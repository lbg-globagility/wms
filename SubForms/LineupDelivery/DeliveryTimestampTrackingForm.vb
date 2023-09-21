Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Interfaces.Repositories
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class DeliveryTimestampTrackingForm
    Private ReadOnly _lineupId As Integer
    Private _lineup As WarehouseManagementSystem.Core.Entities.Lineup

    Public Sub New(lineupId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _lineupId = lineupId

        dtpTime.ShowCheckBox = True
    End Sub

    Private Async Sub DeliveryTimestampTrackingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lineupRepository = MainServiceProvider.GetRequiredService(Of ILineupRepository)
        _lineup = Await lineupRepository.GetByIdAsync(id:=_lineupId)
        If _lineup IsNot Nothing Then
            dtpTime.Checked = _lineup.ConfirmedDeliveryTimeStamp IsNot Nothing
            dtpDate.MinDate = If(_lineup.LineUpDate, Date.Now)

            dtpDate.Value = _lineup.ConfirmedDeliveryTimeStamp.Value.Date
            dtpTime.Value = _lineup.ConfirmedDeliveryTimeStamp.Value
        End If
    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim value = dtpDate.Value.Date.
            AddSeconds(0).
            AddMinutes(dtpTime.Value.Minute).
            AddHours(dtpTime.Value.Hour)
        If Not MessageBox.Show(
                text:=$"Are you sure the delivery that time is {value.ToShortDateString()} {value.ToShortTimeString()}?",
                caption:="Confirm Delivery Time",
                buttons:=MessageBoxButtons.YesNo,
                icon:=MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Return
        End If

        Panel2.Enabled = False
        Await FunctionUtils.TryCatchFunctionAsync(messageTitle:=String.Empty,
            Async Function()
                If _lineup IsNot Nothing Then
                    _lineup.SetConfirmedDeliveryTimeStamp(dateTime:=value)
                End If

                Dim lineupRepository = MainServiceProvider.GetRequiredService(Of ILineupRepository)
                Await lineupRepository.SaveAsync(entity:=_lineup)

                DialogResult = DialogResult.OK
                Panel2.Enabled = True
            End Function)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub dtpTime_ValueChanged(sender As Object, e As EventArgs) Handles dtpTime.ValueChanged
        btnSave.Enabled = dtpTime.Checked
    End Sub

End Class