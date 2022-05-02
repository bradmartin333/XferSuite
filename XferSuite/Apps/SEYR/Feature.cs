using System;
using System.Drawing;
using System.Linq;
using System.Xml.Serialization;

namespace XferSuite.Apps.SEYR
{
    [Serializable()]
    public class Feature
    {
        public enum NullDetectionTypes
        {
            None,
            Include_Empty,
            Include_Filled,
            Include_Both,
        }

        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Rectangle")]
        public Rectangle Rectangle { get; set; } = new Rectangle(10, 10, 10, 10);
        [XmlElement("Threshold")]
        public float Threshold { get; set; } = 0.2f;
        [XmlElement("NullDetection")]
        public NullDetectionTypes NullDetection { get; set; } = NullDetectionTypes.None;
        public string NullDetectionDisplay { get => NullDetection.ToString().Replace("_", " "); }
        [XmlElement("FlipScore")]
        public bool FlipScore { get; set; } = false;
        [XmlElement("SaveImage")]
        public bool SaveImage { get; set; } = true;

        private float _MinScore = float.MaxValue;
        [XmlElement("MinScore")]
        public float MinScore { get => _MinScore; set => _MinScore = value; }

        private float _MaxScore = float.MinValue;
        [XmlElement("MaxScore")]
        public float MaxScore { get => _MaxScore; set => _MaxScore = value; }

        internal int ID { get; set; }
        internal double PassThreshold { get; set; }
        internal double Limit { get; set; }
        internal DataEntry[] Data { get; set; }
        internal double[] HistData { get; set; }

        public Rectangle GetGeometry()
        {
            Point offset = new Point((int)(ParseSEYR.Project.ScaledPixelsPerMicron * Rectangle.X),
                (int)(ParseSEYR.Project.ScaledPixelsPerMicron * Rectangle.Y));
            Point size = new Point((int)(ParseSEYR.Project.ScaledPixelsPerMicron * Rectangle.Width),
                (int)(ParseSEYR.Project.ScaledPixelsPerMicron * Rectangle.Height));
            return new Rectangle(offset.X, offset.Y, size.X, size.Y);
        }

        public Rectangle GetPaddedGeometry()
        {
            Rectangle rect = GetGeometry();
            return new Rectangle(rect.X, rect.Y, rect.Width + (rect.Width * 3 % 4), rect.Height);
        }

        internal bool GenerateState(float score)
        {
            double fromLow = _MinScore;
            double fromHigh = _MaxScore;
            double toLow = FlipScore ? 128 : 0;
            double toHigh = FlipScore ? 0 : 128;
            double map = (double)((score - fromLow) * (toHigh - toLow) / (fromHigh - fromLow)) + toLow;
            return map - 64 > 0;
        }

        internal (int, int) GetNullData()
        {
            float[] scores = Data.Select(x => x.Score).ToArray();
            return (scores.Where(x => x == -10).Count(), scores.Where(x => x == 0).Count());
        }
    }
}
