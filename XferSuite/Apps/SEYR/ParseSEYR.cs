using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace XferSuite.Apps.SEYR
{
    public partial class ParseSEYR : Form
    {
        private static readonly string ProjectPath = $@"{Path.GetTempPath()}\project.seyr";
        private static readonly string ReportPath = $@"{Path.GetTempPath()}\SEYRreport.txt";
        public static Project Project { get; set; } = null;
        private List<DataEntry> Data { get; set; } = new List<DataEntry>();

        public ParseSEYR(string path)
        {
            InitializeComponent();
            using (ZipArchive archive = ZipFile.OpenRead(path))
            {
                ExtractFile(ProjectPath, archive);
                ExtractFile(ReportPath, archive);
            }
            LoadProject();
            LoadData();
            RescoreAllData();
            ComboFeatures.Items.AddRange(Data.GroupBy(x => x.FeatureName).Select(x => x.Key).ToArray());
        }

        private void ExtractFile(string path, ZipArchive archive)
        {
            archive.Entries.Where(x => x.Name == path.Split('\\').Last()).First().ExtractToFile(path, true);
        }

        private void LoadProject()
        {
            using (StreamReader stream = new StreamReader(ProjectPath))
            {
                XmlSerializer x = new XmlSerializer(typeof(Project));
                try
                {
                    Project = (Project)x.Deserialize(stream);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Corrupt SEYR Project. Loading default project.\n\n{ex}", "SEYR");
                    Project = new Project();
                    return;
                }
            }
        }

        private void LoadData()
        {
            string[] lines = File.ReadAllLines(ReportPath);
            for (int i = 1; i < lines.Length; i++)
                Data.Add(new DataEntry(lines[i]));
        }

        private void RescoreAllData()
        {
            foreach (DataEntry dataEntry in Data)
            {
                Feature feature = Project.Features.Where(x => x.Name == dataEntry.FeatureName).First();
                bool newState = feature.GenerateState(dataEntry.Score);
                if (dataEntry.State != newState)
                {
                    dataEntry.State = newState;
                    dataEntry.UpdatedState = true;
                }
            }
            System.Diagnostics.Debug.WriteLine($"{Data.Where(x => x.UpdatedState).Count()} Updated States");
        }

        private void BtnRescore_Click(object sender, EventArgs e)
        {

        }

        private void BtnPlot_Click(object sender, EventArgs e)
        {

        }

        private void BtnEditCriteria_Click(object sender, EventArgs e)
        {

        }

        private void BtnExportCycleFile_Click(object sender, EventArgs e)
        {

        }
    }
}
