Public Interface IReportProvider
    Property Name As String
    Property IsHidden As Boolean

    Function RunAsync() As Task

End Interface