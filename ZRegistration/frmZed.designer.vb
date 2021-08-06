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
        Me.btnSaveWindow = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblStats = New System.Windows.Forms.Label()
        Me.HistPlot = New OxyPlot.WindowsForms.PlotView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ZedPlot = New OxyPlot.WindowsForms.PlotView()
        Me.flowHeatMapSettings = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblColorAxisMin = New System.Windows.Forms.Label()
        Me.numColorAxisMin = New System.Windows.Forms.NumericUpDown()
        Me.lblColorAxisMax = New System.Windows.Forms.Label()
        Me.numColorAxisMax = New System.Windows.Forms.NumericUpDown()
        Me.btnResetColorAxes = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbxRemoveOutliers = New System.Windows.Forms.CheckBox()
        Me.cbxFlipX = New System.Windows.Forms.CheckBox()
        Me.cbxFlipY = New System.Windows.Forms.CheckBox()
        Me.cbxFlipZ = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.flowHeatMapSettings.SuspendLayout()
        CType(Me.numColorAxisMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numColorAxisMax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'HeatPlot
        '
        Me.HeatPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HeatPlot.Location = New System.Drawing.Point(3, 23)
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
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnSaveWindow, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStats, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.HeatPlot, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.HistPlot, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ZedPlot, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.flowHeatMapSettings, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1013, 347)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnSaveWindow
        '
        Me.btnSaveWindow.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSaveWindow.AutoSize = True
        Me.btnSaveWindow.Location = New System.Drawing.Point(926, 318)
        Me.btnSaveWindow.Name = "btnSaveWindow"
        Me.btnSaveWindow.Size = New System.Drawing.Size(84, 23)
        Me.btnSaveWindow.TabIndex = 0
        Me.btnSaveWindow.Text = "Save Window"
        Me.btnSaveWindow.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(677, 0)
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
        Me.lblStats.Location = New System.Drawing.Point(340, 0)
        Me.lblStats.Name = "lblStats"
        Me.lblStats.Size = New System.Drawing.Size(331, 20)
        Me.lblStats.TabIndex = 4
        Me.lblStats.Text = "Histogram"
        Me.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HistPlot
        '
        Me.HistPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HistPlot.Location = New System.Drawing.Point(340, 23)
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
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(331, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Heat Map: Height Measurement (mm)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ZedPlot
        '
        Me.ZedPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ZedPlot.Location = New System.Drawing.Point(677, 23)
        Me.ZedPlot.Name = "ZedPlot"
        Me.ZedPlot.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.ZedPlot.Size = New System.Drawing.Size(333, 286)
        Me.ZedPlot.TabIndex = 7
        Me.ZedPlot.Text = "PlotView1"
        Me.ZedPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.ZedPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.ZedPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'flowHeatMapSettings
        '
        Me.flowHeatMapSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.flowHeatMapSettings.AutoSize = True
        Me.flowHeatMapSettings.Controls.Add(Me.lblColorAxisMin)
        Me.flowHeatMapSettings.Controls.Add(Me.numColorAxisMin)
        Me.flowHeatMapSettings.Controls.Add(Me.lblColorAxisMax)
        Me.flowHeatMapSettings.Controls.Add(Me.numColorAxisMax)
        Me.flowHeatMapSettings.Controls.Add(Me.btnResetColorAxes)
        Me.flowHeatMapSettings.Location = New System.Drawing.Point(35, 315)
        Me.flowHeatMapSettings.Name = "flowHeatMapSettings"
        Me.flowHeatMapSettings.Size = New System.Drawing.Size(266, 29)
        Me.flowHeatMapSettings.TabIndex = 8
        '
        'lblColorAxisMin
        '
        Me.lblColorAxisMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblColorAxisMin.AutoSize = True
        Me.lblColorAxisMin.Location = New System.Drawing.Point(3, 8)
        Me.lblColorAxisMin.Name = "lblColorAxisMin"
        Me.lblColorAxisMin.Size = New System.Drawing.Size(24, 13)
        Me.lblColorAxisMin.TabIndex = 0
        Me.lblColorAxisMin.Text = "Min"
        '
        'numColorAxisMin
        '
        Me.numColorAxisMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numColorAxisMin.DecimalPlaces = 3
        Me.numColorAxisMin.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.numColorAxisMin.Location = New System.Drawing.Point(33, 4)
        Me.numColorAxisMin.Name = "numColorAxisMin"
        Me.numColorAxisMin.Size = New System.Drawing.Size(54, 20)
        Me.numColorAxisMin.TabIndex = 1
        '
        'lblColorAxisMax
        '
        Me.lblColorAxisMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblColorAxisMax.AutoSize = True
        Me.lblColorAxisMax.Location = New System.Drawing.Point(93, 8)
        Me.lblColorAxisMax.Name = "lblColorAxisMax"
        Me.lblColorAxisMax.Size = New System.Drawing.Size(27, 13)
        Me.lblColorAxisMax.TabIndex = 2
        Me.lblColorAxisMax.Text = "Max"
        '
        'numColorAxisMax
        '
        Me.numColorAxisMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numColorAxisMax.DecimalPlaces = 3
        Me.numColorAxisMax.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.numColorAxisMax.Location = New System.Drawing.Point(126, 4)
        Me.numColorAxisMax.Name = "numColorAxisMax"
        Me.numColorAxisMax.Size = New System.Drawing.Size(56, 20)
        Me.numColorAxisMax.TabIndex = 3
        '
        'btnResetColorAxes
        '
        Me.btnResetColorAxes.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnResetColorAxes.AutoSize = True
        Me.btnResetColorAxes.Location = New System.Drawing.Point(188, 3)
        Me.btnResetColorAxes.Name = "btnResetColorAxes"
        Me.btnResetColorAxes.Size = New System.Drawing.Size(75, 23)
        Me.btnResetColorAxes.TabIndex = 4
        Me.btnResetColorAxes.Text = "Reset"
        Me.btnResetColorAxes.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.cbxRemoveOutliers)
        Me.FlowLayoutPanel1.Controls.Add(Me.cbxFlipX)
        Me.FlowLayoutPanel1.Controls.Add(Me.cbxFlipY)
        Me.FlowLayoutPanel1.Controls.Add(Me.cbxFlipZ)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(340, 315)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(331, 29)
        Me.FlowLayoutPanel1.TabIndex = 9
        '
        'cbxRemoveOutliers
        '
        Me.cbxRemoveOutliers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cbxRemoveOutliers.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbxRemoveOutliers.AutoSize = True
        Me.cbxRemoveOutliers.Location = New System.Drawing.Point(3, 3)
        Me.cbxRemoveOutliers.Name = "cbxRemoveOutliers"
        Me.cbxRemoveOutliers.Size = New System.Drawing.Size(95, 23)
        Me.cbxRemoveOutliers.TabIndex = 0
        Me.cbxRemoveOutliers.Text = "Remove Outliers"
        Me.cbxRemoveOutliers.UseVisualStyleBackColor = True
        '
        'cbxFlipX
        '
        Me.cbxFlipX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cbxFlipX.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbxFlipX.AutoSize = True
        Me.cbxFlipX.Location = New System.Drawing.Point(104, 3)
        Me.cbxFlipX.Name = "cbxFlipX"
        Me.cbxFlipX.Size = New System.Drawing.Size(43, 23)
        Me.cbxFlipX.TabIndex = 1
        Me.cbxFlipX.Text = "Flip X"
        Me.cbxFlipX.UseVisualStyleBackColor = True
        '
        'cbxFlipY
        '
        Me.cbxFlipY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cbxFlipY.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbxFlipY.AutoSize = True
        Me.cbxFlipY.Location = New System.Drawing.Point(153, 3)
        Me.cbxFlipY.Name = "cbxFlipY"
        Me.cbxFlipY.Size = New System.Drawing.Size(43, 23)
        Me.cbxFlipY.TabIndex = 2
        Me.cbxFlipY.Text = "Flip Y"
        Me.cbxFlipY.UseVisualStyleBackColor = True
        '
        'cbxFlipZ
        '
        Me.cbxFlipZ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cbxFlipZ.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbxFlipZ.AutoSize = True
        Me.cbxFlipZ.Location = New System.Drawing.Point(202, 3)
        Me.cbxFlipZ.Name = "cbxFlipZ"
        Me.cbxFlipZ.Size = New System.Drawing.Size(43, 23)
        Me.cbxFlipZ.TabIndex = 3
        Me.cbxFlipZ.Text = "Flip Z"
        Me.cbxFlipZ.UseVisualStyleBackColor = True
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
        Me.flowHeatMapSettings.ResumeLayout(False)
        Me.flowHeatMapSettings.PerformLayout()
        CType(Me.numColorAxisMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numColorAxisMax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HeatPlot As OxyPlot.WindowsForms.PlotView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents HistPlot As OxyPlot.WindowsForms.PlotView
    Friend WithEvents lblStats As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSaveWindow As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ZedPlot As OxyPlot.WindowsForms.PlotView
    Friend WithEvents flowHeatMapSettings As FlowLayoutPanel
    Friend WithEvents lblColorAxisMin As Label
    Friend WithEvents numColorAxisMin As NumericUpDown
    Friend WithEvents lblColorAxisMax As Label
    Friend WithEvents numColorAxisMax As NumericUpDown
    Friend WithEvents btnResetColorAxes As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents cbxRemoveOutliers As CheckBox
    Friend WithEvents cbxFlipX As CheckBox
    Friend WithEvents cbxFlipY As CheckBox
    Friend WithEvents cbxFlipZ As CheckBox
End Class
