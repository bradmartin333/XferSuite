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

        [XmlElement("PassThreshold")] // Added by XferSuite
        public double PassThreshold { get; set; } = -10;
        [XmlElement("Limit")] // Added by XferSuite
        public double Limit { get; set; } = -10;
        [XmlElement("Ignore")] // Added by XferSuite
        public bool Ignore { get; set; } = false;

        private string _CriteriaString = string.Empty;
        [XmlElement("CriteriaString")]  // Added by XferSuite
        public string CriteriaString
        {
            get => _CriteriaString.Replace(" ", "`");
            set { _CriteriaString = value; }
        }

        internal DataEntry[] Data { get; set; }
        internal double[] HistData { get; set; }
        internal string RedundancyGroup
        {
            get
            {
                string[] vals = CriteriaString.Split('_');
                if (vals.Length == 2)
                    return vals[0];
                else
                    return string.Empty;
            }
        }
        internal string NeedOneGroup
        {
            get
            {
                string[] vals = CriteriaString.Split('_');
                if (vals.Length == 2)
                    return vals[1];
                else
                    return CriteriaString;
            }
        }

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
            return new Rectangle(rect.X, rect.Y, rect.Width + ((rect.Width * 3) % 4), rect.Height);
        }

        internal bool GenerateState(float score)
        {
            if (score == -10) return false; // Null exclude
            if (score == 0) return true; // Null include
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
