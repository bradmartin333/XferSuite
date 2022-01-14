using System.Windows.Forms;
using XferHelper;
using BrightIdeasSoftware;
using System;
using System.Linq;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using System.Drawing;
using System.ComponentModel;
using Microsoft.FSharp.Collections;
using System.Text;

namespace XferSuite
{
    public partial class ParseSEYR : Form
    {
        private bool _ShowPlotAxes = true;
        [Category("User Parameters")]
        public bool ShowPlotAxes
        {
            get => _ShowPlotAxes;
            set
            {
                _ShowPlotAxes = value;
                ConfigurePlot();
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

        private int _PointSize = 2;
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

        private string Path { get; set; }
        private Report.Entry[] Data { get; set; }
        private Report.Criteria[] Features { get; set; }
        private Report.Criteria SelectedFeature { get; set; }
        private bool ObjectHasBeenDropped { get; set; }

        private List<ScatterPoint>[] ScatterPoints = new List<ScatterPoint>[2]; // Pass, Fail

        public ParseSEYR(string path)
        {
            InitializeComponent();
            Path = path;
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
            Text = Path.Split('\\').Last().Replace(".txt", "");
            Data = Report.data(Path);
            Features = Report.getFeatures(Data);
            InitObjects();
        }

        private void InitObjects()
        {
            Features = Report.getFeatures(Data);
            SelectedFeature = null;
            lblSelectedFeature.Text = "N\\A";
            rtb.Text = "";
            flowLayoutPanelCriteria.Enabled = false;
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

        private void Parse()
        {
            using (new HourGlass(UsePlexiglass: false))
            {
                List<string> needOneParents = Features.Where(x => x.IsParent).Select(x => x.Name).ToList();

                // Reset
                rtb.Text = "RR\tRC\tR\tC\tYield\n";
                ScatterPoints[0] = new List<ScatterPoint>();
                ScatterPoints[1] = new List<ScatterPoint>();
                int fieldNum = 0;
                double passNum = 0;
                double failNum = 0;

                // Parse
                int num = Report.getNumImages(Data) + 1;
                int numX = Report.getNumX(Data);
                int numY = Report.getNumY(Data);
                int[] lastRegion = Report.getRegion(Report.getImage(Data, 1));
                for (int k = 1; k < num; k++)
                {
                    var thisImg = Report.getImage(Data, k);

                    for (int i = 0; i < numX; i++)
                    {
                        for (int j = 0; j < numY; j++)
                        {
                            var thisCell = Report.getCell(thisImg, i, j);
                            if (thisCell.Length == 0) continue;
                            bool pass = CheckCriteria(thisCell, needOneParents);

                            double thisX = thisCell[0].X;
                            double thisY = thisCell[0].Y;

                            string thisTag =
                                $"X: {thisX}\n" +
                                $"Y: {thisY}\n" +
                                $"RR: {thisCell[0].RR}\n" +
                                $"RC: {thisCell[0].RC}\n" +
                                $"R: {thisCell[0].R}\n" +
                                $"C: {thisCell[0].C}";

                            if (pass)
                            {
                                passNum++;
                                ScatterPoints[0].Add(new ScatterPoint(thisX, thisY, tag: thisTag));
                            }
                            else
                            {
                                failNum++;
                                ScatterPoints[1].Add(new ScatterPoint(thisX, thisY, tag: thisTag));
                            }
                        }
                    }

                    int[] thisRegion = Report.getRegion(thisImg);
                    if (!Enumerable.SequenceEqual(thisRegion, lastRegion))
                    {
                        lastRegion = thisRegion;
                        fieldNum++;
                        rtb.Text +=
                            $"{thisRegion[0]}\t" +
                            $"{thisRegion[1]}\t" +
                            $"{thisRegion[2]}\t" +
                            $"{thisRegion[3]}\t" +
                            $"{passNum / (passNum + failNum):P}\n";
                        passNum = 0;
                        failNum = 0;
                    }
                }

                rtb.Text +=
                    $"{lastRegion[0]}\t" +
                    $"{lastRegion[1]}\t" +
                    $"{lastRegion[2]}\t" +
                    $"{lastRegion[3]}\t" +
                    $"{passNum / (passNum + failNum):P}";

                ConfigurePlot();
            }
        }

        private void ConfigurePlot()
        {
            PlotModel plotModel = new PlotModel()
            {
                Title = $"Total Yield   {ScatterPoints[0].Count() / (double)(ScatterPoints[0].Count() + ScatterPoints[1].Count()):P}",
                TitleFontSize = 12
            };

            LinearAxis Xaxis = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "X Position",
                IsAxisVisible = ShowPlotAxes,
                StartPosition = _FlipXAxis ? 1 : 0,
                EndPosition = _FlipXAxis ? 0 : 1
            };
            LinearAxis Yaxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "Y Position",
                IsAxisVisible = ShowPlotAxes,
                StartPosition = _FlipYAxis ? 1 : 0,
                EndPosition = _FlipYAxis ? 0 : 1
            };

            ScatterSeries passScatter = new ScatterSeries()
            {
                MarkerFill = OxyColors.LawnGreen,
                MarkerSize = _PointSize,
                TrackerFormatString = "{Tag}"
            };
            passScatter.Points.AddRange(ScatterPoints[0]);
            ScatterSeries failScatter = new ScatterSeries()
            {
                MarkerFill = OxyColors.Red,
                MarkerSize = _PointSize,
                TrackerFormatString = "{Tag}"
            };
            failScatter.Points.AddRange(ScatterPoints[1]);

            plotModel.Axes.Add(Xaxis);
            plotModel.Axes.Add(Yaxis);
            plotModel.Series.Add(failScatter);
            plotModel.Series.Add(passScatter);
            plotView.Model = plotModel;
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

            toolStripButtonCopyText.Enabled = true;
            toolStripButtonCopyPlot.Enabled = true;
            toolStripButtonCopyForExcel.Enabled = true;
        }

        private void toolStripButtonCopyText_Click(object sender, EventArgs e)
        {
            if (rtb.Text != "")
                Clipboard.SetText(rtb.Text);
            else
                Clipboard.Clear();
        }

        private void toolStripButtonCopyPlot_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(plotView.Width, plotView.Height);
            plotView.DrawToBitmap(bitmap, new Rectangle(0, 0, plotView.Width, plotView.Height));
            Clipboard.SetImage(bitmap);
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

        private void toolStripButtonCopyForExcel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                    "This feature is currently only supported for SEYRDesktop generated data. Continue?",
                    "Copy SEYR Plot for Excel", MessageBoxButtons.YesNoCancel);
            if (dialogResult != DialogResult.Yes) return;

