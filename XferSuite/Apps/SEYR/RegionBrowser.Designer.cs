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
            this.ToolStripMenuItemFlipHoriz = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFlipVert = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.FlipHorizApplyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FlipVertApplyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RotateApplyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyEntireWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCopyImage,
            this.ToolStripMenuItemFlipHoriz,
            this.ToolStripMenuItemFlipVert,
            this.ToolStripMenuItemRotate,
            this.ToolStripMenuItemExportExcel});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(181, 136);
            // 
            // ToolStripMenuItemCopyImage
            // 
            this.ToolStripMenuItemCopyImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyEntireWindowToolStripMenuItem});
            this.ToolStripMenuItemCopyImage.Name = "ToolStripMenuItemCopyImage";
            this.ToolStripMenuItemCopyImage.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemCopyImage.Text = "Copy Image";
            this.ToolStripMenuItemCopyImage.Click += new System.EventHandler(this.ToolStripMenuItemCopyImage_Click);
            // 
            // ToolStripMenuItemFlipHoriz
            // 
            this.ToolStripMenuItemFlipHoriz.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FlipHorizApplyAllToolStripMenuItem});
            this.ToolStripMenuItemFlipHoriz.Name = "ToolStripMenuItemFlipHoriz";
            this.ToolStripMenuItemFlipHoriz.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemFlipHoriz.Text = "Flip Horizontally";
            this.ToolStripMenuItemFlipHoriz.Click += new System.EventHandler(this.ToolStripMenuItemFlipHoriz_Click);
            // 
            // ToolStripMenuItemFlipVert
            // 
            this.ToolStripMenuItemFlipVert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FlipVertApplyAllToolStripMenuItem});
            this.ToolStripMenuItemFlipVert.Name = "ToolStripMenuItemFlipVert";
            this.ToolStripMenuItemFlipVert.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemFlipVert.Text = "Flip Vertically";
            this.ToolStripMenuItemFlipVert.Click += new System.EventHandler(this.ToolStripMenuItemFlipVert_Click);
            // 
            // ToolStripMenuItemRotate
            // 
            this.ToolStripMenuItemRotate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RotateApplyAllToolStripMenuItem});
            this.ToolStripMenuItemRotate.Name = "ToolStripMenuItemRotate";
            this.ToolStripMenuItemRotate.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemRotate.Text = "Rotate 90 degrees";
            this.ToolStripMenuItemRotate.Click += new System.EventHandler(this.ToolStripMenuItemRotate_Click);
            // 
            // ToolStripMenuItemExportExcel
            // 
            this.ToolStripMenuItemExportExcel.Name = "ToolStripMenuItemExportExcel";
            this.ToolStripMenuItemExportExcel.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemExportExcel.Text = "Export to Excel";
            this.ToolStripMenuItemExportExcel.Click += new System.EventHandler(this.ToolStripMenuItemExportExcel_Click);
            // 
            // FlipHorizApplyAllToolStripMenuItem
            // 
            this.FlipHorizApplyAllToolStripMenuItem.Name = "FlipHorizApplyAllToolStripMenuItem";
            this.FlipHorizApplyAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FlipHorizApplyAllToolStripMenuItem.Text = "Apply All";
            this.FlipHorizApplyAllToolStripMenuItem.Click += new System.EventHandler(this.FlipHorizApplyAllToolStripMenuItem_Click);
            // 
            // FlipVertApplyAllToolStripMenuItem
            // 
            this.FlipVertApplyAllToolStripMenuItem.Name = "FlipVertApplyAllToolStripMenuItem";
            this.FlipVertApplyAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FlipVertApplyAllToolStripMenuItem.Text = "Apply All";
            this.FlipVertApplyAllToolStripMenuItem.Click += new System.EventHandler(this.FlipVertApplyAllToolStripMenuItem_Click);
            // 
            // RotateApplyAllToolStripMenuItem
            // 
            this.RotateApplyAllToolStripMenuItem.Name = "RotateApplyAllToolStripMenuItem";
            this.RotateApplyAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RotateApplyAllToolStripMenuItem.Text = "Apply All";
            this.RotateApplyAllToolStripMenuItem.Click += new System.EventHandler(this.RotateApplyAllToolStripMenuItem_Click);
            // 
            // CopyEntireWindowToolStripMenuItem
            // 
            this.CopyEntireWindowToolStripMenuItem.Name = "CopyEntireWindowToolStripMenuItem";
            this.CopyEntireWindowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CopyEntireWindowToolStripMenuItem.Text = "Entire Window";
            this.CopyEntireWindowToolStripMenuItem.Click += new System.EventHandler(this.CopyEntireWindowToolStripMenuItem_Click);
            // 
            // RegionBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 654);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegionBrowser";
            this.Text = "Region Browser";
            this.ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopyImage;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFlipHoriz;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFlipVert;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRotate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExportExcel;
        private System.Windows.Forms.ToolStripMenuItem FlipHorizApplyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FlipVertApplyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RotateApplyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyEntireWindowToolStripMenuItem;
    }
}