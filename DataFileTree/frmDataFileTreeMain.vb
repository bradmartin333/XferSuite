Public Class frmDataFileTreeMain
    <ComponentModel.Description("This is the file type extension for the Data File tree")>
    <ComponentModel.Category("User Parameters")>
    Public Property FileExtension As String = "png"

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim data = New frmDataFileTreeEditor(numSub.Value, numVar.Value, FileExtension)
        data.Show()
        Hide()
    End Sub
End Class
