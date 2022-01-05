using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private string _Path;
        private Metro.Position[] _Raw; // gets split into data and missing
        private Metro.Position[] _Data; // gets split into pass and fail
        private Metro.Position[] _Missing;
        private Metro.Position[] _Pass;
        private Metro.Position[] _Fail;
        List<string> _Prints = new List<string>();

        public MetroGraphs(string path)
        {
            InitializeComponent();
            _Path = path;
            _Raw = Metro.data(_Path);
            _ = InitializeData();
        }

        private bool InitializeData()
        {
            Tuple<Metro.Position[], Metro.Position[]> _splitData = Metro.missingData(_Raw);
            _Data = _splitData.Item2;
            _Missing = _splitData.Item1;

            string[] indices = Metro.prints(_Raw);
            int printIdx = 1;
            int posIdx = 0;
            foreach (string index in indices)
            {
                if (!_Prints.Contains(index))
                {
                    _Prints.Add(index);
                    printIdx += 1;
                }
                _Raw[posIdx].PrintNum = printIdx;
                posIdx += 1;
            }

            MakePlots();

            return true;
        }

        private void MakePlots()
        {
            Metro.rescore(_Data, Threshold);
            makeScatterPlot();
            makeErrorScatterPlot();
            makeHistograms();
            makeErrorPlots();
            makeSigmaPlots();
            makeYieldPlot();
        }

        private void makeScatterPlot()
        {
            Tuple<Metro.Position[], Metro.Position[]> _scoredData = Metro.failData(_Data);
            _Pass = _scoredData.Item2;
            _Fail = _scoredData.Item1;

            PlotModel scatter = new PlotModel() { TitleFontSize = 15 };
            double[] passX = Metro.xPos(_Pass);
            double[] passY = Metro.yPos(_Pass);
            ScatterSeries passSeries = new ScatterSeries() { MarkerFill = OxyColors.Green, MarkerSize = _PointSize };
            for (int i = 0; i < _Pass.Length; i++)
            {
                passSeries.Points.Add(new ScatterPoint(passX[i], passY[i]));
            }
            scatter.Series.Add(passSeries);

            double[] failX = Metro.xPos(_Fail);
            double[] failY = Metro.yPos(_Fail);
            ScatterSeries failSeries = new ScatterSeries() { MarkerFill = OxyColors.Gold, MarkerSize = _PointSize };
            for (int i = 0; i < _Fail.Length; i++)
            {
                failSeries.Points.Add(new ScatterPoint(failX[i], failY[i]));
            }
            scatter.Series.Add(failSeries);

            double[] missingX = Metro.xPos(_Missing);
            double[] missingY = Metro.yPos(_Missing);
            ScatterSeries missingSeries = new ScatterSeries() { MarkerFill = OxyColors.Red, MarkerSize = _PointSize };
            for (int i = 0; i < _Missing.Length; i++)
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
            scatter.Title = string.Format("{0} Pass   {1} Fail   {2} Missing", _scoredData.Item2.Length, _scoredData.Item1.Length, _Missing.Length);
            scatterPlot.Model = scatter;
        }

        private void makeErrorScatterPlot()
        {
            PlotModel errorScatter = new PlotModel() { TitleFontSize = 15 };
            double[] errorX = Metro.xError(_Pass);
            double[] errorY = Metro.yError(_Pass);
            ScatterSeries errorScatterSeries = new ScatterSeries() { MarkerType = MarkerType.Circle, MarkerFill = OxyColors.Blue, MarkerSize = 1 };
            for (int i = 0; i < _Pass.Length; i++)
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

            float FYld = _Pass.Length / (float) _Raw.Length;
            float PYld = (_Pass.Length + _Fail.Length) / (float) _Raw.Length;
            errorScatter.Title = string.Format("Func. Yield: {0}   Print Yield: {1}", FYld.ToString("p"), PYld.ToString("p"));
            errorScatterPlot.Model = errorScatter;
        }

        private void makeHistograms()
        {
            PlotModel histogramX = new PlotModel() { TitleFontSize = 15 };       
            double[] dataX = Metro.xError(_Pass);
            histogramX.Series.Add(makeHistogram(dataX));
            histogramX.Series.Add(makeHistStatBars(dataX));
            histogramX.Series.Add(makeNormDistribution(dataX));
            histogramX.Title = string.Format("Median: {0} micron   3Sigma: {1}", Stats.median(dataX), Stats.threeSig(dataX));
            
            PlotModel histogramY = new PlotModel() { TitleFontSize = 15 };
            double[] dataY = Metro.yError(_Pass);
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
                Maximum = _Prints.Count + 0.5
            };
            LinearAxis myXaxis2 = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "Print Number",
                Minimum = 0.5,
                Maximum = _Prints.Count + 0.5
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

            foreach (string print in _Prints)
            {
                double[] data = new double[_Raw.Length];
                if (axis == "X")
                {
                    data = Metro.xError(Metro.getPrint(print, _Pass));
                }
                else if (axis == "Y")
                {
                    data = Metro.yError(Metro.getPrint(print, _Pass));
                }
                if (data.Length == 0)
                {
                    continue;
                }

                double[] summary = Stats.summary(data);
                double sig = Stats.threeSig(data);
                if (sig > TargetSigma)
                {
                    Red.Items.Add(new BoxPlotItem(_Prints.IndexOf(print) + 1, summary[0], summary[1], summary[2], summary[3], summary[4]) { Tag = print });
                }
                else
                {
                    Green.Items.Add(new BoxPlotItem(_Prints.IndexOf(print) + 1, summary[0], summary[1], summary[2], summary[3], summary[4]) { Tag = print });
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
                Maximum = _Prints.Count + 0.5
            };
            LinearAxis myXaxis2 = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "Print Number",
                Minimum = 0.5,
                Maximum = _Prints.Count + 0.5
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

            foreach (string print in _Prints)
            {
                double[] data = new double[_Raw.Length];
                if (axis == "X")
                {
                    data = Metro.xError(Metro.getPrint(print, _Pass));
                }
                else if (axis == "Y")
                {
                    data = Metro.yError(Metro.getPrint(print, _Pass));
                }
                if (data.Length == 0)
                {
                    continue;
                }

                double sig = Stats.threeSig(data);
                if (sig > TargetSigma + 0.5)
                {
                    RedOut.Points.Add(new ScatterPoint(_Prints.IndexOf(print) + 1, TargetSigma + 0.5) { Tag = print + $"\nActual Value = {sig}" });
                }
                else if (sig > TargetSigma)
                {
                    Red.Points.Add(new ScatterPoint(_Prints.IndexOf(print) + 1, sig) { Tag = print });
                }
                else
                {
                    Green.Points.Add(new ScatterPoint(_Prints.IndexOf(print) + 1, sig) { Tag = print });
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

            foreach (string print in _Prints)
            {
                int FYld = Metro.getPrint(print, _Pass).Length;
                if (FYld == 0)
                {
                    continue;
                }

                double yld = (FYld / (float) Metro.getPrint(print, _Raw).Length) * 100;
                yieldList.Add(yld);
                if (yld < TargetYield)
                {
                    Red.Points.Add(new ScatterPoint(_Prints.IndexOf(print) + 1, yld) { Tag = print });
                }
                else
                {
                    Green.Points.Add(new ScatterPoint(_Prints.IndexOf(print) + 1, yld) { Tag = print });
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
                    Maximum = _Prints.Count + 0.5
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

        private void btnSaveSummary_Click(object sender, EventArgs e)
        {
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.Title = "Export Summary";
                    saveFileDialog.DefaultExt = ".png";
                    saveFileDialog.Filter = "png file (*.png)|*.png";
                    saveFileDialog.FileName = Text.Replace(".txt", "Summary");
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Bitmap output = ComposeSummary();
                        output.Save(saveFileDialog.FileName);
                    }
                }
            }
        }

        private Bitmap ComposeSummary()
        {
            Size size = new Size(0, 0);

            foreach (TabPage page in tabControl.TabPages)
                foreach (TableLayoutPanel tlp in page.Controls.OfType<TableLayoutPanel>())
                    foreach (PlotView plot in tlp.Controls.OfType<PlotView>())
                        if (!(plot.Tag == null))
                        {
                            if (plot.Width > size.Width)
                                size = new Size(plot.Width, size.Height);
                            if (plot.Height > size.Height)
                                size = new Size(size.Width, plot.Height);
                        }

            Bitmap bmp = new Bitmap(size.Width * 2, size.Height * 4);

            int pageIDX = 0;
            int i = 0;
            int j = 0;

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, size.Width * 2, size.Height * 4));

                foreach (TabPage page in tabControl.TabPages)
                {
                    if (pageIDX < 4 && pageIDX != 2) // Don't wan't boxplot
                    {
                        foreach (TableLayoutPanel tlp in page.Controls.OfType<TableLayoutPanel>())
                        {
                            foreach (PlotView plot in tlp.Controls.OfType<PlotView>())
                            {
                                var pngExporter = new PngExporter { Width = size.Width, Height = size.Height };
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
                    else if (pageIDX == 4) // Yield plot
                    {
                        foreach (PlotView plot in page.Controls.OfType<PlotView>()) // There is only one
                        {
                            var pngExporter = new PngExporter { Width = size.Width * 2, Height = size.Height };
                            g.DrawImage(pngExporter.ExportToBitmap(plot.Model), new Rectangle(0, j * size.Height, size.Width * 2, size.Height),
                                new Rectangle(0, 0, size.Width * 2, size.Height), GraphicsUnit.Pixel);
                        }
                    }

                    pageIDX++;
                }
            }

            return bmp;
        }

        private void btnShowFingerprintPlots_Click(object sender, EventArgs e)
        {
            Form form = new Fingerprinting(Metro.data(_Path)) { Text = new FileInfo(_Path).Name };
            form.Activated += MainMenu.Form_Activated;
            form.Show();
        }

        private void btnShowAnglePlots_Click(object sender, EventArgs e)
        {
            Form form = new Angleprinting(Metro.data(_Path)) { Text = new FileInfo(_Path).Name };
            form.Activated += MainMenu.Form_Activated;
            form.Show();
        }

        private void btnApplyDataFilters_Click(object sender, EventArgs e)
        {
            try
            {
                List<string[]> filters = new List<string[]>();
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    List<string> cols = new List<string>();
                    foreach (DataGridViewCell cell in row.Cells)
                        if (cell.Value != null) cols.Add(cell.Value.ToString());
                    // Make sure all cols are valid
                    if (cols.Count == 3) filters.Add(cols.ToArray()); 
                }

                _Raw = Metro.filterData(filters.ToArray(), Metro.data(_Path));
                InitializeData();
            }        
            catch (Exception)
            {
                MessageBox.Show("Error in data filter entries", "XferSuite");
            }
        }
    }
}
