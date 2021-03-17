using System.Drawing;
using System.Xml.Linq;

namespace XferSuite
{
    public static class Parameters
    {
        public static string RecipeName = "NoRecipe";
        public static string ToolName = "NoTool";

        // Source
        //public static PointF SourceChiplets;
        public static PointF SourceChipletPitch;
        public static PointF SourceClusters;
        public static PointF SourceClusterPitch;
        public static PointF SourceRegions;
        public static PointF SourceRegionPitch;
        public static PointF SourceOrigin;

        // Target
        public static PointF TargetPrints;
        public static PointF TargetPrintPitch;
        public static PointF TargetClusters;
        public static PointF TargetClusterPitch;
        public static PointF TargetOrigin;

        // Stamp
        public static PointF StampPosts;
        public static PointF StampPostPitch;

        // Tool
        public static PointF SourceWaferCenter;
        public static PointF TargetWaferCenter;
        public static float SourceDiameter;
        public static float TargetDiameter;
        public static PointF StageRange;

        public static void LoadRecipe(string path)
        {
            XDocument doc = XDocument.Load(path);

            XElement recipe = doc.Element("ProcessParameters").Element("Recipe");
            RecipeName = recipe.Element("Name").Value;

            XElement source = doc.Element("ProcessParameters").Element("Source");
            //SourceChiplets = new PointF(float.Parse(source.Element("SourceXChiplets").Value), float.Parse(source.Element("SourceYChiplets").Value));
            SourceChipletPitch = new PointF(float.Parse(source.Element("SourceXChipletPitch").Value), float.Parse(source.Element("SourceYChipletPitch").Value));
            SourceClusters = new PointF(float.Parse(source.Element("SourceXClusters").Value), float.Parse(source.Element("SourceYClusters").Value));
            SourceClusterPitch = new PointF(float.Parse(source.Element("SourceXClusterPitch").Value), float.Parse(source.Element("SourceYClusterPitch").Value));
            SourceRegions = new PointF(float.Parse(source.Element("SourceXRegions").Value), float.Parse(source.Element("SourceYRegions").Value));
            SourceRegionPitch = new PointF(float.Parse(source.Element("SourceXRegionsPitch").Value), float.Parse(source.Element("SourceYRegionsPitch").Value));
            SourceOrigin = new PointF(float.Parse(source.Element("SourceR1C1XPosGlobal").Value), float.Parse(source.Element("SourceR1C1YPosGlobal").Value));

            XElement target = doc.Element("ProcessParameters").Element("Target");
            TargetPrints = new PointF(float.Parse(target.Element("TargetXPrints").Value), float.Parse(target.Element("TargetYPrints").Value));
            TargetPrintPitch = new PointF(float.Parse(target.Element("TargetXPrintPitch").Value), float.Parse(target.Element("TargetYPrintPitch").Value));
            TargetClusters = new PointF(float.Parse(target.Element("TargetXClusters").Value), float.Parse(target.Element("TargetYClusters").Value));
            TargetClusterPitch = new PointF(float.Parse(target.Element("TargetXClusterPitch").Value), float.Parse(target.Element("TargetYClusterPitch").Value));
            TargetOrigin = new PointF(float.Parse(target.Element("TargetR1C1XPosGlobal").Value), float.Parse(target.Element("TargetR1C1YPosGlobal").Value));

            XElement stamp = doc.Element("ProcessParameters").Element("Stamp");
            StampPosts = new PointF(float.Parse(stamp.Element("StampXPosts").Value), float.Parse(stamp.Element("StampYPosts").Value));
            StampPostPitch = new PointF(float.Parse(stamp.Element("StampXPostPitch").Value), float.Parse(stamp.Element("StampYPostPitch").Value));
        }

        public static void LoadConfig(string path)
        {
            XDocument doc = XDocument.Load(path);

            ToolName = doc.Element("config").Element("Printer").Value;

            SourceWaferCenter = new PointF(float.Parse(doc.Element("config").Element("SourceWaferOriginX").Value), float.Parse(doc.Element("config").Element("SourceWaferOriginY").Value));
            TargetWaferCenter = new PointF(float.Parse(doc.Element("config").Element("TargetWaferOriginX").Value), float.Parse(doc.Element("config").Element("TargetWaferOriginY").Value));
            SourceDiameter = float.Parse(doc.Element("config").Element("SourceWaferSize").Value);
            TargetDiameter = float.Parse(doc.Element("config").Element("TargetWaferSize").Value);
            StageRange = new PointF(float.Parse(doc.Element("config").Element("MaxStageRangeX").Value), float.Parse(doc.Element("config").Element("MaxStageRangeY").Value));
        }
    }
}
