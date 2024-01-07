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
Public Class AddTruckShiftForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim atsdeliverytruckid, atsshiftid, atsdeliverytruckshiftid As Integer
    Public addtruckshiftcue As Boolean = False
    Private Sub AddTruckShiftForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            cboTruckInfo.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#Region "Functions"
    Sub callAutoComplete()
        globalautocompleteTruckInfo(cboTruckInfo, Me)
        globalautocompleteShiftInfo(cboShiftInfo, Me)
    End Sub
    Sub callAutoPopulate()
        globalautopopulateTruckInfo(cboTruckInfo, Me)
        globalautopopulateShiftInfo(cboShiftInfo, Me)
    End Sub
#Region "Clear/Enable/Visible"
    Sub clearfields()
        Try
            cboTruckInfo.Text = ""
            cboShiftInfo.Text = ""
            cboTruckInfo.SelectedItem = Nothing
            cboShiftInfo.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#End Region
    Private Sub pbAddTruck_MouseEnter(sender As Object, e As EventArgs) Handles pbAddTruck.MouseEnter
        Try
            pbAddTruck.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddTruck_MouseLeave(sender As Object, e As EventArgs) Handles pbAddTruck.MouseLeave
        Try
            pbAddTruck.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddShift_MouseEnter(sender As Object, e As EventArgs) Handles pbAddShift.MouseEnter
        Try
            pbAddShift.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddShift_MouseLeave(sender As Object, e As EventArgs) Handles pbAddShift.MouseLeave
        Try
            pbAddShift.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub pbAddTruck_Click(sender As Object, e As EventArgs) Handles pbAddTruck.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim addtrucklinkform As New AddTruckForm
            addtrucklinkform.ShowInTaskbar = False
            addtrucklinkform.ShowDialog()
            If addtrucklinkform.addtruckformcue = legit Then
                globalautocompleteTruckInfo(cboTruckInfo, Me)
                globalautopopulateTruckInfo(cboTruckInfo, Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub pbAddShift_Click(sender As Object, e As EventArgs) Handles pbAddShift.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim addshiftlinkform As New AddShiftForm
            addshiftlinkform.ShowInTaskbar = False
            addshiftlinkform.ShowDialog()
            If addshiftlinkform.addshiftformcue = legit Then
                globalautocompleteShiftInfo(cboShiftInfo, Me)
                globalautopopulateShiftInfo(cboShiftInfo, Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cboTruckInfo_TextChanged(sender As Object, e As EventArgs) Handles cboTruckInfo.TextChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(cboTruckInfo.Text) <> "" Then
                getDeliveryTruckIDB(cboTruckInfo.Text, Me)
                atsdeliverytruckid = globaldeliverytruckid
                If atsdeliverytruckid <> 0 Then
                    If LTrim(cboShiftInfo.Text) <> "" Then
                        getShiftIDB(cboShiftInfo.Text, Me)
                        atsshiftid = globalshiftid
                        If atsshiftid <> 0 Then
                            getDeliveryTruckShiftIDA(atsdeliverytruckid, atsshiftid, "AND dts.`status` != 'Inactive'", Me)
                            atsdeliverytruckshiftid = globaldeliverytruckshiftid
                            If atsdeliverytruckshiftid <> 0 Then
                                errProvider.SetError(pbAddTruck, "The truck and shift has been created already.")
                                errProvider.SetError(pbAddShift, "The truck and shift has been created already.")
                            End If
                        End If
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
    Private Sub cboShiftInfo_TextChanged(sender As Object, e As EventArgs) Handles cboShiftInfo.TextChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(cboTruckInfo.Text) <> "" Then
                getDeliveryTruckIDB(cboTruckInfo.Text, Me)
                atsdeliverytruckid = globaldeliverytruckid
                If atsdeliverytruckid <> 0 Then
                    If LTrim(cboShiftInfo.Text) <> "" Then
                        getShiftIDB(cboShiftInfo.Text, Me)
                        atsshiftid = globalshiftid
                        If atsshiftid <> 0 Then
                            getDeliveryTruckShiftIDA(atsdeliverytruckid, atsshiftid, "AND dts.`status` != 'Inactive'", Me)
                            atsdeliverytruckshiftid = globaldeliverytruckshiftid
                            If atsdeliverytruckshiftid <> 0 Then
                                errProvider.SetError(pbAddTruck, "The truck and shift has been created already.")
                                errProvider.SetError(pbAddShift, "The truck and shift has been created already.")
                            End If
                        End If
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
    Private Sub cboTruckInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTruckInfo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(cboTruckInfo.Text) <> "" Then
                getDeliveryTruckIDB(cboTruckInfo.Text, Me)
                atsdeliverytruckid = globaldeliverytruckid
                If atsdeliverytruckid <> 0 Then
                    If LTrim(cboShiftInfo.Text) <> "" Then
                        getShiftIDB(cboShiftInfo.Text, Me)
                        atsshiftid = globalshiftid
                        If atsshiftid <> 0 Then
                            getDeliveryTruckShiftIDA(atsdeliverytruckid, atsshiftid, "AND dts.`status` != 'Inactive'", Me)
                            atsdeliverytruckshiftid = globaldeliverytruckshiftid
                            If atsdeliverytruckshiftid <> 0 Then
                                errProvider.SetError(pbAddTruck, "The truck and shift has been created already.")
                                errProvider.SetError(pbAddShift, "The truck and shift has been created already.")
                            End If
                        End If
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
    Private Sub cboShiftInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShiftInfo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(cboTruckInfo.Text) <> "" Then
                getDeliveryTruckIDB(cboTruckInfo.Text, Me)
                atsdeliverytruckid = globaldeliverytruckid
                If atsdeliverytruckid <> 0 Then
                    If LTrim(cboShiftInfo.Text) <> "" Then
                        getShiftIDB(cboShiftInfo.Text, Me)
                        atsshiftid = globalshiftid
                        If atsshiftid <> 0 Then
                            getDeliveryTruckShiftIDA(atsdeliverytruckid, atsshiftid, "AND dts.`status` != 'Inactive'", Me)
                            atsdeliverytruckshiftid = globaldeliverytruckshiftid
                            If atsdeliverytruckshiftid <> 0 Then
                                errProvider.SetError(pbAddTruck, "The truck and shift has been created already.")
                                errProvider.SetError(pbAddShift, "The truck and shift has been created already.")
                            End If
                        End If
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
    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            If LTrim(cboTruckInfo.Text) <> "" Then
                getDeliveryTruckIDB(cboTruckInfo.Text, Me)
                atsdeliverytruckid = globaldeliverytruckid
                If atsdeliverytruckid = 0 Then
                    errProvider.SetError(pbAddTruck, "The truck info might be unavailable or inactive at this moment.")
                    cboTruckInfo.Focus()
                    Exit Try
                End If
            Else
                errProvider.SetError(pbAddTruck, "Please enter the truck info.")
                cboTruckInfo.Focus()
                Exit Try
            End If
            If LTrim(cboShiftInfo.Text) <> "" Then
                getShiftIDB(cboShiftInfo.Text, Me)
                atsshiftid = globalshiftid
                If atsshiftid = 0 Then
                    errProvider.SetError(pbAddShift, "The shift info might be unavailable or inactive at this moment.")
                    cboShiftInfo.Focus()
                    Exit Try
                End If
            Else
                errProvider.SetError(pbAddShift, "Please enter the shift info.")
                cboShiftInfo.Focus()
                Exit Try
            End If
            getDeliveryTruckShiftIDA(atsdeliverytruckid, atsshiftid, "AND dts.`status` != 'Inactive'", Me)
            atsdeliverytruckshiftid = globaldeliverytruckshiftid
            If atsdeliverytruckshiftid <> 0 Then
                errProvider.SetError(pbAddTruck, "The truck and shift has been created already.")
                errProvider.SetError(pbAddShift, "The truck and shift has been created already.")
                Exit Try
            End If
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If LTrim(cboTruckInfo.Text) <> "" Then
                    getDeliveryTruckIDB(cboTruckInfo.Text, Me)
                    atsdeliverytruckid = globaldeliverytruckid
                    If atsdeliverytruckid = 0 Then
                        errProvider.SetError(pbAddTruck, "The truck info might be unavailable or inactive at this moment.")
                        cboTruckInfo.Focus()
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddTruck, "Please enter the truck info.")
                    cboTruckInfo.Focus()
                    Exit Try
                End If
                If LTrim(cboShiftInfo.Text) <> "" Then
                    getShiftIDB(cboShiftInfo.Text, Me)
                    atsshiftid = globalshiftid
                    If atsshiftid = 0 Then
                        errProvider.SetError(pbAddShift, "The shift info might be unavailable or inactive at this moment.")
                        cboShiftInfo.Focus()
                        Exit Try
                    End If
                Else
                    errProvider.SetError(pbAddShift, "Please enter the shift info.")
                    cboShiftInfo.Focus()
                    Exit Try
                End If
                getDeliveryTruckShiftIDA(atsdeliverytruckid, atsshiftid, "AND dts.`status` != 'Inactive'", Me)
                atsdeliverytruckshiftid = globaldeliverytruckshiftid
                If atsdeliverytruckshiftid <> 0 Then
                    errProvider.SetError(pbAddTruck, "The truck and shift has been created already.")
                    errProvider.SetError(pbAddShift, "The truck and shift has been created already.")
                End If
                getDeliveryTruckShiftIDA(atsdeliverytruckid, atsshiftid, "", Me)
                atsdeliverytruckshiftid = globaldeliverytruckshiftid
                If atsdeliverytruckshiftid = 0 Then
                    I_DeliveryTruckShifts(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, atsdeliverytruckid, atsshiftid, "Active", Me)
                Else
                    U_DeliveryTruckShift(atsdeliverytruckshiftid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, atsdeliverytruckid, atsshiftid, "Active", Me)
                End If
                If myModule.systemerrorfound = False Then
                    MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    addtruckshiftcue = legit
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