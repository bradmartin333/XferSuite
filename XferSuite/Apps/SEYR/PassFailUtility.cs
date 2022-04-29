using System.Linq;
using ScottPlot.Plottable;
using System.Windows.Forms;
using ScottPlot.Statistics;
using System.Drawing;

namespace XferSuite.Apps.SEYR
{
    public partial class PassFailUtility : Form
    {
        private readonly DataEntry[] Data;
        private readonly double[] HistData;
        private readonly float PassThreshold;
        private readonly bool FlipScore;
        private readonly int NullExclude;
        private readonly int NullInclude;

        public PassFailUtility(DataEntry[] data)
        {
            InitializeComponent();
            Data = data;
            Text = $"Editing {Data[0].FeatureName}";
            HistData = Data.Select(x => (double)x.Score).Where(x => x > 0).ToArray();
            PassThreshold = (Data[0].Feature.MaxScore - Data[0].Feature.MinScore) / 2;
            FlipScore = Data[0].Feature.FlipScore;

            float[] scores = Data.Select(x => x.Score).ToArray();
            NullExclude = scores.Where(x => x == -10).Count();
            NullInclude = scores.Where(x => x == 0).Count();
            LabelNullExcludeCount.Text = NullExclude.ToString();
            LabelNullIncludeCount.Text = NullInclude.ToString();

            MakeHistogram();
            MakePie();
        }

        private void MakeHistogram()
        {
            if (HistData.Length < 2) return; // Insufficient data
            (double[] counts, double[] binEdges) = Common.Histogram(HistData, min: HistData.Min(), max: HistData.Max(), binSize: 1);
            double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();
            BarPlot bar = HistPlot.Plot.AddBar(values: counts, positions: leftEdges);
            bar.BarWidth = 1;
            bar.BorderColor = Color.Transparent;
            HistPlot.Refresh();
        }

        private void MakePie()
        {
            double[] values = GetValues();
            Color color1 = Color.FromArgb(255, 0, 150, 200);
            Color color2 = Color.FromArgb(100, 0, 150, 200);
            var pie = PiePlot.Plot.AddPie(values);
            pie.DonutSize = .6;
            pie.DonutLabel = (values[0] / values.Sum()).ToString("P");
            pie.CenterFont.Color = color1;
            pie.CenterFont.Size = 18;
            pie.OutlineSize = 2;
            pie.SliceFillColors = new Color[] { color1, color2 };
            PiePlot.Configuration.DoubleClickBenchmark = false;
            PiePlot.Plot.XAxis.LockLimits();
            PiePlot.Plot.YAxis.LockLimits();
            PiePlot.Refresh();
        }

        private double[] GetValues()
        {
            double numPass = HistData.Where(x => FlipScore ? x < PassThreshold : x > PassThreshold).Count();
            double numFail = HistData.Length - numPass;
            LabelSelectedCount.Text = numPass.ToString();
            LabelUnselectedCount.Text = numFail.ToString();
            LabelTotalCount.Text = $"{NullExclude + NullInclude + numPass + numFail}";
            return new double[] { numPass + NullInclude, numFail + NullExclude };
        }
    }
}
