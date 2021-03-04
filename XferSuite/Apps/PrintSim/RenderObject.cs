using System.Drawing;

namespace XferSuite
{
    public class RenderObject
    {
        public bool Selected;
        public float RR, RC, R, C, IDX;
        public float X, Y, Width, Height;

        public RenderObject(float x, float y, float width, float height, Color color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
