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
Public Class PostionViewForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim fs As FileStream
    Dim br As BinaryReader
    Dim cue As String
    Dim ImageData() As Byte
    Dim positionid As Integer
    Dim AttachedFile As Object
    Dim legit As Boolean = True
    Dim fraud As Boolean = False
    Dim itemno, rowscount As Integer
    Dim thefilepath As String = Nothing
    Dim FileName, FileExtension As String
    Dim nowDate = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
    Private Sub PostionViewForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            displayPositionDetails()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub PostionViewForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Sub callAutoCompleteFunctions()
        SearchCompletePosition()
    End Sub
    Sub callAutoPopulateFunctions()
        populatePosition()
        populateStatus()
    End Sub
#Region "Clear/Enable/Visible Functions"
    Sub clearfields()
        Try
            cue = ""
            clearPositionInformation()
            enableGB(legit, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud)
            dgUsers.Rows.Clear()
            dgUnknown.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub clearPositionInformation()
        Try
            txtPositionName.Text = ""
            txtComments.Text = ""
            cboPosition.Text = ""
            cboStatus.SelectedItem = Nothing
            cboPosition.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean)
        Try
            gbPositionList.Enabled = enable1
            gbPosition.Enabled = enable2
            gbUser.Enabled = enable3
            gbUnknown.Enabled = enable3
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
#Region "Click Functions"
    Sub tsrefreshperformclick()
        Try
            errProvider.Clear()
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            displayPositionDetails()
            tabMain.SelectedTab = tabDetails
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display Functions"
#Region "AutoComplete Functions"
    Sub SearchCompletePosition()
        Try
            Dim position As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT positionname FROM positions organizationid = '" & Z_OrganizationID & "' ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                position.Add(ds.Tables(0).Rows(i)("positionname").ToString())
            Next
            cboPosition.AutoCompleteSource = AutoCompleteSource.CustomSource
            cboPosition.AutoCompleteCustomSource = position
            cboPosition.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub
