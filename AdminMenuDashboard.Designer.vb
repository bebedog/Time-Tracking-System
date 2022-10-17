<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminMenuDashboard
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
        Me.btnYTDGenerator = New System.Windows.Forms.Button()
        Me.btnManualSessionEntry = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnYTDGenerator
        '
        Me.btnYTDGenerator.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYTDGenerator.Location = New System.Drawing.Point(12, 12)
        Me.btnYTDGenerator.Name = "btnYTDGenerator"
        Me.btnYTDGenerator.Size = New System.Drawing.Size(120, 107)
        Me.btnYTDGenerator.TabIndex = 0
        Me.btnYTDGenerator.Text = "YTD Generator"
        Me.btnYTDGenerator.UseVisualStyleBackColor = True
        '
        'btnManualSessionEntry
        '
        Me.btnManualSessionEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManualSessionEntry.Location = New System.Drawing.Point(138, 12)
        Me.btnManualSessionEntry.Name = "btnManualSessionEntry"
        Me.btnManualSessionEntry.Size = New System.Drawing.Size(120, 107)
        Me.btnManualSessionEntry.TabIndex = 0
        Me.btnManualSessionEntry.Text = "Manual Session Entry"
        Me.btnManualSessionEntry.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(264, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(120, 107)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Exit Menu"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'AdminMenuDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 131)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnManualSessionEntry)
        Me.Controls.Add(Me.btnYTDGenerator)
        Me.Name = "AdminMenuDashboard"
        Me.Text = "AdminMenuDashboard"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnYTDGenerator As Button
    Friend WithEvents btnManualSessionEntry As Button
    Friend WithEvents btnExit As Button
End Class
