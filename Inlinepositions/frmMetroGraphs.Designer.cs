
namespace Inlinepositions
{
    partial class frmMetroGraphs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMetroGraphs));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Combo = new System.Windows.Forms.TabPage();
            this.ComboPlot = new ScottPlot.FormsPlot();
            this.XError = new System.Windows.Forms.TabPage();
            this.XErrorPlot = new ScottPlot.FormsPlot();
            this.YError = new System.Windows.Forms.TabPage();
            this.YErrorPlot = new ScottPlot.FormsPlot();
            this.XStdDev = new System.Windows.Forms.TabPage();
            this.XStdDevPlot = new ScottPlot.FormsPlot();
            this.YStdDev = new System.Windows.Forms.TabPage();
            this.YStdDevPlot = new ScottPlot.FormsPlot();
            this.XYScatter = new System.Windows.Forms.TabPage();
            this.XYDist = new System.Windows.Forms.TabPage();
            this.XYScatterPlot = new ScottPlot.FormsPlot();
            this.XYDistPlot = new ScottPlot.FormsPlot();
            this.tabControl.SuspendLayout();
            this.Combo.SuspendLayout();
            this.XError.SuspendLayout();
            this.YError.SuspendLayout();
            this.XStdDev.SuspendLayout();
            this.YStdDev.SuspendLayout();
            this.XYScatter.SuspendLayout();
            this.XYDist.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.XYScatter);
            this.tabControl.Controls.Add(this.XYDist);
            this.tabControl.Controls.Add(this.Combo);
            this.tabControl.Controls.Add(this.XError);
            this.tabControl.Controls.Add(this.YError);
            this.tabControl.Controls.Add(this.XStdDev);
            this.tabControl.Controls.Add(this.YStdDev);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // Combo
            // 
            this.Combo.Controls.Add(this.ComboPlot);
            this.Combo.Location = new System.Drawing.Point(4, 22);
            this.Combo.Name = "Combo";
            this.Combo.Size = new System.Drawing.Size(792, 424);
            this.Combo.TabIndex = 2;
            this.Combo.Text = "Combo";
            this.Combo.UseVisualStyleBackColor = true;
            // 
            // ComboPlot
            // 
            this.ComboPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboPlot.Location = new System.Drawing.Point(0, 0);
            this.ComboPlot.Name = "ComboPlot";
            this.ComboPlot.Size = new System.Drawing.Size(792, 424);
            this.ComboPlot.TabIndex = 0;
            // 
            // XError
            // 
            this.XError.Controls.Add(this.XErrorPlot);
            this.XError.Location = new System.Drawing.Point(4, 22);
            this.XError.Name = "XError";
            this.XError.Size = new System.Drawing.Size(792, 424);
            this.XError.TabIndex = 3;
            this.XError.Text = "X Error";
            this.XError.UseVisualStyleBackColor = true;
            // 
            // XErrorPlot
            // 
            this.XErrorPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XErrorPlot.Location = new System.Drawing.Point(0, 0);
            this.XErrorPlot.Name = "XErrorPlot";
            this.XErrorPlot.Size = new System.Drawing.Size(792, 424);
            this.XErrorPlot.TabIndex = 0;
            // 
            // YError
            // 
            this.YError.Controls.Add(this.YErrorPlot);
            this.YError.Location = new System.Drawing.Point(4, 22);
            this.YError.Name = "YError";
            this.YError.Size = new System.Drawing.Size(792, 424);
            this.YError.TabIndex = 4;
            this.YError.Text = "Y Error";
            this.YError.UseVisualStyleBackColor = true;
            // 
            // YErrorPlot
            // 
            this.YErrorPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YErrorPlot.Location = new System.Drawing.Point(0, 0);
            this.YErrorPlot.Name = "YErrorPlot";
            this.YErrorPlot.Size = new System.Drawing.Size(792, 424);
            this.YErrorPlot.TabIndex = 0;
            // 
            // XStdDev
            // 
            this.XStdDev.Controls.Add(this.XStdDevPlot);
            this.XStdDev.Location = new System.Drawing.Point(4, 22);
            this.XStdDev.Name = "XStdDev";
            this.XStdDev.Size = new System.Drawing.Size(792, 424);
            this.XStdDev.TabIndex = 5;
            this.XStdDev.Text = "X StdDev";
            this.XStdDev.UseVisualStyleBackColor = true;
            // 
            // XStdDevPlot
            // 
            this.XStdDevPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XStdDevPlot.Location = new System.Drawing.Point(0, 0);
            this.XStdDevPlot.Name = "XStdDevPlot";
            this.XStdDevPlot.Size = new System.Drawing.Size(792, 424);
            this.XStdDevPlot.TabIndex = 0;
            // 
            // YStdDev
            // 
            this.YStdDev.Controls.Add(this.YStdDevPlot);
            this.YStdDev.Location = new System.Drawing.Point(4, 22);
            this.YStdDev.Name = "YStdDev";
            this.YStdDev.Size = new System.Drawing.Size(792, 424);
            this.YStdDev.TabIndex = 6;
            this.YStdDev.Text = "Y StdDev";
            this.YStdDev.UseVisualStyleBackColor = true;
            // 
            // YStdDevPlot
            // 
            this.YStdDevPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YStdDevPlot.Location = new System.Drawing.Point(0, 0);
            this.YStdDevPlot.Name = "YStdDevPlot";
            this.YStdDevPlot.Size = new System.Drawing.Size(792, 424);
            this.YStdDevPlot.TabIndex = 0;
            // 
            // XYScatter
            // 
            this.XYScatter.Controls.Add(this.XYScatterPlot);
            this.XYScatter.Location = new System.Drawing.Point(4, 22);
            this.XYScatter.Name = "XYScatter";
            this.XYScatter.Size = new System.Drawing.Size(792, 424);
            this.XYScatter.TabIndex = 7;
            this.XYScatter.Text = "XY Scatter";
            this.XYScatter.UseVisualStyleBackColor = true;
            // 
            // XYDist
            // 
            this.XYDist.Controls.Add(this.XYDistPlot);
            this.XYDist.Location = new System.Drawing.Point(4, 22);
            this.XYDist.Name = "XYDist";
            this.XYDist.Size = new System.Drawing.Size(792, 424);
            this.XYDist.TabIndex = 8;
            this.XYDist.Text = "XY Distribution";
            this.XYDist.UseVisualStyleBackColor = true;
            // 
            // XYScatterPlot
            // 
            this.XYScatterPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XYScatterPlot.Location = new System.Drawing.Point(0, 0);
            this.XYScatterPlot.Name = "XYScatterPlot";
            this.XYScatterPlot.Size = new System.Drawing.Size(792, 424);
            this.XYScatterPlot.TabIndex = 0;
            // 
            // XYDistPlot
            // 
            this.XYDistPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XYDistPlot.Location = new System.Drawing.Point(0, 0);
            this.XYDistPlot.Name = "XYDistPlot";
            this.XYDistPlot.Size = new System.Drawing.Size(792, 424);
            this.XYDistPlot.TabIndex = 0;
            // 
            // frmMetroGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMetroGraphs";
            this.Text = "File Name";
            this.Load += new System.EventHandler(this.frmMetroGraphs_Load);
            this.tabControl.ResumeLayout(false);
            this.Combo.ResumeLayout(false);
            this.XError.ResumeLayout(false);
            this.YError.ResumeLayout(false);
            this.XStdDev.ResumeLayout(false);
            this.YStdDev.ResumeLayout(false);
            this.XYScatter.ResumeLayout(false);
            this.XYDist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Combo;
        private ScottPlot.FormsPlot ComboPlot;
        private System.Windows.Forms.TabPage XError;
        private ScottPlot.FormsPlot XErrorPlot;
        private System.Windows.Forms.TabPage YError;
        private ScottPlot.FormsPlot YErrorPlot;
        private System.Windows.Forms.TabPage XStdDev;
        private ScottPlot.FormsPlot XStdDevPlot;
        private System.Windows.Forms.TabPage YStdDev;
        private ScottPlot.FormsPlot YStdDevPlot;
        private System.Windows.Forms.TabPage XYScatter;
        private ScottPlot.FormsPlot XYScatterPlot;
        private System.Windows.Forms.TabPage XYDist;
        private ScottPlot.FormsPlot XYDistPlot;
    }
}

