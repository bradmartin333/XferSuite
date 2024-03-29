﻿using System.Linq;
using ScottPlot.Plottable;
using System.Windows.Forms;
using ScottPlot.Statistics;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace XferSuite.Apps.SEYR
{
    public partial class PassFailUtility : Form
    {
        public double PassThreshold;
        public double Limit;
        private readonly List<DataEntry> Data;
        private readonly int NullExclude;
        private readonly int NullInclude;
        private readonly int NumberImagesInScroller = 25;
        private readonly float PenSize;
        private readonly Feature Feature;
        private double[] HistData { get => Feature.HistData; }
        private bool FlipScore { get => Feature.FlipScore; }
        private BarPlot BarPlot;
        private Annotation ViewDataAnnotation;
        private bool HSpanChanging = false;
        private bool LoadingImages = false;
        private Point ClickPoint = Point.Empty;

        public PassFailUtility(List<DataEntry> data, Feature feature, int numberImagesInScroller, float penSize)
        {
            InitializeComponent();
            Data = data;
            Feature = feature;
            Text = $"Editing \"{feature.Name}\"";
            PassThreshold = feature.PassThreshold;
            Limit = feature.Limit;
            TxtCriteriaString.Text = feature.CriteriaString;
            NumberImagesInScroller = numberImagesInScroller;
            PenSize = penSize;

            (NullExclude, NullInclude) = feature.GetNullData();
            LabelNullExcludeCount.Text = NullExclude.ToString();
            LabelNullIncludeCount.Text = NullInclude.ToString();
            BtnIgnoreFeature.Text = feature.Ignore ? "Include Feature" : "Ignore Feature";
            BtnIgnoreFeature.BackColor = feature.Ignore ? Color.Gold : Color.LightCoral;

            HistPlot.Plot.Grid(false);

            MakeHistogram();
            MakePie();

            FormClosing += PassFailUtility_FormClosing;
        }

        private void PassFailUtility_FormClosing(object sender, FormClosingEventArgs e)
        {
            ImageScroller.LastSelectedFeatureName = string.Empty;
            CloseImageScroller();
        }

        private void CloseImageScroller()
        {
            if (Application.OpenForms.OfType<ImageScroller>().Any())
                Application.OpenForms.OfType<ImageScroller>().First().Close();
        }

        #region Histogram

        private void MakeHistogram()
        {
            HistPlot.Plot.Clear();

            if (HistData.Length < 2) return; // Insufficient data

            double histMax = HistData.Max();
            double histMin = HistData.Min();
            if (histMax == histMin)
                BarPlot = HistPlot.Plot.AddBar(values: new double[] { HistData.Length }, positions: new double[] { HistData[0] });
            else
            {
                double flexBinSize = 1;
                if (histMax - histMin < 2) flexBinSize = (histMax - histMin) / 100;
                (double[] counts, double[] binEdges) = Common.Histogram(HistData, min: HistData.Min(), max: HistData.Max(), binSize: flexBinSize);
                double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();
                BarPlot = HistPlot.Plot.AddBar(values: counts, positions: leftEdges);
            }
            BarPlot.BarWidth = 1;
            BarPlot.BorderColor = Color.Transparent;

            ViewDataAnnotation = HistPlot.Plot.AddAnnotation("Score = N/A", 10, 10);
            ViewDataAnnotation.BackgroundColor = Color.FromArgb(200, Color.White);
            ViewDataAnnotation.BorderColor = Color.Transparent;
            ViewDataAnnotation.Font.Color = Color.Black;
            ViewDataAnnotation.Shadow = false;
            HistPlot.MouseWheel += Control_MouseWheel;
            HistPlot.Configuration.DoubleClickBenchmark = false;
            HistPlot.Configuration.EnablePlotObjectEditor = true;
            HistPlot.MouseDown += HistPlot_MouseDown;
            HistPlot.MouseUp += Control_MouseUp;

            HSpan hSpan = HistPlot.Plot.AddHorizontalSpan(
                FlipScore ? Limit : PassThreshold, 
                FlipScore ? PassThreshold : Limit, 
                Color.FromArgb(75, Color.SlateGray));
            hSpan.DragEnabled = true;
            hSpan.Dragged += HSpan_Dragged;

            HistPlot.Refresh();
        }

        private void HistPlot_MouseDown(object sender, MouseEventArgs e)
        {
            ClickPoint = e.Location;
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (LoadingImages || e.Location != ClickPoint) return;
            ScottPlot.FormsPlot p = (ScottPlot.FormsPlot)sender;
            (double mX, _) = p.GetMouseCoordinates();
            int x = (int)Math.Floor(mX);
            string message = $"Score = {x}\n";
            for (int i = 0; i < BarPlot.Positions.Length; i++)
                if (Math.Floor(BarPlot.Positions[i]) == x && BarPlot.Values[i] > 0)
                    message += $"Count = {BarPlot.Values[i]}\n";
            ViewDataAnnotation.Label = message;
            if (!HSpanChanging) ShowImages(x);
            else CloseImageScroller();
            HSpanChanging = false;
            p.Refresh();
        }

        private void ShowImages(int x)
        {
            using (new Utility.HourGlass(false))
            {
                if (LoadingImages) return;
                LoadingImages = true;
                string[] locations = Data.Where(d => Math.Abs(d.Score - x) <= 1 && d.FeatureName == Feature.Name).Select(e => e.Location()).Distinct().ToArray();
                HashSet<string> locationsHashSet = new HashSet<string>(locations);
                DataEntry[] imageEntriesRaw = Data.Where(d => d.Feature.SaveImage).ToArray();
                if (imageEntriesRaw.Length > 0)
                {
                    string[] imageFeatures = imageEntriesRaw.Select(d => d.Feature.CriteriaString).Distinct().ToArray();
                    bool drawFeatures = imageFeatures.Length == 1 && imageFeatures[0] == "img";
                    DataEntry[] imageEntries = imageEntriesRaw.Where(d => locationsHashSet.Contains(d.Location())).ToArray();
                    CloseImageScroller();
                    if (imageEntries.Any())
                    {
                        IEnumerable<IGrouping<string, DataEntry>> imageGroups = imageEntries.GroupBy(e => e.FeatureName);
                        string initialFeature = Feature.SaveImage ? Feature.Name : imageGroups.First().Key;
                        _ = new ImageScroller(imageGroups, initialFeature, Feature, NumberImagesInScroller, x, PenSize, drawFeatures);
                    }
                }
                LoadingImages = false;
            }
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
            HSpanChanging = true;
            HSpan hSpan = (HSpan)sender;
            double minVal = Math.Min(hSpan.X1, hSpan.X2);
            double maxVal = Math.Max(hSpan.X1, hSpan.X2);
            Limit = Math.Round(FlipScore ? minVal : maxVal);
            PassThreshold = Math.Round(FlipScore ? maxVal : minVal);
            ViewDataAnnotation.Label = $"Limit = {Limit}\nPass Threshold = {PassThreshold}";
            MakePie();
        }

        #endregion

        private void MakePie()
        {
            PiePlot.Plot.Clear();
            double[] values = GetValues();
            var pie = PiePlot.Plot.AddPie(values);
            pie.DonutSize = .6;
            pie.DonutLabel = (values[0] / values.Sum()).ToString("P");
            pie.CenterFont.Color = Color.Black;
            pie.CenterFont.Size = 18;
            pie.OutlineSize = 2;
            pie.SliceFillColors = new Color[] { Color.LightGreen, Color.LightCoral };
            PiePlot.Configuration.DoubleClickBenchmark = false;
            PiePlot.Configuration.EnablePlotObjectEditor = true;
            PiePlot.Plot.XAxis.LockLimits();
            PiePlot.Plot.YAxis.LockLimits();
            PiePlot.Refresh();
        }

        private double[] GetValues()
        {
            double numPass = HistData.Where(
                x => (FlipScore ? x <= PassThreshold : x >= PassThreshold) && 
                (FlipScore ? x >= Limit : x <= Limit)).Count();
            double numFail = HistData.Length - numPass;
            LabelSelectedCount.Text = numPass.ToString();
            LabelUnselectedCount.Text = numFail.ToString();
            LabelTotalCount.Text = $"{NullExclude + NullInclude + numPass + numFail}";
            return new double[] { numPass + NullInclude, numFail + NullExclude };
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            Feature.CriteriaString = TxtCriteriaString.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnIgnoreFeature_Click(object sender, EventArgs e)
        {
            Feature.CriteriaString = TxtCriteriaString.Text;
            DialogResult = DialogResult.Ignore;
            Close();
        }
    }
}
