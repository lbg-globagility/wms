<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PickListForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PickListForm))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dgPickList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pl_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pl_picklistno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pl_picklistdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pl_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.cmdLast = New System.Windows.Forms.ToolStripButton()
        Me.cmdNext = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrev = New System.Windows.Forms.ToolStripButton()
        Me.cmdFirst = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.gbPickList = New System.Windows.Forms.GroupBox()
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
        Me.Label40 = New System.Windows.Forms.Label()
        Me.dtpToSearch = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromSearch = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboDate = New System.Windows.Forms.ComboBox()
        Me.cboSearch2 = New System.Windows.Forms.ComboBox()
        Me.cboSearch1 = New System.Windows.Forms.ComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.gbRackShelfColumn = New System.Windows.Forms.GroupBox()
        Me.dgRackShelfColumn = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.rsc_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_rack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_shelf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtytopick = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtyavailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtyallocated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_qtyorderable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_pickorderno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsc_issueflg = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.rsc_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtQtyToPick = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.msSaveRSC = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbCustomerOrders = New System.Windows.Forms.GroupBox()
        Me.dgCustomerOrders = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.co_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_customerorderno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_pono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_customername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_customerorderdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_inventorylocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_targetdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_canceldate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.co_option = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txtOverallQtyToPick = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOverallQtyOrdered = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gbCustomerOrderItems = New System.Windows.Forms.GroupBox()
        Me.chkOtherInfo = New System.Windows.Forms.CheckBox()
        Me.txtTotalQtyToPick = New System.Windows.Forms.TextBox()
        Me.lnkViewEditBundleItems = New System.Windows.Forms.LinkLabel()
        Me.txtTotalQtyOrdered = New System.Windows.Forms.TextBox()
        Me.dgCustomerOrderItems = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ci_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_pcsrowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_bid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorvalue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seqno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_itemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_colorname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_seasoncode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_qtyordered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_totalqtytopick = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_verifiedby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_verifieddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_unitofmeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ci_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbPickListInformation = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.pbAddPicker = New System.Windows.Forms.PictureBox()
        Me.txtPickListDate = New System.Windows.Forms.TextBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtPickListNo = New System.Windows.Forms.TextBox()
        Me.txtCompletedDate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.cboPickerName = New System.Windows.Forms.ComboBox()
        Me.cboLocationName = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.msOrder = New System.Windows.Forms.ToolStripMenuItem()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        CType(Me.dgPickList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.gbPickList.SuspendLayout()
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
        Me.gbRackShelfColumn.SuspendLayout()
        CType(Me.dgRackShelfColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.gbCustomerOrders.SuspendLayout()
        CType(Me.dgCustomerOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCustomerOrderItems.SuspendLayout()
        CType(Me.dgCustomerOrderItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPickListInformation.SuspendLayout()
        CType(Me.pbAddPicker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msMenu.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Indigo
        Me.Label16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(6, -1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 17)
        Me.Label16.TabIndex = 216
        Me.Label16.Text = "Pick List:"
        '
        'dgPickList
        '
        Me.dgPickList.AllowUserToAddRows = False
        Me.dgPickList.AllowUserToDeleteRows = False
        Me.dgPickList.AllowUserToOrderColumns = True
        Me.dgPickList.AllowUserToResizeRows = False
        Me.dgPickList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgPickList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPickList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgPickList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPickList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pl_rowid, Me.pl_picklistno, Me.pl_picklistdate, Me.pl_status})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPickList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgPickList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgPickList.Location = New System.Drawing.Point(8, 68)
        Me.dgPickList.MultiSelect = False
        Me.dgPickList.Name = "dgPickList"
        Me.dgPickList.ReadOnly = True
        Me.dgPickList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPickList.Size = New System.Drawing.Size(324, 286)
        Me.dgPickList.TabIndex = 16
        '
        'pl_rowid
        '
        Me.pl_rowid.HeaderText = "rowid"
        Me.pl_rowid.Name = "pl_rowid"
        Me.pl_rowid.ReadOnly = True
        Me.pl_rowid.Visible = False
        '
        'pl_picklistno
        '
        Me.pl_picklistno.HeaderText = "Pick List No."
        Me.pl_picklistno.Name = "pl_picklistno"
        Me.pl_picklistno.ReadOnly = True
        '
        'pl_picklistdate
        '
        Me.pl_picklistdate.HeaderText = "Pick List Date"
        Me.pl_picklistdate.Name = "pl_picklistdate"
        Me.pl_picklistdate.ReadOnly = True
        Me.pl_picklistdate.Width = 75
        '
        'pl_status
        '
        Me.pl_status.HeaderText = "Status"
        Me.pl_status.Name = "pl_status"
        Me.pl_status.ReadOnly = True
        Me.pl_status.Width = 65
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
        Me.ToolStrip3.TabIndex = 13
        '
        'gbPickList
        '
        Me.gbPickList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbPickList.BackColor = System.Drawing.Color.Transparent
        Me.gbPickList.Controls.Add(Me.Label4)
        Me.gbPickList.Controls.Add(Me.txtPage)
        Me.gbPickList.Controls.Add(Me.txtPageNo)
        Me.gbPickList.Controls.Add(Me.ToolStrip3)
        Me.gbPickList.Controls.Add(Me.dgPickList)
        Me.gbPickList.Controls.Add(Me.Label16)
        Me.gbPickList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPickList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbPickList.Location = New System.Drawing.Point(6, 161)
        Me.gbPickList.Name = "gbPickList"
        Me.gbPickList.Size = New System.Drawing.Size(340, 360)
        Me.gbPickList.TabIndex = 2
        Me.gbPickList.TabStop = False
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
        'txtPage
        '
        Me.txtPage.Location = New System.Drawing.Point(228, 43)
        Me.txtPage.Name = "txtPage"
        Me.txtPage.Size = New System.Drawing.Size(41, 21)
        Me.txtPage.TabIndex = 15
        '
        'txtPageNo
        '
        Me.txtPageNo.Location = New System.Drawing.Point(121, 43)
        Me.txtPageNo.Name = "txtPageNo"
        Me.txtPageNo.ReadOnly = True
        Me.txtPageNo.Size = New System.Drawing.Size(101, 21)
        Me.txtPageNo.TabIndex = 14
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
        Me.gbSearch.Size = New System.Drawing.Size(340, 150)
        Me.gbSearch.TabIndex = 1
        Me.gbSearch.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Indigo
        Me.Label21.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
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
        Me.tabSearch.Size = New System.Drawing.Size(324, 117)
        Me.tabSearch.TabIndex = 9
        '
        'tabSimple
        '
        Me.tabSimple.Controls.Add(Me.txtSimpleSearch)
        Me.tabSimple.Controls.Add(Me.Label30)
        Me.tabSimple.Location = New System.Drawing.Point(4, 29)
        Me.tabSimple.Name = "tabSimple"
        Me.tabSimple.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSimple.Size = New System.Drawing.Size(316, 84)
        Me.tabSimple.TabIndex = 1
        Me.tabSimple.Text = "       Simple       "
        Me.tabSimple.UseVisualStyleBackColor = True
        '
        'txtSimpleSearch
        '
        Me.txtSimpleSearch.Location = New System.Drawing.Point(97, 29)
        Me.txtSimpleSearch.Name = "txtSimpleSearch"
        Me.txtSimpleSearch.Size = New System.Drawing.Size(212, 21)
        Me.txtSimpleSearch.TabIndex = 7
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(3, 31)
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
        Me.tabCommon.Controls.Add(Me.cboSearch2)
        Me.tabCommon.Controls.Add(Me.cboSearch1)
        Me.tabCommon.Location = New System.Drawing.Point(4, 29)
        Me.tabCommon.Name = "tabCommon"
        Me.tabCommon.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCommon.Size = New System.Drawing.Size(316, 84)
        Me.tabCommon.TabIndex = 0
        Me.tabCommon.Text = "       Common       "
        Me.tabCommon.UseVisualStyleBackColor = True
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(243, 5)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(24, 15)
        Me.Label40.TabIndex = 260
        Me.Label40.Text = "To:"
        '
        'dtpToSearch
        '
        Me.dtpToSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpToSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpToSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToSearch.Location = New System.Drawing.Point(202, 24)
        Me.dtpToSearch.Name = "dtpToSearch"
        Me.dtpToSearch.Size = New System.Drawing.Size(110, 21)
        Me.dtpToSearch.TabIndex = 10
        '
        'dtpFromSearch
        '
        Me.dtpFromSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpFromSearch.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFromSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromSearch.Location = New System.Drawing.Point(88, 24)
        Me.dtpFromSearch.Name = "dtpFromSearch"
        Me.dtpFromSearch.Size = New System.Drawing.Size(110, 21)
        Me.dtpFromSearch.TabIndex = 9
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(119, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 15)
        Me.Label18.TabIndex = 259
        Me.Label18.Text = "From:"
        '
        'cboDate
        '
        Me.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDate.FormattingEnabled = True
        Me.cboDate.Location = New System.Drawing.Point(4, 23)
        Me.cboDate.Name = "cboDate"
        Me.cboDate.Size = New System.Drawing.Size(80, 23)
        Me.cboDate.TabIndex = 8
        '
        'cboSearch2
        '
        Me.cboSearch2.FormattingEnabled = True
        Me.cboSearch2.Location = New System.Drawing.Point(115, 51)
        Me.cboSearch2.Name = "cboSearch2"
        Me.cboSearch2.Size = New System.Drawing.Size(192, 23)
        Me.cboSearch2.TabIndex = 12
        '
        'cboSearch1
        '
        Me.cboSearch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch1.FormattingEnabled = True
        Me.cboSearch1.Location = New System.Drawing.Point(9, 51)
        Me.cboSearch1.Name = "cboSearch1"
        Me.cboSearch1.Size = New System.Drawing.Size(100, 23)
        Me.cboSearch1.TabIndex = 11
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Indigo
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbPickList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbSearch)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabMain)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblsavemsg)
        Me.SplitContainer1.Panel2.Controls.Add(Me.msMenu)
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
        Me.tabDetails.Controls.Add(Me.gbRackShelfColumn)
        Me.tabDetails.Controls.Add(Me.gbCustomerOrders)
        Me.tabDetails.Controls.Add(Me.gbCustomerOrderItems)
        Me.tabDetails.Controls.Add(Me.gbPickListInformation)
        Me.tabDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(828, 472)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "P.L. Details"
        Me.tabDetails.UseVisualStyleBackColor = True
        '
        'gbRackShelfColumn
        '
        Me.gbRackShelfColumn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbRackShelfColumn.Controls.Add(Me.dgRackShelfColumn)
        Me.gbRackShelfColumn.Controls.Add(Me.txtQtyToPick)
        Me.gbRackShelfColumn.Controls.Add(Me.Label8)
        Me.gbRackShelfColumn.Controls.Add(Me.Label13)
        Me.gbRackShelfColumn.Controls.Add(Me.MenuStrip1)
        Me.gbRackShelfColumn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRackShelfColumn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbRackShelfColumn.Location = New System.Drawing.Point(7, 396)
        Me.gbRackShelfColumn.Name = "gbRackShelfColumn"
        Me.gbRackShelfColumn.Size = New System.Drawing.Size(751, 200)
        Me.gbRackShelfColumn.TabIndex = 6
        Me.gbRackShelfColumn.TabStop = False
        '
        'dgRackShelfColumn
        '
        Me.dgRackShelfColumn.AllowUserToAddRows = False
        Me.dgRackShelfColumn.AllowUserToDeleteRows = False
        Me.dgRackShelfColumn.AllowUserToOrderColumns = True
        Me.dgRackShelfColumn.AllowUserToResizeRows = False
        Me.dgRackShelfColumn.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRackShelfColumn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgRackShelfColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRackShelfColumn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rsc_rowid, Me.rsc_rack, Me.rsc_column, Me.rsc_shelf, Me.rsc_qtytopick, Me.rsc_qtyavailable, Me.rsc_qtyallocated, Me.rsc_qtyorderable, Me.rsc_pickorderno, Me.rsc_issueflg, Me.rsc_remarks})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgRackShelfColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgRackShelfColumn.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgRackShelfColumn.Location = New System.Drawing.Point(7, 18)
        Me.dgRackShelfColumn.MultiSelect = False
        Me.dgRackShelfColumn.Name = "dgRackShelfColumn"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRackShelfColumn.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgRackShelfColumn.RowHeadersVisible = False
        Me.dgRackShelfColumn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRackShelfColumn.Size = New System.Drawing.Size(570, 175)
        Me.dgRackShelfColumn.TabIndex = 32
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
        Me.rsc_rack.Width = 50
        '
        'rsc_column
        '
        Me.rsc_column.HeaderText = "Column"
        Me.rsc_column.Name = "rsc_column"
        Me.rsc_column.ReadOnly = True
        Me.rsc_column.Width = 60
        '
        'rsc_shelf
        '
        Me.rsc_shelf.HeaderText = "Shelf"
        Me.rsc_shelf.Name = "rsc_shelf"
        Me.rsc_shelf.ReadOnly = True
        Me.rsc_shelf.Width = 50
        '
        'rsc_qtytopick
        '
        Me.rsc_qtytopick.HeaderText = "Qty. To Pick"
        Me.rsc_qtytopick.Name = "rsc_qtytopick"
        Me.rsc_qtytopick.Width = 67
        '
        'rsc_qtyavailable
        '
        Me.rsc_qtyavailable.HeaderText = "Qty. Available"
        Me.rsc_qtyavailable.Name = "rsc_qtyavailable"
        Me.rsc_qtyavailable.ReadOnly = True
        Me.rsc_qtyavailable.Visible = False
        Me.rsc_qtyavailable.Width = 60
        '
        'rsc_qtyallocated
        '
        Me.rsc_qtyallocated.HeaderText = "Qty. Allocated"
        Me.rsc_qtyallocated.Name = "rsc_qtyallocated"
        Me.rsc_qtyallocated.ReadOnly = True
        Me.rsc_qtyallocated.Visible = False
        Me.rsc_qtyallocated.Width = 60
        '
        'rsc_qtyorderable
        '
        Me.rsc_qtyorderable.HeaderText = "Qty. Orderable"
        Me.rsc_qtyorderable.Name = "rsc_qtyorderable"
        Me.rsc_qtyorderable.ReadOnly = True
        Me.rsc_qtyorderable.Width = 60
        '
        'rsc_pickorderno
        '
        Me.rsc_pickorderno.HeaderText = "Pick Order No."
        Me.rsc_pickorderno.Name = "rsc_pickorderno"
        Me.rsc_pickorderno.ReadOnly = True
        Me.rsc_pickorderno.Width = 83
        '
        'rsc_issueflg
        '
        Me.rsc_issueflg.HeaderText = "With Issue"
        Me.rsc_issueflg.Name = "rsc_issueflg"
        Me.rsc_issueflg.Width = 50
        '
        'rsc_remarks
        '
        Me.rsc_remarks.HeaderText = "Remarks"
        Me.rsc_remarks.Name = "rsc_remarks"
        '
        'txtQtyToPick
        '
        Me.txtQtyToPick.BackColor = System.Drawing.SystemColors.Control
        Me.txtQtyToPick.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyToPick.Location = New System.Drawing.Point(720, 42)
        Me.txtQtyToPick.Name = "txtQtyToPick"
        Me.txtQtyToPick.ReadOnly = True
        Me.txtQtyToPick.Size = New System.Drawing.Size(69, 21)
        Me.txtQtyToPick.TabIndex = 34
        Me.txtQtyToPick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(597, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 15)
        Me.Label8.TabIndex = 469
        Me.Label8.Text = "Total Qty. To Pick:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label13.Location = New System.Drawing.Point(9, -2)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(163, 17)
        Me.Label13.TabIndex = 228
        Me.Label13.Text = "Rack / Column / Shelf:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msSaveRSC})
        Me.MenuStrip1.Location = New System.Drawing.Point(579, 10)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(211, 25)
        Me.MenuStrip1.TabIndex = 33
        '
        'msSaveRSC
        '
        Me.msSaveRSC.Image = CType(resources.GetObject("msSaveRSC.Image"), System.Drawing.Image)
        Me.msSaveRSC.Name = "msSaveRSC"
        Me.msSaveRSC.Size = New System.Drawing.Size(203, 21)
        Me.msSaveRSC.Text = "Save &Rack / Column / Shelf"
        '
        'gbCustomerOrders
        '
        Me.gbCustomerOrders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCustomerOrders.Controls.Add(Me.dgCustomerOrders)
        Me.gbCustomerOrders.Controls.Add(Me.txtOverallQtyToPick)
        Me.gbCustomerOrders.Controls.Add(Me.Label1)
        Me.gbCustomerOrders.Controls.Add(Me.Label6)
        Me.gbCustomerOrders.Controls.Add(Me.txtOverallQtyOrdered)
        Me.gbCustomerOrders.Controls.Add(Me.Label9)
        Me.gbCustomerOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCustomerOrders.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCustomerOrders.Location = New System.Drawing.Point(372, 5)
        Me.gbCustomerOrders.Name = "gbCustomerOrders"
        Me.gbCustomerOrders.Size = New System.Drawing.Size(399, 190)
        Me.gbCustomerOrders.TabIndex = 4
        Me.gbCustomerOrders.TabStop = False
        '
        'dgCustomerOrders
        '
        Me.dgCustomerOrders.AllowUserToAddRows = False
        Me.dgCustomerOrders.AllowUserToDeleteRows = False
        Me.dgCustomerOrders.AllowUserToOrderColumns = True
        Me.dgCustomerOrders.AllowUserToResizeRows = False
        Me.dgCustomerOrders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.dgCustomerOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.co_rowid, Me.co_seqno, Me.co_customerorderno, Me.co_pono, Me.co_customername, Me.co_customerorderdate, Me.co_inventorylocation, Me.co_targetdate, Me.co_canceldate, Me.co_status, Me.co_option})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCustomerOrders.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgCustomerOrders.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCustomerOrders.Location = New System.Drawing.Point(7, 21)
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
        Me.dgCustomerOrders.Size = New System.Drawing.Size(384, 136)
        Me.dgCustomerOrders.TabIndex = 24
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
        Me.co_seqno.Width = 40
        '
        'co_customerorderno
        '
        Me.co_customerorderno.HeaderText = "Customer Order No."
        Me.co_customerorderno.Name = "co_customerorderno"
        Me.co_customerorderno.ReadOnly = True
        Me.co_customerorderno.Width = 80
        '
        'co_pono
        '
        Me.co_pono.HeaderText = "P.O. No."
        Me.co_pono.Name = "co_pono"
        Me.co_pono.ReadOnly = True
        Me.co_pono.Width = 80
        '
        'co_customername
        '
        Me.co_customername.HeaderText = "Customer Name"
        Me.co_customername.Name = "co_customername"
        Me.co_customername.ReadOnly = True
        Me.co_customername.Width = 150
        '
        'co_customerorderdate
        '
        Me.co_customerorderdate.HeaderText = "Customer Order Date"
        Me.co_customerorderdate.Name = "co_customerorderdate"
        Me.co_customerorderdate.ReadOnly = True
        Me.co_customerorderdate.Width = 90
        '
        'co_inventorylocation
        '
        Me.co_inventorylocation.HeaderText = "Inventory Location"
        Me.co_inventorylocation.Name = "co_inventorylocation"
        Me.co_inventorylocation.ReadOnly = True
        '
        'co_targetdate
        '
        Me.co_targetdate.HeaderText = "Receipt Date"
        Me.co_targetdate.Name = "co_targetdate"
        Me.co_targetdate.ReadOnly = True
        Me.co_targetdate.Width = 80
        '
        'co_canceldate
        '
        Me.co_canceldate.HeaderText = "Cancel Date"
        Me.co_canceldate.Name = "co_canceldate"
        Me.co_canceldate.ReadOnly = True
        Me.co_canceldate.Width = 80
        '
        'co_status
        '
        Me.co_status.HeaderText = "Status"
        Me.co_status.Name = "co_status"
        Me.co_status.ReadOnly = True
        Me.co_status.Width = 80
        '
        'co_option
        '
        Me.co_option.HeaderText = ""
        Me.co_option.Name = "co_option"
        Me.co_option.ReadOnly = True
        Me.co_option.Text = "Delete"
        Me.co_option.UseColumnTextForButtonValue = True
        Me.co_option.Width = 50
        '
        'txtOverallQtyToPick
        '
        Me.txtOverallQtyToPick.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOverallQtyToPick.Location = New System.Drawing.Point(363, 163)
        Me.txtOverallQtyToPick.Name = "txtOverallQtyToPick"
        Me.txtOverallQtyToPick.ReadOnly = True
        Me.txtOverallQtyToPick.Size = New System.Drawing.Size(80, 21)
        Me.txtOverallQtyToPick.TabIndex = 26
        Me.txtOverallQtyToPick.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(9, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 17)
        Me.Label1.TabIndex = 228
        Me.Label1.Text = "Customer Orders:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(227, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 15)
        Me.Label6.TabIndex = 473
        Me.Label6.Text = "Overall Qty. To Pick:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtOverallQtyOrdered
        '
        Me.txtOverallQtyOrdered.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOverallQtyOrdered.Location = New System.Drawing.Point(142, 163)
        Me.txtOverallQtyOrdered.Name = "txtOverallQtyOrdered"
        Me.txtOverallQtyOrdered.ReadOnly = True
        Me.txtOverallQtyOrdered.Size = New System.Drawing.Size(80, 21)
        Me.txtOverallQtyOrdered.TabIndex = 25
        Me.txtOverallQtyOrdered.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(2, 166)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 15)
        Me.Label9.TabIndex = 472
        Me.Label9.Text = "Overall Qty. Ordered:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbCustomerOrderItems
        '
        Me.gbCustomerOrderItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCustomerOrderItems.Controls.Add(Me.chkOtherInfo)
        Me.gbCustomerOrderItems.Controls.Add(Me.txtTotalQtyToPick)
        Me.gbCustomerOrderItems.Controls.Add(Me.lnkViewEditBundleItems)
        Me.gbCustomerOrderItems.Controls.Add(Me.txtTotalQtyOrdered)
        Me.gbCustomerOrderItems.Controls.Add(Me.dgCustomerOrderItems)
        Me.gbCustomerOrderItems.Controls.Add(Me.Label15)
        Me.gbCustomerOrderItems.Controls.Add(Me.Label11)
        Me.gbCustomerOrderItems.Controls.Add(Me.Label7)
        Me.gbCustomerOrderItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCustomerOrderItems.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbCustomerOrderItems.Location = New System.Drawing.Point(7, 195)
        Me.gbCustomerOrderItems.Name = "gbCustomerOrderItems"
        Me.gbCustomerOrderItems.Size = New System.Drawing.Size(764, 200)
        Me.gbCustomerOrderItems.TabIndex = 5
        Me.gbCustomerOrderItems.TabStop = False
        '
        'chkOtherInfo
        '
        Me.chkOtherInfo.AutoSize = True
        Me.chkOtherInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOtherInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOtherInfo.Location = New System.Drawing.Point(8, 176)
        Me.chkOtherInfo.Name = "chkOtherInfo"
        Me.chkOtherInfo.Size = New System.Drawing.Size(114, 19)
        Me.chkOtherInfo.TabIndex = 28
        Me.chkOtherInfo.Text = "View Other Info.:"
        Me.chkOtherInfo.UseVisualStyleBackColor = True
        '
        'txtTotalQtyToPick
        '
        Me.txtTotalQtyToPick.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyToPick.Location = New System.Drawing.Point(672, 174)
        Me.txtTotalQtyToPick.Name = "txtTotalQtyToPick"
        Me.txtTotalQtyToPick.ReadOnly = True
        Me.txtTotalQtyToPick.Size = New System.Drawing.Size(85, 21)
        Me.txtTotalQtyToPick.TabIndex = 31
        Me.txtTotalQtyToPick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lnkViewEditBundleItems
        '
        Me.lnkViewEditBundleItems.AutoSize = True
        Me.lnkViewEditBundleItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkViewEditBundleItems.Location = New System.Drawing.Point(129, 177)
        Me.lnkViewEditBundleItems.Name = "lnkViewEditBundleItems"
        Me.lnkViewEditBundleItems.Size = New System.Drawing.Size(135, 15)
        Me.lnkViewEditBundleItems.TabIndex = 29
        Me.lnkViewEditBundleItems.TabStop = True
        Me.lnkViewEditBundleItems.Text = "View/Edit Bundle Items:"
        '
        'txtTotalQtyOrdered
        '
        Me.txtTotalQtyOrdered.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQtyOrdered.Location = New System.Drawing.Point(408, 174)
        Me.txtTotalQtyOrdered.Name = "txtTotalQtyOrdered"
        Me.txtTotalQtyOrdered.ReadOnly = True
        Me.txtTotalQtyOrdered.Size = New System.Drawing.Size(85, 21)
        Me.txtTotalQtyOrdered.TabIndex = 30
        Me.txtTotalQtyOrdered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgCustomerOrderItems
        '
        Me.dgCustomerOrderItems.AllowUserToAddRows = False
        Me.dgCustomerOrderItems.AllowUserToDeleteRows = False
        Me.dgCustomerOrderItems.AllowUserToOrderColumns = True
        Me.dgCustomerOrderItems.AllowUserToResizeRows = False
        Me.dgCustomerOrderItems.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerOrderItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgCustomerOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustomerOrderItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ci_rowid, Me.ci_pcsrowid, Me.ci_bid, Me.ci_colorvalue, Me.ci_seqno, Me.ci_itemcode, Me.ci_colorname, Me.ci_color, Me.ci_size, Me.ci_seasoncode, Me.ci_qtyordered, Me.ci_totalqtytopick, Me.ci_sku, Me.ci_status, Me.ci_verifiedby, Me.ci_verifieddate, Me.ci_remarks, Me.ci_unitofmeasure, Me.ci_type})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCustomerOrderItems.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgCustomerOrderItems.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCustomerOrderItems.Location = New System.Drawing.Point(7, 16)
        Me.dgCustomerOrderItems.MultiSelect = False
        Me.dgCustomerOrderItems.Name = "dgCustomerOrderItems"
        Me.dgCustomerOrderItems.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustomerOrderItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgCustomerOrderItems.RowHeadersVisible = False
        Me.dgCustomerOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCustomerOrderItems.Size = New System.Drawing.Size(800, 155)
        Me.dgCustomerOrderItems.TabIndex = 27
        '
        'ci_rowid
        '
        Me.ci_rowid.HeaderText = "rowid"
        Me.ci_rowid.Name = "ci_rowid"
        Me.ci_rowid.ReadOnly = True
        Me.ci_rowid.Visible = False
        '
        'ci_pcsrowid
        '
        Me.ci_pcsrowid.HeaderText = "pcsrowid"
        Me.ci_pcsrowid.Name = "ci_pcsrowid"
        Me.ci_pcsrowid.ReadOnly = True
        Me.ci_pcsrowid.Visible = False
        '
        'ci_bid
        '
        Me.ci_bid.HeaderText = "bid"
        Me.ci_bid.Name = "ci_bid"
        Me.ci_bid.ReadOnly = True
        Me.ci_bid.Visible = False
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
        'ci_itemcode
        '
        Me.ci_itemcode.HeaderText = "Product Code / Bundle Name"
        Me.ci_itemcode.Name = "ci_itemcode"
        Me.ci_itemcode.ReadOnly = True
        Me.ci_itemcode.Width = 120
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
        'ci_totalqtytopick
        '
        Me.ci_totalqtytopick.HeaderText = "Total Qty. To Pick"
        Me.ci_totalqtytopick.Name = "ci_totalqtytopick"
        Me.ci_totalqtytopick.ReadOnly = True
        Me.ci_totalqtytopick.Width = 80
        '
        'ci_sku
        '
        Me.ci_sku.HeaderText = "SKU"
        Me.ci_sku.Name = "ci_sku"
        Me.ci_sku.ReadOnly = True
        '
        'ci_status
        '
        Me.ci_status.HeaderText = "Status"
        Me.ci_status.Name = "ci_status"
        Me.ci_status.ReadOnly = True
        Me.ci_status.Width = 70
        '
        'ci_verifiedby
        '
        Me.ci_verifiedby.HeaderText = "Verified By"
        Me.ci_verifiedby.Name = "ci_verifiedby"
        Me.ci_verifiedby.ReadOnly = True
        Me.ci_verifiedby.Width = 90
        '
        'ci_verifieddate
        '
        Me.ci_verifieddate.HeaderText = "Verified Date"
        Me.ci_verifieddate.Name = "ci_verifieddate"
        Me.ci_verifieddate.ReadOnly = True
        '
        'ci_remarks
        '
        Me.ci_remarks.HeaderText = "Remarks"
        Me.ci_remarks.Name = "ci_remarks"
        Me.ci_remarks.ReadOnly = True
        '
        'ci_unitofmeasure
        '
        Me.ci_unitofmeasure.HeaderText = "Unit Of Measure"
        Me.ci_unitofmeasure.Name = "ci_unitofmeasure"
        Me.ci_unitofmeasure.ReadOnly = True
        Me.ci_unitofmeasure.Width = 75
        '
        'ci_type
        '
        Me.ci_type.HeaderText = "Type"
        Me.ci_type.Name = "ci_type"
        Me.ci_type.ReadOnly = True
        Me.ci_type.Width = 35
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(9, -2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(164, 17)
        Me.Label15.TabIndex = 228
        Me.Label15.Text = "Customer Order Items:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(504, 177)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(165, 15)
        Me.Label11.TabIndex = 472
        Me.Label11.Text = "Total Qty. To Pick (Sum):"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(275, 177)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 15)
        Me.Label7.TabIndex = 468
        Me.Label7.Text = "Total Qty. Ordered:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbPickListInformation
        '
        Me.gbPickListInformation.Controls.Add(Me.Label25)
        Me.gbPickListInformation.Controls.Add(Me.pbAddPicker)
        Me.gbPickListInformation.Controls.Add(Me.txtPickListDate)
        Me.gbPickListInformation.Controls.Add(Me.txtComments)
        Me.gbPickListInformation.Controls.Add(Me.Label20)
        Me.gbPickListInformation.Controls.Add(Me.Label14)
        Me.gbPickListInformation.Controls.Add(Me.Label22)
        Me.gbPickListInformation.Controls.Add(Me.txtPickListNo)
        Me.gbPickListInformation.Controls.Add(Me.txtCompletedDate)
        Me.gbPickListInformation.Controls.Add(Me.Label10)
        Me.gbPickListInformation.Controls.Add(Me.Label52)
        Me.gbPickListInformation.Controls.Add(Me.cboPickerName)
        Me.gbPickListInformation.Controls.Add(Me.cboLocationName)
        Me.gbPickListInformation.Controls.Add(Me.Label17)
        Me.gbPickListInformation.Controls.Add(Me.txtStatus)
        Me.gbPickListInformation.Controls.Add(Me.Label55)
        Me.gbPickListInformation.Controls.Add(Me.Label3)
        Me.gbPickListInformation.Controls.Add(Me.Label5)
        Me.gbPickListInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPickListInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbPickListInformation.Location = New System.Drawing.Point(6, 5)
        Me.gbPickListInformation.Name = "gbPickListInformation"
        Me.gbPickListInformation.Size = New System.Drawing.Size(360, 190)
        Me.gbPickListInformation.TabIndex = 3
        Me.gbPickListInformation.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(4, 136)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 15)
        Me.Label25.TabIndex = 436
        Me.Label25.Text = "Comments:"
        '
        'pbAddPicker
        '
        Me.pbAddPicker.BackColor = System.Drawing.Color.Transparent
        Me.pbAddPicker.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddPicker.Image = CType(resources.GetObject("pbAddPicker.Image"), System.Drawing.Image)
        Me.pbAddPicker.Location = New System.Drawing.Point(319, 78)
        Me.pbAddPicker.Name = "pbAddPicker"
        Me.pbAddPicker.Size = New System.Drawing.Size(14, 18)
        Me.pbAddPicker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddPicker.TabIndex = 444
        Me.pbAddPicker.TabStop = False
        Me.pbAddPicker.Tag = ""
        '
        'txtPickListDate
        '
        Me.txtPickListDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPickListDate.Location = New System.Drawing.Point(88, 48)
        Me.txtPickListDate.Name = "txtPickListDate"
        Me.txtPickListDate.ReadOnly = True
        Me.txtPickListDate.Size = New System.Drawing.Size(80, 21)
        Me.txtPickListDate.TabIndex = 19
        '
        'txtComments
        '
        Me.txtComments.BackColor = System.Drawing.SystemColors.Window
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(74, 133)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(279, 51)
        Me.txtComments.TabIndex = 23
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(83, 73)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(16, 20)
        Me.Label20.TabIndex = 442
        Me.Label20.Text = "*"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(4, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 15)
        Me.Label14.TabIndex = 420
        Me.Label14.Text = "Pick List Date:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(96, 100)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(16, 20)
        Me.Label22.TabIndex = 443
        Me.Label22.Text = "*"
        '
        'txtPickListNo
        '
        Me.txtPickListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPickListNo.Location = New System.Drawing.Point(82, 21)
        Me.txtPickListNo.Name = "txtPickListNo"
        Me.txtPickListNo.ReadOnly = True
        Me.txtPickListNo.Size = New System.Drawing.Size(110, 21)
        Me.txtPickListNo.TabIndex = 17
        '
        'txtCompletedDate
        '
        Me.txtCompletedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompletedDate.Location = New System.Drawing.Point(269, 48)
        Me.txtCompletedDate.Name = "txtCompletedDate"
        Me.txtCompletedDate.ReadOnly = True
        Me.txtCompletedDate.Size = New System.Drawing.Size(84, 21)
        Me.txtCompletedDate.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(4, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 15)
        Me.Label10.TabIndex = 438
        Me.Label10.Text = "Location Name:"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(4, 24)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(77, 15)
        Me.Label52.TabIndex = 272
        Me.Label52.Text = "Pick List No.:"
        '
        'cboPickerName
        '
        Me.cboPickerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPickerName.FormattingEnabled = True
        Me.cboPickerName.Location = New System.Drawing.Point(99, 75)
        Me.cboPickerName.Name = "cboPickerName"
        Me.cboPickerName.Size = New System.Drawing.Size(218, 23)
        Me.cboPickerName.TabIndex = 21
        '
        'cboLocationName
        '
        Me.cboLocationName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLocationName.FormattingEnabled = True
        Me.cboLocationName.Location = New System.Drawing.Point(112, 104)
        Me.cboLocationName.Name = "cboLocationName"
        Me.cboLocationName.Size = New System.Drawing.Size(221, 23)
        Me.cboLocationName.TabIndex = 22
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(4, 78)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 15)
        Me.Label17.TabIndex = 441
        Me.Label17.Text = "Picker Name:"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(249, 21)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(104, 21)
        Me.txtStatus.TabIndex = 18
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.White
        Me.Label55.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label55.Location = New System.Drawing.Point(9, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(157, 17)
        Me.Label55.TabIndex = 228
        Me.Label55.Text = "Pick List Information:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(171, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 15)
        Me.Label3.TabIndex = 424
        Me.Label3.Text = "Completed Date:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(202, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 426
        Me.Label5.Text = "Status:"
        '
        'lblsavemsg
        '
        Me.lblsavemsg.AutoSize = True
        Me.lblsavemsg.Location = New System.Drawing.Point(164, 5)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 193
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msNew, Me.msSave, Me.msPrint, Me.msOrder})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(836, 25)
        Me.msMenu.TabIndex = 224
        '
        'msNew
        '
        Me.msNew.Image = CType(resources.GetObject("msNew.Image"), System.Drawing.Image)
        Me.msNew.Name = "msNew"
        Me.msNew.Size = New System.Drawing.Size(146, 21)
        Me.msNew.Text = "&Generate Pick List"
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
        Me.msPrint.Image = CType(resources.GetObject("msPrint.Image"), System.Drawing.Image)
        Me.msPrint.Name = "msPrint"
        Me.msPrint.Size = New System.Drawing.Size(66, 21)
        Me.msPrint.Text = "&Print"
        '
        'msOrder
        '
        Me.msOrder.Image = CType(resources.GetObject("msOrder.Image"), System.Drawing.Image)
        Me.msOrder.Name = "msOrder"
        Me.msOrder.Size = New System.Drawing.Size(102, 21)
        Me.msOrder.Text = "Cancel &List"
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
        Me.lblTitle.Text = "Pick List"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PickListForm
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
        Me.Name = "PickListForm"
        CType(Me.dgPickList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.gbPickList.ResumeLayout(False)
        Me.gbPickList.PerformLayout()
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
        Me.gbRackShelfColumn.ResumeLayout(False)
        Me.gbRackShelfColumn.PerformLayout()
        CType(Me.dgRackShelfColumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gbCustomerOrders.ResumeLayout(False)
        Me.gbCustomerOrders.PerformLayout()
        CType(Me.dgCustomerOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCustomerOrderItems.ResumeLayout(False)
        Me.gbCustomerOrderItems.PerformLayout()
        CType(Me.dgCustomerOrderItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPickListInformation.ResumeLayout(False)
        Me.gbPickListInformation.PerformLayout()
        CType(Me.pbAddPicker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dgPickList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents gbPickList As System.Windows.Forms.GroupBox
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
    Friend WithEvents cboSearch2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearch1 As System.Windows.Forms.ComboBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents gbCustomerOrderItems As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents gbCustomerOrders As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msOrder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgCustomerOrders As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents msPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgCustomerOrderItems As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtQtyToPick As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQtyOrdered As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtOverallQtyOrdered As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents dtpToSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboDate As System.Windows.Forms.ComboBox
    Friend WithEvents pl_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pl_picklistno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pl_picklistdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pl_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lnkViewEditBundleItems As System.Windows.Forms.LinkLabel
    Friend WithEvents gbRackShelfColumn As System.Windows.Forms.GroupBox
    Friend WithEvents dgRackShelfColumn As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQtyToPick As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOverallQtyToPick As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents msSaveRSC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbAddPicker As System.Windows.Forms.PictureBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboPickerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents gbPickListInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtPickListDate As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtPickListNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCompletedDate As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboLocationName As System.Windows.Forms.ComboBox
    Friend WithEvents chkOtherInfo As System.Windows.Forms.CheckBox
    Friend WithEvents ci_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_pcsrowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_bid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorvalue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seqno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_itemcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_colorname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_seasoncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_qtyordered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_totalqtytopick As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_sku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_verifiedby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_verifieddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_unitofmeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ci_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents co_rowid As DataGridViewTextBoxColumn
    Friend WithEvents co_seqno As DataGridViewTextBoxColumn
    Friend WithEvents co_customerorderno As DataGridViewTextBoxColumn
    Friend WithEvents co_pono As DataGridViewTextBoxColumn
    Friend WithEvents co_customername As DataGridViewTextBoxColumn
    Friend WithEvents co_customerorderdate As DataGridViewTextBoxColumn
    Friend WithEvents co_inventorylocation As DataGridViewTextBoxColumn
    Friend WithEvents co_targetdate As DataGridViewTextBoxColumn
    Friend WithEvents co_canceldate As DataGridViewTextBoxColumn
    Friend WithEvents co_status As DataGridViewTextBoxColumn
    Friend WithEvents co_option As DataGridViewButtonColumn
    Friend WithEvents rsc_rowid As DataGridViewTextBoxColumn
    Friend WithEvents rsc_rack As DataGridViewTextBoxColumn
    Friend WithEvents rsc_column As DataGridViewTextBoxColumn
    Friend WithEvents rsc_shelf As DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtytopick As DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtyavailable As DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtyallocated As DataGridViewTextBoxColumn
    Friend WithEvents rsc_qtyorderable As DataGridViewTextBoxColumn
    Friend WithEvents rsc_pickorderno As DataGridViewTextBoxColumn
    Friend WithEvents rsc_issueflg As DataGridViewCheckBoxColumn
    Friend WithEvents rsc_remarks As DataGridViewTextBoxColumn
End Class
