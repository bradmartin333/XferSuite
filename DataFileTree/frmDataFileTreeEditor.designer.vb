<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataFileTreeEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataFileTreeEditor))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgVar = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSub = New System.Windows.Forms.DataGridView()
        Me.Subjects = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSelectDir = New System.Windows.Forms.Button()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.lblDir = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgVar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgVar, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgSub, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSelectDir, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnGenerate, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDir, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(584, 576)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'dgVar
        '
        Me.dgVar.AllowUserToAddRows = False
        Me.dgVar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgVar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgVar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.dgVar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgVar.Location = New System.Drawing.Point(296, 4)
        Me.dgVar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgVar.Name = "dgVar"
        Me.dgVar.RowHeadersWidth = 51
        Me.dgVar.Size = New System.Drawing.Size(284, 486)
        Me.dgVar.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Variables"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'dgSub
        '
        Me.dgSub.AllowUserToAddRows = False
        Me.dgSub.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSub.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Subjects})
        Me.dgSub.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSub.Location = New System.Drawing.Point(4, 4)
        Me.dgSub.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgSub.Name = "dgSub"
        Me.dgSub.RowHeadersWidth = 51
        Me.dgSub.Size = New System.Drawing.Size(284, 486)
        Me.dgSub.TabIndex = 0
        '
        'Subjects
        '
        Me.Subjects.HeaderText = "Subjects"
        Me.Subjects.MinimumWidth = 6
        Me.Subjects.Name = "Subjects"
        '
        'btnSelectDir
        '
        Me.btnSelectDir.AutoSize = True
        Me.btnSelectDir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSelectDir.Location = New System.Drawing.Point(4, 498)
        Me.btnSelectDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSelectDir.Name = "btnSelectDir"
        Me.btnSelectDir.Size = New System.Drawing.Size(284, 33)
        Me.btnSelectDir.TabIndex = 2
        Me.btnSelectDir.Text = "Select Directory"
        Me.btnSelectDir.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnGenerate, 2)
        Me.btnGenerate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnGenerate.Enabled = False
        Me.btnGenerate.Location = New System.Drawing.Point(4, 539)
        Me.btnGenerate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(576, 33)
        Me.btnGenerate.TabIndex = 3
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'lblDir
        '
        Me.lblDir.AutoSize = True
        Me.lblDir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDir.Location = New System.Drawing.Point(296, 494)
        Me.lblDir.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDir.Name = "lblDir"
        Me.lblDir.Size = New System.Drawing.Size(284, 41)
        Me.lblDir.TabIndex = 4
        Me.lblDir.Text = "Select a directory"
        Me.lblDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmDataFileTreeEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 576)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmDataFileTreeEditor"
        Me.Text = "File Names"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgVar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dgSub As DataGridView
    Friend WithEvents dgVar As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Subjects As DataGridViewTextBoxColumn
    Friend WithEvents btnSelectDir As Button
    Friend WithEvents btnGenerate As Button
    Friend WithEvents lblDir As Label
End Class
