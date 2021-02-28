<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmZed
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmZed))
        Me.HeatPlot = New OxyPlot.WindowsForms.PlotView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblStats = New System.Windows.Forms.Label()
        Me.HistPlot = New OxyPlot.WindowsForms.PlotView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnSaveWindow = New System.Windows.Forms.Button()
        Me.ZedPlot = New OxyPlot.WindowsForms.PlotView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'HeatPlot
        '
        Me.HeatPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HeatPlot.Location = New System.Drawing.Point(3, 58)
        Me.HeatPlot.Name = "HeatPlot"
        Me.HeatPlot.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.HeatPlot.Size = New System.Drawing.Size(331, 286)
        Me.HeatPlot.TabIndex = 0
        Me.HeatPlot.Text = "PlotView1"
        Me.HeatPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.HeatPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.HeatPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStats, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.HeatPlot, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.HistPlot, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ZedPlot, 2, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1013, 347)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(677, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(333, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Scatterplot: Green = X, Blue = Y"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStats
        '
        Me.lblStats.AutoSize = True
        Me.lblStats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStats.Location = New System.Drawing.Point(340, 35)
        Me.lblStats.Name = "lblStats"
        Me.lblStats.Size = New System.Drawing.Size(331, 20)
        Me.lblStats.TabIndex = 4
        Me.lblStats.Text = "Histogram"
        Me.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HistPlot
        '
        Me.HistPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HistPlot.Location = New System.Drawing.Point(340, 58)
        Me.HistPlot.Name = "HistPlot"
        Me.HistPlot.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.HistPlot.Size = New System.Drawing.Size(331, 286)
        Me.HistPlot.TabIndex = 1
        Me.HistPlot.Text = "PlotView1"
        Me.HistPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.HistPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.HistPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(331, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Heat Map: Height Measurement (mm)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel1, 3)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnSaveWindow)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1007, 29)
        Me.FlowLayoutPanel1.TabIndex = 5
        '
        'btnSaveWindow
        '
        Me.btnSaveWindow.AutoSize = True
        Me.btnSaveWindow.Location = New System.Drawing.Point(920, 3)
        Me.btnSaveWindow.Name = "btnSaveWindow"
        Me.btnSaveWindow.Size = New System.Drawing.Size(84, 23)
        Me.btnSaveWindow.TabIndex = 0
        Me.btnSaveWindow.Text = "Save Window"
        Me.btnSaveWindow.UseVisualStyleBackColor = True
        '
        'ZedPlot
        '
        Me.ZedPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ZedPlot.Location = New System.Drawing.Point(677, 58)
        Me.ZedPlot.Name = "ZedPlot"
        Me.ZedPlot.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.ZedPlot.Size = New System.Drawing.Size(333, 286)
        Me.ZedPlot.TabIndex = 7
        Me.ZedPlot.Text = "PlotView1"
        Me.ZedPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.ZedPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.ZedPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'frmZed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 347)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmZed"
        Me.Text = "Height Sensor Data"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HeatPlot As OxyPlot.WindowsForms.PlotView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents HistPlot As OxyPlot.WindowsForms.PlotView
    Friend WithEvents lblStats As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnSaveWindow As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ZedPlot As OxyPlot.WindowsForms.PlotView
End Class
