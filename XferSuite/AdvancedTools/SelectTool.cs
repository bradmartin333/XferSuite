using System;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.AdvancedTools
{
    public partial class SelectTool : Form
    {
        enum AdvancedForm
        {
            TenZoneCal,
            uTPlogParser,
        }

        public SelectTool()
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
                    case AdvancedForm.TenZoneCal:
                        if (Application.OpenForms.OfType<CalGenerator>().Any())
                            Application.OpenForms.OfType<CalGenerator>().First().BringToFront();
                        else
                            _ = new CalGenerator();
                        Close();
                        break;
                    case AdvancedForm.uTPlogParser:
                        if (Application.OpenForms.OfType<PrintLogParser>().Any())
                            Application.OpenForms.OfType<PrintLogParser>().First().BringToFront();
                        else
                            _ = new PrintLogParser();
                        Close();
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
