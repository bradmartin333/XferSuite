using System;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite
{
    public partial class PositionCalc : Form
    {
        private double[][] Nums = new double[2][];

        public PositionCalc()
        {
            InitializeComponent();
            DeactivateCalc();
            Nums[0] = new double[] { 0 };
            Nums[1] = new double[] { 0 };
            foreach (Button button in tableLayoutPanelButtons.Controls.OfType<Button>())
                button.Click += PositionCalc_Click;
        }

        private void PositionCalc_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Clipboard.SetText(btn.Text);
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            CheckContents(textBox1);
        }

        private void textBox2_TextChanged(object sender, System.EventArgs e)
        {
            CheckContents(textBox2);
        }

        private void CheckContents(TextBox box)
        {
            DeactivateCalc();
            Nums[box.TabIndex] = new double[] { 0 };
            string[] str = box.Text.Split(',');
            if (str.Length != 9) return;
            Nums[box.TabIndex] = new double[9];
            for (int i = 0; i < 9; i++)
                if (!double.TryParse(str[i], out Nums[box.TabIndex][i])) return;
            if (Nums[0].Length == 9 && Nums[1].Length == 9) CalculateDifference();
        }

        private void DeactivateCalc()
        {
            foreach (Button button in tableLayoutPanelButtons.Controls.OfType<Button>())
            {
                button.Enabled = false;
                button.Text = "";
            }
        }

        private void CalculateDifference(bool toggle = false)
        {
            foreach (Button button in tableLayoutPanelButtons.Controls.OfType<Button>())
            {
                if (toggle && !button.Enabled) return;
                button.Enabled = true;
                double val = Math.Round(Nums[0][button.TabIndex] - Nums[1][button.TabIndex], 3);
                if (cbxAbs.Checked) val = Math.Abs(val);
                if (cbxFlip.Checked) val = -val;
                button.Text = val.ToString();
            }
        }

        private void cbxAbs_CheckedChanged(object sender, EventArgs e)
        {
            CalculateDifference(true);
        }

        private void cbxFlip_CheckedChanged(object sender, EventArgs e)
        {
            CalculateDifference(true);
        }
    }
}
