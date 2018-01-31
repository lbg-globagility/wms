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
Imports System.ComponentModel
Imports System.Data.OleDb
Public Class EditRackShelfColumnForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim ersinitialrsc As String
    Dim searchrackshelfcolumnid As Integer
    Public ersccue As Boolean = False
    Public erscrackshelfcolumnid, erscinventorylocationid As Integer
    Private Sub EditRackShelfColumnForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            If erscrackshelfcolumnid <> 0 Then
                displayRSCInformation(erscrackshelfcolumnid)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub EditRackShelfColumnForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
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
        autopopulateRack(cboRack)
        autopopulateShelf(cboShelf)
        autopopulateColumn(cboColumn)
    End Sub
#Region "Clear/Enable/Visible Functions"
    Sub clearfields()
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
#End Region
#Region "Display Functions"
#Region "AutoComplete"
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
#Region "Display"
    Sub displayRSCInformation(ByVal irackshelfcolumnid As Integer)
        Try
            ersinitialrsc = ""
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(rsc.rackno,''),COALESCE(rsc.shelfno,''),COALESCE(rsc.columnno,''),COALESCE(rsc.pickorderno,0),COALESCE(rsc.remarks,'') FROM rackshelfcolumn rsc WHERE rsc.rowid = " & irackshelfcolumnid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    cboRack.Text = reader1(0)
                    cboShelf.Text = reader1(1)
                    cboColumn.Text = reader1(2)
                    txtPickOrderNo.Text = reader1(3)
                    txtRemarks.Text = reader1(4)
                    ersinitialrsc = "" & reader1(0) & "" & reader1(1) & "" & reader1(2) & ""
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
#End Region
    Private Sub pbAutoAddRack_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddRack.MouseEnter
        Try
            pbAutoAddRack.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddRack_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddRack.MouseLeave
        Try
            pbAutoAddRack.BackColor = Color.Transparent
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
            pbAutoAddColumn.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddColumn_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddColumn.MouseLeave
        Try
            pbAutoAddColumn.BackColor = Color.Transparent
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
            pbAutoAddShelf.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddShelf_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddShelf.MouseLeave
        Try
            pbAutoAddShelf.BackColor = Color.Transparent
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
    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            searchrackshelfcolumnid = 0
            myModule.systemerrorfound = False
            If ersinitialrsc <> "" & cboRack.Text & "" & cboShelf.Text & "" & cboColumn.Text & "" Then
                getRackShelfColumnID("" & cboRack.Text & "" & cboShelf.Text & "" & cboColumn.Text & "", erscinventorylocationid, Me)
                searchrackshelfcolumnid = globalrackshelfcolumnid
            End If
            If LTrim(cboRack.Text) = "" And LTrim(cboShelf.Text) = "" And LTrim(cboColumn.Text) = "" Then
                MessageBox.Show("Please fill-up rack,column, and shelf fields.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboRack.Focus()
            ElseIf LTrim(cboRack.Text) = "" Then
                MessageBox.Show("Please fill-up rack,column, and shelf fields.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboRack.Focus()
            ElseIf LTrim(cboShelf.Text) = "" Then
                MessageBox.Show("Please fill-up rack,column, and shelf fields.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboShelf.Focus()
            ElseIf LTrim(cboColumn.Text) = "" Then
                MessageBox.Show("Please fill-up rack,column, and shelf fields.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboColumn.Focus()
            ElseIf erscrackshelfcolumnid = 0 Then
                MessageBox.Show("System cannot find the rack,column, and shelf id", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboRack.Focus()
            ElseIf searchrackshelfcolumnid <> 0 Then
                MessageBox.Show("The rack,column, and shelf fields is in the list already.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboRack.Focus()
            Else
                If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    If ersinitialrsc <> "" & cboRack.Text & "" & cboShelf.Text & "" & cboColumn.Text & "" Then
                        getRackShelfColumnID("" & cboRack.Text & "" & cboShelf.Text & "" & cboColumn.Text & "", erscinventorylocationid, Me)
                        searchrackshelfcolumnid = globalrackshelfcolumnid
                    End If
                    If searchrackshelfcolumnid = 0 Then
                        U_RackShelfColumn(erscrackshelfcolumnid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, cboRack.Text, cboShelf.Text, cboColumn.Text, If(IsNumeric(txtPickOrderNo.Text), CInt(txtPickOrderNo.Text), 0), txtRemarks.Text, Me)
                    Else
                        MessageBox.Show("The rack,column, and shelf fields is in the list already.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cboRack.Focus()
                        Exit Try
                    End If
                    If myModule.systemerrorfound = False Then
                        MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ersccue = legit
                        Me.Close()
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
End Class