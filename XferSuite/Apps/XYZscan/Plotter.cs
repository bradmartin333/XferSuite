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

        private string Path { get; set; }
        private List<Scan> Scans { get; set; } = new List<Scan>();
        private FormsPlot[] Plots { get; set; }
        private ToolStripComboBox[] ComboBoxes { get; set; }
        public Plotter(string filePath)
        {
            InitializeComponent();
            olv.SelectionChanged += Olv_SelectionChanged;
            Plots = new FormsPlot[] { pA, pB, pC, pD };
            ComboBoxes = new ToolStripComboBox[] { comboX, comboY, comboZ };
            foreach (ToolStripComboBox comboBox in ComboBoxes)
            {
                comboBox.SelectedIndex = 0;
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
                for (int i = 0; i < olv.SelectedObjects.Count; i++)
                {
                    Scan scan = (Scan)olv.SelectedObjects[i];
                    if (scan.Data.Count > 3) CreatePlot(Plots[i], scan);
                }
            }
            else
            {
                olv.DeselectAll();
            }
        }

        private void CreatePlot(FormsPlot formsPlot, Scan scan)
        {
            formsPlot.Plot.Clear();
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
            if (toolStripButtonFlipX.Checked) FlipAxis(ref xAxisData);
            if (toolStripButtonFlipY.Checked) FlipAxis(ref yAxisData);
            if (toolStripButtonFlipZ.Checked) FlipAxis(ref zAxisData);
            UpdateToolbars(new double[][] { xAxisData, yAxisData, zAxisData });

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
                        var cmap = ScottPlot.Drawing.Colormap.Viridis;
                        var cb = formsPlot.Plot.AddColorbar(cmap);
                        double maxH = zAxisData.Max();
                        var ticksInfo = Zed.getTicks(zAxisData);
                        cb.AddTicks(ticksInfo.Item1, ticksInfo.Item2);
                        for (int i = 0; i < data.Length; i++)
                        {
                            double colorFraction = zAxisData[i] / maxH;
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
        }

        private void FlipAxis(ref double[] data)
        {
            double max = data.Max();
            for (int i = 0; i < data.Length; i++)
                data[i] = Math.Abs(data[i] - max);
        }

        private void UpdateToolbars(double[][] data)
        {
            for (int i = 0; i < 3; i++)
            {
                if (data[i].Length > 3)
                {
                    double min = Math.Round(data[i].Min(), 3);
                    double max = Math.Round(data[i].Max(), 3);
                    switch (i)
                    {
                        case 0:
                            toolStripTextBoxMinX.Text = min.ToString();
                            toolStripTextBoxMaxX.Text = max.ToString();
                            break;
                        case 1:
                            toolStripTextBoxMinY.Text = min.ToString();
                            toolStripTextBoxMaxY.Text = max.ToString();
                            break;
                        case 2:
                            toolStripTextBoxMinZ.Text = min.ToString();
                            toolStripTextBoxMaxZ.Text = max.ToString();
                            break;
                    }
                }
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

        private void toolStripButtonFlip_Click(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            if (!button.Checked)
            {
                button.BackColor = System.Drawing.Color.LightGreen;
                button.Checked = true;
            }            
            else
            {
                button.BackColor = System.Drawing.SystemColors.Control;
                button.Checked = false;
            }
            MakePlots();
        }
    }
}
