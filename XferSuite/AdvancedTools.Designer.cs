namespace XferSuite
{
    partial class AdvancedTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedTools));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ListBox = new System.Windows.Forms.ListBox();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.ListBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.BtnOpen, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(280, 119);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // ListBox
            // 
            this.ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox.FormattingEnabled = true;
            this.ListBox.Items.AddRange(new object[] {
            "10Zone 2Dcal Generator",
            "uTP Log Parser",
            "roux",
            "Camera Network Refresh"});
            this.ListBox.Location = new System.Drawing.Point(3, 3);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(274, 82);
            this.ListBox.TabIndex = 0;
            // 
            // BtnOpen
            // 
            this.BtnOpen.AutoSize = true;
            this.BtnOpen.BackColor = System.Drawing.Color.White;
            this.BtnOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOpen.Location = new System.Drawing.Point(3, 91);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(274, 25);
            this.BtnOpen.TabIndex = 1;
            this.BtnOpen.Text = "Open";
            this.BtnOpen.UseVisualStyleBackColor = false;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // AdvancedTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 119);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdvancedTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Tools";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ListBox ListBox;
        private System.Windows.Forms.Button BtnOpen;
    }
}