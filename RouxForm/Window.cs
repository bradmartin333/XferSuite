using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace RouxForm
{
    public class Window : Form
    {
        private SizeF WindowSize = SizeF.Empty;

        public Window()
        {
            Rectangle bounds = Screen.FromControl(this).Bounds;
            WindowSize = new SizeF((int)(bounds.Width * 0.9), (int)(bounds.Height * 0.9));

            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "",
                Title = "Open an image to pixelate"
            };

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;
            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            if (dlg.ShowDialog() == DialogResult.OK) Functions.OpenWindow(new FileInfo(dlg.FileName), WindowSize);
        }
    }
}
