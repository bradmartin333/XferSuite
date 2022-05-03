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
        [XmlElement("PassThreshold")]
        public double PassThreshold { get; set; } = -10; // Added by XferSuite
        [XmlElement("Limit")]
        public double Limit { get; set; } = -10; // Added by XferSuite
        [XmlElement("Ignore")]
        public bool Ignore { get; set; } = false; // Added by XferSuite
        internal int ID { get; set; }
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
            if (FlipScore) return score >= Limit && score <= PassThreshold;
            else return score >= PassThreshold && score <= Limit;
        }

        internal (int, int) GetNullData()
        {
            float[] scores = Data.Select(x => x.Score).ToArray();
            return (scores.Where(x => x == -10).Count(), scores.Where(x => x == 0).Count());
        }
    }
}
