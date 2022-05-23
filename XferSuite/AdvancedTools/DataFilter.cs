using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace XferSuite.AdvancedTools
{
    public partial class DataFilter : Form
    {
        struct CommandProcessor
        {
            public Commands Command;
            public List<string> Args;
        }

        enum Commands { COLS, COUNT, COUNTEX, DELETE, REPLACE, REPLACEEX }
        enum Delimeter { Tab, Space, Comma }
        private char Delim { 
            get
            {
                switch ((Delimeter)ComboDelimeter.SelectedItem)
                {
                    case Delimeter.Tab:
                        return '\t';
                    case Delimeter.Space:
                        return ' ';
                    case Delimeter.Comma:
                        return ',';
                    default:
                        return ' ';
                }
            } 
        }
        private FileInfo FileInfo = null;
        private string Header = null;
        private string LastEntry = string.Empty;
        private List<string[]> Data = new List<string[]>();
        private List<bool> NumberColumn = new List<bool>();

        public DataFilter()
        {
            InitializeComponent();
            ComboDelimeter.DataSource = Enum.GetValues(typeof(Delimeter));
            RTB.KeyUp += RTB_KeyUp;
        }

        private void RTB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ProcessRTB();
            if (e.KeyCode == Keys.Up) PrintLastEntry();
        }

        private void PrintLastEntry()
        {
            RTB.Text = LastEntry;
        }

        private void ProcessRTB()
        {
            if (Data.Count == 0)
            {
                RTB.Text = "No data loaded";
                return;
            }              

            if (RTB.Text.Contains("Invalid"))
            {
                RTB.Text = "";
                return;
            }

            string[] commands = Enum.GetNames(typeof(Commands));
            string msg = RTB.Text.TrimEnd('\n');
            string[] cols = msg.Split(' ');
            
            List<CommandProcessor> commandProcessors = new List<CommandProcessor>();
            foreach (string col in cols)
            {
                if (commands.Contains(col))
                {
                    CommandProcessor commandProcessor = new CommandProcessor()
                    {
                        Command = (Commands)Enum.Parse(typeof(Commands), col),
                        Args = new List<string>()
                    };
                    commandProcessors.Add(commandProcessor);
                }
                else if (commandProcessors.Count > 0)
                    commandProcessors.Last().Args.Add(col);
            }

            if (commandProcessors.Count == 0)
                RTB.Text = "Invalid command";
            else
            {
                RTB.Text = string.Empty;
                LastEntry = msg;
            }    

            foreach (CommandProcessor cp in commandProcessors)
                ExecuteCommand(cp);
        }

        private void ExecuteCommand(CommandProcessor cp)
        {
            switch (cp.Command)
            {
                case Commands.COLS:
                    PrintCols();
                    break;
                case Commands.COUNT:
                case Commands.COUNTEX:
                    if (cp.Args.Count > 3 || (cp.Args.Count == 3 && cp.Args[1] != "IN") || cp.Args.Count == 2)
                        RTB.Text += "Invalid count command\n";
                    else
                        PrintCount(cp.Args.ToArray(), cp.Command == Commands.COUNTEX);
                    break;
                case Commands.DELETE:
                    break;
                case Commands.REPLACE:
                case Commands.REPLACEEX:
                    if ((cp.Args.Count == 4 && cp.Args[2] != "IN") || cp.Args.Count > 4)
                        RTB.Text += "Invalid replace command\n";
                    else
                        PrintReplace(cp.Args.ToArray(), cp.Command == Commands.COUNTEX);
                    break;
                default:
                    break;
            }
        }

        private void PrintReplace(string[] vals, bool exact)
        {
            try
            {
                int num = 0;
                if (vals.Length == 2)
                {
                    foreach (string[] row in Data)
                    {
                        for (int i = 0; i < row.Length; i++)
                        {
                            if (exact)
                            {
                                if (row[i] == vals[0])
                                {
                                    row[i] = vals[1];
                                    num++;
                                }
                            }
                            else
                            {
                                if (row[i].Contains(vals[0]))
                                {
                                    row[i] = row[i].Replace(vals[0], vals[1]);
                                    num++;
                                }
                            }
                        }
                    }
                    RTB.Text += $"{(exact ? "Exact r" : "R")}eplaced {num} intances of {vals[0]}\n";
                }
                else
                {
                    int colNum = int.Parse(vals[3]);
                    foreach (string[] row in Data)
                    {
                        if (row.Length - 1 < colNum) continue;
                        if (exact)
                        {
                            if (row[colNum] == vals[0])
                            {
                                row[colNum] = vals[1];
                                num++;
                            }
                        }
                        else
                        {
                            if (row[colNum].Contains(vals[0]))
                            {
                                row[colNum] = row[colNum].Replace(vals[0], vals[1]);
                                num++;
                            }
                        }
                    }
                    RTB.Text += $"{(exact ? "Exact r" : "R")}eplaced {num} intances of {vals[0]} in {vals[3]}\n";
                }
            }
            catch (Exception ex)
            {
                RTB.Text += $"Invalid replace command {ex}\n";
            }
        }

        private void PrintCols()
        {
            if (!string.IsNullOrEmpty(Header))
                RTB.Text = Header + "\n";
            RTB.Text += "ColIdx: ";
            for (int i = 0; i < NumberColumn.Count; i++)
                RTB.Text += $"{i}{Delim}";
            RTB.Text += "\nNumCol: ";
            foreach (bool item in NumberColumn)
                RTB.Text += $"{item}{Delim}";
            RTB.Text += "\n";
        }

        private void PrintCount(string[] vals, bool exact)
        {
            try
            {
                int num = 0;
                if (vals.Length == 1)
                {
                    foreach (string[] row in Data)
                        num += row.Where(x => exact ? x == vals[0] : x.Contains(vals[0])).Count();
                    RTB.Text += $"{(exact ? "Exact c" : "C")}ount of {vals[0]} = {num}\n";
                }
                else
                {
                    int colNum = int.Parse(vals[2]);
                    foreach (string[] row in Data)
                    {
                        if (row.Length - 1 < colNum) continue;
                        if (exact)
                            num += row[colNum] == vals[0] ? 1 : 0;
                        else
                            num += row[colNum].Contains(vals[0]) ? 1 : 0;
                    }
                    RTB.Text += $"{(exact ? "Exact c" : "C")}ount of {vals[0]} in {vals[2]} = {num}\n";
                }
            }
            catch (Exception ex)
            {
                RTB.Text += $"Invalid count command {ex}\n";
            }
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Select a file for filtering";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo = new FileInfo(openFileDialog.FileName);
                    InitFile();
                }    
            }
        }

        private void InitFile()
        {
            LblFile.Text = FileInfo.Name;
        }

        private void BtnLoadData_Click(object sender, EventArgs e)
        {
            if (FileInfo == null || !FileInfo.Exists) return;

            Data = new List<string[]>();
            NumberColumn = new List<bool>();

            string[] lines = File.ReadAllLines(FileInfo.FullName);
            int idx = 0;
            if (CbxHeaderRow.Checked)
            {
                Header = lines[0];
                idx = 1;
            }

            string firstLine = lines[idx];
            string[] cols = firstLine.Split(Delim);
            foreach (string col in cols)
                NumberColumn.Add(float.TryParse(col, out _));

            for (int i = idx; i < lines.Length; i++)
                if (!string.IsNullOrEmpty(lines[i])) Data.Add(lines[i].Split(Delim));

            LblData.Text = $"{Data.Count} Rows Loaded";
        }

        private string StringifyData()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(Header)) sb.AppendLine(Header);
            foreach (string[] row in Data)
                sb.AppendLine(string.Join(Delim.ToString(), row));
            return sb.ToString();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
           
            Clipboard.SetText(StringifyData());
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
