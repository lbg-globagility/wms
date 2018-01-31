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
Public Class AddShiftForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim adshiftid As Integer
    Public addshiftformcue As Boolean = False
    Private Sub AddShiftForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            dtpTimeFrom.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0)
            dtpTimeTo.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0)
            txtShiftName.Text = ""
            txtShiftName.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub txtShiftName_TextChanged(sender As Object, e As EventArgs) Handles txtShiftName.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        getShiftIDA(txtShiftName.Text, "AND `status` = 'Active'", Me)
    '        adshiftid = globalshiftid
    '        If adshiftid <> 0 Then
    '            errProvider.SetError(txtShiftName, "The shift name has been created already, please type a new one.")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            If LTrim(txtShiftName.Text) = "" Then
                errProvider.SetError(txtShiftName, "Please enter the shift name.")
                txtShiftName.Focus()
                Exit Try
            End If
            getShiftIDA(txtShiftName.Text, "AND `status` = 'Active'", Me)
            adshiftid = globalshiftid
            If adshiftid <> 0 Then
                errProvider.SetError(txtShiftName, "The shift name has been created already, please type a new one.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getShiftIDA(txtShiftName.Text, "AND `status` = 'Active'", Me)
                adshiftid = globalshiftid
                If adshiftid <> 0 Then
                    errProvider.SetError(txtShiftName, "The shift name has been created already, please type a new one.")
                    Exit Try
                End If
                getShiftIDA(txtShiftName.Text, "", Me)
                adshiftid = globalshiftid
                If adshiftid <> 0 Then
                    U_Shifts(adshiftid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, txtShiftName.Text, dtpTimeFrom.Value, dtpTimeTo.Value, "Active", Me)
                Else
                    I_Shifts(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, txtShiftName.Text, dtpTimeFrom.Value, dtpTimeTo.Value, "Active", Me)
                End If
                If myModule.systemerrorfound = False Then
                    MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    addshiftformcue = legit
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