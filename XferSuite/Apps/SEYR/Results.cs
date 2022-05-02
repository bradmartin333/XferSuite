using System.Drawing;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class Results : Form
    {
        public Results(double[] vs1, double[] vs2, double[] vs3, double[] vs4)
        {
            InitializeComponent();
            formsPlot1.Plot.Style(dataBackground: Color.Black);
            formsPlot1.Plot.Grid(false);
            formsPlot1.Plot.AddScatter(vs1, vs2, Color.LawnGreen, markerShape: ScottPlot.MarkerShape.filledSquare, lineStyle: ScottPlot.LineStyle.None, markerSize: 5);
            formsPlot1.Plot.AddScatter(vs3, vs4, Color.Firebrick, markerShape: ScottPlot.MarkerShape.filledSquare, lineStyle: ScottPlot.LineStyle.None, markerSize: 5);
            formsPlot1.Refresh();
            Show();
        }
    }
}
