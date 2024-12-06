using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite.Apps.InlinePositions
{
    // HELP WANTED
    // Combine this class with Fingerprinting
    public partial class Angleprinting : Form
    {
        private float _PointMagnitude = 2F;
        [
            Category("User Parameters"),
            Description("Value to multiply angle error by")
        ]
        public float PointMagnitude
        {
            get => _PointMagnitude;
            set
            {
                _PointMagnitude = value;
                MakePlot();
            }
        }

        private float _ThresholdX = 1.5F;
        [
            Category("User Parameters"),
            Description("Positions with placement error greater than this micron value in the X direction will be filtered out of the plotted data"),
            DisplayName("Threshold X")
        ]
        public float ThresholdX
        {
            get => _ThresholdX;
            set
            {
                _ThresholdX = value;
                MakePlot();
            }
        }

        private float _ThresholdY = 1.5F;
        [
            Category("User Parameters"),
            Description("Positions with placement error greater than this micron value in the Y direction will be filtered out of the plotted data"),
            DisplayName("Threshold Y")
        ]
        public float ThresholdY
        {
            get => _ThresholdY;
            set
            {
                _ThresholdY = value;
                MakePlot();
            }
        }

        private readonly Metro.Position[] _Raw; // Gets split into data and missing
        private readonly Metro.Position[] _Data; // Gets split into pass and fail
        private bool _PlotAll = true; // On by default
        readonly List<string> _Prints = new List<string>();

        public Angleprinting(Metro.Position[] data)
        {
            InitializeComponent();
            ResizeEnd += Angleprinting_ResizeEnd;

            _Raw = data;
            Tuple<Metro.Position[], Metro.Position[]> _splitData = Metro.missingData(_Raw);
            _Data = _splitData.Item2; // We don't want any data for missing devices

            string[] indices = Metro.prints(_Raw); // Get all prints in RR RC R C format
            int printIdx = 1;
            int posIdx = 0;
            foreach (string index in indices)
            {
                if (!_Prints.Contains(index))
                {
                    // Add unique prints to the list box and increment the print index
                    _Prints.Add(index);
                    PrintList.Items.Add(string.Format("{0}: {1}", printIdx, index));
                    printIdx += 1;
                }
                _Raw[posIdx].PrintNum = printIdx; // Assign an print index to each passing device
                posIdx += 1;
            }

            MakePlot();
        }

        private void Angleprinting_ResizeEnd(object sender, EventArgs e)
        {
            MakePlot();
        }

        private void PrintList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _PlotAll = false;
            MakePlot();
        }

        private void PrintList_DoubleClick(object sender, EventArgs e)
        {
            _PlotAll = true;
            MakePlot();
        }

        private void MakePlot()
        {
            Metro.rescore(_Data, ThresholdX, ThresholdY, 0, 0);
            Tuple<Metro.Position[], Metro.Position[]> _scoredData = Metro.failData(_Data);
            Metro.Position[] plotData = _scoredData.Item2; // Passing positions

            PlotModel anglePlot = new PlotModel() { TitleFontSize = 15 };

            // Hacky, but fast way of selecting all by default
            List<int> loopSet = new List<int>();
            if (_PlotAll)
                for (int idx = 0; idx < PrintList.Items.Count; idx++)
                    loopSet.Add(idx);
            else
                foreach (int idx in PrintList.SelectedIndices)
                    loopSet.Add(idx);

            // Obtain and plot data for selected list box indices
            Metro.Position[][] printData = new Metro.Position[_Prints.Count()][];
            foreach (int idx in loopSet)
                printData[idx] = Metro.getPrint(_Prints[idx], plotData);
            foreach (int idx in loopSet)
                for (int i = 0; i < printData[idx].Length; i++)
                    anglePlot.Series.Add(PlotAngle(printData[idx][i], idx));

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

            var xPositions = Metro.xPos(_Data);
            var yPositions = Metro.yPos(_Data);
            var xMin = xPositions.Min() - 1;
            var xMax = xPositions.Max() + 1;
            var yMin = yPositions.Min() - 1;
            var yMax = yPositions.Max() + 1;

            double plotAspectRatio = (double)plot.Width / plot.Height;
            double dataAspectRatio = (xMax - xMin) / (yMax - yMin);

            if (dataAspectRatio > plotAspectRatio)
            {
                double adjustedHeight = (xMax - xMin) / plotAspectRatio;
                double yMid = (yMax + yMin) / 2;
                yMin = yMid - adjustedHeight / 2;
                yMax = yMid + adjustedHeight / 2;
            }
            else
            {
                double adjustedWidth = (yMax - yMin) * plotAspectRatio;
                double xMid = (xMax + xMin) / 2;
                xMin = xMid - adjustedWidth / 2;
                xMax = xMid + adjustedWidth / 2;
            }

            myXaxis.Minimum = xMin;
            myXaxis.Maximum = xMax;
            myYaxis.Minimum = yMin;
            myYaxis.Maximum = yMax;

            anglePlot.Axes.Add(myXaxis);
            anglePlot.Axes.Add(myYaxis);
            plot.Model = anglePlot;
        }

        private ScatterSeries PlotAngle(Metro.Position pos, int idx)
        {
            ScatterSeries post = new ScatterSeries() { 
                MarkerType = MarkerType.Circle,
                MarkerFill = pos.AE > 0 ? OxyColors.Blue : OxyColors.Red,
                MarkerSize = _PointMagnitude * Math.Abs(pos.AE) };
            post.TrackerFormatString = post.TrackerFormatString + Environment.NewLine + 
                PrintList.Items[idx].ToString() + Environment.NewLine + 
                "Angle Error: " + Math.Round(pos.AE, 6).ToString();
            post.Points.Add(new ScatterPoint(pos.X, pos.Y));
            return post;
        }

        private void BtnSavePlot_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Export Angleprint Plot";
                saveFileDialog.DefaultExt = ".png";
                saveFileDialog.Filter = "png file (*.png)|*.png";
                saveFileDialog.FileName = Text.Replace(".txt", "Angleprint");
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var pngExporter = new PngExporter { Width = plot.Width, Height = plot.Width };
                    Bitmap fg = pngExporter.ExportToBitmap(plot.Model);
                    Bitmap bg = new Bitmap(fg.Width, fg.Height);
                    using (Graphics g = Graphics.FromImage(bg))
                    {
                        g.FillRectangle(Brushes.White, new Rectangle(Point.Empty, bg.Size));
                        g.DrawImage(fg, new Point(0, 0));
                    }
                    bg.Save(saveFileDialog.FileName);
                }
            }
        }
    }
}
