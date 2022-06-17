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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsNewSEYRUPToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TogglePassFailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetCriteiraGroupingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetCriteriaPlotSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupFeaturesIntoCriteriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FeatureOLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CriteriaOLV)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 1;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.Controls.Add(this.FeatureOLV, 0, 2);
            this.TLP.Controls.Add(this.CriteriaOLV, 0, 5);
            this.TLP.Controls.Add(this.label1, 0, 1);
            this.TLP.Controls.Add(this.label2, 0, 4);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 24);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 6;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.Size = new System.Drawing.Size(334, 387);
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
            this.FeatureOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this.FeatureOLV.FullRowSelect = true;
            this.FeatureOLV.HasCollapsibleGroups = false;
            this.FeatureOLV.HideSelection = false;
            this.FeatureOLV.Location = new System.Drawing.Point(3, 33);
            this.FeatureOLV.Name = "FeatureOLV";
            this.FeatureOLV.ShowGroups = false;
            this.FeatureOLV.Size = new System.Drawing.Size(328, 157);
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
            this.CriteriaOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this.CriteriaOLV.FullRowSelect = true;
            this.CriteriaOLV.HasCollapsibleGroups = false;
            this.CriteriaOLV.HideSelection = false;
            this.CriteriaOLV.Location = new System.Drawing.Point(3, 226);
            this.CriteriaOLV.Name = "CriteriaOLV";
            this.CriteriaOLV.ShowGroups = false;
            this.CriteriaOLV.Size = new System.Drawing.Size(328, 158);
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
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Feature Manager";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Plotted Criteria";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsToolStripMenuItem,
            this.PlotToolStripMenuItem,
            this.LoadingToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(334, 24);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveAsNewSEYRUPToolStripMenuItem1,
            this.TogglePassFailToolStripMenuItem,
            this.ResetCriteiraGroupingsToolStripMenuItem,
            this.ResetCriteriaPlotSettingsToolStripMenuItem,
            this.GroupFeaturesIntoCriteriaToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.ToolsToolStripMenuItem.Text = "Tools";
            // 
            // SaveAsNewSEYRUPToolStripMenuItem1
            // 
            this.SaveAsNewSEYRUPToolStripMenuItem1.Name = "SaveAsNewSEYRUPToolStripMenuItem1";
            this.SaveAsNewSEYRUPToolStripMenuItem1.Size = new System.Drawing.Size(237, 22);
            this.SaveAsNewSEYRUPToolStripMenuItem1.Text = "Save As New SEYRUP";
            this.SaveAsNewSEYRUPToolStripMenuItem1.Click += new System.EventHandler(this.SaveAsNewSEYRUPToolStripMenuItem1_Click);
            // 
            // TogglePassFailToolStripMenuItem
            // 
            this.TogglePassFailToolStripMenuItem.CheckOnClick = true;
            this.TogglePassFailToolStripMenuItem.Name = "TogglePassFailToolStripMenuItem";
            this.TogglePassFailToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.TogglePassFailToolStripMenuItem.Text = "Toggle Pass Fail";
            this.TogglePassFailToolStripMenuItem.Click += new System.EventHandler(this.TogglePassFailToolStripMenuItem_Click);
            // 
            // ResetCriteiraGroupingsToolStripMenuItem
            // 
            this.ResetCriteiraGroupingsToolStripMenuItem.Name = "ResetCriteiraGroupingsToolStripMenuItem";
            this.ResetCriteiraGroupingsToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.ResetCriteiraGroupingsToolStripMenuItem.Text = "Reset Criteira Groupings";
            this.ResetCriteiraGroupingsToolStripMenuItem.Click += new System.EventHandler(this.ResetCriteiraGroupingsToolStripMenuItem_Click);
            // 
            // ResetCriteriaPlotSettingsToolStripMenuItem
            // 
            this.ResetCriteriaPlotSettingsToolStripMenuItem.Name = "ResetCriteriaPlotSettingsToolStripMenuItem";
            this.ResetCriteriaPlotSettingsToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.ResetCriteriaPlotSettingsToolStripMenuItem.Text = "Reset Criteria Plot Settings";
            this.ResetCriteriaPlotSettingsToolStripMenuItem.Click += new System.EventHandler(this.ResetCriteriaPlotSettingsToolStripMenuItem_Click);
            // 
            // GroupFeaturesIntoCriteriaToolStripMenuItem
            // 
            this.GroupFeaturesIntoCriteriaToolStripMenuItem.Name = "GroupFeaturesIntoCriteriaToolStripMenuItem";
            this.GroupFeaturesIntoCriteriaToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.GroupFeaturesIntoCriteriaToolStripMenuItem.Text = "Group Features Into Criteria (g)";
            this.GroupFeaturesIntoCriteriaToolStripMenuItem.Click += new System.EventHandler(this.GroupFeaturesIntoCriteriaToolStripMenuItem_Click);
            // 
            // PlotToolStripMenuItem
            // 
            this.PlotToolStripMenuItem.AutoSize = false;
            this.PlotToolStripMenuItem.BackColor = System.Drawing.Color.LightBlue;
            this.PlotToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.PlotToolStripMenuItem.Name = "PlotToolStripMenuItem";
            this.PlotToolStripMenuItem.Size = new System.Drawing.Size(175, 20);
            this.PlotToolStripMenuItem.Text = "Plot";
            this.PlotToolStripMenuItem.Click += new System.EventHandler(this.PlotToolStripMenuItem_Click);
            // 
            // LoadingToolStripMenuItem
            // 
            this.LoadingToolStripMenuItem.AutoSize = false;
            this.LoadingToolStripMenuItem.BackColor = System.Drawing.Color.Bisque;
            this.LoadingToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LoadingToolStripMenuItem.Name = "LoadingToolStripMenuItem";
            this.LoadingToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.LoadingToolStripMenuItem.Text = "Loading...";
            this.LoadingToolStripMenuItem.Visible = false;
            // 
            // ParseSEYR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 411);
            this.Controls.Add(this.TLP);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(350, 450);
            this.Name = "ParseSEYR";
            this.Text = "Parse SEYR";
            this.Load += new System.EventHandler(this.ParseSEYR_Load);
            this.TLP.ResumeLayout(false);
            this.TLP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FeatureOLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CriteriaOLV)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsNewSEYRUPToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TogglePassFailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetCriteiraGroupingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetCriteriaPlotSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadingToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem GroupFeaturesIntoCriteriaToolStripMenuItem;
    }
}