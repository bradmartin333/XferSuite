﻿namespace XferSuite
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
            this.buttonAutoscale = new System.Windows.Forms.Button();
            this.checkBoxShowBestFit = new System.Windows.Forms.CheckBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.olv = new BrightIdeasSoftware.FastDataListView();
            this.OlvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnIndex = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnTemp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnRH = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnSpeed = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnPasses = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumnThreshold = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pA = new ScottPlot.FormsPlot();
            this.pB = new ScottPlot.FormsPlot();
            this.pC = new ScottPlot.FormsPlot();
            this.pD = new ScottPlot.FormsPlot();
            this.toolStripX = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.comboX = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonFlipX = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelMinX = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelMaxX = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxCustomMinX = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxCustomMaxX = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonApplyX = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonResetX = new System.Windows.Forms.ToolStripButton();
            this.numX = new System.Windows.Forms.ToolStripLabel();
            this.toolStripY = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.comboY = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonFlipY = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel12 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelMinY = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel13 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelMaxY = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxCustomMinY = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxCustomMaxY = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonApplyY = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonResetY = new System.Windows.Forms.ToolStripButton();
            this.numY = new System.Windows.Forms.ToolStripLabel();
            this.toolStripZ = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.comboZ = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonFlipZ = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel14 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelMinZ = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel15 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelMaxZ = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxCustomMinZ = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxCustomMaxZ = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonApplyZ = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonResetZ = new System.Windows.Forms.ToolStripButton();
            this.numZ = new System.Windows.Forms.ToolStripLabel();
            this.checkBoxRemoveAngle = new System.Windows.Forms.CheckBox();
            this.buttonExportSelected = new System.Windows.Forms.Button();
            this.checkBoxEraseData = new System.Windows.Forms.CheckBox();
            this.olvColumnEdited = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
            this.toolStripX.SuspendLayout();
            this.toolStripY.SuspendLayout();
            this.toolStripZ.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp
            // 
            this.tlp.ColumnCount = 8;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlp.Controls.Add(this.buttonAutoscale, 4, 0);
            this.tlp.Controls.Add(this.checkBoxShowBestFit, 3, 0);
            this.tlp.Controls.Add(this.ProgressBar, 0, 0);
            this.tlp.Controls.Add(this.olv, 0, 1);
            this.tlp.Controls.Add(this.pA, 6, 3);
            this.tlp.Controls.Add(this.pB, 7, 3);
            this.tlp.Controls.Add(this.pC, 6, 4);
            this.tlp.Controls.Add(this.pD, 7, 4);
            this.tlp.Controls.Add(this.toolStripX, 6, 0);
            this.tlp.Controls.Add(this.toolStripY, 6, 1);
            this.tlp.Controls.Add(this.toolStripZ, 6, 2);
            this.tlp.Controls.Add(this.checkBoxRemoveAngle, 5, 0);
            this.tlp.Controls.Add(this.buttonExportSelected, 2, 0);
            this.tlp.Controls.Add(this.checkBoxEraseData, 1, 0);
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
            // buttonAutoscale
            // 
            this.buttonAutoscale.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAutoscale.BackgroundImage")));
            this.buttonAutoscale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAutoscale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAutoscale.FlatAppearance.BorderSize = 0;
            this.buttonAutoscale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAutoscale.Location = new System.Drawing.Point(417, 3);
            this.buttonAutoscale.Name = "buttonAutoscale";
            this.buttonAutoscale.Size = new System.Drawing.Size(24, 23);
            this.buttonAutoscale.TabIndex = 17;
            this.buttonAutoscale.UseVisualStyleBackColor = true;
            this.buttonAutoscale.Click += new System.EventHandler(this.buttonAutoscale_Click);
            // 
            // checkBoxShowBestFit
            // 
            this.checkBoxShowBestFit.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxShowBestFit.AutoSize = true;
            this.checkBoxShowBestFit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBoxShowBestFit.BackgroundImage")));
            this.checkBoxShowBestFit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkBoxShowBestFit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxShowBestFit.FlatAppearance.BorderSize = 0;
            this.checkBoxShowBestFit.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.checkBoxShowBestFit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxShowBestFit.Location = new System.Drawing.Point(387, 3);
            this.checkBoxShowBestFit.Name = "checkBoxShowBestFit";
            this.checkBoxShowBestFit.Size = new System.Drawing.Size(24, 23);
            this.checkBoxShowBestFit.TabIndex = 14;
            this.checkBoxShowBestFit.UseVisualStyleBackColor = true;
            this.checkBoxShowBestFit.CheckedChanged += new System.EventHandler(this.checkBoxShowBestFit_CheckedChanged);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressBar.Location = new System.Drawing.Point(3, 3);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(318, 23);
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
            this.tlp.SetColumnSpan(this.olv, 6);
            this.olv.Cursor = System.Windows.Forms.Cursors.Default;
            this.olv.DataSource = null;
            this.olv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olv.FullRowSelect = true;
            this.olv.HideSelection = false;
            this.olv.Location = new System.Drawing.Point(3, 32);
            this.olv.Name = "olv";
            this.tlp.SetRowSpan(this.olv, 4);
            this.olv.ShowGroups = false;
            this.olv.Size = new System.Drawing.Size(468, 749);
            this.olv.SmallImageList = this.imageList;
            this.olv.TabIndex = 3;
            this.olv.UseCompatibleStateImageBehavior = false;
            this.olv.UseFilterIndicator = true;
            this.olv.UseFiltering = true;
            this.olv.View = System.Windows.Forms.View.Details;
            this.olv.VirtualMode = true;
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
            // pA
            // 
            this.pA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pA.Location = new System.Drawing.Point(477, 82);
            this.pA.Name = "pA";
            this.pA.Size = new System.Drawing.Size(372, 346);
            this.pA.TabIndex = 5;
            this.pA.Tag = "0";
            // 
            // pB
            // 
            this.pB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pB.Location = new System.Drawing.Point(855, 82);
            this.pB.Name = "pB";
            this.pB.Size = new System.Drawing.Size(373, 346);
            this.pB.TabIndex = 6;
            this.pB.Tag = "1";
            // 
            // pC
            // 
            this.pC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pC.Location = new System.Drawing.Point(477, 434);
            this.pC.Name = "pC";
            this.pC.Size = new System.Drawing.Size(372, 347);
            this.pC.TabIndex = 7;
            this.pC.Tag = "2";
            // 
            // pD
            // 
            this.pD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pD.Location = new System.Drawing.Point(855, 434);
            this.pD.Name = "pD";
            this.pD.Size = new System.Drawing.Size(373, 347);
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
            this.toolStripLabel8,
            this.toolStripLabelMinX,
            this.toolStripLabel11,
            this.toolStripLabelMaxX,
            this.toolStripLabel4,
            this.toolStripTextBoxCustomMinX,
            this.toolStripLabel5,
            this.toolStripTextBoxCustomMaxX,
            this.toolStripButtonApplyX,
            this.toolStripButtonResetX,
            this.numX});
            this.toolStripX.Location = new System.Drawing.Point(474, 0);
            this.toolStripX.Name = "toolStripX";
            this.toolStripX.Size = new System.Drawing.Size(757, 25);
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
            this.comboX.Tag = "0";
            this.comboX.Text = "X (mm)";
            // 
            // toolStripButtonFlipX
            // 
            this.toolStripButtonFlipX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFlipX.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFlipX.Image")));
            this.toolStripButtonFlipX.Name = "toolStripButtonFlipX";
            this.toolStripButtonFlipX.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFlipX.Tag = "0";
            this.toolStripButtonFlipX.Text = "Flip";
            this.toolStripButtonFlipX.Click += new System.EventHandler(this.toolStripButtonFlipX_Click);
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel8.Text = "Min";
            // 
            // toolStripLabelMinX
            // 
            this.toolStripLabelMinX.AutoSize = false;
            this.toolStripLabelMinX.Name = "toolStripLabelMinX";
            this.toolStripLabelMinX.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabelMinX.Text = "N/A";
            // 
            // toolStripLabel11
            // 
            this.toolStripLabel11.Name = "toolStripLabel11";
            this.toolStripLabel11.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel11.Text = "Max";
            // 
            // toolStripLabelMaxX
            // 
            this.toolStripLabelMaxX.AutoSize = false;
            this.toolStripLabelMaxX.Name = "toolStripLabelMaxX";
            this.toolStripLabelMaxX.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabelMaxX.Text = "N/A";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(73, 22);
            this.toolStripLabel4.Text = "Custom Min";
            // 
            // toolStripTextBoxCustomMinX
            // 
            this.toolStripTextBoxCustomMinX.AutoSize = false;
            this.toolStripTextBoxCustomMinX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxCustomMinX.Name = "toolStripTextBoxCustomMinX";
            this.toolStripTextBoxCustomMinX.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabel5.Text = "Custom Max";
            // 
            // toolStripTextBoxCustomMaxX
            // 
            this.toolStripTextBoxCustomMaxX.AutoSize = false;
            this.toolStripTextBoxCustomMaxX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxCustomMaxX.Name = "toolStripTextBoxCustomMaxX";
            this.toolStripTextBoxCustomMaxX.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripButtonApplyX
            // 
            this.toolStripButtonApplyX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonApplyX.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonApplyX.Image")));
            this.toolStripButtonApplyX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonApplyX.Name = "toolStripButtonApplyX";
            this.toolStripButtonApplyX.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonApplyX.Tag = "0";
            this.toolStripButtonApplyX.Text = "Apply";
            this.toolStripButtonApplyX.Click += new System.EventHandler(this.toolStripButtonApply_Click);
            // 
            // toolStripButtonResetX
            // 
            this.toolStripButtonResetX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonResetX.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonResetX.Image")));
            this.toolStripButtonResetX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonResetX.Name = "toolStripButtonResetX";
            this.toolStripButtonResetX.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonResetX.Text = "Reset";
            this.toolStripButtonResetX.Click += new System.EventHandler(this.toolStripButtonResetX_Click);
            // 
            // numX
            // 
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripY
            // 
            this.tlp.SetColumnSpan(this.toolStripY, 2);
            this.toolStripY.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.comboY,
            this.toolStripButtonFlipY,
            this.toolStripLabel12,
            this.toolStripLabelMinY,
            this.toolStripLabel13,
            this.toolStripLabelMaxY,
            this.toolStripLabel6,
            this.toolStripTextBoxCustomMinY,
            this.toolStripLabel7,
            this.toolStripTextBoxCustomMaxY,
            this.toolStripButtonApplyY,
            this.toolStripButtonResetY,
            this.numY});
            this.toolStripY.Location = new System.Drawing.Point(474, 29);
            this.toolStripY.Name = "toolStripY";
            this.toolStripY.Size = new System.Drawing.Size(757, 25);
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
            this.comboY.Tag = "1";
            this.comboY.Text = "Y (mm)";
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
            this.toolStripButtonFlipY.Click += new System.EventHandler(this.toolStripButtonFlipY_Click);
            // 
            // toolStripLabel12
            // 
            this.toolStripLabel12.Name = "toolStripLabel12";
            this.toolStripLabel12.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel12.Text = "Min";
            // 
            // toolStripLabelMinY
            // 
            this.toolStripLabelMinY.AutoSize = false;
            this.toolStripLabelMinY.Name = "toolStripLabelMinY";
            this.toolStripLabelMinY.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabelMinY.Text = "N/A";
            // 
            // toolStripLabel13
            // 
            this.toolStripLabel13.Name = "toolStripLabel13";
            this.toolStripLabel13.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel13.Text = "Max";
            // 
            // toolStripLabelMaxY
            // 
            this.toolStripLabelMaxY.AutoSize = false;
            this.toolStripLabelMaxY.Name = "toolStripLabelMaxY";
            this.toolStripLabelMaxY.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabelMaxY.Text = "N/A";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(73, 22);
            this.toolStripLabel6.Text = "Custom Min";
            // 
            // toolStripTextBoxCustomMinY
            // 
            this.toolStripTextBoxCustomMinY.AutoSize = false;
            this.toolStripTextBoxCustomMinY.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxCustomMinY.Name = "toolStripTextBoxCustomMinY";
            this.toolStripTextBoxCustomMinY.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabel7.Text = "Custom Max";
            // 
            // toolStripTextBoxCustomMaxY
            // 
            this.toolStripTextBoxCustomMaxY.AutoSize = false;
            this.toolStripTextBoxCustomMaxY.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxCustomMaxY.Name = "toolStripTextBoxCustomMaxY";
            this.toolStripTextBoxCustomMaxY.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripButtonApplyY
            // 
            this.toolStripButtonApplyY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonApplyY.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonApplyY.Image")));
            this.toolStripButtonApplyY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonApplyY.Name = "toolStripButtonApplyY";
            this.toolStripButtonApplyY.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonApplyY.Tag = "1";
            this.toolStripButtonApplyY.Text = "Apply";
            this.toolStripButtonApplyY.Click += new System.EventHandler(this.toolStripButtonApply_Click);
            // 
            // toolStripButtonResetY
            // 
            this.toolStripButtonResetY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonResetY.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonResetY.Image")));
            this.toolStripButtonResetY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonResetY.Name = "toolStripButtonResetY";
            this.toolStripButtonResetY.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonResetY.Text = "Reset";
            this.toolStripButtonResetY.Click += new System.EventHandler(this.toolStripButtonResetY_Click);
            // 
            // numY
            // 
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripZ
            // 
            this.tlp.SetColumnSpan(this.toolStripZ, 2);
            this.toolStripZ.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.comboZ,
            this.toolStripButtonFlipZ,
            this.toolStripLabel14,
            this.toolStripLabelMinZ,
            this.toolStripLabel15,
            this.toolStripLabelMaxZ,
            this.toolStripLabel9,
            this.toolStripTextBoxCustomMinZ,
            this.toolStripLabel10,
            this.toolStripTextBoxCustomMaxZ,
            this.toolStripButtonApplyZ,
            this.toolStripButtonResetZ,
            this.numZ});
            this.toolStripZ.Location = new System.Drawing.Point(474, 54);
            this.toolStripZ.Name = "toolStripZ";
            this.toolStripZ.Size = new System.Drawing.Size(757, 25);
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
            this.comboZ.Tag = "2";
            this.comboZ.Text = "Height (µm)";
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
            this.toolStripButtonFlipZ.Click += new System.EventHandler(this.toolStripButtonFlipZ_Click);
            // 
            // toolStripLabel14
            // 
            this.toolStripLabel14.Name = "toolStripLabel14";
            this.toolStripLabel14.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel14.Text = "Min";
            // 
            // toolStripLabelMinZ
            // 
            this.toolStripLabelMinZ.AutoSize = false;
            this.toolStripLabelMinZ.Name = "toolStripLabelMinZ";
            this.toolStripLabelMinZ.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabelMinZ.Text = "N/A";
            // 
            // toolStripLabel15
            // 
            this.toolStripLabel15.Name = "toolStripLabel15";
            this.toolStripLabel15.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel15.Text = "Max";
            // 
            // toolStripLabelMaxZ
            // 
            this.toolStripLabelMaxZ.AutoSize = false;
            this.toolStripLabelMaxZ.Name = "toolStripLabelMaxZ";
            this.toolStripLabelMaxZ.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabelMaxZ.Text = "N/A";
            // 
            // toolStripLabel9
            // 
            this.toolStripLabel9.Name = "toolStripLabel9";
            this.toolStripLabel9.Size = new System.Drawing.Size(73, 22);
            this.toolStripLabel9.Text = "Custom Min";
            // 
            // toolStripTextBoxCustomMinZ
            // 
            this.toolStripTextBoxCustomMinZ.AutoSize = false;
            this.toolStripTextBoxCustomMinZ.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxCustomMinZ.Name = "toolStripTextBoxCustomMinZ";
            this.toolStripTextBoxCustomMinZ.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripLabel10
            // 
            this.toolStripLabel10.Name = "toolStripLabel10";
            this.toolStripLabel10.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabel10.Text = "Custom Max";
            // 
            // toolStripTextBoxCustomMaxZ
            // 
            this.toolStripTextBoxCustomMaxZ.AutoSize = false;
            this.toolStripTextBoxCustomMaxZ.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxCustomMaxZ.Name = "toolStripTextBoxCustomMaxZ";
            this.toolStripTextBoxCustomMaxZ.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripButtonApplyZ
            // 
            this.toolStripButtonApplyZ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonApplyZ.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonApplyZ.Image")));
            this.toolStripButtonApplyZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonApplyZ.Name = "toolStripButtonApplyZ";
            this.toolStripButtonApplyZ.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonApplyZ.Tag = "2";
            this.toolStripButtonApplyZ.Text = "Apply";
            this.toolStripButtonApplyZ.Click += new System.EventHandler(this.toolStripButtonApply_Click);
            // 
            // toolStripButtonResetZ
            // 
            this.toolStripButtonResetZ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonResetZ.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonResetZ.Image")));
            this.toolStripButtonResetZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonResetZ.Name = "toolStripButtonResetZ";
            this.toolStripButtonResetZ.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonResetZ.Text = "Reset";
            this.toolStripButtonResetZ.Click += new System.EventHandler(this.toolStripButtonResetZ_Click);
            // 
            // numZ
            // 
            this.numZ.Name = "numZ";
            this.numZ.Size = new System.Drawing.Size(0, 22);
            // 
            // checkBoxRemoveAngle
            // 
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
            this.checkBoxRemoveAngle.Location = new System.Drawing.Point(447, 3);
            this.checkBoxRemoveAngle.Name = "checkBoxRemoveAngle";
            this.checkBoxRemoveAngle.Size = new System.Drawing.Size(24, 23);
            this.checkBoxRemoveAngle.TabIndex = 12;
            this.checkBoxRemoveAngle.UseVisualStyleBackColor = true;
            this.checkBoxRemoveAngle.CheckedChanged += new System.EventHandler(this.checkBoxRemoveAngle_CheckedChanged);
            // 
            // buttonExportSelected
            // 
            this.buttonExportSelected.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExportSelected.BackgroundImage")));
            this.buttonExportSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonExportSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExportSelected.FlatAppearance.BorderSize = 0;
            this.buttonExportSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportSelected.Location = new System.Drawing.Point(357, 3);
            this.buttonExportSelected.Name = "buttonExportSelected";
            this.buttonExportSelected.Size = new System.Drawing.Size(24, 23);
            this.buttonExportSelected.TabIndex = 15;
            this.buttonExportSelected.UseVisualStyleBackColor = true;
            this.buttonExportSelected.Click += new System.EventHandler(this.buttonExportSelected_Click);
            // 
            // checkBoxEraseData
            // 
            this.checkBoxEraseData.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxEraseData.AutoSize = true;
            this.checkBoxEraseData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBoxEraseData.BackgroundImage")));
            this.checkBoxEraseData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkBoxEraseData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxEraseData.FlatAppearance.BorderSize = 0;
            this.checkBoxEraseData.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightCoral;
            this.checkBoxEraseData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxEraseData.Location = new System.Drawing.Point(327, 3);
            this.checkBoxEraseData.Name = "checkBoxEraseData";
            this.checkBoxEraseData.Size = new System.Drawing.Size(24, 23);
            this.checkBoxEraseData.TabIndex = 16;
            this.checkBoxEraseData.UseVisualStyleBackColor = true;
            this.checkBoxEraseData.Visible = false;
            this.checkBoxEraseData.CheckedChanged += new System.EventHandler(this.checkBoxEraseData_CheckedChanged);
            // 
            // olvColumnEdited
            // 
            this.olvColumnEdited.ImageAspectName = "EditedIcon";
            this.olvColumnEdited.Text = "Edited";
            this.olvColumnEdited.Width = 45;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "edit");
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
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxCustomMinX;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxCustomMaxX;
        private System.Windows.Forms.ToolStripButton toolStripButtonFlipZ;
        private System.Windows.Forms.ToolStripLabel toolStripLabel9;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxCustomMinZ;
        private System.Windows.Forms.ToolStripLabel toolStripLabel10;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxCustomMaxZ;
        private System.Windows.Forms.ToolStrip toolStripY;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox comboY;
        private System.Windows.Forms.ToolStripButton toolStripButtonFlipY;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxCustomMinY;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxCustomMaxY;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private System.Windows.Forms.ToolStripLabel toolStripLabel11;
        private System.Windows.Forms.ToolStripLabel toolStripLabel12;
        private System.Windows.Forms.ToolStripLabel toolStripLabel13;
        private System.Windows.Forms.ToolStripLabel toolStripLabel14;
        private System.Windows.Forms.ToolStripLabel toolStripLabel15;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMinX;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMaxX;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMinY;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMaxY;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMinZ;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMaxZ;
        private System.Windows.Forms.ToolStripButton toolStripButtonApplyX;
        private System.Windows.Forms.ToolStripButton toolStripButtonApplyY;
        private System.Windows.Forms.ToolStripButton toolStripButtonApplyZ;
        private System.Windows.Forms.CheckBox checkBoxRemoveAngle;
        private System.Windows.Forms.ToolStripLabel numX;
        private System.Windows.Forms.ToolStripLabel numY;
        private System.Windows.Forms.ToolStripLabel numZ;
        private System.Windows.Forms.ToolStripButton toolStripButtonResetX;
        private System.Windows.Forms.ToolStripButton toolStripButtonResetY;
        private System.Windows.Forms.ToolStripButton toolStripButtonResetZ;
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
    }
}