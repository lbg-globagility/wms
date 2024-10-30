Imports MySql.Data.MySqlClient

Public Class ContactsForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim cue As String
    Dim sqlquery As String
    Dim itemno, rowscount As Integer
    Dim spagenumA, countpagenumA, numofpagesA, validpagesA As Integer
    Dim spagenumB, countpagenumB, numofpagesB, validpagesB As Integer
    Dim spagenumC, countpagenumC, numofpagesC, validpagesC As Integer
    Dim pageequation1, pageequation2, pageequation3, additionalpage As Decimal

    Private Sub ContactsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            displayPickerList(spagenumA)
            pageSetupA()
            txtPageNoPickerList.Text = "" & numofpagesA & " of " & validpagesA & " "
            displayPackerList(spagenumB)
            pageSetupB()
            txtPageNoPackerList.Text = "" & numofpagesB & " of " & validpagesB & " "
            displayDriverList(spagenumC)
            pageSetupC()
            txtPageNoDriverList.Text = "" & numofpagesC & " of " & validpagesC & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ContactsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Sub callAutoComplete()
        autocompleteSuffix(cboSuffix)
        autocompleteSalutation(cboSalutation)
        autocompleteGender(cboGender)
        autocompleteCivilStatus(cboCivilStatus)
    End Sub

    Sub callAutoPopulate()
        autopopulateContactType()
        autopopulateSuffix(cboSuffix)
        autopopulateSalutation(cboSalutation)
        autopopulateGender(cboGender)
        autopopulateCivilStatus(cboCivilStatus)
        autopopulateStatus(cboStatus)
    End Sub

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            cue = ""
            spagenumA = neutralpage : numofpagesA = startingpage
            spagenumB = neutralpage : numofpagesB = startingpage
            spagenumC = neutralpage : numofpagesC = startingpage
            clearContactInformation()
            enableGB(legit)
            enableFields(fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearRightPage()
        Try
            cue = ""
            clearContactInformation()
            enableGB(legit)
            enableFields(fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearContactInformation()
        Try
            txtContactNo.Text = ""
            txtFName.Text = ""
            txtMName.Text = ""
            txtLName.Text = ""
            cboSuffix.Text = ""
            txtNickName.Text = ""
            cboSalutation.Text = ""
            cboGender.Text = ""
            cboCivilStatus.Text = ""
            txtMainPhone.Text = ""
            txtFaxNo.Text = ""
            txtAlternatePhone.Text = ""
            txtTIN.Text = ""
            dtpBirthday.Value = Now.Date
            txtEmailAddress.Text = ""
            txtComments.Text = ""
            cboStatus.Text = ""
            cboContactType.Text = ""
            cboContactType.SelectedItem = Nothing
            cboSuffix.SelectedItem = Nothing
            cboSalutation.SelectedItem = Nothing
            cboGender.SelectedItem = Nothing
            cboCivilStatus.SelectedItem = Nothing
            cboStatus.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean)
        Try
            gbPickerList.Enabled = enable1
            gbPackerList.Enabled = enable1
            gbDriverList.Enabled = enable1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableFields(ByVal enable1 As Boolean, ByVal enable2 As Boolean)
        Try
            cboContactType.Enabled = enable2
            txtFName.Enabled = enable1
            txtMName.Enabled = enable1
            txtLName.Enabled = enable1
            cboSalutation.Enabled = enable1
            cboSuffix.Enabled = enable1
            txtNickName.Enabled = enable1
            cboGender.Enabled = enable1
            cboCivilStatus.Enabled = enable1
            txtTIN.Enabled = enable1
            txtMainPhone.Enabled = enable1
            txtAlternatePhone.Enabled = enable1
            txtFaxNo.Enabled = enable1
            dtpBirthday.Enabled = enable1
            cboStatus.Enabled = enable1
            txtComments.Enabled = enable1
            txtEmailAddress.Enabled = enable1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableANDvisibleMS(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal visible1 As Boolean)
        Try
            msNew.Enabled = enable1
            msSave.Enabled = enable2
            msCancel.Visible = visible1
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
            callAutoComplete()
            callAutoPopulate()
            displayPickerList(spagenumA)
            pageSetupA()
            txtPageNoPickerList.Text = "" & numofpagesA & " of " & validpagesA & " "
            displayPackerList(spagenumB)
            pageSetupB()
            txtPageNoPackerList.Text = "" & numofpagesB & " of " & validpagesB & " "
            displayDriverList(spagenumC)
            pageSetupC()
            txtPageNoDriverList.Text = "" & numofpagesC & " of " & validpagesC & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Page Setup"

    Sub pageSetupA()
        Try
            getCountPageNumA()
            If countpagenumA < pagedivisor Then
                validpagesA = startingpage
            Else
                additionalpage = countpagenumA / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpagesA = countpagenumA / pagedivisor
                Else
                    validpagesA = countpagenumA / pagedivisor
                    validpagesA = validpagesA + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNumA()
        Try
            countpagenumA = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(p.rowid),0) FROM contacts p WHERE p.organizationid = " & Z_OrganizationID & " AND p.`type` = 'Picker' ")
            If dtCid.Rows.Count <> 0 Then
                countpagenumA = dtCid.Rows(0)(0)
            Else
                countpagenumA = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub pageSetupB()
        Try
            getCountPageNumB()
            If countpagenumB < pagedivisor Then
                validpagesB = startingpage
            Else
                additionalpage = countpagenumB / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpagesB = countpagenumB / pagedivisor
                Else
                    validpagesB = countpagenumB / pagedivisor
                    validpagesB = validpagesB + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNumB()
        Try
            countpagenumB = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(p.rowid),0) FROM contacts p WHERE p.organizationid = " & Z_OrganizationID & " AND p.`type` = 'Packer' ")
            If dtCid.Rows.Count <> 0 Then
                countpagenumB = dtCid.Rows(0)(0)
            Else
                countpagenumB = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub pageSetupC()
        Try
            getCountPageNumC()
            If countpagenumC < pagedivisor Then
                validpagesC = startingpage
            Else
                additionalpage = countpagenumC / pagedivisor
                If additionalpage = Int(additionalpage) Then
                    validpagesC = countpagenumC / pagedivisor
                Else
                    validpagesC = countpagenumC / pagedivisor
                    validpagesC = validpagesC + startingpage
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getCountPageNumC()
        Try
            countpagenumC = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtCid As New DataTable
            dtCid = getDataTableForSQL("SELECT COALESCE(COUNT(p.rowid),0) FROM contacts p WHERE p.organizationid = " & Z_OrganizationID & " AND p.`type` = 'Driver' ")
            If dtCid.Rows.Count <> 0 Then
                countpagenumC = dtCid.Rows(0)(0)
            Else
                countpagenumC = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Display"

