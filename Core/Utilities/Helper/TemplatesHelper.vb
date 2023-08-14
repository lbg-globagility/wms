Option Strict On

Namespace Global.WarehouseManagementSystem.Desktop.Helpers
    Public Enum ExcelTemplates
        Product
    End Enum

    Public Class TemplatesHelper

        Public Shared ReadOnly PRODUCT As String = "product-color-size-template.xlsx"

        Private Const FILE_PATH As String = "Import Templates/"

        Public Shared Function GetFileName(excelTemplate As ExcelTemplates) As String
            Select Case excelTemplate
                Case ExcelTemplates.Product
                    Return PRODUCT
                Case Else
                    Return Nothing
            End Select
        End Function

        Public Shared Function GetFullPath(excelTemplate As ExcelTemplates) As String
            Dim fileName As String
            Select Case excelTemplate

                Case ExcelTemplates.Product
                    fileName = PRODUCT
                Case Else
                    Return Nothing
            End Select

            Return FILE_PATH & fileName
        End Function

    End Class

End Namespace
