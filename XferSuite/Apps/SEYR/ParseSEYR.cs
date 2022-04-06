using System.Windows.Forms;
using XferHelper;
using BrightIdeasSoftware;
using System;
using System.Linq;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using System.Drawing;
using System.ComponentModel;
using Microsoft.FSharp.Collections;
using System.IO;
using System.Text;

namespace XferSuite.Apps.SEYR
{
    public partial class ParseSEYR : Form
    {
        #region User Parameters

        private bool _FlipXAxis = true;
        [Category("User Parameters")]
        public bool FlipXAxis
        {
            get => _FlipXAxis;
            set
            {
                _FlipXAxis = value;
                RunParseWorker();
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
                RunParseWorker();
            }
        }

        private int _PointSize = 1;
        [Category("User Parameters")]
        public int PointSize
        {
            get => _PointSize;
            set
            {
                _PointSize = value;
                ConfigurePlot();
            }
        }

        private bool _TransposePlot = false;
        [Category("User Parameters")]
        [Description("Flip X and Y coords of scatterpoints")]
        public bool TransposePlot
        {
            get => _TransposePlot;
            set
            {
                _TransposePlot = value;
                List<Plottable> PlottablesRotated = new List<Plottable>();
                foreach (Plottable p in Plottables)
                {
                    PlottablesRotated.Add(new Plottable
                    {
                        Region = p.Region,
                        X = p.Y,
                        Y = p.X,
                        Pass = p.Pass,
                        Color = p.Color,
                        Size = p.Size,
                        CustomTag = p.CustomTag,
                    });
                }
                Plottables = PlottablesRotated;
                ConfigurePlot();
            }
        }

        private bool _ShowAxesNames = false;
        [Category("User Parameters")]
        public bool ShowAxesNames
        {
            get => _ShowAxesNames;
            set
            {
                _ShowAxesNames = value;
                ConfigurePlot();
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
            public OxyColor Color;
            public int Size;
            public string CustomTag;

            public override string ToString()
            {
                return $"Region {Region}{DetailString}";
            }
        }

        private FileInfo Path { get; set; }
        private Report.Entry[] Data { get; set; }
        private Report.Feature[] Features { get; set; }
        private Report.Feature SelectedFeature { get; set; }
        private bool ObjectHasBeenDropped { get; set; } // For criteria selector - possibly unecessary

        private List<Plottable> Plottables = new List<Plottable>();
        private List<CustomFeature> CustomFeatures = new List<CustomFeature>();
        private List<string> PlotOrder = new List<string>();
        private ScottPlot.Plottable.Annotation ViewDataAnnotation;
        private readonly List<ScottPlot.Plottable.BarPlot> ViewDataPlots = new List<ScottPlot.Plottable.BarPlot>();
        private readonly List<(PlotView, int, int)> ContextMenuTable = new List<(PlotView, int, int)>(); // Will be replaced when upgraded to Scottplot
        private readonly BackgroundWorker ParseWorker = new BackgroundWorker();

        public ParseSEYR(string path)
        {
            InitializeComponent();
            Path = new FileInfo(path);
            Text = Path.Name.Replace(Path.Extension, string.Empty);
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

            checkedListBox.ItemCheck += CheckedListBox_ItemCheck;

            Show();
        }

        private void ResetFeaturesAndUI(bool preserveCustom = false)
        {
            Features = Report.getFeatures(Data);
            SelectedFeature = null;
            lblSelectedFeature.Text = @"N\A";
            toolStripButtonCopyParsedCSV.Enabled = false;
            olvBuffer.SetObjects(Features);
            olvRequire.Objects = null;
            olvNeedOne.Objects = null;
            ObjectHasBeenDropped = false;
            toolStripButtonAddCustom.Enabled = Features.Length > 1;
            if (!preserveCustom)
            {
                CustomFeatures = new List<CustomFeature>();
                checkedListBox.Items.Clear();
            }
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

        #endregion

        #region Parse Methods

        private void RunParseWorker()
        {
            if (ParseWorker.IsBusy) return;
            foreach (ObjectListView olv in tableLayoutPanel.Controls.OfType<ObjectListView>())
                olv.Enabled = false;
            flowLayoutPanelCriteria.Enabled = false;
            toolStripProgressBar.Value = 0;
            ParseWorker.RunWorkerAsync();
        }

        private void ParseWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Parse();
        }

        private void ParseWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ConfigurePlot();
            toolStripProgressBar.Value = 0;
            foreach (ObjectListView olv in tableLayoutPanel.Controls.OfType<ObjectListView>())
                olv.Enabled = true;
            flowLayoutPanelCriteria.Enabled = true;
            toolStripButtonCopyParsedCSV.Enabled = true;
        }

