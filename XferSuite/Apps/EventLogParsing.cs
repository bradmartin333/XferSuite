using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using XferHelper;
using BrightIdeasSoftware;

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
            eventColumn.ImageGetter = new ImageGetterDelegate(EventImageGetter);
        }

        private string[] _lines;
        private Parser.Event[] _events;

        public object EventImageGetter(object rowObject)
        {
            Parser.Event e = (Parser.Event) rowObject;
            if (e.Msg.Contains("ERROR:") && !e.Msg.Contains("No Error"))
                return Properties.Resources.iconmonstr_error_3_16;
            else if (e.Msg.Contains("XferPrint Operational"))
                return Properties.Resources.iconmonstr_check_mark_1_16;
            else
                return null;
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

        private void fastObjectListView_SelectedChanged(object sender, EventArgs ev)
        {
            PlotModel plotModel = new PlotModel();
            plotModel.MouseUp += (s, e) =>
            {
                if (e.IsShiftDown)
                {
                    SavePlot();
                }
            };

            plotModel.Axes.Add(new TimeSpanAxis { Position = AxisPosition.Left, Title = "TimeSpan" });
            StairStepSeries stairStepSeries = new StairStepSeries();
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
                stairStepSeries.Points.Add(new DataPoint(i, Axis.ToDouble(duration)));
            }
            plotModel.Series.Add(stairStepSeries);
            plot.Model = plotModel;
        }
    }
}
