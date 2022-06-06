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
        private (DataEntry[], Criteria)[,] Data { get; set; }
        private Bitmap Render;
        private readonly bool FlipX = false;
        private readonly bool FlipY = false;

        public DataSheet((int, int) region, Size regionGrid, Size stampGrid, Size imageGrid, bool flipX, bool flipY)
        {
            ID = region;
            StampGrid = stampGrid;
            ImageGrid = imageGrid;
            DataSize = new Size(regionGrid.Width * stampGrid.Width * imageGrid.Width, regionGrid.Height * stampGrid.Height * imageGrid.Height);
            Data = new (DataEntry[], Criteria)[DataSize.Width, DataSize.Height];
            FlipX = flipX;
            FlipY = flipY;
        }

        public void Insert(DataEntry[] e, Criteria c)
        {
            int i = ((e[0].R - 1) * StampGrid.Width * ImageGrid.Width) + ((e[0].SR - 1) * ImageGrid.Width) + e[0].TR - 1;
            int j = ((e[0].C - 1) * StampGrid.Height * ImageGrid.Height) + ((e[0].SC - 1) * ImageGrid.Height) + e[0].TC - 1;
            Data[i, j] = (e, c);
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
                    if (Data[j, i].Item2 == null) continue;
                    total++;
                    Color c = Data[j, i].Item2.Color;
                    if (showPF) 
                    {
                        c = Data[j, i].Item2.Pass ? Color.Green : Color.Firebrick;
                        if (c == Color.Green) 
                            pass++;
                        bitmap.SetPixel(i, j, c);
                    } 
                    else
                        bitmap.SetPixel(i, j, c);
                }
            if (FlipX) bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
            if (FlipY) bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Render = bitmap;
            string percentage = (pass / total).ToString("P");
            return (bitmap, percentage);
        }

        public string GetCSV(List<Criteria> criteria)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < Render.Height; j++)
            {
                for (int i = 0; i < Render.Width; i++)
                {
                    var criterion = criteria.Where(x => x.Color == Render.GetPixel(i, j));
                    if (criterion.Any())
                        sb.Append($"{criterion.First().ID}\t");
                    else if (Data[i,j].Item1 != null)
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
                    if (Data[j, i].Item1 != null && !Data[j, i].Item2.Pass)
                    {
                        idx++;
                        sb.AppendLine(CreateCycleFileEntry(idx, GetLocation(new Point(i, j), true).Item1[0]));
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

        public (DataEntry[], Criteria) GetLocation(Point p_in, bool cycle = false)
        {
            try
            {
                int bmpX = p_in.X;
                int bmpY = p_in.Y;
                if (!cycle && FlipX) bmpX = Render.Width - bmpX - 1;
                if (!cycle && FlipY) bmpY = Render.Height - bmpY - 1;
                return Data[bmpY, bmpX];
            }
            catch (System.Exception)
            {
                return (null, null);
            }
        }
    }
}
