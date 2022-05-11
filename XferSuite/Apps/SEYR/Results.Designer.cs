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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ComboPropertySelector = new System.Windows.Forms.ComboBox();
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CbxToggleMarker = new System.Windows.Forms.CheckBox();
            this.CbxTogglePassFail = new System.Windows.Forms.CheckBox();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnRefreshPlot = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormsPlot
            // 
            this.tableLayoutPanel.SetColumnSpan(this.FormsPlot, 5);
            this.FormsPlot.Location = new System.Drawing.Point(3, 3);
            this.FormsPlot.Name = "FormsPlot";
            this.tableLayoutPanel.SetRowSpan(this.FormsPlot, 2);
            this.FormsPlot.Size = new System.Drawing.Size(559, 492);
            this.FormsPlot.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Controls.Add(this.FormsPlot, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.ComboPropertySelector, 5, 0);
            this.tableLayoutPanel.Controls.Add(this.PropertyGrid, 5, 1);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(759, 536);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // ComboPropertySelector
            // 
            this.ComboPropertySelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboPropertySelector.FormattingEnabled = true;
            this.ComboPropertySelector.Location = new System.Drawing.Point(568, 3);
            this.ComboPropertySelector.Name = "ComboPropertySelector";
            this.ComboPropertySelector.Size = new System.Drawing.Size(188, 21);
            this.ComboPropertySelector.TabIndex = 4;
            this.ComboPropertySelector.SelectedIndexChanged += new System.EventHandler(this.ComboPropertySelector_SelectedIndexChanged);
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid.Location = new System.Drawing.Point(568, 30);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.Size = new System.Drawing.Size(188, 468);
            this.PropertyGrid.TabIndex = 5;
            this.PropertyGrid.ToolbarVisible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.flowLayoutPanel1, 6);
            this.flowLayoutPanel1.Controls.Add(this.CbxToggleMarker);
            this.flowLayoutPanel1.Controls.Add(this.CbxTogglePassFail);
            this.flowLayoutPanel1.Controls.Add(this.BtnReset);
            this.flowLayoutPanel1.Controls.Add(this.BtnRefreshPlot);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(121, 504);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(516, 29);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // CbxToggleMarker
            // 
            this.CbxToggleMarker.Appearance = System.Windows.Forms.Appearance.Button;
            this.CbxToggleMarker.BackColor = System.Drawing.Color.White;
            this.CbxToggleMarker.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightBlue;
            this.CbxToggleMarker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbxToggleMarker.Location = new System.Drawing.Point(3, 3);
            this.CbxToggleMarker.Name = "CbxToggleMarker";
            this.CbxToggleMarker.Size = new System.Drawing.Size(123, 23);
            this.CbxToggleMarker.TabIndex = 5;
            this.CbxToggleMarker.Text = "Toggle Marker";
            this.CbxToggleMarker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CbxToggleMarker.UseVisualStyleBackColor = false;
            this.CbxToggleMarker.CheckedChanged += new System.EventHandler(this.CbxToggleMarker_CheckedChanged);
            // 
            // CbxTogglePassFail
            // 
            this.CbxTogglePassFail.Appearance = System.Windows.Forms.Appearance.Button;
            this.CbxTogglePassFail.BackColor = System.Drawing.Color.White;
            this.CbxTogglePassFail.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightBlue;
            this.CbxTogglePassFail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbxTogglePassFail.Location = new System.Drawing.Point(132, 3);
            this.CbxTogglePassFail.Name = "CbxTogglePassFail";
            this.CbxTogglePassFail.Size = new System.Drawing.Size(123, 23);
            this.CbxTogglePassFail.TabIndex = 1;
            this.CbxTogglePassFail.Text = "Toggle Pass/Fail";
            this.CbxTogglePassFail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CbxTogglePassFail.UseVisualStyleBackColor = false;
            this.CbxTogglePassFail.CheckedChanged += new System.EventHandler(this.CbxTogglePassFail_CheckedChanged);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.White;
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Location = new System.Drawing.Point(261, 3);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(123, 23);
            this.BtnReset.TabIndex = 3;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnRefreshPlot
            // 
            this.BtnRefreshPlot.BackColor = System.Drawing.Color.White;
            this.BtnRefreshPlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefreshPlot.Location = new System.Drawing.Point(390, 3);
            this.BtnRefreshPlot.Name = "BtnRefreshPlot";
            this.BtnRefreshPlot.Size = new System.Drawing.Size(123, 23);
            this.BtnRefreshPlot.TabIndex = 4;
            this.BtnRefreshPlot.Text = "Refresh";
            this.BtnRefreshPlot.UseVisualStyleBackColor = false;
            this.BtnRefreshPlot.Click += new System.EventHandler(this.BtnRefreshPlot_Click);
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 536);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(775, 575);
            this.Name = "Results";
            this.Text = "Results";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot FormsPlot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.CheckBox CbxTogglePassFail;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.ComboBox ComboPropertySelector;
        private System.Windows.Forms.PropertyGrid PropertyGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BtnRefreshPlot;
        private System.Windows.Forms.CheckBox CbxToggleMarker;
    }
}