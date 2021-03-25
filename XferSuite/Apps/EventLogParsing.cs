using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
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
            }
        }

        public EventLogParsing(string Path)
        {
            InitializeComponent();

            _lines = File.ReadAllLines(Path);
            _events = Parser.reader(_lines);
            fastObjectListView.SetObjects(_events);
            fastObjectListView.SelectionChanged += FastObjectListView_SelectionChanged;

            lblFilterPercent.Text = (1.0 - (_events.Length / (double) _lines.Length)).ToString("p") + " Lines Filtered Out";
        }

        private string[] _lines;
        private Parser.Event[] _events;

        private void SavePlot()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Export Event Time Plot";
                saveFileDialog.DefaultExt = ".png";
                saveFileDialog.Filter = "png file (*.png)|*.png";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var pngExporter = new PngExporter { Width = plot.Width, Height = plot.Width, Background = OxyColors.White };
                    pngExporter.ExportToFile(plot.Model, saveFileDialog.FileName);
                }
            }
        }

        private void FastObjectListView_SelectionChanged(object sender, EventArgs e)
        {
            PlotModel plotModel = new PlotModel() { TitleFontSize = 15 };
            plotModel.MouseUp += (s, ev) =>
            {
                if (ev.IsShiftDown)
                {
                    SavePlot();
                }
            };

            plotModel.Axes.Add(new TimeSpanAxis { Position = AxisPosition.Left, Title = "TimeSpan" });
            StairStepSeries stairStepSeries = new StairStepSeries();
            List<double> timeSpans = new List<double>();
            var events = fastObjectListView.SelectedObjects;
            for (int i = 1; i < events.Count; i++)
            {
                Parser.Event eventA = (Parser.Event)events[i];
                Parser.Event eventB = (Parser.Event)events[i-1];
                TimeSpan duration = new TimeSpan(eventA.Stamp - eventB.Stamp);
                if (duration.Ticks == 0)
                {
                    continue;
                }
                timeSpans.Add(Axis.ToDouble(duration));
                stairStepSeries.Points.Add(new DataPoint(eventA.IDX, Axis.ToDouble(duration)));
            }
            plotModel.Series.Add(stairStepSeries);
            plotModel.Title = string.Format("Mean: {0} s  Range: {1} s", Stats.mean(timeSpans.ToArray()), Stats.range(timeSpans.ToArray()));
            plot.Model = plotModel;
        }
    }
}
