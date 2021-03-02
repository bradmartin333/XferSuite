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

            if (settings.controlsArr[idx] == null || ((Form)settings.controlsArr[idx]).IsDisposed == true || idx == 0)
            {
                switch (idx)
                {
                    case 0:
                        if (!InitMetroGraphs(idx))
                        {
                            break;
                        }
                        break;
                    case 1:
                        path = OpenFile("Open a HeightSensorLog File");
                        if (path == null)
                        {
                            break;
                        }
                        ZRegistration.frmScanSelect ZS = new ZRegistration.frmScanSelect() { Path = path, Location = PointToScreen(btn.Location) };
                        ZS.FormClosed += new FormClosedEventHandler(controlClosed);
                        settings.controlsArr[idx] = ZS;
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        path = OpenFile("Open an EventLog File");
                        if (path == null)
                        {
                            break;
                        }
                        string[] readText = File.ReadAllLines(path);
                        Parser.Event[] prints = Parser.main(readText);
                        EventLogParsing ELP = new EventLogParsing { Location = PointToScreen(btn.Location) };
                        foreach (Parser.Event p in prints)
                        {
                            ELP.richTextBox.Text += p.Time + Environment.NewLine;
                        }
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

        private string OpenFile(string title)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = title;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return null;
        }

        private bool InitMetroGraphs(int idx)
        {
            string path = OpenFile("Open an Inlinepositions File");
            if (path == null)
            {
                return false;
            }

            int fileType = Metro.verify(path);
            Metro.Position[] data;

            switch (fileType)
            {
                case 0:
                    MessageBox.Show("Insufficient data in file", "XferSuite Inlinepositions");
                    return false;
                case 1:
                    data = Metro.data(path);
                    break;
                case 2:
                    data = Metro.data(path);
                    break;
                default:
                    MessageBox.Show("Invalid file", "XferSuite Inlinepositions");
                    return false;
            }

            MetroGraphs MG = new MetroGraphs(data) { Text = new FileInfo(path).Name };
            MG.FormClosed += new FormClosedEventHandler(controlClosed);
            settings.controlsArr[idx] = MG;
            return true;
        }
    }
}
