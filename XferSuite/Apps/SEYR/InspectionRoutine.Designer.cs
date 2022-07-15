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
            this.BtnPrevious = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnDone = new System.Windows.Forms.Button();
            this.PBX = new System.Windows.Forms.PictureBox();
            this.TLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 3;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.TLP.Controls.Add(this.ListBoxNames, 1, 0);
            this.TLP.Controls.Add(this.BtnNext, 2, 2);
            this.TLP.Controls.Add(this.TextBoxName, 1, 1);
            this.TLP.Controls.Add(this.BtnDone, 1, 3);
            this.TLP.Controls.Add(this.PBX, 0, 0);
            this.TLP.Controls.Add(this.BtnPrevious, 1, 2);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 4;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.Size = new System.Drawing.Size(647, 440);
            this.TLP.TabIndex = 0;
            // 
            // ListBoxNames
            // 
            this.TLP.SetColumnSpan(this.ListBoxNames, 2);
            this.ListBoxNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxNames.FormattingEnabled = true;
            this.ListBoxNames.Items.AddRange(new object[] {
            "null"});
            this.ListBoxNames.Location = new System.Drawing.Point(417, 3);
            this.ListBoxNames.Name = "ListBoxNames";
            this.ListBoxNames.Size = new System.Drawing.Size(227, 350);
            this.ListBoxNames.TabIndex = 3;
            this.ListBoxNames.SelectedIndexChanged += new System.EventHandler(this.ListBoxNames_SelectedIndexChanged);
            // 
            // TextBoxName
            // 
            this.TLP.SetColumnSpan(this.TextBoxName, 2);
            this.TextBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxName.Location = new System.Drawing.Point(417, 359);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(227, 20);
            this.TextBoxName.TabIndex = 4;
            this.TextBoxName.Text = "null";
            this.TextBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnPrevious.BackgroundImage")));
            this.BtnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPrevious.FlatAppearance.BorderSize = 0;
            this.BtnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrevious.Location = new System.Drawing.Point(417, 385);
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(110, 23);
            this.BtnPrevious.TabIndex = 0;
            this.BtnPrevious.UseVisualStyleBackColor = true;
            this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnNext.BackgroundImage")));
            this.BtnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnNext.FlatAppearance.BorderSize = 0;
            this.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNext.Location = new System.Drawing.Point(533, 385);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(111, 23);
            this.BtnNext.TabIndex = 1;
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnDone
            // 
            this.BtnDone.BackColor = System.Drawing.Color.White;
            this.TLP.SetColumnSpan(this.BtnDone, 2);
            this.BtnDone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDone.Location = new System.Drawing.Point(417, 414);
            this.BtnDone.Name = "BtnDone";
            this.BtnDone.Size = new System.Drawing.Size(227, 23);
            this.BtnDone.TabIndex = 2;
            this.BtnDone.Text = "Close and Copy";
            this.BtnDone.UseVisualStyleBackColor = false;
            this.BtnDone.Click += new System.EventHandler(this.BtnDone_Click);
            // 
            // PBX
            // 
            this.PBX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PBX.Location = new System.Drawing.Point(3, 3);
            this.PBX.Name = "PBX";
            this.TLP.SetRowSpan(this.PBX, 4);
            this.PBX.Size = new System.Drawing.Size(408, 434);
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
            ((System.ComponentModel.ISupportInitialize)(this.PBX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.ListBox ListBoxNames;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Button BtnPrevious;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnDone;
        private System.Windows.Forms.PictureBox PBX;
    }
}