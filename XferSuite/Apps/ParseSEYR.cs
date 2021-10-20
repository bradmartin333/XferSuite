using System.Windows.Forms;
using XferHelper;
using BrightIdeasSoftware;
using System;
using System.Linq;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;
using System.Drawing;
using System.ComponentModel;

namespace XferSuite
{
    public partial class ParseSEYR : Form
    {
        private bool _FlipRC = false;
        [Category("User Parameters")]
        public bool FlipRC
        {
            get => _FlipRC;
            set
            {
                _FlipRC = value;
            }
        }

        private bool _ShowPlotAxes = false;
        [Category("User Parameters")]
        public bool ShowPlotAxes
        {
            get => _ShowPlotAxes;
            set
            {
                _ShowPlotAxes = value;
            }
        }

        private string Path { get; set; }
        private Report.Entry[] Data { get; set; }
        private Report.Criteria[] Features { get; set; }
        private Report.Criteria SelectedFeature { get; set; }

        private PointF Pitch = PointF.Empty;

        public ParseSEYR(string path)
        {
            InitializeComponent();
            Path = path;
            string[] splitPath = path.Split('_');
            try
            {
                Pitch = new PointF(float.Parse(splitPath[splitPath.Length - 2]), float.Parse(splitPath.Last().Replace(".txt", "")));
            }
            catch (Exception) { }
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
            olvNeedOne.ModelCanDrop += (s, e) => { e.Effect = DragDropEffects.Copy; };
            olvNeedOne.ModelDropped += ModelDropped;

            Show();
        }

        private void btnShowScatterplot_Click(object sender, EventArgs e)
        {
            Form form = new Form()
            {
                FormBorderStyle = FormBorderStyle.None,
                Text = "SEYR Report Scatter"
            };
            PlotView plotView = new PlotView()
            {
                Dock = DockStyle.Fill
            };
            PlotModel plotModel = new PlotModel();
            ScatterSeries[] scatters = Parse();
            foreach (ScatterSeries series in scatters)
            {
                plotModel.Series.Add(series);
            }
            LinearAxis Xaxis = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "X Position",
                IsAxisVisible = ShowPlotAxes
            };
            LinearAxis Yaxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "Y Position",
                IsAxisVisible = ShowPlotAxes
            };
            plotModel.Axes.Add(Xaxis);
            plotModel.Axes.Add(Yaxis);
            plotView.Model = plotModel;
            form.Controls.Add(plotView);
            form.Show();

            Bitmap bitmap = new Bitmap(form.Width, form.Height);
            form.DrawToBitmap(bitmap, new Rectangle(0, 0, form.Width, form.Height));
            Clipboard.SetImage(bitmap);

            form.FormBorderStyle = FormBorderStyle.SizableToolWindow;
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
        }

        private void btnResetColumns_Click(object sender, EventArgs e)
        {
            InitObjects();
        }

        private void ModelDropped(object sender, ModelDropEventArgs e)
        {
            foreach (Report.Criteria m in e.SourceModels)
            {
                m.Bucket = Report.toBucket(int.Parse(e.ListView.Tag.ToString()));
                ((ObjectListView)sender).AddObject(m);
                olvBuffer.RemoveObject(m);
            }
        }

        private void ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            flowLayoutPanelCriteria.Enabled = true;
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

        private ScatterSeries[] Parse()
        {
            using (new HourGlass())
            {
                rtb.Text = "RR\tRC\tYield\n";

                ScatterSeries passScatter = new ScatterSeries() { MarkerFill = OxyColors.LawnGreen, MarkerSize = 1, TrackerFormatString = "{Tag}" };
                ScatterSeries failScatter = new ScatterSeries() { MarkerFill = OxyColors.Red, MarkerSize = 1, TrackerFormatString = "{Tag}" };

                int fieldNum = 0;
                double passNum = 0;
                double failNum = 0;

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
                            bool pass = CheckCriteria(thisCell);

                            double thisX = thisCell[0].X;
                            double thisY = thisCell[0].Y;
                            AdjustPlotPosition(ref thisX, ref thisY, i, j, k, num, numX, numY);

                            string thisTag = string.Format("X: {0}\nY: {1}\nRR: {2}\nRC: {3}\nR: {4}\nC: {5}",
                                thisX, thisY, thisCell[0].RR, thisCell[0].RC, thisCell[0].R, thisCell[0].C);

                            if (pass)
                            {
                                passNum++;
                                passScatter.Points.Add(new ScatterPoint(thisX, thisY, tag: thisTag));
                            }
                            else
                            {
                                failNum++;
                                failScatter.Points.Add(new ScatterPoint(thisX, thisY, tag: thisTag));
                            }
                        }
                    }

                    int[] thisRegion = Report.getRegion(thisImg);
                    if (thisRegion[0] != lastRegion[0] || thisRegion[1] != lastRegion[1])
                    {
                        lastRegion = thisRegion;
                        fieldNum++;
                        rtb.Text += string.Format("{0}\t{1}\t{2}\n", thisRegion[0], thisRegion[1], (passNum / (passNum + failNum)).ToString("P"));
                        passNum = 0;
                        failNum = 0;
                    }
                }
                rtb.Text += string.Format("{0}\t{1}\t{2}\n", lastRegion[0], lastRegion[1], (passNum / (passNum + failNum)).ToString("P"));

                return new ScatterSeries[] { passScatter, failScatter };
            }
        }

        private bool CheckCriteria(Report.Entry[] thisCell)
        {
            List<bool> needOneList = new List<bool>();

            foreach (Report.Entry item in thisCell)
            {
                Report.Criteria criteria = Features.First(x => x.Name == item.Name);
                switch (criteria.Bucket)
                {
                    case Report.Bucket.Buffer:
                        break;
                    case Report.Bucket.Required:
                        if (!criteria.Requirements.Contains(item.State)) return false;
                        break;
                    case Report.Bucket.NeedOne:
                        needOneList.Add(criteria.Requirements.Contains(item.State));
                        break;
                    default:
                        break;
                }
            }

            if (needOneList.Count > 0 && !needOneList.Contains(true)) return false;
            return true;
        }

        private void AdjustPlotPosition(ref double thisX, ref double thisY, int i, int j, int k, int num, int numX, int numY)
        {
            if (_FlipRC)
            {
                if (thisX == -1 || thisY == -1)
                {
                    thisY = (k - 1) % Math.Sqrt(num - 1);
                    thisX = double.Parse(((k - 1) / Math.Sqrt(num - 1)).ToString().Split('.').First());
                }
                thisX += (i - ((double)numX / 2)) * Pitch.X;
                thisY -= (j - ((double)numY / 2)) * Pitch.Y;
            }
            else
            {
                if (thisX == -1 || thisY == -1)
                {
                    thisX = (k - 1) % Math.Sqrt(num - 1);
                    thisY = double.Parse(((k - 1) / Math.Sqrt(num - 1)).ToString().Split('.').First());
                }
                thisX += (i - ((double)numX / 2)) * Pitch.X;
                thisY -= (j - ((double)numY / 2)) * Pitch.Y;
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            Parse();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtb.Text);
        }
    }
}
