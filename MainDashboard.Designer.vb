﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainDashboard
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainDashboard))
        Me.btnSwitch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbJobsTasks = New System.Windows.Forms.ComboBox()
        Me.btnLunch = New System.Windows.Forms.Button()
        Me.btnBreak = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbSubTasks = New System.Windows.Forms.ComboBox()
        Me.SwitchCooldown = New System.Windows.Forms.Timer(Me.components)
        Me.lblStatus = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSwitch
        '
        Me.btnSwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btnSwitch.Location = New System.Drawing.Point(279, 138)
        Me.btnSwitch.Name = "btnSwitch"
        Me.btnSwitch.Size = New System.Drawing.Size(112, 42)
        Me.btnSwitch.TabIndex = 7
        Me.btnSwitch.Text = "Switch Task"
        Me.btnSwitch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Task/Jobs: "
        '
        'cbJobsTasks
        '
        Me.cbJobsTasks.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbJobsTasks.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbJobsTasks.FormattingEnabled = True
        Me.cbJobsTasks.Location = New System.Drawing.Point(107, 67)
        Me.cbJobsTasks.Name = "cbJobsTasks"
        Me.cbJobsTasks.Size = New System.Drawing.Size(281, 28)
        Me.cbJobsTasks.TabIndex = 5
        '
        'btnLunch
        '
        Me.btnLunch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btnLunch.Location = New System.Drawing.Point(160, 138)
        Me.btnLunch.Name = "btnLunch"
        Me.btnLunch.Size = New System.Drawing.Size(112, 42)
        Me.btnLunch.TabIndex = 8
        Me.btnLunch.Text = "Lunch"
        Me.btnLunch.UseVisualStyleBackColor = True
        '
        'btnBreak
        '
        Me.btnBreak.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btnBreak.Location = New System.Drawing.Point(42, 138)
        Me.btnBreak.Name = "btnBreak"
        Me.btnBreak.Size = New System.Drawing.Size(112, 42)
        Me.btnBreak.TabIndex = 9
        Me.btnBreak.Text = "Break"
        Me.btnBreak.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(-2, 207)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(410, 23)
        Me.ProgressBar1.Step = 50
        Me.ProgressBar1.TabIndex = 10
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbType.FormattingEnabled = True
        Me.cbType.Location = New System.Drawing.Point(107, 33)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(281, 28)
        Me.cbType.TabIndex = 11
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.LasermetProjectTimeTrackingApp.My.Resources.Resources.LaserTiTA_128x128
        Me.PictureBox1.Location = New System.Drawing.Point(91, -52)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(297, 288)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(54, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Filter:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(29, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 20)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Subtask:"
        '
        'cbSubTasks
        '
        Me.cbSubTasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSubTasks.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubTasks.FormattingEnabled = True
        Me.cbSubTasks.Location = New System.Drawing.Point(107, 99)
        Me.cbSubTasks.Name = "cbSubTasks"
        Me.cbSubTasks.Size = New System.Drawing.Size(281, 28)
        Me.cbSubTasks.TabIndex = 16
        '
        'SwitchCooldown
        '
        Me.SwitchCooldown.Interval = 1000
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(12, 191)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblStatus.TabIndex = 18
        Me.lblStatus.Text = "Status: "
        '
        'MainDashboard
        '
        Me.AcceptButton = Me.btnSwitch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 220)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbSubTasks)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbType)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnBreak)
        Me.Controls.Add(Me.btnLunch)
        Me.Controls.Add(Me.btnSwitch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbJobsTasks)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainDashboard"
        Me.Text = "Form2"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSwitch As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cbJobsTasks As ComboBox
    Friend WithEvents btnLunch As Button
    Friend WithEvents btnBreak As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents cbType As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbSubTasks As ComboBox
    Friend WithEvents SwitchCooldown As Timer
    Friend WithEvents lblStatus As Label
End Class
