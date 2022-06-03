using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.AdvancedTools
{
    /// <summary>
    /// Landing page to open Advanced Tools
    /// </summary>
    public partial class SelectTool : Form
    {
        // Add enum for form as well as a human readable decription
        enum AdvancedForm
        {
            [Description("Data Filtering")]
            dataFilter,
            [Description("Stamp SEYR Parser")]
            stampSEYR,
            [Description("Map Flip")]
            mapFlip,
            [Description("10Zone Cal Generator")]
            tenZoneCal,
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
                Form tool = new Form();
                switch (form)
                {
                    case AdvancedForm.dataFilter:
                        if (Application.OpenForms.OfType<DataFilter>().Any())
                            Application.OpenForms.OfType<DataFilter>().First().BringToFront();
                        else
                            tool = new DataFilter();
                        Close();
                        break;
                    case AdvancedForm.stampSEYR:
                        if (Application.OpenForms.OfType<StampSEYR>().Any())
                            Application.OpenForms.OfType<StampSEYR>().First().BringToFront();
                        else
                            tool = new StampSEYR();
                        Close();
                        break;
                    case AdvancedForm.mapFlip:
                        if (Application.OpenForms.OfType<MapFlip>().Any())
                            Application.OpenForms.OfType<MapFlip>().First().BringToFront();
                        else
                            tool = new MapFlip();
                        Close();
                        break;
                    case AdvancedForm.tenZoneCal:
                        if (Application.OpenForms.OfType<CalGenerator>().Any())
                            Application.OpenForms.OfType<CalGenerator>().First().BringToFront();
                        else
                            tool = new CalGenerator();
                        Close();
                        break;
                    case AdvancedForm.uTPlogParser:
                        if (Application.OpenForms.OfType<uTP.PrintLogParser>().Any())
                            Application.OpenForms.OfType<uTP.PrintLogParser>().First().BringToFront();
                        else
                            tool = new uTP.PrintLogParser();
                        Close();
                        break;
                    // Create a form in the AdvancedTools folder and add a case above this comment
                    // for the newly added enum field and copy the above examples to launch the new form
                    default:
                        MessageBox.Show("Invalid Selection", "XferSuite Advanced Tools");
                        return;
                }
                tool.Activated += Tool_Activated;
                tool.Show();
                MainMenu.Settings.PropertyGrid.SelectedObject = form;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Selection", "XferSuite Advanced Tools");
            }
        }

        private void Tool_Activated(object sender, EventArgs e)
        {
            if (!MainMenu.Settings.IsDisposed) // Prevents error on app close
                MainMenu.Settings.PropertyGrid.SelectedObject = sender;
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