#End Region
#Region "AutoPopulate Functions"
    Sub populatePosition()
        Try
            cboPosition.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT positionname FROM positions WHERE organizationid = '" & Z_OrganizationID & "' ORDER BY positionname "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                cboPosition.Items.Add(reader1(0).ToString())
            End While
            reader1.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub populateStatus()
        Try
            cboStatus.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT displayvalue FROM listofvalues WHERE type = 'Status' AND status = 'Active' ORDER BY displayvalue"
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                cboStatus.Items.Add(reader1(0).ToString())
            End While
            reader1.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display Datagrids"
    Public Function displayPositionDetails()
        If conn.State = ConnectionState.Open Then conn.Close()
        sqlquery = "SELECT p.rowid,COALESCE(pp.positionname,''),COALESCE(p.comments,''),COALESCE(p.positionname,''),COALESCE(p.status,'') " & _
            "FROM positions p LEFT JOIN positions pp ON p.parentpositionid = pp.rowid  " & _
            "WHERE p.organizationid = '" & Z_OrganizationID & "' ORDER BY p.positionname "
        dgPositions.Rows.Clear()
        Dim sqlcmd As New MySqlCommand(sqlquery, conn)
        conn.Open()
        Dim sqlrd As MySqlDataReader = sqlcmd.ExecuteReader
        sqlcmd = Nothing
        If sqlrd.HasRows Then
            Try
                Dim n As Integer = 0
                Dim seqno As Integer = 1
                While sqlrd.Read
                    dgPositions.Rows.Add()
                    dgPositions.Item(p_rowid.Index, n).Value = sqlrd(0)
                    dgPositions.Item(p_parentposition.Index, n).Value = sqlrd(1)
                    dgPositions.Item(p_comments.Index, n).Value = sqlrd(2)
                    dgPositions.Item(p_no.Index, n).Value = seqno
                    dgPositions.Item(p_positionname.Index, n).Value = sqlrd(3)
                    dgPositions.Item(p_status.Index, n).Value = sqlrd(4)
                    seqno = seqno + 1
                    n = n + 1
                End While
                Return True
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, Me.Name))
                sqlrd.Close()
                conn.Close()
                Return False
            Finally
                If dgPositions.Rows.Count <> 0 Then
                    dgPositions.CurrentRow.Selected = False
                End If
                dgPositions.Columns("p_no").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                sqlrd.Close()
                conn.Close()
            End Try
            Return True
        End If
        conn.Close()
        Return Nothing
    End Function
    Public Function displayUserDetails(ByVal ipositionid As Integer)
        If conn.State = ConnectionState.Open Then conn.Close()
        sqlquery = "SELECT u.rowid,COALESCE(u.firstname,''),COALESCE(u.middlename,''),COALESCE(u.lastname,''),COALESCE(u.status,'') " & _
            "FROM users u WHERE u.organizationid = '" & Z_OrganizationID & "' AND u.positionid = '" & ipositionid & "' ORDER BY u.rowid "
        dgUsers.Rows.Clear()
        Dim sqlcmd As New MySqlCommand(sqlquery, conn)
        conn.Open()
        Dim sqlrd As MySqlDataReader = sqlcmd.ExecuteReader
        sqlcmd = Nothing
        If sqlrd.HasRows Then
            Try
                Dim n As Integer = 0
                While sqlrd.Read
                    dgUsers.Rows.Add()
                    dgUsers.Item(u_rowid.Index, n).Value = sqlrd(0)
                    dgUsers.Item(u_userno.Index, n).Value = sqlrd(0)
                    dgUsers.Item(u_fname.Index, n).Value = sqlrd(1)
                    dgUsers.Item(u_mname.Index, n).Value = sqlrd(2)
                    dgUsers.Item(u_lname.Index, n).Value = sqlrd(3)
                    dgUsers.Item(u_status.Index, n).Value = sqlrd(4)
                    n = n + 1
                End While
                Return True
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, Me.Name))
                sqlrd.Close()
                conn.Close()
                Return False
            Finally
                If dgUsers.Rows.Count <> 0 Then
                    dgUsers.CurrentRow.Selected = False
                End If
                sqlrd.Close()
                conn.Close()
            End Try
            Return True
        End If
        conn.Close()
        Return Nothing
    End Function
    Public Function displayPositionViews(ByVal spositionid As Integer)
        If conn.State = ConnectionState.Open Then conn.Close()
        sqlquery = "SELECT pv.rowid,pv.viewid,COALESCE(v.viewname,''),COALESCE(pv.creates,''),COALESCE(pv.updates,''),COALESCE(pv.disable,''),COALESCE(pv.readonly,''),COALESCE(pv.remarks,'') " & _
            "FROM positionviews pv LEFT JOIN views v ON pv.viewid = v.rowid WHERE pv.organizationid = '" & Z_OrganizationID & "' AND pv.positionid = '" & spositionid & "' ORDER BY v.viewname "
        dgUnknown.Rows.Clear()
        Dim sqlcmd As New MySqlCommand(sqlquery, conn)
        conn.Open()
        Dim sqlrd As MySqlDataReader = sqlcmd.ExecuteReader
        sqlcmd = Nothing
        If sqlrd.HasRows Then
            Try
                Dim n As Integer = 0
                Dim seqno As Integer = 1
                While sqlrd.Read
                    dgUnknown.Rows.Add()
                    dgUnknown.Item(pv_rowid.Index, n).Value = sqlrd(0)
                    dgUnknown.Item(pv_viewid.Index, n).Value = sqlrd(1)
                    dgUnknown.Item(pv_no.Index, n).Value = seqno
                    dgUnknown.Item(pv_viewname.Index, n).Value = sqlrd(2)
                    If sqlrd(3) = "Y" Then
                        dgUnknown.Item(pv_create.Index, n).Value = legit
                    Else
                        dgUnknown.Item(pv_create.Index, n).Value = fraud
                    End If
                    If sqlrd(4) = "Y" Then
                        dgUnknown.Item(pv_updates.Index, n).Value = legit
                    Else
                        dgUnknown.Item(pv_updates.Index, n).Value = fraud
                    End If
                    If sqlrd(5) = "Y" Then
                        dgUnknown.Item(pv_disable.Index, n).Value = legit
                    Else
                        dgUnknown.Item(pv_disable.Index, n).Value = fraud
                    End If
                    If sqlrd(6) = "Y" Then
                        dgUnknown.Item(pv_readonly.Index, n).Value = legit
                    Else
                        dgUnknown.Item(pv_readonly.Index, n).Value = fraud
                    End If
                    dgUnknown.Item(pv_remarks.Index, n).Value = sqlrd(7)
                    seqno = seqno + 1
                    n = n + 1
                End While
                Return True
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, Me.Name))
                sqlrd.Close()
                conn.Close()
                Return False
            Finally
                If dgUnknown.Rows.Count <> 0 Then
                    dgUnknown.CurrentRow.Selected = False
                End If
                sqlrd.Close()
                conn.Close()
            End Try
            Return True
        End If
        conn.Close()
        Return Nothing
    End Function
    Public Function displayNewPositionViews()
        If conn.State = ConnectionState.Open Then conn.Close()
        sqlquery = "SELECT v.rowid,v.viewname FROM views v WHERE v.organizationid = " & Z_OrganizationID & " ORDER BY v.viewname "
        dgUnknown.Rows.Clear()
        Dim sqlcmd As New MySqlCommand(sqlquery, conn)
        conn.Open()
        Dim sqlrd As MySqlDataReader = sqlcmd.ExecuteReader
        sqlcmd = Nothing
        If sqlrd.HasRows Then
            Try
                Dim n As Integer = 0
                Dim seqno As Integer = 1
                While sqlrd.Read
                    dgUnknown.Rows.Add()
                    dgUnknown.Item(pv_rowid.Index, n).Value = 0
                    dgUnknown.Item(pv_no.Index, n).Value = seqno
                    dgUnknown.Item(pv_viewid.Index, n).Value = sqlrd(0)
                    dgUnknown.Item(pv_viewname.Index, n).Value = sqlrd(1)
                    dgUnknown.Item(pv_create.Index, n).Value = fraud
                    dgUnknown.Item(pv_updates.Index, n).Value = legit
                    dgUnknown.Item(pv_disable.Index, n).Value = fraud
                    dgUnknown.Item(pv_readonly.Index, n).Value = fraud
                    dgUnknown.Item(pv_remarks.Index, n).Value = ""
                    seqno = seqno + 1
                    n = n + 1
                End While
                Return True
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, Me.Name))
                sqlrd.Close()
                conn.Close()
                Return False
            Finally
                If dgUnknown.Rows.Count <> 0 Then
                    dgUnknown.CurrentRow.Selected = False
                End If
                sqlrd.Close()
                conn.Close()
            End Try
            Return True
        End If
        conn.Close()
        Return Nothing
    End Function
