using BrightIdeasSoftware;
using Microsoft.FSharp.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using XferHelper;

namespace XferSuite.Apps.SEYR
{
    public partial class ParseSEYR : Form
    {
        #region User Parameters

        private int _PassPointSize = 1;
        [Category("User Parameters")]
        public int PassPointSize
        {
            get => _PassPointSize;
            set
            {
                _PassPointSize = value;
                Results.UpdateData("Pass point size changed", this);
            }
        }

        private int _FailPointSize = 1;
        [Category("User Parameters")]
        public int FailPointSize
        {
            get => _FailPointSize;
            set
            {
                _FailPointSize = value;
                Results.UpdateData("Fail point size changed", this);
            }
        }

        private bool _FlipXAxis = true;
        [Category("User Parameters")]
        public bool FlipXAxis
        {
            get => _FlipXAxis;
            set
            {
                _FlipXAxis = value;
                Results.UpdateData("X axis orientation changed", this);
            }
        }

        private bool _FlipYAxis = true;
        [Category("User Parameters")]
        public bool FlipYAxis
        {
            get => _FlipYAxis;
            set
            {
                _FlipYAxis = value;
                Results.UpdateData("Y axis orientation changed", this);
            }
        }

        private int _DataReduction = 0;
        [Category("User Parameters")]
        [Description("Percentage of Pass and Fail data to omit for the sake of PC speed")]
        public int DataReduction
        {
            get => _DataReduction;
            set
            {
                if (value >= 0 && value <= 100)
                    _DataReduction = value;
                else if (value < 0)
                    _DataReduction = 0;
                else if (value > 100)
                    _DataReduction = 100;
                Results.UpdateData("Data reduction value changed", this);
            }
        }

        private int _RegionTextSize = 12;
        [Category("User Parameters")]
        public int RegionTextSize
        {
            get => _RegionTextSize;
            set
            {
                _RegionTextSize = value;
                Results.UpdateData("Region text size changed", this);
            }
        }

        private int _RegionTextOffsetX = 0;
        [Category("User Parameters")]
        public int RegionTextOffsetX
        {
            get => _RegionTextOffsetX;
            set
            {
                _RegionTextOffsetX = value;
                Results.UpdateData("Region text offset changed", this);
            }
        }

        private int _RegionTextOffsetY = 0;
        [Category("User Parameters")]
        public int RegionTextOffsetY
        {
            get => _RegionTextOffsetY;
            set
            {
                _RegionTextOffsetY = value;
                Results.UpdateData("Region text offset changed", this);
            }
        }

        private float _RegionTextRotation = 0f;
        [Category("User Parameters")]
        public float RegionTextRotation
        {
            get => _RegionTextRotation;
            set
            {
                _RegionTextRotation = value;
                Results.UpdateData("Region text rotated", this);
            }
        }

        private int _RegionLabelOpacity = 255;
        [Category("User Parameters")]
        public int RegionLabelOpacity
        {
            get => _RegionLabelOpacity;
            set
            {
                if (value >= 0 && value <= 255)
                    _RegionLabelOpacity = value;
                else if (value < 0)
                    _RegionLabelOpacity = 0;
                else if (value > 255)
                    _RegionLabelOpacity = 255;
                Results.UpdateData("Region label opacity changed", this);
            }
        }

        private double _RegionBorderPadding = 0.1;
        [Category("User Parameters")]
        [Description("Adds space (in mm) between data and plotted region border")]
        public double RegionBorderPadding
        {
            get => _RegionBorderPadding;
            set
            {
                _RegionBorderPadding = value < 0 ? 0 : value;
                Results.UpdateData("Region border padding changed", this);
            }
        }

        private int _RegionBorderOpacity = 255;
        [Category("User Parameters")]
        public int RegionBorderOpacity
        {
            get => _RegionBorderOpacity;
            set
            {
                if (value >= 0 && value <= 255)
                    _RegionBorderOpacity = value;
                else if (value < 0)
                    _RegionBorderOpacity = 0;
                else if (value > 255)
                    _RegionBorderOpacity = 255;
                Results.UpdateData("Region border opacity changed", this);
            }
        }

