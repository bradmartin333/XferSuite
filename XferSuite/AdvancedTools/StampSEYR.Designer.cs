namespace XferSuite.AdvancedTools
{
    partial class StampSEYR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StampSEYR));
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.PlotPostCount = new ScottPlot.FormsPlot();
            this.PlotPostDebris = new ScottPlot.FormsPlot();
            this.PlotMesaDebris = new ScottPlot.FormsPlot();
            this.LblPostCount = new System.Windows.Forms.Label();
            this.LblPostDebris = new System.Windows.Forms.Label();
            this.LblMesaDebris = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnOpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NumPostsX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.NumPostsY = new System.Windows.Forms.NumericUpDown();
            this.BtnCopyWindow = new System.Windows.Forms.Button();
            this.TLP.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPostsX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPostsY)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 3;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.TLP.Controls.Add(this.PlotPostCount, 0, 3);
            this.TLP.Controls.Add(this.PlotPostDebris, 1, 3);
            this.TLP.Controls.Add(this.PlotMesaDebris, 2, 3);
            this.TLP.Controls.Add(this.LblPostCount, 0, 2);
            this.TLP.Controls.Add(this.LblPostDebris, 1, 2);
            this.TLP.Controls.Add(this.LblMesaDebris, 2, 2);
            this.TLP.Controls.Add(this.flowLayoutPanel, 0, 0);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 4;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP.Size = new System.Drawing.Size(884, 361);
            this.TLP.TabIndex = 0;
            // 
            // PlotPostCount
            // 
            this.PlotPostCount.Location = new System.Drawing.Point(3, 61);
            this.PlotPostCount.Name = "PlotPostCount";
            this.PlotPostCount.Size = new System.Drawing.Size(288, 297);
            this.PlotPostCount.TabIndex = 4;
            // 
            // PlotPostDebris
            // 
            this.PlotPostDebris.Location = new System.Drawing.Point(297, 61);
            this.PlotPostDebris.Name = "PlotPostDebris";
            this.PlotPostDebris.Size = new System.Drawing.Size(288, 297);
            this.PlotPostDebris.TabIndex = 5;
            // 
            // PlotMesaDebris
            // 
            this.PlotMesaDebris.Location = new System.Drawing.Point(591, 61);
            this.PlotMesaDebris.Name = "PlotMesaDebris";
            this.PlotMesaDebris.Size = new System.Drawing.Size(290, 297);
            this.PlotMesaDebris.TabIndex = 6;
            // 
            // LblPostCount
            // 
            this.LblPostCount.AutoSize = true;
            this.LblPostCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPostCount.Location = new System.Drawing.Point(3, 45);
            this.LblPostCount.Name = "LblPostCount";
            this.LblPostCount.Size = new System.Drawing.Size(288, 13);
            this.LblPostCount.TabIndex = 8;
            this.LblPostCount.Text = "Post Count";
            this.LblPostCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPostDebris
            // 
            this.LblPostDebris.AutoSize = true;
            this.LblPostDebris.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPostDebris.Location = new System.Drawing.Point(297, 45);
            this.LblPostDebris.Name = "LblPostDebris";
            this.LblPostDebris.Size = new System.Drawing.Size(288, 13);
            this.LblPostDebris.TabIndex = 9;
            this.LblPostDebris.Text = "Post Debris";
            this.LblPostDebris.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblMesaDebris
            // 
            this.LblMesaDebris.AutoSize = true;
            this.LblMesaDebris.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblMesaDebris.Location = new System.Drawing.Point(591, 45);
            this.LblMesaDebris.Name = "LblMesaDebris";
            this.LblMesaDebris.Size = new System.Drawing.Size(290, 13);
            this.LblMesaDebris.TabIndex = 10;
            this.LblMesaDebris.Text = "Mesa Debris";
            this.LblMesaDebris.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanel.AutoSize = true;
            this.TLP.SetColumnSpan(this.flowLayoutPanel, 3);
            this.flowLayoutPanel.Controls.Add(this.BtnOpenFile);
            this.flowLayoutPanel.Controls.Add(this.label1);
            this.flowLayoutPanel.Controls.Add(this.NumPostsX);
            this.flowLayoutPanel.Controls.Add(this.label5);
            this.flowLayoutPanel.Controls.Add(this.NumPostsY);
            this.flowLayoutPanel.Controls.Add(this.BtnCopyWindow);
            this.flowLayoutPanel.Location = new System.Drawing.Point(151, 3);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(582, 29);
            this.flowLayoutPanel.TabIndex = 16;
            // 
            // BtnOpenFile
            // 
            this.BtnOpenFile.BackColor = System.Drawing.Color.White;
            this.BtnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOpenFile.Location = new System.Drawing.Point(3, 3);
            this.BtnOpenFile.Name = "BtnOpenFile";
            this.BtnOpenFile.Size = new System.Drawing.Size(100, 23);
            this.BtnOpenFile.TabIndex = 1;
            this.BtnOpenFile.Text = "Open File";
            this.BtnOpenFile.UseVisualStyleBackColor = false;
            this.BtnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "# Posts X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumPostsX
            // 
            this.NumPostsX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NumPostsX.Location = new System.Drawing.Point(168, 4);
            this.NumPostsX.Name = "NumPostsX";
            this.NumPostsX.Size = new System.Drawing.Size(120, 20);
            this.NumPostsX.TabIndex = 14;
            this.NumPostsX.ValueChanged += new System.EventHandler(this.NumPostsX_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "# Posts Y";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumPostsY
            // 
            this.NumPostsY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NumPostsY.Location = new System.Drawing.Point(353, 4);
            this.NumPostsY.Name = "NumPostsY";
            this.NumPostsY.Size = new System.Drawing.Size(120, 20);
            this.NumPostsY.TabIndex = 15;
            this.NumPostsY.ValueChanged += new System.EventHandler(this.NumPostsY_ValueChanged);
            // 
            // BtnCopyWindow
            // 
            this.BtnCopyWindow.BackColor = System.Drawing.Color.White;
            this.BtnCopyWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCopyWindow.Location = new System.Drawing.Point(479, 3);
            this.BtnCopyWindow.Name = "BtnCopyWindow";
            this.BtnCopyWindow.Size = new System.Drawing.Size(100, 23);
            this.BtnCopyWindow.TabIndex = 16;
            this.BtnCopyWindow.Text = "Copy Window";
            this.BtnCopyWindow.UseVisualStyleBackColor = false;
            this.BtnCopyWindow.Click += new System.EventHandler(this.BtnCopyWindow_Click);
            // 
            // StampSEYR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 361);
            this.Controls.Add(this.TLP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 400);
            this.Name = "StampSEYR";
            this.Text = "Stamp SEYR Parser";
            this.TLP.ResumeLayout(false);
            this.TLP.PerformLayout();
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPostsX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPostsY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.Button BtnOpenFile;
        private ScottPlot.FormsPlot PlotPostCount;
        private ScottPlot.FormsPlot PlotPostDebris;
        private ScottPlot.FormsPlot PlotMesaDebris;
        private System.Windows.Forms.Label LblPostCount;
        private System.Windows.Forms.Label LblPostDebris;
        private System.Windows.Forms.Label LblMesaDebris;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NumPostsX;
        private System.Windows.Forms.NumericUpDown NumPostsY;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button BtnCopyWindow;
    }
}