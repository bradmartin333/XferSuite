using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class Plotter : Form
    {
        private bool _RemoveAngle = true;
        [Category("User Parameters")]
        public bool RemoveAngle
        {
            get => _RemoveAngle;
            set
            {
                _RemoveAngle = value;
                MakePlots();
            }
        }

        public bool FlipX { get; set; } = false;
        public bool FlipY { get; set; } = false;
        public bool FlipZ { get; set; } = false;
        private string Path { get; set; }
        private List<Scan> Scans { get; set; } = new List<Scan>();
        private FormsPlot[] Plots { get; set; }
        private ToolStripComboBox[] ComboBoxes { get; set; }

        public Plotter(string filePath)
        {
            InitializeComponent();
            olv.SelectionChanged += Olv_SelectionChanged;
            Plots = new FormsPlot[] { pA, pB, pC, pD };
            foreach (FormsPlot p in Plots)
                p.Plot.Grid(false);
            ComboBoxes = new ToolStripComboBox[] { comboX, comboY, comboZ };
            foreach (ToolStripComboBox comboBox in ComboBoxes)
            {
                comboBox.SelectedIndex = int.Parse(comboBox.Tag.ToString());
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
            Path = filePath;
            Show();
            MakeList();
        }

        private void MakeList()
        {
            ProgressBar.Style = ProgressBarStyle.Marquee;
            ProgressBar.MarqueeAnimationSpeed = 100;

            FindScans();
            olv.SetObjects(Scans);
            olv.Sort(OlvColumn6, SortOrder.Descending);

            ProgressBar.Style = ProgressBarStyle.Continuous;
            ProgressBar.MarqueeAnimationSpeed = 0;
        }

        private void Olv_SelectionChanged(object sender, EventArgs e)
        {
            MakePlots();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripY.Enabled = comboX.SelectedIndex > 0;
            toolStripZ.Enabled = comboY.SelectedIndex > 0;
            MakePlots();
        }

        private void MakePlots()
        {
            if (olv.SelectedIndices.Count <= 4)
            {
                List<double[]> bounds = new List<double[]> ();
                for (int i = 0; i < olv.SelectedObjects.Count; i++)
                {
                    Scan scan = (Scan)olv.SelectedObjects[i];
                    if (scan.Data.Count > 3) bounds.Add(CreatePlot(Plots[i], scan));
                }
                for (int i = olv.SelectedObjects.Count; i < Plots.Length; i++)
                {
                    Plots[i].Plot.Clear();
                    Plots[i].Plot.Title("");
                    Plots[i].Plot.YAxis.Label();
                    Plots[i].Refresh();
                }
                UpdateToolbars(bounds);
            }
            else
            {
                olv.DeselectAll();
            }
        }

        private double[] CreatePlot(FormsPlot formsPlot, Scan scan)
        {
            formsPlot.Plot.Clear();
            formsPlot.Plot.YAxis.Label();

            Zed.Position[] data = new Zed.Position[scan.Data.Count];
            Zed.Plane plane = Zed.getPlane(scan.Data.ToArray());
            for (int i = 0; i < data.Length; i++)
            {
                Zed.Position p = scan.Data[i];
                data[i] = new Zed.Position(p.Time, p.X, p.Y, p.Z, 
                    _RemoveAngle ? p.H - Zed.projectPlane(plane, Zed.posToVec3(scan.Data[i])).Z : p.H, 
                    p.I);
            }

            double[] xAxisData = Zed.getAxis(data, comboX.SelectedIndex);
            double[] yAxisData = Zed.getAxis(data, comboY.SelectedIndex);
            double[] zAxisData = Zed.getAxis(data, comboZ.SelectedIndex);
            if (FlipX) FlipAxis(ref xAxisData);
            if (FlipY) FlipAxis(ref yAxisData);
            if (FlipZ) FlipAxis(ref zAxisData);
            int numAxes = 0;
            foreach (ToolStripComboBox cbx in ComboBoxes)
                if (cbx.SelectedIndex > 0) numAxes++;

            switch (numAxes)
            {
                case 0:
                    break;
                case 1:
                    try
                    {
                        (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(xAxisData, min: xAxisData.Min(), max: xAxisData.Max(), binSize: 1);
                        double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();
                        var bar = formsPlot.Plot.AddBar(values: counts, positions: leftEdges);
                        bar.BarWidth = 1;
                        formsPlot.Plot.YAxis.Label("Count (#)");
                        formsPlot.Plot.SetAxisLimits(yMin: 0);
                        formsPlot.Plot.Title(
                            $"{scan.Name}\nRange: {Math.Round(xAxisData.Max() - xAxisData.Min(), 3)}   3Sigma = { Zed.threeSigma(xAxisData)}", false);
                    }
                    catch (Exception) { }
                    break;
                case 2:
                    formsPlot.Plot.AddScatterPoints(xAxisData, yAxisData);
                    formsPlot.Plot.Title(
                            $"{scan.Name}\nRange: {Math.Round(yAxisData.Max() - yAxisData.Min(), 3)}   3Sigma = { Zed.threeSigma(yAxisData)}", false);
                    break;
                case 3:
                    try
                    {
                        double minH = zAxisData.Min();
                        double maxH = zAxisData.Max();
                        for (int i = 0; i < data.Length; i++)
                        {
                            double colorFraction = (zAxisData[i] - minH) / (maxH - minH);
                            if (colorFraction > 1) colorFraction = maxH / zAxisData[i];
                            System.Drawing.Color c = ScottPlot.Drawing.Colormap.Viridis.GetColor(colorFraction);
                            formsPlot.Plot.AddPoint(xAxisData[i], yAxisData[i], c);
                        }
                        formsPlot.Plot.Title(
                            $"{scan.Name}\nRange: {Math.Round(zAxisData.Max() - zAxisData.Min(), 3)}   3Sigma = { Zed.threeSigma(zAxisData)}", false);
                    }
                    catch (Exception) { }
                    break;
                default:
                    break;
            }

            formsPlot.Refresh();
            return new double[] {xAxisData.Min(), xAxisData.Max(), yAxisData.Min(), yAxisData.Max(), zAxisData.Min(), zAxisData.Max()};
        }

        private void FlipAxis(ref double[] data)
        {
            double max = data.Max();
            for (int i = 0; i < data.Length; i++)
                data[i] = Math.Abs(data[i] - max);
        }

        private void UpdateToolbars(List<double[]> bounds)
        {
            double[] groupBounds = new double[] { double.MaxValue, double.MinValue, double.MaxValue, double.MinValue, double.MaxValue, double.MinValue };
            for (int i = 0; i < bounds.Count; i++)
            {
                for (int j = 0; j < groupBounds.Length; j += 2)
                {
                    if (bounds[i][j] != 0.0 && bounds[i][j + 1] != 0.0)
                    {
                        if (bounds[i][j] < groupBounds[j]) groupBounds[j] = bounds[i][j];
                        if (bounds[i][j + 1] > groupBounds[j + 1]) groupBounds[j + 1] = bounds[i][j + 1];
                    }
                }
            }
            for (int i = 0; i < groupBounds.Length; i += 2)
            {
                if (groupBounds[i] != double.MaxValue && groupBounds[i + 1] != double.MinValue)
                {
                    switch (i/2)
                    {
                        case 0:
                            toolStripTextBoxMinX.Text = Math.Round(groupBounds[i], 3).ToString();
                            toolStripTextBoxMaxX.Text = Math.Round(groupBounds[i + 1], 3).ToString();
                            break;
                        case 1:
                            toolStripTextBoxMinY.Text = Math.Round(groupBounds[i], 3).ToString();
                            toolStripTextBoxMaxY.Text = Math.Round(groupBounds[i + 1], 3).ToString();
                            break;
                        case 2:
                            toolStripTextBoxMinZ.Text = Math.Round(groupBounds[i], 3).ToString();
                            toolStripTextBoxMaxZ.Text = Math.Round(groupBounds[i + 1], 3).ToString();
                            break;
                        default:
                            break;
                    }
                }
            }

            int numAxes = 0;
            foreach (ToolStripComboBox cbx in ComboBoxes)
                if (cbx.SelectedIndex > 0) numAxes++;

            for (int i = 0; i < groupBounds.Length; i += 2)
            {
                groupBounds[i] = groupBounds[i] * 0.99;
                groupBounds[i + 1] = groupBounds[i + 1] * 1.01;
            }

            for (int i = 0; i < olv.SelectedObjects.Count; i++)
            {
                switch (numAxes)
                {
                    case 0:
                        break;
                    case 1:
                        Plots[i].Plot.SetAxisLimitsX(groupBounds[0], groupBounds[1]);
                        break;
                    case 2:
                        Plots[i].Plot.SetAxisLimits(groupBounds[0], groupBounds[1], groupBounds[2], groupBounds[3]);
                        break;
                    case 3:
                        Plots[i].Plot.SetAxisLimits(groupBounds[0], groupBounds[1], groupBounds[2], groupBounds[3]);
                        var cmap = ScottPlot.Drawing.Colormap.Viridis;
                        var cb = Plots[i].Plot.AddColorbar(cmap);
                        cb.MinValue = groupBounds[4];
                        cb.MaxValue = groupBounds[5];
                        break;
                    default:
                        break;
                }

                Plots[i].Refresh();
            }
        }

        private void FindScans()
        {
            Scans.Clear();
            int scanIdx = -1;
            StreamReader reader = new StreamReader(Path);
            while (reader.Peek() != -1)
            {
                Application.DoEvents();
                var line = reader.ReadLine();
                _ = reader.Peek();
                if (line.Contains("NEWSCAN"))
                {
                    scanIdx += 1;
                    var info = line.Split('\t');
                    var thisScan = new Scan()
                    {
                        Index = scanIdx + 1,
                        ShortDate = DateTime.Parse(info[0]).ToShortDateString(),
                        Time = DateTime.Parse(info[0]).ToShortTimeString(),
                        Name = info[2]
                    };
                    if (info.Length > 3)
                    {
                        thisScan.Temp = double.Parse(info[3]);
                        thisScan.RH = double.Parse(info[4]);
                    }
                    if (info.Length > 5)
                    {
                        thisScan.ScanSpeed = int.Parse(info[5]);
                        thisScan.NumPasses = int.Parse(info[6]);
                        thisScan.Threshold = int.Parse(info[7]);
                    }
                    Scans.Add(thisScan);
                }
                else
                    try
                    {
                        Scans[scanIdx].Data.Add(Zed.toPosition(line));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(text: $"Invalid File: {ex}", caption: "XYZscan");
                        return;
                    }
            }
        }

        private void toolStripButtonApply_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButtonFlipX_Click(object sender, EventArgs e)
        {
            FlipX = !FlipX;
            ((ToolStripButton)sender).BackColor = FlipX ? System.Drawing.Color.LightGreen : System.Drawing.SystemColors.Control;
            MakePlots();
        }

        private void toolStripButtonFlipY_Click(object sender, EventArgs e)
        {
            FlipY = !FlipY;
            ((ToolStripButton)sender).BackColor = FlipY ? System.Drawing.Color.LightGreen : System.Drawing.SystemColors.Control;
            MakePlots();
        }

        private void toolStripButtonFlipZ_Click(object sender, EventArgs e)
        {
            FlipZ = !FlipZ;
            ((ToolStripButton)sender).BackColor = FlipZ ? System.Drawing.Color.LightGreen : System.Drawing.SystemColors.Control;
            MakePlots();
        }
    }
}
