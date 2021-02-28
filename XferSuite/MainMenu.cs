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

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idx = int.Parse(btn.Tag.ToString());

            if (settings.controlsArr[idx] == null || ((Form)settings.controlsArr[idx]).IsDisposed == true)
            {
                switch (idx)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        DataFileTree.frmDataFileTreeMain DFT = new DataFileTree.frmDataFileTreeMain() { Location = PointToScreen(btn.Location) };
                        DFT.FormClosed += new FormClosedEventHandler(controlClosed);
                        settings.controlsArr[idx] = DFT;
                        break;
                    case 7:
                        break;
                    case 8:
                        MapFlip.frmMapFlipMain MF = new MapFlip.frmMapFlipMain() { Location = PointToScreen(btn.Location) };
                        MF.FormClosed += new FormClosedEventHandler(controlClosed);
                        settings.controlsArr[idx] =  MF;
                        break;
                }
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
