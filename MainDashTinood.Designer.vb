<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainDashTinood
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainDashTinood))
        Me.lblUserWelcome = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTask = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTimeIn = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SwitchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSwitch = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.lblProjectNumber = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbNotes = New System.Windows.Forms.RichTextBox()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.btnHide = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.overTimeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSubtasks = New System.Windows.Forms.Label()
        Me.lblAdminMenu = New System.Windows.Forms.Label()
        Me.CooldownTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblUserWelcome
        '
        Me.lblUserWelcome.AutoSize = True
        Me.lblUserWelcome.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserWelcome.Location = New System.Drawing.Point(12, 10)
        Me.lblUserWelcome.Name = "lblUserWelcome"
        Me.lblUserWelcome.Size = New System.Drawing.Size(190, 20)
        Me.lblUserWelcome.TabIndex = 0
        Me.lblUserWelcome.Text = "Welcome, LeBron James."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Current Task:"
        '
        'lblTask
        '
        Me.lblTask.AutoSize = True
        Me.lblTask.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTask.ForeColor = System.Drawing.Color.Red
        Me.lblTask.Location = New System.Drawing.Point(122, 50)
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Size = New System.Drawing.Size(109, 20)
        Me.lblTask.TabIndex = 3
        Me.lblTask.Text = "TASK NAME"
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(208, 135)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(186, 63)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Minimize to Tray"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Time Started:"
        '
        'lblTimeIn
        '
        Me.lblTimeIn.AutoSize = True
        Me.lblTimeIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeIn.ForeColor = System.Drawing.Color.Red
        Me.lblTimeIn.Location = New System.Drawing.Point(122, 70)
        Me.lblTimeIn.Name = "lblTimeIn"
        Me.lblTimeIn.Size = New System.Drawing.Size(124, 20)
        Me.lblTimeIn.TabIndex = 7
        Me.lblTimeIn.Text = "TASK TIME IN"
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartment.Location = New System.Drawing.Point(12, 30)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(94, 20)
        Me.lblDepartment.TabIndex = 9
        Me.lblDepartment.Text = "Department"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Lasermet TiTa"
        Me.NotifyIcon1.Visible = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 3600000
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.LasermetProjectTimeTrackingApp.My.Resources.Resources.LaserTiTA_128x128
        Me.PictureBox1.Location = New System.Drawing.Point(105, -50)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(297, 288)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(117, 48)
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SwitchToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.MenuToolStripMenuItem.Text = "Task"
        '
        'SwitchToolStripMenuItem
        '
        Me.SwitchToolStripMenuItem.Name = "SwitchToolStripMenuItem"
        Me.SwitchToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.SwitchToolStripMenuItem.Text = "Switch"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ChangePasswordToolStripMenuItem.Text = "Change password"
        '
        'btnSwitch
        '
        Me.btnSwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSwitch.Location = New System.Drawing.Point(12, 135)
        Me.btnSwitch.Name = "btnSwitch"
        Me.btnSwitch.Size = New System.Drawing.Size(186, 63)
        Me.btnSwitch.TabIndex = 2
        Me.btnSwitch.Text = "Switch Task"
        Me.btnSwitch.UseVisualStyleBackColor = True
        '
        'Timer2
        '
        '
        'Timer3
        '
        '
        'lblProjectNumber
        '
        Me.lblProjectNumber.AutoSize = True
        Me.lblProjectNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProjectNumber.ForeColor = System.Drawing.Color.Red
        Me.lblProjectNumber.Location = New System.Drawing.Point(122, 90)
        Me.lblProjectNumber.Name = "lblProjectNumber"
        Me.lblProjectNumber.Size = New System.Drawing.Size(89, 20)
        Me.lblProjectNumber.TabIndex = 12
        Me.lblProjectNumber.Text = "69696969"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Project No.:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1, 202)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(401, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Notes"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbNotes
        '
        Me.tbNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNotes.Location = New System.Drawing.Point(12, 206)
        Me.tbNotes.Name = "tbNotes"
        Me.tbNotes.Size = New System.Drawing.Size(382, 110)
        Me.tbNotes.TabIndex = 15
        Me.tbNotes.Text = ""
        '
        'btnPost
        '
        Me.btnPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btnPost.Location = New System.Drawing.Point(319, 322)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(75, 36)
        Me.btnPost.TabIndex = 16
        Me.btnPost.Text = "Post"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'btnHide
        '
        Me.btnHide.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHide.Location = New System.Drawing.Point(238, 322)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(75, 36)
        Me.btnHide.TabIndex = 16
        Me.btnHide.Text = "Hide"
        Me.btnHide.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Location = New System.Drawing.Point(13, 324)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Click here to view item on browser."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(44, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Subtask:"
        '
        'lblSubtasks
        '
        Me.lblSubtasks.AutoSize = True
        Me.lblSubtasks.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtasks.ForeColor = System.Drawing.Color.Red
        Me.lblSubtasks.Location = New System.Drawing.Point(122, 110)
        Me.lblSubtasks.Name = "lblSubtasks"
        Me.lblSubtasks.Size = New System.Drawing.Size(122, 20)
        Me.lblSubtasks.TabIndex = 12
        Me.lblSubtasks.Text = "3-Point Dunks"
        Me.lblSubtasks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAdminMenu
        '
        Me.lblAdminMenu.AutoSize = True
        Me.lblAdminMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAdminMenu.Location = New System.Drawing.Point(13, 338)
        Me.lblAdminMenu.Name = "lblAdminMenu"
        Me.lblAdminMenu.Size = New System.Drawing.Size(66, 13)
        Me.lblAdminMenu.TabIndex = 18
        Me.lblAdminMenu.Text = "Admin Menu"
        '
        'CooldownTimer
        '
        Me.CooldownTimer.Interval = 1000
        '
        'MainDashTinood
        '
        Me.AcceptButton = Me.btnPost
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(400, 370)
        Me.Controls.Add(Me.lblAdminMenu)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnHide)
        Me.Controls.Add(Me.btnPost)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblSubtasks)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblProjectNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnSwitch)
        Me.Controls.Add(Me.lblDepartment)
        Me.Controls.Add(Me.lblTimeIn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblTask)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblUserWelcome)
        Me.Controls.Add(Me.tbNotes)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainDashTinood"
        Me.Text = "TiTA v2.0"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblUserWelcome As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTask As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTimeIn As Label
    Friend WithEvents lblDepartment As Label
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SwitchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnSwitch As Button
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Timer3 As Timer
    Friend WithEvents lblProjectNumber As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents tbNotes As RichTextBox
    Friend WithEvents btnPost As Button
    Friend WithEvents btnHide As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents overTimeTimer As Timer
    Friend WithEvents Label5 As Label
    Friend WithEvents lblSubtasks As Label
    Friend WithEvents lblAdminMenu As Label
    Friend WithEvents CooldownTimer As Timer
End Class
