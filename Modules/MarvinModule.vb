Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.OleDb
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
            dtGid = getDataTableForSQL("SELECT COALESCE(rr.ordernumber,''),DATE_FORMAT(rr.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,''),' / ',COALESCE(c.`type`,'')),'')," & _
                            "COALESCE(TIME_FORMAT(rr.timearrived,'%r'),''),COALESCE(rr.arrivedin,''),COALESCE(rr.containerno,''),COALESCE(rr.sealno,''),COALESCE(rr.receivedbrands,'') FROM orders rr LEFT JOIN contacts c ON rr.contactid = c.rowid " & _
                            "WHERE rr.ordertype = 'RR' AND rr.relatedorderid = " & globalirelatedorderid & " AND rr.organizationid = " & Z_OrganizationID & " AND rr.`status` != 'Cancelled' ")
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
    Sub getProductColorSizeTotalDamageQty(ByVal globaliproductcolorsizeid As Integer, ByVal globalformname As Object)
        Try
            globaltotalqtydamage = 0
            Dim dtGtdq As New DataTable
            dtGtdq = getDataTableForSQL("SELECT COALESCE(pcs.totaldamageqty,'') FROM productcolorsizes pcs WHERE pcs.rowid = " & globaliproductcolorsizeid & " ")
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
    Public Function I_PositionView(ByVal OrganizationID As Integer, _
                                  ByVal Created As DateTime, _
                                  ByVal CreatedBy As Integer, _
                                  ByVal LastUpd As DateTime, _
                                  ByVal LastUpdBy As Integer, _
                                  ByVal PositionID As Integer, _
                                  ByVal ViewID As Integer, _
                                  ByVal Creates As Char, _
                                  ByVal Updates As Char, _
                                  ByVal Disable As Char, _
                                  ByVal Reading As Char, _
                                  ByVal Remarks As String, _
                                  ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function I_Position(ByVal OrganizationID As Integer, _
                            ByVal Created As DateTime, _
                            ByVal CreatedBy As Integer, _
                            ByVal LastUpd As DateTime, _
                            ByVal LastUpdBy As Integer, _
                            ByVal PositionName As String, _
                            ByVal ParentPositionID As Object, _
                            ByVal DivisionID As Object, _
                            ByVal Status As String, _
                            ByVal Comments As String, _
                            ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_I_OrderItemsA(ByVal OrganizationID As Integer, _
                             ByVal Created As DateTime, _
                             ByVal CreatedBy As Integer, _
                             ByVal LastUpdBy As Integer, _
                             ByVal AccountID As Integer, _
                             ByVal OrderID As Integer, _
                             ByVal ProductColorSizeID As Object, _
                             ByVal ProductBundleID As Object, _
                             ByVal QtyOrdered As Integer, _
                             ByVal QtyAvailable As Integer, _
                             ByVal ItemType As String, _
                             ByVal ItemCode As String, _
                             ByVal SKU As String, _
                             ByVal UnitOfMeasure As String, _
                             ByVal Remarks As String, _
                             ByVal SRP As Decimal, _
                             ByVal Status As String, _
                             ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_I_OrdersA(ByVal OrganizationID As Integer, _
                        ByVal Created As DateTime, _
                        ByVal CreatedBy As Integer, _
                        ByVal LastUpdBy As Integer, _
                        ByVal AccountID As Integer, _
                        ByVal OrderNumber As String, _
                        ByVal OrderType As String, _
                        ByVal OrderDate As Date, _
                        ByVal TargetDate As Date, _
                        ByVal CustomerName As String, _
                        ByVal Comments As String, _
                        ByVal Status As String, _
                        ByVal TotalAmount As Decimal, _
                        ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_I_Accounts(ByVal OrganizationID As Integer, _
                          ByVal Created As DateTime, _
                          ByVal CreatedBy As Integer, _
                          ByVal LastUpdBy As Integer, _
                          ByVal PrimaryContactID As Object, _
                          ByVal PrimaryAddressID As Object, _
                          ByVal ParentAccountID As Object, _
                          ByVal PickListGroupID As Object, _
                          ByVal AccountNo As Integer, _
                          ByVal AccountType As String, _
                          ByVal CompanyName As String, _
                          ByVal TradeName As String, _
                          ByVal MainPhone As String, _
                          ByVal AltPhone As String, _
                          ByVal FaxNumber As String, _
                          ByVal EmailAddress As String, _
                          ByVal VATRegistrationNo As String, _
                          ByVal Website As String, _
                          ByVal Comments As String, _
                          ByVal Status As String, _
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_I_Orders(ByVal OrganizationID As Integer, _
                     ByVal Created As DateTime, _
                     ByVal CreatedBy As Integer, _
                     ByVal LastUpdBy As Integer, _
                     ByVal AccountID As Object, _
                     ByVal OrderNumber As String, _
                     ByVal OrderType As String, _
                     ByVal OrderDate As Date, _
                     ByVal TargetDate As Object, _
                     ByVal CustomerName As String, _
                     ByVal Comments As String, _
                     ByVal Status As String, _
                     ByVal TotalAmount As Decimal, _
                     ByVal ReceivedBy As String, _
                     ByVal RelatedOrderID As Object, _
                     ByVal ContactID As Object, _
                     ByVal TimeArrived As Object, _
                     ByVal ReceivedBrands As String, _
                     ByVal ContainerNo As String, _
                     ByVal SealNo As String, _
                     ByVal ArrivedIn As String, _
                     ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_I_OrderItems(ByVal OrganizationID As Integer, _
                           ByVal Created As DateTime, _
                           ByVal CreatedBy As Integer, _
                           ByVal LastUpdBy As Integer, _
                           ByVal AccountID As Object, _
                           ByVal OrderID As Integer, _
                           ByVal ProductColorSizeID As Object, _
                           ByVal ProductBundleID As Object, _
                           ByVal QtyOrdered As Integer, _
                           ByVal QtyAvailable As Integer, _
                           ByVal ItemType As String, _
                           ByVal ItemCode As String, _
                           ByVal SKU As String, _
                           ByVal UnitOfMeasure As String, _
                           ByVal Remarks As String, _
                           ByVal SRP As Decimal, _
                           ByVal Status As String, _
                           ByVal QtyReceived As Integer, _
                           ByVal Approval As Char, _
                           ByVal QtyDamaged As Integer, _
                           ByVal Reasons As String, _
                           ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_I_productinventorylocation(ByVal OrganizationID As Integer, _
                                                 ByVal Created As DateTime, _
                                                 ByVal CreatedBy As Integer, _
                                                 ByVal LastUpdBy As Integer, _
                                                 ByVal RackShelfColumnID As Integer, _
                                                 ByVal ProductColorSizeID As Integer, _
                                                 ByVal TotalAvailableQty As Integer, _
                                                 ByVal TotalReserveQty As Integer, _
                                                 ByVal TotalDamageQty As Integer, _
                                                 ByVal TotalSupplierProblemQty As Integer, _
                                                 ByVal TotalInRepairQty As Integer, _
                                                 ByVal TotalToReceiveQty As Integer, _
                                                 ByVal RunningTotalQty As Integer, _
                                                 ByVal UnitPrice As Decimal, _
                                                 ByVal LastInventoryCount As Integer, _
                                                 ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_I_rscorderitems(ByVal OrganizationID As Integer, _
                                      ByVal Created As DateTime, _
                                      ByVal CreatedBy As Integer, _
                                      ByVal LastUpdBy As Integer, _
                                      ByVal ProdInventoryLocID As Integer, _
                                      ByVal OrderItemsID As Object, _
                                      ByVal QtyApplied As Integer, _
                                      ByVal Status As String, _
                                      ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
        Dim SQL_command As MySqlCommand = _
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
        Dim SQL_command As MySqlCommand = _
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
        Dim SQL_command As MySqlCommand = _
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
    Public Function U_PositionView(ByVal RowID As Integer, _
                                ByVal LastUpd As DateTime, _
                                ByVal LastUpdBy As Integer, _
                                ByVal Creates As Char, _
                                ByVal Updates As Char, _
                                ByVal Disable As Char, _
                                ByVal Reading As Char, _
                                ByVal Remarks As String, _
                                ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function U_Position(ByVal RowID As Integer, _
                          ByVal LastUpd As DateTime, _
                          ByVal LastUpdBy As Integer, _
                          ByVal PositionName As String, _
                          ByVal ParentPositionID As Object, _
                          ByVal DivisionID As Object, _
                          ByVal Status As String, _
                          ByVal Comments As String, _
                          ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function MB_U_OrderItemsA(ByVal RowID As Integer, _
                              ByVal LastUpd As DateTime, _
                              ByVal LastUpdBy As Integer, _
                              ByVal QtyOrdered As Integer, _
                              ByVal SRP As Decimal, _
                              ByVal UnitOfMeasure As String, _
                              ByVal Remarks As String, _
                              ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_U_OrderA(ByVal RowID As Integer, _
                                 ByVal LastUpd As DateTime, _
                                 ByVal LastUpdBy As Integer, _
                                 ByVal AccountID As Integer, _
                                 ByVal OrderNumber As String, _
                                 ByVal OrderDate As Date, _
                                 ByVal TargetDate As Date, _
                                 ByVal Comments As String, _
                                 ByVal TotalAmount As Decimal, _
                                 ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_U_OrderB(ByVal RowID As Integer, _
                              ByVal LastUpd As DateTime, _
                              ByVal LastUpdBy As Integer, _
                              ByVal BranchID As Object, _
                              ByVal CompanyID As Object, _
                              ByVal CombineCodingID As Object, _
                              ByVal ReferenceNumber As String, _
                              ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_U_Accounts(ByVal RowID As Integer, _
                  ByVal LastUpd As DateTime, _
                  ByVal LastUpdby As Integer, _
                  ByVal PrimaryContactID As Object, _
                  ByVal PrimaryAddressID As Object, _
                  ByVal ParentAccountID As Object, _
                  ByVal PickListGroupID As Object, _
                  ByVal CompanyName As String, _
                  ByVal MainPhone As String, _
                  ByVal AltPhone As String, _
                  ByVal FaxNumber As String, _
                  ByVal EmailAddress As String, _
                  ByVal VATRegistrationNo As String, _
                  ByVal Website As String, _
                  ByVal Comments As String, _
                  ByVal Status As String, _
                  ByVal globalformname As Object) As Boolean


        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_U_Orders(ByVal RowID As Integer, _
                             ByVal LastUpd As DateTime, _
                             ByVal LastUpdBy As Integer, _
                             ByVal AccountID As Object, _
                             ByVal OrderNumber As String, _
                             ByVal OrderDate As Date, _
                             ByVal TargetDate As Object, _
                             ByVal Comments As String, _
                             ByVal TotalAmount As Decimal, _
                             ByVal ReceivedBy As String, _
                             ByVal ContactID As Object, _
                             ByVal TimeArrived As Object, _
                             ByVal ReceivedBrands As String, _
                             ByVal ContainerNo As String, _
                             ByVal SealNo As String, _
                             ByVal ArrivedIn As String, _
                             ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_U_OrderItems(ByVal RowID As Integer, _
                             ByVal LastUpd As DateTime, _
                             ByVal LastUpdBy As Integer, _
                             ByVal QtyReceived As Integer, _
                             ByVal QtyDamaged As Integer, _
                             ByVal Remarks As String, _
                             ByVal Reasons As String, _
                             ByVal Approval As Char, _
                             ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_U_OrderItemsA(ByVal RowID As Integer, _
                              ByVal LastUpd As DateTime, _
                              ByVal LastUpdBy As Integer, _
                              ByVal QtyOrdered As Integer, _
                              ByVal QtyDamaged As Integer, _
                              ByVal SRP As Decimal, _
                              ByVal UnitOfMeasure As String, _
                              ByVal Remarks As String, _
                              ByVal Reasons As String, _
                              ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
    Public Function M_U_rscorderitems(ByVal RowID As Integer, _
                            ByVal LastUpd As DateTime, _
                            ByVal LastUpdBy As Integer, _
                            ByVal QtyApplied As Integer, _
                            ByVal Status As String, _
                            ByVal globalformname As Object) As Boolean

        Dim F_return As Boolean = False
        Dim SQL_command As MySqlCommand = _
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
