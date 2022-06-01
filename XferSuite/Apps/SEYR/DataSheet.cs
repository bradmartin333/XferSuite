using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace XferSuite.Apps.SEYR
{
    public class DataSheet
    {      
        public (int, int) ID { get; set; }
        public Size StampGrid { get; set; }
        public Size ImageGrid { get; set; }
        public Size DataSize { get; set; }
        private (int, DataEntry)[,] Data { get; set; }
        private List<(int[], bool, Color)> Criteria { get; set; }
        private Bitmap Render;
        private readonly bool FlipX = false;
        private readonly bool FlipY = true;

        public DataSheet((int, int) region, Size regionGrid, Size stampGrid, Size imageGrid, List<(int[], bool, Color)> criteria)
        {
            ID = region;
            StampGrid = stampGrid;
            ImageGrid = imageGrid;
            DataSize = new Size(regionGrid.Width * stampGrid.Width * imageGrid.Width, regionGrid.Height * stampGrid.Height * imageGrid.Height);
            Data = new (int, DataEntry)[DataSize.Width, DataSize.Height];
            Criteria = criteria;
        }

        public void Insert(DataEntry e, int criterion)
        {
            int i = ((e.R - 1) * StampGrid.Width * ImageGrid.Width) + ((e.SR - 1) * ImageGrid.Width) + e.TR - 1;
            int j = ((e.C - 1) * StampGrid.Height * ImageGrid.Height) + ((e.SC - 1) * ImageGrid.Height) + e.TC - 1;
            Data[i, j] = (criterion, e);
        }

        public (Bitmap, string) GetBitmap(bool showPF)
        {
            if (DataSize.Height <= 1 || DataSize.Width <= 1) return (new Bitmap(1, 1), 0.ToString("P"));
            Bitmap bitmap = new Bitmap(DataSize.Height, DataSize.Width);
            double pass = 0;
            double total = 0;
            for (int i = 0; i < bitmap.Width; i++)
                for (int j = 0; j < bitmap.Height; j++)
                {
                    total++;
                    var criterion = Criteria.Where(x => x.Item1.Sum() == Data[j, i].Item1);
                    if (criterion.Any())
                    {
                        Color c = criterion.First().Item3;
                        if (showPF) c = criterion.First().Item2 ? Color.Green : Color.Firebrick;
                        if (c == Color.Green) pass++;
                        bitmap.SetPixel(i, j, c);
                    } 
                    else if (showPF)
                        bitmap.SetPixel(i, j, Color.Firebrick);
                }
            if (FlipX) bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
            if (FlipY) bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Render = bitmap;
            string percentage = (pass / total).ToString("P");
            return (bitmap, percentage);
        }

        public string GetCSV()
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < Render.Height; j++)
            {
                for (int i = 0; i < Render.Width; i++)
                {
                    var criteria = Criteria.Where(x => x.Item3 == Render.GetPixel(i, j));
                    if (criteria.Any())
                        sb.Append($"{criteria.First().Item1.Sum()}\t");
                    else
                        sb.Append($"0\t");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public string CreateCycleFile(ref int idx)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < DataSize.Width; i++)
            {
                for (int j = 0; j < DataSize.Height; j++)
                {
                    var criterion = Criteria.Where(x => x.Item1.Sum() == Data[i, j].Item1);
                    bool pass = false;
                    if (criterion.Any()) pass = criterion.First().Item2;
                    if (!pass)
                    {
                        idx++;
                        sb.AppendLine(CreateCycleFileEntry(idx, GetLocation(new Point(i, j))));
                    }
                }
            }
            return sb.ToString();
        }

        private string CreateCycleFileEntry(int idx, DataEntry d)
        {
            return $"{idx}, AB1234, 1, 1, 1, 1, {idx}, YZ9876, {d.RR}, {d.RC}, " +
                   $"{(d.R - 1) * StampGrid.Width * ImageGrid.Width + (d.SR - 1) * StampGrid.Width + d.TR}, " +
                   $"{(d.C - 1) * StampGrid.Height * ImageGrid.Height + (d.SC - 1) * StampGrid.Height + d.TC}";
        }

        public DataEntry GetLocation(Point p_in)
        {
            int bmpX = p_in.X;
            int bmpY = p_in.Y;
            if (FlipX) bmpX = Render.Width - bmpX - 1;
            if (FlipY) bmpY = Render.Height - bmpY - 1;
            return Data[bmpY, bmpX].Item2;
        }
    }
}
