Imports WarehouseManagementSystem.Core.Entities

Public Class ProductColorSizeModel
    Private ReadOnly _productColorSize As ProductColorSize
    Private ReadOnly _productColor As ProductColor

    Public Sub New(productColorSize As ProductColorSize)
        _productColorSize = productColorSize
        _productColor = productColorSize.ProductColor
    End Sub

    Public Property IsSelected As Boolean

    Public ReadOnly Property ProductCode As String
        Get
            Return _productColor?.Product?.ProductCode
        End Get
    End Property

    Public ReadOnly Property BrandName As String
        Get
            Return _productColor?.Product?.BrandName
        End Get
    End Property

    Public ReadOnly Property Category As String
        Get
            Return _productColor?.Product?.Category.CategoryName
        End Get
    End Property

    Public ReadOnly Property SRP As String
        Get
            Return _productColor?.Product?.UnitPrice.Value.ToString("N2")
        End Get
    End Property

    Public ReadOnly Property UnitOfMeasure As String
        Get
            Return _productColor?.Product?.UnitOfMeasure
        End Get
    End Property

    Public ReadOnly Property Description As String
        Get
            Return _productColor?.Product?.Description
        End Get
    End Property

    Public ReadOnly Property Colors As String
        Get
            Return _productColor.Color.ColorName
        End Get
    End Property

    Public ReadOnly Property Style As String
        Get
            Return $"{_productColorSize.Size}"
        End Get
    End Property

    Public ReadOnly Property SeasonCode As String
        Get
            Return $"{_productColorSize.SeasonCode}"
        End Get
    End Property

    Public ReadOnly Property ProductColorSize As ProductColorSize
        Get
            Return _productColorSize
        End Get
    End Property

End Class