using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class Fingerprinting : Form
    {
        private float _VectorMagnitude = 150F;
        [
            Category("User Parameters"),
            Description("Value to multiply position error by")
        ]
        public float VectorMagnitude
        {
            get => _VectorMagnitude;
            set
            {
                _VectorMagnitude = value;
                MakePlot();
            }
        }

        private float _Threshold = 1.5F;
        [
            Category("User Parameters"),
            Description("Positions with placement error greater than this micron value will be filtered out of the plotted data")
        ]
        public float Threshold
        {
            get => _Threshold;
            set
            {
                _Threshold = value;
                MakePlot();
            }
        }

        public Fingerprinting(Metro.Position[] data)
        {
            InitializeComponent();
            _raw = data;
            Tuple<Metro.Position[], Metro.Position[]> _splitData = Metro.missingData(_raw);
            _data = _splitData.Item2;

            string[] indices = Metro.prints(_raw);
            int printIdx = 1;
            int posIdx = 0;
            foreach (string index in indices)
            {
                if (!_prints.Contains(index))
                {
                    _prints.Add(index);
                    PrintList.Items.Add(index);
                    printIdx += 1;
                }
                _raw[posIdx].PrintNum = printIdx;
                posIdx += 1;
            }
        }

        private Metro.Position[] _raw; // gets split into data and missing
        private Metro.Position[] _data; // gets split into pass and fail
        List<string> _prints = new List<string>();

        private void PrintList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakePlot();
        }

        private void MakePlot()
        {
            Metro.Rescore(_data, Threshold);
            Tuple<Metro.Position[], Metro.Position[]> _scoredData = Metro.failData(_data);
            Metro.Position[] plotData = _scoredData.Item2; // Passing positions

            PlotModel vectorPlot = new PlotModel() { TitleFontSize = 15 };
            vectorPlot.MouseDown += (s, e) =>
            {
                if (e.IsShiftDown)
                {
                    SavePlot();
                }
            };

            foreach (int idx in PrintList.SelectedIndices)
            {
                Metro.Position[] printData = Metro.getPrint(_prints[idx], plotData);
                for (int i = 0; i < printData.Length; i++)
                {
                    vectorPlot.Series.Add(PlotVector(printData[i]));
                }
            }

            LinearAxis myXaxis = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                IsAxisVisible = true,
                StartPosition = 1,
                EndPosition = 0,
                IsZoomEnabled = true,
                IsPanEnabled = true,
                Title = "X Position (mm)"
            };

            LinearAxis myYaxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                IsAxisVisible = true,
                StartPosition = 1,
                EndPosition = 0,
                IsZoomEnabled = true,
                IsPanEnabled = true,
                Title = "Y Position (mm)"
            };

            vectorPlot.Axes.Add(myXaxis);
            vectorPlot.Axes.Add(myYaxis);
            plot.Model = vectorPlot;
        }

        private LineSeries PlotVector(Metro.Position vector)
        {
            var fromP = new DataPoint(vector.X, vector.Y);
            var toP = new DataPoint(vector.X + vector.XE, vector.Y + vector.YE);

            var dx = fromP.X - toP.X;
            var dy = fromP.Y - toP.Y;

            var norm = Math.Sqrt(dx * dx + dy * dy);

            var udx = dx / norm;
            var udy = dy / norm;

            var ax = udx * Math.Sqrt(3) / 2 - udy * 1 / 2;
            var ay = udx * 1 / 2 + udy * Math.Sqrt(3) / 2;
            var bx = udx * Math.Sqrt(3) / 2 + udy * 1 / 2;
            var by = -udx * 1 / 2 + udy * Math.Sqrt(3) / 2;

            DataPoint arrowheadA = new DataPoint(toP.X + Math.Abs(toP.X - fromP.X) * ax * VectorMagnitude, toP.Y + Math.Abs(toP.Y - fromP.Y) * ay * VectorMagnitude);
            DataPoint arrowheadB = new DataPoint(toP.X + Math.Abs(toP.X - fromP.X) * bx * VectorMagnitude, toP.Y + Math.Abs(toP.Y - fromP.Y) * by * VectorMagnitude);

            LineSeries post = new LineSeries() { Color = OxyColors.Black, LineStyle = LineStyle.Solid, StrokeThickness = 0.5 };
            post.Points.Add(fromP);
            post.Points.Add(toP);
            post.Points.Add(arrowheadA);
            post.Points.Add(toP);
            post.Points.Add(arrowheadB);

            return post;
        }

        private void SavePlot()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Export Fingerprint Plot";
                saveFileDialog.DefaultExt = ".png";
                saveFileDialog.Filter = "png file (*.png)|*.png";
                saveFileDialog.FileName = Text.Replace(".txt", "Fingerprint");
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var pngExporter = new PngExporter { Width = plot.Width, Height = plot.Width, Background = OxyColors.White };
                    pngExporter.ExportToFile(plot.Model, saveFileDialog.FileName);
                }
            }
        }
    }
}
