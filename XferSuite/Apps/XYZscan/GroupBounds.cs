namespace XferSuite.Apps.XYZscan
{
    public static class GroupBounds
    {
        public static double XMin { get; set; } = double.MaxValue;
        public static double XMax { get; set; } = double.MinValue;
        public static double YMin { get; set; } = double.MaxValue;
        public static double YMax { get; set; } = double.MinValue;
        public static double ZMin { get; set; } = double.MaxValue;
        public static double ZMax { get; set; } = double.MinValue;
        public enum Axis
        {
            X, Y, Z
        }

        public static void Reset()
        {
            XMin = double.MaxValue;
            XMax = double.MinValue;
            YMin = double.MaxValue;
            YMax = double.MinValue;
            ZMin = double.MaxValue;
            ZMax = double.MinValue;
        }

        public static double GetRange(Axis axis, int numDecimalPlaces = 3)
        {
            switch (axis)
            {
                case Axis.X:
                    if (XMin != double.MaxValue && XMax != double.MinValue) 
                        return System.Math.Round(XMax - XMin, numDecimalPlaces);
                    break;
                case Axis.Y:
                    if (YMin != double.MaxValue && YMax != double.MinValue)
                        return System.Math.Round(YMax - YMin, numDecimalPlaces);
                    break;
                case Axis.Z:
                    if (ZMin != double.MaxValue && ZMax != double.MinValue)
                        return System.Math.Round(ZMax - ZMin, numDecimalPlaces);
                    break;
                default:
                    break;
            }
            return double.MaxValue;
        }

        public static string GetRangeString(Axis axis, int numDecimalPlaces = 3)
        {
            double range = GetRange(axis, numDecimalPlaces);
            return range == double.MaxValue ? "N/A" : range.ToString();
        }
    }
}
