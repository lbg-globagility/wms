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
Public Class SelectPickListForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Public splpicklistid As Integer
    Public selecpicklistcue As Boolean = False
    Private Sub SelectPickListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            cboPickingListNo.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub callAutoComplete()
        autocompletePickListNo(cboPickingListNo)
    End Sub
    Sub callAutoPopulate()
        autopopulatePickListNo(cboPickingListNo)
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            cboPickingListNo.Text = ""
            cboPickingListNo.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Display"
#Region "AutoComplete"
    Sub autocompletePickListNo(ByVal icombobox As ComboBox)
        Try
            Dim picklistno As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(pl.picklistno,'') AS 'picklistno' FROM picklist pl WHERE pl.organizationid = " & Z_OrganizationID & " AND pl.verifyflg = 'N' AND (pl.status = 'New' OR pl.status = 'Save Only') GROUP BY pl.picklistno ORDER BY pl.picklistno ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                picklistno.Add(ds.Tables(0).Rows(i)("picklistno").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = picklistno
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub
#End Region
#Region "AutoPopulate"
    Sub autopopulatePickListNo(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(pl.picklistno,'') AS 'picklistno' FROM picklist pl WHERE pl.organizationid = " & Z_OrganizationID & " AND pl.verifyflg = 'N' AND (pl.status = 'New' OR pl.status = 'Save Only') GROUP BY pl.picklistno ORDER BY pl.picklistno ASC "
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
#End Region
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            If LTrim(cboPickingListNo.Text) <> "" Then
                'getPickListIDA(cboPickingListNo.Text, Me)
                splpicklistid = globalpicklistid
                If splpicklistid = 0 Then
                    errProvider.SetError(cboPickingListNo, "This pick list no. has been verified already or not available to verified.")
                    Exit Try
                End If
            Else
                errProvider.SetError(cboPickingListNo, "Please choose or enter the pick list no.")
                Exit Try
            End If
            If myModule.systemerrorfound = False Then
                selecpicklistcue = legit
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
End Class