using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class Plotter : Form
    {
        #region Globals
        public bool RemoveAngle { get; set; } = true;
        public bool FlipX { get; set; } = false;
        public bool FlipY { get; set; } = false;
        public bool FlipZ { get; set; } = false;
        private string Path { get; set; }
        private List<Scan> Scans { get; set; } = new List<Scan>();
        private FormsPlot[] Plots { get; set; }
        private ToolStripComboBox[] ComboBoxes { get; set; }
        private ToolStripLabel[] toolStripLabels { get; set; }
        private double[] CustomAxes { get; set; } = new double[6];

        #endregion

        public Plotter(string filePath)
        {
            InitializeComponent();
            olv.SelectionChanged += Olv_SelectionChanged;

            Plots = new FormsPlot[] { pA, pB, pC, pD };
            foreach (FormsPlot p in Plots)
                p.Plot.Grid(false);

            ComboBoxes = new ToolStripComboBox[] { comboX, comboY, comboZ };
            foreach (ToolStripComboBox comboBox in ComboBoxes)
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            toolStripLabels = new ToolStripLabel[] { numX, numY, numZ };

            ToolTip removeAngleTip = new ToolTip();
            removeAngleTip.SetToolTip(checkBoxRemoveAngle, 
"Remove Level:\n" +
"When checked, the best fit plane of height data is removed\n" +
"This corrects for chuck level\n" +
"The best fit plane is removed twice when using custom axes on height data");

            Path = filePath;
            Show();
            MakeList();
        }

        #region Log Parsing

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

        #endregion

        #region Plot Selection

        private void Olv_SelectionChanged(object sender, EventArgs e)
        {
            MakePlots();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboX.SelectedIndex < 1)
            {
                toolStripY.Enabled = false;
                comboY.SelectedIndex = 0;
            }
            if (comboY.SelectedIndex < 1)
            {
                toolStripZ.Enabled = false;
                comboZ.SelectedIndex = 0;
            }
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
                    ClearAxisLabels(Plots[i].Plot);
                    Plots[i].Refresh();
                }
                UpdateToolbars(bounds);
            }
            else
            {
                olv.DeselectAll();
            }
        }

        #endregion

        #region Plotting

        private double[] CreatePlot(FormsPlot formsPlot, Scan scan)
        {
            formsPlot.Plot.Clear();
            ClearAxisLabels(formsPlot.Plot);

            Zed.Position[] data = (Zed.Position[])scan.Data.ToArray().Clone();
            double numPoints = data.Length;
            if (CustomAxes.Sum() != 0)
            {
                try
                {
                    data = Zed.filterData(data, comboX.SelectedIndex, CustomAxes[0], CustomAxes[1]);
                    if (data.Length != numPoints) numX.Text = (data.Length / numPoints).ToString("P", CultureInfo.InvariantCulture);
                    numPoints = data.Length;
                    data = Zed.filterData(data, comboY.SelectedIndex, CustomAxes[2], CustomAxes[3]);
                    if (data.Length != numPoints) numY.Text = (data.Length / numPoints).ToString("P", CultureInfo.InvariantCulture);
                    numPoints = data.Length;
                    data = Zed.filterData(data, comboZ.SelectedIndex, CustomAxes[4], CustomAxes[5]);
                    if (data.Length != numPoints) numZ.Text = (data.Length / numPoints).ToString("P", CultureInfo.InvariantCulture);
                    numPoints = data.Length;
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid custom axes", "XferSuite");
                }
            }
            else
            {
                foreach (ToolStripLabel label in toolStripLabels)
                    label.Text = "";
            }

            if (3 > data.Length)
            {
                MessageBox.Show("Insufficient data.", "XferSuite");
                return new double[6];
            }

            Zed.Plane plane = Zed.getPlane(data);
            for (int i = 0; i < data.Length; i++)
            {
                Zed.Position p = data[i];
                data[i] = new Zed.Position(p.Time, p.X, p.Y, p.Z, 
                    RemoveAngle ? p.H - Zed.projectPlane(plane, Zed.posToVec3(data[i])).Z : p.H, 
                    p.I);
            }

            foreach (ToolStripComboBox comboBox in ComboBoxes)
            {
                if (comboBox.SelectedIndex == 4 || comboBox.SelectedIndex == 6)
                {
                    int idx = int.Parse(comboBox.Tag.ToString());
                    if (CustomAxes[idx * 2] != 0 || CustomAxes[(idx * 2) + 1] != 0)
                    {
                        data = data.Where(x => (idx == 6 ? x.Z : 0.0) + x.H >= CustomAxes[idx * 2] &&
                            CustomAxes[(idx * 2) + 1] > (idx == 6 ? x.Z : 0.0) + x.H).ToArray();
                        if (data.Length != numPoints)
                        {
                            toolStripLabels[idx].Text = (data.Length / numPoints).ToString("P", CultureInfo.InvariantCulture);
                            Zed.Plane plane2 = Zed.getPlane(data);
                            for (int i = 0; i < data.Length; i++)
                            {
                                Zed.Position p = data[i];
                                data[i] = new Zed.Position(p.Time, p.X, p.Y, p.Z,
                                    RemoveAngle ? p.H - Zed.projectPlane(plane2, Zed.posToVec3(data[i])).Z : p.H,
                                    p.I);
                            }
                        }    
                    }
                }
            }

            if (3 > data.Length)
            {
                MessageBox.Show("Insufficient data.", "XferSuite");
                return new double[6];
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

            try
            {
                switch (numAxes)
                {
                    case 0:
                        break;
                    case 1:
                        (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(xAxisData, min: xAxisData.Min(), max: xAxisData.Max(), binSize: 1);
                        double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();
                        var bar = formsPlot.Plot.AddBar(values: counts, positions: leftEdges);
                        bar.BarWidth = 1;
                        formsPlot.Plot.XAxis.Label(comboX.Text);
                        formsPlot.Plot.YAxis.Label("Count (#)");
                        formsPlot.Plot.SetAxisLimits(yMin: 0);
                        formsPlot.Plot.Title(
                            $"{scan.Name}\nRange: {Math.Round(xAxisData.Max() - xAxisData.Min(), 3)}   3Sigma = { Zed.threeSigma(xAxisData)}", false);
                        break;
                    case 2:
                        formsPlot.Plot.AddScatterPoints(xAxisData, yAxisData);
                        formsPlot.Plot.XAxis.Label(comboX.Text);
                        formsPlot.Plot.YAxis.Label(comboY.Text);
                        formsPlot.Plot.Title(
                                $"{scan.Name}\nRange: {Math.Round(yAxisData.Max() - yAxisData.Min(), 3)}   3Sigma = { Zed.threeSigma(yAxisData)}", false);
                        break;
                    case 3:
                        double minH = zAxisData.Min();
                        double maxH = zAxisData.Max();
                        for (int i = 0; i < data.Length; i++)
                        {
                            double colorFraction = (zAxisData[i] - minH) / (maxH - minH);
                            if (colorFraction > 1) colorFraction = maxH / zAxisData[i];
                            Color c = ScottPlot.Drawing.Colormap.Viridis.GetColor(colorFraction);
                            formsPlot.Plot.AddPoint(xAxisData[i], yAxisData[i], c);
                        }
                        formsPlot.Plot.XAxis.Label(comboX.Text);
                        formsPlot.Plot.YAxis.Label(comboY.Text);
                        formsPlot.Plot.Title(
                            $"{scan.Name}\nRange: {Math.Round(zAxisData.Max() - zAxisData.Min(), 3)}   3Sigma = { Zed.threeSigma(zAxisData)}", false);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                var msg = formsPlot.Plot.AddAnnotation("Insufficient Data", 10, 10);
                msg.Font.Size = 24;
                msg.Shadow = false;
                msg.BackgroundColor = Color.Transparent;
                msg.BorderColor = Color.Transparent;
                formsPlot.Plot.Title(
                    $"{scan.Name}\nRange: N/A   3Sigma = N/A", false);
            }

            return new double[] {xAxisData.Min(), xAxisData.Max(), yAxisData.Min(), yAxisData.Max(), zAxisData.Min(), zAxisData.Max()};
        }

        private void UpdateToolbars(List<double[]> bounds)
        {
            double[] groupBounds = new double[] { double.MaxValue, double.MinValue, double.MaxValue, double.MinValue, double.MaxValue, double.MinValue };
            for (int i = 0; i < bounds.Count; i++)
            {
                for (int j = 0; j < groupBounds.Length; j += 2)
                {
                    if (bounds[i][j] != 0.0 || bounds[i][j + 1] != 0.0)
                    {
                        if (bounds[i][j] < groupBounds[j]) groupBounds[j] = bounds[i][j];
                        if (bounds[i][j + 1] > groupBounds[j + 1]) groupBounds[j + 1] = bounds[i][j + 1];
                    }
                }
            }
            for (int i = 0; i < groupBounds.Length; i += 2)
            {
                string min = "N/A";
                string max = "N/A";
                if (groupBounds[i] != double.MaxValue && groupBounds[i + 1] != double.MinValue)
                {
                    min = Math.Round(groupBounds[i], 3).ToString();
                    max = Math.Round(groupBounds[i + 1], 3).ToString();
                }
                switch (i/2)
                {
                    case 0:
                        toolStripLabelMinX.Text = min;
                        toolStripLabelMaxX.Text = max;
                        break;
                    case 1:
                        toolStripLabelMinY.Text = min;
                        toolStripLabelMaxY.Text = max;
                        break;
                    case 2:
                        toolStripLabelMinZ.Text = min;
                        toolStripLabelMaxZ.Text = max;
                        break;
                    default:
                        break;
                }
            }

            int numAxes = 0;
            foreach (ToolStripComboBox cbx in ComboBoxes)
                if (cbx.SelectedIndex > 0) numAxes++;

            for (int i = 0; i < groupBounds.Length; i += 2)
            {
                groupBounds[i] = groupBounds[i];
                groupBounds[i + 1] = groupBounds[i + 1];
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
                        cb.YAxisIndex = i;
                        Plots[i].Plot.YAxis2.Label(comboZ.Text);
                        cb.MinValue = groupBounds[4];
                        cb.MaxValue = groupBounds[5];
                        break;
                    default:
                        break;
                }

                try
                {
                    Plots[i].Refresh();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
        }

        private void ClearAxisLabels(Plot plot)
        {
            plot.XAxis.Label("");
            plot.YAxis.Label("");
            plot.YAxis2.Label("");
        }

        #endregion

        #region Plot Customization

        private void CustomizeAxis(int axis)
        {
            double min = 0.0;
            double max = 0.0;
            bool parseMin = false;
            bool parseMax = false;
            switch (axis)
            {
                case 0:
                    if (comboX.SelectedIndex > 0)
                    {
                        parseMin = double.TryParse(toolStripTextBoxCustomMinX.Text, out min);
                        parseMax = double.TryParse(toolStripTextBoxCustomMaxX.Text, out max);
                    }
                    if (toolStripTextBoxCustomMinX.Text == "") parseMin = true;
                    if (toolStripTextBoxCustomMaxX.Text == "") parseMax = true;
                    break;
                case 1:
                    if (comboY.SelectedIndex > 0)
                    {
                        parseMin = double.TryParse(toolStripTextBoxCustomMinY.Text, out min);
                        parseMax = double.TryParse(toolStripTextBoxCustomMaxY.Text, out max);
                    }
                    if (toolStripTextBoxCustomMinY.Text == "") parseMin = true;
                    if (toolStripTextBoxCustomMaxY.Text == "") parseMax = true;
                    break;
                case 2:
                    if (comboZ.SelectedIndex > 0)
                    {
                        parseMin = double.TryParse(toolStripTextBoxCustomMinZ.Text, out min);
                        parseMax = double.TryParse(toolStripTextBoxCustomMaxZ.Text, out max);
                    }
                    if (toolStripTextBoxCustomMinZ.Text == "") parseMin = true;
                    if (toolStripTextBoxCustomMaxZ.Text == "") parseMax = true;
                    break;
            }
            if (parseMin && parseMax)
            {
                CustomAxes[axis * 2] = min;
                CustomAxes[(axis * 2) + 1] = max;
                MakePlots();
            }
            else
            {
                MessageBox.Show("An axis must be selected and the min and max must be valid numbers.", "XferSuite");
            }
        }

        private void toolStripButtonApply_Click(object sender, EventArgs e)
        {
            CustomizeAxis(int.Parse(((ToolStripButton)sender).Tag.ToString()));
        }

        private void toolStripButtonResetX_Click(object sender, EventArgs e)
        {
            toolStripTextBoxCustomMinX.Text = "";
            toolStripTextBoxCustomMaxX.Text = "";
            CustomizeAxis(0);
        }

        private void toolStripButtonResetY_Click(object sender, EventArgs e)
        {
            toolStripTextBoxCustomMinY.Text = "";
            toolStripTextBoxCustomMaxY.Text = "";
            CustomizeAxis(1);
        }

        private void toolStripButtonResetZ_Click(object sender, EventArgs e)
        {
            toolStripTextBoxCustomMinZ.Text = "";
            toolStripTextBoxCustomMaxZ.Text = "";
            CustomizeAxis(2);
        }
        private void FlipAxis(ref double[] data)
        {
            double max = data.Max();
            double min = data.Min();
            for (int i = 0; i < data.Length; i++)
                data[i] = Math.Abs(data[i] - max) - min;
        }

        private void toolStripButtonFlipX_Click(object sender, EventArgs e)
        {
            FlipX = !FlipX;
            ((ToolStripButton)sender).BackColor = FlipX ? Color.LightGreen : SystemColors.Control;
            MakePlots();
        }

        private void toolStripButtonFlipY_Click(object sender, EventArgs e)
        {
            FlipY = !FlipY;
            ((ToolStripButton)sender).BackColor = FlipY ? Color.LightGreen : SystemColors.Control;
            MakePlots();
        }

        private void toolStripButtonFlipZ_Click(object sender, EventArgs e)
        {
            FlipZ = !FlipZ;
            ((ToolStripButton)sender).BackColor = FlipZ ? Color.LightGreen : SystemColors.Control;
            MakePlots();
        }

        private void checkBoxRemoveAngle_CheckedChanged(object sender, EventArgs e)
        {
            RemoveAngle = !RemoveAngle;
            MakePlots();
        }

        #endregion
    }
}
