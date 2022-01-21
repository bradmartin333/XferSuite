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

namespace XferSuite
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
                ConfigurePlot();
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
                ConfigurePlot();
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
                        Pass = p.Pass
                    });
                }
                Plottables = PlottablesRotated;
                ConfigurePlot();
            }
        }

        private bool _PlotOrder = true;
        [Category("User Parameters")]
        [Description("True: Fail beneath Pass, False: Pass beneath Fail")]
        public bool PlotOrder
        {
            get => _PlotOrder;
            set
            {
                _PlotOrder = value;
                ConfigurePlot();
            }
        }

        #endregion

        #region Globals and Setup

        public struct Plottable
        {
            public string Region;
            public double X;
            public double Y;
            public bool Pass;

            public override string ToString()
            {
                return $"Region {Region}";
            }
        }

        private FileInfo Path { get; set; }
        private Report.Entry[] Data { get; set; }
        private Report.Criteria[] Features { get; set; }
        private Report.Criteria SelectedFeature { get; set; }
        private bool ObjectHasBeenDropped { get; set; }

        private List<Plottable> Plottables = new List<Plottable>();
        private double XMax, YMax;
        private ScatterSeries PassScatter, FailScatter;
        private List<(PlotView, int, int)> ContextMenuTable = new List<(PlotView, int, int)>();

        public ParseSEYR(string path)
        {
            InitializeComponent();
            Path = new FileInfo(path);
            Text = Path.Name.Replace(Path.Extension, string.Empty);
            Data = Report.data(Path.FullName);
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
            olvNeedOne.CanExpandGetter = delegate (object x) { return ((Report.Criteria)x).IsParent; };
            olvNeedOne.ChildrenGetter = delegate (object x) { return ((Report.Criteria)x).Children; };

            Show();
        }

        private void ResetFeaturesAndUI()
        {
            Features = Report.getFeatures(Data);
            SelectedFeature = null;
            lblSelectedFeature.Text = @"N\A";

            rtb.Text = "";
            toolStripButtonSpecificRegion.Enabled = false;

            olvBuffer.SetObjects(Features);
            olvRequire.Objects = null;
            olvNeedOne.Objects = null;
            ObjectHasBeenDropped = false;
        }

        #endregion

        #region OLV Logic

        private void ModelCanDrop(object sender, ModelDropEventArgs e)
        {
            e.Handled = true;
            e.Effect = DragDropEffects.None;
            if (e.TargetModel != null) 
            {
                // Only one branch
                if (!((Report.Criteria)e.TargetModel).IsChild)
                    e.Effect = DragDropEffects.Link;
            }
            else
                e.Effect = DragDropEffects.Copy;
        }

        private void ModelDropped(object sender, ModelDropEventArgs e)
        {
            foreach (Report.Criteria m in e.SourceModels)
            {
                m.Bucket = Report.toBucket(int.Parse(e.ListView.Tag.ToString()));
                if ((ObjectListView)sender == olvNeedOne)
                {
                    if (e.DropTargetLocation == DropTargetLocation.Item)
                    {
                        m.IsChild = true;
                        Report.Criteria targ = (Report.Criteria)e.TargetModel;
                        m.FamilyName = targ.Name;

                        // Converting between F# and C# lists
                        List<Report.Criteria> children = targ.Children.ToList();
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
                {
                    ((ObjectListView)sender).AddObject(m);
                }
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

        private void cbx_CheckedChanged(object sender, EventArgs e)
        {
            List<Report.State> requirements = new List<Report.State>();
            foreach (CheckBox cbx in flowLayoutPanelCriteria.Controls.OfType<CheckBox>())
                if (cbx.Checked) requirements.Add(Report.toState(int.Parse(cbx.Tag.ToString())));
            Features.First(x => x.Name == SelectedFeature.Name).Requirements = requirements.ToArray();
        }

        private void btnApplyToAll_Click(object sender, EventArgs e)
        {
            List<Report.State> requirements = new List<Report.State>();
            foreach (CheckBox cbx in flowLayoutPanelCriteria.Controls.OfType<CheckBox>())
                if (cbx.Checked) requirements.Add(Report.toState(int.Parse(cbx.Tag.ToString())));
            foreach (Report.Criteria feature in Features)
                feature.Requirements = requirements.ToArray();
        }

        #endregion

        #region Parse Methods

        private void Parse(bool noPitches = false)
        {
            if (Features.Where(x => x.Bucket == Report.Bucket.Buffer).Count() == Features.Length)
            {
                MessageBox.Show("All features are buffers. Parsing aborted.");
                return;
            }

            // Reset
            rtb.Text = "(RR, RC, R, C)\tYield\n";
            Plottables = new List<Plottable>();
            double distX = 0.0;
            double distY = 0.0;

            if (!noPitches)
            {
                using (PromptForInput input = new PromptForInput(
                    prompt: "Enter X grid pitch in millimeters",
                    textEntry: false,
                    max: 100,
                    title: $"SEYR Parser Grid Setup"))
                {
                    var result = input.ShowDialog();
                    if (result == DialogResult.OK)
                        distX = (double)((NumericUpDown)input.Control).Value;
                }
                using (PromptForInput input = new PromptForInput(
                    prompt: "Enter Y grid pitch in millimeters",
                    textEntry: false,
                    max: 100,
                    title: $"SEYR Parser Grid Setup"))
                {
                    var result = input.ShowDialog();
                    if (result == DialogResult.OK)
                        distY = (double)((NumericUpDown)input.Control).Value;
                }
            }

            using (new HourGlass(UsePlexiglass: false))
            {
                // Filter out buffer data
                string[] bufferStrings = Features.Where(x => x.Bucket == Report.Bucket.Buffer).Select(x => x.Name).ToArray();
                var filteredData = Report.removeBuffers(Data, bufferStrings);
                string[] regions = Report.getRegions(filteredData);

                if (Features.Where(x => x.Bucket == Report.Bucket.Required).Count() == 1 &&
                    Features.Where(x => x.Bucket == Report.Bucket.NeedOne).Count() == 0)
                    ParseSingle(distX, distY, filteredData, regions);
                else
                    ParseMulti(distX, distY, filteredData, regions);

                if (Plottables.Count > 0)
                {
                    rtb.Text += $"\nTotal\t{Plottables.Where(p => p.Pass).Count() / (double)(Plottables.Count()):P}";

                    XMax = Plottables.Select(p => p.X).Max();
                    YMax = Plottables.Select(p => p.Y).Max();

                    ConfigurePlot();
                    toolStripButtonSpecificRegion.Enabled = true;
                }
            }
        }

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

                    Plottables.Add(new Plottable
                    {
                        Region = regions[l],
                        X = entry.X + (entry.XCopy * distX),
                        Y = entry.Y + (entry.YCopy * distY),
                        Pass = pass
                    });

                    if (pass)
                        passNum++;
                    else
                        failNum++;
                }

                rtb.Text += $"{regions[l]}\t{passNum / (passNum + failNum):P}\n";
            };
        }

        private void ParseMulti(double distX, double distY, Report.Entry[] filteredData, string[] regions)
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

                            Plottables.Add(new Plottable
                            {
                                Region = regions[l],
                                X = thisCell[0].X + (i * distX),
                                Y = thisCell[0].Y + (j * distY),
                                Pass = pass
                            });

                            if (pass)
                                passNum++;
                            else
                                failNum++;
                        }
                    }
                }

                rtb.Text += $"{regions[l]}\t{passNum / (passNum + failNum):P}\n";
            };
        }

        #endregion

        #region Custom UI Elements
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

        private PlotView InitPlotView()
        {
            PlotView view = new PlotView() { Dock = DockStyle.Fill };
            (ContextMenu cm, int saveId, int copyId) = InitContextMenu();
            ContextMenuTable.Add((view, saveId, copyId));
            view.ContextMenu = cm;
            return view;
        }

        private PlotModel InitPlotModel(bool visible = true)
        {
            PlotModel plotModel = new PlotModel();
            plotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                TickStyle = OxyPlot.Axes.TickStyle.None,
                IsAxisVisible = visible,
            });
            plotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                TickStyle = OxyPlot.Axes.TickStyle.None,
                IsAxisVisible = visible,
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

        private void StackAndShowPlots(ref PlotView view, ref PlotModel model, ScatterSeries passSeries, ScatterSeries failSeries)
        {
            if (_PlotOrder)
            {
                model.Series.Add(failSeries);
                model.Series.Add(passSeries);
            }
            else
            {
                model.Series.Add(passSeries);
                model.Series.Add(failSeries);
            }
            view.Model = model;
        }

        private void ConfigurePlot()
        {
            PlotView plot = InitPlotView();
            PlotModel plotModel = InitPlotModel(visible: false);
            (ScatterSeries passScatter,  ScatterSeries failScatter) = InitScatterSeries();
            foreach (Plottable p in Plottables)
            {
                ScatterPoint scatterPoint = new ScatterPoint(
                    _FlipXAxis ? Math.Abs(XMax - p.X) : p.X,
                    _FlipYAxis ? Math.Abs(YMax - p.Y) : p.Y,
                    tag: p.ToString());

                if (p.Pass)
                    passScatter.Points.Add(scatterPoint);
                else
                    failScatter.Points.Add(scatterPoint);
            }
            PassScatter = passScatter;
            FailScatter = failScatter;
            StackAndShowPlots(ref plot, ref plotModel, passScatter, failScatter);
            Form form = InitLargeForm(Text);
            form.Controls.Add(plot);
            form.Show();
        }

        private void ConfigureSpecificRegionPlot(string region)
        {
            PlotView plot = InitPlotView();
            PlotModel plotModel = plotModel = InitPlotModel();
            (ScatterSeries passScatter, ScatterSeries failScatter) = InitScatterSeries();
            passScatter.Points.AddRange(PassScatter.Points.Where(x => x.Tag.ToString().Contains(region)));
            failScatter.Points.AddRange(FailScatter.Points.Where(x => x.Tag.ToString().Contains(region)));
            StackAndShowPlots(ref plot, ref plotModel, passScatter, failScatter);
            Form form = InitLargeForm(region);
            form.Controls.Add(plot);
            form.Show();
        }

        private Form InitLargeForm(string text)
        {
            Rectangle bounds = Screen.FromControl(this).Bounds;
            int size = (int)(Math.Min(bounds.Width, bounds.Height) * 0.95);
            return new Form()
            {
                Width = size,
                Height = size,
                FormBorderStyle = FormBorderStyle.SizableToolWindow,
                StartPosition = FormStartPosition.CenterScreen,
                Text = text
            };
        }

        #endregion

        #region Tool Strip Methods

        private void toolStripButtonReset_Click(object sender, EventArgs e)
        {
            ResetFeaturesAndUI();
        }

        private void toolStripButtonParse_Click(object sender, EventArgs e)
        {
            Parse();
        }

        private void toolStripButtonParseNoPicthes_Click(object sender, EventArgs e)
        {
            Parse(noPitches: true);
        }

        private void toolStripButtonCopyText_Click(object sender, EventArgs e)
        {
            if (rtb.Text != "") Clipboard.SetText(rtb.Text);
        }

        private void toolStripButtonCopyWindow_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            DrawToBitmap(bmp, new Rectangle(0, 0, Width, Height));
            Clipboard.SetImage(bmp);
        }

        private void toolStripButtonSmartSort_Click(object sender, EventArgs e)
        {
            Report.Criteria[] originalFeatures = Features; // Maintain requirements
            ResetFeaturesAndUI();

            // Alphabetical order looks better in the NeedOne bucket
            var sortList = Features.ToList();
            sortList.Sort();
            Features = sortList.ToArray();

            flowLayoutPanelCriteria.Enabled = false;
            olvBuffer.Objects = null;

            foreach (Report.Criteria feature in Features)
            {
                feature.Requirements = originalFeatures.First(x => x.Name == feature.Name).Requirements;
                FindHome(feature);
            }

            olvNeedOne.RebuildAll(true);
        }

        private void toolStripButtonSpecificRegion_Click(object sender, EventArgs e)
        {
            string region = string.Empty;

            using (PromptForInput input = new PromptForInput(
                prompt: "Enter region string to be plotted (RR, RC, R, C)",
                title: $"SEYR Parser Specific Region Plotting"))
            {
                var result = input.ShowDialog();
                if (result == DialogResult.OK)
                    region = ((TextBox)input.Control).Text;
                else
                    return;
            }

            if (!Plottables.Where(p => p.Region == region).Any())
            {
                MessageBox.Show("Specified region not found");
                return;
            }

            ConfigureSpecificRegionPlot(region);
        }

        #endregion

        #region Feature Manipulation Methods

        private bool CheckCriteria(Report.Entry[] thisCell, List<string> needOneParents)
        {
            List<bool>[] needOneLists = new List<bool>[needOneParents.Count];

            for (int i = 0; i < thisCell.Length; i++)
            {
                Report.Entry item = thisCell[i];
                Report.Criteria criteria = Features.First(x => x.Name == item.Name);
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

        private void FindHome(Report.Criteria feature)
        {
            char[] digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (feature.Name.Any(char.IsDigit))
            {
                feature.Bucket = Report.Bucket.NeedOne;
                string rootName = feature.Name.TrimEnd(digits);
                bool foundParent = false;
                foreach (var item in olvNeedOne.Objects)
                {
                    Report.Criteria targ = (Report.Criteria)item;
                    if (targ.Name.Contains(rootName) && targ.IsParent)
                    {
                        feature.IsChild = true;
                        feature.FamilyName = targ.Name;

                        // Converting between F# and C# lists
                        List<Report.Criteria> children = targ.Children.ToList();
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

        private string MakeFeatureDataHistogram(ref ScottPlot.FormsPlot control, Report.State state)
        {
            try
            {
                double[] data = Report.getData(
                Data.Where(x => x.State == state).ToArray(), SelectedFeature.Name);
                if (data.Length < 3) return state.ToString();
                (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(
                    data, min: data.Min(), max: data.Max(), binSize: 1);
                double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();
                ScottPlot.Plottable.BarPlot bar = control.Plot.AddBar(values: counts, positions: leftEdges);
                bar.BarWidth = 1;
                bar.BorderColor = Color.Transparent;
                switch (state)
                {
                    case Report.State.Pass:
                        bar.FillColor = Color.LawnGreen;
                        ScottPlot.Plottable.HSpan hSpan =
                            control.Plot.AddHorizontalSpan(data.Min(), data.Max(), Color.FromArgb(50, Color.LawnGreen));
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
                return string.Empty;
            }
            catch (Exception) { }
            return state.ToString();
        }

        private void HSpan_Dragged(object sender, EventArgs e)
        {
            ScottPlot.Plottable.HSpan hSpan = (ScottPlot.Plottable.HSpan)sender;
            Report.rescoreFeature(Data, SelectedFeature.Name, hSpan.X1, hSpan.X2);
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            ScottPlot.FormsPlot control = new ScottPlot.FormsPlot() { Dock = DockStyle.Fill };
            List<string> skippedPlots = new List<string>();
            foreach (Report.State state in Enum.GetValues(typeof(Report.State)))
            {
                if (state == Report.State.Other) continue;
                string plotName = MakeFeatureDataHistogram(ref control, state);
                if (plotName != string.Empty) skippedPlots.Add(plotName);
            }
            if (skippedPlots.Count > 0)
            {
                string message = "Plots not shown: ";
                foreach (string item in skippedPlots)
                    message += $"{item}, ";
                ScottPlot.Plottable.Annotation annotation =
                    control.Plot.AddAnnotation(message.Substring(0, message.Length - 2), -10, 10);
                annotation.BackgroundColor = Color.Transparent;
                annotation.BorderColor = Color.Transparent;
                annotation.Font.Color = Color.Black;
                annotation.Shadow = false;
            }
            control.Plot.Title(SelectedFeature.Name);
            control.Plot.XAxis.Label("Score");
            control.Plot.YAxis.Label("Count");
            control.Plot.Grid(false);
            control.Refresh();
            Form form = new Form()
            {
                Size = new Size(600, 400),
                FormBorderStyle = FormBorderStyle.SizableToolWindow
            };
            form.Controls.Add(control);
            form.Show();
        }

        #endregion
    }
}
