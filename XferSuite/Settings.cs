using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XferSuite
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            buttons = tableLayoutPanel.Controls.OfType<Button>();
        }

        public object[] controlsArr = new object[9];
        private IEnumerable<Button> buttons = new Button[9];

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idx = int.Parse(btn.Tag.ToString());
            propertyGrid.SelectedObject = controlsArr[idx];
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadButtons();
        }

        public void LoadButtons()
        {
            foreach (Button btn in buttons)
            {
                int idx = int.Parse(btn.Tag.ToString());
                btn.Visible = controlsArr[idx] != null;
                if (btn.Visible)
                {
                    btn.Visible = !(((Form)controlsArr[idx]).IsDisposed == true);
                }
            }
        }
    }
}
