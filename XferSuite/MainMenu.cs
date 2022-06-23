using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class MainMenu : Form
    {
        public static int MajorVersion = 3;
        public static int MinorVerson = 24;
        public static readonly Settings Settings = new Settings();

        public MainMenu()
        {
            InitializeComponent();
            Text = string.Format("XferSuite v{0}.{1}", MajorVersion, MinorVerson);
            foreach (Button b in tableLayoutPanel.Controls.OfType<Button>())
            {
                ToolTip tip = new ToolTip { InitialDelay = 0 };
                tip.SetToolTip(b, b.AccessibleName);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (Apps.Camera.CameraViewer cameraViewer in Application.OpenForms.OfType<Apps.Camera.CameraViewer>())
                cameraViewer.EndStream();
        }

        private void Btn_Click(object sender, EventArgs e)
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
                    path = OpenFile("Open a SEYRUP file", "SEYRUP file (*.seyrup)|*.seyrup");
                    break;
                default:
                    break;
            }
            return path;
        }

        private void CreateForm(int idx, string path)
        {
            Form form = new Form();
            switch (idx)
            {
                case 0:
                    using (new Utility.HourGlass())
                    {
                        if (!VerifyPath(path, idx)) return;
                        form = new Apps.InlinePositions.MetroGraphs(path) { Text = new FileInfo(path).Name };
                    }
                    break;
                case 1:
                    using (new Utility.HourGlass())
                    {
                        if (!VerifyPath(path, idx)) return;
                        form = new Apps.XYZplotter.Plotter(path);
                    }
                    break;
                case 2:
                    using (new Utility.HourGlass())
                    {
                        form = new Apps.SEYR.ParseSEYR(path);
                    }
                    break;
                case 3:
                    form = new Apps.Camera.CameraViewer();
                    break;
                case 4:
                    form = new AdvancedTools.SelectTool();
                    break;
                default:
                    return;
            }
            form.Activated += Form_Activated;
            form.Show();
            Settings.PropertyGrid.SelectedObject = form;
        }

        public static void Form_Activated(object sender, EventArgs e)
        {
            if (!Settings.IsDisposed) // Prevents error on app close
                Settings.PropertyGrid.SelectedObject = sender;
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            Settings.Show();
            Settings.BringToFront();
        }

        public static string OpenFile(string title, string filter)
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

        public static string[] OpenFiles(string title, string filter)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = title;
                openFileDialog.Filter = filter;
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    return openFileDialog.FileNames;
            }
            return null;
        }

        public static string SaveFile(string title, string filter)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = title;
                saveFileDialog.Filter = filter;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    return saveFileDialog.FileName;
            }
            return null;
        }

        private bool VerifyPath(string path, int idx)
        {
            int result = -1;
            switch (idx)
            {
                case 0:
                    result = Metro.verify(path);
                    break;
                case 1:
                    result = Zed.verify(path);
                    break;
                default:
                    break;
            }
            if (result == -1) return false;
            switch (result)
            {
                case 0:
                    MessageBox.Show("Insufficient data in file", "XferSuite");
                    return false;
                case 1:
                case 2:
                    return true;
                default:
                    MessageBox.Show("Invalid file", "XferSuite");
                    return false;
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            Settings.CheckForUpdates();
        }
    }
}
