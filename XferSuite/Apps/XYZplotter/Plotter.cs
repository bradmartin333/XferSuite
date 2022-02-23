using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XferHelper;
using XferSuite.Apps.XYZplotter;
using static XferSuite.Apps.XYZplotter.Configuration;

namespace XferSuite
{
    public partial class Plotter : Form
    {
        #region Globals

        // Controls
        private readonly string[] AxesStrings = new string[] { "None", "X (mm)", "Y (mm)", "Z (mm)", "Height (µm)", "Intensity (%)", "Z - Height (mm)" };
        private ToolStripComboBox[] ComboBoxes { get; set; }
        private FormsPlot[] Plots { get; set; }

        // Plottables
        private ScatterPlot[] ErasePointPlots { get; set; } = new ScatterPlot[4];
        private MarkerPlot[] HighlightPointPlots { get; set; } = new MarkerPlot[4];
        private HSpan[] HSpan { get; set; } = new HSpan[4];
        private VSpan[] VSpan { get; set; } = new VSpan[4];

        // Data
        private string Path { get; set; }
        private List<Scan> Scans { get; set; } = new List<Scan>();
        private Scan[] ActiveScans { get; set; } = new Scan[4];
        private int LastActiveScans { get; set; } = -1;
        private int[] LastHighlightedPoints { get; set; } = new int[4];
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

        #endregion

        public Plotter(string path)
        {
            InitializeComponent();
            Path = path;
            olv.SelectionChanged += Olv_SelectionChanged;

            Plots = new FormsPlot[] { pA, pB, pC, pD };
            foreach (FormsPlot p in Plots)
            {
                p.Plot.Grid(false);
                p.MouseMove += P_MouseMove;
                p.MouseUp += P_MouseUp;
                p.Configuration.DoubleClickBenchmark = false;
            }

            ComboBoxes = new ToolStripComboBox[] { comboX, comboY, comboZ };
            foreach (ToolStripComboBox comboBox in ComboBoxes)
            {
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                comboBox.Items.AddRange(AxesStrings);
            }
            comboX.SelectedIndex = (int)Zed.Axes.X;
            comboY.SelectedIndex = (int)Zed.Axes.Y;
            comboZ.SelectedIndex = (int)Zed.Axes.H;
                
            Control[] toolTipContols = tlp.Controls.Cast<Control>().Where(c => c.GetType() == typeof(CheckBox) || c.GetType() == typeof(Button)).ToArray();
            foreach (Control control in toolTipContols)
            {
                ToolTip tip = new ToolTip() { InitialDelay = 1 };
                if (control.AccessibleDescription != null) tip.SetToolTip(control, control.AccessibleDescription.Replace('_', '\n'));
            }

            checkBoxEraseData.MouseUp += CheckBoxEraseData_MouseUp;

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

            using (StreamReader reader = new StreamReader(Path))
            {
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
                            MessageBox.Show(text: $"Invalid File: {ex}", caption: "XYZ Plotter");
                            return;
                        }
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
            if (comboX.SelectedIndex == (int)Zed.Axes.None)
            {
                toolStripY.Enabled = false;
                comboY.SelectedIndex = (int)Zed.Axes.None;
            }
            if (comboY.SelectedIndex == (int)Zed.Axes.None)
            {
                toolStripZ.Enabled = false;
                comboZ.SelectedIndex = (int)Zed.Axes.None;
            }
            toolStripY.Enabled = comboX.SelectedIndex != (int)Zed.Axes.None;
            toolStripZ.Enabled = comboY.SelectedIndex != (int)Zed.Axes.None;
            MakePlots();
        }

