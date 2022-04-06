using System.Collections.Generic;

namespace XferSuite.Apps.SEYR
{
    public class PlotOrderElement
    {
        public string Name { get; set; }

        public static List<PlotOrderElement> GenerateDefaults()
        {
            return new List<PlotOrderElement>() {
                new PlotOrderElement() { Name = "Fail" },
                new PlotOrderElement() { Name = "Pass" }, };
        }
    }
}
