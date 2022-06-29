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
        public bool Ignore { get; set; } = false;
        private (DataEntry[], Criteria)[,] Data { get; set; }
        private Bitmap Render;
        private readonly bool FlipX = false;
        private readonly bool FlipY = false;
        private const string PassColor = "ff008000";
        private const string FailColor = "ffb22222";

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
                    string c = Data[j, i].Item2.Color.Name;
                    if (showPF) 
                    {
                        c = Data[j, i].Item2.Pass ? PassColor : FailColor;
                        if (c == PassColor) 
                            pass++;
                    }
                    bitmap.SetPixel(i, j, Color.FromArgb(int.Parse(c, System.Globalization.NumberStyles.HexNumber)));
                }
            if (FlipX) bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
            if (FlipY) bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Render = bitmap;
            string percentage = (pass / total).ToString("P");
            return (bitmap, percentage);
        }

        public int[,] GetData()
        {
            int[,] output = new int[DataSize.Width, DataSize.Height];
            for (int i = 0; i < DataSize.Width; i++)
            {
                for (int j = DataSize.Height - 1; j >= 0;  j--)
                {
                    output[i, j] = Data[i, j].Item2.ID;
                }
            }
            return output;
        }

        public string GetCSV(List<Criteria> criteria, bool showPF)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < Render.Height; j++)
            {
                for (int i = 0; i < Render.Width; i++)
                {
                    if (showPF)
                    {
                        switch (Render.GetPixel(i, j).Name)
                        {
                            case PassColor:
                                sb.Append($"1\t");
                                break;
                            case FailColor:
                                sb.Append($"0\t");
                                break;
                            default:
                                sb.Append($" \t");
                                break;
                        }
                    }
                    else
                    {
                        var criterion = criteria.Where(x => x.Color == Render.GetPixel(i, j));
                        if (criterion.Any())
                            sb.Append($"{criterion.First().ID}\t");
                        else
                            sb.Append($" \t");
                    }
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public string CreateCycleFile(ref int idx)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < Render.Height; j++)
            {
                for (int i = 0; i < Render.Width; i++)
                {
                    if (Render.GetPixel(i, j).Name == FailColor)
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
