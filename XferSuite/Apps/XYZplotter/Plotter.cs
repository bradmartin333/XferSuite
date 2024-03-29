﻿using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XferHelper;
using static XferSuite.Apps.XYZplotter.Configuration;

namespace XferSuite.Apps.XYZplotter
{
    public partial class Plotter : Form
    {
        private int _ColorRounding = 2;
        [Category("User Parameters")]
        [Description("The higher the number, the more colors are shown in the Z axis and the longer it will take to create the plot. Default = 2, Min = 0, Max = 10")]
        public int ColorRounding
        {
            get => _ColorRounding;
            set
            {
                if (value < 0)
                    _ColorRounding = 0;
                else if (value > 10)
                    _ColorRounding = 10;
                else
                    _ColorRounding = value;
                MakePlots();
            }
        }

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
        private int[] LastHighlightedPoints { get; set; } = new int[4];
        public bool EraseDataEnabled { get; set; }
        private bool _ErasePointEnabled = false;
        private bool ErasePointEnabled
        {
            get => _ErasePointEnabled;
            set
            {
                _ErasePointEnabled = value;
                checkBoxEraseData.FlatAppearance.CheckedBackColor = _ErasePointEnabled ? Color.LightCoral : Color.Gold;
            }
        }
        private bool _MagicSelectEnabled = false;
        private bool MagicSelectEnabled
        {
            get => _MagicSelectEnabled;
            set
            {
                _MagicSelectEnabled = value;
                checkBoxEraseData.BackgroundImage = _MagicSelectEnabled ? Properties.Resources.magic_select : Properties.Resources.eraser;
                checkBoxEraseData.BackColor = _MagicSelectEnabled ? Color.LightGreen : SystemColors.Control;
            }
        }
        public bool HoverScatterEnabled
        {
            get => _ErasePointEnabled || _MagicSelectEnabled;
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
                p.Configuration.EnablePlotObjectEditor = true;
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
            bool lastEraseDataEnabled = EraseDataEnabled;
            if (e.Button == MouseButtons.Right) TurnOffEraseMode();
            if (lastEraseDataEnabled) MakePlots();
        }

        private void P_MouseUp(object sender, MouseEventArgs e)
        {
            if (!HoverScatterEnabled) return;

            FormsPlot p = (FormsPlot)sender;
            int plotIdx = int.Parse(p.Tag.ToString());
            if (ActiveScans[plotIdx] == null) return;

            try
            {
                if (ErasePointEnabled)
                {
                    ActiveScans[plotIdx].Data.RemoveAt(LastHighlightedPoints[plotIdx]);
                    ActiveScans[plotIdx].Edited = true;
                    ActiveScans[plotIdx].SelectedIdx = -1;
                    olv.Refresh();
                }
                if (MagicSelectEnabled)
                {
                    if (ActiveScans[plotIdx].SelectedIdx == LastHighlightedPoints[plotIdx])
                        ActiveScans[plotIdx].SelectedIdx = -1;
                    else
                        ActiveScans[plotIdx].SelectedIdx = LastHighlightedPoints[plotIdx];
                }
                    
                MakePlots();
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Exception in P_MouseUp");
            }
        }

        private void P_MouseMove(object sender, MouseEventArgs e)
        {
            if (!HoverScatterEnabled) return;

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
                            thisScan.Threshold = double.Parse(info[7]);
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
            UpdateEraseDataMode();
            MakePlots();
        }

        private void toolStripButtonViewSpecial_Click(object sender, EventArgs e)
        {
            comboX.SelectedIndex = (int)Zed.Axes.X;
            comboY.SelectedIndex = (int)Zed.Axes.H;
            comboZ.SelectedIndex = (int)Zed.Axes.None;
        }

        private void toolStripButtonViewStandard_Click(object sender, EventArgs e)
        {
            comboX.SelectedIndex = (int)Zed.Axes.X;
            comboY.SelectedIndex = (int)Zed.Axes.Y;
            comboZ.SelectedIndex = (int)Zed.Axes.H;
        }

        private void MakePlots()
        {
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
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Exception in MakePlots: {ex}");
                }

                for (int i = 0; i < numPlots; i++) Plots[i].Visible = true;
                for (int i = numPlots; i < Plots.Length; i++) Plots[i].Visible = false;
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
            formsPlot.Name = ((Scan)olv.SelectedObjects[plotIdx]).Name;

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

