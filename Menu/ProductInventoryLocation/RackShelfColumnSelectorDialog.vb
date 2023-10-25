Imports Microsoft.Extensions.DependencyInjection
Imports WarehouseManagementSystem.Core.Dto
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices

Public Class RackShelfColumnSelectorDialog
    Private ReadOnly _orderId As Integer?
    Private ReadOnly _inventoryLocationId As Integer?
    Private ReadOnly _productColorSizeId As Integer
    Private ReadOnly _productInventoryLocationId As Integer
    Private ReadOnly _movementHistories As List(Of MovementHistory)
    Private ReadOnly _movementHistoryGroupByProductColorSizeModel As MovementHistoryGroupByProductColorSizeModel
    Private ReadOnly _isStockTransferFromInventoryLocation As Boolean
    Private ReadOnly _isStockTransferToInventoryLocation As Boolean
    Private ReadOnly _inventoryLocationName As String
    Private _order As Order

    Public Sub New(orderId As Integer?,
        inventoryLocationId As Integer?,
        movementHistoryGroupByProductColorSizeModel As MovementHistoryGroupByProductColorSizeModel,
        Optional inventoryLocationName As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _orderId = orderId
        _inventoryLocationId = inventoryLocationId
        _productColorSizeId = movementHistoryGroupByProductColorSizeModel.ProductColorSizeId
        _productInventoryLocationId = movementHistoryGroupByProductColorSizeModel.ProductInventoryLocation.RowID.Value
        _movementHistories = movementHistoryGroupByProductColorSizeModel.MovementHistories
        _movementHistoryGroupByProductColorSizeModel = movementHistoryGroupByProductColorSizeModel

        _isStockTransferFromInventoryLocation = _inventoryLocationId = If(movementHistoryGroupByProductColorSizeModel.StockTransferFromInventoryLocationId, 0)

        _isStockTransferToInventoryLocation = _inventoryLocationId = If(movementHistoryGroupByProductColorSizeModel.StockTransferToInventoryLocationId, 0)

        _inventoryLocationName = inventoryLocationName
    End Sub

    Public ReadOnly Property GeneratedMovementHistories As List(Of MovementHistory)

    Private Async Sub RackShelfColumnSelectorDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridRackShelfColumn.AutoGenerateColumns = False

        Dim orderDataService = GetRequiredService(Of IOrderDataService)()
        _order = Await orderDataService.GetOrderAsync(_orderId)

        If _order.IsStockTransferType Then
            Me.Text = $"{_inventoryLocationName} {If(_isStockTransferFromInventoryLocation, "→", If(_isStockTransferToInventoryLocation, "←", ""))} {_movementHistoryGroupByProductColorSizeModel.ProductCode}"

            Quantity.HeaderText =
                If(_isStockTransferFromInventoryLocation,
                    "Outgoing Quantity",
                    If(_isStockTransferToInventoryLocation,
                        "Incoming Quantity",
                        "Quantity"))
        ElseIf _order.IsStockAdjustType Then
            Quantity.MinValue = Integer.MinValue
            FlowLayoutPanel1.Visible = True
            FlowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight
            FlowLayoutPanel1.WrapContents = True
        End If

        Dim productInventoryLocationDataService = GetRequiredService(Of IProductInventoryLocationDataService)()
        Dim productInventoryLocations = Await productInventoryLocationDataService.GetByInventoryLocationIdAsync(_inventoryLocationId)

        Dim dataSource = productInventoryLocations.
            Where(Function(t) t.ProductColorSizeID = _productColorSizeId).
            Select(Function(t)
                       Dim movementHistory = _movementHistories?.
                        Where(Function(f) f.ProductColorSizeID = _productColorSizeId).
                        Where(Function(f) f.ProductInventoryLocationIDA = _productInventoryLocationId).
                        FirstOrDefault()
                       Dim qtyToApply = If(movementHistory.QtyToApply, 0)

                       Return New RackShelfColumnModel(order:=_order,
                        productInventoryLocation:=t,
                        rackShelfColumn:=t.RackShelfColumn,
                        qtyToApply:=qtyToApply,
                        movementHistory:=movementHistory)
                   End Function).
            ToList()
        gridRackShelfColumn.DataSource = dataSource

        DisEnableOKButton()
    End Sub

    Private Sub gridRackShelfColumn_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridRackShelfColumn.CellContentClick

    End Sub

    Private Sub gridRackShelfColumn_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles gridRackShelfColumn.CellEndEdit
        DisEnableOKButton()
    End Sub

    Private Sub DisEnableOKButton()
        gridRackShelfColumn.Refresh()

        Dim models = GetModels().
            Where(Function(t) t.HasError).
            ToList()

        ButtonOK.Enabled = Not models.Any()
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Dim models = GetModels().
            Where(Function(t) t.HasChangedQuantity).
            ToList()

        Dim fromOrToText = If(_inventoryLocationId = _movementHistoryGroupByProductColorSizeModel.StockTransferFromInventoryLocationId, "From",
            If(_inventoryLocationId = _movementHistoryGroupByProductColorSizeModel.StockTransferToInventoryLocationId, "To", String.Empty))

        _GeneratedMovementHistories = models.
            Select(Function(t) MovementHistory.NewMovementHistory(organizationId:=Z_OrganizationID,
                userId:=Z_UserID,
                productColorSizeID:=_productColorSizeId,
                orderId:=_orderId,
                productInventoryLocationId:=_productInventoryLocationId,
                currentQty:=t.AvailableQty,
                qtyToApply:=t.Quantity,
                transactionType:=$"{OrderType.ST} - {fromOrToText}")).
            ToList()

        DialogResult = DialogResult.OK
    End Sub

    Private Function GetModels() As List(Of RackShelfColumnModel)
        If gridRackShelfColumn.Rows.Count() = 0 Then Return Enumerable.Empty(Of RackShelfColumnModel)()

        Return gridRackShelfColumn.Rows.
            OfType(Of DataGridViewRow).
            Select(Function(t) CType(t.DataBoundItem, RackShelfColumnModel)).
            ToList()
    End Function

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub LinkLabelSeeSample_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelSeeSample.LinkClicked
        Dim newLine = Environment.NewLine
        MessageBox.Show(text:=$"Ex #1.{newLine}An item has [60] `Available Qty`, but the actual count is [45].{newLine}The user need to input negative fiffteen [-15] in the `Quantity` column.{newLine}{newLine}Ex #2.{newLine}An item has [192] `Available Qty`, but the actual count is [248].{newLine}The user need to input fifty six [56] in the `Quantity` column.",
            caption:="How Adjustment works",
            icon:=MessageBoxIcon.Information,
            buttons:=MessageBoxButtons.OK)
    End Sub

End Class