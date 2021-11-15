
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
            this.btnXYZscan = new System.Windows.Forms.Button();
            this.btnInlinepositions = new System.Windows.Forms.Button();
            this.btnPositionCalc = new System.Windows.Forms.Button();
            this.btnDataFileTree = new System.Windows.Forms.Button();
            this.btnMapFlip = new System.Windows.Forms.Button();
            this.btnParseSEYR = new System.Windows.Forms.Button();
            this.btnCameraViewer = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel.Controls.Add(this.btnPositionCalc, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.btnXYZscan, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.btnDataFileTree, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.btnInlinepositions, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.btnParseSEYR, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.btnCameraViewer, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.btnSettings, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.btnMapFlip, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(406, 170);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.AccessibleName = "Settings";
            this.btnSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.BackgroundImage")));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(313, 95);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(10);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(83, 65);
            this.btnSettings.TabIndex = 11;
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnXYZscan
            // 
            this.btnXYZscan.AccessibleName = "XYZ Scans";
            this.btnXYZscan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXYZscan.BackgroundImage")));
            this.btnXYZscan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnXYZscan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXYZscan.FlatAppearance.BorderSize = 0;
            this.btnXYZscan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnXYZscan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnXYZscan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXYZscan.Location = new System.Drawing.Point(111, 10);
            this.btnXYZscan.Margin = new System.Windows.Forms.Padding(10);
            this.btnXYZscan.Name = "btnXYZscan";
            this.btnXYZscan.Size = new System.Drawing.Size(81, 65);
            this.btnXYZscan.TabIndex = 4;
            this.btnXYZscan.Tag = "1";
            this.btnXYZscan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXYZscan.UseVisualStyleBackColor = true;
            this.btnXYZscan.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnInlinepositions
            // 
            this.btnInlinepositions.AccessibleName = "Inlinepositions";
            this.btnInlinepositions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInlinepositions.BackgroundImage")));
            this.btnInlinepositions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInlinepositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInlinepositions.FlatAppearance.BorderSize = 0;
            this.btnInlinepositions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnInlinepositions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnInlinepositions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInlinepositions.Location = new System.Drawing.Point(10, 10);
            this.btnInlinepositions.Margin = new System.Windows.Forms.Padding(10);
            this.btnInlinepositions.Name = "btnInlinepositions";
            this.btnInlinepositions.Size = new System.Drawing.Size(81, 65);
            this.btnInlinepositions.TabIndex = 2;
            this.btnInlinepositions.Tag = "0";
            this.btnInlinepositions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInlinepositions.UseVisualStyleBackColor = true;
            this.btnInlinepositions.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnPositionCalc
            // 
            this.btnPositionCalc.AccessibleName = "Position Calculator";
            this.btnPositionCalc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPositionCalc.BackgroundImage")));
            this.btnPositionCalc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPositionCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPositionCalc.FlatAppearance.BorderSize = 0;
            this.btnPositionCalc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnPositionCalc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnPositionCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionCalc.Location = new System.Drawing.Point(212, 95);
            this.btnPositionCalc.Margin = new System.Windows.Forms.Padding(10);
            this.btnPositionCalc.Name = "btnPositionCalc";
            this.btnPositionCalc.Size = new System.Drawing.Size(81, 65);
            this.btnPositionCalc.TabIndex = 12;
            this.btnPositionCalc.Tag = "6";
            this.btnPositionCalc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPositionCalc.UseVisualStyleBackColor = true;
            this.btnPositionCalc.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnDataFileTree
            // 
            this.btnDataFileTree.AccessibleName = "Data File Tree";
            this.btnDataFileTree.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDataFileTree.BackgroundImage")));
            this.btnDataFileTree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDataFileTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDataFileTree.FlatAppearance.BorderSize = 0;
            this.btnDataFileTree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnDataFileTree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnDataFileTree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataFileTree.Location = new System.Drawing.Point(10, 95);
            this.btnDataFileTree.Margin = new System.Windows.Forms.Padding(10);
            this.btnDataFileTree.Name = "btnDataFileTree";
            this.btnDataFileTree.Size = new System.Drawing.Size(81, 65);
            this.btnDataFileTree.TabIndex = 8;
            this.btnDataFileTree.Tag = "4";
            this.btnDataFileTree.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDataFileTree.UseVisualStyleBackColor = true;
            this.btnDataFileTree.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnMapFlip
            // 
            this.btnMapFlip.AccessibleName = "Map Flip";
            this.btnMapFlip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMapFlip.BackgroundImage")));
            this.btnMapFlip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMapFlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMapFlip.FlatAppearance.BorderSize = 0;
            this.btnMapFlip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnMapFlip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnMapFlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMapFlip.Location = new System.Drawing.Point(111, 95);
            this.btnMapFlip.Margin = new System.Windows.Forms.Padding(10);
            this.btnMapFlip.Name = "btnMapFlip";
            this.btnMapFlip.Size = new System.Drawing.Size(81, 65);
            this.btnMapFlip.TabIndex = 10;
            this.btnMapFlip.Tag = "5";
            this.btnMapFlip.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMapFlip.UseVisualStyleBackColor = true;
            this.btnMapFlip.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnParseSEYR
            // 
            this.btnParseSEYR.AccessibleName = "Parse SEYR Report";
            this.btnParseSEYR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnParseSEYR.BackgroundImage")));
            this.btnParseSEYR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnParseSEYR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnParseSEYR.FlatAppearance.BorderSize = 0;
            this.btnParseSEYR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnParseSEYR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnParseSEYR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParseSEYR.Location = new System.Drawing.Point(212, 10);
            this.btnParseSEYR.Margin = new System.Windows.Forms.Padding(10);
            this.btnParseSEYR.Name = "btnParseSEYR";
            this.btnParseSEYR.Size = new System.Drawing.Size(81, 65);
            this.btnParseSEYR.TabIndex = 7;
            this.btnParseSEYR.Tag = "2";
            this.btnParseSEYR.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnParseSEYR.UseVisualStyleBackColor = true;
            this.btnParseSEYR.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCameraViewer
            // 
            this.btnCameraViewer.AccessibleName = "Camera Viewer";
            this.btnCameraViewer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCameraViewer.BackgroundImage")));
            this.btnCameraViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCameraViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCameraViewer.FlatAppearance.BorderSize = 0;
            this.btnCameraViewer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnCameraViewer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnCameraViewer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCameraViewer.Location = new System.Drawing.Point(313, 10);
            this.btnCameraViewer.Margin = new System.Windows.Forms.Padding(10);
            this.btnCameraViewer.Name = "btnCameraViewer";
            this.btnCameraViewer.Size = new System.Drawing.Size(83, 65);
            this.btnCameraViewer.TabIndex = 11;
            this.btnCameraViewer.Tag = "3";
            this.btnCameraViewer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCameraViewer.UseVisualStyleBackColor = true;
            this.btnCameraViewer.Click += new System.EventHandler(this.btn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 170);
            this.Controls.Add(this.tableLayoutPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XferSuite v0.0";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnInlinepositions;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnMapFlip;
        private System.Windows.Forms.Button btnDataFileTree;
        private System.Windows.Forms.Button btnParseSEYR;
        private System.Windows.Forms.Button btnXYZscan;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnPositionCalc;
        private System.Windows.Forms.Button btnCameraViewer;
    }
}

