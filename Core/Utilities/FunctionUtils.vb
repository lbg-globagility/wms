Imports Microsoft.EntityFrameworkCore
Imports WarehouseManagementSystem.Core.Exceptions

Public Class FunctionUtils

    Public Shared Async Function TryCatchFunctionAsync(
            messageTitle As String,
            action As Func(Of Task),
            Optional baseExceptionErrorMessage As String = Nothing,
            Optional errorCallBack As Action = Nothing,
            Optional dbUpdateCallBack As Action(Of DbUpdateException) = Nothing) As Task
        Try

            Await action()
        Catch ex As ArgumentException
            MessageBoxHelper.ErrorMessage(ex.Message, messageTitle)

            If errorCallBack IsNot Nothing Then
                errorCallBack()
            End If
        Catch ex As BusinessLogicException
            MessageBoxHelper.ErrorMessage(ex.Message, messageTitle)

            If errorCallBack IsNot Nothing Then
                errorCallBack()
            End If
        Catch ex As DbUpdateException

            If dbUpdateCallBack IsNot Nothing Then
                dbUpdateCallBack(ex)
            Else
                HandleDefaultError(messageTitle, baseExceptionErrorMessage, errorCallBack, ex)

            End If
        Catch ex As Exception

            HandleDefaultError(messageTitle, baseExceptionErrorMessage, errorCallBack, ex)

        End Try

    End Function

    Private Shared Sub HandleDefaultError(
            messageTitle As String,
            baseExceptionErrorMessage As String,
            errorCallBack As Action,
            ex As Exception)

        Debugger.Break()

        If baseExceptionErrorMessage Is Nothing Then

            MessageBoxHelper.DefaultErrorMessage(messageTitle, ex)
        Else

            MessageBoxHelper.ErrorMessage(baseExceptionErrorMessage, messageTitle)
        End If

        If errorCallBack IsNot Nothing Then
            errorCallBack()
        End If
    End Sub

    Public Shared Function TryCatchExcelParserReadFunction(
            action As Action,
            Optional messageTitle As String = "WorkSheet Parsing Error") As Boolean

        Try

            action()

            Return True
        Catch ex As WorkSheetRowParseValueException

            MessageBoxHelper.ErrorMessage(ex.Message, messageTitle)
        Catch ex As ExcelException

            MessageBoxHelper.ErrorMessage(ex.Message, messageTitle)
        Catch ex As Exception
            Debugger.Break()

            MessageBoxHelper.DefaultErrorMessage(messageTitle, ex)

        End Try

        Return False

    End Function

End Class