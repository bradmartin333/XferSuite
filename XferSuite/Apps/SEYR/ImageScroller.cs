using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class ImageScroller : Form
    {
        private int IDX = 0;
        private readonly List<Bitmap> Bitmaps;
        private readonly List<string> Info;

        public ImageScroller(List<Bitmap> bitmaps, List<string> info)
        {
            InitializeComponent();
            Location = Point.Empty;
            Bitmaps = bitmaps;
            Info = info;
            PBX.MouseUp += PBX_MouseUp;
            Timer.Start();
            Show();
            BringToFront();
        }

        private void PBX_MouseUp(object sender, MouseEventArgs e)
        {
            Timer.Enabled = !Timer.Enabled;
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            PBX.BackgroundImage = Bitmaps[IDX];
            LblInfo.Text = Info[IDX];
            IDX++;
            if (IDX > Bitmaps.Count - 1) IDX = 0;
        }
    }
}
