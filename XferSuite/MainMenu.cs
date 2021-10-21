using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class MainMenu : Form
    {
        public static int MajorVersion = 2;
        public static int MinorVerson = 5;

        private Settings _Settings = new Settings();

        public MainMenu()
        {
            InitializeComponent();
            Text = string.Format("XferSuite v{0}.{1}", MajorVersion, MinorVerson);
            foreach (Button b in tableLayoutPanel.Controls.OfType<Button>())
            {
                ToolTip tip = new ToolTip
                {
                    InitialDelay = 0
                };
                tip.SetToolTip(b, b.AccessibleName);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (CameraViewer cameraViewer in Application.OpenForms.OfType<CameraViewer>()) cameraViewer.EndStream();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idx = int.Parse(btn.Tag.ToString());
            string path = GetPath(idx);
            if (path == null) return;
            CreateForm(idx, path);
        }

        private string GetPath(int idx)
        {
            string path = string.Empty;
            switch (idx)
            {
                case 0:
                    path = OpenFile("Open an Inlinepositions File", "txt file (*.txt)|*.txt");
                    break;
                case 1:
                    path = OpenFile("Open a HeightSensorLog File", "txt file (*.txt)|*.txt");
                    break;
                case 2:
                    path = OpenFile("Open an Inlinepositions File", "txt file (*.txt)|*.txt");
                    break;
                case 3:
                    path = OpenFile("Open a XferPrint recipe", "xrec file (*.xrec)|*.xrec");
                    break;
                case 4:
                    path = OpenFile("Open a SEYR Report", "txt file (*.txt)|*.txt");
                    break;
                default:
                    break;
            }
            return path;
        }

        private void CreateForm(int idx, string path)
        {
            Form form = new Form();
            using (new HourGlass())
            {
                switch (idx)
                {
                    case 0:
                        if (!VerifyMetro(path)) return;
                        form = new MetroGraphs(Metro.data(path)) { Text = new FileInfo(path).Name };
                        break;
                    case 1:
                        form = new XYZscan.frmScanSelect(path);
                        break;
                    case 2:
                        if (!VerifyMetro(path)) return;
                        form = new Fingerprinting(Metro.data(path)) { Text = new FileInfo(path).Name };
                        break;
                    case 3:
                        form = new PrintSim(path);
                        break;
                    case 4:
                        form = new ParseSEYR(path);
                        break;
                    case 5:
                        form = new DataFileTree.frmDataFileTreeMain();
                        break;
                    case 6:
                        form = new MapFlip();
                        break;
                    default:
                        return;
                }
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

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Bitmap bmp = new Bitmap(Width, Height);
                DrawToBitmap(bmp, new Rectangle(0, 0, Width, Height));
                DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath);
                string desiredPath;
                if (directoryInfo.FullName.Contains("Debug"))
                    desiredPath = directoryInfo.FullName.Replace("bin\\Debug", "");
                else
                    desiredPath = directoryInfo.FullName.Replace("bin\\Release", "");
                bmp.Save(desiredPath + "\\Main.png");
            }
        }
    }
}
