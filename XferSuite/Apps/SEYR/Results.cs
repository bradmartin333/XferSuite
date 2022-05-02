using ScottPlot.Plottable;
using System.Drawing;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class Results : Form
    {
        public Results(ScatterCriteria[] scatters)
        {
            InitializeComponent();
            foreach (ScatterCriteria scatter in scatters)
            {
                if (scatter.X.Count == 0) continue;
                ScatterPlot plot = FormsPlot.Plot.AddScatter(
                    scatter.X.ToArray(), 
                    scatter.Y.ToArray(), 
                    markerShape: ScottPlot.MarkerShape.filledSquare, 
                    lineStyle: ScottPlot.LineStyle.None, 
                    label: scatter.Name);
                if (scatter.Color != Color.Transparent) plot.Color = scatter.Color;
            }
            FormsPlot.Plot.Legend();
            FormsPlot.Refresh();
            Show();
        }
    }
}
