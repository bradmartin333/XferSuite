Imports MathNet.Spatial.Euclidean
Imports OxyPlot
Imports OxyPlot.Axes
Imports OxyPlot.Series
Imports XferHelper

Public Class frmZed
    Private _RemoveOutliers As Boolean = False
    Public Property RemoveOutliers() As Boolean
        Get
            Return _RemoveOutliers
        End Get
        Set(value As Boolean)
            _RemoveOutliers = value
            ParseData()
            CreatePlots()
        End Set
    End Property

    Private _FlipX As Boolean = False
    Public Property FlipX() As Boolean
        Get
            Return _FlipX
        End Get
        Set(value As Boolean)
            _FlipX = value
            ParseData()
            CreatePlots()
        End Set
    End Property

    Private _FlipY As Boolean = False
    Public Property FlipY() As Boolean
        Get
            Return _FlipY
        End Get
        Set(value As Boolean)
            _FlipY = value
            ParseData()
            CreatePlots()
        End Set
    End Property

    Private _FlipZ As Boolean = False
    Public Property FlipZ() As Boolean
        Get
            Return _FlipZ
        End Get
        Set(value As Boolean)
            _FlipZ = value
            ParseData()
            CreatePlots()
        End Set
    End Property

    Dim _Data
    Dim HistData As New List(Of Double)
    Dim ScatterData As New List(Of Point3D)
    Dim ScatterDataX, ScatterDataY, ScatterDataZ As New List(Of ScatterPoint)
    Dim HistMin, HistMax, ColorMin, ColorMax As Double
    Dim ColorMinOriginal As Double = 999
    Dim ColorMaxOriginal As Double = 0

    Public Sub New(data As List(Of String), text As String)
        InitializeComponent()
        Me.Text = text
        _Data = Zed.parse(data.ToArray)
        ParseData()
        CreatePlots()
    End Sub

    Private Sub ParseData()
        HistData.Clear()
        ScatterData.Clear()
        ScatterDataX.Clear()
        ScatterDataY.Clear()
        ScatterDataZ.Clear()
        ColorMinOriginal = 999
        ColorMaxOriginal = 0
        ScanScatterData(True)
        ScanScatterData(False)
        HistMin = HistData.Min
        HistMax = HistData.Max
        Dim bounds = Zed.bounds(_Data)
        numColorAxisMin.Value = ColorMinOriginal
        numColorAxisMax.Value = ColorMaxOriginal
    End Sub

    Private Sub ScanScatterData(coord As Boolean)
        Dim heights As New List(Of Double)
        For Each d In _Data
            heights.Add(d.Z)
        Next
        Dim median As Double = Stats.median(heights.ToArray())
        Dim filter As New List(Of Double)
        For Each d In _Data
            Dim Pos As Double
            If coord Then
                Pos = d.X
            Else
                Pos = d.Y
            End If

            Dim bounds = Zed.bounds(_Data)
            Dim bufferX = d.X
            Dim bufferY = d.Y
            Dim bufferZ = d.Z

            If FlipX Then bufferX = bounds(1) - bufferX
            If FlipY Then bufferY = bounds(3) - bufferY
            If FlipZ Then bufferZ = bounds(5) - bufferZ

            If Math.Abs(d.Z - median) / ((d.Z + median) / 2) > 0.05 And _RemoveOutliers Then
                Continue For ' Outliers
            ElseIf Not filter.Contains(Math.Round(Pos, 1) And _RemoveOutliers) Then
                filter.Add(Math.Round(Pos, 1))
                If coord Then
                    ScatterDataX.Add(New ScatterPoint(bufferX, bufferZ))
                Else
                    ScatterDataY.Add(New ScatterPoint(bufferY, bufferZ))
                End If
                ScatterDataZ.Add(New ScatterPoint(d.X, d.Y, 2, bufferZ))
                HistData.Add(d.Z)
                If bufferZ < ColorMinOriginal Then ColorMinOriginal = bufferZ
                If bufferZ > ColorMaxOriginal Then ColorMaxOriginal = bufferZ
            ElseIf Not _RemoveOutliers Then
                If coord Then
                    ScatterDataX.Add(New ScatterPoint(bufferX, bufferZ))
                Else
                    ScatterDataY.Add(New ScatterPoint(bufferY, bufferZ))
                End If
                ScatterDataZ.Add(New ScatterPoint(d.X, d.Y, 2, bufferZ))
                HistData.Add(d.Z)
                If bufferZ < ColorMinOriginal Then ColorMinOriginal = bufferZ
                If bufferZ > ColorMaxOriginal Then ColorMaxOriginal = bufferZ
            End If
        Next
    End Sub

    Private Sub CreatePlots()
        CreateHeatmap()
        CreateHistogram()
        CreateScatterplot()
    End Sub

    Private Sub cbxRemoveOutliers_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRemoveOutliers.CheckedChanged
        RemoveOutliers = Not RemoveOutliers
    End Sub

    Private Sub cbxFlipX_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFlipX.CheckedChanged
        FlipX = Not FlipX
    End Sub

    Private Sub cbxFlipY_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFlipY.CheckedChanged
        FlipY = Not FlipY
    End Sub

    Private Sub cbxFlipZ_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFlipZ.CheckedChanged
        FlipZ = Not FlipZ
    End Sub

    Private Sub numColorAxisMin_ValueChanged(sender As Object, e As EventArgs) Handles numColorAxisMin.ValueChanged
        ColorMin = numColorAxisMin.Value
        CreatePlots()
    End Sub

    Private Sub numColorAxisMax_ValueChanged(sender As Object, e As EventArgs) Handles numColorAxisMax.ValueChanged
        ColorMax = numColorAxisMax.Value
        CreatePlots()
    End Sub

    Private Sub btnResetColorAxes_Click(sender As Object, e As EventArgs) Handles btnResetColorAxes.Click
        numColorAxisMin.Value = ColorMinOriginal
        numColorAxisMax.Value = ColorMaxOriginal
        CreatePlots()
    End Sub

    Private Sub CreateHeatmap()
        Dim plot As New PlotModel
        Dim zScatter As New ScatterSeries()

        Dim myXaxis = New Axes.LinearAxis With {
            .Title = "X Position (mm)",
            .Position = Axes.AxisPosition.Bottom,
            .StartPosition = Convert.ToInt32(FlipX),
            .EndPosition = Convert.ToInt32(Not FlipX)
        }
        Dim myYaxis = New Axes.LinearAxis With {
            .Title = "Y Position (mm)",
            .Position = Axes.AxisPosition.Left,
            .StartPosition = Convert.ToInt32(FlipY),
            .EndPosition = Convert.ToInt32(Not FlipY)
        }
        Dim myZaxis = New Axes.LinearColorAxis With {
            .Title = "Z Position (mm)",
            .Position = Axes.AxisPosition.Right,
            .Key = "Color Axis",
            .Minimum = ColorMin,
            .Maximum = ColorMax
        }

        zScatter.TrackerFormatString = zScatter.TrackerFormatString + vbNewLine + "Z Position (mm): {Value}"

        plot.Series.Add(zScatter)
        plot.Axes.Add(myXaxis)
        plot.Axes.Add(myYaxis)
        plot.Axes.Add(myZaxis)

        zScatter.Points.AddRange(ScatterDataZ.AsEnumerable)
        HeatPlot.Model = plot
    End Sub

    Private Sub CreateHistogram()
        Dim plot As New PlotModel

        HistData.Sort()
        Dim median = Stats.median(HistData.ToArray())
        Dim stdDev = Stats.stdDev(HistData.ToArray())
        Dim my3sig = stdDev * 3
        Dim range = Math.Round((HistData.Max - HistData.Min) * 1000, 1)
        lblStats.Text = "Range = " & range.ToString & " microns   Median = " & String.Format("{0:N3}", median) & " mm   3Sigma = " & String.Format("{0:N3}", my3sig)

        Dim histSeries As New HistogramSeries With {.FillColor = OxyColors.DarkBlue}
        Dim binningOptions = New BinningOptions(BinningOutlierMode.CountOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.IncludeExtremeValues)
        Dim binBreaks = HistogramHelpers.CreateUniformBins(HistMin - 0.0001, HistMax + 0.0001, 10)
        histSeries.Items.AddRange(HistogramHelpers.Collect(HistData, binBreaks, binningOptions))
        plot.Series.Add(histSeries)

        Dim myXaxis = New Axes.LinearAxis With {
            .Title = "Height Measurement (mm)",
            .Position = Axes.AxisPosition.Bottom,
            .StartPosition = Convert.ToInt32(FlipZ),
            .EndPosition = Convert.ToInt32(Not FlipZ)
        }
        Dim myYaxis = New Axes.LinearAxis With {
            .Title = "Relative Frequency",
            .Position = Axes.AxisPosition.Left
        }
        plot.Axes.Add(myXaxis)
        plot.Axes.Add(myYaxis)
        HistPlot.Model = plot
    End Sub

    Private Sub CreateScatterplot()
        Dim plot As New PlotModel

        Dim xScatter As New ScatterSeries With {.MarkerFill = OxyColors.LawnGreen, .MarkerSize = 2}
        xScatter.Points.AddRange(ScatterDataX.AsEnumerable)

        Dim yScatter As New ScatterSeries With {.MarkerFill = OxyColors.DarkBlue, .MarkerSize = 2}
        yScatter.Points.AddRange(ScatterDataY.AsEnumerable)

        plot.Series.Add(xScatter)
        plot.Series.Add(yScatter)

        Dim myXaxis = New Axes.LinearAxis With {
            .Title = "Position (mm)",
            .Position = Axes.AxisPosition.Bottom
        }
        Dim myYaxis = New Axes.LinearAxis With {
            .Title = "Height Measurement (mm)",
            .Position = Axes.AxisPosition.Left,
            .StartPosition = Convert.ToInt32(FlipZ),
            .EndPosition = Convert.ToInt32(Not FlipZ)
        }
        plot.Axes.Add(myXaxis)
        plot.Axes.Add(myYaxis)
        ZedPlot.Model = plot
    End Sub

    Private Sub btnSaveWindow_Click(sender As Object, e As EventArgs) Handles btnSaveWindow.Click
        Using sfd As New SaveFileDialog() With {.Filter = "PNG Image|*.png", .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop}
            If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim bmp As New Bitmap(Width, Height)
                DrawToBitmap(bmp, New Rectangle(0, 0, Width, Height))
                bmp.Save(sfd.FileName, Imaging.ImageFormat.Png)
            End If
        End Using
    End Sub
End Class