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
Public Class AddCycleCountForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim accbrandid, acccyclecountid, acccountproductrackcolumnshelf As Integer
    Public addcyclecountformcue As Boolean = False
    Private Sub AddCycleCountForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            clearfields()
            callAutoPopulate()
            getCycleCountNo(Me)
            txtCycleCountNo.Text = globalcyclecountno
            cboCountBy.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub AddCycleCountForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            PrimaryForm.MainLoadingBar.Visible = fraud
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#Region "Functions"
    Sub callAutoPopulate()
        autopopulateCountBy(cboCountBy)
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            txtCycleCountNo.Text = ""
            cboBrandName.Text = ""
            cboCountBy.SelectedItem = Nothing
            cboBrandName.SelectedItem = Nothing
            chkAllBrand.Checked = fraud
            gbBrand.Visible = fraud
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
            Dim cmd As New MySqlCommand("SELECT COALESCE(b.brandname,'') AS 'brandname' FROM products p LEFT JOIN brands b ON p.brandid = b.rowid WHERE p.organizationid = " & Z_OrganizationID & " AND p.brandid IS NOT NULL GROUP BY b.brandname ORDER BY b.brandname ", conn)
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
#End Region
#Region "AutoPopulate"
    Sub autopopulateCountBy(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(lic,'') AS 'cyclecounttype' FROM listofvalues WHERE `type` = 'Cycle Count Type' AND `status` = 'Active' GROUP BY lic ORDER BY lic "
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
    Sub autopopulateBrandName(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(b.brandname,'') AS 'brandname' FROM products p LEFT JOIN brands b ON p.brandid = b.rowid WHERE p.organizationid = " & Z_OrganizationID & " AND p.brandid IS NOT NULL GROUP BY b.brandname ORDER BY b.brandname "
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
#End Region
#Region "Saving"
    Sub getCountProductRackColumnShelf(ByVal iconditionstring As String)
        Try
            acccountproductrackcolumnshelf = 0
            Dim dtGc As New DataTable
            dtGc = getDataTableForSQL("SELECT COALESCE(COUNT(pil.rowid),0) FROM productinventorylocation pil LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid " & _
                            "LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid WHERE pil.organizationid = " & Z_OrganizationID & " " & iconditionstring & " ")
            If dtGc.Rows.Count <> 0 Then
                acccountproductrackcolumnshelf = CInt(dtGc.Rows(0)(0))
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub
    Sub saveCycleCountItems(ByVal icyclecountid As Integer, ByVal iconditionstring As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT COALESCE(pil.productcolorsizeid,0),COALESCE(pil.rowid,0),COALESCE(pil.totalavailableqty,0),COALESCE(rsc.rackno,''),COALESCE(rsc.columnno,''),COALESCE(rsc.shelfno,'') FROM productinventorylocation pil " & _
                "LEFT JOIN productcolorsizes pcs ON pil.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " & _
                "WHERE pil.organizationid = " & Z_OrganizationID & " " & iconditionstring & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    If myModule.systemerrorfound = False Then
                        I_CycleCountItems(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, icyclecountid, CInt(reader1(0)), CInt(reader1(1)), DBNull.Value, DBNull.Value, CInt(reader1(2)), DBNull.Value, DBNull.Value, CStr(reader1(3)), CStr(reader1(4)), CStr(reader1(5)), "", Me)
                        If PrimaryForm.MainLoadingBar.Value < acccountproductrackcolumnshelf + startingpage Then
                            PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
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
#End Region
    Private Sub cboCountBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCountBy.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cboCountBy.Text = "" Then
                gbBrand.Visible = fraud
            ElseIf cboCountBy.Text = "Brand" Then
                gbBrand.Visible = legit
                autocompleteBrandName(cboBrandName)
                autopopulateBrandName(cboBrandName)
                cboBrandName.Text = "" : cboBrandName.SelectedItem = Nothing
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub chkAllBrand_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllBrand.CheckedChanged
        Try
            If chkAllBrand.Checked = legit Then
                cboBrandName.Enabled = fraud
                cboBrandName.Text = "" : cboBrandName.SelectedItem = Nothing
            Else
                cboBrandName.Enabled = legit
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
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Cycle Count", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            If cboCountBy.Text = "" Then
                errProvider.SetError(cboCountBy, "Please choose the count by for new cycle count.")
                Exit Try
            End If
            If cboCountBy.Text = "Brand" Then
                If chkAllBrand.Checked = fraud Then
                    If cboBrandName.Text = "" Then
                        errProvider.SetError(cboBrandName, "Please choose or enter the brand name.")
                        Exit Try
                    End If
                    getBrandID(cboBrandName.Text, Me)
                    accbrandid = globalbrandid
                    If accbrandid = 0 Then
                        errProvider.SetError(cboBrandName, "System cannot find the brand name, please choose the brand name.")
                        Exit Try
                    End If
                    getCountProductRackColumnShelf("AND p.brandid = " & accbrandid & "")
                    If acccountproductrackcolumnshelf = 0 Then
                        MessageBox.Show("There is no available brand of item stock in any Rack / Column / Shelf as of this moment.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                Else
                    getCountProductRackColumnShelf("AND p.brandid IS NOT NULL")
                    If acccountproductrackcolumnshelf = 0 Then
                        MessageBox.Show("There is no available brand of item stock in any Rack / Column / Shelf as of this moment.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Try
                    End If
                End If
            End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getCycleCountNo(Me)
                PrimaryForm.MainLoadingBar.Visible = legit
                PrimaryForm.MainLoadingBar.Maximum = acccountproductrackcolumnshelf + startingpage
                I_CycleCount(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, If(accbrandid = 0, DBNull.Value, accbrandid), globalcyclecountno, cboCountBy.Text, "", "", Me)
                acccyclecountid = globalcyclecountidsp
                If myModule.systemerrorfound = False Then
                    If PrimaryForm.MainLoadingBar.Value < acccountproductrackcolumnshelf + startingpage Then
                        PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                    End If
                    If cboCountBy.Text = "Brand" Then
                        If chkAllBrand.Checked = legit Then
                            saveCycleCountItems(acccyclecountid, "AND p.brandid IS NOT NULL")
                        ElseIf chkAllBrand.Checked = fraud Then
                            saveCycleCountItems(acccyclecountid, "AND p.brandid = " & accbrandid & "")
                        End If
                    End If
                    If CInt(txtCycleCountNo.Text) <> globalcyclecountno Then
                        MessageBox.Show("Please take note that the Cycle Count No. will change from " & txtCycleCountNo.Text & " to " & globalcyclecountno & "." & vbNewLine & "Another user used Cycle Count No. " & txtCycleCountNo.Text & " for its new cycle count.", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCycleCountNo.Text = globalcyclecountno
                    End If
                End If
                If myModule.systemerrorfound = False Then
                    MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    addcyclecountformcue = legit
                    Me.Close()
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