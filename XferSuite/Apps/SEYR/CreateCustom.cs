using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite.Apps.SEYR
{
    /// <summary>
    /// Form for creating custom SEYR features from existing report data
    /// </summary>
    public partial class CreateCustom : Form
    {
        public CustomFeature CustomFeature { get; set; } = new CustomFeature();
        private readonly List<CustomFeature> ExistingCustomFeatures;

        public CreateCustom(Report.Feature[] features, List<CustomFeature> customFeatures, CustomFeature feature = null)
        {
            InitializeComponent();
            panelColor.Click += PanelColor_Click;
            if (feature != null)
            {
                CustomFeature = feature;
                Text = Text.Replace("Create", "Edit");
            }
            ExistingCustomFeatures = customFeatures;
            ((DataGridViewComboBoxColumn)dataGridView.Columns[0]).DataSource = features.Select(x => x.Name).Distinct().ToList();
            txtName.Text = CustomFeature.Name;
            panelColor.BackColor = Color.FromArgb(CustomFeature.Color.A, CustomFeature.Color.R, CustomFeature.Color.G, CustomFeature.Color.B);
            numSize.Value = CustomFeature.Size;
            comboBoxType.SelectedIndex = CustomFeature.Type == Report.State.Pass ? 0 : 1;
            numOffsetX.Value = (decimal)CustomFeature.Offset.X;
            numOffsetY.Value = (decimal)CustomFeature.Offset.Y;
            foreach ((string, Report.State) filter in CustomFeature.Filters)
                dataGridView.Rows.Add(new object[] { filter.Item1, filter.Item2 == Report.State.Pass ? "Pass" : "Fail" });
            CustomFeature.Visible = true;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (ExistingCustomFeatures.Select(x => x.Name).Contains(txtName.Text) && !Text.Contains("Edit"))
            {
                MessageBox.Show("Custom feature name already taken.", "Create Custom SEYR Feature");
                return;
            }
            CustomFeature.Update(this, ParseDataGrid());
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PanelColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog
            {
                AllowFullOpen = true,
                ShowHelp = true,
                Color = panelColor.BackColor,
                CustomColors = new int[] { 
                    ColorTranslator.ToOle(Color.LawnGreen),
                    ColorTranslator.ToOle(Color.Firebrick),
                    ColorTranslator.ToOle(Color.Blue),
                    ColorTranslator.ToOle(Color.Orange), },
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
                panelColor.BackColor = MyDialog.Color;
        }

        #region File Management

        private List<(string, Report.State)> ParseDataGrid()
        {
            List<(string, Report.State)> filters = new List<(string, Report.State)>();
            try
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
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
            return $"{txtName.Text}\t{panelColor.BackColor.ToArgb()}\t{numSize.Value}\t{comboBoxType.Text}\t{numOffsetX.Value}\t{numOffsetY.Value}\n";
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
                        panelColor.BackColor = Color.FromArgb(int.Parse(cols[1]));
                        numSize.Value = decimal.Parse(cols[2]);
                        comboBoxType.Text = cols[3];
                        numOffsetX.Value = decimal.Parse(cols[4]);
                        numOffsetY.Value = decimal.Parse(cols[5]);
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
