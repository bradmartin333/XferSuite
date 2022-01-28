using System.Windows.Forms;

namespace XferSuite
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            string info = "Download here: tinyurl.com/DownloadXferSuite\n";
            info += System.IO.File.ReadAllText("README.md").Split('☺')[1];
            rtb.Text = info;
        }
    }
}
