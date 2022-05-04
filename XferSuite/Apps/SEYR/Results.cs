﻿using ScottPlot.Plottable;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class Results : Form
    {
        private readonly List<DataEntry> Data;
        private readonly ScatterCriteria[] Scatters;
        private readonly List<ScatterPlot> ScatterPlots = new List<ScatterPlot>();
        private MarkerPlot MarkerPlot = null;
        private Bitmap SelectedBitmap = null;
        private bool ShowPassFail = false;

        public Results(List<DataEntry> data, ScatterCriteria[] scatters)
        {
            InitializeComponent();
            Data = data;
            Scatters = scatters;

            FormsPlot.Plot.Palette = ScottPlot.Palette.ColorblindFriendly;
            FormsPlot.Plot.Legend();
            FormsPlot.MouseMove += FormsPlot_MouseMove;
            FormsPlot.LeftClicked += FormsPlot_LeftClicked;

            MakePlot();
            Show();
        }

        private void FormsPlot_MouseMove(object sender, MouseEventArgs e)
        {
            if (!CbxToggleMarker.Checked) return;
            (double x, double y) = FormsPlot.GetMouseCoordinates();
            double min = double.MaxValue;
            double thisX = 0;
            double thisY = 0;
            foreach (ScatterCriteria scatter in Scatters)
                for (int i = 0; i < scatter.X.Count; i++)
                {
                    double hyp = Math.Sqrt((scatter.X[i] - x) * (scatter.X[i] - x) + (scatter.Y[i] - y) * (scatter.Y[i] - y));
                    if (hyp < min)
                    {
                        min = hyp;
                        thisX = scatter.BaseX[i];
                        thisY = scatter.BaseY[i];
                    }
                }

            SelectedBitmap = null;
            DataEntry[] entries = Data.Where(d => d.X == thisX && d.Y == thisY).ToArray();
            foreach (DataEntry entry in entries)
            {
                FormsPlot.Plot.Title($"{entry}", false, size: 12);
                if (entry.Image != null)
                {
                    SelectedBitmap = entry.Image;
                    break;
                }
            } 

            MarkerPlot.X = ParseSEYR.XSign * thisX;
            MarkerPlot.Y = ParseSEYR.YSign * thisY;
            MarkerPlot.Color = SelectedBitmap == null ? Color.Transparent : Color.Gold;
            FormsPlot.Refresh();
        }

        private void FormsPlot_LeftClicked(object sender, EventArgs e)
        {
            if (!CbxToggleMarker.Checked) return;
            FormsPlot.Plot.AddImage(SelectedBitmap, MarkerPlot.X, MarkerPlot.Y);
            FormsPlot.Refresh();
        }

        private void MakePlot()
        {
            ResetUI();
            double someX = 0;
            double someY = 0;
            foreach (ScatterCriteria scatter in Scatters)
            {
                if (scatter.X.Count == 0) continue;
                if (someX == 0) someX = scatter.X[0];
                if (someY == 0) someY = scatter.Y[0];
                ScatterPlot plot = FormsPlot.Plot.AddScatter(
                    scatter.X.ToArray(),
                    scatter.Y.ToArray(),
                    markerShape: ScottPlot.MarkerShape.filledSquare,
                    lineStyle: ScottPlot.LineStyle.None,
                    label: scatter.Name);
                if (scatter.Color != Color.Transparent)
                    plot.Color = scatter.Color;
                else if (ShowPassFail)
                    plot.Color = scatter.Pass ? Color.LawnGreen : Color.Firebrick;
                ScatterPlots.Add(plot);
            }
            MarkerPlot = FormsPlot.Plot.AddMarker(someX, someY, ScottPlot.MarkerShape.filledSquare, color: Color.Transparent);
            SetupCombo();
            SetAxes();
            FormsPlot.Refresh();
        }

        private void ResetUI()
        {
            FormsPlot.Plot.Clear();
            ScatterPlots.Clear();
            FormsPlot.Plot.Title("");
            ComboPropertySelector.Text = "";
            ComboPropertySelector.Items.Clear();
            PropertyGrid.SelectedObject = null;
        }

        private void SetupCombo()
        {
            ComboPropertySelector.Items.AddRange(ScatterPlots.Select(x => x.Label).ToArray());
            ComboPropertySelector.Items.Add("Plot Control");
        }

        private void SetAxes()
        {
            List<double> xPositions = new List<double>();
            List<string> xLabels = new List<string>();
            foreach (var region in Data.GroupBy(x => x.RC))
            {
                DataEntry[] regionData = region.ToArray();
                xPositions.Add(regionData.Select(x => ParseSEYR.XSign * x.X).Average());
                xLabels.Add(region.Key.ToString());
            }
            FormsPlot.Plot.XAxis.ManualTickPositions(xPositions.ToArray(), xLabels.ToArray());

            List<double> yPositions = new List<double>();
            List<string> yLabels = new List<string>();
            foreach (var region in Data.GroupBy(x => x.RR))
            {
                DataEntry[] regionData = region.ToArray();
                yPositions.Add(regionData.Select(x => ParseSEYR.YSign * x.Y).Average());
                yLabels.Add(region.Key.ToString());
            }
            FormsPlot.Plot.YAxis.ManualTickPositions(yPositions.ToArray(), yLabels.ToArray());
        }

        #region UI Elements

        private void CbxToggleMarker_CheckedChanged(object sender, EventArgs e)
        {
            MarkerPlot.IsVisible = CbxToggleMarker.Checked;
            FormsPlot.Plot.Title("");
            FormsPlot.Refresh();
        }

        private void CbxTogglePassFail_CheckedChanged(object sender, EventArgs e)
        {
            ShowPassFail = CbxTogglePassFail.Checked;
            MakePlot();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            MakePlot();
        }

        private void ComboPropertySelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboPropertySelector.Text == "Plot Control")
                PropertyGrid.SelectedObject = FormsPlot;
            else
                PropertyGrid.SelectedObject = ScatterPlots.Where(x => x.Label == ComboPropertySelector.Text).First();
        }

        private void BtnRefreshPlot_Click(object sender, EventArgs e)
        {
            FormsPlot.Plot.Title("");
            FormsPlot.Refresh();
        }

        #endregion
    }
}
