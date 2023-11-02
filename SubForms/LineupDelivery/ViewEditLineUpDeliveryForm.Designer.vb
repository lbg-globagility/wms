<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewEditLineUpDeliveryForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewEditLineUpDeliveryForm))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dgLineUpList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.lu_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lu_lineupno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lu_deliveryno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lu_customerorderinfo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lu_deliverydate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.cmdLast = New System.Windows.Forms.ToolStripButton()
        Me.cmdNext = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrev = New System.Windows.Forms.ToolStripButton()
        Me.cmdFirst = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.gbLineUpList = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPage = New System.Windows.Forms.TextBox()
        Me.txtPageNo = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tabSearch = New System.Windows.Forms.TabControl()
        Me.tabSimple = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.gbCartons = New System.Windows.Forms.GroupBox()
        Me.dgCartons = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ca_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_packinglistcartonid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_cartonno = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.ca_cbm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_sizename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_packername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_packeddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_option = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.gbAddProductItem = New System.Windows.Forms.GroupBox()
        Me.txtSizeName = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtBoxCBM = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblCartonNoE = New System.Windows.Forms.Label()
        Me.cboCartonNo = New System.Windows.Forms.ComboBox()
        Me.btnAddCarton = New System.Windows.Forms.Button()
        Me.gbLineUpInformation = New System.Windows.Forms.GroupBox()
        Me.btnAddHelper2 = New System.Windows.Forms.PictureBox()
        Me.btnAddHelper1 = New System.Windows.Forms.PictureBox()
        Me.btnAddAgent = New System.Windows.Forms.PictureBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cboHelper2 = New System.Windows.Forms.ComboBox()
        Me.cboHelper1 = New System.Windows.Forms.ComboBox()
        Me.cboAgent = New System.Windows.Forms.ComboBox()
        Me.txtClassDescription = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtVendorCodeNameInfo = New System.Windows.Forms.TextBox()
        Me.txtBranchCodeNameInfo = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCBM = New System.Windows.Forms.TextBox()
        Me.txtCancelDate = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPONo = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtConfirmedDate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSIDRNo = New System.Windows.Forms.TextBox()
        Me.txtCustomerOrderInfo = New System.Windows.Forms.TextBox()
        Me.txtDeliveryHours = New System.Windows.Forms.TextBox()
        Me.txtReceiptDate = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pbAddDriver = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDeliveryAddress = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCustomerOrderDate = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.pbAddTruckShiftInfo = New System.Windows.Forms.PictureBox()
        Me.cboDriverName = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboTruckShiftInfo = New System.Windows.Forms.ComboBox()
        Me.dtpLineUpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtLineUpNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msToDeliver = New System.Windows.Forms.ToolStripMenuItem()
        Me.msOrder = New System.Windows.Forms.ToolStripMenuItem()
        Me.msPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.msConfirm = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblTitle = New System.Windows.Forms.Label()
        CType(Me.dgLineUpList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.gbLineUpList.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.tabSimple.SuspendLayout()
        Me.tabCommon.SuspendLayout()
        Me.gbCartons.SuspendLayout()
        CType(Me.dgCartons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAddProductItem.SuspendLayout()
        Me.gbLineUpInformation.SuspendLayout()
        CType(Me.btnAddHelper2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAddHelper1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAddAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddDriver, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddTruckShiftInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msMenu.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.GhostWhite
        Me.Label16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(6, -1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 17)
        Me.Label16.TabIndex = 216
        Me.Label16.Text = "Line-Up List:"
        '
        'dgLineUpList
        '
        Me.dgLineUpList.AllowUserToAddRows = False
        Me.dgLineUpList.AllowUserToDeleteRows = False
        Me.dgLineUpList.AllowUserToOrderColumns = True
        Me.dgLineUpList.AllowUserToResizeRows = False
        Me.dgLineUpList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgLineUpList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLineUpList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLineUpList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLineUpList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.lu_rowid, Me.lu_lineupno, Me.lu_deliveryno, Me.lu_customerorderinfo, Me.lu_deliverydate})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLineUpList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgLineUpList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgLineUpList.Location = New System.Drawing.Point(7, 68)
        Me.dgLineUpList.MultiSelect = False
        Me.dgLineUpList.Name = "dgLineUpList"
        Me.dgLineUpList.ReadOnly = True
        Me.dgLineUpList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLineUpList.Size = New System.Drawing.Size(325, 275)
        Me.dgLineUpList.TabIndex = 17
        '
        'lu_rowid
        '
        Me.lu_rowid.HeaderText = "rowid"
        Me.lu_rowid.Name = "lu_rowid"
        Me.lu_rowid.ReadOnly = True
        Me.lu_rowid.Visible = False
        '
        'lu_lineupno
        '
        Me.lu_lineupno.HeaderText = "Line-Up No."
        Me.lu_lineupno.Name = "lu_lineupno"
        Me.lu_lineupno.ReadOnly = True
        Me.lu_lineupno.Width = 80
        '
        'lu_deliveryno
        '
        Me.lu_deliveryno.HeaderText = "S.I./D.R. No."
        Me.lu_deliveryno.Name = "lu_deliveryno"
        Me.lu_deliveryno.ReadOnly = True
        Me.lu_deliveryno.Width = 80
        '
        'lu_customerorderinfo
        '
        Me.lu_customerorderinfo.HeaderText = "Customer Order Info."
        Me.lu_customerorderinfo.Name = "lu_customerorderinfo"
        Me.lu_customerorderinfo.ReadOnly = True
        '
        'lu_deliverydate
        '
        Me.lu_deliverydate.HeaderText = "Delivery Date"
        Me.lu_deliverydate.Name = "lu_deliverydate"
        Me.lu_deliverydate.ReadOnly = True
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
        Me.ToolStrip3.TabIndex = 14
        Me.ToolStrip3.Text = "toolbar1"
        '
        'gbLineUpList
        '
        Me.gbLineUpList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbLineUpList.BackColor = System.Drawing.Color.Transparent
        Me.gbLineUpList.Controls.Add(Me.Label4)
        Me.gbLineUpList.Controls.Add(Me.txtPage)
        Me.gbLineUpList.Controls.Add(Me.txtPageNo)
        Me.gbLineUpList.Controls.Add(Me.ToolStrip3)
        Me.gbLineUpList.Controls.Add(Me.dgLineUpList)
        Me.gbLineUpList.Controls.Add(Me.Label16)
        Me.gbLineUpList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLineUpList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbLineUpList.Location = New System.Drawing.Point(7, 177)
        Me.gbLineUpList.Name = "gbLineUpList"
        Me.gbLineUpList.Size = New System.Drawing.Size(340, 350)
        Me.gbLineUpList.TabIndex = 2
        Me.gbLineUpList.TabStop = False
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
        Me.txtPage.TabIndex = 16
        '
        'txtPageNo
        '
        Me.txtPageNo.Location = New System.Drawing.Point(121, 43)
        Me.txtPageNo.Name = "txtPageNo"
        Me.txtPageNo.ReadOnly = True
        Me.txtPageNo.Size = New System.Drawing.Size(101, 21)
        Me.txtPageNo.TabIndex = 15
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.GhostWhite
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbLineUpList)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbCartons)
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbLineUpInformation)
        Me.SplitContainer1.Panel2.Controls.Add(Me.msMenu)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblsavemsg)
        Me.SplitContainer1.Size = New System.Drawing.Size(984, 534)
        Me.SplitContainer1.SplitterDistance = 357
        Me.SplitContainer1.TabIndex = 236
        '
        'gbSearch
        '
        Me.gbSearch.BackColor = System.Drawing.Color.Transparent
        Me.gbSearch.Controls.Add(Me.Label21)
        Me.gbSearch.Controls.Add(Me.tabSearch)
        Me.gbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSearch.Location = New System.Drawing.Point(7, 6)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(340, 170)
        Me.gbSearch.TabIndex = 3
        Me.gbSearch.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.GhostWhite
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
        Me.tabSearch.TabIndex = 5
        '
        'tabSimple
        '
        Me.tabSimple.Controls.Add(Me.Button1)
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(96, 71)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtSimpleSearch
        '
        Me.txtSimpleSearch.Location = New System.Drawing.Point(96, 43)
        Me.txtSimpleSearch.Name = "txtSimpleSearch"
        Me.txtSimpleSearch.Size = New System.Drawing.Size(212, 21)
        Me.txtSimpleSearch.TabIndex = 6
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
        Me.dtpToSearch.TabIndex = 9
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
        Me.dtpFromSearch.TabIndex = 8
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
        Me.cboDate.TabIndex = 7
        '
        'cboSearch4
        '
        Me.cboSearch4.FormattingEnabled = True
        Me.cboSearch4.Location = New System.Drawing.Point(112, 80)
        Me.cboSearch4.Name = "cboSearch4"
        Me.cboSearch4.Size = New System.Drawing.Size(198, 23)
        Me.cboSearch4.TabIndex = 13
        '
        'cboSearch2
        '
        Me.cboSearch2.FormattingEnabled = True
        Me.cboSearch2.Location = New System.Drawing.Point(112, 51)
        Me.cboSearch2.Name = "cboSearch2"
        Me.cboSearch2.Size = New System.Drawing.Size(198, 23)
        Me.cboSearch2.TabIndex = 11
        '
        'cboSearch3
        '
        Me.cboSearch3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch3.FormattingEnabled = True
        Me.cboSearch3.Location = New System.Drawing.Point(3, 80)
        Me.cboSearch3.Name = "cboSearch3"
        Me.cboSearch3.Size = New System.Drawing.Size(105, 23)
        Me.cboSearch3.TabIndex = 12
        '
        'cboSearch1
        '
        Me.cboSearch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch1.FormattingEnabled = True
        Me.cboSearch1.Location = New System.Drawing.Point(3, 52)
        Me.cboSearch1.Name = "cboSearch1"
        Me.cboSearch1.Size = New System.Drawing.Size(105, 23)
        Me.cboSearch1.TabIndex = 10
        '
        'gbCartons
        '
        Me.gbCartons.Controls.Add(Me.dgCartons)
        Me.gbCartons.Controls.Add(Me.Label15)
        Me.gbCartons.Controls.Add(Me.gbAddProductItem)
        Me.gbCartons.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCartons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCartons.Location = New System.Drawing.Point(7, 371)
        Me.gbCartons.Name = "gbCartons"
        Me.gbCartons.Size = New System.Drawing.Size(605, 230)
        Me.gbCartons.TabIndex = 4
        Me.gbCartons.TabStop = False
        '
        'dgCartons
        '
        Me.dgCartons.AllowUserToAddRows = False
        Me.dgCartons.AllowUserToDeleteRows = False
        Me.dgCartons.AllowUserToOrderColumns = True
        Me.dgCartons.AllowUserToResizeRows = False
        Me.dgCartons.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartons.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgCartons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCartons.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ca_rowid, Me.ca_packinglistcartonid, Me.ca_seqno, Me.ca_cartonno, Me.ca_cbm, Me.ca_sizename, Me.ca_packername, Me.ca_status, Me.ca_packeddate, Me.ca_option})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCartons.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgCartons.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCartons.Location = New System.Drawing.Point(8, 51)
        Me.dgCartons.MultiSelect = False
        Me.dgCartons.Name = "dgCartons"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartons.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgCartons.RowHeadersVisible = False
        Me.dgCartons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCartons.Size = New System.Drawing.Size(589, 171)
        Me.dgCartons.TabIndex = 43
        '
        'ca_rowid
        '
        Me.ca_rowid.HeaderText = "rowid"
        Me.ca_rowid.Name = "ca_rowid"
        Me.ca_rowid.Visible = False
        '
        'ca_packinglistcartonid
        '
        Me.ca_packinglistcartonid.HeaderText = "packinglistcartonid"
        Me.ca_packinglistcartonid.Name = "ca_packinglistcartonid"
        Me.ca_packinglistcartonid.Visible = False
        '
        'ca_seqno
        '
        Me.ca_seqno.HeaderText = "Seq. No."
        Me.ca_seqno.Name = "ca_seqno"
        Me.ca_seqno.Width = 50
        '
        'ca_cartonno
        '
        Me.ca_cartonno.HeaderText = "Box No."
        Me.ca_cartonno.Name = "ca_cartonno"
        Me.ca_cartonno.ReadOnly = True
        Me.ca_cartonno.Width = 90
        '
        'ca_cbm
        '
        Me.ca_cbm.HeaderText = "CBM"
        Me.ca_cbm.Name = "ca_cbm"
        Me.ca_cbm.ReadOnly = True
        Me.ca_cbm.Width = 80
        '
        'ca_sizename
        '
        Me.ca_sizename.HeaderText = "Size Name"
        Me.ca_sizename.Name = "ca_sizename"
        Me.ca_sizename.ReadOnly = True
        Me.ca_sizename.Width = 80
        '
        'ca_packername
        '
        Me.ca_packername.HeaderText = "Packer Name"
        Me.ca_packername.Name = "ca_packername"
        Me.ca_packername.ReadOnly = True
        Me.ca_packername.Width = 120
        '
        'ca_status
        '
        Me.ca_status.HeaderText = "Status"
        Me.ca_status.Name = "ca_status"
        Me.ca_status.ReadOnly = True
        Me.ca_status.Width = 80
        '
        'ca_packeddate
        '
        Me.ca_packeddate.HeaderText = "Packed Date"
        Me.ca_packeddate.Name = "ca_packeddate"
        Me.ca_packeddate.ReadOnly = True
        '
        'ca_option
        '
        Me.ca_option.HeaderText = ""
        Me.ca_option.Name = "ca_option"
        Me.ca_option.Text = "Remove"
        Me.ca_option.UseColumnTextForButtonValue = True
        Me.ca_option.Width = 60
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(9, -2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 17)
        Me.Label15.TabIndex = 228
        Me.Label15.Text = "Boxes:"
        '
        'gbAddProductItem
        '
        Me.gbAddProductItem.Controls.Add(Me.txtSizeName)
        Me.gbAddProductItem.Controls.Add(Me.Label24)
        Me.gbAddProductItem.Controls.Add(Me.txtBoxCBM)
        Me.gbAddProductItem.Controls.Add(Me.Label23)
        Me.gbAddProductItem.Controls.Add(Me.lblCartonNoE)
        Me.gbAddProductItem.Controls.Add(Me.cboCartonNo)
        Me.gbAddProductItem.Controls.Add(Me.btnAddCarton)
        Me.gbAddProductItem.Location = New System.Drawing.Point(8, 8)
        Me.gbAddProductItem.Name = "gbAddProductItem"
        Me.gbAddProductItem.Size = New System.Drawing.Size(589, 39)
        Me.gbAddProductItem.TabIndex = 38
        Me.gbAddProductItem.TabStop = False
        '
        'txtSizeName
        '
        Me.txtSizeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSizeName.Location = New System.Drawing.Point(419, 11)
        Me.txtSizeName.Name = "txtSizeName"
        Me.txtSizeName.ReadOnly = True
        Me.txtSizeName.Size = New System.Drawing.Size(90, 21)
        Me.txtSizeName.TabIndex = 41
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(343, 14)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(74, 15)
        Me.Label24.TabIndex = 588
        Me.Label24.Text = "Size  Name:"
        '
        'txtBoxCBM
        '
        Me.txtBoxCBM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxCBM.Location = New System.Drawing.Point(238, 11)
        Me.txtBoxCBM.Name = "txtBoxCBM"
        Me.txtBoxCBM.ReadOnly = True
        Me.txtBoxCBM.Size = New System.Drawing.Size(90, 21)
        Me.txtBoxCBM.TabIndex = 40
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(197, 14)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(37, 15)
        Me.Label23.TabIndex = 451
        Me.Label23.Text = "CBM:"
        '
        'lblCartonNoE
        '
        Me.lblCartonNoE.AutoSize = True
        Me.lblCartonNoE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartonNoE.Location = New System.Drawing.Point(4, 14)
        Me.lblCartonNoE.Name = "lblCartonNoE"
        Me.lblCartonNoE.Size = New System.Drawing.Size(53, 15)
        Me.lblCartonNoE.TabIndex = 450
        Me.lblCartonNoE.Text = "Box No.:"
        '
        'cboCartonNo
        '
        Me.cboCartonNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCartonNo.FormattingEnabled = True
        Me.cboCartonNo.Location = New System.Drawing.Point(58, 11)
        Me.cboCartonNo.Name = "cboCartonNo"
        Me.cboCartonNo.Size = New System.Drawing.Size(124, 23)
        Me.cboCartonNo.TabIndex = 39
        '
        'btnAddCarton
        '
        Me.btnAddCarton.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAddCarton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnAddCarton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddCarton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddCarton.Image = CType(resources.GetObject("btnAddCarton.Image"), System.Drawing.Image)
        Me.btnAddCarton.Location = New System.Drawing.Point(526, 7)
        Me.btnAddCarton.Name = "btnAddCarton"
        Me.btnAddCarton.Size = New System.Drawing.Size(45, 30)
        Me.btnAddCarton.TabIndex = 42
        Me.btnAddCarton.UseVisualStyleBackColor = False
        '
        'gbLineUpInformation
        '
        Me.gbLineUpInformation.Controls.Add(Me.btnAddHelper2)
        Me.gbLineUpInformation.Controls.Add(Me.btnAddHelper1)
        Me.gbLineUpInformation.Controls.Add(Me.btnAddAgent)
        Me.gbLineUpInformation.Controls.Add(Me.Label32)
        Me.gbLineUpInformation.Controls.Add(Me.Label28)
        Me.gbLineUpInformation.Controls.Add(Me.Label26)
        Me.gbLineUpInformation.Controls.Add(Me.cboHelper2)
        Me.gbLineUpInformation.Controls.Add(Me.cboHelper1)
        Me.gbLineUpInformation.Controls.Add(Me.cboAgent)
        Me.gbLineUpInformation.Controls.Add(Me.txtClassDescription)
        Me.gbLineUpInformation.Controls.Add(Me.Label31)
        Me.gbLineUpInformation.Controls.Add(Me.txtVendorCodeNameInfo)
        Me.gbLineUpInformation.Controls.Add(Me.txtBranchCodeNameInfo)
        Me.gbLineUpInformation.Controls.Add(Me.Label41)
        Me.gbLineUpInformation.Controls.Add(Me.Label29)
        Me.gbLineUpInformation.Controls.Add(Me.Label9)
        Me.gbLineUpInformation.Controls.Add(Me.txtCBM)
        Me.gbLineUpInformation.Controls.Add(Me.txtCancelDate)
        Me.gbLineUpInformation.Controls.Add(Me.Label14)
        Me.gbLineUpInformation.Controls.Add(Me.Label2)
        Me.gbLineUpInformation.Controls.Add(Me.txtPONo)
        Me.gbLineUpInformation.Controls.Add(Me.Label27)
        Me.gbLineUpInformation.Controls.Add(Me.txtConfirmedDate)
        Me.gbLineUpInformation.Controls.Add(Me.Label1)
        Me.gbLineUpInformation.Controls.Add(Me.txtSIDRNo)
        Me.gbLineUpInformation.Controls.Add(Me.txtCustomerOrderInfo)
        Me.gbLineUpInformation.Controls.Add(Me.txtDeliveryHours)
        Me.gbLineUpInformation.Controls.Add(Me.txtReceiptDate)
        Me.gbLineUpInformation.Controls.Add(Me.Label20)
        Me.gbLineUpInformation.Controls.Add(Me.Label10)
        Me.gbLineUpInformation.Controls.Add(Me.pbAddDriver)
        Me.gbLineUpInformation.Controls.Add(Me.Label7)
        Me.gbLineUpInformation.Controls.Add(Me.txtDeliveryAddress)
        Me.gbLineUpInformation.Controls.Add(Me.Label19)
        Me.gbLineUpInformation.Controls.Add(Me.txtCustomerOrderDate)
        Me.gbLineUpInformation.Controls.Add(Me.Label22)
        Me.gbLineUpInformation.Controls.Add(Me.pbAddTruckShiftInfo)
        Me.gbLineUpInformation.Controls.Add(Me.cboDriverName)
        Me.gbLineUpInformation.Controls.Add(Me.Label17)
        Me.gbLineUpInformation.Controls.Add(Me.txtComments)
        Me.gbLineUpInformation.Controls.Add(Me.Label25)
        Me.gbLineUpInformation.Controls.Add(Me.txtStatus)
        Me.gbLineUpInformation.Controls.Add(Me.Label12)
        Me.gbLineUpInformation.Controls.Add(Me.Label5)
        Me.gbLineUpInformation.Controls.Add(Me.cboTruckShiftInfo)
        Me.gbLineUpInformation.Controls.Add(Me.dtpLineUpDate)
        Me.gbLineUpInformation.Controls.Add(Me.Label11)
        Me.gbLineUpInformation.Controls.Add(Me.txtLineUpNo)
        Me.gbLineUpInformation.Controls.Add(Me.Label3)
        Me.gbLineUpInformation.Controls.Add(Me.Label6)
        Me.gbLineUpInformation.Controls.Add(Me.Label8)
        Me.gbLineUpInformation.Controls.Add(Me.Label13)
        Me.gbLineUpInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLineUpInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbLineUpInformation.Location = New System.Drawing.Point(7, 26)
        Me.gbLineUpInformation.Name = "gbLineUpInformation"
        Me.gbLineUpInformation.Size = New System.Drawing.Size(605, 339)
        Me.gbLineUpInformation.TabIndex = 3
        Me.gbLineUpInformation.TabStop = False
        '
        'btnAddHelper2
        '
        Me.btnAddHelper2.BackColor = System.Drawing.Color.Transparent
        Me.btnAddHelper2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddHelper2.Image = CType(resources.GetObject("btnAddHelper2.Image"), System.Drawing.Image)
        Me.btnAddHelper2.Location = New System.Drawing.Point(582, 303)
        Me.btnAddHelper2.Name = "btnAddHelper2"
        Me.btnAddHelper2.Size = New System.Drawing.Size(14, 18)
        Me.btnAddHelper2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnAddHelper2.TabIndex = 605
        Me.btnAddHelper2.TabStop = False
        Me.btnAddHelper2.Tag = ""
        '
        'btnAddHelper1
        '
        Me.btnAddHelper1.BackColor = System.Drawing.Color.Transparent
        Me.btnAddHelper1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddHelper1.Image = CType(resources.GetObject("btnAddHelper1.Image"), System.Drawing.Image)
        Me.btnAddHelper1.Location = New System.Drawing.Point(582, 276)
        Me.btnAddHelper1.Name = "btnAddHelper1"
        Me.btnAddHelper1.Size = New System.Drawing.Size(14, 18)
        Me.btnAddHelper1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnAddHelper1.TabIndex = 604
        Me.btnAddHelper1.TabStop = False
        Me.btnAddHelper1.Tag = ""
        '
        'btnAddAgent
        '
        Me.btnAddAgent.BackColor = System.Drawing.Color.Transparent
        Me.btnAddAgent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddAgent.Image = CType(resources.GetObject("btnAddAgent.Image"), System.Drawing.Image)
        Me.btnAddAgent.Location = New System.Drawing.Point(294, 276)
        Me.btnAddAgent.Name = "btnAddAgent"
        Me.btnAddAgent.Size = New System.Drawing.Size(14, 18)
        Me.btnAddAgent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnAddAgent.TabIndex = 603
        Me.btnAddAgent.TabStop = False
        Me.btnAddAgent.Tag = ""
        Me.btnAddAgent.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(312, 306)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(57, 15)
        Me.Label32.TabIndex = 595
        Me.Label32.Text = "Helper 2:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(312, 279)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(57, 15)
        Me.Label28.TabIndex = 595
        Me.Label28.Text = "Helper 1:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(5, 279)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(41, 15)
        Me.Label26.TabIndex = 595
        Me.Label26.Text = "Agent:"
        Me.Label26.Visible = False
        '
        'cboHelper2
        '
        Me.cboHelper2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHelper2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHelper2.FormattingEnabled = True
        Me.cboHelper2.Location = New System.Drawing.Point(385, 298)
        Me.cboHelper2.Name = "cboHelper2"
        Me.cboHelper2.Size = New System.Drawing.Size(194, 23)
        Me.cboHelper2.TabIndex = 594
        '
        'cboHelper1
        '
        Me.cboHelper1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHelper1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHelper1.FormattingEnabled = True
        Me.cboHelper1.Location = New System.Drawing.Point(385, 271)
        Me.cboHelper1.Name = "cboHelper1"
        Me.cboHelper1.Size = New System.Drawing.Size(194, 23)
        Me.cboHelper1.TabIndex = 594
        '
        'cboAgent
        '
        Me.cboAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAgent.FormattingEnabled = True
        Me.cboAgent.Location = New System.Drawing.Point(52, 271)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Size = New System.Drawing.Size(238, 23)
        Me.cboAgent.TabIndex = 594
        Me.cboAgent.Visible = False
        '
        'txtClassDescription
        '
        Me.txtClassDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClassDescription.Location = New System.Drawing.Point(112, 241)
        Me.txtClassDescription.Name = "txtClassDescription"
        Me.txtClassDescription.ReadOnly = True
        Me.txtClassDescription.Size = New System.Drawing.Size(295, 21)
        Me.txtClassDescription.TabIndex = 35
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(5, 244)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(105, 15)
        Me.Label31.TabIndex = 593
        Me.Label31.Text = "Class Description:"
        '
        'txtVendorCodeNameInfo
        '
        Me.txtVendorCodeNameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorCodeNameInfo.Location = New System.Drawing.Point(152, 214)
        Me.txtVendorCodeNameInfo.Name = "txtVendorCodeNameInfo"
        Me.txtVendorCodeNameInfo.ReadOnly = True
        Me.txtVendorCodeNameInfo.Size = New System.Drawing.Size(255, 21)
        Me.txtVendorCodeNameInfo.TabIndex = 34
        '
        'txtBranchCodeNameInfo
        '
        Me.txtBranchCodeNameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchCodeNameInfo.Location = New System.Drawing.Point(152, 187)
        Me.txtBranchCodeNameInfo.Name = "txtBranchCodeNameInfo"
        Me.txtBranchCodeNameInfo.ReadOnly = True
        Me.txtBranchCodeNameInfo.Size = New System.Drawing.Size(255, 21)
        Me.txtBranchCodeNameInfo.TabIndex = 33
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(5, 189)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(147, 15)
        Me.Label41.TabIndex = 591
        Me.Label41.Text = "Branch Code / Name Info:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(5, 217)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(147, 15)
        Me.Label29.TabIndex = 590
        Me.Label29.Text = "Vendor Code / Name Info:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(267, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 15)
        Me.Label9.TabIndex = 587
        Me.Label9.Text = "CBM:"
        '
        'txtCBM
        '
        Me.txtCBM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCBM.Location = New System.Drawing.Point(306, 77)
        Me.txtCBM.Name = "txtCBM"
        Me.txtCBM.ReadOnly = True
        Me.txtCBM.Size = New System.Drawing.Size(90, 21)
        Me.txtCBM.TabIndex = 25
        '
        'txtCancelDate
        '
        Me.txtCancelDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCancelDate.Location = New System.Drawing.Point(497, 133)
        Me.txtCancelDate.Name = "txtCancelDate"
        Me.txtCancelDate.ReadOnly = True
        Me.txtCancelDate.Size = New System.Drawing.Size(100, 21)
        Me.txtCancelDate.TabIndex = 31
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(414, 136)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 15)
        Me.Label14.TabIndex = 585
        Me.Label14.Text = "Cancel Date:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(436, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 584
        Me.Label2.Text = "P.O. No.:"
        '
        'txtPONo
        '
        Me.txtPONo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPONo.Location = New System.Drawing.Point(497, 106)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.ReadOnly = True
        Me.txtPONo.Size = New System.Drawing.Size(100, 21)
        Me.txtPONo.TabIndex = 28
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(417, 80)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(76, 15)
        Me.Label27.TabIndex = 581
        Me.Label27.Text = "S.I./D.R. No.:"
        '
        'txtConfirmedDate
        '
        Me.txtConfirmedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmedDate.Location = New System.Drawing.Point(507, 21)
        Me.txtConfirmedDate.Name = "txtConfirmedDate"
        Me.txtConfirmedDate.ReadOnly = True
        Me.txtConfirmedDate.Size = New System.Drawing.Size(90, 21)
        Me.txtConfirmedDate.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(410, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 15)
        Me.Label1.TabIndex = 580
        Me.Label1.Text = "Confirmed Date:"
        '
        'txtSIDRNo
        '
        Me.txtSIDRNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSIDRNo.Location = New System.Drawing.Point(497, 77)
        Me.txtSIDRNo.Name = "txtSIDRNo"
        Me.txtSIDRNo.ReadOnly = True
        Me.txtSIDRNo.Size = New System.Drawing.Size(100, 21)
        Me.txtSIDRNo.TabIndex = 26
        '
        'txtCustomerOrderInfo
        '
        Me.txtCustomerOrderInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerOrderInfo.Location = New System.Drawing.Point(132, 106)
        Me.txtCustomerOrderInfo.Name = "txtCustomerOrderInfo"
        Me.txtCustomerOrderInfo.ReadOnly = True
        Me.txtCustomerOrderInfo.Size = New System.Drawing.Size(275, 21)
        Me.txtCustomerOrderInfo.TabIndex = 27
        '
        'txtDeliveryHours
        '
        Me.txtDeliveryHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryHours.Location = New System.Drawing.Point(417, 173)
        Me.txtDeliveryHours.Multiline = True
        Me.txtDeliveryHours.Name = "txtDeliveryHours"
        Me.txtDeliveryHours.ReadOnly = True
        Me.txtDeliveryHours.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDeliveryHours.Size = New System.Drawing.Size(180, 35)
        Me.txtDeliveryHours.TabIndex = 36
        '
        'txtReceiptDate
        '
        Me.txtReceiptDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceiptDate.Location = New System.Drawing.Point(312, 133)
        Me.txtReceiptDate.Name = "txtReceiptDate"
        Me.txtReceiptDate.ReadOnly = True
        Me.txtReceiptDate.Size = New System.Drawing.Size(95, 21)
        Me.txtReceiptDate.TabIndex = 30
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(228, 136)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 15)
        Me.Label20.TabIndex = 567
        Me.Label20.Text = "Receipt Date:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 109)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 15)
        Me.Label10.TabIndex = 555
        Me.Label10.Text = "Customer Order Info.:"
        '
        'pbAddDriver
        '
        Me.pbAddDriver.BackColor = System.Drawing.Color.Transparent
        Me.pbAddDriver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddDriver.Image = CType(resources.GetObject("pbAddDriver.Image"), System.Drawing.Image)
        Me.pbAddDriver.Location = New System.Drawing.Point(241, 80)
        Me.pbAddDriver.Name = "pbAddDriver"
        Me.pbAddDriver.Size = New System.Drawing.Size(14, 16)
        Me.pbAddDriver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddDriver.TabIndex = 575
        Me.pbAddDriver.TabStop = False
        Me.pbAddDriver.Tag = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(5, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 15)
        Me.Label7.TabIndex = 572
        Me.Label7.Text = "Delivery Address:"
        '
        'txtDeliveryAddress
        '
        Me.txtDeliveryAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryAddress.Location = New System.Drawing.Point(111, 160)
        Me.txtDeliveryAddress.Name = "txtDeliveryAddress"
        Me.txtDeliveryAddress.ReadOnly = True
        Me.txtDeliveryAddress.Size = New System.Drawing.Size(296, 21)
        Me.txtDeliveryAddress.TabIndex = 32
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(470, 155)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 15)
        Me.Label19.TabIndex = 569
        Me.Label19.Text = "Delivery Hours:"
        '
        'txtCustomerOrderDate
        '
        Me.txtCustomerOrderDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerOrderDate.Location = New System.Drawing.Point(132, 133)
        Me.txtCustomerOrderDate.Name = "txtCustomerOrderDate"
        Me.txtCustomerOrderDate.ReadOnly = True
        Me.txtCustomerOrderDate.Size = New System.Drawing.Size(95, 21)
        Me.txtCustomerOrderDate.TabIndex = 29
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(5, 136)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(126, 15)
        Me.Label22.TabIndex = 568
        Me.Label22.Text = "Customer Order Date:"
        '
        'pbAddTruckShiftInfo
        '
        Me.pbAddTruckShiftInfo.BackColor = System.Drawing.Color.Transparent
        Me.pbAddTruckShiftInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddTruckShiftInfo.Image = CType(resources.GetObject("pbAddTruckShiftInfo.Image"), System.Drawing.Image)
        Me.pbAddTruckShiftInfo.Location = New System.Drawing.Point(565, 50)
        Me.pbAddTruckShiftInfo.Name = "pbAddTruckShiftInfo"
        Me.pbAddTruckShiftInfo.Size = New System.Drawing.Size(14, 18)
        Me.pbAddTruckShiftInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddTruckShiftInfo.TabIndex = 563
        Me.pbAddTruckShiftInfo.TabStop = False
        Me.pbAddTruckShiftInfo.Tag = ""
        '
        'cboDriverName
        '
        Me.cboDriverName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDriverName.FormattingEnabled = True
        Me.cboDriverName.Location = New System.Drawing.Point(87, 77)
        Me.cboDriverName.Name = "cboDriverName"
        Me.cboDriverName.Size = New System.Drawing.Size(150, 23)
        Me.cboDriverName.TabIndex = 24
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(5, 80)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 15)
        Me.Label17.TabIndex = 562
        Me.Label17.Text = "Driver Name:"
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(417, 227)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(180, 35)
        Me.txtComments.TabIndex = 37
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(475, 208)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 15)
        Me.Label25.TabIndex = 560
        Me.Label25.Text = "Comments:"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(52, 48)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(100, 21)
        Me.txtStatus.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(5, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 558
        Me.Label12.Text = "Status:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(179, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 15)
        Me.Label5.TabIndex = 553
        Me.Label5.Text = "Truck Plate No.:"
        '
        'cboTruckShiftInfo
        '
        Me.cboTruckShiftInfo.BackColor = System.Drawing.SystemColors.Window
        Me.cboTruckShiftInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTruckShiftInfo.FormattingEnabled = True
        Me.cboTruckShiftInfo.Location = New System.Drawing.Point(291, 48)
        Me.cboTruckShiftInfo.Name = "cboTruckShiftInfo"
        Me.cboTruckShiftInfo.Size = New System.Drawing.Size(270, 23)
        Me.cboTruckShiftInfo.TabIndex = 23
        '
        'dtpLineUpDate
        '
        Me.dtpLineUpDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpLineUpDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpLineUpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLineUpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLineUpDate.Location = New System.Drawing.Point(291, 21)
        Me.dtpLineUpDate.Name = "dtpLineUpDate"
        Me.dtpLineUpDate.Size = New System.Drawing.Size(110, 21)
        Me.dtpLineUpDate.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(193, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 15)
        Me.Label11.TabIndex = 551
        Me.Label11.Text = "Delivery Date:"
        '
        'txtLineUpNo
        '
        Me.txtLineUpNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLineUpNo.Location = New System.Drawing.Point(85, 21)
        Me.txtLineUpNo.Name = "txtLineUpNo"
        Me.txtLineUpNo.ReadOnly = True
        Me.txtLineUpNo.Size = New System.Drawing.Size(100, 21)
        Me.txtLineUpNo.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(5, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 549
        Me.Label3.Text = "Line-Up No.:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(274, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 20)
        Me.Label6.TabIndex = 564
        Me.Label6.Text = "*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(9, -2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(153, 17)
        Me.Label8.TabIndex = 228
        Me.Label8.Text = "Line-Up Information:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(274, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 20)
        Me.Label13.TabIndex = 565
        Me.Label13.Text = "*"
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave, Me.msToDeliver, Me.msOrder, Me.msPrint, Me.msConfirm})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(612, 24)
        Me.msMenu.TabIndex = 18
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(62, 20)
        Me.msSave.Text = "&Save"
        '
        'msToDeliver
        '
        Me.msToDeliver.Image = CType(resources.GetObject("msToDeliver.Image"), System.Drawing.Image)
        Me.msToDeliver.Name = "msToDeliver"
        Me.msToDeliver.Size = New System.Drawing.Size(92, 20)
        Me.msToDeliver.Text = "To &Deliver"
        '
        'msOrder
        '
        Me.msOrder.Image = CType(resources.GetObject("msOrder.Image"), System.Drawing.Image)
        Me.msOrder.Name = "msOrder"
        Me.msOrder.Size = New System.Drawing.Size(118, 20)
        Me.msOrder.Text = "Cancel &Line-Up"
        '
        'msPrint
        '
        Me.msPrint.Image = CType(resources.GetObject("msPrint.Image"), System.Drawing.Image)
        Me.msPrint.Name = "msPrint"
        Me.msPrint.Size = New System.Drawing.Size(62, 20)
        Me.msPrint.Text = "&Print"
        '
        'msConfirm
        '
        Me.msConfirm.Image = CType(resources.GetObject("msConfirm.Image"), System.Drawing.Image)
        Me.msConfirm.Name = "msConfirm"
        Me.msConfirm.Size = New System.Drawing.Size(130, 20)
        Me.msConfirm.Text = "&Confirm Delivery"
        '
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(18, 6)
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
        Me.lblTitle.Size = New System.Drawing.Size(984, 28)
        Me.lblTitle.TabIndex = 234
        Me.lblTitle.Text = "View / Edit Line-Up And Delivery"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ViewEditLineUpDeliveryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(984, 562)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewEditLineUpDeliveryForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgLineUpList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.gbLineUpList.ResumeLayout(False)
        Me.gbLineUpList.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.tabSearch.ResumeLayout(False)
        Me.tabSimple.ResumeLayout(False)
        Me.tabSimple.PerformLayout()
        Me.tabCommon.ResumeLayout(False)
        Me.tabCommon.PerformLayout()
        Me.gbCartons.ResumeLayout(False)
        Me.gbCartons.PerformLayout()
        CType(Me.dgCartons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAddProductItem.ResumeLayout(False)
        Me.gbAddProductItem.PerformLayout()
        Me.gbLineUpInformation.ResumeLayout(False)
        Me.gbLineUpInformation.PerformLayout()
        CType(Me.btnAddHelper2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAddHelper1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAddAgent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddDriver, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddTruckShiftInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dgLineUpList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents gbLineUpList As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPage As System.Windows.Forms.TextBox
    Friend WithEvents txtPageNo As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblTitle As System.Windows.Forms.Label
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
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msOrder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbLineUpInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSIDRNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerOrderInfo As System.Windows.Forms.TextBox
    Friend WithEvents txtDeliveryHours As System.Windows.Forms.TextBox
    Friend WithEvents txtReceiptDate As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pbAddDriver As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Private WithEvents txtCustomerOrderDate As System.Windows.Forms.TextBox
    Private WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents pbAddTruckShiftInfo As System.Windows.Forms.PictureBox
    Friend WithEvents cboDriverName As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboTruckShiftInfo As System.Windows.Forms.ComboBox
    Friend WithEvents dtpLineUpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtLineUpNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents gbCartons As System.Windows.Forms.GroupBox
    Friend WithEvents dgCartons As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents msToDeliver As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msConfirm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtConfirmedDate As System.Windows.Forms.TextBox
    Friend WithEvents gbAddProductItem As System.Windows.Forms.GroupBox
    Friend WithEvents lblCartonNoE As System.Windows.Forms.Label
    Friend WithEvents cboCartonNo As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddCarton As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtCancelDate As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCBM As System.Windows.Forms.TextBox
    Private WithEvents txtVendorCodeNameInfo As System.Windows.Forms.TextBox
    Private WithEvents txtBranchCodeNameInfo As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Private WithEvents txtClassDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtSizeName As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtBoxCBM As System.Windows.Forms.TextBox
    Friend WithEvents lu_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lu_lineupno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lu_deliveryno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lu_customerorderinfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lu_deliverydate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_packinglistcartonid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_cartonno As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ca_cbm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_sizename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_packername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_packeddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_option As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Label32 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents cboHelper2 As ComboBox
    Friend WithEvents cboHelper1 As ComboBox
    Friend WithEvents cboAgent As ComboBox
    Friend WithEvents btnAddAgent As PictureBox
    Friend WithEvents btnAddHelper1 As PictureBox
    Friend WithEvents btnAddHelper2 As PictureBox
    Friend WithEvents Button1 As Button
End Class
