using BrightIdeasSoftware;
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

        public Plotter(string filePath)
        {
            InitializeComponent();
            olv.SelectionChanged += Olv_SelectionChanged;
            Plots = new FormsPlot[] { pA, pB, pC, pD };
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
            FastDataListView olv = (FastDataListView)sender;
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
            var cmap = ScottPlot.Drawing.Colormap.Viridis;
            formsPlot.Plot.AddColorbar(cmap);
            double maxH = scan.Data.Select(x => x.H).Max();
            foreach (XferHelper.Zed.Position p in scan.Data)
            {
                double colorFraction = p.H / maxH;
                System.Drawing.Color c = ScottPlot.Drawing.Colormap.Viridis.GetColor(colorFraction);
                formsPlot.Plot.AddPoint(p.X, p.Y, c);
            }
            formsPlot.Refresh();
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
