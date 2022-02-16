using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class Plotter : Form
    {
        #region Globals
        private bool ShowBestFit { get; set; }
        private bool RemoveAngle { get; set; } = true;
        private bool FlipX { get; set; } = false;
        private bool FlipY { get; set; } = false;
        private bool FlipZ { get; set; } = false;
        private string Path { get; set; }
        private List<Scan> Scans { get; set; } = new List<Scan>();
        private Scan[] ActiveScans { get; set; } = new Scan[4];
        private FormsPlot[] Plots { get; set; }
        private ScottPlot.Plottable.ScatterPlot[] ErasePointPlots { get; set; } = new ScottPlot.Plottable.ScatterPlot[4];
        private ScottPlot.Plottable.MarkerPlot[] HighlightPointPlots { get; set; } = new ScottPlot.Plottable.MarkerPlot[4];
        private int[] LastHighlightedPoints { get; set; } = new int[4];
        private ToolStripComboBox[] ComboBoxes { get; set; }
        private double[] CustomAxes { get; set; } = new double[6];
        public bool ErasePointEnabled { get; set; }
        private bool _EraseOnClickEnabled = false;
        private bool EraseOnClickEnabled
        {
            get => _EraseOnClickEnabled;
            set
            {
                _EraseOnClickEnabled = value;
                checkBoxEraseData.FlatAppearance.CheckedBackColor = _EraseOnClickEnabled ? Color.LightCoral : Color.Gold;
            }
        }

        #endregion

        public Plotter(string filePath)
        {
            InitializeComponent();
            olv.SelectionChanged += Olv_SelectionChanged;

            Plots = new FormsPlot[] { pA, pB, pC, pD };
            foreach (FormsPlot p in Plots)
            {
                p.Plot.Grid(false);
                p.MouseMove += P_MouseMove;
                p.MouseUp += P_MouseUp;
            }

            ComboBoxes = new ToolStripComboBox[] { comboX, comboY, comboZ };
            foreach (ToolStripComboBox comboBox in ComboBoxes)
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            Control[] toolTipContols = tlp.Controls.Cast<Control>().Where(x => x.GetType() == typeof(CheckBox) || x.GetType() == typeof(Button)).ToArray();
            foreach (Control control in toolTipContols)
            {
                ToolTip tip = new ToolTip() { InitialDelay = 1 };
                if (control.AccessibleDescription != null) tip.SetToolTip(control, control.AccessibleDescription.Replace('_', '\n'));
            }

            Path = filePath;
            Show();
            MakeList();
            MakePlots();
        }

        private void P_MouseUp(object sender, MouseEventArgs e)
        {
            if (!EraseOnClickEnabled) return;

            FormsPlot p = (FormsPlot)sender;
            int plotIdx = int.Parse(p.Tag.ToString());
            if (ActiveScans[plotIdx] == null) return;

            ActiveScans[plotIdx].Data.RemoveAt(LastHighlightedPoints[plotIdx]);
            ActiveScans[plotIdx].Edited = true;
            olv.Refresh();
            MakePlots();
        }

        private void P_MouseMove(object sender, MouseEventArgs e)
        {
            if (!EraseOnClickEnabled) return;

            FormsPlot p = (FormsPlot)sender;
            int plotIdx = int.Parse(p.Tag.ToString());
            if (ErasePointPlots[plotIdx] == null) return;

            (double mouseCoordX, double mouseCoordY) = p.GetMouseCoordinates();
            double xyRatio = p.Plot.XAxis.Dims.PxPerUnit / p.Plot.YAxis.Dims.PxPerUnit;
            (double pointX, double pointY, int pointIndex) = ErasePointPlots[plotIdx].GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);

            HighlightPointPlots[plotIdx].X = pointX;
            HighlightPointPlots[plotIdx].Y = pointY;
            HighlightPointPlots[plotIdx].IsVisible = true;

            if (LastHighlightedPoints[plotIdx] != pointIndex)
            {
                LastHighlightedPoints[plotIdx] = pointIndex;
                p.Refresh();
            }
        }

        #region Log Parsing

        private void MakeList()
        {
            ProgressBar.Style = ProgressBarStyle.Marquee;
            ProgressBar.MarqueeAnimationSpeed = 100;

            FindScans();
            olv.SetObjects(Scans);
            olv.Sort(OlvColumnIndex, SortOrder.Descending);

            ProgressBar.Style = ProgressBarStyle.Continuous;
            ProgressBar.MarqueeAnimationSpeed = 0;
        }

        private void FindScans()
        {
            Scans.Clear();
            int scanIdx = -1;
            StreamReader reader = new StreamReader(Path);
            while (reader.Peek() != -1)
            {
                Application.DoEvents();
                var line = reader.ReadLine();
                _ = reader.Peek();
                if (line.Contains("NEWSCAN"))
                {
                    scanIdx += 1;
                    var info = line.Split('\t');
                    var thisScan = new Scan()
                    {
                        Index = scanIdx + 1,
                        ShortDate = DateTime.Parse(info[0]).ToString("yyyy-MM-dd"),
                        Time = DateTime.Parse(info[0]).ToString("HH:mm:ss"),
                        Name = info[2]
                    };
                    if (info.Length > 3)
                    {
                        thisScan.Temp = double.Parse(info[3]);
                        thisScan.RH = double.Parse(info[4]);
                    }
                    if (info.Length > 5)
                    {
                        thisScan.ScanSpeed = int.Parse(info[5]);
                        thisScan.NumPasses = int.Parse(info[6]);
                        thisScan.Threshold = int.Parse(info[7]);
                    }
                    Scans.Add(thisScan);
                }
                else
                    try
                    {
                        Scans[scanIdx].Data.Add(Zed.toPosition(line));
                        Scans[scanIdx].BackupData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(text: $"Invalid File: {ex}", caption: "XYZscan");
                        return;
                    }
            }
        }

        #endregion

        #region Plot Selection

        private void Olv_SelectionChanged(object sender, EventArgs e)
        {
            MakePlots();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboX.SelectedIndex < 1)
            {
                toolStripY.Enabled = false;
                comboY.SelectedIndex = 0;
            }
            if (comboY.SelectedIndex < 1)
            {
                toolStripZ.Enabled = false;
                comboZ.SelectedIndex = 0;
            }
            toolStripY.Enabled = comboX.SelectedIndex > 0;
            toolStripZ.Enabled = comboY.SelectedIndex > 0;
            MakePlots();
        }

        private void MakePlots()
        {
            UpdateEraseDataMode();
            if (olv.SelectedIndices.Count <= 4)
            {
                List<double[]> bounds = new List<double[]> ();
                for (int i = 0; i < olv.SelectedObjects.Count; i++)
                {
                    Scan scan = (Scan)olv.SelectedObjects[i];
                    ActiveScans[i] = scan;
                    if (scan.Data.Count > 3) bounds.Add(CreatePlot(i, scan));
                }
                for (int i = olv.SelectedObjects.Count; i < Plots.Length; i++)
                {
                    Plots[i].Plot.Clear();
                    Plots[i].Plot.Title("");
                    ClearAxisLabels(Plots[i].Plot);
                    Plots[i].Refresh();
                }
                UpdateToolbars(bounds);
            }
        }

        #endregion

        #region Plotting

        private double[] CreatePlot(int plotIdx, Scan scan)
        {
            FormsPlot formsPlot = Plots[plotIdx];
            formsPlot.Plot.Clear();
            ClearAxisLabels(formsPlot.Plot);

            Zed.Position[] data = (Zed.Position[])scan.Data.ToArray().Clone();
            if (CustomAxes.Sum() != 0)
            {
                try
                {
                    data = Zed.filterData(data, comboX.SelectedIndex, CustomAxes[0], CustomAxes[1]);
                    data = Zed.filterData(data, comboY.SelectedIndex, CustomAxes[2], CustomAxes[3]);
                    data = Zed.filterData(data, comboZ.SelectedIndex, CustomAxes[4], CustomAxes[5]);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid custom axes", "XferSuite");
                }
            }

            if (3 > data.Length)
            {
                MessageBox.Show("Insufficient data.", "XferSuite");
                return new double[6];
            }

            Zed.Plane plane = Zed.getPlane(data);
            for (int i = 0; i < data.Length; i++)
            {
                Zed.Position p = data[i];
                data[i] = new Zed.Position(p.Time, p.X, p.Y, p.Z, 
                    RemoveAngle ? p.H - Zed.projectPlane(plane, Zed.posToVec3(data[i])).Z : p.H, 
                    p.I);
            }

            double[] xAxisData = Zed.getAxis(data, comboX.SelectedIndex);
            double[] yAxisData = Zed.getAxis(data, comboY.SelectedIndex);
            double[] zAxisData = Zed.getAxis(data, comboZ.SelectedIndex);
            if (FlipX) FlipAxis(ref xAxisData);
            if (FlipY) FlipAxis(ref yAxisData);
            if (FlipZ) FlipAxis(ref zAxisData);
            int numAxes = 0;
            foreach (ToolStripComboBox cbx in ComboBoxes)
                if (cbx.SelectedIndex > 0) numAxes++;

            try
            {
                switch (numAxes)
                {
                    case 0:
                        break;
                    case 1:
                        (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(xAxisData, min: xAxisData.Min(), max: xAxisData.Max(), binSize: 0.25);
                        double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();
                        var bar = formsPlot.Plot.AddBar(values: counts, positions: leftEdges);
                        bar.BarWidth = 0.25;
                        bar.BorderColor = Color.Transparent;
                        formsPlot.Plot.XAxis.Label(comboX.Text);
                        formsPlot.Plot.YAxis.Label("Count (#)");
                        formsPlot.Plot.SetAxisLimits(yMin: 0);
                        formsPlot.Plot.Title(
                            $"{scan.Name}\nRange: {Math.Round(xAxisData.Max() - xAxisData.Min(), 3)}   3Sigma = {Zed.threeSigma(xAxisData)}", false);
                        if (ShowBestFit)
                        {
                            double[] densities = ScottPlot.Statistics.Common.ProbabilityDensity(xAxisData, binEdges);
                            var probPlot = formsPlot.Plot.AddScatterLines(binEdges, densities, Color.Black, 3, LineStyle.Dash);
                            probPlot.YAxisIndex = 1;
                            formsPlot.Plot.SetAxisLimits(yMin: 0, yAxisIndex: 1);
                        }
                        break;
                    case 2:
                        ErasePointPlots[plotIdx] = formsPlot.Plot.AddScatterPoints(xAxisData, yAxisData);
                        formsPlot.Plot.XAxis.Label(comboX.Text);
                        formsPlot.Plot.YAxis.Label(comboY.Text);
                        formsPlot.Plot.Title(
                                $"{scan.Name}\nRange: {Math.Round(yAxisData.Max() - yAxisData.Min(), 3)}   3Sigma = { Zed.threeSigma(yAxisData)}", false);
                        if (ShowBestFit)
                        {
                            double[] poly = Zed.scatterPolynomial(xAxisData, yAxisData);
                            double[] polyData = xAxisData.Select(x => poly[0] + poly[1] * x + poly[2] * Math.Pow(x, 2) + poly[3] * Math.Pow(x, 3)).ToArray();
                            formsPlot.Plot.AddFunction(
                                new Func<double, double?>((x) => poly[0] + poly[1] * x + poly[2] * Math.Pow(x, 2) + poly[3] * Math.Pow(x, 3)),
                                Color.Black, 3, LineStyle.Dash);
                            var annotation = formsPlot.Plot.AddAnnotation($"R² = {Zed.rSquared(polyData, yAxisData)}", 5, 5);
                            annotation.Shadow = false;
                            annotation.BackgroundColor = Color.White;
                        }
                        if (EraseOnClickEnabled)
                        {
                            HighlightPointPlots[plotIdx] = formsPlot.Plot.AddPoint(0, 0);
                            HighlightPointPlots[plotIdx].Color = Color.Red;
                            HighlightPointPlots[plotIdx].IsVisible = false;
                        }
                        break;
                    case 3:
                        double minH = zAxisData.Min();
                        double maxH = zAxisData.Max();
                        for (int i = 0; i < data.Length; i++)
                        {
                            double colorFraction = (zAxisData[i] - minH) / (maxH - minH);
                            if (colorFraction > 1) colorFraction = maxH / zAxisData[i];
                            Color c = ScottPlot.Drawing.Colormap.Viridis.GetColor(colorFraction);
                            formsPlot.Plot.AddPoint(xAxisData[i], yAxisData[i], c);
                        }
                        formsPlot.Plot.XAxis.Label(comboX.Text);
                        formsPlot.Plot.YAxis.Label(comboY.Text);
                        formsPlot.Plot.Title(
                            $"{scan.Name}\nRange: {Math.Round(zAxisData.Max() - zAxisData.Min(), 3)}   3Sigma = { Zed.threeSigma(zAxisData)}", false);
                        if (ShowBestFit)
                        {
                            double[] poly = Zed.scatterPolynomial(xAxisData, yAxisData);
                            double[] polyData = xAxisData.Select(x => poly[0] + poly[1] * x + poly[2] * Math.Pow(x, 2) + poly[3] * Math.Pow(x, 3)).ToArray();
                            formsPlot.Plot.AddFunction(
                                new Func<double, double?>((x) => poly[0] + poly[1] * x + poly[2] * Math.Pow(x, 2) + poly[3] * Math.Pow(x, 3)),
                                Color.Black, 3, LineStyle.Dash);
                            var annotation = formsPlot.Plot.AddAnnotation($"R² = {Zed.rSquared(polyData, yAxisData)}", 5, 5);
                            annotation.Shadow = false;
                            annotation.BackgroundColor = Color.White;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                var msg = formsPlot.Plot.AddAnnotation("Insufficient Data", 10, 10);
                msg.Font.Size = 24;
                msg.Shadow = false;
                msg.BackgroundColor = Color.Transparent;
                msg.BorderColor = Color.Transparent;
                formsPlot.Plot.Title(
                    $"{scan.Name}\nRange: N/A   3Sigma = N/A", false);
            }

            return new double[] {xAxisData.Min(), xAxisData.Max(), yAxisData.Min(), yAxisData.Max(), zAxisData.Min(), zAxisData.Max()};
        }

        private void UpdateToolbars(List<double[]> bounds)
        {
            double[] groupBounds = new double[] { double.MaxValue, double.MinValue, double.MaxValue, double.MinValue, double.MaxValue, double.MinValue };
            for (int i = 0; i < bounds.Count; i++)
            {
                for (int j = 0; j < groupBounds.Length; j += 2)
                {
                    if (bounds[i][j] != 0.0 || bounds[i][j + 1] != 0.0)
                    {
                        if (bounds[i][j] < groupBounds[j]) groupBounds[j] = bounds[i][j];
                        if (bounds[i][j + 1] > groupBounds[j + 1]) groupBounds[j + 1] = bounds[i][j + 1];
                    }
                }
            }
            for (int i = 0; i < groupBounds.Length; i += 2)
            {
                string range = (groupBounds[i] != double.MaxValue && groupBounds[i + 1] != double.MinValue) ?
                    Math.Round(groupBounds[i + 1] - groupBounds[i], 3).ToString() : "N/A";
                switch (i/2)
                {
                    case 0:
                        toolStripLabelRangeX.Text = range;
                        break;
                    case 1:
                        toolStripLabelRangeY.Text = range;
                        break;
                    case 2:
                        toolStripLabelRangeZ.Text = range;
                        break;
                    default:
                        break;
                }
            }

            int numAxes = 0;
            foreach (ToolStripComboBox cbx in ComboBoxes)
                if (cbx.SelectedIndex > 0) numAxes++;

            for (int i = 0; i < groupBounds.Length; i += 2)
            {
                groupBounds[i] = groupBounds[i];
                groupBounds[i + 1] = groupBounds[i + 1];
            }

            for (int i = 0; i < 4; i++)
            {
                if (!ErasePointEnabled)
                {
                    switch (numAxes)
                    {
                        case 0:
                            break;
                        case 1:
                            Plots[i].Plot.SetAxisLimitsX(groupBounds[0], groupBounds[1]);
                            break;
                        case 2:
                            Plots[i].Plot.SetAxisLimits(groupBounds[0], groupBounds[1], groupBounds[2], groupBounds[3]);
                            break;
                        case 3:
                            Plots[i].Plot.SetAxisLimits(groupBounds[0], groupBounds[1], groupBounds[2], groupBounds[3]);
                            var cmap = ScottPlot.Drawing.Colormap.Viridis;
                            var cb = Plots[i].Plot.AddColorbar(cmap);
                            cb.YAxisIndex = i;
                            Plots[i].Plot.YAxis2.Label(comboZ.Text);
                            cb.MinValue = groupBounds[4];
                            cb.MaxValue = groupBounds[5];
                            break;
                        default:
                            break;
                    }
                }

                try
                {
                    Plots[i].Refresh();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
        }

        private void ClearAxisLabels(Plot plot)
        {
            plot.XAxis.Label("");
            plot.YAxis.Label("");
            plot.YAxis2.Label("");
        }

        #endregion

        #region Plot Customization

        private void FlipAxis(ref double[] data)
        {
            double max = data.Max();
            double min = data.Min();
            for (int i = 0; i < data.Length; i++)
                data[i] = Math.Abs(data[i] - max) - min;
        }

        private void toolStripButtonFlipX_Click(object sender, EventArgs e)
        {
            FlipX = !FlipX;
            ((ToolStripButton)sender).BackColor = FlipX ? Color.LightGreen : SystemColors.Control;
            MakePlots();
        }

        private void toolStripButtonFlipY_Click(object sender, EventArgs e)
        {
            FlipY = !FlipY;
            ((ToolStripButton)sender).BackColor = FlipY ? Color.LightGreen : SystemColors.Control;
            MakePlots();
        }

        private void toolStripButtonFlipZ_Click(object sender, EventArgs e)
        {
            FlipZ = !FlipZ;
            ((ToolStripButton)sender).BackColor = FlipZ ? Color.LightGreen : SystemColors.Control;
            MakePlots();
        }

        private void checkBoxShowBestFit_CheckedChanged(object sender, EventArgs e)
        {
            ShowBestFit = !ShowBestFit;
            MakePlots();
        }

        private void checkBoxRemoveAngle_CheckedChanged(object sender, EventArgs e)
        {
            RemoveAngle = !RemoveAngle;
            MakePlots();
        }

        private void checkBoxEraseData_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEraseDataMode(redraw: true);
        }

        private void UpdateEraseDataMode(bool redraw = false)
        {
            ErasePointEnabled = checkBoxEraseData.Checked;
            EraseOnClickEnabled = ErasePointEnabled ? (comboX.SelectedIndex == 1 || comboX.SelectedIndex == 2) && comboY.SelectedIndex == 4 && comboZ.SelectedIndex < 1 : false;
            if (redraw) MakePlots();
        }

        private void buttonAutoscale_Click(object sender, EventArgs e)
        {
            foreach (FormsPlot plot in Plots)
            {
                plot.Plot.AxisAuto();
                plot.Refresh();
            } 
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            if (olv.SelectedObject != null)
            {
                ((Scan)olv.SelectedObject).RevertData();
                MakePlots();
            }
        }

        #endregion

        private void buttonExportSelected_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Export Selected Scans";
                saveFileDialog.DefaultExt = ".txt";
                saveFileDialog.Filter = "Text file (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)               
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                        for (int i = olv.SelectedObjects.Count - 1; i >= 0; i--)
                            sw.Write(((Scan)olv.SelectedObjects[i]).ToString());
            }
        }
    }
}
