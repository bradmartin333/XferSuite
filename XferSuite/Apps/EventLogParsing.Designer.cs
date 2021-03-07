
namespace XferSuite
{
    partial class EventLogParsing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventLogParsing));
            this.rtbPrints = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rtbMain = new System.Windows.Forms.RichTextBox();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbPrints
            // 
            this.rtbPrints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPrints.Location = new System.Drawing.Point(2, 355);
            this.rtbPrints.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtbPrints.Name = "rtbPrints";
            this.rtbPrints.Size = new System.Drawing.Size(494, 139);
            this.rtbPrints.TabIndex = 0;
            this.rtbPrints.Text = "Print List:\n";
            this.rtbPrints.WordWrap = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.rtbPrints, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rtbMain, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDateRange, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(498, 496);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // rtbMain
            // 
            this.rtbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMain.Location = new System.Drawing.Point(3, 23);
            this.rtbMain.Name = "rtbMain";
            this.rtbMain.Size = new System.Drawing.Size(492, 327);
            this.rtbMain.TabIndex = 1;
            this.rtbMain.Text = "";
            this.rtbMain.WordWrap = false;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateRange.Location = new System.Drawing.Point(3, 0);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(492, 20);
            this.lblDateRange.TabIndex = 2;
            this.lblDateRange.Text = "Start Date - End Date";
            this.lblDateRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventLogParsing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 496);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EventLogParsing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Event Log Parsing";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox rtbPrints;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox rtbMain;
        private System.Windows.Forms.Label lblDateRange;
    }
}