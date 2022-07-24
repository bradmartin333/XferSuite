namespace XferSuite.AdvancedTools
{
    partial class SwapABGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwapABGrid));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnOpenSEYRUP = new System.Windows.Forms.Button();
            this.BtnSaveSEYRUP = new System.Windows.Forms.Button();
            this.LblInfo = new System.Windows.Forms.Label();
            this.DataLoadingWorker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.BtnOpenSEYRUP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnSaveSEYRUP, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblInfo, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(233, 210);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnOpenSEYRUP
            // 
            this.BtnOpenSEYRUP.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnOpenSEYRUP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOpenSEYRUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOpenSEYRUP.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpenSEYRUP.Location = new System.Drawing.Point(3, 3);
            this.BtnOpenSEYRUP.Name = "BtnOpenSEYRUP";
            this.BtnOpenSEYRUP.Size = new System.Drawing.Size(227, 64);
            this.BtnOpenSEYRUP.TabIndex = 0;
            this.BtnOpenSEYRUP.Text = "Open SEYRUP";
            this.BtnOpenSEYRUP.UseVisualStyleBackColor = false;
            this.BtnOpenSEYRUP.Click += new System.EventHandler(this.BtnOpenSEYRUP_Click);
            // 
            // BtnSaveSEYRUP
            // 
            this.BtnSaveSEYRUP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSaveSEYRUP.Enabled = false;
            this.BtnSaveSEYRUP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
            this.BtnSaveSEYRUP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Honeydew;
            this.BtnSaveSEYRUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveSEYRUP.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveSEYRUP.Location = new System.Drawing.Point(3, 143);
            this.BtnSaveSEYRUP.Name = "BtnSaveSEYRUP";
            this.BtnSaveSEYRUP.Size = new System.Drawing.Size(227, 64);
            this.BtnSaveSEYRUP.TabIndex = 1;
            this.BtnSaveSEYRUP.Text = "Save SEYRUP";
            this.BtnSaveSEYRUP.UseVisualStyleBackColor = false;
            this.BtnSaveSEYRUP.Click += new System.EventHandler(this.BtnSaveSEYRUP_Click);
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblInfo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.Location = new System.Drawing.Point(3, 70);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(227, 70);
            this.LblInfo.TabIndex = 2;
            this.LblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SwapABGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 210);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(249, 249);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(249, 249);
            this.Name = "SwapABGrid";
            this.Text = "Swap AB Grid";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnOpenSEYRUP;
        private System.Windows.Forms.Button BtnSaveSEYRUP;
        private System.Windows.Forms.Label LblInfo;
        private System.ComponentModel.BackgroundWorker DataLoadingWorker;
    }
}