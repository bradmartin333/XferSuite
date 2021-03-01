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
