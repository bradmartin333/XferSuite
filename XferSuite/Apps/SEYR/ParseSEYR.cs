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

        private bool _FlipX = false;
        [Category("User Parameters")]
        public bool FlipX { get => _FlipX; set => _FlipX = value; }

        private bool _FlipY = true;
        [Category("User Parameters")]
        public bool FlipY { get => _FlipY; set => _FlipY = value; }

        private readonly bool ForceClose;
        private readonly string ProjectPath = $@"{Path.GetTempPath()}\project.seyr";
        private readonly string ReportPath = $@"{Path.GetTempPath()}\SEYRreport.txt";

        public static Project Project { get; set; } = null;
        private string DataHeader { get; set; } = string.Empty;
        private List<DataEntry> Data { get; set; } = new List<DataEntry>();
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
            ValidateRegions();
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

        private bool LoadData(bool swap = false)
        {
            Data.Clear();
            string[] lines = File.ReadAllLines(ReportPath);
            DataHeader = lines[0];
            for (int i = 1; i < lines.Length; i++)
            {
                DataEntry dataEntry = new DataEntry(lines[i], swap);
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
                if (feature.HistData.Length == 0)
                {
                    feature.HistData = new double[] { 0 };
                    System.Diagnostics.Debug.WriteLine($"{feature.Name} is empty");
                }
                else if (feature.MinScore == float.MaxValue || feature.MaxScore == float.MinValue || feature.MinScore == feature.MaxScore)
                {
                    if (feature.HistData.Length == 0)
                    {
                        feature.HistData = new double[] { 0 };
                        System.Diagnostics.Debug.WriteLine($"{feature.Name} has no valid data");
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

        private void ValidateRegions()
        {
            int maxRR = Data.Select(x => x.RR).Max();
            int maxR = Data.Select(x => x.R).Max();
            if (maxR == 1 && maxRR > 1)
            {
                DialogResult result = MessageBox.Show(
                    "The RR/RC indices outrank the R/C indices, which will cause rendering issues. Would you like to swap RR with R and RC with C?",
                    "Parse SEYR", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    LoadProject();
                    LoadData(true);
                }
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
                if (string.IsNullOrEmpty(feature.CriteriaString))
                    feature.CriteriaString = feature.Name;
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
            ComboFeatures.Text = feature.Name;
        }

        private void InitFeatureInfo()
        {
            ComboFeatures.Items.Clear();
            for (int i = 0; i < Project.Features.Count; i++)
            {
                Feature feature = Project.Features[i];
                ComboFeatures.Items.Add(feature.Name);
                if (Project.Features[i].Ignore) continue;
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

            List<(int, Color, string, bool)> matchedCriteria = new List<(int, Color, string, bool)>();

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
                        (int, Color, string, bool) match = FindMatchingCriteria(entries, matchedCriteria.Count);
                        if (!matchedCriteria.Select(x => x.Item1).ToList().Contains(match.Item1))
                            matchedCriteria.Add(match);
                        sheet.Insert(entries[0], match.Item1, match.Item2, match.Item4);
                    }
                }
            }

            RegionBrowser rb = new RegionBrowser(Data, Sheets, matchedCriteria);
            LegendView lv = new LegendView(MakeLegend(matchedCriteria), rb);
            BtnMakeCycleFile.Enabled = true;
        }

        private (int ID, Color c, string str, bool pass) FindMatchingCriteria(DataEntry[] entries, int colorIdx)
        {
            int passingID = 0;
            string passingNames = string.Empty;
            bool pass = true;

            var redundantGroups = entries.GroupBy(x => x.Feature.RedundancyGroup);
            foreach (var group in redundantGroups)
            {
                var needOneGroups = group.ToArray().GroupBy(x => x.Feature.NeedOneGroup).ToArray();
                for (int i = 0; i < needOneGroups.Length; i++)
                {
                    DataEntry[] needOneEntries = needOneGroups[i].ToArray();
                    if (needOneEntries.Where(x => x.State).Any())
                    {
                        passingID += (i + 1) * (i + 1);
                        passingNames += $"{needOneGroups[i].Key}\t";
                    }
                    else
                        pass = false;
                }
            }

            return (passingID, Pallete.GetColor(colorIdx), passingNames, pass);
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
                Sheets.Add(new DataSheet(region, RegionGrid, StampGrid, ImageGrid, _FlipX, _FlipY));

            return true;
        }

        private Bitmap MakeLegend(List<(int, Color, string, bool)> matches)
        {
            if (matches.Count == 0) return null;
            Font font = new Font("Segoe", 16);
            SizeF strSize = SizeF.Empty;
            Bitmap bmp = new Bitmap(1, 1);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (var criterion in matches)
                {
                    SizeF critSize = g.MeasureString(criterion.Item3, font);
                    if (critSize.Width > strSize.Width) strSize = critSize;
                }
            }
            strSize = new SizeF(strSize.Width, strSize.Height * 0.9f);
            bmp = new Bitmap((int)strSize.Width, (int)(strSize.Height * matches.Count));
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    Color c = matches[i].Item2;
                    g.FillRectangle(new SolidBrush(c), 0, i * strSize.Height, strSize.Width, strSize.Height);
                    SolidBrush contrastBrush = new SolidBrush((((0.299 * c.R) + (0.587 * c.G) + (0.114 * c.B)) / 255) > 0.5 ? Color.Black : Color.White);
                    g.DrawString(matches[i].Item3, font, contrastBrush, new PointF(0, i * strSize.Height));
                }
            }
            return bmp;
        }

        private void BtnMakeCycleFile_Click(object sender, EventArgs e)
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