                        if (HoverScatterEnabled)
                        {
                            HighlightPointPlots[plotIdx] = formsPlot.Plot.AddPoint(0, 0);
                            HighlightPointPlots[plotIdx].Color = ErasePointEnabled ? Color.Red : Color.LawnGreen;
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

                        if (plotData.SelectedPoint != null) 
                            formsPlot.Plot.AddPoint(plotData.SelectedPoint.X, plotData.SelectedPoint.Y, Color.Black, 20, MarkerShape.asterisk);

                        break;
                    case 3:
                        // Create point lists grouped by color
                        // This is a lot faster than adding points individually
                        List<double> fractions = new List<double>();
                        List<Color> colors = new List<Color>();
                        List<List<PlotPoint>> points = new List<List<PlotPoint>>();
                        for (int i = 0; i < plotData.Z.Length; i++)
                        {
                            double colorFraction = Math.Round((plotData.Z[i] - GroupBounds.ZMin) / (GroupBounds.ZMax - GroupBounds.ZMin), _ColorRounding);
                            int fractionIdx = fractions.IndexOf(colorFraction);
                            if (fractionIdx != -1)
                                points[fractionIdx].Add(new PlotPoint { X = plotData.X[i], Y = plotData.Y[i], C = colors[fractionIdx] });
                            else
                            {
                                fractions.Add(colorFraction);
                                colors.Add(ScottPlot.Drawing.Colormap.Viridis.GetColor(colorFraction));
                                points.Add(new List<PlotPoint>() { new PlotPoint { X = plotData.X[i], Y = plotData.Y[i], C = colors.Last() } });
                            }
                        }

                        // Add lists as individual scatterplots
                        foreach (List<PlotPoint> pointList in points)
                            formsPlot.Plot.AddScatter(pointList.Select(p => p.X).ToArray(), pointList.Select(p => p.Y).ToArray(), pointList[0].C, lineStyle: LineStyle.None);

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

                        if (plotData.SelectedPoint != null)
                            formsPlot.Plot.AddPoint(plotData.SelectedPoint.X, plotData.SelectedPoint.Y, Color.Black, 20, MarkerShape.asterisk);

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

                formsPlot.Refresh();
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
            return $"{Math.Round(position, 5 - ((int)position).ToString().Length)}";
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
            if (OverrideCheckbox) return;
            if (!checkBoxEraseData.Checked && EraseDataEnabled && !ErasePointEnabled) CreateCustomAxes();
            UpdateEraseDataMode();
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
                        Zed.getAxisSingle(s, comboX.SelectedIndex, FlipX) >= HSpanVals.Item1 && 
                        Zed.getAxisSingle(s, comboX.SelectedIndex, FlipX) <= HSpanVals.Item2 && 
                        Zed.getAxisSingle(s, comboY.SelectedIndex, FlipY) >= VSpanVals.Item1 && 
                        Zed.getAxisSingle(s, comboY.SelectedIndex, FlipY) <= VSpanVals.Item2);
                    ActiveScans[i].Edited = ActiveScans[i].Edited || originalNumPoints > ActiveScans[i].Data.Count;
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine("Exception in CreateCustomAxes");
                }
            }
            MakePlots();
        }

        private void UpdateEraseDataMode()
        {
            bool lastEraseDataEnabled = EraseDataEnabled;
            bool lastMagicSelectEnabled = MagicSelectEnabled;
            EraseDataEnabled = checkBoxEraseData.Checked;

            bool allowEraseData = true;
            if (((comboX.SelectedIndex == (int)Zed.Axes.H || comboY.SelectedIndex == (int)Zed.Axes.H ||
                comboX.SelectedIndex == (int)Zed.Axes.ZH || comboY.SelectedIndex == (int)Zed.Axes.ZH)
                && comboZ.SelectedIndex != (int)Zed.Axes.None) || comboY.SelectedIndex == (int)Zed.Axes.None)
            {
                TurnOffEraseMode();
                allowEraseData = false;
            }

            bool erasePointPermitted = allowEraseData && (comboX.SelectedIndex == (int)Zed.Axes.X || comboX.SelectedIndex == (int)Zed.Axes.Y) &&
                comboY.SelectedIndex == (int)Zed.Axes.H && comboZ.SelectedIndex == (int)Zed.Axes.None;
            ErasePointEnabled = EraseDataEnabled && erasePointPermitted;
            checkBoxEraseData.Visible = allowEraseData;
            MagicSelectEnabled = erasePointPermitted && !ErasePointEnabled && allowEraseData;

            if (lastEraseDataEnabled != EraseDataEnabled || lastMagicSelectEnabled != MagicSelectEnabled) MakePlots();
        }

        private void TurnOffEraseMode()
        {
            OverrideCheckbox = true;
            EraseDataEnabled = false;
            ErasePointEnabled = false;
            checkBoxEraseData.Checked = false;
            checkBoxEraseData.Visible = false;
            OverrideCheckbox = false;
        }

        private void ButtonAutoscale_Click(object sender, EventArgs e)
        {
            foreach (FormsPlot plot in Plots)
            {
                plot.Plot.AxisAuto();
                plot.Refresh();
            }
        }

        private void BtnRevert_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < olv.SelectedObjects.Count; i++) ((Scan)olv.SelectedObjects[i]).RevertData();
            MakePlots();
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
            bool singlePlot = olv.SelectedObjects.Count == 1;
            bool saveImage = ModifierKeys == Keys.Shift;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Export Selected Scans";
                saveFileDialog.DefaultExt = ".txt";
                saveFileDialog.Filter = "Text file (*.txt)|*.txt";

                if (singlePlot) saveFileDialog.FileName = ((Scan)olv.SelectedObjects[0]).Name.ToString();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                        for (int i = olv.SelectedObjects.Count - 1; i >= 0; i--)
                            sw.Write(((Scan)olv.SelectedObjects[i]).ToString());
                    if (singlePlot && saveImage)
                    {
                        Bitmap bmp = Plots[0].Plot.GetBitmap();
                        Bitmap bg = new Bitmap(bmp.Width, bmp.Height);
                        using (Graphics g = Graphics.FromImage(bg))
                        {
                            g.Clear(SystemColors.Control);
                            g.DrawImage(bmp, 0, 0);
                        }
                        bg.Save(saveFileDialog.FileName.Replace(".txt", ".png"));
                    }
                } 
            }
        }
    }
}
