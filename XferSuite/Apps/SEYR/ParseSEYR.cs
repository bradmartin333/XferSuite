﻿using System;
using System.Collections;
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
        private List<int> Criteria { get; set; } = new List<int>();
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
                feature.PassThreshold = (feature.MaxScore + feature.MinScore) / 2.0;
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

        private void InitFeatureInfo()
        {
            List<int> criteriaVals = new List<int>();
            List<string> criteriaNames = new List<string>();
            for (int i = 0; i < Project.Features.Count; i++)
            {
                int id = (i + 1) * (i + 1);
                string name = Project.Features[i].Name;
                Project.Features[i].ID = id;
                ComboFeatures.Items.Add(name);
                criteriaVals.Add(id);
                criteriaNames.Add(name);
            }

            //foreach (string[] features in Project.Criteria)
            //{
            //    int id = 0;
            //    string name = string.Empty;
            //    foreach (string feature in features)
            //    {
            //        id += Project.Features.Where(x => x.Name == feature).First().ID;
            //        name += feature + " ";
            //    }
            //    criteriaVals.Add(id);
            //    criteriaNames.Add(name);
            //}

            criteriaVals = criteriaVals.Distinct().ToList();
            foreach (var valCombo in Combinations(criteriaVals))
                if (valCombo.Length > 0) Criteria.Add(valCombo.Sum());

            List<ScatterCriteria> scatters = new List<ScatterCriteria>();
            foreach (var nameCombo in Combinations(criteriaNames))
                if (nameCombo.Length > 0) scatters.Add(new ScatterCriteria(string.Join(", ", nameCombo)));
            Scatters = scatters.ToArray();
        }

        public static IEnumerable<T[]> Combinations<T>(IEnumerable<T> source)
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
                        if (entry.State) criterion += entry.Feature.ID;
                    
                    int idx = Criteria.IndexOf(criterion);
                    if (idx == -1) continue;
                    ScatterCriteria scatterCriteria = Scatters[idx];
                    scatterCriteria.X.Add(x);
                    scatterCriteria.Y.Add(y);
                    break;
                }
            }

            Results results = new Results(Scatters);
        }

        private void BtnExportCycleFile_Click(object sender, EventArgs e)
        {

        }
    }
}
