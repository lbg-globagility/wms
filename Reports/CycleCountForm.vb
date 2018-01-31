Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Linq
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Public Class CycleCountForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim printdataset As New DataSetA.SetDDataTable
    Dim printdatatable As New DataTable
    Dim sqlquery As String
    Dim cue, searchmode As String
    Dim itemno, rowscount As Integer
    Dim simplesearchphrase, commonphrase As String
    Dim ccvariancecylecount1, ccvariancecylecount2 As Decimal
    Dim ccvariancecylecount1string, ccvariancecylecount2string As String
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal
    Dim ccproductcolorsizesid, cccontactid, cccountedbya, cccountedbyb, cccyclecountitemscount As Integer
    Dim spagenum, countpagenum, numofpages, validpages, ccipagenum, ccicountpagenum, ccinumofpages, ccivalidpages As Integer
    Private Sub CycleCountForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            displayCycleCountList(spagenum)
            pageSetup()
            txtPageNo.Text = "" & numofpages & " of " & validpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub CycleCountForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
        globalautocompleteContactName(cboCountedBy, "Picker", Me)
    End Sub
    Sub callAutoPopulate()
        autopopulatecboSearch()
        autopopulateCountedBy()
        globalautopopulateContactName(cboCountedBy, "Picker", Me)
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            cue = ""
            searchmode = "Basic"
            spagenum = neutralpage : numofpages = startingpage
            clearSearchItems()
            clearCycleCountInformation()
            clearCycleCountItems()
            dgCycleCountItems.Rows.Clear()
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
            cue = ""
            clearCycleCountInformation()
            clearCycleCountItems()
            dgCycleCountItems.Rows.Clear()
            enableGB(legit, fraud)
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
    Sub clearCycleCountInformation()
        Try
            txtCycleCountNo.Text = ""
            txtCycleCountDate.Text = ""
            txtCountBy.Text = ""
            txtBrandName.Text = ""
            txtComments.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearCycleCountItems()
        Try
            txtPageNoCCI.Text = ""
            cboCountedBy.Text = ""
            chkAllCycle1.Checked = fraud
            chkAllCycle2.Checked = fraud
            cboCountedBy.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean)
        Try
            gbSearch.Enabled = enable1
            gbCycleCountList.Enabled = enable1
            gbCycleCountInformation.Enabled = enable2
            gbCycleCountItems.Enabled = enable2
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub enableANDvisibleMS(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean)
        Try
            msNew.Enabled = enable1
            msSave.Enabled = enable2
            msPrint.Enabled = enable3
            msReports.Enabled = enable3
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
            callAutoComplete()
            callAutoPopulate()
            displayCycleCountList(spagenum)
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(cc.rowid),0) FROM cyclecount cc WHERE cc.organizationid = " & Z_OrganizationID & " ")
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
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(cc.rowid),0) FROM cyclecount cc WHERE cc.organizationid = " & Z_OrganizationID & " AND (cc.cyclecountno LIKE ""%" & esearchstring & "%"" OR cc.cyclecountby LIKE ""%" & esearchstring & "%"") ")
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
    Sub pageSetup2()
        Try
            getCountPageNum2()
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
    Sub getCountPageNum2()
        Try
            countpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(cc.rowid),0) FROM cyclecount cc WHERE cc.organizationid = " & Z_OrganizationID & " " & _
                            "AND (cc.created >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' " & _
                            "AND cc.created <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) ")
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
    Sub pageSetup3(ByVal icommonstring As String)
        Try
            getCountPageNum3(icommonstring)
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
    Sub getCountPageNum3(ByVal ecommonstring As String)
        Try
            countpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(cc.rowid),0) FROM cyclecount cc WHERE cc.organizationid = " & Z_OrganizationID & " " & _
                            "AND (cc.created >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' " & _
                            "AND cc.created <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) AND " & ecommonstring & " ")
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
            If icommonbox.Text = "BrandName" Then
                commonphrase = "b.brandname = """ & icommonstring & """"
            ElseIf icommonbox.Text = "Combination" Then
                getProductColorSizesIDB(icommonstring, Me)
                ccproductcolorsizesid = globalproductcolorsizesid
                commonphrase = "cci.productcolorsizesid = " & ccproductcolorsizesid & ""
            ElseIf icommonbox.Text = "CountedBy" Then
                getContactID(icommonstring, "Picker", Me)
                cccontactid = globalcontactid
                commonphrase = "cci.cyclecount1contactid = " & cccontactid & " OR cci.cyclecount2contactid = " & cccontactid & " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub pageSetupCCI(ByVal icyclecountid As Integer)
        Try
            getCountPageNumCCI(icyclecountid)
            If ccicountpagenum < pagedivisor Then
                ccivalidpages = startingpage
            Else
                additionalpage = ccicountpagenum / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    ccivalidpages = ccicountpagenum / pagedivisor
                Else
                    ccivalidpages = ccicountpagenum / pagedivisor
                    ccivalidpages = ccivalidpages + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub getCountPageNumCCI(ByVal ecyclecountid As Integer)
        Try
            ccicountpagenum = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(cci.rowid),0) FROM cyclecountitems cci WHERE cci.organizationid = " & Z_OrganizationID & " AND cci.cyclecountid = " & ecyclecountid & " ")
            If dtCid.Rows.Count <> 0 Then
                ccicountpagenum = dtCid.Rows(0)(0)
            Else
                ccicountpagenum = 0
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
    Sub autocompleteBrandName(ByVal icombobox As ComboBox)
        Try
            Dim brandname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(b.brandname,'') AS 'brandname' FROM cyclecountitems cci LEFT JOIN productcolorsizes pcs ON cci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " & _
                            "LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN brands b ON p.brandid = b.rowid WHERE cci.organizationid = " & Z_OrganizationID & " GROUP BY b.brandname ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                brandname.Add(ds.Tables(0).Rows(i)("brandname").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = brandname
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autocompleteByCombination(ByVal icombobox As ComboBox)
        Try
            Dim productcombination As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(p.productcode,''),' / ',COALESCE(c.colorname,''),' / ',COALESCE(pcs.size,''),' / ',COALESCE(pcs.seasoncode,'')),'') AS 'productcombination' FROM cyclecountitems cci " & _
                                "LEFT JOIN productcolorsizes pcs ON cci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid " & _
                                "LEFT JOIN colors c ON pc.colorid = c.rowid WHERE pcs.organizationid = " & Z_OrganizationID & " AND pcs.status = 'Active' ORDER BY p.productcode,c.colorname ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                productcombination.Add(ds.Tables(0).Rows(i)("productcombination").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = productcombination
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
            cboSearch1.Items.Add("BrandName")
            cboSearch1.Items.Add("Combination")
            cboSearch1.Items.Add("CountedBy")
            cboSearch1.Items.Add("")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autopopulateBrandName(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(b.brandname,'') AS 'brandname' FROM cyclecountitems cci LEFT JOIN productcolorsizes pcs ON cci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " & _
                            "LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN brands b ON p.brandid = b.rowid WHERE cci.organizationid = " & Z_OrganizationID & " GROUP BY b.brandname ORDER BY b.brandname "
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
    Sub autopopulateByCombination(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(p.productcode,''),' / ',COALESCE(c.colorname,''),' / ',COALESCE(pcs.size,''),' / ',COALESCE(pcs.seasoncode,'')),'') AS 'productcombination' FROM cyclecountitems cci " & _
                                "LEFT JOIN productcolorsizes pcs ON cci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid " & _
                                "LEFT JOIN colors c ON pc.colorid = c.rowid WHERE pcs.organizationid = " & Z_OrganizationID & " AND pcs.status = 'Active' ORDER BY p.productcode,c.colorname "
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
    Sub autopopulateCountedBy()
        Try
            cci_countedbya.Items.Clear()
            cci_countedbyb.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'') AS 'firstname' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.`type` = 'Picker' GROUP BY c.rowid ORDER BY c.firstname "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                cci_countedbya.Items.Add(reader1(0).ToString())
                cci_countedbyb.Items.Add(reader1(0).ToString())
            End While
            cci_countedbya.Items.Add("")
            cci_countedbyb.Items.Add("")
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
    Sub displayCycleCountList(ByVal istartpage As Integer)
        Try
            dgCycleCountList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT cc.rowid,COALESCE(cc.cyclecountno,''),DATE_FORMAT(cc.created,'%d-%b-%Y'),COALESCE(cc.cyclecountby,'') FROM cyclecount cc " & _
                        "WHERE cc.organizationid = " & Z_OrganizationID & " ORDER BY cc.created DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCycleCountList.Rows.Add()
                    dgCycleCountList.Item(cc_rowid.Index, n).Value = reader1(0)
                    dgCycleCountList.Item(cc_ccno.Index, n).Value = reader1(1)
                    dgCycleCountList.Item(cc_ccdate.Index, n).Value = reader1(2)
                    dgCycleCountList.Item(cc_countby.Index, n).Value = reader1(3)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCycleCountList.Columns("cc_ccno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountList.Columns("cc_ccdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountList.Columns("cc_countby").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCycleCountList.Rows.Count <> 0 Then
                dgCycleCountList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displaySearchPhrase(ByVal isearchphrase As String, ByVal istartpage As Integer)
        Try
            dgCycleCountList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT cc.rowid,COALESCE(cc.cyclecountno,''),DATE_FORMAT(cc.created,'%d-%b-%Y'),COALESCE(cc.cyclecountby,'') FROM cyclecount cc " & _
                        "WHERE cc.organizationid = " & Z_OrganizationID & " AND (cc.cyclecountno LIKE ""%" & isearchphrase & "%"" OR cc.cyclecountby LIKE ""%" & isearchphrase & "%"") " & _
                        "ORDER BY cc.created DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCycleCountList.Rows.Add()
                    dgCycleCountList.Item(cc_rowid.Index, n).Value = reader1(0)
                    dgCycleCountList.Item(cc_ccno.Index, n).Value = reader1(1)
                    dgCycleCountList.Item(cc_ccdate.Index, n).Value = reader1(2)
                    dgCycleCountList.Item(cc_countby.Index, n).Value = reader1(3)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCycleCountList.Columns("cc_ccno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountList.Columns("cc_ccdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountList.Columns("cc_countby").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCycleCountList.Rows.Count <> 0 Then
                dgCycleCountList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayDateSearch(ByVal istartpage As Integer)
        Try
            dgCycleCountList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT cc.rowid,COALESCE(cc.cyclecountno,''),DATE_FORMAT(cc.created,'%d-%b-%Y'),COALESCE(cc.cyclecountby,'') FROM cyclecount cc " & _
                        "WHERE cc.organizationid = " & Z_OrganizationID & " AND (cc.created >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' " & _
                        "AND cc.created <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) " & _
                        "GROUP BY cc.rowid ORDER BY cc.created DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCycleCountList.Rows.Add()
                    dgCycleCountList.Item(cc_rowid.Index, n).Value = reader1(0)
                    dgCycleCountList.Item(cc_ccno.Index, n).Value = reader1(1)
                    dgCycleCountList.Item(cc_ccdate.Index, n).Value = reader1(2)
                    dgCycleCountList.Item(cc_countby.Index, n).Value = reader1(3)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCycleCountList.Columns("cc_ccno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountList.Columns("cc_ccdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountList.Columns("cc_countby").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCycleCountList.Rows.Count <> 0 Then
                dgCycleCountList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayCommonPhrase(ByVal icommonphrase As String, ByVal istartpage As Integer)
        Try
            dgCycleCountList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT cc.rowid,COALESCE(cc.cyclecountno,''),DATE_FORMAT(cc.created,'%d-%b-%Y'),COALESCE(cc.cyclecountby,'') FROM cyclecount cc " & _
                        "WHERE cc.organizationid = " & Z_OrganizationID & " AND (cc.created >= '" & dtpFromSearch.Value.Year & "-" & dtpFromSearch.Value.Month & "-" & dtpFromSearch.Value.Day & "' " & _
                        "AND cc.created <= '" & dtpToSearch.Value.Year & "-" & dtpToSearch.Value.Month & "-" & dtpToSearch.Value.Day & "' ) AND " & icommonphrase & " " & _
                        "GROUP BY cc.rowid ORDER BY cc.created DESC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgCycleCountList.Rows.Add()
                    dgCycleCountList.Item(cc_rowid.Index, n).Value = reader1(0)
                    dgCycleCountList.Item(cc_ccno.Index, n).Value = reader1(1)
                    dgCycleCountList.Item(cc_ccdate.Index, n).Value = reader1(2)
                    dgCycleCountList.Item(cc_countby.Index, n).Value = reader1(3)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCycleCountList.Columns("cc_ccno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountList.Columns("cc_ccdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountList.Columns("cc_countby").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCycleCountList.Rows.Count <> 0 Then
                dgCycleCountList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayCycleCountInformation(ByVal icyclecountid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(cc.cyclecountno,''),DATE_FORMAT(cc.created,'%d-%b-%Y'),COALESCE(cc.cyclecountby,''),COALESCE(b.brandname,''),COALESCE(cc.comments,'') " & _
                        "FROM cyclecount cc LEFT JOIN brands b ON cc.brandid = b.rowid WHERE cc.rowid = " & icyclecountid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtCycleCountNo.Text = CStr(reader1(0))
                    txtCycleCountDate.Text = CStr(reader1(1))
                    txtCountBy.Text = CStr(reader1(2))
                    txtBrandName.Text = CStr(reader1(3))
                    txtComments.Text = CStr(reader1(4))
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayCycleCountItems(ByVal icyclecountid As Integer, ByVal istartpage As Integer)
        Try
            dgCycleCountItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT cci.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,'')," & _
                            "COALESCE(CONCAT(COALESCE(cci.rackno,''),' / ',COALESCE(cci.columnno,''),' / ',COALESCE(cci.shelfno,'')),''),COALESCE(cci.cyclecount1qty,''),COALESCE(cci.cyclecount2qty,'')," & _
                            "COALESCE(CONCAT(COALESCE(c1.firstname,''),' ',COALESCE(c1.middlename,''),' ',COALESCE(c1.lastname,''),' ',COALESCE(c1.suffix,''),' - ',COALESCE(c1.contactno,'')),'')," & _
                            "COALESCE(CONCAT(COALESCE(c2.firstname,''),' ',COALESCE(c2.middlename,''),' ',COALESCE(c2.lastname,''),' ',COALESCE(c2.suffix,''),' - ',COALESCE(c2.contactno,'')),'')," & _
                            "COALESCE(cci.remarks,'') FROM cyclecountitems cci LEFT JOIN productcolorsizes pcs ON cci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid " & _
                            "LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN contacts c1 ON cci.cyclecount1contactid = c1.rowid " & _
                            "LEFT JOIN contacts c2 ON cci.cyclecount2contactid = c2.rowid LEFT JOIN brands b ON p.brandid = b.rowid LEFT JOIN productinventorylocation pil ON cci.productinventorylocationid = pil.rowid " & _
                            "LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid WHERE cci.cyclecountid = " & icyclecountid & " AND cci.organizationid = " & Z_OrganizationID & " " & _
                            "ORDER BY b.brandname ASC,rsc.pickorderno ASC,p.productcode,c.colorname,pcs.size,pcs.seasoncode LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer
            If istartpage = 0 Then
                seqno = 1
            Else
                seqno = istartpage + 1
            End If
            While reader1.Read()
                If reader1.HasRows Then
                    dgCycleCountItems.Rows.Add()
                    dgCycleCountItems.Item(cci_seqno.Index, n).Value = seqno
                    dgCycleCountItems.Item(cci_rowid.Index, n).Value = reader1(0)
                    dgCycleCountItems.Item(cci_colorvalue.Index, n).Value = reader1(1)
                    dgCycleCountItems.Item(cci_productcode.Index, n).Value = reader1(2)
                    dgCycleCountItems.Item(cci_colorname.Index, n).Value = reader1(3)
                    dgCycleCountItems.Item(cci_color.Index, n).Value = ""
                    dgCycleCountItems.Item(cci_size.Index, n).Value = reader1(4)
                    dgCycleCountItems.Item(cci_seasoncode.Index, n).Value = reader1(5)
                    dgCycleCountItems.Item(cci_sku.Index, n).Value = reader1(6)
                    dgCycleCountItems.Item(cci_rackcolumnshelf.Index, n).Value = reader1(7)
                    dgCycleCountItems.Item(cci_qtya.Index, n).Value = reader1(8)
                    dgCycleCountItems.Item(cci_qtyb.Index, n).Value = reader1(9)
                    dgCycleCountItems.Item(cci_countedbya.Index, n).Value = reader1(10)
                    dgCycleCountItems.Item(cci_countedbyb.Index, n).Value = reader1(11)
                    dgCycleCountItems.Item(cci_remarks.Index, n).Value = reader1(12)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCycleCountItems.Columns("cci_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountItems.Columns("cci_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountItems.Columns("cci_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountItems.Columns("cci_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountItems.Columns("cci_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountItems.Columns("cci_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountItems.Columns("cci_rackcolumnshelf").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountItems.Columns("cci_qtya").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCycleCountItems.Columns("cci_qtyb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCycleCountItems.Rows.Count <> 0 Then
                dgCycleCountItems.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#End Region
#Region "Colors"
    Sub colorCoding()
        Try
            If dgCycleCountItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgCycleCountItems.Rows.Count - 1
                    If CStr(dgCycleCountItems.Rows(i).Cells("cci_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgCycleCountItems.Rows(i).Cells("cci_colorvalue").Value))
                        dgCycleCountItems.Rows(i).Cells("cci_color").Style.BackColor = readcolor
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
#Region "Printing"
    Sub getCycleCountItemsCount(ByVal icyclecountid As Integer)
        Try
            cccyclecountitemscount = 0
            Dim dtGc As New DataTable
            dtGc = getDataTableForSQL("SELECT COALESCE(COUNT(cci.rowid),0) FROM cyclecountitems cci WHERE cci.cyclecountid = " & icyclecountid & " AND cci.organizationid = " & Z_OrganizationID & " ")
            If dtGc.Rows.Count <> 0 Then
                cccyclecountitemscount = dtGc.Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub
    Sub printCycleCountItemsA(ByVal icyclecountid As Integer, ByVal ititleprint As String, ByVal icyclecountcontactid As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(b.brandname,''),COALESCE(cc.cyclecountno,''),DATE_FORMAT(cc.created,'%d-%b-%Y'),COALESCE(cc.cyclecountby,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,'')," & _
                            "COALESCE(cci.rackno,''),COALESCE(cci.columnno,''),COALESCE(cci.shelfno,''),COALESCE(CONCAT(COALESCE(cb.firstname,''),' ',COALESCE(cb.middlename,''),' ',COALESCE(cb.lastname,''),' ',COALESCE(cb.suffix,''),' - ',COALESCE(cb.contactno,'')),'')," & _
                            "COALESCE(CONCAT(COALESCE(cci.rackno,''),' ',COALESCE(cci.columnno,''),' ',COALESCE(cci.shelfno,'')),'') FROM cyclecountitems cci " & _
                            "LEFT JOIN cyclecount cc ON cci.cyclecountid = cc.rowid LEFT JOIN productcolorsizes pcs ON cci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN colors c ON pc.colorid = c.rowid " & _
                            "LEFT JOIN brands b ON p.brandid = b.rowid LEFT JOIN contacts cb ON " & icyclecountcontactid & " = cb.rowid LEFT JOIN productinventorylocation pil ON cci.productinventorylocationid = pil.rowid LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " & _
                            "WHERE cci.cyclecountid = " & icyclecountid & " AND cci.organizationid = " & Z_OrganizationID & " ORDER BY rsc.rackno,rsc.columnno,rsc.shelfno,p.productcode,c.colorname,pcs.size,pcs.seasoncode "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    printdataset.AddSetDRow(CStr(reader1(13)), ititleprint, "Cycle Count No.: " & CStr(reader1(1)) & "", "Cycle Count Date: " & CStr(reader1(2)) & "", "Count By: " & CStr(reader1(3)) & "", CStr(seqno), CStr(reader1(4)), CStr(reader1(5)), _
                                CStr(reader1(6)), CStr(reader1(7)), CStr(reader1(8)), CStr(reader1(9)), CStr(reader1(10)), CStr(reader1(11)), "", CStr(reader1(12)), "", "", "", "", "")
                    If PrimaryForm.MainLoadingBar.Value < cccyclecountitemscount Then
                        PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                    End If
                    seqno = seqno + 1
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub printCycleCountItemsB(ByVal icyclecountid As Integer, ByVal ititleprint As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(b.brandname,''),COALESCE(cc.cyclecountno,''),DATE_FORMAT(cc.created,'%d-%b-%Y'),COALESCE(cc.cyclecountby,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,'')," & _
                            "COALESCE(cci.rackno,''),COALESCE(cci.columnno,''),COALESCE(cci.shelfno,''),COALESCE(cci.originalqty,0),COALESCE(cci.cyclecount1qty,''),COALESCE(CONCAT(COALESCE(cb.firstname,''),' ',COALESCE(cb.middlename,''),' ',COALESCE(cb.lastname,''),' ',COALESCE(cb.suffix,''),' - ',COALESCE(cb.contactno,'')),'') " & _
                            "FROM cyclecountitems cci LEFT JOIN cyclecount cc ON cci.cyclecountid = cc.rowid LEFT JOIN productcolorsizes pcs ON cci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN colors c ON pc.colorid = c.rowid " & _
                            "LEFT JOIN brands b ON p.brandid = b.rowid LEFT JOIN contacts cb ON cci.cyclecount1contactid = cb.rowid LEFT JOIN productinventorylocation pil ON cci.productinventorylocationid = pil.rowid LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " & _
                            "WHERE cci.cyclecountid = " & icyclecountid & " AND cci.organizationid = " & Z_OrganizationID & " ORDER BY rsc.rackno,rsc.columnno,rsc.shelfno,p.productcode,c.colorname,pcs.size,pcs.seasoncode "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    If IsNumeric(reader1(13)) Then
                        ccvariancecylecount1 = (CInt(reader1(13)) - CInt(reader1(12))) / CInt(reader1(12)) * pagedivisor
                        ccvariancecylecount1string = "" & Format(ccvariancecylecount1, "#,##0.00") & "%"
                    Else
                        ccvariancecylecount1string = ""
                    End If
                    printdataset.AddSetDRow(CStr(reader1(0)), ititleprint, "Cycle Count No.: " & CStr(reader1(1)) & "", "Cycle Count Date: " & CStr(reader1(2)) & "", "Count By: " & CStr(reader1(3)) & "", CStr(seqno), CStr(reader1(4)), CStr(reader1(5)), CStr(reader1(6)), _
                                CStr(reader1(7)), CStr(reader1(8)), CStr(reader1(9)), CStr(reader1(10)), CStr(reader1(11)), Format(CInt(reader1(12)), "#,##0"), If(IsNumeric(reader1(13)), Format(CInt(reader1(13)), "#,##0"), ""), CStr(reader1(14)), ccvariancecylecount1string, "", "", "")
                    If PrimaryForm.MainLoadingBar.Value < cccyclecountitemscount Then
                        PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                    End If
                    seqno = seqno + 1
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub printCycleCountItemsC(ByVal icyclecountid As Integer, ByVal ititleprint As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(b.brandname,''),COALESCE(cc.cyclecountno,''),DATE_FORMAT(cc.created,'%d-%b-%Y'),COALESCE(cc.cyclecountby,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pcs.sku,'')," & _
                            "COALESCE(cci.rackno,''),COALESCE(cci.columnno,''),COALESCE(cci.shelfno,''),COALESCE(cci.originalqty,0),COALESCE(cci.cyclecount1qty,''),COALESCE(CONCAT(COALESCE(c1.firstname,''),' ',COALESCE(c1.middlename,''),' ',COALESCE(c1.lastname,''),' ',COALESCE(c1.suffix,''),' - ',COALESCE(c1.contactno,'')),'')," & _
                            "COALESCE(cci.cyclecount2qty,''),COALESCE(CONCAT(COALESCE(c2.firstname,''),' ',COALESCE(c2.middlename,''),' ',COALESCE(c2.lastname,''),' ',COALESCE(c2.suffix,''),' - ',COALESCE(c2.contactno,'')),'') FROM cyclecountitems cci LEFT JOIN cyclecount cc ON cci.cyclecountid = cc.rowid  " & _
                            "LEFT JOIN productcolorsizes pcs ON cci.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN colors c ON pc.colorid = c.rowid LEFT JOIN brands b ON p.brandid = b.rowid " & _
                            "LEFT JOIN contacts c1 ON cci.cyclecount1contactid = c1.rowid LEFT JOIN contacts c2 ON cci.cyclecount2contactid = c2.rowid LEFT JOIN productinventorylocation pil ON cci.productinventorylocationid = pil.rowid LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " & _
                            "WHERE cci.cyclecountid = " & icyclecountid & " AND cci.organizationid = " & Z_OrganizationID & " ORDER BY rsc.rackno,rsc.columnno,rsc.shelfno,p.productcode,c.colorname,pcs.size,pcs.seasoncode "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    If IsNumeric(reader1(13)) Then
                        ccvariancecylecount1 = (CInt(reader1(13)) - CInt(reader1(12))) / CInt(reader1(12)) * pagedivisor
                        ccvariancecylecount1string = "" & Format(ccvariancecylecount1, "#,##0.00") & "%"
                    Else
                        ccvariancecylecount1string = ""
                    End If
                    If IsNumeric(reader1(15)) Then
                        ccvariancecylecount2 = (CInt(reader1(15)) - CInt(reader1(12))) / CInt(reader1(12)) * pagedivisor
                        ccvariancecylecount2string = "" & Format(ccvariancecylecount2, "#,##0.00") & "%"
                    Else
                        ccvariancecylecount2string = ""
                    End If
                    printdataset.AddSetDRow(CStr(reader1(0)), ititleprint, "Cycle Count No.: " & CStr(reader1(1)) & "", "Cycle Count Date: " & CStr(reader1(2)) & "", "Count By: " & CStr(reader1(3)) & "", CStr(seqno), CStr(reader1(4)), CStr(reader1(5)), CStr(reader1(6)), _
                                CStr(reader1(7)), CStr(reader1(8)), CStr(reader1(9)), CStr(reader1(10)), CStr(reader1(11)), Format(CInt(reader1(12)), "#,##0"), If(IsNumeric(reader1(13)), Format(CInt(reader1(13)), "#,##0"), ""), CStr(reader1(14)), ccvariancecylecount1string, _
                                If(IsNumeric(reader1(15)), Format(CInt(reader1(15)), "#,##0"), ""), CStr(reader1(16)), ccvariancecylecount2string)
                    If PrimaryForm.MainLoadingBar.Value < cccyclecountitemscount Then
                        PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                    End If
                    seqno = seqno + 1
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
                PrimaryForm.CCountForm = False
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
    Private Sub pbAddCountedBy_MouseEnter(sender As Object, e As EventArgs) Handles pbAddCountedBy.MouseEnter
        Try
            pbAddCountedBy.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddCountedBy_MouseLeave(sender As Object, e As EventArgs) Handles pbAddCountedBy.MouseLeave
        Try
            pbAddCountedBy.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddCountedBy_Click(sender As Object, e As EventArgs) Handles pbAddCountedBy.Click
        Try
            Dim addpickerlinkform As New AddPickerForm
            addpickerlinkform.ShowInTaskbar = False
            addpickerlinkform.ShowDialog()
            If addpickerlinkform.addpickerformcue = legit Then
                Me.Cursor = Cursors.WaitCursor
                globalautocompleteContactName(cboCountedBy, "Picker", Me)
                globalautopopulateContactName(cboCountedBy, "Picker", Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub msNew_Click(sender As Object, e As EventArgs) Handles msNew.Click
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Cycle Count", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.CCountForm = False
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
            Dim addcyclecountlinkform As New AddCycleCountForm
            addcyclecountlinkform.ShowInTaskbar = False
            addcyclecountlinkform.ShowDialog()
            If addcyclecountlinkform.addcyclecountformcue = legit Then
                Me.Cursor = Cursors.WaitCursor
                tsrefreshperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgCycleCountList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCycleCountList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCycleCountList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearCycleCountInformation()
                clearCycleCountItems()
                dgCycleCountItems.Rows.Clear()
                enableGB(legit, legit)
                enableANDvisibleMS(legit, legit, legit)
                displayCycleCountInformation(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value))
                ccipagenum = neutralpage : ccinumofpages = startingpage
                displayCycleCountItems(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value), ccipagenum)
                pageSetupCCI(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value))
                txtPageNoCCI.Text = "" & ccinumofpages & " of " & ccivalidpages & " "
                colorCoding() : txtComments.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgCycleCountList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgCycleCountList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCycleCountList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearCycleCountInformation()
                    clearCycleCountItems()
                    dgCycleCountItems.Rows.Clear()
                    enableGB(legit, legit)
                    enableANDvisibleMS(legit, legit, legit)
                    displayCycleCountInformation(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value))
                    ccipagenum = neutralpage : ccinumofpages = startingpage
                    displayCycleCountItems(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value), ccipagenum)
                    pageSetupCCI(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value))
                    txtPageNoCCI.Text = "" & ccinumofpages & " of " & ccivalidpages & " "
                    colorCoding() : txtComments.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub chkAllCycle1_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllCycle1.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCycleCountItems.Rows.Count <> 0 Then
                If chkAllCycle1.Checked = legit Then
                    getContactID(cboCountedBy.Text, "Picker", Me)
                    cccontactid = globalcontactid
                    If cccontactid <> 0 Then
                        getContactNameB(cccontactid, Me)
                        For a = 0 To dgCycleCountItems.Rows.Count - 1
                            dgCycleCountItems.Rows(a).Cells("cci_countedbya").Value = globalcontactname
                        Next
                    Else
                        errProvider.SetError(cboCountedBy, "System cannot find the picker name, please choose among the given choices.")
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
    Private Sub chkAllCycle2_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllCycle2.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCycleCountItems.Rows.Count <> 0 Then
                If chkAllCycle2.Checked = legit Then
                    getContactID(cboCountedBy.Text, "Picker", Me)
                    cccontactid = globalcontactid
                    If cccontactid <> 0 Then
                        getContactNameB(cccontactid, Me)
                        For a = 0 To dgCycleCountItems.Rows.Count - 1
                            dgCycleCountItems.Rows(a).Cells("cci_countedbyb").Value = globalcontactname
                        Next
                    Else
                        errProvider.SetError(cboCountedBy, "System cannot find the picker name, please choose among the given choices.")
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
    Private Sub cmdFirstCCI_Click(sender As Object, e As EventArgs) Handles cmdFirstCCI.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            ccipagenum = neutralpage : ccinumofpages = startingpage
            displayCycleCountItems(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value), ccipagenum)
            colorCoding()
            txtPageNoCCI.Text = "" & ccinumofpages & " of " & ccivalidpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cmdPrevCCI_Click(sender As Object, e As EventArgs) Handles cmdPrevCCI.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            ccipagenum = ccipagenum - pagedivisor
            ccinumofpages = ccinumofpages - 1
            If ccipagenum < 0 Then
                If countpagenum < pagedivisor Then
                    ccipagenum = neutralpage
                Else
                    ccipagenum = countpagenum - pagedivisor
                End If
                ccinumofpages = ccivalidpages
            End If
            displayCycleCountItems(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value), ccipagenum)
            colorCoding()
            txtPageNoCCI.Text = "" & ccinumofpages & " of " & ccivalidpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cmdNextCCI_Click(sender As Object, e As EventArgs) Handles cmdNextCCI.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            ccipagenum = ccipagenum + pagedivisor
            ccinumofpages = ccinumofpages + 1
            If ccinumofpages > ccivalidpages Then
                ccipagenum = neutralpage
                ccinumofpages = startingpage
            End If
            displayCycleCountItems(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value), ccipagenum)
            colorCoding()
            txtPageNoCCI.Text = "" & ccinumofpages & " of " & ccivalidpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cmdLastCCI_Click(sender As Object, e As EventArgs) Handles cmdLastCCI.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If ccicountpagenum < pagedivisor Then
                ccipagenum = neutralpage
            Else
                ccipagenum = ccicountpagenum - pagedivisor
            End If
            ccinumofpages = ccivalidpages
            displayCycleCountItems(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value), ccipagenum)
            colorCoding()
            txtPageNoCCI.Text = "" & ccinumofpages & " of " & ccivalidpages & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            dgCycleCountItems.CommitEdit(legit) : dgCycleCountItems.ClearSelection() : dgCycleCountItems.CurrentCell = Nothing
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Cycle Count", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.CCountForm = False
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
            If dgCycleCountList.Rows.Count = 0 Then
                MessageBox.Show("There is no Cycle Count that needs to be updated.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                U_CycleCount(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtComments.Text, Me)
                If dgCycleCountItems.Rows.Count <> 0 Then
                    For a = 0 To dgCycleCountItems.Rows.Count - 1
                        If myModule.systemerrorfound = False Then
                            getContactID(dgCycleCountItems.Rows(a).Cells("cci_countedbya").Value, "Picker", Me)
                            cccountedbya = globalcontactid
                            getContactID(dgCycleCountItems.Rows(a).Cells("cci_countedbyb").Value, "Picker", Me)
                            cccountedbyb = globalcontactid
                            U_CycleCountItems(CInt(dgCycleCountItems.Rows(a).Cells("cci_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(cccountedbya = 0, DBNull.Value, cccountedbya), If(cccountedbyb = 0, DBNull.Value, cccountedbyb), _
                                    If(IsNumeric(dgCycleCountItems.Rows(a).Cells("cci_qtya").Value), CInt(dgCycleCountItems.Rows(a).Cells("cci_qtya").Value), DBNull.Value), If(IsNumeric(dgCycleCountItems.Rows(a).Cells("cci_qtyb").Value), CInt(dgCycleCountItems.Rows(a).Cells("cci_qtyb").Value), DBNull.Value), CStr(dgCycleCountItems.Rows(a).Cells("cci_remarks").Value), Me)
                        End If
                    Next
                End If
                If myModule.systemerrorfound = False Then
                    myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub msPrintCycle1_Click(sender As Object, e As EventArgs) Handles msPrintCycle1.Click
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Cycle Count", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.CCountForm = False
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
            If dgCycleCountList.Rows.Count = 0 Then
                MessageBox.Show("There is no Cycle Count that needs to be printed.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to print this cycle count?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getCycleCountItemsCount(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value))
                PrimaryForm.MainLoadingBar.Visible = legit
                PrimaryForm.MainLoadingBar.Maximum = cccyclecountitemscount
                printCycleCountItemsA(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value), "Print - Cycle Count 1", "cci.cyclecount1contactid")
                Dim printreport As New CycleCountPrint
                Dim openreportviewer As New ReportViewer
                openreportviewer.CrystalReportViewer.ReportSource = printreport
                printdatatable = printdataset
                printreport.SetDataSource(printdatatable)
                openreportviewer.Show()
                printdatatable.Dispose()
                printdatatable = Nothing
                printdataset.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
            PrimaryForm.MainLoadingBar.Visible = fraud
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub msPrintCycle2_Click(sender As Object, e As EventArgs) Handles msPrintCycle2.Click
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Cycle Count", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.CCountForm = False
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
            If dgCycleCountList.Rows.Count = 0 Then
                MessageBox.Show("There is no Cycle Count that needs to be printed.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to print this cycle count?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getCycleCountItemsCount(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value))
                PrimaryForm.MainLoadingBar.Visible = legit
                PrimaryForm.MainLoadingBar.Maximum = cccyclecountitemscount
                printCycleCountItemsA(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value), "Print - Cycle Count 2", "cci.cyclecount2contactid")
                Dim printreport As New CycleCountPrint
                Dim openreportviewer As New ReportViewer
                openreportviewer.CrystalReportViewer.ReportSource = printreport
                printdatatable = printdataset
                printreport.SetDataSource(printdatatable)
                openreportviewer.Show()
                printdatatable.Dispose()
                printdatatable = Nothing
                printdataset.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
            PrimaryForm.MainLoadingBar.Visible = fraud
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub msReportCycle1_Click(sender As Object, e As EventArgs) Handles msReportCycle1.Click
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Cycle Count", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.CCountForm = False
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
            If dgCycleCountList.Rows.Count = 0 Then
                MessageBox.Show("There is no Cycle Count that needs to be printed.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to print the report for Cycle Count 1?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getCycleCountItemsCount(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value))
                PrimaryForm.MainLoadingBar.Visible = legit
                PrimaryForm.MainLoadingBar.Maximum = cccyclecountitemscount
                printCycleCountItemsB(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value), "Cycle Count 1 Report")
                Dim printreport As New CycleCountReportA
                Dim openreportviewer As New ReportViewer
                openreportviewer.CrystalReportViewer.ReportSource = printreport
                printdatatable = printdataset
                printreport.SetDataSource(printdatatable)
                openreportviewer.Show()
                printdatatable.Dispose()
                printdatatable = Nothing
                printdataset.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
            PrimaryForm.MainLoadingBar.Visible = fraud
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub msReportCycle2_Click(sender As Object, e As EventArgs) Handles msReportCycle2.Click
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Cycle Count", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.CCountForm = False
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
            If dgCycleCountList.Rows.Count = 0 Then
                MessageBox.Show("There is no Cycle Count that needs to be printed.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If MessageBox.Show("Would you like to print the report for Cycle Count 2?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getCycleCountItemsCount(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value))
                PrimaryForm.MainLoadingBar.Visible = legit
                PrimaryForm.MainLoadingBar.Maximum = cccyclecountitemscount
                printCycleCountItemsC(CInt(dgCycleCountList.CurrentRow.Cells("cc_rowid").Value), "Cycle Count 2 Report")
                Dim printreport As New CycleCountReportB
                Dim openreportviewer As New ReportViewer
                openreportviewer.CrystalReportViewer.ReportSource = printreport
                printdatatable = printdataset
                printreport.SetDataSource(printdatatable)
                openreportviewer.Show()
                printdatatable.Dispose()
                printdatatable = Nothing
                printdataset.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
            PrimaryForm.MainLoadingBar.Visible = fraud
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
            ElseIf cboSearch1.Text = "BrandName" Then
                autocompleteBrandName(cboSearch2)
                autopopulateBrandName(cboSearch2)
            ElseIf cboSearch1.Text = "Combination" Then
                autocompleteByCombination(cboSearch2)
                autopopulateByCombination(cboSearch2)
            ElseIf cboSearch1.Text = "CountedBy" Then
                globalautocompleteContactName(cboSearch2, "Picker", Me)
                globalautopopulateContactName(cboSearch2, "Picker", Me)
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
                If cboSearch1.Text = "" Then
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmode = "DateSearch"
                    spagenum = neutralpage : numofpages = startingpage
                    displayDateSearch(spagenum)
                    pageSetup2()
                    txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                ElseIf cboSearch2.Text = "" Then
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmode = "DateSearch"
                    spagenum = neutralpage : numofpages = startingpage
                    displayDateSearch(spagenum)
                    pageSetup2()
                    txtPageNo.Text = "" & numofpages & " of " & validpages & " "
                Else
                    txtSimpleSearch.Text = ""
                    clearRightPage()
                    searchmode = "CommonSearch"
                    spagenum = neutralpage : numofpages = startingpage
                    getCommonPhrase(cboSearch1, cboSearch2.Text)
                    displayCommonPhrase(commonphrase, spagenum)
                    pageSetup3(commonphrase)
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
                displayCycleCountList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(commonphrase, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum)
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
                displayCycleCountList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(commonphrase, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum)
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
                displayCycleCountList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(commonphrase, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum)
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
                displayCycleCountList(spagenum)
            ElseIf searchmode = "CommonSearch" Then
                displayCommonPhrase(commonphrase, spagenum)
            ElseIf searchmode = "SimpleSearch" Then
                displaySearchPhrase(simplesearchphrase, spagenum)
            ElseIf searchmode = "DateSearch" Then
                displayDateSearch(spagenum)
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
                            displayCycleCountList(spagenum)
                        ElseIf searchmode = "CommonSearch" Then
                            displayCommonPhrase(commonphrase, spagenum)
                        ElseIf searchmode = "SimpleSearch" Then
                            displaySearchPhrase(simplesearchphrase, spagenum)
                        ElseIf searchmode = "DateSearch" Then
                            displayDateSearch(spagenum)
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
    Private Sub dgCycleCountItems_MouseUp(sender As Object, e As MouseEventArgs) Handles dgCycleCountItems.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgCycleCountItems.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgCycleCountItems.BeginEdit(True)
                Else
                    dgCycleCountItems.EndEdit()
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
    Private Sub dgCycleCountList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCycleCountList.DataError
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
                dgCycleCountList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgCycleCountItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCycleCountItems.DataError
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
                dgCycleCountItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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