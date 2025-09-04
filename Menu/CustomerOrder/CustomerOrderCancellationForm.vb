Option Strict On

Imports System.Threading
Imports TreeGridView
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports PickListt = WarehouseManagementSystem.Core.Entities.PickList

Public Class CustomerOrderCancellationForm
    Private Const COLUMN_WIDTH As Integer = 764
    Private ReadOnly _userId As Integer
    Private ReadOnly _orderId As Integer
    Private Const SECONDS_FIVE As Integer = 5
    Private _cts As CancellationTokenSource

    Public Sub New(userId As Integer, orderId As Integer)
        _userId = userId
        _orderId = orderId

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Async Sub CustomerOrderCancellationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tgvLineup.AutoGenerateColumns = False
        tgvPackingList.AutoGenerateColumns = False
        tgvPickList.AutoGenerateColumns = False

        Await LoadLineupAsync()
        Await LoadPackingListAsync()
        Await LoadPickListAsync()
    End Sub

    Private Async Function GetLineupsAsync() As Task(Of List(Of Lineup))
        Dim lineupDataService = GetRequiredService(Of ILineupDataService)()

        Return (Await lineupDataService.GetManyByOrderIdAsync(_orderId)).
            Where(Function(t) Not t.IsCancelled).
            ToList()

    End Function

    Private Async Function GetPackingListsAsync() As Task(Of List(Of PackingList))
        Dim packingListDataService = GetRequiredService(Of IPackingListDataService)()

        Dim ids = {_orderId}

        Return (Await packingListDataService.GetManyByOrderIdsAsync(ids)).
            Where(Function(t) Not t.IsCancelled).
            ToList()

    End Function

    Private Async Function GetPickListsAsync() As Task(Of List(Of PickListt))
        Dim pickListDataService = GetRequiredService(Of IPickListDataService)()

        Dim lksdjf = Await pickListDataService.GetManyByOrderIdAsync(_orderId)

        Return (Await pickListDataService.GetManyByOrderIdAsync(_orderId)).
            Where(Function(t) Not t.IsStatusCancelled).
            ToList()

    End Function

    Private Async Function LoadLineupAsync() As Task
        Dim lineups = Await GetLineupsAsync()

        For Each lineup In lineups
            Dim text = $"DR# {lineup.DeliveryNo}, Lineup#: {lineup.LineUpNo}({lineup.Status.ToString()}), Plate#: {lineup.PlateNo}, Driver: {If(String.IsNullOrEmpty(lineup.DeliveredBy), "None", lineup.DeliveredBy)}, Helper(s): {If(String.IsNullOrEmpty(lineup.Helpers), "None", lineup.Helpers)}"

            Dim node = tgvLineup.Nodes.FirstOrDefault(Function(t) lineup.RowID.Value = CInt(t.Tag))
            If node Is Nothing Then node = tgvLineup.Nodes.Add(text)
            node.Tag = lineup.RowID
            Dim n0 = node
            DoNotShowCheckBox(n0)

            For Each lineupCarton In lineup.LineupCartons
                Dim n1 = n0.Nodes.Add($"{lineupCarton.PackingListCarton.CartonNo}")
                DoNotShowCheckBox(n1)

                For Each packingListCartonItem In lineupCarton.PackingListCarton.PackingListCartonItems.OrderBy(Function(t) t.OrderItemID)
                    Dim oi = packingListCartonItem.OrderItem

                    Dim n2 = n1.Nodes.Add($"{oi.ItemCode} → {packingListCartonItem.QtyInCarton}{If(String.IsNullOrEmpty(oi.UnitOfMeasure), oi?.ProductInventoryLocation?.UnitOfMeasure2, oi.UnitOfMeasure)} × {oi.SRP.Value:n2} = {oi.TotalItemPrice:n2}")
                    DoNotShowCheckBox(n2)
                Next
            Next
        Next

        Dim column = tgvLineup.Columns.OfType(Of DataGridViewColumn).FirstOrDefault()
        column.Width = COLUMN_WIDTH

        TabPage1.Text = $"Lineup/Delivery ({If(lineups?.Count(), 0)})"
    End Function

    Private Async Function LoadPackingListAsync() As Task
        Dim packingLists = Await GetPackingListsAsync()

        For Each packingList In packingLists
            Dim text = $"Packing List # {packingList.PackingListNo}"

            Dim node = tgvPackingList.Nodes.FirstOrDefault(Function(t) packingList.RowID.Value = CInt(t.Tag))
            If node Is Nothing Then node = tgvPackingList.Nodes.Add(text)
            node.Tag = packingList.RowID
            Dim n0 = node
            DoNotShowCheckBox(n0)

            For Each packingListCarton In packingList.PackingListCartons
                Dim n1 = n0.Nodes.Add($"{packingListCarton.CartonNo}")
                DoNotShowCheckBox(n1)

                For Each packingListCartonItem In packingListCarton.PackingListCartonItems.OrderBy(Function(t) t.OrderItemID)
                    Dim oi = packingListCartonItem.OrderItem

                    Dim n2 = n1.Nodes.Add($"{oi.ItemCode} → {packingListCartonItem.QtyInCarton}{If(String.IsNullOrEmpty(oi.UnitOfMeasure), oi?.ProductInventoryLocation?.UnitOfMeasure2, oi.UnitOfMeasure)} × {oi.SRP.Value:n2} = {oi.TotalItemPrice:n2}")
                    DoNotShowCheckBox(n2)
                Next
            Next
        Next

        Dim column = tgvPackingList.Columns.OfType(Of DataGridViewColumn).FirstOrDefault()
        column.Width = COLUMN_WIDTH

        TabPage2.Text = $"Packing List ({If(packingLists?.Count(), 0)})"
    End Function

    Private Async Function LoadPickListAsync() As Task
        Dim pickLists = Await GetPickListsAsync()

        For Each pickList In pickLists
            Dim text = $"Pick List # {pickList.PickListNo}"

            Dim node = tgvPickList.Nodes.FirstOrDefault(Function(t) pickList.RowID.Value = CInt(t.Tag))
            If node Is Nothing Then node = tgvPickList.Nodes.Add(text)
            node.Tag = pickList.RowID
            Dim n0 = node
            DoNotShowCheckBox(n0)

            For Each pickListOrder In pickList.PickListOrders.OrderBy(Function(t) t.OrderItemID)
                Dim oi = pickListOrder.OrderItem
                Dim pil = oi.ProductInventoryLocation
                Dim r = pil.RackShelfColumn
                Dim i = r.InventoryLocation

                Dim info = $"[{i.Name}: {String.Join(String.Empty, r.RackNo, r.ShelfNo, r.ColumnNo)}] {If(pickListOrder.IsVerifiedStatus And pickListOrder.PickListOrderItem.IsVerified, String.Concat("[✔", pickListOrder.PickListOrderItem.Status.ToString(), "]"), String.Empty)}"
                Dim n1 = n0.Nodes.Add($"{oi.ItemCode} → {pickListOrder.PickListOrderItem.QtyPicked}{If(String.IsNullOrEmpty(oi.UnitOfMeasure), oi?.ProductInventoryLocation?.UnitOfMeasure2, oi.UnitOfMeasure)} × {oi.SRP.Value:n2} = {oi.TotalItemPrice:n2} → {info}")
                DoNotShowCheckBox(n1)

            Next
        Next

        Dim column = tgvPickList.Columns.OfType(Of DataGridViewColumn).FirstOrDefault()
        column.Width = COLUMN_WIDTH

        TabPage3.Text = $"Pick List ({If(pickLists?.Count(), 0)})"
    End Function

    Private Sub DoNotShowCheckBox(node As TreeGridNode)
        node.Grid.ShowCheckBox = False
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Text = $"Cancel ({SECONDS_FIVE})"

        _cts = New CancellationTokenSource()

        Await StartBackgroundTask(_cts.Token).
            ContinueWith(
            Sub(antecedent)
                'If antecedent.IsCompleted Then Debug.WriteLine("antecedent.IsCompleted")
                'If antecedent.IsCanceled Then Debug.WriteLine("antecedent.IsCanceled")
                'If antecedent.IsFaulted Then Debug.WriteLine("antecedent.IsFaulted")

                If antecedent.IsCompleted Then
                    Dim fsdfsd = {antecedent.IsCanceled, antecedent.IsFaulted}

                    If Not fsdfsd.Any(Function(t) t) Then DialogResult = DialogResult.OK

                End If

                Button1.Enabled = True
                Button2.Text = "Cancel"

            End Sub, TaskScheduler.FromCurrentSynchronizationContext())

    End Sub

    Private Async Function StartBackgroundTask(token As CancellationToken) As Task
        Dim seconds5 = SECONDS_FIVE

        While Not token.IsCancellationRequested
            Try
                Debug.WriteLine(seconds5)

                Await Task.Delay(1000, token).
                    ContinueWith(
                    Sub()
                        seconds5 -= 1
                        Button2.Text = $"Cancel ({seconds5})"
                    End Sub, TaskScheduler.FromCurrentSynchronizationContext())

                token.ThrowIfCancellationRequested()

            Catch taskCanceledEx As TaskCanceledException
                Debug.WriteLine("Background task TaskCanceledException")
                Throw taskCanceledEx

            Catch operationCanceledEx As OperationCanceledException
                Debug.WriteLine("Background task OperationCanceledException")
                Throw operationCanceledEx

            Catch ex As Exception
                Debug.WriteLine($"Error in background task: {ex.Message}")
                Throw ex

            Finally
                If seconds5 = 0 Then _cts.Cancel()

            End Try

        End While

    End Function

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Enabled = False

        _cts?.Cancel(True)

        Button2.Enabled = True

    End Sub

    Private Sub Button1_EnabledChanged(sender As Object, e As EventArgs) Handles Button1.EnabledChanged
        Button2.Enabled = Not Button1.Enabled

    End Sub

    Private Sub CustomerOrderCancellationForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _cts IsNot Nothing Then Button2_Click(Button2, New EventArgs)

    End Sub

End Class
