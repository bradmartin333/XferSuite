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
        private Size ArraySize;

        public RegionBrowser(List<DataSheet> sheets)
        {
            InitializeComponent();
            Sheets = sheets;
            SetupTLP();
            Show();
        }

        private void SetupTLP()
        {
            var IDs = Sheets.Select(s => s.ID).ToList();
            var RRs = IDs.Select(id => id.Item1);
            var RCs = IDs.Select(id => id.Item2);
            ArraySize = new Size(RRs.Max(), RCs.Max());

            int hgt = 100 / RRs.Count();
            int wid = 100 / RCs.Count();

            TLP.ColumnStyles.Clear();
            TLP.RowStyles.Clear();
            TLP.ColumnCount = ArraySize.Height + 2;
            TLP.RowCount = ArraySize.Width + 2;

            TLP.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            TLP.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            for (int i = 0; i < ArraySize.Height; i++)
            {
                TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, wid));
                for (int j = 0; j < ArraySize.Width; j++)
                {
                    if (i == 0)
                    {
                        TLP.RowStyles.Add(new RowStyle(SizeType.Percent, hgt));
                        TLP.Controls.Add(TLPLabel((j + 1).ToString()), 1, ArraySize.Width - j - 1);
                    }
                    PictureBox pictureBox = new PictureBox()
                    {
                        Dock = DockStyle.Fill,
                        BackgroundImageLayout = ImageLayout.Zoom,
                    };
                    DataSheet[] sheets = Sheets.Where(s => s.ID == (ArraySize.Width - j, i + 1)).ToArray();
                    if (sheets.Any()) pictureBox.BackgroundImage = sheets.First().GetTestBitmap();
                    TLP.Controls.Add(pictureBox, i + 2, j);
                }
            }

            TLP.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            TLP.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            for (int i = 1; i < ArraySize.Height + 1; i++)
                TLP.Controls.Add(TLPLabel(i.ToString()), i + 1, ArraySize.Width + 1);

            Label RRlabel = TLPLabel("RR");
            TLP.Controls.Add(RRlabel, 0, 0);
            TLP.SetRowSpan(RRlabel, ArraySize.Width);

            Label RClabel = TLPLabel("RC");
            TLP.Controls.Add(RClabel, 2, ArraySize.Width + 2);
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
    }
}
