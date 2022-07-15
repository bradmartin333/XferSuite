using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace XferSuite.Apps.SEYR
{
    [Serializable()]
    public class Criteria
    {
        [XmlElement("Color")]
        public System.Drawing.Color Color { get; set; }
        [XmlElement("ID")]
        public int ID { get; set; } = 0;
        [XmlElement("LegendEntry")]
        public string LegendEntry { get; set; } = "Null";
        [XmlElement("Pass")]
        public bool Pass { get; set; } = true;

        public static ScottPlot.Drawing.Palette Palette = ScottPlot.Palette.OneHalf;
        public bool Override { get; set; } = false;

        public Criteria() { }

        public Criteria(DataEntry[] data)
        {
            data = data.Where(x => !x.Feature.Ignore).ToArray();
            var redundantGroups = data.GroupBy(x => x.Feature.RedundancyGroup);
            bool pass = false;
            foreach (var group in redundantGroups)
            {
                bool innerPass = true;
                var needOneGroups = group.ToArray().GroupBy(x => x.Feature.NeedOneGroup).ToArray();
                for (int i = 0; i < needOneGroups.Length; i++)
                {
                    DataEntry[] needOneEntries = needOneGroups[i].ToArray();
                    if (needOneEntries.Where(x => x.State).Any())
                    {
                        ID += (i + 1) * (i + 1);
                        if (LegendEntry == "Null") LegendEntry = string.Empty;
                        LegendEntry += $"{(string.IsNullOrEmpty(group.Key) ? "" : $"{group.Key}_")}{needOneGroups[i].Key} ";
                    }
                    else
                        innerPass = false;
                }
                if (innerPass) pass = true;
            }
            Pass = pass;
            LegendEntry = LegendEntry.TrimEnd(new char[] { ' ' });
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
