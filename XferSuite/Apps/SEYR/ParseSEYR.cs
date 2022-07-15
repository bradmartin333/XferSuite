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
        #region User Parameters

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
        private Delimeter _FileDelimeter = (Delimeter)Properties.Settings.Default.SEYR_Delimeter;
        [
            Category("User Parameters"),
            Description("Tabs are excel friendly, but some tools take comma separated values. " +
            "This is used when generating Data Rows or a Repair Cycle File."),
            DisplayName("Delimeter")
        ]
        public Delimeter FileDelimeter 
        { 
            get => _FileDelimeter; 
            set
            {
                _FileDelimeter = value;
                Properties.Settings.Default.SEYR_Delimeter = (int)_FileDelimeter;
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

        private bool _TransposeA = false;
        [
            Category("User Parameters"),
            Description("Transposes X and Y A grid values. " +
            "Might cause the software to stall if not an appropriate application of the feature. " +
            "Need to close and reopen .SEYRUP file to reset. " +
            "Toggles itself off after use as it greatly increases processing time."),
            DisplayName("Transpose A Grid")
        ]
        public bool TransposeA { get => _TransposeA; set => _TransposeA = value; }

        private bool _FlipAX = false;
        [
            Category("User Parameters"),
            Description("Flips X direction of A grid values. " +
            "Might cause the software to stall if not an appropriate application of the feature. " +
            "Need to close and reopen .SEYRUP file to reset. " +
            "Toggles itself off after use as it greatly increases processing time."),
            DisplayName("Flip AX Grid")
        ]
        public bool FlipAX { get => _FlipAX; set => _FlipAX = value; }

        private bool _FlipAY = false;
        [
            Category("User Parameters"),
            Description("Flips Y direction of A grid values. " +
            "Might cause the software to stall if not an appropriate application of the feature. " +
            "Need to close and reopen .SEYRUP file to reset. " +
            "Toggles itself off after use as it greatly increases processing time."),
            DisplayName("Flip AY Grid")
        ]
        public bool FlipAY { get => _FlipAY; set => _FlipAY = value; }

        private bool _SplitB = false;
        [
            Category("User Parameters"),
            Description("Irreversibly and uncontrollably creates more plotted regions. " +
            "Might cause the software to stall if not an appropriate application of the feature. " +
            "Need to close and reopen .SEYRUP file to reset. " +
            "Toggles itself off after use as it greatly increases processing time."),
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

        private int _PercentageSigFigs = Properties.Settings.Default.SEYR_Percentage_Sig_Figs;
        [
            Category("User Parameters"),
            Description("Control number of decimal places in the Pass/Fail plot"),
            DisplayName("Significant Figures")
        ]
        public int PercentageSigFigs
        {
            get => _PercentageSigFigs;
            set
            {
                _PercentageSigFigs = value;
                Properties.Settings.Default.SEYR_Percentage_Sig_Figs = _PercentageSigFigs;
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

        public bool _ShowPFData = Properties.Settings.Default.SEYR_Show_PF_Data;
        [
            Category("User Parameters"),
            Description("Show the # passing / # total above the percentage in the Pass/Fail plot"),
            DisplayName("Show Pass Fail Data")
        ]
        public bool ShowPFData
        {
            get => _ShowPFData;
            set
            {
                _ShowPFData = value;
                Properties.Settings.Default.SEYR_Show_PF_Data = _ShowPFData;
                Properties.Settings.Default.Save();
            }
        }

        private int _ExcelLeftStart = Properties.Settings.Default.SEYR_Excel_Left_Start;
        [
            Category("User Parameters"),
            Description("Column number (starting from 1) for start cell when exporting to Excel"),
            DisplayName("Excel Left Start")
        ]
        public int ExcelLeftStart
        {
            get => _ExcelLeftStart;
            set
            {
                if (value > 0)
                {
                    _ExcelLeftStart = value;
                    Properties.Settings.Default.SEYR_Excel_Left_Start = _ExcelLeftStart;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private int _ExcelTopStart = Properties.Settings.Default.SEYR_Excel_Top_Start;
        [
            Category("User Parameters"),
            Description("Row number (starting from 1) for start cell when exporting to Excel"),
            DisplayName("Excel Top Start")
        ]
        public int ExcelTopStart
        {
            get => _ExcelTopStart;
            set
            {
                if (value > 0)
                {
                    _ExcelTopStart = value;
                    Properties.Settings.Default.SEYR_Excel_Top_Start = _ExcelTopStart;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private int _CompositeXMargin = Properties.Settings.Default.SEYR_Composite_X_Margin;
        [
            Category("User Parameters"),
            Description("Number of X pixels to pad each tile's bitmap with"),
            DisplayName("Composite X Margin")
        ]
        public int CompositeXMargin
        {
            get => _CompositeXMargin;
            set
            {
                if (value >= 0)
                {
                    _CompositeXMargin = value;
                    Properties.Settings.Default.SEYR_Composite_X_Margin = _CompositeXMargin;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private int _CompositeYMargin = Properties.Settings.Default.SEYR_Composite_Y_Margin;
        [
            Category("User Parameters"),
            Description("Number of Y pixels to pad each tile's bitmap with"),
            DisplayName("Composite Y Margin")
        ]
        public int CompositeYMargin
        {
            get => _CompositeYMargin;
            set
            {
                if (value >= 0)
                {
                    _CompositeYMargin = value;
                    Properties.Settings.Default.SEYR_Composite_Y_Margin = _CompositeYMargin;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private long _LargeFileSize = Properties.Settings.Default.SEYR_Large_File_Size;
        [
            Category("User Parameters"),
            Description("SEYRUP file size to be considered for splitting"),
            DisplayName("Large File Size (MB)")
        ]
        public long LargeFileSize
        {
            get => _LargeFileSize;
            set
            {
                _LargeFileSize = value;
                Properties.Settings.Default.SEYR_Large_File_Size = _LargeFileSize;
                Properties.Settings.Default.Save();
            }
        }

        #endregion

        #region  Globals and Setup

        public static string FileName;
        public readonly string ActiveDirectory;
        public readonly string ProjectPath = $@"{Path.GetTempPath()}project.seyr";
        public readonly string ReportPath = $@"{Path.GetTempPath()}SEYRreport.txt";
        public readonly string CriteriaPath = $@"{Path.GetTempPath()}SEYRcriteria.txt";

        public static int LongestFeatureName = 0;
        public static Project Project { get; set; } = null;
        public List<DataEntry> Data { get; set; } = new List<DataEntry>();
        public List<DataSheet> Sheets { get; set; } = new List<DataSheet>();
        public List<Criteria> PlottedCriteria { get; set; } = new List<Criteria>();
        private RegionBrowser RegionBrowser { get; set; } = null;
        private int[] GridDims = new int[6]; // RMax, CMax, SRMax, SCMax, TRMax, TCMax
        private bool SplitFile = false;
        private readonly bool HasSavedCriteria = false;

        public ParseSEYR(string path)
        {
            InitializeComponent();
            FileInfo userPath = new FileInfo(path);
            CheckLargeFile(userPath);
            ActiveDirectory = userPath.DirectoryName;
            FileName = userPath.Name.Replace(userPath.Extension, "");
            Text = FileName;

            using (ZipArchive archive = ZipFile.OpenRead(path))
            {
                ExtractFile(ProjectPath, archive);
                ExtractFile(ReportPath, archive);
                HasSavedCriteria = ExtractFile(CriteriaPath, archive);
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
            SaveWorker.RunWorkerCompleted += SaveWorker_RunWorkerCompleted;
        }

        private void ParseSEYR_Load(object sender, EventArgs e)
        {
            
            ToggleInfo("Loading File...", Color.Bisque);
            LoadProject();
            if (HasSavedCriteria) LoadCriteria();
            DataLoadingWorker.RunWorkerAsync();
        }

        private void CheckLargeFile(FileInfo fileInfo)
        {
            if (fileInfo.Length > _LargeFileSize * 1e6)
            {
                DialogResult result = MessageBox.Show("This is a large SEYRUP file, would you like to split it up into smaller files within the host directory?", 
                    "SEYR Parsing", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) SplitFile = true;
            }
        }

        private void ParseSEYR_FormClosing(object sender, FormClosingEventArgs e)
        {
            try  // Exception on close during loading
            {
                File.Delete(ProjectPath);
                File.Delete(ReportPath);
            }
            catch (Exception) { }
        }

        public void ToggleInfo(string info, Color color)
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

        private void LoadCriteria()
        {
            using (StreamReader stream = new StreamReader(CriteriaPath))
            {
                XmlSerializer x = new XmlSerializer(typeof(List<Criteria>));
                try
                {
                    CriteriaOLV.Objects = (List<Criteria>)x.Deserialize(stream);
                    CriteriaOLV.RebuildColumns();
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
            GridDims = new int[6];
            (int, int) lastAgrid = (-1, -1);
            string splitDir = $@"\{DateTime.Now:ddMMMyyyy-HH-mm-ss}\";
            using (var sr = new StreamReader(ReportPath))
            {
                DataEntry.Header = sr.ReadLine();
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    DataEntry dataEntry = new DataEntry(line);
                    if (!dataEntry.Complete) break;
                    
                    if (SplitFile)
                    {
                        (int, int) thisA = (dataEntry.RC, dataEntry.RR);
                        if (lastAgrid == (-1, -1))
                            lastAgrid = thisA;
                        else if (lastAgrid != thisA)
                        {
                            SaveSplitFile(lastAgrid.ToString(), splitDir);
                            lastAgrid = thisA;
                        }
                    }
                    else // For sizing data sheets
                    {
                        for (int i = 0; i < GridDims.Length; i++)
                        {
                            int dim = dataEntry.GetDimension(i);
                            if (dim > GridDims[i]) GridDims[i] = dim;
                        }
                    }

                    Data.Add(dataEntry);
                }
            }
            if (Data.Count > 0 && SplitFile) SaveSplitFile(lastAgrid.ToString(), splitDir);
        }

        private void DataLoadingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Data.Count == 0)
            {
                if (SplitFile)
                    MessageBox.Show("SEYRUP file splitting complete.", "SEYR");
                else
                    MessageBox.Show("Data does not meet XferSuite requirements.", "SEYR");
                Close();
                return;
            }

            ToggleInfo("Analyzing Distributions...", Color.Bisque);

            IEnumerable<IGrouping<string, DataEntry>> groups = Data.GroupBy(x => x.FeatureName);
            foreach (IGrouping<string, DataEntry> group in groups)
            {
                Feature feature = Project.Features.Where(x => x.Name == group.Key).First();
                feature.Data = group.ToArray();
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

            RescoreAllData();
            InitFeatureInfo();
        }

        private void RescoreAllData()
        {
            ToggleInfo("Fitting Data...", Color.Bisque);
            LongestFeatureName = 0;
            foreach (Feature feature in Project.Features)
            {
                if (feature.Name.Length > LongestFeatureName)
                    LongestFeatureName = feature.Name.Length;
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
            try // Exception on close during loading
            {
                FeatureOLV.Objects = Project.Features;
                ToggleInfo("Plot", Color.LightBlue);
            }
            catch (Exception) { }
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

        private string MakeDefaultCriteriaString(string input) => System.Text.RegularExpressions.Regex.Replace(input, @"\d", "").Replace(" ","-").Replace("_","-").ToLower();

        #endregion

        #region OLV Object Manipulation

        private void EditFeature(Feature feature)
        {
            ToggleInfo("Loading Feature...", Color.Bisque);
            using (PassFailUtility pf = new PassFailUtility(Data, feature, NumberImagesInScroller, Project.ScaledPixelsPerMicron))
            {
                ToggleInfo("Plot", Color.LightBlue);
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
            RegionBrowser = new RegionBrowser(this);
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
            ToggleInfo("Making Sheets...", Color.Bisque);
            if (!MakeSheets()) return;
            ToggleInfo("Plotting...", Color.Bisque);
            PlotWorker.RunWorkerAsync();
        }

        private bool MakeSheets()
        {
            Sheets.Clear();
            Size aGrid = new Size(GridDims[0], GridDims[1]);

            if (_TransposeA)
            {
                foreach (DataEntry item in Data)
                {
                    (item.RC, item.RR) = (item.RR, item.RC);
                    item.UpdateRaw();
                }
                aGrid = new Size(GridDims[1], GridDims[0]);
                _TransposeA = false;
            }

            if (_FlipAX)
            {
                foreach (DataEntry item in Data)
                {
                    item.RC = aGrid.Width - item.RC + 1;
                    item.UpdateRaw();
                }
                _FlipAX = false;
            }

            if (_FlipAY)
            {
                foreach (DataEntry item in Data)
                {
                    item.RR = aGrid.Height - item.RR + 1;
                    item.UpdateRaw();
                }
                _FlipAY = false;
            }

            if (_SplitB)
            {
                foreach (DataEntry item in Data)
                {
                    item.RR = ((item.RR - 1) * aGrid.Width) + item.R;
                    item.RC = ((item.RC - 1) * aGrid.Height) + item.C;
                    item.R = 1;
                    item.C = 1;
                    item.UpdateRaw();
                }
                GridDims[0] = 1;
                GridDims[1] = 1;
                aGrid = new Size(GridDims[0], GridDims[1]);
                _SplitB = false;
            }

            (int, int)[] regions = Data.Select(x => (x.RR, x.RC)).Distinct().OrderBy(x => x.RR).OrderBy(x => x.RC).ToArray();
            if (regions.Length == 0 || (regions.Length == 1 && regions[0] == (0, 0)))
            {
                MessageBox.Show("Data does not meet XferSuite requirements.", "SEYR");
                return false;
            }
            foreach ((int, int) region in regions)
                Sheets.Add(new DataSheet(
                    region, aGrid,
                    new Size(GridDims[2], GridDims[3]),
                    new Size(GridDims[4], GridDims[5]),
                    _FlipX, _FlipY));

            return true;
        }

        private void CbxPassFail_CheckedChanged(object sender, EventArgs e)
        {
            if (RegionBrowser.Visible) 
                ToggleInfo("Toggling Pass Fail...", Color.Bisque);
            RegionBrowser.TogglePF(CbxPassFail.Checked);
            ToggleInfo("Plot", Color.LightBlue);
        }

        #endregion

        #region Save Session

        private string ExportPath;

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog
            {
                Filter = "SEYRUP file(*.seyrup)| *.seyrup",
                Title = "Save SEYRUP File"
            };
            if (svd.ShowDialog() == DialogResult.OK)
            {
                ExportPath = svd.FileName;
                ToggleInfo("Saving Files...", Color.Bisque);
                SaveProject();
                SaveWorker.RunWorkerAsync();
            }
        }

        public void ExportSEYRUP(string reportPath, string projectPath, string exportPath)
        {
            SaveCriteria();
            if (!SplitFile) ToggleInfo("Compressing...", Color.Bisque);
            if (File.Exists(exportPath)) File.Delete(exportPath);
            using (ZipArchive zip = ZipFile.Open(exportPath, ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(reportPath, Path.GetFileName(ReportPath));
                zip.CreateEntryFromFile(projectPath, Path.GetFileName(ProjectPath));
                zip.CreateEntryFromFile(CriteriaPath, Path.GetFileName(CriteriaPath));
            }
            if (!SplitFile) ToggleInfo("Plot", Color.LightBlue);
        }

        private void SaveProject()
        {
            using (StreamWriter stream = new StreamWriter(ProjectPath))
            {
                XmlSerializer x = new XmlSerializer(typeof(Project));
                x.Serialize(stream, Project);
            }
        }

        private void SaveCriteria()
        {
            foreach (Criteria criteria in PlottedCriteria)
                criteria.Override = true;
            using (StreamWriter stream = new StreamWriter(CriteriaPath))
            {
                XmlSerializer x = new XmlSerializer(typeof(List<Criteria>));
                x.Serialize(stream, PlottedCriteria);
            }
        }

        private void SaveWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (StreamWriter stream = new StreamWriter(ReportPath))
            {
                stream.WriteLine(DataEntry.Header);
                foreach (DataEntry entry in Data)
                    stream.WriteLine(entry.Raw);
            }
        }
        private void SaveWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ExportSEYRUP(ReportPath, ProjectPath, ExportPath);
        }

        private void SaveSplitFile(string ID, string splitDir)
        {
            string reportPath = $@"{Path.GetTempPath()}SEYRreport_split.txt";
            string exportDir = ActiveDirectory + splitDir;
            if (!Directory.Exists(exportDir)) Directory.CreateDirectory(exportDir);
            string exportPath = $"{exportDir}{Text}_{ID}.seyrup";
            using (StreamWriter stream = new StreamWriter(reportPath))
            {
                stream.WriteLine(DataEntry.Header);
                foreach (DataEntry d in Data)
                    stream.WriteLine(d.Raw);
            }
            ExportSEYRUP(reportPath, ProjectPath, exportPath);
            Data.Clear();
            File.Delete(reportPath);
        }

        #endregion
    }
}
