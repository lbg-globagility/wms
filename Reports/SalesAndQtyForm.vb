Imports MySql.Data.MySqlClient
Imports WarehouseManagementSystem.Core.Enums

Public Class SalesAndQtyForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim printdataset As New DataSetA.SetEDataTable
    Dim printdatatable As New DataTable
    Dim sqtydatefrom As New DateTimePicker
    Dim sqtydateto As New DateTimePicker
    Dim sqlquery As String
    Dim sqtymonths As String
    Dim stproductimage As Object
    Dim sqtymonthsinayear As Integer = 12
    Dim sqtyminimumyear As Integer = 1900
    Dim sqtymaximumyear As Integer = 9000
    Dim sqtyplusmonth, sqtymonthorder As Integer
    Dim sqtyfirstdayoftheyear, sqtyperiodFrom, sqtymonthstart As Date
    Dim sqtyconditionstringA, sqtyconditionstringB, sqtyconditionstringC As String
    Dim itemcount, rowscount, sqtybrandid, sqtycategoryid, sqtytotalqtydelivered As Integer

    Private Sub SalesAndQtyForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#Region "Functions"

    Sub callAutoComplete()
        globalautocompleteBrandName(cboBrandName, "", Me)
        globalautocompleteCategory(cboCategory, "", Me)
    End Sub

    Sub callAutoPopulate()
        globalautopopulateBrandName(cboBrandName, "", Me)
        globalautopopulateCategory(cboCategory, "", Me)
    End Sub

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            cboBrandName.Text = ""
            cboCategory.Text = ""
            txtYear.Text = ""
            cboBrandName.SelectedItem = Nothing
            cboCategory.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Printing"

    Sub printSalesAndQtyReport(ByVal iconditionstring As String)
        Try
            sqtyplusmonth = 0 : sqtymonths = "" : stproductimage = Nothing
            For i = 0 To sqtymonthsinayear - 1
                sqtyfirstdayoftheyear = "01-Jan-" & txtYear.Text & ""
                sqtyperiodFrom = sqtyfirstdayoftheyear.ToShortDateString
                sqtymonthstart = Format(DateSerial(sqtyperiodFrom.Year + 0, sqtyperiodFrom.Month + sqtyplusmonth, sqtyperiodFrom.Day + 0))
                sqtydatefrom.Value = sqtymonthstart
                sqtymonths = MonthName(sqtydatefrom.Value.Month)
                getMonthOrder(sqtymonths)
                Dim DaysInMonth As Integer = Date.DaysInMonth(sqtymonthstart.Year, sqtymonthstart.Month)
                Dim LastDayInMonthDate As Date = New Date(sqtymonthstart.Year, sqtymonthstart.Month, DaysInMonth)
                sqtydateto.Value = LastDayInMonthDate
                If conn.State = ConnectionState.Closed Then conn.Open()
                Dim sql1 As String = "SELECT oi.rowid,oi.orderid,COALESCE(b.brandname,''),COALESCE(ct.categoryname,''),COALESCE(oi.srp,0.0) FROM orderitems oi LEFT JOIN orders o ON oi.orderid = o.rowid " &
                            "LEFT JOIN productcolorsizes pcs ON oi.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid " &
                            "LEFT JOIN brands b ON p.brandid = b.rowid LEFT JOIN categories ct ON p.categoryid = ct.rowid WHERE oi.organizationid = " & Z_OrganizationID & $" AND o.ordertype = '{OrderType.CO.ToString()}' " &
                            "AND o.`status` = 'Delivery' AND " & iconditionstring & " (o.orderdate >= '" & sqtydatefrom.Value.Year & "-" & sqtydatefrom.Value.Month & "-" & sqtydatefrom.Value.Day & "' " &
                            "AND o.orderdate <= '" & sqtydateto.Value.Year & "-" & sqtydateto.Value.Month & "-" & sqtydateto.Value.Day & "') ORDER BY b.brandname,ct.categoryname "
                Dim cmd1 As New MySqlCommand(sql1, conn)
                Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
                While reader1.Read()
                    If reader1.HasRows Then
                        getPickListOrderID(CInt(reader1(1)), CInt(reader1(0)))
                        If sqtytotalqtydelivered > 0 Then
                            printdataset.AddSetERow(CStr(reader1(2)), CStr(reader1(3)), "" & sqtymonths & "" & vbNewLine & "Qty.               Sales", "", "", "", "", "", sqtytotalqtydelivered, sqtytotalqtydelivered * CDec(reader1(4)), sqtymonthorder, 0.0, 0, 0.0, 0.0, stproductimage)
                        End If
                    End If
                End While
                reader1.Close()
                sqtyplusmonth = sqtyplusmonth + 1
            Next
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getPickListOrderID(ByVal iorderid As Integer, ByVal iorderitemid As Integer)
        Try
            sqtytotalqtydelivered = 0
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(plo.rowid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.orderitemid = " & iorderitemid & " AND plo.orderid = " & iorderid & " AND (plo.`status` != 'Inactive' AND plo.`status` != 'Cancelled') ")
            If dtGid.Rows.Count <> 0 Then
                getTotalQtyDelivered(CInt(dtGid.Rows(0)(0)))
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getTotalQtyDelivered(ByVal ipicklistorderid As Integer)
        Try
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pli.qtydelivered)) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & ipicklistorderid & " AND (pli.`status` != 'Inactive' AND pli.`status` != 'Cancelled') ")
            If dtGtq.Rows.Count <> 0 Then
                sqtytotalqtydelivered = dtGtq.Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getMonthOrder(ByVal imonth As String)
        Try
            If imonth = "January" Then
                sqtymonthorder = 1
            ElseIf imonth = "February" Then
                sqtymonthorder = 2
            ElseIf imonth = "March" Then
                sqtymonthorder = 3
            ElseIf imonth = "April" Then
                sqtymonthorder = 4
            ElseIf imonth = "May" Then
                sqtymonthorder = 5
            ElseIf imonth = "June" Then
                sqtymonthorder = 6
            ElseIf imonth = "July" Then
                sqtymonthorder = 7
            ElseIf imonth = "August" Then
                sqtymonthorder = 8
            ElseIf imonth = "September" Then
                sqtymonthorder = 9
            ElseIf imonth = "October" Then
                sqtymonthorder = 10
            ElseIf imonth = "November" Then
                sqtymonthorder = 11
            ElseIf imonth = "December" Then
                sqtymonthorder = 12
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

