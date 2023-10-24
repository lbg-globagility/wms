Imports System.IO
Imports Microsoft.Extensions.DependencyInjection
Imports MySql.Data.MySqlClient

Module myModule
    Dim formatcount As Integer
    Public colorconverter As New ColorConverter
    Public globalconn As New MySqlConnection
    Public da As New MySqlDataAdapter
    Public cmd As New MySqlCommand
    Public hintInfo As ToolTip
    Public readcolor As Color
    Public ballooncue As Boolean
    Public pesosign As Char = "₱"
    Public legit As Boolean = True
    Public fraud As Boolean = False
    Public secondpage As Integer = 2
    Public neutralpage As Integer = 0
    Public systemerrorfound As Boolean
    Public startingpage As Integer = 1
    Public pagedivisor As Integer = 100
    Public commissionrateA As Integer = 1
    Public commissionrateB As Integer = 2
    Public commissionrateC As Integer = 3
    Public commissionrateD As Integer = 4
    Public commantimeoutlimit As Integer = 999999
    Public globalreferenceno As Decimal
    Public sys_servername, sys_userid, sys_password, sys_db As String
    Public globaltotalqtyapplied, globalprintorder, globaltotalqtyordered As Integer
    Public globalshiftid, globaldeliverytruckshiftid, globallineupno, globallineupid, globalpositionid As Integer
    Public globalpiltotalavailableqty, globalpiltotalreserveqty, globalpackinglistcartonitemqtyincarton As Integer
    Public globalorderitemsrp, globalordertotalamount, globalpackedweight, globalpackedamount, globalcbm As Decimal
    Public globalcyclecountno, globaltotalqtyallocated, globalpicklistorderitemqtypicked, globallineupcbmid As Integer
    Public globalpicklistgroupid, globalorderitemqtyordered, globalpicklistno, globalcontactno, globalpicklistorderid As Integer
    Public globalcartonno, globalpackinglistcartonitemid, globalpackedby, globaldeliverytruckno, globaldeliverytruckid As Integer
    Public globalcontactid, globalpicklistorderitemid, globalpicklistid, globalpicklistordercount, globalpackinglistno As Integer
    Public globalorganizationid, globalskuid, globalSKU2id, globalcolorid, globalproductcolorsizesid, globalproductcolorsid, globaluserid As Integer
    Public globalcustomerid, globalaccountno, globalproductbundleid, globalproductbundleitemid, globalorderno, globalorderid As Integer
    Public globalbranchid, globalcombinecodingid, globalcodingid, globalcartonsizeid, globallistofvaluesid, globalorderitemid As Integer
    Public globaltotalqtyavailable, globaltotalqtyreserve, globaltotalqtydamage, globalpackinglistid, globalpackinglistcartonid As Integer
    Public globalinventorylocationid, globalrackshelfcolumnid, globalproductid, globalcategoryid, globalbrandid, globalcompanyid As Integer
    Public globalpicklistorderstatus, globalorderitemstatus, globalorderdate, globaltargetdate, globalpackername, globalpackeddate As String
    Public globalpackedweightuom, globalpackedsizeinfo, globalpackingliststatus, globalpackinglistcartonitemstatus, globalboxsizename As String
    Public globaladdressname, globalcontactname, globalorderstatus, globalpickliststatus, globalusername, globalpicklistorderitemremarks As String
    Public globalcreateflg, globalupdateflg, globaldisableflg, globalreadonlyflg, globalpicklistorderitemissueflg, globalorderitemapproveflg As Char
    Public globalpackinglistcartonstatus, globalpackedcartonno, globaldeliveryhours, globallineupstatus, globallineupcartonstatus, globalorderitemtag As String
    Public globallineupnos, globalbranchname, globalbranchaddress, globalvendorname, globalorderclassdescription, globalorderpono, globalordersidrno, globalordercanceldate As String

    Public MainServiceProvider As ServiceProvider
    Public Const CONFIG_FILE_PATH As String = "C:\ConnectionString\config.ini"

#Region "Module Functions"

    Public Sub dbconn()
        Static once As SByte = 0
        If once = 0 Then
            once = 1
            Static write As SByte = 0
            Try
                globalconn = New MySqlConnection
                If File.Exists("C:\ConnectionString\ConnectionStringDreamheartsdb.txt") Then
                    globalconn.ConnectionString = System.IO.File.ReadAllText("C:\ConnectionString\ConnectionStringDreamheartsdb.txt")
                    If write <> 1 Then
                        write = 1
                        Dim objReader As New System.IO.StreamReader("C:\ConnectionString\ConnectionStringDreamheartsdb.txt")
                        Dim _conStr As String
                        Dim fg As Object
                        If objReader.Peek() <> -1 Then
                            _conStr = objReader.ReadLine
                            sys_servername = getStrBetween(_conStr, "", ";")
                            fg = sys_servername
                            sys_userid = _conStr.Substring(sys_servername.Length, _conStr.Length - sys_servername.Length)
                            sys_servername = getStrBetween(_conStr, "=", ";")
                            sys_userid = getStrBetween(sys_userid, "=", ";")
                            fg = fg & ";"
                            sys_password = _conStr.Substring(fg.Length, _conStr.Length - fg.Length)
                            fg = getStrBetween(sys_password, "", ";")
                            fg = sys_password.Substring(fg.Length, sys_password.Length - fg.Length)
                            sys_password = getStrBetween(fg, "=", ";")
                            _conStr = StrReverse(_conStr)
                            sys_db = StrReverse(getStrBetween(_conStr, ";", "="))
                        End If
                        objReader.Close()
                        objReader.Dispose()
                    End If
                Else
                    File.AppendAllText("C:\ConnectionString\ConnectionStringDreamheartsdb.txt",
                                       "server=" & sys_servername &
                                       ";user id=" & sys_userid &
                                       ";password=" & sys_password &
                                       ";database=" & sys_db & ";")
                    globalconn.ConnectionString = "server=" & sys_servername &
                                            ";user id=" & sys_userid &
                                            ";password=" & sys_password &
                                            ";database=" & sys_db & ";"
                End If
            Catch ex As Exception
                MsgBox(ex.Message & " ERR_NO 77-10 : dbconn", , "Server Connection")
            End Try
        End If
    End Sub

    Function getStrBetween(ByVal myStr As String, ByVal startIndx As Char, ByVal lastIndx As Char) As String
        Dim _mystr As String = myStr
        _mystr = _mystr.Substring(_mystr.IndexOf(startIndx) + 1)
        _mystr = _mystr.Substring(0, _mystr.IndexOf(lastIndx))
        Return _mystr
    End Function

    Public Function getErrExcptn(ByVal ex As Exception, Optional FormNam As String = Nothing) As String
        Dim st As StackTrace = New StackTrace(ex, True)
        Dim sf As StackFrame = st.GetFrame(st.FrameCount - 1)
        Dim op_FrmNam As String = If(FormNam = Nothing, "", FormNam & ".")
        Dim globagsystemversionnum As String = AboutForm.SystemVerNo.Text
        Dim mystr As String = ex.Message & vbNewLine & vbNewLine &
                        "(System Version: " & globagsystemversionnum & ") An ERROR occured in  " & op_FrmNam &
                        st.GetFrame(st.FrameCount - 1).GetMethod.Name &
                        " " & sf.GetFileLineNumber()
        systemerrorfound = True
        Return mystr
    End Function

    Sub TabControlColor(ByVal TabCntrl As TabControl,
                        ByVal ee As System.Windows.Forms.DrawItemEventArgs,
                        Optional formColor As Color = Nothing)
        Dim g As Graphics = ee.Graphics
        Dim tp As TabPage = TabCntrl.TabPages(ee.Index)
        Dim br As Brush
        Dim sf As New StringFormat
        Dim r As New RectangleF(ee.Bounds.X, ee.Bounds.Y + 7, ee.Bounds.Width, ee.Bounds.Height - 7) '
        If formColor <> Nothing Then
            If TabCntrl.Alignment = TabAlignment.Top Then
                Dim _myPen As New Pen(formColor, 7)
                Dim myTabRect As Rectangle = New Rectangle(0, 0, TabCntrl.Width - ((TabCntrl.Width * 0.01)), TabCntrl.Height - 3)
                ee.Graphics.DrawRectangle(_myPen, myTabRect)
                Dim custBr = New SolidBrush(formColor)
                Dim x = 0
                For i = 0 To TabCntrl.TabCount - 1
                    x += ee.Bounds.Width
                Next
                Dim myCustRect = New Rectangle(x - (x * 0.08), 0, TabCntrl.Width - ((TabCntrl.Width * 0.02) - 2), ee.Bounds.Height)
                ee.Graphics.FillRectangle(custBr, myCustRect)
            ElseIf TabCntrl.Alignment = TabAlignment.Bottom Then
            End If
        End If
        Dim TabTextBrush As Brush = New SolidBrush(Color.Black)
        Dim TabBackBrush As Brush = New SolidBrush(Color.FromArgb(253, 209, 128))
        sf.Alignment = StringAlignment.Center
        Dim strTitle As String = tp.Text & "   "
        If TabCntrl.SelectedIndex = ee.Index Then
            br = TabBackBrush
            g.FillRectangle(br, ee.Bounds)
            br = TabTextBrush
            Dim ff As Font
            ff = New Font(TabCntrl.Font, FontStyle.Bold)
            g.DrawString(strTitle, ff, br, r, sf)
        Else
            br = New SolidBrush(Color.WhiteSmoke)
            g.FillRectangle(br, ee.Bounds)
            br = New SolidBrush(Color.Black)
            Dim ff As Font
            ff = New Font(TabCntrl.Font, FontStyle.Regular)
            g.DrawString(strTitle, TabCntrl.Font, br, r, sf)
        End If
    End Sub

    Public Sub myBalloon(Optional ToolTipStringContent As String = Nothing, Optional ToolTipStringTitle As String = Nothing, Optional objct As System.Windows.Forms.IWin32Window = Nothing, Optional x As Integer = 0, Optional y As Integer = 0, Optional dispo As SByte = 0, Optional duration As Integer = 3000)
        Try
            If dispo = 1 Then
                hintInfo = New ToolTip
                hintInfo.IsBalloon = True
                hintInfo.ToolTipTitle = ToolTipStringTitle
                hintInfo.ToolTipIcon = ToolTipIcon.Info
                hintInfo.Show(ToolTipStringContent, objct, x - 2, y - 2, 1)
                hintInfo.Hide(objct)
                hintInfo.Dispose()
            Else
                hintInfo = New ToolTip
                hintInfo.IsBalloon = True
                hintInfo.ToolTipTitle = ToolTipStringTitle
                hintInfo.ToolTipIcon = ToolTipIcon.Info
                hintInfo.Show(ToolTipStringContent, objct, x - 2, y - 2, duration)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " ERR_NO 88-14 : Warn Ballon", , "Balloon Message")
        End Try
    End Sub

    Sub GridDrawCustomHeaderColumns(ByVal dgv As DataGridView,
     ByVal e As DataGridViewCellPaintingEventArgs, ByVal img As Image,
     ByVal Style As DGVHeaderImageAlignments)
        Dim gr As Graphics = e.Graphics
        Dim rowHeadrPaint As Graphics = e.Graphics
        gr.FillRectangle(
         New SolidBrush(dgv.ColumnHeadersDefaultCellStyle.BackColor),
         e.CellBounds)
        If img IsNot Nothing Then
            Select Case Style
                Case DGVHeaderImageAlignments.FillCell
                    gr.DrawImage(
                     img, e.CellBounds.X, e.CellBounds.Y,
                     e.CellBounds.Width, e.CellBounds.Height)
                Case DGVHeaderImageAlignments.SingleCentered
                    gr.DrawImage(img,
                     ((e.CellBounds.Width - img.Width) \ 2) + e.CellBounds.X,
                     ((e.CellBounds.Height - img.Height) \ 2) + e.CellBounds.Y,
                     img.Width, img.Height)
                Case DGVHeaderImageAlignments.SingleLeft
                    gr.DrawImage(img, e.CellBounds.X,
                     ((e.CellBounds.Height - img.Height) \ 2) + e.CellBounds.Y,
                     img.Width, img.Height)
                Case DGVHeaderImageAlignments.SingleRight
                    gr.DrawImage(img,
                     (e.CellBounds.Width - img.Width) + e.CellBounds.X,
                     ((e.CellBounds.Height - img.Height) \ 2) + e.CellBounds.Y,
                     img.Width, img.Height)
                Case DGVHeaderImageAlignments.Tile

                    Dim br As New TextureBrush(img, Drawing2D.WrapMode.Tile)
                    gr.FillRectangle(br, e.ClipBounds)
                Case Else
                    gr.DrawImage(
                     img, e.CellBounds.X, e.CellBounds.Y,
                     e.ClipBounds.Width, e.CellBounds.Height)
            End Select
        End If
        If e.Value Is Nothing Then
            e.Handled = True
            Return
        End If
        Using sf As New StringFormat
            With sf
                Select Case dgv.ColumnHeadersDefaultCellStyle.Alignment
                    Case DataGridViewContentAlignment.BottomCenter
                        .Alignment = StringAlignment.Center
                        .LineAlignment = StringAlignment.Far
                    Case DataGridViewContentAlignment.BottomLeft
                        .Alignment = StringAlignment.Near
                        .LineAlignment = StringAlignment.Far
                    Case DataGridViewContentAlignment.BottomRight
                        .Alignment = StringAlignment.Far
                        .LineAlignment = StringAlignment.Far
                    Case DataGridViewContentAlignment.MiddleCenter
                        .Alignment = StringAlignment.Center
                        .LineAlignment = StringAlignment.Center
                    Case DataGridViewContentAlignment.MiddleLeft
                        .Alignment = StringAlignment.Near
                        .LineAlignment = StringAlignment.Center
                    Case DataGridViewContentAlignment.MiddleRight
                        .Alignment = StringAlignment.Far
                        .LineAlignment = StringAlignment.Center
                    Case DataGridViewContentAlignment.TopCenter
                        .Alignment = StringAlignment.Center
                        .LineAlignment = StringAlignment.Near
                    Case DataGridViewContentAlignment.TopLeft
                        .Alignment = StringAlignment.Near
                        .LineAlignment = StringAlignment.Near
                    Case DataGridViewContentAlignment.TopRight
                        .Alignment = StringAlignment.Far
                        .LineAlignment = StringAlignment.Near
                End Select
                .HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None
                .Trimming = StringTrimming.None
            End With
            Dim newFont = New System.Drawing.Font("Segoe UI", 8.75!, FontStyle.Regular)
            Dim newForeColor = Color.FromArgb(0, 0, 0)
            With dgv.ColumnHeadersDefaultCellStyle
                gr.DrawString(e.Value.ToString, newFont,
                 New SolidBrush(newForeColor), e.CellBounds, sf)
            End With
        End Using
        e.Handled = True
    End Sub

    Public Enum DGVHeaderImageAlignments As Int32
        [Default] = 0
        FillCell = 1
        SingleCentered = 2
        SingleLeft = 3
        SingleRight = 4
        Stretch = [Default]
        Tile = 5
    End Enum

