using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using static XferSuite.Parameters;

namespace XferSuite
{
    class TransferMap
    {
        public static List<int[]> _Picks = new List<int[]>();
        public static List<int[]> _Prints = new List<int[]>();
        public static List<int[]> _Cleans = new List<int[]>();
        public static int _NumPrints;
        public static Point _CleanMax;

        public static void LoadMap(string path)
        {
            _Picks.Clear();
            _Prints.Clear();
            _Cleans.Clear();
            _CleanMax = new Point((int)(CleanConfigSize.Width / StampSize.Height), (int)(CleanConfigSize.Height / StampSize.Width));

            XDocument doc = XDocument.Load(path);
            IEnumerable<XElement> transfers = doc.Element("TransferMap").Element("Transfers").Elements("Transfer");
            foreach (XElement transfer in transfers)
            {
                XAttribute[] pick = transfer.Element("Pick").Attributes().ToArray();
                int[] pickVals = new int[] { int.Parse(pick[1].Value), int.Parse(pick[2].Value), int.Parse(pick[3].Value), int.Parse(pick[4].Value), int.Parse(pick[5].Value) };
                _Picks.Add(pickVals);

                XAttribute[] print = transfer.Element("Print").Attributes().ToArray();
                int[] printVals = new int[] { int.Parse(print[1].Value), int.Parse(print[2].Value), int.Parse(print[3].Value), int.Parse(print[4].Value), 1 };
                _Prints.Add(printVals);

                if (transfer.Elements("Clean").Any())
                {
                    XAttribute[] clean = transfer.Element("Clean").Attributes().ToArray();
                    int[] cleanVals = new int[] { 1, 1, int.Parse(clean[1].Value), int.Parse(clean[2].Value), int.Parse(clean[3].Value) };
                    _Cleans.Add(cleanVals);
                }
                else
                {
                    _Cleans.Add(new int[]
                    {
                        _NumPrints / NumIndices % _CleanMax.Y + 1,
                        _NumPrints / NumIndices % _CleanMax.X + 1,
                        _NumPrints % NumIndices + 1
                    }); // Row, Col, IDX
                }

                _NumPrints++;
            }
        }
    }
}
