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
Public Class AddBranchCodeNameForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim bcnbranchid As Integer
    Public addbranchcodenamecue As Boolean = False
    Private Sub AddBranchCodeNameForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            txtBranchCode.Text = ""
            txtBranchName.Text = ""
            txtBranchAddress.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub txtBranchName_TextChanged(sender As Object, e As EventArgs) Handles txtBranchName.TextChanged
    '    Try
    '        errProvider.Clear()
    '        If LTrim(txtBranchName.Text) <> "" Then
    '            getBranchCodeIDA("AND branchname = """ & txtBranchName.Text & """", "AND `status` = 'Active'", Me)
    '            bcnbranchid = globalbranchid
    '            If bcnbranchid <> 0 Then
    '                errProvider.SetError(txtBranchName, "Branch name has been created already, please type a new one.")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    'End Sub
    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            If LTrim(txtBranchName.Text) <> "" Then
                getBranchCodeIDA("AND branchname = """ & txtBranchName.Text & """", "AND `status` = 'Active'", Me)
                bcnbranchid = globalbranchid
                If bcnbranchid <> 0 Then
                    errProvider.SetError(txtBranchName, "Branch name has been created already, please type a new one.")
                    Exit Try
                End If
            Else
                errProvider.SetError(txtBranchName, "Please enter the branch name.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getBranchCodeIDA("AND branchname = """ & txtBranchName.Text & """", "", Me)
                bcnbranchid = globalbranchid
                If bcnbranchid = 0 Then
                    I_Branches(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, txtBranchCode.Text, txtBranchName.Text, txtBranchAddress.Text, "Active", Me)
                Else
                    U_Branches(bcnbranchid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtBranchCode.Text, txtBranchName.Text, txtBranchAddress.Text, "Active", Me)
                End If
                If myModule.systemerrorfound = False Then
                    MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    addbranchcodenamecue = legit
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