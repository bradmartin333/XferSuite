
namespace XferSuite
{
    partial class PrintSim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintSim));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenMap = new System.Windows.Forms.Button();
            this.lblPrintIdx = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.plot = new OxyPlot.WindowsForms.PlotView();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numCTLength = new System.Windows.Forms.NumericUpDown();
            this.numCTWidth = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCTLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCTWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.btnOpenMap, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPrintIdx, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNext, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFinish, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.plot, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.numCTLength, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.numCTWidth, 7, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 547);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnOpenMap
            // 
            this.btnOpenMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenMap.Location = new System.Drawing.Point(3, 3);
            this.btnOpenMap.Name = "btnOpenMap";
            this.btnOpenMap.Size = new System.Drawing.Size(84, 23);
            this.btnOpenMap.TabIndex = 0;
            this.btnOpenMap.Text = "Open .xmap";
            this.btnOpenMap.UseVisualStyleBackColor = true;
            this.btnOpenMap.Click += new System.EventHandler(this.btnOpenMap_Click);
            // 
            // lblPrintIdx
            // 
            this.lblPrintIdx.AutoSize = true;
            this.lblPrintIdx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrintIdx.Location = new System.Drawing.Point(93, 0);
            this.lblPrintIdx.Name = "lblPrintIdx";
            this.lblPrintIdx.Size = new System.Drawing.Size(84, 29);
            this.lblPrintIdx.TabIndex = 1;
            this.lblPrintIdx.Text = "0/0 Prints";
            this.lblPrintIdx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.Location = new System.Drawing.Point(183, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(84, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next Print";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinish.Location = new System.Drawing.Point(273, 3);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(84, 23);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "Finish .xmap";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // plot
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.plot, 8);
            this.plot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot.Location = new System.Drawing.Point(3, 32);
            this.plot.Name = "plot";
            this.plot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot.Size = new System.Drawing.Size(715, 512);
            this.plot.TabIndex = 4;
            this.plot.Text = "plotView1";
            this.plot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.Filter = "*.xrec";
            this.fileSystemWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fileSystemWatcher.SynchronizingObject = this;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cleaning Tape Length (X)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cleaning Tape Width (Y)";
            // 
            // numCTLength
            // 
            this.numCTLength.DecimalPlaces = 1;
            this.numCTLength.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCTLength.Location = new System.Drawing.Point(453, 3);
            this.numCTLength.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCTLength.Name = "numCTLength";
            this.numCTLength.Size = new System.Drawing.Size(84, 20);
            this.numCTLength.TabIndex = 7;
            this.numCTLength.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numCTWidth
            // 
            this.numCTWidth.DecimalPlaces = 1;
            this.numCTWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCTWidth.Location = new System.Drawing.Point(633, 3);
            this.numCTWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCTWidth.Name = "numCTWidth";
            this.numCTWidth.Size = new System.Drawing.Size(85, 20);
            this.numCTWidth.TabIndex = 8;
            this.numCTWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // PrintSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 547);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintSim";
            this.Text = "Print Cycle Simulation";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCTLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCTWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnOpenMap;
        private System.Windows.Forms.Label lblPrintIdx;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFinish;
        private OxyPlot.WindowsForms.PlotView plot;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numCTLength;
        public System.Windows.Forms.NumericUpDown numCTWidth;
    }
}