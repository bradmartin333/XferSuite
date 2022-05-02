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
        private readonly string ProjectPath = $@"{Path.GetTempPath()}\project.seyr";
        private readonly string ReportPath = $@"{Path.GetTempPath()}\SEYRreport.txt";
        public static Project Project { get; set; } = null;
        private string DataHeader { get; set; } = string.Empty;
        private List<DataEntry> Data { get; set; } = new List<DataEntry>();
        private List<(int, bool)> Criteria { get; set; } = new List<(int, bool)>();
        private ScatterCriteria[] Scatters { get; set; } = null;

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
            InitFeatureInfo();
        }

        #region Load Data

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
            DataHeader = lines[0];
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
                feature.PassThreshold = feature.PassThreshold == -10 ? (feature.MaxScore + feature.MinScore) / 2.0 : feature.PassThreshold;
                feature.Limit = feature.Limit == -10 ? (feature.FlipScore ? feature.HistData.Min() : feature.HistData.Max()) : feature.Limit;
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

        #endregion

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
                    RescoreAllData();
                    InitFeatureInfo();
                }
                else if (result == DialogResult.Ignore)
                    feature.Ignore = !feature.Ignore;
            }
        }

        private void InitFeatureInfo()
        {
            List<int> criteriaVals = new List<int>();
            List<string> criteriaNames = new List<string>();
            ComboFeatures.Items.Clear();
            for (int i = 0; i < Project.Features.Count; i++)
            {
                int id = (i + 1) * (i + 1);
                string name = Project.Features[i].Name;
                Project.Features[i].ID = id;
                ComboFeatures.Items.Add(name);
                if (Project.Features[i].Ignore) continue;
                criteriaVals.Add(id);
                criteriaNames.Add(name);
            }

            List<int> passingVals = new List<int>();
            foreach (string[] features in Project.Criteria)
            {
                int id = 0;
                foreach (string feature in features)
                    id += Project.Features.Where(x => x.Name == feature).First().ID;
                passingVals.Add(id);
            }

            criteriaVals = criteriaVals.Distinct().ToList();
            foreach (var valCombo in Combinations(criteriaVals))
            {
                int sum = valCombo.Sum();
                if (valCombo.Length > 0) Criteria.Add((sum, passingVals.Contains(sum)));
            }
                
            List<ScatterCriteria> scatters = new List<ScatterCriteria>();
            foreach (var nameCombo in Combinations(criteriaNames))
                if (nameCombo.Length > 0) scatters.Add(new ScatterCriteria(string.Join(", ", nameCombo)));
            Scatters = scatters.ToArray();
        }

        public IEnumerable<T[]> Combinations<T>(IEnumerable<T> source)
        {
            if (null == source)
                throw new ArgumentNullException(nameof(source));

            T[] data = source.ToArray();

            return Enumerable
              .Range(0, 1 << (data.Length))
              .Select(index => data
                 .Where((v, i) => (index & (1 << i)) != 0)
                 .ToArray());
        }

        private void BtnPlot_Click(object sender, EventArgs e)
        {
            Scatters.ToList().ForEach(s => s.Reset());

            var images = Data.GroupBy(x => x.ImageNumber);
            foreach (IGrouping<int, DataEntry> image in images)
            {
                var tiles = image.ToArray().GroupBy(x => (x.TR, x.TC));
                foreach (var tile in tiles)
                {
                    DataEntry[] entries = tile.ToArray();
                    double x = -(entries[0].X + (entries[0].TC * Project.PitchX / Project.PixelsPerMicron / 1e3));
                    double y = entries[0].Y + (entries[0].TR * Project.PitchY / Project.PixelsPerMicron / 1e3);

                    int criterion = 0;
                    foreach (DataEntry entry in entries)
                    {
                        Feature feature = entry.Feature;
                        if (feature.Ignore) continue;
                        if (entry.State) criterion += feature.ID;
                    }

                    bool pass = true;
                    int idx = Criteria.IndexOf((criterion, pass));
                    if (idx == -1)
                    {
                        pass = false;
                        idx = Criteria.IndexOf((criterion, pass));
                    }
                    if (idx == -1)
                        continue;
                    ScatterCriteria scatterCriteria = Scatters[idx];
                    scatterCriteria.X.Add(x);
                    scatterCriteria.Y.Add(y);
                    scatterCriteria.Pass = pass;
                    break;
                }
            }

            Results results = new Results(Scatters);
        }

        private void BtnExportCycleFile_Click(object sender, EventArgs e)
        {

        }

        #region Save Session

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();
            svd.Filter = "SEYRUP file(*.seyrup)| *.seyrup";
            svd.Title = "Save SEYRUP File";
            if (svd.ShowDialog() == DialogResult.OK)
            {
                LabelLoading.Visible = true;
                Application.DoEvents();
                SaveProject();
                SaveReport();
                using (ZipArchive zip = ZipFile.Open(svd.FileName, ZipArchiveMode.Update))
                {
                    zip.CreateEntryFromFile(ReportPath, Path.GetFileName(ReportPath));
                    zip.CreateEntryFromFile(ProjectPath, Path.GetFileName(ProjectPath));
                }
                LabelLoading.Visible = false;
            }
        }

        private void SaveProject()
        {
            using (StreamWriter stream = new StreamWriter(ProjectPath))
            {
                XmlSerializer x = new XmlSerializer(typeof(Project));
                x.Serialize(stream, Project);
            }
        }

        private void SaveReport()
        {
            using (StreamWriter stream = new StreamWriter(ReportPath))
            {
                stream.WriteLine(DataHeader);
                foreach (DataEntry entry in Data)
                    stream.WriteLine(entry.Raw);
            }
        }

        #endregion
    }
}
