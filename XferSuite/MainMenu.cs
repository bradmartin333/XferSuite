using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XferHelper;

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
            string path = null;

            switch (idx)
            {
                case 0:
                    if (!ReadMetro(idx))
                    {
                        break;
                    }
                    break;
                case 1:
                    path = OpenFile("Open a HeightSensorLog File", "txt file (*.txt)|*.txt");
                    if (path == null)
                    {
                        break;
                    }
                    ZRegistration.frmScanSelect ZS = new ZRegistration.frmScanSelect() { Path = path };
                    ZS.FormClosed += new FormClosedEventHandler(controlClosed);
                    settings.controlsArr[idx] = ZS;
                    break;
                case 2:
                    if (!ReadMetro(idx))
                    {
                        break;
                    }
                    break;
                case 3:
                    path = OpenFile("Open a XferPrint recipe", "xrec file (*.xrec)|*.xrec");
                    if (path == null)
                    {
                        break;
                    }
                    PrintSim PS = new PrintSim(path);
                    PS.FormClosed += new FormClosedEventHandler(controlClosed);
                    settings.controlsArr[idx] = PS;
                    break;
                case 4:
                    path = OpenFile("Open an EventLog File", "txt file (*.txt)|*.txt");
                    if (path == null)
                    {
                        break;
                    }
                    EventLogParsing ELP = new EventLogParsing(path);
                    ELP.FormClosed += new FormClosedEventHandler(controlClosed);
                    settings.controlsArr[idx] = ELP;
                    break;
                case 5:
                    DataFileTree.frmDataFileTreeMain DFT = new DataFileTree.frmDataFileTreeMain() { Location = PointToScreen(btn.Location) };
                    DFT.FormClosed += new FormClosedEventHandler(controlClosed);
                    settings.controlsArr[idx] = DFT;
                    break;
                case 6:
                    MapFlip MF = new MapFlip();
                    MF.FormClosed += new FormClosedEventHandler(controlClosed);
                    settings.controlsArr[idx] = MF;
                    break;
            }

            if (settings.controlsArr[idx] != null)
            {
                ((Form)settings.controlsArr[idx]).Show();
                ((Form)settings.controlsArr[idx]).BringToFront();
                settings.LoadButtons();
            }
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

        private string OpenFile(string title, string filter)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = title;
                openFileDialog.Filter = filter;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return null;
        }

        private bool ReadMetro(int idx)
        {
            string path = OpenFile("Open an Inlinepositions File", "txt file (*.txt)|*.txt");
            if (path == null)
            {
                return false;
            }

            int fileType = Metro.verify(path);
            Metro.Position[] data;

            switch (fileType)
            {
                case 0:
                    MessageBox.Show("Insufficient data in file", "XferSuite");
                    return false;
                case 1:
                    data = Metro.data(path);
                    break;
                case 2:
                    data = Metro.data(path);
                    break;
                default:
                    MessageBox.Show("Invalid file", "XferSuite");
                    return false;
            }

            switch (idx)
            {
                case 0:
                    MetroGraphs MG = new MetroGraphs(data) { Text = new FileInfo(path).Name };
                    MG.FormClosed += new FormClosedEventHandler(controlClosed);
                    settings.controlsArr[idx] = MG;
                    break;
                case 2:
                    Fingerprinting FP = new Fingerprinting(data) { Text = new FileInfo(path).Name };
                    FP.FormClosed += new FormClosedEventHandler(controlClosed);
                    settings.controlsArr[idx] = FP;
                    break;
            }

            return true;
        }
    }
}
