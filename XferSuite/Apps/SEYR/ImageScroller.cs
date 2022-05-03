using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class ImageScroller : Form
    {
        private int IDX = 0;
        private readonly List<Bitmap> Bitmaps;

        public ImageScroller(List<Bitmap> bitmaps)
        {
            InitializeComponent();
            Location = Point.Empty;
            Bitmaps = bitmaps;
            Timer.Start();
            Show();
            BringToFront();
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            PBX.BackgroundImage = Bitmaps[IDX];
            IDX++;
            if (IDX > Bitmaps.Count - 1) IDX = 0;
        }
    }
}
