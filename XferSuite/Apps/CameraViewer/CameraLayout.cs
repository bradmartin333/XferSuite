using System;
using System.Drawing;

namespace XferSuite
{
    [Serializable]
    public class CameraLayout
    {
        public string CamID { get; set; } = string.Empty;
        public bool ShowListView { get; set; } = true;
        public bool ShowCrosshair { get; set; } = false;
        public Color CrosshairColor { get; set; } = Color.LawnGreen;
        public int Rotation { get; set; } = 0;
        public Size WindowSize { get; set; } = Size.Empty;
        public Point WindowLocation { get; set; } = Point.Empty;
    }
}
