namespace XferSuite.AdvancedTools
{
    partial class DataFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataFilter));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Flow1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnSelectFile = new System.Windows.Forms.Button();
            this.LblFile = new System.Windows.Forms.Label();
            this.Flow2 = new System.Windows.Forms.FlowLayoutPanel();
            this.CbxHeaderRow = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboDelimeter = new System.Windows.Forms.ComboBox();
            this.Flow3 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnLoadData = new System.Windows.Forms.Button();
            this.LblData = new System.Windows.Forms.Label();
            this.Flow4 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.Flow1.SuspendLayout();
            this.Flow2.SuspendLayout();
            this.Flow3.SuspendLayout();
            this.Flow4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Flow1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Flow2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Flow3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Flow4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.RTB, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(521, 230);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Flow1
            // 
            this.Flow1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Flow1.AutoSize = true;
            this.Flow1.Controls.Add(this.BtnSelectFile);
            this.Flow1.Controls.Add(this.LblFile);
            this.Flow1.Location = new System.Drawing.Point(174, 3);
            this.Flow1.Name = "Flow1";
            this.Flow1.Size = new System.Drawing.Size(172, 29);
            this.Flow1.TabIndex = 0;
            // 
            // BtnSelectFile
            // 
            this.BtnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelectFile.BackColor = System.Drawing.Color.White;
            this.BtnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectFile.Location = new System.Drawing.Point(3, 3);
            this.BtnSelectFile.Name = "BtnSelectFile";
            this.BtnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.BtnSelectFile.TabIndex = 1;
            this.BtnSelectFile.Text = "Select File";
            this.BtnSelectFile.UseVisualStyleBackColor = false;
            this.BtnSelectFile.Click += new System.EventHandler(this.BtnSelectFile_Click);
            // 
            // LblFile
            // 
            this.LblFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblFile.AutoSize = true;
            this.LblFile.Location = new System.Drawing.Point(84, 8);
            this.LblFile.Name = "LblFile";
            this.LblFile.Size = new System.Drawing.Size(85, 13);
            this.LblFile.TabIndex = 0;
            this.LblFile.Text = "No File Selected";
            this.LblFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Flow2
            // 
            this.Flow2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Flow2.AutoSize = true;
            this.Flow2.Controls.Add(this.CbxHeaderRow);
            this.Flow2.Controls.Add(this.label2);
            this.Flow2.Controls.Add(this.ComboDelimeter);
            this.Flow2.Location = new System.Drawing.Point(98, 38);
            this.Flow2.Name = "Flow2";
            this.Flow2.Size = new System.Drawing.Size(325, 27);
            this.Flow2.TabIndex = 1;
            // 
            // CbxHeaderRow
            // 
            this.CbxHeaderRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxHeaderRow.AutoSize = true;
            this.CbxHeaderRow.Checked = true;
            this.CbxHeaderRow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxHeaderRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbxHeaderRow.Location = new System.Drawing.Point(3, 5);
            this.CbxHeaderRow.Name = "CbxHeaderRow";
            this.CbxHeaderRow.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.CbxHeaderRow.Size = new System.Drawing.Size(135, 17);
            this.CbxHeaderRow.TabIndex = 2;
            this.CbxHeaderRow.Text = "Has Header Row";
            this.CbxHeaderRow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CbxHeaderRow.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Delimeter";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComboDelimeter
            // 
            this.ComboDelimeter.FormattingEnabled = true;
            this.ComboDelimeter.Location = new System.Drawing.Point(201, 3);
            this.ComboDelimeter.Name = "ComboDelimeter";
            this.ComboDelimeter.Size = new System.Drawing.Size(121, 21);
            this.ComboDelimeter.TabIndex = 1;
            // 
            // Flow3
            // 
            this.Flow3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Flow3.AutoSize = true;
            this.Flow3.Controls.Add(this.BtnLoadData);
            this.Flow3.Controls.Add(this.LblData);
            this.Flow3.Location = new System.Drawing.Point(174, 71);
            this.Flow3.Name = "Flow3";
            this.Flow3.Size = new System.Drawing.Size(173, 29);
            this.Flow3.TabIndex = 3;
            // 
            // BtnLoadData
            // 
            this.BtnLoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLoadData.BackColor = System.Drawing.Color.White;
            this.BtnLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLoadData.Location = new System.Drawing.Point(3, 3);
            this.BtnLoadData.Name = "BtnLoadData";
            this.BtnLoadData.Size = new System.Drawing.Size(75, 23);
            this.BtnLoadData.TabIndex = 0;
            this.BtnLoadData.Text = "Load Data";
            this.BtnLoadData.UseVisualStyleBackColor = false;
            this.BtnLoadData.Click += new System.EventHandler(this.BtnLoadData_Click);
            // 
            // LblData
            // 
            this.LblData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblData.AutoSize = true;
            this.LblData.Location = new System.Drawing.Point(84, 8);
            this.LblData.Name = "LblData";
            this.LblData.Size = new System.Drawing.Size(86, 13);
            this.LblData.TabIndex = 1;
            this.LblData.Text = "No Data Loaded";
            this.LblData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Flow4
            // 
            this.Flow4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Flow4.AutoSize = true;
            this.Flow4.Controls.Add(this.BtnCopy);
            this.Flow4.Controls.Add(this.BtnSave);
            this.Flow4.Location = new System.Drawing.Point(179, 198);
            this.Flow4.Name = "Flow4";
            this.Flow4.Size = new System.Drawing.Size(162, 29);
            this.Flow4.TabIndex = 4;
            // 
            // BtnCopy
            // 
            this.BtnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCopy.BackColor = System.Drawing.Color.White;
            this.BtnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCopy.Location = new System.Drawing.Point(3, 3);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(75, 23);
            this.BtnCopy.TabIndex = 0;
            this.BtnCopy.Text = "Copy Data";
            this.BtnCopy.UseVisualStyleBackColor = false;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.BackColor = System.Drawing.Color.White;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Location = new System.Drawing.Point(84, 3);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "Save Data";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // RTB
            // 
            this.RTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB.Location = new System.Drawing.Point(3, 106);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(515, 86);
            this.RTB.TabIndex = 5;
            this.RTB.Text = "";
            // 
            // DataFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 230);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataFilter";
            this.Text = "Data Filter";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Flow1.ResumeLayout(false);
            this.Flow1.PerformLayout();
            this.Flow2.ResumeLayout(false);
            this.Flow2.PerformLayout();
            this.Flow3.ResumeLayout(false);
            this.Flow3.PerformLayout();
            this.Flow4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel Flow1;
        private System.Windows.Forms.Button BtnSelectFile;
        private System.Windows.Forms.Label LblFile;
        private System.Windows.Forms.FlowLayoutPanel Flow2;
        private System.Windows.Forms.CheckBox CbxHeaderRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboDelimeter;
        private System.Windows.Forms.FlowLayoutPanel Flow3;
        private System.Windows.Forms.Button BtnLoadData;
        private System.Windows.Forms.Label LblData;
        private System.Windows.Forms.FlowLayoutPanel Flow4;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.RichTextBox RTB;
    }
}