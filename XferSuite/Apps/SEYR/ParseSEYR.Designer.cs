namespace XferSuite.Apps.SEYR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParseSEYR));
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.ComboFeatures = new System.Windows.Forms.ComboBox();
            this.BtnRescore = new System.Windows.Forms.Button();
            this.BtnPlot = new System.Windows.Forms.Button();
            this.BtnExportCycleFile = new System.Windows.Forms.Button();
            this.LabelLoading = new System.Windows.Forms.Label();
            this.TLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 2;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.TLP.Controls.Add(this.ComboFeatures, 0, 1);
            this.TLP.Controls.Add(this.BtnRescore, 1, 1);
            this.TLP.Controls.Add(this.BtnPlot, 0, 3);
            this.TLP.Controls.Add(this.BtnExportCycleFile, 1, 3);
            this.TLP.Controls.Add(this.LabelLoading, 0, 2);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 5;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.Size = new System.Drawing.Size(301, 96);
            this.TLP.TabIndex = 1;
            // 
            // ComboFeatures
            // 
            this.ComboFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboFeatures.FormattingEnabled = true;
            this.ComboFeatures.Location = new System.Drawing.Point(3, 12);
            this.ComboFeatures.Name = "ComboFeatures";
            this.ComboFeatures.Size = new System.Drawing.Size(144, 21);
            this.ComboFeatures.TabIndex = 1;
            // 
            // BtnRescore
            // 
            this.BtnRescore.BackColor = System.Drawing.Color.White;
            this.BtnRescore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRescore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRescore.Location = new System.Drawing.Point(153, 12);
            this.BtnRescore.Name = "BtnRescore";
            this.BtnRescore.Size = new System.Drawing.Size(145, 23);
            this.BtnRescore.TabIndex = 2;
            this.BtnRescore.Text = "Open Rescore Utility";
            this.BtnRescore.UseVisualStyleBackColor = false;
            this.BtnRescore.Click += new System.EventHandler(this.BtnRescore_Click);
            // 
            // BtnPlot
            // 
            this.BtnPlot.BackColor = System.Drawing.Color.White;
            this.BtnPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlot.Location = new System.Drawing.Point(3, 61);
            this.BtnPlot.Name = "BtnPlot";
            this.BtnPlot.Size = new System.Drawing.Size(144, 23);
            this.BtnPlot.TabIndex = 3;
            this.BtnPlot.Text = "Plot";
            this.BtnPlot.UseVisualStyleBackColor = false;
            this.BtnPlot.Click += new System.EventHandler(this.BtnPlot_Click);
            // 
            // BtnExportCycleFile
            // 
            this.BtnExportCycleFile.BackColor = System.Drawing.Color.White;
            this.BtnExportCycleFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnExportCycleFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportCycleFile.Location = new System.Drawing.Point(153, 61);
            this.BtnExportCycleFile.Name = "BtnExportCycleFile";
            this.BtnExportCycleFile.Size = new System.Drawing.Size(145, 23);
            this.BtnExportCycleFile.TabIndex = 5;
            this.BtnExportCycleFile.Text = "Export Cycle File";
            this.BtnExportCycleFile.UseVisualStyleBackColor = false;
            this.BtnExportCycleFile.Click += new System.EventHandler(this.BtnExportCycleFile_Click);
            // 
            // LabelLoading
            // 
            this.LabelLoading.AutoSize = true;
            this.LabelLoading.BackColor = System.Drawing.Color.Bisque;
            this.TLP.SetColumnSpan(this.LabelLoading, 2);
            this.LabelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelLoading.Location = new System.Drawing.Point(3, 38);
            this.LabelLoading.Name = "LabelLoading";
            this.LabelLoading.Size = new System.Drawing.Size(295, 20);
            this.LabelLoading.TabIndex = 6;
            this.LabelLoading.Text = "Loading...";
            this.LabelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelLoading.Visible = false;
            // 
            // ParseSEYR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 96);
            this.Controls.Add(this.TLP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ParseSEYR";
            this.Text = "Parse SEYR";
            this.TLP.ResumeLayout(false);
            this.TLP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.ComboBox ComboFeatures;
        private System.Windows.Forms.Button BtnRescore;
        private System.Windows.Forms.Button BtnPlot;
        private System.Windows.Forms.Button BtnExportCycleFile;
        private System.Windows.Forms.Label LabelLoading;
    }
}