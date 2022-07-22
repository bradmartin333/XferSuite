using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite.AdvancedTools
{
    public partial class SwapABGrid : Form
    {
        private static string FileName;
        private string ActiveDirectory;
        private bool HasCriteria = false;
        private bool Swapped = false;
        private readonly string ProjectPath = $@"{Path.GetTempPath()}project.seyr";
        private readonly string ReportPath = $@"{Path.GetTempPath()}SEYRreport.txt";
        private readonly string SwappedReportPath = $@"{Path.GetTempPath()}SEYRreport_swap.txt";
        private readonly string CriteriaPath = $@"{Path.GetTempPath()}SEYRcriteria.txt";

        public SwapABGrid()
        {
            InitializeComponent();
            FormClosing += SwapABGrid_FormClosing;
            DataLoadingWorker.RunWorkerCompleted += DataLoadingWorker_RunWorkerCompleted;
        }

        private void BtnOpenSEYRUP_Click(object sender, EventArgs e)
        {
            string path = MainMenu.OpenFile("Open a SEYRUP file", "SEYRUP file (*.seyrup)|*.seyrup");
            if (string.IsNullOrEmpty(path)) return;
            LoadData(path);
        }

        private void BtnSaveSEYRUP_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog
            {
                Filter = "SEYRUP file(*.seyrup)| *.seyrup",
                Title = "Save SEYRUP File",
                InitialDirectory = ActiveDirectory,
                FileName = $"{FileName}_swapped",
            };
            if (svd.ShowDialog() == DialogResult.OK)
            {
                string exportPath = svd.FileName;
                ToggleInfo("Saving...", Color.Bisque);
                if (File.Exists(exportPath)) File.Delete(exportPath);
                using (ZipArchive zip = ZipFile.Open(exportPath, ZipArchiveMode.Create))
                {
                    zip.CreateEntryFromFile(SwappedReportPath, Path.GetFileName(ReportPath));
                    zip.CreateEntryFromFile(ProjectPath, Path.GetFileName(ProjectPath));
                    if (HasCriteria) zip.CreateEntryFromFile(CriteriaPath, Path.GetFileName(CriteriaPath));
                }
                Close();
            }
        }

        public void ToggleInfo(string info, Color color)
        {
            LblInfo.Text = info;
            LblInfo.BackColor = color;
            BtnSaveSEYRUP.Enabled = info == "Done";
            Application.DoEvents();
        }
        private void SwapABGrid_FormClosing(object sender, FormClosingEventArgs e)
        {
            try  // Exception on close during loading
            {
                File.Delete(ProjectPath);
                File.Delete(ReportPath);
                if (Swapped) File.Delete(SwappedReportPath);
                if (HasCriteria) File.Delete(CriteriaPath);
            }
            catch (Exception) { }
        }

        private void LoadData(string path)
        {
            FileInfo userPath = new FileInfo(path);
            ActiveDirectory = userPath.DirectoryName;
            FileName = userPath.Name.Replace(userPath.Extension, "");

            using (ZipArchive archive = ZipFile.OpenRead(path))
            {
                ExtractFile(ProjectPath, archive);
                ExtractFile(ReportPath, archive);
                HasCriteria = ExtractFile(CriteriaPath, archive);
            }

            ToggleInfo("Loading...", Color.Bisque);
            DataLoadingWorker.RunWorkerAsync();
        }

        private void DataLoadingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (StreamWriter stream = new StreamWriter(ReportPath))
                {
                    using (var sr = new StreamReader(ReportPath))
                    {
                        while (sr.Peek() >= 0)
                        {
                            string[] cols = sr.ReadLine().Split('\t');
                            // validate and swap info here
                            stream.WriteLine(string.Join("\t", cols));
                        }
                    }
                }
                Swapped = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Swap Failed", "XferSuite");
                Close();
            }
        }

        private void DataLoadingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ToggleInfo("Done", Color.LightGreen);
        }

        private bool ExtractFile(string path, ZipArchive archive)
        {
            var matches = archive.Entries.Where(x => x.Name == path.Split('\\').Last());
            if (matches.Any()) matches.First().ExtractToFile(path, true);
            else return false;
            return true;
        }
    }
}
