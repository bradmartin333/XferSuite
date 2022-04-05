using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.Apps
{
    public partial class MapFlip : Form
    {
        private string _Delimeter = "";
        [Category("User Parameters")]
        public string Delimeter
        {
            get => _Delimeter;
            set
            {
                _Delimeter = value;
                InitInput();
            }
        }

        Panel[] _Panels = new Panel[4];
        Color[] _PnlColors = new Color[4];
        Color[] _PnlColorsInit = new Color[4];
        private string[][] _Input;

        public MapFlip()
        {
            InitializeComponent();
            _Panels = new Panel[] { pnlOutA, pnlOutB, pnlOutC, pnlOutD };
            getPanelColors(init: true);
            InitInput();
        }

        private void MapFlip_Activated(object sender, EventArgs e)
        {
            InitInput();
        }

        private void InitInput()
        {
            string clipText = Clipboard.GetText();

            if (_Delimeter == "")
            {
                DetermineDelimeter(clipText);
            }

            string[] clipLines = clipText.Split('\n');

            bool validArr = true;
            List<string[]> arrBuilder = new List<string[]>();
            foreach (string line in clipLines)
            {
                if (line.Trim() == "")
                {
                    continue;
                }
                string[] values = line.Trim().Split(_Delimeter.ToCharArray());
                arrBuilder.Add(values);
            }

            if (arrBuilder.Count == 0)
            {
                validArr = false;
            }

            if (validArr)
            {
                int checkLen = arrBuilder[0].Length;
                for (int i = 1; i < arrBuilder.Count; i++)
                {
                    if (arrBuilder[i].Length != checkLen)
                    {
                        validArr = false;
                    }
                }
                lblClip.Text = string.Format("Clipboard contains a {0} x {1} matrix", arrBuilder.Count, checkLen);
            }
            else
            {
                lblClip.Text = "Clipboard does not contain a valid m x n matrix";
            }

            _Input = arrBuilder.ToArray();
        }

        private void DetermineDelimeter(string clipText)
        {
            char[] delims = new char[] { ' ', ',', '\t', '|' };
            int[] count = new int[delims.Length];
            for (int i = 0; i < delims.Length; i++)
            {
                char[] arr = clipText.ToCharArray();
                foreach (char c in arr)
                {
                    if (c == delims[i])
                    {
                        count[i]++;
                    }
                }
            }
            _Delimeter = delims[count.ToList().IndexOf(count.Max())].ToString();
        }

        private void horizFlip()
        {
            UpdateColors(new int[] { 1, 0, 3, 2 });

            string output = "";
            for (int i = 0; i < _Input.Length; i++)
            {
                for (int j = _Input[0].Length - 1; j >= 0; j--)
                {
                    output += _Input[i][j];
                    if (j != 0)
                    {
                        output += _Delimeter;
                    }
                }
                if (i != _Input.Length - 1)
                {
                    output += '\n';
                }
            }
            Clipboard.SetText(output);

            InitInput();
        }

        private void vertFlip()
        {
            UpdateColors(new int[] { 2, 3, 0, 1 });

            string output = "";
            for (int i = _Input.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < _Input[0].Length; j++)
                {
                    output += _Input[i][j];
                    if (j != _Input[0].Length - 1)
                    {
                        output += _Delimeter;
                    }
                }
                if (i != 0)
                {
                    output += '\n';
                }
            }
            Clipboard.SetText(output);

            InitInput();
        }

        private void rotate()
        {
            UpdateColors(new int[] { 1, 3, 0, 2 });

            string output = "";
            for (int j = _Input[0].Length - 1; j >= 0; j--)
            {
                for (int i = 0; i < _Input.Length; i++)
                {
                    output += _Input[i][j];
                    if (i != _Input.Length - 1)
                    {
                        output += _Delimeter;
                    }
                }
                if (j != 0)
                {
                    output += '\n';
                }
            }
            Clipboard.SetText(output);

            InitInput();
        }

        private void UpdateColors(int[] vals)
        {
            getPanelColors();
            _Panels[0].BackColor = _PnlColors[vals[0]];
            _Panels[1].BackColor = _PnlColors[vals[1]];
            _Panels[2].BackColor = _PnlColors[vals[2]];
            _Panels[3].BackColor = _PnlColors[vals[3]];
        }

        private void btnClick(object sender, EventArgs e)
        {
            BackColor = Color.Firebrick;
            Refresh();

            Button button = (Button)sender;
            try
            {
                switch (button.Tag)
                {
                    case "0":
                        horizFlip();
                        break;
                    case "1":
                        vertFlip();
                        break;
                    case "2":
                        rotate();
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please check the clipboad contents", "Map Flip");
            }

            BackColor = Color.Silver;
        }

        private void getPanelColors(bool init = false)
        {
            for(int i = 0; i < 4; i++)
            {
                if (init)
                {
                    _PnlColorsInit[i] = _Panels[i].BackColor;
                }
                else
                {
                    _PnlColors[i] = _Panels[i].BackColor;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _Panels.Length; i++)
            {
                _Panels[i].BackColor = _PnlColorsInit[i];
            }
            _Delimeter = "";
            InitInput();
        }
    }
}
