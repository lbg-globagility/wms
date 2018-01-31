<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductsForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbProductList = New System.Windows.Forms.GroupBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.cmdFirst = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrev = New System.Windows.Forms.ToolStripButton()
        Me.cmdNext = New System.Windows.Forms.ToolStripButton()
        Me.cmdLast = New System.Windows.Forms.ToolStripButton()
        Me.tsColors = New System.Windows.Forms.ToolStripButton()
        Me.tsImport = New System.Windows.Forms.ToolStripButton()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPage = New System.Windows.Forms.TextBox()
        Me.txtPageNo = New System.Windows.Forms.TextBox()
        Me.dgProductList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.p_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_brandname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_company = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tabSearch = New System.Windows.Forms.TabControl()
        Me.tabSimple = New System.Windows.Forms.TabPage()
        Me.txtSimpleSearch = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tabCommon = New System.Windows.Forms.TabPage()
        Me.cboSearch4 = New System.Windows.Forms.ComboBox()
        Me.cboSearch2 = New System.Windows.Forms.ComboBox()
        Me.cboSearch3 = New System.Windows.Forms.ComboBox()
        Me.cboSearch1 = New System.Windows.Forms.ComboBox()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.gbInventoryLocation = New System.Windows.Forms.GroupBox()
        Me.dgInventoryLocations = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.il_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.il_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.il_locationname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.il_totalqtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.il_totalqtyallocated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.il_totalqtyreserve = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.il_totalqtydamage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.il_locationtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbRackShelfColumn = New System.Windows.Forms.GroupBox()
        Me.txtSeasonCode = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgRackShelfColumn = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.rsc_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtyreserve = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtydamage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_rack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_shelf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtyallocated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtyorderable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.gbProductImage = New System.Windows.Forms.GroupBox()
        Me.btnDownloadImage = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtImagePath = New System.Windows.Forms.TextBox()
        Me.pbProductImage = New System.Windows.Forms.PictureBox()
        Me.btnDeleteImage = New System.Windows.Forms.Button()
        Me.btnChangeImage = New System.Windows.Forms.Button()
        Me.gbProductSize = New System.Windows.Forms.GroupBox()
        Me.lblSeasonCode = New System.Windows.Forms.Label()
        Me.txtEditSeasonCode = New System.Windows.Forms.TextBox()
        Me.txtSumQtyAllocated = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtLastSoldDate = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSumQtyReserve = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSumQtyAvailable = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgProductSizes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.s_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_sizes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_totalqtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_totalqtyallocated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_totalqtyreserve = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_active = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.txtLastShipmentDate = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.gbProductColor = New System.Windows.Forms.GroupBox()
        Me.dgProductColors = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.c_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbProductInformation = New System.Windows.Forms.GroupBox()
        Me.pbAutoAddD = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddC = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddB = New System.Windows.Forms.PictureBox()
        Me.pbAutoAddA = New System.Windows.Forms.PictureBox()
        Me.cboUnitOfMeasure = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboCompany = New System.Windows.Forms.ComboBox()
        Me.cboBrandName = New System.Windows.Forms.ComboBox()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtSRP = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtProductCode = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbProductList.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.dgProductList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSearch.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.tabSimple.SuspendLayout()
        Me.tabCommon.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.gbInventoryLocation.SuspendLayout()
        CType(Me.dgInventoryLocations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRackShelfColumn.SuspendLayout()
        CType(Me.dgRackShelfColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProductImage.SuspendLayout()
        CType(Me.pbProductImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProductSize.SuspendLayout()
        CType(Me.dgProductSizes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProductColor.SuspendLayout()
        CType(Me.dgProductColors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProductInformation.SuspendLayout()
        CType(Me.pbAutoAddD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msMenu.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.lblTitle.TabIndex = 218
        Me.lblTitle.Text = "Products"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.pbClose.TabIndex = 220
        Me.pbClose.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbProductList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbSearch)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabMain)
        Me.SplitContainer1.Panel2.Controls.Add(Me.msMenu)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblsavemsg)
        Me.SplitContainer1.Size = New System.Drawing.Size(1200, 532)
        Me.SplitContainer1.SplitterDistance = 357
        Me.SplitContainer1.TabIndex = 221
        '
        'gbProductList
        '
        Me.gbProductList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbProductList.BackColor = System.Drawing.Color.Transparent
        Me.gbProductList.Controls.Add(Me.ToolStrip3)
        Me.gbProductList.Controls.Add(Me.Label4)
        Me.gbProductList.Controls.Add(Me.txtPage)
        Me.gbProductList.Controls.Add(Me.txtPageNo)
        Me.gbProductList.Controls.Add(Me.dgProductList)
        Me.gbProductList.Controls.Add(Me.Label16)
        Me.gbProductList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProductList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbProductList.Location = New System.Drawing.Point(6, 152)
        Me.gbProductList.Name = "gbProductList"
        Me.gbProductList.Size = New System.Drawing.Size(340, 369)
        Me.gbProductList.TabIndex = 2
        Me.gbProductList.TabStop = False
        '
        'ToolStrip3
        '
        Me.ToolStrip3.AutoSize = False
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdFirst, Me.cmdPrev, Me.cmdNext, Me.cmdLast, Me.tsColors, Me.tsImport, Me.tsRefresh})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 17)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(334, 24)
        Me.ToolStrip3.TabIndex = 298
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
        'tsColors
        '
        Me.tsColors.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsColors.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsColors.Image = CType(resources.GetObject("tsColors.Image"), System.Drawing.Image)
        Me.tsColors.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsColors.Name = "tsColors"
        Me.tsColors.Size = New System.Drawing.Size(71, 21)
        Me.tsColors.Text = "&Colors"
        '
        'tsImport
        '
        Me.tsImport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsImport.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsImport.Image = CType(resources.GetObject("tsImport.Image"), System.Drawing.Image)
        Me.tsImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsImport.Name = "tsImport"
        Me.tsImport.Size = New System.Drawing.Size(74, 21)
        Me.tsImport.Text = "I&mport"
        '
        'tsRefresh
        '
        Me.tsRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsRefresh.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tsRefresh.Image = CType(resources.GetObject("tsRefresh.Image"), System.Drawing.Image)
        Me.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRefresh.Name = "tsRefresh"
        Me.tsRefresh.Size = New System.Drawing.Size(78, 21)
        Me.tsRefresh.Text = "&Refresh"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(50, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 15)
        Me.Label4.TabIndex = 297
        Me.Label4.Text = "Page No.:"
        '
        'txtPage
        '
        Me.txtPage.Location = New System.Drawing.Point(228, 44)
        Me.txtPage.Name = "txtPage"
        Me.txtPage.Size = New System.Drawing.Size(41, 21)
        Me.txtPage.TabIndex = 17
        '
        'txtPageNo
        '
        Me.txtPageNo.Location = New System.Drawing.Point(121, 44)
        Me.txtPageNo.Name = "txtPageNo"
        Me.txtPageNo.ReadOnly = True
        Me.txtPageNo.Size = New System.Drawing.Size(101, 21)
        Me.txtPageNo.TabIndex = 16
        '
        'dgProductList
        '
        Me.dgProductList.AllowUserToAddRows = False
        Me.dgProductList.AllowUserToDeleteRows = False
        Me.dgProductList.AllowUserToOrderColumns = True
        Me.dgProductList.AllowUserToResizeRows = False
        Me.dgProductList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgProductList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.p_rowid, Me.p_seqno, Me.p_productcode, Me.p_brandname, Me.p_category, Me.p_company})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgProductList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductList.Location = New System.Drawing.Point(8, 68)
        Me.dgProductList.MultiSelect = False
        Me.dgProductList.Name = "dgProductList"
        Me.dgProductList.ReadOnly = True
        Me.dgProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductList.Size = New System.Drawing.Size(324, 295)
        Me.dgProductList.TabIndex = 18
        '
        'p_rowid
        '
        Me.p_rowid.HeaderText = "rowid"
        Me.p_rowid.Name = "p_rowid"
        Me.p_rowid.ReadOnly = True
        Me.p_rowid.Visible = False
        '
        'p_seqno
        '
        Me.p_seqno.HeaderText = "Seq. No."
        Me.p_seqno.Name = "p_seqno"
        Me.p_seqno.ReadOnly = True
        Me.p_seqno.Width = 50
        '
        'p_productcode
        '
        Me.p_productcode.HeaderText = "Product Code"
        Me.p_productcode.Name = "p_productcode"
        Me.p_productcode.ReadOnly = True
        Me.p_productcode.Width = 120
        '
        'p_brandname
        '
        Me.p_brandname.HeaderText = "Brand Name"
        Me.p_brandname.Name = "p_brandname"
        Me.p_brandname.ReadOnly = True
        '
        'p_category
        '
        Me.p_category.HeaderText = "Category"
        Me.p_category.Name = "p_category"
        Me.p_category.ReadOnly = True
        '
        'p_company
        '
        Me.p_company.HeaderText = "Vendor Name"
        Me.p_company.Name = "p_company"
        Me.p_company.ReadOnly = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Label16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(6, 1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 17)
        Me.Label16.TabIndex = 216
        Me.Label16.Text = "Product List:"
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
        Me.Label21.BackColor = System.Drawing.Color.DarkSeaGreen
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
        Me.txtSimpleSearch.TabIndex = 10
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
        'cboSearch4
        '
        Me.cboSearch4.FormattingEnabled = True
        Me.cboSearch4.Location = New System.Drawing.Point(115, 39)
        Me.cboSearch4.Name = "cboSearch4"
        Me.cboSearch4.Size = New System.Drawing.Size(191, 23)
        Me.cboSearch4.TabIndex = 14
        '
        'cboSearch2
        '
        Me.cboSearch2.FormattingEnabled = True
        Me.cboSearch2.Location = New System.Drawing.Point(115, 13)
        Me.cboSearch2.Name = "cboSearch2"
        Me.cboSearch2.Size = New System.Drawing.Size(191, 23)
        Me.cboSearch2.TabIndex = 12
        '
        'cboSearch3
        '
        Me.cboSearch3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch3.FormattingEnabled = True
        Me.cboSearch3.Location = New System.Drawing.Point(8, 39)
        Me.cboSearch3.Name = "cboSearch3"
        Me.cboSearch3.Size = New System.Drawing.Size(102, 23)
        Me.cboSearch3.TabIndex = 13
        '
        'cboSearch1
        '
        Me.cboSearch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch1.FormattingEnabled = True
        Me.cboSearch1.Location = New System.Drawing.Point(8, 13)
        Me.cboSearch1.Name = "cboSearch1"
        Me.cboSearch1.Size = New System.Drawing.Size(102, 23)
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
        Me.tabMain.Size = New System.Drawing.Size(835, 503)
        Me.tabMain.TabIndex = 223
        '
        'tabDetails
        '
        Me.tabDetails.AutoScroll = True
        Me.tabDetails.Controls.Add(Me.gbInventoryLocation)
        Me.tabDetails.Controls.Add(Me.gbRackShelfColumn)
        Me.tabDetails.Controls.Add(Me.gbProductImage)
        Me.tabDetails.Controls.Add(Me.gbProductSize)
        Me.tabDetails.Controls.Add(Me.gbProductColor)
        Me.tabDetails.Controls.Add(Me.gbProductInformation)
        Me.tabDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(827, 472)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Product Details"
        Me.tabDetails.UseVisualStyleBackColor = True
        '
        'gbInventoryLocation
        '
        Me.gbInventoryLocation.Controls.Add(Me.dgInventoryLocations)
        Me.gbInventoryLocation.Controls.Add(Me.Label3)
        Me.gbInventoryLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbInventoryLocation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbInventoryLocation.Location = New System.Drawing.Point(419, 150)
        Me.gbInventoryLocation.Name = "gbInventoryLocation"
        Me.gbInventoryLocation.Size = New System.Drawing.Size(397, 175)
        Me.gbInventoryLocation.TabIndex = 7
        Me.gbInventoryLocation.TabStop = False
        '
        'dgInventoryLocations
        '
        Me.dgInventoryLocations.AllowUserToAddRows = False
        Me.dgInventoryLocations.AllowUserToDeleteRows = False
        Me.dgInventoryLocations.AllowUserToOrderColumns = True
        Me.dgInventoryLocations.AllowUserToResizeRows = False
        Me.dgInventoryLocations.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgInventoryLocations.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgInventoryLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgInventoryLocations.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.il_rowid, Me.il_seqno, Me.il_locationname, Me.il_totalqtyavailable, Me.il_totalqtyallocated, Me.il_totalqtyreserve, Me.il_totalqtydamage, Me.il_locationtype})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgInventoryLocations.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgInventoryLocations.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgInventoryLocations.Location = New System.Drawing.Point(6, 20)
        Me.dgInventoryLocations.MultiSelect = False
        Me.dgInventoryLocations.Name = "dgInventoryLocations"
        Me.dgInventoryLocations.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgInventoryLocations.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgInventoryLocations.RowHeadersVisible = False
        Me.dgInventoryLocations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgInventoryLocations.Size = New System.Drawing.Size(385, 145)
        Me.dgInventoryLocations.TabIndex = 37
        '
        'il_rowid
        '
        Me.il_rowid.HeaderText = "rowid"
        Me.il_rowid.Name = "il_rowid"
        Me.il_rowid.ReadOnly = True
        Me.il_rowid.Visible = False
        '
        'il_seqno
        '
        Me.il_seqno.HeaderText = "Seq. No."
        Me.il_seqno.Name = "il_seqno"
        Me.il_seqno.ReadOnly = True
        Me.il_seqno.Width = 50
        '
        'il_locationname
        '
        Me.il_locationname.HeaderText = "Location Name"
        Me.il_locationname.Name = "il_locationname"
        Me.il_locationname.ReadOnly = True
        '
        'il_totalqtyavailable
        '
        Me.il_totalqtyavailable.HeaderText = "Overall Qty. Available"
        Me.il_totalqtyavailable.Name = "il_totalqtyavailable"
        Me.il_totalqtyavailable.ReadOnly = True
        Me.il_totalqtyavailable.Width = 92
        '
        'il_totalqtyallocated
        '
        Me.il_totalqtyallocated.HeaderText = "Overall Qty. Allocated"
        Me.il_totalqtyallocated.Name = "il_totalqtyallocated"
        Me.il_totalqtyallocated.ReadOnly = True
        Me.il_totalqtyallocated.Width = 92
        '
        'il_totalqtyreserve
        '
        Me.il_totalqtyreserve.HeaderText = "Overall Qty. Reserve"
        Me.il_totalqtyreserve.Name = "il_totalqtyreserve"
        Me.il_totalqtyreserve.ReadOnly = True
        Me.il_totalqtyreserve.Width = 92
        '
        'il_totalqtydamage
        '
        Me.il_totalqtydamage.HeaderText = "Overall Qty. Damage"
        Me.il_totalqtydamage.Name = "il_totalqtydamage"
        Me.il_totalqtydamage.ReadOnly = True
        Me.il_totalqtydamage.Width = 92
        '
        'il_locationtype
        '
        Me.il_locationtype.HeaderText = "Location Type"
        Me.il_locationtype.Name = "il_locationtype"
        Me.il_locationtype.ReadOnly = True
        Me.il_locationtype.Width = 70
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(9, -3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 17)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "Inventory Location:"
        '
        'gbRackShelfColumn
        '
        Me.gbRackShelfColumn.Controls.Add(Me.txtSeasonCode)
        Me.gbRackShelfColumn.Controls.Add(Me.Label19)
        Me.gbRackShelfColumn.Controls.Add(Me.txtLocation)
        Me.gbRackShelfColumn.Controls.Add(Me.Label11)
        Me.gbRackShelfColumn.Controls.Add(Me.txtSize)
        Me.gbRackShelfColumn.Controls.Add(Me.Label10)
        Me.gbRackShelfColumn.Controls.Add(Me.txtColor)
        Me.gbRackShelfColumn.Controls.Add(Me.Label7)
        Me.gbRackShelfColumn.Controls.Add(Me.dgRackShelfColumn)
        Me.gbRackShelfColumn.Controls.Add(Me.Label15)
        Me.gbRackShelfColumn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRackShelfColumn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbRackShelfColumn.Location = New System.Drawing.Point(419, 328)
        Me.gbRackShelfColumn.Name = "gbRackShelfColumn"
        Me.gbRackShelfColumn.Size = New System.Drawing.Size(397, 245)
        Me.gbRackShelfColumn.TabIndex = 8
        Me.gbRackShelfColumn.TabStop = False
        '
        'txtSeasonCode
        '
        Me.txtSeasonCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeasonCode.Location = New System.Drawing.Point(241, 25)
        Me.txtSeasonCode.Name = "txtSeasonCode"
        Me.txtSeasonCode.ReadOnly = True
        Me.txtSeasonCode.Size = New System.Drawing.Size(150, 21)
        Me.txtSeasonCode.TabIndex = 40
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(146, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 15)
        Me.Label19.TabIndex = 280
        Me.Label19.Text = "Season Code:"
        '
        'txtLocation
        '
        Me.txtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(241, 50)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(150, 21)
        Me.txtLocation.TabIndex = 41
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(146, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 15)
        Me.Label11.TabIndex = 279
        Me.Label11.Text = "Location Name:"
        '
        'txtSize
        '
        Me.txtSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSize.Location = New System.Drawing.Point(43, 50)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        Me.txtSize.Size = New System.Drawing.Size(95, 21)
        Me.txtSize.TabIndex = 39
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(3, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 15)
        Me.Label10.TabIndex = 277
        Me.Label10.Text = "Size:"
        '
        'txtColor
        '
        Me.txtColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColor.Location = New System.Drawing.Point(43, 25)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(95, 21)
        Me.txtColor.TabIndex = 38
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(3, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 15)
        Me.Label7.TabIndex = 275
        Me.Label7.Text = "Color:"
        '
        'dgRackShelfColumn
        '
        Me.dgRackShelfColumn.AllowUserToAddRows = False
        Me.dgRackShelfColumn.AllowUserToDeleteRows = False
        Me.dgRackShelfColumn.AllowUserToOrderColumns = True
        Me.dgRackShelfColumn.AllowUserToResizeRows = False
        Me.dgRackShelfColumn.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRackShelfColumn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgRackShelfColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRackShelfColumn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rsc_rowid, Me.rsc_qtyreserve, Me.rsc_qtydamage, Me.rsc_seqno, Me.rsc_rack, Me.rsc_column, Me.rsc_shelf, Me.rsc_qtyavailable, Me.rsc_qtyallocated, Me.rsc_qtyorderable})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgRackShelfColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgRackShelfColumn.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgRackShelfColumn.Location = New System.Drawing.Point(6, 77)
        Me.dgRackShelfColumn.MultiSelect = False
        Me.dgRackShelfColumn.Name = "dgRackShelfColumn"
        Me.dgRackShelfColumn.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRackShelfColumn.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgRackShelfColumn.RowHeadersVisible = False
        Me.dgRackShelfColumn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRackShelfColumn.Size = New System.Drawing.Size(385, 160)
        Me.dgRackShelfColumn.TabIndex = 42
        '
        'rsc_rowid
        '
        Me.rsc_rowid.HeaderText = "rowid"
        Me.rsc_rowid.Name = "rsc_rowid"
        Me.rsc_rowid.ReadOnly = True
        Me.rsc_rowid.Visible = False
        '
        'rsc_qtyreserve
        '
        Me.rsc_qtyreserve.HeaderText = "qty. reserve"
        Me.rsc_qtyreserve.Name = "rsc_qtyreserve"
        Me.rsc_qtyreserve.ReadOnly = True
        Me.rsc_qtyreserve.Visible = False
        Me.rsc_qtyreserve.Width = 60
        '
        'rsc_qtydamage
        '
        Me.rsc_qtydamage.HeaderText = "qty. damage"
        Me.rsc_qtydamage.Name = "rsc_qtydamage"
        Me.rsc_qtydamage.ReadOnly = True
        Me.rsc_qtydamage.Visible = False
        Me.rsc_qtydamage.Width = 60
        '
        'rsc_seqno
        '
        Me.rsc_seqno.HeaderText = "Seq. No."
        Me.rsc_seqno.Name = "rsc_seqno"
        Me.rsc_seqno.ReadOnly = True
        Me.rsc_seqno.Width = 50
        '
        'rsc_rack
        '
        Me.rsc_rack.HeaderText = "Rack"
        Me.rsc_rack.Name = "rsc_rack"
        Me.rsc_rack.ReadOnly = True
        Me.rsc_rack.Width = 50
        '
        'rsc_column
        '
        Me.rsc_column.HeaderText = "Column"
        Me.rsc_column.Name = "rsc_column"
        Me.rsc_column.ReadOnly = True
        Me.rsc_column.Width = 60
        '
        'rsc_shelf
        '
        Me.rsc_shelf.HeaderText = "Shelf"
        Me.rsc_shelf.Name = "rsc_shelf"
        Me.rsc_shelf.ReadOnly = True
        Me.rsc_shelf.Width = 50
        '
        'rsc_qtyavailable
        '
        Me.rsc_qtyavailable.HeaderText = "Qty. Available"
        Me.rsc_qtyavailable.Name = "rsc_qtyavailable"
        Me.rsc_qtyavailable.ReadOnly = True
        Me.rsc_qtyavailable.Width = 60
        '
        'rsc_qtyallocated
        '
        Me.rsc_qtyallocated.HeaderText = "Qty. Allocated"
        Me.rsc_qtyallocated.Name = "rsc_qtyallocated"
        Me.rsc_qtyallocated.ReadOnly = True
        Me.rsc_qtyallocated.Width = 60
        '
        'rsc_qtyorderable
        '
        Me.rsc_qtyorderable.HeaderText = "Qty. Orderable"
        Me.rsc_qtyorderable.Name = "rsc_qtyorderable"
        Me.rsc_qtyorderable.ReadOnly = True
        Me.rsc_qtyorderable.Width = 60
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(9, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(163, 17)
        Me.Label15.TabIndex = 228
        Me.Label15.Text = "Rack / Column / Shelf:"
        '
        'gbProductImage
        '
        Me.gbProductImage.Controls.Add(Me.btnDownloadImage)
        Me.gbProductImage.Controls.Add(Me.Label2)
        Me.gbProductImage.Controls.Add(Me.txtImagePath)
        Me.gbProductImage.Controls.Add(Me.pbProductImage)
        Me.gbProductImage.Controls.Add(Me.btnDeleteImage)
        Me.gbProductImage.Controls.Add(Me.btnChangeImage)
        Me.gbProductImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProductImage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbProductImage.Location = New System.Drawing.Point(581, 5)
        Me.gbProductImage.Name = "gbProductImage"
        Me.gbProductImage.Size = New System.Drawing.Size(235, 139)
        Me.gbProductImage.TabIndex = 4
        Me.gbProductImage.TabStop = False
        '
        'btnDownloadImage
        '
        Me.btnDownloadImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDownloadImage.Location = New System.Drawing.Point(13, 84)
        Me.btnDownloadImage.Name = "btnDownloadImage"
        Me.btnDownloadImage.Size = New System.Drawing.Size(74, 24)
        Me.btnDownloadImage.TabIndex = 28
        Me.btnDownloadImage.Text = "Download"
        Me.btnDownloadImage.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(9, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 17)
        Me.Label2.TabIndex = 228
        Me.Label2.Text = "Product Image:"
        '
        'txtImagePath
        '
        Me.txtImagePath.Enabled = False
        Me.txtImagePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImagePath.Location = New System.Drawing.Point(13, 112)
        Me.txtImagePath.Name = "txtImagePath"
        Me.txtImagePath.Size = New System.Drawing.Size(74, 21)
        Me.txtImagePath.TabIndex = 29
        Me.txtImagePath.Visible = False
        '
        'pbProductImage
        '
        Me.pbProductImage.BackColor = System.Drawing.SystemColors.Control
        Me.pbProductImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbProductImage.Location = New System.Drawing.Point(94, 21)
        Me.pbProductImage.Name = "pbProductImage"
        Me.pbProductImage.Size = New System.Drawing.Size(135, 114)
        Me.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbProductImage.TabIndex = 397
        Me.pbProductImage.TabStop = False
        '
        'btnDeleteImage
        '
        Me.btnDeleteImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteImage.Location = New System.Drawing.Point(13, 58)
        Me.btnDeleteImage.Name = "btnDeleteImage"
        Me.btnDeleteImage.Size = New System.Drawing.Size(74, 24)
        Me.btnDeleteImage.TabIndex = 27
        Me.btnDeleteImage.Text = "Delete"
        Me.btnDeleteImage.UseVisualStyleBackColor = True
        '
        'btnChangeImage
        '
        Me.btnChangeImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeImage.Location = New System.Drawing.Point(13, 31)
        Me.btnChangeImage.Name = "btnChangeImage"
        Me.btnChangeImage.Size = New System.Drawing.Size(74, 24)
        Me.btnChangeImage.TabIndex = 26
        Me.btnChangeImage.Text = "Change"
        Me.btnChangeImage.UseVisualStyleBackColor = True
        '
        'gbProductSize
        '
        Me.gbProductSize.Controls.Add(Me.lblSeasonCode)
        Me.gbProductSize.Controls.Add(Me.txtEditSeasonCode)
        Me.gbProductSize.Controls.Add(Me.txtSumQtyAllocated)
        Me.gbProductSize.Controls.Add(Me.Label20)
        Me.gbProductSize.Controls.Add(Me.txtLastSoldDate)
        Me.gbProductSize.Controls.Add(Me.Label13)
        Me.gbProductSize.Controls.Add(Me.txtSumQtyReserve)
        Me.gbProductSize.Controls.Add(Me.Label12)
        Me.gbProductSize.Controls.Add(Me.txtSumQtyAvailable)
        Me.gbProductSize.Controls.Add(Me.Label5)
        Me.gbProductSize.Controls.Add(Me.dgProductSizes)
        Me.gbProductSize.Controls.Add(Me.Label1)
        Me.gbProductSize.Controls.Add(Me.lblSKU)
        Me.gbProductSize.Controls.Add(Me.txtLastShipmentDate)
        Me.gbProductSize.Controls.Add(Me.Label8)
        Me.gbProductSize.Controls.Add(Me.txtSKU)
        Me.gbProductSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProductSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbProductSize.Location = New System.Drawing.Point(175, 150)
        Me.gbProductSize.Name = "gbProductSize"
        Me.gbProductSize.Size = New System.Drawing.Size(240, 423)
        Me.gbProductSize.TabIndex = 6
        Me.gbProductSize.TabStop = False
        '
        'lblSeasonCode
        '
        Me.lblSeasonCode.AutoSize = True
        Me.lblSeasonCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeasonCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSeasonCode.Location = New System.Drawing.Point(135, 322)
        Me.lblSeasonCode.Name = "lblSeasonCode"
        Me.lblSeasonCode.Size = New System.Drawing.Size(84, 15)
        Me.lblSeasonCode.TabIndex = 467
        Me.lblSeasonCode.Text = "Season Code:"
        '
        'txtEditSeasonCode
        '
        Me.txtEditSeasonCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditSeasonCode.Location = New System.Drawing.Point(123, 340)
        Me.txtEditSeasonCode.Name = "txtEditSeasonCode"
        Me.txtEditSeasonCode.Size = New System.Drawing.Size(105, 21)
        Me.txtEditSeasonCode.TabIndex = 466
        '
        'txtSumQtyAllocated
        '
        Me.txtSumQtyAllocated.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSumQtyAllocated.Location = New System.Drawing.Point(88, 298)
        Me.txtSumQtyAllocated.Name = "txtSumQtyAllocated"
        Me.txtSumQtyAllocated.ReadOnly = True
        Me.txtSumQtyAllocated.Size = New System.Drawing.Size(65, 21)
        Me.txtSumQtyAllocated.TabIndex = 464
        Me.txtSumQtyAllocated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(90, 268)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(66, 26)
        Me.Label20.TabIndex = 465
        Me.Label20.Text = "(Sum) Qty." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Allocated:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtLastSoldDate
        '
        Me.txtLastSoldDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastSoldDate.Location = New System.Drawing.Point(99, 394)
        Me.txtLastSoldDate.Name = "txtLastSoldDate"
        Me.txtLastSoldDate.ReadOnly = True
        Me.txtLastSoldDate.Size = New System.Drawing.Size(135, 21)
        Me.txtLastSoldDate.TabIndex = 36
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(3, 397)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 15)
        Me.Label13.TabIndex = 463
        Me.Label13.Text = "Last Sold Date:"
        '
        'txtSumQtyReserve
        '
        Me.txtSumQtyReserve.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSumQtyReserve.Location = New System.Drawing.Point(163, 298)
        Me.txtSumQtyReserve.Name = "txtSumQtyReserve"
        Me.txtSumQtyReserve.ReadOnly = True
        Me.txtSumQtyReserve.Size = New System.Drawing.Size(65, 21)
        Me.txtSumQtyReserve.TabIndex = 33
        Me.txtSumQtyReserve.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(162, 268)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 26)
        Me.Label12.TabIndex = 461
        Me.Label12.Text = "(Sum) Qty." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Reserve:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSumQtyAvailable
        '
        Me.txtSumQtyAvailable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSumQtyAvailable.Location = New System.Drawing.Point(12, 298)
        Me.txtSumQtyAvailable.Name = "txtSumQtyAvailable"
        Me.txtSumQtyAvailable.ReadOnly = True
        Me.txtSumQtyAvailable.Size = New System.Drawing.Size(65, 21)
        Me.txtSumQtyAvailable.TabIndex = 32
        Me.txtSumQtyAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(12, 268)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 26)
        Me.Label5.TabIndex = 459
        Me.Label5.Text = "(Sum) Qty." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Available:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgProductSizes
        '
        Me.dgProductSizes.AllowUserToAddRows = False
        Me.dgProductSizes.AllowUserToDeleteRows = False
        Me.dgProductSizes.AllowUserToOrderColumns = True
        Me.dgProductSizes.AllowUserToResizeRows = False
        Me.dgProductSizes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductSizes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgProductSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductSizes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.s_rowid, Me.s_sizes, Me.s_seasoncode, Me.s_totalqtyavailable, Me.s_totalqtyallocated, Me.s_totalqtyreserve, Me.s_active})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductSizes.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgProductSizes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductSizes.Location = New System.Drawing.Point(6, 20)
        Me.dgProductSizes.MultiSelect = False
        Me.dgProductSizes.Name = "dgProductSizes"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductSizes.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgProductSizes.RowHeadersVisible = False
        Me.dgProductSizes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductSizes.Size = New System.Drawing.Size(228, 245)
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
        's_totalqtyavailable
        '
        Me.s_totalqtyavailable.HeaderText = "Total Qty. Available"
        Me.s_totalqtyavailable.Name = "s_totalqtyavailable"
        Me.s_totalqtyavailable.ReadOnly = True
        Me.s_totalqtyavailable.Width = 80
        '
        's_totalqtyallocated
        '
        Me.s_totalqtyallocated.HeaderText = "Total Qty. Allocated"
        Me.s_totalqtyallocated.Name = "s_totalqtyallocated"
        Me.s_totalqtyallocated.ReadOnly = True
        Me.s_totalqtyallocated.Width = 80
        '
        's_totalqtyreserve
        '
        Me.s_totalqtyreserve.HeaderText = "Total Qty. Reserve"
        Me.s_totalqtyreserve.Name = "s_totalqtyreserve"
        Me.s_totalqtyreserve.ReadOnly = True
        Me.s_totalqtyreserve.Width = 80
        '
        's_active
        '
        Me.s_active.HeaderText = "Active"
        Me.s_active.Name = "s_active"
        Me.s_active.Width = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(9, -3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 17)
        Me.Label1.TabIndex = 228
        Me.Label1.Text = "Product Sizes And Season Code:"
        '
        'lblSKU
        '
        Me.lblSKU.AutoSize = True
        Me.lblSKU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSKU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSKU.Location = New System.Drawing.Point(47, 322)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(35, 15)
        Me.lblSKU.TabIndex = 272
        Me.lblSKU.Text = "SKU:"
        '
        'txtLastShipmentDate
        '
        Me.txtLastShipmentDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastShipmentDate.Location = New System.Drawing.Point(123, 367)
        Me.txtLastShipmentDate.Name = "txtLastShipmentDate"
        Me.txtLastShipmentDate.ReadOnly = True
        Me.txtLastShipmentDate.Size = New System.Drawing.Size(111, 21)
        Me.txtLastShipmentDate.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(3, 370)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 15)
        Me.Label8.TabIndex = 273
        Me.Label8.Text = "Last Shipment Date:"
        '
        'txtSKU
        '
        Me.txtSKU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKU.Location = New System.Drawing.Point(12, 340)
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.Size = New System.Drawing.Size(105, 21)
        Me.txtSKU.TabIndex = 34
        '
        'gbProductColor
        '
        Me.gbProductColor.Controls.Add(Me.dgProductColors)
        Me.gbProductColor.Controls.Add(Me.Label6)
        Me.gbProductColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProductColor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbProductColor.Location = New System.Drawing.Point(6, 150)
        Me.gbProductColor.Name = "gbProductColor"
        Me.gbProductColor.Size = New System.Drawing.Size(165, 423)
        Me.gbProductColor.TabIndex = 5
        Me.gbProductColor.TabStop = False
        '
        'dgProductColors
        '
        Me.dgProductColors.AllowUserToAddRows = False
        Me.dgProductColors.AllowUserToDeleteRows = False
        Me.dgProductColors.AllowUserToOrderColumns = True
        Me.dgProductColors.AllowUserToResizeRows = False
        Me.dgProductColors.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColors.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgProductColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductColors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c_rowid, Me.c_colorvalue, Me.c_seqno, Me.c_colorname, Me.c_color})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductColors.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgProductColors.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductColors.Location = New System.Drawing.Point(7, 20)
        Me.dgProductColors.MultiSelect = False
        Me.dgProductColors.Name = "dgProductColors"
        Me.dgProductColors.ReadOnly = True
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductColors.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgProductColors.RowHeadersVisible = False
        Me.dgProductColors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductColors.Size = New System.Drawing.Size(150, 395)
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
        Me.c_color.Width = 40
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(9, -3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 17)
        Me.Label6.TabIndex = 228
        Me.Label6.Text = "Product Colors:"
        '
        'gbProductInformation
        '
        Me.gbProductInformation.Controls.Add(Me.pbAutoAddD)
        Me.gbProductInformation.Controls.Add(Me.pbAutoAddC)
        Me.gbProductInformation.Controls.Add(Me.pbAutoAddB)
        Me.gbProductInformation.Controls.Add(Me.pbAutoAddA)
        Me.gbProductInformation.Controls.Add(Me.cboUnitOfMeasure)
        Me.gbProductInformation.Controls.Add(Me.Label14)
        Me.gbProductInformation.Controls.Add(Me.cboCompany)
        Me.gbProductInformation.Controls.Add(Me.cboBrandName)
        Me.gbProductInformation.Controls.Add(Me.cboCategory)
        Me.gbProductInformation.Controls.Add(Me.Label47)
        Me.gbProductInformation.Controls.Add(Me.txtSRP)
        Me.gbProductInformation.Controls.Add(Me.Label18)
        Me.gbProductInformation.Controls.Add(Me.Label17)
        Me.gbProductInformation.Controls.Add(Me.txtDescription)
        Me.gbProductInformation.Controls.Add(Me.Label40)
        Me.gbProductInformation.Controls.Add(Me.Label42)
        Me.gbProductInformation.Controls.Add(Me.txtProductCode)
        Me.gbProductInformation.Controls.Add(Me.Label46)
        Me.gbProductInformation.Controls.Add(Me.Label51)
        Me.gbProductInformation.Controls.Add(Me.Label52)
        Me.gbProductInformation.Controls.Add(Me.Label55)
        Me.gbProductInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProductInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbProductInformation.Location = New System.Drawing.Point(6, 5)
        Me.gbProductInformation.Name = "gbProductInformation"
        Me.gbProductInformation.Size = New System.Drawing.Size(569, 139)
        Me.gbProductInformation.TabIndex = 3
        Me.gbProductInformation.TabStop = False
        '
        'pbAutoAddD
        '
        Me.pbAutoAddD.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddD.Image = CType(resources.GetObject("pbAutoAddD.Image"), System.Drawing.Image)
        Me.pbAutoAddD.Location = New System.Drawing.Point(532, 55)
        Me.pbAutoAddD.Name = "pbAutoAddD"
        Me.pbAutoAddD.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddD.TabIndex = 533
        Me.pbAutoAddD.TabStop = False
        Me.pbAutoAddD.Tag = ""
        '
        'pbAutoAddC
        '
        Me.pbAutoAddC.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddC.Image = CType(resources.GetObject("pbAutoAddC.Image"), System.Drawing.Image)
        Me.pbAutoAddC.Location = New System.Drawing.Point(268, 109)
        Me.pbAutoAddC.Name = "pbAutoAddC"
        Me.pbAutoAddC.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddC.TabIndex = 532
        Me.pbAutoAddC.TabStop = False
        Me.pbAutoAddC.Tag = ""
        '
        'pbAutoAddB
        '
        Me.pbAutoAddB.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddB.Image = CType(resources.GetObject("pbAutoAddB.Image"), System.Drawing.Image)
        Me.pbAutoAddB.Location = New System.Drawing.Point(268, 82)
        Me.pbAutoAddB.Name = "pbAutoAddB"
        Me.pbAutoAddB.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddB.TabIndex = 531
        Me.pbAutoAddB.TabStop = False
        Me.pbAutoAddB.Tag = ""
        '
        'pbAutoAddA
        '
        Me.pbAutoAddA.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddA.Image = CType(resources.GetObject("pbAutoAddA.Image"), System.Drawing.Image)
        Me.pbAutoAddA.Location = New System.Drawing.Point(268, 55)
        Me.pbAutoAddA.Name = "pbAutoAddA"
        Me.pbAutoAddA.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddA.TabIndex = 530
        Me.pbAutoAddA.TabStop = False
        Me.pbAutoAddA.Tag = ""
        '
        'cboUnitOfMeasure
        '
        Me.cboUnitOfMeasure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUnitOfMeasure.FormattingEnabled = True
        Me.cboUnitOfMeasure.Location = New System.Drawing.Point(408, 52)
        Me.cboUnitOfMeasure.Name = "cboUnitOfMeasure"
        Me.cboUnitOfMeasure.Size = New System.Drawing.Size(120, 23)
        Me.cboUnitOfMeasure.TabIndex = 24
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(309, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 15)
        Me.Label14.TabIndex = 302
        Me.Label14.Text = "Unit of Measure:"
        '
        'cboCompany
        '
        Me.cboCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCompany.FormattingEnabled = True
        Me.cboCompany.Location = New System.Drawing.Point(106, 106)
        Me.cboCompany.Name = "cboCompany"
        Me.cboCompany.Size = New System.Drawing.Size(160, 23)
        Me.cboCompany.TabIndex = 22
        '
        'cboBrandName
        '
        Me.cboBrandName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBrandName.FormattingEnabled = True
        Me.cboBrandName.Location = New System.Drawing.Point(106, 52)
        Me.cboBrandName.Name = "cboBrandName"
        Me.cboBrandName.Size = New System.Drawing.Size(160, 23)
        Me.cboBrandName.TabIndex = 20
        '
        'cboCategory
        '
        Me.cboCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(106, 79)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(160, 23)
        Me.cboCategory.TabIndex = 21
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(363, 27)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(23, 15)
        Me.Label47.TabIndex = 300
        Me.Label47.Text = "(₱)"
        '
        'txtSRP
        '
        Me.txtSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSRP.Location = New System.Drawing.Point(387, 25)
        Me.txtSRP.Name = "txtSRP"
        Me.txtSRP.Size = New System.Drawing.Size(164, 21)
        Me.txtSRP.TabIndex = 23
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(309, 28)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(35, 15)
        Me.Label18.TabIndex = 298
        Me.Label18.Text = "SRP:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(5, 109)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 15)
        Me.Label17.TabIndex = 296
        Me.Label17.Text = "Vendor Name:"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(387, 79)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(164, 50)
        Me.txtDescription.TabIndex = 25
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(309, 83)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(72, 15)
        Me.Label40.TabIndex = 294
        Me.Label40.Text = "Description:"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(5, 82)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(58, 15)
        Me.Label42.TabIndex = 292
        Me.Label42.Text = "Category:"
        '
        'txtProductCode
        '
        Me.txtProductCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductCode.Location = New System.Drawing.Point(106, 25)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Size = New System.Drawing.Size(183, 21)
        Me.txtProductCode.TabIndex = 19
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Red
        Me.Label46.Location = New System.Drawing.Point(87, 25)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(16, 20)
        Me.Label46.TabIndex = 278
        Me.Label46.Text = "*"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label51.Location = New System.Drawing.Point(5, 55)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(80, 15)
        Me.Label51.TabIndex = 273
        Me.Label51.Text = "Brand Name:"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(5, 28)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(84, 15)
        Me.Label52.TabIndex = 272
        Me.Label52.Text = "Product Code:"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.White
        Me.Label55.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label55.Location = New System.Drawing.Point(9, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(154, 17)
        Me.Label55.TabIndex = 228
        Me.Label55.Text = "Product Information:"
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(835, 25)
        Me.msMenu.TabIndex = 315
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(18, 5)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 193
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'ProductsForm
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
        Me.Name = "ProductsForm"
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbProductList.ResumeLayout(False)
        Me.gbProductList.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.dgProductList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.tabSearch.ResumeLayout(False)
        Me.tabSimple.ResumeLayout(False)
        Me.tabSimple.PerformLayout()
        Me.tabCommon.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.gbInventoryLocation.ResumeLayout(False)
        Me.gbInventoryLocation.PerformLayout()
        CType(Me.dgInventoryLocations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRackShelfColumn.ResumeLayout(False)
        Me.gbRackShelfColumn.PerformLayout()
        CType(Me.dgRackShelfColumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProductImage.ResumeLayout(False)
        Me.gbProductImage.PerformLayout()
        CType(Me.pbProductImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProductSize.ResumeLayout(False)
        Me.gbProductSize.PerformLayout()
        CType(Me.dgProductSizes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProductColor.ResumeLayout(False)
        Me.gbProductColor.PerformLayout()
        CType(Me.dgProductColors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProductInformation.ResumeLayout(False)
        Me.gbProductInformation.PerformLayout()
        CType(Me.pbAutoAddD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbProductList As System.Windows.Forms.GroupBox
    Friend WithEvents txtPage As System.Windows.Forms.TextBox
    Friend WithEvents txtPageNo As System.Windows.Forms.TextBox
    Friend WithEvents dgProductList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label16 As System.Windows.Forms.Label
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
    Friend WithEvents gbProductInformation As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents gbProductColor As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbProductSize As System.Windows.Forms.GroupBox
    Friend WithEvents dgProductSizes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgProductColors As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbProductImage As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbProductImage As System.Windows.Forms.PictureBox
    Friend WithEvents txtImagePath As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteImage As System.Windows.Forms.Button
    Friend WithEvents btnChangeImage As System.Windows.Forms.Button
    Friend WithEvents txtLastShipmentDate As System.Windows.Forms.TextBox
    Friend WithEvents txtSKU As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblSKU As System.Windows.Forms.Label
    Friend WithEvents gbRackShelfColumn As System.Windows.Forms.GroupBox
    Friend WithEvents dgRackShelfColumn As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtSRP As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnDownloadImage As System.Windows.Forms.Button
    Friend WithEvents gbInventoryLocation As System.Windows.Forms.GroupBox
    Friend WithEvents dgInventoryLocations As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboBrandName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCompany As System.Windows.Forms.ComboBox
    Friend WithEvents txtSumQtyAvailable As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSize As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSumQtyReserve As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboUnitOfMeasure As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtLastSoldDate As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtSeasonCode As System.Windows.Forms.TextBox
    Friend WithEvents c_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbAutoAddA As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddC As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddB As System.Windows.Forms.PictureBox
    Friend WithEvents pbAutoAddD As System.Windows.Forms.PictureBox
    Friend WithEvents tsColors As System.Windows.Forms.ToolStripButton
    Friend WithEvents p_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_brandname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_company As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtSumQtyAllocated As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblSeasonCode As System.Windows.Forms.Label
    Friend WithEvents txtEditSeasonCode As System.Windows.Forms.TextBox
    Friend WithEvents s_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_sizes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_totalqtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_totalqtyallocated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_totalqtyreserve As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_active As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents il_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents il_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents il_locationname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents il_totalqtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents il_totalqtyallocated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents il_totalqtyreserve As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents il_totalqtydamage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents il_locationtype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtyreserve As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtydamage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_rack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_shelf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtyallocated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtyorderable As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
