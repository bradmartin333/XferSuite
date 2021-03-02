using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XferHelper;

namespace XferSuite
{
    public partial class MetroGraphs : Form
    {
        private float _TargetSigma = 1.5F;
        [
            Category("User Parameters"),
            Description("Print 3 Sigma values above this will be marked red"),
            DisplayName("Target 3 Sigma")
        ]
        public float TargetSigma
        {
            get => _TargetSigma;
            set
            {
                _TargetSigma = value;
                MakePlots();
            }
        }

        private float _TargetYield = 98F;
        [
            Category("User Parameters"),
            Description("Print %Yield below this will be marked red"),
            DisplayName("Target %Yield")
        ]
        public float TargetYield
        {
            get => _TargetYield;
            set
            {
                _TargetYield = value;
                MakePlots();
            }
        }

        private float _Outliers = 0F;
        [
            Category("User Parameters"),
            Description("Positions within this range of the Threshold will be plotted, but not incorporated into the calculated statistics"),
            DisplayName("Outliers Filter")
        ]
        public float Outliers
        {
            get => _Outliers;
            set
            {
                _Outliers = value;
                MakePlots();
            }
        }

        private float _Threshold = 1.5F;
        [
            Category("User Parameters"),
            Description("Positions with placement error greater than this value will be filtered out of the plotted data")
        ]
        public float Threshold
        {
            get => _Threshold;
            set
            {
                _Threshold = value;
                MakePlots();
            }
        }

        private bool _UseParams = false;
        [
            Category("User Parameters"),
            Description("Use the Threshold and Outliers values entered here"),
            DisplayName("Use Custom Parameters")
        ]
        public bool UseParams
        {
            get => _UseParams;
            set
            {
                _UseParams = value;
                MakePlots();
            }
        }

        public MetroGraphs(Metro.Position[] data)
        {
            InitializeComponent();
            _data = data;

            string[] indices = Metro.prints(data);
            foreach (string index in indices)
            {
                if (!prints.Contains(index))
                {
                    prints.Add(index);
                }
            }

            MakePlots();
        }

        private Metro.Position[] _data;
        List<string> prints = new List<string>();

        private void MakePlots()
        {

        }

        private void MakeXYScatter()
        {

        }

        private void MakeXYDist()
        {

        }

        private void MakeYield()
        {

        }

        private void MakeXError(int i, Color color)
        {

        }

        private void MakeYError(int i, Color color)
        {

        }

        private void MakeX3Sig()
        {

        }

        private void MakeY3Sig()
        {

        }

        private void FillArray(ref double[] arr, int num)
        {

        }
    }
}
