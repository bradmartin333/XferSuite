using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.AdvancedTools
{
    public partial class SelectTool : Form
    {
        // Add enum for form as well as a human readable decription
        enum AdvancedForm
        {
            [Description("10Zone Cal Generator")]
            TenZoneCal,
            [Description("uTP Log Parser")]
            uTPlogParser,
        }

        public SelectTool()
        {
            InitializeComponent();
            ListBox.Items.AddRange(GetDescriptions(typeof(AdvancedForm)));
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
                    // Create a form in the AdvancedTools folder and add a case above this comment
                    // for the newly added enum field and copy the above examples to launch the new form
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

        /// <summary>
        /// Generate a list of descriptions from an enum to
        /// be added to a list box control
        /// </summary>
        /// <param name="type">
        /// Send typeof(MyEnum)
        /// </param>
        /// <returns>
        /// An ordered list of descriptions
        /// </returns>
        private static object[] GetDescriptions(Type type)
        {
            List<object> descs = new List<object>();
            var names = Enum.GetNames(type);
            foreach (var name in names)
            {
                var field = type.GetField(name);
                var fds = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                foreach (DescriptionAttribute fd in fds)
                    descs.Add(fd.Description);
            }
            return descs.ToArray();
        }
    }
}
