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
Public Class AddCodeForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim accodingid As Integer
    Public addcodecue As Boolean = False
    Private Sub AddCodeForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            cboCodeType.Text = ""
            cboCodeType.SelectedItem = Nothing
            txtCodeNo.Text = ""
            txtCodeName.Text = ""
            autopopulateCodeType(cboCodeType)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub autopopulateCodeType(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(lv.lic,'') AS 'codetype' FROM listofvalues lv WHERE lv.`status` = 'Active' AND lv.`type` = 'Code Type' GROUP BY lv.lic ORDER BY lv.lic "
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
    'Private Sub cboCodeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCodeType.SelectedIndexChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If LTrim(cboCodeType.Text) <> "" Then
    '            If LTrim(txtCodeNo.Text) <> "" Then
    '                getCodingsIDA(txtCodeNo.Text, cboCodeType.Text, "AND `status` = 'Active'", Me)
    '                accodingid = globalcodingid
    '                If accodingid <> 0 Then
    '                    errProvider.SetError(cboCodeType, "Code type and code no. has been created already, please type a new one.")
    '                    errProvider.SetError(txtCodeNo, "Code type and code no. has been created already, please type a new one.")
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    'Private Sub cboCodeType_TextChanged(sender As Object, e As EventArgs) Handles cboCodeType.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If LTrim(cboCodeType.Text) <> "" Then
    '            If LTrim(txtCodeNo.Text) <> "" Then
    '                getCodingsIDA(txtCodeNo.Text, cboCodeType.Text, "AND `status` = 'Active'", Me)
    '                accodingid = globalcodingid
    '                If accodingid <> 0 Then
    '                    errProvider.SetError(cboCodeType, "Code type and code no. has been created already, please type a new one.")
    '                    errProvider.SetError(txtCodeNo, "Code type and code no. has been created already, please type a new one.")
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    'Private Sub txtCodeNo_TextChanged(sender As Object, e As EventArgs) Handles txtCodeNo.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If LTrim(cboCodeType.Text) <> "" Then
    '            If LTrim(txtCodeNo.Text) <> "" Then
    '                getCodingsIDA(txtCodeNo.Text, cboCodeType.Text, "AND `status` = 'Active'", Me)
    '                accodingid = globalcodingid
    '                If accodingid <> 0 Then
    '                    errProvider.SetError(cboCodeType, "Code type and code no. has been created already, please type a new one.")
    '                    errProvider.SetError(txtCodeNo, "Code type and code no. has been created already, please type a new one.")
    '                End If
    '            End If
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
            If LTrim(cboCodeType.Text) <> "" Then
                If LTrim(txtCodeNo.Text) <> "" Then
                    getCodingsIDA(txtCodeNo.Text, cboCodeType.Text, "AND `status` = 'Active'", Me)
                    accodingid = globalcodingid
                    If accodingid <> 0 Then
                        errProvider.SetError(cboCodeType, "Code type and code no. has been created already, please type a new one.")
                        errProvider.SetError(txtCodeNo, "Code type and code no. has been created already, please type a new one.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(txtCodeNo, "Please enter the code no.")
                    Exit Try
                End If
            Else
                errProvider.SetError(cboCodeType, "Please enter the code type.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getCodingsIDA(txtCodeNo.Text, cboCodeType.Text, "", Me)
                accodingid = globalcodingid
                If accodingid = 0 Then
                    I_Codings(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cboCodeType.Text, txtCodeNo.Text, txtCodeName.Text, "Active", Me)
                Else
                    U_Codings(accodingid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, cboCodeType.Text, txtCodeNo.Text, txtCodeName.Text, "Active", Me)
                End If
                If myModule.systemerrorfound = False Then
                    MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    addcodecue = legit
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