            double xMin = Math.Floor(plotView.Model.Axes[0].DataMinimum);
            double yMin = Math.Floor(plotView.Model.Axes[1].DataMinimum);
            int xRange = (int)Math.Ceiling(plotView.Model.Axes[0].DataMaximum - xMin);
            int yRange = (int)Math.Ceiling(plotView.Model.Axes[1].DataMaximum - yMin);

            int[,] output = new int[xRange, yRange];
            foreach (ScatterPoint pt in ScatterPoints[0])
            {
                int thisX = (int)Math.Floor(pt.X - xMin);
                int thisY = (int)Math.Floor(pt.Y - yMin);
                output[thisX, thisY] = 1;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < xRange; i++)
            {
                for (int j = 0; j < yRange; j++)
                {
                    sb.Append($"{output[i, j]}\t");
                }
                sb.Append('\n');
            }
            Clipboard.SetText(sb.ToString());
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            double[] data = Report.getData(Data, SelectedFeature.Name);

            ScottPlot.FormsPlot control = new ScottPlot.FormsPlot()
            {
                Dock = DockStyle.Fill
            };

            (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(data, data.Min(), data.Max(), 1);
            double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();

            // Display the histogram counts as a bar plot
            ScottPlot.Plottable.BarPlot bar = control.Plot.AddBar(counts, leftEdges);
            bar.BarWidth = 1;
            control.Plot.Title(SelectedFeature.Name);
            control.Plot.YAxis.Label("Count (#)");
            control.Plot.XAxis.Label("Score");
            control.Plot.SetAxisLimits(yMin: 0);
            control.Refresh();

            Form form = new Form()
            {
                Size = new Size(650, 450),
                FormBorderStyle = FormBorderStyle.FixedToolWindow
            };
            form.Controls.Add(control);
            form.Show();
        }
    }
}
