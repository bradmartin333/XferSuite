using System.Collections.Generic;
using System.Drawing;

namespace XferSuite.Apps.SEYR
{
    internal class DataSheet
    {      
        public (int, int) ID { get; set; }
        public Size ImageGrid { get; set; }
        private int[,] Data { get; set; }
        private List<(int, bool)> Criteria { get; set; }

        public DataSheet((int, int) region, Size regionGrid, Size imageGrid, List<(int, bool)> criteria)
        {
            ID = region;
            ImageGrid = imageGrid;
            Data = new int[regionGrid.Width * imageGrid.Width, regionGrid.Height * imageGrid.Height];
            Criteria = criteria;
        }

        public void Insert(int i, int j, int val)
        {
            Data[i, j] = val;
        }
    }
}
