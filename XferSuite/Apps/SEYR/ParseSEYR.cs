using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace XferSuite.Apps.SEYR
{
    public partial class ParseSEYR : Form
    {
        public enum Delimeter { Tab, Comma, Space }
        private Delimeter _CycleFileDelimeter = Delimeter.Tab;
        [Category("User Parameters")]
        public Delimeter CycleFileDelimeter { get => _CycleFileDelimeter; set => _CycleFileDelimeter = value; }

        private readonly bool ForceClose;
        private readonly string ProjectPath = $@"{Path.GetTempPath()}\project.seyr";
        private readonly string ReportPath = $@"{Path.GetTempPath()}\SEYRreport.txt";

        public static Project Project { get; set; } = null;
        private string DataHeader { get; set; } = string.Empty;
        private List<DataEntry> Data { get; set; } = new List<DataEntry>();
        private List<(int[], bool, Color)> Criteria { get; set; } = new List<(int[], bool, Color)>();
        private List<DataSheet> Sheets { get; set; } = new List<DataSheet>();
        private readonly ScottPlot.Drawing.Palette Pallete = ScottPlot.Palette.Category20;
        private Size RegionGrid, StampGrid, ImageGrid;       

        public ParseSEYR(string path)
        {
            InitializeComponent();
            using (ZipArchive archive = ZipFile.OpenRead(path))
            {
                ExtractFile(ProjectPath, archive);
                ExtractFile(ReportPath, archive);
            }
            LoadProject();
            if (!LoadData())
            {
                ForceClose = true;
                return;
            }
            RescoreAllData();
            InitFeatureInfo();
        }

        private void ParseSEYR_Load(object sender, EventArgs e)
        {
            if (ForceClose) Close();
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

        private bool LoadData()
        {
            string[] lines = File.ReadAllLines(ReportPath);
            DataHeader = lines[0];
            for (int i = 1; i < lines.Length; i++)
            {
                DataEntry dataEntry = new DataEntry(lines[i]);
                if (dataEntry.HasValidPosition()) Data.Add(dataEntry);
            }

            if (Data.Count == 0)
            {
                MessageBox.Show("Data does not meet XferSuite requirements.", "SEYR");
                return false;
            }

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

            return true;
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
            var combos = Combinations(criteriaVals);
            foreach (var valCombo in combos)
            {
                int sum = valCombo.Sum();
                if (valCombo.Length > 0) Criteria.Add((valCombo, passingVals.Contains(sum), Pallete.GetColor(Criteria.Count)));
            }
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
            if (Application.OpenForms.OfType<RegionBrowser>().Any()) Application.OpenForms.OfType<RegionBrowser>().First().Close();
            if (Application.OpenForms.OfType<LegendView>().Any()) Application.OpenForms.OfType<LegendView>().First().Close();

            if (!MakeSheets()) return;

            foreach (DataSheet sheet in Sheets)
            {
                DataEntry[] region = Data.Where(x => (x.RR, x.RC) == sheet.ID).ToArray();
                var images = region.GroupBy(x => x.ImageNumber);
                foreach (IGrouping<int, DataEntry> image in images)
                {
                    var imageData = image.ToArray();
                    var tiles = imageData.GroupBy(x => (x.TR, x.TC));
                    foreach (var tile in tiles)
                    {
                        DataEntry[] entries = tile.ToArray();
                        int criterion = 0;
                        foreach (DataEntry entry in entries)
                        {
                            Feature feature = entry.Feature;
                            if (feature.Ignore) continue;
                            if (entry.State) criterion += feature.ID;
                        }
                        sheet.Insert(entries[0], criterion);
                    }
                }
            }

            RegionBrowser rb = new RegionBrowser(Data, Sheets, MakeLegendStr());
            LegendView lv = new LegendView(MakeLegend(), rb);
            BtnExportCycleFile.Enabled = true;
        }

        private bool MakeSheets()
        {
            Sheets.Clear();

            int maxR = Data.Select(x => x.R).Max();
            int maxC = Data.Select(x => x.C).Max();
            int maxSR = Data.Select(x => x.SR).Max();
            int maxSC = Data.Select(x => x.SC).Max();
            int maxTR = Data.Select(x => x.TR).Max();
            int maxTC = Data.Select(x => x.TC).Max();
            RegionGrid = new Size(maxR, maxC);
            StampGrid = new Size(maxSR, maxSC);
            ImageGrid = new Size(maxTR, maxTC);

            (int, int)[] regions = Data.Select(x => (x.RR, x.RC)).Distinct().OrderBy(x => x.RR).OrderBy(x => x.RC).ToArray();

            if (regions.Length == 0 || (regions.Length == 1 && regions[0] == (0, 0)))
            {
                MessageBox.Show("Data does not meet XferSuite requirements.", "SEYR");
                return false;
            }

            foreach ((int, int) region in regions)
                Sheets.Add(new DataSheet(region, RegionGrid, StampGrid, ImageGrid, Criteria));

            return true;
        }

        private string MakeLegendStr()
        {
            var criteria = GetUsedCriteria();
            string output = string.Empty;
            foreach (var criterion in criteria)
                output += $"{criterion.Item1.Sum()}\t{GetCriterionString(criterion)}\n";
            return output;
        }

        private Bitmap MakeLegend()
        {
            var criteria = GetUsedCriteria();
            Font font = new Font("Segoe", 16);
            SizeF strSize = SizeF.Empty;
            Bitmap bmp = new Bitmap(1, 1);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (var criterion in criteria)
                {
                    string critStr = GetCriterionString(criterion);
                    SizeF critSize = g.MeasureString(critStr, font);
                    if (critSize.Width > strSize.Width) strSize = critSize;
                }
            }
            strSize = new SizeF(strSize.Width, strSize.Height * 0.9f);
            bmp = new Bitmap((int)strSize.Width, (int)(strSize.Height * criteria.Count));
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int i = 0; i < criteria.Count; i++)
                {
                    Color c = criteria[i].Item3;
                    g.FillRectangle(new SolidBrush(c), 0, i * strSize.Height, strSize.Width, strSize.Height);
                    SolidBrush contrastBrush = new SolidBrush((((0.299 * c.R) + (0.587 * c.G) + (0.114 * c.B)) / 255) > 0.5 ? Color.Black : Color.White);
                    g.DrawString(GetCriterionString(criteria[i]), font, contrastBrush, new PointF(0, i * strSize.Height));
                }
            }
            return bmp;
        }

        private List<(int[], bool, Color)> GetUsedCriteria()
        {
            List<(int[], bool, Color)> criteria = new List<(int[], bool, Color)>();
            foreach (var criterion in Criteria)
            {
                bool valid = true;
                foreach (int val in criterion.Item1)
                {
                    if (Project.Features[(int)(Math.Sqrt(val) - 1)].Ignore)
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid) criteria.Add(criterion);
            }
            return criteria;
        }

        private string GetCriterionString((int[], bool, Color) criterion)
        {
            string output = string.Empty;
            foreach (int val in criterion.Item1)
                output += Project.Features[(int)(Math.Sqrt(val) - 1)].Name + "-";
            return output.Substring(0, output.Length - 1);
        }

        private void BtnExportCycleFile_Click(object sender, EventArgs e)
        {
            Form form = new Form() { Text = "Cycle File" };
            RichTextBox rtb = new RichTextBox() { 
                Dock = DockStyle.Fill,
                Text = MakeCycleFileHeader(),
            };
            form.Controls.Add(rtb);
            int idx = 0;
            foreach (DataSheet sheet in Sheets)
            {
                string lines = sheet.CreateCycleFile(ref idx);
                ApplyDelimeter(ref lines);
                rtb.Text += lines;
            }
            form.Show();
        }

        private string MakeCycleFileHeader()
        {
            string output = "UniqueID, Pick.WaferID, Pick.RegionRow, Pick.RegionColumn, Pick.Row, Pick.Column, Pick.Index, Place.WaferID, Place.RegionRow, Place.RegionColumn, Place.Row, Place.Column\n";
            ApplyDelimeter(ref output);
            return output;
        }

        private void ApplyDelimeter(ref string txt)
        {
            switch (_CycleFileDelimeter)
            {
                case Delimeter.Tab:
                    txt = txt.Replace(", ", "\t");
                    break;
                case Delimeter.Space:
                    txt = txt.Replace(", ", " ");
                    break;
                case Delimeter.Comma:
                default:
                    break;
            }
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