#End Region

#End Region

    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If MessageBox.Show("Are you sure you wanted to close this form?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                PrimaryForm.SlsQtyForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboBrandName_TextChanged(sender As Object, e As EventArgs) Handles cboBrandName.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub cboBrandName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBrandName.SelectedIndexChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub cboCategory_TextChanged(sender As Object, e As EventArgs) Handles cboCategory.TextChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        Try
            errProvider.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Sales And Qty", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.SlsQtyForm = False
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
                errProvider.SetError(txtYear, "Please enter the year for the Sales and Qty Report.")
                Exit Try
            Else
                If IsNumeric(txtYear.Text) Then
                    If CInt(txtYear.Text) < sqtyminimumyear Then
                        errProvider.SetError(txtYear, "The year you entered is less than the minimum year allowed.")
                        Exit Try
                    ElseIf CInt(txtYear.Text) > sqtymaximumyear Then
                        errProvider.SetError(txtYear, "The year you entered is greater than the maximum year allowed.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtYear, "Please use numbers for the year of Sales and Qty Report.")
                    Exit Try
                End If
            End If
            If LTrim(cboBrandName.Text) <> "" Then
                getBrandID(cboBrandName.Text, Me) : sqtybrandid = globalbrandid
                If sqtybrandid = 0 Then
                    errProvider.SetError(cboBrandName, "System cannot find the brand name or you may leave it blank.")
                    Exit Try
                End If
            End If
            If LTrim(cboCategory.Text) <> "" Then
                getCategoryID(cboCategory.Text, "", Me) : sqtycategoryid = globalcategoryid
                If sqtycategoryid = 0 Then
                    errProvider.SetError(cboCategory, "System cannot find the category or you may leave it blank.")
                    Exit Try
                End If
            End If
            If MessageBox.Show("Would you like to print this Sales And Qty Report?", "Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If sqtybrandid <> 0 Then
                    sqtyconditionstringA = "p.brandid = " & sqtybrandid & ""
                Else
                    sqtyconditionstringA = ""
                End If
                If sqtycategoryid <> 0 Then
                    sqtyconditionstringB = "p.categoryid = " & sqtycategoryid & ""
                Else
                    sqtyconditionstringB = ""
                End If
                If sqtyconditionstringA = "" AndAlso sqtyconditionstringB = "" Then
                    sqtyconditionstringC = ""
                ElseIf sqtyconditionstringA = "" Then
                    sqtyconditionstringC = "" & sqtyconditionstringB & " AND "
                ElseIf sqtyconditionstringB = "" Then
                    sqtyconditionstringC = "" & sqtyconditionstringA & " AND "
                Else
                    sqtyconditionstringC = "" & sqtyconditionstringA & " AND " & sqtyconditionstringB & " AND "
                End If
                printSalesAndQtyReport(sqtyconditionstringC)
                Dim printreport As New SalesAndQtyPrint
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