        private void ParseWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //rtb.Text += e.UserState.ToString(); // TODO ADD TO PLOT
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void Parse(bool noPitches = false)
        {
            if (Features.Where(x => x.Bucket == Report.Bucket.Buffer).Count() == Features.Length && CustomFeatures.Count == 0)
            {
                MessageBox.Show("All features are buffers. Parsing aborted.");
                return;
            }

            // Reset
            ParseWorker.ReportProgress(1, "(RR, RC, R, C)\tYield\n"); // Header
            Plottables = new List<Plottable>();
            double distX = 0.0;
            double distY = 0.0;

            if (!noPitches)
            {
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
            }

            string[] bufferStrings = Features.Where(x => x.Bucket == Report.Bucket.Buffer).Select(x => x.Name).ToArray();
            var filteredData = CustomFeatures.Count == 0 ? Report.removeBuffers(Data, bufferStrings) : Data;
            string[] regions = Report.getRegions(filteredData);

            if (Features.Where(x => x.Bucket == Report.Bucket.Required).Count() == 1 &&
                Features.Where(x => x.Bucket == Report.Bucket.NeedOne).Count() == 0 &&
                CustomFeatures.Count == 0)
                ParseSingle(distX, distY, filteredData, regions);
            else
                ParseMulti(distX, distY, filteredData, regions, 
                    !(Features.Where(x => x.Bucket == Report.Bucket.Required).Count() > 0 ||
                    Features.Where(x => x.Bucket == Report.Bucket.NeedOne).Count() > 0));
        }

        // Much, much faster way of parsing large data sets as you do not have to obtain regions
        // within regions and each entry is treated as a tile
        private void ParseSingle(double distX, double distY, Report.Entry[] filteredData, string[] regions)
        {
            for (int l = 0; l < regions.Length; l++)
            {
                double passNum = 0;
                double failNum = 0;
                Report.Entry[] regionData = Report.getRegion(filteredData, regions[l]);

                foreach (Report.Entry entry in regionData)
                {
                    bool pass = CheckCriteria(new Report.Entry[] {entry}, new List<string>());
                    double thisX = entry.X + entry.XCopy * distX * (_FlipXAxis ? -1 : 1);
                    double thisY = entry.Y + entry.YCopy * distY * (_FlipYAxis ? 1 : -1);

                    Plottables.Add(new Plottable
                    {
                        Region = regions[l],
                        DetailString = $"\nCopy ({entry.XCopy}, {entry.YCopy})\nLocation ({thisX}, {thisY})\n{(pass ? "Pass" : "Fail")}",
                        X = thisX,
                        Y = thisY,
                        Pass = pass,
                        Color = pass ? OxyColors.LawnGreen : OxyColors.Firebrick,
                        Size = _PointSize,
                        CustomTag = string.Empty,
                    });

                    if (pass)
                        passNum++;
                    else
                        failNum++;
                }

                ParseWorker.ReportProgress((int)((l + 1) / (double)regions.Length * 100), $"{regions[l]}\t{passNum / (passNum + failNum):P}\n");
            };
        }