#End Region
#End Region
#Region "Saving Functions"
    Sub getPositionIDA(ByVal spositionname As String)
        Try
            positionid = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtPid As New DataTable
            dtPid = getDataTableForSQL("SELECT rowid FROM positions WHERE positionname = '" & spositionname & "' AND organizationid = '" & Z_OrganizationID & "' ")
            If dtPid.Rows.Count <> 0 Then
                positionid = dtPid.Rows(0)(0)
            Else
                positionid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub getUpdPositionID(ByVal srowid As Integer, ByVal spositionname As String)
        Try
            positionid = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtPid As New DataTable
            dtPid = getDataTableForSQL("SELECT rowid FROM positions WHERE positionname = '" & spositionname & "' AND organizationid = '" & Z_OrganizationID & "' AND rowid != '" & srowid & "' ")
            If dtPid.Rows.Count <> 0 Then
                positionid = dtPid.Rows(0)(0)
            Else
                positionid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub insertPositionViews(ByVal savepositionid As Integer)
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT rowid FROM `views` WHERE organizationid = '" & Z_OrganizationID & "' ORDER BY rowid "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            Dim n As Integer = 0
            While reader1.Read()
                I_PositionView(Z_OrganizationID, nowDate, Z_UserID, nowDate, Z_UserID, savepositionid, CInt(reader1(0).ToString()), If(dgUnknown.Rows(n).Cells("pv_create").Value = True, "Y", "N"),
                               If(dgUnknown.Rows(n).Cells("pv_updates").Value = True, "Y", "N"), If(dgUnknown.Rows(n).Cells("pv_disable").Value = True, "Y", "N"),
                               If(dgUnknown.Rows(n).Cells("pv_readonly").Value = True, "Y", "N"), dgUnknown.Rows(n).Cells("pv_remarks").Value, Me)
                n = n + 1
            End While
            reader1.Close()
            conn.Close()
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
                PrimaryForm.PosViewForm = False
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
            myBalloon("Successfully refresh", "Refresh", lblsavemsg, -15, -65)
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
                getPositionView(globalpositionid, "Positions And Views", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PosViewForm = False
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
            clearPositionInformation()
            dgUsers.Rows.Clear()
            dgUnknown.Rows.Clear()
            enableGB(fraud, legit, legit)
            enableANDvisibleMS(fraud, legit, legit)
            If dgPositions.Rows.Count <> 0 Then
                dgPositions.CurrentRow.Selected = False
            End If
            displayNewPositionViews()
            txtPositionName.Focus()
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
            cue = "Edit"
            errProvider.Clear()
            tabMain.SelectedTab = tabDetails
            clearPositionInformation()
            enableGB(legit, legit, legit)
            enableANDvisibleMS(legit, legit, fraud)
            If dgPositions.Rows.Count <> 0 Then
                dgPositions.CurrentRow.Selected = True
                txtPositionName.Text = dgPositions.CurrentRow.Cells("p_positionname").Value
                cboPosition.Text = dgPositions.CurrentRow.Cells("p_parentposition").Value
                txtComments.Text = dgPositions.CurrentRow.Cells("p_comments").Value
                cboStatus.Text = dgPositions.CurrentRow.Cells("p_status").Value
                displayUserDetails(CInt(dgPositions.CurrentRow.Cells("p_rowid").Value))
                displayPositionViews(CInt(dgPositions.CurrentRow.Cells("p_rowid").Value))
            Else
                tsrefreshperformclick()
            End If
            txtPositionName.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgPositions_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPositions.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            cue = "Edit"
            errProvider.Clear()
            tabMain.SelectedTab = tabDetails
            clearPositionInformation()
            enableGB(legit, legit, legit)
            enableANDvisibleMS(legit, legit, fraud)
            If dgPositions.Rows.Count <> 0 Then
                txtPositionName.Text = dgPositions.CurrentRow.Cells("p_positionname").Value
                cboPosition.Text = dgPositions.CurrentRow.Cells("p_parentposition").Value
                txtComments.Text = dgPositions.CurrentRow.Cells("p_comments").Value
                cboStatus.Text = dgPositions.CurrentRow.Cells("p_status").Value
                displayUserDetails(CInt(dgPositions.CurrentRow.Cells("p_rowid").Value))
                displayPositionViews(CInt(dgPositions.CurrentRow.Cells("p_rowid").Value))
            End If
            txtPositionName.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgPositions_KeyUp(sender As Object, e As KeyEventArgs) Handles dgPositions.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPositions.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    tabMain.SelectedTab = tabDetails
                    clearPositionInformation()
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, fraud)
                    If dgPositions.Rows.Count <> 0 Then
                        txtPositionName.Text = dgPositions.CurrentRow.Cells("p_positionname").Value
                        cboPosition.Text = dgPositions.CurrentRow.Cells("p_parentposition").Value
                        txtComments.Text = dgPositions.CurrentRow.Cells("p_comments").Value
                        cboStatus.Text = dgPositions.CurrentRow.Cells("p_status").Value
                        displayUserDetails(CInt(dgPositions.CurrentRow.Cells("p_rowid").Value))
                        displayPositionViews(CInt(dgPositions.CurrentRow.Cells("p_rowid").Value))
                    End If
                    txtPositionName.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtPositionName_Leave(sender As Object, e As EventArgs) Handles txtPositionName.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cue = "New" Then
                getPositionIDA(txtPositionName.Text)
                If positionid <> 0 Then
                    errProvider.SetError(txtPositionName, "Position name has been created already, please type a new one or else there would be an error once this would be save")
                End If
            ElseIf cue = "Edit" Then
                getUpdPositionID(CInt(dgPositions.CurrentRow.Cells("p_rowid").Value), txtPositionName.Text)
                If positionid <> 0 Then
                    errProvider.SetError(txtPositionName, "Position name has been created already, please type a new one or else there would be an error once this would be save")
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub txtPositionName_TextChanged(sender As Object, e As EventArgs) Handles txtPositionName.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cue = "New" Then
    '            getPositionIDA(txtPositionName.Text)
    '            If positionid <> 0 Then
    '                errProvider.SetError(txtPositionName, "Position name has been created already, please type a new one or else there would be an error once this would be save")
    '            End If
    '        ElseIf cue = "Edit" Then
    '            getUpdPositionID(CInt(dgPositions.CurrentRow.Cells("p_rowid").Value), txtPositionName.Text)
    '            If positionid <> 0 Then
    '                errProvider.SetError(txtPositionName, "Position name has been created already, please type a new one or else there would be an error once this would be save")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    Private Sub dgUnknown_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgUnknown.CellContentClick
        Try
            If dgUnknown.Rows.Count <> 0 Then
                If e.ColumnIndex = dgUnknown.Columns("pv_create").Index Or e.ColumnIndex = dgUnknown.Columns("pv_updates").Index Or e.ColumnIndex = dgUnknown.Columns("pv_readonly").Index Or e.ColumnIndex = dgUnknown.Columns("pv_disable").Index Then
                    Dim checkboxIndexes As New List(Of Integer)
                    checkboxIndexes.Add(dgUnknown.Columns("pv_create").Index)
                    checkboxIndexes.Add(dgUnknown.Columns("pv_updates").Index)
                    checkboxIndexes.Add(dgUnknown.Columns("pv_disable").Index)
                    checkboxIndexes.Add(dgUnknown.Columns("pv_readonly").Index)
                    If dgUnknown.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False Then
                        For Each index In checkboxIndexes
                            If index <> e.ColumnIndex Then
                                dgUnknown.Rows(e.RowIndex).Cells(index).Value = False
                            End If
                        Next
                    End If
                    dgUnknown.CommitEdit(True)
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub dgUnknown_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgUnknown.CellEndEdit
        Try
            dgUnknown.CommitEdit(True)
            For i = 0 To dgUnknown.Rows.Count - 1
                If dgUnknown.Rows(i).Cells("pv_create").Value = fraud AndAlso dgUnknown.Rows(i).Cells("pv_updates").Value = fraud AndAlso dgUnknown.Rows(i).Cells("pv_disable").Value = fraud AndAlso dgUnknown.Rows(i).Cells("pv_readonly").Value = fraud Then
                    dgUnknown.Rows(i).Cells("pv_readonly").Value = legit
                End If
            Next
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub dgUnknown_MouseUp(sender As Object, e As MouseEventArgs) Handles dgUnknown.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgUnknown.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgUnknown.BeginEdit(True)
                Else
                    dgUnknown.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            dgUnknown.CommitEdit(True) : dgUnknown.ClearSelection() : dgUnknown.CurrentCell = Nothing
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Positions And Views", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.PosViewForm = False
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
                getPositionIDA(txtPositionName.Text)
            ElseIf cue = "Edit" Then
                If globalcreateflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                getUpdPositionID(CInt(dgPositions.CurrentRow.Cells("p_rowid").Value), txtPositionName.Text)
            End If
            If txtPositionName.Text = "" AndAlso cboStatus.Text = "" Then
                errProvider.SetError(txtPositionName, "Please fill-up these fields")
                errProvider.SetError(cboStatus, "Please fill-up these fields")
                txtPositionName.Focus()
            ElseIf txtPositionName.Text = "" Then
                errProvider.SetError(txtPositionName, "Please enter the position name ")
                txtPositionName.Focus()
            ElseIf cboStatus.Text = "" Then : errProvider.SetError(cboStatus, "Please choose the status of the position")
                cboStatus.Focus()
            ElseIf positionid <> 0 Then
                errProvider.SetError(txtPositionName, "Position name has been created already, please type a new one")
                txtPositionName.Focus()
            Else
                If MessageBox.Show("Would you like to save the changes on this page? ", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    getPositionIDA(cboPosition.Text)
                    If cue = "New" Then
                        I_Position(Z_OrganizationID, nowDate, Z_UserID, nowDate, Z_UserID, txtPositionName.Text, If(positionid = 0, DBNull.Value, positionid), DBNull.Value, cboStatus.Text, txtComments.Text, Me)
                        getPositionIDA(txtPositionName.Text)
                        insertPositionViews(positionid)
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Save", "Save", lblsavemsg, -15, -65)
                        End If
                    ElseIf cue = "Edit" Then
                        U_Position(CInt(dgPositions.CurrentRow.Cells("p_rowid").Value), nowDate, Z_UserID, txtPositionName.Text, If(positionid = 0, DBNull.Value, positionid), DBNull.Value, cboStatus.Text, txtComments.Text, Me)
                        For c = 0 To dgUnknown.Rows.Count - 1
                            U_PositionView(CInt(dgUnknown.Rows(c).Cells("pv_rowid").Value), nowDate, Z_UserID, If(dgUnknown.Rows(c).Cells("pv_create").Value = True, "Y", "N"), If(dgUnknown.Rows(c).Cells("pv_updates").Value = True, "Y", "N"), _
                                            If(dgUnknown.Rows(c).Cells("pv_disable").Value = True, "Y", "N"), If(dgUnknown.Rows(c).Cells("pv_readonly").Value = True, "Y", "N"), dgUnknown.Rows(c).Cells("pv_remarks").Value, Me)
                        Next
                        If myModule.systemerrorfound = False Then
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
#Region "Datagrid Data Error"
    Private Sub dgPositions_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgPositions.DataError
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
                dgPositions.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgUsers_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgUsers.DataError
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
                dgUsers.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub dgUnknown_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgUnknown.DataError
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
                dgUnknown.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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