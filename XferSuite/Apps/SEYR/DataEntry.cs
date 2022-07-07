using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.Apps.SEYR
{
    public class DataEntry
    {
        public static string Header;
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
        public Form Form { get; set; } = null;
        public string ImageData { get; set; }
        public bool Complete { get; set; } = false; // Flag for finding imporperly formatted data
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
                            if (idx >= data.Length) break; // Hack for protection against corrupted files
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
            string[] cols = data.Split('\t');
            try
            {
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
                Raw = data;
                Complete = RR != 0 && RC != 0 && R != 0 && C != 0 && TR != 0 && TC != 0;
            }
            catch (Exception)
            {
                Complete = false;
            }
        }

        public int GetDimension(int i)
        {
            switch (i)
            {
                case 0: return R;
                case 1: return C;
                case 2: return SR;
                case 3: return SC;
                case 4: return TR;
                case 5: return TC;
                default: return 0;
            }
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

        public string Location() => $"RR {RR}, RC {RC}, R {R}, C {C}, SR {SR}, SC {SC}, TR {TR}, TC {TC}";

        public string DataRow() => $"{ImageNumber}, {X}, {Y}, {RR}, {RC}, {R}, {C}, {SR}, {SC}, {TR}, {TC}";

        public override string ToString() => $"({FeatureName} {Score})";

        public void UpdateRaw() => Raw = $"{ImageNumber}\t{X}\t{Y}\t{RR}\t{RC}\t{R}\t{C}\t{SR}\t{SC}\t{TR}\t{TC}\t{FeatureName}\t{Score}\t{State}\t{ImageData}";
    }
}
