<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PostionViewForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PostionViewForm))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgPositions = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.p_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_parentposition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_comments = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_positionname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbPositionList = New System.Windows.Forms.GroupBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.gbUser = New System.Windows.Forms.GroupBox()
        Me.dgUsers = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.u_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.u_userno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.u_fname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.u_mname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.u_lname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.u_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbUnknown = New System.Windows.Forms.GroupBox()
        Me.dgUnknown = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pv_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pv_viewid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pv_delete = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pv_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pv_viewname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pv_create = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pv_updates = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pv_disable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pv_readonly = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pv_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.gbPosition = New System.Windows.Forms.GroupBox()
        Me.txtPositionName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboPosition = New System.Windows.Forms.ComboBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.msNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.msSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblsavemsg = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.dgPositions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPositionList.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.gbUser.SuspendLayout()
        CType(Me.dgUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbUnknown.SuspendLayout()
        CType(Me.dgUnknown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPosition.SuspendLayout()
        Me.msMenu.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.pbClose.TabIndex = 290
        Me.pbClose.TabStop = False
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
        Me.ToolStrip3.TabIndex = 215
        Me.ToolStrip3.Text = "toolbar1"
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
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(6, 1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 17)
        Me.Label12.TabIndex = 220
        Me.Label12.Text = "Position List:"
        '
        'dgPositions
        '
        Me.dgPositions.AllowUserToAddRows = False
        Me.dgPositions.AllowUserToDeleteRows = False
        Me.dgPositions.AllowUserToOrderColumns = True
        Me.dgPositions.AllowUserToResizeRows = False
        Me.dgPositions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgPositions.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPositions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPositions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.p_rowid, Me.p_parentposition, Me.p_comments, Me.p_no, Me.p_positionname, Me.p_status})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPositions.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgPositions.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgPositions.Location = New System.Drawing.Point(8, 42)
        Me.dgPositions.MultiSelect = False
        Me.dgPositions.Name = "dgPositions"
        Me.dgPositions.ReadOnly = True
        Me.dgPositions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPositions.Size = New System.Drawing.Size(350, 467)
        Me.dgPositions.TabIndex = 217
        '
        'p_rowid
        '
        Me.p_rowid.HeaderText = "rowid"
        Me.p_rowid.Name = "p_rowid"
        Me.p_rowid.ReadOnly = True
        Me.p_rowid.Visible = False
        '
        'p_parentposition
        '
        Me.p_parentposition.HeaderText = "parentposition"
        Me.p_parentposition.Name = "p_parentposition"
        Me.p_parentposition.ReadOnly = True
        Me.p_parentposition.Visible = False
        '
        'p_comments
        '
        Me.p_comments.HeaderText = "comments"
        Me.p_comments.Name = "p_comments"
        Me.p_comments.ReadOnly = True
        Me.p_comments.Visible = False
        '
        'p_no
        '
        Me.p_no.HeaderText = "Seq. No."
        Me.p_no.Name = "p_no"
        Me.p_no.ReadOnly = True
        Me.p_no.Width = 50
        '
        'p_positionname
        '
        Me.p_positionname.HeaderText = "Position Name"
        Me.p_positionname.Name = "p_positionname"
        Me.p_positionname.ReadOnly = True
        Me.p_positionname.Width = 140
        '
        'p_status
        '
        Me.p_status.HeaderText = "Status"
        Me.p_status.Name = "p_status"
        Me.p_status.ReadOnly = True
        '
        'gbPositionList
        '
        Me.gbPositionList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbPositionList.BackColor = System.Drawing.Color.Transparent
        Me.gbPositionList.Controls.Add(Me.Label12)
        Me.gbPositionList.Controls.Add(Me.dgPositions)
        Me.gbPositionList.Controls.Add(Me.ToolStrip3)
        Me.gbPositionList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPositionList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbPositionList.Location = New System.Drawing.Point(5, 5)
        Me.gbPositionList.Name = "gbPositionList"
        Me.gbPositionList.Size = New System.Drawing.Size(366, 518)
        Me.gbPositionList.TabIndex = 1
        Me.gbPositionList.TabStop = False
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbPositionList)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabMain)
        Me.SplitContainer1.Panel2.Controls.Add(Me.msMenu)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblsavemsg)
        Me.SplitContainer1.Size = New System.Drawing.Size(1210, 534)
        Me.SplitContainer1.SplitterDistance = 380
        Me.SplitContainer1.TabIndex = 289
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
        Me.tabMain.Size = New System.Drawing.Size(822, 505)
        Me.tabMain.TabIndex = 195
        '
        'tabDetails
        '
        Me.tabDetails.AutoScroll = True
        Me.tabDetails.Controls.Add(Me.gbUser)
        Me.tabDetails.Controls.Add(Me.gbUnknown)
        Me.tabDetails.Controls.Add(Me.gbPosition)
        Me.tabDetails.Location = New System.Drawing.Point(4, 4)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(814, 474)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Position Details"
        Me.tabDetails.UseVisualStyleBackColor = True
        '
        'gbUser
        '
        Me.gbUser.Controls.Add(Me.dgUsers)
        Me.gbUser.Controls.Add(Me.Label8)
        Me.gbUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbUser.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbUser.Location = New System.Drawing.Point(385, 6)
        Me.gbUser.Name = "gbUser"
        Me.gbUser.Size = New System.Drawing.Size(420, 160)
        Me.gbUser.TabIndex = 272
        Me.gbUser.TabStop = False
        '
        'dgUsers
        '
        Me.dgUsers.AllowUserToAddRows = False
        Me.dgUsers.AllowUserToDeleteRows = False
        Me.dgUsers.AllowUserToOrderColumns = True
        Me.dgUsers.AllowUserToResizeRows = False
        Me.dgUsers.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUsers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.u_rowid, Me.u_userno, Me.u_fname, Me.u_mname, Me.u_lname, Me.u_status})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgUsers.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgUsers.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgUsers.Location = New System.Drawing.Point(7, 20)
        Me.dgUsers.MultiSelect = False
        Me.dgUsers.Name = "dgUsers"
        Me.dgUsers.ReadOnly = True
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUsers.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgUsers.Size = New System.Drawing.Size(405, 130)
        Me.dgUsers.TabIndex = 239
        '
        'u_rowid
        '
        Me.u_rowid.HeaderText = "rowid"
        Me.u_rowid.Name = "u_rowid"
        Me.u_rowid.ReadOnly = True
        Me.u_rowid.Visible = False
        '
        'u_userno
        '
        Me.u_userno.HeaderText = "User No."
        Me.u_userno.Name = "u_userno"
        Me.u_userno.ReadOnly = True
        Me.u_userno.Width = 50
        '
        'u_fname
        '
        Me.u_fname.HeaderText = "First Name"
        Me.u_fname.Name = "u_fname"
        Me.u_fname.ReadOnly = True
        '
        'u_mname
        '
        Me.u_mname.HeaderText = "Middle Name"
        Me.u_mname.Name = "u_mname"
        Me.u_mname.ReadOnly = True
        Me.u_mname.Width = 110
        '
        'u_lname
        '
        Me.u_lname.HeaderText = "Last Name"
        Me.u_lname.Name = "u_lname"
        Me.u_lname.ReadOnly = True
        '
        'u_status
        '
        Me.u_status.HeaderText = "Status"
        Me.u_status.Name = "u_status"
        Me.u_status.ReadOnly = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(9, -1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 17)
        Me.Label8.TabIndex = 238
        Me.Label8.Text = "Users:"
        '
        'gbUnknown
        '
        Me.gbUnknown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbUnknown.Controls.Add(Me.dgUnknown)
        Me.gbUnknown.Controls.Add(Me.Label22)
        Me.gbUnknown.Location = New System.Drawing.Point(6, 172)
        Me.gbUnknown.Name = "gbUnknown"
        Me.gbUnknown.Size = New System.Drawing.Size(800, 295)
        Me.gbUnknown.TabIndex = 271
        Me.gbUnknown.TabStop = False
        '
        'dgUnknown
        '
        Me.dgUnknown.AllowUserToAddRows = False
        Me.dgUnknown.AllowUserToDeleteRows = False
        Me.dgUnknown.AllowUserToOrderColumns = True
        Me.dgUnknown.AllowUserToResizeRows = False
        Me.dgUnknown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgUnknown.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUnknown.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgUnknown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgUnknown.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pv_rowid, Me.pv_viewid, Me.pv_delete, Me.pv_no, Me.pv_viewname, Me.pv_create, Me.pv_updates, Me.pv_disable, Me.pv_readonly, Me.pv_remarks})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgUnknown.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgUnknown.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgUnknown.Location = New System.Drawing.Point(6, 19)
        Me.dgUnknown.MultiSelect = False
        Me.dgUnknown.Name = "dgUnknown"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUnknown.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgUnknown.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgUnknown.Size = New System.Drawing.Size(785, 265)
        Me.dgUnknown.TabIndex = 350
        '
        'pv_rowid
        '
        Me.pv_rowid.HeaderText = "rowid"
        Me.pv_rowid.Name = "pv_rowid"
        Me.pv_rowid.Visible = False
        '
        'pv_viewid
        '
        Me.pv_viewid.HeaderText = "viewid"
        Me.pv_viewid.Name = "pv_viewid"
        Me.pv_viewid.Visible = False
        '
        'pv_delete
        '
        Me.pv_delete.HeaderText = "delete"
        Me.pv_delete.Name = "pv_delete"
        Me.pv_delete.Visible = False
        '
        'pv_no
        '
        Me.pv_no.HeaderText = "Seq. No."
        Me.pv_no.Name = "pv_no"
        Me.pv_no.ReadOnly = True
        Me.pv_no.Width = 50
        '
        'pv_viewname
        '
        Me.pv_viewname.HeaderText = "View Name"
        Me.pv_viewname.Name = "pv_viewname"
        Me.pv_viewname.ReadOnly = True
        Me.pv_viewname.Width = 180
        '
        'pv_create
        '
        Me.pv_create.HeaderText = "Create"
        Me.pv_create.Name = "pv_create"
        Me.pv_create.Width = 60
        '
        'pv_updates
        '
        Me.pv_updates.HeaderText = "Update"
        Me.pv_updates.Name = "pv_updates"
        '
        'pv_disable
        '
        Me.pv_disable.HeaderText = "Disable"
        Me.pv_disable.Name = "pv_disable"
        Me.pv_disable.Width = 60
        '
        'pv_readonly
        '
        Me.pv_readonly.HeaderText = "Read-Only"
        Me.pv_readonly.Name = "pv_readonly"
        Me.pv_readonly.Width = 70
        '
        'pv_remarks
        '
        Me.pv_remarks.HeaderText = "Remarks"
        Me.pv_remarks.Name = "pv_remarks"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.White
        Me.Label22.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label22.Location = New System.Drawing.Point(9, -3)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(54, 17)
        Me.Label22.TabIndex = 240
        Me.Label22.Text = "Views:"
        '
        'gbPosition
        '
        Me.gbPosition.Controls.Add(Me.txtPositionName)
        Me.gbPosition.Controls.Add(Me.Label11)
        Me.gbPosition.Controls.Add(Me.Label10)
        Me.gbPosition.Controls.Add(Me.txtComments)
        Me.gbPosition.Controls.Add(Me.Label9)
        Me.gbPosition.Controls.Add(Me.Label7)
        Me.gbPosition.Controls.Add(Me.cboPosition)
        Me.gbPosition.Controls.Add(Me.cboStatus)
        Me.gbPosition.Controls.Add(Me.Label18)
        Me.gbPosition.Controls.Add(Me.Label17)
        Me.gbPosition.Controls.Add(Me.Label4)
        Me.gbPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPosition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbPosition.Location = New System.Drawing.Point(6, 6)
        Me.gbPosition.Name = "gbPosition"
        Me.gbPosition.Size = New System.Drawing.Size(370, 160)
        Me.gbPosition.TabIndex = 219
        Me.gbPosition.TabStop = False
        '
        'txtPositionName
        '
        Me.txtPositionName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPositionName.Location = New System.Drawing.Point(127, 22)
        Me.txtPositionName.Name = "txtPositionName"
        Me.txtPositionName.Size = New System.Drawing.Size(215, 21)
        Me.txtPositionName.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(15, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 15)
        Me.Label11.TabIndex = 277
        Me.Label11.Text = "Parent Position:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(108, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 20)
        Me.Label10.TabIndex = 275
        Me.Label10.Text = "*"
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(127, 74)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(215, 45)
        Me.txtComments.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(15, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 15)
        Me.Label9.TabIndex = 270
        Me.Label9.Text = "Comments:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(15, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 15)
        Me.Label7.TabIndex = 247
        Me.Label7.Text = "Position Name:"
        '
        'cboPosition
        '
        Me.cboPosition.BackColor = System.Drawing.SystemColors.Window
        Me.cboPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPosition.FormattingEnabled = True
        Me.cboPosition.Location = New System.Drawing.Point(127, 47)
        Me.cboPosition.Name = "cboPosition"
        Me.cboPosition.Size = New System.Drawing.Size(215, 23)
        Me.cboPosition.TabIndex = 2
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(127, 125)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(215, 23)
        Me.cboStatus.TabIndex = 4
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label18.Location = New System.Drawing.Point(9, -1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(157, 17)
        Me.Label18.TabIndex = 238
        Me.Label18.Text = "Position Information:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(108, 122)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(16, 20)
        Me.Label17.TabIndex = 234
        Me.Label17.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(15, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 15)
        Me.Label4.TabIndex = 232
        Me.Label4.Text = "Status:"
        '
        'msMenu
        '
        Me.msMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msNew, Me.msSave, Me.msCancel})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(822, 25)
        Me.msMenu.TabIndex = 317
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
        Me.lblsavemsg.Location = New System.Drawing.Point(81, 6)
        Me.lblsavemsg.Name = "lblsavemsg"
        Me.lblsavemsg.Size = New System.Drawing.Size(0, 13)
        Me.lblsavemsg.TabIndex = 193
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
        Me.lblTitle.TabIndex = 288
        Me.lblTitle.Text = "Positions And Views"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'PostionViewForm
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
        Me.Name = "PostionViewForm"
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.dgPositions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPositionList.ResumeLayout(False)
        Me.gbPositionList.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.gbUser.ResumeLayout(False)
        Me.gbUser.PerformLayout()
        CType(Me.dgUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbUnknown.ResumeLayout(False)
        Me.gbUnknown.PerformLayout()
        CType(Me.dgUnknown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPosition.ResumeLayout(False)
        Me.gbPosition.PerformLayout()
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgPositions As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gbPositionList As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents gbUser As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gbUnknown As System.Windows.Forms.GroupBox
    Friend WithEvents dgUnknown As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents gbPosition As System.Windows.Forms.GroupBox
    Friend WithEvents txtPositionName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboPosition As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsavemsg As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents p_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_parentposition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_comments As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_positionname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgUsers As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents pv_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pv_viewid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pv_delete As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pv_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pv_viewname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pv_create As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pv_updates As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pv_disable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pv_readonly As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pv_remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents u_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents u_userno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents u_fname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents u_mname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents u_lname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents u_status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
