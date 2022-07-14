namespace XferSuite.Apps.SEYR
{
    partial class InspectionRoutine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionRoutine));
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.ListBoxNames = new System.Windows.Forms.ListBox();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnPrevious = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.PBX = new System.Windows.Forms.PictureBox();
            this.TLP.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 2;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.TLP.Controls.Add(this.ListBoxNames, 1, 0);
            this.TLP.Controls.Add(this.TextBoxName, 1, 1);
            this.TLP.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.TLP.Controls.Add(this.PBX, 0, 0);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 3;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.Size = new System.Drawing.Size(647, 440);
            this.TLP.TabIndex = 0;
            // 
            // ListBoxNames
            // 
            this.ListBoxNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxNames.FormattingEnabled = true;
            this.ListBoxNames.Location = new System.Drawing.Point(423, 3);
            this.ListBoxNames.Name = "ListBoxNames";
            this.ListBoxNames.Size = new System.Drawing.Size(221, 373);
            this.ListBoxNames.TabIndex = 3;
            // 
            // TextBoxName
            // 
            this.TextBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxName.Location = new System.Drawing.Point(423, 382);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(221, 20);
            this.TextBoxName.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.BtnPrevious);
            this.flowLayoutPanel1.Controls.Add(this.BtnNext);
            this.flowLayoutPanel1.Controls.Add(this.BtnCopy);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(437, 408);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(193, 29);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrevious.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnPrevious.BackgroundImage")));
            this.BtnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnPrevious.FlatAppearance.BorderSize = 0;
            this.BtnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrevious.Location = new System.Drawing.Point(3, 3);
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(50, 23);
            this.BtnPrevious.TabIndex = 0;
            this.BtnPrevious.UseVisualStyleBackColor = true;
            this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnNext.BackgroundImage")));
            this.BtnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnNext.FlatAppearance.BorderSize = 0;
            this.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNext.Location = new System.Drawing.Point(59, 3);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(50, 23);
            this.BtnNext.TabIndex = 1;
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnCopy
            // 
            this.BtnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCopy.BackColor = System.Drawing.Color.White;
            this.BtnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCopy.Location = new System.Drawing.Point(115, 3);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(75, 23);
            this.BtnCopy.TabIndex = 2;
            this.BtnCopy.Text = "Copy Data";
            this.BtnCopy.UseVisualStyleBackColor = false;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // PBX
            // 
            this.PBX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PBX.Location = new System.Drawing.Point(3, 3);
            this.PBX.Name = "PBX";
            this.TLP.SetRowSpan(this.PBX, 3);
            this.PBX.Size = new System.Drawing.Size(414, 434);
            this.PBX.TabIndex = 6;
            this.PBX.TabStop = false;
            // 
            // InspectionRoutine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 440);
            this.Controls.Add(this.TLP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InspectionRoutine";
            this.Text = "Inspection Routine";
            this.TLP.ResumeLayout(false);
            this.TLP.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.ListBox ListBoxNames;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BtnPrevious;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.PictureBox PBX;
    }
}