#Region "AutoComplete"

    Sub autocompleteSuffix(ByVal icombobox As ComboBox)
        Try
            Dim suffix As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.suffix,'') AS 'suffix' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.suffix != '' GROUP BY c.suffix ORDER BY c.suffix ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                suffix.Add(ds.Tables(0).Rows(i)("suffix").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = suffix
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub

    Sub autocompleteSalutation(ByVal icombobox As ComboBox)
        Try
            Dim salutation As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.salutation,'') AS 'salutation' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.salutation != '' GROUP BY c.salutation ORDER BY c.salutation ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                salutation.Add(ds.Tables(0).Rows(i)("salutation").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = salutation
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub

    Sub autocompleteGender(ByVal icombobox As ComboBox)
        Try
            Dim gender As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.gender,'') AS 'gender' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.gender != '' GROUP BY c.gender ORDER BY c.gender ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                gender.Add(ds.Tables(0).Rows(i)("gender").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = gender
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub

    Sub autocompleteCivilStatus(ByVal icombobox As ComboBox)
        Try
            Dim civilstatus As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.civilstatus,'') AS 'civilstatus' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.civilstatus != '' GROUP BY c.civilstatus ORDER BY c.civilstatus ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                civilstatus.Add(ds.Tables(0).Rows(i)("civilstatus").ToString())
            Next
            icombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            icombobox.AutoCompleteCustomSource = civilstatus
            icombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub

#End Region

