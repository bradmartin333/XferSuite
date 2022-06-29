using System;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class CycleFileViewer : Form
    {
        public CycleFileViewer(string header, string file)
        {
            InitializeComponent();
            TxtHeader.Text = header;
            RTB.Text = file;
            Show();
        }

        private void BtnCopyCycleFile_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RTB.Text);
        }
    }
}
