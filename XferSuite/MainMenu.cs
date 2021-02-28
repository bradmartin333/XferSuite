using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XferSuite
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            foreach (Button b in tableLayoutPanel.Controls.OfType<Button>())
            {
                ToolTip tip = new ToolTip 
                { 
                    InitialDelay = 0 
                };
                tip.SetToolTip(b, b.AccessibleName);
            }
        }

        private Settings settings = new Settings();

        private void btnDataFileTree_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idx = int.Parse(btn.Tag.ToString());

            if (settings.controlsArr[idx] == null || ((Form)settings.controlsArr[idx]).IsDisposed == true)
            {
                DataFileTree.frmDataFileTreeMain DFT = new DataFileTree.frmDataFileTreeMain()
                {
                    Location = PointToScreen(btn.Location)
                };
                DFT.FormClosed += new FormClosedEventHandler(controlClosed);
                settings.controlsArr[idx] = DFT;
            }
            
            ((Form)settings.controlsArr[idx]).Show();
            ((Form)settings.controlsArr[idx]).BringToFront();
            settings.LoadButtons();
        }

        private void controlClosed(object sender, FormClosedEventArgs e)
        {
            Form thisForm = (Form)sender;
            thisForm.Dispose();
            settings.LoadButtons();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settings.Show();
            settings.BringToFront();
        }
    }
}
