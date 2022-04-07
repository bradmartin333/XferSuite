using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using static XferSuite.Apps.SEYR.ParseSEYR;
using ScottPlot;
using System;
using ScottPlot.Plottable;
using System.Drawing;

namespace XferSuite.Apps.SEYR
{
    public partial class Results : Form
    {
        private readonly List<ScatterPlot> Scatters = new List<ScatterPlot>();
        private MarkerPlot HighlightedPoint;
        private (int, int) LastHighlightedIndex = (-1, -1);
        private bool ShowGrid = true;
        private bool ShowTrackerString = false;
        private bool FlipX;
        private bool FlipY;
        private int PassPointSize;
        private int FailPointSize;
        private List<Plottable> Plottables;
        private List<PlotOrderElement> PlotOrder;
        private List<CustomFeature> CustomFeatures;

        public Results(string title)
        {
            InitializeComponent();
            Text = title;
            formsPlot.Configuration.DoubleClickBenchmark = false;
            formsPlot.Plot.Style(figureBackground: Color.White);
            formsPlot.RightClicked -= formsPlot.DefaultRightClickEvent;
            formsPlot.RightClicked += CustomRightClickEvent;
            formsPlot.MouseMove += FormsPlot_MouseMove;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void CustomRightClickEvent(object sender, EventArgs e)
        {
            ContextMenuStrip customMenu = new ContextMenuStrip();
            customMenu.Items.Add(new ToolStripMenuItem("Copy Plot", null, new EventHandler(CopyImage)));
            customMenu.Items.Add(new ToolStripMenuItem("Save Plot", null, new EventHandler(SaveImage)));
            customMenu.Items.Add(new ToolStripMenuItem("Reset Axes", null, new EventHandler(ResetAxes)));
            customMenu.Items.Add(new ToolStripMenuItem("Select Plot Background Color", null, new EventHandler(SelectPlotColor)));
            customMenu.Items.Add(new ToolStripMenuItem("Toggle Grid", null, new EventHandler(ToggleGrid)));
            customMenu.Items.Add(new ToolStripMenuItem("Toggle Tracker String", null, new EventHandler(ToggleTrackerString)));
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

        private void ResetAxes(object sender, EventArgs e)
        {
            formsPlot.Plot.AxisAuto();
            formsPlot.Refresh();
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
                formsPlot.Refresh();
            }
            LabelStatus.Text = "Plot color changed";
        }

        private void ToggleGrid(object sender, EventArgs e)
        {
            ShowGrid = !ShowGrid;
            formsPlot.Plot.Grid(ShowGrid);
            formsPlot.Refresh();
            LabelStatus.Text = "Grid visibility changed";
        }

        private void ToggleTrackerString(object sender, EventArgs e)
        {
            ShowTrackerString = !ShowTrackerString;
            UpdatePlot("Tracker string visibility changed");
        }

        private void FormsPlot_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (!ShowTrackerString || HighlightedPoint == null || Plottables.Count == 0) return;

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

                // Render if the highlighted point chnaged
                if (LastHighlightedIndex != (closestIdx, coords[closestIdx].Item3))
                    LastHighlightedIndex = (closestIdx, coords[closestIdx].Item3);

                // Update the GUI to describe the highlighted point
                Plottable[] plottables = Plottables.Where(
                    p => p.X * (FlipX ? -1 : 1) == coords[closestIdx].Item1 &&
                    p.Y * (FlipY ? 1 : -1) == coords[closestIdx].Item2).ToArray();
                
                if (plottables.Count() != 0)
                {
                    formsPlot.Plot.Title(plottables[0].ToString(), size: 10);
                    formsPlot.Refresh();
                }
            }
            catch (Exception) { }
        }

        public void UpdateData(string reason, ParseSEYR parseSEYR)
        {
            FlipX = parseSEYR.FlipXAxis;
            FlipY = parseSEYR.FlipYAxis;
            PassPointSize = parseSEYR.PassPointSize;
            FailPointSize = parseSEYR.FailPointSize;
            Plottables = parseSEYR.Plottables;
            PlotOrder = parseSEYR.PlotOrder;
            CustomFeatures = parseSEYR.CustomFeatures;
            UpdatePlot(reason);
        }

        private void UpdatePlot(string reason)
        {
            if (Plottables.Count == 0) return;
            Scatters.Clear();
            formsPlot.Plot.Clear();
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
            formsPlot.Plot.XAxis.TickLabelNotation(invertSign: FlipX);
            formsPlot.Plot.YAxis.TickLabelNotation(invertSign: FlipY);

            if (ShowTrackerString) // Add a red circle we can move around later as a highlighted point indicator
            {
                HighlightedPoint = formsPlot.Plot.AddPoint(0, 0);
                HighlightedPoint.Color = Color.Red;
                HighlightedPoint.MarkerSize = 10;
                HighlightedPoint.MarkerShape = MarkerShape.openCircle;
                HighlightedPoint.IsVisible = false;
            }
            else
                formsPlot.Plot.Title("");

            formsPlot.Refresh();
            LabelStatus.Text = reason;
        }
    }
}
