using System.Windows.Forms;
using XferHelper;
using BrightIdeasSoftware;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using Microsoft.FSharp.Collections;
using System.IO;

namespace XferSuite.Apps.SEYR
{
    public partial class ParseSEYR : Form
    {
        #region User Parameters

        private int _PassPointSize = 4;
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

        private int _FailPointSize = 4;
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
        [Description("Percentagle of Pass and Fail data to omit for the sake of PC speed")]
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

        private int _RegionBorderTransparency = 100;
        [Category("User Parameters")]
        public int RegionBorderTransparency
        {
            get => _RegionBorderTransparency;
            set
            {
                if (value >= 0 && value <= 255)
                    _RegionBorderTransparency = value;
                else if (value < 0)
                    _RegionBorderTransparency = 0;
                else if (value > 255)
                    _RegionBorderTransparency = 255;
                Results.UpdateData("Region border transparency changed", this);
            }
        }

        private int _RegionLabelTransparency = 100;
        [Category("User Parameters")]
        public int RegionLabelTransparency
        {
            get => _RegionLabelTransparency;
            set
            {
                if (value >= 0 && value <= 255)
                    _RegionLabelTransparency = value;
                else if (value < 0)
                    _RegionLabelTransparency = 0;
                else if (value > 255)
                    _RegionLabelTransparency = 255;
                Results.UpdateData("Region label transparency changed", this);
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

        public string[] Regions;
        public List<Plottable> Plottables = new List<Plottable>();
        public List<PlotOrderElement> PlotOrder = PlotOrderElement.GenerateDefaults();
        public readonly List<CustomFeature> CustomFeatures = new List<CustomFeature>();

        private readonly FileInfo Path;
        private readonly Report.Entry[] Data;
        private Report.Feature[] Features;
        private Report.Feature SelectedFeature;
        private bool ObjectHasBeenDropped; // For criteria selector - possibly unecessary
        private readonly Results Results;
        private ScottPlot.Plottable.Annotation ViewDataAnnotation;
        private readonly List<ScottPlot.Plottable.BarPlot> ViewDataPlots = new List<ScottPlot.Plottable.BarPlot>();
        private readonly BackgroundWorker ParseWorker = new BackgroundWorker();

        public ParseSEYR(string path)
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
            olvNeedOne.CanExpandGetter = delegate (object x) { return ((Report.Feature)x).IsParent; };
            olvNeedOne.ChildrenGetter = delegate (object x) { return ((Report.Feature)x).Children; };

            olvCustom.DoubleClick += OlvCustom_DoubleClick;
            olvCustom.FormatRow += OlvCustom_FormatRow;

            Show();
        }

        private void ResetFeaturesAndUI()
        {
            Features = Report.getFeatures(Data);
            SelectedFeature = null;
            lblSelectedFeature.Text = @"N\A";
            olvBuffer.SetObjects(Features);
            olvRequire.Objects = null;
            olvNeedOne.Objects = null;
            ObjectHasBeenDropped = false;
            toolStripButtonAddCustom.Enabled = Features.Length > 1;
        }

        #endregion

        #region OLV Logic

        private void ModelCanDrop(object sender, ModelDropEventArgs e)
        {
            e.Handled = true;
            e.Effect = DragDropEffects.None;
            if (e.TargetModel != null && !((Report.Feature)e.TargetModel).IsChild)
                e.Effect = DragDropEffects.Link; // Only one branch
            else
                e.Effect = DragDropEffects.Copy;
        }

        private void ModelDropped(object sender, ModelDropEventArgs e)
        {
            foreach (Report.Feature m in e.SourceModels)
            {
                m.Bucket = Report.toBucket(int.Parse(e.ListView.Tag.ToString()));
                if ((ObjectListView)sender == olvNeedOne)
                {
                    if (e.DropTargetLocation == DropTargetLocation.Item)
                    {
                        m.IsChild = true;
                        Report.Feature targ = (Report.Feature)e.TargetModel;
                        m.FamilyName = targ.Name;

                        // Converting between F# and C# lists
                        List<Report.Feature> children = targ.Children.ToList();
                        children.Add(m);
                        targ.Children = ListModule.OfSeq(children);
                    }
                    else
                    {
                        m.IsParent = true;
                        m.FamilyName = m.Name;
                        ((ObjectListView)sender).AddObject(m);
                        olvNeedOne.ExpandAll();
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
            foreach (Report.Feature feature in Features)
                feature.Requirements = requirements.ToArray();
        }

        private void OlvCustom_DoubleClick(object sender, EventArgs e)
        {
            if (olvCustom.SelectedIndex == -1) return;
            CustomFeature feature = (CustomFeature)olvCustom.SelectedObject;
            using (CreateCustom cc = new CreateCustom(Features, CustomFeatures, feature))
            {
                var result = cc.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CustomFeatures[olvCustom.SelectedIndex] = cc.CustomFeature;
                    olvCustom.SelectedItem.BackColor = cc.CustomFeature.Color;
                    olvCustom.SelectedItem.ForeColor = cc.CustomFeature.ContrastColor;
                    olvCustom.SelectedItem.Decoration = 
                        cc.CustomFeature.Type == Report.State.Null ? new ImageDecoration(Properties.Resources.invisible_small, 255) : null;
                    olvCustom.DeselectAll();
                    olvCustom.Refresh();
                    Results.UpdateData("Custom feature updated", this);
                }
                else if (result == DialogResult.Ignore)
                {
                    CustomFeatures.RemoveAt(olvCustom.SelectedIndex);
                    PlotOrder.Remove(PlotOrder.Where(x => x.Name == feature.Name).First());
                    olvCustom.RemoveObject(feature);
                    olvCustom.Refresh();
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

        #endregion

        #region Parse Methods

        private void RunParseWorker()
        {
            if (ParseWorker.IsBusy) return;
            foreach (ObjectListView olv in tableLayoutPanel.Controls.OfType<ObjectListView>())
                olv.Enabled = false;
            flowLayoutPanelCriteria.Enabled = false;
            toolStripProgressBar.Value = 0;
            Results.RTB.Clear();
            ParseWorker.RunWorkerAsync();
        }

        private void ParseWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Reset
            ParseWorker.ReportProgress(1, "(RR, RC, R, C)\tYield\n"); // Header
            Plottables = new List<Plottable>();
            double distX = 0.0;
            double distY = 0.0;

            if (Path.FullName.Contains("_CP_"))
            {
                string[] slice = Path.FullName.Replace(".txt", "").Split('_');
                distX = double.Parse(slice[slice.Length - 2]);
                distY = double.Parse(slice[slice.Length - 1]);
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
                        distX = (double)((NumericUpDown)input.Control).Value;
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
                        distY = (double)((NumericUpDown)input.Control).Value;
                    else
                        return;
                }
            }

            string[] bufferStrings = Features.Where(x => x.Bucket == Report.Bucket.Buffer).Select(x => x.Name).ToArray();
            var filteredData = CustomFeatures.Where(x => x.Visible).Count() > 0 ? Data : Report.removeBuffers(Data, bufferStrings);
            Regions = Report.getRegions(filteredData);

            if (Features.Where(x => x.Bucket == Report.Bucket.Required).Count() == 1 &&
                Features.Where(x => x.Bucket == Report.Bucket.NeedOne).Count() == 0 &&
                CustomFeatures.Where(x => x.Visible).Count() == 0)
                ParseSingle(distX, distY, filteredData);
            else
                ParseMulti(distX, distY, filteredData,
                    !(Features.Where(x => x.Bucket == Report.Bucket.Required).Count() > 0 ||
                    Features.Where(x => x.Bucket == Report.Bucket.NeedOne).Count() > 0));
        }

        private void ParseWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Results.UpdateData("Newly parsed data", this);
            Results.Show();
            Results.BringToFront();
            toolStripProgressBar.Value = 0;
            foreach (ObjectListView olv in tableLayoutPanel.Controls.OfType<ObjectListView>())
                olv.Enabled = true;
            flowLayoutPanelCriteria.Enabled = true;
        }

        private void ParseWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Results.RTB.Text += e.UserState;
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

        // Much, much faster way of parsing large data sets as you do not have to obtain regions
        // within regions and each entry is treated as a tile
        private void ParseSingle(double distX, double distY, Report.Entry[] filteredData)
        {
            for (int l = 0; l < Regions.Length; l++)
            {
                double passNum = 0;
                double failNum = 0;
                Report.Entry[] regionData = Report.getRegion(filteredData, Regions[l]);

                foreach (Report.Entry entry in regionData)
                {
                    bool pass = CheckCriteria(new Report.Entry[] {entry}, new List<string>());
                    double thisX = entry.X + entry.XCopy * distX * (_FlipXAxis ? -1 : 1);
                    double thisY = entry.Y + entry.YCopy * distY;

                    Plottables.Add(new Plottable
                    {
                        Region = Regions[l],
                        DetailString = $"     Copy ({entry.XCopy}, {entry.YCopy})     Location ({thisX}, {thisY})     {(pass ? "Pass" : "Fail")}",
                        X = thisX,
                        Y = thisY,
                        Pass = pass,
                        CustomTag = string.Empty,
                        Color = pass ? Color.LawnGreen : Color.Firebrick,
                    });

                    if (pass)
                        passNum++;
                    else
                        failNum++;
                }

                ParseWorker.ReportProgress((int)((l + 1) / (double)Regions.Length * 100), $"{Regions[l]}\t{passNum / (passNum + failNum):P}\n");
            };
        }

        private void ParseMulti(double distX, double distY, Report.Entry[] filteredData, bool onlyCustom)
        {
            int numX = Report.getNumX(filteredData);
            int numY = Report.getNumY(filteredData);
            List<string> needOneParents = Features.Where(x => x.IsParent).Select(x => x.Name).ToList();

            for (int l = 0; l < Regions.Length; l++)
            {
                double passNum = 0;
                double failNum = 0;
                Report.Entry[] regionData = Report.getRegion(filteredData, Regions[l]);
                int numRegionPics = Report.getNumImages(regionData);

                for (int k = 1; k < numRegionPics + 1; k++)
                {
                    var thisImg = Report.getImage(regionData, k + l * numRegionPics);

                    for (int i = 0; i < numX; i++)
                    {
                        for (int j = 0; j < numY; j++)
                        {
                            var thisCell = Report.getCell(thisImg, i, j);
                            if (thisCell.Length == 0) continue;
                            bool pass = CheckCriteria(thisCell, needOneParents);
                            double thisX = thisCell[0].X + i * distX * (_FlipXAxis ? -1 : 1);
                            double thisY = thisCell[0].Y + j * distY;

                            foreach (CustomFeature custom in CustomFeatures.Where(x => x.Visible))
                            {
                                bool notMatched = false;
                                foreach ((string, Report.State) filter in custom.Filters)
                                    if (thisCell.Where(x => x.Name == filter.Item1).First().State != filter.Item2) notMatched = true;
                                if (notMatched) continue;

                                Plottable customPlottable = new Plottable
                                {
                                    Region = Regions[l],
                                    DetailString = $"     Copy ({thisCell[0].XCopy}, {thisCell[0].YCopy})     Location ({thisX}, {thisY})     {(pass ? "Pass" : "Fail")}     Custom: {custom.Name}",
                                    X = thisX - custom.Offset.X,
                                    Y = thisY - custom.Offset.Y,
                                    Pass = custom.Type == Report.State.Pass,
                                    CustomTag = custom.Name,
                                    Color = custom.Color,
                                };

                                Plottables.Add(customPlottable);

                                if (custom.Type == Report.State.Pass)
                                    passNum++;
                                else if (custom.Type == Report.State.Fail)
                                    failNum++;
                            }

                            if (!onlyCustom)
                            {
                                Plottables.Add(new Plottable
                                {
                                    Region = Regions[l],
                                    DetailString = $"     Copy ({thisCell[0].XCopy}, {thisCell[0].YCopy})     Location ({thisX}, {thisY})     {(pass ? "Pass" : "Fail")}",
                                    X = thisX,
                                    Y = thisY,
                                    Pass = pass,
                                    CustomTag = string.Empty,
                                    Color = pass ? Color.LawnGreen : Color.Firebrick,
                                });

                                if (pass)
                                    passNum++;
                                else
                                    failNum++;
                            }
                        }
                    }
                }

                ParseWorker.ReportProgress((int)((l + 1) / (double)Regions.Length * 100), $"{Regions[l]}\t{passNum / (passNum + failNum):P}\n");
            };
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
            RunParseWorker();  
        }

        private void ToolStripButtonSmartSort_Click(object sender, EventArgs e)
        {
            if (ParseWorker.IsBusy) return;
            
            Report.Feature[] originalFeatures = Features; // Maintain requirements
            ResetFeaturesAndUI();

            // Alphabetical order looks better in the NeedOne bucket
            var sortList = Features.ToList();
            sortList.Sort();
            Features = sortList.ToArray();

            flowLayoutPanelCriteria.Enabled = false;
            olvBuffer.Objects = null;

            Report.Feature[] criteria = Features.Where(x => !x.Name.Contains("pat")).ToArray();
            if (criteria.Length == 1)
            {
                criteria[0].Bucket = Report.Bucket.Required;
                olvRequire.AddObject(criteria[0]);
                olvBuffer.AddObjects(Features.Where(x => x.Name.Contains("pat")).ToArray());
            }
            else
            {
                foreach (Report.Feature feature in Features)
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
                {
                    olvCustom.AddObject(cc.CustomFeature);
                    CustomFeatures.Add(cc.CustomFeature);
                    PlotOrder.Add(new PlotOrderElement() { Name = cc.CustomFeature.Name });
                }
                else
                    return;
            }
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
                Report.Feature criteria = Features.First(x => x.Name == item.Name);
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

        private void FindHome(Report.Feature feature)
        {
            char[] digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (feature.Name.Any(char.IsDigit))
            {
                feature.Bucket = Report.Bucket.NeedOne;
                string rootName = feature.Name.TrimEnd(digits);
                bool foundParent = false;
                foreach (var item in olvNeedOne.Objects)
                {
                    Report.Feature targ = (Report.Feature)item;
                    if (targ.Name.Contains(rootName) && targ.IsParent)
                    {
                        feature.IsChild = true;
                        feature.FamilyName = targ.Name;

                        // Converting between F# and C# lists
                        List<Report.Feature> children = targ.Children.ToList();
                        children.Add(feature);
                        targ.Children = ListModule.OfSeq(children);
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
                case Report.State.Misaligned:
                    bar.FillColor = Color.ForestGreen;
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
