namespace XferSuite.Apps.SEYR
{
    partial class PassFailUtility
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassFailUtility));
            this.HistPlot = new ScottPlot.FormsPlot();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LabelUnselectedCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LabelNullExcludeCount = new System.Windows.Forms.Label();
            this.LabelNullIncludeCount = new System.Windows.Forms.Label();
            this.LabelSelectedCount = new System.Windows.Forms.Label();
            this.LabelTotalCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.PiePlot = new ScottPlot.FormsPlot();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtCriteriaString = new System.Windows.Forms.TextBox();
            this.BtnIgnoreFeature = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HistPlot
            // 
            this.HistPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistPlot.Location = new System.Drawing.Point(3, 3);
            this.HistPlot.Name = "HistPlot";
            this.tableLayoutPanel.SetRowSpan(this.HistPlot, 11);
            this.HistPlot.Size = new System.Drawing.Size(485, 455);
            this.HistPlot.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.BtnIgnoreFeature, 1, 9);
            this.tableLayoutPanel.Controls.Add(this.LabelUnselectedCount, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.HistPlot, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.LabelNullExcludeCount, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.LabelNullIncludeCount, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.LabelSelectedCount, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.LabelTotalCount, 2, 5);
            this.tableLayoutPanel.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.label3, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.label4, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.BtnConfirm, 1, 10);
            this.tableLayoutPanel.Controls.Add(this.PiePlot, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.label8, 1, 7);
            this.tableLayoutPanel.Controls.Add(this.TxtCriteriaString, 1, 8);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 11;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(659, 461);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // LabelUnselectedCount
            // 
            this.LabelUnselectedCount.AutoSize = true;
            this.LabelUnselectedCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelUnselectedCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelUnselectedCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUnselectedCount.Location = new System.Drawing.Point(609, 53);
            this.LabelUnselectedCount.Name = "LabelUnselectedCount";
            this.LabelUnselectedCount.Size = new System.Drawing.Size(47, 17);
            this.LabelUnselectedCount.TabIndex = 14;
            this.LabelUnselectedCount.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.MistyRose;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(494, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Unselected";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelNullExcludeCount
            // 
            this.LabelNullExcludeCount.AutoSize = true;
            this.LabelNullExcludeCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelNullExcludeCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelNullExcludeCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNullExcludeCount.Location = new System.Drawing.Point(609, 19);
            this.LabelNullExcludeCount.Name = "LabelNullExcludeCount";
            this.LabelNullExcludeCount.Size = new System.Drawing.Size(47, 17);
            this.LabelNullExcludeCount.TabIndex = 1;
            this.LabelNullExcludeCount.Text = "N/A";
            // 
            // LabelNullIncludeCount
            // 
            this.LabelNullIncludeCount.AutoSize = true;
            this.LabelNullIncludeCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelNullIncludeCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelNullIncludeCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNullIncludeCount.Location = new System.Drawing.Point(609, 36);
            this.LabelNullIncludeCount.Name = "LabelNullIncludeCount";
            this.LabelNullIncludeCount.Size = new System.Drawing.Size(47, 17);
            this.LabelNullIncludeCount.TabIndex = 2;
            this.LabelNullIncludeCount.Text = "N/A";
            // 
            // LabelSelectedCount
            // 
            this.LabelSelectedCount.AutoSize = true;
            this.LabelSelectedCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelSelectedCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSelectedCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSelectedCount.Location = new System.Drawing.Point(609, 70);
            this.LabelSelectedCount.Name = "LabelSelectedCount";
            this.LabelSelectedCount.Size = new System.Drawing.Size(47, 17);
            this.LabelSelectedCount.TabIndex = 3;
            this.LabelSelectedCount.Text = "N/A";
            // 
            // LabelTotalCount
            // 
            this.LabelTotalCount.AutoSize = true;
            this.LabelTotalCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelTotalCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelTotalCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalCount.Location = new System.Drawing.Point(609, 87);
            this.LabelTotalCount.Name = "LabelTotalCount";
            this.LabelTotalCount.Size = new System.Drawing.Size(47, 17);
            this.LabelTotalCount.TabIndex = 4;
            this.LabelTotalCount.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MistyRose;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(494, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Null Exclude";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Honeydew;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(494, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Null Include";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Honeydew;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(494, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Selected";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(494, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Total";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(494, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Data Entry Type";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(609, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Count";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.BackColor = System.Drawing.Color.LightGreen;
            this.tableLayoutPanel.SetColumnSpan(this.BtnConfirm, 2);
            this.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfirm.Location = new System.Drawing.Point(494, 435);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(162, 23);
            this.BtnConfirm.TabIndex = 11;
            this.BtnConfirm.Text = "Confirm";
            this.BtnConfirm.UseVisualStyleBackColor = false;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // PiePlot
            // 
            this.PiePlot.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.PiePlot, 2);
            this.PiePlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PiePlot.Location = new System.Drawing.Point(494, 107);
            this.PiePlot.Name = "PiePlot";
            this.PiePlot.Size = new System.Drawing.Size(162, 254);
            this.PiePlot.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.label8, 2);
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(494, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Criteria String";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtCriteriaString
            // 
            this.tableLayoutPanel.SetColumnSpan(this.TxtCriteriaString, 2);
            this.TxtCriteriaString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCriteriaString.Location = new System.Drawing.Point(494, 380);
            this.TxtCriteriaString.Name = "TxtCriteriaString";
            this.TxtCriteriaString.Size = new System.Drawing.Size(162, 20);
            this.TxtCriteriaString.TabIndex = 17;
            this.TxtCriteriaString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnIgnoreFeature
            // 
            this.BtnIgnoreFeature.BackColor = System.Drawing.Color.LightCoral;
            this.tableLayoutPanel.SetColumnSpan(this.BtnIgnoreFeature, 2);
            this.BtnIgnoreFeature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnIgnoreFeature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIgnoreFeature.Location = new System.Drawing.Point(494, 406);
            this.BtnIgnoreFeature.Name = "BtnIgnoreFeature";
            this.BtnIgnoreFeature.Size = new System.Drawing.Size(162, 23);
            this.BtnIgnoreFeature.TabIndex = 15;
            this.BtnIgnoreFeature.Text = "Ignore Feature";
            this.BtnIgnoreFeature.UseVisualStyleBackColor = false;
            this.BtnIgnoreFeature.Click += new System.EventHandler(this.BtnIgnoreFeature_Click);
            // 
            // PassFailUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(659, 461);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(675, 500);
            this.Name = "PassFailUtility";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot HistPlot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label LabelNullExcludeCount;
        private System.Windows.Forms.Label LabelNullIncludeCount;
        private System.Windows.Forms.Label LabelSelectedCount;
        private System.Windows.Forms.Label LabelTotalCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnConfirm;
        private ScottPlot.FormsPlot PiePlot;
        private System.Windows.Forms.Label LabelUnselectedCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtCriteriaString;
        private System.Windows.Forms.Button BtnIgnoreFeature;
    }
}