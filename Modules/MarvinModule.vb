Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.OleDb
Imports WarehouseManagementSystem.Core.Enums

Module MarvinModule
    Public gloPoNo, glopono1, glosuppid, globalsuppliercustomerid, globalsupplierid, glolocid, glorcsorderitemid, gloqtyapplied, gloprodctinvtylocid As Integer
    Public gloOrType, gloRRNo, gloRRDate, gloRRReceivedBy, gloRRTimeArrived, gloRRArrivedIn, gloRRContainerNo, gloRRSealNo, gloRRBrands As String
    Public gloNewR As Boolean = False

#Region "Populate Combobox"

    Sub PopulatePRNO(ByVal icombobox As ComboBox, ByVal combotype As String, ByVal globalformname As Object)
        Try
            icombobox.Items.Clear()
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand("cb_populate_pono", globalconn)
            cmd1.CommandType = CommandType.StoredProcedure
            cmd1.Parameters.AddWithValue("P_OrganizationID", Z_OrganizationID)
            cmd1.Parameters.AddWithValue("P_Type", combotype)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                icombobox.Items.Add(reader1(0).ToString())
            End While
            reader1.Close()
            globalconn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub populateDataGridViewComboBox(ByVal comboquery As String, ByVal combo As DataGridViewComboBoxColumn, ByVal globalformname As Object)
        Try
            combo.Items.Clear()
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd As New MySqlCommand(comboquery, globalconn)
            With cmd
                Dim comboreader As MySqlDataReader = .ExecuteReader
                With comboreader
                    While .Read
                        combo.Items.Add(comboreader(0).ToString)
                    End While
                    .Close()
                End With
            End With
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub populateComboBox(ByVal comboquery As String, ByVal combo As ComboBox, ByVal globalformname As Object)
        Try
            combo.Items.Clear()
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd As New MySqlCommand(comboquery, globalconn)
            With cmd
                Dim comboreader As MySqlDataReader = .ExecuteReader
                With comboreader
                    While .Read
                        combo.Items.Add(comboreader(0).ToString)
                    End While
                    .Close()
                End With
            End With
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateAccountNameReceiving(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,''),' - ',COALESCE(a.accounttype,'')),'') AS 'accountname' FROM accounts a WHERE a.organizationid = " & Z_OrganizationID & " AND a.accounttype IN ('Customer','Supplier') AND a.`status` = 'Active' GROUP BY a.rowid ORDER BY a.companyname "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
            globalconn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateReceivedBy(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,''),' / ',COALESCE(c.`type`,'')),'') AS 'firstname' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.`status` = 'Active' AND c.`type` IN ('Picker','Packer') GROUP BY c.rowid ORDER BY c.firstname "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

#End Region

