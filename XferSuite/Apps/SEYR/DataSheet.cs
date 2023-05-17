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
        public Point PointID { get => new Point(ID.Item1, ID.Item2); }
        public Size StampGrid { get; set; }
        public Size ImageGrid { get; set; }
        public Size DataSize { get; set; }
        public bool Ignore { get; set; } = false;
        private (DataEntry[], Criteria)[,] Data { get; set; }
        private Bitmap Render;
        private readonly bool FlipX = false;
        private readonly bool FlipY = false;
        private readonly Color PassColor = Color.Green;
        private readonly Color FailColor = Color.Firebrick;

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

        public (Bitmap, double, double) GetBitmap(bool showPF)
        {
            if (DataSize.Height <= 1 || DataSize.Width <= 1) return (new Bitmap(1, 1), 0, 0);
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
                        if (Data[j, i].Item2.Pass)
                        {
                            pass++;
                            c = PassColor;
                        }
                        else
                            c = FailColor;     
                    }
                    bitmap.SetPixel(i, j, c);
                }
            if (FlipX) bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
            if (FlipY) bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Render = bitmap;
            return (bitmap, pass, total);
        }

        private (double, double) GetYieldData()
        {
            double pass = 0;
            double total = 0;
            for (int i = 0; i < DataSize.Height; i++)
                for (int j = 0; j < DataSize.Width; j++)
                {
                    if (Data[j, i].Item2 == null) continue;
                    total++;
                    if (Data[j, i].Item2.Pass) pass++;
                }
            return (pass, total);
        }

        public string GetRegionYieldString(int sigFigs)
        {
            var d = Data[0, 0];
            if (d.Item1 != null && d.Item1.Length > 0)
            {
                DataEntry e = d.Item1[0];
                (double pass, double total) = GetYieldData();
                double percentage = Math.Round(pass / total, sigFigs) * 100;
                int numDigitsBeforeDecimal = (int)Math.Log10(percentage) + 1;
                int numDecimalPlaces = Math.Max(0, sigFigs - numDigitsBeforeDecimal);
                return $"{e.R}, {e.C}, {e.RR}, {e.RC}, {string.Format($"{{0:F{numDecimalPlaces}}}", percentage)}, {total}";
            }
            else return $"ERR {ID}";
        }

        public Bitmap MakeComposite(Size margin)
        {
            Feature[] features = ParseSEYR.Project.Features.Where(x => x.SaveImage).ToArray();
            if (features.Count() > 1)
            {
                Feature[] specificImage = features.Where(x => x.CriteriaString == "img").ToArray();
                if (specificImage.Length == 1) features = specificImage;
            }
            if (features.Count() == 1)
            {
                Feature feature = features[0];
                DataEntry[] entries = Data[0, 0].Item1.Where(x => x.FeatureName == feature.Name).ToArray();
                if (entries.Any())
                {
                    DataEntry entry = entries[0];
                    Size imageSize = entry.Image.Size;
                    Size size = new Size(imageSize.Width + margin.Width, imageSize.Height + margin.Height);
                    try
                    {
                        Bitmap bitmap = new Bitmap(DataSize.Height * size.Width, DataSize.Width * size.Height);
                        for (int i = 0; i < DataSize.Height; i++)
                            for (int j = 0; j < DataSize.Width; j++)
                                DrawTile(i, j, feature.Name, size, ref bitmap);
                        return bitmap;
                    }
                    catch (Exception)
                    {
                        return new Bitmap(1, 1);
                    }
                }
                else
                    return new Bitmap(1, 1);
            }
            else
                return new Bitmap(1, 1);
        }

        private void DrawTile(int i, int j, string name, Size size, ref Bitmap bmp)
        {
            if (Data[j, i].Item2 != null)
            {
                Bitmap tile = Data[j, i].Item1.Where(x => x.FeatureName == name).First().Image;
                int xLocation = i * size.Width;
                if (FlipX) xLocation = bmp.Width - xLocation - size.Width;
                int yLocation = j * size.Height;
                if (FlipY) yLocation = bmp.Height - yLocation - size.Height;
                using (Graphics g = Graphics.FromImage(bmp))
                    g.DrawImage(tile, new Rectangle(xLocation, yLocation, tile.Width, tile.Height));
            }  
        }

        public object[,] GetData(bool showPF)
        {
            object[,] output = new object[DataSize.Width, DataSize.Height];
            for (int i = 0; i < DataSize.Width; i++)
                for (int j = 0; j < DataSize.Height; j++)
                    output[FlipY ? DataSize.Width - i - 1 : i, FlipX ? DataSize.Height - j - 1 : j] = (Data[i, j].Item1 == null) ? 
                        " " : (object)(showPF ? Convert.ToInt32(Data[i, j].Item2.Pass) : Data[i, j].Item2.ID);
            return output;
        }

        public DataEntry[] GetEntries()
        {
            List<DataEntry> entries = new List<DataEntry>();
            for (int i = 0; i < DataSize.Width; i++)
                for (int j = 0; j < DataSize.Height; j++)
                    Data[i, j].Item1?.ToList().ForEach(x => entries.Add(x));
            return entries.ToArray();
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
                        Color c = Render.GetPixel(i, j);
                        if (c.ToArgb() == PassColor.ToArgb())
                            sb.Append($"1\t");
                        else if (c.ToArgb() == FailColor.ToArgb())
                            sb.Append($"0\t");
                        else
                            sb.Append($" \t");
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

        public string GetDataRows(List<string> names, bool failOnly = false)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < DataSize.Width; i++)
                for (int j = 0; j < DataSize.Height; j++)
                    if (Data[i, j].Item1 != null)
                    {
                        (DataEntry[], Criteria) rowObject = GetLocation(new Point(j, i), true);
                        if (failOnly && rowObject.Item2.Pass) continue;
                        if (rowObject.Item1 == null) continue;
                        DataEntry d = rowObject.Item1[0];
                        string legend = rowObject.Item2.LegendEntry;
                        string line = $"{d.DataRow()}, " + CreateCycleRC(d) + ", " +
                            $"{(rowObject.Item2.Pass ? "Pass" : "Fail")}, " +
                            $"{rowObject.Item2.ID}, {legend}";

                        foreach (string name in names)
                            line += $", {Convert.ToInt32(legend.Contains(name.TrimEnd(new char[] {' '})))}";

                        sb.AppendLine(line);
                    }         
            return sb.ToString();
        }

        public string CreateCycleFile(ref int idx)
        {
            string repairWafer = ParseSEYR.FileName + "_Repair";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < DataSize.Width; i++)
                for (int j = 0; j < DataSize.Height; j++)
                    if (Data[i, j].Item1 != null)
                    {
                        (DataEntry[], Criteria) rowObject = GetLocation(new Point(j, i), true);
                        if (rowObject.Item1 == null) continue;
                        if (!rowObject.Item2.Pass)
                        {
                            idx++;
                            sb.AppendLine(CreateCycleFileEntry(repairWafer, idx, rowObject.Item1[0]));
                        }
                    }                   
            return sb.ToString();
        }

        private string CreateCycleFileEntry(string repairWafer, int idx, DataEntry d)
        {
            return $"{idx}, {repairWafer}, 1, 1, 1, 1, {idx}, YZ9876, {d.RR}, {d.RC}, " + CreateCycleRC(d);
        }

        private string CreateCycleRC(DataEntry d)
        {
            return $"{(d.R - 1) * StampGrid.Width * ImageGrid.Width + (d.SR - 1) * StampGrid.Width + d.TR}, " +
                   $"{(d.C - 1) * StampGrid.Height * ImageGrid.Height + (d.SC - 1) * StampGrid.Height + d.TC}";
        }

        public (DataEntry[], Criteria) GetLocation(Point p_in, bool cycle = false)
        {
            // 15NOV2022
            // Issue #246 shows that the Data[,] index can be flipped incorrecty and not always fail.
            // Fix is to swap i,j when calling this function during iteration of DataSize.
            // Using mouse click hander point works fine using x,y.
            // One has to be swapped and because the click handler is already a Point,
            // it is easier to just swap i,j type calls to be j,i.
            try
            {
                int bmpX = p_in.X;
                int bmpY = p_in.Y;
                if (!cycle && FlipX) bmpX = Render.Width - bmpX - 1;
                if (!cycle && FlipY) bmpY = Render.Height - bmpY - 1;
                return Data[bmpY, bmpX];
            }
            catch (Exception)
            {
                return (null, null);
            }
        }
    }
}
