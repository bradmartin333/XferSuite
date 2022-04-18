using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using XferHelper;

namespace XferSuite.Apps.SEYR
{
    public class Feature
    {
        public static List<(string, PointF)> ProjectInfo = new List<(string, PointF)>();
        public string Name { get; set; }
        public Report.Bucket Bucket { get; set; } = Report.Bucket.Buffer;
        public Report.State[] Requirements { get; set; } = new Report.State[] { Report.State.Pass };
        public List<Feature> Children { get; set; } = new List<Feature>();
        public string FamilyName { get; set; } = "";
        public bool IsChild { get; set; } = false;
        public bool IsParent { get; set; } = false;
        public PointF Location { get; set; } = PointF.Empty;

        public Feature(string name, PointF location)
        {
            Name = name;
            Location = location;
        }

        public static Feature[] GetFeatures(Report.Entry[] data)
        {
            string[] projectNames = ProjectInfo.Select(x => x.Item1).ToArray();
            List<Feature> features = new List<Feature>();
            string[] names = data.Select(x => x.Name).Distinct().ToArray();
            foreach (string name in names)
            {
                if (projectNames.Contains(name))
                    features.Add(new Feature(name, ProjectInfo.Where(x => x.Item1 == name).First().Item2));
                else
                    features.Add(new Feature(name, PointF.Empty));
            }
            return features.ToArray();
        }
    }
}
