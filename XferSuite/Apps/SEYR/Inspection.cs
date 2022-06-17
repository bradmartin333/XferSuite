using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class Inspection : Form
    {
        private bool Loading = false;
        private DataEntry[] Data;
        private int IDX = 0;
        private readonly string FileName;

        public Inspection(string fileName)
        {
            InitializeComponent();
            FileName = fileName;
            KeyDown += Inspection_KeyDown;
            FormClosing += Inspection_FormClosing;
        }

        private void BtnParserMenu_Click(object sender, EventArgs e)
        {
            BringMenuToFront();
        }

        private void Inspection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F) BringMenuToFront();
        }

        private void BringMenuToFront()
        {
            IEnumerable<ParseSEYR> matches = Application.OpenForms.OfType<ParseSEYR>().Where(x => x.Text == FileName);
            if (matches.Any()) matches.First().BringToFront();
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
            //IDX = 0; // Reset to starting feature
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
            if (IDX > Data.Length - 1) IDX = 0; // Simple error prevention
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
