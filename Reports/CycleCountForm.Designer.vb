<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CycleCountForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CycleCountForm))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dgCycleCountList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cc_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc_ccno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc_ccdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc_countby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.cmdLast = New System.Windows.Forms.ToolStripButton()
        Me.cmdNext = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrev = New System.Windows.Forms.ToolStripButton()
        Me.cmdFirst = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.gbCycleCountList = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPage = New System.Windows.Forms.TextBox()
        Me.txtPageNo = New System.Windows.Forms.TextBox()
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tabSearch = New System.Windows.Forms.TabControl()
        Me.tabSimple = New System.Windows.Forms.TabPage()
        Me.txtSimpleSearch = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tabCommon = New System.Windows.Forms.TabPage()
        Me.cboSearch2 = New System.Windows.Forms.ComboBox()
        Me.cboSearch1 = New System.Windows.Forms.ComboBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.dtpToSearch = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromSearch = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.gbCycleCountItems = New System.Windows.Forms.GroupBox()
        Me.pbAddCountedBy = New System.Windows.Forms.PictureBox()
        Me.chkAllCycle2 = New System.Windows.Forms.CheckBox()
        Me.chkAllCycle1 = New System.Windows.Forms.CheckBox()
        Me.cboCountedBy = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cmdFirstCCI = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrevCCI = New System.Windows.Forms.ToolStripButton()
        Me.cmdNextCCI = New System.Windows.Forms.ToolStripButton()
        Me.cmdLastCCI = New System.Windows.Forms.ToolStripButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPageNoCCI = New System.Windows.Forms.TextBox()
        Me.dgCycleCountItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cci_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cci_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cci_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cci_productcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cci_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cci_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cci_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cci_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cci_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cci_rackcolumnshelf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cci_qtya = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cci_countedbya = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cci_qtyb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cci_countedbyb = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cci_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.gbCycleCountInformation = New System.Windows.Forms.GroupBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtBrandName = New System.Windows.Forms.TextBox()
        Me.txtCountBy = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCycleCountDate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtCycleCountNo = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.msPrintCycle1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.msPrintCycle2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.msReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.msReportCycle1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.msReportCycle2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        CType(Me.dgCycleCountList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.gbCycleCountList.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        Me.tabSearch.SuspendLayout()
        Me.tabSimple.SuspendLayout()
        Me.tabCommon.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.gbCycleCountItems.SuspendLayout()
        CType(Me.pbAddCountedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgCycleCountItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCycleCountInformation.SuspendLayout()
        Me.msMenu.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.MistyRose
        Me.Label16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(6, -1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(121, 17)
        Me.Label16.TabIndex = 216
        Me.Label16.Text = "Cycle Count List:"
        '
        'dgCycleCountList
        '
        Me.dgCycleCountList.AllowUserToAddRows = False
        Me.dgCycleCountList.AllowUserToDeleteRows = False
        Me.dgCycleCountList.AllowUserToOrderColumns = True
        Me.dgCycleCountList.AllowUserToResizeRows = False
        Me.dgCycleCountList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgCycleCountList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCycleCountList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCycleCountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCycleCountList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cc_rowid, Me.cc_ccno, Me.cc_ccdate, Me.cc_countby})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCycleCountList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCycleCountList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCycleCountList.Location = New System.Drawing.Point(8, 68)
        Me.dgCycleCountList.MultiSelect = False
        Me.dgCycleCountList.Name = "dgCycleCountList"
        Me.dgCycleCountList.ReadOnly = True
        Me.dgCycleCountList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCycleCountList.Size = New System.Drawing.Size(324, 295)
        Me.dgCycleCountList.TabIndex = 14
        '
        'cc_rowid
        '
        Me.cc_rowid.HeaderText = "rowid"
        Me.cc_rowid.Name = "cc_rowid"
        Me.cc_rowid.ReadOnly = True
        Me.cc_rowid.Visible = False
        '
        'cc_ccno
        '
        Me.cc_ccno.HeaderText = "Cycle Count No."
        Me.cc_ccno.Name = "cc_ccno"
        Me.cc_ccno.ReadOnly = True
        '
        'cc_ccdate
        '
        Me.cc_ccdate.HeaderText = "Cycle Count Date"
        Me.cc_ccdate.Name = "cc_ccdate"
        Me.cc_ccdate.ReadOnly = True
        '
        'cc_countby
        '
        Me.cc_countby.HeaderText = "Count By"
        Me.cc_countby.Name = "cc_countby"
        Me.cc_countby.ReadOnly = True
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
        Me.ToolStrip3.TabIndex = 11
        '
        'gbCycleCountList
        '
        Me.gbCycleCountList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbCycleCountList.BackColor = System.Drawing.Color.Transparent
        Me.gbCycleCountList.Controls.Add(Me.Label4)
        Me.gbCycleCountList.Controls.Add(Me.txtPage)
        Me.gbCycleCountList.Controls.Add(Me.txtPageNo)
        Me.gbCycleCountList.Controls.Add(Me.ToolStrip3)
        Me.gbCycleCountList.Controls.Add(Me.dgCycleCountList)
        Me.gbCycleCountList.Controls.Add(Me.Label16)
        Me.gbCycleCountList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCycleCountList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCycleCountList.Location = New System.Drawing.Point(6, 152)
        Me.gbCycleCountList.Name = "gbCycleCountList"
        Me.gbCycleCountList.Size = New System.Drawing.Size(340, 369)
        Me.gbCycleCountList.TabIndex = 2
        Me.gbCycleCountList.TabStop = False
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
        Me.txtPage.TabIndex = 13
        '
        'txtPageNo
        '
        Me.txtPageNo.Location = New System.Drawing.Point(121, 43)
        Me.txtPageNo.Name = "txtPageNo"
        Me.txtPageNo.ReadOnly = True
        Me.txtPageNo.Size = New System.Drawing.Size(101, 21)
        Me.txtPageNo.TabIndex = 12
        '
        'gbSearch
        '
        Me.gbSearch.BackColor = System.Drawing.Color.Transparent
        Me.gbSearch.Controls.Add(Me.Label21)
        Me.gbSearch.Controls.Add(Me.tabSearch)
        Me.gbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSearch.Location = New System.Drawing.Point(6, 5)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(340, 140)
        Me.gbSearch.TabIndex = 1
        Me.gbSearch.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.MistyRose
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
        Me.tabSearch.Location = New System.Drawing.Point(8, 21)
        Me.tabSearch.Multiline = True
        Me.tabSearch.Name = "tabSearch"
        Me.tabSearch.SelectedIndex = 0
        Me.tabSearch.Size = New System.Drawing.Size(324, 106)
        Me.tabSearch.TabIndex = 5
        '
        'tabSimple
        '
        Me.tabSimple.Controls.Add(Me.txtSimpleSearch)
        Me.tabSimple.Controls.Add(Me.Label30)
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
        Me.txtSimpleSearch.TabIndex = 6
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
        'tabCommon
        '
        Me.tabCommon.Controls.Add(Me.cboSearch2)
        Me.tabCommon.Controls.Add(Me.cboSearch1)
        Me.tabCommon.Controls.Add(Me.Label40)
        Me.tabCommon.Controls.Add(Me.dtpToSearch)
        Me.tabCommon.Controls.Add(Me.dtpFromSearch)
        Me.tabCommon.Controls.Add(Me.Label18)
        Me.tabCommon.Location = New System.Drawing.Point(4, 29)
        Me.tabCommon.Name = "tabCommon"
        Me.tabCommon.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCommon.Size = New System.Drawing.Size(316, 73)
        Me.tabCommon.TabIndex = 0
        Me.tabCommon.Text = "       Common       "
        Me.tabCommon.UseVisualStyleBackColor = True
        '
        'cboSearch2
        '
        Me.cboSearch2.FormattingEnabled = True
        Me.cboSearch2.Location = New System.Drawing.Point(109, 38)
        Me.cboSearch2.Name = "cboSearch2"
        Me.cboSearch2.Size = New System.Drawing.Size(195, 23)
        Me.cboSearch2.TabIndex = 10
        '
        'cboSearch1
        '
        Me.cboSearch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch1.FormattingEnabled = True
        Me.cboSearch1.Location = New System.Drawing.Point(6, 38)
        Me.cboSearch1.Name = "cboSearch1"
        Me.cboSearch1.Size = New System.Drawing.Size(100, 23)
        Me.cboSearch1.TabIndex = 9
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(164, 13)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(24, 15)
        Me.Label40.TabIndex = 259
        Me.Label40.Text = "To:"
        '
        'dtpToSearch
        '
        Me.dtpToSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpToSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpToSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToSearch.Location = New System.Drawing.Point(194, 11)
        Me.dtpToSearch.Name = "dtpToSearch"
        Me.dtpToSearch.Size = New System.Drawing.Size(110, 21)
        Me.dtpToSearch.TabIndex = 8
        '
        'dtpFromSearch
        '
        Me.dtpFromSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpFromSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFromSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromSearch.Location = New System.Drawing.Point(46, 11)
        Me.dtpFromSearch.Name = "dtpFromSearch"
        Me.dtpFromSearch.Size = New System.Drawing.Size(110, 21)
        Me.dtpFromSearch.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(3, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 15)
        Me.Label18.TabIndex = 258
        Me.Label18.Text = "From:"
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.MistyRose
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbCycleCountList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbSearch)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabMain)
        Me.SplitContainer1.Panel2.Controls.Add(Me.msMenu)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblsavemsg)
        Me.SplitContainer1.Size = New System.Drawing.Size(1200, 532)
        Me.SplitContainer1.SplitterDistance = 356
        Me.SplitContainer1.TabIndex = 236
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
        Me.tabMain.Size = New System.Drawing.Size(836, 503)
        Me.tabMain.TabIndex = 223
        '
        'tabDetails
        '
        Me.tabDetails.AutoScroll = True
        Me.tabDetails.Controls.Add(Me.gbCycleCountItems)
        Me.tabDetails.Controls.Add(Me.gbCycleCountInformation)
        Me.tabDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(828, 472)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Cycle Count Details"
        Me.tabDetails.UseVisualStyleBackColor = True
        '
        'gbCycleCountItems
        '
        Me.gbCycleCountItems.Controls.Add(Me.pbAddCountedBy)
        Me.gbCycleCountItems.Controls.Add(Me.chkAllCycle2)
        Me.gbCycleCountItems.Controls.Add(Me.chkAllCycle1)
        Me.gbCycleCountItems.Controls.Add(Me.cboCountedBy)
        Me.gbCycleCountItems.Controls.Add(Me.Label5)
        Me.gbCycleCountItems.Controls.Add(Me.ToolStrip1)
        Me.gbCycleCountItems.Controls.Add(Me.Label3)
        Me.gbCycleCountItems.Controls.Add(Me.txtPageNoCCI)
        Me.gbCycleCountItems.Controls.Add(Me.dgCycleCountItems)
        Me.gbCycleCountItems.Controls.Add(Me.Label15)
        Me.gbCycleCountItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCycleCountItems.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCycleCountItems.Location = New System.Drawing.Point(6, 85)
        Me.gbCycleCountItems.Name = "gbCycleCountItems"
        Me.gbCycleCountItems.Size = New System.Drawing.Size(822, 450)
        Me.gbCycleCountItems.TabIndex = 4
        Me.gbCycleCountItems.TabStop = False
        '
        'pbAddCountedBy
        '
        Me.pbAddCountedBy.BackColor = System.Drawing.Color.Transparent
        Me.pbAddCountedBy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddCountedBy.Image = CType(resources.GetObject("pbAddCountedBy.Image"), System.Drawing.Image)
        Me.pbAddCountedBy.Location = New System.Drawing.Point(589, 21)
        Me.pbAddCountedBy.Name = "pbAddCountedBy"
        Me.pbAddCountedBy.Size = New System.Drawing.Size(14, 18)
        Me.pbAddCountedBy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddCountedBy.TabIndex = 452
        Me.pbAddCountedBy.TabStop = False
        Me.pbAddCountedBy.Tag = ""
        '
        'chkAllCycle2
        '
        Me.chkAllCycle2.AutoSize = True
        Me.chkAllCycle2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAllCycle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAllCycle2.Location = New System.Drawing.Point(713, 21)
        Me.chkAllCycle2.Name = "chkAllCycle2"
        Me.chkAllCycle2.Size = New System.Drawing.Size(84, 19)
        Me.chkAllCycle2.TabIndex = 24
        Me.chkAllCycle2.Text = "All Cycle 2:"
        Me.chkAllCycle2.UseVisualStyleBackColor = True
        '
        'chkAllCycle1
        '
        Me.chkAllCycle1.AutoSize = True
        Me.chkAllCycle1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAllCycle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAllCycle1.Location = New System.Drawing.Point(622, 21)
        Me.chkAllCycle1.Name = "chkAllCycle1"
        Me.chkAllCycle1.Size = New System.Drawing.Size(84, 19)
        Me.chkAllCycle1.TabIndex = 23
        Me.chkAllCycle1.Text = "All Cycle 1:"
        Me.chkAllCycle1.UseVisualStyleBackColor = True
        '
        'cboCountedBy
        '
        Me.cboCountedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCountedBy.FormattingEnabled = True
        Me.cboCountedBy.Location = New System.Drawing.Point(391, 20)
        Me.cboCountedBy.Name = "cboCountedBy"
        Me.cboCountedBy.Size = New System.Drawing.Size(195, 23)
        Me.cboCountedBy.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(316, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 15)
        Me.Label5.TabIndex = 427
        Me.Label5.Text = "Counted By:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdFirstCCI, Me.cmdPrevCCI, Me.cmdNextCCI, Me.cmdLastCCI})
        Me.ToolStrip1.Location = New System.Drawing.Point(187, 19)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(115, 22)
        Me.ToolStrip1.TabIndex = 21
        '
        'cmdFirstCCI
        '
        Me.cmdFirstCCI.BackColor = System.Drawing.Color.Transparent
        Me.cmdFirstCCI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdFirstCCI.Image = CType(resources.GetObject("cmdFirstCCI.Image"), System.Drawing.Image)
        Me.cmdFirstCCI.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdFirstCCI.Name = "cmdFirstCCI"
        Me.cmdFirstCCI.Size = New System.Drawing.Size(24, 19)
        Me.cmdFirstCCI.Text = "First"
        '
        'cmdPrevCCI
        '
        Me.cmdPrevCCI.BackColor = System.Drawing.Color.Transparent
        Me.cmdPrevCCI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPrevCCI.Image = CType(resources.GetObject("cmdPrevCCI.Image"), System.Drawing.Image)
        Me.cmdPrevCCI.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdPrevCCI.Name = "cmdPrevCCI"
        Me.cmdPrevCCI.Size = New System.Drawing.Size(24, 19)
        Me.cmdPrevCCI.Text = "Previous"
        '
        'cmdNextCCI
        '
        Me.cmdNextCCI.BackColor = System.Drawing.Color.Transparent
        Me.cmdNextCCI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdNextCCI.Image = CType(resources.GetObject("cmdNextCCI.Image"), System.Drawing.Image)
        Me.cmdNextCCI.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdNextCCI.Name = "cmdNextCCI"
        Me.cmdNextCCI.Size = New System.Drawing.Size(24, 19)
        Me.cmdNextCCI.Text = "Next"
        '
        'cmdLastCCI
        '
        Me.cmdLastCCI.BackColor = System.Drawing.Color.Transparent
        Me.cmdLastCCI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdLastCCI.Image = CType(resources.GetObject("cmdLastCCI.Image"), System.Drawing.Image)
        Me.cmdLastCCI.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.cmdLastCCI.Name = "cmdLastCCI"
        Me.cmdLastCCI.Size = New System.Drawing.Size(24, 19)
        Me.cmdLastCCI.Text = "Last"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(9, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 15)
        Me.Label3.TabIndex = 299
        Me.Label3.Text = "Page No.:"
        '
        'txtPageNoCCI
        '
        Me.txtPageNoCCI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPageNoCCI.Location = New System.Drawing.Point(82, 20)
        Me.txtPageNoCCI.Name = "txtPageNoCCI"
        Me.txtPageNoCCI.ReadOnly = True
        Me.txtPageNoCCI.Size = New System.Drawing.Size(101, 21)
        Me.txtPageNoCCI.TabIndex = 20
        '
        'dgCycleCountItems
        '
        Me.dgCycleCountItems.AllowUserToAddRows = False
        Me.dgCycleCountItems.AllowUserToDeleteRows = False
        Me.dgCycleCountItems.AllowUserToOrderColumns = True
        Me.dgCycleCountItems.AllowUserToResizeRows = False
        Me.dgCycleCountItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCycleCountItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgCycleCountItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCycleCountItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cci_rowid, Me.cci_colorvalue, Me.cci_seqno, Me.cci_productcode, Me.cci_colorname, Me.cci_color, Me.cci_size, Me.cci_seasoncode, Me.cci_sku, Me.cci_rackcolumnshelf, Me.cci_qtya, Me.cci_countedbya, Me.cci_qtyb, Me.cci_countedbyb, Me.cci_remarks})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCycleCountItems.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgCycleCountItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCycleCountItems.Location = New System.Drawing.Point(12, 50)
        Me.dgCycleCountItems.MultiSelect = False
        Me.dgCycleCountItems.Name = "dgCycleCountItems"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCycleCountItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgCycleCountItems.RowHeadersVisible = False
        Me.dgCycleCountItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCycleCountItems.Size = New System.Drawing.Size(785, 390)
        Me.dgCycleCountItems.TabIndex = 25
        '
        'cci_rowid
        '
        Me.cci_rowid.HeaderText = "rowid"
        Me.cci_rowid.Name = "cci_rowid"
        Me.cci_rowid.Visible = False
        '
        'cci_colorvalue
        '
        Me.cci_colorvalue.HeaderText = "colorvalue"
        Me.cci_colorvalue.Name = "cci_colorvalue"
        Me.cci_colorvalue.Visible = False
        '
        'cci_seqno
        '
        Me.cci_seqno.HeaderText = "Seq. No."
        Me.cci_seqno.Name = "cci_seqno"
        Me.cci_seqno.ReadOnly = True
        Me.cci_seqno.Width = 50
        '
        'cci_productcode
        '
        Me.cci_productcode.HeaderText = "Product Code"
        Me.cci_productcode.Name = "cci_productcode"
        Me.cci_productcode.ReadOnly = True
        '
        'cci_colorname
        '
        Me.cci_colorname.HeaderText = "Color Name"
        Me.cci_colorname.Name = "cci_colorname"
        Me.cci_colorname.ReadOnly = True
        Me.cci_colorname.Width = 60
        '
        'cci_color
        '
        Me.cci_color.HeaderText = ""
        Me.cci_color.Name = "cci_color"
        Me.cci_color.ReadOnly = True
        Me.cci_color.Width = 30
        '
        'cci_size
        '
        Me.cci_size.HeaderText = "Size"
        Me.cci_size.Name = "cci_size"
        Me.cci_size.ReadOnly = True
        Me.cci_size.Width = 40
        '
        'cci_seasoncode
        '
        Me.cci_seasoncode.HeaderText = "Season Code"
        Me.cci_seasoncode.Name = "cci_seasoncode"
        Me.cci_seasoncode.ReadOnly = True
        Me.cci_seasoncode.Width = 70
        '
        'cci_sku
        '
        Me.cci_sku.HeaderText = "SKU"
        Me.cci_sku.Name = "cci_sku"
        Me.cci_sku.ReadOnly = True
        '
        'cci_rackcolumnshelf
        '
        Me.cci_rackcolumnshelf.HeaderText = "Rack / Column / Shelf"
        Me.cci_rackcolumnshelf.Name = "cci_rackcolumnshelf"
        Me.cci_rackcolumnshelf.ReadOnly = True
        Me.cci_rackcolumnshelf.Width = 150
        '
        'cci_qtya
        '
        Me.cci_qtya.HeaderText = "Cycle 1 Qty."
        Me.cci_qtya.Name = "cci_qtya"
        Me.cci_qtya.Width = 60
        '
        'cci_countedbya
        '
        Me.cci_countedbya.HeaderText = "Cycle 1 Counted By"
        Me.cci_countedbya.Name = "cci_countedbya"
        '
        'cci_qtyb
        '
        Me.cci_qtyb.HeaderText = "Cycle 2 Qty."
        Me.cci_qtyb.Name = "cci_qtyb"
        Me.cci_qtyb.Width = 60
        '
        'cci_countedbyb
        '
        Me.cci_countedbyb.HeaderText = "Cycle 2 Counted By"
        Me.cci_countedbyb.Name = "cci_countedbyb"
        '
        'cci_remarks
        '
        Me.cci_remarks.HeaderText = "Remarks"
        Me.cci_remarks.Name = "cci_remarks"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(9, -2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(134, 17)
        Me.Label15.TabIndex = 228
        Me.Label15.Text = "Cycle Count Items:"
        '
        'gbCycleCountInformation
        '
        Me.gbCycleCountInformation.Controls.Add(Me.txtComments)
        Me.gbCycleCountInformation.Controls.Add(Me.Label25)
        Me.gbCycleCountInformation.Controls.Add(Me.txtBrandName)
        Me.gbCycleCountInformation.Controls.Add(Me.txtCountBy)
        Me.gbCycleCountInformation.Controls.Add(Me.Label2)
        Me.gbCycleCountInformation.Controls.Add(Me.txtCycleCountDate)
        Me.gbCycleCountInformation.Controls.Add(Me.Label1)
        Me.gbCycleCountInformation.Controls.Add(Me.Label51)
        Me.gbCycleCountInformation.Controls.Add(Me.txtCycleCountNo)
        Me.gbCycleCountInformation.Controls.Add(Me.Label52)
        Me.gbCycleCountInformation.Controls.Add(Me.Label55)
        Me.gbCycleCountInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCycleCountInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCycleCountInformation.Location = New System.Drawing.Point(6, 5)
        Me.gbCycleCountInformation.Name = "gbCycleCountInformation"
        Me.gbCycleCountInformation.Size = New System.Drawing.Size(800, 75)
        Me.gbCycleCountInformation.TabIndex = 3
        Me.gbCycleCountInformation.TabStop = False
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(561, 21)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(210, 46)
        Me.txtComments.TabIndex = 19
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(486, 24)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 15)
        Me.Label25.TabIndex = 436
        Me.Label25.Text = "Comments:"
        '
        'txtBrandName
        '
        Me.txtBrandName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrandName.Location = New System.Drawing.Point(334, 46)
        Me.txtBrandName.Name = "txtBrandName"
        Me.txtBrandName.ReadOnly = True
        Me.txtBrandName.Size = New System.Drawing.Size(129, 21)
        Me.txtBrandName.TabIndex = 18
        '
        'txtCountBy
        '
        Me.txtCountBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountBy.Location = New System.Drawing.Point(334, 21)
        Me.txtCountBy.Name = "txtCountBy"
        Me.txtCountBy.ReadOnly = True
        Me.txtCountBy.Size = New System.Drawing.Size(129, 21)
        Me.txtCountBy.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(248, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 15)
        Me.Label2.TabIndex = 430
        Me.Label2.Text = "Count By:"
        '
        'txtCycleCountDate
        '
        Me.txtCycleCountDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCycleCountDate.Location = New System.Drawing.Point(119, 46)
        Me.txtCycleCountDate.Name = "txtCycleCountDate"
        Me.txtCycleCountDate.ReadOnly = True
        Me.txtCycleCountDate.Size = New System.Drawing.Size(110, 21)
        Me.txtCycleCountDate.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(9, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 15)
        Me.Label1.TabIndex = 428
        Me.Label1.Text = "Cycle Count Date :"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label51.Location = New System.Drawing.Point(248, 49)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(80, 15)
        Me.Label51.TabIndex = 426
        Me.Label51.Text = "Brand Name:"
        '
        'txtCycleCountNo
        '
        Me.txtCycleCountNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCycleCountNo.Location = New System.Drawing.Point(119, 21)
        Me.txtCycleCountNo.Name = "txtCycleCountNo"
        Me.txtCycleCountNo.ReadOnly = True
        Me.txtCycleCountNo.Size = New System.Drawing.Size(110, 21)
        Me.txtCycleCountNo.TabIndex = 15
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(9, 24)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(96, 15)
        Me.Label52.TabIndex = 272
        Me.Label52.Text = "Cycle Count No.:"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.White
        Me.Label55.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label55.Location = New System.Drawing.Point(9, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(180, 17)
        Me.Label55.TabIndex = 228
        Me.Label55.Text = "Cycle Count Information:"
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msNew, Me.msSave, Me.msPrint, Me.msReports})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(836, 25)
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
        'msPrint
        '
        Me.msPrint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msPrintCycle1, Me.msPrintCycle2})
        Me.msPrint.Image = CType(resources.GetObject("msPrint.Image"), System.Drawing.Image)
        Me.msPrint.Name = "msPrint"
        Me.msPrint.Size = New System.Drawing.Size(66, 21)
        Me.msPrint.Text = "&Print"
        '
        'msPrintCycle1
        '
        Me.msPrintCycle1.Image = CType(resources.GetObject("msPrintCycle1.Image"), System.Drawing.Image)
        Me.msPrintCycle1.Name = "msPrintCycle1"
        Me.msPrintCycle1.Size = New System.Drawing.Size(119, 22)
        Me.msPrintCycle1.Text = "Cycle &1"
        '
        'msPrintCycle2
        '
        Me.msPrintCycle2.Image = CType(resources.GetObject("msPrintCycle2.Image"), System.Drawing.Image)
        Me.msPrintCycle2.Name = "msPrintCycle2"
        Me.msPrintCycle2.Size = New System.Drawing.Size(119, 22)
        Me.msPrintCycle2.Text = "Cycle &2"
        '
        'msReports
        '
        Me.msReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msReportCycle1, Me.msReportCycle2})
        Me.msReports.Image = CType(resources.GetObject("msReports.Image"), System.Drawing.Image)
        Me.msReports.Name = "msReports"
        Me.msReports.Size = New System.Drawing.Size(83, 21)
        Me.msReports.Text = "&Reports"
        '
        'msReportCycle1
        '
        Me.msReportCycle1.Image = CType(resources.GetObject("msReportCycle1.Image"), System.Drawing.Image)
        Me.msReportCycle1.Name = "msReportCycle1"
        Me.msReportCycle1.Size = New System.Drawing.Size(119, 22)
        Me.msReportCycle1.Text = "Cycle &1"
        '
        'msReportCycle2
        '
        Me.msReportCycle2.Image = CType(resources.GetObject("msReportCycle2.Image"), System.Drawing.Image)
        Me.msReportCycle2.Name = "msReportCycle2"
        Me.msReportCycle2.Size = New System.Drawing.Size(119, 22)
        Me.msReportCycle2.Text = "Cycle &2"
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
        Me.pbClose.TabIndex = 235
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
        Me.lblTitle.Size = New System.Drawing.Size(1200, 28)
        Me.lblTitle.TabIndex = 234
        Me.lblTitle.Text = "Cycle Count"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CycleCountForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 560)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CycleCountForm"
        CType(Me.dgCycleCountList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.gbCycleCountList.ResumeLayout(False)
        Me.gbCycleCountList.PerformLayout()
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.tabSearch.ResumeLayout(False)
        Me.tabSimple.ResumeLayout(False)
        Me.tabSimple.PerformLayout()
        Me.tabCommon.ResumeLayout(False)
        Me.tabCommon.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.gbCycleCountItems.ResumeLayout(False)
        Me.gbCycleCountItems.PerformLayout()
        CType(Me.pbAddCountedBy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgCycleCountItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCycleCountInformation.ResumeLayout(False)
        Me.gbCycleCountInformation.PerformLayout()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dgCycleCountList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents gbCycleCountList As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPage As System.Windows.Forms.TextBox
    Friend WithEvents txtPageNo As System.Windows.Forms.TextBox
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tabSearch As System.Windows.Forms.TabControl
    Friend WithEvents tabSimple As System.Windows.Forms.TabPage
    Friend WithEvents txtSimpleSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents tabCommon As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents gbCycleCountItems As System.Windows.Forms.GroupBox
    Friend WithEvents dgCycleCountItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents gbCycleCountInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txtCycleCountNo As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents dtpToSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCycleCountDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCountBy As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBrandName As System.Windows.Forms.TextBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdFirstCCI As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrevCCI As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNextCCI As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLastCCI As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPageNoCCI As System.Windows.Forms.TextBox
    Friend WithEvents cboSearch2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch1 As System.Windows.Forms.ComboBox
    Friend WithEvents msPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msPrintCycle1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msPrintCycle2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msReportCycle1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msReportCycle2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cc_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc_ccno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc_ccdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc_countby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCountedBy As System.Windows.Forms.ComboBox
    Friend WithEvents chkAllCycle1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllCycle2 As System.Windows.Forms.CheckBox
    Friend WithEvents pbAddCountedBy As System.Windows.Forms.PictureBox
    Friend WithEvents cci_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cci_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cci_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cci_productcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cci_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cci_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cci_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cci_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cci_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cci_rackcolumnshelf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cci_qtya As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cci_countedbya As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cci_qtyb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cci_countedbyb As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cci_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
