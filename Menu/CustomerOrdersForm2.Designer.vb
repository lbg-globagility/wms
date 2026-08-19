<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CustomerOrdersForm2
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerOrdersForm2))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gridOrders = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SIDRNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.linkFirst = New System.Windows.Forms.LinkLabel()
        Me.linkPrev = New System.Windows.Forms.LinkLabel()
        Me.linkLast = New System.Windows.Forms.LinkLabel()
        Me.linkNext = New System.Windows.Forms.LinkLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CheckBoxShowAll = New System.Windows.Forms.CheckBox()
        Me.btnClearSearch = New System.Windows.Forms.Button()
        Me.ButtonSearch = New System.Windows.Forms.Button()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.LinkLabelRefresh = New System.Windows.Forms.LinkLabel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.cboCustomerName = New SergeUtils.EasyCompletionComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cboClassDescription = New System.Windows.Forms.ComboBox()
        Me.btnAddAgent = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pbAddClassDescription = New System.Windows.Forms.PictureBox()
        Me.txtLineUpNos = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtPickListNo = New System.Windows.Forms.TextBox()
        Me.pbAddBranchCodeName = New System.Windows.Forms.PictureBox()
        Me.pbAddVendorCodeName = New System.Windows.Forms.PictureBox()
        Me.pbAddCustomer = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDeliveryHours = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtDRNumber = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.dtpDateSubmitted = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtReferenceNumber = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.cboAgent = New System.Windows.Forms.ComboBox()
        Me.cboBranchCodeNameInfo = New System.Windows.Forms.ComboBox()
        Me.cboVendorCodeNameInfo = New System.Windows.Forms.ComboBox()
        Me.txtOrderNumber = New System.Windows.Forms.TextBox()
        Me.txtDeliveryAddress = New System.Windows.Forms.TextBox()
        Me.dtpOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonApproved = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonRevoke = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonReEncode = New System.Windows.Forms.ToolStripButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gridOrderItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnUnitOfLength = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column22 = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.ColumnUnitOfLengthPriceText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnDelete = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAddOrderItem = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.gridOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.btnAddAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddClassDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddBranchCodeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddVendorCodeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridOrderItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gridOrders)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 713)
        Me.SplitContainer1.SplitterDistance = 333
        Me.SplitContainer1.TabIndex = 0
        '
        'gridOrders
        '
        Me.gridOrders.AllowUserToAddRows = False
        Me.gridOrders.AllowUserToDeleteRows = False
        Me.gridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column13, Me.Column14, Me.SIDRNo, Me.Column19, Me.Column16, Me.Column18, Me.Column21, Me.Column15, Me.Column17, Me.Column20, Me.Column12})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridOrders.DefaultCellStyle = DataGridViewCellStyle2
        Me.gridOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridOrders.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridOrders.Location = New System.Drawing.Point(0, 127)
        Me.gridOrders.Name = "gridOrders"
        Me.gridOrders.ReadOnly = True
        Me.gridOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridOrders.Size = New System.Drawing.Size(331, 549)
        Me.gridOrders.TabIndex = 2
        '
        'Column13
        '
        Me.Column13.DataPropertyName = "OrderNumber"
        Me.Column13.HeaderText = "Customer Order No."
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.DataPropertyName = "ReferenceNumber"
        Me.Column14.HeaderText = "P.O. No."
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'SIDRNo
        '
        Me.SIDRNo.DataPropertyName = "DRNumber"
        Me.SIDRNo.HeaderText = "S.I./D.R. No"
        Me.SIDRNo.Name = "SIDRNo"
        Me.SIDRNo.ReadOnly = True
        '
        'Column19
        '
        Me.Column19.DataPropertyName = "StatusDisplayText"
        Me.Column19.HeaderText = "Status"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.DataPropertyName = "OrderDate"
        Me.Column16.HeaderText = "Customer Order Date"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'Column18
        '
        Me.Column18.DataPropertyName = "CustomerNameText"
        Me.Column18.HeaderText = "Customer Name"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        '
        'Column21
        '
        Me.Column21.DataPropertyName = "AgentNameText"
        Me.Column21.HeaderText = "Agent Name"
        Me.Column21.Name = "Column21"
        Me.Column21.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.DataPropertyName = "DRNumber"
        Me.Column15.HeaderText = "D.R. No."
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column17
        '
        Me.Column17.DataPropertyName = "DateSubmitted"
        Me.Column17.HeaderText = "Date Sent to Warehouse"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        '
        'Column20
        '
        Me.Column20.DataPropertyName = "TotalAmount"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Column20.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column20.HeaderText = "Total Amount"
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.DataPropertyName = "TotalQuantitiesText"
        Me.Column12.HeaderText = "Total Quantities"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.linkFirst)
        Me.Panel5.Controls.Add(Me.linkPrev)
        Me.Panel5.Controls.Add(Me.linkLast)
        Me.Panel5.Controls.Add(Me.linkNext)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 676)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(331, 35)
        Me.Panel5.TabIndex = 3
        '
        'linkFirst
        '
        Me.linkFirst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.linkFirst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.linkFirst.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.linkFirst.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.linkFirst.Location = New System.Drawing.Point(85, 6)
        Me.linkFirst.Name = "linkFirst"
        Me.linkFirst.Size = New System.Drawing.Size(40, 16)
        Me.linkFirst.TabIndex = 4
        Me.linkFirst.TabStop = True
        Me.linkFirst.Text = "« First"
        Me.linkFirst.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'linkPrev
        '
        Me.linkPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.linkPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.linkPrev.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.linkPrev.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.linkPrev.Location = New System.Drawing.Point(125, 6)
        Me.linkPrev.Name = "linkPrev"
        Me.linkPrev.Size = New System.Drawing.Size(40, 16)
        Me.linkPrev.TabIndex = 5
        Me.linkPrev.TabStop = True
        Me.linkPrev.Text = "‹ Prev"
        Me.linkPrev.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'linkLast
        '
        Me.linkLast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.linkLast.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.linkLast.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.linkLast.Location = New System.Drawing.Point(205, 6)
        Me.linkLast.Name = "linkLast"
        Me.linkLast.Size = New System.Drawing.Size(40, 16)
        Me.linkLast.TabIndex = 7
        Me.linkLast.TabStop = True
        Me.linkLast.Text = "Last »"
        Me.linkLast.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'linkNext
        '
        Me.linkNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.linkNext.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.linkNext.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.linkNext.Location = New System.Drawing.Point(165, 6)
        Me.linkNext.Name = "linkNext"
        Me.linkNext.Size = New System.Drawing.Size(40, 16)
        Me.linkNext.TabIndex = 6
        Me.linkNext.TabStop = True
        Me.linkNext.Text = "Next ›"
        Me.linkNext.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.CheckBoxShowAll)
        Me.Panel3.Controls.Add(Me.btnClearSearch)
        Me.Panel3.Controls.Add(Me.ButtonSearch)
        Me.Panel3.Controls.Add(Me.TextBoxSearch)
        Me.Panel3.Controls.Add(Me.LinkLabelRefresh)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(331, 127)
        Me.Panel3.TabIndex = 1
        '
        'CheckBoxShowAll
        '
        Me.CheckBoxShowAll.AutoSize = True
        Me.CheckBoxShowAll.Location = New System.Drawing.Point(11, 104)
        Me.CheckBoxShowAll.Name = "CheckBoxShowAll"
        Me.CheckBoxShowAll.Size = New System.Drawing.Size(70, 17)
        Me.CheckBoxShowAll.TabIndex = 3
        Me.CheckBoxShowAll.Text = "Show all"
        Me.CheckBoxShowAll.UseVisualStyleBackColor = True
        '
        'btnClearSearch
        '
        Me.btnClearSearch.FlatAppearance.BorderSize = 0
        Me.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearSearch.Location = New System.Drawing.Point(12, 81)
        Me.btnClearSearch.Name = "btnClearSearch"
        Me.btnClearSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnClearSearch.TabIndex = 2
        Me.btnClearSearch.Text = "❌"
        Me.btnClearSearch.UseVisualStyleBackColor = True
        '
        'ButtonSearch
        '
        Me.ButtonSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSearch.Location = New System.Drawing.Point(244, 60)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSearch.TabIndex = 1
        Me.ButtonSearch.Text = "Search"
        Me.ButtonSearch.UseVisualStyleBackColor = True
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSearch.Location = New System.Drawing.Point(11, 32)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(308, 22)
        Me.TextBoxSearch.TabIndex = 0
        '
        'LinkLabelRefresh
        '
        Me.LinkLabelRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelRefresh.Image = CType(resources.GetObject("LinkLabelRefresh.Image"), System.Drawing.Image)
        Me.LinkLabelRefresh.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LinkLabelRefresh.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabelRefresh.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabelRefresh.Location = New System.Drawing.Point(255, 105)
        Me.LinkLabelRefresh.Name = "LinkLabelRefresh"
        Me.LinkLabelRefresh.Size = New System.Drawing.Size(64, 18)
        Me.LinkLabelRefresh.TabIndex = 4
        Me.LinkLabelRefresh.TabStop = True
        Me.LinkLabelRefresh.Text = "Refresh"
        Me.LinkLabelRefresh.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.cboCustomerName)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label25)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtComments)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label27)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label28)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtDRNumber)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label26)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtpDateSubmitted)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtpEndDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label22)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label20)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtpDeliveryDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label23)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtStatus)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtReferenceNumber)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label36)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label41)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label29)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label19)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label52)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cboAgent)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cboBranchCodeNameInfo)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cboVendorCodeNameInfo)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtOrderNumber)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtDeliveryAddress)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtpOrderDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label9)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.gridOrderItems)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer2.Size = New System.Drawing.Size(927, 713)
        Me.SplitContainer2.SplitterDistance = 301
        Me.SplitContainer2.TabIndex = 0
        '
        'cboCustomerName
        '
        Me.cboCustomerName.DisplayMember = "CompanyName"
        Me.cboCustomerName.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(168, 111)
        Me.cboCustomerName.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(208, 21)
        Me.cboCustomerName.TabIndex = 757
        Me.cboCustomerName.ValueMember = "RowID"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(409, 119)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 13)
        Me.Label25.TabIndex = 756
        Me.Label25.Text = "Comments"
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(564, 111)
        Me.txtComments.MaxLength = 255
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(208, 50)
        Me.txtComments.TabIndex = 13
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.cboClassDescription)
        Me.Panel4.Controls.Add(Me.btnAddAgent)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.pbAddClassDescription)
        Me.Panel4.Controls.Add(Me.txtLineUpNos)
        Me.Panel4.Controls.Add(Me.Label24)
        Me.Panel4.Controls.Add(Me.Label31)
        Me.Panel4.Controls.Add(Me.txtPickListNo)
        Me.Panel4.Controls.Add(Me.pbAddBranchCodeName)
        Me.Panel4.Controls.Add(Me.pbAddVendorCodeName)
        Me.Panel4.Controls.Add(Me.pbAddCustomer)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.txtDeliveryHours)
        Me.Panel4.Location = New System.Drawing.Point(848, 84)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(521, 290)
        Me.Panel4.TabIndex = 754
        Me.Panel4.Visible = False
        '
        'cboClassDescription
        '
        Me.cboClassDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboClassDescription.FormattingEnabled = True
        Me.cboClassDescription.Location = New System.Drawing.Point(154, 60)
        Me.cboClassDescription.Name = "cboClassDescription"
        Me.cboClassDescription.Size = New System.Drawing.Size(285, 21)
        Me.cboClassDescription.TabIndex = 730
        '
        'btnAddAgent
        '
        Me.btnAddAgent.BackColor = System.Drawing.Color.Transparent
        Me.btnAddAgent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddAgent.Image = CType(resources.GetObject("btnAddAgent.Image"), System.Drawing.Image)
        Me.btnAddAgent.Location = New System.Drawing.Point(13, 207)
        Me.btnAddAgent.Name = "btnAddAgent"
        Me.btnAddAgent.Size = New System.Drawing.Size(14, 18)
        Me.btnAddAgent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnAddAgent.TabIndex = 753
        Me.btnAddAgent.TabStop = False
        Me.btnAddAgent.Tag = ""
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(244, 153)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 737
        Me.Label11.Text = "Line-Up No(s)."
        '
        'pbAddClassDescription
        '
        Me.pbAddClassDescription.BackColor = System.Drawing.Color.Transparent
        Me.pbAddClassDescription.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddClassDescription.Image = CType(resources.GetObject("pbAddClassDescription.Image"), System.Drawing.Image)
        Me.pbAddClassDescription.Location = New System.Drawing.Point(465, 25)
        Me.pbAddClassDescription.Name = "pbAddClassDescription"
        Me.pbAddClassDescription.Size = New System.Drawing.Size(14, 18)
        Me.pbAddClassDescription.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddClassDescription.TabIndex = 752
        Me.pbAddClassDescription.TabStop = False
        Me.pbAddClassDescription.Tag = ""
        '
        'txtLineUpNos
        '
        Me.txtLineUpNos.Location = New System.Drawing.Point(335, 150)
        Me.txtLineUpNos.Name = "txtLineUpNos"
        Me.txtLineUpNos.ReadOnly = True
        Me.txtLineUpNos.Size = New System.Drawing.Size(120, 22)
        Me.txtLineUpNos.TabIndex = 734
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(48, 153)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(68, 13)
        Me.Label24.TabIndex = 739
        Me.Label24.Text = "Pick List No."
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(48, 63)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(95, 13)
        Me.Label31.TabIndex = 751
        Me.Label31.Text = "Class Description"
        '
        'txtPickListNo
        '
        Me.txtPickListNo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPickListNo.Location = New System.Drawing.Point(128, 149)
        Me.txtPickListNo.Name = "txtPickListNo"
        Me.txtPickListNo.ReadOnly = True
        Me.txtPickListNo.Size = New System.Drawing.Size(110, 22)
        Me.txtPickListNo.TabIndex = 733
        '
        'pbAddBranchCodeName
        '
        Me.pbAddBranchCodeName.BackColor = System.Drawing.Color.Transparent
        Me.pbAddBranchCodeName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddBranchCodeName.Image = CType(resources.GetObject("pbAddBranchCodeName.Image"), System.Drawing.Image)
        Me.pbAddBranchCodeName.Location = New System.Drawing.Point(13, 119)
        Me.pbAddBranchCodeName.Name = "pbAddBranchCodeName"
        Me.pbAddBranchCodeName.Size = New System.Drawing.Size(14, 18)
        Me.pbAddBranchCodeName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddBranchCodeName.TabIndex = 750
        Me.pbAddBranchCodeName.TabStop = False
        Me.pbAddBranchCodeName.Tag = ""
        '
        'pbAddVendorCodeName
        '
        Me.pbAddVendorCodeName.BackColor = System.Drawing.Color.Transparent
        Me.pbAddVendorCodeName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddVendorCodeName.Image = CType(resources.GetObject("pbAddVendorCodeName.Image"), System.Drawing.Image)
        Me.pbAddVendorCodeName.Location = New System.Drawing.Point(13, 148)
        Me.pbAddVendorCodeName.Name = "pbAddVendorCodeName"
        Me.pbAddVendorCodeName.Size = New System.Drawing.Size(14, 18)
        Me.pbAddVendorCodeName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddVendorCodeName.TabIndex = 749
        Me.pbAddVendorCodeName.TabStop = False
        Me.pbAddVendorCodeName.Tag = ""
        '
        'pbAddCustomer
        '
        Me.pbAddCustomer.BackColor = System.Drawing.Color.Transparent
        Me.pbAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddCustomer.Image = CType(resources.GetObject("pbAddCustomer.Image"), System.Drawing.Image)
        Me.pbAddCustomer.Location = New System.Drawing.Point(13, 63)
        Me.pbAddCustomer.Name = "pbAddCustomer"
        Me.pbAddCustomer.Size = New System.Drawing.Size(14, 18)
        Me.pbAddCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddCustomer.TabIndex = 741
        Me.pbAddCustomer.TabStop = False
        Me.pbAddCustomer.Tag = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(101, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 742
        Me.Label10.Text = "Delivery Hours"
        '
        'txtDeliveryHours
        '
        Me.txtDeliveryHours.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryHours.Location = New System.Drawing.Point(51, 103)
        Me.txtDeliveryHours.Multiline = True
        Me.txtDeliveryHours.Name = "txtDeliveryHours"
        Me.txtDeliveryHours.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDeliveryHours.Size = New System.Drawing.Size(187, 40)
        Me.txtDeliveryHours.TabIndex = 731
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(409, 65)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(68, 13)
        Me.Label27.TabIndex = 747
        Me.Label27.Text = "S.I./D.R. No."
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(541, 53)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(17, 21)
        Me.Label28.TabIndex = 746
        Me.Label28.Text = "*"
        Me.Label28.Visible = False
        '
        'txtDRNumber
        '
        Me.txtDRNumber.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDRNumber.Location = New System.Drawing.Point(564, 56)
        Me.txtDRNumber.Name = "txtDRNumber"
        Me.txtDRNumber.ReadOnly = True
        Me.txtDRNumber.Size = New System.Drawing.Size(208, 22)
        Me.txtDRNumber.TabIndex = 10
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(409, 203)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(133, 13)
        Me.Label26.TabIndex = 745
        Me.Label26.Text = "Date Sent to Warehouse"
        '
        'dtpDateSubmitted
        '
        Me.dtpDateSubmitted.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpDateSubmitted.Checked = False
        Me.dtpDateSubmitted.Enabled = False
        Me.dtpDateSubmitted.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateSubmitted.Location = New System.Drawing.Point(564, 194)
        Me.dtpDateSubmitted.Name = "dtpDateSubmitted"
        Me.dtpDateSubmitted.ShowCheckBox = True
        Me.dtpDateSubmitted.Size = New System.Drawing.Size(208, 22)
        Me.dtpDateSubmitted.TabIndex = 14
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpEndDate.Checked = False
        Me.dtpEndDate.Enabled = False
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(564, 248)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(208, 22)
        Me.dtpEndDate.TabIndex = 16
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(409, 257)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 13)
        Me.Label22.TabIndex = 744
        Me.Label22.Text = "Cancel Date"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(409, 37)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 13)
        Me.Label20.TabIndex = 743
        Me.Label20.Text = "P.O. No."
        '
        'dtpDeliveryDate
        '
        Me.dtpDeliveryDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpDeliveryDate.Checked = False
        Me.dtpDeliveryDate.Enabled = False
        Me.dtpDeliveryDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDeliveryDate.Location = New System.Drawing.Point(564, 221)
        Me.dtpDeliveryDate.Name = "dtpDeliveryDate"
        Me.dtpDeliveryDate.ShowCheckBox = True
        Me.dtpDeliveryDate.Size = New System.Drawing.Size(208, 22)
        Me.dtpDeliveryDate.TabIndex = 15
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(409, 230)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(74, 13)
        Me.Label23.TabIndex = 738
        Me.Label23.Text = "Delivery Date"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(564, 84)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(208, 22)
        Me.txtStatus.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(409, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 13)
        Me.Label12.TabIndex = 736
        Me.Label12.Text = "Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(541, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 21)
        Me.Label6.TabIndex = 735
        Me.Label6.Text = "*"
        '
        'txtReferenceNumber
        '
        Me.txtReferenceNumber.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferenceNumber.Location = New System.Drawing.Point(564, 28)
        Me.txtReferenceNumber.Name = "txtReferenceNumber"
        Me.txtReferenceNumber.Size = New System.Drawing.Size(208, 22)
        Me.txtReferenceNumber.TabIndex = 9
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(3, 256)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(38, 13)
        Me.Label36.TabIndex = 722
        Me.Label36.Text = "Agent"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(3, 202)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(135, 13)
        Me.Label41.TabIndex = 719
        Me.Label41.Text = "Branch Code / Name Info"
        Me.Label41.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(3, 229)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(137, 13)
        Me.Label29.TabIndex = 718
        Me.Label29.Text = "Vendor Code / Name Info"
        Me.Label29.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 146)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(91, 13)
        Me.Label19.TabIndex = 716
        Me.Label19.Text = "Delivery Address"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(3, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 714
        Me.Label2.Text = "Customer Order Date"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 119)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 713
        Me.Label14.Text = "Customer Name"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(3, 37)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(110, 13)
        Me.Label52.TabIndex = 712
        Me.Label52.Text = "Customer Order No."
        '
        'cboAgent
        '
        Me.cboAgent.CausesValidation = False
        Me.cboAgent.DisplayMember = "FullNameLastNameFirst"
        Me.cboAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgent.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAgent.Location = New System.Drawing.Point(168, 248)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Size = New System.Drawing.Size(208, 21)
        Me.cboAgent.TabIndex = 7
        Me.cboAgent.ValueMember = "RowID"
        '
        'cboBranchCodeNameInfo
        '
        Me.cboBranchCodeNameInfo.BackColor = System.Drawing.SystemColors.Window
        Me.cboBranchCodeNameInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBranchCodeNameInfo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranchCodeNameInfo.FormattingEnabled = True
        Me.cboBranchCodeNameInfo.Location = New System.Drawing.Point(168, 194)
        Me.cboBranchCodeNameInfo.Name = "cboBranchCodeNameInfo"
        Me.cboBranchCodeNameInfo.Size = New System.Drawing.Size(208, 21)
        Me.cboBranchCodeNameInfo.TabIndex = 5
        Me.cboBranchCodeNameInfo.Visible = False
        '
        'cboVendorCodeNameInfo
        '
        Me.cboVendorCodeNameInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendorCodeNameInfo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendorCodeNameInfo.FormattingEnabled = True
        Me.cboVendorCodeNameInfo.Location = New System.Drawing.Point(168, 221)
        Me.cboVendorCodeNameInfo.Name = "cboVendorCodeNameInfo"
        Me.cboVendorCodeNameInfo.Size = New System.Drawing.Size(208, 21)
        Me.cboVendorCodeNameInfo.TabIndex = 6
        Me.cboVendorCodeNameInfo.Visible = False
        '
        'txtOrderNumber
        '
        Me.txtOrderNumber.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderNumber.Location = New System.Drawing.Point(168, 28)
        Me.txtOrderNumber.Name = "txtOrderNumber"
        Me.txtOrderNumber.ReadOnly = True
        Me.txtOrderNumber.Size = New System.Drawing.Size(208, 22)
        Me.txtOrderNumber.TabIndex = 0
        '
        'txtDeliveryAddress
        '
        Me.txtDeliveryAddress.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryAddress.Location = New System.Drawing.Point(168, 138)
        Me.txtDeliveryAddress.MaxLength = 150
        Me.txtDeliveryAddress.Multiline = True
        Me.txtDeliveryAddress.Name = "txtDeliveryAddress"
        Me.txtDeliveryAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDeliveryAddress.Size = New System.Drawing.Size(208, 50)
        Me.txtDeliveryAddress.TabIndex = 4
        '
        'dtpOrderDate
        '
        Me.dtpOrderDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpOrderDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpOrderDate.Location = New System.Drawing.Point(168, 56)
        Me.dtpOrderDate.Name = "dtpOrderDate"
        Me.dtpOrderDate.Size = New System.Drawing.Size(208, 22)
        Me.dtpOrderDate.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonNew, Me.ToolStripLabel3, Me.ToolStripButtonSave, Me.ToolStripLabel1, Me.ToolStripButtonApproved, Me.ToolStripLabel2, Me.ToolStripButtonPrint, Me.ToolStripLabel6, Me.ToolStripButtonCancel, Me.ToolStripButtonClose, Me.ToolStripLabel4, Me.ToolStripButtonRevoke, Me.ToolStripLabel5, Me.ToolStripButtonReEncode})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(925, 25)
        Me.ToolStrip1.TabIndex = 1
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
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(31, 22)
        Me.ToolStripLabel3.Text = "        "
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
        Me.ToolStripButtonApproved.Size = New System.Drawing.Size(129, 22)
        Me.ToolStripButtonApproved.Text = "Send to Warehouse"
        Me.ToolStripButtonApproved.ToolTipText = "Approve Stock Transfer"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel2.Text = "               "
        '
        'ToolStripButtonPrint
        '
        Me.ToolStripButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonPrint.Image = CType(resources.GetObject("ToolStripButtonPrint.Image"), System.Drawing.Image)
        Me.ToolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonPrint.Name = "ToolStripButtonPrint"
        Me.ToolStripButtonPrint.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonPrint.Text = "Print"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel6.Text = "               "
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
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel4.Text = "               "
        '
        'ToolStripButtonRevoke
        '
        Me.ToolStripButtonRevoke.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonRevoke.Image = CType(resources.GetObject("ToolStripButtonRevoke.Image"), System.Drawing.Image)
        Me.ToolStripButtonRevoke.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonRevoke.Name = "ToolStripButtonRevoke"
        Me.ToolStripButtonRevoke.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripButtonRevoke.Text = "Revoke Order"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel5.Text = "               "
        '
        'ToolStripButtonReEncode
        '
        Me.ToolStripButtonReEncode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonReEncode.Image = CType(resources.GetObject("ToolStripButtonReEncode.Image"), System.Drawing.Image)
        Me.ToolStripButtonReEncode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonReEncode.Name = "ToolStripButtonReEncode"
        Me.ToolStripButtonReEncode.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripButtonReEncode.Text = "Re-Encode as New"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(150, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 21)
        Me.Label9.TabIndex = 715
        Me.Label9.Text = "*"
        '
        'gridOrderItems
        '
        Me.gridOrderItems.AllowUserToAddRows = False
        Me.gridOrderItems.AllowUserToDeleteRows = False
        Me.gridOrderItems.ColumnHeadersHeight = 40
        Me.gridOrderItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column23, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column9, Me.Column6, Me.Column7, Me.ColumnUnitOfLength, Me.Column22, Me.ColumnUnitOfLengthPriceText, Me.Column8, Me.Column10, Me.Column11, Me.ColumnDelete})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridOrderItems.DefaultCellStyle = DataGridViewCellStyle7
        Me.gridOrderItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridOrderItems.EnableHeadersVisualStyles = False
        Me.gridOrderItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridOrderItems.Location = New System.Drawing.Point(0, 35)
        Me.gridOrderItems.Name = "gridOrderItems"
        Me.gridOrderItems.RowHeadersWidth = 67
        Me.gridOrderItems.Size = New System.Drawing.Size(925, 336)
        Me.gridOrderItems.TabIndex = 1
        '
        'Column23
        '
        Me.Column23.DataPropertyName = "WarehouseName"
        Me.Column23.HeaderText = "Inventory Name"
        Me.Column23.Name = "Column23"
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "ProductCode"
        Me.Column1.HeaderText = "Product Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "ColorName"
        Me.Column2.HeaderText = "Color Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Size"
        Me.Column3.HeaderText = "Size"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "SeasonCode"
        Me.Column4.HeaderText = "Season Code"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "QuantityOrdered"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "Number of Roll(s)"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 120
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "UnitOfMeasure"
        Me.Column9.HeaderText = "Unit of Measure"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column6.HeaderText = "Price per Roll"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "TotalItemPrice"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column7.HeaderText = "Total Item Price (Roll)"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 128
        '
        'ColumnUnitOfLength
        '
        Me.ColumnUnitOfLength.DataPropertyName = "UnitOfLength"
        Me.ColumnUnitOfLength.HeaderText = "Unit Of Length"
        Me.ColumnUnitOfLength.Name = "ColumnUnitOfLength"
        Me.ColumnUnitOfLength.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Column22
        '
        '
        '
        '
        Me.Column22.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.Column22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Column22.DataPropertyName = "UnitOfLengthNumber"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Column22.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column22.HeaderText = "Unit Length Number"
        Me.Column22.Increment = 1.0R
        Me.Column22.Name = "Column22"
        '
        'ColumnUnitOfLengthPriceText
        '
        Me.ColumnUnitOfLengthPriceText.DataPropertyName = "UnitOfLengthPriceText"
        Me.ColumnUnitOfLengthPriceText.HeaderText = "Price Per Unit (Meter/Yard)"
        Me.ColumnUnitOfLengthPriceText.Name = "ColumnUnitOfLengthPriceText"
        Me.ColumnUnitOfLengthPriceText.Width = 144
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "Sku"
        Me.Column8.HeaderText = "SKU"
        Me.Column8.Name = "Column8"
        '
        'Column10
        '
        Me.Column10.DataPropertyName = "Sku2"
        Me.Column10.HeaderText = "SKU2"
        Me.Column10.Name = "Column10"
        '
        'Column11
        '
        Me.Column11.DataPropertyName = "Remarks"
        Me.Column11.HeaderText = "Remarks"
        Me.Column11.Name = "Column11"
        '
        'ColumnDelete
        '
        Me.ColumnDelete.HeaderText = "Delete?"
        Me.ColumnDelete.Image = CType(resources.GetObject("ColumnDelete.Image"), System.Drawing.Image)
        Me.ColumnDelete.Name = "ColumnDelete"
        Me.ColumnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColumnDelete.Text = Nothing
        Me.ColumnDelete.Width = 48
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 371)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(925, 35)
        Me.Panel2.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAddOrderItem)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(925, 35)
        Me.Panel1.TabIndex = 1
        '
        'btnAddOrderItem
        '
        Me.btnAddOrderItem.Image = CType(resources.GetObject("btnAddOrderItem.Image"), System.Drawing.Image)
        Me.btnAddOrderItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddOrderItem.Location = New System.Drawing.Point(6, 6)
        Me.btnAddOrderItem.Name = "btnAddOrderItem"
        Me.btnAddOrderItem.Size = New System.Drawing.Size(112, 23)
        Me.btnAddOrderItem.TabIndex = 0
        Me.btnAddOrderItem.Text = "Add Order Item"
        Me.btnAddOrderItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddOrderItem.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(121, 70)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripMenuItem1.Text = "Copy"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripMenuItem2.Text = "Paste"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripMenuItem3.Text = "Make All"
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(61, 4)
        '
        'CustomerOrdersForm2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1264, 713)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "CustomerOrdersForm2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.gridOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.btnAddAgent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddClassDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddBranchCodeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddVendorCodeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridOrderItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents gridOrderItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAddOrderItem As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButtonNew As ToolStripButton
    Friend WithEvents ToolStripButtonSave As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripButtonApproved As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToolStripButtonCancel As ToolStripButton
    Friend WithEvents ToolStripButtonClose As ToolStripButton
    Friend WithEvents gridOrders As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cboAgent As ComboBox
    Friend WithEvents cboBranchCodeNameInfo As ComboBox
    Friend WithEvents cboVendorCodeNameInfo As ComboBox
    Friend WithEvents txtOrderNumber As TextBox
    Friend WithEvents txtDeliveryAddress As TextBox
    Friend WithEvents dtpOrderDate As DateTimePicker
    Friend WithEvents Label36 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnAddAgent As PictureBox
    Friend WithEvents pbAddClassDescription As PictureBox
    Friend WithEvents cboClassDescription As ComboBox
    Friend WithEvents Label31 As Label
    Friend WithEvents pbAddBranchCodeName As PictureBox
    Friend WithEvents pbAddVendorCodeName As PictureBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents txtDRNumber As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents Label22 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtDeliveryHours As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents pbAddCustomer As PictureBox
    Friend WithEvents txtPickListNo As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents dtpDeliveryDate As DateTimePicker
    Friend WithEvents Label23 As Label
    Friend WithEvents txtLineUpNos As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtReferenceNumber As TextBox
    Friend WithEvents dtpDateSubmitted As DateTimePicker
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label25 As Label
    Friend WithEvents txtComments As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents linkNext As LinkLabel
    Friend WithEvents linkPrev As LinkLabel
    Friend WithEvents linkFirst As LinkLabel
    Friend WithEvents linkLast As LinkLabel
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents ToolStripButtonRevoke As ToolStripButton
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents ToolStripButtonReEncode As ToolStripButton
    Friend WithEvents ToolStripButtonPrint As ToolStripButton
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents ButtonSearch As Button
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents btnClearSearch As Button
    Friend WithEvents CheckBoxShowAll As CheckBox
    Friend WithEvents LinkLabelRefresh As LinkLabel
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents Column23 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents ColumnUnitOfLength As DataGridViewComboBoxColumn
    Friend WithEvents Column22 As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents ColumnUnitOfLengthPriceText As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents ColumnDelete As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents cboCustomerName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents SIDRNo As DataGridViewTextBoxColumn
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents Column21 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column20 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
End Class
