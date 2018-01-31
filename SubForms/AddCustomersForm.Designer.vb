<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddCustomersForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddCustomersForm))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboPickingGroup = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pbEditContactPerson = New System.Windows.Forms.PictureBox()
        Me.txtContactPerson = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTIN = New System.Windows.Forms.MaskedTextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.txtWebsite = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.pbEditDeliveryAddress = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFaxNo = New System.Windows.Forms.TextBox()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.cboParentCustomer = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAlternatePhone = New System.Windows.Forms.TextBox()
        Me.txtDeliveryAddress = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCustomerNo = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtMainPhone = New System.Windows.Forms.TextBox()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDeliveryHours = New System.Windows.Forms.TextBox()
        Me.pbAddBranchCodeName = New System.Windows.Forms.PictureBox()
        Me.cboBranchCodeNameInfo = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.pbAutoAddA = New System.Windows.Forms.PictureBox()
        Me.msMenu.SuspendLayout()
        CType(Me.pbEditContactPerson, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEditDeliveryAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddBranchCodeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(789, 28)
        Me.lblTitle.TabIndex = 396
        Me.lblTitle.Text = "Add Customer"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(789, 25)
        Me.msMenu.TabIndex = 30
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'cboPickingGroup
        '
        Me.cboPickingGroup.BackColor = System.Drawing.SystemColors.Window
        Me.cboPickingGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPickingGroup.FormattingEnabled = True
        Me.cboPickingGroup.Location = New System.Drawing.Point(240, 200)
        Me.cboPickingGroup.Name = "cboPickingGroup"
        Me.cboPickingGroup.Size = New System.Drawing.Size(124, 23)
        Me.cboPickingGroup.TabIndex = 20
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(145, 204)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 15)
        Me.Label18.TabIndex = 417
        Me.Label18.Text = "Pick List Group:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 204)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 414
        Me.Label12.Text = "Status:"
        '
        'pbEditContactPerson
        '
        Me.pbEditContactPerson.BackColor = System.Drawing.Color.Transparent
        Me.pbEditContactPerson.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEditContactPerson.Image = CType(resources.GetObject("pbEditContactPerson.Image"), System.Drawing.Image)
        Me.pbEditContactPerson.Location = New System.Drawing.Point(359, 175)
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
        Me.txtContactPerson.Location = New System.Drawing.Point(107, 174)
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.ReadOnly = True
        Me.txtContactPerson.Size = New System.Drawing.Size(250, 21)
        Me.txtContactPerson.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 177)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 15)
        Me.Label11.TabIndex = 412
        Me.Label11.Text = "Contact Person:"
        '
        'txtTIN
        '
        Me.txtTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTIN.Location = New System.Drawing.Point(448, 147)
        Me.txtTIN.Mask = "000-000-000-000"
        Me.txtTIN.Name = "txtTIN"
        Me.txtTIN.Size = New System.Drawing.Size(117, 21)
        Me.txtTIN.TabIndex = 26
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(407, 148)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(38, 15)
        Me.Label31.TabIndex = 406
        Me.Label31.Text = "T.I.N.:"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(648, 168)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(70, 15)
        Me.Label40.TabIndex = 294
        Me.Label40.Text = "Comments:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(407, 94)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 15)
        Me.Label8.TabIndex = 314
        Me.Label8.Text = "Website:"
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(586, 186)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(190, 66)
        Me.txtComments.TabIndex = 29
        '
        'txtWebsite
        '
        Me.txtWebsite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWebsite.Location = New System.Drawing.Point(461, 90)
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.Size = New System.Drawing.Size(315, 21)
        Me.txtWebsite.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(571, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 15)
        Me.Label7.TabIndex = 312
        Me.Label7.Text = "Email Address:"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailAddress.Location = New System.Drawing.Point(660, 147)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(116, 21)
        Me.txtEmailAddress.TabIndex = 27
        '
        'pbEditDeliveryAddress
        '
        Me.pbEditDeliveryAddress.BackColor = System.Drawing.Color.Transparent
        Me.pbEditDeliveryAddress.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEditDeliveryAddress.Image = CType(resources.GetObject("pbEditDeliveryAddress.Image"), System.Drawing.Image)
        Me.pbEditDeliveryAddress.Location = New System.Drawing.Point(753, 65)
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
        Me.Label2.Location = New System.Drawing.Point(407, 121)
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
        Me.Label6.Location = New System.Drawing.Point(109, 89)
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
        Me.Label5.Location = New System.Drawing.Point(8, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 15)
        Me.Label5.TabIndex = 309
        Me.Label5.Text = "Parent Customer:"
        '
        'txtFaxNo
        '
        Me.txtFaxNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaxNo.Location = New System.Drawing.Point(461, 118)
        Me.txtFaxNo.Name = "txtFaxNo"
        Me.txtFaxNo.Size = New System.Drawing.Size(104, 21)
        Me.txtFaxNo.TabIndex = 24
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(128, 91)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(254, 21)
        Me.txtCustomerName.TabIndex = 15
        '
        'cboParentCustomer
        '
        Me.cboParentCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cboParentCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboParentCustomer.FormattingEnabled = True
        Me.cboParentCustomer.Location = New System.Drawing.Point(128, 118)
        Me.cboParentCustomer.Name = "cboParentCustomer"
        Me.cboParentCustomer.Size = New System.Drawing.Size(254, 23)
        Me.cboParentCustomer.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(304, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 15)
        Me.Label3.TabIndex = 306
        Me.Label3.Text = "Delivery Address:"
        '
        'txtAlternatePhone
        '
        Me.txtAlternatePhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlternatePhone.Location = New System.Drawing.Point(671, 118)
        Me.txtAlternatePhone.Name = "txtAlternatePhone"
        Me.txtAlternatePhone.Size = New System.Drawing.Size(105, 21)
        Me.txtAlternatePhone.TabIndex = 25
        '
        'txtDeliveryAddress
        '
        Me.txtDeliveryAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryAddress.Location = New System.Drawing.Point(410, 64)
        Me.txtDeliveryAddress.Name = "txtDeliveryAddress"
        Me.txtDeliveryAddress.ReadOnly = True
        Me.txtDeliveryAddress.Size = New System.Drawing.Size(341, 21)
        Me.txtDeliveryAddress.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 15)
        Me.Label1.TabIndex = 306
        Me.Label1.Text = "Customer No.:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(571, 121)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 15)
        Me.Label17.TabIndex = 296
        Me.Label17.Text = "Alternate Phone:"
        '
        'txtCustomerNo
        '
        Me.txtCustomerNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerNo.Location = New System.Drawing.Point(128, 64)
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
        Me.Label52.Location = New System.Drawing.Point(8, 94)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(100, 15)
        Me.Label52.TabIndex = 272
        Me.Label52.Text = "Customer Name:"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(8, 150)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(77, 15)
        Me.Label42.TabIndex = 292
        Me.Label42.Text = "Main Phone:"
        '
        'txtMainPhone
        '
        Me.txtMainPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMainPhone.Location = New System.Drawing.Point(128, 147)
        Me.txtMainPhone.Name = "txtMainPhone"
        Me.txtMainPhone.Size = New System.Drawing.Size(254, 21)
        Me.txtMainPhone.TabIndex = 17
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(55, 200)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(80, 21)
        Me.txtStatus.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(449, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 419
        Me.Label4.Text = "Delivery Hours:"
        '
        'txtDeliveryHours
        '
        Me.txtDeliveryHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryHours.Location = New System.Drawing.Point(410, 186)
        Me.txtDeliveryHours.Multiline = True
        Me.txtDeliveryHours.Name = "txtDeliveryHours"
        Me.txtDeliveryHours.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDeliveryHours.Size = New System.Drawing.Size(170, 66)
        Me.txtDeliveryHours.TabIndex = 28
        '
        'pbAddBranchCodeName
        '
        Me.pbAddBranchCodeName.BackColor = System.Drawing.Color.Transparent
        Me.pbAddBranchCodeName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddBranchCodeName.Image = CType(resources.GetObject("pbAddBranchCodeName.Image"), System.Drawing.Image)
        Me.pbAddBranchCodeName.Location = New System.Drawing.Point(368, 232)
        Me.pbAddBranchCodeName.Name = "pbAddBranchCodeName"
        Me.pbAddBranchCodeName.Size = New System.Drawing.Size(14, 18)
        Me.pbAddBranchCodeName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddBranchCodeName.TabIndex = 439
        Me.pbAddBranchCodeName.TabStop = False
        Me.pbAddBranchCodeName.Tag = ""
        '
        'cboBranchCodeNameInfo
        '
        Me.cboBranchCodeNameInfo.BackColor = System.Drawing.SystemColors.Window
        Me.cboBranchCodeNameInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranchCodeNameInfo.FormattingEnabled = True
        Me.cboBranchCodeNameInfo.Location = New System.Drawing.Point(159, 229)
        Me.cboBranchCodeNameInfo.Name = "cboBranchCodeNameInfo"
        Me.cboBranchCodeNameInfo.Size = New System.Drawing.Size(205, 23)
        Me.cboBranchCodeNameInfo.TabIndex = 21
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(8, 232)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(147, 15)
        Me.Label41.TabIndex = 438
        Me.Label41.Text = "Branch Code / Name Info:"
        '
        'pbAutoAddA
        '
        Me.pbAutoAddA.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddA.Image = CType(resources.GetObject("pbAutoAddA.Image"), System.Drawing.Image)
        Me.pbAutoAddA.Location = New System.Drawing.Point(368, 203)
        Me.pbAutoAddA.Name = "pbAutoAddA"
        Me.pbAutoAddA.Size = New System.Drawing.Size(14, 18)
        Me.pbAutoAddA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddA.TabIndex = 531
        Me.pbAutoAddA.TabStop = False
        Me.pbAutoAddA.Tag = ""
        '
        'AddCustomersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(789, 261)
        Me.Controls.Add(Me.pbAutoAddA)
        Me.Controls.Add(Me.pbAddBranchCodeName)
        Me.Controls.Add(Me.cboBranchCodeNameInfo)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDeliveryHours)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.cboPickingGroup)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.cboParentCustomer)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtMainPhone)
        Me.Controls.Add(Me.pbEditContactPerson)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.txtContactPerson)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtCustomerNo)
        Me.Controls.Add(Me.txtTIN)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.txtDeliveryAddress)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAlternatePhone)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtWebsite)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtFaxNo)
        Me.Controls.Add(Me.txtEmailAddress)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.pbEditDeliveryAddress)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddCustomersForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.pbEditContactPerson, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEditDeliveryAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddBranchCodeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboPickingGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pbEditContactPerson As System.Windows.Forms.PictureBox
    Friend WithEvents txtContactPerson As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTIN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtWebsite As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents pbEditDeliveryAddress As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFaxNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents cboParentCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAlternatePhone As System.Windows.Forms.TextBox
    Friend WithEvents txtDeliveryAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerNo As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtMainPhone As System.Windows.Forms.TextBox
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryHours As System.Windows.Forms.TextBox
    Friend WithEvents pbAddBranchCodeName As System.Windows.Forms.PictureBox
    Friend WithEvents cboBranchCodeNameInfo As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents pbAutoAddA As System.Windows.Forms.PictureBox
End Class
