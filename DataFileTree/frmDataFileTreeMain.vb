﻿Public Class frmDataFileTreeMain
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim data = New frmDataFileTreeEditor(numSub.Value, numVar.Value)
        data.Show()
        Hide()
    End Sub
End Class
