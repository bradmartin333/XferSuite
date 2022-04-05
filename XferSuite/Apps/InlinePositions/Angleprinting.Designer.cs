
namespace XferSuite.Apps.InlinePositions
{
    partial class Angleprinting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Angleprinting));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PrintList = new System.Windows.Forms.ListBox();
            this.plot = new OxyPlot.WindowsForms.PlotView();
            this.btnSavePlot = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.PrintList, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.plot, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.btnSavePlot, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(543, 424);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // PrintList
            // 
            this.PrintList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrintList.FormattingEnabled = true;
            this.PrintList.Location = new System.Drawing.Point(3, 3);
            this.PrintList.Name = "PrintList";
            this.PrintList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PrintList.Size = new System.Drawing.Size(119, 387);
            this.PrintList.TabIndex = 0;
            this.PrintList.SelectedIndexChanged += new System.EventHandler(this.PrintList_SelectedIndexChanged);
            this.PrintList.DoubleClick += new System.EventHandler(this.PrintList_DoubleClick);
            // 
            // plot
            // 
            this.plot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot.Location = new System.Drawing.Point(128, 3);
            this.plot.Name = "plot";
            this.plot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel.SetRowSpan(this.plot, 2);
            this.plot.Size = new System.Drawing.Size(412, 418);
            this.plot.TabIndex = 1;
            this.plot.Text = "plotView1";
            this.plot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // btnSavePlot
            // 
            this.btnSavePlot.AutoSize = true;
            this.btnSavePlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSavePlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePlot.Location = new System.Drawing.Point(3, 396);
            this.btnSavePlot.Name = "btnSavePlot";
            this.btnSavePlot.Size = new System.Drawing.Size(119, 25);
            this.btnSavePlot.TabIndex = 2;
            this.btnSavePlot.Text = "Save Plot";
            this.btnSavePlot.UseVisualStyleBackColor = true;
            this.btnSavePlot.Click += new System.EventHandler(this.btnSavePlot_Click);
            // 
            // Angleprinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 424);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Angleprinting";
            this.Text = "Angleprinting";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ListBox PrintList;
        private OxyPlot.WindowsForms.PlotView plot;
        private System.Windows.Forms.Button btnSavePlot;
    }
}