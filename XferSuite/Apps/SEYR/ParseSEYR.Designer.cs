
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
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.toolStripButtonParse = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddCustom = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReset = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSmartSort = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopyParsedCSV = new System.Windows.Forms.ToolStripButton();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
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
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Controls.Add(this.olvNeedOne, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.olvRequire, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.olvBuffer, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanelCriteria, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label2, 4, 1);
            this.tableLayoutPanel.Controls.Add(this.checkedListBox, 4, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(574, 270);
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
            this.olvNeedOne.Location = new System.Drawing.Point(345, 33);
            this.olvNeedOne.Name = "olvNeedOne";
            this.tableLayoutPanel.SetRowSpan(this.olvNeedOne, 2);
            this.olvNeedOne.ShowGroups = false;
            this.olvNeedOne.Size = new System.Drawing.Size(108, 234);
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
            this.olvRequire.Location = new System.Drawing.Point(231, 33);
            this.olvRequire.Name = "olvRequire";
            this.tableLayoutPanel.SetRowSpan(this.olvRequire, 2);
            this.olvRequire.ShowGroups = false;
            this.olvRequire.Size = new System.Drawing.Size(108, 234);
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
            this.olvBuffer.Location = new System.Drawing.Point(117, 33);
            this.olvBuffer.Name = "olvBuffer";
            this.tableLayoutPanel.SetRowSpan(this.olvBuffer, 2);
            this.olvBuffer.ShowGroups = false;
            this.olvBuffer.Size = new System.Drawing.Size(108, 234);
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
            this.flowLayoutPanelCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
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
            this.flowLayoutPanelCriteria.Location = new System.Drawing.Point(3, 62);
            this.flowLayoutPanelCriteria.Name = "flowLayoutPanelCriteria";
            this.tableLayoutPanel.SetRowSpan(this.flowLayoutPanelCriteria, 2);
            this.flowLayoutPanelCriteria.Size = new System.Drawing.Size(108, 175);
            this.flowLayoutPanelCriteria.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Functional Criteria";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelectedFeature
            // 
            this.lblSelectedFeature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedFeature.AutoSize = true;
            this.lblSelectedFeature.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFeature.Location = new System.Drawing.Point(3, 13);
            this.lblSelectedFeature.Name = "lblSelectedFeature";
            this.lblSelectedFeature.Size = new System.Drawing.Size(91, 12);
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
            this.cbxPass.Location = new System.Drawing.Point(3, 28);
            this.cbxPass.Name = "cbxPass";
            this.cbxPass.Size = new System.Drawing.Size(91, 17);
            this.cbxPass.TabIndex = 2;
            this.cbxPass.Tag = "0";
            this.cbxPass.Text = "Pass";
            this.cbxPass.UseVisualStyleBackColor = true;
            this.cbxPass.CheckedChanged += new System.EventHandler(this.Cbx_CheckedChanged);
            // 
            // cbxFail
            // 
            this.cbxFail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFail.AutoSize = true;
            this.cbxFail.Location = new System.Drawing.Point(3, 51);
            this.cbxFail.Name = "cbxFail";
            this.cbxFail.Size = new System.Drawing.Size(91, 17);
            this.cbxFail.TabIndex = 3;
            this.cbxFail.Tag = "1";
            this.cbxFail.Text = "Fail";
            this.cbxFail.UseVisualStyleBackColor = true;
            this.cbxFail.CheckedChanged += new System.EventHandler(this.Cbx_CheckedChanged);
            // 
            // cbxNull
            // 
            this.cbxNull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxNull.AutoSize = true;
            this.cbxNull.Location = new System.Drawing.Point(3, 74);
            this.cbxNull.Name = "cbxNull";
            this.cbxNull.Size = new System.Drawing.Size(91, 17);
            this.cbxNull.TabIndex = 4;
            this.cbxNull.Tag = "2";
            this.cbxNull.Text = "Null";
            this.cbxNull.UseVisualStyleBackColor = true;
            this.cbxNull.CheckedChanged += new System.EventHandler(this.Cbx_CheckedChanged);
            // 
            // cbxMisaligned
            // 
            this.cbxMisaligned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxMisaligned.AutoSize = true;
            this.cbxMisaligned.Location = new System.Drawing.Point(3, 97);
            this.cbxMisaligned.Name = "cbxMisaligned";
            this.cbxMisaligned.Size = new System.Drawing.Size(91, 17);
            this.cbxMisaligned.TabIndex = 5;
            this.cbxMisaligned.Tag = "3";
            this.cbxMisaligned.Text = "Misaligned";
            this.cbxMisaligned.UseVisualStyleBackColor = true;
            this.cbxMisaligned.CheckedChanged += new System.EventHandler(this.Cbx_CheckedChanged);
            // 
            // btnApplyToAll
            // 
            this.btnApplyToAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyToAll.Location = new System.Drawing.Point(3, 120);
            this.btnApplyToAll.Name = "btnApplyToAll";
            this.btnApplyToAll.Size = new System.Drawing.Size(91, 23);
            this.btnApplyToAll.TabIndex = 8;
            this.btnApplyToAll.Text = "Apply To All";
            this.btnApplyToAll.UseVisualStyleBackColor = true;
            this.btnApplyToAll.Click += new System.EventHandler(this.BtnApplyToAll_Click);
            // 
            // btnViewData
            // 
            this.btnViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewData.Location = new System.Drawing.Point(3, 149);
            this.btnViewData.Name = "btnViewData";
            this.btnViewData.Size = new System.Drawing.Size(91, 23);
            this.btnViewData.TabIndex = 9;
            this.btnViewData.Text = "View Data";
            this.btnViewData.UseVisualStyleBackColor = true;
            this.btnViewData.Click += new System.EventHandler(this.BtnViewData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(459, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Custom";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkedListBox
            // 
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(459, 53);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(112, 214);
            this.checkedListBox.TabIndex = 6;
            // 
            // toolStripButtonParse
            // 
            this.toolStripButtonParse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonParse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonParse.Image")));
            this.toolStripButtonParse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonParse.Name = "toolStripButtonParse";
            this.toolStripButtonParse.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonParse.Text = "Parse";
            this.toolStripButtonParse.Click += new System.EventHandler(this.ToolStripButtonParse_Click);
            // 
            // toolStripButtonAddCustom
            // 
            this.toolStripButtonAddCustom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddCustom.Enabled = false;
            this.toolStripButtonAddCustom.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddCustom.Image")));
            this.toolStripButtonAddCustom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddCustom.Name = "toolStripButtonAddCustom";
            this.toolStripButtonAddCustom.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonAddCustom.Text = "Add Custom";
            this.toolStripButtonAddCustom.Click += new System.EventHandler(this.ToolStripButtonAddCustom_Click);
            // 
            // toolStripButtonReset
            // 
            this.toolStripButtonReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReset.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReset.Image")));
            this.toolStripButtonReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReset.Name = "toolStripButtonReset";
            this.toolStripButtonReset.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonReset.Text = "Reset Columns";
            this.toolStripButtonReset.Click += new System.EventHandler(this.ToolStripButtonReset_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonParse,
            this.toolStripButtonSmartSort,
            this.toolStripButtonAddCustom,
            this.toolStripButtonReset,
            this.toolStripButtonCopyParsedCSV,
            this.toolStripProgressBar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(574, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSmartSort
            // 
            this.toolStripButtonSmartSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSmartSort.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSmartSort.Image")));
            this.toolStripButtonSmartSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSmartSort.Name = "toolStripButtonSmartSort";
            this.toolStripButtonSmartSort.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonSmartSort.Text = "Smart Sort";
            this.toolStripButtonSmartSort.Click += new System.EventHandler(this.ToolStripButtonSmartSort_Click);
            // 
            // toolStripButtonCopyParsedCSV
            // 
            this.toolStripButtonCopyParsedCSV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopyParsedCSV.Enabled = false;
            this.toolStripButtonCopyParsedCSV.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopyParsedCSV.Image")));
            this.toolStripButtonCopyParsedCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopyParsedCSV.Name = "toolStripButtonCopyParsedCSV";
            this.toolStripButtonCopyParsedCSV.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonCopyParsedCSV.Text = "Copy Parsed Data as CSV";
            this.toolStripButtonCopyParsedCSV.Click += new System.EventHandler(this.ToolStripButtonCopyParsedCSV_Click);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(380, 24);
            // 
            // ParseSEYR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 270);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(590, 266);
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
        private System.Windows.Forms.ToolStripButton toolStripButtonParse;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddCustom;
        private System.Windows.Forms.ToolStripButton toolStripButtonReset;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopyParsedCSV;
        private BrightIdeasSoftware.TreeListView olvNeedOne;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.ObjectListView olvRequire;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.ObjectListView olvBuffer;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCriteria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectedFeature;
        private System.Windows.Forms.CheckBox cbxPass;
        private System.Windows.Forms.CheckBox cbxFail;
        private System.Windows.Forms.CheckBox cbxNull;
        private System.Windows.Forms.CheckBox cbxMisaligned;
        private System.Windows.Forms.Button btnApplyToAll;
        private System.Windows.Forms.Button btnViewData;
        private System.Windows.Forms.ToolStripButton toolStripButtonSmartSort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBox;
    }
}