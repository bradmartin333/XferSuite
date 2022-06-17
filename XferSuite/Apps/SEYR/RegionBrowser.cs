﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class RegionBrowser : Form
    {
        private static Font YieldFont;
        private readonly List<DataEntry> Data;
        private readonly List<DataSheet> Sheets;
        private readonly List<Criteria> Criteria;
        private Size ArraySize;
        private TableLayoutPanel TLP;
        private List<PictureBox> PictureBoxes;
        private readonly Inspection Inspection;
        private bool LastPF = false;
        private readonly string FileName;
        private readonly ParseSEYR.Delimeter CycleFileDelimeter;

        public RegionBrowser(List<DataEntry> data, List<DataSheet> sheets, List<Criteria> criteria, bool showPF, string fileName, ParseSEYR.Delimeter delimeter, Font yieldFont)
        {
            InitializeComponent();
            FormClosing += RegionBrowser_FormClosing;
            Data = data;
            Sheets = sheets;
            Criteria = criteria;
            KeyDown += RegionBrowser_KeyDown;
            FileName = fileName;
            Inspection = new Inspection(FileName);
            Text = FileName;
            SetupTLP(showPF);
            Show();
            CycleFileDelimeter = delimeter;
            YieldFont = yieldFont;
        }

        private void RegionBrowser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F)
            {
                IEnumerable<ParseSEYR> matches = Application.OpenForms.OfType<ParseSEYR>().Where(x => x.Text == FileName);
                if (matches.Any()) matches.First().BringToFront();
            }
        }

        private void RegionBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.Where(x => x.Form != null).ToList().ForEach(x => x.Form.Close());
            Inspection.Close();
        }

        private void SetupTLP(bool showPF)
        {
            LastPF = showPF;
            TLP = new TableLayoutPanel() { Dock = DockStyle.Fill, };
            Controls.Add(TLP);

            PictureBoxes = new List<PictureBox>();

            var IDs = Sheets.Select(s => s.ID).ToList();
            var RRs = IDs.Select(id => id.Item1).Distinct();
            var RCs = IDs.Select(id => id.Item2).Distinct();
            ArraySize = new Size(RRs.Max(), RCs.Max());

            int hgt = (int)Math.Floor(100 / (double)RRs.Count());
            int wid = (int)Math.Floor(100 / (double)RCs.Count());

            TLP.ColumnStyles.Clear();
            TLP.RowStyles.Clear();
            TLP.ColumnCount = ArraySize.Height + 2;
            TLP.RowCount = (ArraySize.Width * 2) + 2;

            TLP.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            TLP.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            for (int i = 0; i < ArraySize.Height; i++)
            {
                TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, wid));
                for (int j = 0; j < ArraySize.Width; j++)
                {
                    if (i == 0)
                    {
                        TLP.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        TLP.RowStyles.Add(new RowStyle(SizeType.Percent, hgt));
                        TLP.Controls.Add(TLPLabel((j + 1).ToString()), 1, TLP.RowCount - 2 - (j * 2) - 1);
                    }
                    
                    DataSheet[] sheets = Sheets.Where(s => s.ID == (ArraySize.Width - j, i + 1)).ToArray();
                    if (sheets.Any())
                    {
                        DataSheet sheet = sheets.First();
                        var bmpInfo = sheet.GetBitmap(showPF);
                        PictureBox pictureBox = TLPPictureBox(sheet.ID);
                        PictureBoxes.Add(pictureBox);
                        pictureBox.BackgroundImage = bmpInfo.Item1;
                        if (showPF) TLP.Controls.Add(TLPLabel($"┏   {bmpInfo.Item2}   ┓", true), i + 2, j * 2);
                        TLP.Controls.Add(pictureBox, i + 2, (j * 2) + 1);
                    }  
                }
            }

            TLP.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            TLP.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            for (int i = 1; i < ArraySize.Height + 1; i++)
                TLP.Controls.Add(TLPLabel(i.ToString()), i + 1, TLP.RowCount - 1);

            Label RRlabel = TLPLabel("RR");
            TLP.Controls.Add(RRlabel, 0, 0);
            TLP.SetRowSpan(RRlabel, TLP.RowCount - 2);

            Label RClabel = TLPLabel("RC");
            TLP.Controls.Add(RClabel, 2, TLP.RowCount);
            TLP.SetColumnSpan(RClabel, ArraySize.Height);
        }

        private Label TLPLabel(string txt, bool percentage = false)
        {
            Label lbl = new Label()
            {
                Text = txt,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
            };
            if (percentage) lbl.Font = YieldFont;
            return lbl;
        }

        private PictureBox TLPPictureBox((int, int) ID)
        {
            PictureBox pictureBox = new PictureBox()
            {
                Dock = DockStyle.Fill,
                BackgroundImageLayout = ImageLayout.Stretch,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = ID,
                Cursor = Cursors.Cross,
            };
            pictureBox.MouseUp += PictureBox_MouseUp;
            return pictureBox;
        }

        public void TogglePF(bool showPF)
        {
            Controls.Remove(TLP);
            SetupTLP(showPF);
        }

        #region PictureBox Methods

        private void OpenImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            ContextMenuStrip.Tag = ((PictureBox)sender).Tag;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    Point location = StretchMousePos(e.Location);
                    PictureBox thisPBX = GetActivePictureBox();
                    DataSheet thisSheet = GetActiveSheet();
                    HighightPoint(location, thisPBX);
                    (DataEntry[] match, Criteria criterion) = thisSheet.GetLocation(location);
                    if (match != null)
                    {
                        DataEntry[] matches = match.Where(x => x.Image != null).ToArray();
                        if (matches.Any())
                            Inspection.Set(matches, criterion);
                        else
                            Inspection.Hide();
                        Text = match[0].Location();
                    }
                    break;
                case MouseButtons.Right:
                    ContextMenuStrip.Show(((PictureBox)sender).PointToScreen(e.Location));
                    break;
                case MouseButtons.Middle:
                    OpenImage();
                    break;
                default:
                    break;
            }
        }

        private void OpenImage()
        {
            string path = $@"{System.IO.Path.GetTempPath()}RBimg.png";
            GetActiveBitmap().Save(path);
            System.Diagnostics.Process.Start(path);
        }

        private void CopyEntireWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Bitmap bmp = new Bitmap(TLP.Width, TLP.Height))
            {
                TLP.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                Clipboard.SetImage(bmp);
            }
        }

        private void CopySelectedRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(GetActiveBitmap());
        }

        private void ToolStripMenuCopyCSV_Click(object sender, EventArgs e)
        {
            string data = GetActiveSheet().GetCSV(Criteria);
            Clipboard.SetText(data + '\n' + string.Join("\n", Criteria.Select(x => $"{x.ID}\t{x.LegendEntry}").ToArray()));
        }

        private void RenderAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBoxes.ForEach(p => RenderPictureBox(p));
        }

        private void RenderSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenderPictureBox(GetActivePictureBox());
        }

        private void ClickableAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PictureBoxes.ForEach(p => p.BackgroundImage = Sheets.Where(s => s.ID == ((int, int))p.Tag).First().GetBitmap(LastPF).Item1);
        }

        private void ClickableSelectedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetActivePictureBox().BackgroundImage = GetActiveSheet().GetBitmap(LastPF).Item1;
        }

        private void HighightPoint(Point location, PictureBox pictureBox)
        {
            try
            {
                Bitmap bmp = new Bitmap(pictureBox.BackgroundImage.Width, pictureBox.BackgroundImage.Height);
                bmp.SetPixel(location.X, location.Y, Color.HotPink);
                pictureBox.Image = bmp;
            }
            catch (Exception)
            {
                pictureBox.Image = null;
            }
        }

        private Bitmap GetActiveBitmap()
        {
            return (Bitmap)GetActivePictureBox().BackgroundImage;
        }

        private PictureBox GetActivePictureBox()
        {
            foreach (PictureBox pictureBox in PictureBoxes)
                pictureBox.Image = null;
            return PictureBoxes.Where(x => x.Tag == ContextMenuStrip.Tag).First();
        }

        private DataSheet GetActiveSheet()
        {
            return Sheets.Where(x => x.ID == ((int, int))ContextMenuStrip.Tag).First();
        }

        private Point StretchMousePos(Point p)
        {
            PictureBox pictureBox = GetActivePictureBox();
            Size pbx = pictureBox.Size;
            Size img = pictureBox.BackgroundImage.Size;
            return new Point(
                (int)Math.Floor(img.Width * p.X / (double)pbx.Width),
                (int)Math.Floor(img.Height * p.Y / (double)pbx.Height));
        }

        private void RenderPictureBox(PictureBox pictureBox)
        {
            Bitmap newimg = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(newimg))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(pictureBox.BackgroundImage, new Rectangle(Point.Empty, newimg.Size));
            }
            pictureBox.BackgroundImage = newimg;
        }

        #endregion

        #region Cycle File

        private void MakeCycleFileSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeCycleFile(new List<DataSheet>() { GetActiveSheet() });
        }

        private void MakeCycleFileAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeCycleFile(Sheets);
        }

        private void MakeCycleFile(List<DataSheet> sheets)
        {
            Form form = new Form() 
            { 
                Text = "Cycle File", 
                Size = new Size(800,500),
            };
            RichTextBox rtb = new RichTextBox()
            {
                Dock = DockStyle.Fill,
                Text = MakeCycleFileHeader(),
            };
            form.Controls.Add(rtb);
            int idx = 0;
            foreach (DataSheet sheet in sheets)
            {
                string lines = sheet.CreateCycleFile(ref idx);
                ApplyDelimeter(ref lines);
                rtb.Text += lines;
            }
            form.Show();
        }

        private string MakeCycleFileHeader()
        {
            string output = "UniqueID, Pick.WaferID, Pick.RegionRow, Pick.RegionColumn, Pick.Row, Pick.Column, Pick.Index, Place.WaferID, Place.RegionRow, Place.RegionColumn, Place.Row, Place.Column\n";
            ApplyDelimeter(ref output);
            return output;
        }

        private void ApplyDelimeter(ref string txt)
        {
            switch (CycleFileDelimeter)
            {
                case ParseSEYR.Delimeter.Tab:
                    txt = txt.Replace(", ", "\t");
                    break;
                case ParseSEYR.Delimeter.Space:
                    txt = txt.Replace(", ", " ");
                    break;
                case ParseSEYR.Delimeter.Comma:
                default:
                    break;
            }
        }

        #endregion
    }
}
