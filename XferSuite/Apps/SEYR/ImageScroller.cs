using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public partial class ImageScroller : Form
    {
        public static string LastSelectedFeatureName = string.Empty;

        private readonly IEnumerable<IGrouping<string, DataEntry>> ImageGroups;
        private readonly string BaseFeatureName;
        private readonly int NumberImagesInScroller;
        private readonly double Score;

        private int IDX = 0;
        private Bitmap[] Bitmaps;
        private string[] Info;

        public ImageScroller(IEnumerable<IGrouping<string, DataEntry>> imageGroups, string name, string baseFeatureName, int numberImagesInScroller, double score)
        {
            InitializeComponent();
            ImageGroups = imageGroups;
            BaseFeatureName = baseFeatureName;
            NumberImagesInScroller = numberImagesInScroller;
            Score = score;

            ComboFeatureSelector.Items.AddRange(ImageGroups.Select(x => x.Key).ToArray());
            if (ComboFeatureSelector.Items.Contains(LastSelectedFeatureName))
                ComboFeatureSelector.Text = LastSelectedFeatureName;
            else
                ComboFeatureSelector.Text = name;
            LoadFeatureData();

            Location = Point.Empty;
            PBX.MouseUp += PBX_MouseUp;
            Timer.Start();
            Show();
            BringToFront();
        }

        private void PBX_MouseUp(object sender, MouseEventArgs e)
        {
            Timer.Enabled = !Timer.Enabled;
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            if (Bitmaps.Any() && Info.Any())
            {
                PBX.BackgroundImage = Bitmaps[IDX];
                LblInfo.Text = Info[IDX];
                IDX++;
                if (IDX > Bitmaps.Length - 1) IDX = 0;
            }
        }

        private void ComboFeatureSelector_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!Timer.Enabled) return;
            Timer.Stop();
            LastSelectedFeatureName = ComboFeatureSelector.Text;
            LoadFeatureData();
            Timer.Start();
        }

        private void LoadFeatureData()
        {
            IEnumerable<IGrouping<string, DataEntry>> group = ImageGroups.Where(x => x.Key == ComboFeatureSelector.Text);
            if (!group.Any()) return;
            IEnumerable<DataEntry> data = group.First().Take(NumberImagesInScroller);
            Bitmaps = data.Select(x => x.Image).ToArray();
            Info = data.Select(x => x.Location()).ToArray();
            Text = $"First {Bitmaps.Length} images with \"{BaseFeatureName}\" score = {Score}";
            IDX = 0;
        }
    }
}
