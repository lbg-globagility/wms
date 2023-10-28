Option Strict On

Imports System.IO
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Exceptions
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices

Public Class ProductImageManager
    Private ReadOnly _picp As ProductImageConfigParser
    Private ReadOnly _server As String
    Private ReadOnly _photoDir As String
    Private ReadOnly _organizationId As Integer
    Private ReadOnly _userId As Integer
    Private ReadOnly _viewName As String

    Private Sub New()

    End Sub

    Public Sub New(picp As ProductImageConfigParser)
        _picp = picp
        _server = _picp.Server
        _photoDir = _picp.PhotoDir
    End Sub

    Public Sub New(picp As ProductImageConfigParser,
            organizationId As Integer,
            userId As Integer,
            viewName As String)
        _picp = picp
        _server = _picp.Server
        _photoDir = _picp.PhotoDir
        _organizationId = organizationId
        _userId = userId
        _viewName = viewName
    End Sub

    Public Function GetPhotoUrl(productCode As String) As String
        If String.IsNullOrEmpty(productCode) Then Return String.Empty

        Return $"\\{_server}{_photoDir}\{productCode}.jpg"
    End Function

    Public Async Function ChangeAsync(productId As Integer, sourceFileName As String) As Task
        Dim positionViewDataService = GetRequiredService(Of IPositionViewDataService)()
        Dim positionView = Await positionViewDataService.GetByUserIdAndViewNameAsync(organizationId:=Z_OrganizationID,
            userId:=_userId,
            viewName:=_viewName)

        If positionView.Restricted OrElse
            positionView.ReadOnly OrElse
            positionView.Creates OrElse
            Not positionView.Updates Then

            BusinessLogicException.ThrowInsufficientPrivilege()
            Return
        End If

        Dim productDataService = GetRequiredService(Of IProductDataService)()
        Dim product = Await productDataService.GetByIdAsync(id:=productId)

        Dim destFileName = $"\\{_server}{_photoDir}\{product.ProductCode}{Path.GetExtension(sourceFileName)}"

        File.Copy(sourceFileName:=sourceFileName,
            destFileName:=destFileName,
            overwrite:=True)
    End Function

    Public Async Function DeleteAsync(productId As Integer) As Task
        Dim positionViewDataService = GetRequiredService(Of IPositionViewDataService)()
        Dim positionView = Await positionViewDataService.GetByUserIdAndViewNameAsync(organizationId:=Z_OrganizationID,
            userId:=_userId,
            viewName:=_viewName)

        If positionView.Restricted OrElse
            positionView.ReadOnly OrElse
            Not positionView.Updates Then

            BusinessLogicException.ThrowInsufficientPrivilege()
            Return
        End If

        Dim productDataService = GetRequiredService(Of IProductDataService)()
        Dim product = Await productDataService.GetByIdAsync(id:=productId)

        Dim url = GetPhotoUrl(product.ProductCode)
        If File.Exists(url) Then File.Delete(url)
    End Function

    Public Async Function DownloadAsync(productId As Integer) As Task
        Dim productDataService = GetRequiredService(Of IProductDataService)()
        Dim product = Await productDataService.GetByIdAsync(id:=productId)

        Dim url = GetPhotoUrl(product.ProductCode)
        If File.Exists(url) Then
            File.Copy(sourceFileName:=url,
                destFileName:=$"{Path.GetTempPath}\{product.ProductCode}{Path.GetExtension(url)}",
                overwrite:=True)
        End If
    End Function

End Class