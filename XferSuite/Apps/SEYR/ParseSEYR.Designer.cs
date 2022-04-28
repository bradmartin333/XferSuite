namespace XferSuite.Apps.SEYR
{
    partial class ParseSEYR
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
            this.FormsPlot = new ScottPlot.FormsPlot();
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.TLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormsPlot
            // 
            this.FormsPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormsPlot.Location = new System.Drawing.Point(3, 52);
            this.FormsPlot.Name = "FormsPlot";
            this.FormsPlot.Size = new System.Drawing.Size(475, 442);
            this.FormsPlot.TabIndex = 0;
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 1;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.Controls.Add(this.FormsPlot, 0, 1);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 2;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.TLP.Size = new System.Drawing.Size(481, 497);
            this.TLP.TabIndex = 1;
            // 
            // ParseSEYR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 497);
            this.Controls.Add(this.TLP);
            this.Name = "ParseSEYR";
            this.Text = "ParseSEYR";
            this.TLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLP;
        private ScottPlot.FormsPlot FormsPlot;
    }
}