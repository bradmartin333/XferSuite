namespace XferSuite.XYZscan
{
    partial class Plotter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plotter));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.olv = new BrightIdeasSoftware.FastDataListView();
            this.OlvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pA = new ScottPlot.FormsPlot();
            this.pB = new ScottPlot.FormsPlot();
            this.pC = new ScottPlot.FormsPlot();
            this.pD = new ScottPlot.FormsPlot();
            this.toolStripX = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.comboX = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonFlipX = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxMinX = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxMaxX = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonApplyX = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelStatsX = new System.Windows.Forms.ToolStripLabel();
            this.toolStripY = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.comboY = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonFlipY = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxMinY = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxMaxY = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonApplyY = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelStatsY = new System.Windows.Forms.ToolStripLabel();
            this.toolStripZ = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.comboZ = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonFlipZ = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxMinZ = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxMaxZ = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonApplyZ = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelStatsZ = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
            this.toolStripX.SuspendLayout();
            this.toolStripY.SuspendLayout();
            this.toolStripZ.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.ProgressBar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.olv, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pA, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.pB, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.pC, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.pD, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.toolStripX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStripY, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStripZ, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1231, 784);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressBar.Location = new System.Drawing.Point(3, 3);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(363, 19);
            this.ProgressBar.Step = 1;
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 4;
            // 
            // olv
            // 
            this.olv.AllColumns.Add(this.OlvColumn3);
            this.olv.AllColumns.Add(this.OlvColumn6);
            this.olv.AllColumns.Add(this.OlvColumn1);
            this.olv.AllColumns.Add(this.OlvColumn2);
            this.olv.AllColumns.Add(this.OlvColumn4);
            this.olv.AllColumns.Add(this.OlvColumn5);
            this.olv.AllColumns.Add(this.OlvColumn7);
            this.olv.AllColumns.Add(this.OlvColumn8);
            this.olv.AllColumns.Add(this.OlvColumn9);
            this.olv.CellEditUseWholeCell = false;
            this.olv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OlvColumn3,
            this.OlvColumn6,
            this.OlvColumn1,
            this.OlvColumn2,
            this.OlvColumn4,
            this.OlvColumn5,
            this.OlvColumn7,
            this.OlvColumn8,
            this.OlvColumn9});
            this.olv.Cursor = System.Windows.Forms.Cursors.Default;
            this.olv.DataSource = null;
            this.olv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olv.FullRowSelect = true;
            this.olv.HideSelection = false;
            this.olv.Location = new System.Drawing.Point(3, 28);
            this.olv.Name = "olv";
            this.tableLayoutPanel1.SetRowSpan(this.olv, 4);
            this.olv.ShowGroups = false;
            this.olv.Size = new System.Drawing.Size(363, 753);
            this.olv.TabIndex = 3;
            this.olv.UseCompatibleStateImageBehavior = false;
            this.olv.UseFilterIndicator = true;
            this.olv.UseFiltering = true;
            this.olv.View = System.Windows.Forms.View.Details;
            this.olv.VirtualMode = true;
            // 
            // OlvColumn3
            // 
            this.OlvColumn3.AspectName = "Name";
            this.OlvColumn3.Text = "Name";
            this.OlvColumn3.Width = 370;
            // 
            // OlvColumn6
            // 
            this.OlvColumn6.AspectName = "Index";
            this.OlvColumn6.AspectToStringFormat = "{0}";
            this.OlvColumn6.Text = "Index";
            this.OlvColumn6.Width = 48;
            // 
            // OlvColumn1
            // 
            this.OlvColumn1.AspectName = "ShortDate";
            this.OlvColumn1.AspectToStringFormat = "{0:d}";
            this.OlvColumn1.Text = "Date";
            this.OlvColumn1.Width = 82;
            // 
            // OlvColumn2
            // 
            this.OlvColumn2.AspectName = "Time";
            this.OlvColumn2.AspectToStringFormat = "{0:d}";
            this.OlvColumn2.Text = "Time";
            this.OlvColumn2.Width = 83;
            // 
            // OlvColumn4
            // 
            this.OlvColumn4.AspectName = "Temp";
            this.OlvColumn4.AspectToStringFormat = "{0}°C";
            this.OlvColumn4.Text = "Temp";
            // 
            // OlvColumn5
            // 
            this.OlvColumn5.AspectName = "RH";
            this.OlvColumn5.AspectToStringFormat = "{0}%";
            this.OlvColumn5.Text = "RH";
            // 
            // OlvColumn7
            // 
            this.OlvColumn7.AspectName = "ScanSpeed";
            this.OlvColumn7.AspectToStringFormat = "{0} m/s";
            this.OlvColumn7.Text = "Speed";
            // 
            // OlvColumn8
            // 
            this.OlvColumn8.AspectName = "NumPasses";
            this.OlvColumn8.AspectToStringFormat = "{0}";
            this.OlvColumn8.Text = "# Passes";
            // 
            // OlvColumn9
            // 
            this.OlvColumn9.AspectName = "Threshold";
            this.OlvColumn9.AspectToStringFormat = "{0}%";
            this.OlvColumn9.Text = "Threshold";
            // 
            // pA
            // 
            this.pA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pA.Location = new System.Drawing.Point(372, 78);
            this.pA.Name = "pA";
            this.pA.Size = new System.Drawing.Size(424, 348);
            this.pA.TabIndex = 5;
            this.pA.Tag = "A";
            // 
            // pB
            // 
            this.pB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pB.Location = new System.Drawing.Point(802, 78);
            this.pB.Name = "pB";
            this.pB.Size = new System.Drawing.Size(426, 348);
            this.pB.TabIndex = 6;
            this.pB.Tag = "B";
            // 
            // pC
            // 
            this.pC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pC.Location = new System.Drawing.Point(372, 432);
            this.pC.Name = "pC";
            this.pC.Size = new System.Drawing.Size(424, 349);
            this.pC.TabIndex = 7;
            this.pC.Tag = "C";
            // 
            // pD
            // 
            this.pD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pD.Location = new System.Drawing.Point(802, 432);
            this.pD.Name = "pD";
            this.pD.Size = new System.Drawing.Size(426, 349);
            this.pD.TabIndex = 8;
            this.pD.Tag = "D";
            // 
            // toolStripX
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStripX, 2);
            this.toolStripX.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.comboX,
            this.toolStripButtonFlipX,
            this.toolStripLabel4,
            this.toolStripTextBoxMinX,
            this.toolStripLabel5,
            this.toolStripTextBoxMaxX,
            this.toolStripButtonApplyX,
            this.toolStripLabelStatsX});
            this.toolStripX.Location = new System.Drawing.Point(369, 0);
            this.toolStripX.Name = "toolStripX";
            this.toolStripX.Size = new System.Drawing.Size(862, 25);
            this.toolStripX.TabIndex = 9;
            this.toolStripX.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "X Axis";
            // 
            // comboX
            // 
            this.comboX.Items.AddRange(new object[] {
            "None",
            "X (mm)",
            "Y (mm)",
            "Z (mm)",
            "Height (µm)",
            "Intensity (%)",
            "Z + Height (mm)"});
            this.comboX.MaxDropDownItems = 6;
            this.comboX.Name = "comboX";
            this.comboX.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripButtonFlipX
            // 
            this.toolStripButtonFlipX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFlipX.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFlipX.Image")));
            this.toolStripButtonFlipX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFlipX.Name = "toolStripButtonFlipX";
            this.toolStripButtonFlipX.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFlipX.Tag = "0";
            this.toolStripButtonFlipX.Text = "Flip";
            this.toolStripButtonFlipX.Click += new System.EventHandler(this.toolStripButtonFlip_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel4.Text = "Min";
            // 
            // toolStripTextBoxMinX
            // 
            this.toolStripTextBoxMinX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxMinX.Name = "toolStripTextBoxMinX";
            this.toolStripTextBoxMinX.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel5.Text = "Max";
            // 
            // toolStripTextBoxMaxX
            // 
            this.toolStripTextBoxMaxX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxMaxX.Name = "toolStripTextBoxMaxX";
            this.toolStripTextBoxMaxX.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButtonApplyX
            // 
            this.toolStripButtonApplyX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonApplyX.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonApplyX.Image")));
            this.toolStripButtonApplyX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonApplyX.Name = "toolStripButtonApplyX";
            this.toolStripButtonApplyX.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonApplyX.Text = "Apply";
            this.toolStripButtonApplyX.Click += new System.EventHandler(this.toolStripButtonApply_Click);
            // 
            // toolStripLabelStatsX
            // 
            this.toolStripLabelStatsX.Name = "toolStripLabelStatsX";
            this.toolStripLabelStatsX.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripY
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStripY, 2);
            this.toolStripY.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.comboY,
            this.toolStripButtonFlipY,
            this.toolStripLabel6,
            this.toolStripTextBoxMinY,
            this.toolStripLabel7,
            this.toolStripTextBoxMaxY,
            this.toolStripButtonApplyY,
            this.toolStripLabelStatsY});
            this.toolStripY.Location = new System.Drawing.Point(369, 25);
            this.toolStripY.Name = "toolStripY";
            this.toolStripY.Size = new System.Drawing.Size(862, 25);
            this.toolStripY.TabIndex = 10;
            this.toolStripY.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel2.Text = "Y Axis";
            // 
            // comboY
            // 
            this.comboY.Items.AddRange(new object[] {
            "None",
            "X (mm)",
            "Y (mm)",
            "Z (mm)",
            "Height (µm)",
            "Intensity (%)",
            "Z + Height (mm)"});
            this.comboY.Name = "comboY";
            this.comboY.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripButtonFlipY
            // 
            this.toolStripButtonFlipY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFlipY.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFlipY.Image")));
            this.toolStripButtonFlipY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFlipY.Name = "toolStripButtonFlipY";
            this.toolStripButtonFlipY.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFlipY.Tag = "1";
            this.toolStripButtonFlipY.Text = "Flip";
            this.toolStripButtonFlipY.Click += new System.EventHandler(this.toolStripButtonFlip_Click);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel6.Text = "Min";
            // 
            // toolStripTextBoxMinY
            // 
            this.toolStripTextBoxMinY.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxMinY.Name = "toolStripTextBoxMinY";
            this.toolStripTextBoxMinY.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel7.Text = "Max";
            // 
            // toolStripTextBoxMaxY
            // 
            this.toolStripTextBoxMaxY.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxMaxY.Name = "toolStripTextBoxMaxY";
            this.toolStripTextBoxMaxY.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButtonApplyY
            // 
            this.toolStripButtonApplyY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonApplyY.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonApplyY.Image")));
            this.toolStripButtonApplyY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonApplyY.Name = "toolStripButtonApplyY";
            this.toolStripButtonApplyY.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonApplyY.Text = "Apply";
            this.toolStripButtonApplyY.Click += new System.EventHandler(this.toolStripButtonApply_Click);
            // 
            // toolStripLabelStatsY
            // 
            this.toolStripLabelStatsY.Name = "toolStripLabelStatsY";
            this.toolStripLabelStatsY.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripZ
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStripZ, 2);
            this.toolStripZ.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.comboZ,
            this.toolStripButtonFlipZ,
            this.toolStripLabel9,
            this.toolStripTextBoxMinZ,
            this.toolStripLabel10,
            this.toolStripTextBoxMaxZ,
            this.toolStripButtonApplyZ,
            this.toolStripLabelStatsZ});
            this.toolStripZ.Location = new System.Drawing.Point(369, 50);
            this.toolStripZ.Name = "toolStripZ";
            this.toolStripZ.Size = new System.Drawing.Size(862, 25);
            this.toolStripZ.TabIndex = 11;
            this.toolStripZ.Text = "toolStrip2";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel3.Text = "Z Axis";
            // 
            // comboZ
            // 
            this.comboZ.Items.AddRange(new object[] {
            "None",
            "X (mm)",
            "Y (mm)",
            "Z (mm)",
            "Height (µm)",
            "Intensity (%)",
            "Z + Height (mm)"});
            this.comboZ.Name = "comboZ";
            this.comboZ.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripButtonFlipZ
            // 
            this.toolStripButtonFlipZ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFlipZ.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFlipZ.Image")));
            this.toolStripButtonFlipZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFlipZ.Name = "toolStripButtonFlipZ";
            this.toolStripButtonFlipZ.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFlipZ.Tag = "2";
            this.toolStripButtonFlipZ.Text = "Flip";
            this.toolStripButtonFlipZ.Click += new System.EventHandler(this.toolStripButtonFlip_Click);
            // 
            // toolStripLabel9
            // 
            this.toolStripLabel9.Name = "toolStripLabel9";
            this.toolStripLabel9.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel9.Text = "Min";
            // 
            // toolStripTextBoxMinZ
            // 
            this.toolStripTextBoxMinZ.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxMinZ.Name = "toolStripTextBoxMinZ";
            this.toolStripTextBoxMinZ.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel10
            // 
            this.toolStripLabel10.Name = "toolStripLabel10";
            this.toolStripLabel10.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel10.Text = "Max";
            // 
            // toolStripTextBoxMaxZ
            // 
            this.toolStripTextBoxMaxZ.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxMaxZ.Name = "toolStripTextBoxMaxZ";
            this.toolStripTextBoxMaxZ.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButtonApplyZ
            // 
            this.toolStripButtonApplyZ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonApplyZ.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonApplyZ.Image")));
            this.toolStripButtonApplyZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonApplyZ.Name = "toolStripButtonApplyZ";
            this.toolStripButtonApplyZ.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonApplyZ.Text = "Apply";
            this.toolStripButtonApplyZ.Click += new System.EventHandler(this.toolStripButtonApply_Click);
            // 
            // toolStripLabelStatsZ
            // 
            this.toolStripLabelStatsZ.Name = "toolStripLabelStatsZ";
            this.toolStripLabelStatsZ.Size = new System.Drawing.Size(0, 22);
            // 
            // Plotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 784);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Plotter";
            this.Text = "XYZ Scan";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
            this.toolStripX.ResumeLayout(false);
            this.toolStripX.PerformLayout();
            this.toolStripY.ResumeLayout(false);
            this.toolStripY.PerformLayout();
            this.toolStripZ.ResumeLayout(false);
            this.toolStripZ.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal BrightIdeasSoftware.FastDataListView olv;
        internal BrightIdeasSoftware.OLVColumn OlvColumn3;
        internal BrightIdeasSoftware.OLVColumn OlvColumn6;
        internal BrightIdeasSoftware.OLVColumn OlvColumn1;
        internal BrightIdeasSoftware.OLVColumn OlvColumn2;
        internal BrightIdeasSoftware.OLVColumn OlvColumn4;
        internal BrightIdeasSoftware.OLVColumn OlvColumn5;
        internal BrightIdeasSoftware.OLVColumn OlvColumn7;
        private BrightIdeasSoftware.OLVColumn OlvColumn8;
        internal System.Windows.Forms.ProgressBar ProgressBar;
        private BrightIdeasSoftware.OLVColumn OlvColumn9;
        private ScottPlot.FormsPlot pA;
        private ScottPlot.FormsPlot pB;
        private ScottPlot.FormsPlot pC;
        private ScottPlot.FormsPlot pD;
        private System.Windows.Forms.ToolStrip toolStripX;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox comboX;
        private System.Windows.Forms.ToolStrip toolStripY;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox comboY;
        private System.Windows.Forms.ToolStrip toolStripZ;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox comboZ;
        private System.Windows.Forms.ToolStripButton toolStripButtonFlipX;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxMinX;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxMaxX;
        private System.Windows.Forms.ToolStripLabel toolStripLabelStatsX;
        private System.Windows.Forms.ToolStripButton toolStripButtonFlipY;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxMinY;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxMaxY;
        private System.Windows.Forms.ToolStripLabel toolStripLabelStatsY;
        private System.Windows.Forms.ToolStripButton toolStripButtonFlipZ;
        private System.Windows.Forms.ToolStripLabel toolStripLabel9;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxMinZ;
        private System.Windows.Forms.ToolStripLabel toolStripLabel10;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxMaxZ;
        private System.Windows.Forms.ToolStripLabel toolStripLabelStatsZ;
        private System.Windows.Forms.ToolStripButton toolStripButtonApplyX;
        private System.Windows.Forms.ToolStripButton toolStripButtonApplyY;
        private System.Windows.Forms.ToolStripButton toolStripButtonApplyZ;
    }
}