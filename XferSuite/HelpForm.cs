﻿using System.Windows.Forms;

namespace XferSuite
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            rtb.Text = Properties.Resources.help;
        }
    }
}