#Region "Auto Complete Combobox"

    Sub globalautocompleteAccountNameReceiving(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim accountname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,''),' - ',COALESCE(a.accounttype,'')),'') AS 'accountname' FROM accounts a WHERE a.organizationid = " & Z_OrganizationID & " AND a.accounttype IN ('Customer','Supplier') AND a.`status` = 'Active' GROUP BY a.rowid ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                accountname.Add(ds.Tables(0).Rows(i)("accountname").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = accountname
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteReceivedBy(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim contactname As New AutoCompleteStringCollection
            Dim cmd1 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,''),' / ',COALESCE(c.`type`,'')),'') AS 'firstname' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.`status` = 'Active' AND c.`type` IN ('Picker','Packer') GROUP BY c.rowid ", globalconn)
            Dim cmd2 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(c.lastname,''),', ',COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,''),' / ',COALESCE(c.`type`,'')),'') AS 'lastname' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.status = 'Active' AND c.`type` IN ('Picker','Packer') GROUP BY c.rowid ", globalconn)
            Dim da1 As New MySqlDataAdapter(cmd1)
            Dim da2 As New MySqlDataAdapter(cmd2)
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet
            da1.Fill(ds1, "list1")
            da2.Fill(ds2, "list2")
            Dim i As Integer
            For i = 0 To ds1.Tables(0).Rows.Count - 1
                contactname.Add(ds1.Tables(0).Rows(i)("firstname").ToString())
            Next
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                contactname.Add(ds2.Tables(0).Rows(i)("lastname").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = contactname
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

#End Region

#Region "Get ID/Information"

    Sub getSupplierID(ByVal globalicustomername As String, ByVal globalformname As Object)
        Try
            globalsupplierid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM accounts WHERE CONCAT(COALESCE(companyname,''),' - ',COALESCE(accountno,'')) = """ & globalicustomername & """ AND organizationid = " & Z_OrganizationID & " AND accounttype = 'Supplier' ")
            If dtGid.Rows.Count <> 0 Then
                globalsupplierid = dtGid.Rows(0)(0)
            Else
                globalsupplierid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderIDSupA(ByVal globaliorderid As Integer, ByVal globaliordernumber As String, ByVal globaliordertype As String, ByVal globalformname As Object)
        Try
            globalorderid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM orders WHERE rowid != " & globaliorderid & " AND ordernumber = """ & globaliordernumber & """ AND ordertype = '" & globaliordertype & "' AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalorderid = dtGid.Rows(0)(0)
            Else
                globalorderid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderIDSupB(ByVal globaliordernumber As String, ByVal globaliordertype As String, ByVal globalformname As Object)
        Try
            globalorderid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM orders WHERE ordernumber = """ & globaliordernumber & """ AND ordertype = '" & globaliordertype & "' AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalorderid = dtGid.Rows(0)(0)
            Else
                globalorderid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getIDPRNOA(ByVal globalireferenceno As String, ByVal globaliordertype As String, ByVal globalformname As Object)
        Try
            gloPoNo = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM orders WHERE ordernumber = """ & globalireferenceno & """ AND ordertype= """ & globaliordertype & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                gloPoNo = dtGid.Rows(0)(0)
            Else
                gloPoNo = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getIDPRNOB(ByVal globalireferenceno As String, ByVal globaliordertype As String, ByVal globalformname As Object)
        Try
            gloPoNo = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM orders WHERE ordernumber = """ & globalireferenceno & """ AND ordertype= """ & globaliordertype & """ AND organizationid = " & Z_OrganizationID & " AND `status` = 'New' ")
            If dtGid.Rows.Count <> 0 Then
                gloPoNo = dtGid.Rows(0)(0)
            Else
                gloPoNo = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub MgetSupplierID(ByVal globalisuppliercustomername As String, ByVal globalformname As Object)
        Try
            glosuppid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM accounts WHERE COALESCE(CONCAT(COALESCE(companyname,''),' - ',COALESCE(accountno,''),' - ',COALESCE(accounttype,'')),'') = """ & globalisuppliercustomername & """ AND organizationid = " & Z_OrganizationID & " AND accounttype in ('Supplier','Customer') ")
            If dtGid.Rows.Count <> 0 Then
                glosuppid = dtGid.Rows(0)(0)
            Else
                glosuppid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getSupplierCustomerID(ByVal globalicustomername As String, ByVal globalformname As Object)
        Try
            globalsuppliercustomerid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM accounts WHERE COALESCE(CONCAT(COALESCE(companyname,''),' - ',COALESCE(accountno,''),' - ',COALESCE(accounttype,'')),'') = """ & globalicustomername & """ AND organizationid = " & Z_OrganizationID & " AND accounttype IN ('Supplier','Customer') ")
            If dtGid.Rows.Count <> 0 Then
                globalsuppliercustomerid = dtGid.Rows(0)(0)
            Else
                globalsuppliercustomerid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getReceivedBy(ByVal globalicontactname As String, ByVal globalformname As Object)
        Try
            globalcontactid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(c.rowid,0) FROM contacts c WHERE COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,''),' / ',COALESCE(c.`type`,'')),'') = """ & globalicontactname & """ AND c.organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalcontactid = dtGid.Rows(0)(0)
            Else
                globalcontactid = 0
            End If
            If globalcontactid = 0 Then
                dtGid = getDataTableForSQL("SELECT COALESCE(c.rowid,0) FROM contacts c WHERE COALESCE(CONCAT(COALESCE(c.lastname,''),', ',COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,''),' / ',COALESCE(c.`type`,'')),'') = """ & globalicontactname & """ AND c.organizationid = " & Z_OrganizationID & " ")
                If dtGid.Rows.Count <> 0 Then
                    globalcontactid = dtGid.Rows(0)(0)
                Else
                    globalcontactid = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderItemApproveFlg(ByVal globaliorderitemid As Integer, ByVal globalformname As Object)
        Try
            globalorderitemapproveflg = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGflg As New DataTable
            dtGflg = getDataTableForSQL("SELECT COALESCE(oi.`approval`,'') FROM orderitems oi WHERE oi.rowid = " & globaliorderitemid & " ")
            If dtGflg.Rows.Count <> 0 Then
                globalorderitemapproveflg = dtGflg.Rows(0)(0)
            Else
                globalorderitemapproveflg = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getInventoryLocID(ByVal globalformname As Object)
        Try
            glolocid = 0
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM inventorylocations WHERE `type` = 'Main' AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                glolocid = dtGid.Rows(0)(0)
            Else
                glolocid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getProductInventoryLocID(ByVal globalirackcolumnshelfid As Integer, ByVal globaliproductcolorsizeid As Integer, ByVal globalformname As Object)
        Try
            gloprodctinvtylocid = 0
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM productinventorylocation WHERE rackshelfcolumnid = " & globalirackcolumnshelfid & " AND productcolorsizeid = " & globaliproductcolorsizeid & " AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                gloprodctinvtylocid = dtGid.Rows(0)(0)
            Else
                gloprodctinvtylocid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getRCSOrderItemID(ByVal globaliproductinventorylocationid As Integer, ByVal globaliorderitemid As Integer, ByVal globalformname As Object)
        Try
            glorcsorderitemid = 0 : gloqtyapplied = 0
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0),COALESCE(qtyapplied,0) FROM rscorderitems WHERE prodinventorylocid = " & globaliproductinventorylocationid & " AND orderitemsid = " & globaliorderitemid & " AND organizationid = " & Z_OrganizationID & " AND `status` = 'Active' ")
            If dtGid.Rows.Count <> 0 Then
                glorcsorderitemid = dtGid.Rows(0)(0)
                gloqtyapplied = dtGid.Rows(0)(1)
            Else
                glorcsorderitemid = 0
                gloqtyapplied = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getRRInfo(ByVal globalirelatedorderid As Integer, ByVal globalformname As Object)
        Try
            gloRRNo = "" : gloRRDate = "" : gloRRReceivedBy = "" : gloRRTimeArrived = "" : gloRRArrivedIn = "" : gloRRContainerNo = "" : gloRRSealNo = "" : gloRRBrands = ""
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rr.ordernumber,''),DATE_FORMAT(rr.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,''),' / ',COALESCE(c.`type`,'')),'')," &
                            "COALESCE(TIME_FORMAT(rr.timearrived,'%r'),''),COALESCE(rr.arrivedin,''),COALESCE(rr.containerno,''),COALESCE(rr.sealno,''),COALESCE(rr.receivedbrands,'') FROM orders rr LEFT JOIN contacts c ON rr.contactid = c.rowid " &
                            $"WHERE rr.ordertype = '{OrderType.RR.ToString()}' AND rr.relatedorderid = " & globalirelatedorderid & " AND rr.organizationid = " & Z_OrganizationID & " AND rr.`status` != 'Cancelled' ")
            If dtGid.Rows.Count <> 0 Then
                gloRRNo = dtGid.Rows(0)(0)
                gloRRDate = dtGid.Rows(0)(1)
                gloRRReceivedBy = dtGid.Rows(0)(2)
                gloRRTimeArrived = dtGid.Rows(0)(3)
                gloRRArrivedIn = dtGid.Rows(0)(4)
                gloRRContainerNo = dtGid.Rows(0)(5)
                gloRRSealNo = dtGid.Rows(0)(6)
                gloRRBrands = dtGid.Rows(0)(7)
            Else
                gloRRNo = "" : gloRRDate = "" : gloRRReceivedBy = "" : gloRRTimeArrived = "" : gloRRArrivedIn = "" : gloRRContainerNo = "" : gloRRSealNo = "" : gloRRBrands = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getProductColorSizeTotalDamageQty(ByVal globaliproductcolorsizeid As Object, ByVal globalformname As Object)
        Try
            globaltotalqtydamage = 0
            Dim dtGtdq As New DataTable
            Dim id = If(globaliproductcolorsizeid Is Nothing, 0, CInt(globaliproductcolorsizeid))
            dtGtdq = getDataTableForSQL("SELECT COALESCE(pcs.totaldamageqty,'') FROM productcolorsizes pcs WHERE pcs.rowid = " & id & " ")
            If dtGtdq.Rows.Count <> 0 Then
                globaltotalqtydamage = dtGtdq.Rows(0)(0)
            Else
                globaltotalqtydamage = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

#End Region

#Region "Stored Procedure"

#Region "Insert"

    Public Function I_PositionView(ByVal OrganizationID As Integer,
                                  ByVal Created As DateTime,
                                  ByVal CreatedBy As Integer,
                                  ByVal LastUpd As DateTime,
                                  ByVal LastUpdBy As Integer,
                                  ByVal PositionID As Integer,
                                  ByVal ViewID As Integer,
                                  ByVal Creates As Char,
                                  ByVal Updates As Char,
                                  ByVal Disable As Char,
                                  ByVal Reading As Char,
                                  ByVal Remarks As String,
                                  ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_positionview", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpd", LastUpd)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_PositionID", PositionID)
                .Parameters.AddWithValue("I_ViewID", ViewID)
                .Parameters.AddWithValue("I_Creates", Creates)
                .Parameters.AddWithValue("I_Updates", Updates)
                .Parameters.AddWithValue("I_Disable", Disable)
                .Parameters.AddWithValue("I_ReadOnly", Reading)
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

    Public Function I_Position(ByVal OrganizationID As Integer,
                            ByVal Created As DateTime,
                            ByVal CreatedBy As Integer,
                            ByVal LastUpd As DateTime,
                            ByVal LastUpdBy As Integer,
                            ByVal PositionName As String,
                            ByVal ParentPositionID As Object,
                            ByVal DivisionID As Object,
                            ByVal Status As String,
                            ByVal Comments As String,
                            ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("I_position", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpd", LastUpd)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_PositionName", PositionName)
                .Parameters.AddWithValue("I_ParentPositionID", ParentPositionID)
                .Parameters.AddWithValue("I_DivisionID", DivisionID)
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

    Public Function M_I_OrderItemsA(ByVal OrganizationID As Integer,
                             ByVal Created As DateTime,
                             ByVal CreatedBy As Integer,
                             ByVal LastUpdBy As Integer,
                             ByVal AccountID As Integer,
                             ByVal OrderID As Integer,
                             ByVal ProductColorSizeID As Object,
                             ByVal ProductBundleID As Object,
                             ByVal QtyOrdered As Integer,
                             ByVal QtyAvailable As Integer,
                             ByVal ItemType As String,
                             ByVal ItemCode As String,
                             ByVal SKU As String,
                             ByVal UnitOfMeasure As String,
                             ByVal Remarks As String,
                             ByVal SRP As Decimal,
                             ByVal Status As String,
                             ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_I_orderitemsA", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_AccountID", AccountID)
                .Parameters.AddWithValue("I_OrderID", OrderID)
                .Parameters.AddWithValue("I_ProductColorSizeID", ProductColorSizeID)
                .Parameters.AddWithValue("I_ProductBundleID", ProductBundleID)
                .Parameters.AddWithValue("I_QtyOrdered", QtyOrdered)
                .Parameters.AddWithValue("I_QtyAvailable", QtyAvailable)
                .Parameters.AddWithValue("I_ItemType", ItemType)
                .Parameters.AddWithValue("I_ItemCode", ItemCode)
                .Parameters.AddWithValue("I_SKU", SKU)
                .Parameters.AddWithValue("I_UnitOfMeasure", UnitOfMeasure)
                .Parameters.AddWithValue("I_Remarks", Remarks)
                .Parameters.AddWithValue("I_SRP", SRP)
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

    Public Function M_I_OrdersA(ByVal OrganizationID As Integer,
                        ByVal Created As DateTime,
                        ByVal CreatedBy As Integer,
                        ByVal LastUpdBy As Integer,
                        ByVal AccountID As Integer,
                        ByVal OrderNumber As String,
                        ByVal OrderType As String,
                        ByVal OrderDate As Date,
                        ByVal TargetDate As Date,
                        ByVal CustomerName As String,
                        ByVal Comments As String,
                        ByVal Status As String,
                        ByVal TotalAmount As Decimal,
                        ByVal LineUpId As Object,
                        ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_I_ordersA", connection)
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
                .Parameters.AddWithValue("I_OrderNumber", OrderNumber)
                .Parameters.AddWithValue("I_OrderType", OrderType)
                .Parameters.AddWithValue("I_OrderDate", OrderDate)
                .Parameters.AddWithValue("I_TargetDate", TargetDate)
                .Parameters.AddWithValue("I_CustomerName", CustomerName)
                .Parameters.AddWithValue("I_Comments", Comments)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_TotalAmount", TotalAmount)
                .Parameters.AddWithValue("I_LineUpId", If(LineUpId Is Nothing, DBNull.Value, LineUpId))
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

    Public Function M_I_Accounts(ByVal OrganizationID As Integer,
                          ByVal Created As DateTime,
                          ByVal CreatedBy As Integer,
                          ByVal LastUpdBy As Integer,
                          ByVal PrimaryContactID As Object,
                          ByVal PrimaryAddressID As Object,
                          ByVal ParentAccountID As Object,
                          ByVal PickListGroupID As Object,
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
                          ByVal Comments As String,
                          ByVal Status As String,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_I_accounts", connection)
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
                .Parameters.AddWithValue("I_Comments", Comments)
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

    Public Function M_I_Orders(ByVal OrganizationID As Integer,
                     ByVal Created As DateTime,
                     ByVal CreatedBy As Integer,
                     ByVal LastUpdBy As Integer,
                     ByVal AccountID As Object,
                     ByVal OrderNumber As String,
                     ByVal OrderType As String,
                     ByVal OrderDate As Date,
                     ByVal TargetDate As Object,
                     ByVal CustomerName As String,
                     ByVal Comments As String,
                     ByVal Status As String,
                     ByVal TotalAmount As Decimal,
                     ByVal ReceivedBy As String,
                     ByVal RelatedOrderID As Object,
                     ByVal ContactID As Object,
                     ByVal TimeArrived As Object,
                     ByVal ReceivedBrands As String,
                     ByVal ContainerNo As String,
                     ByVal SealNo As String,
                     ByVal ArrivedIn As String,
                     ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_I_Orders", connection)
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
                .Parameters.AddWithValue("I_OrderNumber", OrderNumber)
                .Parameters.AddWithValue("I_OrderType", OrderType)
                .Parameters.AddWithValue("I_OrderDate", OrderDate)
                .Parameters.AddWithValue("I_TargetDate", TargetDate)
                .Parameters.AddWithValue("I_CustomerName", CustomerName)
                .Parameters.AddWithValue("I_Comments", Comments)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_TotalAmount", TotalAmount)
                .Parameters.AddWithValue("I_ReceivedBy", ReceivedBy)
                .Parameters.AddWithValue("I_RelatedOrderID", RelatedOrderID)
                .Parameters.AddWithValue("I_ContactID", ContactID)
                .Parameters.AddWithValue("I_TimeArrived", TimeArrived)
                .Parameters.AddWithValue("I_ReceivedBrands", ReceivedBrands)
                .Parameters.AddWithValue("I_ContainerNo", ContainerNo)
                .Parameters.AddWithValue("I_SealNo", SealNo)
                .Parameters.AddWithValue("I_ArrivedIn", ArrivedIn)
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

    Public Function M_I_OrderItems(ByVal OrganizationID As Integer,
                           ByVal Created As DateTime,
                           ByVal CreatedBy As Integer,
                           ByVal LastUpdBy As Integer,
                           ByVal AccountID As Object,
                           ByVal OrderID As Integer,
                           ByVal ProductColorSizeID As Object,
                           ByVal ProductBundleID As Object,
                           ByVal QtyOrdered As Integer,
                           ByVal QtyAvailable As Integer,
                           ByVal ItemType As String,
                           ByVal ItemCode As String,
                           ByVal SKU As String,
                           ByVal UnitOfMeasure As String,
                           ByVal Remarks As String,
                           ByVal SRP As Decimal,
                           ByVal Status As String,
                           ByVal QtyReceived As Integer,
                           ByVal Approval As Char,
                           ByVal QtyDamaged As Integer,
                           ByVal Reasons As String,
                           ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_I_OrderItems", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_AccountID", AccountID)
                .Parameters.AddWithValue("I_OrderID", OrderID)
                .Parameters.AddWithValue("I_ProductColorSizeID", ProductColorSizeID)
                .Parameters.AddWithValue("I_ProductBundleID", ProductBundleID)
                .Parameters.AddWithValue("I_QtyOrdered", QtyOrdered)
                .Parameters.AddWithValue("I_QtyAvailable", QtyAvailable)
                .Parameters.AddWithValue("I_ItemType", ItemType)
                .Parameters.AddWithValue("I_ItemCode", ItemCode)
                .Parameters.AddWithValue("I_SKU", SKU)
                .Parameters.AddWithValue("I_UnitOfMeasure", UnitOfMeasure)
                .Parameters.AddWithValue("I_Remarks", Remarks)
                .Parameters.AddWithValue("I_SRP", SRP)
                .Parameters.AddWithValue("I_Status", Status)
                .Parameters.AddWithValue("I_QtyReceived", QtyReceived)
                .Parameters.AddWithValue("I_Approval", Approval)
                .Parameters.AddWithValue("I_QtyDamaged", QtyDamaged)
                .Parameters.AddWithValue("I_Reasons", Reasons)
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

    Public Function M_I_productinventorylocation(ByVal OrganizationID As Integer,
                                                 ByVal Created As DateTime,
                                                 ByVal CreatedBy As Integer,
                                                 ByVal LastUpdBy As Integer,
                                                 ByVal RackShelfColumnID As Integer,
                                                 ByVal ProductColorSizeID As Integer,
                                                 ByVal TotalAvailableQty As Integer,
                                                 ByVal TotalReserveQty As Integer,
                                                 ByVal TotalDamageQty As Integer,
                                                 ByVal TotalSupplierProblemQty As Integer,
                                                 ByVal TotalInRepairQty As Integer,
                                                 ByVal TotalToReceiveQty As Integer,
                                                 ByVal RunningTotalQty As Integer,
                                                 ByVal UnitPrice As Decimal,
                                                 ByVal LastInventoryCount As Integer,
                                                 ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_I_productinventorylocation", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_RackShelfColumnID", RackShelfColumnID)
                .Parameters.AddWithValue("I_ProductColorSizeID", ProductColorSizeID)
                .Parameters.AddWithValue("I_TotalAvailableQty", TotalAvailableQty)
                .Parameters.AddWithValue("I_TotalReserveQty", TotalReserveQty)
                .Parameters.AddWithValue("I_TotalDamageQty", TotalDamageQty)
                .Parameters.AddWithValue("I_TotalSupplierProblemQty", TotalSupplierProblemQty)
                .Parameters.AddWithValue("I_TotalInRepairQty", TotalInRepairQty)
                .Parameters.AddWithValue("I_TotalToReceiveQty", TotalToReceiveQty)
                .Parameters.AddWithValue("I_RunningTotalQty", RunningTotalQty)
                .Parameters.AddWithValue("I_UnitPrice", UnitPrice)
                .Parameters.AddWithValue("I_LastInventoryCount", LastInventoryCount)
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

    Public Function M_I_rscorderitems(ByVal OrganizationID As Integer,
                                      ByVal Created As DateTime,
                                      ByVal CreatedBy As Integer,
                                      ByVal LastUpdBy As Integer,
                                      ByVal ProdInventoryLocID As Integer,
                                      ByVal OrderItemsID As Object,
                                      ByVal QtyApplied As Integer,
                                      ByVal Status As String,
                                      ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_I_rscorderitems", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("I_ProdInventoryLocID", ProdInventoryLocID)
                .Parameters.AddWithValue("I_OrderItemsID", OrderItemsID)
                .Parameters.AddWithValue("I_QtyApplied", QtyApplied)
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

    Public Function M_I_productmovementhistory(ByVal OrganizationID As Integer,
                                               ByVal Created As DateTime,
                                               ByVal CreatedBy As Integer,
                                               ByVal OrderID As String,
                                               ByVal ProductColorSizeID As Integer,
                                               ByVal ProductInventoryLocationIDA As Integer,
                                               ByVal ProductInventoryLocationIDB As String,
                                               ByVal CurrentQty As Integer,
                                               ByVal QtyToApply As Integer,
                                               ByVal TransactionType As String,
                                               ByVal ColumnName As String,
                                               ByVal Comments As String,
                                               ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_I_productmovementhistory", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.Clear()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_OrderID", OrderID)
                .Parameters.AddWithValue("I_ProductColorSizeID", ProductColorSizeID)
                .Parameters.AddWithValue("I_ProductInventoryLocationIDA", ProductInventoryLocationIDA)
                .Parameters.AddWithValue("I_ProductInventoryLocationIDB", ProductInventoryLocationIDB)
                .Parameters.AddWithValue("I_CurrentQty", CurrentQty)
                .Parameters.AddWithValue("I_QtyToApply", QtyToApply)
                .Parameters.AddWithValue("I_NewQty", CurrentQty + QtyToApply)
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

    Public Function M_I_productmovementhistoryStockAdjustment(ByVal OrganizationID As Integer,
                                             ByVal Created As DateTime,
                                             ByVal CreatedBy As Integer,
                                             ByVal OrderID As String,
                                             ByVal ProductColorSizeID As Integer,
                                             ByVal ProductInventoryLocationIDA As Integer,
                                             ByVal ProductInventoryLocationIDB As String,
                                             ByVal CurrentQty As Integer,
                                             ByVal QtyToApply As Integer,
                                             ByVal TransactionType As String,
                                             ByVal ColumnName As String,
                                             ByVal Comments As String,
                                             ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_I_productmovementhistory", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.Clear()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_OrderID", OrderID)
                .Parameters.AddWithValue("I_ProductColorSizeID", ProductColorSizeID)
                .Parameters.AddWithValue("I_ProductInventoryLocationIDA", ProductInventoryLocationIDA)
                .Parameters.AddWithValue("I_ProductInventoryLocationIDB", ProductInventoryLocationIDB)
                .Parameters.AddWithValue("I_CurrentQty", CurrentQty)
                .Parameters.AddWithValue("I_QtyToApply", Math.Abs(CurrentQty - QtyToApply))
                .Parameters.AddWithValue("I_NewQty", QtyToApply)
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

    Public Function M_I_productmovementhistoryStockTransfer(ByVal OrganizationID As Integer,
                                             ByVal Created As DateTime,
                                             ByVal CreatedBy As Integer,
                                             ByVal OrderID As String,
                                             ByVal ProductColorSizeID As Integer,
                                             ByVal ProductInventoryLocationIDA As Integer,
                                             ByVal ProductInventoryLocationIDB As String,
                                             ByVal CurrentQty As Integer,
                                             ByVal QtyToApply As Integer,
                                             ByVal TransactionType As String,
                                             ByVal ColumnName As String,
                                             ByVal Comments As String,
                                             ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_I_productmovementhistory", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.Clear()
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("I_OrganizationID", OrganizationID)
                .Parameters.AddWithValue("I_Created", Created)
                .Parameters.AddWithValue("I_CreatedBy", CreatedBy)
                .Parameters.AddWithValue("I_OrderID", OrderID)
                .Parameters.AddWithValue("I_ProductColorSizeID", ProductColorSizeID)
                .Parameters.AddWithValue("I_ProductInventoryLocationIDA", ProductInventoryLocationIDA)
                .Parameters.AddWithValue("I_ProductInventoryLocationIDB", ProductInventoryLocationIDB)
                .Parameters.AddWithValue("I_CurrentQty", CurrentQty)
                .Parameters.AddWithValue("I_QtyToApply", QtyToApply)
                .Parameters.AddWithValue("I_NewQty", CurrentQty - QtyToApply)
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

#Region "Update"

    Public Function U_PositionView(ByVal RowID As Integer,
                                ByVal LastUpd As DateTime,
                                ByVal LastUpdBy As Integer,
                                ByVal Creates As Char,
                                ByVal Updates As Char,
                                ByVal Disable As Char,
                                ByVal Reading As Char,
                                ByVal Remarks As String,
                                ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_positionview", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_Creates", Creates)
                .Parameters.AddWithValue("U_Updates", Updates)
                .Parameters.AddWithValue("U_Disable", Disable)
                .Parameters.AddWithValue("U_ReadOnly", Reading)
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

    Public Function U_Position(ByVal RowID As Integer,
                          ByVal LastUpd As DateTime,
                          ByVal LastUpdBy As Integer,
                          ByVal PositionName As String,
                          ByVal ParentPositionID As Object,
                          ByVal DivisionID As Object,
                          ByVal Status As String,
                          ByVal Comments As String,
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("U_position", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_PositionName", PositionName)
                .Parameters.AddWithValue("U_ParentPositionID", ParentPositionID)
                .Parameters.AddWithValue("U_DivisionID", DivisionID)
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

    Public Function MB_U_OrderItemsA(ByVal RowID As Integer,
                              ByVal LastUpd As DateTime,
                              ByVal LastUpdBy As Integer,
                              ByVal QtyOrdered As Integer,
                              ByVal SRP As Decimal,
                              ByVal UnitOfMeasure As String,
                              ByVal Remarks As String,
                              ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("MB_U_orderitemsA", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_QtyOrdered", QtyOrdered)
                .Parameters.AddWithValue("U_SRP", SRP)
                .Parameters.AddWithValue("U_UnitOfMeasure", UnitOfMeasure)
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

    Public Function M_U_OrderA(ByVal RowID As Integer,
                                 ByVal LastUpd As DateTime,
                                 ByVal LastUpdBy As Integer,
                                 ByVal AccountID As Integer,
                                 ByVal OrderNumber As String,
                                 ByVal OrderDate As Date,
                                 ByVal TargetDate As Date,
                                 ByVal Comments As String,
                                 ByVal TotalAmount As Decimal,
                                 ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_U_orderA", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_AccountID", AccountID)
                .Parameters.AddWithValue("U_OrderNumber", OrderNumber)
                .Parameters.AddWithValue("U_OrderDate", OrderDate)
                .Parameters.AddWithValue("U_TargetDate", TargetDate)
                .Parameters.AddWithValue("U_Comments", Comments)
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

    Public Function M_U_OrderB(ByVal RowID As Integer,
                              ByVal LastUpd As DateTime,
                              ByVal LastUpdBy As Integer,
                              ByVal BranchID As Object,
                              ByVal CompanyID As Object,
                              ByVal CombineCodingID As Object,
                              ByVal ReferenceNumber As String,
                              ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_U_orderB", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.Clear()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_BranchID", BranchID)
                .Parameters.AddWithValue("U_CompanyID", CompanyID)
                .Parameters.AddWithValue("U_CombineCodingID", CombineCodingID)
                .Parameters.AddWithValue("U_ReferenceNumber", ReferenceNumber)
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

    Public Function M_U_Accounts(ByVal RowID As Integer,
                  ByVal LastUpd As DateTime,
                  ByVal LastUpdby As Integer,
                  ByVal PrimaryContactID As Object,
                  ByVal PrimaryAddressID As Object,
                  ByVal ParentAccountID As Object,
                  ByVal PickListGroupID As Object,
                  ByVal CompanyName As String,
                  ByVal MainPhone As String,
                  ByVal AltPhone As String,
                  ByVal FaxNumber As String,
                  ByVal EmailAddress As String,
                  ByVal VATRegistrationNo As String,
                  ByVal Website As String,
                  ByVal Comments As String,
                  ByVal Status As String,
                  ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_U_accounts", connection)
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
                .Parameters.AddWithValue("U_CompanyName", CompanyName)
                .Parameters.AddWithValue("U_MainPhone", MainPhone)
                .Parameters.AddWithValue("U_AltPhone", AltPhone)
                .Parameters.AddWithValue("U_FaxNumber", FaxNumber)
                .Parameters.AddWithValue("U_EmailAddress", EmailAddress)
                .Parameters.AddWithValue("U_VATRegistrationNo", VATRegistrationNo)
                .Parameters.AddWithValue("U_Website", Website)
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

    Public Function M_U_Orders(ByVal RowID As Integer,
                             ByVal LastUpd As DateTime,
                             ByVal LastUpdBy As Integer,
                             ByVal AccountID As Object,
                             ByVal OrderNumber As String,
                             ByVal OrderDate As Date,
                             ByVal TargetDate As Object,
                             ByVal Comments As String,
                             ByVal TotalAmount As Decimal,
                             ByVal ReceivedBy As String,
                             ByVal ContactID As Object,
                             ByVal TimeArrived As Object,
                             ByVal ReceivedBrands As String,
                             ByVal ContainerNo As String,
                             ByVal SealNo As String,
                             ByVal ArrivedIn As String,
                             ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_U_Orders", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_AccountID", AccountID)
                .Parameters.AddWithValue("U_OrderNumber", OrderNumber)
                .Parameters.AddWithValue("U_OrderDate", OrderDate)
                .Parameters.AddWithValue("U_TargetDate", TargetDate)
                .Parameters.AddWithValue("U_Comments", Comments)
                .Parameters.AddWithValue("U_TotalAmount", TotalAmount)
                .Parameters.AddWithValue("U_ReceivedBy", ReceivedBy)
                .Parameters.AddWithValue("U_ContactID", ContactID)
                .Parameters.AddWithValue("U_TimeArrived", TimeArrived)
                .Parameters.AddWithValue("U_ReceivedBrands", ReceivedBrands)
                .Parameters.AddWithValue("U_ContainerNo", ContainerNo)
                .Parameters.AddWithValue("U_SealNo", SealNo)
                .Parameters.AddWithValue("U_ArrivedIn", ArrivedIn)
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

    Public Function M_U_OrderItems(ByVal RowID As Integer,
                             ByVal LastUpd As DateTime,
                             ByVal LastUpdBy As Integer,
                             ByVal QtyReceived As Integer,
                             ByVal QtyDamaged As Integer,
                             ByVal Remarks As String,
                             ByVal Reasons As String,
                             ByVal Approval As Char,
                             ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_U_OrderItems", connection)
        With SQL_command
            Try
                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_QtyReceived", QtyReceived)
                .Parameters.AddWithValue("U_QtyDamaged", QtyDamaged)
                .Parameters.AddWithValue("U_Remarks", Remarks)
                .Parameters.AddWithValue("U_Reasons", Reasons)
                .Parameters.AddWithValue("U_Approval", Approval)
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

    Public Function M_U_OrderItemsA(ByVal RowID As Integer,
                              ByVal LastUpd As DateTime,
                              ByVal LastUpdBy As Integer,
                              ByVal QtyOrdered As Integer,
                              ByVal QtyDamaged As Integer,
                              ByVal SRP As Decimal,
                              ByVal UnitOfMeasure As String,
                              ByVal Remarks As String,
                              ByVal Reasons As String,
                              ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_U_OrderitemsA", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_QtyOrdered", QtyOrdered)
                .Parameters.AddWithValue("U_QtyDamaged", QtyDamaged)
                .Parameters.AddWithValue("U_SRP", SRP)
                .Parameters.AddWithValue("U_UnitOfMeasure", UnitOfMeasure)
                .Parameters.AddWithValue("U_Remarks", Remarks)
                .Parameters.AddWithValue("U_Reasons", Reasons)
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

    Public Function M_U_rscorderitems(ByVal RowID As Integer,
                            ByVal LastUpd As DateTime,
                            ByVal LastUpdBy As Integer,
                            ByVal QtyApplied As Integer,
                            ByVal Status As String,
                            ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand =
                  New MySqlCommand("M_U_rscorderitems", connection)
        With SQL_command
            Try

                .Connection.Open()
                .Parameters.AddWithValue("U_RowID", RowID)
                .Parameters.AddWithValue("U_LastUpd", LastUpd)
                .Parameters.AddWithValue("U_LastUpdBy", LastUpdBy)
                .Parameters.AddWithValue("U_QtyApplied", QtyApplied)
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

#End Region

#Region "User rights"

    Public Sub UserRights(ByVal positionid As Integer, ByVal viewname As String,
                          ByRef creates As Char, ByRef updates As Char, ByRef disable As Char,
                          ByRef reads As Char, ByVal formname As Object)

        Try
            Dim ViewID As String = getStringItem("Select RowID from views where ViewName=""" & viewname & """ AND OrganizationID=" & Z_OrganizationID)
            If ViewID = "" Then
                MessageBox.Show("No views found on the record.", "User Rights", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Try
            End If
            If positionid = 0 Then
                MessageBox.Show("No position found on the record.", "User Rights", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Try
            End If
            Dim dtPosV As New DataTable
            dtPosV = getDataTableForSQL("Select Coalesce(Creates,'Y'),Coalesce(ReadOnly,'Y'),Coalesce(Updates,'Y'),Coalesce(Disable,'Y') from positionviews where viewid=" & Val(ViewID) & " and positionid=" & positionid & " And Organizationid=" & Z_OrganizationID)

            creates = dtPosV.Rows(0)(0)
            updates = dtPosV.Rows(0)(2)
            disable = dtPosV.Rows(0)(3)
            reads = dtPosV.Rows(0)(1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, formname.Name))
        Finally
            connection.Close()
        End Try
    End Sub

#End Region

End Module