using System;
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
        private static Font RCFont;
        private static bool YieldBrackets;
        private static int DefaultPlotSize;
        private readonly List<DataEntry> Data;
        private readonly List<DataSheet> Sheets;
        private readonly List<Criteria> Criteria;
        private TableLayoutPanel TLP;
        private List<PictureBox> PictureBoxes;
        private readonly Inspection Inspection;
        private bool LastPF = false;
        private readonly string FileName;
        private readonly ParseSEYR.Delimeter CycleFileDelimeter;
        private readonly Project Project;

        public RegionBrowser(List<DataEntry> data, List<DataSheet> sheets, List<Criteria> criteria, 
            bool showPF, string fileName, ParseSEYR.Delimeter delimeter, Font yieldFont, Font rcFont, bool yieldBrackets, int defaultPlotSize, Project project)
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
            CycleFileDelimeter = delimeter;
            YieldFont = yieldFont;
            RCFont = rcFont;
            YieldBrackets = yieldBrackets;
            DefaultPlotSize = defaultPlotSize;
            Project = project;
            SetupTLP(showPF);
            Show();
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

            var IDs = Sheets.Where(x => !x.Ignore).Select(s => s.ID).ToList();
            var RRs = IDs.Select(id => id.Item1).Distinct();
            var RCs = IDs.Select(id => id.Item2).Distinct();

            int rowMin = RRs.Min();
            int rowMax = RRs.Max();
            int rowRange = rowMax - rowMin + 1;

            int colMin = RCs.Min();
            int colMax = RCs.Max();
            int colRange = colMax - colMin + 1;

            int hgt = (int)Math.Floor(100 / (double)rowRange);
            int wid = (int)Math.Floor(100 / (double)colRange);

            TLP.ColumnStyles.Clear();
            TLP.RowStyles.Clear();
            TLP.ColumnCount = colRange + 2;
            TLP.RowCount = (rowRange * 2) + 2;

            TLP.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // "RC"
            TLP.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // RC val

            int rowIdx = 0;
            int colIdx = 0;

            Size imageSize = Size.Empty;

            for (int i = colMin; i <= colMax; i++)
            {
                TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, wid)); // This column
                for (int j = rowMin; j <= rowMax; j++)
                {
                    if (i == colMin) // New Row
                    {
                        TLP.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        TLP.RowStyles.Add(new RowStyle(SizeType.Percent, hgt));
                        TLP.Controls.Add(TLPLabel(j.ToString()), 1, TLP.RowCount - 2 - ((j - rowMin) * 2) - 1);
                    }
                    
                    DataSheet[] sheets = Sheets.Where(s => s.ID == (j, i) && !s.Ignore).ToArray();
                    if (sheets.Any())
                    {
                        DataSheet sheet = sheets.First();
                        var bmpInfo = sheet.GetBitmap(showPF);
                        PictureBox pictureBox = TLPPictureBox(sheet.ID);
                        PictureBoxes.Add(pictureBox);
                        pictureBox.BackgroundImage = bmpInfo.Item1;
                        if (imageSize.IsEmpty) imageSize = bmpInfo.Item1.Size;
                        Point thisCell = new Point(i - colMin + 2, (-2 * (j - rowMin - rowRange)) - 2);
                        if (showPF) 
                            TLP.Controls.Add(TLPLabel($"{(YieldBrackets ? "┏ " : "")}{bmpInfo.Item2}{(YieldBrackets ? " ┓" : "")}", true), thisCell.X, thisCell.Y);
                        TLP.Controls.Add(pictureBox, thisCell.X, thisCell.Y + 1);
                    }

                    rowIdx++;
                }
                colIdx++;
            }

            TLP.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            TLP.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            for (int i = 1; i < colRange + 1; i++)
                TLP.Controls.Add(TLPLabel(i.ToString()), i + 1, TLP.RowCount - 1);

            Label RRlabel = TLPLabel("RR");
            TLP.Controls.Add(RRlabel, 0, 0);
            TLP.SetRowSpan(RRlabel, TLP.RowCount - 2);

            Label RClabel = TLPLabel("RC");
            TLP.Controls.Add(RClabel, 2, TLP.RowCount);
            TLP.SetColumnSpan(RClabel, colRange);

            SetSize(imageSize, rowRange, colRange);
        }

        private void SetSize(Size imageSize, int rowRange, int colRange)
        {
            double rangeX = imageSize.Width * colRange * Project.PitchX;
            double rangeY = imageSize.Height * rowRange * Project.PitchY;
            Size defaultSize = new Size(DefaultPlotSize, DefaultPlotSize);
            Size scaledSize = defaultSize;
            if (rangeX < rangeY)
                scaledSize = new Size((int)(defaultSize.Width * (rangeX / rangeY)), defaultSize.Height);
            else if (rangeY < rangeX)
                scaledSize = new Size(defaultSize.Width, (int)(defaultSize.Height * (rangeY / rangeX)));
            Size = scaledSize;
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
            lbl.Font = percentage ? YieldFont : RCFont;
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

        private void OpenImage(bool entireImage = false)
        {
            string path = $@"{System.IO.Path.GetTempPath()}RBimg.png";
            if (entireImage)
                GetEntireBitmap().Save(path);
            else
                GetActiveBitmap().Save(path);
            System.Diagnostics.Process.Start(path);
        }

        private void OpenEntireWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage(true);
        }

        private void OpenSelectedRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private Bitmap GetEntireBitmap()
        {
            Bitmap bmp = new Bitmap(TLP.Width, TLP.Height);
            TLP.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            return bmp;
        }

        private void CopyEntireWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(GetEntireBitmap());
        }

        private void CopySelectedRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(GetActiveBitmap());
        }

        private void ToolStripMenuCopyCSV_Click(object sender, EventArgs e)
        {
            string data = GetActiveSheet().GetCSV(Criteria, LastPF);
            string footer = LastPF ? "\n" : ('\n' + string.Join("\n", Criteria.Select(x => $"{x.ID}\t{x.LegendEntry}").ToArray()));
            Clipboard.SetText(data + footer);
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

        private void IgnoreSelectedRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveSheet().Ignore = true;
            Controls.Remove(TLP);
            SetupTLP(LastPF);
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
                Clipboard.SetText(lines);
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
