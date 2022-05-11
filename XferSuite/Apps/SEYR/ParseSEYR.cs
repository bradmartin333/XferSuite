using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private static bool _FlipX = true;
        [Category("User Parameters")]
        public bool FlipX { get => _FlipX; set => _FlipX = value; }
        public static int XSign { get => _FlipX ? -1 : 1; }

        private static bool _FlipY = true;
        [Category("User Parameters")]
        public bool FlipY { get => _FlipY; set => _FlipY = value; }
        public static int YSign { get => _FlipY ? -1 : 1; }

        private readonly string ProjectPath = $@"{Path.GetTempPath()}\project.seyr";
        private readonly string ReportPath = $@"{Path.GetTempPath()}\SEYRreport.txt";
        public static Project Project { get; set; } = null;
        private string DataHeader { get; set; } = string.Empty;
        private List<DataEntry> Data { get; set; } = new List<DataEntry>();
        private List<(int, bool)> Criteria { get; set; } = new List<(int, bool)>();
        private List<RegionInfo> Regions { get; set; } = new List<RegionInfo>();
        private List<ScatterCriteria> Scatters { get; set; } = null;

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

        private bool ExtractFile(string path, ZipArchive archive)
        {
            var matches = archive.Entries.Where(x => x.Name == path.Split('\\').Last());
            if (matches.Any()) matches.First().ExtractToFile(path, true);
            else return false;
            return true;
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

            (int, int)[] regions = Data.Select(x => (x.RR, x.RC)).Distinct().OrderBy(x => x.RR).OrderBy(x => x.RC).ToArray();
            foreach ((int, int) region in regions)
                Regions.Add(new RegionInfo(region));

            foreach (Feature feature in Project.Features)
            {
                feature.Data = Data.Where(x => x.FeatureName == feature.Name).ToArray();
                feature.HistData = feature.Data.Select(x => (double)x.Score).Where(x => x > 0).ToArray();
                if (feature.MinScore == float.MaxValue || feature.MaxScore == float.MinValue || feature.MinScore == feature.MaxScore)
                {
                    if (feature.HistData.Length == 0)
                    {
                        feature.HistData = new double[] { 0 };
                        System.Diagnostics.Debug.WriteLine($"{feature.Name} is empty");
                    }
                    else
                    {
                        feature.MinScore = (float)feature.HistData.Min();
                        feature.MaxScore = (float)feature.HistData.Max();
                        System.Diagnostics.Debug.WriteLine($"{feature.Name} min/max updated");
                    }
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
                int updated = 0;
                foreach (DataEntry entry in feature.Data)
                {
                    bool newState = feature.GenerateState(entry.Score);
                    if (entry.State != newState)
                    {
                        updated++;
                        entry.State = newState;
                    }
                }
                System.Diagnostics.Debug.WriteLine($"{feature.Name} {updated} updated states");
            }
        }

        #endregion

        private void BtnRescore_Click(object sender, EventArgs e)
        {
            if (ComboFeatures.SelectedIndex == -1) return;
            LabelLoading.Visible = true;
            Application.DoEvents();
            Feature feature = Project.Features.Where(x => x.Name == ComboFeatures.Text).First();
            using (PassFailUtility pf = new PassFailUtility(Data, feature))
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
                Feature feature = Project.Features[i];
                int id = (i + 1) * (i + 1);
                string name = feature.Name;
                feature.ID = id;
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
                
            Scatters = new List<ScatterCriteria>();
            foreach (var nameCombo in Combinations(criteriaNames))
                if (nameCombo.Length > 0) Scatters.Add(new ScatterCriteria(string.Join(", ", nameCombo)));
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
            Scatters.ForEach(s => s.Reset());
            Regions.ForEach(r => r.Reset());

            var images = Data.GroupBy(x => x.ImageNumber);
            foreach (IGrouping<int, DataEntry> image in images)
            {
                var tiles = image.ToArray().GroupBy(x => (x.TR, x.TC));
                foreach (var tile in tiles)
                {
                    DataEntry[] entries = tile.ToArray();
                    double x = XSign * (entries[0].X + (entries[0].TC * Project.PitchX / Project.PixelsPerMicron / 1e3));
                    double y = YSign * (entries[0].Y + (entries[0].TR * Project.PitchY / Project.PixelsPerMicron / 1e3));
                    RegionInfo region = Regions.Where(r => r.ID == (entries[0].RR, entries[0].RC)).First();
                    region.Total++;

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
                    scatterCriteria.BaseX.Add(entries[0].X);
                    scatterCriteria.BaseY.Add(entries[0].Y);
                    scatterCriteria.X.Add(x);
                    scatterCriteria.Y.Add(y);
                    scatterCriteria.Pass = pass;

                    if (pass) region.Pass++;
                }
            }

            Results results = new Results(Data, Scatters, Regions);
        }

        private void BtnExportCycleFile_Click(object sender, EventArgs e)
        {
            Form form = new Form() { Text = "Cycle File" };
            RichTextBox rtb = new RichTextBox() { Dock = DockStyle.Fill };
            form.Controls.Add(rtb);
            rtb.Text = "Coming soon";
            form.Show();
        }

        #region Save Session

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog
            {
                Filter = "SEYRUP file(*.seyrup)| *.seyrup",
                Title = "Save SEYRUP File"
            };
            if (svd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(svd.FileName)) File.Delete(svd.FileName);
                LabelLoading.Text = "Saving...";
                LabelLoading.Visible = true;
                Application.DoEvents();
                SaveProject();
                SaveReport();
                using (ZipArchive zip = ZipFile.Open(svd.FileName, ZipArchiveMode.Create))
                {
                    zip.CreateEntryFromFile(ReportPath, Path.GetFileName(ReportPath));
                    zip.CreateEntryFromFile(ProjectPath, Path.GetFileName(ProjectPath));
                }
                LabelLoading.Visible = false;
                LabelLoading.Text = "Loading...";
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
