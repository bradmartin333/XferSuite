using System;
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
        private Size DataSize { get; set; }
        private int[,] Data { get; set; }
        private List<(int[], bool, Color)> Criteria { get; set; }

        public DataSheet((int, int) region, Size regionGrid, Size stampGrid, Size imageGrid, List<(int[], bool, Color)> criteria)
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

        // HELP WANTED
        // Create bitmap using BitmapData, not SetPixel
        public (Bitmap, string) GetBitmap(bool showPF)
        {
            Bitmap bitmap = new Bitmap(DataSize.Height - 1, DataSize.Width - 1);
            double pass = 0;
            double total = 0;
            for (int i = 0; i < bitmap.Width; i++)
                for (int j = 0; j < bitmap.Height; j++)
                {
                    total++;
                    var criterion = Criteria.Where(x => x.Item1.Sum() == Data[j, i]);
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
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            string percentage = (pass / total).ToString("P");
            return (bitmap, percentage);
        }

        public string GetCSV()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = DataSize.Width - 1; i > 0; i--)
            {
                for (int j = 0; j < DataSize.Height; j++)
                {
                    var criterion = Criteria.Where(x => x.Item1.Sum() == Data[i, j]);
                    string data = "0";
                    if (criterion.Any()) data = criterion.First().Item1.Sum().ToString();
                    sb.Append($"{data}\t");
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
                    var criterion = Criteria.Where(x => x.Item1.Sum() == Data[i, j]);
                    bool pass = false;
                    if (criterion.Any()) pass = criterion.First().Item2;
                    if (!pass)
                    {
                        idx++;
                        sb.AppendLine(CreateCycleFileEntry(idx, GetLocation(ID, new Point(i, j))));
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

        public DataEntry GetLocation(object ID, Point l)
        {
            (int, int) region = ((int, int))ID;

            int C = l.X / (StampGrid.Height * ImageGrid.Height);
            int SC = (l.X - (C * StampGrid.Height * ImageGrid.Height)) / ImageGrid.Height;
            int TC = l.X - (C * StampGrid.Height * ImageGrid.Height) - (SC * ImageGrid.Height);

            int R = l.Y / (StampGrid.Width * ImageGrid.Width);
            int SR = (l.Y - (R * StampGrid.Width * ImageGrid.Width)) / ImageGrid.Width;
            int TR = l.Y - (R * StampGrid.Width * ImageGrid.Width) - (SR * ImageGrid.Width);

            return new DataEntry($"0\t0\t0\t{region.Item1}\t{region.Item2}\t{R + 1}\t{C + 1}\t{SR + 1}\t{SC + 1}\t{TR + 1}\t{TC + 1}\t\t0\tFalse\t");
        }
    }
}
