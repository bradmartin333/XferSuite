
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(802, 381);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.webBrowser1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(794, 355);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(788, 349);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // scatterPlot
            // 
            this.scatterPlot.AccessibleName = "Position Scatter Plot";
            this.scatterPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scatterPlot.Location = new System.Drawing.Point(3, 3);
            this.scatterPlot.Name = "scatterPlot";
            this.scatterPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.scatterPlot.Size = new System.Drawing.Size(388, 343);
            this.scatterPlot.TabIndex = 1;
            this.scatterPlot.Text = "plotView1";
            this.scatterPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.scatterPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.scatterPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.scatterPlot.DoubleClick += new System.EventHandler(this.Plot_DoubleClick);
            // 
            // errorScatterPlot
            // 
            this.errorScatterPlot.AccessibleName = "Error Scatter Plot";
            this.errorScatterPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorScatterPlot.Location = new System.Drawing.Point(397, 3);
            this.errorScatterPlot.Name = "errorScatterPlot";
            this.errorScatterPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.errorScatterPlot.Size = new System.Drawing.Size(388, 343);
            this.errorScatterPlot.TabIndex = 2;
            this.errorScatterPlot.Text = "plotView1";
            this.errorScatterPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.errorScatterPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.errorScatterPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.errorScatterPlot.DoubleClick += new System.EventHandler(this.Plot_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(794, 355);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(788, 349);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // histogramPlotX
            // 
            this.histogramPlotX.AccessibleName = "X Error Histogram";
            this.histogramPlotX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramPlotX.Location = new System.Drawing.Point(3, 3);
            this.histogramPlotX.Name = "histogramPlotX";
            this.histogramPlotX.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.histogramPlotX.Size = new System.Drawing.Size(388, 343);
            this.histogramPlotX.TabIndex = 0;
            this.histogramPlotX.Text = "plotView1";
            this.histogramPlotX.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.histogramPlotX.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.histogramPlotX.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.histogramPlotX.DoubleClick += new System.EventHandler(this.Plot_DoubleClick);
            // 
            // histogramPlotY
            // 
            this.histogramPlotY.AccessibleName = "Y Error Histogram";
            this.histogramPlotY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramPlotY.Location = new System.Drawing.Point(397, 3);
            this.histogramPlotY.Name = "histogramPlotY";
            this.histogramPlotY.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.histogramPlotY.Size = new System.Drawing.Size(388, 343);
            this.histogramPlotY.TabIndex = 1;
            this.histogramPlotY.Text = "plotView1";
            this.histogramPlotY.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.histogramPlotY.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.histogramPlotY.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.histogramPlotY.DoubleClick += new System.EventHandler(this.Plot_DoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(794, 355);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(794, 355);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // errorBoxplotX
            // 
            this.errorBoxplotX.AccessibleName = "X Error Boxplot";
            this.errorBoxplotX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorBoxplotX.Location = new System.Drawing.Point(3, 3);
            this.errorBoxplotX.Name = "errorBoxplotX";
            this.errorBoxplotX.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.errorBoxplotX.Size = new System.Drawing.Size(391, 349);
            this.errorBoxplotX.TabIndex = 0;
            this.errorBoxplotX.Text = "plotView1";
            this.errorBoxplotX.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.errorBoxplotX.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.errorBoxplotX.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // errorBoxplotY
            // 
            this.errorBoxplotY.AccessibleName = "Y Error Boxplot";
            this.errorBoxplotY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorBoxplotY.Location = new System.Drawing.Point(400, 3);
            this.errorBoxplotY.Name = "errorBoxplotY";
            this.errorBoxplotY.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.errorBoxplotY.Size = new System.Drawing.Size(391, 349);
            this.errorBoxplotY.TabIndex = 1;
            this.errorBoxplotY.Text = "plotView1";
            this.errorBoxplotY.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.errorBoxplotY.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.errorBoxplotY.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tableLayoutPanel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(794, 355);
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(794, 355);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // sigmaPlotX
            // 
            this.sigmaPlotX.AccessibleName = "X 3Sigma Plot";
            this.sigmaPlotX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sigmaPlotX.Location = new System.Drawing.Point(3, 3);
            this.sigmaPlotX.Name = "sigmaPlotX";
            this.sigmaPlotX.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.sigmaPlotX.Size = new System.Drawing.Size(391, 349);
            this.sigmaPlotX.TabIndex = 0;
            this.sigmaPlotX.Text = "plotView1";
            this.sigmaPlotX.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.sigmaPlotX.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.sigmaPlotX.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // sigmaPlotY
            // 
            this.sigmaPlotY.AccessibleName = "Y 3Sigma Plot";
            this.sigmaPlotY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sigmaPlotY.Location = new System.Drawing.Point(400, 3);
            this.sigmaPlotY.Name = "sigmaPlotY";
            this.sigmaPlotY.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.sigmaPlotY.Size = new System.Drawing.Size(391, 349);
            this.sigmaPlotY.TabIndex = 1;
            this.sigmaPlotY.Text = "plotView1";
            this.sigmaPlotY.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.sigmaPlotY.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.sigmaPlotY.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.yieldPlot);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(794, 355);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Yield";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // yieldPlot
            // 
            this.yieldPlot.AccessibleName = "Yield Plot";
            this.yieldPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yieldPlot.Location = new System.Drawing.Point(0, 0);
            this.yieldPlot.Name = "yieldPlot";
            this.yieldPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.yieldPlot.Size = new System.Drawing.Size(794, 355);
            this.yieldPlot.TabIndex = 0;
            this.yieldPlot.Text = "plotView1";
            this.yieldPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.yieldPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.yieldPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // MetroGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 381);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MetroGraphs";
            this.Text = "MetroGraphs";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
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
    }
}