using ScottPlot.Plottable;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class Results : Form
    {
        private bool ShowPassFail = false;
        private List<DataEntry> Data;
        private readonly ScatterCriteria[] Scatters;
        private MarkerPlot MarkerPlot = null;
        private Bitmap SelectedBitmap = null;

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
            (double x, double y) = FormsPlot.GetMouseCoordinates();
            double min = double.MaxValue;
            double thisX = 0;
            double thisY = 0;
            foreach (ScatterCriteria scatter in Scatters)
            {
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
            }

            SelectedBitmap = null;
            DataEntry[] entries = Data.Where(d => d.X == thisX && d.Y == thisY).ToArray();
            foreach (DataEntry entry in entries)
            {
                if (entry.Image != null)
                {
                    SelectedBitmap = entry.Image;
                    break;
                }
            }

            MarkerPlot.X = -thisX;
            MarkerPlot.Y = thisY;
            MarkerPlot.Color = SelectedBitmap == null ? Color.Transparent : Color.Gold;
            FormsPlot.Refresh();
        }

        private void FormsPlot_LeftClicked(object sender, EventArgs e)
        {
            FormsPlot.Plot.AddImage(SelectedBitmap, MarkerPlot.X, MarkerPlot.Y);
            FormsPlot.Refresh();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            ShowPassFail = checkBox1.Checked;
            MakePlot();
        }

        private void MakePlot()
        {
            FormsPlot.Plot.Clear();
            foreach (ScatterCriteria scatter in Scatters)
            {
                if (scatter.X.Count == 0) continue;
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
            }
            MarkerPlot = FormsPlot.Plot.AddMarker(0, 0, ScottPlot.MarkerShape.filledSquare, color: Color.Transparent);
            FormsPlot.Refresh();
        }
    }
}
