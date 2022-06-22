namespace XferSuite.Apps.SEYR
{
    partial class ParseSEYR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParseSEYR));
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.FeatureOLV = new BrightIdeasSoftware.ObjectListView();
            this.featureOlvIgnore = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.featureOlvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.featureOlvCriteria = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.featureOlvImage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CriteriaOLV = new BrightIdeasSoftware.ObjectListView();
            this.criteriaOlvPass = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.criteriaOlvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.criteriaOlvID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnPlot = new System.Windows.Forms.Button();
            this.BtnSaveAs = new System.Windows.Forms.Button();
            this.CbxPassFail = new System.Windows.Forms.CheckBox();
            this.FeatureMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FeatureEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FeatureGroupNeedOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FeatureGroupRedundantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FeatureResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CriteriaMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CriteriaEditColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CriteriaResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataLoadingWorker = new System.ComponentModel.BackgroundWorker();
            this.PlotWorker = new System.ComponentModel.BackgroundWorker();
            this.TLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FeatureOLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CriteriaOLV)).BeginInit();
            this.FeatureMenuStrip.SuspendLayout();
            this.CriteriaMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 2;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP.Controls.Add(this.FeatureOLV, 0, 4);
            this.TLP.Controls.Add(this.CriteriaOLV, 0, 7);
            this.TLP.Controls.Add(this.label1, 0, 3);
            this.TLP.Controls.Add(this.label2, 0, 6);
            this.TLP.Controls.Add(this.BtnPlot, 0, 0);
            this.TLP.Controls.Add(this.BtnSaveAs, 1, 1);
            this.TLP.Controls.Add(this.CbxPassFail, 0, 1);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 8;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.Size = new System.Drawing.Size(334, 411);
            this.TLP.TabIndex = 1;
            // 
            // FeatureOLV
            // 
            this.FeatureOLV.AllColumns.Add(this.featureOlvIgnore);
            this.FeatureOLV.AllColumns.Add(this.featureOlvName);
            this.FeatureOLV.AllColumns.Add(this.featureOlvCriteria);
            this.FeatureOLV.AllColumns.Add(this.featureOlvImage);
            this.FeatureOLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FeatureOLV.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FeatureOLV.CellEditUseWholeCell = false;
            this.FeatureOLV.CheckBoxes = true;
            this.FeatureOLV.CheckedAspectName = "Ignore";
            this.FeatureOLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.featureOlvIgnore,
            this.featureOlvName,
            this.featureOlvCriteria,
            this.featureOlvImage});
            this.TLP.SetColumnSpan(this.FeatureOLV, 2);
            this.FeatureOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this.FeatureOLV.FullRowSelect = true;
            this.FeatureOLV.HasCollapsibleGroups = false;
            this.FeatureOLV.HideSelection = false;
            this.FeatureOLV.Location = new System.Drawing.Point(3, 91);
            this.FeatureOLV.Name = "FeatureOLV";
            this.FeatureOLV.ShowGroups = false;
            this.FeatureOLV.Size = new System.Drawing.Size(328, 140);
            this.FeatureOLV.TabIndex = 8;
            this.FeatureOLV.UseCompatibleStateImageBehavior = false;
            this.FeatureOLV.View = System.Windows.Forms.View.Details;
            // 
            // featureOlvIgnore
            // 
            this.featureOlvIgnore.AspectName = "Ignore";
            this.featureOlvIgnore.CheckBoxes = true;
            this.featureOlvIgnore.Text = "Ignore";
            this.featureOlvIgnore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // featureOlvName
            // 
            this.featureOlvName.AspectName = "Name";
            this.featureOlvName.Text = "Name";
            this.featureOlvName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // featureOlvCriteria
            // 
            this.featureOlvCriteria.AspectName = "CriteriaString";
            this.featureOlvCriteria.FillsFreeSpace = true;
            this.featureOlvCriteria.Text = "Criteria String";
            this.featureOlvCriteria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // featureOlvImage
            // 
            this.featureOlvImage.AspectName = "SaveImage";
            this.featureOlvImage.AspectToStringFormat = "{0}";
            this.featureOlvImage.Text = "Image";
            this.featureOlvImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CriteriaOLV
            // 
            this.CriteriaOLV.AllColumns.Add(this.criteriaOlvPass);
            this.CriteriaOLV.AllColumns.Add(this.criteriaOlvName);
            this.CriteriaOLV.AllColumns.Add(this.criteriaOlvID);
            this.CriteriaOLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CriteriaOLV.CellEditUseWholeCell = false;
            this.CriteriaOLV.CheckBoxes = true;
            this.CriteriaOLV.CheckedAspectName = "Pass";
            this.CriteriaOLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.criteriaOlvPass,
            this.criteriaOlvName,
            this.criteriaOlvID});
            this.TLP.SetColumnSpan(this.CriteriaOLV, 2);
            this.CriteriaOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this.CriteriaOLV.FullRowSelect = true;
            this.CriteriaOLV.HasCollapsibleGroups = false;
            this.CriteriaOLV.HideSelection = false;
            this.CriteriaOLV.Location = new System.Drawing.Point(3, 267);
            this.CriteriaOLV.Name = "CriteriaOLV";
            this.CriteriaOLV.ShowGroups = false;
            this.CriteriaOLV.Size = new System.Drawing.Size(328, 141);
            this.CriteriaOLV.TabIndex = 12;
            this.CriteriaOLV.UseCompatibleStateImageBehavior = false;
            this.CriteriaOLV.View = System.Windows.Forms.View.Details;
            // 
            // criteriaOlvPass
            // 
            this.criteriaOlvPass.AspectName = "Pass";
            this.criteriaOlvPass.CheckBoxes = true;
            this.criteriaOlvPass.Text = "Pass";
            this.criteriaOlvPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // criteriaOlvName
            // 
            this.criteriaOlvName.AspectName = "LegendEntry";
            this.criteriaOlvName.FillsFreeSpace = true;
            this.criteriaOlvName.Text = "Name";
            this.criteriaOlvName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // criteriaOlvID
            // 
            this.criteriaOlvID.AspectName = "ID";
            this.criteriaOlvID.AspectToStringFormat = "{0}";
            this.criteriaOlvID.Text = "ID";
            this.criteriaOlvID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.TLP.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Feature Manager";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.TLP.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Plotted Criteria";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnPlot
            // 
            this.BtnPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPlot.BackColor = System.Drawing.Color.LightBlue;
            this.TLP.SetColumnSpan(this.BtnPlot, 2);
            this.BtnPlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlot.Location = new System.Drawing.Point(3, 3);
            this.BtnPlot.Name = "BtnPlot";
            this.BtnPlot.Size = new System.Drawing.Size(328, 23);
            this.BtnPlot.TabIndex = 15;
            this.BtnPlot.Text = "Plot";
            this.BtnPlot.UseVisualStyleBackColor = false;
            this.BtnPlot.Click += new System.EventHandler(this.BtnPlot_Click);
            // 
            // BtnSaveAs
            // 
            this.BtnSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveAs.BackColor = System.Drawing.Color.White;
            this.BtnSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveAs.Location = new System.Drawing.Point(253, 32);
            this.BtnSaveAs.Name = "BtnSaveAs";
            this.BtnSaveAs.Size = new System.Drawing.Size(78, 23);
            this.BtnSaveAs.TabIndex = 16;
            this.BtnSaveAs.Text = "Save As";
            this.BtnSaveAs.UseVisualStyleBackColor = false;
            this.BtnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
            // 
            // CbxPassFail
            // 
            this.CbxPassFail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxPassFail.Appearance = System.Windows.Forms.Appearance.Button;
            this.CbxPassFail.AutoSize = true;
            this.CbxPassFail.BackColor = System.Drawing.Color.White;
            this.CbxPassFail.Enabled = false;
            this.CbxPassFail.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.CbxPassFail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbxPassFail.Location = new System.Drawing.Point(3, 32);
            this.CbxPassFail.Name = "CbxPassFail";
            this.CbxPassFail.Size = new System.Drawing.Size(244, 23);
            this.CbxPassFail.TabIndex = 17;
            this.CbxPassFail.Text = "Toggle Pass Fail";
            this.CbxPassFail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CbxPassFail.UseVisualStyleBackColor = false;
            this.CbxPassFail.CheckedChanged += new System.EventHandler(this.CbxPassFail_CheckedChanged);
            // 
            // FeatureMenuStrip
            // 
            this.FeatureMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FeatureEditToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.FeatureResetToolStripMenuItem});
            this.FeatureMenuStrip.Name = "FeatureMenuStrip";
            this.FeatureMenuStrip.Size = new System.Drawing.Size(108, 70);
            // 
            // FeatureEditToolStripMenuItem
            // 
            this.FeatureEditToolStripMenuItem.Name = "FeatureEditToolStripMenuItem";
            this.FeatureEditToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.FeatureEditToolStripMenuItem.Text = "Edit";
            this.FeatureEditToolStripMenuItem.Click += new System.EventHandler(this.FeatureEditToolStripMenuItem_Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FeatureGroupNeedOneToolStripMenuItem,
            this.FeatureGroupRedundantToolStripMenuItem});
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.groupToolStripMenuItem.Text = "Group";
            // 
            // FeatureGroupNeedOneToolStripMenuItem
            // 
            this.FeatureGroupNeedOneToolStripMenuItem.Name = "FeatureGroupNeedOneToolStripMenuItem";
            this.FeatureGroupNeedOneToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.FeatureGroupNeedOneToolStripMenuItem.Text = "Need One";
            this.FeatureGroupNeedOneToolStripMenuItem.Click += new System.EventHandler(this.FeatureGroupNeedOneToolStripMenuItem_Click);
            // 
            // FeatureGroupRedundantToolStripMenuItem
            // 
            this.FeatureGroupRedundantToolStripMenuItem.Name = "FeatureGroupRedundantToolStripMenuItem";
            this.FeatureGroupRedundantToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.FeatureGroupRedundantToolStripMenuItem.Text = "Redundant";
            this.FeatureGroupRedundantToolStripMenuItem.Click += new System.EventHandler(this.FeatureGroupRedundantToolStripMenuItem_Click);
            // 
            // FeatureResetToolStripMenuItem
            // 
            this.FeatureResetToolStripMenuItem.Name = "FeatureResetToolStripMenuItem";
            this.FeatureResetToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.FeatureResetToolStripMenuItem.Text = "Reset";
            this.FeatureResetToolStripMenuItem.Click += new System.EventHandler(this.FeatureResetToolStripMenuItem_Click);
            // 
            // CriteriaMenuStrip
            // 
            this.CriteriaMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CriteriaEditColorToolStripMenuItem,
            this.CriteriaResetToolStripMenuItem});
            this.CriteriaMenuStrip.Name = "CriteriaMenuStrip";
            this.CriteriaMenuStrip.Size = new System.Drawing.Size(127, 48);
            // 
            // CriteriaEditColorToolStripMenuItem
            // 
            this.CriteriaEditColorToolStripMenuItem.Name = "CriteriaEditColorToolStripMenuItem";
            this.CriteriaEditColorToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.CriteriaEditColorToolStripMenuItem.Text = "Edit Color";
            this.CriteriaEditColorToolStripMenuItem.Click += new System.EventHandler(this.CriteriaEditColorToolStripMenuItem_Click);
            // 
            // CriteriaResetToolStripMenuItem
            // 
            this.CriteriaResetToolStripMenuItem.Name = "CriteriaResetToolStripMenuItem";
            this.CriteriaResetToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.CriteriaResetToolStripMenuItem.Text = "Reset";
            this.CriteriaResetToolStripMenuItem.Click += new System.EventHandler(this.CriteriaResetToolStripMenuItem_Click);
            // 
            // DataLoadingWorker
            // 
            this.DataLoadingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DataLoadingWorker_DoWork);
            // 
            // PlotWorker
            // 
            this.PlotWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PlotWorker_DoWork);
            // 
            // ParseSEYR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 411);
            this.Controls.Add(this.TLP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 450);
            this.Name = "ParseSEYR";
            this.Text = "Parse SEYR";
            this.Load += new System.EventHandler(this.ParseSEYR_Load);
            this.TLP.ResumeLayout(false);
            this.TLP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FeatureOLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CriteriaOLV)).EndInit();
            this.FeatureMenuStrip.ResumeLayout(false);
            this.CriteriaMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLP;
        private BrightIdeasSoftware.ObjectListView FeatureOLV;
        private BrightIdeasSoftware.OLVColumn featureOlvIgnore;
        private BrightIdeasSoftware.OLVColumn featureOlvName;
        private BrightIdeasSoftware.OLVColumn featureOlvCriteria;
        private BrightIdeasSoftware.OLVColumn featureOlvImage;
        private BrightIdeasSoftware.ObjectListView CriteriaOLV;
        private BrightIdeasSoftware.OLVColumn criteriaOlvPass;
        private BrightIdeasSoftware.OLVColumn criteriaOlvName;
        private BrightIdeasSoftware.OLVColumn criteriaOlvID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnPlot;
        private System.Windows.Forms.Button BtnSaveAs;
        private System.Windows.Forms.CheckBox CbxPassFail;
        private System.Windows.Forms.ContextMenuStrip FeatureMenuStrip;
        private System.Windows.Forms.ContextMenuStrip CriteriaMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FeatureResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CriteriaResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FeatureEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CriteriaEditColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FeatureGroupNeedOneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FeatureGroupRedundantToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker DataLoadingWorker;
        private System.ComponentModel.BackgroundWorker PlotWorker;
    }
}