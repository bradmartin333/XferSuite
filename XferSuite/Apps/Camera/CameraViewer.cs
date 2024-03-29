﻿using Accord.Video;
using Accord.Video.DirectShow;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using static XferSuite.Apps.Camera.CameraLayout;

namespace XferSuite.Apps.Camera
{
    public partial class CameraViewer : Form
    {
        // Session Memory
        private readonly string MemoryPath = @"C:\XferPrint\Data\Log\Layouts\XferSuiteCamera.bin";
        private CameraLayout CameraLayout;

        // Video Feed
        private readonly FilterInfoCollection VideoDevices;
        private VideoCaptureDevice VideoSource;

        // Controls
        private readonly Splitter Splitter = new Splitter() { Dock = DockStyle.Left, MinExtra = 100, MinSize = 75 };
        private readonly ListBox ListBox = new ListBox() { Dock = DockStyle.Left };
        private readonly PictureBox PictureBox = new PictureBox() { Dock = DockStyle.Fill, BackgroundImageLayout = ImageLayout.Zoom, SizeMode = PictureBoxSizeMode.Zoom };

        // UI Elements
        private Size LastSize = Size.Empty;
        private Color Color = Color.LawnGreen;
        private RotateFlipTypeSubset RotateFlipType = RotateFlipTypeSubset.RotateNoneFlipNone;

        public CameraViewer()
        {
            InitializeComponent();
            Controls.AddRange(new Control[] { PictureBox, Splitter, ListBox });
            ListBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            VideoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            ListBox.Items.AddRange(VideoDevices.Select(x => x.Name).ToArray());
            ResizeEnd += CameraViewer_WindowChanged;
            LocationChanged += CameraViewer_WindowChanged;
            ToolStripComboBoxRotateFlip.Items.AddRange(Enum.GetNames(typeof(RotateFlipTypeSubset)));
            ToolStripComboBoxRotateFlip.SelectedIndexChanged += ToolStripComboBoxRotateFlip_SelectedIndexChanged;
            CameraLayout = new CameraLayout();
            Deserialize(MemoryPath);
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox.SelectedIndex == -1) return;
            EndStream();
            StartStream(VideoDevices[ListBox.SelectedIndex].MonikerString);
            UpdateSessionMemory();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            EndStream();
        }

        private void StartStream(string moniker)
        {
            try
            {
                CameraLayout.CamID = moniker;
                VideoSource = new VideoCaptureDevice(moniker);
                VideoSource.NewFrame += new NewFrameEventHandler(NewFrame);
                VideoSource.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }  
        }

        public void EndStream()
        {
            if (VideoSource != null && VideoSource.IsRunning)
            {
                VideoSource.SignalToStop();
                VideoSource.WaitForStop();
            }
        }

        private void NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                Size thisSize = RotateImage(ref bitmap);
                PictureBox.BackgroundImage = bitmap;
                if (thisSize != LastSize) DrawCrosshair();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private Size RotateImage(ref Bitmap bitmap)
        {
            Enum.TryParse(RotateFlipType.ToString(), out RotateFlipType rotateFlipType);
            bitmap.RotateFlip(rotateFlipType);
            return bitmap.Size;
        }

        private void BtnToggleListView_Click(object sender, EventArgs e)
        {
            ListBox.Visible = btnToggleListView.Checked;
            if (btnToggleListView.Checked)
                btnToggleListView.Image = Properties.Resources.visible;
            else
                btnToggleListView.Image = Properties.Resources.invisible;
            UpdateSessionMemory();
        }

        private void BtnToggleCrosshair_Click(object sender, EventArgs e)
        {
            DrawCrosshair();
        }

        private void DrawCrosshair()
        {
            if (VideoSource == null || !VideoSource.IsRunning || PictureBox.BackgroundImage == null) return;
            Bitmap bitmap = new Bitmap(PictureBox.BackgroundImage.Width, PictureBox.BackgroundImage.Height);
            if (btnToggleCrosshair.Checked)
            {
                Pen pen = new Pen(Color.FromArgb(100, Color), bitmap.Height / 150);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawLine(pen, new Point(bitmap.Width / 2, 0), new Point(bitmap.Width / 2, bitmap.Height));
                g.DrawLine(pen, new Point(0, bitmap.Height / 2), new Point(bitmap.Width, bitmap.Height / 2));
            }
            PictureBox.Image = bitmap;
            LastSize = bitmap.Size;
            UpdateSessionMemory();
        }

        private void BtnCrosshairColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color = colorDialog.Color;
                DrawCrosshair();
            }
        }

        private void ToolStripComboBoxRotateFlip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(ToolStripComboBoxRotateFlip.Text, out RotateFlipType);
            UpdateSessionMemory();
        }

        private void BtnSaveFrame_Click(object sender, EventArgs e)
        {
            if (VideoSource == null || !VideoSource.IsRunning) return;
            Bitmap bitmap = (Bitmap)PictureBox.BackgroundImage.Clone();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Export Camera Frame";
                saveFileDialog.DefaultExt = ".png";
                saveFileDialog.Filter = "png file (*.png)|*.png";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    bitmap.Save(saveFileDialog.FileName);
            }
        }

        #region Session Memory

        private void BtnResetSessionMem_Click(object sender, EventArgs e)
        {
            File.Delete(MemoryPath);
            Close();
        }

        private void CameraViewer_WindowChanged(object sender, EventArgs e)
        {
            if (File.Exists(MemoryPath)) UpdateSessionMemory();
        }

        private void UpdateSessionMemory()
        {
            if (Visible)
            {
                CameraLayout.WindowSize = Size;
                CameraLayout.WindowLocation = Location;
                CameraLayout.ShowListView = btnToggleListView.Checked;
                CameraLayout.ShowCrosshair = btnToggleCrosshair.Checked;
                CameraLayout.CrosshairColor = Color;
                CameraLayout.RotateFlipType = RotateFlipType;
            }
            
            Serialize(CameraLayout, MemoryPath);
            btnResetSessionMem.Visible = File.Exists(MemoryPath);
        }

        public void Serialize(CameraLayout cameraLayout, string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);
            if (!fileInfo.Directory.Exists) return;

            Stream ms = File.OpenWrite(filename);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, cameraLayout);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        public void Deserialize(string filename)
        {
            if (!File.Exists(filename))
            {
                btnResetSessionMem.Visible = false;
                return;
            }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = File.Open(filename, FileMode.Open);
            try
            {
                object obj = formatter.Deserialize(fs);
                CameraLayout = (CameraLayout)obj;
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
            catch (Exception)
            {
                fs.Flush();
                fs.Close();
                fs.Dispose();
                File.Delete(MemoryPath);
                return;
            }

            // Start Video
            foreach (FilterInfo device in VideoDevices)
                if (device.MonikerString == CameraLayout.CamID) StartStream(CameraLayout.CamID);
            System.Threading.Thread.SpinWait(1000);
            if (VideoSource == null || !VideoSource.IsRunning) return;

            // Restore Position
            StartPosition = FormStartPosition.Manual;
            Size = CameraLayout.WindowSize;
            DesktopLocation = CameraLayout.WindowLocation;

            // Restore Options
            RotateFlipType = CameraLayout.RotateFlipType;
            ToolStripComboBoxRotateFlip.Text = RotateFlipType.ToString();
            Color = CameraLayout.CrosshairColor;
            if (!CameraLayout.ShowListView) btnToggleListView.PerformClick();
            if (CameraLayout.ShowCrosshair) btnToggleCrosshair.PerformClick();
        }

        #endregion
    }
}
