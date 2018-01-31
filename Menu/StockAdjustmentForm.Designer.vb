<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockAdjustmentForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockAdjustmentForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdFirst = New System.Windows.Forms.ToolStripButton()
        Me.gbStockAdjustmentOrderList = New System.Windows.Forms.GroupBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.cmdPrev = New System.Windows.Forms.ToolStripButton()
        Me.cmdNext = New System.Windows.Forms.ToolStripButton()
        Me.cmdLast = New System.Windows.Forms.ToolStripButton()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPage = New System.Windows.Forms.TextBox()
        Me.txtPageNo = New System.Windows.Forms.TextBox()
        Me.dgStockAdjusmentList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.s_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_StockNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_stockadjdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_stockadjstatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.tabSearch = New System.Windows.Forms.TabControl()
        Me.tabSimpleSearch = New System.Windows.Forms.TabPage()
        Me.txtSimpleSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabCommonSearch = New System.Windows.Forms.TabPage()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpToSearch = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromSearch = New System.Windows.Forms.DateTimePicker()
        Me.cboSearch4 = New System.Windows.Forms.ComboBox()
        Me.cboSearch3 = New System.Windows.Forms.ComboBox()
        Me.cboSearch2 = New System.Windows.Forms.ComboBox()
        Me.cboSearch1 = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.grpStockAdjrsc = New System.Windows.Forms.GroupBox()
        Me.pcAddtnlItems = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgrackshelfcolumn = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.grpStockAdjustmentitems = New System.Windows.Forms.GroupBox()
        Me.chkApproveAll = New System.Windows.Forms.CheckBox()
        Me.gbAddProductItem = New System.Windows.Forms.GroupBox()
        Me.cboItemCode = New System.Windows.Forms.ComboBox()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkOtherInfo = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgStockAdjustmentItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
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
        Me.ci_qtyreceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtystocked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_srp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_totalprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_approved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ci_option = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ci_itemtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_app = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbStockAdjustment = New System.Windows.Forms.GroupBox()
        Me.txtAdjustedBy = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtStockAdjustmentNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtpStockAdjustmentDate = New System.Windows.Forms.DateTimePicker()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.msOrder = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.r_rack = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.r_column = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.r_shelf = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.r_qtystock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_qtyallocated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_qtyapply = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_qtystocked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_datestocked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_prodinvlocinventoryid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_rscid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbStockAdjustmentOrderList.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.dgStockAdjusmentList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.tabSimpleSearch.SuspendLayout()
        Me.tabCommonSearch.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.grpStockAdjrsc.SuspendLayout()
        CType(Me.pcAddtnlItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgrackshelfcolumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStockAdjustmentitems.SuspendLayout()
        Me.gbAddProductItem.SuspendLayout()
        CType(Me.dgStockAdjustmentItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbStockAdjustment.SuspendLayout()
        Me.msMenu.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdFirst
        '
        Me.cmdFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdFirst.Image = CType(resources.GetObject("cmdFirst.Image"), System.Drawing.Image)
        Me.cmdFirst.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(24, 21)
        '
        'gbStockAdjustmentOrderList
        '
        Me.gbStockAdjustmentOrderList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbStockAdjustmentOrderList.BackColor = System.Drawing.Color.Transparent
        Me.gbStockAdjustmentOrderList.Controls.Add(Me.ToolStrip3)
        Me.gbStockAdjustmentOrderList.Controls.Add(Me.Label4)
        Me.gbStockAdjustmentOrderList.Controls.Add(Me.txtPage)
        Me.gbStockAdjustmentOrderList.Controls.Add(Me.txtPageNo)
        Me.gbStockAdjustmentOrderList.Controls.Add(Me.dgStockAdjusmentList)
        Me.gbStockAdjustmentOrderList.Controls.Add(Me.Label16)
        Me.gbStockAdjustmentOrderList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbStockAdjustmentOrderList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbStockAdjustmentOrderList.Location = New System.Drawing.Point(6, 181)
        Me.gbStockAdjustmentOrderList.Name = "gbStockAdjustmentOrderList"
        Me.gbStockAdjustmentOrderList.Size = New System.Drawing.Size(340, 340)
        Me.gbStockAdjustmentOrderList.TabIndex = 2
        Me.gbStockAdjustmentOrderList.TabStop = False
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
        'dgStockAdjusmentList
        '
        Me.dgStockAdjusmentList.AllowUserToAddRows = False
        Me.dgStockAdjusmentList.AllowUserToDeleteRows = False
        Me.dgStockAdjusmentList.AllowUserToOrderColumns = True
        Me.dgStockAdjusmentList.AllowUserToResizeRows = False
        Me.dgStockAdjusmentList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgStockAdjusmentList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStockAdjusmentList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgStockAdjusmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgStockAdjusmentList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.s_rowid, Me.s_StockNo, Me.s_stockadjdate, Me.s_stockadjstatus})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgStockAdjusmentList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgStockAdjusmentList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgStockAdjusmentList.Location = New System.Drawing.Point(8, 68)
        Me.dgStockAdjusmentList.MultiSelect = False
        Me.dgStockAdjusmentList.Name = "dgStockAdjusmentList"
        Me.dgStockAdjusmentList.ReadOnly = True
        Me.dgStockAdjusmentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgStockAdjusmentList.Size = New System.Drawing.Size(324, 266)
        Me.dgStockAdjusmentList.TabIndex = 18
        '
        's_rowid
        '
        Me.s_rowid.HeaderText = "RowID"
        Me.s_rowid.Name = "s_rowid"
        Me.s_rowid.ReadOnly = True
        Me.s_rowid.Visible = False
        '
        's_StockNo
        '
        Me.s_StockNo.HeaderText = "Stock Adj. No"
        Me.s_StockNo.Name = "s_StockNo"
        Me.s_StockNo.ReadOnly = True
        '
        's_stockadjdate
        '
        Me.s_stockadjdate.HeaderText = "Stock Adj. Date"
        Me.s_stockadjdate.Name = "s_stockadjdate"
        Me.s_stockadjdate.ReadOnly = True
        '
        's_stockadjstatus
        '
        Me.s_stockadjstatus.HeaderText = "Status"
        Me.s_stockadjstatus.Name = "s_stockadjstatus"
        Me.s_stockadjstatus.ReadOnly = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Chartreuse
        Me.Label16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(6, -1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(156, 17)
        Me.Label16.TabIndex = 216
        Me.Label16.Text = "Stock Adjusment List:"
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Chartreuse
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbStockAdjustmentOrderList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbSearch)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabMain)
        Me.SplitContainer1.Panel2.Controls.Add(Me.msMenu)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblsavemsg)
        Me.SplitContainer1.Size = New System.Drawing.Size(1200, 532)
        Me.SplitContainer1.SplitterDistance = 355
        Me.SplitContainer1.TabIndex = 245
        '
        'gbSearch
        '
        Me.gbSearch.BackColor = System.Drawing.Color.Transparent
        Me.gbSearch.Controls.Add(Me.tabSearch)
        Me.gbSearch.Controls.Add(Me.Label21)
        Me.gbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSearch.Location = New System.Drawing.Point(6, 5)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(340, 170)
        Me.gbSearch.TabIndex = 1
        Me.gbSearch.TabStop = False
        '
        'tabSearch
        '
        Me.tabSearch.Controls.Add(Me.tabSimpleSearch)
        Me.tabSearch.Controls.Add(Me.tabCommonSearch)
        Me.tabSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSearch.ItemSize = New System.Drawing.Size(62, 25)
        Me.tabSearch.Location = New System.Drawing.Point(8, 19)
        Me.tabSearch.Multiline = True
        Me.tabSearch.Name = "tabSearch"
        Me.tabSearch.SelectedIndex = 0
        Me.tabSearch.Size = New System.Drawing.Size(324, 145)
        Me.tabSearch.TabIndex = 218
        '
        'tabSimpleSearch
        '
        Me.tabSimpleSearch.Controls.Add(Me.txtSimpleSearch)
        Me.tabSimpleSearch.Controls.Add(Me.Label1)
        Me.tabSimpleSearch.Location = New System.Drawing.Point(4, 29)
        Me.tabSimpleSearch.Name = "tabSimpleSearch"
        Me.tabSimpleSearch.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSimpleSearch.Size = New System.Drawing.Size(316, 112)
        Me.tabSimpleSearch.TabIndex = 1
        Me.tabSimpleSearch.Text = "       Simple       "
        Me.tabSimpleSearch.UseVisualStyleBackColor = True
        '
        'txtSimpleSearch
        '
        Me.txtSimpleSearch.Location = New System.Drawing.Point(96, 37)
        Me.txtSimpleSearch.Name = "txtSimpleSearch"
        Me.txtSimpleSearch.Size = New System.Drawing.Size(214, 21)
        Me.txtSimpleSearch.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(4, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Search Phrase:"
        '
        'tabCommonSearch
        '
        Me.tabCommonSearch.Controls.Add(Me.Label40)
        Me.tabCommonSearch.Controls.Add(Me.Label14)
        Me.tabCommonSearch.Controls.Add(Me.dtpToSearch)
        Me.tabCommonSearch.Controls.Add(Me.dtpFromSearch)
        Me.tabCommonSearch.Controls.Add(Me.cboSearch4)
        Me.tabCommonSearch.Controls.Add(Me.cboSearch3)
        Me.tabCommonSearch.Controls.Add(Me.cboSearch2)
        Me.tabCommonSearch.Controls.Add(Me.cboSearch1)
        Me.tabCommonSearch.Location = New System.Drawing.Point(4, 29)
        Me.tabCommonSearch.Name = "tabCommonSearch"
        Me.tabCommonSearch.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCommonSearch.Size = New System.Drawing.Size(316, 112)
        Me.tabCommonSearch.TabIndex = 0
        Me.tabCommonSearch.Text = "       Common       "
        Me.tabCommonSearch.UseVisualStyleBackColor = True
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(170, 14)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(24, 15)
        Me.Label40.TabIndex = 251
        Me.Label40.Text = "To:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(4, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 15)
        Me.Label14.TabIndex = 250
        Me.Label14.Text = "From:"
        '
        'dtpToSearch
        '
        Me.dtpToSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpToSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpToSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToSearch.Location = New System.Drawing.Point(199, 10)
        Me.dtpToSearch.Name = "dtpToSearch"
        Me.dtpToSearch.Size = New System.Drawing.Size(113, 21)
        Me.dtpToSearch.TabIndex = 8
        '
        'dtpFromSearch
        '
        Me.dtpFromSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpFromSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFromSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromSearch.Location = New System.Drawing.Point(46, 10)
        Me.dtpFromSearch.Name = "dtpFromSearch"
        Me.dtpFromSearch.Size = New System.Drawing.Size(113, 21)
        Me.dtpFromSearch.TabIndex = 7
        '
        'cboSearch4
        '
        Me.cboSearch4.FormattingEnabled = True
        Me.cboSearch4.Location = New System.Drawing.Point(121, 66)
        Me.cboSearch4.Name = "cboSearch4"
        Me.cboSearch4.Size = New System.Drawing.Size(189, 23)
        Me.cboSearch4.TabIndex = 12
        '
        'cboSearch3
        '
        Me.cboSearch3.FormattingEnabled = True
        Me.cboSearch3.Location = New System.Drawing.Point(121, 40)
        Me.cboSearch3.Name = "cboSearch3"
        Me.cboSearch3.Size = New System.Drawing.Size(189, 23)
        Me.cboSearch3.TabIndex = 10
        '
        'cboSearch2
        '
        Me.cboSearch2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch2.FormattingEnabled = True
        Me.cboSearch2.Location = New System.Drawing.Point(6, 66)
        Me.cboSearch2.Name = "cboSearch2"
        Me.cboSearch2.Size = New System.Drawing.Size(109, 23)
        Me.cboSearch2.TabIndex = 11
        '
        'cboSearch1
        '
        Me.cboSearch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch1.FormattingEnabled = True
        Me.cboSearch1.Location = New System.Drawing.Point(6, 40)
        Me.cboSearch1.Name = "cboSearch1"
        Me.cboSearch1.Size = New System.Drawing.Size(109, 23)
        Me.cboSearch1.TabIndex = 9
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Chartreuse
        Me.Label21.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label21.Location = New System.Drawing.Point(6, -2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 17)
        Me.Label21.TabIndex = 217
        Me.Label21.Text = "Search:"
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
        Me.tabMain.Size = New System.Drawing.Size(837, 503)
        Me.tabMain.TabIndex = 223
        '
        'tabDetails
        '
        Me.tabDetails.AutoScroll = True
        Me.tabDetails.Controls.Add(Me.grpStockAdjrsc)
        Me.tabDetails.Controls.Add(Me.grpStockAdjustmentitems)
        Me.tabDetails.Controls.Add(Me.gbStockAdjustment)
        Me.tabDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(829, 472)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Stock Adj. Details"
        Me.tabDetails.UseVisualStyleBackColor = True
        '
        'grpStockAdjrsc
        '
        Me.grpStockAdjrsc.Controls.Add(Me.pcAddtnlItems)
        Me.grpStockAdjrsc.Controls.Add(Me.Label7)
        Me.grpStockAdjrsc.Controls.Add(Me.dgrackshelfcolumn)
        Me.grpStockAdjrsc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpStockAdjrsc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpStockAdjrsc.Location = New System.Drawing.Point(6, 410)
        Me.grpStockAdjrsc.Name = "grpStockAdjrsc"
        Me.grpStockAdjrsc.Size = New System.Drawing.Size(800, 200)
        Me.grpStockAdjrsc.TabIndex = 6
        Me.grpStockAdjrsc.TabStop = False
        '
        'pcAddtnlItems
        '
        Me.pcAddtnlItems.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pcAddtnlItems.Image = CType(resources.GetObject("pcAddtnlItems.Image"), System.Drawing.Image)
        Me.pcAddtnlItems.Location = New System.Drawing.Point(15, 17)
        Me.pcAddtnlItems.Name = "pcAddtnlItems"
        Me.pcAddtnlItems.Size = New System.Drawing.Size(14, 12)
        Me.pcAddtnlItems.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcAddtnlItems.TabIndex = 469
        Me.pcAddtnlItems.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(9, -1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(287, 17)
        Me.Label7.TabIndex = 238
        Me.Label7.Text = "Stock Adjustment Rack / Column / Shelf:"
        '
        'dgrackshelfcolumn
        '
        Me.dgrackshelfcolumn.AllowUserToAddRows = False
        Me.dgrackshelfcolumn.AllowUserToDeleteRows = False
        Me.dgrackshelfcolumn.AllowUserToOrderColumns = True
        Me.dgrackshelfcolumn.AllowUserToResizeRows = False
        Me.dgrackshelfcolumn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgrackshelfcolumn.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgrackshelfcolumn.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgrackshelfcolumn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgrackshelfcolumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrackshelfcolumn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.r_rack, Me.r_column, Me.r_shelf, Me.r_qtystock, Me.r_qtyallocated, Me.r_qtyapply, Me.r_qtystocked, Me.r_datestocked, Me.r_prodinvlocinventoryid, Me.r_rscid})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgrackshelfcolumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgrackshelfcolumn.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgrackshelfcolumn.Location = New System.Drawing.Point(6, 35)
        Me.dgrackshelfcolumn.MultiSelect = False
        Me.dgrackshelfcolumn.Name = "dgrackshelfcolumn"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgrackshelfcolumn.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgrackshelfcolumn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgrackshelfcolumn.Size = New System.Drawing.Size(790, 150)
        Me.dgrackshelfcolumn.TabIndex = 240
        '
        'grpStockAdjustmentitems
        '
        Me.grpStockAdjustmentitems.Controls.Add(Me.chkApproveAll)
        Me.grpStockAdjustmentitems.Controls.Add(Me.gbAddProductItem)
        Me.grpStockAdjustmentitems.Controls.Add(Me.chkOtherInfo)
        Me.grpStockAdjustmentitems.Controls.Add(Me.Label15)
        Me.grpStockAdjustmentitems.Controls.Add(Me.dgStockAdjustmentItems)
        Me.grpStockAdjustmentitems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpStockAdjustmentitems.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpStockAdjustmentitems.Location = New System.Drawing.Point(6, 120)
        Me.grpStockAdjustmentitems.Name = "grpStockAdjustmentitems"
        Me.grpStockAdjustmentitems.Size = New System.Drawing.Size(800, 280)
        Me.grpStockAdjustmentitems.TabIndex = 5
        Me.grpStockAdjustmentitems.TabStop = False
        '
        'chkApproveAll
        '
        Me.chkApproveAll.AutoSize = True
        Me.chkApproveAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkApproveAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkApproveAll.Location = New System.Drawing.Point(127, 258)
        Me.chkApproveAll.Name = "chkApproveAll"
        Me.chkApproveAll.Size = New System.Drawing.Size(89, 19)
        Me.chkApproveAll.TabIndex = 243
        Me.chkApproveAll.Text = "Approve All:"
        Me.chkApproveAll.UseVisualStyleBackColor = True
        '
        'gbAddProductItem
        '
        Me.gbAddProductItem.Controls.Add(Me.cboItemCode)
        Me.gbAddProductItem.Controls.Add(Me.btnAddProduct)
        Me.gbAddProductItem.Controls.Add(Me.Label8)
        Me.gbAddProductItem.Location = New System.Drawing.Point(11, 13)
        Me.gbAddProductItem.Name = "gbAddProductItem"
        Me.gbAddProductItem.Size = New System.Drawing.Size(548, 39)
        Me.gbAddProductItem.TabIndex = 243
        Me.gbAddProductItem.TabStop = False
        '
        'cboItemCode
        '
        Me.cboItemCode.FormattingEnabled = True
        Me.cboItemCode.Location = New System.Drawing.Point(69, 12)
        Me.cboItemCode.Name = "cboItemCode"
        Me.cboItemCode.Size = New System.Drawing.Size(410, 21)
        Me.cboItemCode.TabIndex = 30
        '
        'btnAddProduct
        '
        Me.btnAddProduct.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAddProduct.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProduct.Image = CType(resources.GetObject("btnAddProduct.Image"), System.Drawing.Image)
        Me.btnAddProduct.Location = New System.Drawing.Point(498, 7)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(45, 30)
        Me.btnAddProduct.TabIndex = 32
        Me.btnAddProduct.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 15)
        Me.Label8.TabIndex = 415
        Me.Label8.Text = "Item Code:"
        '
        'chkOtherInfo
        '
        Me.chkOtherInfo.AutoSize = True
        Me.chkOtherInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOtherInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOtherInfo.Location = New System.Drawing.Point(7, 258)
        Me.chkOtherInfo.Name = "chkOtherInfo"
        Me.chkOtherInfo.Size = New System.Drawing.Size(114, 19)
        Me.chkOtherInfo.TabIndex = 242
        Me.chkOtherInfo.Text = "View Other Info.:"
        Me.chkOtherInfo.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(9, -4)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(174, 17)
        Me.Label15.TabIndex = 238
        Me.Label15.Text = "Stock Adjustment Items:"
        '
        'dgStockAdjustmentItems
        '
        Me.dgStockAdjustmentItems.AllowUserToAddRows = False
        Me.dgStockAdjustmentItems.AllowUserToDeleteRows = False
        Me.dgStockAdjustmentItems.AllowUserToOrderColumns = True
        Me.dgStockAdjustmentItems.AllowUserToResizeRows = False
        Me.dgStockAdjustmentItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStockAdjustmentItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgStockAdjustmentItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgStockAdjustmentItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ci_rowid, Me.ci_pcsrowid, Me.ci_bid, Me.ci_colorvalue, Me.ci_seqno, Me.ci_productcode, Me.ci_colorname, Me.ci_color, Me.ci_size, Me.ci_seasoncode, Me.ci_unitofmeasure, Me.ci_qtyordered, Me.ci_qtyreceived, Me.ci_qtystocked, Me.ci_srp, Me.ci_totalprice, Me.ci_sku, Me.ci_remarks, Me.ci_approved, Me.ci_option, Me.ci_itemtype, Me.ci_app})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgStockAdjustmentItems.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgStockAdjustmentItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgStockAdjustmentItems.Location = New System.Drawing.Point(6, 55)
        Me.dgStockAdjustmentItems.MultiSelect = False
        Me.dgStockAdjustmentItems.Name = "dgStockAdjustmentItems"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStockAdjustmentItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgStockAdjustmentItems.RowHeadersVisible = False
        Me.dgStockAdjustmentItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgStockAdjustmentItems.Size = New System.Drawing.Size(790, 200)
        Me.dgStockAdjustmentItems.TabIndex = 241
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
        Me.ci_qtyordered.Visible = False
        Me.ci_qtyordered.Width = 60
        '
        'ci_qtyreceived
        '
        Me.ci_qtyreceived.HeaderText = "Qty. Received"
        Me.ci_qtyreceived.Name = "ci_qtyreceived"
        Me.ci_qtyreceived.Visible = False
        '
        'ci_qtystocked
        '
        Me.ci_qtystocked.HeaderText = "Qty. Stocked"
        Me.ci_qtystocked.Name = "ci_qtystocked"
        Me.ci_qtystocked.ReadOnly = True
        Me.ci_qtystocked.Visible = False
        '
        'ci_srp
        '
        Me.ci_srp.HeaderText = "SRP"
        Me.ci_srp.Name = "ci_srp"
        Me.ci_srp.Visible = False
        Me.ci_srp.Width = 80
        '
        'ci_totalprice
        '
        Me.ci_totalprice.HeaderText = "Total Price"
        Me.ci_totalprice.Name = "ci_totalprice"
        Me.ci_totalprice.ReadOnly = True
        Me.ci_totalprice.Visible = False
        '
        'ci_sku
        '
        Me.ci_sku.HeaderText = "SKU"
        Me.ci_sku.Name = "ci_sku"
        Me.ci_sku.ReadOnly = True
        '
        'ci_remarks
        '
        Me.ci_remarks.HeaderText = "Remarks"
        Me.ci_remarks.Name = "ci_remarks"
        '
        'ci_approved
        '
        Me.ci_approved.HeaderText = "Approve for Adjusting"
        Me.ci_approved.Name = "ci_approved"
        '
        'ci_option
        '
        Me.ci_option.HeaderText = ""
        Me.ci_option.Name = "ci_option"
        Me.ci_option.Text = "Delete"
        Me.ci_option.UseColumnTextForButtonValue = True
        Me.ci_option.Width = 50
        '
        'ci_itemtype
        '
        Me.ci_itemtype.HeaderText = "ItemType"
        Me.ci_itemtype.Name = "ci_itemtype"
        Me.ci_itemtype.Visible = False
        '
        'ci_app
        '
        Me.ci_app.HeaderText = "App"
        Me.ci_app.Name = "ci_app"
        Me.ci_app.Visible = False
        '
        'gbStockAdjustment
        '
        Me.gbStockAdjustment.Controls.Add(Me.txtAdjustedBy)
        Me.gbStockAdjustment.Controls.Add(Me.Label6)
        Me.gbStockAdjustment.Controls.Add(Me.txtStatus)
        Me.gbStockAdjustment.Controls.Add(Me.Label12)
        Me.gbStockAdjustment.Controls.Add(Me.txtComments)
        Me.gbStockAdjustment.Controls.Add(Me.Label9)
        Me.gbStockAdjustment.Controls.Add(Me.Label5)
        Me.gbStockAdjustment.Controls.Add(Me.txtStockAdjustmentNo)
        Me.gbStockAdjustment.Controls.Add(Me.Label2)
        Me.gbStockAdjustment.Controls.Add(Me.Label18)
        Me.gbStockAdjustment.Controls.Add(Me.dtpStockAdjustmentDate)
        Me.gbStockAdjustment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbStockAdjustment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbStockAdjustment.Location = New System.Drawing.Point(6, 6)
        Me.gbStockAdjustment.Name = "gbStockAdjustment"
        Me.gbStockAdjustment.Size = New System.Drawing.Size(800, 108)
        Me.gbStockAdjustment.TabIndex = 4
        Me.gbStockAdjustment.TabStop = False
        '
        'txtAdjustedBy
        '
        Me.txtAdjustedBy.Enabled = False
        Me.txtAdjustedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdjustedBy.Location = New System.Drawing.Point(583, 23)
        Me.txtAdjustedBy.Name = "txtAdjustedBy"
        Me.txtAdjustedBy.Size = New System.Drawing.Size(149, 21)
        Me.txtAdjustedBy.TabIndex = 442
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(503, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 15)
        Me.Label6.TabIndex = 441
        Me.Label6.Text = "Adjusted By:"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(383, 24)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(110, 21)
        Me.txtStatus.TabIndex = 439
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(309, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 440
        Me.Label12.Text = "Status:"
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(381, 50)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(351, 45)
        Me.txtComments.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(305, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 15)
        Me.Label9.TabIndex = 395
        Me.Label9.Text = "Comments:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(12, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 15)
        Me.Label5.TabIndex = 389
        Me.Label5.Text = "Stock Adjustment Date:"
        '
        'txtStockAdjustmentNo
        '
        Me.txtStockAdjustmentNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockAdjustmentNo.Location = New System.Drawing.Point(159, 24)
        Me.txtStockAdjustmentNo.Name = "txtStockAdjustmentNo"
        Me.txtStockAdjustmentNo.ReadOnly = True
        Me.txtStockAdjustmentNo.Size = New System.Drawing.Size(136, 21)
        Me.txtStockAdjustmentNo.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(12, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 15)
        Me.Label2.TabIndex = 239
        Me.Label2.Text = "Stock Adjustment No.:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label18.Location = New System.Drawing.Point(9, -1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(220, 17)
        Me.Label18.TabIndex = 238
        Me.Label18.Text = "Stock Adjustment Information:"
        '
        'dtpStockAdjustmentDate
        '
        Me.dtpStockAdjustmentDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpStockAdjustmentDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpStockAdjustmentDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStockAdjustmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStockAdjustmentDate.Location = New System.Drawing.Point(159, 49)
        Me.dtpStockAdjustmentDate.Name = "dtpStockAdjustmentDate"
        Me.dtpStockAdjustmentDate.Size = New System.Drawing.Size(136, 21)
        Me.dtpStockAdjustmentDate.TabIndex = 16
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msNew, Me.msSave, Me.msCancel, Me.msOrder})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(837, 25)
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
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1200, 28)
        Me.lblTitle.TabIndex = 243
        Me.lblTitle.Text = "Stock Adjustment"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbClose
        '
        Me.pbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pbClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbClose.Image = CType(resources.GetObject("pbClose.Image"), System.Drawing.Image)
        Me.pbClose.Location = New System.Drawing.Point(1169, 5)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(22, 19)
        Me.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbClose.TabIndex = 244
        Me.pbClose.TabStop = False
        '
        'r_rack
        '
        Me.r_rack.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.r_rack.HeaderText = "Rack"
        Me.r_rack.Name = "r_rack"
        Me.r_rack.ReadOnly = True
        Me.r_rack.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.r_rack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.r_rack.Width = 60
        '
        'r_column
        '
        Me.r_column.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.r_column.HeaderText = "Column"
        Me.r_column.Name = "r_column"
        Me.r_column.ReadOnly = True
        Me.r_column.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.r_column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.r_column.Width = 75
        '
        'r_shelf
        '
        Me.r_shelf.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.r_shelf.HeaderText = "Shelf"
        Me.r_shelf.Name = "r_shelf"
        Me.r_shelf.ReadOnly = True
        Me.r_shelf.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.r_shelf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.r_shelf.Width = 60
        '
        'r_qtystock
        '
        Me.r_qtystock.HeaderText = "Quantity in Stock Before"
        Me.r_qtystock.Name = "r_qtystock"
        Me.r_qtystock.ReadOnly = True
        Me.r_qtystock.Width = 114
        '
        'r_qtyallocated
        '
        Me.r_qtyallocated.HeaderText = "Qty. Allocated"
        Me.r_qtyallocated.Name = "r_qtyallocated"
        Me.r_qtyallocated.ReadOnly = True
        Me.r_qtyallocated.Width = 96
        '
        'r_qtyapply
        '
        Me.r_qtyapply.HeaderText = "Quantity to Stock After"
        Me.r_qtyapply.Name = "r_qtyapply"
        Me.r_qtyapply.Width = 114
        '
        'r_qtystocked
        '
        Me.r_qtystocked.HeaderText = "Qty. Stocked"
        Me.r_qtystocked.Name = "r_qtystocked"
        Me.r_qtystocked.ReadOnly = True
        Me.r_qtystocked.Visible = False
        Me.r_qtystocked.Width = 91
        '
        'r_datestocked
        '
        Me.r_datestocked.HeaderText = "Date Stocked Adjusted"
        Me.r_datestocked.Name = "r_datestocked"
        Me.r_datestocked.ReadOnly = True
        Me.r_datestocked.Width = 141
        '
        'r_prodinvlocinventoryid
        '
        Me.r_prodinvlocinventoryid.HeaderText = "prodinvlocinventoryID"
        Me.r_prodinvlocinventoryid.Name = "r_prodinvlocinventoryid"
        Me.r_prodinvlocinventoryid.Visible = False
        Me.r_prodinvlocinventoryid.Width = 148
        '
        'r_rscid
        '
        Me.r_rscid.HeaderText = "RSCID"
        Me.r_rscid.Name = "r_rscid"
        Me.r_rscid.Visible = False
        Me.r_rscid.Width = 69
        '
        'StockAdjustmentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 560)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "StockAdjustmentForm"
        Me.Text = "StockAdjustment"
        Me.gbStockAdjustmentOrderList.ResumeLayout(False)
        Me.gbStockAdjustmentOrderList.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.dgStockAdjusmentList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.tabSearch.ResumeLayout(False)
        Me.tabSimpleSearch.ResumeLayout(False)
        Me.tabSimpleSearch.PerformLayout()
        Me.tabCommonSearch.ResumeLayout(False)
        Me.tabCommonSearch.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.grpStockAdjrsc.ResumeLayout(False)
        Me.grpStockAdjrsc.PerformLayout()
        CType(Me.pcAddtnlItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgrackshelfcolumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStockAdjustmentitems.ResumeLayout(False)
        Me.grpStockAdjustmentitems.PerformLayout()
        Me.gbAddProductItem.ResumeLayout(False)
        Me.gbAddProductItem.PerformLayout()
        CType(Me.dgStockAdjustmentItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbStockAdjustment.ResumeLayout(False)
        Me.gbStockAdjustment.PerformLayout()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbStockAdjustmentOrderList As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPage As System.Windows.Forms.TextBox
    Friend WithEvents txtPageNo As System.Windows.Forms.TextBox
    Friend WithEvents dgStockAdjusmentList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents tabSearch As System.Windows.Forms.TabControl
    Friend WithEvents tabSimpleSearch As System.Windows.Forms.TabPage
    Friend WithEvents txtSimpleSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabCommonSearch As System.Windows.Forms.TabPage
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpToSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboSearch4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msOrder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents gbStockAdjustment As System.Windows.Forms.GroupBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtStockAdjustmentNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dtpStockAdjustmentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAdjustedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents grpStockAdjustmentitems As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dgrackshelfcolumn As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgStockAdjustmentItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents grpStockAdjrsc As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkOtherInfo As System.Windows.Forms.CheckBox
    Friend WithEvents s_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_StockNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_stockadjdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_stockadjstatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gbAddProductItem As System.Windows.Forms.GroupBox
    Friend WithEvents cboItemCode As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddProduct As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pcAddtnlItems As System.Windows.Forms.PictureBox
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
    Friend WithEvents ci_qtyreceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtystocked As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_srp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_totalprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_approved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ci_option As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ci_itemtype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_app As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkApproveAll As System.Windows.Forms.CheckBox
    Friend WithEvents r_rack As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents r_column As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents r_shelf As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents r_qtystock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_qtyallocated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_qtyapply As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_qtystocked As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_datestocked As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_prodinvlocinventoryid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_rscid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
