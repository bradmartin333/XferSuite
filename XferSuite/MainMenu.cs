﻿using System;
using System.IO;
using System.Linq;
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

        private Settings _Settings = new Settings();

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idx = int.Parse(btn.Tag.ToString());

            Form form = new Form();
            string path;

            switch (idx)
            {
                case 0:
                    path = OpenFile("Open an Inlinepositions File", "txt file (*.txt)|*.txt");
                    if (path == null)
                        return;
                    if (!VerifyMetro(path))
                        return;
                    form = new MetroGraphs(Metro.data(path)) { Text = new FileInfo(path).Name };
                    break;
                case 1:
                    path = OpenFile("Open a HeightSensorLog File", "txt file (*.txt)|*.txt");
                    if (path == null)
                        return;
                    form = new ZRegistration.frmScanSelect() { Path = path };
                    break;
                case 2:
                    path = OpenFile("Open an Inlinepositions File", "txt file (*.txt)|*.txt");
                    if (path == null)
                        return;
                    if (!VerifyMetro(path))
                        return;
                    form = new Fingerprinting(Metro.data(path)) { Text = new FileInfo(path).Name };
                    break;
                case 3:
                    path = OpenFile("Open a XferPrint recipe", "xrec file (*.xrec)|*.xrec");
                    if (path == null)
                        return;
                    form = new PrintSim(path);
                    break;
                case 4:
                    path = OpenFile("Open an EventLog File", "txt file (*.txt)|*.txt");
                    if (path == null)
                        return;
                    form = new EventLogParsing(path);
                    break;
                case 5:
                    form = new DataFileTree.frmDataFileTreeMain() { Location = PointToScreen(btn.Location) };
                    break;
                case 6:
                    form = new MapFlip();
                    break;
            }

            form.Activated += Form_Activated;
            form.Show();
        }

        private void Form_Activated(object sender, EventArgs e)
        {
            if (!_Settings.IsDisposed) // Prevents error on app close
                _Settings.propertyGrid.SelectedObject = sender;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            _Settings.Show();
            _Settings.BringToFront();
        }

        private string OpenFile(string title, string filter)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = title;
                openFileDialog.Filter = filter;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    return openFileDialog.FileName;
            }
            return null;
        }

        private bool VerifyMetro(string path)
        {
            switch (Metro.verify(path))
            {
                case 0:
                    MessageBox.Show("Insufficient data in file", "XferSuite");
                    return false;
                case 1:
                    return true;
                case 2:
                    return true;
                default:
                    MessageBox.Show("Invalid file", "XferSuite");
                    return false;
            }
        }
    }
}
