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
using static XferSuite.RenderObject;

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

        private float _DeviceSizeX = 40F;
        [
            Category("User Parameters"),
            Description("Width of device in microns")
        ]
        public float DeviceSizeX
        {
            get => _DeviceSizeX;
            set
            {
                _DeviceSizeX = value;
            }
        }

        private float _DeviceSizeY = 40F;
        [
            Category("User Parameters"),
            Description("Height of device in microns")
        ]
        public float DeviceSizeY
        {
            get => _DeviceSizeY;
            set
            {
                _DeviceSizeY = value;
            }
        }

        public PrintSim(string path)
        {
            InitializeComponent();
            LoadRecipe(path);
            CreateSourceFeatures();
            CreateTargetFeatures();
            MakePlot();
        }

        private List<RenderObject> _Devices = new List<RenderObject>();
        private List<RenderObject> _Sites = new List<RenderObject>();
        private List<PointF> _SourceBuilder = new List<PointF>();
        private List<PointF> _TargetBuilder = new List<PointF>();

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
            for (int j = 0; j < SourceChiplets.Y; j++)
            {
                for (int i = (int)SourceChiplets.X - 1; i >= 0; i--)
                {
                    _SourceBuilder.Add(new PointF(SourceOrigin.X + i * SourceChipletPitch.X, SourceOrigin.Y + j * SourceChipletPitch.Y));
                }
            }

            int rr = 0;
            for (int n = 0; n < SourceRegions.Y; n++)
            {
                int rc = 0;
                for (int m = (int)SourceRegions.X - 1; m >= 0; m--)
                {
                    int r = 0;
                    for (int l = 0; l < SourceClusters.Y; l++)
                    {
                        int c = 0;
                        for (int k = (int)SourceClusters.X - 1; k >= 0; k--)
                        {
                            int idx = 0;
                            foreach (PointF pos in _SourceBuilder)
                            {
                                RenderObject renderObject = new RenderObject(pos.X + k * SourceClusterPitch.X + m * SourceRegionPitch.X, pos.Y + l * SourceClusterPitch.Y + n * SourceRegionPitch.Y, _DeviceSizeX, _DeviceSizeY, Color.DarkBlue);
                                renderObject.RR = rr + 1;
                                renderObject.RC = rc + 1;
                                renderObject.R = r + 1;
                                renderObject.C = c + 1;
                                renderObject.IDX = idx + 1;
                                _Devices.Add(renderObject);
                                idx++;
                            }
                            c++;
                        }
                        r++;
                    }
                    rc++;
                }
                rr++;
            }
        }

        private void CreateTargetFeatures()
        {
            for (int j = 0; j < StampPosts.Y; j++)
            {
                for (int i = (int)StampPosts.X - 1; i >= 0; i--)
                {
                    _TargetBuilder.Add(new PointF(TargetOrigin.X + i * StampPostPitch.X, TargetOrigin.Y + j * StampPostPitch.Y));
                }
            }

            int rr = 0;
            for (int n = 0; n < TargetClusters.Y; n++)
            {
                int rc = 0;
                for (int m = (int)TargetClusters.X - 1; m >= 0; m--)
                {
                    int r = 0;
                    for (int l = 0; l < TargetPrints.Y; l++)
                    {
                        int c = 0;
                        for (int k = (int)TargetPrints.X - 1; k >= 0; k--)
                        {
                            foreach (PointF pos in _TargetBuilder)
                            {
                                RenderObject renderObject = new RenderObject(pos.X + k * TargetPrintPitch.X + m * TargetClusterPitch.X, pos.Y + l * TargetPrintPitch.Y + n * TargetClusterPitch.Y, _DeviceSizeX, _DeviceSizeY, Color.DarkGreen);
                                renderObject.RR = rr + 1;
                                renderObject.RC = rc + 1;
                                renderObject.R = r + 1;
                                renderObject.C = c + 1;
                                _Sites.Add(renderObject);
                            }
                            c++;
                        }
                        r++;
                    }
                    rc++;
                }
                rr++;
            }
        }
    }
}
