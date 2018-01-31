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
Public Class PickListReportForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim printdatasetA As New DataSetA.SetFDataTable
    Dim printdatasetB As New DataSetA.SetBDataTable
    Dim printdatatableA As New DataTable
    Dim printdatatableB As New DataTable
    Dim sqlquery As String
    Dim plrproductcode As String
    Dim plrproductimage As Object
    Private Sub PickListReportForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            autopopulateFilterBy(cboFilterBy)
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
            clearFilters()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearFilters()
        Try
            dtpCustomerOrderDate.Value = Now.Date
            cboCustomerName.Text = ""
            cboCustomerName.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Printing"
    Sub printPickListReportOutright(ByVal icondition As String, ByVal iorderdate As String)
        Try
            plrproductcode = ""
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT * FROM vw_picklistreport WHERE organizationid = " & Z_OrganizationID & " AND itemtype = 'BI' " & icondition & " AND (bistatus != 'Inactive' AND bistatus != 'Cancelled') AND orderdate = '" & iorderdate & "' ORDER BY productcode,colorname,pono ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            cmd1.CommandTimeout = commantimeoutlimit
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If plrproductcode <> "" Then
                    If plrproductcode <> CStr(reader1(24)) Then
                        plrproductimage = reader1(18)
                        If IsDBNull(plrproductimage) Then
                            plrproductimage = Nothing
                        End If
                        plrproductcode = CStr(reader1(24))
                    Else
                        plrproductimage = Nothing
                    End If
                Else
                    plrproductimage = reader1(18)
                    If IsDBNull(plrproductimage) Then
                        plrproductimage = Nothing
                    End If
                    plrproductcode = CStr(reader1(24))
                End If
                'plrproductimage = reader1(18)
                'If IsDBNull(plrproductimage) Then
                '    plrproductimage = Nothing
                'End If
                If reader1.HasRows Then
                    printdatasetA.AddSetFRow(CStr(reader1(24)), CStr(reader1(9)), CStr(reader1(10)), CStr(reader1(25)), CStr(reader1(15)), "  " & CStr(reader1(6)) & "       " & CStr(reader1(8)) & "           " & CStr(reader1(7)) & "", Format(CDec(reader1(11)), "#,##0"), CStr(reader1(24)), "ENTRY DATE: " & CStr(reader1(0)) & "", CStr(reader1(1)), "RECEIPT DATE: " & CStr(reader1(2)) & "", "CANCEL DATE: " & CStr(reader1(3)) & "", "BUY COST: " & Format(CDec(reader1(4)), "#,##0.00") & "", "SRP: " & Format(CDec(reader1(5)), "#,##0.00") & "", "PPK SKU: " & CStr(reader1(17)) & "", "" & CStr(reader1(26)) & " - " & CStr(reader1(27)) & "", CInt(reader1(14)), plrproductimage)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub printPickListReportConsignor(ByVal icondition As String, ByVal iorderdate As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT * FROM vw_picklistreport WHERE organizationid = " & Z_OrganizationID & " AND itemtype = 'S' " & icondition & " AND (bistatus != 'Inactive' AND bistatus != 'Cancelled') AND orderdate = '" & iorderdate & "' ORDER BY productcode,colorname,pono ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            cmd1.CommandTimeout = commantimeoutlimit
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                'plrproductimage = reader1(18)
                'If IsDBNull(plrproductimage) Then
                '    plrproductimage = Nothing
                'End If
                plrproductimage = Nothing
                If reader1.HasRows Then
                    printdatasetA.AddSetFRow("" & CStr(reader1(9)) & " - " & CStr(reader1(12)) & "", "", "", CStr(reader1(10)), CStr(reader1(11)), "", "", CStr(reader1(9)), "ENTRY DATE: " & CStr(reader1(0)) & "", CStr(reader1(1)), "RECEIPT DATE: " & CStr(reader1(2)) & "", "CANCEL DATE: " & CStr(reader1(3)) & "", "P.O. No.: " & CStr(reader1(6)) & " ", "SRP: " & Format(CDec(reader1(5)), "#,##0.00") & "", "", "BRANCH NAME - CODE: " & CStr(reader1(7)) & " - " & CStr(reader1(8)) & "", CInt(reader1(14)), plrproductimage)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub printPickListReportOtherStore(ByVal icondition As String, ByVal iorderdate As String)
        Try
            plrproductcode = ""
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT * FROM vw_picklistreport WHERE organizationid = " & Z_OrganizationID & " AND itemtype = 'S' " & icondition & " AND (bistatus != 'Inactive' AND bistatus != 'Cancelled') AND orderdate = '" & iorderdate & "' ORDER BY productcode,colorname,pono ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            cmd1.CommandTimeout = commantimeoutlimit
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If plrproductcode <> "" Then
                    If plrproductcode <> CStr(reader1(24)) Then
                        plrproductimage = reader1(18)
                        If IsDBNull(plrproductimage) Then
                            plrproductimage = Nothing
                        End If
                        plrproductcode = CStr(reader1(24))
                    Else
                        plrproductimage = Nothing
                    End If
                Else
                    plrproductimage = reader1(18)
                    If IsDBNull(plrproductimage) Then
                        plrproductimage = Nothing
                    End If
                    plrproductcode = CStr(reader1(24))
                End If
                'plrproductimage = reader1(18)
                'If IsDBNull(plrproductimage) Then
                '    plrproductimage = Nothing
                'End If
                If reader1.HasRows Then
                    printdatasetA.AddSetFRow(CStr(reader1(24)), CStr(reader1(9)), CStr(reader1(10)), CStr(reader1(25)), CStr(reader1(15)), "  " & CStr(reader1(6)) & "       " & CStr(reader1(8)) & "           " & CStr(reader1(7)) & "", Format(CDec(reader1(11)), "#,##0"), CStr(reader1(24)), "ENTRY DATE: " & CStr(reader1(0)) & "", CStr(reader1(1)), "RECEIPT DATE: " & CStr(reader1(2)) & "", "CANCEL DATE: " & CStr(reader1(3)) & "", "", "SRP: " & Format(CDec(reader1(5)), "#,##0.00") & "", "PPK SKU: " & CStr(reader1(17)) & "", "" & CStr(reader1(26)) & " - " & CStr(reader1(27)) & "", CInt(reader1(14)), plrproductimage)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub printSKUsA(ByVal iorderdate As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pcs.productcolorid,COALESCE(pcs.sku,'') FROM productcolorsizes pcs WHERE pcs.organizationid = " & Z_OrganizationID & " AND pcs.sku IS NOT NULL AND pcs.sku != '' AND pcs.`status` = 'Active' GROUP BY pcs.rowid "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    printdatasetB.AddSetBRow(CStr(reader1(0)), CStr(reader1(1)), "", "", "", "")
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub printSKUsB(ByVal icondition As String, ByVal iorderdate As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT * FROM vw_picklistreport WHERE organizationid = " & Z_OrganizationID & " AND itemtype = 'S' " & icondition & " AND (bistatus != 'Inactive' AND bistatus != 'Cancelled') AND orderdate = '" & iorderdate & "' ORDER BY productcode,colorname ASC  "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    printdatasetB.AddSetBRow(CStr(reader1(9)), CStr(reader1(16)), "", "", "", "")
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
#Region "Display"
    Sub autocompleteParentAccount(ByVal icombobox As ComboBox)
        Try
            Dim parentaccount As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(pa.companyname,''),' - ',COALESCE(pa.accountno,'')),'') AS 'parentaccount' FROM accounts a LEFT JOIN accounts pa ON a.parentaccountid = pa.rowid " & _
                                "WHERE a.organizationid = " & Z_OrganizationID & " AND a.parentaccountid IS NOT NULL AND a.accounttype = 'Customer' GROUP BY a.parentaccountid ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                parentaccount.Add(ds.Tables(0).Rows(i)("parentaccount").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = parentaccount
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub autopopulateParentAccount(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(pa.companyname,''),' - ',COALESCE(pa.accountno,'')),'') AS 'parentaccount' FROM accounts a LEFT JOIN accounts pa ON a.parentaccountid = pa.rowid " & _
                            "WHERE a.organizationid = " & Z_OrganizationID & " AND a.parentaccountid IS NOT NULL AND a.accounttype = 'Customer' GROUP BY a.parentaccountid ORDER BY pa.companyname "
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
    Sub autopopulateFilterBy(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            icombobox.Items.Add("Customer Name")
            icombobox.Items.Add("Parent Customer")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#End Region
    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If MessageBox.Show("Are you sure you wanted to close this form?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                PrimaryForm.PckLstRForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboCustomerName_TextChanged(sender As Object, e As EventArgs) Handles cboCustomerName.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub cboCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomerName.SelectedIndexChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub cboFilterBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterBy.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cboFilterBy.Text = "" Then
                cboCustomerName.Items.Clear() : cboCustomerName.AutoCompleteCustomSource.Clear()
            ElseIf cboFilterBy.Text = "Customer Name" Then
                globalautocompleteAccountName(cboCustomerName, "Customer", "AND a.`status` = 'Active'", Me)
                globalautopopulateAccountName(cboCustomerName, "Customer", "AND a.`status` = 'Active'", Me)
            ElseIf cboFilterBy.Text = "Parent Customer" Then
                autocompleteParentAccount(cboCustomerName)
                autopopulateParentAccount(cboCustomerName)
            End If
            cboCustomerName.Text = "" : cboCustomerName.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            cmsOptions.Show(Cursor.Position)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cmsOutright_Click(sender As Object, e As EventArgs) Handles cmsOutright.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Pick List Report", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PckLstRForm = False
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
            If LTrim(cboFilterBy.Text) = "" Then
                errProvider.SetError(cboFilterBy, "Please choose what to filter.")
                Exit Try
            End If
            If LTrim(cboCustomerName.Text) <> "" Then
                getCustomerID(cboCustomerName.Text, Me)
                If globalcustomerid = 0 Then
                    errProvider.SetError(cboCustomerName, "System cannot find the customer name.")
                    Exit Try
                End If
            Else
                errProvider.SetError(cboCustomerName, "Please enter the customer name.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to print this Pick List Report in Outright Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If cboFilterBy.Text = "Customer Name" Then
                    printPickListReportOutright("AND accountid = " & globalcustomerid & "", Format(dtpCustomerOrderDate.Value, "MM/dd/yyyy"))
                ElseIf cboFilterBy.Text = "Parent Customer" Then
                    printPickListReportOutright("AND parentaccountid = " & globalcustomerid & "", Format(dtpCustomerOrderDate.Value, "MM/dd/yyyy"))
                End If
                printSKUsA(Format(dtpCustomerOrderDate.Value, "MM/dd/yyyy"))
                Dim printreport As New PickListReportPrint
                Dim openreportviewer As New ReportViewer
                openreportviewer.CrystalReportViewer.ReportSource = printreport
                printdatatableA = printdatasetA
                printdatatableB = printdatasetB
                printreport.SetDataSource(printdatatableA)
                printreport.Subreports.Item("SubReportA.rpt").SetDataSource(printdatatableB)
                openreportviewer.Show()
                printdatatableA.Dispose()
                printdatatableA = Nothing
                printdatatableB.Dispose()
                printdatatableB = Nothing
                printdatasetA.Clear()
                printdatasetB.Clear()
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
                getPositionView(globalpositionid, "Pick List Report", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PckLstRForm = False
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
            If LTrim(cboFilterBy.Text) = "" Then
                errProvider.SetError(cboFilterBy, "Please choose what to filter.")
                Exit Try
            End If
            If LTrim(cboCustomerName.Text) <> "" Then
                getCustomerID(cboCustomerName.Text, Me)
                If globalcustomerid = 0 Then
                    errProvider.SetError(cboCustomerName, "System cannot find the customer name.")
                    Exit Try
                End If
            Else
                errProvider.SetError(cboCustomerName, "Please enter the customer name.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to print this Pick List Report in Consignor Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If cboFilterBy.Text = "Customer Name" Then
                    printPickListReportConsignor("AND accountid = " & globalcustomerid & "", Format(dtpCustomerOrderDate.Value, "MM/dd/yyyy"))
                    printSKUsB("AND accountid = " & globalcustomerid & "", Format(dtpCustomerOrderDate.Value, "MM/dd/yyyy"))
                ElseIf cboFilterBy.Text = "Parent Customer" Then
                    printPickListReportConsignor("AND parentaccountid = " & globalcustomerid & "", Format(dtpCustomerOrderDate.Value, "MM/dd/yyyy"))
                    printSKUsB("AND parentaccountid = " & globalcustomerid & "", Format(dtpCustomerOrderDate.Value, "MM/dd/yyyy"))
                End If
                Dim printreport As New ConsignorPLReportPrint
                Dim openreportviewer As New ReportViewer
                openreportviewer.CrystalReportViewer.ReportSource = printreport
                printdatatableA = printdatasetA
                printdatatableB = printdatasetB
                printreport.SetDataSource(printdatatableA)
                printreport.Subreports.Item("SubReportA.rpt").SetDataSource(printdatatableB)
                openreportviewer.Show()
                printdatatableA.Dispose()
                printdatatableA = Nothing
                printdatatableB.Dispose()
                printdatatableB = Nothing
                printdatasetA.Clear()
                printdatasetB.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cmsOtherStore_Click(sender As Object, e As EventArgs) Handles cmsOtherStore.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Pick List Report", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PckLstRForm = False
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
            If LTrim(cboFilterBy.Text) = "" Then
                errProvider.SetError(cboFilterBy, "Please choose what to filter.")
                Exit Try
            End If
            If LTrim(cboCustomerName.Text) <> "" Then
                getCustomerID(cboCustomerName.Text, Me)
                If globalcustomerid = 0 Then
                    errProvider.SetError(cboCustomerName, "System cannot find the customer name.")
                    Exit Try
                End If
            Else
                errProvider.SetError(cboCustomerName, "Please enter the customer name.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to print this Pick List Report in Other Store Form?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If cboFilterBy.Text = "Customer Name" Then
                    printPickListReportOtherStore("AND accountid = " & globalcustomerid & "", Format(dtpCustomerOrderDate.Value, "MM/dd/yyyy"))
                ElseIf cboFilterBy.Text = "Parent Customer" Then
                    printPickListReportOtherStore("AND parentaccountid = " & globalcustomerid & "", Format(dtpCustomerOrderDate.Value, "MM/dd/yyyy"))
                End If
                printSKUsA(Format(dtpCustomerOrderDate.Value, "MM/dd/yyyy"))
                Dim printreport As New PickListReportPrint
                Dim openreportviewer As New ReportViewer
                openreportviewer.CrystalReportViewer.ReportSource = printreport
                printdatatableA = printdatasetA
                printdatatableB = printdatasetB
                printreport.SetDataSource(printdatatableA)
                printreport.Subreports.Item("SubReportA.rpt").SetDataSource(printdatatableB)
                openreportviewer.Show()
                printdatatableA.Dispose()
                printdatatableA = Nothing
                printdatatableB.Dispose()
                printdatatableB = Nothing
                printdatasetA.Clear()
                printdatasetB.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
End Class