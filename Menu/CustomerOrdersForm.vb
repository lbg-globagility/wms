Imports Microsoft.Extensions.DependencyInjection
Imports MySql.Data.MySqlClient
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Repositories

Public Class CustomerOrdersForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim printdataset As New DataSetA.SetADataTable
    Dim printdatatable As New DataTable
    Dim sqlquery As String
    Dim itemno, rowscount As Integer
    Dim cue, searchmode, coorderno As String
    Dim coincompleteqtyavailablecue As Boolean
    Dim cobundlesku, cobundleunitofmeasure As String
    Dim cooverallsrp, cototalsrp, coitotalprice As Decimal
    Dim spagenum, countpagenum, numofpages, validpages As Integer
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal
    Dim simplesearchphrase, datephrase, commonphrase, pagefilter1, pagefilter2, pagefilter3, pagefilter4 As String
    Dim cototalqtyordered, coqtyordered, coitotalqtyordered, coiqtyordered, cototalqtydelivered, cototalqtypicked As Integer
    Dim cocustomerid, coorderid, coproductcolorsizesid, coproductid, coproductbundleid, coorderitemid, cobranchid, covendorid, cocombinecodingid As Integer
    Private _agents As List(Of Contact)
    Private _systemOwner As SystemOwner
    Private ReadOnly _noAgent As Contact = Contact.BlankAgent(organizationId:=Z_OrganizationID)

    Private Async Sub CustomerOrdersForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        If IsThurston Then
            SplitContainer3.Panel1Collapsed = True
            Panel1.Visible = True
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            Await CallAutoPopulate()
            displayCustomerOrderList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default

        Await LoadInventoryLocations()
    End Sub

    Private Async Function GetAgentsAsync() As Task
        Dim contactDataService = GetRequiredService(Of IContactDataService)()

        _agents = Await contactDataService.GetAgentsAsync(organizationId:=Z_OrganizationID)

        Dim agentDataSource = New List(Of Contact) From {_noAgent}
        agentDataSource.AddRange(_agents)

        cboAgent.ValueMember = "RowID"
        cboAgent.DisplayMember = "FullNameLastNameFirst"
        cboAgent.DataSource = agentDataSource
    End Function

    Private Sub CustomerOrdersForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Sub callAutoComplete()
        globalautocompleteAccountName(cboCustomerName, "Customer", "AND a.`status` = 'Active'", Me)
        globalautocompleteBranchCodeName(cboBranchCodeNameInfo, Me)
        globalautocompleteVendorCodeName(cboVendorCodeNameInfo, Me)
        globalautocompleteClassDescription(cboClassDescription, Me)
        globalautocompleteListOfValues(cboTags, "Tags", Me)
    End Sub

    Private Async Function CallAutoPopulate() As Task
        autopopulatecboSearch()
        autopopulatecboBy()
        globalautopopulateAccountName(cboCustomerName, "Customer", "AND a.status = 'Active'", Me)
        globalautopopulateBranchCodeName(cboBranchCodeNameInfo, Me)
        globalautopopulateVendorCodeName(cboVendorCodeNameInfo, Me)
        globalautopopulateClassDescription(cboClassDescription, Me)
        globalautopopulateListOfValues(cboTags, "Tags", Me)
        autopopulateTags()
        autoPopulateCustomerOrderType()
        Await GetAgentsAsync()
    End Function

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            cue = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearCustomerOrderInformation()
            clearAddProductA()
            clearAddProductB()
            clearCustomerOrderItems()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visibleCustomerOrderItems(fraud)
            visibleGB(fraud, fraud, fraud, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud, fraud, fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRightPage()
        Try
            cue = ""
            clearCustomerOrderInformation()
            clearAddProductA()
            clearAddProductB()
            clearCustomerOrderItems()
            clearDatagrids()
            enableGB(legit, fraud, fraud)
            visibleCustomerOrderItems(fraud)
            visibleGB(fraud, fraud, fraud, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud, fraud, fraud, fraud)
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
            cboSearch4.Text = ""
            cboDate.SelectedItem = Nothing
            cboSearch1.SelectedItem = Nothing
            cboSearch2.SelectedItem = Nothing
            cboSearch3.SelectedItem = Nothing
            cboSearch4.SelectedItem = Nothing
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
            cboSearch3.SelectedItem = Nothing
            cboSearch2.Items.Clear() : cboSearch2.AutoCompleteCustomSource.Clear()
            cboSearch2.Text = "" : cboSearch2.SelectedItem = Nothing
            cboSearch4.Items.Clear() : cboSearch4.AutoCompleteCustomSource.Clear()
            cboSearch4.Text = "" : cboSearch4.SelectedItem = Nothing
            dtpFromSearch.Value = Now.Date.AddDays(-(Now.Day) + 1)
            dtpToSearch.Value = Now.Date
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearCustomerOrderInformation()
        Try
            txtCustomerOrderNo.Text = ""
            txtPONo.Text = ""
            txtSIDRNo.Text = ""
            txtStatus.Text = ""
            dtpCustomerOrderDate.Value = Now.Date
            dtpDeliveryDate.Value = Now.Date
            dtpEndDate.Value = Now.Date
            txtDateSubmitted.Text = ""
            cboCustomerName.Text = ""
            txtDeliveryAddress.Text = ""
            cboBranchCodeNameInfo.Text = ""
            cboVendorCodeNameInfo.Text = ""
            cboClassDescription.Text = ""
            txtDeliveryHours.Text = ""
            txtComments.Text = ""
            txtPickListNo.Text = ""
            txtLineUpNos.Text = ""
            cboCustomerName.SelectedItem = Nothing
            cboBranchCodeNameInfo.SelectedItem = Nothing
            cboVendorCodeNameInfo.SelectedItem = Nothing
            cboClassDescription.SelectedItem = Nothing
            cboCustomerOrderType.SelectedItem = Nothing
            cboAgent.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearAddProductA()
        Try
            cboBy.Text = ""
            cboByPhrase.Text = ""
            txtQtyOrdered.Text = ""
            cboTags.Text = ""
            cboTags.SelectedItem = Nothing
            cboBy.SelectedItem = Nothing
            cboByPhrase.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearAddProductB()
        Try
            txtBundleSRP.Text = ""
            txtOverallQty.Text = ""
            txtOverallPrice.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearCustomerOrderItems()
        Try
            chkOtherInfo.Checked = fraud
            lnkEditBundleItems.Visible = fraud
            txtTotalItems.Text = ""
            txtTotalQty.Text = ""
            txtTotalPrice.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearDatagrids()
        Try
            dgProductColorSizes.Rows.Clear()
            dgProductColors.Rows.Clear()
            dgProductSizes.Rows.Clear()
            dgBundleItems.Rows.Clear()
            dgCustomerOrderItems.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbCustomerOrderList.Enabled = enable1
            gbCustomerOrderInformation.Enabled = enable2
            gbCustomerOrderItems.Enabled = enable2
            gbAddProducts.Enabled = enable3
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableANDvisibleMS(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean, ByVal enable4 As Boolean, ByVal visible1 As Boolean, ByVal visible2 As Boolean)
        Try
            msNew.Enabled = enable1
            msSave.Enabled = enable2
            msDuplicate.Enabled = enable3
            msSubmit.Enabled = enable4
            msCancel.Visible = visible1
            msOrder.Visible = visible2
            msPrint.Enabled = fraud
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub visibleCustomerOrderItems(ByVal visible1 As Boolean)
        Try
            ci_unitofmeasure.Visible = visible1
            ci_qtypicked.Visible = visible1
            ci_qtydelivered.Visible = visible1
            ci_type.Visible = visible1
            ci_remarks.Visible = visible1
            ci_verifiedby.Visible = visible1
            ci_verifieddate.Visible = visible1
            ci_packedby.Visible = visible1
            ci_packeddate.Visible = visible1
            ci_deliveredby.Visible = visible1
            ci_delivereddate.Visible = visible1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub visibleGB(ByVal visible1 As Boolean, ByVal visible2 As Boolean, ByVal visible3 As Boolean, ByVal visible4 As Boolean, ByVal visible5 As Boolean)
        Try
            dgProductColorSizes.Visible = visible1
            dgProductColors.Visible = visible2
            dgProductSizes.Visible = visible2
            dgBundleItems.Visible = visible3
            lblSRP.Visible = visible3
            txtBundleSRP.Visible = visible3
            lblOverallQty.Visible = visible4
            txtOverallQty.Visible = visible4
            lblOverallPrice.Visible = visible5
            lblOverallPesoSign.Visible = visible5
            txtOverallPrice.Visible = visible5
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Click"

    Private Async Sub tsrefreshperformclick()
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            Await CallAutoPopulate()
            displayCustomerOrderList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub dgCustomerOrderListPerformClick()
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerOrderList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearCustomerOrderInformation()
                clearAddProductA()
                clearAddProductB()
                clearCustomerOrderItems()
                clearDatagrids()
                visibleCustomerOrderItems(fraud)
                visibleGB(fraud, fraud, fraud, fraud, fraud)
                displayCustomerOrderInformation(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                displayCustomerOrderItems(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                customerorderitemscomputations() : colorCoding()
                If txtStatus.Text = "New" Then
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, legit, legit, fraud, legit)
                    msOrder.Text = "Cancel Order"
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud, fraud, legit)
                    msOrder.Text = "Re-Open Order"
                Else
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, legit, fraud, fraud, fraud)
                    If LTrim(txtSIDRNo.Text) <> "" Then
                        msPrint.Enabled = legit
                    End If
                End If
                txtPONo.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAddperformclick()
        Try
            errProvider.Clear()
            If cboBy.Text <> "" Then
                If LTrim(cboByPhrase.Text) = "" Then
                    errProvider.SetError(cboByPhrase, "Please fill-up this box.")
                    cboByPhrase.Focus()
                    Exit Try
                ElseIf cboBy.Text = "BundleName" Then
                    If Not IsNumeric(txtQtyOrdered.Text) Then
                        errProvider.SetError(txtQtyOrdered, "Please use numbers for qty. ordered")
                        txtQtyOrdered.Focus()
                        Exit Try
                    End If
                    If dgBundleItems.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the bundle name.")
                        cboByPhrase.Focus()
                    Else
                        checkCustomerOrderItemsC()
                    End If
                ElseIf cboBy.Text = "Combination" Then
                    If Not IsNumeric(txtQtyOrdered.Text) Then
                        errProvider.SetError(txtQtyOrdered, "Please use numbers for qty. ordered")
                        txtQtyOrdered.Focus()
                        Exit Try
                    End If
                    If dgProductColorSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the combination code.")
                        cboByPhrase.Focus()
                    Else
                        checkCustomerOrderItemsA()
                    End If
                ElseIf cboBy.Text = "ProductCode" Then
                    If dgProductSizes.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the sizes.")
                        cboByPhrase.Focus()
                    Else
                        checkCustomerOrderItemsB()
                    End If
                ElseIf cboBy.Text = "SKU" Then
                    If Not IsNumeric(txtQtyOrdered.Text) Then
                        errProvider.SetError(txtQtyOrdered, "Please use numbers for qty. ordered")
                        txtQtyOrdered.Focus()
                        Exit Try
                    End If
                    If dgProductColorSizes.Rows.Count = 0 And dgBundleItems.Rows.Count = 0 Then
                        errProvider.SetError(cboByPhrase, "System cannot find the sku.")
                        cboByPhrase.Focus()
                    Else
                        If dgProductColorSizes.Rows.Count <> 0 Then
                            checkCustomerOrderItemsA()
                        ElseIf dgBundleItems.Rows.Count <> 0 Then
                            checkCustomerOrderItemsC()
                        End If
                    End If
                End If
            Else
                errProvider.SetError(cboBy, "Please choose among the options given in this box.")
                cboBy.Focus()
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Computations"

    Sub getPickListOrderID(ByVal iorderid As Integer, ByVal iorderitemid As Integer)
        Try
            cototalqtydelivered = 0 : cototalqtypicked = 0
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(plo.rowid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.orderitemid = " & iorderitemid & " AND plo.orderid = " & iorderid & " AND (plo.`status` != 'Inactive' AND plo.`status` != 'Cancelled') ")
            If dtGid.Rows.Count <> 0 Then
                getTotalQtyPicked(CInt(dtGid.Rows(0)(0)))
                getTotalQtyDelivered(CInt(dtGid.Rows(0)(0)))
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getTotalQtyDelivered(ByVal ipicklistorderid As Integer)
        Try
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pli.qtydelivered),0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND (pli.`status` != 'Inactive' AND pli.`status` != 'Cancelled') ")
            If dtGtq.Rows.Count <> 0 Then
                cototalqtydelivered = dtGtq.Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getTotalQtyPicked(ByVal ipicklistorderid As Integer)
        Try
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pli.qtypicked),0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND (pli.`status` != 'Inactive' AND pli.`status` != 'Cancelled') ")
            If dtGtq.Rows.Count <> 0 Then
                cototalqtypicked = dtGtq.Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub addproductcomputations()
        Try
            cototalqtyordered = 0 : coqtyordered = 0 : cooverallsrp = 0.0 : cototalsrp = 0.0
            If IsNumeric(txtQtyOrdered.Text) Then
                coqtyordered = CInt(txtQtyOrdered.Text)
            Else
                coqtyordered = 0
            End If
            If dgProductColorSizes.Visible = legit Then
                If dgProductColorSizes.Rows.Count <> 0 Then
                    For i = 0 To dgProductColorSizes.Rows.Count - 1
                        If IsNumeric(dgProductColorSizes.Rows(i).Cells("pcs_srp").Value) Then
                            cototalsrp = cototalsrp + CDec(dgProductColorSizes.Rows(i).Cells("pcs_srp").Value)
                        End If
                    Next
                End If
                cooverallsrp = cototalsrp * coqtyordered
            ElseIf dgProductSizes.Visible = legit Then
                If dgProductSizes.Rows.Count <> 0 Then
                    For i = 0 To dgProductSizes.Rows.Count - 1
                        If IsNumeric(dgProductSizes.Rows(i).Cells("s_qtyordered").Value) Then
                            coqtyordered = CInt(dgProductSizes.Rows(i).Cells("s_qtyordered").Value)
                            cototalqtyordered = cototalqtyordered + CInt(dgProductSizes.Rows(i).Cells("s_qtyordered").Value)
                        Else
                            coqtyordered = 0
                        End If
                        If IsNumeric(dgProductSizes.Rows(i).Cells("s_srp").Value) Then
                            dgProductSizes.Rows(i).Cells("s_totalprice").Value = coqtyordered * CDec(dgProductSizes.Rows(i).Cells("s_srp").Value)
                        Else
                            dgProductSizes.Rows(i).Cells("s_totalprice").Value = 0.0
                        End If
                        If IsNumeric(dgProductSizes.Rows(i).Cells("s_totalprice").Value) Then
                            cooverallsrp = cooverallsrp + CDec(dgProductSizes.Rows(i).Cells("s_totalprice").Value)
                        End If
                    Next
                End If
            ElseIf dgBundleItems.Visible = legit Then
                If dgBundleItems.Rows.Count <> 0 Then
                    For i = 0 To dgBundleItems.Rows.Count - 1
                        If IsNumeric(dgBundleItems.Rows(i).Cells("bi_qtybundle").Value) Then
                            dgBundleItems.Rows(i).Cells("bi_totalqty").Value = coqtyordered * CInt(dgBundleItems.Rows(i).Cells("bi_qtybundle").Value)
                        Else
                            dgBundleItems.Rows(i).Cells("bi_totalqty").Value = 0
                        End If
                        If IsNumeric(dgBundleItems.Rows(i).Cells("bi_totalqty").Value) Then
                            cototalqtyordered = cototalqtyordered + CInt(dgBundleItems.Rows(i).Cells("bi_totalqty").Value)
                        End If
                    Next
                End If
                cooverallsrp = coqtyordered * If(IsNumeric(txtBundleSRP.Text), CDec(txtBundleSRP.Text), 0.0)
            End If
            txtOverallQty.Text = Format(cototalqtyordered, "#,##0")
            txtOverallPrice.Text = Format(cooverallsrp, "#,##0.00")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub customerorderitemscomputations()
        Try
            coitotalqtyordered = 0 : coiqtyordered = 0 : coitotalprice = 0.0
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtyordered").Value) Then
                        coiqtyordered = CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtyordered").Value)
                        coitotalqtyordered = coitotalqtyordered + CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtyordered").Value)
                    Else
                        coiqtyordered = 0
                    End If
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_srp").Value) Then
                        dgCustomerOrderItems.Rows(i).Cells("ci_totalprice").Value = Math.Round(coiqtyordered * CDec(dgCustomerOrderItems.Rows(i).Cells("ci_srp").Value), 2)
                    Else
                        dgCustomerOrderItems.Rows(i).Cells("ci_totalprice").Value = 0.0
                    End If
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_totalprice").Value) Then
                        coitotalprice = coitotalprice + CDec(dgCustomerOrderItems.Rows(i).Cells("ci_totalprice").Value)
                    End If
                Next
            End If
            txtTotalItems.Text = dgCustomerOrderItems.Rows.Count
            txtTotalQty.Text = Format(coitotalqtyordered, "#,##0")
            txtTotalPrice.Text = Format(coitotalprice, "#,##0.00")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(co.rowid),0) FROM orders co WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' ")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(co.rowid),0) FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' " &
                            "AND (co.ordernumber LIKE ""%" & esearchstring & "%"" OR co.referencenumber LIKE ""%" & esearchstring & "%"" OR co.status LIKE ""%" & esearchstring & "%"" OR cu.companyname LIKE ""%" & esearchstring & "%"") ")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(co.rowid),0) FROM orders co WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' AND " &
                            "(" & edatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                            "" & edatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) ")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(co.rowid),0) FROM orders co WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' AND " & ecommonstring & " " & edatesearch & " ")
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
            If icommonbox.Text = "CustomerName" Then
                getCustomerID(icommonstring, Me)
                cocustomerid = globalcustomerid
                commonphrase = "co.accountid = " & cocustomerid & ""
            ElseIf icommonbox.Text = "Status" Then
                commonphrase = "co.status = """ & icommonstring & """"
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

    Sub autocompleteCustomerName(ByVal icombobox As ComboBox)
        Try
            Dim customername As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'') AS 'customername' FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' GROUP BY cu.rowid ORDER BY cu.companyname ", conn)
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

    Sub autocompleteStatus(ByVal icombobox As ComboBox)
        Try
            Dim costatus As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(co.status,'') AS 'costatus' FROM orders co WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' GROUP BY co.status ORDER BY co.status ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                costatus.Add(ds.Tables(0).Rows(i)("costatus").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = costatus
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
            cboDate.Items.Add("OrderDate")
            cboDate.Items.Add("TargetDate")
            cboDate.Items.Add("")
            cboSearch1.Items.Clear()
            cboSearch3.Items.Clear()
            cboSearch1.Items.Add("CustomerName")
            cboSearch1.Items.Add("Status")
            cboSearch3.Items.Add("CustomerName")
            cboSearch3.Items.Add("Status")
            cboSearch1.Items.Add("")
            cboSearch3.Items.Add("")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autopopulatecboBy()
        Try
            cboBy.Items.Clear()
            cboBy.Items.Add("BundleName")
            cboBy.Items.Add("Combination")
            cboBy.Items.Add("ProductCode")
            cboBy.Items.Add("SKU")
            cboBy.Items.Add("")
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
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'') AS 'customername' FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' GROUP BY cu.accountno ORDER BY cu.companyname "
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
            Dim sql1 As String = "SELECT COALESCE(co.status,'') AS 'costatus' FROM orders co WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' GROUP BY co.status ORDER BY co.status "
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

    Sub autopopulateTags()
        Try
            ci_tags.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT lic FROM listofvalues WHERE type = 'Tags' ORDER BY lic "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                ci_tags.Items.Add(reader1(0).ToString())
            End While
            ci_tags.Items.Add("")
            reader1.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autoPopulateCustomerOrderType()
        Dim customerOrderTypes = [Enum].GetValues(GetType(InventoryLocationType))
        cboCustomerOrderType.DataSource = customerOrderTypes

        'cboCustomerOrderType.Items.Clear()
        'For Each type In customerOrderTypes
        '    cboCustomerOrderType.Items.Add(type)
        'Next
    End Sub

    Private Async Function LoadInventoryLocations() As Task
        Dim inventoryLocationRepository = GetRequiredService(Of IInventoryLocationRepository)()
        Dim inventoryLocations = Await inventoryLocationRepository.GetAllByOrganizationIdAsync(Z_OrganizationID)

        'Dim dataSource = New List(Of WarehouseManagementSystem.Core.Entities.InventoryLocation) From {WarehouseManagementSystem.Core.Entities.InventoryLocation.NewInventoryLocation(organizationId:=Z_OrganizationID, name:=String.Empty, type:=InventoryLocationType.Damage)}
        'dataSource.AddRange(inventoryLocations)

        cboInventoryLocation.ValueMember = "RowID"
        cboInventoryLocation.DisplayMember = "Name"
        cboInventoryLocation.DataSource = inventoryLocations
    End Function

#End Region

#Region "Datagrids"

    Sub displayCustomerOrderList(ByVal istartpage As Integer)
        Try
            dgCustomerOrderList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT co.rowid,COALESCE(co.ordernumber,''),DATE_FORMAT(co.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'')," &
                        "COALESCE(co.status,''),COALESCE(co.referencenumber,'') FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' " &
                        "ORDER BY co.ordernumber DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCustomerOrderList.Rows.Add()
                    dgCustomerOrderList.Item(co_rowid.Index, n).Value = reader1(0)
                    dgCustomerOrderList.Item(co_customerorderno.Index, n).Value = reader1(1)
                    dgCustomerOrderList.Item(co_customerorderdate.Index, n).Value = reader1(2)
                    dgCustomerOrderList.Item(co_customername.Index, n).Value = reader1(3)
                    dgCustomerOrderList.Item(co_status.Index, n).Value = reader1(4)
                    dgCustomerOrderList.Item(co_pono.Index, n).Value = reader1(5)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCustomerOrderList.Columns("co_customerorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderList.Columns("co_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderList.Columns("co_customerorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderList.Columns("co_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCustomerOrderList.Rows.Count <> 0 Then
                dgCustomerOrderList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgCustomerOrderList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT co.rowid,COALESCE(co.ordernumber,''),DATE_FORMAT(co.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'')," &
                        "COALESCE(co.status,''),COALESCE(co.referencenumber,'') FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' AND " &
                        "(co.ordernumber LIKE ""%" & isearchphrase & "%"" OR co.referencenumber LIKE ""%" & isearchphrase & "%"" OR co.status LIKE ""%" & isearchphrase & "%"" OR cu.companyname LIKE ""%" & isearchphrase & "%"") " &
                        "ORDER BY co.ordernumber DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCustomerOrderList.Rows.Add()
                    dgCustomerOrderList.Item(co_rowid.Index, n).Value = reader1(0)
                    dgCustomerOrderList.Item(co_customerorderno.Index, n).Value = reader1(1)
                    dgCustomerOrderList.Item(co_customerorderdate.Index, n).Value = reader1(2)
                    dgCustomerOrderList.Item(co_customername.Index, n).Value = reader1(3)
                    dgCustomerOrderList.Item(co_status.Index, n).Value = reader1(4)
                    dgCustomerOrderList.Item(co_pono.Index, n).Value = reader1(5)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCustomerOrderList.Columns("co_customerorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderList.Columns("co_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderList.Columns("co_customerorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderList.Columns("co_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCustomerOrderList.Rows.Count <> 0 Then
                dgCustomerOrderList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayDateSearch(ByVal istartpage As Integer, ByVal idatesearch As String)
        Try
            dgCustomerOrderList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT co.rowid,COALESCE(co.ordernumber,''),DATE_FORMAT(co.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'')," &
                        "COALESCE(co.status,''),COALESCE(co.referencenumber,'') FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' AND " &
                        "(" & idatesearch & " >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                        "" & idatesearch & " <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) " &
                        "GROUP BY co.rowid ORDER BY co.ordernumber DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCustomerOrderList.Rows.Add()
                    dgCustomerOrderList.Item(co_rowid.Index, n).Value = reader1(0)
                    dgCustomerOrderList.Item(co_customerorderno.Index, n).Value = reader1(1)
                    dgCustomerOrderList.Item(co_customerorderdate.Index, n).Value = reader1(2)
                    dgCustomerOrderList.Item(co_customername.Index, n).Value = reader1(3)
                    dgCustomerOrderList.Item(co_status.Index, n).Value = reader1(4)
                    dgCustomerOrderList.Item(co_pono.Index, n).Value = reader1(5)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCustomerOrderList.Columns("co_customerorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderList.Columns("co_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderList.Columns("co_customerorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderList.Columns("co_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCustomerOrderList.Rows.Count <> 0 Then
                dgCustomerOrderList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCommonPhrase(ByVal icommonphrase As String, ByVal idatesearch As String, ByVal istartpage As Integer)
        Try
            dgCustomerOrderList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT co.rowid,COALESCE(co.ordernumber,''),DATE_FORMAT(co.orderdate,'%d-%b-%Y'),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'')," &
                        "COALESCE(co.status,''),COALESCE(co.referencenumber,'') FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid WHERE co.organizationid = " & Z_OrganizationID & " " &
                        $"AND co.ordertype = '{OrderType.CO.ToString()}' AND " & icommonphrase & " " & idatesearch & " ORDER BY co.ordernumber DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCustomerOrderList.Rows.Add()
                    dgCustomerOrderList.Item(co_rowid.Index, n).Value = reader1(0)
                    dgCustomerOrderList.Item(co_customerorderno.Index, n).Value = reader1(1)
                    dgCustomerOrderList.Item(co_customerorderdate.Index, n).Value = reader1(2)
                    dgCustomerOrderList.Item(co_customername.Index, n).Value = reader1(3)
                    dgCustomerOrderList.Item(co_status.Index, n).Value = reader1(4)
                    dgCustomerOrderList.Item(co_pono.Index, n).Value = reader1(5)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCustomerOrderList.Columns("co_customerorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderList.Columns("co_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderList.Columns("co_customerorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderList.Columns("co_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCustomerOrderList.Rows.Count <> 0 Then
                dgCustomerOrderList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCustomerOrderInformation(ByVal icustomerorderid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(co.ordernumber,''),COALESCE(co.referencenumber,''),COALESCE(co.drnumber,''),COALESCE(co.status,''),COALESCE(DATE_FORMAT(co.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(co.targetdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(co.enddate,'%d-%b-%Y'),'')," &
                        "COALESCE(DATE_FORMAT(co.datesubmitted,'%d-%b-%Y'),''),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),''),COALESCE(co.customeraddress,''),COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(ve.companyname,''),' - ',COALESCE(ve.companycode,'')),''),COALESCE(CONCAT(COALESCE(cc.codename,''),' / ',COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),''),COALESCE(co.deliveryhours,'')," &
                        "COALESCE(co.comments,''),co.InventoryLocationID,co.AgentID,COALESCE(co.CustomerOrderType,''),IFNULL(il.`Type`,'') FROM orders co LEFT JOIN accounts cu ON co.accountid = cu.rowid LEFT JOIN branches bc ON co.branchid = bc.rowid LEFT JOIN companies ve ON co.companyid = ve.rowid LEFT JOIN combinecodings cc ON co.combinecodingid = cc.rowid " &
                        "LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid LEFT JOIN inventorylocations il ON il.RowID=co.InventoryLocationID WHERE co.rowid = " & icustomerorderid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtCustomerOrderNo.Text = reader1(0)
                    txtPONo.Text = reader1(1)
                    txtSIDRNo.Text = reader1(2)
                    txtStatus.Text = reader1(3)
                    dtpCustomerOrderDate.Text = reader1(4)
                    dtpDeliveryDate.Text = reader1(5)
                    dtpEndDate.Text = reader1(6)
                    txtDateSubmitted.Text = reader1(7)
                    cboCustomerName.Text = reader1(8)
                    txtDeliveryAddress.Text = reader1(9)
                    cboBranchCodeNameInfo.Text = reader1(10)
                    cboVendorCodeNameInfo.Text = reader1(11)
                    cboClassDescription.Text = reader1(12)
                    txtDeliveryHours.Text = reader1(13)
                    txtComments.Text = reader1(14)
                    cboAgent.SelectedValue = If(IsDBNull(reader1(16)), _noAgent.RowID, reader1(16))
                    cboCustomerOrderType.Text = reader1(18)
                    getPickListNoB(icustomerorderid, Me)
                    If globalpicklistno = 0 Then
                        txtPickListNo.Text = ""
                    Else
                        txtPickListNo.Text = globalpicklistno
                    End If
                    getLineUpNos(icustomerorderid, Me)
                    txtLineUpNos.Text = globallineupnos
                    cboInventoryLocation.SelectedValue = reader1(15)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayCustomerOrderItems(ByVal icustomerorderid As Integer)
        Try
            dgCustomerOrderItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ci.rowid,COALESCE(ci.productcolorsizeid,0),COALESCE(ci.productbundleid,0),COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(b.bundlename,''),COALESCE(c.colorname,''),COALESCE(pcs.size,'')," &
                    "COALESCE(pcs.seasoncode,''),COALESCE(ci.unitofmeasure,''),COALESCE(ci.qtyordered,0),COALESCE(ci.srp,0.0),COALESCE(pcs.sku,''),COALESCE(b.sku,''),COALESCE(ci.itemtype,''),COALESCE(ci.remarks,''),COALESCE(ci.status,'')," &
                    "COALESCE(CONCAT(COALESCE(vb.firstname,''),' ',COALESCE(vb.lastname,''),' - ',COALESCE(vb.rowid,'')),''),COALESCE(DATE_FORMAT(ci.verifieddate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(ci.packeddate,'%d-%b-%Y'),'')," &
                    "COALESCE(CONCAT(COALESCE(pa.firstname,''),' ',COALESCE(pa.middlename,''),' ',COALESCE(pa.lastname,''),' ',COALESCE(pa.suffix,''),' - ',COALESCE(pa.contactno,'')),''),COALESCE(DATE_FORMAT(ci.delivereddate,'%d-%b-%Y'),'')," &
                    "COALESCE(CONCAT(COALESCE(dr.firstname,''),' ',COALESCE(dr.middlename,''),' ',COALESCE(dr.lastname,''),' ',COALESCE(dr.suffix,''),' - ',COALESCE(dr.contactno,'')),''),COALESCE(ci.tags,''),COALESCE(ci.sku,'') FROM orderitems ci LEFT JOIN contacts pa ON ci.packedby = pa.rowid " &
                    "LEFT JOIN productbundles b ON ci.productbundleid = b.rowid LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid LEFT JOIN contacts dr ON ci.deliveredby = dr.rowid LEFT JOIN users vb ON ci.verifiedby = vb.rowid " &
                    "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE ci.orderid = " & icustomerorderid & " AND ci.organizationid = " & Z_OrganizationID & " " &
                    "AND ci.status != 'Inactive' AND ci.itemtype != 'BI' ORDER BY ci.rowid "
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
                        dgCustomerOrderItems.Item(ci_productcode.Index, n).Value = reader1(4)
                    Else
                        dgCustomerOrderItems.Item(ci_productcode.Index, n).Value = reader1(5)
                    End If
                    dgCustomerOrderItems.Item(ci_colorname.Index, n).Value = reader1(6)
                    dgCustomerOrderItems.Item(ci_size.Index, n).Value = reader1(7)
                    dgCustomerOrderItems.Item(ci_seasoncode.Index, n).Value = reader1(8)
                    dgCustomerOrderItems.Item(ci_unitofmeasure.Index, n).Value = reader1(9)
                    dgCustomerOrderItems.Item(ci_qtyordered.Index, n).Value = CInt(reader1(10))
                    dgCustomerOrderItems.Item(ci_srp.Index, n).Value = reader1(11)
                    If CInt(reader1(1)) <> 0 Then
                        If LTrim(CStr(reader1(24))) = "" Then
                            dgCustomerOrderItems.Item(ci_sku.Index, n).Value = reader1(12)
                        Else
                            dgCustomerOrderItems.Item(ci_sku.Index, n).Value = reader1(24)
                        End If
                    Else
                        dgCustomerOrderItems.Item(ci_sku.Index, n).Value = reader1(13)
                    End If
                    dgCustomerOrderItems.Item(ci_type.Index, n).Value = reader1(14)
                    dgCustomerOrderItems.Item(ci_remarks.Index, n).Value = reader1(15)
                    If CInt(reader1(1)) <> 0 Then
                        dgCustomerOrderItems.Item(ci_status.Index, n).Value = reader1(16)
                        dgCustomerOrderItems.Item(ci_verifiedby.Index, n).Value = reader1(17)
                        dgCustomerOrderItems.Item(ci_verifieddate.Index, n).Value = reader1(18)
                        dgCustomerOrderItems.Item(ci_packeddate.Index, n).Value = reader1(19)
                        dgCustomerOrderItems.Item(ci_packedby.Index, n).Value = reader1(20)
                        dgCustomerOrderItems.Item(ci_delivereddate.Index, n).Value = reader1(21)
                        dgCustomerOrderItems.Item(ci_deliveredby.Index, n).Value = reader1(22)
                        getPickListOrderID(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), CInt(reader1(0)))
                        dgCustomerOrderItems.Item(ci_qtypicked.Index, n).Value = cototalqtypicked
                        dgCustomerOrderItems.Item(ci_qtydelivered.Index, n).Value = cototalqtydelivered
                    Else
                        dgCustomerOrderItems.Item(ci_status.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_verifiedby.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_verifieddate.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_packedby.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_packeddate.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_deliveredby.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_delivereddate.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_qtypicked.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_qtydelivered.Index, n).Value = ""
                    End If
                    dgCustomerOrderItems.Item(ci_tags.Index, n).Value = reader1(23)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCustomerOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtypicked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtydelivered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_tags").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_verifieddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_delivereddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                dgCustomerOrderItems.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayProductsA(ByVal iproductcolorsizeid As Integer)
        Try
            dgProductColorSizes.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT * FROM vw_productcolorsizes WHERE rowid = " & iproductcolorsizeid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductColorSizes.Rows.Add()
                    dgProductColorSizes.Item(pcs_rowid.Index, n).Value = reader1(0)
                    dgProductColorSizes.Item(pcs_colorvalue.Index, n).Value = reader1(1)
                    dgProductColorSizes.Item(pcs_productcode.Index, n).Value = reader1(2)
                    dgProductColorSizes.Item(pcs_colorname.Index, n).Value = reader1(3)
                    dgProductColorSizes.Item(pcs_size.Index, n).Value = reader1(4)
                    dgProductColorSizes.Item(pcs_seasoncode.Index, n).Value = reader1(5)
                    dgProductColorSizes.Item(pcs_sku.Index, n).Value = reader1(6)
                    dgProductColorSizes.Item(pcs_srp.Index, n).Value = CDec(reader1(7))
                    dgProductColorSizes.Item(pcs_qtyavailable.Index, n).Value = CDec(reader1(8))
                    getTotalQtyOrderedA(CInt(reader1(0)), $"AND oi.`status` = 'New' AND o.`status` = 'Submitted To Warehouse' AND o.ordertype = '{OrderType.CO.ToString()}'", Me)
                    dgProductColorSizes.Item(pcs_qtyallocated.Index, n).Value = CDec(reader1(9)) + globaltotalqtyordered
                    dgProductColorSizes.Item(pcs_qtyreserve.Index, n).Value = CDec(reader1(10))
                    dgProductColorSizes.Item(pcs_qtyorderable.Index, n).Value = CDec(reader1(8)) - (CDec(reader1(9)) + globaltotalqtyordered)
                    dgProductColorSizes.Item(pcs_unitmeasure.Index, n).Value = reader1(11)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductColorSizes.Columns("pcs_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_qtyallocated").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_qtyorderable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_qtyreserve").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColorSizes.Columns("pcs_unitmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProductColorSizes.Rows.Count <> 0 Then
                dgProductColorSizes.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayProductsB(ByVal iproductid As Integer)
        Try
            dgProductColors.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pc.rowid,COALESCE(c.colorvalue,''),COALESCE(c.colorname,'') FROM productcolors pc LEFT JOIN colors c ON pc.colorid = c.rowid " &
                            "WHERE pc.organizationid = " & Z_OrganizationID & " AND pc.productid = " & iproductid & " AND pc.`status` = 'Active' ORDER BY c.colorname ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductColors.Rows.Add()
                    dgProductColors.Item(c_seqno.Index, n).Value = seqno
                    dgProductColors.Item(c_rowid.Index, n).Value = reader1(0)
                    dgProductColors.Item(c_colorvalue.Index, n).Value = reader1(1)
                    dgProductColors.Item(c_colorname.Index, n).Value = reader1(2)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductColors.Columns("c_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductColors.Columns("c_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProductColors.Rows.Count <> 0 Then
                dgProductColors.CurrentRow.Selected = False
            End If
            colorCoding()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayProductsC(ByVal iproductcolorid As Integer)
        Try
            dgProductSizes.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            'Dim sql1 As String = "SELECT pcs.rowid,COALESCE(pcs.size,0.0),COALESCE(pcs.seasoncode,''),COALESCE(p.unitprice,0.00),COALESCE(pcs.sku,'') FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " & _
            '            "LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.organizationid = " & Z_OrganizationID & " AND pcs.productcolorid = " & iproductcolorid & " AND pcs.status = 'Active' ORDER BY pcs.size ASC "
            Dim sql1 As String = "SELECT * FROM vw_productcolorsizes WHERE pcrowid = " & iproductcolorid & " AND organizationid = " & Z_OrganizationID & " AND pcsstatus = 'Active' ORDER BY size ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgProductSizes.Rows.Add()
                    dgProductSizes.Item(s_rowid.Index, n).Value = reader1(0)
                    dgProductSizes.Item(s_colorvalue.Index, n).Value = reader1(1)
                    dgProductSizes.Item(s_productcode.Index, n).Value = reader1(2)
                    dgProductSizes.Item(s_colorname.Index, n).Value = reader1(3)
                    dgProductSizes.Item(s_sizes.Index, n).Value = reader1(4)
                    dgProductSizes.Item(s_seasoncode.Index, n).Value = reader1(5)
                    dgProductSizes.Item(s_qtyordered.Index, n).Value = ""
                    dgProductSizes.Item(s_srp.Index, n).Value = CDec(reader1(7))
                    dgProductSizes.Item(s_totalprice.Index, n).Value = ""
                    dgProductSizes.Item(s_sku.Index, n).Value = reader1(6)
                    dgProductSizes.Item(s_qtyavailable.Index, n).Value = CDec(reader1(8))
                    getTotalQtyOrderedA(CInt(reader1(0)), $"AND oi.`status` = 'New' AND o.`status` = 'Submitted To Warehouse' AND o.ordertype = '{OrderType.CO.ToString()}'", Me)
                    dgProductSizes.Item(s_qtyallocated.Index, n).Value = CDec(reader1(9)) + globaltotalqtyordered
                    dgProductSizes.Item(s_qtyreserve.Index, n).Value = CDec(reader1(10))
                    dgProductSizes.Item(s_qtyorderable.Index, n).Value = CDec(reader1(8)) - (CDec(reader1(9)) + globaltotalqtyordered)
                    dgProductSizes.Item(s_unitofmeasure.Index, n).Value = reader1(11)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProductSizes.Columns("s_sizes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_qtyallocated").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_qtyorderable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_qtyreserve").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProductSizes.Columns("s_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProductSizes.Rows.Count <> 0 Then
                dgProductSizes.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayProductsD(ByVal iproductbundleid As Integer)
        Try
            dgBundleItems.Rows.Clear() : cobundlesku = "" : cobundleunitofmeasure = ""
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            'Dim sql1 As String = "SELECT bi.rowid,COALESCE(bi.productcolorsizeid,0),COALESCE(c.colorvalue,''),COALESCE(bi.qtyavailable,0),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,''),COALESCE(pb.srp,0.00) " & _
            '    "FROM productbundleitems bi LEFT JOIN productcolorsizes pcs ON bi.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " & _
            '    "LEFT JOIN productbundles pb ON bi.productbundleid = pb.rowid WHERE bi.productbundleid = " & iproductbundleid & " AND bi.organizationid = " & Z_OrganizationID & " AND bi.status = 'Active' ORDER BY p.productcode,c.colorname "
            Dim sql1 As String = "SELECT * FROM vw_bundleitems WHERE productbundleid = " & iproductbundleid & " AND organizationid = " & Z_OrganizationID & " AND bistatus = 'Active' ORDER BY productcode,colorname,size ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgBundleItems.Rows.Add()
                    dgBundleItems.Item(bi_seqno.Index, n).Value = seqno
                    dgBundleItems.Item(bi_rowid.Index, n).Value = reader1(0)
                    dgBundleItems.Item(bi_pcsrowid.Index, n).Value = reader1(1)
                    dgBundleItems.Item(bi_colorvalue.Index, n).Value = reader1(2)
                    dgBundleItems.Item(bi_qtybundle.Index, n).Value = reader1(3)
                    dgBundleItems.Item(bi_productcode.Index, n).Value = reader1(4)
                    dgBundleItems.Item(bi_colorname.Index, n).Value = reader1(5)
                    dgBundleItems.Item(bi_size.Index, n).Value = reader1(6)
                    dgBundleItems.Item(bi_seasoncode.Index, n).Value = reader1(7)
                    dgBundleItems.Item(bi_sku.Index, n).Value = reader1(8)
                    dgBundleItems.Item(bi_totalqty.Index, n).Value = ""
                    txtBundleSRP.Text = CDec(reader1(9))
                    dgBundleItems.Item(bi_qtyavailable.Index, n).Value = CDec(reader1(10))
                    getTotalQtyOrderedA(CInt(reader1(1)), $"AND oi.`status` = 'New' AND o.`status` = 'Submitted To Warehouse' AND o.ordertype = '{OrderType.CO.ToString()}'", Me)
                    dgBundleItems.Item(bi_qtyallocated.Index, n).Value = CDec(reader1(11)) + globaltotalqtyordered
                    dgBundleItems.Item(bi_qtyreserve.Index, n).Value = CDec(reader1(12))
                    dgBundleItems.Item(bi_qtyorderable.Index, n).Value = CDec(reader1(10)) - (CDec(reader1(11)) + globaltotalqtyordered)
                    cobundleunitofmeasure = CStr(reader1(13))
                    cobundlesku = CStr(reader1(17))
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgBundleItems.Columns("bi_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtybundle").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_totalqty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtyallocated").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtyorderable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgBundleItems.Columns("bi_qtyreserve").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgBundleItems.Rows.Count <> 0 Then
                dgBundleItems.CurrentRow.Selected = False
            End If
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
            If dgProductColorSizes.Rows.Count <> 0 Then
                For i As Integer = 0 To dgProductColorSizes.Rows.Count - 1
                    If CStr(dgProductColorSizes.Rows(i).Cells("pcs_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgProductColorSizes.Rows(i).Cells("pcs_colorvalue").Value))
                        dgProductColorSizes.Rows(i).Cells("pcs_color").Style.BackColor = readcolor
                    End If
                Next
            End If
            If dgProductColors.Rows.Count <> 0 Then
                For i As Integer = 0 To dgProductColors.Rows.Count - 1
                    If CStr(dgProductColors.Rows(i).Cells("c_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgProductColors.Rows(i).Cells("c_colorvalue").Value))
                        dgProductColors.Rows(i).Cells("c_color").Style.BackColor = readcolor
                    End If
                Next
            End If
            If dgBundleItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgBundleItems.Rows.Count - 1
                    If CStr(dgBundleItems.Rows(i).Cells("bi_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgBundleItems.Rows(i).Cells("bi_colorvalue").Value))
                        dgBundleItems.Rows(i).Cells("bi_color").Style.BackColor = readcolor
                    End If
                Next
            End If
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
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#End Region

#Region "Adding"

    Sub checkCustomerOrderItemsA()
        Try
            If dgProductColorSizes.Rows.Count <> 0 Then
                For a = 0 To dgProductColorSizes.Rows.Count - 1
                    If CInt(txtQtyOrdered.Text) > CInt(dgProductColorSizes.Rows(a).Cells("pcs_qtyorderable").Value) Then
                        If MessageBox.Show("Qty. Orderable is less than Qty. Order, do you want to proceed adding this item?", "Checking", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Exit For
                        Else
                            Exit Try
                        End If
                    End If
                Next
                For p = 0 To dgProductColorSizes.Rows.Count - 1
                    If dgCustomerOrderItems.Rows.Count <> 0 Then
                        rowscount = dgCustomerOrderItems.Rows.Count - 1
                        For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                            If dgCustomerOrderItems.Rows(i).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                errProvider.SetError(cboByPhrase, "Product is in the list already.")
                                cboByPhrase.Focus()
                                Exit Try
                            ElseIf rowscount = 0 Then
                                addCustomerOrderItemA(CInt(dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value), CStr(dgProductColorSizes.Rows(p).Cells("pcs_colorvalue").Value), CStr(dgProductColorSizes.Rows(p).Cells("pcs_productcode").Value), CStr(dgProductColorSizes.Rows(p).Cells("pcs_colorname").Value), CStr(dgProductColorSizes.Rows(p).Cells("pcs_size").Value),
                                        CStr(dgProductColorSizes.Rows(p).Cells("pcs_unitmeasure").Value), CStr(dgProductColorSizes.Rows(p).Cells("pcs_sku").Value), CStr(dgProductColorSizes.Rows(p).Cells("pcs_seasoncode").Value), CInt(txtQtyOrdered.Text), If(IsNumeric(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), CDec(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), 0.0), cboTags.Text)
                                For a = 0 To dgCustomerOrderItems.Rows.Count - 1
                                    dgCustomerOrderItems.CurrentRow.Selected = fraud
                                    If dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                        dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Selected = legit
                                        dgCustomerOrderItems.FirstDisplayedScrollingRowIndex = dgCustomerOrderItems.RowCount - 1
                                        Exit For
                                    End If
                                Next
                                cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQtyOrdered.Text = "" : cboByPhrase.Focus() : dgProductColorSizes.Rows.Clear()
                                cboTags.Text = "" : cboTags.SelectedItem = Nothing
                            End If
                            rowscount = rowscount - 1
                        Next
                    Else
                        addCustomerOrderItemA(CInt(dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value), CStr(dgProductColorSizes.Rows(p).Cells("pcs_colorvalue").Value), CStr(dgProductColorSizes.Rows(p).Cells("pcs_productcode").Value), CStr(dgProductColorSizes.Rows(p).Cells("pcs_colorname").Value), CStr(dgProductColorSizes.Rows(p).Cells("pcs_size").Value),
                                CStr(dgProductColorSizes.Rows(p).Cells("pcs_unitmeasure").Value), CStr(dgProductColorSizes.Rows(p).Cells("pcs_sku").Value), CStr(dgProductColorSizes.Rows(p).Cells("pcs_seasoncode").Value), CInt(txtQtyOrdered.Text), If(IsNumeric(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), CDec(dgProductColorSizes.Rows(p).Cells("pcs_srp").Value), 0.0), cboTags.Text)
                        For a = 0 To dgCustomerOrderItems.Rows.Count - 1
                            dgCustomerOrderItems.CurrentRow.Selected = fraud
                            If dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value = dgProductColorSizes.Rows(p).Cells("pcs_rowid").Value Then
                                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Selected = legit
                                dgCustomerOrderItems.FirstDisplayedScrollingRowIndex = dgCustomerOrderItems.RowCount - 1
                                Exit For
                            End If
                        Next
                        cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQtyOrdered.Text = "" : cboByPhrase.Focus() : dgProductColorSizes.Rows.Clear()
                        cboTags.Text = "" : cboTags.SelectedItem = Nothing
                    End If
                Next
                itemno = 1 : colorCoding() : addproductcomputations() : customerorderitemscomputations()
                For i As Integer = 0 To dgCustomerOrderItems.Rows.Count - 1
                    dgCustomerOrderItems.Rows(i).Cells("ci_seqno").Value = itemno
                    itemno = itemno + 1
                Next i
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub checkCustomerOrderItemsB()
        Try
            If dgProductSizes.Rows.Count <> 0 Then
                For a = 0 To dgProductSizes.Rows.Count - 1
                    If IsNumeric(dgProductSizes.Rows(a).Cells("s_qtyordered").Value) Then
                        If CInt(dgProductSizes.Rows(a).Cells("s_qtyordered").Value) > CInt(dgProductSizes.Rows(a).Cells("s_qtyorderable").Value) Then
                            If MessageBox.Show("Qty. Orderable is less than Qty. Order, do you want to proceed adding this item/s?", "Checking", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                Exit For
                            Else
                                Exit Try
                            End If
                        End If
                    End If
                Next
                For p = 0 To dgProductSizes.Rows.Count - 1
                    If IsNumeric(dgProductSizes.Rows(p).Cells("s_qtyordered").Value) Then
                        If CInt(dgProductSizes.Rows(p).Cells("s_qtyordered").Value) > 0 Then
                            If dgCustomerOrderItems.Rows.Count <> 0 Then
                                rowscount = dgCustomerOrderItems.Rows.Count - 1
                                For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                                    If dgCustomerOrderItems.Rows(i).Cells("ci_pcsrowid").Value = dgProductSizes.Rows(p).Cells("s_rowid").Value Then
                                        Exit For
                                    ElseIf rowscount = 0 Then
                                        ' addCustomerOrderItemA(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CInt(dgProductSizes.Rows(p).Cells("s_qtyordered").Value), If(IsNumeric(dgProductSizes.Rows(p).Cells("s_srp").Value), CDec(dgProductSizes.Rows(p).Cells("s_srp").Value), 0.0))
                                        addCustomerOrderItemA(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CStr(dgProductSizes.Rows(p).Cells("s_colorvalue").Value), CStr(dgProductSizes.Rows(p).Cells("s_productcode").Value), CStr(dgProductSizes.Rows(p).Cells("s_colorname").Value), CStr(dgProductSizes.Rows(p).Cells("s_sizes").Value),
                                             CStr(dgProductSizes.Rows(p).Cells("s_unitofmeasure").Value), CStr(dgProductSizes.Rows(p).Cells("s_sku").Value), CStr(dgProductSizes.Rows(p).Cells("s_seasoncode").Value), CInt(dgProductSizes.Rows(p).Cells("s_qtyordered").Value), If(IsNumeric(dgProductSizes.Rows(p).Cells("s_srp").Value), CDec(dgProductSizes.Rows(p).Cells("s_srp").Value), 0.0), cboTags.Text)
                                    End If
                                    rowscount = rowscount - 1
                                Next
                            Else
                                '  addCustomerOrderItemA(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CInt(dgProductSizes.Rows(p).Cells("s_qtyordered").Value), If(IsNumeric(dgProductSizes.Rows(p).Cells("s_srp").Value), CDec(dgProductSizes.Rows(p).Cells("s_srp").Value), 0.0))
                                addCustomerOrderItemA(CInt(dgProductSizes.Rows(p).Cells("s_rowid").Value), CStr(dgProductSizes.Rows(p).Cells("s_colorvalue").Value), CStr(dgProductSizes.Rows(p).Cells("s_productcode").Value), CStr(dgProductSizes.Rows(p).Cells("s_colorname").Value), CStr(dgProductSizes.Rows(p).Cells("s_sizes").Value),
                                        CStr(dgProductSizes.Rows(p).Cells("s_unitofmeasure").Value), CStr(dgProductSizes.Rows(p).Cells("s_sku").Value), CStr(dgProductSizes.Rows(p).Cells("s_seasoncode").Value), CInt(dgProductSizes.Rows(p).Cells("s_qtyordered").Value), If(IsNumeric(dgProductSizes.Rows(p).Cells("s_srp").Value), CDec(dgProductSizes.Rows(p).Cells("s_srp").Value), 0.0), cboTags.Text)
                            End If
                        End If
                    End If
                Next
                itemno = 1 : colorCoding() : addproductcomputations() : customerorderitemscomputations()
                For i As Integer = 0 To dgCustomerOrderItems.Rows.Count - 1
                    dgCustomerOrderItems.Rows(i).Cells("ci_seqno").Value = itemno
                    itemno = itemno + 1
                Next i
                If dgCustomerOrderItems.Rows.Count <> 0 Then
                    dgCustomerOrderItems.CurrentRow.Selected = False
                    dgCustomerOrderItems.FirstDisplayedScrollingRowIndex = dgCustomerOrderItems.RowCount - 1
                End If
                cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQtyOrdered.Text = "" : cboByPhrase.Focus()
                cboTags.Text = "" : cboTags.SelectedItem = Nothing
                dgProductColors.Rows.Clear() : dgProductSizes.Rows.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub checkCustomerOrderItemsC()
        Try
            If cboBy.Text = "BundleName" Then
                getProductBundleIDA(cboByPhrase.Text, Me)
                coproductbundleid = globalproductbundleid
            ElseIf cboBy.Text = "SKU" Then
                getProductBundleSKUA(cboByPhrase.Text, Me)
                coproductbundleid = globalskuid
            End If
            If coproductbundleid = 0 Then
                errProvider.SetError(cboByPhrase, "System cannot find the bundle name.")
                cboByPhrase.Focus()
                Exit Try
            End If
            If dgBundleItems.Rows.Count <> 0 Then
                For a = 0 To dgBundleItems.Rows.Count - 1
                    If IsNumeric(dgBundleItems.Rows(a).Cells("bi_totalqty").Value) Then
                        If CInt(dgBundleItems.Rows(a).Cells("bi_totalqty").Value) > CInt(dgBundleItems.Rows(a).Cells("bi_qtyorderable").Value) Then
                            If MessageBox.Show("Qty. Orderable is less than Qty. Order, do you want to proceed adding this item?", "Checking", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                Exit For
                            Else
                                Exit Try
                            End If
                        End If
                    End If
                Next
                If dgCustomerOrderItems.Rows.Count <> 0 Then
                    rowscount = dgCustomerOrderItems.Rows.Count - 1
                    For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                        If dgCustomerOrderItems.Rows(i).Cells("ci_bid").Value = coproductbundleid Then
                            errProvider.SetError(cboByPhrase, "Bundle is in the list already.")
                            cboByPhrase.Focus()
                            Exit Try
                        ElseIf rowscount = 0 Then
                            addCustomerOrderItemB(coproductbundleid, cboByPhrase.Text, CInt(txtQtyOrdered.Text), If(IsNumeric(txtBundleSRP.Text), CDec(txtBundleSRP.Text), 0.0), cboTags.Text)
                            For a = 0 To dgCustomerOrderItems.Rows.Count - 1
                                dgCustomerOrderItems.CurrentRow.Selected = fraud
                                If dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value = coproductbundleid Then
                                    dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Selected = legit
                                    dgCustomerOrderItems.FirstDisplayedScrollingRowIndex = dgCustomerOrderItems.RowCount - 1
                                    Exit For
                                End If
                            Next
                            cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQtyOrdered.Text = "" : cboByPhrase.Focus() : dgBundleItems.Rows.Clear()
                            cboTags.Text = "" : cboTags.SelectedItem = Nothing
                        End If
                        rowscount = rowscount - 1
                    Next
                Else
                    addCustomerOrderItemB(coproductbundleid, cboByPhrase.Text, CInt(txtQtyOrdered.Text), If(IsNumeric(txtBundleSRP.Text), CDec(txtBundleSRP.Text), 0.0), cboTags.Text)
                    For a = 0 To dgCustomerOrderItems.Rows.Count - 1
                        dgCustomerOrderItems.CurrentRow.Selected = fraud
                        If dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value = coproductbundleid Then
                            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Selected = legit
                            dgCustomerOrderItems.FirstDisplayedScrollingRowIndex = dgCustomerOrderItems.RowCount - 1
                            Exit For
                        End If
                    Next
                    cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing : txtQtyOrdered.Text = "" : cboByPhrase.Focus() : dgBundleItems.Rows.Clear()
                    cboTags.Text = "" : cboTags.SelectedItem = Nothing
                End If
                itemno = 1 : colorCoding() : addproductcomputations() : customerorderitemscomputations()
                For i As Integer = 0 To dgCustomerOrderItems.Rows.Count - 1
                    dgCustomerOrderItems.Rows(i).Cells("ci_seqno").Value = itemno
                    itemno = itemno + 1
                Next i
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub addCustomerOrderItemA(ByVal iproductcolorsizeid As Integer, ByVal icolorvalue As String, ByVal iproductcode As String, ByVal icolorname As String, ByVal isize As String, ByVal iunitofmeasure As String, ByVal isku As String, ByVal iseasoncode As String, ByVal iqtyordered As Integer, ByVal isrp As Decimal, ByVal itags As String)
        Try
            dgCustomerOrderItems.Rows.Add()
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_rowid").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_bid").Value = neutralpage
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_type").Value = "S"
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_remarks").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_pcsrowid").Value = iproductcolorsizeid
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_colorvalue").Value = icolorvalue
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_productcode").Value = iproductcode
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_colorname").Value = icolorname
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_size").Value = isize
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_unitofmeasure").Value = iunitofmeasure
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtyordered").Value = iqtyordered
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_srp").Value = isrp
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_sku").Value = isku
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_seasoncode").Value = iseasoncode
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_status").Value = "New"
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtypicked").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtydelivered").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_verifiedby").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_verifieddate").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_packedby").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_packeddate").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_deliveredby").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_delivereddate").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_tags").Value = itags

            dgCustomerOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtypicked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtydelivered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_tags").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_verifieddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_delivereddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    'Sub addCustomerOrderItemA(ByVal iproductcolorsizeid As Integer, ByVal iqtyordered As Integer, ByVal isrp As Decimal)
    '    Try
    '        If conn.State = ConnectionState.Closed Then conn.Open()
    '        Dim sql1 As String = "SELECT pcs.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(p.unitofmeasure,''),COALESCE(pcs.sku,''),COALESCE(pcs.seasoncode,'') " & _
    '            "FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pcs.rowid = " & iproductcolorsizeid & " "
    '        Dim cmd1 As New MySqlCommand(sql1, conn)
    '        Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
    '        While reader1.Read()
    '            If reader1.HasRows Then
    '                dgCustomerOrderItems.Rows.Add()
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_rowid").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_bid").Value = neutralpage
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_type").Value = "S"
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_remarks").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_pcsrowid").Value = reader1(0)
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_colorvalue").Value = reader1(1)
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_productcode").Value = reader1(2)
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_colorname").Value = reader1(3)
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_size").Value = reader1(4)
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_unitofmeasure").Value = reader1(5)
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtyordered").Value = iqtyordered
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_srp").Value = isrp
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_sku").Value = reader1(6)
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_seasoncode").Value = reader1(7)
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_status").Value = "New"
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtypicked").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtydelivered").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_verifiedby").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_verifieddate").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_packedby").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_packeddate").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_deliveredby").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_delivereddate").Value = ""
    '            End If
    '        End While
    '        reader1.Close()
    '        dgCustomerOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_qtypicked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_qtydelivered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_verifieddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_delivereddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    'End Sub
    Sub addCustomerOrderItemB(ByVal iproductbundleid As Integer, ByVal ibundlename As String, ByVal iqtyordered As Integer, ByVal isrp As Decimal, ByVal itags As String)
        Try
            dgCustomerOrderItems.Rows.Add()
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_rowid").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_pcsrowid").Value = neutralpage
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_type").Value = "B"
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_remarks").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_colorvalue").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_colorname").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_size").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_seasoncode").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_bid").Value = iproductbundleid
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_productcode").Value = ibundlename
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_unitofmeasure").Value = cobundleunitofmeasure
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtyordered").Value = iqtyordered
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_srp").Value = isrp
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_sku").Value = cobundlesku
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_status").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtypicked").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtydelivered").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_verifiedby").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_verifieddate").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_packedby").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_packeddate").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_deliveredby").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_delivereddate").Value = ""
            dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_tags").Value = itags

            dgCustomerOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtypicked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_qtydelivered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_tags").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_verifieddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_delivereddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    'Sub addCustomerOrderItemB(ByVal iproductbundleid As Integer, ByVal iqtyordered As Integer, ByVal isrp As Decimal)
    '    Try
    '        If conn.State = ConnectionState.Closed Then conn.Open()
    '        Dim sql1 As String = "SELECT b.rowid,COALESCE(b.bundlename,''),COALESCE(b.unitofmeasure,''),COALESCE(b.sku,'') FROM productbundles b WHERE b.rowid = " & iproductbundleid & " "
    '        Dim cmd1 As New MySqlCommand(sql1, conn)
    '        Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
    '        While reader1.Read()
    '            If reader1.HasRows Then
    '                dgCustomerOrderItems.Rows.Add()
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_rowid").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_pcsrowid").Value = neutralpage
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_type").Value = "B"
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_remarks").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_colorvalue").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_colorname").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_size").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_seasoncode").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_bid").Value = reader1(0)
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_productcode").Value = reader1(1)
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_unitofmeasure").Value = reader1(2)
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtyordered").Value = iqtyordered
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_srp").Value = isrp
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_sku").Value = reader1(3)
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_status").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtypicked").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_qtydelivered").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_verifiedby").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_verifieddate").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_packedby").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_packeddate").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_deliveredby").Value = ""
    '                dgCustomerOrderItems.Rows(dgCustomerOrderItems.Rows.Count - 1).Cells("ci_delivereddate").Value = ""
    '            End If
    '        End While
    '        reader1.Close()
    '        dgCustomerOrderItems.Columns("ci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_qtyordered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_qtypicked").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_qtydelivered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_verifieddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_delivereddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgCustomerOrderItems.Columns("ci_option").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    'End Sub

#End Region

#Region "Saving"

    Sub saveBundleItems(ByVal iproductbundleid As Integer, ByVal iqtyordered As Integer, ByVal icustomerorderid As Integer, ByVal iorderitemid As Integer, ByVal itags As String)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT bi.rowid,COALESCE(bi.productcolorsizeid,0),COALESCE(c.colorvalue,''),COALESCE(bi.qtyavailable,0),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,''),COALESCE(p.unitofmeasure,'') " &
                "FROM productbundleitems bi LEFT JOIN productcolorsizes pcs ON bi.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid " &
                "LEFT JOIN productbundles pb ON bi.productbundleid = pb.rowid WHERE bi.productbundleid = " & iproductbundleid & " AND bi.organizationid = " & Z_OrganizationID & " AND bi.status = 'Active' ORDER BY p.productcode,c.colorname "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        'getTotalQtyAvailableA(CInt(reader1(1)), Me)
                        'getTotalQtyAllocatedA(CInt(reader1(1)), Me)
                        I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cocustomerid, icustomerorderid, CInt(reader1(1)), iproductbundleid, iorderitemid, CInt(reader1(3)) * iqtyordered,
                            0, "BI", "" & reader1(4) & " / " & reader1(5) & " / " & reader1(6) & " / " & reader1(7) & "", CStr(reader1(8)), CStr(reader1(9)), "", 0.0, "New", itags, Me)
                        If myModule.systemerrorfound = False Then
                            U_ProductColorSizeSoldInfo(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, CInt(reader1(3)) * iqtyordered, dtpCustomerOrderDate.Value, Me)
                        End If
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

    Sub updateBundleItemsA(ByVal iorderitemid As Integer, ByVal iqtyorderedbefore As Integer, ByVal iqtyorderedafter As Integer, ByVal icustomerorderid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT bi.rowid,COALESCE(bi.qtyordered,0) FROM orderitems bi WHERE bi.orderid = " & icustomerorderid & " AND bi.organizationid = " & Z_OrganizationID & " AND bi.orderitemid = " & iorderitemid & " AND bi.itemtype = 'BI' "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        U_OrderItemQtyOrdered(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Math.Round(CInt(reader1(1)) / iqtyorderedbefore, 2) * iqtyorderedafter, Me)
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

    Sub updateBundleItemsB(ByVal iorderitemid As Integer, ByVal icustomerorderid As Integer, ByVal itags As String)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT bi.rowid FROM orderitems bi WHERE bi.orderid = " & icustomerorderid & " AND bi.organizationid = " & Z_OrganizationID & " AND bi.orderitemid = " & iorderitemid & " AND bi.itemtype = 'BI' "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        U_OrderItemAccountID(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, cocustomerid, Me)
                        If globalorderitemtag <> itags Then
                            U_OrderItemTags(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, itags, Me)
                        End If
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

#Region "Delete"

    Sub deleteBundleItems(ByVal icustomerorderid As Integer, ByVal iorderitemid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT ci.rowid FROM orderitems ci WHERE ci.orderid = " & icustomerorderid & " AND ci.organizationid = " & Z_OrganizationID & " AND ci.status != 'Inactive' AND ci.orderitemid = " & iorderitemid & " AND ci.itemtype = 'BI' ORDER BY ci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    U_OrderItemStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
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

#Region "Duplicating"

    Sub duplicateCustomerOrder(ByVal icustomerorderid As Integer)
        Try
            Dim dtDco As New DataTable
            dtDco = getDataTableForSQL("SELECT co.accountid,COALESCE(co.referencenumber,''),DATE_FORMAT(co.orderdate,'%d-%b-%Y'),DATE_FORMAT(co.targetdate,'%d-%b-%Y'),COALESCE(co.customername)," &
                        "COALESCE(co.comments,''),COALESCE(co.totalamount,0),COALESCE(co.deliveryhours,''),COALESCE(co.customeraddress,''),COALESCE(co.branchid,0),COALESCE(co.companyid,0)," &
                        "COALESCE(co.combinecodingid,0),DATE_FORMAT(co.enddate,'%d-%b-%Y'),COALESCE(co.Agentid,0),COALESCE(co.CustomerOrderType,''),IFNULL(co.InventoryLocationID,0) FROM orders co WHERE co.rowid = " & icustomerorderid & " ")
            If dtDco.Rows.Count <> 0 Then
                getOrderNo(globaliordertype:=OrderType.CO.ToString(), Me)
                I_Orders(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CInt(dtDco.Rows(0)(0)), If(CInt(dtDco.Rows(0)(9)) = 0, DBNull.Value, CInt(dtDco.Rows(0)(9))), If(CInt(dtDco.Rows(0)(10)) = 0, DBNull.Value, CInt(dtDco.Rows(0)(10))),
                    If(CInt(dtDco.Rows(0)(11)) = 0, DBNull.Value, CInt(dtDco.Rows(0)(11))), CStr(globalorderno), "", "", OrderType:=OrderType.CO.ToString(), dtDco.Rows(0)(2), dtDco.Rows(0)(3), dtDco.Rows(0)(12), dtDco.Rows(0)(4), dtDco.Rows(0)(5), "New", CDec(dtDco.Rows(0)(6)), CStr(dtDco.Rows(0)(7)), CStr(dtDco.Rows(0)(8)), CStr(dtDco.Rows(0)(14)), Me, InventoryLocationId:=CInt(dtDco.Rows(0)(15)), AgentId:=CInt(dtDco.Rows(0)(13)))
                coorderid = globalorderidsp
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub duplicateCustomerOrderItems(ByVal icustomerorderid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(ci.accountid,0),COALESCE(ci.productcolorsizeid,0),COALESCE(ci.productbundleid,0),COALESCE(ci.orderitemid,0),COALESCE(ci.qtyordered,0),COALESCE(ci.itemtype,'')," &
                    "COALESCE(ci.itemcode,''),COALESCE(pcs.sku,''),COALESCE(ci.unitofmeasure,''),COALESCE(ci.remarks,''),COALESCE(ci.srp,0.0),COALESCE(ci.tags,'') FROM orderitems ci LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid " &
                    "WHERE ci.orderid = " & icustomerorderid & " AND ci.organizationid = " & Z_OrganizationID & " AND ci.status != 'Inactive' ORDER BY ci.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        If CInt(reader1(1)) <> 0 Then
                            getTotalQtyAvailableA(CInt(reader1(1)), Me)
                            getTotalQtyAllocatedA(CInt(reader1(1)), Me)
                        Else
                            globaltotalqtyavailable = 0
                            globaltotalqtyallocated = 0
                        End If
                        If CStr(reader1(5)) <> "BI" Then
                            coorderitemid = 0
                        End If
                        If CStr(reader1(5)) <> "A" Then
                            I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CInt(reader1(0)), coorderid, If(reader1(1) = 0, DBNull.Value, CInt(reader1(1))), If(reader1(2) = 0, DBNull.Value, CInt(reader1(2))),
                                If(coorderitemid = 0, DBNull.Value, coorderitemid), CInt(reader1(4)), globaltotalqtyavailable - globaltotalqtyallocated, CStr(reader1(5)), CStr(reader1(6)), CStr(reader1(7)), CStr(reader1(8)), CStr(reader1(9)), CDec(reader1(10)), "New", CStr(reader1(11)), Me)
                        End If
                        If CStr(reader1(5)) = "B" Then
                            coorderitemid = globalorderitemidsp
                        End If
                        If myModule.systemerrorfound = False Then
                            If CInt(reader1(1)) <> 0 Then
                                U_ProductColorSizeSoldInfo(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, CInt(reader1(4)), Now.Date, Me)
                            End If
                        End If
                    End If
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

#End Region

#Region "Submitting"

    Sub checkBundleItemsA(ByVal iproductbundleid As Integer, ByVal iqtyordered As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT bi.rowid,COALESCE(bi.productcolorsizeid,0),COALESCE(bi.qtyavailable,0) FROM productbundleitems bi WHERE bi.productbundleid = " & iproductbundleid & " AND bi.organizationid = " & Z_OrganizationID & " AND bi.status = 'Active' "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        getTotalQtyAvailableA(CInt(reader1(1)), Me)
                        getTotalQtyAllocatedA(CInt(reader1(1)), Me)
                        getTotalQtyOrderedA(CInt(reader1(1)), $"AND oi.`status` = 'New' AND o.`status` = 'Submitted To Warehouse' AND o.ordertype = '{OrderType.CO.ToString()}'", Me)
                        If globaltotalqtyavailable - (globaltotalqtyallocated + globaltotalqtyordered) < CInt(reader1(2)) * iqtyordered Then
                            coincompleteqtyavailablecue = legit
                            Exit Try
                        End If
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

    Sub checkBundleItemsB(ByVal iorderitemid As Integer, ByVal iqtyorderedbefore As Integer, ByVal iqtyorderedafter As Integer, ByVal icustomerorderid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT bi.rowid,COALESCE(bi.productcolorsizeid,0),COALESCE(bi.qtyordered,0) FROM orderitems bi WHERE bi.orderid = " & icustomerorderid & " AND bi.organizationid = " & Z_OrganizationID & " AND bi.orderitemid = " & iorderitemid & " AND bi.itemtype = 'BI' "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        getTotalQtyAvailableA(CInt(reader1(1)), Me)
                        getTotalQtyAllocatedA(CInt(reader1(1)), Me)
                        getTotalQtyOrderedA(CInt(reader1(1)), $"AND oi.`status` = 'New' AND o.`status` = 'Submitted To Warehouse' AND o.ordertype = '{OrderType.CO.ToString()}'", Me)
                        If globaltotalqtyavailable - (globaltotalqtyallocated + globaltotalqtyordered) < Math.Round(CInt(reader1(2)) / iqtyorderedbefore, 2) * iqtyorderedafter Then
                            coincompleteqtyavailablecue = legit
                            Exit Try
                        End If
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

#Region "Printing"

    Sub printCustomerOrderItems(ByVal icustomerorderid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT ci.rowid,COALESCE(c.colorvalue,''),COALESCE(ve.companycode,''),COALESCE(o.drnumber,''),COALESCE(br.branchcode,''),COALESCE(DATE_FORMAT(o.targetdate,'%m%d%y'),''),COALESCE(c1.codeno,''),COALESCE(c2.codeno,''),COALESCE(c3.codeno,'')," &
                    "COALESCE(CONCAT(COALESCE(p.productcode,''),' ',COALESCE(c.colorname,''),' ',COALESCE(pcs.size,''),' ',COALESCE(pcs.seasoncode,'')),''),COALESCE(pcs.sku,''),ci.orderid,COALESCE(o.ordernumber,'') FROM orderitems ci LEFT JOIN productcolorsizes pcs ON ci.productcolorsizeid = pcs.rowid " &
                    "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN orders o ON ci.orderid = o.rowid LEFT JOIN companies ve ON o.companyid = ve.rowid " &
                    "LEFT JOIN branches br ON o.branchid = br.rowid LEFT JOIN combinecodings cc ON o.combinecodingid = cc.rowid LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid " &
                    "WHERE ci.organizationid = " & Z_OrganizationID & " AND ci.`status` != 'Inactive' AND ci.itemtype != 'B' AND ci.orderid = " & icustomerorderid & " GROUP BY ci.rowid ORDER BY ci.rowid"
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getPickListOrderID(CInt(reader1(11)), CInt(reader1(0)))
                    If cototalqtypicked > 0 Then
                        printdataset.AddSetARow(CStr(reader1(2)), CStr(reader1(3)), CStr(reader1(4)), CStr(reader1(5)), cototalqtypicked, CStr(reader1(6)), CStr(reader1(7)), CStr(reader1(8)), 0, CStr(reader1(9)), CStr(reader1(10)), Nothing, CStr(reader1(12)), "", "")
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
                PrimaryForm.COForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAddProduct_Leave(sender As Object, e As EventArgs) Handles btnAddProduct.Leave
        Try
            cboByPhrase.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
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
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.COForm = False
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
            clearCustomerOrderInformation()
            clearAddProductA()
            clearAddProductB()
            clearCustomerOrderItems()
            clearDatagrids()
            enableGB(fraud, legit, legit)
            visibleCustomerOrderItems(fraud)
            visibleGB(fraud, fraud, fraud, fraud, fraud)
            enableANDvisibleMS(fraud, legit, fraud, fraud, legit, fraud)
            If dgCustomerOrderList.Rows.Count <> 0 Then
                dgCustomerOrderList.CurrentRow.Selected = False
            End If
            getOrderNo(globaliordertype:=OrderType.CO.ToString(), Me)
            getReferenceNo(globaliordertype:=OrderType.CO.ToString(), Me)
            txtCustomerOrderNo.Text = CStr(globalorderno)
            txtPONo.Text = CStr(globalreferenceno)
            txtStatus.Text = "New"
            txtPONo.Focus()
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
            If dgCustomerOrderList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearCustomerOrderInformation()
                clearAddProductA()
                clearAddProductB()
                clearCustomerOrderItems()
                clearDatagrids()
                visibleCustomerOrderItems(fraud)
                visibleGB(fraud, fraud, fraud, fraud, fraud)
                dgCustomerOrderList.CurrentRow.Selected = True
                displayCustomerOrderInformation(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                displayCustomerOrderItems(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                customerorderitemscomputations() : colorCoding()
                If txtStatus.Text = "New" Then
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, legit, legit, fraud, legit)
                    msOrder.Text = "Cancel Order"
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud, fraud, legit)
                    msOrder.Text = "Re-Open Order"
                Else
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, legit, fraud, fraud, fraud)
                    If LTrim(txtSIDRNo.Text) <> "" Then
                        msPrint.Enabled = legit
                    End If
                End If
                txtPONo.Focus()
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

    Private Sub dgCustomerOrderList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrderList.CellContentClick

    End Sub

    Private Sub dgCustomerOrderList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrderList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerOrderList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearCustomerOrderInformation()
                clearAddProductA()
                clearAddProductB()
                clearCustomerOrderItems()
                clearDatagrids()
                visibleCustomerOrderItems(fraud)
                visibleGB(fraud, fraud, fraud, fraud, fraud)
                displayCustomerOrderInformation(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                displayCustomerOrderItems(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                customerorderitemscomputations() : colorCoding()
                If txtStatus.Text = "New" Then
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, legit, legit, fraud, legit)
                    msOrder.Text = "Cancel Order"
                ElseIf txtStatus.Text = "Cancelled" Then
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, fraud, fraud, fraud, legit)
                    msOrder.Text = "Re-Open Order"
                Else
                    enableGB(legit, legit, fraud)
                    enableANDvisibleMS(legit, fraud, legit, fraud, fraud, fraud)
                    If LTrim(txtSIDRNo.Text) <> "" Then
                        msPrint.Enabled = legit
                    End If
                End If
                txtPONo.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCustomerOrderList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgCustomerOrderList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerOrderList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearCustomerOrderInformation()
                    clearAddProductA()
                    clearAddProductB()
                    clearCustomerOrderItems()
                    clearDatagrids()
                    visibleCustomerOrderItems(fraud)
                    visibleGB(fraud, fraud, fraud, fraud, fraud)
                    displayCustomerOrderInformation(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                    displayCustomerOrderItems(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                    customerorderitemscomputations() : colorCoding()
                    If txtStatus.Text = "New" Then
                        enableGB(legit, legit, legit)
                        enableANDvisibleMS(legit, legit, legit, legit, fraud, legit)
                        msOrder.Text = "Cancel Order"
                    ElseIf txtStatus.Text = "Cancelled" Then
                        enableGB(legit, legit, fraud)
                        enableANDvisibleMS(legit, fraud, fraud, fraud, fraud, legit)
                        msOrder.Text = "Re-Open Order"
                    Else
                        enableGB(legit, legit, fraud)
                        enableANDvisibleMS(legit, fraud, legit, fraud, fraud, fraud)
                        If LTrim(txtSIDRNo.Text) <> "" Then
                            msPrint.Enabled = legit
                        End If
                    End If
                    txtPONo.Focus()
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

    'Private Sub txtPONo_TextChanged(sender As Object, e As EventArgs) Handles txtPONo.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cue = "New" Then
    '            If LTrim(cboCustomerName.Text) <> "" Then
    '                getCustomerID(cboCustomerName.Text, Me)
    '                cocustomerid = globalcustomerid
    '                If LTrim(txtPONo.Text) <> "" Then
    '                    If cocustomerid = 0 Then
    '                        errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
    '                    Else
    '                        getOrderIDA(txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
    '                        coorderid = globalorderid
    '                        If coorderid <> 0 Then
    '                            errProvider.SetError(txtPONo, "P.O. No. and customer name has been created already, please type a new one.")
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        ElseIf cue = "Edit" Then
    '            If dgCustomerOrderList.Rows.Count <> 0 Then
    '                If LTrim(cboCustomerName.Text) <> "" Then
    '                    getCustomerID(cboCustomerName.Text, Me)
    '                    cocustomerid = globalcustomerid
    '                    If LTrim(txtPONo.Text) <> "" Then
    '                        If cocustomerid = 0 Then
    '                            errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
    '                        Else
    '                            getOrderIDB(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
    '                            coorderid = globalorderid
    '                            If coorderid <> 0 Then
    '                                errProvider.SetError(txtPONo, "P.O. No. and customer name has been created already, please type a new one.")
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
    'Private Sub txtSIDRNo_TextChanged(sender As Object, e As EventArgs) Handles txtSIDRNo.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cue = "New" Then
    '            If LTrim(cboCustomerName.Text) <> "" Then
    '                getCustomerID(cboCustomerName.Text, Me)
    '                cocustomerid = globalcustomerid
    '                If LTrim(txtSIDRNo.Text) <> "" Then
    '                    If cocustomerid = 0 Then
    '                        errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
    '                    Else
    '                        getOrderIDE(txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
    '                        coorderid = globalorderid
    '                        If coorderid <> 0 Then
    '                            errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        ElseIf cue = "Edit" Then
    '            If dgCustomerOrderList.Rows.Count <> 0 Then
    '                If LTrim(cboCustomerName.Text) <> "" Then
    '                    getCustomerID(cboCustomerName.Text, Me)
    '                    cocustomerid = globalcustomerid
    '                    If LTrim(txtSIDRNo.Text) <> "" Then
    '                        If cocustomerid = 0 Then
    '                            errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
    '                        Else
    '                            getOrderIDF(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
    '                            coorderid = globalorderid
    '                            If coorderid <> 0 Then
    '                                errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
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
    'Private Sub cboCustomerName_Leave(sender As Object, e As EventArgs) Handles cboCustomerName.Leave
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        txtDeliveryHours.Text = "" : txtDeliveryAddress.Text = ""
    '        If cue = "New" Then
    '            If LTrim(cboCustomerName.Text) <> "" Then
    '                getCustomerID(cboCustomerName.Text, Me)
    '                cocustomerid = globalcustomerid
    '                If cocustomerid = 0 Then
    '                    errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
    '                Else
    '                    getAccountInfo(cocustomerid, Me)
    '                    txtDeliveryHours.Text = globaldeliveryhours
    '                    txtDeliveryAddress.Text = globaladdressname
    '                    cboBranchCodeNameInfo.Text = globalbranchname
    '                    'getOrderIDA(txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
    '                    'coorderid = globalorderid
    '                    'If coorderid <> 0 Then
    '                    '    errProvider.SetError(txtPONo, "P.O. No. and customer name has been created already, please type a new one.")
    '                    'End If
    '                End If
    '                'If LTrim(txtPONo.Text) <> "" Then

    '                'End If
    '                'If LTrim(txtSIDRNo.Text) <> "" Then
    '                '    If cocustomerid = 0 Then
    '                '        errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
    '                '    Else
    '                '        getOrderIDE(txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
    '                '        coorderid = globalorderid
    '                '        If coorderid <> 0 Then
    '                '            errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
    '                '        End If
    '                '    End If
    '                'End If
    '            End If
    '        ElseIf cue = "Edit" Then
    '            If dgCustomerOrderList.Rows.Count <> 0 Then
    '                If LTrim(cboCustomerName.Text) <> "" Then
    '                    getCustomerID(cboCustomerName.Text, Me)
    '                    cocustomerid = globalcustomerid
    '                    If cocustomerid = 0 Then
    '                        errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
    '                    Else
    '                        getAccountInfo(cocustomerid, Me)
    '                        txtDeliveryHours.Text = globaldeliveryhours
    '                        txtDeliveryAddress.Text = globaladdressname
    '                        cboBranchCodeNameInfo.Text = globalbranchname
    '                        'getOrderIDB(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
    '                        'coorderid = globalorderid
    '                        'If coorderid <> 0 Then
    '                        '    errProvider.SetError(txtPONo, "P.O. No. and customer name has been created already, please type a new one.")
    '                        'End If
    '                    End If
    '                    'If LTrim(txtPONo.Text) <> "" Then

    '                    'End If
    '                    'If LTrim(txtSIDRNo.Text) <> "" Then
    '                    '    If cocustomerid = 0 Then
    '                    '        errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
    '                    '    Else
    '                    '        getOrderIDF(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
    '                    '        coorderid = globalorderid
    '                    '        If coorderid <> 0 Then
    '                    '            errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
    '                    '        End If
    '                    '    End If
    '                    'End If
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
    Private Sub cboCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomerName.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            txtDeliveryHours.Text = "" : txtDeliveryAddress.Text = ""
            If cue = "New" Then
                If LTrim(cboCustomerName.Text) <> "" Then
                    getCustomerID(cboCustomerName.Text, Me)
                    cocustomerid = globalcustomerid
                    If cocustomerid = 0 Then
                        '  errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                    Else
                        getAccountInfo(cocustomerid, Me)
                        txtDeliveryHours.Text = globaldeliveryhours
                        txtDeliveryAddress.Text = globaladdressname
                        cboBranchCodeNameInfo.Text = globalbranchname
                        'getOrderIDA(txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                        'coorderid = globalorderid
                        'If coorderid <> 0 Then
                        '    errProvider.SetError(txtPONo, "P.O. No. and customer name has been created already, please type a new one.")
                        'End If
                    End If
                    'If LTrim(txtPONo.Text) <> "" Then

                    'End If
                    'If LTrim(txtSIDRNo.Text) <> "" Then
                    '    If cocustomerid = 0 Then
                    '        errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                    '    Else
                    '        getOrderIDE(txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                    '        coorderid = globalorderid
                    '        If coorderid <> 0 Then
                    '            errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
                    '        End If
                    '    End If
                    'End If
                End If
            ElseIf cue = "Edit" Then
                If dgCustomerOrderList.Rows.Count <> 0 Then
                    If LTrim(cboCustomerName.Text) <> "" Then
                        getCustomerID(cboCustomerName.Text, Me)
                        cocustomerid = globalcustomerid
                        If cocustomerid = 0 Then
                            '  errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                        Else
                            getAccountInfo(cocustomerid, Me)
                            txtDeliveryHours.Text = globaldeliveryhours
                            txtDeliveryAddress.Text = globaladdressname
                            cboBranchCodeNameInfo.Text = globalbranchname
                            'getOrderIDB(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                            'coorderid = globalorderid
                            'If coorderid <> 0 Then
                            '    errProvider.SetError(txtPONo, "P.O. No. and customer name has been created already, please type a new one.")
                            'End If
                        End If
                        'If LTrim(txtPONo.Text) <> "" Then

                        'End If
                        'If LTrim(txtSIDRNo.Text) <> "" Then
                        '    If cocustomerid = 0 Then
                        '        errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                        '    Else
                        '        getOrderIDF(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                        '        coorderid = globalorderid
                        '        If coorderid <> 0 Then
                        '            errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
                        '        End If
                        '    End If
                        'End If
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

    Private Sub cboCustomerName_TextChanged(sender As Object, e As EventArgs) Handles cboCustomerName.TextChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            txtDeliveryHours.Text = "" : txtDeliveryAddress.Text = ""
            If cue = "New" Then
                If LTrim(cboCustomerName.Text) <> "" Then
                    getCustomerID(cboCustomerName.Text, Me)
                    cocustomerid = globalcustomerid
                    If cocustomerid = 0 Then
                        '  errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                    Else
                        getAccountInfo(cocustomerid, Me)
                        txtDeliveryHours.Text = globaldeliveryhours
                        txtDeliveryAddress.Text = globaladdressname
                        cboBranchCodeNameInfo.Text = globalbranchname
                        'getOrderIDA(txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                        'coorderid = globalorderid
                        'If coorderid <> 0 Then
                        '    errProvider.SetError(txtPONo, "P.O. No. and customer name has been created already, please type a new one.")
                        'End If
                    End If
                    'If LTrim(txtPONo.Text) <> "" Then

                    'End If
                    'If LTrim(txtSIDRNo.Text) <> "" Then
                    '    If cocustomerid = 0 Then
                    '        errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                    '    Else
                    '        getOrderIDE(txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                    '        coorderid = globalorderid
                    '        If coorderid <> 0 Then
                    '            errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
                    '        End If
                    '    End If
                    'End If
                End If
            ElseIf cue = "Edit" Then
                If dgCustomerOrderList.Rows.Count <> 0 Then
                    If LTrim(cboCustomerName.Text) <> "" Then
                        getCustomerID(cboCustomerName.Text, Me)
                        cocustomerid = globalcustomerid
                        If cocustomerid = 0 Then
                            '  errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                        Else
                            getAccountInfo(cocustomerid, Me)
                            txtDeliveryHours.Text = globaldeliveryhours
                            txtDeliveryAddress.Text = globaladdressname
                            cboBranchCodeNameInfo.Text = globalbranchname
                            'getOrderIDB(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                            'coorderid = globalorderid
                            'If coorderid <> 0 Then
                            '    errProvider.SetError(txtPONo, "P.O. No. and customer name has been created already, please type a new one.")
                            'End If
                        End If
                        'If LTrim(txtPONo.Text) <> "" Then

                        'End If
                        'If LTrim(txtSIDRNo.Text) <> "" Then
                        '    If cocustomerid = 0 Then
                        '        errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                        '    Else
                        '        getOrderIDF(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                        '        coorderid = globalorderid
                        '        If coorderid <> 0 Then
                        '            errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
                        '        End If
                        '    End If
                        'End If
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

    Private Sub cboBranchCodeNameInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBranchCodeNameInfo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If cue <> "" Then
                If LTrim(cboBranchCodeNameInfo.Text) <> "" Then
                    getBranchCodeIDB(cboBranchCodeNameInfo.Text, Me)
                    cobranchid = globalbranchid
                    If cobranchid <> 0 Then
                        txtDeliveryAddress.Text = globalbranchaddress
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

    Private Sub cboBranchCodeNameInfo_TextChanged(sender As Object, e As EventArgs) Handles cboBranchCodeNameInfo.TextChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If cue <> "" Then
                If LTrim(cboBranchCodeNameInfo.Text) <> "" Then
                    getBranchCodeIDB(cboBranchCodeNameInfo.Text, Me)
                    cobranchid = globalbranchid
                    If cobranchid <> 0 Then
                        txtDeliveryAddress.Text = globalbranchaddress
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

    Private Sub cboBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBy.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            txtQtyOrdered.Text = ""
            txtBundleSRP.Text = ""
            cboTags.Text = "" : cboTags.SelectedItem = Nothing
            dgProductColors.Rows.Clear()
            dgProductSizes.Rows.Clear()
            dgProductColorSizes.Rows.Clear()
            dgBundleItems.Rows.Clear()
            If cboBy.Text = "" Then
                cboByPhrase.Items.Clear() : cboByPhrase.AutoCompleteCustomSource.Clear()
                visibleGB(fraud, fraud, fraud, fraud, fraud)
            ElseIf cboBy.Text = "BundleName" Then
                globalautocompleteByBundleName(cboByPhrase, Me)
                globalautopopulateByBundleName(cboByPhrase, Me)
                visibleGB(fraud, fraud, legit, legit, legit)
            ElseIf cboBy.Text = "Combination" Then
                globalautocompleteByCombination(cboByPhrase, Me)
                globalautopopulateByCombination(cboByPhrase, Me)
                visibleGB(legit, fraud, fraud, fraud, legit)
            ElseIf cboBy.Text = "ProductCode" Then
                globalautocompleteByProductCode(cboByPhrase, Me)
                globalautopopulateByProductCode(cboByPhrase, Me)
                visibleGB(fraud, legit, fraud, legit, legit)
            ElseIf cboBy.Text = "SKU" Then
                globalautocompleteBySKU(cboByPhrase, Me)
                globalautopopulateBySKU(cboByPhrase, Me)
                visibleGB(fraud, fraud, fraud, fraud, fraud)
            End If
            addproductcomputations()
            cboByPhrase.Text = "" : cboByPhrase.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub cboByPhrase_Leave(sender As Object, e As EventArgs) Handles cboByPhrase.Leave
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cboByPhrase.Text <> "" Then
    '            If cboBy.Text = "" Then
    '                txtBundleSRP.Text = ""
    '                dgBundleItems.Rows.Clear()
    '                dgProductColorSizes.Rows.Clear()
    '                dgProductColors.Rows.Clear()
    '                dgProductSizes.Rows.Clear()
    '            ElseIf cboBy.Text = "BundleName" Then
    '                getProductBundleIDA(cboByPhrase.Text, Me)
    '                coproductbundleid = globalproductbundleid
    '                dgBundleItems.Rows.Clear()
    '                If coproductbundleid <> 0 Then
    '                    displayProductsD(coproductbundleid)
    '                    colorCoding()
    '                Else
    '                    txtBundleSRP.Text = ""
    '                End If
    '            ElseIf cboBy.Text = "Combination" Then
    '                getProductColorSizesIDB(cboByPhrase.Text, Me)
    '                coproductcolorsizesid = globalproductcolorsizesid
    '                dgProductColorSizes.Rows.Clear()
    '                If coproductcolorsizesid <> 0 Then
    '                    displayProductsA(coproductcolorsizesid)
    '                    colorCoding()
    '                End If
    '            ElseIf cboBy.Text = "ProductCode" Then
    '                getProductIDB(cboByPhrase.Text, Me)
    '                coproductid = globalproductid
    '                dgProductColors.Rows.Clear()
    '                dgProductSizes.Rows.Clear()
    '                If coproductid <> 0 Then
    '                    displayProductsB(coproductid)
    '                    colorCoding()
    '                End If
    '            ElseIf cboBy.Text = "SKU" Then
    '                getProductColorSizesSKUA(cboByPhrase.Text, Me)
    '                coproductcolorsizesid = globalskuid
    '                dgProductColorSizes.Rows.Clear()
    '                dgBundleItems.Rows.Clear()
    '                If coproductcolorsizesid <> 0 Then
    '                    visibleGB(legit, fraud, fraud, fraud, legit)
    '                    displayProductsA(coproductcolorsizesid)
    '                    colorCoding()
    '                Else
    '                    getProductBundleSKUA(cboByPhrase.Text, Me)
    '                    coproductbundleid = globalskuid
    '                    If coproductbundleid <> 0 Then
    '                        visibleGB(fraud, fraud, legit, legit, legit)
    '                        displayProductsD(coproductbundleid)
    '                        colorCoding()
    '                    Else
    '                        txtBundleSRP.Text = ""
    '                    End If
    '                End If
    '            End If
    '        Else
    '            txtBundleSRP.Text = ""
    '            dgBundleItems.Rows.Clear()
    '            dgProductColorSizes.Rows.Clear()
    '            dgProductColors.Rows.Clear()
    '            dgProductSizes.Rows.Clear()
    '        End If
    '        addproductcomputations()
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    Private Sub cboByPhrase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboByPhrase.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cboByPhrase.Text <> "" Then
                If cboBy.Text = "" Then
                    txtBundleSRP.Text = ""
                    dgBundleItems.Rows.Clear()
                    dgProductColorSizes.Rows.Clear()
                    dgProductColors.Rows.Clear()
                    dgProductSizes.Rows.Clear()
                ElseIf cboBy.Text = "BundleName" Then
                    getProductBundleIDA(cboByPhrase.Text, Me)
                    coproductbundleid = globalproductbundleid
                    dgBundleItems.Rows.Clear()
                    If coproductbundleid <> 0 Then
                        displayProductsD(coproductbundleid)
                        colorCoding()
                    Else
                        txtBundleSRP.Text = ""
                    End If
                ElseIf cboBy.Text = "Combination" Then
                    getProductColorSizesIDB(cboByPhrase.Text, Me)
                    coproductcolorsizesid = globalproductcolorsizesid
                    dgProductColorSizes.Rows.Clear()
                    If coproductcolorsizesid <> 0 Then
                        displayProductsA(coproductcolorsizesid)
                        colorCoding()
                    End If
                ElseIf cboBy.Text = "ProductCode" Then
                    getProductIDB(cboByPhrase.Text, Me)
                    coproductid = globalproductid
                    dgProductColors.Rows.Clear()
                    dgProductSizes.Rows.Clear()
                    If coproductid <> 0 Then
                        displayProductsB(coproductid)
                        colorCoding()
                    End If
                ElseIf cboBy.Text = "SKU" Then
                    getProductColorSizesSKUA(cboByPhrase.Text, Me)
                    coproductcolorsizesid = globalskuid
                    dgProductColorSizes.Rows.Clear()
                    dgBundleItems.Rows.Clear()
                    If coproductcolorsizesid <> 0 Then
                        visibleGB(legit, fraud, fraud, fraud, legit)
                        displayProductsA(coproductcolorsizesid)
                        colorCoding()
                    Else
                        getProductBundleSKUA(cboByPhrase.Text, Me)
                        coproductbundleid = globalskuid
                        If coproductbundleid <> 0 Then
                            visibleGB(fraud, fraud, legit, legit, legit)
                            displayProductsD(coproductbundleid)
                            colorCoding()
                        Else
                            txtBundleSRP.Text = ""
                        End If
                    End If
                End If
            Else
                txtBundleSRP.Text = ""
                dgBundleItems.Rows.Clear()
                dgProductColorSizes.Rows.Clear()
                dgProductColors.Rows.Clear()
                dgProductSizes.Rows.Clear()
            End If
            addproductcomputations()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboByPhrase_TextChanged(sender As Object, e As EventArgs) Handles cboByPhrase.TextChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cboByPhrase.Text <> "" Then
                If cboBy.Text = "" Then
                    txtBundleSRP.Text = ""
                    dgBundleItems.Rows.Clear()
                    dgProductColorSizes.Rows.Clear()
                    dgProductColors.Rows.Clear()
                    dgProductSizes.Rows.Clear()
                ElseIf cboBy.Text = "BundleName" Then
                    getProductBundleIDA(cboByPhrase.Text, Me)
                    coproductbundleid = globalproductbundleid
                    dgBundleItems.Rows.Clear()
                    If coproductbundleid <> 0 Then
                        displayProductsD(coproductbundleid)
                        colorCoding()
                    Else
                        txtBundleSRP.Text = ""
                    End If
                ElseIf cboBy.Text = "Combination" Then
                    getProductColorSizesIDB(cboByPhrase.Text, Me)
                    coproductcolorsizesid = globalproductcolorsizesid
                    dgProductColorSizes.Rows.Clear()
                    If coproductcolorsizesid <> 0 Then
                        displayProductsA(coproductcolorsizesid)
                        colorCoding()
                    End If
                ElseIf cboBy.Text = "ProductCode" Then
                    getProductIDB(cboByPhrase.Text, Me)
                    coproductid = globalproductid
                    dgProductColors.Rows.Clear()
                    dgProductSizes.Rows.Clear()
                    If coproductid <> 0 Then
                        displayProductsB(coproductid)
                        colorCoding()
                    End If
                ElseIf cboBy.Text = "SKU" Then
                    getProductColorSizesSKUA(cboByPhrase.Text, Me)
                    coproductcolorsizesid = globalskuid
                    dgProductColorSizes.Rows.Clear()
                    dgBundleItems.Rows.Clear()
                    If coproductcolorsizesid <> 0 Then
                        visibleGB(legit, fraud, fraud, fraud, legit)
                        displayProductsA(coproductcolorsizesid)
                        colorCoding()
                    Else
                        getProductBundleSKUA(cboByPhrase.Text, Me)
                        coproductbundleid = globalskuid
                        If coproductbundleid <> 0 Then
                            visibleGB(fraud, fraud, legit, legit, legit)
                            displayProductsD(coproductbundleid)
                            colorCoding()
                        Else
                            txtBundleSRP.Text = ""
                        End If
                    End If
                End If
            Else
                txtBundleSRP.Text = ""
                dgBundleItems.Rows.Clear()
                dgProductColorSizes.Rows.Clear()
                dgProductColors.Rows.Clear()
                dgProductSizes.Rows.Clear()
            End If
            addproductcomputations()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtQtyOrdered_TextChanged(sender As Object, e As EventArgs) Handles txtQtyOrdered.TextChanged
        Try
            addproductcomputations()
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub txtBundleSRP_TextChanged(sender As Object, e As EventArgs) Handles txtBundleSRP.TextChanged
        Try
            addproductcomputations()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgProductColors_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProductColors.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductColors.Rows.Count <> 0 Then
                displayProductsC(CInt(dgProductColors.CurrentRow.Cells("c_rowid").Value))
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProductColors_KeyUp(sender As Object, e As KeyEventArgs) Handles dgProductColors.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductColors.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    displayProductsC(CInt(dgProductColors.CurrentRow.Cells("c_rowid").Value))
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProductSizes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgProductSizes.CellEndEdit
        Try
            addproductcomputations()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgProductSizes_KeyDown(sender As Object, e As KeyEventArgs) Handles dgProductSizes.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgProductSizes.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Enter Then
                    btnAddperformclick()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            btnAddperformclick()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtQtyOrdered_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQtyOrdered.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                btnAddperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboTags_KeyDown(sender As Object, e As KeyEventArgs) Handles cboTags.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                btnAddperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbAddCustomer_MouseEnter(sender As Object, e As EventArgs) Handles pbAddCustomer.MouseEnter
        Try
            pbAddCustomer.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddCustomer_MouseLeave(sender As Object, e As EventArgs) Handles pbAddCustomer.MouseLeave
        Try
            pbAddCustomer.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddCustomer_Click(sender As Object, e As EventArgs) Handles pbAddCustomer.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.COForm = False
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
            Dim addcustomerslinkform As New AddCustomersForm
            addcustomerslinkform.ShowInTaskbar = False
            addcustomerslinkform.ShowDialog()
            If addcustomerslinkform.addcustomerformcue = legit Then
                globalautocompleteAccountName(cboCustomerName, "Customer", "AND a.`status` = 'Active'", Me)
                globalautopopulateAccountName(cboCustomerName, "Customer", "AND a.`status` = 'Active'", Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCustomerOrderItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrderItems.CellEndEdit
        Try
            customerorderitemscomputations()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgCustomerOrderItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrderItems.CellClick
        Try
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                If IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value) Then
                    If CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value) <> 0 Then
                        If dgCustomerOrderList.Rows.Count <> 0 Then
                            If CStr(dgCustomerOrderItems.CurrentRow.Cells("ci_type").Value) = "B" Then
                                lnkEditBundleItems.Visible = legit
                            Else
                                lnkEditBundleItems.Visible = fraud
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
    End Sub

    Private Sub lnkEditBundleItems_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEditBundleItems.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.COForm = False
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
            Dim editbundleitemslinkform As New EditBundleItemsAForm
            If LTrim(cboCustomerName.Text) <> "" Then
                getCustomerID(cboCustomerName.Text, Me)
                cocustomerid = globalcustomerid
                If cocustomerid = 0 Then
                    errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                    Exit Try
                Else
                    editbundleitemslinkform.ebiacustomerid = cocustomerid
                End If
            Else
                errProvider.SetError(pbAddCustomer, "Please enter the customer name.")
                Exit Try
            End If
            If dgCustomerOrderList.Rows.Count <> 0 Then
                editbundleitemslinkform.ebiacustomerorderid = CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value)
            Else
                errProvider.SetError(pbAddCustomer, "System cannot find the customer order.")
                Exit Try
            End If
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                editbundleitemslinkform.ebiaorderitemid = CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value)
            Else
                errProvider.SetError(pbAddCustomer, "System cannot find the customer order item.")
                Exit Try
            End If
            editbundleitemslinkform.ShowInTaskbar = False
            editbundleitemslinkform.ShowDialog()
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
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.COForm = False
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
            If dgCustomerOrderList.Rows.Count <> 0 Then
                getOrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Me)
                If globalorderstatus <> txtStatus.Text Then
                    MessageBox.Show("This customer order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                ElseIf globalorderstatus = "New" Then
                    If MessageBox.Show("Would you like to cancel this order?", "Cancelling", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        If dgCustomerOrderList.Rows.Count <> 0 Then
                            getOrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Me)
                            If globalorderstatus <> txtStatus.Text Then
                                MessageBox.Show("This customer order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                        U_OrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Cancelled", Me)
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Cancelled", "Cancel", lblsavemsg, -15, -65)
                            tsrefreshperformclick()
                        End If
                    End If
                ElseIf globalorderstatus = "Cancelled" Then
                    If MessageBox.Show("Would you like to re-open this order?", "Opening", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        If dgCustomerOrderList.Rows.Count <> 0 Then
                            getOrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Me)
                            If globalorderstatus <> txtStatus.Text Then
                                MessageBox.Show("This customer order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                        U_OrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "New", Me)
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Opened", "Open", lblsavemsg, -15, -65)
                            tsrefreshperformclick()
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

    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            customerorderitemscomputations()
            dgCustomerOrderItems.CommitEdit(legit) : dgCustomerOrderItems.ClearSelection() : dgCustomerOrderItems.CurrentCell = Nothing
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.COForm = False
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
                If LTrim(cboCustomerName.Text) <> "" Then
                    getCustomerID(cboCustomerName.Text, Me)
                    cocustomerid = globalcustomerid
                    If LTrim(txtPONo.Text) <> "" Then
                        If cocustomerid = 0 Then
                            errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                            Exit Try
                        Else
                            'getOrderIDA(txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                            'coorderid = globalorderid
                            'If coorderid <> 0 Then
                            '    errProvider.SetError(txtPONo, "P.O. No. and customer name has been created already, please type a new one.")
                            '    Exit Try
                            'End If
                        End If
                    Else
                        errProvider.SetError(txtPONo, "Please enter the P.O. no.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddCustomer, "Please enter the customer name.")
                    Exit Try
                End If
                'If LTrim(txtSIDRNo.Text) <> "" Then
                '    getOrderIDE(txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                '    coorderid = globalorderid
                '    If coorderid <> 0 Then
                '        errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
                '        Exit Try
                '    End If
                'End If
                If cboCustomerOrderType.SelectedValue Is Nothing Then
                    errProvider.SetError(cboCustomerOrderType, "Please select an `Order Type` value")
                    Cursor = Cursors.Default
                    Return
                End If
            ElseIf cue = "Edit" Then
                If globalcreateflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If dgCustomerOrderList.Rows.Count <> 0 Then
                    If LTrim(cboCustomerName.Text) <> "" Then
                        getCustomerID(cboCustomerName.Text, Me)
                        cocustomerid = globalcustomerid
                        If LTrim(txtPONo.Text) <> "" Then
                            If cocustomerid = 0 Then
                                errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                                Exit Try
                            Else
                                'getOrderIDB(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                                'coorderid = globalorderid
                                'If coorderid <> 0 Then
                                '    errProvider.SetError(txtPONo, "P.O No. and customer name been created already, please type a new one.")
                                '    Exit Try
                                'End If
                            End If
                        Else
                            errProvider.SetError(txtPONo, "Please enter the P.O. no.")
                            Exit Try
                        End If
                    Else
                        errProvider.SetError(pbAddCustomer, "Please enter the customer name.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddCustomer, "System cannot find the customer order.")
                    Exit Try
                End If
                'If LTrim(txtSIDRNo.Text) <> "" Then
                '    getOrderIDF(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                '    coorderid = globalorderid
                '    If coorderid <> 0 Then
                '        errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
                '        Exit Try
                '    End If
                'End If
                If dgCustomerOrderList.Rows.Count <> 0 Then
                    getOrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Me)
                    If globalorderstatus <> txtStatus.Text Then
                        MessageBox.Show("This customer order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                End If
            End If
            myModule.systemerrorfound = False
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getBranchCodeIDB(cboBranchCodeNameInfo.Text, Me)
                cobranchid = globalbranchid
                getCompanyIDB(cboVendorCodeNameInfo.Text, Me)
                covendorid = globalcompanyid
                getCombineCodingsIDB(cboClassDescription.Text, Me)
                cocombinecodingid = globalcombinecodingid
                If cue = "New" Then
                    'getCustomerID(cboCustomerName.Text, Me)
                    'cocustomerid = globalcustomerid
                    'getOrderIDA(txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                    'coorderid = globalorderid
                    'If coorderid <> 0 Then
                    '    errProvider.SetError(txtPONo, "P.O No. and customer name has been created already, please type a new one.")
                    '    Exit Try
                    'End If
                    'If LTrim(txtSIDRNo.Text) <> "" Then
                    '    getOrderIDE(txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                    '    coorderid = globalorderid
                    '    If coorderid <> 0 Then
                    '        errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
                    '        Exit Try
                    '    End If
                    'End If
                    getOrderNo(globaliordertype:=OrderType.CO.ToString(), Me)

                    I_Orders(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cocustomerid, If(cobranchid = 0, DBNull.Value, cobranchid), If(covendorid = 0, DBNull.Value, covendorid), If(cocombinecodingid = 0, DBNull.Value, cocombinecodingid),
                            CStr(globalorderno), txtPONo.Text, txtSIDRNo.Text, OrderType:=OrderType.CO.ToString(), dtpCustomerOrderDate.Value, dtpDeliveryDate.Value, dtpEndDate.Value, cboCustomerName.Text, txtComments.Text, txtStatus.Text, Math.Round(coitotalprice, 2), txtDeliveryHours.Text, txtDeliveryAddress.Text, cboCustomerOrderType.Text, Me, InventoryLocationId:=CInt(cboInventoryLocation.SelectedValue), AgentId:=CInt(cboAgent.SelectedValue))
                    coorderid = globalorderidsp
                    If dgCustomerOrderItems.Rows.Count <> 0 Then
                        For a = 0 To dgCustomerOrderItems.Rows.Count - 1
                            If myModule.systemerrorfound = False Then
                                If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                    If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                        'getTotalQtyAvailableA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                        'getTotalQtyAllocatedA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                        I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cocustomerid, coorderid, CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value, DBNull.Value,
                                            If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), 0, CStr(dgCustomerOrderItems.Rows(a).Cells("ci_type").Value),
                                            "" & CStr(dgCustomerOrderItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgCustomerOrderItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgCustomerOrderItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgCustomerOrderItems.Rows(a).Cells("ci_seasoncode").Value) & "",
                                            CStr(dgCustomerOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_remarks").Value), If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "New", CStr(dgCustomerOrderItems.Rows(a).Cells("ci_tags").Value), Me)
                                        If myModule.systemerrorfound = False Then
                                            U_ProductColorSizeSoldInfo(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), dtpCustomerOrderDate.Value, Me)
                                        End If
                                    End If
                                End If
                                If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value) Then
                                    If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value) <> 0 Then
                                        I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cocustomerid, coorderid, DBNull.Value, CInt(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value), DBNull.Value, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0),
                                            0, CStr(dgCustomerOrderItems.Rows(a).Cells("ci_type").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_productcode").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_remarks").Value),
                                            If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "New", CStr(dgCustomerOrderItems.Rows(a).Cells("ci_tags").Value), Me)
                                        saveBundleItems(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value), If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), coorderid, globalorderitemidsp, CStr(dgCustomerOrderItems.Rows(a).Cells("ci_tags").Value))
                                    End If
                                End If
                            Else
                                Exit Sub
                            End If
                        Next
                    End If
                    If CStr(txtCustomerOrderNo.Text) <> CStr(globalorderno) Then
                        MessageBox.Show("Please take note that the Customer Order No. has change from " & txtCustomerOrderNo.Text & " to " & globalorderno & "." & vbNewLine & "Another user used Customer Order No. " & txtCustomerOrderNo.Text & " for its new customer order.", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCustomerOrderNo.Text = globalorderno
                    End If
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Save", "Save", lblsavemsg, -15, -65)
                        clearcboSearch()
                        clearRightPage()
                        searchmode = "SimpleSearch"
                        txtSimpleSearch.Text = CStr(globalorderno)
                        simplesearchphrase = txtSimpleSearch.Text
                        spagenum = neutralpage : numofpages = startingpage
                        displaySearchPhrase(simplesearchphrase, spagenum)
                        pageSetup1(simplesearchphrase)
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                    End If
                ElseIf cue = "Edit" Then
                    If dgCustomerOrderList.Rows.Count <> 0 Then
                        getOrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Me)
                        If globalorderstatus <> txtStatus.Text Then
                            MessageBox.Show("This customer order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                    End If
                    If dgCustomerOrderList.Rows.Count <> 0 Then
                        'getCustomerID(cboCustomerName.Text, Me)
                        'cocustomerid = globalcustomerid
                        'getOrderIDB(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                        'coorderid = globalorderid
                        'If coorderid <> 0 Then
                        '    errProvider.SetError(txtPONo, "P.O. No. and customer name has been created already, please type a new one.")
                        '    Exit Try
                        'End If
                        'If LTrim(txtSIDRNo.Text) <> "" Then
                        '    getOrderIDF(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                        '    coorderid = globalorderid
                        '    If coorderid <> 0 Then
                        '        errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
                        '        Exit Try
                        '    End If
                        'End If
                        U_Orders(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, cocustomerid, If(cobranchid = 0, DBNull.Value, cobranchid), If(covendorid = 0, DBNull.Value, covendorid), If(cocombinecodingid = 0, DBNull.Value, cocombinecodingid),
                             txtCustomerOrderNo.Text, txtPONo.Text, txtSIDRNo.Text, dtpCustomerOrderDate.Value, dtpDeliveryDate.Value, dtpEndDate.Value, txtComments.Text, Math.Round(coitotalprice, 2), txtDeliveryHours.Text, txtDeliveryAddress.Text, cboCustomerOrderType.Text, Me, cboCustomerOrderType.SelectedValue, AgentId:=CInt(cboAgent.SelectedValue))
                        If dgCustomerOrderItems.Rows.Count <> 0 Then
                            For a = 0 To dgCustomerOrderItems.Rows.Count - 1
                                If myModule.systemerrorfound = False Then
                                    If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value) Then
                                        If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value) <> 0 Then
                                            If CStr(dgCustomerOrderItems.Rows(a).Cells("ci_type").Value) = "B" Then
                                                getOrderItemInfo(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value), Me)
                                                If globalorderitemqtyordered <> If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0) Then
                                                    updateBundleItemsA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value), globalorderitemqtyordered, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                                                End If
                                                updateBundleItemsB(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value), CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_tags").Value))
                                            End If
                                            If myModule.systemerrorfound = False Then
                                                U_OrderItems(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, cocustomerid, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0),
                                                    If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_remarks").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_tags").Value), Me)
                                            End If
                                        End If
                                    Else
                                        If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                            If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                                'getTotalQtyAvailableA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                'getTotalQtyAllocatedA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                                I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cocustomerid, CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value,
                                                    DBNull.Value, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), 0, CStr(dgCustomerOrderItems.Rows(a).Cells("ci_type").Value),
                                                    "" & CStr(dgCustomerOrderItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgCustomerOrderItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgCustomerOrderItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgCustomerOrderItems.Rows(a).Cells("ci_seasoncode").Value) & "",
                                                    CStr(dgCustomerOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_remarks").Value), If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "New", CStr(dgCustomerOrderItems.Rows(a).Cells("ci_tags").Value), Me)
                                                If myModule.systemerrorfound = False Then
                                                    U_ProductColorSizeSoldInfo(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), dtpCustomerOrderDate.Value, Me)
                                                End If
                                            End If
                                        End If
                                        If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value) Then
                                            If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value) <> 0 Then
                                                I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cocustomerid, CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), DBNull.Value, CInt(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value), DBNull.Value, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0),
                                                    0, CStr(dgCustomerOrderItems.Rows(a).Cells("ci_type").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_productcode").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_remarks").Value),
                                                    If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "New", CStr(dgCustomerOrderItems.Rows(a).Cells("ci_tags").Value), Me)
                                                saveBundleItems(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value), If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), globalorderitemidsp, CStr(dgCustomerOrderItems.Rows(a).Cells("ci_tags").Value))
                                            End If
                                        End If
                                    End If
                                Else
                                    Exit Sub
                                End If
                            Next
                        End If
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                            dgCustomerOrderListPerformClick()
                        End If
                    End If
                Else
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
            connection.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msDuplicate_Click(sender As Object, e As EventArgs) Handles msDuplicate.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.COForm = False
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
            If MessageBox.Show("Would you like to duplicate this order?", "Duplicating", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                duplicateCustomerOrder(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                duplicateCustomerOrderItems(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                If myModule.systemerrorfound = False Then
                    MessageBox.Show("Successfully Duplicated, you have created Customer Order No. " & globalorderno & "", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tsrefreshperformclick()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msSubmit_Click(sender As Object, e As EventArgs) Handles msSubmit.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            customerorderitemscomputations()
            dgCustomerOrderItems.CommitEdit(legit) : dgCustomerOrderItems.ClearSelection() : dgCustomerOrderItems.CurrentCell = Nothing
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.COForm = False
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
            If dgCustomerOrderList.Rows.Count <> 0 Then
                If LTrim(cboCustomerName.Text) <> "" Then
                    getCustomerID(cboCustomerName.Text, Me)
                    cocustomerid = globalcustomerid
                    If LTrim(txtPONo.Text) <> "" Then
                        If cocustomerid = 0 Then
                            errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                            Exit Try
                        Else
                            'getOrderIDB(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                            'coorderid = globalorderid
                            'If coorderid <> 0 Then
                            '    errProvider.SetError(txtPONo, "P.O No. and customer name been created already, please type a new one.")
                            '    Exit Try
                            'End If
                        End If
                    Else
                        errProvider.SetError(txtPONo, "Please enter the P.O. no.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddCustomer, "Please enter the customer name.")
                    Exit Try
                End If
            Else
                errProvider.SetError(pbAddCustomer, "System cannot find the customer order.")
                Exit Try
            End If
            'If LTrim(txtSIDRNo.Text) <> "" Then
            '    getOrderIDF(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
            '    coorderid = globalorderid
            '    If coorderid <> 0 Then
            '        errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
            '        Exit Try
            '    End If
            'End If
            If dgCustomerOrderList.Rows.Count <> 0 Then
                getOrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Me)
                If globalorderstatus <> "New" Then
                    MessageBox.Show("This customer order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            If dgCustomerOrderItems.Rows.Count = 0 Then
                MessageBox.Show("There are no customer order items to be submitted.", "Submitting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            coincompleteqtyavailablecue = fraud
            For a = 0 To dgCustomerOrderItems.Rows.Count - 1
                dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").ErrorText = Nothing
                If CStr(dgCustomerOrderItems.Rows(a).Cells("ci_type").Value) = "B" Then
                    If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value) Then
                        If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value) <> 0 Then
                            getOrderItemInfo(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value), Me)
                            checkBundleItemsB(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value), globalorderitemqtyordered, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                            If coincompleteqtyavailablecue = legit Then
                                MessageBox.Show("One or more bundle item(s) qty. ordered is greater than the qty. orderable.", "Submitting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Try
                            End If
                        End If
                    Else
                        If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value) Then
                            If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value) <> 0 Then
                                checkBundleItemsA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value), If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0))
                                If coincompleteqtyavailablecue = legit Then
                                    MessageBox.Show("One or more bundle item(s) qty. ordered is greater than the qty. orderable.", "Submitting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                End If
                            End If
                        End If
                    End If
                Else
                    If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                        If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                            getTotalQtyAvailableA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                            getTotalQtyAllocatedA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                            getTotalQtyOrderedA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), $"AND oi.`status` = 'New' AND o.`status` = 'Submitted To Warehouse' AND o.ordertype = '{OrderType.CO.ToString()}'", Me)
                            If globaltotalqtyavailable - (globaltotalqtyallocated + globaltotalqtyordered) < If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0) Then
                                dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").ErrorText = "Qty. Orderable is less than qty. ordered."
                                Exit Try
                            End If
                        End If
                    End If
                End If
            Next
            If MessageBox.Show("NOTE: Submitting this customer order means that you have completed, checked, and satisfied this order." & vbNewLine & "" & vbNewLine & "Do you want to proceed submitting this order?", "Submitting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If dgCustomerOrderList.Rows.Count <> 0 Then
                    getOrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Me)
                    If globalorderstatus <> "New" Then
                        MessageBox.Show("This customer order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                End If
                coincompleteqtyavailablecue = fraud
                For a = 0 To dgCustomerOrderItems.Rows.Count - 1
                    dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").ErrorText = Nothing
                    If CStr(dgCustomerOrderItems.Rows(a).Cells("ci_type").Value) = "B" Then
                        If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value) Then
                            If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value) <> 0 Then
                                getOrderItemInfo(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value), Me)
                                checkBundleItemsB(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value), globalorderitemqtyordered, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                                If coincompleteqtyavailablecue = legit Then
                                    MessageBox.Show("One or more bundle item(s) qty. ordered is greater than the qty. orderable.", "Submitting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                End If
                            End If
                        Else
                            If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value) Then
                                If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value) <> 0 Then
                                    checkBundleItemsA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value), If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0))
                                    If coincompleteqtyavailablecue = legit Then
                                        MessageBox.Show("One or more bundle item(s) qty. ordered is greater than the qty. orderable.", "Submitting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Try
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                            If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                getTotalQtyAvailableA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                getTotalQtyAllocatedA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                getTotalQtyOrderedA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), $"AND oi.`status` = 'New' AND o.`status` = 'Submitted To Warehouse' AND o.ordertype = '{OrderType.CO.ToString()}'", Me)
                                If globaltotalqtyavailable - (globaltotalqtyallocated + globaltotalqtyordered) < If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0) Then
                                    dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").ErrorText = "Qty. Orderable is less than qty. ordered."
                                    Exit Try
                                End If
                            End If
                        End If
                    End If
                Next
                If dgCustomerOrderList.Rows.Count <> 0 Then
                    getBranchCodeIDB(cboBranchCodeNameInfo.Text, Me)
                    cobranchid = globalbranchid
                    getCompanyIDB(cboVendorCodeNameInfo.Text, Me)
                    covendorid = globalcompanyid
                    getCombineCodingsIDB(cboClassDescription.Text, Me)
                    cocombinecodingid = globalcombinecodingid
                    'getCustomerID(cboCustomerName.Text, Me)
                    'cocustomerid = globalcustomerid
                    'getOrderIDB(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtPONo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                    'coorderid = globalorderid
                    'If coorderid <> 0 Then
                    '    errProvider.SetError(txtPONo, "P.O. No. and customer name has been created already, please type a new one.")
                    '    Exit Try
                    'End If
                    'If LTrim(txtSIDRNo.Text) <> "" Then
                    '    getOrderIDF(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                    '    coorderid = globalorderid
                    '    If coorderid <> 0 Then
                    '        errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
                    '        Exit Try
                    '    End If
                    'End If
                    U_Orders(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, cocustomerid, If(cobranchid = 0, DBNull.Value, cobranchid), If(covendorid = 0, DBNull.Value, covendorid), If(cocombinecodingid = 0, DBNull.Value, cocombinecodingid),
                                txtCustomerOrderNo.Text, txtPONo.Text, txtSIDRNo.Text, dtpCustomerOrderDate.Value, dtpDeliveryDate.Value, dtpEndDate.Value, txtComments.Text, Math.Round(coitotalprice, 2), txtDeliveryHours.Text, txtDeliveryAddress.Text, cboCustomerOrderType.Text, Me, AgentId:=CInt(cboAgent.SelectedValue))
                    U_OrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Submitted To Warehouse", Me)
                    U_OrderDateSubmitted(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Date.Now.ToString("yyyy/MM/dd"), Me)
                    If dgCustomerOrderItems.Rows.Count <> 0 Then
                        For a = 0 To dgCustomerOrderItems.Rows.Count - 1
                            If myModule.systemerrorfound = False Then
                                If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value) Then
                                    If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value) <> 0 Then
                                        If CStr(dgCustomerOrderItems.Rows(a).Cells("ci_type").Value) = "B" Then
                                            getOrderItemInfo(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value), Me)
                                            If globalorderitemqtyordered <> If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0) Then
                                                updateBundleItemsA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value), globalorderitemqtyordered, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                                            End If
                                            updateBundleItemsB(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value), CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_tags").Value))
                                        End If
                                        If myModule.systemerrorfound = False Then
                                            U_OrderItems(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, cocustomerid, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0),
                                                If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_remarks").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_tags").Value), Me)
                                        End If
                                    End If
                                Else
                                    If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value) Then
                                        If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value) <> 0 Then
                                            'getTotalQtyAvailableA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                            'getTotalQtyAllocatedA(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Me)
                                            I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cocustomerid, CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), DBNull.Value,
                                                DBNull.Value, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), 0, CStr(dgCustomerOrderItems.Rows(a).Cells("ci_type").Value),
                                                "" & CStr(dgCustomerOrderItems.Rows(a).Cells("ci_productcode").Value) & " / " & CStr(dgCustomerOrderItems.Rows(a).Cells("ci_colorname").Value) & " / " & CStr(dgCustomerOrderItems.Rows(a).Cells("ci_size").Value) & " / " & CStr(dgCustomerOrderItems.Rows(a).Cells("ci_seasoncode").Value) & "",
                                                CStr(dgCustomerOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_remarks").Value), If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "New", CStr(dgCustomerOrderItems.Rows(a).Cells("ci_tags").Value), Me)
                                            If myModule.systemerrorfound = False Then
                                                U_ProductColorSizeSoldInfo(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_pcsrowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), dtpCustomerOrderDate.Value, Me)
                                            End If
                                        End If
                                    End If
                                    If IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value) Then
                                        If CInt(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value) <> 0 Then
                                            I_OrderItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cocustomerid, CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), DBNull.Value, CInt(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value), DBNull.Value, If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0),
                                                0, CStr(dgCustomerOrderItems.Rows(a).Cells("ci_type").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_productcode").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_sku").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_unitofmeasure").Value), CStr(dgCustomerOrderItems.Rows(a).Cells("ci_remarks").Value),
                                                If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), CDec(dgCustomerOrderItems.Rows(a).Cells("ci_srp").Value), 0.0), "New", CStr(dgCustomerOrderItems.Rows(a).Cells("ci_tags").Value), Me)
                                            saveBundleItems(CInt(dgCustomerOrderItems.Rows(a).Cells("ci_bid").Value), If(IsNumeric(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), CInt(dgCustomerOrderItems.Rows(a).Cells("ci_qtyordered").Value), 0), CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), globalorderitemidsp, CStr(dgCustomerOrderItems.Rows(a).Cells("ci_tags").Value))
                                        End If
                                    End If
                                End If
                            Else
                                Exit Sub
                            End If
                        Next
                    End If
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Submitted", "Submit", lblsavemsg, -15, -65)
                    End If
                End If
                If myModule.systemerrorfound = False Then
                    tsrefreshperformclick()
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
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                If e.ColumnIndex = dgCustomerOrderItems.Columns("ci_option").Index Then
                    If IsNumeric(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value) Then
                        If dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value = 0 Then
                            If dgCustomerOrderItems.SelectedRows.Count > 0 Then
                                dgCustomerOrderItems.Rows.Remove(dgCustomerOrderItems.SelectedRows(0))
                            End If
                        Else
                            getPositionID(Me)
                            If globalpositionid <> 0 Then
                                getPositionView(globalpositionid, "Customer Orders", Me)
                                If globaldisableflg = "Y" Then
                                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    PrimaryForm.COForm = False
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
                            If dgCustomerOrderList.Rows.Count <> 0 Then
                                getOrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Me)
                                If globalorderstatus <> txtStatus.Text Then
                                    MessageBox.Show("This customer order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Try
                                ElseIf globalorderstatus = "New" Then
                                    If MessageBox.Show("Would you like to delete this item from this list?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                        Me.Cursor = Cursors.WaitCursor
                                        getOrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Me)
                                        If globalorderstatus <> "New" Then
                                            MessageBox.Show("This customer order has been updated by other user, please click refresh button to check the new status of this order.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Exit Try
                                        End If
                                        getOrderItemInfo(CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value), Me)
                                        getOrderTotalAmount(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Me)
                                        U_OrderTotalAmount(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, globalordertotalamount - Math.Round(globalorderitemsrp * globalorderitemqtyordered, 2), Me)
                                        If myModule.systemerrorfound = False Then
                                            U_OrderItemStatus(CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive", Me)
                                        End If
                                        If myModule.systemerrorfound = False Then
                                            If CStr(dgCustomerOrderItems.CurrentRow.Cells("ci_type").Value) = "B" Then
                                                deleteBundleItems(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), CInt(dgCustomerOrderItems.CurrentRow.Cells("ci_rowid").Value))
                                            End If
                                        End If
                                        If myModule.systemerrorfound = False Then
                                            If dgCustomerOrderItems.SelectedRows.Count > 0 Then
                                                dgCustomerOrderItems.Rows.Remove(dgCustomerOrderItems.SelectedRows(0))
                                            End If
                                            myBalloon("Successfully Deleted", "Delete", lblsavemsg, -15, -65)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If dgCustomerOrderItems.SelectedRows.Count > 0 Then
                            dgCustomerOrderItems.Rows.Remove(dgCustomerOrderItems.SelectedRows(0))
                        End If
                    End If
                    itemno = startingpage
                    For i As Integer = 0 To dgCustomerOrderItems.Rows.Count - 1
                        dgCustomerOrderItems.Rows(i).Cells("ci_seqno").Value = itemno
                        itemno = itemno + 1
                    Next i
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbSaveSIDR_MouseEnter(sender As Object, e As EventArgs) Handles pbSaveSIDRNo.MouseEnter
        Try
            pbSaveSIDRNo.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbSaveSIDR_MouseLeave(sender As Object, e As EventArgs) Handles pbSaveSIDRNo.MouseLeave
        Try
            pbSaveSIDRNo.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbSaveSIDRNo_Click(sender As Object, e As EventArgs) Handles pbSaveSIDRNo.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            If cue = "Edit" Then
                getPositionID(Me)
                If globalpositionid <> 0 Then
                    getPositionView(globalpositionid, "Customer Orders", Me)
                    If globaldisableflg = "Y" Then
                        MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        PrimaryForm.COForm = False
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
                If dgCustomerOrderList.Rows.Count <> 0 Then
                    getOrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Me)
                    If globalorderstatus = "Delivery" Then
                        MessageBox.Show("System cannot update the S.I./D.R. No. since this customer order has been delivered already.", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    ElseIf globalorderstatus = "Cancelled" Then
                        MessageBox.Show("System cannot update the S.I./D.R. No. since this customer order has been cancelled already.", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                    If LTrim(cboCustomerName.Text) <> "" Then
                        getCustomerID(cboCustomerName.Text, Me)
                        cocustomerid = globalcustomerid
                        If LTrim(txtSIDRNo.Text) <> "" Then
                            If cocustomerid = 0 Then
                                errProvider.SetError(pbAddCustomer, "System cannot find the customer name.")
                                Exit Try
                            Else
                                'getOrderIDF(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                                'coorderid = globalorderid
                                'If coorderid <> 0 Then
                                '    errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
                                '    Exit Try
                                'End If
                            End If
                        Else
                            errProvider.SetError(pbSaveSIDRNo, "Please enter the S.I./D.R. No.")
                            Exit Try
                        End If
                    Else
                        errProvider.SetError(pbAddCustomer, "Please enter the customer name.")
                        Exit Try
                    End If
                    If MessageBox.Show("Would you like to update the S.I./D.R. No. of this customer order?", "Updating", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        getOrderStatus(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Me)
                        If globalorderstatus = "Delivery" Then
                            MessageBox.Show("System cannot update the S.I./D.R. No. since this customer order has been delivered already.", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        ElseIf globalorderstatus = "Cancelled" Then
                            MessageBox.Show("System cannot update the S.I./D.R. No. since this customer order has been cancelled already.", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Try
                        End If
                        'getOrderIDF(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), txtSIDRNo.Text, "CO", cocustomerid, "AND `status` != 'Cancelled'", Me)
                        'coorderid = globalorderid
                        'If coorderid <> 0 Then
                        '    errProvider.SetError(pbSaveSIDRNo, "S.I./D.R. No. and customer name has been created already, please type a new one.")
                        '    Exit Try
                        'End If
                        U_OrderDRNumber(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtSIDRNo.Text, Me)
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

    Private Sub pbAddBranchCodeName_MouseEnter(sender As Object, e As EventArgs) Handles pbAddBranchCodeName.MouseEnter
        Try
            pbAddBranchCodeName.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub cboInventoryLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboInventoryLocation.SelectedIndexChanged

    End Sub

    Private Sub cboCustomerOrderType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomerOrderType.SelectedIndexChanged
        If cboCustomerOrderType.SelectedValue IsNot Nothing Then errProvider.SetError(cboCustomerOrderType, String.Empty)

        If msNew.Enabled AndAlso Not cboCustomerOrderType.SelectedIndex = -1 Then Return

        Dim inventoryLocationType = CType(cboCustomerOrderType.SelectedValue, InventoryLocationType)

        Dim dataSource = cboInventoryLocation.Items.
            OfType(Of Object).
            Select(Function(t) CType(t, InventoryLocation)).
            Where(Function(t) t.Type = inventoryLocationType).
            ToList()

        If Not dataSource.Any() Then
            MessageBox.Show(text:=$"No Inventory Location for type `{inventoryLocationType}`.{Environment.NewLine}{Environment.NewLine}You need to create a new Inventory Location with type `{inventoryLocationType}`.{Environment.NewLine}{Environment.NewLine}Go to `Menu` > `Inventory Management` > `(L) Inventory Locations`",
                caption:="No Inventory Location",
                icon:=MessageBoxIcon.Error,
                buttons:=MessageBoxButtons.OK)

            cboCustomerOrderType.SelectedIndex = -1
            Return
        End If

        If dataSource.Count() > 1 Then
            Dim form = New CustomerOrderInventoryLocationSelectorDialog(inventoryLocations:=dataSource)
            If form.ShowDialog() = DialogResult.OK Then
                cboInventoryLocation.SelectedValue = form.InventoryLocationId
            Else
                cboCustomerOrderType.SelectedIndex = -1
            End If
        Else
            cboInventoryLocation.SelectedValue = dataSource.FirstOrDefault().RowID.Value
        End If
    End Sub

    Private Sub cboAgent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAgent.SelectedIndexChanged

    End Sub

    Private Async Sub btnAddAgent_Click(sender As Object, e As EventArgs) Handles btnAddAgent.Click
        Dim form As New AddContactForm(contactType:=ContactType.Agent, True)
        If form.ShowDialog() = DialogResult.OK Then
            Await GetAgentsAsync()
        End If
    End Sub

    Private Sub pbAddBranchCodeName_MouseLeave(sender As Object, e As EventArgs) Handles pbAddBranchCodeName.MouseLeave
        Try
            pbAddBranchCodeName.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAddOrderItem.Click
        Dim inventoryLocationId = CInt(cboInventoryLocation.SelectedValue)

        'btnAddperformclick()
    End Sub

    Private Sub gbCustomerOrderItems_EnabledChanged(sender As Object, e As EventArgs) Handles gbCustomerOrderItems.EnabledChanged
        Panel1.Enabled = gbCustomerOrderItems.Enabled
    End Sub

    Private Sub pbAddBranchCodeName_Click(sender As Object, e As EventArgs) Handles pbAddBranchCodeName.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.COForm = False
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
            Dim addbranchcodenamelinkform As New AddBranchCodeNameForm
            addbranchcodenamelinkform.ShowInTaskbar = False
            addbranchcodenamelinkform.ShowDialog()
            If addbranchcodenamelinkform.addbranchcodenamecue = legit Then
                globalautocompleteBranchCodeName(cboBranchCodeNameInfo, Me)
                globalautopopulateBranchCodeName(cboBranchCodeNameInfo, Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbAddVendorCodeName_MouseEnter(sender As Object, e As EventArgs) Handles pbAddVendorCodeName.MouseEnter
        Try
            pbAddVendorCodeName.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddVendorCodeName_MouseLeave(sender As Object, e As EventArgs) Handles pbAddVendorCodeName.MouseLeave
        Try
            pbAddVendorCodeName.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddVendorCodeName_Click(sender As Object, e As EventArgs) Handles pbAddVendorCodeName.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.COForm = False
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
            Dim addvendorcodenamelinkform As New AddVendorCodeNameForm
            addvendorcodenamelinkform.ShowInTaskbar = False
            addvendorcodenamelinkform.ShowDialog()
            If addvendorcodenamelinkform.addvendorcodenamecue = legit Then
                globalautocompleteVendorCodeName(cboVendorCodeNameInfo, Me)
                globalautopopulateVendorCodeName(cboVendorCodeNameInfo, Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbAddClassDescription_MouseEnter(sender As Object, e As EventArgs) Handles pbAddClassDescription.MouseEnter
        Try
            pbAddClassDescription.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddClassDescription_MouseLeave(sender As Object, e As EventArgs) Handles pbAddClassDescription.MouseLeave
        Try
            pbAddClassDescription.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddClassDescription_Click(sender As Object, e As EventArgs) Handles pbAddClassDescription.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.COForm = False
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
            Dim addclassdescriptionlinkform As New AddClassDescriptionForm
            addclassdescriptionlinkform.ShowInTaskbar = False
            addclassdescriptionlinkform.ShowDialog()
            If addclassdescriptionlinkform.addclassdescriptioncue = legit Then
                globalautocompleteClassDescription(cboClassDescription, Me)
                globalautopopulateClassDescription(cboClassDescription, Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbAddTags_MouseEnter(sender As Object, e As EventArgs) Handles pbAddTags.MouseEnter
        Try
            pbAddTags.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddTags_MouseLeave(sender As Object, e As EventArgs) Handles pbAddTags.MouseLeave
        Try
            pbAddTags.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddTags_Click(sender As Object, e As EventArgs) Handles pbAddTags.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.COForm = False
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
            Dim addtagslinkform As New AddTagsForm
            addtagslinkform.ShowInTaskbar = False
            addtagslinkform.ShowDialog()
            If addtagslinkform.addtagscue = legit Then
                globalautocompleteListOfValues(cboTags, "Tags", Me)
                globalautopopulateListOfValues(cboTags, "Tags", Me)
                autopopulateTags()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msPrint_Click(sender As Object, e As EventArgs) Handles msPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Customer Orders", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.COForm = False
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
            If dgCustomerOrderList.Rows.Count <> 0 Then
                If MessageBox.Show("Would you like to print the VDR?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    printCustomerOrderItems(CInt(dgCustomerOrderList.CurrentRow.Cells("co_rowid").Value))
                    Dim printreport As New VendorReportPrint
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
            ElseIf cboSearch1.Text = "CustomerName" Then
                autocompleteCustomerName(cboSearch2)
                autopopulateCustomerName(cboSearch2)
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

    Private Sub cboSearch3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearch3.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If cboSearch3.Text = "" Then
                cboSearch4.Items.Clear() : cboSearch4.AutoCompleteCustomSource.Clear()
            ElseIf cboSearch3.Text = "CustomerName" Then
                autocompleteCustomerName(cboSearch4)
                autopopulateCustomerName(cboSearch4)
            ElseIf cboSearch1.Text = "Status" Then
                autocompleteStatus(cboSearch4)
                autopopulateStatus(cboSearch4)
            End If
            cboSearch4.Text = "" : cboSearch4.SelectedItem = Nothing
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
                If cboDate.Text = "" And cboSearch1.Text = "" And cboSearch3.Text = "" Then
                    tsrefreshperformclick()
                Else
                    If cboDate.Text <> "" And cboSearch1.Text = "" And cboSearch3.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "OrderDate" Then
                            datephrase = "co.orderdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        ElseIf cboDate.Text = "TargetDate" Then
                            datephrase = "co.targetdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        End If
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                    ElseIf cboDate.Text <> "" And cboSearch2.Text = "" And cboSearch4.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "OrderDate" Then
                            datephrase = "co.orderdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        ElseIf cboDate.Text = "TargetDate" Then
                            datephrase = "co.targetdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        End If
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
                        If cboSearch3.Text = "" Then
                            pagefilter2 = ""
                        Else
                            getCommonPhrase(cboSearch3, cboSearch4.Text)
                            pagefilter2 = "" & commonphrase & ""
                        End If
                        If pagefilter1 = "" Then
                            pagefilter3 = pagefilter2
                        ElseIf pagefilter2 = "" Then
                            pagefilter3 = pagefilter1
                        Else
                            pagefilter3 = "" & pagefilter1 & " AND " & pagefilter2 & ""
                        End If
                        If cboDate.Text = "OrderDate" Then
                            pagefilter4 = " AND (co.orderdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                    "co.orderdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        ElseIf cboDate.Text = "TargetDate" Then
                            pagefilter4 = " AND (co.targetdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                    "co.targetdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        Else
                            pagefilter4 = ""
                        End If
                        spagenum = neutralpage : numofpages = startingpage
                        displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
                        pageSetup3(pagefilter3, pagefilter4)
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

    Private Sub cboSearch4_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSearch4.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If cboDate.Text = "" And cboSearch1.Text = "" And cboSearch3.Text = "" Then
                    tsrefreshperformclick()
                Else
                    If cboDate.Text <> "" And cboSearch1.Text = "" And cboSearch3.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "OrderDate" Then
                            datephrase = "co.orderdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        ElseIf cboDate.Text = "TargetDate" Then
                            datephrase = "co.targetdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        End If
                        txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                    ElseIf cboDate.Text <> "" And cboSearch2.Text = "" And cboSearch4.Text = "" Then
                        txtSimpleSearch.Text = ""
                        clearRightPage()
                        searchmode = "DateSearch"
                        spagenum = neutralpage : numofpages = startingpage
                        If cboDate.Text = "OrderDate" Then
                            datephrase = "co.orderdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        ElseIf cboDate.Text = "TargetDate" Then
                            datephrase = "co.targetdate"
                            displayDateSearch(spagenum, datephrase)
                            pageSetup2(datephrase)
                        End If
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
                        If cboSearch3.Text = "" Then
                            pagefilter2 = ""
                        Else
                            getCommonPhrase(cboSearch3, cboSearch4.Text)
                            pagefilter2 = "" & commonphrase & ""
                        End If
                        If pagefilter1 = "" Then
                            pagefilter3 = pagefilter2
                        ElseIf pagefilter2 = "" Then
                            pagefilter3 = pagefilter1
                        Else
                            pagefilter3 = "" & pagefilter1 & " AND " & pagefilter2 & ""
                        End If
                        If cboDate.Text = "OrderDate" Then
                            pagefilter4 = " AND (co.orderdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                    "co.orderdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        ElseIf cboDate.Text = "TargetDate" Then
                            pagefilter4 = " AND (co.targetdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                                    "co.targetdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "') "
                        Else
                            pagefilter4 = ""
                        End If
                        spagenum = neutralpage : numofpages = startingpage
                        displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
                        pageSetup3(pagefilter3, pagefilter4)
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
                displayCustomerOrderList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
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
                displayCustomerOrderList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
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
                displayCustomerOrderList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
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
                displayCustomerOrderList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
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
                            displayCustomerOrderList(spagenum)
                        ElseIf searchmode = "CommonSearch" Then
                            displayCommonPhrase(pagefilter3, pagefilter4, spagenum)
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

    Private Sub dgProductColorSizes_MouseUp(sender As Object, e As MouseEventArgs) Handles dgProductColorSizes.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgProductColorSizes.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgProductColorSizes.BeginEdit(True)
                Else
                    dgProductColorSizes.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgProductSizes_MouseUp(sender As Object, e As MouseEventArgs) Handles dgProductSizes.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgProductSizes.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgProductSizes.BeginEdit(True)
                Else
                    dgProductSizes.EndEdit()
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

    Private Sub dgCustomerOrderList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCustomerOrderList.DataError
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
                dgCustomerOrderList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProductColorSizes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProductColorSizes.DataError
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
                dgProductColorSizes.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProductColors_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProductColors.DataError
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
                dgProductColors.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProductSizes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProductSizes.DataError
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
                dgProductSizes.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgBundleItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgBundleItems.DataError
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
                dgBundleItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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

#End Region

    Private ReadOnly Property IsThurston As Boolean
        Get
            Return _systemOwner.IsThurston
        End Get
    End Property
End Class