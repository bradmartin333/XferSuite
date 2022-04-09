
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
            this.btnXYZplotter = new System.Windows.Forms.Button();
            this.btnInlinepositions = new System.Windows.Forms.Button();
            this.btnParseSEYR = new System.Windows.Forms.Button();
            this.btnCameraViewer = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAdvancedTools = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Controls.Add(this.btnXYZplotter, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.btnInlinepositions, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.btnParseSEYR, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.btnCameraViewer, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.btnSettings, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.btnAdvancedTools, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(338, 170);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // btnXYZplotter
            // 
            this.btnXYZplotter.AccessibleName = "XYZ Plotter";
            this.btnXYZplotter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXYZplotter.BackgroundImage")));
            this.btnXYZplotter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnXYZplotter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXYZplotter.FlatAppearance.BorderSize = 0;
            this.btnXYZplotter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnXYZplotter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnXYZplotter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXYZplotter.Location = new System.Drawing.Point(122, 10);
            this.btnXYZplotter.Margin = new System.Windows.Forms.Padding(10);
            this.btnXYZplotter.Name = "btnXYZplotter";
            this.btnXYZplotter.Size = new System.Drawing.Size(92, 65);
            this.btnXYZplotter.TabIndex = 4;
            this.btnXYZplotter.Tag = "1";
            this.btnXYZplotter.UseVisualStyleBackColor = true;
            this.btnXYZplotter.Click += new System.EventHandler(this.Btn_Click);
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
            this.btnInlinepositions.Size = new System.Drawing.Size(92, 65);
            this.btnInlinepositions.TabIndex = 2;
            this.btnInlinepositions.Tag = "0";
            this.btnInlinepositions.UseVisualStyleBackColor = true;
            this.btnInlinepositions.Click += new System.EventHandler(this.Btn_Click);
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
            this.btnParseSEYR.Location = new System.Drawing.Point(234, 10);
            this.btnParseSEYR.Margin = new System.Windows.Forms.Padding(10);
            this.btnParseSEYR.Name = "btnParseSEYR";
            this.btnParseSEYR.Size = new System.Drawing.Size(94, 65);
            this.btnParseSEYR.TabIndex = 7;
            this.btnParseSEYR.Tag = "2";
            this.btnParseSEYR.UseVisualStyleBackColor = true;
            this.btnParseSEYR.Click += new System.EventHandler(this.Btn_Click);
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
            this.btnCameraViewer.Location = new System.Drawing.Point(10, 95);
            this.btnCameraViewer.Margin = new System.Windows.Forms.Padding(10);
            this.btnCameraViewer.Name = "btnCameraViewer";
            this.btnCameraViewer.Size = new System.Drawing.Size(92, 65);
            this.btnCameraViewer.TabIndex = 11;
            this.btnCameraViewer.Tag = "3";
            this.btnCameraViewer.UseVisualStyleBackColor = true;
            this.btnCameraViewer.Click += new System.EventHandler(this.Btn_Click);
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
            this.btnSettings.Location = new System.Drawing.Point(234, 95);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(10);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(94, 65);
            this.btnSettings.TabIndex = 11;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnAdvancedTools
            // 
            this.btnAdvancedTools.AccessibleName = "Advanced Tools";
            this.btnAdvancedTools.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdvancedTools.BackgroundImage")));
            this.btnAdvancedTools.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdvancedTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdvancedTools.FlatAppearance.BorderSize = 0;
            this.btnAdvancedTools.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.btnAdvancedTools.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnAdvancedTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvancedTools.Location = new System.Drawing.Point(122, 95);
            this.btnAdvancedTools.Margin = new System.Windows.Forms.Padding(10);
            this.btnAdvancedTools.Name = "btnAdvancedTools";
            this.btnAdvancedTools.Size = new System.Drawing.Size(92, 65);
            this.btnAdvancedTools.TabIndex = 10;
            this.btnAdvancedTools.Tag = "4";
            this.btnAdvancedTools.UseVisualStyleBackColor = true;
            this.btnAdvancedTools.Click += new System.EventHandler(this.Btn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 170);
            this.Controls.Add(this.tableLayoutPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(354, 209);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XferSuite v0.0";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnInlinepositions;
        private System.Windows.Forms.Button btnAdvancedTools;
        private System.Windows.Forms.Button btnParseSEYR;
        private System.Windows.Forms.Button btnXYZplotter;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnCameraViewer;
        public System.Windows.Forms.Button btnSettings;
    }
}

