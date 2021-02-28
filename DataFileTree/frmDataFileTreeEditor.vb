Imports System.IO

Public Class frmDataFileTreeEditor
    Private Dir
    Private fileExt As String

    Public Sub New(ByVal numSub As Integer, ByVal numVar As Integer, ByVal fileExt As String)
        ' This call is required by the designer.
        InitializeComponent()

        Me.fileExt = fileExt

        ' Add any initialization after the InitializeComponent() call.
        For i As Integer = 0 To numSub - 1
            dgSub.Rows.Add("")
        Next
        For i As Integer = 0 To numVar - 1
            dgVar.Rows.Add("")
        Next
    End Sub

    Private Sub btnSelectDir_Click(sender As Object, e As EventArgs) Handles btnSelectDir.Click
        Dim dialog = New FolderBrowserDialog With {.Description = "Choose folder containing Inlinepositions data"}
        If dialog.ShowDialog() = DialogResult.OK Then
            Dir = dialog.SelectedPath & "\"
            lblDir.Text = Dir.ToString()
            btnGenerate.Enabled = True
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        For Each variable As DataGridViewRow In dgVar.Rows
            Dim thisVar = variable.Cells(0).Value.ToString()
            If Not Directory.Exists(Dir & thisVar) Then Directory.CreateDirectory(Dir & thisVar)
            For i = 1 To frmDataFileTreeMain.numRep.Value
                Dim thisRep = "_" & i.ToString
                If frmDataFileTreeMain.numRep.Value = 1 Then
                    thisRep = ""
                End If
                For Each subject As DataGridViewRow In dgSub.Rows
                    Dim path = Dir & thisVar & "/" & subject.Cells(0).Value.ToString() & thisRep & "." & fileExt
                    Dim fs As FileStream = File.Create(path)
                Next
            Next
        Next
        MsgBox("File Tree Generated")
    End Sub
End Class