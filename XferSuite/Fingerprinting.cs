using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class Fingerprinting : Form
    {
        public Fingerprinting(Metro.Position[] data)
        {
            InitializeComponent();
            _raw = data;

            string[] indices = Metro.prints(_raw);
            int printIdx = 1;
            int posIdx = 0;
            foreach (string index in indices)
            {
                if (!_prints.Contains(index))
                {
                    _prints.Add(index);
                    PrintList.Items.Add(index);
                    printIdx += 1;
                }
                _raw[posIdx].PrintNum = printIdx;
                posIdx += 1;
            }
        }

        private Metro.Position[] _raw;
        List<string> _prints = new List<string>();

        private void PrintList_SelectedIndexChanged(object sender, EventArgs e)
        {
            plot.BackColor = Color.Green;
        }
    }
}
