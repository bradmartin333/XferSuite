namespace XferSuite.Apps.SEYR
{
    partial class RegionBrowser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegionBrowser));
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemCopyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyEntireWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopySelectedRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCopyCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.RenderSelectedRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCopyImage,
            this.ToolStripMenuItemCopyCSV,
            this.RenderSelectedRegionToolStripMenuItem});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(290, 92);
            // 
            // ToolStripMenuItemCopyImage
            // 
            this.ToolStripMenuItemCopyImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyEntireWindowToolStripMenuItem,
            this.CopySelectedRegionToolStripMenuItem});
            this.ToolStripMenuItemCopyImage.Name = "ToolStripMenuItemCopyImage";
            this.ToolStripMenuItemCopyImage.Size = new System.Drawing.Size(289, 22);
            this.ToolStripMenuItemCopyImage.Text = "Copy Image";
            // 
            // CopyEntireWindowToolStripMenuItem
            // 
            this.CopyEntireWindowToolStripMenuItem.Name = "CopyEntireWindowToolStripMenuItem";
            this.CopyEntireWindowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CopyEntireWindowToolStripMenuItem.Text = "Entire Window";
            this.CopyEntireWindowToolStripMenuItem.Click += new System.EventHandler(this.CopyEntireWindowToolStripMenuItem_Click);
            // 
            // CopySelectedRegionToolStripMenuItem
            // 
            this.CopySelectedRegionToolStripMenuItem.Name = "CopySelectedRegionToolStripMenuItem";
            this.CopySelectedRegionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CopySelectedRegionToolStripMenuItem.Text = "Selected Region";
            this.CopySelectedRegionToolStripMenuItem.Click += new System.EventHandler(this.CopySelectedRegionToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemCopyCSV
            // 
            this.ToolStripMenuItemCopyCSV.Name = "ToolStripMenuItemCopyCSV";
            this.ToolStripMenuItemCopyCSV.Size = new System.Drawing.Size(289, 22);
            this.ToolStripMenuItemCopyCSV.Text = "Copy CSV";
            this.ToolStripMenuItemCopyCSV.Click += new System.EventHandler(this.ToolStripMenuCopyCSV_Click);
            // 
            // RenderSelectedRegionToolStripMenuItem
            // 
            this.RenderSelectedRegionToolStripMenuItem.Name = "RenderSelectedRegionToolStripMenuItem";
            this.RenderSelectedRegionToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.RenderSelectedRegionToolStripMenuItem.Text = "Render Selected Region (Breaks Clicking)";
            this.RenderSelectedRegionToolStripMenuItem.Click += new System.EventHandler(this.RenderSelectedRegionToolStripMenuItem_Click);
            // 
            // RegionBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 654);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegionBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Region Browser";
            this.ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopyImage;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopyCSV;
        private System.Windows.Forms.ToolStripMenuItem CopyEntireWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopySelectedRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenderSelectedRegionToolStripMenuItem;
    }
}