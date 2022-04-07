using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using static XferSuite.Apps.SEYR.ParseSEYR;
using ScottPlot;
using System;

namespace XferSuite.Apps.SEYR
{
    public partial class Results : Form
    {
        private bool ShowGrid = true;
        private bool FlipX;
        private bool FlipY;
        private int PassPointSize;
        private int FailPointSize;
        private List<Plottable> Plottables;
        private List<PlotOrderElement> PlotOrder;
        List<CustomFeature> CustomFeatures;

        public Results(string title)
        {
            InitializeComponent();
            Text = title;
            formsPlot.Configuration.DoubleClickBenchmark = false;
            formsPlot.Plot.Style(figureBackground: System.Drawing.Color.White);
            formsPlot.RightClicked -= formsPlot.DefaultRightClickEvent;
            formsPlot.RightClicked += CustomRightClickEvent;
        }

        private void CustomRightClickEvent(object sender, EventArgs e)
        {
            ContextMenuStrip customMenu = new ContextMenuStrip();
            customMenu.Items.Add(new ToolStripMenuItem("Copy Plot", null, new EventHandler(CopyImage)));
            customMenu.Items.Add(new ToolStripMenuItem("Save Plot", null, new EventHandler(SaveImage)));
            customMenu.Items.Add(new ToolStripMenuItem("Reset Axes", null, new EventHandler(ResetAxes)));
            customMenu.Items.Add(new ToolStripMenuItem("Select Plot Background Color", null, new EventHandler(SelectPlotColor)));
            customMenu.Items.Add(new ToolStripMenuItem("Toggle Grid", null, new EventHandler(ToggleGrid)));
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
            LabelStatus.Text = "Grid changed";
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
            Plottables = parseSEYR.Plottables;
            PlotOrder = parseSEYR.PlotOrder;
            CustomFeatures = parseSEYR.CustomFeatures;
            UpdatePlot(reason);
        }

        private void UpdatePlot(string reason)
        {
            if (Plottables.Count == 0) return;
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
                formsPlot.Plot.AddScatter(
                    plottables.Select(x => x.X * (FlipX ? -1 : 1)).ToArray(),
                    plottables.Select(x => x.Y * (FlipY ? 1 : -1)).ToArray(),
                    plottables[0].Color,
                    markerSize: thisSize,
                    lineStyle: LineStyle.None);
            }
            formsPlot.Plot.XAxis.TickLabelNotation(invertSign: FlipX);
            formsPlot.Plot.YAxis.TickLabelNotation(invertSign: FlipY);
            formsPlot.Refresh();
            LabelStatus.Text = $"Replot: {reason}";
        }
    }
}
