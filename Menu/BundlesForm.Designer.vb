<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BundlesForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BundlesForm))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBundleName = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.gbBundleItems = New System.Windows.Forms.GroupBox()
        Me.txtTotalItems = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalQty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.bi_qtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bi_option = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboSearch4 = New System.Windows.Forms.ComboBox()
        Me.cboSearch2 = New System.Windows.Forms.ComboBox()
        Me.cboSearch3 = New System.Windows.Forms.ComboBox()
        Me.cboSearch1 = New System.Windows.Forms.ComboBox()
        Me.tabCommon = New System.Windows.Forms.TabPage()
        Me.tabSearch = New System.Windows.Forms.TabControl()
        Me.tabSimple = New System.Windows.Forms.TabPage()
        Me.txtSimpleSearch = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.txtPage = New System.Windows.Forms.TextBox()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtPageNo = New System.Windows.Forms.TextBox()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.gbAddProducts = New System.Windows.Forms.GroupBox()
        Me.dgProductColorSizes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pcs_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcs_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbAddProductItem = New System.Windows.Forms.GroupBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.cboByPhrase = New System.Windows.Forms.ComboBox()
        Me.cboBy = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgProductColors = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.c_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgProductSizes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.s_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_sizes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbBundleInformation = New System.Windows.Forms.GroupBox()
        Me.pbAutoAddD = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddC = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddB = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddA = New System.Windows.Forms.PictureBox()
        Me.cboCompany = New System.Windows.Forms.ComboBox()
        Me.cboBrandName = New System.Windows.Forms.ComboBox()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboUnitOfMeasure = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtSRP = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbBundleList = New System.Windows.Forms.GroupBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.cmdFirst = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrev = New System.Windows.Forms.ToolStripButton()
        Me.cmdNext = New System.Windows.Forms.ToolStripButton()
        Me.cmdLast = New System.Windows.Forms.ToolStripButton()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.dgBundleList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.b_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.b_bundlename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.b_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.b_srp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.b_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.gbBundleItems.SuspendLayout()
        CType(Me.dgBundleItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCommon.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.tabSimple.SuspendLayout()
        Me.msMenu.SuspendLayout()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMain.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.gbAddProducts.SuspendLayout()
        CType(Me.dgProductColorSizes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAddProductItem.SuspendLayout()
        CType(Me.dgProductColors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgProductSizes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBundleInformation.SuspendLayout()
        CType(Me.pbAutoAddD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSearch.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbBundleList.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.dgBundleList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(109, 109)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(170, 23)
        Me.cboStatus.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(89, 109)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 20)
        Me.Label13.TabIndex = 415
        Me.Label13.Text = "*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 414
        Me.Label12.Text = "Status:"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(298, 58)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(72, 15)
        Me.Label40.TabIndex = 294
        Me.Label40.Text = "Description:"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(371, 55)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(155, 77)
        Me.txtDescription.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(90, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 20)
        Me.Label6.TabIndex = 310
        Me.Label6.Text = "*"
        '
        'txtBundleName
        '
        Me.txtBundleName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBundleName.Location = New System.Drawing.Point(109, 28)
        Me.txtBundleName.Name = "txtBundleName"
        Me.txtBundleName.Size = New System.Drawing.Size(170, 21)
        Me.txtBundleName.TabIndex = 15
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(6, 31)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(86, 15)
        Me.Label52.TabIndex = 272
        Me.Label52.Text = "Bundle Name:"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.White
        Me.Label55.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label55.Location = New System.Drawing.Point(9, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(149, 17)
        Me.Label55.TabIndex = 228
        Me.Label55.Text = "Bundle Information:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(9, -2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 17)
        Me.Label15.TabIndex = 228
        Me.Label15.Text = "Bundle Items:"
        '
        'gbBundleItems
        '
        Me.gbBundleItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbBundleItems.Controls.Add(Me.txtTotalItems)
        Me.gbBundleItems.Controls.Add(Me.Label8)
        Me.gbBundleItems.Controls.Add(Me.txtTotalQty)
        Me.gbBundleItems.Controls.Add(Me.Label7)
        Me.gbBundleItems.Controls.Add(Me.dgBundleItems)
        Me.gbBundleItems.Controls.Add(Me.Label15)
        Me.gbBundleItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBundleItems.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbBundleItems.Location = New System.Drawing.Point(397, 155)
        Me.gbBundleItems.Name = "gbBundleItems"
        Me.gbBundleItems.Size = New System.Drawing.Size(425, 310)
        Me.gbBundleItems.TabIndex = 5
        Me.gbBundleItems.TabStop = False
        '
        'txtTotalItems
        '
        Me.txtTotalItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalItems.Location = New System.Drawing.Point(133, 278)
        Me.txtTotalItems.Name = "txtTotalItems"
        Me.txtTotalItems.ReadOnly = True
        Me.txtTotalItems.Size = New System.Drawing.Size(73, 21)
        Me.txtTotalItems.TabIndex = 33
        Me.txtTotalItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(47, 280)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 15)
        Me.Label8.TabIndex = 463
        Me.Label8.Text = "Total Items:"
        '
        'txtTotalQty
        '
        Me.txtTotalQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQty.Location = New System.Drawing.Point(301, 278)
        Me.txtTotalQty.Name = "txtTotalQty"
        Me.txtTotalQty.ReadOnly = True
        Me.txtTotalQty.Size = New System.Drawing.Size(73, 21)
        Me.txtTotalQty.TabIndex = 34
        Me.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(224, 280)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 15)
        Me.Label7.TabIndex = 461
        Me.Label7.Text = "Total Qty.:"
        '
        'dgBundleItems
        '
        Me.dgBundleItems.AllowUserToAddRows = False
        Me.dgBundleItems.AllowUserToDeleteRows = False
        Me.dgBundleItems.AllowUserToOrderColumns = True
        Me.dgBundleItems.AllowUserToResizeRows = False
        Me.dgBundleItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgBundleItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBundleItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgBundleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBundleItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bi_rowid, Me.bi_pcsrowid, Me.bi_colorvalue, Me.bi_seqno, Me.bi_productcode, Me.bi_colorname, Me.bi_color, Me.bi_size, Me.bi_seasoncode, Me.bi_qtyavailable, Me.bi_sku, Me.bi_option})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgBundleItems.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgBundleItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgBundleItems.Location = New System.Drawing.Point(8, 19)
        Me.dgBundleItems.MultiSelect = False
        Me.dgBundleItems.Name = "dgBundleItems"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBundleItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgBundleItems.RowHeadersVisible = False
        Me.dgBundleItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgBundleItems.Size = New System.Drawing.Size(411, 253)
        Me.dgBundleItems.TabIndex = 32
        '
        'bi_rowid
        '
        Me.bi_rowid.HeaderText = "rowid"
        Me.bi_rowid.Name = "bi_rowid"
        Me.bi_rowid.Visible = False
        '
        'bi_pcsrowid
        '
        Me.bi_pcsrowid.HeaderText = "pcsrowid"
        Me.bi_pcsrowid.Name = "bi_pcsrowid"
        Me.bi_pcsrowid.Visible = False
        '
        'bi_colorvalue
        '
        Me.bi_colorvalue.HeaderText = "colorvalue"
        Me.bi_colorvalue.Name = "bi_colorvalue"
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
        'bi_qtyavailable
        '
        Me.bi_qtyavailable.HeaderText = "Qty. Bundle"
        Me.bi_qtyavailable.Name = "bi_qtyavailable"
        Me.bi_qtyavailable.Width = 50
        '
        'bi_sku
        '
        Me.bi_sku.HeaderText = "SKU"
        Me.bi_sku.Name = "bi_sku"
        Me.bi_sku.ReadOnly = True
        '
        'bi_option
        '
        Me.bi_option.HeaderText = ""
        Me.bi_option.Name = "bi_option"
        Me.bi_option.Text = "Delete"
        Me.bi_option.UseColumnTextForButtonValue = True
        Me.bi_option.Width = 60
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
        'cboSearch4
        '
        Me.cboSearch4.FormattingEnabled = True
        Me.cboSearch4.Location = New System.Drawing.Point(125, 39)
        Me.cboSearch4.Name = "cboSearch4"
        Me.cboSearch4.Size = New System.Drawing.Size(181, 23)
        Me.cboSearch4.TabIndex = 10
        '
        'cboSearch2
        '
        Me.cboSearch2.FormattingEnabled = True
        Me.cboSearch2.Location = New System.Drawing.Point(125, 13)
        Me.cboSearch2.Name = "cboSearch2"
        Me.cboSearch2.Size = New System.Drawing.Size(181, 23)
        Me.cboSearch2.TabIndex = 8
        '
        'cboSearch3
        '
        Me.cboSearch3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch3.FormattingEnabled = True
        Me.cboSearch3.Location = New System.Drawing.Point(8, 39)
        Me.cboSearch3.Name = "cboSearch3"
        Me.cboSearch3.Size = New System.Drawing.Size(111, 23)
        Me.cboSearch3.TabIndex = 9
        '
        'cboSearch1
        '
        Me.cboSearch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch1.FormattingEnabled = True
        Me.cboSearch1.Location = New System.Drawing.Point(8, 13)
        Me.cboSearch1.Name = "cboSearch1"
        Me.cboSearch1.Size = New System.Drawing.Size(111, 23)
        Me.cboSearch1.TabIndex = 7
        '
        'tabCommon
        '
        Me.tabCommon.Controls.Add(Me.cboSearch4)
        Me.tabCommon.Controls.Add(Me.cboSearch2)
        Me.tabCommon.Controls.Add(Me.cboSearch3)
        Me.tabCommon.Controls.Add(Me.cboSearch1)
        Me.tabCommon.Location = New System.Drawing.Point(4, 29)
        Me.tabCommon.Name = "tabCommon"
        Me.tabCommon.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCommon.Size = New System.Drawing.Size(316, 73)
        Me.tabCommon.TabIndex = 0
        Me.tabCommon.Text = "       Common       "
        Me.tabCommon.UseVisualStyleBackColor = True
        '
        'tabSearch
        '
        Me.tabSearch.Controls.Add(Me.tabSimple)
        Me.tabSearch.Controls.Add(Me.tabCommon)
        Me.tabSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSearch.ItemSize = New System.Drawing.Size(62, 25)
        Me.tabSearch.Location = New System.Drawing.Point(8, 21)
        Me.tabSearch.Multiline = True
        Me.tabSearch.Name = "tabSearch"
        Me.tabSearch.SelectedIndex = 0
        Me.tabSearch.Size = New System.Drawing.Size(324, 106)
        Me.tabSearch.TabIndex = 9
        '
        'tabSimple
        '
        Me.tabSimple.Controls.Add(Me.txtSimpleSearch)
        Me.tabSimple.Controls.Add(Me.Label30)
        Me.tabSimple.Location = New System.Drawing.Point(4, 29)
        Me.tabSimple.Name = "tabSimple"
        Me.tabSimple.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSimple.Size = New System.Drawing.Size(316, 73)
        Me.tabSimple.TabIndex = 1
        Me.tabSimple.Text = "       Simple       "
        Me.tabSimple.UseVisualStyleBackColor = True
        '
        'txtSimpleSearch
        '
        Me.txtSimpleSearch.Location = New System.Drawing.Point(96, 26)
        Me.txtSimpleSearch.Name = "txtSimpleSearch"
        Me.txtSimpleSearch.Size = New System.Drawing.Size(212, 21)
        Me.txtSimpleSearch.TabIndex = 6
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(2, 28)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(91, 15)
        Me.Label30.TabIndex = 4
        Me.Label30.Text = "Search Phrase:"
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msNew, Me.msSave, Me.msCancel})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(836, 25)
        Me.msMenu.TabIndex = 315
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
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(81, 5)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 193
        '
        'txtPage
        '
        Me.txtPage.Location = New System.Drawing.Point(228, 43)
        Me.txtPage.Name = "txtPage"
        Me.txtPage.Size = New System.Drawing.Size(41, 21)
        Me.txtPage.TabIndex = 13
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
        Me.pbClose.TabIndex = 232
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
        Me.lblTitle.TabIndex = 231
        Me.lblTitle.Text = "Bundles"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'txtPageNo
        '
        Me.txtPageNo.Location = New System.Drawing.Point(121, 43)
        Me.txtPageNo.Name = "txtPageNo"
        Me.txtPageNo.ReadOnly = True
        Me.txtPageNo.Size = New System.Drawing.Size(101, 21)
        Me.txtPageNo.TabIndex = 12
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
        Me.tabDetails.Controls.Add(Me.gbBundleItems)
        Me.tabDetails.Controls.Add(Me.gbBundleInformation)
        Me.tabDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(828, 472)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Bundle Details"
        Me.tabDetails.UseVisualStyleBackColor = True
        '
        'gbAddProducts
        '
        Me.gbAddProducts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbAddProducts.Controls.Add(Me.dgProductColorSizes)
        Me.gbAddProducts.Controls.Add(Me.gbAddProductItem)
        Me.gbAddProducts.Controls.Add(Me.Label1)
        Me.gbAddProducts.Controls.Add(Me.dgProductColors)
        Me.gbAddProducts.Controls.Add(Me.dgProductSizes)
        Me.gbAddProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAddProducts.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbAddProducts.Location = New System.Drawing.Point(6, 155)
        Me.gbAddProducts.Name = "gbAddProducts"
        Me.gbAddProducts.Size = New System.Drawing.Size(385, 310)
        Me.gbAddProducts.TabIndex = 4
        Me.gbAddProducts.TabStop = False
        '
        'dgProductColorSizes
        '
        Me.dgProductColorSizes.AllowUserToAddRows = False
        Me.dgProductColorSizes.AllowUserToDeleteRows = False
        Me.dgProductColorSizes.AllowUserToOrderColumns = True
        Me.dgProductColorSizes.AllowUserToResizeRows = False
        Me.dgProductColorSizes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgProductColorSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductColorSizes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pcs_rowid, Me.pcs_seqno, Me.pcs_colorvalue, Me.pcs_productcode, Me.pcs_colorname, Me.pcs_color, Me.pcs_size, Me.pcs_seasoncode, Me.pcs_sku})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductColorSizes.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgProductColorSizes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductColorSizes.Location = New System.Drawing.Point(9, 90)
        Me.dgProductColorSizes.MultiSelect = False
        Me.dgProductColorSizes.Name = "dgProductColorSizes"
        Me.dgProductColorSizes.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColorSizes.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgProductColorSizes.RowHeadersVisible = False
        Me.dgProductColorSizes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductColorSizes.Size = New System.Drawing.Size(366, 162)
        Me.dgProductColorSizes.TabIndex = 29
        '
        'pcs_rowid
        '
        Me.pcs_rowid.HeaderText = "rowid"
        Me.pcs_rowid.Name = "pcs_rowid"
        Me.pcs_rowid.ReadOnly = True
        Me.pcs_rowid.Visible = False
        '
        'pcs_seqno
        '
        Me.pcs_seqno.HeaderText = "seq. no."
        Me.pcs_seqno.Name = "pcs_seqno"
        Me.pcs_seqno.ReadOnly = True
        Me.pcs_seqno.Visible = False
        Me.pcs_seqno.Width = 40
        '
        'pcs_colorvalue
        '
        Me.pcs_colorvalue.HeaderText = "colorvalue"
        Me.pcs_colorvalue.Name = "pcs_colorvalue"
        Me.pcs_colorvalue.ReadOnly = True
        Me.pcs_colorvalue.Visible = False
        '
        'pcs_productcode
        '
        Me.pcs_productcode.HeaderText = "Product Code"
        Me.pcs_productcode.Name = "pcs_productcode"
        Me.pcs_productcode.ReadOnly = True
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
        'pcs_sku
        '
        Me.pcs_sku.HeaderText = "SKU"
        Me.pcs_sku.Name = "pcs_sku"
        Me.pcs_sku.ReadOnly = True
        '
        'gbAddProductItem
        '
        Me.gbAddProductItem.Controls.Add(Me.txtQty)
        Me.gbAddProductItem.Controls.Add(Me.Label5)
        Me.gbAddProductItem.Controls.Add(Me.btnAddProduct)
        Me.gbAddProductItem.Controls.Add(Me.cboByPhrase)
        Me.gbAddProductItem.Controls.Add(Me.cboBy)
        Me.gbAddProductItem.Controls.Add(Me.Label3)
        Me.gbAddProductItem.Location = New System.Drawing.Point(10, 14)
        Me.gbAddProductItem.Name = "gbAddProductItem"
        Me.gbAddProductItem.Size = New System.Drawing.Size(365, 70)
        Me.gbAddProductItem.TabIndex = 24
        Me.gbAddProductItem.TabStop = False
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(255, 40)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(45, 21)
        Me.txtQty.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(242, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 15)
        Me.Label5.TabIndex = 416
        Me.Label5.Text = "Qty. Bundle:"
        '
        'btnAddProduct
        '
        Me.btnAddProduct.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAddProduct.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProduct.Image = CType(resources.GetObject("btnAddProduct.Image"), System.Drawing.Image)
        Me.btnAddProduct.Location = New System.Drawing.Point(319, 5)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(41, 65)
        Me.btnAddProduct.TabIndex = 28
        Me.btnAddProduct.UseVisualStyleBackColor = False
        '
        'cboByPhrase
        '
        Me.cboByPhrase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboByPhrase.FormattingEnabled = True
        Me.cboByPhrase.Location = New System.Drawing.Point(6, 40)
        Me.cboByPhrase.Name = "cboByPhrase"
        Me.cboByPhrase.Size = New System.Drawing.Size(228, 23)
        Me.cboByPhrase.TabIndex = 26
        '
        'cboBy
        '
        Me.cboBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBy.FormattingEnabled = True
        Me.cboBy.Location = New System.Drawing.Point(86, 13)
        Me.cboBy.Name = "cboBy"
        Me.cboBy.Size = New System.Drawing.Size(97, 23)
        Me.cboBy.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(64, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 15)
        Me.Label3.TabIndex = 415
        Me.Label3.Text = "By:"
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
        Me.dgProductColors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgProductColors.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColors.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgProductColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductColors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c_rowid, Me.c_colorvalue, Me.c_seqno, Me.c_colorname, Me.c_color})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductColors.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgProductColors.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductColors.Location = New System.Drawing.Point(10, 90)
        Me.dgProductColors.MultiSelect = False
        Me.dgProductColors.Name = "dgProductColors"
        Me.dgProductColors.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColors.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgProductColors.RowHeadersVisible = False
        Me.dgProductColors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductColors.Size = New System.Drawing.Size(148, 210)
        Me.dgProductColors.TabIndex = 30
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
        Me.c_seqno.Width = 40
        '
        'c_colorname
        '
        Me.c_colorname.HeaderText = "Color Name"
        Me.c_colorname.Name = "c_colorname"
        Me.c_colorname.ReadOnly = True
        Me.c_colorname.Width = 60
        '
        'c_color
        '
        Me.c_color.HeaderText = ""
        Me.c_color.Name = "c_color"
        Me.c_color.ReadOnly = True
        Me.c_color.Width = 30
        '
        'dgProductSizes
        '
        Me.dgProductSizes.AllowUserToAddRows = False
        Me.dgProductSizes.AllowUserToDeleteRows = False
        Me.dgProductSizes.AllowUserToOrderColumns = True
        Me.dgProductSizes.AllowUserToResizeRows = False
        Me.dgProductSizes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgProductSizes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductSizes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgProductSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductSizes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.s_rowid, Me.s_sizes, Me.s_seasoncode, Me.s_qty, Me.s_sku})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductSizes.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgProductSizes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductSizes.Location = New System.Drawing.Point(164, 90)
        Me.dgProductSizes.MultiSelect = False
        Me.dgProductSizes.Name = "dgProductSizes"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductSizes.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgProductSizes.RowHeadersVisible = False
        Me.dgProductSizes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductSizes.Size = New System.Drawing.Size(211, 210)
        Me.dgProductSizes.TabIndex = 31
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
        's_qty
        '
        Me.s_qty.HeaderText = "Qty. Bundle"
        Me.s_qty.Name = "s_qty"
        Me.s_qty.Width = 50
        '
        's_sku
        '
        Me.s_sku.HeaderText = "SKU"
        Me.s_sku.Name = "s_sku"
        Me.s_sku.ReadOnly = True
        '
        'gbBundleInformation
        '
        Me.gbBundleInformation.Controls.Add(Me.pbAutoAddD)
        Me.gbBundleInformation.Controls.Add(Me.pbAutoAddC)
        Me.gbBundleInformation.Controls.Add(Me.pbAutoAddB)
        Me.gbBundleInformation.Controls.Add(Me.pbAutoAddA)
        Me.gbBundleInformation.Controls.Add(Me.cboCompany)
        Me.gbBundleInformation.Controls.Add(Me.cboBrandName)
        Me.gbBundleInformation.Controls.Add(Me.cboCategory)
        Me.gbBundleInformation.Controls.Add(Me.Label17)
        Me.gbBundleInformation.Controls.Add(Me.Label42)
        Me.gbBundleInformation.Controls.Add(Me.Label51)
        Me.gbBundleInformation.Controls.Add(Me.txtSKU)
        Me.gbBundleInformation.Controls.Add(Me.Label2)
        Me.gbBundleInformation.Controls.Add(Me.cboUnitOfMeasure)
        Me.gbBundleInformation.Controls.Add(Me.Label14)
        Me.gbBundleInformation.Controls.Add(Me.Label47)
        Me.gbBundleInformation.Controls.Add(Me.txtSRP)
        Me.gbBundleInformation.Controls.Add(Me.Label18)
        Me.gbBundleInformation.Controls.Add(Me.cboStatus)
        Me.gbBundleInformation.Controls.Add(Me.Label13)
        Me.gbBundleInformation.Controls.Add(Me.Label12)
        Me.gbBundleInformation.Controls.Add(Me.Label40)
        Me.gbBundleInformation.Controls.Add(Me.txtDescription)
        Me.gbBundleInformation.Controls.Add(Me.Label6)
        Me.gbBundleInformation.Controls.Add(Me.txtBundleName)
        Me.gbBundleInformation.Controls.Add(Me.Label52)
        Me.gbBundleInformation.Controls.Add(Me.Label55)
        Me.gbBundleInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBundleInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbBundleInformation.Location = New System.Drawing.Point(6, 5)
        Me.gbBundleInformation.Name = "gbBundleInformation"
        Me.gbBundleInformation.Size = New System.Drawing.Size(815, 145)
        Me.gbBundleInformation.TabIndex = 3
        Me.gbBundleInformation.TabStop = False
        '
        'pbAutoAddD
        '
        Me.pbAutoAddD.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddD.Image = CType(resources.GetObject("pbAutoAddD.Image"), System.Drawing.Image)
        Me.pbAutoAddD.Location = New System.Drawing.Point(788, 84)
        Me.pbAutoAddD.Name = "pbAutoAddD"
        Me.pbAutoAddD.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddD.TabIndex = 534
        Me.pbAutoAddD.TabStop = False
        Me.pbAutoAddD.Tag = ""
        '
        'pbAutoAddC
        '
        Me.pbAutoAddC.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddC.Image = CType(resources.GetObject("pbAutoAddC.Image"), System.Drawing.Image)
        Me.pbAutoAddC.Location = New System.Drawing.Point(788, 57)
        Me.pbAutoAddC.Name = "pbAutoAddC"
        Me.pbAutoAddC.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddC.TabIndex = 533
        Me.pbAutoAddC.TabStop = False
        Me.pbAutoAddC.Tag = ""
        '
        'pbAutoAddB
        '
        Me.pbAutoAddB.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddB.Image = CType(resources.GetObject("pbAutoAddB.Image"), System.Drawing.Image)
        Me.pbAutoAddB.Location = New System.Drawing.Point(788, 28)
        Me.pbAutoAddB.Name = "pbAutoAddB"
        Me.pbAutoAddB.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddB.TabIndex = 532
        Me.pbAutoAddB.TabStop = False
        Me.pbAutoAddB.Tag = ""
        '
        'pbAutoAddA
        '
        Me.pbAutoAddA.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddA.Image = CType(resources.GetObject("pbAutoAddA.Image"), System.Drawing.Image)
        Me.pbAutoAddA.Location = New System.Drawing.Point(507, 28)
        Me.pbAutoAddA.Name = "pbAutoAddA"
        Me.pbAutoAddA.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddA.TabIndex = 531
        Me.pbAutoAddA.TabStop = False
        Me.pbAutoAddA.Tag = ""
        '
        'cboCompany
        '
        Me.cboCompany.FormattingEnabled = True
        Me.cboCompany.Location = New System.Drawing.Point(636, 82)
        Me.cboCompany.Name = "cboCompany"
        Me.cboCompany.Size = New System.Drawing.Size(146, 21)
        Me.cboCompany.TabIndex = 23
        '
        'cboBrandName
        '
        Me.cboBrandName.FormattingEnabled = True
        Me.cboBrandName.Location = New System.Drawing.Point(636, 26)
        Me.cboBrandName.Name = "cboBrandName"
        Me.cboBrandName.Size = New System.Drawing.Size(146, 21)
        Me.cboBrandName.TabIndex = 21
        '
        'cboCategory
        '
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(636, 55)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(146, 21)
        Me.cboCategory.TabIndex = 22
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(547, 83)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 15)
        Me.Label17.TabIndex = 428
        Me.Label17.Text = "Vendor Name:"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(547, 58)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(58, 15)
        Me.Label42.TabIndex = 427
        Me.Label42.Text = "Category:"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label51.Location = New System.Drawing.Point(547, 31)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(80, 15)
        Me.Label51.TabIndex = 426
        Me.Label51.Text = "Brand Name:"
        '
        'txtSKU
        '
        Me.txtSKU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKU.Location = New System.Drawing.Point(109, 55)
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.Size = New System.Drawing.Size(170, 21)
        Me.txtSKU.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 15)
        Me.Label2.TabIndex = 422
        Me.Label2.Text = "SKU:"
        '
        'cboUnitOfMeasure
        '
        Me.cboUnitOfMeasure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUnitOfMeasure.FormattingEnabled = True
        Me.cboUnitOfMeasure.Location = New System.Drawing.Point(398, 26)
        Me.cboUnitOfMeasure.Name = "cboUnitOfMeasure"
        Me.cboUnitOfMeasure.Size = New System.Drawing.Size(106, 23)
        Me.cboUnitOfMeasure.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(298, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 15)
        Me.Label14.TabIndex = 420
        Me.Label14.Text = "Unit of Measure:"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(83, 85)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(23, 15)
        Me.Label47.TabIndex = 418
        Me.Label47.Text = "(₱)"
        '
        'txtSRP
        '
        Me.txtSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSRP.Location = New System.Drawing.Point(109, 82)
        Me.txtSRP.Name = "txtSRP"
        Me.txtSRP.Size = New System.Drawing.Size(170, 21)
        Me.txtSRP.TabIndex = 17
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 85)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(35, 15)
        Me.Label18.TabIndex = 417
        Me.Label18.Text = "SRP:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label21.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label21.Location = New System.Drawing.Point(6, -2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 17)
        Me.Label21.TabIndex = 217
        Me.Label21.Text = "Search:"
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbBundleList)
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
        Me.SplitContainer1.TabIndex = 233
        '
        'gbBundleList
        '
        Me.gbBundleList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbBundleList.BackColor = System.Drawing.Color.Transparent
        Me.gbBundleList.Controls.Add(Me.Label4)
        Me.gbBundleList.Controls.Add(Me.txtPage)
        Me.gbBundleList.Controls.Add(Me.txtPageNo)
        Me.gbBundleList.Controls.Add(Me.ToolStrip3)
        Me.gbBundleList.Controls.Add(Me.dgBundleList)
        Me.gbBundleList.Controls.Add(Me.Label16)
        Me.gbBundleList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBundleList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbBundleList.Location = New System.Drawing.Point(6, 152)
        Me.gbBundleList.Name = "gbBundleList"
        Me.gbBundleList.Size = New System.Drawing.Size(340, 369)
        Me.gbBundleList.TabIndex = 2
        Me.gbBundleList.TabStop = False
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
        Me.ToolStrip3.Size = New System.Drawing.Size(334, 22)
        Me.ToolStrip3.TabIndex = 11
        Me.ToolStrip3.Text = "toolbar1"
        '
        'cmdFirst
        '
        Me.cmdFirst.BackColor = System.Drawing.Color.Transparent
        Me.cmdFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdFirst.Image = CType(resources.GetObject("cmdFirst.Image"), System.Drawing.Image)
        Me.cmdFirst.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(24, 19)
        Me.cmdFirst.Text = "First"
        '
        'cmdPrev
        '
        Me.cmdPrev.BackColor = System.Drawing.Color.Transparent
        Me.cmdPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPrev.Image = CType(resources.GetObject("cmdPrev.Image"), System.Drawing.Image)
        Me.cmdPrev.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdPrev.Name = "cmdPrev"
        Me.cmdPrev.Size = New System.Drawing.Size(24, 19)
        Me.cmdPrev.Text = "Previous"
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.Transparent
        Me.cmdNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdNext.Image = CType(resources.GetObject("cmdNext.Image"), System.Drawing.Image)
        Me.cmdNext.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(24, 19)
        Me.cmdNext.Text = "Next"
        '
        'cmdLast
        '
        Me.cmdLast.BackColor = System.Drawing.Color.Transparent
        Me.cmdLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdLast.Image = CType(resources.GetObject("cmdLast.Image"), System.Drawing.Image)
        Me.cmdLast.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(24, 19)
        Me.cmdLast.Text = "Last"
        '
        'tsRefresh
        '
        Me.tsRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsRefresh.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tsRefresh.Image = CType(resources.GetObject("tsRefresh.Image"), System.Drawing.Image)
        Me.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRefresh.Name = "tsRefresh"
        Me.tsRefresh.Size = New System.Drawing.Size(78, 19)
        Me.tsRefresh.Text = "&Refresh"
        '
        'dgBundleList
        '
        Me.dgBundleList.AllowUserToAddRows = False
        Me.dgBundleList.AllowUserToDeleteRows = False
        Me.dgBundleList.AllowUserToOrderColumns = True
        Me.dgBundleList.AllowUserToResizeRows = False
        Me.dgBundleList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgBundleList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBundleList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgBundleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBundleList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.b_rowid, Me.b_bundlename, Me.b_sku, Me.b_srp, Me.b_status})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgBundleList.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgBundleList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgBundleList.Location = New System.Drawing.Point(8, 68)
        Me.dgBundleList.MultiSelect = False
        Me.dgBundleList.Name = "dgBundleList"
        Me.dgBundleList.ReadOnly = True
        Me.dgBundleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgBundleList.Size = New System.Drawing.Size(324, 295)
        Me.dgBundleList.TabIndex = 14
        '
        'b_rowid
        '
        Me.b_rowid.HeaderText = "rowid"
        Me.b_rowid.Name = "b_rowid"
        Me.b_rowid.ReadOnly = True
        Me.b_rowid.Visible = False
        '
        'b_bundlename
        '
        Me.b_bundlename.HeaderText = "Bundle Name"
        Me.b_bundlename.Name = "b_bundlename"
        Me.b_bundlename.ReadOnly = True
        '
        'b_sku
        '
        Me.b_sku.HeaderText = "SKU"
        Me.b_sku.Name = "b_sku"
        Me.b_sku.ReadOnly = True
        '
        'b_srp
        '
        Me.b_srp.HeaderText = "SRP"
        Me.b_srp.Name = "b_srp"
        Me.b_srp.ReadOnly = True
        '
        'b_status
        '
        Me.b_status.HeaderText = "Status"
        Me.b_status.Name = "b_status"
        Me.b_status.ReadOnly = True
        Me.b_status.Width = 80
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(6, -1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 17)
        Me.Label16.TabIndex = 216
        Me.Label16.Text = "Bundle List:"
        '
        'BundlesForm
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
        Me.Name = "BundlesForm"
        Me.gbBundleItems.ResumeLayout(False)
        Me.gbBundleItems.PerformLayout()
        CType(Me.dgBundleItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCommon.ResumeLayout(False)
        Me.tabSearch.ResumeLayout(False)
        Me.tabSimple.ResumeLayout(False)
        Me.tabSimple.PerformLayout()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMain.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.gbAddProducts.ResumeLayout(False)
        Me.gbAddProducts.PerformLayout()
        CType(Me.dgProductColorSizes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAddProductItem.ResumeLayout(False)
        Me.gbAddProductItem.PerformLayout()
        CType(Me.dgProductColors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgProductSizes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbBundleInformation.ResumeLayout(False)
        Me.gbBundleInformation.PerformLayout()
        CType(Me.pbAutoAddD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbBundleList.ResumeLayout(False)
        Me.gbBundleList.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.dgBundleList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBundleName As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents gbBundleItems As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboSearch4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch1 As System.Windows.Forms.ComboBox
    Friend WithEvents tabCommon As System.Windows.Forms.TabPage
    Friend WithEvents tabSearch As System.Windows.Forms.TabControl
    Friend WithEvents tabSimple As System.Windows.Forms.TabPage
    Friend WithEvents txtSimpleSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents txtPage As System.Windows.Forms.TextBox
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbBundleList As System.Windows.Forms.GroupBox
    Friend WithEvents txtPageNo As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgBundleList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents gbBundleInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtSRP As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboUnitOfMeasure As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSKU As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbAddProducts As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgProductColorSizes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbAddProductItem As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddProduct As System.Windows.Forms.Button
    Friend WithEvents cboByPhrase As System.Windows.Forms.ComboBox
    Friend WithEvents cboBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgBundleItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgProductColors As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgProductSizes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalItems As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents b_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents b_bundlename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents b_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents b_srp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents b_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboCompany As System.Windows.Forms.ComboBox
    Friend WithEvents cboBrandName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents c_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcs_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_pcsrowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_qtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bi_option As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents s_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_sizes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbAutoAddA As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddD As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddC As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddB As System.Windows.Forms.PictureBox
End Class
