using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XferSuite
{
    public partial class MapFlip : Form
    {
        List<Panel> Panels = new List<Panel>();
        Color[] PnlColors = new Color[4];
        List<int> Operations = new List<int>();
        private string[][] Input;
        private bool OperationsLoaded;

        private bool _WordWrapping;
        [Category("User Parameters")]
        public bool WordWrapping
        {
            get => _WordWrapping;
            set
            {
                _WordWrapping = value;
                rtbIn.WordWrap = _WordWrapping;
                rtbOut.WordWrap = _WordWrapping;
            }
        }

        private float _Zoom;
        [Category("User Parameters")]
        public float Zoom
        {
            get => _Zoom;
            set
            {
                _Zoom = value;
                rtbIn.ZoomFactor = _Zoom;
                rtbOut.ZoomFactor = _Zoom;
            }
        }

        public MapFlip()
        {
            InitializeComponent();

            foreach (Panel p in tableLayoutPanel2.Controls.OfType<Panel>())
            {
                if (!p.Name.Contains("Out"))
                {
                    continue;
                }
                Panels.Add(p);
            }

            if (File.Exists("last.txt"))
            {
                LoadOperations();
                Operate(true);
            }

            OperationsLoaded = true;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            rtbOut.Text = "";
            TSV_ToArray(rtbIn.Text);
            Operate(false);
            PrintOutput();
            SaveOperations();
        }

        private void TSV_ToArray(string TSV)
        {
            List<string[]> temp = new List<string[]>();

            string[] lines = TSV.Split('\n');

            foreach (string line in lines)
            {
                string[] values = line.Split("\t".ToCharArray());
                temp.Add(values);
            }

            Input = temp.ToArray();
        }

        private void Operate(bool colors)
        {
            foreach (int i in Operations)
            {
                switch (i)
                {
                    case 0:
                        horizFlip(colors);
                        break;
                    case 1:
                        vertFlip(colors);
                        break;
                    case 2:
                        rotate(colors);
                        break;
                }
            }
        }

        private void PrintOutput()
        {
            for (int i = 0; i < Input.Length - 1; i++)
            {
                for (int j = 0; j < Input[0].Length; j++)
                {
                    rtbOut.Text += Input[i][j] + "\t";
                }
                rtbOut.Text += "\n";
            }
        }

        private void horizFlip(bool colors)
        {
            if (colors)
            {
                getPanelColors();
                Panels[0].BackColor = PnlColors[1];
                Panels[1].BackColor = PnlColors[0];
                Panels[2].BackColor = PnlColors[3];
                Panels[3].BackColor = PnlColors[2];
                if (OperationsLoaded)
                {
                    Operations.Add(0);
                }
            }
            else
            {
                List<string[]> Output = new List<string[]>();
                for (int i = 0; i < Input.Length - 1; i++)
                {
                    List<string> temp = new List<string>();
                    for (int j = Input[0].Length - 1; j >= 0; j--)
                    {
                        temp.Add(Input[i][j]);
                    }
                    Output.Add(temp.ToArray());
                }
                finishOperation(Output);
            }
        }

        private void vertFlip(bool colors)
        {
            if (colors)
            {
                getPanelColors();
                Panels[0].BackColor = PnlColors[2];
                Panels[1].BackColor = PnlColors[3];
                Panels[2].BackColor = PnlColors[0];
                Panels[3].BackColor = PnlColors[1];
                if (OperationsLoaded)
                {
                    Operations.Add(1);
                }
            }
            else
            {
                List<string[]> Output = new List<string[]>();
                for (int i = Input.Length - 2; i >= 0; i--)
                {
                    List<string> temp = new List<string>();
                    for (int j = 0; j < Input[0].Length; j++)
                    {
                        temp.Add(Input[i][j]);
                    }
                    Output.Add(temp.ToArray());
                }
                finishOperation(Output);
            }
        }

        private void rotate(bool colors)
        {
            if (colors)
            {
                getPanelColors();
                Panels[0].BackColor = PnlColors[1];
                Panels[1].BackColor = PnlColors[3];
                Panels[2].BackColor = PnlColors[0];
                Panels[3].BackColor = PnlColors[2];
                if (OperationsLoaded)
                {
                    Operations.Add(2);
                }
            }
            else
            {
                List<string[]> Output = new List<string[]>();
                for (int j = Input[0].Length - 1; j >= 0; j--)
                {
                    List<string> temp = new List<string>();
                    for (int i = 0; i < Input.Length - 1; i++)
                    {
                        temp.Add(Input[i][j]);
                    }
                    Output.Add(temp.ToArray());
                }
                finishOperation(Output);
            }
        }

        private void finishOperation(List<string[]> Output)
        {
            string[] newLine = { "\n" };
            Output.Add(newLine);
            Input = Output.ToArray();
        }

        private void btnHorizFlip_Click(object sender, EventArgs e)
        {
            horizFlip(true);
        }

        private void btnVertFlip_Click(object sender, EventArgs e)
        {
            vertFlip(true);
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            rotate(true);
        }

        private void getPanelColors()
        {
            for(int i = 0; i < 4; i++)
            {
                PnlColors[i] = Panels[i].BackColor;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Panels[0].BackColor = Color.Red;
            Panels[1].BackColor = Color.Green;
            Panels[2].BackColor = Color.Blue;
            Panels[3].BackColor = Color.Yellow;
            Operations.Clear();
            File.Delete("last.txt");
            rtbOut.Text = "";
        }

        private void LoadOperations()
        {
            string text = File.ReadAllText("last.txt");
            foreach (char i in text)
            {
                Operations.Add(int.Parse(char.ToString(i)));
            }
        }

        private void SaveOperations()
        {
            string text = "";
            foreach (int i in Operations)
            {
                text += i.ToString();
            }
            File.WriteAllText("last.txt", text);
        }
    }
}
