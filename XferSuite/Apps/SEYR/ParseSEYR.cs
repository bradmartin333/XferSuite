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
        #region Globals and Setup

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

        public enum Palletes { Category20, ColorblindFriendly, Microcharts, OneHalf }
        [Category("User Parameters")]
        public Palletes Palette {
            get => (Palletes)Enum.Parse(typeof(Palletes), Criteria.Palette.Name);
            set
            {
                switch (value)
                {
                    case Palletes.Category20:
                        Criteria.Palette = ScottPlot.Drawing.Palette.Category20;
                        break;
                    case Palletes.ColorblindFriendly:
                        Criteria.Palette = ScottPlot.Drawing.Palette.ColorblindFriendly;
                        break;
                    case Palletes.Microcharts:
                        Criteria.Palette = ScottPlot.Drawing.Palette.Microcharts;
                        break;
                    case Palletes.OneHalf:
                        Criteria.Palette = ScottPlot.Drawing.Palette.OneHalf;
                        break;
                }
            }
        }

        private readonly bool ForceClose;
        private readonly string FileName;
        private readonly string ProjectPath = $@"{Path.GetTempPath()}project.seyr";
        private readonly string ReportPath = $@"{Path.GetTempPath()}SEYRreport.txt";

        public static Project Project { get; set; } = null;
        private List<DataEntry> Data { get; set; } = new List<DataEntry>();
        private List<DataSheet> Sheets { get; set; } = new List<DataSheet>();
        private RegionBrowser RegionBrowser { get; set; } = null;

        public ParseSEYR(string path)
        {
            InitializeComponent();
            FileInfo userPath = new FileInfo(path);
            FileName = userPath.Name.Replace(userPath.Extension, "");
            Text = FileName;

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

            FeatureOLV.DoubleClick += FeatureOLV_DoubleClick;
            FeatureOLV.KeyDown += FeatureOLV_KeyDown;
            CriteriaOLV.DoubleClick += CriteriaOLV_DoubleClick;
            CriteriaOLV.FormatRow += CriteriaOLV_FormatRow;
            FormClosing += ParseSEYR_FormClosing;
        }

        private void ParseSEYR_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete(ProjectPath);
            File.Delete(ReportPath);
        }

        private void ParseSEYR_Load(object sender, EventArgs e)
        {
            if (ForceClose) Close();
        }

        #endregion

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
            DataEntry.Header = lines[0];
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
                foreach (DataEntry entry in feature.Data)
                    entry.State = feature.GenerateState(entry.Score);
                if (string.IsNullOrEmpty(feature.CriteriaString))
                    feature.CriteriaString = System.Text.RegularExpressions.Regex.Replace(feature.Name, @"\d", "");
            }
        }

        private void ResetCriteiraGroupingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Feature feature in Project.Features)
                feature.CriteriaString = System.Text.RegularExpressions.Regex.Replace(feature.Name, @"\d", "");
            InitFeatureInfo();
        }

        private void ResetCriteriaPlotSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CriteriaOLV.ClearObjects();
        }

        #endregion

        #region OLV Logic

        private void FeatureOLV_DoubleClick(object sender, EventArgs e)
        {
            if (FeatureOLV.SelectedObject != null)
            {
                LoadingToolStripMenuItem.Visible = true;
                Application.DoEvents();
                Feature feature = ((Feature)FeatureOLV.SelectedObject);
                using (PassFailUtility pf = new PassFailUtility(Data, feature))
                {
                    LoadingToolStripMenuItem.Visible = false;
                    Application.DoEvents();
                    DialogResult result = pf.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        feature.PassThreshold = pf.PassThreshold;
                        feature.Limit = pf.Limit;
                        RescoreAllData();
                        InitFeatureInfo();
                    }
                    else if (result == DialogResult.Ignore)
                        feature.Ignore = !feature.Ignore;
                }
            }
        }

        private void GroupFeaturesIntoCriteriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupFeatures();
        }

        private void FeatureOLV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G && FeatureOLV.SelectedObjects.Count > 1) GroupFeatures();
        }

        private void GroupFeatures()
        {
            using (Utility.PromptForInput prompt = new Utility.PromptForInput("Enter criteria string"))
            {
                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    foreach (Feature item in FeatureOLV.SelectedObjects)
                        item.CriteriaString = prompt.Control.Text;
                    InitFeatureInfo();
                }
            }
        }

        private void CriteriaOLV_DoubleClick(object sender, EventArgs e)
        {
            if (CriteriaOLV.SelectedObject == null) return;
            Criteria criteria = (Criteria)CriteriaOLV.SelectedObject;
            using (ColorDialog colorDialog = new ColorDialog() { AllowFullOpen = true, AnyColor = true, Color = criteria.Color })
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    criteria.Color = colorDialog.Color;
                    CriteriaOLV.RebuildColumns();
                    CriteriaOLV.DeselectAll();
                }
            }
        }

        private void CriteriaOLV_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            Color c = ((Criteria)e.Model).Color;
            e.Item.BackColor = c;
            e.Item.ForeColor = (((0.299 * c.R) + (0.587 * c.G) + (0.114 * c.B)) / 255) > 0.5 ? Color.Black : Color.White;
        }

        private void InitFeatureInfo()
        {
            FeatureOLV.Objects = Project.Features;
        }

        #endregion

        #region Plotting

        private void PlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadingToolStripMenuItem.Visible = true;
            Application.DoEvents();

            if (Application.OpenForms.OfType<RegionBrowser>().Any()) Application.OpenForms.OfType<RegionBrowser>().First().Close();
            if (Application.OpenForms.OfType<Inspection>().Any()) Application.OpenForms.OfType<Inspection>().First().Close();

            if (!MakeSheets()) return;

            List<Criteria> criteria = new List<Criteria>();
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
                        Criteria criterion = new Criteria(entries);

                        if (CriteriaOLV.Objects != null) // Allow user override
                        {
                            Criteria[] matches = ((List<Criteria>)CriteriaOLV.Objects).Where(x => x.LegendEntry == criterion.LegendEntry).ToArray();
                            if (matches.Any())
                            {
                                criterion.Override = true;
                                criterion.Pass = matches[0].Pass;
                                criterion.Color = matches[0].Color;
                            }
                        }

                        criterion.TryAppend(ref criteria);
                        sheet.Insert(entries, criterion);
                    }
                }
            }

            CriteriaOLV.Objects = criteria;
            MakeCycleFileToolStripMenuItem.Enabled = true;
            TogglePassFailToolStripMenuItem.Enabled = true;
            LoadingToolStripMenuItem.Visible = false;
            RegionBrowser = new RegionBrowser(
                Data, Sheets, criteria, TogglePassFailToolStripMenuItem.Checked)
            { Text = FileName };
        }

        private bool MakeSheets()
        {
            Sheets.Clear();
            (int, int)[] regions = Data.Select(x => (x.RR, x.RC)).Distinct().OrderBy(x => x.RR).OrderBy(x => x.RC).ToArray();
            if (regions.Length == 0 || (regions.Length == 1 && regions[0] == (0, 0)))
            {
                MessageBox.Show("Data does not meet XferSuite requirements.", "SEYR");
                return false;
            }
            foreach ((int, int) region in regions)
                Sheets.Add(new DataSheet(
                    region, 
                    new Size(Data.Select(x => x.R).Max(), Data.Select(x => x.C).Max()), 
                    new Size(Data.Select(x => x.SR).Max(), Data.Select(x => x.SC).Max()), 
                    new Size(Data.Select(x => x.TR).Max(), Data.Select(x => x.TC).Max()), 
                    _FlipX, _FlipY));

            return true;
        }

        private void TogglePassFailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegionBrowser.TogglePF(TogglePassFailToolStripMenuItem.Checked);
        }

        #endregion

        #region Cycle File

        private void MakeCycleFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadingToolStripMenuItem.Visible = true;
            Application.DoEvents();

            Form form = new Form() { Text = "Cycle File" };
            RichTextBox rtb = new RichTextBox()
            {
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

            LoadingToolStripMenuItem.Visible = false;
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

        #endregion

        #region Save Session

        private void SaveAsNewSEYRUPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog
            {
                Filter = "SEYRUP file(*.seyrup)| *.seyrup",
                Title = "Save SEYRUP File"
            };
            if (svd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(svd.FileName)) File.Delete(svd.FileName);
                LoadingToolStripMenuItem.Text = "Saving...";
                LoadingToolStripMenuItem.Visible = true;
                Application.DoEvents();
                SaveProject();
                SaveReport();
                using (ZipArchive zip = ZipFile.Open(svd.FileName, ZipArchiveMode.Create))
                {
                    zip.CreateEntryFromFile(ReportPath, Path.GetFileName(ReportPath));
                    zip.CreateEntryFromFile(ProjectPath, Path.GetFileName(ProjectPath));
                }
                LoadingToolStripMenuItem.Visible = false;
                LoadingToolStripMenuItem.Text = "Loading...";
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
                stream.WriteLine(DataEntry.Header);
                foreach (DataEntry entry in Data)
                    stream.WriteLine(entry.Raw);
            }
        }

        #endregion
    }
}
