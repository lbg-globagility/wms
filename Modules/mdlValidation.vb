Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Data
Module mdlValidation
   
    Public Z_OrganizationID As Integer
    Public Z_UserID As Integer
    Public Z_PositionID As Integer
    Public Z_UserName As String
    Public Z_CompanyName As String
    Public Z_Encryptdata As String
    Public Function execute(ByVal query As String) As DataTable
        Try
            Dim con As New MySqlConnection(connectionString)
            Dim da As New MySqlDataAdapter(query, con)
            Dim cb As New MySqlCommandBuilder(da)
            Dim dt As New DataTable
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function SQL_GetDataTable(ByVal sql_Queery As String) As DataTable
        Dim DataReturn As New DataTable
        Try
            Dim command As MySqlCommand = New MySqlCommand(sql_Queery, New MySqlConnection(connectionString))
            command.Connection.Open()
            Dim adapter As MySqlDataAdapter = New MySqlDataAdapter(command)
            adapter.Fill(DataReturn)
            command.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return DataReturn
    End Function
    Public Function getDataTableForSQL(ByVal COMMD As String)
        Dim mdlVconnection As MySqlConnection = New MySqlConnection(connectionString)
        Dim command As MySqlCommand = New MySqlCommand(COMMD, mdlVconnection)
        Try
            Dim DataReturn As New DataTable
            command.Connection.Open()
            Dim adapter As MySqlDataAdapter = New MySqlDataAdapter(command)
            adapter.Fill(DataReturn)
            Return DataReturn
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            command.Connection.Close()
        End Try
    End Function
    Public Function getDataSetForTable(ByVal TableName As String)
        Dim sql As String = "SELECT  * FROM " & TableName
        Dim command As MySqlCommand = New MySqlCommand(sql, New MySqlConnection(connectionString))
        Try
            Dim DataReturn As New DataSet
            command.Connection.Open()
            Dim adapter As MySqlDataAdapter = New MySqlDataAdapter(command)
            adapter.Fill(DataReturn)
            command.Connection.Close()
            Return DataReturn
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            command.Connection.Close()
        End Try
    End Function
    Public Function getDataSetForSQL(ByVal COMMD As String)
        Dim command As MySqlCommand = New MySqlCommand(COMMD, New MySqlConnection(connectionString))
        Try
            Dim DataReturn As New DataSet
            command.Connection.Open()
            Dim adapter As MySqlDataAdapter = New MySqlDataAdapter(command)
            adapter.Fill(DataReturn)
            command.Connection.Close()
            Return DataReturn
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            command.Connection.Close()
        End Try
    End Function
    Public Function SQL_ArrayList(ByVal Sqlcommand As String) As ArrayList
        connection = New MySqlConnection(connectionString)
        Dim ArString As New ArrayList
        Try
            connection.Open()
            Dim command As MySqlCommand = _
                   New MySqlCommand(Sqlcommand, connection)
            command.CommandType = CommandType.Text
            Dim DR As MySqlDataReader = command.ExecuteReader
            Do While DR.Read
                ArString.Add(DR.GetValue(0))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            connection.Close()
        End Try
        Return ArString
    End Function
    Public Function EncrypedData(ByVal a As String)
        Dim Encryped As String = Nothing
        If Not a Is Nothing Then
            For Each x As Char In a
                Dim ToCOn As Integer = Convert.ToInt64(x) + 133
                Encryped &= Convert.ToChar(Convert.ToInt64(ToCOn))
                Z_Encryptdata = Encryped
            Next
        End If
        Return Encryped
    End Function
    Public Function DecrypedData(ByVal a As String)
        Dim DEcrypedio As String = Nothing
        If Not a Is Nothing Then
            For Each x As Char In a
                Dim ToCOn As Integer = Convert.ToInt64(x) - 133
                DEcrypedio &= Convert.ToChar(Convert.ToInt64(ToCOn))
            Next
        End If
        Return DEcrypedio
    End Function
    Public Function DirectCommand(ByVal SqCommand As String)
        Dim NumberitemInserted As Integer
        Dim command As MySqlCommand = New MySqlCommand(SqCommand, New MySqlConnection(connectionString))
        Try
            Dim DataReturn As New DataSet
            command.CommandType = CommandType.Text
            command.Connection.Open()
            NumberitemInserted = command.ExecuteNonQuery()
            command.Connection.Close()
        Catch ex As Exception
            NumberitemInserted = -1
        Finally
            command.Connection.Close()
        End Try
        Return NumberitemInserted
    End Function
    Public Function ObjectToString(ByVal obj As Object) As String
        Try
            If IsDBNull(obj) Then
                Return ""
            ElseIf obj = Nothing Then
                Return ""
            Else
                Return obj
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function getStringItem(ByVal Sqlcommand As String) As String
        connection = New MySqlConnection(connectionString)
        Dim itemSTR As String = Nothing
        Try
            connection.Open()
            Dim command As MySqlCommand = _
                   New MySqlCommand(Sqlcommand, connection)
            command.CommandType = CommandType.Text
            Dim DR As MySqlDataReader = command.ExecuteReader
            Do While DR.Read
                itemSTR = ObjectToString(DR.GetValue(0))
            Loop
        Catch ex As Exception
            itemSTR = ""
        Finally
            connection.Close()
        End Try
        Return itemSTR
    End Function
    Public Function SQL_ArrayList_Decrypted(ByVal Sqlcommand As String) As ArrayList
        connection = New MySqlConnection(connectionString)
        Dim ArString As New ArrayList
        Try
            connection.Open()
            Dim command As MySqlCommand = _
                   New MySqlCommand(Sqlcommand, connection)
            command.CommandType = CommandType.Text
            Dim DR As MySqlDataReader = command.ExecuteReader
            Do While DR.Read
                ArString.Add(DecrypedData(DR.GetValue(0)))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            connection.Close()
        End Try
        Return ArString
    End Function
    Public Function ConvertImageFiletoBytes(ByVal ImageFilePath As String) As Byte()
        Dim _tempByte() As Byte = Nothing
        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Return Nothing
        End If
        Try
            Dim _fileInfo As New IO.FileInfo(ImageFilePath)
            Dim _NumBytes As Long = _fileInfo.Length
            Dim _FStream As New IO.FileStream(ImageFilePath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim _BinaryReader As New IO.BinaryReader(_FStream)
            _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes))
            _fileInfo = Nothing
            _NumBytes = 0
            _FStream.Close()
            _FStream.Dispose()
            _BinaryReader.Close()
            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function ConvertByteToImage(ByVal ImgByte As Byte()) As Image
        Try
            Dim stream As System.IO.MemoryStream
            Dim img As Image
            stream = New System.IO.MemoryStream(ImgByte)
            img = Image.FromStream(stream)
            Return img
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function getImage(ByVal Sqlcommand As String) As Object
        connection = New MySqlConnection(connectionString)
        Dim ItemNumber As New Object
        Try
            connection.Open()
            Dim command As MySqlCommand = _
                   New MySqlCommand(Sqlcommand, connection)
            command.CommandType = CommandType.Text
            Dim DR As MySqlDataReader = command.ExecuteReader
            Do While DR.Read
                ItemNumber = DR.GetValue(0)
            Loop
        Catch ex As Exception
            ItemNumber = Nothing
        Finally
            connection.Close()
        End Try
        Return ItemNumber
    End Function
End Module
