Imports MySql.Data.MySqlClient
Imports Spire.Barcode
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Desktop.Utilities

Public Class PackingListForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim printdataset As New DataSetA.SetADataTable
    Dim printdatatable As New DataTable
    Dim sqlTran As MySqlTransaction
    Dim sqlquery As String
    Dim imagedata() As Byte
    Dim cue, searchmode As String
    Dim itemno, rowscount As Integer
    Dim palqtytopackerrorcue As Boolean
    Dim spagenum, countpagenum, numofpages, validpages As Integer
    Dim pageequation1, pageequation2, pageequation3, additionalpage, paltotalpricesum As Decimal
    Dim palcustomerid, palcontactid, palorderid, palpackinglistid, palcountpackinglistboxes As Integer
    Dim simplesearchphrase, datephrase, commonphrase, pagefilter1, pagefilter2, palstartidentifier, palendindentifier, palmothersku, palprintsku, palorderitemstatus As String
    Dim paltotalqtyincarton, palqtyincartonsum, paltotalqtypickedsum, paltotalqtyincartonsum, palqtyincarton, palqtytopacksum, paltotalqtypicked, palqtypicked, palqtyordered As Integer
    Private _systemOwner As SystemOwner

    Private Async Sub PackingListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        If IsThurston Then
            ci_totalqtyincarton.HeaderText = "Total Qty. In Truck"
            Label3.Text = $"Total Qty. {ChrW(13)}{ChrW(13)}In Truck (Sum):"
            Label5.Text = "Qty. In Truck (Sum):"
            cai_qtyincarton.HeaderText = "Qty. In Truck"
            Label1.Text = "Truck Items:"
            ca_cartonno.HeaderText = "Truck No."
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            Spire.Barcode.BarcodeSettings.ApplyKey("LNAVJZFGXY6-NWBQG-FGB9V-34L5T")
            errProvider.Clear()
            clearfields()
            callAutoPopulateFunctions()
            displayPackingList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default


        If IsThurston Then
            For Each comboBox In gbPackingListInformation.Controls.
                OfType(Of Control).
                OfType(Of ComboBox).
                ToArray()

                SetStyleToDropDownList(comboBox)
            Next
        End If
    End Sub

    Private Sub PackingListForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Sub callAutoPopulateFunctions()
        autopopulatecboSearch()
    End Sub

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            cue = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearPackingListInformation()
            clearCustomerOrderItems()
            clearCartonItems()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visibleCustomerOrderItems(fraud)
            enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRightPage()
        Try
            cue = ""
            clearPackingListInformation()
            clearCustomerOrderItems()
            clearCartonItems()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visibleCustomerOrderItems(fraud)
            enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
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
            cboSearch2.Text = ""
            cboDate.SelectedItem = Nothing
            cboSearch1.SelectedItem = Nothing
            cboSearch2.SelectedItem = Nothing
            dtpFromSearch.Value = Now.Date.AddDays(-(Now.Day) + 1)
            dtpToSearch.Value = Now.Date
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearcboSearch()
        Try
            txtPage.Text = ""
            cboDate.SelectedItem = Nothing
            cboSearch1.SelectedItem = Nothing
            cboSearch2.Items.Clear() : cboSearch2.AutoCompleteCustomSource.Clear()
            cboSearch2.Text = "" : cboSearch2.SelectedItem = Nothing
            dtpFromSearch.Value = Now.Date.AddDays(-(Now.Day) + 1)
            dtpToSearch.Value = Now.Date
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearPackingListInformation()
        Try
            txtPackingListNo.Text = ""
            txtPackingListDate.Text = ""
            txtStatus.Text = ""
            txtComments.Text = ""
            cboCustomerOrderInfo.Text = ""
            txtPONo.Text = ""
            txtCustomerOrderDate.Text = ""
            txtTargetDeliveryDate.Text = ""
            txtCancelDate.Text = ""
            txtClassDescription.Text = ""
            txtSIDRNo.Text = ""
            txtBranchCodeNameInfo.Text = ""
            txtVendorCodeNameInfo.Text = ""
            txtTotalPrice.Text = ""
            cboCustomerOrderInfo.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearCustomerOrderItems()
        Try
            txtTotalItems.Text = ""
            txtTotalQtyPicked.Text = ""
            txtTotalQtyInCartonSum.Text = ""
            txtTotalPrice.Text = ""
            chkOtherInfo.Checked = fraud
            lnkViewEditBundleItems.Visible = fraud
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearCartonItems()
        Try
            txtQtyInCartonSum.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearDatagrids()
        Try
            dgCustomerOrderItems.Rows.Clear()
            dgCartons.Rows.Clear()
            dgCartonItems.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbPackingList.Enabled = enable1
            gbPackingListInformation.Enabled = enable2
            gbCustomerOrderItems.Enabled = enable3
            gbCartons.Enabled = enable3
            gbCartonItems.Enabled = enable3
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub visibleCustomerOrderItems(ByVal visible1 As Boolean)
        Try
            ci_qtyordered.Visible = visible1
            ci_srp.Visible = visible1
            ci_totalprice.Visible = visible1
            ci_unitofmeasure.Visible = visible1
            ci_type.Visible = visible1
            ci_remarks.Visible = visible1
            ci_packedby.Visible = visible1
            ci_packeddate.Visible = visible1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableANDvisibleMS(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean, ByVal visible1 As Boolean, ByVal visible2 As Boolean)
        Try
            msNew.Enabled = enable1
            msSave.Enabled = enable2
            msPrint.Enabled = enable3
            msCancel.Visible = visible1
            msOrder.Visible = visible2
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
            callAutoPopulateFunctions()
            displayPackingList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Computations"

    Sub getPickListOrderIDA(ByVal iorderid As Integer, ByVal iorderitemid As Integer)
        Try
            paltotalqtypicked = 0
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(plo.rowid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.orderitemid = " & iorderitemid & " AND plo.orderid = " & iorderid & " AND (plo.`status` != 'Inactive' AND plo.`status` != 'Cancelled') ")
            If dtGid.Rows.Count <> 0 Then
                getTotalQtyPickedA(CInt(dtGid.Rows(0)(0)))
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getPickListOrderIDB(ByVal eorderid As Integer)
        Try
            paltotalqtypickedsum = 0
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(plo.rowid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.orderid = " & eorderid & " AND (plo.`status` != 'Inactive' AND plo.`status` != 'Cancelled') "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getTotalQtyPickedB(CInt(reader1(0)))
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getTotalQtyPickedA(ByVal ipicklistorderid As Integer)
        Try
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pli.qtypicked),0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND (pli.`status` != 'Inactive' AND pli.`status` != 'Cancelled') ")
            If dtGtq.Rows.Count <> 0 Then
                paltotalqtypicked = dtGtq.Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getTotalQtyPickedB(ByVal ipicklistorderid As Integer)
        Try
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pli.qtypicked),0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND (pli.`status` != 'Inactive' AND pli.`status` != 'Cancelled') ")
            If dtGtq.Rows.Count <> 0 Then
                paltotalqtypickedsum = paltotalqtypickedsum + dtGtq.Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getTotalQtyInCarton(ByVal epackinglistid As Integer, ByVal eorderitemid As Integer)
        Try
            paltotalqtyincarton = 0
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pci.qtyincarton),0) FROM packinglistcartonitems pci LEFT JOIN packinglistcartons pc ON pci.packinglistcartonid = pc.rowid WHERE pc.packinglistid = " & epackinglistid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' AND pci.orderitemid = " & eorderitemid & " ")
            If dtGtq.Rows.Count <> 0 Then
                paltotalqtyincarton = dtGtq.Rows(0)(0)
            Else
                paltotalqtyincarton = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getPackingListCartonID(ByVal epackinglistid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pc.rowid FROM packinglistcartons pc WHERE pc.organizationid = " & Z_OrganizationID & " AND pc.packinglistid = " & epackinglistid & " AND pc.status != 'Inactive' "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getQtyInCarton(CInt(reader1(0)))
                    paltotalqtyincartonsum = paltotalqtyincartonsum + palqtyincarton
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getQtyInCarton(ByVal ipackinglistcartonid As Integer)
        Try
            palqtyincarton = 0
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pci.qtyincarton),0) FROM packinglistcartonitems pci WHERE pci.packinglistcartonid = " & ipackinglistcartonid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' ")
            If dtGtq.Rows.Count <> 0 Then
                palqtyincarton = dtGtq.Rows(0)(0)
            Else
                palqtyincarton = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub packinglistcomputations(ByVal iorderid As Integer, ByVal ipackinglistid As Integer)
        Try
            palqtyincartonsum = 0 : paltotalqtyincartonsum = 0 : palqtytopacksum = 0
            palqtypicked = 0 : paltotalpricesum = 0.0 : palqtytopackerrorcue = fraud
            getPickListOrderIDB(iorderid)
            getPackingListCartonID(ipackinglistid)
            If dgCartonItems.Rows.Count <> 0 Then
                For i = 0 To dgCartonItems.Rows.Count - 1
                    If IsNumeric(dgCartonItems.Rows(i).Cells("cai_qtyincarton").Value) Then
                        palqtyincartonsum = palqtyincartonsum + CInt(dgCartonItems.Rows(i).Cells("cai_qtyincarton").Value)
                    End If
                Next
            End If
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value) Then
                        palqtypicked = CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value)
                    Else
                        palqtypicked = 0
                    End If
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtyordered").Value) Then
                        palqtyordered = CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtyordered").Value)
                    Else
                        palqtyordered = 0
                    End If
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_srp").Value) Then
                        If CStr(dgCustomerOrderItems.Rows(i).Cells("ci_type").Value) = "B" Then
                            dgCustomerOrderItems.Rows(i).Cells("ci_totalprice").Value = Math.Round(palqtyordered * CDec(dgCustomerOrderItems.Rows(i).Cells("ci_srp").Value), 2)
                        ElseIf CStr(dgCustomerOrderItems.Rows(i).Cells("ci_type").Value) = "S" Then
                            dgCustomerOrderItems.Rows(i).Cells("ci_totalprice").Value = Math.Round(palqtypicked * CDec(dgCustomerOrderItems.Rows(i).Cells("ci_srp").Value), 2)
                        End If
                    Else
                        dgCustomerOrderItems.Rows(i).Cells("ci_totalprice").Value = 0.0
                    End If
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_totalprice").Value) Then
                        paltotalpricesum = paltotalpricesum + CDec(dgCustomerOrderItems.Rows(i).Cells("ci_totalprice").Value)
                    End If
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value) Then
                        palqtytopacksum = palqtytopacksum + CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value)
                        If If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value), 0) < If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), 0) + CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value) Then
                            palqtytopackerrorcue = legit
                            dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").ErrorText = "Qty. Picked is less than Total Qty. In Carton plus(+) Qty. To Pack."
                        Else
                            dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").ErrorText = Nothing
                        End If
                    Else
                        dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").ErrorText = Nothing
                    End If
                Next
            End If
            txtTotalItems.Text = dgCustomerOrderItems.Rows.Count
            txtTotalQtyPicked.Text = Format(paltotalqtypickedsum, "#,##0")
            txtTotalQtyInCartonSum.Text = Format(paltotalqtyincartonsum + palqtytopacksum, "#,##0")
            txtQtyInCartonSum.Text = Format(palqtyincartonsum, "#,##0")
            txtTotalPrice.Text = Format(paltotalpricesum, "#,##0.00")
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
            dtCid = getDataTableForSQL("SELECT COUNT(pal.rowid) FROM packinglist pal WHERE pal.organizationid = " & Z_OrganizationID & " ")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(pal.rowid),0) FROM packinglist pal LEFT JOIN orders co ON pal.orderid = co.rowid LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE pal.organizationid = " & Z_OrganizationID & " AND " &
                            "(pal.packinglistno LIKE ""%" & esearchstring & "%"" OR pal.status LIKE ""%" & esearchstring & "%"" OR co.ordernumber LIKE ""%" & esearchstring & "%"" OR cu.companyname LIKE ""%" & esearchstring & "%"") ")
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

    Sub pageSetup2(ByVal idatesearch As String)
        Try
            getCountPageNum2(idatesearch)
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

    Sub getCountPageNum2(ByVal edatesearch As String)
        Try
            countpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(pal.rowid),0) FROM packinglist pal LEFT JOIN orders co ON pal.orderid = co.rowid WHERE pal.organizationid = " & Z_OrganizationID & " AND " &
                            "(" & edatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' " &
                            "AND " & edatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) ")
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

    Sub pageSetup3(ByVal icommonstring As String, ByVal idatesearch As String)
        Try
            getCountPageNum3(icommonstring, idatesearch)
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

    Sub getCountPageNum3(ByVal ecommonstring As String, ByVal edatesearch As String)
        Try
            countpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(pal.rowid),0) FROM packinglist pal LEFT JOIN orders co ON pal.orderid = co.rowid LEFT JOIN accounts cu ON co.accountid = cu.rowid LEFT JOIN packinglistcartons pc ON pal.rowid = pc.packinglistid WHERE pal.organizationid = " & Z_OrganizationID & " AND " & ecommonstring & " " & edatesearch & " ")
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

    Sub getCommonPhrase(ByVal icommonbox As ComboBox, ByVal icommonstring As String)
        Try
            commonphrase = ""
            If icommonbox.Text = "CartonNo" Then
                commonphrase = "pc.cartonno = """ & icommonstring & """"
            ElseIf icommonbox.Text = "CustomerName" Then
                getCustomerID(icommonstring, Me)
                palcustomerid = globalcustomerid
                commonphrase = "co.accountid =  " & palcustomerid & ""
            ElseIf icommonbox.Text = "PackerName" Then
                getContactID(icommonstring, "Packer", Me)
                palcontactid = globalcontactid
                commonphrase = "pc.contactid = " & palcontactid & ""
            ElseIf icommonbox.Text = "Status" Then
                commonphrase = "pal.status = """ & icommonstring & """"
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

    Sub autocompleteCartonNos(ByVal icombobox As ComboBox)
        Try
            Dim cartonnos As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(pc.cartonno,'') AS 'cartonnos' FROM packinglist pal LEFT JOIN packinglistcartons pc ON pal.rowid = pc.packinglistid WHERE pal.organizationid = " & Z_OrganizationID & " GROUP BY pc.cartonno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                cartonnos.Add(ds.Tables(0).Rows(i)("cartonnos").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = cartonnos
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteCustomerName(ByVal icombobox As ComboBox)
        Try
            Dim customername As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'') AS 'customername' FROM packinglist pal " &
                            "LEFT JOIN orders co ON pal.orderid = co.rowid LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE pal.organizationid = " & Z_OrganizationID & " GROUP BY cu.rowid ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                customername.Add(ds.Tables(0).Rows(i)("customername").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = customername
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompletePackerName(ByVal icombobox As ComboBox)
        Try
            Dim contactname As New AutoCompleteStringCollection
            Dim cmd1 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'') AS 'firstname' FROM packinglist pal LEFT JOIN packinglistcartons pc ON pal.rowid = pc.packinglistid LEFT JOIN contacts c ON pc.contactid = c.rowid WHERE pal.organizationid = " & Z_OrganizationID & " GROUP BY c.rowid ", globalconn)
            Dim cmd2 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(c.lastname,''),', ',COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'') AS 'lastname' FROM packinglist pal LEFT JOIN packinglistcartons pc ON pal.rowid = pc.packinglistid LEFT JOIN contacts c ON pc.contactid = c.rowid WHERE pal.organizationid = " & Z_OrganizationID & " GROUP BY c.rowid ", globalconn)
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
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = contactname
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub autocompleteStatus(ByVal icombobox As ComboBox)
        Try
            Dim palstatus As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(pal.status,'') AS 'palstatus' FROM packinglist pal WHERE pal.organizationid = " & Z_OrganizationID & " GROUP BY pal.status ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                palstatus.Add(ds.Tables(0).Rows(i)("palstatus").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = palstatus
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "AutoPopulate"

    Sub autopopulatecboSearch()
        Try
            cboDate.Items.Clear()
            cboDate.Items.Add("PackingDate")
            cboDate.Items.Add("TargetDate")
            cboDate.Items.Add("")
            cboSearch1.Items.Clear()
            cboSearch1.Items.Add("CartonNo")
            cboSearch1.Items.Add("CustomerName")
            cboSearch1.Items.Add("PackerName")
            cboSearch1.Items.Add("Status")
            cboSearch1.Items.Add("")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autopopulateCartonNos(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(pc.cartonno,'') AS 'cartonnos' FROM packinglist pal LEFT JOIN packinglistcartons pc ON pal.rowid = pc.packinglistid WHERE pal.organizationid = " & Z_OrganizationID & " GROUP BY pc.cartonno ORDER BY pc.cartonno "
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

    Sub autopopulateCustomerName(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'') AS 'customername' FROM packinglist pal " &
                            "LEFT JOIN orders co ON pal.orderid = co.rowid LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE pal.organizationid = " & Z_OrganizationID & " GROUP BY cu.rowid ORDER BY cu.companyname "
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

    Sub autopopulatePackerName(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'') AS 'firstname' FROM packinglist pal LEFT JOIN packinglistcartons pc ON pal.rowid = pc.packinglistid LEFT JOIN contacts c ON pc.contactid = c.rowid WHERE pal.organizationid = " & Z_OrganizationID & " GROUP BY c.rowid ORDER BY c.firstname "
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

    Sub autopopulateStatus(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(pal.status,'') AS 'palstatus' FROM packinglist pal WHERE pal.organizationid = " & Z_OrganizationID & " GROUP BY pal.status ORDER BY pal.status "
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

    Sub displayPackingList(ByVal istartpage As Integer)
        Try
            dgPackingList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pal.rowid,COALESCE(pal.packinglistno,''),DATE_FORMAT(pal.packinglistdate,'%d-%b-%Y'),COALESCE(co.ordernumber,'')," &
                        "COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),''),COALESCE(pal.status,'') FROM packinglist pal " &
                        "LEFT JOIN orders co ON pal.orderid = co.rowid LEFT JOIN accounts cu ON co.accountid = cu.rowid " &
                        "WHERE pal.organizationid = " & Z_OrganizationID & " ORDER BY pal.packinglistdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPackingList.Rows.Add()
                    dgPackingList.Item(pal_rowid.Index, n).Value = reader1(0)
                    dgPackingList.Item(pal_packinglistno.Index, n).Value = reader1(1)
                    dgPackingList.Item(pal_packinglistdate.Index, n).Value = reader1(2)
                    dgPackingList.Item(pal_customerorderno.Index, n).Value = reader1(3)
                    dgPackingList.Item(pal_customername.Index, n).Value = reader1(4)
                    dgPackingList.Item(pal_status.Index, n).Value = reader1(5)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPackingList.Columns("pal_packinglistno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingList.Columns("pal_packinglistdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingList.Columns("pal_customerorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingList.Columns("pal_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPackingList.Rows.Count <> 0 Then
                dgPackingList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgPackingList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pal.rowid,COALESCE(pal.packinglistno,''),DATE_FORMAT(pal.packinglistdate,'%d-%b-%Y'),COALESCE(co.ordernumber,'')," &
                        "COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),''),COALESCE(pal.`status`,'') FROM packinglist pal " &
                        "LEFT JOIN orders co ON pal.orderid = co.rowid LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE pal.organizationid = " & Z_OrganizationID & " AND " &
                        "(pal.packinglistno LIKE ""%" & isearchphrase & "%"" OR pal.status LIKE ""%" & isearchphrase & "%"" OR co.ordernumber LIKE ""%" & isearchphrase & "%"" OR cu.companyname LIKE ""%" & isearchphrase & "%"") " &
                        "ORDER BY pal.packinglistdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPackingList.Rows.Add()
                    dgPackingList.Item(pal_rowid.Index, n).Value = reader1(0)
                    dgPackingList.Item(pal_packinglistno.Index, n).Value = reader1(1)
                    dgPackingList.Item(pal_packinglistdate.Index, n).Value = reader1(2)
                    dgPackingList.Item(pal_customerorderno.Index, n).Value = reader1(3)
                    dgPackingList.Item(pal_customername.Index, n).Value = reader1(4)
                    dgPackingList.Item(pal_status.Index, n).Value = reader1(5)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPackingList.Columns("pal_packinglistno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingList.Columns("pal_packinglistdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingList.Columns("pal_customerorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingList.Columns("pal_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPackingList.Rows.Count <> 0 Then
                dgPackingList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayDateSearch(ByVal istartpage As Integer, ByVal idatesearch As String)
        Try
            dgPackingList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pal.rowid,COALESCE(pal.packinglistno,''),DATE_FORMAT(pal.packinglistdate,'%d-%b-%Y'),COALESCE(co.ordernumber,'')," &
                        "COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),''),COALESCE(pal.status,'') FROM packinglist pal " &
                        "LEFT JOIN orders co ON pal.orderid = co.rowid LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE pal.organizationid = " & Z_OrganizationID & " " &
                        "AND (" & idatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                        "" & idatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) " &
                        "GROUP BY pal.rowid  ORDER BY pal.packinglistdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPackingList.Rows.Add()
                    dgPackingList.Item(pal_rowid.Index, n).Value = reader1(0)
                    dgPackingList.Item(pal_packinglistno.Index, n).Value = reader1(1)
                    dgPackingList.Item(pal_packinglistdate.Index, n).Value = reader1(2)
                    dgPackingList.Item(pal_customerorderno.Index, n).Value = reader1(3)
                    dgPackingList.Item(pal_customername.Index, n).Value = reader1(4)
                    dgPackingList.Item(pal_status.Index, n).Value = reader1(5)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPackingList.Columns("pal_packinglistno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingList.Columns("pal_packinglistdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingList.Columns("pal_customerorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingList.Columns("pal_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPackingList.Rows.Count <> 0 Then
                dgPackingList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCommonPhrase(ByVal icommonphrase As String, ByVal idatesearch As String, ByVal istartpage As Integer)
        Try
            dgPackingList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pal.rowid,COALESCE(pal.packinglistno,''),DATE_FORMAT(pal.packinglistdate,'%d-%b-%Y'),COALESCE(co.ordernumber,'')," &
                        "COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),''),COALESCE(pal.status,'') FROM packinglist pal " &
                        "LEFT JOIN orders co ON pal.orderid = co.rowid LEFT JOIN accounts cu ON co.accountid = cu.rowid LEFT JOIN packinglistcartons pc ON pal.rowid = pc.packinglistid " &
                        "WHERE pal.organizationid = " & Z_OrganizationID & " AND " & icommonphrase & " " & idatesearch & " GROUP BY pal.rowid ORDER BY pal.packinglistdate DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPackingList.Rows.Add()
                    dgPackingList.Item(pal_rowid.Index, n).Value = reader1(0)
                    dgPackingList.Item(pal_packinglistno.Index, n).Value = reader1(1)
                    dgPackingList.Item(pal_packinglistdate.Index, n).Value = reader1(2)
                    dgPackingList.Item(pal_customerorderno.Index, n).Value = reader1(3)
                    dgPackingList.Item(pal_customername.Index, n).Value = reader1(4)
                    dgPackingList.Item(pal_status.Index, n).Value = reader1(5)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPackingList.Columns("pal_packinglistno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingList.Columns("pal_packinglistdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingList.Columns("pal_customerorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackingList.Columns("pal_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPackingList.Rows.Count <> 0 Then
                dgPackingList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCustomerOrderItems(ByVal icustomerorderid As Integer, ByVal ipackinglistid As Integer)
        Try
            dgCustomerOrderItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ci.rowid,COALESCE(ci.productcolorsizeid,0),COALESCE(ci.productbundleid,0),COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(b.bundlename,''),COALESCE(c.colorname,''),COALESCE(pcs.size,'')," &
                    "COALESCE(pcs.seasoncode,''),COALESCE(ci.qtyordered,0),COALESCE(pcs.sku,''),COALESCE(b.sku,''),COALESCE(ci.unitofmeasure,''),COALESCE(ci.itemtype,''),COALESCE(ci.remarks,''),COALESCE(ci.`status`,''),COALESCE(DATE_FORMAT(ci.packeddate,'%d-%b-%Y'),'')," &
                    "COALESCE(CONCAT(COALESCE(pa.firstname,''),' ',COALESCE(pa.middlename,''),' ',COALESCE(pa.lastname,''),' ',COALESCE(pa.suffix,''),' - ',COALESCE(pa.contactno,'')),''),COALESCE(ci.srp,''),COALESCE(ci.tags,''),COALESCE(ci.sku,'') FROM orderitems ci LEFT JOIN productbundles b ON ci.productbundleid = b.rowid " &
                    "LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN contacts pa ON ci.packedby = pa.rowid " &
                    "WHERE ci.orderid = " & icustomerorderid & " AND ci.organizationid = " & Z_OrganizationID & " AND ci.status != 'Inactive' AND ci.itemtype != 'BI' ORDER BY ci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgCustomerOrderItems.Rows.Add()
                    dgCustomerOrderItems.Item(ci_seqno.Index, n).Value = seqno
                    dgCustomerOrderItems.Item(ci_rowid.Index, n).Value = reader1(0)
                    dgCustomerOrderItems.Item(ci_pcsrowid.Index, n).Value = reader1(1)
                    dgCustomerOrderItems.Item(ci_bid.Index, n).Value = reader1(2)
                    dgCustomerOrderItems.Item(ci_colorvalue.Index, n).Value = reader1(3)
                    If CInt(reader1(1)) <> 0 Then
                        dgCustomerOrderItems.Item(ci_itemcode.Index, n).Value = reader1(4)
                    Else
                        dgCustomerOrderItems.Item(ci_itemcode.Index, n).Value = reader1(5)
                    End If
                    dgCustomerOrderItems.Item(ci_colorname.Index, n).Value = reader1(6)
                    dgCustomerOrderItems.Item(ci_color.Index, n).Value = ""
                    dgCustomerOrderItems.Item(ci_size.Index, n).Value = reader1(7)
                    dgCustomerOrderItems.Item(ci_seasoncode.Index, n).Value = reader1(8)
                    dgCustomerOrderItems.Item(ci_qtyordered.Index, n).Value = reader1(9)
                    getTotalQtyInCarton(ipackinglistid, CInt(reader1(0)))
                    getPickListOrderIDA(icustomerorderid, CInt(reader1(0)))
                    If CInt(reader1(1)) <> 0 Then
                        dgCustomerOrderItems.Item(ci_totalqtyincarton.Index, n).Value = paltotalqtyincarton
                        dgCustomerOrderItems.Item(ci_qtypicked.Index, n).Value = paltotalqtypicked
                    Else
                        dgCustomerOrderItems.Item(ci_totalqtyincarton.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_qtypicked.Index, n).Value = ""
                    End If
                    dgCustomerOrderItems.Item(ci_qtytopack.Index, n).Value = ""
                    If CInt(reader1(1)) <> 0 Then
                        If LTrim(CStr(reader1(20))) = "" Then
                            dgCustomerOrderItems.Item(ci_sku.Index, n).Value = reader1(10)
                        Else
                            dgCustomerOrderItems.Item(ci_sku.Index, n).Value = reader1(20)
                        End If
                    Else
                        dgCustomerOrderItems.Item(ci_sku.Index, n).Value = reader1(11)
                    End If
                    dgCustomerOrderItems.Item(ci_unitofmeasure.Index, n).Value = reader1(12)
                    dgCustomerOrderItems.Item(ci_type.Index, n).Value = reader1(13)
                    dgCustomerOrderItems.Item(ci_remarks.Index, n).Value = reader1(14)
                    If CInt(reader1(1)) <> 0 Then
                        dgCustomerOrderItems.Item(ci_status.Index, n).Value = reader1(15)
                        dgCustomerOrderItems.Item(ci_packeddate.Index, n).Value = reader1(16)
                        dgCustomerOrderItems.Item(ci_packedby.Index, n).Value = reader1(17)
                    Else
                        dgCustomerOrderItems.Item(ci_status.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_packedby.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_packeddate.Index, n).Value = ""
                    End If
                    dgCustomerOrderItems.Item(ci_srp.Index, n).Value = reader1(18)
                    dgCustomerOrderItems.Item(ci_tags.Index, n).Value = reader1(19)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCustomerOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_itemcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtypicked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_totalqtyincarton").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtytopack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_tags").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                dgCustomerOrderItems.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayPackingListInformation(ByVal ipackinglistid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(pal.packinglistno,''),COALESCE(DATE_FORMAT(pal.packinglistdate,'%d-%b-%Y'),''),COALESCE(pal.`status`,''),COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ',COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'')," &
                        "COALESCE(pal.comments,'') FROM packinglist pal LEFT JOIN orders o ON pal.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid WHERE pal.rowid = " & ipackinglistid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtPackingListNo.Text = reader1(0)
                    txtPackingListDate.Text = reader1(1)
                    txtStatus.Text = reader1(2)
                    cboCustomerOrderInfo.Text = reader1(3)
                    txtComments.Text = reader1(4)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayPackingListCartons(ByVal ipackinglistid As Integer)
        Try
            dgCartons.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pc.rowid,COALESCE(pc.cartonno,''),COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),''),COALESCE(DATE_FORMAT(pc.packeddate,'%d-%b-%Y'),''),COALESCE(pc.`status`,''),COALESCE(cs.sizename,''),COALESCE(pc.amount,'')," &
                        "COALESCE(CONCAT(COALESCE(pc.weight,''),' ',COALESCE(pc.weightuom,'')),'') FROM packinglistcartons pc LEFT JOIN contacts c ON pc.contactid = c.rowid LEFT JOIN cartonsizes cs ON pc.cartonsizeid = cs.rowid WHERE pc.packinglistid = " & ipackinglistid & " AND pc.organizationid = " & Z_OrganizationID & " AND pc.`status` != 'Inactive' ORDER BY pc.cartonno "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgCartons.Rows.Add()
                    dgCartons.Item(ca_seqno.Index, n).Value = seqno
                    dgCartons.Item(ca_rowid.Index, n).Value = reader1(0)
                    dgCartons.Item(ca_cartonno.Index, n).Value = reader1(1)
                    dgCartons.Item(ca_packername.Index, n).Value = reader1(2)
                    dgCartons.Item(ca_packeddate.Index, n).Value = reader1(3)
                    dgCartons.Item(ca_status.Index, n).Value = reader1(4)
                    dgCartons.Item(ca_size.Index, n).Value = reader1(5)
                    dgCartons.Item(ca_amount.Index, n).Value = reader1(6)
                    dgCartons.Item(ca_weight.Index, n).Value = reader1(7)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCartons.Columns("ca_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_cartonno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_weight").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCartons.Rows.Count <> 0 Then
                dgCartons.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayPackingListCartonItems(ByVal ipackinglistcartonid As Integer)
        Try
            dgCartonItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pci.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pci.qtyincarton,0),COALESCE(pcs.sku,''),COALESCE(oi.unitofmeasure,''),COALESCE(oi.itemtype,''),COALESCE(oi.sku,'') " &
                    "FROM packinglistcartonitems pci LEFT JOIN orderitems oi ON pci.orderitemid = oi.rowid LEFT JOIN productcolorsizes pcs ON oi.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid " &
                    "LEFT JOIN products p ON pc.productid = p.rowid WHERE pci.packinglistcartonid = " & ipackinglistcartonid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' ORDER BY p.productcode,c.colorname,pcs.size "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgCartonItems.Rows.Add()
                    dgCartonItems.Item(cai_seqno.Index, n).Value = seqno
                    dgCartonItems.Item(cai_rowid.Index, n).Value = reader1(0)
                    dgCartonItems.Item(cai_colorvalue.Index, n).Value = reader1(1)
                    dgCartonItems.Item(cai_productcode.Index, n).Value = reader1(2)
                    dgCartonItems.Item(cai_colorname.Index, n).Value = reader1(3)
                    dgCartonItems.Item(cai_color.Index, n).Value = ""
                    dgCartonItems.Item(cai_size.Index, n).Value = reader1(4)
                    dgCartonItems.Item(cai_seasoncode.Index, n).Value = reader1(5)
                    dgCartonItems.Item(cai_qtyincarton.Index, n).Value = reader1(6)
                    If LTrim(CStr(reader1(10))) = "" Then
                        dgCartonItems.Item(cai_sku.Index, n).Value = reader1(7)
                    Else
                        dgCartonItems.Item(cai_sku.Index, n).Value = reader1(10)
                    End If
                    dgCartonItems.Item(cai_unitofmeasure.Index, n).Value = reader1(8)
                    dgCartonItems.Item(cai_type.Index, n).Value = reader1(9)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCartonItems.Columns("cai_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_qtyincarton").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCartonItems.Rows.Count <> 0 Then
                dgCartonItems.CurrentRow.Selected = False
            End If
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
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgCustomerOrderItems.Rows.Count - 1
                    If dgCustomerOrderItems.Rows(i).Cells(ci_type.Index).Value = "B" Then
                        dgCustomerOrderItems.Rows(i).DefaultCellStyle.BackColor = Drawing.Color.PaleGreen
                    Else
                        If CStr(dgCustomerOrderItems.Rows(i).Cells("ci_colorvalue").Value) <> "" Then
                            readcolor = colorconverter.ConvertFromString(CStr(dgCustomerOrderItems.Rows(i).Cells("ci_colorvalue").Value))
                            dgCustomerOrderItems.Rows(i).Cells("ci_color").Style.BackColor = readcolor
                        End If
                    End If
                Next
            End If
            If dgCartonItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgCartonItems.Rows.Count - 1
                    If CStr(dgCartonItems.Rows(i).Cells("cai_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgCartonItems.Rows(i).Cells("cai_colorvalue").Value))
                        dgCartonItems.Rows(i).Cells("cai_color").Style.BackColor = readcolor
                    End If
                    If dgCartonItems.Rows(i).Cells(cai_type.Index).Value = "BI" Then
                        dgCartonItems.Rows(i).DefaultCellStyle.BackColor = Drawing.Color.PaleGreen
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

#Region "Printing"

    Sub countPackingListBoxes(ByVal ipackinglistid As Integer)
        Try
            palcountpackinglistboxes = 0
            Dim dtCpb As New DataTable
            dtCpb = getDataTableForSQL("SELECT COALESCE(COUNT(pc.rowid),0) FROM packinglistcartons pc WHERE pc.packinglistid = " & ipackinglistid & " AND pc.organizationid = " & Z_OrganizationID & " AND pc.`status` != 'Inactive' ")
            If dtCpb.Rows.Count <> 0 Then
                palcountpackinglistboxes = dtCpb.Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getCodeIndentifiers()
        Try
            palstartidentifier = "" : palendindentifier = ""
            Dim dtCis As New DataTable
            dtCis = getDataTableForSQL("SELECT COALESCE(ci.startcode,''),COALESCE(ci.endcode,'') FROM codeindentifiers ci WHERE ci.organizationid = " & Z_OrganizationID & " AND ci.`status` = 'Active' ")
            If dtCis.Rows.Count <> 0 Then
                palstartidentifier = dtCis.Rows(0)(0)
                palendindentifier = dtCis.Rows(0)(1)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getMotherSKU(ByVal icustomerorderid As Integer, ByVal ipackinglistid As Integer)
        Try
            palmothersku = ""
            Dim dtMsku As New DataTable
            dtMsku = getDataTableForSQL("SELECT ci.rowid,COALESCE(b.bundlename,''),COALESCE(ci.qtyordered,0),COALESCE(b.sku,''),COALESCE(ci.srp,'') FROM orderitems ci LEFT JOIN productbundles b ON ci.productbundleid = b.rowid " &
                    "WHERE ci.orderid = " & icustomerorderid & " AND ci.organizationid = " & Z_OrganizationID & " AND ci.status != 'Inactive' AND ci.itemtype != 'BI' ORDER BY ci.rowid ")
            If dtMsku.Rows.Count <> 0 Then
                palmothersku = dtMsku.Rows(0)(3)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub printPackingListA(ByVal ipackinglistid As Integer)
        Try
            rowscount = startingpage
            If conn.State = ConnectionState.Closed Then conn.Open()
            'Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(pc.rowid,''),'-',COALESCE(pal.rowid,'')),''),COALESCE(ve.companycode,''),COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),''),COALESCE(o.referencenumber,''),COALESCE(o.drnumber,''),COALESCE(c1.codename,'')," & _
            '            "COALESCE(CONCAT(COALESCE(cs.`length`,''),' ', COALESCE(cs.lengthuom,'')),''),COALESCE(CONCAT(COALESCE(cs.`width`,''),' ', COALESCE(cs.widthuom,'')),''),COALESCE(CONCAT(COALESCE(cs.`height`,''),' ',COALESCE(cs.heightuom,'')),''),COALESCE(CONCAT(COALESCE(pc.`weight`,''),' ',COALESCE(pc.weightuom,'')),'')," & _
            '            "COALESCE(CONCAT(COALESCE(o.referencenumber,''),',',COALESCE(o.drnumber,'')),'') AS '2DCodeA',COALESCE(pc.amount,0.0) AS '2DCodeB',COALESCE(bc.branchcode,''),COALESCE(cs.`length`,0.0),COALESCE(cs.`width`,0.0),COALESCE(cs.`height`,0.0),COALESCE(pc.`weight`,0.0) AS '2DCodeC' FROM packinglistcartons pc " & _
            '            "LEFT JOIN packinglist pal ON pc.packinglistid = pal.rowid LEFT JOIN orders o ON pal.orderid = o.rowid LEFT JOIN combinecodings cc ON o.combinecodingid = cc.rowid LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid " & _
            '            "LEFT JOIN branches bc ON o.branchid = bc.rowid LEFT JOIN companies ve ON o.companyid = ve.rowid LEFT JOIN cartonsizes cs ON pc.cartonsizeid = cs.rowid WHERE pc.packinglistid = " & ipackinglistid & " AND pc.organizationid = " & Z_OrganizationID & " AND pc.`status` != 'Inactive' ORDER BY pc.rowid "
            Dim sql1 As String = "SELECT pc.rowid,COALESCE(ve.companycode,''),COALESCE(bc.branchcode,''),COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ', COALESCE(bc.branchname,'')),''),COALESCE(o.referencenumber,''),COALESCE(o.drnumber,''),COALESCE(c1.codename,''),COALESCE(cs.`length`,0.00),COALESCE(cs.lengthuom,''),COALESCE(cs.`width`,0.00)," &
            "COALESCE(cs.widthuom,''),COALESCE(cs.`height`,0.00),COALESCE(cs.heightuom,''),COALESCE(pc.`weight`,0.00),COALESCE(pc.weightuom,'') FROM packinglistcartons pc LEFT JOIN packinglist pal ON pc.packinglistid = pal.rowid LEFT JOIN orders o ON pal.orderid = o.rowid LEFT JOIN companies ve ON o.companyid = ve.rowid " &
            "LEFT JOIN branches bc ON o.branchid = bc.rowid LEFT JOIN combinecodings cc ON o.combinecodingid = cc.rowid LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN cartonsizes cs ON pc.cartonsizeid = cs.rowid WHERE pc.packinglistid = " & ipackinglistid & " AND pc.organizationid = " & Z_OrganizationID & " AND pc.`status` != 'Inactive' ORDER BY pc.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    Spire.Barcode.BarcodeSettings.ApplyKey("LNAVJZFGXY6-NWBQG-FGB9V-34L5T")
                    'Dim printdimensionalcode As New Spire.Barcode.Forms.BarCodeControl
                    'printdimensionalcode.Type = BarCodeType.Pdf417
                    'printdimensionalcode.ShowText = fraud
                    'bccBarcode.Data = "" & CStr(reader1(10)) & "," & palmothersku & ",1.00," & CStr(reader1(11)) & "," & palcountpackinglistboxes & "," & rowscount & "," & CStr(reader1(12)) & "," & CInt(reader1(13)) & "," & CInt(reader1(14)) & "," & CInt(reader1(15)) & "," & CInt(reader1(16)) & "," & palendindentifier & ""
                    'printdimensionalcode.Data = "" & palstartidentifier & "," & CStr(reader1(10)) & "," & palmothersku & ",1.00," & CStr(reader1(11)) & "," & palcountpackinglistboxes & "," & rowscount & "," & CStr(reader1(12)) & "," & CInt(reader1(13)) & "," & CInt(reader1(14)) & "," & CInt(reader1(15)) & "," & CInt(reader1(16)) & "," & palendindentifier & ""
                    fillbarcodeA(CInt(reader1(0)), CStr(reader1(4)), CStr(reader1(5)), CStr(reader1(2)), CStr(Math.Round(CDec(reader1(7)), 0)), CStr(Math.Round(CDec(reader1(9)), 0)), CStr(Math.Round(CDec(reader1(11)), 0)), CStr(Math.Round(CDec(reader1(13)), 0)))
                    bccBarcode.Data = "" & bccBarcode.Data & "," & palendindentifier & ""
                    Dim generator As New BarCodeGenerator(bccBarcode)
                    Dim barcode As Image = generator.GenerateImage()
                    Dim mybytearray As Byte()
                    Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream
                    barcode.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    mybytearray = ms.ToArray()
                    'Dim converter As New ImageConverter
                    'imagedata = converter.ConvertTo(barcode, GetType(Byte()))
                    'printdataset.AddSetARow(CStr(reader1(0)), CStr(reader1(1)), CStr(reader1(2)), CStr(reader1(3)), neutralpage, CStr(reader1(5)), CStr(reader1(6)), CStr(reader1(7)), CStr(reader1(8)), CStr(reader1(9)), "" & rowscount & "  OF  " & palcountpackinglistboxes & "", mybytearray, "", CStr(reader1(4)), "")
                    printdataset.AddSetARow(CStr(reader1(0)), CStr(reader1(1)), CStr(reader1(3)), CStr(reader1(4)), neutralpage, CStr(reader1(6)), "" & CStr(Math.Round(CDec(reader1(7)), 0)) & "  " & CStr(reader1(8)) & "", "" & CStr(Math.Round(CDec(reader1(9)), 0)) & "  " & CStr(reader1(10)) & "", "" & CStr(Math.Round(CDec(reader1(11)), 0)) & "  " & CStr(reader1(12)) & "", "" & CStr(Math.Round(CDec(reader1(13)), 0)) & "  " & CStr(reader1(14)) & "", "" & rowscount & "  OF  " & palcountpackinglistboxes & "", mybytearray, "", CStr(reader1(5)), "")
                    rowscount = rowscount + startingpage
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub printPackingListB(ByVal ipackinglistid As Integer)
        Try
            rowscount = startingpage
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(pc.rowid,''),'-',COALESCE(pal.rowid,'')),''),COALESCE(CONCAT(COALESCE(ve.companycode,''),' ',COALESCE(ve.companyname,'')),''),COALESCE(CONCAT(COALESCE(bc.branchcode,''),' ',COALESCE(bc.branchname,'')),''),COALESCE(o.drnumber,''),COALESCE(CONCAT(COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),'')," &
                        "COALESCE(cc.codename,''),COALESCE(CONCAT(COALESCE(bc.branchcode,''),',',COALESCE(ve.companycode,''),',',COALESCE(o.drnumber,''),',',COALESCE(c1.codeno,''),',',COALESCE(c2.codeno,''),',',COALESCE(c3.codeno,'')),'') AS '2DCodeA',COALESCE(pc.amount,'') AS '2DCodeB',COALESCE(o.branchid,0),COALESCE(o.ordernumber,'') FROM packinglistcartons pc " &
                        "LEFT JOIN packinglist pal ON pc.packinglistid = pal.rowid LEFT JOIN orders o ON pal.orderid = o.rowid LEFT JOIN combinecodings cc ON o.combinecodingid = cc.rowid LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid " &
                        "LEFT JOIN branches bc ON o.branchid = bc.rowid LEFT JOIN companies ve ON o.companyid = ve.rowid LEFT JOIN cartonsizes cs ON pc.cartonsizeid = cs.rowid WHERE pc.packinglistid = " & ipackinglistid & " AND pc.organizationid = " & Z_OrganizationID & " AND pc.`status` != 'Inactive' ORDER BY pc.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    Spire.Barcode.BarcodeSettings.ApplyKey("LNAVJZFGXY6-NWBQG-FGB9V-34L5T")
                    'Dim printdimensionalcode As New Spire.Barcode.Forms.BarCodeControl
                    'printdimensionalcode.Type = BarCodeType.Pdf417
                    'printdimensionalcode.ShowText = fraud
                    ' printdimensionalcode.Data = "SCDS,238,044124,,238,,,,2,1,0.00,SMEND"
                    bccBarcode.Data = "" & palstartidentifier & "," & CStr(reader1(6)) & "," & palcountpackinglistboxes & "," & rowscount & "," & CStr(reader1(7)) & "," & palendindentifier & ""
                    'printdimensionalcode.Data = "" & palstartidentifier & "," & CStr(reader1(6)) & "," & palcountpackinglistboxes & "," & rowscount & "," & CStr(reader1(7)) & "," & palendindentifier & ""
                    Dim generator As New BarCodeGenerator(bccBarcode)
                    Dim barcode As Image = generator.GenerateImage()
                    Dim mybytearray As Byte()
                    Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream
                    barcode.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    mybytearray = ms.ToArray()
                    'Dim converter As New ImageConverter
                    'imagedata = converter.ConvertTo(barcode, GetType(Byte()))
                    printdataset.AddSetARow(CStr(reader1(0)), CStr(reader1(1)), If(CInt(reader1(8)) = 0, "#N/A", CStr(reader1(2))), CStr(reader1(3)), neutralpage, CStr(reader1(4)), CStr(reader1(5)), "" & rowscount & "  OF  " & palcountpackinglistboxes & "", "C.O. No.: " & CStr(reader1(9)) & "", "", "", mybytearray, "", "", "")
                    rowscount = rowscount + startingpage
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub printPackingListC(ByVal ipackinglistid As Integer)
        Try
            rowscount = startingpage
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pc.rowid,COALESCE(ve.companycode,''),COALESCE(bc.branchcode,''),COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ', COALESCE(bc.branchname,'')),''),COALESCE(o.referencenumber,''),COALESCE(o.drnumber,''),COALESCE(c1.codename,''),COALESCE(cs.`length`,0.00),COALESCE(cs.lengthuom,''),COALESCE(cs.`width`,0.00)," &
                        "COALESCE(cs.widthuom,''),COALESCE(cs.`height`,0.00),COALESCE(cs.heightuom,''),COALESCE(pc.`weight`,0.00),COALESCE(pc.weightuom,'') FROM packinglistcartons pc LEFT JOIN packinglist pal ON pc.packinglistid = pal.rowid LEFT JOIN orders o ON pal.orderid = o.rowid LEFT JOIN companies ve ON o.companyid = ve.rowid " &
                        "LEFT JOIN branches bc ON o.branchid = bc.rowid LEFT JOIN combinecodings cc ON o.combinecodingid = cc.rowid LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN cartonsizes cs ON pc.cartonsizeid = cs.rowid WHERE pc.packinglistid = " & ipackinglistid & " AND pc.organizationid = " & Z_OrganizationID & " AND pc.`status` != 'Inactive' ORDER BY pc.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    Spire.Barcode.BarcodeSettings.ApplyKey("LNAVJZFGXY6-NWBQG-FGB9V-34L5T")
                    'fillbarcodeB(CInt(reader1(0)), CStr(reader1(4)), CStr(reader1(5)), CStr(reader1(2)), CStr(Math.Round(CDec(reader1(7)), 0)), CStr(Math.Round(CDec(reader1(9)), 0)), CStr(Math.Round(CDec(reader1(11)), 0)), CStr(Math.Round(CDec(reader1(13)), 0)))
                    fillbarcodeB(CInt(reader1(0)), CStr(reader1(4)), CStr(reader1(5)), CStr(reader1(2)), CInt(reader1(7)), CInt(reader1(9)), CInt(reader1(11)), CInt(reader1(13)))
                    bccBarcode.Data = "" & bccBarcode.Data & "," & palendindentifier & ""
                    Dim generator As New BarCodeGenerator(bccBarcode)
                    Dim barcode As Image = generator.GenerateImage()
                    Dim mybytearray As Byte()
                    Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream
                    barcode.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    mybytearray = ms.ToArray()
                    ' printdataset.AddSetARow(CStr(reader1(0)), CStr(reader1(1)), CStr(reader1(3)), CStr(reader1(4)), neutralpage, CStr(reader1(6)), "" & CStr(Math.Round(CDec(reader1(7)), 0)) & "  " & CStr(reader1(8)) & "", "" & CStr(Math.Round(CDec(reader1(9)), 0)) & "  " & CStr(reader1(10)) & "", "" & CStr(Math.Round(CDec(reader1(11)), 0)) & "  " & CStr(reader1(12)) & "", "" & CStr(Math.Round(CDec(reader1(13)), 0)) & "  " & CStr(reader1(14)) & "", "" & rowscount & "  OF  " & palcountpackinglistboxes & "", mybytearray, "", CStr(reader1(5)), "")
                    printdataset.AddSetARow(CStr(reader1(0)), CStr(reader1(1)), CStr(reader1(3)), CStr(reader1(4)), neutralpage, CStr(reader1(6)), "" & CStr(Math.Round(CDec(reader1(7)), 0)) & "  " & CStr(reader1(8)) & "", "" & CStr(Math.Round(CDec(reader1(9)), 0)) & "  " & CStr(reader1(10)) & "", "" & CStr(Math.Round(CDec(reader1(11)), 0)) & "  " & CStr(reader1(12)) & "", "" & CStr(Math.Round(CDec(reader1(13)), 0)) & "  " & CStr(reader1(14)) & "", "" & rowscount & "  OF  " & palcountpackinglistboxes & "", mybytearray, "", CStr(reader1(5)), bccBarcode.Data)
                    rowscount = rowscount + startingpage
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub fillbarcodeA(ByVal ipackinglistcartonid As Integer, ByVal ipono As String, ByVal idrno As String, ByVal ibranchcode As String, ByVal ilength As String, ByVal iwidth As String, ByVal iheight As String, ByVal iweight As String)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT pci.rowid,COALESCE(bi.sku,''),COALESCE(b.sku,''),COALESCE(bi.srp,0.00) FROM packinglistcartonitems pci LEFT JOIN orderitems oi ON pci.orderitemid = oi.rowid LEFT JOIN orderitems bi ON oi.orderitemid = bi.rowid " &
                        "LEFT JOIN productbundles b ON bi.productbundleid = b.rowid WHERE pci.packinglistcartonid = " & ipackinglistcartonid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If LTrim(CStr(reader1(1))) = "" Then
                        palprintsku = CStr(reader1(2))
                    Else
                        palprintsku = CStr(reader1(1))
                    End If
                    bccBarcode.Data = "" & ipono & "," & idrno & "," & palprintsku & ",1," & CStr(reader1(3)) & "," & palcountpackinglistboxes & "," & rowscount & "," & ibranchcode & "," & ilength & "," & iwidth & "," & iheight & "," & iweight & ""
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub fillbarcodeB(ByVal ipackinglistcartonid As Integer, ByVal ipono As String, ByVal idrno As String, ByVal ibranchcode As String, ByVal ilength As String, ByVal iwidth As String, ByVal iheight As String, ByVal iweight As String)
        Try
            itemno = startingpage
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT pci.rowid,COALESCE(oi.sku,''),COALESCE(pcs.sku,''),COALESCE(pci.qtyincarton,0),COALESCE(oi.srp,0.00) FROM packinglistcartonitems pci LEFT JOIN orderitems oi ON pci.orderitemid = oi.rowid " &
                        "LEFT JOIN productcolorsizes pcs ON oi.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " &
                        "WHERE pci.packinglistcartonid = " & ipackinglistcartonid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' ORDER BY p.productcode,c.colorname,pcs.size,pcs.seasoncode "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If LTrim(CStr(reader1(1))) = "" Then
                        palprintsku = CStr(reader1(2))
                    Else
                        palprintsku = CStr(reader1(1))
                    End If
                    'If itemno = startingpage Then
                    '    bccBarcode.Data = "" & ipono & "," & idrno & "," & palprintsku & "," & CStr(reader1(3)) & "," & CStr(reader1(4)) & "," & palcountpackinglistboxes & "," & rowscount & "," & ibranchcode & "," & ilength & "," & iwidth & "," & iheight & "," & iweight & ""
                    'Else
                    '    bccBarcode.Data = "" & bccBarcode.Data & "," & ipono & "," & idrno & "," & palprintsku & "," & CStr(reader1(3)) & "," & CStr(reader1(4)) & "," & palcountpackinglistboxes & "," & rowscount & "," & ibranchcode & "," & ilength & "," & iwidth & "," & iheight & "," & iweight & ""
                    'End If
                    'If itemno = startingpage Then
                    '    bccBarcode.Data = "" & ipono & "," & idrno & "," & palprintsku & "," & Format(CInt(reader1(3)), "###0.00") & "," & Format(CDec(reader1(4)), "###0.0000") & "," & palcountpackinglistboxes & "," & rowscount & "," & ibranchcode & "," & ilength & "," & iwidth & "," & iheight & "," & iweight & ""
                    'Else
                    '    bccBarcode.Data = "" & bccBarcode.Data & ",SM" & vbNewLine & "" & ipono & "," & idrno & "," & palprintsku & "," & Format(CInt(reader1(3)), "###0.00") & "," & Format(CDec(reader1(4)), "###0.0000") & "," & palcountpackinglistboxes & "," & rowscount & "," & ibranchcode & "," & ilength & "," & iwidth & "," & iheight & "," & iweight & ""
                    'End If
                    If itemno = startingpage Then
                        bccBarcode.Data = "" & ipono & "," & idrno & "," & palprintsku & "," & CInt(reader1(3)) & "," & CInt(reader1(4)) & "," & palcountpackinglistboxes & "," & rowscount & "," & ibranchcode & "," & ilength & "," & iwidth & "," & iheight & "," & iweight & ""
                    Else
                        bccBarcode.Data = "" & bccBarcode.Data & ",SM" & vbNewLine & "" & ipono & "," & idrno & "," & palprintsku & "," & CInt(reader1(3)) & "," & CInt(reader1(4)) & "," & palcountpackinglistboxes & "," & rowscount & "," & ibranchcode & "," & ilength & "," & iwidth & "," & iheight & "," & iweight & ""
                    End If
                    itemno = itemno + startingpage
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

#Region "Deleting"

    Sub deleteCartonItems(ByVal ipackinglistcartonid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pci.rowid,pci.orderitemid,COALESCE(pci.qtyincarton,0) FROM packinglistcartonitems pci " &
                    "WHERE pci.packinglistcartonid = " & ipackinglistcartonid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' ORDER BY pci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        getOrderItemStatus(CInt(reader1(1)), Me)
                        If globalorderitemstatus = "Partially Lined Up" Then
                            palorderitemstatus = "Partially Lined Up"
                        Else
                            getTotalQtyInCarton(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), CInt(reader1(1)))
                            If (paltotalqtyincarton - CInt(reader1(2))) <> 0 Then
                                palorderitemstatus = "Partially Packed"
                            Else
                                palorderitemstatus = "Verified"
                            End If
                        End If
                        U_OrderItemStatus(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, palorderitemstatus, Me)
                        U_PackingListCartonItemStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
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

#End Region

#Region "Cancelling"

    Sub cancelPackingListCartons(ByVal ipackinglistid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pc.rowid FROM packinglistcartons pc WHERE pc.packinglistid = " & ipackinglistid & " AND pc.organizationid = " & Z_OrganizationID & " AND pc.`status` != 'Inactive' ORDER BY pc.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    cancelCartonItems(CInt(reader1(0)))
                    U_PackingListCartonStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Cancelled", Me)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub cancelCartonItems(ByVal ipackinglistcartonid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT pci.rowid,pci.orderitemid FROM packinglistcartonitems pci " &
                    "WHERE pci.packinglistcartonid = " & ipackinglistcartonid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' ORDER BY pci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        U_OrderItemStatus(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Verified", Me)
                        U_PackingListCartonItemStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Cancelled", Me)
                    End If
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
                PrimaryForm.PaLForm = False
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

    Private Sub msNew_Click(sender As Object, e As EventArgs) Handles msNew.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            cue = "New"
            errProvider.Clear()
            clearPackingListInformation()
            clearCustomerOrderItems()
            clearCartonItems()
            clearDatagrids()
            enableGB(fraud, legit, fraud)
            visibleCustomerOrderItems(fraud)
            enableANDvisibleMS(fraud, legit, fraud, legit, fraud)
            If dgPackingList.Rows.Count <> 0 Then
                dgPackingList.CurrentRow.Selected = False
            End If
            getPackingListNoA(Me)
            txtPackingListNo.Text = CStr(globalpackinglistno)
            txtStatus.Text = "New"
            txtPackingListDate.Text = Date.Now.ToString("dd-MMM-yyyy")
            globalautocompleteOrderInfoA(cboCustomerOrderInfo, globaliordertype:=OrderType.CO.ToString(), "For Packing", Me)
            globalautopopulateOrderInfoA(cboCustomerOrderInfo, globaliordertype:=OrderType.CO.ToString(), "For Packing", Me)
            cboCustomerOrderInfo.Enabled = legit
            txtPackingListNo.Focus()
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
            If dgPackingList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearPackingListInformation()
                clearCustomerOrderItems()
                clearCartonItems()
                clearDatagrids()
                enableGB(legit, legit, legit)
                visibleCustomerOrderItems(fraud)
                dgPackingList.CurrentRow.Selected = True
                displayPackingListInformation(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                palorderid = globalorderid
                getOrderInfo(palorderid, Me)
                txtPONo.Text = globalorderpono
                txtCustomerOrderDate.Text = globalorderdate
                txtTargetDeliveryDate.Text = globaltargetdate
                txtCancelDate.Text = globalordercanceldate
                txtClassDescription.Text = globalorderclassdescription
                txtSIDRNo.Text = globalordersidrno
                txtBranchCodeNameInfo.Text = globalbranchname
                txtVendorCodeNameInfo.Text = globalvendorname
                displayCustomerOrderItems(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                displayPackingListCartons(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                colorCoding() : packinglistcomputations(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If txtStatus.Text = "New" Then
                    enableANDvisibleMS(legit, legit, legit, fraud, legit)
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
                ElseIf txtStatus.Text = "Delivered" Then
                    enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
                Else
                    enableANDvisibleMS(legit, legit, legit, fraud, fraud)
                End If
                cboCustomerOrderInfo.Enabled = fraud
                txtPackingListNo.Focus()
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

    Private Sub dgPackingList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPackingList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPackingList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearPackingListInformation()
                clearCustomerOrderItems()
                clearCartonItems()
                clearDatagrids()
                enableGB(legit, legit, legit)
                visibleCustomerOrderItems(fraud)
                dgPackingList.CurrentRow.Selected = True
                displayPackingListInformation(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                palorderid = globalorderid
                getOrderInfo(palorderid, Me)
                txtPONo.Text = globalorderpono
                txtCustomerOrderDate.Text = globalorderdate
                txtTargetDeliveryDate.Text = globaltargetdate
                txtCancelDate.Text = globalordercanceldate
                txtClassDescription.Text = globalorderclassdescription
                txtSIDRNo.Text = globalordersidrno
                txtBranchCodeNameInfo.Text = globalbranchname
                txtVendorCodeNameInfo.Text = globalvendorname
                displayCustomerOrderItems(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                displayPackingListCartons(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                colorCoding() : packinglistcomputations(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If txtStatus.Text = "New" Then
                    enableANDvisibleMS(legit, legit, legit, fraud, legit)
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
                ElseIf txtStatus.Text = "Delivered" Then
                    enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
                Else
                    enableANDvisibleMS(legit, legit, legit, fraud, fraud)
                End If
                cboCustomerOrderInfo.Enabled = fraud
                txtPackingListNo.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgPackingList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgPackingList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPackingList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearPackingListInformation()
                    clearCustomerOrderItems()
                    clearCartonItems()
                    clearDatagrids()
                    enableGB(legit, legit, legit)
                    visibleCustomerOrderItems(fraud)
                    dgPackingList.CurrentRow.Selected = True
                    displayPackingListInformation(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                    palorderid = globalorderid
                    getOrderInfo(palorderid, Me)
                    txtPONo.Text = globalorderpono
                    txtCustomerOrderDate.Text = globalorderdate
                    txtTargetDeliveryDate.Text = globaltargetdate
                    txtCancelDate.Text = globalordercanceldate
                    txtClassDescription.Text = globalorderclassdescription
                    txtSIDRNo.Text = globalordersidrno
                    txtBranchCodeNameInfo.Text = globalbranchname
                    txtVendorCodeNameInfo.Text = globalvendorname
                    displayCustomerOrderItems(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    displayPackingListCartons(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    colorCoding() : packinglistcomputations(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    If txtStatus.Text = "New" Then
                        enableANDvisibleMS(legit, legit, legit, fraud, legit)
                    ElseIf txtStatus.Text = "Cancelled" Then
                        enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
                    ElseIf txtStatus.Text = "Delivered" Then
                        enableANDvisibleMS(legit, fraud, fraud, fraud, fraud)
                    Else
                        enableANDvisibleMS(legit, legit, legit, fraud, fraud)
                    End If
                    cboCustomerOrderInfo.Enabled = fraud
                    txtPackingListNo.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtPackingListNo_Leave(sender As Object, e As EventArgs) Handles txtPackingListNo.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cue = "New" Then
                If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                    getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                    palorderid = globalorderid
                    If LTrim(txtPackingListNo.Text) <> "" Then
                        If palorderid = 0 Then
                            errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                        Else
                            getPackingListIDA(txtPackingListNo.Text, palorderid, Me)
                            palpackinglistid = globalpackinglistid
                            If palpackinglistid <> 0 Then
                                errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
                            End If
                        End If
                    End If
                End If
            ElseIf cue = "Edit" Then
                If dgPackingList.Rows.Count <> 0 Then
                    If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                        getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                        palorderid = globalorderid
                        If LTrim(txtPackingListNo.Text) <> "" Then
                            If palorderid = 0 Then
                                errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                            Else
                                getPackingListIDB(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), txtPackingListNo.Text, palorderid, Me)
                                palpackinglistid = globalpackinglistid
                                If palpackinglistid <> 0 Then
                                    errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            cboCustomerOrderInfo.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub txtPackingListNo_TextChanged(sender As Object, e As EventArgs) Handles txtPackingListNo.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cue = "New" Then
    '            If LTrim(cboCustomerOrderInfo.Text) <> "" Then
    '                getOrderIDC(cboCustomerOrderInfo.Text, "CO", Me)
    '                palorderid = globalorderid
    '                If LTrim(txtPackingListNo.Text) <> "" Then
    '                    If palorderid = 0 Then
    '                        errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
    '                    Else
    '                        getPackingListIDA(txtPackingListNo.Text, palorderid, Me)
    '                        palpackinglistid = globalpackinglistid
    '                        If palpackinglistid <> 0 Then
    '                            errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        ElseIf cue = "Edit" Then
    '            If dgPackingList.Rows.Count <> 0 Then
    '                If LTrim(cboCustomerOrderInfo.Text) <> "" Then
    '                    getOrderIDC(cboCustomerOrderInfo.Text, "CO", Me)
    '                    palorderid = globalorderid
    '                    If LTrim(txtPackingListNo.Text) <> "" Then
    '                        If palorderid = 0 Then
    '                            errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
    '                        Else
    '                            getPackingListIDB(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), txtPackingListNo.Text, palorderid, Me)
    '                            palpackinglistid = globalpackinglistid
    '                            If palpackinglistid <> 0 Then
    '                                errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    Private Sub cboCustomerOrderInfo_Leave(sender As Object, e As EventArgs) Handles cboCustomerOrderInfo.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cue = "New" Then
                If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                    getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                    palorderid = globalorderid
                    If palorderid <> 0 Then
                        getOrderInfo(palorderid, Me)
                        txtPONo.Text = globalorderpono
                        txtCustomerOrderDate.Text = globalorderdate
                        txtTargetDeliveryDate.Text = globaltargetdate
                        txtCancelDate.Text = globalordercanceldate
                        txtClassDescription.Text = globalorderclassdescription
                        txtSIDRNo.Text = globalordersidrno
                        txtBranchCodeNameInfo.Text = globalbranchname
                        txtVendorCodeNameInfo.Text = globalvendorname
                        displayCustomerOrderItems(palorderid, neutralpage)
                        colorCoding() : packinglistcomputations(palorderid, neutralpage)
                    End If
                    If LTrim(txtPackingListNo.Text) <> "" Then
                        If palorderid = 0 Then
                            errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                        Else
                            getPackingListIDA(txtPackingListNo.Text, palorderid, Me)
                            palpackinglistid = globalpackinglistid
                            If palpackinglistid <> 0 Then
                                errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
                            End If
                        End If
                    End If
                End If
            ElseIf cue = "Edit" Then
                If dgPackingList.Rows.Count <> 0 Then
                    If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                        getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                        palorderid = globalorderid
                        If LTrim(txtPackingListNo.Text) <> "" Then
                            If palorderid = 0 Then
                                errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                            Else
                                getPackingListIDB(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), txtPackingListNo.Text, palorderid, Me)
                                palpackinglistid = globalpackinglistid
                                If palpackinglistid <> 0 Then
                                    errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            txtComments.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub cboCustomerOrderInfo_TextChanged(sender As Object, e As EventArgs) Handles cboCustomerOrderInfo.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cue = "New" Then
    '            If LTrim(cboCustomerOrderInfo.Text) <> "" Then
    '                getOrderIDC(cboCustomerOrderInfo.Text, "CO", Me)
    '                palorderid = globalorderid
    '                If palorderid <> 0 Then
    '                    getOrderInfo(palorderid, Me)
    '                    txtPONo.Text = globalorderpono
    '                    txtCustomerOrderDate.Text = globalorderdate
    '                    txtTargetDeliveryDate.Text = globaltargetdate
    '                    txtCancelDate.Text = globalordercanceldate
    '                    txtClassDescription.Text = globalorderclassdescription
    '                    txtSIDRNo.Text = globalordersidrno
    '                    txtBranchCodeNameInfo.Text = globalbranchname
    '                    txtVendorCodeNameInfo.Text = globalvendorname
    '                    displayCustomerOrderItems(palorderid, neutralpage)
    '                    colorCoding() : packinglistcomputations(palorderid, neutralpage)
    '                End If
    '                If LTrim(txtPackingListNo.Text) <> "" Then
    '                    If palorderid = 0 Then
    '                        errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
    '                    Else
    '                        getPackingListIDA(txtPackingListNo.Text, palorderid, Me)
    '                        palpackinglistid = globalpackinglistid
    '                        If palpackinglistid <> 0 Then
    '                            errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        ElseIf cue = "Edit" Then
    '            If dgPackingList.Rows.Count <> 0 Then
    '                If LTrim(cboCustomerOrderInfo.Text) <> "" Then
    '                    getOrderIDC(cboCustomerOrderInfo.Text, "CO", Me)
    '                    palorderid = globalorderid
    '                    If LTrim(txtPackingListNo.Text) <> "" Then
    '                        If palorderid = 0 Then
    '                            errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
    '                        Else
    '                            getPackingListIDB(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), txtPackingListNo.Text, palorderid, Me)
    '                            palpackinglistid = globalpackinglistid
    '                            If palpackinglistid <> 0 Then
    '                                errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    'Private Sub cboCustomerOrderInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomerOrderInfo.SelectedIndexChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cue = "New" Then
    '            If LTrim(cboCustomerOrderInfo.Text) <> "" Then
    '                getOrderIDC(cboCustomerOrderInfo.Text, "CO", Me)
    '                palorderid = globalorderid
    '                If palorderid <> 0 Then
    '                    getOrderInfo(palorderid, Me)
    '                    txtPONo.Text = globalorderpono
    '                    txtCustomerOrderDate.Text = globalorderdate
    '                    txtTargetDeliveryDate.Text = globaltargetdate
    '                    txtCancelDate.Text = globalordercanceldate
    '                    txtClassDescription.Text = globalorderclassdescription
    '                    txtSIDRNo.Text = globalordersidrno
    '                    txtBranchCodeNameInfo.Text = globalbranchname
    '                    txtVendorCodeNameInfo.Text = globalvendorname
    '                    displayCustomerOrderItems(palorderid, neutralpage)
    '                    colorCoding() : packinglistcomputations(palorderid, neutralpage)
    '                End If
    '                If LTrim(txtPackingListNo.Text) <> "" Then
    '                    If palorderid = 0 Then
    '                        errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
    '                    Else
    '                        getPackingListIDA(txtPackingListNo.Text, palorderid, Me)
    '                        palpackinglistid = globalpackinglistid
    '                        If palpackinglistid <> 0 Then
    '                            errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        ElseIf cue = "Edit" Then
    '            If dgPackingList.Rows.Count <> 0 Then
    '                If LTrim(cboCustomerOrderInfo.Text) <> "" Then
    '                    getOrderIDC(cboCustomerOrderInfo.Text, "CO", Me)
    '                    palorderid = globalorderid
    '                    If LTrim(txtPackingListNo.Text) <> "" Then
    '                        If palorderid = 0 Then
    '                            errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
    '                        Else
    '                            getPackingListIDB(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), txtPackingListNo.Text, palorderid, Me)
    '                            palpackinglistid = globalpackinglistid
    '                            If palpackinglistid <> 0 Then
    '                                errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    Private Sub chkOtherInfo_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtherInfo.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If chkOtherInfo.Checked = legit Then
                visibleCustomerOrderItems(legit)
            Else
                visibleCustomerOrderItems(fraud)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCustomerOrderItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrderItems.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                lnkViewEditBundleItems.Visible = fraud
                btnAddToCarton.Enabled = legit
                If CStr(dgCustomerOrderItems.CurrentRow.Cells("ci_type").Value) = "S" Then
                    getOrderItemStatus(CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value), Me)
                    If globalorderitemstatus = "Verified" Or globalorderitemstatus = "Partially Packed" Or globalorderitemstatus = "Partially Lined Up" Then
                        If If(IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_qtypicked").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_qtypicked").Value), 0) = If(IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_totalqtyincarton").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_totalqtyincarton").Value), 0) Then
                            ci_qtytopack.ReadOnly = legit
                        Else
                            ci_qtytopack.ReadOnly = fraud
                        End If
                    Else
                        ci_qtytopack.ReadOnly = legit
                    End If
                Else
                    lnkViewEditBundleItems.Visible = legit
                    ci_qtytopack.ReadOnly = legit
                    btnAddToCarton.Enabled = fraud
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCustomerOrderItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrderItems.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPackingList.Rows.Count <> 0 Then
                If dgCustomerOrderItems.Rows.Count <> 0 Then
                    If e.ColumnIndex = dgCustomerOrderItems.Columns("ci_totalqtyincarton").Index Then
                        If CStr(dgCustomerOrderItems.CurrentRow.Cells("ci_type").Value) = "S" Then
                            If IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_totalqtyincarton").Value) Then
                                If CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_totalqtyincarton").Value) <> 0 Then
                                    Dim viewcartonslinkform As New ViewCartonsForm
                                    viewcartonslinkform.vcpackinglistid = CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value)
                                    viewcartonslinkform.vcorderitemid = CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value)
                                    viewcartonslinkform.ShowInTaskbar = False
                                    viewcartonslinkform.ShowDialog()
                                End If
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

    Private Sub dgCustomerOrderItems_KeyUp(sender As Object, e As KeyEventArgs) Handles dgCustomerOrderItems.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    lnkViewEditBundleItems.Visible = fraud
                    btnAddToCarton.Enabled = legit
                    If CStr(dgCustomerOrderItems.CurrentRow.Cells("ci_type").Value) = "S" Then
                        getOrderItemStatus(CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value), Me)
                        If globalorderitemstatus = "Verified" Or globalorderitemstatus = "Partially Packed" Or globalorderitemstatus = "Partially Lined Up" Then
                            If If(IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_qtypicked").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_qtypicked").Value), 0) = If(IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_totalqtyincarton").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_totalqtyincarton").Value), 0) Then
                                ci_qtytopack.ReadOnly = legit
                            Else
                                ci_qtytopack.ReadOnly = fraud
                            End If
                        Else
                            ci_qtytopack.ReadOnly = legit
                        End If
                    Else
                        lnkViewEditBundleItems.Visible = legit
                        ci_qtytopack.ReadOnly = legit
                        btnAddToCarton.Enabled = fraud
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

    Private Sub dgCustomerOrderItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrderItems.CellEndEdit
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPackingList.Rows.Count <> 0 Then
                getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                palorderid = globalorderid
                packinglistcomputations(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAddToCarton_Click(sender As Object, e As EventArgs) Handles btnAddToCarton.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
            If dgPackingList.Rows.Count <> 0 Then
                getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                palorderid = globalorderid
                If palorderid = 0 Then
                    MessageBox.Show("System cannot find the customer order.", "Adding", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                packinglistcomputations(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palqtytopackerrorcue = legit Then
                    MessageBox.Show("One of the Qty. Ordered is less than Total Qty. In Carton plus(+) Qty. To Pack.", "Adding", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                Dim addtocartonlinkform As New AddToCartonForm
                addtocartonlinkform.lblTitle.Text = "Add To Carton"
                addtocartonlinkform.atcorderid = palorderid
                addtocartonlinkform.atcpackinglistid = CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value)
                If dgCustomerOrderItems.Rows.Count <> 0 Then
                    addtocartonlinkform.dgCustomerOrderItems.Rows.Clear()
                    For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                        If CStr(dgCustomerOrderItems.Rows(i).Cells("ci_type").Value) = "S" Then
                            If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value) Then
                                If CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value) > 0 Then
                                    getOrderItemStatus(CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value), Me)
                                    If globalorderitemstatus = CStr(dgCustomerOrderItems.Rows(i).Cells("ci_status").Value) Then
                                        If globalorderitemstatus = "Verified" Or globalorderitemstatus = "Partially Packed" Or globalorderitemstatus = "Partially Lined Up" Then
                                            addtocartonlinkform.dgCustomerOrderItems.Rows.Add()
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_rowid").Value = CInt(dgCustomerOrderItems.Rows(i).Cells("ci_rowid").Value)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_colorvalue").Value = CStr(dgCustomerOrderItems.Rows(i).Cells("ci_colorvalue").Value)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_productcode").Value = CStr(dgCustomerOrderItems.Rows(i).Cells("ci_itemcode").Value)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_colorname").Value = CStr(dgCustomerOrderItems.Rows(i).Cells("ci_colorname").Value)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_color").Value = ""
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_size").Value = If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_size").Value), CDec(dgCustomerOrderItems.Rows(i).Cells("ci_size").Value), "")
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_seasoncode").Value = CStr(dgCustomerOrderItems.Rows(i).Cells("ci_seasoncode").Value)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtyordered").Value = If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtyordered").Value), 0)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtypicked").Value = If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtypicked").Value), 0)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_totalqtyincarton").Value = If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_totalqtyincarton").Value), 0)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtytopack").Value = If(IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value), CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtytopack").Value), 0)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_status").Value = CStr(dgCustomerOrderItems.Rows(i).Cells("ci_status").Value)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_sku").Value = CStr(dgCustomerOrderItems.Rows(i).Cells("ci_sku").Value)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_unitofmeasure").Value = CStr(dgCustomerOrderItems.Rows(i).Cells("ci_unitofmeasure").Value)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_remarks").Value = CStr(dgCustomerOrderItems.Rows(i).Cells("ci_remarks").Value)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_tags").Value = CStr(dgCustomerOrderItems.Rows(i).Cells("ci_tags").Value)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_packedby").Value = CStr(dgCustomerOrderItems.Rows(i).Cells("ci_packedby").Value)
                                            addtocartonlinkform.dgCustomerOrderItems.Rows(addtocartonlinkform.dgCustomerOrderItems.Rows.Count - 1).Cells("ci_packeddate").Value = CStr(dgCustomerOrderItems.Rows(i).Cells("ci_packeddate").Value)
                                        End If
                                    Else
                                        dgCustomerOrderItems.Rows(i).Cells("ci_status").ErrorText = "There is a change in the status of this customer order item, click the pick list again to check the status."
                                        Exit Try
                                    End If
                                End If
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("There is nothing to add in this customer order item.", "Adding", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If addtocartonlinkform.dgCustomerOrderItems.Rows.Count = 0 Then
                    MessageBox.Show("There is nothing to add in this customer order item.", "Adding", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                Else
                    addtocartonlinkform.ShowInTaskbar = False
                    addtocartonlinkform.ShowDialog()
                    If addtocartonlinkform.addtocartonformcue = legit Then
                        displayCustomerOrderItems(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                        displayPackingListCartons(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                        dgCartonItems.Rows.Clear()
                        colorCoding() : packinglistcomputations(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
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

    Private Sub dgCartons_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCartons.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCartons.Rows.Count <> 0 Then
                displayPackingListCartonItems(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value))
                getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                palorderid = globalorderid
                colorCoding() : packinglistcomputations(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCartons_KeyUp(sender As Object, e As KeyEventArgs) Handles dgCartons.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCartons.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    displayPackingListCartonItems(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value))
                    getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                    palorderid = globalorderid
                    colorCoding() : packinglistcomputations(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCartons_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCartons.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCartons.Rows.Count <> 0 Then
                If e.ColumnIndex = dgCartons.Columns("ca_option").Index Then
                    getPackingListCartonStatus(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value), Me)
                    If globalpackinglistcartonstatus = "Active" Then
                        cmsOptions.Show(Cursor.Position)
                    Else
                        MessageBox.Show("System cannot edit this box since the box has been lined-up or delivered already.", "Editing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
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

    Private Sub lnkViewEditBundleItems_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkViewEditBundleItems.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
            If dgPackingList.Rows.Count <> 0 Then
                getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                palorderid = globalorderid
                If palorderid = 0 Then
                    MessageBox.Show("System cannot find the customer order.", "Adding", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If dgCustomerOrderItems.Rows.Count = 0 Then
                    MessageBox.Show("There is nothing to add in this customer order item.", "Adding", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                Dim addtocartonlinkform As New AddToCartonForm
                addtocartonlinkform.lblTitle.Text = "Add To Box - Bundle Items"
                addtocartonlinkform.atcorderid = palorderid
                addtocartonlinkform.atcpackinglistid = CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value)
                addtocartonlinkform.atcorderitemid = CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value)
                addtocartonlinkform.ShowInTaskbar = False
                addtocartonlinkform.ShowDialog()
                If addtocartonlinkform.addtocartonformcue = legit Then
                    displayCustomerOrderItems(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    displayPackingListCartons(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    dgCartonItems.Rows.Clear()
                    colorCoding() : packinglistcomputations(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmsEdit_Click(sender As Object, e As EventArgs) Handles cmsEdit.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
            If dgPackingList.Rows.Count = 0 Then
                MessageBox.Show("System cannot find the packing list.", "Editing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If dgCartons.Rows.Count = 0 Then
                MessageBox.Show("System cannot find the box.", "Editing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            getPackingListCartonStatus(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value), Me)
            If globalpackinglistcartonstatus <> "Active" Then
                MessageBox.Show("The status of this box has been updated, click the pick list again to check the status.", "Editing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            Dim editcartonlinkform As New EditCartonForm
            editcartonlinkform.ecpackinglistcartonid = CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value)
            editcartonlinkform.ecpackinglistid = CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value)
            editcartonlinkform.ShowInTaskbar = False
            editcartonlinkform.ShowDialog()
            If editcartonlinkform.editcartonformcue = legit Then
                dgCartonItems.Rows.Clear()
                displayPackingListCartons(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                colorCoding() : packinglistcomputations(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
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
            errProvider.Clear()
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If cue = "New" Then
                If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                    getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                    palorderid = globalorderid
                    If palorderid = 0 Then
                        errProvider.SetError(cboCustomerOrderInfo, "Please choose or enter the customer order info.")
                        Exit Try
                    End If
                    getPackingListIDC(palorderid, Me)
                    If palpackinglistid <> 0 Then
                        errProvider.SetError(txtPackingListNo, "The packing list for this order has been created already.")
                        Exit Try
                    End If
                    If LTrim(txtPackingListNo.Text) <> "" Then
                        If palorderid = 0 Then
                            errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                            Exit Try
                        Else
                            getPackingListIDA(txtPackingListNo.Text, palorderid, Me)
                            palpackinglistid = globalpackinglistid
                            If palpackinglistid <> 0 Then
                                errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
                                Exit Try
                            End If
                        End If
                    Else
                        errProvider.SetError(txtPackingListNo, "Please enter the packing list no.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(cboCustomerOrderInfo, "Please choose or enter the customer order info.")
                    Exit Try
                End If
            ElseIf cue = "Edit" Then
                If globalcreateflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If dgPackingList.Rows.Count <> 0 Then
                    If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                        getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                        palorderid = globalorderid
                        If LTrim(txtPackingListNo.Text) <> "" Then
                            If palorderid = 0 Then
                                errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                                Exit Try
                            Else
                                getPackingListIDB(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), txtPackingListNo.Text, palorderid, Me)
                                palpackinglistid = globalpackinglistid
                                If palpackinglistid <> 0 Then
                                    errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
                                    errProvider.SetError(cboCustomerOrderInfo, "Packing List No. and Customer Order has been created already, please type a new one.")
                                    Exit Try
                                End If
                            End If
                        Else
                            errProvider.SetError(txtPackingListNo, "Please enter the packing list no.")
                            Exit Try
                        End If
                    Else
                        errProvider.SetError(cboCustomerOrderInfo, "Please choose the customer order info.")
                        Exit Try
                    End If
                    getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                    If globalpackingliststatus <> txtStatus.Text Then
                        MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                Else
                    MessageBox.Show("System cannot find the Packing List to be updated.", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            myModule.systemerrorfound = False
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If cue = "New" Then
                    getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                    palorderid = globalorderid
                    If palorderid = 0 Then
                        errProvider.SetError(cboCustomerOrderInfo, "Please choose or enter the customer order info.")
                        Exit Try
                    End If
                    getPackingListIDC(palorderid, Me)
                    If palpackinglistid <> 0 Then
                        errProvider.SetError(txtPackingListNo, "The packing list for this order has been created already.")
                        Exit Try
                    End If
                    getPackingListIDA(txtPackingListNo.Text, palorderid, Me)
                    palpackinglistid = globalpackinglistid
                    If palpackinglistid <> 0 Then
                        errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
                        Exit Try
                    End If
                    I_PackingList(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, palorderid, txtPackingListNo.Text, txtPackingListDate.Text, txtStatus.Text, txtComments.Text, Me)
                    If myModule.systemerrorfound = False Then
                        U_OrderStatus(palorderid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Packing", Me)
                    End If
                    If myModule.systemerrorfound = False Then
                        Await AutomateContainPackingListToDefaultCartonAsync().
                            ContinueWith(
                            continuationAction:=Sub()
                                                    myBalloon("Successfully Save", "Save", lblsavemsg, -15, -65)
                                                    tsrefreshperformclick()
                                                End Sub, scheduler:=TaskScheduler.FromCurrentSynchronizationContext)
                    End If
                ElseIf cue = "Edit" Then
                    If dgPackingList.Rows.Count <> 0 Then
                        getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                        palorderid = globalorderid
                        If palorderid = 0 Then
                            errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                            Exit Try
                        Else
                            getPackingListIDB(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), txtPackingListNo.Text, palorderid, Me)
                            palpackinglistid = globalpackinglistid
                            If palpackinglistid <> 0 Then
                                errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
                                errProvider.SetError(cboCustomerOrderInfo, "Packing List No. and Customer Order has been created already, please type a new one.")
                                Exit Try
                            End If
                        End If
                        getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                        If globalpackingliststatus <> txtStatus.Text Then
                            MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                        U_PackingList(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtPackingListNo.Text, txtComments.Text, Me)
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
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

    Private Sub cmsDelete_Click(sender As Object, e As EventArgs) Handles cmsDelete.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
            If dgCartons.Rows.Count <> 0 Then
                getPackingListCartonStatus(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value), Me)
                If globalpackinglistcartonstatus = "Active" Then
                    If MessageBox.Show("Would you like to delete this box?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        getPackingListCartonStatus(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value), Me)
                        If globalpackinglistcartonstatus = "Active" Then
                            deleteCartonItems(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value))
                            If myModule.systemerrorfound = False Then
                                U_PackingListCartonStatus(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
                                displayCustomerOrderItems(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                                displayPackingListCartons(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                                colorCoding() : packinglistcomputations(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                                myBalloon("Successfully Deleted", "Delete", lblsavemsg, -15, -65)
                                txtPackingListNo.Focus()
                            End If
                        Else
                            MessageBox.Show("System cannot delete this box since this box has been lined-up or delivered already.", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                    End If
                Else
                    MessageBox.Show("System cannot delete this box since this box has been lined-up or delivered already.", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCartonItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCartonItems.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
            If dgCartons.Rows.Count <> 0 Then
                If dgCartonItems.Rows.Count <> 0 Then
                    If e.ColumnIndex = dgCartonItems.Columns("cai_option").Index Then
                        getPackingListCartonStatus(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value), Me)
                        If globalpackinglistcartonstatus = "Active" Then
                            If MessageBox.Show("Would you like to remove this item inside this box?", "Removing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                Me.Cursor = Cursors.WaitCursor
                                getPackingListCartonStatus(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value), Me)
                                If globalpackinglistcartonstatus = "Active" Then
                                    If myModule.systemerrorfound = False Then
                                        getPackingListCartonItemInfo(CInt(dgCartonItems.CurrentRow.Cells("cai_rowid").Value), Me)
                                        getOrderItemStatus(globalorderitemid, Me)
                                        If globalorderitemstatus = "Partially Lined Up" Then
                                            palorderitemstatus = "Partially Lined Up"
                                        Else
                                            getTotalQtyInCarton(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), globalorderitemid)
                                            If paltotalqtyincarton - globalpackinglistcartonitemqtyincarton <> 0 Then
                                                palorderitemstatus = "Partially Packed"
                                            Else
                                                palorderitemstatus = "Verified"
                                            End If
                                        End If
                                        U_OrderItemStatus(globalorderitemid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, palorderitemstatus, Me)
                                    End If
                                    If myModule.systemerrorfound = False Then
                                        U_PackingListCartonItemStatus(CInt(dgCartonItems.CurrentRow.Cells("cai_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
                                        dgCartonItems.Rows.Clear() : getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me) : palorderid = globalorderid
                                        displayCustomerOrderItems(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                                        displayPackingListCartons(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                                        colorCoding() : packinglistcomputations(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                                        myBalloon("Successfully Removed", "Remove", lblsavemsg, -15, -65)
                                    End If
                                Else
                                    MessageBox.Show("System cannot remove this item since the box has been lined-up or delivered already.", "Removing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                End If
                            End If
                        Else
                            MessageBox.Show("System cannot remove this item since the box has been lined-up or delivered already.", "Removing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
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

    Private Sub msOrder_Click(sender As Object, e As EventArgs) Handles msOrder.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
            If dgPackingList.Rows.Count <> 0 Then
                If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                    getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                    palorderid = globalorderid
                    If LTrim(txtPackingListNo.Text) <> "" Then
                        If palorderid = 0 Then
                            errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                            Exit Try
                        Else
                            getPackingListIDB(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), txtPackingListNo.Text, palorderid, Me)
                            palpackinglistid = globalpackinglistid
                            If palpackinglistid <> 0 Then
                                errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
                                errProvider.SetError(cboCustomerOrderInfo, "Packing List No. and Customer Order has been created already, please type a new one.")
                                Exit Try
                            End If
                        End If
                    Else
                        errProvider.SetError(txtPackingListNo, "Please enter the packing list no.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(cboCustomerOrderInfo, "Please choose the customer order info.")
                    Exit Try
                End If
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the Packing List to be updated.", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("NOTE: Once you cancelled this packing list, you cannot open this packing list again." & vbNewLine & "" & vbNewLine & "Do you want to proceed cancelling this packing list?", "Cancelling", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If dgPackingList.Rows.Count <> 0 Then
                    getOrderIDC(cboCustomerOrderInfo.Text, globaliordertype:=OrderType.CO.ToString(), Me)
                    palorderid = globalorderid
                    If palorderid = 0 Then
                        errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                        Exit Try
                    Else
                        getPackingListIDB(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), txtPackingListNo.Text, palorderid, Me)
                        palpackinglistid = globalpackinglistid
                        If palpackinglistid <> 0 Then
                            errProvider.SetError(txtPackingListNo, "Packing List No. and Customer Order has been created already, please type a new one.")
                            errProvider.SetError(cboCustomerOrderInfo, "Packing List No. and Customer Order has been created already, please type a new one.")
                            Exit Try
                        End If
                    End If
                    getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                    If globalpackingliststatus <> txtStatus.Text Then
                        MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    U_PackingList(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtPackingListNo.Text, txtComments.Text, Me)
                    cancelPackingListCartons(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    U_OrderStatus(palorderid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "For Packing", Me)
                    U_PackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Cancelled", Me)
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Cancelled", "Cancel", lblsavemsg, -15, -65)
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

    Private Sub msOutright_Click(sender As Object, e As EventArgs) Handles msOutrightA.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
            If dgPackingList.Rows.Count <> 0 Then
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the Packing List to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to print this packing list in Outright A Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If myModule.systemerrorfound = False Then
                    getCodeIndentifiers()
                    'getOrderIDC(cboCustomerOrderInfo.Text, "CO", Me)
                    'palorderid = globalorderid
                    'getMotherSKU(palorderid, CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    printPackingListA(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    Dim printreport As New OutrightPrint
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
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msOutrightB_Click(sender As Object, e As EventArgs) Handles msOutrightB.Click
        'Me.Cursor = Cursors.WaitCursor
        'Try
        '    errProvider.Clear()
        '    myModule.systemerrorfound = False
        '    getPositionID(Me)
        '    If globalpositionid <> 0 Then
        '        getPositionView(globalpositionid, "Packing List", Me)
        '        If globaldisableflg = "Y" Then
        '            MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            PrimaryForm.PaLForm = False
        '            Me.Close()
        '        End If
        '        If globalreadonlyflg = "Y" Then
        '            MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Exit Try
        '        End If
        '        If globalcreateflg = "Y" Then
        '            MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Exit Try
        '        End If
        '    Else
        '        MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Exit Try
        '    End If
        '    If dgPackingList.Rows.Count <> 0 Then
        '        getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
        '        If globalpackingliststatus <> txtStatus.Text Then
        '            MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Exit Try
        '        End If
        '        countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
        '        If palcountpackinglistboxes = 0 Then
        '            MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Exit Try
        '        End If
        '    Else
        '        MessageBox.Show("System cannot find the Packing List to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Exit Try
        '    End If
        '    If MessageBox.Show("Would you like to print this packing list in Outright B Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '        Me.Cursor = Cursors.WaitCursor
        '        getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
        '        If globalpackingliststatus <> txtStatus.Text Then
        '            MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Exit Try
        '        End If
        '        countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
        '        If palcountpackinglistboxes = 0 Then
        '            MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Exit Try
        '        End If
        '        If myModule.systemerrorfound = False Then
        '            getCodeIndentifiers()
        '            printPackingListC(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
        '            Dim printreport As New OutrightPrintB
        '            Dim openreportviewer As New ReportViewer
        '            openreportviewer.CrystalReportViewer.ReportSource = printreport
        '            printdatatable = printdataset
        '            printreport.SetDataSource(printdatatable)
        '            openreportviewer.Show()
        '            printdatatable.Dispose()
        '            printdatatable = Nothing
        '            printdataset.Clear()
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(getErrExcptn(ex, Me.Name))
        'Finally
        '    conn.Close()
        'End Try
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsExtraSmall_Click(sender As Object, e As EventArgs) Handles tsExtraSmall.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
            If dgPackingList.Rows.Count <> 0 Then
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the Packing List to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to print this packing list in Outright B in Small Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If myModule.systemerrorfound = False Then
                    getCodeIndentifiers()
                    printPackingListC(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    Dim printreport As New OutrightPrint
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
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsSmall_Click(sender As Object, e As EventArgs) Handles tsSmall.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
            If dgPackingList.Rows.Count <> 0 Then
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the Packing List to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to print this packing list in Outright B in Small Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If myModule.systemerrorfound = False Then
                    getCodeIndentifiers()
                    printPackingListC(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    Dim printreport As New OutrightPrintE
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
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsMedium_Click(sender As Object, e As EventArgs) Handles tsMedium.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
            If dgPackingList.Rows.Count <> 0 Then
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the Packing List to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to print this packing list in Outright B in Large Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If myModule.systemerrorfound = False Then
                    getCodeIndentifiers()
                    printPackingListC(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    Dim printreport As New OutrightPrintC
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
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsLarge_Click(sender As Object, e As EventArgs) Handles tsLarge.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
            If dgPackingList.Rows.Count <> 0 Then
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the Packing List to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to print this packing list in Outright B in Large Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If myModule.systemerrorfound = False Then
                    getCodeIndentifiers()
                    printPackingListC(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    Dim printreport As New OutrightPrintD
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
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsExtraLarge_Click(sender As Object, e As EventArgs) Handles tsExtraLarge.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
            If dgPackingList.Rows.Count <> 0 Then
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the Packing List to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to print this packing list in Outright B in Small Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If myModule.systemerrorfound = False Then
                    getCodeIndentifiers()
                    printPackingListC(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    'Dim printreport As New OutrightPrintB
                    Dim printreport As New OutrightPrintBRev
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
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msConsignor_Click(sender As Object, e As EventArgs) Handles msConsignor.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PaLForm = False
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
            If dgPackingList.Rows.Count <> 0 Then
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the Packing List to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to print this packing list in Consignor Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getPackingListStatus(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value), Me)
                If globalpackingliststatus <> txtStatus.Text Then
                    MessageBox.Show("This packing list has been updated by other user, please click refresh button to check the new status of this packing list.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                countPackingListBoxes(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                If palcountpackinglistboxes = 0 Then
                    MessageBox.Show("There is no box that needs to be printed.", "Printing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If myModule.systemerrorfound = False Then
                    getCodeIndentifiers()
                    printPackingListB(CInt(dgPackingList.CurrentRow.Cells("pal_rowid").Value))
                    Dim printreport As New ConsignorPrint
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
                    clearcboSearch()
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

    Private Sub cboSearch1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearch1.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If cboSearch1.Text = "" Then
                cboSearch2.Items.Clear() : cboSearch2.AutoCompleteCustomSource.Clear()
            ElseIf cboSearch1.Text = "CartonNo" Then
                autocompleteCartonNos(cboSearch2)
                autopopulateCartonNos(cboSearch2)
            ElseIf cboSearch1.Text = "CustomerName" Then
                autocompleteCustomerName(cboSearch2)
                autopopulateCustomerName(cboSearch2)
            ElseIf cboSearch1.Text = "PackerName" Then
                autocompletePackerName(cboSearch2)
                autopopulatePackerName(cboSearch2)
            ElseIf cboSearch1.Text = "Status" Then
                autocompleteStatus(cboSearch2)
                autopopulateStatus(cboSearch2)
            End If
            cboSearch2.Text = "" : cboSearch2.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboSearch2_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSearch2.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If cboDate.Text = "" And cboSearch1.Text = "" Then
                    tsrefreshperformclick()
                Else
                    If cboDate.Text <> "" And cboSearch1.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "PackingDate" Then
                            datephrase = "pal.packinglistdate"
                        ElseIf cboDate.Text = "TargetDate" Then
                            datephrase = "co.targetdate"
                        End If
                        displayDateSearch(spagenum, datephrase)
                        pageSetup2(datephrase)
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                    ElseIf cboDate.Text <> "" And cboSearch2.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "PackingDate" Then
                            datephrase = "pal.packinglistdate"
                        ElseIf cboDate.Text = "TargetDate" Then
                            datephrase = "co.targetdate"
                        End If
                        displayDateSearch(spagenum, datephrase)
                        pageSetup2(datephrase)
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                    Else
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "CommonSearch"
                        If cboSearch1.Text = "" Then
                            pagefilter1 = ""
                        Else
                            getCommonPhrase(cboSearch1, cboSearch2.Text)
                            pagefilter1 = "" & commonphrase & ""
                        End If
                        If cboDate.Text = "PackingDate" Then
                            pagefilter2 = " AND (pal.packinglistdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                "pal.packinglistdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        ElseIf cboDate.Text = "TargetDate" Then
                            pagefilter2 = " AND (co.targetdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                "co.targetdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        Else
                            pagefilter2 = ""
                        End If
                        spagenum = neutralpage : numofpages = startingpage
                        displayCommonPhrase(pagefilter1, pagefilter2, spagenum)
                        pageSetup3(pagefilter1, pagefilter2)
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
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

    Private Sub cmdFirst_Click(sender As Object, e As EventArgs) Handles cmdFirst.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            spagenum = neutralpage
            numofpages = startingpage
            If searchmode = "Basic" Then
                displayPackingList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter1, pagefilter2, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum, datephrase)
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
                displayPackingList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter1, pagefilter2, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum, datephrase)
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
                displayPackingList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter1, pagefilter2, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum, datephrase)
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
                displayPackingList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter1, pagefilter2, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum, datephrase)
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
                            displayPackingList(spagenum)
                        ElseIf searchmode = "CommonSearch" Then
                            displayCommonPhrase(pagefilter1, pagefilter2, spagenum)
                        ElseIf searchmode = "SimpleSearch" Then
                            displaySearchPhrase(simplesearchphrase, spagenum)
                        ElseIf searchmode = "DateSearch" Then
                            displayDateSearch(spagenum, datephrase)
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

    Private Sub dgCartons_MouseUp(sender As Object, e As MouseEventArgs) Handles dgCartons.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgCartons.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgCartons.BeginEdit(True)
                Else
                    dgCartons.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgCartonItems_MouseUp(sender As Object, e As MouseEventArgs) Handles dgCartonItems.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgCartonItems.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgCartonItems.BeginEdit(True)
                Else
                    dgCartonItems.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgCustomerOrderItems_MouseUp(sender As Object, e As MouseEventArgs) Handles dgCustomerOrderItems.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgCustomerOrderItems.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgCustomerOrderItems.BeginEdit(True)
                Else
                    dgCustomerOrderItems.EndEdit()
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

    Private Sub dgPackingList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgPackingList.DataError
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
                dgPackingList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCustomerOrderItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCustomerOrderItems.DataError
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
                dgCustomerOrderItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCartons_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCartons.DataError
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
                dgCartons.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCartonItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCartonItems.DataError
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
                dgCartonItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

    Private ReadOnly Property IsThurston As Boolean
        Get
            Return _systemOwner.IsThurston
        End Get
    End Property

    Private Async Function AutomateContainPackingListToDefaultCartonAsync() As Task
        Await FunctionUtils.TryCatchFunctionAsync("Assign this packing list to default carton size",
            action:=
            Async Function()
                Dim packingListCartonDataService = GetRequiredService(Of IPackingListCartonDataService)()

                Dim cartonSizeDataService = GetRequiredService(Of ICartonSizeDataService)()
                Dim cartonSize = Await cartonSizeDataService.GetOrCreateDefaultAsync(organizationId:=Z_OrganizationID, userId:=Z_UserID)
                Dim cartonSizeId = cartonSize.RowID.Value
                Dim cartonNo = cartonSize.SizeName

                Dim contactDataService = GetRequiredService(Of IContactDataService)()
                Dim defaultPacker = Await contactDataService.GetOrCreateDefaultAsync(organizationId:=Z_OrganizationID,
                    userId:=Z_UserID,
                    contactType:=ContactType.Packer)
                Dim packerId = defaultPacker.RowID.Value

                Dim packingListDataService = GetRequiredService(Of IPackingListDataService)()
                Dim packingList = Await packingListDataService.GetPackingListByOrderIdAsync(orderId:=palorderid)
                Dim packingListId = packingList.RowID.Value
                Dim packedDate = If(packingList.PackingListDate, Date.Now)
                Dim amount = packingList.GrandTotalItemGross

                Dim newPackingListCarton = PackingListCarton.NewPackingListCarton(organizationId:=Z_OrganizationID,
                    userId:=Z_UserID,
                    cartonSizeId:=cartonSizeId,
                    contactId:=packerId,
                    packingListId:=packingListId,
                    packedDate:=packedDate,
                    cartonNo:=cartonNo,
                    amount:=amount)

                Dim orderItems = packingList.Order.OrderItems
                For Each item In orderItems
                    Dim newPackingListCartonItem = PackingListCartonItem.NewPackingListCartonItem(organizationId:=Z_OrganizationID,
                        userId:=Z_UserID,
                        orderItemId:=item.RowID.Value,
                        quantity:=item.QtyOrdered)

                    newPackingListCarton.AddPackingListCartonItems(packingListCartonItems:=New List(Of PackingListCartonItem) From {newPackingListCartonItem})
                Next

                Await packingListCartonDataService.SaveManyAsync(userId:=Z_UserID, added:=New List(Of PackingListCarton) From {newPackingListCarton})
            End Function)
    End Function

End Class