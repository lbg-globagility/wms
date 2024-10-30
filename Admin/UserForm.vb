Imports System.IO
Imports MySql.Data.MySqlClient

Public Class UserForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim fs As FileStream
    Dim br As BinaryReader
    Dim cue As String
    Dim ImageData() As Byte
    Dim AttachedFile As Object
    Dim itemno, rowscount As Integer
    Dim thefilepath As String = Nothing
    Dim saveuserid, positionid As Integer
    Dim FileName, FileExtension As String
    Dim susername, spassword, decryptusername, decryptpassword, encryptusername, encryptpassword As String

    Private Sub UserForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            displayUserDetails()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub UserForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
        autocompletePosition()
    End Sub

    Sub callAutoPopulateFunctions()
        autopopulatePosition()
        autopopulateStatus()
    End Sub

#Region "Clear/Enable/Visible Functions"

    Sub clearfields()
        Try
            cue = ""
            clearUserInformation()
            clearAttachment()
            enableGB(legit, fraud, fraud)
            enableANDvisibleMS(legit, fraud, fraud)
            dgAttachments.Rows.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearUserInformation()
        Try
            txtEmailAddress.Text = ""
            txtComments.Text = ""
            txtUsername.Text = ""
            txtPassword.Text = ""
            txtFName.Text = ""
            txtMName.Text = ""
            txtLName.Text = ""
            cboPosition.Text = ""
            cboStatus.SelectedItem = Nothing
            cboPosition.SelectedItem = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearAttachment()
        Try
            txtFileName.Text = ""
            txtFileRemarks.Text = ""
            txtFilePath.Clear()
            txtFileExtension.Clear()
            pbImage.Image = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearTabAttachment2()
        Try
            txtFileName.Text = ""
            txtFileRemarks.Text = ""
            txtFilePath.Clear()
            txtFileExtension.Clear()
            pbImage.Image = Nothing
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean, ByVal enable2 As Boolean, ByVal enable3 As Boolean)
        Try
            gbUserList.Enabled = enable1
            gbUser.Enabled = enable2
            gbAttachment.Enabled = enable3
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enablegbAddAttachment(ByVal enable1 As Boolean, ByVal enable2 As Boolean)
        Try
            txtFileName.Enabled = enable1
            txtFileRemarks.Enabled = enable1
            dgAttachments.Enabled = enable2
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

