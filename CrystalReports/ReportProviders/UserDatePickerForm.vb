Public Class UserDatePickerForm
    Private ReadOnly _isDateOnlyConfig As Boolean
    Public ReadOnly Property IsDateOnly As Boolean
    Public ReadOnly Property IsDateRange As Boolean
    Public ReadOnly Property StartDate As Date
    Public ReadOnly Property EndDate As Date?

    Public Sub New(Optional isDateOnlyConfig As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _isDateOnlyConfig = isDateOnlyConfig
    End Sub

    Private Sub UserDatePickerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker2.Visible = Not _isDateOnlyConfig
        If _isDateOnlyConfig Then Label1.Text = "Pick Date"
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker2.Checked AndAlso
            Not DateTimePicker2.MinDate.Date = DateTimePicker1.Value.Date Then

            Dim dateValue = DateTimePicker1.Value

            DateTimePicker2.MinDate = dateValue
            DateTimePicker2.Value = dateValue
        End If

        UpdateDisplayInfo()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        If DateTimePicker2.Checked Then
            DateTimePicker1_ValueChanged(DateTimePicker1, New EventArgs())
        End If

        UpdateDisplayInfo()
    End Sub

    Private Sub UpdateDisplayInfo()
        If DateTimePicker2.Checked Then
            Label2.Text = $"Dates between {DateTimePicker1.Value:MMM d, yyyy} and {DateTimePicker2.Value:MMM d, yyyy}"
        Else
            Label2.Text = $"Picked Date: {DateTimePicker1.Value:MMM d, yyyy}"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        _IsDateOnly = Not DateTimePicker2.Checked
        _IsDateRange = DateTimePicker2.Checked

        _StartDate = DateTimePicker1.Value.Date
        If _IsDateRange Then _EndDate = DateTimePicker2.Value.Date

        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DialogResult = DialogResult.Cancel
    End Sub

End Class