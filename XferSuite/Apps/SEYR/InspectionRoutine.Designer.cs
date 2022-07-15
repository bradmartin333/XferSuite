﻿namespace XferSuite.Apps.SEYR
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
            this.BtnPrevious = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.BtnDone = new System.Windows.Forms.Button();
            this.PBX = new System.Windows.Forms.PictureBox();
            this.LabelCounter = new System.Windows.Forms.Label();
            this.OLV = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.TLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OLV)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 4;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.TLP.Controls.Add(this.BtnPrevious, 1, 2);
            this.TLP.Controls.Add(this.BtnNext, 3, 2);
            this.TLP.Controls.Add(this.TextBoxName, 1, 1);
            this.TLP.Controls.Add(this.BtnDone, 1, 3);
            this.TLP.Controls.Add(this.PBX, 0, 0);
            this.TLP.Controls.Add(this.LabelCounter, 2, 2);
            this.TLP.Controls.Add(this.OLV, 1, 0);
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
            // BtnPrevious
            // 
            this.BtnPrevious.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnPrevious.BackgroundImage")));
            this.BtnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPrevious.FlatAppearance.BorderSize = 0;
            this.BtnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrevious.Location = new System.Drawing.Point(423, 381);
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(39, 23);
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
            this.BtnNext.Location = new System.Drawing.Point(603, 381);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(41, 23);
            this.BtnNext.TabIndex = 1;
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // TextBoxName
            // 
            this.TLP.SetColumnSpan(this.TextBoxName, 3);
            this.TextBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxName.Location = new System.Drawing.Point(423, 355);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(221, 20);
            this.TextBoxName.TabIndex = 4;
            this.TextBoxName.Text = "null";
            this.TextBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // BtnDone
            // 
            this.BtnDone.BackColor = System.Drawing.Color.White;
            this.TLP.SetColumnSpan(this.BtnDone, 3);
            this.BtnDone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDone.Location = new System.Drawing.Point(423, 414);
            this.BtnDone.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.BtnDone.Name = "BtnDone";
            this.BtnDone.Size = new System.Drawing.Size(221, 23);
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
            this.PBX.Size = new System.Drawing.Size(414, 434);
            this.PBX.TabIndex = 6;
            this.PBX.TabStop = false;
            // 
            // LabelCounter
            // 
            this.LabelCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelCounter.Location = new System.Drawing.Point(468, 378);
            this.LabelCounter.Name = "LabelCounter";
            this.LabelCounter.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.LabelCounter.Size = new System.Drawing.Size(129, 29);
            this.LabelCounter.TabIndex = 7;
            this.LabelCounter.Text = "N/A";
            this.LabelCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OLV
            // 
            this.OLV.AllColumns.Add(this.olvColumn1);
            this.OLV.AllColumns.Add(this.olvColumn2);
            this.OLV.CellEditUseWholeCell = false;
            this.OLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2});
            this.TLP.SetColumnSpan(this.OLV, 3);
            this.OLV.Cursor = System.Windows.Forms.Cursors.Default;
            this.OLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OLV.FullRowSelect = true;
            this.OLV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.OLV.HideSelection = false;
            this.OLV.Location = new System.Drawing.Point(423, 3);
            this.OLV.Name = "OLV";
            this.OLV.SelectAllOnControlA = false;
            this.OLV.SelectedBackColor = System.Drawing.Color.LightBlue;
            this.OLV.ShowGroups = false;
            this.OLV.Size = new System.Drawing.Size(221, 346);
            this.OLV.TabIndex = 8;
            this.OLV.UnfocusedSelectedBackColor = System.Drawing.Color.LightBlue;
            this.OLV.UseCompatibleStateImageBehavior = false;
            this.OLV.View = System.Windows.Forms.View.Details;
            this.OLV.SelectedIndexChanged += new System.EventHandler(this.OLV_SelectedIndexChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Index";
            this.olvColumn1.AspectToStringFormat = "{0}";
            this.olvColumn1.Text = "Index";
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Message";
            this.olvColumn2.FillsFreeSpace = true;
            this.olvColumn2.Text = "Fail Reason";
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
            ((System.ComponentModel.ISupportInitialize)(this.OLV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Button BtnPrevious;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnDone;
        private System.Windows.Forms.PictureBox PBX;
        private System.Windows.Forms.Label LabelCounter;
        private BrightIdeasSoftware.ObjectListView OLV;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
    }
}