
using System.Windows.Forms;

namespace XferSuite
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnLegal = new System.Windows.Forms.Button();
            this.btnCheckForUpdates = new System.Windows.Forms.Button();
            this.btnViewDocs = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(2, 31);
            this.propertyGrid.Margin = new System.Windows.Forms.Padding(2);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid.Size = new System.Drawing.Size(358, 365);
            this.propertyGrid.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.btnViewDocs, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.btnLegal, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.propertyGrid, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.btnCheckForUpdates, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(362, 456);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // btnLegal
            // 
            this.btnLegal.BackColor = System.Drawing.Color.White;
            this.btnLegal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLegal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLegal.Location = new System.Drawing.Point(3, 430);
            this.btnLegal.Name = "btnLegal";
            this.btnLegal.Size = new System.Drawing.Size(356, 23);
            this.btnLegal.TabIndex = 2;
            this.btnLegal.Text = "View License";
            this.btnLegal.UseVisualStyleBackColor = false;
            this.btnLegal.Click += new System.EventHandler(this.btnViewLicense_Click);
            // 
            // btnCheckForUpdates
            // 
            this.btnCheckForUpdates.BackColor = System.Drawing.Color.White;
            this.btnCheckForUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheckForUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckForUpdates.Location = new System.Drawing.Point(3, 3);
            this.btnCheckForUpdates.Name = "btnCheckForUpdates";
            this.btnCheckForUpdates.Size = new System.Drawing.Size(356, 23);
            this.btnCheckForUpdates.TabIndex = 1;
            this.btnCheckForUpdates.Text = "Check For Updates";
            this.btnCheckForUpdates.UseVisualStyleBackColor = false;
            this.btnCheckForUpdates.Click += new System.EventHandler(this.btnCheckForUpdates_Click);
            // 
            // btnViewDocs
            // 
            this.btnViewDocs.BackColor = System.Drawing.Color.White;
            this.btnViewDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnViewDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDocs.Location = new System.Drawing.Point(3, 401);
            this.btnViewDocs.Name = "btnViewDocs";
            this.btnViewDocs.Size = new System.Drawing.Size(356, 23);
            this.btnViewDocs.TabIndex = 3;
            this.btnViewDocs.Text = "Documentation";
            this.btnViewDocs.UseVisualStyleBackColor = false;
            this.btnViewDocs.Click += new System.EventHandler(this.btnViewDocs_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 456);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Settings";
            this.Text = "Settings";
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public PropertyGrid propertyGrid;
        private TableLayoutPanel tableLayoutPanel;
        private Button btnCheckForUpdates;
        private Button btnLegal;
        private Button btnViewDocs;
    }
}