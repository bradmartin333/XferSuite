using OxyPlot;
using System;
using System.Linq;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class CreateCustom : Form
    {
        public CreateCustom(Report.Feature[] features)
        {
            InitializeComponent();
            comboBoxShape.DataSource = Enum.GetValues(typeof(MarkerType));
            ((DataGridViewComboBoxColumn)dataGridView.Columns[0]).DataSource = features.Select(x => x.Name).Distinct().ToList();
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {

        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LabelColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog
            {
                AllowFullOpen = true,
                ShowHelp = true,
                Color = labelColor.BackColor
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
                labelColor.BackColor = MyDialog.Color;
        }
    }
}
