Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Windows.Forms
Imports System.Data
Public Class LoginForm
    Dim ctr As Integer = 0
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            dbconn()
            cboOrganization.SelectedItem = Nothing
            cboOrganization.Text = ""
            txtUsername.Text = ""
            txtPassword.Text = ""
            autopopulateCompanyName()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
            SkipLoginCredentials()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoginForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            myBalloon(, , btnLogin, , , 1)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#Region "Functions"
    Sub autopopulateCompanyName()
        Try
            Dim strQuery As String = "SELECT COALESCE(o.name,'') FROM organizations o "
            cboOrganization.Items.Clear()
            cboOrganization.Items.AddRange(CType(SQL_ArrayList(strQuery).ToArray(GetType(String)), String()))
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
    Sub displayCompanyImage(ByVal icompanyname As String)
        Try
            PhotoImages.Image = Nothing
            Dim sqlquery As String = "SELECT COALESCE(o.image,'') FROM organizations o WHERE o.name = """ & icompanyname & """ "
            Dim sqlcmd As New MySqlCommand(sqlquery, conn)
            conn.Open()
            Dim sqlrd As MySqlDataReader = sqlcmd.ExecuteReader
            sqlcmd = Nothing
            If sqlrd.HasRows Then
                While sqlrd.Read
                    If sqlrd(0).ToString = "" Then
                        PhotoImages.Image = Nothing
                    Else
                        Dim pictureData As Byte() = DirectCast(sqlrd(0), Byte())
                        If pictureData.Length > 0 Then
                            Dim picture As Image = Nothing
                            Using stream As New IO.MemoryStream(pictureData, True)
                                picture = Image.FromStream(stream)
                                PhotoImages.Image = (picture)
                            End Using
                        End If
                    End If
                End While
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        conn.Close()
    End Sub
#End Region
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub cboOrganization_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOrganization.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            displayCompanyImage(cboOrganization.Text)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If Trim(txtUsername.Text) = "" Or Trim(txtPassword.Text) = "" Then
                    myBalloon("Please enter your username and password.", "Invalid login", btnLogin, btnLogin.Width - 18, -69)
                    If Trim(txtUsername.Text) = "" Then
                        txtUsername.Focus()
                    ElseIf Trim(txtPassword.Text) = "" Then
                        txtPassword.Focus()
                    End If
                    Exit Try
                ElseIf cboOrganization.Text = "" Then
                    myBalloon("Please choose your company name.", "Invalid login", btnLogin, btnLogin.Width - 18, -69)
                    cboOrganization.Focus()
                    Exit Try
                Else
                    Dim orgid As String = getStringItem("SELECT o.rowid FROM organizations o WHERE o.name = """ & cboOrganization.Text & """ ")
                    Z_OrganizationID = Val(orgid)
                    Z_CompanyName = cboOrganization.Text

                    Dim userid As String = getStringItem("SELECT COALESCE(u.rowid,0) FROM users u WHERE u.userid = """ & EncrypedData(txtUsername.Text) & """ AND u.password = """ & EncrypedData(txtPassword.Text) & """ AND u.organizationid = " & Z_OrganizationID & " ")
                    Z_UserID = Val(userid)

                    Dim username As String = getStringItem("SELECT COALESCE(CONCAT(u.firstname,' ',u.lastname),'') FROM users u WHERE u.userid = """ & EncrypedData(txtUsername.Text) & """ AND u.password = """ & EncrypedData(txtPassword.Text) & """ AND u.organizationid = " & Z_OrganizationID & " ")
                    Z_UserName = username

                    Dim posid As String = getStringItem("SELECT PositionID FROM users u WHERE u.userid = """ & EncrypedData(txtUsername.Text) & """ AND u.password = """ & EncrypedData(txtPassword.Text) & """ AND u.organizationid = " & Z_OrganizationID & " ")
                    Z_PositionID = Val(posid)

                    Dim dt As New DataTable
                    dt = getDataTableForSQL("SELECT * FROM users u WHERE u.userid = """ & EncrypedData(txtUsername.Text) & """ AND u.password = """ & EncrypedData(txtPassword.Text) & """ AND u.organizationid = " & Z_OrganizationID & " AND u.status = 'Active' ")

                    If ctr = 3 Then
                        Me.Close()
                    ElseIf ctr <= 2 Then
                        If dt.Rows.Count > 0 Then
                            Dim uname As String = DecrypedData(dt.Rows(0)("UserID").ToString)
                            Dim passname As String = DecrypedData(dt.Rows(0)("Password").ToString)
                            Dim passnA As String = EncrypedData(txtPassword.Text)
                            Dim passnB As String = EncrypedData(passname)
                            Dim usnameA As String = EncrypedData(uname)
                            Dim usnameB As String = EncrypedData(txtUsername.Text)
                            If passnA = passnB And usnameA = usnameB Then
                                PrimaryForm.Show()
                                ctr = 0
                                Me.Hide()
                            Else
                                MsgBox("Incorrect Login Fields!", MsgBoxStyle.Critical, "LOGIN FAILED")
                                txtUsername.Clear()
                                txtPassword.Clear()
                                txtUsername.Focus()
                                ctr += 1
                            End If
                        Else
                            MsgBox("Incorrect Login Fields!", MsgBoxStyle.Critical, "LOGIN FAILED")
                            txtUsername.Clear()
                            txtPassword.Clear()
                            txtUsername.Focus()
                            ctr += 1
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
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If Trim(txtUsername.Text) = "" Or Trim(txtPassword.Text) = "" Then
                myBalloon("Please enter your username and password.", "Invalid login", btnLogin, btnLogin.Width - 18, -69)
                If Trim(txtUsername.Text) = "" Then
                    txtUsername.Focus()
                ElseIf Trim(txtPassword.Text) = "" Then
                    txtPassword.Focus()
                End If
                Exit Try
            ElseIf cboOrganization.Text = "" Then
                myBalloon("Please choose your company name.", "Invalid login", btnLogin, btnLogin.Width - 18, -69)
                cboOrganization.Focus()
                Exit Try
            Else
                Dim orgid As String = getStringItem("SELECT o.rowid FROM organizations o WHERE o.name = """ & cboOrganization.Text & """ ")
                Z_OrganizationID = Val(orgid)
                Z_CompanyName = cboOrganization.Text

                Dim userid As String = getStringItem("SELECT COALESCE(u.rowid,0) FROM users u WHERE u.userid = """ & EncrypedData(txtUsername.Text) & """ AND u.password = """ & EncrypedData(txtPassword.Text) & """ AND u.organizationid = " & Z_OrganizationID & " ")
                Z_UserID = Val(userid)

                Dim username As String = getStringItem("SELECT COALESCE(CONCAT(u.firstname,' ',u.lastname),'') FROM users u WHERE u.userid = """ & EncrypedData(txtUsername.Text) & """ AND u.password = """ & EncrypedData(txtPassword.Text) & """ AND u.organizationid = " & Z_OrganizationID & " ")
                Z_UserName = username

                Dim posid As String = getStringItem("SELECT PositionID FROM users u WHERE u.userid = """ & EncrypedData(txtUsername.Text) & """ AND u.password = """ & EncrypedData(txtPassword.Text) & """ AND u.organizationid = " & Z_OrganizationID & " ")
                Z_PositionID = Val(posid)

                Dim dt As New DataTable
                dt = getDataTableForSQL("SELECT * FROM users u WHERE u.userid = """ & EncrypedData(txtUsername.Text) & """ AND u.password = """ & EncrypedData(txtPassword.Text) & """ AND u.organizationid = " & Z_OrganizationID & " AND u.status = 'Active' ")

                If ctr = 3 Then
                    Me.Close()
                ElseIf ctr <= 2 Then
                    If dt.Rows.Count > 0 Then
                        Dim uname As String = DecrypedData(dt.Rows(0)("UserID").ToString)
                        Dim passname As String = DecrypedData(dt.Rows(0)("Password").ToString)
                        Dim passnA As String = EncrypedData(txtPassword.Text)
                        Dim passnB As String = EncrypedData(passname)
                        Dim usnameA As String = EncrypedData(uname)
                        Dim usnameB As String = EncrypedData(txtUsername.Text)
                        If passnA = passnB And usnameA = usnameB Then
                            PrimaryForm.Show()
                            ctr = 0
                            Me.Hide()
                        Else
                            MsgBox("Incorrect Login Fields!", MsgBoxStyle.Critical, "LOGIN FAILED")
                            txtUsername.Clear()
                            txtPassword.Clear()
                            txtUsername.Focus()
                            ctr += 1
                        End If
                    Else
                        MsgBox("Incorrect Login Fields!", MsgBoxStyle.Critical, "LOGIN FAILED")
                        txtUsername.Clear()
                        txtPassword.Clear()
                        txtUsername.Focus()
                        ctr += 1
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

    Private Sub SkipLoginCredentials()
        If Not Debugger.IsAttached Then Return

        txtUsername.Text = "admin"
        txtPassword.Text = "admin"
    End Sub
End Class
