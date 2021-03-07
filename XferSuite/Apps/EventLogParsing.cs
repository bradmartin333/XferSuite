using System;
using System.IO;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class EventLogParsing : Form
    {
        public EventLogParsing(string Path)
        {
            InitializeComponent();

            _lines = File.ReadAllLines(Path);

            ParsePrints();
        }

        public string[] _lines;

        private void ParsePrints()
        {
            Parser.Event[] prints = Parser.main(_lines);
            foreach (Parser.Event p in prints)
            {
                rtbPrints.Text += p.Time + Environment.NewLine;
            }
        }
    }
}
