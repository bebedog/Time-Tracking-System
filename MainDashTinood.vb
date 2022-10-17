Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports System.Reflection

Public Class MainDashTinood
    Dim apiKey As String = "eyJhbGciOiJIUzI1NiJ9.eyJ0aWQiOjE1MjU2NzQ3OCwidWlkIjoxNTA5MzQwNywiaWFkIjoiMjAyMi0wMy0yNVQwMTo0Njo1My4wMDBaIiwicGVyIjoibWU6d3JpdGUiLCJhY3RpZCI6NjYxMjMxMCwicmduIjoidXNlMSJ9.F1TqwLS-QsuM8Ss3UcgskbNFUIer1dfwfoLyPMq1pbc"
    Public newID As String
    Public cooldown As Integer = 60
    Public Class Data
        Public Property items_by_column_values As List(Of ItemsByColumnValue)
        Public Property boards As List(Of Board)
        Public Property items As List(Of Item)
        Public Property change_multiple_column_values As ChangeMultipleColumnValues
        Public Property create_item As CreateItem
    End Class
    Public Class CreateItem
        Public Property id As String
    End Class
    Public Class ChangeMultipleColumnValues
        Public Property id As String
    End Class
    Public Class ColumnValue
        Public Property id As String
        Public Property text As String
    End Class
    Public Class Board
        Public Property items As List(Of Item)
    End Class
    Public Class Item
        Public Property name As String
        Public Property column_values As List(Of ColumnValue)
    End Class
    Public Class ItemsByColumnValue
        Public Property id As String
    End Class
    Public Class Root
        Public Property data As Data
        Public Property account_id As Integer
    End Class
    Public Function apiRequest(ByVal myData As String)
        Try
            Dim myReq As HttpWebRequest
            Dim myResp As HttpWebResponse
            Dim myReader As StreamReader
            myReq = DirectCast(WebRequest.Create("https://api.monday.com/v2"), HttpWebRequest)
            myReq.Method = "POST"
            myReq.ContentType = "application/json"
            myReq.Accept = "application/json"
            myReq.Headers.Add("Authorization", apiKey)
            myReq.GetRequestStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, System.Text.Encoding.UTF8.GetBytes(myData).Count)
            myResp = myReq.GetResponse
            myReader = New System.IO.StreamReader(myResp.GetResponseStream)
            Dim jsonResponse As String = myReader.ReadToEnd
            Return jsonResponse
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error!")
        End Try
    End Function
    Public Sub positionLoginScreen()
        Me.Visible = True
        Dim x As Integer
        Dim y As Integer
        x = Screen.PrimaryScreen.WorkingArea.Width
        y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height

        Do Until x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
            x = x - 1
            Me.Location = New Point(x, y)
        Loop

    End Sub
    Public Sub reminder()
        NotifyIcon1.BalloonTipText = "Are you still working on " + lblTask.Text + "?"
        NotifyIcon1.ShowBalloonTip(1000)
    End Sub
    Public Sub reminderLunch()
        NotifyIcon1.BalloonTipText = "Are you still on lunch break?"
        NotifyIcon1.ShowBalloonTip(300000)
    End Sub
    Public Sub reminderBreak()
        NotifyIcon1.BalloonTipText = "Are you still on break?"
        NotifyIcon1.ShowBalloonTip(300000)
    End Sub
    Private Sub MainDashTinood_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnSwitch.Enabled = False
        CooldownTimer.Enabled = True
        If MainDashboard.IsDisposed Then
            'original main dashboard instance was disposed is closed
            newID = My.Settings.newID
        Else
            newID = My.Settings.newID
        End If
        If Form1.sessionUser = "Jayson" Or Form1.sessionUser = "Christiane" Then
            lblAdminMenu.Visible = True
        Else
            lblAdminMenu.Visible = False
        End If

        btnPost.Enabled = False
        Me.Size = New Size(400, 222)
        tbNotes.Hide()
        Button1.Visible = True
        'detects whether user has admin rights.
        positionLoginScreen()
        Me.TopMost = True
        Dim takeColumnValuesOfCurrentJob As String = "{""query"":""query{\r\n    items(ids:[" & newID & "]){\r\n        column_values(ids:[job,text]){\r\n            text\r\n        }\r\n    }\r\n}"",""variables"":{}}"
        Dim responseStatus As String = apiRequest(takeColumnValuesOfCurrentJob)
        Dim obj1 = JsonConvert.DeserializeObject(Of Root)(responseStatus)
        Dim Task As String = obj1.data.items(0).column_values(0).text.ToString()
        Dim clockIn As String = obj1.data.items(0).column_values(1).text.ToString
        lblUserWelcome.Text = "Welcome, " + Form1.sessionUser + " " + Form1.sessionUserSurname + "."
        lblTimeIn.Text = clockIn
        lblTask.Text = Task
        lblDepartment.Text = "Department: " + Form1.sessionDepartment
        lblSubtasks.Text = MainDashboard.sessionSubTask
        If My.Settings.sessionProjectNumber = "" Then
            lblProjectNumber.Text = "N/A"
        Else
            lblProjectNumber.Text = My.Settings.sessionProjectNumber
        End If
    End Sub
    Private Sub btnSwitchTask_Click(sender As Object, e As EventArgs)
        MainDashboard.Show()
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'minimize to tray button
        If lblTask.Text = "Lunch" Then
            NotifyIcon1.Visible = True
            NotifyIcon1.Text = Form1.sessionUser + " | " + lblTask.Text
            Me.Hide()
            NotifyIcon1.BalloonTipText = "TiTA is now working in the background and will remind you in an hour to switch other task. Enjoy your lunch!"
            NotifyIcon1.ShowBalloonTip(1000)
            Timer2.Enabled = True
            Timer2.Interval = 3600000
        ElseIf lblTask.Text = "Break" Then
            NotifyIcon1.Visible = True
            NotifyIcon1.Text = Form1.sessionUser + " | " + lblTask.Text
            Me.Hide()
            NotifyIcon1.BalloonTipText = "TiTA is now working in the background and will remind you in 15 minutes. Have a nice break!"
            NotifyIcon1.ShowBalloonTip(1000)
            Timer3.Enabled = True
            Timer3.Interval = 900000
        Else
            NotifyIcon1.Visible = True
            NotifyIcon1.Text = Form1.sessionUser + " | " + lblTask.Text
            Me.Hide()
            NotifyIcon1.BalloonTipText = "TiTA is now working in the background and will remind you in an hour about your current task."
            NotifyIcon1.ShowBalloonTip(1000)
            Timer1.Interval = 3600000
            Timer1.Enabled = True
        End If
    End Sub
    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Timer1.Enabled = False
        positionLoginScreen()
        NotifyIcon1.Visible = False
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        reminder()
    End Sub
    Private Sub NotifyIcon1_BalloonTipClicked(sender As Object, e As EventArgs) Handles NotifyIcon1.BalloonTipClicked
        Me.Show()
        Timer1.Enabled = False
        positionLoginScreen()
        NotifyIcon1.Visible = False
    End Sub
    Private Sub SwitchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SwitchToolStripMenuItem.Click
        Dim dia As DialogResult = MessageBox.Show("Are you sure you want to switch tasks?", "Switch Task Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dia = DialogResult.Yes Then
            'IF CONFIRMED
            MainDashboard.Show()
            Me.Close()
        Else
            'IF NOT CONFIRMERD

        End If
    End Sub
    Private Sub ClockOutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim dialog As DialogResult = MessageBox.Show("Do you really wish to clock out?" + Environment.NewLine + "This will bring you back to the login page.",
                                             "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            'CLOCK OUT Commands here
            Form1.Show()
            Me.Close()
        Else

        End If
    End Sub
    Private Sub NotifyIcon1_Click(sender As Object, e As EventArgs) Handles NotifyIcon1.Click
        NotifyIcon1.ContextMenuStrip = ContextMenuStrip1
        Dim mi = GetType(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.NonPublic Or BindingFlags.Instance)
        mi.Invoke(NotifyIcon1, Nothing)
    End Sub
    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Me.Hide()
        changePasswordForm.Show()
    End Sub
    Private Sub btnSwitch_Click(sender As Object, e As EventArgs) Handles btnSwitch.Click
        Dim dia As DialogResult = MessageBox.Show("Are you sure you want to switch tasks?", "Switch Task Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dia = DialogResult.Yes Then
            'IF CONFIRMED
            MainDashboard.Show()
            Me.Close()
        Else
            'IF NOT CONFIRMERD

        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        reminderLunch()
    End Sub
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        reminderBreak()
    End Sub
    Private Sub btnAddJobs_Click(sender As Object, e As EventArgs)
        Me.Hide()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Visible = False
        tbNotes.Show()
        Me.Size = New Size(400, 350)
        btnHide.Visible = True
        btnPost.Visible = True
        btnPost.Enabled = True
        Button1.Visible = False
        positionLoginScreen()
        tbNotes.Select()
    End Sub
    Private Sub btnHide_Click(sender As Object, e As EventArgs) Handles btnHide.Click
        Me.Size = New Size(400, 222)
        tbNotes.Hide()
        btnPost.Enabled = False
        Button1.Visible = True
        btnHide.Visible = False
        btnPost.Visible = True
        positionLoginScreen()
    End Sub
    Private Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If tbNotes.Text = "" Then
            'notes is empty
            Form1.msgBoxInformative("Text box is empty.", "Oops, something went wrong!")
        Else
            Try
                Dim postCommand As String = "{""query"":""mutation{create_update(item_id:" & newID & ", body:\""" & tbNotes.Text & "\"") {\r\n  id\r\n}}"",""variables"":{}}"
                apiRequest(postCommand)
                Form1.msgBoxInformative("Update succesfully posted!", "Success!")
                tbNotes.Clear()
                btnHide.PerformClick()
            Catch ex As Exception
                Form1.msgBoxInformative("Please make sure that you are connected to the internet." + Environment.NewLine + ex.ToString, "Oops, something went wrong!")
            End Try
        End If
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Process.Start("https://lasermet-team.monday.com/boards/2628729848/pulses/" + newID)
    End Sub
    Private Sub lblAdminMenu_Click(sender As Object, e As EventArgs) Handles lblAdminMenu.Click
        Me.Hide()
        AdminMenuDashboard.Show()
    End Sub
    Private Sub CooldownTimer_Tick(sender As Object, e As EventArgs) Handles CooldownTimer.Tick
        btnSwitch.Text = "Switch Task (" + cooldown.ToString + ")"
        cooldown -= 1
        If cooldown = 0 Then
            CooldownTimer.Enabled = False
            btnSwitch.Enabled = True
            btnSwitch.Text = "Switch Task"
        End If
    End Sub
End Class