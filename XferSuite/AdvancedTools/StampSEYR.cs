using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.AdvancedTools
{
    public partial class StampSEYR : Form
    {
        struct Entry
        {
            public double X;
            public double Y;
            public int PostCount;
            public int PostDebris;
            public int MesaDebris;
        }

        private FileInfo FileInfo = null;
        private List<Entry> Data = new List<Entry>();
        private int MaxPostCount = 1;
        private int[] Counts = new int[3];

        public StampSEYR()
        {
            InitializeComponent();
            foreach (FormsPlot p in TLP.Controls.OfType<FormsPlot>())
                p.Plot.Grid(false);
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Select a file for filtering";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo = new FileInfo(openFileDialog.FileName);
                    LoadData();
                }
            }
        }

        private void LoadData()
        {
            string[] lines = File.ReadAllLines(FileInfo.FullName);
            if (lines[0] != "ImageNumber\tX\tY\tRR\tRC\tR\tC\tSR\tSC\tNumPosts\tPxPostDebris\tPxMesaDebris")
            {
                MessageBox.Show("This file is not currently supported by this feature", "XferSuite Advanced Tools");
                return;
            }
            Counts = new int[3];
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i])) continue;
                string[] cols = lines[i].Split('\t');
                int pc = int.Parse(cols[cols.Length - 3]);
                int pd = int.Parse(cols[cols.Length - 2]);
                int md = int.Parse(cols[cols.Length - 1]);
                Data.Add(new Entry()
                {
                    X = double.Parse(cols[1]),
                    Y = double.Parse(cols[2]),
                    PostCount = pc,
                    PostDebris = pd,
                    MesaDebris = md,
                });
                if (pc > MaxPostCount) MaxPostCount = pc;
                Counts[0] += pc;
                Counts[1] += pd;
                Counts[2] += md;
            }
            Data = Data.OrderBy(x => x.X).OrderBy(x => x.Y).ToList();
            PlotAll();
        }

        private void CbxFlipX_CheckedChanged(object sender, EventArgs e)
        {
            PlotAll();
        }

        private void CbxFlipY_CheckedChanged(object sender, EventArgs e)
        {
            PlotAll();
        }

        private void NumPostsX_ValueChanged(object sender, EventArgs e)
        {
            PlotAll();
        }

        private void NumPostsY_ValueChanged(object sender, EventArgs e)
        {
            PlotAll();
        }

        private void PlotAll()
        {
            foreach (FormsPlot p in TLP.Controls.OfType<FormsPlot>())
            {
                int col = TLP.GetColumn(p);
                p.Plot.Clear();
                p.Plot.AddHeatmap(GetDataArr(col), lockScales: false);
                p.Plot.Margins(0, 0);
                p.PerformAutoScale();
                p.Refresh();
            }
            LblPostCount.Text = $"Post Count = {Counts[0]}";
            LblPostDebris.Text = $"Post Debris = {Counts[1]:#.##E+0} px";
            LblMesaDebris.Text = $"Mesa Debris = {Counts[2]:#.##E+0} px";
        }

        private double?[,] GetDataArr(int idx)
        {
            int d = 0;
            double?[,] output = new double?[(int)NumPostsX.Value, (int)NumPostsY.Value];
            if (Data.Count >= NumPostsX.Value * NumPostsY.Value)
            {
                for (int i = 0; i < NumPostsX.Value; i++)
                {
                    for (int j = 0; j < NumPostsY.Value; j++)
                    {
                        double? data = null;
                        double val = 0;
                        switch (idx)
                        {
                            case 0:
                                val = Data[d].PostCount;
                                break;
                            case 1:
                                val = Data[d].PostDebris;
                                break;
                            case 2:
                                val = Data[d].MesaDebris;
                                break;
                            case 3:
                                val = Data[d].PostDebris * 100 + Data[d].MesaDebris;
                                break;
                            default:
                                break;
                        }
                        if (val > 0) data = val;
                        output[i, j] = data;
                        d++;
                    }
                }
            }
            if (d == 0) return new double?[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            return output;
        }

        private void BtnCopyWindow_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            DrawToBitmap(b, new Rectangle(0, 0, Width, Height));
            Clipboard.SetImage(b);
        }
    }
}
