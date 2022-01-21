
namespace XferSuite
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.olvNeedOne = new BrightIdeasSoftware.TreeListView();
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvRequire = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBuffer = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.flowLayoutPanelCriteria = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectedFeature = new System.Windows.Forms.Label();
            this.cbxPass = new System.Windows.Forms.CheckBox();
            this.cbxFail = new System.Windows.Forms.CheckBox();
            this.cbxNull = new System.Windows.Forms.CheckBox();
            this.cbxMisaligned = new System.Windows.Forms.CheckBox();
            this.btnApplyToAll = new System.Windows.Forms.Button();
            this.btnViewData = new System.Windows.Forms.Button();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.toolStripButtonParse = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSmartSort = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReset = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonParseNoPicthes = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopyWindow = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSpecificRegion = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvNeedOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvRequire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvBuffer)).BeginInit();
            this.flowLayoutPanelCriteria.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel.Controls.Add(this.olvNeedOne, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.olvRequire, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.olvBuffer, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanelCriteria, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.rtb, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(527, 460);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // olvNeedOne
            // 
            this.olvNeedOne.AllColumns.Add(this.olvColumn3);
            this.olvNeedOne.CellEditUseWholeCell = false;
            this.olvNeedOne.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn3});
            this.olvNeedOne.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvNeedOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvNeedOne.HideSelection = false;
            this.olvNeedOne.IsSimpleDropSink = true;
            this.olvNeedOne.Location = new System.Drawing.Point(354, 35);
            this.olvNeedOne.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.olvNeedOne.Name = "olvNeedOne";
            this.olvNeedOne.ShowGroups = false;
            this.olvNeedOne.Size = new System.Drawing.Size(169, 198);
            this.olvNeedOne.TabIndex = 2;
            this.olvNeedOne.Tag = "2";
            this.olvNeedOne.UseCompatibleStateImageBehavior = false;
            this.olvNeedOne.View = System.Windows.Forms.View.Details;
            this.olvNeedOne.VirtualMode = true;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Name";
            this.olvColumn3.Text = "Need One";
            this.olvColumn3.Width = 90;
            // 
            // olvRequire
            // 
            this.olvRequire.AllColumns.Add(this.olvColumn2);
            this.olvRequire.CellEditUseWholeCell = false;
            this.olvRequire.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn2});
            this.olvRequire.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvRequire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvRequire.HideSelection = false;
            this.olvRequire.IsSimpleDropSink = true;
            this.olvRequire.Location = new System.Drawing.Point(179, 35);
            this.olvRequire.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.olvRequire.Name = "olvRequire";
            this.olvRequire.ShowGroups = false;
            this.olvRequire.Size = new System.Drawing.Size(167, 198);
            this.olvRequire.TabIndex = 1;
            this.olvRequire.Tag = "1";
            this.olvRequire.UseCompatibleStateImageBehavior = false;
            this.olvRequire.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Name";
            this.olvColumn2.Text = "Require";
            this.olvColumn2.Width = 90;
            // 
            // olvBuffer
            // 
            this.olvBuffer.AllColumns.Add(this.olvColumn1);
            this.olvBuffer.CellEditUseWholeCell = false;
            this.olvBuffer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
            this.olvBuffer.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvBuffer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvBuffer.HideSelection = false;
            this.olvBuffer.IsSimpleDragSource = true;
            this.olvBuffer.Location = new System.Drawing.Point(4, 35);
            this.olvBuffer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.olvBuffer.Name = "olvBuffer";
            this.olvBuffer.ShowGroups = false;
            this.olvBuffer.Size = new System.Drawing.Size(167, 198);
            this.olvBuffer.TabIndex = 0;
            this.olvBuffer.Tag = "0";
            this.olvBuffer.UseCompatibleStateImageBehavior = false;
            this.olvBuffer.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.Text = "Buffer";
            this.olvColumn1.Width = 90;
            // 
            // flowLayoutPanelCriteria
            // 
            this.flowLayoutPanelCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanelCriteria.AutoSize = true;
            this.flowLayoutPanelCriteria.Controls.Add(this.label1);
            this.flowLayoutPanelCriteria.Controls.Add(this.lblSelectedFeature);
            this.flowLayoutPanelCriteria.Controls.Add(this.cbxPass);
            this.flowLayoutPanelCriteria.Controls.Add(this.cbxFail);
            this.flowLayoutPanelCriteria.Controls.Add(this.cbxNull);
            this.flowLayoutPanelCriteria.Controls.Add(this.cbxMisaligned);
            this.flowLayoutPanelCriteria.Controls.Add(this.btnApplyToAll);
            this.flowLayoutPanelCriteria.Controls.Add(this.btnViewData);
            this.flowLayoutPanelCriteria.Enabled = false;
            this.flowLayoutPanelCriteria.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelCriteria.Location = new System.Drawing.Point(27, 241);
            this.flowLayoutPanelCriteria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanelCriteria.Name = "flowLayoutPanelCriteria";
            this.flowLayoutPanelCriteria.Size = new System.Drawing.Size(121, 215);
            this.flowLayoutPanelCriteria.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Functional Criteria";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelectedFeature
            // 
            this.lblSelectedFeature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedFeature.AutoSize = true;
            this.lblSelectedFeature.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFeature.Location = new System.Drawing.Point(4, 16);
            this.lblSelectedFeature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedFeature.Name = "lblSelectedFeature";
            this.lblSelectedFeature.Size = new System.Drawing.Size(113, 15);
            this.lblSelectedFeature.TabIndex = 7;
            this.lblSelectedFeature.Text = "N/A";
            this.lblSelectedFeature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxPass
            // 
            this.cbxPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPass.AutoSize = true;
            this.cbxPass.Checked = true;
            this.cbxPass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxPass.Location = new System.Drawing.Point(4, 35);
            this.cbxPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxPass.Name = "cbxPass";
            this.cbxPass.Size = new System.Drawing.Size(113, 20);
            this.cbxPass.TabIndex = 2;
            this.cbxPass.Tag = "0";
            this.cbxPass.Text = "Pass";
            this.cbxPass.UseVisualStyleBackColor = true;
            this.cbxPass.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            // 
            // cbxFail
            // 
            this.cbxFail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFail.AutoSize = true;
            this.cbxFail.Location = new System.Drawing.Point(4, 63);
            this.cbxFail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxFail.Name = "cbxFail";
            this.cbxFail.Size = new System.Drawing.Size(113, 20);
            this.cbxFail.TabIndex = 3;
            this.cbxFail.Tag = "1";
            this.cbxFail.Text = "Fail";
            this.cbxFail.UseVisualStyleBackColor = true;
            this.cbxFail.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            // 
            // cbxNull
            // 
            this.cbxNull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxNull.AutoSize = true;
            this.cbxNull.Location = new System.Drawing.Point(4, 91);
            this.cbxNull.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxNull.Name = "cbxNull";
            this.cbxNull.Size = new System.Drawing.Size(113, 20);
            this.cbxNull.TabIndex = 4;
            this.cbxNull.Tag = "2";
            this.cbxNull.Text = "Null";
            this.cbxNull.UseVisualStyleBackColor = true;
            this.cbxNull.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            // 
            // cbxMisaligned
            // 
            this.cbxMisaligned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxMisaligned.AutoSize = true;
            this.cbxMisaligned.Location = new System.Drawing.Point(4, 119);
            this.cbxMisaligned.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxMisaligned.Name = "cbxMisaligned";
            this.cbxMisaligned.Size = new System.Drawing.Size(113, 20);
            this.cbxMisaligned.TabIndex = 5;
            this.cbxMisaligned.Tag = "3";
            this.cbxMisaligned.Text = "Misaligned";
            this.cbxMisaligned.UseVisualStyleBackColor = true;
            this.cbxMisaligned.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            // 
            // btnApplyToAll
            // 
            this.btnApplyToAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyToAll.Location = new System.Drawing.Point(4, 147);
            this.btnApplyToAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnApplyToAll.Name = "btnApplyToAll";
            this.btnApplyToAll.Size = new System.Drawing.Size(113, 28);
            this.btnApplyToAll.TabIndex = 8;
            this.btnApplyToAll.Text = "Apply To All";
            this.btnApplyToAll.UseVisualStyleBackColor = true;
            this.btnApplyToAll.Click += new System.EventHandler(this.btnApplyToAll_Click);
            // 
            // btnViewData
            // 
            this.btnViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewData.Location = new System.Drawing.Point(4, 183);
            this.btnViewData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewData.Name = "btnViewData";
            this.btnViewData.Size = new System.Drawing.Size(113, 28);
            this.btnViewData.TabIndex = 9;
            this.btnViewData.Text = "View Data";
            this.btnViewData.UseVisualStyleBackColor = true;
            this.btnViewData.Click += new System.EventHandler(this.btnViewData_Click);
            // 
            // rtb
            // 
            this.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel.SetColumnSpan(this.rtb, 2);
            this.rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb.Location = new System.Drawing.Point(179, 241);
            this.rtb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(344, 215);
            this.rtb.TabIndex = 6;
            this.rtb.Text = "";
            // 
            // toolStripButtonParse
            // 
            this.toolStripButtonParse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonParse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonParse.Image")));
            this.toolStripButtonParse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonParse.Name = "toolStripButtonParse";
            this.toolStripButtonParse.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonParse.Text = "Parse";
            this.toolStripButtonParse.Click += new System.EventHandler(this.toolStripButtonParse_Click);
            // 
            // toolStripButtonSmartSort
            // 
            this.toolStripButtonSmartSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSmartSort.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSmartSort.Image")));
            this.toolStripButtonSmartSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSmartSort.Name = "toolStripButtonSmartSort";
            this.toolStripButtonSmartSort.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonSmartSort.Text = "Smart Sort";
            this.toolStripButtonSmartSort.Click += new System.EventHandler(this.toolStripButtonSmartSort_Click);
            // 
            // toolStripButtonReset
            // 
            this.toolStripButtonReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReset.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReset.Image")));
            this.toolStripButtonReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReset.Name = "toolStripButtonReset";
            this.toolStripButtonReset.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonReset.Text = "Reset Columns";
            this.toolStripButtonReset.Click += new System.EventHandler(this.toolStripButtonReset_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonParse,
            this.toolStripButtonParseNoPicthes,
            this.toolStripButtonSmartSort,
            this.toolStripButtonReset,
            this.toolStripButtonCopyWindow,
            this.toolStripButtonSpecificRegion});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(527, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonParseNoPicthes
            // 
            this.toolStripButtonParseNoPicthes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonParseNoPicthes.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonParseNoPicthes.Image")));
            this.toolStripButtonParseNoPicthes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonParseNoPicthes.Name = "toolStripButtonParseNoPicthes";
            this.toolStripButtonParseNoPicthes.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonParseNoPicthes.Text = "Parse Without Pitches";
            this.toolStripButtonParseNoPicthes.Click += new System.EventHandler(this.toolStripButtonParseNoPicthes_Click);
            // 
            // toolStripButtonCopyWindow
            // 
            this.toolStripButtonCopyWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopyWindow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopyWindow.Image")));
            this.toolStripButtonCopyWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopyWindow.Name = "toolStripButtonCopyWindow";
            this.toolStripButtonCopyWindow.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonCopyWindow.Text = "Copy Window to Clipboard";
            this.toolStripButtonCopyWindow.Click += new System.EventHandler(this.toolStripButtonCopyWindow_Click);
            // 
            // toolStripButtonSpecificRegion
            // 
            this.toolStripButtonSpecificRegion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSpecificRegion.Enabled = false;
            this.toolStripButtonSpecificRegion.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSpecificRegion.Image")));
            this.toolStripButtonSpecificRegion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSpecificRegion.Name = "toolStripButtonSpecificRegion";
            this.toolStripButtonSpecificRegion.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonSpecificRegion.Text = "Plot Specific Region";
            this.toolStripButtonSpecificRegion.Click += new System.EventHandler(this.toolStripButtonSpecificRegion_Click);
            // 
            // ParseSEYR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 460);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ParseSEYR";
            this.Text = "Parse SEYR";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvNeedOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvRequire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvBuffer)).EndInit();
            this.flowLayoutPanelCriteria.ResumeLayout(false);
            this.flowLayoutPanelCriteria.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private BrightIdeasSoftware.ObjectListView olvBuffer;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.TreeListView olvNeedOne;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.ObjectListView olvRequire;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCriteria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxPass;
        private System.Windows.Forms.CheckBox cbxFail;
        private System.Windows.Forms.CheckBox cbxNull;
        private System.Windows.Forms.CheckBox cbxMisaligned;
        private System.Windows.Forms.Label lblSelectedFeature;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Button btnApplyToAll;
        private System.Windows.Forms.Button btnViewData;
        private System.Windows.Forms.ToolStripButton toolStripButtonParse;
        private System.Windows.Forms.ToolStripButton toolStripButtonSmartSort;
        private System.Windows.Forms.ToolStripButton toolStripButtonReset;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonParseNoPicthes;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopyWindow;
        private System.Windows.Forms.ToolStripButton toolStripButtonSpecificRegion;
    }
}