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
    public partial class LegendView : Form
    {
        private Bitmap Legend;
        private RegionBrowser RegionBrowser;

        public LegendView(Bitmap bitmap, RegionBrowser rb)
        {
            InitializeComponent();
            Legend = bitmap;
            RegionBrowser = rb;
            PBX.BackgroundImage = Legend;
            Show();
        }

        private void CbxTogglePF_CheckedChanged(object sender, EventArgs e)
        {
            RegionBrowser.TogglePF(CbxTogglePF.Checked);
        }
    }
}
