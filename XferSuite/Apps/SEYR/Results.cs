using ScottPlot.Plottable;
using System.Drawing;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class Results : Form
    {
        private bool ShowPassFail = false;
        private readonly ScatterCriteria[] Scatters;

        public Results(ScatterCriteria[] scatters)
        {
            InitializeComponent();
            Scatters = scatters;
            FormsPlot.Plot.Palette = ScottPlot.Palette.ColorblindFriendly;
            FormsPlot.Plot.Legend();
            MakePlot();
            Show();
        }

        private void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            ShowPassFail = checkBox1.Checked;
            MakePlot();
        }

        private void MakePlot()
        {
            FormsPlot.Plot.Clear();
            foreach (ScatterCriteria scatter in Scatters)
            {
                if (scatter.X.Count == 0) continue;
                ScatterPlot plot = FormsPlot.Plot.AddScatter(
                    scatter.X.ToArray(),
                    scatter.Y.ToArray(),
                    markerShape: ScottPlot.MarkerShape.filledSquare,
                    lineStyle: ScottPlot.LineStyle.None,
                    label: scatter.Name);
                if (scatter.Color != Color.Transparent)
                    plot.Color = scatter.Color;
                else if (ShowPassFail)
                    plot.Color = scatter.Pass ? Color.LawnGreen : Color.Firebrick;
            }
            FormsPlot.Refresh();
        }
    }
}
