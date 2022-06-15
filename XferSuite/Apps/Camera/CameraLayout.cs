using System;
using System.Drawing;

namespace XferSuite.Apps.Camera
{
    [Serializable]
    public class CameraLayout
    {
        public enum RotateFlipTypeSubset
        {
            RotateNoneFlipNone,
            Rotate90FlipNone,
            Rotate180FlipNone,
            Rotate270FlipNone,
            RotateNoneFlipX,
            Rotate90FlipX,
            RotateNoneFlipY,
            Rotate90FlipY,
        }
        public string CamID { get; set; } = string.Empty;
        public bool ShowListView { get; set; } = true;
        public bool ShowCrosshair { get; set; } = false;
        public Color CrosshairColor { get; set; } = Color.LawnGreen;
        public RotateFlipTypeSubset RotateFlipType { get; set; } = RotateFlipTypeSubset.RotateNoneFlipNone;
        public Size WindowSize { get; set; } = Size.Empty;
        public Point WindowLocation { get; set; } = Point.Empty;
    }
}
