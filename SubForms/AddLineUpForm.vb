Imports Microsoft.Extensions.DependencyInjection
Imports MySql.Data.MySqlClient
Imports WarehouseManagementSystem.Core.Enums
Imports WarehouseManagementSystem.Core.Interfaces
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices

Public Class AddLineUpForm
    Dim manager As New sqlModule.Manager
    Dim conn As New MySqlConnection(manager.GetConnString)
    Dim conn1 As New MySqlConnection(manager.GetConnString)
    Dim sqlcmd As MySqlCommand
    Dim sqlrd As MySqlDataReader
    Dim sqlquery As String
    Dim aludlineupdate, aludorderitemstatus As String
    Dim aluddeliverytruckid, aludlineupcbmid, aludlineupid, aludcontactid As Integer
    Dim aluddeliverytruckcbm, aludlineupboxescbm, aludlineupboxescbmsum, aludtobelineupcbm As Decimal
    Dim aludorderid, aludpackinglistid, aludqtyincartonsum, aluddeliverytruckshiftid, aludtotalqtyincarton As Integer
    Public addlineupdeliverycue As Boolean = False
    Private _agents As List(Of WarehouseManagementSystem.Core.Entities.Contact)
    Private _helpers As List(Of WarehouseManagementSystem.Core.Entities.Contact)
    Private _systemOwner As WarehouseManagementSystem.Core.Entities.SystemOwner

    Private Async Sub AddLineUpForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim _systemOwnerService = GetRequiredService(Of ISystemOwnerService)()
        _systemOwner = Await _systemOwnerService.GetCurrentSystemOwnerEntityAsync()

        If IsThurston Then
            Label16.Visible = False
            txtCBM.Visible = False
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            clearfields()
            callAutoComplete()
            callAutoPopulate()
            getLineUpNo(Me)
            txtLineUpNo.Text = globallineupno
            txtStatus.Text = "Lined Up"
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default

        Await GetAgentsAsync()
        Await GetHelpersAsync()

        If IsThurston Then
            For Each comboBox In gbLineUpInformation.Controls.
                OfType(Of Control).
                OfType(Of ComboBox).
                ToArray()

                SetStyleToDropDownList(comboBox)
            Next
        End If

    End Sub

#Region "Functions"

    Sub callAutoComplete()
        globalautocompleteOrderInfoB(cboCustomerOrderInfo, Me)
        globalautocompleteTruckShiftInfo(cboTruckShiftInfo, Me)
        globalautocompleteContactName(cboDriverName, "Driver", Me)
    End Sub

    Sub callAutoPopulate()
        globalautopopulateOrderInfoB(cboCustomerOrderInfo, Me)
        globalautopopulateTruckShiftInfo(cboTruckShiftInfo, Me)
        globalautopopulateContactName(cboDriverName, "Driver", Me)
    End Sub

