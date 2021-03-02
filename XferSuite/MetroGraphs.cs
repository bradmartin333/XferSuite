﻿using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
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
                if (!prints.Contains(index))
                {
                    prints.Add(index);
                    printIdx += 1;
                }
                _data[posIdx].PrintNum = printIdx;
                posIdx += 1;
            }

            MakePlots();
        }

        private Metro.Position[] _raw;
        private Metro.Position[] _data;
        private Metro.Position[] _missing;
        private Metro.Position[] _pass;
        private Metro.Position[] _fail;
        List<string> prints = new List<string>();

        private void MakePlots()
        {
            Metro.Rescore(_data, Threshold);
            makeScatterPlot();
            makeErrorScatterPlot();
        }

        private void makeScatterPlot()
        {
            Tuple<Metro.Position[], Metro.Position[]> _scoredData = Metro.failData(_data);
            _pass = _scoredData.Item2;
            _fail = _scoredData.Item1;

            PlotModel scatter = new PlotModel() { TitleFontSize = 15 }; 
            
            double[] passX = Metro.XPos(_pass);
            double[] passY = Metro.YPos(_pass);
            ScatterSeries passSeries = new ScatterSeries() { MarkerFill = OxyColors.Green, MarkerSize = 2 };
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
    }
}
