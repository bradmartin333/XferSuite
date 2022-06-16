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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParseSEYR));
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.BtnResetCriteria = new System.Windows.Forms.Button();
            this.BtnCombineSelected = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnMakeCycleFile = new System.Windows.Forms.Button();
            this.LabelLoading = new System.Windows.Forms.Label();
            this.FeatureOLV = new BrightIdeasSoftware.ObjectListView();
            this.featureOlvIgnore = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.featureOlvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.featureOlvCriteria = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.featureOlvImage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CbxTogglePF = new System.Windows.Forms.CheckBox();
            this.BtnPlot = new System.Windows.Forms.Button();
            this.CriteriaOLV = new BrightIdeasSoftware.ObjectListView();
            this.criteriaOlvPass = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.criteriaOlvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.criteriaOlvID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.TLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FeatureOLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CriteriaOLV)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 2;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.TLP.Controls.Add(this.BtnResetCriteria, 0, 6);
            this.TLP.Controls.Add(this.BtnCombineSelected, 0, 2);
            this.TLP.Controls.Add(this.BtnSave, 1, 2);
            this.TLP.Controls.Add(this.BtnMakeCycleFile, 1, 3);
            this.TLP.Controls.Add(this.LabelLoading, 0, 1);
            this.TLP.Controls.Add(this.FeatureOLV, 0, 0);
            this.TLP.Controls.Add(this.CbxTogglePF, 0, 3);
            this.TLP.Controls.Add(this.BtnPlot, 0, 4);
            this.TLP.Controls.Add(this.CriteriaOLV, 0, 5);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 7;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.Size = new System.Drawing.Size(334, 411);
            this.TLP.TabIndex = 1;
            // 
            // BtnResetCriteria
            // 
            this.BtnResetCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnResetCriteria.BackColor = System.Drawing.Color.White;
            this.TLP.SetColumnSpan(this.BtnResetCriteria, 2);
            this.BtnResetCriteria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnResetCriteria.Location = new System.Drawing.Point(3, 385);
            this.BtnResetCriteria.Name = "BtnResetCriteria";
            this.BtnResetCriteria.Size = new System.Drawing.Size(328, 23);
            this.BtnResetCriteria.TabIndex = 13;
            this.BtnResetCriteria.Text = "Reset Criteria";
            this.BtnResetCriteria.UseVisualStyleBackColor = false;
            this.BtnResetCriteria.Click += new System.EventHandler(this.BtnResetCriteria_Click);
            // 
            // BtnCombineSelected
            // 
            this.BtnCombineSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCombineSelected.BackColor = System.Drawing.Color.White;
            this.BtnCombineSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCombineSelected.Location = new System.Drawing.Point(3, 150);
            this.BtnCombineSelected.Name = "BtnCombineSelected";
            this.BtnCombineSelected.Size = new System.Drawing.Size(161, 23);
            this.BtnCombineSelected.TabIndex = 11;
            this.BtnCombineSelected.Text = "Combine Selected";
            this.BtnCombineSelected.UseVisualStyleBackColor = false;
            this.BtnCombineSelected.Click += new System.EventHandler(this.BtnCombineSelected_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.BackColor = System.Drawing.Color.White;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Location = new System.Drawing.Point(170, 150);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(161, 23);
            this.BtnSave.TabIndex = 7;
            this.BtnSave.Text = "Save As New SEYRUP";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnMakeCycleFile
            // 
            this.BtnMakeCycleFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMakeCycleFile.BackColor = System.Drawing.Color.White;
            this.BtnMakeCycleFile.Enabled = false;
            this.BtnMakeCycleFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMakeCycleFile.Location = new System.Drawing.Point(170, 179);
            this.BtnMakeCycleFile.Name = "BtnMakeCycleFile";
            this.BtnMakeCycleFile.Size = new System.Drawing.Size(161, 23);
            this.BtnMakeCycleFile.TabIndex = 5;
            this.BtnMakeCycleFile.Text = "Make Cycle File";
            this.BtnMakeCycleFile.UseVisualStyleBackColor = false;
            this.BtnMakeCycleFile.Click += new System.EventHandler(this.BtnMakeCycleFile_Click);
            // 
            // LabelLoading
            // 
            this.LabelLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelLoading.AutoSize = true;
            this.LabelLoading.BackColor = System.Drawing.Color.Bisque;
            this.TLP.SetColumnSpan(this.LabelLoading, 2);
            this.LabelLoading.Location = new System.Drawing.Point(3, 127);
            this.LabelLoading.Name = "LabelLoading";
            this.LabelLoading.Size = new System.Drawing.Size(328, 20);
            this.LabelLoading.TabIndex = 6;
            this.LabelLoading.Text = "Loading...";
            this.LabelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelLoading.Visible = false;
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
            this.FeatureOLV.Location = new System.Drawing.Point(3, 3);
            this.FeatureOLV.Name = "FeatureOLV";
            this.FeatureOLV.ShowGroups = false;
            this.FeatureOLV.Size = new System.Drawing.Size(328, 121);
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
            // CbxTogglePF
            // 
            this.CbxTogglePF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxTogglePF.Appearance = System.Windows.Forms.Appearance.Button;
            this.CbxTogglePF.AutoSize = true;
            this.CbxTogglePF.BackColor = System.Drawing.Color.White;
            this.CbxTogglePF.Enabled = false;
            this.CbxTogglePF.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.CbxTogglePF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbxTogglePF.Location = new System.Drawing.Point(3, 179);
            this.CbxTogglePF.Name = "CbxTogglePF";
            this.CbxTogglePF.Size = new System.Drawing.Size(161, 23);
            this.CbxTogglePF.TabIndex = 9;
            this.CbxTogglePF.Text = "Toggle Pass Fail";
            this.CbxTogglePF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CbxTogglePF.UseVisualStyleBackColor = false;
            this.CbxTogglePF.CheckedChanged += new System.EventHandler(this.CbxTogglePF_CheckedChanged);
            // 
            // BtnPlot
            // 
            this.BtnPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPlot.BackColor = System.Drawing.Color.LightBlue;
            this.TLP.SetColumnSpan(this.BtnPlot, 2);
            this.BtnPlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlot.Location = new System.Drawing.Point(3, 208);
            this.BtnPlot.Name = "BtnPlot";
            this.BtnPlot.Size = new System.Drawing.Size(328, 44);
            this.BtnPlot.TabIndex = 3;
            this.BtnPlot.Text = "Plot";
            this.BtnPlot.UseVisualStyleBackColor = false;
            this.BtnPlot.Click += new System.EventHandler(this.BtnPlot_Click);
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
            this.CriteriaOLV.Location = new System.Drawing.Point(3, 258);
            this.CriteriaOLV.Name = "CriteriaOLV";
            this.CriteriaOLV.ShowGroups = false;
            this.CriteriaOLV.Size = new System.Drawing.Size(328, 121);
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.Button BtnPlot;
        private System.Windows.Forms.Button BtnMakeCycleFile;
        private System.Windows.Forms.Label LabelLoading;
        private System.Windows.Forms.Button BtnSave;
        private BrightIdeasSoftware.ObjectListView FeatureOLV;
        private BrightIdeasSoftware.OLVColumn featureOlvIgnore;
        private BrightIdeasSoftware.OLVColumn featureOlvName;
        private BrightIdeasSoftware.OLVColumn featureOlvCriteria;
        private BrightIdeasSoftware.OLVColumn featureOlvImage;
        private System.Windows.Forms.CheckBox CbxTogglePF;
        private System.Windows.Forms.Button BtnCombineSelected;
        private BrightIdeasSoftware.ObjectListView CriteriaOLV;
        private BrightIdeasSoftware.OLVColumn criteriaOlvPass;
        private BrightIdeasSoftware.OLVColumn criteriaOlvName;
        private BrightIdeasSoftware.OLVColumn criteriaOlvID;
        private System.Windows.Forms.Button BtnResetCriteria;
    }
}