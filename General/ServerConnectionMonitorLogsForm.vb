Public Class ServerConnectionMonitorLogsForm
    Private ReadOnly _serverConnectionLogs As List(Of String)

    Public Sub New(serverConnectionLogs As List(Of String))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _serverConnectionLogs = serverConnectionLogs

    End Sub

    Private Sub ServerConnectionMonitorLogsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.Items.AddRange(_serverConnectionLogs.OrderByDescending(Function(t) t).Select(Function(x) x).ToArray())

        If If(_serverConnectionLogs?.Any(), False) Then ListBox1.SelectedIndex = 0

    End Sub

End Class
