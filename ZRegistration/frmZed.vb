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

    Dim Data As Zed.Position()
    Dim LastData As List(Of Zed.Position)
    Dim HistData As New List(Of Double)
    Dim ScatterDataX, ScatterDataY, ScatterDataZ As New List(Of ScatterPoint)
    Dim HistMin, HistMax As Double
    Dim Initialized As Boolean

    ' Theta Info
    Dim XLineAngle As Double
    Dim YLineAngle As Double
    Dim XPlaneAngle As Double
    Dim YPlaneAngle As Double
    Dim CustomAxes As Double()
    Dim UseCustomAxes As Boolean

    Public Sub New(selectedObject As cScan, userSetAxes As Double(), userSetAxesEnabled As Boolean)
        InitializeComponent()
        CustomAxes = userSetAxes
        UseCustomAxes = userSetAxesEnabled
        Text = selectedObject.Name
        Data = selectedObject.Data.ToArray()
        CreatePlots(initialPlot:=True)
        Initialized = True
        Show()
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
        Dim bounds = Zed.bounds(Data)
        For Each d As Zed.Position In Data
            Dim adjX = d.X
            Dim adjY = d.Y
            Dim adjZ = d.Z

            If FlipX Then adjX = bounds(1) - adjX
            If FlipY Then adjY = bounds(3) - adjY
            If FlipZ Then adjZ = bounds(5) - adjZ

            UserData.Add(New Zed.Position(d.Time, adjX, adjY, adjZ))
        Next

        Dim TiltData = UserData
        Dim XLine = Zed.dataLineFit(UserData.ToArray(), 0)
        Dim YLine = Zed.dataLineFit(UserData.ToArray(), 1)
        XLineAngle = XLine.Item1 * Math.Sign(XLine.Item2)
        YLineAngle = YLine.Item1 * Math.Sign(YLine.Item2)
        Dim PlaneThetas = Zed.dataPlaneFit(UserData.ToArray())
        XPlaneAngle = PlaneThetas.Item1
        YPlaneAngle = PlaneThetas.Item2
        If (RemoveTilt) Then
            TiltData = New List(Of Zed.Position)
            For Each d In UserData
                TiltData.Add(New Zed.Position(d.Time, d.X, d.Y, d.Z - (d.X * XLine.Item2) - (d.Y * YLine.Item2)))
            Next
        End If

        Dim FilteredData = TiltData
        Dim outlierRemovalLevel As Integer = OutlierLevelScrollBar.Value
        If (outlierRemovalLevel > 0) Then
            FilteredData = New List(Of Zed.Position)
            Dim zData = Zed.getAxis(TiltData.ToArray(), 2)
            Dim binningOptions = New BinningOptions(BinningOutlierMode.CountOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.IncludeExtremeValues)
            Dim binBreaks = HistogramHelpers.CreateUniformBins(zData.Min() - 0.0001, zData.Max() + 0.0001, 10)
            Dim histItems = HistogramHelpers.Collect(zData, binBreaks, binningOptions)
            For Each d As Zed.Position In TiltData
                For Each bin As HistogramItem In histItems
                    If bin.RangeStart <= d.Z And bin.RangeEnd >= d.Z And bin.Count > 5 * outlierRemovalLevel Then
                        FilteredData.Add(d)
                    End If
                Next
            Next
        End If

        If FilteredData.Count = 0 Then
            FilteredData = LastData
        Else
            LastData = FilteredData
        End If

        For Each d In FilteredData
            ScatterDataX.Add(New ScatterPoint(d.X, d.Z * 1000.0))
            ScatterDataY.Add(New ScatterPoint(d.Y, d.Z * 1000.0))
            ScatterDataZ.Add(New ScatterPoint(d.X, d.Y, 2, d.Z * 1000.0))
            HistData.Add(d.Z * 1000.0)
        Next

        lblNumData.Text = String.Format("{0}/{1} Points Removed", Data.Count() - FilteredData.Count(), Data.Count())
    End Sub

    Private Sub CreateHeatmap()
        Dim plot As New PlotModel
        Dim zScatter As New ScatterSeries()
        zScatter.TrackerFormatString = zScatter.TrackerFormatString + vbNewLine + "Z Position (μm): {Value}"
        plot.Series.Add(zScatter)

        Dim xAxis As New LinearAxis With {
            .Title = "X Position (mm)",
            .Position = AxisPosition.Bottom
        }

        If UseCustomAxes Then
            xAxis.Minimum = CustomAxes(0)
            xAxis.Maximum = CustomAxes(1)
        End If

        Dim yAxis As New LinearAxis With {
            .Title = "Y Position (mm)",
            .Position = AxisPosition.Left
        }

        If UseCustomAxes Then
            yAxis.Minimum = CustomAxes(2)
            yAxis.Maximum = CustomAxes(3)
        End If

        Dim zAxis As New LinearColorAxis With {
            .Title = "Z Position (μm)",
            .Position = AxisPosition.Right,
            .Key = "Color Axis",
            .Maximum = HistMax,
            .Minimum = HistMin
        }

        If UseCustomAxes Then
            zAxis.Minimum = CustomAxes(4)
            zAxis.Maximum = CustomAxes(5)
        Else
            zAxis.Minimum = HistMin
            zAxis.Maximum = HistMax
        End If

        plot.Axes.Add(xAxis)
        plot.Axes.Add(yAxis)
        plot.Axes.Add(zAxis)
        zScatter.Points.AddRange(ScatterDataZ.AsEnumerable)
        HeatPlot.Model = plot
    End Sub

    Private Sub CreateHistogram()
        Dim plot As New PlotModel With {.TitleFontSize = 10, .TitleHorizontalAlignment = TitleHorizontalAlignment.CenteredWithinView}

        HistData.Sort()
        Dim median = Stats.median(HistData.ToArray())
        Dim stdDev = Stats.stdDev(HistData.ToArray())
        Dim my3sig = stdDev * 3
        Dim range = HistData.Max - HistData.Min
        plot.Title = String.Format("Range = {0} μm   Median = {1} μm   3Sigma = {2} μm", Math.Round(range, 1), Math.Round(median, 1), Math.Round(my3sig, 1))

        Dim histSeries As New HistogramSeries With {.FillColor = OxyColors.DarkBlue}
        Dim binningOptions = New BinningOptions(BinningOutlierMode.CountOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.IncludeExtremeValues)
        Dim binBreaks = HistogramHelpers.CreateUniformBins(HistMin - 0.0001, HistMax + 0.0001, 10)
        histSeries.Items.AddRange(HistogramHelpers.Collect(HistData, binBreaks, binningOptions))
        plot.Series.Add(histSeries)

        plot.Axes.Add(New LinearAxis With {.Title = "Height Measurement (μm)", .Position = AxisPosition.Bottom})
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

        Dim xAxis As New LinearAxis With {
            .Title = "Position (mm)",
            .Position = AxisPosition.Bottom
        }

        If UseCustomAxes Then
            If coord Then
                xAxis.Minimum = CustomAxes(0)
                xAxis.Maximum = CustomAxes(1)
            Else
                xAxis.Minimum = CustomAxes(2)
                xAxis.Maximum = CustomAxes(3)
            End If
        End If

        Dim yAxis As New LinearAxis With {
            .Title = "Y Height (μm)",
            .Position = AxisPosition.Left
        }

        If UseCustomAxes Then
            yAxis.Minimum = CustomAxes(4)
            yAxis.Maximum = CustomAxes(5)
        End If

        plot.Axes.Add(xAxis)
        plot.Axes.Add(yAxis)

        Dim rSquared = Zed.rSquared(polyScatter.Points.ToArray(), scatterData.ToArray())
        If coord Then
            plot.Title = String.Format("X Direction     R² = {0}", rSquared)
            ScatterXvsZ.Model = plot
        Else
            plot.Title = String.Format("Y Direction     R² = {0}", rSquared)
            ScatterYvsZ.Model = plot
        End If
    End Sub

    Private Sub cbxView_CheckedChanged(sender As Object, e As EventArgs) Handles cbxView.CheckedChanged
        FlipX = Not FlipX
        FlipZ = Not FlipZ

        If FlipX Then
            cbxView.Text = "SPOT View"
        Else
            cbxView.Text = "Printer View"
        End If
    End Sub

    Private Sub cbxRemoveTilt_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRemoveTilt.CheckedChanged
        RemoveTilt = Not RemoveTilt
    End Sub

    Private Sub OutlierLevelScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles OutlierLevelScrollBar.Scroll
        CreatePlots()
        lblOutlierRemovalLevel.Text = String.Format("Outlier Removal Level {0}", OutlierLevelScrollBar.Value)
    End Sub

    Private Sub btnThetaInfo_Click(sender As Object, e As EventArgs) Handles btnThetaInfo.Click
        Dim THXlinear = Math.Round(YLineAngle, 3)
        Dim THYlinear = Math.Round(XLineAngle, 3)
        Dim THXplanar = Math.Round(YPlaneAngle, 3)
        Dim THYplanar = Math.Round(XPlaneAngle, 3)
        Dim result As DialogResult = MessageBox.Show($"Evalutation Only:

Linear
    THX: {THXlinear:#0.000} deg
    THY: {THYlinear:#0.000} deg

Planar
    THX: {THXplanar:#0.000} deg
    THY: {THYplanar:#0.000} deg", "Press OK to copy as CSV", MessageBoxButtons.OKCancel)
        If result = DialogResult.OK Then
            Clipboard.SetText($"{THXlinear:#0.000}{vbTab}{THYlinear:#0.000}{vbTab}{THXplanar:#0.000}{vbTab}{THYplanar:#0.000}")
        End If
    End Sub

    Private Sub btnCopyData_Click(sender As Object, e As EventArgs) Handles btnCopyData.Click
        Dim builder As New Text.StringBuilder
        For Each scatter As ScatterPoint In ScatterDataZ
            builder.Append(String.Format("{0}{1}{2}{3}{4}{5}",
                                    scatter.X, vbTab, scatter.Y, vbTab, scatter.Value / 1000.0, vbNewLine))
        Next
        Clipboard.SetText(builder.ToString())
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

    Private Sub btnCopyWindow_Click(sender As Object, e As EventArgs) Handles btnCopyWindow.Click
        Dim bmp As New Bitmap(Width, Height)
        DrawToBitmap(bmp, New Rectangle(0, 0, Width, Height))
        Clipboard.SetImage(bmp)
    End Sub
End Class