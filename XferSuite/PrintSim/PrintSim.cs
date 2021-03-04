using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static XferSuite.Parameters;

namespace XferSuite
{
    public partial class PrintSim : Form
    {
        private bool _WatchFile = true;
        [
            Category("User Parameters"),
            Description("Monitor loaded .xrec for file changes")
        ]
        public bool WatchFile
        {
            get => _WatchFile;
            set
            {
                _WatchFile = value;
            }
        }

        public PrintSim(string path)
        {
            InitializeComponent();
            LoadRecipe(path);
            MakePlot();
        }
        
        private void btnOpenMap_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

        }

        private void plot_DoubleClick(object sender, EventArgs e)
        {

        }

        private void MakePlot()
        {

        }
    }
}
