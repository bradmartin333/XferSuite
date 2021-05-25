Imports OxyPlot
Imports OxyPlot.Axes
Imports OxyPlot.Series
Imports XferHelper

Public Class frmZed
    Dim PlotData, ZedData
    Dim Min, Max As PointF
    Dim HistData, Outliers As New List(Of Double)
    Dim ScatterDataX, ScatterDataY As New List(Of ScatterPoint)
    Dim HistMin, HistMax, ColorMin, ColorMax, ColorMinOriginal, ColorMaxOriginal As Double

    Public Sub New(data As List(Of String), text As String)
        InitializeComponent()
        Me.Text = text
        ParseData(data)
        CreatePlots()
    End Sub

    Private Sub ParseData(data As List(Of String))
        ZedData = Zed.parse(data.ToArray)
        Dim bounds = Zed.bounds(ZedData)
        Min = New PointF(bounds(0), bounds(2))
        Max = New PointF(bounds(1), bounds(3))
        Dim PlotData(Math.Round(Max.X - Min.X), Math.Round(Max.Y - Min.Y)) As Double

        For Each d In ZedData
            If d.X > Max.X OrElse d.Y > Max.Y OrElse d.X < Min.X OrElse d.Y < Min.Y Then Continue For
            PlotData(Math.Round(d.X - Min.X), Math.Round(d.Y - Min.Y)) = d.H
        Next

        Dim BufferScatterDataX = Zed.scatter(ZedData, True)
        ScanScatterData(BufferScatterDataX, True)
        Dim BufferScatterDataY = Zed.scatter(ZedData, False)
        ScanScatterData(BufferScatterDataY, False)

        Dim cleanHeightData As New List(Of Double)
        For i = 0 To Math.Round(Max.X - Min.X)
            For j = 0 To Math.Round(Max.Y - Min.Y)
                If PlotData(i, j) = 0 Or Outliers.Contains(PlotData(i, j)) Then
                    PlotData(i, j) = Double.NaN
                Else
                    cleanHeightData.Add(PlotData(i, j))
                End If
            Next
        Next
        Me.PlotData = PlotData

        HistMin = HistData.Min
        HistMax = HistData.Max

        ColorMinOriginal = cleanHeightData.Min()
        ColorMaxOriginal = cleanHeightData.Max()
        numColorAxisMin.Value = ColorMinOriginal
        numColorAxisMax.Value = ColorMaxOriginal
    End Sub

    Private Sub ScanScatterData(data As Object, coord As Boolean)
        Dim heights As New List(Of Double)
        For Each d In data
            heights.Add(d.H)
        Next
        Dim median As Double = Stats.median(heights.ToArray())
        Dim filter As New List(Of Double)
        For Each d In data
            If Math.Abs(d.H - median) / ((d.H + median) / 2) > 0.05 Then
                Outliers.Add(d.H)
            ElseIf Not filter.Contains(Math.Round(d.Pos, 1)) Then
                filter.Add(Math.Round(d.Pos, 1))
                If coord Then
                    ScatterDataX.Add(New ScatterPoint(d.Pos, d.H))
                Else
                    ScatterDataY.Add(New ScatterPoint(d.Pos, d.H))
                End If
                HistData.Add(d.H)
            End If
        Next
    End Sub

    Private Sub CreatePlots()
        Dim plot As New PlotModel
        plot.Axes.Add(New LinearColorAxis With {.Position = AxisPosition.Right,
                                                .Palette = OxyPalettes.BlueWhiteRed31,
                                                .HighColor = OxyColors.Gray,
                                                .LowColor = OxyColors.Black,
                                                .Minimum = ColorMin,
                                                .Maximum = ColorMax})
        plot.Series.Add(CreateHeatMap())
        HeatPlot.Model = plot

        Dim myXaxis = New Axes.LinearAxis With {
            .Title = "X Coordinate (mm)",
            .Position = Axes.AxisPosition.Bottom
        }
        Dim myYaxis = New Axes.LinearAxis With {
            .Title = "Y Coordinate (mm)",
            .Position = Axes.AxisPosition.Left
        }
        plot.Axes.Add(myXaxis)
        plot.Axes.Add(myYaxis)

        CreateHistogram()
        CreateScatterplot()
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
            .Position = Axes.AxisPosition.Bottom
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
            .StartPosition = 1,
            .EndPosition = 0
        }
        plot.Axes.Add(myXaxis)
        plot.Axes.Add(myYaxis)
        ZedPlot.Model = plot
    End Sub

    Private Function CreateHeatMap() As HeatMapSeries
        Try
            Dim hms = New HeatMapSeries With {
                .CoordinateDefinition = HeatMapCoordinateDefinition.Center,
                .X1 = Max.X,
                .X0 = Min.X,
                .Y0 = Max.Y,
                .Y1 = Min.Y,
                .Data = PlotData,
                .Interpolate = True
            }
            Dim x = hms.Data
            Return hms
        Catch ex As Exception
            MsgBox("Field too small for heat map plotting", MsgBoxStyle.OkOnly, "Load Zed Data")
            Return New HeatMapSeries
        End Try
    End Function

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