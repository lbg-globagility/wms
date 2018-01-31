Imports MySql.Data.MySqlClient
Module sqlModule
    Public Class Manager
        Public sqlConn As New MySqlConnection()
        Public sqlRd As MySqlDataReader
        Public newconn = System.IO.File.ReadAllText("C:\ConnectionString\ConnectionStringDreamheartsdb.txt")
        Public newcon = System.IO.File.ReadAllText("C:\ConnectionString\ConnectionStringDreamheartsdb.txt")
        Public Function GetConnString() As String
            Try
                Dim connString As String = System.IO.File.ReadAllText("C:\ConnectionString\ConnectionStringDreamheartsdb.txt")
                Return connString
            Catch ex As Exception
                MsgBox("Error Code: sqlModule-GC. Please check your connection before trying again. (Error Message: " & ex.Message & ")", MsgBoxStyle.Critical, "System Message")
            End Try
            Return Nothing
        End Function
        Private Function OpenConnection() As Boolean
            Try
                If sqlConn.State = ConnectionState.Open Then
                    sqlConn.Close()
                    sqlConn.Dispose()
                End If
                sqlConn.ConnectionString = GetConnString()
                sqlConn.Open()
                Return True
            Catch ex As Exception
                MsgBox("Error Code: sqlModule-OC. Please check your connection before trying again. (Error Message: " & ex.Message & ")", MsgBoxStyle.Critical, "System Message")
            End Try
            Return False
        End Function
        Private Function CloseConnection() As Boolean
            Try
                If sqlConn.State = ConnectionState.Open Then
                    sqlConn.Close()
                    sqlConn.Dispose()
                End If
                Return True
            Catch ex As Exception
                MsgBox("Error Code: sqlModule-CC. Please check your connection before trying again. (Error Message: " & ex.Message & ")", MsgBoxStyle.Critical, "System Message")
            End Try
            Return False
        End Function
        Public Sub ClosedReader()
            Try
                If sqlConn.State = ConnectionState.Open Then
                    sqlConn.Close()
                    sqlConn.Dispose()
                End If
                If sqlRd.IsClosed = False Then
                    sqlRd.Close()
                End If
            Catch ex As Exception
                MsgBox("Error Code: sqlModule-CR. Please check your connection before trying again. (Error Message: " & ex.Message & ")", MsgBoxStyle.Critical, "System Message")
            End Try
        End Sub
        Public Function ExecuteReader(ByVal commandString) As MySqlDataReader
            Try
                OpenConnection()
                Dim cmd As New MySqlCommand()
                cmd.Connection = sqlConn
                cmd.CommandText = commandString
                sqlRd = cmd.ExecuteReader()
            Catch ex As Exception
                MsgBox("Error Code: sqlModule-ER. Please check your connection before trying again. (Error Message: " & ex.Message & ")", MsgBoxStyle.Critical, "System Message")
            Finally
                CloseConnection()
            End Try
            Return sqlRd
        End Function
        Public Function ExecuteNonQuery(ByVal commandString) As Integer
            Dim id As Integer = 0
            Try
                OpenConnection()
                Dim cmd As New MySqlCommand()
                cmd.Connection = sqlConn
                cmd.CommandText = commandString
                id = cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Error Code: sqlModule-EN. Please check your connection before trying again. (Error Message: " & ex.Message & ")", MsgBoxStyle.Critical, "System Message")
            Finally
                CloseConnection()
            End Try
            Return id
        End Function
    End Class
End Module
