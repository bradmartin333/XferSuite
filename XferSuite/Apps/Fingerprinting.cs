using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class Fingerprinting : Form
    {
        private float _VectorMagnitude = 200F;
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

        private bool _ShowEntropy = false;
        [
            Category("User Parameters"),
            Description("Colorize prints based of their statistical entropy relative to each other")
        ]
        public bool ShowEntropy
        {
            get => _ShowEntropy;
            set
            {
                _ShowEntropy = value;
                MakePlot();
            }
        }

        private double _EntropyLowerBound = 0.0;
        [
            Category("User Parameters"),
        ]
        public double EntropyLowerBound
        {
            get => _EntropyLowerBound;
            set
            {
                _EntropyLowerBound = value;
                MakePlot();
            }
        }

        private double _EntropyUpperBound = 1.0;
        [
            Category("User Parameters"),
        ]
        public double EntropyUpperBound
        {
            get => _EntropyUpperBound;
            set
            {
                _EntropyUpperBound = value;
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
                    PrintList.Items.Add(string.Format("{0}: {1}", printIdx, index));
                    printIdx += 1;
                }
                _raw[posIdx].PrintNum = printIdx;
                posIdx += 1;
            }

            MakePlot();
        }

        private Metro.Position[] _raw; // Gets split into data and missing
        private Metro.Position[] _data; // Gets split into pass and fail
        private bool _PlotAll = true; // On by default
        List<string> _prints = new List<string>();

        private void PrintList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _PlotAll = false;
            MakePlot();
        }

        private void PrintList_DoubleClick(object sender, EventArgs e)
        {
            _PlotAll = true;
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

            // Hacky, but fast way of selecting all by default
            List<int> loopSet = new List<int>();
            if (_PlotAll)
            {
                for (int idx = 0; idx < PrintList.Items.Count; idx++)
                {
                    loopSet.Add(idx);
                }
            }
            else
            {
                foreach (int idx in PrintList.SelectedIndices)
                {
                    loopSet.Add(idx);
                }
            }

            if (!_ShowEntropy)
            {
                foreach (int idx in loopSet)
                {
                    Metro.Position[] printData = Metro.getPrint(_prints[idx], plotData);
                    double[] normError = Metro.NormErrorRange(printData);
                    for (int i = 0; i < printData.Length; i++)
                    {
                        vectorPlot.Series.Add(PlotVector(printData[i], normError, normError[i], idx));
                    }
                }
            }
            else
            {
                Metro.Position[][] printData = new Metro.Position[_prints.Count()][];
                double[] printEntropy = new double[_prints.Count()];
                foreach (int idx in loopSet)
                {
                    printData[idx] = Metro.getPrint(_prints[idx], plotData);
                    printEntropy[idx] = Metro.NextMagnitudeEntropy(printData[idx]) / 1e10;
                }
                foreach (int idx in loopSet)
                {
                    for (int i = 0; i < printData[idx].Length; i++)
                    {
                        vectorPlot.Series.Add(PlotVector(printData[idx][i], 
                            new double[] { _EntropyLowerBound, _EntropyUpperBound }, printEntropy[idx], idx));
                    }
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

        private LineSeries PlotVector(Metro.Position vector, double[] colorRangeVals, double colorVal, int idx)
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

            Color color = Lux2Color((colorVal - colorRangeVals.Max()) / (colorRangeVals.Max() - colorRangeVals.Min()));
            LineSeries post = new LineSeries() { Color = OxyColor.FromRgb(color.R, color.G, color.B), LineStyle = LineStyle.Solid, StrokeThickness = 0.5 };
            post.TrackerFormatString = post.TrackerFormatString + Environment.NewLine + 
                PrintList.Items[idx].ToString() + Environment.NewLine + 
                "Color Value: " + Math.Round(colorVal, 6).ToString();
            post.Points.Add(fromP);
            post.Points.Add(toP);
            post.Points.Add(arrowheadA);
            post.Points.Add(toP);
            post.Points.Add(arrowheadB);

            return post;
        }

        public static Color Lux2Color(double lux)
        {
            lux = Math.Abs(lux);
            double r = 0.5;
            double g = 0.5;
            double b = 0.5;
            double v = 0.75;
            double m = 1 - v;
            double sv = (v - m) / v;
            lux *= 4.0;
            int sextant = (int)lux;
            double fract = lux - sextant;
            double vsf = v * sv * fract;
            double mid1 = m + vsf;
            double mid2 = v - vsf;
            switch (sextant)
            {
                case 0:
                    r = v;
                    g = mid1;
                    b = m;
                    break;
                case 1:
                    r = mid2;
                    g = v;
                    b = m;
                    break;
                case 2:
                    r = m;
                    g = v;
                    b = mid1;
                    break;
                case 3:
                    r = m;
                    g = mid2;
                    b = v;
                    break;
                case 4:
                    r = mid1;
                    g = m;
                    b = v;
                    break;
                //case 5:
                //    r = v;
                //    g = m;
                //    b = mid2;
                //    break;
            }
            return Color.FromArgb(255, Convert.ToByte(r * 255.0f), Convert.ToByte(g * 255.0f), Convert.ToByte(b * 255.0f));
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
