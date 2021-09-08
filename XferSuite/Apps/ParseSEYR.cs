using System.Windows.Forms;
using XferHelper;
using BrightIdeasSoftware;
using System;
using System.Linq;
using System.Collections.Generic;

namespace XferSuite
{
    public partial class ParseSEYR : Form
    {
        private string Path { get; set; }
        private Report.Entry[] Data { get; set; }
        private Report.Criteria[] Features { get; set; }
        private Report.Criteria SelectedFeature { get; set; }

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
            olvNeedOne.ModelCanDrop += (s, e) => { e.Effect = DragDropEffects.Copy; };
            olvNeedOne.ModelDropped += ModelDropped;

            Show();
        }

        private void btnOpenReport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Open a SEYR Report";
                openFileDialog.Filter = "txt file (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Path = openFileDialog.FileName;
                    OpenReport();
                }
            }
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

        private void btnParse_Click(object sender, EventArgs e)
        {
            rtb.Text = "THIS IS A DEMO\n";
            int fieldNum = 0;
            double passNum = 0;
            double failNum = 0;

            int num = Report.getNumImages(Data) + 1;
            int numX = Report.getNumX(Data);
            int numY = Report.getNumY(Data);
            for (int k = 0; k < num; k++)
            {
                var thisImg = Report.getImage(Data, k);

                for (int i = 0; i < numX; i++)
                {
                    for (int j = 0; j < numY; j++)
                    {
                        var thisCell = Report.getCell(thisImg, i, j);
                        if (thisCell.Length == 0) continue;
                        bool pass = true;
                        List<bool> needOneList = new List<bool>();

                        foreach (Report.Entry item in thisCell)
                        {
                            Report.Criteria criteria = Features.First(x => x.Name == item.Name);
                            switch (criteria.Bucket)
                            {
                                case Report.Bucket.Buffer:
                                    break;
                                case Report.Bucket.Required:
                                    if (!criteria.Requirements.Contains(item.State)) pass = false;
                                    break;
                                case Report.Bucket.NeedOne:
                                    needOneList.Add(criteria.Requirements.Contains(item.State));
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (needOneList.Count > 0 && !needOneList.Contains(true)) pass = false;

                        if (pass)
                            passNum++;
                        else
                            failNum++;
                    }
                }

                if (passNum + failNum == 1600)
                {
                    fieldNum++;
                    rtb.Text += string.Format("{0}\n", (passNum / (passNum + failNum)).ToString("P"));
                    passNum = 0;
                    failNum = 0;
                }
            }
            rtb.Text += string.Format("{0}\n", (passNum / (passNum + failNum)).ToString("P"));
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtb.Text);
        }
    }
}
