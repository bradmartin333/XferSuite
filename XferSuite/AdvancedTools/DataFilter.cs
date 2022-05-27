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

        enum Commands { 
            COLS, 
            COUNT, COUNTEX, 
            DELETE, DELETEEX, 
            REPLACE, REPLACEEX, 
            IF, IFEX,
            NOT, NOTEX,
            EVAL, OPER
        }
        enum Delimeter { Tab, Space, Comma, Semicolon }
        enum Evaluators { GR, LS, GREQ, LSEQ, EQ, NEQ }
        enum Operators { ADD, SUB, MUL, DIV, MOD, POW, RND }
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
                    case Delimeter.Semicolon:
                        return ';';
                    default:
                        return ' ';
                }
            } 
        }
        private FileInfo FileInfo = null;
        private string Header = null;
        private string LastEntry = string.Empty;
        private List<(int, string[])> Data = new List<(int, string[])>();
        private List<(int, string[])> DataRemainder = new List<(int, string[])>();
        private List<(int, string[])> DataSubset = new List<(int, string[])>();
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
            else if (e.KeyCode == Keys.Up) PrintLastEntry();
            else if (e.KeyCode == Keys.Down) RTB.Text = "";
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
            string msg = RTB.Text.Replace("\n", "");
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

            DataRemainder.Clear();
            DataSubset.Clear();
            Data = Data.OrderBy(x => x.Item1).ToList();
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
                case Commands.DELETEEX:
                    if (cp.Args.Count > 3 || (cp.Args.Count == 3 && cp.Args[1] != "IN") || cp.Args.Count == 2)
                        RTB.Text += "Invalid delete command\n";
                    else
                        PrintDelete(cp.Args.ToArray(), cp.Command == Commands.DELETEEX);
                    break;
                case Commands.REPLACE:
                case Commands.REPLACEEX:
                    if (cp.Args.Count < 2 || (cp.Args.Count == 4 && cp.Args[2] != "IN") || cp.Args.Count > 4)
                        RTB.Text += "Invalid replace command\n";
                    else
                        PrintReplace(cp.Args.ToArray(), cp.Command == Commands.COUNTEX);
                    break;
                case Commands.IF:
                case Commands.IFEX:
                case Commands.NOT:
                case Commands.NOTEX:
                    if (cp.Args.Count > 3 || (cp.Args.Count == 3 && cp.Args[1] != "IN") || cp.Args.Count == 2 || cp.Args.Count == 0)
                        RTB.Text += "Invalid if command\n";
                    else
                        EvaluateIf(cp.Args.ToArray(), cp.Command);
                    break;
                case Commands.EVAL:
                    int EcolNum;
                    Evaluators Eenum;
                    float Ecrit;
                    if (!int.TryParse(cp.Args[0], out EcolNum))
                        RTB.Text += "Invalid eval command (Bad column number)\n";
                    else if (!Enum.TryParse(cp.Args[1], out Eenum))
                        RTB.Text += $"Invalid eval command (Valid keys are {string.Join(", ", Enum.GetNames(typeof(Evaluators)))})\n";
                    else if (!float.TryParse(cp.Args[2], out Ecrit))
                        RTB.Text += "Invalid eval command (Bad criteria)\n";
                    else if (!NumberColumn[EcolNum])
                        RTB.Text += "Selected eval column is not a number column\n";
                    else
                        EvaluateEval(EcolNum, Eenum, Ecrit);
                    break;
                case Commands.OPER:
                    int OcolNum;
                    Operators Oenum;
                    float Ocrit;
                    if (!int.TryParse(cp.Args[0], out OcolNum))
                        RTB.Text += "Invalid oper command (Bad column number)\n";
                    else if (!Enum.TryParse(cp.Args[1], out Oenum))
                        RTB.Text += $"Invalid oper command (Valid keys are {string.Join(", ", Enum.GetNames(typeof(Operators)))})\n";
                    else if (!float.TryParse(cp.Args[2], out Ocrit))
                        RTB.Text += "Invalid oper command (Bad criteria)\n";
                    else if (!NumberColumn[OcolNum])
                        RTB.Text += "Selected oper column is not a number column\n";
                    else
                        EvaluateOper(OcolNum, Oenum, Ocrit);
                    break;
                default:
                    break;
            }
            LblData.Text = $"{Data.Count} Rows Loaded";
        }

        #region Commands

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
            List<(int, string[])> data = DataSubset.Count == 0 ? Data : DataSubset;
            try
            {
                int num = 0;
                if (vals.Length == 0)
                    RTB.Text += $"Count = {data.Count}\n";
                else if (vals.Length == 1)
                {
                    foreach ((int, string[]) row in data)
                        num += row.Item2.Where(x => exact ? x == vals[0] : x.Contains(vals[0])).Count();
                    RTB.Text += $"{(exact ? "Exact c" : "C")}ount of {vals[0]} = {num}\n";
                }
                else
                {
                    int colNum = int.Parse(vals[2]);
                    foreach ((int, string[]) row in data)
                    {
                        if (row.Item2.Length - 1 < colNum) continue;
                        if (exact)
                            num += row.Item2[colNum] == vals[0] ? 1 : 0;
                        else
                            num += row.Item2[colNum].Contains(vals[0]) ? 1 : 0;
                    }
                    RTB.Text += $"{(exact ? "Exact c" : "C")}ount of {vals[0]} in {vals[2]} = {num}\n";
                }
            }
            catch (Exception ex)
            {
                RTB.Text += $"Invalid count command {ex}\n";
            }
        }

        private void PrintDelete(string[] vals, bool exact)
        {
            List<(int, string[])> data = DataSubset.Count == 0 ? new List<(int, string[])>(Data) : DataSubset;
            try
            {
                List<(int, string[])> newData = new List<(int, string[])>();
                if (vals.Length == 0)
                {
                    RTB.Text += $"Deleted {data.Count} rows\n";
                    data.Clear();
                }
                else
                {
                    if (vals.Length == 1)
                    {
                        foreach ((int, string[]) row in data)
                            if (!row.Item2.Where(x => exact ? x == vals[0] : x.Contains(vals[0])).Any()) newData.Add(row);
                    }
                    else
                    {
                        int colNum = int.Parse(vals[2]);
                        foreach ((int, string[]) row in data)
                        {
                            bool match = false;
                            if (row.Item2.Length - 1 < colNum)
                            {
                                newData.Add(row);
                                continue;
                            }
                            if (exact)
                                match = row.Item2[colNum] == vals[0];
                            else
                                match = row.Item2[colNum].Contains(vals[0]);
                            if (!match) newData.Add(row);
                        }
                    }
                    RTB.Text += $"{(exact ? "Exact d" : "D")}eleted {Data.Count - newData.Count} rows\n";
                }

                if (DataSubset.Count == 0)
                {
                    Data.Clear();
                    Data.AddRange(DataRemainder);
                    Data.AddRange(newData);
                    DataRemainder.Clear();
                    DataSubset.Clear();
                }
                else
                    Data = newData;
            }
            catch (Exception ex)
            {
                RTB.Text += $"Invalid delete command {ex}\n";
            }
        }

        private void PrintReplace(string[] vals, bool exact)
        {
            List<(int, string[])> data = DataSubset.Count == 0 ? new List<(int, string[])>(Data) : DataSubset;
            try
            {
                string rep = string.Empty;
                if (vals[1] != "NULL") rep = vals[1];

                int num = 0;
                if (vals.Length == 2)
                {
                    foreach ((int, string[]) row in data)
                    {
                        for (int i = 0; i < row.Item2.Length; i++)
                        {
                            if (exact)
                            {
                                if (row.Item2[i] == vals[0])
                                {
                                    row.Item2[i] = rep;
                                    num++;
                                }
                            }
                            else
                            {
                                if (row.Item2[i].Contains(vals[0]))
                                {
                                    row.Item2[i] = row.Item2[i].Replace(vals[0], rep);
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
                    foreach ((int, string[]) row in data)
                    {
                        if (row.Item2.Length - 1 < colNum) continue;
                        if (exact)
                        {
                            if (row.Item2[colNum] == vals[0])
                            {
                                row.Item2[colNum] = rep;
                                num++;
                            }
                        }
                        else
                        {
                            if (row.Item2[colNum].Contains(vals[0]))
                            {
                                row.Item2[colNum] = row.Item2[colNum].Replace(vals[0], rep);
                                num++;
                            }
                        }
                    }
                    RTB.Text += $"{(exact ? "Exact r" : "R")}eplaced {num} intances of {vals[0]} in {vals[3]}\n";
                }

                if (DataSubset.Count == 0)
                {
                    Data.Clear();
                    Data.AddRange(DataRemainder);
                    Data.AddRange(data);
                    DataRemainder.Clear();
                    DataSubset.Clear();
                }
            }
            catch (Exception ex)
            {
                RTB.Text += $"Invalid replace command {ex}\n";
            }
        }

        private void EvaluateIf(string[] vals, Commands command)
        {
            List<(int, string[])> data = DataSubset.Count == 0 ? Data : DataSubset;
            List<(int, string[])> thisRemainder = new List<(int, string[])>();
            List<(int, string[])> thisSubset = new List<(int, string[])>();

            try
            {
                if (vals.Length == 1)
                {
                    foreach ((int, string[]) row in data)
                    {
                        switch (command)
                        {
                            case Commands.IF:
                            case Commands.NOT:
                                if (row.Item2.Where(x => x.Contains(vals[0])).Count() > 0 && command == Commands.IF)
                                    thisSubset.Add(row);
                                else if (row.Item2.Where(x => x.Contains(vals[0])).Count() == 0 && command == Commands.NOT)
                                    thisSubset.Add(row);
                                else
                                    thisRemainder.Add(row);
                                break;
                            case Commands.IFEX:
                            case Commands.NOTEX:
                                if (row.Item2.Where(x => x == vals[0]).Count() > 0 && command == Commands.IFEX)
                                    thisSubset.Add(row);
                                else if (row.Item2.Where(x => x == vals[0]).Count() == 0 && command == Commands.NOTEX)
                                    thisSubset.Add(row);
                                else
                                    thisRemainder.Add(row);
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    int colNum = int.Parse(vals[2]);
                    foreach ((int, string[]) row in data)
                    {
                        switch (command)
                        {
                            case Commands.IF:
                            case Commands.NOT:
                                if (row.Item2[colNum].Contains(vals[0]) && command == Commands.IF)
                                    thisSubset.Add(row);
                                else if (!row.Item2[colNum].Contains(vals[0]) && command == Commands.NOT)
                                    thisSubset.Add(row);
                                else
                                    thisRemainder.Add(row);
                                break;
                            case Commands.IFEX:
                            case Commands.NOTEX:
                                if (row.Item2[colNum] == vals[0] && command == Commands.IFEX)
                                    thisSubset.Add(row);
                                else if (row.Item2[colNum] != vals[0] && command == Commands.NOTEX)
                                    thisSubset.Add(row);
                                else
                                    thisRemainder.Add(row);
                                break;
                            default:
                                break;
                        }
                    }
                }

                DataRemainder.AddRange(thisRemainder);
                DataSubset = thisSubset;
            }
            catch (Exception ex)
            {
                RTB.Text += $"Invalid if command {ex}\n";
            }
        }

        private void EvaluateEval(int colNum, Evaluators c, float crit)
        {
            List<(int, string[])> data = DataSubset.Count == 0 ? Data : DataSubset;
            List<(int, string[])> thisRemainder = new List<(int, string[])>();
            List<(int, string[])> thisSubset = new List<(int, string[])>();

            try
            {
                foreach ((int, string[]) row in data)
                {
                    if (!float.TryParse(row.Item2[colNum], out float val)) thisRemainder.Add(row);
                    switch (c)
                    {
                        case Evaluators.GR:
                            if (val > crit)
                                thisSubset.Add(row);
                            else
                                thisRemainder.Add(row);
                            break;
                        case Evaluators.LS:
                            if (val < crit)
                                thisSubset.Add(row);
                            else
                                thisRemainder.Add(row);
                            break;
                        case Evaluators.GREQ:
                            if (val >= crit)
                                thisSubset.Add(row);
                            else
                                thisRemainder.Add(row);
                            break;
                        case Evaluators.LSEQ:
                            if (val <= crit)
                                thisSubset.Add(row);
                            else
                                thisRemainder.Add(row);
                            break;
                        case Evaluators.EQ:
                            if (val == crit)
                                thisSubset.Add(row);
                            else
                                thisRemainder.Add(row);
                            break;
                        case Evaluators.NEQ:
                            if (val != crit)
                                thisSubset.Add(row);
                            else
                                thisRemainder.Add(row);
                            break;
                        default:
                            thisRemainder.Add(row);
                            break;
                    }
                }

                DataRemainder.AddRange(thisRemainder);
                DataSubset = thisSubset;
            }
            catch (Exception ex)
            {
                RTB.Text += $"Invalid eval command {ex}\n";
            }
        }

        private void EvaluateOper(int colNum, Operators c, float crit)
        {
            List<(int, string[])> data = DataSubset.Count == 0 ? Data : DataSubset;
            try
            {
                foreach ((int, string[]) row in data)
                {
                    if (!float.TryParse(row.Item2[colNum], out float val)) continue;
                    switch (c)
                    {
                        case Operators.ADD:
                            row.Item2[colNum] = (val + crit).ToString();
                            break;
                        case Operators.SUB:
                            row.Item2[colNum] = (val - crit).ToString();
                            break;
                        case Operators.MUL:
                            row.Item2[colNum] = (val * crit).ToString();
                            break;
                        case Operators.DIV:
                            row.Item2[colNum] = (val / crit).ToString();
                            break;
                        case Operators.MOD:
                            row.Item2[colNum] = (val % crit).ToString();
                            break;
                        case Operators.POW:
                            row.Item2[colNum] = (Math.Pow(val, crit)).ToString();
                            break;
                        case Operators.RND:
                            row.Item2[colNum] = (Math.Round(val, (int)crit)).ToString();
                            break;
                        default:
                            break;
                    }
                }

                Data.Clear();
                Data.AddRange(DataRemainder);
                Data.AddRange(data);
                DataRemainder.Clear();
                DataSubset.Clear();
                RTB.Text += $"Oper command complete\n";
            }
            catch (Exception ex)
            {
                RTB.Text += $"Invalid oper command {ex}\n";
            }
        }

        #endregion

        #region Input and Output

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

            Header = null;
            Data = new List<(int, string[])>();
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
                if (!string.IsNullOrEmpty(lines[i])) Data.Add((i, lines[i].Split(Delim)));

            LblData.Text = $"{Data.Count} Rows Loaded";
        }

        private string StringifyData()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(Header)) sb.AppendLine(Header);
            foreach ((int, string[]) row in Data)
                sb.AppendLine(string.Join(Delim.ToString(), row.Item2));
            return sb.ToString();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(StringifyData());
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Save filtered file";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(saveFileDialog.FileName, StringifyData());
            }
        }

        #endregion
    }
}
