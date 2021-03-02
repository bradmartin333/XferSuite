
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
            this.scatterPlot = new OxyPlot.WindowsForms.PlotView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.histogramPlot = new OxyPlot.WindowsForms.PlotView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.errorBoxplot = new OxyPlot.WindowsForms.PlotView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.sigmaPlot = new OxyPlot.WindowsForms.PlotView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.comboPlot = new OxyPlot.WindowsForms.PlotView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.errorScatterPlot = new OxyPlot.WindowsForms.PlotView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.webBrowser1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scatter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // scatterPlot
            // 
            this.scatterPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scatterPlot.Location = new System.Drawing.Point(3, 3);
            this.scatterPlot.Name = "scatterPlot";
            this.scatterPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.scatterPlot.Size = new System.Drawing.Size(387, 412);
            this.scatterPlot.TabIndex = 1;
            this.scatterPlot.Text = "plotView1";
            this.scatterPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.scatterPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.scatterPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(786, 418);
            this.webBrowser1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.histogramPlot);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Histogram";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // histogramPlot
            // 
            this.histogramPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramPlot.Location = new System.Drawing.Point(3, 3);
            this.histogramPlot.Name = "histogramPlot";
            this.histogramPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.histogramPlot.Size = new System.Drawing.Size(786, 418);
            this.histogramPlot.TabIndex = 0;
            this.histogramPlot.Text = "plotView1";
            this.histogramPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.histogramPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.histogramPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.errorBoxplot);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Boxplot";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // errorBoxplot
            // 
            this.errorBoxplot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorBoxplot.Location = new System.Drawing.Point(0, 0);
            this.errorBoxplot.Name = "errorBoxplot";
            this.errorBoxplot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.errorBoxplot.Size = new System.Drawing.Size(792, 424);
            this.errorBoxplot.TabIndex = 0;
            this.errorBoxplot.Text = "plotView1";
            this.errorBoxplot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.errorBoxplot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.errorBoxplot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.sigmaPlot);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(792, 424);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "3 Sigma";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // sigmaPlot
            // 
            this.sigmaPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sigmaPlot.Location = new System.Drawing.Point(0, 0);
            this.sigmaPlot.Name = "sigmaPlot";
            this.sigmaPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.sigmaPlot.Size = new System.Drawing.Size(792, 424);
            this.sigmaPlot.TabIndex = 0;
            this.sigmaPlot.Text = "plotView1";
            this.sigmaPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.sigmaPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.sigmaPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.comboPlot);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(792, 424);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Combo";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // comboPlot
            // 
            this.comboPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboPlot.Location = new System.Drawing.Point(0, 0);
            this.comboPlot.Name = "comboPlot";
            this.comboPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.comboPlot.Size = new System.Drawing.Size(792, 424);
            this.comboPlot.TabIndex = 0;
            this.comboPlot.Text = "plotView1";
            this.comboPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.comboPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.comboPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 418);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // errorScatterPlot
            // 
            this.errorScatterPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorScatterPlot.Location = new System.Drawing.Point(396, 3);
            this.errorScatterPlot.Name = "errorScatterPlot";
            this.errorScatterPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.errorScatterPlot.Size = new System.Drawing.Size(387, 412);
            this.errorScatterPlot.TabIndex = 2;
            this.errorScatterPlot.Text = "plotView1";
            this.errorScatterPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.errorScatterPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.errorScatterPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // MetroGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MetroGraphs";
            this.Text = "MetroGraphs";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private OxyPlot.WindowsForms.PlotView histogramPlot;
        private OxyPlot.WindowsForms.PlotView errorBoxplot;
        private OxyPlot.WindowsForms.PlotView sigmaPlot;
        private OxyPlot.WindowsForms.PlotView comboPlot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private OxyPlot.WindowsForms.PlotView errorScatterPlot;
    }
}