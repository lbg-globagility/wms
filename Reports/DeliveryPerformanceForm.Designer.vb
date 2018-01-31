<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeliveryPerformanceForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeliveryPerformanceForm))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.gbFilter = New System.Windows.Forms.GroupBox()
        Me.pnlOptions = New System.Windows.Forms.Panel()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.cboMonths = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbProducts = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtLatePercentage = New System.Windows.Forms.TextBox()
        Me.txtTotalLate = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOnTimePercentage = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalOnTime = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalDeliveries = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgDeliveries = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.d_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_cono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_pono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_sidrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_lineupno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_codate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_datesubmitted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_receiptdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_canceldate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_deliverydate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_customername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFilter.SuspendLayout()
        Me.pnlOptions.SuspendLayout()
        Me.gbProducts.SuspendLayout()
        CType(Me.dgDeliveries, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.TabIndex = 13
        Me.lblTitle.Text = "Delivery Perfomance"
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
        Me.pbClose.TabIndex = 238
        Me.pbClose.TabStop = False
        '
        'gbFilter
        '
        Me.gbFilter.Controls.Add(Me.pnlOptions)
        Me.gbFilter.Controls.Add(Me.Label2)
        Me.gbFilter.Controls.Add(Me.txtYear)
        Me.gbFilter.Controls.Add(Me.Label51)
        Me.gbFilter.Controls.Add(Me.cboMonths)
        Me.gbFilter.Controls.Add(Me.Label1)
        Me.gbFilter.Controls.Add(Me.Label3)
        Me.gbFilter.Location = New System.Drawing.Point(20, 40)
        Me.gbFilter.Name = "gbFilter"
        Me.gbFilter.Size = New System.Drawing.Size(600, 50)
        Me.gbFilter.TabIndex = 1
        Me.gbFilter.TabStop = False
        '
        'pnlOptions
        '
        Me.pnlOptions.BackColor = System.Drawing.Color.Salmon
        Me.pnlOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOptions.Controls.Add(Me.btnEnter)
        Me.pnlOptions.Controls.Add(Me.btnPrint)
        Me.pnlOptions.Location = New System.Drawing.Point(340, 7)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(245, 42)
        Me.pnlOptions.TabIndex = 18
        '
        'btnEnter
        '
        Me.btnEnter.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnEnter.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnter.Location = New System.Drawing.Point(18, 2)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(95, 35)
        Me.btnEnter.TabIndex = 5
        Me.btnEnter.Text = "Enter"
        Me.btnEnter.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.Location = New System.Drawing.Point(128, 2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(95, 35)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "   Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(212, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 20)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "*"
        '
        'txtYear
        '
        Me.txtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYear.Location = New System.Drawing.Point(231, 17)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(80, 21)
        Me.txtYear.TabIndex = 4
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label51.Location = New System.Drawing.Point(181, 21)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(35, 15)
        Me.Label51.TabIndex = 16
        Me.Label51.Text = "Year:"
        '
        'cboMonths
        '
        Me.cboMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonths.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonths.FormattingEnabled = True
        Me.cboMonths.Location = New System.Drawing.Point(65, 17)
        Me.cboMonths.Name = "cboMonths"
        Me.cboMonths.Size = New System.Drawing.Size(100, 23)
        Me.cboMonths.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(20, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Month:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(6, -4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Filters:"
        '
        'gbProducts
        '
        Me.gbProducts.Controls.Add(Me.Label9)
        Me.gbProducts.Controls.Add(Me.txtLatePercentage)
        Me.gbProducts.Controls.Add(Me.txtTotalLate)
        Me.gbProducts.Controls.Add(Me.Label8)
        Me.gbProducts.Controls.Add(Me.txtOnTimePercentage)
        Me.gbProducts.Controls.Add(Me.Label7)
        Me.gbProducts.Controls.Add(Me.txtTotalOnTime)
        Me.gbProducts.Controls.Add(Me.Label6)
        Me.gbProducts.Controls.Add(Me.txtTotalDeliveries)
        Me.gbProducts.Controls.Add(Me.Label5)
        Me.gbProducts.Controls.Add(Me.dgDeliveries)
        Me.gbProducts.Controls.Add(Me.Label4)
        Me.gbProducts.Location = New System.Drawing.Point(20, 95)
        Me.gbProducts.Name = "gbProducts"
        Me.gbProducts.Size = New System.Drawing.Size(1100, 450)
        Me.gbProducts.TabIndex = 2
        Me.gbProducts.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(955, 426)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 15)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "%"
        '
        'txtLatePercentage
        '
        Me.txtLatePercentage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLatePercentage.Location = New System.Drawing.Point(905, 423)
        Me.txtLatePercentage.Name = "txtLatePercentage"
        Me.txtLatePercentage.ReadOnly = True
        Me.txtLatePercentage.Size = New System.Drawing.Size(48, 21)
        Me.txtLatePercentage.TabIndex = 12
        Me.txtLatePercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalLate
        '
        Me.txtTotalLate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalLate.Location = New System.Drawing.Point(825, 423)
        Me.txtTotalLate.Name = "txtTotalLate"
        Me.txtTotalLate.ReadOnly = True
        Me.txtTotalLate.Size = New System.Drawing.Size(75, 21)
        Me.txtTotalLate.TabIndex = 11
        Me.txtTotalLate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(695, 426)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 15)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "%"
        '
        'txtOnTimePercentage
        '
        Me.txtOnTimePercentage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOnTimePercentage.Location = New System.Drawing.Point(645, 423)
        Me.txtOnTimePercentage.Name = "txtOnTimePercentage"
        Me.txtOnTimePercentage.ReadOnly = True
        Me.txtOnTimePercentage.Size = New System.Drawing.Size(48, 21)
        Me.txtOnTimePercentage.TabIndex = 10
        Me.txtOnTimePercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(745, 426)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 15)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Total Late:"
        '
        'txtTotalOnTime
        '
        Me.txtTotalOnTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalOnTime.Location = New System.Drawing.Point(565, 423)
        Me.txtTotalOnTime.Name = "txtTotalOnTime"
        Me.txtTotalOnTime.ReadOnly = True
        Me.txtTotalOnTime.Size = New System.Drawing.Size(75, 21)
        Me.txtTotalOnTime.TabIndex = 9
        Me.txtTotalOnTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(460, 426)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 15)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Total On-Time:"
        '
        'txtTotalDeliveries
        '
        Me.txtTotalDeliveries.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDeliveries.Location = New System.Drawing.Point(340, 423)
        Me.txtTotalDeliveries.Name = "txtTotalDeliveries"
        Me.txtTotalDeliveries.ReadOnly = True
        Me.txtTotalDeliveries.Size = New System.Drawing.Size(90, 21)
        Me.txtTotalDeliveries.TabIndex = 8
        Me.txtTotalDeliveries.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(225, 426)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 15)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Total Deliveries:"
        '
        'dgDeliveries
        '
        Me.dgDeliveries.AllowUserToAddRows = False
        Me.dgDeliveries.AllowUserToDeleteRows = False
        Me.dgDeliveries.AllowUserToOrderColumns = True
        Me.dgDeliveries.AllowUserToResizeRows = False
        Me.dgDeliveries.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDeliveries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgDeliveries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDeliveries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.d_rowid, Me.d_seqno, Me.d_cono, Me.d_pono, Me.d_sidrno, Me.d_lineupno, Me.d_codate, Me.d_datesubmitted, Me.d_receiptdate, Me.d_canceldate, Me.d_deliverydate, Me.d_status, Me.d_customername})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDeliveries.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgDeliveries.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgDeliveries.Location = New System.Drawing.Point(10, 19)
        Me.dgDeliveries.MultiSelect = False
        Me.dgDeliveries.Name = "dgDeliveries"
        Me.dgDeliveries.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDeliveries.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgDeliveries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDeliveries.Size = New System.Drawing.Size(1080, 400)
        Me.dgDeliveries.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(6, -4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 17)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Confirmed Deliveries:"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'd_rowid
        '
        Me.d_rowid.HeaderText = "rowid"
        Me.d_rowid.Name = "d_rowid"
        Me.d_rowid.ReadOnly = True
        Me.d_rowid.Visible = False
        '
        'd_seqno
        '
        Me.d_seqno.HeaderText = "Seq. No."
        Me.d_seqno.Name = "d_seqno"
        Me.d_seqno.ReadOnly = True
        Me.d_seqno.Width = 50
        '
        'd_cono
        '
        Me.d_cono.HeaderText = "Customer Order No."
        Me.d_cono.Name = "d_cono"
        Me.d_cono.ReadOnly = True
        Me.d_cono.Width = 80
        '
        'd_pono
        '
        Me.d_pono.HeaderText = "P.O. No."
        Me.d_pono.Name = "d_pono"
        Me.d_pono.ReadOnly = True
        Me.d_pono.Width = 80
        '
        'd_sidrno
        '
        Me.d_sidrno.HeaderText = "S.I./D.R. No."
        Me.d_sidrno.Name = "d_sidrno"
        Me.d_sidrno.ReadOnly = True
        Me.d_sidrno.Width = 80
        '
        'd_lineupno
        '
        Me.d_lineupno.HeaderText = "Line-Up No."
        Me.d_lineupno.Name = "d_lineupno"
        Me.d_lineupno.ReadOnly = True
        Me.d_lineupno.Width = 80
        '
        'd_codate
        '
        Me.d_codate.HeaderText = "Customer Order Date"
        Me.d_codate.Name = "d_codate"
        Me.d_codate.ReadOnly = True
        Me.d_codate.Width = 90
        '
        'd_datesubmitted
        '
        Me.d_datesubmitted.HeaderText = "Date Submitted"
        Me.d_datesubmitted.Name = "d_datesubmitted"
        Me.d_datesubmitted.ReadOnly = True
        Me.d_datesubmitted.Width = 90
        '
        'd_receiptdate
        '
        Me.d_receiptdate.HeaderText = "Receipt Date"
        Me.d_receiptdate.Name = "d_receiptdate"
        Me.d_receiptdate.ReadOnly = True
        Me.d_receiptdate.Width = 90
        '
        'd_canceldate
        '
        Me.d_canceldate.HeaderText = "Cancel Date"
        Me.d_canceldate.Name = "d_canceldate"
        Me.d_canceldate.ReadOnly = True
        Me.d_canceldate.Width = 90
        '
        'd_deliverydate
        '
        Me.d_deliverydate.HeaderText = "Delivery Date"
        Me.d_deliverydate.Name = "d_deliverydate"
        Me.d_deliverydate.ReadOnly = True
        Me.d_deliverydate.Width = 90
        '
        'd_status
        '
        Me.d_status.HeaderText = "Status"
        Me.d_status.Name = "d_status"
        Me.d_status.ReadOnly = True
        '
        'd_customername
        '
        Me.d_customername.HeaderText = "Customer Name"
        Me.d_customername.Name = "d_customername"
        Me.d_customername.ReadOnly = True
        '
        'DeliveryPerformanceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 560)
        Me.Controls.Add(Me.gbProducts)
        Me.Controls.Add(Me.gbFilter)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DeliveryPerformanceForm"
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFilter.ResumeLayout(False)
        Me.gbFilter.PerformLayout()
        Me.pnlOptions.ResumeLayout(False)
        Me.gbProducts.ResumeLayout(False)
        Me.gbProducts.PerformLayout()
        CType(Me.dgDeliveries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents gbFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMonths As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents pnlOptions As System.Windows.Forms.Panel
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents gbProducts As System.Windows.Forms.GroupBox
    Friend WithEvents dgDeliveries As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDeliveries As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalOnTime As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtOnTimePercentage As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLatePercentage As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalLate As System.Windows.Forms.TextBox
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents d_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_cono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_pono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_sidrno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_lineupno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_codate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_datesubmitted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_receiptdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_canceldate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_deliverydate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_customername As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
