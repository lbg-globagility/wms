Option Strict On

Imports Microsoft.Extensions.DependencyInjection
Imports MySql.Data.MySqlClient
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Repositories
Imports WarehouseManagementSystem.Desktop.Utilities
Imports WarehouseManagementSystem.Utilities.Extensions
Imports WarehouseManagementSystem.Infrastructure.Data.Extensions.ProductInventoryLocationExtensions

Public Class InventoryLocationsForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim conn2 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim cue, searchmode As String
    Dim itemno, rowscount As Integer
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal
    Dim simplesearchphrase, commonphrase, pagefilter1, pagefilter2, pagefilter3 As String
    Dim spagenum, countpagenum, numofpages, validpages, rcspagenum, rcscountpagenum, rcsnumofpages, rcsvalidpages As Integer
    Dim iltotalqtyavailable, iltotalqtyreserve, iltotalqtydamage, iltotalqtyallocated, iltotalqtyorderable, ilinventorylocationid, iladdressid, ilrackshelfcolumnid As Integer
    Private _systemOwner As SystemOwner
    Private _picp As ProductImageConfigParser
    Private ReadOnly Property ProductColorSizeModels As List(Of ProductColorSizeModel)

    Private Async Sub InventoryLocationsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        gridProductColorSizes.AutoGenerateColumns = False
        gridRackShelfColumns.AutoGenerateColumns = False

        _picp = New ProductImageConfigParser(filePath:=CONFIG_FILE_PATH)

        If IsThurston Then
            SplitContainer3.Panel1Collapsed = True
            SplitContainer3.Panel2Collapsed = False

        Else
            SplitContainer3.Panel1Collapsed = False
            SplitContainer3.Panel2Collapsed = True
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            displayInventoryLocationList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub InventoryLocationsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            myBalloon(, , lblsavemsg, , , 1)
            myBalloon(, , pbAutoAddRack, , , 1)
            myBalloon(, , pbAutoAddColumn, , , 1)
            myBalloon(, , pbAutoAddShelf, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#Region "Functions"

    Sub callAutoCompleteFunctions()
        autocompleteRack(cboRack)
        autocompleteShelf(cboShelf)
        autocompleteColumn(cboColumn)
    End Sub

    Sub callAutoPopulateFunctions()
        autopopulatecboSearch()
        autopopulateLocationTypeB(cboLocationType)
        autopopulateRack(cboRack)
        autopopulateShelf(cboShelf)
        autopopulateColumn(cboColumn)
    End Sub

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            cue = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearInventoryLocationInformation()
            cleargbAddRSC()
            clearDataGrids()
            visibleProducts(fraud)
            enableGB(legit, fraud, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRightPage()
        Try
            cue = ""
            clearInventoryLocationInformation()
            cleargbAddRSC()
            clearDataGrids()
            visibleProducts(fraud)
            enableGB(legit, fraud, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud)
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
            cboSearch1.SelectedItem = Nothing
            cboSearch2.SelectedItem = Nothing
            cboSearch3.SelectedItem = Nothing
            cboSearch4.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearcboSearch()
        Try
            txtPage.Text = ""
            cboSearch1.SelectedItem = Nothing : cboSearch3.SelectedItem = Nothing
            cboSearch2.Items.Clear() : cboSearch2.AutoCompleteCustomSource.Clear()
            cboSearch2.Text = "" : cboSearch2.SelectedItem = Nothing
            cboSearch4.Items.Clear() : cboSearch4.AutoCompleteCustomSource.Clear()
            cboSearch4.Text = "" : cboSearch4.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearInventoryLocationInformation()
        Try
            txtLocationName.Text = ""
            cboLocationType.Text = ""
            txtMainPhone.Text = ""
            txtAddress.Text = ""
            txtAlternatePhone.Text = ""
            txtFaxNo.Text = ""
            txtComments.Text = ""
            txtPageNoRCS.Text = ""
            txtTotalProducts.Text = ""
            txtTotalQtyAvailable.Text = ""
            txtTotalQtyAllocated.Text = ""
            txtTotalQtyOrderable.Text = ""
            txtTotalQtyReserve.Text = ""
            txtTotalQtyDamage.Text = ""
            chkOtherInfo.Checked = fraud
            cboLocationType.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub cleargbAddRSC()
        Try
            cboRack.Text = ""
            cboShelf.Text = ""
            cboColumn.Text = ""
            txtPickOrderNo.Text = ""
            txtRemarks.Text = ""
            cboRack.SelectedItem = Nothing
            cboShelf.SelectedItem = Nothing
            cboColumn.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearDataGrids()
        Try
            dgRackShelfColumn.Rows.Clear()
            dgProducts.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean, ByVal enable4 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbInventoryLocationList.Enabled = enable1
            gbInventoryLocationInformation.Enabled = enable2
            'gbRackShelfColumn.Enabled = enable3
            'gbProducts.Enabled = enable4
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

    Sub visibleProducts(ByVal visible1 As Boolean)
        Try
            p_qtyavailable.Visible = visible1
            p_qtyallocated.Visible = visible1
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
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            displayInventoryLocationList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub btnAddRSCperformclick()
        Try
            errProvider.Clear()
            If LTrim(cboRack.Text) = "" And LTrim(cboShelf.Text) = "" And LTrim(cboColumn.Text) = "" Then
                errProvider.SetError(btnAddRSC, "Please fill-up rack,shelf and column fields.")
                cboRack.Focus()
            ElseIf LTrim(cboRack.Text) = "" Then
                errProvider.SetError(btnAddRSC, "Please fill-up rack,shelf and column fields.")
                cboRack.Focus()
            ElseIf LTrim(cboShelf.Text) = "" Then
                errProvider.SetError(btnAddRSC, "Please fill-up rack,shelf and column fields.")
                cboShelf.Focus()
            ElseIf LTrim(cboColumn.Text) = "" Then
                errProvider.SetError(btnAddRSC, "Please fill-up rack,shelf and column fields.")
                cboColumn.Focus()
            Else
                If dgRackShelfColumn.Rows.Count <> 0 Then
                    If cue = "New" Then
                        rowscount = dgRackShelfColumn.Rows.Count - 1
                        For i = 0 To dgRackShelfColumn.Rows.Count - 1
                            Dim rackShelfColumnConcat = String.Concat({dgRackShelfColumn.Rows(i).Cells("rsc_rack").Value, dgRackShelfColumn.Rows(i).Cells("rsc_shelf").Value, dgRackShelfColumn.Rows(i).Cells("rsc_column").Value})

                            If rackShelfColumnConcat = "" & cboRack.Text & "" & cboShelf.Text & "" & cboColumn.Text & "" Then
                                errProvider.SetError(btnAddRSC, "The rack,column, and shelf is in the list already.")
                                cboRack.Focus()
                                Exit Try
                            ElseIf rowscount = 0 Then
                                addRackShelfColumnRow()
                                For a = 0 To dgRackShelfColumn.Rows.Count - 1
                                    dgRackShelfColumn.CurrentRow.Selected = fraud
                                    If String.Concat({dgRackShelfColumn.Rows(a).Cells("rsc_rack").Value, dgRackShelfColumn.Rows(a).Cells("rsc_shelf").Value, dgRackShelfColumn.Rows(a).Cells("rsc_column").Value}) = "" & cboRack.Text & "" & cboShelf.Text & "" & cboColumn.Text & "" Then
                                        dgRackShelfColumn.Rows(dgRackShelfColumn.Rows.Count - 1).Selected = legit
                                        dgRackShelfColumn.FirstDisplayedScrollingRowIndex = dgRackShelfColumn.RowCount - 1
                                        Exit For
                                    End If
                                Next
                                cleargbAddRSC() : cboRack.Focus()
                            End If
                            rowscount = rowscount - 1
                        Next
                        itemno = 1
                        For i As Integer = 0 To dgRackShelfColumn.Rows.Count - 1
                            dgRackShelfColumn.Rows(i).Cells("rsc_seqno").Value = itemno
                            itemno = itemno + 1
                        Next i
                    ElseIf cue = "Edit" Then
                        getRackShelfColumnID("" & cboRack.Text & "" & cboShelf.Text & "" & cboColumn.Text & "", CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), Me)
                        If globalrackshelfcolumnid <> 0 Then
                            errProvider.SetError(btnAddRSC, "The rack,column, and shelf is in the list already.")
                            cboRack.Focus()
                            Exit Try
                        Else
                            rowscount = dgRackShelfColumn.Rows.Count - 1
                            For i = 0 To dgRackShelfColumn.Rows.Count - 1
                                If String.Concat({dgRackShelfColumn.Rows(i).Cells("rsc_rack").Value, dgRackShelfColumn.Rows(i).Cells("rsc_shelf").Value, dgRackShelfColumn.Rows(i).Cells("rsc_column").Value}) = "" & cboRack.Text & "" & cboShelf.Text & "" & cboColumn.Text & "" Then
                                    errProvider.SetError(btnAddRSC, "The rack,column, and shelf is in the list already.")
                                    cboRack.Focus()
                                    Exit Try
                                ElseIf rowscount = 0 Then
                                    If rcsnumofpages <> rcsvalidpages Then
                                        pageSetupRCS(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value))
                                        If rcscountpagenum < pagedivisor Then
                                            rcspagenum = neutralpage
                                        Else
                                            rcspagenum = rcscountpagenum - pagedivisor
                                        End If
                                        rcsnumofpages = rcsvalidpages
                                        displayRackShelfColumn(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), rcspagenum)
                                        txtPageNoRCS.Text = "" & rcsnumofpages & " of " & rcsvalidpages & " "
                                    End If
                                    addRackShelfColumnRow()
                                    For a = 0 To dgRackShelfColumn.Rows.Count - 1
                                        dgRackShelfColumn.CurrentRow.Selected = fraud
                                        If String.Concat({dgRackShelfColumn.Rows(a).Cells("rsc_rack").Value, dgRackShelfColumn.Rows(a).Cells("rsc_shelf").Value, dgRackShelfColumn.Rows(a).Cells("rsc_column").Value}) = "" & cboRack.Text & "" & cboShelf.Text & "" & cboColumn.Text & "" Then
                                            dgRackShelfColumn.Rows(dgRackShelfColumn.Rows.Count - 1).Selected = legit
                                            dgRackShelfColumn.FirstDisplayedScrollingRowIndex = dgRackShelfColumn.RowCount - 1
                                            Exit For
                                        End If
                                    Next
                                    cleargbAddRSC() : cboRack.Focus()
                                    For a As Integer = 0 To dgRackShelfColumn.Rows.Count - 1
                                        If CInt(dgRackShelfColumn.Rows(a).Cells("rsc_seqno").Value) = neutralpage Then
                                            itemno = startingpage
                                        Else
                                            itemno = CInt(dgRackShelfColumn.Rows(a).Cells("rsc_seqno").Value)
                                        End If
                                        Exit For
                                    Next
                                    For d As Integer = 0 To dgRackShelfColumn.Rows.Count - 1
                                        dgRackShelfColumn.Rows(d).Cells("rsc_seqno").Value = itemno
                                        itemno = itemno + 1
                                    Next d
                                End If
                                rowscount = rowscount - 1
                            Next
                        End If
                    End If
                Else
                    addRackShelfColumnRow()
                    For a = 0 To dgRackShelfColumn.Rows.Count - 1
                        dgRackShelfColumn.CurrentRow.Selected = fraud
                        If String.Concat({dgRackShelfColumn.Rows(a).Cells("rsc_rack").Value, dgRackShelfColumn.Rows(a).Cells("rsc_shelf").Value, dgRackShelfColumn.Rows(a).Cells("rsc_column").Value}) = "" & cboRack.Text & "" & cboShelf.Text & "" & cboColumn.Text & "" Then
                            dgRackShelfColumn.Rows(dgRackShelfColumn.Rows.Count - 1).Selected = legit
                            dgRackShelfColumn.FirstDisplayedScrollingRowIndex = dgRackShelfColumn.RowCount - 1
                            Exit For
                        End If
                    Next
                    cleargbAddRSC() : cboRack.Focus()
                    itemno = 1
                    For i As Integer = 0 To dgRackShelfColumn.Rows.Count - 1
                        dgRackShelfColumn.Rows(i).Cells("rsc_seqno").Value = itemno
                        itemno = itemno + 1
                    Next i
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Computations"

    Sub totalcomputation()
        Try
            iltotalqtyavailable = 0 : iltotalqtyreserve = 0 : iltotalqtydamage = 0
            iltotalqtyallocated = 0 : iltotalqtyorderable = 0
            If dgProducts.Rows.Count <> 0 Then
                For i = 0 To dgProducts.Rows.Count - 1
                    If IsNumeric(dgProducts.Rows(i).Cells("p_qtyavailable").Value) Then
                        iltotalqtyavailable = iltotalqtyavailable + CInt(dgProducts.Rows(i).Cells("p_qtyavailable").Value)
                    End If
                    If IsNumeric(dgProducts.Rows(i).Cells("p_qtyallocated").Value) Then
                        iltotalqtyallocated = iltotalqtyallocated + CInt(dgProducts.Rows(i).Cells("p_qtyallocated").Value)
                    End If
                    If IsNumeric(dgProducts.Rows(i).Cells("p_qtyorderable").Value) Then
                        iltotalqtyorderable = iltotalqtyorderable + CInt(dgProducts.Rows(i).Cells("p_qtyorderable").Value)
                    End If
                    If IsNumeric(dgProducts.Rows(i).Cells("p_qtyreserve").Value) Then
                        iltotalqtyreserve = iltotalqtyreserve + CInt(dgProducts.Rows(i).Cells("p_qtyreserve").Value)
                    End If
                    If IsNumeric(dgProducts.Rows(i).Cells("p_qtydamage").Value) Then
                        iltotalqtydamage = iltotalqtydamage + CInt(dgProducts.Rows(i).Cells("p_qtydamage").Value)
                    End If
                Next
            End If
            txtTotalProducts.Text = Format(dgProducts.Rows.Count, "#,##0")
            txtTotalQtyAvailable.Text = Format(iltotalqtyavailable, "#,##0")
            txtTotalQtyAllocated.Text = Format(iltotalqtyallocated, "#,##0")
            txtTotalQtyOrderable.Text = Format(iltotalqtyorderable, "#,##0")
            txtTotalQtyReserve.Text = Format(iltotalqtyreserve, "#,##0")
            txtTotalQtyDamage.Text = Format(iltotalqtydamage, "#,##0")
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
                additionalpage = CDec(countpagenum / pagedivisor)
                If additionalpage = Int(additionalpage) Then
                    validpages = CInt(countpagenum / pagedivisor)
                Else
                    validpages = CInt(countpagenum / pagedivisor)
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
            dtCid = CType(getDataTableForSQL(COMMD:=$"SELECT COUNT(il.rowid) FROM inventorylocations il WHERE il.organizationid = {Z_OrganizationID}"), DataTable)
            If dtCid.Rows.Count <> 0 Then
                countpagenum = CInt(dtCid.Rows(0)(0))
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
                additionalpage = CDec(countpagenum / pagedivisor)
                If additionalpage = Int(additionalpage) Then
                    validpages = CInt(countpagenum / pagedivisor)
                Else
                    validpages = CInt(countpagenum / pagedivisor)
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
            dtCid = CType(getDataTableForSQL($"SELECT COUNT(il.rowid) FROM inventorylocations il LEFT JOIN rackshelfcolumn rsc ON il.rowid = rsc.inventorylocationid  WHERE il.organizationid = {Z_OrganizationID} AND (il.name LIKE ""%{esearchstring}%"" OR il.type LIKE ""%{esearchstring}%"" OR rsc.rackno LIKE ""%{esearchstring}%"" OR rsc.shelfno LIKE ""%{esearchstring}%"" OR rsc.columnno LIKE ""%{esearchstring}%"")"), DataTable)
            If dtCid.Rows.Count <> 0 Then
                countpagenum = CInt(dtCid.Rows(0)(0))
            Else
                countpagenum = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub pageSetup2(ByVal isearchstring As String)
        Try
            getCountPageNum2(isearchstring)
            If countpagenum < pagedivisor Then
                validpages = startingpage
            Else
                additionalpage = CDec(countpagenum / pagedivisor)
                If additionalpage = Int(additionalpage) Then
                    validpages = CInt(countpagenum / pagedivisor)
                Else
                    validpages = CInt(countpagenum / pagedivisor)
                    validpages = validpages + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNum2(ByVal ecommontring As String)
        Try
            countpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = CType(getDataTableForSQL($"SELECT COUNT(il.rowid) FROM inventorylocations il LEFT JOIN rackshelfcolumn rsc ON il.rowid = rsc.inventorylocationid WHERE il.organizationid = {Z_OrganizationID} AND {ecommontring} "), DataTable)
            If dtCid.Rows.Count <> 0 Then
                countpagenum = CInt(dtCid.Rows(0)(0))
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
            If icommonbox.Text = "Column" Then
                commonphrase = "rsc.columnno = """ & icommonstring & """"
            ElseIf icommonbox.Text = "LocationType" Then
                commonphrase = "il.type = """ & icommonstring & """"
            ElseIf icommonbox.Text = "Rack" Then
                commonphrase = "rsc.rackno = """ & icommonstring & """"
            ElseIf icommonbox.Text = "Shelf" Then
                commonphrase = "rsc.shelfno = """ & icommonstring & """"
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub pageSetupRCS(ByVal iinventorylocationid As Integer)
        Try
            getCountPageNumRCS(iinventorylocationid)
            If rcscountpagenum < pagedivisor Then
                rcsvalidpages = startingpage
            Else
                additionalpage = CDec(rcscountpagenum / pagedivisor)
                If additionalpage = Int(additionalpage) Then
                    rcsvalidpages = CInt(rcscountpagenum / pagedivisor)
                Else
                    rcsvalidpages = CInt(rcscountpagenum / pagedivisor)
                    rcsvalidpages = rcsvalidpages + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNumRCS(ByVal einventorylocationid As Integer)
        Try
            rcscountpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = CType(getDataTableForSQL($"SELECT COALESCE(COUNT(rcs.rowid),0) FROM rackshelfcolumn rcs WHERE rcs.organizationid = {Z_OrganizationID} AND rcs.inventorylocationid = {einventorylocationid} "), DataTable)
            If dtCid.Rows.Count <> 0 Then
                rcscountpagenum = CInt(dtCid.Rows(0)(0))
            Else
                rcscountpagenum = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Display Functions"

#Region "AutoComplete"

    Sub autocompleteLocationType(ByVal icombobox As ComboBox)
        Try
            Dim locationtype As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(il.type,'') AS 'locationtype' FROM inventorylocations il WHERE il.organizationid = " & Z_OrganizationID & " GROUP BY il.type ORDER BY il.type ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                locationtype.Add(ds.Tables(0).Rows(i)("locationtype").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = locationtype
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteRack(ByVal icombobox As ComboBox)
        Try
            Dim rackno As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(rsc.rackno,'') AS 'rackno' FROM rackshelfcolumn rsc WHERE rsc.organizationid = " & Z_OrganizationID & " GROUP BY rsc.rackno ORDER BY rsc.rackno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                rackno.Add(ds.Tables(0).Rows(i)("rackno").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = rackno
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteShelf(ByVal icombobox As ComboBox)
        Try
            Dim shelfno As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(rsc.shelfno,'') AS 'shelfno' FROM rackshelfcolumn rsc WHERE rsc.organizationid = " & Z_OrganizationID & " GROUP BY rsc.shelfno ORDER BY rsc.shelfno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                shelfno.Add(ds.Tables(0).Rows(i)("shelfno").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = shelfno
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteColumn(ByVal icombobox As ComboBox)
        Try
            Dim columnno As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(rsc.columnno,'') AS 'columnno' FROM rackshelfcolumn rsc WHERE rsc.organizationid = " & Z_OrganizationID & " GROUP BY rsc.columnno ORDER BY rsc.columnno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                columnno.Add(ds.Tables(0).Rows(i)("columnno").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = columnno
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
            cboSearch1.Items.Clear()
            cboSearch3.Items.Clear()
            cboSearch1.Items.Add("Column")
            cboSearch1.Items.Add("LocationType")
            cboSearch1.Items.Add("Rack")
            cboSearch1.Items.Add("Shelf")
            cboSearch3.Items.Add("Column")
            cboSearch3.Items.Add("LocationType")
            cboSearch3.Items.Add("Rack")
            cboSearch3.Items.Add("Shelf")
            cboSearch1.Items.Add("")
            cboSearch3.Items.Add("")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autopopulateLocationTypeA(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(il.type,'') AS 'locationtype' FROM inventorylocations il WHERE il.organizationid = " & Z_OrganizationID & " GROUP BY il.type ORDER BY il.type "
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

    Sub autopopulateLocationTypeB(ByVal icombobox As ComboBox)
        If IsThurston Then
            Dim inventoryLocationTypes = [Enum].GetValues(GetType(InventoryLocationType))
            icombobox.Items.Clear()
            For Each item In inventoryLocationTypes
                icombobox.Items.Add(item)
            Next
            Return
        End If

        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(lic,'') FROM listofvalues WHERE type = 'Location Type' GROUP BY lic ORDER BY lic "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                icombobox.Items.Add(reader1(0).ToString())
            End While
            reader1.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autopopulateRack(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(rsc.rackno,'') AS 'rackno' FROM rackshelfcolumn rsc WHERE rsc.organizationid = " & Z_OrganizationID & " GROUP BY rsc.rackno ORDER BY rsc.rackno "
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

    Sub autopopulateShelf(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(rsc.shelfno,'') AS 'shelfno' FROM rackshelfcolumn rsc WHERE rsc.organizationid = " & Z_OrganizationID & " GROUP BY rsc.shelfno ORDER BY rsc.shelfno "
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

    Sub autopopulateColumn(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(rsc.columnno,'') AS 'columnno' FROM rackshelfcolumn rsc WHERE rsc.organizationid = " & Z_OrganizationID & " GROUP BY rsc.columnno ORDER BY rsc.columnno "
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

    Sub displayInventoryLocationList(ByVal istartpage As Integer)
        Try
            dgInventoryLocationList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT il.rowid,COALESCE(il.name,''),COALESCE(il.type,''),COALESCE(il.mainphone,'') FROM inventorylocations il " &
                        "WHERE il.organizationid = " & Z_OrganizationID & " ORDER BY il.name,il.type LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer
            If istartpage = neutralpage Then
                seqno = 1
            Else
                seqno = istartpage + 1
            End If
            While reader1.Read()
                If reader1.HasRows Then
                    dgInventoryLocationList.Rows.Add()
                    dgInventoryLocationList.Item(il_rowid.Index, n).Value = reader1(0)
                    dgInventoryLocationList.Item(il_seqno.Index, n).Value = seqno
                    dgInventoryLocationList.Item(il_locationname.Index, n).Value = reader1(1)
                    dgInventoryLocationList.Item(il_locationtype.Index, n).Value = reader1(2)
                    dgInventoryLocationList.Item(il_mainphone.Index, n).Value = reader1(3)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgInventoryLocationList.Columns("il_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocationList.Columns("il_locationname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocationList.Columns("il_locationtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocationList.Columns("il_mainphone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgInventoryLocationList.Rows.Count <> 0 Then
                dgInventoryLocationList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgInventoryLocationList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT il.rowid,COALESCE(il.name,''),COALESCE(il.type,''),COALESCE(il.mainphone,'') FROM inventorylocations il LEFT JOIN rackshelfcolumn rsc ON il.rowid = rsc. inventorylocationid " &
                        "WHERE il.organizationid = " & Z_OrganizationID & " AND (il.name LIKE ""%" & isearchphrase & "%"" OR il.type LIKE ""%" & isearchphrase & "%"" OR rsc.rackno " &
                        "LIKE ""%" & isearchphrase & "%"" OR rsc.shelfno LIKE ""%" & isearchphrase & "%"" OR rsc.columnno LIKE ""%" & isearchphrase & "%"") ORDER BY il.name,il.type LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer
            If istartpage = neutralpage Then
                seqno = 1
            Else
                seqno = istartpage + 1
            End If
            While reader1.Read()
                If reader1.HasRows Then
                    dgInventoryLocationList.Rows.Add()
                    dgInventoryLocationList.Item(il_rowid.Index, n).Value = reader1(0)
                    dgInventoryLocationList.Item(il_seqno.Index, n).Value = seqno
                    dgInventoryLocationList.Item(il_locationname.Index, n).Value = reader1(1)
                    dgInventoryLocationList.Item(il_locationtype.Index, n).Value = reader1(2)
                    dgInventoryLocationList.Item(il_mainphone.Index, n).Value = reader1(3)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgInventoryLocationList.Columns("il_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocationList.Columns("il_locationname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocationList.Columns("il_locationtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocationList.Columns("il_mainphone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgInventoryLocationList.Rows.Count <> 0 Then
                dgInventoryLocationList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCommonPhrase(ByVal icommonphrase As String, ByVal istartpage As Integer)
        Try
            dgInventoryLocationList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT il.rowid,COALESCE(il.name,''),COALESCE(il.type,''),COALESCE(il.mainphone,'') FROM inventorylocations il LEFT JOIN rackshelfcolumn rsc ON il.rowid = rsc.inventorylocationid " &
                        "WHERE il.organizationid = " & Z_OrganizationID & " AND " & icommonphrase & " ORDER BY il.name,il.type LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer
            If istartpage = neutralpage Then
                seqno = 1
            Else
                seqno = istartpage + 1
            End If
            While reader1.Read()
                If reader1.HasRows Then
                    dgInventoryLocationList.Rows.Add()
                    dgInventoryLocationList.Item(il_rowid.Index, n).Value = reader1(0)
                    dgInventoryLocationList.Item(il_seqno.Index, n).Value = seqno
                    dgInventoryLocationList.Item(il_locationname.Index, n).Value = reader1(1)
                    dgInventoryLocationList.Item(il_locationtype.Index, n).Value = reader1(2)
                    dgInventoryLocationList.Item(il_mainphone.Index, n).Value = reader1(3)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgInventoryLocationList.Columns("il_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocationList.Columns("il_locationname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocationList.Columns("il_locationtype").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventoryLocationList.Columns("il_mainphone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgInventoryLocationList.Rows.Count <> 0 Then
                dgInventoryLocationList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayInventoryLocationInformation(ByVal iinventorylocationid As Integer)
        Try
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(il.name,''),COALESCE(il.type,''),COALESCE(il.mainphone,''),COALESCE(il.mobilephone,''),COALESCE(il.faxnumber,''),COALESCE(il.comments,''),COALESCE(il.addressid,0)," &
                        "COALESCE(CONCAT(COALESCE(ad.streetaddress1,''),' ',COALESCE(ad.streetaddress2,''),' ',COALESCE(ad.barangay,''),' ',COALESCE(ad.citytown,''),' ',COALESCE(ad.province,''),' ',COALESCE(ad.state,''),' ',COALESCE(ad.zipcode,''),' ',COALESCE(ad.country,'')),'') " &
                        "FROM inventorylocations il LEFT JOIN address ad ON il.addressid = ad.rowid WHERE il.rowid = " & iinventorylocationid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtLocationName.Text = CStr(If(reader1(0) Is Nothing, String.Empty, reader1(0)))
                    cboLocationType.Text = CStr(If(reader1(1) Is Nothing, String.Empty, reader1(1)))
                    txtMainPhone.Text = CStr(If(reader1(2) Is Nothing, String.Empty, reader1(2)))
                    txtAddress.Text = CStr(If(reader1(7) Is Nothing, String.Empty, reader1(7)))
                    txtAlternatePhone.Text = CStr(If(reader1(3) Is Nothing, String.Empty, reader1(3)))
                    txtFaxNo.Text = CStr(If(reader1(4) Is Nothing, String.Empty, reader1(4)))
                    txtComments.Text = CStr(If(reader1(5) Is Nothing, String.Empty, reader1(5)))
                    iladdressid = CInt(If(reader1(6) Is Nothing, New Integer(), reader1(6)))
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayRackShelfColumn(ByVal iinventorylocationid As Integer, ByVal istartpage As Integer)
        Try
            dgRackShelfColumn.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            'Dim sql1 As String = "SELECT rsc.rowid,COALESCE(rsc.rackno,''),COALESCE(rsc.shelfno,''),COALESCE(rsc.columnno,''),COALESCE(rsc.pickorderno,0),COALESCE(rsc.remarks,'') FROM rackshelfcolumn rsc " &
            '            "WHERE rsc.organizationid = " & Z_OrganizationID & " AND rsc.inventorylocationid = " & iinventorylocationid & " ORDER BY rsc.pickorderno ASC LIMIT " & istartpage & "," & pagedivisor & " "

            Dim sql1 As String = $"SELECT
	            rsc.rowid,
	            COALESCE(rsc.rackno, ''),
	            COALESCE(rsc.shelfno, ''),
	            COALESCE(rsc.columnno, ''),
	            COALESCE(rsc.pickorderno, 0),
	            COALESCE(rsc.remarks, '')
            FROM
	            rackshelfcolumn rsc
            LEFT JOIN productinventorylocation pil ON pil.RackShelfColumnID=rsc.RowID
            WHERE
	            rsc.organizationid = {Z_OrganizationID}
	            AND rsc.inventorylocationid = {iinventorylocationid}
            GROUP BY
	            rsc.RowID
            ORDER BY
	            SUM(IFNULL(pil.TotalAvailableQty, 0)) > 0 DESC, rsc.pickorderno ASC LIMIT {istartpage},{pagedivisor};"

            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer
            If istartpage = neutralpage Then
                seqno = 1
            Else
                seqno = istartpage + 1
            End If
            While reader1.Read()
                If reader1.HasRows Then
                    dgRackShelfColumn.Rows.Add()
                    dgRackShelfColumn.Item(rsc_rowid.Index, n).Value = reader1(0)
                    dgRackShelfColumn.Item(rsc_seqno.Index, n).Value = seqno
                    dgRackShelfColumn.Item(rsc_rack.Index, n).Value = reader1(1)
                    dgRackShelfColumn.Item(rsc_shelf.Index, n).Value = reader1(2)
                    dgRackShelfColumn.Item(rsc_column.Index, n).Value = reader1(3)
                    dgRackShelfColumn.Item(rsc_pickorderno.Index, n).Value = reader1(4)
                    dgRackShelfColumn.Item(rsc_remarks.Index, n).Value = reader1(5)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgRackShelfColumn.Columns("rsc_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_rack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_shelf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_pickorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_column").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgRackShelfColumn.Rows.Count <> 0 Then
                dgRackShelfColumn.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayProducts(ByVal irackshelfcolumnid As Integer)
        Try
            dgProducts.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pil.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),IFNULL(pil.UnitOfMeasure, ''),COALESCE(pil.totalavailableqty,0),COALESCE(pil.totalreserveqty,0),COALESCE(pil.totaldamageqty,0),COALESCE(pcs.sku,''),COALESCE(pcs.sku2,''),COALESCE(pcs.seasoncode,'')," &
                        "COALESCE(pil.totalallocatedqty,0) FROM productinventorylocation pil LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid " &
                        "LEFT JOIN products p ON pc.productid = p.rowid WHERE pil.organizationid = " & Z_OrganizationID & " AND pil.rackshelfcolumnid = " & irackshelfcolumnid & " ORDER BY p.productcode ASC,c.colorname ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgProducts.Rows.Add()
                    dgProducts.Item(p_seqno.Index, n).Value = seqno
                    dgProducts.Item(p_rowid.Index, n).Value = reader1(0)
                    dgProducts.Item(p_colorvalue.Index, n).Value = reader1(1)
                    dgProducts.Item(p_productcode.Index, n).Value = reader1(2)
                    dgProducts.Item(p_colorname.Index, n).Value = reader1(3)
                    dgProducts.Item(p_size.Index, n).Value = reader1(4)
                    dgProducts.Item(p_unitOfMeasure.Index, n).Value = reader1(5)
                    dgProducts.Item(p_qtyavailable.Index, n).Value = reader1(6)
                    dgProducts.Item(p_qtyreserve.Index, n).Value = reader1(7)
                    dgProducts.Item(p_qtydamage.Index, n).Value = reader1(8)
                    dgProducts.Item(p_sku.Index, n).Value = reader1(9)
                    dgProducts.Item(p_sku2.Index, n).Value = reader1(10)
                    dgProducts.Item(p_seasoncode.Index, n).Value = reader1(11)
                    dgProducts.Item(p_qtyallocated.Index, n).Value = reader1(12)
                    dgProducts.Item(p_qtyorderable.Index, n).Value = CInt(reader1(7)) - CInt(reader1(12))
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgProducts.Columns("p_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_qtyavailable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_qtyallocated").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_qtyorderable").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_qtyreserve").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_qtydamage").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgProducts.Columns("p_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgProducts.Rows.Count <> 0 Then
                dgProducts.CurrentRow.Selected = False
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
            If dgProducts.Rows.Count <> 0 Then
                For i As Integer = 0 To dgProducts.Rows.Count - 1
                    If CStr(dgProducts.Rows(i).Cells("p_colorvalue").Value) <> "" Then
                        readcolor = CType(colorconverter.ConvertFromString(CStr(dgProducts.Rows(i).Cells("p_colorvalue").Value)), Drawing.Color)
                        dgProducts.Rows(i).Cells("p_color").Style.BackColor = readcolor
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

#Region "Saving Functions"

    Sub addRackShelfColumnRow()
        Try
            dgRackShelfColumn.Rows.Add()
            dgRackShelfColumn.Rows(dgRackShelfColumn.Rows.Count - 1).Cells("rsc_rowid").Value = ""
            dgRackShelfColumn.Rows(dgRackShelfColumn.Rows.Count - 1).Cells("rsc_rack").Value = cboRack.Text
            dgRackShelfColumn.Rows(dgRackShelfColumn.Rows.Count - 1).Cells("rsc_shelf").Value = cboShelf.Text
            dgRackShelfColumn.Rows(dgRackShelfColumn.Rows.Count - 1).Cells("rsc_column").Value = cboColumn.Text
            dgRackShelfColumn.Rows(dgRackShelfColumn.Rows.Count - 1).Cells("rsc_pickorderno").Value = If(IsNumeric(txtPickOrderNo.Text), CInt(txtPickOrderNo.Text), 0)
            dgRackShelfColumn.Rows(dgRackShelfColumn.Rows.Count - 1).Cells("rsc_remarks").Value = txtRemarks.Text
            dgRackShelfColumn.Columns("rsc_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_rack").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_shelf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_column").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgRackShelfColumn.Columns("rsc_pickorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
                PrimaryForm.ILForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtComments_Leave(sender As Object, e As EventArgs) Handles txtComments.Leave
        Try
            txtLocationName.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnAddRSC_Leave(sender As Object, e As EventArgs) Handles btnAddRSC.Leave
        Try
            cboRack.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbEditAddress_MouseEnter(sender As Object, e As EventArgs) Handles pbEditAddress.MouseEnter
        Try
            pbEditAddress.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbEditAddress_MouseLeave(sender As Object, e As EventArgs) Handles pbEditAddress.MouseLeave
        Try
            pbEditAddress.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Sub pbEditAddress_Click(sender As Object, e As EventArgs) Handles pbEditAddress.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Inventory Locations", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.ILForm = False
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
            If cue = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            Dim addresslinkform As New AddressForm
            addresslinkform.afaddressid = iladdressid
            addresslinkform.ShowInTaskbar = False
            addresslinkform.ShowDialog()
            iladdressid = addresslinkform.afaddressid
            If iladdressid <> 0 Then
                getAddressName(iladdressid, Me)
                txtAddress.Text = globaladdressname
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbAutoAddRack_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddRack.MouseEnter
        Try
            pbAutoAddRack.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddRack_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddRack.MouseLeave
        Try
            pbAutoAddRack.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddRack_Click(sender As Object, e As EventArgs) Handles pbAutoAddRack.Click
        Try
            myBalloon("Automatic adding of rack.", "Auto-Add", pbAutoAddRack, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddColumn_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddColumn.MouseEnter
        Try
            pbAutoAddColumn.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddColumn_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddColumn.MouseLeave
        Try
            pbAutoAddColumn.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddColumn_Click(sender As Object, e As EventArgs) Handles pbAutoAddColumn.Click
        Try
            myBalloon("Automatic adding of column.", "Auto-Add", pbAutoAddColumn, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddShelf_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddShelf.MouseEnter
        Try
            pbAutoAddShelf.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddShelf_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddShelf.MouseLeave
        Try
            pbAutoAddShelf.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddShelf_Click(sender As Object, e As EventArgs) Handles pbAutoAddShelf.Click
        Try
            myBalloon("Automatic adding of shelf.", "Auto-Add", pbAutoAddShelf, -15, -65)
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
                getPositionView(globalpositionid, "Inventory Locations", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.ILForm = False
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
            clearInventoryLocationInformation()
            cleargbAddRSC()
            clearDataGrids()
            visibleProducts(fraud)
            enableGB(fraud, legit, fraud, fraud)
            enableANDvisibleMS(fraud, legit, legit)
            If dgInventoryLocationList.Rows.Count <> 0 Then
                dgInventoryLocationList.CurrentRow.Selected = False
            End If
            iladdressid = 0
            txtLocationName.Focus()
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
            If dgInventoryLocationList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearInventoryLocationInformation()
                cleargbAddRSC()
                clearDataGrids()
                visibleProducts(fraud)
                enableGB(legit, legit, legit, legit)
                enableANDvisibleMS(legit, legit, fraud)
                dgInventoryLocationList.CurrentRow.Selected = True
                displayInventoryLocationInformation(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value))
                rcspagenum = neutralpage : rcsnumofpages = startingpage
                displayRackShelfColumn(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), rcspagenum)
                pageSetupRCS(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value))
                txtPageNoRCS.Text = "" & rcsnumofpages & " of " & rcsvalidpages & " " : txtLocationName.Focus()
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

    Private Sub dgInventoryLocationList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgInventoryLocationList.CellContentClick

    End Sub

    Private Async Sub dgInventoryLocationList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgInventoryLocationList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgInventoryLocationList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearInventoryLocationInformation()
                cleargbAddRSC()
                clearDataGrids()
                visibleProducts(fraud)
                enableGB(legit, legit, legit, legit)
                enableANDvisibleMS(legit, legit, fraud)
                displayInventoryLocationInformation(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value))
                rcspagenum = neutralpage : rcsnumofpages = startingpage
                displayRackShelfColumn(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), rcspagenum)
                LoadProductColorSizesBasedOnRackShelfColumn()
                pageSetupRCS(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value))
                txtPageNoRCS.Text = "" & rcsnumofpages & " of " & rcsvalidpages & " " : txtLocationName.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default

        If IsThurston Then
            Await LoadProductColorSizesOfInventoryLocationAsync()

            Dim inventoryLocationId = GetCurrentInventoryLocationId()
            LinkLabel1.Enabled = Not inventoryLocationId = 0
            Return
        End If

    End Sub

    Private Async Function LoadProductColorSizesOfInventoryLocationAsync() As Task
        Dim productInventoryLocationDataService = GetRequiredService(Of IProductInventoryLocationDataService)()
        Dim inventoryLocationId = GetCurrentInventoryLocationId()
        Dim productInventoryLocations = Await productInventoryLocationDataService.GetByInventoryLocationIdAsync(inventoryLocationId:=inventoryLocationId)

        Dim productColorSizeRepository = GetRequiredService(Of IProductColorSizeRepository)()
        Dim productColorSizes = Await productColorSizeRepository.GetManyByOrganizationIdsAsync(Z_OrganizationID)
        Dim dataSource = productColorSizes.
            Select(Function(t)
                       Dim productInventoryLocationItems = productInventoryLocations.
                        Where(Function(i) i.ProductColorSizeID = t.RowID.Value).
                        ToList()
                       Return New ProductColorSizeModel(inventoryLocationId:=inventoryLocationId,
                            productInventoryLocations:=productInventoryLocationItems,
                            productColorSize:=t,
                            _picp)
                   End Function).
            OrderBy(Function(t) t.ProductCode).
            ToList()

        _ProductColorSizeModels = dataSource

        gridProductColorSizes.DataSource = dataSource
    End Function

    Private Sub LoadProductColorSizesBasedOnRackShelfColumn()
        If Not IsThurston Then Return

        Dim row = dgRackShelfColumn.Rows.OfType(Of DataGridViewRow).FirstOrDefault()

        If row Is Nothing Then Return
        displayProducts(irackshelfcolumnid:=CInt(row.Cells(rsc_rowid.Name).Value))
    End Sub

    Private Sub dgInventoryLocationList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgInventoryLocationList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgInventoryLocationList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearInventoryLocationInformation()
                    cleargbAddRSC()
                    clearDataGrids()
                    visibleProducts(fraud)
                    enableGB(legit, legit, legit, legit)
                    enableANDvisibleMS(legit, legit, fraud)
                    displayInventoryLocationInformation(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value))
                    rcspagenum = neutralpage : rcsnumofpages = startingpage
                    displayRackShelfColumn(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), rcspagenum)
                    pageSetupRCS(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value))
                    txtPageNoRCS.Text = "" & rcsnumofpages & " of " & rcsvalidpages & " " : txtLocationName.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdFirstRCS_Click(sender As Object, e As EventArgs) Handles cmdFirstRCS.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If cue = "Edit" Then
                If dgInventoryLocationList.Rows.Count <> 0 Then
                    rcspagenum = neutralpage : rcsnumofpages = startingpage
                    dgProducts.Rows.Clear() : txtTotalQtyAvailable.Text = "" : txtTotalQtyAllocated.Text = "" : txtTotalQtyOrderable.Text = ""
                    displayRackShelfColumn(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), rcspagenum)
                    txtPageNoRCS.Text = "" & rcsnumofpages & " of " & rcsvalidpages & " "
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdPrevRCS_Click(sender As Object, e As EventArgs) Handles cmdPrevRCS.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If cue = "Edit" Then
                If dgInventoryLocationList.Rows.Count <> 0 Then
                    rcspagenum = rcspagenum - pagedivisor
                    rcsnumofpages = rcsnumofpages - 1
                    If rcspagenum < 0 Then
                        If countpagenum < pagedivisor Then
                            rcspagenum = neutralpage
                        Else
                            rcspagenum = countpagenum - pagedivisor
                        End If
                        rcsnumofpages = rcsvalidpages
                    End If
                    dgProducts.Rows.Clear() : txtTotalQtyAvailable.Text = "" : txtTotalQtyAllocated.Text = "" : txtTotalQtyOrderable.Text = ""
                    displayRackShelfColumn(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), rcspagenum)
                    txtPageNoRCS.Text = "" & rcsnumofpages & " of " & rcsvalidpages & " "
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdNextRCS_Click(sender As Object, e As EventArgs) Handles cmdNextRCS.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If cue = "Edit" Then
                If dgInventoryLocationList.Rows.Count <> 0 Then
                    rcspagenum = rcspagenum + pagedivisor
                    rcsnumofpages = rcsnumofpages + 1
                    If rcsnumofpages > rcsvalidpages Then
                        rcspagenum = neutralpage
                        rcsnumofpages = startingpage
                    End If
                    dgProducts.Rows.Clear() : txtTotalQtyAvailable.Text = "" : txtTotalQtyAllocated.Text = "" : txtTotalQtyOrderable.Text = ""
                    displayRackShelfColumn(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), rcspagenum)
                    txtPageNoRCS.Text = "" & rcsnumofpages & " of " & rcsvalidpages & " "
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdLastRCS_Click(sender As Object, e As EventArgs) Handles cmdLastRCS.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If cue = "Edit" Then
                If dgInventoryLocationList.Rows.Count <> 0 Then
                    If rcscountpagenum < pagedivisor Then
                        rcspagenum = neutralpage
                    Else
                        rcspagenum = rcscountpagenum - pagedivisor
                    End If
                    rcsnumofpages = rcsvalidpages
                    dgProducts.Rows.Clear() : txtTotalQtyAvailable.Text = "" : txtTotalQtyAllocated.Text = "" : txtTotalQtyOrderable.Text = ""
                    displayRackShelfColumn(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), rcspagenum)
                    txtPageNoRCS.Text = "" & rcsnumofpages & " of " & rcsvalidpages & " "
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtLocationName_Leave(sender As Object, e As EventArgs) Handles txtLocationName.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cue = "New" Then
                getInventorylocationIDA(txtLocationName.Text, Me)
                ilinventorylocationid = globalinventorylocationid
                If ilinventorylocationid <> 0 Then
                    errProvider.SetError(txtLocationName, "Location name has been created already, please type a new one.")
                End If
            ElseIf cue = "Edit" Then
                If dgInventoryLocationList.Rows.Count <> 0 Then
                    getInventorylocationIDB(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), txtLocationName.Text, Me)
                    ilinventorylocationid = globalinventorylocationid
                    If ilinventorylocationid <> 0 Then
                        errProvider.SetError(txtLocationName, "Location name has been created already, please type a new one.")
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

    'Private Sub txtLocationName_TextChanged(sender As Object, e As EventArgs) Handles txtLocationName.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cue = "New" Then
    '            getInventorylocationIDA(txtLocationName.Text, Me)
    '            ilinventorylocationid = globalinventorylocationid
    '            If ilinventorylocationid <> 0 Then
    '                errProvider.SetError(txtLocationName, "Location name has been created already, please type a new one.")
    '            End If
    '        ElseIf cue = "Edit" Then
    '            If dgInventoryLocationList.Rows.Count <> 0 Then
    '                getInventorylocationIDB(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), txtLocationName.Text, Me)
    '                ilinventorylocationid = globalinventorylocationid
    '                If ilinventorylocationid <> 0 Then
    '                    errProvider.SetError(txtLocationName, "Location name has been created already, please type a new one.")
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
    Private Sub cboLocationType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLocationType.SelectedIndexChanged
        Try
            If cboLocationType.Text <> "" Then
                If cue = "New" Then
                    If cboLocationType.Text = "Main" Then
                        enableGB(fraud, legit, legit, fraud)
                    Else
                        enableGB(fraud, legit, fraud, fraud)
                    End If
                ElseIf cue = "Edit" Then
                    If cboLocationType.Text = "Main" Then
                        enableGB(legit, legit, legit, legit)
                    Else
                        enableGB(legit, legit, fraud, fraud)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnAddRSC_Click(sender As Object, e As EventArgs) Handles btnAddRSC.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            btnAddRSCperformclick()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboShelf_KeyDown(sender As Object, e As KeyEventArgs) Handles cboShelf.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                btnAddRSCperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtPickOrderNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPickOrderNo.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                btnAddRSCperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                btnAddRSCperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboRack_TextChanged(sender As Object, e As EventArgs) Handles cboRack.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub cboShelf_TextChanged(sender As Object, e As EventArgs) Handles cboShelf.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProducts.CellContentClick

    End Sub

    Private Async Sub dgProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgProducts.SelectionChanged
        Dim productInventoryLocationId = CInt(If(dgProducts.CurrentRow?.Cells(p_rowid.Name).Value, 0))
        If productInventoryLocationId = 0 Then
            txtTotalQtyAvailable.Text = "0"
            txtTotalQtyAllocated.Text = "0"
            txtTotalQtyOrderable.Text = "0"

            Return
        End If

        Dim productInventoryLocationDataService = GetRequiredService(Of IProductInventoryLocationDataService)()

        Dim productInventoryLocation = Await productInventoryLocationDataService.GetByIdAsync(productInventoryLocationId)

        txtTotalQtyAvailable.Text = $"{If(productInventoryLocation.TotalAvailableQty, 0)}"
        txtTotalQtyAllocated.Text = $"{If(productInventoryLocation.TotalAllocatedQty, 0)}"
        txtTotalQtyOrderable.Text = $"{productInventoryLocation.TotalOrderableQty}"
    End Sub

    Private Sub gridProductColorSizes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridProductColorSizes.CellContentClick

    End Sub

    Private Sub gridProductColorSizes_SelectionChanged(sender As Object, e As EventArgs) Handles gridProductColorSizes.SelectionChanged
        If gridProductColorSizes.CurrentRow Is Nothing Then

            Return
        End If

        Dim model = CType(gridProductColorSizes.CurrentRow.DataBoundItem, ProductColorSizeModel)
        Dim productColorSizeId = GetCurrentProductColorSizeId()
        Dim inventoryLocationId = GetCurrentInventoryLocationId()

        Dim dataSource = model.ProductInventoryLocations.
            BestFetchClause(inventoryLocationId:=inventoryLocationId, productColorSizeId:=productColorSizeId, ignoreOrderableQty:=True).
            Select(Function(t) New RackShelfColumnSimpleModel(productColorSizeId:=productColorSizeId, t.RackShelfColumn)).
            OrderByDescending(Function(t) t.HasAvailableQty).
            ThenBy(Function(t) t.PickOrderNo).
            ToList()

        gridRackShelfColumns.DataSource = dataSource

        LinkLabel1.Enabled = Not GetCurrentInventoryLocationId() = 0 AndAlso Not productColorSizeId = 0
    End Sub

    Private Async Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim inventoryLocationId = GetCurrentInventoryLocationId()

        Dim productColorSizeId = GetCurrentProductColorSizeId()

        If inventoryLocationId = 0 Then
            MessageBox.Show(text:="No inventory location selected.",
                caption:="Invalid Inventory Location",
                icon:=MessageBoxIcon.Error,
                buttons:=MessageBoxButtons.OK)
            Return
        End If

        If productColorSizeId = 0 Then
            MessageBox.Show(text:="No product selected.",
                caption:="Invalid Product",
                icon:=MessageBoxIcon.Error,
                buttons:=MessageBoxButtons.OK)
            Return
        End If

        Dim rackShelfColumnDataService = GetRequiredService(Of IRackShelfColumnDataService)()

        Dim rackShelfColumn = Await rackShelfColumnDataService.GenerateNew(organizationId:=Z_OrganizationID,
            userId:=Z_UserID,
            inventoryLocationId:=inventoryLocationId)

        Dim currentRowIndex = If(gridProductColorSizes.CurrentRow?.Index, 0)

        Dim form As New RackShelfColumnFormDialog(productColorSizeId:=productColorSizeId,
            rackShelfColumn:=rackShelfColumn)
        If Not form.IsValid AndAlso Not form.ShowDialog() = DialogResult.OK Then Return

        Await FunctionUtils.TryCatchFunctionAsync("Create Rack-Shelf-Column and incorporate to Product Inventory Location",
            Async Function()
                Dim model = CType(gridProductColorSizes.CurrentRow.DataBoundItem, ProductColorSizeModel)

                Dim newProductInventoryLocation = ProductInventoryLocation.NewProductInventoryLocation(
                    organizationId:=Z_OrganizationID,
                    userId:=Z_UserID,
                    productColorSizeId:=productColorSizeId,
                    unitOfMeasure:=model.ProductInventoryLocation.UnitOfMeasure,
                    unitPrice:=model.ProductInventoryLocation.UnitPrice,
                    unitOfMeasure2:=model.UnitOfMeasure2,
                    unitPriceOfUOM2:=model.UnitPriceOfUOM2)

                Dim newRackShelfColumn = form.ProcessedRackShelfColumn

                newRackShelfColumn.AddProductInventoryLocations(New List(Of ProductInventoryLocation) From {newProductInventoryLocation})

                Await rackShelfColumnDataService.SaveManyAsync(userId:=Z_UserID,
                    added:=New List(Of RackShelfColumn) From {newRackShelfColumn})

                Await LoadProductColorSizesOfInventoryLocationAsync()
            End Function).
                ContinueWith(
                continuationAction:=Sub()
                                        With gridProductColorSizes
                                            If .Rows.Count() < currentRowIndex Then Return

                                            .ClearSelection()
                                            .CurrentCell = .Item(DataGridViewTextBoxColumn1.Name, currentRowIndex)
                                            .Refresh()
                                        End With

                                        gridProductColorSizes_SelectionChanged(gridProductColorSizes, New EventArgs())
                                    End Sub,
                scheduler:=TaskScheduler.FromCurrentSynchronizationContext())

    End Sub

    Private Function GetCurrentInventoryLocationId() As Integer
        Return CInt(If(dgInventoryLocationList.CurrentRow?.Cells(il_rowid.Name).Value, 0))
    End Function

    Private Function GetCurrentProductColorSizeId() As Integer
        Dim model = CType(gridProductColorSizes.CurrentRow?.DataBoundItem, ProductColorSizeModel)
        Return If(model?.ProductColorSizeId, 0)
    End Function

    Private Async Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim inventoryLocationId = GetCurrentInventoryLocationId()
        Dim productColorSizeId = GetCurrentProductColorSizeId()

        If inventoryLocationId = 0 Then
            MessageBox.Show(text:="No inventory location selected.",
                caption:="Invalid Inventory Location",
                icon:=MessageBoxIcon.Error,
                buttons:=MessageBoxButtons.OK)
            Return
        End If

        If productColorSizeId = 0 Then
            MessageBox.Show(text:="No product selected.",
                caption:="Invalid Product",
                icon:=MessageBoxIcon.Error,
                buttons:=MessageBoxButtons.OK)
            Return
        End If

        Dim models = gridRackShelfColumns.Rows.OfType(Of DataGridViewRow)?.
            Select(Function(t) CType(t.DataBoundItem, RackShelfColumnSimpleModel)).
            ToList()

        Dim currentRowIndex = If(gridProductColorSizes.CurrentRow?.Index, 0)

        Dim form As New RackShelfColumnForm(inventoryLocationId:=inventoryLocationId,
            productColorSizeId:=productColorSizeId,
            rackShelfColumnIds:=models.Select(Function(t) t.RowID).ToArray())
        If Not form.ShowDialog() = DialogResult.OK Then Return

        Await FunctionUtils.TryCatchFunctionAsync("Select from existing Rack-Shelf-Column and incorporate to Product Inventory Location",
            Async Function()
                Dim model = CType(gridProductColorSizes.CurrentRow.DataBoundItem, ProductColorSizeModel)

                Dim newProductInventoryLocation = ProductInventoryLocation.NewProductInventoryLocation(
                    organizationId:=Z_OrganizationID,
                    userId:=Z_UserID,
                    productColorSizeId:=productColorSizeId,
                    unitOfMeasure:=StringExtensions.IfNullOrEmpty(model?.ProductInventoryLocation?.UnitOfMeasure, model.ProductColorSize.UnitOfMeasure2),
                    unitPrice:=If(model?.ProductInventoryLocation?.UnitPrice, model.ProductColorSize.UnitPriceOfUOM2),
                    unitOfMeasure2:=model.UnitOfMeasure2,
                    unitPriceOfUOM2:=model.UnitPriceOfUOM2)

                Dim newRackShelfColumn = form.ProcessedRackShelfColumn

                newRackShelfColumn.AddProductInventoryLocations(New List(Of ProductInventoryLocation) From {newProductInventoryLocation})

                Dim rackShelfColumnDataService = GetRequiredService(Of IRackShelfColumnDataService)()
                Await rackShelfColumnDataService.SaveManyAsync(userId:=Z_UserID,
                    updated:=New List(Of RackShelfColumn) From {newRackShelfColumn})

                Await LoadProductColorSizesOfInventoryLocationAsync()
            End Function).
                ContinueWith(
                continuationAction:=Sub()
                                        With gridProductColorSizes
                                            If .Rows.Count() < currentRowIndex Then Return

                                            .ClearSelection()
                                            .CurrentCell = .Item(DataGridViewTextBoxColumn1.Name, currentRowIndex)
                                            .Refresh()
                                        End With

                                        gridProductColorSizes_SelectionChanged(gridProductColorSizes, New EventArgs())
                                    End Sub,
                scheduler:=TaskScheduler.FromCurrentSynchronizationContext())
    End Sub

    Private Sub gridRackShelfColumns_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridRackShelfColumns.CellContentClick

    End Sub

    Private Async Sub gridRackShelfColumns_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridRackShelfColumns.CellDoubleClick

    End Sub

    Private Async Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Trim().Length = 0 Then
            Await LoadProductColorSizesOfInventoryLocationAsync()
            Return
        End If

        If _ProductColorSizeModels Is Nothing Then Return

        Dim searchedDataSource = _ProductColorSizeModels.
            Where(Function(t) t.AdvanceSearch(searchText:=txtSearch.Text)).
            ToList()
        gridProductColorSizes.DataSource = searchedDataSource
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSearch_TextChanged(txtSearch, New EventArgs())
        End If
    End Sub

    Private Sub cboColumn_TextChanged(sender As Object, e As EventArgs) Handles cboColumn.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgRackShelfColumn_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgRackShelfColumn.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgRackShelfColumn.Rows.Count <> 0 Then
                If cue = "Edit" Then
                    If IsNumeric(dgRackShelfColumn.CurrentRow.Cells("rsc_rowid").Value) Then
                        If CInt(dgRackShelfColumn.CurrentRow.Cells("rsc_rowid").Value) <> 0 Then
                            displayProducts(CInt(dgRackShelfColumn.CurrentRow.Cells("rsc_rowid").Value))
                            colorCoding() : totalcomputation()
                        Else
                            dgProducts.Rows.Clear()
                            txtTotalQtyAvailable.Text = ""
                            txtTotalQtyAllocated.Text = ""
                            txtTotalQtyOrderable.Text = ""
                        End If
                    Else
                        dgProducts.Rows.Clear()
                        txtTotalQtyAvailable.Text = ""
                        txtTotalQtyAllocated.Text = ""
                        txtTotalQtyOrderable.Text = ""
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

    Private Sub dgRackShelfColumn_KeyUp(sender As Object, e As KeyEventArgs) Handles dgRackShelfColumn.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgRackShelfColumn.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    If cue = "Edit" Then
                        If IsNumeric(dgRackShelfColumn.CurrentRow.Cells("rsc_rowid").Value) Then
                            If CInt(dgRackShelfColumn.CurrentRow.Cells("rsc_rowid").Value) <> 0 Then
                                displayProducts(CInt(dgRackShelfColumn.CurrentRow.Cells("rsc_rowid").Value))
                                colorCoding() : totalcomputation()
                            Else
                                dgProducts.Rows.Clear()
                                txtTotalQtyAvailable.Text = ""
                                txtTotalQtyAllocated.Text = ""
                                txtTotalQtyOrderable.Text = ""
                            End If
                        Else
                            dgProducts.Rows.Clear()
                            txtTotalQtyAvailable.Text = ""
                            txtTotalQtyAllocated.Text = ""
                            txtTotalQtyOrderable.Text = ""
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

    Private Sub dgRackShelfColumn_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgRackShelfColumn.CellContentClick
        Try
            If dgRackShelfColumn.Rows.Count <> 0 Then
                If e.ColumnIndex = dgRackShelfColumn.Columns("rsc_option").Index Then
                    If IsNumeric(dgRackShelfColumn.CurrentRow.Cells("rsc_rowid").Value) Then
                        If CInt(dgRackShelfColumn.CurrentRow.Cells("rsc_rowid").Value) = 0 Then
                            cmsEdit.Visible = fraud
                            cmsDelete.Visible = legit
                        Else
                            cmsEdit.Visible = legit
                            cmsDelete.Visible = fraud
                        End If
                    Else
                        If CStr(dgRackShelfColumn.CurrentRow.Cells("rsc_rowid").Value) = "" Then
                            cmsEdit.Visible = fraud
                            cmsDelete.Visible = legit
                        End If
                    End If
                    cmsOptions.Show(Cursor.Position)
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub chkOtherInfo_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtherInfo.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If chkOtherInfo.Checked = legit Then
                visibleProducts(legit)
            Else
                visibleProducts(fraud)
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
            If dgRackShelfColumn.Rows.Count <> 0 Then
                If IsNumeric(dgRackShelfColumn.CurrentRow.Cells("rsc_rowid").Value) Then
                    If CInt(dgRackShelfColumn.CurrentRow.Cells("rsc_rowid").Value) = 0 Then
                        If dgRackShelfColumn.SelectedRows.Count > 0 Then
                            dgRackShelfColumn.Rows.Remove(dgRackShelfColumn.SelectedRows(0))
                        End If
                    End If
                Else
                    If CStr(dgRackShelfColumn.CurrentRow.Cells("rsc_rowid").Value) = "" Then
                        If dgRackShelfColumn.SelectedRows.Count > 0 Then
                            dgRackShelfColumn.Rows.Remove(dgRackShelfColumn.SelectedRows(0))
                        End If
                    End If
                End If
                For a As Integer = 0 To dgRackShelfColumn.Rows.Count - 1
                    If CInt(dgRackShelfColumn.Rows(a).Cells("rsc_seqno").Value) = neutralpage Then
                        itemno = startingpage
                    Else
                        itemno = CInt(dgRackShelfColumn.Rows(a).Cells("rsc_seqno").Value)
                    End If
                    Exit For
                Next
                For d As Integer = 0 To dgRackShelfColumn.Rows.Count - 1
                    dgRackShelfColumn.Rows(d).Cells("rsc_seqno").Value = itemno
                    itemno = itemno + 1
                Next d
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub cmsEdit_Click(sender As Object, e As EventArgs) Handles cmsEdit.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Inventory Locations", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.ILForm = False
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
            Dim editrsclinkform As New EditRackShelfColumnForm
            If dgRackShelfColumn.Rows.Count <> 0 Then
                editrsclinkform.erscrackshelfcolumnid = CInt(dgRackShelfColumn.CurrentRow.Cells("rsc_rowid").Value)
            End If
            If dgInventoryLocationList.Rows.Count <> 0 Then
                editrsclinkform.erscinventorylocationid = CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value)
            End If
            editrsclinkform.ShowInTaskbar = False
            editrsclinkform.ShowDialog()
            If editrsclinkform.ersccue = legit Then
                If dgInventoryLocationList.Rows.Count <> 0 Then
                    clearDataGrids()
                    cleargbAddRSC()
                    txtTotalProducts.Text = ""
                    txtTotalQtyAvailable.Text = ""
                    txtTotalQtyAllocated.Text = ""
                    txtTotalQtyOrderable.Text = ""
                    txtTotalQtyReserve.Text = ""
                    txtTotalQtyDamage.Text = ""
                    displayRackShelfColumn(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), rcspagenum)
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
            errProvider.Clear()
            'dgRackShelfColumn.CommitEdit(legit)
            dgRackShelfColumn.CommitEdit(Nothing) : dgRackShelfColumn.ClearSelection() : dgRackShelfColumn.CurrentCell = Nothing
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Inventory Locations", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.ILForm = False
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
                getInventorylocationIDA(txtLocationName.Text, Me)
            ElseIf cue = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If dgInventoryLocationList.Rows.Count <> 0 Then
                    getInventorylocationIDB(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), txtLocationName.Text, Me)
                End If
            End If
            ilinventorylocationid = globalinventorylocationid
            myModule.systemerrorfound = False
            If LTrim(txtLocationName.Text) = "" Then
                errProvider.SetError(txtLocationName, "Please type the location name.")
                txtLocationName.Focus()
            ElseIf LTrim(cboLocationType.Text) = "" Then
                errProvider.SetError(cboLocationType, "Please choose the location type.")
                cboLocationType.Focus()
            ElseIf ilinventorylocationid <> 0 Then
                errProvider.SetError(txtLocationName, "Location name has been created already, please type a new one.")
                txtLocationName.Focus()
            Else
                If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    If cue = "New" Then
                        getInventorylocationIDA(txtLocationName.Text, Me)
                        ilinventorylocationid = globalinventorylocationid
                        If ilinventorylocationid <> 0 Then
                            errProvider.SetError(txtLocationName, "Location name has been created already, please type a new one.")
                            txtLocationName.Focus()
                            Exit Try
                        End If
                        I_InventoryLocations(Z_OrganizationID, Date.Now, Z_UserID, Z_UserID, If(iladdressid = 0, New Integer?, iladdressid), txtLocationName.Text, cboLocationType.Text,
                                    txtMainPhone.Text, txtAlternatePhone.Text, txtFaxNo.Text, "Active", txtComments.Text, Me)
                        If myModule.systemerrorfound = False Then
                            If dgRackShelfColumn.Rows.Count <> 0 Then
                                getInventorylocationIDA(txtLocationName.Text, Me)
                                ilinventorylocationid = globalinventorylocationid
                                For a = 0 To dgRackShelfColumn.Rows.Count - 1
                                    If myModule.systemerrorfound = False Then
                                        I_RackShelfColumn(Z_OrganizationID, Date.Now, Z_UserID, Z_UserID, ilinventorylocationid, CStr(dgRackShelfColumn.Rows(a).Cells("rsc_rack").Value), CStr(dgRackShelfColumn.Rows(a).Cells("rsc_shelf").Value),
                                             CStr(dgRackShelfColumn.Rows(a).Cells("rsc_column").Value), CInt(dgRackShelfColumn.Rows(a).Cells("rsc_pickorderno").Value), CStr(dgRackShelfColumn.Rows(a).Cells("rsc_remarks").Value), "Active", Me)
                                    Else
                                        Exit Try
                                    End If
                                Next
                            End If
                        End If
                        If myModule.systemerrorfound = False Then
                            Await Task.Run(PopulateInventoryLocationWithProductColorSizesAsync())

                            myBalloon("Successfully Save", "Save", lblsavemsg, -15, -65)
                        End If
                    ElseIf cue = "Edit" Then
                        If dgInventoryLocationList.Rows.Count <> 0 Then
                            getInventorylocationIDB(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), txtLocationName.Text, Me)
                            ilinventorylocationid = globalinventorylocationid
                        End If
                        If ilinventorylocationid <> 0 Then
                            errProvider.SetError(txtLocationName, "Location name has been created already, please type a new one.")
                            txtLocationName.Focus()
                            Exit Try
                        End If
                        U_InventoryLocations(CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), Date.Now, Z_UserID, iladdressid, txtLocationName.Text, cboLocationType.Text,
                                    txtMainPhone.Text, txtAlternatePhone.Text, txtFaxNo.Text, txtComments.Text, Me)
                        If myModule.systemerrorfound = False Then
                            If dgRackShelfColumn.Rows.Count <> 0 Then
                                For a = 0 To dgRackShelfColumn.Rows.Count - 1
                                    If myModule.systemerrorfound = False Then
                                        If CStr(dgRackShelfColumn.Rows(a).Cells("rsc_rowid").Value) = "" Then
                                            getRackShelfColumnID(String.Concat({dgRackShelfColumn.Rows(a).Cells("rsc_rack").Value, dgRackShelfColumn.Rows(a).Cells("rsc_shelf").Value, dgRackShelfColumn.Rows(a).Cells("rsc_column").Value}), CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), Me)
                                            ilrackshelfcolumnid = globalrackshelfcolumnid
                                            If ilrackshelfcolumnid = 0 Then
                                                I_RackShelfColumn(Z_OrganizationID, Date.Now, Z_UserID, Z_UserID, CInt(dgInventoryLocationList.CurrentRow.Cells("il_rowid").Value), CStr(dgRackShelfColumn.Rows(a).Cells("rsc_rack").Value),
                                                    CStr(dgRackShelfColumn.Rows(a).Cells("rsc_shelf").Value), CStr(dgRackShelfColumn.Rows(a).Cells("rsc_column").Value), CInt(dgRackShelfColumn.Rows(a).Cells("rsc_pickorderno").Value), CStr(dgRackShelfColumn.Rows(a).Cells("rsc_remarks").Value), "Active", Me)
                                            End If
                                        End If
                                    Else
                                        Exit Try
                                    End If
                                Next
                            End If
                        End If
                        If myModule.systemerrorfound = False Then
                            Await Task.Run(PopulateInventoryLocationWithProductColorSizesAsync())

                            myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                        End If
                    Else
                    End If
                    If myModule.systemerrorfound = False Then
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

    Private Function PopulateInventoryLocationWithProductColorSizesAsync() As Func(Of Task)
        Return Async Function()
                   Await FunctionUtils.TryCatchFunctionAsync("Save changes Inventory Location",
                        Async Function()
                            Dim inventoryLocationDataService = GetRequiredService(Of IInventoryLocationDataService)()

                            Await inventoryLocationDataService.PopulateWithProductColorSizesAsync(
                                inventoryLocationName:=txtLocationName.Text.Trim,
                                userId:=Z_UserID)

                            MessageBox.Show(text:="Inventory location save changes!",
                                caption:="",
                                buttons:=MessageBoxButtons.OK,
                                icon:=MessageBoxIcon.Information)
                        End Function)
               End Function
    End Function

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
            ElseIf cboSearch1.Text = "Column" Then
                autocompleteColumn(cboSearch2)
                autopopulateColumn(cboSearch2)
            ElseIf cboSearch1.Text = "LocationType" Then
                autocompleteLocationType(cboSearch2)
                autopopulateLocationTypeA(cboSearch2)
            ElseIf cboSearch1.Text = "Rack" Then
                autocompleteRack(cboSearch2)
                autopopulateRack(cboSearch2)
            ElseIf cboSearch1.Text = "Shelf" Then
                autocompleteShelf(cboSearch2)
                autopopulateShelf(cboSearch2)
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
            ElseIf cboSearch3.Text = "Column" Then
                autocompleteColumn(cboSearch4)
                autopopulateColumn(cboSearch4)
            ElseIf cboSearch3.Text = "LocationType" Then
                autocompleteLocationType(cboSearch4)
                autopopulateLocationTypeA(cboSearch4)
            ElseIf cboSearch3.Text = "Rack" Then
                autocompleteRack(cboSearch4)
                autopopulateRack(cboSearch4)
            ElseIf cboSearch3.Text = "Shelf" Then
                autocompleteShelf(cboSearch4)
                autopopulateShelf(cboSearch4)
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
                If cboSearch1.Text = "" AndAlso cboSearch3.Text = "" Then
                    tsrefreshperformclick()
                ElseIf cboSearch2.Text = "" AndAlso cboSearch4.Text = "" Then
                    tsrefreshperformclick()
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
                    spagenum = neutralpage : numofpages = startingpage
                    displayCommonPhrase(pagefilter3, spagenum)
                    pageSetup2(pagefilter3)
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

    Private Sub cboSearch4_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSearch4.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If cboSearch1.Text = "" AndAlso cboSearch3.Text = "" Then
                    tsrefreshperformclick()
                ElseIf cboSearch2.Text = "" AndAlso cboSearch4.Text = "" Then
                    tsrefreshperformclick()
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
                    spagenum = neutralpage : numofpages = startingpage
                    displayCommonPhrase(pagefilter3, spagenum)
                    pageSetup2(pagefilter3)
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
                displayInventoryLocationList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, spagenum)
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
                displayInventoryLocationList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, spagenum)
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
                displayInventoryLocationList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, spagenum)
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
                displayInventoryLocationList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(pagefilter3, spagenum)
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
                        tabMain.SelectedTab = tabDetails
                        If countpagenum < pagedivisor Then
                            spagenum = neutralpage
                        Else
                            pageequation1 = CInt(txtPage.Text) * pagedivisor
                            pageequation2 = CDec((CInt(txtPage.Text) / validpages * countpagenum))
                            If pageequation1 < pageequation2 Then
                                pageequation3 = CDec((CInt(txtPage.Text) / validpages * countpagenum) - (pageequation2 - pageequation1))
                            Else
                                pageequation3 =
                                    CDec(CInt(txtPage.Text) / validpages * countpagenum)
                            End If
                            spagenum = CInt(pageequation3 - pagedivisor)
                        End If
                        numofpages = CInt(txtPage.Text)
                        If searchmode = "Basic" Then
                            displayInventoryLocationList(spagenum)
                        ElseIf searchmode = "CommonSearch" Then
                            displayCommonPhrase(pagefilter3, spagenum)
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

#Region "Datagrid Errors"

    Private Sub dgInventoryLocationList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgInventoryLocationList.DataError
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
                dgInventoryLocationList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgRackShelfColumn_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgRackShelfColumn.DataError
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
                dgRackShelfColumn.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgProducts_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgProducts.DataError
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
                dgProducts.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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