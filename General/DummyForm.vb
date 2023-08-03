Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports Spire.Barcode

Public Class DummyForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim sqlquery As String
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim fileOpener As OpenFileDialog = New OpenFileDialog()
    Dim printdataset As New DataSetA.SetCDataTable
    Dim printdatatable As New DataTable
    Dim dtExcelData As DataTable
    Dim ImageData() As Byte
    Dim examplecount As Integer = 5
    Dim examplestring As String
    Dim printcount As Integer

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            printcount = 1
            For a = 0 To examplecount - 1
                examplestring = printcount
                bccTestImage.Data = examplestring
                Dim generator As New BarCodeGenerator(bccTestImage)
                Dim barcode As Image = generator.GenerateImage()
                Dim converter As New ImageConverter
                ImageData = converter.ConvertTo(barcode, GetType(Byte()))
                '  printdataset.AddSetCRow("", "", "", "", "", 0, "", ImageData)
                printcount = printcount + 1
            Next
            Dim printreport As New TestPrint
            Dim openreportviewer As New ReportViewer
            openreportviewer.CrystalReportViewer.ReportSource = printreport
            printdatatable = printdataset
            printreport.SetDataSource(printdatatable)
            openreportviewer.Show()
            printdatatable.Dispose()
            printdatatable = Nothing
            printdataset.Clear()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Try
            fileOpener.Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx"
            If fileOpener.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If MessageBox.Show("Would you like to import this file?", "Importing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    PrimaryForm.MainLoadingBar.Value = neutralpage
                    PrimaryForm.MainLoadingBar.Visible = legit
                    ImportExcelFile(fileOpener.FileName)
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

#Region "Functions"

    Sub ImportExcelFile(ByVal iexcelfilepath As String)
        Try
            dtExcelData = New DataTable
            dtExcelData = ReadExcelFile(iexcelfilepath)
            If myModule.systemerrorfound = False Then
                PrimaryForm.MainLoadingBar.Visible = legit
                PrimaryForm.MainLoadingBar.Maximum = dtExcelData.Rows.Count
            Else
                Exit Try
            End If
            For i = 0 To dtExcelData.Rows.Count - 1
                If myModule.systemerrorfound = False Then
                    If Not IsDBNull(dtExcelData.Rows(i)(0)) Then
                        If LTrim(CStr(dtExcelData.Rows(i)(0))) <> "" Then
                            If Not IsDBNull(dtExcelData.Rows(i)(1)) Then
                                If LTrim(CStr(dtExcelData.Rows(i)(1))) <> "" Then
                                    '  I_Branches(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CStr(dtExcelData.Rows(i)(0)), CStr(dtExcelData.Rows(i)(1)), "Active", Me)
                                End If
                            End If
                        End If
                    End If
                Else
                    Exit Try
                End If
                If PrimaryForm.MainLoadingBar.Value < dtExcelData.Rows.Count Then
                    PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                End If
            Next
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
            dtExcelData = Nothing
        End Try
    End Sub

    Function ReadExcelFile(ByVal eexcelfilepath As String)
        Dim da As New OleDbDataAdapter
        Dim dt As New DataTable
        Dim cmd As New OleDbCommand
        Dim xlsConn As OleDbConnection
        Dim sPath As String = String.Empty
        sPath = eexcelfilepath
        xlsConn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sPath & ";Extended Properties=Excel 12.0")
        Try
            xlsConn.Open()
            cmd.Connection = xlsConn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = ("SELECT * FROM [Sheet1$]")
            da.SelectCommand = cmd
            da.Fill(dt)
        Catch
            MsgBox("Error 1254: Error Importing the file. Be sure that the file you are trying to import is closed or the file might be corrupted. ", MsgBoxStyle.Critical, "Error Message")
            myModule.systemerrorfound = True
        Finally
            xlsConn.Close()
            xlsConn = Nothing
        End Try
        Return dt
    End Function

#End Region

End Class