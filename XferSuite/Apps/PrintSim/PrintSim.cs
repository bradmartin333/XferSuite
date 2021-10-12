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
using static XferSuite.TransferMap;

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

        public PrintSim(string path)
        {
            InitializeComponent();

            _Path = path;
            fileSystemWatcher.Path = Path.GetDirectoryName(path);
            fileSystemWatcher.Changed += UpdateFile;

            UpdateAll();
        }

        private string _Path;
        private string _MapPath;
        private int _PrintNum = 0;
        private bool _NullSourceRegion;
        private List<Sim.ID> _Devices = new List<Sim.ID>();
        private List<Sim.ID> _Sites = new List<Sim.ID>();
        private List<Sim.ID> _CleanLocations = new List<Sim.ID>();

        // ToDo - Load Printer Config
        private PointF XExtent = new PointF(0, 800);
        private PointF YExtent = new PointF(0, 600);

        private void UpdateAll()
        {
            timer.Start(); // Need a delay so fileSystemWatcher and XML reader don't overlap
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _Devices.Clear();
            _Sites.Clear();
            _CleanLocations.Clear();
            LoadRecipe(_Path);
            if (!(_MapPath == null))
            {
                LoadMap(_MapPath, numCTLength.Value, numCTWidth.Value);
            }
            _PrintNum = 0;
            UpdatePrintIdx();
            CreateSourceFeatures();
            CreateTargetFeatures();
            CreateCleanFeatures();
            MakePlot();
            timer.Stop();
        }

        private void btnOpenMap_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Open a Transfer Map";
                openFileDialog.Filter = "xmap file (*.xmap)|*.xmap";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _MapPath = openFileDialog.FileName;
                }
            }
            UpdateAll();
        }

        private void UpdatePrintIdx()
        {
            lblPrintIdx.Text = string.Format("{0}/{1} Prints", _PrintNum, _NumPrints);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_PrintNum == _NumPrints)
            {
                return;
            }
            Sim.SelectDevice(_Picks[_PrintNum], _Devices.ToArray(), true, _NullSourceRegion, (int)StampPosts.X, (int)StampPosts.Y);
            Sim.SelectSite(_Prints[_PrintNum], _Sites.ToArray(), true);
            Sim.SelectClean(_Cleans[_PrintNum], _CleanLocations.ToArray(), true);
            MakePlot();
            _PrintNum++;
            UpdatePrintIdx();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            while (_PrintNum != _NumPrints)
            {
                btnNext_Click(sender, e);
            }
        }

        private void SavePlot()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Export Print Sim Map";
                saveFileDialog.DefaultExt = ".png";
                saveFileDialog.Filter = "png file (*.png)|*.png";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var pngExporter = new PngExporter { Width = plot.Width, Height = plot.Width, Background = OxyColors.White };
                    pngExporter.ExportToFile(plot.Model, saveFileDialog.FileName);
                }
            }
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
            map.MouseDown += (s, e) =>
            {
                if (e.IsShiftDown)
                {
                    SavePlot();
                }
            };

            ScatterSeries availableDevices = new ScatterSeries() { MarkerFill = OxyColors.DarkSeaGreen };
            ScatterSeries pickedDevices = new ScatterSeries() { MarkerFill = OxyColors.Transparent, MarkerStroke = OxyColors.LightSeaGreen, MarkerStrokeThickness = 1 };
            ScatterSeries availableSites = new ScatterSeries() { MarkerFill = OxyColors.Transparent, MarkerStroke = OxyColors.DarkBlue, MarkerStrokeThickness = 1 };
            ScatterSeries printedSites = new ScatterSeries() { MarkerFill = OxyColors.BlueViolet };
            ScatterSeries availableCleans = new ScatterSeries() { MarkerFill = OxyColors.Transparent, MarkerStroke = OxyColors.OrangeRed, MarkerStrokeThickness = 1 };
            ScatterSeries cleanedSites = new ScatterSeries() { MarkerFill = OxyColors.Orange };

            foreach (Sim.ID device in _Devices)
            {
                ScatterPoint thisDevice = new ScatterPoint(device.X, device.Y) { Tag = device.ToString() };
                if (device.Selected)
                {
                    pickedDevices.Points.Add(thisDevice);
                }
                else
                {
                    availableDevices.Points.Add(thisDevice);
                }
            }
            foreach (Sim.ID site in _Sites)
            {
                ScatterPoint thisSite = new ScatterPoint(site.X, site.Y) { Tag = site.ToString() };
                if (site.Selected)
                {
                    printedSites.Points.Add(thisSite);
                }
                else
                {
                    availableSites.Points.Add(thisSite);
                }
            }
            foreach (Sim.ID clean in _CleanLocations)
            {
                ScatterPoint thisSite = new ScatterPoint(clean.X, clean.Y) { Tag = clean.ToString() };
                if (clean.Selected)
                {
                    cleanedSites.Points.Add(thisSite);
                }
                else
                {
                    availableCleans.Points.Add(thisSite);
                }
            }

            map.Series.Add(availableDevices);
            map.Series.Add(pickedDevices);
            map.Series.Add(availableSites);
            map.Series.Add(printedSites);
            map.Series.Add(availableCleans);
            map.Series.Add(cleanedSites);

            availableDevices.TrackerFormatString = availableDevices.TrackerFormatString + Environment.NewLine + "{Tag}";
            pickedDevices.TrackerFormatString = pickedDevices.TrackerFormatString + Environment.NewLine + "{Tag}";
            availableSites.TrackerFormatString = availableSites.TrackerFormatString + Environment.NewLine + "{Tag}";
            printedSites.TrackerFormatString = printedSites.TrackerFormatString + Environment.NewLine + "{Tag}";
            availableCleans.TrackerFormatString = availableCleans.TrackerFormatString + Environment.NewLine + "{Tag}";
            cleanedSites.TrackerFormatString = cleanedSites.TrackerFormatString + Environment.NewLine + "{Tag}";

            LinearAxis myXaxis = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                IsAxisVisible = true,
                StartPosition = 1,
                EndPosition = 0,
                IsZoomEnabled = true,
                IsPanEnabled = true,
                Title = "X Position (mm)",
                Minimum = XExtent.X,
                Maximum = XExtent.Y
            };

            LinearAxis myYaxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                IsAxisVisible = true,
                StartPosition = 1,
                EndPosition = 0,
                IsZoomEnabled = true,
                IsPanEnabled = true,
                Title = "Y Position (mm)",
                Minimum = YExtent.X,
                Maximum = YExtent.Y
            };

            myXaxis.TransformChanged += MyXaxis_TransformChanged;
            myYaxis.TransformChanged += MyYaxis_TransformChanged;

            map.Axes.Add(myXaxis);
            map.Axes.Add(myYaxis);
            plot.Model = map;
            Refresh();
        }

        private void MyXaxis_TransformChanged(object sender, EventArgs e)
        {
            LinearAxis axis = (LinearAxis)sender;
            XExtent = new PointF((float)axis.ActualMinimum, (float)axis.ActualMaximum);
        }

        private void MyYaxis_TransformChanged(object sender, EventArgs e)
        {
            LinearAxis axis = (LinearAxis)sender;
            YExtent = new PointF((float)axis.ActualMinimum, (float)axis.ActualMaximum);
        }

        private void CreateSourceFeatures()
        {
            if (SourceRegions.X == 1 && SourceRegions.Y == 1)
            {
                _NullSourceRegion = true;
                _Devices.AddRange(Sim.MakeIDs(1 + (StampPostPitch.X / SourceChipletPitch.X), 1 + (StampPostPitch.Y / SourceChipletPitch.Y),
                                          StampPosts.X, StampPosts.Y,
                                          SourceClusters.X, SourceClusters.Y,
                                          SourceChipletPitch.X, SourceChipletPitch.Y,
                                          StampPostPitch.X, StampPostPitch.Y,
                                          SourceClusterPitch.X, SourceClusterPitch.Y,
                                          SourceOrigin.X, SourceOrigin.Y,
                                          true, _NullSourceRegion));
            }
            else
            {
                _NullSourceRegion = false;
                _Devices.AddRange(Sim.MakeIDs(1 + (StampPostPitch.X / SourceChipletPitch.X), 1 + (StampPostPitch.Y / SourceChipletPitch.Y),
                                          SourceClusters.X, SourceClusters.Y,
                                          SourceRegions.X, SourceRegions.Y,
                                          SourceChipletPitch.X, SourceChipletPitch.Y,
                                          SourceClusterPitch.X, SourceClusterPitch.Y,
                                          SourceRegionPitch.X, SourceRegionPitch.Y,
                                          SourceOrigin.X, SourceOrigin.Y,
                                          true, _NullSourceRegion));
            } 
        }

        private void CreateTargetFeatures()
        {
            _Sites.AddRange(Sim.MakeIDs(StampPosts.X, StampPosts.Y,
                                        TargetPrints.X, TargetPrints.Y,
                                        TargetClusters.X, TargetClusters.Y,
                                        StampPostPitch.X, StampPostPitch.Y,
                                        TargetPrintPitch.X, TargetPrintPitch.Y,
                                        TargetClusterPitch.X, TargetClusterPitch.Y,
                                        TargetOrigin.X, TargetOrigin.Y,
                                        false, false));
        }

        private void CreateCleanFeatures()
        {
            _CleanLocations.AddRange(Sim.MakeIDs(1 + (StampPostPitch.X / SourceChipletPitch.X), 1 + (StampPostPitch.Y / SourceChipletPitch.Y),
                                          SourceClusters.X, SourceClusters.Y,
                                          SourceRegions.X, SourceRegions.Y,
                                          SourceChipletPitch.X, SourceChipletPitch.Y,
                                          SourceClusterPitch.X, SourceClusterPitch.Y,
                                          SourceRegionPitch.X, SourceRegionPitch.Y,
                                          CleaningTapeOrigin.X, CleaningTapeOrigin.Y,
                                          false, false));
        }
    }
}
