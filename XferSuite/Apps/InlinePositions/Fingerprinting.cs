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

namespace XferSuite.Apps.InlinePositions
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

        private float _ThresholdX = 1.5F;
        [
            Category("User Parameters"),
            Description("Positions with placement error greater than this micron value in the X direction will be filtered out of the plotted data"),
            DisplayName("Threshold X")
        ]
        public float ThresholdX
        {
            get => _ThresholdX;
            set
            {
                _ThresholdX = value;
                MakePlot();
            }
        }

        private float _ThresholdY = 1.5F;
        [
            Category("User Parameters"),
            Description("Positions with placement error greater than this micron value in the Y direction will be filtered out of the plotted data"),
            DisplayName("Threshold Y")
        ]
        public float ThresholdY
        {
            get => _ThresholdY;
            set
            {
                _ThresholdY = value;
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

        private bool _RemoveMedianError = false;
        [
            Category("User Parameters"),
        ]
        public bool RemoveMedianError
        {
            get => _RemoveMedianError;
            set
            {
                _RemoveMedianError = value;
                MakePlot();
            }
        }

        public Fingerprinting(Metro.Position[] data)
        {
            InitializeComponent();
            ResizeEnd += Fingerprinting_ResizeEnd;

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

        private void Fingerprinting_ResizeEnd(object sender, EventArgs e)
        {
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
            double xErrorMedian = 0;
            double yErrorMedian = 0;
            if (RemoveMedianError)
            {
                xErrorMedian = Metro.xErrorMedian(_data);
                yErrorMedian = Metro.yErrorMedian(_data);
            }

            Metro.rescore(_data, ThresholdX, ThresholdY, xErrorMedian, yErrorMedian);
            Tuple<Metro.Position[], Metro.Position[]> _scoredData = Metro.failData(_data);
            Metro.Position[] plotData = _scoredData.Item2; // Passing positions

            PlotModel vectorPlot = new PlotModel() { TitleFontSize = 15 };

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
                    double[] normError = Metro.normErrorRange(printData, xErrorMedian, yErrorMedian);
                    for (int i = 0; i < printData.Length; i++)
                    {
                        vectorPlot.Series.Add(PlotVector(printData[i], normError, normError[i], xErrorMedian, yErrorMedian, idx));
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
                    printEntropy[idx] = Metro.nextMagnitudeEntropy(printData[idx], xErrorMedian, yErrorMedian) / 1e10;
                }
                foreach (int idx in loopSet)
                {
                    for (int i = 0; i < printData[idx].Length; i++)
                    {
                        vectorPlot.Series.Add(PlotVector(printData[idx][i], 
                            new double[] { _EntropyLowerBound, _EntropyUpperBound }, printEntropy[idx], xErrorMedian, yErrorMedian, idx));
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

            var xPositions = Metro.xPos(_data);
            var yPositions = Metro.yPos(_data);
                var xMin = xPositions.Min() - 1;
                var xMax = xPositions.Max() + 1;
                var yMin = yPositions.Min() - 1;
                var yMax = yPositions.Max() + 1;

                double plotAspectRatio = (double)plot.Width / plot.Height;
                double dataAspectRatio = (xMax - xMin) / (yMax - yMin);

                if (dataAspectRatio > plotAspectRatio)
                {
                    double adjustedHeight = (xMax - xMin) / plotAspectRatio;
                    double yMid = (yMax + yMin) / 2;
                    yMin = yMid - adjustedHeight / 2;
                    yMax = yMid + adjustedHeight / 2;
                }
                else
                {
                    double adjustedWidth = (yMax - yMin) * plotAspectRatio;
                    double xMid = (xMax + xMin) / 2;
                    xMin = xMid - adjustedWidth / 2;
                    xMax = xMid + adjustedWidth / 2;
                }

                myXaxis.Minimum = xMin;
                myXaxis.Maximum = xMax;
                myYaxis.Minimum = yMin;
                myYaxis.Maximum = yMax;

            vectorPlot.Axes.Add(myXaxis);
            vectorPlot.Axes.Add(myYaxis);
            plot.Model = vectorPlot;
        }

        private LineSeries PlotVector(Metro.Position vector, double[] colorRangeVals, double colorVal, double xErrorMedian, double yErrorMedian, int idx)
        {
            double adjusted_xe = (vector.XE - xErrorMedian) * VectorMagnitude;
            double adjusted_ye = (vector.YE - yErrorMedian) * VectorMagnitude;

            var fromP = new DataPoint(vector.X, vector.Y);
            var toP = new DataPoint(vector.X + adjusted_xe, vector.Y + adjusted_ye);

            double radius = Math.Max(Math.Abs(adjusted_xe), Math.Abs(adjusted_ye)) / 3;
            double angle = Math.Atan2(toP.Y - fromP.Y, toP.X - fromP.X);
            double arrowheadAngle = 150 * Math.PI / 180;
            DataPoint arrowheadA = new DataPoint(
                toP.X + radius * Math.Cos(angle - arrowheadAngle),
                toP.Y + radius * Math.Sin(angle - arrowheadAngle)
            );
            DataPoint arrowheadB = new DataPoint(
                toP.X + radius * Math.Cos(angle + arrowheadAngle),
                toP.Y + radius * Math.Sin(angle + arrowheadAngle)
            );

            Color color = Lux2Color((colorVal - colorRangeVals.Max()) / (colorRangeVals.Max() - colorRangeVals.Min()));
            LineSeries post = new LineSeries() { Color = OxyColor.FromRgb(color.R, color.G, color.B), LineStyle = LineStyle.Solid, StrokeThickness = 0.5 };
            post.TrackerFormatString = post.TrackerFormatString + Environment.NewLine + 
                PrintList.Items[idx].ToString() + Environment.NewLine +
                "Error: (" + vector.XE + ", " + vector.YE + ")" + Environment.NewLine +
                "Color Value: " + Math.Round(colorVal, 6).ToString();
            post.StrokeThickness = 2;
            post.Points.Add(fromP);
            post.Points.Add(toP);
            post.Points.Add(arrowheadA);
            post.Points.Add(arrowheadB);
            post.Points.Add(toP);

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

        private void btnSavePlot_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Export Fingerprint Plot";
                saveFileDialog.DefaultExt = ".png";
                saveFileDialog.Filter = "png file (*.png)|*.png";
                if (_ShowEntropy)
                {
                    saveFileDialog.FileName = Text.Replace(".txt", "FingerprintEntropy");
                }
                else
                {
                    saveFileDialog.FileName = Text.Replace(".txt", "Fingerprint");
                }
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var pngExporter = new PngExporter { Width = plot.Width, Height = plot.Width };
                    Bitmap fg = pngExporter.ExportToBitmap(plot.Model);
                    Bitmap bg = new Bitmap(fg.Width, fg.Height);
                    using (Graphics g = Graphics.FromImage(bg))
                    {
                        g.FillRectangle(Brushes.White, new Rectangle(Point.Empty, bg.Size));
                        g.DrawImage(fg, new Point(0, 0));
                    }
                    bg.Save(saveFileDialog.FileName);
                }
            }
        }
    }
}
