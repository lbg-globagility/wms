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
Public Class AddVendorCodeNameForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim vcnvendorid As Integer
    Public addvendorcodenamecue As Boolean = False
    Private Sub AddVendorCodeNameForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            txtVendorCode.Text = ""
            txtVendorName.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub txtVendorCode_TextChanged(sender As Object, e As EventArgs) Handles txtVendorCode.TextChanged
    '    Try
    '        errProvider.Clear()
    '        If LTrim(txtVendorCode.Text) <> "" Then
    '            getCompanyIDA("AND companycode = """ & txtVendorCode.Text & """", "AND `status` = 'Active'", Me)
    '            vcnvendorid = globalcompanyid
    '            If vcnvendorid <> 0 Then
    '                errProvider.SetError(txtVendorCode, "Vendor code has been created already, please type a new one.")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    'End Sub
    'Private Sub txtVendorName_TextChanged(sender As Object, e As EventArgs) Handles txtVendorName.TextChanged
    '    Try
    '        errProvider.Clear()
    '        If LTrim(txtVendorName.Text) <> "" Then
    '            getCompanyIDA("AND companyname = """ & txtVendorName.Text & """", "AND `status` = 'Active'", Me)
    '            vcnvendorid = globalcompanyid
    '            If vcnvendorid <> 0 Then
    '                errProvider.SetError(txtVendorName, "Vendor name has been created already, please type a new one.")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    'End Sub
    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            'If LTrim(txtVendorCode.Text) <> "" Then
            '    getCompanyIDA("AND companycode = """ & txtVendorCode.Text & """", "AND `status` = 'Active'", Me)
            '    vcnvendorid = globalcompanyid
            '    If vcnvendorid <> 0 Then
            '        errProvider.SetError(txtVendorCode, "Vendor code has been created already, please type a new one.")
            '    End If
            'End If
            'If LTrim(txtVendorName.Text) <> "" Then
            '    getCompanyIDA("AND companyname = """ & txtVendorName.Text & """", "AND `status` = 'Active'", Me)
            '    vcnvendorid = globalcompanyid
            '    If vcnvendorid <> 0 Then
            '        errProvider.SetError(txtVendorName, "Vendor name has been created already, please type a new one.")
            '    End If
            'Else
            '    errProvider.SetError(txtVendorName, "Please enter the vendor name.")
            '    Exit Try
            'End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                'getCompanyIDA("AND companyname = """ & txtVendorName.Text & """", "", Me)
                'vcnvendorid = globalcompanyid
                'If vcnvendorid = 0 Then
                '    I_Companies(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, txtVendorCode.Text, txtVendorName.Text, "Active", Me)
                'Else
                '    U_Companies(vcnvendorid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtVendorCode.Text, txtVendorName.Text, "Active", Me)
                'End If
                I_Companies(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, txtVendorCode.Text, txtVendorName.Text, "Active", Me)
                If myModule.systemerrorfound = False Then
                    MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    addvendorcodenamecue = legit
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