Option Strict On

Imports System.IO
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Exceptions
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Utilities.Extensions

Public Class ProductImageManager
    Private ReadOnly _picp As ProductImageConfigParser
    Private ReadOnly _server As String
    Private ReadOnly _photoDir As String

    Private Sub New()

    End Sub

    Public Sub New(picp As ProductImageConfigParser)
        _picp = picp
        _server = _picp.Server
        _photoDir = _picp.PhotoDir
    End Sub

    Public Function GetPhotoUrl(productCode As String) As String
        If String.IsNullOrEmpty(productCode) Then Return String.Empty

        Return $"\\{_server}{_photoDir}\{productCode}.jpg"
    End Function

    Public Async Function ChangeAsync(productId As Integer, fileDialog As OpenFileDialog) As Task
        Dim productDataService = GetRequiredService(Of IProductDataService)()
        Dim product = Await productDataService.GetByIdAsync(id:=productId)

        Dim compositeDestination = $"""\\\\{_server}{_photoDir.Replace("\", "\\")}\\{product.ProductCode}{Path.GetExtension(fileDialog.FileName)}"""
        'Dim processStartInfo = New ProcessStartInfo() With
        '{
        '    .Arguments = $" -c -f ""{fileDialog.FileName.Replace("\", "\\")}"" {compositeDestination}",
        '    .CreateNoWindow = False,
        '    .FileName = "psexec",
        '    .RedirectStandardInput = True,
        '    .RedirectStandardError = True,
        '    .RedirectStandardOutput = True,
        '    .UseShellExecute = False,
        '    .WindowStyle = ProcessWindowStyle.Normal
        '}

        ''.Verb = "runas"

        'Using proc = Process.Start(processStartInfo)
        '    Await proc.WaitForExitAsync()

        '    'Dim standardOutput = proc.StandardOutput?.ReadToEnd()
        '    'Dim standardError = proc.StandardError?.ReadToEnd()

        '    Dim exitCode = proc.ExitCode
        '    If Not exitCode = 0 Then BusinessLogicException.Throw($"Error: #{exitCode} - {proc.StandardError?.ReadToEnd()}")
        'End Using
        Dim destFileName = $"\\{_server}{_photoDir}\{product.ProductCode}{Path.GetExtension(fileDialog.FileName)}"

        File.Copy(sourceFileName:=fileDialog.FileName,
            destFileName:=destFileName,
            overwrite:=True)
    End Function

    Public Async Function DeleteAsync(productId As Integer) As Task
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