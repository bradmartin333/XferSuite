using System;

namespace XferSuite.AdvancedTools.uTP
{
    public partial class PrintInfo
    {
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public bool Finished { get; set; }
        public string Recipe { get; set; } = string.Empty;
        public int Cycles { get; set; }
        public PrintInfo() { }
        public override string ToString() => $"{(Stop - Start).TotalMinutes:f3}\t{Cycles}\n";
    }
}
