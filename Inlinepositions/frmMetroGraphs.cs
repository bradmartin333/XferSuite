using ScottPlot;
using ScottPlot.Statistics;
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

namespace Inlinepositions
{
    public partial class frmMetroGraphs : Form
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

        private float _Outliers = 0F;
        [
            Category("User Parameters"), 
            Description("Positions within this range of the Threshold will be plotted, but not incorporated into the calculated statistics"), 
            DisplayName("Outliers Filter")
        ]
        public float Outliers
        {
            get => _Outliers;
            set
            {
                _Outliers = value;
                MakePlots();
            }
        }

        private float _Threshold = 1.5F;
        [
            Category("User Parameters"),
            Description("Positions with placement error greater than this value will be filtered out of the plotted data")
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

        public frmMetroGraphs(Metro.Position[] data)
        {
            InitializeComponent();
            _data = data;

            string[] indices = Metro.prints(data);
            foreach (string index in indices)
            {
                if (!prints.Contains(index))
                {
                    prints.Add(index);
                }
            }

            MakePlots();
        }

        private Metro.Position[] _data;
        List<string> prints = new List<string>();

        private void MakePlots()
        {
            XYScatterPlot.plt.Clear();
            MakeXYScatter();
            XYDistPlot.plt.Clear();
            MakeXYDist();
            ComboPlot.plt.Clear();
            MakeCombo();
            XErrorPlot.plt.Clear();
            MakeXError();
            YErrorPlot.plt.Clear();
            MakeYError();
            X3SigPlot.plt.Clear();
            MakeX3Sig();
            Y3SigPlot.plt.Clear();
            MakeY3Sig();
            // Secret trick to force refresh plot & save time by only doing the selected plot
            ((FormsPlot)tabControl.SelectedTab.Controls[0]).ScrollWheelProcessor();
        }

        private void MakeXYScatter()
        {
            XYScatterPlot.plt.PlotScatter(Metro.XPos(_data), Metro.YPos(_data), lineStyle: LineStyle.None);
            XYScatterPlot.plt.Ticks(rulerModeX: true, rulerModeY: true);
            XYScatterPlot.plt.YLabel("X Position (mm)");
            XYScatterPlot.plt.XLabel("Y Position (mm)");
        }

        private void MakeXYDist()
        {
            var seriesA = new PopulationSeries(new Population[] { new Population(Metro.XError(_data)) }, "X Error");
            var seriesB = new PopulationSeries(new Population[] { new Population(Metro.YError(_data)) }, "Y Error");
            var multiSeries = new PopulationMultiSeries(new PopulationSeries[] { seriesA, seriesB });
            XYDistPlot.plt.PlotPopulations(multiSeries);
            XYDistPlot.plt.Ticks(displayTicksX: false);
            XYDistPlot.plt.Legend();
            XYDistPlot.plt.Grid(lineStyle: LineStyle.Dot, enableVertical: false);
            XYDistPlot.plt.YLabel("Position Error (um)");
        }

        private void MakeCombo()
        {

        }

        private void MakeXError()
        {
            foreach (string print in prints)
            {
                double[] error = Metro.XError(Metro.getPrint(print, _data));
                if (error.Length == 0) { continue; };
                double[] x = new double[error.Length];
                FillArray(ref x, prints.IndexOf(print) + 1);
                XErrorPlot.plt.PlotScatter(x, error, lineStyle: LineStyle.None);
            }
        }

        private void MakeYError()
        {
            foreach (string print in prints)
            {
                double[] error = Metro.YError(Metro.getPrint(print, _data));
                if (error.Length == 0) { continue; };
                double[] x = new double[error.Length];
                FillArray(ref x, prints.IndexOf(print) + 1);
                YErrorPlot.plt.PlotScatter(x, error, lineStyle: LineStyle.None);
            }
        }

        private void MakeX3Sig()
        {
            for (int i = 0; i < prints.Count; i++)
            {
                double sig = Metro.X3Sig(Metro.getPrint(prints[i], _data));
                if (sig > TargetSigma)
                {
                    X3SigPlot.plt.PlotPoint(i + 1, sig, Color.Red, 10);
                }
                else
                {
                    X3SigPlot.plt.PlotPoint(i + 1, sig, Color.Green, 10);
                }
            }
        }

        private void MakeY3Sig()
        {
            for (int i = 0; i < prints.Count; i++)
            {
                double sig = Metro.Y3Sig(Metro.getPrint(prints[i], _data));
                if (sig > TargetSigma)
                {
                    Y3SigPlot.plt.PlotPoint(i + 1, sig, Color.Red, 10);
                }
                else
                {
                    Y3SigPlot.plt.PlotPoint(i + 1, sig, Color.Green, 10);
                } 
            }
        }

        private void FillArray(ref double[] arr, int num)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = num;
            }
        }
    }
}
