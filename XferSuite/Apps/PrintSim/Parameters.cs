using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XferSuite
{
    public static class Parameters
    {
        private static readonly string ConfigPath = @"C:\XferPrint\XferPrintConfig.xml";
        public static string RecipeName = "NoRecipe";
        public static string ToolName = "NoTool";

        // Source
        public static Point SourceChiplets;
        public static PointF SourceChipletPitch;
        public static Point SourceClusters;
        public static PointF SourceClusterPitch;
        public static Point SourceRegions;
        public static PointF SourceRegionPitch;
        public static PointF SourceOrigin;

        // Target
        public static Point TargetPrints;
        public static PointF TargetPrintPitch;
        public static Point TargetClusters;
        public static PointF TargetClusterPitch;
        public static PointF TargetOrigin;

        // Cleaning Tape
        public static PointF CleaningTapeOrigin;

        // Stamp
        public static Point StampPosts;
        public static PointF StampPostPitch;
        public static SizeF StampSize;
        public static int NumIndices;

        // Tool
        public static PointF SourceWaferCenter;
        public static PointF TargetWaferCenter;
        public static float SourceDiameter;
        public static float TargetDiameter;
        public static PointF StageRange;
        public static PointF CleanConfigOrigin;
        public static SizeF CleanConfigSize;

        public static void LoadRecipe(string path)
        {
            XDocument doc = XDocument.Load(path);

            XElement recipe = doc.Element("ProcessParameters").Element("Recipe");
            RecipeName = recipe.Element("Name").Value;

            XElement source = doc.Element("ProcessParameters").Element("Source");
            SourceChiplets = new Point(int.Parse(source.Element("SourceXChiplets").Value), int.Parse(source.Element("SourceYChiplets").Value));
            SourceChipletPitch = new PointF(float.Parse(source.Element("SourceXChipletPitch").Value), float.Parse(source.Element("SourceYChipletPitch").Value));
            SourceClusters = new Point(int.Parse(source.Element("SourceXClusters").Value), int.Parse(source.Element("SourceYClusters").Value));
            SourceClusterPitch = new PointF(float.Parse(source.Element("SourceXClusterPitch").Value), float.Parse(source.Element("SourceYClusterPitch").Value));
            SourceRegions = new Point(int.Parse(source.Element("SourceXRegions").Value), int.Parse(source.Element("SourceYRegions").Value));
            SourceRegionPitch = new PointF(float.Parse(source.Element("SourceXRegionsPitch").Value), float.Parse(source.Element("SourceYRegionsPitch").Value));
            SourceOrigin = new PointF(float.Parse(source.Element("SourceR1C1XPosGlobal").Value), float.Parse(source.Element("SourceR1C1YPosGlobal").Value));

            XElement target = doc.Element("ProcessParameters").Element("Target");
            TargetPrints = new Point(int.Parse(target.Element("TargetXPrints").Value), int.Parse(target.Element("TargetYPrints").Value));
            TargetPrintPitch = new PointF(float.Parse(target.Element("TargetXPrintPitch").Value), float.Parse(target.Element("TargetYPrintPitch").Value));
            TargetClusters = new Point(int.Parse(target.Element("TargetXClusters").Value), int.Parse(target.Element("TargetYClusters").Value));
            TargetClusterPitch = new PointF(float.Parse(target.Element("TargetXClusterPitch").Value), float.Parse(target.Element("TargetYClusterPitch").Value));
            TargetOrigin = new PointF(float.Parse(target.Element("TargetR1C1XPosGlobal").Value), float.Parse(target.Element("TargetR1C1YPosGlobal").Value));

            XElement stamp = doc.Element("ProcessParameters").Element("Stamp");
            StampPosts = new Point(int.Parse(stamp.Element("StampXPosts").Value), int.Parse(stamp.Element("StampYPosts").Value));
            StampPostPitch = new PointF(float.Parse(stamp.Element("StampXPostPitch").Value), float.Parse(stamp.Element("StampYPostPitch").Value));
            StampSize = new SizeF(StampPosts.X * StampPostPitch.X, StampPosts.Y * StampPostPitch.Y);
            NumIndices = (int)(StampPostPitch.X / SourceChipletPitch.X * (StampPostPitch.Y / SourceChipletPitch.Y));

            XElement clean = doc.Element("ProcessParameters").Element("Clean");
            CleaningTapeOrigin = new PointF(float.Parse(clean.Element("CleanXOrigin").Value), float.Parse(clean.Element("CleanYOrigin").Value));
        }

        public static bool LoadConfig()
        {
            if (!File.Exists(ConfigPath))
            {
                MessageBox.Show("Config File Not Present - PrintSim Unavailable");
                return false;
            }

            XDocument doc = XDocument.Load(ConfigPath);

            ToolName = doc.Element("config").Element("Printer").Value;

            SourceWaferCenter = new PointF(float.Parse(doc.Element("config").Element("SourceWaferOriginX").Value), float.Parse(doc.Element("config").Element("SourceWaferOriginY").Value));
            TargetWaferCenter = new PointF(float.Parse(doc.Element("config").Element("TargetWaferOriginX").Value), float.Parse(doc.Element("config").Element("TargetWaferOriginY").Value));
            SourceDiameter = float.Parse(doc.Element("config").Element("SourceWaferSize").Value);
            TargetDiameter = float.Parse(doc.Element("config").Element("TargetWaferSize").Value);
            StageRange = new PointF(float.Parse(doc.Element("config").Element("MaxStageRangeX").Value), float.Parse(doc.Element("config").Element("MaxStageRangeY").Value));
            CleanConfigOrigin = new PointF(float.Parse(doc.Element("config").Element("CleanTapeOriginX").Value), float.Parse(doc.Element("config").Element("CleanTapeOriginY").Value));
            CleanConfigSize = new SizeF(float.Parse(doc.Element("config").Element("CleanTapeZoneLength").Value), float.Parse(doc.Element("config").Element("CleanTapeZoneWidth").Value));
            return true;
        }
    }
}
