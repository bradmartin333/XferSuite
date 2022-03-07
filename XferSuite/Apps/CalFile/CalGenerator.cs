using System.Windows.Forms;

namespace XferSuite
{
    public partial class CalGenerator : Form
    {
        private int XRange { get; set; }
        private int YRange { get; set; }
        private string XAxis { get; set; }
        private string YAxis { get; set; }
        private string ZAxis { get; set; }
        private string ZCAxis { get; set; }
        private int Increment { get; set; }
        private int XSteps { get; set; }
        private int YSteps { get; set; }
        private double[,] Data { get; set; }

        public CalGenerator()
        {
            InitializeComponent();
            Show();
        }

        private void SaveA3200CalFile(string path)
        {
            XSteps = XRange / Increment;
            YSteps = YRange / Increment;

            string header = string.Format(":START2D {0} {1} {2} {3} -{4} -{4} {5}\n:START2D POSUNIT=METRIC CORUNIT=METRIC\n\n",
                XAxis,
                YAxis,
                ZAxis,
                ZCAxis,
                Increment, XSteps + 2);

            string body = BorderLine();
            for (int j = 0; j < YSteps; j++)
            {
                body += CalStr(0.0);
                for (int i = 0; i < XSteps; i++)
                    body += CalStr(Data[j, i]);
                body += CalStr(0.0);
                TabToLine(ref body);
            }
            body += BorderLine();

            string footer = "\n:END";

            string output = header + body + footer;
        }

        private string CalStr(double z)
        {
            return string.Format("{0:#,0.000}\t{0:#,0.000}\t", z);
        }

        private void TabToLine(ref string s)
        {
            int place = s.LastIndexOf('\t');
            if (place == -1)
                return;
            s = s.Remove(place, 1).Insert(place, "\n");
        }

        private string BorderLine()
        {
            string line = "";
            for (int i = 0; i < XSteps + 2; i++)
                line += CalStr(0.0);
            TabToLine(ref line);
            return line;
        }
    }
}
