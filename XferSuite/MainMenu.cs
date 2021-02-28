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
                        string path = OpenFile("Open a HeightSensorLog File");
                        if (path == null)
                        {
                            break;
                        }
                        ZRegistration.frmScanSelect ZS = new ZRegistration.frmScanSelect(path) { Location = PointToScreen(btn.Location) };
                        ZS.FormClosed += new FormClosedEventHandler(controlClosed);
                        settings.controlsArr[idx] = ZS;
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
                        settings.controlsArr[idx] = MF;
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

        private string OpenFile(string title)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = title;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return null;
        }
    }
}