        private int _PercentageTextSize = 12;
        [Category("User Parameters")]
        public int PercentageTextSize
        {
            get => _PercentageTextSize;
            set
            {
                _PercentageTextSize = value;
                Results.UpdateData("Percentage text size changed", this);
            }
        }

        private int _PercentLabelOpacity = 255;
        [Category("User Parameters")]
        public int PercentLabelOpacity
        {
            get => _PercentLabelOpacity;
            set
            {
                if (value >= 0 && value <= 255)
                    _PercentLabelOpacity = value;
                else if (value < 0)
                    _PercentLabelOpacity = 0;
                else if (value > 255)
                    _PercentLabelOpacity = 255;
                Results.UpdateData("Percent label opacity changed", this);
            }
        }

        private bool _PercentLocation = true;
        [Category("User Parameters")]
        [Description("True: Center of region, False: In region text location")]
        public bool PercentLocation
        {
            get => _PercentLocation;
            set
            {
                _PercentLocation = value;
                Results.UpdateData("Percent location changed", this);
            }
        }

        #endregion

        #region Globals and Setup

        public struct Plottable
        {
            public string Region;
            public string DetailString;
            public double X;
            public double Y;
            public bool Pass;
            public string CustomTag;
            public Color Color;

            public override string ToString()
            {
                return $"Region {Region}{DetailString}";
            }
        }

        public string[] Regions = null;
        public List<Plottable> Plottables = new List<Plottable>();
        public List<PlotOrderElement> PlotOrder = PlotOrderElement.GenerateDefaults();
        public readonly List<CustomFeature> CustomFeatures = new List<CustomFeature>();

        private readonly FileInfo Path;
        private readonly Report.Entry[] Data;
        private Feature[] Features;
        private Feature SelectedFeature;
        private bool ObjectHasBeenDropped; // For criteria selector - possibly unecessary
        private readonly Results Results;
        private ScottPlot.Plottable.Annotation ViewDataAnnotation;
        private readonly List<ScottPlot.Plottable.BarPlot> ViewDataPlots = new List<ScottPlot.Plottable.BarPlot>();
        private readonly BackgroundWorker ParseWorker = new BackgroundWorker();

        private bool RequiredOn, NeedOneOn, CustomOn;
        private double DistX = -1;
        private double DistY = -1;
        private Report.Entry[] FilteredData;

        public ParseSEYR(string path, string seyrup = null)
        {
            InitializeComponent();
            Path = new FileInfo(path);
            Text = Path.Name.Replace(Path.Extension, string.Empty);
            Results = new Results(Text);
            Data = Report.data(Path.FullName);

            ParseWorker.WorkerReportsProgress = true;
            ParseWorker.DoWork += ParseWorker_DoWork;
            ParseWorker.ProgressChanged += ParseWorker_ProgressChanged;
            ParseWorker.RunWorkerCompleted += ParseWorker_RunWorkerCompleted;

            if (!string.IsNullOrEmpty(seyrup)) LoadProjectInfo(seyrup);

            ResetFeaturesAndUI();

            SimpleDragSource bufferSource = (SimpleDragSource)olvBuffer.DragSource;
            bufferSource.RefreshAfterDrop = true;
            SimpleDropSink requireSink = (SimpleDropSink)olvRequire.DropSink;
            requireSink.AcceptExternal = true;
            requireSink.CanDropOnBackground = true;
            SimpleDropSink needOneSink = (SimpleDropSink)olvNeedOne.DropSink;
            needOneSink.AcceptExternal = true;
            needOneSink.CanDropOnBackground = true;

            olvBuffer.ItemSelectionChanged += ItemSelectionChanged;
            olvRequire.ItemSelectionChanged += ItemSelectionChanged;
            olvNeedOne.ItemSelectionChanged += ItemSelectionChanged;

            olvRequire.ModelCanDrop += (s, e) => { e.Effect = DragDropEffects.Copy; };
            olvRequire.ModelDropped += ModelDropped;
            olvNeedOne.ModelCanDrop += ModelCanDrop;
            olvNeedOne.ModelDropped += ModelDropped;
            olvNeedOne.CanExpandGetter = delegate (object x) { return ((Feature)x).IsParent; };
            olvNeedOne.ChildrenGetter = delegate (object x) { return ((Feature)x).Children; };

            olvCustom.DoubleClick += OlvCustom_DoubleClick;
            olvCustom.FormatRow += OlvCustom_FormatRow;

            Show();
        }

