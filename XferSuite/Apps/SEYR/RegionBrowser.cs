using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class RegionBrowser : Form
    {
        private readonly List<DataEntry> Data;
        private readonly List<DataSheet> Sheets;
        private readonly string LegendStr;
        private Size ArraySize;
        private TableLayoutPanel TLP;
        private List<PictureBox> PictureBoxes;

        public RegionBrowser(List<DataEntry> data, List<DataSheet> sheets, string legendStr)
        {
            InitializeComponent();
            FormClosing += RegionBrowser_FormClosing;
            Data = data;
            Sheets = sheets;
            LegendStr = legendStr;
            SetupTLP();
            Show();
        }

        private void RegionBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.Where(x => x.Form != null).ToList().ForEach(x => x.Form.Close());
        }

        private void SetupTLP(bool showPF = false)
        {
            TLP = new TableLayoutPanel() { Dock = DockStyle.Fill, };
            Controls.Add(TLP);

            PictureBoxes = new List<PictureBox>();

            var IDs = Sheets.Select(s => s.ID).ToList();
            var RRs = IDs.Select(id => id.Item1);
            var RCs = IDs.Select(id => id.Item2);
            ArraySize = new Size(RRs.Max(), RCs.Max());

            int hgt = 100 / RRs.Count();
            int wid = 100 / RCs.Count();

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
                        if (showPF) TLP.Controls.Add(TLPLabel(bmpInfo.Item2), i + 2, j * 2);
                        TLP.Controls.Add(pictureBox, i + 2, j * 2 + 1);
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

        private Label TLPLabel(string txt)
        {
            return new Label()
            {
                Text = txt,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
            };
        }

        private PictureBox TLPPictureBox((int, int) ID)
        {
            PictureBox pictureBox = new PictureBox()
            {
                Dock = DockStyle.Fill,
                BackgroundImageLayout = ImageLayout.Zoom,
                Tag = ID,
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

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    ContextMenuStrip.Tag = ((PictureBox)sender).Tag;
                    DataEntry data = GetActiveSheet().GetLocation(ContextMenuStrip.Tag, ZoomMousePos(e.Location));
                    DataEntry[] matches = Data.Where(x => x.ImageMatch(data)).Where(x => x.Image != null).ToArray();
                    Text = data.Location();
                    if (matches.Any()) matches[0].ShowImage();
                    break;
                case MouseButtons.Right:
                    ContextMenuStrip.Tag = ((PictureBox)sender).Tag;
                    ContextMenuStrip.Show(((PictureBox)sender).PointToScreen(e.Location));
                    break;
                default:
                    break;
            }
        }

        private void CopyEntireWindowToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Rectangle bounds = Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                Clipboard.SetImage(bitmap);
            }
        }

        private void CopySelectedRegionToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetImage(GetActiveBitmap());
        }

        private void ToolStripMenuCopyCSV_Click(object sender, System.EventArgs e)
        {
            string data = GetActiveSheet().GetCSV();
            Clipboard.SetText(data + LegendStr);
        }

        private Bitmap GetActiveBitmap()
        {
            return (Bitmap)GetActivePictureBox().BackgroundImage;
        }

        private PictureBox GetActivePictureBox()
        {
            return PictureBoxes.Where(x => x.Tag == ContextMenuStrip.Tag).First();
        }

        private DataSheet GetActiveSheet()
        {
            return Sheets.Where(x => x.ID == ((int, int))ContextMenuStrip.Tag).First();
        }

        /// <summary>
        /// Method for adjusting mouse pos to pictureBox set to Zoom
        /// </summary>
        /// <param name="click">
        /// Mouse coordinates
        /// </param>
        /// <returns>
        /// Pixel coordinates at that point
        /// </returns>
        private Point ZoomMousePos(Point click)
        {
            Size pbxSize = GetActivePictureBox().Size;
            Bitmap image = GetActiveBitmap();
            Size imgSize = image.Size;
            float imageAspect = imgSize.Width / (float)imgSize.Height;
            float controlAspect = pbxSize.Width / (float)pbxSize.Height;
            PointF pos = new PointF(click.X, click.Y);
            if (imageAspect > controlAspect)
            {
                float ratioWidth = imgSize.Width / (float)pbxSize.Width;
                pos.X *= ratioWidth;
                float scale = pbxSize.Width / (float)imgSize.Width;
                float displayHeight = scale * imgSize.Height;
                float diffHeight = pbxSize.Height - displayHeight;
                diffHeight /= 2;
                pos.Y -= diffHeight;
                pos.Y /= scale;
            }
            else
            {
                float ratioHeight = imgSize.Height / (float)pbxSize.Height;
                pos.Y *= ratioHeight;
                float scale = pbxSize.Height / (float)imgSize.Height;
                float displayWidth = scale * imgSize.Width;
                float diffWidth = pbxSize.Width - displayWidth;
                diffWidth /= 2;
                pos.X -= diffWidth;
                pos.X /= scale;
            }
            return new Point((int)pos.X, (int)pos.Y);
        }

        #endregion
    }
}
