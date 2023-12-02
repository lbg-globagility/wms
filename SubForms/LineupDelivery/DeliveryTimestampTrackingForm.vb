Option Strict On
Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Entities
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
        Dim lineupRepository = GetRequiredService(Of ILineupRepository)()
        _lineup = Await lineupRepository.GetByIdAsync(id:=_lineupId)
        If _lineup IsNot Nothing Then
            Dim hasValue = _lineup.ConfirmedDeliveryTimeStamp IsNot Nothing
            dtpTime.Checked = hasValue
            'dtpDate.MinDate = If(_lineup.LineUpDate, Date.Now)

            If hasValue Then
                dtpDate.Value = _lineup.ConfirmedDeliveryTimeStamp.Value.Date
                dtpTime.Value = _lineup.ConfirmedDeliveryTimeStamp.Value
            End If
        End If
    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim value = dtpDate.Value
        If Not MessageBox.Show(
                text:=$"Are you sure that the delivery date/time is{Environment.NewLine}{value:MMM d, yyyy h:mm tt}?",
                caption:="Confirm Delivery Time",
                buttons:=MessageBoxButtons.YesNoCancel,
                defaultButton:=MessageBoxDefaultButton.Button2,
                icon:=MessageBoxIcon.Question) = DialogResult.Yes Then
            Return
        End If

        Panel2.Enabled = False
        Await FunctionUtils.TryCatchFunctionAsync(messageTitle:=String.Empty,
            Async Function()
                If _lineup IsNot Nothing Then
                    _lineup.SetConfirmedDeliveryTimeStamp(dateTime:=value)
                End If

                Dim lineupRepository = GetRequiredService(Of ILineupRepository)()
                Await lineupRepository.SaveManyAsync(updated:=New List(Of Lineup) From {_lineup})

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