        private void LoadProjectInfo(string path)
        {
            string destinationPath = $@"{System.IO.Path.GetTempPath()}\project.seyr";

            using (ZipArchive archive = ZipFile.OpenRead(path))
            {
                ZipArchiveEntry report = archive.Entries.Where(x => x.Name == "project.seyr").First();
                report.ExtractToFile(destinationPath, true);
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(destinationPath);
            double pxPerMM = double.Parse(doc.SelectSingleNode("/Project/PixelsPerMicron").InnerText) * 1e3;
            DistX = double.Parse(doc.SelectSingleNode("/Project/PitchX").InnerText) / pxPerMM;
            DistY = double.Parse(doc.SelectSingleNode("/Project/PitchY").InnerText) / pxPerMM;

            XmlNodeList features = doc.SelectNodes("/Project/Features/Feature");
            XmlNodeList locations = doc.SelectNodes("/Project/Features/Feature/Rectangle/Location");
            for (int i = 0; i < features.Count; i++)
                Feature.ProjectInfo.Add((
                    features[i]["Name"].InnerText,
                    new PointF((float)(double.Parse(locations[i]["X"].InnerText) / pxPerMM), (float)(double.Parse(locations[i]["Y"].InnerText) / pxPerMM))));
        }

        private void ResetFeaturesAndUI()
        {
            Features = Feature.GetFeatures(Data);
            SelectedFeature = null;
            lblSelectedFeature.Text = @"N\A";
            olvBuffer.SetObjects(Features);
            olvRequire.Objects = null;
            olvNeedOne.Objects = null;
            ObjectHasBeenDropped = false;
        }

        #endregion

        #region OLV Logic

        private void ModelCanDrop(object sender, ModelDropEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (e.TargetModel != null)
            {
                if (((Feature)e.TargetModel).IsChild)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    e.Effect = DragDropEffects.Link; // Only one branch
                }
            }
            else
            {
                e.Handled = true;
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void ModelDropped(object sender, ModelDropEventArgs e)
        {
            for (int i = 0; i < e.SourceModels.Count; i++)
            {
                Feature m = (Feature)e.SourceModels[i];
                m.Bucket = Report.toBucket(int.Parse(e.ListView.Tag.ToString()));
                if ((ObjectListView)sender == olvNeedOne)
                {
                    if (e.DropTargetLocation == DropTargetLocation.Item)
                    {
                        m.IsChild = true;
                        Feature targ = (Feature)e.TargetModel;
                        m.FamilyName = targ.Name;
                        targ.Children.Add(m);
                    }
                    else
                    {
                        if (i > 0)
                        {
                            m.Bucket = Report.Bucket.NeedOne;
                            m.IsChild = true;
                            Feature parent = (Feature)e.SourceModels[0];
                            m.FamilyName = parent.Name;
                            parent.Children.Add(m);
                        }
                        else
                        {
                            m.IsParent = true;
                            m.FamilyName = m.Name;
                            ((ObjectListView)sender).AddObject(m);
                            olvNeedOne.ExpandAll();
                        }
                    }
                }
                else
                    ((ObjectListView)sender).AddObject(m);
                olvBuffer.RemoveObject(m);
            }
            e.RefreshObjects();
            flowLayoutPanelCriteria.Enabled = false;
            ObjectHasBeenDropped = true;
        }

        private void ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            flowLayoutPanelCriteria.Enabled = !ObjectHasBeenDropped;
            SelectedFeature = Features.First(x => x.Name == e.Item.Text);
            lblSelectedFeature.Text = SelectedFeature.Name;
            foreach (CheckBox cbx in flowLayoutPanelCriteria.Controls.OfType<CheckBox>())
            {
                Report.State state = Report.toState(int.Parse(cbx.Tag.ToString()));
                cbx.Checked = SelectedFeature.Requirements.Contains(state);
            }
        }

        private void Cbx_CheckedChanged(object sender, EventArgs e)
        {
            List<Report.State> requirements = new List<Report.State>();
            foreach (CheckBox cbx in flowLayoutPanelCriteria.Controls.OfType<CheckBox>())
                if (cbx.Checked) requirements.Add(Report.toState(int.Parse(cbx.Tag.ToString())));
            Features.First(x => x.Name == SelectedFeature.Name).Requirements = requirements.ToArray();
        }

        private void BtnApplyToAll_Click(object sender, EventArgs e)
        {
            List<Report.State> requirements = new List<Report.State>();
            foreach (CheckBox cbx in flowLayoutPanelCriteria.Controls.OfType<CheckBox>())
                if (cbx.Checked) requirements.Add(Report.toState(int.Parse(cbx.Tag.ToString())));
            foreach (Feature feature in Features)
                feature.Requirements = requirements.ToArray();
        }

        private void OlvCustom_DoubleClick(object sender, EventArgs e)
        {
            if (olvCustom.SelectedIndex == -1) return;
            CustomFeature feature = (CustomFeature)olvCustom.SelectedObject;
            string originalName = feature.Name;
            using (CreateCustom cc = new CreateCustom(Features, CustomFeatures, feature))
            {
                var result = cc.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var plotOrderIdx = PlotOrder.Select(x => x.Name).ToList().IndexOf(originalName);
                    PlotOrder[plotOrderIdx].Name = cc.CustomFeature.Name;
                    CustomFeatures[olvCustom.SelectedIndex] = cc.CustomFeature;
                    olvCustom.UpdateObject(olvCustom.SelectedObject);
                    olvCustom.DeselectAll();
                    Results.UpdateData("Custom feature updated", this);
                }
                else if (result == DialogResult.Ignore)
                {
                    PlotOrder.Remove(PlotOrder.Where(x => x.Name == feature.Name).First());
                    CustomFeatures.RemoveAt(olvCustom.SelectedIndex);
                    olvCustom.RemoveObject(feature);
                    Results.UpdateData("Custom feature hidden", this);
                }
                else
                    return;
            }
        }

