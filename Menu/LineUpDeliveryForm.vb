Imports MySql.Data.MySqlClient
Imports WarehouseManagementSystem.Core.Entities
Imports WarehouseManagementSystem.Core.Interfaces

Public Class LineUpDeliveryForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim ludstartdate As Date
    Dim itemno, rowscount As Integer
    Dim luddisplaydays, ludlineupcartonsqty, luddeliverytruckshiftid As Integer
    Dim ludstringdate, ludstringday, ludcustomerorderslineup, ludbasisdate, ludselectedcell, ludselectedcolumn As String
    Private _systemOwner As SystemOwner

    Private Async Sub LineUpDeliveryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            dtpFromSearch.Value = Now.Date
            dtpToSearch.Value = Now.Date.AddDays(7)
            displayLineUpCalenderColumn()
            luddisplaydays = CInt(DateDiff(DateInterval.Day, dtpFromSearch.Value, dtpToSearch.Value))
            ludstartdate = dtpFromSearch.Value
            If luddisplaydays > 0 Or luddisplaydays = 0 Then
                luddisplaydays = luddisplaydays + 1
                displayLineUpCalenderRows(luddisplaydays)
                colorCoding()
            Else
                errProvider.SetError(dtpFromSearch, "Date From should not be greater than Date To.")
                dgLineUpCalendar.Rows.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LineUpDeliveryForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

