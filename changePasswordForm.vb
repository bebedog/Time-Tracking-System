Imports System.Data.OleDb

Public Class changePasswordForm
    Public Users() As String
    Public sessionUser As String
    Public sessionMondayId As String
    Public sessionUserSurname As String
    Public sessionDepartment As String
    Dim conn As New OleDb.OleDbConnection
    Dim conn1 As New OleDb.OleDbConnection
    Dim adapter As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim sdr As OleDbDataReader
    'https://www.microsoft.com/en-us/download/confirmation.aspx?id=13255 you need to install this.
    Public Function openDatabase(ByVal command As String)
        Dim conn As New OleDb.OleDbConnection
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & My.Settings.InventoryLocation & ""
        conn.Open()
        Dim cmd As OleDbCommand = New OleDbCommand(command, conn)
        Dim sdr As OleDbDataReader = cmd.ExecuteReader()
        Return sdr.Read()
    End Function
    Public Sub closeDatabase()
        conn.Close()
    End Sub
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
    Private Sub changePasswordForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        positionLoginScreen()
        tbNewPass.Select()
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        If (tbNewPass.Text = tbRENewPass.Text) Then
            'PASSWORDS ARE AN EXACT MATCH
            Dim inventoryQuery As String = "UPDATE users
                                        SET [Password]=@hehe
                                        WHERE User='" & Form1.sessionUser & "'"

            conn1.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & My.Settings.InventoryLocation & ""
            conn1.Open()
            Try
                cmd = New OleDbCommand(inventoryQuery, conn1)
                cmd.Parameters.AddWithValue("@hehe", tbNewPass.Text)
                cmd.ExecuteNonQuery()
                conn.Close()
                Form1.msgBoxInformative("Password has been successfully changed!", "Success!")
                Me.Close()
                MainDashTinood.Show()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            conn1.Close()

            'Dim accountInformation As String = "UPDATE users SET Password='" & tbNewPass.Text & "' WHERE User='" & Form1.sessionUser.ToString & "'"
            'conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & My.Settings.InventoryLocation & ""
            'conn.Open()
            'Try
            '    cmd = New OleDbCommand(accountInformation, conn)
            '    cmd.ExecuteNonQuery()
            '    conn.Close()
            '    Form1.msgBoxInformative("Hi, " + Form1.sessionUser + ". Your password has been updated.", "Success!")
            '    MainDashTinood.Show()
            '    Me.Close()
            'Catch ex As Exception
            '    Form1.msgBoxInformative("Please contact admin." + Environment.NewLine + ex.ToString, "Oops! Something went wrong!")
            '    Me.Close()
            'End Try
        Else
            'PASSWORDS ARE NOT A MATCH
            Form1.msgBoxInformative("Please make sure that you typed the same password for each field.", "Password mismatch!")
            tbNewPass.Clear()
            tbRENewPass.Clear()
            tbNewPass.Select()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainDashboard.Show()
        Me.Close()

    End Sub
End Class