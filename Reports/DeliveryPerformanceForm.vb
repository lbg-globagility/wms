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
Public Class DeliveryPerformanceForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim dpdatefrom As New DateTimePicker
    Dim dpdateto As New DateTimePicker
    Dim dpcanceldate As New DateTimePicker
    Dim dpdeliverydate As New DateTimePicker
    Dim printdataset As New DataSetA.SetDDataTable
    Dim printdatatable As New DataTable
    Dim sqlquery As String
    Dim dpmonthsinayear As Integer = 12
    Dim dpminimumyear As Integer = 1900
    Dim dpmaximumyear As Integer = 9000
    Dim dpplusmonth, dptotalontime, dptotallate As Integer
    Dim dpfirstdayofthemonth, dpperiodfrom, dpmonthstart As Date
    Private Sub DeliveryPerformanceForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoPopulate()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub callAutoPopulate()
        autopopulateMonths()
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            clearFilters()
            clearTotals()
            dgDeliveries.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearFilters()
        Try
            txtYear.Text = ""
            cboMonths.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearTotals()
        Try
            txtTotalDeliveries.Text = ""
            txtTotalOnTime.Text = ""
            txtOnTimePercentage.Text = ""
            txtTotalLate.Text = ""
            txtLatePercentage.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Computations"
    Sub deliveryperformancecomputations()
        Try
            dptotalontime = 0 : dptotallate = 0
            If dgDeliveries.Rows.Count <> 0 Then
                For i = 0 To dgDeliveries.Rows.Count - 1
                    If CStr(dgDeliveries.Rows(i).Cells("d_status").Value) = "On-Time" Then
                        dptotalontime = dptotalontime + startingpage
                    Else
                        dptotallate = dptotallate + startingpage
                    End If
                Next
            End If
            txtTotalDeliveries.Text = Format(Math.Round(dgDeliveries.Rows.Count, 0), "#,##0")
            txtTotalOnTime.Text = Format(Math.Round(dptotalontime, 0), "#,##0")
            txtTotalLate.Text = Format(Math.Round(dptotallate, 0), "#,##0")
            If dgDeliveries.Rows.Count <> 0 Then
                txtOnTimePercentage.Text = Format(Math.Round((dptotalontime / dgDeliveries.Rows.Count) * 100, 0), "#,##0")
                txtLatePercentage.Text = Format(Math.Round((dptotallate / dgDeliveries.Rows.Count) * 100, 0), "#,##0")
            Else
                txtOnTimePercentage.Text = ""
                txtLatePercentage.Text = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display"
