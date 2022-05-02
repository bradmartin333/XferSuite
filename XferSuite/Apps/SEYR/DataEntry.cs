using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace XferSuite.Apps.SEYR
{
    public class DataEntry
    {
        public string Raw { get; set; }
        public int ImageNumber { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int RR { get; set; }
        public int RC { get; set; }
        public int R { get; set; }
        public int C { get; set; }
        public int SR { get; set; }
        public int SC { get; set; }
        public int TR { get; set; }
        public int TC { get; set; }
        public string FeatureName { get; set; }
        public Feature Feature { get => ParseSEYR.Project.Features.Where(x => x.Name == FeatureName).First(); }
        public float Score { get; set; }
        public bool State { get; set; }
        public string ImageData { get; set; }
        public Bitmap Image
        {
            get
            {
                if (Feature.SaveImage)
                {
                    byte[] data = Decompress(ImageData);
                    Rectangle rect = Feature.GetPaddedGeometry();
                    Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
                    int idx = 0;
                    for (int j = 0; j < rect.Height; j++)
                    {
                        for (int i = 0; i < rect.Width; i++)
                        {
                            byte val = data[idx];
                            bitmap.SetPixel(i, j, Color.FromArgb(val, val, val));
                            idx++;
                        }
                    }
                    return bitmap;
                }
                else
                    return null;
            }
        }

        public DataEntry(string data)
        {
            Raw = data;
            string[] cols = data.Split('\t');
            ImageNumber = int.Parse(cols[0]);
            X = double.Parse(cols[1]);
            Y = double.Parse(cols[2]);
            RR = int.Parse(cols[3]);
            RC = int.Parse(cols[4]);
            R = int.Parse(cols[5]);
            C = int.Parse(cols[6]);
            SR = int.Parse(cols[7]);
            SC = int.Parse(cols[8]);
            TR = int.Parse(cols[9]);
            TC = int.Parse(cols[10]);
            FeatureName = cols[11];
            Score = float.Parse(cols[12]);
            State = bool.Parse(cols[13]);
            ImageData = cols[14];
        }

        public static byte[] Decompress(string compressed)
        {
            byte[] data = Convert.FromBase64String(compressed);
            MemoryStream input = new MemoryStream(data);
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(input, CompressionMode.Decompress))
            {
                dstream.CopyTo(output);
            }
            return output.ToArray();
        }
    }
}
