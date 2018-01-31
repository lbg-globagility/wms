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
Imports System.Data.OleDb
Public Class ImportProductsForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(Manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim dtExcelData As DataTable
    Dim sqlquery As String
    Dim ipfproductcolorsid, itemno As Integer
    Dim ipfproductsrp, ipfproductsize As Decimal
    Dim lognotesA, lognotesB, lognotesC, ipfimportstatus, ipfseasoncode As String
    Dim ipfproductid, ipfcolorid, ipfbrandid, ipfcategoryid, ipfcompanyid, ipfproductcolorsizesid, ipfskuid As Integer
    Dim ipfproductcode, ipfbrandname, ipfcategoryname, ipfcompanyname, ipfsrp, ipfunitofmeasure, ipfdescription, ipfcolors, ipfsize, ipfsku As String
    Public ipfexcelfilepath As String
    Private Sub ImportProductsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Try
            myModule.systemerrorfound = False
            dgImportProducts.Rows.Clear()
            PrimaryForm.MainLoadingBar.Value = neutralpage
            ImportExcelFile(ipfexcelfilepath)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ImportProductsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            PrimaryForm.MainLoadingBar.Visible = fraud
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
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
                    Me.Cursor = Cursors.WaitCursor
                    lognotesA = "" : lognotesB = "" : lognotesC = ""
                    If Not IsDBNull(dtExcelData.Rows(i)(0)) Then
                        If LTrim(CStr(dtExcelData.Rows(i)(0))) <> "" Then
                            getProductIDB(CStr(dtExcelData.Rows(i)(0)), Me)
                            ipfproductid = globalproductid
                            If Not IsDBNull(dtExcelData.Rows(i)(9)) Then
                                ipfseasoncode = CStr(dtExcelData.Rows(i)(9))
                            Else
                                ipfseasoncode = ""
                            End If
                            If Not IsDBNull(dtExcelData.Rows(i)(7)) Then
                                If LTrim(CStr(dtExcelData.Rows(i)(7))) <> "" Then
                                    ipfcolorid = 0
                                    If Not IsDBNull(dtExcelData.Rows(i)(8)) Then
                                        If IsNumeric(dtExcelData.Rows(i)(8)) Then
                                            ipfproductsize = CDec(dtExcelData.Rows(i)(8))
                                            If ipfproductsize < startingpage Then
                                                lognotesA = "Size should be greater than 0"
                                                ipfimportstatus = "Failed"
                                            End If
                                        Else
                                            ipfproductsize = 0
                                            lognotesA = "Size should be a number"
                                            ipfimportstatus = "Failed"
                                        End If
                                    Else
                                        ipfproductsize = 0
                                        lognotesA = "No Size"
                                        ipfimportstatus = "Failed"
                                    End If
                                    If ipfproductsize > 0 Then
                                        getColorID(CStr(dtExcelData.Rows(i)(7)), Me)
                                        ipfcolorid = globalcolorid
                                        If ipfcolorid = 0 Then
                                            I_Colors(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CStr(dtExcelData.Rows(i)(7)), "", "Active", Me)
                                            getColorID(CStr(dtExcelData.Rows(i)(7)), Me)
                                            ipfcolorid = globalcolorid
                                        End If
                                    End If
                                Else
                                    ipfcolorid = 0
                                    lognotesA = "No Color"
                                    ipfimportstatus = "Failed"
                                End If
                            Else
                                ipfcolorid = 0
                                lognotesA = "No Color"
                                ipfimportstatus = "Failed"
                            End If
                            If ipfproductid = 0 Then
                                If ipfcolorid <> 0 Then
                                    If Not IsDBNull(dtExcelData.Rows(i)(1)) Then
                                        If LTrim(CStr(dtExcelData.Rows(i)(1))) <> "" Then
                                            getBrandID(CStr(dtExcelData.Rows(i)(1)), Me)
                                            ipfbrandid = globalbrandid
                                            If ipfbrandid = 0 Then
                                                I_Brands(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CStr(dtExcelData.Rows(i)(1)), "Active", Me)
                                                getBrandID(CStr(dtExcelData.Rows(i)(1)), Me)
                                                ipfbrandid = globalbrandid
                                            End If
                                        Else
                                            ipfbrandid = 0
                                        End If
                                        ipfbrandname = CStr(dtExcelData.Rows(i)(1))
                                    Else
                                        ipfbrandid = 0
                                        ipfbrandname = ""
                                    End If
                                    If Not IsDBNull(dtExcelData.Rows(i)(2)) Then
                                        If LTrim(CStr(dtExcelData.Rows(i)(2))) <> "" Then
                                            getCategoryID(CStr(dtExcelData.Rows(i)(2)), "", Me)
                                            ipfcategoryid = globalcategoryid
                                            If ipfcategoryid = 0 Then
                                                I_Categories(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CStr(dtExcelData.Rows(i)(2)), "Active", Me)
                                                getCategoryID(CStr(dtExcelData.Rows(i)(2)), "", Me)
                                                ipfcategoryid = globalcategoryid
                                            End If
                                        Else
                                            ipfcategoryid = 0
                                        End If
                                        ipfcategoryname = CStr(dtExcelData.Rows(i)(2))
                                    Else
                                        ipfcategoryid = 0
                                        ipfcategoryname = ""
                                    End If
                                    If Not IsDBNull(dtExcelData.Rows(i)(3)) Then
                                        If LTrim(CStr(dtExcelData.Rows(i)(3))) <> "" Then
                                            getCompanyIDA("AND companyname = """ & CStr(dtExcelData.Rows(i)(3)) & """", "", Me)
                                            ipfcompanyid = globalcompanyid
                                            If ipfcompanyid = 0 Then
                                                I_Companies(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, "", CStr(dtExcelData.Rows(i)(3)), "Active", Me)
                                                getCompanyIDA("AND companyname = """ & CStr(dtExcelData.Rows(i)(3)) & """", "", Me)
                                                ipfcompanyid = globalcompanyid
                                            End If
                                        Else
                                            ipfcompanyid = 0
                                        End If
                                        ipfcompanyname = CStr(dtExcelData.Rows(i)(3))
                                    Else
                                        ipfcompanyid = 0
                                        ipfcompanyname = ""
                                    End If
                                    If Not IsDBNull(dtExcelData.Rows(i)(4)) Then
                                        If IsNumeric(dtExcelData.Rows(i)(4)) Then
                                            ipfproductsrp = CDec(dtExcelData.Rows(i)(4))
                                        Else
                                            ipfproductsrp = 0.0
                                            lognotesB = "SRP should be a number"
                                        End If
                                        ipfsrp = CStr(dtExcelData.Rows(i)(4))
                                    Else
                                        ipfproductsrp = 0.0
                                        ipfsrp = ""
                                        lognotesB = "No SRP"
                                    End If
                                    If Not IsDBNull(dtExcelData.Rows(i)(5)) Then
                                        ipfunitofmeasure = CStr(dtExcelData.Rows(i)(5))
                                    Else
                                        ipfunitofmeasure = ""
                                    End If
                                    If Not IsDBNull(dtExcelData.Rows(i)(6)) Then
                                        ipfdescription = CStr(dtExcelData.Rows(i)(6))
                                    Else
                                        ipfdescription = ""
                                    End If
                                    I_Products(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, If(ipfcategoryid = 0, DBNull.Value, ipfcategoryid), If(ipfbrandid = 0, DBNull.Value, ipfbrandid), If(ipfcompanyid = 0, DBNull.Value, ipfcompanyid), _
                                            CStr(dtExcelData.Rows(i)(0)), CStr(dtExcelData.Rows(i)(0)), ipfbrandname, ipfcategoryname, ipfcompanyname, ipfunitofmeasure, ipfdescription, ipfproductsrp, "Active", Me)
                                    getProductIDB(CStr(dtExcelData.Rows(i)(0)), Me)
                                    ipfproductid = globalproductid
                                    I_ProductColors(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, ipfproductid, ipfcolorid, "Active", Me)
                                    ipfproductcolorsid = globalproductcolorsidsp
                                    If Not IsDBNull(dtExcelData.Rows(i)(10)) Then
                                        If LTrim(CStr(dtExcelData.Rows(i)(10))) <> "" Then
                                            getProductColorSizesSKUA(CStr(dtExcelData.Rows(i)(10)), Me)
                                            ipfskuid = globalskuid
                                            If ipfskuid <> 0 Then
                                                lognotesC = "SKU Already exist"
                                            Else
                                                getProductBundleSKUA(CStr(dtExcelData.Rows(i)(10)), Me)
                                                ipfskuid = globalskuid
                                                If ipfskuid <> 0 Then
                                                    lognotesC = "SKU Already exist"
                                                End If
                                            End If
                                        Else
                                            lognotesC = "No SKU"
                                        End If
                                        ipfsku = CStr(dtExcelData.Rows(i)(10))
                                    Else
                                        ipfsku = ""
                                        lognotesC = "No SKU"
                                    End If
                                    I_ProductColorSizes(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, ipfproductcolorsid, ipfproductsize, ipfseasoncode, If(ipfskuid = 0, ipfsku, ""), "Active", Me)
                                    ipfimportstatus = "Successful"
                                End If
                            Else
                                If ipfcolorid <> 0 Then
                                    getProductColorSizesIDA(ipfproductid, ipfcolorid, ipfproductsize, ipfseasoncode, Me)
                                    ipfproductcolorsizesid = globalproductcolorsizesid
                                    If ipfproductcolorsizesid = 0 Then
                                        If Not IsDBNull(dtExcelData.Rows(i)(10)) Then
                                            If LTrim(CStr(dtExcelData.Rows(i)(10))) <> "" Then
                                                getProductColorSizesSKUA(CStr(dtExcelData.Rows(i)(10)), Me)
                                                ipfskuid = globalskuid
                                                If ipfskuid <> 0 Then
                                                    lognotesC = "SKU Already exist"
                                                Else
                                                    getProductBundleSKUA(CStr(dtExcelData.Rows(i)(10)), Me)
                                                    ipfskuid = globalskuid
                                                    If ipfskuid <> 0 Then
                                                        lognotesC = "SKU Already exist"
                                                    End If
                                                End If
                                            Else
                                                lognotesC = "No SKU"
                                            End If
                                            ipfsku = CStr(dtExcelData.Rows(i)(10))
                                        Else
                                            ipfsku = ""
                                            lognotesC = "No SKU"
                                        End If
                                        getProductColorsID(ipfproductid, ipfcolorid, Me)
                                        ipfproductcolorsid = globalproductcolorsid
                                        If ipfproductcolorsid = 0 Then
                                            I_ProductColors(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, ipfproductid, ipfcolorid, "Active", Me)
                                            ipfproductcolorsid = globalproductcolorsidsp
                                        End If
                                        I_ProductColorSizes(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, ipfproductcolorsid, ipfproductsize, ipfseasoncode, If(ipfskuid = 0, ipfsku, ""), "Active", Me)
                                        ipfimportstatus = "Successful"
                                    Else
                                        lognotesA = "Product Code, Color, Size and Season Code already exist"
                                        ipfimportstatus = "Failed"
                                    End If
                                End If
                            End If
                        Else
                            ipfproductid = 0
                            lognotesA = "No Product Code"
                            ipfimportstatus = "Failed"
                        End If
                    Else
                        ipfproductid = 0
                        lognotesA = "No Product Code"
                        ipfimportstatus = "Failed"
                    End If
                    If Not IsDBNull(dtExcelData.Rows(i)(0)) Then
                        ipfproductcode = CStr(dtExcelData.Rows(i)(0))
                    Else
                        ipfproductcode = ""
                    End If
                    If Not IsDBNull(dtExcelData.Rows(i)(7)) Then
                        ipfcolors = CStr(dtExcelData.Rows(i)(7))
                    Else
                        ipfcolors = ""
                    End If
                    If Not IsDBNull(dtExcelData.Rows(i)(8)) Then
                        ipfsize = CStr(dtExcelData.Rows(i)(8))
                    Else
                        ipfsize = ""
                    End If
                    If Not IsDBNull(dtExcelData.Rows(i)(1)) Then
                        ipfbrandname = CStr(dtExcelData.Rows(i)(1))
                    Else
                        ipfbrandname = ""
                    End If
                    If Not IsDBNull(dtExcelData.Rows(i)(2)) Then
                        ipfcategoryname = CStr(dtExcelData.Rows(i)(2))
                    Else
                        ipfcategoryname = ""
                    End If
                    If Not IsDBNull(dtExcelData.Rows(i)(3)) Then
                        ipfcompanyname = CStr(dtExcelData.Rows(i)(3))
                    Else
                        ipfcompanyname = ""
                    End If
                    If Not IsDBNull(dtExcelData.Rows(i)(4)) Then
                        ipfsrp = CStr(dtExcelData.Rows(i)(4))
                    Else
                        ipfsrp = ""
                    End If
                    If Not IsDBNull(dtExcelData.Rows(i)(5)) Then
                        ipfunitofmeasure = CStr(dtExcelData.Rows(i)(5))
                    Else
                        ipfunitofmeasure = ""
                    End If
                    If Not IsDBNull(dtExcelData.Rows(i)(6)) Then
                        ipfdescription = CStr(dtExcelData.Rows(i)(6))
                    Else
                        ipfdescription = ""
                    End If
                    If Not IsDBNull(dtExcelData.Rows(i)(9)) Then
                        ipfseasoncode = CStr(dtExcelData.Rows(i)(9))
                    Else
                        ipfseasoncode = ""
                    End If
                    If Not IsDBNull(dtExcelData.Rows(i)(10)) Then
                        ipfsku = CStr(dtExcelData.Rows(i)(10))
                    Else
                        ipfsku = ""
                    End If
                    addImportProducts()
                    If dgImportProducts.Rows.Count <> 0 Then
                        itemno = startingpage
                        For s As Integer = 0 To dgImportProducts.Rows.Count - 1
                            dgImportProducts.Rows(s).Cells("im_seqno").Value = itemno
                            itemno = itemno + 1
                        Next s
                    End If
                    If PrimaryForm.MainLoadingBar.Value < dtExcelData.Rows.Count Then
                        PrimaryForm.MainLoadingBar.Value = PrimaryForm.MainLoadingBar.Value + startingpage
                    End If
                    If PrimaryForm.MainLoadingBar.Value = dtExcelData.Rows.Count Then
                        MessageBox.Show("Successfully Imported.", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    Exit Try
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
            cmd.CommandText = ("SELECT * FROM [Products$]")
            da.SelectCommand = cmd
            da.Fill(dt)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
            '   MsgBox("Error 1254: Error Importing the file. Be sure that the file you are trying to import is closed or the file might be corrupted. ", MsgBoxStyle.Critical, "Error Message")
            myModule.systemerrorfound = True
        Finally
            xlsConn.Close()
            xlsConn = Nothing
        End Try
        Return dt
    End Function
    Sub addImportProducts()
        Try
            dgImportProducts.Rows.Add()
            dgImportProducts.Rows(dgImportProducts.Rows.Count - 1).Cells("im_productcode").Value = ipfproductcode
            dgImportProducts.Rows(dgImportProducts.Rows.Count - 1).Cells("im_brandname").Value = ipfbrandname
            dgImportProducts.Rows(dgImportProducts.Rows.Count - 1).Cells("im_categoryname").Value = ipfcategoryname
            dgImportProducts.Rows(dgImportProducts.Rows.Count - 1).Cells("im_companyname").Value = ipfcompanyname
            dgImportProducts.Rows(dgImportProducts.Rows.Count - 1).Cells("im_srp").Value = ipfsrp
            dgImportProducts.Rows(dgImportProducts.Rows.Count - 1).Cells("im_unitofmeasure").Value = ipfunitofmeasure
            dgImportProducts.Rows(dgImportProducts.Rows.Count - 1).Cells("im_description").Value = ipfdescription
            dgImportProducts.Rows(dgImportProducts.Rows.Count - 1).Cells("im_colorname").Value = ipfcolors
            dgImportProducts.Rows(dgImportProducts.Rows.Count - 1).Cells("im_size").Value = ipfsize
            dgImportProducts.Rows(dgImportProducts.Rows.Count - 1).Cells("im_seasoncode").Value = ipfseasoncode
            dgImportProducts.Rows(dgImportProducts.Rows.Count - 1).Cells("im_sku").Value = ipfsku
            dgImportProducts.Rows(dgImportProducts.Rows.Count - 1).Cells("im_status").Value = ipfimportstatus
            dgImportProducts.Rows(dgImportProducts.Rows.Count - 1).Cells("im_lognotes").Value = "" & lognotesA & " / " & lognotesB & " / " & lognotesC & ""
            dgImportProducts.Columns("im_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgImportProducts.Columns("im_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgImportProducts.Columns("im_brandname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgImportProducts.Columns("im_categoryname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgImportProducts.Columns("im_companyname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgImportProducts.Columns("im_srp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgImportProducts.Columns("im_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgImportProducts.Columns("im_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgImportProducts.Columns("im_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgImportProducts.Columns("im_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgImportProducts.Columns("im_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgImportProducts.Columns("im_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub
#End Region
#Region "Datagrid Errors"
    Private Sub dgImportProducts_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgImportProducts.DataError
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
                dgImportProducts.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
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