#Region "AutoPopulate"

    Sub autopopulateContactType()
        Try

            cboContactType.Items.Clear()
            cboContactType.Items.Add("Driver")
            cboContactType.Items.Add("Packer")
            cboContactType.Items.Add("Picker")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autopopulateSuffix(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.suffix,'') AS 'suffix' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.suffix != '' GROUP BY c.suffix ORDER BY c.suffix "
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

    Sub autopopulateSalutation(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.salutation,'') AS 'salutation' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.salutation != '' GROUP BY c.salutation ORDER BY c.salutation "
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

    Sub autopopulateGender(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.gender,'') AS 'gender' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.gender != '' GROUP BY c.gender ORDER BY c.gender "
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

    Sub autopopulateCivilStatus(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.civilstatus,'') AS 'civilstatus' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.civilstatus != '' GROUP BY c.civilstatus ORDER BY c.civilstatus "
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

    Sub autopopulateStatus(ByVal icombobox As ComboBox)
        Try
            icombobox.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT lic FROM listofvalues WHERE type = 'Status' AND `status` = 'Active' ORDER BY lic "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                icombobox.Items.Add(reader1(0).ToString())
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

    Sub displayPickerList(ByVal istartpage As Integer)
        Try
            dgPickerList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT p.rowid,COALESCE(p.contactno,''),COALESCE(p.firstname,''),COALESCE(p.lastname,''),COALESCE(p.middlename,'') FROM contacts p " &
                        "WHERE p.organizationid = " & Z_OrganizationID & " AND p.`type` = 'Picker' ORDER BY p.contactno ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPickerList.Rows.Add()
                    dgPickerList.Item(p_rowid.Index, n).Value = reader1(0)
                    dgPickerList.Item(p_pickerno.Index, n).Value = reader1(1)
                    dgPickerList.Item(p_fname.Index, n).Value = reader1(2)
                    dgPickerList.Item(p_lname.Index, n).Value = reader1(3)
                    dgPickerList.Item(p_mname.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPickerList.Columns("p_pickerno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickerList.Columns("p_fname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickerList.Columns("p_lname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPickerList.Columns("p_mname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPickerList.Rows.Count <> 0 Then
                dgPickerList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayPackerList(ByVal istartpage As Integer)
        Try
            dgPackerList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT p.rowid,COALESCE(p.contactno,''),COALESCE(p.firstname,''),COALESCE(p.lastname,''),COALESCE(p.middlename,'') FROM contacts p " &
                        "WHERE p.organizationid = " & Z_OrganizationID & " AND p.`type` = 'Packer' ORDER BY p.contactno ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgPackerList.Rows.Add()
                    dgPackerList.Item(pa_rowid.Index, n).Value = reader1(0)
                    dgPackerList.Item(pa_packerno.Index, n).Value = reader1(1)
                    dgPackerList.Item(pa_fname.Index, n).Value = reader1(2)
                    dgPackerList.Item(pa_lname.Index, n).Value = reader1(3)
                    dgPackerList.Item(pa_mname.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgPackerList.Columns("pa_packerno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackerList.Columns("pa_fname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackerList.Columns("pa_lname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgPackerList.Columns("pa_mname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgPackerList.Rows.Count <> 0 Then
                dgPackerList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayDriverList(ByVal istartpage As Integer)
        Try
            dgDriverList.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT p.rowid,COALESCE(p.contactno,''),COALESCE(p.firstname,''),COALESCE(p.lastname,''),COALESCE(p.middlename,'') FROM contacts p " &
                        "WHERE p.organizationid = " & Z_OrganizationID & " AND p.`type` = 'Driver' ORDER BY p.contactno ASC LIMIT " & istartpage & "," & pagedivisor & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            While reader1.Read()
                If reader1.HasRows Then
                    dgDriverList.Rows.Add()
                    dgDriverList.Item(dr_rowid.Index, n).Value = reader1(0)
                    dgDriverList.Item(dr_driverno.Index, n).Value = reader1(1)
                    dgDriverList.Item(dr_fname.Index, n).Value = reader1(2)
                    dgDriverList.Item(dr_lname.Index, n).Value = reader1(3)
                    dgDriverList.Item(dr_mname.Index, n).Value = reader1(4)
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgDriverList.Columns("dr_driverno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDriverList.Columns("dr_fname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDriverList.Columns("dr_lname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDriverList.Columns("dr_mname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgDriverList.Rows.Count <> 0 Then
                dgDriverList.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getContactInformation(ByVal icontactid As Integer)
        Try
            Dim dtCinfo As New DataTable
            dtCinfo = getDataTableForSQL("SELECT COALESCE(c.`type`,''),COALESCE(c.contactno,''),COALESCE(c.firstname,''),COALESCE(c.middlename,''),COALESCE(c.lastname,''),COALESCE(c.salutation,''),COALESCE(c.suffix,''),COALESCE(c.nickname,''),COALESCE(c.gender,''),COALESCE(c.civilstatus,'')," &
                        "COALESCE(c.tinnumber,''),COALESCE(c.mainphone,''),COALESCE(c.alternatephone,''),COALESCE(c.faxnumber,''),COALESCE(c.birthday,''),COALESCE(c.status,''),COALESCE(c.comments,''),COALESCE(c.emailaddress,'') FROM contacts c WHERE c.rowid = " & icontactid & " ")
            If dtCinfo.Rows.Count <> 0 Then
                cboContactType.Text = dtCinfo.Rows(0)(0)
                txtContactNo.Text = dtCinfo.Rows(0)(1)
                txtFName.Text = dtCinfo.Rows(0)(2)
                txtMName.Text = dtCinfo.Rows(0)(3)
                txtLName.Text = dtCinfo.Rows(0)(4)
                cboSalutation.Text = dtCinfo.Rows(0)(5)
                cboSuffix.Text = dtCinfo.Rows(0)(6)
                txtNickName.Text = dtCinfo.Rows(0)(7)
                cboGender.Text = dtCinfo.Rows(0)(8)
                cboCivilStatus.Text = dtCinfo.Rows(0)(9)
                txtTIN.Text = dtCinfo.Rows(0)(10)
                txtMainPhone.Text = dtCinfo.Rows(0)(11)
                txtAlternatePhone.Text = dtCinfo.Rows(0)(12)
                txtFaxNo.Text = dtCinfo.Rows(0)(13)
                dtpBirthday.Text = dtCinfo.Rows(0)(14)
                cboStatus.Text = dtCinfo.Rows(0)(15)
                txtComments.Text = dtCinfo.Rows(0)(16)
                txtEmailAddress.Text = dtCinfo.Rows(0)(17)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

#End Region

#End Region

#End Region

    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If MessageBox.Show("Are you sure you wanted to close this form?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                PrimaryForm.CntctsForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtComments_Leave(sender As Object, e As EventArgs) Handles txtComments.Leave
        Try
            txtFName.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub msNew_Click(sender As Object, e As EventArgs) Handles msNew.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Contacts", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.CntctsForm = False
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
            cue = "New"
            errProvider.Clear()
            clearContactInformation()
            enableGB(fraud)
            enableFields(legit, legit)
            enableANDvisibleMS(fraud, legit, legit)
            cboContactType.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub msCancel_Click(sender As Object, e As EventArgs) Handles msCancel.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            tsrefreshperformclick()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgPickerList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPickerList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPickerList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearContactInformation()
                enableFields(legit, fraud)
                enableANDvisibleMS(legit, legit, fraud)
                If dgPackerList.Rows.Count <> 0 Then
                    dgPackerList.CurrentRow.Selected = False
                End If
                If dgDriverList.Rows.Count <> 0 Then
                    dgDriverList.CurrentRow.Selected = False
                End If
                getContactInformation(CInt(dgPickerList.CurrentRow.Cells("p_rowid").Value))
                txtFName.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgPickerList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgPickerList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPickerList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearContactInformation()
                    enableFields(legit, fraud)
                    enableANDvisibleMS(legit, legit, fraud)
                    If dgPackerList.Rows.Count <> 0 Then
                        dgPackerList.CurrentRow.Selected = False
                    End If
                    If dgDriverList.Rows.Count <> 0 Then
                        dgDriverList.CurrentRow.Selected = False
                    End If
                    getContactInformation(CInt(dgPickerList.CurrentRow.Cells("p_rowid").Value))
                    txtFName.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgPackerList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPackerList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPackerList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearContactInformation()
                enableFields(legit, fraud)
                enableANDvisibleMS(legit, legit, fraud)
                If dgPickerList.Rows.Count <> 0 Then
                    dgPickerList.CurrentRow.Selected = False
                End If
                If dgDriverList.Rows.Count <> 0 Then
                    dgDriverList.CurrentRow.Selected = False
                End If
                getContactInformation(CInt(dgPackerList.CurrentRow.Cells("pa_rowid").Value))
                txtFName.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgPackerList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgPackerList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgPackerList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearContactInformation()
                    enableFields(legit, fraud)
                    enableANDvisibleMS(legit, legit, fraud)
                    If dgPickerList.Rows.Count <> 0 Then
                        dgPickerList.CurrentRow.Selected = False
                    End If
                    If dgDriverList.Rows.Count <> 0 Then
                        dgDriverList.CurrentRow.Selected = False
                    End If
                    getContactInformation(CInt(dgPackerList.CurrentRow.Cells("pa_rowid").Value))
                    txtFName.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgDriverList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDriverList.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgDriverList.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearContactInformation()
                enableFields(legit, fraud)
                enableANDvisibleMS(legit, legit, fraud)
                If dgPickerList.Rows.Count <> 0 Then
                    dgPickerList.CurrentRow.Selected = False
                End If
                If dgPackerList.Rows.Count <> 0 Then
                    dgPackerList.CurrentRow.Selected = False
                End If
                getContactInformation(CInt(dgDriverList.CurrentRow.Cells("dr_rowid").Value))
                txtFName.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgDriverList_KeyUp(sender As Object, e As KeyEventArgs) Handles dgDriverList.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgDriverList.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearContactInformation()
                    enableFields(legit, fraud)
                    enableANDvisibleMS(legit, legit, fraud)
                    If dgPickerList.Rows.Count <> 0 Then
                        dgPickerList.CurrentRow.Selected = False
                    End If
                    If dgPackerList.Rows.Count <> 0 Then
                        dgPackerList.CurrentRow.Selected = False
                    End If
                    getContactInformation(CInt(dgDriverList.CurrentRow.Cells("dr_rowid").Value))
                    txtFName.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboContactType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboContactType.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If cue = "New" Then
                If LTrim(cboContactType.Text) <> "" Then
                    If cboContactType.Text = "Driver" Then
                        getContactNo("Driver", Me)
                    ElseIf cboContactType.Text = "Packer" Then
                        getContactNo("Packer", Me)
                    ElseIf cboContactType.Text = "Picker" Then
                        getContactNo("Picker", Me)
                    End If
                    txtContactNo.Text = globalcontactno
                End If
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
                getPositionView(globalpositionid, "Contacts", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.CntctsForm = False
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
            If LTrim(cboContactType.Text) = "" Then
                errProvider.SetError(cboContactType, "Please choose the contact type of this contact.")
                cboContactType.Focus()
                Exit Try
            End If
            If LTrim(txtFName.Text) = "" And LTrim(txtLName.Text) = "" Then
                errProvider.SetError(txtFName, "Please fill-up either the first name or the last name.")
                errProvider.SetError(txtLName, "Please fill-up either the first name or the last name.")
                txtFName.Focus()
                Exit Try
            End If
            If LTrim(cboStatus.Text) = "" Then
                errProvider.SetError(cboStatus, "Please choose the status of this contact.")
                cboStatus.Focus()
                Exit Try
            End If
            If cue = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If cboContactType.Text = "Driver" Then
                    If dgDriverList.Rows.Count = 0 Then
                        errProvider.SetError(cboContactType, "System cannot find the driver list.")
                        cboContactType.Focus()
                        Exit Try
                    End If
                ElseIf cboContactType.Text = "Packer" Then
                    If dgPackerList.Rows.Count = 0 Then
                        errProvider.SetError(cboContactType, "System cannot find the packer list.")
                        cboContactType.Focus()
                        Exit Try
                    End If
                ElseIf cboContactType.Text = "Picker" Then
                    If dgPickerList.Rows.Count = 0 Then
                        errProvider.SetError(cboContactType, "System cannot find the picker list.")
                        cboContactType.Focus()
                        Exit Try
                    End If
                End If
            End If
            If MessageBox.Show("Would you like to save the changes in this page? ", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If cue = "New" Then
                    If cboContactType.Text = "Driver" Then
                        getContactNo("Driver", Me)
                        I_Contact(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, globalcontactno, "Driver", cboSalutation.Text, txtFName.Text, txtMName.Text, txtLName.Text, cboSuffix.Text, txtMainPhone.Text, txtAlternatePhone.Text, dtpBirthday.Value,
                                cboGender.Text, cboCivilStatus.Text, txtEmailAddress.Text, txtTIN.Text, txtComments.Text, cboStatus.Text, "", "", txtFaxNo.Text, "Driver", txtNickName.Text, Me)
                    ElseIf cboContactType.Text = "Packer" Then
                        getContactNo("Packer", Me)
                        I_Contact(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, globalcontactno, "Packer", cboSalutation.Text, txtFName.Text, txtMName.Text, txtLName.Text, cboSuffix.Text, txtMainPhone.Text, txtAlternatePhone.Text, dtpBirthday.Value,
                                cboGender.Text, cboCivilStatus.Text, txtEmailAddress.Text, txtTIN.Text, txtComments.Text, cboStatus.Text, "", "", txtFaxNo.Text, "Packer", txtNickName.Text, Me)
                    ElseIf cboContactType.Text = "Picker" Then
                        getContactNo("Picker", Me)
                        I_Contact(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, globalcontactno, "Picker", cboSalutation.Text, txtFName.Text, txtMName.Text, txtLName.Text, cboSuffix.Text, txtMainPhone.Text, txtAlternatePhone.Text, dtpBirthday.Value,
                                cboGender.Text, cboCivilStatus.Text, txtEmailAddress.Text, txtTIN.Text, txtComments.Text, cboStatus.Text, "", "", txtFaxNo.Text, "Picker", txtNickName.Text, Me)
                    End If
                    If CStr(txtContactNo.Text) <> CStr(globalcontactno) Then
                        MessageBox.Show("Please take note that the Contact No. has change from " & txtContactNo.Text & " to " & globalcontactno & "." & vbNewLine & "Another user used Contact No. " & txtContactNo.Text & " for its new contact.", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtContactNo.Text = globalcontactno
                    End If
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Save", "Save", lblsavemsg, -15, -65)
                        tsrefreshperformclick()
                    End If
                ElseIf cue = "Edit" Then
                    If cboContactType.Text = "Driver" Then
                        U_Contacts(CInt(dgDriverList.CurrentRow.Cells("dr_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, cboSalutation.Text, txtFName.Text, txtMName.Text, txtLName.Text, cboSuffix.Text, txtMainPhone.Text, txtAlternatePhone.Text, dtpBirthday.Value,
                                cboGender.Text, cboCivilStatus.Text, txtEmailAddress.Text, txtTIN.Text, txtComments.Text, "", "", txtFaxNo.Text, "Driver", txtNickName.Text, cboStatus.Text, Me)
                    ElseIf cboContactType.Text = "Packer" Then
                        U_Contacts(CInt(dgPackerList.CurrentRow.Cells("pa_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, cboSalutation.Text, txtFName.Text, txtMName.Text, txtLName.Text, cboSuffix.Text, txtMainPhone.Text, txtAlternatePhone.Text, dtpBirthday.Value,
                                cboGender.Text, cboCivilStatus.Text, txtEmailAddress.Text, txtTIN.Text, txtComments.Text, "", "", txtFaxNo.Text, "Packer", txtNickName.Text, cboStatus.Text, Me)
                    ElseIf cboContactType.Text = "Picker" Then
                        U_Contacts(CInt(dgPickerList.CurrentRow.Cells("p_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, cboSalutation.Text, txtFName.Text, txtMName.Text, txtLName.Text, cboSuffix.Text, txtMainPhone.Text, txtAlternatePhone.Text, dtpBirthday.Value,
                                cboGender.Text, cboCivilStatus.Text, txtEmailAddress.Text, txtTIN.Text, txtComments.Text, "", "", txtFaxNo.Text, "Picker", txtNickName.Text, cboStatus.Text, Me)
                    End If
                    If myModule.systemerrorfound = False Then
                        myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                        tsrefreshperformclick()
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

#Region "Search/Page Setup"

    Private Sub cmdFirstPickerList_Click(sender As Object, e As EventArgs) Handles cmdFirstPickerList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If dgPackerList.Rows.Count <> 0 Then
                dgPackerList.CurrentRow.Selected = False
            End If
            If dgDriverList.Rows.Count <> 0 Then
                dgDriverList.CurrentRow.Selected = False
            End If
            spagenumA = neutralpage
            numofpagesA = startingpage
            displayPickerList(spagenumA)
            txtPageNoPickerList.Text = "" & numofpagesA & " of " & validpagesA & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdPrevPickerList_Click(sender As Object, e As EventArgs) Handles cmdPrevPickerList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If dgPackerList.Rows.Count <> 0 Then
                dgPackerList.CurrentRow.Selected = False
            End If
            If dgDriverList.Rows.Count <> 0 Then
                dgDriverList.CurrentRow.Selected = False
            End If
            spagenumA = spagenumA - pagedivisor
            numofpagesA = numofpagesA - 1
            If spagenumA < 0 Then
                If countpagenumA < pagedivisor Then
                    spagenumA = neutralpage
                Else
                    spagenumA = countpagenumA - pagedivisor
                End If
                numofpagesA = validpagesA
            End If
            displayPickerList(spagenumA)
            txtPageNoPickerList.Text = "" & numofpagesA & " of " & validpagesA & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdNextPickerList_Click(sender As Object, e As EventArgs) Handles cmdNextPickerList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If dgPackerList.Rows.Count <> 0 Then
                dgPackerList.CurrentRow.Selected = False
            End If
            If dgDriverList.Rows.Count <> 0 Then
                dgDriverList.CurrentRow.Selected = False
            End If
            spagenumA = spagenumA + pagedivisor
            numofpagesA = numofpagesA + 1
            If numofpagesA > validpagesA Then
                spagenumA = neutralpage
                numofpagesA = startingpage
            End If
            displayPickerList(spagenumA)
            txtPageNoPickerList.Text = "" & numofpagesA & " of " & validpagesA & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdLastPickerList_Click(sender As Object, e As EventArgs) Handles cmdLastPickerList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If dgPackerList.Rows.Count <> 0 Then
                dgPackerList.CurrentRow.Selected = False
            End If
            If dgDriverList.Rows.Count <> 0 Then
                dgDriverList.CurrentRow.Selected = False
            End If
            If countpagenumA < pagedivisor Then
                spagenumA = neutralpage
            Else
                spagenumA = countpagenumA - pagedivisor
            End If
            numofpagesA = validpagesA
            displayPickerList(spagenumA)
            txtPageNoPickerList.Text = "" & numofpagesA & " of " & validpagesA & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtPagePickerList_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPagePickerList.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If IsNumeric(txtPagePickerList.Text) Then
                    If CInt(txtPagePickerList.Text) < 0 Then
                    ElseIf CInt(txtPagePickerList.Text) = 0 Then
                    ElseIf CInt(txtPagePickerList.Text) > validpagesA Then
                    Else
                        clearRightPage()
                        If dgPackerList.Rows.Count <> 0 Then
                            dgPackerList.CurrentRow.Selected = False
                        End If
                        If dgDriverList.Rows.Count <> 0 Then
                            dgDriverList.CurrentRow.Selected = False
                        End If
                        If countpagenumA < pagedivisor Then
                            spagenumA = neutralpage
                        Else
                            pageequation1 = CInt(txtPagePickerList.Text) * pagedivisor
                            pageequation2 = ((CInt(txtPagePickerList.Text) / validpagesA) * countpagenumA)
                            If pageequation1 < pageequation2 Then
                                pageequation3 = ((CInt(txtPagePickerList.Text) / validpagesA) * countpagenumA) - (pageequation2 - pageequation1)
                            Else
                                pageequation3 = (CInt(txtPagePickerList.Text) / validpagesA) * countpagenumA
                            End If
                            spagenumA = pageequation3 - pagedivisor
                        End If
                        numofpagesA = CInt(txtPagePickerList.Text)
                        displayPickerList(spagenumA)
                        txtPageNoPickerList.Text = "" & numofpagesA & " of " & validpagesA & " "
                        txtPagePickerList.Text = ""
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

    Private Sub cmdFirstPackerList_Click(sender As Object, e As EventArgs) Handles cmdFirstPackerList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If dgPickerList.Rows.Count <> 0 Then
                dgPickerList.CurrentRow.Selected = False
            End If
            If dgDriverList.Rows.Count <> 0 Then
                dgDriverList.CurrentRow.Selected = False
            End If
            spagenumB = neutralpage
            numofpagesB = startingpage
            displayPackerList(spagenumB)
            txtPageNoPackerList.Text = "" & numofpagesB & " of " & validpagesB & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdPrevPackerList_Click(sender As Object, e As EventArgs) Handles cmdPrevPackerList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If dgPickerList.Rows.Count <> 0 Then
                dgPickerList.CurrentRow.Selected = False
            End If
            If dgDriverList.Rows.Count <> 0 Then
                dgDriverList.CurrentRow.Selected = False
            End If
            spagenumB = spagenumB - pagedivisor
            numofpagesB = numofpagesB - 1
            If spagenumB < 0 Then
                If countpagenumB < pagedivisor Then
                    spagenumB = neutralpage
                Else
                    spagenumB = countpagenumB - pagedivisor
                End If
                numofpagesB = validpagesB
            End If
            displayPackerList(spagenumB)
            txtPageNoPackerList.Text = "" & numofpagesB & " of " & validpagesB & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdNextPackerList_Click(sender As Object, e As EventArgs) Handles cmdNextPackerList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If dgPickerList.Rows.Count <> 0 Then
                dgPickerList.CurrentRow.Selected = False
            End If
            If dgDriverList.Rows.Count <> 0 Then
                dgDriverList.CurrentRow.Selected = False
            End If
            spagenumB = spagenumB + pagedivisor
            numofpagesB = numofpagesB + 1
            If numofpagesB > validpagesB Then
                spagenumB = neutralpage
                numofpagesB = startingpage
            End If
            displayPackerList(spagenumB)
            txtPageNoPackerList.Text = "" & numofpagesB & " of " & validpagesB & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdLastPackerList_Click(sender As Object, e As EventArgs) Handles cmdLastPackerList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If dgPickerList.Rows.Count <> 0 Then
                dgPickerList.CurrentRow.Selected = False
            End If
            If dgDriverList.Rows.Count <> 0 Then
                dgDriverList.CurrentRow.Selected = False
            End If
            If countpagenumB < pagedivisor Then
                spagenumB = neutralpage
            Else
                spagenumB = countpagenumB - pagedivisor
            End If
            numofpagesB = validpagesB
            displayPackerList(spagenumB)
            txtPageNoPackerList.Text = "" & numofpagesB & " of " & validpagesB & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtPagePackerList_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPagePackerList.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If IsNumeric(txtPagePackerList.Text) Then
                    If CInt(txtPagePackerList.Text) < 0 Then
                    ElseIf CInt(txtPagePackerList.Text) = 0 Then
                    ElseIf CInt(txtPagePackerList.Text) > validpagesB Then
                    Else
                        clearRightPage()
                        If dgPickerList.Rows.Count <> 0 Then
                            dgPickerList.CurrentRow.Selected = False
                        End If
                        If dgDriverList.Rows.Count <> 0 Then
                            dgDriverList.CurrentRow.Selected = False
                        End If
                        If countpagenumB < pagedivisor Then
                            spagenumB = neutralpage
                        Else
                            pageequation1 = CInt(txtPagePackerList.Text) * pagedivisor
                            pageequation2 = ((CInt(txtPagePackerList.Text) / validpagesB) * countpagenumB)
                            If pageequation1 < pageequation2 Then
                                pageequation3 = ((CInt(txtPagePackerList.Text) / validpagesB) * countpagenumB) - (pageequation2 - pageequation1)
                            Else
                                pageequation3 = (CInt(txtPagePackerList.Text) / validpagesB) * countpagenumB
                            End If
                            spagenumB = pageequation3 - pagedivisor
                        End If
                        numofpagesB = CInt(txtPagePackerList.Text)
                        displayPackerList(spagenumB)
                        txtPageNoPackerList.Text = "" & numofpagesB & " of " & validpagesB & " "
                        txtPagePackerList.Text = ""
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

    Private Sub cmdFirstDriverList_Click(sender As Object, e As EventArgs) Handles cmdFirstDriverList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If dgPackerList.Rows.Count <> 0 Then
                dgPackerList.CurrentRow.Selected = False
            End If
            If dgPickerList.Rows.Count <> 0 Then
                dgPickerList.CurrentRow.Selected = False
            End If
            spagenumC = neutralpage
            numofpagesC = startingpage
            displayDriverList(spagenumC)
            txtPageNoDriverList.Text = "" & numofpagesC & " of " & validpagesC & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdPrevDriverList_Click(sender As Object, e As EventArgs) Handles cmdPrevDriverList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If dgPackerList.Rows.Count <> 0 Then
                dgPackerList.CurrentRow.Selected = False
            End If
            If dgPickerList.Rows.Count <> 0 Then
                dgPickerList.CurrentRow.Selected = False
            End If
            spagenumC = spagenumC - pagedivisor
            numofpagesC = numofpagesC - 1
            If spagenumC < 0 Then
                If countpagenumC < pagedivisor Then
                    spagenumC = neutralpage
                Else
                    spagenumC = countpagenumC - pagedivisor
                End If
                numofpagesC = validpagesC
            End If
            displayDriverList(spagenumC)
            txtPageNoDriverList.Text = "" & numofpagesC & " of " & validpagesC & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdNextDriverList_Click(sender As Object, e As EventArgs) Handles cmdNextDriverList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If dgPackerList.Rows.Count <> 0 Then
                dgPackerList.CurrentRow.Selected = False
            End If
            If dgPickerList.Rows.Count <> 0 Then
                dgPickerList.CurrentRow.Selected = False
            End If
            spagenumC = spagenumC + pagedivisor
            numofpagesC = numofpagesC + 1
            If numofpagesC > validpagesC Then
                spagenumC = neutralpage
                numofpagesC = startingpage
            End If
            displayDriverList(spagenumC)
            txtPageNoDriverList.Text = "" & numofpagesC & " of " & validpagesC & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdLastDriverList_Click(sender As Object, e As EventArgs) Handles cmdLastDriverList.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearRightPage()
            If dgPackerList.Rows.Count <> 0 Then
                dgPackerList.CurrentRow.Selected = False
            End If
            If dgPickerList.Rows.Count <> 0 Then
                dgPickerList.CurrentRow.Selected = False
            End If
            If countpagenumC < pagedivisor Then
                spagenumC = neutralpage
            Else
                spagenumC = countpagenumC - pagedivisor
            End If
            numofpagesC = validpagesC
            displayDriverList(spagenumC)
            txtPageNoDriverList.Text = "" & numofpagesC & " of " & validpagesC & " "
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtPageDriverList_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPageDriverList.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If IsNumeric(txtPageDriverList.Text) Then
                    If CInt(txtPageDriverList.Text) < 0 Then
                    ElseIf CInt(txtPageDriverList.Text) = 0 Then
                    ElseIf CInt(txtPageDriverList.Text) > validpagesC Then
                    Else
                        clearRightPage()
                        If dgPackerList.Rows.Count <> 0 Then
                            dgPackerList.CurrentRow.Selected = False
                        End If
                        If dgPickerList.Rows.Count <> 0 Then
                            dgPickerList.CurrentRow.Selected = False
                        End If
                        If countpagenumC < pagedivisor Then
                            spagenumC = neutralpage
                        Else
                            pageequation1 = CInt(txtPageDriverList.Text) * pagedivisor
                            pageequation2 = ((CInt(txtPageDriverList.Text) / validpagesC) * countpagenumC)
                            If pageequation1 < pageequation2 Then
                                pageequation3 = ((CInt(txtPageDriverList.Text) / validpagesC) * countpagenumC) - (pageequation2 - pageequation1)
                            Else
                                pageequation3 = (CInt(txtPageDriverList.Text) / validpagesC) * countpagenumC
                            End If
                            spagenumC = pageequation3 - pagedivisor
                        End If
                        numofpagesC = CInt(txtPageDriverList.Text)
                        displayDriverList(spagenumC)
                        txtPageNoDriverList.Text = "" & numofpagesC & " of " & validpagesC & " "
                        txtPageDriverList.Text = ""
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

#End Region

#Region "Datagrid Errors"

    Private Sub dgPickerList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgPickerList.DataError
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
                dgPickerList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgPackerList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgPackerList.DataError
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
                dgPackerList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgDriverList_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgDriverList.DataError
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
                dgDriverList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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