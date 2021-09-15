Imports System.IO

Public Class frmScanSelect
    Public Property Path As String
    Dim Scans As New List(Of cScan)

    Public Sub New(filePath As String)
        InitializeComponent()
        Path = filePath
        Show()
        MakeList()
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        MakeList()
    End Sub

    Public Sub MakeList()
        ProgressBar.Style = ProgressBarStyle.Marquee
        ProgressBar.MarqueeAnimationSpeed = 100
        Application.DoEvents()

        FindScans()
        olv.SetObjects(Scans)
        olv.Sort(OlvColumn6, SortOrder.Descending)

        ProgressBar.Style = ProgressBarStyle.Continuous
        ProgressBar.MarqueeAnimationSpeed = 0
    End Sub

    Private Sub ScanSelected(sender As Object, e As EventArgs) Handles olv.ItemActivate
        Dim Zed As New frmZed(olv.SelectedObject)
    End Sub

    Private Sub FindScans()
        Scans.Clear()
        Dim scanIdx As Integer = -1
        Dim reader As StreamReader = New StreamReader(Path)
        While reader.Peek <> -1
            Application.DoEvents()
            Dim line = reader.ReadLine
            Dim p = reader.Peek
            If line.Contains("NEWSCAN") Then
                scanIdx += 1
                Dim info = line.Split(vbTab)
                Dim thisScan = New cScan With
                {
                    .Index = scanIdx + 1,
                    .ShortDate = Date.Parse(info(0)).ToShortDateString,
                    .Time = Date.Parse(info(0)).ToShortTimeString,
                    .Name = info(2)
                }
                If (info.Length > 3) Then
                    thisScan.Temp = info(3)
                    thisScan.RH = info(4)
                End If
                Scans.Add(thisScan)
            Else
                Application.DoEvents()
                Scans(scanIdx).Data.Add(XferHelper.Zed.toPosition(line))
            End If
            Application.DoEvents()
        End While
    End Sub
End Class