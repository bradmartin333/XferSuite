using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using static XferSuite.Apps.SEYR.ParseSEYR;
using ScottPlot;
using System;
using ScottPlot.Plottable;
using System.Drawing;
using System.Text;

namespace XferSuite.Apps.SEYR
{
    public partial class Results : Form
    {
        private PointF FormScaling;
        private readonly List<ScatterPlot> Scatters = new List<ScatterPlot>();
        private MarkerPlot HighlightedPoint;

        private bool ShowGrid = true;
        private bool ShowTrackerString = false;
        private bool UseLowQuality = true;
        private bool ShowRegionBorders = true;
        private bool ShowPercentages = false;

        private bool FlipX;
        private bool FlipY;
        private int PassPointSize;
        private int FailPointSize;
        private int RegionTextSize;
        private int PercentageTextSize;

        private string[] Regions;
        private List<Plottable> Plottables;
        private List<PlotOrderElement> PlotOrder;
        private List<CustomFeature> CustomFeatures;

        public Results(string title)
        {
            InitializeComponent();
            Text = title;
            Resize += Results_Resize;

            formsPlot.Configuration.DoubleClickBenchmark = false;
            formsPlot.Plot.Style(figureBackground: Color.White);
            formsPlot.KeyUp += FormsPlot_KeyUp;
            formsPlot.MouseUp += FormsPlot_MouseUp;
            formsPlot.Plot.Frameless();

            RTB.Click += RTB_Click;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void UpdateData(string reason, ParseSEYR parseSEYR)
        {
            FlipX = parseSEYR.FlipXAxis;
            FlipY = parseSEYR.FlipYAxis;
            PassPointSize = parseSEYR.PassPointSize;
            FailPointSize = parseSEYR.FailPointSize;
            RegionTextSize = parseSEYR.RegionTextSize;
            PercentageTextSize = parseSEYR.PercentageTextSize;
            Regions = parseSEYR.Regions;
            Plottables = parseSEYR.Plottables;
            PlotOrder = parseSEYR.PlotOrder;
            CustomFeatures = parseSEYR.CustomFeatures;
            UpdatePlot(reason);
        }

        private void UpdatePlot(string reason)
        {
            using (new Utility.HourGlass(UsePlexiglass: false))
            {
                if (Plottables.Count == 0) return;

                UpdateForm();
                Scatters.Clear();
                formsPlot.Plot.Clear();
                formsPlot.Plot.XAxis.TickLabelNotation(invertSign: FlipX);
                formsPlot.Plot.YAxis.TickLabelNotation(invertSign: FlipY);

                foreach (PlotOrderElement plotOrderElement in PlotOrder)
                {
                    Plottable[] plottables;
                    float thisSize;
                    switch (plotOrderElement.Name)
                    {
                        case "Pass":
                            thisSize = PassPointSize;
                            plottables = Plottables.Where(x => string.IsNullOrEmpty(x.CustomTag) && x.Pass).ToArray();
                            break;
                        case "Fail":
                            thisSize = FailPointSize;
                            plottables = Plottables.Where(x => string.IsNullOrEmpty(x.CustomTag) && !x.Pass).ToArray();
                            break;
                        default:
                            CustomFeature customFeature = CustomFeatures.Where(x => x.Name == plotOrderElement.Name).First();
                            thisSize = customFeature.Size;
                            plottables = Plottables.Where(x => x.CustomTag == customFeature.Name).ToArray();
                            break;
                    }
                    Scatters.Add(formsPlot.Plot.AddScatter(
                        plottables.Select(x => x.X * (FlipX ? -1 : 1)).ToArray(),
                        plottables.Select(x => x.Y * (FlipY ? 1 : -1)).ToArray(),
                        plottables[0].Color,
                        markerSize: thisSize,
                        lineStyle: LineStyle.None));
                }

                if (ShowRegionBorders || ShowPercentages)
                {
                    foreach (string region in Regions)
                    {
                        Plottable[] regionPlottables = Plottables.Where(p => p.Region == region).ToArray();
                        double[] xs = regionPlottables.Select(p => p.X).ToArray();
                        double[] ys = regionPlottables.Select(p => p.Y).ToArray();
                        double minX = xs.Min() * (FlipX ? -1 : 1);
                        double minY = ys.Min() * (FlipY ? 1 : -1);
                        double maxX = xs.Max() * (FlipX ? -1 : 1);
                        double maxY = ys.Max() * (FlipY ? 1 : -1);
                        double[] regionXs = new double[] { minX, minX, maxX, maxX, minX };
                        double[] regionYs = new double[] { minY, maxY, maxY, minY, minY };

                        if (ShowRegionBorders)
                        {
                            formsPlot.Plot.AddScatterLines(regionXs, regionYs, Color.Black, 3);
                            Text txt = formsPlot.Plot.AddText(
                                region,
                                (minX + maxX) / 2,
                                FlipY ? minY : maxY,
                                RegionTextSize,
                                color: Color.Black);
                            txt.BackgroundColor = Color.White;
                            txt.BackgroundFill = true;
                            txt.FontBold = true;
                        }

                        if (ShowPercentages)
                        {
                            Text txt = formsPlot.Plot.AddText(
                                GetRegionPercent(region), 
                                (minX + maxX) / 2, 
                                (minY + maxY) / 2, 
                                PercentageTextSize, 
                                color: Color.Black);
                            txt.BackgroundColor = Color.White;
                            txt.BackgroundFill = true;
                            txt.FontBold = true;
                        }
                    }
                }

                if (ShowTrackerString) // Add a red circle we can move around later as a highlighted point indicator
                {
                    HighlightedPoint = formsPlot.Plot.AddPoint(0, 0);
                    HighlightedPoint.Color = Color.Red;
                    HighlightedPoint.MarkerSize = 10;
                    HighlightedPoint.MarkerShape = MarkerShape.openCircle;
                    HighlightedPoint.IsVisible = false;
                }

                formsPlot.Refresh(lowQuality: UseLowQuality);
                LabelStatus.Text = reason;
            }
        }

        private string GetRegionPercent(string region)
        {
            string[] lines = RTB.Text.Split('\n');
            string dataLine = lines.Where(x => x.Contains(region)).First();
            return dataLine.Split('\t')[1];
        }

        #region Context Menu Strip

        private void FormsPlot_KeyUp(object sender, KeyEventArgs e)
        {
            CustomRightClickEvent(sender, e);
            LabelTracker.Text = "";
        }

        private void CustomRightClickEvent(object sender, EventArgs e)
        {
            ContextMenuStrip customMenu = new ContextMenuStrip();
            customMenu.Items.Add(new ToolStripMenuItem("Copy Plot", null, new EventHandler(CopyImage)));
            customMenu.Items.Add(new ToolStripMenuItem("Save Plot", null, new EventHandler(SaveImage)));
            customMenu.Items.Add(new ToolStripMenuItem("Copy Data", null, new EventHandler(CopyData)));
            customMenu.Items.Add(new ToolStripSeparator());
            customMenu.Items.Add(new ToolStripMenuItem("Reset Axes", null, new EventHandler(ResetAxes)));
            customMenu.Items.Add(new ToolStripMenuItem("Select Plot Background Color", null, new EventHandler(SelectPlotColor)));
            customMenu.Items.Add(new ToolStripSeparator());
            customMenu.Items.Add(new ToolStripMenuItem("Toggle Grid", null, new EventHandler(ToggleGrid)));
            customMenu.Items.Add(new ToolStripMenuItem("Toggle Tracker String", null, new EventHandler(ToggleTrackerString)));
            customMenu.Items.Add(new ToolStripMenuItem("Toggle Quality", null, new EventHandler(ToggleQuality)));
            customMenu.Items.Add(new ToolStripMenuItem("Toggle Region Borders", null, new EventHandler(ToggleRegionBorders)));
            customMenu.Items.Add(new ToolStripMenuItem("Toggle Percentages", null, new EventHandler(TogglePercentages)));
            customMenu.Show(System.Windows.Forms.Cursor.Position);
        }

        private void CopyImage(object sender, EventArgs e)
        {
            Clipboard.SetImage(formsPlot.Plot.Render());
            LabelStatus.Text = "Plot copied to clipboard";
        }

        private void SaveImage(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Save Plot";
                saveFileDialog.DefaultExt = ".png";
                saveFileDialog.Filter = "png file (*.png)|*.png";
                saveFileDialog.FileName = Text.Replace(".txt", "Summary");
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    formsPlot.Plot.Render().Save(saveFileDialog.FileName);
                    LabelStatus.Text = "Plot saved";
                }
            }
        }

