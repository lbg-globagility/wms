<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrganizationForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrganizationForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtAlternatePhone = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFaxNo = New System.Windows.Forms.TextBox()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.cboOrganizationType = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMainPhone = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.txtOrganizationName = New System.Windows.Forms.TextBox()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.dgOrganizationList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.o_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_orgname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_tradename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_mainphone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbOrganizationList = New System.Windows.Forms.GroupBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.gbUsers = New System.Windows.Forms.GroupBox()
        Me.dgUsers = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.u_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.u_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.u_fname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.u_mname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.u_lname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.u_position = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.u_emailaddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.u_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.gbOrganizationLogo = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtImagePath = New System.Windows.Forms.TextBox()
        Me.pbOrganizationLogo = New System.Windows.Forms.PictureBox()
        Me.btnRemoveLogo = New System.Windows.Forms.Button()
        Me.btnChangeLogo = New System.Windows.Forms.Button()
        Me.gbOrganizationInformation = New System.Windows.Forms.GroupBox()
        Me.pbAutoAddA = New System.Windows.Forms.PictureBox()
        Me.pbEditContactPerson = New System.Windows.Forms.PictureBox()
        Me.pbEditPremAddress = New System.Windows.Forms.PictureBox()
        Me.pbEditPrimAddress = New System.Windows.Forms.PictureBox()
        Me.txtContactPerson = New System.Windows.Forms.TextBox()
        Me.txtPremiseAddress = New System.Windows.Forms.TextBox()
        Me.txtPrimaryAddress = New System.Windows.Forms.TextBox()
        Me.txtTIN = New System.Windows.Forms.MaskedTextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtWebsite = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTradeName = New System.Windows.Forms.TextBox()
        Me.txtOtherEmail = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.msMenu.SuspendLayout()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.dgOrganizationList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrganizationList.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.gbUsers.SuspendLayout()
        CType(Me.dgUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrganizationLogo.SuspendLayout()
        CType(Me.pbOrganizationLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrganizationInformation.SuspendLayout()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEditContactPerson, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEditPremAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEditPrimAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtAlternatePhone
        '
        Me.txtAlternatePhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlternatePhone.Location = New System.Drawing.Point(137, 214)
        Me.txtAlternatePhone.Name = "txtAlternatePhone"
        Me.txtAlternatePhone.Size = New System.Drawing.Size(294, 21)
        Me.txtAlternatePhone.TabIndex = 15
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(7, 217)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(97, 15)
        Me.Label39.TabIndex = 372
        Me.Label39.Text = "Alternate Phone:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(7, 109)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(99, 15)
        Me.Label13.TabIndex = 369
        Me.Label13.Text = "Primary Address:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(7, 163)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 15)
        Me.Label11.TabIndex = 368
        Me.Label11.Text = "Contact Person:"
        '
        'txtFaxNo
        '
        Me.txtFaxNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaxNo.Location = New System.Drawing.Point(137, 295)
        Me.txtFaxNo.Name = "txtFaxNo"
        Me.txtFaxNo.Size = New System.Drawing.Size(294, 21)
        Me.txtFaxNo.TabIndex = 18
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailAddress.Location = New System.Drawing.Point(137, 241)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(294, 21)
        Me.txtEmailAddress.TabIndex = 16
        '
        'cboOrganizationType
        '
        Me.cboOrganizationType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOrganizationType.FormattingEnabled = True
        Me.cboOrganizationType.Location = New System.Drawing.Point(137, 77)
        Me.cboOrganizationType.Name = "cboOrganizationType"
        Me.cboOrganizationType.Size = New System.Drawing.Size(269, 23)
        Me.cboOrganizationType.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(7, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 15)
        Me.Label12.TabIndex = 362
        Me.Label12.Text = "Organization Type:"
        '
        'txtMainPhone
        '
        Me.txtMainPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMainPhone.Location = New System.Drawing.Point(137, 187)
        Me.txtMainPhone.Name = "txtMainPhone"
        Me.txtMainPhone.Size = New System.Drawing.Size(294, 21)
        Me.txtMainPhone.TabIndex = 14
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(7, 244)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 15)
        Me.Label19.TabIndex = 361
        Me.Label19.Text = "Email Address:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(7, 298)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(52, 15)
        Me.Label24.TabIndex = 359
        Me.Label24.Text = "Fax No.:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(7, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 15)
        Me.Label5.TabIndex = 249
        Me.Label5.Text = "Trade Name:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(133, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 20)
        Me.Label6.TabIndex = 248
        Me.Label6.Text = "*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(7, 190)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 15)
        Me.Label8.TabIndex = 240
        Me.Label8.Text = "Main Phone:"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1210, 28)
        Me.lblTitle.TabIndex = 281
        Me.lblTitle.Text = "Organizations"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(821, 25)
        Me.msMenu.TabIndex = 316
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'pbClose
        '
        Me.pbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pbClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbClose.Image = CType(resources.GetObject("pbClose.Image"), System.Drawing.Image)
        Me.pbClose.Location = New System.Drawing.Point(1183, 5)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(19, 19)
        Me.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbClose.TabIndex = 283
        Me.pbClose.TabStop = False
        '
        'txtOrganizationName
        '
        Me.txtOrganizationName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrganizationName.Location = New System.Drawing.Point(152, 24)
        Me.txtOrganizationName.Name = "txtOrganizationName"
        Me.txtOrganizationName.Size = New System.Drawing.Size(279, 21)
        Me.txtOrganizationName.TabIndex = 8
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(6, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 17)
        Me.Label2.TabIndex = 220
        Me.Label2.Text = "Organization List:"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.AutoSize = False
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsRefresh})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 17)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(360, 22)
        Me.ToolStrip3.TabIndex = 6
        Me.ToolStrip3.Text = "toolbar1"
        '
        'dgOrganizationList
        '
        Me.dgOrganizationList.AllowUserToAddRows = False
        Me.dgOrganizationList.AllowUserToDeleteRows = False
        Me.dgOrganizationList.AllowUserToOrderColumns = True
        Me.dgOrganizationList.AllowUserToResizeRows = False
        Me.dgOrganizationList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgOrganizationList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOrganizationList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgOrganizationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOrganizationList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.o_rowid, Me.o_seqno, Me.o_orgname, Me.o_tradename, Me.o_mainphone})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgOrganizationList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgOrganizationList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgOrganizationList.Location = New System.Drawing.Point(8, 42)
        Me.dgOrganizationList.MultiSelect = False
        Me.dgOrganizationList.Name = "dgOrganizationList"
        Me.dgOrganizationList.ReadOnly = True
        Me.dgOrganizationList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOrganizationList.Size = New System.Drawing.Size(350, 469)
        Me.dgOrganizationList.TabIndex = 7
        '
        'o_rowid
        '
        Me.o_rowid.HeaderText = "rowid"
        Me.o_rowid.Name = "o_rowid"
        Me.o_rowid.ReadOnly = True
        Me.o_rowid.Visible = False
        '
        'o_seqno
        '
        Me.o_seqno.HeaderText = "Seq. No."
        Me.o_seqno.Name = "o_seqno"
        Me.o_seqno.ReadOnly = True
        Me.o_seqno.Width = 50
        '
        'o_orgname
        '
        Me.o_orgname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.o_orgname.HeaderText = "Organization Name"
        Me.o_orgname.Name = "o_orgname"
        Me.o_orgname.ReadOnly = True
        Me.o_orgname.Width = 127
        '
        'o_tradename
        '
        Me.o_tradename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.o_tradename.HeaderText = "Trade Name"
        Me.o_tradename.Name = "o_tradename"
        Me.o_tradename.ReadOnly = True
        Me.o_tradename.Width = 93
        '
        'o_mainphone
        '
        Me.o_mainphone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.o_mainphone.HeaderText = "Main Phone"
        Me.o_mainphone.Name = "o_mainphone"
        Me.o_mainphone.ReadOnly = True
        Me.o_mainphone.Width = 91
        '
        'gbOrganizationList
        '
        Me.gbOrganizationList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbOrganizationList.BackColor = System.Drawing.Color.Transparent
        Me.gbOrganizationList.Controls.Add(Me.dgOrganizationList)
        Me.gbOrganizationList.Controls.Add(Me.Label2)
        Me.gbOrganizationList.Controls.Add(Me.ToolStrip3)
        Me.gbOrganizationList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrganizationList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbOrganizationList.Location = New System.Drawing.Point(7, 3)
        Me.gbOrganizationList.Name = "gbOrganizationList"
        Me.gbOrganizationList.Size = New System.Drawing.Size(366, 520)
        Me.gbOrganizationList.TabIndex = 1
        Me.gbOrganizationList.TabStop = False
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Yellow
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbOrganizationList)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabMain)
        Me.SplitContainer1.Panel2.Controls.Add(Me.msMenu)
        Me.SplitContainer1.Size = New System.Drawing.Size(1210, 534)
        Me.SplitContainer1.SplitterDistance = 381
        Me.SplitContainer1.TabIndex = 282
        '
        'tabMain
        '
        Me.tabMain.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabMain.Controls.Add(Me.tabDetails)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabMain.ItemSize = New System.Drawing.Size(61, 23)
        Me.tabMain.Location = New System.Drawing.Point(0, 25)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(821, 505)
        Me.tabMain.TabIndex = 0
        '
        'tabDetails
        '
        Me.tabDetails.AutoScroll = True
        Me.tabDetails.Controls.Add(Me.gbUsers)
        Me.tabDetails.Controls.Add(Me.gbOrganizationLogo)
        Me.tabDetails.Controls.Add(Me.gbOrganizationInformation)
        Me.tabDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(813, 474)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Org. Details"
        Me.tabDetails.UseVisualStyleBackColor = True
        '
        'gbUsers
        '
        Me.gbUsers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbUsers.Controls.Add(Me.dgUsers)
        Me.gbUsers.Controls.Add(Me.Label22)
        Me.gbUsers.Location = New System.Drawing.Point(465, 209)
        Me.gbUsers.Name = "gbUsers"
        Me.gbUsers.Size = New System.Drawing.Size(339, 256)
        Me.gbUsers.TabIndex = 4
        Me.gbUsers.TabStop = False
        '
        'dgUsers
        '
        Me.dgUsers.AllowUserToAddRows = False
        Me.dgUsers.AllowUserToDeleteRows = False
        Me.dgUsers.AllowUserToOrderColumns = True
        Me.dgUsers.AllowUserToResizeRows = False
        Me.dgUsers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgUsers.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUsers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.u_rowid, Me.u_seqno, Me.u_fname, Me.u_mname, Me.u_lname, Me.u_position, Me.u_emailaddress, Me.u_status})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgUsers.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgUsers.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgUsers.Location = New System.Drawing.Point(10, 20)
        Me.dgUsers.MultiSelect = False
        Me.dgUsers.Name = "dgUsers"
        Me.dgUsers.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUsers.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgUsers.Size = New System.Drawing.Size(319, 224)
        Me.dgUsers.TabIndex = 25
        '
        'u_rowid
        '
        Me.u_rowid.HeaderText = "rowid"
        Me.u_rowid.Name = "u_rowid"
        Me.u_rowid.ReadOnly = True
        Me.u_rowid.Visible = False
        '
        'u_seqno
        '
        Me.u_seqno.HeaderText = "Seq. No."
        Me.u_seqno.Name = "u_seqno"
        Me.u_seqno.ReadOnly = True
        Me.u_seqno.Width = 50
        '
        'u_fname
        '
        Me.u_fname.HeaderText = "First Name"
        Me.u_fname.Name = "u_fname"
        Me.u_fname.ReadOnly = True
        Me.u_fname.Width = 80
        '
        'u_mname
        '
        Me.u_mname.HeaderText = "Middle Name"
        Me.u_mname.Name = "u_mname"
        Me.u_mname.ReadOnly = True
        Me.u_mname.Width = 60
        '
        'u_lname
        '
        Me.u_lname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.u_lname.HeaderText = "Last Name"
        Me.u_lname.Name = "u_lname"
        Me.u_lname.ReadOnly = True
        Me.u_lname.Width = 92
        '
        'u_position
        '
        Me.u_position.HeaderText = "Position"
        Me.u_position.Name = "u_position"
        Me.u_position.ReadOnly = True
        Me.u_position.Width = 80
        '
        'u_emailaddress
        '
        Me.u_emailaddress.HeaderText = "Email Address"
        Me.u_emailaddress.Name = "u_emailaddress"
        Me.u_emailaddress.ReadOnly = True
        Me.u_emailaddress.Width = 80
        '
        'u_status
        '
        Me.u_status.HeaderText = "Status"
        Me.u_status.Name = "u_status"
        Me.u_status.ReadOnly = True
        Me.u_status.Width = 70
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.White
        Me.Label22.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label22.Location = New System.Drawing.Point(9, -3)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(144, 17)
        Me.Label22.TabIndex = 240
        Me.Label22.Text = "Organization Users:"
        '
        'gbOrganizationLogo
        '
        Me.gbOrganizationLogo.Controls.Add(Me.Label9)
        Me.gbOrganizationLogo.Controls.Add(Me.txtImagePath)
        Me.gbOrganizationLogo.Controls.Add(Me.pbOrganizationLogo)
        Me.gbOrganizationLogo.Controls.Add(Me.btnRemoveLogo)
        Me.gbOrganizationLogo.Controls.Add(Me.btnChangeLogo)
        Me.gbOrganizationLogo.Location = New System.Drawing.Point(465, 6)
        Me.gbOrganizationLogo.Name = "gbOrganizationLogo"
        Me.gbOrganizationLogo.Size = New System.Drawing.Size(300, 197)
        Me.gbOrganizationLogo.TabIndex = 3
        Me.gbOrganizationLogo.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(9, -1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 17)
        Me.Label9.TabIndex = 406
        Me.Label9.Text = "Organization Logo:"
        '
        'txtImagePath
        '
        Me.txtImagePath.Enabled = False
        Me.txtImagePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImagePath.Location = New System.Drawing.Point(21, 109)
        Me.txtImagePath.Name = "txtImagePath"
        Me.txtImagePath.Size = New System.Drawing.Size(70, 21)
        Me.txtImagePath.TabIndex = 24
        Me.txtImagePath.Visible = False
        '
        'pbOrganizationLogo
        '
        Me.pbOrganizationLogo.BackColor = System.Drawing.SystemColors.Control
        Me.pbOrganizationLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbOrganizationLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbOrganizationLogo.Location = New System.Drawing.Point(102, 25)
        Me.pbOrganizationLogo.Name = "pbOrganizationLogo"
        Me.pbOrganizationLogo.Size = New System.Drawing.Size(174, 155)
        Me.pbOrganizationLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbOrganizationLogo.TabIndex = 397
        Me.pbOrganizationLogo.TabStop = False
        '
        'btnRemoveLogo
        '
        Me.btnRemoveLogo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveLogo.Location = New System.Drawing.Point(21, 81)
        Me.btnRemoveLogo.Name = "btnRemoveLogo"
        Me.btnRemoveLogo.Size = New System.Drawing.Size(70, 24)
        Me.btnRemoveLogo.TabIndex = 23
        Me.btnRemoveLogo.Text = "&Delete"
        Me.btnRemoveLogo.UseVisualStyleBackColor = True
        '
        'btnChangeLogo
        '
        Me.btnChangeLogo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeLogo.Location = New System.Drawing.Point(21, 54)
        Me.btnChangeLogo.Name = "btnChangeLogo"
        Me.btnChangeLogo.Size = New System.Drawing.Size(70, 24)
        Me.btnChangeLogo.TabIndex = 22
        Me.btnChangeLogo.Text = "&Change"
        Me.btnChangeLogo.UseVisualStyleBackColor = True
        '
        'gbOrganizationInformation
        '
        Me.gbOrganizationInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbOrganizationInformation.Controls.Add(Me.pbAutoAddA)
        Me.gbOrganizationInformation.Controls.Add(Me.pbEditContactPerson)
        Me.gbOrganizationInformation.Controls.Add(Me.pbEditPremAddress)
        Me.gbOrganizationInformation.Controls.Add(Me.pbEditPrimAddress)
        Me.gbOrganizationInformation.Controls.Add(Me.txtContactPerson)
        Me.gbOrganizationInformation.Controls.Add(Me.txtPremiseAddress)
        Me.gbOrganizationInformation.Controls.Add(Me.txtPrimaryAddress)
        Me.gbOrganizationInformation.Controls.Add(Me.txtTIN)
        Me.gbOrganizationInformation.Controls.Add(Me.Label31)
        Me.gbOrganizationInformation.Controls.Add(Me.txtWebsite)
        Me.gbOrganizationInformation.Controls.Add(Me.Label30)
        Me.gbOrganizationInformation.Controls.Add(Me.txtComments)
        Me.gbOrganizationInformation.Controls.Add(Me.Label14)
        Me.gbOrganizationInformation.Controls.Add(Me.txtTradeName)
        Me.gbOrganizationInformation.Controls.Add(Me.txtOtherEmail)
        Me.gbOrganizationInformation.Controls.Add(Me.Label17)
        Me.gbOrganizationInformation.Controls.Add(Me.Label15)
        Me.gbOrganizationInformation.Controls.Add(Me.txtAlternatePhone)
        Me.gbOrganizationInformation.Controls.Add(Me.Label39)
        Me.gbOrganizationInformation.Controls.Add(Me.Label13)
        Me.gbOrganizationInformation.Controls.Add(Me.Label11)
        Me.gbOrganizationInformation.Controls.Add(Me.txtFaxNo)
        Me.gbOrganizationInformation.Controls.Add(Me.txtEmailAddress)
        Me.gbOrganizationInformation.Controls.Add(Me.cboOrganizationType)
        Me.gbOrganizationInformation.Controls.Add(Me.Label12)
        Me.gbOrganizationInformation.Controls.Add(Me.txtMainPhone)
        Me.gbOrganizationInformation.Controls.Add(Me.Label19)
        Me.gbOrganizationInformation.Controls.Add(Me.Label24)
        Me.gbOrganizationInformation.Controls.Add(Me.Label5)
        Me.gbOrganizationInformation.Controls.Add(Me.Label6)
        Me.gbOrganizationInformation.Controls.Add(Me.Label8)
        Me.gbOrganizationInformation.Controls.Add(Me.txtOrganizationName)
        Me.gbOrganizationInformation.Controls.Add(Me.Label7)
        Me.gbOrganizationInformation.Controls.Add(Me.Label18)
        Me.gbOrganizationInformation.Controls.Add(Me.lblsavemsg)
        Me.gbOrganizationInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrganizationInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbOrganizationInformation.Location = New System.Drawing.Point(4, 5)
        Me.gbOrganizationInformation.Name = "gbOrganizationInformation"
        Me.gbOrganizationInformation.Size = New System.Drawing.Size(455, 460)
        Me.gbOrganizationInformation.TabIndex = 2
        Me.gbOrganizationInformation.TabStop = False
        '
        'pbAutoAddA
        '
        Me.pbAutoAddA.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddA.Image = CType(resources.GetObject("pbAutoAddA.Image"), System.Drawing.Image)
        Me.pbAutoAddA.Location = New System.Drawing.Point(412, 79)
        Me.pbAutoAddA.Name = "pbAutoAddA"
        Me.pbAutoAddA.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddA.TabIndex = 532
        Me.pbAutoAddA.TabStop = False
        Me.pbAutoAddA.Tag = ""
        '
        'pbEditContactPerson
        '
        Me.pbEditContactPerson.BackColor = System.Drawing.Color.Transparent
        Me.pbEditContactPerson.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEditContactPerson.Image = CType(resources.GetObject("pbEditContactPerson.Image"), System.Drawing.Image)
        Me.pbEditContactPerson.Location = New System.Drawing.Point(412, 161)
        Me.pbEditContactPerson.Name = "pbEditContactPerson"
        Me.pbEditContactPerson.Size = New System.Drawing.Size(19, 19)
        Me.pbEditContactPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbEditContactPerson.TabIndex = 410
        Me.pbEditContactPerson.TabStop = False
        Me.pbEditContactPerson.Tag = ""
        '
        'pbEditPremAddress
        '
        Me.pbEditPremAddress.BackColor = System.Drawing.Color.Transparent
        Me.pbEditPremAddress.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEditPremAddress.Image = CType(resources.GetObject("pbEditPremAddress.Image"), System.Drawing.Image)
        Me.pbEditPremAddress.Location = New System.Drawing.Point(412, 134)
        Me.pbEditPremAddress.Name = "pbEditPremAddress"
        Me.pbEditPremAddress.Size = New System.Drawing.Size(19, 19)
        Me.pbEditPremAddress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbEditPremAddress.TabIndex = 409
        Me.pbEditPremAddress.TabStop = False
        Me.pbEditPremAddress.Tag = ""
        '
        'pbEditPrimAddress
        '
        Me.pbEditPrimAddress.BackColor = System.Drawing.Color.Transparent
        Me.pbEditPrimAddress.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEditPrimAddress.Image = CType(resources.GetObject("pbEditPrimAddress.Image"), System.Drawing.Image)
        Me.pbEditPrimAddress.Location = New System.Drawing.Point(412, 107)
        Me.pbEditPrimAddress.Name = "pbEditPrimAddress"
        Me.pbEditPrimAddress.Size = New System.Drawing.Size(19, 19)
        Me.pbEditPrimAddress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbEditPrimAddress.TabIndex = 408
        Me.pbEditPrimAddress.TabStop = False
        Me.pbEditPrimAddress.Tag = ""
        '
        'txtContactPerson
        '
        Me.txtContactPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactPerson.Location = New System.Drawing.Point(137, 160)
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.ReadOnly = True
        Me.txtContactPerson.Size = New System.Drawing.Size(269, 21)
        Me.txtContactPerson.TabIndex = 13
        '
        'txtPremiseAddress
        '
        Me.txtPremiseAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPremiseAddress.Location = New System.Drawing.Point(137, 133)
        Me.txtPremiseAddress.Name = "txtPremiseAddress"
        Me.txtPremiseAddress.ReadOnly = True
        Me.txtPremiseAddress.Size = New System.Drawing.Size(269, 21)
        Me.txtPremiseAddress.TabIndex = 12
        '
        'txtPrimaryAddress
        '
        Me.txtPrimaryAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrimaryAddress.Location = New System.Drawing.Point(137, 106)
        Me.txtPrimaryAddress.Name = "txtPrimaryAddress"
        Me.txtPrimaryAddress.ReadOnly = True
        Me.txtPrimaryAddress.Size = New System.Drawing.Size(269, 21)
        Me.txtPrimaryAddress.TabIndex = 11
        '
        'txtTIN
        '
        Me.txtTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTIN.Location = New System.Drawing.Point(137, 322)
        Me.txtTIN.Mask = "000-000-000-000"
        Me.txtTIN.Name = "txtTIN"
        Me.txtTIN.Size = New System.Drawing.Size(294, 21)
        Me.txtTIN.TabIndex = 19
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(7, 325)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(38, 15)
        Me.Label31.TabIndex = 404
        Me.Label31.Text = "T.I.N.:"
        '
        'txtWebsite
        '
        Me.txtWebsite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWebsite.Location = New System.Drawing.Point(137, 349)
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.Size = New System.Drawing.Size(294, 21)
        Me.txtWebsite.TabIndex = 20
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(7, 352)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(54, 15)
        Me.Label30.TabIndex = 403
        Me.Label30.Text = "Website:"
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(111, 376)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(320, 72)
        Me.txtComments.TabIndex = 21
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(7, 379)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 15)
        Me.Label14.TabIndex = 402
        Me.Label14.Text = "Comments:"
        '
        'txtTradeName
        '
        Me.txtTradeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTradeName.Location = New System.Drawing.Point(137, 51)
        Me.txtTradeName.Name = "txtTradeName"
        Me.txtTradeName.Size = New System.Drawing.Size(294, 21)
        Me.txtTradeName.TabIndex = 9
        '
        'txtOtherEmail
        '
        Me.txtOtherEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOtherEmail.Location = New System.Drawing.Point(137, 268)
        Me.txtOtherEmail.Name = "txtOtherEmail"
        Me.txtOtherEmail.Size = New System.Drawing.Size(294, 21)
        Me.txtOtherEmail.TabIndex = 17
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(7, 271)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(122, 15)
        Me.Label17.TabIndex = 378
        Me.Label17.Text = "Other Email Address:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(7, 136)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 15)
        Me.Label15.TabIndex = 375
        Me.Label15.Text = "Premise Address:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(7, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 15)
        Me.Label7.TabIndex = 239
        Me.Label7.Text = "Organization Name:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label18.Location = New System.Drawing.Point(9, -1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(189, 17)
        Me.Label18.TabIndex = 238
        Me.Label18.Text = "Organization Information:"
        '
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(10, -30)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 15)
        Me.lblsavemsg.TabIndex = 304
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'OrganizationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1210, 562)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OrganizationForm"
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.dgOrganizationList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrganizationList.ResumeLayout(False)
        Me.gbOrganizationList.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.gbUsers.ResumeLayout(False)
        Me.gbUsers.PerformLayout()
        CType(Me.dgUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrganizationLogo.ResumeLayout(False)
        Me.gbOrganizationLogo.PerformLayout()
        CType(Me.pbOrganizationLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrganizationInformation.ResumeLayout(False)
        Me.gbOrganizationInformation.PerformLayout()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEditContactPerson, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEditPremAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEditPrimAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtAlternatePhone As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtFaxNo As System.Windows.Forms.TextBox
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents cboOrganizationType As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMainPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents txtOrganizationName As System.Windows.Forms.TextBox
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents dgOrganizationList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbOrganizationList As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents gbOrganizationInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtOtherEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTradeName As System.Windows.Forms.TextBox
    Friend WithEvents txtTIN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtWebsite As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents gbOrganizationLogo As System.Windows.Forms.GroupBox
    Friend WithEvents pbOrganizationLogo As System.Windows.Forms.PictureBox
    Friend WithEvents gbUsers As System.Windows.Forms.GroupBox
    Friend WithEvents dgUsers As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtImagePath As System.Windows.Forms.TextBox
    Friend WithEvents btnRemoveLogo As System.Windows.Forms.Button
    Friend WithEvents btnChangeLogo As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtContactPerson As System.Windows.Forms.TextBox
    Friend WithEvents txtPremiseAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtPrimaryAddress As System.Windows.Forms.TextBox
    Friend WithEvents pbEditContactPerson As System.Windows.Forms.PictureBox
    Friend WithEvents pbEditPremAddress As System.Windows.Forms.PictureBox
    Friend WithEvents pbEditPrimAddress As System.Windows.Forms.PictureBox
    Friend WithEvents u_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents u_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents u_fname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents u_mname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents u_lname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents u_position As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents u_emailaddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents u_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_orgname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_tradename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_mainphone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbAutoAddA As System.Windows.Forms.PictureBox
End Class
