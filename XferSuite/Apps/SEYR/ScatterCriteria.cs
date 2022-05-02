using System.Collections.Generic;
using System.Drawing;

namespace XferSuite.Apps.SEYR
{
    public class ScatterCriteria
    {
        public List<double> X { get; set; } = new List<double>();
        public List<double> Y { get; set; } = new List<double>();
        public string Name { get; set; }
        public Color Color { get; set; } = Color.Transparent;
        public ScatterCriteria(string name)
        {
            Name = name;
        }
        public void Reset()
        {
            X.Clear();
            Y.Clear();
            Color = Color.Transparent;
        }
    }
}
