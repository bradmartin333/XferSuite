﻿using System.Windows.Forms;

namespace XferSuite.Utility
{
    public partial class PromptForInput : Form
    {
        private readonly bool TextEntry;
        public Control Control { get; set; }

        /// <summary>
        /// Easy way to prompt user for text or numerical data
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="textEntry">
        /// True for a text based entry
        /// False for a num up down
        /// </param>
        /// <param name="title"></param>
        public PromptForInput(string prompt, bool textEntry = true, int max = 100, string title = "XferSuite")
        {
            InitializeComponent();
            Text = title;
            label.Text = prompt;
            TextEntry = textEntry;
            if (TextEntry)
                Control = new TextBox() { TextAlign = HorizontalAlignment.Center };
            else
                Control = new NumericUpDown() { TextAlign = HorizontalAlignment.Center, Maximum = max, DecimalPlaces = 3 };
            Control.Dock = DockStyle.Fill;
            Shown += PromptForInput_Shown;
            tableLayoutPanel.Controls.Add(Control, 1, 2);
        }

        private void PromptForInput_Shown(object sender, System.EventArgs e)
        {
            if (TextEntry)
                ((TextBox)Control).Focus();
            else
            {
                ((NumericUpDown)Control).Select();
                ((NumericUpDown)Control).Select(0, Control.Text.Length);
            }
        }

        private void BtnContinue_Click(object sender, System.EventArgs e)
        {
            Proceed();
        }

        private void Proceed()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
