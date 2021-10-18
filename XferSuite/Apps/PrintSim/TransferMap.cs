using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static bool _autoCleanLocations = false;

        private static float StampXSize;
        private static float StampYSize;
        private static float CleanTapeXSize;
        private static float CleanTapeYSize;
        private static int CleanMaxRows;
        private static int CleanMaxColumns;
        private static int CleanMaxIndex;
        private static int MaxCleanCycle;
        private static int CleanIndex;
        private static int CleanRow;
        private static int CleanColumn;
        public static int CleanRegionRow = 1;
        public static int CleanRegionColumn = 1;
        private static sRCI CleanResults;

        public static async void LoadMap(string path)
        {
            _Picks.Clear();
            _Prints.Clear();
            _Cleans.Clear();

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
                    int[] cleanVals = new int[] { int.Parse(clean[1].Value), int.Parse(clean[2].Value), int.Parse(clean[3].Value)};
                    _Cleans.Add(cleanVals);
                }
                else
                {
                    _autoCleanLocations = true;
                }
            }

            _NumPrints = _Picks.Count;

            if (_autoCleanLocations)
            {
                for (int _prints = 1; _prints <= _NumPrints; _prints++)
                {
                    sRCI result = await AutoClean(_prints);
                    int[] cleanVals = new int[] { result.Row, result.Column, result.Index};
                    _Cleans.Add(cleanVals);
                }
            }
        }

        public struct sRCI
        {
            public int Row;
            public int Column;
            public int Index;
        }
        public static void Init_Class()
        {
            StampXSize = (StampPosts.X + 1) * StampPostPitch.X;
            StampYSize = (StampPosts.Y + 1) * StampPostPitch.Y;
            CleanMaxRows = Convert.ToInt32(Math.Round(CleanConfigSize.Y / StampYSize));
            CleanMaxColumns = Convert.ToInt32(Math.Round(CleanConfigSize.X / StampXSize));
            CleanMaxIndex = Convert.ToInt32(StampPostPitch.X / SourceChipletPitch.X * (StampPostPitch.Y / SourceChipletPitch.Y));
            MaxCleanCycle = CleanMaxRows * CleanMaxColumns * CleanMaxIndex; // Max number of cleans that cab be done using the current Stamp dimensions
        }
        public static async Task<sRCI> AutoClean(int CycleNum)
        {
            try
            {   
                Init_Class();
                CleanIndex = (CycleNum - 1) % CleanMaxIndex + 1; // Generates the Index From 1 to MaxIndex
                CleanRow = Convert.ToInt32(1d + (CycleNum - 1 - (CycleNum - 1) % CleanMaxIndex) / (double)CleanMaxIndex); // Generates the Rows from 1 to Infinite Rows
                CleanColumn = Convert.ToInt32(1d + (CleanRow - 1 - (CleanRow - 1) % CleanMaxRows) / (double)CleanMaxRows); // Generates the Columns from 1 to Infinite Columns
                CleanResults.Row = (CleanRow - 1) % CleanMaxRows + 1; // Generates the rows from 1 to MaxRows
                CleanResults.Column = (CleanColumn - 1) % CleanMaxColumns + 1; // Generates the Columns from 1 to MaxColumns
                CleanResults.Index = CleanIndex;
                if (CleanResults.Column == CleanMaxColumns && CleanResults.Row == CleanMaxRows && CleanResults.Index == CleanMaxIndex)
                {
                    CleanRegionRow++;
                    if (CleanRegionRow == 11)
                    {
                        CleanRegionRow = 1;
                        CleanRegionColumn++;
                    }
                }
                return CleanResults;
            }
            catch (Exception ex)
            {
                //WriteEventLog("ERROR: Exception in AutoClean: ", ex.Message);
                CleanResults.Row = -999;
                CleanResults.Column = -999;
                CleanResults.Index = -999;
                return CleanResults;
            }
        }
    }
}
