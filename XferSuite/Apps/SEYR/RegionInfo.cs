namespace XferSuite.Apps.SEYR
{
    public class RegionInfo
    {
        public (int, int) ID { get; set; }
        public int Pass { get; set; } = 0;
        public int Total { get; set; } = 0;

        public RegionInfo((int, int) region)
        {
            ID = region;
        }

        public void Reset()
        {
            Pass = 0;
            Total = 0;
        }

        public string Percentage() => (Pass / (double)Total).ToString("P");
    }
}
