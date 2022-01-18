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

        public ParseSEYR(string path)
        {
            InitializeComponent();
            Path = new FileInfo(path);
            OpenReport();

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

        private void OpenReport()
        {
            Text = Path.Name;
            Data = Report.data(Path.FullName);
            Features = Report.getFeatures(Data);
            InitObjects();
        }

        private void InitObjects()
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

        private void ConfigurePlot()
        {
            PlotModel plotModel = new PlotModel();
            plotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                IsAxisVisible = false,
            });
            plotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                IsAxisVisible = false,
            });

            ScatterSeries passScatter = new ScatterSeries()
            {
                MarkerFill = OxyColors.LawnGreen,
                MarkerSize = _PointSize,
                TrackerFormatString = "{Tag}"
            };
            ScatterSeries failScatter = new ScatterSeries()
            {
                MarkerFill = OxyColors.Red,
                MarkerSize = _PointSize,
                TrackerFormatString = "{Tag}"
            };

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

            if (_PlotOrder)
            {
                plotModel.Series.Add(failScatter);
                plotModel.Series.Add(passScatter);
            }
            else
            {
                plotModel.Series.Add(passScatter);
                plotModel.Series.Add(failScatter);
            }

            plotView.Model = plotModel;
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
            }

            if (!Plottables.Where(p => p.Region == region).Any())
            {
                MessageBox.Show("Specified region not found");
                return;
            }

            Rectangle bounds = Screen.FromControl(this).Bounds;
            int size = (int)(Math.Min(bounds.Width, bounds.Height) * 0.95);
            Form form = new Form()
            {
                Width = size,
                Height = size,
                FormBorderStyle = FormBorderStyle.SizableToolWindow,
                StartPosition = FormStartPosition.CenterScreen,
                Text = region
            };

            PlotView plot = new PlotView() { Dock = DockStyle.Fill };
            PlotModel plotModel = new PlotModel();
            plotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                TickStyle = OxyPlot.Axes.TickStyle.None
            });
            plotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                TickStyle = OxyPlot.Axes.TickStyle.None
            });

            ScatterSeries passSeries = (ScatterSeries)plotView.Model.Series[_PlotOrder ? 1 : 0];

            ScatterSeries passScatter = new ScatterSeries()
            {
                MarkerFill = OxyColors.LawnGreen,
                MarkerSize = _PointSize,
                TrackerFormatString = "{Tag}"
            };
            passScatter.Points.AddRange(
                ((ScatterSeries)plotView.Model.Series[_PlotOrder ? 1 : 0]).Points.Where(
                    x => x.Tag.ToString().Contains(region)));
            ScatterSeries failScatter = new ScatterSeries()
            {
                MarkerFill = OxyColors.Red,
                MarkerSize = _PointSize,
                TrackerFormatString = "{Tag}"
            };
            failScatter.Points.AddRange(
                ((ScatterSeries)plotView.Model.Series[_PlotOrder ? 0 : 1]).Points.Where(
                    x => x.Tag.ToString().Contains(region)));

            if (_PlotOrder)
            {
                plotModel.Series.Add(failScatter);
                plotModel.Series.Add(passScatter);
            }
            else
            {
                plotModel.Series.Add(passScatter);
                plotModel.Series.Add(failScatter);
            }

            plot.Model = plotModel;
            form.Controls.Add(plot);
            form.Show();
        }

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

        private void toolStripButtonReset_Click(object sender, EventArgs e)
        {
            InitObjects();
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
            if (rtb.Text != "")
                Clipboard.SetText(rtb.Text);
            else
                Clipboard.Clear();
        }

        private void toolStripButtonSmartSort_Click(object sender, EventArgs e)
        {
            Report.Criteria[] originalFeatures = Features;
            Features = Report.getFeatures(Data);
            var sortList = Features.ToList();
            sortList.Sort();
            Features = sortList.ToArray();

            // Init
            SelectedFeature = null;
            lblSelectedFeature.Text = "N\\A";
            rtb.Text = "";
            flowLayoutPanelCriteria.Enabled = false;
            olvBuffer.Objects = null;
            olvRequire.Objects = null;
            olvNeedOne.Objects = null;
            ObjectHasBeenDropped = true;

            foreach (Report.Criteria feature in Features)
            {
                feature.Requirements = originalFeatures.First(x => x.Name == feature.Name).Requirements;
                FindHome(feature);
            }

            olvNeedOne.RebuildAll(true);
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

        private void btnViewData_Click(object sender, EventArgs e)
        {
            double[] data = Report.getData(Data, SelectedFeature.Name);
            if (data.Sum() == 0) return;
            ScottPlot.FormsPlot control = new ScottPlot.FormsPlot() { Dock = DockStyle.Fill };
            (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(
                data, min: data.Min(), max: data.Max(), binSize: 1);
            double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();
            ScottPlot.Plottable.BarPlot bar = control.Plot.AddBar(values: counts, positions: leftEdges);
            bar.BarWidth = 1;
            control.Plot.Title(SelectedFeature.Name);
            control.Plot.XAxis.Label("Score");
            control.Plot.YAxis.Label("Count");
            control.Refresh();
            Form form = new Form()
            {
                Size = new Size(600, 400),
                FormBorderStyle = FormBorderStyle.SizableToolWindow
            };
            form.Controls.Add(control);
            form.Show();
        }

        private void toolStripButtonCopyWindow_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            DrawToBitmap(bmp, new Rectangle(0, 0, Width, Height));
            Clipboard.SetImage(bmp);
        }

        private void btnAdjustData_Click(object sender, EventArgs e)
        {
            int min = int.MinValue;
            using (PromptForInput input = new PromptForInput(
                prompt: "Enter new lower bound for passing score", 
                textEntry: false,
                title: $"Adjust {SelectedFeature.Name}"))
            {
                var result = input.ShowDialog();
                if (result == DialogResult.OK)
                    min = (int)((NumericUpDown)input.Control).Value;
                else
                    return;
            }

            int max = int.MinValue;
            using (PromptForInput input = new PromptForInput(
                prompt: "Enter new upper bound for passing score",
                textEntry: false,
                max: (int)Report.getData(Data, SelectedFeature.Name).Max(),
                title: $"Adjust {SelectedFeature.Name}"))
            {
                var result = input.ShowDialog();
                if (result == DialogResult.OK)
                    max = (int)((NumericUpDown)input.Control).Value;
                else
                    return;
            }

            if (max > min)
                Report.rescoreFeature(Data, SelectedFeature.Name, min, max);
            else
                MessageBox.Show("Max must be greater than min.");
        }
    }
}
