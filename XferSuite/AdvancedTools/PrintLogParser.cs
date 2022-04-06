using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.AdvancedTools
{
    /// <summary>
    /// Calculates duration of print sessions from a uTP log
    /// </summary>
    public partial class PrintLogParser : Form
    {
        readonly List<Print> Prints = new List<Print>();

        public PrintLogParser()
        {
            InitializeComponent();
            Show();
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            string path = OpenFile("Select uTP Log", "txt file (*.txt)|*.txt");
            if (path == null) return;

            LabelPath.Text = path;
            Prints.Clear();
            ComboBoxRecipe.Items.Clear();
            ComboBoxDate.Items.Clear();
            RichTextBox.Text = "Minutes\tCycles\n";

            FindPrints();

            ComboBoxRecipe.Items.AddRange(Prints.Select(x => x.Recipe).Distinct().ToArray());
        }

        private string OpenFile(string title, string filter)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = title;
                openFileDialog.Filter = filter;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    return openFileDialog.FileName;
            }
            return null;
        }

        private void FindPrints()
        {
            try
            {
                using (StreamReader reader = new StreamReader(LabelPath.Text))
                {
                    _ = reader.ReadLine(); // Discard header
                    while (reader.Peek() != -1)
                    {
                        var line = reader.ReadLine();
                        _ = reader.Peek();
                        string[] data = line.Split(',');
                        if (data.Length == 2)
                        {
                            if (line.Contains("STARTED")) Prints.Add(new Print() { Start = DateTime.Parse(data[0]) });
                            else
                            {
                                Prints.Last().Stop = DateTime.Parse(data[0]);
                                if (line.Contains("FINISHED"))
                                    Prints.Last().Finished = true;
                            }
                        }
                        else
                        {
                            if (Prints.Last().Recipe == string.Empty) Prints.Last().Recipe = data[19].Split('\\').Last();
                            Prints.Last().Cycles++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Invalid File\n\n{ex}", "XferSuite Advanced Tools");
            }
        }

        private void ComboBoxRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxRecipe.SelectedIndex == -1) return;
            ComboBoxDate.Items.Clear();
            ComboBoxDate.Text = "";
            RichTextBox.Text = "Minutes\tCycles\n";
            ComboBoxDate.Items.AddRange(Prints.Where(x => x.Recipe == ComboBoxRecipe.Text).
                Select(y => y.Start.ToShortDateString()).Distinct().ToArray());
        }

        private void ComboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            RichTextBox.Text = "Minutes\tCycles\n";
            foreach (Print print in Prints.Where(x => x.Recipe == ComboBoxRecipe.Text &&
                x.Start.ToShortDateString() == ComboBoxDate.Text))
            {
                RichTextBox.Text += print.ToString();
            }
        }
    }

    public partial class Print
    {
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public bool Finished { get; set; }
        public string Recipe { get; set; } = string.Empty;
        public int Cycles { get; set; }
        public Print() { }
        public override string ToString() => $"{(Stop - Start).TotalMinutes:f3}\t{Cycles}\n";
    }
}
