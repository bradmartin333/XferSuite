using System.Windows.Forms;

namespace XferSuite
{
    public partial class PromptForInput : Form
    {
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
            if (textEntry)
                Control = new TextBox() { TextAlign = HorizontalAlignment.Center };
            else
                Control = new NumericUpDown() { TextAlign = HorizontalAlignment.Center, Maximum = max };
            Control.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(Control, 1, 2);
        }

        private void btnContinue_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
