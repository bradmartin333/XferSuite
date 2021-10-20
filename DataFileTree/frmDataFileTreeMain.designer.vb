<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataFileTreeMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataFileTreeMain))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.numRep = New System.Windows.Forms.NumericUpDown()
        Me.numVar = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numSub = New System.Windows.Forms.NumericUpDown()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.numRep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numVar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.numRep, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.numVar, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.numSub, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnNext, 1, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(211, 79)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'numRep
        '
        Me.numRep.AutoSize = True
        Me.numRep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numRep.Location = New System.Drawing.Point(137, 20)
        Me.numRep.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numRep.Name = "numRep"
        Me.numRep.Size = New System.Drawing.Size(67, 20)
        Me.numRep.TabIndex = 5
        Me.numRep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numRep.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numVar
        '
        Me.numVar.AutoSize = True
        Me.numVar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numVar.Location = New System.Drawing.Point(71, 20)
        Me.numVar.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numVar.Name = "numVar"
        Me.numVar.Size = New System.Drawing.Size(60, 20)
        Me.numVar.TabIndex = 4
        Me.numVar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numVar.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(137, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "# Replicates"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "# Variables"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "# Subjects"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numSub
        '
        Me.numSub.AutoSize = True
        Me.numSub.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numSub.Location = New System.Drawing.Point(7, 20)
        Me.numSub.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSub.Name = "numSub"
        Me.numSub.Size = New System.Drawing.Size(58, 20)
        Me.numSub.TabIndex = 3
        Me.numSub.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numSub.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnNext
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnNext, 3)
        Me.btnNext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNext.Location = New System.Drawing.Point(7, 46)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(197, 26)
        Me.btnNext.TabIndex = 6
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'frmDataFileTreeMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(211, 79)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDataFileTreeMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.numRep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numVar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents numRep As NumericUpDown
    Friend WithEvents numVar As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents numSub As NumericUpDown
    Friend WithEvents btnNext As Button
End Class
