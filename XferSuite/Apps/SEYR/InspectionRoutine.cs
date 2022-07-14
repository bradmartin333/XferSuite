using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class InspectionRoutine : Form
    {
        private readonly string ID;
        private readonly DataEntry[] Entries;
        private readonly string[] DataRows;
        private int DataIndex = -1;

        public InspectionRoutine(DataSheet sheet, List<string> names)
        {
            InitializeComponent();
            ID = sheet.ID.ToString();
            Entries = sheet.GetEntries();
            DataRows = sheet.GetDataRows(names, true).Split('\n').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            Next();
            Show();
        }

        private void BtnPrevious_Click(object sender, System.EventArgs e)
        {
            Previous();
        }

        private void BtnNext_Click(object sender, System.EventArgs e)
        {
            Next();
        }

        private void Previous()
        {
            if (DataIndex == 0) return;
            DataIndex--;
            ShowData();
        }

        private void Next()
        {
            if (DataIndex > DataRows.Length - 2) return;
            DataIndex++;
            ShowData();
        }

        private void ShowData()
        {
            int imgNum = int.Parse(DataRows[DataIndex].Split(',')[0]);
            (int, int) thisTile = (int.Parse(DataRows[DataIndex].Split(',')[9]), int.Parse(DataRows[DataIndex].Split(',')[10]));
            DataEntry[] matches = Entries.Where(x => x.ImageNumber == imgNum && (x.TR, x.TC) == thisTile && x.Image != null).ToArray();
            if (matches.Count() > 1)
            {
                DataEntry[] specificImage = matches.Where(x => x.FeatureName.ToLower().Contains("img")).ToArray();
                if (specificImage.Length == 1) matches = specificImage;
            }
            if (matches.Length == 1)
            {
                DataEntry entry = matches.First();
                PBX.BackgroundImage = entry.Image;
                Text = $"Inspecting fail {DataIndex + 1} of {DataRows.Length} in region {ID}";
            }
        }

        private void BtnCopy_Click(object sender, System.EventArgs e)
        {

        }
    }
}