        private void MakePlots()
        {
            // Housekeeping methods
            olv.Refresh();
            ProgressBar.Focus();
            UpdateEraseDataMode();

            if (olv.SelectedIndices.Count <= 4)
            {

                int numPlots = olv.SelectedObjects.Count;
                PlotData[] groupData = new PlotData[numPlots];
                GroupBounds.Reset();
                Scan[] scans = olv.SelectedObjects.Cast<Scan>().ToArray();

                int numAxes = ComboBoxes.Where(x => x.SelectedIndex != (int)Zed.Axes.None).Count();
                Zed.Axes X = (Zed.Axes)comboX.SelectedIndex;
                Zed.Axes Y = (Zed.Axes)comboY.SelectedIndex;
                Zed.Axes Z = (Zed.Axes)comboZ.SelectedIndex;

                try
                {
                    for (int i = 0; i < numPlots; i++)
                    {
                        ActiveScans[i] = scans[i];
                        groupData[i] = new PlotData(scans[i], X, Y, Z);
                    }
                    for (int i = 0; i < numPlots; i++) CreatePlot(i, groupData[i], numAxes);
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine("User changed scan indices before plotting completed");
                }

                if (olv.SelectedObjects.Count != LastActiveScans)
                {
                    for (int i = 0; i < numPlots; i++) Plots[i].Visible = true;
                    for (int i = numPlots; i < Plots.Length; i++) Plots[i].Visible = false;
                }
                LastActiveScans = olv.SelectedObjects.Count;
            }

            UpdateToolStripRange();
        }

        #endregion

        #region Plotting

