<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockTransferForm
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockTransferForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbStockTransferItems = New System.Windows.Forms.GroupBox()
        Me.dgProductHistory = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.h_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_rack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_shelf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_qtybefore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_qtyapplied = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_qtyafter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_uom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkOtherInfo = New System.Windows.Forms.CheckBox()
        Me.txtTotalQtyToTransfer = New System.Windows.Forms.TextBox()
        Me.lblTotalQtyToTransfer = New System.Windows.Forms.Label()
        Me.btnAddRackShelfColumn = New System.Windows.Forms.Button()
        Me.btnAddStockFrom = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTo = New System.Windows.Forms.ComboBox()
        Me.cboFrom = New System.Windows.Forms.ComboBox()
        Me.dgRackShelfColumnTo = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.rsc_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_rack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_shelf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtytransfer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_remove = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgRackShelfColumnFrom = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.r_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_pcsrowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_rack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_shelf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_qtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_qtyallocated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_qtystock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.r_remove = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.lblStockTransferItems = New System.Windows.Forms.Label()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtStockTransferNo = New System.Windows.Forms.TextBox()
        Me.msCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtpStockTransferDate = New System.Windows.Forms.DateTimePicker()
        Me.gbStockTransferInformation = New System.Windows.Forms.GroupBox()
        Me.txtTransferedBy = New System.Windows.Forms.TextBox()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.txtSimpleSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabSimpleSearch = New System.Windows.Forms.TabPage()
        Me.tabSearch = New System.Windows.Forms.TabControl()
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbStockTransferList = New System.Windows.Forms.GroupBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.cmdFirst = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrev = New System.Windows.Forms.ToolStripButton()
        Me.cmdNext = New System.Windows.Forms.ToolStripButton()
        Me.cmdLast = New System.Windows.Forms.ToolStripButton()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPage = New System.Windows.Forms.TextBox()
        Me.txtPageNo = New System.Windows.Forms.TextBox()
        Me.dgStockTransferList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.s_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_StockNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_stocktransdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbStockTransferItems.SuspendLayout()
        CType(Me.dgProductHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgRackShelfColumnTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgRackShelfColumnFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbStockTransferInformation.SuspendLayout()
        Me.msMenu.SuspendLayout()
        Me.tabSimpleSearch.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbStockTransferList.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.dgStockTransferList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMain.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbStockTransferItems
        '
        Me.gbStockTransferItems.Controls.Add(Me.chkOtherInfo)
        Me.gbStockTransferItems.Controls.Add(Me.txtTotalQtyToTransfer)
        Me.gbStockTransferItems.Controls.Add(Me.lblTotalQtyToTransfer)
        Me.gbStockTransferItems.Controls.Add(Me.btnAddRackShelfColumn)
        Me.gbStockTransferItems.Controls.Add(Me.btnAddStockFrom)
        Me.gbStockTransferItems.Controls.Add(Me.Label7)
        Me.gbStockTransferItems.Controls.Add(Me.Label3)
        Me.gbStockTransferItems.Controls.Add(Me.cboTo)
        Me.gbStockTransferItems.Controls.Add(Me.cboFrom)
        Me.gbStockTransferItems.Controls.Add(Me.dgRackShelfColumnTo)
        Me.gbStockTransferItems.Controls.Add(Me.dgRackShelfColumnFrom)
        Me.gbStockTransferItems.Controls.Add(Me.lblStockTransferItems)
        Me.gbStockTransferItems.Controls.Add(Me.dgProductHistory)
        Me.gbStockTransferItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbStockTransferItems.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbStockTransferItems.Location = New System.Drawing.Point(6, 115)
        Me.gbStockTransferItems.Name = "gbStockTransferItems"
        Me.gbStockTransferItems.Size = New System.Drawing.Size(800, 400)
        Me.gbStockTransferItems.TabIndex = 4
        Me.gbStockTransferItems.TabStop = False
        '
        'dgProductHistory
        '
        Me.dgProductHistory.AllowUserToAddRows = False
        Me.dgProductHistory.AllowUserToDeleteRows = False
        Me.dgProductHistory.AllowUserToOrderColumns = True
        Me.dgProductHistory.AllowUserToResizeRows = False
        Me.dgProductHistory.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgProductHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.h_rowid, Me.h_colorvalue, Me.h_productcode, Me.h_colorname, Me.h_color, Me.h_size, Me.h_seasoncode, Me.h_rack, Me.h_column, Me.h_shelf, Me.h_qtybefore, Me.h_qtyapplied, Me.h_qtyafter, Me.h_type, Me.h_uom, Me.h_sku})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProductHistory.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgProductHistory.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgProductHistory.Location = New System.Drawing.Point(30, 60)
        Me.dgProductHistory.MultiSelect = False
        Me.dgProductHistory.Name = "dgProductHistory"
        Me.dgProductHistory.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProductHistory.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgProductHistory.RowHeadersVisible = False
        Me.dgProductHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProductHistory.Size = New System.Drawing.Size(720, 330)
        Me.dgProductHistory.TabIndex = 24
        Me.dgProductHistory.Visible = False
        '
        'h_rowid
        '
        Me.h_rowid.HeaderText = "rowid"
        Me.h_rowid.Name = "h_rowid"
        Me.h_rowid.ReadOnly = True
        Me.h_rowid.Visible = False
        Me.h_rowid.Width = 62
        '
        'h_colorvalue
        '
        Me.h_colorvalue.HeaderText = "colorvalue"
        Me.h_colorvalue.Name = "h_colorvalue"
        Me.h_colorvalue.ReadOnly = True
        Me.h_colorvalue.Visible = False
        '
        'h_productcode
        '
        Me.h_productcode.HeaderText = "Product Code"
        Me.h_productcode.Name = "h_productcode"
        Me.h_productcode.ReadOnly = True
        Me.h_productcode.Width = 110
        '
        'h_colorname
        '
        Me.h_colorname.HeaderText = "Color Name"
        Me.h_colorname.Name = "h_colorname"
        Me.h_colorname.ReadOnly = True
        Me.h_colorname.Width = 90
        '
        'h_color
        '
        Me.h_color.HeaderText = ""
        Me.h_color.Name = "h_color"
        Me.h_color.ReadOnly = True
        Me.h_color.Width = 30
        '
        'h_size
        '
        Me.h_size.HeaderText = "Size"
        Me.h_size.Name = "h_size"
        Me.h_size.ReadOnly = True
        Me.h_size.Width = 50
        '
        'h_seasoncode
        '
        Me.h_seasoncode.HeaderText = "Season Code"
        Me.h_seasoncode.Name = "h_seasoncode"
        Me.h_seasoncode.ReadOnly = True
        Me.h_seasoncode.Width = 70
        '
        'h_rack
        '
        Me.h_rack.HeaderText = "Rack"
        Me.h_rack.Name = "h_rack"
        Me.h_rack.ReadOnly = True
        Me.h_rack.Width = 50
        '
        'h_column
        '
        Me.h_column.HeaderText = "Column"
        Me.h_column.Name = "h_column"
        Me.h_column.ReadOnly = True
        Me.h_column.Width = 60
        '
        'h_shelf
        '
        Me.h_shelf.HeaderText = "Shelf"
        Me.h_shelf.Name = "h_shelf"
        Me.h_shelf.ReadOnly = True
        Me.h_shelf.Width = 50
        '
        'h_qtybefore
        '
        Me.h_qtybefore.HeaderText = "Qty. Before Trans."
        Me.h_qtybefore.Name = "h_qtybefore"
        Me.h_qtybefore.ReadOnly = True
        Me.h_qtybefore.Width = 90
        '
        'h_qtyapplied
        '
        Me.h_qtyapplied.HeaderText = "Qty. Applied"
        Me.h_qtyapplied.Name = "h_qtyapplied"
        Me.h_qtyapplied.ReadOnly = True
        Me.h_qtyapplied.Width = 70
        '
        'h_qtyafter
        '
        Me.h_qtyafter.HeaderText = "Qty. After Trans."
        Me.h_qtyafter.Name = "h_qtyafter"
        Me.h_qtyafter.ReadOnly = True
        Me.h_qtyafter.Width = 80
        '
        'h_type
        '
        Me.h_type.HeaderText = "Type"
        Me.h_type.Name = "h_type"
        Me.h_type.ReadOnly = True
        Me.h_type.Width = 70
        '
        'h_uom
        '
        Me.h_uom.HeaderText = "Unit Of Measure"
        Me.h_uom.Name = "h_uom"
        Me.h_uom.ReadOnly = True
        Me.h_uom.Width = 70
        '
        'h_sku
        '
        Me.h_sku.HeaderText = "SKU"
        Me.h_sku.Name = "h_sku"
        Me.h_sku.ReadOnly = True
        Me.h_sku.Width = 80
        '
        'chkOtherInfo
        '
        Me.chkOtherInfo.AutoSize = True
        Me.chkOtherInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOtherInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOtherInfo.Location = New System.Drawing.Point(30, 158)
        Me.chkOtherInfo.Name = "chkOtherInfo"
        Me.chkOtherInfo.Size = New System.Drawing.Size(114, 19)
        Me.chkOtherInfo.TabIndex = 21
        Me.chkOtherInfo.Text = "View Other Info.:"
        Me.chkOtherInfo.UseVisualStyleBackColor = True
        '
        'txtTotalQtyToTransfer
        '
        Me.txtTotalQtyToTransfer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalQtyToTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyToTransfer.Location = New System.Drawing.Point(580, 240)
        Me.txtTotalQtyToTransfer.Name = "txtTotalQtyToTransfer"
        Me.txtTotalQtyToTransfer.ReadOnly = True
        Me.txtTotalQtyToTransfer.Size = New System.Drawing.Size(95, 21)
        Me.txtTotalQtyToTransfer.TabIndex = 23
        Me.txtTotalQtyToTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotalQtyToTransfer
        '
        Me.lblTotalQtyToTransfer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalQtyToTransfer.AutoSize = True
        Me.lblTotalQtyToTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalQtyToTransfer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotalQtyToTransfer.Location = New System.Drawing.Point(560, 220)
        Me.lblTotalQtyToTransfer.Name = "lblTotalQtyToTransfer"
        Me.lblTotalQtyToTransfer.Size = New System.Drawing.Size(144, 15)
        Me.lblTotalQtyToTransfer.TabIndex = 474
        Me.lblTotalQtyToTransfer.Text = "Total Qty. To Transfer"
        '
        'btnAddRackShelfColumn
        '
        Me.btnAddRackShelfColumn.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAddRackShelfColumn.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnAddRackShelfColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddRackShelfColumn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddRackShelfColumn.Image = CType(resources.GetObject("btnAddRackShelfColumn.Image"), System.Drawing.Image)
        Me.btnAddRackShelfColumn.Location = New System.Drawing.Point(705, 28)
        Me.btnAddRackShelfColumn.Name = "btnAddRackShelfColumn"
        Me.btnAddRackShelfColumn.Size = New System.Drawing.Size(43, 25)
        Me.btnAddRackShelfColumn.TabIndex = 19
        Me.btnAddRackShelfColumn.UseVisualStyleBackColor = False
        '
        'btnAddStockFrom
        '
        Me.btnAddStockFrom.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAddStockFrom.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnAddStockFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddStockFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddStockFrom.Image = CType(resources.GetObject("btnAddStockFrom.Image"), System.Drawing.Image)
        Me.btnAddStockFrom.Location = New System.Drawing.Point(470, 28)
        Me.btnAddStockFrom.Name = "btnAddStockFrom"
        Me.btnAddStockFrom.Size = New System.Drawing.Size(43, 25)
        Me.btnAddStockFrom.TabIndex = 17
        Me.btnAddStockFrom.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(540, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 15)
        Me.Label7.TabIndex = 472
        Me.Label7.Text = "Stock To:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 471
        Me.Label3.Text = "Stock From:"
        '
        'cboTo
        '
        Me.cboTo.FormattingEnabled = True
        Me.cboTo.Location = New System.Drawing.Point(600, 30)
        Me.cboTo.Name = "cboTo"
        Me.cboTo.Size = New System.Drawing.Size(100, 21)
        Me.cboTo.TabIndex = 18
        '
        'cboFrom
        '
        Me.cboFrom.FormattingEnabled = True
        Me.cboFrom.Location = New System.Drawing.Point(105, 30)
        Me.cboFrom.Name = "cboFrom"
        Me.cboFrom.Size = New System.Drawing.Size(360, 21)
        Me.cboFrom.TabIndex = 16
        '
        'dgRackShelfColumnTo
        '
        Me.dgRackShelfColumnTo.AllowUserToAddRows = False
        Me.dgRackShelfColumnTo.AllowUserToDeleteRows = False
        Me.dgRackShelfColumnTo.AllowUserToOrderColumns = True
        Me.dgRackShelfColumnTo.AllowUserToResizeRows = False
        Me.dgRackShelfColumnTo.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRackShelfColumnTo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgRackShelfColumnTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRackShelfColumnTo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rsc_rowid, Me.rsc_rack, Me.rsc_column, Me.rsc_shelf, Me.rsc_qtytransfer, Me.rsc_remove})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgRackShelfColumnTo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgRackShelfColumnTo.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgRackShelfColumnTo.Location = New System.Drawing.Point(180, 160)
        Me.dgRackShelfColumnTo.MultiSelect = False
        Me.dgRackShelfColumnTo.Name = "dgRackShelfColumnTo"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRackShelfColumnTo.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgRackShelfColumnTo.RowHeadersVisible = False
        Me.dgRackShelfColumnTo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRackShelfColumnTo.Size = New System.Drawing.Size(360, 230)
        Me.dgRackShelfColumnTo.TabIndex = 22
        '
        'rsc_rowid
        '
        Me.rsc_rowid.HeaderText = "rowid"
        Me.rsc_rowid.Name = "rsc_rowid"
        Me.rsc_rowid.Visible = False
        '
        'rsc_rack
        '
        Me.rsc_rack.HeaderText = "Rack"
        Me.rsc_rack.Name = "rsc_rack"
        Me.rsc_rack.ReadOnly = True
        Me.rsc_rack.Width = 70
        '
        'rsc_column
        '
        Me.rsc_column.HeaderText = "Column"
        Me.rsc_column.Name = "rsc_column"
        Me.rsc_column.ReadOnly = True
        Me.rsc_column.Width = 70
        '
        'rsc_shelf
        '
        Me.rsc_shelf.HeaderText = "Shelf"
        Me.rsc_shelf.Name = "rsc_shelf"
        Me.rsc_shelf.ReadOnly = True
        Me.rsc_shelf.Width = 70
        '
        'rsc_qtytransfer
        '
        Me.rsc_qtytransfer.HeaderText = "Qty. To Transfer"
        Me.rsc_qtytransfer.Name = "rsc_qtytransfer"
        Me.rsc_qtytransfer.Width = 70
        '
        'rsc_remove
        '
        Me.rsc_remove.HeaderText = ""
        Me.rsc_remove.Name = "rsc_remove"
        Me.rsc_remove.Text = "Delete"
        Me.rsc_remove.UseColumnTextForButtonValue = True
        Me.rsc_remove.Width = 60
        '
        'dgRackShelfColumnFrom
        '
        Me.dgRackShelfColumnFrom.AllowUserToAddRows = False
        Me.dgRackShelfColumnFrom.AllowUserToDeleteRows = False
        Me.dgRackShelfColumnFrom.AllowUserToOrderColumns = True
        Me.dgRackShelfColumnFrom.AllowUserToResizeRows = False
        Me.dgRackShelfColumnFrom.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRackShelfColumnFrom.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgRackShelfColumnFrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRackShelfColumnFrom.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.r_rowid, Me.r_pcsrowid, Me.r_colorvalue, Me.r_productcode, Me.r_colorname, Me.r_color, Me.r_size, Me.r_seasoncode, Me.r_unitofmeasure, Me.r_sku, Me.r_rack, Me.r_column, Me.r_shelf, Me.r_qtyavailable, Me.r_qtyallocated, Me.r_qtystock, Me.r_remove})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgRackShelfColumnFrom.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgRackShelfColumnFrom.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgRackShelfColumnFrom.Location = New System.Drawing.Point(30, 60)
        Me.dgRackShelfColumnFrom.MultiSelect = False
        Me.dgRackShelfColumnFrom.Name = "dgRackShelfColumnFrom"
        Me.dgRackShelfColumnFrom.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRackShelfColumnFrom.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgRackShelfColumnFrom.RowHeadersVisible = False
        Me.dgRackShelfColumnFrom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRackShelfColumnFrom.Size = New System.Drawing.Size(720, 92)
        Me.dgRackShelfColumnFrom.TabIndex = 20
        '
        'r_rowid
        '
        Me.r_rowid.HeaderText = "rowid"
        Me.r_rowid.Name = "r_rowid"
        Me.r_rowid.ReadOnly = True
        Me.r_rowid.Visible = False
        '
        'r_pcsrowid
        '
        Me.r_pcsrowid.HeaderText = "pcsid"
        Me.r_pcsrowid.Name = "r_pcsrowid"
        Me.r_pcsrowid.ReadOnly = True
        Me.r_pcsrowid.Visible = False
        Me.r_pcsrowid.Width = 68
        '
        'r_colorvalue
        '
        Me.r_colorvalue.HeaderText = "colorvalue"
        Me.r_colorvalue.Name = "r_colorvalue"
        Me.r_colorvalue.ReadOnly = True
        Me.r_colorvalue.Visible = False
        '
        'r_productcode
        '
        Me.r_productcode.HeaderText = "Product Code"
        Me.r_productcode.Name = "r_productcode"
        Me.r_productcode.ReadOnly = True
        Me.r_productcode.Width = 110
        '
        'r_colorname
        '
        Me.r_colorname.HeaderText = "Color Name"
        Me.r_colorname.Name = "r_colorname"
        Me.r_colorname.ReadOnly = True
        Me.r_colorname.Width = 90
        '
        'r_color
        '
        Me.r_color.HeaderText = ""
        Me.r_color.Name = "r_color"
        Me.r_color.ReadOnly = True
        Me.r_color.Width = 30
        '
        'r_size
        '
        Me.r_size.HeaderText = "Size"
        Me.r_size.Name = "r_size"
        Me.r_size.ReadOnly = True
        Me.r_size.Width = 50
        '
        'r_seasoncode
        '
        Me.r_seasoncode.HeaderText = "Season Code"
        Me.r_seasoncode.Name = "r_seasoncode"
        Me.r_seasoncode.ReadOnly = True
        Me.r_seasoncode.Width = 70
        '
        'r_unitofmeasure
        '
        Me.r_unitofmeasure.HeaderText = "Unit of Measure"
        Me.r_unitofmeasure.Name = "r_unitofmeasure"
        Me.r_unitofmeasure.ReadOnly = True
        Me.r_unitofmeasure.Width = 60
        '
        'r_sku
        '
        Me.r_sku.HeaderText = "SKU"
        Me.r_sku.Name = "r_sku"
        Me.r_sku.ReadOnly = True
        Me.r_sku.Width = 70
        '
        'r_rack
        '
        Me.r_rack.HeaderText = "Rack"
        Me.r_rack.Name = "r_rack"
        Me.r_rack.ReadOnly = True
        Me.r_rack.Width = 50
        '
        'r_column
        '
        Me.r_column.HeaderText = "Column"
        Me.r_column.Name = "r_column"
        Me.r_column.ReadOnly = True
        Me.r_column.Width = 60
        '
        'r_shelf
        '
        Me.r_shelf.HeaderText = "Shelf"
        Me.r_shelf.Name = "r_shelf"
        Me.r_shelf.ReadOnly = True
        Me.r_shelf.Width = 50
        '
        'r_qtyavailable
        '
        Me.r_qtyavailable.HeaderText = "Qty. Available"
        Me.r_qtyavailable.Name = "r_qtyavailable"
        Me.r_qtyavailable.ReadOnly = True
        Me.r_qtyavailable.Width = 70
        '
        'r_qtyallocated
        '
        Me.r_qtyallocated.HeaderText = "Qty. Allocated"
        Me.r_qtyallocated.Name = "r_qtyallocated"
        Me.r_qtyallocated.ReadOnly = True
        Me.r_qtyallocated.Width = 70
        '
        'r_qtystock
        '
        Me.r_qtystock.HeaderText = "Qty. Orderable"
        Me.r_qtystock.Name = "r_qtystock"
        Me.r_qtystock.ReadOnly = True
        Me.r_qtystock.Width = 70
        '
        'r_remove
        '
        Me.r_remove.HeaderText = ""
        Me.r_remove.Name = "r_remove"
        Me.r_remove.ReadOnly = True
        Me.r_remove.Text = "Delete"
        Me.r_remove.UseColumnTextForButtonValue = True
        Me.r_remove.Width = 60
        '
        'lblStockTransferItems
        '
        Me.lblStockTransferItems.AutoSize = True
        Me.lblStockTransferItems.BackColor = System.Drawing.Color.White
        Me.lblStockTransferItems.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockTransferItems.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lblStockTransferItems.Location = New System.Drawing.Point(9, -1)
        Me.lblStockTransferItems.Name = "lblStockTransferItems"
        Me.lblStockTransferItems.Size = New System.Drawing.Size(154, 17)
        Me.lblStockTransferItems.TabIndex = 238
        Me.lblStockTransferItems.Text = "Stock Transfer Items:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pbClose
        '
        Me.pbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pbClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbClose.Image = CType(resources.GetObject("pbClose.Image"), System.Drawing.Image)
        Me.pbClose.Location = New System.Drawing.Point(1166, 5)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(22, 19)
        Me.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbClose.TabIndex = 247
        Me.pbClose.TabStop = False
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(81, 5)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 193
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(500, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 15)
        Me.Label6.TabIndex = 441
        Me.Label6.Text = "Transfered By:"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(380, 24)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(110, 21)
        Me.txtStatus.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(305, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 440
        Me.Label12.Text = "Status:"
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(380, 50)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(350, 45)
        Me.txtComments.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(305, 55)
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
        Me.Label5.Location = New System.Drawing.Point(15, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 15)
        Me.Label5.TabIndex = 389
        Me.Label5.Text = "Stock Transfer Date:"
        '
        'txtStockTransferNo
        '
        Me.txtStockTransferNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockTransferNo.Location = New System.Drawing.Point(140, 24)
        Me.txtStockTransferNo.Name = "txtStockTransferNo"
        Me.txtStockTransferNo.ReadOnly = True
        Me.txtStockTransferNo.Size = New System.Drawing.Size(140, 21)
        Me.txtStockTransferNo.TabIndex = 11
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(15, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 15)
        Me.Label2.TabIndex = 239
        Me.Label2.Text = "Stock Transfer No.:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label18.Location = New System.Drawing.Point(9, -1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(200, 17)
        Me.Label18.TabIndex = 238
        Me.Label18.Text = "Stock Transfer Information:"
        '
        'dtpStockTransferDate
        '
        Me.dtpStockTransferDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpStockTransferDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpStockTransferDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStockTransferDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStockTransferDate.Location = New System.Drawing.Point(140, 50)
        Me.dtpStockTransferDate.Name = "dtpStockTransferDate"
        Me.dtpStockTransferDate.Size = New System.Drawing.Size(140, 21)
        Me.dtpStockTransferDate.TabIndex = 12
        '
        'gbStockTransferInformation
        '
        Me.gbStockTransferInformation.Controls.Add(Me.txtTransferedBy)
        Me.gbStockTransferInformation.Controls.Add(Me.Label6)
        Me.gbStockTransferInformation.Controls.Add(Me.txtStatus)
        Me.gbStockTransferInformation.Controls.Add(Me.Label12)
        Me.gbStockTransferInformation.Controls.Add(Me.txtComments)
        Me.gbStockTransferInformation.Controls.Add(Me.Label9)
        Me.gbStockTransferInformation.Controls.Add(Me.Label5)
        Me.gbStockTransferInformation.Controls.Add(Me.txtStockTransferNo)
        Me.gbStockTransferInformation.Controls.Add(Me.Label2)
        Me.gbStockTransferInformation.Controls.Add(Me.Label18)
        Me.gbStockTransferInformation.Controls.Add(Me.dtpStockTransferDate)
        Me.gbStockTransferInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbStockTransferInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbStockTransferInformation.Location = New System.Drawing.Point(6, 6)
        Me.gbStockTransferInformation.Name = "gbStockTransferInformation"
        Me.gbStockTransferInformation.Size = New System.Drawing.Size(800, 105)
        Me.gbStockTransferInformation.TabIndex = 3
        Me.gbStockTransferInformation.TabStop = False
        '
        'txtTransferedBy
        '
        Me.txtTransferedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransferedBy.Location = New System.Drawing.Point(590, 24)
        Me.txtTransferedBy.Name = "txtTransferedBy"
        Me.txtTransferedBy.Size = New System.Drawing.Size(140, 21)
        Me.txtTransferedBy.TabIndex = 14
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msNew, Me.msSave, Me.msCancel})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(837, 25)
        Me.msMenu.TabIndex = 19
        '
        'txtSimpleSearch
        '
        Me.txtSimpleSearch.Location = New System.Drawing.Point(100, 10)
        Me.txtSimpleSearch.Name = "txtSimpleSearch"
        Me.txtSimpleSearch.Size = New System.Drawing.Size(200, 21)
        Me.txtSimpleSearch.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(5, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Search Phrase:"
        '
        'tabSimpleSearch
        '
        Me.tabSimpleSearch.Controls.Add(Me.txtSimpleSearch)
        Me.tabSimpleSearch.Controls.Add(Me.Label1)
        Me.tabSimpleSearch.Location = New System.Drawing.Point(4, 29)
        Me.tabSimpleSearch.Name = "tabSimpleSearch"
        Me.tabSimpleSearch.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSimpleSearch.Size = New System.Drawing.Size(317, 42)
        Me.tabSimpleSearch.TabIndex = 1
        Me.tabSimpleSearch.Text = "       Simple       "
        Me.tabSimpleSearch.UseVisualStyleBackColor = True
        '
        'tabSearch
        '
        Me.tabSearch.Controls.Add(Me.tabSimpleSearch)
        Me.tabSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSearch.ItemSize = New System.Drawing.Size(62, 25)
        Me.tabSearch.Location = New System.Drawing.Point(5, 15)
        Me.tabSearch.Multiline = True
        Me.tabSearch.Name = "tabSearch"
        Me.tabSearch.SelectedIndex = 0
        Me.tabSearch.Size = New System.Drawing.Size(325, 75)
        Me.tabSearch.TabIndex = 5
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
        Me.gbSearch.Size = New System.Drawing.Size(340, 100)
        Me.gbSearch.TabIndex = 1
        Me.gbSearch.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Plum
        Me.Label21.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label21.Location = New System.Drawing.Point(6, -2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 17)
        Me.Label21.TabIndex = 217
        Me.Label21.Text = "Search:"
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Plum
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbStockTransferList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbSearch)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabMain)
        Me.SplitContainer1.Panel2.Controls.Add(Me.msMenu)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblsavemsg)
        Me.SplitContainer1.Size = New System.Drawing.Size(1200, 492)
        Me.SplitContainer1.SplitterDistance = 355
        Me.SplitContainer1.TabIndex = 248
        '
        'gbStockTransferList
        '
        Me.gbStockTransferList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbStockTransferList.BackColor = System.Drawing.Color.Transparent
        Me.gbStockTransferList.Controls.Add(Me.ToolStrip3)
        Me.gbStockTransferList.Controls.Add(Me.Label4)
        Me.gbStockTransferList.Controls.Add(Me.txtPage)
        Me.gbStockTransferList.Controls.Add(Me.txtPageNo)
        Me.gbStockTransferList.Controls.Add(Me.dgStockTransferList)
        Me.gbStockTransferList.Controls.Add(Me.Label16)
        Me.gbStockTransferList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbStockTransferList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbStockTransferList.Location = New System.Drawing.Point(6, 110)
        Me.gbStockTransferList.Name = "gbStockTransferList"
        Me.gbStockTransferList.Size = New System.Drawing.Size(340, 370)
        Me.gbStockTransferList.TabIndex = 2
        Me.gbStockTransferList.TabStop = False
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
        Me.ToolStrip3.TabIndex = 7
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
        Me.txtPage.TabIndex = 9
        '
        'txtPageNo
        '
        Me.txtPageNo.Location = New System.Drawing.Point(121, 43)
        Me.txtPageNo.Name = "txtPageNo"
        Me.txtPageNo.ReadOnly = True
        Me.txtPageNo.Size = New System.Drawing.Size(101, 21)
        Me.txtPageNo.TabIndex = 8
        '
        'dgStockTransferList
        '
        Me.dgStockTransferList.AllowUserToAddRows = False
        Me.dgStockTransferList.AllowUserToDeleteRows = False
        Me.dgStockTransferList.AllowUserToOrderColumns = True
        Me.dgStockTransferList.AllowUserToResizeRows = False
        Me.dgStockTransferList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgStockTransferList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgStockTransferList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgStockTransferList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgStockTransferList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.s_rowid, Me.s_StockNo, Me.s_stocktransdate, Me.s_status})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgStockTransferList.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgStockTransferList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgStockTransferList.Location = New System.Drawing.Point(8, 68)
        Me.dgStockTransferList.MultiSelect = False
        Me.dgStockTransferList.Name = "dgStockTransferList"
        Me.dgStockTransferList.ReadOnly = True
        Me.dgStockTransferList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgStockTransferList.Size = New System.Drawing.Size(324, 296)
        Me.dgStockTransferList.TabIndex = 10
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
        Me.s_StockNo.HeaderText = "Stock Transfer No"
        Me.s_StockNo.Name = "s_StockNo"
        Me.s_StockNo.ReadOnly = True
        '
        's_stocktransdate
        '
        Me.s_stocktransdate.HeaderText = "Stock Transfer Date"
        Me.s_stocktransdate.Name = "s_stocktransdate"
        Me.s_stocktransdate.ReadOnly = True
        Me.s_stocktransdate.Width = 110
        '
        's_status
        '
        Me.s_status.HeaderText = "Status"
        Me.s_status.Name = "s_status"
        Me.s_status.ReadOnly = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Plum
        Me.Label16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(6, -1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(141, 17)
        Me.Label16.TabIndex = 216
        Me.Label16.Text = "Stock Transfer List:"
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
        Me.tabMain.Size = New System.Drawing.Size(837, 463)
        Me.tabMain.TabIndex = 223
        '
        'tabDetails
        '
        Me.tabDetails.AutoScroll = True
        Me.tabDetails.Controls.Add(Me.gbStockTransferItems)
        Me.tabDetails.Controls.Add(Me.gbStockTransferInformation)
        Me.tabDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(829, 432)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Stock Transfer Details"
        Me.tabDetails.UseVisualStyleBackColor = True
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
        Me.lblTitle.TabIndex = 249
        Me.lblTitle.Text = "Stock Transfer"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StockTransferForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 520)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "StockTransferForm"
        Me.Text = "StockTransferForm"
        Me.gbStockTransferItems.ResumeLayout(False)
        Me.gbStockTransferItems.PerformLayout()
        CType(Me.dgProductHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgRackShelfColumnTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgRackShelfColumnFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbStockTransferInformation.ResumeLayout(False)
        Me.gbStockTransferInformation.PerformLayout()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        Me.tabSimpleSearch.ResumeLayout(False)
        Me.tabSimpleSearch.PerformLayout()
        Me.tabSearch.ResumeLayout(False)
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbStockTransferList.ResumeLayout(False)
        Me.gbStockTransferList.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.dgStockTransferList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMain.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbStockTransferItems As System.Windows.Forms.GroupBox
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbStockTransferList As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPage As System.Windows.Forms.TextBox
    Friend WithEvents txtPageNo As System.Windows.Forms.TextBox
    Friend WithEvents dgStockTransferList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents tabSearch As System.Windows.Forms.TabControl
    Friend WithEvents tabSimpleSearch As System.Windows.Forms.TabPage
    Friend WithEvents txtSimpleSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents dgRackShelfColumnFrom As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbStockTransferInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtStockTransferNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dtpStockTransferDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dgRackShelfColumnTo As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cboTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTransferedBy As System.Windows.Forms.TextBox
    Friend WithEvents dgProductHistory As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents lblStockTransferItems As System.Windows.Forms.Label
    Friend WithEvents s_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_StockNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_stocktransdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAddStockFrom As System.Windows.Forms.Button
    Friend WithEvents btnAddRackShelfColumn As System.Windows.Forms.Button
    Friend WithEvents txtTotalQtyToTransfer As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalQtyToTransfer As System.Windows.Forms.Label
    Friend WithEvents chkOtherInfo As System.Windows.Forms.CheckBox
    Friend WithEvents r_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_pcsrowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_rack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_shelf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_qtyavailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_qtyallocated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_qtystock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_remove As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents rsc_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_rack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_shelf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtytransfer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsc_remove As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents h_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_rack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_shelf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_qtybefore As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_qtyapplied As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_qtyafter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_uom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_sku As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
