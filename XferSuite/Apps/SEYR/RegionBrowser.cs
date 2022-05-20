using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class RegionBrowser : Form
    {
        private List<DataSheet> Sheets;
        private Size ArraySize;

        public RegionBrowser(List<DataSheet> sheets)
        {
            InitializeComponent();
            Sheets = sheets;
            ResizeTLP();
            Show();
        }

        private void ResizeTLP()
        {
            var IDs = Sheets.Select(s => s.ID).ToList();
            var RRs = IDs.Select(id => id.Item1);
            var RCs = IDs.Select(id => id.Item2);
            ArraySize = new Size(RRs.Max(), RCs.Max());

            int hgt = 100 / RRs.Count();
            int wid = 100 / RCs.Count();

            TLP.ColumnStyles.Clear();
            TLP.RowStyles.Clear();
            TLP.ColumnCount = ArraySize.Height;
            TLP.RowCount = ArraySize.Width;

            for (int i = 0; i < ArraySize.Height; i++)
            {
                TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, wid));
                for (int j = 0; j < ArraySize.Width; j++)
                {
                    if (i == 0) TLP.RowStyles.Add(new RowStyle(SizeType.Percent, hgt));
                    PictureBox pictureBox = new PictureBox()
                    {
                        Dock = DockStyle.Fill,
                        BackgroundImageLayout = ImageLayout.Zoom,
                    };
                    DataSheet[] sheets = Sheets.Where(s => s.ID == (ArraySize.Width - j, i + 1)).ToArray();
                    if (sheets.Any()) pictureBox.BackgroundImage = sheets.First().GetTestBitmap();
                    TLP.Controls.Add(pictureBox, i, j);
                }
            }
        }
    }
}
