using System.Linq;
using ScottPlot.Plottable;
using System.Windows.Forms;
using ScottPlot.Statistics;
using System.Drawing;
using System;

namespace XferSuite.Apps.SEYR
{
    public partial class PassFailUtility : Form
    {
        public double PassThreshold;
        public double Limit;
        private readonly Feature Feature;
        private double[] HistData { get => Feature.HistData; }
        private bool FlipScore { get => Feature.FlipScore; }
        private readonly int NullExclude;
        private readonly int NullInclude;
        private BarPlot BarPlot;
        private Annotation ViewDataAnnotation;

        public PassFailUtility(Feature feature)
        {
            InitializeComponent();
            Feature = feature;
            Text = $"Editing {feature.Name}";
            PassThreshold = feature.PassThreshold;
            Limit = feature.Limit;

            (NullExclude, NullInclude) = feature.GetNullData();
            LabelNullExcludeCount.Text = NullExclude.ToString();
            LabelNullIncludeCount.Text = NullInclude.ToString();

            MakeHistogram();
            MakePie();
        }

        #region Histogram

        private void MakeHistogram()
        {
            HistPlot.Plot.Clear();

            if (HistData.Length < 2) return; // Insufficient data
            (double[] counts, double[] binEdges) = Common.Histogram(HistData, min: HistData.Min(), max: HistData.Max(), binSize: 1);
            double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();
            BarPlot = HistPlot.Plot.AddBar(values: counts, positions: leftEdges);
            BarPlot.BarWidth = 1;
            BarPlot.BorderColor = Color.Transparent;

            ViewDataAnnotation = HistPlot.Plot.AddAnnotation("Score = N/A", 10, 10);
            ViewDataAnnotation.BackgroundColor = Color.FromArgb(200, Color.White);
            ViewDataAnnotation.BorderColor = Color.Transparent;
            ViewDataAnnotation.Font.Color = Color.Black;
            ViewDataAnnotation.Shadow = false;
            HistPlot.MouseWheel += Control_MouseWheel;
            HistPlot.Configuration.DoubleClickBenchmark = false;
            HistPlot.MouseUp += Control_MouseUp;

            HSpan hSpan = HistPlot.Plot.AddHorizontalSpan(
                FlipScore ? Limit : PassThreshold, 
                FlipScore ? PassThreshold : Limit, 
                Color.FromArgb(75, Color.SlateGray));
            hSpan.DragEnabled = true;
            hSpan.Dragged += HSpan_Dragged;

            HistPlot.Refresh();
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            ScottPlot.FormsPlot p = (ScottPlot.FormsPlot)sender;
            (double mX, _) = p.GetMouseCoordinates();
            int x = (int)Math.Floor(mX);
            string message = $"Score = {x}\n";
            for (int i = 0; i < BarPlot.Positions.Length; i++)
                if (Math.Floor(BarPlot.Positions[i]) == x && BarPlot.Values[i] > 0)
                    message += $"Count = {BarPlot.Values[i]}\n";
            ViewDataAnnotation.Label = message;
            p.Refresh();
        }

        private void Control_MouseWheel(object sender, MouseEventArgs e)
        {
            ScottPlot.FormsPlot control = (ScottPlot.FormsPlot)sender;
            switch (GetControlAxis(control, e.Location))
            {
                case 0:
                    control.Plot.XAxis.LockLimits(true);
                    control.Plot.YAxis.LockLimits(false);
                    break;
                case 1:
                    control.Plot.XAxis.LockLimits(false);
                    control.Plot.YAxis.LockLimits(true);
                    break;
                default:
                    control.Plot.XAxis.LockLimits(false);
                    control.Plot.YAxis.LockLimits(false);
                    break;
            }
        }

        private int GetControlAxis(ScottPlot.FormsPlot control, Point location)
        {
            if (location.X < 60) // At XAxis
                return 0;
            else if (location.Y > control.Height - 60) // At YAxis
                return 1;
            else
                return -1;
        }

        private void HSpan_Dragged(object sender, EventArgs e)
        {
            HSpan hSpan = (HSpan)sender;
            double minVal = Math.Min(hSpan.X1, hSpan.X2);
            double maxVal = Math.Max(hSpan.X1, hSpan.X2);
            Limit = FlipScore ? minVal : maxVal;
            PassThreshold = FlipScore ? maxVal : minVal;
            ViewDataAnnotation.Label = $"Limit = {Math.Round(Limit, 2)}\nPass Threshold = {Math.Round(PassThreshold, 2)}";
            MakePie();
        }

        #endregion

        private void MakePie()
        {
            PiePlot.Plot.Clear();
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
            double numPass = HistData.Where(
                x => (FlipScore ? x < PassThreshold : x > PassThreshold) && 
                (FlipScore ? x > Limit : x < Limit)).Count();
            double numFail = HistData.Length - numPass;
            LabelSelectedCount.Text = numPass.ToString();
            LabelUnselectedCount.Text = numFail.ToString();
            LabelTotalCount.Text = $"{NullExclude + NullInclude + numPass + numFail}";
            return new double[] { numPass + NullInclude, numFail + NullExclude };
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
