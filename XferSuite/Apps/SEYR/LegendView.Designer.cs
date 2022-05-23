namespace XferSuite.Apps.SEYR
{
    partial class LegendView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegendView));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CbxTogglePF = new System.Windows.Forms.CheckBox();
            this.PBX = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.CbxTogglePF, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.PBX, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(289, 164);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // CbxTogglePF
            // 
            this.CbxTogglePF.Appearance = System.Windows.Forms.Appearance.Button;
            this.CbxTogglePF.AutoSize = true;
            this.CbxTogglePF.BackColor = System.Drawing.Color.White;
            this.CbxTogglePF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CbxTogglePF.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.CbxTogglePF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbxTogglePF.Location = new System.Drawing.Point(3, 138);
            this.CbxTogglePF.Name = "CbxTogglePF";
            this.CbxTogglePF.Size = new System.Drawing.Size(283, 23);
            this.CbxTogglePF.TabIndex = 0;
            this.CbxTogglePF.Text = "Toggle Pass Fail";
            this.CbxTogglePF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CbxTogglePF.UseVisualStyleBackColor = false;
            this.CbxTogglePF.CheckedChanged += new System.EventHandler(this.CbxTogglePF_CheckedChanged);
            // 
            // PBX
            // 
            this.PBX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PBX.Location = new System.Drawing.Point(3, 3);
            this.PBX.Name = "PBX";
            this.PBX.Size = new System.Drawing.Size(283, 129);
            this.PBX.TabIndex = 1;
            this.PBX.TabStop = false;
            // 
            // LegendView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 164);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LegendView";
            this.Text = "Legend";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.CheckBox CbxTogglePF;
        private System.Windows.Forms.PictureBox PBX;
    }
}