        private void CopyData(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("X\tY\tRR\tRC\tR\tC\tState\tCustomTag\n");
            foreach (Plottable p in Plottables)
            {
                string regionCSV = p.Region.Substring(1, p.Region.Length - 2).Replace(", ", "\t");
                sb.Append($"{Math.Round(p.X, 3)}\t{Math.Round(p.Y, 3)}\t{regionCSV}\t{(p.Pass ? "Pass" : "Fail")}\t{p.CustomTag}\n");
            }
            Clipboard.SetText(sb.ToString());
            LabelStatus.Text = "Data copied to clipboard";
        }

        private void ResetAxes(object sender, EventArgs e)
        {
            formsPlot.Plot.AxisAuto();
            formsPlot.Refresh(lowQuality: UseLowQuality);
            LabelStatus.Text = "Plot axes autoscaled";
        }

        private void SelectPlotColor(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog
            {
                AllowFullOpen = true,
                ShowHelp = true,
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                formsPlot.Plot.Style(dataBackground: MyDialog.Color);
                formsPlot.Refresh(lowQuality: UseLowQuality);
            }
            LabelStatus.Text = "Plot color changed";
        }

        private void ToggleGrid(object sender, EventArgs e)
        {
            ShowGrid = !ShowGrid;
            formsPlot.Plot.Grid(ShowGrid);
            formsPlot.Refresh(lowQuality: UseLowQuality);
            LabelStatus.Text = "Grid visibility changed";
        }

