using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace XferSuite.Apps.SEYR
{
    public partial class RegionBrowser : Form
    {
        private readonly ParseSEYR PS;
        private readonly Inspection Inspection;
        private readonly Project Project;
        private Size CellSize;
        private Point ExcelStart;
        private TableLayoutPanel TLP;
        private List<PictureBox> PictureBoxes;
        private bool LastPF = false;
        private Point LastClick = NullClick;
        private static Point NullClick = new Point(-1, -1);

        public RegionBrowser(ParseSEYR parseSEYR)
        {
            InitializeComponent();
            FormClosing += RegionBrowser_FormClosing;
            KeyDown += RegionBrowser_KeyDown;
            Project = ParseSEYR.Project;
            PS = parseSEYR;
            ExcelStart = new Point(PS.ExcelLeftStart, PS.ExcelTopStart);
            Text = ParseSEYR.FileName;
            Inspection = new Inspection(Text);
            SetupTLP(PS.CbxPassFail.Checked);
            Show();
        }

        private void RegionBrowser_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    ShiftInspection(new Point(0, -1));
                    break;
                case Keys.Left:
                case Keys.A:
                    ShiftInspection(new Point(-1, 0));
                    break;
                case Keys.Down:
                case Keys.S:
                    ShiftInspection(new Point(0, 1));
                    break;
                case Keys.Right:
                case Keys.D:
                    ShiftInspection(new Point(1, 0));
                    break;
                case Keys.F:
                    IEnumerable<ParseSEYR> matches = Application.OpenForms.OfType<ParseSEYR>().Where(x => x.Text == Text);
                    if (matches.Any()) matches.First().BringToFront();
                    break;
                default:
                    break;
            }
        }

        private void RegionBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            PS.Data.Where(x => x.Form != null).ToList().ForEach(x => x.Form.Close());
            Inspection.Close();
        }

        private void SetupTLP(bool showPF)
        {
            LastPF = showPF;
            TLP = new TableLayoutPanel() { Dock = DockStyle.Fill, };
            Controls.Add(TLP);

            PictureBoxes = new List<PictureBox>();

            var IDs = PS.Sheets.Where(x => !x.Ignore).Select(s => s.ID).ToList();
            var RRs = IDs.Select(id => id.Item1).Distinct();
            var RCs = IDs.Select(id => id.Item2).Distinct();

            int rowMin = RRs.Min();
            int rowMax = RRs.Max();
            int rowRange = rowMax - rowMin + 1;

            int colMin = RCs.Min();
            int colMax = RCs.Max();
            int colRange = colMax - colMin + 1;

            CellSize = new Size(
                (int)Math.Floor(100 / (double)rowRange), 
                (int)Math.Floor(100 / (double)colRange));

            TLP.ColumnStyles.Clear();
            TLP.RowStyles.Clear();
            TLP.ColumnCount = colRange + 2;
            TLP.RowCount = (rowRange * 2) + 2;

            TLP.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // "RC"
            TLP.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // RC val

            int rowIdx = 0;
            int colIdx = 0;

            Size imageSize = Size.Empty;

            for (int i = colMin; i <= colMax; i++)
            {
                TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, CellSize.Width)); // This column
                for (int j = rowMin; j <= rowMax; j++)
                {
                    if (i == colMin) // New Row
                    {
                        TLP.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        TLP.RowStyles.Add(new RowStyle(SizeType.Percent, CellSize.Height));
                        TLP.Controls.Add(TLPLabel(j.ToString()), 1, TLP.RowCount - 2 - ((j - rowMin) * 2) - 1);
                    }
                    
                    DataSheet[] sheets = PS.Sheets.Where(s => s.ID == (j, i) && !s.Ignore).ToArray();
                    if (sheets.Any())
                    {
                        DataSheet sheet = sheets.First();
                        var bmpInfo = sheet.GetBitmap(showPF);
                        PictureBox pictureBox = TLPPictureBox(sheet.ID);
                        PictureBoxes.Add(pictureBox);
                        pictureBox.BackgroundImage = bmpInfo.Item1;
                        if (imageSize.IsEmpty) imageSize = bmpInfo.Item1.Size;
                        Point thisCell = new Point(i - colMin + 2, (-2 * (j - rowMin - rowRange)) - 2);
                        if (showPF) 
                            TLP.Controls.Add(TLPLabel($"{(PS.ShowYieldBrackets ? "┏ " : "")}{bmpInfo.Item2}{(PS.ShowYieldBrackets ? " ┓" : "")}", true), 
                                thisCell.X, thisCell.Y);
                        TLP.Controls.Add(pictureBox, thisCell.X, thisCell.Y + 1);
                    }

                    rowIdx++;
                }
                colIdx++;
            }

            TLP.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            TLP.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            for (int i = 1; i < colRange + 1; i++)
                TLP.Controls.Add(TLPLabel(i.ToString()), i + 1, TLP.RowCount - 1);

            Label RRlabel = TLPLabel("RR");
            TLP.Controls.Add(RRlabel, 0, 0);
            TLP.SetRowSpan(RRlabel, TLP.RowCount - 2);

            Label RClabel = TLPLabel("RC");
            TLP.Controls.Add(RClabel, 2, TLP.RowCount);
            TLP.SetColumnSpan(RClabel, colRange);

            SetSize(imageSize, rowRange, colRange);
        }

        private void SetSize(Size imageSize, int rowRange, int colRange)
        {
            double rangeX = imageSize.Width * colRange * Project.PitchX;
            double rangeY = imageSize.Height * rowRange * Project.PitchY;
            Size defaultSize = new Size(PS.PlotSize, PS.PlotSize);
            Size scaledSize = defaultSize;
            if (rangeX < rangeY)
                scaledSize = new Size((int)(defaultSize.Width * (rangeX / rangeY)), defaultSize.Height);
            else if (rangeY < rangeX)
                scaledSize = new Size(defaultSize.Width, (int)(defaultSize.Height * (rangeY / rangeX)));
            Size = scaledSize;
        }

        private Label TLPLabel(string txt, bool percentage = false)
        {
            Label lbl = new Label()
            {
                Text = txt,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
            };
            lbl.Font = percentage ? PS.YieldFont : PS.RCFont;
            return lbl;
        }

        private PictureBox TLPPictureBox((int, int) ID)
        {
            PictureBox pictureBox = new PictureBox()
            {
                Dock = DockStyle.Fill,
                BackgroundImageLayout = ImageLayout.Stretch,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = ID,
                Cursor = Cursors.Cross,
            };
            pictureBox.MouseLeave += PictureBox_MouseLeave;
            pictureBox.MouseWheel += PictureBox_MouseWheel;
            pictureBox.MouseUp += PictureBox_MouseUp;
            return pictureBox;
        }

        public void TogglePF(bool showPF)
        {
            Controls.Remove(TLP);
            SetupTLP(showPF);
        }

        #region PictureBox Methods

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pbx = ((PictureBox)sender);
            TableLayoutPanelCellPosition tlpPosition = TLP.GetCellPosition(pbx);
            TLP.ColumnStyles[tlpPosition.Column].Width = CellSize.Width;
            TLP.RowStyles[tlpPosition.Row].Height = CellSize.Height;
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            PictureBox pbx = ((PictureBox)sender);
            TableLayoutPanelCellPosition tlpPosition = TLP.GetCellPosition(pbx);
            float newWid = (float)(TLP.ColumnStyles[tlpPosition.Column].Width + (e.Delta / TLP.ColumnCount));
            float newHgt = (float)(TLP.RowStyles[tlpPosition.Row].Height + (e.Delta / TLP.RowCount));
            if (newWid >= CellSize.Width && newHgt >= CellSize.Height)
            {
                TLP.ColumnStyles[tlpPosition.Column].Width = newWid;
                TLP.RowStyles[tlpPosition.Row].Height = newHgt;
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            ContextMenuStrip.Tag = ((PictureBox)sender).Tag;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    Point location = StretchMousePos(e.Location);
                    OpenInspection(location);
                    break;
                case MouseButtons.Right:
                    ContextMenuStrip.Show(((PictureBox)sender).PointToScreen(e.Location));
                    break;
                case MouseButtons.Middle:
                    OpenImage();
                    break;
                default:
                    break;
            }
        }

        private void ShiftInspection(Point shift)
        {
            if (LastClick == NullClick) return;
            Point p = new Point(LastClick.X + shift.X, LastClick.Y + shift.Y);
            OpenInspection(p);
        }

        private void OpenInspection(Point p)
        {
            PictureBox thisPBX = GetActivePictureBox();
            DataSheet thisSheet = GetActiveSheet();
            HighightPoint(p, thisPBX);
            (DataEntry[] all, Criteria criterion) = thisSheet.GetLocation(p);
            if (all != null)
            {
                DataEntry[] matches = all.Where(x => x.Image != null).ToArray();
                if (matches.Any())
                    Inspection.Set(all, matches, criterion);
                else
                    Inspection.Hide();
                Text = all[0].Location();
                LastClick = p;
                Focus();
            }
        }

        private void OpenEntireWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage(true);
        }

        private void OpenSelectedRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void OpenImage(bool entireImage = false)
        {
            string path = $@"{Path.GetTempPath()}RBimg.png";
            if (entireImage)
                GetEntireBitmap().Save(path);
            else
                GetActiveBitmap().Save(path);
            Process.Start(path);
        }

        private Bitmap GetEntireBitmap()
        {
            Bitmap bmp = new Bitmap(TLP.Width, TLP.Height);
            TLP.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            return bmp;
        }

        private void CopyEntireWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new Utility.HourGlass(false))
                Clipboard.SetImage(GetEntireBitmap());
        }

        private void CopySelectedRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new Utility.HourGlass(false))
                Clipboard.SetImage(GetActiveBitmap());
        }

        private void ToolStripMenuCopyCSV_Click(object sender, EventArgs e)
        {
            using (new Utility.HourGlass(false))
            {
                string data = GetActiveSheet().GetCSV(PS.PlottedCriteria, LastPF);
                string footer = LastPF ? "\n" : ('\n' + string.Join("\n", PS.PlottedCriteria.Select(x => $"{x.ID}\t{x.LegendEntry}").ToArray()));
                Clipboard.SetText(data + footer);
            }
        }

        private void RenderAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new Utility.HourGlass(false))
                PictureBoxes.ForEach(p => RenderPictureBox(p));
        }

        private void RenderSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new Utility.HourGlass(false))
                RenderPictureBox(GetActivePictureBox());
        }

        private void ClickableAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (new Utility.HourGlass(false))
                PictureBoxes.ForEach(p => p.BackgroundImage = PS.Sheets.Where(s => s.ID == ((int, int))p.Tag).First().GetBitmap(LastPF).Item1);
        }

        private void ClickableSelectedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (new Utility.HourGlass(false))
                GetActivePictureBox().BackgroundImage = GetActiveSheet().GetBitmap(LastPF).Item1;
        }

        private void IgnoreSelectedRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new Utility.HourGlass(false))
            {
                GetActiveSheet().Ignore = true;
                Controls.Remove(TLP);
                SetupTLP(LastPF);
            }
        }

        private void HighightPoint(Point location, PictureBox pictureBox)
        {
            try
            {
                Bitmap bmp = new Bitmap(pictureBox.BackgroundImage.Width, pictureBox.BackgroundImage.Height);
                bmp.SetPixel(location.X, location.Y, Color.HotPink);
                pictureBox.Image = bmp;
            }
            catch (Exception)
            {
                pictureBox.Image = null;
            }
        }

        private Bitmap GetActiveBitmap()
        {
            return (Bitmap)GetActivePictureBox().BackgroundImage;
        }

        private PictureBox GetActivePictureBox()
        {
            foreach (PictureBox pictureBox in PictureBoxes)
                pictureBox.Image = null;
            return PictureBoxes.Where(x => x.Tag == ContextMenuStrip.Tag).First();
        }

        private DataSheet GetActiveSheet()
        {
            return PS.Sheets.Where(x => x.ID == ((int, int))ContextMenuStrip.Tag).First();
        }

        private Point StretchMousePos(Point p)
        {
            PictureBox pictureBox = GetActivePictureBox();
            Size pbx = pictureBox.Size;
            Size img = pictureBox.BackgroundImage.Size;
            return new Point(
                (int)Math.Floor(img.Width * p.X / (double)pbx.Width),
                (int)Math.Floor(img.Height * p.Y / (double)pbx.Height));
        }

        private void RenderPictureBox(PictureBox pictureBox)
        {
            Bitmap newimg = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(newimg))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(pictureBox.BackgroundImage, new Rectangle(Point.Empty, newimg.Size));
            }
            pictureBox.BackgroundImage = newimg;
        }

        #endregion

        #region Cycle File

        private void MakeCycleFileSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeCycleFile(new List<DataSheet>() { GetActiveSheet() });
        }

        private void MakeCycleFileAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeCycleFile(PS.Sheets);
        }

        private void MakeCycleFile(List<DataSheet> sheets)
        {
            using (new Utility.HourGlass(false))
            {
                int idx = 0;
                string file = string.Empty;
                foreach (DataSheet sheet in sheets)
                {
                    string lines = sheet.CreateCycleFile(ref idx);
                    ApplyDelimeter(ref lines);
                    file += lines;
                }
                _ = new CycleFileViewer(MakeCycleFileHeader(), file);
            }
        }

        private string MakeCycleFileHeader()
        {
            string output = "UniqueID, Pick.WaferID, Pick.RegionRow, Pick.RegionColumn, Pick.Row, Pick.Column, Pick.Index, Place.WaferID, Place.RegionRow, Place.RegionColumn, Place.Row, Place.Column\n";
            ApplyDelimeter(ref output);
            return output;
        }

        private void ApplyDelimeter(ref string txt)
        {
            switch (PS.FileDelimeter)
            {
                case ParseSEYR.Delimeter.Tab:
                    txt = txt.Replace(", ", "\t");
                    break;
                case ParseSEYR.Delimeter.Space:
                    txt = txt.Replace(", ", " ");
                    break;
                case ParseSEYR.Delimeter.Comma:
                default:
                    break;
            }
        }

        #endregion

        #region Excel Export

        private void OpenExcelSelectedRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenInExcel(new List<DataSheet>() { GetActiveSheet() });
        }

        private void OpenExcelEntireWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenInExcel(PS.Sheets);
        }

        private void OpenInExcel(List<DataSheet> sheets)
        {
            string path = $@"{Path.GetTempPath()}SEYR_{Text}.xlsx";

            if (File.Exists(path) && IsFileLocked(path))
            {
                MessageBox.Show($"{path} is in use.\nClose Excel and try again.", "SEYR Open in Excel");
                return;
            }

            using (new Utility.HourGlass(false))
            {
                Excel._Application xl = new Excel.Application();
                Excel._Workbook wb = xl.Workbooks.Add(Type.Missing);
                Excel._Worksheet ws = wb.Sheets[1];

                DataSheet[] sheetsCopy = (DataSheet[])sheets.ToArray().Clone();
                sheetsCopy = sheetsCopy.OrderBy(x => x.ID.Item1).ThenBy(x => x.ID.Item2).ToArray();

                for (int i = sheetsCopy.Length - 1; i >= 0; i--)
                {
                    if (i != sheetsCopy.Length - 1) ws = wb.Sheets.Add();
                    Point pointID = sheetsCopy[i].PointID;
                    ws.Name = $"C{pointID.Y}R{pointID.X}";

                    object[,] data = sheetsCopy[i].GetData(LastPF);
                    var startCell = ws.Cells[ExcelStart.Y, ExcelStart.X];
                    var endCell = ws.Cells[data.GetLength(0) + ExcelStart.Y - 1, data.GetLength(1) + ExcelStart.X - 1];
                    var writeRange = ws.Range[startCell, endCell];
                    writeRange.Value = data;

                    if (!LastPF)
                    {
                        int[] IDs = PS.PlottedCriteria.Select(x => x.ID).ToArray();
                        string[] legendStrings = PS.PlottedCriteria.Select(x => x.LegendEntry).ToArray();
                        for (int j = 0; j < PS.PlottedCriteria.Count; j++)
                        {
                            ((Excel.Range)ws.Cells[data.GetLength(0) + 1 + j + ExcelStart.Y, ExcelStart.X]).Value = IDs[j];
                            ((Excel.Range)ws.Cells[data.GetLength(0) + 1 + j + ExcelStart.Y, 1 + ExcelStart.X]).Value = legendStrings[j];
                        }
                    }

                    Excel.Range used = ws.UsedRange;
                    used.EntireColumn.ColumnWidth = 5;
                    Excel.ColorScale cs = used.Cells.FormatConditions.AddColorScale(3);
                    cs.ColorScaleCriteria[1].Type = Excel.XlConditionValueTypes.xlConditionValueLowestValue;
                    cs.ColorScaleCriteria[1].FormatColor.Color = 0x001403FC;  // Blue
                    cs.ColorScaleCriteria[2].Type = Excel.XlConditionValueTypes.xlConditionValuePercentile;
                    cs.ColorScaleCriteria[2].Value = 50;
                    cs.ColorScaleCriteria[2].FormatColor.Color = 0x00FC0303;  // Red
                    cs.ColorScaleCriteria[3].Type = Excel.XlConditionValueTypes.xlConditionValueHighestValue;
                    cs.ColorScaleCriteria[3].FormatColor.Color = 0x0003FC1C;  // Green
                }

                if (File.Exists(path)) File.Delete(path);
                wb.SaveAs(path, 51, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                wb.Close(true, Type.Missing, Type.Missing);
                xl.Quit();
            }

            Process.Start(path);
        }

        protected virtual bool IsFileLocked(string path)
        {
            FileInfo file = new FileInfo(path);
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region SEYRUP Export

        private void ExportSEYRUPSelectedRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportSEYRUP(new List<DataSheet>() { GetActiveSheet() });
        }

        private void ExportSEYRUPEntireWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportSEYRUP(PS.Sheets);
        }

        private void ExportSEYRUP(List<DataSheet> sheets)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = "Choose a directory for the SEYRUP files to be exported to",
                ShowNewFolderButton = true,
                SelectedPath = PS.ActiveDirectory,
            };
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < sheets.Count; i++)
                {
                    PS.ToggleInfo($"Saving Files {i + 1}/{sheets.Count} ...", Color.Bisque);
                    DataEntry[] data = sheets[i].GetEntries();
                    string reportPath = PS.ReportPath.Replace(".txt", $"{sheets[i].ID}.txt");
                    using (StreamWriter stream = new StreamWriter(reportPath))
                    {
                        stream.WriteLine(DataEntry.Header);
                        foreach (DataEntry d in data)
                            stream.WriteLine(d.Raw);
                    }
                    PS.ExportSEYRUP(reportPath, PS.ProjectPath, fbd.SelectedPath + $@"\{sheets[i].ID}.seyrup");
                }
            }
        }

        #endregion

        #region Export Composite

        private void ExportCompositeSelectedRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportComposite(new List<DataSheet>() { GetActiveSheet() });
        }

        private void ExportCompositeEntireWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportComposite(PS.Sheets);
        }

        private void ExportComposite(List<DataSheet> sheets)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = "Choose a directory for the composite images to be exported to",
                ShowNewFolderButton = true,
                SelectedPath = PS.ActiveDirectory,
            };
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Size emptySize = new Size(1, 1);
                Size margin = new Size(PS.CompositeXMargin, PS.CompositeYMargin);
                string failMsg = string.Empty;
                for (int i = 0; i < sheets.Count; i++)
                {
                    PS.ToggleInfo($"Exporting images {i + 1}/{sheets.Count} ...", Color.Bisque);
                    Bitmap bmp = sheets[i].MakeComposite(margin);
                    if (bmp.Size == emptySize)
                        failMsg += $"{sheets[i].ID}\n";
                    else
                    {
                        string path = fbd.SelectedPath + $@"\{Text}_{sheets[i].ID}.png";
                        int idx = 2;
                        while (File.Exists(path))
                        {
                            if (idx > 2)
                                path = path.Replace($"_{idx - 1}.png", $"_{idx}.png");
                            else
                                path = path.Replace(".png", $"_{idx}.png");
                            idx++;
                        }
                        bmp.Save(path);
                    }
                }
                PS.ToggleInfo("Plot", Color.LightBlue);
                if (!string.IsNullOrEmpty(failMsg))
                {
                    failMsg = "These regions could not be exported:\n" + failMsg;
                    MessageBox.Show(failMsg, "SEYR Export Composite");
                }
            }
        }

        #endregion

        #region Copy Data Rows

        private void CopyDataRowsSelectedRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyDataRows(new List<DataSheet>() { GetActiveSheet() });
        }

        private void CopyDataRowsEntireWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyDataRows(PS.Sheets);
        }

        private void CopyDataRows(List<DataSheet> sheets)
        {
            using (new Utility.HourGlass(false))
            {
                string data = "ImageNumber, X, Y, RR, RC, R, C, SR, SC, TileR, TileC, CycleR, CycleC, State, ID, Legend";
                List<string> names = PS.PlottedCriteria.OrderByDescending(x => x.ID).First().LegendEntry.Split(' ').ToList();
                names.ForEach(x => data += $", {x}");
                data += '\n';
                foreach (DataSheet sheet in sheets)
                    data += sheet.GetDataRows(names);
                ApplyDelimeter(ref data);
                Clipboard.SetText(data);
            }
        }

        #endregion
    }
}
