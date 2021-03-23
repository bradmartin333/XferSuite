
namespace XferSuite
{
    partial class EventLogParsing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventLogParsing));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.plot = new OxyPlot.WindowsForms.PlotView();
            this.fastObjectListView = new BrightIdeasSoftware.FastObjectListView();
            this.idxColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.timeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.categoryColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.descriptionColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.eventColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dataColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lblFilterPercent = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.plot, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.fastObjectListView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFilterPercent, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1113, 612);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // plot
            // 
            this.plot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot.Location = new System.Drawing.Point(3, 315);
            this.plot.Name = "plot";
            this.plot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot.Size = new System.Drawing.Size(1107, 294);
            this.plot.TabIndex = 4;
            this.plot.Text = "plotView1";
            this.plot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // fastObjectListView
            // 
            this.fastObjectListView.AllColumns.Add(this.idxColumn);
            this.fastObjectListView.AllColumns.Add(this.dateColumn);
            this.fastObjectListView.AllColumns.Add(this.timeColumn);
            this.fastObjectListView.AllColumns.Add(this.categoryColumn);
            this.fastObjectListView.AllColumns.Add(this.descriptionColumn);
            this.fastObjectListView.AllColumns.Add(this.eventColumn);
            this.fastObjectListView.AllColumns.Add(this.dataColumn);
            this.fastObjectListView.AllowColumnReorder = true;
            this.fastObjectListView.CellEditUseWholeCell = false;
            this.fastObjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idxColumn,
            this.dateColumn,
            this.timeColumn,
            this.categoryColumn,
            this.descriptionColumn,
            this.eventColumn,
            this.dataColumn});
            this.fastObjectListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView.FullRowSelect = true;
            this.fastObjectListView.HideSelection = false;
            this.fastObjectListView.Location = new System.Drawing.Point(3, 16);
            this.fastObjectListView.Name = "fastObjectListView";
            this.fastObjectListView.ShowGroups = false;
            this.fastObjectListView.Size = new System.Drawing.Size(1107, 293);
            this.fastObjectListView.TabIndex = 5;
            this.fastObjectListView.TintSortColumn = true;
            this.fastObjectListView.UseAlternatingBackColors = true;
            this.fastObjectListView.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView.UseFiltering = true;
            this.fastObjectListView.UseHotItem = true;
            this.fastObjectListView.View = System.Windows.Forms.View.Details;
            this.fastObjectListView.VirtualMode = true;
            // 
            // idxColumn
            // 
            this.idxColumn.AspectName = "IDX";
            this.idxColumn.Text = "Index";
            this.idxColumn.Width = 39;
            // 
            // dateColumn
            // 
            this.dateColumn.AspectName = "Date";
            this.dateColumn.AspectToStringFormat = "{0:d}";
            this.dateColumn.Text = "Date";
            this.dateColumn.Width = 110;
            // 
            // timeColumn
            // 
            this.timeColumn.AspectName = "Time";
            this.timeColumn.AspectToStringFormat = "{0:g}";
            this.timeColumn.Text = "Time";
            this.timeColumn.Width = 102;
            // 
            // categoryColumn
            // 
            this.categoryColumn.AspectName = "Category";
            this.categoryColumn.Text = "Category";
            this.categoryColumn.Width = 133;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.AspectName = "Description";
            this.descriptionColumn.Text = "Description";
            this.descriptionColumn.Width = 234;
            // 
            // eventColumn
            // 
            this.eventColumn.AspectName = "Msg";
            this.eventColumn.Text = "Event";
            this.eventColumn.Width = 259;
            // 
            // dataColumn
            // 
            this.dataColumn.AspectName = "Data";
            this.dataColumn.Text = "Data";
            this.dataColumn.Width = 235;
            // 
            // lblFilterPercent
            // 
            this.lblFilterPercent.AutoSize = true;
            this.lblFilterPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilterPercent.Location = new System.Drawing.Point(3, 0);
            this.lblFilterPercent.Name = "lblFilterPercent";
            this.lblFilterPercent.Size = new System.Drawing.Size(1107, 13);
            this.lblFilterPercent.TabIndex = 6;
            this.lblFilterPercent.Text = "label1";
            this.lblFilterPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventLogParsing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 612);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EventLogParsing";
            this.Text = "Event Log Parsing";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private OxyPlot.WindowsForms.PlotView plot;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView;
        private BrightIdeasSoftware.OLVColumn dateColumn;
        private BrightIdeasSoftware.OLVColumn eventColumn;
        private BrightIdeasSoftware.OLVColumn timeColumn;
        private BrightIdeasSoftware.OLVColumn categoryColumn;
        private BrightIdeasSoftware.OLVColumn descriptionColumn;
        private BrightIdeasSoftware.OLVColumn dataColumn;
        private System.Windows.Forms.Label lblFilterPercent;
        private BrightIdeasSoftware.OLVColumn idxColumn;
    }
}