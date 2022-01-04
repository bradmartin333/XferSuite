
namespace XferSuite
{
    partial class MetroGraphs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetroGraphs));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scatterPlot = new OxyPlot.WindowsForms.PlotView();
            this.errorScatterPlot = new OxyPlot.WindowsForms.PlotView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.histogramPlotX = new OxyPlot.WindowsForms.PlotView();
            this.histogramPlotY = new OxyPlot.WindowsForms.PlotView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.errorBoxplotX = new OxyPlot.WindowsForms.PlotView();
            this.errorBoxplotY = new OxyPlot.WindowsForms.PlotView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.sigmaPlotX = new OxyPlot.WindowsForms.PlotView();
            this.sigmaPlotY = new OxyPlot.WindowsForms.PlotView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.yieldPlot = new OxyPlot.WindowsForms.PlotView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnShowFingerprintPlots = new System.Windows.Forms.Button();
            this.btnSaveSummary = new System.Windows.Forms.Button();
            this.btnShowAnglePlots = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage6);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(859, 381);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.webBrowser1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(851, 355);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scatter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.scatterPlot, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.errorScatterPlot, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 349F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(845, 349);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // scatterPlot
            // 
            this.scatterPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scatterPlot.Location = new System.Drawing.Point(3, 3);
            this.scatterPlot.Name = "scatterPlot";
            this.scatterPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.scatterPlot.Size = new System.Drawing.Size(416, 343);
            this.scatterPlot.TabIndex = 1;
            this.scatterPlot.Tag = "1";
            this.scatterPlot.Text = "Position Scatter Plot";
            this.scatterPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.scatterPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.scatterPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // errorScatterPlot
            // 
            this.errorScatterPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorScatterPlot.Location = new System.Drawing.Point(425, 3);
            this.errorScatterPlot.Name = "errorScatterPlot";
            this.errorScatterPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.errorScatterPlot.Size = new System.Drawing.Size(417, 343);
            this.errorScatterPlot.TabIndex = 2;
            this.errorScatterPlot.Tag = "1";
            this.errorScatterPlot.Text = "Error Scatter Plot";
            this.errorScatterPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.errorScatterPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.errorScatterPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(250, 250);
            this.webBrowser1.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(851, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Histogram";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.histogramPlotX, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.histogramPlotY, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 349F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(845, 349);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // histogramPlotX
            // 
            this.histogramPlotX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramPlotX.Location = new System.Drawing.Point(3, 3);
            this.histogramPlotX.Name = "histogramPlotX";
            this.histogramPlotX.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.histogramPlotX.Size = new System.Drawing.Size(416, 343);
            this.histogramPlotX.TabIndex = 0;
            this.histogramPlotX.Tag = "1";
            this.histogramPlotX.Text = "X Error Histogram";
            this.histogramPlotX.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.histogramPlotX.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.histogramPlotX.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // histogramPlotY
            // 
            this.histogramPlotY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramPlotY.Location = new System.Drawing.Point(425, 3);
            this.histogramPlotY.Name = "histogramPlotY";
            this.histogramPlotY.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.histogramPlotY.Size = new System.Drawing.Size(417, 343);
            this.histogramPlotY.TabIndex = 1;
            this.histogramPlotY.Tag = "1";
            this.histogramPlotY.Text = "Y Error Histogram";
            this.histogramPlotY.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.histogramPlotY.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.histogramPlotY.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(851, 355);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Boxplot";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.errorBoxplotX, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.errorBoxplotY, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 355F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(851, 355);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // errorBoxplotX
            // 
            this.errorBoxplotX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorBoxplotX.Location = new System.Drawing.Point(3, 3);
            this.errorBoxplotX.Name = "errorBoxplotX";
            this.errorBoxplotX.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.errorBoxplotX.Size = new System.Drawing.Size(419, 349);
            this.errorBoxplotX.TabIndex = 0;
            this.errorBoxplotX.Text = "X Error Boxplot";
            this.errorBoxplotX.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.errorBoxplotX.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.errorBoxplotX.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // errorBoxplotY
            // 
            this.errorBoxplotY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorBoxplotY.Location = new System.Drawing.Point(428, 3);
            this.errorBoxplotY.Name = "errorBoxplotY";
            this.errorBoxplotY.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.errorBoxplotY.Size = new System.Drawing.Size(420, 349);
            this.errorBoxplotY.TabIndex = 1;
            this.errorBoxplotY.Text = "Y Error Boxplot";
            this.errorBoxplotY.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.errorBoxplotY.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.errorBoxplotY.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tableLayoutPanel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(851, 355);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "3 Sigma";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.sigmaPlotX, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.sigmaPlotY, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 355F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(851, 355);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // sigmaPlotX
            // 
            this.sigmaPlotX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sigmaPlotX.Location = new System.Drawing.Point(3, 3);
            this.sigmaPlotX.Name = "sigmaPlotX";
            this.sigmaPlotX.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.sigmaPlotX.Size = new System.Drawing.Size(419, 349);
            this.sigmaPlotX.TabIndex = 0;
            this.sigmaPlotX.Text = "X 3Sigma Plot";
            this.sigmaPlotX.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.sigmaPlotX.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.sigmaPlotX.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // sigmaPlotY
            // 
            this.sigmaPlotY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sigmaPlotY.Location = new System.Drawing.Point(428, 3);
            this.sigmaPlotY.Name = "sigmaPlotY";
            this.sigmaPlotY.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.sigmaPlotY.Size = new System.Drawing.Size(420, 349);
            this.sigmaPlotY.TabIndex = 1;
            this.sigmaPlotY.Text = "Y 3Sigma Plot";
            this.sigmaPlotY.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.sigmaPlotY.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.sigmaPlotY.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.yieldPlot);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(851, 355);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Yield";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // yieldPlot
            // 
            this.yieldPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yieldPlot.Location = new System.Drawing.Point(0, 0);
            this.yieldPlot.Name = "yieldPlot";
            this.yieldPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.yieldPlot.Size = new System.Drawing.Size(851, 355);
            this.yieldPlot.TabIndex = 0;
            this.yieldPlot.Text = "Yield Plot";
            this.yieldPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.yieldPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.yieldPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.btnShowAnglePlots);
            this.tabPage6.Controls.Add(this.btnShowFingerprintPlots);
            this.tabPage6.Controls.Add(this.btnSaveSummary);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(851, 355);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Tools";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnShowFingerprintPlots
            // 
            this.btnShowFingerprintPlots.AutoSize = true;
            this.btnShowFingerprintPlots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowFingerprintPlots.Location = new System.Drawing.Point(19, 69);
            this.btnShowFingerprintPlots.Name = "btnShowFingerprintPlots";
            this.btnShowFingerprintPlots.Size = new System.Drawing.Size(149, 47);
            this.btnShowFingerprintPlots.TabIndex = 1;
            this.btnShowFingerprintPlots.Text = "Show Fingerprint Plots";
            this.btnShowFingerprintPlots.UseVisualStyleBackColor = true;
            this.btnShowFingerprintPlots.Click += new System.EventHandler(this.btnShowFingerprintPlots_Click);
            // 
            // btnSaveSummary
            // 
            this.btnSaveSummary.AutoSize = true;
            this.btnSaveSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSummary.Location = new System.Drawing.Point(19, 16);
            this.btnSaveSummary.Name = "btnSaveSummary";
            this.btnSaveSummary.Size = new System.Drawing.Size(149, 47);
            this.btnSaveSummary.TabIndex = 0;
            this.btnSaveSummary.Text = "Save 4 Graph Summary";
            this.btnSaveSummary.UseVisualStyleBackColor = true;
            this.btnSaveSummary.Click += new System.EventHandler(this.btnSaveSummary_Click);
            // 
            // btnShowAnglePlots
            // 
            this.btnShowAnglePlots.AutoSize = true;
            this.btnShowAnglePlots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAnglePlots.Location = new System.Drawing.Point(19, 122);
            this.btnShowAnglePlots.Name = "btnShowAnglePlots";
            this.btnShowAnglePlots.Size = new System.Drawing.Size(149, 47);
            this.btnShowAnglePlots.TabIndex = 2;
            this.btnShowAnglePlots.Text = "Show Angleprint Plots";
            this.btnShowAnglePlots.UseVisualStyleBackColor = true;
            this.btnShowAnglePlots.Click += new System.EventHandler(this.btnShowAnglePlots_Click);
            // 
            // MetroGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 381);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MetroGraphs";
            this.Text = "MetroGraphs";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private OxyPlot.WindowsForms.PlotView scatterPlot;
        private OxyPlot.WindowsForms.PlotView histogramPlotX;
        private OxyPlot.WindowsForms.PlotView errorBoxplotX;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private OxyPlot.WindowsForms.PlotView errorScatterPlot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private OxyPlot.WindowsForms.PlotView histogramPlotY;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private OxyPlot.WindowsForms.PlotView errorBoxplotY;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private OxyPlot.WindowsForms.PlotView sigmaPlotX;
        private OxyPlot.WindowsForms.PlotView sigmaPlotY;
        private OxyPlot.WindowsForms.PlotView yieldPlot;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnSaveSummary;
        private System.Windows.Forms.Button btnShowFingerprintPlots;
        private System.Windows.Forms.Button btnShowAnglePlots;
    }
}