        private void OlvCustom_FormatRow(object sender, FormatRowEventArgs e)
        {
            CustomFeature customFeature = (CustomFeature)e.Model;
            e.Item.BackColor = customFeature.Color;
            e.Item.ForeColor = customFeature.ContrastColor;
            e.Item.Decoration = customFeature.Type == Report.State.Null ? new ImageDecoration(Properties.Resources.invisible_small, 255) : null;
        }

        private void ToggleOLVs(bool toggle)
        {
            foreach (ObjectListView olv in tableLayoutPanel.Controls.OfType<ObjectListView>())
                olv.Enabled = toggle;
        }

        #endregion

        #region Parse Methods

        private void ParseWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ParseWorker.ReportProgress(-2);
            Plottables = new List<Plottable>();
            RequiredOn = Features.Where(x => x.Bucket == Report.Bucket.Required).Count() > 0;
            NeedOneOn = Features.Where(x => x.IsChild).Count() > 0;
            CustomOn = CustomFeatures.Where(x => x.Checked).Count() > 0;
            FilteredData = CustomOn ? Data : Report.removeBuffers(Data, Features.Where(x => x.Bucket == Report.Bucket.Buffer).Select(x => x.Name).ToArray());
            if (Regions == null) InitialzeData();
            if (RequiredOn || NeedOneOn || CustomOn) Parse();
        }

