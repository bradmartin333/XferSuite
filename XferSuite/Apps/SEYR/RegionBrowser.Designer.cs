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
            this.OpenImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenEntireWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSelectedRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCopyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyEntireWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopySelectedRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenExcelEntireWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenExcelSelectedRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCopyCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.renderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenderAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenderSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeClickableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClickableAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ClickableSelectedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MakeCycleFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MakeCycleFileAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MakeCycleFileSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSEYRUPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportSEYRUPEntireWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportSEYRUPSelectedRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCompositeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportCompositeEntireWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportCompositeSelectedRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IgnoreSelectedRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyDataRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyDataRowsEntireWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyDataRowsSelectedRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenImageToolStripMenuItem,
            this.ToolStripMenuItemCopyImage,
            this.openInExcelToolStripMenuItem,
            this.ToolStripMenuItemCopyCSV,
            this.CopyDataRowsToolStripMenuItem,
            this.MakeCycleFileToolStripMenuItem,
            this.renderToolStripMenuItem,
            this.makeClickableToolStripMenuItem,
            this.exportSEYRUPToolStripMenuItem,
            this.exportCompositeImageToolStripMenuItem,
            this.IgnoreSelectedRegionToolStripMenuItem});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(224, 246);
            // 
            // OpenImageToolStripMenuItem
            // 
            this.OpenImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenEntireWindowToolStripMenuItem,
            this.OpenSelectedRegionToolStripMenuItem});
            this.OpenImageToolStripMenuItem.Name = "OpenImageToolStripMenuItem";
            this.OpenImageToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.OpenImageToolStripMenuItem.Text = "Open Image";
            // 
            // OpenEntireWindowToolStripMenuItem
            // 
            this.OpenEntireWindowToolStripMenuItem.Name = "OpenEntireWindowToolStripMenuItem";
            this.OpenEntireWindowToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.OpenEntireWindowToolStripMenuItem.Text = "Entire Window";
            this.OpenEntireWindowToolStripMenuItem.Click += new System.EventHandler(this.OpenEntireWindowToolStripMenuItem_Click);
            // 
            // OpenSelectedRegionToolStripMenuItem
            // 
            this.OpenSelectedRegionToolStripMenuItem.Name = "OpenSelectedRegionToolStripMenuItem";
            this.OpenSelectedRegionToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.OpenSelectedRegionToolStripMenuItem.Text = "Selected Region";
            this.OpenSelectedRegionToolStripMenuItem.Click += new System.EventHandler(this.OpenSelectedRegionToolStripMenuItem_Click);
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
            this.CopyEntireWindowToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.CopyEntireWindowToolStripMenuItem.Text = "Entire Window";
            this.CopyEntireWindowToolStripMenuItem.Click += new System.EventHandler(this.CopyEntireWindowToolStripMenuItem_Click);
            // 
            // CopySelectedRegionToolStripMenuItem
            // 
            this.CopySelectedRegionToolStripMenuItem.Name = "CopySelectedRegionToolStripMenuItem";
            this.CopySelectedRegionToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.CopySelectedRegionToolStripMenuItem.Text = "Selected Region";
            this.CopySelectedRegionToolStripMenuItem.Click += new System.EventHandler(this.CopySelectedRegionToolStripMenuItem_Click);
            // 
            // openInExcelToolStripMenuItem
            // 
            this.openInExcelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenExcelEntireWindowToolStripMenuItem,
            this.OpenExcelSelectedRegionToolStripMenuItem});
            this.openInExcelToolStripMenuItem.Name = "openInExcelToolStripMenuItem";
            this.openInExcelToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.openInExcelToolStripMenuItem.Text = "Open In Excel";
            // 
            // OpenExcelEntireWindowToolStripMenuItem
            // 
            this.OpenExcelEntireWindowToolStripMenuItem.Name = "OpenExcelEntireWindowToolStripMenuItem";
            this.OpenExcelEntireWindowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenExcelEntireWindowToolStripMenuItem.Text = "Entire Window";
            this.OpenExcelEntireWindowToolStripMenuItem.Click += new System.EventHandler(this.OpenExcelEntireWindowToolStripMenuItem_Click);
            // 
            // OpenExcelSelectedRegionToolStripMenuItem
            // 
            this.OpenExcelSelectedRegionToolStripMenuItem.Name = "OpenExcelSelectedRegionToolStripMenuItem";
            this.OpenExcelSelectedRegionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenExcelSelectedRegionToolStripMenuItem.Text = "Selected Region";
            this.OpenExcelSelectedRegionToolStripMenuItem.Click += new System.EventHandler(this.OpenExcelSelectedRegionToolStripMenuItem_Click);
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
            this.RenderAllToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.RenderAllToolStripMenuItem.Text = "Entire Window";
            this.RenderAllToolStripMenuItem.Click += new System.EventHandler(this.RenderAllToolStripMenuItem_Click);
            // 
            // RenderSelectedToolStripMenuItem
            // 
            this.RenderSelectedToolStripMenuItem.Name = "RenderSelectedToolStripMenuItem";
            this.RenderSelectedToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.RenderSelectedToolStripMenuItem.Text = "Selected Region";
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
            this.ClickableAllToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.ClickableAllToolStripMenuItem1.Text = "Entire Window";
            this.ClickableAllToolStripMenuItem1.Click += new System.EventHandler(this.ClickableAllToolStripMenuItem1_Click);
            // 
            // ClickableSelectedToolStripMenuItem1
            // 
            this.ClickableSelectedToolStripMenuItem1.Name = "ClickableSelectedToolStripMenuItem1";
            this.ClickableSelectedToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.ClickableSelectedToolStripMenuItem1.Text = "Selected Region";
            this.ClickableSelectedToolStripMenuItem1.Click += new System.EventHandler(this.ClickableSelectedToolStripMenuItem1_Click);
            // 
            // MakeCycleFileToolStripMenuItem
            // 
            this.MakeCycleFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MakeCycleFileAllToolStripMenuItem,
            this.MakeCycleFileSelectedToolStripMenuItem});
            this.MakeCycleFileToolStripMenuItem.Name = "MakeCycleFileToolStripMenuItem";
            this.MakeCycleFileToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.MakeCycleFileToolStripMenuItem.Text = "Make Repair Cycle File";
            // 
            // MakeCycleFileAllToolStripMenuItem
            // 
            this.MakeCycleFileAllToolStripMenuItem.Name = "MakeCycleFileAllToolStripMenuItem";
            this.MakeCycleFileAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.MakeCycleFileAllToolStripMenuItem.Text = "Entire Window";
            this.MakeCycleFileAllToolStripMenuItem.Click += new System.EventHandler(this.MakeCycleFileAllToolStripMenuItem_Click);
            // 
            // MakeCycleFileSelectedToolStripMenuItem
            // 
            this.MakeCycleFileSelectedToolStripMenuItem.Name = "MakeCycleFileSelectedToolStripMenuItem";
            this.MakeCycleFileSelectedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.MakeCycleFileSelectedToolStripMenuItem.Text = "Selected Region";
            this.MakeCycleFileSelectedToolStripMenuItem.Click += new System.EventHandler(this.MakeCycleFileSelectedToolStripMenuItem_Click);
            // 
            // exportSEYRUPToolStripMenuItem
            // 
            this.exportSEYRUPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportSEYRUPEntireWindowToolStripMenuItem,
            this.ExportSEYRUPSelectedRegionToolStripMenuItem});
            this.exportSEYRUPToolStripMenuItem.Name = "exportSEYRUPToolStripMenuItem";
            this.exportSEYRUPToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.exportSEYRUPToolStripMenuItem.Text = "Export SEYRUP";
            // 
            // ExportSEYRUPEntireWindowToolStripMenuItem
            // 
            this.ExportSEYRUPEntireWindowToolStripMenuItem.Name = "ExportSEYRUPEntireWindowToolStripMenuItem";
            this.ExportSEYRUPEntireWindowToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ExportSEYRUPEntireWindowToolStripMenuItem.Text = "Entire Window";
            this.ExportSEYRUPEntireWindowToolStripMenuItem.Click += new System.EventHandler(this.ExportSEYRUPEntireWindowToolStripMenuItem_Click);
            // 
            // ExportSEYRUPSelectedRegionToolStripMenuItem
            // 
            this.ExportSEYRUPSelectedRegionToolStripMenuItem.Name = "ExportSEYRUPSelectedRegionToolStripMenuItem";
            this.ExportSEYRUPSelectedRegionToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ExportSEYRUPSelectedRegionToolStripMenuItem.Text = "Selected Region";
            this.ExportSEYRUPSelectedRegionToolStripMenuItem.Click += new System.EventHandler(this.ExportSEYRUPSelectedRegionToolStripMenuItem_Click);
            // 
            // exportCompositeImageToolStripMenuItem
            // 
            this.exportCompositeImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportCompositeEntireWindowToolStripMenuItem,
            this.ExportCompositeSelectedRegionToolStripMenuItem});
            this.exportCompositeImageToolStripMenuItem.Name = "exportCompositeImageToolStripMenuItem";
            this.exportCompositeImageToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.exportCompositeImageToolStripMenuItem.Text = "Export Composite Image";
            // 
            // ExportCompositeEntireWindowToolStripMenuItem
            // 
            this.ExportCompositeEntireWindowToolStripMenuItem.Name = "ExportCompositeEntireWindowToolStripMenuItem";
            this.ExportCompositeEntireWindowToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ExportCompositeEntireWindowToolStripMenuItem.Text = "Entire Window";
            this.ExportCompositeEntireWindowToolStripMenuItem.Click += new System.EventHandler(this.ExportCompositeEntireWindowToolStripMenuItem_Click);
            // 
            // ExportCompositeSelectedRegionToolStripMenuItem
            // 
            this.ExportCompositeSelectedRegionToolStripMenuItem.Name = "ExportCompositeSelectedRegionToolStripMenuItem";
            this.ExportCompositeSelectedRegionToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ExportCompositeSelectedRegionToolStripMenuItem.Text = "Selected Region";
            this.ExportCompositeSelectedRegionToolStripMenuItem.Click += new System.EventHandler(this.ExportCompositeSelectedRegionToolStripMenuItem_Click);
            // 
            // IgnoreSelectedRegionToolStripMenuItem
            // 
            this.IgnoreSelectedRegionToolStripMenuItem.Name = "IgnoreSelectedRegionToolStripMenuItem";
            this.IgnoreSelectedRegionToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.IgnoreSelectedRegionToolStripMenuItem.Text = "Ignore Selected Region";
            this.IgnoreSelectedRegionToolStripMenuItem.Click += new System.EventHandler(this.IgnoreSelectedRegionToolStripMenuItem_Click);
            // 
            // CopyDataRowsToolStripMenuItem
            // 
            this.CopyDataRowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyDataRowsEntireWindowToolStripMenuItem,
            this.CopyDataRowsSelectedRegionToolStripMenuItem});
            this.CopyDataRowsToolStripMenuItem.Name = "CopyDataRowsToolStripMenuItem";
            this.CopyDataRowsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.CopyDataRowsToolStripMenuItem.Text = "Copy Data Rows";
            // 
            // CopyDataRowsEntireWindowToolStripMenuItem
            // 
            this.CopyDataRowsEntireWindowToolStripMenuItem.Name = "CopyDataRowsEntireWindowToolStripMenuItem";
            this.CopyDataRowsEntireWindowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CopyDataRowsEntireWindowToolStripMenuItem.Text = "Entire Window";
            this.CopyDataRowsEntireWindowToolStripMenuItem.Click += new System.EventHandler(this.CopyDataRowsEntireWindowToolStripMenuItem_Click);
            // 
            // CopyDataRowsSelectedRegionToolStripMenuItem
            // 
            this.CopyDataRowsSelectedRegionToolStripMenuItem.Name = "CopyDataRowsSelectedRegionToolStripMenuItem";
            this.CopyDataRowsSelectedRegionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CopyDataRowsSelectedRegionToolStripMenuItem.Text = "Selected Region";
            this.CopyDataRowsSelectedRegionToolStripMenuItem.Click += new System.EventHandler(this.CopyDataRowsSelectedRegionToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem MakeCycleFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MakeCycleFileAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MakeCycleFileSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenEntireWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenSelectedRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IgnoreSelectedRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenExcelEntireWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenExcelSelectedRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSEYRUPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportSEYRUPEntireWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportSEYRUPSelectedRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCompositeImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportCompositeEntireWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportCompositeSelectedRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyDataRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyDataRowsEntireWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyDataRowsSelectedRegionToolStripMenuItem;
    }
}