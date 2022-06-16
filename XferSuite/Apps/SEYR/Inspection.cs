using System;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class Inspection : Form
    {
        private bool Loading = false;
        private DataEntry[] Data;
        private int IDX = 0;

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
            foreach (DataEntry entry in Data)
                entry.State = CBX.Checked;
            CBX.Text = CBX.Checked ? "Pass" : "Fail";
        }

        public void Set(DataEntry[] d, Criteria criteria)
        {
            Loading = true;
            IDX = 0;
            Data = d;
            CBX.Checked = criteria.Pass;
            CBX.Text = CBX.Checked ? "Pass" : "Fail";
            PBX.BackColor = criteria.Color;
            CycleImages();
            Show();
            BringToFront();
            Loading = false;
        }

        private void CycleImages()
        {
            PBX.BackgroundImage = Data[IDX].Image;
            Text = $"{Data[IDX]} {Data[IDX].X}, {Data[IDX].Y}";
            LblInfo.Text = Data[IDX].Location();
        }

        private void PBX_Click(object sender, EventArgs e)
        {
            IDX++;
            if (IDX > Data.Length - 1) IDX = 0;
            CycleImages();
        }
    }
}
