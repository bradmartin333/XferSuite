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
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnMakeCycleFile = new System.Windows.Forms.Button();
            this.LabelLoading = new System.Windows.Forms.Label();
            this.OLV = new BrightIdeasSoftware.ObjectListView();
            this.olvIgnore = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCriteria = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvImage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BtnPlot = new System.Windows.Forms.Button();
            this.CbxTogglePF = new System.Windows.Forms.CheckBox();
            this.PBXLegend = new System.Windows.Forms.PictureBox();
            this.BtnCombineSelected = new System.Windows.Forms.Button();
            this.TLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBXLegend)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 2;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.TLP.Controls.Add(this.BtnCombineSelected, 0, 2);
            this.TLP.Controls.Add(this.BtnSave, 1, 2);
            this.TLP.Controls.Add(this.BtnMakeCycleFile, 1, 3);
            this.TLP.Controls.Add(this.LabelLoading, 0, 1);
            this.TLP.Controls.Add(this.OLV, 0, 0);
            this.TLP.Controls.Add(this.CbxTogglePF, 0, 3);
            this.TLP.Controls.Add(this.PBXLegend, 0, 5);
            this.TLP.Controls.Add(this.BtnPlot, 0, 4);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 6;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.Size = new System.Drawing.Size(302, 408);
            this.TLP.TabIndex = 1;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.BackColor = System.Drawing.Color.White;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Location = new System.Drawing.Point(154, 163);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(145, 23);
            this.BtnSave.TabIndex = 7;
            this.BtnSave.Text = "Make SEYRUP";
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
            this.BtnMakeCycleFile.Location = new System.Drawing.Point(154, 192);
            this.BtnMakeCycleFile.Name = "BtnMakeCycleFile";
            this.BtnMakeCycleFile.Size = new System.Drawing.Size(145, 23);
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
            this.LabelLoading.Location = new System.Drawing.Point(3, 140);
            this.LabelLoading.Name = "LabelLoading";
            this.LabelLoading.Size = new System.Drawing.Size(296, 20);
            this.LabelLoading.TabIndex = 6;
            this.LabelLoading.Text = "Loading...";
            this.LabelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelLoading.Visible = false;
            // 
            // OLV
            // 
            this.OLV.AllColumns.Add(this.olvIgnore);
            this.OLV.AllColumns.Add(this.olvName);
            this.OLV.AllColumns.Add(this.olvCriteria);
            this.OLV.AllColumns.Add(this.olvImage);
            this.OLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OLV.CellEditUseWholeCell = false;
            this.OLV.CheckBoxes = true;
            this.OLV.CheckedAspectName = "Ignore";
            this.OLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvIgnore,
            this.olvName,
            this.olvCriteria,
            this.olvImage});
            this.TLP.SetColumnSpan(this.OLV, 2);
            this.OLV.Cursor = System.Windows.Forms.Cursors.Default;
            this.OLV.FullRowSelect = true;
            this.OLV.HasCollapsibleGroups = false;
            this.OLV.HideSelection = false;
            this.OLV.Location = new System.Drawing.Point(3, 3);
            this.OLV.Name = "OLV";
            this.OLV.ShowGroups = false;
            this.OLV.Size = new System.Drawing.Size(296, 134);
            this.OLV.TabIndex = 8;
            this.OLV.UseCompatibleStateImageBehavior = false;
            this.OLV.View = System.Windows.Forms.View.Details;
            // 
            // olvIgnore
            // 
            this.olvIgnore.AspectName = "Ignore";
            this.olvIgnore.CheckBoxes = true;
            this.olvIgnore.Text = "Ignore";
            this.olvIgnore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvName
            // 
            this.olvName.AspectName = "Name";
            this.olvName.Text = "Name";
            this.olvName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvCriteria
            // 
            this.olvCriteria.AspectName = "CriteriaString";
            this.olvCriteria.FillsFreeSpace = true;
            this.olvCriteria.Text = "Criteria String";
            this.olvCriteria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvImage
            // 
            this.olvImage.AspectName = "SaveImage";
            this.olvImage.AspectToStringFormat = "{0}";
            this.olvImage.Text = "Image";
            this.olvImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnPlot
            // 
            this.BtnPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPlot.BackColor = System.Drawing.Color.White;
            this.TLP.SetColumnSpan(this.BtnPlot, 2);
            this.BtnPlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlot.Location = new System.Drawing.Point(3, 221);
            this.BtnPlot.Name = "BtnPlot";
            this.BtnPlot.Size = new System.Drawing.Size(296, 44);
            this.BtnPlot.TabIndex = 3;
            this.BtnPlot.Text = "Plot";
            this.BtnPlot.UseVisualStyleBackColor = false;
            this.BtnPlot.Click += new System.EventHandler(this.BtnPlot_Click);
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
            this.CbxTogglePF.Location = new System.Drawing.Point(3, 192);
            this.CbxTogglePF.Name = "CbxTogglePF";
            this.CbxTogglePF.Size = new System.Drawing.Size(145, 23);
            this.CbxTogglePF.TabIndex = 9;
            this.CbxTogglePF.Text = "Toggle Pass Fail";
            this.CbxTogglePF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CbxTogglePF.UseVisualStyleBackColor = false;
            this.CbxTogglePF.CheckedChanged += new System.EventHandler(this.CbxTogglePF_CheckedChanged);
            // 
            // PBXLegend
            // 
            this.PBXLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PBXLegend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TLP.SetColumnSpan(this.PBXLegend, 2);
            this.PBXLegend.Location = new System.Drawing.Point(3, 271);
            this.PBXLegend.Name = "PBXLegend";
            this.PBXLegend.Size = new System.Drawing.Size(296, 134);
            this.PBXLegend.TabIndex = 10;
            this.PBXLegend.TabStop = false;
            // 
            // BtnCombineSelected
            // 
            this.BtnCombineSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCombineSelected.BackColor = System.Drawing.Color.White;
            this.BtnCombineSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCombineSelected.Location = new System.Drawing.Point(3, 163);
            this.BtnCombineSelected.Name = "BtnCombineSelected";
            this.BtnCombineSelected.Size = new System.Drawing.Size(145, 23);
            this.BtnCombineSelected.TabIndex = 11;
            this.BtnCombineSelected.Text = "Combine Selected";
            this.BtnCombineSelected.UseVisualStyleBackColor = false;
            this.BtnCombineSelected.Click += new System.EventHandler(this.BtnCombineSelected_Click);
            // 
            // ParseSEYR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 408);
            this.Controls.Add(this.TLP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(315, 150);
            this.Name = "ParseSEYR";
            this.Text = "Parse SEYR";
            this.Load += new System.EventHandler(this.ParseSEYR_Load);
            this.TLP.ResumeLayout(false);
            this.TLP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBXLegend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.Button BtnPlot;
        private System.Windows.Forms.Button BtnMakeCycleFile;
        private System.Windows.Forms.Label LabelLoading;
        private System.Windows.Forms.Button BtnSave;
        private BrightIdeasSoftware.ObjectListView OLV;
        private BrightIdeasSoftware.OLVColumn olvIgnore;
        private BrightIdeasSoftware.OLVColumn olvName;
        private BrightIdeasSoftware.OLVColumn olvCriteria;
        private BrightIdeasSoftware.OLVColumn olvImage;
        private System.Windows.Forms.CheckBox CbxTogglePF;
        private System.Windows.Forms.PictureBox PBXLegend;
        private System.Windows.Forms.Button BtnCombineSelected;
    }
}