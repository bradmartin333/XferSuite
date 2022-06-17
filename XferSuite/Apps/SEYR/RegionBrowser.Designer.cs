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
            this.renderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenderAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenderSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeClickableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClickableAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ClickableSelectedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeCycleFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MakeCycleFileAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MakeCycleFileSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenImageToolStripMenuItem,
            this.ToolStripMenuItemCopyImage,
            this.ToolStripMenuItemCopyCSV,
            this.renderToolStripMenuItem,
            this.makeClickableToolStripMenuItem,
            this.makeCycleFileToolStripMenuItem});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(224, 158);
            // 
            // ToolStripMenuItemCopyImage
            // 
            this.ToolStripMenuItemCopyImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyEntireWindowToolStripMenuItem,
            this.CopySelectedRegionToolStripMenuItem});
            this.ToolStripMenuItemCopyImage.Name = "ToolStripMenuItemCopyImage";
            this.ToolStripMenuItemCopyImage.Size = new System.Drawing.Size(223, 22);
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
            this.ToolStripMenuItemCopyCSV.Size = new System.Drawing.Size(223, 22);
            this.ToolStripMenuItemCopyCSV.Text = "Copy CSV";
            this.ToolStripMenuItemCopyCSV.Click += new System.EventHandler(this.ToolStripMenuCopyCSV_Click);
            // 
            // renderToolStripMenuItem
            // 
            this.renderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RenderAllToolStripMenuItem,
            this.RenderSelectedToolStripMenuItem});
            this.renderToolStripMenuItem.Name = "renderToolStripMenuItem";
            this.renderToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.renderToolStripMenuItem.Text = "Render (Disables Inspection)";
            // 
            // RenderAllToolStripMenuItem
            // 
            this.RenderAllToolStripMenuItem.Name = "RenderAllToolStripMenuItem";
            this.RenderAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RenderAllToolStripMenuItem.Text = "All";
            this.RenderAllToolStripMenuItem.Click += new System.EventHandler(this.RenderAllToolStripMenuItem_Click);
            // 
            // RenderSelectedToolStripMenuItem
            // 
            this.RenderSelectedToolStripMenuItem.Name = "RenderSelectedToolStripMenuItem";
            this.RenderSelectedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RenderSelectedToolStripMenuItem.Text = "Selected";
            this.RenderSelectedToolStripMenuItem.Click += new System.EventHandler(this.RenderSelectedToolStripMenuItem_Click);
            // 
            // makeClickableToolStripMenuItem
            // 
            this.makeClickableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClickableAllToolStripMenuItem1,
            this.ClickableSelectedToolStripMenuItem1});
            this.makeClickableToolStripMenuItem.Name = "makeClickableToolStripMenuItem";
            this.makeClickableToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.makeClickableToolStripMenuItem.Text = "Make Clickable";
            // 
            // ClickableAllToolStripMenuItem1
            // 
            this.ClickableAllToolStripMenuItem1.Name = "ClickableAllToolStripMenuItem1";
            this.ClickableAllToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.ClickableAllToolStripMenuItem1.Text = "All";
            this.ClickableAllToolStripMenuItem1.Click += new System.EventHandler(this.ClickableAllToolStripMenuItem1_Click);
            // 
            // ClickableSelectedToolStripMenuItem1
            // 
            this.ClickableSelectedToolStripMenuItem1.Name = "ClickableSelectedToolStripMenuItem1";
            this.ClickableSelectedToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.ClickableSelectedToolStripMenuItem1.Text = "Selected";
            this.ClickableSelectedToolStripMenuItem1.Click += new System.EventHandler(this.ClickableSelectedToolStripMenuItem1_Click);
            // 
            // OpenImageToolStripMenuItem
            // 
            this.OpenImageToolStripMenuItem.Name = "OpenImageToolStripMenuItem";
            this.OpenImageToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.OpenImageToolStripMenuItem.Text = "Open Image (Middle Click)";
            this.OpenImageToolStripMenuItem.Click += new System.EventHandler(this.OpenImageToolStripMenuItem_Click);
            // 
            // makeCycleFileToolStripMenuItem
            // 
            this.makeCycleFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MakeCycleFileAllToolStripMenuItem,
            this.MakeCycleFileSelectedToolStripMenuItem});
            this.makeCycleFileToolStripMenuItem.Name = "makeCycleFileToolStripMenuItem";
            this.makeCycleFileToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.makeCycleFileToolStripMenuItem.Text = "Make Repair Cycle File";
            // 
            // MakeCycleFileAllToolStripMenuItem
            // 
            this.MakeCycleFileAllToolStripMenuItem.Name = "MakeCycleFileAllToolStripMenuItem";
            this.MakeCycleFileAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.MakeCycleFileAllToolStripMenuItem.Text = "All";
            this.MakeCycleFileAllToolStripMenuItem.Click += new System.EventHandler(this.MakeCycleFileAllToolStripMenuItem_Click);
            // 
            // MakeCycleFileSelectedToolStripMenuItem
            // 
            this.MakeCycleFileSelectedToolStripMenuItem.Name = "MakeCycleFileSelectedToolStripMenuItem";
            this.MakeCycleFileSelectedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.MakeCycleFileSelectedToolStripMenuItem.Text = "Selected";
            this.MakeCycleFileSelectedToolStripMenuItem.Click += new System.EventHandler(this.MakeCycleFileSelectedToolStripMenuItem_Click);
            // 
            // RegionBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
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
        private System.Windows.Forms.ToolStripMenuItem renderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenderAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenderSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeClickableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClickableAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ClickableSelectedToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OpenImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeCycleFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MakeCycleFileAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MakeCycleFileSelectedToolStripMenuItem;
    }
}