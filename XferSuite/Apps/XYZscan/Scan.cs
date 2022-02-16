﻿using System.Collections.Generic;
using System.Text;
using XferHelper;

namespace XferSuite
{
    public class Scan
    {
        public int Index { get; set; }
        public string ShortDate { get; set; }
        public string Time { get; set; }
        public string Name { get; set; } = "";
        public double Temp { get; set; } = 0.0;
        public double RH { get; set; } = 0.0;
        public int ScanSpeed { get; set; } = 0;
        public int NumPasses { get; set; } = 0;
        public int Threshold { get; set; } = 0;
        public List<Zed.Position> Data { get; set; } = new List<Zed.Position>();

        private bool _Edited;
        public bool Edited
        {
            get => _Edited;
            set
            {
                _Edited = value;
                EditedIcon = _Edited ? "edit" : "";
            }
        }
        public string EditedIcon { get; set; } = "";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"{ShortDate} {Time}\tNEWSCAN\t{Name}\t{Temp}\t{RH}\t{ScanSpeed}\t{NumPasses}\t{Threshold}\n");
            foreach (Zed.Position p in Data)
                sb.Append($"{p.Time.ToString("yyyy-MM-dd")} {p.Time.ToString("HH:mm:ss")}\t{p.X}\t{p.Y}\t{p.H / 1e3}\t{p.Z}\t{p.I}\n");
            return sb.ToString();
        }
    }
}
