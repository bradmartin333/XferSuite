using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using XferHelper;

namespace XferSuite
{
    public partial class CalGenerator : Form
    {
        private int XRange = 500;
        private int YRange = 500; 
        private int Increment, XSteps, YSteps;
        private string XAxis, YAxis, ZAxis, ZCAxis;
        private double[,] Data;

        public CalGenerator()
        {
            InitializeComponent();
            ComboIncrement.SelectedIndex = 2;
            NumXRange.Value = 500;
            NumYRange.Value = 500;
            ComboXAxis.SelectedIndex = 0;
            ComboYAxis.SelectedIndex = 1;
            ComboZAxis.SelectedIndex = 2;
            ComboZCAxis.SelectedIndex = 3;
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
            if ((int)NumXRange.Value % Increment == 0)
            {
                XRange = (int)NumXRange.Value;
                ComboIncrement.BackColor = System.Drawing.Color.White;
            }
            else
            {
                NumXRange.Value = XRange;
                ComboIncrement.BackColor = System.Drawing.Color.Gold;
            }
            UpdateAll();
        }

        private void NumYRange_ValueChanged(object sender, EventArgs e)
        {
            if ((int)NumYRange.Value % Increment == 0)
            {
                YRange = (int)NumYRange.Value;
                ComboIncrement.BackColor = System.Drawing.Color.White;
            }
            else
            {
                NumYRange.Value = YRange;
                ComboIncrement.BackColor = System.Drawing.Color.Gold;
            }
            UpdateAll();
        }

        private void ComboXAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboXAxis.SelectedIndex != -1)
            {
                if (ValidateAxes(ComboXAxis.Text))
                    XAxis = ComboXAxis.Text;
                else
                    ComboXAxis.SelectedIndex = -1;
            }
            UpdateAll();
        }

        private void ComboYAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboYAxis.SelectedIndex != -1)
            {
                if (ValidateAxes(ComboYAxis.Text))
                    YAxis = ComboYAxis.Text;
                else
                    ComboYAxis.SelectedIndex = -1;
            }
            UpdateAll();
        }

        private void ComboZAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboZAxis.SelectedIndex != -1)
            {
                if (ValidateAxes(ComboZAxis.Text))
                    ZAxis = ComboZAxis.Text;
                else
                    ComboZAxis.SelectedIndex = -1;
            }
            UpdateAll();
        }

        private void ComboZCAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboZCAxis.SelectedIndex != -1)
            {
                if (ValidateAxes(ComboZCAxis.Text))
                    ZCAxis = ComboZCAxis.Text;
                else
                    ComboZCAxis.SelectedIndex = -1;
            }
            UpdateAll();
        }

        private void ComboIncrement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboIncrement.SelectedIndex != -1)
            {
                int testIncrement = int.Parse(ComboIncrement.Text);
                if (XRange % testIncrement == 0 && YRange % testIncrement == 0)
                {
                    Increment = testIncrement;
                    ComboIncrement.BackColor = System.Drawing.Color.White;
                } 
                else
                {
                    ComboIncrement.SelectedIndex = -1;
                    ComboIncrement.BackColor = System.Drawing.Color.Gold;
                }
            }
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
            System.Diagnostics.Process.Start(@"https://github.com/bradmartin333/XferSuite/wiki/10Zone-2DCal-Generator");
        }

        #endregion

        private void UpdateAll()
        {
            ClearOutput();

            if (XRange <= 0 || YRange <= 0 || 
                ComboXAxis.SelectedIndex == -1 || ComboYAxis.SelectedIndex == -1 || ComboZAxis.SelectedIndex == -1 || ComboZCAxis.SelectedIndex == -1 ||
                ComboIncrement.SelectedIndex == -1) return;

            CreateDataArray();
            if (CreateHeatplot()) CreateCalOutput();
        }

        private void CreateDataArray()
        {
            try
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
                Data = new double[YSteps, XSteps];

                // Fit data to plane and generate data
                Zed.Plane plane = Zed.getPlaneVec(positions.ToArray());
                for (int i = 0; i < XRange; i += Increment)
                    for (int j = 0; j < YRange; j += Increment)
                    {
                        if (i > xmin && xmax > i && j > ymin && ymax > j)
                            Data[j / Increment, i / Increment] = Zed.projectPlane(plane, new Zed.Vec3(i, j, 0)).Z;
                        else
                            Data[j / Increment, i / Increment] = 0;
                    }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private void CreateCalOutput()
        {
            try
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private bool CreateHeatplot()
        {
            try
            {
                // Flip Y-Axis for plot
                double[,] data = new double[YSteps, XSteps];
                for (int i = 0; i < XSteps; i++)
                    for (int j = 0; j < YSteps; j++)
                        data[j, XSteps - 1 - i] = Data[j, i];

                ScottPlot.Plottable.Heatmap hm = FormsPlot.Plot.AddHeatmap(data, lockScales: false);
                hm.Smooth = true;
                FormsPlot.PerformAutoScale();
                FormsPlot.Refresh();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
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
