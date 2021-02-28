Public Class frmDataFileTreeMain
    Public Property FileExt As String = ".png"

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim data = New frmDataFileTreeEditor(numSub.Value, numVar.Value, FileExt)
        data.Show()
        Hide()
    End Sub
End Class
