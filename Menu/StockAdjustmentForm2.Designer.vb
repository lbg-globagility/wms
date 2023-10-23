<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StockAdjustmentForm2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockAdjustmentForm2))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gridStockAdjustmentOrders = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LinkLabelRefresh = New System.Windows.Forms.LinkLabel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStockAdjustmentNo = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtTransferedBy = New System.Windows.Forms.TextBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.dtpStockAdjustmentDate = New System.Windows.Forms.DateTimePicker()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.gridStockAdjustmentOrdersFrom = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pickFromRackShelfColumn = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rackShelfColumnFrom = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.deleteProductColorSize = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAddItem = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboFromInventory = New System.Windows.Forms.ComboBox()
        Me.gridStockAdjustmentOrdersTo = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pickToRackShelfColumn = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rackShelfColumnTo = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnAddItem2 = New System.Windows.Forms.Button()
        Me.cboToInventory = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonApproved = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.gridStockAdjustmentOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.gridStockAdjustmentOrdersFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.gridStockAdjustmentOrdersTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridStockAdjustmentOrders
        '
        Me.gridStockAdjustmentOrders.AllowUserToAddRows = False
        Me.gridStockAdjustmentOrders.AllowUserToDeleteRows = False
        Me.gridStockAdjustmentOrders.AllowUserToResizeRows = False
        Me.gridStockAdjustmentOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridStockAdjustmentOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column6, Me.Column7, Me.Column4, Me.Column8})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridStockAdjustmentOrders.DefaultCellStyle = DataGridViewCellStyle1
        Me.gridStockAdjustmentOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridStockAdjustmentOrders.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridStockAdjustmentOrders.Location = New System.Drawing.Point(0, 109)
        Me.gridStockAdjustmentOrders.Name = "gridStockAdjustmentOrders"
        Me.gridStockAdjustmentOrders.ReadOnly = True
        Me.gridStockAdjustmentOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridStockAdjustmentOrders.Size = New System.Drawing.Size(206, 450)
        Me.gridStockAdjustmentOrders.TabIndex = 12
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "OrderNumber"
        Me.Column5.HeaderText = "Stock Adjustment No."
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "Status"
        Me.Column6.HeaderText = "Status"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "OrderDate"
        Me.Column7.HeaderText = "Stock Adjustment Date"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "UserCreateFullName"
        Me.Column4.HeaderText = "Created By"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "UserUpdateFullName"
        Me.Column8.HeaderText = "Last Updated By"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gridStockAdjustmentOrders)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1065, 561)
        Me.SplitContainer1.SplitterDistance = 208
        Me.SplitContainer1.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LinkLabelRefresh)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(206, 109)
        Me.Panel1.TabIndex = 13
        '
        'LinkLabelRefresh
        '
        Me.LinkLabelRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelRefresh.Image = CType(resources.GetObject("LinkLabelRefresh.Image"), System.Drawing.Image)
        Me.LinkLabelRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LinkLabelRefresh.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline
        Me.LinkLabelRefresh.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabelRefresh.Location = New System.Drawing.Point(129, 90)
        Me.LinkLabelRefresh.Name = "LinkLabelRefresh"
        Me.LinkLabelRefresh.Size = New System.Drawing.Size(64, 16)
        Me.LinkLabelRefresh.TabIndex = 7
        Me.LinkLabelRefresh.TabStop = True
        Me.LinkLabelRefresh.Text = "Refresh"
        Me.LinkLabelRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(11, 44)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(182, 22)
        Me.txtSearch.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtStockAdjustmentNo)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtStatus)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtTransferedBy)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtComments)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtpStockAdjustmentDate)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(853, 536)
        Me.SplitContainer2.SplitterDistance = 154
        Me.SplitContainer2.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Stock Adjustment Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(257, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Comments"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Adjusted By"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Stock Adjustment No."
        '
        'txtStockAdjustmentNo
        '
        Me.txtStockAdjustmentNo.BackColor = System.Drawing.Color.White
        Me.txtStockAdjustmentNo.Location = New System.Drawing.Point(151, 19)
        Me.txtStockAdjustmentNo.Name = "txtStockAdjustmentNo"
        Me.txtStockAdjustmentNo.ReadOnly = True
        Me.txtStockAdjustmentNo.Size = New System.Drawing.Size(100, 22)
        Me.txtStockAdjustmentNo.TabIndex = 0
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.White
        Me.txtStatus.Location = New System.Drawing.Point(151, 47)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(100, 22)
        Me.txtStatus.TabIndex = 1
        '
        'txtTransferedBy
        '
        Me.txtTransferedBy.BackColor = System.Drawing.Color.White
        Me.txtTransferedBy.Location = New System.Drawing.Point(151, 75)
        Me.txtTransferedBy.Name = "txtTransferedBy"
        Me.txtTransferedBy.ReadOnly = True
        Me.txtTransferedBy.Size = New System.Drawing.Size(100, 22)
        Me.txtTransferedBy.TabIndex = 2
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(324, 19)
        Me.txtComments.MaxLength = 255
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(301, 106)
        Me.txtComments.TabIndex = 4
        '
        'dtpStockAdjustmentDate
        '
        Me.dtpStockAdjustmentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStockAdjustmentDate.Location = New System.Drawing.Point(151, 103)
        Me.dtpStockAdjustmentDate.Name = "dtpStockAdjustmentDate"
        Me.dtpStockAdjustmentDate.Size = New System.Drawing.Size(100, 22)
        Me.dtpStockAdjustmentDate.TabIndex = 3
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.gridStockAdjustmentOrdersFrom)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Panel2)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.gridStockAdjustmentOrdersTo)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Panel3)
        Me.SplitContainer3.Size = New System.Drawing.Size(851, 376)
        Me.SplitContainer3.SplitterDistance = 426
        Me.SplitContainer3.TabIndex = 0
        '
        'gridStockAdjustmentOrdersFrom
        '
        Me.gridStockAdjustmentOrdersFrom.AllowUserToAddRows = False
        Me.gridStockAdjustmentOrdersFrom.AllowUserToDeleteRows = False
        Me.gridStockAdjustmentOrdersFrom.AllowUserToResizeRows = False
        Me.gridStockAdjustmentOrdersFrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridStockAdjustmentOrdersFrom.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.pickFromRackShelfColumn, Me.Column3, Me.rackShelfColumnFrom, Me.deleteProductColorSize})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridStockAdjustmentOrdersFrom.DefaultCellStyle = DataGridViewCellStyle2
        Me.gridStockAdjustmentOrdersFrom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridStockAdjustmentOrdersFrom.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridStockAdjustmentOrdersFrom.Location = New System.Drawing.Point(0, 100)
        Me.gridStockAdjustmentOrdersFrom.Name = "gridStockAdjustmentOrdersFrom"
        Me.gridStockAdjustmentOrdersFrom.Size = New System.Drawing.Size(426, 276)
        Me.gridStockAdjustmentOrdersFrom.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "ProductCode"
        Me.Column1.HeaderText = "Product Code-Color-Size"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "QtyToApply"
        Me.Column2.HeaderText = "Outgoing Quantity"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'pickFromRackShelfColumn
        '
        Me.pickFromRackShelfColumn.HeaderText = ""
        Me.pickFromRackShelfColumn.Image = CType(resources.GetObject("pickFromRackShelfColumn.Image"), System.Drawing.Image)
        Me.pickFromRackShelfColumn.Name = "pickFromRackShelfColumn"
        Me.pickFromRackShelfColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pickFromRackShelfColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.pickFromRackShelfColumn.Text = Nothing
        Me.pickFromRackShelfColumn.Width = 24
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "UnitOfMeasure"
        Me.Column3.HeaderText = "Unit of Measure"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'rackShelfColumnFrom
        '
        Me.rackShelfColumnFrom.HeaderText = "Rack-Shelf-Column"
        Me.rackShelfColumnFrom.Name = "rackShelfColumnFrom"
        Me.rackShelfColumnFrom.ReadOnly = True
        Me.rackShelfColumnFrom.Visible = False
        '
        'deleteProductColorSize
        '
        Me.deleteProductColorSize.HeaderText = ""
        Me.deleteProductColorSize.Image = CType(resources.GetObject("deleteProductColorSize.Image"), System.Drawing.Image)
        Me.deleteProductColorSize.Name = "deleteProductColorSize"
        Me.deleteProductColorSize.ReadOnly = True
        Me.deleteProductColorSize.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.deleteProductColorSize.Text = Nothing
        Me.deleteProductColorSize.ToolTipText = "Delete?"
        Me.deleteProductColorSize.Width = 24
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnAddItem)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.cboFromInventory)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(426, 100)
        Me.Panel2.TabIndex = 0
        '
        'btnAddItem
        '
        Me.btnAddItem.Image = CType(resources.GetObject("btnAddItem.Image"), System.Drawing.Image)
        Me.btnAddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddItem.Location = New System.Drawing.Point(7, 71)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(56, 23)
        Me.btnAddItem.TabIndex = 1
        Me.btnAddItem.Text = "Add"
        Me.btnAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAddItem, "Add Product Code-Color-Size")
        Me.btnAddItem.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "From Inventory"
        '
        'cboFromInventory
        '
        Me.cboFromInventory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFromInventory.FormattingEnabled = True
        Me.cboFromInventory.Location = New System.Drawing.Point(104, 21)
        Me.cboFromInventory.Name = "cboFromInventory"
        Me.cboFromInventory.Size = New System.Drawing.Size(192, 21)
        Me.cboFromInventory.TabIndex = 0
        '
        'gridStockAdjustmentOrdersTo
        '
        Me.gridStockAdjustmentOrdersTo.AllowUserToAddRows = False
        Me.gridStockAdjustmentOrdersTo.AllowUserToDeleteRows = False
        Me.gridStockAdjustmentOrdersTo.AllowUserToResizeRows = False
        Me.gridStockAdjustmentOrdersTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridStockAdjustmentOrdersTo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.pickToRackShelfColumn, Me.DataGridViewTextBoxColumn3, Me.rackShelfColumnTo})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridStockAdjustmentOrdersTo.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridStockAdjustmentOrdersTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridStockAdjustmentOrdersTo.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridStockAdjustmentOrdersTo.Location = New System.Drawing.Point(0, 100)
        Me.gridStockAdjustmentOrdersTo.Name = "gridStockAdjustmentOrdersTo"
        Me.gridStockAdjustmentOrdersTo.Size = New System.Drawing.Size(421, 276)
        Me.gridStockAdjustmentOrdersTo.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ProductCode"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Product Code-Color-Size"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "QtyToApply"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Adjustment Quantity"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'pickToRackShelfColumn
        '
        Me.pickToRackShelfColumn.HeaderText = ""
        Me.pickToRackShelfColumn.Image = CType(resources.GetObject("pickToRackShelfColumn.Image"), System.Drawing.Image)
        Me.pickToRackShelfColumn.Name = "pickToRackShelfColumn"
        Me.pickToRackShelfColumn.Text = Nothing
        Me.pickToRackShelfColumn.Width = 24
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "UnitOfMeasure"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Unit of Measure"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'rackShelfColumnTo
        '
        Me.rackShelfColumnTo.HeaderText = "Rack-Shelf-Column"
        Me.rackShelfColumnTo.Name = "rackShelfColumnTo"
        Me.rackShelfColumnTo.ReadOnly = True
        Me.rackShelfColumnTo.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnAddItem2)
        Me.Panel3.Controls.Add(Me.cboToInventory)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(421, 100)
        Me.Panel3.TabIndex = 1
        '
        'btnAddItem2
        '
        Me.btnAddItem2.Image = CType(resources.GetObject("btnAddItem2.Image"), System.Drawing.Image)
        Me.btnAddItem2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddItem2.Location = New System.Drawing.Point(7, 71)
        Me.btnAddItem2.Name = "btnAddItem2"
        Me.btnAddItem2.Size = New System.Drawing.Size(56, 23)
        Me.btnAddItem2.TabIndex = 6
        Me.btnAddItem2.Text = "Add"
        Me.btnAddItem2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAddItem2, "Add Product Code-Color-Size")
        Me.btnAddItem2.UseVisualStyleBackColor = True
        '
        'cboToInventory
        '
        Me.cboToInventory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToInventory.FormattingEnabled = True
        Me.cboToInventory.Location = New System.Drawing.Point(146, 21)
        Me.cboToInventory.Name = "cboToInventory"
        Me.cboToInventory.Size = New System.Drawing.Size(192, 21)
        Me.cboToInventory.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Inventory Location"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonNew, Me.ToolStripButtonSave, Me.ToolStripLabel1, Me.ToolStripButtonApproved, Me.ToolStripLabel2, Me.ToolStripButtonCancel, Me.ToolStripButtonClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(853, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButtonNew
        '
        Me.ToolStripButtonNew.Image = CType(resources.GetObject("ToolStripButtonNew.Image"), System.Drawing.Image)
        Me.ToolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonNew.Name = "ToolStripButtonNew"
        Me.ToolStripButtonNew.Size = New System.Drawing.Size(51, 22)
        Me.ToolStripButtonNew.Text = "&New"
        '
        'ToolStripButtonSave
        '
        Me.ToolStripButtonSave.Image = CType(resources.GetObject("ToolStripButtonSave.Image"), System.Drawing.Image)
        Me.ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSave.Name = "ToolStripButtonSave"
        Me.ToolStripButtonSave.Size = New System.Drawing.Size(51, 22)
        Me.ToolStripButtonSave.Text = "&Save"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel1.Text = "               "
        '
        'ToolStripButtonApproved
        '
        Me.ToolStripButtonApproved.Image = CType(resources.GetObject("ToolStripButtonApproved.Image"), System.Drawing.Image)
        Me.ToolStripButtonApproved.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonApproved.Name = "ToolStripButtonApproved"
        Me.ToolStripButtonApproved.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripButtonApproved.Text = "Approve Stock Adjustment"
        Me.ToolStripButtonApproved.ToolTipText = "Approve Stock Adjustment"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel2.Text = "               "
        '
        'ToolStripButtonCancel
        '
        Me.ToolStripButtonCancel.Image = CType(resources.GetObject("ToolStripButtonCancel.Image"), System.Drawing.Image)
        Me.ToolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCancel.Name = "ToolStripButtonCancel"
        Me.ToolStripButtonCancel.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripButtonCancel.Text = "Cancel"
        '
        'ToolStripButtonClose
        '
        Me.ToolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonClose.Image = CType(resources.GetObject("ToolStripButtonClose.Image"), System.Drawing.Image)
        Me.ToolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonClose.Name = "ToolStripButtonClose"
        Me.ToolStripButtonClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripButtonClose.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButtonClose.Text = "Close"
        '
        'StockAdjustmentForm2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1065, 561)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "StockAdjustmentForm2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.gridStockAdjustmentOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.gridStockAdjustmentOrdersFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.gridStockAdjustmentOrdersTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gridStockAdjustmentOrders As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButtonNew As ToolStripButton
    Friend WithEvents ToolStripButtonSave As ToolStripButton
    Friend WithEvents ToolStripButtonClose As ToolStripButton
    Friend WithEvents dtpStockAdjustmentDate As DateTimePicker
    Friend WithEvents txtComments As TextBox
    Friend WithEvents txtTransferedBy As TextBox
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents txtStockAdjustmentNo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Label6 As Label
    Friend WithEvents cboFromInventory As ComboBox
    Friend WithEvents gridStockAdjustmentOrdersFrom As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label8 As Label
    Friend WithEvents cboToInventory As ComboBox
    Friend WithEvents gridStockAdjustmentOrdersTo As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnAddItem As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripButtonCancel As ToolStripButton
    Friend WithEvents LinkLabelRefresh As LinkLabel
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents pickFromRackShelfColumn As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents rackShelfColumnFrom As DataGridViewButtonColumn
    Friend WithEvents deleteProductColorSize As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents ToolStripButtonApproved As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents pickToRackShelfColumn As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents rackShelfColumnTo As DataGridViewButtonColumn
    Friend WithEvents btnAddItem2 As Button
End Class
