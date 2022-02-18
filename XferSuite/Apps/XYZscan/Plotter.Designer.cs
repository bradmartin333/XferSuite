namespace XferSuite
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plotter));
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxEqualize = new System.Windows.Forms.CheckBox();
            this.buttonAutoscale = new System.Windows.Forms.Button();
            this.checkBoxShowBestFit = new System.Windows.Forms.CheckBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.olv = new BrightIdeasSoftware.FastDataListView();
            this.olvColumnEdited = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnIndex = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnTemp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnRH = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnSpeed = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnPasses = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnThreshold = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pA = new ScottPlot.FormsPlot();
            this.pB = new ScottPlot.FormsPlot();
            this.pC = new ScottPlot.FormsPlot();
            this.pD = new ScottPlot.FormsPlot();
            this.toolStripX = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.comboX = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonFlipX = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelRangeX = new System.Windows.Forms.ToolStripLabel();
            this.toolStripY = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.comboY = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonFlipY = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel12 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelRangeY = new System.Windows.Forms.ToolStripLabel();
            this.toolStripZ = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.comboZ = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonFlipZ = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel14 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelRangeZ = new System.Windows.Forms.ToolStripLabel();
            this.checkBoxRemoveAngle = new System.Windows.Forms.CheckBox();
            this.buttonExportSelected = new System.Windows.Forms.Button();
            this.checkBoxEraseData = new System.Windows.Forms.CheckBox();
            this.btnRevert = new System.Windows.Forms.Button();
            this.tlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
            this.toolStripX.SuspendLayout();
            this.toolStripY.SuspendLayout();
            this.toolStripZ.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp
            // 
            this.tlp.ColumnCount = 10;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlp.Controls.Add(this.checkBoxEqualize, 6, 0);
            this.tlp.Controls.Add(this.buttonAutoscale, 5, 0);
            this.tlp.Controls.Add(this.checkBoxShowBestFit, 4, 0);
            this.tlp.Controls.Add(this.ProgressBar, 0, 0);
            this.tlp.Controls.Add(this.olv, 0, 1);
            this.tlp.Controls.Add(this.pA, 8, 3);
            this.tlp.Controls.Add(this.pB, 9, 3);
            this.tlp.Controls.Add(this.pC, 8, 4);
            this.tlp.Controls.Add(this.pD, 9, 4);
            this.tlp.Controls.Add(this.toolStripX, 8, 0);
            this.tlp.Controls.Add(this.toolStripY, 8, 1);
            this.tlp.Controls.Add(this.toolStripZ, 8, 2);
            this.tlp.Controls.Add(this.checkBoxRemoveAngle, 7, 0);
            this.tlp.Controls.Add(this.buttonExportSelected, 3, 0);
            this.tlp.Controls.Add(this.checkBoxEraseData, 2, 0);
            this.tlp.Controls.Add(this.btnRevert, 1, 0);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 5;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp.Size = new System.Drawing.Size(1231, 784);
            this.tlp.TabIndex = 0;
            // 
            // checkBoxEqualize
            // 
            this.checkBoxEqualize.AccessibleDescription = "Equalize:_Height axes share a common lower bound";
            this.checkBoxEqualize.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxEqualize.AutoSize = true;
            this.checkBoxEqualize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBoxEqualize.BackgroundImage")));
            this.checkBoxEqualize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkBoxEqualize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxEqualize.FlatAppearance.BorderSize = 0;
            this.checkBoxEqualize.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.checkBoxEqualize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxEqualize.Location = new System.Drawing.Point(357, 3);
            this.checkBoxEqualize.Name = "checkBoxEqualize";
            this.checkBoxEqualize.Size = new System.Drawing.Size(24, 23);
            this.checkBoxEqualize.TabIndex = 19;
            this.checkBoxEqualize.UseVisualStyleBackColor = true;
            this.checkBoxEqualize.CheckedChanged += new System.EventHandler(this.checkBoxEqualize_CheckedChanged);
            // 
            // buttonAutoscale
            // 
            this.buttonAutoscale.AccessibleDescription = "Autoscale:_Discard equalized axes and autoscale all plots";
            this.buttonAutoscale.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAutoscale.BackgroundImage")));
            this.buttonAutoscale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAutoscale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAutoscale.FlatAppearance.BorderSize = 0;
            this.buttonAutoscale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAutoscale.Location = new System.Drawing.Point(327, 3);
            this.buttonAutoscale.Name = "buttonAutoscale";
            this.buttonAutoscale.Size = new System.Drawing.Size(24, 23);
            this.buttonAutoscale.TabIndex = 17;
            this.buttonAutoscale.UseVisualStyleBackColor = true;
            this.buttonAutoscale.Click += new System.EventHandler(this.ButtonAutoscale_Click);
            // 
            // checkBoxShowBestFit
            // 
            this.checkBoxShowBestFit.AccessibleDescription = "Show Best Fit:_Show a third order polynomial trendline and R² value";
            this.checkBoxShowBestFit.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxShowBestFit.AutoSize = true;
            this.checkBoxShowBestFit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBoxShowBestFit.BackgroundImage")));
            this.checkBoxShowBestFit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkBoxShowBestFit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxShowBestFit.FlatAppearance.BorderSize = 0;
            this.checkBoxShowBestFit.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.checkBoxShowBestFit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxShowBestFit.Location = new System.Drawing.Point(297, 3);
            this.checkBoxShowBestFit.Name = "checkBoxShowBestFit";
            this.checkBoxShowBestFit.Size = new System.Drawing.Size(24, 23);
            this.checkBoxShowBestFit.TabIndex = 14;
            this.checkBoxShowBestFit.UseVisualStyleBackColor = true;
            this.checkBoxShowBestFit.CheckedChanged += new System.EventHandler(this.CheckBoxShowBestFit_CheckedChanged);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressBar.Location = new System.Drawing.Point(3, 3);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(198, 23);
            this.ProgressBar.Step = 1;
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 4;
            // 
            // olv
            // 
            this.olv.AllColumns.Add(this.olvColumnEdited);
            this.olv.AllColumns.Add(this.OlvColumnName);
            this.olv.AllColumns.Add(this.OlvColumnIndex);
            this.olv.AllColumns.Add(this.OlvColumnDate);
            this.olv.AllColumns.Add(this.OlvColumnTime);
            this.olv.AllColumns.Add(this.OlvColumnTemp);
            this.olv.AllColumns.Add(this.OlvColumnRH);
            this.olv.AllColumns.Add(this.OlvColumnSpeed);
            this.olv.AllColumns.Add(this.OlvColumnPasses);
            this.olv.AllColumns.Add(this.OlvColumnThreshold);
            this.olv.CellEditUseWholeCell = false;
            this.olv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnEdited,
            this.OlvColumnName,
            this.OlvColumnIndex,
            this.OlvColumnDate,
            this.OlvColumnTime,
            this.OlvColumnTemp,
            this.OlvColumnRH,
            this.OlvColumnSpeed,
            this.OlvColumnPasses,
            this.OlvColumnThreshold});
            this.tlp.SetColumnSpan(this.olv, 8);
            this.olv.Cursor = System.Windows.Forms.Cursors.Default;
            this.olv.DataSource = null;
            this.olv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olv.FullRowSelect = true;
            this.olv.HideSelection = false;
            this.olv.Location = new System.Drawing.Point(3, 32);
            this.olv.Name = "olv";
            this.tlp.SetRowSpan(this.olv, 4);
            this.olv.ShowGroups = false;
            this.olv.Size = new System.Drawing.Size(408, 749);
            this.olv.SmallImageList = this.imageList;
            this.olv.TabIndex = 3;
            this.olv.UseCompatibleStateImageBehavior = false;
            this.olv.UseFilterIndicator = true;
            this.olv.UseFiltering = true;
            this.olv.View = System.Windows.Forms.View.Details;
            this.olv.VirtualMode = true;
            // 
            // olvColumnEdited
            // 
            this.olvColumnEdited.ImageAspectName = "EditedIcon";
            this.olvColumnEdited.Text = "";
            this.olvColumnEdited.Width = 25;
            // 
            // OlvColumnName
            // 
            this.OlvColumnName.AspectName = "Name";
            this.OlvColumnName.Text = "Name";
            this.OlvColumnName.Width = 375;
            // 
            // OlvColumnIndex
            // 
            this.OlvColumnIndex.AspectName = "Index";
            this.OlvColumnIndex.AspectToStringFormat = "{0}";
            this.OlvColumnIndex.Text = "Index";
            this.OlvColumnIndex.Width = 44;
            // 
            // OlvColumnDate
            // 
            this.OlvColumnDate.AspectName = "ShortDate";
            this.OlvColumnDate.AspectToStringFormat = "{0:d}";
            this.OlvColumnDate.Text = "Date";
            this.OlvColumnDate.Width = 82;
            // 
            // OlvColumnTime
            // 
            this.OlvColumnTime.AspectName = "Time";
            this.OlvColumnTime.AspectToStringFormat = "{0:d}";
            this.OlvColumnTime.Text = "Time";
            this.OlvColumnTime.Width = 83;
            // 
            // OlvColumnTemp
            // 
            this.OlvColumnTemp.AspectName = "Temp";
            this.OlvColumnTemp.AspectToStringFormat = "{0}°C";
            this.OlvColumnTemp.Text = "Temp";
            // 
            // OlvColumnRH
            // 
            this.OlvColumnRH.AspectName = "RH";
            this.OlvColumnRH.AspectToStringFormat = "{0}%";
            this.OlvColumnRH.Text = "RH";
            // 
            // OlvColumnSpeed
            // 
            this.OlvColumnSpeed.AspectName = "ScanSpeed";
            this.OlvColumnSpeed.AspectToStringFormat = "{0} mm/s";
            this.OlvColumnSpeed.Text = "Speed";
            // 
            // OlvColumnPasses
            // 
            this.OlvColumnPasses.AspectName = "NumPasses";
            this.OlvColumnPasses.AspectToStringFormat = "{0}";
            this.OlvColumnPasses.Text = "# Passes";
            // 
            // OlvColumnThreshold
            // 
            this.OlvColumnThreshold.AspectName = "Threshold";
            this.OlvColumnThreshold.AspectToStringFormat = "{0}%";
            this.OlvColumnThreshold.Text = "Threshold";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "edit");
            // 
            // pA
            // 
            this.pA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pA.Location = new System.Drawing.Point(417, 82);
            this.pA.Name = "pA";
            this.pA.Size = new System.Drawing.Size(402, 346);
            this.pA.TabIndex = 5;
            this.pA.Tag = "0";
            // 
            // pB
            // 
            this.pB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pB.Location = new System.Drawing.Point(825, 82);
            this.pB.Name = "pB";
            this.pB.Size = new System.Drawing.Size(403, 346);
            this.pB.TabIndex = 6;
            this.pB.Tag = "1";
            // 
            // pC
            // 
            this.pC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pC.Location = new System.Drawing.Point(417, 434);
            this.pC.Name = "pC";
            this.pC.Size = new System.Drawing.Size(402, 347);
            this.pC.TabIndex = 7;
            this.pC.Tag = "2";
            // 
            // pD
            // 
            this.pD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pD.Location = new System.Drawing.Point(825, 434);
            this.pD.Name = "pD";
            this.pD.Size = new System.Drawing.Size(403, 347);
            this.pD.TabIndex = 8;
            this.pD.Tag = "3";
            // 
            // toolStripX
            // 
            this.tlp.SetColumnSpan(this.toolStripX, 2);
            this.toolStripX.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.comboX,
            this.toolStripButtonFlipX,
            this.toolStripSeparator3,
            this.toolStripLabel8,
            this.toolStripLabelRangeX});
            this.toolStripX.Location = new System.Drawing.Point(414, 0);
            this.toolStripX.Name = "toolStripX";
            this.toolStripX.Size = new System.Drawing.Size(817, 25);
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
            this.comboX.MaxDropDownItems = 6;
            this.comboX.Name = "comboX";
            this.comboX.Size = new System.Drawing.Size(121, 25);
            this.comboX.Tag = "0";
            // 
            // toolStripButtonFlipX
            // 
            this.toolStripButtonFlipX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonFlipX.Name = "toolStripButtonFlipX";
            this.toolStripButtonFlipX.Size = new System.Drawing.Size(30, 22);
            this.toolStripButtonFlipX.Tag = "0";
            this.toolStripButtonFlipX.Text = "Flip";
            this.toolStripButtonFlipX.Click += new System.EventHandler(this.ToolStripButtonFlipX_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel8.Text = "Range";
            // 
            // toolStripLabelRangeX
            // 
            this.toolStripLabelRangeX.Name = "toolStripLabelRangeX";
            this.toolStripLabelRangeX.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabelRangeX.Text = "N/A";
            this.toolStripLabelRangeX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripY
            // 
            this.tlp.SetColumnSpan(this.toolStripY, 2);
            this.toolStripY.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.comboY,
            this.toolStripButtonFlipY,
            this.toolStripSeparator1,
            this.toolStripLabel12,
            this.toolStripLabelRangeY});
            this.toolStripY.Location = new System.Drawing.Point(414, 29);
            this.toolStripY.Name = "toolStripY";
            this.toolStripY.Size = new System.Drawing.Size(817, 25);
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
            this.comboY.Name = "comboY";
            this.comboY.Size = new System.Drawing.Size(121, 25);
            this.comboY.Tag = "1";
            // 
            // toolStripButtonFlipY
            // 
            this.toolStripButtonFlipY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonFlipY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFlipY.Name = "toolStripButtonFlipY";
            this.toolStripButtonFlipY.Size = new System.Drawing.Size(30, 22);
            this.toolStripButtonFlipY.Tag = "1";
            this.toolStripButtonFlipY.Text = "Flip";
            this.toolStripButtonFlipY.Click += new System.EventHandler(this.ToolStripButtonFlipY_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel12
            // 
            this.toolStripLabel12.Name = "toolStripLabel12";
            this.toolStripLabel12.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel12.Text = "Range";
            // 
            // toolStripLabelRangeY
            // 
            this.toolStripLabelRangeY.Name = "toolStripLabelRangeY";
            this.toolStripLabelRangeY.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabelRangeY.Text = "N/A";
            this.toolStripLabelRangeY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripZ
            // 
            this.tlp.SetColumnSpan(this.toolStripZ, 2);
            this.toolStripZ.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.comboZ,
            this.toolStripButtonFlipZ,
            this.toolStripSeparator2,
            this.toolStripLabel14,
            this.toolStripLabelRangeZ});
            this.toolStripZ.Location = new System.Drawing.Point(414, 54);
            this.toolStripZ.Name = "toolStripZ";
            this.toolStripZ.Size = new System.Drawing.Size(817, 25);
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
            this.comboZ.Name = "comboZ";
            this.comboZ.Size = new System.Drawing.Size(121, 25);
            this.comboZ.Tag = "2";
            // 
            // toolStripButtonFlipZ
            // 
            this.toolStripButtonFlipZ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonFlipZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFlipZ.Name = "toolStripButtonFlipZ";
            this.toolStripButtonFlipZ.Size = new System.Drawing.Size(30, 22);
            this.toolStripButtonFlipZ.Tag = "2";
            this.toolStripButtonFlipZ.Text = "Flip";
            this.toolStripButtonFlipZ.Click += new System.EventHandler(this.ToolStripButtonFlipZ_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel14
            // 
            this.toolStripLabel14.Name = "toolStripLabel14";
            this.toolStripLabel14.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel14.Text = "Range";
            // 
            // toolStripLabelRangeZ
            // 
            this.toolStripLabelRangeZ.Name = "toolStripLabelRangeZ";
            this.toolStripLabelRangeZ.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabelRangeZ.Text = "N/A";
            this.toolStripLabelRangeZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxRemoveAngle
            // 
            this.checkBoxRemoveAngle.AccessibleDescription = "Remove Level:_When checked, the best fit plane of height data is removed_This cor" +
    "rects for chuck level";
            this.checkBoxRemoveAngle.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxRemoveAngle.AutoSize = true;
            this.checkBoxRemoveAngle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBoxRemoveAngle.BackgroundImage")));
            this.checkBoxRemoveAngle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkBoxRemoveAngle.Checked = true;
            this.checkBoxRemoveAngle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRemoveAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxRemoveAngle.FlatAppearance.BorderSize = 0;
            this.checkBoxRemoveAngle.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.checkBoxRemoveAngle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxRemoveAngle.Location = new System.Drawing.Point(387, 3);
            this.checkBoxRemoveAngle.Name = "checkBoxRemoveAngle";
            this.checkBoxRemoveAngle.Size = new System.Drawing.Size(24, 23);
            this.checkBoxRemoveAngle.TabIndex = 12;
            this.checkBoxRemoveAngle.UseVisualStyleBackColor = true;
            this.checkBoxRemoveAngle.CheckedChanged += new System.EventHandler(this.CheckBoxRemoveAngle_CheckedChanged);
            // 
            // buttonExportSelected
            // 
            this.buttonExportSelected.AccessibleDescription = "Export Selected Scans:_Create a new file with the data contained in the selected " +
    "scans";
            this.buttonExportSelected.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExportSelected.BackgroundImage")));
            this.buttonExportSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonExportSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExportSelected.FlatAppearance.BorderSize = 0;
            this.buttonExportSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportSelected.Location = new System.Drawing.Point(267, 3);
            this.buttonExportSelected.Name = "buttonExportSelected";
            this.buttonExportSelected.Size = new System.Drawing.Size(24, 23);
            this.buttonExportSelected.TabIndex = 15;
            this.buttonExportSelected.UseVisualStyleBackColor = true;
            this.buttonExportSelected.Click += new System.EventHandler(this.ButtonExportSelected_Click);
            // 
            // checkBoxEraseData
            // 
            this.checkBoxEraseData.AccessibleDescription = "Erase Data:_Remove data by axis sliders _Special case to remove by clicking point" +
    "s with X vs. Height vs. Null_Cannot use special case with an enabled Z Axis_Righ" +
    "t click to exit without modifying data";
            this.checkBoxEraseData.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxEraseData.AutoSize = true;
            this.checkBoxEraseData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBoxEraseData.BackgroundImage")));
            this.checkBoxEraseData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkBoxEraseData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxEraseData.FlatAppearance.BorderSize = 0;
            this.checkBoxEraseData.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            this.checkBoxEraseData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxEraseData.Location = new System.Drawing.Point(237, 3);
            this.checkBoxEraseData.Name = "checkBoxEraseData";
            this.checkBoxEraseData.Size = new System.Drawing.Size(24, 23);
            this.checkBoxEraseData.TabIndex = 16;
            this.checkBoxEraseData.UseVisualStyleBackColor = true;
            this.checkBoxEraseData.CheckedChanged += new System.EventHandler(this.CheckBoxEraseData_CheckedChanged);
            // 
            // btnRevert
            // 
            this.btnRevert.AccessibleDescription = "Revert data:_Selected scan is reverted to original, unedited state";
            this.btnRevert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRevert.BackgroundImage")));
            this.btnRevert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRevert.FlatAppearance.BorderSize = 0;
            this.btnRevert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevert.Location = new System.Drawing.Point(207, 3);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(24, 23);
            this.btnRevert.TabIndex = 18;
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.BtnRevert_Click);
            // 
            // Plotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 784);
            this.Controls.Add(this.tlp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Plotter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XYZ Scan";
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
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

        private System.Windows.Forms.TableLayoutPanel tlp;
        internal BrightIdeasSoftware.FastDataListView olv;
        private BrightIdeasSoftware.OLVColumn OlvColumnPasses;
        internal System.Windows.Forms.ProgressBar ProgressBar;
        private BrightIdeasSoftware.OLVColumn OlvColumnThreshold;
        private ScottPlot.FormsPlot pA;
        private ScottPlot.FormsPlot pB;
        private ScottPlot.FormsPlot pC;
        private ScottPlot.FormsPlot pD;
        private System.Windows.Forms.ToolStrip toolStripX;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox comboX;
        private System.Windows.Forms.ToolStrip toolStripZ;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox comboZ;
        private System.Windows.Forms.ToolStripButton toolStripButtonFlipX;
        private System.Windows.Forms.ToolStripButton toolStripButtonFlipZ;
        private System.Windows.Forms.ToolStrip toolStripY;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox comboY;
        private System.Windows.Forms.ToolStripButton toolStripButtonFlipY;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private System.Windows.Forms.ToolStripLabel toolStripLabel12;
        private System.Windows.Forms.ToolStripLabel toolStripLabel14;
        private System.Windows.Forms.ToolStripLabel toolStripLabelRangeX;
        private System.Windows.Forms.ToolStripLabel toolStripLabelRangeY;
        private System.Windows.Forms.ToolStripLabel toolStripLabelRangeZ;
        private System.Windows.Forms.CheckBox checkBoxRemoveAngle;
        private System.Windows.Forms.Button buttonExportSelected;
        private System.Windows.Forms.CheckBox checkBoxShowBestFit;
        private System.Windows.Forms.CheckBox checkBoxEraseData;
        private System.Windows.Forms.Button buttonAutoscale;
        private System.Windows.Forms.ImageList imageList;
        private BrightIdeasSoftware.OLVColumn olvColumnEdited;
        private BrightIdeasSoftware.OLVColumn OlvColumnName;
        private BrightIdeasSoftware.OLVColumn OlvColumnIndex;
        private BrightIdeasSoftware.OLVColumn OlvColumnDate;
        private BrightIdeasSoftware.OLVColumn OlvColumnTime;
        private BrightIdeasSoftware.OLVColumn OlvColumnTemp;
        private BrightIdeasSoftware.OLVColumn OlvColumnRH;
        private BrightIdeasSoftware.OLVColumn OlvColumnSpeed;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.CheckBox checkBoxEqualize;
    }
}