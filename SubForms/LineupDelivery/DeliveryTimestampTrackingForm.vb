Option Strict On
Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Repositories
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class DeliveryTimestampTrackingForm
    Private ReadOnly _lineupId As Integer
    Private _lineup As Lineup

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
            Else
                dtpDate.Value = Date.Now
                dtpTime.Value = Date.Now
            End If
        End If
    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim value = dtpDate.Value
        If Not MessageBox.Show(
                text:=$"NOTE: Once you confirmed this delivery, you cannot undo the process again.{Environment.NewLine}{Environment.NewLine}Are you sure you want to `Confirm` this delivery and set delivery date/time to {value:MMM d, yyyy h:mm tt}?",
                caption:="Confirm Delivery",
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

                Dim lineupDataService = GetRequiredService(Of ILineupDataService)()
                Await lineupDataService.SaveManyAsync(userId:=Z_UserID, updated:=New List(Of Lineup) From {_lineup})

                DialogResult = DialogResult.OK
            End Function).
            ContinueWith(Sub()
                             Panel2.Enabled = True
                         End Sub, scheduler:=TaskScheduler.FromCurrentSynchronizationContext)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub dtpTime_ValueChanged(sender As Object, e As EventArgs) Handles dtpTime.ValueChanged
        btnSave.Enabled = dtpTime.Checked
    End Sub

End Class