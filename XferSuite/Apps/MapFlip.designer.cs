
namespace XferSuite
{
    partial class MapFlip
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapFlip));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rtbIn = new System.Windows.Forms.RichTextBox();
            this.rtbOut = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInA = new System.Windows.Forms.Panel();
            this.pnlInB = new System.Windows.Forms.Panel();
            this.pnlInC = new System.Windows.Forms.Panel();
            this.pnlInD = new System.Windows.Forms.Panel();
            this.pnlOutA = new System.Windows.Forms.Panel();
            this.pnlOutB = new System.Windows.Forms.Panel();
            this.pnlOutC = new System.Windows.Forms.Panel();
            this.pnlOutD = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnHorizFlip = new System.Windows.Forms.Button();
            this.btnVertFlip = new System.Windows.Forms.Button();
            this.btnRotate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.rtbIn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtbOut, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 238F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(881, 238);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rtbIn
            // 
            this.rtbIn.AcceptsTab = true;
            this.rtbIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbIn.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.rtbIn.Location = new System.Drawing.Point(3, 3);
            this.rtbIn.Name = "rtbIn";
            this.rtbIn.Size = new System.Drawing.Size(287, 232);
            this.rtbIn.TabIndex = 0;
            this.rtbIn.Text = "";
            // 
            // rtbOut
            // 
            this.rtbOut.AcceptsTab = true;
            this.rtbOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOut.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.rtbOut.Location = new System.Drawing.Point(589, 3);
            this.rtbOut.Name = "rtbOut";
            this.rtbOut.Size = new System.Drawing.Size(289, 232);
            this.rtbOut.TabIndex = 1;
            this.rtbOut.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.pnlInA, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.pnlInB, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.pnlInC, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.pnlInD, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.pnlOutA, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.pnlOutB, 6, 2);
            this.tableLayoutPanel2.Controls.Add(this.pnlOutC, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.pnlOutD, 6, 3);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnGenerate, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnHorizFlip, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnVertFlip, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnRotate, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnReset, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(296, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(287, 232);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // pnlInA
            // 
            this.pnlInA.BackColor = System.Drawing.Color.Green;
            this.pnlInA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlInA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInA.Location = new System.Drawing.Point(3, 95);
            this.pnlInA.Name = "pnlInA";
            this.pnlInA.Size = new System.Drawing.Size(44, 40);
            this.pnlInA.TabIndex = 0;
            // 
            // pnlInB
            // 
            this.pnlInB.BackColor = System.Drawing.Color.Red;
            this.pnlInB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlInB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInB.Location = new System.Drawing.Point(53, 95);
            this.pnlInB.Name = "pnlInB";
            this.pnlInB.Size = new System.Drawing.Size(44, 40);
            this.pnlInB.TabIndex = 1;
            // 
            // pnlInC
            // 
            this.pnlInC.BackColor = System.Drawing.Color.Yellow;
            this.pnlInC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlInC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInC.Location = new System.Drawing.Point(3, 141);
            this.pnlInC.Name = "pnlInC";
            this.pnlInC.Size = new System.Drawing.Size(44, 40);
            this.pnlInC.TabIndex = 2;
            // 
            // pnlInD
            // 
            this.pnlInD.BackColor = System.Drawing.Color.Blue;
            this.pnlInD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlInD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInD.Location = new System.Drawing.Point(53, 141);
            this.pnlInD.Name = "pnlInD";
            this.pnlInD.Size = new System.Drawing.Size(44, 40);
            this.pnlInD.TabIndex = 3;
            // 
            // pnlOutA
            // 
            this.pnlOutA.BackColor = System.Drawing.Color.Red;
            this.pnlOutA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOutA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOutA.Location = new System.Drawing.Point(187, 95);
            this.pnlOutA.Name = "pnlOutA";
            this.pnlOutA.Size = new System.Drawing.Size(44, 40);
            this.pnlOutA.TabIndex = 4;
            this.pnlOutA.Tag = "";
            // 
            // pnlOutB
            // 
            this.pnlOutB.BackColor = System.Drawing.Color.Green;
            this.pnlOutB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOutB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOutB.Location = new System.Drawing.Point(237, 95);
            this.pnlOutB.Name = "pnlOutB";
            this.pnlOutB.Size = new System.Drawing.Size(47, 40);
            this.pnlOutB.TabIndex = 5;
            // 
            // pnlOutC
            // 
            this.pnlOutC.BackColor = System.Drawing.Color.Blue;
            this.pnlOutC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOutC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOutC.Location = new System.Drawing.Point(187, 141);
            this.pnlOutC.Name = "pnlOutC";
            this.pnlOutC.Size = new System.Drawing.Size(44, 40);
            this.pnlOutC.TabIndex = 6;
            // 
            // pnlOutD
            // 
            this.pnlOutD.BackColor = System.Drawing.Color.Yellow;
            this.pnlOutD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOutD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOutD.Location = new System.Drawing.Point(237, 141);
            this.pnlOutD.Name = "pnlOutD";
            this.pnlOutD.Size = new System.Drawing.Size(47, 40);
            this.pnlOutD.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "In";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 2);
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(187, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Out";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.AutoSize = true;
            this.btnGenerate.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.SetColumnSpan(this.btnGenerate, 3);
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Location = new System.Drawing.Point(103, 193);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(78, 29);
            this.btnGenerate.TabIndex = 10;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnHorizFlip
            // 
            this.btnHorizFlip.BackColor = System.Drawing.SystemColors.Control;
            this.btnHorizFlip.BackgroundImage = global::XferSuite.Properties.Resources.horizFlip;
            this.btnHorizFlip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHorizFlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHorizFlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHorizFlip.Location = new System.Drawing.Point(120, 49);
            this.btnHorizFlip.Name = "btnHorizFlip";
            this.btnHorizFlip.Size = new System.Drawing.Size(44, 40);
            this.btnHorizFlip.TabIndex = 11;
            this.btnHorizFlip.UseVisualStyleBackColor = false;
            this.btnHorizFlip.Click += new System.EventHandler(this.btnHorizFlip_Click);
            // 
            // btnVertFlip
            // 
            this.btnVertFlip.BackColor = System.Drawing.SystemColors.Control;
            this.btnVertFlip.BackgroundImage = global::XferSuite.Properties.Resources.vertFlip;
            this.btnVertFlip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVertFlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVertFlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVertFlip.Location = new System.Drawing.Point(120, 95);
            this.btnVertFlip.Name = "btnVertFlip";
            this.btnVertFlip.Size = new System.Drawing.Size(44, 40);
            this.btnVertFlip.TabIndex = 12;
            this.btnVertFlip.UseVisualStyleBackColor = false;
            this.btnVertFlip.Click += new System.EventHandler(this.btnVertFlip_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.BackColor = System.Drawing.SystemColors.Control;
            this.btnRotate.BackgroundImage = global::XferSuite.Properties.Resources.rotateArrow;
            this.btnRotate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRotate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotate.Location = new System.Drawing.Point(120, 141);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(44, 40);
            this.btnRotate.TabIndex = 13;
            this.btnRotate.UseVisualStyleBackColor = false;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.AutoSize = true;
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.SetColumnSpan(this.btnReset, 3);
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(103, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(78, 29);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // MapFlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(881, 238);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapFlip";
            this.Text = "MapFlip";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox rtbIn;
        private System.Windows.Forms.RichTextBox rtbOut;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pnlInA;
        private System.Windows.Forms.Panel pnlInB;
        private System.Windows.Forms.Panel pnlInC;
        private System.Windows.Forms.Panel pnlInD;
        private System.Windows.Forms.Panel pnlOutA;
        private System.Windows.Forms.Panel pnlOutB;
        private System.Windows.Forms.Panel pnlOutC;
        private System.Windows.Forms.Panel pnlOutD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnHorizFlip;
        private System.Windows.Forms.Button btnVertFlip;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.Button btnReset;
    }
}

