using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class CreateCustom : Form
    {
        public CreateCustom(Report.Entry[] data)
        {
            InitializeComponent();
            comboBoxShape.DataSource = Enum.GetValues(typeof(MarkerType));
            ((DataGridViewComboBoxColumn)dataGridView.Columns[0]).DataSource = data.Select(x => x.Name).Distinct().ToList();
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            var x = ParseDataGrid();
            ScatterSeries series = new ScatterSeries();
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

        #region File Management

        private List<string[]> ParseDataGrid()
        {
            List<string[]> filters = new List<string[]>();
            try
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    List<string> cols = new List<string>();
                    foreach (DataGridViewCell cell in row.Cells)
                        if (cell.Value != null) cols.Add(cell.Value.ToString());
                    // Make sure all cols are valid
                    if (cols.Count == 3) filters.Add(cols.ToArray());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in data filter entries", "Create Custom SEYR Plottable");
            }
            return filters;
        }

        private string GetDataGridAsString()
        {
            List<string[]> filters = ParseDataGrid();
            string output = string.Empty;
            foreach (string[] filter in filters)
                output += string.Join("\t", filter) + '\n';
            return output;
        }

        private string GetParameters()
        {
            return $"{labelColor.BackColor.ToArgb()}\t{comboBoxShape.Text}\t{numSize.Value}\t{numOffsetX.Value}\t{numOffsetY.Value}\n";
        }

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            string pathBuffer = MainMenu.SaveFile("Save Custom SEYR Plottable", "Text File (*.txt) | *.txt");
            if (pathBuffer == null)
                return;
            else
                System.IO.File.WriteAllText(pathBuffer, GetParameters() + GetDataGridAsString());
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            string pathBuffer = MainMenu.OpenFile("Open Custom SEYR Plottable", "Text File (*.txt) | *.txt");
            if (pathBuffer == null)
                return;
            else
                LoadAll(System.IO.File.ReadAllLines(pathBuffer));
        }

        private void LoadAll(string[] lines)
        {
            try
            {
                dataGridView.Rows.Clear();
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] cols = lines[i].Split('\t');
                    if (i == 0)
                    {
                        labelColor.BackColor = Color.FromArgb(int.Parse(cols[0]));
                        comboBoxShape.Text = cols[1];
                        numSize.Value = decimal.Parse(cols[2]);
                        numOffsetX.Value = decimal.Parse(cols[3]);
                        numOffsetY.Value = decimal.Parse(cols[4]);
                    }
                    else
                        dataGridView.Rows.Add(cols);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Corrupt save:\n{ex}", "Create Custom SEYR Plottable");
            }
        }

        #endregion
    }
}
