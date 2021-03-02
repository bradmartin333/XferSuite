
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
            this.XYScatter = new System.Windows.Forms.TabPage();
            this.XYScatterPlot = new ScottPlot.FormsPlot();
            this.XYDist = new System.Windows.Forms.TabPage();
            this.XYDistPlot = new ScottPlot.FormsPlot();
            this.Yield = new System.Windows.Forms.TabPage();
            this.YieldPlot = new ScottPlot.FormsPlot();
            this.XError = new System.Windows.Forms.TabPage();
            this.XErrorPlot = new ScottPlot.FormsPlot();
            this.YError = new System.Windows.Forms.TabPage();
            this.YErrorPlot = new ScottPlot.FormsPlot();
            this.X3Sig = new System.Windows.Forms.TabPage();
            this.X3SigPlot = new ScottPlot.FormsPlot();
            this.Y3Sig = new System.Windows.Forms.TabPage();
            this.Y3SigPlot = new ScottPlot.FormsPlot();
            this.tabControl.SuspendLayout();
            this.XYScatter.SuspendLayout();
            this.XYDist.SuspendLayout();
            this.Yield.SuspendLayout();
            this.XError.SuspendLayout();
            this.YError.SuspendLayout();
            this.X3Sig.SuspendLayout();
            this.Y3Sig.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.XYScatter);
            this.tabControl.Controls.Add(this.XYDist);
            this.tabControl.Controls.Add(this.Yield);
            this.tabControl.Controls.Add(this.XError);
            this.tabControl.Controls.Add(this.YError);
            this.tabControl.Controls.Add(this.X3Sig);
            this.tabControl.Controls.Add(this.Y3Sig);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
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
            // XYScatterPlot
            // 
            this.XYScatterPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XYScatterPlot.Location = new System.Drawing.Point(0, 0);
            this.XYScatterPlot.Name = "XYScatterPlot";
            this.XYScatterPlot.Size = new System.Drawing.Size(792, 424);
            this.XYScatterPlot.TabIndex = 0;
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
            // XYDistPlot
            // 
            this.XYDistPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XYDistPlot.Location = new System.Drawing.Point(0, 0);
            this.XYDistPlot.Name = "XYDistPlot";
            this.XYDistPlot.Size = new System.Drawing.Size(792, 424);
            this.XYDistPlot.TabIndex = 0;
            // 
            // Yield
            // 
            this.Yield.Controls.Add(this.YieldPlot);
            this.Yield.Location = new System.Drawing.Point(4, 22);
            this.Yield.Name = "Yield";
            this.Yield.Size = new System.Drawing.Size(792, 424);
            this.Yield.TabIndex = 2;
            this.Yield.Text = "Yield";
            this.Yield.UseVisualStyleBackColor = true;
            // 
            // YieldPlot
            // 
            this.YieldPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YieldPlot.Location = new System.Drawing.Point(0, 0);
            this.YieldPlot.Name = "YieldPlot";
            this.YieldPlot.Size = new System.Drawing.Size(792, 424);
            this.YieldPlot.TabIndex = 0;
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
            // X3Sig
            // 
            this.X3Sig.Controls.Add(this.X3SigPlot);
            this.X3Sig.Location = new System.Drawing.Point(4, 22);
            this.X3Sig.Name = "X3Sig";
            this.X3Sig.Size = new System.Drawing.Size(792, 424);
            this.X3Sig.TabIndex = 5;
            this.X3Sig.Text = "X 3Sigma";
            this.X3Sig.UseVisualStyleBackColor = true;
            // 
            // X3SigPlot
            // 
            this.X3SigPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X3SigPlot.Location = new System.Drawing.Point(0, 0);
            this.X3SigPlot.Name = "X3SigPlot";
            this.X3SigPlot.Size = new System.Drawing.Size(792, 424);
            this.X3SigPlot.TabIndex = 0;
            // 
            // Y3Sig
            // 
            this.Y3Sig.Controls.Add(this.Y3SigPlot);
            this.Y3Sig.Location = new System.Drawing.Point(4, 22);
            this.Y3Sig.Name = "Y3Sig";
            this.Y3Sig.Size = new System.Drawing.Size(792, 424);
            this.Y3Sig.TabIndex = 6;
            this.Y3Sig.Text = "Y 3Sigma";
            this.Y3Sig.UseVisualStyleBackColor = true;
            // 
            // Y3SigPlot
            // 
            this.Y3SigPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y3SigPlot.Location = new System.Drawing.Point(0, 0);
            this.Y3SigPlot.Name = "Y3SigPlot";
            this.Y3SigPlot.Size = new System.Drawing.Size(792, 424);
            this.Y3SigPlot.TabIndex = 0;
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
            this.tabControl.ResumeLayout(false);
            this.XYScatter.ResumeLayout(false);
            this.XYDist.ResumeLayout(false);
            this.Yield.ResumeLayout(false);
            this.XError.ResumeLayout(false);
            this.YError.ResumeLayout(false);
            this.X3Sig.ResumeLayout(false);
            this.Y3Sig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Yield;
        private ScottPlot.FormsPlot YieldPlot;
        private System.Windows.Forms.TabPage XError;
        private ScottPlot.FormsPlot XErrorPlot;
        private System.Windows.Forms.TabPage YError;
        private ScottPlot.FormsPlot YErrorPlot;
        private System.Windows.Forms.TabPage X3Sig;
        private ScottPlot.FormsPlot X3SigPlot;
        private System.Windows.Forms.TabPage Y3Sig;
        private ScottPlot.FormsPlot Y3SigPlot;
        private System.Windows.Forms.TabPage XYScatter;
        private ScottPlot.FormsPlot XYScatterPlot;
        private System.Windows.Forms.TabPage XYDist;
        private ScottPlot.FormsPlot XYDistPlot;
    }
}

