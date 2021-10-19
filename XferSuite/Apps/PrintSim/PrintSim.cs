using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XferHelper;
using static XferSuite.Parameters;
using static XferSuite.TransferMap;

namespace XferSuite
{
    public partial class PrintSim : Form
    {
        private double _FinishXMapDelay = 0;
        [
            Category("User Parameters"),
            Description("Delay in ms between prints when finishing .xmap")
        ]
        public double FinishXMapDelay
        {
            get => _FinishXMapDelay;
            set
            {
                _FinishXMapDelay = value;
                UpdateAll();
            }
        }

        public PrintSim(string path)
        {
            if (!LoadConfig()) return;

            InitializeComponent();
            pb.BackgroundImage = new Bitmap((int)StageRange.X, (int)StageRange.Y);
            pb.Image = new Bitmap((int)StageRange.X, (int)StageRange.Y);

            _Path = path;

            UpdateAll();
        }

        private string _Path;
        private string _MapPath;
        private int _PrintNum = 0;
        private List<Sim.ID> _Devices = new List<Sim.ID>();
        private List<Sim.ID> _Sites = new List<Sim.ID>();
        private List<Sim.ID> _CleanLocations = new List<Sim.ID>();
        private int _LastCleanCol;

        private void UpdateAll()
        {
            _Devices.Clear();
            _Sites.Clear();
            _CleanLocations.Clear();
            LoadRecipe(_Path);
            if (!(_MapPath == null))
                LoadMap(_MapPath);
            _PrintNum = 0;
            UpdatePrintIdx();
            CreateSourceFeatures();
            CreateTargetFeatures();
            CreateCleanFeatures();
            MakePlot();
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
                return;
            SelectDevice(_Picks[_PrintNum], _Devices.ToArray());
            SelectSite(_Prints[_PrintNum], _Sites.ToArray());
            SelectClean(_Cleans[_PrintNum], _CleanLocations.ToArray());
            MakePlot();
            _PrintNum++;
            UpdatePrintIdx();
        }

        private void SelectDevice(int[] vs, Sim.ID[] iDs)
        {
            iDs.Where(id => id.RR == vs[0] && id.RC == vs[1] && id.R == vs[2] && id.C == vs[3] && id.IDX == vs[4]).AsParallel().ForAll(e => e.Selected = false);
        }

        private void SelectSite(int[] vs, Sim.ID[] iDs)
        {
            iDs.Where(id => id.RR == vs[0] && id.RC == vs[1] && id.R == vs[2] && id.C == vs[3]).AsParallel().ForAll(e => e.Selected = true);
        }

        private void SelectClean(int[] vs, Sim.ID[] iDs)
        {
            if (vs[1] < _LastCleanCol)
            {
                iDs.AsParallel().ForAll(e => e.Selected = false); // Tape Indexed
                _LastCleanCol = vs[1];
            }
            else
                _LastCleanCol = vs[1];
            iDs.Where(id => id.R == vs[0] && id.C == vs[1] && id.IDX == vs[2]).AsParallel().ForAll(e => e.Selected = true);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            while (_PrintNum != _NumPrints)
            {
                btnNext_Click(sender, e);
                Application.DoEvents();
                System.Threading.Thread.Sleep((int)FinishXMapDelay);
            }
        }

        private void MakePlot()
        {
            Bitmap bg = new Bitmap((int)StageRange.X, (int)StageRange.Y);
            using (Graphics g = Graphics.FromImage(bg))
            {
                g.FillRectangle(Brushes.White, new RectangleF(0, 0, StageRange.X, StageRange.Y));
                g.DrawEllipse(new Pen(Brushes.DarkSeaGreen, 3), 
                    new RectangleF(
                        SourceWaferCenter.X - SourceDiameter / 2, 
                        SourceWaferCenter.Y - SourceDiameter / 2, 
                        SourceDiameter, 
                        SourceDiameter));
                g.DrawEllipse(new Pen(Brushes.BlueViolet, 3),
                    new RectangleF(
                        TargetWaferCenter.X - TargetDiameter / 2,
                        TargetWaferCenter.Y - TargetDiameter / 2,
                        TargetDiameter, 
                        TargetDiameter));
                g.DrawRectangle(new Pen(Brushes.Orange, 3),
                    new Rectangle(
                        (int)(CleanConfigOrigin.X - CleanConfigSize.Width),
                        (int)(CleanConfigOrigin.Y - CleanConfigSize.Height),
                        (int)CleanConfigSize.Width,
                        (int)CleanConfigSize.Height));
            }
            bg.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pb.BackgroundImage = bg;

            Bitmap fg = new Bitmap((int)StageRange.X, (int)StageRange.Y);
            using (Graphics g = Graphics.FromImage(fg))
            {
                foreach (Sim.ID device in _Devices.Where(x => x.Selected))
                    g.FillRectangle(Brushes.DarkSeaGreen, 
                        new RectangleF((float)device.X, (float)device.Y, SourceClusterPitch.X, SourceClusterPitch.Y));
                foreach (Sim.ID site in _Sites.Where(x => x.Selected))
                    g.FillRectangle(Brushes.BlueViolet, 
                        new RectangleF((float)site.X, (float)site.Y, StampSize.Width, StampSize.Height));
                foreach (Sim.ID clean in _CleanLocations.Where(x => x.Selected))
                    g.FillRectangle(Brushes.Orange, 
                        new RectangleF((float)clean.X, (float)clean.Y, StampSize.Width, StampSize.Height));
            }
            fg.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pb.Image = fg;

            Refresh();
        }

        private void CreateSourceFeatures()
        {
            for (int i = 0; i < NumIndices; i++)
            {
                _Devices.AddRange(Sim.MakeIDs(SourceClusters.X, SourceClusters.Y,
                                              SourceRegions.X, SourceRegions.Y,
                                              SourceClusterPitch.X, SourceClusterPitch.Y,
                                              SourceRegionPitch.X, SourceRegionPitch.Y,
                                              SourceOrigin.X, SourceOrigin.Y,
                                              true, i + 1));
            }
        }

        private void CreateTargetFeatures()
        {
            _Sites.AddRange(Sim.MakeIDs(TargetPrints.X, TargetPrints.Y,
                                        TargetClusters.X, TargetClusters.Y,
                                        TargetPrintPitch.X, TargetPrintPitch.Y,
                                        TargetClusterPitch.X, TargetClusterPitch.Y,
                                        TargetOrigin.X, TargetOrigin.Y,
                                        false, 1));
        }

        private void CreateCleanFeatures()
        {
            foreach (int[] clean in _Cleans)
                _CleanLocations.Add(new Sim.ID(-clean[1] * SourceClusterPitch.X + CleaningTapeOrigin.X, -clean[0] * SourceClusterPitch.Y + CleaningTapeOrigin.Y, 
                    1, 1, clean[0], clean[1], clean[2], false));
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Export Print Sim Map";
                saveFileDialog.DefaultExt = ".png";
                saveFileDialog.Filter = "png file (*.png)|*.png";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bg = (Bitmap)pb.BackgroundImage.Clone();
                    Bitmap fg = (Bitmap)pb.Image.Clone();
                    using (Graphics g = Graphics.FromImage(bg))
                    {
                        g.DrawImage(fg, new Point(0, 0));
                    }
                    bg.Save(saveFileDialog.FileName);
                }
            }
        }
    }
}
