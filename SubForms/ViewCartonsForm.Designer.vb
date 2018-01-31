<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewCartonsForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewCartonsForm))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.dgCartons = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ca_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_cartonno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_qtyincarton = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_packername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_packeddate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtQtyInCartonSum = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dgCartons, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(449, 28)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "View Cartons"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgCartons
        '
        Me.dgCartons.AllowUserToAddRows = False
        Me.dgCartons.AllowUserToDeleteRows = False
        Me.dgCartons.AllowUserToOrderColumns = True
        Me.dgCartons.AllowUserToResizeRows = False
        Me.dgCartons.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartons.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCartons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCartons.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ca_rowid, Me.ca_cartonno, Me.ca_qtyincarton, Me.ca_packername, Me.ca_packeddate, Me.ca_status})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCartons.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCartons.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCartons.Location = New System.Drawing.Point(13, 41)
        Me.dgCartons.MultiSelect = False
        Me.dgCartons.Name = "dgCartons"
        Me.dgCartons.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCartons.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgCartons.RowHeadersVisible = False
        Me.dgCartons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCartons.Size = New System.Drawing.Size(425, 240)
        Me.dgCartons.TabIndex = 1
        '
        'ca_rowid
        '
        Me.ca_rowid.HeaderText = "rowid"
        Me.ca_rowid.Name = "ca_rowid"
        Me.ca_rowid.ReadOnly = True
        Me.ca_rowid.Visible = False
        '
        'ca_cartonno
        '
        Me.ca_cartonno.HeaderText = "Carton No."
        Me.ca_cartonno.Name = "ca_cartonno"
        Me.ca_cartonno.ReadOnly = True
        Me.ca_cartonno.Width = 60
        '
        'ca_qtyincarton
        '
        Me.ca_qtyincarton.HeaderText = "Qty. In Carton"
        Me.ca_qtyincarton.Name = "ca_qtyincarton"
        Me.ca_qtyincarton.ReadOnly = True
        Me.ca_qtyincarton.Width = 60
        '
        'ca_packername
        '
        Me.ca_packername.HeaderText = "Packer Name"
        Me.ca_packername.Name = "ca_packername"
        Me.ca_packername.ReadOnly = True
        Me.ca_packername.Width = 120
        '
        'ca_packeddate
        '
        Me.ca_packeddate.HeaderText = "Packed Date"
        Me.ca_packeddate.Name = "ca_packeddate"
        Me.ca_packeddate.ReadOnly = True
        '
        'ca_status
        '
        Me.ca_status.HeaderText = "Status"
        Me.ca_status.Name = "ca_status"
        Me.ca_status.ReadOnly = True
        Me.ca_status.Width = 80
        '
        'txtQtyInCartonSum
        '
        Me.txtQtyInCartonSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtQtyInCartonSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyInCartonSum.Location = New System.Drawing.Point(208, 286)
        Me.txtQtyInCartonSum.Name = "txtQtyInCartonSum"
        Me.txtQtyInCartonSum.ReadOnly = True
        Me.txtQtyInCartonSum.Size = New System.Drawing.Size(75, 21)
        Me.txtQtyInCartonSum.TabIndex = 2
        Me.txtQtyInCartonSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(67, 290)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 15)
        Me.Label5.TabIndex = 470
        Me.Label5.Text = "Qty. In Carton (Sum):"
        '
        'ViewCartonsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(449, 312)
        Me.Controls.Add(Me.txtQtyInCartonSum)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgCartons)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewCartonsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgCartons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dgCartons As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ca_rowid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_cartonno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_qtyincarton As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_packername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_packeddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtQtyInCartonSum As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
