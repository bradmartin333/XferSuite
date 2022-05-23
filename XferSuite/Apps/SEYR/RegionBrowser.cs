using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class RegionBrowser : Form
    {
        private readonly List<DataSheet> Sheets;
        private readonly string LegendStr;
        private Size ArraySize;
        private TableLayoutPanel TLP;
        private List<PictureBox> PictureBoxes;

        public RegionBrowser(List<DataSheet> sheets, string legendStr)
        {
            InitializeComponent();
            Sheets = sheets;
            LegendStr = legendStr;
            SetupTLP();
            Show();
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

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    ContextMenuStrip.Tag = ((PictureBox)sender).Tag;
                    ContextMenuStrip.Show(((PictureBox)sender).PointToScreen(e.Location));
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
        }

        public void TogglePF(bool showPF)
        {
            Controls.Remove(TLP);
            SetupTLP(showPF);
        }

        #region Context Menu

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

        private void ToolStripMenuItemCopyImage_Click(object sender, System.EventArgs e)
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

        #endregion
    }
}
