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

        private int _NumberImagesInScroller = 25;
        [
            Category("User Parameters"),
            Description("The more images loaded when clicking a histogram bar, the longer the form will take to load"),
            DisplayName("# Images in Scroller")
        ]
        public int NumberImagesInScroller { get => _NumberImagesInScroller; set => _NumberImagesInScroller = value; }

        private int _DefaultPlotSize = 700;
        [
            Category("User Parameters"),
            Description("Autoscaling will be applied to this starting X by Y square dimension"),
            DisplayName("Default Plot Window Size")
        ]
        public int DefaultPlotSize { get => _DefaultPlotSize; set => _DefaultPlotSize = value; }

        public enum Delimeter { Tab, Comma, Space }
        private Delimeter _CycleFileDelimeter = Delimeter.Tab;
        [
            Category("User Parameters"),
            Description("Tabs are excel friendly, but some tools take comma separated values"),
            DisplayName("Cycle File Delimeter")
        ]
        public Delimeter CycleFileDelimeter { get => _CycleFileDelimeter; set => _CycleFileDelimeter = value; }

        private bool _FlipX = false;
        [
            Category("User Parameters"),
            Description("Invert the X direction in the plot window"),
            DisplayName("Flip X")
        ]
        public bool FlipX { get => _FlipX; set => _FlipX = value; }

        private bool _FlipY = true;
        [
            Category("User Parameters"),
            Description("Invert the Y direction in the plot window"),
            DisplayName("Flip Y")
        ]
        public bool FlipY { get => _FlipY; set => _FlipY = value; }

        public enum Palletes { Category20, ColorblindFriendly, Microcharts, OneHalf }
        [
            Category("User Parameters"),
            Description("There are currently 4 available palletes"),
            DisplayName("Plot Window Pallete")
        ]
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

        private Font _YieldFont = new Font("Segoe", 10.0f);
        [
            Category("User Parameters"),
            Description("Yield % font in the  plot window"),
            DisplayName("Yield Font")
        ]
        public Font YieldFont { get => _YieldFont; set => _YieldFont = value; }

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
            FeatureOLV.CellRightClick += FeatureOLV_CellRightClick;
            CriteriaOLV.DoubleClick += CriteriaOLV_DoubleClick;
            CriteriaOLV.FormatRow += CriteriaOLV_FormatRow;
            CriteriaOLV.CellRightClick += CriteriaOLV_CellRightClick;
            CriteriaOLV.SelectedBackColor = Color.White;
            CriteriaOLV.SelectedForeColor = Color.Magenta;
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

        private void ToggleInfo(string info, Color color)
        {
            BtnPlot.Text = info;
            BtnPlot.BackColor = color;
            Application.DoEvents();
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
                if (!dataEntry.Complete) break;
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

        #endregion

        #region OLV Logic

        private void FeatureOLV_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            FeatureEditToolStripMenuItem.Visible = FeatureOLV.SelectedObjects.Count == 1;
            if (FeatureOLV.SelectedObjects.Count > 0) e.MenuStrip = FeatureMenuStrip;
        }

        private void CriteriaOLV_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            if (CriteriaOLV.SelectedObjects.Count > 0) e.MenuStrip = CriteriaMenuStrip;
        }

        private void FeatureOLV_DoubleClick(object sender, EventArgs e)
        {
            if (FeatureOLV.SelectedObject != null) EditFeature((Feature)FeatureOLV.SelectedObject);
        }

        private void FeatureEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FeatureOLV.SelectedObject != null) EditFeature((Feature)FeatureOLV.SelectedObject);
        }

        private void FeatureOLV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G && FeatureOLV.SelectedObjects.Count > 1) GroupFeatures(ModifierKeys == Keys.Shift);
        }

        private void FeatureGroupNeedOneToolStripMenuItem_Click(object sender, EventArgs e) => GroupFeatures(false);

        private void FeatureGroupRedundantToolStripMenuItem_Click(object sender, EventArgs e) => GroupFeatures(true);

        private void FeatureResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Feature feature in FeatureOLV.SelectedObjects)
                feature.CriteriaString = System.Text.RegularExpressions.Regex.Replace(feature.Name, @"\d", "");
            InitFeatureInfo();
        }

        private void CriteriaOLV_DoubleClick(object sender, EventArgs e)
        {
            if (CriteriaOLV.SelectedObject == null) return;
            EditCriteriaColor(new List<Criteria>() { (Criteria)CriteriaOLV.SelectedObject });
        }

        private void CriteriaEditColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Criteria> criteria = GetSelectedCriteria();
            if (criteria.Count > 0) EditCriteriaColor(criteria);
        }

        private void CriteriaResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CriteriaOLV.RemoveObjects(CriteriaOLV.SelectedObjects);
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

        private List<Criteria> GetAllCriteria()
        {
            List<Criteria> criteria = new List<Criteria>();
            if (CriteriaOLV.Objects == null) return criteria;
            foreach (Criteria criterion in CriteriaOLV.Objects)
                criteria.Add(criterion);
            return criteria;
        }

        private List<Criteria> GetSelectedCriteria()
        {
            List<Criteria> criteria = new List<Criteria>();
            foreach (Criteria criterion in CriteriaOLV.SelectedObjects)
                criteria.Add(criterion);
            return criteria;
        }

        #endregion

        #region OLV Object Manipulation

        private void EditFeature(Feature feature)
        {
            ToggleInfo("Loading...", Color.Bisque);
            Application.DoEvents();
            using (PassFailUtility pf = new PassFailUtility(Data, feature, NumberImagesInScroller))
            {
                ToggleInfo("Plot", Color.LightBlue);
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

        private void GroupFeatures(bool redundantGroup)
        {
            using (Utility.PromptForInput prompt = new Utility.PromptForInput($"Enter {(redundantGroup ? "redundant group " : "")}criteria string"))
            {
                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    foreach (Feature item in FeatureOLV.SelectedObjects)
                    {
                        if (redundantGroup) 
                            item.CriteriaString = $"{prompt.Control.Text}_{item.NeedOneGroup}";
                        else
                            item.CriteriaString = $"{(string.IsNullOrEmpty(item.RedundancyGroup) ? "" : $"{item.RedundancyGroup}_")}{prompt.Control.Text}";
                    }
                    InitFeatureInfo();
                }
            }
        }

        private void EditCriteriaColor(List<Criteria> criteria)
        {
            Color c = Color.Black;
            if (criteria.Count == 1) c = criteria[0].Color;
            using (ColorDialog colorDialog = new ColorDialog() { AllowFullOpen = true, AnyColor = true, Color = c })
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (Criteria criterion in criteria)
                        criterion.Color = colorDialog.Color;
                    CriteriaOLV.RebuildColumns();
                    CriteriaOLV.DeselectAll();
                }
            }
        }

        #endregion

        #region Plotting

        private void BtnPlot_Click(object sender, EventArgs e)
        {
            ToggleInfo("Loading...", Color.Bisque);
            if (Application.OpenForms.OfType<RegionBrowser>().Any()) Application.OpenForms.OfType<RegionBrowser>().First().Close();
            if (Application.OpenForms.OfType<Inspection>().Any()) Application.OpenForms.OfType<Inspection>().First().Close();

            if (!MakeSheets()) return;

            List<Criteria> matchCriteira = GetAllCriteria();
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
                            Criteria[] matches = matchCriteira.Where(x => x.LegendEntry == criterion.LegendEntry).ToArray();
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
            CbxPassFail.Enabled = true;
            ToggleInfo("Plot", Color.LightBlue);

            RegionBrowser = new RegionBrowser(Data, Sheets, criteria, CbxPassFail.Checked, FileName, _CycleFileDelimeter, _YieldFont, _DefaultPlotSize);
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

        private void CbxPassFail_CheckedChanged(object sender, EventArgs e)
        {
            if (RegionBrowser.Visible) ToggleInfo("Loading...", Color.Bisque);
            RegionBrowser.TogglePF(CbxPassFail.Checked);
            ToggleInfo("Plot", Color.LightBlue);
        }

        #endregion

        #region Save Session

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog
            {
                Filter = "SEYRUP file(*.seyrup)| *.seyrup",
                Title = "Save SEYRUP File"
            };
            if (svd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(svd.FileName)) File.Delete(svd.FileName);
                ToggleInfo("Saving...", Color.Bisque);
                Application.DoEvents();
                SaveProject();
                SaveReport();
                using (ZipArchive zip = ZipFile.Open(svd.FileName, ZipArchiveMode.Create))
                {
                    zip.CreateEntryFromFile(ReportPath, Path.GetFileName(ReportPath));
                    zip.CreateEntryFromFile(ProjectPath, Path.GetFileName(ProjectPath));
                }
                ToggleInfo("Plot", Color.LightBlue);
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
