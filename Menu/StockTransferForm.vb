Imports MySql.Data.MySqlClient
Imports WarehouseManagementSystem.Core.Enums

Public Class StockTransferForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim itemno, rowscount As Integer
    Dim cue, searchmode, simplesearchphrase As String
    Dim spagenum, countpagenum, numofpages, validpages As Integer
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal
    Dim getilid, getpilocid, getrscid, getnewpilocid, storderid, sttotalqtytotransfer As Integer

    Private Sub StocktTransferForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            displayStockTransferList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
            getInventoryLocID()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub StocktTransferForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            myBalloon(, , lblsavemsg, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#Region "Function"

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            cue = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearStockTransInformation()
            clearAddProductA()
            clearDatagrids()
            visibleRackShelfColumnFrom(fraud)
            visibleDatagrids(fraud, legit)
            enableGB(legit, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud)
            lblStockTransferItems.Text = "Stock Transfer Items:"
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRightPage()
        Try
            cue = ""
            clearStockTransInformation()
            clearAddProductA()
            clearDatagrids()
            visibleRackShelfColumnFrom(fraud)
            visibleDatagrids(fraud, legit)
            enableGB(legit, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud)
            lblStockTransferItems.Text = "Stock Transfer Items:"
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearSearchItems()
        Try
            txtSimpleSearch.Text = ""
            txtPageNo.Text = ""
            txtPage.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearStockTransInformation()
        Try
            txtStockTransferNo.Text = ""
            txtStatus.Text = ""
            txtComments.Text = ""
            txtTransferedBy.Text = ""
            dtpStockTransferDate.Value = Now.Date
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearAddProductA()
        Try
            cboFrom.Text = ""
            cboFrom.SelectedItem = Nothing
            cboTo.Text = ""
            cboTo.SelectedItem = Nothing
            txtTotalQtyToTransfer.Text = ""
            chkOtherInfo.Checked = fraud
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearDatagrids()
        Try
            dgRackShelfColumnFrom.Rows.Clear()
            dgRackShelfColumnTo.Rows.Clear()
            dgProductHistory.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub visibleRackShelfColumnFrom(ByVal visible1 As Boolean)
        Try
            r_unitofmeasure.Visible = visible1
            r_qtyavailable.Visible = visible1
            r_qtyallocated.Visible = visible1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub visibleDatagrids(ByVal visible1 As Boolean, ByVal visible2 As Boolean)
        Try
            dgProductHistory.Visible = visible1
            dgRackShelfColumnFrom.Visible = visible2
            dgRackShelfColumnTo.Visible = visible2
            chkOtherInfo.Visible = visible2
            lblTotalQtyToTransfer.Visible = visible2
            txtTotalQtyToTransfer.Visible = visible2
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbStockTransferList.Enabled = enable1
            gbStockTransferItems.Enabled = enable2
            gbStockTransferInformation.Enabled = enable2
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableANDvisibleMS(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal visible1 As Boolean)
        Try
            msNew.Enabled = enable1
            msSave.Enabled = enable2
            msCancel.Visible = visible1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Computation"

    Sub stocktransfercomputation()
        Try
            sttotalqtytotransfer = 0
            If dgRackShelfColumnTo.Rows.Count <> 0 Then
                For i = 0 To dgRackShelfColumnTo.Rows.Count - 1
                    If IsNumeric(dgRackShelfColumnTo.Rows(i).Cells("rsc_qtytransfer").Value) Then
                        sttotalqtytotransfer = sttotalqtytotransfer + CInt(dgRackShelfColumnTo.Rows(i).Cells("rsc_qtytransfer").Value)
                    End If
                Next
            End If
            txtTotalQtyToTransfer.Text = Format(sttotalqtytotransfer, "#,##0")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Click"

    Sub tsrefreshperformclick()
        Try
            errProvider.Clear()
            clearfields()
            displayStockTransferList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Page Setup"

    Sub pageSetup()
        Try
            getCountPageNum()
            If countpagenum < pagedivisor Then
                validpages = startingpage
            Else
                additionalpage = countpagenum / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpages = countpagenum / pagedivisor
                Else
                    validpages = countpagenum / pagedivisor
                    validpages = validpages + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNum()
        Try
            countpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COUNT(po.rowid) FROM orders po WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.ST.ToString()}' ")
            If dtCid.Rows.Count <> 0 Then
                countpagenum = dtCid.Rows(0)(0)
            Else
                countpagenum = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub pageSetup1(ByVal isearchstring As String)
        Try
            getCountPageNum1(isearchstring)
            If countpagenum < pagedivisor Then
                validpages = startingpage
            Else
                additionalpage = countpagenum / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpages = countpagenum / pagedivisor
                Else
                    validpages = countpagenum / pagedivisor
                    validpages = validpages + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNum1(ByVal esearchstring As String)
        Try
            countpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(po.rowid),0) FROM orders po WHERE po.organizationid = " & Z_OrganizationID & $" AND po.ordertype = '{OrderType.ST.ToString()}' " &
                            " AND (po.ordernumber LIKE ""%" & esearchstring & "%"" OR po.status LIKE ""%" & esearchstring & "%"") ")
            If dtCid.Rows.Count <> 0 Then
                countpagenum = dtCid.Rows(0)(0)
            Else
                countpagenum = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Display"

