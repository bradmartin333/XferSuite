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
            set => _TargetSigma = value;
        }

        private float _TargetYield = 1.5F;
        [
            Category("User Parameters"),
            Description("Print %Yield below this will be marked red"),
            DisplayName("Target %Yield")
        ]
        public float TargetYield
        {
            get => _TargetYield;
            set => _TargetYield = value;
        }

        private float _Outliers = 1.5F;
        [
            Category("User Parameters"), 
            Description("Positions within this range of the Threshold will be plotted, but not incorporated into the calculated statistics"), 
            DisplayName("Outliers Filter")
        ]
        public float Outliers
        {
            get => _Outliers;
            set => _Outliers = value;
        }

        private float _Threshold = 1.5F;
        [
            Category("User Parameters"),
            Description("Positions with placement error greater than this value will be filtered out of the plotted data")
        ]
        public float Threshold
        {
            get => _Threshold;
            set => _Threshold = value;
        }

        public frmMetroGraphs(Metro.Position[] data)
        {
            InitializeComponent();
            _data = data;
        }

        private void frmMetroGraphs_Load(object sender, EventArgs e)
        {
            MakeXYScatter();
            MakeXYDist();
            MakeCombo();
            MakeXError();
            MakeYError();
            MakeXStdDev();
            MakeYStdDev();
            Refresh();
        }

        private Metro.Position[] _data;

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
            XYScatterPlot.plt.YLabel("Position Error (um)");
        }

        private void MakeCombo()
        {

        }

        private void MakeXError()
        {

        }

        private void MakeYError()
        {

        }

        private void MakeXStdDev()
        {

        }

        private void MakeYStdDev()
        {

        }
    }
}
