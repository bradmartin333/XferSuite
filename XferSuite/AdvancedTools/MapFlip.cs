using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.AdvancedTools
{
    /// <summary>
    /// A silly, but sometimes handy app made long ago
    /// (Hence the shoddy code and lack of comments)
    /// </summary>
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

        private readonly Panel[] _Panels = new Panel[4];
        private readonly Color[] _PnlColors = new Color[4];
        private readonly Color[] _PnlColorsInit = new Color[4];
        private string[][] _Input;

        public MapFlip()
        {
            InitializeComponent();
            _Panels = new Panel[] { pnlOutA, pnlOutB, pnlOutC, pnlOutD };
            GetPanelColors(init: true);
            InitInput();
        }

        private void MapFlip_Activated(object sender, EventArgs e)
        {
            InitInput();
        }

        private void InitInput()
        {
            try
            {
                string[] clipLines = Clipboard.GetText().Split('\n');
                if (_Delimeter == "") DetectDelimiter(clipLines, new char[] { '\t', '|', ',', ':', ';' });

                bool validArr = true;
                List<string[]> arrBuilder = new List<string[]>();
                foreach (string line in clipLines)
                {
                    if (line.Trim() == "") continue;
                    string[] values = line.Trim().Split(_Delimeter.ToCharArray());
                    arrBuilder.Add(values);
                }

                if (arrBuilder.Count == 0) validArr = false;

                int checkLen = arrBuilder[0].Length;
                for (int i = 1; i < arrBuilder.Count; i++)
                    if (arrBuilder[i].Length != checkLen) validArr = false;

                if (validArr)
                    lblClip.Text = string.Format("Clipboard contains a {0} x {1} matrix", arrBuilder.Count, checkLen);
                else
                    lblClip.Text = "Clipboard does not contain a valid m x n matrix";

                _Input = arrBuilder.ToArray();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error initializing input:\n{ex.Message}", "Map Flip");
            }
        }

        /// <summary>
        /// Analyze the given lines of text and try to determine the correct delimiter used. If multiple
        /// candidate delimiters are found, the highest frequency delimiter will be returned.
        /// </summary>
        /// <param name="lines">Lines to inspect</param>
        /// <param name="delimiters">Delimiters to search for</param>
        /// <returns>The most probable delimiter by usage, or null if none found.</returns>
        /// https://stackoverflow.com/questions/761932/how-should-i-detect-which-delimiter-is-used-in-a-text-file
        private void DetectDelimiter(IEnumerable<string> lines, IEnumerable<char> delimiters)
        {
            Dictionary<char, int> delimFrequency = new Dictionary<char, int>();

            // Setup our frequency tracker for given delimiters
            delimiters.ToList().ForEach(
                curDelim => delimFrequency.Add(curDelim, 0));

            // Get a total sum of all occurrences of each delimiter in the given lines
            delimFrequency.ToList().ForEach(
                curDelim => delimFrequency[curDelim.Key] = lines.Sum(line => line.Count(p => p == curDelim.Key)));

            // Find delimiters that have a frequency evenly divisible by the number of lines
            // (correct & consistent usage) and order them by largest frequency
            var possibleDelimiters = delimFrequency
                              .Where(f => f.Value > 0 && f.Value % lines.Count() == 0)
                              .OrderByDescending(f => f.Value)
                              .ToList();

            // If more than one possible delimiter found, select the most used one
            if (possibleDelimiters.Any()) _Delimeter = possibleDelimiters.First().Key.ToString();
        }

        private void HorizFlip()
        {
            UpdateColors(new int[] { 1, 0, 3, 2 });

            string output = "";
            for (int i = 0; i < _Input.Length; i++)
            {
                for (int j = _Input[0].Length - 1; j >= 0; j--)
                {
                    output += _Input[i][j];
                    if (j != 0) output += _Delimeter;
                }
                if (i != _Input.Length - 1)
                    output += '\n';
            }
            Clipboard.SetText(output);

            InitInput();
        }

        private void VertFlip()
        {
            UpdateColors(new int[] { 2, 3, 0, 1 });

            string output = "";
            for (int i = _Input.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < _Input[0].Length; j++)
                {
                    output += _Input[i][j];
                    if (j != _Input[0].Length - 1) output += _Delimeter;
                }
                if (i != 0) output += '\n';
            }
            Clipboard.SetText(output);

            InitInput();
        }

        private void Rotate()
        {
            UpdateColors(new int[] { 1, 3, 0, 2 });

            string output = "";
            for (int j = _Input[0].Length - 1; j >= 0; j--)
            {
                for (int i = 0; i < _Input.Length; i++)
                {
                    output += _Input[i][j];
                    if (i != _Input.Length - 1) output += _Delimeter;
                }
                if (j != 0) output += '\n';
            }
            Clipboard.SetText(output);

            InitInput();
        }

        private void UpdateColors(int[] vals)
        {
            GetPanelColors();
            _Panels[0].BackColor = _PnlColors[vals[0]];
            _Panels[1].BackColor = _PnlColors[vals[1]];
            _Panels[2].BackColor = _PnlColors[vals[2]];
            _Panels[3].BackColor = _PnlColors[vals[3]];
        }

        private void BtnClick(object sender, EventArgs e)
        {
            BackColor = Color.Firebrick;
            Refresh();

            Button button = (Button)sender;
            try
            {
                switch (button.Tag)
                {
                    case "0":
                        HorizFlip();
                        break;
                    case "1":
                        VertFlip();
                        break;
                    case "2":
                        Rotate();
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please check the clipboad contents", "Map Flip");
            }

            BackColor = Color.Silver;
        }

        private void GetPanelColors(bool init = false)
        {
            for(int i = 0; i < 4; i++)
            {
                if (init)
                    _PnlColorsInit[i] = _Panels[i].BackColor;
                else
                    _PnlColors[i] = _Panels[i].BackColor;
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _Panels.Length; i++)
                _Panels[i].BackColor = _PnlColorsInit[i];
            _Delimeter = "";
            InitInput();
        }
    }
}
