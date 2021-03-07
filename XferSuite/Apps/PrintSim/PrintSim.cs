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

            map.Series.Add(availableDevices);
            map.Series.Add(pickedDevices);
            map.Series.Add(availableSites);
            map.Series.Add(printedSites);

            availableDevices.TrackerFormatString = availableDevices.TrackerFormatString + Environment.NewLine + "{Tag}";
            pickedDevices.TrackerFormatString = pickedDevices.TrackerFormatString + Environment.NewLine + "{Tag}";
            availableSites.TrackerFormatString = availableSites.TrackerFormatString + Environment.NewLine + "{Tag}";
            printedSites.TrackerFormatString = printedSites.TrackerFormatString + Environment.NewLine + "{Tag}";

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

            map.Axes.Add(myXaxis);
            map.Axes.Add(myYaxis);
            plot.Model = map;
            Refresh();
        }

        private void CreateSourceFeatures()
        {
            _Devices.AddRange(Sim.MakeIDs(SourceChiplets.X, SourceChiplets.Y,
                                          SourceClusters.X, SourceClusters.Y,
                                          SourceRegions.X, SourceRegions.Y,
                                          SourceChipletPitch.X, SourceChipletPitch.Y,
                                          SourceClusterPitch.X, SourceClusterPitch.Y,
                                          SourceRegionPitch.X, SourceRegionPitch.Y,
                                          SourceOrigin.X, SourceOrigin.Y,
                                          true));
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
                                        false));
        }
    }
}
