using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class EventLogParsing : Form
    {
        private double _MaxTime = 60.0;
        [
            Category("User Parameters"),
            Description("Filter out any print durations longer than this value in seconds")
        ]
        public double MaxTime
        {
            get => _MaxTime;
            set
            {
                _MaxTime = value;
                if (RecipeList.SelectedIndices.Count > 0)
                {
                    MakePrintTimePlot(RecipeList.SelectedItem.ToString());
                }
            }
        }

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
            RecipeList.SelectedIndex = 0;
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

            double[] timesRaw = Parser.getPrints(recipe, _events);
            double[] times = Parser.filterPrints(timesRaw, _MaxTime);

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
            print.Title = string.Format("Median: {0} s   Mean: {1} s", Stats.median(times), Stats.mean(times));
            print.Subtitle = string.Format("Max Filter = {0} s", _MaxTime.ToString());
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