#Region "Clear/Enable/Visible"

    Sub clearfields()
        Try
            clearLineUpInformation()
            dgCartons.Rows.Clear()
            dgCartonItems.Rows.Clear()
            enableGB(fraud)
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub clearLineUpInformation()
        Try
            txtLineUpNo.Text = ""
            txtStatus.Text = ""
            cboTruckShiftInfo.Text = ""
            txtCBM.Text = ""
            cboDriverName.Text = ""
            txtComments.Text = ""
            cboCustomerOrderInfo.Text = ""
            txtPONo.Text = ""
            txtCustomerOrderDate.Text = ""
            txtReceiptDate.Text = ""
            txtCancelDate.Text = ""
            txtDeliveryAddress.Text = ""
            txtSIDRNo.Text = ""
            txtBranchCodeNameInfo.Text = ""
            txtVendorCodeNameInfo.Text = ""
            txtClassDescription.Text = ""
            txtDeliveryHours.Text = ""
            cboTruckShiftInfo.SelectedItem = Nothing
            cboDriverName.SelectedItem = Nothing
            cboCustomerOrderInfo.SelectedItem = Nothing
            dtpLineUpDate.Value = Now.Date
            txtQtyInCartonSum.Text = ""
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub enableGB(ByVal enable1 As Boolean)
        Try
            gbCartons.Enabled = enable1
            gbCartonItems.Enabled = enable1
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Computations"

    Sub getTotalQtyInCarton(ByVal epackinglistid As Integer, ByVal eorderitemid As Integer)
        Try
            aludtotalqtyincarton = 0
            Dim dtGtq As New DataTable
            dtGtq = getDataTableForSQL("SELECT COALESCE(SUM(pci.qtyincarton),0) FROM packinglistcartonitems pci LEFT JOIN packinglistcartons pc ON pci.packinglistcartonid = pc.rowid WHERE pc.packinglistid = " & epackinglistid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' AND pci.orderitemid = " & eorderitemid & " ")
            If dtGtq.Rows.Count <> 0 Then
                aludtotalqtyincarton = dtGtq.Rows(0)(0)
            Else
                aludtotalqtyincarton = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getDeliveryTruckCBM(ByVal edeliverytruckid As Integer)
        Try
            aluddeliverytruckcbm = 0
            Dim dtGcbm As New DataTable
            dtGcbm = getDataTableForSQL("SELECT COALESCE(dt.cbm,0) FROM deliverytrucks dt WHERE dt.rowid = " & edeliverytruckid & " ")
            If dtGcbm.Rows.Count <> 0 Then
                aluddeliverytruckcbm = dtGcbm.Rows(0)(0)
            Else
                aluddeliverytruckcbm = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub getLineUpID(ByVal edeliverytruckshiftid As Integer, ByVal edeliverydate As String)
        Try
            aludlineupboxescbmsum = 0.0
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT rowid FROM lineups WHERE deliverytruckshiftid = " & edeliverytruckshiftid & " AND lineupdate = """ & edeliverydate & """ AND organizationid = " & Z_OrganizationID & " "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    getLineUpBoxesCBM(CInt(reader1(0)))
                    aludlineupboxescbmsum = aludlineupboxescbmsum + aludlineupboxescbm
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub getLineUpBoxesCBM(ByVal ilineupid As Integer)
        Try
            aludlineupboxescbm = 0
            Dim dtGcbm As New DataTable
            dtGcbm = getDataTableForSQL("SELECT COALESCE(SUM(luc.cbm),0.0) FROM lineupcartons luc WHERE luc.lineupid = " & ilineupid & " AND luc.`status` != 'Inactive' AND luc.organizationid = " & Z_OrganizationID & " ")
            If dtGcbm.Rows.Count <> 0 Then
                aludlineupboxescbm = dtGcbm.Rows(0)(0)
            Else
                aludlineupboxescbm = 0
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Sub addlineupdeliverycomputations()
        Try
            aludqtyincartonsum = 0
            If dgCartonItems.Rows.Count <> 0 Then
                For i = 0 To dgCartonItems.Rows.Count - 1
                    If IsNumeric(dgCartonItems.Rows(i).Cells("cai_qtyincarton").Value) Then
                        aludqtyincartonsum = aludqtyincartonsum + CInt(dgCartonItems.Rows(i).Cells("cai_qtyincarton").Value)
                    End If
                Next
            End If
            txtQtyInCartonSum.Text = Format(aludqtyincartonsum, "#,##0")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub cbmcomputation(ByVal ideliverytruckid As Integer, ByVal ideliverytruckshiftid As Integer, ByVal ideliverydate As String)
        Try
            getLineUpCBMID(ideliverytruckshiftid, ideliverydate, Me)
            aludlineupcbmid = globallineupcbmid
            If aludlineupcbmid = 0 Then
                getDeliveryTruckCBM(ideliverytruckid)
            Else
                aluddeliverytruckcbm = globalcbm
            End If
            getLineUpID(ideliverytruckshiftid, ideliverydate)
            aludtobelineupcbm = 0
            If dgCartons.Rows.Count <> 0 Then
                For i = 0 To dgCartons.Rows.Count - 1
                    If dgCartons.Rows(i).Cells("ca_lineup").Value = legit Then
                        If IsNumeric(dgCartons.Rows(i).Cells("ca_cbm").Value) Then
                            aludtobelineupcbm = aludtobelineupcbm + CDec(dgCartons.Rows(i).Cells("ca_cbm").Value)
                        End If
                    End If
                Next
            End If
            txtCBM.Text = Format(aluddeliverytruckcbm - (aludlineupboxescbmsum + aludtobelineupcbm), "#,##0")
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

#End Region

#Region "Display"

#Region "Datagrids"

    Sub displayPackingListCartons(ByVal ipackinglistid As Integer)
        Try
            dgCartons.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pc.rowid,COALESCE(pc.cartonno,''),COALESCE(CONCAT(COALESCE(c.firstname,''),' ',COALESCE(c.middlename,''),' ',COALESCE(c.lastname,''),' ',COALESCE(c.suffix,''),' - ',COALESCE(c.contactno,'')),''),COALESCE(DATE_FORMAT(pc.packeddate,'%d-%b-%Y'),''),COALESCE(pc.`status`,''),COALESCE(cs.sizename,'')," &
                        $"COALESCE(cs.`length`,0),COALESCE(cs.`width`,0),COALESCE(cs.`height`,0) FROM packinglistcartons pc LEFT JOIN contacts c ON pc.contactid = c.rowid LEFT JOIN cartonsizes cs ON pc.cartonsizeid = cs.rowid {If(IsThurston, $"INNER JOIN packinglist pl ON pl.RowID=pc.PackingListID INNER JOIN orders o ON o.RowID=pl.OrderID AND LOCATE(CONCAT_WS(' ', o.OrderNumber, '(C.O. No.)'), '{cboCustomerOrderInfo.Text.Trim()}') > 0", String.Empty)} WHERE {If(IsThurston, "IFNULL(pc.Amount, 0) > 0 AND ", $"pc.packinglistid = {ipackinglistid} AND ")}pc.organizationid = " & Z_OrganizationID & " AND pc.`status` != 'Inactive' ORDER BY pc.cartonno "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgCartons.Rows.Add()
                    dgCartons.Item(ca_seqno.Index, n).Value = seqno
                    dgCartons.Item(ca_lineup.Index, n).Value = fraud
                    dgCartons.Item(ca_rowid.Index, n).Value = reader1(0)
                    dgCartons.Item(ca_cartonno.Index, n).Value = reader1(1)
                    dgCartons.Item(ca_packername.Index, n).Value = reader1(2)
                    dgCartons.Item(ca_packeddate.Index, n).Value = reader1(3)
                    dgCartons.Item(ca_status.Index, n).Value = reader1(4)
                    dgCartons.Item(ca_sizename.Index, n).Value = reader1(5)
                    dgCartons.Item(ca_cbm.Index, n).Value = Math.Round((CDec(reader1(6)) / 1000) * (CDec(reader1(7)) / 1000) * (CDec(reader1(8)) / 1000), 2)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCartons.Columns("ca_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_cartonno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_cbm").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_sizename").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_packeddate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartons.Columns("ca_lineup").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCartons.Rows.Count <> 0 Then
                dgCartons.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Sub displayPackingListCartonItems(ByVal ipackinglistcartonid As Integer)
        Try
            dgCartonItems.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pci.rowid,COALESCE(c.colorvalue,''),COALESCE(p.productcode,''),COALESCE(c.colorname,''),COALESCE(pcs.size,''),COALESCE(pcs.seasoncode,''),COALESCE(pci.qtyincarton,0),COALESCE(pcs.sku,''),COALESCE(oi.unitofmeasure,''),COALESCE(oi.itemtype,''),COALESCE(oi.sku,'') " &
                    "FROM packinglistcartonitems pci LEFT JOIN orderitems oi ON pci.orderitemid = oi.rowid LEFT JOIN productcolorsizes pcs ON oi.productcolorsizeid = pcs.rowid LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid LEFT JOIN colors c ON pc.colorid = c.rowid " &
                    "LEFT JOIN products p ON pc.productid = p.rowid WHERE pci.packinglistcartonid = " & ipackinglistcartonid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.status != 'Inactive' ORDER BY p.productcode,c.colorname,pcs.size "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            Dim n As Integer = 0
            Dim seqno As Integer = 1
            While reader1.Read()
                If reader1.HasRows Then
                    dgCartonItems.Rows.Add()
                    dgCartonItems.Item(cai_seqno.Index, n).Value = seqno
                    dgCartonItems.Item(cai_rowid.Index, n).Value = reader1(0)
                    dgCartonItems.Item(cai_colorvalue.Index, n).Value = reader1(1)
                    dgCartonItems.Item(cai_productcode.Index, n).Value = reader1(2)
                    dgCartonItems.Item(cai_colorname.Index, n).Value = reader1(3)
                    dgCartonItems.Item(cai_color.Index, n).Value = ""
                    dgCartonItems.Item(cai_size.Index, n).Value = reader1(4)
                    dgCartonItems.Item(cai_seasoncode.Index, n).Value = reader1(5)
                    dgCartonItems.Item(cai_qtyincarton.Index, n).Value = reader1(6)
                    If LTrim(CStr(reader1(10))) = "" Then
                        dgCartonItems.Item(cai_sku.Index, n).Value = reader1(7)
                    Else
                        dgCartonItems.Item(cai_sku.Index, n).Value = reader1(10)
                    End If
                    dgCartonItems.Item(cai_unitofmeasure.Index, n).Value = reader1(8)
                    dgCartonItems.Item(cai_type.Index, n).Value = reader1(9)
                    seqno = seqno + 1
                    n = n + 1
                End If
            End While
            reader1.Close()
            dgCartonItems.Columns("cai_seqno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_productcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_colorname").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_seasoncode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_qtyincarton").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_sku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_unitofmeasure").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgCartonItems.Columns("cai_type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If dgCartonItems.Rows.Count <> 0 Then
                dgCartonItems.CurrentRow.Selected = False
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Colors"

    Sub colorCoding()
        Try
            If dgCartonItems.Rows.Count <> 0 Then
                For i As Integer = 0 To dgCartonItems.Rows.Count - 1
                    If CStr(dgCartonItems.Rows(i).Cells("cai_colorvalue").Value) <> "" Then
                        readcolor = colorconverter.ConvertFromString(CStr(dgCartonItems.Rows(i).Cells("cai_colorvalue").Value))
                        dgCartonItems.Rows(i).Cells("cai_color").Style.BackColor = readcolor
                    End If
                    If dgCartonItems.Rows(i).Cells(cai_type.Index).Value = "BI" Then
                        dgCartonItems.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#End Region

#Region "Saving"

    Sub updatePackingListCartonItems(ByVal ipackinglistcartonid As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim sql1 As String = "SELECT pci.rowid,pci.orderitemid,COALESCE(pci.qtyincarton,0),COALESCE(oi.qtyordered,0),COALESCE(oi.`status`,'') FROM packinglistcartonitems pci LEFT JOIN orderitems oi ON pci.orderitemid = oi.rowid WHERE pci.packinglistcartonid = " & ipackinglistcartonid & " AND pci.organizationid = " & Z_OrganizationID & " AND pci.`status` != 'Inactive' "
            Dim cmd1 As New MySqlCommand(sql1, conn)
            Dim reader1 As MySqlDataReader = cmd1.ExecuteReader
            While reader1.Read()
                If reader1.HasRows Then
                    U_PackingListCartonItemStatus(CInt(reader1(0)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Lined Up", Me)
                    getTotalQtyInCarton(aludpackinglistid, CInt(reader1(1)))
                    If aludtotalqtyincarton < CInt(reader1(3)) Then
                        aludorderitemstatus = "Partially Lined Up"
                    Else
                        aludorderitemstatus = "Lined Up"
                    End If
                    U_OrderItemStatus(CInt(reader1(1)), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, aludorderitemstatus, Me)
                End If
            End While
            reader1.Close()
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

    Private Async Function GetAgentsAsync() As Task
        Dim contactDataService = GetRequiredService(Of IContactDataService)()

        _agents = Await contactDataService.GetAgentsAsync(organizationId:=Z_OrganizationID)

        Dim agentDataSource = New List(Of WarehouseManagementSystem.Core.Entities.Contact) From {WarehouseManagementSystem.Core.Entities.Contact.NewContact(organizationId:=Z_OrganizationID, lastName:=String.Empty, firstName:=String.Empty, workPhone:=String.Empty, type:=ContactType.Agent)}
        agentDataSource.AddRange(_agents)
        cboAgent.ValueMember = "RowID"
        cboAgent.DisplayMember = "FullNameLastNameFirst"
        cboAgent.DataSource = agentDataSource.OrderBy(Function(a) a.FullNameLastNameFirst).ToList()

    End Function

    Private Async Function GetHelpersAsync() As Task
        Dim contactDataService = GetRequiredService(Of IContactDataService)()

        _helpers = Await contactDataService.GetHelpersAsync(organizationId:=Z_OrganizationID)

        Dim helperDataSource = New List(Of WarehouseManagementSystem.Core.Entities.Contact) From {WarehouseManagementSystem.Core.Entities.Contact.NewContact(organizationId:=Z_OrganizationID, lastName:=String.Empty, firstName:=String.Empty, workPhone:=String.Empty, type:=ContactType.Driver)}
        helperDataSource.AddRange(_helpers)

        cboHelper1.ValueMember = "RowID"
        cboHelper1.DisplayMember = "FullNameLastNameFirst"
        cboHelper1.DataSource = helperDataSource.OrderBy(Function(h) h.FullNameLastNameFirst).ToList()

        cboHelper2.ValueMember = "RowID"
        cboHelper2.DisplayMember = "FullNameLastNameFirst"
        cboHelper2.BindingContext = New BindingContext()
        cboHelper2.DataSource = helperDataSource.OrderBy(Function(h) h.FullNameLastNameFirst).ToList()

    End Function

#End Region

    'Private Sub cboCustomerOrderInfo_Leave(sender As Object, e As EventArgs) Handles cboCustomerOrderInfo.Leave
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If LTrim(cboCustomerOrderInfo.Text) <> "" Then
    '            getOrderIDD(cboCustomerOrderInfo.Text, Me)
    '            aludpackinglistid = globalpackinglistid : aludorderid = globalorderid
    '            If aludpackinglistid <> 0 Then
    '                getOrderInfo(aludorderid, Me)
    '                txtPONo.Text = globalorderpono
    '                txtCustomerOrderDate.Text = globalorderdate
    '                txtReceiptDate.Text = globaltargetdate
    '                txtCancelDate.Text = globalordercanceldate
    '                txtDeliveryAddress.Text = globaladdressname
    '                txtSIDRNo.Text = globalordersidrno
    '                txtBranchCodeNameInfo.Text = globalbranchname
    '                txtVendorCodeNameInfo.Text = globalvendorname
    '                txtClassDescription.Text = globalorderclassdescription
    '                txtDeliveryHours.Text = globaldeliveryhours
    '                enableGB(legit) : displayPackingListCartons(aludpackinglistid)
    '                dgCartonItems.Rows.Clear() : addlineupdeliverycomputations()
    '            Else
    '                txtPONo.Text = ""
    '                txtCustomerOrderDate.Text = ""
    '                txtReceiptDate.Text = ""
    '                txtCancelDate.Text = ""
    '                txtDeliveryAddress.Text = ""
    '                txtSIDRNo.Text = ""
    '                txtBranchCodeNameInfo.Text = ""
    '                txtVendorCodeNameInfo.Text = ""
    '                txtClassDescription.Text = ""
    '                txtDeliveryHours.Text = ""
    '                enableGB(fraud) : dgCartons.Rows.Clear()
    '                txtQtyInCartonSum.Text = "" : dgCartonItems.Rows.Clear()
    '            End If
    '            If LTrim(cboTruckShiftInfo.Text) <> "" Then
    '                If aludpackinglistid = 0 Then
    '                    errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
    '                Else
    '                    getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
    '                    aluddeliverytruckshiftid = globaldeliverytruckshiftid
    '                    aluddeliverytruckid = globaldeliverytruckid
    '                    If aluddeliverytruckshiftid <> 0 Then
    '                        aludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
    '                        cbmcomputation(aluddeliverytruckid, aluddeliverytruckshiftid, aludlineupdate)
    '                        If aluddeliverytruckcbm - (aludlineupboxescbmsum + aludtobelineupcbm) < neutralpage Then
    '                            errProvider.SetError(txtCBM, "System detected that the truck is full already.")
    '                        End If
    '                        getLineUpIDA(aluddeliverytruckshiftid, aludorderid, aludlineupdate, Me)
    '                        aludlineupid = globallineupid
    '                        If aludlineupid <> 0 Then
    '                            errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
    '                            errProvider.SetError(cboCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
    '                            errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
    '                        End If
    '                    Else
    '                        errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
    '                    End If
    '                End If
    '            End If
    '        Else
    '            txtPONo.Text = ""
    '            txtCustomerOrderDate.Text = ""
    '            txtReceiptDate.Text = ""
    '            txtCancelDate.Text = ""
    '            txtDeliveryAddress.Text = ""
    '            txtSIDRNo.Text = ""
    '            txtBranchCodeNameInfo.Text = ""
    '            txtVendorCodeNameInfo.Text = ""
    '            txtClassDescription.Text = ""
    '            txtDeliveryHours.Text = ""
    '            enableGB(fraud) : dgCartons.Rows.Clear()
    '            txtQtyInCartonSum.Text = "" : dgCartonItems.Rows.Clear()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(getErrExcptn(ex, Me.Name))
    '    Finally
    '        conn.Close()
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    Private Sub cboCustomerOrderInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomerOrderInfo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                getOrderIDD(cboCustomerOrderInfo.Text, Me)
                aludpackinglistid = globalpackinglistid : aludorderid = globalorderid
                If aludpackinglistid <> 0 Then
                    getOrderInfo(aludorderid, Me)
                    txtPONo.Text = globalorderpono
                    txtCustomerOrderDate.Text = globalorderdate
                    txtReceiptDate.Text = globaltargetdate
                    txtCancelDate.Text = globalordercanceldate
                    txtDeliveryAddress.Text = globaladdressname
                    txtSIDRNo.Text = globalordersidrno
                    txtBranchCodeNameInfo.Text = globalbranchname
                    txtVendorCodeNameInfo.Text = globalvendorname
                    txtClassDescription.Text = globalorderclassdescription
                    txtDeliveryHours.Text = globaldeliveryhours
                    enableGB(legit) : displayPackingListCartons(aludpackinglistid)
                    dgCartonItems.Rows.Clear() : addlineupdeliverycomputations()
                Else
                    txtPONo.Text = ""
                    txtCustomerOrderDate.Text = ""
                    txtReceiptDate.Text = ""
                    txtCancelDate.Text = ""
                    txtDeliveryAddress.Text = ""
                    txtSIDRNo.Text = ""
                    txtBranchCodeNameInfo.Text = ""
                    txtVendorCodeNameInfo.Text = ""
                    txtClassDescription.Text = ""
                    txtDeliveryHours.Text = ""
                    enableGB(fraud) : dgCartons.Rows.Clear()
                    txtQtyInCartonSum.Text = "" : dgCartonItems.Rows.Clear()
                End If
                If LTrim(cboTruckShiftInfo.Text) <> "" Then
                    If aludpackinglistid = 0 Then
                        errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                    Else
                        getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                        aluddeliverytruckshiftid = globaldeliverytruckshiftid
                        aluddeliverytruckid = globaldeliverytruckid
                        If aluddeliverytruckshiftid <> 0 Then
                            aludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                            cbmcomputation(aluddeliverytruckid, aluddeliverytruckshiftid, aludlineupdate)
                            If aluddeliverytruckcbm - (aludlineupboxescbmsum + aludtobelineupcbm) < neutralpage Then
                                errProvider.SetError(txtCBM, "System detected that the truck is full already.")
                            End If
                            getLineUpIDA(aluddeliverytruckshiftid, aludorderid, aludlineupdate, Me)
                            aludlineupid = globallineupid
                            If aludlineupid <> 0 Then
                                errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                                errProvider.SetError(cboCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                                errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                            End If
                        Else
                            errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
                        End If
                    End If
                End If
            Else
                txtPONo.Text = ""
                txtCustomerOrderDate.Text = ""
                txtReceiptDate.Text = ""
                txtCancelDate.Text = ""
                txtDeliveryAddress.Text = ""
                txtSIDRNo.Text = ""
                txtBranchCodeNameInfo.Text = ""
                txtVendorCodeNameInfo.Text = ""
                txtClassDescription.Text = ""
                txtDeliveryHours.Text = ""
                enableGB(fraud) : dgCartons.Rows.Clear()
                txtQtyInCartonSum.Text = "" : dgCartonItems.Rows.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboCustomerOrderInfo_TextChanged(sender As Object, e As EventArgs) Handles cboCustomerOrderInfo.TextChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                getOrderIDD(cboCustomerOrderInfo.Text, Me)
                aludpackinglistid = globalpackinglistid : aludorderid = globalorderid
                If aludpackinglistid <> 0 Then
                    getOrderInfo(aludorderid, Me)
                    txtPONo.Text = globalorderpono
                    txtCustomerOrderDate.Text = globalorderdate
                    txtReceiptDate.Text = globaltargetdate
                    txtCancelDate.Text = globalordercanceldate
                    txtDeliveryAddress.Text = globaladdressname
                    txtSIDRNo.Text = globalordersidrno
                    txtBranchCodeNameInfo.Text = globalbranchname
                    txtVendorCodeNameInfo.Text = globalvendorname
                    txtClassDescription.Text = globalorderclassdescription
                    txtDeliveryHours.Text = globaldeliveryhours
                    enableGB(legit) : displayPackingListCartons(aludpackinglistid)
                    dgCartonItems.Rows.Clear() : addlineupdeliverycomputations()
                Else
                    txtPONo.Text = ""
                    txtCustomerOrderDate.Text = ""
                    txtReceiptDate.Text = ""
                    txtCancelDate.Text = ""
                    txtDeliveryAddress.Text = ""
                    txtSIDRNo.Text = ""
                    txtBranchCodeNameInfo.Text = ""
                    txtVendorCodeNameInfo.Text = ""
                    txtClassDescription.Text = ""
                    txtDeliveryHours.Text = ""
                    enableGB(fraud) : dgCartons.Rows.Clear()
                    txtQtyInCartonSum.Text = "" : dgCartonItems.Rows.Clear()
                End If
                If LTrim(cboTruckShiftInfo.Text) <> "" Then
                    If aludpackinglistid = 0 Then
                        errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                    Else
                        getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                        aluddeliverytruckshiftid = globaldeliverytruckshiftid
                        aluddeliverytruckid = globaldeliverytruckid
                        If aluddeliverytruckshiftid <> 0 Then
                            aludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                            cbmcomputation(aluddeliverytruckid, aluddeliverytruckshiftid, aludlineupdate)
                            If aluddeliverytruckcbm - (aludlineupboxescbmsum + aludtobelineupcbm) < neutralpage Then
                                errProvider.SetError(txtCBM, "System detected that the truck is full already.")
                            End If
                            getLineUpIDA(aluddeliverytruckshiftid, aludorderid, aludlineupdate, Me)
                            aludlineupid = globallineupid
                            If aludlineupid <> 0 Then
                                errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                                errProvider.SetError(cboCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                                errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                            End If
                        Else
                            errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
                        End If
                    End If
                End If
            Else
                txtPONo.Text = ""
                txtCustomerOrderDate.Text = ""
                txtReceiptDate.Text = ""
                txtCancelDate.Text = ""
                txtDeliveryAddress.Text = ""
                txtSIDRNo.Text = ""
                txtBranchCodeNameInfo.Text = ""
                txtVendorCodeNameInfo.Text = ""
                txtClassDescription.Text = ""
                txtDeliveryHours.Text = ""
                enableGB(fraud) : dgCartons.Rows.Clear()
                txtQtyInCartonSum.Text = "" : dgCartonItems.Rows.Clear()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub cboTruckShiftInfo_Leave(sender As Object, e As EventArgs) Handles cboTruckShiftInfo.Leave
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        errProvider.Clear()
    '        If LTrim(cboCustomerOrderInfo.Text) <> "" Then
    '            getOrderIDD(cboCustomerOrderInfo.Text, Me)
    '            aludpackinglistid = globalpackinglistid : aludorderid = globalorderid
    '            If LTrim(cboTruckShiftInfo.Text) <> "" Then
    '                If aludpackinglistid = 0 Then
    '                    errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
    '                Else
    '                    getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
    '                    aluddeliverytruckshiftid = globaldeliverytruckshiftid
    '                    aluddeliverytruckid = globaldeliverytruckid
    '                    If aluddeliverytruckshiftid <> 0 Then
    '                        aludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
    '                        cbmcomputation(aluddeliverytruckid, aluddeliverytruckshiftid, aludlineupdate)
    '                        If aluddeliverytruckcbm - (aludlineupboxescbmsum + aludtobelineupcbm) < neutralpage Then
    '                            errProvider.SetError(txtCBM, "System detected that the truck is full already.")
    '                        End If
    '                        getLineUpIDA(aluddeliverytruckshiftid, aludorderid, aludlineupdate, Me)
    '                        aludlineupid = globallineupid
    '                        If aludlineupid <> 0 Then
    '                            errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
    '                            errProvider.SetError(cboCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
    '                            errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
    '                        End If
    '                    Else
    '                        errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
    '                    End If
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
    Private Sub cboTruckShiftInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTruckShiftInfo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                getOrderIDD(cboCustomerOrderInfo.Text, Me)
                aludpackinglistid = globalpackinglistid : aludorderid = globalorderid
                If LTrim(cboTruckShiftInfo.Text) <> "" Then
                    If aludpackinglistid = 0 Then
                        errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                    Else
                        getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                        aluddeliverytruckshiftid = globaldeliverytruckshiftid
                        aluddeliverytruckid = globaldeliverytruckid
                        If aluddeliverytruckshiftid <> 0 Then
                            aludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                            cbmcomputation(aluddeliverytruckid, aluddeliverytruckshiftid, aludlineupdate)
                            If aluddeliverytruckcbm - (aludlineupboxescbmsum + aludtobelineupcbm) < neutralpage Then
                                errProvider.SetError(txtCBM, "System detected that the truck is full already.")
                            End If
                            getLineUpIDA(aluddeliverytruckshiftid, aludorderid, aludlineupdate, Me)
                            aludlineupid = globallineupid
                            If aludlineupid <> 0 Then
                                errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                                errProvider.SetError(cboCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                                errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                            End If
                        Else
                            errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
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

    Private Sub cboTruckShiftInfo_TextChanged(sender As Object, e As EventArgs) Handles cboTruckShiftInfo.TextChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                getOrderIDD(cboCustomerOrderInfo.Text, Me)
                aludpackinglistid = globalpackinglistid : aludorderid = globalorderid
                If LTrim(cboTruckShiftInfo.Text) <> "" Then
                    If aludpackinglistid = 0 Then
                        errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                    Else
                        getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                        aluddeliverytruckshiftid = globaldeliverytruckshiftid
                        aluddeliverytruckid = globaldeliverytruckid
                        If aluddeliverytruckshiftid <> 0 Then
                            aludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                            cbmcomputation(aluddeliverytruckid, aluddeliverytruckshiftid, aludlineupdate)
                            If aluddeliverytruckcbm - (aludlineupboxescbmsum + aludtobelineupcbm) < neutralpage Then
                                errProvider.SetError(txtCBM, "System detected that the truck is full already.")
                            End If
                            getLineUpIDA(aluddeliverytruckshiftid, aludorderid, aludlineupdate, Me)
                            aludlineupid = globallineupid
                            If aludlineupid <> 0 Then
                                errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                                errProvider.SetError(cboCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                                errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                            End If
                        Else
                            errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
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

    Private Sub dtpLineUpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpLineUpDate.ValueChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                getOrderIDD(cboCustomerOrderInfo.Text, Me)
                aludpackinglistid = globalpackinglistid : aludorderid = globalorderid
                If LTrim(cboTruckShiftInfo.Text) <> "" Then
                    If aludpackinglistid = 0 Then
                        errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                    Else
                        getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                        aluddeliverytruckshiftid = globaldeliverytruckshiftid
                        aluddeliverytruckid = globaldeliverytruckid
                        If aluddeliverytruckshiftid <> 0 Then
                            aludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                            cbmcomputation(aluddeliverytruckid, aluddeliverytruckshiftid, aludlineupdate)
                            If aluddeliverytruckcbm - (aludlineupboxescbmsum + aludtobelineupcbm) < neutralpage Then
                                errProvider.SetError(txtCBM, "System detected that the truck is full already.")
                            End If
                            getLineUpIDA(aluddeliverytruckshiftid, aludorderid, aludlineupdate, Me)
                            aludlineupid = globallineupid
                            If aludlineupid <> 0 Then
                                errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                                errProvider.SetError(cboCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                                errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                            End If
                        Else
                            errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
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

    Private Sub pbAddTruckShiftInfo_MouseEnter(sender As Object, e As EventArgs) Handles pbAddTruckShiftInfo.MouseEnter
        Try
            pbAddTruckShiftInfo.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddTruckShiftInfo_MouseLeave(sender As Object, e As EventArgs) Handles pbAddTruckShiftInfo.MouseLeave
        Try
            pbAddTruckShiftInfo.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddDriver_MouseEnter(sender As Object, e As EventArgs) Handles pbAddDriver.MouseEnter
        Try
            pbAddDriver.BackColor = Color.MediumSpringGreen
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub pbAddDriver_MouseLeave(sender As Object, e As EventArgs) Handles pbAddDriver.MouseLeave
        Try
            pbAddDriver.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

    Private Async Sub pbAddTruckShiftInfo_Click(sender As Object, e As EventArgs) Handles pbAddTruckShiftInfo.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Line-Up And Delivery", Me)
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

            If IsThurston Then
                Dim form As New AddTruckForm
                If form.ShowDialog() = DialogResult.OK Then
                    Dim truckId = form.TruckId

                    Using cmd As New MySqlCommand(commandText:=$"INSERT INTO `deliverytruckshifts` (`OrganizationID`, `Created`, `CreatedBy`, `LastUpd`, `LastUpdBy`, `DeliveryTruckID`, `ShiftID`, `Status`) VALUES ({Z_OrganizationID}, CURRENT_TIMESTAMP(), 1, CURRENT_TIMESTAMP(), 1, {truckId}, 1, 'Active');
") _
                        With {.Connection = connection}
                        If cmd.Connection.State = ConnectionState.Closed Then Await cmd.Connection.OpenAsync()
                        Await cmd.ExecuteNonQueryAsync()
                    End Using

                    globalautocompleteTruckShiftInfo(cboTruckShiftInfo, Me)
                    globalautopopulateTruckShiftInfo(cboTruckShiftInfo, Me)
                End If
            Else
                Dim addtruckshiftlinkform As New AddTruckShiftForm
                addtruckshiftlinkform.ShowInTaskbar = False
                addtruckshiftlinkform.ShowDialog()
                If addtruckshiftlinkform.addtruckshiftcue = legit Then
                    globalautocompleteTruckShiftInfo(cboTruckShiftInfo, Me)
                    globalautopopulateTruckShiftInfo(cboTruckShiftInfo, Me)
                    addlineupdeliverycue = legit
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbAddDriver_Click(sender As Object, e As EventArgs) Handles pbAddDriver.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Line-Up And Delivery", Me)
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
            Dim adddriverlinkform As New AddDriverForm
            adddriverlinkform.ShowInTaskbar = False
            adddriverlinkform.ShowDialog()
            If adddriverlinkform.adddriverformcue = legit Then
                globalautocompleteContactName(cboDriverName, "Driver", Me)
                globalautopopulateContactName(cboDriverName, "Driver", Me)
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCartons_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCartons.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCartons.Rows.Count <> 0 Then
                displayPackingListCartonItems(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value))
                colorCoding() : addlineupdeliverycomputations()
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCartons_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgCartons.CellEndEdit
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            If aluddeliverytruckshiftid <> 0 Then
                aludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                cbmcomputation(aluddeliverytruckid, aluddeliverytruckshiftid, aludlineupdate)
                If aluddeliverytruckcbm - (aludlineupboxescbmsum + aludtobelineupcbm) < neutralpage Then
                    errProvider.SetError(txtCBM, "System detected that the truck is full already.")
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCartons_KeyUp(sender As Object, e As KeyEventArgs) Handles dgCartons.KeyUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgCartons.Rows.Count <> 0 Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                    displayPackingListCartonItems(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value))
                    colorCoding() : addlineupdeliverycomputations()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCartons_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgCartons.CurrentCellDirtyStateChanged
        Try
            If dgCartons.IsCurrentCellDirty = legit Then
                getPackingListCartonStatus(CInt(dgCartons.CurrentRow.Cells("ca_rowid").Value), Me)
                If globalpackinglistcartonstatus <> "Active" Then
                    dgCartons.CancelEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        End Try
    End Sub

    Private Sub msSave_Click(sender As Object, e As EventArgs) Handles msSave.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            errProvider.Clear()
            dgCartons.CommitEdit(legit) : dgCartons.ClearSelection() : dgCartons.CurrentCell = Nothing
            getPositionID(Me)
            If globalpositionid <> 0 Then
                getPositionView(globalpositionid, "Line-Up And Delivery", Me)
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
            If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                getOrderIDD(cboCustomerOrderInfo.Text, Me)
                aludpackinglistid = globalpackinglistid : aludorderid = globalorderid
                If LTrim(cboTruckShiftInfo.Text) <> "" Then
                    If aludpackinglistid = 0 Then
                        errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                        Exit Try
                    Else
                        getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                        aluddeliverytruckshiftid = globaldeliverytruckshiftid
                        aluddeliverytruckid = globaldeliverytruckid
                        If aluddeliverytruckshiftid <> 0 Then
                            aludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                            cbmcomputation(aluddeliverytruckid, aluddeliverytruckshiftid, aludlineupdate)
                            If aluddeliverytruckcbm - (aludlineupboxescbmsum + aludtobelineupcbm) < neutralpage Then
                                errProvider.SetError(txtCBM, "System detected that the truck is full already.")
                            End If
                            getLineUpIDA(aluddeliverytruckshiftid, aludorderid, aludlineupdate, Me)
                            aludlineupid = globallineupid
                            If aludlineupid <> 0 Then
                                errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                                errProvider.SetError(cboCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                                errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                                Exit Try
                            End If
                        Else
                            errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
                            Exit Try
                        End If
                    End If
                Else
                    errProvider.SetError(pbAddTruckShiftInfo, "Please choose the truck shift info.")
                    Exit Try
                End If
            Else
                errProvider.SetError(cboCustomerOrderInfo, "Please choose the customer order info.")
                Exit Try
            End If
            myModule.systemerrorfound = False
            If MessageBox.Show("Would you like to save the changes in this page?", "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If LTrim(cboCustomerOrderInfo.Text) <> "" Then
                    getOrderIDD(cboCustomerOrderInfo.Text, Me)
                    aludpackinglistid = globalpackinglistid : aludorderid = globalorderid
                    If LTrim(cboTruckShiftInfo.Text) <> "" Then
                        If aludpackinglistid = 0 Then
                            errProvider.SetError(cboCustomerOrderInfo, "System cannot find the customer order.")
                            Exit Try
                        Else
                            getDeliveryTruckShiftIDB(cboTruckShiftInfo.Text, "AND dts.`status` = 'Active'", Me)
                            aluddeliverytruckshiftid = globaldeliverytruckshiftid
                            aluddeliverytruckid = globaldeliverytruckid
                            If aluddeliverytruckshiftid <> 0 Then
                                aludlineupdate = Format(dtpLineUpDate.Value, "yyyy-MM-dd")
                                cbmcomputation(aluddeliverytruckid, aluddeliverytruckshiftid, aludlineupdate)
                                If aluddeliverytruckcbm - (aludlineupboxescbmsum + aludtobelineupcbm) < neutralpage Then
                                    errProvider.SetError(txtCBM, "System detected that the truck is full already.")
                                End If
                                getLineUpIDA(aluddeliverytruckshiftid, aludorderid, aludlineupdate, Me)
                                aludlineupid = globallineupid
                                If aludlineupid <> 0 Then
                                    errProvider.SetError(dtpLineUpDate, "The line-up has been created already, please choose a new combination of line-up.")
                                    errProvider.SetError(cboCustomerOrderInfo, "The line-up has been created already, please choose a new combination of line-up.")
                                    errProvider.SetError(pbAddTruckShiftInfo, "The line-up has been created already, please choose a new combination of line-up.")
                                    Exit Try
                                End If
                            Else
                                errProvider.SetError(pbAddTruckShiftInfo, "System cannot find the track shift info.")
                                Exit Try
                            End If
                        End If
                    Else
                        errProvider.SetError(pbAddTruckShiftInfo, "Please choose the truck shift info.")
                        Exit Try
                    End If
                Else
                    errProvider.SetError(cboCustomerOrderInfo, "Please choose the customer order info.")
                    Exit Try
                End If
                getContactID(cboDriverName.Text, "Driver", Me)
                aludcontactid = globalcontactid
                getLineUpNo(Me)
                If myModule.systemerrorfound = False Then
                    I_LineUps(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, If(aludcontactid = 0, DBNull.Value, aludcontactid), aludpackinglistid, aluddeliverytruckshiftid, aludorderid, dtpLineUpDate.Value, txtDeliveryHours.Text, globallineupno, txtSIDRNo.Text, txtStatus.Text, txtComments.Text, txtDeliveryAddress.Text, Me,
                        AgentId:=cboAgent.SelectedValue,
                        Helper1Id:=cboHelper1.SelectedValue,
                        Helper2Id:=cboHelper2.SelectedValue)
                    aludlineupid = globallineupidsp
                    getLineUpCBMID(aluddeliverytruckshiftid, Format(dtpLineUpDate.Value, "yyyy-MM-dd"), Me)
                    aludlineupcbmid = globallineupcbmid
                    If aludlineupcbmid = 0 Then
                        I_LineUpCBM(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, aluddeliverytruckshiftid, dtpLineUpDate.Value, aluddeliverytruckcbm, "Active", Me)
                    End If
                End If
                For a = 0 To dgCartons.Rows.Count - 1
                    If myModule.systemerrorfound = False Then
                        If dgCartons.Rows(a).Cells("ca_lineup").Value = legit Then
                            getPackingListCartonStatus(CInt(dgCartons.Rows(a).Cells("ca_rowid").Value), Me)
                            If globalpackinglistcartonstatus = "Active" Then
                                I_LineUpCartons(Z_OrganizationID, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, Z_UserID, CInt(dgCartons.Rows(a).Cells("ca_rowid").Value), aludlineupid, "Lined Up",
                                            If(IsNumeric(dgCartons.Rows(a).Cells("ca_cbm").Value), CDec(dgCartons.Rows(a).Cells("ca_cbm").Value), 0.0), Me)
                                If myModule.systemerrorfound = False Then
                                    U_PackingListCartonStatus(CInt(dgCartons.Rows(a).Cells("ca_rowid").Value), Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Lined Up", Me)
                                End If
                                If myModule.systemerrorfound = False Then
                                    updatePackingListCartonItems(CInt(dgCartons.Rows(a).Cells("ca_rowid").Value))
                                End If
                            End If
                        End If
                    End If
                Next
                If myModule.systemerrorfound = False Then
                    getOrderStatus(aludorderid, Me)
                    If globalorderstatus = "Packing" Then
                        U_OrderStatus(aludorderid, Date.Now.ToString("yyyy/MM/dd HH:mm:ss"), Z_UserID, "Lined Up", Me)
                    End If
                End If
                If myModule.systemerrorfound = False Then
                    If CInt(txtLineUpNo.Text) <> globallineupno Then
                        MessageBox.Show("Please take note that the Line-Up No. will change from " & txtLineUpNo.Text & " to " & globallineupno & "." & vbNewLine & "Another user used Line-Up No. " & txtLineUpNo.Text & " for its new line-up.", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtLineUpNo.Text = globallineupno
                    End If
                    MessageBox.Show("Successfully Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    addlineupdeliverycue = legit
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

#Region "Datagrid MouseUp"

    Private Sub dgCartons_MouseUp(sender As Object, e As MouseEventArgs) Handles dgCartons.MouseUp
        Try
            Dim hitTestinfo As DataGridView.HitTestInfo
            If e.Button = MouseButtons.Left Then
                hitTestinfo = dgCartons.HitTest(e.X, e.Y)
                If hitTestinfo.Type = DataGridViewHitTestType.Cell Then
                    dgCartons.BeginEdit(True)
                Else
                    dgCartons.EndEdit()
                End If
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region "Datagrid Errors"

    Private Sub dgCartons_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCartons.DataError
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
                dgCartons.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCartonItems_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCartonItems.DataError
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
                dgCartonItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " "
            End If
        Catch ex As Exception
            MsgBox(getErrExcptn(ex, Me.Name))
        Finally
            conn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

    Private Async Sub btnAddAgent_Click(sender As Object, e As EventArgs) Handles btnAddAgent.Click
        Dim form As New AddContactForm(contactType:=ContactType.Agent, True)
        If form.ShowDialog() = DialogResult.OK Then
            Await GetAgentsAsync()
        End If
    End Sub

    Private Async Sub btnAddHelper1_Click(sender As Object, e As EventArgs) Handles btnAddHelper1.Click
        Dim form As New AddContactForm(contactType:=ContactType.Helper, True)
        If form.ShowDialog() = DialogResult.OK Then
            Await GetHelpersAsync()
        End If
    End Sub

    Private Async Sub btnAddHelper2_Click(sender As Object, e As EventArgs) Handles btnAddHelper2.Click
        Dim form As New AddContactForm(contactType:=ContactType.Helper, True)
        If form.ShowDialog() = DialogResult.OK Then
            Await GetHelpersAsync()
        End If
    End Sub

    Private ReadOnly Property IsThurston As Boolean
        Get
            Return _systemOwner.IsThurston
        End Get
    End Property
End Class