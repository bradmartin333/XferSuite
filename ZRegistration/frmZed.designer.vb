﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.lblStats = New System.Windows.Forms.Label()
        Me.HistPlot = New OxyPlot.WindowsForms.PlotView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.flowHeatMapSettings = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblColorAxisMin = New System.Windows.Forms.Label()
        Me.numColorAxisMin = New System.Windows.Forms.NumericUpDown()
        Me.lblColorAxisMax = New System.Windows.Forms.Label()
        Me.numColorAxisMax = New System.Windows.Forms.NumericUpDown()
        Me.btnResetColorAxes = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbxRemoveOutliers = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbxFlipX = New System.Windows.Forms.CheckBox()
        Me.cbxFlipY = New System.Windows.Forms.CheckBox()
        Me.cbxFlipZ = New System.Windows.Forms.CheckBox()
        Me.btnSaveWindow = New System.Windows.Forms.Button()
        Me.cbxRemoveBorders = New System.Windows.Forms.CheckBox()
        Me.lblXvsZ = New System.Windows.Forms.Label()
        Me.lblYvsZ = New System.Windows.Forms.Label()
        Me.ScatterXvsZ = New OxyPlot.WindowsForms.PlotView()
        Me.ScatterYvsZ = New OxyPlot.WindowsForms.PlotView()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.flowHeatMapSettings.SuspendLayout()
        CType(Me.numColorAxisMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numColorAxisMax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'HeatPlot
        '
        Me.HeatPlot.BackColor = System.Drawing.Color.LightGray
        Me.HeatPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HeatPlot.Location = New System.Drawing.Point(4, 25)
        Me.HeatPlot.Name = "HeatPlot"
        Me.HeatPlot.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.HeatPlot.Size = New System.Drawing.Size(343, 253)
        Me.HeatPlot.TabIndex = 0
        Me.HeatPlot.Text = "PlotView1"
        Me.HeatPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.HeatPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.HeatPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99998!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00002!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblStats, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.HeatPlot, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.HistPlot, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.flowHeatMapSettings, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblXvsZ, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblYvsZ, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ScatterXvsZ, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ScatterYvsZ, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel3, 1, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(703, 636)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblStats
        '
        Me.lblStats.AutoSize = True
        Me.lblStats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStats.Location = New System.Drawing.Point(354, 1)
        Me.lblStats.Name = "lblStats"
        Me.lblStats.Size = New System.Drawing.Size(345, 20)
        Me.lblStats.TabIndex = 4
        Me.lblStats.Text = "Histogram"
        Me.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HistPlot
        '
        Me.HistPlot.BackColor = System.Drawing.Color.LightGray
        Me.HistPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HistPlot.Location = New System.Drawing.Point(354, 25)
        Me.HistPlot.Name = "HistPlot"
        Me.HistPlot.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.HistPlot.Size = New System.Drawing.Size(345, 253)
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
        Me.Label1.Location = New System.Drawing.Point(4, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(343, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Heat Map: Height Measurement (mm)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.flowHeatMapSettings.Location = New System.Drawing.Point(32, 285)
        Me.flowHeatMapSettings.Name = "flowHeatMapSettings"
        Me.flowHeatMapSettings.Size = New System.Drawing.Size(286, 29)
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
        Me.numColorAxisMin.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.numColorAxisMin.Name = "numColorAxisMin"
        Me.numColorAxisMin.Size = New System.Drawing.Size(65, 20)
        Me.numColorAxisMin.TabIndex = 1
        Me.numColorAxisMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblColorAxisMax
        '
        Me.lblColorAxisMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblColorAxisMax.AutoSize = True
        Me.lblColorAxisMax.Location = New System.Drawing.Point(104, 8)
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
        Me.numColorAxisMax.Location = New System.Drawing.Point(137, 4)
        Me.numColorAxisMax.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.numColorAxisMax.Name = "numColorAxisMax"
        Me.numColorAxisMax.Size = New System.Drawing.Size(65, 20)
        Me.numColorAxisMax.TabIndex = 3
        Me.numColorAxisMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnResetColorAxes
        '
        Me.btnResetColorAxes.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnResetColorAxes.AutoSize = True
        Me.btnResetColorAxes.Location = New System.Drawing.Point(208, 3)
        Me.btnResetColorAxes.Name = "btnResetColorAxes"
        Me.btnResetColorAxes.Size = New System.Drawing.Size(75, 23)
        Me.btnResetColorAxes.TabIndex = 4
        Me.btnResetColorAxes.Text = "Reset"
        Me.btnResetColorAxes.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.cbxRemoveOutliers)
        Me.FlowLayoutPanel1.Controls.Add(Me.cbxRemoveBorders)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(74, 602)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(203, 30)
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
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.Controls.Add(Me.cbxFlipX)
        Me.FlowLayoutPanel2.Controls.Add(Me.cbxFlipY)
        Me.FlowLayoutPanel2.Controls.Add(Me.cbxFlipZ)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(453, 285)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(147, 29)
        Me.FlowLayoutPanel2.TabIndex = 10
        '
        'cbxFlipX
        '
        Me.cbxFlipX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cbxFlipX.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbxFlipX.AutoSize = True
        Me.cbxFlipX.Location = New System.Drawing.Point(3, 3)
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
        Me.cbxFlipY.Location = New System.Drawing.Point(52, 3)
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
        Me.cbxFlipZ.Location = New System.Drawing.Point(101, 3)
        Me.cbxFlipZ.Name = "cbxFlipZ"
        Me.cbxFlipZ.Size = New System.Drawing.Size(43, 23)
        Me.cbxFlipZ.TabIndex = 3
        Me.cbxFlipZ.Text = "Flip Z"
        Me.cbxFlipZ.UseVisualStyleBackColor = True
        '
        'btnSaveWindow
        '
        Me.btnSaveWindow.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSaveWindow.AutoSize = True
        Me.btnSaveWindow.Location = New System.Drawing.Point(3, 3)
        Me.btnSaveWindow.Name = "btnSaveWindow"
        Me.btnSaveWindow.Size = New System.Drawing.Size(84, 23)
        Me.btnSaveWindow.TabIndex = 0
        Me.btnSaveWindow.Text = "Save Window"
        Me.btnSaveWindow.UseVisualStyleBackColor = True
        '
        'cbxRemoveBorders
        '
        Me.cbxRemoveBorders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cbxRemoveBorders.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbxRemoveBorders.AutoSize = True
        Me.cbxRemoveBorders.Location = New System.Drawing.Point(104, 3)
        Me.cbxRemoveBorders.Name = "cbxRemoveBorders"
        Me.cbxRemoveBorders.Size = New System.Drawing.Size(96, 23)
        Me.cbxRemoveBorders.TabIndex = 1
        Me.cbxRemoveBorders.Text = "Remove Borders"
        Me.cbxRemoveBorders.UseVisualStyleBackColor = True
        '
        'lblXvsZ
        '
        Me.lblXvsZ.AutoSize = True
        Me.lblXvsZ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblXvsZ.Location = New System.Drawing.Point(4, 318)
        Me.lblXvsZ.Name = "lblXvsZ"
        Me.lblXvsZ.Size = New System.Drawing.Size(343, 20)
        Me.lblXvsZ.TabIndex = 11
        Me.lblXvsZ.Text = "X vs. Z"
        Me.lblXvsZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblYvsZ
        '
        Me.lblYvsZ.AutoSize = True
        Me.lblYvsZ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblYvsZ.Location = New System.Drawing.Point(354, 318)
        Me.lblYvsZ.Name = "lblYvsZ"
        Me.lblYvsZ.Size = New System.Drawing.Size(345, 20)
        Me.lblYvsZ.TabIndex = 12
        Me.lblYvsZ.Text = "Y vs. Z"
        Me.lblYvsZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ScatterXvsZ
        '
        Me.ScatterXvsZ.BackColor = System.Drawing.Color.LightGray
        Me.ScatterXvsZ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ScatterXvsZ.Location = New System.Drawing.Point(4, 342)
        Me.ScatterXvsZ.Name = "ScatterXvsZ"
        Me.ScatterXvsZ.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.ScatterXvsZ.Size = New System.Drawing.Size(343, 253)
        Me.ScatterXvsZ.TabIndex = 13
        Me.ScatterXvsZ.Text = "PlotView1"
        Me.ScatterXvsZ.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.ScatterXvsZ.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.ScatterXvsZ.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'ScatterYvsZ
        '
        Me.ScatterYvsZ.BackColor = System.Drawing.Color.LightGray
        Me.ScatterYvsZ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ScatterYvsZ.Location = New System.Drawing.Point(354, 342)
        Me.ScatterYvsZ.Name = "ScatterYvsZ"
        Me.ScatterYvsZ.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.ScatterYvsZ.Size = New System.Drawing.Size(345, 253)
        Me.ScatterYvsZ.TabIndex = 14
        Me.ScatterYvsZ.Text = "PlotView2"
        Me.ScatterYvsZ.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.ScatterYvsZ.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.ScatterYvsZ.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel3.AutoSize = True
        Me.FlowLayoutPanel3.Controls.Add(Me.btnSaveWindow)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(481, 602)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(90, 30)
        Me.FlowLayoutPanel3.TabIndex = 15
        '
        'frmZed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 636)
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
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HeatPlot As OxyPlot.WindowsForms.PlotView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents HistPlot As OxyPlot.WindowsForms.PlotView
    Friend WithEvents lblStats As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSaveWindow As Button
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
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents cbxRemoveBorders As CheckBox
    Friend WithEvents lblXvsZ As Label
    Friend WithEvents lblYvsZ As Label
    Friend WithEvents ScatterXvsZ As OxyPlot.WindowsForms.PlotView
    Friend WithEvents ScatterYvsZ As OxyPlot.WindowsForms.PlotView
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
End Class
