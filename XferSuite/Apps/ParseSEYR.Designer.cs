
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
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonParse = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSmartSort = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopyText = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopyPlot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopyForExcel = new System.Windows.Forms.ToolStripButton();
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
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.85714F));
            this.tableLayoutPanel.Controls.Add(this.olvNeedOne, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.olvRequire, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.olvBuffer, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanelCriteria, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.rtb, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.plotView, 3, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(834, 361);
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
            this.olvNeedOne.Location = new System.Drawing.Point(319, 28);
            this.olvNeedOne.Name = "olvNeedOne";
            this.olvNeedOne.ShowGroups = false;
            this.olvNeedOne.Size = new System.Drawing.Size(152, 178);
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
            this.olvRequire.Location = new System.Drawing.Point(161, 28);
            this.olvRequire.Name = "olvRequire";
            this.olvRequire.ShowGroups = false;
            this.olvRequire.Size = new System.Drawing.Size(152, 178);
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
            this.olvBuffer.Location = new System.Drawing.Point(3, 28);
            this.olvBuffer.Name = "olvBuffer";
            this.olvBuffer.ShowGroups = false;
            this.olvBuffer.Size = new System.Drawing.Size(152, 178);
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
            this.flowLayoutPanelCriteria.Enabled = false;
            this.flowLayoutPanelCriteria.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelCriteria.Location = new System.Drawing.Point(30, 212);
            this.flowLayoutPanelCriteria.Name = "flowLayoutPanelCriteria";
            this.flowLayoutPanelCriteria.Size = new System.Drawing.Size(97, 146);
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
            this.cbxPass.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
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
            this.cbxFail.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
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
            this.cbxNull.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
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
            this.cbxMisaligned.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            // 
            // btnApplyToAll
            // 
            this.btnApplyToAll.Location = new System.Drawing.Point(3, 120);
            this.btnApplyToAll.Name = "btnApplyToAll";
            this.btnApplyToAll.Size = new System.Drawing.Size(75, 23);
            this.btnApplyToAll.TabIndex = 8;
            this.btnApplyToAll.Text = "Apply To All";
            this.btnApplyToAll.UseVisualStyleBackColor = true;
            this.btnApplyToAll.Click += new System.EventHandler(this.btnApplyToAll_Click);
            // 
            // rtb
            // 
            this.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel.SetColumnSpan(this.rtb, 2);
            this.rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb.Location = new System.Drawing.Point(161, 212);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(310, 146);
            this.rtb.TabIndex = 6;
            this.rtb.Text = "";
            // 
            // plotView
            // 
            this.plotView.BackColor = System.Drawing.Color.White;
            this.plotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView.Location = new System.Drawing.Point(477, 28);
            this.plotView.Name = "plotView";
            this.plotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel.SetRowSpan(this.plotView, 2);
            this.plotView.Size = new System.Drawing.Size(354, 330);
            this.plotView.TabIndex = 7;
            this.plotView.Text = "plotView1";
            this.plotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonParse,
            this.toolStripButtonSmartSort,
            this.toolStripButtonReset,
            this.toolStripButtonCopyText,
            this.toolStripButtonCopyPlot,
            this.toolStripButtonCopyForExcel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonParse
            // 
            this.toolStripButtonParse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonParse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonParse.Image")));
            this.toolStripButtonParse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonParse.Name = "toolStripButtonParse";
            this.toolStripButtonParse.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonParse.Text = "Parse";
            this.toolStripButtonParse.Click += new System.EventHandler(this.toolStripButtonParse_Click);
            // 
            // toolStripButtonSmartSort
            // 
            this.toolStripButtonSmartSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSmartSort.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSmartSort.Image")));
            this.toolStripButtonSmartSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSmartSort.Name = "toolStripButtonSmartSort";
            this.toolStripButtonSmartSort.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSmartSort.Text = "Smart Sort";
            this.toolStripButtonSmartSort.Click += new System.EventHandler(this.toolStripButtonSmartSort_Click);
            // 
            // toolStripButtonReset
            // 
            this.toolStripButtonReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReset.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReset.Image")));
            this.toolStripButtonReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReset.Name = "toolStripButtonReset";
            this.toolStripButtonReset.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonReset.Text = "Reset Columns";
            this.toolStripButtonReset.Click += new System.EventHandler(this.toolStripButtonReset_Click);
            // 
            // toolStripButtonCopyText
            // 
            this.toolStripButtonCopyText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopyText.Enabled = false;
            this.toolStripButtonCopyText.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopyText.Image")));
            this.toolStripButtonCopyText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopyText.Name = "toolStripButtonCopyText";
            this.toolStripButtonCopyText.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCopyText.Text = "Copy Text";
            this.toolStripButtonCopyText.Click += new System.EventHandler(this.toolStripButtonCopyText_Click);
            // 
            // toolStripButtonCopyPlot
            // 
            this.toolStripButtonCopyPlot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopyPlot.Enabled = false;
            this.toolStripButtonCopyPlot.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopyPlot.Image")));
            this.toolStripButtonCopyPlot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopyPlot.Name = "toolStripButtonCopyPlot";
            this.toolStripButtonCopyPlot.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCopyPlot.Text = "Copy Plot";
            this.toolStripButtonCopyPlot.Click += new System.EventHandler(this.toolStripButtonCopyPlot_Click);
            // 
            // toolStripButtonCopyForExcel
            // 
            this.toolStripButtonCopyForExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopyForExcel.Enabled = false;
            this.toolStripButtonCopyForExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopyForExcel.Image")));
            this.toolStripButtonCopyForExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopyForExcel.Name = "toolStripButtonCopyForExcel";
            this.toolStripButtonCopyForExcel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCopyForExcel.Text = "Copy Plot For Excel";
            this.toolStripButtonCopyForExcel.Click += new System.EventHandler(this.toolStripButtonCopyForExcel_Click);
            // 
            // ParseSEYR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 361);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 400);
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
        private OxyPlot.WindowsForms.PlotView plotView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonParse;
        private System.Windows.Forms.ToolStripButton toolStripButtonReset;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopyText;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopyPlot;
        private System.Windows.Forms.ToolStripButton toolStripButtonSmartSort;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopyForExcel;
    }
}