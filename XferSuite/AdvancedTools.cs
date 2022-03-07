using System;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite
{
    public partial class AdvancedTools : Form
    {
        enum AdvancedForm
        {
            TenZone2Dcal,
            uTPlogParser,
            roux,
            CamNetRefresh,
        }

        public AdvancedTools()
        {
            InitializeComponent();
            Show();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                AdvancedForm form = (AdvancedForm)ListBox.SelectedIndices[0];
                switch (form)
                {
                    case AdvancedForm.TenZone2Dcal:
                        if (Application.OpenForms.OfType<CalGenerator>().Any())
                            Application.OpenForms.OfType<CalGenerator>().First().BringToFront();
                        else
                            _ = new CalGenerator();
                        Close();
                        break;
                    case AdvancedForm.uTPlogParser:
                        MessageBox.Show("Coming soon!", "XferSuite Advanced Tools");
                        break;
                    case AdvancedForm.roux:
                        MessageBox.Show("Coming soon!", "XferSuite Advanced Tools");
                        break;
                    case AdvancedForm.CamNetRefresh:
                        MessageBox.Show("Coming soon!", "XferSuite Advanced Tools");
                        break;
                    default:
                        MessageBox.Show("Invalid Selection", "XferSuite Advanced Tools");
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Selection", "XferSuite Advanced Tools");
            }
        }
    }
}
