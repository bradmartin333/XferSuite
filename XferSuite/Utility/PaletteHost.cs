using ScottPlot;
using System.Drawing;
using System.Linq;

namespace XferSuite.Utility
{
    public static class PaletteHost
    {
        private static readonly IPalette[] ScottPlotPalettes = Palette.GetPalettes();

        public enum Palettes
        {
            Amber,
            Aurora,
            Category10,
            Category20,
            ColorblindFriendly,
            Dark,
            DarkPastel,
            Frost,
            Microcharts,
            Nero,
            Nord,
            OneHalf,
            OneHalfDark,
            PolarNight,
            Redness,
            Snowstorm,
            Tsitsulin,
        }

        public static Color GetColor(Palettes palette, int idx)
        {
            IPalette thisPalette = ScottPlotPalettes.Where(x => x.Name.Replace(" ","") == palette.ToString()).First();
            (byte r, byte g, byte b) = thisPalette.GetRGB(idx);
            return Color.FromArgb(r, g, b);
        }
    }
}
