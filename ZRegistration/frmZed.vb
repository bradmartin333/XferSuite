Imports OxyPlot
Imports OxyPlot.Axes
Imports OxyPlot.Series
Imports XferHelper

Public Class frmZed
    Private _FlipX As Boolean = True
    Public Property FlipX() As Boolean
        Get
            Return _FlipX
        End Get
        Set(value As Boolean)
            _FlipX = value
            CreatePlots()
        End Set
    End Property

    Private _FlipY As Boolean = True
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

    Private _RemoveTilt As Boolean = False
    Public Property RemoveTilt() As Boolean
        Get
            Return _RemoveTilt
        End Get
        Set(value As Boolean)
            _RemoveTilt = value
            CreatePlots()
        End Set
    End Property

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

    Dim _Data
    Dim HistData As New List(Of Double)
    Dim ScatterDataX, ScatterDataY, ScatterDataZ As New List(Of ScatterPoint)
    Dim HistMin, HistMax As Double
    Dim Initialized As Boolean

    Public Sub New(data As List(Of String), text As String)
        InitializeComponent()
        Me.Text = text
        _Data = Zed.parse(data.ToArray)
        CreatePlots(initialPlot:=True)
        Initialized = True
    End Sub

    Private Sub CreatePlots(Optional initialPlot As Boolean = False)
        If Not Initialized And Not initialPlot Then Return

        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        ParseData()
        CreateHeatmap()
        CreateHistogram()
        CreateScatterplot(True)
        CreateScatterplot(False)

        Cursor = Cursors.Default
    End Sub

    Private Sub ParseData()
        ' Reset globals
        HistData.Clear()
        ScatterDataX.Clear()
        ScatterDataY.Clear()
        ScatterDataZ.Clear()

        ' Recreate data sets
        ScanScatterData()
        HistMin = HistData.Min()
        HistMax = HistData.Max()
    End Sub

    Private Sub ScanScatterData()
        Dim UserData = New List(Of Zed.Position)
        Dim bounds = Zed.bounds(_Data)
        For Each d As Zed.Position In _Data
            Dim adjX = d.X
            Dim adjY = d.Y
            Dim adjZ = d.Z

            If FlipX Then adjX = bounds(1) - adjX
            If FlipY Then adjY = bounds(3) - adjY
            If FlipZ Then adjZ = bounds(5) - adjZ

            UserData.Add(New Zed.Position(d.Time, adjX, adjY, adjZ))
        Next

        Dim TiltData = UserData
        If (RemoveTilt) Then
            TiltData = New List(Of Zed.Position)
            Dim XLine = Zed.dataLineFit(UserData.ToArray(), 0)
            Dim YLine = Zed.dataLineFit(UserData.ToArray(), 1)
            For Each d In UserData
                TiltData.Add(New Zed.Position(d.Time, d.X, d.Y, d.Z - (d.X * XLine.Item2) - (d.Y * YLine.Item2)))
            Next
        End If

        Dim FilteredData = TiltData
        If (RemoveOutliers) Then
            FilteredData = New List(Of Zed.Position)
            Dim zData = Zed.getAxis(TiltData.ToArray(), 2)
            Dim binningOptions = New BinningOptions(BinningOutlierMode.CountOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.IncludeExtremeValues)
            Dim binBreaks = HistogramHelpers.CreateUniformBins(zData.Min() - 0.0001, zData.Max() + 0.0001, 10)
            Dim histItems = HistogramHelpers.Collect(zData, binBreaks, binningOptions)
            For Each d As Zed.Position In TiltData
                For Each bin As HistogramItem In histItems
                    If bin.RangeStart <= d.Z And bin.RangeEnd >= d.Z And bin.Height > 5 Then
                        FilteredData.Add(d)
                    End If
                Next
            Next
        End If

        For Each d In FilteredData
            ScatterDataX.Add(New ScatterPoint(d.X, d.Z))
            ScatterDataY.Add(New ScatterPoint(d.Y, d.Z))
            ScatterDataZ.Add(New ScatterPoint(d.X, d.Y, 2, d.Z))
            HistData.Add(d.Z)
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
            .Maximum = HistMax,
            .Minimum = HistMin
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

    Private Sub cbxView_CheckedChanged(sender As Object, e As EventArgs) Handles cbxView.CheckedChanged
        FlipX = Not FlipX

        If FlipX Then
            cbxView.Text = "SPOT View"
        Else
            cbxView.Text = "Printer View"
        End If
    End Sub

    Private Sub cbxRemoveTilt_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRemoveTilt.CheckedChanged
        RemoveTilt = Not RemoveTilt
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