        private void InitialzeData()
        {
            if (DistX == -1 || DistY == -1)
            {
                DistX = 0.0;
                DistY = 0.0;

                if (Path.FullName.Contains("_CP_"))
                {
                    string[] slice = Path.FullName.Replace(".txt", "").Split('_');
                    DistX = double.Parse(slice[slice.Length - 2]);
                    DistY = double.Parse(slice[slice.Length - 1]);
                }
                else
                {
                    using (Utility.PromptForInput input = new Utility.PromptForInput(
                        prompt: "Enter X grid pitch in millimeters",
                        textEntry: false,
                        max: 100,
                        title: $"SEYR Parser Grid Setup"))
                    {
                        var result = input.ShowDialog();
                        if (result == DialogResult.OK)
                            DistX = (double)((NumericUpDown)input.Control).Value;
                        else
                            return;
                    }
                    using (Utility.PromptForInput input = new Utility.PromptForInput(
                        prompt: "Enter Y grid pitch in millimeters",
                        textEntry: false,
                        max: 100,
                        title: $"SEYR Parser Grid Setup"))
                    {
                        var result = input.ShowDialog();
                        if (result == DialogResult.OK)
                            DistY = (double)((NumericUpDown)input.Control).Value;
                        else
                            return;
                    }
                }
            }
            
            Regions = Report.getRegions(FilteredData);
        }

