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
            CreatePlots()
        End Set
    End Property

    Private _RemoveBorders As Boolean = False
    Public Property RemoveBorders() As Boolean
        Get
            Return _RemoveBorders
        End Get
        Set(value As Boolean)
            _RemoveBorders = value
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
            CreatePlots()
        End Set
    End Property

    Private _ColorMin As Double
    Public Property ColorMin() As Double
        Get
            Return _ColorMin
        End Get
        Set(value As Double)
            _ColorMin = value
        End Set
    End Property

    Private _ColorMax As Double
    Public Property ColorMax() As Double
        Get
            Return _ColorMax
        End Get
        Set(value As Double)
            _ColorMax = value
        End Set
    End Property

    Private _PolyX As Double()
    Public Property PolyX() As Double()
        Get
            Return _PolyX
        End Get
        Set(ByVal value As Double())
            _PolyX = value
        End Set
    End Property

    Private _PolyY As Double()
    Public Property PolyY() As Double()
        Get
            Return _PolyY
        End Get
        Set(ByVal value As Double())
            _PolyY = value
        End Set
    End Property

    Dim _Data
    Dim HistData As New List(Of Double)
    Dim ScatterDataX, ScatterDataY, ScatterDataZ As New List(Of ScatterPoint)
    Dim HistMin, HistMax As Double
    Dim ColorMinOriginal As Double = 999
    Dim ColorMaxOriginal As Double = -999
    Dim PercentBorderRemoval As Double = 10
    Dim PercentOutlier As Double = 5

    Public Sub New(data As List(Of String), text As String)
        InitializeComponent()
        Me.Text = text
        _Data = Zed.parse(data.ToArray)
        CreatePlots()
    End Sub

    Private Sub CreatePlots(Optional preserveColors As Boolean = False)
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        If Not preserveColors Then
            ColorMin = 0
            ColorMax = 0
        End If

        ParseData(preserveColors)
        CreateHeatmap()
        CreateHistogram()
        CreateScatterplot(True)
        CreateScatterplot(False)

        Cursor = Cursors.Default
    End Sub

    Private Sub ParseData(Optional preserveColors As Boolean = False)
        ' Reset globals
        HistData.Clear()
        ScatterDataX.Clear()
        ScatterDataY.Clear()
        ScatterDataZ.Clear()
        ColorMinOriginal = 999
        ColorMaxOriginal = -999

        ' Recreate data sets
        ScanScatterData(True)
        ScanScatterData(False)
        HistMin = HistData.Min
        HistMax = HistData.Max

        If Not preserveColors Then
            ColorMin = ColorMinOriginal
            numColorAxisMin.Value = ColorMinOriginal
            ColorMax = ColorMaxOriginal
            numColorAxisMax.Value = ColorMaxOriginal
        End If
    End Sub

    Private Sub ScanScatterData(coord As Boolean)
        Dim bounds = Zed.bounds(_Data)
        Dim median As Double = Stats.median(Zed.getAxis(_Data, 2).ToArray())
        Dim filter As New List(Of Double)
        Dim center As PointF
        Dim radius As Double
        Dim isCircular = True

        If RemoveBorders Then
            center = New PointF((bounds(0) + bounds(1)) / 2, (bounds(2) + bounds(3)) / 2)
            radius = Math.Max(bounds(1) - bounds(0), bounds(3) - bounds(2)) / 2
            For Each d In _Data
                Dim distance = MathNet.Numerics.Distance.Euclidean(New Double() {d.X, d.Y}, New Double() {center.X, center.Y})
                If distance > radius * (1 + PercentBorderRemoval / 100) Then
                    isCircular = False
                    Exit For
                End If
            Next
        End If

        For Each d In _Data
            Dim Pos As Double
            If coord Then
                Pos = d.X
            Else
                Pos = d.Y
            End If

            If RemoveBorders Then
                If isCircular Then
                    Dim distance = MathNet.Numerics.Distance.Euclidean(New Double() {d.X, d.Y}, New Double() {center.X, center.Y})
                    If distance > radius * (1 - PercentBorderRemoval / 100) Then
                        Continue For
                    End If
                Else
                    If d.X - bounds(0) < (bounds(1) - bounds(0)) * (PercentBorderRemoval / 100) Then Continue For
                    If bounds(1) - d.X < (bounds(1) - bounds(0)) * (PercentBorderRemoval / 100) Then Continue For
                    If d.Y - bounds(2) < (bounds(3) - bounds(2)) * (PercentBorderRemoval / 100) Then Continue For
                    If bounds(3) - d.Y < (bounds(3) - bounds(2)) * (PercentBorderRemoval / 100) Then Continue For
                End If
            End If

            Dim adjX = d.X
            Dim adjY = d.Y
            Dim adjZ = d.Z

            If FlipX Then adjX = bounds(1) - adjX
            If FlipY Then adjY = bounds(3) - adjY
            If FlipZ Then adjZ = bounds(5) - adjZ

            If ColorMin <> 0 And ColorMax <> 0 Then
                If adjZ < ColorMin Or adjZ > ColorMax Then Continue For
            End If

            If Math.Abs(d.Z - median) / ((d.Z + median) / 2) > (PercentOutlier / 100) And RemoveOutliers Then
                Continue For ' Outliers
            ElseIf Not filter.Contains(Math.Round(Pos, 1) And RemoveOutliers) Then
                filter.Add(Math.Round(Pos, 1))
                If coord Then
                    ScatterDataX.Add(New ScatterPoint(adjX, adjZ))
                Else
                    ScatterDataY.Add(New ScatterPoint(adjY, adjZ))
                End If
                ScatterDataZ.Add(New ScatterPoint(adjX, adjY, 2, adjZ))
                HistData.Add(adjZ)
                If adjZ < ColorMinOriginal Then ColorMinOriginal = adjZ
                If adjZ > ColorMaxOriginal Then ColorMaxOriginal = adjZ
            ElseIf Not RemoveOutliers Then
                If coord Then
                    ScatterDataX.Add(New ScatterPoint(adjX, adjZ))
                Else
                    ScatterDataY.Add(New ScatterPoint(adjY, adjZ))
                End If
                ScatterDataZ.Add(New ScatterPoint(adjX, adjY, 2, adjZ))
                HistData.Add(adjZ)
                If adjZ < ColorMinOriginal Then ColorMinOriginal = adjZ
                If adjZ > ColorMaxOriginal Then ColorMaxOriginal = adjZ
            End If
        Next
    End Sub

    Private Sub CreateHeatmap()
        Dim plot As New PlotModel
        Dim zScatter As New ScatterSeries()
        zScatter.TrackerFormatString = zScatter.TrackerFormatString + vbNewLine + "Z Position (mm): {Value}"
        plot.Series.Add(zScatter)
        plot.Axes.Add(New LinearAxis With {.Title = "X Position (mm)", .Position = AxisPosition.Bottom})
        plot.Axes.Add(New LinearAxis With {.Title = "Y Position (mm)", .Position = AxisPosition.Left})
        plot.Axes.Add(New LinearColorAxis With {
            .Title = "Z Position (mm)",
            .Position = AxisPosition.Right,
            .Key = "Color Axis",
            .Minimum = ColorMin,
            .Maximum = ColorMax
        })
        zScatter.Points.AddRange(ScatterDataZ.AsEnumerable)
        HeatPlot.Model = plot
    End Sub

    Private Sub CreateHistogram()
        Dim plot As New PlotModel With {.TitleFontSize = 10, .TitleHorizontalAlignment = TitleHorizontalAlignment.CenteredWithinView}

        HistData.Sort()
        Dim median = Stats.median(HistData.ToArray())
        Dim stdDev = Stats.stdDev(HistData.ToArray())
        Dim my3sig = stdDev * 3
        Dim range = Math.Round((HistData.Max - HistData.Min) * 1000, 1)
        plot.Title = "Range = " & range.ToString & " μm   Median = " & String.Format("{0:N3}", median) & " mm   3Sigma = " & String.Format("{0:N3}", my3sig)

        Dim histSeries As New HistogramSeries With {.FillColor = OxyColors.DarkBlue}
        Dim binningOptions = New BinningOptions(BinningOutlierMode.CountOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.IncludeExtremeValues)
        Dim binBreaks = HistogramHelpers.CreateUniformBins(HistMin - 0.0001, HistMax + 0.0001, 10)
        histSeries.Items.AddRange(HistogramHelpers.Collect(HistData, binBreaks, binningOptions))
        plot.Series.Add(histSeries)

        plot.Axes.Add(New LinearAxis With {.Title = "Height Measurement (mm)", .Position = AxisPosition.Bottom})
        plot.Axes.Add(New LinearAxis With {.Title = "Relative Frequency", .Position = AxisPosition.Left})
        HistPlot.Model = plot
    End Sub

    Private Sub CreateScatterplot(coord As Boolean)
        Dim plot As New PlotModel With {.TitleFontSize = 10, .TitleHorizontalAlignment = TitleHorizontalAlignment.CenteredWithinView}

        Dim scatterData As List(Of ScatterPoint)
        If coord Then
            scatterData = ScatterDataX
        Else
            scatterData = ScatterDataY
        End If

        Dim scatter As New ScatterSeries With {.MarkerFill = OxyColors.DarkBlue, .MarkerSize = 2}
        scatter.Points.AddRange(scatterData.AsEnumerable)

        Dim poly As Double() = Zed.scatterPolynomial(scatterData.ToArray())
        If coord Then
            PolyX = poly
        Else
            PolyY = poly
        End If

        Dim polyScatter As New LineSeries With {.Color = OxyColors.LawnGreen, .StrokeThickness = 5}
        Dim scatterCopy As ScatterPoint() = scatterData.ToArray().Clone()
        Dim scatterList As List(Of ScatterPoint) = scatterCopy.ToList().OrderBy(Function(x) x.X).ToList()
        For Each point In scatterList
            Dim val = poly(0) + poly(1) * point.X + poly(2) * Math.Pow(point.X, 2) + poly(3) * Math.Pow(point.X, 3)
            polyScatter.Points.Add(New DataPoint(point.X, val))
        Next

        plot.Series.Add(scatter)
        plot.Series.Add(polyScatter)
        plot.Axes.Add(New LinearAxis With {.Title = "Position (mm)", .Position = AxisPosition.Bottom})
        plot.Axes.Add(New LinearAxis With {.Title = "Height (mm)", .Position = AxisPosition.Left})

        Dim rSquared = Zed.rSquared(polyScatter.Points.ToArray(), scatterData.ToArray())
        If coord Then
            plot.Title = String.Format("X Direction     R² = {0}", rSquared)
            ScatterXvsZ.Model = plot
        Else
            plot.Title = String.Format("Y Direction     R² = {0}", rSquared)
            ScatterYvsZ.Model = plot
        End If
    End Sub

    Private Sub cbxRemoveOutliers_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRemoveOutliers.CheckedChanged
        RemoveOutliers = Not RemoveOutliers
    End Sub

    Private Sub cbxRemoveBorders_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRemoveBorders.CheckedChanged
        RemoveBorders = Not RemoveBorders
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

    Private Sub numColorAxisMin_ValueChanged(sender As Object, e As EventArgs) Handles numColorAxisMin.Click
        If (Math.Abs(numColorAxisMin.Value - ColorMax) < 0.001) Then
            numColorAxisMin.Value = ColorMin
        Else
            ColorMin = numColorAxisMin.Value
            CreatePlots(preserveColors:=True)
        End If
    End Sub

    Private Sub numColorAxisMax_ValueChanged(sender As Object, e As EventArgs) Handles numColorAxisMax.Click
        If (Math.Abs(numColorAxisMax.Value - ColorMin) < 0.001) Then
            numColorAxisMax.Value = ColorMax
        Else
            ColorMax = numColorAxisMax.Value
            CreatePlots(preserveColors:=True)
        End If
    End Sub

    Private Sub btnResetColorAxes_Click(sender As Object, e As EventArgs) Handles btnResetColorAxes.Click
        numColorAxisMin.Value = ColorMinOriginal
        numColorAxisMax.Value = ColorMaxOriginal
        CreatePlots()
    End Sub

    Private Sub btnCopyTrendline_Click(sender As Object, e As EventArgs) Handles btnCopyTrendline.Click
        Dim output As String = String.Format("{0}x² + {1}x + {2}{3}{4}y² + {5}y + {6}",
                                             PolyX(2), PolyX(1), PolyX(0), vbNewLine, PolyY(2), PolyY(1), PolyY(0))
        Clipboard.SetText(output)
    End Sub

    Private Sub btnCopyData_Click(sender As Object, e As EventArgs) Handles btnCopyData.Click
        Dim output As String = ""
        For Each scatter As ScatterPoint In ScatterDataZ
            output += String.Format("{0}{1}{2}{3}{4}{5}",
                                    scatter.X, vbTab, scatter.Y, vbTab, scatter.Value, vbNewLine)
        Next
        Clipboard.SetText(output)
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