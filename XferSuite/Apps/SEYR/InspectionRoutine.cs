using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Text;

namespace XferSuite.Apps.SEYR
{
    public partial class InspectionRoutine : Form
    {
        public string Output;
        private readonly string Header;
        private readonly string ID;
        private readonly DataEntry[] Entries;
        private readonly string[] DataRows;
        private readonly string[] FailReasons;
        private int DataIndex = -1;

        public InspectionRoutine(DataSheet sheet, (string, List<string>) info)
        {
            InitializeComponent();
            ID = sheet.ID.ToString();
            Entries = sheet.GetEntries();
            Header = info.Item1.Replace("\n", ", FailReason\n");
            DataRows = sheet.GetDataRows(info.Item2, true).Split('\n').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            FailReasons = new string[DataRows.Length];
            TextBoxName.Click += TextBoxName_Click;
            Next(false);
        }

        private void TextBoxName_Click(object sender, EventArgs e)
        {
            TextBoxName.Focus();
            TextBoxName.SelectAll();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    if (ListBoxNames.SelectedIndex > -1) ListBoxNames.SelectedIndex--;
                    return true;
                case Keys.Left:
                    Previous();
                    return true;
                case Keys.Down:
                    if (ListBoxNames.SelectedIndex < ListBoxNames.Items.Count - 1) ListBoxNames.SelectedIndex++;
                    return true;
                case Keys.Right:
                    Next();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            Previous();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void Previous()
        {
            if (DataIndex == 0) return;
            AddName();
            DataIndex--;
            ShowData();
        }

        private void Next(bool userClick = true)
        {
            if (DataIndex > DataRows.Length - 2) return;
            if (userClick)
            {
                UpdateReason();
                AddName();
            }
            DataIndex++;
            ShowData();
        }

        private void AddName()
        {
            if (!ListBoxNames.Items.Contains(TextBoxName.Text))
            {
                ListBoxNames.Items.Add(TextBoxName.Text);
                ListBoxNames.SelectedIndex = ListBoxNames.Items.Count - 1;
            }
        }

        private void ShowData()
        {
            int imgNum = int.Parse(DataRows[DataIndex].Split(',')[0]);
            (int, int) thisTile = (int.Parse(DataRows[DataIndex].Split(',')[9]), int.Parse(DataRows[DataIndex].Split(',')[10]));
            DataEntry[] matches = Entries.Where(x => x.ImageNumber == imgNum && (x.TR, x.TC) == thisTile && x.Image != null).ToArray();
            if (matches.Count() > 1)
            {
                DataEntry[] specificImage = matches.Where(x => x.FeatureName.ToLower().Contains("img")).ToArray();
                if (specificImage.Length == 1) matches = specificImage;
            }
            if (matches.Length == 1)
            {
                DataEntry entry = matches.First();
                PBX.BackgroundImage = entry.Image;
                Text = $"Inspecting fail {DataIndex + 1} of {DataRows.Length} in region {ID}";
                if (!string.IsNullOrEmpty(FailReasons[DataIndex]))
                    TextBoxName.Text = FailReasons[DataIndex];
                else
                {
                    ListBoxNames.SelectedIndex = 0;
                    Application.DoEvents(); // Selected index visually refreshed immediately
                }
                TextBoxName.Focus();
                TextBoxName.SelectAll();
            }
        }

        private void ListBoxNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxNames.SelectedItem != null) TextBoxName.Text = ListBoxNames.SelectedItem.ToString();
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            UpdateReason();
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            UpdateReason();
            StringBuilder sb = new StringBuilder(Header);
            for (int i = 0; i < DataRows.Length; i++)
                sb.AppendLine(DataRows[i].Replace("\r", $", {FailReasons[i]}"));
            Output = sb.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateReason() => FailReasons[DataIndex] = TextBoxName.Text;
    }
}
