using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XferHelper;
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
                UpdateAll();
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

            _Path = path;
            fileSystemWatcher.Path = Path.GetDirectoryName(path);
            fileSystemWatcher.Changed += UpdateFile;

            UpdateAll();
        }

        private string _Path;
        private List<Sim.ID> _Devices = new List<Sim.ID>();
        private List<Sim.ID> _Sites = new List<Sim.ID>();

        private void UpdateAll()
        {
            timer.Start(); // Need a delay so fileSystemWatcher and XML reader don't overlap
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _Devices.Clear();
            _Sites.Clear();
            LoadRecipe(_Path);
            CreateSourceFeatures();
            CreateTargetFeatures();
            MakePlot();
            timer.Stop();
        }

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

        private void UpdateFile(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed && _WatchFile)
            {
                UpdateAll();
            }
        }

        private void MakePlot()
        {
            PlotModel map = new PlotModel();
            ScatterSeries scatter = new ScatterSeries();
            foreach (Sim.ID device in _Devices)
            {
                scatter.Points.Add(new ScatterPoint(device.X, device.Y, (device.Width * device.Height) / 1e3) { Tag = device.ToString() });
            }
            foreach (Sim.ID site in _Sites)
            {
                scatter.Points.Add(new ScatterPoint(site.X, site.Y, (site.Width * site.Height) / 1e3) { Tag = site.ToString() });

            }
            map.Series.Add(scatter);

            LinearAxis myXaxis = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                IsAxisVisible = true,
                StartPosition = 1,
                EndPosition = 0,
                IsZoomEnabled = true,
                IsPanEnabled = true,
                Title = "X Position (mm)"
            };

            LinearAxis myYaxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                IsAxisVisible = true,
                StartPosition = 1,
                EndPosition = 0,
                IsZoomEnabled = true,
                IsPanEnabled = true,
                Title = "Y Position (mm)"
            };

            scatter.TrackerFormatString = scatter.TrackerFormatString + Environment.NewLine + "{Tag}";
            map.Axes.Add(myXaxis);
            map.Axes.Add(myYaxis);
            plot.Model = map;
            Refresh();
        }

        private void CreateSourceFeatures()
        {
            List<PointF> _SourceBuilder = new List<PointF>();
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
                                _Devices.Add(new Sim.ID(pos.X + k * SourceClusterPitch.X + m * SourceRegionPitch.X, 
                                                        pos.Y + l * SourceClusterPitch.Y + n * SourceRegionPitch.Y, 
                                                        _DeviceSizeX, _DeviceSizeY, rr, rc, r, c, 0));
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
            List<PointF> _TargetBuilder = new List<PointF>();
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
                                _Sites.Add(new Sim.ID(pos.X + k * TargetPrintPitch.X + m * TargetClusterPitch.X, 
                                                      pos.Y + l * TargetPrintPitch.Y + n * TargetClusterPitch.Y, 
                                                      _DeviceSizeX, _DeviceSizeY, rr, rc, r, c, 0));
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
