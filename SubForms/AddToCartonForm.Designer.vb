<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddToCartonForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddToCartonForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtPackingListNo = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtCustomerOrderInfo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgCustomerOrderItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.txtTotalQtyInCartonSum = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalItems = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalQtyPicked = New System.Windows.Forms.TextBox()
        Me.gbOptions = New System.Windows.Forms.GroupBox()
        Me.pbAutoAddA = New System.Windows.Forms.PictureBox()
        Me.pbAddSize = New System.Windows.Forms.PictureBox()
        Me.cboSizeInfo = New System.Windows.Forms.ComboBox()
        Me.lblSizeInfo = New System.Windows.Forms.Label()
        Me.lblPesoSign = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.lblWeightUOM = New System.Windows.Forms.Label()
        Me.cboWeightUOM = New System.Windows.Forms.ComboBox()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.lblWeight = New System.Windows.Forms.Label()
        Me.dtpPackedDate = New System.Windows.Forms.DateTimePicker()
        Me.lblPackedDate = New System.Windows.Forms.Label()
        Me.pbAddPacker = New System.Windows.Forms.PictureBox()
        Me.cboPackerName = New System.Windows.Forms.ComboBox()
        Me.lblPackerName = New System.Windows.Forms.Label()
        Me.txtCartonNo = New System.Windows.Forms.TextBox()
        Me.lblCartonNoA = New System.Windows.Forms.Label()
        Me.lblCartonNoAsteriskA = New System.Windows.Forms.Label()
        Me.lblCartonNoAsteriskE = New System.Windows.Forms.Label()
        Me.cboCartonNo = New System.Windows.Forms.ComboBox()
        Me.lblCartonNoE = New System.Windows.Forms.Label()
        Me.rbtnAddNewCarton = New System.Windows.Forms.RadioButton()
        Me.rbtnExistingCarton = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.chkPackAll = New System.Windows.Forms.CheckBox()
        Me.ci_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtyordered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtypicked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_totalqtyincarton = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.ci_qtytopack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_tags = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_packedby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_packeddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.msMenu.SuspendLayout()
        CType(Me.dgCustomerOrderItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOptions.SuspendLayout()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddPacker, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(684, 28)
        Me.lblTitle.TabIndex = 494
        Me.lblTitle.Text = "Add To Box"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSave})
        Me.msMenu.Location = New System.Drawing.Point(0, 28)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(684, 25)
        Me.msMenu.TabIndex = 1
        '
        'msSave
        '
        Me.msSave.Image = CType(resources.GetObject("msSave.Image"), System.Drawing.Image)
        Me.msSave.Name = "msSave"
        Me.msSave.Size = New System.Drawing.Size(64, 21)
        Me.msSave.Text = "&Save"
        '
        'txtPackingListNo
        '
        Me.txtPackingListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPackingListNo.Location = New System.Drawing.Point(138, 49)
        Me.txtPackingListNo.Name = "txtPackingListNo"
        Me.txtPackingListNo.ReadOnly = True
        Me.txtPackingListNo.Size = New System.Drawing.Size(125, 21)
        Me.txtPackingListNo.TabIndex = 2
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(38, 52)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(98, 15)
        Me.Label52.TabIndex = 497
        Me.Label52.Text = "Packing List No.:"
        '
        'txtCustomerOrderInfo
        '
        Me.txtCustomerOrderInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerOrderInfo.Location = New System.Drawing.Point(404, 49)
        Me.txtCustomerOrderInfo.Name = "txtCustomerOrderInfo"
        Me.txtCustomerOrderInfo.ReadOnly = True
        Me.txtCustomerOrderInfo.Size = New System.Drawing.Size(235, 21)
        Me.txtCustomerOrderInfo.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(278, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 15)
        Me.Label10.TabIndex = 499
        Me.Label10.Text = "Customer Order Info.:"
        '
        'dgCustomerOrderItems
        '
        Me.dgCustomerOrderItems.AllowUserToAddRows = False
        Me.dgCustomerOrderItems.AllowUserToDeleteRows = False
        Me.dgCustomerOrderItems.AllowUserToOrderColumns = True
        Me.dgCustomerOrderItems.AllowUserToResizeRows = False
        Me.dgCustomerOrderItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerOrderItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCustomerOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomerOrderItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ci_rowid, Me.ci_colorvalue, Me.ci_seqno, Me.ci_productcode, Me.ci_colorname, Me.ci_color, Me.ci_size, Me.ci_seasoncode, Me.ci_qtyordered, Me.ci_qtypicked, Me.ci_totalqtyincarton, Me.ci_qtytopack, Me.ci_status, Me.ci_sku, Me.ci_unitofmeasure, Me.ci_remarks, Me.ci_tags, Me.ci_packedby, Me.ci_packeddate})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCustomerOrderItems.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCustomerOrderItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCustomerOrderItems.Location = New System.Drawing.Point(12, 76)
        Me.dgCustomerOrderItems.MultiSelect = False
        Me.dgCustomerOrderItems.Name = "dgCustomerOrderItems"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerOrderItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgCustomerOrderItems.RowHeadersVisible = False
        Me.dgCustomerOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCustomerOrderItems.Size = New System.Drawing.Size(660, 210)
        Me.dgCustomerOrderItems.TabIndex = 4
        '
        'txtTotalQtyInCartonSum
        '
        Me.txtTotalQtyInCartonSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyInCartonSum.Location = New System.Drawing.Point(555, 292)
        Me.txtTotalQtyInCartonSum.Name = "txtTotalQtyInCartonSum"
        Me.txtTotalQtyInCartonSum.ReadOnly = True
        Me.txtTotalQtyInCartonSum.Size = New System.Drawing.Size(90, 21)
        Me.txtTotalQtyInCartonSum.TabIndex = 8
        Me.txtTotalQtyInCartonSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(465, 290)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 26)
        Me.Label3.TabIndex = 506
        Me.Label3.Text = "Total Qty. In " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Box (Sum):"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalItems
        '
        Me.txtTotalItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalItems.Location = New System.Drawing.Point(169, 292)
        Me.txtTotalItems.Name = "txtTotalItems"
        Me.txtTotalItems.ReadOnly = True
        Me.txtTotalItems.Size = New System.Drawing.Size(90, 21)
        Me.txtTotalItems.TabIndex = 6
        Me.txtTotalItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(122, 289)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 26)
        Me.Label8.TabIndex = 505
        Me.Label8.Text = "Total" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Items:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(283, 290)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 26)
        Me.Label7.TabIndex = 504
        Me.Label7.Text = "Total Qty." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Picked:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalQtyPicked
        '
        Me.txtTotalQtyPicked.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyPicked.Location = New System.Drawing.Point(352, 292)
        Me.txtTotalQtyPicked.Name = "txtTotalQtyPicked"
        Me.txtTotalQtyPicked.ReadOnly = True
        Me.txtTotalQtyPicked.Size = New System.Drawing.Size(90, 21)
        Me.txtTotalQtyPicked.TabIndex = 7
        Me.txtTotalQtyPicked.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbOptions
        '
        Me.gbOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbOptions.Controls.Add(Me.pbAutoAddA)
        Me.gbOptions.Controls.Add(Me.pbAddSize)
        Me.gbOptions.Controls.Add(Me.cboSizeInfo)
        Me.gbOptions.Controls.Add(Me.lblSizeInfo)
        Me.gbOptions.Controls.Add(Me.lblPesoSign)
        Me.gbOptions.Controls.Add(Me.txtAmount)
        Me.gbOptions.Controls.Add(Me.lblAmount)
        Me.gbOptions.Controls.Add(Me.lblWeightUOM)
        Me.gbOptions.Controls.Add(Me.cboWeightUOM)
        Me.gbOptions.Controls.Add(Me.txtWeight)
        Me.gbOptions.Controls.Add(Me.lblWeight)
        Me.gbOptions.Controls.Add(Me.dtpPackedDate)
        Me.gbOptions.Controls.Add(Me.lblPackedDate)
        Me.gbOptions.Controls.Add(Me.pbAddPacker)
        Me.gbOptions.Controls.Add(Me.cboPackerName)
        Me.gbOptions.Controls.Add(Me.lblPackerName)
        Me.gbOptions.Controls.Add(Me.txtCartonNo)
        Me.gbOptions.Controls.Add(Me.lblCartonNoA)
        Me.gbOptions.Controls.Add(Me.lblCartonNoAsteriskA)
        Me.gbOptions.Controls.Add(Me.lblCartonNoAsteriskE)
        Me.gbOptions.Controls.Add(Me.cboCartonNo)
        Me.gbOptions.Controls.Add(Me.lblCartonNoE)
        Me.gbOptions.Controls.Add(Me.rbtnAddNewCarton)
        Me.gbOptions.Controls.Add(Me.rbtnExistingCarton)
        Me.gbOptions.Controls.Add(Me.Label9)
        Me.gbOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbOptions.Location = New System.Drawing.Point(33, 320)
        Me.gbOptions.Name = "gbOptions"
        Me.gbOptions.Size = New System.Drawing.Size(620, 180)
        Me.gbOptions.TabIndex = 9
        Me.gbOptions.TabStop = False
        '
        'pbAutoAddA
        '
        Me.pbAutoAddA.BackColor = System.Drawing.Color.Transparent
        Me.pbAutoAddA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAutoAddA.Image = CType(resources.GetObject("pbAutoAddA.Image"), System.Drawing.Image)
        Me.pbAutoAddA.Location = New System.Drawing.Point(476, 123)
        Me.pbAutoAddA.Name = "pbAutoAddA"
        Me.pbAutoAddA.Size = New System.Drawing.Size(19, 16)
        Me.pbAutoAddA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAutoAddA.TabIndex = 531
        Me.pbAutoAddA.TabStop = False
        Me.pbAutoAddA.Tag = ""
        '
        'pbAddSize
        '
        Me.pbAddSize.BackColor = System.Drawing.Color.Transparent
        Me.pbAddSize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddSize.Image = CType(resources.GetObject("pbAddSize.Image"), System.Drawing.Image)
        Me.pbAddSize.Location = New System.Drawing.Point(407, 149)
        Me.pbAddSize.Name = "pbAddSize"
        Me.pbAddSize.Size = New System.Drawing.Size(14, 18)
        Me.pbAddSize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddSize.TabIndex = 529
        Me.pbAddSize.TabStop = False
        Me.pbAddSize.Tag = ""
        '
        'cboSizeInfo
        '
        Me.cboSizeInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSizeInfo.FormattingEnabled = True
        Me.cboSizeInfo.Location = New System.Drawing.Point(113, 147)
        Me.cboSizeInfo.Name = "cboSizeInfo"
        Me.cboSizeInfo.Size = New System.Drawing.Size(290, 23)
        Me.cboSizeInfo.TabIndex = 18
        '
        'lblSizeInfo
        '
        Me.lblSizeInfo.AutoSize = True
        Me.lblSizeInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSizeInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSizeInfo.Location = New System.Drawing.Point(50, 150)
        Me.lblSizeInfo.Name = "lblSizeInfo"
        Me.lblSizeInfo.Size = New System.Drawing.Size(57, 15)
        Me.lblSizeInfo.TabIndex = 528
        Me.lblSizeInfo.Text = "Size Info:"
        '
        'lblPesoSign
        '
        Me.lblPesoSign.AutoSize = True
        Me.lblPesoSign.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesoSign.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPesoSign.Location = New System.Drawing.Point(487, 150)
        Me.lblPesoSign.Name = "lblPesoSign"
        Me.lblPesoSign.Size = New System.Drawing.Size(23, 15)
        Me.lblPesoSign.TabIndex = 526
        Me.lblPesoSign.Text = "(₱)"
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(511, 147)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(95, 21)
        Me.txtAmount.TabIndex = 19
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAmount.Location = New System.Drawing.Point(434, 150)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(52, 15)
        Me.lblAmount.TabIndex = 525
        Me.lblAmount.Text = "Amount:"
        '
        'lblWeightUOM
        '
        Me.lblWeightUOM.AutoSize = True
        Me.lblWeightUOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeightUOM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWeightUOM.Location = New System.Drawing.Point(496, 123)
        Me.lblWeightUOM.Name = "lblWeightUOM"
        Me.lblWeightUOM.Size = New System.Drawing.Size(104, 15)
        Me.lblWeightUOM.TabIndex = 523
        Me.lblWeightUOM.Text = "(Unit Of Measure)"
        '
        'cboWeightUOM
        '
        Me.cboWeightUOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboWeightUOM.FormattingEnabled = True
        Me.cboWeightUOM.Location = New System.Drawing.Point(407, 120)
        Me.cboWeightUOM.Name = "cboWeightUOM"
        Me.cboWeightUOM.Size = New System.Drawing.Size(64, 23)
        Me.cboWeightUOM.TabIndex = 17
        '
        'txtWeight
        '
        Me.txtWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(335, 120)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(66, 21)
        Me.txtWeight.TabIndex = 16
        '
        'lblWeight
        '
        Me.lblWeight.AutoSize = True
        Me.lblWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWeight.Location = New System.Drawing.Point(282, 120)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(48, 15)
        Me.lblWeight.TabIndex = 522
        Me.lblWeight.Text = "Weight:"
        '
        'dtpPackedDate
        '
        Me.dtpPackedDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpPackedDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPackedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpPackedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPackedDate.Location = New System.Drawing.Point(132, 120)
        Me.dtpPackedDate.Name = "dtpPackedDate"
        Me.dtpPackedDate.Size = New System.Drawing.Size(110, 21)
        Me.dtpPackedDate.TabIndex = 15
        '
        'lblPackedDate
        '
        Me.lblPackedDate.AutoSize = True
        Me.lblPackedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackedDate.Location = New System.Drawing.Point(50, 120)
        Me.lblPackedDate.Name = "lblPackedDate"
        Me.lblPackedDate.Size = New System.Drawing.Size(80, 15)
        Me.lblPackedDate.TabIndex = 454
        Me.lblPackedDate.Text = "Packed Date:"
        '
        'pbAddPacker
        '
        Me.pbAddPacker.BackColor = System.Drawing.Color.Transparent
        Me.pbAddPacker.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddPacker.Image = CType(resources.GetObject("pbAddPacker.Image"), System.Drawing.Image)
        Me.pbAddPacker.Location = New System.Drawing.Point(589, 94)
        Me.pbAddPacker.Name = "pbAddPacker"
        Me.pbAddPacker.Size = New System.Drawing.Size(14, 18)
        Me.pbAddPacker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddPacker.TabIndex = 453
        Me.pbAddPacker.TabStop = False
        Me.pbAddPacker.Tag = ""
        '
        'cboPackerName
        '
        Me.cboPackerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPackerName.FormattingEnabled = True
        Me.cboPackerName.Location = New System.Drawing.Point(335, 92)
        Me.cboPackerName.Name = "cboPackerName"
        Me.cboPackerName.Size = New System.Drawing.Size(251, 23)
        Me.cboPackerName.TabIndex = 14
        '
        'lblPackerName
        '
        Me.lblPackerName.AutoSize = True
        Me.lblPackerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackerName.Location = New System.Drawing.Point(245, 95)
        Me.lblPackerName.Name = "lblPackerName"
        Me.lblPackerName.Size = New System.Drawing.Size(85, 15)
        Me.lblPackerName.TabIndex = 452
        Me.lblPackerName.Text = "Packer Name:"
        '
        'txtCartonNo
        '
        Me.txtCartonNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCartonNo.Location = New System.Drawing.Point(120, 92)
        Me.txtCartonNo.Name = "txtCartonNo"
        Me.txtCartonNo.Size = New System.Drawing.Size(110, 21)
        Me.txtCartonNo.TabIndex = 13
        '
        'lblCartonNoA
        '
        Me.lblCartonNoA.AutoSize = True
        Me.lblCartonNoA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartonNoA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCartonNoA.Location = New System.Drawing.Point(50, 95)
        Me.lblCartonNoA.Name = "lblCartonNoA"
        Me.lblCartonNoA.Size = New System.Drawing.Size(53, 15)
        Me.lblCartonNoA.TabIndex = 449
        Me.lblCartonNoA.Text = "Box No.:"
        '
        'lblCartonNoAsteriskA
        '
        Me.lblCartonNoAsteriskA.AutoSize = True
        Me.lblCartonNoAsteriskA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartonNoAsteriskA.ForeColor = System.Drawing.Color.Red
        Me.lblCartonNoAsteriskA.Location = New System.Drawing.Point(105, 92)
        Me.lblCartonNoAsteriskA.Name = "lblCartonNoAsteriskA"
        Me.lblCartonNoAsteriskA.Size = New System.Drawing.Size(16, 20)
        Me.lblCartonNoAsteriskA.TabIndex = 450
        Me.lblCartonNoAsteriskA.Text = "*"
        '
        'lblCartonNoAsteriskE
        '
        Me.lblCartonNoAsteriskE.AutoSize = True
        Me.lblCartonNoAsteriskE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartonNoAsteriskE.ForeColor = System.Drawing.Color.Red
        Me.lblCartonNoAsteriskE.Location = New System.Drawing.Point(128, 42)
        Me.lblCartonNoAsteriskE.Name = "lblCartonNoAsteriskE"
        Me.lblCartonNoAsteriskE.Size = New System.Drawing.Size(16, 20)
        Me.lblCartonNoAsteriskE.TabIndex = 447
        Me.lblCartonNoAsteriskE.Text = "*"
        '
        'cboCartonNo
        '
        Me.cboCartonNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCartonNo.FormattingEnabled = True
        Me.cboCartonNo.Location = New System.Drawing.Point(145, 42)
        Me.cboCartonNo.Name = "cboCartonNo"
        Me.cboCartonNo.Size = New System.Drawing.Size(110, 23)
        Me.cboCartonNo.TabIndex = 11
        '
        'lblCartonNoE
        '
        Me.lblCartonNoE.AutoSize = True
        Me.lblCartonNoE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartonNoE.Location = New System.Drawing.Point(77, 45)
        Me.lblCartonNoE.Name = "lblCartonNoE"
        Me.lblCartonNoE.Size = New System.Drawing.Size(53, 15)
        Me.lblCartonNoE.TabIndex = 446
        Me.lblCartonNoE.Text = "Box No.:"
        '
        'rbtnAddNewCarton
        '
        Me.rbtnAddNewCarton.AutoSize = True
        Me.rbtnAddNewCarton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAddNewCarton.Location = New System.Drawing.Point(36, 70)
        Me.rbtnAddNewCarton.Name = "rbtnAddNewCarton"
        Me.rbtnAddNewCarton.Size = New System.Drawing.Size(109, 19)
        Me.rbtnAddNewCarton.TabIndex = 12
        Me.rbtnAddNewCarton.TabStop = True
        Me.rbtnAddNewCarton.Text = "Add New Box"
        Me.rbtnAddNewCarton.UseVisualStyleBackColor = True
        '
        'rbtnExistingCarton
        '
        Me.rbtnExistingCarton.AutoSize = True
        Me.rbtnExistingCarton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnExistingCarton.Location = New System.Drawing.Point(36, 19)
        Me.rbtnExistingCarton.Name = "rbtnExistingCarton"
        Me.rbtnExistingCarton.Size = New System.Drawing.Size(104, 19)
        Me.rbtnExistingCarton.TabIndex = 10
        Me.rbtnExistingCarton.TabStop = True
        Me.rbtnExistingCarton.Text = "Existing Box"
        Me.rbtnExistingCarton.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(9, -2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 17)
        Me.Label9.TabIndex = 228
        Me.Label9.Text = "Options:"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'chkPackAll
        '
        Me.chkPackAll.AutoSize = True
        Me.chkPackAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPackAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPackAll.Location = New System.Drawing.Point(27, 293)
        Me.chkPackAll.Name = "chkPackAll"
        Me.chkPackAll.Size = New System.Drawing.Size(72, 19)
        Me.chkPackAll.TabIndex = 5
        Me.chkPackAll.Text = "Pack All:"
        Me.chkPackAll.UseVisualStyleBackColor = True
        '
        'ci_rowid
        '
        Me.ci_rowid.HeaderText = "rowid"
        Me.ci_rowid.Name = "ci_rowid"
        Me.ci_rowid.Visible = False
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
        'ci_qtyordered
        '
        Me.ci_qtyordered.HeaderText = "Qty. Ordered"
        Me.ci_qtyordered.Name = "ci_qtyordered"
        Me.ci_qtyordered.ReadOnly = True
        Me.ci_qtyordered.Width = 60
        '
        'ci_qtypicked
        '
        Me.ci_qtypicked.HeaderText = "Qty. Picked"
        Me.ci_qtypicked.Name = "ci_qtypicked"
        Me.ci_qtypicked.ReadOnly = True
        Me.ci_qtypicked.Width = 60
        '
        'ci_totalqtyincarton
        '
        Me.ci_totalqtyincarton.HeaderText = "Total Qty. In Box"
        Me.ci_totalqtyincarton.Name = "ci_totalqtyincarton"
        Me.ci_totalqtyincarton.ReadOnly = True
        Me.ci_totalqtyincarton.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ci_totalqtyincarton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ci_totalqtyincarton.Width = 80
        '
        'ci_qtytopack
        '
        Me.ci_qtytopack.HeaderText = "Qty. To Pack"
        Me.ci_qtytopack.Name = "ci_qtytopack"
        Me.ci_qtytopack.Width = 68
        '
        'ci_status
        '
        Me.ci_status.HeaderText = "Status"
        Me.ci_status.Name = "ci_status"
        Me.ci_status.ReadOnly = True
        Me.ci_status.Width = 80
        '
        'ci_sku
        '
        Me.ci_sku.HeaderText = "SKU"
        Me.ci_sku.Name = "ci_sku"
        Me.ci_sku.ReadOnly = True
        '
        'ci_unitofmeasure
        '
        Me.ci_unitofmeasure.HeaderText = "Unit Of Measure"
        Me.ci_unitofmeasure.Name = "ci_unitofmeasure"
        Me.ci_unitofmeasure.ReadOnly = True
        Me.ci_unitofmeasure.Width = 70
        '
        'ci_remarks
        '
        Me.ci_remarks.HeaderText = "Remarks"
        Me.ci_remarks.Name = "ci_remarks"
        Me.ci_remarks.ReadOnly = True
        '
        'ci_tags
        '
        Me.ci_tags.HeaderText = "Tags"
        Me.ci_tags.Name = "ci_tags"
        Me.ci_tags.ReadOnly = True
        Me.ci_tags.Width = 90
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
        'AddToCartonForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(684, 512)
        Me.Controls.Add(Me.chkPackAll)
        Me.Controls.Add(Me.gbOptions)
        Me.Controls.Add(Me.txtTotalQtyInCartonSum)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTotalItems)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTotalQtyPicked)
        Me.Controls.Add(Me.dgCustomerOrderItems)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCustomerOrderInfo)
        Me.Controls.Add(Me.txtPackingListNo)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddToCartonForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.dgCustomerOrderItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOptions.ResumeLayout(False)
        Me.gbOptions.PerformLayout()
        CType(Me.pbAutoAddA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddPacker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtPackingListNo As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerOrderInfo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgCustomerOrderItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtTotalQtyInCartonSum As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalItems As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQtyPicked As System.Windows.Forms.TextBox
    Friend WithEvents gbOptions As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rbtnExistingCarton As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnAddNewCarton As System.Windows.Forms.RadioButton
    Friend WithEvents lblCartonNoAsteriskE As System.Windows.Forms.Label
    Friend WithEvents cboCartonNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblCartonNoE As System.Windows.Forms.Label
    Friend WithEvents txtCartonNo As System.Windows.Forms.TextBox
    Friend WithEvents lblCartonNoA As System.Windows.Forms.Label
    Friend WithEvents lblCartonNoAsteriskA As System.Windows.Forms.Label
    Friend WithEvents cboPackerName As System.Windows.Forms.ComboBox
    Friend WithEvents lblPackerName As System.Windows.Forms.Label
    Friend WithEvents pbAddPacker As System.Windows.Forms.PictureBox
    Friend WithEvents lblPackedDate As System.Windows.Forms.Label
    Friend WithEvents dtpPackedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents chkPackAll As System.Windows.Forms.CheckBox
    Friend WithEvents lblWeightUOM As System.Windows.Forms.Label
    Friend WithEvents cboWeightUOM As System.Windows.Forms.ComboBox
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents lblWeight As System.Windows.Forms.Label
    Friend WithEvents lblPesoSign As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents pbAddSize As System.Windows.Forms.PictureBox
    Friend WithEvents cboSizeInfo As System.Windows.Forms.ComboBox
    Friend WithEvents lblSizeInfo As System.Windows.Forms.Label
    Friend WithEvents pbAutoAddA As System.Windows.Forms.PictureBox
    Friend WithEvents ci_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtyordered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtypicked As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_totalqtyincarton As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ci_qtytopack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_tags As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_packedby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_packeddate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
