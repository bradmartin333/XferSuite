namespace XferSuite.Apps.SEYR
{
    partial class Results
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Results));
            this.FormsPlot = new ScottPlot.FormsPlot();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxTogglePassFail = new System.Windows.Forms.CheckBox();
            this.BtnResetPlot = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormsPlot
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.FormsPlot, 5);
            this.FormsPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormsPlot.Location = new System.Drawing.Point(3, 3);
            this.FormsPlot.Name = "FormsPlot";
            this.FormsPlot.Size = new System.Drawing.Size(617, 498);
            this.FormsPlot.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.FormsPlot, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CbxTogglePassFail, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnResetPlot, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 533);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // CbxTogglePassFail
            // 
            this.CbxTogglePassFail.Appearance = System.Windows.Forms.Appearance.Button;
            this.CbxTogglePassFail.AutoSize = true;
            this.CbxTogglePassFail.BackColor = System.Drawing.Color.White;
            this.CbxTogglePassFail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CbxTogglePassFail.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightBlue;
            this.CbxTogglePassFail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbxTogglePassFail.Location = new System.Drawing.Point(3, 507);
            this.CbxTogglePassFail.Name = "CbxTogglePassFail";
            this.CbxTogglePassFail.Size = new System.Drawing.Size(118, 23);
            this.CbxTogglePassFail.TabIndex = 1;
            this.CbxTogglePassFail.Text = "Toggle Pass/Fail";
            this.CbxTogglePassFail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CbxTogglePassFail.UseVisualStyleBackColor = false;
            this.CbxTogglePassFail.CheckedChanged += new System.EventHandler(this.CbxTogglePassFail_CheckedChanged);
            // 
            // BtnResetPlot
            // 
            this.BtnResetPlot.BackColor = System.Drawing.Color.White;
            this.BtnResetPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnResetPlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnResetPlot.Location = new System.Drawing.Point(127, 507);
            this.BtnResetPlot.Name = "BtnResetPlot";
            this.BtnResetPlot.Size = new System.Drawing.Size(118, 23);
            this.BtnResetPlot.TabIndex = 2;
            this.BtnResetPlot.Text = "Reset Plot";
            this.BtnResetPlot.UseVisualStyleBackColor = false;
            this.BtnResetPlot.Click += new System.EventHandler(this.BtnResetPlot_Click);
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 533);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Results";
            this.Text = "Results";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot FormsPlot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox CbxTogglePassFail;
        private System.Windows.Forms.Button BtnResetPlot;
    }
}