        private void ParseMulti(double distX, double distY, Report.Entry[] filteredData, string[] regions, bool onlyCustom)
        {
            int numX = Report.getNumX(filteredData);
            int numY = Report.getNumY(filteredData);
            List<string> needOneParents = Features.Where(x => x.IsParent).Select(x => x.Name).ToList();

            for (int l = 0; l < regions.Length; l++)
            {
                double passNum = 0;
                double failNum = 0;
                Report.Entry[] regionData = Report.getRegion(filteredData, regions[l]);
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
                            double thisY = thisCell[0].Y + j * distY * (_FlipYAxis ? 1 : -1);

                            foreach (CustomFeature custom in CustomFeatures)
                            {
                                bool matchesFilter = false;      
                                foreach ((string, Report.State) filter in custom.Filters)
                                    matchesFilter = thisCell.Where(x => x.Name == filter.Item1).First().State == filter.Item2;
                                if (matchesFilter)
                                {
                                    Plottable customPlottable = new Plottable
                                    {
                                        Region = regions[l],
                                        DetailString = $"\nCopy ({thisCell[0].XCopy}, {thisCell[0].YCopy})\nLocation ({thisX}, {thisY})\n{(pass ? "Pass" : "Fail")}\nCustom: {custom.Name}",
                                        X = thisX + custom.Offset.X,
                                        Y = thisY + custom.Offset.Y,
                                        Pass = custom.Type == Report.State.Pass,
                                        Color = custom.Color,
                                        Size = custom.Size,
                                        CustomTag = custom.Name,
                                    };

                                    Plottables.Add(customPlottable);

                                    if (customPlottable.Pass)
                                        passNum++;
                                    else
                                        failNum++;
                                }
                            }

                            if (!onlyCustom)
                            {
                                Plottables.Add(new Plottable
                                {
                                    Region = regions[l],
                                    DetailString = $"\nCopy ({thisCell[0].XCopy}, {thisCell[0].YCopy})\nLocation ({thisX}, {thisY})\n{(pass ? "Pass" : "Fail")}",
                                    X = thisX,
                                    Y = thisY,
                                    Pass = pass,
                                    Color = pass ? OxyColors.LawnGreen : OxyColors.Firebrick,
                                    Size = _PointSize,
                                    CustomTag = string.Empty,
                                });

                                if (pass)
                                    passNum++;
                                else
                                    failNum++;
                            }
                        }
                    }
                }

