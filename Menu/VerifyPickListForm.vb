Imports MySql.Data.MySqlClient
Imports WarehouseManagementSystem.Core.Interfaces

Public Class VerifyPickListForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim conn2 As New MySqlConnection(manager.GetConnString)
    Dim conn3 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim printdataset As New DataSetA.SetADataTable
    Dim printdatasetsku As New DataSetA.SetDDataTable
    Dim printdatatable As New DataTable
    Dim ImageData() As Byte
    Dim productimage As Object
    Dim itemno, rowscount As Integer
    Dim vplloadingbar As Integer = 4
    Dim cue, searchmode, simplesearchphrase As String
    Dim spagenum, countpagenum, numofpages, validpages As Integer
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal
    Dim vpltotalqtypicked, vplqtypicked, vplqtypickedsum, vplpicklistorderstatus As Integer
    Private _systemOwner As WarehouseManagementSystem.Core.Entities.SystemOwner

    Private Async Sub VerifyPickListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            displayPickList(spagenum)
            colorCoding() : pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VerifyPickListForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

#Region "Functions"

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            cue = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearPickListInformation()
            dgPickListItems.Rows.Clear()
            enableGB(legit, fraud)
            visiblePickListItems(fraud)
            enableANDvisibleMS(fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRightPage()
        Try
            cue = ""
            clearPickListInformation()
            dgPickListItems.Rows.Clear()
            enableGB(legit, fraud)
            visiblePickListItems(fraud)
            enableANDvisibleMS(fraud)
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

    Sub clearPickListInformation()
        Try
            txtPickListNo.Text = ""
            txtPickerName.Text = ""
            txtCompletedDate.Text = ""
            txtStatus.Text = ""
            txtComments.Text = ""
            txtTotalQtyPicked.Text = ""
            chkOtherInfo.Checked = fraud
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbPickList.Enabled = enable1
            gbPickListInformation.Enabled = enable2
            gbPickListItems.Enabled = enable2
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub visiblePickListItems(ByVal visible1 As Boolean)
        Try
            pli_unitofmeasure.Visible = visible1
            pli_verifiedby.Visible = visible1
            pli_verifieddate.Visible = visible1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub enableANDvisibleMS(ByVal enable1 As Boolean)
        Try
            msSave.Enabled = enable1
            'msPrint.Enabled = enable1
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
            displayPickList(spagenum)
            colorCoding() : pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Function clickpicklist() As Task
        Try
            clearPickListInformation()
            dgPickListItems.Rows.Clear()
            enableGB(legit, legit)
            visiblePickListItems(fraud)
            getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
            If globalpickliststatus = "Cancelled" Then
                enableANDvisibleMS(fraud)
            ElseIf globalpickliststatus = "Completed" Then
                enableANDvisibleMS(fraud)
            Else
                enableANDvisibleMS(legit)
            End If
            displayPickListInformation(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
            Await displayPickListItemsA(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
            colorCoding() : verifypicklistcomputation()
            txtComments.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Function

    Sub verifypicklist()
        Try
            clearPickListInformation()
            ' dgPickListItems.Rows.Clear()
            enableGB(legit, legit)
            visiblePickListItems(fraud)
            getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
            dgPickList.CurrentRow.Cells("pl_status").Value = globalpickliststatus
            If globalpickliststatus = "Cancelled" Then
                enableANDvisibleMS(fraud)
            ElseIf globalpickliststatus = "Completed" Then
                enableANDvisibleMS(fraud)
            Else
                enableANDvisibleMS(legit)
            End If
            displayPickListInformation(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
            dgPickListItems.CurrentRow.Cells("pli_status").Value = "Verified"
            'displayPickListItemsA(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
            colorCoding() : verifypicklistcomputation()
            txtComments.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Computations"

    Sub verifypicklistcomputation()
        Try
            vpltotalqtypicked = 0
            If dgPickListItems.Rows.Count <> 0 Then
                For i = 0 To dgPickListItems.Rows.Count - 1
                    If IsNumeric(dgPickListItems.Rows(i).Cells("pli_qtypicked").Value) Then
                        vpltotalqtypicked = vpltotalqtypicked + CInt(dgPickListItems.Rows(i).Cells("pli_qtypicked").Value)
                    End If
                Next
            End If
            txtTotalQtyPicked.Text = Format(vpltotalqtypicked, "#,##0")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getTotalQtyPicked(ByVal ipicklistorderid As Integer)
        Try
            vplqtypicked = 0
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pli.qtypicked),0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND (pli.`status` = 'Active' OR pli.`status` = 'Verified') ")
            If dtGtq.Rows.Count <> 0 Then
                vplqtypicked = dtGtq.Rows(0)(0)
            Else
                vplqtypicked = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(pl.rowid),0) FROM picklist pl WHERE pl.organizationid = " & Z_OrganizationID & " ")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(pl.rowid),0) FROM picklist pl WHERE pl.organizationid = " & Z_OrganizationID & " AND (pl.picklistno LIKE ""%" & esearchstring & "%"" OR pl.status LIKE ""%" & esearchstring & "%"") ")
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

#Region "Datagrids"

    Sub displayPickList(ByVal istartpage As Integer)
        Try
            dgPickList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pl.rowid,COALESCE(pl.picklistno,''),COALESCE(pl.status,''),COALESCE(DATE_FORMAT(pl.completeddate,'%d-%b-%Y'),'') " &
                        "FROM picklist pl WHERE pl.organizationid = " & Z_OrganizationID & " ORDER BY pl.picklistno DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPickList.Rows.Add()
                    dgPickList.Item(pl_rowid.Index, n).Value = reader1(0)
                    dgPickList.Item(pl_picklistno.Index, n).Value = reader1(1)
                    dgPickList.Item(pl_status.Index, n).Value = reader1(2)
                    dgPickList.Item(pl_completeddate.Index, n).Value = reader1(3)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPickList.Columns("pl_picklistno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickList.Columns("pl_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickList.Columns("pl_completeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPickList.Rows.Count <> 0 Then
                dgPickList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgPickList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pl.rowid,COALESCE(pl.picklistno,''),COALESCE(pl.status,''),COALESCE(DATE_FORMAT(pl.completeddate,'%d-%b-%Y'),'') " &
                        "FROM picklist pl WHERE pl.organizationid = " & Z_OrganizationID & " AND (pl.picklistno LIKE ""%" & isearchphrase & "%"" OR pl.status LIKE ""%" & isearchphrase & "%"") " &
                        "ORDER BY pl.picklistno DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPickList.Rows.Add()
                    dgPickList.Item(pl_rowid.Index, n).Value = reader1(0)
                    dgPickList.Item(pl_picklistno.Index, n).Value = reader1(1)
                    dgPickList.Item(pl_status.Index, n).Value = reader1(2)
                    dgPickList.Item(pl_completeddate.Index, n).Value = reader1(3)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPickList.Columns("pl_picklistno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickList.Columns("pl_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickList.Columns("pl_completeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPickList.Rows.Count <> 0 Then
                dgPickList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayPickListInformation(ByVal ipicklistid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(pl.picklistno,''),COALESCE(DATE_FORMAT(pl.completeddate,'%d-%b-%Y'),''),COALESCE(pl.status,''),COALESCE(pl.comments,'')," &
                        "COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'') " &
                        "FROM picklist pl LEFT JOIN contacts c ON pl.contactid = c.rowid WHERE pl.rowid = " & ipicklistid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtPickListNo.Text = reader1(0)
                    txtCompletedDate.Text = reader1(1)
                    txtStatus.Text = reader1(2)
                    txtComments.Text = reader1(3)
                    txtPickerName.Text = reader1(4)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Private Async Function displayPickListItemsA(ByVal ipicklistid As Integer) As Task
        Try
            dgPickListItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(oi.productcolorsizeid,0),COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,''),COALESCE(oi.unitofmeasure,''),COALESCE(plo.status,'')," &
                    "COALESCE(CONCAT(COALESCE(vb.firstname,''),' ',COALESCE(vb.lastname,''),' - ',COALESCE(vb.rowid,'')),''),COALESCE(DATE_FORMAT(oi.verifieddate,'%d-%b-%Y'),''),COALESCE(oi.sku,''), IFNULL(il.Name, '') `InventoryLocation` FROM picklistorders plo LEFT JOIN orderitems oi ON plo.orderitemid = oi.rowid " &
                    "LEFT JOIN productcolorsizes pcs ON oi.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN users vb ON oi.verifiedby = vb.rowid LEFT JOIN colors c ON pc.colorid = c.rowid " &
                    "LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN orders o ON o.RowID=oi.OrderID LEFT JOIN inventorylocations il ON il.RowID=o.InventoryLocationID WHERE plo.organizationid = " & Z_OrganizationID & " AND (plo.`status` != 'Inactive' AND plo.`status` != 'Cancelled') " &
                    "AND plo.picklistid = " & ipicklistid & " GROUP BY oi.productcolorsizeid ORDER BY p.productcode,c.colorname,pcs.size "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = Await cmd1.ExecuteReaderAsync()
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgPickListItems.Rows.Add()
                    dgPickListItems.Item(pli_seqno.Index, n).Value = seqno
                    dgPickListItems.Item(pli_rowid.Index, n).Value = reader1(0)
                    dgPickListItems.Item(pli_colorvalue.Index, n).Value = reader1(1)
                    dgPickListItems.Item(pli_productcode.Index, n).Value = reader1(2)
                    dgPickListItems.Item(pli_colorname.Index, n).Value = reader1(3)
                    dgPickListItems.Item(pli_color.Index, n).Value = ""
                    dgPickListItems.Item(pli_size.Index, n).Value = reader1(4)
                    dgPickListItems.Item(pli_seasoncode.Index, n).Value = reader1(5)
                    If LTrim(CStr(reader1(8))) = "" Then
                        dgPickListItems.Item(pli_sku.Index, n).Value = reader1(6)
                    Else
                        dgPickListItems.Item(pli_sku.Index, n).Value = reader1(11)
                    End If
                    dgPickListItems.Item(pli_unitofmeasure.Index, n).Value = reader1(7)
                    displayPickListItemsB(ipicklistid, CInt(reader1(0)))
                    dgPickListItems.Item(pli_qtypicked.Index, n).Value = vplqtypickedsum
                    If CStr(reader1(8)) <> "Verified" Then
                        dgPickListItems.Item(pli_status.Index, n).Value = "Not verified"
                    Else
                        dgPickListItems.Item(pli_status.Index, n).Value = reader1(8)
                    End If
                    dgPickListItems.Item(pli_verifiedby.Index, n).Value = reader1(9)
                    dgPickListItems.Item(pli_verifieddate.Index, n).Value = reader1(10)
                    dgPickListItems.Item(pli_inventorylocation.Index, n).Value = reader1(12)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPickListItems.Columns("pli_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListItems.Columns("pli_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListItems.Columns("pli_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListItems.Columns("pli_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListItems.Columns("pli_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListItems.Columns("pli_qtypicked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListItems.Columns("pli_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListItems.Columns("pli_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListItems.Columns("pli_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListItems.Columns("pli_verify").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickListItems.Columns("pli_verifieddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPickListItems.Rows.Count <> 0 Then
                dgPickListItems.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Function

    Sub displayPickListItemsB(ByVal epicklistid As Integer, ByVal eproductcolorsizeid As Integer)
        Try
            vplqtypickedsum = 0
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT plo.rowid FROM picklistorders plo LEFT JOIN orderitems oi ON plo.orderitemid = oi.rowid WHERE plo.organizationid = " & Z_OrganizationID & " " &
                    "AND (plo.`status` != 'Inactive' AND plo.`status` != 'Cancelled') AND oi.productcolorsizeid = " & eproductcolorsizeid & " AND plo.picklistid = " & epicklistid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getTotalQtyPicked(CInt(reader1(0)))
                    vplqtypickedsum = vplqtypickedsum + vplqtypicked
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

#End Region

#Region "Colors"

    Sub colorCoding()
        Try
            If dgPickList.Rows.Count <> 0 Then
                For i As Integer = 0 To dgPickList.Rows.Count - 1
                    If dgPickList.Rows(i).Cells(pl_status.Index).Value = "New" Then
                        dgPickList.Rows(i).DefaultCellStyle.BackColor = Color.LightYellow
                    ElseIf dgPickList.Rows(i).Cells(pl_status.Index).Value = "Modified" Then
                        dgPickList.Rows(i).DefaultCellStyle.BackColor = Color.PowderBlue
                    ElseIf dgPickList.Rows(i).Cells(pl_status.Index).Value = "Cancelled" Then
                        dgPickList.Rows(i).DefaultCellStyle.BackColor = Color.MistyRose
                    ElseIf dgPickList.Rows(i).Cells(pl_status.Index).Value = "Completed" Then
                        dgPickList.Rows(i).DefaultCellStyle.BackColor = Color.Honeydew
                    End If
                Next
            End If
            If dgPickListItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgPickListItems.Rows.Count - 1
                    If CStr(dgPickListItems.Rows(i).Cells("pli_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgPickListItems.Rows(i).Cells("pli_colorvalue").Value))
                        dgPickListItems.Rows(i).Cells("pli_color").Style.BackColor = readcolor
                    End If
                    dgPickListItems.Rows(i).Cells("pli_qtypicked").Style.BackColor = Color.Gainsboro
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

#Region "Verifying"

    Sub getPickListOrderStatusA(ByVal ipicklistid As Integer, ByVal iproductcolorsizeid As Integer)
        Try
            vplpicklistorderstatus = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtGplos As New DataTable
            dtGplos = getDataTableForSQL("SELECT COALESCE(plo.rowid,0) FROM picklistorders plo LEFT JOIN orderitems oi ON plo.orderitemid = oi.rowid WHERE plo.organizationid = " & Z_OrganizationID & " AND oi.productcolorsizeid = " & iproductcolorsizeid & " AND plo.picklistid = " & ipicklistid & " AND plo.`status` = 'Verified' ")
            If dtGplos.Rows.Count <> 0 Then
                vplpicklistorderstatus = dtGplos.Rows(0)(0)
            Else
                vplpicklistorderstatus = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getPickListOrderStatusB(ByVal ipicklistid As Integer)
        Try
            vplpicklistorderstatus = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtGplos As New DataTable
            dtGplos = getDataTableForSQL("SELECT COALESCE(plo.rowid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.picklistid = " & ipicklistid & " AND (plo.`status` = 'New' OR plo.`status` = 'Modified') ")
            If dtGplos.Rows.Count <> 0 Then
                vplpicklistorderstatus = dtGplos.Rows(0)(0)
            Else
                vplpicklistorderstatus = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub verifyPickListItemsA(ByVal ipicklistid As Integer, ByVal iproductcolorsizeid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT plo.rowid,plo.orderitemid,plo.orderid FROM picklistorders plo LEFT JOIN orderitems oi ON plo.orderitemid = oi.rowid WHERE plo.organizationid = " & Z_OrganizationID & " " &
                    "AND (plo.`status` != 'Inactive' AND plo.`status` != 'Cancelled') AND oi.productcolorsizeid = " & iproductcolorsizeid & " AND plo.picklistid = " & ipicklistid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        U_PickListOrderStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Verified", Me)
                    End If
                    If myModule.systemerrorfound = False Then
                        getOrderItemStatus(CInt(reader1(1)), Me)
                        If globalorderitemstatus = "Pick Listed" Then
                            U_OrderItemVerification(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Verified", Z_UserID, Date.Now.ToString("yyyy/MM/dd"), Me)
                        End If
                    End If
                    If myModule.systemerrorfound = False Then
                        getOrderStatus(CInt(reader1(2)), Me)
                        If globalorderstatus = "Pick Listed" Then
                            U_OrderStatus(CInt(reader1(2)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "For Packing", Me)
                        End If
                    End If
                    If myModule.systemerrorfound = False Then
                        verifyPickListItemsB(CInt(reader1(0)))
                    End If
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub verifyPickListItemsB(ByVal ipicklistorderid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT pli.rowid,pli.productinventorylocationid,COALESCE(pli.qtypicked,0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND pli.`status` = 'Active' "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    U_PickListOrderItemStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Verified", Me)
                    getProductInventoryLocationTotals(CInt(reader1(1)), Me)
                    getTotalQtyAllocatedC(CInt(reader1(1)), Me)
                    U_ProductInventoryLocationTotals(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globalpiltotalavailableqty - CInt(reader1(2)), globalpiltotalreserveqty + CInt(reader1(2)), Me)
                    U_ProductInventoryLocationQtyAllocated(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globaltotalqtyallocated - CInt(reader1(2)), Me)
                    I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, DBNull.Value, DBNull.Value, CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), DBNull.Value, CInt(reader1(1)),
                            DBNull.Value, globalpiltotalavailableqty, CInt(reader1(2)), globalpiltotalavailableqty - CInt(reader1(2)), "Verify PL QA", "TotalAvailableQty", "", Me)
                    I_ProductMovementHistory(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, DBNull.Value, DBNull.Value, CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), DBNull.Value, CInt(reader1(1)),
                            DBNull.Value, globalpiltotalreserveqty, CInt(reader1(2)), globalpiltotalreserveqty + CInt(reader1(2)), "Verify PL QR", "TotalReserveQty", "", Me)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

#End Region

#Region "Printing"

    Sub printVerifyPickListA(ByVal ipicklistid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(o.rowid,0),COALESCE(p.productcode,''),COALESCE(co.colorname,''),COALESCE(pcs.size,''),COALESCE(pli.qtypicked,0),COALESCE(pl.picklistno,'')," &
                        "COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),''),COALESCE(DATE_FORMAT(pl.picklistdate,'%d-%b-%Y')),COALESCE(il.name,''),COALESCE(pcs.seasoncode,''),COALESCE(o.referencenumber,'')," &
                        "COALESCE(o.CustomerName,''),COALESCE(bc.branchcode,''),COALESCE(DATE_FORMAT(o.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.targetdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.enddate,'%d-%b-%Y'),''),COALESCE(CONCAT(COALESCE(c1.codename,''),', ',COALESCE(c1.codeno,'')),''),COALESCE(o.ordernumber,''),COALESCE(pil.UnitPriceOfUOM2,0.00) " &
                        "FROM picklistorderitems pli LEFT JOIN picklistorders plo ON pli.picklistorderid = plo.rowid LEFT JOIN orders o ON plo.orderid = o.rowid LEFT JOIN branches bc ON o.branchid = bc.rowid LEFT JOIN picklist pl ON plo.picklistid = pl.rowid LEFT JOIN inventorylocations il ON pl.inventorylocationid = il.rowid " &
                        "LEFT JOIN combinecodings cc ON o.combinecodingid = cc.rowid LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN contacts c ON pl.contactid = c.rowid LEFT JOIN productinventorylocation pil ON pli.productinventorylocationid = pil.rowid LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " &
                        "LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors co ON pc.colorid = co.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pl.organizationid = " & Z_OrganizationID & " " &
                        "AND pl.rowid = " & ipicklistid & " AND plo.`status` != 'Inactive' AND pli.`status` != 'Inactive' AND pli.qtypicked > 0 ORDER BY p.productcode,o.referencenumber,o.CustomerName ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            cmd1.CommandTimeout = commantimeoutlimit
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    productimage = Nothing
                    printdataset.AddSetARow(CStr(reader1(0)),
                        CStr(reader1(1)),
                        CStr(reader1(2)),
                        CStr(reader1(3)),
                        CInt(reader1(4)),
                        "ENTRY DATE: " & CStr(reader1(13)) & "",
                        "RECEIPT DATE: " & CStr(reader1(14)) & "",
                        "DEPT: " & CStr(reader1(16)) & "",
                        "CANCEL DATE: " & CStr(reader1(15)) & "",
                        "" & CStr(reader1(10)) & "" & vbNewLine & "" & CStr(reader1(17)) & "",
                        CStr(reader1(11)),
                        productimage,
                        CStr(reader1(12)),
                        "PICK LIST NO.: " & CStr(reader1(5)) & "",
                        "" & CStr(reader1(18)) & " - " & CStr(reader1(9)) & "")
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub printVerifyPickListB(ByVal ipicklistid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            'Dim sql1 As String = "SELECT COALESCE(o.rowid,0),COALESCE(p.productcode,''),COALESCE(co.colorname,''),COALESCE(pcs.size,''),COALESCE(pli.qtypicked,0),COALESCE(pl.picklistno,'')," & _
            '            "COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),''),COALESCE(DATE_FORMAT(pl.picklistdate,'%d-%b-%Y')),COALESCE(il.name,''),COALESCE(pcs.seasoncode,''),COALESCE(o.referencenumber,'')," & _
            '            "COALESCE(bc.branchname,''),COALESCE(bc.branchcode,''),COALESCE(DATE_FORMAT(o.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.targetdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.enddate,'%d-%b-%Y'),''),COALESCE(CONCAT(COALESCE(c1.codename,''),', ',COALESCE(c1.codeno,'')),''),COALESCE(o.ordernumber,''),COALESCE(p.unitprice,0.00) " & _
            '            "FROM picklistorderitems pli LEFT JOIN picklistorders plo ON pli.picklistorderid = plo.rowid LEFT JOIN orders o ON plo.orderid = o.rowid LEFT JOIN branches bc ON o.branchid = bc.rowid LEFT JOIN picklist pl ON plo.picklistid = pl.rowid LEFT JOIN inventorylocations il ON pl.inventorylocationid = il.rowid " & _
            '            "LEFT JOIN combinecodings cc ON o.combinecodingid = cc.rowid LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN contacts c ON pl.contactid = c.rowid LEFT JOIN productinventorylocation pil ON pli.productinventorylocationid = pil.rowid LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " & _
            '            "LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors co ON pc.colorid = co.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pl.organizationid = " & Z_OrganizationID & " " & _
            '            "AND pl.rowid = " & ipicklistid & " AND plo.`status` != 'Inactive' AND pli.`status` != 'Inactive' AND pli.qtypicked > 0 ORDER BY o.ordernumber ASC "
            Dim sql1 As String = "SELECT COALESCE(o.rowid,0),COALESCE(p.productcode,''),COALESCE(co.colorname,''),COALESCE(pcs.size,''),COALESCE(pli.qtypicked,0),COALESCE(pl.picklistno,'')," &
                        "COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),''),COALESCE(DATE_FORMAT(pl.picklistdate,'%d-%b-%Y'),''),COALESCE(il.name,''),COALESCE(pcs.seasoncode,''),COALESCE(o.referencenumber,''),COALESCE(o.CustomerName,'')," &
                        "COALESCE(bc.branchcode,''),COALESCE(DATE_FORMAT(o.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.targetdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.enddate,'%d-%b-%Y'),''),COALESCE(CONCAT(COALESCE(c1.codename,''),', ',COALESCE(c1.codeno,'')),''),COALESCE(o.ordernumber,''),COALESCE(pil.UnitPriceOfUOM2,0.00) " &
                        "FROM picklistorderitems pli LEFT JOIN picklistorders plo ON pli.picklistorderid = plo.rowid LEFT JOIN orders o ON plo.orderid = o.rowid LEFT JOIN branches bc ON o.branchid = bc.rowid LEFT JOIN picklist pl ON plo.picklistid = pl.rowid LEFT JOIN inventorylocations il ON pl.inventorylocationid = il.rowid " &
                        "LEFT JOIN combinecodings cc ON o.combinecodingid = cc.rowid LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN contacts c ON pl.contactid = c.rowid LEFT JOIN productinventorylocation pil ON pli.productinventorylocationid = pil.rowid LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " &
                        "LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors co ON pc.colorid = co.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pl.organizationid = " & Z_OrganizationID & " " &
                        "AND pl.rowid = " & ipicklistid & " AND plo.`status` != 'Inactive' AND pli.`status` != 'Inactive' AND pli.qtypicked > 0 ORDER BY o.ordernumber,p.productcode ASC,o.CustomerName ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            cmd1.CommandTimeout = commantimeoutlimit
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    productimage = Nothing
                    'printdataset.AddSetARow(CStr(reader1(0)), CStr(reader1(1)), CStr(reader1(2)), CStr(reader1(3)), CInt(reader1(4)), "ENTRY DATE: " & CStr(reader1(13)) & "", "RECEIPT DATE: " & CStr(reader1(14)) & "", "DEPT: " & CStr(reader1(16)) & "", "CANCEL DATE: " & CStr(reader1(15)) & "", "" & CStr(reader1(10)) & "" & vbNewLine & "" & CStr(reader1(17)) & "", CStr(reader1(11)), productimage, CStr(reader1(12)), "PICK LIST NO.: " & CStr(reader1(5)) & "", "" & CStr(reader1(18)) & " - " & CStr(reader1(9)) & "")
                    printdataset.AddSetARow(CStr(reader1(0)), CStr(reader1(1)), CStr(reader1(2)), CStr(reader1(3)), CInt(reader1(4)), "ENTRY DATE: " & CStr(reader1(13)) & "", "RECEIPT DATE: " & CStr(reader1(14)) & "", "DEPT: " & CStr(reader1(16)) & "", "CANCEL DATE: " & CStr(reader1(15)) & "", "" & CStr(reader1(10)) & "" & vbNewLine & "" & CStr(reader1(17)) & "", CStr(reader1(11)), productimage, CStr(reader1(12)), "PICK LIST NO.: " & CStr(reader1(5)) & "", "" & CStr(reader1(18)) & " - " & CStr(reader1(9)) & "")
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub printVerifyPickListC(ByVal ipicklistid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            'Dim sql1 As String = "SELECT COALESCE(o.rowid,0),COALESCE(p.productcode,''),COALESCE(co.colorname,''),COALESCE(pcs.size,''),COALESCE(pli.qtypicked,0),COALESCE(pl.picklistno,'')," & _
            '            "COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),''),COALESCE(DATE_FORMAT(pl.picklistdate,'%d-%b-%Y')),COALESCE(il.name,''),COALESCE(pcs.seasoncode,''),COALESCE(o.referencenumber,'')," & _
            '            "COALESCE(bc.branchname,''),COALESCE(bc.branchcode,''),COALESCE(DATE_FORMAT(o.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.targetdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.enddate,'%d-%b-%Y'),''),COALESCE(CONCAT(COALESCE(c1.codename,''),', ',COALESCE(c1.codeno,'')),''),COALESCE(o.ordernumber,''),COALESCE(p.unitprice,0.00) " & _
            '            "FROM picklistorderitems pli LEFT JOIN picklistorders plo ON pli.picklistorderid = plo.rowid LEFT JOIN orders o ON plo.orderid = o.rowid LEFT JOIN branches bc ON o.branchid = bc.rowid LEFT JOIN picklist pl ON plo.picklistid = pl.rowid LEFT JOIN inventorylocations il ON pl.inventorylocationid = il.rowid " & _
            '            "LEFT JOIN combinecodings cc ON o.combinecodingid = cc.rowid LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN contacts c ON pl.contactid = c.rowid LEFT JOIN productinventorylocation pil ON pli.productinventorylocationid = pil.rowid LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " & _
            '            "LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors co ON pc.colorid = co.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pl.organizationid = " & Z_OrganizationID & " " & _
            '            "AND pl.rowid = " & ipicklistid & " AND plo.`status` != 'Inactive' AND pli.`status` != 'Inactive' AND pli.qtypicked > 0 ORDER BY o.ordernumber ASC "
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(o.ordernumber,''),' - ',COALESCE(o.referencenumber,'')),'') AS 'CO-PO',COALESCE(pl.picklistno,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(oi.sku,''),COALESCE(pli.qtypicked,0) FROM picklistorders plo " &
                        "INNER JOIN picklistorderitems pli ON plo.rowid = pli.picklistorderid LEFT JOIN productinventorylocation pil ON pli.productinventorylocationid = pil.rowid LEFT JOIN picklist pl ON plo.picklistid = pl.rowid LEFT JOIN orders o ON plo.orderid = o.rowid LEFT JOIN orderitems oi ON plo.orderitemid = oi.rowid " &
                        "LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE plo.organizationid = " & Z_OrganizationID & " " &
                        "AND plo.picklistid = " & ipicklistid & " AND plo.`status` != 'Inactive' AND pli.`status` != 'Inactive' AND pli.qtypicked > 0 ORDER BY o.ordernumber, p.productcode, c.colorname, pcs.size "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            cmd1.CommandTimeout = commantimeoutlimit
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    productimage = Nothing
                    'printdataset.AddSetARow(CStr(reader1(0)), CStr(reader1(1)), CStr(reader1(2)), CStr(reader1(3)), CInt(reader1(4)), "ENTRY DATE: " & CStr(reader1(13)) & "", "RECEIPT DATE: " & CStr(reader1(14)) & "", "DEPT: " & CStr(reader1(16)) & "", "CANCEL DATE: " & CStr(reader1(15)) & "", "" & CStr(reader1(10)) & "" & vbNewLine & "" & CStr(reader1(17)) & "", CStr(reader1(11)), productimage, CStr(reader1(12)), "PICK LIST NO.: " & CStr(reader1(5)) & "", "" & CStr(reader1(18)) & " - " & CStr(reader1(9)) & "")
                    printdatasetsku.AddSetDRow(CStr(reader1(0)), "PICK LIST NO.: " & CStr(reader1(1)) & "", CStr(reader1(2)), CStr(reader1(3)), CStr(reader1(4)), CStr(reader1(5)), CStr(reader1(6)), CStr(reader1(7)), "", "", "", "", "", "", "", "", "", "", "", "", "")
                End If
            End While
            reader1.Close()
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
                PrimaryForm.VPLForm = False
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

    Private Sub dgPickList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPickList.CellContentClick

    End Sub

    Private Async Sub dgPickList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPickList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPickList.Rows.Count <> 0 Then
                Await clickpicklist()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub dgPickList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgPickList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPickList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    Await clickpicklist()
                End If
            End If
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
                visiblePickListItems(legit)
            Else
                visiblePickListItems(fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Move From Picking To Packing", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.VPLForm = False
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalcreateflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If dgPickList.Rows.Count <> 0 Then
                getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                If globalpickliststatus = "Cancelled" Then
                    MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                ElseIf globalpickliststatus = "Completed" Then
                    MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                    If globalpickliststatus = "Cancelled" Then
                        MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    ElseIf globalpickliststatus = "Completed" Then
                        MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    U_PickListComments(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtComments.Text, Me)
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                    End If
                End If
            Else
                errProvider.SetError(txtPickListNo, "System cannot find the Pick List to be updated.")
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgPickListItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPickListItems.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            If dgPickListItems.Rows.Count <> 0 Then
                If e.ColumnIndex = dgPickListItems.Columns("pli_verify").Index Then
                    getPositionID(Me)
                    If globalpositionid <> 0 Then
                        getPositionView(globalpositionid, "Move From Picking To Packing", Me)
                        If globaldisableflg = "Y" Then
                            MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            PrimaryForm.VPLForm = False
                            Me.Close()
                        End If
                        If globalreadonlyflg = "Y" Then
                            MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                        If globalcreateflg = "Y" AndAlso Not IsThurston Then
                            MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                    Else
                        MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    If dgPickList.Rows.Count <> 0 Then
                        getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                        If globalpickliststatus = "Cancelled" Then
                            MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        ElseIf globalpickliststatus = "Completed" Then
                            MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                        getPickListOrderStatusA(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgPickListItems.CurrentRow.Cells("pli_rowid").Value))
                        If vplpicklistorderstatus = 0 Then
                            displayPickListItemsB(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgPickListItems.CurrentRow.Cells("pli_rowid").Value))
                            If IsNumeric(dgPickListItems.CurrentRow.Cells("pli_qtypicked").Value) Then
                                If CInt(dgPickListItems.CurrentRow.Cells("pli_qtypicked").Value) <> vplqtypickedsum Then
                                    MessageBox.Show("This pick list item has been updated by other user, please click refresh button to check the new status of this pick list item.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                End If
                            Else
                                MessageBox.Show("This pick list has items been updated by other user, please click refresh button to check the new status of this pick list item.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        Else
                            If Not IsVerifyAll Then MessageBox.Show("This pick list item has been verified already.", "Verifying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                        If If(IsVerifyAll, DialogResult.Yes, MessageBox.Show("NOTE: Verifying this pick list item means that you have completely checked the quality and quantity of this/these item/s." & vbNewLine & "" & vbNewLine & "Do you want to proceed verifying this pick list item/s?", "Verifying", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.Yes Then
                            Me.Cursor = Cursors.WaitCursor
                            PrimaryForm.MainLoadingBar.Visible = legit
                            PrimaryForm.MainLoadingBar.Maximum = vplloadingbar
                            ' getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                            If PrimaryForm.MainLoadingBar.Value < vplloadingbar Then
                                PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                            End If
                            'If globalpickliststatus = "Cancelled" Then
                            '    MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            '    Exit Try
                            'ElseIf globalpickliststatus = "Completed" Then
                            '    MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            '    Exit Try
                            'End If
                            ' getPickListOrderStatusA(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgPickListItems.CurrentRow.Cells("pli_rowid").Value))
                            If PrimaryForm.MainLoadingBar.Value < vplloadingbar Then
                                PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                            End If
                            'If vplpicklistorderstatus = 0 Then
                            '    displayPickListItemsB(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgPickListItems.CurrentRow.Cells("pli_rowid").Value))
                            '    If IsNumeric(dgPickListItems.CurrentRow.Cells("pli_qtypicked").Value) Then
                            '        If CInt(dgPickListItems.CurrentRow.Cells("pli_qtypicked").Value) <> vplqtypickedsum Then
                            '            MessageBox.Show("This pick list item has been updated by other user, please click refresh button to check the new status of this pick list item.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            '            Exit Try
                            '        End If
                            '    Else
                            '        MessageBox.Show("This pick list items has been updated by other user, please click refresh button to check the new status of this pick list item.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            '        Exit Try
                            '    End If
                            'Else
                            '    MessageBox.Show("This pick list item has been verified already.", "Verifying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            '    Exit Try
                            'End If
                            If myModule.systemerrorfound = False Then
                                verifyPickListItemsA(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), CInt(dgPickListItems.CurrentRow.Cells("pli_rowid").Value))
                                If PrimaryForm.MainLoadingBar.Value < vplloadingbar Then
                                    PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                                End If
                            End If
                            If myModule.systemerrorfound = False Then
                                getPickListOrderStatusB(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
                                If vplpicklistorderstatus = 0 Then
                                    U_PickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Completed", Me)
                                    U_PickListCompletedDate(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Date.Now.ToString("yyyy/MM/dd"), Me)
                                Else
                                    U_PickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Partially Verified", Me)
                                End If
                                If PrimaryForm.MainLoadingBar.Value < vplloadingbar Then
                                    PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                                End If
                            End If
                            If myModule.systemerrorfound = False Then
                                verifypicklist()
                                '    MessageBox.Show("Successfully Verified.", "Verified", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                '    clickpicklist()
                            End If
                        End If
                    Else
                        errProvider.SetError(txtPickListNo, "System cannot find the Pick List to be updated.")
                        Exit Try
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
            PrimaryForm.MainLoadingBar.Visible = fraud
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msPrint_Click(sender As Object, e As EventArgs) Handles msPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            cmsOptions.Show(Cursor.Position)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ButtonVerifyAll_Click(sender As Object, e As EventArgs) Handles ButtonVerifyAll.Click
        Dim rows = dgPickListItems.Rows?.OfType(Of DataGridViewRow)
        _IsVerifyAll = If(rows?.Any(), False)

        If Not _IsVerifyAll Then Return

        For Each r In rows
            dgPickListItems.CurrentCell = dgPickListItems.Item(columnIndex:=pli_verify.Index, rowIndex:=r.Index)
            dgPickListItems_CellContentClick(sender:=dgPickListItems, e:=New DataGridViewCellEventArgs(columnIndex:=pli_verify.Index, rowIndex:=r.Index))
        Next

        _IsVerifyAll = False
    End Sub

    Private Sub cmsOutright_Click(sender As Object, e As EventArgs) Handles cmsOutright.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Move From Picking To Packing", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.VPLForm = False
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalcreateflg = "Y" AndAlso Not IsThurston Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If dgPickList.Rows.Count <> 0 Then
                getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                If globalpickliststatus <> txtStatus.Text Then
                    MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalpickliststatus <> "Cancelled" Then
                    If MessageBox.Show("Would you like to print this pick list in Outright Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                        If globalpickliststatus = "Cancelled" Then
                            MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                        If myModule.systemerrorfound = False Then
                            'getUserName(Z_UserID, Me)
                            printVerifyPickListA(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
                            Dim printreport As New VerifyPickListPrint
                            Dim openreportviewer As New ReportViewer
                            openreportviewer.CrystalReportViewer.ReportSource = printreport
                            printdatatable = printdataset
                            printreport.SetDataSource(printdatatable)
                            openreportviewer.Show()
                            printdatatable.Dispose()
                            printdatatable = Nothing
                            printdataset.Clear()
                        End If
                    End If
                End If
            Else
                errProvider.SetError(txtPickListNo, "System cannot find the Pick List to be printed.")
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmsConsignor_Click(sender As Object, e As EventArgs) Handles cmsConsignor.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Move From Picking To Packing", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.VPLForm = False
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalcreateflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If dgPickList.Rows.Count <> 0 Then
                getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                If globalpickliststatus <> txtStatus.Text Then
                    MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalpickliststatus <> "Cancelled" Then
                    If MessageBox.Show("Would you like to print this pick list in Consignor Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                        If globalpickliststatus = "Cancelled" Then
                            MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                        If myModule.systemerrorfound = False Then
                            'getUserName(Z_UserID, Me)
                            printVerifyPickListB(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
                            Dim printreport As New VerifyPickListPrintB
                            Dim openreportviewer As New ReportViewer
                            openreportviewer.CrystalReportViewer.ReportSource = printreport
                            printdatatable = printdataset
                            printreport.SetDataSource(printdatatable)
                            openreportviewer.Show()
                            printdatatable.Dispose()
                            printdatatable = Nothing
                            printdataset.Clear()
                        End If
                    End If
                End If
            Else
                errProvider.SetError(txtPickListNo, "System cannot find the Pick List to be printed.")
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmsSKU_Click(sender As Object, e As EventArgs) Handles cmsSKU.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Move From Picking To Packing", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.VPLForm = False
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalcreateflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If dgPickList.Rows.Count <> 0 Then
                getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                If globalpickliststatus <> txtStatus.Text Then
                    MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalpickliststatus <> "Cancelled" Then
                    If MessageBox.Show("Would you like to print this pick list in SKU Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        getPickListStatus(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value), Me)
                        If globalpickliststatus = "Cancelled" Then
                            MessageBox.Show("This pick list has been updated by other user, please click refresh button to check the new status of this pick list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                        If myModule.systemerrorfound = False Then
                            'getUserName(Z_UserID, Me)
                            printVerifyPickListC(CInt(dgPickList.CurrentRow.Cells("pl_rowid").Value))
                            Dim printreport As New SKUTagPrint
                            Dim openreportviewer As New ReportViewer
                            openreportviewer.CrystalReportViewer.ReportSource = printreport
                            printdatatable = printdatasetsku
                            printreport.SetDataSource(printdatatable)
                            openreportviewer.Show()
                            printdatatable.Dispose()
                            printdatatable = Nothing
                            printdatasetsku.Clear()
                        End If
                    End If
                End If
            Else
                errProvider.SetError(txtPickListNo, "System cannot find the Pick List to be printed.")
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
        Dim fsdfsd = pli_verify.Name
    End Sub

#Region "Search/Page Setup"

    Private Sub txtSimpleSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSimpleSearch.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If txtSimpleSearch.Text = "" Then
                    tsrefreshperformclick()
                Else
                    clearRightPage()
                    searchmode = "SimpleSearch"
                    simplesearchphrase = txtSimpleSearch.Text
                    spagenum = neutralpage : numofpages = startingpage
                    displaySearchPhrase(simplesearchphrase, spagenum)
                    colorCoding() : pageSetup1(simplesearchphrase)
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
                displayPickList(spagenum)
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
                displayPickList(spagenum)
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
                displayPickList(spagenum)
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
                displayPickList(spagenum)
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
                            displayPickList(spagenum)
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

    Private Sub dgPickListItems_MouseUp(sender As Object, e As MouseEventArgs) Handles dgPickListItems.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgPickListItems.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgPickListItems.BeginEdit(True)
                Else
                    dgPickListItems.EndEdit()
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

    Private Sub dgPickList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgPickList.DataError
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
                dgPickList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgPickListItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgPickListItems.DataError
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
                dgPickListItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

    Private ReadOnly Property IsVerifyAll As Boolean

    Private ReadOnly Property IsThurston As Boolean
        Get
            Return _systemOwner.IsThurston
        End Get
    End Property

End Class