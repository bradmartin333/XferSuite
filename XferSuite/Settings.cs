using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace XferSuite
{
    public partial class Settings : Form
    {
        private bool UpdateFound = false;

        public Settings()
        {
            InitializeComponent();
            PropertyGrid.BrowsableAttributes = new AttributeCollection(new CategoryAttribute("User Parameters"));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void CheckForUpdates()
        {
            if (BtnCheckForUpdates.BackColor == Color.PaleTurquoise)
            {
                try
                {
                    PerformUpdate();
                    Application.Exit();
                }
                catch (Exception)
                {
                    System.Diagnostics.Process.Start(@"https://bradmartin333.github.io/utility/XferSuite");
                }
            }
            BtnCheckForUpdates.Text = "Checking For Updates...";
            BtnCheckForUpdates.BackColor = Color.White;
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
                    BtnCheckForUpdates.Text = $"Click here to update to {mostRecentVersion}";
                    BtnCheckForUpdates.BackColor = Color.PaleTurquoise;
                    MainMenu mainMenu = Application.OpenForms.OfType<MainMenu>().First();
                    if (!UpdateFound) mainMenu.Text += $"   {mostRecentVersion} Available";
                    UpdateFound = true;
                }
                else
                {
                    BtnCheckForUpdates.Text = "Up To Date";
                    BtnCheckForUpdates.BackColor = Color.LightGreen;
                }
            }
            catch (Exception)
            {
                BtnCheckForUpdates.Text = "Check Network Connection";
                BtnCheckForUpdates.BackColor = Color.LightYellow;
            }
        }

        private void PerformUpdate()
        {
            string tempPath = Path.GetTempPath() + "XferSuiteSetup.exe";
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("User-Agent: Other");
                web.DownloadFile(@"https://github.com/bradmartin333/XferSuite/raw/master/Setup/XferSuiteSetup.exe", tempPath);
            }
            System.Diagnostics.Process.Start(tempPath);
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
            textBox.Text = Properties.Resources.LicenseInfo.ToString();
            form.Controls.Add(textBox);
            form.Show();
        }

        private void btnViewDocs_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/bradmartin333/XferSuite/wiki");
        }

        private void BtnAdvancedTools_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AdvancedTools>().Any())
                Application.OpenForms.OfType<AdvancedTools>().First().BringToFront();
            else
                _ = new AdvancedTools();
            Close();
        }
    }
}
