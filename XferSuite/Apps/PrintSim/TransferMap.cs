using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
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

        public static void LoadMap(string path)
        {
            _Picks.Clear();
            _Prints.Clear();
            _Cleans.Clear();

            Point cleanMax = new Point((int)((CleanConfigSize.Width - Math.Abs(CleanConfigOrigin.X - CleaningTapeOrigin.X)) / StampSize.Width),
                (int)((CleanConfigSize.Height - Math.Abs(CleanConfigOrigin.Y - CleaningTapeOrigin.Y)) / StampSize.Height));
            int cleanIndicesX = cleanMax.X;
            int cleanIndicesY = cleanMax.Y;
            if (cleanMax.X == 0)
            {
                MessageBox.Show("Stamp exceeds CleanTapeZoneHeight with current CleanXOrigin");
                return;
            }
            if (cleanMax.Y == 0)
            {
                MessageBox.Show("Stamp exceeds CleanTapeZoneWidth with current CleanYOrigin");
                return;
            }
            /*
             * Can be smarter here...
             * Currently only packing in cleans if there is plenty of space where are indicies are within the tape area
             * Could possibly just pack available clean area
             * Can also determine ideal tape index length here
             */
            if (cleanMax.X > 1 && (int)((CleanConfigSize.Width - Math.Abs(CleanConfigOrigin.X - CleaningTapeOrigin.X)) / SourceClusterPitch.X) == cleanMax.X)
                    cleanIndicesX = (int)SourceChiplets.X;
            if (cleanMax.Y > 1 && (int)((CleanConfigSize.Height - Math.Abs(CleanConfigOrigin.Y - CleaningTapeOrigin.Y)) / SourceClusterPitch.Y) == cleanMax.Y)
                    cleanIndicesY = (int)SourceChiplets.Y;

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
                        _NumPrints / cleanIndicesY % cleanMax.Y + 1,
                        _NumPrints / cleanIndicesX % cleanMax.X + 1,
                        _NumPrints % NumIndices + 1
                    }); // Row, Col, IDX
                }

                _NumPrints++;
            }
        }
    }
}
