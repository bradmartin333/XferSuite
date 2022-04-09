
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
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtnCheckForUpdates = new System.Windows.Forms.Button();
            this.BtnLegal = new System.Windows.Forms.Button();
            this.BtnViewDocs = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PropertyGrid
            // 
            this.tableLayoutPanel.SetColumnSpan(this.PropertyGrid, 2);
            this.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid.Location = new System.Drawing.Point(2, 31);
            this.PropertyGrid.Margin = new System.Windows.Forms.Padding(2);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.PropertyGrid.Size = new System.Drawing.Size(358, 394);
            this.PropertyGrid.TabIndex = 0;
            this.PropertyGrid.ToolbarVisible = false;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.BtnViewDocs, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.BtnLegal, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.PropertyGrid, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.BtnCheckForUpdates, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(362, 456);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // BtnCheckForUpdates
            // 
            this.BtnCheckForUpdates.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel.SetColumnSpan(this.BtnCheckForUpdates, 2);
            this.BtnCheckForUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCheckForUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCheckForUpdates.Location = new System.Drawing.Point(3, 3);
            this.BtnCheckForUpdates.Name = "BtnCheckForUpdates";
            this.BtnCheckForUpdates.Size = new System.Drawing.Size(356, 23);
            this.BtnCheckForUpdates.TabIndex = 1;
            this.BtnCheckForUpdates.Text = "Check For Updates";
            this.BtnCheckForUpdates.UseVisualStyleBackColor = false;
            this.BtnCheckForUpdates.Click += new System.EventHandler(this.BtnCheckForUpdates_Click);
            // 
            // BtnLegal
            // 
            this.BtnLegal.BackColor = System.Drawing.Color.White;
            this.BtnLegal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLegal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLegal.Location = new System.Drawing.Point(184, 430);
            this.BtnLegal.Name = "BtnLegal";
            this.BtnLegal.Size = new System.Drawing.Size(175, 23);
            this.BtnLegal.TabIndex = 2;
            this.BtnLegal.Text = "View License";
            this.BtnLegal.UseVisualStyleBackColor = false;
            this.BtnLegal.Click += new System.EventHandler(this.BtnViewLicense_Click);
            // 
            // BtnViewDocs
            // 
            this.BtnViewDocs.BackColor = System.Drawing.Color.White;
            this.BtnViewDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnViewDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnViewDocs.Location = new System.Drawing.Point(3, 430);
            this.BtnViewDocs.Name = "BtnViewDocs";
            this.BtnViewDocs.Size = new System.Drawing.Size(175, 23);
            this.BtnViewDocs.TabIndex = 3;
            this.BtnViewDocs.Text = "Documentation";
            this.BtnViewDocs.UseVisualStyleBackColor = false;
            this.BtnViewDocs.Click += new System.EventHandler(this.BtnViewDocs_Click);
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

        public PropertyGrid PropertyGrid;
        private TableLayoutPanel tableLayoutPanel;
        private Button BtnCheckForUpdates;
        private Button BtnViewDocs;
        private Button BtnLegal;
    }
}