#Region "Click"

    Sub tsrefreshperformclick()
        Try
            errProvider.Clear()
            dtpFromSearch.Value = Now.Date
            dtpToSearch.Value = Now.Date.AddDays(7)
            displayLineUpCalenderColumn()
            luddisplaydays = CInt(DateDiff(DateInterval.Day, dtpFromSearch.Value, dtpToSearch.Value))
            ludstartdate = dtpFromSearch.Value
            If luddisplaydays > 0 Or luddisplaydays = 0 Then
                luddisplaydays = luddisplaydays + 1
                displayLineUpCalenderRows(luddisplaydays)
                colorCoding()
            Else
                errProvider.SetError(dtpFromSearch, "Date From should not be greater than Date To.")
                dgLineUpCalendar.Rows.Clear()
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

    Sub displayLineUpCalenderColumn()
        Try
            dgLineUpCalendar.Columns.Clear()
            Dim hiddencol As New DataGridViewTextBoxColumn
            hiddencol.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            hiddencol.Width = 100
            hiddencol.Frozen = legit
            hiddencol.HeaderText = "BasisDate"
            hiddencol.Name = "lud_basisdate"
            hiddencol.Visible = fraud
            dgLineUpCalendar.Columns.Add(hiddencol)
            Dim startcol As New DataGridViewTextBoxColumn
            startcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            startcol.Width = 100
            startcol.Frozen = legit
            startcol.HeaderText = "Delivery Date"
            startcol.Name = "lud_date"
            dgLineUpCalendar.Columns.Add(startcol)
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = $"SELECT {If(IsThurston, "IFNULL(dt.truckname, '')", "COALESCE(CONCAT(COALESCE(dt.truckname,''),' - ',COALESCE(dt.truckno,''),' / ',COALESCE(s.shiftname,'')),'')")} " &
                        "FROM deliverytruckshifts dts LEFT JOIN deliverytrucks dt ON dts.deliverytruckid = dt.rowid LEFT JOIN shifts s ON dts.shiftid = s.rowid " &
                        "WHERE dts.organizationid = " & Z_OrganizationID & " AND dts.`status` = 'Active' ORDER BY dt.truckname,s.shiftname DESC "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    Dim col As New DataGridViewTextBoxColumn
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                    col.Width = 350
                    col.HeaderText = CStr(reader1(0))
                    col.Name = CStr(reader1(0))
                    dgLineUpCalendar.Columns.Add(col)
                End If
            End While
            reader1.Close()
            dgLineUpCalendar.Columns("lud_date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayLineUpCalenderRows(ByVal inumberofdays As Integer)
        Try
            dgLineUpCalendar.Rows.Clear()
            Dim n As Integer = 0
            For i = 0 To inumberofdays - 1
                ludbasisdate = Format(ludstartdate, "yyyy-MM-dd")
                ludstringdate = Format(ludstartdate, "dd-MMM-yyyy")
                ludstringday = DateTime.Parse(Format(ludstartdate, "dd-MMM-yyyy")).DayOfWeek.ToString
                dgLineUpCalendar.Rows.Add()
                dgLineUpCalendar.Item(lud_basisdate.Index, n).Value = ludbasisdate
                dgLineUpCalendar.Item(lud_date.Index, n).Value = "" & ludstringdate & "" & vbNewLine & "(" & ludstringday & ")"
                Dim m As Integer = 0
                For j = 0 To dgLineUpCalendar.Columns.Count - 1
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    Dim sdfsdfsd = If(IsThurston, "IFNULL(dt.truckname, '')", "COALESCE(CONCAT(COALESCE(dt.truckname,''),' - ',COALESCE(dt.truckno,''),' / ',COALESCE(s.shiftname,'')),'')")
                    Dim sql1 As String = $"SELECT COALESCE(DATE_FORMAT(lu.lineupdate,'%d-%b-%Y'),''),{sdfsdfsd}," &
                                "COALESCE(o.ordernumber,'') FROM lineups lu LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN deliverytruckshifts dts ON lu.deliverytruckshiftid = dts.rowid " &
                                "LEFT JOIN deliverytrucks dt ON dts.deliverytruckid = dt.rowid LEFT JOIN shifts s ON dts.shiftid = s.rowid " &
                                "WHERE lu.organizationid = " & Z_OrganizationID & " AND lu.`status` != 'Cancelled' "
                    Dim cmd1 As New MySqlCommand(sql1, conn)
                    Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
                    While reader1.Read()
                        If reader1.HasRows Then
                            If CStr(reader1(0)) = ludstringdate Then
                                If CStr(reader1(1)) = CStr(dgLineUpCalendar.Columns(m).Name) Then
                                    getCustomerOrdersLineUp(CStr(reader1(0)), CStr(reader1(1)))
                                    dgLineUpCalendar.Item(reader1(1), n).Value = ludcustomerorderslineup
                                End If
                            End If
                        End If
                    End While
                    reader1.Close()
                    m = m + 1
                Next
                ludstartdate = ludstartdate.AddDays(1)
                n = n + 1
            Next
            If dgLineUpCalendar.Rows.Count <> 0 Then
                dgLineUpCalendar.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCustomerOrdersLineUp(ByVal ilineupdate As String, ByVal ideliverytruckshift As String)
        Try
            ludcustomerorderslineup = "" : rowscount = 0
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim fsdfsd = If(IsThurston, "IFNULL(dt.truckname, '')", "COALESCE(CONCAT(COALESCE(dt.truckname,''),' - ',COALESCE(dt.truckno,''),' / ',COALESCE(s.shiftname,'')),'')")
            Dim sql1 As String = "SELECT lu.rowid,COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ',COALESCE(CONCAT(COALESCE(cu.companyname,''),' - ',COALESCE(cu.accountno,'')),'')),'') FROM lineups lu " &
                        "LEFT JOIN orders o ON lu.orderid = o.rowid LEFT JOIN accounts cu ON o.accountid = cu.rowid LEFT JOIN deliverytruckshifts dts ON lu.deliverytruckshiftid = dts.rowid " &
                        "LEFT JOIN deliverytrucks dt ON dts.deliverytruckid = dt.rowid LEFT JOIN shifts s ON dts.shiftid = s.rowid WHERE lu.organizationid = " & Z_OrganizationID & " AND lu.`status` != 'Cancelled' " &
                        "AND COALESCE(DATE_FORMAT(lu.lineupdate,'%d-%b-%Y'),'') = """ & ilineupdate & $""" AND {fsdfsd} = """ & ideliverytruckshift & """ ORDER BY o.ordernumber "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    countLineUpCartons(CInt(reader1(0)))
                    If rowscount = 0 Then
                        Dim valueText = If(IsThurston,
                            $"{CStr(reader1(1))} / Total Contents: {ludlineupcartonsqty}",
                            "" & CStr(reader1(1)) & " / Total Box/es: " & ludlineupcartonsqty & "")
                        ludcustomerorderslineup = valueText
                    Else
                        Dim valueText = If(IsThurston,
                            $"{ludcustomerorderslineup}{vbNewLine} {CStr(reader1(1))} / Total Box/es: {ludlineupcartonsqty}",
                            "" & ludcustomerorderslineup & "" & vbNewLine & "" & CStr(reader1(1)) & " / Total Box/es: " & ludlineupcartonsqty & "")
                        ludcustomerorderslineup = valueText
                    End If
                    rowscount = rowscount + 1
                End If
            End While
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub countLineUpCartons(ByVal ilineupid As Integer)
        Try
            ludlineupcartonsqty = 0
            Dim dtCOs As New DataTable
            dtCOs = getDataTableForSQL("SELECT COALESCE(COUNT(luc.rowid),0) FROM lineupcartons luc WHERE luc.organizationid = " & Z_OrganizationID & " AND luc.lineupid = " & ilineupid & " AND luc.`status` != 'Inactive' ")
            If dtCOs.Rows.Count <> 0 Then
                ludlineupcartonsqty = dtCOs.Rows(0)(0)
            Else
                ludlineupcartonsqty = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

#End Region

#Region "Colors"

    Sub colorCoding()
        Try
            If dgLineUpCalendar.Rows.Count <> 0 Then
                For i As Integer = 0 To dgLineUpCalendar.Rows.Count - 1
                    For j = 1 To dgLineUpCalendar.Columns.Count - 1
                        If dgLineUpCalendar.Rows(i).Cells(dgLineUpCalendar.Columns(j).Name).Value <> "" Then
                            dgLineUpCalendar.Rows(i).Cells(dgLineUpCalendar.Columns(j).Name).Style.BackColor = Drawing.Color.Ivory
                        End If
                    Next
                Next
                For i As Integer = 0 To dgLineUpCalendar.Rows.Count - 1
                    dgLineUpCalendar.Rows(i).Cells("lud_date").Style.BackColor = Drawing.Color.Lavender
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
                PrimaryForm.LnUpDlvryForm = False
                Me.Close()
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
            errProvider.Clear()
            displayLineUpCalenderColumn()
            luddisplaydays = CInt(DateDiff(DateInterval.Day, dtpFromSearch.Value, dtpToSearch.Value))
            ludstartdate = dtpFromSearch.Value
            If luddisplaydays > 0 Or luddisplaydays = 0 Then
                luddisplaydays = luddisplaydays + 1
                displayLineUpCalenderRows(luddisplaydays)
                colorCoding()
            Else
                errProvider.SetError(dtpFromSearch, "Date From should not be greater than Date To.")
                dgLineUpCalendar.Rows.Clear()
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
            errProvider.Clear()
            displayLineUpCalenderColumn()
            luddisplaydays = CInt(DateDiff(DateInterval.Day, dtpFromSearch.Value, dtpToSearch.Value))
            ludstartdate = dtpFromSearch.Value
            If luddisplaydays > 0 Or luddisplaydays = 0 Then
                luddisplaydays = luddisplaydays + 1
                displayLineUpCalenderRows(luddisplaydays)
                colorCoding()
            Else
                errProvider.SetError(dtpFromSearch, "Date From should not be greater than Date To.")
                dgLineUpCalendar.Rows.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msRefresh_Click(sender As Object, e As EventArgs) Handles msRefresh.Click
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
                getPositionView(globalpositionid, "Line-Up And Delivery", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.LnUpDlvryForm = False
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
            Dim addlineupdeliverylinkform As New AddLineUpForm
            addlineupdeliverylinkform.ShowInTaskbar = False
            addlineupdeliverylinkform.ShowDialog()
            If addlineupdeliverylinkform.addlineupdeliverycue = legit Then
                displayLineUpCalenderColumn()
                luddisplaydays = CInt(DateDiff(DateInterval.Day, dtpFromSearch.Value, dtpToSearch.Value))
                ludstartdate = dtpFromSearch.Value
                If luddisplaydays > 0 Or luddisplaydays = 0 Then
                    luddisplaydays = luddisplaydays + 1
                    displayLineUpCalenderRows(luddisplaydays)
                    colorCoding()
                Else
                    errProvider.SetError(dtpFromSearch, "Date From should not be greater than Date To.")
                    dgLineUpCalendar.Rows.Clear()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msViewEdit_Click(sender As Object, e As EventArgs) Handles msViewEdit.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim vieweditlineupdeliverylinkform As New ViewEditLineUpDeliveryForm
            vieweditlineupdeliverylinkform.ShowInTaskbar = False
            vieweditlineupdeliverylinkform.ShowDialog()
            If vieweditlineupdeliverylinkform.vieweditlineupdeliverycue = legit Then
                displayLineUpCalenderColumn()
                luddisplaydays = CInt(DateDiff(DateInterval.Day, dtpFromSearch.Value, dtpToSearch.Value))
                ludstartdate = dtpFromSearch.Value
                If luddisplaydays > 0 Or luddisplaydays = 0 Then
                    luddisplaydays = luddisplaydays + 1
                    displayLineUpCalenderRows(luddisplaydays)
                    colorCoding()
                Else
                    errProvider.SetError(dtpFromSearch, "Date From should not be greater than Date To.")
                    dgLineUpCalendar.Rows.Clear()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgLineUpCalendar_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineUpCalendar.CellContentClick

    End Sub

    Private Sub dgLineUpCalendar_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineUpCalendar.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            ludselectedcell = "" : ludselectedcolumn = ""
            Dim selectedCellCount As Integer = dgLineUpCalendar.GetCellCount(DataGridViewElementStates.Selected)
            If selectedCellCount > 0 Then
                If dgLineUpCalendar.AreAllCellsSelected(True) Then
                    MessageBox.Show("All cells are selected", "Selected Cells")
                Else
                    For i = 0 To selectedCellCount - 1
                        ludselectedcell = CStr(dgLineUpCalendar.SelectedCells(i).Value)
                        ludselectedcolumn = CStr(dgLineUpCalendar.Columns(CInt(dgLineUpCalendar.SelectedCells(i).ColumnIndex)).Name)
                    Next i
                End If
            End If
            If ludselectedcell <> "" Then
                If ludselectedcolumn <> "" Then
                    getDeliveryTruckShiftIDB(ludselectedcolumn, "", Me)
                    luddeliverytruckshiftid = globaldeliverytruckshiftid
                    Dim vieweditlineupdeliverylinkform As New ViewEditLineUpDeliveryForm
                    vieweditlineupdeliverylinkform.veludpublicselectedcellcue = legit
                    vieweditlineupdeliverylinkform.veludpublicdeliverydate = CStr(dgLineUpCalendar.CurrentRow.Cells("lud_basisdate").Value)
                    vieweditlineupdeliverylinkform.veludpublicdeliverytruckshiftid = luddeliverytruckshiftid
                    vieweditlineupdeliverylinkform.ShowInTaskbar = False
                    vieweditlineupdeliverylinkform.ShowDialog()
                    If vieweditlineupdeliverylinkform.vieweditlineupdeliverycue = legit Then
                        displayLineUpCalenderColumn()
                        luddisplaydays = CInt(DateDiff(DateInterval.Day, dtpFromSearch.Value, dtpToSearch.Value))
                        ludstartdate = dtpFromSearch.Value
                        If luddisplaydays > 0 Or luddisplaydays = 0 Then
                            luddisplaydays = luddisplaydays + 1
                            displayLineUpCalenderRows(luddisplaydays)
                            colorCoding()
                        Else
                            errProvider.SetError(dtpFromSearch, "Date From should not be greater than Date To.")
                            dgLineUpCalendar.Rows.Clear()
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

#Region "Datagrid Errors"

    Private Sub dgLineUpCalendar_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgLineUpCalendar.DataError
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
                dgLineUpCalendar.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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