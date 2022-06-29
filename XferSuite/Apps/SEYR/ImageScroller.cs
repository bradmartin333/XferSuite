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
        private readonly bool DrawFeatures;
        private readonly float PenSize;
        private readonly Rectangle FeatureRectangle;

        private int IDX = 0;
        private Bitmap[] Bitmaps;
        private string[] Info;

        public ImageScroller(IEnumerable<IGrouping<string, DataEntry>> imageGroups, string name, Feature feature, int numberImagesInScroller, double score, float penSize, bool drawFeatures)
        {
            InitializeComponent();
            ImageGroups = imageGroups;
            BaseFeatureName = feature.Name;
            NumberImagesInScroller = numberImagesInScroller;
            Score = score;
            DrawFeatures = drawFeatures;
            PenSize = penSize;
            
            if (DrawFeatures)
            {
                Rectangle thisFeatureRect = feature.GetGeometry();
                Rectangle imgFeatureRext = imageGroups.First().ToArray().First().Feature.GetGeometry();
                FeatureRectangle = new Rectangle(thisFeatureRect.X - imgFeatureRext.X, thisFeatureRect.Y - imgFeatureRext.Y,
                    thisFeatureRect.Width, thisFeatureRect.Height);
            }

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
                Bitmap bitmap = Bitmaps[IDX];
                if (DrawFeatures)
                    using (Graphics g = Graphics.FromImage(bitmap))
                        g.DrawRectangle(new Pen(Brushes.HotPink, PenSize), FeatureRectangle);
                PBX.BackgroundImage = bitmap;
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
            var g = group.First();
            int len = g.ToArray().Length;
            IEnumerable<DataEntry> data;
            if (len <= NumberImagesInScroller)
                data = group.First().Take(NumberImagesInScroller);
            else
            {
                int interval = (int)(len / (double)(NumberImagesInScroller - 1));
                data = g.Where((x, i) => i % interval == 0);
            }
            Bitmaps = data.Select(x => x.Image).ToArray();
            Info = data.Select(x => x.Location()).ToArray();
            Text = $"{Bitmaps.Length} images with \"{BaseFeatureName}\" score = {Score}";
            IDX = 0;
        }
    }
}
