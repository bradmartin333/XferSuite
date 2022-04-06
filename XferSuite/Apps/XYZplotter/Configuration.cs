namespace XferSuite.Apps.XYZplotter
{
    /// <summary>
    /// Handy place to store user selected configurations of plots
    /// </summary>
    public static class Configuration
    {
        public static bool RemoveAngle { get; set; } = true;
        public static bool Equalize { get; set; } = false;
        public static bool ShowBestFit { get; set; } = false;
        public static bool FlipX { get; set; } = false;
        public static bool FlipY { get; set; } = false;
        public static bool FlipZ { get; set; } = false;
        public static bool OverrideCheckbox { get; set; } = false;
    }
}
