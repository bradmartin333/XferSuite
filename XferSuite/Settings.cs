using System.ComponentModel;
using System.Windows.Forms;

namespace XferSuite
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            propertyGrid.BrowsableAttributes = new AttributeCollection(new CategoryAttribute("User Parameters"));
        }
    }
}