        private void CreatePlot(int plotIdx, PlotData plotData, int numAxes)
        {
            FormsPlot formsPlot = Plots[plotIdx];
            formsPlot.Plot.Clear();
            ClearAxisLabels(formsPlot.Plot);

            try
            {
                switch (numAxes)
                {
                    case 0:
                        break;
                    case 1:
                        // Make histogram
                        (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(plotData.X, min: plotData.X.Min(), max: plotData.X.Max(), binSize: 0.25);
                        double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();
                        var bar = formsPlot.Plot.AddBar(values: counts, positions: leftEdges);
                        bar.BarWidth = 0.25;
                        bar.BorderColor = Color.Transparent;

                        // Format plot
                        formsPlot.Plot.XAxis.Label(comboX.Text);
                        formsPlot.Plot.YAxis.Label("Count (#)");
                        formsPlot.Plot.SetAxisLimits(yMin: 0);
                        formsPlot.Plot.Title(
                            $"{plotData.Name}\nRange: {Math.Round(plotData.X.Max() - plotData.X.Min(), 3)}   3Sigma = {Stats.threeSig(plotData.X)}", false);
                        formsPlot.Plot.SetAxisLimitsX(GroupBounds.XMin, GroupBounds.XMax);
                        formsPlot.Plot.XAxis.TickLabelNotation(invertSign: FlipX);
                        formsPlot.Plot.XAxis.TickLabelFormat(CustomTickFormatter);

                        if (ShowBestFit)
                        {
                            double[] densities = ScottPlot.Statistics.Common.ProbabilityDensity(plotData.X, binEdges);
                            var probPlot = formsPlot.Plot.AddScatterLines(binEdges, densities, Color.Black, 3, LineStyle.Dash);
                            probPlot.YAxisIndex = 1;
                            formsPlot.Plot.SetAxisLimits(yMin: 0, yAxisIndex: 1);
                        }
                        break;
                    case 2:
                        // Plot and save data for custom erase plot
                        ErasePointPlots[plotIdx] = formsPlot.Plot.AddScatterPoints(plotData.X, plotData.Y);

                        // Format plot
                        formsPlot.Plot.XAxis.Label(comboX.Text);
                        formsPlot.Plot.YAxis.Label(comboY.Text);
                        formsPlot.Plot.Title(
                                $"{plotData.Name}\nRange: {Math.Round(plotData.Y.Max() - plotData.Y.Min(), 3)}   3Sigma = { Stats.threeSig(plotData.Y)}", false);
                        if (!EraseDataEnabled) // Want data easier to see if enabled
                        {
                            formsPlot.Plot.SetAxisLimits(GroupBounds.XMin, GroupBounds.XMax, GroupBounds.YMin, GroupBounds.YMax);
                            formsPlot.Plot.XAxis.TickLabelNotation(invertSign: FlipX);
                            formsPlot.Plot.YAxis.TickLabelNotation(invertSign: FlipY);
                            formsPlot.Plot.XAxis.TickLabelFormat(CustomTickFormatter);
                            formsPlot.Plot.YAxis.TickLabelFormat(CustomTickFormatter);
                        }

                        if (ErasePointEnabled)
                        {
                            HighlightPointPlots[plotIdx] = formsPlot.Plot.AddPoint(0, 0);
                            HighlightPointPlots[plotIdx].Color = Color.Red;
                            HighlightPointPlots[plotIdx].IsVisible = false;
                        }

                        if (ShowBestFit)
                        {
                            double[] poly = Zed.scatterPolynomial(plotData.X, plotData.Y);
                            double[] polyData = plotData.X.Select(x => poly[0] + poly[1] * x + poly[2] * Math.Pow(x, 2) + poly[3] * Math.Pow(x, 3)).ToArray();
                            formsPlot.Plot.AddFunction(
                                new Func<double, double?>((x) => poly[0] + poly[1] * x + poly[2] * Math.Pow(x, 2) + poly[3] * Math.Pow(x, 3)),
                                Color.Black, 3, LineStyle.Dash);
                            var annotation = formsPlot.Plot.AddAnnotation($"R² = {Zed.rSquared(polyData, plotData.Y)}", 5, 5);
                            annotation.Shadow = false;
                            annotation.BackgroundColor = Color.White;
                        }
                        break;
                    case 3:
                        // Add 3D points
                        for (int i = 0; i < plotData.Z.Length; i++)
                        {
                            double colorFraction = (plotData.Z[i] - GroupBounds.ZMin) / (GroupBounds.ZMax - GroupBounds.ZMin);
                            Color c = ScottPlot.Drawing.Colormap.Viridis.GetColor(colorFraction);
                            formsPlot.Plot.AddPoint(plotData.X[i], plotData.Y[i], c);
                        }

                        // Format plot
                        formsPlot.Plot.XAxis.Label(comboX.Text);
                        formsPlot.Plot.YAxis.Label(comboY.Text);
                        formsPlot.Plot.Title(
                            $"{plotData.Name}\nRange: {Math.Round(plotData.Z.Max() - plotData.Z.Min(), 3)}   3Sigma = { Stats.threeSig(plotData.Z)}", false);
                        if (!EraseDataEnabled) // Want data easier to see if enabled
                        {
                            formsPlot.Plot.SetAxisLimits(GroupBounds.XMin, GroupBounds.XMax, GroupBounds.YMin, GroupBounds.YMax);
                            var cmap = ScottPlot.Drawing.Colormap.Viridis;
                            var cb = formsPlot.Plot.AddColorbar(cmap);
                            cb.YAxisIndex = 3;
                            formsPlot.Plot.YAxis2.Label(comboZ.Text);
                            cb.MinValue = GroupBounds.ZMin;
                            cb.MaxValue = GroupBounds.ZMax;
                            cb.AutomaticTicks(formatter: ColorbarFormatter);
                            formsPlot.Plot.XAxis.TickLabelNotation(invertSign: FlipX);
                            formsPlot.Plot.YAxis.TickLabelNotation(invertSign: FlipY);
                            formsPlot.Plot.YAxis2.TickLabelNotation(invertSign: FlipZ);
                            formsPlot.Plot.XAxis.TickLabelFormat(CustomTickFormatter);
                            formsPlot.Plot.YAxis.TickLabelFormat(CustomTickFormatter);
                        }

                        if (ShowBestFit)
                        {
                            double[] poly = Zed.scatterPolynomial(plotData.X, plotData.Y);
                            double[] polyData = plotData.X.Select(x => poly[0] + poly[1] * x + poly[2] * Math.Pow(x, 2) + poly[3] * Math.Pow(x, 3)).ToArray();
                            formsPlot.Plot.AddFunction(
                                new Func<double, double?>((x) => poly[0] + poly[1] * x + poly[2] * Math.Pow(x, 2) + poly[3] * Math.Pow(x, 3)),
                                Color.Black, 3, LineStyle.Dash);
                            var annotation = formsPlot.Plot.AddAnnotation($"R² = {Zed.rSquared(polyData, plotData.Y)}", 5, 5);
                            annotation.Shadow = false;
                            annotation.BackgroundColor = Color.White;
                        }
                        break;
                    default:
                        break;
                }

                if (EraseDataEnabled && !ErasePointEnabled)
                {
                    HSpan[plotIdx] = formsPlot.Plot.AddHorizontalSpan(plotData.X.Min() - 2, plotData.X.Min() - 1, Color.FromArgb(150, Color.DarkRed));
                    HSpan[plotIdx].DragEnabled = true;
                    VSpan[plotIdx] = formsPlot.Plot.AddVerticalSpan(plotData.Y.Min() - 2, plotData.Y.Min() - 1, Color.FromArgb(150, Color.DarkViolet));
                    VSpan[plotIdx].DragEnabled = true;
                }

                formsPlot.Refresh();
            }
            catch (Exception)
            {
                var msg = formsPlot.Plot.AddAnnotation("Insufficient Data", 10, 10);
                msg.Font.Size = 24;
                msg.Shadow = false;
                msg.BackgroundColor = Color.Transparent;
                msg.BorderColor = Color.Transparent;
                formsPlot.Plot.Title(
                    $"{plotData.Name}\nRange: N/A   3Sigma = N/A", false);
            }
        }

        private void UpdateToolStripRange()
        {

            toolStripLabelRangeX.Text = GroupBounds.GetRangeString(GroupBounds.Axis.X);
            toolStripLabelRangeY.Text = GroupBounds.GetRangeString(GroupBounds.Axis.Y);
            toolStripLabelRangeZ.Text = GroupBounds.GetRangeString(GroupBounds.Axis.Z);
        }

        private string CustomTickFormatter(double position)
        {
            if ((position - (int)position) > 1e-3)
                return $"{position:F3}";
            else
                return $"{(int)position}";
        }

        private string ColorbarFormatter(double position)
        {
            return $"{Math.Round(position, 4 - ((int)position).ToString().Length)}";
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
        }

        private void CheckBoxRemoveAngle_CheckedChanged(object sender, EventArgs e)
        {
            RemoveAngle = !RemoveAngle;
            MakePlots();
        }

        private void CheckBoxEqualize_CheckedChanged(object sender, EventArgs e)
        {
            Equalize = !Equalize;
            MakePlots();
        }

        private void CheckBoxEraseData_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxEraseData.Checked && EraseDataEnabled && !ErasePointEnabled) CreateCustomAxes();
            UpdateEraseDataMode(redraw: true);
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
            if (EraseDataEnabled && (comboX.SelectedIndex == (int)Zed.Axes.H || comboY.SelectedIndex == (int)Zed.Axes.H || 
                comboX.SelectedIndex == (int)Zed.Axes.ZH || comboY.SelectedIndex == (int)Zed.Axes.ZH) 
                && comboZ.SelectedIndex != (int)Zed.Axes.None) TurnOffEraseMode();
            if (EraseDataEnabled && comboY.SelectedIndex == (int)Zed.Axes.None) TurnOffEraseMode();
            ErasePointEnabled = EraseDataEnabled && (comboX.SelectedIndex == (int)Zed.Axes.X || comboX.SelectedIndex == (int)Zed.Axes.Y) && 
                comboY.SelectedIndex == (int)Zed.Axes.H && comboZ.SelectedIndex == (int)Zed.Axes.None;
            if (redraw) MakePlots();
        }

        private void TurnOffEraseMode()
        {
            EraseDataEnabled = false;
            ErasePointEnabled = false;
            checkBoxEraseData.Checked = false;
            MessageBox.Show("Erase mode unavailable with current axes selection", "XYZ Plotter");
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

        private void ButtonReloadFile_Click(object sender, EventArgs e)
        {
            Hide();
            _ = new Plotter(Path);
            Close();
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
