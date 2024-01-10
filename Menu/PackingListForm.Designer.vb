<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PackingListForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PackingListForm))
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalQtyPicked = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgCustomerOrderItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ci_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_pcsrowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_bid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_itemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtyordered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtypicked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_totalqtyincarton = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.ci_qtytopack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_srp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_totalprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_tags = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_packedby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_packeddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotalItems = New System.Windows.Forms.TextBox()
        Me.gbCustomerOrderItems = New System.Windows.Forms.GroupBox()
        Me.bccBarcode = New Spire.Barcode.Forms.BarCodeControl()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotalPrice = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnAddToCarton = New System.Windows.Forms.Button()
        Me.txtTotalQtyInCartonSum = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lnkViewEditBundleItems = New System.Windows.Forms.LinkLabel()
        Me.chkOtherInfo = New System.Windows.Forms.CheckBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.msNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.msOrder = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.msOutrightA = New System.Windows.Forms.ToolStripMenuItem()
        Me.msOutrightB = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsExtraSmall = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSmall = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMedium = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsLarge = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsExtraLarge = New System.Windows.Forms.ToolStripMenuItem()
        Me.msConsignor = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPackingListNo = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.gbPackingListInformation = New System.Windows.Forms.GroupBox()
        Me.txtClassDescription = New System.Windows.Forms.TextBox()
        Me.txtVendorCodeNameInfo = New System.Windows.Forms.TextBox()
        Me.txtBranchCodeNameInfo = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtCancelDate = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtSIDRNo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPONo = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCustomerOrderDate = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTargetDeliveryDate = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtPackingListDate = New System.Windows.Forms.TextBox()
        Me.cboCustomerOrderInfo = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmdLast = New System.Windows.Forms.ToolStripButton()
        Me.dgPackingList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pal_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pal_packinglistno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pal_packinglistdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pal_customerorderno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pal_customername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pal_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbPackingList = New System.Windows.Forms.GroupBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.cmdFirst = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrev = New System.Windows.Forms.ToolStripButton()
        Me.cmdNext = New System.Windows.Forms.ToolStripButton()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPage = New System.Windows.Forms.TextBox()
        Me.txtPageNo = New System.Windows.Forms.TextBox()
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tabSearch = New System.Windows.Forms.TabControl()
        Me.tabSimple = New System.Windows.Forms.TabPage()
        Me.txtSimpleSearch = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tabCommon = New System.Windows.Forms.TabPage()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.dtpToSearch = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromSearch = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboDate = New System.Windows.Forms.ComboBox()
        Me.cboSearch2 = New System.Windows.Forms.ComboBox()
        Me.cboSearch1 = New System.Windows.Forms.ComboBox()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.gbCartonItems = New System.Windows.Forms.GroupBox()
        Me.txtQtyInCartonSum = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgCartonItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cai_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_qtyincarton = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cai_option = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbCartons = New System.Windows.Forms.GroupBox()
        Me.dgCartons = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ca_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_cartonno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_weight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_packername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_packeddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_option = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.cmsOptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsDelete = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgCustomerOrderItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCustomerOrderItems.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msMenu.SuspendLayout()
        Me.gbPackingListInformation.SuspendLayout()
        CType(Me.dgPackingList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbPackingList.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.tabSimple.SuspendLayout()
        Me.tabCommon.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.gbCartonItems.SuspendLayout()
        CType(Me.dgCartonItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCartons.SuspendLayout()
        CType(Me.dgCartons, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(742, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 26)
        Me.Label8.TabIndex = 463
        Me.Label8.Text = "Total" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Items:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTotalQtyPicked
        '
        Me.txtTotalQtyPicked.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyPicked.Location = New System.Drawing.Point(717, 177)
        Me.txtTotalQtyPicked.Name = "txtTotalQtyPicked"
        Me.txtTotalQtyPicked.ReadOnly = True
        Me.txtTotalQtyPicked.Size = New System.Drawing.Size(90, 21)
        Me.txtTotalQtyPicked.TabIndex = 33
        Me.txtTotalQtyPicked.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(734, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 26)
        Me.Label7.TabIndex = 461
        Me.Label7.Text = "Total Qty." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Picked:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgCustomerOrderItems
        '
        Me.dgCustomerOrderItems.AllowUserToAddRows = False
        Me.dgCustomerOrderItems.AllowUserToDeleteRows = False
        Me.dgCustomerOrderItems.AllowUserToOrderColumns = True
        Me.dgCustomerOrderItems.AllowUserToResizeRows = False
        Me.dgCustomerOrderItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerOrderItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgCustomerOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomerOrderItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ci_rowid, Me.ci_pcsrowid, Me.ci_bid, Me.ci_colorvalue, Me.ci_seqno, Me.ci_itemcode, Me.ci_colorname, Me.ci_color, Me.ci_size, Me.ci_seasoncode, Me.ci_qtyordered, Me.ci_qtypicked, Me.ci_totalqtyincarton, Me.ci_qtytopack, Me.ci_srp, Me.ci_totalprice, Me.ci_status, Me.ci_sku, Me.ci_unitofmeasure, Me.ci_type, Me.ci_remarks, Me.ci_tags, Me.ci_packedby, Me.ci_packeddate})
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCustomerOrderItems.DefaultCellStyle = DataGridViewCellStyle24
        Me.dgCustomerOrderItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCustomerOrderItems.Location = New System.Drawing.Point(10, 17)
        Me.dgCustomerOrderItems.MultiSelect = False
        Me.dgCustomerOrderItems.Name = "dgCustomerOrderItems"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerOrderItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgCustomerOrderItems.RowHeadersVisible = False
        Me.dgCustomerOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCustomerOrderItems.Size = New System.Drawing.Size(695, 220)
        Me.dgCustomerOrderItems.TabIndex = 30
        '
        'ci_rowid
        '
        Me.ci_rowid.HeaderText = "rowid"
        Me.ci_rowid.Name = "ci_rowid"
        Me.ci_rowid.Visible = False
        '
        'ci_pcsrowid
        '
        Me.ci_pcsrowid.HeaderText = "pcsrowid"
        Me.ci_pcsrowid.Name = "ci_pcsrowid"
        Me.ci_pcsrowid.Visible = False
        '
        'ci_bid
        '
        Me.ci_bid.HeaderText = "bid"
        Me.ci_bid.Name = "ci_bid"
        Me.ci_bid.Visible = False
        '
        'ci_colorvalue
        '
        Me.ci_colorvalue.HeaderText = "colorvalue"
        Me.ci_colorvalue.Name = "ci_colorvalue"
        Me.ci_colorvalue.Visible = False
        '
        'ci_seqno
        '
        Me.ci_seqno.HeaderText = "Seq. No."
        Me.ci_seqno.Name = "ci_seqno"
        Me.ci_seqno.ReadOnly = True
        Me.ci_seqno.Width = 40
        '
        'ci_itemcode
        '
        Me.ci_itemcode.HeaderText = "Product Code / Bundle Name"
        Me.ci_itemcode.Name = "ci_itemcode"
        Me.ci_itemcode.ReadOnly = True
        Me.ci_itemcode.Width = 120
        '
        'ci_colorname
        '
        Me.ci_colorname.HeaderText = "Color Name"
        Me.ci_colorname.Name = "ci_colorname"
        Me.ci_colorname.ReadOnly = True
        Me.ci_colorname.Width = 60
        '
        'ci_color
        '
        Me.ci_color.HeaderText = ""
        Me.ci_color.Name = "ci_color"
        Me.ci_color.ReadOnly = True
        Me.ci_color.Width = 30
        '
        'ci_size
        '
        Me.ci_size.HeaderText = "Size"
        Me.ci_size.Name = "ci_size"
        Me.ci_size.ReadOnly = True
        Me.ci_size.Width = 40
        '
        'ci_seasoncode
        '
        Me.ci_seasoncode.HeaderText = "Season Code"
        Me.ci_seasoncode.Name = "ci_seasoncode"
        Me.ci_seasoncode.ReadOnly = True
        Me.ci_seasoncode.Width = 70
        '
        'ci_qtyordered
        '
        Me.ci_qtyordered.HeaderText = "Qty. Ordered"
        Me.ci_qtyordered.Name = "ci_qtyordered"
        Me.ci_qtyordered.ReadOnly = True
        Me.ci_qtyordered.Width = 60
        '
        'ci_qtypicked
        '
        Me.ci_qtypicked.HeaderText = "Qty. Picked"
        Me.ci_qtypicked.Name = "ci_qtypicked"
        Me.ci_qtypicked.ReadOnly = True
        Me.ci_qtypicked.Width = 60
        '
        'ci_totalqtyincarton
        '
        Me.ci_totalqtyincarton.HeaderText = "Total Qty. In Box"
        Me.ci_totalqtyincarton.Name = "ci_totalqtyincarton"
        Me.ci_totalqtyincarton.ReadOnly = True
        Me.ci_totalqtyincarton.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ci_totalqtyincarton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ci_totalqtyincarton.Width = 80
        '
        'ci_qtytopack
        '
        Me.ci_qtytopack.HeaderText = "Qty. To Pack"
        Me.ci_qtytopack.Name = "ci_qtytopack"
        Me.ci_qtytopack.Width = 68
        '
        'ci_srp
        '
        Me.ci_srp.HeaderText = "SRP"
        Me.ci_srp.Name = "ci_srp"
        Me.ci_srp.ReadOnly = True
        Me.ci_srp.Width = 80
        '
        'ci_totalprice
        '
        Me.ci_totalprice.HeaderText = "Total Price"
        Me.ci_totalprice.Name = "ci_totalprice"
        Me.ci_totalprice.ReadOnly = True
        '
        'ci_status
        '
        Me.ci_status.HeaderText = "Status"
        Me.ci_status.Name = "ci_status"
        Me.ci_status.ReadOnly = True
        Me.ci_status.Width = 80
        '
        'ci_sku
        '
        Me.ci_sku.HeaderText = "SKU"
        Me.ci_sku.Name = "ci_sku"
        Me.ci_sku.ReadOnly = True
        '
        'ci_unitofmeasure
        '
        Me.ci_unitofmeasure.HeaderText = "Unit Of Measure"
        Me.ci_unitofmeasure.Name = "ci_unitofmeasure"
        Me.ci_unitofmeasure.ReadOnly = True
        Me.ci_unitofmeasure.Width = 70
        '
        'ci_type
        '
        Me.ci_type.HeaderText = "Type"
        Me.ci_type.Name = "ci_type"
        Me.ci_type.ReadOnly = True
        Me.ci_type.Width = 35
        '
        'ci_remarks
        '
        Me.ci_remarks.HeaderText = "Remarks"
        Me.ci_remarks.Name = "ci_remarks"
        Me.ci_remarks.ReadOnly = True
        '
        'ci_tags
        '
        Me.ci_tags.HeaderText = "Tags"
        Me.ci_tags.Name = "ci_tags"
        Me.ci_tags.ReadOnly = True
        Me.ci_tags.Width = 90
        '
        'ci_packedby
        '
        Me.ci_packedby.HeaderText = "Packed By"
        Me.ci_packedby.Name = "ci_packedby"
        Me.ci_packedby.ReadOnly = True
        '
        'ci_packeddate
        '
        Me.ci_packeddate.HeaderText = "Packed Date"
        Me.ci_packeddate.Name = "ci_packeddate"
        Me.ci_packeddate.ReadOnly = True
        '
        'txtTotalItems
        '
        Me.txtTotalItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalItems.Location = New System.Drawing.Point(717, 124)
        Me.txtTotalItems.Name = "txtTotalItems"
        Me.txtTotalItems.ReadOnly = True
        Me.txtTotalItems.Size = New System.Drawing.Size(90, 21)
        Me.txtTotalItems.TabIndex = 32
        Me.txtTotalItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbCustomerOrderItems
        '
        Me.gbCustomerOrderItems.Controls.Add(Me.bccBarcode)
        Me.gbCustomerOrderItems.Controls.Add(Me.Label17)
        Me.gbCustomerOrderItems.Controls.Add(Me.txtTotalPrice)
        Me.gbCustomerOrderItems.Controls.Add(Me.Label19)
        Me.gbCustomerOrderItems.Controls.Add(Me.btnAddToCarton)
        Me.gbCustomerOrderItems.Controls.Add(Me.txtTotalQtyInCartonSum)
        Me.gbCustomerOrderItems.Controls.Add(Me.Label3)
        Me.gbCustomerOrderItems.Controls.Add(Me.dgCustomerOrderItems)
        Me.gbCustomerOrderItems.Controls.Add(Me.Label15)
        Me.gbCustomerOrderItems.Controls.Add(Me.txtTotalItems)
        Me.gbCustomerOrderItems.Controls.Add(Me.Label8)
        Me.gbCustomerOrderItems.Controls.Add(Me.Label7)
        Me.gbCustomerOrderItems.Controls.Add(Me.txtTotalQtyPicked)
        Me.gbCustomerOrderItems.Controls.Add(Me.lnkViewEditBundleItems)
        Me.gbCustomerOrderItems.Controls.Add(Me.chkOtherInfo)
        Me.gbCustomerOrderItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCustomerOrderItems.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCustomerOrderItems.Location = New System.Drawing.Point(5, 167)
        Me.gbCustomerOrderItems.Name = "gbCustomerOrderItems"
        Me.gbCustomerOrderItems.Size = New System.Drawing.Size(815, 290)
        Me.gbCustomerOrderItems.TabIndex = 4
        Me.gbCustomerOrderItems.TabStop = False
        '
        'bccBarcode
        '
        Me.bccBarcode.BorderWidth = 0.6!
        Me.bccBarcode.BottomText = ""
        Me.bccBarcode.BottomTextFont = New System.Drawing.Font("Arial", 8.0!)
        Me.bccBarcode.Data = "SCDS,CDP 3133,,,1.00,0.00,2,1,238,650,490,270,0,SMEND"
        Me.bccBarcode.Data2D = "SCDS,CDP 3133,,,1.00,0.00,2,1,238,650,490,270,0,SMEND"
        Me.bccBarcode.DpiX = 96.0!
        Me.bccBarcode.DpiY = 96.0!
        Me.bccBarcode.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.bccBarcode.ImageHeight = 30.0!
        Me.bccBarcode.ImageWidth = 120.0!
        Me.bccBarcode.Location = New System.Drawing.Point(35, 93)
        Me.bccBarcode.Name = "bccBarcode"
        Me.bccBarcode.QRCodeLogoImage = CType(resources.GetObject("bccBarcode.QRCodeLogoImage"), System.Drawing.Image)
        Me.bccBarcode.ResolutionType = Spire.Barcode.ResolutionType.Printer
        Me.bccBarcode.Rotate = 0!
        Me.bccBarcode.ShowText = False
        Me.bccBarcode.Size = New System.Drawing.Size(339, 97)
        Me.bccBarcode.SupSpace = 4.0!
        Me.bccBarcode.TabIndex = 240
        Me.bccBarcode.Tag = ""
        Me.bccBarcode.TextFont = New System.Drawing.Font("Arial", 8.0!)
        Me.bccBarcode.TopText = ""
        Me.bccBarcode.TopTextAligment = System.Drawing.StringAlignment.Center
        Me.bccBarcode.TopTextFont = New System.Drawing.Font("Arial", 8.0!)
        Me.bccBarcode.Type = CType(((Spire.Barcode.BarCodeType.Codabar Or Spire.Barcode.BarCodeType.Code93Extended) _
            Or Spire.Barcode.BarCodeType.ITF14), Spire.Barcode.BarCodeType)
        Me.bccBarcode.UseChecksum = Spire.Barcode.CheckSumMode.[Auto]
        Me.bccBarcode.Visible = False
        Me.bccBarcode.WideNarrowRatio = 2.0!
        Me.bccBarcode.X = 1.0!
        Me.bccBarcode.XYRatio = 0.5!
        Me.bccBarcode.Y = 1.0!
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(560, 243)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(16, 15)
        Me.Label17.TabIndex = 469
        Me.Label17.Text = "₱"
        '
        'txtTotalPrice
        '
        Me.txtTotalPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrice.Location = New System.Drawing.Point(580, 240)
        Me.txtTotalPrice.Name = "txtTotalPrice"
        Me.txtTotalPrice.ReadOnly = True
        Me.txtTotalPrice.Size = New System.Drawing.Size(120, 21)
        Me.txtTotalPrice.TabIndex = 37
        Me.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(450, 245)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(109, 13)
        Me.Label19.TabIndex = 468
        Me.Label19.Text = "Total Price (Sum):"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAddToCarton
        '
        Me.btnAddToCarton.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAddToCarton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnAddToCarton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddToCarton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddToCarton.Image = CType(resources.GetObject("btnAddToCarton.Image"), System.Drawing.Image)
        Me.btnAddToCarton.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnAddToCarton.Location = New System.Drawing.Point(714, 17)
        Me.btnAddToCarton.Name = "btnAddToCarton"
        Me.btnAddToCarton.Size = New System.Drawing.Size(95, 75)
        Me.btnAddToCarton.TabIndex = 31
        Me.btnAddToCarton.Text = "Add To Truck"
        Me.btnAddToCarton.UseVisualStyleBackColor = False
        '
        'txtTotalQtyInCartonSum
        '
        Me.txtTotalQtyInCartonSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyInCartonSum.Location = New System.Drawing.Point(717, 230)
        Me.txtTotalQtyInCartonSum.Name = "txtTotalQtyInCartonSum"
        Me.txtTotalQtyInCartonSum.ReadOnly = True
        Me.txtTotalQtyInCartonSum.Size = New System.Drawing.Size(90, 21)
        Me.txtTotalQtyInCartonSum.TabIndex = 34
        Me.txtTotalQtyInCartonSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(723, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 26)
        Me.Label3.TabIndex = 466
        Me.Label3.Text = "Total Qty. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "In Box (Sum):"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(9, -2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(164, 17)
        Me.Label15.TabIndex = 228
        Me.Label15.Text = "Customer Order Items:"
        '
        'lnkViewEditBundleItems
        '
        Me.lnkViewEditBundleItems.AutoSize = True
        Me.lnkViewEditBundleItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkViewEditBundleItems.Location = New System.Drawing.Point(150, 243)
        Me.lnkViewEditBundleItems.Name = "lnkViewEditBundleItems"
        Me.lnkViewEditBundleItems.Size = New System.Drawing.Size(135, 15)
        Me.lnkViewEditBundleItems.TabIndex = 36
        Me.lnkViewEditBundleItems.TabStop = True
        Me.lnkViewEditBundleItems.Text = "View/Edit Bundle Items:"
        '
        'chkOtherInfo
        '
        Me.chkOtherInfo.AutoSize = True
        Me.chkOtherInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOtherInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOtherInfo.Location = New System.Drawing.Point(20, 242)
        Me.chkOtherInfo.Name = "chkOtherInfo"
        Me.chkOtherInfo.Size = New System.Drawing.Size(114, 19)
        Me.chkOtherInfo.TabIndex = 35
        Me.chkOtherInfo.Text = "View Other Info.:"
        Me.chkOtherInfo.UseVisualStyleBackColor = True
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(87, 104)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(286, 48)
        Me.txtComments.TabIndex = 20
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(10, 107)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 15)
        Me.Label25.TabIndex = 434
        Me.Label25.Text = "Comments:"
        '
        'msNew
        '
        Me.msNew.Image = CType(resources.GetObject("msNew.Image"), System.Drawing.Image)
        Me.msNew.Name = "msNew"
        Me.msNew.Size = New System.Drawing.Size(63, 21)
        Me.msNew.Text = "&New"
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'msCancel
        '
        Me.msCancel.Image = CType(resources.GetObject("msCancel.Image"), System.Drawing.Image)
        Me.msCancel.Name = "msCancel"
        Me.msCancel.Size = New System.Drawing.Size(76, 21)
        Me.msCancel.Text = "&Cancel"
        '
        'msOrder
        '
        Me.msOrder.Image = CType(resources.GetObject("msOrder.Image"), System.Drawing.Image)
        Me.msOrder.Name = "msOrder"
        Me.msOrder.Size = New System.Drawing.Size(102, 21)
        Me.msOrder.Text = "Cancel &List"
        '
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(81, 5)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 193
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msNew, Me.msSave, Me.msPrint, Me.msCancel, Me.msOrder})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(836, 25)
        Me.msMenu.TabIndex = 19
        '
        'msPrint
        '
        Me.msPrint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msOutrightA, Me.msOutrightB, Me.msConsignor})
        Me.msPrint.Image = CType(resources.GetObject("msPrint.Image"), System.Drawing.Image)
        Me.msPrint.Name = "msPrint"
        Me.msPrint.Size = New System.Drawing.Size(66, 21)
        Me.msPrint.Text = "&Print"
        '
        'msOutrightA
        '
        Me.msOutrightA.Image = CType(resources.GetObject("msOutrightA.Image"), System.Drawing.Image)
        Me.msOutrightA.Name = "msOutrightA"
        Me.msOutrightA.Size = New System.Drawing.Size(142, 22)
        Me.msOutrightA.Text = "Outright &A"
        '
        'msOutrightB
        '
        Me.msOutrightB.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsExtraSmall, Me.tsSmall, Me.tsMedium, Me.tsLarge, Me.tsExtraLarge})
        Me.msOutrightB.Image = CType(resources.GetObject("msOutrightB.Image"), System.Drawing.Image)
        Me.msOutrightB.Name = "msOutrightB"
        Me.msOutrightB.Size = New System.Drawing.Size(142, 22)
        Me.msOutrightB.Text = "Outright &B"
        '
        'tsExtraSmall
        '
        Me.tsExtraSmall.Image = CType(resources.GetObject("tsExtraSmall.Image"), System.Drawing.Image)
        Me.tsExtraSmall.Name = "tsExtraSmall"
        Me.tsExtraSmall.Size = New System.Drawing.Size(145, 22)
        Me.tsExtraSmall.Text = "&Extra Small"
        '
        'tsSmall
        '
        Me.tsSmall.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsSmall.Image = CType(resources.GetObject("tsSmall.Image"), System.Drawing.Image)
        Me.tsSmall.Name = "tsSmall"
        Me.tsSmall.Size = New System.Drawing.Size(145, 22)
        Me.tsSmall.Text = "S&mall"
        '
        'tsMedium
        '
        Me.tsMedium.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMedium.Image = CType(resources.GetObject("tsMedium.Image"), System.Drawing.Image)
        Me.tsMedium.Name = "tsMedium"
        Me.tsMedium.Size = New System.Drawing.Size(145, 22)
        Me.tsMedium.Text = "Me&dium"
        '
        'tsLarge
        '
        Me.tsLarge.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsLarge.Image = CType(resources.GetObject("tsLarge.Image"), System.Drawing.Image)
        Me.tsLarge.Name = "tsLarge"
        Me.tsLarge.Size = New System.Drawing.Size(145, 22)
        Me.tsLarge.Text = "La&rge"
        '
        'tsExtraLarge
        '
        Me.tsExtraLarge.Image = CType(resources.GetObject("tsExtraLarge.Image"), System.Drawing.Image)
        Me.tsExtraLarge.Name = "tsExtraLarge"
        Me.tsExtraLarge.Size = New System.Drawing.Size(145, 22)
        Me.tsExtraLarge.Text = "E&xtra Large"
        '
        'msConsignor
        '
        Me.msConsignor.Image = CType(resources.GetObject("msConsignor.Image"), System.Drawing.Image)
        Me.msConsignor.Name = "msConsignor"
        Me.msConsignor.Size = New System.Drawing.Size(142, 22)
        Me.msConsignor.Text = "Consi&gnor"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1200, 28)
        Me.lblTitle.TabIndex = 237
        Me.lblTitle.Text = "Packing List"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(10, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 15)
        Me.Label2.TabIndex = 422
        Me.Label2.Text = "Packing List Date:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(106, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 20)
        Me.Label6.TabIndex = 310
        Me.Label6.Text = "*"
        '
        'txtPackingListNo
        '
        Me.txtPackingListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPackingListNo.Location = New System.Drawing.Point(121, 21)
        Me.txtPackingListNo.Name = "txtPackingListNo"
        Me.txtPackingListNo.Size = New System.Drawing.Size(110, 21)
        Me.txtPackingListNo.TabIndex = 17
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(10, 24)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(98, 15)
        Me.Label52.TabIndex = 272
        Me.Label52.Text = "Packing List No.:"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.White
        Me.Label55.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label55.Location = New System.Drawing.Point(9, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(182, 17)
        Me.Label55.TabIndex = 228
        Me.Label55.Text = "Packing List Information:"
        '
        'gbPackingListInformation
        '
        Me.gbPackingListInformation.Controls.Add(Me.txtClassDescription)
        Me.gbPackingListInformation.Controls.Add(Me.txtVendorCodeNameInfo)
        Me.gbPackingListInformation.Controls.Add(Me.txtBranchCodeNameInfo)
        Me.gbPackingListInformation.Controls.Add(Me.Label31)
        Me.gbPackingListInformation.Controls.Add(Me.Label41)
        Me.gbPackingListInformation.Controls.Add(Me.Label29)
        Me.gbPackingListInformation.Controls.Add(Me.txtCancelDate)
        Me.gbPackingListInformation.Controls.Add(Me.Label14)
        Me.gbPackingListInformation.Controls.Add(Me.Label27)
        Me.gbPackingListInformation.Controls.Add(Me.txtSIDRNo)
        Me.gbPackingListInformation.Controls.Add(Me.Label13)
        Me.gbPackingListInformation.Controls.Add(Me.txtPONo)
        Me.gbPackingListInformation.Controls.Add(Me.txtStatus)
        Me.gbPackingListInformation.Controls.Add(Me.Label12)
        Me.gbPackingListInformation.Controls.Add(Me.txtCustomerOrderDate)
        Me.gbPackingListInformation.Controls.Add(Me.Label22)
        Me.gbPackingListInformation.Controls.Add(Me.txtTargetDeliveryDate)
        Me.gbPackingListInformation.Controls.Add(Me.Label20)
        Me.gbPackingListInformation.Controls.Add(Me.txtPackingListDate)
        Me.gbPackingListInformation.Controls.Add(Me.cboCustomerOrderInfo)
        Me.gbPackingListInformation.Controls.Add(Me.Label10)
        Me.gbPackingListInformation.Controls.Add(Me.txtComments)
        Me.gbPackingListInformation.Controls.Add(Me.Label25)
        Me.gbPackingListInformation.Controls.Add(Me.Label2)
        Me.gbPackingListInformation.Controls.Add(Me.txtPackingListNo)
        Me.gbPackingListInformation.Controls.Add(Me.Label52)
        Me.gbPackingListInformation.Controls.Add(Me.Label55)
        Me.gbPackingListInformation.Controls.Add(Me.Label6)
        Me.gbPackingListInformation.Controls.Add(Me.Label11)
        Me.gbPackingListInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPackingListInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbPackingListInformation.Location = New System.Drawing.Point(5, 5)
        Me.gbPackingListInformation.Name = "gbPackingListInformation"
        Me.gbPackingListInformation.Size = New System.Drawing.Size(815, 160)
        Me.gbPackingListInformation.TabIndex = 3
        Me.gbPackingListInformation.TabStop = False
        '
        'txtClassDescription
        '
        Me.txtClassDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClassDescription.Location = New System.Drawing.Point(360, 77)
        Me.txtClassDescription.Name = "txtClassDescription"
        Me.txtClassDescription.ReadOnly = True
        Me.txtClassDescription.Size = New System.Drawing.Size(272, 21)
        Me.txtClassDescription.TabIndex = 26
        '
        'txtVendorCodeNameInfo
        '
        Me.txtVendorCodeNameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorCodeNameInfo.Location = New System.Drawing.Point(555, 131)
        Me.txtVendorCodeNameInfo.Name = "txtVendorCodeNameInfo"
        Me.txtVendorCodeNameInfo.ReadOnly = True
        Me.txtVendorCodeNameInfo.Size = New System.Drawing.Size(255, 21)
        Me.txtVendorCodeNameInfo.TabIndex = 29
        '
        'txtBranchCodeNameInfo
        '
        Me.txtBranchCodeNameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchCodeNameInfo.Location = New System.Drawing.Point(555, 104)
        Me.txtBranchCodeNameInfo.Name = "txtBranchCodeNameInfo"
        Me.txtBranchCodeNameInfo.ReadOnly = True
        Me.txtBranchCodeNameInfo.Size = New System.Drawing.Size(255, 21)
        Me.txtBranchCodeNameInfo.TabIndex = 28
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(249, 80)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(105, 15)
        Me.Label31.TabIndex = 478
        Me.Label31.Text = "Class Description:"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(403, 107)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(147, 15)
        Me.Label41.TabIndex = 477
        Me.Label41.Text = "Branch Code / Name Info:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(403, 134)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(147, 15)
        Me.Label29.TabIndex = 476
        Me.Label29.Text = "Vendor Code / Name Info:"
        '
        'txtCancelDate
        '
        Me.txtCancelDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCancelDate.Location = New System.Drawing.Point(710, 50)
        Me.txtCancelDate.Name = "txtCancelDate"
        Me.txtCancelDate.ReadOnly = True
        Me.txtCancelDate.Size = New System.Drawing.Size(100, 21)
        Me.txtCancelDate.TabIndex = 25
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(633, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 15)
        Me.Label14.TabIndex = 474
        Me.Label14.Text = "Cancel Date:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(634, 80)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(76, 15)
        Me.Label27.TabIndex = 473
        Me.Label27.Text = "S.I./D.R. No.:"
        '
        'txtSIDRNo
        '
        Me.txtSIDRNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSIDRNo.Location = New System.Drawing.Point(710, 77)
        Me.txtSIDRNo.Name = "txtSIDRNo"
        Me.txtSIDRNo.ReadOnly = True
        Me.txtSIDRNo.Size = New System.Drawing.Size(100, 21)
        Me.txtSIDRNo.TabIndex = 27
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(653, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 15)
        Me.Label13.TabIndex = 472
        Me.Label13.Text = "P.O. No.:"
        '
        'txtPONo
        '
        Me.txtPONo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPONo.Location = New System.Drawing.Point(710, 21)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.ReadOnly = True
        Me.txtPONo.Size = New System.Drawing.Size(100, 21)
        Me.txtPONo.TabIndex = 22
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(86, 77)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(145, 21)
        Me.txtStatus.TabIndex = 19
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 469
        Me.Label12.Text = "Status:"
        '
        'txtCustomerOrderDate
        '
        Me.txtCustomerOrderDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerOrderDate.Location = New System.Drawing.Point(376, 50)
        Me.txtCustomerOrderDate.Name = "txtCustomerOrderDate"
        Me.txtCustomerOrderDate.ReadOnly = True
        Me.txtCustomerOrderDate.Size = New System.Drawing.Size(85, 21)
        Me.txtCustomerOrderDate.TabIndex = 23
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(249, 51)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(126, 15)
        Me.Label22.TabIndex = 453
        Me.Label22.Text = "Customer Order Date:"
        '
        'txtTargetDeliveryDate
        '
        Me.txtTargetDeliveryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTargetDeliveryDate.Location = New System.Drawing.Point(547, 50)
        Me.txtTargetDeliveryDate.Name = "txtTargetDeliveryDate"
        Me.txtTargetDeliveryDate.ReadOnly = True
        Me.txtTargetDeliveryDate.Size = New System.Drawing.Size(85, 21)
        Me.txtTargetDeliveryDate.TabIndex = 24
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(465, 51)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 15)
        Me.Label20.TabIndex = 451
        Me.Label20.Text = "Receipt Date:"
        '
        'txtPackingListDate
        '
        Me.txtPackingListDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPackingListDate.Location = New System.Drawing.Point(121, 50)
        Me.txtPackingListDate.Name = "txtPackingListDate"
        Me.txtPackingListDate.ReadOnly = True
        Me.txtPackingListDate.Size = New System.Drawing.Size(110, 21)
        Me.txtPackingListDate.TabIndex = 18
        '
        'cboCustomerOrderInfo
        '
        Me.cboCustomerOrderInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomerOrderInfo.FormattingEnabled = True
        Me.cboCustomerOrderInfo.Location = New System.Drawing.Point(385, 21)
        Me.cboCustomerOrderInfo.Name = "cboCustomerOrderInfo"
        Me.cboCustomerOrderInfo.Size = New System.Drawing.Size(247, 23)
        Me.cboCustomerOrderInfo.TabIndex = 21
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(249, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 15)
        Me.Label10.TabIndex = 436
        Me.Label10.Text = "Customer Order Info.:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(370, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 20)
        Me.Label11.TabIndex = 444
        Me.Label11.Text = "*"
        '
        'cmdLast
        '
        Me.cmdLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdLast.Image = CType(resources.GetObject("cmdLast.Image"), System.Drawing.Image)
        Me.cmdLast.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(24, 21)
        '
        'dgPackingList
        '
        Me.dgPackingList.AllowUserToAddRows = False
        Me.dgPackingList.AllowUserToDeleteRows = False
        Me.dgPackingList.AllowUserToOrderColumns = True
        Me.dgPackingList.AllowUserToResizeRows = False
        Me.dgPackingList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgPackingList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPackingList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle32
        Me.dgPackingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPackingList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pal_rowid, Me.pal_packinglistno, Me.pal_packinglistdate, Me.pal_customerorderno, Me.pal_customername, Me.pal_status})
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPackingList.DefaultCellStyle = DataGridViewCellStyle33
        Me.dgPackingList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgPackingList.Location = New System.Drawing.Point(8, 68)
        Me.dgPackingList.MultiSelect = False
        Me.dgPackingList.Name = "dgPackingList"
        Me.dgPackingList.ReadOnly = True
        Me.dgPackingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPackingList.Size = New System.Drawing.Size(324, 296)
        Me.dgPackingList.TabIndex = 16
        '
        'pal_rowid
        '
        Me.pal_rowid.HeaderText = "rowid"
        Me.pal_rowid.Name = "pal_rowid"
        Me.pal_rowid.ReadOnly = True
        Me.pal_rowid.Visible = False
        '
        'pal_packinglistno
        '
        Me.pal_packinglistno.HeaderText = "Packing List No."
        Me.pal_packinglistno.Name = "pal_packinglistno"
        Me.pal_packinglistno.ReadOnly = True
        '
        'pal_packinglistdate
        '
        Me.pal_packinglistdate.HeaderText = "Packing List Date"
        Me.pal_packinglistdate.Name = "pal_packinglistdate"
        Me.pal_packinglistdate.ReadOnly = True
        '
        'pal_customerorderno
        '
        Me.pal_customerorderno.HeaderText = "Customer Order No."
        Me.pal_customerorderno.Name = "pal_customerorderno"
        Me.pal_customerorderno.ReadOnly = True
        '
        'pal_customername
        '
        Me.pal_customername.HeaderText = "Customer Name"
        Me.pal_customername.Name = "pal_customername"
        Me.pal_customername.ReadOnly = True
        '
        'pal_status
        '
        Me.pal_status.HeaderText = "Status"
        Me.pal_status.Name = "pal_status"
        Me.pal_status.ReadOnly = True
        Me.pal_status.Width = 80
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Aquamarine
        Me.Label16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(6, -1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 17)
        Me.Label16.TabIndex = 216
        Me.Label16.Text = "Packing List:"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Aquamarine
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbPackingList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbSearch)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabMain)
        Me.SplitContainer1.Panel2.Controls.Add(Me.msMenu)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblsavemsg)
        Me.SplitContainer1.Size = New System.Drawing.Size(1200, 532)
        Me.SplitContainer1.SplitterDistance = 356
        Me.SplitContainer1.TabIndex = 239
        '
        'gbPackingList
        '
        Me.gbPackingList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbPackingList.BackColor = System.Drawing.Color.Transparent
        Me.gbPackingList.Controls.Add(Me.ToolStrip3)
        Me.gbPackingList.Controls.Add(Me.Label4)
        Me.gbPackingList.Controls.Add(Me.txtPage)
        Me.gbPackingList.Controls.Add(Me.txtPageNo)
        Me.gbPackingList.Controls.Add(Me.dgPackingList)
        Me.gbPackingList.Controls.Add(Me.Label16)
        Me.gbPackingList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPackingList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbPackingList.Location = New System.Drawing.Point(6, 147)
        Me.gbPackingList.Name = "gbPackingList"
        Me.gbPackingList.Size = New System.Drawing.Size(340, 370)
        Me.gbPackingList.TabIndex = 2
        Me.gbPackingList.TabStop = False
        '
        'ToolStrip3
        '
        Me.ToolStrip3.AutoSize = False
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdFirst, Me.cmdPrev, Me.cmdNext, Me.cmdLast, Me.tsRefresh})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 17)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(334, 24)
        Me.ToolStrip3.TabIndex = 13
        '
        'cmdFirst
        '
        Me.cmdFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdFirst.Image = CType(resources.GetObject("cmdFirst.Image"), System.Drawing.Image)
        Me.cmdFirst.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(24, 21)
        '
        'cmdPrev
        '
        Me.cmdPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPrev.Image = CType(resources.GetObject("cmdPrev.Image"), System.Drawing.Image)
        Me.cmdPrev.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdPrev.Name = "cmdPrev"
        Me.cmdPrev.Size = New System.Drawing.Size(24, 21)
        '
        'cmdNext
        '
        Me.cmdNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdNext.Image = CType(resources.GetObject("cmdNext.Image"), System.Drawing.Image)
        Me.cmdNext.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(24, 21)
        '
        'tsRefresh
        '
        Me.tsRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsRefresh.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tsRefresh.Image = CType(resources.GetObject("tsRefresh.Image"), System.Drawing.Image)
        Me.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRefresh.Name = "tsRefresh"
        Me.tsRefresh.Size = New System.Drawing.Size(75, 21)
        Me.tsRefresh.Text = "&Refresh"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(50, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 15)
        Me.Label4.TabIndex = 297
        Me.Label4.Text = "Page No.:"
        '
        'txtPage
        '
        Me.txtPage.Location = New System.Drawing.Point(228, 43)
        Me.txtPage.Name = "txtPage"
        Me.txtPage.Size = New System.Drawing.Size(41, 21)
        Me.txtPage.TabIndex = 15
        '
        'txtPageNo
        '
        Me.txtPageNo.Location = New System.Drawing.Point(121, 43)
        Me.txtPageNo.Name = "txtPageNo"
        Me.txtPageNo.ReadOnly = True
        Me.txtPageNo.Size = New System.Drawing.Size(101, 21)
        Me.txtPageNo.TabIndex = 14
        '
        'gbSearch
        '
        Me.gbSearch.BackColor = System.Drawing.Color.Transparent
        Me.gbSearch.Controls.Add(Me.Label21)
        Me.gbSearch.Controls.Add(Me.tabSearch)
        Me.gbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSearch.Location = New System.Drawing.Point(6, 5)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(340, 140)
        Me.gbSearch.TabIndex = 1
        Me.gbSearch.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Aquamarine
        Me.Label21.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label21.Location = New System.Drawing.Point(6, -2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 17)
        Me.Label21.TabIndex = 217
        Me.Label21.Text = "Search:"
        '
        'tabSearch
        '
        Me.tabSearch.Controls.Add(Me.tabSimple)
        Me.tabSearch.Controls.Add(Me.tabCommon)
        Me.tabSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSearch.ItemSize = New System.Drawing.Size(62, 25)
        Me.tabSearch.Location = New System.Drawing.Point(8, 16)
        Me.tabSearch.Multiline = True
        Me.tabSearch.Name = "tabSearch"
        Me.tabSearch.SelectedIndex = 0
        Me.tabSearch.Size = New System.Drawing.Size(325, 115)
        Me.tabSearch.TabIndex = 6
        '
        'tabSimple
        '
        Me.tabSimple.Controls.Add(Me.txtSimpleSearch)
        Me.tabSimple.Controls.Add(Me.Label30)
        Me.tabSimple.Location = New System.Drawing.Point(4, 29)
        Me.tabSimple.Name = "tabSimple"
        Me.tabSimple.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSimple.Size = New System.Drawing.Size(317, 82)
        Me.tabSimple.TabIndex = 1
        Me.tabSimple.Text = "       Simple       "
        Me.tabSimple.UseVisualStyleBackColor = True
        '
        'txtSimpleSearch
        '
        Me.txtSimpleSearch.Location = New System.Drawing.Point(96, 31)
        Me.txtSimpleSearch.Name = "txtSimpleSearch"
        Me.txtSimpleSearch.Size = New System.Drawing.Size(212, 21)
        Me.txtSimpleSearch.TabIndex = 7
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(2, 33)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(91, 15)
        Me.Label30.TabIndex = 4
        Me.Label30.Text = "Search Phrase:"
        '
        'tabCommon
        '
        Me.tabCommon.Controls.Add(Me.Label40)
        Me.tabCommon.Controls.Add(Me.dtpToSearch)
        Me.tabCommon.Controls.Add(Me.dtpFromSearch)
        Me.tabCommon.Controls.Add(Me.Label18)
        Me.tabCommon.Controls.Add(Me.cboDate)
        Me.tabCommon.Controls.Add(Me.cboSearch2)
        Me.tabCommon.Controls.Add(Me.cboSearch1)
        Me.tabCommon.Location = New System.Drawing.Point(4, 29)
        Me.tabCommon.Name = "tabCommon"
        Me.tabCommon.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCommon.Size = New System.Drawing.Size(317, 82)
        Me.tabCommon.TabIndex = 0
        Me.tabCommon.Text = "       Common       "
        Me.tabCommon.UseVisualStyleBackColor = True
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(242, 5)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(24, 15)
        Me.Label40.TabIndex = 255
        Me.Label40.Text = "To:"
        '
        'dtpToSearch
        '
        Me.dtpToSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpToSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpToSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToSearch.Location = New System.Drawing.Point(201, 24)
        Me.dtpToSearch.Name = "dtpToSearch"
        Me.dtpToSearch.Size = New System.Drawing.Size(110, 21)
        Me.dtpToSearch.TabIndex = 10
        '
        'dtpFromSearch
        '
        Me.dtpFromSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpFromSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFromSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromSearch.Location = New System.Drawing.Point(87, 24)
        Me.dtpFromSearch.Name = "dtpFromSearch"
        Me.dtpFromSearch.Size = New System.Drawing.Size(110, 21)
        Me.dtpFromSearch.TabIndex = 9
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(118, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 15)
        Me.Label18.TabIndex = 254
        Me.Label18.Text = "From:"
        '
        'cboDate
        '
        Me.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDate.FormattingEnabled = True
        Me.cboDate.Location = New System.Drawing.Point(3, 23)
        Me.cboDate.Name = "cboDate"
        Me.cboDate.Size = New System.Drawing.Size(80, 23)
        Me.cboDate.TabIndex = 8
        '
        'cboSearch2
        '
        Me.cboSearch2.FormattingEnabled = True
        Me.cboSearch2.Location = New System.Drawing.Point(112, 52)
        Me.cboSearch2.Name = "cboSearch2"
        Me.cboSearch2.Size = New System.Drawing.Size(198, 23)
        Me.cboSearch2.TabIndex = 12
        '
        'cboSearch1
        '
        Me.cboSearch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch1.FormattingEnabled = True
        Me.cboSearch1.Location = New System.Drawing.Point(3, 52)
        Me.cboSearch1.Name = "cboSearch1"
        Me.cboSearch1.Size = New System.Drawing.Size(105, 23)
        Me.cboSearch1.TabIndex = 11
        '
        'tabMain
        '
        Me.tabMain.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabMain.Controls.Add(Me.tabDetails)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabMain.ItemSize = New System.Drawing.Size(61, 23)
        Me.tabMain.Location = New System.Drawing.Point(0, 25)
        Me.tabMain.Multiline = True
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(836, 503)
        Me.tabMain.TabIndex = 223
        '
        'tabDetails
        '
        Me.tabDetails.AutoScroll = True
        Me.tabDetails.Controls.Add(Me.gbCartonItems)
        Me.tabDetails.Controls.Add(Me.gbCartons)
        Me.tabDetails.Controls.Add(Me.gbCustomerOrderItems)
        Me.tabDetails.Controls.Add(Me.gbPackingListInformation)
        Me.tabDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(828, 472)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Pa. L. Details"
        Me.tabDetails.UseVisualStyleBackColor = True
        '
        'gbCartonItems
        '
        Me.gbCartonItems.Controls.Add(Me.txtQtyInCartonSum)
        Me.gbCartonItems.Controls.Add(Me.Label5)
        Me.gbCartonItems.Controls.Add(Me.dgCartonItems)
        Me.gbCartonItems.Controls.Add(Me.Label1)
        Me.gbCartonItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCartonItems.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCartonItems.Location = New System.Drawing.Point(340, 463)
        Me.gbCartonItems.Name = "gbCartonItems"
        Me.gbCartonItems.Size = New System.Drawing.Size(480, 200)
        Me.gbCartonItems.TabIndex = 6
        Me.gbCartonItems.TabStop = False
        '
        'txtQtyInCartonSum
        '
        Me.txtQtyInCartonSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyInCartonSum.Location = New System.Drawing.Point(245, 175)
        Me.txtQtyInCartonSum.Name = "txtQtyInCartonSum"
        Me.txtQtyInCartonSum.ReadOnly = True
        Me.txtQtyInCartonSum.Size = New System.Drawing.Size(75, 21)
        Me.txtQtyInCartonSum.TabIndex = 40
        Me.txtQtyInCartonSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(105, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 15)
        Me.Label5.TabIndex = 468
        Me.Label5.Text = "Qty. In Box (Sum):"
        '
        'dgCartonItems
        '
        Me.dgCartonItems.AllowUserToAddRows = False
        Me.dgCartonItems.AllowUserToDeleteRows = False
        Me.dgCartonItems.AllowUserToOrderColumns = True
        Me.dgCartonItems.AllowUserToResizeRows = False
        Me.dgCartonItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartonItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.dgCartonItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCartonItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cai_rowid, Me.cai_colorvalue, Me.cai_seqno, Me.cai_productcode, Me.cai_colorname, Me.cai_color, Me.cai_size, Me.cai_seasoncode, Me.cai_qtyincarton, Me.cai_sku, Me.cai_unitofmeasure, Me.cai_type, Me.cai_option})
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCartonItems.DefaultCellStyle = DataGridViewCellStyle27
        Me.dgCartonItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCartonItems.Location = New System.Drawing.Point(5, 20)
        Me.dgCartonItems.MultiSelect = False
        Me.dgCartonItems.Name = "dgCartonItems"
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartonItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle28
        Me.dgCartonItems.RowHeadersVisible = False
        Me.dgCartonItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCartonItems.Size = New System.Drawing.Size(470, 150)
        Me.dgCartonItems.TabIndex = 39
        '
        'cai_rowid
        '
        Me.cai_rowid.HeaderText = "rowid"
        Me.cai_rowid.Name = "cai_rowid"
        Me.cai_rowid.Visible = False
        '
        'cai_colorvalue
        '
        Me.cai_colorvalue.HeaderText = "colorvalue"
        Me.cai_colorvalue.Name = "cai_colorvalue"
        Me.cai_colorvalue.Visible = False
        '
        'cai_seqno
        '
        Me.cai_seqno.HeaderText = "Seq. No."
        Me.cai_seqno.Name = "cai_seqno"
        Me.cai_seqno.ReadOnly = True
        Me.cai_seqno.Width = 40
        '
        'cai_productcode
        '
        Me.cai_productcode.HeaderText = "Product Code"
        Me.cai_productcode.Name = "cai_productcode"
        Me.cai_productcode.ReadOnly = True
        '
        'cai_colorname
        '
        Me.cai_colorname.HeaderText = "Color Name"
        Me.cai_colorname.Name = "cai_colorname"
        Me.cai_colorname.ReadOnly = True
        Me.cai_colorname.Width = 60
        '
        'cai_color
        '
        Me.cai_color.HeaderText = ""
        Me.cai_color.Name = "cai_color"
        Me.cai_color.ReadOnly = True
        Me.cai_color.Width = 30
        '
        'cai_size
        '
        Me.cai_size.HeaderText = "Size"
        Me.cai_size.Name = "cai_size"
        Me.cai_size.ReadOnly = True
        Me.cai_size.Width = 40
        '
        'cai_seasoncode
        '
        Me.cai_seasoncode.HeaderText = "Season Code"
        Me.cai_seasoncode.Name = "cai_seasoncode"
        Me.cai_seasoncode.ReadOnly = True
        Me.cai_seasoncode.Width = 70
        '
        'cai_qtyincarton
        '
        Me.cai_qtyincarton.HeaderText = "Qty. In Box"
        Me.cai_qtyincarton.Name = "cai_qtyincarton"
        Me.cai_qtyincarton.ReadOnly = True
        Me.cai_qtyincarton.Width = 63
        '
        'cai_sku
        '
        Me.cai_sku.HeaderText = "SKU"
        Me.cai_sku.Name = "cai_sku"
        Me.cai_sku.ReadOnly = True
        '
        'cai_unitofmeasure
        '
        Me.cai_unitofmeasure.HeaderText = "Unit Of Measure"
        Me.cai_unitofmeasure.Name = "cai_unitofmeasure"
        Me.cai_unitofmeasure.ReadOnly = True
        Me.cai_unitofmeasure.Width = 70
        '
        'cai_type
        '
        Me.cai_type.HeaderText = "Type"
        Me.cai_type.Name = "cai_type"
        Me.cai_type.ReadOnly = True
        Me.cai_type.Width = 35
        '
        'cai_option
        '
        Me.cai_option.HeaderText = ""
        Me.cai_option.Name = "cai_option"
        Me.cai_option.Text = "Remove"
        Me.cai_option.UseColumnTextForButtonValue = True
        Me.cai_option.Width = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(9, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 228
        Me.Label1.Text = "Box Items:"
        '
        'gbCartons
        '
        Me.gbCartons.Controls.Add(Me.dgCartons)
        Me.gbCartons.Controls.Add(Me.Label9)
        Me.gbCartons.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCartons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCartons.Location = New System.Drawing.Point(5, 465)
        Me.gbCartons.Name = "gbCartons"
        Me.gbCartons.Size = New System.Drawing.Size(330, 200)
        Me.gbCartons.TabIndex = 5
        Me.gbCartons.TabStop = False
        '
        'dgCartons
        '
        Me.dgCartons.AllowUserToAddRows = False
        Me.dgCartons.AllowUserToDeleteRows = False
        Me.dgCartons.AllowUserToOrderColumns = True
        Me.dgCartons.AllowUserToResizeRows = False
        Me.dgCartons.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartons.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle29
        Me.dgCartons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCartons.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ca_rowid, Me.ca_seqno, Me.ca_cartonno, Me.ca_size, Me.ca_weight, Me.ca_amount, Me.ca_packername, Me.ca_packeddate, Me.ca_status, Me.ca_option})
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCartons.DefaultCellStyle = DataGridViewCellStyle30
        Me.dgCartons.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCartons.Location = New System.Drawing.Point(10, 20)
        Me.dgCartons.MultiSelect = False
        Me.dgCartons.Name = "dgCartons"
        Me.dgCartons.ReadOnly = True
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartons.RowHeadersDefaultCellStyle = DataGridViewCellStyle31
        Me.dgCartons.RowHeadersVisible = False
        Me.dgCartons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCartons.Size = New System.Drawing.Size(310, 170)
        Me.dgCartons.TabIndex = 38
        '
        'ca_rowid
        '
        Me.ca_rowid.HeaderText = "rowid"
        Me.ca_rowid.Name = "ca_rowid"
        Me.ca_rowid.ReadOnly = True
        Me.ca_rowid.Visible = False
        '
        'ca_seqno
        '
        Me.ca_seqno.HeaderText = "Seq. No."
        Me.ca_seqno.Name = "ca_seqno"
        Me.ca_seqno.ReadOnly = True
        Me.ca_seqno.Width = 50
        '
        'ca_cartonno
        '
        Me.ca_cartonno.HeaderText = "Box No."
        Me.ca_cartonno.Name = "ca_cartonno"
        Me.ca_cartonno.ReadOnly = True
        '
        'ca_size
        '
        Me.ca_size.HeaderText = "Size Name"
        Me.ca_size.Name = "ca_size"
        Me.ca_size.ReadOnly = True
        Me.ca_size.Width = 80
        '
        'ca_weight
        '
        Me.ca_weight.HeaderText = "Weight"
        Me.ca_weight.Name = "ca_weight"
        Me.ca_weight.ReadOnly = True
        Me.ca_weight.Width = 80
        '
        'ca_amount
        '
        Me.ca_amount.HeaderText = "Amount"
        Me.ca_amount.Name = "ca_amount"
        Me.ca_amount.ReadOnly = True
        Me.ca_amount.Width = 80
        '
        'ca_packername
        '
        Me.ca_packername.HeaderText = "Packer Name"
        Me.ca_packername.Name = "ca_packername"
        Me.ca_packername.ReadOnly = True
        Me.ca_packername.Width = 120
        '
        'ca_packeddate
        '
        Me.ca_packeddate.HeaderText = "Packed Date"
        Me.ca_packeddate.Name = "ca_packeddate"
        Me.ca_packeddate.ReadOnly = True
        '
        'ca_status
        '
        Me.ca_status.HeaderText = "Status"
        Me.ca_status.Name = "ca_status"
        Me.ca_status.ReadOnly = True
        Me.ca_status.Width = 80
        '
        'ca_option
        '
        Me.ca_option.HeaderText = ""
        Me.ca_option.Name = "ca_option"
        Me.ca_option.ReadOnly = True
        Me.ca_option.Text = ""
        Me.ca_option.Width = 30
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(9, -2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 17)
        Me.Label9.TabIndex = 228
        Me.Label9.Text = "Boxes:"
        '
        'pbClose
        '
        Me.pbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pbClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbClose.Image = CType(resources.GetObject("pbClose.Image"), System.Drawing.Image)
        Me.pbClose.Location = New System.Drawing.Point(1175, 5)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(19, 19)
        Me.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbClose.TabIndex = 238
        Me.pbClose.TabStop = False
        '
        'cmsOptions
        '
        Me.cmsOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsEdit, Me.cmsDelete})
        Me.cmsOptions.Name = "cMenustrip"
        Me.cmsOptions.Size = New System.Drawing.Size(108, 48)
        '
        'cmsEdit
        '
        Me.cmsEdit.Image = CType(resources.GetObject("cmsEdit.Image"), System.Drawing.Image)
        Me.cmsEdit.Name = "cmsEdit"
        Me.cmsEdit.Size = New System.Drawing.Size(107, 22)
        Me.cmsEdit.Text = "Edit"
        '
        'cmsDelete
        '
        Me.cmsDelete.Image = CType(resources.GetObject("cmsDelete.Image"), System.Drawing.Image)
        Me.cmsDelete.Name = "cmsDelete"
        Me.cmsDelete.Size = New System.Drawing.Size(107, 22)
        Me.cmsDelete.Text = "Delete"
        '
        'PackingListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 560)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PackingListForm"
        CType(Me.dgCustomerOrderItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCustomerOrderItems.ResumeLayout(False)
        Me.gbCustomerOrderItems.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        Me.gbPackingListInformation.ResumeLayout(False)
        Me.gbPackingListInformation.PerformLayout()
        CType(Me.dgPackingList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbPackingList.ResumeLayout(False)
        Me.gbPackingList.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.tabSearch.ResumeLayout(False)
        Me.tabSimple.ResumeLayout(False)
        Me.tabSimple.PerformLayout()
        Me.tabCommon.ResumeLayout(False)
        Me.tabCommon.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.gbCartonItems.ResumeLayout(False)
        Me.gbCartonItems.PerformLayout()
        CType(Me.dgCartonItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCartons.ResumeLayout(False)
        Me.gbCartons.PerformLayout()
        CType(Me.dgCartons, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQtyPicked As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgCustomerOrderItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtTotalItems As System.Windows.Forms.TextBox
    Friend WithEvents gbCustomerOrderItems As System.Windows.Forms.GroupBox
    Friend WithEvents lnkViewEditBundleItems As System.Windows.Forms.LinkLabel
    Friend WithEvents chkOtherInfo As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents msNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msOrder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbPackingList As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPage As System.Windows.Forms.TextBox
    Friend WithEvents txtPageNo As System.Windows.Forms.TextBox
    Friend WithEvents dgPackingList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tabSearch As System.Windows.Forms.TabControl
    Friend WithEvents tabSimple As System.Windows.Forms.TabPage
    Friend WithEvents txtSimpleSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents tabCommon As System.Windows.Forms.TabPage
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents dtpToSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboDate As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch1 As System.Windows.Forms.ComboBox
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents gbPackingListInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPackingListNo As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerOrderInfo As System.Windows.Forms.ComboBox
    Private WithEvents txtPackingListDate As System.Windows.Forms.TextBox
    Friend WithEvents gbCartons As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQtyInCartonSum As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgCartons As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbCartonItems As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgCartonItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtQtyInCartonSum As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents msPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents txtCustomerOrderDate As System.Windows.Forms.TextBox
    Private WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTargetDeliveryDate As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnAddToCarton As System.Windows.Forms.Button
    Friend WithEvents pal_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pal_packinglistno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pal_packinglistdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pal_customerorderno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pal_customername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pal_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmsOptions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtSIDRNo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCancelDate As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Private WithEvents txtVendorCodeNameInfo As System.Windows.Forms.TextBox
    Private WithEvents txtBranchCodeNameInfo As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Private WithEvents txtClassDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cai_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_qtyincarton As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cai_option As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ca_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_cartonno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_weight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_packername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_packeddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_option As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents msOutrightA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msConsignor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ci_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_pcsrowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_bid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_itemcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtyordered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtypicked As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_totalqtyincarton As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ci_qtytopack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_srp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_totalprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_tags As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_packedby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_packeddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bccBarcode As Spire.Barcode.Forms.BarCodeControl
    Friend WithEvents msOutrightB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSmall As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMedium As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsLarge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsExtraSmall As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsExtraLarge As System.Windows.Forms.ToolStripMenuItem
End Class
