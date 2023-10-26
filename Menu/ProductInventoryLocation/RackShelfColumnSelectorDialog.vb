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

        Me.Text = $"{inventoryLocationName} {If(_isStockTransferFromInventoryLocation, "→", If(_isStockTransferToInventoryLocation, "←", ""))} {movementHistoryGroupByProductColorSizeModel.ProductCode}"
        '
        Quantity.HeaderText = If(_isStockTransferFromInventoryLocation,
            "Outgoing Quantity",
            If(_isStockTransferToInventoryLocation,
            "Incoming Quantity",
            "Quantity"))
    End Sub

    Public ReadOnly Property GeneratedMovementHistories As List(Of MovementHistory)

    Private Async Sub RackShelfColumnSelectorDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridRackShelfColumn.AutoGenerateColumns = False

        Dim productInventoryLocationDataService = MainServiceProvider.GetRequiredService(Of IProductInventoryLocationDataService)
        Dim productInventoryLocations = Await productInventoryLocationDataService.GetByInventoryLocationIdAsync(_inventoryLocationId)

        Dim dataSource = productInventoryLocations.
            Where(Function(t) t.ProductColorSizeID = _productColorSizeId).
            Select(Function(t) New RackShelfColumnModel(rackShelfColumn:=t.RackShelfColumn,
                qtyToApply:=If(_movementHistories.Where(Function(f) f.ProductColorSizeID = _productColorSizeId).
                    Where(Function(f) f.ProductInventoryLocationIDA = _productInventoryLocationId).
                    FirstOrDefault()?.
                    QtyToApply, 0))).
            ToList()
        gridRackShelfColumn.DataSource = dataSource
    End Sub

    Private Sub gridRackShelfColumn_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridRackShelfColumn.CellContentClick

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Dim models = gridRackShelfColumn.Rows.
            OfType(Of DataGridViewRow).
            Select(Function(t) CType(t.DataBoundItem, RackShelfColumnModel)).
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

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub

End Class