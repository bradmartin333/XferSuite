
namespace XferSuite.Apps.Camera
{
    partial class CameraViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraViewer));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnToggleListView = new System.Windows.Forms.ToolStripButton();
            this.btnToggleCrosshair = new System.Windows.Forms.ToolStripButton();
            this.btnCrosshairColor = new System.Windows.Forms.ToolStripButton();
            this.btnSaveFrame = new System.Windows.Forms.ToolStripButton();
            this.btnResetSessionMem = new System.Windows.Forms.ToolStripButton();
            this.ToolStripComboBoxRotateFlip = new System.Windows.Forms.ToolStripComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnToggleListView,
            this.btnToggleCrosshair,
            this.btnCrosshairColor,
            this.btnSaveFrame,
            this.btnResetSessionMem,
            this.ToolStripComboBoxRotateFlip});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(543, 27);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnToggleListView
            // 
            this.btnToggleListView.Checked = true;
            this.btnToggleListView.CheckOnClick = true;
            this.btnToggleListView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnToggleListView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToggleListView.Image = global::XferSuite.Properties.Resources.visible;
            this.btnToggleListView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToggleListView.Name = "btnToggleListView";
            this.btnToggleListView.Size = new System.Drawing.Size(24, 24);
            this.btnToggleListView.Text = "Toggle List View";
            this.btnToggleListView.Click += new System.EventHandler(this.BtnToggleListView_Click);
            // 
            // btnToggleCrosshair
            // 
            this.btnToggleCrosshair.CheckOnClick = true;
            this.btnToggleCrosshair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToggleCrosshair.Image = ((System.Drawing.Image)(resources.GetObject("btnToggleCrosshair.Image")));
            this.btnToggleCrosshair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToggleCrosshair.Name = "btnToggleCrosshair";
            this.btnToggleCrosshair.Size = new System.Drawing.Size(24, 24);
            this.btnToggleCrosshair.Text = "Toggle Crosshair";
            this.btnToggleCrosshair.Click += new System.EventHandler(this.BtnToggleCrosshair_Click);
            // 
            // btnCrosshairColor
            // 
            this.btnCrosshairColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCrosshairColor.Image = ((System.Drawing.Image)(resources.GetObject("btnCrosshairColor.Image")));
            this.btnCrosshairColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCrosshairColor.Name = "btnCrosshairColor";
            this.btnCrosshairColor.Size = new System.Drawing.Size(24, 24);
            this.btnCrosshairColor.Text = "Crosshair Color";
            this.btnCrosshairColor.Click += new System.EventHandler(this.BtnCrosshairColor_Click);
            // 
            // btnSaveFrame
            // 
            this.btnSaveFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveFrame.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveFrame.Image")));
            this.btnSaveFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveFrame.Name = "btnSaveFrame";
            this.btnSaveFrame.Size = new System.Drawing.Size(24, 24);
            this.btnSaveFrame.Text = "Save Frame";
            this.btnSaveFrame.Click += new System.EventHandler(this.BtnSaveFrame_Click);
            // 
            // btnResetSessionMem
            // 
            this.btnResetSessionMem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnResetSessionMem.Image = ((System.Drawing.Image)(resources.GetObject("btnResetSessionMem.Image")));
            this.btnResetSessionMem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResetSessionMem.Name = "btnResetSessionMem";
            this.btnResetSessionMem.Size = new System.Drawing.Size(24, 24);
            this.btnResetSessionMem.Text = "Reset Session Memory";
            this.btnResetSessionMem.Click += new System.EventHandler(this.BtnResetSessionMem_Click);
            // 
            // ToolStripComboBoxRotateFlip
            // 
            this.ToolStripComboBoxRotateFlip.Name = "ToolStripComboBoxRotateFlip";
            this.ToolStripComboBoxRotateFlip.Size = new System.Drawing.Size(135, 27);
            // 
            // CameraViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 420);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "CameraViewer";
            this.Text = "Camera Viewer";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnToggleListView;
        private System.Windows.Forms.ToolStripButton btnToggleCrosshair;
        private System.Windows.Forms.ToolStripButton btnCrosshairColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripButton btnSaveFrame;
        private System.Windows.Forms.ToolStripButton btnResetSessionMem;
        private System.Windows.Forms.ToolStripComboBox ToolStripComboBoxRotateFlip;
    }
}