using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static XferSuite.Parameters;

namespace XferSuite
{
    public partial class PrintSim : Form
    {
        private bool _WatchFile = true;
        [
            Category("User Parameters"),
            Description("Monitor loaded .xrec for file changes")
        ]
        public bool WatchFile
        {
            get => _WatchFile;
            set
            {
                _WatchFile = value;
            }
        }

        public PrintSim(string path)
        {
            InitializeComponent();
            LoadRecipe(path);
            MakePlot();
        }

        //private List<RenderObject> _StampPosts = new List<RenderObject>();
        //private List<RenderObject> _Wafers = new List<RenderObject>();
        //private List<RenderObject> _Devices = new List<RenderObject>();
        //private List<RenderObject> _Sites = new List<RenderObject>();
        //private List<Vector2> _SourceBuilder = new List<Vector2>();
        //private List<Vector2> _TargetBuilder = new List<Vector2>();

        private void btnOpenMap_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

        }

        private void plot_DoubleClick(object sender, EventArgs e)
        {

        }

        private void MakePlot()
        {

        }

        private void CreateSourceFeatures()
        {
            //for (int j = 0; j < SourceChiplets.Y; j++)
            //{
            //    for (int i = (int)SourceChiplets.X - 1; i >= 0; i--)
            //    {
            //        _SourceBuilder.Add(new Vector2(SourceOrigin.X + i * SourceChipletPitch.X, SourceOrigin.Y + j * SourceChipletPitch.Y));
            //    }
            //}

            //int rr = 0;
            //for (int n = 0; n < SourceRegions.Y; n++)
            //{
            //    int rc = 0;
            //    for (int m = (int)SourceRegions.X - 1; m >= 0; m--)
            //    {
            //        int r = 0;
            //        for (int l = 0; l < SourceClusters.Y; l++)
            //        {
            //            int c = 0;
            //            for (int k = (int)SourceClusters.X - 1; k >= 0; k--)
            //            {
            //                int idx = 0;
            //                foreach (Vector2 pos in _SourceBuilder)
            //                {
            //                    RenderObject renderObject = new RenderObject(ObjectFactory.CreateRect(pos.X + k * SourceClusterPitch.X + m * SourceRegionPitch.X, pos.Y + l * SourceClusterPitch.Y + n * SourceRegionPitch.Y, DeviceSize.X, DeviceSize.Y, Color4.DarkBlue));
            //                    renderObject.RR = rr + 1;
            //                    renderObject.RC = rc + 1;
            //                    renderObject.R = r + 1;
            //                    renderObject.C = c + 1;
            //                    renderObject.IDX = idx + 1;
            //                    _Devices.Add(renderObject);
            //                    idx++;
            //                }
            //                c++;
            //            }
            //            r++;
            //        }
            //        rc++;
            //    }
            //    rr++;
            //}
        }

        private void CreateTargetFeatures()
        {
            //for (int j = 0; j < StampPosts.Y; j++)
            //{
            //    for (int i = (int)StampPosts.X - 1; i >= 0; i--)
            //    {
            //        _TargetBuilder.Add(new Vector2(TargetOrigin.X + i * StampPostPitch.X, TargetOrigin.Y + j * StampPostPitch.Y));
            //    }
            //}

            //int rr = 0;
            //for (int n = 0; n < TargetClusters.Y; n++)
            //{
            //    int rc = 0;
            //    for (int m = (int)TargetClusters.X - 1; m >= 0; m--)
            //    {
            //        int r = 0;
            //        for (int l = 0; l < TargetPrints.Y; l++)
            //        {
            //            int c = 0;
            //            for (int k = (int)TargetPrints.X - 1; k >= 0; k--)
            //            {
            //                foreach (Vector2 pos in _TargetBuilder)
            //                {
            //                    RenderObject renderObject = new RenderObject(ObjectFactory.CreateRect(pos.X + k * TargetPrintPitch.X + m * TargetClusterPitch.X, pos.Y + l * TargetPrintPitch.Y + n * TargetClusterPitch.Y, DeviceSize.X, DeviceSize.Y, Color4.DarkGreen));
            //                    renderObject.RR = rr + 1;
            //                    renderObject.RC = rc + 1;
            //                    renderObject.R = r + 1;
            //                    renderObject.C = c + 1;
            //                    _Sites.Add(renderObject);
            //                }
            //                c++;
            //            }
            //            r++;
            //        }
            //        rc++;
            //    }
            //    rr++;
            //}
        }
    }
}
