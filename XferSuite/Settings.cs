using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace XferSuite
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            propertyGrid.BrowsableAttributes = new AttributeCollection(new CategoryAttribute("User Parameters"));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void CheckForUpdates()
        {
            if (btnCheckForUpdates.BackColor == Color.PaleTurquoise)
                System.Diagnostics.Process.Start(@"https://bradmartin333.github.io/utility/XferSuite");
            btnCheckForUpdates.Text = "Checking For Updates...";
            btnCheckForUpdates.BackColor = Color.White;
            try
            {
                int thisMajorVersion = MainMenu.MajorVersion;
                int thisMinorVersion = MainMenu.MinorVerson;
                string data;
                using (WebClient web = new WebClient())
                {
                    web.Headers.Add("User-Agent: Other");
                    data = web.DownloadString(@"https://api.github.com/repos/bradmartin333/XferSuite/tags");
                }
                Regex rx = new Regex("\"(.*?)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                MatchCollection matches = rx.Matches(data);
                string mostRecentVersion = matches[1].Value.Trim('\\', '\"');
                int mostRecentMajorVersion = int.Parse(mostRecentVersion.Replace("v", "").Split('.').First());
                int mostRecentMinorVersion = int.Parse(mostRecentVersion.Replace("v", "").Split('.').Last());
                if (mostRecentMajorVersion > thisMajorVersion || (mostRecentMajorVersion >= thisMajorVersion && mostRecentMinorVersion > thisMinorVersion))
                {
                    btnCheckForUpdates.Text = mostRecentVersion + " Is Available";
                    btnCheckForUpdates.BackColor = Color.PaleTurquoise;
                }
                else
                {
                    btnCheckForUpdates.Text = "Up To Date";
                    btnCheckForUpdates.BackColor = Color.LightGreen;
                }
            }
            catch (Exception)
            {
                btnCheckForUpdates.Text = "Check Network Connection";
                btnCheckForUpdates.BackColor = Color.LightYellow;
            }
        }

        private void btnCheckForUpdates_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        private void btnViewLicense_Click(object sender, EventArgs e)
        {
            Form form = new Form()
            {
                Text = "XferSuite Licenses",
                Icon = Icon
            };
            RichTextBox textBox = new RichTextBox() { Dock = DockStyle.Fill };
            textBox.Text = System.IO.File.ReadAllText("LicenseInfo.txt");
            form.Controls.Add(textBox);
            form.Show();
        }
    }
}
