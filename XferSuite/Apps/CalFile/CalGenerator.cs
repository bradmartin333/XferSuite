using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using XferHelper;

namespace XferSuite
{
    public partial class CalGenerator : Form
    {
        private int XRange { get; set; }
        private int YRange { get; set; }
        private string XAxis { get; set; }
        private string YAxis { get; set; }
        private string ZAxis { get; set; }
        private string ZCAxis { get; set; }
        private int Increment { get; set; }
        private int XSteps { get; set; }
        private int YSteps { get; set; }
        private double[,] Data { get; set; }

        public CalGenerator()
        {
            InitializeComponent();
            NumXRange.Value = 500;
            NumYRange.Value = 500;
            ComboXAxis.SelectedIndex = 0;
            ComboYAxis.SelectedIndex = 1;
            ComboZAxis.SelectedIndex = 2;
            ComboZCAxis.SelectedIndex = 3;
            ComboIncrement.SelectedIndex = 2;
            FormsPlot.Plot.Frameless();
            Show();
        }

        #region Cal File Helpers

        private string CalStr(double z)
        {
            return string.Format("{0:#,0.000}\t{0:#,0.000}\t", z);
        }

        private void TabToLine(ref string s)
        {
            int place = s.LastIndexOf('\t');
            if (place == -1)
                return;
            s = s.Remove(place, 1).Insert(place, "\n");
        }

        private string BorderLine()
        {
            string line = "";
            for (int i = 0; i < XSteps + 2; i++)
                line += CalStr(0.0);
            TabToLine(ref line);
            return line;
        }

        #endregion

        #region UI Handlers

        private void NumXRange_ValueChanged(object sender, EventArgs e)
        {
            XRange = (int)NumXRange.Value;
            UpdateAll();
        }

        private void NumYRange_ValueChanged(object sender, EventArgs e)
        {
            YRange = (int)NumYRange.Value;
            UpdateAll();
        }

        private void ComboXAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboXAxis.SelectedIndex != -1)
            {
                if (ValidateAxes(ComboXAxis.Text))
                {
                    XAxis = ComboXAxis.Text;
                    UpdateAll();
                }
                else
                    ComboXAxis.SelectedIndex = -1;
            }
        }

        private void ComboYAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboYAxis.SelectedIndex != -1)
            {
                if (ValidateAxes(ComboYAxis.Text))
                {
                    YAxis = ComboYAxis.Text;
                    UpdateAll();
                }
                else
                    ComboYAxis.SelectedIndex = -1;
            }
        }

        private void ComboZAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboZAxis.SelectedIndex != -1)
            {
                if (ValidateAxes(ComboZAxis.Text))
                {
                    ZAxis = ComboZAxis.Text;
                    UpdateAll();
                }
                else
                    ComboZAxis.SelectedIndex = -1;
            }
        }

        private void ComboZCAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboZCAxis.SelectedIndex != -1)
            {
                if (ValidateAxes(ComboZCAxis.Text))
                {
                    ZCAxis = ComboZCAxis.Text;
                    UpdateAll();
                }
                else
                    ComboZCAxis.SelectedIndex = -1;
            }
        }

        private void ComboIncrement_SelectedIndexChanged(object sender, EventArgs e)
        {
            Increment = int.Parse(ComboIncrement.Text);
            UpdateAll();
        }

        private void BtnAddPosition_Click(object sender, EventArgs e)
        {
            string clipboard = Clipboard.GetText();
            string[] pastes = clipboard.Split('\n');
            foreach (string paste in pastes)
            {
                string cleanPaste = paste.Trim('\r');
                if (ValidatePosition(cleanPaste)) RTBPositions.Text += $"{cleanPaste}\n";
            }
            UpdateAll();
        }

        private void BtnClearPositions_Click(object sender, EventArgs e)
        {
            RTBPositions.Clear();
            ClearOutput();
        }

        private void BtnCopyOutput_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RTBOutput.Text);
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void UpdateAll()
        {
            if (XRange <= 0 || YRange <= 0 || 
                ComboXAxis.SelectedIndex == -1 || ComboYAxis.SelectedIndex == -1 || ComboZAxis.SelectedIndex == -1 || ComboZCAxis.SelectedIndex == -1 ||
                ComboIncrement.SelectedIndex == -1) return;

            ClearOutput();
            CreateDataArray();
            if (CreateHeatplot()) CreateCalOutput();
        }

        private void CreateDataArray()
        {
            // Parse pasted positions
            List<Zed.Vec3> positions = new List<Zed.Vec3>();
            string[] pastes = RTBPositions.Text.Split('\n');
            foreach (string paste in pastes)
            {
                if (string.IsNullOrEmpty(paste)) break;
                string[] cols = paste.Split(',');
                positions.Add(new Zed.Vec3(double.Parse(cols[0]), double.Parse(cols[1]), double.Parse(cols[5])));
            }

            // Find data bounds
            (double xmin, double xmax) = Zed.getAxisMinMax(positions.Select(x => x.X).ToArray());
            (double ymin, double ymax) = Zed.getAxisMinMax(positions.Select(y => y.Y).ToArray());

            // Create blank data array
            XSteps = XRange / Increment;
            YSteps = YRange / Increment;
            Data = new double[XSteps, YSteps];

            // Fit data to plane and generate data
            Zed.Plane plane = Zed.getPlaneVec(positions.ToArray());
            for (int i = 0; i < XRange; i += Increment)
                for (int j = 0; j < YRange; j += Increment)
                {
                    if (i > xmin && xmax > i && j > ymin && ymax > j)
                        Data[i / Increment, j / Increment] = Zed.projectPlane(plane, new Zed.Vec3(i, j, 0)).Z;
                    else
                        Data[i / Increment, j / Increment] = 0;
                }    
        }

        private void CreateCalOutput()
        {
            string header = $":START2D {XAxis} {YAxis} {ZAxis} {ZCAxis} -{Increment} -{Increment} {XSteps + 2}\n:START2D POSUNIT=METRIC CORUNIT=METRIC\n\n";

            string body = BorderLine();
            for (int j = 0; j < YSteps; j++)
            {
                body += CalStr(0.0);
                for (int i = 0; i < XSteps; i++)
                    body += CalStr(Data[j, i]);
                body += CalStr(0.0);
                TabToLine(ref body);
            }
            body += BorderLine();

            RTBOutput.Text = header + body + "\n:END";
        }

        private bool CreateHeatplot()
        {
            try
            {
                // Flip Y-Axis for plot
                double[,] data = new double[XSteps, YSteps];
                for (int i = 0; i < XSteps; i++)
                    for (int j = 0; j < YSteps; j++)
                        data[XSteps - 1 - i, j] = Data[i, j];

                ScottPlot.Plottable.Heatmap hm = FormsPlot.Plot.AddHeatmap(data, lockScales: false);
                hm.Smooth = true;
                FormsPlot.PerformAutoScale();
                FormsPlot.Refresh();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void ClearOutput()
        {
            RTBOutput.Clear();
            FormsPlot.Plot.Clear();
            FormsPlot.Refresh();
        }

        private bool ValidatePosition(string paste)
        {
            string[] vals = paste.Split(',');
            if (vals.Length < 9) return false;
            // Special PositionMemory.txt parser
            return !(double.Parse(vals[0]) == 1000000.0 || double.Parse(vals[1]) == 1000000.0 || double.Parse(vals[5]) == 1000000.0);
        }

        private bool ValidateAxes(string value) => !(XAxis == value || YAxis == value || ZAxis == value || ZCAxis == value);
    }
}
