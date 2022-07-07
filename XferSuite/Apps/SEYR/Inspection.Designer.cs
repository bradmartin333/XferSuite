namespace XferSuite.Apps.SEYR
{
    partial class Inspection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inspection));
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.BtnViewDistribution = new System.Windows.Forms.Button();
            this.PBX = new System.Windows.Forms.PictureBox();
            this.LblInfo = new System.Windows.Forms.Label();
            this.CBX = new System.Windows.Forms.CheckBox();
            this.BtnParserMenu = new System.Windows.Forms.Button();
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.TLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 3;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLP.Controls.Add(this.BtnViewDistribution, 1, 2);
            this.TLP.Controls.Add(this.PBX, 0, 0);
            this.TLP.Controls.Add(this.LblInfo, 0, 1);
            this.TLP.Controls.Add(this.CBX, 0, 2);
            this.TLP.Controls.Add(this.BtnParserMenu, 2, 2);
            this.TLP.Controls.Add(this.RTB, 0, 3);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 4;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.Size = new System.Drawing.Size(484, 461);
            this.TLP.TabIndex = 0;
            // 
            // BtnViewDistribution
            // 
            this.BtnViewDistribution.AutoSize = true;
            this.BtnViewDistribution.BackColor = System.Drawing.Color.White;
            this.BtnViewDistribution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnViewDistribution.Location = new System.Drawing.Point(317, 331);
            this.BtnViewDistribution.Name = "BtnViewDistribution";
            this.BtnViewDistribution.Size = new System.Drawing.Size(79, 25);
            this.BtnViewDistribution.TabIndex = 4;
            this.BtnViewDistribution.Text = "Show Data";
            this.BtnViewDistribution.UseVisualStyleBackColor = false;
            this.BtnViewDistribution.Click += new System.EventHandler(this.BtnShowData_Click);
            // 
            // PBX
            // 
            this.PBX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TLP.SetColumnSpan(this.PBX, 3);
            this.PBX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PBX.Location = new System.Drawing.Point(3, 3);
            this.PBX.Name = "PBX";
            this.PBX.Size = new System.Drawing.Size(478, 289);
            this.PBX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBX.TabIndex = 0;
            this.PBX.TabStop = false;
            this.PBX.Click += new System.EventHandler(this.PBX_Click);
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.TLP.SetColumnSpan(this.LblInfo, 3);
            this.LblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblInfo.Location = new System.Drawing.Point(3, 295);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.LblInfo.Size = new System.Drawing.Size(478, 33);
            this.LblInfo.TabIndex = 1;
            this.LblInfo.Text = "N/A";
            this.LblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CBX
            // 
            this.CBX.Appearance = System.Windows.Forms.Appearance.Button;
            this.CBX.AutoSize = true;
            this.CBX.BackColor = System.Drawing.Color.LightCoral;
            this.CBX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBX.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.CBX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBX.Location = new System.Drawing.Point(3, 331);
            this.CBX.Name = "CBX";
            this.CBX.Size = new System.Drawing.Size(308, 25);
            this.CBX.TabIndex = 2;
            this.CBX.Text = "Fail";
            this.CBX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CBX.UseVisualStyleBackColor = false;
            this.CBX.CheckedChanged += new System.EventHandler(this.CBX_CheckedChanged);
            // 
            // BtnParserMenu
            // 
            this.BtnParserMenu.AutoSize = true;
            this.BtnParserMenu.BackColor = System.Drawing.Color.White;
            this.BtnParserMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnParserMenu.Location = new System.Drawing.Point(402, 331);
            this.BtnParserMenu.Name = "BtnParserMenu";
            this.BtnParserMenu.Size = new System.Drawing.Size(79, 25);
            this.BtnParserMenu.TabIndex = 3;
            this.BtnParserMenu.Text = "Parser Menu";
            this.BtnParserMenu.UseVisualStyleBackColor = false;
            this.BtnParserMenu.Click += new System.EventHandler(this.BtnParserMenu_Click);
            // 
            // RTB
            // 
            this.TLP.SetColumnSpan(this.RTB, 3);
            this.RTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTB.Location = new System.Drawing.Point(3, 362);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(478, 96);
            this.RTB.TabIndex = 5;
            this.RTB.Text = "";
            this.RTB.Visible = false;
            // 
            // Inspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.TLP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Inspection";
            this.Text = "Inspection";
            this.TLP.ResumeLayout(false);
            this.TLP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.PictureBox PBX;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.CheckBox CBX;
        private System.Windows.Forms.Button BtnParserMenu;
        private System.Windows.Forms.Button BtnViewDistribution;
        private System.Windows.Forms.RichTextBox RTB;
    }
}