Imports Microsoft.Extensions.DependencyInjection
Imports MySql.Data.MySqlClient
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices

Public Class AccountsForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim itemno, rowscount As Integer
    Dim cueA, searchmodeA, cueB, searchmodeB As String
    Dim aftotalqtydelivered, afqtyordered As Integer
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal
    Dim spagenumA, spagenumB, countpagenumA, countpagenumB, numofpagesA, numofpagesB, validpagesA, validpagesB As Integer
    Dim simplesearchphraseA, simplesearchphraseB, commonphrase, pagefilter1, pagefilter2, pagefilter3A, pagefilter3B As String
    Dim cfparentcustomerid, cfdeliveryaddressid, cfcontactpersonid, cfpicklistgroupid, cfbranchid, sfdeliveryaddressid, sfcontactpersonid As Integer
    Private _agents As List(Of WarehouseManagementSystem.Core.Entities.Contact)
    Private _systemOwner As SystemOwner

    Private Async Sub AccountsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfieldsA()
            clearfieldsB()
            callAutoPopulate()
            tabAccounts.SelectedTab = tabSuppliers
            displaySupplierList(spagenumB)
            pageSetupB()
            txtPageNo.Text = "" & numofpagesB & " of " & validpagesB & " "
            tabAccounts.SelectedTab = tabCustomers
            displayCustomerList(spagenumA)
            pageSetupA()
            txtPageNoA.Text = "" & numofpagesA & " of " & validpagesA & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default

        If IsThurston Then
            'For Each comboBox In gbCustomerInformation.Controls.
            '    OfType(Of Control).
            '    OfType(Of ComboBox).
            '    ToArray()

            '    SetStyleToDropDownList(comboBox)
            'Next
        End If
    End Sub

    Private Sub AccountsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            myBalloon(, , lblsavemsgA, , , 1)
            myBalloon(, , lblsavemsg, , , 1)
            myBalloon(, , pbAutoAddA, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#Region "Functions"

    Sub callAutoPopulate()
        autopopulatecboSearch()
        autopopulateStatus(cboStatusA)
        autopopulateStatus(cboStatus)
        autopopulateAgent(cboAgent)
    End Sub

#Region "Clear/Enable/Visible"

#Region "Customers Tab"

    Sub clearfieldsA()
        Try
            cueA = ""
            searchmodeA = "Basic"
            spagenumA = neutralpage : numofpagesA = startingpage
            clearSearchItemsA()
            clearCustomerInformation()
            dgCustomerOrders.Rows.Clear()
            dgCustomerOrderItems.Rows.Clear()
            enableGBA(legit, fraud, fraud)
            enableANDvisibleMSA(legit, fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRightPageA()
        Try
            cueA = ""
            clearCustomerInformation()
            dgCustomerOrders.Rows.Clear()
            dgCustomerOrderItems.Rows.Clear()
            enableGBA(legit, fraud, fraud)
            enableANDvisibleMSA(legit, fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearSearchItemsA()
        Try
            txtSimpleSearchA.Text = ""
            txtPageNoA.Text = ""
            txtPageA.Text = ""
            cboSearch2A.Text = ""
            cboSearch4A.Text = ""
            cboSearch1A.SelectedItem = Nothing
            cboSearch2A.SelectedItem = Nothing
            cboSearch3A.SelectedItem = Nothing
            cboSearch4A.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearcboSearchA()
        Try
            txtPageA.Text = ""
            cboSearch1A.SelectedItem = Nothing : cboSearch3A.SelectedItem = Nothing
            cboSearch2A.Items.Clear() : cboSearch2A.AutoCompleteCustomSource.Clear()
            cboSearch2A.Text = "" : cboSearch2A.SelectedItem = Nothing
            cboSearch4A.Items.Clear() : cboSearch4A.AutoCompleteCustomSource.Clear()
            cboSearch4A.Text = "" : cboSearch4A.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearCustomerInformation()
        Try
            txtCustomerNo.Text = ""
            txtCustomerName.Text = ""
            cboParentCustomer.Text = ""
            cboPickingGroup.Text = ""
            txtMainPhoneA.Text = ""
            txtContactPersonA.Text = ""
            txtEmailAddressA.Text = ""
            txtDeliveryAddressA.Text = ""
            txtFaxNoA.Text = ""
            txtAlternatePhoneA.Text = ""
            txtWebsiteA.Text = ""
            txtTINA.Text = ""
            txtCommentsA.Text = ""
            txtDeliveryHours.Text = ""
            cboBranchCodeNameInfo.Text = ""
            cboBranchCodeNameInfo.SelectedItem = Nothing
            cboStatusA.SelectedItem = Nothing
            cboPickingGroup.SelectedItem = Nothing
            cboParentCustomer.SelectedItem = Nothing
            dtpFromSearch.Value = Now.Date.AddDays(-(Now.Day) + 1)
            dtpToSearch.Value = Now.Date
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGBA(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean)
        Try
            gbSearchA.Enabled = enable1
            gbCustomerList.Enabled = enable1
            gbCustomerInformation.Enabled = enable2
            gbCustomerOrders.Enabled = enable3
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableANDvisibleMSA(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal visible1 As Boolean)
        Try
            msNewA.Enabled = enable1
            msSaveA.Enabled = enable2
            msCancelA.Visible = visible1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Suppliers Tab"

    Sub clearfieldsB()
        Try
            cueB = ""
            searchmodeB = "Basic"
            spagenumB = neutralpage : numofpagesB = startingpage
            clearSearchItems()
            clearSupplierInformation()
            enableGB(legit, fraud)
            enableANDvisibleMS(legit, fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRightPage()
        Try
            cueB = ""
            clearSupplierInformation()
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
            cboSearch3.Text = ""
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
            cboSearch1.SelectedItem = Nothing : cboSearch2.SelectedItem = Nothing
            cboSearch3.Items.Clear() : cboSearch3.AutoCompleteCustomSource.Clear()
            cboSearch3.Text = "" : cboSearch3.SelectedItem = Nothing
            cboSearch4.Items.Clear() : cboSearch4.AutoCompleteCustomSource.Clear()
            cboSearch4.Text = "" : cboSearch4.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearSupplierInformation()
        Try
            txtSupplierNo.Text = ""
            txtSupplierName.Text = ""
            txtMainPhone.Text = ""
            txtContactPerson.Text = ""
            txtEmailAddress.Text = ""
            txtFaxNo.Text = ""
            txtAlternatePhone.Text = ""
            txtWebsite.Text = ""
            txtTIN.Text = ""
            txtComments.Text = ""
            cboStatus.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbSupplierList.Enabled = enable1
            gbSupplierInformation.Enabled = enable2
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

#End Region

#Region "Click"

    Sub tsrefreshperformclickA()
        Try
            errProvider.Clear()
            clearfieldsA()
            callAutoPopulate()
            displayCustomerList(spagenumA)
            pageSetupA()
            txtPageNoA.Text = "" & numofpagesA & " of " & validpagesA & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub tsrefreshperformclickB()
        Try
            errProvider.Clear()
            clearfieldsB()
            callAutoPopulate()
            displaySupplierList(spagenumB)
            pageSetupB()
            txtPageNo.Text = "" & numofpagesB & " of " & validpagesB & " "
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
            aftotalqtydelivered = 0
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(plo.rowid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.orderitemid = " & iorderitemid & " AND plo.orderid = " & iorderid & " AND (plo.`status` != 'Inactive' AND plo.`status` != 'Cancelled') ")
            If dtGid.Rows.Count <> 0 Then
                getTotalQyDelivered(CInt(dtGid.Rows(0)(0)))
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getTotalQyDelivered(ByVal ipicklistorderid As Integer)
        Try
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pli.qtydelivered)) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND (pli.`status` != 'Inactive' AND pli.`status` != 'Cancelled') ")
            If dtGtq.Rows.Count <> 0 Then
                aftotalqtydelivered = dtGtq.Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub customerorderitemscomputations()
        Try
            afqtyordered = 0
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                For i = 0 To dgCustomerOrderItems.Rows.Count - 1
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_qtyordered").Value) Then
                        afqtyordered = CInt(dgCustomerOrderItems.Rows(i).Cells("ci_qtyordered").Value)
                    Else
                        afqtyordered = 0
                    End If
                    If IsNumeric(dgCustomerOrderItems.Rows(i).Cells("ci_srp").Value) Then
                        dgCustomerOrderItems.Rows(i).Cells("ci_totalprice").Value = Math.Round(afqtyordered * CDec(dgCustomerOrderItems.Rows(i).Cells("ci_srp").Value), 2)
                    Else
                        dgCustomerOrderItems.Rows(i).Cells("ci_totalprice").Value = 0.0
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

#Region "Page Setup"

    Sub pageSetupA()
        Try
            getCountPageNumA()
            If countpagenumA < pagedivisor Then
                validpagesA = startingpage
            Else
                additionalpage = countpagenumA / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpagesA = countpagenumA / pagedivisor
                Else
                    validpagesA = countpagenumA / pagedivisor
                    validpagesA = validpagesA + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNumA()
        Try
            countpagenumA = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COUNT(c.rowid) FROM accounts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' ")
            If dtCid.Rows.Count <> 0 Then
                countpagenumA = dtCid.Rows(0)(0)
            Else
                countpagenumA = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub pageSetup1A(ByVal isearchstring As String)
        Try
            getCountPageNum1A(isearchstring)
            If countpagenumA < pagedivisor Then
                validpagesA = startingpage
            Else
                additionalpage = countpagenumA / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpagesA = countpagenumA / pagedivisor
                Else
                    validpagesA = countpagenumA / pagedivisor
                    validpagesA = validpagesA + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNum1A(ByVal esearchstring As String)
        Try
            countpagenumA = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(c.rowid),0) FROM accounts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' AND (c.companyname LIKE ""%" & esearchstring & "%"" OR c.accountno LIKE ""%" & esearchstring & "%"") ")
            If dtCid.Rows.Count <> 0 Then
                countpagenumA = dtCid.Rows(0)(0)
            Else
                countpagenumA = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub pageSetup2A(ByVal isearchstring As String)
        Try
            getCountPageNum2A(isearchstring)
            If countpagenumA < pagedivisor Then
                validpagesA = startingpage
            Else
                additionalpage = countpagenumA / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpagesA = countpagenumA / pagedivisor
                Else
                    validpagesA = countpagenumA / pagedivisor
                    validpagesA = validpagesA + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNum2A(ByVal ecommontring As String)
        Try
            countpagenumA = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COUNT(c.rowid) FROM accounts c LEFT JOIN address ad ON c.primaryaddressid = ad.rowid " &
                            "WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' AND " & ecommontring & " ")
            If dtCid.Rows.Count <> 0 Then
                countpagenumA = dtCid.Rows(0)(0)
            Else
                countpagenumA = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCommonPhraseA(ByVal icommonbox As ComboBox, ByVal icommonstring As String)
        Try
            commonphrase = ""
            If icommonbox.Text = "City/Town" Then
                commonphrase = "ad.citytown = """ & icommonstring & """"
            ElseIf icommonbox.Text = "ParentCustomer" Then
                getCustomerID(icommonstring, Me)
                cfparentcustomerid = globalcustomerid
                commonphrase = "c.parentaccountid = " & cfparentcustomerid & ""
            ElseIf icommonbox.Text = "Province" Then
                commonphrase = "ad.province = """ & icommonstring & """"
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub pageSetupB()
        Try
            getCountPageNumB()
            If countpagenumB < pagedivisor Then
                validpagesB = startingpage
            Else
                additionalpage = countpagenumB / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpagesB = countpagenumB / pagedivisor
                Else
                    validpagesB = countpagenumB / pagedivisor
                    validpagesB = validpagesB + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNumB()
        Try
            countpagenumB = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COUNT(c.rowid) FROM accounts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Supplier' ")
            If dtCid.Rows.Count <> 0 Then
                countpagenumB = dtCid.Rows(0)(0)
            Else
                countpagenumB = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub pageSetup1B(ByVal isearchstring As String)
        Try
            getCountPageNum1B(isearchstring)
            If countpagenumB < pagedivisor Then
                validpagesB = startingpage
            Else
                additionalpage = countpagenumB / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpagesB = countpagenumB / pagedivisor
                Else
                    validpagesB = countpagenumB / pagedivisor
                    validpagesB = validpagesB + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNum1B(ByVal esearchstring As String)
        Try
            countpagenumB = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(c.rowid),0) FROM accounts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Supplier' AND (c.companyname LIKE '%" & esearchstring & "%' OR c.accountno LIKE '%" & esearchstring & "%') ")
            If dtCid.Rows.Count <> 0 Then
                countpagenumB = dtCid.Rows(0)(0)
            Else
                countpagenumB = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub pageSetup2B(ByVal isearchstring As String)
        Try
            getCountPageNum2B(isearchstring)
            If countpagenumB < pagedivisor Then
                validpagesB = startingpage
            Else
                additionalpage = countpagenumB / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpagesB = countpagenumB / pagedivisor
                Else
                    validpagesB = countpagenumB / pagedivisor
                    validpagesB = validpagesB + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNum2B(ByVal ecommontring As String)
        Try
            countpagenumB = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COUNT(c.rowid) FROM accounts c LEFT JOIN address ad ON c.primaryaddressid = ad.rowid " &
                            "WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Supplier' AND " & ecommontring & " ")
            If dtCid.Rows.Count <> 0 Then
                countpagenumB = dtCid.Rows(0)(0)
            Else
                countpagenumB = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCommonPhraseB(ByVal icommonbox As ComboBox, ByVal icommonstring As String)
        Try
            commonphrase = ""
            If icommonbox.Text = "City/Town" Then
                commonphrase = "ad.citytown = """ & icommonstring & """"
            ElseIf icommonbox.Text = "Province" Then
                commonphrase = "ad.province = """ & icommonstring & """"
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

    Sub autocompleteCityTown(ByVal icombobox As ComboBox)
        Try
            Dim citytown As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(ad.citytown,'') AS 'citytown' FROM accounts c LEFT JOIN address ad ON c.primaryaddressid = ad.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND ad.citytown != '' GROUP BY ad.citytown ORDER BY ad.citytown ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                citytown.Add(ds.Tables(0).Rows(i)("citytown").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = citytown
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteParentCustomerA(ByVal icombobox As ComboBox)
        Try
            Dim parentcustomer As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(c.companyname,''),' - ',COALESCE(c.accountno,'')),'') AS 'parentcustomer' FROM accounts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' GROUP BY c.accountno ORDER BY c.accountno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                parentcustomer.Add(ds.Tables(0).Rows(i)("parentcustomer").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = parentcustomer
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteParentCustomerB(ByVal icombobox As ComboBox)
        Try
            Dim parentcustomer As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(pa.companyname,''),' - ',COALESCE(pa.accountno,'')),'') AS 'parentcustomer' FROM accounts c LEFT JOIN accounts pa ON c.parentaccountid = pa.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' GROUP BY pa.accountno ORDER BY pa.accountno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                parentcustomer.Add(ds.Tables(0).Rows(i)("parentcustomer").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = parentcustomer
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompleteProvince(ByVal icombobox As ComboBox)
        Try
            Dim province As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(ad.province,'') AS 'province' FROM accounts c LEFT JOIN address ad ON c.primaryaddressid = ad.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND ad.province != '' GROUP BY ad.province ORDER BY ad.province ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                province.Add(ds.Tables(0).Rows(i)("province").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = province
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autocompletePickingGroup(ByVal icombobox As ComboBox)
        Try
            Dim groupname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(pg.groupname,'') AS 'groupname' FROM accounts c LEFT JOIN picklistgroup pg ON c.picklistgroupid = pg.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' AND c.picklistgroupid IS NOT NULL GROUP BY pg.groupname ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                groupname.Add(ds.Tables(0).Rows(i)("groupname").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = groupname
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
            cboSearch1A.Items.Clear()
            cboSearch3A.Items.Clear()
            cboSearch1A.Items.Add("City/Town")
            cboSearch1A.Items.Add("ParentCustomer")
            cboSearch1A.Items.Add("Province")
            cboSearch3A.Items.Add("City/Town")
            cboSearch3A.Items.Add("ParentCustomer")
            cboSearch3A.Items.Add("Province")
            cboSearch1A.Items.Add("")
            cboSearch3A.Items.Add("")

            cboSearch1.Items.Clear()
            cboSearch3.Items.Clear()
            cboSearch1.Items.Add("City/Town")
            cboSearch1.Items.Add("Province")
            cboSearch3.Items.Add("City/Town")
            cboSearch3.Items.Add("Province")
            cboSearch1.Items.Add("")
            cboSearch3.Items.Add("")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autopopulateCityTown(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(ad.citytown,'') AS 'citytown' FROM accounts c LEFT JOIN address ad ON c.primaryaddressid = ad.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND ad.citytown != '' GROUP BY ad.citytown ORDER BY ad.citytown "
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

    Sub autopopulateParentCustomerA(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(c.companyname,''),' - ',COALESCE(c.accountno,'')),'') AS 'parentcustomer' FROM accounts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' GROUP BY c.accountno ORDER BY c.companyname "
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

    Sub autopopulateParentCustomerB(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(pa.companyname,''),' - ',COALESCE(pa.accountno,'')),'') AS 'parentcustomer' FROM accounts c LEFT JOIN accounts pa ON c.parentaccountid = pa.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' GROUP BY pa.accountno ORDER BY pa.companyname "
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

    Sub autopopulateProvince(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(ad.province,'') AS 'province' FROM accounts c LEFT JOIN address ad ON c.primaryaddressid = ad.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND ad.province != '' GROUP BY ad.province ORDER BY ad.province "
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
            Dim sql1 As String = "SELECT lic FROM listofvalues WHERE type = 'Status' AND status = 'Active' ORDER BY lic "
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

    Async Sub autopopulateAgent(ByVal icombobox As ComboBox)
        Dim contactDataService = MainServiceProvider.GetRequiredService(Of IContactDataService)

        _agents = Await contactDataService.GetAgentsAsync(organizationId:=Z_OrganizationID)

        Dim agentDataSource = New List(Of WarehouseManagementSystem.Core.Entities.Contact) From {WarehouseManagementSystem.Core.Entities.Contact.NewContact(organizationId:=Z_OrganizationID, lastName:=String.Empty, firstName:=String.Empty, workPhone:=String.Empty, type:=1)}
        agentDataSource.AddRange(_agents)
        icombobox.ValueMember = "RowID"
        icombobox.DisplayMember = "FullNameLastNameFirst"
        icombobox.DataSource = agentDataSource
    End Sub

    Sub autopopulatePickingGroup(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(pg.groupname,'') AS 'groupname' FROM accounts c LEFT JOIN picklistgroup pg ON c.picklistgroupid = pg.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' AND c.picklistgroupid IS NOT NULL GROUP BY pg.groupname ORDER BY pg.groupname "
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

    Sub displayCustomerList(ByVal istartpage As Integer)
        Try
            dgCustomerList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT c.rowid,COALESCE(c.accountno,''),COALESCE(c.companyname,''),COALESCE(CONCAT(COALESCE(pa.companyname,''),' - ',COALESCE(pa.accountno,'')),''),COALESCE(c.mainphone,'') FROM accounts c " &
                        "LEFT JOIN accounts pa ON c.parentaccountid = pa.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' ORDER BY c.accountno ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCustomerList.Rows.Add()
                    dgCustomerList.Item(c_rowid.Index, n).Value = reader1(0)
                    dgCustomerList.Item(c_customerno.Index, n).Value = reader1(1)
                    dgCustomerList.Item(c_customername.Index, n).Value = reader1(2)
                    dgCustomerList.Item(c_parentcustomer.Index, n).Value = reader1(3)
                    dgCustomerList.Item(c_mainphone.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCustomerList.Columns("c_customerno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerList.Columns("c_mainphone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If tabAccounts.SelectedTab Is tabCustomers Then
                If dgCustomerList.Rows.Count <> 0 Then
                    dgCustomerList.CurrentRow.Selected = False
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySearchPhraseA(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgCustomerList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT c.rowid,COALESCE(c.accountno,''),COALESCE(c.companyname,''),COALESCE(CONCAT(COALESCE(pa.companyname,''),' - ',COALESCE(pa.accountno,'')),''),COALESCE(c.mainphone,'') FROM accounts c " &
                        "LEFT JOIN accounts pa ON c.parentaccountid = pa.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' AND (c.companyname LIKE ""%" & isearchphrase & "%"" OR c.accountno LIKE ""%" & isearchphrase & "%"") " &
                        "ORDER BY c.accountno ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCustomerList.Rows.Add()
                    dgCustomerList.Item(c_rowid.Index, n).Value = reader1(0)
                    dgCustomerList.Item(c_customerno.Index, n).Value = reader1(1)
                    dgCustomerList.Item(c_customername.Index, n).Value = reader1(2)
                    dgCustomerList.Item(c_parentcustomer.Index, n).Value = reader1(3)
                    dgCustomerList.Item(c_mainphone.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCustomerList.Columns("c_customerno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerList.Columns("c_mainphone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCustomerList.Rows.Count <> 0 Then
                dgCustomerList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCommonPhraseA(ByVal icommonphrase As String, ByVal istartpage As Integer)
        Try
            dgCustomerList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT c.rowid,COALESCE(c.accountno,''),COALESCE(c.companyname,''),COALESCE(CONCAT(COALESCE(pa.companyname,''),' - ',COALESCE(pa.accountno,'')),''),COALESCE(c.mainphone,'') FROM accounts c " &
                        "LEFT JOIN accounts pa ON c.parentaccountid = pa.rowid LEFT JOIN address ad ON c.primaryaddressid = ad.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Customer' AND " & icommonphrase & " " &
                        "ORDER BY c.accountno ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCustomerList.Rows.Add()
                    dgCustomerList.Item(c_rowid.Index, n).Value = reader1(0)
                    dgCustomerList.Item(c_customerno.Index, n).Value = reader1(1)
                    dgCustomerList.Item(c_customername.Index, n).Value = reader1(2)
                    dgCustomerList.Item(c_parentcustomer.Index, n).Value = reader1(3)
                    dgCustomerList.Item(c_mainphone.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCustomerList.Columns("c_customerno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerList.Columns("c_mainphone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCustomerList.Rows.Count <> 0 Then
                dgCustomerList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCustomerInformation(ByVal icustomerid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(c.accountno,''),COALESCE(c.companyname,''),COALESCE(CONCAT(COALESCE(pa.companyname,''),' - ',COALESCE(pa.accountno,'')),''),COALESCE(c.mainphone,''),COALESCE(CONCAT(COALESCE(cp.firstname,''),' ',COALESCE(cp.middlename,''),' ',COALESCE(cp.lastname,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(ad.streetaddress1,''),' ',COALESCE(ad.streetaddress2,''),' ',COALESCE(ad.barangay,''),' ',COALESCE(ad.citytown,''),' ',COALESCE(ad.province,''),' ',COALESCE(ad.state,''),' ',COALESCE(ad.zipcode,''),' ',COALESCE(ad.country,'')),''),COALESCE(c.faxnumber,'')," &
                        "COALESCE(c.altphone,''),COALESCE(c.website,''),COALESCE(c.vatregistrationno,''),COALESCE(c.comments,''),COALESCE(c.status,''),COALESCE(c.emailaddress,''),COALESCE(c.primaryaddressid,0),COALESCE(c.primarycontactid,0),COALESCE(pg.groupname,''),COALESCE(c.deliveryhours,'')," &
                        "COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),''), c.AgentID FROM accounts c LEFT JOIN accounts pa ON c.parentaccountid = pa.rowid LEFT JOIN contacts cp ON c.primarycontactid = cp.rowid LEFT JOIN address ad ON c.primaryaddressid = ad.rowid " &
                        "LEFT JOIN picklistgroup pg ON c.picklistgroupid = pg.rowid LEFT JOIN branches bc ON c.branchid = bc.rowid WHERE c.rowid = " & icustomerid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtCustomerNo.Text = reader1(0)
                    txtCustomerName.Text = reader1(1)
                    cboParentCustomer.Text = reader1(2)
                    txtMainPhoneA.Text = reader1(3)
                    txtContactPersonA.Text = reader1(4)
                    txtDeliveryAddressA.Text = reader1(5)
                    txtFaxNoA.Text = reader1(6)
                    txtAlternatePhoneA.Text = reader1(7)
                    txtWebsiteA.Text = reader1(8)
                    txtTINA.Text = reader1(9)
                    txtCommentsA.Text = reader1(10)
                    cboStatusA.Text = reader1(11)
                    txtEmailAddressA.Text = reader1(12)
                    cfdeliveryaddressid = reader1(13)
                    cfcontactpersonid = reader1(14)
                    cboPickingGroup.Text = reader1(15)
                    txtDeliveryHours.Text = reader1(16)
                    cboBranchCodeNameInfo.Text = reader1(17)

                    If IsDBNull(reader1(18)) Then
                        cboAgent.SelectedIndex = -1
                    Else
                        cboAgent.SelectedValue = CInt(reader1(18))
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

    Sub displayCustomerOrders(ByVal iaccountid As Integer)
        Try
            dgCustomerOrders.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT co.rowid,COALESCE(co.ordernumber,''),COALESCE(co.referencenumber,''),DATE_FORMAT(co.orderdate,'%d-%b-%Y'),COALESCE(co.status,'') " &
                        "FROM orders co WHERE co.organizationid = " & Z_OrganizationID & $" AND co.ordertype = '{OrderType.CO.ToString()}' AND co.accountid = " & iaccountid & " AND " &
                        "(co.orderdate >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' AND " &
                        "co.orderdate <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) GROUP BY co.rowid ORDER BY co.ordernumber DESC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCustomerOrders.Rows.Add()
                    dgCustomerOrders.Item(co_seqno.Index, n).Value = seqno
                    dgCustomerOrders.Item(co_rowid.Index, n).Value = reader1(0)
                    dgCustomerOrders.Item(co_customerorderno.Index, n).Value = reader1(1)
                    dgCustomerOrders.Item(co_pono.Index, n).Value = reader1(2)
                    dgCustomerOrders.Item(co_customerorderdate.Index, n).Value = reader1(3)
                    dgCustomerOrders.Item(co_status.Index, n).Value = reader1(4)
                    getLineUpNos(CInt(reader1(0)), Me)
                    dgCustomerOrders.Item(co_drnos.Index, n).Value = globallineupnos
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCustomerOrders.Columns("co_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrders.Columns("co_customerorderno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrders.Columns("co_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrders.Columns("co_customerorderdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrders.Columns("co_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrders.Columns("co_drnos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCustomerOrders.Rows.Count <> 0 Then
                dgCustomerOrders.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
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
                    "COALESCE(CONCAT(COALESCE(dr.firstname,''),' ',COALESCE(dr.middlename,''),' ',COALESCE(dr.lastname,''),' ',COALESCE(dr.suffix,''),' - ',COALESCE(dr.contactno,'')),'') FROM orderitems ci LEFT JOIN contacts pa ON ci.packedby = pa.rowid " &
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
                    dgCustomerOrderItems.Item(ci_qtyordered.Index, n).Value = reader1(10)
                    dgCustomerOrderItems.Item(ci_srp.Index, n).Value = reader1(11)
                    If CInt(reader1(1)) <> 0 Then
                        dgCustomerOrderItems.Item(ci_sku.Index, n).Value = reader1(12)
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
                        getPickListOrderID(CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value), CInt(reader1(0)))
                        dgCustomerOrderItems.Item(ci_qtydelivered.Index, n).Value = aftotalqtydelivered
                    Else
                        dgCustomerOrderItems.Item(ci_status.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_verifiedby.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_verifieddate.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_packedby.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_packeddate.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_deliveredby.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_delivereddate.Index, n).Value = ""
                        dgCustomerOrderItems.Item(ci_qtydelivered.Index, n).Value = ""
                    End If
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
            dgCustomerOrderItems.Columns("ci_qtydelivered").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_totalprice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_verifieddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCustomerOrderItems.Columns("ci_delivereddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCustomerOrderItems.Rows.Count <> 0 Then
                dgCustomerOrderItems.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySupplierList(ByVal istartpage As Integer)
        Try
            dgSuppliersList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT c.rowid,COALESCE(c.accountno,''),COALESCE(c.companyname,''),COALESCE(CONCAT(COALESCE(pa.companyname,''),' - ',COALESCE(pa.accountno,'')),''),COALESCE(c.mainphone,'') FROM accounts c " &
                        "LEFT JOIN accounts pa ON c.parentaccountid = pa.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Supplier' ORDER BY c.accountno ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgSuppliersList.Rows.Add()
                    dgSuppliersList.Item(s_rowid.Index, n).Value = reader1(0)
                    dgSuppliersList.Item(s_supplierno.Index, n).Value = reader1(1)
                    dgSuppliersList.Item(s_suppliername.Index, n).Value = reader1(2)
                    dgSuppliersList.Item(s_mainphone.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgSuppliersList.Columns("s_supplierno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSuppliersList.Columns("s_mainphone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If tabAccounts.SelectedTab Is tabSuppliers Then
                If dgSuppliersList.Rows.Count <> 0 Then
                    dgSuppliersList.CurrentRow.Selected = False
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySearchPhraseB(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgSuppliersList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT c.rowid,COALESCE(c.accountno,''),COALESCE(c.companyname,''),COALESCE(CONCAT(COALESCE(pa.companyname,''),' - ',COALESCE(pa.accountno,'')),''),COALESCE(c.mainphone,'') FROM accounts c " &
                        "LEFT JOIN accounts pa ON c.parentaccountid = pa.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Supplier' AND (c.companyname LIKE '%" & isearchphrase & "%' OR c.accountno LIKE '%" & isearchphrase & "%') " &
                        "ORDER BY c.accountno ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgSuppliersList.Rows.Add()
                    dgSuppliersList.Item(s_rowid.Index, n).Value = reader1(0)
                    dgSuppliersList.Item(s_supplierno.Index, n).Value = reader1(1)
                    dgSuppliersList.Item(s_suppliername.Index, n).Value = reader1(2)
                    dgSuppliersList.Item(s_mainphone.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgSuppliersList.Columns("s_supplierno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSuppliersList.Columns("s_mainphone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgSuppliersList.Rows.Count <> 0 Then
                dgSuppliersList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayCommonPhraseB(ByVal icommonphrase As String, ByVal istartpage As Integer)
        Try
            dgSuppliersList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT c.rowid,COALESCE(c.accountno,''),COALESCE(c.companyname,''),COALESCE(CONCAT(COALESCE(pa.companyname,''),' - ',COALESCE(pa.accountno,'')),''),COALESCE(c.mainphone,'') FROM accounts c " &
                        "LEFT JOIN accounts pa ON c.parentaccountid = pa.rowid LEFT JOIN address ad ON c.primaryaddressid = ad.rowid WHERE c.organizationid = " & Z_OrganizationID & " AND c.accounttype = 'Supplier' AND " & icommonphrase & " " &
                        "ORDER BY c.accountno ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgSuppliersList.Rows.Add()
                    dgSuppliersList.Item(s_rowid.Index, n).Value = reader1(0)
                    dgSuppliersList.Item(s_supplierno.Index, n).Value = reader1(1)
                    dgSuppliersList.Item(s_suppliername.Index, n).Value = reader1(2)
                    dgSuppliersList.Item(s_mainphone.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgSuppliersList.Columns("s_supplierno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSuppliersList.Columns("s_mainphone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgSuppliersList.Rows.Count <> 0 Then
                dgSuppliersList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displaySupplierInformation(ByVal isupplierid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(c.accountno,''),COALESCE(c.companyname,''),COALESCE(CONCAT(COALESCE(pa.companyname,''),' - ',COALESCE(pa.accountno,'')),''),COALESCE(c.mainphone,''),COALESCE(CONCAT(COALESCE(cp.firstname,''),' ',COALESCE(cp.middlename,''),' ',COALESCE(cp.lastname,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(ad.streetaddress1,''),' ',COALESCE(ad.streetaddress2,''),' ',COALESCE(ad.barangay,''),' ',COALESCE(ad.citytown,''),' ',COALESCE(ad.province,''),' ',COALESCE(ad.state,''),' ',COALESCE(ad.zipcode,''),' ',COALESCE(ad.country,'')),'')," &
                        "COALESCE(c.faxnumber,''),COALESCE(c.altphone,''),COALESCE(c.website,''),COALESCE(c.vatregistrationno,''),COALESCE(c.comments,''),COALESCE(c.status,''),COALESCE(c.emailaddress,''),COALESCE(c.primaryaddressid,0),COALESCE(c.primarycontactid,0),COALESCE(pg.groupname,'') FROM accounts c " &
                        "LEFT JOIN accounts pa ON c.parentaccountid = pa.rowid LEFT JOIN contacts cp ON c.primarycontactid = cp.rowid LEFT JOIN address ad ON c.primaryaddressid = ad.rowid LEFT JOIN picklistgroup pg ON c.picklistgroupid = pg.rowid WHERE c.rowid = " & isupplierid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtSupplierNo.Text = reader1(0)
                    txtSupplierName.Text = reader1(1)
                    txtMainPhone.Text = reader1(3)
                    txtContactPerson.Text = reader1(4)
                    txtFaxNo.Text = reader1(6)
                    txtAlternatePhone.Text = reader1(7)
                    txtWebsite.Text = reader1(8)
                    txtTIN.Text = reader1(9)
                    txtComments.Text = reader1(10)
                    cboStatus.Text = reader1(11)
                    txtEmailAddress.Text = reader1(12)
                    sfdeliveryaddressid = reader1(13)
                    sfcontactpersonid = reader1(14)
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
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#End Region

#End Region

    Private Sub tabAccounts_DrawItem(sender As Object, e As DrawItemEventArgs) Handles tabAccounts.DrawItem
        Try
            TabControlColor(tabAccounts, e)
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
                PrimaryForm.AccntsForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#Region "Customers Tab"

    Private Sub tabCustomersMain_DrawItem(sender As Object, e As DrawItemEventArgs) Handles tabCustomersMain.DrawItem
        Try
            TabControlColor(tabCustomersMain, e)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub txtCommentsA_Leave(sender As Object, e As EventArgs) Handles txtCommentsA.Leave
        Try
            txtCustomerName.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub tsRefreshA_Click(sender As Object, e As EventArgs) Handles tsRefreshA.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            tsrefreshperformclickA()
            myBalloon("Successfully Refreshed", "Refresh", lblsavemsgA, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msNewA_Click(sender As Object, e As EventArgs) Handles msNewA.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Accounts", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.AccntsForm = False
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
            cueA = "New"
            errProvider.Clear()
            clearCustomerInformation()
            dgCustomerOrders.Rows.Clear()
            dgCustomerOrderItems.Rows.Clear()
            enableGBA(fraud, legit, fraud)
            enableANDvisibleMSA(fraud, legit, legit)
            If dgCustomerList.Rows.Count <> 0 Then
                dgCustomerList.CurrentRow.Selected = False
            End If
            getAccountNo("Customer", Me)
            txtCustomerNo.Text = globalaccountno
            autocompleteParentCustomerA(cboParentCustomer)
            autopopulateParentCustomerA(cboParentCustomer)
            cfdeliveryaddressid = 0 : cfcontactpersonid = 0
            txtCustomerName.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msCancelA_Click(sender As Object, e As EventArgs) Handles msCancelA.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerList.Rows.Count <> 0 Then
                cueA = "Edit"
                errProvider.Clear()
                clearCustomerInformation()
                dgCustomerOrders.Rows.Clear()
                dgCustomerOrderItems.Rows.Clear()
                enableGBA(legit, legit, legit)
                enableANDvisibleMSA(legit, legit, fraud)
                dgCustomerList.CurrentRow.Selected = True
                displayCustomerInformation(CInt(dgCustomerList.CurrentRow.Cells("c_rowid").Value))
                displayCustomerOrders(CInt(dgCustomerList.CurrentRow.Cells("c_rowid").Value))
                autocompleteParentCustomerA(cboParentCustomer)
                autopopulateParentCustomerA(cboParentCustomer)
                autocompletePickingGroup(cboPickingGroup)
                autopopulatePickingGroup(cboPickingGroup)
                globalautocompleteBranchCodeName(cboBranchCodeNameInfo, Me)
                globalautopopulateBranchCodeName(cboBranchCodeNameInfo, Me)
                txtCustomerName.Focus()
            Else
                tsrefreshperformclickA()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbAutoAddA_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddA.MouseEnter
        Try
            pbAutoAddA.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddA_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddA.MouseLeave
        Try
            pbAutoAddA.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAutoAddA_Click(sender As Object, e As EventArgs) Handles pbAutoAddA.Click
        Try
            myBalloon("Automatic adding of pick list group.", "Auto-Add", pbAutoAddA, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgCustomerList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerList.Rows.Count <> 0 Then
                cueA = "Edit"
                errProvider.Clear()
                clearCustomerInformation()
                dgCustomerOrders.Rows.Clear()
                dgCustomerOrderItems.Rows.Clear()
                enableGBA(legit, legit, legit)
                enableANDvisibleMSA(legit, legit, fraud)
                displayCustomerInformation(CInt(dgCustomerList.CurrentRow.Cells("c_rowid").Value))
                displayCustomerOrders(CInt(dgCustomerList.CurrentRow.Cells("c_rowid").Value))
                autocompleteParentCustomerA(cboParentCustomer)
                autopopulateParentCustomerA(cboParentCustomer)
                autocompletePickingGroup(cboPickingGroup)
                autopopulatePickingGroup(cboPickingGroup)
                globalautocompleteBranchCodeName(cboBranchCodeNameInfo, Me)
                globalautopopulateBranchCodeName(cboBranchCodeNameInfo, Me)
                txtCustomerName.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCustomerList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgCustomerList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cueA = "Edit"
                    errProvider.Clear()
                    clearCustomerInformation()
                    dgCustomerOrders.Rows.Clear()
                    dgCustomerOrderItems.Rows.Clear()
                    enableGBA(legit, legit, legit)
                    enableANDvisibleMSA(legit, legit, fraud)
                    displayCustomerInformation(CInt(dgCustomerList.CurrentRow.Cells("c_rowid").Value))
                    displayCustomerOrders(CInt(dgCustomerList.CurrentRow.Cells("c_rowid").Value))
                    autocompleteParentCustomerA(cboParentCustomer)
                    autopopulateParentCustomerA(cboParentCustomer)
                    autocompletePickingGroup(cboPickingGroup)
                    autopopulatePickingGroup(cboPickingGroup)
                    globalautocompleteBranchCodeName(cboBranchCodeNameInfo, Me)
                    globalautopopulateBranchCodeName(cboBranchCodeNameInfo, Me)
                    txtCustomerName.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dtpFromSearch_ValueChanged(sender As Object, e As EventArgs) Handles dtpFromSearch.ValueChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerList.Rows.Count <> 0 Then
                displayCustomerOrders(CInt(dgCustomerList.CurrentRow.Cells("c_rowid").Value))
                dgCustomerOrderItems.Rows.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dtpToSearch_ValueChanged(sender As Object, e As EventArgs) Handles dtpToSearch.ValueChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerList.Rows.Count <> 0 Then
                displayCustomerOrders(CInt(dgCustomerList.CurrentRow.Cells("c_rowid").Value))
                dgCustomerOrderItems.Rows.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCustomerOrders_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomerOrders.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerOrders.Rows.Count <> 0 Then
                displayCustomerOrderItems(CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value))
                customerorderitemscomputations() : colorCoding()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCustomerOrders_KeyUp(sender As Object, e As KeyEventArgs) Handles dgCustomerOrders.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCustomerOrders.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    displayCustomerOrderItems(CInt(dgCustomerOrders.CurrentRow.Cells("co_rowid").Value))
                    customerorderitemscomputations() : colorCoding()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbEditDeliveryAddress_MouseEnter(sender As Object, e As EventArgs) Handles pbEditDeliveryAddress.MouseEnter
        Try
            pbEditDeliveryAddress.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbEditDeliveryAddress_MouseLeave(sender As Object, e As EventArgs) Handles pbEditDeliveryAddress.MouseLeave
        Try
            pbEditDeliveryAddress.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Sub pbEditDeliveryAddress_Click(sender As Object, e As EventArgs) Handles pbEditDeliveryAddress.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Accounts", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.AccntsForm = False
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
            If cueA = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            Dim addresslinkform As New AddressForm
            addresslinkform.afaddressid = cfdeliveryaddressid
            addresslinkform.ShowInTaskbar = False
            addresslinkform.ShowDialog()
            cfdeliveryaddressid = addresslinkform.afaddressid
            If cfdeliveryaddressid <> 0 Then
                getAddressName(cfdeliveryaddressid, Me)
                txtDeliveryAddressA.Text = globaladdressname
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbEditContactPersonA_MouseEnter(sender As Object, e As EventArgs) Handles pbEditContactPersonA.MouseEnter
        Try
            pbEditContactPersonA.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbEditContactPersonA_MouseLeave(sender As Object, e As EventArgs) Handles pbEditContactPersonA.MouseLeave
        Try
            pbEditContactPersonA.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Sub pbEditContactPersonA_Click(sender As Object, e As EventArgs) Handles pbEditContactPersonA.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Accounts", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.AccntsForm = False
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
            If cueA = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            Dim contactslinkform As New ContactPersonForm
            contactslinkform.cfcontactid = cfcontactpersonid
            contactslinkform.ShowInTaskbar = False
            contactslinkform.ShowDialog()
            cfcontactpersonid = contactslinkform.cfcontactid
            If cfcontactpersonid <> 0 Then
                getContactNameA(cfcontactpersonid, Me)
                txtContactPersonA.Text = globalcontactname
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

    Private Sub pbAddBranchCodeName_MouseLeave(sender As Object, e As EventArgs) Handles pbAddBranchCodeName.MouseLeave
        Try
            pbAddBranchCodeName.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddBranchCodeName_Click(sender As Object, e As EventArgs) Handles pbAddBranchCodeName.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Accounts", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.AccntsForm = False
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

    Private Async Sub msSaveA_Click(sender As Object, e As EventArgs) Handles msSaveA.Click
        Console.WriteLine(cboAgent.SelectedValue)
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Accounts", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.AccntsForm = False
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
            If cueA = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            If LTrim(txtCustomerName.Text) = "" Then
                errProvider.SetError(txtCustomerName, "Please enter the customer name.")
                txtCustomerName.Focus()
            ElseIf LTrim(cboStatusA.Text) = "" Then
                errProvider.SetError(cboStatusA, "Please choose the status of the customer.")
                cboStatusA.Focus()
            Else
                If MessageBox.Show("Would you like to save the changes in this page? ", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    getCustomerID(cboParentCustomer.Text, Me)
                    cfparentcustomerid = globalcustomerid
                    getBranchCodeIDB(cboBranchCodeNameInfo.Text, Me)
                    cfbranchid = globalbranchid
                    If LTrim(cboPickingGroup.Text) <> "" Then
                        getPickListGroupID(cboPickingGroup.Text, Me) : cfpicklistgroupid = globalpicklistgroupid
                        If cfpicklistgroupid = 0 Then
                            I_PickListGroup(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cboPickingGroup.Text, "Active", Me)
                            getPickListGroupID(cboPickingGroup.Text, Me) : cfpicklistgroupid = globalpicklistgroupid
                        End If
                    Else
                        cfpicklistgroupid = 0
                    End If
                    If cueA = "New" Then
                        getAccountNo("Customer", Me)
                        I_Accounts(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, If(cfcontactpersonid = 0, DBNull.Value, cfcontactpersonid), If(cfdeliveryaddressid = 0, DBNull.Value, cfdeliveryaddressid), If(cfparentcustomerid = 0, DBNull.Value, cfparentcustomerid), If(cfpicklistgroupid = 0, DBNull.Value, cfpicklistgroupid),
                                If(cfbranchid = 0, DBNull.Value, cfbranchid), globalaccountno, AccountType:="Customer", txtCustomerName.Text, txtCustomerName.Text, txtMainPhoneA.Text, txtAlternatePhoneA.Text, txtFaxNoA.Text, txtEmailAddressA.Text, txtTINA.Text, txtWebsiteA.Text, txtDeliveryHours.Text, txtCommentsA.Text, cboStatusA.Text, cboAgent.SelectedValue, Me)
                        If CInt(txtCustomerNo.Text) <> globalaccountno Then
                            MessageBox.Show("Please take note that the Customer No. will change from " & CInt(txtCustomerNo.Text) & " to " & globalaccountno & "." & vbNewLine & "Another user used the Customer No. " & CInt(txtCustomerNo.Text) & " for its new customer", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtCustomerNo.Text = globalaccountno
                        End If
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Save, Customer No. " & globalaccountno, "Save", lblsavemsgA, -15, -65)
                            tsrefreshperformclickA()
                        End If
                    ElseIf cueA = "Edit" Then
                        U_Accounts(CInt(dgCustomerList.CurrentRow.Cells("c_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(cfcontactpersonid = 0, DBNull.Value, cfcontactpersonid), If(cfdeliveryaddressid = 0, DBNull.Value, cfdeliveryaddressid), If(cfparentcustomerid = 0, DBNull.Value, cfparentcustomerid),
                                If(cfpicklistgroupid = 0, DBNull.Value, cfpicklistgroupid), If(cfbranchid = 0, DBNull.Value, cfbranchid), txtCustomerName.Text, txtMainPhoneA.Text, txtAlternatePhoneA.Text, txtFaxNoA.Text, txtEmailAddressA.Text, txtTINA.Text, txtWebsiteA.Text, txtDeliveryHours.Text, txtCommentsA.Text, cboStatusA.Text, cboAgent.SelectedValue, Me)
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Updated", "Update", lblsavemsgA, -15, -65)
                            tsrefreshperformclickA()
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

#End Region

#Region "Suppliers Tab"

    Private Sub tabMain_DrawItem(sender As Object, e As DrawItemEventArgs) Handles tabMain.DrawItem
        Try
            TabControlColor(tabMain, e)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub txtComments_Leave(sender As Object, e As EventArgs) Handles txtComments.Leave
        Try
            txtSupplierName.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub tsRefresh_Click(sender As Object, e As EventArgs) Handles tsRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            tsrefreshperformclickB()
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
            cueB = "New"
            errProvider.Clear()
            clearSupplierInformation()
            enableGB(fraud, legit)
            enableANDvisibleMS(fraud, legit, legit)
            If dgSuppliersList.Rows.Count <> 0 Then
                dgSuppliersList.CurrentRow.Selected = False
            End If
            getAccountNo("Supplier", Me)
            txtSupplierNo.Text = globalaccountno
            sfdeliveryaddressid = 0 : sfcontactpersonid = 0
            txtSupplierName.Focus()
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
            If dgSuppliersList.Rows.Count <> 0 Then
                cueB = "Edit"
                errProvider.Clear()
                clearSupplierInformation()
                enableGB(legit, legit)
                enableANDvisibleMS(legit, legit, fraud)
                dgSuppliersList.CurrentRow.Selected = True
                displaySupplierInformation(CInt(dgSuppliersList.CurrentRow.Cells("s_rowid").Value))
                txtSupplierName.Focus()
            Else
                tsrefreshperformclickB()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgSuppliersList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSuppliersList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgSuppliersList.Rows.Count <> 0 Then
                cueB = "Edit"
                errProvider.Clear()
                clearSupplierInformation()
                enableGB(legit, legit)
                enableANDvisibleMS(legit, legit, fraud)
                dgSuppliersList.CurrentRow.Selected = True
                displaySupplierInformation(CInt(dgSuppliersList.CurrentRow.Cells("s_rowid").Value))
                txtSupplierName.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgSuppliersList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgSuppliersList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgSuppliersList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cueB = "Edit"
                    errProvider.Clear()
                    clearSupplierInformation()
                    enableGB(legit, legit)
                    enableANDvisibleMS(legit, legit, fraud)
                    dgSuppliersList.CurrentRow.Selected = True
                    displaySupplierInformation(CInt(dgSuppliersList.CurrentRow.Cells("s_rowid").Value))
                    txtSupplierName.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbEditContactPerson_MouseEnter(sender As Object, e As EventArgs) Handles pbEditContactPerson.MouseEnter
        Try
            pbEditContactPerson.BackColor = Drawing.Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbEditContactPerson_MouseLeave(sender As Object, e As EventArgs) Handles pbEditContactPerson.MouseLeave
        Try
            pbEditContactPerson.BackColor = Drawing.Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Sub pbEditContactPerson_Click(sender As Object, e As EventArgs) Handles pbEditContactPerson.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Accounts", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.AccntsForm = False
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
            If cueB = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            Dim contactslinkform As New ContactPersonForm
            contactslinkform.cfcontactid = sfcontactpersonid
            contactslinkform.ShowInTaskbar = False
            contactslinkform.ShowDialog()
            sfcontactpersonid = contactslinkform.cfcontactid
            If sfcontactpersonid <> 0 Then
                getContactNameA(sfcontactpersonid, Me)
                txtContactPerson.Text = globalcontactname
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
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Accounts", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.AccntsForm = False
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
            If cueB = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            If LTrim(txtSupplierName.Text) = "" Then
                errProvider.SetError(txtSupplierName, "Please enter the supplier name.")
                txtSupplierName.Focus()
            ElseIf LTrim(cboStatus.Text) = "" Then
                errProvider.SetError(cboStatus, "Please choose the status of the supplier.")
                cboStatus.Focus()
            Else
                If MessageBox.Show("Would you like to save the changes on this page? ", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    If cueB = "New" Then
                        getAccountNo("Supplier", Me)
                        M_I_Accounts(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, If(sfcontactpersonid = 0, DBNull.Value, sfcontactpersonid), DBNull.Value, DBNull.Value,
                                 DBNull.Value, globalaccountno, "Supplier", txtSupplierName.Text, txtSupplierName.Text, txtMainPhone.Text, txtAlternatePhone.Text, txtFaxNo.Text, txtEmailAddress.Text, txtTIN.Text, txtWebsite.Text, txtComments.Text, cboStatus.Text, Me)
                        If CInt(txtSupplierNo.Text) <> globalaccountno Then
                            MessageBox.Show("Please take note that the supplier No. will change from " & CInt(txtSupplierNo.Text) & " to " & globalaccountno & "." & vbNewLine & "Another user used the Supplier No. " & CInt(txtSupplierNo.Text) & " for its new supplier", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtSupplierNo.Text = globalaccountno
                        End If
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Save, Supplier No. " & globalaccountno, "Save", lblsavemsg, -15, -65)
                            tsrefreshperformclickB()
                        End If
                    ElseIf cueB = "Edit" Then
                        M_U_Accounts(CInt(dgSuppliersList.CurrentRow.Cells("s_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(sfcontactpersonid = 0, DBNull.Value, sfcontactpersonid), DBNull.Value,
                                 DBNull.Value, DBNull.Value, txtSupplierName.Text, txtMainPhone.Text, txtAlternatePhone.Text, txtFaxNo.Text, txtEmailAddress.Text, txtTIN.Text, txtWebsite.Text, txtComments.Text, cboStatus.Text, Me)
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                            tsrefreshperformclickB()
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

#End Region

#Region "Search/Page Setup"

#Region "Customers"

    Private Sub txtSimpleSearchA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSimpleSearchA.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If txtSimpleSearchA.Text = "" Then
                    tsrefreshperformclickA()
                Else
                    clearcboSearchA()
                    clearRightPageA()
                    searchmodeA = "SimpleSearch"
                    simplesearchphraseA = txtSimpleSearchA.Text
                    spagenumA = neutralpage : numofpagesA = startingpage
                    displaySearchPhraseA(simplesearchphraseA, spagenumA)
                    pageSetup1A(simplesearchphraseA)
                    txtPageNoA.Text = "" & numofpagesA & " of " & validpagesA & " "
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboSearch1A_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearch1A.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If cboSearch1A.Text = "" Then
                cboSearch2A.Items.Clear() : cboSearch2A.AutoCompleteCustomSource.Clear()
            ElseIf cboSearch1A.Text = "City/Town" Then
                autocompleteCityTown(cboSearch2A)
                autopopulateCityTown(cboSearch2A)
            ElseIf cboSearch1A.Text = "ParentCustomer" Then
                autocompleteParentCustomerB(cboSearch2A)
                autopopulateParentCustomerB(cboSearch2A)
            ElseIf cboSearch1A.Text = "Province" Then
                autocompleteProvince(cboSearch2A)
                autopopulateProvince(cboSearch2A)
            End If
            cboSearch2A.Text = "" : cboSearch2A.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboSearch3A_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearch3A.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If cboSearch3A.Text = "" Then
                cboSearch4A.Items.Clear() : cboSearch4A.AutoCompleteCustomSource.Clear()
            ElseIf cboSearch3A.Text = "City/Town" Then
                autocompleteCityTown(cboSearch4A)
                autopopulateCityTown(cboSearch4A)
            ElseIf cboSearch3A.Text = "ParentCustomer" Then
                autocompleteParentCustomerB(cboSearch4A)
                autopopulateParentCustomerB(cboSearch4A)
            ElseIf cboSearch3A.Text = "Province" Then
                autocompleteProvince(cboSearch4A)
                autopopulateProvince(cboSearch4A)
            End If
            cboSearch4A.Text = "" : cboSearch4A.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboSearch2A_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSearch2A.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If cboSearch1A.Text = "" AndAlso cboSearch3A.Text = "" Then
                    tsrefreshperformclickA()
                ElseIf cboSearch2A.Text = "" AndAlso cboSearch4A.Text = "" Then
                    tsrefreshperformclickA()
                Else
                    txtSimpleSearchA.Text = ""
                    clearRightPageA()
                    searchmodeA = "CommonSearch"
                    If cboSearch1A.Text = "" Then
                        pagefilter1 = ""
                    Else
                        getCommonPhraseA(cboSearch1A, cboSearch2A.Text)
                        pagefilter1 = "" & commonphrase & ""
                    End If
                    If cboSearch3A.Text = "" Then
                        pagefilter2 = ""
                    Else
                        getCommonPhraseA(cboSearch3A, cboSearch4A.Text)
                        pagefilter2 = "" & commonphrase & ""
                    End If
                    If pagefilter1 = "" Then
                        pagefilter3A = pagefilter2
                    ElseIf pagefilter2 = "" Then
                        pagefilter3A = pagefilter1
                    Else
                        pagefilter3A = "" & pagefilter1 & " AND " & pagefilter2 & ""
                    End If
                    spagenumA = neutralpage : numofpagesA = startingpage
                    displayCommonPhraseA(pagefilter3A, spagenumA)
                    pageSetup2A(pagefilter3A)
                    txtPageNoA.Text = "" & numofpagesA & " of " & validpagesA & " "
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboSearch4A_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSearch4A.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If cboSearch1A.Text = "" AndAlso cboSearch3A.Text = "" Then
                    tsrefreshperformclickA()
                ElseIf cboSearch2A.Text = "" AndAlso cboSearch4A.Text = "" Then
                    tsrefreshperformclickA()
                Else
                    txtSimpleSearchA.Text = ""
                    clearRightPageA()
                    searchmodeA = "CommonSearch"
                    If cboSearch1A.Text = "" Then
                        pagefilter1 = ""
                    Else
                        getCommonPhraseA(cboSearch1A, cboSearch2A.Text)
                        pagefilter1 = "" & commonphrase & ""
                    End If
                    If cboSearch3A.Text = "" Then
                        pagefilter2 = ""
                    Else
                        getCommonPhraseA(cboSearch3A, cboSearch4A.Text)
                        pagefilter2 = "" & commonphrase & ""
                    End If
                    If pagefilter1 = "" Then
                        pagefilter3A = pagefilter2
                    ElseIf pagefilter2 = "" Then
                        pagefilter3A = pagefilter1
                    Else
                        pagefilter3A = "" & pagefilter1 & " AND " & pagefilter2 & ""
                    End If
                    spagenumA = neutralpage : numofpagesA = startingpage
                    displayCommonPhraseA(pagefilter3A, spagenumA)
                    pageSetup2A(pagefilter3A)
                    txtPageNoA.Text = "" & numofpagesA & " of " & validpagesA & " "
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdFirstA_Click(sender As Object, e As EventArgs) Handles cmdFirstA.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPageA()
            spagenumA = neutralpage
            numofpagesA = startingpage
            If searchmodeA = "Basic" Then
                displayCustomerList(spagenumA)
            ElseIf searchmodeA = "CommonSearch" Then
                displayCommonPhraseA(pagefilter3A, spagenumA)
            ElseIf searchmodeA = "SimpleSearch" Then
                displaySearchPhraseA(simplesearchphraseA, spagenumA)
            End If
            txtPageNoA.Text = "" & numofpagesA & " of " & validpagesA & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdPrevA_Click(sender As Object, e As EventArgs) Handles cmdPrevA.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPageA()
            spagenumA = spagenumA - pagedivisor
            numofpagesA = numofpagesA - 1
            If spagenumA < 0 Then
                If countpagenumA < pagedivisor Then
                    spagenumA = neutralpage
                Else
                    spagenumA = countpagenumA - pagedivisor
                End If
                numofpagesA = validpagesA
            End If
            If searchmodeA = "Basic" Then
                displayCustomerList(spagenumA)
            ElseIf searchmodeA = "CommonSearch" Then
                displayCommonPhraseA(pagefilter3A, spagenumA)
            ElseIf searchmodeA = "SimpleSearch" Then
                displaySearchPhraseA(simplesearchphraseA, spagenumA)
            End If
            txtPageNoA.Text = "" & numofpagesA & " of " & validpagesA & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdNextA_Click(sender As Object, e As EventArgs) Handles cmdNextA.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPageA()
            spagenumA = spagenumA + pagedivisor
            numofpagesA = numofpagesA + 1
            If numofpagesA > validpagesA Then
                spagenumA = neutralpage
                numofpagesA = startingpage
            End If
            If searchmodeA = "Basic" Then
                displayCustomerList(spagenumA)
            ElseIf searchmodeA = "CommonSearch" Then
                displayCommonPhraseA(pagefilter3A, spagenumA)
            ElseIf searchmodeA = "SimpleSearch" Then
                displaySearchPhraseA(simplesearchphraseA, spagenumA)
            End If
            txtPageNoA.Text = "" & numofpagesA & " of " & validpagesA & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdLastA_Click(sender As Object, e As EventArgs) Handles cmdLastA.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPageA()
            If countpagenumA < pagedivisor Then
                spagenumA = neutralpage
            Else
                spagenumA = countpagenumA - pagedivisor
            End If
            numofpagesA = validpagesA
            If searchmodeA = "Basic" Then
                displayCustomerList(spagenumA)
            ElseIf searchmodeA = "CommonSearch" Then
                displayCommonPhraseA(pagefilter3A, spagenumA)
            ElseIf searchmodeA = "SimpleSearch" Then
                displaySearchPhraseA(simplesearchphraseA, spagenumA)
            End If
            txtPageNoA.Text = "" & numofpagesA & " of " & validpagesA & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtPageA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPageA.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If IsNumeric(txtPageA.Text) Then
                    If CInt(txtPageA.Text) < 0 Then
                    ElseIf CInt(txtPageA.Text) = 0 Then
                    ElseIf CInt(txtPageA.Text) > validpagesA Then
                    Else
                        clearRightPageA()
                        If countpagenumA < pagedivisor Then
                            spagenumA = neutralpage
                        Else
                            pageequation1 = CInt(txtPageA.Text) * pagedivisor
                            pageequation2 = ((CInt(txtPageA.Text) / validpagesA) * countpagenumA)
                            If pageequation1 < pageequation2 Then
                                pageequation3 = ((CInt(txtPageA.Text) / validpagesA) * countpagenumA) - (pageequation2 - pageequation1)
                            Else
                                pageequation3 = (CInt(txtPageA.Text) / validpagesA) * countpagenumA
                            End If
                            spagenumA = pageequation3 - pagedivisor
                        End If
                        numofpagesA = CInt(txtPageA.Text)
                        If searchmodeA = "Basic" Then
                            displayCustomerList(spagenumA)
                        ElseIf searchmodeA = "CommonSearch" Then
                            displayCommonPhraseA(pagefilter3A, spagenumA)
                        ElseIf searchmodeA = "SimpleSearch" Then
                            displaySearchPhraseA(simplesearchphraseA, spagenumA)
                        End If
                        txtPageNoA.Text = "" & numofpagesA & " of " & validpagesA & " "
                        txtPageA.Text = ""
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

#Region "Suppliers"

    Private Sub txtSimpleSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSimpleSearch.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If txtSimpleSearch.Text = "" Then
                    tsrefreshperformclickB()
                Else
                    clearcboSearch()
                    clearRightPage()
                    searchmodeB = "SimpleSearch"
                    simplesearchphraseB = txtSimpleSearch.Text
                    spagenumB = neutralpage : numofpagesB = startingpage
                    displaySearchPhraseB(simplesearchphraseB, spagenumB)
                    pageSetup1B(simplesearchphraseB)
                    txtPageNo.Text = "" & numofpagesB & " of " & validpagesB & " "
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
            ElseIf cboSearch1.Text = "City/Town" Then
                autocompleteCityTown(cboSearch2)
                autopopulateCityTown(cboSearch2)
            ElseIf cboSearch1.Text = "Province" Then
                autocompleteProvince(cboSearch2)
                autopopulateProvince(cboSearch2)
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
            ElseIf cboSearch3.Text = "City/Town" Then
                autocompleteCityTown(cboSearch4)
                autopopulateCityTown(cboSearch4)
            ElseIf cboSearch3.Text = "Province" Then
                autocompleteProvince(cboSearch4)
                autopopulateProvince(cboSearch4)
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
                    tsrefreshperformclickB()
                ElseIf cboSearch2.Text = "" AndAlso cboSearch4.Text = "" Then
                    tsrefreshperformclickB()
                Else
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmodeB = "CommonSearch"
                    If cboSearch1.Text = "" Then
                        pagefilter1 = ""
                    Else
                        getCommonPhraseB(cboSearch1, cboSearch2.Text)
                        pagefilter1 = "" & commonphrase & ""
                    End If
                    If cboSearch3.Text = "" Then
                        pagefilter2 = ""
                    Else
                        getCommonPhraseB(cboSearch3, cboSearch4.Text)
                        pagefilter2 = "" & commonphrase & ""
                    End If
                    If pagefilter1 = "" Then
                        pagefilter3B = pagefilter2
                    ElseIf pagefilter2 = "" Then
                        pagefilter3B = pagefilter1
                    Else
                        pagefilter3B = "" & pagefilter1 & " AND " & pagefilter2 & ""
                    End If
                    spagenumB = neutralpage : numofpagesB = startingpage
                    displayCommonPhraseB(pagefilter3B, spagenumB)
                    pageSetup2B(pagefilter3B)
                    txtPageNo.Text = "" & numofpagesB & " of " & validpagesB & " "
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
                    tsrefreshperformclickB()
                ElseIf cboSearch2.Text = "" AndAlso cboSearch4.Text = "" Then
                    tsrefreshperformclickB()
                Else
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmodeB = "CommonSearch"
                    If cboSearch1.Text = "" Then
                        pagefilter1 = ""
                    Else
                        getCommonPhraseB(cboSearch1, cboSearch2.Text)
                        pagefilter1 = "" & commonphrase & ""
                    End If
                    If cboSearch3.Text = "" Then
                        pagefilter2 = ""
                    Else
                        getCommonPhraseB(cboSearch3, cboSearch4.Text)
                        pagefilter2 = "" & commonphrase & ""
                    End If
                    If pagefilter1 = "" Then
                        pagefilter3B = pagefilter2
                    ElseIf pagefilter2 = "" Then
                        pagefilter3B = pagefilter1
                    Else
                        pagefilter3B = "" & pagefilter1 & " AND " & pagefilter2 & ""
                    End If
                    spagenumB = neutralpage : numofpagesB = startingpage
                    displayCommonPhraseB(pagefilter3B, spagenumB)
                    pageSetup2B(pagefilter3B)
                    txtPageNo.Text = "" & numofpagesB & " of " & validpagesB & " "
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
            spagenumB = neutralpage
            numofpagesB = startingpage
            If searchmodeB = "Basic" Then
                displaySupplierList(spagenumB)
            ElseIf searchmodeB = "CommonSearch" Then
                displayCommonPhraseB(pagefilter3B, spagenumB)
            ElseIf searchmodeB = "SimpleSearch" Then
                displaySearchPhraseB(simplesearchphraseB, spagenumB)
            End If
            txtPageNo.Text = "" & numofpagesB & " of " & validpagesB & " "
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
            spagenumB = spagenumB - pagedivisor
            numofpagesB = numofpagesB - 1
            If spagenumB < 0 Then
                If countpagenumB < pagedivisor Then
                    spagenumB = neutralpage
                Else
                    spagenumB = countpagenumB - pagedivisor
                End If
                numofpagesB = validpagesB
            End If
            If searchmodeB = "Basic" Then
                displaySupplierList(spagenumB)
            ElseIf searchmodeB = "CommonSearch" Then
                displayCommonPhraseB(pagefilter3B, spagenumB)
            ElseIf searchmodeB = "SimpleSearch" Then
                displaySearchPhraseB(simplesearchphraseB, spagenumB)
            End If
            txtPageNo.Text = "" & numofpagesB & " of " & validpagesB & " "
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
            spagenumB = spagenumB + pagedivisor
            numofpagesB = numofpagesB + 1
            If numofpagesB > validpagesB Then
                spagenumB = neutralpage
                numofpagesB = startingpage
            End If
            If searchmodeB = "Basic" Then
                displaySupplierList(spagenumB)
            ElseIf searchmodeB = "CommonSearch" Then
                displayCommonPhraseB(pagefilter3B, spagenumB)
            ElseIf searchmodeB = "SimpleSearch" Then
                displaySearchPhraseB(simplesearchphraseB, spagenumB)
            End If
            txtPageNo.Text = "" & numofpagesB & " of " & validpagesB & " "
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
            If countpagenumB < pagedivisor Then
                spagenumB = neutralpage
            Else
                spagenumB = countpagenumB - pagedivisor
            End If
            numofpagesB = validpagesB
            If searchmodeB = "Basic" Then
                displaySupplierList(spagenumB)
            ElseIf searchmodeB = "CommonSearch" Then
                displayCommonPhraseB(pagefilter3B, spagenumB)
            ElseIf searchmodeB = "SimpleSearch" Then
                displaySearchPhraseB(simplesearchphraseB, spagenumB)
            End If
            txtPageNo.Text = "" & numofpagesB & " of " & validpagesB & " "
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
                    ElseIf CInt(txtPage.Text) > validpagesB Then
                    Else
                        clearRightPage()
                        If countpagenumB < pagedivisor Then
                            spagenumB = neutralpage
                        Else
                            pageequation1 = CInt(txtPage.Text) * pagedivisor
                            pageequation2 = ((CInt(txtPage.Text) / validpagesB) * countpagenumB)
                            If pageequation1 < pageequation2 Then
                                pageequation3 = ((CInt(txtPage.Text) / validpagesB) * countpagenumB) - (pageequation2 - pageequation1)
                            Else
                                pageequation3 = (CInt(txtPage.Text) / validpagesB) * countpagenumB
                            End If
                            spagenumB = pageequation3 - pagedivisor
                        End If
                        numofpagesB = CInt(txtPage.Text)
                        If searchmodeB = "Basic" Then
                            displaySupplierList(spagenumB)
                        ElseIf searchmodeB = "CommonSearch" Then
                            displayCommonPhraseB(pagefilter3B, spagenumB)
                        ElseIf searchmodeB = "SimpleSearch" Then
                            displaySearchPhraseB(simplesearchphraseB, spagenumB)
                        End If
                        txtPageNo.Text = "" & numofpagesB & " of " & validpagesB & " "
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

#End Region

#Region "Datagrid Errors"

    Private Sub dgCustomerList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCustomerList.DataError
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
                dgCustomerList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCustomerOrders_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCustomerOrders.DataError
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
                dgCustomerOrders.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCustomerOrderItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
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

    Private Sub dgSupplierList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgSuppliersList.DataError
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
                dgSuppliersList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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