using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public MetroGraphs(Metro.Position[] data)
        {
            InitializeComponent();
            _raw = data;
            _data = data;
            Tuple<Metro.Position[], Metro.Position[]> _splitData = Metro.missingData(_data);
            _data = _splitData.Item2;
            _missing = _splitData.Item1;

            string[] indices = Metro.prints(_data);
            int printIdx = 1;
            int posIdx = 0;
            foreach (string index in indices)
            {
                if (!_prints.Contains(index))
                {
                    _prints.Add(index);
                    printIdx += 1;
                }
                _data[posIdx].PrintNum = printIdx;
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
            ScatterSeries passSeries = new ScatterSeries() { MarkerFill = OxyColors.Green, MarkerSize = 1 };
            for (int i = 0; i < _pass.Length; i++)
            {
                passSeries.Points.Add(new ScatterPoint(passX[i], passY[i]));
            }
            scatter.Series.Add(passSeries);

            double[] failX = Metro.XPos(_fail);
            double[] failY = Metro.YPos(_fail);
            ScatterSeries failSeries = new ScatterSeries() { MarkerFill = OxyColors.Gold, MarkerSize = 1 };
            for (int i = 0; i < _fail.Length; i++)
            {
                failSeries.Points.Add(new ScatterPoint(failX[i], failY[i]));
            }
            scatter.Series.Add(failSeries);

            double[] missingX = Metro.XPos(_missing);
            double[] missingY = Metro.YPos(_missing);
            ScatterSeries missingSeries = new ScatterSeries() { MarkerFill = OxyColors.Red, MarkerSize = 1 };
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
            BinningOptions binningOptions = new BinningOptions(BinningOutlierMode.CountOutliers, BinningIntervalType.InclusiveUpperBound, BinningExtremeValueMode.IncludeExtremeValues);
            var binBreaks = HistogramHelpers.CreateUniformBins(data.Min(), data.Max(), NumBins);
            histogramSeries.Items.AddRange(HistogramHelpers.Collect(data, binBreaks, binningOptions));
            return histogramSeries;
        }

        private RectangleBarSeries makeHistStatBars(double[] data)
        {
            RectangleBarSeries barSeries = new RectangleBarSeries() { StrokeThickness = 3, StrokeColor = OxyColors.LightSeaGreen };
            double threeSig = Stats.threeSig(data);
            double median = Stats.median(data);
            barSeries.Items.Add(new RectangleBarItem((-threeSig / 2) + median, 0, (-threeSig / 2) + median, 1e6));
            barSeries.Items.Add(new RectangleBarItem(threeSig / 2 + median, 0, threeSig / 2 + median, 1e6));
            return barSeries;
        }

        private LineSeries makeNormDistribution(double[] data)
        {
            LineSeries lineSeries = new LineSeries() { StrokeThickness = 3, Color = OxyColors.LightGreen };
            for (double i = data.Min(); i < data.Max(); i+=0.01)
            {
                lineSeries.Points.Add(new DataPoint(i, Stats.normVal(data, i)));
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
                Maximum = _prints.Count + 0.5,
                MajorStep = 1,
                MinorStep = 1
            };
            LinearAxis myXaxis2 = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "Print Number",
                Minimum = 0.5,
                Maximum = _prints.Count + 0.5,
                MajorStep = 1,
                MinorStep = 1
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
                double[] data = new double[_pass.Length];
                if (axis == "X")
                {
                    data = Metro.XError(Metro.getPrint(print, _pass));
                }
                else if (axis == "Y")
                {
                    data = Metro.YError(Metro.getPrint(print, _pass));
                }

                double[] summary = Stats.summary(data);
                double sig = Stats.threeSig(data);
                if (sig > TargetSigma)
                {
                    Red.Items.Add(new BoxPlotItem(_prints.IndexOf(print) + 1, summary[0], summary[1], summary[2], summary[3], summary[4]));
                }
                else
                {
                    Green.Items.Add(new BoxPlotItem(_prints.IndexOf(print) + 1, summary[0], summary[1], summary[2], summary[3], summary[4]));
                }
            }
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
                Maximum = _prints.Count + 0.5,
                MajorStep = 1,
                MinorStep = 1
            };
            LinearAxis myXaxis2 = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "Print Number",
                Minimum = 0.5,
                Maximum = _prints.Count + 0.5,
                MajorStep = 1,
                MinorStep = 1
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
                double[] data = new double[_pass.Length];
                if (axis == "X")
                {
                    data = Metro.XError(Metro.getPrint(print, _pass));
                }
                else if (axis == "Y")
                {
                    data = Metro.YError(Metro.getPrint(print, _pass));
                }

                double sig = Stats.threeSig(data);
                if (sig > TargetSigma + 0.5)
                {
                    RedOut.Points.Add(new ScatterPoint(_prints.IndexOf(print) + 1, TargetSigma + 0.5));
                }
                else if (sig > TargetSigma)
                {
                    Red.Points.Add(new ScatterPoint(_prints.IndexOf(print) + 1, sig));
                }
                else
                {
                    Green.Points.Add(new ScatterPoint(_prints.IndexOf(print) + 1, sig));
                }
            }
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
                double yld = (Metro.getPrint(print, _pass).Length / (float) Metro.getPrint(print, _raw).Length) * 100;
                yieldList.Add(yld);
                if (yld < TargetYield)
                {
                    Red.Points.Add(new ScatterPoint(_prints.IndexOf(print) + 1, yld));
                }
                else
                {
                    Green.Points.Add(new ScatterPoint(_prints.IndexOf(print) + 1, yld));
                }
            }

            yield.Series.Add(Green);
            yield.Series.Add(Red);

            LinearAxis myXaxis = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "Print Number",
                Minimum = 0.5,
                Maximum = _prints.Count + 0.5,
                MajorStep = 1,
                MinorStep = 1
            };
            LinearAxis myYaxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "Functional Yield (%)",
                Minimum = yieldList.Min() - 0.25,
                Maximum = 100.25,
                MajorStep = 1,
                MinorStep = 1
            };

            yield.Axes.Add(myXaxis);
            yield.Axes.Add(myYaxis);

            yieldPlot.Model = yield;
        }

        private void Plot_Click(object sender, EventArgs e)
        {
            PlotView thisPlot = (PlotView)sender;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Export " + thisPlot.AccessibleName;
                saveFileDialog.DefaultExt = ".png";
                saveFileDialog.Filter = "png file (*.png)|*.png";
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var pngExporter = new PngExporter { Width = thisPlot.Width, Height = thisPlot.Height, Background = OxyColors.White };
                    pngExporter.ExportToFile(thisPlot.Model, saveFileDialog.FileName);
                }
            }
        }
    }
}
