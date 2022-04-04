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
                    if (cols.Count == 2) filters.Add(cols.ToArray());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in data filter entries", "Create Custom SEYR Feature");
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
