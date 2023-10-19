Option Strict On

Imports IniParser
Imports IniParser.Model
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class ProductImageConfigParser
    Private Const PRODUCT_IMAGE_SECTION As String = "prod-img"
    Private Const SERVER_ATTRIBUTE As String = "server"
    Private Const PHOTO_DIRECTORY_ATTRIBUTE As String = "photoDir"
    Private ReadOnly _filePath As String
    Private ReadOnly _parser As FileIniDataParser
    Private _iniData As IniData

    Private Sub New()

    End Sub

    Public Sub New(filePath As String)
        _filePath = filePath
        _parser = New FileIniDataParser()

        LoadConfig()
    End Sub

    Private Async Sub LoadConfig()
        Await FunctionUtils.TryCatchFunctionAsync(messageTitle:=String.Empty,
            action:=
            Function()
                _iniData = _parser.ReadFile(filePath:=_filePath)
                Return Task.FromResult(0)
            End Function,
            errorCallBack:=
            Sub()
                Dim data = New IniData()
                Dim sections = data.Sections.
                    OfType(Of SectionData)

                Dim hasProductImageSection = sections.Any(Function(t) t.SectionName = PRODUCT_IMAGE_SECTION)

                If Not hasProductImageSection Then data.Sections.AddSection(PRODUCT_IMAGE_SECTION)

                Dim keys = data(PRODUCT_IMAGE_SECTION)

                Dim keysCollection = keys.OfType(Of KeyData)

                Dim hasServer = keysCollection.Any(Function(t) t.KeyName = SERVER_ATTRIBUTE)
                If Not hasServer Then keys.AddKey(keyName:=SERVER_ATTRIBUTE, keyValue:="127.0.0.1")

                Dim hasPhotoDir = keysCollection.Any(Function(t) t.KeyName = PHOTO_DIRECTORY_ATTRIBUTE)
                If Not hasPhotoDir Then keys.AddKey(keyName:=PHOTO_DIRECTORY_ATTRIBUTE, keyValue:="\Users\Public\prod-img")

                If Not hasProductImageSection AndAlso
                    Not hasServer AndAlso
                    Not hasPhotoDir Then

                    _parser.WriteFile(filePath:=_filePath, parsedData:=data)

                    _iniData = data
                End If
            End Sub)
    End Sub

    Public ReadOnly Property Server As String
        Get
            Return _iniData?.
                Sections(PRODUCT_IMAGE_SECTION)?.
                GetKeyData(SERVER_ATTRIBUTE)?.
                Value
        End Get
    End Property

    Public ReadOnly Property PhotoDir As String
        Get
            Return _iniData?.
                Sections(PRODUCT_IMAGE_SECTION)?.
                GetKeyData(PHOTO_DIRECTORY_ATTRIBUTE)?.
                Value
        End Get
    End Property

End Class