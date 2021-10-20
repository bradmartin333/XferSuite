using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class MetroGraphs : Form
    {
        private float _TargetSigma = 1.5F;
        [
            Category("User Parameters"),
            Description("Print 3 Sigma values above this will be marked red"),
            DisplayName("Target 3 Sigma")
        ]
        public float TargetSigma
        {
            get => _TargetSigma;
            set
            {
                _TargetSigma = value;
                MakePlots();
            }
        }

        private float _TargetYield = 98F;
        [
            Category("User Parameters"),
            Description("Print %Yield below this will be marked red"),
            DisplayName("Target %Yield")
        ]
        public float TargetYield
        {
            get => _TargetYield;
            set
            {
                _TargetYield = value;
                MakePlots();
            }
        }

        private float _Threshold = 10F;
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
                MakePlots();
            }
        }

        private int _NumBins = 50;
        [
            Category("User Parameters"),
            Description("Number of bins in histogram plots"),
            DisplayName("Histogram Bin Count")
        ]
        public int NumBins
        {
            get => _NumBins;
            set
            {
                _NumBins = value;
                MakePlots();
            }
        }

        private int _PointSize = 1;
        [
            Category("User Parameters"),
            Description("Size of points in scatterplot"),
        ]
        public int PointSize
        {
            get => _PointSize;
            set
            {
                _PointSize = value;
                MakePlots();
            }
        }

        public MetroGraphs(Metro.Position[] data)
        {
            InitializeComponent();
            _raw = data;
            Tuple<Metro.Position[], Metro.Position[]> _splitData = Metro.missingData(_raw);
            _data = _splitData.Item2;
            _missing = _splitData.Item1;

            string[] indices = Metro.prints(_raw);
            int printIdx = 1;
            int posIdx = 0;
            foreach (string index in indices)
            {
                if (!_prints.Contains(index))
                {
                    _prints.Add(index);
                    printIdx += 1;
                }
                _raw[posIdx].PrintNum = printIdx;
                posIdx += 1;
            }

            MakePlots();
        }

        private Metro.Position[] _raw; // gets split into data and missing
        private Metro.Position[] _data; // gets split into pass and fail
        private Metro.Position[] _missing;
        private Metro.Position[] _pass;
        private Metro.Position[] _fail;
        List<string> _prints = new List<string>();

        private void MakePlots()
        {
            Metro.Rescore(_data, Threshold);
            makeScatterPlot();
            makeErrorScatterPlot();
            makeHistograms();
            makeErrorPlots();
            makeSigmaPlots();
            makeYieldPlot();
        }

        private void makeScatterPlot()
        {
            Tuple<Metro.Position[], Metro.Position[]> _scoredData = Metro.failData(_data);
            _pass = _scoredData.Item2;
            _fail = _scoredData.Item1;

            PlotModel scatter = new PlotModel() { TitleFontSize = 15 };
            double[] passX = Metro.XPos(_pass);
            double[] passY = Metro.YPos(_pass);
            ScatterSeries passSeries = new ScatterSeries() { MarkerFill = OxyColors.Green, MarkerSize = _PointSize };
            for (int i = 0; i < _pass.Length; i++)
            {
                passSeries.Points.Add(new ScatterPoint(passX[i], passY[i]));
            }
            scatter.Series.Add(passSeries);

            double[] failX = Metro.XPos(_fail);
            double[] failY = Metro.YPos(_fail);
            ScatterSeries failSeries = new ScatterSeries() { MarkerFill = OxyColors.Gold, MarkerSize = _PointSize };
            for (int i = 0; i < _fail.Length; i++)
            {
                failSeries.Points.Add(new ScatterPoint(failX[i], failY[i]));
            }
            scatter.Series.Add(failSeries);

            double[] missingX = Metro.XPos(_missing);
            double[] missingY = Metro.YPos(_missing);
            ScatterSeries missingSeries = new ScatterSeries() { MarkerFill = OxyColors.Red, MarkerSize = _PointSize };
            for (int i = 0; i < _missing.Length; i++)
            {
                missingSeries.Points.Add(new ScatterPoint(missingX[i], missingY[i]));
            }
            scatter.Series.Add(missingSeries);

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

            scatter.Axes.Add(myXaxis);
            scatter.Axes.Add(myYaxis);
            scatter.Title = string.Format("{0} Pass   {1} Fail   {2} Missing", _scoredData.Item2.Length, _scoredData.Item1.Length, _missing.Length);
            scatterPlot.Model = scatter;
        }

        private void makeErrorScatterPlot()
        {
            PlotModel errorScatter = new PlotModel() { TitleFontSize = 15 };
            double[] errorX = Metro.XError(_pass);
            double[] errorY = Metro.YError(_pass);
            ScatterSeries errorScatterSeries = new ScatterSeries() { MarkerType = MarkerType.Circle, MarkerFill = OxyColors.Blue, MarkerSize = 1 };
            for (int i = 0; i < _pass.Length; i++)
            {
                errorScatterSeries.Points.Add(new ScatterPoint(errorX[i], errorY[i]));
            }
            errorScatter.Series.Add(errorScatterSeries);

            LinearAxis myXaxis = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "X Error Distance (microns)"
            };
            LinearAxis myYaxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "Y Error Distance (microns)"
            };

            errorScatter.Axes.Add(myXaxis);
            errorScatter.Axes.Add(myYaxis);

            float FYld = _pass.Length / (float) _raw.Length;
            float PYld = (_pass.Length + _fail.Length) / (float) _raw.Length;
            errorScatter.Title = string.Format("Func. Yield: {0}   Print Yield: {1}", FYld.ToString("p"), PYld.ToString("p"));
            errorScatterPlot.Model = errorScatter;
        }

        private void makeHistograms()
        {
            PlotModel histogramX = new PlotModel() { TitleFontSize = 15 };       
            double[] dataX = Metro.XError(_pass);
            histogramX.Series.Add(makeHistogram(dataX));
            histogramX.Series.Add(makeHistStatBars(dataX));
            histogramX.Series.Add(makeNormDistribution(dataX));
            histogramX.Title = string.Format("Median: {0} micron   3Sigma: {1}", Stats.median(dataX), Stats.threeSig(dataX));
            
            PlotModel histogramY = new PlotModel() { TitleFontSize = 15 };
            double[] dataY = Metro.YError(_pass);
            histogramY.Series.Add(makeHistogram(dataY));
            histogramY.Series.Add(makeHistStatBars(dataY));
            histogramY.Series.Add(makeNormDistribution(dataY));
            histogramY.Title = string.Format("Median: {0} micron   3Sigma: {1}", Stats.median(dataY), Stats.threeSig(dataY));

            LinearAxis myXaxis1 = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "X Error Distance (microns)",
                Minimum = -Threshold,
                Maximum = Threshold
            };
            LinearAxis myXaxis2 = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "X Error Distance (microns)",
                Minimum = -Threshold,
                Maximum = Threshold
            };
            LinearAxis myYaxis1 = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "Relative Frequency",
                Maximum = 5
            };
            LinearAxis myYaxis2 = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "Relative Frequency",
                Maximum = 5
            };

            histogramX.Axes.Add(myXaxis1);
            histogramY.Axes.Add(myXaxis2);
            histogramX.Axes.Add(myYaxis1);
            histogramY.Axes.Add(myYaxis2);

            histogramPlotX.Model = histogramX;
            histogramPlotY.Model = histogramY;
        }

        private HistogramSeries makeHistogram(double[] data)
        {
            HistogramSeries histogramSeries = new HistogramSeries() { FillColor = OxyColors.DarkBlue };
            try
            {
                BinningOptions binningOptions = new BinningOptions(BinningOutlierMode.CountOutliers, BinningIntervalType.InclusiveUpperBound, BinningExtremeValueMode.IncludeExtremeValues);
                var binBreaks = HistogramHelpers.CreateUniformBins(data.Min(), data.Max(), NumBins);
                histogramSeries.Items.AddRange(HistogramHelpers.Collect(data, binBreaks, binningOptions));
            }
            catch (Exception)
            {
                // Insufficient Data
            }
            return histogramSeries;
        }

        private RectangleBarSeries makeHistStatBars(double[] data)
        {
            RectangleBarSeries barSeries = new RectangleBarSeries() { StrokeThickness = 3, StrokeColor = OxyColors.LightSeaGreen };
            double threeSig = Stats.threeSig(data);
            double median = Stats.median(data);
            barSeries.Items.Add(new RectangleBarItem((-threeSig / 2) + median, 0, (-threeSig / 2) + median, 1e6));
            barSeries.Items.Add(new RectangleBarItem((threeSig / 2) + median, 0,( threeSig / 2) + median, 1e6));
            return barSeries;
        }

        private LineSeries makeNormDistribution(double[] data)
        {
            LineSeries lineSeries = new LineSeries() { StrokeThickness = 3, Color = OxyColors.LightGreen };
            try
            {
                for (double i = data.Min(); i < data.Max(); i += 0.01)
                {
                    lineSeries.Points.Add(new DataPoint(i, Stats.normVal(data, i)));
                }
            }
            catch (Exception)
            {
                // Insufficient Data
            }
            return lineSeries;
        }

        private void makeErrorPlots()
        {
            PlotModel boxplotX = new PlotModel() { TitleFontSize = 15 };
            BoxPlotSeries[] plotsX = makeBoxPlot("X");
            boxplotX.Series.Add(plotsX[0]);
            boxplotX.Series.Add(plotsX[1]);

            PlotModel boxplotY = new PlotModel() { TitleFontSize = 15 };
            BoxPlotSeries[] plotsY = makeBoxPlot("Y");
            boxplotY.Series.Add(plotsY[0]);
            boxplotY.Series.Add(plotsY[1]);

            LinearAxis myXaxis1 = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "Print Number",
                Minimum = 0.5,
                Maximum = _prints.Count + 0.5
            };
            LinearAxis myXaxis2 = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "Print Number",
                Minimum = 0.5,
                Maximum = _prints.Count + 0.5
            };
            LinearAxis myYaxis1 = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "X Error (microns)",
                Minimum = -3,
                Maximum = 3
            };
            LinearAxis myYaxis2 = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "Y Error (microns)",
                Minimum = -3,
                Maximum = 3
            };

            boxplotX.Axes.Add(myXaxis1);
            boxplotY.Axes.Add(myXaxis2);
            boxplotX.Axes.Add(myYaxis1);
            boxplotY.Axes.Add(myYaxis2);

            errorBoxplotX.Model = boxplotX;
            errorBoxplotY.Model = boxplotY;
        }

        private BoxPlotSeries[] makeBoxPlot(string axis)
        {
            BoxPlotSeries Red = new BoxPlotSeries() { Fill = OxyColors.Red };
            BoxPlotSeries Green = new BoxPlotSeries() { Fill = OxyColors.Green };

            foreach (string print in _prints)
            {
                double[] data = new double[_raw.Length];
                if (axis == "X")
                {
                    data = Metro.XError(Metro.getPrint(print, _data));
                }
                else if (axis == "Y")
                {
                    data = Metro.YError(Metro.getPrint(print, _data));
                }
                if (data.Length == 0)
                {
                    continue;
                }

                double[] summary = Stats.summary(data);
                double sig = Stats.threeSig(data);
                if (sig > TargetSigma)
                {
                    Red.Items.Add(new BoxPlotItem(_prints.IndexOf(print) + 1, summary[0], summary[1], summary[2], summary[3], summary[4]) { Tag = print });
                }
                else
                {
                    Green.Items.Add(new BoxPlotItem(_prints.IndexOf(print) + 1, summary[0], summary[1], summary[2], summary[3], summary[4]) { Tag = print });
                }
            }

            Red.TrackerFormatString = Red.TrackerFormatString + Environment.NewLine + "{Tag}";
            Green.TrackerFormatString = Green.TrackerFormatString + Environment.NewLine + "{Tag}";

            return new BoxPlotSeries[] { Red, Green };
        }

        private void makeSigmaPlots()
        {
            PlotModel sigmaX = new PlotModel() { TitleFontSize = 15 };
            ScatterSeries[] sigmaScattersX = makeSigmaScatter("X");
            sigmaX.Series.Add(sigmaScattersX[0]);
            sigmaX.Series.Add(sigmaScattersX[1]);
            sigmaX.Series.Add(sigmaScattersX[2]);

            PlotModel sigmaY = new PlotModel() { TitleFontSize = 15 };
            ScatterSeries[] sigmaScattersY = makeSigmaScatter("Y");
            sigmaY.Series.Add(sigmaScattersY[0]);
            sigmaY.Series.Add(sigmaScattersY[1]);
            sigmaY.Series.Add(sigmaScattersY[2]);

            LinearAxis myXaxis1 = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "Print Number",
                Minimum = 0.5,
                Maximum = _prints.Count + 0.5
            };
            LinearAxis myXaxis2 = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "Print Number",
                Minimum = 0.5,
                Maximum = _prints.Count + 0.5
            };
            LinearAxis myYaxis1 = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "X 3Sigma (microns)",
                Minimum = 0,
                Maximum = TargetSigma + 0.6
            };
            LinearAxis myYaxis2 = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title =  "Y 3Sigma (microns)",
                Minimum = 0,
                Maximum = TargetSigma + 0.6
            };

            sigmaX.Axes.Add(myXaxis1);
            sigmaY.Axes.Add(myXaxis2);
            sigmaX.Axes.Add(myYaxis1);
            sigmaY.Axes.Add(myYaxis2);

            sigmaPlotX.Model = sigmaX;
            sigmaPlotY.Model = sigmaY;
        }

        private ScatterSeries[] makeSigmaScatter(string axis)
        {
            ScatterSeries Green = new ScatterSeries() {MarkerSize = 3, MarkerType = MarkerType.Circle, MarkerFill = OxyColors.Green };
            ScatterSeries Red = new ScatterSeries() {MarkerSize = 3, MarkerType = MarkerType.Circle, MarkerFill = OxyColors.Red };
            ScatterSeries RedOut = new ScatterSeries() {MarkerSize = 3, MarkerType = MarkerType.Cross, MarkerStroke = OxyColors.Red };

            foreach (string print in _prints)
            {
                double[] data = new double[_raw.Length];
                if (axis == "X")
                {
                    data = Metro.XError(Metro.getPrint(print, _data));
                }
                else if (axis == "Y")
                {
                    data = Metro.YError(Metro.getPrint(print, _data));
                }
                if (data.Length == 0)
                {
                    continue;
                }

                double sig = Stats.threeSig(data);
                if (sig > TargetSigma + 0.5)
                {
                    RedOut.Points.Add(new ScatterPoint(_prints.IndexOf(print) + 1, TargetSigma + 0.5) { Tag = print });
                }
                else if (sig > TargetSigma)
                {
                    Red.Points.Add(new ScatterPoint(_prints.IndexOf(print) + 1, sig) { Tag = print });
                }
                else
                {
                    Green.Points.Add(new ScatterPoint(_prints.IndexOf(print) + 1, sig) { Tag = print });
                }
            }

            Green.TrackerFormatString = Green.TrackerFormatString + Environment.NewLine + "{Tag}";
            Red.TrackerFormatString = Red.TrackerFormatString + Environment.NewLine + "{Tag}";
            RedOut.TrackerFormatString = RedOut.TrackerFormatString + Environment.NewLine + "{Tag}";

            return new ScatterSeries[] { RedOut, Red, Green };
        }

        private void makeYieldPlot()
        {
            PlotModel yield = new PlotModel() { TitleFontSize = 15 };

            List<double> yieldList = new List<double>();
            ScatterSeries Green = new ScatterSeries() { MarkerSize = 5, MarkerType = MarkerType.Circle, MarkerFill = OxyColors.Green };
            ScatterSeries Red = new ScatterSeries() { MarkerSize = 5, MarkerType = MarkerType.Circle, MarkerFill = OxyColors.Red };

            foreach (string print in _prints)
            {
                int FYld = Metro.getPrint(print, _pass).Length;
                if (FYld == 0)
                {
                    continue;
                }

                double yld = (FYld / (float) Metro.getPrint(print, _raw).Length) * 100;
                yieldList.Add(yld);
                if (yld < TargetYield)
                {
                    Red.Points.Add(new ScatterPoint(_prints.IndexOf(print) + 1, yld) { Tag = print });
                }
                else
                {
                    Green.Points.Add(new ScatterPoint(_prints.IndexOf(print) + 1, yld) { Tag = print });
                }
            }

            Green.TrackerFormatString = Green.TrackerFormatString + Environment.NewLine + "{Tag}";
            Red.TrackerFormatString = Red.TrackerFormatString + Environment.NewLine + "{Tag}";

            yield.Series.Add(Green);
            yield.Series.Add(Red);

            try
            {
                LinearAxis myXaxis = new LinearAxis()
                {
                    Position = AxisPosition.Bottom,
                    Title = "Print Number",
                    Minimum = 0.5,
                    Maximum = _prints.Count + 0.5
                };
                LinearAxis myYaxis = new LinearAxis()
                {
                    Position = AxisPosition.Left,
                    Title = "Functional Yield (%)",
                    Minimum = yieldList.Min() - 0.25,
                    Maximum = 100.25
                };

                yield.Axes.Add(myXaxis);
                yield.Axes.Add(myYaxis);
            }
            catch (Exception)
            {
                // Insufficient Data
            }

            yieldPlot.Model = yield;
        }

        //private void SaveSummary()
        //{
        //    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        //    {
        //        saveFileDialog.RestoreDirectory = true;
        //        saveFileDialog.Title = "Export 4 Graph Summary";
        //        saveFileDialog.DefaultExt = ".png";
        //        saveFileDialog.Filter = "png file (*.png)|*.png";
        //        saveFileDialog.FileName = Text.Replace(".txt", "Summary");
        //        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            Bitmap output = ComposeSummary();
        //            output.Save(saveFileDialog.FileName);
        //        }
        //    }
        //}

        private Bitmap ComposeSummary()
        {
            Size size = new Size(0, 0);

            foreach (TabPage page in tabControl1.TabPages)
            {
                foreach (TableLayoutPanel tlp in page.Controls.OfType<TableLayoutPanel>())
                {
                    foreach (PlotView plot in tlp.Controls.OfType<PlotView>())
                    {
                        if (!(plot.Tag == null))
                        {
                            if (plot.Width > size.Width | plot.Height > size.Height)
                            {
                                size = plot.Size;
                            }
                        }
                    }
                }
            }

            Bitmap bmp = new Bitmap(size.Width * 2, size.Height * 2); // First 2 pages

            int i = 0;
            int j = 0;

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, size.Width * 2, size.Height * 2));

                foreach (TabPage page in tabControl1.TabPages)
                {
                    if (j == 2)
                    {
                        continue; // Only save first 2 pages for now
                    }

                    foreach (TableLayoutPanel tlp in page.Controls.OfType<TableLayoutPanel>())
                    {
                        foreach (PlotView plot in tlp.Controls.OfType<PlotView>())
                        {
                            var pngExporter = new PngExporter { Width = size.Width, Height = size.Width };
                            g.DrawImage(pngExporter.ExportToBitmap(plot.Model), new Rectangle(i * size.Width, j * size.Height, size.Width, size.Height), 
                                new Rectangle(0, 0, size.Width, size.Height), GraphicsUnit.Pixel);

                            i += 1;
                            if (i == 2)
                            {
                                i = 0;
                                j += 1;
                            }
                        }
                    }
                }
            }

            return bmp;
        }
    }
}
