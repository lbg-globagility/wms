<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsForm))
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
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.tabAccounts = New System.Windows.Forms.TabControl()
        Me.tabCustomers = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbCustomerList = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPageA = New System.Windows.Forms.TextBox()
        Me.txtPageNoA = New System.Windows.Forms.TextBox()
        Me.tsMenuA = New System.Windows.Forms.ToolStrip()
        Me.cmdFirstA = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrevA = New System.Windows.Forms.ToolStripButton()
        Me.cmdNextA = New System.Windows.Forms.ToolStripButton()
        Me.cmdLastA = New System.Windows.Forms.ToolStripButton()
        Me.tsRefreshA = New System.Windows.Forms.ToolStripButton()
        Me.dgCustomerList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.c_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_customerno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_customername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_mainphone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_parentcustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.gbSearchA = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tabSearchA = New System.Windows.Forms.TabControl()
        Me.tabSimpleA = New System.Windows.Forms.TabPage()
        Me.txtSimpleSearchA = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tabCommonA = New System.Windows.Forms.TabPage()
        Me.cboSearch4A = New System.Windows.Forms.ComboBox()
        Me.cboSearch2A = New System.Windows.Forms.ComboBox()
        Me.cboSearch3A = New System.Windows.Forms.ComboBox()
        Me.cboSearch1A = New System.Windows.Forms.ComboBox()
        Me.tabCustomersMain = New System.Windows.Forms.TabControl()
        Me.tabCustomerDetails = New System.Windows.Forms.TabPage()
        Me.gbCustomerOrders = New System.Windows.Forms.GroupBox()
        Me.dgCustomerOrderItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ci_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtyordered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtydelivered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_srp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_totalprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_verifiedby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_verifieddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_packedby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_packeddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_deliveredby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_delivereddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpToSearch = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromSearch = New System.Windows.Forms.DateTimePicker()
        Me.dgCustomerOrders = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.co_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_customerorderno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_pono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_customerorderdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_drnos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.gbCustomerInformation = New System.Windows.Forms.GroupBox()
        Me.pbAutoAddA = New System.Windows.Forms.PictureBox()
        Me.pbAddBranchCodeName = New System.Windows.Forms.PictureBox()
        Me.cboBranchCodeNameInfo = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtDeliveryHours = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboPickingGroup = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboStatusA = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pbEditContactPersonA = New System.Windows.Forms.PictureBox()
        Me.txtContactPersonA = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTINA = New System.Windows.Forms.MaskedTextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCommentsA = New System.Windows.Forms.TextBox()
        Me.txtWebsiteA = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEmailAddressA = New System.Windows.Forms.TextBox()
        Me.pbEditDeliveryAddress = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFaxNoA = New System.Windows.Forms.TextBox()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.cboParentCustomer = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAlternatePhoneA = New System.Windows.Forms.TextBox()
        Me.txtDeliveryAddressA = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCustomerNo = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtMainPhoneA = New System.Windows.Forms.TextBox()
        Me.msMenuA = New System.Windows.Forms.MenuStrip()
        Me.msNewA = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSaveA = New System.Windows.Forms.ToolStripMenuItem()
        Me.msCancelA = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblsavemsgA = New System.Windows.Forms.Label()
        Me.tabSuppliers = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.gbSupplierList = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPage = New System.Windows.Forms.TextBox()
        Me.txtPageNo = New System.Windows.Forms.TextBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.cmdFirst = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrev = New System.Windows.Forms.ToolStripButton()
        Me.cmdNext = New System.Windows.Forms.ToolStripButton()
        Me.cmdLast = New System.Windows.Forms.ToolStripButton()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.dgSuppliersList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.s_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_supplierno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_suppliername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_mainphone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tabSearch = New System.Windows.Forms.TabControl()
        Me.tabSimple = New System.Windows.Forms.TabPage()
        Me.txtSimpleSearch = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tabCommon = New System.Windows.Forms.TabPage()
        Me.cboSearch4 = New System.Windows.Forms.ComboBox()
        Me.cboSearch2 = New System.Windows.Forms.ComboBox()
        Me.cboSearch3 = New System.Windows.Forms.ComboBox()
        Me.cboSearch1 = New System.Windows.Forms.ComboBox()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.gbSupplierInformation = New System.Windows.Forms.GroupBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.pbEditContactPerson = New System.Windows.Forms.PictureBox()
        Me.txtContactPerson = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtTIN = New System.Windows.Forms.MaskedTextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.txtWebsite = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtFaxNo = New System.Windows.Forms.TextBox()
        Me.txtSupplierName = New System.Windows.Forms.TextBox()
        Me.txtAlternatePhone = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtSupplierNo = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtMainPhone = New System.Windows.Forms.TextBox()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.cboAgent = New System.Windows.Forms.ComboBox()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAccounts.SuspendLayout()
        Me.tabCustomers.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbCustomerList.SuspendLayout()
        Me.tsMenuA.SuspendLayout()
        CType(Me.dgCustomerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSearchA.SuspendLayout()
        Me.tabSearchA.SuspendLayout()
        Me.tabSimpleA.SuspendLayout()
        Me.tabCommonA.SuspendLayout()
        Me.tabCustomersMain.SuspendLayout()
        Me.tabCustomerDetails.SuspendLayout()
        Me.gbCustomerOrders.SuspendLayout()
        CType(Me.dgCustomerOrderItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCustomerOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCustomerInformation.SuspendLayout()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddBranchCodeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEditContactPersonA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEditDeliveryAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msMenuA.SuspendLayout()
        Me.tabSuppliers.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.gbSupplierList.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.dgSuppliersList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSearch.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.tabSimple.SuspendLayout()
        Me.tabCommon.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.gbSupplierInformation.SuspendLayout()
        CType(Me.pbEditContactPerson, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msMenu.SuspendLayout()
        Me.SuspendLayout()
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
        Me.pbClose.Location = New System.Drawing.Point(1175, 3)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(19, 19)
        Me.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbClose.TabIndex = 229
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
        Me.lblTitle.Size = New System.Drawing.Size(1200, 25)
        Me.lblTitle.TabIndex = 228
        Me.lblTitle.Text = "Accounts"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabAccounts
        '
        Me.tabAccounts.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabAccounts.Controls.Add(Me.tabCustomers)
        Me.tabAccounts.Controls.Add(Me.tabSuppliers)
        Me.tabAccounts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabAccounts.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabAccounts.ItemSize = New System.Drawing.Size(61, 23)
        Me.tabAccounts.Location = New System.Drawing.Point(0, 25)
        Me.tabAccounts.Multiline = True
        Me.tabAccounts.Name = "tabAccounts"
        Me.tabAccounts.SelectedIndex = 0
        Me.tabAccounts.Size = New System.Drawing.Size(1200, 535)
        Me.tabAccounts.TabIndex = 230
        '
        'tabCustomers
        '
        Me.tabCustomers.AutoScroll = True
        Me.tabCustomers.Controls.Add(Me.SplitContainer1)
        Me.tabCustomers.Location = New System.Drawing.Point(4, 4)
        Me.tabCustomers.Name = "tabCustomers"
        Me.tabCustomers.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCustomers.Size = New System.Drawing.Size(1192, 504)
        Me.tabCustomers.TabIndex = 0
        Me.tabCustomers.Text = "Customers"
        Me.tabCustomers.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Firebrick
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbCustomerList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbSearchA)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabCustomersMain)
        Me.SplitContainer1.Panel2.Controls.Add(Me.msMenuA)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblsavemsgA)
        Me.SplitContainer1.Size = New System.Drawing.Size(1186, 498)
        Me.SplitContainer1.SplitterDistance = 357
        Me.SplitContainer1.TabIndex = 234
        '
        'gbCustomerList
        '
        Me.gbCustomerList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbCustomerList.BackColor = System.Drawing.Color.Transparent
        Me.gbCustomerList.Controls.Add(Me.Label4)
        Me.gbCustomerList.Controls.Add(Me.txtPageA)
        Me.gbCustomerList.Controls.Add(Me.txtPageNoA)
        Me.gbCustomerList.Controls.Add(Me.tsMenuA)
        Me.gbCustomerList.Controls.Add(Me.dgCustomerList)
        Me.gbCustomerList.Controls.Add(Me.Label16)
        Me.gbCustomerList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCustomerList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCustomerList.Location = New System.Drawing.Point(6, 152)
        Me.gbCustomerList.Name = "gbCustomerList"
        Me.gbCustomerList.Size = New System.Drawing.Size(340, 335)
        Me.gbCustomerList.TabIndex = 2
        Me.gbCustomerList.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(50, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 15)
        Me.Label4.TabIndex = 297
        Me.Label4.Text = "Page No.:"
        '
        'txtPageA
        '
        Me.txtPageA.Location = New System.Drawing.Point(228, 43)
        Me.txtPageA.Name = "txtPageA"
        Me.txtPageA.Size = New System.Drawing.Size(41, 21)
        Me.txtPageA.TabIndex = 12
        '
        'txtPageNoA
        '
        Me.txtPageNoA.Location = New System.Drawing.Point(121, 43)
        Me.txtPageNoA.Name = "txtPageNoA"
        Me.txtPageNoA.ReadOnly = True
        Me.txtPageNoA.Size = New System.Drawing.Size(101, 21)
        Me.txtPageNoA.TabIndex = 11
        '
        'tsMenuA
        '
        Me.tsMenuA.AutoSize = False
        Me.tsMenuA.BackColor = System.Drawing.Color.Transparent
        Me.tsMenuA.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMenuA.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenuA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdFirstA, Me.cmdPrevA, Me.cmdNextA, Me.cmdLastA, Me.tsRefreshA})
        Me.tsMenuA.Location = New System.Drawing.Point(3, 17)
        Me.tsMenuA.Name = "tsMenuA"
        Me.tsMenuA.Size = New System.Drawing.Size(334, 22)
        Me.tsMenuA.TabIndex = 10
        Me.tsMenuA.Text = "toolbar1"
        '
        'cmdFirstA
        '
        Me.cmdFirstA.BackColor = System.Drawing.Color.White
        Me.cmdFirstA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdFirstA.Image = CType(resources.GetObject("cmdFirstA.Image"), System.Drawing.Image)
        Me.cmdFirstA.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdFirstA.Name = "cmdFirstA"
        Me.cmdFirstA.Size = New System.Drawing.Size(24, 19)
        Me.cmdFirstA.Text = "First"
        '
        'cmdPrevA
        '
        Me.cmdPrevA.BackColor = System.Drawing.Color.White
        Me.cmdPrevA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPrevA.Image = CType(resources.GetObject("cmdPrevA.Image"), System.Drawing.Image)
        Me.cmdPrevA.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdPrevA.Name = "cmdPrevA"
        Me.cmdPrevA.Size = New System.Drawing.Size(24, 19)
        Me.cmdPrevA.Text = "Previous"
        '
        'cmdNextA
        '
        Me.cmdNextA.BackColor = System.Drawing.Color.White
        Me.cmdNextA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdNextA.Image = CType(resources.GetObject("cmdNextA.Image"), System.Drawing.Image)
        Me.cmdNextA.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdNextA.Name = "cmdNextA"
        Me.cmdNextA.Size = New System.Drawing.Size(24, 19)
        Me.cmdNextA.Text = "Next"
        '
        'cmdLastA
        '
        Me.cmdLastA.BackColor = System.Drawing.Color.White
        Me.cmdLastA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdLastA.Image = CType(resources.GetObject("cmdLastA.Image"), System.Drawing.Image)
        Me.cmdLastA.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdLastA.Name = "cmdLastA"
        Me.cmdLastA.Size = New System.Drawing.Size(24, 19)
        Me.cmdLastA.Text = "Last"
        '
        'tsRefreshA
        '
        Me.tsRefreshA.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRefreshA.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsRefreshA.ForeColor = System.Drawing.Color.White
        Me.tsRefreshA.Image = CType(resources.GetObject("tsRefreshA.Image"), System.Drawing.Image)
        Me.tsRefreshA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRefreshA.Name = "tsRefreshA"
        Me.tsRefreshA.Size = New System.Drawing.Size(78, 19)
        Me.tsRefreshA.Text = "&Refresh"
        '
        'dgCustomerList
        '
        Me.dgCustomerList.AllowUserToAddRows = False
        Me.dgCustomerList.AllowUserToDeleteRows = False
        Me.dgCustomerList.AllowUserToOrderColumns = True
        Me.dgCustomerList.AllowUserToResizeRows = False
        Me.dgCustomerList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgCustomerList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomerList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c_rowid, Me.c_customerno, Me.c_customername, Me.c_mainphone, Me.c_parentcustomer})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCustomerList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCustomerList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCustomerList.Location = New System.Drawing.Point(8, 69)
        Me.dgCustomerList.MultiSelect = False
        Me.dgCustomerList.Name = "dgCustomerList"
        Me.dgCustomerList.ReadOnly = True
        Me.dgCustomerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCustomerList.Size = New System.Drawing.Size(325, 260)
        Me.dgCustomerList.TabIndex = 13
        '
        'c_rowid
        '
        Me.c_rowid.HeaderText = "rowid"
        Me.c_rowid.Name = "c_rowid"
        Me.c_rowid.ReadOnly = True
        Me.c_rowid.Visible = False
        '
        'c_customerno
        '
        Me.c_customerno.HeaderText = "Customer No."
        Me.c_customerno.Name = "c_customerno"
        Me.c_customerno.ReadOnly = True
        Me.c_customerno.Width = 60
        '
        'c_customername
        '
        Me.c_customername.HeaderText = "Customer Name"
        Me.c_customername.Name = "c_customername"
        Me.c_customername.ReadOnly = True
        '
        'c_mainphone
        '
        Me.c_mainphone.HeaderText = "Main Phone"
        Me.c_mainphone.Name = "c_mainphone"
        Me.c_mainphone.ReadOnly = True
        '
        'c_parentcustomer
        '
        Me.c_parentcustomer.HeaderText = "Parent Customer"
        Me.c_parentcustomer.Name = "c_parentcustomer"
        Me.c_parentcustomer.ReadOnly = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Firebrick
        Me.Label16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(6, -1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(107, 17)
        Me.Label16.TabIndex = 216
        Me.Label16.Text = "Customer List:"
        '
        'gbSearchA
        '
        Me.gbSearchA.BackColor = System.Drawing.Color.Transparent
        Me.gbSearchA.Controls.Add(Me.Label21)
        Me.gbSearchA.Controls.Add(Me.tabSearchA)
        Me.gbSearchA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSearchA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSearchA.Location = New System.Drawing.Point(6, 5)
        Me.gbSearchA.Name = "gbSearchA"
        Me.gbSearchA.Size = New System.Drawing.Size(340, 140)
        Me.gbSearchA.TabIndex = 1
        Me.gbSearchA.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Firebrick
        Me.Label21.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(6, -2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 17)
        Me.Label21.TabIndex = 217
        Me.Label21.Text = "Search:"
        '
        'tabSearchA
        '
        Me.tabSearchA.Controls.Add(Me.tabSimpleA)
        Me.tabSearchA.Controls.Add(Me.tabCommonA)
        Me.tabSearchA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSearchA.ItemSize = New System.Drawing.Size(62, 25)
        Me.tabSearchA.Location = New System.Drawing.Point(8, 21)
        Me.tabSearchA.Multiline = True
        Me.tabSearchA.Name = "tabSearchA"
        Me.tabSearchA.SelectedIndex = 0
        Me.tabSearchA.Size = New System.Drawing.Size(324, 106)
        Me.tabSearchA.TabIndex = 9
        '
        'tabSimpleA
        '
        Me.tabSimpleA.Controls.Add(Me.txtSimpleSearchA)
        Me.tabSimpleA.Controls.Add(Me.Label30)
        Me.tabSimpleA.Location = New System.Drawing.Point(4, 29)
        Me.tabSimpleA.Name = "tabSimpleA"
        Me.tabSimpleA.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSimpleA.Size = New System.Drawing.Size(316, 73)
        Me.tabSimpleA.TabIndex = 1
        Me.tabSimpleA.Text = "       Simple       "
        Me.tabSimpleA.UseVisualStyleBackColor = True
        '
        'txtSimpleSearchA
        '
        Me.txtSimpleSearchA.Location = New System.Drawing.Point(96, 26)
        Me.txtSimpleSearchA.Name = "txtSimpleSearchA"
        Me.txtSimpleSearchA.Size = New System.Drawing.Size(212, 21)
        Me.txtSimpleSearchA.TabIndex = 5
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
        'tabCommonA
        '
        Me.tabCommonA.Controls.Add(Me.cboSearch4A)
        Me.tabCommonA.Controls.Add(Me.cboSearch2A)
        Me.tabCommonA.Controls.Add(Me.cboSearch3A)
        Me.tabCommonA.Controls.Add(Me.cboSearch1A)
        Me.tabCommonA.Location = New System.Drawing.Point(4, 29)
        Me.tabCommonA.Name = "tabCommonA"
        Me.tabCommonA.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCommonA.Size = New System.Drawing.Size(316, 73)
        Me.tabCommonA.TabIndex = 0
        Me.tabCommonA.Text = "       Common       "
        Me.tabCommonA.UseVisualStyleBackColor = True
        '
        'cboSearch4A
        '
        Me.cboSearch4A.FormattingEnabled = True
        Me.cboSearch4A.Location = New System.Drawing.Point(115, 39)
        Me.cboSearch4A.Name = "cboSearch4A"
        Me.cboSearch4A.Size = New System.Drawing.Size(191, 23)
        Me.cboSearch4A.TabIndex = 9
        '
        'cboSearch2A
        '
        Me.cboSearch2A.FormattingEnabled = True
        Me.cboSearch2A.Location = New System.Drawing.Point(115, 13)
        Me.cboSearch2A.Name = "cboSearch2A"
        Me.cboSearch2A.Size = New System.Drawing.Size(191, 23)
        Me.cboSearch2A.TabIndex = 7
        '
        'cboSearch3A
        '
        Me.cboSearch3A.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch3A.FormattingEnabled = True
        Me.cboSearch3A.Location = New System.Drawing.Point(8, 39)
        Me.cboSearch3A.Name = "cboSearch3A"
        Me.cboSearch3A.Size = New System.Drawing.Size(102, 23)
        Me.cboSearch3A.TabIndex = 8
        '
        'cboSearch1A
        '
        Me.cboSearch1A.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch1A.FormattingEnabled = True
        Me.cboSearch1A.Location = New System.Drawing.Point(8, 13)
        Me.cboSearch1A.Name = "cboSearch1A"
        Me.cboSearch1A.Size = New System.Drawing.Size(102, 23)
        Me.cboSearch1A.TabIndex = 6
        '
        'tabCustomersMain
        '
        Me.tabCustomersMain.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabCustomersMain.Controls.Add(Me.tabCustomerDetails)
        Me.tabCustomersMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCustomersMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabCustomersMain.ItemSize = New System.Drawing.Size(61, 23)
        Me.tabCustomersMain.Location = New System.Drawing.Point(0, 25)
        Me.tabCustomersMain.Multiline = True
        Me.tabCustomersMain.Name = "tabCustomersMain"
        Me.tabCustomersMain.SelectedIndex = 0
        Me.tabCustomersMain.Size = New System.Drawing.Size(821, 469)
        Me.tabCustomersMain.TabIndex = 223
        '
        'tabCustomerDetails
        '
        Me.tabCustomerDetails.AutoScroll = True
        Me.tabCustomerDetails.Controls.Add(Me.gbCustomerOrders)
        Me.tabCustomerDetails.Controls.Add(Me.gbCustomerInformation)
        Me.tabCustomerDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabCustomerDetails.Name = "tabCustomerDetails"
        Me.tabCustomerDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCustomerDetails.Size = New System.Drawing.Size(813, 438)
        Me.tabCustomerDetails.TabIndex = 0
        Me.tabCustomerDetails.Text = "Customer Details"
        Me.tabCustomerDetails.UseVisualStyleBackColor = True
        '
        'gbCustomerOrders
        '
        Me.gbCustomerOrders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbCustomerOrders.Controls.Add(Me.dgCustomerOrderItems)
        Me.gbCustomerOrders.Controls.Add(Me.Label9)
        Me.gbCustomerOrders.Controls.Add(Me.Label10)
        Me.gbCustomerOrders.Controls.Add(Me.dtpToSearch)
        Me.gbCustomerOrders.Controls.Add(Me.dtpFromSearch)
        Me.gbCustomerOrders.Controls.Add(Me.dgCustomerOrders)
        Me.gbCustomerOrders.Controls.Add(Me.Label15)
        Me.gbCustomerOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCustomerOrders.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCustomerOrders.Location = New System.Drawing.Point(8, 231)
        Me.gbCustomerOrders.Name = "gbCustomerOrders"
        Me.gbCustomerOrders.Size = New System.Drawing.Size(795, 198)
        Me.gbCustomerOrders.TabIndex = 4
        Me.gbCustomerOrders.TabStop = False
        '
        'dgCustomerOrderItems
        '
        Me.dgCustomerOrderItems.AllowUserToAddRows = False
        Me.dgCustomerOrderItems.AllowUserToDeleteRows = False
        Me.dgCustomerOrderItems.AllowUserToOrderColumns = True
        Me.dgCustomerOrderItems.AllowUserToResizeRows = False
        Me.dgCustomerOrderItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgCustomerOrderItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerOrderItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgCustomerOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomerOrderItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ci_rowid, Me.ci_colorvalue, Me.ci_seqno, Me.ci_productcode, Me.ci_colorname, Me.ci_color, Me.ci_size, Me.ci_seasoncode, Me.ci_unitofmeasure, Me.ci_qtyordered, Me.ci_qtydelivered, Me.ci_srp, Me.ci_totalprice, Me.ci_sku, Me.ci_type, Me.ci_remarks, Me.ci_status, Me.ci_verifiedby, Me.ci_verifieddate, Me.ci_packedby, Me.ci_packeddate, Me.ci_deliveredby, Me.ci_delivereddate})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCustomerOrderItems.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgCustomerOrderItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCustomerOrderItems.Location = New System.Drawing.Point(423, 19)
        Me.dgCustomerOrderItems.MultiSelect = False
        Me.dgCustomerOrderItems.Name = "dgCustomerOrderItems"
        Me.dgCustomerOrderItems.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerOrderItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgCustomerOrderItems.RowHeadersVisible = False
        Me.dgCustomerOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCustomerOrderItems.Size = New System.Drawing.Size(366, 170)
        Me.dgCustomerOrderItems.TabIndex = 33
        '
        'ci_rowid
        '
        Me.ci_rowid.HeaderText = "rowid"
        Me.ci_rowid.Name = "ci_rowid"
        Me.ci_rowid.ReadOnly = True
        Me.ci_rowid.Visible = False
        '
        'ci_colorvalue
        '
        Me.ci_colorvalue.HeaderText = "colorvalue"
        Me.ci_colorvalue.Name = "ci_colorvalue"
        Me.ci_colorvalue.ReadOnly = True
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
        Me.ci_unitofmeasure.ReadOnly = True
        Me.ci_unitofmeasure.Width = 70
        '
        'ci_qtyordered
        '
        Me.ci_qtyordered.HeaderText = "Qty. Ordered"
        Me.ci_qtyordered.Name = "ci_qtyordered"
        Me.ci_qtyordered.ReadOnly = True
        Me.ci_qtyordered.Width = 60
        '
        'ci_qtydelivered
        '
        Me.ci_qtydelivered.HeaderText = "Qty. Delivered"
        Me.ci_qtydelivered.Name = "ci_qtydelivered"
        Me.ci_qtydelivered.ReadOnly = True
        Me.ci_qtydelivered.Width = 60
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
        'ci_sku
        '
        Me.ci_sku.HeaderText = "SKU"
        Me.ci_sku.Name = "ci_sku"
        Me.ci_sku.ReadOnly = True
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(183, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 15)
        Me.Label9.TabIndex = 255
        Me.Label9.Text = "To:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(9, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 15)
        Me.Label10.TabIndex = 254
        Me.Label10.Text = "From:"
        '
        'dtpToSearch
        '
        Me.dtpToSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpToSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpToSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToSearch.Location = New System.Drawing.Point(213, 19)
        Me.dtpToSearch.Name = "dtpToSearch"
        Me.dtpToSearch.Size = New System.Drawing.Size(113, 21)
        Me.dtpToSearch.TabIndex = 31
        '
        'dtpFromSearch
        '
        Me.dtpFromSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpFromSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFromSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFromSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromSearch.Location = New System.Drawing.Point(54, 19)
        Me.dtpFromSearch.Name = "dtpFromSearch"
        Me.dtpFromSearch.Size = New System.Drawing.Size(113, 21)
        Me.dtpFromSearch.TabIndex = 30
        '
        'dgCustomerOrders
        '
        Me.dgCustomerOrders.AllowUserToAddRows = False
        Me.dgCustomerOrders.AllowUserToDeleteRows = False
        Me.dgCustomerOrders.AllowUserToOrderColumns = True
        Me.dgCustomerOrders.AllowUserToResizeRows = False
        Me.dgCustomerOrders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgCustomerOrders.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerOrders.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgCustomerOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomerOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.co_rowid, Me.co_seqno, Me.co_customerorderno, Me.co_pono, Me.co_customerorderdate, Me.co_status, Me.co_drnos})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCustomerOrders.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgCustomerOrders.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCustomerOrders.Location = New System.Drawing.Point(12, 46)
        Me.dgCustomerOrders.MultiSelect = False
        Me.dgCustomerOrders.Name = "dgCustomerOrders"
        Me.dgCustomerOrders.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerOrders.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgCustomerOrders.RowHeadersVisible = False
        Me.dgCustomerOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCustomerOrders.Size = New System.Drawing.Size(399, 143)
        Me.dgCustomerOrders.TabIndex = 32
        '
        'co_rowid
        '
        Me.co_rowid.HeaderText = "rowid"
        Me.co_rowid.Name = "co_rowid"
        Me.co_rowid.ReadOnly = True
        Me.co_rowid.Visible = False
        '
        'co_seqno
        '
        Me.co_seqno.HeaderText = "Seq. No."
        Me.co_seqno.Name = "co_seqno"
        Me.co_seqno.ReadOnly = True
        Me.co_seqno.Width = 50
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
        Me.co_pono.Width = 90
        '
        'co_customerorderdate
        '
        Me.co_customerorderdate.HeaderText = "Customer Order Date"
        Me.co_customerorderdate.Name = "co_customerorderdate"
        Me.co_customerorderdate.ReadOnly = True
        Me.co_customerorderdate.Width = 90
        '
        'co_status
        '
        Me.co_status.HeaderText = "Status"
        Me.co_status.Name = "co_status"
        Me.co_status.ReadOnly = True
        Me.co_status.Width = 90
        '
        'co_drnos
        '
        Me.co_drnos.HeaderText = "Line-Up No(s)."
        Me.co_drnos.Name = "co_drnos"
        Me.co_drnos.ReadOnly = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(9, -2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(202, 17)
        Me.Label15.TabIndex = 228
        Me.Label15.Text = "Customer Orders And Items:"
        '
        'gbCustomerInformation
        '
        Me.gbCustomerInformation.Controls.Add(Me.Label43)
        Me.gbCustomerInformation.Controls.Add(Me.cboAgent)
        Me.gbCustomerInformation.Controls.Add(Me.pbAutoAddA)
        Me.gbCustomerInformation.Controls.Add(Me.pbAddBranchCodeName)
        Me.gbCustomerInformation.Controls.Add(Me.cboBranchCodeNameInfo)
        Me.gbCustomerInformation.Controls.Add(Me.Label41)
        Me.gbCustomerInformation.Controls.Add(Me.txtDeliveryHours)
        Me.gbCustomerInformation.Controls.Add(Me.Label19)
        Me.gbCustomerInformation.Controls.Add(Me.cboPickingGroup)
        Me.gbCustomerInformation.Controls.Add(Me.Label18)
        Me.gbCustomerInformation.Controls.Add(Me.cboStatusA)
        Me.gbCustomerInformation.Controls.Add(Me.Label13)
        Me.gbCustomerInformation.Controls.Add(Me.Label12)
        Me.gbCustomerInformation.Controls.Add(Me.pbEditContactPersonA)
        Me.gbCustomerInformation.Controls.Add(Me.txtContactPersonA)
        Me.gbCustomerInformation.Controls.Add(Me.Label11)
        Me.gbCustomerInformation.Controls.Add(Me.txtTINA)
        Me.gbCustomerInformation.Controls.Add(Me.Label31)
        Me.gbCustomerInformation.Controls.Add(Me.Label40)
        Me.gbCustomerInformation.Controls.Add(Me.Label8)
        Me.gbCustomerInformation.Controls.Add(Me.txtCommentsA)
        Me.gbCustomerInformation.Controls.Add(Me.txtWebsiteA)
        Me.gbCustomerInformation.Controls.Add(Me.Label7)
        Me.gbCustomerInformation.Controls.Add(Me.txtEmailAddressA)
        Me.gbCustomerInformation.Controls.Add(Me.pbEditDeliveryAddress)
        Me.gbCustomerInformation.Controls.Add(Me.Label2)
        Me.gbCustomerInformation.Controls.Add(Me.Label6)
        Me.gbCustomerInformation.Controls.Add(Me.Label5)
        Me.gbCustomerInformation.Controls.Add(Me.txtFaxNoA)
        Me.gbCustomerInformation.Controls.Add(Me.txtCustomerName)
        Me.gbCustomerInformation.Controls.Add(Me.cboParentCustomer)
        Me.gbCustomerInformation.Controls.Add(Me.Label3)
        Me.gbCustomerInformation.Controls.Add(Me.txtAlternatePhoneA)
        Me.gbCustomerInformation.Controls.Add(Me.txtDeliveryAddressA)
        Me.gbCustomerInformation.Controls.Add(Me.Label1)
        Me.gbCustomerInformation.Controls.Add(Me.Label17)
        Me.gbCustomerInformation.Controls.Add(Me.txtCustomerNo)
        Me.gbCustomerInformation.Controls.Add(Me.Label52)
        Me.gbCustomerInformation.Controls.Add(Me.Label55)
        Me.gbCustomerInformation.Controls.Add(Me.Label42)
        Me.gbCustomerInformation.Controls.Add(Me.txtMainPhoneA)
        Me.gbCustomerInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCustomerInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCustomerInformation.Location = New System.Drawing.Point(8, 5)
        Me.gbCustomerInformation.Name = "gbCustomerInformation"
        Me.gbCustomerInformation.Size = New System.Drawing.Size(795, 220)
        Me.gbCustomerInformation.TabIndex = 3
        Me.gbCustomerInformation.TabStop = False
        '
        'pbAutoAddA
        '
        Me.pbAutoAddA.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddA.Image = CType(resources.GetObject("pbAutoAddA.Image"), System.Drawing.Image)
        Me.pbAutoAddA.Location = New System.Drawing.Point(365, 162)
        Me.pbAutoAddA.Name = "pbAutoAddA"
        Me.pbAutoAddA.Size = New System.Drawing.Size(14, 18)
        Me.pbAutoAddA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddA.TabIndex = 533
        Me.pbAutoAddA.TabStop = False
        Me.pbAutoAddA.Tag = ""
        '
        'pbAddBranchCodeName
        '
        Me.pbAddBranchCodeName.BackColor = System.Drawing.Color.Transparent
        Me.pbAddBranchCodeName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddBranchCodeName.Image = CType(resources.GetObject("pbAddBranchCodeName.Image"), System.Drawing.Image)
        Me.pbAddBranchCodeName.Location = New System.Drawing.Point(365, 189)
        Me.pbAddBranchCodeName.Name = "pbAddBranchCodeName"
        Me.pbAddBranchCodeName.Size = New System.Drawing.Size(14, 18)
        Me.pbAddBranchCodeName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddBranchCodeName.TabIndex = 436
        Me.pbAddBranchCodeName.TabStop = False
        Me.pbAddBranchCodeName.Tag = ""
        '
        'cboBranchCodeNameInfo
        '
        Me.cboBranchCodeNameInfo.BackColor = System.Drawing.SystemColors.Window
        Me.cboBranchCodeNameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranchCodeNameInfo.FormattingEnabled = True
        Me.cboBranchCodeNameInfo.Location = New System.Drawing.Point(155, 187)
        Me.cboBranchCodeNameInfo.Name = "cboBranchCodeNameInfo"
        Me.cboBranchCodeNameInfo.Size = New System.Drawing.Size(205, 23)
        Me.cboBranchCodeNameInfo.TabIndex = 21
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(6, 191)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(147, 15)
        Me.Label41.TabIndex = 422
        Me.Label41.Text = "Branch Code / Name Info:"
        '
        'txtDeliveryHours
        '
        Me.txtDeliveryHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryHours.Location = New System.Drawing.Point(408, 146)
        Me.txtDeliveryHours.Multiline = True
        Me.txtDeliveryHours.Name = "txtDeliveryHours"
        Me.txtDeliveryHours.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDeliveryHours.Size = New System.Drawing.Size(155, 64)
        Me.txtDeliveryHours.TabIndex = 28
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(442, 128)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 15)
        Me.Label19.TabIndex = 420
        Me.Label19.Text = "Delivery Hours:"
        '
        'cboPickingGroup
        '
        Me.cboPickingGroup.BackColor = System.Drawing.SystemColors.Window
        Me.cboPickingGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPickingGroup.FormattingEnabled = True
        Me.cboPickingGroup.Location = New System.Drawing.Point(250, 159)
        Me.cboPickingGroup.Name = "cboPickingGroup"
        Me.cboPickingGroup.Size = New System.Drawing.Size(110, 23)
        Me.cboPickingGroup.TabIndex = 20
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(155, 163)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 15)
        Me.Label18.TabIndex = 417
        Me.Label18.Text = "Pick List Group:"
        '
        'cboStatusA
        '
        Me.cboStatusA.BackColor = System.Drawing.SystemColors.Window
        Me.cboStatusA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatusA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatusA.FormattingEnabled = True
        Me.cboStatusA.Location = New System.Drawing.Point(65, 159)
        Me.cboStatusA.Name = "cboStatusA"
        Me.cboStatusA.Size = New System.Drawing.Size(85, 23)
        Me.cboStatusA.TabIndex = 19
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(47, 160)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 20)
        Me.Label13.TabIndex = 415
        Me.Label13.Text = "*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 163)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 414
        Me.Label12.Text = "Status:"
        '
        'pbEditContactPersonA
        '
        Me.pbEditContactPersonA.BackColor = System.Drawing.Color.Transparent
        Me.pbEditContactPersonA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEditContactPersonA.Image = CType(resources.GetObject("pbEditContactPersonA.Image"), System.Drawing.Image)
        Me.pbEditContactPersonA.Location = New System.Drawing.Point(361, 134)
        Me.pbEditContactPersonA.Name = "pbEditContactPersonA"
        Me.pbEditContactPersonA.Size = New System.Drawing.Size(19, 19)
        Me.pbEditContactPersonA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbEditContactPersonA.TabIndex = 413
        Me.pbEditContactPersonA.TabStop = False
        Me.pbEditContactPersonA.Tag = ""
        '
        'txtContactPersonA
        '
        Me.txtContactPersonA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactPersonA.Location = New System.Drawing.Point(126, 133)
        Me.txtContactPersonA.Name = "txtContactPersonA"
        Me.txtContactPersonA.ReadOnly = True
        Me.txtContactPersonA.Size = New System.Drawing.Size(229, 21)
        Me.txtContactPersonA.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(6, 136)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 15)
        Me.Label11.TabIndex = 412
        Me.Label11.Text = "Contact Person:"
        '
        'txtTINA
        '
        Me.txtTINA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTINA.Location = New System.Drawing.Point(446, 106)
        Me.txtTINA.Mask = "000-000-000-000"
        Me.txtTINA.Name = "txtTINA"
        Me.txtTINA.Size = New System.Drawing.Size(117, 21)
        Me.txtTINA.TabIndex = 26
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(405, 107)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(38, 15)
        Me.Label31.TabIndex = 406
        Me.Label31.Text = "T.I.N.:"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(640, 128)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(70, 15)
        Me.Label40.TabIndex = 294
        Me.Label40.Text = "Comments:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(567, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 15)
        Me.Label8.TabIndex = 314
        Me.Label8.Text = "Website:"
        '
        'txtCommentsA
        '
        Me.txtCommentsA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommentsA.Location = New System.Drawing.Point(569, 146)
        Me.txtCommentsA.Multiline = True
        Me.txtCommentsA.Name = "txtCommentsA"
        Me.txtCommentsA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCommentsA.Size = New System.Drawing.Size(205, 64)
        Me.txtCommentsA.TabIndex = 29
        '
        'txtWebsiteA
        '
        Me.txtWebsiteA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWebsiteA.Location = New System.Drawing.Point(627, 49)
        Me.txtWebsiteA.Name = "txtWebsiteA"
        Me.txtWebsiteA.Size = New System.Drawing.Size(147, 21)
        Me.txtWebsiteA.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(569, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 15)
        Me.Label7.TabIndex = 312
        Me.Label7.Text = "Email Address:"
        '
        'txtEmailAddressA
        '
        Me.txtEmailAddressA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailAddressA.Location = New System.Drawing.Point(658, 106)
        Me.txtEmailAddressA.Name = "txtEmailAddressA"
        Me.txtEmailAddressA.Size = New System.Drawing.Size(116, 21)
        Me.txtEmailAddressA.TabIndex = 27
        '
        'pbEditDeliveryAddress
        '
        Me.pbEditDeliveryAddress.BackColor = System.Drawing.Color.Transparent
        Me.pbEditDeliveryAddress.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEditDeliveryAddress.Image = CType(resources.GetObject("pbEditDeliveryAddress.Image"), System.Drawing.Image)
        Me.pbEditDeliveryAddress.Location = New System.Drawing.Point(755, 24)
        Me.pbEditDeliveryAddress.Name = "pbEditDeliveryAddress"
        Me.pbEditDeliveryAddress.Size = New System.Drawing.Size(19, 19)
        Me.pbEditDeliveryAddress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbEditDeliveryAddress.TabIndex = 224
        Me.pbEditDeliveryAddress.TabStop = False
        Me.pbEditDeliveryAddress.Tag = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(405, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 304
        Me.Label2.Text = "Fax No.:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(107, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 20)
        Me.Label6.TabIndex = 310
        Me.Label6.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(6, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 15)
        Me.Label5.TabIndex = 309
        Me.Label5.Text = "Parent Customer:"
        '
        'txtFaxNoA
        '
        Me.txtFaxNoA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaxNoA.Location = New System.Drawing.Point(459, 77)
        Me.txtFaxNoA.Name = "txtFaxNoA"
        Me.txtFaxNoA.Size = New System.Drawing.Size(104, 21)
        Me.txtFaxNoA.TabIndex = 24
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(126, 50)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(254, 21)
        Me.txtCustomerName.TabIndex = 15
        '
        'cboParentCustomer
        '
        Me.cboParentCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cboParentCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboParentCustomer.FormattingEnabled = True
        Me.cboParentCustomer.Location = New System.Drawing.Point(126, 77)
        Me.cboParentCustomer.Name = "cboParentCustomer"
        Me.cboParentCustomer.Size = New System.Drawing.Size(254, 23)
        Me.cboParentCustomer.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(302, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 15)
        Me.Label3.TabIndex = 306
        Me.Label3.Text = "Delivery Address:"
        '
        'txtAlternatePhoneA
        '
        Me.txtAlternatePhoneA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlternatePhoneA.Location = New System.Drawing.Point(669, 77)
        Me.txtAlternatePhoneA.Name = "txtAlternatePhoneA"
        Me.txtAlternatePhoneA.Size = New System.Drawing.Size(105, 21)
        Me.txtAlternatePhoneA.TabIndex = 25
        '
        'txtDeliveryAddressA
        '
        Me.txtDeliveryAddressA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryAddressA.Location = New System.Drawing.Point(408, 23)
        Me.txtDeliveryAddressA.Name = "txtDeliveryAddressA"
        Me.txtDeliveryAddressA.ReadOnly = True
        Me.txtDeliveryAddressA.Size = New System.Drawing.Size(341, 21)
        Me.txtDeliveryAddressA.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 15)
        Me.Label1.TabIndex = 306
        Me.Label1.Text = "Customer No.:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(569, 80)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 15)
        Me.Label17.TabIndex = 296
        Me.Label17.Text = "Alternate Phone:"
        '
        'txtCustomerNo
        '
        Me.txtCustomerNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerNo.Location = New System.Drawing.Point(126, 23)
        Me.txtCustomerNo.Name = "txtCustomerNo"
        Me.txtCustomerNo.ReadOnly = True
        Me.txtCustomerNo.Size = New System.Drawing.Size(125, 21)
        Me.txtCustomerNo.TabIndex = 14
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(6, 53)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(100, 15)
        Me.Label52.TabIndex = 272
        Me.Label52.Text = "Customer Name:"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.White
        Me.Label55.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label55.Location = New System.Drawing.Point(9, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(166, 17)
        Me.Label55.TabIndex = 228
        Me.Label55.Text = "Customer Information:"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(6, 109)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(77, 15)
        Me.Label42.TabIndex = 292
        Me.Label42.Text = "Main Phone:"
        '
        'txtMainPhoneA
        '
        Me.txtMainPhoneA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMainPhoneA.Location = New System.Drawing.Point(126, 106)
        Me.txtMainPhoneA.Name = "txtMainPhoneA"
        Me.txtMainPhoneA.Size = New System.Drawing.Size(254, 21)
        Me.txtMainPhoneA.TabIndex = 17
        '
        'msMenuA
        '
        Me.msMenuA.BackColor = System.Drawing.Color.Transparent
        Me.msMenuA.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenuA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msNewA, Me.msSaveA, Me.msCancelA})
        Me.msMenuA.Location = New System.Drawing.Point(0, 0)
        Me.msMenuA.Name = "msMenuA"
        Me.msMenuA.Size = New System.Drawing.Size(821, 25)
        Me.msMenuA.TabIndex = 315
        '
        'msNewA
        '
        Me.msNewA.Image = CType(resources.GetObject("msNewA.Image"), System.Drawing.Image)
        Me.msNewA.Name = "msNewA"
        Me.msNewA.Size = New System.Drawing.Size(63, 21)
        Me.msNewA.Text = "&New"
        '
        'msSaveA
        '
        Me.msSaveA.Image = CType(resources.GetObject("msSaveA.Image"), System.Drawing.Image)
        Me.msSaveA.Name = "msSaveA"
        Me.msSaveA.Size = New System.Drawing.Size(64, 21)
        Me.msSaveA.Text = "&Save"
        '
        'msCancelA
        '
        Me.msCancelA.Image = CType(resources.GetObject("msCancelA.Image"), System.Drawing.Image)
        Me.msCancelA.Name = "msCancelA"
        Me.msCancelA.Size = New System.Drawing.Size(76, 21)
        Me.msCancelA.Text = "&Cancel"
        '
        'lblsavemsgA
        '
        Me.lblsavemsgA.AutoSize = True
        Me.lblsavemsgA.Location = New System.Drawing.Point(81, 5)
        Me.lblsavemsgA.Name = "lblsavemsgA"
        Me.lblsavemsgA.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsgA.TabIndex = 193
        '
        'tabSuppliers
        '
        Me.tabSuppliers.Controls.Add(Me.SplitContainer2)
        Me.tabSuppliers.Location = New System.Drawing.Point(4, 4)
        Me.tabSuppliers.Name = "tabSuppliers"
        Me.tabSuppliers.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSuppliers.Size = New System.Drawing.Size(1192, 504)
        Me.tabSuppliers.TabIndex = 1
        Me.tabSuppliers.Text = "Suppliers"
        Me.tabSuppliers.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.AutoScroll = True
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.SplitContainer2.Panel1.Controls.Add(Me.gbSupplierList)
        Me.SplitContainer2.Panel1.Controls.Add(Me.gbSearch)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.AutoScroll = True
        Me.SplitContainer2.Panel2.Controls.Add(Me.tabMain)
        Me.SplitContainer2.Panel2.Controls.Add(Me.msMenu)
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblsavemsg)
        Me.SplitContainer2.Size = New System.Drawing.Size(1186, 498)
        Me.SplitContainer2.SplitterDistance = 357
        Me.SplitContainer2.TabIndex = 234
        '
        'gbSupplierList
        '
        Me.gbSupplierList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbSupplierList.BackColor = System.Drawing.Color.Transparent
        Me.gbSupplierList.Controls.Add(Me.Label14)
        Me.gbSupplierList.Controls.Add(Me.txtPage)
        Me.gbSupplierList.Controls.Add(Me.txtPageNo)
        Me.gbSupplierList.Controls.Add(Me.ToolStrip3)
        Me.gbSupplierList.Controls.Add(Me.dgSuppliersList)
        Me.gbSupplierList.Controls.Add(Me.Label20)
        Me.gbSupplierList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSupplierList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSupplierList.Location = New System.Drawing.Point(6, 152)
        Me.gbSupplierList.Name = "gbSupplierList"
        Me.gbSupplierList.Size = New System.Drawing.Size(340, 335)
        Me.gbSupplierList.TabIndex = 2
        Me.gbSupplierList.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(50, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 15)
        Me.Label14.TabIndex = 297
        Me.Label14.Text = "Page No.:"
        '
        'txtPage
        '
        Me.txtPage.Location = New System.Drawing.Point(228, 43)
        Me.txtPage.Name = "txtPage"
        Me.txtPage.Size = New System.Drawing.Size(41, 21)
        Me.txtPage.TabIndex = 12
        '
        'txtPageNo
        '
        Me.txtPageNo.Location = New System.Drawing.Point(121, 43)
        Me.txtPageNo.Name = "txtPageNo"
        Me.txtPageNo.ReadOnly = True
        Me.txtPageNo.Size = New System.Drawing.Size(101, 21)
        Me.txtPageNo.TabIndex = 11
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
        Me.ToolStrip3.TabIndex = 10
        Me.ToolStrip3.Text = "toolbar1"
        '
        'cmdFirst
        '
        Me.cmdFirst.BackColor = System.Drawing.Color.White
        Me.cmdFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdFirst.Image = CType(resources.GetObject("cmdFirst.Image"), System.Drawing.Image)
        Me.cmdFirst.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(24, 19)
        Me.cmdFirst.Text = "First"
        '
        'cmdPrev
        '
        Me.cmdPrev.BackColor = System.Drawing.Color.White
        Me.cmdPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPrev.Image = CType(resources.GetObject("cmdPrev.Image"), System.Drawing.Image)
        Me.cmdPrev.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdPrev.Name = "cmdPrev"
        Me.cmdPrev.Size = New System.Drawing.Size(24, 19)
        Me.cmdPrev.Text = "Previous"
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.White
        Me.cmdNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdNext.Image = CType(resources.GetObject("cmdNext.Image"), System.Drawing.Image)
        Me.cmdNext.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(24, 19)
        Me.cmdNext.Text = "Next"
        '
        'cmdLast
        '
        Me.cmdLast.BackColor = System.Drawing.Color.White
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
        Me.tsRefresh.ForeColor = System.Drawing.Color.White
        Me.tsRefresh.Image = CType(resources.GetObject("tsRefresh.Image"), System.Drawing.Image)
        Me.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRefresh.Name = "tsRefresh"
        Me.tsRefresh.Size = New System.Drawing.Size(78, 19)
        Me.tsRefresh.Text = "&Refresh"
        '
        'dgSuppliersList
        '
        Me.dgSuppliersList.AllowUserToAddRows = False
        Me.dgSuppliersList.AllowUserToDeleteRows = False
        Me.dgSuppliersList.AllowUserToOrderColumns = True
        Me.dgSuppliersList.AllowUserToResizeRows = False
        Me.dgSuppliersList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgSuppliersList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSuppliersList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgSuppliersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSuppliersList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.s_rowid, Me.s_supplierno, Me.s_suppliername, Me.s_mainphone})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSuppliersList.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgSuppliersList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgSuppliersList.Location = New System.Drawing.Point(8, 69)
        Me.dgSuppliersList.MultiSelect = False
        Me.dgSuppliersList.Name = "dgSuppliersList"
        Me.dgSuppliersList.ReadOnly = True
        Me.dgSuppliersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSuppliersList.Size = New System.Drawing.Size(325, 260)
        Me.dgSuppliersList.TabIndex = 13
        '
        's_rowid
        '
        Me.s_rowid.HeaderText = "rowid"
        Me.s_rowid.Name = "s_rowid"
        Me.s_rowid.ReadOnly = True
        Me.s_rowid.Visible = False
        '
        's_supplierno
        '
        Me.s_supplierno.HeaderText = "Supplier No."
        Me.s_supplierno.Name = "s_supplierno"
        Me.s_supplierno.ReadOnly = True
        Me.s_supplierno.Width = 60
        '
        's_suppliername
        '
        Me.s_suppliername.HeaderText = "Supplier Name"
        Me.s_suppliername.Name = "s_suppliername"
        Me.s_suppliername.ReadOnly = True
        '
        's_mainphone
        '
        Me.s_mainphone.HeaderText = "Main Phone"
        Me.s_mainphone.Name = "s_mainphone"
        Me.s_mainphone.ReadOnly = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.Label20.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(6, -1)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 17)
        Me.Label20.TabIndex = 216
        Me.Label20.Text = "Supplier List:"
        '
        'gbSearch
        '
        Me.gbSearch.BackColor = System.Drawing.Color.Transparent
        Me.gbSearch.Controls.Add(Me.Label22)
        Me.gbSearch.Controls.Add(Me.tabSearch)
        Me.gbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSearch.Location = New System.Drawing.Point(6, 5)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(340, 140)
        Me.gbSearch.TabIndex = 1
        Me.gbSearch.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.Label22.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(6, -2)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(59, 17)
        Me.Label22.TabIndex = 217
        Me.Label22.Text = "Search:"
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
        Me.tabSimple.Controls.Add(Me.Label23)
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
        Me.txtSimpleSearch.TabIndex = 5
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(2, 28)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(91, 15)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "Search Phrase:"
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
        Me.cboSearch4.TabIndex = 9
        '
        'cboSearch2
        '
        Me.cboSearch2.FormattingEnabled = True
        Me.cboSearch2.Location = New System.Drawing.Point(115, 13)
        Me.cboSearch2.Name = "cboSearch2"
        Me.cboSearch2.Size = New System.Drawing.Size(191, 23)
        Me.cboSearch2.TabIndex = 7
        '
        'cboSearch3
        '
        Me.cboSearch3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch3.FormattingEnabled = True
        Me.cboSearch3.Location = New System.Drawing.Point(8, 39)
        Me.cboSearch3.Name = "cboSearch3"
        Me.cboSearch3.Size = New System.Drawing.Size(102, 23)
        Me.cboSearch3.TabIndex = 8
        '
        'cboSearch1
        '
        Me.cboSearch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch1.FormattingEnabled = True
        Me.cboSearch1.Location = New System.Drawing.Point(8, 13)
        Me.cboSearch1.Name = "cboSearch1"
        Me.cboSearch1.Size = New System.Drawing.Size(102, 23)
        Me.cboSearch1.TabIndex = 6
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
        Me.tabMain.Size = New System.Drawing.Size(821, 469)
        Me.tabMain.TabIndex = 223
        '
        'tabDetails
        '
        Me.tabDetails.AutoScroll = True
        Me.tabDetails.Controls.Add(Me.gbSupplierInformation)
        Me.tabDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(813, 438)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Supplier Details"
        Me.tabDetails.UseVisualStyleBackColor = True
        '
        'gbSupplierInformation
        '
        Me.gbSupplierInformation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbSupplierInformation.Controls.Add(Me.cboStatus)
        Me.gbSupplierInformation.Controls.Add(Me.Label24)
        Me.gbSupplierInformation.Controls.Add(Me.Label25)
        Me.gbSupplierInformation.Controls.Add(Me.pbEditContactPerson)
        Me.gbSupplierInformation.Controls.Add(Me.txtContactPerson)
        Me.gbSupplierInformation.Controls.Add(Me.Label26)
        Me.gbSupplierInformation.Controls.Add(Me.txtTIN)
        Me.gbSupplierInformation.Controls.Add(Me.Label27)
        Me.gbSupplierInformation.Controls.Add(Me.Label28)
        Me.gbSupplierInformation.Controls.Add(Me.Label29)
        Me.gbSupplierInformation.Controls.Add(Me.txtComments)
        Me.gbSupplierInformation.Controls.Add(Me.txtWebsite)
        Me.gbSupplierInformation.Controls.Add(Me.Label32)
        Me.gbSupplierInformation.Controls.Add(Me.txtEmailAddress)
        Me.gbSupplierInformation.Controls.Add(Me.Label33)
        Me.gbSupplierInformation.Controls.Add(Me.Label34)
        Me.gbSupplierInformation.Controls.Add(Me.txtFaxNo)
        Me.gbSupplierInformation.Controls.Add(Me.txtSupplierName)
        Me.gbSupplierInformation.Controls.Add(Me.txtAlternatePhone)
        Me.gbSupplierInformation.Controls.Add(Me.Label35)
        Me.gbSupplierInformation.Controls.Add(Me.Label36)
        Me.gbSupplierInformation.Controls.Add(Me.txtSupplierNo)
        Me.gbSupplierInformation.Controls.Add(Me.Label37)
        Me.gbSupplierInformation.Controls.Add(Me.Label38)
        Me.gbSupplierInformation.Controls.Add(Me.Label39)
        Me.gbSupplierInformation.Controls.Add(Me.txtMainPhone)
        Me.gbSupplierInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSupplierInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSupplierInformation.Location = New System.Drawing.Point(10, 7)
        Me.gbSupplierInformation.Name = "gbSupplierInformation"
        Me.gbSupplierInformation.Size = New System.Drawing.Size(790, 420)
        Me.gbSupplierInformation.TabIndex = 3
        Me.gbSupplierInformation.TabStop = False
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(296, 176)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(98, 23)
        Me.cboStatus.TabIndex = 18
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Red
        Me.Label24.Location = New System.Drawing.Point(279, 177)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(16, 20)
        Me.Label24.TabIndex = 415
        Me.Label24.Text = "*"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(176, 179)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(44, 15)
        Me.Label25.TabIndex = 414
        Me.Label25.Text = "Status:"
        '
        'pbEditContactPerson
        '
        Me.pbEditContactPerson.BackColor = System.Drawing.Color.Transparent
        Me.pbEditContactPerson.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEditContactPerson.Image = CType(resources.GetObject("pbEditContactPerson.Image"), System.Drawing.Image)
        Me.pbEditContactPerson.Location = New System.Drawing.Point(593, 149)
        Me.pbEditContactPerson.Name = "pbEditContactPerson"
        Me.pbEditContactPerson.Size = New System.Drawing.Size(19, 19)
        Me.pbEditContactPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbEditContactPerson.TabIndex = 413
        Me.pbEditContactPerson.TabStop = False
        Me.pbEditContactPerson.Tag = ""
        '
        'txtContactPerson
        '
        Me.txtContactPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactPerson.Location = New System.Drawing.Point(296, 148)
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.ReadOnly = True
        Me.txtContactPerson.Size = New System.Drawing.Size(291, 21)
        Me.txtContactPerson.TabIndex = 17
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(176, 151)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(93, 15)
        Me.Label26.TabIndex = 412
        Me.Label26.Text = "Contact Person:"
        '
        'txtTIN
        '
        Me.txtTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTIN.Location = New System.Drawing.Point(296, 259)
        Me.txtTIN.Mask = "000-000-000-000"
        Me.txtTIN.Name = "txtTIN"
        Me.txtTIN.Size = New System.Drawing.Size(104, 21)
        Me.txtTIN.TabIndex = 22
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(176, 256)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(38, 15)
        Me.Label27.TabIndex = 406
        Me.Label27.Text = "T.I.N.:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(176, 284)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(70, 15)
        Me.Label28.TabIndex = 294
        Me.Label28.Text = "Comments:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(176, 205)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(54, 15)
        Me.Label29.TabIndex = 314
        Me.Label29.Text = "Website:"
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(296, 286)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(316, 49)
        Me.txtComments.TabIndex = 24
        '
        'txtWebsite
        '
        Me.txtWebsite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWebsite.Location = New System.Drawing.Point(296, 205)
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.Size = New System.Drawing.Size(316, 21)
        Me.txtWebsite.TabIndex = 19
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(406, 260)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(89, 15)
        Me.Label32.TabIndex = 312
        Me.Label32.Text = "Email Address:"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailAddress.Location = New System.Drawing.Point(506, 259)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(106, 21)
        Me.txtEmailAddress.TabIndex = 23
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(176, 231)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(52, 15)
        Me.Label33.TabIndex = 304
        Me.Label33.Text = "Fax No.:"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Red
        Me.Label34.Location = New System.Drawing.Point(277, 92)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(16, 20)
        Me.Label34.TabIndex = 310
        Me.Label34.Text = "*"
        '
        'txtFaxNo
        '
        Me.txtFaxNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaxNo.Location = New System.Drawing.Point(296, 232)
        Me.txtFaxNo.Name = "txtFaxNo"
        Me.txtFaxNo.Size = New System.Drawing.Size(104, 21)
        Me.txtFaxNo.TabIndex = 20
        '
        'txtSupplierName
        '
        Me.txtSupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplierName.Location = New System.Drawing.Point(296, 94)
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.Size = New System.Drawing.Size(316, 21)
        Me.txtSupplierName.TabIndex = 15
        '
        'txtAlternatePhone
        '
        Me.txtAlternatePhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlternatePhone.Location = New System.Drawing.Point(506, 232)
        Me.txtAlternatePhone.Name = "txtAlternatePhone"
        Me.txtAlternatePhone.Size = New System.Drawing.Size(106, 21)
        Me.txtAlternatePhone.TabIndex = 21
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(176, 70)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(78, 15)
        Me.Label35.TabIndex = 306
        Me.Label35.Text = "Supplier No.:"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(406, 235)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(97, 15)
        Me.Label36.TabIndex = 296
        Me.Label36.Text = "Alternate Phone:"
        '
        'txtSupplierNo
        '
        Me.txtSupplierNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplierNo.Location = New System.Drawing.Point(296, 67)
        Me.txtSupplierNo.Name = "txtSupplierNo"
        Me.txtSupplierNo.ReadOnly = True
        Me.txtSupplierNo.Size = New System.Drawing.Size(125, 21)
        Me.txtSupplierNo.TabIndex = 14
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(176, 97)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(93, 15)
        Me.Label37.TabIndex = 272
        Me.Label37.Text = "Supplier Name:"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.White
        Me.Label38.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label38.Location = New System.Drawing.Point(9, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(159, 17)
        Me.Label38.TabIndex = 228
        Me.Label38.Text = "Supplier Information:"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(176, 124)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(77, 15)
        Me.Label39.TabIndex = 292
        Me.Label39.Text = "Main Phone:"
        '
        'txtMainPhone
        '
        Me.txtMainPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMainPhone.Location = New System.Drawing.Point(296, 121)
        Me.txtMainPhone.Name = "txtMainPhone"
        Me.txtMainPhone.Size = New System.Drawing.Size(316, 21)
        Me.txtMainPhone.TabIndex = 16
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msNew, Me.msSave, Me.msCancel})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(821, 25)
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
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(403, 53)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(41, 15)
        Me.Label43.TabIndex = 535
        Me.Label43.Text = "Agent:"
        '
        'cboAgent
        '
        Me.cboAgent.BackColor = System.Drawing.SystemColors.Window
        Me.cboAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAgent.FormattingEnabled = True
        Me.cboAgent.Location = New System.Drawing.Point(445, 47)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Size = New System.Drawing.Size(118, 23)
        Me.cboAgent.TabIndex = 534
        '
        'AccountsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 560)
        Me.Controls.Add(Me.tabAccounts)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AccountsForm"
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAccounts.ResumeLayout(False)
        Me.tabCustomers.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbCustomerList.ResumeLayout(False)
        Me.gbCustomerList.PerformLayout()
        Me.tsMenuA.ResumeLayout(False)
        Me.tsMenuA.PerformLayout()
        CType(Me.dgCustomerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSearchA.ResumeLayout(False)
        Me.gbSearchA.PerformLayout()
        Me.tabSearchA.ResumeLayout(False)
        Me.tabSimpleA.ResumeLayout(False)
        Me.tabSimpleA.PerformLayout()
        Me.tabCommonA.ResumeLayout(False)
        Me.tabCustomersMain.ResumeLayout(False)
        Me.tabCustomerDetails.ResumeLayout(False)
        Me.gbCustomerOrders.ResumeLayout(False)
        Me.gbCustomerOrders.PerformLayout()
        CType(Me.dgCustomerOrderItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCustomerOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCustomerInformation.ResumeLayout(False)
        Me.gbCustomerInformation.PerformLayout()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddBranchCodeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEditContactPersonA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEditDeliveryAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msMenuA.ResumeLayout(False)
        Me.msMenuA.PerformLayout()
        Me.tabSuppliers.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.gbSupplierList.ResumeLayout(False)
        Me.gbSupplierList.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.dgSuppliersList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.tabSearch.ResumeLayout(False)
        Me.tabSimple.ResumeLayout(False)
        Me.tabSimple.PerformLayout()
        Me.tabCommon.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.gbSupplierInformation.ResumeLayout(False)
        Me.gbSupplierInformation.PerformLayout()
        CType(Me.pbEditContactPerson, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents tabAccounts As System.Windows.Forms.TabControl
    Friend WithEvents tabCustomers As System.Windows.Forms.TabPage
    Friend WithEvents tabSuppliers As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbCustomerList As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPageA As System.Windows.Forms.TextBox
    Friend WithEvents txtPageNoA As System.Windows.Forms.TextBox
    Friend WithEvents tsMenuA As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdFirstA As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrevA As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNextA As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLastA As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefreshA As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgCustomerList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents gbSearchA As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tabSearchA As System.Windows.Forms.TabControl
    Friend WithEvents tabSimpleA As System.Windows.Forms.TabPage
    Friend WithEvents txtSimpleSearchA As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents tabCommonA As System.Windows.Forms.TabPage
    Friend WithEvents cboSearch4A As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch2A As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch3A As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch1A As System.Windows.Forms.ComboBox
    Friend WithEvents tabCustomersMain As System.Windows.Forms.TabControl
    Friend WithEvents tabCustomerDetails As System.Windows.Forms.TabPage
    Friend WithEvents gbCustomerOrders As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpToSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgCustomerOrders As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents gbCustomerInformation As System.Windows.Forms.GroupBox
    Friend WithEvents txtDeliveryHours As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboPickingGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboStatusA As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pbEditContactPersonA As System.Windows.Forms.PictureBox
    Friend WithEvents txtContactPersonA As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTINA As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCommentsA As System.Windows.Forms.TextBox
    Friend WithEvents txtWebsiteA As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddressA As System.Windows.Forms.TextBox
    Friend WithEvents pbEditDeliveryAddress As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFaxNoA As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents cboParentCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAlternatePhoneA As System.Windows.Forms.TextBox
    Friend WithEvents txtDeliveryAddressA As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerNo As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtMainPhoneA As System.Windows.Forms.TextBox
    Friend WithEvents msMenuA As System.Windows.Forms.MenuStrip
    Friend WithEvents msNewA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msSaveA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msCancelA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsavemsgA As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbSupplierList As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPage As System.Windows.Forms.TextBox
    Friend WithEvents txtPageNo As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgSuppliersList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents s_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_supplierno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_suppliername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_mainphone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tabSearch As System.Windows.Forms.TabControl
    Friend WithEvents tabSimple As System.Windows.Forms.TabPage
    Friend WithEvents txtSimpleSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents tabCommon As System.Windows.Forms.TabPage
    Friend WithEvents cboSearch4 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch1 As System.Windows.Forms.ComboBox
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents gbSupplierInformation As System.Windows.Forms.GroupBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents pbEditContactPerson As System.Windows.Forms.PictureBox
    Friend WithEvents txtContactPerson As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtTIN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtWebsite As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtFaxNo As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents txtAlternatePhone As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtSupplierNo As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtMainPhone As System.Windows.Forms.TextBox
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents cboBranchCodeNameInfo As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents pbAddBranchCodeName As System.Windows.Forms.PictureBox
    Friend WithEvents dgCustomerOrderItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ci_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtyordered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtydelivered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_srp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_totalprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_verifiedby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_verifieddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_packedby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_packeddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_deliveredby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_delivereddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents co_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents co_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents co_customerorderno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents co_pono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents co_customerorderdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents co_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents co_drnos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbAutoAddA As System.Windows.Forms.PictureBox
    Friend WithEvents c_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_customerno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_customername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_mainphone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_parentcustomer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label43 As Label
    Friend WithEvents cboAgent As ComboBox
End Class
