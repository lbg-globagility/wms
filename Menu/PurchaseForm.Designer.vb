<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseForm
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseForm))
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkOtherInfo = New System.Windows.Forms.CheckBox()
        Me.txtTotalPrice = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalItems = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalQty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgSupplierOrderItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ci_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_pcsrowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_bid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtyordered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtyreceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtybad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_srp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_totalprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_reason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_itemtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_option = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.gbSupplierOrderItems = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtOverallQty = New System.Windows.Forms.TextBox()
        Me.lblOverallQty = New System.Windows.Forms.Label()
        Me.txtOverallPrice = New System.Windows.Forms.TextBox()
        Me.lblOverallPrice = New System.Windows.Forms.Label()
        Me.lblOverallPesoSign = New System.Windows.Forms.Label()
        Me.dgProductColorSizes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pcs_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_qtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_srp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.msOrder = New System.Windows.Forms.ToolStripMenuItem()
        Me.msCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbAddSupplier = New System.Windows.Forms.PictureBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dtpTargetDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtRRNo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.dtpSupplierOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboSupplierName = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSupplierOrderNo = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.gbSupplierOrderInformation = New System.Windows.Forms.GroupBox()
        Me.txtReceivedBy = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtSealNo = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtContainerNo = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtBrands = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtArrivedIn = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtTimeArrived = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtRRDate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.c_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboBy = New System.Windows.Forms.ComboBox()
        Me.gbAddProductItem = New System.Windows.Forms.GroupBox()
        Me.txtQtyOrdered = New System.Windows.Forms.TextBox()
        Me.cboByPhrase = New System.Windows.Forms.ComboBox()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgSupplierOrderList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.so_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.so_supplierorderno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.so_supplierorderdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.so_suppliername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.so_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbSupplierOrderList = New System.Windows.Forms.GroupBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.cmdFirst = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrev = New System.Windows.Forms.ToolStripButton()
        Me.cmdNext = New System.Windows.Forms.ToolStripButton()
        Me.cmdLast = New System.Windows.Forms.ToolStripButton()
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
        Me.cboSearch4 = New System.Windows.Forms.ComboBox()
        Me.cboSearch2 = New System.Windows.Forms.ComboBox()
        Me.cboSearch3 = New System.Windows.Forms.ComboBox()
        Me.cboSearch1 = New System.Windows.Forms.ComboBox()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.gbAddProducts = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgProductColors = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.c_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgProductSizes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.s_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_sizes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_qtyordered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_qtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_srp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_totalprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.cboByPhrase2 = New SergeUtils.EasyCompletionComboBox()
        CType(Me.dgSupplierOrderItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSupplierOrderItems.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgProductColorSizes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msMenu.SuspendLayout()
        CType(Me.pbAddSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSupplierOrderInformation.SuspendLayout()
        Me.gbAddProductItem.SuspendLayout()
        CType(Me.dgSupplierOrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbSupplierOrderList.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.tabSimple.SuspendLayout()
        Me.tabCommon.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.gbAddProducts.SuspendLayout()
        CType(Me.dgProductColors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgProductSizes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(656, 226)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(16, 15)
        Me.Label17.TabIndex = 466
        Me.Label17.Text = "₱"
        '
        'chkOtherInfo
        '
        Me.chkOtherInfo.AutoSize = True
        Me.chkOtherInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOtherInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOtherInfo.Location = New System.Drawing.Point(22, 226)
        Me.chkOtherInfo.Name = "chkOtherInfo"
        Me.chkOtherInfo.Size = New System.Drawing.Size(114, 19)
        Me.chkOtherInfo.TabIndex = 37
        Me.chkOtherInfo.Text = "View Other Info.:"
        Me.chkOtherInfo.UseVisualStyleBackColor = True
        '
        'txtTotalPrice
        '
        Me.txtTotalPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrice.Location = New System.Drawing.Point(675, 223)
        Me.txtTotalPrice.Name = "txtTotalPrice"
        Me.txtTotalPrice.ReadOnly = True
        Me.txtTotalPrice.Size = New System.Drawing.Size(129, 21)
        Me.txtTotalPrice.TabIndex = 40
        Me.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(578, 226)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 15)
        Me.Label13.TabIndex = 465
        Me.Label13.Text = "Total Price:"
        '
        'txtTotalItems
        '
        Me.txtTotalItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalItems.Location = New System.Drawing.Point(329, 223)
        Me.txtTotalItems.Name = "txtTotalItems"
        Me.txtTotalItems.ReadOnly = True
        Me.txtTotalItems.Size = New System.Drawing.Size(65, 21)
        Me.txtTotalItems.TabIndex = 38
        Me.txtTotalItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(241, 226)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 15)
        Me.Label8.TabIndex = 463
        Me.Label8.Text = "Total Items:"
        '
        'txtTotalQty
        '
        Me.txtTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQty.Location = New System.Drawing.Point(495, 223)
        Me.txtTotalQty.Name = "txtTotalQty"
        Me.txtTotalQty.ReadOnly = True
        Me.txtTotalQty.Size = New System.Drawing.Size(75, 21)
        Me.txtTotalQty.TabIndex = 39
        Me.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(402, 226)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 15)
        Me.Label7.TabIndex = 461
        Me.Label7.Text = "Total Orders:"
        '
        'dgSupplierOrderItems
        '
        Me.dgSupplierOrderItems.AllowUserToAddRows = False
        Me.dgSupplierOrderItems.AllowUserToDeleteRows = False
        Me.dgSupplierOrderItems.AllowUserToOrderColumns = True
        Me.dgSupplierOrderItems.AllowUserToResizeRows = False
        Me.dgSupplierOrderItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSupplierOrderItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgSupplierOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSupplierOrderItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ci_rowid, Me.ci_pcsrowid, Me.ci_bid, Me.ci_colorvalue, Me.ci_seqno, Me.ci_productcode, Me.ci_colorname, Me.ci_color, Me.ci_size, Me.ci_seasoncode, Me.ci_sku, Me.ci_unitofmeasure, Me.ci_qtyordered, Me.ci_qtyreceived, Me.ci_qtybad, Me.ci_srp, Me.ci_totalprice, Me.ci_remarks, Me.ci_reason, Me.ci_itemtype, Me.ci_option})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSupplierOrderItems.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgSupplierOrderItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgSupplierOrderItems.Location = New System.Drawing.Point(8, 19)
        Me.dgSupplierOrderItems.MultiSelect = False
        Me.dgSupplierOrderItems.Name = "dgSupplierOrderItems"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSupplierOrderItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgSupplierOrderItems.RowHeadersVisible = False
        Me.dgSupplierOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSupplierOrderItems.Size = New System.Drawing.Size(800, 200)
        Me.dgSupplierOrderItems.TabIndex = 36
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
        'ci_productcode
        '
        Me.ci_productcode.HeaderText = "Product Code"
        Me.ci_productcode.Name = "ci_productcode"
        Me.ci_productcode.ReadOnly = True
        Me.ci_productcode.Width = 120
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
        Me.ci_unitofmeasure.Width = 70
        '
        'ci_qtyordered
        '
        Me.ci_qtyordered.HeaderText = "Qty. Ordered"
        Me.ci_qtyordered.Name = "ci_qtyordered"
        Me.ci_qtyordered.Width = 60
        '
        'ci_qtyreceived
        '
        Me.ci_qtyreceived.HeaderText = "Qty. Received (Good)"
        Me.ci_qtyreceived.Name = "ci_qtyreceived"
        Me.ci_qtyreceived.ReadOnly = True
        Me.ci_qtyreceived.Width = 105
        '
        'ci_qtybad
        '
        Me.ci_qtybad.HeaderText = "Qty. Received (Bad)"
        Me.ci_qtybad.Name = "ci_qtybad"
        Me.ci_qtybad.ReadOnly = True
        Me.ci_qtybad.Width = 105
        '
        'ci_srp
        '
        Me.ci_srp.HeaderText = "SRP"
        Me.ci_srp.Name = "ci_srp"
        Me.ci_srp.Width = 80
        '
        'ci_totalprice
        '
        Me.ci_totalprice.HeaderText = "Total Price"
        Me.ci_totalprice.Name = "ci_totalprice"
        Me.ci_totalprice.ReadOnly = True
        '
        'ci_remarks
        '
        Me.ci_remarks.HeaderText = "Remarks"
        Me.ci_remarks.Name = "ci_remarks"
        '
        'ci_reason
        '
        Me.ci_reason.HeaderText = "Reason"
        Me.ci_reason.Name = "ci_reason"
        Me.ci_reason.ReadOnly = True
        '
        'ci_itemtype
        '
        Me.ci_itemtype.HeaderText = "Type"
        Me.ci_itemtype.Name = "ci_itemtype"
        Me.ci_itemtype.ReadOnly = True
        Me.ci_itemtype.Width = 40
        '
        'ci_option
        '
        Me.ci_option.HeaderText = ""
        Me.ci_option.Name = "ci_option"
        Me.ci_option.Text = "Delete"
        Me.ci_option.UseColumnTextForButtonValue = True
        Me.ci_option.Width = 50
        '
        'gbSupplierOrderItems
        '
        Me.gbSupplierOrderItems.Controls.Add(Me.Label17)
        Me.gbSupplierOrderItems.Controls.Add(Me.chkOtherInfo)
        Me.gbSupplierOrderItems.Controls.Add(Me.txtTotalPrice)
        Me.gbSupplierOrderItems.Controls.Add(Me.Label13)
        Me.gbSupplierOrderItems.Controls.Add(Me.txtTotalItems)
        Me.gbSupplierOrderItems.Controls.Add(Me.Label8)
        Me.gbSupplierOrderItems.Controls.Add(Me.txtTotalQty)
        Me.gbSupplierOrderItems.Controls.Add(Me.Label7)
        Me.gbSupplierOrderItems.Controls.Add(Me.dgSupplierOrderItems)
        Me.gbSupplierOrderItems.Controls.Add(Me.Label15)
        Me.gbSupplierOrderItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSupplierOrderItems.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSupplierOrderItems.Location = New System.Drawing.Point(6, 392)
        Me.gbSupplierOrderItems.Name = "gbSupplierOrderItems"
        Me.gbSupplierOrderItems.Size = New System.Drawing.Size(815, 250)
        Me.gbSupplierOrderItems.TabIndex = 5
        Me.gbSupplierOrderItems.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(9, -2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(161, 17)
        Me.Label15.TabIndex = 228
        Me.Label15.Text = "Purchase Order Items:"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'txtOverallQty
        '
        Me.txtOverallQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtOverallQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOverallQty.Location = New System.Drawing.Point(689, 110)
        Me.txtOverallQty.Name = "txtOverallQty"
        Me.txtOverallQty.ReadOnly = True
        Me.txtOverallQty.Size = New System.Drawing.Size(95, 21)
        Me.txtOverallQty.TabIndex = 34
        Me.txtOverallQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOverallQty
        '
        Me.lblOverallQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOverallQty.AutoSize = True
        Me.lblOverallQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverallQty.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOverallQty.Location = New System.Drawing.Point(696, 92)
        Me.lblOverallQty.Name = "lblOverallQty"
        Me.lblOverallQty.Size = New System.Drawing.Size(84, 15)
        Me.lblOverallQty.TabIndex = 470
        Me.lblOverallQty.Text = "Overall Qty.:"
        '
        'txtOverallPrice
        '
        Me.txtOverallPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtOverallPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOverallPrice.Location = New System.Drawing.Point(675, 153)
        Me.txtOverallPrice.Name = "txtOverallPrice"
        Me.txtOverallPrice.ReadOnly = True
        Me.txtOverallPrice.Size = New System.Drawing.Size(122, 21)
        Me.txtOverallPrice.TabIndex = 35
        Me.txtOverallPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOverallPrice
        '
        Me.lblOverallPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOverallPrice.AutoSize = True
        Me.lblOverallPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverallPrice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOverallPrice.Location = New System.Drawing.Point(692, 135)
        Me.lblOverallPrice.Name = "lblOverallPrice"
        Me.lblOverallPrice.Size = New System.Drawing.Size(93, 15)
        Me.lblOverallPrice.TabIndex = 468
        Me.lblOverallPrice.Text = "Overall Price:"
        '
        'lblOverallPesoSign
        '
        Me.lblOverallPesoSign.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOverallPesoSign.AutoSize = True
        Me.lblOverallPesoSign.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverallPesoSign.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOverallPesoSign.Location = New System.Drawing.Point(659, 156)
        Me.lblOverallPesoSign.Name = "lblOverallPesoSign"
        Me.lblOverallPesoSign.Size = New System.Drawing.Size(16, 15)
        Me.lblOverallPesoSign.TabIndex = 469
        Me.lblOverallPesoSign.Text = "₱"
        '
        'dgProductColorSizes
        '
        Me.dgProductColorSizes.AllowUserToAddRows = False
        Me.dgProductColorSizes.AllowUserToDeleteRows = False
        Me.dgProductColorSizes.AllowUserToOrderColumns = True
        Me.dgProductColorSizes.AllowUserToResizeRows = False
        Me.dgProductColorSizes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgProductColorSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductColorSizes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pcs_rowid, Me.pcs_colorvalue, Me.pcs_productcode, Me.pcs_colorname, Me.pcs_color, Me.pcs_size, Me.pcs_seasoncode, Me.pcs_qtyavailable, Me.pcs_srp, Me.pcs_sku})
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductColorSizes.DefaultCellStyle = DataGridViewCellStyle19
        Me.dgProductColorSizes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductColorSizes.Location = New System.Drawing.Point(9, 55)
        Me.dgProductColorSizes.MultiSelect = False
        Me.dgProductColorSizes.Name = "dgProductColorSizes"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizes.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dgProductColorSizes.RowHeadersVisible = False
        Me.dgProductColorSizes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductColorSizes.Size = New System.Drawing.Size(645, 140)
        Me.dgProductColorSizes.TabIndex = 33
        '
        'pcs_rowid
        '
        Me.pcs_rowid.HeaderText = "rowid"
        Me.pcs_rowid.Name = "pcs_rowid"
        Me.pcs_rowid.Visible = False
        '
        'pcs_colorvalue
        '
        Me.pcs_colorvalue.HeaderText = "colorvalue"
        Me.pcs_colorvalue.Name = "pcs_colorvalue"
        Me.pcs_colorvalue.Visible = False
        '
        'pcs_productcode
        '
        Me.pcs_productcode.HeaderText = "Product Code"
        Me.pcs_productcode.Name = "pcs_productcode"
        Me.pcs_productcode.ReadOnly = True
        Me.pcs_productcode.Width = 120
        '
        'pcs_colorname
        '
        Me.pcs_colorname.HeaderText = "Color Name"
        Me.pcs_colorname.Name = "pcs_colorname"
        Me.pcs_colorname.ReadOnly = True
        Me.pcs_colorname.Width = 60
        '
        'pcs_color
        '
        Me.pcs_color.HeaderText = ""
        Me.pcs_color.Name = "pcs_color"
        Me.pcs_color.ReadOnly = True
        Me.pcs_color.Width = 30
        '
        'pcs_size
        '
        Me.pcs_size.HeaderText = "Size"
        Me.pcs_size.Name = "pcs_size"
        Me.pcs_size.ReadOnly = True
        Me.pcs_size.Width = 50
        '
        'pcs_seasoncode
        '
        Me.pcs_seasoncode.HeaderText = "Season Code"
        Me.pcs_seasoncode.Name = "pcs_seasoncode"
        Me.pcs_seasoncode.ReadOnly = True
        Me.pcs_seasoncode.Width = 70
        '
        'pcs_qtyavailable
        '
        Me.pcs_qtyavailable.HeaderText = "Qty. Available"
        Me.pcs_qtyavailable.Name = "pcs_qtyavailable"
        Me.pcs_qtyavailable.ReadOnly = True
        Me.pcs_qtyavailable.Width = 60
        '
        'pcs_srp
        '
        Me.pcs_srp.HeaderText = "SRP"
        Me.pcs_srp.Name = "pcs_srp"
        Me.pcs_srp.Width = 50
        '
        'pcs_sku
        '
        Me.pcs_sku.HeaderText = "SKU"
        Me.pcs_sku.Name = "pcs_sku"
        Me.pcs_sku.ReadOnly = True
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
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(81, 5)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 193
        '
        'msOrder
        '
        Me.msOrder.Image = CType(resources.GetObject("msOrder.Image"), System.Drawing.Image)
        Me.msOrder.Name = "msOrder"
        Me.msOrder.Size = New System.Drawing.Size(28, 21)
        '
        'msCancel
        '
        Me.msCancel.Image = CType(resources.GetObject("msCancel.Image"), System.Drawing.Image)
        Me.msCancel.Name = "msCancel"
        Me.msCancel.Size = New System.Drawing.Size(76, 21)
        Me.msCancel.Text = "&Cancel"
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'msNew
        '
        Me.msNew.Image = CType(resources.GetObject("msNew.Image"), System.Drawing.Image)
        Me.msNew.Name = "msNew"
        Me.msNew.Size = New System.Drawing.Size(63, 21)
        Me.msNew.Text = "&New"
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
        Me.msPrint.Image = CType(resources.GetObject("msPrint.Image"), System.Drawing.Image)
        Me.msPrint.Name = "msPrint"
        Me.msPrint.Size = New System.Drawing.Size(66, 21)
        Me.msPrint.Text = "&Print"
        '
        'pbAddSupplier
        '
        Me.pbAddSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbAddSupplier.BackColor = System.Drawing.Color.Transparent
        Me.pbAddSupplier.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddSupplier.Image = CType(resources.GetObject("pbAddSupplier.Image"), System.Drawing.Image)
        Me.pbAddSupplier.Location = New System.Drawing.Point(627, 24)
        Me.pbAddSupplier.Name = "pbAddSupplier"
        Me.pbAddSupplier.Size = New System.Drawing.Size(14, 18)
        Me.pbAddSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddSupplier.TabIndex = 435
        Me.pbAddSupplier.TabStop = False
        Me.pbAddSupplier.Tag = ""
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(80, 104)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(185, 40)
        Me.txtComments.TabIndex = 22
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(5, 107)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 15)
        Me.Label25.TabIndex = 434
        Me.Label25.Text = "Comments:"
        '
        'dtpTargetDeliveryDate
        '
        Me.dtpTargetDeliveryDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpTargetDeliveryDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTargetDeliveryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTargetDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTargetDeliveryDate.Location = New System.Drawing.Point(140, 77)
        Me.dtpTargetDeliveryDate.Name = "dtpTargetDeliveryDate"
        Me.dtpTargetDeliveryDate.Size = New System.Drawing.Size(125, 21)
        Me.dtpTargetDeliveryDate.TabIndex = 21
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(5, 78)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(120, 15)
        Me.Label23.TabIndex = 431
        Me.Label23.Text = "Target Delivery Date:"
        '
        'txtRRNo
        '
        Me.txtRRNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRRNo.Location = New System.Drawing.Point(350, 50)
        Me.txtRRNo.Name = "txtRRNo"
        Me.txtRRNo.ReadOnly = True
        Me.txtRRNo.Size = New System.Drawing.Size(110, 21)
        Me.txtRRNo.TabIndex = 25
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(285, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 15)
        Me.Label11.TabIndex = 428
        Me.Label11.Text = "R.R. No.:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(375, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 20)
        Me.Label9.TabIndex = 425
        Me.Label9.Text = "*"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(710, 23)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(95, 21)
        Me.txtStatus.TabIndex = 24
        '
        'dtpSupplierOrderDate
        '
        Me.dtpSupplierOrderDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpSupplierOrderDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpSupplierOrderDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSupplierOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSupplierOrderDate.Location = New System.Drawing.Point(140, 50)
        Me.dtpSupplierOrderDate.Name = "dtpSupplierOrderDate"
        Me.dtpSupplierOrderDate.Size = New System.Drawing.Size(125, 21)
        Me.dtpSupplierOrderDate.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(5, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 15)
        Me.Label2.TabIndex = 422
        Me.Label2.Text = "Purchase Order Date:"
        '
        'cboSupplierName
        '
        Me.cboSupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSupplierName.FormattingEnabled = True
        Me.cboSupplierName.Location = New System.Drawing.Point(395, 23)
        Me.cboSupplierName.Name = "cboSupplierName"
        Me.cboSupplierName.Size = New System.Drawing.Size(230, 23)
        Me.cboSupplierName.TabIndex = 23
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(285, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 15)
        Me.Label14.TabIndex = 420
        Me.Label14.Text = "Supplier Name:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(660, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 414
        Me.Label12.Text = "Status:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(120, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 20)
        Me.Label6.TabIndex = 310
        Me.Label6.Text = "*"
        '
        'txtSupplierOrderNo
        '
        Me.txtSupplierOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplierOrderNo.Location = New System.Drawing.Point(140, 23)
        Me.txtSupplierOrderNo.Name = "txtSupplierOrderNo"
        Me.txtSupplierOrderNo.Size = New System.Drawing.Size(125, 21)
        Me.txtSupplierOrderNo.TabIndex = 19
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(5, 26)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(118, 15)
        Me.Label52.TabIndex = 272
        Me.Label52.Text = "Purchase Order No.:"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.White
        Me.Label55.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label55.Location = New System.Drawing.Point(9, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(207, 17)
        Me.Label55.TabIndex = 228
        Me.Label55.Text = "Purchase Order Information:"
        '
        'gbSupplierOrderInformation
        '
        Me.gbSupplierOrderInformation.Controls.Add(Me.txtReceivedBy)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label27)
        Me.gbSupplierOrderInformation.Controls.Add(Me.txtSealNo)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label26)
        Me.gbSupplierOrderInformation.Controls.Add(Me.txtContainerNo)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label24)
        Me.gbSupplierOrderInformation.Controls.Add(Me.txtBrands)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label22)
        Me.gbSupplierOrderInformation.Controls.Add(Me.txtArrivedIn)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label20)
        Me.gbSupplierOrderInformation.Controls.Add(Me.txtTimeArrived)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label19)
        Me.gbSupplierOrderInformation.Controls.Add(Me.txtRRDate)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label10)
        Me.gbSupplierOrderInformation.Controls.Add(Me.pbAddSupplier)
        Me.gbSupplierOrderInformation.Controls.Add(Me.txtComments)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label25)
        Me.gbSupplierOrderInformation.Controls.Add(Me.dtpTargetDeliveryDate)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label23)
        Me.gbSupplierOrderInformation.Controls.Add(Me.txtRRNo)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label11)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label9)
        Me.gbSupplierOrderInformation.Controls.Add(Me.txtStatus)
        Me.gbSupplierOrderInformation.Controls.Add(Me.dtpSupplierOrderDate)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label2)
        Me.gbSupplierOrderInformation.Controls.Add(Me.cboSupplierName)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label14)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label12)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label6)
        Me.gbSupplierOrderInformation.Controls.Add(Me.txtSupplierOrderNo)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label52)
        Me.gbSupplierOrderInformation.Controls.Add(Me.Label55)
        Me.gbSupplierOrderInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSupplierOrderInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSupplierOrderInformation.Location = New System.Drawing.Point(6, 5)
        Me.gbSupplierOrderInformation.Name = "gbSupplierOrderInformation"
        Me.gbSupplierOrderInformation.Size = New System.Drawing.Size(815, 150)
        Me.gbSupplierOrderInformation.TabIndex = 3
        Me.gbSupplierOrderInformation.TabStop = False
        '
        'txtReceivedBy
        '
        Me.txtReceivedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceivedBy.Location = New System.Drawing.Point(365, 104)
        Me.txtReceivedBy.Name = "txtReceivedBy"
        Me.txtReceivedBy.ReadOnly = True
        Me.txtReceivedBy.Size = New System.Drawing.Size(165, 21)
        Me.txtReceivedBy.TabIndex = 31
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(285, 107)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(77, 15)
        Me.Label27.TabIndex = 449
        Me.Label27.Text = "Received By:"
        '
        'txtSealNo
        '
        Me.txtSealNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSealNo.Location = New System.Drawing.Point(720, 77)
        Me.txtSealNo.Name = "txtSealNo"
        Me.txtSealNo.ReadOnly = True
        Me.txtSealNo.Size = New System.Drawing.Size(85, 21)
        Me.txtSealNo.TabIndex = 30
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(660, 78)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(57, 15)
        Me.Label26.TabIndex = 447
        Me.Label26.Text = "Seal No.:"
        '
        'txtContainerNo
        '
        Me.txtContainerNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContainerNo.Location = New System.Drawing.Point(555, 77)
        Me.txtContainerNo.Name = "txtContainerNo"
        Me.txtContainerNo.ReadOnly = True
        Me.txtContainerNo.Size = New System.Drawing.Size(95, 21)
        Me.txtContainerNo.TabIndex = 29
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(470, 78)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(85, 15)
        Me.Label24.TabIndex = 445
        Me.Label24.Text = "Container No.:"
        '
        'txtBrands
        '
        Me.txtBrands.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrands.Location = New System.Drawing.Point(605, 104)
        Me.txtBrands.Name = "txtBrands"
        Me.txtBrands.ReadOnly = True
        Me.txtBrands.Size = New System.Drawing.Size(200, 21)
        Me.txtBrands.TabIndex = 32
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(540, 107)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(57, 15)
        Me.Label22.TabIndex = 443
        Me.Label22.Text = "Brand(s):"
        '
        'txtArrivedIn
        '
        Me.txtArrivedIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArrivedIn.Location = New System.Drawing.Point(350, 77)
        Me.txtArrivedIn.Name = "txtArrivedIn"
        Me.txtArrivedIn.ReadOnly = True
        Me.txtArrivedIn.Size = New System.Drawing.Size(110, 21)
        Me.txtArrivedIn.TabIndex = 28
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(285, 78)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(60, 15)
        Me.Label20.TabIndex = 441
        Me.Label20.Text = "Arrived In:"
        '
        'txtTimeArrived
        '
        Me.txtTimeArrived.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimeArrived.Location = New System.Drawing.Point(720, 50)
        Me.txtTimeArrived.Name = "txtTimeArrived"
        Me.txtTimeArrived.ReadOnly = True
        Me.txtTimeArrived.Size = New System.Drawing.Size(85, 21)
        Me.txtTimeArrived.TabIndex = 27
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(639, 53)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 15)
        Me.Label19.TabIndex = 439
        Me.Label19.Text = "Time Arrived:"
        '
        'txtRRDate
        '
        Me.txtRRDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRRDate.Location = New System.Drawing.Point(535, 50)
        Me.txtRRDate.Name = "txtRRDate"
        Me.txtRRDate.ReadOnly = True
        Me.txtRRDate.Size = New System.Drawing.Size(100, 21)
        Me.txtRRDate.TabIndex = 26
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(470, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 15)
        Me.Label10.TabIndex = 437
        Me.Label10.Text = "R.R. Date:"
        '
        'c_seqno
        '
        Me.c_seqno.HeaderText = "Seq. No."
        Me.c_seqno.Name = "c_seqno"
        Me.c_seqno.ReadOnly = True
        Me.c_seqno.Width = 77
        '
        'c_color
        '
        Me.c_color.HeaderText = ""
        Me.c_color.Name = "c_color"
        Me.c_color.ReadOnly = True
        Me.c_color.Width = 30
        '
        'cboBy
        '
        Me.cboBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBy.FormattingEnabled = True
        Me.cboBy.Location = New System.Drawing.Point(27, 11)
        Me.cboBy.Name = "cboBy"
        Me.cboBy.Size = New System.Drawing.Size(110, 23)
        Me.cboBy.TabIndex = 27
        '
        'gbAddProductItem
        '
        Me.gbAddProductItem.Controls.Add(Me.cboByPhrase2)
        Me.gbAddProductItem.Controls.Add(Me.txtQtyOrdered)
        Me.gbAddProductItem.Controls.Add(Me.cboByPhrase)
        Me.gbAddProductItem.Controls.Add(Me.btnAddProduct)
        Me.gbAddProductItem.Controls.Add(Me.Label5)
        Me.gbAddProductItem.Controls.Add(Me.cboBy)
        Me.gbAddProductItem.Controls.Add(Me.Label3)
        Me.gbAddProductItem.Location = New System.Drawing.Point(9, 12)
        Me.gbAddProductItem.Name = "gbAddProductItem"
        Me.gbAddProductItem.Size = New System.Drawing.Size(645, 39)
        Me.gbAddProductItem.TabIndex = 26
        Me.gbAddProductItem.TabStop = False
        '
        'txtQtyOrdered
        '
        Me.txtQtyOrdered.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyOrdered.Location = New System.Drawing.Point(502, 11)
        Me.txtQtyOrdered.Name = "txtQtyOrdered"
        Me.txtQtyOrdered.Size = New System.Drawing.Size(45, 21)
        Me.txtQtyOrdered.TabIndex = 29
        '
        'cboByPhrase
        '
        Me.cboByPhrase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboByPhrase.FormattingEnabled = True
        Me.cboByPhrase.Location = New System.Drawing.Point(142, 11)
        Me.cboByPhrase.Name = "cboByPhrase"
        Me.cboByPhrase.Size = New System.Drawing.Size(280, 23)
        Me.cboByPhrase.TabIndex = 28
        '
        'btnAddProduct
        '
        Me.btnAddProduct.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAddProduct.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProduct.Image = CType(resources.GetObject("btnAddProduct.Image"), System.Drawing.Image)
        Me.btnAddProduct.Location = New System.Drawing.Point(572, 7)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(45, 30)
        Me.btnAddProduct.TabIndex = 30
        Me.btnAddProduct.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(445, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 30)
        Me.Label5.TabIndex = 416
        Me.Label5.Text = "Qty." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ordered:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 15)
        Me.Label3.TabIndex = 415
        Me.Label3.Text = "By:"
        '
        'dgSupplierOrderList
        '
        Me.dgSupplierOrderList.AllowUserToAddRows = False
        Me.dgSupplierOrderList.AllowUserToDeleteRows = False
        Me.dgSupplierOrderList.AllowUserToOrderColumns = True
        Me.dgSupplierOrderList.AllowUserToResizeRows = False
        Me.dgSupplierOrderList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgSupplierOrderList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSupplierOrderList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgSupplierOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSupplierOrderList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.so_rowid, Me.so_supplierorderno, Me.so_supplierorderdate, Me.so_suppliername, Me.so_status})
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSupplierOrderList.DefaultCellStyle = DataGridViewCellStyle28
        Me.dgSupplierOrderList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgSupplierOrderList.Location = New System.Drawing.Point(8, 68)
        Me.dgSupplierOrderList.MultiSelect = False
        Me.dgSupplierOrderList.Name = "dgSupplierOrderList"
        Me.dgSupplierOrderList.ReadOnly = True
        Me.dgSupplierOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSupplierOrderList.Size = New System.Drawing.Size(324, 266)
        Me.dgSupplierOrderList.TabIndex = 18
        '
        'so_rowid
        '
        Me.so_rowid.HeaderText = "rowid"
        Me.so_rowid.Name = "so_rowid"
        Me.so_rowid.ReadOnly = True
        Me.so_rowid.Visible = False
        '
        'so_supplierorderno
        '
        Me.so_supplierorderno.HeaderText = "Purchase Order No."
        Me.so_supplierorderno.Name = "so_supplierorderno"
        Me.so_supplierorderno.ReadOnly = True
        '
        'so_supplierorderdate
        '
        Me.so_supplierorderdate.HeaderText = "Purchase Order Date"
        Me.so_supplierorderdate.Name = "so_supplierorderdate"
        Me.so_supplierorderdate.ReadOnly = True
        '
        'so_suppliername
        '
        Me.so_suppliername.HeaderText = "Supplier Name"
        Me.so_suppliername.Name = "so_suppliername"
        Me.so_suppliername.ReadOnly = True
        '
        'so_status
        '
        Me.so_status.HeaderText = "Status"
        Me.so_status.Name = "so_status"
        Me.so_status.ReadOnly = True
        Me.so_status.Width = 80
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(6, -1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(148, 17)
        Me.Label16.TabIndex = 216
        Me.Label16.Text = "Purchase Order List:"
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbSupplierOrderList)
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
        'gbSupplierOrderList
        '
        Me.gbSupplierOrderList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbSupplierOrderList.BackColor = System.Drawing.Color.Transparent
        Me.gbSupplierOrderList.Controls.Add(Me.ToolStrip3)
        Me.gbSupplierOrderList.Controls.Add(Me.Label4)
        Me.gbSupplierOrderList.Controls.Add(Me.txtPage)
        Me.gbSupplierOrderList.Controls.Add(Me.txtPageNo)
        Me.gbSupplierOrderList.Controls.Add(Me.dgSupplierOrderList)
        Me.gbSupplierOrderList.Controls.Add(Me.Label16)
        Me.gbSupplierOrderList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSupplierOrderList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSupplierOrderList.Location = New System.Drawing.Point(6, 181)
        Me.gbSupplierOrderList.Name = "gbSupplierOrderList"
        Me.gbSupplierOrderList.Size = New System.Drawing.Size(340, 340)
        Me.gbSupplierOrderList.TabIndex = 2
        Me.gbSupplierOrderList.TabStop = False
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
        Me.ToolStrip3.TabIndex = 15
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
        'cmdLast
        '
        Me.cmdLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdLast.Image = CType(resources.GetObject("cmdLast.Image"), System.Drawing.Image)
        Me.cmdLast.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(24, 21)
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
        Me.txtPage.TabIndex = 17
        '
        'txtPageNo
        '
        Me.txtPageNo.Location = New System.Drawing.Point(121, 43)
        Me.txtPageNo.Name = "txtPageNo"
        Me.txtPageNo.ReadOnly = True
        Me.txtPageNo.Size = New System.Drawing.Size(101, 21)
        Me.txtPageNo.TabIndex = 16
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
        Me.gbSearch.Size = New System.Drawing.Size(340, 170)
        Me.gbSearch.TabIndex = 1
        Me.gbSearch.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
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
        Me.tabSearch.Size = New System.Drawing.Size(324, 145)
        Me.tabSearch.TabIndex = 6
        '
        'tabSimple
        '
        Me.tabSimple.Controls.Add(Me.txtSimpleSearch)
        Me.tabSimple.Controls.Add(Me.Label30)
        Me.tabSimple.Location = New System.Drawing.Point(4, 29)
        Me.tabSimple.Name = "tabSimple"
        Me.tabSimple.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSimple.Size = New System.Drawing.Size(316, 112)
        Me.tabSimple.TabIndex = 1
        Me.tabSimple.Text = "       Simple       "
        Me.tabSimple.UseVisualStyleBackColor = True
        '
        'txtSimpleSearch
        '
        Me.txtSimpleSearch.Location = New System.Drawing.Point(96, 43)
        Me.txtSimpleSearch.Name = "txtSimpleSearch"
        Me.txtSimpleSearch.Size = New System.Drawing.Size(212, 21)
        Me.txtSimpleSearch.TabIndex = 7
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(2, 45)
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
        Me.tabCommon.Controls.Add(Me.cboSearch4)
        Me.tabCommon.Controls.Add(Me.cboSearch2)
        Me.tabCommon.Controls.Add(Me.cboSearch3)
        Me.tabCommon.Controls.Add(Me.cboSearch1)
        Me.tabCommon.Location = New System.Drawing.Point(4, 29)
        Me.tabCommon.Name = "tabCommon"
        Me.tabCommon.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCommon.Size = New System.Drawing.Size(316, 112)
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
        'cboSearch4
        '
        Me.cboSearch4.FormattingEnabled = True
        Me.cboSearch4.Location = New System.Drawing.Point(112, 80)
        Me.cboSearch4.Name = "cboSearch4"
        Me.cboSearch4.Size = New System.Drawing.Size(198, 23)
        Me.cboSearch4.TabIndex = 14
        '
        'cboSearch2
        '
        Me.cboSearch2.FormattingEnabled = True
        Me.cboSearch2.Location = New System.Drawing.Point(112, 51)
        Me.cboSearch2.Name = "cboSearch2"
        Me.cboSearch2.Size = New System.Drawing.Size(198, 23)
        Me.cboSearch2.TabIndex = 12
        '
        'cboSearch3
        '
        Me.cboSearch3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch3.FormattingEnabled = True
        Me.cboSearch3.Location = New System.Drawing.Point(3, 80)
        Me.cboSearch3.Name = "cboSearch3"
        Me.cboSearch3.Size = New System.Drawing.Size(105, 23)
        Me.cboSearch3.TabIndex = 13
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
        Me.tabDetails.Controls.Add(Me.gbAddProducts)
        Me.tabDetails.Controls.Add(Me.gbSupplierOrderItems)
        Me.tabDetails.Controls.Add(Me.gbSupplierOrderInformation)
        Me.tabDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(828, 472)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "P.O. Details"
        Me.tabDetails.UseVisualStyleBackColor = True
        '
        'gbAddProducts
        '
        Me.gbAddProducts.Controls.Add(Me.txtOverallQty)
        Me.gbAddProducts.Controls.Add(Me.lblOverallQty)
        Me.gbAddProducts.Controls.Add(Me.txtOverallPrice)
        Me.gbAddProducts.Controls.Add(Me.lblOverallPrice)
        Me.gbAddProducts.Controls.Add(Me.lblOverallPesoSign)
        Me.gbAddProducts.Controls.Add(Me.dgProductColorSizes)
        Me.gbAddProducts.Controls.Add(Me.gbAddProductItem)
        Me.gbAddProducts.Controls.Add(Me.Label1)
        Me.gbAddProducts.Controls.Add(Me.dgProductColors)
        Me.gbAddProducts.Controls.Add(Me.dgProductSizes)
        Me.gbAddProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAddProducts.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbAddProducts.Location = New System.Drawing.Point(6, 183)
        Me.gbAddProducts.Name = "gbAddProducts"
        Me.gbAddProducts.Size = New System.Drawing.Size(815, 205)
        Me.gbAddProducts.TabIndex = 4
        Me.gbAddProducts.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(9, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 17)
        Me.Label1.TabIndex = 228
        Me.Label1.Text = "Add Products:"
        '
        'dgProductColors
        '
        Me.dgProductColors.AllowUserToAddRows = False
        Me.dgProductColors.AllowUserToDeleteRows = False
        Me.dgProductColors.AllowUserToOrderColumns = True
        Me.dgProductColors.AllowUserToResizeRows = False
        Me.dgProductColors.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColors.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgProductColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductColors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c_rowid, Me.c_colorvalue, Me.c_seqno, Me.c_colorname, Me.c_color})
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductColors.DefaultCellStyle = DataGridViewCellStyle22
        Me.dgProductColors.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductColors.Location = New System.Drawing.Point(9, 55)
        Me.dgProductColors.MultiSelect = False
        Me.dgProductColors.Name = "dgProductColors"
        Me.dgProductColors.ReadOnly = True
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColors.RowHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgProductColors.RowHeadersVisible = False
        Me.dgProductColors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductColors.Size = New System.Drawing.Size(205, 140)
        Me.dgProductColors.TabIndex = 31
        '
        'c_rowid
        '
        Me.c_rowid.HeaderText = "rowid"
        Me.c_rowid.Name = "c_rowid"
        Me.c_rowid.ReadOnly = True
        Me.c_rowid.Visible = False
        '
        'c_colorvalue
        '
        Me.c_colorvalue.HeaderText = "colorvalue"
        Me.c_colorvalue.Name = "c_colorvalue"
        Me.c_colorvalue.ReadOnly = True
        Me.c_colorvalue.Visible = False
        '
        'c_colorname
        '
        Me.c_colorname.HeaderText = "Color Name"
        Me.c_colorname.Name = "c_colorname"
        Me.c_colorname.ReadOnly = True
        Me.c_colorname.Width = 97
        '
        'dgProductSizes
        '
        Me.dgProductSizes.AllowUserToAddRows = False
        Me.dgProductSizes.AllowUserToDeleteRows = False
        Me.dgProductSizes.AllowUserToOrderColumns = True
        Me.dgProductSizes.AllowUserToResizeRows = False
        Me.dgProductSizes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductSizes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgProductSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductSizes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.s_rowid, Me.s_sizes, Me.s_seasoncode, Me.s_qtyordered, Me.s_qtyavailable, Me.s_srp, Me.s_totalprice, Me.s_sku})
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductSizes.DefaultCellStyle = DataGridViewCellStyle25
        Me.dgProductSizes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductSizes.Location = New System.Drawing.Point(219, 55)
        Me.dgProductSizes.MultiSelect = False
        Me.dgProductSizes.Name = "dgProductSizes"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductSizes.RowHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.dgProductSizes.RowHeadersVisible = False
        Me.dgProductSizes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductSizes.Size = New System.Drawing.Size(433, 140)
        Me.dgProductSizes.TabIndex = 32
        '
        's_rowid
        '
        Me.s_rowid.HeaderText = "rowid"
        Me.s_rowid.Name = "s_rowid"
        Me.s_rowid.Visible = False
        '
        's_sizes
        '
        Me.s_sizes.HeaderText = "Size"
        Me.s_sizes.Name = "s_sizes"
        Me.s_sizes.ReadOnly = True
        Me.s_sizes.Width = 50
        '
        's_seasoncode
        '
        Me.s_seasoncode.HeaderText = "Season Code"
        Me.s_seasoncode.Name = "s_seasoncode"
        Me.s_seasoncode.ReadOnly = True
        Me.s_seasoncode.Width = 70
        '
        's_qtyordered
        '
        Me.s_qtyordered.HeaderText = "Qty. Ordered"
        Me.s_qtyordered.Name = "s_qtyordered"
        Me.s_qtyordered.Width = 60
        '
        's_qtyavailable
        '
        Me.s_qtyavailable.HeaderText = "Qty. Available"
        Me.s_qtyavailable.Name = "s_qtyavailable"
        Me.s_qtyavailable.ReadOnly = True
        Me.s_qtyavailable.Width = 60
        '
        's_srp
        '
        Me.s_srp.HeaderText = "SRP"
        Me.s_srp.Name = "s_srp"
        Me.s_srp.Width = 50
        '
        's_totalprice
        '
        Me.s_totalprice.HeaderText = "Total Price"
        Me.s_totalprice.Name = "s_totalprice"
        Me.s_totalprice.ReadOnly = True
        '
        's_sku
        '
        Me.s_sku.HeaderText = "SKU"
        Me.s_sku.Name = "s_sku"
        Me.s_sku.ReadOnly = True
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
        Me.lblTitle.Text = "Purchase Orders"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboByPhrase2
        '
        Me.cboByPhrase2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboByPhrase2.FormattingEnabled = True
        Me.cboByPhrase2.Location = New System.Drawing.Point(142, 11)
        Me.cboByPhrase2.Name = "cboByPhrase2"
        Me.cboByPhrase2.Size = New System.Drawing.Size(280, 23)
        Me.cboByPhrase2.TabIndex = 471
        '
        'PurchaseForm
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
        Me.Name = "PurchaseForm"
        Me.Text = "PurchaseForm"
        CType(Me.dgSupplierOrderItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSupplierOrderItems.ResumeLayout(False)
        Me.gbSupplierOrderItems.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgProductColorSizes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.pbAddSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSupplierOrderInformation.ResumeLayout(False)
        Me.gbSupplierOrderInformation.PerformLayout()
        Me.gbAddProductItem.ResumeLayout(False)
        Me.gbAddProductItem.PerformLayout()
        CType(Me.dgSupplierOrderList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbSupplierOrderList.ResumeLayout(False)
        Me.gbSupplierOrderList.PerformLayout()
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
        Me.gbAddProducts.ResumeLayout(False)
        Me.gbAddProducts.PerformLayout()
        CType(Me.dgProductColors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgProductSizes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkOtherInfo As System.Windows.Forms.CheckBox
    Friend WithEvents txtTotalPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalItems As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgSupplierOrderItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbSupplierOrderItems As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbSupplierOrderList As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPage As System.Windows.Forms.TextBox
    Friend WithEvents txtPageNo As System.Windows.Forms.TextBox
    Friend WithEvents dgSupplierOrderList As DevComponents.DotNetBar.Controls.DataGridViewX
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
    Friend WithEvents cboSearch4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch1 As System.Windows.Forms.ComboBox
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents gbAddProducts As System.Windows.Forms.GroupBox
    Friend WithEvents txtOverallQty As System.Windows.Forms.TextBox
    Friend WithEvents lblOverallQty As System.Windows.Forms.Label
    Friend WithEvents txtOverallPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblOverallPrice As System.Windows.Forms.Label
    Friend WithEvents lblOverallPesoSign As System.Windows.Forms.Label
    Friend WithEvents dgProductColorSizes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbAddProductItem As System.Windows.Forms.GroupBox
    Friend WithEvents txtQtyOrdered As System.Windows.Forms.TextBox
    Friend WithEvents cboByPhrase As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddProduct As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgProductColors As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents c_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgProductSizes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbSupplierOrderInformation As System.Windows.Forms.GroupBox
    Friend WithEvents pbAddSupplier As System.Windows.Forms.PictureBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dtpTargetDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtRRNo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents dtpSupplierOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSupplierName As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSupplierOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msOrder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents so_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents so_supplierorderno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents so_supplierorderdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents so_suppliername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents so_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_qtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_srp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents msPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ci_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_pcsrowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_bid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtyordered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtyreceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtybad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_srp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_totalprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_reason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_itemtype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_option As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents s_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_sizes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_qtyordered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_qtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_srp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_totalprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtRRDate As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTimeArrived As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtArrivedIn As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtBrands As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtContainerNo As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtSealNo As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtReceivedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboByPhrase2 As SergeUtils.EasyCompletionComboBox
End Class