                ParseWorker.ReportProgress((int)((l + 1) / (double)regions.Length * 100), $"{regions[l]}\t{passNum / (passNum + failNum):P}\n");
            };
        }

        #endregion

        #region Custom UI Elements

        // This region will dissapear after upgrading to Scottplot
        private (ContextMenu, int, int) InitContextMenu()
        {
            MenuItem savePlot = new MenuItem() { Text = "Save Plot" };
            savePlot.Click += SavePlot_Click;
            MenuItem copyPlot = new MenuItem() { Text = "Copy Plot" };
            copyPlot.Click += CopyPlot_Click;
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add(savePlot);
            cm.MenuItems.Add(copyPlot);
            return (cm, savePlot.GetHashCode(), copyPlot.GetHashCode());
        }

        private void SavePlot_Click(object sender, EventArgs e)
        {
            foreach (var entry in ContextMenuTable)
            {
                if (entry.Item2 == ((MenuItem)sender).GetHashCode())
                {
                    PlotView plotView = entry.Item1;
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Title = "Save SEYR Plot";
                        saveFileDialog.DefaultExt = ".png";
                        saveFileDialog.Filter = "png file (*.png)|*.png";
                        saveFileDialog.FileName = Text;
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            var pngExporter = new PngExporter { Width = plotView.Width, Height = plotView.Width };
                            Bitmap fg = pngExporter.ExportToBitmap(plotView.Model);
                            Bitmap bg = new Bitmap(fg.Width, fg.Height);
                            using (Graphics g = Graphics.FromImage(bg))
                            {
                                g.FillRectangle(Brushes.White, new Rectangle(Point.Empty, bg.Size));
                                g.DrawImage(fg, new Point(0, 0));
                            }
                            bg.Save(saveFileDialog.FileName);
                        }
                    }
                    return;
                }
            }
            MessageBox.Show("Operation Failed", "XferSuite");
        }

        private void CopyPlot_Click(object sender, EventArgs e)
        {
            foreach (var entry in ContextMenuTable)
            {
                if (entry.Item3 == ((MenuItem)sender).GetHashCode())
                {
                    PlotView plotView = entry.Item1;
                    Bitmap bitmap = new Bitmap(plotView.Width, plotView.Height);
                    plotView.DrawToBitmap(bitmap, new Rectangle(0, 0, plotView.Width, plotView.Height));
                    Clipboard.SetImage(bitmap);
                    return;
                }
            }
            MessageBox.Show("Operation Failed", "XferSuite");
        }

        #endregion

        #region Plotting Methods

        // This region will move to it's own class/form during Scottplot upgrade

        private PlotView InitPlotView()
        {
            PlotView view = new PlotView() { Dock = DockStyle.Fill };
            (ContextMenu cm, int saveId, int copyId) = InitContextMenu();
            ContextMenuTable.Add((view, saveId, copyId));
            view.ContextMenu = cm;
            return view;
        }

        private PlotModel InitPlotModel()
        {
            PlotModel plotModel = new PlotModel();
            plotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                TickStyle = OxyPlot.Axes.TickStyle.None,
                StartPosition = _FlipXAxis ? 1 : 0,
                EndPosition = _FlipXAxis ? 0 : 1,
                Title = _ShowAxesNames ? "X Position (mm)" : null,
            });
            plotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                TickStyle = OxyPlot.Axes.TickStyle.None,
                StartPosition = _FlipYAxis ? 1 : 0,
                EndPosition = _FlipYAxis ? 0 : 1,
                Title = _ShowAxesNames ? "Y Position (mm)" : null,
            });
            return plotModel;
        }

        private (ScatterSeries, ScatterSeries) InitScatterSeries()
        {
            return (
                new ScatterSeries()
                {
                    MarkerFill = OxyColors.LawnGreen,
                    MarkerSize = _PointSize,
                    TrackerFormatString = "{Tag}"
                },
                new ScatterSeries()
                {
                    MarkerFill = OxyColors.Firebrick,
                    MarkerSize = _PointSize,
                    TrackerFormatString = "{Tag}"
                }
            );
        }

        private void StackAndShowPlots(ref PlotView view, ref PlotModel model, ScatterSeries passSeries, ScatterSeries failSeries, List<ScatterSeries> customScatters)
        {
            if (PlotOrder.Count != 2 + CustomFeatures.Where(x => x.Checked).Select(x => x.Name).Count()) AutoPlotOrder();
            foreach (string plotName in PlotOrder)
            {
                if (plotName == "Pass")
                    model.Series.Add(passSeries);
                else if (plotName == "Fail")
                    model.Series.Add(failSeries);
                else
                    model.Series.Add(customScatters[
                        CustomFeatures.Where(x => x.Checked).ToList().
                        IndexOf(CustomFeatures.Where(x => x.Name == plotName).First())]);
            }
            view.Model = model;
        }

        private void AutoPlotOrder()
        {
            PlotOrder = new List<string>() { "Pass", "Fail" };
            PlotOrder.AddRange(CustomFeatures.Where(x => x.Checked).Select(x => x.Name));
        }

        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CustomFeatures[e.Index].Checked = e.NewValue == CheckState.Checked;
        }

        private void ConfigurePlot()
        {
            if (Plottables.Count == 0) return;
            PlotView plot = InitPlotView();
            PlotModel plotModel = InitPlotModel();
            (ScatterSeries passScatter,  ScatterSeries failScatter) = InitScatterSeries();
            foreach (Plottable p in Plottables.Where(x => string.IsNullOrEmpty(x.CustomTag)))
            {
                ScatterPoint scatterPoint = new ScatterPoint(p.X, p.Y, tag: p.ToString());
                if (p.Pass)
                    passScatter.Points.Add(scatterPoint);
                else
                    failScatter.Points.Add(scatterPoint);
            }
            List<ScatterSeries> customScatters = new List<ScatterSeries>();
            foreach (CustomFeature customFeature in CustomFeatures.Where(x => x.Checked))
            {
                ScatterSeries scatter = new ScatterSeries()
                {
                    MarkerFill = customFeature.Color,
                    MarkerSize = customFeature.Size,
                    TrackerFormatString = "{Tag}"
                };
                Plottable[] customPlottables = Plottables.Where(x => x.CustomTag == customFeature.Name).ToArray();
                foreach (Plottable p in customPlottables)
                    scatter.Points.Add(new ScatterPoint(p.X, p.Y, tag: p.ToString()));
                customScatters.Add(scatter);
            }
            StackAndShowPlots(ref plot, ref plotModel, passScatter, failScatter, customScatters);
            Form form = InitLargeForm(Text);
            form.Controls.Add(plot);
            form.Show();
            form.BringToFront();
        }

        private Form InitLargeForm(string text)
        {
            var xData = Plottables.Select(p => p.X);
            var yData = Plottables.Select(p => p.Y);
            double xRange = xData.Max() - xData.Min();
            double yRange = yData.Max() - yData.Min();
            double xScale = 1.0;
            double yScale = 1.0;
            if (xRange > yRange)
                yScale = yRange / xRange;
            else
                xScale = xRange / yRange;

            Rectangle bounds = Screen.FromControl(this).Bounds;
            int size = (int)(Math.Min(bounds.Width, bounds.Height) * 0.95);
            Form form = new Form()
            {
                Width = (int)(size * xScale),
                Height = (int)(size * yScale),
                FormBorderStyle = FormBorderStyle.SizableToolWindow,
                StartPosition = FormStartPosition.CenterScreen,
                Text = text,
                Tag = (xScale/yScale).ToString()
            };
            form.Resize += Form_Resize;
            return form;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control) || ModifierKeys.HasFlag(Keys.Alt) || ModifierKeys.HasFlag(Keys.Shift))
            {
                Form form = (Form)sender;
                form.Size = new Size((int)(form.Height * double.Parse(form.Tag.ToString())), form.Height);
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
            RunParseWorker();  
        }

        private void ToolStripButtonSmartSort_Click(object sender, EventArgs e)
        {
            if (ParseWorker.IsBusy) return;
            
            Report.Feature[] originalFeatures = Features; // Maintain requirements
            ResetFeaturesAndUI(preserveCustom: true);

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
                    CustomFeatures.Add(cc.CustomFeature);
                    checkedListBox.Items.Add(cc.CustomFeature.Name);
                    checkedListBox.SetItemChecked(CustomFeatures.Count - 1, true);
                }
                else
                    return;
            }
        }

        private void ToolStripButtonEditPlotOrder_Click(object sender, EventArgs e)
        {
            AutoPlotOrder();
            using (EditPlotOrder edit = new EditPlotOrder(PlotOrder))
            {
                var result = edit.ShowDialog();
                if (result == DialogResult.OK)
                    PlotOrder = edit.PlotOrder;
                else
                    return;
            }
        }

        private void ToolStripButtonCopyParsedCSV_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("X\tY\tRR\tRC\tR\tC\tState\tCustomTag\n");
            foreach (Plottable p in Plottables)
            {
                string regionCSV = p.Region.Substring(1, p.Region.Length - 2).Replace(", ", "\t");
                sb.Append($"{Math.Round(p.X, 3)}\t{Math.Round(p.Y, 3)}\t{regionCSV}\t{(p.Pass ? "Pass" : "Fail")}\t{p.CustomTag}\n");
            }
            Clipboard.SetText(sb.ToString());
            MessageBox.Show("Data copied to clipboard", "XferSuite");
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
