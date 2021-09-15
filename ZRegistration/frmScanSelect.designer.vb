<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScanSelect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScanSelect))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.olv = New BrightIdeasSoftware.FastDataListView()
        Me.OlvColumn6 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn5 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.olv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnReload, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.olv, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ProgressBar, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(496, 372)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnReload
        '
        Me.btnReload.AutoSize = True
        Me.btnReload.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnReload.Location = New System.Drawing.Point(3, 3)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(490, 27)
        Me.btnReload.TabIndex = 1
        Me.btnReload.Text = "Reload File"
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'olv
        '
        Me.olv.AllColumns.Add(Me.OlvColumn6)
        Me.olv.AllColumns.Add(Me.OlvColumn1)
        Me.olv.AllColumns.Add(Me.OlvColumn2)
        Me.olv.AllColumns.Add(Me.OlvColumn3)
        Me.olv.AllColumns.Add(Me.OlvColumn4)
        Me.olv.AllColumns.Add(Me.OlvColumn5)
        Me.olv.CellEditUseWholeCell = False
        Me.olv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn6, Me.OlvColumn1, Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn5})
        Me.olv.Cursor = System.Windows.Forms.Cursors.Default
        Me.olv.DataSource = Nothing
        Me.olv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olv.FullRowSelect = True
        Me.olv.HideSelection = False
        Me.olv.Location = New System.Drawing.Point(3, 52)
        Me.olv.Name = "olv"
        Me.olv.ShowGroups = False
        Me.olv.Size = New System.Drawing.Size(490, 317)
        Me.olv.TabIndex = 2
        Me.olv.UseCompatibleStateImageBehavior = False
        Me.olv.UseFilterIndicator = True
        Me.olv.UseFiltering = True
        Me.olv.View = System.Windows.Forms.View.Details
        Me.olv.VirtualMode = True
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "Index"
        Me.OlvColumn6.AspectToStringFormat = "{0}"
        Me.OlvColumn6.Text = "Index"
        Me.OlvColumn6.Width = 48
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "ShortDate"
        Me.OlvColumn1.AspectToStringFormat = "{0:d}"
        Me.OlvColumn1.Text = "Date"
        Me.OlvColumn1.Width = 82
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "Time"
        Me.OlvColumn2.AspectToStringFormat = "{0:d}"
        Me.OlvColumn2.Text = "Time"
        Me.OlvColumn2.Width = 83
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "Name"
        Me.OlvColumn3.Text = "Name"
        Me.OlvColumn3.Width = 136
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "Temp"
        Me.OlvColumn4.AspectToStringFormat = "{0}°C"
        Me.OlvColumn4.Text = "Temp"
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "RH"
        Me.OlvColumn5.AspectToStringFormat = "{0}%"
        Me.OlvColumn5.Text = "RH"
        '
        'ProgressBar
        '
        Me.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBar.Location = New System.Drawing.Point(3, 36)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(490, 10)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 3
        '
        'frmScanSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 372)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmScanSelect"
        Me.Text = "Double click a row to plot a scan"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.olv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnReload As Button
    Friend WithEvents olv As BrightIdeasSoftware.FastDataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn6 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressBar As ProgressBar
End Class