#End Region

#Region "Global Functions"

#Region "AUTO-COMPLETE"

    Sub globalautocompleteAccountName(ByVal globalicombobox As ComboBox, ByVal globaliaccounttype As String, ByVal globalicondition As String, ByVal globalformname As Object)
        Try
            Dim accountname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'') AS 'accountname' FROM accounts a WHERE a.organizationid = " & Z_OrganizationID & " AND a.accounttype = '" & globaliaccounttype & "' " & globalicondition & " GROUP BY a.accountno ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                accountname.Add(ds.Tables(0).Rows(i)("accountname").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = accountname
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteContactName(ByVal globalicombobox As ComboBox, ByVal globalicontacttype As String, ByVal globalformname As Object)
        Try
            Dim contactname As New AutoCompleteStringCollection
            Dim cmd1 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'') AS 'firstname' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.status = 'Active' AND c.`type` = '" & globalicontacttype & "' GROUP BY c.rowid ", globalconn)
            Dim cmd2 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(c.lastname,''),', ',COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'') AS 'lastname' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.status = 'Active' AND c.`type` = '" & globalicontacttype & "' GROUP BY c.rowid ", globalconn)
            Dim da1 As New MySqlDataAdapter(cmd1)
            Dim da2 As New MySqlDataAdapter(cmd2)
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet
            da1.Fill(ds1, "list1")
            da2.Fill(ds2, "list2")
            Dim i As Integer
            For i = 0 To ds1.Tables(0).Rows.Count - 1
                contactname.Add(ds1.Tables(0).Rows(i)("firstname").ToString())
            Next
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                contactname.Add(ds2.Tables(0).Rows(i)("lastname").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = contactname
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteByCombination(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim combination As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(p.productcode,''),' / ',COALESCE(c.colorname,''),' / ',COALESCE(pcs.size,''),' / ',COALESCE(pcs.seasoncode,'')),'') AS 'combination' " &
                                "FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN colors c ON pc.colorid = c.rowid " &
                                "WHERE pcs.organizationid = " & Z_OrganizationID & " AND pcs.status = 'Active' ORDER BY p.productcode,c.colorname ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                combination.Add(ds.Tables(0).Rows(i)("combination").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = combination
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteByProductCode(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim productcode As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(p.productcode,'') AS 'productcode' FROM products p WHERE p.organizationid = " & Z_OrganizationID & " GROUP BY p.productcode ORDER BY p.productcode ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                productcode.Add(ds.Tables(0).Rows(i)("productcode").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = productcode
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteBySKU(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim mergesku As New AutoCompleteStringCollection
            Dim cmd1 As New MySqlCommand("SELECT COALESCE(pcs.sku,'') AS 'pcssku' FROM productcolorsizes pcs WHERE pcs.organizationid = " & Z_OrganizationID & " AND pcs.status = 'Active' AND pcs.sku != '' GROUP BY pcs.sku ", globalconn)
            Dim cmd2 As New MySqlCommand("SELECT COALESCE(bu.sku,'') AS 'busku' FROM productbundles bu WHERE bu.organizationid = " & Z_OrganizationID & " AND bu.status = 'Active' AND bu.sku != '' GROUP BY bu.sku ", globalconn)
            Dim da1 As New MySqlDataAdapter(cmd1)
            Dim da2 As New MySqlDataAdapter(cmd2)
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet
            da1.Fill(ds1, "list1")
            da2.Fill(ds2, "list2")
            Dim i As Integer
            For i = 0 To ds1.Tables(0).Rows.Count - 1
                mergesku.Add(ds1.Tables(0).Rows(i)("pcssku").ToString())
            Next
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                mergesku.Add(ds2.Tables(0).Rows(i)("busku").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = mergesku
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteByBundleName(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim bundlename As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(bu.bundlename,'') AS 'bundlename' FROM productbundles bu WHERE bu.organizationid = " & Z_OrganizationID & " AND bu.status = 'Active' GROUP BY bu.bundlename ORDER BY bu.bundlename ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                bundlename.Add(ds.Tables(0).Rows(i)("bundlename").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = bundlename
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteLocationName(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim locationname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(il.name,'') AS 'locationname' FROM inventorylocations il WHERE il.organizationid = " & Z_OrganizationID & " AND il.status = 'Active' ORDER BY il.name ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                locationname.Add(ds.Tables(0).Rows(i)("locationname").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = locationname
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteOrderInfoA(ByVal globalicombobox As ComboBox, ByVal globaliordertype As String, ByVal globaliorderstatus As String, ByVal globalformname As Object)
        Try
            Dim orderinfo As New AutoCompleteStringCollection
            Dim cmd1 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,''),' / ',CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.)')),'') AS 'companyname' FROM orders o LEFT JOIN accounts a ON o.accountid = a.rowid WHERE o.organizationid = " & Z_OrganizationID & " AND o.`status` = '" & globaliorderstatus & "' AND o.ordertype = '" & globaliordertype & "' GROUP BY o.rowid ", globalconn)
            Dim cmd2 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ',COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'') AS 'ordernumber' FROM orders o LEFT JOIN accounts a ON o.accountid = a.rowid WHERE o.organizationid = " & Z_OrganizationID & " AND o.`status` = '" & globaliorderstatus & "' AND o.ordertype = '" & globaliordertype & "' GROUP BY o.rowid ", globalconn)
            Dim da1 As New MySqlDataAdapter(cmd1)
            Dim da2 As New MySqlDataAdapter(cmd2)
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet
            da1.Fill(ds1, "list1")
            da2.Fill(ds2, "list2")
            Dim i As Integer
            For i = 0 To ds1.Tables(0).Rows.Count - 1
                orderinfo.Add(ds1.Tables(0).Rows(i)("companyname").ToString())
            Next
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                orderinfo.Add(ds2.Tables(0).Rows(i)("ordernumber").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = orderinfo
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteOrderInfoB(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim orderinfo As New AutoCompleteStringCollection
            Dim cmd1 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(a.companyname,''),' - ', COALESCE(a.accountno,''),' / ',COALESCE(o.ordernumber,''),' (C.O. No.) / ',CONCAT(COALESCE(pl.packinglistno,''),' (Pa.L. No.)')),'') AS 'companyname' FROM packinglist pl LEFT JOIN orders o ON pl.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid LEFT JOIN packinglistcartons plc ON pl.rowid = plc.packinglistid WHERE pl.organizationid = " & Z_OrganizationID & " AND plc.`status` = 'Active' GROUP BY o.rowid ", globalconn)
            Dim cmd2 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ', COALESCE(a.companyname,''),' - ', COALESCE(a.accountno,''),' / ',CONCAT(COALESCE(pl.packinglistno,''),' (Pa.L. No.)')),'') AS 'ordernumber' FROM packinglist pl LEFT JOIN orders o ON pl.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid LEFT JOIN packinglistcartons plc ON pl.rowid = plc.packinglistid WHERE pl.organizationid = " & Z_OrganizationID & " AND plc.`status` = 'Active' GROUP BY o.rowid ", globalconn)
            Dim da1 As New MySqlDataAdapter(cmd1)
            Dim da2 As New MySqlDataAdapter(cmd2)
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet
            da1.Fill(ds1, "list1")
            da2.Fill(ds2, "list2")
            Dim i As Integer
            For i = 0 To ds1.Tables(0).Rows.Count - 1
                orderinfo.Add(ds1.Tables(0).Rows(i)("companyname").ToString())
            Next
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                orderinfo.Add(ds2.Tables(0).Rows(i)("ordernumber").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = orderinfo
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteTruckInfo(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim truckinfo As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(dt.truckname,''),' - ',COALESCE(dt.plateno,''),' - ',COALESCE(dt.truckno,'')),'') AS 'truckinfo' FROM deliverytrucks dt WHERE dt.organizationid = " & Z_OrganizationID & " AND dt.`status` = 'Active' GROUP BY dt.rowid ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                truckinfo.Add(ds.Tables(0).Rows(i)("truckinfo").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = truckinfo
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteShiftInfo(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim shiftinfo As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(s.shiftname,''),' - From: ',COALESCE(TIME_FORMAT(s.timefrom,'%r'),''),'  To: ',COALESCE(TIME_FORMAT(s.timeto,'%r'),'')),'') AS 'shiftinfo' FROM shifts s WHERE s.organizationid = " & Z_OrganizationID & " AND s.`status` = 'Active' GROUP BY s.rowid ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                shiftinfo.Add(ds.Tables(0).Rows(i)("shiftinfo").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = shiftinfo
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteTruckShiftInfo(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim truckshiftinfo As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(dt.truckname,''),' - ',COALESCE(dt.truckno,''),' / ',COALESCE(s.shiftname,'')),'') AS 'truckshiftinfo' FROM deliverytruckshifts dts " &
                            "LEFT JOIN deliverytrucks dt ON dts.deliverytruckid = dt.rowid LEFT JOIN shifts s ON dts.shiftid = s.rowid WHERE dts.organizationid = " & Z_OrganizationID & " AND dts.`status` = 'Active' GROUP BY dts.rowid ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                truckshiftinfo.Add(ds.Tables(0).Rows(i)("truckshiftinfo").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = truckshiftinfo
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteCartonNos(ByVal globalicombobox As ComboBox, ByVal globalipackinglistid As Integer, ByVal globalformname As Object)
        Try
            Dim cartonnos As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(pc.cartonno,'') AS 'cartonnos' FROM packinglistcartons pc WHERE pc.organizationid = " & Z_OrganizationID & " AND pc.packinglistid = " & globalipackinglistid & " AND pc.`status` = 'Active' GROUP BY pc.rowid ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                cartonnos.Add(ds.Tables(0).Rows(i)("cartonnos").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = cartonnos
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteBranchCodeName(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim branchcodename As New AutoCompleteStringCollection
            Dim cmd1 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),'') AS 'branchcode' FROM branches bc WHERE bc.organizationid = " & Z_OrganizationID & " AND bc.status = 'Active' GROUP BY bc.rowid ", globalconn)
            Dim cmd2 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(bc.branchname,''),' - ',COALESCE(bc.branchcode,'')),'') AS 'branchname' FROM branches bc WHERE bc.organizationid = " & Z_OrganizationID & " AND bc.status = 'Active' GROUP BY bc.rowid ", globalconn)
            Dim da1 As New MySqlDataAdapter(cmd1)
            Dim da2 As New MySqlDataAdapter(cmd2)
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet
            da1.Fill(ds1, "list1")
            da2.Fill(ds2, "list2")
            Dim i As Integer
            For i = 0 To ds1.Tables(0).Rows.Count - 1
                branchcodename.Add(ds1.Tables(0).Rows(i)("branchcode").ToString())
            Next
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                branchcodename.Add(ds2.Tables(0).Rows(i)("branchname").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = branchcodename
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteVendorCodeName(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim vendorcodename As New AutoCompleteStringCollection
            Dim cmd1 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(ve.companyname,''),' - ',COALESCE(ve.companycode,'')),'') AS 'vendorname' FROM companies ve WHERE ve.organizationid = " & Z_OrganizationID & " AND ve.status = 'Active' GROUP BY ve.rowid ", globalconn)
            Dim cmd2 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(ve.companycode,''),' - ',COALESCE(ve.companyname,'')),'') AS 'vendorcode' FROM companies ve WHERE ve.organizationid = " & Z_OrganizationID & " AND ve.status = 'Active' GROUP BY ve.rowid ", globalconn)
            Dim da1 As New MySqlDataAdapter(cmd1)
            Dim da2 As New MySqlDataAdapter(cmd2)
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet
            da1.Fill(ds1, "list1")
            da2.Fill(ds2, "list2")
            Dim i As Integer
            For i = 0 To ds1.Tables(0).Rows.Count - 1
                vendorcodename.Add(ds1.Tables(0).Rows(i)("vendorname").ToString())
            Next
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                vendorcodename.Add(ds2.Tables(0).Rows(i)("vendorcode").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = vendorcodename
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteClassDescription(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim classdescription As New AutoCompleteStringCollection
            Dim cmd1 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(cc.codename,''),' / ',COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),'') AS 'codename' FROM combinecodings cc LEFT JOIN codings c1 ON cc.codingida = c1.rowid " &
                            "LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid WHERE cc.organizationid = " & Z_OrganizationID & " AND cc.status = 'Active' GROUP BY cc.rowid ", globalconn)
            Dim cmd2 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,''),' / ',COALESCE(cc.codename,'')),'') AS 'codings' FROM combinecodings cc LEFT JOIN codings c1 ON cc.codingida = c1.rowid " &
                            "LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid WHERE cc.organizationid = " & Z_OrganizationID & " AND cc.status = 'Active' GROUP BY cc.rowid ", globalconn)
            Dim da1 As New MySqlDataAdapter(cmd1)
            Dim da2 As New MySqlDataAdapter(cmd2)
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet
            da1.Fill(ds1, "list1")
            da2.Fill(ds2, "list2")
            Dim i As Integer
            For i = 0 To ds1.Tables(0).Rows.Count - 1
                classdescription.Add(ds1.Tables(0).Rows(i)("codename").ToString())
            Next
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                classdescription.Add(ds2.Tables(0).Rows(i)("codings").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = classdescription
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteCodings(ByVal globalicombobox As ComboBox, ByVal globalicondition As String, ByVal globalformname As Object)
        Try
            Dim codings As New AutoCompleteStringCollection
            Dim cmd1 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(co.codetype,''),' / ',COALESCE(co.codeno,''),' - ',COALESCE(co.codename,'')),'') AS 'codetype' FROM codings co WHERE co.organizationid = " & Z_OrganizationID & " AND co.status = 'Active' " & globalicondition & " GROUP BY co.rowid ", globalconn)
            Dim cmd2 As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(co.codeno,''),' - ',COALESCE(co.codename,''),' / ',COALESCE(co.codetype,'')),'') AS 'codeno' FROM codings co WHERE co.organizationid = " & Z_OrganizationID & " AND co.status = 'Active' " & globalicondition & " GROUP BY co.rowid ", globalconn)
            Dim da1 As New MySqlDataAdapter(cmd1)
            Dim da2 As New MySqlDataAdapter(cmd2)
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet
            da1.Fill(ds1, "list1")
            da2.Fill(ds2, "list2")
            Dim i As Integer
            For i = 0 To ds1.Tables(0).Rows.Count - 1
                codings.Add(ds1.Tables(0).Rows(i)("codetype").ToString())
            Next
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                codings.Add(ds2.Tables(0).Rows(i)("codeno").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = codings
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteListOfValues(ByVal globalicombobox As ComboBox, ByVal globalitype As String, ByVal globalformname As Object)
        Try
            Dim displayvalue As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT lic AS 'displayvalue' FROM listofvalues WHERE `type` = '" & globalitype & "' AND `status` = 'Active' GROUP BY lic ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                displayvalue.Add(ds.Tables(0).Rows(i)("displayvalue").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = displayvalue
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteSizeInfo(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            Dim sizeinfo As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(CONCAT(COALESCE(cs.sizename,''),' - ', COALESCE(cs.`length`,''),' ', COALESCE(cs.lengthuom,''),'/', COALESCE(cs.`width`,''),' ', COALESCE(cs.widthuom,''),'/', COALESCE(cs.`height`,''),' ', COALESCE(cs.heightuom,''),' - l/w/h'),'') AS 'sizeinfo' FROM cartonsizes cs WHERE cs.organizationid = " & Z_OrganizationID & " AND cs.`status` = 'Active' ORDER BY cs.sizename ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                sizeinfo.Add(ds.Tables(0).Rows(i)("sizeinfo").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = sizeinfo
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteBrandName(ByVal globalicombobox As ComboBox, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            Dim brandname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(b.brandname,'') AS 'brandname' FROM brands b WHERE b.organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " GROUP BY b.brandname ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                brandname.Add(ds.Tables(0).Rows(i)("brandname").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = brandname
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautocompleteCategory(ByVal globalicombobox As ComboBox, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            Dim categoryname As New AutoCompleteStringCollection
            Dim cmd As New MySqlCommand("SELECT COALESCE(c.categoryname,'') AS 'categoryname' FROM categories c WHERE c.organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " GROUP BY c.categoryname ", globalconn)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(ds, "list")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                categoryname.Add(ds.Tables(0).Rows(i)("categoryname").ToString())
            Next
            globalicombobox.AutoCompleteSource = AutoCompleteSource.CustomSource
            globalicombobox.AutoCompleteCustomSource = categoryname
            globalicombobox.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

#End Region

#Region "AUTO-POPULATE"

    Sub globalautopopulateAccountName(ByVal globalicombobox As ComboBox, ByVal globaliaccounttype As String, ByVal globalicondition As String, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'') AS 'accountname' FROM accounts a WHERE a.organizationid = " & Z_OrganizationID & " AND a.accounttype = '" & globaliaccounttype & "' " & globalicondition & " GROUP BY a.accountno ORDER BY a.companyname "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateContactName(ByVal globalicombobox As ComboBox, ByVal globalicontacttype As String, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),'') AS 'firstname' FROM contacts c WHERE c.organizationid = " & Z_OrganizationID & " AND c.status = 'Active' AND c.`type` = '" & globalicontacttype & "' GROUP BY c.rowid ORDER BY c.firstname "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateByCombination(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(p.productcode,''),' / ',COALESCE(c.colorname,''),' / ',COALESCE(pcs.size,''),' / ',COALESCE(pcs.seasoncode,'')),'') AS 'combination' " &
                            "FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN colors c ON pc.colorid = c.rowid " &
                            "WHERE pcs.organizationid = " & Z_OrganizationID & " AND pcs.status = 'Active' ORDER BY p.productcode,c.colorname "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateByProductCode(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(p.productcode,'') AS 'productcode' FROM products p WHERE p.organizationid = " & Z_OrganizationID & " GROUP BY p.productcode ORDER BY p.productcode "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateBySKU(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(pcs.sku,'') AS 'sku' FROM productcolorsizes pcs WHERE pcs.organizationid = " & Z_OrganizationID & " AND pcs.status = 'Active' AND pcs.sku != '' GROUP BY pcs.sku ORDER BY pcs.sku "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateByBundleName(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(bu.bundlename,'') AS 'bundlename' FROM productbundles bu WHERE bu.organizationid = " & Z_OrganizationID & " AND bu.status = 'Active' GROUP BY bu.bundlename ORDER BY bu.bundlename "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateLocationName(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(il.name,'') AS 'locationname' FROM inventorylocations il WHERE il.organizationid = " & Z_OrganizationID & " AND il.status = 'Active' ORDER BY il.name "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateOrderInfoA(ByVal globalicombobox As ComboBox, ByVal globaliordertype As String, ByVal globaliorderstatus As String, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ',COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'') AS 'ordernumber' FROM orders o LEFT JOIN accounts a ON o.accountid = a.rowid WHERE o.organizationid = " & Z_OrganizationID & " AND o.status = '" & globaliorderstatus & "' AND o.ordertype = '" & globaliordertype & "' GROUP BY o.rowid ORDER BY o.ordernumber "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateOrderInfoB(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ', COALESCE(a.companyname,''),' - ', COALESCE(a.accountno,''),' / ',CONCAT(COALESCE(pl.packinglistno,''),' (Pa.L. No.)')),'') AS 'ordernumber' FROM packinglist pl LEFT JOIN orders o ON pl.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid LEFT JOIN packinglistcartons plc ON pl.rowid = plc.packinglistid WHERE pl.organizationid = " & Z_OrganizationID & " AND plc.`status` = 'Active' GROUP BY o.rowid ORDER BY o.ordernumber "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateTruckInfo(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(dt.truckname,''),' - ',COALESCE(dt.plateno,''),' - ',COALESCE(dt.truckno,'')),'') AS 'truckinfo' FROM deliverytrucks dt WHERE dt.organizationid = " & Z_OrganizationID & " AND dt.`status` = 'Active' GROUP BY dt.rowid ORDER BY dt.truckname "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateShiftInfo(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(s.shiftname,''),' - From: ',COALESCE(TIME_FORMAT(s.timefrom,'%r'),''),'  To: ',COALESCE(TIME_FORMAT(s.timeto,'%r'),'')),'') AS 'shiftinfo' FROM shifts s WHERE s.organizationid = " & Z_OrganizationID & " AND s.`status` = 'Active' GROUP BY s.rowid ORDER BY s.shiftname DESC "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateTruckShiftInfo(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(dt.truckname,''),' - ',COALESCE(dt.truckno,''),' / ',COALESCE(s.shiftname,'')),'') AS 'truckshiftinfo' FROM deliverytruckshifts dts " &
                    "LEFT JOIN deliverytrucks dt ON dts.deliverytruckid = dt.rowid LEFT JOIN shifts s ON dts.shiftid = s.rowid WHERE dts.organizationid = " & Z_OrganizationID & " AND dts.`status` = 'Active' GROUP BY dts.rowid ORDER BY dt.truckname,s.shiftname DESC "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateCartonNos(ByVal globalicombobox As ComboBox, ByVal globalipackinglistid As Integer, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(pc.cartonno,'') AS 'cartonnos' FROM packinglistcartons pc WHERE pc.organizationid = " & Z_OrganizationID & " AND pc.packinglistid = " & globalipackinglistid & " AND pc.`status` = 'Active' GROUP BY pc.rowid ORDER BY pc.cartonno "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateBranchCodeName(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),'') AS 'branchcode' FROM branches bc WHERE bc.organizationid = " & Z_OrganizationID & " AND bc.status = 'Active' GROUP BY bc.rowid ORDER BY bc.branchname ASC"
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateVendorCodeName(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(ve.companyname,''),' - ',COALESCE(ve.companycode,'')),'') AS 'vendorname' FROM companies ve WHERE ve.organizationid = " & Z_OrganizationID & " AND ve.status = 'Active' GROUP BY ve.rowid ORDER BY ve.companyname "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateClassDescription(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(cc.codename,''),' / ',COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),'') AS 'codename' FROM combinecodings cc LEFT JOIN codings c1 ON cc.codingida = c1.rowid " &
                            "LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid WHERE cc.organizationid = " & Z_OrganizationID & " AND cc.status = 'Active' GROUP BY cc.rowid ORDER BY cc.codename "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateCodings(ByVal globalicombobox As ComboBox, ByVal globalicondition As String, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(co.codeno,''),' - ',COALESCE(co.codename,''),' / ',COALESCE(co.codetype,'')),'') AS 'codeno' FROM codings co WHERE co.organizationid = " & Z_OrganizationID & " AND co.status = 'Active' " & globalicondition & " GROUP BY co.rowid ORDER BY co.codeno "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateListOfValues(ByVal globalicombobox As ComboBox, ByVal globalitype As String, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT lic AS 'displayvalue' FROM listofvalues WHERE `type` = '" & globalitype & "' AND `status` = 'Active' GROUP BY lic ORDER BY lic "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateSizeInfo(ByVal globalicombobox As ComboBox, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(CONCAT(COALESCE(cs.sizename,''),' - ', COALESCE(cs.`length`,''),' ', COALESCE(cs.lengthuom,''),'/', COALESCE(cs.`width`,''),' ', COALESCE(cs.widthuom,''),'/', COALESCE(cs.`height`,''),' ', COALESCE(cs.heightuom,''),' - l/w/h'),'') AS 'sizeinfo' FROM cartonsizes cs WHERE cs.organizationid = " & Z_OrganizationID & " AND cs.`status` = 'Active' ORDER BY cs.sizename "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateBrandName(ByVal globalicombobox As ComboBox, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(b.brandname,'') AS 'brandname' FROM brands b WHERE b.organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " GROUP BY b.brandname ORDER BY b.brandname "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub globalautopopulateCategory(ByVal globalicombobox As ComboBox, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalicombobox.Items.Clear()
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(c.categoryname,'') AS 'categoryname' FROM categories c WHERE c.organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " GROUP BY c.categoryname ORDER BY c.categoryname "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                globalicombobox.Items.Add(reader1(0).ToString())
            End While
            globalicombobox.Items.Add("")
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

#End Region

#Region "SELECT"

    Sub getInventorylocationIDA(ByVal globaliinventorylocationname As String, ByVal globalformname As Object)
        Try
            globalinventorylocationid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM inventorylocations WHERE name = """ & globaliinventorylocationname & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalinventorylocationid = dtGid.Rows(0)(0)
            Else
                globalinventorylocationid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getInventorylocationIDB(ByVal globaliinventorylocationid As Integer, ByVal globaliinventorylocationname As String, ByVal globalformname As Object)
        Try
            globalinventorylocationid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM inventorylocations WHERE rowid != " & globaliinventorylocationid & " AND name = """ & globaliinventorylocationname & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalinventorylocationid = dtGid.Rows(0)(0)
            Else
                globalinventorylocationid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getInventorylocationIDC(ByVal globalformname As Object)
        Try
            globalinventorylocationid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM inventorylocations WHERE organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalinventorylocationid = dtGid.Rows(0)(0)
            Else
                globalinventorylocationid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getAddressName(ByVal globaliaddressid As Integer, ByVal globalformname As Object)
        Try
            globaladdressname = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtAdn As New DataTable
            dtAdn = getDataTableForSQL("SELECT CONCAT(COALESCE(ad.streetaddress1,''),' ',COALESCE(ad.streetaddress2,''),' ',COALESCE(ad.barangay,''),' ',COALESCE(ad.citytown,''),' ',COALESCE(ad.province,''),' ',COALESCE(ad.state,''),' ',COALESCE(ad.zipcode,''),' ',COALESCE(ad.country,'')) FROM address ad WHERE ad.rowid = " & globaliaddressid & " ")
            If dtAdn.Rows.Count <> 0 Then
                globaladdressname = dtAdn.Rows(0)(0)
            Else
                globaladdressname = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getContactNameA(ByVal globalicontactid As Integer, ByVal globalformname As Object)
        Try
            globalcontactname = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtCtn As New DataTable
            dtCtn = getDataTableForSQL("SELECT CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,'')) FROM contacts c WHERE c.rowid = " & globalicontactid & " ")
            If dtCtn.Rows.Count <> 0 Then
                globalcontactname = dtCtn.Rows(0)(0)
            Else
                globalcontactname = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getContactNameB(ByVal globalicontactid As Integer, ByVal globalformname As Object)
        Try
            globalcontactname = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtCtn As New DataTable
            dtCtn = getDataTableForSQL("SELECT CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')) FROM contacts c WHERE c.rowid = " & globalicontactid & " ")
            If dtCtn.Rows.Count <> 0 Then
                globalcontactname = dtCtn.Rows(0)(0)
            Else
                globalcontactname = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getRackShelfColumnID(ByVal globalirackshelfcolumnname As String, ByVal globaliinventorylocationid As Integer, ByVal globalformname As Object)
        Try
            globalrackshelfcolumnid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rsc.rowid,0) FROM rackshelfcolumn rsc WHERE CONCAT(COALESCE(rsc.rackno,''),'',COALESCE(rsc.shelfno,''),'',COALESCE(rsc.columnno,'')) = """ & globalirackshelfcolumnname & """ AND rsc.organizationid = " & Z_OrganizationID & " AND rsc.inventorylocationid = " & globaliinventorylocationid & " ")
            If dtGid.Rows.Count <> 0 Then
                globalrackshelfcolumnid = dtGid.Rows(0)(0)
            Else
                globalrackshelfcolumnid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getTotalQtyAvailableA(ByVal globaliproductcolorsizeid As Integer, ByVal globalformname As Object)
        Try
            globaltotalqtyavailable = 0
            Dim dtTq As New DataTable
            dtTq = getDataTableForSQL("SELECT COALESCE(SUM(pil.totalavailableqty),0) FROM productinventorylocation pil " &
                            "WHERE pil.organizationid = " & Z_OrganizationID & " AND pil.productcolorsizeid = " & globaliproductcolorsizeid & " ")
            If dtTq.Rows.Count <> 0 Then
                globaltotalqtyavailable = dtTq.Rows(0)(0)
            Else
                globaltotalqtyavailable = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getTotalQtyAvailableB(ByVal globaliproductcolorsizeid As Integer, ByVal globaliinventorylocationid As Integer, ByVal globalformname As Object)
        Try
            globaltotalqtyavailable = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtTq As New DataTable
            dtTq = getDataTableForSQL("SELECT COALESCE(SUM(pil.totalavailableqty),0) FROM productinventorylocation pil LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " &
                            "WHERE pil.organizationid = " & Z_OrganizationID & " AND pil.productcolorsizeid = " & globaliproductcolorsizeid & " AND rsc.inventorylocationid = " & globaliinventorylocationid & " ")
            If dtTq.Rows.Count <> 0 Then
                globaltotalqtyavailable = dtTq.Rows(0)(0)
            Else
                globaltotalqtyavailable = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getTotalQtyAvailableC(ByVal globaliproductinventorylocationid As Integer, ByVal globalformname As Object)
        Try
            globaltotalqtyavailable = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtTq As New DataTable
            dtTq = getDataTableForSQL("SELECT COALESCE(pil.totalavailableqty,0) FROM productinventorylocation pil WHERE pil.rowid = " & globaliproductinventorylocationid & " ")
            If dtTq.Rows.Count <> 0 Then
                globaltotalqtyavailable = dtTq.Rows(0)(0)
            Else
                globaltotalqtyavailable = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getTotalQtyAvailableD(ByVal globalirackshelfcolumnid As Integer, ByVal globalformname As Object)
        Try
            globaltotalqtyavailable = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtTq As New DataTable
            dtTq = getDataTableForSQL("SELECT COALESCE(SUM(pil.totalavailableqty),0) FROM productinventorylocation pil WHERE pil.rackshelfcolumnid = " & globalirackshelfcolumnid & " AND pil.organizationid = " & Z_OrganizationID & " ")
            If dtTq.Rows.Count <> 0 Then
                globaltotalqtyavailable = dtTq.Rows(0)(0)
            Else
                globaltotalqtyavailable = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getTotalQtyAllocatedA(ByVal globaliproductcolorsizeid As Integer, ByVal globalformname As Object)
        Try
            globaltotalqtyallocated = 0
            Dim dtTq As New DataTable
            dtTq = getDataTableForSQL("SELECT COALESCE(SUM(pil.totalallocatedqty),0) FROM productinventorylocation pil " &
                            "WHERE pil.organizationid = " & Z_OrganizationID & " AND pil.productcolorsizeid = " & globaliproductcolorsizeid & " ")
            If dtTq.Rows.Count <> 0 Then
                globaltotalqtyallocated = dtTq.Rows(0)(0)
            Else
                globaltotalqtyallocated = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getTotalQtyAllocatedB(ByVal globaliproductcolorsizeid As Integer, ByVal globaliinventorylocationid As Integer, ByVal globalformname As Object)
        Try
            globaltotalqtyallocated = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtTq As New DataTable
            dtTq = getDataTableForSQL("SELECT COALESCE(SUM(pil.totalallocatedqty),0) FROM productinventorylocation pil LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " &
                            "WHERE pil.organizationid = " & Z_OrganizationID & " AND pil.productcolorsizeid = " & globaliproductcolorsizeid & " AND rsc.inventorylocationid = " & globaliinventorylocationid & " ")
            If dtTq.Rows.Count <> 0 Then
                globaltotalqtyallocated = dtTq.Rows(0)(0)
            Else
                globaltotalqtyallocated = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getTotalQtyAllocatedC(ByVal globaliproductinventorylocationid As Integer, ByVal globalformname As Object)
        Try
            globaltotalqtyallocated = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtTq As New DataTable
            dtTq = getDataTableForSQL("SELECT COALESCE(pil.totalallocatedqty,0) FROM productinventorylocation pil WHERE pil.rowid = " & globaliproductinventorylocationid & " ")
            If dtTq.Rows.Count <> 0 Then
                globaltotalqtyallocated = dtTq.Rows(0)(0)
            Else
                globaltotalqtyallocated = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getTotalQtyOrderedA(ByVal globaliproductcolorsizeid As Integer, ByVal globaliconditionstring As String, ByVal globalformname As Object)
        Try
            globaltotalqtyordered = 0
            Dim dtTq As New DataTable
            dtTq = getDataTableForSQL("SELECT COALESCE(SUM(oi.qtyordered),0) FROM orderitems oi LEFT JOIN orders o ON oi.orderid = o.rowid WHERE oi.organizationid = " & Z_OrganizationID & " AND oi.productcolorsizeid = " & globaliproductcolorsizeid & " " & globaliconditionstring & " ")
            If dtTq.Rows.Count <> 0 Then
                globaltotalqtyordered = dtTq.Rows(0)(0)
            Else
                globaltotalqtyordered = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getTotalQtyReserveA(ByVal globaliproductcolorsizeid As Integer, ByVal globalformname As Object)
        Try
            globaltotalqtyreserve = 0
            Dim dtTq As New DataTable
            dtTq = getDataTableForSQL("SELECT COALESCE(SUM(pil.totalreserveqty),0) FROM productinventorylocation pil " &
                            "WHERE pil.organizationid = " & Z_OrganizationID & " AND pil.productcolorsizeid = " & globaliproductcolorsizeid & " ")
            If dtTq.Rows.Count <> 0 Then
                globaltotalqtyreserve = dtTq.Rows(0)(0)
            Else
                globaltotalqtyreserve = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getTotalQtyReserveB(ByVal globaliproductcolorsizeid As Integer, ByVal globaliinventorylocationid As Integer, ByVal globalformname As Object)
        Try
            globaltotalqtyreserve = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtTq As New DataTable
            dtTq = getDataTableForSQL("SELECT COALESCE(SUM(pil.totalreserveqty),0) FROM productinventorylocation pil LEFT JOIN rackshelfcolumn rsc ON pil.rackshelfcolumnid = rsc.rowid " &
                            "WHERE pil.organizationid = " & Z_OrganizationID & " AND pil.productcolorsizeid = " & globaliproductcolorsizeid & " AND rsc.inventorylocationid = " & globaliinventorylocationid & " ")
            If dtTq.Rows.Count <> 0 Then
                globaltotalqtyreserve = dtTq.Rows(0)(0)
            Else
                globaltotalqtyreserve = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getTotalQtyDamageA(ByVal globaliproductcolorsizeid As Integer, ByVal globalformname As Object)
        Try
            globaltotalqtydamage = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtTq As New DataTable
            dtTq = getDataTableForSQL("SELECT COALESCE(pcs.totaldamageqty,0) FROM productcolorsizes pcs WHERE pcs.rowid = " & globaliproductcolorsizeid & " ")
            If dtTq.Rows.Count <> 0 Then
                globaltotalqtydamage = dtTq.Rows(0)(0)
            Else
                globaltotalqtydamage = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductIDA(ByVal globaliproductid As Integer, ByVal globaliproductcode As String, ByVal globalformname As Object)
        Try
            globalproductid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM products WHERE rowid != " & globaliproductid & " AND productcode = """ & globaliproductcode & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalproductid = dtGid.Rows(0)(0)
            Else
                globalproductid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductIDB(ByVal globaliproductcode As String, ByVal globalformname As Object)
        Try
            globalproductid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM products WHERE productcode = """ & globaliproductcode & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalproductid = dtGid.Rows(0)(0)
            Else
                globalproductid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getCategoryID(ByVal globalicategoryname As String, ByVal globalicondition As String, ByVal globalformname As Object)
        Try
            globalcategoryid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM categories WHERE categoryname = """ & globalicategoryname & """ AND organizationid = " & Z_OrganizationID & " " & globalicondition & "")
            If dtGid.Rows.Count <> 0 Then
                globalcategoryid = dtGid.Rows(0)(0)
            Else
                globalcategoryid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getBrandID(ByVal globalibrandname As String, ByVal globalformname As Object)
        Try
            globalbrandid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM brands WHERE brandname = """ & globalibrandname & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalbrandid = dtGid.Rows(0)(0)
            Else
                globalbrandid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getCompanyIDA(ByVal globalicondition As String, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalcompanyid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM companies WHERE organizationid = " & Z_OrganizationID & " " & globalicondition & " " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globalcompanyid = dtGid.Rows(0)(0)
            Else
                globalcompanyid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getCompanyIDB(ByVal globalicompanyname As String, ByVal globalformname As Object)
        Try
            globalcompanyid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(cm.rowid,0) FROM companies cm WHERE cm.organizationid = " & Z_OrganizationID & " AND COALESCE(CONCAT(COALESCE(cm.companyname,''),' - ',COALESCE(cm.companycode,'')),'') = """ & globalicompanyname & """ ")
            If dtGid.Rows.Count <> 0 Then
                globalcompanyid = dtGid.Rows(0)(0)
            Else
                globalcompanyid = 0
            End If
            If globalcompanyid = 0 Then
                dtGid = getDataTableForSQL("SELECT COALESCE(cm.rowid,0) FROM companies cm WHERE cm.organizationid = " & Z_OrganizationID & " AND COALESCE(CONCAT(COALESCE(cm.companycode,''),' - ',COALESCE(cm.companyname,'')),'') = """ & globalicompanyname & """ ")
                If dtGid.Rows.Count <> 0 Then
                    globalcompanyid = dtGid.Rows(0)(0)
                Else
                    globalcompanyid = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getColorID(ByVal globalicolorname As String, ByVal globalformname As Object)
        Try
            globalcolorid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM colors WHERE colorname = """ & globalicolorname & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalcolorid = dtGid.Rows(0)(0)
            Else
                globalcolorid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrganizationIDA(ByVal globaliorganizationid As Integer, ByVal globaliorganizationname As String, ByVal globalformname As Object)
        Try
            globalorganizationid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM organizations WHERE rowid != " & globaliorganizationid & " AND name = """ & globaliorganizationname & """ ")
            If dtGid.Rows.Count <> 0 Then
                globalorganizationid = dtGid.Rows(0)(0)
            Else
                globalorganizationid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductColorSizesSKUA(ByVal globalisku As String, ByVal globalformname As Object)
        Try
            globalskuid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM productcolorsizes WHERE sku = """ & globalisku & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalskuid = dtGid.Rows(0)(0)
            Else
                globalskuid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductColorSizesSKUB(ByVal globaliproductcolorsizesid As Integer, ByVal globalisku As String, ByVal globalformname As Object)
        Try
            globalskuid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM productcolorsizes WHERE rowid != " & globaliproductcolorsizesid & " AND sku = """ & globalisku & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalskuid = dtGid.Rows(0)(0)
            Else
                globalskuid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Public Sub getProductColorSizesSKU2B(globaliproductcolorsizesid As Integer,
            globalisku2 As String,
            globalformname As Form)
        Try
            globalSKU2id = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM productcolorsizes WHERE rowid != " & globaliproductcolorsizesid & " AND sku2 = """ & globalisku2 & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalSKU2id = dtGid.Rows(0)(0)
            Else
                globalSKU2id = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductBundleSKUA(ByVal globalisku As String, ByVal globalformname As Object)
        Try
            globalskuid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM productbundles WHERE sku = """ & globalisku & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalskuid = dtGid.Rows(0)(0)
            Else
                globalskuid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Public Sub getProductBundleSKU2A(globalisku2 As String, globalformname As ProductsForm)
        Try
            globalSKU2id = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM productbundles WHERE sku2 = """ & globalisku2 & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalSKU2id = dtGid.Rows(0)(0)
            Else
                globalSKU2id = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductBundleSKUB(ByVal globaliproductbundleid As Integer, ByVal globalisku As String, ByVal globalformname As Object)
        Try
            globalskuid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM productbundles WHERE rowid != " & globaliproductbundleid & " AND sku = """ & globalisku & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalskuid = dtGid.Rows(0)(0)
            Else
                globalskuid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductColorSizesIDA(ByVal globaliproductid As Integer, ByVal globalicolorid As Integer, ByVal globalisize As Decimal, ByVal globaliseasoncode As String, ByVal globalformname As Object)
        Try
            globalproductcolorsizesid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(pcs.rowid,0) FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid WHERE pc.productid = " & globaliproductid & " AND pc.colorid = " & globalicolorid & " AND pcs.size = " & globalisize & " AND pcs.seasoncode = """ & globaliseasoncode & """ AND pcs.organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalproductcolorsizesid = dtGid.Rows(0)(0)
            Else
                globalproductcolorsizesid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductColorSizesIDB(ByVal globalicombination As String, ByVal globalformname As Object)
        Try
            globalproductcolorsizesid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(pcs.rowid,0) FROM productcolorsizes pcs LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN products p ON pc.productid = p.rowid LEFT JOIN colors c ON pc.colorid = c.rowid " &
                            "WHERE pcs.organizationid = " & Z_OrganizationID & " AND CONCAT(COALESCE(p.productcode,''),' / ',COALESCE(c.colorname,''),' / ',COALESCE(pcs.size,''),' / ',COALESCE(pcs.seasoncode,'')) = """ & globalicombination & """ ")
            If dtGid.Rows.Count <> 0 Then
                globalproductcolorsizesid = dtGid.Rows(0)(0)
            Else
                globalproductcolorsizesid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductColorSizesIDC(ByVal globaliproductcolorsizeid As Integer, ByVal globaliproductcolorid As Integer, ByVal globalisize As String, ByVal globaliseasoncode As String, ByVal globalformname As Object)
        Try
            globalproductcolorsizesid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(pcs.rowid,0) FROM productcolorsizes pcs WHERE pcs.rowid != " & globaliproductcolorsizeid & " AND pcs.productcolorid = " & globaliproductcolorid & " AND pcs.size = """ & globalisize & """ AND pcs.seasoncode = """ & globaliseasoncode & """ AND pcs.organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalproductcolorsizesid = dtGid.Rows(0)(0)
            Else
                globalproductcolorsizesid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductColorsID(ByVal globaliproductid As Integer, ByVal globalicolorid As Integer, ByVal globalformname As Object)
        Try
            globalproductcolorsid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(pc.rowid,0) FROM productcolors pc  WHERE pc.productid = " & globaliproductid & " AND pc.colorid = " & globalicolorid & "  AND pc.organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalproductcolorsid = dtGid.Rows(0)(0)
            Else
                globalproductcolorsid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getCustomerID(ByVal globalicustomername As String, ByVal globalformname As Object)
        Try
            globalcustomerid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM accounts WHERE CONCAT(COALESCE(companyname,''),' - ',COALESCE(accountno,'')) = """ & globalicustomername & """ AND organizationid = " & Z_OrganizationID & " AND accounttype = 'Customer' ")
            If dtGid.Rows.Count <> 0 Then
                globalcustomerid = dtGid.Rows(0)(0)
            Else
                globalcustomerid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getAccountNo(ByVal globaliaccounttype As String, ByVal globalformname As Object)
        Try
            globalaccountno = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGno As New DataTable
            dtGno = getDataTableForSQL("SELECT COALESCE(MAX(accountno),0) FROM accounts WHERE organizationid = " & Z_OrganizationID & " AND accounttype = '" & globaliaccounttype & "' ")
            If dtGno.Rows.Count <> 0 Then
                globalaccountno = dtGno.Rows(0)(0)
                globalaccountno = globalaccountno + 1
            Else
                globalaccountno = 1
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductBundleIDA(ByVal globalibundlename As String, ByVal globalformname As Object)
        Try
            globalproductbundleid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM productbundles WHERE bundlename = """ & globalibundlename & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalproductbundleid = dtGid.Rows(0)(0)
            Else
                globalproductbundleid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductBundleIDB(ByVal globaliproductbundleid As Integer, ByVal globalibundlename As String, ByVal globalformname As Object)
        Try
            globalproductbundleid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM productbundles WHERE rowid != " & globaliproductbundleid & " AND bundlename = """ & globalibundlename & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalproductbundleid = dtGid.Rows(0)(0)
            Else
                globalproductbundleid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductBundleItemID(ByVal globaliproductbundleid As Integer, ByVal globaliproductcolorsizeid As Integer, ByVal globalformname As Object)
        Try
            globalproductbundleitemid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM productbundleitems WHERE productbundleid = " & globaliproductbundleid & " AND productcolorsizeid = " & globaliproductcolorsizeid & " AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalproductbundleitemid = dtGid.Rows(0)(0)
            Else
                globalproductbundleitemid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getUserID(ByVal globaliusername As String, ByVal globalformname As Object)
        Try
            globaluserid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(u.rowid,0) FROM users u WHERE CONCAT(COALESCE(u.firstname,''),' ',COALESCE(u.lastname,''),' - ',COALESCE(u.rowid,'')) = """ & globaliusername & """ AND u.organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globaluserid = dtGid.Rows(0)(0)
            Else
                globaluserid = 0
            End If
            If globaluserid = 0 Then
                dtGid = getDataTableForSQL("SELECT COALESCE(u.rowid,0) FROM users u WHERE CONCAT(COALESCE(u.lastname,''),' ',COALESCE(u.firstname,''),' - ',COALESCE(u.rowid,'')) = """ & globaliusername & """ AND u.organizationid = " & Z_OrganizationID & " ")
                If dtGid.Rows.Count <> 0 Then
                    globaluserid = dtGid.Rows(0)(0)
                Else
                    globaluserid = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getContactID(ByVal globalicontactname As String, ByVal globalicontacttype As String, ByVal globalformname As Object)
        Try
            globalcontactid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(c.rowid,0) FROM contacts c WHERE CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')) = """ & globalicontactname & """ AND c.organizationid = " & Z_OrganizationID & " AND c.`type` = '" & globalicontacttype & "' ")
            If dtGid.Rows.Count <> 0 Then
                globalcontactid = dtGid.Rows(0)(0)
            Else
                globalcontactid = 0
            End If
            If globalcontactid = 0 Then
                dtGid = getDataTableForSQL("SELECT COALESCE(c.rowid,0) FROM contacts c WHERE CONCAT(COALESCE(c.lastname,''),', ',COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')) = """ & globalicontactname & """ AND c.organizationid = " & Z_OrganizationID & " AND c.`type` = '" & globalicontacttype & "' ")
                If dtGid.Rows.Count <> 0 Then
                    globalcontactid = dtGid.Rows(0)(0)
                Else
                    globalcontactid = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderNo(ByVal globaliordertype As String, ByVal globalformname As Object)
        Try
            globalorderno = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGno As New DataTable
            dtGno = getDataTableForSQL("SELECT COALESCE(MAX(CAST(ordernumber AS UNSIGNED)),0) FROM orders WHERE organizationid = " & Z_OrganizationID & " AND ordertype = '" & globaliordertype & "' ")
            If dtGno.Rows.Count <> 0 Then
                globalorderno = dtGno.Rows(0)(0)
                globalorderno = globalorderno + 1
            Else
                globalorderno = 1
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getReferenceNo(ByVal globaliordertype As String, ByVal globalformname As Object)
        Try
            globalreferenceno = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGno As New DataTable
            dtGno = getDataTableForSQL("SELECT COALESCE(MAX(CAST(referencenumber AS UNSIGNED)),0) FROM orders WHERE organizationid = " & Z_OrganizationID & " AND ordertype = '" & globaliordertype & "' ")
            If dtGno.Rows.Count <> 0 Then
                globalreferenceno = dtGno.Rows(0)(0)
                globalreferenceno = globalreferenceno + 1
            Else
                globalreferenceno = 1
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderIDA(ByVal globaliordernumber As String, ByVal globaliordertype As String, ByVal globaliaccountid As Integer, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalorderid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM orders WHERE referencenumber = """ & globaliordernumber & """ AND ordertype = '" & globaliordertype & "' AND accountid = " & globaliaccountid & " AND organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globalorderid = dtGid.Rows(0)(0)
            Else
                globalorderid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderIDB(ByVal globaliorderid As Integer, ByVal globaliordernumber As String, ByVal globaliordertype As String, ByVal globaliaccountid As Integer, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalorderid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM orders WHERE rowid != " & globaliorderid & " AND referencenumber = """ & globaliordernumber & """ AND ordertype = '" & globaliordertype & "' AND accountid = " & globaliaccountid & " AND organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globalorderid = dtGid.Rows(0)(0)
            Else
                globalorderid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderIDC(ByVal globaliorderinfo As String, ByVal globaliordertype As String, ByVal globalformname As Object)
        Try
            globalorderid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(o.rowid,0) FROM orders o LEFT JOIN accounts a ON o.accountid = a.rowid WHERE COALESCE(CONCAT(COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,''),' / ',CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.)')),'') = """ & globaliorderinfo & """ AND o.organizationid = " & Z_OrganizationID & " AND o.ordertype = '" & globaliordertype & "' ")
            If dtGid.Rows.Count <> 0 Then
                globalorderid = dtGid.Rows(0)(0)
            Else
                globalorderid = 0
            End If
            If globalorderid = 0 Then
                dtGid = getDataTableForSQL("SELECT COALESCE(o.rowid,0) FROM orders o LEFT JOIN accounts a ON o.accountid = a.rowid WHERE COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ',COALESCE(a.companyname,''),' - ',COALESCE(a.accountno,'')),'') = """ & globaliorderinfo & """ AND o.organizationid = " & Z_OrganizationID & " AND o.ordertype = '" & globaliordertype & "' ")
                If dtGid.Rows.Count <> 0 Then
                    globalorderid = dtGid.Rows(0)(0)
                Else
                    globalorderid = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderIDD(ByVal globaliorderinfo As String, ByVal globalformname As Object)
        Try
            globalpackinglistid = 0 : globalorderid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(pl.rowid,0),COALESCE(o.rowid,0) FROM packinglist pl LEFT JOIN orders o ON pl.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid LEFT JOIN packinglistcartons plc ON pl.rowid = plc.packinglistid WHERE COALESCE(CONCAT(COALESCE(a.companyname,''),' - ', COALESCE(a.accountno,''),' / ',COALESCE(o.ordernumber,''),' (C.O. No.) / ',CONCAT(COALESCE(pl.packinglistno,''),' (Pa.L. No.)')),'') = """ & globaliorderinfo & """ AND pl.organizationid = " & Z_OrganizationID & " AND plc.`status` = 'Active' ")
            If dtGid.Rows.Count <> 0 Then
                globalpackinglistid = dtGid.Rows(0)(0)
                globalorderid = dtGid.Rows(0)(1)
            Else
                globalpackinglistid = 0 : globalorderid = 0
            End If
            If globalpackinglistid = 0 Then
                dtGid = getDataTableForSQL("SELECT COALESCE(pl.rowid,0),COALESCE(o.rowid,0) FROM packinglist pl LEFT JOIN orders o ON pl.orderid = o.rowid LEFT JOIN accounts a ON o.accountid = a.rowid LEFT JOIN packinglistcartons plc ON pl.rowid = plc.packinglistid WHERE COALESCE(CONCAT(COALESCE(o.ordernumber,''),' (C.O. No.) / ', COALESCE(a.companyname,''),' - ', COALESCE(a.accountno,''),' / ',CONCAT(COALESCE(pl.packinglistno,''),' (Pa.L. No.)')),'') = """ & globaliorderinfo & """ AND pl.organizationid = " & Z_OrganizationID & " AND plc.`status` = 'Active' ")
                If dtGid.Rows.Count <> 0 Then
                    globalpackinglistid = dtGid.Rows(0)(0)
                    globalorderid = dtGid.Rows(0)(1)
                Else
                    globalpackinglistid = 0 : globalorderid = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderIDE(ByVal globaliordernumber As String, ByVal globaliordertype As String, ByVal globaliaccountid As Integer, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalorderid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM orders WHERE drnumber = """ & globaliordernumber & """ AND ordertype = '" & globaliordertype & "' AND accountid = " & globaliaccountid & " AND organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globalorderid = dtGid.Rows(0)(0)
            Else
                globalorderid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderIDF(ByVal globaliorderid As Integer, ByVal globaliordernumber As String, ByVal globaliordertype As String, ByVal globaliaccountid As Integer, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalorderid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM orders WHERE rowid != " & globaliorderid & " AND drnumber = """ & globaliordernumber & """ AND ordertype = '" & globaliordertype & "' AND accountid = " & globaliaccountid & " AND organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globalorderid = dtGid.Rows(0)(0)
            Else
                globalorderid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPickListGroupID(ByVal globalipicklistgroupname As String, ByVal globalformname As Object)
        Try
            globalpicklistgroupid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM picklistgroup WHERE groupname = """ & globalipicklistgroupname & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalpicklistgroupid = dtGid.Rows(0)(0)
            Else
                globalpicklistgroupid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderStatus(ByVal globaliorderid As Integer, ByVal globalformname As Object)
        Try
            globalorderstatus = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGs As New DataTable
            dtGs = getDataTableForSQL("SELECT COALESCE(o.status,'') FROM orders o WHERE o.rowid = " & globaliorderid & " ")
            If dtGs.Rows.Count <> 0 Then
                globalorderstatus = dtGs.Rows(0)(0)
            Else
                globalorderstatus = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderInfo(ByVal globaliorderid As Integer, ByVal globalformname As Object)
        Try
            globalorderdate = "" : globaltargetdate = "" : globaldeliveryhours = "" : globaladdressname = "" : globalordercanceldate = ""
            globalorderclassdescription = "" : globalorderpono = "" : globalordersidrno = "" : globalbranchname = "" : globalvendorname = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGinfo As New DataTable
            dtGinfo = getDataTableForSQL("SELECT COALESCE(DATE_FORMAT(o.orderdate,'%d-%b-%Y'),''),COALESCE(DATE_FORMAT(o.targetdate,'%d-%b-%Y'),''),COALESCE(o.deliveryhours,''),COALESCE(o.customeraddress,''),COALESCE(DATE_FORMAT(o.enddate,'%d-%b-%Y'),''),COALESCE(o.referencenumber,'')," &
                    "COALESCE(o.drnumber,''),COALESCE(CONCAT(COALESCE(cc.codename,''),' / ',COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),''),COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),''),COALESCE(CONCAT(COALESCE(ve.companyname,''),' - ',COALESCE(ve.companycode,'')),'') " &
                    "FROM orders o LEFT JOIN combinecodings cc ON o.combinecodingid = cc.rowid LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid LEFT JOIN branches bc ON o.branchid = bc.rowid LEFT JOIN companies ve ON o.companyid = ve.rowid WHERE o.rowid = " & globaliorderid & " ")
            If dtGinfo.Rows.Count <> 0 Then
                globalorderdate = dtGinfo.Rows(0)(0)
                globaltargetdate = dtGinfo.Rows(0)(1)
                globaldeliveryhours = dtGinfo.Rows(0)(2)
                globaladdressname = dtGinfo.Rows(0)(3)
                globalordercanceldate = dtGinfo.Rows(0)(4)
                globalorderpono = dtGinfo.Rows(0)(5)
                globalordersidrno = dtGinfo.Rows(0)(6)
                globalorderclassdescription = dtGinfo.Rows(0)(7)
                globalbranchname = dtGinfo.Rows(0)(8)
                globalvendorname = dtGinfo.Rows(0)(9)
            Else
                globalorderdate = "" : globaltargetdate = "" : globaldeliveryhours = "" : globaladdressname = "" : globalordercanceldate = ""
                globalorderclassdescription = "" : globalorderpono = "" : globalordersidrno = "" : globalbranchname = "" : globalvendorname = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderItemStatus(ByVal globaliorderitemid As Integer, ByVal globalformname As Object)
        Try
            globalorderitemstatus = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGs As New DataTable
            dtGs = getDataTableForSQL("SELECT COALESCE(oi.status,'') FROM orderitems oi WHERE oi.rowid = " & globaliorderitemid & " ")
            If dtGs.Rows.Count <> 0 Then
                globalorderitemstatus = dtGs.Rows(0)(0)
            Else
                globalorderitemstatus = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderTotalAmount(ByVal globaliorderid As Integer, ByVal globalformname As Object)
        Try
            globalordertotalamount = 0.0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtOta As New DataTable
            dtOta = getDataTableForSQL("SELECT COALESCE(o.totalamount,0.0) FROM orders o WHERE o.rowid = " & globaliorderid & " ")
            If dtOta.Rows.Count <> 0 Then
                globalordertotalamount = dtOta.Rows(0)(0)
            Else
                globalordertotalamount = 0.0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderItemInfo(ByVal globaliorderitemid As Integer, ByVal globalformname As Object)
        Try
            globalorderitemsrp = 0.0 : globalorderitemqtyordered = 0 : globalorderitemtag = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtOIin As New DataTable
            dtOIin = getDataTableForSQL("SELECT COALESCE(oi.qtyordered,0),COALESCE(oi.srp,0.0),COALESCE(oi.tags,'') FROM orderitems oi WHERE oi.rowid = " & globaliorderitemid & " ")
            If dtOIin.Rows.Count <> 0 Then
                globalorderitemqtyordered = dtOIin.Rows(0)(0)
                globalorderitemsrp = dtOIin.Rows(0)(1)
                globalorderitemtag = dtOIin.Rows(0)(2)
            Else
                globalorderitemsrp = 0.0 : globalorderitemqtyordered = 0 : globalorderitemtag = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPickListNoA(ByVal globalformname As Object)
        Try
            globalpicklistno = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGno As New DataTable
            dtGno = getDataTableForSQL("SELECT COALESCE(MAX(CAST(picklistno AS UNSIGNED)),0) FROM picklist WHERE organizationid = " & Z_OrganizationID & " ")
            If dtGno.Rows.Count <> 0 Then
                globalpicklistno = dtGno.Rows(0)(0)
                globalpicklistno = globalpicklistno + 1
            Else
                globalpicklistno = 1
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPickListNoB(ByVal globaliorderid As Integer, ByVal globalformname As Object)
        Try
            globalpicklistno = 0
            Dim dtGno As New DataTable
            dtGno = getDataTableForSQL("SELECT COALESCE(pl.picklistno,0) FROM picklistorders plo LEFT JOIN picklist pl ON plo.picklistid = pl.rowid WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.orderid = " & globaliorderid & " AND (plo.status != 'Inactive' AND plo.status != 'Cancelled') GROUP BY pl.rowid ")
            If dtGno.Rows.Count <> 0 Then
                globalpicklistno = dtGno.Rows(0)(0)
            Else
                globalpicklistno = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getContactNo(ByVal globalicontacttype As String, ByVal globalformname As Object)
        Try
            globalcontactno = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGno As New DataTable
            dtGno = getDataTableForSQL("SELECT COALESCE(MAX(contactno),0) FROM contacts WHERE organizationid = " & Z_OrganizationID & " AND `type` = '" & globalicontacttype & "' ")
            If dtGno.Rows.Count <> 0 Then
                globalcontactno = dtGno.Rows(0)(0)
                globalcontactno = globalcontactno + 1
            Else
                globalcontactno = 1
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPickListOrderID(ByVal globalipicklistid As Integer, ByVal globaliorderid As Integer, ByVal globaliorderitemid As Integer, ByVal globalformname As Object)
        Try
            globalpicklistorderid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(plo.rowid,0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.picklistid = " & globalipicklistid & " AND plo.orderid = " & globaliorderid & " AND plo.orderitemid = " & globaliorderitemid & " ")
            If dtGid.Rows.Count <> 0 Then
                globalpicklistorderid = dtGid.Rows(0)(0)
            Else
                globalpicklistorderid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPickListStatus(ByVal globalipicklistid As Integer, ByVal globalformname As Object)
        Try
            globalpickliststatus = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGs As New DataTable
            dtGs = getDataTableForSQL("SELECT COALESCE(pl.status,'') FROM picklist pl WHERE pl.rowid = " & globalipicklistid & " ")
            If dtGs.Rows.Count <> 0 Then
                globalpickliststatus = dtGs.Rows(0)(0)
            Else
                globalpickliststatus = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPickListOrderStatus(ByVal globalipicklistid As Integer, ByVal globaliorderid As Integer, ByVal globaliorderitemid As Integer, ByVal globalformname As Object)
        Try
            globalpicklistorderstatus = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGst As New DataTable
            dtGst = getDataTableForSQL("SELECT COALESCE(plo.status,'') FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.picklistid = " & globalipicklistid & " AND plo.orderid = " & globaliorderid & " AND plo.orderitemid = " & globaliorderitemid & " ")
            If dtGst.Rows.Count <> 0 Then
                globalpicklistorderstatus = dtGst.Rows(0)(0)
            Else
                globalpicklistorderstatus = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPickListOrderItemID(ByVal globalipicklistorderid As Integer, ByVal globaliproductinventorylocationid As Integer, ByVal globalformname As Object)
        Try
            globalpicklistorderitemid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(pli.rowid,0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & globalipicklistorderid & " AND pli.productinventorylocationid = " & globaliproductinventorylocationid & " ")
            If dtGid.Rows.Count <> 0 Then
                globalpicklistorderitemid = dtGid.Rows(0)(0)
            Else
                globalpicklistorderitemid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPickListOrderItemInfo(ByVal globalipicklistorderid As Integer, ByVal globaliproductinventorylocationid As Integer, ByVal globalformname As Object)
        Try
            globalpicklistorderitemissueflg = "" : globalpicklistorderitemremarks = "" : globalpicklistorderitemqtypicked = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGin As New DataTable
            dtGin = getDataTableForSQL("SELECT COALESCE(pli.issueflg,''),COALESCE(pli.remarks,''),COALESCE(pli.qtypicked,0) FROM picklistorderitems pli WHERE pli.organizationid = " & Z_OrganizationID & " AND pli.picklistorderid = " & globalipicklistorderid & " AND pli.productinventorylocationid = " & globaliproductinventorylocationid & " ")
            If dtGin.Rows.Count <> 0 Then
                globalpicklistorderitemissueflg = dtGin.Rows(0)(0)
                globalpicklistorderitemremarks = dtGin.Rows(0)(1)
                globalpicklistorderitemqtypicked = dtGin.Rows(0)(2)
            Else
                globalpicklistorderitemissueflg = "" : globalpicklistorderitemremarks = "" : globalpicklistorderitemqtypicked = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getUserName(ByVal globaliuserid As Integer, ByVal globalformname As Object)
        Try
            globalusername = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGun As New DataTable
            dtGun = getDataTableForSQL("SELECT COALESCE(CONCAT(COALESCE(u.firstname,''),' ',COALESCE(u.lastname,''),' - ',COALESCE(u.rowid,'')),'') FROM users u WHERE rowid = " & globaliuserid & " ")
            If dtGun.Rows.Count <> 0 Then
                globalusername = dtGun.Rows(0)(0)
            Else
                globalusername = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getCountPickListOrder(ByVal globalipicklistid As Integer, ByVal globalicondition As String, ByVal globalformname As Object)
        Try
            globalpicklistordercount = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGct As New DataTable
            dtGct = getDataTableForSQL("SELECT COALESCE(COUNT(plo.rowid),0) FROM picklistorders plo WHERE plo.organizationid = " & Z_OrganizationID & " AND plo.picklistid = " & globalipicklistid & " " & globalicondition & " ")
            If dtGct.Rows.Count <> 0 Then
                globalpicklistordercount = dtGct.Rows(0)(0)
            Else
                globalpicklistordercount = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getProductInventoryLocationTotals(ByVal globaliproductinventorylocationid As Integer, ByVal globalformname As Object)
        Try
            globalpiltotalavailableqty = 0 : globalpiltotalreserveqty = 0
            Dim dtPILt As New DataTable
            dtPILt = getDataTableForSQL("SELECT COALESCE(pil.totalavailableqty,0),COALESCE(pil.totalreserveqty,0) FROM productinventorylocation pil WHERE pil.rowid = " & globaliproductinventorylocationid & " ")
            If dtPILt.Rows.Count <> 0 Then
                globalpiltotalavailableqty = dtPILt.Rows(0)(0)
                globalpiltotalreserveqty = dtPILt.Rows(0)(1)
            Else
                globalpiltotalavailableqty = 0 : globalpiltotalreserveqty = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getPackingListNoA(ByVal globalformname As Object)
        Try
            globalpackinglistno = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGno As New DataTable
            dtGno = getDataTableForSQL("SELECT COALESCE(MAX(CAST(packinglistno AS UNSIGNED)),0) FROM packinglist WHERE organizationid = " & Z_OrganizationID & " ")
            If dtGno.Rows.Count <> 0 Then
                globalpackinglistno = dtGno.Rows(0)(0)
                globalpackinglistno = globalpackinglistno + 1
            Else
                globalpackinglistno = 1
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPackingListNoB(ByVal globaliorderid As Integer, ByVal globalformname As Object)
        Try
            globalpackinglistno = 0
            Dim dtGno As New DataTable
            dtGno = getDataTableForSQL("SELECT COALESCE(pal.packinglistno,0) FROM packinglist pal WHERE pal.organizationid = " & Z_OrganizationID & " AND pal.orderid = " & globaliorderid & " AND pal.`status` != 'Cancelled' ")
            If dtGno.Rows.Count <> 0 Then
                globalpackinglistno = dtGno.Rows(0)(0)
            Else
                globalpackinglistno = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getPackingListStatus(ByVal globalipackinglistid As Integer, ByVal globalformname As Object)
        Try
            globalpackingliststatus = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGs As New DataTable
            dtGs = getDataTableForSQL("SELECT COALESCE(pal.`status`,'') FROM packinglist pal WHERE pal.rowid = " & globalipackinglistid & " ")
            If dtGs.Rows.Count <> 0 Then
                globalpackingliststatus = dtGs.Rows(0)(0)
            Else
                globalpackingliststatus = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPackingListIDA(ByVal globalipackinglistno As String, ByVal globaliorderid As Integer, ByVal globalformname As Object)
        Try
            globalpackinglistid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM packinglist WHERE packinglistno = """ & globalipackinglistno & """ AND orderid = " & globaliorderid & " AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalpackinglistid = dtGid.Rows(0)(0)
            Else
                globalpackinglistid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPackingListIDB(ByVal globalipackinglistid As Integer, ByVal globalipackinglistno As String, ByVal globaliorderid As Integer, ByVal globalformname As Object)
        Try
            globalpackinglistid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM packinglist WHERE rowid != " & globalipackinglistid & " AND packinglistno = """ & globalipackinglistno & """ AND orderid = " & globaliorderid & " AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalpackinglistid = dtGid.Rows(0)(0)
            Else
                globalpackinglistid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPackingListIDC(ByVal globaliorderid As Integer, ByVal globalformname As Object)
        Try
            globalpackinglistid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM packinglist WHERE orderid = " & globaliorderid & " AND organizationid = " & Z_OrganizationID & " AND status != 'Cancelled' ")
            If dtGid.Rows.Count <> 0 Then
                globalpackinglistid = dtGid.Rows(0)(0)
            Else
                globalpackinglistid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPackingListCartonIDA(ByVal globalipackinglistid As Integer, ByVal globalicartonno As String, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalpackinglistcartonid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM packinglistcartons WHERE packinglistid = " & globalipackinglistid & " AND cartonno = """ & globalicartonno & """ AND organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globalpackinglistcartonid = dtGid.Rows(0)(0)
            Else
                globalpackinglistcartonid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPackingListCartonIDB(ByVal globalipackinglistcartonid As Integer, ByVal globalipackinglistid As Integer, ByVal globalicartonno As String, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalpackinglistcartonid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM packinglistcartons WHERE rowid != " & globalipackinglistcartonid & " AND packinglistid = " & globalipackinglistid & " AND cartonno = """ & globalicartonno & """ AND organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globalpackinglistcartonid = dtGid.Rows(0)(0)
            Else
                globalpackinglistcartonid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getCartonNo(ByVal globalipackinglistid As Integer, ByVal globalformname As Object)
        Try
            globalcartonno = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGno As New DataTable
            dtGno = getDataTableForSQL("SELECT COALESCE(MAX(CAST(cartonno AS UNSIGNED)),0) FROM packinglistcartons WHERE organizationid = " & Z_OrganizationID & " AND packinglistid = " & globalipackinglistid & " ")
            If dtGno.Rows.Count <> 0 Then
                globalcartonno = dtGno.Rows(0)(0)
                globalcartonno = globalcartonno + 1
            Else
                globalcartonno = 1
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPackingListCartonItemID(ByVal globalipackinglistcartonid As Integer, ByVal globaliorderitemid As Integer, ByVal globalformname As Object)
        Try
            globalpackinglistcartonitemid = 0 : globalpackinglistcartonitemqtyincarton = 0 : globalpackinglistcartonitemstatus = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0),COALESCE(qtyincarton,0),COALESCE(`status`,'') FROM packinglistcartonitems WHERE packinglistcartonid = " & globalipackinglistcartonid & " AND organizationid = " & Z_OrganizationID & " AND orderitemid = " & globaliorderitemid & " ")
            If dtGid.Rows.Count <> 0 Then
                globalpackinglistcartonitemid = dtGid.Rows(0)(0)
                globalpackinglistcartonitemqtyincarton = dtGid.Rows(0)(1)
                globalpackinglistcartonitemstatus = dtGid.Rows(0)(2)
            Else
                globalpackinglistcartonitemid = 0
                globalpackinglistcartonitemqtyincarton = 0
                globalpackinglistcartonitemstatus = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPackingListCartonStatus(ByVal globalipackinglistcartonid As Integer, ByVal globalformname As Object)
        Try
            globalpackinglistcartonstatus = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGst As New DataTable
            dtGst = getDataTableForSQL("SELECT COALESCE(status,'') FROM packinglistcartons WHERE rowid = " & globalipackinglistcartonid & " ")
            If dtGst.Rows.Count <> 0 Then
                globalpackinglistcartonstatus = dtGst.Rows(0)(0)
            Else
                globalpackinglistcartonstatus = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPackingListCartonInfo(ByVal globalipackinglistcartonid As Integer, ByVal globalformname As Object)
        Try
            globalpackedby = 0 : globalpackername = "" : globalpackeddate = "" : globalpackedcartonno = "" : globalboxsizename = ""
            globalpackedweight = 0.0 : globalpackedamount = 0.0 : globalpackedweightuom = "" : globalpackedsizeinfo = "" : globalcbm = 0.0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGin As New DataTable
            dtGin = getDataTableForSQL("SELECT COALESCE(pc.contactid,0),COALESCE(pc.cartonno,''),COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),''),COALESCE(DATE_FORMAT(pc.packeddate,'%d-%b-%Y'),''),COALESCE(pc.`weight`,0.0)," &
                    "COALESCE(pc.weightuom,''),COALESCE(pc.amount,0.0),COALESCE(CONCAT(COALESCE(cs.sizename,''),' - ', COALESCE(cs.`length`,''),' ', COALESCE(cs.lengthuom,''),'/', COALESCE(cs.`width`,''),' ', COALESCE(cs.widthuom,''),'/', COALESCE(cs.`height`,''),' ', COALESCE(cs.heightuom,''),' - l/w/h'),'')," &
                    "COALESCE(cs.sizename,''),COALESCE(cs.`length`,0),COALESCE(cs.`width`,0),COALESCE(cs.`height`,0) FROM packinglistcartons pc LEFT JOIN contacts c ON pc.contactid = c.rowid LEFT JOIN cartonsizes cs ON pc.cartonsizeid = cs.rowid WHERE pc.rowid = " & globalipackinglistcartonid & " ")
            If dtGin.Rows.Count <> 0 Then
                globalpackedby = dtGin.Rows(0)(0)
                globalpackedcartonno = dtGin.Rows(0)(1)
                globalpackername = dtGin.Rows(0)(2)
                globalpackeddate = dtGin.Rows(0)(3)
                globalpackedweight = dtGin.Rows(0)(4)
                globalpackedweightuom = dtGin.Rows(0)(5)
                globalpackedamount = dtGin.Rows(0)(6)
                globalpackedsizeinfo = dtGin.Rows(0)(7)
                globalboxsizename = dtGin.Rows(0)(8)
                globalcbm = Math.Round(CDec(dtGin.Rows(0)(9)) * CDec(dtGin.Rows(0)(10)) * CDec(dtGin.Rows(0)(11)), 2)
            Else
                globalpackedby = 0 : globalpackername = "" : globalpackeddate = "" : globalpackedcartonno = "" : globalpackedweight = 0.0
                globalpackedamount = 0.0 : globalpackedweightuom = "" : globalpackedsizeinfo = "" : globalboxsizename = "" : globalcbm = 0.0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPackingListCartonItemInfo(ByVal globalipackinglistcartonitemid As Integer, ByVal globalformname As Object)
        Try
            globalorderitemid = 0 : globalpackinglistcartonitemqtyincarton = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(pci.orderitemid,0),COALESCE(pci.qtyincarton,0) FROM packinglistcartonitems pci WHERE pci.rowid = " & globalipackinglistcartonitemid & " ")
            If dtGid.Rows.Count <> 0 Then
                globalorderitemid = dtGid.Rows(0)(0)
                globalpackinglistcartonitemqtyincarton = dtGid.Rows(0)(1)
            Else
                globalorderitemid = 0 : globalpackinglistcartonitemqtyincarton = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getDeliveryTruckNo(ByVal globalformname As Object)
        Try
            globaldeliverytruckno = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGno As New DataTable
            dtGno = getDataTableForSQL("SELECT COALESCE(MAX(truckno),0) FROM deliverytrucks WHERE organizationid = " & Z_OrganizationID & "  ")
            If dtGno.Rows.Count <> 0 Then
                globaldeliverytruckno = dtGno.Rows(0)(0)
                globaldeliverytruckno = globaldeliverytruckno + 1
            Else
                globaldeliverytruckno = 1
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getDeliveryTruckIDA(ByVal globalitruckname As String, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globaldeliverytruckid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM deliverytrucks WHERE truckname = """ & globalitruckname & """ AND organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globaldeliverytruckid = dtGid.Rows(0)(0)
            Else
                globaldeliverytruckid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getDeliveryTruckIDB(ByVal globalitruckname As String, ByVal globalformname As Object)
        Try
            globaldeliverytruckid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(dt.rowid,0) FROM deliverytrucks dt WHERE COALESCE(CONCAT(COALESCE(dt.truckname,''),' - ',COALESCE(dt.plateno,''),' - ',COALESCE(dt.truckno,'')),'') = """ & globalitruckname & """ AND dt.organizationid = " & Z_OrganizationID & " AND dt.`status` = 'Active' ")
            If dtGid.Rows.Count <> 0 Then
                globaldeliverytruckid = dtGid.Rows(0)(0)
            Else
                globaldeliverytruckid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getShiftIDA(ByVal globalishiftname As String, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalshiftid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM shifts WHERE shiftname = """ & globalishiftname & """ AND organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globalshiftid = dtGid.Rows(0)(0)
            Else
                globalshiftid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getShiftIDB(ByVal globalishiftname As String, ByVal globalformname As Object)
        Try
            globalshiftid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(s.rowid,0) FROM shifts s WHERE COALESCE(CONCAT(COALESCE(s.shiftname,''),' - From: ',COALESCE(TIME_FORMAT(s.timefrom,'%r'),''),'  To: ',COALESCE(TIME_FORMAT(s.timeto,'%r'),'')),'') = """ & globalishiftname & """ AND s.organizationid = " & Z_OrganizationID & " AND s.`status` = 'Active' ")
            If dtGid.Rows.Count <> 0 Then
                globalshiftid = dtGid.Rows(0)(0)
            Else
                globalshiftid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getDeliveryTruckShiftIDA(ByVal globalideliverytruckid As Integer, ByVal globalishiftid As Integer, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globaldeliverytruckshiftid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(dts.rowid,0) FROM deliverytruckshifts dts WHERE dts.deliverytruckid = " & globalideliverytruckid & " AND dts.shiftid = " & globalishiftid & " AND dts.organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globaldeliverytruckshiftid = dtGid.Rows(0)(0)
            Else
                globaldeliverytruckshiftid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getDeliveryTruckShiftIDB(ByVal globaltruckshiftinfo As String, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globaldeliverytruckshiftid = 0 : globaldeliverytruckid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(dts.rowid,0),COALESCE(dts.deliverytruckid,0)  FROM deliverytruckshifts dts LEFT JOIN deliverytrucks dt ON dts.deliverytruckid = dt.rowid LEFT JOIN shifts s ON dts.shiftid = s.rowid WHERE COALESCE(CONCAT(COALESCE(dt.truckname,''),' - ',COALESCE(dt.truckno,''),' / ',COALESCE(s.shiftname,'')),'') = """ & globaltruckshiftinfo & """ AND dts.organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globaldeliverytruckshiftid = dtGid.Rows(0)(0)
                globaldeliverytruckid = dtGid.Rows(0)(1)
            Else
                globaldeliverytruckshiftid = 0 : globaldeliverytruckid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getAccountInfo(ByVal globaliaccountid As Integer, ByVal globalformname As Object)
        Try
            globaldeliveryhours = "" : globaladdressname = "" : globalbranchname = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGinfo As New DataTable
            dtGinfo = getDataTableForSQL("SELECT COALESCE(c.deliveryhours,''),CONCAT(COALESCE(ad.streetaddress1,''),' ',COALESCE(ad.streetaddress2,''),' ',COALESCE(ad.barangay,''),' ',COALESCE(ad.citytown,''),' ',COALESCE(ad.province,''),' ',COALESCE(ad.state,''),' ',COALESCE(ad.zipcode,''),' ',COALESCE(ad.country,''))," &
                            "COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),'') FROM accounts c LEFT JOIN address ad ON c.primaryaddressid = ad.rowid LEFT JOIN branches bc ON c.branchid = bc.rowid WHERE c.rowid = " & globaliaccountid & " ")
            If dtGinfo.Rows.Count <> 0 Then
                globaldeliveryhours = dtGinfo.Rows(0)(0)
                globaladdressname = dtGinfo.Rows(0)(1)
                globalbranchname = dtGinfo.Rows(0)(2)
            Else
                globaldeliveryhours = "" : globaladdressname = "" : globalbranchname = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getLineUpNo(ByVal globalformname As Object)
        Try
            globallineupno = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGno As New DataTable
            dtGno = getDataTableForSQL("SELECT COALESCE(MAX(CAST(lineupno AS UNSIGNED)),0) FROM lineups WHERE organizationid = " & Z_OrganizationID & " ")
            If dtGno.Rows.Count <> 0 Then
                globallineupno = dtGno.Rows(0)(0)
                globallineupno = globallineupno + 1
            Else
                globallineupno = 1
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getLineUpIDA(ByVal globalideliverytruckshiftid As Integer, ByVal globaliorderid As Integer, ByVal globalilineupdate As String, ByVal globalformname As Object)
        Try
            globallineupid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM lineups WHERE deliverytruckshiftid = " & globalideliverytruckshiftid & " AND orderid = " & globaliorderid & " AND lineupdate = """ & globalilineupdate & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globallineupid = dtGid.Rows(0)(0)
            Else
                globallineupid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getLineUpIDB(ByVal globalilineupid As Integer, ByVal globalideliveryno As String, ByVal globalformname As Object)
        Try
            globallineupid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM lineups WHERE rowid != " & globalilineupid & " AND deliveryno = """ & globalideliveryno & """ AND status != 'Cancelled' AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globallineupid = dtGid.Rows(0)(0)
            Else
                globallineupid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getLineUpIDC(ByVal globalilineupid As Integer, ByVal globalideliverytruckshiftid As Integer, ByVal globaliorderid As Integer, ByVal globalilineupdate As String, ByVal globalformname As Object)
        Try
            globallineupid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM lineups WHERE rowid != " & globalilineupid & " AND deliverytruckshiftid = " & globalideliverytruckshiftid & " AND orderid = " & globaliorderid & " AND lineupdate = """ & globalilineupdate & """ AND organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globallineupid = dtGid.Rows(0)(0)
            Else
                globallineupid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getLineUpStatus(ByVal globalilineupid As Integer, ByVal globalformname As Object)
        Try
            globallineupstatus = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGst As New DataTable
            dtGst = getDataTableForSQL("SELECT COALESCE(status,'') FROM lineups WHERE rowid = " & globalilineupid & " ")
            If dtGst.Rows.Count <> 0 Then
                globallineupstatus = dtGst.Rows(0)(0)
            Else
                globallineupstatus = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getLineUpCartonStatus(ByVal globalilineupcartonid As Integer, ByVal globalformname As Object)
        Try
            globallineupcartonstatus = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGst As New DataTable
            dtGst = getDataTableForSQL("SELECT COALESCE(`status`,'') FROM lineupcartons WHERE rowid = " & globalilineupcartonid & " ")
            If dtGst.Rows.Count <> 0 Then
                globallineupcartonstatus = dtGst.Rows(0)(0)
            Else
                globallineupcartonstatus = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getLineUpNos(ByVal globaliorderid As Integer, ByVal globalformname As Object)
        Try
            formatcount = 0 : globallineupnos = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim sql1 As String = "SELECT COALESCE(lineupno) FROM lineups WHERE organizationid = " & Z_OrganizationID & " AND `status` = 'Lined Up' AND orderid = " & globaliorderid & " GROUP BY rowid ORDER BY lineupno "
            If globalconn.State = ConnectionState.Closed Then globalconn.Open()
            Dim cmd1 As New MySqlCommand(sql1, globalconn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader()
            While reader1.Read()
                If formatcount = 0 Then
                    globallineupnos = CStr(reader1(0))
                Else
                    globallineupnos = "" & globallineupnos & ", " & CStr(reader1(0)) & " "
                End If
                formatcount = formatcount + 1
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getLineUpCBMID(ByVal globalideliverytruckshiftid As Integer, ByVal globalilineupdate As String, ByVal globalformname As Object)
        Try
            globallineupcbmid = 0 : globalcbm = 0.0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0),COALESCE(cbm,0.0) FROM lineupcbm WHERE deliverytruckshiftid = " & globalideliverytruckshiftid & " AND lineupdate = """ & globalilineupdate & """ AND organizationid = " & Z_OrganizationID & " AND `status` != 'Inactive' ")
            If dtGid.Rows.Count <> 0 Then
                globallineupcbmid = dtGid.Rows(0)(0)
                globalcbm = dtGid.Rows(0)(1)
            Else
                globallineupcbmid = 0 : globalcbm = 0.0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getPositionID(ByVal globalformname As Object)
        Try
            globalpositionid = 0
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(u.positionid,0) FROM users u WHERE u.rowid = " & Z_UserID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalpositionid = dtGid.Rows(0)(0)
            Else
                globalpositionid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getPositionView(ByVal globalipositionid As Integer, ByVal globaliviewname As String, ByVal globalformname As Object)
        Try
            globalcreateflg = "" : globalupdateflg = "" : globaldisableflg = "" : globalreadonlyflg = ""
            Dim dtPV As New DataTable
            dtPV = getDataTableForSQL("SELECT COALESCE(pv.creates,''),COALESCE(pv.updates,''),COALESCE(pv.disable,''),COALESCE(pv.readonly,'') FROM positionviews pv LEFT JOIN views v ON pv.viewid = v.rowid WHERE pv.organizationid = " & Z_OrganizationID & " AND pv.positionid = " & globalipositionid & " AND v.viewname = """ & globaliviewname & """ ")
            If dtPV.Rows.Count <> 0 Then
                globalcreateflg = dtPV.Rows(0)(0)
                globalupdateflg = dtPV.Rows(0)(1)
                globaldisableflg = dtPV.Rows(0)(2)
                globalreadonlyflg = dtPV.Rows(0)(3)
            Else
                globalcreateflg = "" : globalupdateflg = "" : globaldisableflg = "" : globalreadonlyflg = ""
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getBranchCodeIDA(ByVal globalicondition As String, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalbranchid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM branches WHERE organizationid = " & Z_OrganizationID & " " & globalicondition & " " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globalbranchid = dtGid.Rows(0)(0)
            Else
                globalbranchid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getBranchCodeIDB(ByVal globalibranchcodename As String, ByVal globalformname As Object)
        Try
            globalbranchid = 0 : globalbranchaddress = ""
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(bc.rowid,0),COALESCE(bc.branchaddress,'') FROM branches bc WHERE bc.organizationid = " & Z_OrganizationID & " AND COALESCE(CONCAT(COALESCE(bc.branchcode,''),' - ',COALESCE(bc.branchname,'')),'') = """ & globalibranchcodename & """ ")
            If dtGid.Rows.Count <> 0 Then
                globalbranchid = dtGid.Rows(0)(0)
                globalbranchaddress = dtGid.Rows(0)(1)
            Else
                globalbranchid = 0 : globalbranchaddress = ""
            End If
            If globalbranchid = 0 Then
                dtGid = getDataTableForSQL("SELECT COALESCE(bc.rowid,0),COALESCE(bc.branchaddress,'') FROM branches bc WHERE bc.organizationid = " & Z_OrganizationID & " AND COALESCE(CONCAT(COALESCE(bc.branchname,''),' - ',COALESCE(bc.branchcode,'')),'') = """ & globalibranchcodename & """ ")
                If dtGid.Rows.Count <> 0 Then
                    globalbranchid = dtGid.Rows(0)(0)
                    globalbranchaddress = dtGid.Rows(0)(1)
                Else
                    globalbranchid = 0 : globalbranchaddress = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getCombineCodingsIDA(ByVal globalicodename As String, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalcombinecodingid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM combinecodings WHERE organizationid = " & Z_OrganizationID & " AND codename = """ & globalicodename & """ " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globalcombinecodingid = dtGid.Rows(0)(0)
            Else
                globalcombinecodingid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getCombineCodingsIDB(ByVal globaliclassdescription As String, ByVal globalformname As Object)
        Try
            globalcombinecodingid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(cc.rowid,0) FROM combinecodings cc LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid " &
                                "WHERE cc.organizationid = " & Z_OrganizationID & " AND COALESCE(CONCAT(COALESCE(cc.codename,''),' / ',COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,'')),'') = """ & globaliclassdescription & """ ")
            If dtGid.Rows.Count <> 0 Then
                globalcombinecodingid = dtGid.Rows(0)(0)
            Else
                globalcombinecodingid = 0
            End If
            If globalcombinecodingid = 0 Then
                dtGid = getDataTableForSQL("SELECT COALESCE(cc.rowid,0) FROM combinecodings cc LEFT JOIN codings c1 ON cc.codingida = c1.rowid LEFT JOIN codings c2 ON cc.codingidb = c2.rowid LEFT JOIN codings c3 ON cc.codingidc = c3.rowid " &
                                "WHERE cc.organizationid = " & Z_OrganizationID & " AND COALESCE(CONCAT(COALESCE(c1.codeno,''),'-',COALESCE(c2.codeno,''),'-',COALESCE(c3.codeno,''),' / ',COALESCE(cc.codename,'')),'') = """ & globaliclassdescription & """ ")
                If dtGid.Rows.Count <> 0 Then
                    globalcombinecodingid = dtGid.Rows(0)(0)
                Else
                    globalcombinecodingid = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getCodingsIDA(ByVal globalicodeno As String, ByVal globalicodetype As String, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalcodingid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM codings WHERE organizationid = " & Z_OrganizationID & " AND codeno = """ & globalicodeno & """ AND codetype = """ & globalicodetype & """ " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globalcodingid = dtGid.Rows(0)(0)
            Else
                globalcodingid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getCodingsIDB(ByVal globalicodings As String, ByVal globalformname As Object)
        Try
            globalcodingid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(co.rowid,0) FROM codings co WHERE co.organizationid = " & Z_OrganizationID & " AND COALESCE(CONCAT(COALESCE(co.codetype,''),' / ',COALESCE(co.codeno,''),' - ',COALESCE(co.codename,'')),'') = """ & globalicodings & """ ")
            If dtGid.Rows.Count <> 0 Then
                globalcodingid = dtGid.Rows(0)(0)
            Else
                globalcodingid = 0
            End If
            If globalcodingid = 0 Then
                dtGid = getDataTableForSQL("SELECT COALESCE(co.rowid,0) FROM codings co WHERE co.organizationid = " & Z_OrganizationID & " AND COALESCE(CONCAT(COALESCE(co.codeno,''),' - ',COALESCE(co.codename,''),' / ',COALESCE(co.codetype,'')),'') = """ & globalicodings & """ ")
                If dtGid.Rows.Count <> 0 Then
                    globalcodingid = dtGid.Rows(0)(0)
                Else
                    globalcodingid = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getCartonSizeIDA(ByVal globalisizename As String, ByVal globalistatuscondition As String, ByVal globalformname As Object)
        Try
            globalcartonsizeid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM cartonsizes WHERE sizename = """ & globalisizename & """ AND organizationid = " & Z_OrganizationID & " " & globalistatuscondition & " ")
            If dtGid.Rows.Count <> 0 Then
                globalcartonsizeid = dtGid.Rows(0)(0)
            Else
                globalcartonsizeid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getCartonSizeIDB(ByVal globalisizeinfo As String, ByVal globalformname As Object)
        Try
            globalcartonsizeid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(cs.rowid,0) FROM cartonsizes cs WHERE COALESCE(CONCAT(COALESCE(cs.sizename,''),' - ', COALESCE(cs.`length`,''),' ', COALESCE(cs.lengthuom,''),'/', COALESCE(cs.`width`,''),' ', COALESCE(cs.widthuom,''),'/', COALESCE(cs.`height`,''),' ', COALESCE(cs.heightuom,''),' - l/w/h'),'') = """ & globalisizeinfo & """ AND cs.organizationid = " & Z_OrganizationID & " ")
            If dtGid.Rows.Count <> 0 Then
                globalcartonsizeid = dtGid.Rows(0)(0)
            Else
                globalcartonsizeid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getListOfValuesID(ByVal globalilic As String, ByVal globalitype As String, ByVal globalformname As Object)
        Try
            globallistofvaluesid = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM listofvalues WHERE lic = """ & globalilic & """ AND `type` = '" & globalitype & "' ")
            If dtGid.Rows.Count <> 0 Then
                globallistofvaluesid = dtGid.Rows(0)(0)
            Else
                globallistofvaluesid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getCycleCountNo(ByVal globalformname As Object)
        Try
            globalcyclecountno = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtGno As New DataTable
            dtGno = getDataTableForSQL("SELECT COALESCE(MAX(cyclecountno),0) FROM cyclecount WHERE organizationid = " & Z_OrganizationID & " ")
            If dtGno.Rows.Count <> 0 Then
                globalcyclecountno = dtGno.Rows(0)(0)
                globalcyclecountno = globalcyclecountno + 1
            Else
                globalcyclecountno = 1
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getTotalQtyAppliedA(ByVal globaliorderitemid As Integer, ByVal globalformname As Object)
        Try
            globaltotalqtyapplied = 0
            If globalconn.State = ConnectionState.Open Then globalconn.Close()
            Dim dtTq As New DataTable
            dtTq = getDataTableForSQL("SELECT COALESCE(SUM(ro.qtyapplied),0) FROM rscorderitems ro WHERE ro.organizationid = " & Z_OrganizationID & " AND ro.orderitemsid = " & globaliorderitemid & " AND ro.`status` = 'Active' ")
            If dtTq.Rows.Count <> 0 Then
                globaltotalqtyapplied = dtTq.Rows(0)(0)
            Else
                globaltotalqtyapplied = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        Finally
            globalconn.Close()
        End Try
    End Sub

    Sub getOrderItemIDA(ByVal globaliorderid As Integer, ByVal globaliproductcolorsizeid As Integer, ByVal globalformname As Object)
        Try
            globalorderitemid = 0
            Dim dtGid As New DataTable
            dtGid = getDataTableForSQL("SELECT COALESCE(rowid,0) FROM orderitems WHERE organizationid = " & Z_OrganizationID & " AND orderid = " & globaliorderid & " AND productcolorsizeid = " & globaliproductcolorsizeid & " AND `status` != 'Inactive' ")
            If dtGid.Rows.Count <> 0 Then
                globalorderitemid = dtGid.Rows(0)(0)
            Else
                globalorderitemid = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

    Sub getPrintOrder(ByVal globaliprintvalue As String, ByVal globalformname As Object)
        Try
            globalprintorder = 0
            Dim dtPO As New DataTable
            dtPO = getDataTableForSQL("SELECT COALESCE(printorder,0) FROM printorder WHERE organizationid = " & Z_OrganizationID & " AND printvalue = """ & globaliprintvalue & """ ")
            If dtPO.Rows.Count <> 0 Then
                globalprintorder = dtPO.Rows(0)(0)
            Else
                globalprintorder = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, globalformname.Name))
        End Try
    End Sub

#End Region

#End Region

    Public Function GetRequiredService(Of T)() As T
        Return MainServiceProvider.GetRequiredService(Of T)
    End Function
End Module