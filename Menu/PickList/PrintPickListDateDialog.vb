Public Class PrintPickListDateDialog
    Private ReadOnly _date As Date

    Public Sub New([date] As Date)

        _date = [date]
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public ReadOnly Property SelectedDate As String

    Private Sub PrintPickListDateDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = _date
        DateTimePicker1.MinDate = _date

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        _SelectedDate = DateTimePicker1.Value.Date
    End Sub

End Class