#Region "Click Functions"

    Sub tsrefreshperformclick()
        Try
            errProvider.Clear()
            clearfields()
            callAutoCompleteFunctions()
            callAutoPopulateFunctions()
            displayUserDetails()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Attachments Functions"

    Sub getAttachment(ByVal rowid As Integer)
        Try
            FileExtension = "" : AttachedFile = Nothing
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtAtt As New DataTable
            dtAtt = getDataTableForSQL("SELECT filetype,attachedfile FROM attachments WHERE rowid = '" & rowid & "' ")
            If dtAtt.Rows.Count <> 0 Then
                FileExtension = dtAtt.Rows(0)(0)
                AttachedFile = dtAtt.Rows(0)(1)
            Else
                FileExtension = "" : AttachedFile = Nothing
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub ShowImage()
        Try
            If IsDBNull(AttachedFile) Then
                pbImage.Image = Nothing
            Else
                If FileExtension = ".jpg" Or FileExtension = ".jpeg" Or FileExtension = ".bmp" Or FileExtension = ".png" Then
                    pbImage.Image = ConvertByteToImage(AttachedFile)
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub downloadImage(ByVal dgattachmentfilename As String)
        Dim image As Image = pbImage.Image
        Dim filename As String = dgattachmentfilename
        Dim ctr As Integer = 0
        Dim sFilename As String = "Image_"
        Dim ext As String = ".jpeg"
        If (Not System.IO.Directory.Exists("c:\AttachedImages")) Then
            System.IO.Directory.CreateDirectory("c:\AttachedImages")
            Dim path As String = System.IO.Path.Combine("c:\AttachedImages", sFilename & ctr & ext)
            Dim dest As New Bitmap(image.Width, image.Height)
            Dim gfx As Graphics = Graphics.FromImage(dest)
            gfx.DrawImageUnscaled(image, Point.Empty)
            gfx.Dispose()
            dest.Save(path)
            dest.Dispose()
            MessageBox.Show("Image saved to c:\AttachedImages as " & sFilename & ctr & ext, "System Message")
            Dim info As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(path)
            path = info.DirectoryName
            Shell("explorer /select, " & "c:\AttachedImages\" & sFilename & ctr & ext, vbNormalFocus)
        Else
            ctr = 0
            While ctr >= 0
                Dim path As String = System.IO.Path.Combine("c:\AttachedImages", sFilename & ctr & ext)
                If System.IO.File.Exists(path) = True Then
                    ctr = ctr + 1

                    Continue While
                ElseIf System.IO.File.Exists(path) = False Then
                    Dim newPath As String = System.IO.Path.Combine("c:\AttachedImages", sFilename & ctr & ext)
                    Dim dest As New Bitmap(image.Width, image.Height)
                    Dim gfx As Graphics = Graphics.FromImage(dest)
                    gfx.DrawImageUnscaled(image, Point.Empty)
                    gfx.Dispose()
                    dest.Save(newPath)
                    dest.Dispose()
                    MessageBox.Show("Image saved to c:\Attached_Images as " & sFilename & ctr & ext, "System Message")
                    Shell("explorer /select, " & "c:\AttachedImages\" & sFilename & ctr & ext, vbNormalFocus)
                    Exit While
                End If
            End While
        End If
    End Sub

    Public Function downloadFile(ByVal rowid As Integer, ByVal sFileName As String, ByVal sFileExtension As String)
        Try
            sqlquery = "SELECT attachedfile FROM attachments WHERE rowid = '" & rowid & "' "
            Dim sqlcmd As New MySqlCommand(sqlquery, conn)
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim fileData As Byte() = DirectCast(sqlcmd.ExecuteScalar(), Byte())
            If (Not System.IO.Directory.Exists("c:\AttachedFiles")) Then
                System.IO.Directory.CreateDirectory("c:\AttachedFiles")
                Dim sTempFileName As String = System.IO.Path.Combine("c:\AttachedFiles", sFileName)
                If Not fileData Is Nothing Then
                    Using fs As New FileStream(sTempFileName, FileMode.OpenOrCreate, FileAccess.Write)
                        fs.Write(fileData, 0, fileData.Length)
                        MsgBox("File saved to c:\AttachedFiles as " & sFileName, MsgBoxStyle.Information, "System Message")
                        Dim info As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(sTempFileName)
                        Shell("explorer /select, " & "c:\AttachedFiles\" & sFileName, vbNormalFocus)
                        fs.Flush()
                        fs.Close()
                        Process.Start(sTempFileName)
                    End Using
                End If
            Else
                Dim sTempFileName As String = System.IO.Path.Combine("c:\AttachedFiles", sFileName)
                If Not fileData Is Nothing Then
                    Using fs As New FileStream(sTempFileName, FileMode.OpenOrCreate, FileAccess.Write)
                        fs.Write(fileData, 0, fileData.Length)
                        MsgBox("File saved to c:\AttachedFiles as " & sFileName, MsgBoxStyle.Information, "System Message")
                        Dim info As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(sTempFileName)
                        Shell("explorer /select, " & "c:\AttachedFiles\" & sFileName, vbNormalFocus)
                        fs.Flush()
                        fs.Close()
                        Process.Start(sTempFileName)
                    End Using
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Return True
    End Function

#End Region

#Region "Display Functions"

#Region "AutoComplete Functions"

    Sub autocompletePosition()
        Try
            Dim positionname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT positionname FROM positions WHERE status = 'Active' AND organizationid = " & Z_OrganizationID & " ", conn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                positionname.Add(ds.Tables(0).Rows(i)("positionname").ToString())
            Next
            cboPosition.AutoCompleteSource = AutoCompleteSource.CustomSource
            cboPosition.AutoCompleteCustomSource = positionname
            cboPosition.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
        End Try
        conn.Close()
    End Sub

#End Region

#Region "AutoPopulate Functions"

    Sub autopopulatePosition()
        Try
            cboPosition.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT positionname FROM positions WHERE status = 'Active' AND organizationid = " & Z_OrganizationID & " ORDER BY positionname "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                cboPosition.Items.Add(reader1(0).ToString())
            End While
            reader1.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub autopopulateStatus()
        Try
            cboStatus.Items.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim sql1 As String = "SELECT lic FROM listofvalues WHERE type = 'Status' AND status = 'Active' ORDER BY lic "
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                cboStatus.Items.Add(reader1(0).ToString())
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

#Region "Display"

    Public Function displayUserDetails()
        If conn.State = ConnectionState.Open Then conn.Close()
        sqlquery = "SELECT u.rowid,COALESCE(u.emailaddress,''),COALESCE(u.comments,''),COALESCE(u.firstname,''),COALESCE(u.middlename,''),COALESCE(u.lastname,'')," &
            "COALESCE(p.positionname,''),COALESCE(u.status,'') FROM users u LEFT JOIN positions p ON u.positionid = p.rowid  " &
            "WHERE u.organizationid = '" & Z_OrganizationID & "' ORDER BY u.rowid "
        dgUsers.Rows.Clear()
        Dim sqlcmd As New MySqlCommand(sqlquery, conn)
        conn.Open()
        Dim sqlrd As MySqlDataReader = sqlcmd.ExecuteReader
        sqlcmd = Nothing
        If sqlrd.HasRows Then
            Try
                Dim n As Integer = 0
                While sqlrd.Read
                    dgUsers.Rows.Add()
                    dgUsers.Item(u_rowid.Index, n).Value = sqlrd(0)
                    dgUsers.Item(u_emailaddress.Index, n).Value = sqlrd(1)
                    dgUsers.Item(u_comments.Index, n).Value = sqlrd(2)
                    dgUsers.Item(u_fname.Index, n).Value = sqlrd(3)
                    dgUsers.Item(u_mname.Index, n).Value = sqlrd(4)
                    dgUsers.Item(u_lname.Index, n).Value = sqlrd(5)
                    dgUsers.Item(u_position.Index, n).Value = sqlrd(6)
                    dgUsers.Item(u_status.Index, n).Value = sqlrd(7)
                    n = n + 1
                End While
                Return True
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, Me.Name))
                sqlrd.Close()
                conn.Close()
                Return False
            Finally
                If dgUsers.Rows.Count <> 0 Then
                    dgUsers.CurrentRow.Selected = False
                End If
                sqlrd.Close()
                conn.Close()
            End Try
            Return True
        End If
        conn.Close()
        Return Nothing
    End Function

    Public Function displayUserAttachments(ByVal iuserid As Integer)
        If conn.State = ConnectionState.Open Then conn.Close()
        sqlquery = "SELECT a.rowid,a.filename,a.filetype,a.remarks,DATE_FORMAT(a.created,'%d-%b-%Y'),COALESCE(DATE_FORMAT(a.lastupd,'%d-%b-%Y'),'') FROM attachments a " &
            "WHERE a.organizationid = " & Z_OrganizationID & " AND a.createdby = " & iuserid & " AND a.status = 'Active' ORDER BY a.filename "
        dgAttachments.Rows.Clear()
        Dim sqlcmd As New MySqlCommand(sqlquery, conn)
        conn.Open()
        Dim sqlrd As MySqlDataReader = sqlcmd.ExecuteReader
        sqlcmd = Nothing
        If sqlrd.HasRows Then
            Try
                Dim n As Integer = 0
                Dim seqno As Integer = 1
                While sqlrd.Read
                    dgAttachments.Rows.Add()
                    dgAttachments.Item(a_rowid.Index, n).Value = sqlrd(0)
                    dgAttachments.Item(a_no.Index, n).Value = seqno
                    dgAttachments.Item(a_filename.Index, n).Value = sqlrd(1)
                    dgAttachments.Item(a_fileextension.Index, n).Value = sqlrd(2)
                    dgAttachments.Item(a_remarks.Index, n).Value = sqlrd(3)
                    dgAttachments.Item(a_datecreated.Index, n).Value = sqlrd(4)
                    dgAttachments.Item(a_lastupd.Index, n).Value = sqlrd(5)
                    seqno = seqno + 1
                    n = n + 1
                End While
                Return True
            Catch ex As Exception
                MsgBox(getErrExcptn(ex, Me.Name))
                sqlrd.Close()
                conn.Close()
                Return False
            Finally
                If dgAttachments.Rows.Count <> 0 Then
                    dgAttachments.CurrentRow.Selected = False
                End If
                sqlrd.Close()
                conn.Close()
            End Try
            Return True
        End If
        conn.Close()
        Return Nothing
    End Function

#End Region

#End Region

#Region "Saving Functions"

    Sub getUserInfo(ByVal iuserid As Integer)
        Try
            getUserInformmation(iuserid)
            decryptUserInformation(susername, spassword)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getUserInformmation(ByVal euserid As Integer)
        Try
            susername = "" : spassword = ""
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtUin As New DataTable
            dtUin = getDataTableForSQL("SELECT userid,password FROM users WHERE rowid = " & euserid & " ")
            If dtUin.Rows.Count <> 0 Then
                susername = dtUin.Rows(0)(0)
                spassword = dtUin.Rows(0)(1)
            Else
                susername = "" : spassword = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub decryptUserInformation(ByVal iusername As String, ByVal ipassword As String)
        Try
            decryptusername = Nothing : decryptpassword = Nothing
            If iusername <> "" Then
                For Each x As Char In iusername
                    Dim ToCOn As Integer = Convert.ToInt64(x) - 133
                    decryptusername &= Convert.ToChar(Convert.ToInt64(ToCOn))
                Next
            End If
            If ipassword <> "" Then
                For Each x As Char In ipassword
                    Dim ToCOn As Integer = Convert.ToInt64(x) - 133
                    decryptpassword &= Convert.ToChar(Convert.ToInt64(ToCOn))
                Next
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub encryptUserInformation(ByVal iusername As String, ByVal ipassword As String)
        Try
            encryptusername = Nothing : encryptpassword = Nothing
            If iusername <> "" Then
                For Each x As Char In iusername
                    Dim ToCOn As Integer = Convert.ToInt64(x) + 133
                    encryptusername &= Convert.ToChar(Convert.ToInt64(ToCOn))
                Next
            End If
            If ipassword <> "" Then
                For Each x As Char In ipassword
                    Dim ToCOn As Integer = Convert.ToInt64(x) + 133
                    encryptpassword &= Convert.ToChar(Convert.ToInt64(ToCOn))
                Next
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getUserID(ByVal iusername As String)
        Try
            saveuserid = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtUid As New DataTable
            dtUid = getDataTableForSQL("SELECT rowid FROM users WHERE userid = """ & iusername & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtUid.Rows.Count <> 0 Then
                saveuserid = dtUid.Rows(0)(0)
            Else
                saveuserid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getUpdUserID(ByVal iuserid As Integer, ByVal iusername As String)
        Try
            saveuserid = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtUid As New DataTable
            dtUid = getDataTableForSQL("SELECT rowid FROM users WHERE userid = """ & iusername & """ AND organizationid = " & Z_OrganizationID & " AND rowid != " & iuserid & " ")
            If dtUid.Rows.Count <> 0 Then
                saveuserid = dtUid.Rows(0)(0)
            Else
                saveuserid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getPositionIDA(ByVal ipositionname As String)
        Try
            positionid = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim dtPid As New DataTable
            dtPid = getDataTableForSQL("SELECT rowid FROM positions WHERE positionname = """ & ipositionname & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtPid.Rows.Count <> 0 Then
                positionid = dtPid.Rows(0)(0)
            Else
                positionid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

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
                PrimaryForm.UsrForm = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboStatus_Leave(sender As Object, e As EventArgs) Handles cboStatus.Leave
        Try
            txtUsername.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnAddFile_Leave(sender As Object, e As EventArgs) Handles btnAddFile.Leave
        Try
            txtFileName.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
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

    Private Sub msNew_Click(sender As Object, e As EventArgs) Handles msNew.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Users", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.UsrForm = False
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
            clearUserInformation()
            clearAttachment()
            dgAttachments.Rows.Clear()
            enableGB(fraud, legit, legit)
            enableANDvisibleMS(fraud, legit, legit)
            enablegbAddAttachment(fraud, fraud)
            If dgUsers.Rows.Count <> 0 Then
                dgUsers.CurrentRow.Selected = False
            End If
            txtUsername.Focus()
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
            If dgUsers.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearUserInformation()
                clearAttachment()
                enableGB(legit, legit, legit)
                enableANDvisibleMS(legit, legit, fraud)
                enablegbAddAttachment(fraud, legit)
                dgUsers.CurrentRow.Selected = True
                txtFName.Text = dgUsers.CurrentRow.Cells("u_fname").Value
                txtMName.Text = dgUsers.CurrentRow.Cells("u_mname").Value
                txtLName.Text = dgUsers.CurrentRow.Cells("u_lname").Value
                cboPosition.Text = dgUsers.CurrentRow.Cells("u_position").Value
                txtEmailAddress.Text = dgUsers.CurrentRow.Cells("u_emailaddress").Value
                txtComments.Text = dgUsers.CurrentRow.Cells("u_comments").Value
                cboStatus.Text = dgUsers.CurrentRow.Cells("u_status").Value
                getUserInfo(CInt(dgUsers.CurrentRow.Cells("u_rowid").Value))
                txtUsername.Text = decryptusername
                txtPassword.Text = decryptpassword
                displayUserAttachments(CInt(dgUsers.CurrentRow.Cells("u_rowid").Value))
                txtUsername.Focus()
            Else
                tsrefreshperformclick()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgUsers.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgUsers.Rows.Count <> 0 Then
                cue = "Edit"
                errProvider.Clear()
                clearUserInformation()
                clearAttachment()
                enableGB(legit, legit, legit)
                enableANDvisibleMS(legit, legit, fraud)
                enablegbAddAttachment(fraud, legit)
                txtFName.Text = dgUsers.CurrentRow.Cells("u_fname").Value
                txtMName.Text = dgUsers.CurrentRow.Cells("u_mname").Value
                txtLName.Text = dgUsers.CurrentRow.Cells("u_lname").Value
                cboPosition.Text = dgUsers.CurrentRow.Cells("u_position").Value
                txtEmailAddress.Text = dgUsers.CurrentRow.Cells("u_emailaddress").Value
                txtComments.Text = dgUsers.CurrentRow.Cells("u_comments").Value
                cboStatus.Text = dgUsers.CurrentRow.Cells("u_status").Value
                getUserInfo(CInt(dgUsers.CurrentRow.Cells("u_rowid").Value))
                txtUsername.Text = decryptusername
                txtPassword.Text = decryptpassword
                displayUserAttachments(CInt(dgUsers.CurrentRow.Cells("u_rowid").Value))
                txtUsername.Focus()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgUsers_KeyUp(sender As Object, e As KeyEventArgs) Handles dgUsers.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgUsers.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    cue = "Edit"
                    errProvider.Clear()
                    clearUserInformation()
                    clearAttachment()
                    enableGB(legit, legit, legit)
                    enableANDvisibleMS(legit, legit, fraud)
                    enablegbAddAttachment(fraud, legit)
                    txtFName.Text = dgUsers.CurrentRow.Cells("u_fname").Value
                    txtMName.Text = dgUsers.CurrentRow.Cells("u_mname").Value
                    txtLName.Text = dgUsers.CurrentRow.Cells("u_lname").Value
                    cboPosition.Text = dgUsers.CurrentRow.Cells("u_position").Value
                    txtEmailAddress.Text = dgUsers.CurrentRow.Cells("u_emailaddress").Value
                    txtComments.Text = dgUsers.CurrentRow.Cells("u_comments").Value
                    cboStatus.Text = dgUsers.CurrentRow.Cells("u_status").Value
                    getUserInfo(CInt(dgUsers.CurrentRow.Cells("u_rowid").Value))
                    txtUsername.Text = decryptusername
                    txtPassword.Text = decryptpassword
                    displayUserAttachments(CInt(dgUsers.CurrentRow.Cells("u_rowid").Value))
                    txtUsername.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtUsername_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            encryptUserInformation(txtUsername.Text, txtPassword.Text)
            If cue = "New" Then
                getUserID(encryptusername)
                If saveuserid <> 0 Then
                    errProvider.SetError(txtUsername, "Username has been created already, please type a new one or else there would be an error once this would be save")
                End If
            ElseIf cue = "Edit" Then
                If dgUsers.Rows.Count <> 0 Then
                    getUpdUserID(CInt(dgUsers.CurrentRow.Cells("u_rowid").Value), encryptusername)
                    If saveuserid <> 0 Then
                        errProvider.SetError(txtUsername, "Username has been created already, please type a new one or else there would be an error once this would be save")
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

    'Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        encryptUserInformation(txtUsername.Text, txtPassword.Text)
    '        If cue = "New" Then
    '            getUserID(encryptusername)
    '            If saveuserid <> 0 Then
    '                errProvider.SetError(txtUsername, "Username has been created already, please type a new one or else there would be an error once this would be save")
    '            End If
    '        ElseIf cue = "Edit" Then
    '            If dgUsers.Rows.Count <> 0 Then
    '                getUpdUserID(CInt(dgUsers.CurrentRow.Cells("u_rowid").Value), encryptusername)
    '                If saveuserid <> 0 Then
    '                    errProvider.SetError(txtUsername, "Username has been created already, please type a new one or else there would be an error once this would be save")
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
    Private Async Sub btnAddFile_Click(sender As Object, e As EventArgs) Handles btnAddFile.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Users", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.UsrForm = False
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
            Using ofd As New OpenFileDialog
                ofd.Filter = "Files (*.bmp;*.jpg;*.jpeg;*.png;*.txt;*.doc;*.docx;*.pdf;*.xls;*.xlsx)|*.bmp;*.jpg;*.jpeg;*.png;*.txt;*.doc;*.docx;*.pdf;*.xls;*.xlsx"
                If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    txtFileName.Enabled = True
                    txtFileRemarks.Enabled = True
                    pbImage.Image = Nothing
                    txtFileName.Text = ""
                    txtFileRemarks.Text = ""
                    txtFilePath.Text = ofd.FileName
                    If Path.GetExtension(txtFilePath.Text) = ".jpg" Or Path.GetExtension(txtFilePath.Text) = ".jpeg" Or Path.GetExtension(txtFilePath.Text) = ".bmp" Or Path.GetExtension(txtFilePath.Text) = ".png" Then
                        pbImage.Image = Image.FromFile(ofd.FileName)
                    End If
                    If Path.GetExtension(txtFilePath.Text) = ".txt" Then
                        txtFileExtension.Text = ".txt"
                    ElseIf Path.GetExtension(txtFilePath.Text) = ".pdf" Then
                        txtFileExtension.Text = ".pdf"
                    ElseIf Path.GetExtension(txtFilePath.Text) = ".doc" Then
                        txtFileExtension.Text = ".doc"
                    ElseIf Path.GetExtension(txtFilePath.Text) = ".docx" Then
                        txtFileExtension.Text = ".docx"
                    ElseIf Path.GetExtension(txtFilePath.Text) = ".xls" Then
                        txtFileExtension.Text = ".xls"
                    ElseIf Path.GetExtension(txtFilePath.Text) = ".xlsx" Then
                        txtFileExtension.Text = ".xlsx"
                    ElseIf Path.GetExtension(txtFilePath.Text) = ".jpg" Then
                        txtFileExtension.Text = ".jpg"
                    ElseIf Path.GetExtension(txtFilePath.Text) = ".jpeg" Then
                        txtFileExtension.Text = ".jpeg"
                    ElseIf Path.GetExtension(txtFilePath.Text) = ".bmp" Then
                        txtFileExtension.Text = ".bmp"
                    ElseIf Path.GetExtension(txtFilePath.Text) = ".png" Then
                        txtFileExtension.Text = ".png"
                    Else
                        MessageBox.Show("File not valid", "System Message")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    txtFileName.Focus()
                Else
                    If txtFileName.Enabled = True Then
                        txtFileName.Focus()
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClearFile_Click(sender As Object, e As EventArgs) Handles btnClearFile.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            clearTabAttachment2()
            enablegbAddAttachment(fraud, legit)
            If dgAttachments.Rows.Count <> 0 Then
                dgAttachments.CurrentRow.Selected = False
            End If
            btnAddFile.Focus()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgAttachments_MouseUp(sender As Object, e As MouseEventArgs) Handles dgAttachments.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgAttachments.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgAttachments.BeginEdit(True)
                Else
                    dgAttachments.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgAttachments_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAttachments.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgAttachments.Rows.Count <> 0 Then
                txtFileName.Enabled = False
                txtFileRemarks.Enabled = False
                txtFileName.Text = ""
                txtFileRemarks.Text = ""
                txtFilePath.Clear()
                txtFileExtension.Clear()
                pbImage.Image = Nothing
                getAttachment(CInt(dgAttachments.CurrentRow.Cells("a_rowid").Value))
                ShowImage()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgAttachments_KeyUp(sender As Object, e As KeyEventArgs) Handles dgAttachments.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgAttachments.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    txtFileName.Enabled = False
                    txtFileRemarks.Enabled = False
                    txtFileName.Text = ""
                    txtFileRemarks.Text = ""
                    txtFilePath.Clear()
                    txtFileExtension.Clear()
                    pbImage.Image = Nothing
                    getAttachment(CInt(dgAttachments.CurrentRow.Cells("a_rowid").Value))
                    ShowImage()
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
            dgAttachments.CommitEdit(True)
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Users", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.UsrForm = False
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
            encryptUserInformation(txtUsername.Text, txtPassword.Text)
            If cue = "New" Then
                getUserID(encryptusername)
            ElseIf cue = "Edit" Then
                If Await IsValidCreateAccessAsync(createFlag:=globalcreateflg, updateFlag:=globalupdateflg) Then
                    MessageBox.Show("The user is not allowed to make any changes in this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
                If dgUsers.Rows.Count <> 0 Then
                    getUpdUserID(CInt(dgUsers.CurrentRow.Cells("u_rowid").Value), encryptusername)
                End If
            End If
            getPositionIDA(cboPosition.Text)
            If LTrim(txtUsername.Text) = "" AndAlso LTrim(txtPassword.Text) = "" AndAlso LTrim(cboPosition.Text) = "" AndAlso LTrim(cboStatus.Text) = "" Then
                errProvider.SetError(txtUsername, "Please fill-up these fields")
                errProvider.SetError(txtPassword, "Please fill-up these fields")
                errProvider.SetError(cboPosition, "Please fill-up these fields")
                errProvider.SetError(cboStatus, "Please fill-up these fields")
                txtUsername.Focus()
            ElseIf LTrim(txtUsername.Text) = "" Then
                errProvider.SetError(txtUsername, "Please enter the username of the user")
                txtUsername.Focus()
            ElseIf LTrim(txtPassword.Text) = "" Then
                errProvider.SetError(txtPassword, "Please enter the password of the user")
                txtPassword.Focus()
            ElseIf LTrim(cboPosition.Text) = "" Then
                errProvider.SetError(cboPosition, "Please choose the position of the user")
                cboPosition.Focus()
            ElseIf LTrim(cboStatus.Text) = "" Then : errProvider.SetError(cboStatus, "Please choose the status of the user")
                cboStatus.Focus()
            ElseIf positionid = 0 Then
                errProvider.SetError(cboPosition, "Please check the spelling or choose from the list of the position then try saving again")
                cboPosition.Focus()
            ElseIf saveuserid <> 0 Then
                errProvider.SetError(txtUsername, "Username has been created already, please type a new one")
                txtUsername.Focus()
            Else
                If MessageBox.Show("Would you like to save the changes in this page? ", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    encryptUserInformation(txtUsername.Text, txtPassword.Text)
                    If cue = "New" Then
                        I_Users(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, encryptusername, encryptpassword, If(positionid = 0, DBNull.Value, positionid), txtFName.Text, txtMName.Text, txtLName.Text, txtEmailAddress.Text, cboStatus.Text, txtComments.Text, Me)
                        getUserID(encryptusername)
                        If txtFilePath.Text <> "" Then
                            FileName = txtFilePath.Text
                            fs = New FileStream(FileName, FileMode.Open, FileAccess.Read)
                            br = New BinaryReader(fs)
                            ImageData = br.ReadBytes(CType(fs.Length, Integer))
                            br.Close()
                            fs.Close()
                            I_Attachments(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), saveuserid, Z_UserID, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, ImageData, txtFileName.Text, txtFileExtension.Text, txtFileRemarks.Text, "Active", Me)
                        End If
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Save", "Save", lblsavemsg, -15, -65)
                        End If
                    ElseIf cue = "Edit" Then
                        U_Users(CInt(dgUsers.CurrentRow.Cells("u_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, encryptusername, encryptpassword, If(positionid = 0, DBNull.Value, positionid), txtFName.Text, txtMName.Text, txtLName.Text, txtEmailAddress.Text, cboStatus.Text, txtComments.Text, Me)
                        For c = 0 To dgAttachments.Rows.Count - 1
                            U_Attachments(CInt(dgAttachments.Rows(c).Cells("a_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, dgAttachments.Rows(c).Cells("a_filename").Value, dgAttachments.Rows(c).Cells("a_remarks").Value, Me)
                        Next
                        If txtFilePath.Text <> "" Then
                            FileName = txtFilePath.Text
                            fs = New FileStream(FileName, FileMode.Open, FileAccess.Read)
                            br = New BinaryReader(fs)
                            ImageData = br.ReadBytes(CType(fs.Length, Integer))
                            br.Close()
                            fs.Close()
                            I_Attachments(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), CInt(dgUsers.CurrentRow.Cells("u_rowid").Value), Z_UserID, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, ImageData, txtFileName.Text, txtFileExtension.Text, txtFileRemarks.Text, "Active", Me)
                        End If
                        If myModule.systemerrorfound = False Then
                            myBalloon("Successfully Updated", "Update", lblsavemsg, -15, -65)
                        End If
                    Else
                    End If
                    If myModule.systemerrorfound = False Then
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

    Private Async Sub dgAttachments_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAttachments.CellContentClick
        Try
            itemno = 1
            dgAttachments.CommitEdit(True)
            myModule.systemerrorfound = False
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Users", Me)
                If globaldisableflg = "Y" Then
                    MessageBox.Show("The user is not allowed to enter this form.", "Displaying", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PrimaryForm.UsrForm = False
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
            If e.ColumnIndex = dgAttachments.Columns("a_remove").Index Then
                If MessageBox.Show("Would you like to remove this attachment to this order?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    U_AttachmentStatus(CInt(dgAttachments.CurrentRow.Cells("a_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Inactive")
                    If myModule.systemerrorfound = False Then
                        If dgAttachments.SelectedRows.Count > 0 Then
                            dgAttachments.Rows.Remove(dgAttachments.SelectedRows(0))
                        End If
                        myBalloon("Successfully Removed", "Remove", lblsavemsg, -15, -65)
                    End If
                End If
                For i As Integer = 0 To dgAttachments.Rows.Count - 1
                    dgAttachments.Rows(i).Cells("a_no").Value = itemno
                    itemno = itemno + 1
                Next i
            ElseIf e.ColumnIndex = dgAttachments.Columns("a_download").Index Then
                If MessageBox.Show("Would you like to download this attachment?", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    getAttachment(CInt(dgAttachments.CurrentRow.Cells("a_rowid").Value))
                    If FileExtension = ".jpg" Or FileExtension = ".jpeg" Or FileExtension = ".bmp" Or FileExtension = ".png" Then
                        downloadImage(dgAttachments.CurrentRow.Cells("a_filename").Value)
                    Else
                        downloadFile(CInt(dgAttachments.CurrentRow.Cells("a_rowid").Value), dgAttachments.CurrentRow.Cells("a_filename").Value, dgAttachments.CurrentRow.Cells("a_fileextension").Value)
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

    Private Sub dgAttachments_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgAttachments.DataError
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
                dgAttachments.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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