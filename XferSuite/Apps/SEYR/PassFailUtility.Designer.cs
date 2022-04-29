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
            this.FPSelector = new ScottPlot.FormsPlot();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelNullExcludeCount = new System.Windows.Forms.Label();
            this.LabelNullIncludeCount = new System.Windows.Forms.Label();
            this.LabelSelectableCount = new System.Windows.Forms.Label();
            this.LabelTotalCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.FPBar = new ScottPlot.FormsPlot();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FPSelector
            // 
            this.FPSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FPSelector.Location = new System.Drawing.Point(3, 3);
            this.FPSelector.Name = "FPSelector";
            this.tableLayoutPanel1.SetRowSpan(this.FPSelector, 7);
            this.FPSelector.Size = new System.Drawing.Size(485, 457);
            this.FPSelector.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.FPSelector, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelNullExcludeCount, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.LabelNullIncludeCount, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.LabelSelectableCount, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.LabelTotalCount, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.FPBar, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(659, 463);
            this.tableLayoutPanel1.TabIndex = 1;
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
            // LabelSelectableCount
            // 
            this.LabelSelectableCount.AutoSize = true;
            this.LabelSelectableCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelSelectableCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSelectableCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSelectableCount.Location = new System.Drawing.Point(609, 53);
            this.LabelSelectableCount.Name = "LabelSelectableCount";
            this.LabelSelectableCount.Size = new System.Drawing.Size(47, 17);
            this.LabelSelectableCount.TabIndex = 3;
            this.LabelSelectableCount.Text = "N/A";
            // 
            // LabelTotalCount
            // 
            this.LabelTotalCount.AutoSize = true;
            this.LabelTotalCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelTotalCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelTotalCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalCount.Location = new System.Drawing.Point(609, 70);
            this.LabelTotalCount.Name = "LabelTotalCount";
            this.LabelTotalCount.Size = new System.Drawing.Size(47, 17);
            this.LabelTotalCount.TabIndex = 4;
            this.LabelTotalCount.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
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
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(494, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Selectable";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(494, 70);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 2);
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(494, 437);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FPBar
            // 
            this.FPBar.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.FPBar, 2);
            this.FPBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FPBar.Location = new System.Drawing.Point(494, 90);
            this.FPBar.Name = "FPBar";
            this.FPBar.Size = new System.Drawing.Size(162, 341);
            this.FPBar.TabIndex = 12;
            // 
            // PassFailUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 463);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PassFailUtility";
            this.Text = "PassFailUtility";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot FPSelector;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LabelNullExcludeCount;
        private System.Windows.Forms.Label LabelNullIncludeCount;
        private System.Windows.Forms.Label LabelSelectableCount;
        private System.Windows.Forms.Label LabelTotalCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private ScottPlot.FormsPlot FPBar;
    }
}