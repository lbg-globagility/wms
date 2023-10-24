<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerOrdersForm
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
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerOrdersForm))
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgProductSizes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.s_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_sizes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_qtyordered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_qtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_qtyallocated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_qtyorderable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_qtyreserve = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_srp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_totalprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtQtyOrdered = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.cboByPhrase = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgProductColors = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.c_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboBy = New System.Windows.Forms.ComboBox()
        Me.gbAddProductItem = New System.Windows.Forms.GroupBox()
        Me.pbAddTags = New System.Windows.Forms.PictureBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cboTags = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgCustomerOrderList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.co_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_customerorderno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_pono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_customerorderdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_customername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbCustomerOrderList = New System.Windows.Forms.GroupBox()
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
        Me.txtBundleSRP = New System.Windows.Forms.TextBox()
        Me.lblSRP = New System.Windows.Forms.Label()
        Me.txtOverallQty = New System.Windows.Forms.TextBox()
        Me.lblOverallQty = New System.Windows.Forms.Label()
        Me.txtOverallPrice = New System.Windows.Forms.TextBox()
        Me.lblOverallPrice = New System.Windows.Forms.Label()
        Me.lblOverallPesoSign = New System.Windows.Forms.Label()
        Me.dgBundleItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.bi_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_pcsrowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_qtybundle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_totalqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_qtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_qtyallocated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_qtyorderable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_qtyreserve = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgProductColorSizes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pcs_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_qtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_qtyallocated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_qtyorderable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_qtyreserve = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_srp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_unitmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbCustomerOrderItems = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lnkEditBundleItems = New System.Windows.Forms.LinkLabel()
        Me.chkOtherInfo = New System.Windows.Forms.CheckBox()
        Me.txtTotalPrice = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalItems = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalQty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgCustomerOrderItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
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
        Me.ci_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtyordered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtypicked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtydelivered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_srp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_totalprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_tags = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ci_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_verifiedby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_verifieddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_packedby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_packeddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_deliveredby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_delivereddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_option = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.gbCustomerOrderInformation = New System.Windows.Forms.GroupBox()
        Me.cboCustomerOrderType = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cboAgent = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cboInventoryLocation = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.pbAddClassDescription = New System.Windows.Forms.PictureBox()
        Me.cboClassDescription = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.pbAddBranchCodeName = New System.Windows.Forms.PictureBox()
        Me.cboBranchCodeNameInfo = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.pbAddVendorCodeName = New System.Windows.Forms.PictureBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cboVendorCodeNameInfo = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.pbSaveSIDRNo = New System.Windows.Forms.PictureBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtSIDRNo = New System.Windows.Forms.TextBox()
        Me.txtDateSubmitted = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtCustomerOrderNo = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtDeliveryAddress = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtDeliveryHours = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pbAddCustomer = New System.Windows.Forms.PictureBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtPickListNo = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtLineUpNos = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.dtpCustomerOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCustomerName = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPONo = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.msCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.msOrder = New System.Windows.Forms.ToolStripMenuItem()
        Me.msDuplicate = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSubmit = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.DataSetA = New Warehouse_Management_System.DataSetA()
        Me.DataSetABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnAddAgent = New System.Windows.Forms.PictureBox()
        CType(Me.dgProductSizes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgProductColors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAddProductItem.SuspendLayout()
        CType(Me.pbAddTags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCustomerOrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbCustomerOrderList.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.tabSimple.SuspendLayout()
        Me.tabCommon.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.gbAddProducts.SuspendLayout()
        CType(Me.dgBundleItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgProductColorSizes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCustomerOrderItems.SuspendLayout()
        CType(Me.dgCustomerOrderItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCustomerOrderInformation.SuspendLayout()
        CType(Me.pbAddClassDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddBranchCodeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddVendorCodeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSaveSIDRNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msMenu.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAddAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgProductSizes
        '
        Me.dgProductSizes.AllowUserToAddRows = False
        Me.dgProductSizes.AllowUserToDeleteRows = False
        Me.dgProductSizes.AllowUserToOrderColumns = True
        Me.dgProductSizes.AllowUserToResizeRows = False
        Me.dgProductSizes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductSizes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgProductSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductSizes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.s_rowid, Me.s_colorvalue, Me.s_productcode, Me.s_colorname, Me.s_sizes, Me.s_seasoncode, Me.s_qtyordered, Me.s_qtyavailable, Me.s_qtyallocated, Me.s_qtyorderable, Me.s_qtyreserve, Me.s_srp, Me.s_totalprice, Me.s_sku, Me.s_unitofmeasure})
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductSizes.DefaultCellStyle = DataGridViewCellStyle19
        Me.dgProductSizes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductSizes.Location = New System.Drawing.Point(219, 55)
        Me.dgProductSizes.MultiSelect = False
        Me.dgProductSizes.Name = "dgProductSizes"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductSizes.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dgProductSizes.RowHeadersVisible = False
        Me.dgProductSizes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductSizes.Size = New System.Drawing.Size(435, 145)
        Me.dgProductSizes.TabIndex = 44
        '
        's_rowid
        '
        Me.s_rowid.HeaderText = "rowid"
        Me.s_rowid.Name = "s_rowid"
        Me.s_rowid.Visible = False
        '
        's_colorvalue
        '
        Me.s_colorvalue.HeaderText = "colorvalue"
        Me.s_colorvalue.Name = "s_colorvalue"
        Me.s_colorvalue.Visible = False
        '
        's_productcode
        '
        Me.s_productcode.HeaderText = "productcode"
        Me.s_productcode.Name = "s_productcode"
        Me.s_productcode.Visible = False
        '
        's_colorname
        '
        Me.s_colorname.HeaderText = "colorname"
        Me.s_colorname.Name = "s_colorname"
        Me.s_colorname.Visible = False
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
        Me.s_qtyordered.HeaderText = "Qty. Order"
        Me.s_qtyordered.Name = "s_qtyordered"
        Me.s_qtyordered.Width = 60
        '
        's_qtyavailable
        '
        Me.s_qtyavailable.HeaderText = "Qty. Available"
        Me.s_qtyavailable.Name = "s_qtyavailable"
        Me.s_qtyavailable.ReadOnly = True
        Me.s_qtyavailable.Visible = False
        Me.s_qtyavailable.Width = 60
        '
        's_qtyallocated
        '
        Me.s_qtyallocated.HeaderText = "Qty. Allocated"
        Me.s_qtyallocated.Name = "s_qtyallocated"
        Me.s_qtyallocated.ReadOnly = True
        Me.s_qtyallocated.Visible = False
        Me.s_qtyallocated.Width = 60
        '
        's_qtyorderable
        '
        Me.s_qtyorderable.HeaderText = "Qty. Orderable"
        Me.s_qtyorderable.Name = "s_qtyorderable"
        Me.s_qtyorderable.ReadOnly = True
        Me.s_qtyorderable.Width = 70
        '
        's_qtyreserve
        '
        Me.s_qtyreserve.HeaderText = "Qty. Reserve"
        Me.s_qtyreserve.Name = "s_qtyreserve"
        Me.s_qtyreserve.ReadOnly = True
        Me.s_qtyreserve.Width = 60
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
        's_unitofmeasure
        '
        Me.s_unitofmeasure.HeaderText = "Unit Of Measure"
        Me.s_unitofmeasure.Name = "s_unitofmeasure"
        Me.s_unitofmeasure.ReadOnly = True
        Me.s_unitofmeasure.Width = 70
        '
        'txtQtyOrdered
        '
        Me.txtQtyOrdered.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyOrdered.Location = New System.Drawing.Point(500, 12)
        Me.txtQtyOrdered.Name = "txtQtyOrdered"
        Me.txtQtyOrdered.Size = New System.Drawing.Size(45, 21)
        Me.txtQtyOrdered.TabIndex = 40
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(457, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 30)
        Me.Label5.TabIndex = 416
        Me.Label5.Text = "Qty." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Order:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAddProduct
        '
        Me.btnAddProduct.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAddProduct.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProduct.Image = CType(resources.GetObject("btnAddProduct.Image"), System.Drawing.Image)
        Me.btnAddProduct.Location = New System.Drawing.Point(739, 7)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(45, 30)
        Me.btnAddProduct.TabIndex = 42
        Me.btnAddProduct.UseVisualStyleBackColor = False
        '
        'cboByPhrase
        '
        Me.cboByPhrase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboByPhrase.FormattingEnabled = True
        Me.cboByPhrase.Location = New System.Drawing.Point(147, 11)
        Me.cboByPhrase.Name = "cboByPhrase"
        Me.cboByPhrase.Size = New System.Drawing.Size(285, 23)
        Me.cboByPhrase.TabIndex = 39
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
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColors.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgProductColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductColors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c_rowid, Me.c_colorvalue, Me.c_seqno, Me.c_colorname, Me.c_color})
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.dgProductColors.Size = New System.Drawing.Size(205, 145)
        Me.dgProductColors.TabIndex = 43
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
        'c_seqno
        '
        Me.c_seqno.HeaderText = "Seq. No."
        Me.c_seqno.Name = "c_seqno"
        Me.c_seqno.ReadOnly = True
        Me.c_seqno.Width = 60
        '
        'c_colorname
        '
        Me.c_colorname.HeaderText = "Color Name"
        Me.c_colorname.Name = "c_colorname"
        Me.c_colorname.ReadOnly = True
        Me.c_colorname.Width = 97
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
        Me.cboBy.Size = New System.Drawing.Size(115, 23)
        Me.cboBy.TabIndex = 38
        '
        'gbAddProductItem
        '
        Me.gbAddProductItem.Controls.Add(Me.pbAddTags)
        Me.gbAddProductItem.Controls.Add(Me.Label32)
        Me.gbAddProductItem.Controls.Add(Me.cboTags)
        Me.gbAddProductItem.Controls.Add(Me.txtQtyOrdered)
        Me.gbAddProductItem.Controls.Add(Me.cboByPhrase)
        Me.gbAddProductItem.Controls.Add(Me.btnAddProduct)
        Me.gbAddProductItem.Controls.Add(Me.Label5)
        Me.gbAddProductItem.Controls.Add(Me.cboBy)
        Me.gbAddProductItem.Controls.Add(Me.Label3)
        Me.gbAddProductItem.Location = New System.Drawing.Point(9, 12)
        Me.gbAddProductItem.Name = "gbAddProductItem"
        Me.gbAddProductItem.Size = New System.Drawing.Size(796, 39)
        Me.gbAddProductItem.TabIndex = 37
        Me.gbAddProductItem.TabStop = False
        '
        'pbAddTags
        '
        Me.pbAddTags.BackColor = System.Drawing.Color.Transparent
        Me.pbAddTags.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddTags.Image = CType(resources.GetObject("pbAddTags.Image"), System.Drawing.Image)
        Me.pbAddTags.Location = New System.Drawing.Point(704, 13)
        Me.pbAddTags.Name = "pbAddTags"
        Me.pbAddTags.Size = New System.Drawing.Size(14, 18)
        Me.pbAddTags.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddTags.TabIndex = 474
        Me.pbAddTags.TabStop = False
        Me.pbAddTags.Tag = ""
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(565, 14)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(37, 15)
        Me.Label32.TabIndex = 474
        Me.Label32.Text = "Tags:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboTags
        '
        Me.cboTags.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTags.FormattingEnabled = True
        Me.cboTags.Location = New System.Drawing.Point(605, 11)
        Me.cboTags.Name = "cboTags"
        Me.cboTags.Size = New System.Drawing.Size(95, 23)
        Me.cboTags.TabIndex = 41
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
        'dgCustomerOrderList
        '
        Me.dgCustomerOrderList.AllowUserToAddRows = False
        Me.dgCustomerOrderList.AllowUserToDeleteRows = False
        Me.dgCustomerOrderList.AllowUserToOrderColumns = True
        Me.dgCustomerOrderList.AllowUserToResizeRows = False
        Me.dgCustomerOrderList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgCustomerOrderList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerOrderList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgCustomerOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomerOrderList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.co_rowid, Me.co_customerorderno, Me.co_pono, Me.co_customerorderdate, Me.co_customername, Me.co_status})
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCustomerOrderList.DefaultCellStyle = DataGridViewCellStyle25
        Me.dgCustomerOrderList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCustomerOrderList.Location = New System.Drawing.Point(8, 68)
        Me.dgCustomerOrderList.MultiSelect = False
        Me.dgCustomerOrderList.Name = "dgCustomerOrderList"
        Me.dgCustomerOrderList.ReadOnly = True
        Me.dgCustomerOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCustomerOrderList.Size = New System.Drawing.Size(324, 266)
        Me.dgCustomerOrderList.TabIndex = 18
        '
        'co_rowid
        '
        Me.co_rowid.HeaderText = "rowid"
        Me.co_rowid.Name = "co_rowid"
        Me.co_rowid.ReadOnly = True
        Me.co_rowid.Visible = False
        '
        'co_customerorderno
        '
        Me.co_customerorderno.HeaderText = "Customer Order No."
        Me.co_customerorderno.Name = "co_customerorderno"
        Me.co_customerorderno.ReadOnly = True
        Me.co_customerorderno.Width = 90
        '
        'co_pono
        '
        Me.co_pono.HeaderText = "P.O. No."
        Me.co_pono.Name = "co_pono"
        Me.co_pono.ReadOnly = True
        Me.co_pono.Width = 80
        '
        'co_customerorderdate
        '
        Me.co_customerorderdate.HeaderText = "Customer Order Date"
        Me.co_customerorderdate.Name = "co_customerorderdate"
        Me.co_customerorderdate.ReadOnly = True
        '
        'co_customername
        '
        Me.co_customername.HeaderText = "Customer Name"
        Me.co_customername.Name = "co_customername"
        Me.co_customername.ReadOnly = True
        '
        'co_status
        '
        Me.co_status.HeaderText = "Status"
        Me.co_status.Name = "co_status"
        Me.co_status.ReadOnly = True
        Me.co_status.Width = 80
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Pink
        Me.Label16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(6, -1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(151, 17)
        Me.Label16.TabIndex = 216
        Me.Label16.Text = "Customer Order List:"
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Pink
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbCustomerOrderList)
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
        Me.SplitContainer1.TabIndex = 236
        '
        'gbCustomerOrderList
        '
        Me.gbCustomerOrderList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbCustomerOrderList.BackColor = System.Drawing.Color.Transparent
        Me.gbCustomerOrderList.Controls.Add(Me.ToolStrip3)
        Me.gbCustomerOrderList.Controls.Add(Me.Label4)
        Me.gbCustomerOrderList.Controls.Add(Me.txtPage)
        Me.gbCustomerOrderList.Controls.Add(Me.txtPageNo)
        Me.gbCustomerOrderList.Controls.Add(Me.dgCustomerOrderList)
        Me.gbCustomerOrderList.Controls.Add(Me.Label16)
        Me.gbCustomerOrderList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCustomerOrderList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCustomerOrderList.Location = New System.Drawing.Point(6, 181)
        Me.gbCustomerOrderList.Name = "gbCustomerOrderList"
        Me.gbCustomerOrderList.Size = New System.Drawing.Size(340, 340)
        Me.gbCustomerOrderList.TabIndex = 2
        Me.gbCustomerOrderList.TabStop = False
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
        Me.ToolStrip3.Text = "toolbar1"
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
        Me.Label21.BackColor = System.Drawing.Color.Pink
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
        Me.tabDetails.Controls.Add(Me.gbCustomerOrderItems)
        Me.tabDetails.Controls.Add(Me.gbCustomerOrderInformation)
        Me.tabDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(828, 472)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "C.O. Details"
        Me.tabDetails.UseVisualStyleBackColor = True
        '
        'gbAddProducts
        '
        Me.gbAddProducts.Controls.Add(Me.txtBundleSRP)
        Me.gbAddProducts.Controls.Add(Me.lblSRP)
        Me.gbAddProducts.Controls.Add(Me.txtOverallQty)
        Me.gbAddProducts.Controls.Add(Me.lblOverallQty)
        Me.gbAddProducts.Controls.Add(Me.txtOverallPrice)
        Me.gbAddProducts.Controls.Add(Me.lblOverallPrice)
        Me.gbAddProducts.Controls.Add(Me.lblOverallPesoSign)
        Me.gbAddProducts.Controls.Add(Me.gbAddProductItem)
        Me.gbAddProducts.Controls.Add(Me.Label1)
        Me.gbAddProducts.Controls.Add(Me.dgProductSizes)
        Me.gbAddProducts.Controls.Add(Me.dgProductColors)
        Me.gbAddProducts.Controls.Add(Me.dgBundleItems)
        Me.gbAddProducts.Controls.Add(Me.dgProductColorSizes)
        Me.gbAddProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAddProducts.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbAddProducts.Location = New System.Drawing.Point(6, 292)
        Me.gbAddProducts.Name = "gbAddProducts"
        Me.gbAddProducts.Size = New System.Drawing.Size(815, 181)
        Me.gbAddProducts.TabIndex = 4
        Me.gbAddProducts.TabStop = False
        '
        'txtBundleSRP
        '
        Me.txtBundleSRP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtBundleSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBundleSRP.Location = New System.Drawing.Point(697, 54)
        Me.txtBundleSRP.Name = "txtBundleSRP"
        Me.txtBundleSRP.Size = New System.Drawing.Size(95, 21)
        Me.txtBundleSRP.TabIndex = 47
        Me.txtBundleSRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSRP
        '
        Me.lblSRP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSRP.AutoSize = True
        Me.lblSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSRP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSRP.Location = New System.Drawing.Point(722, 36)
        Me.lblSRP.Name = "lblSRP"
        Me.lblSRP.Size = New System.Drawing.Size(39, 15)
        Me.lblSRP.TabIndex = 473
        Me.lblSRP.Text = "SRP:"
        '
        'txtOverallQty
        '
        Me.txtOverallQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtOverallQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOverallQty.Location = New System.Drawing.Point(697, 96)
        Me.txtOverallQty.Name = "txtOverallQty"
        Me.txtOverallQty.ReadOnly = True
        Me.txtOverallQty.Size = New System.Drawing.Size(95, 21)
        Me.txtOverallQty.TabIndex = 48
        Me.txtOverallQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOverallQty
        '
        Me.lblOverallQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOverallQty.AutoSize = True
        Me.lblOverallQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverallQty.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOverallQty.Location = New System.Drawing.Point(704, 78)
        Me.lblOverallQty.Name = "lblOverallQty"
        Me.lblOverallQty.Size = New System.Drawing.Size(84, 15)
        Me.lblOverallQty.TabIndex = 470
        Me.lblOverallQty.Text = "Overall Qty.:"
        '
        'txtOverallPrice
        '
        Me.txtOverallPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtOverallPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOverallPrice.Location = New System.Drawing.Point(683, 139)
        Me.txtOverallPrice.Name = "txtOverallPrice"
        Me.txtOverallPrice.ReadOnly = True
        Me.txtOverallPrice.Size = New System.Drawing.Size(122, 21)
        Me.txtOverallPrice.TabIndex = 49
        Me.txtOverallPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOverallPrice
        '
        Me.lblOverallPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOverallPrice.AutoSize = True
        Me.lblOverallPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverallPrice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOverallPrice.Location = New System.Drawing.Point(700, 121)
        Me.lblOverallPrice.Name = "lblOverallPrice"
        Me.lblOverallPrice.Size = New System.Drawing.Size(93, 15)
        Me.lblOverallPrice.TabIndex = 468
        Me.lblOverallPrice.Text = "Overall Price:"
        '
        'lblOverallPesoSign
        '
        Me.lblOverallPesoSign.AutoSize = True
        Me.lblOverallPesoSign.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverallPesoSign.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOverallPesoSign.Location = New System.Drawing.Point(665, 170)
        Me.lblOverallPesoSign.Name = "lblOverallPesoSign"
        Me.lblOverallPesoSign.Size = New System.Drawing.Size(16, 15)
        Me.lblOverallPesoSign.TabIndex = 469
        Me.lblOverallPesoSign.Text = "₱"
        '
        'dgBundleItems
        '
        Me.dgBundleItems.AllowUserToAddRows = False
        Me.dgBundleItems.AllowUserToDeleteRows = False
        Me.dgBundleItems.AllowUserToOrderColumns = True
        Me.dgBundleItems.AllowUserToResizeRows = False
        Me.dgBundleItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBundleItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.dgBundleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBundleItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bi_rowid, Me.bi_pcsrowid, Me.bi_colorvalue, Me.bi_seqno, Me.bi_productcode, Me.bi_colorname, Me.bi_color, Me.bi_size, Me.bi_seasoncode, Me.bi_qtybundle, Me.bi_totalqty, Me.bi_qtyavailable, Me.bi_qtyallocated, Me.bi_qtyorderable, Me.bi_qtyreserve, Me.bi_sku})
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgBundleItems.DefaultCellStyle = DataGridViewCellStyle27
        Me.dgBundleItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgBundleItems.Location = New System.Drawing.Point(9, 55)
        Me.dgBundleItems.MultiSelect = False
        Me.dgBundleItems.Name = "dgBundleItems"
        Me.dgBundleItems.ReadOnly = True
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBundleItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle28
        Me.dgBundleItems.RowHeadersVisible = False
        Me.dgBundleItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgBundleItems.Size = New System.Drawing.Size(645, 145)
        Me.dgBundleItems.TabIndex = 46
        '
        'bi_rowid
        '
        Me.bi_rowid.HeaderText = "rowid"
        Me.bi_rowid.Name = "bi_rowid"
        Me.bi_rowid.ReadOnly = True
        Me.bi_rowid.Visible = False
        '
        'bi_pcsrowid
        '
        Me.bi_pcsrowid.HeaderText = "pcsrowid"
        Me.bi_pcsrowid.Name = "bi_pcsrowid"
        Me.bi_pcsrowid.ReadOnly = True
        Me.bi_pcsrowid.Visible = False
        '
        'bi_colorvalue
        '
        Me.bi_colorvalue.HeaderText = "colorvalue"
        Me.bi_colorvalue.Name = "bi_colorvalue"
        Me.bi_colorvalue.ReadOnly = True
        Me.bi_colorvalue.Visible = False
        '
        'bi_seqno
        '
        Me.bi_seqno.HeaderText = "Seq. No."
        Me.bi_seqno.Name = "bi_seqno"
        Me.bi_seqno.ReadOnly = True
        Me.bi_seqno.Width = 40
        '
        'bi_productcode
        '
        Me.bi_productcode.HeaderText = "Product Code"
        Me.bi_productcode.Name = "bi_productcode"
        Me.bi_productcode.ReadOnly = True
        Me.bi_productcode.Width = 120
        '
        'bi_colorname
        '
        Me.bi_colorname.HeaderText = "Color Name"
        Me.bi_colorname.Name = "bi_colorname"
        Me.bi_colorname.ReadOnly = True
        Me.bi_colorname.Width = 60
        '
        'bi_color
        '
        Me.bi_color.HeaderText = ""
        Me.bi_color.Name = "bi_color"
        Me.bi_color.ReadOnly = True
        Me.bi_color.Width = 30
        '
        'bi_size
        '
        Me.bi_size.HeaderText = "Size"
        Me.bi_size.Name = "bi_size"
        Me.bi_size.ReadOnly = True
        Me.bi_size.Width = 40
        '
        'bi_seasoncode
        '
        Me.bi_seasoncode.HeaderText = "Season Code"
        Me.bi_seasoncode.Name = "bi_seasoncode"
        Me.bi_seasoncode.ReadOnly = True
        Me.bi_seasoncode.Width = 70
        '
        'bi_qtybundle
        '
        Me.bi_qtybundle.HeaderText = "Qty. Bundle"
        Me.bi_qtybundle.Name = "bi_qtybundle"
        Me.bi_qtybundle.ReadOnly = True
        Me.bi_qtybundle.Width = 60
        '
        'bi_totalqty
        '
        Me.bi_totalqty.HeaderText = "Total Qty. Order"
        Me.bi_totalqty.Name = "bi_totalqty"
        Me.bi_totalqty.ReadOnly = True
        Me.bi_totalqty.Width = 88
        '
        'bi_qtyavailable
        '
        Me.bi_qtyavailable.HeaderText = "Qty. Available"
        Me.bi_qtyavailable.Name = "bi_qtyavailable"
        Me.bi_qtyavailable.ReadOnly = True
        Me.bi_qtyavailable.Visible = False
        Me.bi_qtyavailable.Width = 60
        '
        'bi_qtyallocated
        '
        Me.bi_qtyallocated.HeaderText = "Qty. Allocated"
        Me.bi_qtyallocated.Name = "bi_qtyallocated"
        Me.bi_qtyallocated.ReadOnly = True
        Me.bi_qtyallocated.Visible = False
        Me.bi_qtyallocated.Width = 60
        '
        'bi_qtyorderable
        '
        Me.bi_qtyorderable.HeaderText = "Qty. Orderable"
        Me.bi_qtyorderable.Name = "bi_qtyorderable"
        Me.bi_qtyorderable.ReadOnly = True
        Me.bi_qtyorderable.Width = 70
        '
        'bi_qtyreserve
        '
        Me.bi_qtyreserve.HeaderText = "Qty. Reserve"
        Me.bi_qtyreserve.Name = "bi_qtyreserve"
        Me.bi_qtyreserve.ReadOnly = True
        Me.bi_qtyreserve.Width = 60
        '
        'bi_sku
        '
        Me.bi_sku.HeaderText = "SKU"
        Me.bi_sku.Name = "bi_sku"
        Me.bi_sku.ReadOnly = True
        '
        'dgProductColorSizes
        '
        Me.dgProductColorSizes.AllowUserToAddRows = False
        Me.dgProductColorSizes.AllowUserToDeleteRows = False
        Me.dgProductColorSizes.AllowUserToOrderColumns = True
        Me.dgProductColorSizes.AllowUserToResizeRows = False
        Me.dgProductColorSizes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle29
        Me.dgProductColorSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductColorSizes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pcs_rowid, Me.pcs_colorvalue, Me.pcs_productcode, Me.pcs_colorname, Me.pcs_color, Me.pcs_size, Me.pcs_seasoncode, Me.pcs_qtyavailable, Me.pcs_qtyallocated, Me.pcs_qtyorderable, Me.pcs_qtyreserve, Me.pcs_srp, Me.pcs_sku, Me.pcs_unitmeasure})
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductColorSizes.DefaultCellStyle = DataGridViewCellStyle30
        Me.dgProductColorSizes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductColorSizes.Location = New System.Drawing.Point(9, 55)
        Me.dgProductColorSizes.MultiSelect = False
        Me.dgProductColorSizes.Name = "dgProductColorSizes"
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizes.RowHeadersDefaultCellStyle = DataGridViewCellStyle31
        Me.dgProductColorSizes.RowHeadersVisible = False
        Me.dgProductColorSizes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductColorSizes.Size = New System.Drawing.Size(645, 145)
        Me.dgProductColorSizes.TabIndex = 45
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
        Me.pcs_qtyavailable.Visible = False
        Me.pcs_qtyavailable.Width = 60
        '
        'pcs_qtyallocated
        '
        Me.pcs_qtyallocated.HeaderText = "Qty. Allocated"
        Me.pcs_qtyallocated.Name = "pcs_qtyallocated"
        Me.pcs_qtyallocated.ReadOnly = True
        Me.pcs_qtyallocated.Visible = False
        Me.pcs_qtyallocated.Width = 60
        '
        'pcs_qtyorderable
        '
        Me.pcs_qtyorderable.HeaderText = "Qty. Orderable"
        Me.pcs_qtyorderable.Name = "pcs_qtyorderable"
        Me.pcs_qtyorderable.ReadOnly = True
        Me.pcs_qtyorderable.Width = 70
        '
        'pcs_qtyreserve
        '
        Me.pcs_qtyreserve.HeaderText = "Qty. Reserve"
        Me.pcs_qtyreserve.Name = "pcs_qtyreserve"
        Me.pcs_qtyreserve.ReadOnly = True
        Me.pcs_qtyreserve.Width = 60
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
        'pcs_unitmeasure
        '
        Me.pcs_unitmeasure.HeaderText = "Unit Of Measure"
        Me.pcs_unitmeasure.Name = "pcs_unitmeasure"
        Me.pcs_unitmeasure.ReadOnly = True
        Me.pcs_unitmeasure.Width = 70
        '
        'gbCustomerOrderItems
        '
        Me.gbCustomerOrderItems.Controls.Add(Me.Label17)
        Me.gbCustomerOrderItems.Controls.Add(Me.lnkEditBundleItems)
        Me.gbCustomerOrderItems.Controls.Add(Me.chkOtherInfo)
        Me.gbCustomerOrderItems.Controls.Add(Me.txtTotalPrice)
        Me.gbCustomerOrderItems.Controls.Add(Me.Label13)
        Me.gbCustomerOrderItems.Controls.Add(Me.txtTotalItems)
        Me.gbCustomerOrderItems.Controls.Add(Me.Label8)
        Me.gbCustomerOrderItems.Controls.Add(Me.txtTotalQty)
        Me.gbCustomerOrderItems.Controls.Add(Me.Label7)
        Me.gbCustomerOrderItems.Controls.Add(Me.dgCustomerOrderItems)
        Me.gbCustomerOrderItems.Controls.Add(Me.Label15)
        Me.gbCustomerOrderItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCustomerOrderItems.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCustomerOrderItems.Location = New System.Drawing.Point(6, 478)
        Me.gbCustomerOrderItems.Name = "gbCustomerOrderItems"
        Me.gbCustomerOrderItems.Size = New System.Drawing.Size(815, 260)
        Me.gbCustomerOrderItems.TabIndex = 5
        Me.gbCustomerOrderItems.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(669, 237)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(16, 15)
        Me.Label17.TabIndex = 466
        Me.Label17.Text = "₱"
        '
        'lnkEditBundleItems
        '
        Me.lnkEditBundleItems.AutoSize = True
        Me.lnkEditBundleItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkEditBundleItems.Location = New System.Drawing.Point(133, 232)
        Me.lnkEditBundleItems.Name = "lnkEditBundleItems"
        Me.lnkEditBundleItems.Size = New System.Drawing.Size(135, 15)
        Me.lnkEditBundleItems.TabIndex = 52
        Me.lnkEditBundleItems.TabStop = True
        Me.lnkEditBundleItems.Text = "View/Edit Bundle Items:"
        '
        'chkOtherInfo
        '
        Me.chkOtherInfo.AutoSize = True
        Me.chkOtherInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOtherInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOtherInfo.Location = New System.Drawing.Point(5, 231)
        Me.chkOtherInfo.Name = "chkOtherInfo"
        Me.chkOtherInfo.Size = New System.Drawing.Size(114, 19)
        Me.chkOtherInfo.TabIndex = 51
        Me.chkOtherInfo.Text = "View Other Info.:"
        Me.chkOtherInfo.UseVisualStyleBackColor = True
        '
        'txtTotalPrice
        '
        Me.txtTotalPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrice.Location = New System.Drawing.Point(689, 234)
        Me.txtTotalPrice.Name = "txtTotalPrice"
        Me.txtTotalPrice.ReadOnly = True
        Me.txtTotalPrice.Size = New System.Drawing.Size(120, 21)
        Me.txtTotalPrice.TabIndex = 55
        Me.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(600, 231)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 26)
        Me.Label13.TabIndex = 465
        Me.Label13.Text = "Total Price" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Sum):"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalItems
        '
        Me.txtTotalItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalItems.Location = New System.Drawing.Point(334, 234)
        Me.txtTotalItems.Name = "txtTotalItems"
        Me.txtTotalItems.ReadOnly = True
        Me.txtTotalItems.Size = New System.Drawing.Size(76, 21)
        Me.txtTotalItems.TabIndex = 53
        Me.txtTotalItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(290, 231)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 26)
        Me.Label8.TabIndex = 463
        Me.Label8.Text = "Total" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Items:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalQty
        '
        Me.txtTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQty.Location = New System.Drawing.Point(495, 234)
        Me.txtTotalQty.Name = "txtTotalQty"
        Me.txtTotalQty.ReadOnly = True
        Me.txtTotalQty.Size = New System.Drawing.Size(86, 21)
        Me.txtTotalQty.TabIndex = 54
        Me.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(430, 231)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 26)
        Me.Label7.TabIndex = 461
        Me.Label7.Text = "Total Qty." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ordered:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgCustomerOrderItems
        '
        Me.dgCustomerOrderItems.AllowUserToAddRows = False
        Me.dgCustomerOrderItems.AllowUserToDeleteRows = False
        Me.dgCustomerOrderItems.AllowUserToOrderColumns = True
        Me.dgCustomerOrderItems.AllowUserToResizeRows = False
        Me.dgCustomerOrderItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerOrderItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle32
        Me.dgCustomerOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomerOrderItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ci_rowid, Me.ci_pcsrowid, Me.ci_bid, Me.ci_colorvalue, Me.ci_seqno, Me.ci_productcode, Me.ci_colorname, Me.ci_color, Me.ci_size, Me.ci_seasoncode, Me.ci_unitofmeasure, Me.ci_qtyordered, Me.ci_qtypicked, Me.ci_qtydelivered, Me.ci_srp, Me.ci_totalprice, Me.ci_sku, Me.ci_tags, Me.ci_type, Me.ci_remarks, Me.ci_status, Me.ci_verifiedby, Me.ci_verifieddate, Me.ci_packedby, Me.ci_packeddate, Me.ci_deliveredby, Me.ci_delivereddate, Me.ci_option})
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCustomerOrderItems.DefaultCellStyle = DataGridViewCellStyle33
        Me.dgCustomerOrderItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCustomerOrderItems.Location = New System.Drawing.Point(8, 17)
        Me.dgCustomerOrderItems.MultiSelect = False
        Me.dgCustomerOrderItems.Name = "dgCustomerOrderItems"
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerOrderItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle34
        Me.dgCustomerOrderItems.RowHeadersVisible = False
        Me.dgCustomerOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCustomerOrderItems.Size = New System.Drawing.Size(801, 210)
        Me.dgCustomerOrderItems.TabIndex = 50
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
        Me.ci_productcode.HeaderText = "Product Code / Bundle Name"
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
        'ci_qtypicked
        '
        Me.ci_qtypicked.HeaderText = "Qty. Picked"
        Me.ci_qtypicked.Name = "ci_qtypicked"
        Me.ci_qtypicked.ReadOnly = True
        Me.ci_qtypicked.Width = 60
        '
        'ci_qtydelivered
        '
        Me.ci_qtydelivered.HeaderText = "Qty. Delivered"
        Me.ci_qtydelivered.Name = "ci_qtydelivered"
        Me.ci_qtydelivered.ReadOnly = True
        Me.ci_qtydelivered.Width = 65
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
        'ci_sku
        '
        Me.ci_sku.HeaderText = "SKU"
        Me.ci_sku.Name = "ci_sku"
        '
        'ci_tags
        '
        Me.ci_tags.HeaderText = "Tags"
        Me.ci_tags.Name = "ci_tags"
        Me.ci_tags.Width = 90
        '
        'ci_type
        '
        Me.ci_type.HeaderText = "Type"
        Me.ci_type.Name = "ci_type"
        Me.ci_type.ReadOnly = True
        Me.ci_type.Width = 40
        '
        'ci_remarks
        '
        Me.ci_remarks.HeaderText = "Remarks"
        Me.ci_remarks.Name = "ci_remarks"
        '
        'ci_status
        '
        Me.ci_status.HeaderText = "Status"
        Me.ci_status.Name = "ci_status"
        Me.ci_status.ReadOnly = True
        '
        'ci_verifiedby
        '
        Me.ci_verifiedby.HeaderText = "Verified By"
        Me.ci_verifiedby.Name = "ci_verifiedby"
        Me.ci_verifiedby.ReadOnly = True
        '
        'ci_verifieddate
        '
        Me.ci_verifieddate.HeaderText = "Verified Date"
        Me.ci_verifieddate.Name = "ci_verifieddate"
        Me.ci_verifieddate.ReadOnly = True
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
        'ci_deliveredby
        '
        Me.ci_deliveredby.HeaderText = "Delivered By"
        Me.ci_deliveredby.Name = "ci_deliveredby"
        Me.ci_deliveredby.ReadOnly = True
        '
        'ci_delivereddate
        '
        Me.ci_delivereddate.HeaderText = "Delivered Date"
        Me.ci_delivereddate.Name = "ci_delivereddate"
        Me.ci_delivereddate.ReadOnly = True
        '
        'ci_option
        '
        Me.ci_option.HeaderText = ""
        Me.ci_option.Name = "ci_option"
        Me.ci_option.Text = "Delete"
        Me.ci_option.UseColumnTextForButtonValue = True
        Me.ci_option.Width = 50
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
        'gbCustomerOrderInformation
        '
        Me.gbCustomerOrderInformation.Controls.Add(Me.btnAddAgent)
        Me.gbCustomerOrderInformation.Controls.Add(Me.cboCustomerOrderType)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label37)
        Me.gbCustomerOrderInformation.Controls.Add(Me.cboAgent)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label36)
        Me.gbCustomerOrderInformation.Controls.Add(Me.cboInventoryLocation)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label33)
        Me.gbCustomerOrderInformation.Controls.Add(Me.pbAddClassDescription)
        Me.gbCustomerOrderInformation.Controls.Add(Me.cboClassDescription)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label31)
        Me.gbCustomerOrderInformation.Controls.Add(Me.pbAddBranchCodeName)
        Me.gbCustomerOrderInformation.Controls.Add(Me.cboBranchCodeNameInfo)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label41)
        Me.gbCustomerOrderInformation.Controls.Add(Me.pbAddVendorCodeName)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label35)
        Me.gbCustomerOrderInformation.Controls.Add(Me.cboVendorCodeNameInfo)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label29)
        Me.gbCustomerOrderInformation.Controls.Add(Me.pbSaveSIDRNo)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label27)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label28)
        Me.gbCustomerOrderInformation.Controls.Add(Me.txtSIDRNo)
        Me.gbCustomerOrderInformation.Controls.Add(Me.txtDateSubmitted)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label26)
        Me.gbCustomerOrderInformation.Controls.Add(Me.dtpEndDate)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label22)
        Me.gbCustomerOrderInformation.Controls.Add(Me.txtCustomerOrderNo)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label20)
        Me.gbCustomerOrderInformation.Controls.Add(Me.txtDeliveryAddress)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label19)
        Me.gbCustomerOrderInformation.Controls.Add(Me.txtDeliveryHours)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label10)
        Me.gbCustomerOrderInformation.Controls.Add(Me.pbAddCustomer)
        Me.gbCustomerOrderInformation.Controls.Add(Me.txtComments)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label25)
        Me.gbCustomerOrderInformation.Controls.Add(Me.txtPickListNo)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label24)
        Me.gbCustomerOrderInformation.Controls.Add(Me.dtpDeliveryDate)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label23)
        Me.gbCustomerOrderInformation.Controls.Add(Me.txtLineUpNos)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label11)
        Me.gbCustomerOrderInformation.Controls.Add(Me.txtStatus)
        Me.gbCustomerOrderInformation.Controls.Add(Me.dtpCustomerOrderDate)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label2)
        Me.gbCustomerOrderInformation.Controls.Add(Me.cboCustomerName)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label14)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label12)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label6)
        Me.gbCustomerOrderInformation.Controls.Add(Me.txtPONo)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label52)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label55)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label9)
        Me.gbCustomerOrderInformation.Controls.Add(Me.Label34)
        Me.gbCustomerOrderInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCustomerOrderInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCustomerOrderInformation.Location = New System.Drawing.Point(6, 5)
        Me.gbCustomerOrderInformation.Name = "gbCustomerOrderInformation"
        Me.gbCustomerOrderInformation.Size = New System.Drawing.Size(819, 281)
        Me.gbCustomerOrderInformation.TabIndex = 3
        Me.gbCustomerOrderInformation.TabStop = False
        '
        'cboCustomerOrderType
        '
        Me.cboCustomerOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustomerOrderType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomerOrderType.FormattingEnabled = True
        Me.cboCustomerOrderType.Location = New System.Drawing.Point(156, 217)
        Me.cboCustomerOrderType.Name = "cboCustomerOrderType"
        Me.cboCustomerOrderType.Size = New System.Drawing.Size(208, 23)
        Me.cboCustomerOrderType.TabIndex = 31
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Red
        Me.Label37.Location = New System.Drawing.Point(136, 218)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(16, 20)
        Me.Label37.TabIndex = 463
        Me.Label37.Text = "*"
        '
        'cboAgent
        '
        Me.cboAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAgent.FormattingEnabled = True
        Me.cboAgent.Location = New System.Drawing.Point(156, 247)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Size = New System.Drawing.Size(208, 23)
        Me.cboAgent.TabIndex = 461
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(6, 251)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(38, 15)
        Me.Label36.TabIndex = 462
        Me.Label36.Text = "Agent"
        '
        'cboInventoryLocation
        '
        Me.cboInventoryLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInventoryLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInventoryLocation.FormattingEnabled = True
        Me.cboInventoryLocation.Location = New System.Drawing.Point(124, 75)
        Me.cboInventoryLocation.Name = "cboInventoryLocation"
        Me.cboInventoryLocation.Size = New System.Drawing.Size(288, 23)
        Me.cboInventoryLocation.TabIndex = 459
        Me.cboInventoryLocation.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(6, 79)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(108, 15)
        Me.Label33.TabIndex = 458
        Me.Label33.Text = "Inventory Location:"
        Me.Label33.Visible = False
        '
        'pbAddClassDescription
        '
        Me.pbAddClassDescription.BackColor = System.Drawing.Color.Transparent
        Me.pbAddClassDescription.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddClassDescription.Image = CType(resources.GetObject("pbAddClassDescription.Image"), System.Drawing.Image)
        Me.pbAddClassDescription.Location = New System.Drawing.Point(795, 106)
        Me.pbAddClassDescription.Name = "pbAddClassDescription"
        Me.pbAddClassDescription.Size = New System.Drawing.Size(14, 18)
        Me.pbAddClassDescription.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddClassDescription.TabIndex = 457
        Me.pbAddClassDescription.TabStop = False
        Me.pbAddClassDescription.Tag = ""
        '
        'cboClassDescription
        '
        Me.cboClassDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboClassDescription.FormattingEnabled = True
        Me.cboClassDescription.Location = New System.Drawing.Point(508, 103)
        Me.cboClassDescription.Name = "cboClassDescription"
        Me.cboClassDescription.Size = New System.Drawing.Size(285, 23)
        Me.cboClassDescription.TabIndex = 32
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(402, 106)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(105, 15)
        Me.Label31.TabIndex = 456
        Me.Label31.Text = "Class Description:"
        '
        'pbAddBranchCodeName
        '
        Me.pbAddBranchCodeName.BackColor = System.Drawing.Color.Transparent
        Me.pbAddBranchCodeName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddBranchCodeName.Image = CType(resources.GetObject("pbAddBranchCodeName.Image"), System.Drawing.Image)
        Me.pbAddBranchCodeName.Location = New System.Drawing.Point(367, 162)
        Me.pbAddBranchCodeName.Name = "pbAddBranchCodeName"
        Me.pbAddBranchCodeName.Size = New System.Drawing.Size(14, 18)
        Me.pbAddBranchCodeName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddBranchCodeName.TabIndex = 454
        Me.pbAddBranchCodeName.TabStop = False
        Me.pbAddBranchCodeName.Tag = ""
        '
        'cboBranchCodeNameInfo
        '
        Me.cboBranchCodeNameInfo.BackColor = System.Drawing.SystemColors.Window
        Me.cboBranchCodeNameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranchCodeNameInfo.FormattingEnabled = True
        Me.cboBranchCodeNameInfo.Location = New System.Drawing.Point(156, 159)
        Me.cboBranchCodeNameInfo.Name = "cboBranchCodeNameInfo"
        Me.cboBranchCodeNameInfo.Size = New System.Drawing.Size(208, 23)
        Me.cboBranchCodeNameInfo.TabIndex = 30
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(6, 163)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(147, 15)
        Me.Label41.TabIndex = 453
        Me.Label41.Text = "Branch Code / Name Info:"
        '
        'pbAddVendorCodeName
        '
        Me.pbAddVendorCodeName.BackColor = System.Drawing.Color.Transparent
        Me.pbAddVendorCodeName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddVendorCodeName.Image = CType(resources.GetObject("pbAddVendorCodeName.Image"), System.Drawing.Image)
        Me.pbAddVendorCodeName.Location = New System.Drawing.Point(367, 191)
        Me.pbAddVendorCodeName.Name = "pbAddVendorCodeName"
        Me.pbAddVendorCodeName.Size = New System.Drawing.Size(14, 18)
        Me.pbAddVendorCodeName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddVendorCodeName.TabIndex = 451
        Me.pbAddVendorCodeName.TabStop = False
        Me.pbAddVendorCodeName.Tag = ""
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(6, 221)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(73, 15)
        Me.Label35.TabIndex = 450
        Me.Label35.Text = "Order Type: "
        '
        'cboVendorCodeNameInfo
        '
        Me.cboVendorCodeNameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendorCodeNameInfo.FormattingEnabled = True
        Me.cboVendorCodeNameInfo.Location = New System.Drawing.Point(156, 188)
        Me.cboVendorCodeNameInfo.Name = "cboVendorCodeNameInfo"
        Me.cboVendorCodeNameInfo.Size = New System.Drawing.Size(208, 23)
        Me.cboVendorCodeNameInfo.TabIndex = 31
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(6, 192)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(147, 15)
        Me.Label29.TabIndex = 450
        Me.Label29.Text = "Vendor Code / Name Info:"
        '
        'pbSaveSIDRNo
        '
        Me.pbSaveSIDRNo.BackColor = System.Drawing.Color.Transparent
        Me.pbSaveSIDRNo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbSaveSIDRNo.Image = CType(resources.GetObject("pbSaveSIDRNo.Image"), System.Drawing.Image)
        Me.pbSaveSIDRNo.Location = New System.Drawing.Point(633, 22)
        Me.pbSaveSIDRNo.Name = "pbSaveSIDRNo"
        Me.pbSaveSIDRNo.Size = New System.Drawing.Size(14, 18)
        Me.pbSaveSIDRNo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbSaveSIDRNo.TabIndex = 448
        Me.pbSaveSIDRNo.TabStop = False
        Me.pbSaveSIDRNo.Tag = ""
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(438, 25)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(76, 15)
        Me.Label27.TabIndex = 447
        Me.Label27.Text = "S.I./D.R. No.:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(513, 19)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(16, 20)
        Me.Label28.TabIndex = 446
        Me.Label28.Text = "*"
        '
        'txtSIDRNo
        '
        Me.txtSIDRNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSIDRNo.Location = New System.Drawing.Point(530, 21)
        Me.txtSIDRNo.Name = "txtSIDRNo"
        Me.txtSIDRNo.Size = New System.Drawing.Size(100, 21)
        Me.txtSIDRNo.TabIndex = 22
        '
        'txtDateSubmitted
        '
        Me.txtDateSubmitted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateSubmitted.Location = New System.Drawing.Point(687, 76)
        Me.txtDateSubmitted.Name = "txtDateSubmitted"
        Me.txtDateSubmitted.ReadOnly = True
        Me.txtDateSubmitted.Size = New System.Drawing.Size(113, 21)
        Me.txtDateSubmitted.TabIndex = 27
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(509, 79)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(174, 15)
        Me.Label26.TabIndex = 444
        Me.Label26.Text = "Date Submitted to Warehouse:"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpEndDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(689, 49)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(110, 21)
        Me.dtpEndDate.TabIndex = 26
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(608, 52)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 15)
        Me.Label22.TabIndex = 442
        Me.Label22.Text = "Cancel Date:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCustomerOrderNo
        '
        Me.txtCustomerOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerOrderNo.Location = New System.Drawing.Point(136, 21)
        Me.txtCustomerOrderNo.Name = "txtCustomerOrderNo"
        Me.txtCustomerOrderNo.ReadOnly = True
        Me.txtCustomerOrderNo.Size = New System.Drawing.Size(110, 21)
        Me.txtCustomerOrderNo.TabIndex = 20
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(251, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(55, 15)
        Me.Label20.TabIndex = 440
        Me.Label20.Text = "P.O. No.:"
        '
        'txtDeliveryAddress
        '
        Me.txtDeliveryAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryAddress.Location = New System.Drawing.Point(111, 132)
        Me.txtDeliveryAddress.Name = "txtDeliveryAddress"
        Me.txtDeliveryAddress.Size = New System.Drawing.Size(270, 21)
        Me.txtDeliveryAddress.TabIndex = 29
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 136)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 15)
        Me.Label19.TabIndex = 438
        Me.Label19.Text = "Delivery Address:"
        '
        'txtDeliveryHours
        '
        Me.txtDeliveryHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryHours.Location = New System.Drawing.Point(405, 146)
        Me.txtDeliveryHours.Multiline = True
        Me.txtDeliveryHours.Name = "txtDeliveryHours"
        Me.txtDeliveryHours.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDeliveryHours.Size = New System.Drawing.Size(187, 40)
        Me.txtDeliveryHours.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(455, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 15)
        Me.Label10.TabIndex = 436
        Me.Label10.Text = "Delivery Hours:"
        '
        'pbAddCustomer
        '
        Me.pbAddCustomer.BackColor = System.Drawing.Color.Transparent
        Me.pbAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddCustomer.Image = CType(resources.GetObject("pbAddCustomer.Image"), System.Drawing.Image)
        Me.pbAddCustomer.Location = New System.Drawing.Point(367, 106)
        Me.pbAddCustomer.Name = "pbAddCustomer"
        Me.pbAddCustomer.Size = New System.Drawing.Size(14, 18)
        Me.pbAddCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddCustomer.TabIndex = 435
        Me.pbAddCustomer.TabStop = False
        Me.pbAddCustomer.Tag = ""
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(598, 146)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(210, 40)
        Me.txtComments.TabIndex = 34
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(674, 128)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 15)
        Me.Label25.TabIndex = 434
        Me.Label25.Text = "Comments:"
        '
        'txtPickListNo
        '
        Me.txtPickListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPickListNo.Location = New System.Drawing.Point(482, 192)
        Me.txtPickListNo.Name = "txtPickListNo"
        Me.txtPickListNo.ReadOnly = True
        Me.txtPickListNo.Size = New System.Drawing.Size(110, 21)
        Me.txtPickListNo.TabIndex = 35
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(402, 196)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 15)
        Me.Label24.TabIndex = 432
        Me.Label24.Text = "Pick List No.:"
        '
        'dtpDeliveryDate
        '
        Me.dtpDeliveryDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpDeliveryDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpDeliveryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDeliveryDate.Location = New System.Drawing.Point(416, 49)
        Me.dtpDeliveryDate.Name = "dtpDeliveryDate"
        Me.dtpDeliveryDate.Size = New System.Drawing.Size(110, 21)
        Me.dtpDeliveryDate.TabIndex = 25
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(331, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(82, 15)
        Me.Label23.TabIndex = 431
        Me.Label23.Text = "Delivery Date:"
        '
        'txtLineUpNos
        '
        Me.txtLineUpNos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLineUpNos.Location = New System.Drawing.Point(689, 193)
        Me.txtLineUpNos.Name = "txtLineUpNos"
        Me.txtLineUpNos.ReadOnly = True
        Me.txtLineUpNos.Size = New System.Drawing.Size(120, 21)
        Me.txtLineUpNos.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(598, 196)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 15)
        Me.Label11.TabIndex = 428
        Me.Label11.Text = "Line-Up No(s).:"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(709, 21)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(100, 21)
        Me.txtStatus.TabIndex = 23
        '
        'dtpCustomerOrderDate
        '
        Me.dtpCustomerOrderDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpCustomerOrderDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpCustomerOrderDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCustomerOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCustomerOrderDate.Location = New System.Drawing.Point(132, 48)
        Me.dtpCustomerOrderDate.Name = "dtpCustomerOrderDate"
        Me.dtpCustomerOrderDate.Size = New System.Drawing.Size(110, 21)
        Me.dtpCustomerOrderDate.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 15)
        Me.Label2.TabIndex = 422
        Me.Label2.Text = "Customer Order Date:"
        '
        'cboCustomerName
        '
        Me.cboCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(124, 103)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(240, 23)
        Me.cboCustomerName.TabIndex = 28
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 106)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 15)
        Me.Label14.TabIndex = 420
        Me.Label14.Text = "Customer Name:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(663, 25)
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
        Me.Label6.Location = New System.Drawing.Point(303, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 20)
        Me.Label6.TabIndex = 310
        Me.Label6.Text = "*"
        '
        'txtPONo
        '
        Me.txtPONo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPONo.Location = New System.Drawing.Point(320, 21)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.Size = New System.Drawing.Size(100, 21)
        Me.txtPONo.TabIndex = 21
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(6, 25)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(119, 15)
        Me.Label52.TabIndex = 272
        Me.Label52.Text = "Customer Order No.:"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.White
        Me.Label55.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label55.Location = New System.Drawing.Point(9, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(210, 17)
        Me.Label55.TabIndex = 228
        Me.Label55.Text = "Customer Order Information:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(107, 103)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 20)
        Me.Label9.TabIndex = 425
        Me.Label9.Text = "*"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Red
        Me.Label34.Location = New System.Drawing.Point(109, 75)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(16, 20)
        Me.Label34.TabIndex = 460
        Me.Label34.Text = "*"
        Me.Label34.Visible = False
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msNew, Me.msSave, Me.msPrint, Me.msCancel, Me.msOrder, Me.msDuplicate, Me.msSubmit})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(836, 25)
        Me.msMenu.TabIndex = 19
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
        'msPrint
        '
        Me.msPrint.Image = CType(resources.GetObject("msPrint.Image"), System.Drawing.Image)
        Me.msPrint.Name = "msPrint"
        Me.msPrint.Size = New System.Drawing.Size(66, 21)
        Me.msPrint.Text = "&Print"
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
        Me.msOrder.Size = New System.Drawing.Size(28, 21)
        '
        'msDuplicate
        '
        Me.msDuplicate.Image = CType(resources.GetObject("msDuplicate.Image"), System.Drawing.Image)
        Me.msDuplicate.Name = "msDuplicate"
        Me.msDuplicate.Size = New System.Drawing.Size(134, 21)
        Me.msDuplicate.Text = "&Duplicate Order"
        '
        'msSubmit
        '
        Me.msSubmit.Image = CType(resources.GetObject("msSubmit.Image"), System.Drawing.Image)
        Me.msSubmit.Name = "msSubmit"
        Me.msSubmit.Size = New System.Drawing.Size(154, 21)
        Me.msSubmit.Text = "Sent To Warehouse"
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
        Me.pbClose.TabIndex = 235
        Me.pbClose.TabStop = False
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
        Me.lblTitle.TabIndex = 234
        Me.lblTitle.Text = "Customer Orders"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataSetA
        '
        Me.DataSetA.DataSetName = "DataSetA"
        Me.DataSetA.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataSetABindingSource
        '
        Me.DataSetABindingSource.DataSource = Me.DataSetA
        Me.DataSetABindingSource.Position = 0
        '
        'btnAddAgent
        '
        Me.btnAddAgent.BackColor = System.Drawing.Color.Transparent
        Me.btnAddAgent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddAgent.Image = CType(resources.GetObject("btnAddAgent.Image"), System.Drawing.Image)
        Me.btnAddAgent.Location = New System.Drawing.Point(367, 250)
        Me.btnAddAgent.Name = "btnAddAgent"
        Me.btnAddAgent.Size = New System.Drawing.Size(14, 18)
        Me.btnAddAgent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnAddAgent.TabIndex = 603
        Me.btnAddAgent.TabStop = False
        Me.btnAddAgent.Tag = ""
        '
        'CustomerOrdersForm
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
        Me.Name = "CustomerOrdersForm"
        CType(Me.dgProductSizes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgProductColors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAddProductItem.ResumeLayout(False)
        Me.gbAddProductItem.PerformLayout()
        CType(Me.pbAddTags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCustomerOrderList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbCustomerOrderList.ResumeLayout(False)
        Me.gbCustomerOrderList.PerformLayout()
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
        CType(Me.dgBundleItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgProductColorSizes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCustomerOrderItems.ResumeLayout(False)
        Me.gbCustomerOrderItems.PerformLayout()
        CType(Me.dgCustomerOrderItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCustomerOrderInformation.ResumeLayout(False)
        Me.gbCustomerOrderInformation.PerformLayout()
        CType(Me.pbAddClassDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddBranchCodeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddVendorCodeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSaveSIDRNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAddAgent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgProductSizes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtQtyOrdered As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAddProduct As System.Windows.Forms.Button
    Friend WithEvents cboByPhrase As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgProductColors As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cboBy As System.Windows.Forms.ComboBox
    Friend WithEvents gbAddProductItem As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgCustomerOrderList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbCustomerOrderList As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPage As System.Windows.Forms.TextBox
    Friend WithEvents txtPageNo As System.Windows.Forms.TextBox
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tabSearch As System.Windows.Forms.TabControl
    Friend WithEvents tabSimple As System.Windows.Forms.TabPage
    Friend WithEvents txtSimpleSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents tabCommon As System.Windows.Forms.TabPage
    Friend WithEvents cboSearch4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch1 As System.Windows.Forms.ComboBox
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents gbAddProducts As System.Windows.Forms.GroupBox
    Friend WithEvents dgProductColorSizes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbCustomerOrderItems As System.Windows.Forms.GroupBox
    Friend WithEvents dgCustomerOrderItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents gbCustomerOrderInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtpCustomerOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtOverallPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblOverallPrice As System.Windows.Forms.Label
    Friend WithEvents lblOverallPesoSign As System.Windows.Forms.Label
    Friend WithEvents lblOverallQty As System.Windows.Forms.Label
    Friend WithEvents txtOverallQty As System.Windows.Forms.TextBox
    Friend WithEvents dgBundleItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtBundleSRP As System.Windows.Forms.TextBox
    Friend WithEvents lblSRP As System.Windows.Forms.Label
    Friend WithEvents txtLineUpNos As System.Windows.Forms.TextBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtPickListNo As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents msOrder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboDate As System.Windows.Forms.ComboBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dtpToSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents pbAddCustomer As System.Windows.Forms.PictureBox
    Friend WithEvents lnkEditBundleItems As System.Windows.Forms.LinkLabel
    Friend WithEvents chkOtherInfo As System.Windows.Forms.CheckBox
    Friend WithEvents txtTotalItems As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryHours As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents msDuplicate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtDateSubmitted As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtSIDRNo As System.Windows.Forms.TextBox
    Friend WithEvents pbSaveSIDRNo As System.Windows.Forms.PictureBox
    Friend WithEvents cboVendorCodeNameInfo As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents pbAddVendorCodeName As System.Windows.Forms.PictureBox
    Friend WithEvents pbAddClassDescription As System.Windows.Forms.PictureBox
    Friend WithEvents cboClassDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents pbAddBranchCodeName As System.Windows.Forms.PictureBox
    Friend WithEvents cboBranchCodeNameInfo As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents msSubmit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents co_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents co_customerorderno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents co_pono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents co_customerorderdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents co_customername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents co_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents msPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboTags As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents pbAddTags As System.Windows.Forms.PictureBox
    Friend WithEvents c_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_pcsrowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_qtybundle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_totalqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_qtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_qtyallocated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_qtyorderable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_qtyreserve As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_sizes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_qtyordered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_qtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_qtyallocated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_qtyorderable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_qtyreserve As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_srp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_totalprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_qtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_qtyallocated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_qtyorderable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_qtyreserve As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_srp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_unitmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents ci_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtyordered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtypicked As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtydelivered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_srp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_totalprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_tags As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ci_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_verifiedby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_verifieddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_packedby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_packeddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_deliveredby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_delivereddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_option As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents cboInventoryLocation As ComboBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents cboCustomerOrderType As ComboBox
    Friend WithEvents Label35 As Label
    Friend WithEvents cboAgent As ComboBox
    Friend WithEvents Label36 As Label
    Friend WithEvents DataSetA As DataSetA
    Friend WithEvents DataSetABindingSource As BindingSource
    Friend WithEvents Label37 As Label
    Friend WithEvents btnAddAgent As PictureBox
End Class
