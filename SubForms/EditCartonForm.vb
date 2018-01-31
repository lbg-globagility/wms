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
Public Class EditCartonForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim itemno, rowscount As Integer
    Dim eccheckpackinglistcartonid As Integer
    Public editcartonformcue As Boolean = False
    Public ecpackinglistcartonid, ecpackinglistid As Integer
    Private Sub EditCartonForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            getPackingListCartonInfo(ecpackinglistcartonid, Me)
            txtCartonNo.Text = globalpackedcartonno
            cboPackerName.Text = globalpackername
            dtpPackedDate.Text = globalpackeddate
            cboSizeInfo.Text = globalpackedsizeinfo
            txtWeight.Text = globalpackedweight
            cboWeightUOM.Text = globalpackedweightuom
            txtAmount.Text = globalpackedamount
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub EditCartonForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            myBalloon(, , pbAutoAddA, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub callAutoCompleteFunctions()
        globalautocompleteContactName(cboPackerName, "Packer", Me)
        globalautocompleteSizeInfo(cboSizeInfo, Me)
        globalautocompleteListOfValues(cboWeightUOM, "Unit Of Measure", Me)
    End Sub
    Sub callAutoPopulateFunctions()
        globalautopopulateContactName(cboPackerName, "Packer", Me)
        globalautopopulateSizeInfo(cboSizeInfo, Me)
        globalautocompleteListOfValues(cboWeightUOM, "Unit Of Measure", Me)
    End Sub
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
    Private Sub pbAddPacker_MouseEnter(sender As Object, e As EventArgs) Handles pbAddPacker.MouseEnter
        Try
            pbAddPacker.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddPacker_MouseLeave(sender As Object, e As EventArgs) Handles pbAddPacker.MouseLeave
        Try
            pbAddPacker.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddPacker_Click(sender As Object, e As EventArgs) Handles pbAddPacker.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
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
            Dim addpackerlinkform As New AddPackerForm
            addpackerlinkform.ShowInTaskbar = False
            addpackerlinkform.ShowDialog()
            If addpackerlinkform.addpackerformcue = legit Then
                globalautocompleteContactName(cboPackerName, "Packer", Me)
                globalautopopulateContactName(cboPackerName, "Packer", Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub pbAddSize_MouseEnter(sender As Object, e As EventArgs) Handles pbAddSize.MouseEnter
        Try
            pbAddSize.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddSize_MouseLeave(sender As Object, e As EventArgs) Handles pbAddSize.MouseLeave
        Try
            pbAddSize.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddSize_Click(sender As Object, e As EventArgs) Handles pbAddSize.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
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
            Dim addsizelinkform As New AddSizeForm
            addsizelinkform.ShowInTaskbar = False
            addsizelinkform.ShowDialog()
            If addsizelinkform.addsizeformcue = legit Then
                globalautocompleteSizeInfo(cboSizeInfo, Me)
                globalautopopulateSizeInfo(cboSizeInfo, Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub txtCartonNo_TextChanged(sender As Object, e As EventArgs) Handles txtCartonNo.TextChanged
    '    Try
    '        errProvider.Clear()
    '        If LTrim(txtCartonNo.Text) <> "" Then
    '            getPackingListCartonIDB(ecpackinglistcartonid, ecpackinglistid, txtCartonNo.Text, "AND 'status' != 'Inactive'", Me)
    '            eccheckpackinglistcartonid = globalpackinglistcartonid
    '            If eccheckpackinglistcartonid <> 0 Then
    '                errProvider.SetError(txtCartonNo, "The box no. has been created already.")
    '            End If
    '        Else
    '            errProvider.SetError(txtCartonNo, "Please enter the box no.")
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
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Packing List", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
                If globalreadonlyflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If globalcreateflg = "Y" Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            Else
                MessageBox.Show("System cannot find the position of the user.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If ecpackinglistid = 0 Then
                MessageBox.Show("System cannot find the packing list.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If ecpackinglistcartonid = 0 Then
                MessageBox.Show("System cannot find the box.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            getPackingListCartonStatus(ecpackinglistcartonid, Me)
            If globalpackinglistcartonstatus <> "Active" Then
                MessageBox.Show("The status of this box has been updated, click the pick list again to check the status.", "Editing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If
            If LTrim(txtCartonNo.Text) <> "" Then
                getPackingListCartonIDB(ecpackinglistcartonid, ecpackinglistid, txtCartonNo.Text, "AND 'status' != 'Inactive'", Me)
                eccheckpackinglistcartonid = globalpackinglistcartonid
                If eccheckpackinglistcartonid <> 0 Then
                    errProvider.SetError(txtCartonNo, "The box no. has been created already.")
                    Exit Try
                End If
            Else
                errProvider.SetError(txtCartonNo, "Please enter the box no.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                getPackingListCartonStatus(ecpackinglistcartonid, Me)
                If globalpackinglistcartonstatus <> "Active" Then
                    MessageBox.Show("The status of this box has been updated, click the pick list again to check the status.", "Editing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                getPackingListCartonIDB(ecpackinglistcartonid, ecpackinglistid, txtCartonNo.Text, "AND 'status' != 'Inactive'", Me)
                eccheckpackinglistcartonid = globalpackinglistcartonid
                If eccheckpackinglistcartonid <> 0 Then
                    errProvider.SetError(txtCartonNo, "The box no. has been created already.")
                    Exit Try
                End If
                getContactID(cboPackerName.Text, "Packer", Me)
                getCartonSizeIDB(cboSizeInfo.Text, Me)
                U_PackingListCartons(ecpackinglistcartonid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(globalcontactid = 0, DBNull.Value, globalcontactid), If(globalcartonsizeid = 0, DBNull.Value, globalcartonsizeid), _
                        txtCartonNo.Text, dtpPackedDate.Value, cboWeightUOM.Text, If(IsNumeric(txtWeight.Text), CDec(txtWeight.Text), 0.0), If(IsNumeric(txtAmount.Text), CDec(txtAmount.Text), 0.0), Me)
                If myModule.systemerrorfound = False Then
                    getListOfValuesID(cboWeightUOM.Text, "Unit Of Measure", Me)
                    If globallistofvaluesid = 0 Then
                        I_ListOfValues(Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, cboWeightUOM.Text, cboWeightUOM.Text, "Unit Of Measure", "", "", "Active", "N", "Y", DBNull.Value, Me)
                    End If
                    MessageBox.Show("Successfully Updated.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    editcartonformcue = legit
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