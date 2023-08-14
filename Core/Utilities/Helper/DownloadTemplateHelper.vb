Option Strict On

Imports System.IO
Imports WarehouseManagementSystem.Desktop.Utilities

Namespace Global.WarehouseManagementSystem.Desktop.Helpers

    Public Class DownloadTemplateHelper

        Private Const excelFileExtension As String = "xlsx"
        Private Const excelFileFilter As String = "Excel Files|*.xls;*.xlsx;"

        Public Shared Sub DownloadExcel(excelTemplate As ExcelTemplates)

            Dim excelName = TemplatesHelper.GetFileName(excelTemplate)
            Dim template = TemplatesHelper.GetFullPath(excelTemplate)

            Try

                Dim saveFileDialogHelperOutPut = SaveFileDialogHelper.BrowseFile(excelName, excelFileExtension, excelFileFilter)

                If saveFileDialogHelperOutPut.IsSuccess = False Then Return

                File.Copy(template, saveFileDialogHelperOutPut.FileInfo.FullName)

                Dim fileInfo = saveFileDialogHelperOutPut.FileInfo

                Process.Start(saveFileDialogHelperOutPut.FileInfo.FullName)
            Catch ex As IOException

                MessageBoxHelper.ErrorMessage(ex.Message)
            Catch ex As Exception

                MessageBoxHelper.DefaultErrorMessage()

            End Try

        End Sub
    End Class

End Namespace
