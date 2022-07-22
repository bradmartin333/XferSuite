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
            [Description("Swap AB Grid")]
            swapABGrid,
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
                    case AdvancedForm.dataFilter:
                        ShowToolWindow<DataFilter>();
                        break;
                    case AdvancedForm.stampSEYR:
                        ShowToolWindow<StampSEYR>();
                        break;
                    case AdvancedForm.mapFlip:
                        ShowToolWindow<MapFlip>();
                        break;
                    case AdvancedForm.tenZoneCal:
                        ShowToolWindow<CalGenerator>();
                        break;
                    case AdvancedForm.uTPlogParser:
                        ShowToolWindow<uTP.PrintLogParser>();
                        break;
                    case AdvancedForm.swapABGrid:
                        ShowToolWindow<SwapABGrid>();
                        break;
                    // Create a form in the AdvancedTools folder and add a case above this comment
                    // for the newly added enum field and copy the above examples to launch the new form
                    default:
                        MessageBox.Show("Invalid Selection", "XferSuite Advanced Tools");
                        return;
                }
                Close();
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

        private void ShowToolWindow<TWindow>() where TWindow : Form, new()
        {
            var openForm = Application.OpenForms.OfType<TWindow>().FirstOrDefault();
            if (openForm != null)
                openForm.BringToFront();
            else
            {
                Form tool = new TWindow();
                MainMenu.Settings.PropertyGrid.SelectedObject = tool;
                tool.Activated += Tool_Activated;
                tool.Show();
            }
            Close();
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
