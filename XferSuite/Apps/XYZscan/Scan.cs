using System.Collections.Generic;

namespace XferSuite.XYZscan
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
        public List<XferHelper.Zed.Position> Data { get; set; } = new List<XferHelper.Zed.Position>();
    }
}
