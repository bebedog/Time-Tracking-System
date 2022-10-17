<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class changePasswordForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnChangePassword = New System.Windows.Forms.Button()
        Me.tbNewPass = New System.Windows.Forms.TextBox()
        Me.tbRENewPass = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter new password:"
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangePassword.Location = New System.Drawing.Point(272, 116)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(74, 52)
        Me.btnChangePassword.TabIndex = 1
        Me.btnChangePassword.Text = "Change password"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        'tbNewPass
        '
        Me.tbNewPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNewPass.Location = New System.Drawing.Point(12, 32)
        Me.tbNewPass.Name = "tbNewPass"
        Me.tbNewPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbNewPass.Size = New System.Drawing.Size(414, 26)
        Me.tbNewPass.TabIndex = 2
        '
        'tbRENewPass
        '
        Me.tbRENewPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRENewPass.Location = New System.Drawing.Point(12, 84)
        Me.tbRENewPass.Name = "tbRENewPass"
        Me.tbRENewPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbRENewPass.Size = New System.Drawing.Size(414, 26)
        Me.tbRENewPass.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Re-enter new password:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.LasermetProjectTimeTrackingApp.My.Resources.Resources.LaserTiTA_128x128
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(297, 288)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(352, 116)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 52)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'changePasswordForm
        '
        Me.AcceptButton = Me.btnChangePassword
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 178)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tbRENewPass)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbNewPass)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "changePasswordForm"
        Me.Text = "changePasswordForm"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnChangePassword As Button
    Friend WithEvents tbNewPass As TextBox
    Friend WithEvents tbRENewPass As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
End Class
