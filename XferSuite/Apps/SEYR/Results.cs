using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using static XferSuite.Apps.SEYR.ParseSEYR;
using ScottPlot;
using System.ComponentModel;

namespace XferSuite.Apps.SEYR
{
    public partial class Results : Form
    {
        #region User Parameters

        private int _PassPointSize = 5;
        [Category("User Parameters")]
        public int PassPointSize
        {
            get => _PassPointSize;
            set
            {
                _PassPointSize = value;
                UpdatePlot("Pass point size changed");
            }
        }

        private int _FailPointSize = 5;
        [Category("User Parameters")]
        public int FailPointSize
        {
            get => _FailPointSize;
            set
            {
                _FailPointSize = value;
                UpdatePlot("Fail point size changed");
            }
        }

        #endregion

        private List<Plottable> Plottables;
        private List<PlotOrderElement> PlotOrder;
        List<CustomFeature> CustomFeatures;

        public Results(string title)
        {
            InitializeComponent();
            formsPlot.Plot.Title(title);
        }

        public void UpdateData(ParseSEYR parseSEYR)
        {
            Plottables = parseSEYR.Plottables;
            PlotOrder = parseSEYR.PlotOrder;
            CustomFeatures = parseSEYR.CustomFeatures;
            UpdatePlot("Newly parsed data");
        }

        public void UpdatePlot(string reason)
        {
            if (Plottables.Count == 0) return;
            formsPlot.Plot.Clear();
            foreach (PlotOrderElement plotOrderElement in PlotOrder)
            {
                Plottable[] plottables;
                float thisSize;
                switch (plotOrderElement.Name)
                {
                    case "Pass":
                        thisSize = _PassPointSize;
                        plottables = Plottables.Where(x => string.IsNullOrEmpty(x.CustomTag) && x.Pass).ToArray();
                        break;
                    case "Fail":
                        thisSize = _FailPointSize;
                        plottables = Plottables.Where(x => string.IsNullOrEmpty(x.CustomTag) && !x.Pass).ToArray();
                        break;
                    default:
                        CustomFeature customFeature = CustomFeatures.Where(x => x.Name == plotOrderElement.Name).First();
                        thisSize = customFeature.Size;
                        plottables = Plottables.Where(x => x.CustomTag == customFeature.Name).ToArray();
                        break;
                }
                formsPlot.Plot.AddScatter(
                    plottables.Select(x => x.X).ToArray(),
                    plottables.Select(x => x.Y).ToArray(),
                    plottables[0].Color,
                    markerSize: thisSize,
                    lineStyle: LineStyle.None);
            }
            formsPlot.Refresh();
            LabelStatus.Text = reason;
        }
    }
}