#Region "AutoComplete"

    Sub autocompleteStockFrom(ByVal icombobox As ComboBox)
        Try
            Dim stockfrom As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(p.productcode,''),' / ',COALESCE(c.colorname,''),' / ',COALESCE(pcs.size,''),' / ',COALESCE(pcs.seasoncode,''),' - ',COALESCE(rsc.rackno,''),' / ',COALESCE(rsc.columnno,''),' / ',COALESCE(rsc.shelfno,'')),'') AS 'StockFrom' FROM productinventorylocation pil " &
                            "LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " &
                            "WHERE pil.organizationid = " & Z_OrganizationID & " AND rsc.inventorylocationid = " & getilid & " AND pil.totalavailableqty - pil.totalallocatedqty > 0 GROUP BY pil.rowid ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                stockfrom.Add(ds.Tables(0).Rows(i)("StockFrom").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = stockfrom
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteRackColumnShelf(ByVal icombobox As ComboBox)
        Try
            Dim rackcolumnshelf As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(rsc.rackno,''),' / ',COALESCE(rsc.columnno,''),' / ',COALESCE(rsc.shelfno,'')),'') AS 'RackColumnShelf' FROM rackshelfcolumn rsc " &
                            "WHERE rsc.organizationid = " & Z_OrganizationID & " AND rsc.`status` = 'Active' AND rsc.inventorylocationid = " & getilid & " GROUP BY rsc.rowid ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                rackcolumnshelf.Add(ds.Tables(0).Rows(i)("RackColumnShelf").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = rackcolumnshelf
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "AutoPopulate"

    Sub autopopulateStockFrom(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(p.productcode,''),' / ',COALESCE(c.colorname,''),' / ',COALESCE(pcs.size,''),' / ',COALESCE(pcs.seasoncode,''),' - ',COALESCE(rsc.rackno,''),' / ',COALESCE(rsc.columnno,''),' / ',COALESCE(rsc.shelfno,'')),'') AS 'StockFrom' FROM productinventorylocation pil " &
                            "LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " &
                            "WHERE pil.organizationid = " & Z_OrganizationID & " AND rsc.inventorylocationid = " & getilid & " AND pil.totalavailableqty - pil.totalallocatedqty > 0 GROUP BY pil.rowid ORDER BY p.productcode,c.colorname,pcs.size "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                icombobox.Items.Add(reader1(0).ToString())
            End While
            icombobox.Items.Add("")
            reader1.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autopopulateRackColumnShelf(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(rsc.rackno,''),' / ',COALESCE(rsc.columnno,''),' / ',COALESCE(rsc.shelfno,'')),'') AS 'RackColumnShelf' FROM rackshelfcolumn rsc " &
                            "WHERE rsc.organizationid = " & Z_OrganizationID & " AND rsc.`status` = 'Active' AND rsc.inventorylocationid = " & getilid & " GROUP BY rsc.rowid ORDER BY rsc.rackno,rsc.columnno,rsc.shelfno "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                icombobox.Items.Add(reader1(0).ToString())
            End While
            icombobox.Items.Add("")
            reader1.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Datagrids"

    Sub displayStockTransferList(ByVal istartpage As Integer)
        Try
            dgStockTransferList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT s.rowid,COALESCE(s.ordernumber,''),DATE_FORMAT(s.orderdate,'%d-%b-%Y'),COALESCE(s.status,'') FROM orders s " &
                        "WHERE s.organizationid = " & Z_OrganizationID & $" AND s.ordertype = '{OrderType.ST.ToString()}' ORDER BY s.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgStockTransferList.Rows.Add()
                    dgStockTransferList.Item(s_rowid.Index, n).Value = reader1(0)
                    dgStockTransferList.Item(s_StockNo.Index, n).Value = reader1(1)
                    dgStockTransferList.Item(s_stocktransdate.Index, n).Value = reader1(2)
                    dgStockTransferList.Item(s_status.Index, n).Value = reader1(3)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgStockTransferList.Columns("s_StockNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockTransferList.Columns("s_stocktransdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockTransferList.Columns("s_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgStockTransferList.Rows.Count <> 0 Then
                dgStockTransferList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgStockTransferList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT s.rowid,COALESCE(s.ordernumber,''),DATE_FORMAT(s.orderdate,'%d-%b-%Y'),COALESCE(s.status,'') FROM orders s " &
                        "WHERE s.organizationid = " & Z_OrganizationID & $" AND s.ordertype = '{OrderType.ST.ToString()}' AND (s.ordernumber LIKE ""%" & isearchphrase & "%"" OR s.status LIKE ""%" & isearchphrase & "%"") " &
                        "ORDER BY s.orderdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgStockTransferList.Rows.Add()
                    dgStockTransferList.Item(s_rowid.Index, n).Value = reader1(0)
                    dgStockTransferList.Item(s_StockNo.Index, n).Value = reader1(1)
                    dgStockTransferList.Item(s_stocktransdate.Index, n).Value = reader1(2)
                    dgStockTransferList.Item(s_status.Index, n).Value = reader1(3)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgStockTransferList.Columns("s_StockNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockTransferList.Columns("s_stocktransdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgStockTransferList.Columns("s_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgStockTransferList.Rows.Count <> 0 Then
                dgStockTransferList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayStockFrom(ByVal iproductinventorylocid As Integer)
        Try
            dgRackShelfColumnFrom.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pil.rowid,COALESCE(pil.productcolorsizeid,0),COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(p.unitofmeasure),COALESCE(pcs.sku,'')," &
                            "COALESCE(rsc.rackno,''),COALESCE(rsc.columnno,''),COALESCE(rsc.shelfno,''),COALESCE(pil.totalavailableqty,0),COALESCE(pil.totalallocatedqty,0) FROM productinventorylocation pil LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " &
                            "LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pil.rowid = " & iproductinventorylocid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgRackShelfColumnFrom.Rows.Add()
                    dgRackShelfColumnFrom.Item(r_rowid.Index, n).Value = reader1(0)
                    dgRackShelfColumnFrom.Item(r_pcsrowid.Index, n).Value = reader1(1)
                    dgRackShelfColumnFrom.Item(r_colorvalue.Index, n).Value = reader1(2)
                    dgRackShelfColumnFrom.Item(r_productcode.Index, n).Value = reader1(3)
                    dgRackShelfColumnFrom.Item(r_colorname.Index, n).Value = reader1(4)
                    dgRackShelfColumnFrom.Item(r_color.Index, n).Value = ""
                    dgRackShelfColumnFrom.Item(r_size.Index, n).Value = reader1(5)
                    dgRackShelfColumnFrom.Item(r_seasoncode.Index, n).Value = reader1(6)
                    dgRackShelfColumnFrom.Item(r_unitofmeasure.Index, n).Value = reader1(7)
                    dgRackShelfColumnFrom.Item(r_sku.Index, n).Value = reader1(8)
                    dgRackShelfColumnFrom.Item(r_rack.Index, n).Value = reader1(9)
                    dgRackShelfColumnFrom.Item(r_column.Index, n).Value = reader1(10)
                    dgRackShelfColumnFrom.Item(r_shelf.Index, n).Value = reader1(11)
                    dgRackShelfColumnFrom.Item(r_qtyavailable.Index, n).Value = CInt(reader1(12))
                    getTotalQtyOrderedA(CInt(reader1(1)), $"AND oi.`status` = 'New' AND o.`status` = 'Submitted To Warehouse' AND o.ordertype = '{OrderType.CO.ToString()}'", Me)
                    dgRackShelfColumnFrom.Item(r_qtyallocated.Index, n).Value = CInt(reader1(13)) + globaltotalqtyordered
                    dgRackShelfColumnFrom.Item(r_qtystock.Index, n).Value = CInt(reader1(12)) - (CInt(reader1(13)) + globaltotalqtyordered)
                    n = n + 1
                End If
            End While
            reader1.Close()
            If dgRackShelfColumnFrom.Rows.Count <> 0 Then
                dgRackShelfColumnFrom.CurrentRow.Selected = False
            End If
            dgRackShelfColumnFrom.Columns("r_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnFrom.Columns("r_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnFrom.Columns("r_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnFrom.Columns("r_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnFrom.Columns("r_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnFrom.Columns("r_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnFrom.Columns("r_rack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnFrom.Columns("r_column").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnFrom.Columns("r_shelf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnFrom.Columns("r_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnFrom.Columns("r_qtyallocated").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnFrom.Columns("r_qtystock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnFrom.Columns("r_remove").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayStockTransferInformation(ByVal istocktransferid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String
            sql1 = "SELECT COALESCE(s.ordernumber),DATE_FORMAT(s.orderdate,'%d-%b-%Y'),COALESCE(s.comments,''),COALESCE(s.`status`,''),COALESCE(s.receivedby,'') FROM orders s WHERE s.rowid = " & istocktransferid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtStockTransferNo.Text = reader1(0)
                    dtpStockTransferDate.Text = reader1(1)
                    txtComments.Text = reader1(2)
                    txtStatus.Text = reader1(3)
                    txtTransferedBy.Text = reader1(4)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayProductHistory(ByVal istocktransferid As Integer)
        Try
            dgProductHistory.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT h.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(p.unitofmeasure),COALESCE(pcs.sku,''),COALESCE(rsc.rackno,'')," &
                        "COALESCE(rsc.columnno,''),COALESCE(rsc.shelfno,''),COALESCE(h.currentqty,0),COALESCE(h.qtytoapply,0),COALESCE(h.newqty,0),COALESCE(h.transactiontype,'') FROM productmovementhistory h LEFT JOIN productcolorsizes pcs ON h.productcolorsizeid = pcs.rowid " &
                        "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN productinventorylocation pil ON h.productinventorylocationida = pil.rowid LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " &
                        "WHERE h.organizationid = " & Z_OrganizationID & " AND h.orderid = " & istocktransferid & " ORDER BY h.transactiontype "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductHistory.Rows.Add()
                    dgProductHistory.Item(h_rowid.Index, n).Value = reader1(0)
                    dgProductHistory.Item(h_colorvalue.Index, n).Value = reader1(1)
                    dgProductHistory.Item(h_productcode.Index, n).Value = reader1(2)
                    dgProductHistory.Item(h_colorname.Index, n).Value = reader1(3)
                    dgProductHistory.Item(h_color.Index, n).Value = ""
                    dgProductHistory.Item(h_size.Index, n).Value = reader1(4)
                    dgProductHistory.Item(h_seasoncode.Index, n).Value = reader1(5)
                    dgProductHistory.Item(h_uom.Index, n).Value = reader1(6)
                    dgProductHistory.Item(h_sku.Index, n).Value = reader1(7)
                    dgProductHistory.Item(h_rack.Index, n).Value = reader1(8)
                    dgProductHistory.Item(h_column.Index, n).Value = reader1(9)
                    dgProductHistory.Item(h_shelf.Index, n).Value = reader1(10)
                    dgProductHistory.Item(h_qtybefore.Index, n).Value = reader1(11)
                    dgProductHistory.Item(h_qtyapplied.Index, n).Value = reader1(12)
                    dgProductHistory.Item(h_qtyafter.Index, n).Value = reader1(13)
                    dgProductHistory.Item(h_type.Index, n).Value = reader1(14)
                    n = n + 1
                End If
            End While
            reader1.Close()
            If dgProductHistory.Rows.Count <> 0 Then
                dgProductHistory.CurrentRow.Selected = False
            End If
            dgProductHistory.Columns("h_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductHistory.Columns("h_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductHistory.Columns("h_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductHistory.Columns("h_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductHistory.Columns("h_uom").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductHistory.Columns("h_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductHistory.Columns("h_rack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductHistory.Columns("h_column").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductHistory.Columns("h_shelf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductHistory.Columns("h_qtybefore").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductHistory.Columns("h_qtyapplied").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductHistory.Columns("h_qtyafter").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductHistory.Columns("h_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Colors"

    Sub colorCoding()
        Try
            If dgRackShelfColumnFrom.Rows.Count <> 0 Then
                For i As Integer = 0 To dgRackShelfColumnFrom.Rows.Count - 1
                    If CStr(dgRackShelfColumnFrom.Rows(i).Cells("r_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgRackShelfColumnFrom.Rows(i).Cells("r_colorvalue").Value))
                        dgRackShelfColumnFrom.Rows(i).Cells("r_color").Style.BackColor = readcolor
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#End Region

#Region "Adding"

    Sub addRackColumnShelf(ByVal irackcolumnshelfid As Integer)
        Try
            If dgRackShelfColumnTo.Rows.Count <> 0 Then
                rowscount = dgRackShelfColumnTo.Rows.Count - 1
                For i = 0 To dgRackShelfColumnTo.Rows.Count - 1
                    If dgRackShelfColumnTo.Rows(i).Cells("rsc_rowid").Value = irackcolumnshelfid Then
                        errProvider.SetError(btnAddRackShelfColumn, "Rack / Column / Shelf is in the list already.")
                        Exit Try
                    ElseIf rowscount = 0 Then
                        addRackColumnShelfItem(irackcolumnshelfid)
                        For a = 0 To dgRackShelfColumnTo.Rows.Count - 1
                            dgRackShelfColumnTo.CurrentRow.Selected = fraud
                            If dgRackShelfColumnTo.Rows(a).Cells("rsc_rowid").Value = irackcolumnshelfid Then
                                dgRackShelfColumnTo.Rows(dgRackShelfColumnTo.Rows.Count - 1).Selected = legit
                                dgRackShelfColumnTo.FirstDisplayedScrollingRowIndex = dgRackShelfColumnTo.RowCount - 1
                                Exit For
                            End If
                        Next
                        cboTo.Text = "" : cboTo.SelectedItem = Nothing
                    End If
                    rowscount = rowscount - 1
                Next
            Else
                addRackColumnShelfItem(irackcolumnshelfid)
                For a = 0 To dgRackShelfColumnTo.Rows.Count - 1
                    dgRackShelfColumnTo.CurrentRow.Selected = fraud
                    If dgRackShelfColumnTo.Rows(a).Cells("rsc_rowid").Value = irackcolumnshelfid Then
                        dgRackShelfColumnTo.Rows(dgRackShelfColumnTo.Rows.Count - 1).Selected = legit
                        dgRackShelfColumnTo.FirstDisplayedScrollingRowIndex = dgRackShelfColumnTo.RowCount - 1
                        Exit For
                    End If
                Next
                cboTo.Text = "" : cboTo.SelectedItem = Nothing
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub addRackColumnShelfItem(ByVal erackcolumnshelfid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT rsc.rowid,COALESCE(rsc.rackno,''),COALESCE(rsc.columnno,''),COALESCE(rsc.shelfno,'') FROM rackshelfcolumn rsc WHERE rsc.rowid = " & erackcolumnshelfid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    dgRackShelfColumnTo.Rows.Add()
                    dgRackShelfColumnTo.Rows(dgRackShelfColumnTo.Rows.Count - 1).Cells("rsc_rowid").Value = reader1(0)
                    dgRackShelfColumnTo.Rows(dgRackShelfColumnTo.Rows.Count - 1).Cells("rsc_rack").Value = reader1(1)
                    dgRackShelfColumnTo.Rows(dgRackShelfColumnTo.Rows.Count - 1).Cells("rsc_column").Value = reader1(2)
                    dgRackShelfColumnTo.Rows(dgRackShelfColumnTo.Rows.Count - 1).Cells("rsc_shelf").Value = reader1(3)
                    dgRackShelfColumnTo.Rows(dgRackShelfColumnTo.Rows.Count - 1).Cells("rsc_qtytransfer").Value = 0
                End If
            End While
            reader1.Close()
            dgRackShelfColumnTo.Columns("rsc_rack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnTo.Columns("rsc_column").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnTo.Columns("rsc_shelf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnTo.Columns("rsc_qtytransfer").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumnTo.Columns("rsc_remove").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Get IDs"

    Sub getInventoryLocID()
        Try
            getilid = 0
            Dim ID As String = getStringItem("SELECT rowid FROM inventorylocations WHERE `type` = 'Main' AND organizationid = " & Z_OrganizationID & " ")
            getilid = Val(ID)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getProdInventoryLocID(ByVal istockfrom As String)
        Try
            getpilocid = 0
            Dim ID As String = getStringItem("SELECT pil.rowid FROM productinventorylocation pil LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " &
                    "WHERE COALESCE(CONCAT(COALESCE(p.productcode,''),' / ',COALESCE(c.colorname,''),' / ',COALESCE(pcs.size,''),' / ',COALESCE(pcs.seasoncode,''),' - ',COALESCE(rsc.rackno,''),' / ',COALESCE(rsc.columnno,''),' / ',COALESCE(rsc.shelfno,'')),'') = """ & istockfrom & """ AND pil.organizationid = " & Z_OrganizationID & " AND rsc.inventorylocationid = " & getilid & " AND pil.totalavailableqty - pil.totalallocatedqty > 0 ")
            getpilocid = Val(ID)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getRackColumnShelfID(ByVal irackcolumnshelf As String)
        Try
            getrscid = 0
            Dim ID As String = getStringItem("SELECT rsc.rowid FROM rackshelfcolumn rsc WHERE COALESCE(CONCAT(COALESCE(rsc.rackno,''),' / ',COALESCE(rsc.columnno,''),' / ',COALESCE(rsc.shelfno,'')),'') = """ & irackcolumnshelf & """ AND rsc.inventorylocationid = " & getilid & " AND rsc.organizationID = " & Z_OrganizationID & " AND rsc.`status` = 'Active' ")
            getrscid = Val(ID)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getProdInvLocID(ByVal irackcolumnshelfid As Integer, ByVal iproductcolorsizeid As Integer)
        Try
            getpilocid = 0
            Dim ID As String = getStringItem("SELECT pil.rowid FROM productinventorylocation pil WHERE pil.rackshelfcolumnid = " & irackcolumnshelfid & " AND pil.productcolorsizeid = " & iproductcolorsizeid & " AND pil.organizationid = " & Z_OrganizationID & " ")
            getpilocid = Val(ID)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#End Region

    Private Sub tabMain_DrawItem(sender As Object, e As DrawItemEventArgs) Handles tabMain.DrawItem
        Try
            TabControlColor(tabMain, e)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If MessageBox.Show("Are you sure you wanted to close this form?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                PrimaryForm.STransForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsRefresh_Click(sender As Object, e As EventArgs) Handles tsRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            tsrefreshperformclick()
            myBalloon("Successfully Refreshed", "Refresh", lblsavemsg, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkOtherInfo_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtherInfo.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If chkOtherInfo.Checked = legit Then
                visibleRackShelfColumnFrom(legit)
            Else
                visibleRackShelfColumnFrom(fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub msNew_Click(sender As Object, e As EventArgs) Handles msNew.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Stock Transfer", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.STransForm = False
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            cue = "New"
            errProvider.Clear()
            clearStockTransInformation()
            clearAddProductA()
            clearDatagrids()
            visibleRackShelfColumnFrom(fraud)
            visibleDatagrids(fraud, legit)
            enableGB(fraud, legit, legit)
            enableANDvisibleMS(fraud, legit, legit)
            If dgStockTransferList.Rows.Count <> 0 Then
                dgStockTransferList.CurrentRow.Selected = fraud
            End If
            cboFrom.Enabled = legit : btnAddStockFrom.Enabled = legit
            cboTo.Enabled = legit : btnAddRackShelfColumn.Enabled = legit
            getOrderNo(globaliordertype:=OrderType.ST.ToString(), Me)
            txtStockTransferNo.Text = CStr(globalorderno)
            txtStatus.Text = "Approved"
            txtTransferedBy.Text = Z_UserName
            autocompleteStockFrom(cboFrom)
            autopopulateStockFrom(cboFrom)
            autocompleteRackColumnShelf(cboTo)
            autopopulateRackColumnShelf(cboTo)
            lblStockTransferItems.Text = "Stock Transfer Items:"
            dtpStockTransferDate.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAddStockFrom_Click(sender As Object, e As EventArgs) Handles btnAddStockFrom.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(cboFrom.Text) = "" Then
                errProvider.SetError(btnAddStockFrom, "Please choose the item to transfer.")
                Exit Try
            Else
                getProdInventoryLocID(cboFrom.Text)
                If getpilocid = 0 Then
                    errProvider.SetError(btnAddStockFrom, "System cannot find the location of the item, please choose among the options given.")
                    Exit Try
                Else
                    displayStockFrom(getpilocid) : colorCoding()
                    cboFrom.Text = "" : cboFrom.SelectedItem = Nothing
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles cboFrom.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                errProvider.Clear()
                If LTrim(cboFrom.Text) = "" Then
                    errProvider.SetError(btnAddStockFrom, "Please choose the item to transfer.")
                    Exit Try
                Else
                    getProdInventoryLocID(cboFrom.Text)
                    If getpilocid = 0 Then
                        errProvider.SetError(btnAddStockFrom, "System cannot find the location of the item, please choose among the options given.")
                        Exit Try
                    Else
                        displayStockFrom(getpilocid) : colorCoding()
                        cboFrom.Text = "" : cboFrom.SelectedItem = Nothing
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAddRackShelfColumn_Click(sender As Object, e As EventArgs) Handles btnAddRackShelfColumn.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(cboTo.Text) = "" Then
                errProvider.SetError(btnAddRackShelfColumn, "Please choose the rack / column / shelf where to tranfer the item.")
                Exit Try
            Else
                getRackColumnShelfID(cboTo.Text)
                If getrscid = 0 Then
                    errProvider.SetError(btnAddStockFrom, "System cannot find the rack / column / shelf, please choose among the options given.")
                    Exit Try
                Else
                    addRackColumnShelf(getrscid)
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboTo_KeyDown(sender As Object, e As KeyEventArgs) Handles cboTo.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                errProvider.Clear()
                If LTrim(cboTo.Text) = "" Then
                    errProvider.SetError(btnAddRackShelfColumn, "Please choose the rack / column / shelf where to tranfer the item.")
                    Exit Try
                Else
                    getRackColumnShelfID(cboTo.Text)
                    If getrscid = 0 Then
                        errProvider.SetError(btnAddStockFrom, "System cannot find the rack / column / shelf, please choose among the options given.")
                        Exit Try
                    Else
                        addRackColumnShelf(getrscid)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgRackShelfColumnFrom_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgRackShelfColumnFrom.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgRackShelfColumnFrom.Rows.Count <> 0 Then
                If e.ColumnIndex = dgRackShelfColumnFrom.Columns("r_remove").Index Then
                    If cue = "New" Then
                        If dgRackShelfColumnFrom.SelectedRows.Count > 0 Then
                            dgRackShelfColumnFrom.Rows.Remove(dgRackShelfColumnFrom.SelectedRows(0))
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgRackShelfColumnTo_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgRackShelfColumnTo.CellEndEdit
        Try
            errProvider.Clear()
            stocktransfercomputation()
            If dgRackShelfColumnFrom.Rows.Count <> 0 Then
                For i = 0 To dgRackShelfColumnFrom.Rows.Count - 1
                    If dgRackShelfColumnFrom.Rows(i).Cells("r_qtystock").Value < sttotalqtytotransfer Then
                        errProvider.SetError(txtTotalQtyToTransfer, "Total Qty. To Transfer should not be greater than the Qty. Allocated.")
                        Exit Try
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgRackShelfColumnTo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgRackShelfColumnTo.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgRackShelfColumnTo.Rows.Count <> 0 Then
                If e.ColumnIndex = dgRackShelfColumnTo.Columns("rsc_remove").Index Then
                    If cue = "New" Then
                        If dgRackShelfColumnTo.SelectedRows.Count > 0 Then
                            dgRackShelfColumnTo.Rows.Remove(dgRackShelfColumnTo.SelectedRows(0))
                            errProvider.Clear()
                            stocktransfercomputation()
                            If dgRackShelfColumnFrom.Rows.Count <> 0 Then
                                For i = 0 To dgRackShelfColumnFrom.Rows.Count - 1
                                    If dgRackShelfColumnFrom.Rows(i).Cells("r_qtystock").Value < sttotalqtytotransfer Then
                                        errProvider.SetError(txtTotalQtyToTransfer, "Total Qty. To Transfer should not be greater than the Qty. Allocated.")
                                        Exit Try
                                    End If
                                Next
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Stock Transfer", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.STransForm = False
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            errProvider.Clear()
            myModule.systemerrorfound = False
            dgRackShelfColumnFrom.CommitEdit(legit) : dgRackShelfColumnFrom.ClearSelection() : dgRackShelfColumnFrom.CurrentCell = Nothing
            dgRackShelfColumnTo.CommitEdit(legit) : dgRackShelfColumnTo.ClearSelection() : dgRackShelfColumnTo.CurrentCell = Nothing
            If cue = "New" Then
                stocktransfercomputation()
                If dgRackShelfColumnFrom.Rows.Count <> 0 Then
                    For i = 0 To dgRackShelfColumnFrom.Rows.Count - 1
                        If dgRackShelfColumnFrom.Rows(i).Cells("r_qtystock").Value < sttotalqtytotransfer Then
                            errProvider.SetError(txtTotalQtyToTransfer, "Total Qty. To Transfer should not be greater than the Qty. Allocated.")
                            Exit Try
                        End If
                    Next
                Else
                    errProvider.SetError(btnAddStockFrom, "Please choose the item to transfer.")
                    Exit Try
                End If
                If dgRackShelfColumnTo.Rows.Count = 0 Then
                    errProvider.SetError(btnAddRackShelfColumn, "Please choose the rack / column / shelf where to tranfer the item.")
                    Exit Try
                End If
                If sttotalqtytotransfer = 0 Then
                    errProvider.SetError(txtTotalQtyToTransfer, "Total Qty. To Transfer should not be equal to zero.")
                    Exit Try
                End If
            ElseIf cue = "Edit" Then
                MessageBox.Show("Updating an existing Stock Transfer is not allowed in the system.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to save the changes on this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If cue = "New" Then
                    stocktransfercomputation()
                    If dgRackShelfColumnFrom.Rows.Count <> 0 Then
                        For i = 0 To dgRackShelfColumnFrom.Rows.Count - 1
                            displayStockFrom(CInt(dgRackShelfColumnFrom.Rows(i).Cells("r_rowid").Value))
                        Next
                        For i = 0 To dgRackShelfColumnFrom.Rows.Count - 1
                            If dgRackShelfColumnFrom.Rows(i).Cells("r_qtystock").Value < sttotalqtytotransfer Then
                                errProvider.SetError(txtTotalQtyToTransfer, "Total Qty. To Transfer should not be greater than the Qty. Allocated.")
                                Exit Try
                            End If
                        Next
                    End If
                    getOrderNo(globaliordertype:=OrderType.ST.ToString(), Me)
                    M_I_Orders(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, DBNull.Value, CStr(globalorderno), OrderType.ST.ToString(),
                            dtpStockTransferDate.Value, DBNull.Value, "", txtComments.Text, txtStatus.Text, 0, txtTransferedBy.Text, DBNull.Value, DBNull.Value, DBNull.Value, "", "", "", "", Nothing, Me)
                    storderid = globalorderidsp
                    If dgRackShelfColumnFrom.Rows.Count <> 0 Then
                        For a = 0 To dgRackShelfColumnFrom.Rows.Count - 1
                            getProductInventoryLocationTotals(CInt(dgRackShelfColumnFrom.Rows(a).Cells("r_rowid").Value), Me)
                            U_ProductInventoryLocationTotals(CInt(dgRackShelfColumnFrom.Rows(a).Cells("r_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globalpiltotalavailableqty - sttotalqtytotransfer, globalpiltotalreserveqty, Me)
                            I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, storderid, DBNull.Value, DBNull.Value, CInt(dgRackShelfColumnFrom.Rows(a).Cells("r_pcsrowid").Value),
                                       CInt(dgRackShelfColumnFrom.Rows(a).Cells("r_rowid").Value), DBNull.Value, globalpiltotalavailableqty, sttotalqtytotransfer, globalpiltotalavailableqty - sttotalqtytotransfer, "ST - From", "TotalAvailableQty", "", Me)
                        Next
                    End If
                    If dgRackShelfColumnTo.Rows.Count <> 0 Then
                        If dgRackShelfColumnFrom.Rows.Count <> 0 Then
                            For a = 0 To dgRackShelfColumnTo.Rows.Count - 1
                                If IsNumeric(dgRackShelfColumnTo.Rows(a).Cells("rsc_qtytransfer").Value) Then
                                    If CInt(dgRackShelfColumnTo.Rows(a).Cells("rsc_qtytransfer").Value) > 0 Then
                                        For b = 0 To dgRackShelfColumnFrom.Rows.Count - 1
                                            getProdInvLocID(CInt(dgRackShelfColumnTo.Rows(a).Cells("rsc_rowid").Value), CInt(dgRackShelfColumnFrom.Rows(b).Cells("r_pcsrowid").Value))
                                            If getpilocid = 0 Then
                                                I_ProductInventoryLocation(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CInt(dgRackShelfColumnTo.Rows(a).Cells("rsc_rowid").Value), CInt(dgRackShelfColumnFrom.Rows(b).Cells("r_pcsrowid").Value), CInt(dgRackShelfColumnTo.Rows(a).Cells("rsc_qtytransfer").Value), Me)
                                                getnewpilocid = globalproductinventorylocationidsp
                                                I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, storderid, DBNull.Value, DBNull.Value, CInt(dgRackShelfColumnFrom.Rows(b).Cells("r_pcsrowid").Value),
                                                    getnewpilocid, DBNull.Value, 0, CInt(dgRackShelfColumnTo.Rows(a).Cells("rsc_qtytransfer").Value), CInt(dgRackShelfColumnTo.Rows(a).Cells("rsc_qtytransfer").Value), "ST - To", "TotalAvailableQty", "", Me)
                                            Else
                                                getProductInventoryLocationTotals(getpilocid, Me)
                                                U_ProductInventoryLocationTotals(getpilocid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globalpiltotalavailableqty + CInt(dgRackShelfColumnTo.Rows(a).Cells("rsc_qtytransfer").Value), globalpiltotalreserveqty, Me)
                                                I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, storderid, DBNull.Value, DBNull.Value, CInt(dgRackShelfColumnFrom.Rows(b).Cells("r_pcsrowid").Value),
                                                           getpilocid, DBNull.Value, globalpiltotalavailableqty, CInt(dgRackShelfColumnTo.Rows(a).Cells("rsc_qtytransfer").Value), globalpiltotalavailableqty + CInt(dgRackShelfColumnTo.Rows(a).Cells("rsc_qtytransfer").Value), "ST - To", "TotalAvailableQty", "", Me)
                                            End If
                                        Next
                                    End If
                                End If
                            Next
                        End If
                    End If
                    If CInt(txtStockTransferNo.Text) <> globalorderno Then
                        MessageBox.Show("Please take note that the Stock Transfer No. has change from " & CStr(txtStockTransferNo.Text) & " to " & CStr(globalorderno) & "." & vbNewLine & "Another user used Stock Transfer No. " & CStr(txtStockTransferNo.Text) & " for its new stock transfer.", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtStockTransferNo.Text = CStr(globalorderno)
                    End If
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Save", "Save", lblsavemsg, -15, -65)
                        tsrefreshperformclick()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msCancel_Click(sender As Object, e As EventArgs) Handles msCancel.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgStockTransferList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearStockTransInformation()
                clearAddProductA()
                clearDatagrids()
                visibleRackShelfColumnFrom(fraud)
                visibleDatagrids(legit, fraud)
                enableGB(legit, legit, legit)
                enableANDvisibleMS(legit, fraud, fraud)
                If dgStockTransferList.Rows.Count <> 0 Then
                    dgStockTransferList.CurrentRow.Selected = legit
                End If
                cboFrom.Enabled = fraud : btnAddStockFrom.Enabled = fraud
                cboTo.Enabled = fraud : btnAddRackShelfColumn.Enabled = fraud
                displayStockTransferInformation(CInt(dgStockTransferList.CurrentRow.Cells("s_rowid").Value))
                displayProductHistory(CInt(dgStockTransferList.CurrentRow.Cells("s_rowid").Value))
                lblStockTransferItems.Text = "Stock Transfer History List:"
                dtpStockTransferDate.Focus()
            Else
                tsrefreshperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgStockTransferList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgStockTransferList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgStockTransferList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearStockTransInformation()
                clearAddProductA()
                clearDatagrids()
                visibleRackShelfColumnFrom(fraud)
                visibleDatagrids(legit, fraud)
                enableGB(legit, legit, legit)
                enableANDvisibleMS(legit, fraud, fraud)
                cboFrom.Enabled = fraud : btnAddStockFrom.Enabled = fraud
                cboTo.Enabled = fraud : btnAddRackShelfColumn.Enabled = fraud
                displayStockTransferInformation(CInt(dgStockTransferList.CurrentRow.Cells("s_rowid").Value))
                displayProductHistory(CInt(dgStockTransferList.CurrentRow.Cells("s_rowid").Value))
                lblStockTransferItems.Text = "Stock Transfer History List:"
                dtpStockTransferDate.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgStockTransferList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgStockTransferList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgStockTransferList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearStockTransInformation()
                    clearAddProductA()
                    clearDatagrids()
                    visibleRackShelfColumnFrom(fraud)
                    visibleDatagrids(legit, fraud)
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, fraud, fraud)
                    cboFrom.Enabled = fraud : btnAddStockFrom.Enabled = fraud
                    cboTo.Enabled = fraud : btnAddRackShelfColumn.Enabled = fraud
                    displayStockTransferInformation(CInt(dgStockTransferList.CurrentRow.Cells("s_rowid").Value))
                    displayProductHistory(CInt(dgStockTransferList.CurrentRow.Cells("s_rowid").Value))
                    lblStockTransferItems.Text = "Stock Transfer History List:"
                    dtpStockTransferDate.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#Region "Search/Page Setup"

    Private Sub txtSimpleSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSimpleSearch.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If txtSimpleSearch.Text = "" Then
                    tsrefreshperformclick()
                Else
                    txtPage.Text = ""
                    clearRightPage()
                    searchmode = "SimpleSearch"
                    simplesearchphrase = txtSimpleSearch.Text
                    spagenum = neutralpage : numofpages = startingpage
                    displaySearchPhrase(simplesearchphrase, spagenum)
                    pageSetup1(simplesearchphrase)
                    txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdFirst_Click(sender As Object, e As EventArgs) Handles cmdFirst.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            spagenum = neutralpage
            numofpages = startingpage
            If searchmode = "Basic" Then
                displayStockTransferList(spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            End If
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdPrev_Click(sender As Object, e As EventArgs) Handles cmdPrev.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            spagenum = spagenum - pagedivisor
            numofpages = numofpages - 1
            If spagenum < 0 Then
                If countpagenum < pagedivisor Then
                    spagenum = neutralpage
                Else
                    spagenum = countpagenum - pagedivisor
                End If
                numofpages = validpages
            End If
            If searchmode = "Basic" Then
                displayStockTransferList(spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            End If
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            spagenum = spagenum + pagedivisor
            numofpages = numofpages + 1
            If numofpages > validpages Then
                spagenum = neutralpage
                numofpages = startingpage
            End If
            If searchmode = "Basic" Then
                displayStockTransferList(spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            End If
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdLast_Click(sender As Object, e As EventArgs) Handles cmdLast.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If countpagenum < pagedivisor Then
                spagenum = neutralpage
            Else
                spagenum = countpagenum - pagedivisor
            End If
            numofpages = validpages
            If searchmode = "Basic" Then
                displayStockTransferList(spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            End If
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtPage_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPage.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If IsNumeric(txtPage.Text) Then
                    If CInt(txtPage.Text) < 0 Then
                    ElseIf CInt(txtPage.Text) = 0 Then
                    ElseIf CInt(txtPage.Text) > validpages Then
                    Else
                        clearRightPage()
                        If countpagenum < pagedivisor Then
                            spagenum = neutralpage
                        Else
                            pageequation1 = CInt(txtPage.Text) * pagedivisor
                            pageequation2 = ((CInt(txtPage.Text) / validpages) * countpagenum)
                            If pageequation1 < pageequation2 Then
                                pageequation3 = ((CInt(txtPage.Text) / validpages) * countpagenum) - (pageequation2 - pageequation1)
                            Else
                                pageequation3 = (CInt(txtPage.Text) / validpages) * countpagenum
                            End If
                            spagenum = pageequation3 - pagedivisor
                        End If
                        numofpages = CInt(txtPage.Text)
                        If searchmode = "Basic" Then
                            displayStockTransferList(spagenum)
                        ElseIf searchmode = "SimpleSearch" Then
                            displaySearchPhrase(simplesearchphrase, spagenum)
                        End If
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                        txtPage.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "Datagrid MouseUp"

    Private Sub dgRackShelfColumnTo_MouseUp(sender As Object, e As MouseEventArgs) Handles dgRackShelfColumnTo.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgRackShelfColumnTo.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgRackShelfColumnTo.BeginEdit(True)
                Else
                    dgRackShelfColumnTo.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Datagrid Errors"

    Private Sub dgProductHistory_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProductHistory.DataError
        Me.Cursor = Cursors.WaitCursor
        Try
            'MessageBox.Show("Error:  " & e.Context.ToString())
            If (e.Context = DataGridViewDataErrorContexts.Commit) _
                Then
                'MessageBox.Show("Commit error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
                MessageBox.Show("Cell change")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
                MessageBox.Show("parsing error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                ' MessageBox.Show("leave control error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Formatting) Then
                'MessageBox.Show("leave control error")
            End If
            If (TypeOf (e.Exception) Is ConstraintException) Then
                Dim view As DataGridView = CType(sender, DataGridView)
                view.Rows(e.RowIndex).ErrorText = "an error"
                view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                    .ErrorText = "an error"
                MsgBox("error")
                e.ThrowException = False
            End If
            If StrComp(e.Exception.Message, "Input string was not in a correct format.") = 0 Then
                MessageBox.Show("Please Enter a numeric Value")
                'This will change the number back to original
                dgProductHistory.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgStockTransferList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgStockTransferList.DataError
        Me.Cursor = Cursors.WaitCursor
        Try
            'MessageBox.Show("Error:  " & e.Context.ToString())
            If (e.Context = DataGridViewDataErrorContexts.Commit) _
                Then
                'MessageBox.Show("Commit error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
                MessageBox.Show("Cell change")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
                MessageBox.Show("parsing error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                ' MessageBox.Show("leave control error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Formatting) Then
                'MessageBox.Show("leave control error")
            End If
            If (TypeOf (e.Exception) Is ConstraintException) Then
                Dim view As DataGridView = CType(sender, DataGridView)
                view.Rows(e.RowIndex).ErrorText = "an error"
                view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                    .ErrorText = "an error"
                MsgBox("error")
                e.ThrowException = False
            End If
            If StrComp(e.Exception.Message, "Input string was not in a correct format.") = 0 Then
                MessageBox.Show("Please Enter a numeric Value")
                'This will change the number back to original
                dgStockTransferList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgRackShelfColumnFrom_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgRackShelfColumnFrom.DataError
        Me.Cursor = Cursors.WaitCursor
        Try
            'MessageBox.Show("Error:  " & e.Context.ToString())
            If (e.Context = DataGridViewDataErrorContexts.Commit) _
                Then
                'MessageBox.Show("Commit error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
                MessageBox.Show("Cell change")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
                MessageBox.Show("parsing error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                ' MessageBox.Show("leave control error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Formatting) Then
                'MessageBox.Show("leave control error")
            End If
            If (TypeOf (e.Exception) Is ConstraintException) Then
                Dim view As DataGridView = CType(sender, DataGridView)
                view.Rows(e.RowIndex).ErrorText = "an error"
                view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                    .ErrorText = "an error"
                MsgBox("error")
                e.ThrowException = False
            End If
            If StrComp(e.Exception.Message, "Input string was not in a correct format.") = 0 Then
                MessageBox.Show("Please Enter a numeric Value")
                'This will change the number back to original
                dgRackShelfColumnFrom.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgRackShelfColumnTo_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgRackShelfColumnTo.DataError
        Me.Cursor = Cursors.WaitCursor
        Try
            'MessageBox.Show("Error:  " & e.Context.ToString())
            If (e.Context = DataGridViewDataErrorContexts.Commit) _
                Then
                'MessageBox.Show("Commit error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
                MessageBox.Show("Cell change")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
                MessageBox.Show("parsing error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                ' MessageBox.Show("leave control error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Formatting) Then
                'MessageBox.Show("leave control error")
            End If
            If (TypeOf (e.Exception) Is ConstraintException) Then
                Dim view As DataGridView = CType(sender, DataGridView)
                view.Rows(e.RowIndex).ErrorText = "an error"
                view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                    .ErrorText = "an error"
                MsgBox("error")
                e.ThrowException = False
            End If
            If StrComp(e.Exception.Message, "Input string was not in a correct format.") = 0 Then
                MessageBox.Show("Please Enter a numeric Value")
                'This will change the number back to original
                dgRackShelfColumnTo.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

End Class