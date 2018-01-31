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
Public Class AddSizeForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim ascartonsizeid As Integer
    Public addsizeformcue As Boolean = False
    Private Sub AddSizeForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub AddSizeForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            myBalloon(, , pbAutoAddA, , , 1)
            myBalloon(, , pbAutoAddB, , , 1)
            myBalloon(, , pbAutoAddC, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub callAutoCompleteFunctions()
        globalautocompleteListOfValues(cboLengthUOM, "Unit Of Measure", Me)
        globalautocompleteListOfValues(cboWidthUOM, "Unit Of Measure", Me)
        globalautocompleteListOfValues(cboHeightUOM, "Unit Of Measure", Me)
    End Sub
    Sub callAutoPopulateFunctions()
        globalautopopulateListOfValues(cboLengthUOM, "Unit Of Measure", Me)
        globalautopopulateListOfValues(cboWidthUOM, "Unit Of Measure", Me)
        globalautopopulateListOfValues(cboHeightUOM, "Unit Of Measure", Me)
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            txtSizeName.Text = ""
            txtLength.Text = ""
            cboLengthUOM.Text = ""
            txtWidth.Text = ""
            cboWidthUOM.Text = ""
            txtHeight.Text = ""
            cboHeightUOM.Text = ""
            cboLengthUOM.SelectedItem = Nothing
            cboWidthUOM.SelectedItem = Nothing
            cboHeightUOM.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#End Region
    Private Sub pbAutoAddA_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddA.MouseEnter
        Try
            pbAutoAddA.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddA_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddA.MouseLeave
        Try
            pbAutoAddA.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddA_Click(sender As Object, e As EventArgs) Handles pbAutoAddA.Click
        Try
            myBalloon("Automatic adding of unit of measure.", "Auto-Add", pbAutoAddA, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddB_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddB.MouseEnter
        Try
            pbAutoAddB.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddB_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddB.MouseLeave
        Try
            pbAutoAddB.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddB_Click(sender As Object, e As EventArgs) Handles pbAutoAddB.Click
        Try
            myBalloon("Automatic adding of unit of measure.", "Auto-Add", pbAutoAddB, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddC_MouseEnter(sender As Object, e As EventArgs) Handles pbAutoAddC.MouseEnter
        Try
            pbAutoAddC.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddC_MouseLeave(sender As Object, e As EventArgs) Handles pbAutoAddC.MouseLeave
        Try
            pbAutoAddC.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAutoAddC_Click(sender As Object, e As EventArgs) Handles pbAutoAddC.Click
        Try
            myBalloon("Automatic adding of unit of measure.", "Auto-Add", pbAutoAddC, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    'Private Sub txtSizeName_TextChanged(sender As Object, e As EventArgs) Handles txtSizeName.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        getCartonSizeIDA(txtSizeName.Text, "AND `status` = 'Active'", Me)
    '        ascartonsizeid = globalcartonsizeid
    '        If ascartonsizeid <> 0 Then
    '            errProvider.SetError(txtSizeName, "The size name has been created already, please type a new one.")
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
            If LTrim(txtSizeName.Text) = "" Then
                errProvider.SetError(txtSizeName, "Please enter the size name.")
                txtSizeName.Focus()
                Exit Try
            End If
            getCartonSizeIDA(txtSizeName.Text, "AND `status` = 'Active'", Me)
            ascartonsizeid = globalcartonsizeid
            If ascartonsizeid <> 0 Then
                errProvider.SetError(txtSizeName, "The size name has been created already, please type a new one.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getCartonSizeIDA(txtSizeName.Text, "AND `status` = 'Active'", Me)
                ascartonsizeid = globalcartonsizeid
                If ascartonsizeid <> 0 Then
                    errProvider.SetError(txtSizeName, "The size name has been created already, please type a new one.")
                    Exit Try
                End If
                getCartonSizeIDA(txtSizeName.Text, "", Me)
                ascartonsizeid = globalcartonsizeid
                If ascartonsizeid <> 0 Then
                    U_CartonSizes(ascartonsizeid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(IsNumeric(txtLength.Text), CDec(txtLength.Text), 0.0), If(IsNumeric(txtWidth.Text), CDec(txtWidth.Text), 0.0), _
                            If(IsNumeric(txtHeight.Text), CDec(txtHeight.Text), 0.0), cboLengthUOM.Text, cboWidthUOM.Text, cboHeightUOM.Text, "Active", Me)
                Else
                    I_CartonSizes(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, txtSizeName.Text, If(IsNumeric(txtLength.Text), CDec(txtLength.Text), 0.0), _
                            If(IsNumeric(txtWidth.Text), CDec(txtWidth.Text), 0.0), If(IsNumeric(txtHeight.Text), CDec(txtHeight.Text), 0.0), cboLengthUOM.Text, cboWidthUOM.Text, cboHeightUOM.Text, "Active", Me)
                End If
                getListOfValuesID(cboLengthUOM.Text, "Unit Of Measure", Me)
                If globallistofvaluesid = 0 Then
                    I_ListOfValues(Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cboLengthUOM.Text, cboLengthUOM.Text, "Unit Of Measure", "", "", "Active", "N", "Y", DBNull.Value, Me)
                End If
                getListOfValuesID(cboWidthUOM.Text, "Unit Of Measure", Me)
                If globallistofvaluesid = 0 Then
                    I_ListOfValues(Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cboWidthUOM.Text, cboWidthUOM.Text, "Unit Of Measure", "", "", "Active", "N", "Y", DBNull.Value, Me)
                End If
                getListOfValuesID(cboHeightUOM.Text, "Unit Of Measure", Me)
                If globallistofvaluesid = 0 Then
                    I_ListOfValues(Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cboHeightUOM.Text, cboHeightUOM.Text, "Unit Of Measure", "", "", "Active", "N", "Y", DBNull.Value, Me)
                End If
                If myModule.systemerrorfound = False Then
                    MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    addsizeformcue = legit
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