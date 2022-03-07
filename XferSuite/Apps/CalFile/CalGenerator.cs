using System;
using System.Windows.Forms;

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
            Show();
        }

        #region Cal File Generation

        private void SaveA3200CalFile(string path)
        {
            XSteps = XRange / Increment;
            YSteps = YRange / Increment;

            string header = string.Format(":START2D {0} {1} {2} {3} -{4} -{4} {5}\n:START2D POSUNIT=METRIC CORUNIT=METRIC\n\n",
                XAxis,
                YAxis,
                ZAxis,
                ZCAxis,
                Increment, XSteps + 2);

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

            string footer = "\n:END";

            string output = header + body + footer;
        }

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
        }

        private void NumYRange_ValueChanged(object sender, EventArgs e)
        {
            YRange = (int)NumYRange.Value;
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
        }

        private void BtnAddPosition_Click(object sender, EventArgs e)
        {
            string paste = Clipboard.GetText();
            if (ValidatePosition(paste)) RTBPositions.Text += paste;
        }

        private void BtnClearPositions_Click(object sender, EventArgs e)
        {
            RTBPositions.Clear();
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
            //throw new NotImplementedException();
        }

        private bool ValidatePosition(string paste) => paste.Split(',').Length == 10;

        private bool ValidateAxes(string value) => !(XAxis == value || YAxis == value || ZAxis == value || ZCAxis == value);
    }
}
