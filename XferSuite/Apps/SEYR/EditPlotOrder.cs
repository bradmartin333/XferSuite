using System.Collections.Generic;
using System.Windows.Forms;

namespace XferSuite
{
    public partial class EditPlotOrder : Form
    {
        public List<string> PlotOrder { get; set; } = new List<string>();
        public EditPlotOrder(List<string> plotOrder)
        {
            InitializeComponent();
            listBox1.Items.AddRange(plotOrder.ToArray());
            listBox1.KeyUp += ListBox1_KeyUp;
        }

        private void ListBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnMove.PerformClick();
        }

        private void BtnMove_Click(object sender, System.EventArgs e)
        {
            if (listBox1.Items.Count == 0)
                Confirm();
            if (listBox1.SelectedIndex != -1)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            if (listBox1.Items.Count == 0)
                btnMove.BackgroundImage = Properties.Resources.bigCheck;
        }

        private void Confirm()
        {
            foreach (string item in listBox2.Items)
                PlotOrder.Add(item);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
