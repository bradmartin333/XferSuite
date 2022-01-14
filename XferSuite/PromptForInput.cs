using System.Windows.Forms;

namespace XferSuite
{
    public partial class PromptForInput : Form
    {
        public Control Control { get; set; }

        /// <summary>
        /// Easy way to ask for quick info from user
        /// </summary>
        /// <param name="title"></param>
        /// <param name="prompt"></param>
        /// <param name="textEntry">
        /// True for a text based entry
        /// False for a num up down
        /// </param>
        public PromptForInput(string title, string prompt, bool textEntry)
        {
            InitializeComponent();
            Text = title;
            label.Text = prompt;
            if (textEntry)
                Control = new TextBox() { TextAlign = HorizontalAlignment.Center };
            else
                Control = new NumericUpDown() { TextAlign = HorizontalAlignment.Center };
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
