namespace XferSuite.Apps.SEYR
{
    partial class CreateCustom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateCustom));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.numOffsetX = new System.Windows.Forms.NumericUpDown();
            this.numOffsetY = new System.Windows.Forms.NumericUpDown();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.panelColor = new System.Windows.Forms.Panel();
            this.numSize = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioAND = new System.Windows.Forms.RadioButton();
            this.radioOR = new System.Windows.Forms.RadioButton();
            this.Feature = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Criteria = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.radioXOR = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanel2, 1, 7);
            this.tableLayoutPanel.Controls.Add(this.label2, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.label4, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.label5, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.comboBoxType, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.numOffsetX, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.numOffsetY, 2, 5);
            this.tableLayoutPanel.Controls.Add(this.dataGridView, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 1, 8);
            this.tableLayoutPanel.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.txtName, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.labelColor, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.panelColor, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.numSize, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 9;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(385, 277);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(212, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "Size";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.flowLayoutPanel2, 2);
            this.flowLayoutPanel2.Controls.Add(this.btnSaveAs);
            this.flowLayoutPanel2.Controls.Add(this.btnHide);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(221, 206);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(152, 31);
            this.flowLayoutPanel2.TabIndex = 12;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.BackColor = System.Drawing.Color.White;
            this.btnSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAs.Location = new System.Drawing.Point(3, 3);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(70, 25);
            this.btnSaveAs.TabIndex = 2;
            this.btnSaveAs.Text = "Save";
            this.btnSaveAs.UseVisualStyleBackColor = false;
            this.btnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
            // 
            // btnHide
            // 
            this.btnHide.BackColor = System.Drawing.Color.White;
            this.btnHide.Enabled = false;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.Location = new System.Drawing.Point(79, 3);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(70, 25);
            this.btnHide.TabIndex = 3;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.BtnHide_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(212, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(212, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Offset X (mm)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(212, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Offset Y (mm)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxType
            // 
            this.comboBoxType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "Null"});
            this.comboBoxType.Location = new System.Drawing.Point(288, 92);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(94, 21);
            this.comboBoxType.TabIndex = 6;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxType_SelectedIndexChanged);
            // 
            // numOffsetX
            // 
            this.numOffsetX.DecimalPlaces = 3;
            this.numOffsetX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numOffsetX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numOffsetX.Location = new System.Drawing.Point(288, 119);
            this.numOffsetX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numOffsetX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numOffsetX.Name = "numOffsetX";
            this.numOffsetX.Size = new System.Drawing.Size(94, 20);
            this.numOffsetX.TabIndex = 8;
            this.numOffsetX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numOffsetY
            // 
            this.numOffsetY.DecimalPlaces = 3;
            this.numOffsetY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numOffsetY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numOffsetY.Location = new System.Drawing.Point(288, 145);
            this.numOffsetY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numOffsetY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numOffsetY.Name = "numOffsetY";
            this.numOffsetY.Size = new System.Drawing.Size(94, 20);
            this.numOffsetY.TabIndex = 9;
            this.numOffsetY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Feature,
            this.Criteria});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView.Location = new System.Drawing.Point(3, 40);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.tableLayoutPanel.SetRowSpan(this.dataGridView, 8);
            this.dataGridView.Size = new System.Drawing.Size(203, 234);
            this.dataGridView.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.btnConfirm);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(221, 243);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(152, 31);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.LightGreen;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Location = new System.Drawing.Point(3, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(70, 25);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(79, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(212, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 37);
            this.label6.TabIndex = 13;
            this.label6.Text = "Name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(288, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(94, 20);
            this.txtName.TabIndex = 14;
            this.txtName.Text = "Custom";
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelColor.Location = new System.Drawing.Point(212, 37);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(70, 26);
            this.labelColor.TabIndex = 15;
            this.labelColor.Text = "Color";
            this.labelColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelColor
            // 
            this.panelColor.BackColor = System.Drawing.Color.Blue;
            this.panelColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelColor.Location = new System.Drawing.Point(288, 40);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(94, 20);
            this.panelColor.TabIndex = 17;
            // 
            // numSize
            // 
            this.numSize.Location = new System.Drawing.Point(288, 66);
            this.numSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSize.Name = "numSize";
            this.numSize.Size = new System.Drawing.Size(94, 20);
            this.numSize.TabIndex = 18;
            this.numSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteRowToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(134, 26);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.DeleteRowToolStripMenuItem_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.radioAND);
            this.flowLayoutPanel3.Controls.Add(this.radioOR);
            this.flowLayoutPanel3.Controls.Add(this.radioXOR);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(32, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(144, 31);
            this.flowLayoutPanel3.TabIndex = 19;
            // 
            // radioAND
            // 
            this.radioAND.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioAND.Checked = true;
            this.radioAND.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightBlue;
            this.radioAND.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioAND.Location = new System.Drawing.Point(3, 3);
            this.radioAND.Name = "radioAND";
            this.radioAND.Size = new System.Drawing.Size(42, 25);
            this.radioAND.TabIndex = 0;
            this.radioAND.TabStop = true;
            this.radioAND.Text = "AND";
            this.radioAND.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioAND.UseVisualStyleBackColor = true;
            // 
            // radioOR
            // 
            this.radioOR.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioOR.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightBlue;
            this.radioOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioOR.Location = new System.Drawing.Point(51, 3);
            this.radioOR.Name = "radioOR";
            this.radioOR.Size = new System.Drawing.Size(42, 25);
            this.radioOR.TabIndex = 1;
            this.radioOR.Text = "OR";
            this.radioOR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioOR.UseVisualStyleBackColor = true;
            // 
            // Feature
            // 
            this.Feature.HeaderText = "Feature";
            this.Feature.Name = "Feature";
            // 
            // Criteria
            // 
            this.Criteria.HeaderText = "Criteria";
            this.Criteria.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "Null",
            "Misaligned"});
            this.Criteria.Name = "Criteria";
            // 
            // radioXOR
            // 
            this.radioXOR.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioXOR.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightBlue;
            this.radioXOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioXOR.Location = new System.Drawing.Point(99, 3);
            this.radioXOR.Name = "radioXOR";
            this.radioXOR.Size = new System.Drawing.Size(42, 25);
            this.radioXOR.TabIndex = 3;
            this.radioXOR.Text = "XOR";
            this.radioXOR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioXOR.UseVisualStyleBackColor = true;
            // 
            // CreateCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 277);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateCustom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Custom SEYR Feature";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox comboBoxType;
        public System.Windows.Forms.NumericUpDown numOffsetX;
        public System.Windows.Forms.NumericUpDown numOffsetY;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panelColor;
        public System.Windows.Forms.NumericUpDown numSize;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.DataGridViewComboBoxColumn Feature;
        private System.Windows.Forms.DataGridViewComboBoxColumn Criteria;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.RadioButton radioAND;
        private System.Windows.Forms.RadioButton radioOR;
        private System.Windows.Forms.RadioButton radioXOR;
    }
}