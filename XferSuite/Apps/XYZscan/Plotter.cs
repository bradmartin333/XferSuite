﻿using ScottPlot;
using ScottPlot.Plottable;
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
        private ToolStripComboBox[] ComboBoxes { get; set; }
        private bool ShowBestFit { get; set; }
        private bool RemoveAngle { get; set; } = true;
        private bool Equalize { get; set; } = false;
        private bool FlipX { get; set; } = false;
        private bool FlipY { get; set; } = false;
        private bool FlipZ { get; set; } = false;
        private string Path { get; set; }
        private List<Scan> Scans { get; set; } = new List<Scan>();
        private Scan[] ActiveScans { get; set; } = new Scan[4];
        private int LastActiveScans { get; set; } = -1;
        private FormsPlot[] Plots { get; set; }
        private ScatterPlot[] ErasePointPlots { get; set; } = new ScatterPlot[4];
        private MarkerPlot[] HighlightPointPlots { get; set; } = new MarkerPlot[4];
        private int[] LastHighlightedPoints { get; set; } = new int[4];
        private HSpan[] HSpan { get; set; } = new HSpan[4];
        private VSpan[] VSpan { get; set; } = new VSpan[4];
        public bool EraseDataEnabled { get; set; }
        private bool _EraseOnClickEnabled = false;
        private bool ErasePointEnabled
        {
            get => _EraseOnClickEnabled;
            set
            {
                _EraseOnClickEnabled = value;
                checkBoxEraseData.FlatAppearance.CheckedBackColor = _EraseOnClickEnabled ? Color.LightCoral : Color.Gold;
            }
        }
        private readonly string[] AxesStrings = new string[] { "None", "X (mm)", "Y (mm)", "Z (mm)", "Height (µm)", "Intensity (%)", "Z - Height (mm)" };
        private enum Axes { Null, X, Y, Z, H, I, ZH }

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
            {
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                comboBox.Items.AddRange(AxesStrings);
            }
            comboX.SelectedIndex = (int)Axes.X;
            comboY.SelectedIndex = (int)Axes.Y;
            comboZ.SelectedIndex = (int)Axes.H;
                
            Control[] toolTipContols = tlp.Controls.Cast<Control>().Where(c => c.GetType() == typeof(CheckBox) || c.GetType() == typeof(Button)).ToArray();
            foreach (Control control in toolTipContols)
            {
                ToolTip tip = new ToolTip() { InitialDelay = 1 };
                if (control.AccessibleDescription != null) tip.SetToolTip(control, control.AccessibleDescription.Replace('_', '\n'));
            }

            checkBoxEraseData.MouseUp += CheckBoxEraseData_MouseUp;

            Path = filePath;
            Show();
            MakeList();
        }

        #region Mouse Handlers

        private void CheckBoxEraseData_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) TurnOffEraseMode();
        }

        private void P_MouseUp(object sender, MouseEventArgs e)
        {
            if (!ErasePointEnabled) return;

            FormsPlot p = (FormsPlot)sender;
            int plotIdx = int.Parse(p.Tag.ToString());
            if (ActiveScans[plotIdx] == null) return;

            try
            {
                ActiveScans[plotIdx].Data.RemoveAt(LastHighlightedPoints[plotIdx]);
                ActiveScans[plotIdx].Edited = true;
                MakePlots();
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Exception in P_MouseUp");
            }
        }

        private void P_MouseMove(object sender, MouseEventArgs e)
        {
            if (!ErasePointEnabled) return;

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

        #endregion

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
            if (comboX.SelectedIndex == (int)Axes.Null)
            {
                toolStripY.Enabled = false;
                comboY.SelectedIndex = (int)Axes.Null;
            }
            if (comboY.SelectedIndex == (int)Axes.Null)
            {
                toolStripZ.Enabled = false;
                comboZ.SelectedIndex = (int)Axes.Null;
            }
            toolStripY.Enabled = comboX.SelectedIndex != (int)Axes.Null;
            toolStripZ.Enabled = comboY.SelectedIndex != (int)Axes.Null;
            MakePlots();
        }

        private void MakePlots()
        {
            olv.Refresh();
            UpdateEraseDataMode();

            if (olv.SelectedIndices.Count <= 4)
            {
                (double, double) colorScaling = (double.MaxValue, double.MinValue);
                if (comboZ.SelectedIndex != (int)Axes.Null)
                {
                    for (int i = 0; i < olv.SelectedObjects.Count; i++)
                    {
                        Scan scan = (Scan)olv.SelectedObjects[i];
                        Zed.Position[] data = (Zed.Position[])scan.Data.ToArray().Clone();
                        if (3 > data.Length && RemoveAngle) continue;
                        data = ApplyFilters(data);
                        double[] plotData = Zed.getAxis(data, comboZ.SelectedIndex);
                        if (plotData.Min() < colorScaling.Item1) colorScaling.Item1 = plotData.Min();
                        if (plotData.Max() > colorScaling.Item2) colorScaling.Item2 = plotData.Max();
                    }
                }

                List<double[]> bounds = new List<double[]> ();
                for (int i = 0; i < olv.SelectedObjects.Count; i++)
                {
                    Scan scan = (Scan)olv.SelectedObjects[i];
                    ActiveScans[i] = scan;
                    bounds.Add(CreatePlot(i, scan, colorScaling));
                    Plots[i].Visible = true;
                }
                if (olv.SelectedObjects.Count != LastActiveScans) for (int i = olv.SelectedObjects.Count; i < Plots.Length; i++) Plots[i].Visible = false;
                LastActiveScans = olv.SelectedObjects.Count;
                ApplyBounds(bounds);
            }
        }

        #endregion

        #region Plotting

        private Zed.Position[] ApplyFilters(Zed.Position[] data)
        {
            if (RemoveAngle)
            {
                Zed.Plane plane = Zed.getPlane(data);
                for (int i = 0; i < data.Length; i++)
                {
                    Zed.Position p = data[i];
                    data[i] = new Zed.Position(p.Time, p.X, p.Y, p.Z, p.H - Zed.projectPlane(plane, Zed.posToVec3(data[i])).Z, p.I);
                }
            }
            if (Equalize)
            {
                double equalizer = Zed.getAxis(data, 4).Min();
                for (int i = 0; i < data.Length; i++)
                    data[i] = new Zed.Position(data[i].Time, data[i].X, data[i].Y, data[i].Z, data[i].H - equalizer, data[i].I);
            }
            return data;
        }

        private double[] CreatePlot(int plotIdx, Scan scan, (double, double) colorScaling)
        {
            FormsPlot formsPlot = Plots[plotIdx];
            formsPlot.Plot.Clear();
            ClearAxisLabels(formsPlot.Plot);

            Zed.Position[] data = (Zed.Position[])scan.Data.ToArray().Clone();
            if (3 > data.Length)
            {
                formsPlot.Plot.Title($"{scan.Name}\nInsufficient Data", false);
                return new double[6];
            }
            data = ApplyFilters(data);

            (double colorMin, double colorMax) = colorScaling;

            double[] xAxisData = Zed.getAxis(data, comboX.SelectedIndex);
            double[] yAxisData = Zed.getAxis(data, comboY.SelectedIndex);
            double[] zAxisData = Zed.getAxis(data, comboZ.SelectedIndex);

            if (FlipX) for (int i = 0; i < xAxisData.Length; i++) xAxisData[i] *= -1;
            if (FlipY) for (int i = 0; i < yAxisData.Length; i++) yAxisData[i] *= -1;
            if (FlipZ) for (int i = 0; i < zAxisData.Length; i++) zAxisData[i] *= -1;

            try
            {
                switch (ComboBoxes.Where(x => x.SelectedIndex != (int)Axes.Null).Count())
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
                        if (ErasePointEnabled)
                        {
                            HighlightPointPlots[plotIdx] = formsPlot.Plot.AddPoint(0, 0);
                            HighlightPointPlots[plotIdx].Color = Color.Red;
                            HighlightPointPlots[plotIdx].IsVisible = false;
                        }
                        break;
                    case 3:
                        for (int i = 0; i < data.Length; i++)
                        {
                            double colorFraction = (zAxisData[i] - colorMin) / (colorMax - colorMin);
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

                if (EraseDataEnabled && !ErasePointEnabled)
                {
                    HSpan[plotIdx] = formsPlot.Plot.AddHorizontalSpan(xAxisData.Min() - 2, xAxisData.Min() - 1, Color.FromArgb(150, Color.DarkRed));
                    HSpan[plotIdx].DragEnabled = true;
                    VSpan[plotIdx] = formsPlot.Plot.AddVerticalSpan(yAxisData.Min() - 2, yAxisData.Min() - 1, Color.FromArgb(150, Color.DarkViolet));
                    VSpan[plotIdx].DragEnabled = true;
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

            return new double[] { xAxisData.Min(), xAxisData.Max(), yAxisData.Min(), yAxisData.Max(), colorMin, colorMax };
        }

        private void ApplyBounds(List<double[]> bounds)
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
                if (cbx.SelectedIndex != (int)Axes.Null) numAxes++;

            for (int i = 0; i < groupBounds.Length; i += 2)
            {
                groupBounds[i] = groupBounds[i];
                groupBounds[i + 1] = groupBounds[i + 1];
            }

            for (int i = 0; i < 4; i++)
            {
                if (!EraseDataEnabled)
                {
                    switch (numAxes)
                    {
                        case 0:
                            break;
                        case 1:
                            Plots[i].Plot.SetAxisLimitsX(groupBounds[0], groupBounds[1]);
                            Plots[i].Plot.XAxis.TickLabelNotation(invertSign: FlipX);
                            Plots[i].Plot.XAxis.TickLabelFormat(CustomTickFormatter);
                            break;
                        case 2:
                            Plots[i].Plot.SetAxisLimits(groupBounds[0], groupBounds[1], groupBounds[2], groupBounds[3]);
                            Plots[i].Plot.XAxis.TickLabelNotation(invertSign: FlipX);
                            Plots[i].Plot.YAxis.TickLabelNotation(invertSign: FlipY);
                            Plots[i].Plot.XAxis.TickLabelFormat(CustomTickFormatter);
                            Plots[i].Plot.YAxis.TickLabelFormat(CustomTickFormatter);
                            break;
                        case 3:
                            Plots[i].Plot.SetAxisLimits(groupBounds[0], groupBounds[1], groupBounds[2], groupBounds[3]);
                            var cmap = ScottPlot.Drawing.Colormap.Viridis;
                            var cb = Plots[i].Plot.AddColorbar(cmap);
                            cb.YAxisIndex = i;
                            Plots[i].Plot.YAxis2.Label(comboZ.Text);
                            cb.MinValue = groupBounds[4];
                            cb.MaxValue = groupBounds[5];
                            Plots[i].Plot.XAxis.TickLabelNotation(invertSign: FlipX);
                            Plots[i].Plot.YAxis.TickLabelNotation(invertSign: FlipY);
                            Plots[i].Plot.YAxis2.TickLabelNotation(invertSign: FlipZ);
                            Plots[i].Plot.XAxis.TickLabelFormat(CustomTickFormatter);
                            Plots[i].Plot.YAxis.TickLabelFormat(CustomTickFormatter);
                            Plots[i].Plot.YAxis2.TickLabelFormat(CustomTickFormatter);
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

        private string CustomTickFormatter(double position)
        {
            return $"{position:F3}";
        }

        private void ClearAxisLabels(Plot plot)
        {
            plot.XAxis.Label("");
            plot.YAxis.Label("");
            plot.YAxis2.Label("");
        }

        #endregion

        #region Plot Customization

        private void ToolStripButtonFlipX_Click(object sender, EventArgs e)
        {
            FlipX = !FlipX;
            ((ToolStripButton)sender).BackColor = FlipX ? Color.LightGreen : SystemColors.Control;
            MakePlots();
        }

        private void ToolStripButtonFlipY_Click(object sender, EventArgs e)
        {
            FlipY = !FlipY;
            ((ToolStripButton)sender).BackColor = FlipY ? Color.LightGreen : SystemColors.Control;
            MakePlots();
        }

        private void ToolStripButtonFlipZ_Click(object sender, EventArgs e)
        {
            FlipZ = !FlipZ;
            ((ToolStripButton)sender).BackColor = FlipZ ? Color.LightGreen : SystemColors.Control;
            MakePlots();
        }

        private void CheckBoxShowBestFit_CheckedChanged(object sender, EventArgs e)
        {
            ShowBestFit = !ShowBestFit;
            MakePlots();
            ProgressBar.Focus();
        }

        private void CheckBoxRemoveAngle_CheckedChanged(object sender, EventArgs e)
        {
            RemoveAngle = !RemoveAngle;
            MakePlots();
            ProgressBar.Focus();
        }

        private void CheckBoxEqualize_CheckedChanged(object sender, EventArgs e)
        {
            Equalize = !Equalize;
            MakePlots();
            ProgressBar.Focus();
        }

        private void CheckBoxEraseData_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxEraseData.Checked && EraseDataEnabled && !ErasePointEnabled) CreateCustomAxes();
            UpdateEraseDataMode(redraw: true);
            ProgressBar.Focus();
        }

        private void CreateCustomAxes()
        {
            for (int i = 0; i < olv.SelectedIndices.Count; i++)
            {
                try
                {
                    (double, double) HSpanVals = (Math.Min(HSpan[i].X1, HSpan[i].X2), Math.Max(HSpan[i].X1, HSpan[i].X2));
                    (double, double) VSpanVals = (Math.Min(VSpan[i].Y1, VSpan[i].Y2), Math.Max(VSpan[i].Y1, VSpan[i].Y2));
                    int originalNumPoints = ActiveScans[i].Data.Count;
                    ActiveScans[i].Data.RemoveAll(s => 
                        (HSpanVals.Item1 <= (Zed.getAxisSingle(s, comboX.SelectedIndex) * (FlipX ? -1 : 1))) && 
                        ((Zed.getAxisSingle(s, comboX.SelectedIndex) * (FlipX ? -1 : 1)) <= HSpanVals.Item2) && 
                        (VSpanVals.Item1 <= (Zed.getAxisSingle(s, comboY.SelectedIndex) * (FlipY ? -1 : 1))) && 
                        ((Zed.getAxisSingle(s, comboY.SelectedIndex) * (FlipY ? -1 : 1)) <= VSpanVals.Item2));
                    ActiveScans[i].Edited = ActiveScans[i].Edited || originalNumPoints > ActiveScans[i].Data.Count;
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine("Exception in CreateCustomAxes");
                }
            }
            MakePlots();
        }

        private void UpdateEraseDataMode(bool redraw = false)
        {
            EraseDataEnabled = checkBoxEraseData.Checked;
            if (EraseDataEnabled && (comboX.SelectedIndex == (int)Axes.H || comboY.SelectedIndex == (int)Axes.H || 
                comboX.SelectedIndex == (int)Axes.ZH || comboY.SelectedIndex == (int)Axes.ZH) && 
                comboZ.SelectedIndex != (int)Axes.Null) TurnOffEraseMode();
            ErasePointEnabled = EraseDataEnabled && (comboX.SelectedIndex == (int)Axes.X || comboX.SelectedIndex == (int)Axes.Y) && 
                comboY.SelectedIndex == (int)Axes.H && comboZ.SelectedIndex == (int)Axes.Null;
            if (redraw) MakePlots();
        }

        private void TurnOffEraseMode()
        {
            EraseDataEnabled = false;
            ErasePointEnabled = false;
            checkBoxEraseData.Checked = false;
            MakePlots();
        }

        private void ButtonAutoscale_Click(object sender, EventArgs e)
        {
            foreach (FormsPlot plot in Plots)
            {
                plot.Plot.AxisAuto();
                plot.Refresh();
            }
            ProgressBar.Focus();
        }

        private void BtnRevert_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < olv.SelectedObjects.Count; i++) ((Scan)olv.SelectedObjects[i]).RevertData();
            MakePlots();
            ProgressBar.Focus();
        }

        #endregion

        private void ButtonExportSelected_Click(object sender, EventArgs e)
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
            ProgressBar.Focus();
        }
    }
}
