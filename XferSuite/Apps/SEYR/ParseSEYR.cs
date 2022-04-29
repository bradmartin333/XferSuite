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

            foreach (Feature feature in Project.Features)
            {
                feature.Data = Data.Where(x => x.FeatureName == feature.Name).ToArray();
                feature.HistData = feature.Data.Select(x => (double)x.Score).Where(x => x > 0).ToArray();
                if (feature.MinScore == float.MaxValue || feature.MaxScore == float.MinValue || feature.MinScore == feature.MaxScore)
                {
                    feature.MinScore = (float)feature.HistData.Min();
                    feature.MaxScore = (float)feature.HistData.Max();
                    System.Diagnostics.Debug.WriteLine($"{feature.Name} min/max updated");
                }
                feature.PassThreshold = (feature.MaxScore - feature.MinScore) / 2;
                feature.Limit = feature.FlipScore ? feature.HistData.Min() : feature.HistData.Max();
                System.Diagnostics.Debug.WriteLine($"{feature.Name} Min = {feature.MinScore} Max = {feature.MaxScore}");
            }
        }

        private void RescoreAllData()
        {
            foreach (Feature feature in Project.Features)
            {
                foreach (DataEntry entry in feature.Data)
                {
                    bool newState = feature.GenerateState(entry.Score);
                    if (entry.State != newState)
                    {
                        entry.State = newState;
                        entry.UpdatedState = true;
                    }
                }
                System.Diagnostics.Debug.WriteLine($"{feature.Name} {Data.Where(x => x.UpdatedState).Count()} updated states");
            }
        }

        private void BtnRescore_Click(object sender, EventArgs e)
        {
            if (ComboFeatures.SelectedIndex == -1) return;
            LabelLoading.Visible = true;
            Application.DoEvents();
            Feature feature = Project.Features.Where(x => x.Name == ComboFeatures.Text).First();
            using (PassFailUtility pf = new PassFailUtility(feature))
            {
                LabelLoading.Visible = false;
                Application.DoEvents();
                DialogResult result = pf.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (feature.PassThreshold != pf.PassThreshold)
                    {
                        System.Diagnostics.Debug.WriteLine($"{feature.Name} PassThreshold updated from {feature.PassThreshold} to {pf.PassThreshold}");
                        feature.PassThreshold = pf.PassThreshold;
                    }
                    if (feature.Limit != pf.Limit)
                    {
                        System.Diagnostics.Debug.WriteLine($"{feature.Name} Limit updated from {feature.Limit} to {pf.Limit}");
                        feature.Limit = pf.Limit;
                    }
                }
            }
        }

        private void BtnPlot_Click(object sender, EventArgs e)
        {

        }

        private void BtnExportCycleFile_Click(object sender, EventArgs e)
        {

        }
    }
}
