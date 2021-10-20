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
            // Reset
            _NumPrints = 0;
            _Picks.Clear();
            _Prints.Clear();
            _Cleans.Clear();

            // Find number of stamps that fit in the clean area
            Point cleanMax = new Point((int)((CleanConfigSize.Width - Math.Abs(CleanConfigOrigin.X - CleaningTapeOrigin.X)) / SourceClusterPitch.X),
                (int)((CleanConfigSize.Height - Math.Abs(CleanConfigOrigin.Y - CleaningTapeOrigin.Y)) / SourceClusterPitch.Y));
            if (cleanMax.X == 0)
            {
                if ((CleanConfigSize.Width - Math.Abs(CleanConfigOrigin.X - CleaningTapeOrigin.X)) / StampSize.Width == 0 ) // See if we can fit anything in the X dir
                {
                    MessageBox.Show("Stamp exceeds CleanTapeZoneHeight with current CleanXOrigin");
                    return;
                }
                else
                    cleanMax.X = 1;
            }
            if (cleanMax.Y == 0)
            {
                if ((CleanConfigSize.Height - Math.Abs(CleanConfigOrigin.Y - CleaningTapeOrigin.Y)) / StampSize.Height == 0) // See if we can fit anything in the Y dir
                {
                    MessageBox.Show("Stamp exceeds CleanTapeZoneWidth with current CleanYOrigin");
                    return;
                }
                else
                    cleanMax.Y = 1;
            }

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

                if (transfer.Elements("Clean").Any()) // Specified Clean
                {
                    XAttribute[] clean = transfer.Element("Clean").Attributes().ToArray();
                    int[] cleanVals = new int[] { 1, 1, int.Parse(clean[1].Value), int.Parse(clean[2].Value), int.Parse(clean[3].Value) };
                    _Cleans.Add(cleanVals);
                }
                else // Auto Clean: RR, RC, R, C, IDX
                    _Cleans.Add(new int[] { 1, 1, 
                        (_NumPrints % cleanMax.Y) + 1, 
                        (_NumPrints / ((cleanMax.Y > 1) ? cleanMax.X : 1) % cleanMax.X) + 1, 
                        _NumPrints });

                _NumPrints++;
            }
        }
    }
}
