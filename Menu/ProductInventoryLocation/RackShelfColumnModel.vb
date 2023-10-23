Option Strict On

Imports WarehouseManagementSystem.Core.Entities

Friend Class RackShelfColumnModel
    Private ReadOnly _order As Order
    Private ReadOnly _rackShelfColumn As RackShelfColumn
    Private ReadOnly _origQuantity As Integer

    Public Sub New(order As Order,
            rackShelfColumn As RackShelfColumn,
            qtyToApply As Integer,
            movementHistory As MovementHistory)

        _order = order
        _rackShelfColumn = rackShelfColumn
        _origQuantity = qtyToApply
        Quantity = qtyToApply
        _movementHistory = movementHistory
    End Sub

    Public ReadOnly Property RowID As Integer?
        Get
            Return _rackShelfColumn.RowID
        End Get
    End Property

    Public ReadOnly Property PickOrderNo As Integer
        Get
            Return If(_rackShelfColumn.PickOrderNo, 0)
        End Get
    End Property

    Public ReadOnly Property RackNo As String
        Get
            Return _rackShelfColumn.RackNo
        End Get
    End Property

    Public ReadOnly Property ShelfNo As String
        Get
            Return _rackShelfColumn.ShelfNo
        End Get
    End Property

    Public ReadOnly Property ColumnNo As String
        Get
            Return _rackShelfColumn.ColumnNo
        End Get
    End Property

    Public ReadOnly Property AvailableQty As Integer
        Get
            Return If(_rackShelfColumn.AvailableQty, 0)
        End Get
    End Property

    Public ReadOnly Property DistributedQty As Integer
        Get
            Return If(_rackShelfColumn.DistributedQty, 0)
        End Get
    End Property

    Public ReadOnly Property ReservedQty As Integer
        Get
            Return If(_rackShelfColumn.ReservedQty, 0)
        End Get
    End Property

    Public ReadOnly Property DamagedQty As Integer
        Get
            Return If(_rackShelfColumn.DamagedQty, 0)
        End Get
    End Property

    Public ReadOnly Property InRepairQty As Integer
        Get
            Return If(_rackShelfColumn.InRepairQty, 0)
        End Get
    End Property

    Public ReadOnly Property SupplierProblemQty As Integer
        Get
            Return If(_rackShelfColumn.SupplierProblemQty, 0)
        End Get
    End Property

    Public ReadOnly Property LastShippedToLocDate As Date?
        Get
            Return _rackShelfColumn.LastShippedToLocDate
        End Get
    End Property

    Public ReadOnly Property LastCycleCountDate As Date?
        Get
            Return _rackShelfColumn.LastCycleCountDate
        End Get
    End Property

    Public ReadOnly Property Remarks As String
        Get
            Return _rackShelfColumn.Remarks
        End Get
    End Property

    Public Property Quantity As Integer
    Private ReadOnly _movementHistory As MovementHistory

    Public ReadOnly Property HasChangedQuantity As Boolean
        Get
            Return Not _origQuantity = Quantity
        End Get
    End Property

    Public ReadOnly Property IsTooMuchQuantity As Boolean
        Get
            If _order.IsStockTransferType AndAlso _movementHistory.IsTransactionTypeIsFrom Then Return Quantity > If(_rackShelfColumn.AvailableQty, 0)

            Return False
        End Get
    End Property

    Public ReadOnly Property ErrorMessage As String
        Get
            Dim errorMesasge = New List(Of String)
            If IsTooMuchQuantity Then errorMesasge.Add($"{Quantity} is greater than `Available Quantity`")

            Return String.Join("; ", errorMesasge.Where(Function(t) Not String.IsNullOrEmpty(t)).ToArray())
        End Get
    End Property

    Public ReadOnly Property HasError As Boolean
        Get
            Return Not String.IsNullOrEmpty(ErrorMessage)
        End Get
    End Property

End Class