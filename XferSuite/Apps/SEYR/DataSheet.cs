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
        private (int, DataEntry, Color, bool)[,] Data { get; set; }
        private Bitmap Render;
        private readonly bool FlipX = false;
        private readonly bool FlipY = false;

        public DataSheet((int, int) region, Size regionGrid, Size stampGrid, Size imageGrid, bool flipX, bool flipY)
        {
            ID = region;
            StampGrid = stampGrid;
            ImageGrid = imageGrid;
            DataSize = new Size(regionGrid.Width * stampGrid.Width * imageGrid.Width, regionGrid.Height * stampGrid.Height * imageGrid.Height);
            Data = new (int, DataEntry, Color, bool)[DataSize.Width, DataSize.Height];
            FlipX = flipX;
            FlipY = flipY;
        }

        public void Insert(DataEntry e, int criterion, Color c, bool pass)
        {
            int i = ((e.R - 1) * StampGrid.Width * ImageGrid.Width) + ((e.SR - 1) * ImageGrid.Width) + e.TR - 1;
            int j = ((e.C - 1) * StampGrid.Height * ImageGrid.Height) + ((e.SC - 1) * ImageGrid.Height) + e.TC - 1;
            Data[i, j] = (criterion, e, c, pass);
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
                    Color c = Data[j, i].Item3;
                    if (showPF) 
                    {
                        c = Data[j, i].Item4 ? Color.Green : Color.Firebrick;
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

        public string GetCSV(List<(int, Color, string, bool)> criteria)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < Render.Height; j++)
            {
                for (int i = 0; i < Render.Width; i++)
                {
                    var criterion = criteria.Where(x => x.Item2 == Render.GetPixel(i, j));
                    if (criterion.Any())
                        sb.Append($"{criterion.First().Item1}\t");
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
                    if (!Data[j, i].Item4)
                    {
                        idx++;
                        sb.AppendLine(CreateCycleFileEntry(idx, GetLocation(new Point(i, j), true)));
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

        public DataEntry GetLocation(Point p_in, bool cycle = false)
        {
            int bmpX = p_in.X;
            int bmpY = p_in.Y;
            if (!cycle && FlipX) bmpX = Render.Width - bmpX - 1;
            if (!cycle && FlipY) bmpY = Render.Height - bmpY - 1;
            return Data[bmpY, bmpX].Item2;
        }
    }
}
