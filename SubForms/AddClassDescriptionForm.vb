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
Public Class AddClassDescriptionForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim cdcombinecodingid, cdcodingida, cdcodingidb, cdcodingidc As Integer
    Public addclassdescriptioncue As Boolean = False
    Private Sub AddClassDescriptionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            cboCodeA.Text = ""
            cboCodeA.SelectedItem = Nothing
            cboCodeB.Text = ""
            cboCodeB.SelectedItem = Nothing
            cboCodeC.Text = ""
            cboCodeC.SelectedItem = Nothing
            txtClassName.Text = ""
            globalautocompleteCodings(cboCodeA, "AND co.codetype = 'DEPT CODE'", Me)
            globalautocompleteCodings(cboCodeB, "AND co.codetype = 'SUB DEPT CODE'", Me)
            globalautocompleteCodings(cboCodeC, "AND co.codetype = 'CLASS CODE'", Me)
            globalautopopulateCodings(cboCodeA, "AND co.codetype = 'DEPT CODE'", Me)
            globalautopopulateCodings(cboCodeB, "AND co.codetype = 'SUB DEPT CODE'", Me)
            globalautopopulateCodings(cboCodeC, "AND co.codetype = 'CLASS CODE'", Me)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub txtClassName_TextChanged(sender As Object, e As EventArgs) Handles txtClassName.TextChanged
    '    Try
    '        errProvider.Clear()
    '        If LTrim(txtClassName.Text) <> "" Then
    '            getCombineCodingsIDA(txtClassName.Text, "AND `status` = 'Active'", Me)
    '            cdcombinecodingid = globalcombinecodingid
    '            If cdcombinecodingid <> 0 Then
    '                errProvider.SetError(txtClassName, "Class name has been created already, please type a new one.")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    'End Sub
    Private Sub msAdd_Click(sender As Object, e As EventArgs) Handles msAdd.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim addcodelinkform As New AddCodeForm
            addcodelinkform.ShowInTaskbar = False
            addcodelinkform.ShowDialog()
            If addcodelinkform.addcodecue = legit Then
                globalautocompleteCodings(cboCodeA, "AND co.codetype = 'DEPT CODE'", Me)
                globalautocompleteCodings(cboCodeB, "AND co.codetype = 'SUB DEPT CODE'", Me)
                globalautocompleteCodings(cboCodeC, "AND co.codetype = 'CLASS CODE'", Me)
                globalautopopulateCodings(cboCodeA, "AND co.codetype = 'DEPT CODE'", Me)
                globalautopopulateCodings(cboCodeB, "AND co.codetype = 'SUB DEPT CODE'", Me)
                globalautopopulateCodings(cboCodeC, "AND co.codetype = 'CLASS CODE'", Me)
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
            If LTrim(txtClassName.Text) <> "" Then
                'getCombineCodingsIDA(txtClassName.Text, "AND `status` = 'Active'", Me)
                'cdcombinecodingid = globalcombinecodingid
                'If cdcombinecodingid <> 0 Then
                '    errProvider.SetError(txtClassName, "Class name has been created already, please type a new one.")
                '    Exit Try
                'End If
            Else
                errProvider.SetError(txtClassName, "Please enter the class name.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getCodingsIDB(cboCodeA.Text, Me)
                cdcodingida = globalcodingid
                getCodingsIDB(cboCodeB.Text, Me)
                cdcodingidb = globalcodingid
                getCodingsIDB(cboCodeC.Text, Me)
                cdcodingidc = globalcodingid
                I_CombineCodings(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, If(cdcodingida = 0, DBNull.Value, cdcodingida), If(cdcodingidb = 0, DBNull.Value, cdcodingidb), If(cdcodingidc = 0, DBNull.Value, cdcodingidc), txtClassName.Text, "Active", Me)
                'getCombineCodingsIDA(txtClassName.Text, "", Me)
                'cdcombinecodingid = globalcombinecodingid
                'If cdcombinecodingid = 0 Then
                '    I_CombineCodings(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, If(cdcodingida = 0, DBNull.Value, cdcodingida), If(cdcodingidb = 0, DBNull.Value, cdcodingidb), If(cdcodingidc = 0, DBNull.Value, cdcodingidc), txtClassName.Text, "Active", Me)
                'Else
                '    U_CombineCodings(cdcombinecodingid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(cdcodingida = 0, DBNull.Value, cdcodingida), If(cdcodingidb = 0, DBNull.Value, cdcodingidb), If(cdcodingidc = 0, DBNull.Value, cdcodingidc), txtClassName.Text, "Active", Me)
                'End If
                If myModule.systemerrorfound = False Then
                    MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    addclassdescriptioncue = legit
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