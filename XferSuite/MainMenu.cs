using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XferSuite
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            foreach (Button b in tableLayoutPanel.Controls.OfType<Button>())
            {
                ToolTip tip = new ToolTip { InitialDelay = 0 };
                tip.SetToolTip(b, b.AccessibleName);
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDataFileTree_Click(object sender, EventArgs e)
        {
            DataFileTree.frmDataFileTreeMain DFT = new DataFileTree.frmDataFileTreeMain();
            DFT.Show();
        }
    }
}
