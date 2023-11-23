Imports MySql.Data.MySqlClient
Imports WarehouseManagementSystem.Core.Entities

Module mdlStoredProcedure
    Public connectionString As String = System.IO.File.ReadAllText("C:\ConnectionString\ConnectionStringDreamheartsdb.txt")
    Public connection As MySqlConnection = New MySqlConnection(connectionString)
    Public globaldatareader As MySqlDataReader
    Public globalcyclecountidsp, globalproductinventorylocationidsp As Integer
    Public globaladdressidsp, globalcontactidsp, globalproductcolorsidsp, globalproductcolorsizesidsp, globalorderidsp As Integer
    Public globalpicklistidsp, globalpicklistorderidsp, globalorderitemidsp, globalpackinglistcartonidsp, globallineupidsp As Integer

#Region "Accounts"

    Public Function I_Accounts(ByVal OrganizationID As Integer,
                          ByVal Created As DateTime,
                          ByVal CreatedBy As Integer,
                          ByVal LastUpdBy As Integer,
                          ByVal PrimaryContactID As Object,
                          ByVal PrimaryAddressID As Object,
                          ByVal ParentAccountID As Object,
                          ByVal PickListGroupID As Object,
                          ByVal BranchID As Object,
                          ByVal AccountNo As Integer,
                          ByVal AccountType As String,
                          ByVal CompanyName As String,
                          ByVal TradeName As String,
                          ByVal MainPhone As String,
                          ByVal AltPhone As String,
                          ByVal FaxNumber As String,
                          ByVal EmailAddress As String,
                          ByVal VATRegistrationNo As String,
                          ByVal Website As String,
                          ByVal DeliveryHours As String,
                          ByVal Comments As String,
                          ByVal Status As String,
                          ByVal AgentID As Integer,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_accounts", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_PrimaryContactID", PrimaryContactID)
                .Parameters.AddWithValue("I_PrimaryAddressID", PrimaryAddressID)
                .Parameters.AddWithValue("I_ParentAccountID", ParentAccountID)
                .Parameters.AddWithValue("I_PickListGroupID", PickListGroupID)
                .Parameters.AddWithValue("I_BranchID", BranchID)
                .Parameters.AddWithValue("I_AccountNo", AccountNo)
                .Parameters.AddWithValue("I_AccountType", AccountType)
                .Parameters.AddWithValue("I_CompanyName", CompanyName)
                .Parameters.AddWithValue("I_TradeName", TradeName)
                .Parameters.AddWithValue("I_MainPhone", MainPhone)
                .Parameters.AddWithValue("I_AltPhone", AltPhone)
                .Parameters.AddWithValue("I_FaxNumber", FaxNumber)
                .Parameters.AddWithValue("I_EmailAddress", EmailAddress)
                .Parameters.AddWithValue("I_VATRegistrationNo", VATRegistrationNo)
                .Parameters.AddWithValue("I_Website", Website)
                .Parameters.AddWithValue("I_DeliveryHours", DeliveryHours)
                .Parameters.AddWithValue("I_Comments", Comments)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_AgentID", AgentID)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_Accounts(ByVal RowID As Integer,
                   ByVal LastUpd As DateTime,
                   ByVal LastUpdby As Integer,
                   ByVal PrimaryContactID As Object,
                   ByVal PrimaryAddressID As Object,
                   ByVal ParentAccountID As Object,
                   ByVal PickListGroupID As Object,
                   ByVal BranchID As Object,
                   ByVal CompanyName As String,
                   ByVal MainPhone As String,
                   ByVal AltPhone As String,
                   ByVal FaxNumber As String,
                   ByVal EmailAddress As String,
                   ByVal VATRegistrationNo As String,
                   ByVal Website As String,
                   ByVal DeliveryHours As String,
                   ByVal Comments As String,
                   ByVal Status As String,
                   ByVal AgentID As Integer,
                   ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_accounts", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_PrimaryContactID", PrimaryContactID)
                .Parameters.AddWithValue("U_PrimaryAddressID", PrimaryAddressID)
                .Parameters.AddWithValue("U_ParentAccountID", ParentAccountID)
                .Parameters.AddWithValue("U_PickListGroupID", PickListGroupID)
                .Parameters.AddWithValue("U_BranchID", BranchID)
                .Parameters.AddWithValue("U_CompanyName", CompanyName)
                .Parameters.AddWithValue("U_MainPhone", MainPhone)
                .Parameters.AddWithValue("U_AltPhone", AltPhone)
                .Parameters.AddWithValue("U_FaxNumber", FaxNumber)
                .Parameters.AddWithValue("U_EmailAddress", EmailAddress)
                .Parameters.AddWithValue("U_VATRegistrationNo", VATRegistrationNo)
                .Parameters.AddWithValue("U_Website", Website)
                .Parameters.AddWithValue("U_DeliveryHours", DeliveryHours)
                .Parameters.AddWithValue("U_Comments", Comments)
                .Parameters.AddWithValue("U_Status", Status)
                .Parameters.AddWithValue("U_AgentID", AgentID)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Address"

    Public Function I_Address(ByVal Created As DateTime,
                          ByVal CreatedBy As Integer,
                          ByVal LastUpdBy As Integer,
                          ByVal StreetAddress1 As String,
                          ByVal StreetAddress2 As String,
                          ByVal Barangay As String,
                          ByVal CityTown As String,
                          ByVal Province As String,
                          ByVal State As String,
                          ByVal ZipCode As String,
                          ByVal Country As String,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_address", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("newAddressID", MySqlDbType.Int32)
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_StreetAddress1", StreetAddress1)
                .Parameters.AddWithValue("I_StreetAddress2", StreetAddress2)
                .Parameters.AddWithValue("I_Barangay", Barangay)
                .Parameters.AddWithValue("I_CityTown", CityTown)
                .Parameters.AddWithValue("I_Province", Province)
                .Parameters.AddWithValue("I_State", State)
                .Parameters.AddWithValue("I_ZipCode", ZipCode)
                .Parameters.AddWithValue("I_Country", Country)
                .Parameters("newAddressID").Direction = ParameterDirection.ReturnValue
                globaldatareader = .ExecuteReader
                globaladdressidsp = globaldatareader(0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_Address(ByVal RowID As Integer,
                    ByVal LastUpd As DateTime,
                    ByVal LastUpdby As Integer,
                    ByVal StreetAddress1 As String,
                    ByVal StreetAddress2 As String,
                    ByVal Barangay As String,
                    ByVal CityTown As String,
                    ByVal Province As String,
                    ByVal State As String,
                    ByVal ZipCode As String,
                    ByVal Country As String,
                    ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_address", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_StreetAddress1", StreetAddress1)
                .Parameters.AddWithValue("U_StreetAddress2", StreetAddress2)
                .Parameters.AddWithValue("U_Barangay", Barangay)
                .Parameters.AddWithValue("U_CityTown", CityTown)
                .Parameters.AddWithValue("U_Province", Province)
                .Parameters.AddWithValue("U_State", State)
                .Parameters.AddWithValue("U_ZipCode", ZipCode)
                .Parameters.AddWithValue("U_Country", Country)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Attachments"

    Public Function I_Attachments(ByVal OrganizationID As Integer,
                     ByVal Created As DateTime,
                     ByVal CreatedBy As Integer,
                     ByVal LastUpdBy As Integer,
                     ByVal AccountID As Object,
                     ByVal OrderID As Object,
                     ByVal ContactID As Object,
                     ByVal InvoiceID As Object,
                     ByVal ProductID As Object,
                     ByVal AttachedFile As Object,
                     ByVal FileName As String,
                     ByVal FileType As String,
                     ByVal Remarks As String,
                     ByVal Status As String,
                     ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_attachments", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_AccountID", AccountID)
                .Parameters.AddWithValue("I_OrderID", OrderID)
                .Parameters.AddWithValue("I_ContactID", ContactID)
                .Parameters.AddWithValue("I_InvoiceID", InvoiceID)
                .Parameters.AddWithValue("I_ProductID", ProductID)
                .Parameters.AddWithValue("I_AttachedFile", AttachedFile)
                .Parameters.AddWithValue("I_FileName", FileName)
                .Parameters.AddWithValue("I_FileType", FileType)
                .Parameters.AddWithValue("I_Remarks", Remarks)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_Attachments(ByVal RowID As Integer,
                        ByVal LastUpd As DateTime,
                        ByVal LastUpdby As Integer,
                        ByVal FileName As String,
                        ByVal Remarks As String,
                        ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_attachments", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_FileName", FileName)
                .Parameters.AddWithValue("U_Remarks", Remarks)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_AttachmentStatus(ByVal RowID As Integer,
                             ByVal LastUpd As DateTime,
                             ByVal LastUpdby As Integer,
                             ByVal Status As String) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_attachmentstatus", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Brands"

    Public Function I_Brands(ByVal OrganizationID As Integer,
                           ByVal Created As DateTime,
                           ByVal CreatedBy As Integer,
                           ByVal LastUpdBy As Integer,
                           ByVal BrandName As String,
                           ByVal Status As String,
                           ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_brands", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_BrandName", BrandName)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Branches"

    Public Function I_Branches(ByVal OrganizationID As Integer,
                      ByVal Created As DateTime,
                      ByVal CreatedBy As Integer,
                      ByVal LastUpdBy As Integer,
                      ByVal BranchCode As String,
                      ByVal BranchName As String,
                      ByVal BranchAddress As String,
                      ByVal Status As String,
                      ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_branches", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_BranchCode", BranchCode)
                .Parameters.AddWithValue("I_BranchName", BranchName)
                .Parameters.AddWithValue("I_BranchAddress", BranchAddress)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_Branches(ByVal RowID As Integer,
                                 ByVal LastUpd As DateTime,
                                 ByVal LastUpdby As Integer,
                                 ByVal BranchCode As String,
                                 ByVal BranchName As String,
                                 ByVal BranchAddress As String,
                                 ByVal Status As String,
                                 ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_branches", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_BranchCode", BranchCode)
                .Parameters.AddWithValue("U_BranchName", BranchName)
                .Parameters.AddWithValue("U_BranchAddress", BranchAddress)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "CartonSizes"

    Public Function I_CartonSizes(ByVal OrganizationID As Integer,
                          ByVal Created As DateTime,
                          ByVal CreatedBy As Integer,
                          ByVal LastUpdBy As Integer,
                          ByVal SizeName As String,
                          ByVal Length As Decimal,
                          ByVal Width As Decimal,
                          ByVal Height As Decimal,
                          ByVal LengthUOM As String,
                          ByVal WidthUOM As String,
                          ByVal HeightUOM As String,
                          ByVal Status As String,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_cartonsizes", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_SizeName", SizeName)
                .Parameters.AddWithValue("I_Length", Length)
                .Parameters.AddWithValue("I_Width", Width)
                .Parameters.AddWithValue("I_Height", Height)
                .Parameters.AddWithValue("I_LengthUOM", LengthUOM)
                .Parameters.AddWithValue("I_WidthUOM", WidthUOM)
                .Parameters.AddWithValue("I_HeightUOM", HeightUOM)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_CartonSizes(ByVal RowID As Integer,
                                 ByVal LastUpd As DateTime,
                                 ByVal LastUpdby As Integer,
                                 ByVal Length As Decimal,
                                 ByVal Width As Decimal,
                                 ByVal Height As Decimal,
                                 ByVal LengthUOM As String,
                                 ByVal WidthUOM As String,
                                 ByVal HeightUOM As String,
                                 ByVal Status As String,
                                 ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_cartonsizes", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_Length", Length)
                .Parameters.AddWithValue("U_Width", Width)
                .Parameters.AddWithValue("U_Height", Height)
                .Parameters.AddWithValue("U_LengthUOM", LengthUOM)
                .Parameters.AddWithValue("U_WidthUOM", WidthUOM)
                .Parameters.AddWithValue("U_HeightUOM", HeightUOM)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Categories"

    Public Function I_Categories(ByVal OrganizationID As Integer,
                           ByVal Created As DateTime,
                           ByVal CreatedBy As Integer,
                           ByVal LastUpdBy As Integer,
                           ByVal CategoryName As String,
                           ByVal Status As String,
                           ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_categories", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_CategoryName", CategoryName)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_Categories(ByVal RowID As Integer,
                                     ByVal LastUpd As DateTime,
                                     ByVal LastUpdBy As Integer,
                                     ByVal CategoryName As String,
                                     ByVal Status As String,
                                     ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_categories", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_CategoryName", CategoryName)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Codings"

    Public Function I_Codings(ByVal OrganizationID As Integer,
                       ByVal Created As DateTime,
                       ByVal CreatedBy As Integer,
                       ByVal LastUpdBy As Integer,
                       ByVal CodeType As String,
                       ByVal CodeNo As String,
                       ByVal CodeName As String,
                       ByVal Status As String,
                       ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_codings", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_CodeType", CodeType)
                .Parameters.AddWithValue("I_CodeNo", CodeNo)
                .Parameters.AddWithValue("I_CodeName", CodeName)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_Codings(ByVal RowID As Integer,
                                ByVal LastUpd As DateTime,
                                ByVal LastUpdby As Integer,
                                ByVal CodeType As String,
                                ByVal CodeNo As String,
                                ByVal CodeName As String,
                                ByVal Status As String,
                                ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_codings", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_CodeType", CodeType)
                .Parameters.AddWithValue("U_CodeNo", CodeNo)
                .Parameters.AddWithValue("U_CodeName", CodeName)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Colors"

    Public Function I_Colors(ByVal OrganizationID As Integer,
                          ByVal Created As DateTime,
                          ByVal CreatedBy As Integer,
                          ByVal LastUpdBy As Integer,
                          ByVal ColorName As String,
                          ByVal ColorValue As String,
                          ByVal Status As String,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_colors", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_ColorName", ColorName)
                .Parameters.AddWithValue("I_ColorValue", ColorValue)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_Colors(ByVal RowID As Integer,
                            ByVal LastUpd As DateTime,
                            ByVal LastUpdby As Integer,
                            ByVal ColorName As String,
                            ByVal ColorValue As String,
                            ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_colors", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_ColorName", ColorName)
                .Parameters.AddWithValue("U_ColorValue", ColorValue)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "CombineCodings"

    Public Function I_CombineCodings(ByVal OrganizationID As Integer,
                        ByVal Created As DateTime,
                        ByVal CreatedBy As Integer,
                        ByVal LastUpdBy As Integer,
                        ByVal CodingIDA As Object,
                        ByVal CodingIDB As Object,
                        ByVal CodingIDC As Object,
                        ByVal CodeName As String,
                        ByVal Status As String,
                        ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_combinecodings", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_CodingIDA", CodingIDA)
                .Parameters.AddWithValue("I_CodingIDB", CodingIDB)
                .Parameters.AddWithValue("I_CodingIDC", CodingIDC)
                .Parameters.AddWithValue("I_CodeName", CodeName)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_CombineCodings(ByVal RowID As Integer,
                            ByVal LastUpd As DateTime,
                            ByVal LastUpdby As Integer,
                            ByVal CodingIDA As Object,
                            ByVal CodingIDB As Object,
                            ByVal CodingIDC As Object,
                            ByVal CodeName As String,
                            ByVal Status As String,
                            ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_combinecodings", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_CodingIDA", CodingIDA)
                .Parameters.AddWithValue("U_CodingIDB", CodingIDB)
                .Parameters.AddWithValue("U_CodingIDC", CodingIDC)
                .Parameters.AddWithValue("U_CodeName", CodeName)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Companies"

    Public Function I_Companies(ByVal OrganizationID As Integer,
                           ByVal Created As DateTime,
                           ByVal CreatedBy As Integer,
                           ByVal LastUpdBy As Integer,
                           ByVal CompanyCode As String,
                           ByVal CompanyName As String,
                           ByVal Status As String,
                           ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_companies", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_CompanyCode", CompanyCode)
                .Parameters.AddWithValue("I_CompanyName", CompanyName)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_Companies(ByVal RowID As Integer,
                                ByVal LastUpd As DateTime,
                                ByVal LastUpdby As Integer,
                                ByVal CompanyCode As String,
                                ByVal CompanyName As String,
                                ByVal Status As String,
                                ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_companies", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_CompanyCode", CompanyCode)
                .Parameters.AddWithValue("U_CompanyName", CompanyName)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Contacts"

    Public Function I_Contact(ByVal OrganizationID As Integer,
                        ByVal Created As DateTime,
                        ByVal CreatedBy As Integer,
                        ByVal LastUpdBy As Integer,
                        ByVal ContactNo As Integer,
                        ByVal Type As String,
                        ByVal Salutation As String,
                        ByVal FirstName As String,
                        ByVal MiddleName As String,
                        ByVal LastName As String,
                        ByVal Suffix As String,
                        ByVal MainPhone As String,
                        ByVal AlternatePhone As String,
                        ByVal Birthday As Date,
                        ByVal Gender As String,
                        ByVal CivilStatus As String,
                        ByVal EmailAddress As String,
                        ByVal TINNumber As String,
                        ByVal Comments As String,
                        ByVal Status As String,
                        ByVal MobilePhone As String,
                        ByVal WorkPhone As String,
                        ByVal FaxNumber As String,
                        ByVal JobTitle As String,
                        ByVal Nickname As String,
                        ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_contact", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("newContactID", MySqlDbType.Int32)
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_ContactNo", ContactNo)
                .Parameters.AddWithValue("I_Type", Type)
                .Parameters.AddWithValue("I_Salutation", Salutation)
                .Parameters.AddWithValue("I_FirstName", FirstName)
                .Parameters.AddWithValue("I_MiddleName", MiddleName)
                .Parameters.AddWithValue("I_LastName", LastName)
                .Parameters.AddWithValue("I_Suffix", Suffix)
                .Parameters.AddWithValue("I_MainPhone", MainPhone)
                .Parameters.AddWithValue("I_AlternatePhone", AlternatePhone)
                .Parameters.AddWithValue("I_Birthday", Birthday)
                .Parameters.AddWithValue("I_Gender", Gender)
                .Parameters.AddWithValue("I_CivilStatus", CivilStatus)
                .Parameters.AddWithValue("I_EmailAddress", EmailAddress)
                .Parameters.AddWithValue("I_TINNumber", TINNumber)
                .Parameters.AddWithValue("I_Comments", Comments)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_MobilePhone", MobilePhone)
                .Parameters.AddWithValue("I_WorkPhone", WorkPhone)
                .Parameters.AddWithValue("I_FaxNumber", FaxNumber)
                .Parameters.AddWithValue("I_JobTitle", JobTitle)
                .Parameters.AddWithValue("I_Nickname", Nickname)
                .Parameters("newContactID").Direction = ParameterDirection.ReturnValue
                globaldatareader = .ExecuteReader
                globalcontactidsp = globaldatareader(0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_Contacts(ByVal RowID As Integer,
                          ByVal LastUpd As DateTime,
                          ByVal LastUpdBy As Integer,
                          ByVal Salutation As String,
                          ByVal FirstName As String,
                          ByVal MiddleName As String,
                          ByVal LastName As String,
                          ByVal Suffix As String,
                          ByVal MainPhone As String,
                          ByVal AlternatePhone As String,
                          ByVal Birthday As Date,
                          ByVal Gender As String,
                          ByVal CivilStatus As String,
                          ByVal EmailAddress As String,
                          ByVal TINNumber As String,
                          ByVal Comments As String,
                          ByVal MobilePhone As String,
                          ByVal WorkPhone As String,
                          ByVal FaxNumber As String,
                          ByVal JobTitle As String,
                          ByVal Nickname As String,
                          ByVal Status As String,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_contacts", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Salutation", Salutation)
                .Parameters.AddWithValue("U_FirstName", FirstName)
                .Parameters.AddWithValue("U_MiddleName", MiddleName)
                .Parameters.AddWithValue("U_LastName", LastName)
                .Parameters.AddWithValue("U_Suffix", Suffix)
                .Parameters.AddWithValue("U_MainPhone", MainPhone)
                .Parameters.AddWithValue("U_AlternatePhone", AlternatePhone)
                .Parameters.AddWithValue("U_Birthday", Birthday)
                .Parameters.AddWithValue("U_Gender", Gender)
                .Parameters.AddWithValue("U_CivilStatus", CivilStatus)
                .Parameters.AddWithValue("U_EmailAddress", EmailAddress)
                .Parameters.AddWithValue("U_TINNumber", TINNumber)
                .Parameters.AddWithValue("U_Comments", Comments)
                .Parameters.AddWithValue("U_MobilePhone", MobilePhone)
                .Parameters.AddWithValue("U_WorkPhone", WorkPhone)
                .Parameters.AddWithValue("U_FaxNumber", FaxNumber)
                .Parameters.AddWithValue("U_JobTitle", JobTitle)
                .Parameters.AddWithValue("U_Nickname", Nickname)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "CycleCount"

    Public Function I_CycleCount(ByVal OrganizationID As Integer,
                        ByVal Created As DateTime,
                        ByVal CreatedBy As Integer,
                        ByVal LastUpdBy As Integer,
                        ByVal BrandID As Object,
                        ByVal CycleCountNo As Integer,
                        ByVal CycleCountBy As String,
                        ByVal RackColumnShelf As String,
                        ByVal Comments As String,
                        ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_cyclecount", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("newCycleCountID", MySqlDbType.Int32)
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_BrandID", BrandID)
                .Parameters.AddWithValue("I_CycleCountNo", CycleCountNo)
                .Parameters.AddWithValue("I_CycleCountBy", CycleCountBy)
                .Parameters.AddWithValue("I_RackColumnShelf", RackColumnShelf)
                .Parameters.AddWithValue("I_Comments", Comments)
                .Parameters("newCycleCountID").Direction = ParameterDirection.ReturnValue
                globaldatareader = .ExecuteReader
                globalcyclecountidsp = globaldatareader(0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_CycleCount(ByVal RowID As Integer,
                                ByVal LastUpd As DateTime,
                                ByVal LastUpdby As Integer,
                                ByVal Comments As String,
                                ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_cyclecount", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_Comments", Comments)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "CycleCountItems"

    Public Function I_CycleCountItems(ByVal OrganizationID As Integer,
                       ByVal Created As DateTime,
                       ByVal CreatedBy As Integer,
                       ByVal LastUpdBy As Integer,
                       ByVal CycleCountID As Integer,
                       ByVal ProductColorSizeID As Integer,
                       ByVal ProductInventoryLocationID As Integer,
                       ByVal CycleCount1ContactID As Object,
                       ByVal CycleCount2ContactID As Object,
                       ByVal OriginalQty As Integer,
                       ByVal CycleCount1Qty As Object,
                       ByVal CycleCount2Qty As Object,
                       ByVal RackNo As String,
                       ByVal ColumnNo As String,
                       ByVal ShelfNo As String,
                       ByVal Remarks As String,
                       ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_cyclecountitems", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_CycleCountID", CycleCountID)
                .Parameters.AddWithValue("I_ProductColorSizeID", ProductColorSizeID)
                .Parameters.AddWithValue("I_ProductInventoryLocationID", ProductInventoryLocationID)
                .Parameters.AddWithValue("I_CycleCount1ContactID", CycleCount1ContactID)
                .Parameters.AddWithValue("I_CycleCount2ContactID", CycleCount2ContactID)
                .Parameters.AddWithValue("I_OriginalQty", OriginalQty)
                .Parameters.AddWithValue("I_CycleCount1Qty", CycleCount1Qty)
                .Parameters.AddWithValue("I_CycleCount2Qty", CycleCount2Qty)
                .Parameters.AddWithValue("I_RackNo", RackNo)
                .Parameters.AddWithValue("I_ColumnNo", ColumnNo)
                .Parameters.AddWithValue("I_ShelfNo", ShelfNo)
                .Parameters.AddWithValue("I_Remarks", Remarks)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_CycleCountItems(ByVal RowID As Integer,
                              ByVal LastUpd As DateTime,
                              ByVal LastUpdby As Integer,
                              ByVal CycleCount1ContactID As Object,
                              ByVal CycleCount2ContactID As Object,
                              ByVal CycleCount1Qty As Object,
                              ByVal CycleCount2Qty As Object,
                              ByVal Remarks As String,
                              ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_cyclecountitems", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_CycleCount1ContactID", CycleCount1ContactID)
                .Parameters.AddWithValue("U_CycleCount2ContactID", CycleCount2ContactID)
                .Parameters.AddWithValue("U_CycleCount1Qty", CycleCount1Qty)
                .Parameters.AddWithValue("U_CycleCount2Qty", CycleCount2Qty)
                .Parameters.AddWithValue("U_Remarks", Remarks)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "DeliveryTrucks"

    Public Function I_DeliveryTrucks(ByVal OrganizationID As Integer,
                         ByVal Created As DateTime,
                         ByVal CreatedBy As Integer,
                         ByVal LastUpdBy As Integer,
                         ByVal TruckNo As Integer,
                         ByVal TruckName As String,
                         ByVal PlateNo As String,
                         ByVal BrandName As String,
                         ByVal MadeIn As String,
                         ByVal CBM As Decimal,
                         ByVal Status As String,
                         ByVal MaxCapacity As String,
                         ByVal YearAndModel As String,
                         ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_deliverytrucks", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_TruckNo", TruckNo)
                .Parameters.AddWithValue("I_TruckName", TruckName)
                .Parameters.AddWithValue("I_PlateNo", PlateNo)
                .Parameters.AddWithValue("I_BrandName", BrandName)
                .Parameters.AddWithValue("I_MadeIn", MadeIn)
                .Parameters.AddWithValue("I_CBM", CBM)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_MaxCapacity", MaxCapacity)
                .Parameters.AddWithValue("I_YearAndModel", YearAndModel)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_DeliveryTrucks(ByVal RowID As Integer,
                                     ByVal LastUpd As DateTime,
                                     ByVal LastUpdby As Integer,
                                     ByVal TruckName As String,
                                     ByVal PlateNo As String,
                                     ByVal BrandName As String,
                                     ByVal MadeIn As String,
                                     ByVal CBM As Decimal,
                                     ByVal Status As String,
                                     ByVal MaxCapacity As String,
                                     ByVal YearAndModel As String,
                                     ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_deliverytrucks", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_TruckName", TruckName)
                .Parameters.AddWithValue("U_PlateNo", PlateNo)
                .Parameters.AddWithValue("U_BrandName", BrandName)
                .Parameters.AddWithValue("U_MadeIn", MadeIn)
                .Parameters.AddWithValue("U_CBM", CBM)
                .Parameters.AddWithValue("U_Status", Status)
                .Parameters.AddWithValue("U_MaxCapacity", MaxCapacity)
                .Parameters.AddWithValue("U_YearAndModel", YearAndModel)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "DeliveryTruckShifts"

    Public Function I_DeliveryTruckShifts(ByVal OrganizationID As Integer,
                          ByVal Created As DateTime,
                          ByVal CreatedBy As Integer,
                          ByVal LastUpdBy As Integer,
                          ByVal DeliveryTruckID As Integer,
                          ByVal ShiftID As Integer,
                          ByVal Status As String,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_deliverytruckshifts", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_DeliveryTruckID", DeliveryTruckID)
                .Parameters.AddWithValue("I_ShiftID", ShiftID)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_DeliveryTruckShift(ByVal RowID As Integer,
                               ByVal LastUpd As DateTime,
                               ByVal LastUpdBy As Integer,
                               ByVal DeliveryTruckID As Integer,
                               ByVal ShiftID As Integer,
                               ByVal Status As String,
                               ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_deliverytruckshift", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_DeliveryTruckID", DeliveryTruckID)
                .Parameters.AddWithValue("U_ShiftID", ShiftID)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "InventoryLocations"

    Public Function I_InventoryLocations(ByVal OrganizationID As Integer,
                                     ByVal Created As DateTime,
                                     ByVal CreatedBy As Integer,
                                     ByVal LastUpdBy As Integer,
                                     ByVal AddressID As Integer?,
                                     ByVal Name As String,
                                     ByVal Type As String,
                                     ByVal MainPhone As String,
                                     ByVal MobilePhone As String,
                                     ByVal FaxNumber As String,
                                     ByVal Status As String,
                                     ByVal Comments As String,
                                     ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_inventorylocations", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_AddressID", If(AddressID.HasValue AndAlso AddressID.Value > 0, AddressID.Value, DBNull.Value))
                .Parameters.AddWithValue("I_Name", Name)
                .Parameters.AddWithValue("I_Type", Type)
                .Parameters.AddWithValue("I_MainPhone", MainPhone)
                .Parameters.AddWithValue("I_MobilePhone", MobilePhone)
                .Parameters.AddWithValue("I_FaxNumber", FaxNumber)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_Comments", Comments)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_InventoryLocations(ByVal RowID As Integer,
                                     ByVal LastUpd As DateTime,
                                     ByVal LastUpdby As Integer,
                                     ByVal AddressID As Integer?,
                                     ByVal Name As String,
                                     ByVal Type As String,
                                     ByVal MainPhone As String,
                                     ByVal MobilePhone As String,
                                     ByVal FaxNumber As String,
                                     ByVal Comments As String,
                                     ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_inventorylocations", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_AddressID", If(AddressID.HasValue AndAlso AddressID.Value > 0, AddressID.Value, DBNull.Value))
                .Parameters.AddWithValue("U_Name", Name)
                .Parameters.AddWithValue("U_Type", Type)
                .Parameters.AddWithValue("U_MainPhone", MainPhone)
                .Parameters.AddWithValue("U_MobilePhone", MobilePhone)
                .Parameters.AddWithValue("U_FaxNumber", FaxNumber)
                .Parameters.AddWithValue("U_Comments", Comments)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "LineUps"

    Public Function I_LineUps(ByVal OrganizationID As Integer,
                        ByVal Created As DateTime,
                        ByVal CreatedBy As Integer,
                        ByVal LastUpdBy As Integer,
                        ByVal ContactID As Object,
                        ByVal PackingListID As Integer,
                        ByVal DeliveryTruckShiftID As Integer,
                        ByVal OrderID As Integer,
                        ByVal LineUpDate As Date,
                        ByVal DeliveryHours As String,
                        ByVal LineUpNo As String,
                        ByVal DeliveryNo As String,
                        ByVal Status As String,
                        ByVal Comments As String,
                        ByVal DeliveryAddress As String,
                        ByVal globalformname As Object,
                        Optional AgentId As Integer? = Nothing,
                        Optional Helper1Id As Integer? = Nothing,
                        Optional Helper2Id As Integer? = Nothing) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_lineups", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("newLineUpID", MySqlDbType.Int32)
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_ContactID", ContactID)
                .Parameters.AddWithValue("I_PackingListID", PackingListID)
                .Parameters.AddWithValue("I_DeliveryTruckShiftID", DeliveryTruckShiftID)
                .Parameters.AddWithValue("I_OrderID", OrderID)
                .Parameters.AddWithValue("I_LineUpDate", LineUpDate)
                .Parameters.AddWithValue("I_DeliveryHours", DeliveryHours)
                .Parameters.AddWithValue("I_LineUpNo", LineUpNo)
                .Parameters.AddWithValue("I_DeliveryNo", DeliveryNo)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_Comments", Comments)
                .Parameters.AddWithValue("I_DeliveryAddress", DeliveryAddress)

                .Parameters.AddWithValue("I_AgentId", If(AgentId Is Nothing, DBNull.Value, AgentId))
                .Parameters.AddWithValue("I_Helper1Id", If(Helper1Id Is Nothing, DBNull.Value, Helper1Id))
                .Parameters.AddWithValue("I_Helper2Id", If(Helper2Id Is Nothing, DBNull.Value, Helper2Id))

                .Parameters("newLineUpID").Direction = ParameterDirection.ReturnValue
                globaldatareader = .ExecuteReader
                globallineupidsp = globaldatareader(0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_LineUps(ByVal RowID As Integer,
                                ByVal LastUpd As DateTime,
                                ByVal LastUpdby As Integer,
                                ByVal ContactID As Object,
                                ByVal DeliveryTruckShiftID As Integer,
                                ByVal LineUpDate As Date,
                                ByVal DeliveryNo As String,
                                ByVal Comments As String,
                                ByVal globalformname As Object,
                                Optional AgentId As Integer? = Nothing,
                                Optional Helper1Id As Integer? = Nothing,
                                Optional Helper2Id As Integer? = Nothing) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_lineups", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_ContactID", ContactID)
                .Parameters.AddWithValue("U_DeliveryTruckShiftID", DeliveryTruckShiftID)
                .Parameters.AddWithValue("U_LineUpDate", LineUpDate)
                .Parameters.AddWithValue("U_DeliveryNo", DeliveryNo)
                .Parameters.AddWithValue("U_Comments", Comments)

                .Parameters.AddWithValue("U_AgentId", If(AgentId Is Nothing, DBNull.Value, AgentId))
                .Parameters.AddWithValue("U_Helper1Id", If(Helper1Id Is Nothing, DBNull.Value, Helper1Id))
                .Parameters.AddWithValue("U_Helper2Id", If(Helper2Id Is Nothing, DBNull.Value, Helper2Id))

                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_LineUpStatus(ByVal RowID As Integer,
                                  ByVal LastUpd As DateTime,
                                  ByVal LastUpdBy As Integer,
                                  ByVal Status As String,
                                  ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_lineupstatus", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "LineUpCartons"

    Public Function I_LineUpCartons(ByVal OrganizationID As Integer,
                         ByVal Created As DateTime,
                         ByVal CreatedBy As Integer,
                         ByVal LastUpdBy As Integer,
                         ByVal PackingListCartonID As Integer,
                         ByVal LineUpID As Integer,
                         ByVal Status As String,
                         ByVal CBM As Decimal,
                         ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_lineupcartons", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_PackingListCartonID", PackingListCartonID)
                .Parameters.AddWithValue("I_LineUpID", LineUpID)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_CBM", CBM)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_LineUpCartonStatus(ByVal RowID As Integer,
                           ByVal LastUpd As DateTime,
                           ByVal LastUpdBy As Integer,
                           ByVal Status As String,
                           ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_lineupcartonstatus", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "LineUpCBM"

    Public Function I_LineUpCBM(ByVal OrganizationID As Integer,
                     ByVal Created As DateTime,
                     ByVal CreatedBy As Integer,
                     ByVal LastUpdBy As Integer,
                     ByVal DeliveryTruckShiftID As Integer,
                     ByVal LineUpDate As Date,
                     ByVal CBM As Decimal,
                     ByVal Status As String,
                     ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_lineupcbm", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_DeliveryTruckShiftID", DeliveryTruckShiftID)
                .Parameters.AddWithValue("I_LineUpDate", LineUpDate)
                .Parameters.AddWithValue("I_CBM", CBM)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "ListOfValues"

    Public Function I_ListOfValues(ByVal Created As DateTime,
                             ByVal CreatedBy As Integer,
                             ByVal LastUpdBy As Integer,
                             ByVal DisplayValue As String,
                             ByVal LIC As String,
                             ByVal Type As String,
                             ByVal ParentLIC As String,
                             ByVal Description As String,
                             ByVal Status As String,
                             ByVal SystemFlg As Char,
                             ByVal DisplayFlg As Char,
                             ByVal OrderBy As Object,
                             ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_listofvalues", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_DisplayValue", DisplayValue)
                .Parameters.AddWithValue("I_LIC", LIC)
                .Parameters.AddWithValue("I_Type", Type)
                .Parameters.AddWithValue("I_ParentLIC", ParentLIC)
                .Parameters.AddWithValue("I_Description", Description)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_SystemFlg", SystemFlg)
                .Parameters.AddWithValue("I_DisplayFlg", DisplayFlg)
                .Parameters.AddWithValue("I_OrderBy", OrderBy)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_ListOfValueStatus(ByVal RowID As Integer,
                               ByVal LastUpd As DateTime,
                               ByVal LastUpdBy As Integer,
                               ByVal Status As String,
                               ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_listofvaluestatus", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Orders"

    Public Function I_Orders(ByVal OrganizationID As Integer,
                          ByVal Created As DateTime,
                          ByVal CreatedBy As Integer,
                          ByVal LastUpdBy As Integer,
                          ByVal AccountID As Integer,
                          ByVal BranchID As Object,
                          ByVal CompanyID As Object,
                          ByVal CombineCodingID As Object,
                          ByVal OrderNumber As String,
                          ByVal ReferenceNumber As String,
                          ByVal DRNumber As String,
                          ByVal OrderType As String,
                          ByVal OrderDate As Date,
                          ByVal TargetDate As Date,
                          ByVal EndDate As Date,
                          ByVal CustomerName As String,
                          ByVal Comments As String,
                          ByVal Status As String,
                          ByVal TotalAmount As Decimal,
                          ByVal DeliveryHours As String,
                          ByVal CustomerAddress As String,
                          ByVal CustomerOrderType As String,
                          ByVal globalformname As Object,
                          Optional InventoryLocationId As Integer? = Nothing,
                          Optional AgentId As Integer? = Nothing
                          ) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_orders", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("newOrdersID", MySqlDbType.Int32)
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_AccountID", AccountID)
                .Parameters.AddWithValue("I_BranchID", BranchID)
                .Parameters.AddWithValue("I_CompanyID", CompanyID)
                .Parameters.AddWithValue("I_CombineCodingID", CombineCodingID)
                .Parameters.AddWithValue("I_OrderNumber", OrderNumber)
                .Parameters.AddWithValue("I_ReferenceNumber", ReferenceNumber)
                .Parameters.AddWithValue("I_DRNumber", DRNumber)
                .Parameters.AddWithValue("I_OrderType", OrderType)
                .Parameters.AddWithValue("I_OrderDate", OrderDate)
                .Parameters.AddWithValue("I_TargetDate", TargetDate)
                .Parameters.AddWithValue("I_EndDate", EndDate)
                .Parameters.AddWithValue("I_CustomerName", CustomerName)
                .Parameters.AddWithValue("I_Comments", Comments)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_TotalAmount", TotalAmount)
                .Parameters.AddWithValue("I_DeliveryHours", DeliveryHours)
                .Parameters.AddWithValue("I_CustomerAddress", CustomerAddress)
                .Parameters.AddWithValue("I_InventoryLocationID", If(InventoryLocationId Is Nothing, DBNull.Value, InventoryLocationId))
                .Parameters.AddWithValue("I_AgentID", If(AgentId Is Nothing, DBNull.Value, AgentId))
                .Parameters.AddWithValue("I_CustomerOrderType", CustomerOrderType)
                .Parameters("newOrdersID").Direction = ParameterDirection.ReturnValue
                globaldatareader = .ExecuteReader
                globalorderidsp = globaldatareader(0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_Orders(ByVal RowID As Integer,
                                ByVal LastUpd As DateTime,
                                ByVal LastUpdBy As Integer,
                                ByVal AccountID As Integer,
                                ByVal BranchID As Object,
                                ByVal CompanyID As Object,
                                ByVal CombineCodingID As Object,
                                ByVal OrderNumber As String,
                                ByVal ReferenceNumber As String,
                                ByVal DRNumber As String,
                                ByVal OrderDate As Date,
                                ByVal TargetDate As Date,
                                ByVal EndDate As Date,
                                ByVal Comments As String,
                                ByVal TotalAmount As Decimal,
                                ByVal DeliveryHours As String,
                                ByVal CustomerAddress As String,
                                ByVal CustomerOrderType As String,
                                ByVal globalformname As Object,
                                Optional InventoryLocationId As Integer? = Nothing,
                                Optional AgentId As Integer? = Nothing) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_orders", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_AccountID", AccountID)
                .Parameters.AddWithValue("U_BranchID", BranchID)
                .Parameters.AddWithValue("U_CompanyID", CompanyID)
                .Parameters.AddWithValue("U_CombineCodingID", CombineCodingID)
                .Parameters.AddWithValue("U_OrderNumber", OrderNumber)
                .Parameters.AddWithValue("U_ReferenceNumber", ReferenceNumber)
                .Parameters.AddWithValue("U_DRNumber", DRNumber)
                .Parameters.AddWithValue("U_OrderDate", OrderDate)
                .Parameters.AddWithValue("U_TargetDate", TargetDate)
                .Parameters.AddWithValue("U_EndDate", EndDate)
                .Parameters.AddWithValue("U_Comments", Comments)
                .Parameters.AddWithValue("U_TotalAmount", TotalAmount)
                .Parameters.AddWithValue("U_DeliveryHours", DeliveryHours)
                .Parameters.AddWithValue("U_CustomerAddress", CustomerAddress)
                .Parameters.AddWithValue("U_InventoryLocationID", If(InventoryLocationId Is Nothing, DBNull.Value, InventoryLocationId))
                .Parameters.AddWithValue("U_AgentID", If(AgentId Is Nothing, DBNull.Value, AgentId))
                .Parameters.AddWithValue("U_CustomerOrderType", CustomerOrderType)

                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_OrderStatus(ByVal RowID As Integer,
                                  ByVal LastUpd As DateTime,
                                  ByVal LastUpdBy As Integer,
                                  ByVal Status As String,
                                  ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_orderstatus", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_OrderTotalAmount(ByVal RowID As Integer,
                                 ByVal LastUpd As DateTime,
                                 ByVal LastUpdBy As Integer,
                                 ByVal TotalAmount As Decimal,
                                 ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_ordertotalamount", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_TotalAmount", TotalAmount)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_OrderDateSubmitted(ByVal RowID As Integer,
                                     ByVal LastUpd As DateTime,
                                     ByVal LastUpdBy As Integer,
                                     ByVal DateSubmitted As Date,
                                     ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_orderdatesubmitted", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_DateSubmitted", DateSubmitted)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_OrderDRNumber(ByVal RowID As Integer,
                                  ByVal LastUpd As DateTime,
                                  ByVal LastUpdBy As Integer,
                                  ByVal DRNumber As String,
                                  ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_orderdrnumber", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_DRNumber", DRNumber)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "OrderItems"

    Public Function I_OrderItems(ByVal OrganizationID As Integer,
                          ByVal Created As DateTime,
                          ByVal CreatedBy As Integer,
                          ByVal LastUpdBy As Integer,
                          ByVal AccountID As Integer,
                          ByVal OrderID As Integer,
                          ByVal ProductColorSizeID As Object,
                          ByVal ProductBundleID As Object,
                          ByVal OrderItemID As Object,
                          ByVal QtyOrdered As Integer,
                          ByVal QtyAvailable As Integer,
                          ByVal ItemType As String,
                          ByVal ItemCode As String,
                          ByVal SKU As String,
                          ByVal UnitOfMeasure As String,
                          ByVal Remarks As String,
                          ByVal SRP As Decimal,
                          ByVal Status As String,
                          ByVal Tags As String,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_orderitems", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("newOrderItemID", MySqlDbType.Int32)
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_AccountID", AccountID)
                .Parameters.AddWithValue("I_OrderID", OrderID)
                .Parameters.AddWithValue("I_ProductColorSizeID", ProductColorSizeID)
                .Parameters.AddWithValue("I_ProductBundleID", ProductBundleID)
                .Parameters.AddWithValue("I_OrderItemID", OrderItemID)
                .Parameters.AddWithValue("I_QtyOrdered", QtyOrdered)
                .Parameters.AddWithValue("I_QtyAvailable", QtyAvailable)
                .Parameters.AddWithValue("I_ItemType", ItemType)
                .Parameters.AddWithValue("I_ItemCode", ItemCode)
                .Parameters.AddWithValue("I_SKU", SKU)
                .Parameters.AddWithValue("I_UnitOfMeasure", UnitOfMeasure)
                .Parameters.AddWithValue("I_Remarks", Remarks)
                .Parameters.AddWithValue("I_SRP", SRP)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_Tags", Tags)
                .Parameters("newOrderItemID").Direction = ParameterDirection.ReturnValue
                globaldatareader = .ExecuteReader
                globalorderitemidsp = globaldatareader(0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_OrderItems(ByVal RowID As Integer,
                              ByVal LastUpd As DateTime,
                              ByVal LastUpdBy As Integer,
                              ByVal AccountID As Integer,
                              ByVal QtyOrdered As Integer,
                              ByVal SRP As Decimal,
                              ByVal SKU As String,
                              ByVal UnitOfMeasure As String,
                              ByVal Remarks As String,
                              ByVal Tags As String,
                              ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_orderitems", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_AccountID", AccountID)
                .Parameters.AddWithValue("U_QtyOrdered", QtyOrdered)
                .Parameters.AddWithValue("U_SRP", SRP)
                .Parameters.AddWithValue("U_SKU", SKU)
                .Parameters.AddWithValue("U_UnitOfMeasure", UnitOfMeasure)
                .Parameters.AddWithValue("U_Remarks", Remarks)
                .Parameters.AddWithValue("U_Tags", Tags)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_OrderItemStatus(ByVal RowID As Integer,
                             ByVal LastUpd As DateTime,
                             ByVal LastUpdBy As Integer,
                             ByVal Status As String,
                             ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_orderitemstatus", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_OrderItemQtyOrdered(ByVal RowID As Integer,
                              ByVal LastUpd As DateTime,
                              ByVal LastUpdBy As Integer,
                              ByVal QtyOrdered As Integer,
                              ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_orderitemqtyqrdered", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.Clear()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_QtyOrdered", QtyOrdered)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_OrderItemAccountID(ByVal RowID As Integer,
                          ByVal LastUpd As DateTime,
                          ByVal LastUpdBy As Integer,
                          ByVal AccountID As Integer,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_orderitemaccountid", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_AccountID", AccountID)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_OrderItemTags(ByVal RowID As Integer,
                         ByVal LastUpd As DateTime,
                         ByVal LastUpdBy As Integer,
                         ByVal Tags As String,
                         ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_orderitemtags", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Tags", Tags)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_OrderItemVerification(ByVal RowID As Integer,
                          ByVal LastUpd As DateTime,
                          ByVal LastUpdBy As Integer,
                          ByVal Status As String,
                          ByVal VerifiedBy As Object,
                          ByVal VerifiedDate As Date,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_orderitemverification", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .Parameters.AddWithValue("U_VerifiedBy", VerifiedBy)
                .Parameters.AddWithValue("U_VerifiedDate", VerifiedDate)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_OrderItemPacking(ByVal RowID As Integer,
                        ByVal LastUpd As DateTime,
                        ByVal LastUpdBy As Integer,
                        ByVal Status As String,
                        ByVal PackedBy As Object,
                        ByVal PackedDate As Date,
                        ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_orderitempacking", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .Parameters.AddWithValue("U_PackedBy", PackedBy)
                .Parameters.AddWithValue("U_PackedDate", PackedDate)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_OrderItemDelivery(ByVal RowID As Integer,
                       ByVal LastUpd As DateTime,
                       ByVal LastUpdBy As Integer,
                       ByVal Status As String,
                       ByVal DeliveredBy As Object,
                       ByVal DeliveredDate As Date,
                       ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_orderitemdelivery", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .Parameters.AddWithValue("U_DeliveredBy", DeliveredBy)
                .Parameters.AddWithValue("U_DeliveredDate", DeliveredDate)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Organizations"

    Public Function U_Organizations(ByVal RowID As Integer,
                               ByVal LastUpd As DateTime,
                               ByVal LastUpdBy As Integer,
                               ByVal PrimaryAddressID As Object,
                               ByVal PremiseAddressID As Object,
                               ByVal PrimaryContactID As Object,
                               ByVal Name As String,
                               ByVal TradeName As String,
                               ByVal MainPhone As String,
                               ByVal AltPhone As String,
                               ByVal FaxNumber As String,
                               ByVal EmailAddress As String,
                               ByVal AltEmailAddress As String,
                               ByVal TINNo As String,
                               ByVal Website As String,
                               ByVal OrganizationType As String,
                               ByVal Comments As String,
                               ByVal Image As Object,
                               ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_organizations", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_PrimaryAddressID", PrimaryAddressID)
                .Parameters.AddWithValue("U_PremiseAddressID", PremiseAddressID)
                .Parameters.AddWithValue("U_PrimaryContactID", PrimaryContactID)
                .Parameters.AddWithValue("U_Name", Name)
                .Parameters.AddWithValue("U_Tradename", TradeName)
                .Parameters.AddWithValue("U_MainPhone", MainPhone)
                .Parameters.AddWithValue("U_AltPhone", AltPhone)
                .Parameters.AddWithValue("U_FaxNumber", FaxNumber)
                .Parameters.AddWithValue("U_EmailAddress", EmailAddress)
                .Parameters.AddWithValue("U_AltEmailAddress", AltEmailAddress)
                .Parameters.AddWithValue("U_TINNo", TINNo)
                .Parameters.AddWithValue("U_Website", Website)
                .Parameters.AddWithValue("U_OrganizationType", OrganizationType)
                .Parameters.AddWithValue("U_Comments", Comments)
                .Parameters.AddWithValue("U_Image", Image)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_OrganizationImage(ByVal RowID As Integer,
                                  ByVal LastUpd As DateTime,
                                  ByVal LastUpdby As Integer,
                                  ByVal Image As Object,
                                  ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_organizationimage", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_Image", Image)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "PackingList"

    Public Function I_PackingList(ByVal OrganizationID As Integer,
                                   ByVal Created As DateTime,
                                   ByVal CreatedBy As Integer,
                                   ByVal LastUpdBy As Integer,
                                   ByVal OrderID As Integer,
                                   ByVal PackingListNo As String,
                                   ByVal PackingListDate As Date,
                                   ByVal Status As String,
                                   ByVal Comments As String,
                                   ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_packinglist", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_OrderID", OrderID)
                .Parameters.AddWithValue("I_PackingListNo", PackingListNo)
                .Parameters.AddWithValue("I_PackingListDate", PackingListDate)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_Comments", Comments)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PackingList(ByVal RowID As Integer,
                               ByVal LastUpd As DateTime,
                               ByVal LastUpdBy As Integer,
                               ByVal PackingListNo As String,
                               ByVal Comments As String,
                               ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_packinglist", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_PackingListNo", PackingListNo)
                .Parameters.AddWithValue("U_Comments", Comments)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PackingListStatus(ByVal RowID As Integer,
                              ByVal LastUpd As DateTime,
                              ByVal LastUpdBy As Integer,
                              ByVal Status As String,
                              ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_packingliststatus", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "PackingListCartons"

    Public Function I_PackingListCartons(ByVal OrganizationID As Integer,
                                    ByVal Created As DateTime,
                                    ByVal CreatedBy As Integer,
                                    ByVal LastUpdBy As Integer,
                                    ByVal ContactID As Object,
                                    ByVal CartonSizeID As Object,
                                    ByVal PackingListID As Integer,
                                    ByVal CartonNo As String,
                                    ByVal PackedDate As Date,
                                    ByVal WeightUOM As String,
                                    ByVal Weight As Decimal,
                                    ByVal Amount As Decimal,
                                    ByVal Status As String,
                                    ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_packinglistcartons", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("newPackingListCartonID", MySqlDbType.Int32)
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_ContactID", ContactID)
                .Parameters.AddWithValue("I_CartonSizeID", CartonSizeID)
                .Parameters.AddWithValue("I_PackingListID", PackingListID)
                .Parameters.AddWithValue("I_CartonNo", CartonNo)
                .Parameters.AddWithValue("I_PackedDate", PackedDate)
                .Parameters.AddWithValue("I_WeightUOM", WeightUOM)
                .Parameters.AddWithValue("I_Weight", Weight)
                .Parameters.AddWithValue("I_Amount", Amount)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters("newPackingListCartonID").Direction = ParameterDirection.ReturnValue
                globaldatareader = .ExecuteReader
                globalpackinglistcartonidsp = globaldatareader(0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PackingListCartons(ByVal RowID As Integer,
                                ByVal LastUpd As DateTime,
                                ByVal LastUpdBy As Integer,
                                ByVal ContactID As Object,
                                ByVal CartonSizeID As Object,
                                ByVal CartonNo As String,
                                ByVal PackedDate As Date,
                                ByVal WeightUOM As String,
                                ByVal Weight As Decimal,
                                ByVal Amount As Decimal,
                                ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_packinglistcartons", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_ContactID", ContactID)
                .Parameters.AddWithValue("U_CartonSizeID", CartonSizeID)
                .Parameters.AddWithValue("U_CartonNo", CartonNo)
                .Parameters.AddWithValue("U_PackedDate", PackedDate)
                .Parameters.AddWithValue("U_WeightUOM", WeightUOM)
                .Parameters.AddWithValue("U_Weight", Weight)
                .Parameters.AddWithValue("U_Amount", Amount)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PackingListCartonStatus(ByVal RowID As Integer,
                               ByVal LastUpd As DateTime,
                               ByVal LastUpdBy As Integer,
                               ByVal Status As String,
                               ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_packinglistcartonstatus", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "PackingListCartonItems"

    Public Function I_PackingListCartonItems(ByVal OrganizationID As Integer,
                                   ByVal Created As DateTime,
                                   ByVal CreatedBy As Integer,
                                   ByVal LastUpdBy As Integer,
                                   ByVal PackingListCartonID As Integer,
                                   ByVal OrderItemID As Integer,
                                   ByVal QtyInCarton As Integer,
                                   ByVal Status As String,
                                   ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_packinglistcartonitems", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_PackingListCartonID", PackingListCartonID)
                .Parameters.AddWithValue("I_OrderItemID", OrderItemID)
                .Parameters.AddWithValue("I_QtyInCarton", QtyInCarton)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PackingListCartonItems(ByVal RowID As Integer,
                           ByVal LastUpd As DateTime,
                           ByVal LastUpdBy As Integer,
                           ByVal QtyInCarton As Integer,
                           ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_packinglistcartonitems", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_QtyInCarton", QtyInCarton)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PackingListCartonItemStatus(ByVal RowID As Integer,
                           ByVal LastUpd As DateTime,
                           ByVal LastUpdBy As Integer,
                           ByVal Status As String,
                           ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_packinglistcartonitemstatus", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "PickList"

    Public Function I_PickList(ByVal OrganizationID As Integer,
                          ByVal Created As DateTime,
                          ByVal CreatedBy As Integer,
                          ByVal LastUpdBy As Integer,
                          ByVal InventoryLocationID As Integer,
                          ByVal PickListNo As String,
                          ByVal PickListDate As Date,
                          ByVal Status As String,
                          ByVal Comments As String,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_picklist", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("newPickListID", MySqlDbType.Int32)
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_InventoryLocationID", InventoryLocationID)
                .Parameters.AddWithValue("I_PickListNo", PickListNo)
                .Parameters.AddWithValue("I_PickListDate", PickListDate)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_Comments", Comments)
                .Parameters("newPickListID").Direction = ParameterDirection.ReturnValue
                globaldatareader = .ExecuteReader
                globalpicklistidsp = globaldatareader(0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PickList(ByVal RowID As Integer,
                            ByVal LastUpd As DateTime,
                            ByVal LastUpdBy As Integer,
                            ByVal InventoryLocationID As Object,
                            ByVal ContactID As Object,
                            ByVal Comments As String,
                            ByVal Status As String,
                            ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_picklist", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_InventoryLocationID", InventoryLocationID)
                .Parameters.AddWithValue("U_ContactID", ContactID)
                .Parameters.AddWithValue("U_Comments", Comments)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PickListStatus(ByVal RowID As Integer,
                           ByVal LastUpd As DateTime,
                           ByVal LastUpdBy As Integer,
                           ByVal Status As String,
                           ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_pickliststatus", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PickListCompletedDate(ByVal RowID As Integer,
                           ByVal LastUpd As DateTime,
                           ByVal LastUpdBy As Integer,
                           ByVal CompletedDate As Date,
                           ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_picklistcompleteddate", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_CompletedDate", CompletedDate)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PickListComments(ByVal RowID As Integer,
                              ByVal LastUpd As DateTime,
                              ByVal LastUpdBy As Integer,
                              ByVal Comments As String,
                              ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_picklistcomments", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Comments", Comments)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "PickListOrders"

    Public Function I_PickListOrders(ByVal OrganizationID As Integer,
                         ByVal Created As DateTime,
                         ByVal CreatedBy As Integer,
                         ByVal LastUpdBy As Integer,
                         ByVal PickListID As Integer,
                         ByVal OrderID As Integer,
                         ByVal OrderItemID As Integer,
                         ByVal ModifiedFlg As Char,
                         ByVal Status As String,
                         ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_picklistorders", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("newPickListOrderID", MySqlDbType.Int32)
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_PickListID", PickListID)
                .Parameters.AddWithValue("I_OrderID", OrderID)
                .Parameters.AddWithValue("I_OrderItemID", OrderItemID)
                .Parameters.AddWithValue("I_ModifiedFlg", ModifiedFlg)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters("newPickListOrderID").Direction = ParameterDirection.ReturnValue
                globaldatareader = .ExecuteReader
                globalpicklistorderidsp = globaldatareader(0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PickListOrderStatus(ByVal RowID As Integer,
                               ByVal LastUpd As DateTime,
                               ByVal LastUpdBy As Integer,
                               ByVal Status As String,
                               ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_picklistorderstatus", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PickListOrderModifiedFlg(ByVal RowID As Integer,
                             ByVal LastUpd As DateTime,
                             ByVal LastUpdBy As Integer,
                             ByVal ModifiedFlg As Char,
                             ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_picklistordermodifiedflg", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_ModifiedFlg", ModifiedFlg)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "PickListOrderItems"

    Public Function I_PickListOrderItems(ByVal OrganizationID As Integer,
                        ByVal Created As DateTime,
                        ByVal CreatedBy As Integer,
                        ByVal LastUpdBy As Integer,
                        ByVal PickListOrderID As Integer,
                        ByVal ProductInventoryLocationID As Integer,
                        ByVal QtyPicked As Integer,
                        ByVal QtyAvailable As Integer,
                        ByVal IssueFlg As Char,
                        ByVal Status As String,
                        ByVal Remarks As String,
                        ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_picklistorderitems", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_PickListOrderID", PickListOrderID)
                .Parameters.AddWithValue("I_ProductInventoryLocationID", ProductInventoryLocationID)
                .Parameters.AddWithValue("I_QtyPicked", QtyPicked)
                .Parameters.AddWithValue("I_QtyAvailable", QtyAvailable)
                .Parameters.AddWithValue("I_IssueFlg", IssueFlg)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_Remarks", Remarks)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PickListOrderItems(ByVal RowID As Integer,
                                 ByVal LastUpd As DateTime,
                                 ByVal LastUpdBy As Integer,
                                 ByVal QtyPicked As Integer,
                                 ByVal QtyAvailable As Integer,
                                 ByVal IssueFlg As Char,
                                 ByVal Remarks As String,
                                 ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_picklistorderitems", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_QtyPicked", QtyPicked)
                .Parameters.AddWithValue("U_QtyAvailable", QtyAvailable)
                .Parameters.AddWithValue("U_IssueFlg", IssueFlg)
                .Parameters.AddWithValue("U_Remarks", Remarks)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PickListOrderItemStatus(ByVal RowID As Integer,
                                ByVal LastUpd As DateTime,
                                ByVal LastUpdBy As Integer,
                                ByVal Status As String,
                                ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_picklistorderitemstatus", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_PickListOrderItemQtyDelivered(ByVal RowID As Integer,
                                   ByVal LastUpd As DateTime,
                                   ByVal LastUpdBy As Integer,
                                   ByVal QtyDelivered As Integer,
                                   ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_picklistorderitemqtydelivered", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_QtyDelivered", QtyDelivered)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "PickListGroup"

    Public Function I_PickListGroup(ByVal OrganizationID As Integer,
                          ByVal Created As DateTime,
                          ByVal CreatedBy As Integer,
                          ByVal LastUpdBy As Integer,
                          ByVal GroupName As String,
                          ByVal Status As String,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_picklistgroup", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_GroupName", GroupName)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Products"

    Public Function I_Products(ByVal OrganizationID As Integer,
                               ByVal Created As DateTime,
                               ByVal CreatedBy As Integer,
                               ByVal LastUpdBy As Integer,
                               ByVal CategoryID As Object,
                               ByVal BrandID As Object,
                               ByVal CompanyID As Object,
                               ByVal ProductCode As String,
                               ByVal ProductName As String,
                               ByVal BrandName As String,
                               ByVal Category As String,
                               ByVal Company As String,
                               ByVal UnitOfMeasure As String,
                               ByVal Description As String,
                               ByVal UnitPrice As Decimal,
                               ByVal Status As String,
                               ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_products", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_CategoryID", CategoryID)
                .Parameters.AddWithValue("I_BrandID", BrandID)
                .Parameters.AddWithValue("I_CompanyID", CompanyID)
                .Parameters.AddWithValue("I_ProductCode", ProductCode)
                .Parameters.AddWithValue("I_ProductName", ProductName)
                .Parameters.AddWithValue("I_BrandName", BrandName)
                .Parameters.AddWithValue("I_Category", Category)
                .Parameters.AddWithValue("I_Company", Company)
                .Parameters.AddWithValue("I_UnitOfMeasure", UnitOfMeasure)
                .Parameters.AddWithValue("I_Description", Description)
                .Parameters.AddWithValue("I_UnitPrice", UnitPrice)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_Products(ByVal RowID As Integer,
                            ByVal LastUpd As DateTime,
                            ByVal LastUpdby As Integer,
                            ByVal CategoryID As Object,
                            ByVal BrandID As Object,
                            ByVal CompanyID As Object,
                            ByVal ProductCode As String,
                            ByVal ProductName As String,
                            ByVal UnitOfMeasure As String,
                            ByVal BrandName As String,
                            ByVal Category As String,
                            ByVal Company As String,
                            ByVal Description As String,
                            ByVal UnitPrice As Decimal,
                            ByVal Image As String,
                            ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_products", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_CategoryID", CategoryID)
                .Parameters.AddWithValue("U_BrandID", BrandID)
                .Parameters.AddWithValue("U_CompanyID", CompanyID)
                .Parameters.AddWithValue("U_ProductCode", ProductCode)
                .Parameters.AddWithValue("U_ProductName", ProductName)
                .Parameters.AddWithValue("U_UnitOfMeasure", UnitOfMeasure)
                .Parameters.AddWithValue("U_BrandName", BrandName)
                .Parameters.AddWithValue("U_Category", Category)
                .Parameters.AddWithValue("U_Company", Company)
                .Parameters.AddWithValue("U_Description", Description)
                .Parameters.AddWithValue("U_UnitPrice", UnitPrice)
                .Parameters.AddWithValue("U_Image", Image)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_ProductImage(ByVal RowID As Integer,
                                     ByVal LastUpd As DateTime,
                                     ByVal LastUpdby As Integer,
                                     ByVal Image As Object,
                                     ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_productimage", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_Image", Image)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "ProductColors"

    Public Function I_ProductColors(ByVal OrganizationID As Integer,
                           ByVal Created As DateTime,
                           ByVal CreatedBy As Integer,
                           ByVal LastUpdBy As Integer,
                           ByVal ProductID As Integer,
                           ByVal ColorID As Integer,
                           ByVal Status As String,
                           ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_productcolors", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("newProductColorsID", MySqlDbType.Int32)
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_ProductID", ProductID)
                .Parameters.AddWithValue("I_ColorID", ColorID)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters("newProductColorsID").Direction = ParameterDirection.ReturnValue
                globaldatareader = .ExecuteReader
                globalproductcolorsidsp = globaldatareader(0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "ProductColorSizes"

    Public Function I_ProductColorSizes(ByVal OrganizationID As Integer,
                          ByVal Created As DateTime,
                          ByVal CreatedBy As Integer,
                          ByVal LastUpdBy As Integer,
                          ByVal ProductColorID As Integer,
                          ByVal Size As Decimal,
                          ByVal SeasonCode As String,
                          ByVal SKU As String,
                          ByVal Status As String,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_productcolorsizes", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("newProductColorSizesID", MySqlDbType.Int32)
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_ProductColorID", ProductColorID)
                .Parameters.AddWithValue("I_Size", Size)
                .Parameters.AddWithValue("I_SeasonCode", SeasonCode)
                .Parameters.AddWithValue("I_SKU", SKU)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters("newProductColorSizesID").Direction = ParameterDirection.ReturnValue
                globaldatareader = .ExecuteReader
                globalproductcolorsizesidsp = globaldatareader(0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_ProductColorSizeStatus(ByVal RowID As Integer,
                                    ByVal LastUpd As DateTime,
                                    ByVal LastUpdby As Integer,
                                    ByVal Status As String,
                                    ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_productcolorsizestatus", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_ProductColorSizeSKU(ByVal RowID As Integer,
                                    ByVal LastUpd As DateTime,
                                    ByVal LastUpdby As Integer,
                                    ByVal SKU As String,
                                    ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_productcolorsizesku", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_SKU", SKU)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Async Function U_ProductColorSizeSKU2(RowID As Integer,
        LastUpd As Date,
        LastUpdby As Integer,
        SKU2 As String,
        globalformname As Form) As Task(Of Integer)

        Dim queryText = "UPDATE productcolorsizes SET
            LastUpd = CURRENT_TIMESTAMP(),
            LastUpdBy = @userId,
            SKU2 = @sku2
            WHERE RowID = @rowId;"
        Using connection As New MySqlConnection(connectionString:=connectionString),
            command As New MySqlCommand(commandText:=queryText, connection:=connection)

            With command.Parameters
                .AddWithValue("@userId", LastUpdby)
                .AddWithValue("@sku2", SKU2)
                .AddWithValue("@rowId", RowID)
            End With

            Await connection.OpenAsync()
            Return Await command.ExecuteNonQueryAsync()
        End Using
    End Function

    Public Function U_ProductColorSizeSeasonCode(ByVal RowID As Integer,
                                   ByVal LastUpd As DateTime,
                                   ByVal LastUpdby As Integer,
                                   ByVal SeasonCode As String,
                                   ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_productcolorsizeseasoncode", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_SeasonCode", SeasonCode)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_ProductColorSizeSoldInfo(ByVal RowID As Integer,
                                         ByVal LastUpd As DateTime,
                                         ByVal LastUpdby As Integer,
                                         ByVal LastSoldCount As Integer,
                                         ByVal LastSoldDate As Date,
                                         ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_productcolorsizesoldinfo", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_LastSoldCount", LastSoldCount)
                .Parameters.AddWithValue("U_LastSoldDate", LastSoldDate)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_ProductColorSizeTotalDamageQty(ByVal RowID As Integer,
                                    ByVal LastUpd As DateTime,
                                    ByVal LastUpdby As Integer,
                                    ByVal TotalDamageQty As Integer,
                                    ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_productcolorsizetotaldamageqty", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_TotalDamageQty", TotalDamageQty)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "ProductBundles"

    Public Function I_ProductBundles(ByVal OrganizationID As Integer,
                                   ByVal Created As DateTime,
                                   ByVal CreatedBy As Integer,
                                   ByVal LastUpdBy As Integer,
                                   ByVal CategoryID As Object,
                                   ByVal BrandID As Object,
                                   ByVal CompanyID As Object,
                                   ByVal BundleName As String,
                                   ByVal SKU As String,
                                   ByVal UnitOfMeasure As String,
                                   ByVal Description As String,
                                   ByVal Status As String,
                                   ByVal SRP As Decimal,
                                   ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_productbundles", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_CategoryID", CategoryID)
                .Parameters.AddWithValue("I_BrandID", BrandID)
                .Parameters.AddWithValue("I_CompanyID", CompanyID)
                .Parameters.AddWithValue("I_BundleName", BundleName)
                .Parameters.AddWithValue("I_SKU", SKU)
                .Parameters.AddWithValue("I_UnitOfMeasure", UnitOfMeasure)
                .Parameters.AddWithValue("I_Description", Description)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_SRP", SRP)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_ProductBundles(ByVal RowID As Integer,
                                    ByVal LastUpd As DateTime,
                                    ByVal LastUpdby As Integer,
                                    ByVal CategoryID As Object,
                                    ByVal BrandID As Object,
                                    ByVal CompanyID As Object,
                                    ByVal BundleName As String,
                                    ByVal SKU As String,
                                    ByVal UnitOfMeasure As String,
                                    ByVal Description As String,
                                    ByVal Status As String,
                                    ByVal SRP As Decimal,
                                    ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_productbundles", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_CategoryID", CategoryID)
                .Parameters.AddWithValue("U_BrandID", BrandID)
                .Parameters.AddWithValue("U_CompanyID", CompanyID)
                .Parameters.AddWithValue("U_BundleName", BundleName)
                .Parameters.AddWithValue("U_SKU", SKU)
                .Parameters.AddWithValue("U_UnitOfMeasure", UnitOfMeasure)
                .Parameters.AddWithValue("U_Description", Description)
                .Parameters.AddWithValue("U_Status", Status)
                .Parameters.AddWithValue("U_SRP", SRP)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "ProductBundleItems"

    Public Function I_ProductBundleItems(ByVal OrganizationID As Integer,
                         ByVal Created As DateTime,
                         ByVal CreatedBy As Integer,
                         ByVal LastUpdBy As Integer,
                         ByVal ProductBundleID As Integer,
                         ByVal ProductColorSizeID As Integer,
                         ByVal QtyAvailable As Integer,
                         ByVal Status As String,
                         ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_productbundleitems", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_ProductBundleID", ProductBundleID)
                .Parameters.AddWithValue("I_ProductColorSizeID", ProductColorSizeID)
                .Parameters.AddWithValue("I_QtyAvailable", QtyAvailable)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_ProductBundleItems(ByVal RowID As Integer,
                            ByVal LastUpd As DateTime,
                            ByVal LastUpdBy As Integer,
                            ByVal QtyAvailable As Integer,
                            ByVal Status As String,
                            ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_productbundleitems", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_QtyAvailable", QtyAvailable)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "ProductInventoryLocation"

    Public Function I_ProductInventoryLocation(ByVal OrganizationID As Integer,
                        ByVal Created As DateTime,
                        ByVal CreatedBy As Integer,
                        ByVal LastUpdBy As Integer,
                        ByVal RackShelfColumnID As Integer,
                        ByVal ProductColorSizeID As Integer,
                        ByVal TotalAvailableQty As Integer,
                        ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_productinventorylocation", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("newProductInventoryLocationID", MySqlDbType.Int32)
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_RackShelfColumnID", RackShelfColumnID)
                .Parameters.AddWithValue("I_ProductColorSizeID", ProductColorSizeID)
                .Parameters.AddWithValue("I_TotalAvailableQty", TotalAvailableQty)
                .Parameters("newProductInventoryLocationID").Direction = ParameterDirection.ReturnValue
                globaldatareader = .ExecuteReader
                globalproductinventorylocationidsp = globaldatareader(0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_ProductInventoryLocationTotals(ByVal RowID As Integer,
                           ByVal LastUpd As DateTime,
                           ByVal LastUpdBy As Integer,
                           ByVal TotalAvailableQty As Integer,
                           ByVal TotalReserveQty As Integer,
                           ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_productinventorylocationtotals", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_TotalAvailableQty", TotalAvailableQty)
                .Parameters.AddWithValue("U_TotalReserveQty", TotalReserveQty)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_ProductInventoryLocationQtyAllocated(ByVal RowID As Integer,
                          ByVal LastUpd As DateTime,
                          ByVal LastUpdBy As Integer,
                          ByVal TotalAllocatedQty As Integer,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_productinventorylocationqtyallocated", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_TotalAllocatedQty", TotalAllocatedQty)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "ProductMovementHistory"

    Public Function I_ProductMovementHistory(ByVal OrganizationID As Integer,
                       ByVal Created As DateTime,
                       ByVal CreatedBy As Integer,
                       ByVal LastUpdBy As Integer,
                       ByVal OrderID As Object,
                       ByVal LineUpID As Object,
                       ByVal PickListID As Object,
                       ByVal ProductColorSizeID As Object,
                       ByVal ProductInventoryLocationIDA As Object,
                       ByVal ProductInventoryLocationIDB As Object,
                       ByVal CurrentQty As Integer,
                       ByVal QtyToApply As Integer,
                       ByVal NewQty As Integer,
                       ByVal TransactionType As String,
                       ByVal ColumnName As String,
                       ByVal Comments As String,
                       ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_productmovementhistory", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_OrderID", OrderID)
                .Parameters.AddWithValue("I_LineUpID", LineUpID)
                .Parameters.AddWithValue("I_PickListID", PickListID)
                .Parameters.AddWithValue("I_ProductColorSizeID", ProductColorSizeID)
                .Parameters.AddWithValue("I_ProductInventoryLocationIDA", ProductInventoryLocationIDA)
                .Parameters.AddWithValue("I_ProductInventoryLocationIDB", ProductInventoryLocationIDB)
                .Parameters.AddWithValue("I_CurrentQty", CurrentQty)
                .Parameters.AddWithValue("I_QtyToApply", QtyToApply)
                .Parameters.AddWithValue("I_NewQty", NewQty)
                .Parameters.AddWithValue("I_TransactionType", TransactionType)
                .Parameters.AddWithValue("I_ColumnName", ColumnName)
                .Parameters.AddWithValue("I_Comments", Comments)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "RackShelfColumn"

    Public Function I_RackShelfColumn(ByVal OrganizationID As Integer,
                                ByVal Created As DateTime,
                                ByVal CreatedBy As Integer,
                                ByVal LastUpdBy As Integer,
                                ByVal InventoryLocationID As Integer,
                                ByVal RackNo As String,
                                ByVal ShelfNo As String,
                                ByVal ColumnNo As String,
                                ByVal PickOrderNo As Integer,
                                ByVal Remarks As String,
                                ByVal Status As String,
                                ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_rackshelfcolumn", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_InventoryLocationID", InventoryLocationID)
                .Parameters.AddWithValue("I_RackNo", RackNo)
                .Parameters.AddWithValue("I_ShelfNo", ShelfNo)
                .Parameters.AddWithValue("I_ColumnNo", ColumnNo)
                .Parameters.AddWithValue("I_PickOrderNo", PickOrderNo)
                .Parameters.AddWithValue("I_Remarks", Remarks)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_RackShelfColumn(ByVal RowID As Integer,
                        ByVal LastUpd As DateTime,
                        ByVal LastUpdby As Integer,
                        ByVal RackNo As String,
                        ByVal ShelfNo As String,
                        ByVal ColumnNo As String,
                        ByVal PickOrderNo As Integer,
                        ByVal Remarks As String,
                        ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_rackshelfcolumn", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_RackNo", RackNo)
                .Parameters.AddWithValue("U_ShelfNo", ShelfNo)
                .Parameters.AddWithValue("U_ColumnNo", ColumnNo)
                .Parameters.AddWithValue("U_PickOrderNo", PickOrderNo)
                .Parameters.AddWithValue("U_Remarks", Remarks)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Shifts"

    Public Function I_Shifts(ByVal OrganizationID As Integer,
                       ByVal Created As DateTime,
                       ByVal CreatedBy As Integer,
                       ByVal LastUpdBy As Integer,
                       ByVal ShiftName As String,
                       ByVal TimeFrom As DateTime,
                       ByVal TimeTo As DateTime,
                       ByVal Status As String,
                       ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_shifts", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_ShiftName", ShiftName)
                .Parameters.AddWithValue("I_TimeFrom", TimeFrom)
                .Parameters.AddWithValue("I_TimeTo", TimeTo)
                .Parameters.AddWithValue("I_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_Shifts(ByVal RowID As Integer,
                                ByVal LastUpd As DateTime,
                                ByVal LastUpdby As Integer,
                                ByVal ShiftName As String,
                                ByVal TimeFrom As DateTime,
                                ByVal TimeTo As DateTime,
                                ByVal Status As String,
                                ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_shifts", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdby)
                .Parameters.AddWithValue("U_ShiftName", ShiftName)
                .Parameters.AddWithValue("U_TimeFrom", TimeFrom)
                .Parameters.AddWithValue("U_TimeTo", TimeTo)
                .Parameters.AddWithValue("U_Status", Status)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

#Region "Users"

    Public Function I_Users(ByVal OrganizationID As Integer,
                        ByVal Created As DateTime,
                        ByVal CreatedBy As Integer,
                        ByVal LastUpd As DateTime,
                        ByVal LastUpdBy As Integer,
                        ByVal UserID As String,
                        ByVal Password As String,
                        ByVal PositionID As Object,
                        ByVal FirstName As String,
                        ByVal MiddleName As String,
                        ByVal LastName As String,
                        ByVal EmailAddress As String,
                        ByVal Status As String,
                        ByVal Comments As String,
                        ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_users", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpd", LastUpd)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_UserID", UserID)
                .Parameters.AddWithValue("I_Password", Password)
                .Parameters.AddWithValue("I_PositionID", PositionID)
                .Parameters.AddWithValue("I_FirstName", FirstName)
                .Parameters.AddWithValue("I_MiddleName", MiddleName)
                .Parameters.AddWithValue("I_LastName", LastName)
                .Parameters.AddWithValue("I_EmailAddress", EmailAddress)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_Comments", Comments)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

    Public Function U_Users(ByVal RowID As Integer,
                        ByVal LastUpd As DateTime,
                        ByVal LastUpdBy As Integer,
                        ByVal UserID As String,
                        ByVal Password As String,
                        ByVal PositionID As Object,
                        ByVal FirstName As String,
                        ByVal MiddleName As String,
                        ByVal LastName As String,
                        ByVal EmailAddress As String,
                        ByVal Status As String,
                        ByVal Comments As String,
                        ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_users", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_UserID", UserID)
                .Parameters.AddWithValue("U_Password", Password)
                .Parameters.AddWithValue("U_PositionID", PositionID)
                .Parameters.AddWithValue("U_FirstName", FirstName)
                .Parameters.AddWithValue("U_MiddleName", MiddleName)
                .Parameters.AddWithValue("U_LastName", LastName)
                .Parameters.AddWithValue("U_EmailAddress", EmailAddress)
                .Parameters.AddWithValue("U_Status", Status)
                .Parameters.AddWithValue("U_Comments", Comments)
                .CommandType = CommandType.StoredProcedure
                F_return = (.ExecuteNonQuery > 0)
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, globalformname.Name))
            Finally
                connection.Close()
            End Try
        End With
        Return F_return
    End Function

#End Region

End Module