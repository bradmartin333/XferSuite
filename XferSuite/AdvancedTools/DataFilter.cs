using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace XferSuite.AdvancedTools
{
    public partial class DataFilter : Form
    {
        struct CommandProcessor
        {
            public Commands Command;
            public List<string> Args;
        }

        enum Commands { COLS, COUNT, DELETE, REPLACE }
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
        }

        private void ProcessRTB()
        {
            if (Data.Count == 0)
            {
                RTB.Text = "No data loaded";
                return;
            }              
            
            string[] commands = Enum.GetNames(typeof(Commands));
            string[] cols = RTB.Text.TrimEnd('\n').Split(' ');
            
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
            
            RTB.Text = commandProcessors.Count == 0 ? "Invalid command" : string.Empty;
            
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
                    break;
                case Commands.DELETE:
                    break;
                case Commands.REPLACE:
                    break;
                default:
                    break;
            }
        }

        private void PrintCols()
        {
            if (!string.IsNullOrEmpty(Header))
                RTB.Text = Header + "\n";
            RTB.Text += "NUMCOL: ";
            foreach (bool item in NumberColumn)
                RTB.Text += $"{item}{Delim}";
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
                Data.Add(lines[i].Split(Delim));

            LblData.Text = $"{Data.Count} Rows Loaded";
        }
    }
}
