Public Class AdminMenuDashboard
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
    Private Sub AdminMenuDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Lasermet TiTA v" & My.Settings.titaVersion & " | Admin Menu"
        positionLoginScreen()
    End Sub

    Private Sub AdminMenuDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MainDashTinood.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnYTDGenerator.Click
        adminMenu.Show()
        Me.Hide()
    End Sub

    Private Sub btnManualSessionEntry_Click(sender As Object, e As EventArgs) Handles btnManualSessionEntry.Click
        AddItemsManually.Show()
        Me.Hide()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        MainDashTinood.Show()
        Me.Close()
    End Sub
End Class