using System.Collections.Generic;
using System.Linq;

namespace XferSuite.Apps.SEYR
{
    public class Criteria
    {
        public static ScottPlot.Drawing.Palette Palette = ScottPlot.Palette.OneHalf;
        public System.Drawing.Color Color { get; set; }
        public int ID { get; set; } = 0;
        public string LegendEntry { get; set; } = "Null";
        public bool Pass { get; set; } = true;
        public bool Override { get; set; } = false;

        public Criteria(DataEntry[] data)
        {
            data = data.Where(x => !x.Feature.Ignore).ToArray();
            var redundantGroups = data.GroupBy(x => x.Feature.RedundancyGroup);
            foreach (var group in redundantGroups)
            {
                Pass = true;
                var needOneGroups = group.ToArray().GroupBy(x => x.Feature.NeedOneGroup).ToArray();
                for (int i = 0; i < needOneGroups.Length; i++)
                {
                    DataEntry[] needOneEntries = needOneGroups[i].ToArray();
                    if (needOneEntries.Where(x => x.State).Any())
                    {
                        ID += (i + 1) * (i + 1);
                        if (LegendEntry == "Null") LegendEntry = string.Empty;
                        LegendEntry += $"{group.Key}{needOneGroups[i].Key} ";
                    }
                    else
                        Pass = false;
                }
            }
        }

        public void TryAppend(ref List<Criteria> criteria)
        {
            var match = criteria.Where(x => x.ID == ID).ToArray();
            if (!match.Any())
            {
                if (!Override) Color = Palette.GetColor(criteria.Count + 1);
                criteria.Add(this);
            }
            else
                if (!Override) Color = match[0].Color;
        }
    }
}
