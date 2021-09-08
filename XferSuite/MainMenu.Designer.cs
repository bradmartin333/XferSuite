
namespace XferSuite
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnMapFlip = new System.Windows.Forms.Button();
            this.btnDataFileTree = new System.Windows.Forms.Button();
            this.btnParseSEYR = new System.Windows.Forms.Button();
            this.btnPrintCycle = new System.Windows.Forms.Button();
            this.btnFingerprint = new System.Windows.Forms.Button();
            this.btnXYZscan = new System.Windows.Forms.Button();
            this.btnInlinepositions = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Controls.Add(this.btnSettings, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.btnMapFlip, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.btnDataFileTree, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.btnParseSEYR, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.btnPrintCycle, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.btnFingerprint, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.btnXYZscan, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.btnInlinepositions, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(423, 190);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.AccessibleName = "Settings";
            this.btnSettings.BackgroundImage = global::XferSuite.Properties.Resources.iconmonstr_wrench_10_240;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(323, 103);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(8);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(92, 79);
            this.btnSettings.TabIndex = 11;
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnMapFlip
            // 
            this.btnMapFlip.AccessibleName = "Map Flip";
            this.btnMapFlip.BackgroundImage = global::XferSuite.Properties.Resources.iconmonstr_map_10_240;
            this.btnMapFlip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMapFlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMapFlip.FlatAppearance.BorderSize = 0;
            this.btnMapFlip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnMapFlip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnMapFlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMapFlip.Location = new System.Drawing.Point(218, 103);
            this.btnMapFlip.Margin = new System.Windows.Forms.Padding(8);
            this.btnMapFlip.Name = "btnMapFlip";
            this.btnMapFlip.Size = new System.Drawing.Size(89, 79);
            this.btnMapFlip.TabIndex = 10;
            this.btnMapFlip.Tag = "6";
            this.btnMapFlip.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMapFlip.UseVisualStyleBackColor = true;
            this.btnMapFlip.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnDataFileTree
            // 
            this.btnDataFileTree.AccessibleName = "Data File Tree";
            this.btnDataFileTree.BackgroundImage = global::XferSuite.Properties.Resources.iconmonstr_tree_4_240;
            this.btnDataFileTree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDataFileTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDataFileTree.FlatAppearance.BorderSize = 0;
            this.btnDataFileTree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnDataFileTree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnDataFileTree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataFileTree.Location = new System.Drawing.Point(113, 103);
            this.btnDataFileTree.Margin = new System.Windows.Forms.Padding(8);
            this.btnDataFileTree.Name = "btnDataFileTree";
            this.btnDataFileTree.Size = new System.Drawing.Size(89, 79);
            this.btnDataFileTree.TabIndex = 8;
            this.btnDataFileTree.Tag = "5";
            this.btnDataFileTree.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDataFileTree.UseVisualStyleBackColor = true;
            this.btnDataFileTree.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnParseSEYR
            // 
            this.btnParseSEYR.AccessibleName = "Parse SEYR Report";
            this.btnParseSEYR.BackgroundImage = global::XferSuite.Properties.Resources.SEYRgrey;
            this.btnParseSEYR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnParseSEYR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnParseSEYR.FlatAppearance.BorderSize = 0;
            this.btnParseSEYR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnParseSEYR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnParseSEYR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParseSEYR.Location = new System.Drawing.Point(8, 103);
            this.btnParseSEYR.Margin = new System.Windows.Forms.Padding(8);
            this.btnParseSEYR.Name = "btnParseSEYR";
            this.btnParseSEYR.Size = new System.Drawing.Size(89, 79);
            this.btnParseSEYR.TabIndex = 7;
            this.btnParseSEYR.Tag = "4";
            this.btnParseSEYR.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnParseSEYR.UseVisualStyleBackColor = true;
            this.btnParseSEYR.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnPrintCycle
            // 
            this.btnPrintCycle.AccessibleName = "Print Cycle Simulation";
            this.btnPrintCycle.BackgroundImage = global::XferSuite.Properties.Resources.iconmonstr_party_9_240;
            this.btnPrintCycle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrintCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrintCycle.FlatAppearance.BorderSize = 0;
            this.btnPrintCycle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnPrintCycle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnPrintCycle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintCycle.Location = new System.Drawing.Point(323, 8);
            this.btnPrintCycle.Margin = new System.Windows.Forms.Padding(8);
            this.btnPrintCycle.Name = "btnPrintCycle";
            this.btnPrintCycle.Size = new System.Drawing.Size(92, 79);
            this.btnPrintCycle.TabIndex = 6;
            this.btnPrintCycle.Tag = "3";
            this.btnPrintCycle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrintCycle.UseVisualStyleBackColor = true;
            this.btnPrintCycle.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnFingerprint
            // 
            this.btnFingerprint.AccessibleName = "Fingerprinting";
            this.btnFingerprint.BackgroundImage = global::XferSuite.Properties.Resources.iconmonstr_fingerprint_5_240;
            this.btnFingerprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFingerprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFingerprint.FlatAppearance.BorderSize = 0;
            this.btnFingerprint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnFingerprint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFingerprint.Location = new System.Drawing.Point(218, 8);
            this.btnFingerprint.Margin = new System.Windows.Forms.Padding(8);
            this.btnFingerprint.Name = "btnFingerprint";
            this.btnFingerprint.Size = new System.Drawing.Size(89, 79);
            this.btnFingerprint.TabIndex = 5;
            this.btnFingerprint.Tag = "2";
            this.btnFingerprint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFingerprint.UseVisualStyleBackColor = true;
            this.btnFingerprint.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnXYZscan
            // 
            this.btnXYZscan.AccessibleName = "XYZ Scans";
            this.btnXYZscan.BackgroundImage = global::XferSuite.Properties.Resources.iconmonstr_layer_21_240;
            this.btnXYZscan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnXYZscan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXYZscan.FlatAppearance.BorderSize = 0;
            this.btnXYZscan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnXYZscan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnXYZscan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXYZscan.Location = new System.Drawing.Point(113, 8);
            this.btnXYZscan.Margin = new System.Windows.Forms.Padding(8);
            this.btnXYZscan.Name = "btnXYZscan";
            this.btnXYZscan.Size = new System.Drawing.Size(89, 79);
            this.btnXYZscan.TabIndex = 4;
            this.btnXYZscan.Tag = "1";
            this.btnXYZscan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXYZscan.UseVisualStyleBackColor = true;
            this.btnXYZscan.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnInlinepositions
            // 
            this.btnInlinepositions.AccessibleName = "Inlinepositions";
            this.btnInlinepositions.BackgroundImage = global::XferSuite.Properties.Resources.iconmonstr_cube_6_240;
            this.btnInlinepositions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInlinepositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInlinepositions.FlatAppearance.BorderSize = 0;
            this.btnInlinepositions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnInlinepositions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnInlinepositions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInlinepositions.Location = new System.Drawing.Point(8, 8);
            this.btnInlinepositions.Margin = new System.Windows.Forms.Padding(8);
            this.btnInlinepositions.Name = "btnInlinepositions";
            this.btnInlinepositions.Size = new System.Drawing.Size(89, 79);
            this.btnInlinepositions.TabIndex = 2;
            this.btnInlinepositions.Tag = "0";
            this.btnInlinepositions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInlinepositions.UseVisualStyleBackColor = true;
            this.btnInlinepositions.Click += new System.EventHandler(this.btn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 190);
            this.Controls.Add(this.tableLayoutPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XferSuite v1.16";
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnInlinepositions;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnMapFlip;
        private System.Windows.Forms.Button btnDataFileTree;
        private System.Windows.Forms.Button btnParseSEYR;
        private System.Windows.Forms.Button btnPrintCycle;
        private System.Windows.Forms.Button btnFingerprint;
        private System.Windows.Forms.Button btnXYZscan;
    }
}

