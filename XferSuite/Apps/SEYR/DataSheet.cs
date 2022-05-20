using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace XferSuite.Apps.SEYR
{
    public class DataSheet
    {      
        public (int, int) ID { get; set; }
        public Size StampGrid { get; set; }
        public Size ImageGrid { get; set; }
        private Size DataSize { get; set; }
        private int[,] Data { get; set; }
        private List<(int, bool, Color)> Criteria { get; set; }

        public DataSheet((int, int) region, Size regionGrid, Size stampGrid, Size imageGrid, List<(int, bool, Color)> criteria)
        {
            ID = region;
            StampGrid = stampGrid;
            ImageGrid = imageGrid;
            DataSize = new Size(regionGrid.Width * stampGrid.Width * imageGrid.Width, regionGrid.Height * stampGrid.Height * imageGrid.Height);
            Data = new int[DataSize.Width, DataSize.Height];
            Criteria = criteria;
        }

        public void Insert(DataEntry e, int criterion)
        {
            int i = ((e.R - 1) * StampGrid.Width * ImageGrid.Width) + ((e.SR - 1) * ImageGrid.Width) + e.TR - 1;
            int j = ((e.C - 1) * StampGrid.Height * ImageGrid.Height) + ((e.SC - 1) * ImageGrid.Height) + e.TC - 1;
            Data[i, j] = criterion;

        }

        public Bitmap GetTestBitmap()
        {
            Bitmap bitmap = new Bitmap(DataSize.Height - 1, DataSize.Width - 1);
            for (int i = 0; i < bitmap.Width; i++)
                for (int j = 0; j < bitmap.Height; j++)
                {
                    var criterion = Criteria.Where(x => x.Item1 == Data[j, i]);
                    if (criterion.Any()) bitmap.SetPixel(i, j, criterion.First().Item3);
                }
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return bitmap;
        }
    }
}
