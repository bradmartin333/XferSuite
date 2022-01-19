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
        Me.HistPlot = New OxyPlot.WindowsForms.PlotView()
        Me.ScatterXvsZ = New OxyPlot.WindowsForms.PlotView()
        Me.ScatterYvsZ = New OxyPlot.WindowsForms.PlotView()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnCopyData = New System.Windows.Forms.Button()
        Me.btnSaveWindow = New System.Windows.Forms.Button()
        Me.btnCopyWindow = New System.Windows.Forms.Button()
        Me.btnThetaInfo = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbxView = New System.Windows.Forms.CheckBox()
        Me.cbxRemoveTilt = New System.Windows.Forms.CheckBox()
        Me.cbxRemoveBorder = New System.Windows.Forms.CheckBox()
        Me.OutlierLevelScrollBar = New System.Windows.Forms.HScrollBar()
        Me.lblNumData = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'HeatPlot
        '
        Me.HeatPlot.BackColor = System.Drawing.Color.LightGray
        Me.HeatPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HeatPlot.Location = New System.Drawing.Point(3, 3)
        Me.HeatPlot.Name = "HeatPlot"
        Me.HeatPlot.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.HeatPlot.Size = New System.Drawing.Size(345, 275)
        Me.HeatPlot.TabIndex = 0
        Me.HeatPlot.Text = "PlotView1"
        Me.HeatPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.HeatPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.HeatPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99998!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00002!))
        Me.TableLayoutPanel1.Controls.Add(Me.HeatPlot, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.HistPlot, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ScatterXvsZ, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ScatterYvsZ, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(703, 636)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'HistPlot
        '
        Me.HistPlot.BackColor = System.Drawing.Color.LightGray
        Me.HistPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HistPlot.Location = New System.Drawing.Point(354, 3)
        Me.HistPlot.Name = "HistPlot"
        Me.HistPlot.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.HistPlot.Size = New System.Drawing.Size(346, 275)
        Me.HistPlot.TabIndex = 1
        Me.HistPlot.Text = "PlotView1"
        Me.HistPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.HistPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.HistPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'ScatterXvsZ
        '
        Me.ScatterXvsZ.BackColor = System.Drawing.Color.LightGray
        Me.ScatterXvsZ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ScatterXvsZ.Location = New System.Drawing.Point(3, 321)
        Me.ScatterXvsZ.Name = "ScatterXvsZ"
        Me.ScatterXvsZ.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.ScatterXvsZ.Size = New System.Drawing.Size(345, 275)
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
        Me.ScatterYvsZ.Location = New System.Drawing.Point(354, 321)
        Me.ScatterYvsZ.Name = "ScatterYvsZ"
        Me.ScatterYvsZ.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.ScatterYvsZ.Size = New System.Drawing.Size(346, 275)
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
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel3, 2)
        Me.FlowLayoutPanel3.Controls.Add(Me.btnCopyData)
        Me.FlowLayoutPanel3.Controls.Add(Me.btnSaveWindow)
        Me.FlowLayoutPanel3.Controls.Add(Me.btnCopyWindow)
        Me.FlowLayoutPanel3.Controls.Add(Me.btnThetaInfo)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(139, 602)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(424, 31)
        Me.FlowLayoutPanel3.TabIndex = 15
        '
        'btnCopyData
        '
        Me.btnCopyData.AutoSize = True
        Me.btnCopyData.BackColor = System.Drawing.SystemColors.Control
        Me.btnCopyData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopyData.Location = New System.Drawing.Point(3, 3)
        Me.btnCopyData.Name = "btnCopyData"
        Me.btnCopyData.Size = New System.Drawing.Size(100, 25)
        Me.btnCopyData.TabIndex = 2
        Me.btnCopyData.Text = "Copy Data"
        Me.btnCopyData.UseVisualStyleBackColor = False
        '
        'btnSaveWindow
        '
        Me.btnSaveWindow.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSaveWindow.AutoSize = True
        Me.btnSaveWindow.BackColor = System.Drawing.SystemColors.Control
        Me.btnSaveWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveWindow.Location = New System.Drawing.Point(109, 3)
        Me.btnSaveWindow.Name = "btnSaveWindow"
        Me.btnSaveWindow.Size = New System.Drawing.Size(100, 25)
        Me.btnSaveWindow.TabIndex = 0
        Me.btnSaveWindow.Text = "Save Window"
        Me.btnSaveWindow.UseVisualStyleBackColor = False
        '
        'btnCopyWindow
        '
        Me.btnCopyWindow.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCopyWindow.AutoSize = True
        Me.btnCopyWindow.BackColor = System.Drawing.SystemColors.Control
        Me.btnCopyWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopyWindow.Location = New System.Drawing.Point(215, 3)
        Me.btnCopyWindow.Name = "btnCopyWindow"
        Me.btnCopyWindow.Size = New System.Drawing.Size(100, 25)
        Me.btnCopyWindow.TabIndex = 3
        Me.btnCopyWindow.Text = "Copy Window"
        Me.btnCopyWindow.UseVisualStyleBackColor = False
        '
        'btnThetaInfo
        '
        Me.btnThetaInfo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnThetaInfo.AutoSize = True
        Me.btnThetaInfo.BackColor = System.Drawing.SystemColors.Control
        Me.btnThetaInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnThetaInfo.Location = New System.Drawing.Point(321, 3)
        Me.btnThetaInfo.Name = "btnThetaInfo"
        Me.btnThetaInfo.Size = New System.Drawing.Size(100, 25)
        Me.btnThetaInfo.TabIndex = 4
        Me.btnThetaInfo.Text = "Theta Info"
        Me.btnThetaInfo.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel2, 2)
        Me.FlowLayoutPanel2.Controls.Add(Me.cbxView)
        Me.FlowLayoutPanel2.Controls.Add(Me.cbxRemoveTilt)
        Me.FlowLayoutPanel2.Controls.Add(Me.cbxRemoveBorder)
        Me.FlowLayoutPanel2.Controls.Add(Me.OutlierLevelScrollBar)
        Me.FlowLayoutPanel2.Controls.Add(Me.lblNumData)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(54, 284)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(595, 31)
        Me.FlowLayoutPanel2.TabIndex = 10
        '
        'cbxView
        '
        Me.cbxView.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbxView.BackColor = System.Drawing.SystemColors.Control
        Me.cbxView.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleTurquoise
        Me.cbxView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxView.Location = New System.Drawing.Point(3, 3)
        Me.cbxView.Name = "cbxView"
        Me.cbxView.Size = New System.Drawing.Size(100, 25)
        Me.cbxView.TabIndex = 2
        Me.cbxView.Text = "SPOT View"
        Me.cbxView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cbxView.UseVisualStyleBackColor = False
        '
        'cbxRemoveTilt
        '
        Me.cbxRemoveTilt.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbxRemoveTilt.BackColor = System.Drawing.SystemColors.Control
        Me.cbxRemoveTilt.Checked = True
        Me.cbxRemoveTilt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxRemoveTilt.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen
        Me.cbxRemoveTilt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxRemoveTilt.Location = New System.Drawing.Point(109, 3)
        Me.cbxRemoveTilt.Name = "cbxRemoveTilt"
        Me.cbxRemoveTilt.Size = New System.Drawing.Size(100, 25)
        Me.cbxRemoveTilt.TabIndex = 3
        Me.cbxRemoveTilt.Text = "Remove Tilt"
        Me.cbxRemoveTilt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cbxRemoveTilt.UseVisualStyleBackColor = False
        '
        'cbxRemoveBorder
        '
        Me.cbxRemoveBorder.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbxRemoveBorder.BackColor = System.Drawing.SystemColors.Control
        Me.cbxRemoveBorder.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen
        Me.cbxRemoveBorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxRemoveBorder.Location = New System.Drawing.Point(215, 3)
        Me.cbxRemoveBorder.Name = "cbxRemoveBorder"
        Me.cbxRemoveBorder.Size = New System.Drawing.Size(100, 25)
        Me.cbxRemoveBorder.TabIndex = 8
        Me.cbxRemoveBorder.Text = "Remove Border"
        Me.cbxRemoveBorder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cbxRemoveBorder.UseVisualStyleBackColor = False
        '
        'OutlierLevelScrollBar
        '
        Me.OutlierLevelScrollBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OutlierLevelScrollBar.LargeChange = 1
        Me.OutlierLevelScrollBar.Location = New System.Drawing.Point(343, 5)
        Me.OutlierLevelScrollBar.Margin = New System.Windows.Forms.Padding(25, 0, 0, 0)
        Me.OutlierLevelScrollBar.Name = "OutlierLevelScrollBar"
        Me.OutlierLevelScrollBar.Size = New System.Drawing.Size(141, 20)
        Me.OutlierLevelScrollBar.TabIndex = 7
        Me.OutlierLevelScrollBar.Value = 1
        '
        'lblNumData
        '
        Me.lblNumData.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNumData.AutoSize = True
        Me.lblNumData.Location = New System.Drawing.Point(487, 9)
        Me.lblNumData.Name = "lblNumData"
        Me.lblNumData.Size = New System.Drawing.Size(105, 13)
        Me.lblNumData.TabIndex = 6
        Me.lblNumData.Text = "0/0 Points Removed"
        Me.lblNumData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmZed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 636)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(719, 675)
        Me.Name = "frmZed"
        Me.Text = "Height Sensor Data"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HeatPlot As OxyPlot.WindowsForms.PlotView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents HistPlot As OxyPlot.WindowsForms.PlotView
    Friend WithEvents btnSaveWindow As Button
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents ScatterXvsZ As OxyPlot.WindowsForms.PlotView
    Friend WithEvents ScatterYvsZ As OxyPlot.WindowsForms.PlotView
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents btnCopyData As Button
    Friend WithEvents cbxView As CheckBox
    Friend WithEvents cbxRemoveTilt As CheckBox
    Friend WithEvents btnCopyWindow As Button
    Friend WithEvents lblNumData As Label
    Friend WithEvents OutlierLevelScrollBar As HScrollBar
    Friend WithEvents btnThetaInfo As Button
    Friend WithEvents cbxRemoveBorder As CheckBox
End Class
