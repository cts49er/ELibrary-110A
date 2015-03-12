<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGitHub
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
        Me.lblGitHubTest = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblGitHubTest
        '
        Me.lblGitHubTest.AutoSize = True
        Me.lblGitHubTest.Location = New System.Drawing.Point(38, 50)
        Me.lblGitHubTest.Name = "lblGitHubTest"
        Me.lblGitHubTest.Size = New System.Drawing.Size(184, 13)
        Me.lblGitHubTest.TabIndex = 0
        Me.lblGitHubTest.Text = "This is just to teste the GitHub feature"
        '
        'frmGitHub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.lblGitHubTest)
        Me.Name = "frmGitHub"
        Me.Text = "GitHub"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGitHubTest As System.Windows.Forms.Label
End Class
