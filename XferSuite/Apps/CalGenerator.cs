using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace XferSuite
{
    public partial class CalGenerator : Form
    {
        private int XRange = 450;
        private int YRange = 450;
        private string XAxis, YAxis, ZAxis, ZCAxis;
        private double[] Data = new double[4];

        public CalGenerator()
        {
            InitializeComponent();
            NumXRange.Value = XRange;
            NumYRange.Value = YRange;
            ComboXAxis.SelectedIndex = 0;
            ComboYAxis.SelectedIndex = 1;
            ComboZAxis.SelectedIndex = 3;
            ComboZCAxis.SelectedIndex = 5;
            Show();
        }

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
                string.IsNullOrEmpty(RTBPositions.Text)) return;

            CreateDataArray();

            RTBOutput.Text = $":START2D {XAxis} {YAxis} {ZAxis} {ZCAxis} -{XRange:f3} -{YRange:f3} 3"
                + $"\n:START2D POSUNIT=METRIC CORUNIT=METRIC/1000\n\n"
                + $"{Data[1]:f3}\t{Data[1]:f3}\t{Data[3]:f3}\t{Data[3]:f3}\t0.000\t0.000\n"
                + $"{Data[0]:f3}\t{Data[0]:f3}\t{Data[2]:f3}\t{Data[2]:f3}\t0.000\t0.000\n"
                + $"0.000\t0.000\t0.000\t0.000\t0.000\t0.000\n\n:END";
        }

        private void CreateDataArray()
        {
            try
            {
                // Parse pasted positions
                // NW NE SW SE
                List<double> positions = new List<double>();
                string[] pastes = RTBPositions.Text.Split('\n');
                foreach (string paste in pastes)
                {
                    if (string.IsNullOrEmpty(paste)) break;
                    positions.Add(double.Parse(paste.Split(',')[5]));
                }

                Data = new double[4]
                {
                    0.0,
                    (positions[1] - positions[0]) * 1e3,
                    (positions[2] - positions[0]) * 1e3,
                    (positions[3] - positions[0]) * 1e3
                };

                LabelRange.Text = $"Range = {Math.Round((Data.Max() - Data.Min()) * 1e3, 3)} mm";

                // Remove min projection and convert to microns
                double min = Data.Min();
                for (int i = 0; i < 4; i++)
                {
                    Data[i] -= min;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private void ClearOutput()
        {
            RTBOutput.Clear();
            LabelRange.Text = "Range = N/A";
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