        private void ToggleTrackerString(object sender, EventArgs e)
        {
            ShowTrackerString = !ShowTrackerString;
            UpdatePlot("Tracker string visibility changed");
        }

        private void ToggleQuality(object sender, EventArgs e)
        {
            UseLowQuality = !UseLowQuality;
            formsPlot.Refresh(lowQuality: UseLowQuality);
            LabelStatus.Text = "Plot quality changed";
        }

        private void ToggleRegionBorders(object sender, EventArgs e)
        {
            ShowRegionBorders = !ShowRegionBorders;
            UpdatePlot("Region borders changed");
        }

        private void TogglePercentages(object sender, EventArgs e)
        {
            ShowPercentages = !ShowPercentages;
            UpdatePlot("Percentage visibility changed");
        }

        #endregion

        #region Mouse Handlers

        private void FormsPlot_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left || !ShowTrackerString || HighlightedPoint == null || Plottables.Count == 0) return;

                // Determine point nearest the cursor
                (double mouseCoordX, double mouseCoordY) = formsPlot.GetMouseCoordinates();
                double xyRatio = formsPlot.Plot.XAxis.Dims.PxPerUnit / formsPlot.Plot.YAxis.Dims.PxPerUnit;

                List<(double, double, int)> coords = new List<(double, double, int)>();
                List<double> distances = new List<double>();
                for (int i = 0; i < Scatters.Count; i++)
                {
                    (double pointX, double pointY, int pointIndex) = Scatters[i].GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);
                    coords.Add((pointX, pointY, pointIndex));
                    distances.Add(Math.Sqrt(Math.Pow(mouseCoordX - pointX, 2) + Math.Pow(mouseCoordY - pointY, 2)));
                }

                int closestIdx = distances.IndexOf(distances.Min());

                // Place the highlight over the point of interest
                HighlightedPoint.X = coords[closestIdx].Item1;
                HighlightedPoint.Y = coords[closestIdx].Item2;
                HighlightedPoint.IsVisible = true;

                // Update the GUI to describe the highlighted point
                Plottable[] plottables = Plottables.Where(
                    p => p.X * (FlipX ? -1 : 1) == coords[closestIdx].Item1 &&
                    p.Y * (FlipY ? 1 : -1) == coords[closestIdx].Item2).ToArray();

                if (plottables.Count() != 0)
                {
                    LabelTracker.Text = plottables[0].ToString();
                    formsPlot.Refresh(lowQuality: UseLowQuality);
                }
            }
            catch (Exception) { }
        }

        private void RTB_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RTB.Text);
            LabelStatus.Text = "Results text copied to clipboard";
        }

        #endregion

        #region Form Sizing

        private void UpdateForm()
        {
            var xData = Plottables.Select(p => p.X);
            var yData = Plottables.Select(p => p.Y);
            float xRange = (float)(xData.Max() - xData.Min());
            float yRange = (float)(yData.Max() - yData.Min());
            float xScale = 1.0f;
            float yScale = 1.0f;
            if (xRange > yRange)
                yScale = yRange / xRange;
            else
                xScale = xRange / yRange;

            Rectangle plotBounds = formsPlot.Bounds;
            Size desiredPlotSize = new Size((int)(plotBounds.Width * xScale), (int)(plotBounds.Width * yScale));
            Size = new Size(desiredPlotSize.Width + 22, desiredPlotSize.Height + 235);
            FormScaling = new PointF(xScale, yScale);
        }

        private void Results_Resize(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control) || ModifierKeys.HasFlag(Keys.Alt) || ModifierKeys.HasFlag(Keys.Shift))
            {
                Rectangle plotBounds = formsPlot.Bounds;
                Size desiredPlotSize = new Size((int)(plotBounds.Width * FormScaling.X), (int)(plotBounds.Width * FormScaling.Y));
                Size = new Size(desiredPlotSize.Width + 22, desiredPlotSize.Height + 235);
            }
        }

        #endregion
    }
}
