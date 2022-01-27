namespace XferSuite.XYZscan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plotter));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.olv = new BrightIdeasSoftware.FastDataListView();
            this.OlvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OlvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pA = new ScottPlot.FormsPlot();
            this.pB = new ScottPlot.FormsPlot();
            this.pC = new ScottPlot.FormsPlot();
            this.pD = new ScottPlot.FormsPlot();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.comboX = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.comboY = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.comboZ = new System.Windows.Forms.ToolStripComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.ProgressBar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.olv, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pA, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pB, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.pC, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pD, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1231, 664);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressBar.Location = new System.Drawing.Point(3, 3);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(363, 19);
            this.ProgressBar.Step = 1;
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 4;
            // 
            // olv
            // 
            this.olv.AllColumns.Add(this.OlvColumn3);
            this.olv.AllColumns.Add(this.OlvColumn6);
            this.olv.AllColumns.Add(this.OlvColumn1);
            this.olv.AllColumns.Add(this.OlvColumn2);
            this.olv.AllColumns.Add(this.OlvColumn4);
            this.olv.AllColumns.Add(this.OlvColumn5);
            this.olv.AllColumns.Add(this.OlvColumn7);
            this.olv.AllColumns.Add(this.OlvColumn8);
            this.olv.AllColumns.Add(this.OlvColumn9);
            this.olv.CellEditUseWholeCell = false;
            this.olv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OlvColumn3,
            this.OlvColumn6,
            this.OlvColumn1,
            this.OlvColumn2,
            this.OlvColumn4,
            this.OlvColumn5,
            this.OlvColumn7,
            this.OlvColumn8,
            this.OlvColumn9});
            this.olv.Cursor = System.Windows.Forms.Cursors.Default;
            this.olv.DataSource = null;
            this.olv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olv.FullRowSelect = true;
            this.olv.HideSelection = false;
            this.olv.Location = new System.Drawing.Point(3, 28);
            this.olv.Name = "olv";
            this.tableLayoutPanel1.SetRowSpan(this.olv, 2);
            this.olv.ShowGroups = false;
            this.olv.Size = new System.Drawing.Size(363, 633);
            this.olv.TabIndex = 3;
            this.olv.UseCompatibleStateImageBehavior = false;
            this.olv.UseFilterIndicator = true;
            this.olv.UseFiltering = true;
            this.olv.View = System.Windows.Forms.View.Details;
            this.olv.VirtualMode = true;
            // 
            // OlvColumn3
            // 
            this.OlvColumn3.AspectName = "Name";
            this.OlvColumn3.Text = "Name";
            this.OlvColumn3.Width = 370;
            // 
            // OlvColumn6
            // 
            this.OlvColumn6.AspectName = "Index";
            this.OlvColumn6.AspectToStringFormat = "{0}";
            this.OlvColumn6.Text = "Index";
            this.OlvColumn6.Width = 48;
            // 
            // OlvColumn1
            // 
            this.OlvColumn1.AspectName = "ShortDate";
            this.OlvColumn1.AspectToStringFormat = "{0:d}";
            this.OlvColumn1.Text = "Date";
            this.OlvColumn1.Width = 82;
            // 
            // OlvColumn2
            // 
            this.OlvColumn2.AspectName = "Time";
            this.OlvColumn2.AspectToStringFormat = "{0:d}";
            this.OlvColumn2.Text = "Time";
            this.OlvColumn2.Width = 83;
            // 
            // OlvColumn4
            // 
            this.OlvColumn4.AspectName = "Temp";
            this.OlvColumn4.AspectToStringFormat = "{0}°C";
            this.OlvColumn4.Text = "Temp";
            // 
            // OlvColumn5
            // 
            this.OlvColumn5.AspectName = "RH";
            this.OlvColumn5.AspectToStringFormat = "{0}%";
            this.OlvColumn5.Text = "RH";
            // 
            // OlvColumn7
            // 
            this.OlvColumn7.AspectName = "ScanSpeed";
            this.OlvColumn7.AspectToStringFormat = "{0} m/s";
            this.OlvColumn7.Text = "Speed";
            // 
            // OlvColumn8
            // 
            this.OlvColumn8.AspectName = "NumPasses";
            this.OlvColumn8.AspectToStringFormat = "{0}";
            this.OlvColumn8.Text = "# Passes";
            // 
            // OlvColumn9
            // 
            this.OlvColumn9.AspectName = "Threshold";
            this.OlvColumn9.AspectToStringFormat = "{0}%";
            this.OlvColumn9.Text = "Threshold";
            // 
            // pA
            // 
            this.pA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pA.Location = new System.Drawing.Point(372, 28);
            this.pA.Name = "pA";
            this.pA.Size = new System.Drawing.Size(424, 313);
            this.pA.TabIndex = 5;
            this.pA.Tag = "A";
            // 
            // pB
            // 
            this.pB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pB.Location = new System.Drawing.Point(802, 28);
            this.pB.Name = "pB";
            this.pB.Size = new System.Drawing.Size(426, 313);
            this.pB.TabIndex = 6;
            this.pB.Tag = "B";
            // 
            // pC
            // 
            this.pC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pC.Location = new System.Drawing.Point(372, 347);
            this.pC.Name = "pC";
            this.pC.Size = new System.Drawing.Size(424, 314);
            this.pC.TabIndex = 7;
            this.pC.Tag = "C";
            // 
            // pD
            // 
            this.pD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pD.Location = new System.Drawing.Point(802, 347);
            this.pD.Name = "pD";
            this.pD.Size = new System.Drawing.Size(426, 314);
            this.pD.TabIndex = 8;
            this.pD.Tag = "D";
            // 
            // toolStrip
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip, 2);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripButton,
            this.helpToolStripButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.comboX,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.comboY,
            this.toolStripSeparator3,
            this.toolStripLabel3,
            this.comboZ});
            this.toolStrip.Location = new System.Drawing.Point(369, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(862, 25);
            this.toolStrip.TabIndex = 9;
            this.toolStrip.Text = "toolStrip1";
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            "X Position (mm)",
            "Y Position (mm)",
            "Z Position (mm)",
            "Height (µm)",
            "Intensity (%)"});
            this.comboX.MaxDropDownItems = 6;
            this.comboX.Name = "comboX";
            this.comboX.Size = new System.Drawing.Size(121, 25);
            this.comboX.Text = "None";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            "X Position",
            "Y Position",
            "Z Position",
            "Height",
            "Intensity"});
            this.comboY.MaxDropDownItems = 6;
            this.comboY.Name = "comboY";
            this.comboY.Size = new System.Drawing.Size(121, 25);
            this.comboY.Text = "None";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            "X Position",
            "Y Position",
            "Z Position",
            "Height",
            "Intensity"});
            this.comboZ.MaxDropDownItems = 6;
            this.comboZ.Name = "comboZ";
            this.comboZ.Size = new System.Drawing.Size(121, 25);
            this.comboZ.Text = "None";
            // 
            // Plotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 664);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Plotter";
            this.Text = "XYZ Scan";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal BrightIdeasSoftware.FastDataListView olv;
        internal BrightIdeasSoftware.OLVColumn OlvColumn3;
        internal BrightIdeasSoftware.OLVColumn OlvColumn6;
        internal BrightIdeasSoftware.OLVColumn OlvColumn1;
        internal BrightIdeasSoftware.OLVColumn OlvColumn2;
        internal BrightIdeasSoftware.OLVColumn OlvColumn4;
        internal BrightIdeasSoftware.OLVColumn OlvColumn5;
        internal BrightIdeasSoftware.OLVColumn OlvColumn7;
        private BrightIdeasSoftware.OLVColumn OlvColumn8;
        internal System.Windows.Forms.ProgressBar ProgressBar;
        private BrightIdeasSoftware.OLVColumn OlvColumn9;
        private ScottPlot.FormsPlot pA;
        private ScottPlot.FormsPlot pB;
        private ScottPlot.FormsPlot pC;
        private ScottPlot.FormsPlot pD;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox comboX;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox comboY;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox comboZ;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}