Public Class DefaultReportViewer
    Private ReadOnly _dataSource As DataTable

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(dataSource As DataTable)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _dataSource = dataSource
    End Sub

    Private Sub DefaultReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _dataSource IsNot Nothing AndAlso
            Not _dataSource?.Rows.OfType(Of DataRow).Any() Then

            MessageBox.Show("No data found.",
                    String.Empty,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
        End If
    End Sub

End Class