Imports System.IO
Imports MySql.Data.MySqlClient

Public Class OrganizationForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim fileOpener As OpenFileDialog = New OpenFileDialog()
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim fs As FileStream
    Dim br As BinaryReader
    Dim cue As String
    Dim sqlquery As String
    Dim ImageData() As Byte
    Dim organizationlogo As Object
    Dim orgprimaryaddressid, orgpremiseaddressid, orgcontactid, orgorganizationid As Integer

    Private Sub OrganizationForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            displayOrganizationList()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub OrganizationForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        Try
            myBalloon(, , lblsavemsg, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#Region "Functions"

    Sub callAutoCompleteFunctions()
        autocompleteOrganizationType()
    End Sub

    Sub callAutoPopulateFunctions()
        autopopulateOrganizationType()
    End Sub

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            cue = ""
            clearOrganizationInformation()
            clearOrganizationLogo()
            enableGB(legit, fraud)
            enableANDvisibleMS(fraud)
            dgUsers.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearOrganizationInformation()
        Try
            txtOrganizationName.Text = ""
            txtTradeName.Text = ""
            txtMainPhone.Text = ""
            txtAlternatePhone.Text = ""
            txtEmailAddress.Text = ""
            txtOtherEmail.Text = ""
            txtFaxNo.Text = ""
            txtTIN.Text = ""
            txtWebsite.Text = ""
            txtComments.Text = ""
            txtPrimaryAddress.Text = ""
            txtPremiseAddress.Text = ""
            txtContactPerson.Text = ""
            cboOrganizationType.Text = ""
            cboOrganizationType.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearOrganizationLogo()
        Try
            txtImagePath.Clear()
            pbOrganizationLogo.Image = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean)
        Try
            gbOrganizationList.Enabled = enable1
            gbOrganizationInformation.Enabled = enable2
            gbOrganizationLogo.Enabled = enable2
            gbUsers.Enabled = enable2
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableANDvisibleMS(ByVal enable1 As Boolean)
        Try
            msSave.Enabled = enable1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Click"

    Sub tsrefreshperformclick()
        Try
            errProvider.Clear()
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            displayOrganizationList()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Display "

#Region "AutoComplete "

    Sub autocompleteOrganizationType()
        Try
            Dim organizationtype As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT organizationtype FROM organizations GROUP BY organizationtype ORDER BY organizationtype ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                organizationtype.Add(ds.Tables(0).Rows(i)("organizationtype").ToString())
            Next
            cboOrganizationType.AutoCompleteSource = AutoCompleteSource.CustomSource
            cboOrganizationType.AutoCompleteCustomSource = organizationtype
            cboOrganizationType.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub

#End Region

