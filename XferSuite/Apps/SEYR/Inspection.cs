using System;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class Inspection : Form
    {
        private bool Loading = false;
        private DataEntry _DataEntry;

        public Inspection()
        {
            InitializeComponent();
            FormClosing += Inspection_FormClosing;
        }

        private void Inspection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void CBX_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading) return;
            _DataEntry.State = CBX.Checked;
            CBX.Text = CBX.Checked ? "Pass" : "Fail";
        }

        public void Set(DataEntry d, bool pass)
        {
            Loading = true;
            PBX.BackgroundImage = d.Image;
            Text = $"{d} {d.X}, {d.Y}";
            LblInfo.Text = d.Location();
            CBX.Checked = pass;
            CBX.Text = CBX.Checked ? "Pass" : "Fail";
            _DataEntry = d;
            Show();
            Loading = false;
        }
    }
}
