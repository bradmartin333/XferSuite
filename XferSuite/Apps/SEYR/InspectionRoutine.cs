using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Text;
using System.IO;

namespace XferSuite.Apps.SEYR
{
    public partial class InspectionRoutine : Form
    {
        private static FailReason NullFailReason = new FailReason() { Index = 1, Message = "null" };
        private static List<FailReason> FailReasonStructs = new List<FailReason>() { NullFailReason };
        private readonly string Header;
        private readonly string ID;
        private readonly DataEntry[] Entries;
        private readonly string[] DataRows;
        private readonly string[] FailReasons;
        private int DataIndex = -1;
        
        private struct FailReason
        {
            public int Index;
            public string Message;
        }

        public InspectionRoutine(DataSheet sheet, (string, List<string>) info)
        {
            InitializeComponent();
            ID = sheet.ID.ToString();
            Entries = sheet.GetEntries();
            Header = info.Item1.Replace("\n", ", FailReason\n");
            DataRows = sheet.GetDataRows(info.Item2, true).Split('\n').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            FailReasons = Enumerable.Repeat("null", DataRows.Length).ToArray();
            TextBoxName.Click += TextBoxName_Click;
            Text = $"Inspecting fails in region {ID}";
            OLV.Objects = FailReasonStructs;
            Shown += InspectionRoutine_Shown;
            Next(false);
        }

        private void InspectionRoutine_Shown(object sender, EventArgs e)
        {
            SelectText();
        }

        private void TextBoxName_Click(object sender, EventArgs e)
        {
            SelectText();
        }

        private void SelectText()
        {
            TextBoxName.Focus();
            TextBoxName.SelectAll();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    if (OLV.SelectedIndex > -1) OLV.SelectedIndex--;
                    return true;
                case Keys.Left:
                    Previous();
                    return true;
                case Keys.Down:
                    if (OLV.SelectedIndex < OLV.Items.Count - 1) OLV.SelectedIndex++;
                    return true;
                case Keys.Right:
                    Next();
                    return true;
                case Keys.D1:
                case Keys.NumPad1:
                    SelectIndex(1);
                    return true;
                case Keys.D2:
                case Keys.NumPad2:
                    SelectIndex(2);
                    return true;
                case Keys.D3:
                case Keys.NumPad3:
                    SelectIndex(3);
                    return true;
                case Keys.D4:
                case Keys.NumPad4:
                    SelectIndex(4);
                    return true;
                case Keys.D5:
                case Keys.NumPad5:
                    SelectIndex(5);
                    return true;
                case Keys.D6:
                case Keys.NumPad6:
                    SelectIndex(6);
                    return true;
                case Keys.D7:
                case Keys.NumPad7:
                    SelectIndex(7);
                    return true;
                case Keys.D8:
                case Keys.NumPad8:
                    SelectIndex(8);
                    return true;
                case Keys.D9:
                case Keys.NumPad9:
                    SelectIndex(9);
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
            if (DataIndex <= 0)
            {
                LabelCounter.BackColor = System.Drawing.Color.Gold;
                return;
            }
            LabelCounter.BackColor = System.Drawing.SystemColors.Control;
            AddName();
            DataIndex--;
            ShowData();
        }

        private void Next(bool userClick = true)
        {
            if (DataIndex > DataRows.Length - 2)
            {
                LabelCounter.BackColor = System.Drawing.Color.LightGreen;
                return;
            }
            LabelCounter.BackColor = System.Drawing.SystemColors.Control;
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
            FailReason failReason = new FailReason() { Index = OLV.Items.Count + 1, Message = TextBoxName.Text };
            if (!FailReasonStructs.Where(x => x.Message == failReason.Message).Any())
            {
                FailReasonStructs.Add(failReason);
                OLV.Objects = FailReasonStructs;
                OLV.SelectedIndex = OLV.Items.Count - 1;
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
                LabelCounter.Text = $"{DataIndex + 1} / {DataRows.Length}";
                OLV.SelectedIndex = FailReasonStructs.IndexOf(FailReasonStructs.Where(x => x.Message == FailReasons[DataIndex]).First());
                SelectText();
            }
        }

        private void SelectIndex(int idx)
        {
            if (idx > OLV.Items.Count) return;
            OLV.SelectedIndex = idx - 1;
            Application.DoEvents();
            System.Threading.Thread.Sleep(250);
            Next();
        }

        private void OLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OLV.SelectedItem != null) TextBoxName.Text = ((FailReason)OLV.SelectedObject).Message;
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            UpdateReason();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(Header);
            for (int i = 0; i < DataRows.Length; i++)
                sb.AppendLine(DataRows[i].Replace("\r", $", {FailReasons[i]}"));
            string data = sb.ToString();
            ParseSEYR.ApplyDelimeter(ref data);
            Clipboard.SetText(data);
        }

        private void UpdateReason() => FailReasons[DataIndex] = TextBoxName.Text;

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = MainMenu.OpenFile("Open a Inspection Routine Fail Reason list", "txt file(*.txt) | *.txt");
            if (string.IsNullOrEmpty(path)) return;
            string[] lines = System.IO.File.ReadAllLines(path);
            List<FailReason> imports = new List<FailReason>();
            lines.ToList().ForEach(x => imports.Add(TxtToFailReason(x)));
            FailReasonStructs = (List<FailReason>)imports.Distinct().ToList();
            OLV.Objects = FailReasonStructs;
        }

        private FailReason TxtToFailReason(string x)
        {
            string[] cols = x.Split('\t');
            if (cols.Length != 2) return NullFailReason;
            try
            {
                FailReason failReason = new FailReason()
                {
                    Index = int.Parse(cols[0]),
                    Message = cols[1],
                };
                return failReason;
            }
            catch (Exception)
            {
                return NullFailReason;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog
            {
                Filter = "txt file(*.txt) | *.txt",
                Title = "Save a Inspection Routine Fail Reason list",
            };
            if (svd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter stream = new StreamWriter(svd.FileName, false))
                {
                    foreach (FailReason failReason in FailReasonStructs)
                        stream.WriteLine($"{failReason.Index}\t{failReason.Message}");
                }
            }
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FailReasonStructs = new List<FailReason>() { NullFailReason };
            OLV.Objects = FailReasonStructs;
        }
    }
}
