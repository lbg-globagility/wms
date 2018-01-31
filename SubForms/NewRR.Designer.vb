<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewRR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewRR))
        Me.cboPONo = New System.Windows.Forms.ComboBox()
        Me.rdBlankRR = New System.Windows.Forms.RadioButton()
        Me.rdPO = New System.Windows.Forms.RadioButton()
        Me.btnOKRR = New System.Windows.Forms.Button()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cboReturned = New System.Windows.Forms.ComboBox()
        Me.rdReturnNo = New System.Windows.Forms.RadioButton()
        Me.cboPullout = New System.Windows.Forms.ComboBox()
        Me.rdPulloutno = New System.Windows.Forms.RadioButton()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbReceivingInformation = New System.Windows.Forms.GroupBox()
        Me.Label55 = New System.Windows.Forms.Label()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbReceivingInformation.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboPONo
        '
        Me.cboPONo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboPONo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPONo.FormattingEnabled = True
        Me.cboPONo.Location = New System.Drawing.Point(105, 19)
        Me.cboPONo.Name = "cboPONo"
        Me.cboPONo.Size = New System.Drawing.Size(192, 23)
        Me.cboPONo.TabIndex = 5
        '
        'rdBlankRR
        '
        Me.rdBlankRR.AutoSize = True
        Me.rdBlankRR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdBlankRR.Location = New System.Drawing.Point(10, 105)
        Me.rdBlankRR.Name = "rdBlankRR"
        Me.rdBlankRR.Size = New System.Drawing.Size(83, 19)
        Me.rdBlankRR.TabIndex = 10
        Me.rdBlankRR.Text = "Blank R.R."
        Me.rdBlankRR.UseVisualStyleBackColor = True
        '
        'rdPO
        '
        Me.rdPO.AutoSize = True
        Me.rdPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdPO.Location = New System.Drawing.Point(10, 21)
        Me.rdPO.Name = "rdPO"
        Me.rdPO.Size = New System.Drawing.Size(73, 19)
        Me.rdPO.TabIndex = 4
        Me.rdPO.Text = "P.O. No.:"
        Me.rdPO.UseVisualStyleBackColor = True
        '
        'btnOKRR
        '
        Me.btnOKRR.Location = New System.Drawing.Point(113, 122)
        Me.btnOKRR.Name = "btnOKRR"
        Me.btnOKRR.Size = New System.Drawing.Size(106, 30)
        Me.btnOKRR.TabIndex = 11
        Me.btnOKRR.Text = "OK"
        Me.btnOKRR.UseVisualStyleBackColor = True
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'cboReturned
        '
        Me.cboReturned.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboReturned.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturned.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboReturned.FormattingEnabled = True
        Me.cboReturned.Location = New System.Drawing.Point(105, 48)
        Me.cboReturned.Name = "cboReturned"
        Me.cboReturned.Size = New System.Drawing.Size(192, 23)
        Me.cboReturned.TabIndex = 7
        '
        'rdReturnNo
        '
        Me.rdReturnNo.AutoSize = True
        Me.rdReturnNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdReturnNo.Location = New System.Drawing.Point(10, 49)
        Me.rdReturnNo.Name = "rdReturnNo"
        Me.rdReturnNo.Size = New System.Drawing.Size(87, 19)
        Me.rdReturnNo.TabIndex = 6
        Me.rdReturnNo.Text = "Return No.:"
        Me.rdReturnNo.UseVisualStyleBackColor = True
        '
        'cboPullout
        '
        Me.cboPullout.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboPullout.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPullout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPullout.FormattingEnabled = True
        Me.cboPullout.Location = New System.Drawing.Point(105, 77)
        Me.cboPullout.Name = "cboPullout"
        Me.cboPullout.Size = New System.Drawing.Size(192, 23)
        Me.cboPullout.TabIndex = 9
        '
        'rdPulloutno
        '
        Me.rdPulloutno.AutoSize = True
        Me.rdPulloutno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdPulloutno.Location = New System.Drawing.Point(10, 78)
        Me.rdPulloutno.Name = "rdPulloutno"
        Me.rdPulloutno.Size = New System.Drawing.Size(94, 19)
        Me.rdPulloutno.TabIndex = 8
        Me.rdPulloutno.Text = "Pull-Out No.:"
        Me.rdPulloutno.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(334, 28)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "New Receiving"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbReceivingInformation
        '
        Me.gbReceivingInformation.Controls.Add(Me.Label55)
        Me.gbReceivingInformation.Controls.Add(Me.cboPONo)
        Me.gbReceivingInformation.Controls.Add(Me.rdBlankRR)
        Me.gbReceivingInformation.Controls.Add(Me.cboPullout)
        Me.gbReceivingInformation.Controls.Add(Me.btnOKRR)
        Me.gbReceivingInformation.Controls.Add(Me.rdPulloutno)
        Me.gbReceivingInformation.Controls.Add(Me.rdPO)
        Me.gbReceivingInformation.Controls.Add(Me.cboReturned)
        Me.gbReceivingInformation.Controls.Add(Me.rdReturnNo)
        Me.gbReceivingInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReceivingInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbReceivingInformation.Location = New System.Drawing.Point(7, 33)
        Me.gbReceivingInformation.Name = "gbReceivingInformation"
        Me.gbReceivingInformation.Size = New System.Drawing.Size(320, 160)
        Me.gbReceivingInformation.TabIndex = 2
        Me.gbReceivingInformation.TabStop = False
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.White
        Me.Label55.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label55.Location = New System.Drawing.Point(9, -1)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(76, 17)
        Me.Label55.TabIndex = 3
        Me.Label55.Text = "R.R. Type:"
        '
        'NewRR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(334, 202)
        Me.Controls.Add(Me.gbReceivingInformation)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewRR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbReceivingInformation.ResumeLayout(False)
        Me.gbReceivingInformation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboPONo As System.Windows.Forms.ComboBox
    Friend WithEvents rdBlankRR As System.Windows.Forms.RadioButton
    Friend WithEvents rdPO As System.Windows.Forms.RadioButton
    Friend WithEvents btnOKRR As System.Windows.Forms.Button
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboPullout As System.Windows.Forms.ComboBox
    Friend WithEvents rdPulloutno As System.Windows.Forms.RadioButton
    Friend WithEvents cboReturned As System.Windows.Forms.ComboBox
    Friend WithEvents rdReturnNo As System.Windows.Forms.RadioButton
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents gbReceivingInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
End Class
