﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class LegendView : Form
    {
        private readonly Bitmap Legend;
        private readonly RegionBrowser RegionBrowser;

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

        private void BtnCopyImage_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(Legend);
        }

        private void BtnCloseAll_Click(object sender, EventArgs e)
        {
            RegionBrowser.Close();
            Close();
        }
    }
}
