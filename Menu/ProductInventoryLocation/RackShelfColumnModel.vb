Imports WarehouseManagementSystem.Core.Entities

Friend Class RackShelfColumnModel
    Private ReadOnly _rackShelfColumn As RackShelfColumn
    Private ReadOnly _origQuantity As Integer

    Public Sub New(rackShelfColumn As RackShelfColumn, qtyToApply As Integer)
        _rackShelfColumn = rackShelfColumn
        _origQuantity = qtyToApply
        Quantity = qtyToApply
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

    Public ReadOnly Property HasChangedQuantity As Boolean
        Get
            Return Not _origQuantity = Quantity
        End Get
    End Property

End Class