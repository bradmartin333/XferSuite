Imports System.IO

Public Class frmScanSelect
    Private _HideSource As Boolean
    <ComponentModel.Category("User Parameters")>
    Public Property HideSource As Boolean
        Get
            Return _HideSource
        End Get
        Set(Value As Boolean)
            _HideSource = Value
            MakeList()
        End Set
    End Property

    Private _HideTarget As Boolean
    <ComponentModel.Category("User Parameters")>
    Public Property HideTarget As Boolean
        Get
            Return _HideTarget
        End Get
        Set(Value As Boolean)
            _HideTarget = Value
            MakeList()
        End Set
    End Property


    Private _HideClean As Boolean
    <ComponentModel.Category("User Parameters")>
    Public Property HideClean As Boolean
        Get
            Return _HideClean
        End Get
        Set(Value As Boolean)
            _HideClean = Value
            MakeList()
        End Set
    End Property

    Public Property Path As String
    Dim scans As New List(Of String)
    Dim scanData As New List(Of List(Of String))

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click, MyBase.Load
        MakeList()
    End Sub

    Public Sub MakeList()
        scans.Clear()
        scanData.Clear()
        ScanList.Items.Clear()
        FindScans(File.ReadAllLines(Path))
        scans.Reverse()
        scanData.Reverse()
        For Each scan In scans
            ScanList.Items.Add(scan)
        Next
        Refresh()
    End Sub

    Private Sub ScanList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ScanList.SelectedIndexChanged
        Dim Zed As New frmZed(scanData(sender.SelectedIndex), scans(sender.SelectedIndex))
        Zed.Show()
    End Sub

    Private Sub FindScans(lines As String())
        Dim dataBuffer As New List(Of String)
        For i As Integer = 0 To lines.Count() - 1
            If lines(i).Contains("NEWSCAN") Then
                If HideSource AndAlso lines(i).Contains("Source") Then Continue For
                If HideTarget AndAlso lines(i).Contains("Target") Then Continue For
                If HideClean AndAlso lines(i).Contains("Clean") Then Continue For
                If dataBuffer.Count > 0 Then
                    scanData.Add(dataBuffer)
                End If
                dataBuffer = New List(Of String)
                If lines(i + 1).Contains("NEWSCAN") Or lines(i + 1) = "" Then Continue For
                scans.Add(lines(i).Replace(vbTab & "NEWSCAN" & vbTab, "     "))
            Else
                dataBuffer.Add(lines(i))
            End If
        Next
        If dataBuffer.Count > 0 Then scanData.Add(dataBuffer)
    End Sub
End Class