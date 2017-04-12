<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTracker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTracker))
        Me.lblPhpRate = New System.Windows.Forms.Label()
        Me.lblUpdateDate = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblPhpRate
        '
        Me.lblPhpRate.AutoSize = True
        Me.lblPhpRate.Font = New System.Drawing.Font("AR CHRISTY", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhpRate.Location = New System.Drawing.Point(12, 9)
        Me.lblPhpRate.Name = "lblPhpRate"
        Me.lblPhpRate.Size = New System.Drawing.Size(133, 56)
        Me.lblPhpRate.TabIndex = 0
        Me.lblPhpRate.Text = "Label1"
        '
        'lblUpdateDate
        '
        Me.lblUpdateDate.AutoSize = True
        Me.lblUpdateDate.Location = New System.Drawing.Point(12, 65)
        Me.lblUpdateDate.Name = "lblUpdateDate"
        Me.lblUpdateDate.Size = New System.Drawing.Size(109, 17)
        Me.lblUpdateDate.TabIndex = 1
        Me.lblUpdateDate.Text = "Last Update on:"
        '
        'frmTracker
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(192, 103)
        Me.Controls.Add(Me.lblUpdateDate)
        Me.Controls.Add(Me.lblPhpRate)
        Me.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(210, 150)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(210, 150)
        Me.Name = "frmTracker"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "E-Remit Tracker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPhpRate As Label
    Friend WithEvents lblUpdateDate As Label
End Class
