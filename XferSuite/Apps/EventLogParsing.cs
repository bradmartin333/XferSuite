using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.IO;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class EventLogParsing : Form
    {
        public EventLogParsing(string Path)
        {
            InitializeComponent();

            _lines = File.ReadAllLines(Path);
            _events = Parser.reader(_lines);

            GetRecipes();
        }

        private string[] _lines;
        private Parser.Event[] _events;

        private void GetRecipes()
        {
            string[] recipes = Parser.getRecipes(_events);
            foreach (string r in recipes)
            {
                FileInfo recipe = new FileInfo(r);
                RecipeList.Items.Add(recipe.Name.Replace(recipe.Extension, ""));
            }
        }

        private void RecipeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakePrintTimePlot(RecipeList.SelectedItem.ToString());
        }

        private void MakePrintTimePlot(string recipe)
        {
            PlotModel print = new PlotModel() { TitleFontSize = 15 };
            print.MouseDown += (s, e) =>
            {
                if (e.IsShiftDown)
                {
                    SavePlot();
                }
            };

            double[] times = Parser.getPrints(recipe, _events);

            StairStepSeries timeSeries = new StairStepSeries();
            for (int i = 0; i < times.Length; i++)
            {
                timeSeries.Points.Add(new DataPoint(i, times[i]));
            }

            LinearAxis myXaxis = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "Print #"
            };
            LinearAxis myYaxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "Duration (s)"
            };

            print.Axes.Add(myXaxis);
            print.Axes.Add(myYaxis);
            print.Series.Add(timeSeries);
            print.Title = string.Format("Median: {0} s   3Sigma: {1}", Stats.median(times), Stats.threeSig(times));
            plot.Model = print;
        }

        private void SavePlot()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Export Print Time Plot";
                saveFileDialog.DefaultExt = ".png";
                saveFileDialog.Filter = "png file (*.png)|*.png";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var pngExporter = new PngExporter { Width = plot.Width, Height = plot.Width, Background = OxyColors.White };
                    pngExporter.ExportToFile(plot.Model, saveFileDialog.FileName);
                }
            }
        }
    }
}
