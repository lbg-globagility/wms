<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutomatePickingOfPickListForm
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
        Me.ProgressTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CompletionProgressBar = New System.Windows.Forms.ProgressBar()
        Me.CurrentMessageLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CompletionProgressBar
        '
        Me.CompletionProgressBar.Location = New System.Drawing.Point(309, 169)
        Me.CompletionProgressBar.Name = "CompletionProgressBar"
        Me.CompletionProgressBar.Size = New System.Drawing.Size(100, 23)
        Me.CompletionProgressBar.TabIndex = 0
        '
        'CurrentMessageLabel
        '
        Me.CurrentMessageLabel.AutoSize = True
        Me.CurrentMessageLabel.Location = New System.Drawing.Point(159, 252)
        Me.CurrentMessageLabel.Name = "CurrentMessageLabel"
        Me.CurrentMessageLabel.Size = New System.Drawing.Size(39, 13)
        Me.CurrentMessageLabel.TabIndex = 1
        Me.CurrentMessageLabel.Text = "Label1"
        '
        'AutomatePickingOfPickListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CurrentMessageLabel)
        Me.Controls.Add(Me.CompletionProgressBar)
        Me.Name = "AutomatePickingOfPickListForm"
        Me.Text = "AutomatePickingOfPickListForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressTimer As Timer
    Friend WithEvents CompletionProgressBar As ProgressBar
    Friend WithEvents CurrentMessageLabel As Label
End Class
