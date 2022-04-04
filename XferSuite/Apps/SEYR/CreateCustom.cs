using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class CreateCustom : Form
    {
        public CustomFeature CustomFeature { get; set; }

        public CreateCustom(Report.Feature[] features)
        {
            InitializeComponent();
            ((DataGridViewComboBoxColumn)dataGridView.Columns[0]).DataSource = features.Select(x => x.Name).Distinct().ToList();
            comboBoxType.SelectedIndex = 0;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            CustomFeature = new CustomFeature(this, ParseDataGrid());
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #region File Management

        private List<(string, Report.State)> ParseDataGrid()
        {
            List<(string, Report.State)> filters = new List<(string, Report.State)>();
            try
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                    for (int i = 0; i < 2; i++)
                        if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                            filters.Add(((string, Report.State))(row.Cells[0].Value.ToString(), Enum.Parse(typeof(Report.State), row.Cells[1].Value.ToString())));
            }
            catch (Exception)
            {
                MessageBox.Show("Error in data filter entries", "Create Custom SEYR Feature");
            }
            return filters;
        }

        private string GetDataGridAsString()
        {
            List<(string, Report.State)> filters = ParseDataGrid();
            string output = string.Empty;
            foreach ((string, Report.State) filter in filters)
                output += $"{filter.Item1}\t{filter.Item2}\n";
            return output;
        }

        private string GetParameters()
        {
            return $"{txtName.Text}\t{comboBoxType.Text}\t{numOffsetX.Value}\t{numOffsetY.Value}\n";
        }

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            string pathBuffer = MainMenu.SaveFile("Save Custom SEYR Feature", "Text File (*.txt) | *.txt");
            if (pathBuffer == null)
                return;
            else
                System.IO.File.WriteAllText(pathBuffer, GetParameters() + GetDataGridAsString());
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            string pathBuffer = MainMenu.OpenFile("Open Custom SEYR Feature", "Text File (*.txt) | *.txt");
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
                        txtName.Text = cols[0];
                        comboBoxType.Text = cols[1];
                        numOffsetX.Value = decimal.Parse(cols[2]);
                        numOffsetY.Value = decimal.Parse(cols[3]);
                    }
                    else
                        dataGridView.Rows.Add(cols);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Corrupt save:\n\n{ex}", "Create Custom SEYR Feature");
            }
        }

        #endregion
    }
}