        private void ParseWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Results.UpdateData("Newly parsed data", this);
            toolStripLabelPercent.Text = "";
            ToggleOLVs(true);
            flowLayoutPanelCriteria.Enabled = true;
            Application.DoEvents();
        }

        private void ParseWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case -2:
                    toolStripLabelPercent.Text = "Initializing Data";
                    break;
                case -1:
                    toolStripLabelPercent.Text = "Plotting Data";
                    break;
                default:
                    toolStripLabelPercent.Text = $"Parsing Region {e.ProgressPercentage + 1}/{Regions.Length}";
                    break;
            }
        }

        private void Parse()
        {
            List<string> needOneParents = Features.Where(x => x.IsParent).Select(x => x.Name).ToList();
            int regionIdx = 0;
            foreach (IGrouping<string, Report.Entry> regionGroup in FilteredData.GroupBy(x => (x.RR, x.RC, x.R, x.C).ToString()))
            {
                ParseWorker.ReportProgress(regionIdx);
                Report.Entry[] region = regionGroup.ToArray();
                foreach (IGrouping<int, Report.Entry> imageGroup in region.GroupBy(x => x.ImageNumber))
                {
                    Report.Entry[] image = imageGroup.ToArray();
                    foreach (IGrouping<string, Report.Entry> cellGroup in image.GroupBy(x => (x.TileCol, x.TileRow).ToString()))
                    {
                        Report.Entry[] cell = cellGroup.ToArray();
                        if (cell == null || cell.Length == 0) continue;
                        double thisX = cell[0].X + cell[0].TileCol * DistX * (_FlipXAxis ? -1 : 1);
                        double thisY = cell[0].Y + cell[0].TileRow * DistY;
                        string detailString = $"     Cell ({cell[0].TileCol}, {cell[0].TileRow})     Location ({thisX}, {thisY})";
                        foreach (Feature feature in Features)
                        {
                            Plottables.Add(new Plottable()
                            {
                                Region = Regions[regionIdx],
                                DetailString = detailString + $"     {feature.Name}",
                                X = thisX + feature.Location.X * (_FlipXAxis ? -1 : 1),
                                Y = thisY + feature.Location.Y,
                                Pass = cell.Where(x => x.Name == feature.Name).First().State == Report.State.Pass,
                                Color = Color.Green,
                            });
                        }
                    }
                }
                regionIdx++;
            }
            ParseWorker.ReportProgress(-1);
        }

        private bool CheckCustomCriteria(CustomFeature custom, Report.Entry[] cell)
        {
            int product = 1;
            switch (custom.Logic)
            {
                case CustomFeature.LogicType.AND:
                    foreach ((string, Report.State) filter in custom.Filters)
                        product *= Convert.ToInt32(cell.Where(x => x.Name == filter.Item1).First().State == filter.Item2);
                    break;
                case CustomFeature.LogicType.OR:
                    foreach ((string, Report.State) filter in custom.Filters)
                        product += Convert.ToInt32(cell.Where(x => x.Name == filter.Item1).First().State == filter.Item2);
                    break;
                case CustomFeature.LogicType.XOR:
                    foreach ((string, Report.State) filter in custom.Filters)
                        product -= Convert.ToInt32(cell.Where(x => x.Name == filter.Item1).First().State == filter.Item2);
                    break;
            }
            switch (custom.Logic)
            {
                case CustomFeature.LogicType.AND:
                    return product == 1;
                case CustomFeature.LogicType.OR:
                    return product > 1;
                case CustomFeature.LogicType.XOR:
                    return product == 0;
                default:
                    return false;
            }
        }


        #endregion

        #region Tool Strip Methods

        private void ToolStripButtonReset_Click(object sender, EventArgs e)
        {
            if (ParseWorker.IsBusy) return;
            ResetFeaturesAndUI();
        }

        private void ToolStripButtonParse_Click(object sender, EventArgs e)
        {
            if (ParseWorker.IsBusy) return;
            ToggleOLVs(false);
            flowLayoutPanelCriteria.Enabled = false;
            toolStripLabelPercent.Text = "";
            ParseWorker.RunWorkerAsync();
        }

        private void ToolStripButtonSmartSort_Click(object sender, EventArgs e)
        {
            if (ParseWorker.IsBusy) return;
            
            Feature[] originalFeatures = Features; // Maintain requirements
            ResetFeaturesAndUI();

            // Alphabetical order looks better in the NeedOne bucket
            Features.Select(x => x.Name).ToList().Sort();

            flowLayoutPanelCriteria.Enabled = false;
            olvBuffer.Objects = null;

            Feature[] criteria = Features.Where(x => !x.Name.Contains("pat")).ToArray();
            if (criteria.Length == 1)
            {
                criteria[0].Bucket = Report.Bucket.Required;
                olvRequire.AddObject(criteria[0]);
                olvBuffer.AddObjects(Features.Where(x => x.Name.Contains("pat")).ToArray());
            }
            else
            {
                foreach (Feature feature in Features)
                {
                    feature.Requirements = originalFeatures.First(x => x.Name == feature.Name).Requirements;
                    FindHome(feature);
                }
            }

            olvNeedOne.RebuildAll(true);
        }

        private void ToolStripButtonAddCustom_Click(object sender, EventArgs e)
        {
            using (CreateCustom cc = new CreateCustom(Features, CustomFeatures))
            {
                var result = cc.ShowDialog();
                if (result == DialogResult.OK)
                    AddFeatureToProject(cc.CustomFeature);
                else
                    return;
            }
        }

        private void ToolStripButtonImportCustom_Click(object sender, EventArgs e)
        {
            string[] pathBuffers = MainMenu.OpenFiles("Open Custom SEYR Features", "Text File (*.txt) | *.txt");
            if (pathBuffers == null)
                return;
            else
            {
                string mismatches = string.Empty;
                foreach (string path in pathBuffers)
                {
                    CustomFeature feature = new CustomFeature(path);
                    if (!CustomFeatures.Select(x => x.Name).Contains(feature.Name) && feature.ValidateFilters(Features.Select(x => x.Name).ToArray()))
                        AddFeatureToProject(feature);
                    else
                        mismatches += $"{new FileInfo(path).Name}\n";
                }
                if (!string.IsNullOrEmpty(mismatches))
                    MessageBox.Show($"The following files did not match the currently loaded SEYR report:\n\n{mismatches}", "Load Custom SEYR Features");
            }  
        }

        private void AddFeatureToProject(CustomFeature feature)
        {
            olvCustom.AddObject(feature);
            CustomFeatures.Add(feature);
            PlotOrder.Add(new PlotOrderElement() { Name = feature.Name });
        }

        private void ToolStripButtonEditPlotOrder_Click(object sender, EventArgs e)
        {
            using (EditPlotOrder edit = new EditPlotOrder(PlotOrder))
            {
                var result = edit.ShowDialog();
                if (result == DialogResult.OK)
                {
                    PlotOrder = edit.PlotOrder;
                    Results.UpdateData("Plot order updated", this);
                } 
                else
                    return;
            }
        }

        #endregion

        #region Feature Specific Methods

        private bool CheckCriteria(Report.Entry[] thisCell, List<string> needOneParents)
        {
            List<bool>[] needOneLists = new List<bool>[needOneParents.Count];

            for (int i = 0; i < thisCell.Length; i++)
            {
                Report.Entry item = thisCell[i];
                Feature criteria = Features.First(x => x.Name == item.Name);
                switch (criteria.Bucket)
                {
                    case Report.Bucket.Buffer:
                        break;
                    case Report.Bucket.Required:
                        if (!criteria.Requirements.Contains(item.State)) return false;
                        break;
                    case Report.Bucket.NeedOne:
                        int listIdx = needOneParents.IndexOf(criteria.FamilyName);
                        if (needOneLists[listIdx] == null) needOneLists[listIdx] = new List<bool>(); // Init list
                        needOneLists[listIdx].Add(
                            criteria.Requirements.Contains(item.State));
                        break;
                    default:
                        break;
                }
            }

            foreach (List<bool> needOneList in needOneLists)
                if (needOneList.Count != 0 && !needOneList.Contains(true)) return false;

            return true;
        }

        private void FindHome(Feature feature)
        {
            char[] digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (feature.Name.Any(char.IsDigit))
            {
                feature.Bucket = Report.Bucket.NeedOne;
                string rootName = feature.Name.TrimEnd(digits);
                bool foundParent = false;
                foreach (var item in olvNeedOne.Objects)
                {
                    Feature targ = (Feature)item;
                    if (targ.Name.Contains(rootName) && targ.IsParent)
                    {
                        feature.IsChild = true;
                        feature.FamilyName = targ.Name;
                        targ.Children.Add(feature);
                        foundParent = true;
                    }
                }
                if (!foundParent)
                {
                    feature.IsParent = true;
                    feature.FamilyName = feature.Name;
                    olvNeedOne.AddObject(feature);
                    olvNeedOne.ExpandAll();
                }
            }
            else if (!feature.Name.ToLower().Contains("pat"))
            {
                feature.Bucket = Report.Bucket.Required;
                olvRequire.AddObject(feature);
            }
            else
            {
                feature.Bucket = Report.Bucket.Buffer;
                olvBuffer.AddObject(feature);
            }   
        }

        // Functions from here to the end of the region could exist in their own class/form
        private string MakeFeatureDataHistogram(ref ScottPlot.FormsPlot control, Report.State state)
        {
            ScottPlot.Plottable.BarPlot bar;
            double[] data = Report.getData(Data.Where(x => x.State == state).ToArray(), SelectedFeature.Name);
            if (data.Count() == 0)
                return state.ToString();
            else if (data.Max() == 0)
                bar = control.Plot.AddBar(values: new double[] { data.Count() }, positions: new double[] { 0 });
            else if (data.Count() == 1)
                bar = control.Plot.AddBar(values: new double[] {1}, positions: new double[] {data[0]});
            else
            {
                (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(data, min: data.Min(), max: data.Max(), binSize: 1);
                double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();
                bar = control.Plot.AddBar(values: counts, positions: leftEdges);
            }
            bar.BarWidth = 1;
            bar.BorderColor = Color.Transparent;
            bar.Label = state.ToString();

            switch (state)
            {
                case Report.State.Pass:
                    bar.FillColor = Color.LawnGreen;
                    ScottPlot.Plottable.HSpan hSpan =
                        control.Plot.AddHorizontalSpan(data.Min(), data.Max(), Color.FromArgb(75, Color.SlateGray));
                    hSpan.DragEnabled = true;
                    hSpan.Dragged += HSpan_Dragged;
                    break;
                case Report.State.Fail:
                    bar.FillColor = Color.Firebrick;
                    break;
                case Report.State.Null:
                    bar.FillColor = Color.Blue;
                    break;
                default:
                    bar.FillColor = Color.Black;
                    break;
            }

            ViewDataPlots.Add(bar);
            return string.Empty;
        }

        private void HSpan_Dragged(object sender, EventArgs e)
        {
            ScottPlot.Plottable.HSpan hSpan = (ScottPlot.Plottable.HSpan)sender;
            Report.rescoreFeature(Data, SelectedFeature.Name, hSpan.X1, hSpan.X2);
        }

        private void BtnViewData_Click(object sender, EventArgs e)
        {
            ScottPlot.FormsPlot control = new ScottPlot.FormsPlot() { Dock = DockStyle.Fill };
            ViewDataPlots.Clear();
            List<string> skippedPlots = new List<string>();
            foreach (Report.State state in Enum.GetValues(typeof(Report.State)))
            {
                if (state == Report.State.Other) continue;
                string plotName = MakeFeatureDataHistogram(ref control, state);
                if (plotName != string.Empty) skippedPlots.Add(plotName);
            }
            if (skippedPlots.Count > 0)
            {
                string message = "Plots without data: ";
                foreach (string item in skippedPlots)
                    message += $"{item}, ";
                ScottPlot.Plottable.Annotation annotation =
                    control.Plot.AddAnnotation(message.Substring(0, message.Length - 2), -10, 10);
                annotation.BackgroundColor = Color.FromArgb(200, Color.White);
                annotation.BorderColor = Color.Transparent;
                annotation.Font.Color = Color.Black;
                annotation.Shadow = false;
            }

            ViewDataAnnotation = control.Plot.AddAnnotation("Score = N/A", 10, 10);
            ViewDataAnnotation.BackgroundColor = Color.FromArgb(200, Color.White);
            ViewDataAnnotation.BorderColor = Color.Transparent;
            ViewDataAnnotation.Font.Color = Color.Black;
            ViewDataAnnotation.Shadow = false;

            control.Plot.Title(SelectedFeature.Name);
            control.Plot.XAxis.Label("Score");
            control.Plot.YAxis.Label("Count");
            control.Plot.Grid(false);
            control.MouseWheel += Control_MouseWheel;
            control.Configuration.DoubleClickBenchmark = false;
            control.MouseUp += Control_MouseUp;
            control.Refresh();
            Form form = new Form()
            {
                Size = new Size(600, 400),
                FormBorderStyle = FormBorderStyle.SizableToolWindow
            };
            form.Controls.Add(control);
            form.Show();
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            ScottPlot.FormsPlot p = (ScottPlot.FormsPlot)sender;
            (double mX, _) = p.GetMouseCoordinates();
            int x = (int)Math.Floor(mX);
            string message = $"Score = {x}\n";
            foreach (ScottPlot.Plottable.BarPlot barPlot in ViewDataPlots)
                for (int i = 0; i < barPlot.Positions.Length; i++)
                    if (Math.Floor(barPlot.Positions[i]) == x && barPlot.Values[i] > 0)
                        message += $"{barPlot.Label} Count = {barPlot.Values[i]}\n";
            ViewDataAnnotation.Label = message;
            p.Refresh();
        }

        private void Control_MouseWheel(object sender, MouseEventArgs e)
        {
            ScottPlot.FormsPlot control = (ScottPlot.FormsPlot)sender;
            switch(GetControlAxis(control, e.Location))
            {
                case 0:
                    control.Plot.XAxis.LockLimits(true);
                    control.Plot.YAxis.LockLimits(false);
                    break;
                case 1:
                    control.Plot.XAxis.LockLimits(false);
                    control.Plot.YAxis.LockLimits(true);
                    break;
                default:
                    control.Plot.XAxis.LockLimits(false);
                    control.Plot.YAxis.LockLimits(false);
                    break;
            }
        }

        private int GetControlAxis(ScottPlot.FormsPlot control, Point location)
        {
            if (location.X < 60) // At XAxis
                return 0;
            else if (location.Y > control.Height - 60) // At YAxis
                return 1;
            else
                return -1;
        }

        #endregion
    }
}
