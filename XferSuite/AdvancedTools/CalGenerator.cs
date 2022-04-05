using System;
using System.Windows.Forms;
using System.Linq;
using XferHelper;

namespace XferSuite.AdvancedTools
{
    public partial class CalGenerator : Form
    {
        private int XRange = 450;
        private int YRange = 450;
        private string XAxis, YAxis, ZAxis, ZCAxis;

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
            if (pastes.Length < 3) return;
            for (int i = 0; i < 3; i++)
            {
                string cleanPaste = pastes[i].Trim('\r');
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
            System.Diagnostics.Process.Start(@"https://github.com/bradmartin333/XferSuite/wiki/10Zone-Calibration-Generator");
        }

        #endregion

        private void UpdateAll()
        {
            ClearOutput();

            if (XRange <= 0 || YRange <= 0 || 
                ComboXAxis.SelectedIndex == -1 || ComboYAxis.SelectedIndex == -1 || ComboZAxis.SelectedIndex == -1 || ComboZCAxis.SelectedIndex == -1 ||
                string.IsNullOrEmpty(RTBPositions.Text)) return;

            // Parse pasted positions
            // NW NE SW
            Zed.Vec3[] rawPositions = new Zed.Vec3[3];
            string[] pastes = RTBPositions.Text.Split('\n');
            for (int i = 0; i < 3; i++)
            {
                if (string.IsNullOrEmpty(pastes[i])) break;
                string[] cols = pastes[i].Split(',');
                rawPositions[i] = new Zed.Vec3(double.Parse(cols[0]), double.Parse(cols[1]), double.Parse(cols[5]));
            }

            // Remove average projection and convert to mm
            double avg = rawPositions.Select(x => x.Z).Average();
            Zed.Vec3[] positions = new Zed.Vec3[3];
            for (int i = 0; i < 3; i++)
                positions[i] = new Zed.Vec3(rawPositions[i].X, rawPositions[i].Y, (rawPositions[i].Z - avg) * 1e3);

            LabelRange.Text = $"Range = {Math.Round(positions.Select(x => x.Z).Max() - positions.Select(x => x.Z).Min(), 3)} mm";

            Create1DCal(new double[] { positions[0].X, positions[1].X }, new double[] { positions[0].Z, positions[1].Z }, XAxis, XRange);
            Create1DCal(new double[] { positions[0].Y, positions[2].Y }, new double[] { positions[0].Z, positions[2].Z }, YAxis, YRange);
        }

        private void Create1DCal(double[] A, double[] B, string axis, int range)
        {
            (double b, double m) = Zed.linearFit(A, B);
            RTBOutput.Text += $":START {ZAxis} MASTER={axis} POSUNIT=METRIC CORUNIT=METRIC/1000 SAMPLEDIST=-{range}\n"
                + $"{(m * range) + b:f3}\t{b:f3}\t0.000\n"
                + $":END\n";
            RTBOutput.Text += $":START {ZCAxis} MASTER={axis} POSUNIT=METRIC CORUNIT=METRIC/1000 SAMPLEDIST=-{range}\n"
                + $"{(m * range) + b:f3}\t{b:f3}\t0.000\n"
                + $":END\n";
        }

        private void ClearOutput()
        {
            RTBOutput.Text =
                  $";***************************************************************************\n"
                + $";10Zone Height Calibration\t{DateTime.Today.ToLongDateString()}\n"
                + $"****************************************************************************\n";
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
