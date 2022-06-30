using Accord.Statistics.Distributions.Univariate;
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

        private int _NumberImagesInScroller = Properties.Settings.Default.SEYR_Num_Scroller_Images;
        [
            Category("User Parameters"),
            Description("The more images loaded when clicking a histogram bar, the longer the form will take to load"),
            DisplayName("# Images in Scroller")
        ]
        public int NumberImagesInScroller 
        { 
            get => _NumberImagesInScroller; 
            set
            {
                _NumberImagesInScroller = value;
                Properties.Settings.Default.SEYR_Num_Scroller_Images = _NumberImagesInScroller;
                Properties.Settings.Default.Save();
            }
        }

        private int _PlotSize = Properties.Settings.Default.SEYR_Plot_Size;
        [
            Category("User Parameters"),
            Description("Autoscaling will be applied to this starting X by Y square dimension"),
            DisplayName("Default Plot Window Size")
        ]
        public int PlotSize 
        { 
            get => _PlotSize; 
            set
            {
                _PlotSize = value;
                Properties.Settings.Default.SEYR_Plot_Size = _PlotSize;
                Properties.Settings.Default.Save();
            }
        }

        public enum Delimeter { Tab, Comma, Space }
        private Delimeter _CycleFileDelimeter = (Delimeter)Properties.Settings.Default.SEYR_Delimeter;
        [
            Category("User Parameters"),
            Description("Tabs are excel friendly, but some tools take comma separated values"),
            DisplayName("Cycle File Delimeter")
        ]
        public Delimeter CycleFileDelimeter 
        { 
            get => _CycleFileDelimeter; 
            set
            {
                _CycleFileDelimeter = value;
                Properties.Settings.Default.SEYR_Delimeter = (int)_CycleFileDelimeter;
                Properties.Settings.Default.Save();
            }
        }

        private bool _FlipX = Properties.Settings.Default.SEYR_Flip_X;
        [
            Category("User Parameters"),
            Description("Invert the X direction in the plot window"),
            DisplayName("Flip X")
        ]
        public bool FlipX 
        { 
            get => _FlipX; 
            set
            {
                _FlipX = value;
                Properties.Settings.Default.SEYR_Flip_X = _FlipX;
                Properties.Settings.Default.Save();
            } 
        }

        private bool _FlipY = Properties.Settings.Default.SEYR_Flip_Y;
        [
            Category("User Parameters"),
            Description("Invert the Y direction in the plot window"),
            DisplayName("Flip Y")
        ]
        public bool FlipY
        {
            get => _FlipY;
            set
            {
                _FlipY = value;
                Properties.Settings.Default.SEYR_Flip_Y = _FlipY;
                Properties.Settings.Default.Save();
            }
        }

        private bool _SplitB = false;
        [
            Category("User Parameters"),
            Description("IRREVERSIBLY create more plotted regions. Need to close and reopen .SEYRUP file to reset."),
            DisplayName("Split B Grid")
        ]
        public bool SplitB { get => _SplitB; set => _SplitB = value; }

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

        private Font _YieldFont = Properties.Settings.Default.SEYR_Yield_Font;
        [
            Category("User Parameters"),
            Description("Yield % font in the plot window"),
            DisplayName("Yield Font")
        ]
        public Font YieldFont 
        { 
            get => _YieldFont; 
            set
            {
                _YieldFont = value;
                Properties.Settings.Default.SEYR_Yield_Font = _YieldFont;
                Properties.Settings.Default.Save();
            }
        }

        private Font _RCFont = Properties.Settings.Default.SEYR_RC_Font;
        [
            Category("User Parameters"),
            Description("Row and column font in the plot window"),
            DisplayName("RC Font")
        ]
        public Font RCFont 
        { 
            get => _RCFont; 
            set
            {
                _RCFont = value;
                Properties.Settings.Default.SEYR_RC_Font = _RCFont;
                Properties.Settings.Default.Save();
            }
        }

        private bool _ShowYieldBrackets = Properties.Settings.Default.SEYR_Show_Brackets;
        [
            Category("User Parameters"),
            Description("Looks like ┏ XX.X% ┓"),
            DisplayName("Show Yield Brackets")
        ]
        public bool ShowYieldBrackets 
        { 
            get => _ShowYieldBrackets; 
            set
            {
                _ShowYieldBrackets = value;
                Properties.Settings.Default.SEYR_Show_Brackets = _ShowYieldBrackets;
                Properties.Settings.Default.Save();
            }
        }

        private readonly string FileName;
        private readonly string ProjectPath = $@"{Path.GetTempPath()}project.seyr";
        private readonly string ReportPath = $@"{Path.GetTempPath()}SEYRreport.txt";

        public static Project Project { get; set; } = null;
        private List<DataEntry> Data { get; set; } = new List<DataEntry>();
        private List<DataSheet> Sheets { get; set; } = new List<DataSheet>();
        private List<Criteria> PlottedCriteria { get; set; } = new List<Criteria>();
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

            FeatureOLV.DoubleClick += FeatureOLV_DoubleClick;
            FeatureOLV.KeyDown += FeatureOLV_KeyDown;
            FeatureOLV.CellRightClick += FeatureOLV_CellRightClick;
            CriteriaOLV.DoubleClick += CriteriaOLV_DoubleClick;
            CriteriaOLV.FormatRow += CriteriaOLV_FormatRow;
            CriteriaOLV.CellRightClick += CriteriaOLV_CellRightClick;
            CriteriaOLV.SelectedBackColor = Color.White;
            CriteriaOLV.SelectedForeColor = Color.Magenta;
            FormClosing += ParseSEYR_FormClosing;
            DataLoadingWorker.RunWorkerCompleted += DataLoadingWorker_RunWorkerCompleted;
            PlotWorker.RunWorkerCompleted += PlotWorker_RunWorkerCompleted;
        }

        private void ParseSEYR_Load(object sender, EventArgs e)
        {
            ToggleInfo("Loading...", Color.Bisque);
            LoadProject();
            DataLoadingWorker.RunWorkerAsync();
        }

        private void ParseSEYR_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete(ProjectPath);
            File.Delete(ReportPath);
        }

        private void ToggleInfo(string info, Color color)
        {
            BtnPlot.Text = info;
            BtnPlot.BackColor = color;
            TLP.Enabled = info == "Plot";
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

        private void DataLoadingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Data.Clear();
            using (var sr = new StreamReader(ReportPath))
            {
                DataEntry.Header = sr.ReadLine();
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    DataEntry dataEntry = new DataEntry(line);
                    if (!dataEntry.Complete) break;
                    if (dataEntry.HasValidPosition()) Data.Add(dataEntry);
                }
            }
        }

        private void DataLoadingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
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

                if (feature.HistData.Length > 5) // Need some data to match to normal distribution
                {
                    NormalDistribution normal = new NormalDistribution();
                    normal.Fit(feature.HistData);
                    double wid = normal.StandardDeviation * 3;
                    feature.Limit = normal.Mean + ((feature.FlipScore ? -1 : 1) * wid);
                    feature.PassThreshold = normal.Mean - ((feature.FlipScore ? -1 : 1) * wid);
                }
                else
                {
                    feature.PassThreshold = feature.PassThreshold == -10 ? (feature.MaxScore + feature.MinScore) / 2.0 : feature.PassThreshold;
                    feature.Limit = feature.Limit == -10 ? (feature.FlipScore ? feature.HistData.Min() : feature.HistData.Max()) : feature.Limit;
                }

                feature.Ignore = feature.Name.ToLower() == "img";
            }

            if (Data.Count == 0)
            {
                MessageBox.Show("Data does not meet XferSuite requirements.", "SEYR");
                Close();
                return;
            }

            RescoreAllData();
            InitFeatureInfo();
            ToggleInfo("Plot", Color.LightBlue);
        }

        private void RescoreAllData()
        {
            foreach (Feature feature in Project.Features)
            {
                foreach (DataEntry entry in feature.Data)
                    entry.State = feature.GenerateState(entry.Score);
                if (string.IsNullOrEmpty(feature.CriteriaString))
                    feature.CriteriaString = MakeDefaultCriteriaString(feature.Name);
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
                feature.CriteriaString = MakeDefaultCriteriaString(feature.Name);
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

        private string MakeDefaultCriteriaString(string input) => System.Text.RegularExpressions.Regex.Replace(input, @"\d", "").ToLower();

        #endregion

        #region OLV Object Manipulation

        private void EditFeature(Feature feature)
        {
            ToggleInfo("Loading...", Color.Bisque);
            Application.DoEvents();
            using (PassFailUtility pf = new PassFailUtility(Data, feature, NumberImagesInScroller, Project.ScaledPixelsPerMicron))
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

        private void PlotWorker_DoWork(object sender, DoWorkEventArgs e)
        {
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
            PlottedCriteria = criteria;
        }

        private void PlotWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CriteriaOLV.Objects = PlottedCriteria;
            CbxPassFail.Enabled = true;
            RegionBrowser = new RegionBrowser(Data, Sheets, PlottedCriteria,
                CbxPassFail.Checked, FileName, _CycleFileDelimeter, _YieldFont, _RCFont, _ShowYieldBrackets, _PlotSize, Project);
            ToggleInfo("Plot", Color.LightBlue);
        }

        private void BtnPlot_Click(object sender, EventArgs e)
        {
            bool bringRBtoFront = ModifierKeys == Keys.Shift;
            if (Application.OpenForms.OfType<RegionBrowser>().Any())
            {
                RegionBrowser rb = Application.OpenForms.OfType<RegionBrowser>().First();
                if (bringRBtoFront)
                {
                    rb.BringToFront();
                    return;
                }
                else
                    rb.Close();
            }
            if (Application.OpenForms.OfType<Inspection>().Any()) Application.OpenForms.OfType<Inspection>().First().Close();
            if (!MakeSheets()) return;
            ToggleInfo("Loading...", Color.Bisque);
            PlotWorker.RunWorkerAsync();
        }

        private bool MakeSheets()
        {
            Sheets.Clear();

            if (_SplitB)
            {
                Size bGrid = new Size(Data.Select(x => x.R).Max(), Data.Select(x => x.C).Max());
                foreach (DataEntry item in Data)
                {
                    item.RR = ((item.RR - 1) * bGrid.Width) + item.R;
                    item.RC = ((item.RC - 1) * bGrid.Height) + item.C;
                    item.R = 1;
                    item.C = 1;
                    item.UpdateRaw();
                }
            }

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
