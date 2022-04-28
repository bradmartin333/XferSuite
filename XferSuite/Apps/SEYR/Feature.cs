﻿using System;
using System.Collections.Generic;
using System.Drawing;
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

        private float _LastScore = 0f;
        internal float LastScore { get => _LastScore; set => _LastScore = value; }
        internal bool LastPass { get => Map() - 64 > 0; }

        public Feature()
        {
            Name = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
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
            return new Rectangle(rect.X, rect.Y, rect.Width + (rect.Width * 3 % 4), rect.Height);
        }

        public Feature Clone()
        {
            return new Feature()
            {
                Name = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                Rectangle = new Rectangle(Rectangle.X + 5, Rectangle.Y + 5, Rectangle.Width, Rectangle.Height),
                Threshold = Threshold,
                NullDetection = NullDetection,
                SaveImage = SaveImage,
                FlipScore = FlipScore,
            };
        }

        public static string[] GetDisplayNames()
        {
            List<string> names = new List<string>();
            foreach (var name in Enum.GetNames(typeof(NullDetectionTypes)))
                names.Add(name.Replace("_", " "));
            return names.ToArray();
        }

        internal void ClearScore()
        {
            _MinScore = float.MaxValue;
            _MaxScore = float.MinValue;
            _LastScore = 0f;
        }

        internal void UpdateScore(float score)
        {
            if (score > 0)
            {
                if (score < _MinScore) _MinScore = score;
                if (score > _MaxScore) _MaxScore = score;
            }
            _LastScore = score;
        }

        internal Color ColorFromScore(double value = 1, double saturation = 1, byte opacity = 255)
        {
            if (_MinScore == float.MaxValue || _MaxScore == float.MinValue || _MinScore == _MaxScore) return Color.Black;
            double hue = Map();
            if (hue == 360) return Color.FromArgb(255, Color.White);
            if (hue == 0) return Color.FromArgb(255, Color.Black);
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = (hue / 60) - Math.Floor(hue / 60);
            value *= 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - (f * saturation)));
            int t = Convert.ToInt32(value * (1 - ((1 - f) * saturation)));
            if (hi == 0)
                return Color.FromArgb(opacity, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(opacity, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(opacity, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(opacity, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(opacity, t, p, v);
            else
                return Color.FromArgb(opacity, v, p, q);
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

        private double Map()
        {
            double fromLow = _MinScore;
            double fromHigh = _MaxScore;
            double toLow = FlipScore ? 128 : 0;
            double toHigh = FlipScore ? 0 : 128;
            return (double)((_LastScore - fromLow) * (toHigh - toLow) / (fromHigh - fromLow)) + toLow;
        }
    }
}