#Region "AutoPopulate"
    Sub autopopulateMonths()
        Try
            cboMonths.Items.Clear()
            cboMonths.Items.Add("January")
            cboMonths.Items.Add("February")
            cboMonths.Items.Add("March")
            cboMonths.Items.Add("April")
            cboMonths.Items.Add("May")
            cboMonths.Items.Add("June")
            cboMonths.Items.Add("July")
            cboMonths.Items.Add("August")
            cboMonths.Items.Add("September")
            cboMonths.Items.Add("October")
            cboMonths.Items.Add("November")
            cboMonths.Items.Add("December")
            cboMonths.Items.Add("")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Datagrid"
    Sub displayDeliveryPerformance()
        Try
            dgDeliveries.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            'Dim sql1 As String = "SELECT lu.rowid,COALESCE(o.ordernumber,''),COALESCE(o.referencenumber,''),COALESCE(o.drnumber,''),COALESCE(lu.lineupno,''),COALESCE(DATE_FORMAT(o.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.datesubmitted,'%d-%b-%Y'),'')," & _
            '            "COALESCE(DATE_FORMAT(o.targetdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.enddate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(lu.lineupdate,'%d-%b-%Y'),''),COALESCE(DATEDIFF(lu.lineupdate,o.enddate),0),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'') " & _
            '            "FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN accounts cu ON o.accountid = cu.rowid WHERE lu.organizationid = " & Z_OrganizationID & " AND lu.`status` = 'Confirmed Delivery' AND (o.enddate >= '" & dpdatefrom.Value.Year & "-" & dpdatefrom.Value.Month & "-" & dpdatefrom.Value.Day & "' " & _
            '            "AND o.enddate <= '" & dpdateto.Value.Year & "-" & dpdateto.Value.Month & "-" & dpdateto.Value.Day & "') GROUP BY lu.rowid ORDER BY o.enddate ASC "
            Dim sql1 As String = "SELECT pa.rowid,COALESCE(o.ordernumber,''),COALESCE(o.referencenumber,''),COALESCE(o.drnumber,''),COALESCE(pa.packinglistno,''),COALESCE(DATE_FORMAT(o.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.datesubmitted,'%d-%b-%Y'),'')," & _
                        "COALESCE(DATE_FORMAT(o.targetdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.enddate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(pa.packinglistdate,'%d-%b-%Y'),''),COALESCE(DATEDIFF(pa.packinglistdate,o.enddate),0),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'') " & _
                        "FROM packinglist pa LEFT JOIN orders o ON pa.orderid = o.rowid LEFT JOIN accounts cu ON o.accountid = cu.rowid WHERE pa.organizationid = " & Z_OrganizationID & " AND pa.`status` = 'New' AND (o.enddate >= '" & dpdatefrom.Value.Year & "-" & dpdatefrom.Value.Month & "-" & dpdatefrom.Value.Day & "' " & _
                        "AND o.enddate <= '" & dpdateto.Value.Year & "-" & dpdateto.Value.Month & "-" & dpdateto.Value.Day & "') GROUP BY pa.rowid ORDER BY o.enddate ASC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgDeliveries.Rows.Add()
                    dgDeliveries.Item(d_seqno.Index, n).Value = seqno
                    dgDeliveries.Item(d_rowid.Index, n).Value = reader1(0)
                    dgDeliveries.Item(d_cono.Index, n).Value = reader1(1)
                    dgDeliveries.Item(d_pono.Index, n).Value = reader1(2)
                    dgDeliveries.Item(d_sidrno.Index, n).Value = reader1(3)
                    dgDeliveries.Item(d_lineupno.Index, n).Value = reader1(4)
                    dgDeliveries.Item(d_codate.Index, n).Value = reader1(5)
                    dgDeliveries.Item(d_datesubmitted.Index, n).Value = reader1(6)
                    dgDeliveries.Item(d_receiptdate.Index, n).Value = reader1(7)
                    dgDeliveries.Item(d_canceldate.Index, n).Value = reader1(8)
                    dgDeliveries.Item(d_deliverydate.Index, n).Value = reader1(9)
                    dpcanceldate.Value = reader1(8)
                    dpdeliverydate.Value = reader1(9)
                    If dpcanceldate.Value > dpdeliverydate.Value Then
                        dgDeliveries.Item(d_status.Index, n).Value = "On-Time"
                    ElseIf dpcanceldate.Value < dpdeliverydate.Value Then
                        If CInt(reader1(10)) = startingpage Then
                            dgDeliveries.Item(d_status.Index, n).Value = "" & CInt(reader1(10)) & " Day Late"
                        Else
                            dgDeliveries.Item(d_status.Index, n).Value = "" & CInt(reader1(10)) & " Days Late"
                        End If
                    ElseIf dpcanceldate.Value = dpdeliverydate.Value Then
                        dgDeliveries.Item(d_status.Index, n).Value = "On-Time"
                    End If
                    dgDeliveries.Item(d_customername.Index, n).Value = reader1(11)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgDeliveries.Columns("d_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDeliveries.Columns("d_cono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDeliveries.Columns("d_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDeliveries.Columns("d_sidrno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDeliveries.Columns("d_lineupno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDeliveries.Columns("d_codate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDeliveries.Columns("d_datesubmitted").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDeliveries.Columns("d_receiptdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDeliveries.Columns("d_canceldate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDeliveries.Columns("d_deliverydate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDeliveries.Columns("d_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgDeliveries.Rows.Count <> 0 Then
                dgDeliveries.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Printing"
    Sub printDeliveryPerformance()
        Try
            If dgDeliveries.Rows.Count <> 0 Then
                For a = 0 To dgDeliveries.Rows.Count - 1
                    printdataset.AddSetDRow(CStr(dgDeliveries.Rows(a).Cells("d_seqno").Value), CStr(dgDeliveries.Rows(a).Cells("d_cono").Value), CStr(dgDeliveries.Rows(a).Cells("d_pono").Value), CStr(dgDeliveries.Rows(a).Cells("d_sidrno").Value), CStr(dgDeliveries.Rows(a).Cells("d_lineupno").Value), CStr(dgDeliveries.Rows(a).Cells("d_codate").Value), _
                            CStr(dgDeliveries.Rows(a).Cells("d_datesubmitted").Value), CStr(dgDeliveries.Rows(a).Cells("d_receiptdate").Value), CStr(dgDeliveries.Rows(a).Cells("d_canceldate").Value), CStr(dgDeliveries.Rows(a).Cells("d_deliverydate").Value), CStr(dgDeliveries.Rows(a).Cells("d_status").Value), CStr(dgDeliveries.Rows(a).Cells("d_customername").Value), _
                            "Month: " & cboMonths.Text & "", "Year: " & txtYear.Text & "", "Total Deliveries: " & txtTotalDeliveries.Text & "", "Total On-Time: " & txtTotalOnTime.Text & "", "" & txtOnTimePercentage.Text & "%", "Total Late: " & txtTotalLate.Text & "", "" & txtLatePercentage.Text & "%", "", "")
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
    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If MessageBox.Show("Are you sure you wanted to close this form?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                PrimaryForm.DlvryPrfmForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtYear_TextChanged(sender As Object, e As EventArgs) Handles txtYear.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Delivery Performance", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.DlvryPrfmForm = False
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
            If LTrim(txtYear.Text) = "" Then
                errProvider.SetError(txtYear, "Please enter the year for the Delivery Performance Report.")
                dgDeliveries.Rows.Clear() : clearTotals()
                Exit Try
            Else
                If IsNumeric(txtYear.Text) Then
                    If CInt(txtYear.Text) < dpminimumyear Then
                        errProvider.SetError(txtYear, "The year you entered is less than the minimum year allowed.")
                        dgDeliveries.Rows.Clear() : clearTotals()
                        Exit Try
                    ElseIf CInt(txtYear.Text) > dpmaximumyear Then
                        errProvider.SetError(txtYear, "The year you entered is greater than the maximum year allowed.")
                        dgDeliveries.Rows.Clear() : clearTotals()
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtYear, "Please use numbers for the year of Delivery Performance Report.")
                    dgDeliveries.Rows.Clear() : clearTotals()
                    Exit Try
                End If
            End If
            dpplusmonth = 0
            If LTrim(cboMonths.Text) <> "" Then
                dpfirstdayofthemonth = "01-" & cboMonths.Text & "-" & txtYear.Text & ""
                dpperiodfrom = dpfirstdayofthemonth.ToShortDateString
                dpmonthstart = Format(DateSerial(dpperiodfrom.Year + 0, dpperiodfrom.Month + dpplusmonth, dpperiodfrom.Day + 0))
                dpdatefrom.Value = dpmonthstart
                Dim DaysInMonth As Integer = Date.DaysInMonth(dpmonthstart.Year, dpmonthstart.Month)
                Dim LastDayInMonthDate As Date = New Date(dpmonthstart.Year, dpmonthstart.Month, DaysInMonth)
                dpdateto.Value = LastDayInMonthDate
                displayDeliveryPerformance()
            Else
                Dim n As Integer = 0 : Dim seqno As Integer = 1
                dgDeliveries.Rows.Clear()
                For i = 0 To dpmonthsinayear - 1
                    dpfirstdayofthemonth = "01-Jan-" & txtYear.Text & ""
                    dpperiodfrom = dpfirstdayofthemonth.ToShortDateString
                    dpmonthstart = Format(DateSerial(dpperiodfrom.Year + 0, dpperiodfrom.Month + dpplusmonth, dpperiodfrom.Day + 0))
                    dpdatefrom.Value = dpmonthstart
                    Dim DaysInMonth As Integer = Date.DaysInMonth(dpmonthstart.Year, dpmonthstart.Month)
                    Dim LastDayInMonthDate As Date = New Date(dpmonthstart.Year, dpmonthstart.Month, DaysInMonth)
                    dpdateto.Value = LastDayInMonthDate
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    Dim sql1 As String = "SELECT lu.rowid,COALESCE(o.ordernumber,''),COALESCE(o.referencenumber,''),COALESCE(o.drnumber,''),COALESCE(lu.lineupno,''),COALESCE(DATE_FORMAT(o.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.datesubmitted,'%d-%b-%Y'),'')," & _
                                "COALESCE(DATE_FORMAT(o.targetdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.enddate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(lu.lineupdate,'%d-%b-%Y'),''),COALESCE(DATEDIFF(lu.lineupdate,o.enddate),0),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'') " & _
                                "FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN accounts cu ON o.accountid = cu.rowid WHERE lu.organizationid = " & Z_OrganizationID & " AND lu.`status` = 'Confirmed Delivery' AND (o.enddate >= '" & dpdatefrom.Value.Year & "-" & dpdatefrom.Value.Month & "-" & dpdatefrom.Value.Day & "' " & _
                                "AND o.enddate <= '" & dpdateto.Value.Year & "-" & dpdateto.Value.Month & "-" & dpdateto.Value.Day & "') GROUP BY lu.rowid ORDER BY o.enddate ASC "
                    Dim cmd1 As New MySqlCommand(sql1, conn)
                    Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
                    While reader1.Read()
                        If reader1.HasRows Then
                            dgDeliveries.Rows.Add()
                            dgDeliveries.Item(d_seqno.Index, n).Value = seqno
                            dgDeliveries.Item(d_rowid.Index, n).Value = reader1(0)
                            dgDeliveries.Item(d_cono.Index, n).Value = reader1(1)
                            dgDeliveries.Item(d_pono.Index, n).Value = reader1(2)
                            dgDeliveries.Item(d_sidrno.Index, n).Value = reader1(3)
                            dgDeliveries.Item(d_lineupno.Index, n).Value = reader1(4)
                            dgDeliveries.Item(d_codate.Index, n).Value = reader1(5)
                            dgDeliveries.Item(d_datesubmitted.Index, n).Value = reader1(6)
                            dgDeliveries.Item(d_receiptdate.Index, n).Value = reader1(7)
                            dgDeliveries.Item(d_canceldate.Index, n).Value = reader1(8)
                            dgDeliveries.Item(d_deliverydate.Index, n).Value = reader1(9)
                            dpcanceldate.Value = reader1(8)
                            dpdeliverydate.Value = reader1(9)
                            If dpcanceldate.Value > dpdeliverydate.Value Then
                                dgDeliveries.Item(d_status.Index, n).Value = "On-Time"
                            ElseIf dpcanceldate.Value < dpdeliverydate.Value Then
                                If CInt(reader1(10)) = startingpage Then
                                    dgDeliveries.Item(d_status.Index, n).Value = "" & CInt(reader1(10)) & " Day Late"
                                Else
                                    dgDeliveries.Item(d_status.Index, n).Value = "" & CInt(reader1(10)) & " Days Late"
                                End If
                            ElseIf dpcanceldate.Value = dpdeliverydate.Value Then
                                dgDeliveries.Item(d_status.Index, n).Value = "On-Time"
                            End If
                            dgDeliveries.Item(d_customername.Index, n).Value = reader1(11)
                            seqno = seqno + 1
                            n = n + 1
                        End If
                    End While
                    reader1.Close()
                    dpplusmonth = dpplusmonth + 1
                Next
                dgDeliveries.Columns("d_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgDeliveries.Columns("d_cono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgDeliveries.Columns("d_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgDeliveries.Columns("d_sidrno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgDeliveries.Columns("d_lineupno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgDeliveries.Columns("d_codate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgDeliveries.Columns("d_datesubmitted").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgDeliveries.Columns("d_receiptdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgDeliveries.Columns("d_canceldate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgDeliveries.Columns("d_deliverydate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgDeliveries.Columns("d_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                If dgDeliveries.Rows.Count <> 0 Then
                    dgDeliveries.CurrentRow.Selected = False
                End If
            End If
            deliveryperformancecomputations()
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
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Delivery Performance", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.DlvryPrfmForm = False
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
            If LTrim(txtYear.Text) = "" Then
                errProvider.SetError(txtYear, "Please enter the year for the Delivery Performance Report.")
                dgDeliveries.Rows.Clear() : clearTotals()
                Exit Try
            Else
                If IsNumeric(txtYear.Text) Then
                    If CInt(txtYear.Text) < dpminimumyear Then
                        errProvider.SetError(txtYear, "The year you entered is less than the minimum year allowed.")
                        dgDeliveries.Rows.Clear() : clearTotals()
                        Exit Try
                    ElseIf CInt(txtYear.Text) > dpmaximumyear Then
                        errProvider.SetError(txtYear, "The year you entered is greater than the maximum year allowed.")
                        dgDeliveries.Rows.Clear() : clearTotals()
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtYear, "Please use numbers for the year of Delivery Performance Report.")
                    dgDeliveries.Rows.Clear() : clearTotals()
                    Exit Try
                End If
            End If
            If MessageBox.Show("Would you like to print the Delivery Performance Report?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                dpplusmonth = 0
                If LTrim(cboMonths.Text) <> "" Then
                    dpfirstdayofthemonth = "01-" & cboMonths.Text & "-" & txtYear.Text & ""
                    dpperiodfrom = dpfirstdayofthemonth.ToShortDateString
                    dpmonthstart = Format(DateSerial(dpperiodfrom.Year + 0, dpperiodfrom.Month + dpplusmonth, dpperiodfrom.Day + 0))
                    dpdatefrom.Value = dpmonthstart
                    Dim DaysInMonth As Integer = Date.DaysInMonth(dpmonthstart.Year, dpmonthstart.Month)
                    Dim LastDayInMonthDate As Date = New Date(dpmonthstart.Year, dpmonthstart.Month, DaysInMonth)
                    dpdateto.Value = LastDayInMonthDate
                    displayDeliveryPerformance()
                Else
                    Dim n As Integer = 0 : Dim seqno As Integer = 1
                    dgDeliveries.Rows.Clear()
                    For i = 0 To dpmonthsinayear - 1
                        dpfirstdayofthemonth = "01-Jan-" & txtYear.Text & ""
                        dpperiodfrom = dpfirstdayofthemonth.ToShortDateString
                        dpmonthstart = Format(DateSerial(dpperiodfrom.Year + 0, dpperiodfrom.Month + dpplusmonth, dpperiodfrom.Day + 0))
                        dpdatefrom.Value = dpmonthstart
                        Dim DaysInMonth As Integer = Date.DaysInMonth(dpmonthstart.Year, dpmonthstart.Month)
                        Dim LastDayInMonthDate As Date = New Date(dpmonthstart.Year, dpmonthstart.Month, DaysInMonth)
                        dpdateto.Value = LastDayInMonthDate
                        If conn.State = ConnectionState.Closed Then conn.Open()
                        Dim sql1 As String = "SELECT lu.rowid,COALESCE(o.ordernumber,''),COALESCE(o.referencenumber,''),COALESCE(o.drnumber,''),COALESCE(lu.lineupno,''),COALESCE(DATE_FORMAT(o.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.datesubmitted,'%d-%b-%Y'),'')," & _
                                    "COALESCE(DATE_FORMAT(o.targetdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.enddate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(lu.lineupdate,'%d-%b-%Y'),''),COALESCE(DATEDIFF(lu.lineupdate,o.enddate),0),COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'') " & _
                                    "FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN accounts cu ON o.accountid = cu.rowid WHERE lu.organizationid = " & Z_OrganizationID & " AND lu.`status` = 'Confirmed Delivery' AND (o.enddate >= '" & dpdatefrom.Value.Year & "-" & dpdatefrom.Value.Month & "-" & dpdatefrom.Value.Day & "' " & _
                                    "AND o.enddate <= '" & dpdateto.Value.Year & "-" & dpdateto.Value.Month & "-" & dpdateto.Value.Day & "') GROUP BY lu.rowid ORDER BY o.enddate ASC "
                        Dim cmd1 As New MySqlCommand(sql1, conn)
                        Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
                        While reader1.Read()
                            If reader1.HasRows Then
                                dgDeliveries.Rows.Add()
                                dgDeliveries.Item(d_seqno.Index, n).Value = seqno
                                dgDeliveries.Item(d_rowid.Index, n).Value = reader1(0)
                                dgDeliveries.Item(d_cono.Index, n).Value = reader1(1)
                                dgDeliveries.Item(d_pono.Index, n).Value = reader1(2)
                                dgDeliveries.Item(d_sidrno.Index, n).Value = reader1(3)
                                dgDeliveries.Item(d_lineupno.Index, n).Value = reader1(4)
                                dgDeliveries.Item(d_codate.Index, n).Value = reader1(5)
                                dgDeliveries.Item(d_datesubmitted.Index, n).Value = reader1(6)
                                dgDeliveries.Item(d_receiptdate.Index, n).Value = reader1(7)
                                dgDeliveries.Item(d_canceldate.Index, n).Value = reader1(8)
                                dgDeliveries.Item(d_deliverydate.Index, n).Value = reader1(9)
                                dpcanceldate.Value = reader1(8)
                                dpdeliverydate.Value = reader1(9)
                                If dpcanceldate.Value > dpdeliverydate.Value Then
                                    dgDeliveries.Item(d_status.Index, n).Value = "On-Time"
                                ElseIf dpcanceldate.Value < dpdeliverydate.Value Then
                                    If CInt(reader1(10)) = startingpage Then
                                        dgDeliveries.Item(d_status.Index, n).Value = "" & CInt(reader1(10)) & " Day Late"
                                    Else
                                        dgDeliveries.Item(d_status.Index, n).Value = "" & CInt(reader1(10)) & " Days Late"
                                    End If
                                ElseIf dpcanceldate.Value = dpdeliverydate.Value Then
                                    dgDeliveries.Item(d_status.Index, n).Value = "On-Time"
                                End If
                                dgDeliveries.Item(d_customername.Index, n).Value = reader1(11)
                                seqno = seqno + 1
                                n = n + 1
                            End If
                        End While
                        reader1.Close()
                        dpplusmonth = dpplusmonth + 1
                    Next
                    dgDeliveries.Columns("d_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgDeliveries.Columns("d_cono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgDeliveries.Columns("d_pono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgDeliveries.Columns("d_sidrno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgDeliveries.Columns("d_lineupno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgDeliveries.Columns("d_codate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgDeliveries.Columns("d_datesubmitted").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgDeliveries.Columns("d_receiptdate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgDeliveries.Columns("d_canceldate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgDeliveries.Columns("d_deliverydate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgDeliveries.Columns("d_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    If dgDeliveries.Rows.Count <> 0 Then
                        dgDeliveries.CurrentRow.Selected = False
                    End If
                End If
                deliveryperformancecomputations()
                printDeliveryPerformance()
                'Dim printreport As New DeliveryPerformancePrint
                Dim printreport As New DeliveryPerformanceRevPrint
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
        End Try
        Me.Cursor = Cursors.Default
    End Sub
End Class