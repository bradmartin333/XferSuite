Imports System.IO

Public Class frmScanSelect
    <ComponentModel.Description("Use these editable axes with a newly opened scan")>
    <ComponentModel.Category("User Parameters")>
    Public Property UseCustomAxes As Boolean = False

    <ComponentModel.Category("User Parameters")>
    Public Property XMin As Double = 0.0

    <ComponentModel.Category("User Parameters")>
    Public Property XMax As Double = 15.0

    <ComponentModel.Category("User Parameters")>
    Public Property YMin As Double = 0.0

    <ComponentModel.Category("User Parameters")>
    Public Property YMax As Double = 15.0

    <ComponentModel.Category("User Parameters")>
    Public Property ZMin As Double = 0.0

    <ComponentModel.Category("User Parameters")>
    Public Property ZMax As Double = 1.0

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

        FindScans()
        olv.SetObjects(Scans)
        olv.Sort(OlvColumn6, SortOrder.Descending)

        ProgressBar.Style = ProgressBarStyle.Continuous
        ProgressBar.MarqueeAnimationSpeed = 0
    End Sub

    Private Sub ScanSelected(sender As Object, e As EventArgs) Handles olv.ItemActivate
        Dim Zed As New frmZed(olv.SelectedObject, New Double() {XMin, XMax, YMin, YMax, ZMin, ZMax}, UseCustomAxes)
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
                Try
                    Scans(scanIdx).Data.Add(XferHelper.Zed.toPosition(line))
                Catch ex As Exception
                    MessageBox.Show(text:="Invalid File", caption:="XYZscan")
                    Return
                End Try
            End If
        End While
    End Sub
End Class