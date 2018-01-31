<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PickListReportForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PickListReportForm))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.dtpCustomerOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCustomerName = New System.Windows.Forms.ComboBox()
        Me.gbFilter = New System.Windows.Forms.GroupBox()
        Me.cboFilterBy = New System.Windows.Forms.ComboBox()
        Me.pnlOptions = New System.Windows.Forms.Panel()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmsOptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsOutright = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsConsignor = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsOtherStore = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFilter.SuspendLayout()
        Me.pnlOptions.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsOptions.SuspendLayout()
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
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "Pick Listed"
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
        Me.pbClose.TabIndex = 239
        Me.pbClose.TabStop = False
        '
        'dtpCustomerOrderDate
        '
        Me.dtpCustomerOrderDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpCustomerOrderDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpCustomerOrderDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCustomerOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCustomerOrderDate.Location = New System.Drawing.Point(140, 15)
        Me.dtpCustomerOrderDate.Name = "dtpCustomerOrderDate"
        Me.dtpCustomerOrderDate.Size = New System.Drawing.Size(110, 21)
        Me.dtpCustomerOrderDate.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(10, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Customer Order Date:"
        '
        'cboCustomerName
        '
        Me.cboCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(410, 15)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(260, 23)
        Me.cboCustomerName.TabIndex = 4
        '
        'gbFilter
        '
        Me.gbFilter.Controls.Add(Me.cboFilterBy)
        Me.gbFilter.Controls.Add(Me.pnlOptions)
        Me.gbFilter.Controls.Add(Me.cboCustomerName)
        Me.gbFilter.Controls.Add(Me.dtpCustomerOrderDate)
        Me.gbFilter.Controls.Add(Me.Label2)
        Me.gbFilter.Controls.Add(Me.Label3)
        Me.gbFilter.Location = New System.Drawing.Point(20, 40)
        Me.gbFilter.Name = "gbFilter"
        Me.gbFilter.Size = New System.Drawing.Size(850, 50)
        Me.gbFilter.TabIndex = 1
        Me.gbFilter.TabStop = False
        '
        'cboFilterBy
        '
        Me.cboFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFilterBy.FormattingEnabled = True
        Me.cboFilterBy.Location = New System.Drawing.Point(275, 15)
        Me.cboFilterBy.Name = "cboFilterBy"
        Me.cboFilterBy.Size = New System.Drawing.Size(130, 23)
        Me.cboFilterBy.TabIndex = 3
        '
        'pnlOptions
        '
        Me.pnlOptions.BackColor = System.Drawing.Color.Salmon
        Me.pnlOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOptions.Controls.Add(Me.btnPrint)
        Me.pnlOptions.Location = New System.Drawing.Point(690, 7)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(140, 42)
        Me.pnlOptions.TabIndex = 5
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.Location = New System.Drawing.Point(20, 2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(95, 35)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "   Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.UseVisualStyleBackColor = False
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
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Filters:"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'cmsOptions
        '
        Me.cmsOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsOutright, Me.cmsConsignor, Me.cmsOtherStore})
        Me.cmsOptions.Name = "cMenustrip"
        Me.cmsOptions.Size = New System.Drawing.Size(135, 70)
        '
        'cmsOutright
        '
        Me.cmsOutright.Image = CType(resources.GetObject("cmsOutright.Image"), System.Drawing.Image)
        Me.cmsOutright.Name = "cmsOutright"
        Me.cmsOutright.Size = New System.Drawing.Size(134, 22)
        Me.cmsOutright.Text = "&Outright"
        '
        'cmsConsignor
        '
        Me.cmsConsignor.Image = CType(resources.GetObject("cmsConsignor.Image"), System.Drawing.Image)
        Me.cmsConsignor.Name = "cmsConsignor"
        Me.cmsConsignor.Size = New System.Drawing.Size(134, 22)
        Me.cmsConsignor.Text = "&Consignor"
        '
        'cmsOtherStore
        '
        Me.cmsOtherStore.Image = CType(resources.GetObject("cmsOtherStore.Image"), System.Drawing.Image)
        Me.cmsOtherStore.Name = "cmsOtherStore"
        Me.cmsOtherStore.Size = New System.Drawing.Size(134, 22)
        Me.cmsOtherStore.Text = "Other &Store"
        '
        'PickListReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 560)
        Me.Controls.Add(Me.gbFilter)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PickListReportForm"
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFilter.ResumeLayout(False)
        Me.gbFilter.PerformLayout()
        Me.pnlOptions.ResumeLayout(False)
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents dtpCustomerOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents gbFilter As System.Windows.Forms.GroupBox
    Friend WithEvents pnlOptions As System.Windows.Forms.Panel
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmsOptions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsOutright As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsConsignor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsOtherStore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboFilterBy As System.Windows.Forms.ComboBox
End Class