#Region "AutoPopulate"

    Sub autopopulateOrganizationType()
        Try
            cboOrganizationType.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT organizationtype FROM organizations GROUP BY organizationtype ORDER BY organizationtype  "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                cboOrganizationType.Items.Add(reader1(0).ToString())
            End While
            reader1.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Datagrids"

    Sub displayOrganizationList()
        Try
            dgOrganizationList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT o.rowid,COALESCE(o.name,''),COALESCE(o.tradename,''),COALESCE(o.mainphone,'') FROM organizations o "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgOrganizationList.Rows.Add()
                    dgOrganizationList.Item(o_rowid.Index, n).Value = reader1(0)
                    dgOrganizationList.Item(o_seqno.Index, n).Value = seqno
                    dgOrganizationList.Item(o_orgname.Index, n).Value = reader1(1)
                    dgOrganizationList.Item(o_tradename.Index, n).Value = reader1(2)
                    dgOrganizationList.Item(o_mainphone.Index, n).Value = reader1(3)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgOrganizationList.Columns("o_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgOrganizationList.Columns("o_mainphone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgOrganizationList.Rows.Count <> 0 Then
                dgOrganizationList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayOrganizationInformation(ByVal iorganizationid As Integer)
        Try
            organizationlogo = Nothing
            If conn1.State = ConnectionState.Closed Then conn1.Open()
            Dim sql1 As String = "SELECT COALESCE(o.name,''),COALESCE(o.tradename,''),COALESCE(o.organizationtype,''),COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,'')),''),COALESCE(o.mainphone,''),COALESCE(o.altphone,''),COALESCE(o.emailaddress,'')," &
                        "COALESCE(CONCAT(COALESCE(pa.streetaddress1,''),' ',COALESCE(pa.streetaddress2,''),' ',COALESCE(pa.barangay,''),' ',COALESCE(pa.citytown,''),' ',COALESCE(pa.province,''),' ',COALESCE(pa.state,''),' ',COALESCE(pa.zipcode,''),' ',COALESCE(pa.country,'')),'')," &
                        "COALESCE(CONCAT(COALESCE(ad.streetaddress1,''),' ',COALESCE(ad.streetaddress2,''),' ',COALESCE(ad.barangay,''),' ',COALESCE(ad.citytown,''),' ',COALESCE(ad.province,''),' ',COALESCE(ad.state,''),' ',COALESCE(ad.zipcode,''),' ',COALESCE(ad.country,'')),'')," &
                        "COALESCE(o.altemailaddress,''),COALESCE(o.faxnumber,''),COALESCE(o.tinno,''),COALESCE(o.website,''),COALESCE(o.comments,''),COALESCE(o.primaryaddressid,0),COALESCE(o.premiseaddressid,0),COALESCE(o.primarycontactid,0),o.image FROM organizations o " &
                        "LEFT JOIN contacts c ON o.primarycontactid = c.rowid LEFT JOIN address pa ON o.primaryaddressid = pa.rowid  LEFT JOIN address ad ON o.premiseaddressid = ad.rowid WHERE o.rowid = " & iorganizationid & " "
            Dim cmd1 As New MySqlCommand(sql1, conn1)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    txtOrganizationName.Text = reader1(0)
                    txtTradeName.Text = reader1(1)
                    cboOrganizationType.Text = reader1(2)
                    txtPrimaryAddress.Text = reader1(7)
                    txtPremiseAddress.Text = reader1(8)
                    txtContactPerson.Text = reader1(3)
                    txtMainPhone.Text = reader1(4)
                    txtAlternatePhone.Text = reader1(5)
                    txtEmailAddress.Text = reader1(6)
                    txtOtherEmail.Text = reader1(9)
                    txtFaxNo.Text = reader1(10)
                    txtTIN.Text = reader1(11)
                    txtWebsite.Text = reader1(12)
                    txtComments.Text = reader1(13)
                    orgprimaryaddressid = reader1(14)
                    orgpremiseaddressid = reader1(15)
                    orgcontactid = reader1(16)
                    organizationlogo = reader1(17)
                    If IsDBNull(organizationlogo) Then
                        pbOrganizationLogo.Image = Nothing
                    Else
                        pbOrganizationLogo.Image = ConvertByteToImage(organizationlogo)
                    End If
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn1.Close()
        End Try
    End Sub

    Sub displayOrganizationUsers(ByVal iorganizationid As Integer)
        Try
            dgUsers.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT u.rowid,COALESCE(u.firstname,''),COALESCE(u.middlename,''),COALESCE(u.lastname,''),COALESCE(p.positionname,''),COALESCE(u.emailaddress,'')," &
                        "COALESCE(u.status,'') FROM users u LEFT JOIN positions p ON u.positionid = p.rowid WHERE u.organizationid = " & iorganizationid & " ORDER BY u.firstname "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgUsers.Rows.Add()
                    dgUsers.Item(u_rowid.Index, n).Value = reader1(0)
                    dgUsers.Item(u_seqno.Index, n).Value = seqno
                    dgUsers.Item(u_fname.Index, n).Value = reader1(1)
                    dgUsers.Item(u_mname.Index, n).Value = reader1(2)
                    dgUsers.Item(u_lname.Index, n).Value = reader1(3)
                    dgUsers.Item(u_position.Index, n).Value = reader1(4)
                    dgUsers.Item(u_emailaddress.Index, n).Value = reader1(5)
                    dgUsers.Item(u_status.Index, n).Value = reader1(6)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgUsers.Columns("u_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgUsers.Columns("u_fname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgUsers.Columns("u_mname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgUsers.Columns("u_lname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgUsers.Columns("u_position").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgUsers.Columns("u_emailaddress").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgUsers.Columns("u_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgUsers.Rows.Count <> 0 Then
                dgUsers.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#End Region

#End Region

    Private Sub tabMain_DrawItem(sender As Object, e As DrawItemEventArgs) Handles tabMain.DrawItem
        Try
            TabControlColor(tabMain, e)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If MessageBox.Show("Are you sure you wanted to close this form?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                PrimaryForm.OrgForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsRefresh_Click(sender As Object, e As EventArgs) Handles tsRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            tsrefreshperformclick()
            myBalloon("Successfully Refreshed", "Refresh", lblsavemsg, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgOrganizationList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgOrganizationList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgOrganizationList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearOrganizationInformation()
                clearOrganizationLogo()
                enableGB(legit, legit)
                enableANDvisibleMS(legit)
                dgUsers.Rows.Clear()
                displayOrganizationInformation(CInt(dgOrganizationList.CurrentRow.Cells("o_rowid").Value))
                displayOrganizationUsers(CInt(dgOrganizationList.CurrentRow.Cells("o_rowid").Value))
                If tabMain.SelectedTab Is tabDetails Then
                    txtOrganizationName.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgOrganizationList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgOrganizationList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgOrganizationList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearOrganizationInformation()
                    clearOrganizationLogo()
                    enableGB(legit, legit)
                    enableANDvisibleMS(legit)
                    dgUsers.Rows.Clear()
                    displayOrganizationInformation(CInt(dgOrganizationList.CurrentRow.Cells("o_rowid").Value))
                    displayOrganizationUsers(CInt(dgOrganizationList.CurrentRow.Cells("o_rowid").Value))
                    If tabMain.SelectedTab Is tabDetails Then
                        txtOrganizationName.Focus()
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

    Private Sub txtOrganizationName_Leave(sender As Object, e As EventArgs) Handles txtOrganizationName.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If cue = "Edit" Then
                getOrganizationIDA(CInt(dgOrganizationList.CurrentRow.Cells("o_rowid").Value), txtOrganizationName.Text, Me)
                orgorganizationid = globalorganizationid
                If orgorganizationid <> 0 Then
                    errProvider.SetError(txtOrganizationName, "Organization name has been created already, please type a new one.")
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub txtOrganizationName_TextChanged(sender As Object, e As EventArgs) Handles txtOrganizationName.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If cue = "Edit" Then
    '            getOrganizationIDA(CInt(dgOrganizationList.CurrentRow.Cells("o_rowid").Value), txtOrganizationName.Text, Me)
    '            orgorganizationid = globalorganizationid
    '            If orgorganizationid <> 0 Then
    '                errProvider.SetError(txtOrganizationName, "Organization name has been created already, please type a new one.")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
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
            myBalloon("Automatic adding of organization type.", "Auto-Add", pbAutoAddA, -15, -65)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbEditPrimAddress_MouseEnter(sender As Object, e As EventArgs) Handles pbEditPrimAddress.MouseEnter
        Try
            pbEditPrimAddress.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbEditPrimAddress_MouseLeave(sender As Object, e As EventArgs) Handles pbEditPrimAddress.MouseLeave
        Try
            pbEditPrimAddress.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbEditPremAddress_MouseEnter(sender As Object, e As EventArgs) Handles pbEditPremAddress.MouseEnter
        Try
            pbEditPremAddress.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbEditPremAddress_MouseLeave(sender As Object, e As EventArgs) Handles pbEditPremAddress.MouseLeave
        Try
            pbEditPremAddress.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbEditContactPerson_MouseEnter(sender As Object, e As EventArgs) Handles pbEditContactPerson.MouseEnter
        Try
            pbEditContactPerson.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbEditContactPerson_MouseLeave(sender As Object, e As EventArgs) Handles pbEditContactPerson.MouseLeave
        Try
            pbEditContactPerson.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Sub pbEditPrimAddress_Click(sender As Object, e As EventArgs) Handles pbEditPrimAddress.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Organizations", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.OrgForm = False
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
            If cue = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            Dim addresslinkform As New AddressForm
            addresslinkform.afaddressid = orgprimaryaddressid
            addresslinkform.ShowInTaskbar = False
            addresslinkform.ShowDialog()
            orgprimaryaddressid = addresslinkform.afaddressid
            If orgprimaryaddressid <> 0 Then
                getAddressName(orgprimaryaddressid, Me)
                txtPrimaryAddress.Text = globaladdressname
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub pbEditPremAddress_Click(sender As Object, e As EventArgs) Handles pbEditPremAddress.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Organizations", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.OrgForm = False
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
            If cue = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            Dim addresslinkform As New AddressForm
            addresslinkform.afaddressid = orgpremiseaddressid
            addresslinkform.ShowInTaskbar = False
            addresslinkform.ShowDialog()
            orgpremiseaddressid = addresslinkform.afaddressid
            If orgpremiseaddressid <> 0 Then
                getAddressName(orgpremiseaddressid, Me)
                txtPremiseAddress.Text = globaladdressname
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub pbEditContactPerson_Click(sender As Object, e As EventArgs) Handles pbEditContactPerson.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Organizations", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.OrgForm = False
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
            If cue = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            Dim contactslinkform As New ContactPersonForm
            contactslinkform.cfcontactid = orgcontactid
            contactslinkform.ShowInTaskbar = False
            contactslinkform.ShowDialog()
            orgcontactid = contactslinkform.cfcontactid
            If orgcontactid <> 0 Then
                getContactNameA(orgcontactid, Me)
                txtContactPerson.Text = globalcontactname
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub btnChangeLogo_Click(sender As Object, e As EventArgs) Handles btnChangeLogo.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Organizations", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.OrgForm = False
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
            If cue = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            fileOpener.Filter = "Image files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png"
            If fileOpener.ShowDialog() = Windows.Forms.DialogResult.OK Then
                pbOrganizationLogo.Image = Image.FromFile(fileOpener.FileName)
                txtImagePath.Text = fileOpener.FileName
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub btnRemoveLogo_Click(sender As Object, e As EventArgs) Handles btnRemoveLogo.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Organizations", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.OrgForm = False
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
            If cue = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            If Not IsDBNull(organizationlogo) Then
                If MessageBox.Show("Would you like to permanently delete this image?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    myModule.systemerrorfound = False
                    U_OrganizationImage(CInt(dgOrganizationList.CurrentRow.Cells("o_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, DBNull.Value, Me)
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Delete Image", "Deleted", lblsavemsg, -15, -65)
                        organizationlogo.Image = Nothing
                    End If
                End If
            End If
            If txtImagePath.Text <> "" Then
                txtImagePath.Clear()
                organizationlogo.Image = Nothing
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Organizations", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.OrgForm = False
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
            If cue = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                getOrganizationIDA(CInt(dgOrganizationList.CurrentRow.Cells("o_rowid").Value), txtOrganizationName.Text, Me)
                orgorganizationid = globalorganizationid
            End If
            If myModule.systemerrorfound = True Then
                Exit Try
            End If
            If LTrim(txtOrganizationName.Text) = "" Then
                errProvider.SetError(txtOrganizationName, "Please enter the organization name.")
                txtOrganizationName.Focus()
            ElseIf orgorganizationid <> 0 Then
                errProvider.SetError(txtOrganizationName, "Organization name has been created already, please type a new one")
                txtOrganizationName.Focus()
            Else
                If MessageBox.Show("Would you like to save the changes in this page? ", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    If cue = "Edit" Then
                        If txtImagePath.Text <> "" Then
                            fs = New FileStream(txtImagePath.Text, FileMode.Open, FileAccess.Read)
                            br = New BinaryReader(fs)
                            ImageData = br.ReadBytes(CType(fs.Length, Integer))
                            br.Close()
                            fs.Close()
                        End If
                        U_Organizations(CInt(dgOrganizationList.CurrentRow.Cells("o_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, If(orgprimaryaddressid = 0, DBNull.Value, orgprimaryaddressid), If(orgpremiseaddressid = 0, DBNull.Value, orgpremiseaddressid), If(orgcontactid = 0, DBNull.Value, orgcontactid),
                                txtOrganizationName.Text, txtTradeName.Text, txtMainPhone.Text, txtAlternatePhone.Text, txtFaxNo.Text, txtEmailAddress.Text, txtOtherEmail.Text, txtTIN.Text, txtWebsite.Text, cboOrganizationType.Text, txtComments.Text, If(txtImagePath.Text <> "", ImageData, DBNull.Value), Me)
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                            tsrefreshperformclick()
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

#Region "Datagrid Errors"

    Private Sub dgOrganizationList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgOrganizationList.DataError
        Me.Cursor = Cursors.WaitCursor
        Try
            'MessageBox.Show("Error:  " & e.Context.ToString())
            If (e.Context = DataGridViewDataErrorContexts.Commit) _
                Then
                'MessageBox.Show("Commit error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
                MessageBox.Show("Cell change")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
                MessageBox.Show("parsing error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                ' MessageBox.Show("leave control error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Formatting) Then
                'MessageBox.Show("leave control error")
            End If
            If (TypeOf (e.Exception) Is ConstraintException) Then
                Dim view As DataGridView = CType(sender, DataGridView)
                view.Rows(e.RowIndex).ErrorText = "an error"
                view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                    .ErrorText = "an error"
                MsgBox("error")
                e.ThrowException = False
            End If
            If StrComp(e.Exception.Message, "Input string was not in a correct format.") = 0 Then
                MessageBox.Show("Please Enter a numeric Value")
                'This will change the number back to original
                dgOrganizationList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgUsers_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgUsers.DataError
        Me.Cursor = Cursors.WaitCursor
        Try
            'MessageBox.Show("Error:  " & e.Context.ToString())
            If (e.Context = DataGridViewDataErrorContexts.Commit) _
                Then
                'MessageBox.Show("Commit error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
                MessageBox.Show("Cell change")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
                MessageBox.Show("parsing error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                ' MessageBox.Show("leave control error")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Formatting) Then
                'MessageBox.Show("leave control error")
            End If
            If (TypeOf (e.Exception) Is ConstraintException) Then
                Dim view As DataGridView = CType(sender, DataGridView)
                view.Rows(e.RowIndex).ErrorText = "an error"
                view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                    .ErrorText = "an error"
                MsgBox("error")
                e.ThrowException = False
            End If
            If StrComp(e.Exception.Message, "Input string was not in a correct format.") = 0 Then
                MessageBox.Show("Please Enter a numeric Value")
                'This will change the number back to original
                dgUsers.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

End Class