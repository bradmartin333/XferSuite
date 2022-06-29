namespace XferSuite.Apps.SEYR
{
    partial class CycleFileViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CycleFileViewer));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtHeader = new System.Windows.Forms.TextBox();
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.BtnCopyCycleFile = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.TxtHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RTB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnCopyCycleFile, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(859, 386);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TxtHeader
            // 
            this.TxtHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtHeader.Location = new System.Drawing.Point(3, 3);
            this.TxtHeader.Name = "TxtHeader";
            this.TxtHeader.Size = new System.Drawing.Size(853, 20);
            this.TxtHeader.TabIndex = 0;
            // 
            // RTB
            // 
            this.RTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB.Location = new System.Drawing.Point(3, 29);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(853, 323);
            this.RTB.TabIndex = 1;
            this.RTB.Text = "";
            // 
            // BtnCopyCycleFile
            // 
            this.BtnCopyCycleFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCopyCycleFile.AutoSize = true;
            this.BtnCopyCycleFile.BackColor = System.Drawing.Color.White;
            this.BtnCopyCycleFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCopyCycleFile.Location = new System.Drawing.Point(3, 358);
            this.BtnCopyCycleFile.Name = "BtnCopyCycleFile";
            this.BtnCopyCycleFile.Size = new System.Drawing.Size(853, 25);
            this.BtnCopyCycleFile.TabIndex = 2;
            this.BtnCopyCycleFile.Text = "Copy to Clipboard";
            this.BtnCopyCycleFile.UseVisualStyleBackColor = false;
            this.BtnCopyCycleFile.Click += new System.EventHandler(this.BtnCopyCycleFile_Click);
            // 
            // CycleFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 386);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CycleFileViewer";
            this.Text = "Repair Cycle File";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TxtHeader;
        private System.Windows.Forms.RichTextBox RTB;
        private System.Windows.Forms.Button BtnCopyCycleFile;
    }
}