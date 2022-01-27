﻿using BrightIdeasSoftware;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.XYZscan
{
    public partial class Plotter : Form
    {
        public string Path { get; set; }
        public List<Scan> Scans { get; set; } = new List<Scan>();
        public FormsPlot[] Plots { get; set; }
        public ToolStripComboBox[] ComboBoxes { get; set; }

        public Plotter(string filePath)
        {
            InitializeComponent();
            olv.SelectionChanged += Olv_SelectionChanged;
            Plots = new FormsPlot[] { pA, pB, pC, pD };
            ComboBoxes = new ToolStripComboBox[] { comboX, comboY, comboZ };
            Path = filePath;
            Show();
            MakeList();
        }

        public void MakeList()
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
            MakePlots();
        }

        private void MakePlots()
        {
            if (olv.SelectedIndices.Count <= 4)
            {
                for (int i = 0; i < olv.SelectedObjects.Count; i++)
                {
                    CreatePlot(Plots[i], (Scan)olv.SelectedObjects[i]);
                }
            }
        }

        private void CreatePlot(FormsPlot formsPlot, Scan scan)
        {
            formsPlot.Plot.Clear();
            int numAxes = 0;
            foreach (ToolStripComboBox cbx in ComboBoxes)
                if (cbx.SelectedIndex > 0) numAxes++;

            double[] xAxisData = XferHelper.Zed.getAxis(scan.Data.ToArray(), comboX.SelectedIndex);
            double[] yAxisData = XferHelper.Zed.getAxis(scan.Data.ToArray(), comboY.SelectedIndex);
            double[] zAxisData = XferHelper.Zed.getAxis(scan.Data.ToArray(), comboZ.SelectedIndex);

            switch (numAxes)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    var cmap = ScottPlot.Drawing.Colormap.Viridis;
                    var cb = formsPlot.Plot.AddColorbar(cmap);
                    double maxH = zAxisData.Max();
                    var ticksInfo = XferHelper.Zed.getTicks(zAxisData);
                    cb.AddTicks(ticksInfo.Item1, ticksInfo.Item2);
                    for (int i = 0; i < scan.Data.Count; i++)
                    {
                        double colorFraction = zAxisData[i] / maxH;
                        System.Drawing.Color c = ScottPlot.Drawing.Colormap.Viridis.GetColor(colorFraction);
                        formsPlot.Plot.AddPoint(xAxisData[i], yAxisData[i], c);
                    }
                    formsPlot.Refresh();
                    break;
                default:
                    break;
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
                        Scans[scanIdx].Data.Add(XferHelper.Zed.toPosition(line));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(text: $"Invalid File: {ex}", caption: "XYZscan");
                        return;
                    }
            }
        }
    }
}