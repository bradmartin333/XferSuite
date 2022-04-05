namespace XferSuite.AdvancedTools
{
    partial class PrintLogParser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintLogParser));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnOpenFile = new System.Windows.Forms.Button();
            this.LabelPath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBoxRecipe = new System.Windows.Forms.ComboBox();
            this.ComboBoxDate = new System.Windows.Forms.ComboBox();
            this.RichTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel1.Controls.Add(this.BtnOpenFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ComboBoxRecipe, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ComboBoxDate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.RichTextBox, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(551, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnOpenFile
            // 
            this.BtnOpenFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOpenFile.Location = new System.Drawing.Point(3, 3);
            this.BtnOpenFile.Name = "BtnOpenFile";
            this.BtnOpenFile.Size = new System.Drawing.Size(269, 23);
            this.BtnOpenFile.TabIndex = 1;
            this.BtnOpenFile.Text = "Open µTP Log";
            this.BtnOpenFile.UseVisualStyleBackColor = true;
            this.BtnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // LabelPath
            // 
            this.LabelPath.AutoSize = true;
            this.LabelPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelPath.Location = new System.Drawing.Point(278, 0);
            this.LabelPath.Name = "LabelPath";
            this.LabelPath.Size = new System.Drawing.Size(270, 29);
            this.LabelPath.TabIndex = 2;
            this.LabelPath.Text = "N/A";
            this.LabelPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "Recipe";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(278, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ComboBoxRecipe
            // 
            this.ComboBoxRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxRecipe.FormattingEnabled = true;
            this.ComboBoxRecipe.Location = new System.Drawing.Point(3, 72);
            this.ComboBoxRecipe.Name = "ComboBoxRecipe";
            this.ComboBoxRecipe.Size = new System.Drawing.Size(269, 21);
            this.ComboBoxRecipe.TabIndex = 5;
            this.ComboBoxRecipe.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRecipe_SelectedIndexChanged);
            // 
            // ComboBoxDate
            // 
            this.ComboBoxDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxDate.FormattingEnabled = true;
            this.ComboBoxDate.Location = new System.Drawing.Point(278, 72);
            this.ComboBoxDate.Name = "ComboBoxDate";
            this.ComboBoxDate.Size = new System.Drawing.Size(270, 21);
            this.ComboBoxDate.TabIndex = 6;
            this.ComboBoxDate.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDate_SelectedIndexChanged);
            // 
            // RichTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.RichTextBox, 2);
            this.RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox.Location = new System.Drawing.Point(3, 119);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.Size = new System.Drawing.Size(545, 328);
            this.RichTextBox.TabIndex = 0;
            this.RichTextBox.Text = "";
            // 
            // PrintLogParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintLogParser";
            this.Text = "µTP Log Parser";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnOpenFile;
        private System.Windows.Forms.Label LabelPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBoxRecipe;
        private System.Windows.Forms.ComboBox ComboBoxDate;
        private System.Windows.Forms.RichTextBox RichTextBox;
    }
}