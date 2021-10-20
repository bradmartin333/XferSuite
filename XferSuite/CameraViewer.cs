using Accord.Video;
using Accord.Video.DirectShow;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace XferSuite
{
    public partial class CameraViewer : Form
    {
        // Video Feed
        private FilterInfoCollection VideoDevices;
        private VideoCaptureDevice VideoSource;

        // Controls
        private Splitter Splitter = new Splitter() { Dock = DockStyle.Left, MinExtra = 100, MinSize = 75 };
        private ListBox ListBox = new ListBox() { Dock = DockStyle.Left };
        private PictureBox PictureBox = new PictureBox() { Dock = DockStyle.Fill, BackgroundImageLayout = ImageLayout.Zoom, SizeMode = PictureBoxSizeMode.Zoom };

        // UI Elements
        private Size LastSize = Size.Empty;
        private Color Color = Color.LawnGreen;
        private int Rotation = 0;

        public CameraViewer()
        {
            InitializeComponent();
            Controls.AddRange(new Control[] { PictureBox, Splitter, ListBox });
            ListBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            VideoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            ListBox.Items.AddRange(VideoDevices.Select(x => x.Name).ToArray());
            Show();
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EndStream();
            StartStream(ListBox.SelectedIndex);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            EndStream();
        }

        private void StartStream(int v)
        {
            try
            {
                VideoSource = new VideoCaptureDevice(VideoDevices[v].MonikerString);
                VideoSource.NewFrame += new NewFrameEventHandler(NewFrame);
                VideoSource.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }  
        }

        private void EndStream()
        {
            if (VideoSource != null && VideoSource.IsRunning)
            {
                VideoSource.SignalToStop();
                VideoSource.WaitForStop();
            }
        }

        private void NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            RotateImage(ref bitmap);
            PictureBox.BackgroundImage = bitmap;
            if (bitmap.Size != LastSize)
                DrawCrosshair();
            LastSize = bitmap.Size;
        }

        private void RotateImage(ref Bitmap bitmap)
        {
            switch (Rotation % 4)
            {
                case 1:
                    bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case 2:
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 3:
                    bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                default:
                    break;
            }
        }

        private void btnToggleListView_Click(object sender, EventArgs e)
        {
            ListBox.Visible = btnToggleListView.Checked;
            if (btnToggleListView.Checked)
                btnToggleListView.Image = Properties.Resources.visible;
            else
                btnToggleListView.Image = Properties.Resources.invisible;
        }

        private void btnToggleCrosshair_Click(object sender, EventArgs e)
        {
            DrawCrosshair();
        }

        private void DrawCrosshair()
        {
            if (VideoSource == null || !VideoSource.IsRunning) return;
            Bitmap bitmap = new Bitmap(PictureBox.BackgroundImage.Width, PictureBox.BackgroundImage.Height);
            if (btnToggleCrosshair.Checked)
            {
                Pen pen = new Pen(Color.FromArgb(100, Color), bitmap.Height / 150);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawLine(pen, new Point(bitmap.Width / 2, 0), new Point(bitmap.Width / 2, bitmap.Height));
                g.DrawLine(pen, new Point(0, bitmap.Height / 2), new Point(bitmap.Width, bitmap.Height / 2));
            }
            PictureBox.Image = bitmap;
        }

        private void btnCrosshairColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color = colorDialog.Color;
                DrawCrosshair();
            }
        }

        private void btnRotateImage_Click(object sender, EventArgs e)
        {
            Rotation++;
        }
    }
}
