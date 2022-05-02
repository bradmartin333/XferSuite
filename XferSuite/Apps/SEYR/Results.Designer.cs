namespace XferSuite.Apps.SEYR
{
    partial class Results
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
            this.SuspendLayout();
            // 
            // FormsPlot
            // 
            this.FormsPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormsPlot.Location = new System.Drawing.Point(0, 0);
            this.FormsPlot.Name = "FormsPlot";
            this.FormsPlot.Size = new System.Drawing.Size(623, 533);
            this.FormsPlot.TabIndex = 0;
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 533);
            this.Controls.Add(this.FormsPlot);
            this.Name = "Results";
            this.Text = "Results";
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot FormsPlot;
    }
}