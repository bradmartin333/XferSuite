Public Class cScan
    Public Property Index As Integer
    Public Property ShortDate As String
    Public Property Time As String
    Public Property Name As String
    Public Property Temp As Double
    Public Property RH As Double
    Public Property Data As List(Of XferHelper.Zed.Position) = New List(Of XferHelper.Zed.Position)
End Class
