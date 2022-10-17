Imports System.Data.OleDb
Imports System.IO


'Change notes v2.6
'Added the function to auto clock out whenever someone forgets to clock out on Clock Shark.

'Change notes 2.7
'Temporarily removed the function to autoclock out.

Public Class Form1
    Public restartedMainDashBoard As Form
    Public TiTAversion As String = "2.7"
    Public newID As String
    Public Users() As String
    Public sessionUser As String
    Public sessionMondayId As String
    Public sessionUserSurname As String
    Public sessionDepartment As String
    Public sessionProjectNumber As String
    Public sessionSubTask As String
    Public firstSwitch As Boolean = True
    Dim conn As New OleDb.OleDbConnection
    'https://www.microsoft.com/en-us/download/confirmation.aspx?id=13255 you need to install this.
    Public Function ColumnToArray(ByVal col As String)
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & My.Settings.InventoryLocation & ""
        conn.Open()
        Dim command As String = "SELECT " + col + " FROM users"
        Dim cmd = New OleDbCommand(command, conn)
        Dim sdr = cmd.ExecuteReader()
        Dim list As New List(Of String)()
        While sdr.Read()
            list.Add(sdr(col).ToString)
        End While
        conn.Close()
        Return list.Distinct().ToArray
    End Function
    Public Sub closeDatabase()
        conn.Close()
    End Sub
    Public Function msgBoxInformative(ByVal mainText, ByVal headerText)
        MessageBox.Show(mainText, headerText, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'adminMenu.Show()
        Me.Text = "Lasermet TiTA | v" + TiTAversion
        positionLoginScreen()
        Me.TopMost = True
        If My.Settings.InventoryLocation = "" Then
            'IF THERE IS NO DATABASE FILE
            btnSignin.Text = "Setup"
        Else
            Users = ColumnToArray("User")
            closeDatabase()
            Try
                cbUsername.Items.AddRange(Users)
                cbUsername.DropDownStyle = ComboBoxStyle.DropDown
                cbUsername.AutoCompleteSource = AutoCompleteSource.ListItems
            Catch ex As Exception
                msgBoxInformative(ex.ToString, "Please contact admin.")
            End Try

            If My.Settings.LastUser = "" Then
                'IF THERE ARE NO LAST USER
                cbUsername.Select()
            Else
                'IF THERE ARE USER REMEMBERED
                cbUsername.SelectedItem = My.Settings.LastUser
                tbPassword.Select()
            End If
        End If
    End Sub
    Private Sub btnSignin_Click(sender As Object, e As EventArgs) Handles btnSignin.Click
        If My.Settings.InventoryLocation = "" Then
            'IF INVENTORY LOCATION IS NOT SPECIFIED YET
            OpenFileDialog1.InitialDirectory = "C:\\"
            OpenFileDialog1.Filter = "Database Files (*.mdb)|*.mdb"
            If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
                My.Settings.InventoryLocation = OpenFileDialog1.FileName
                msgBoxInformative("Location has ben set to: " + My.Settings.InventoryLocation, "Success!")
                My.Settings.Save()
                Application.Restart()
                'btnConnect.Enabled = True
            End If
        Else
            'IF THERE IS AN INVENTORY Database SUPPLIED.
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & My.Settings.InventoryLocation & ""
            Dim command As String = "SELECT * FROM users
                                 WHERE User='" & cbUsername.Text & "' AND
                                 Password='" & tbPassword.Text & "'"
            Dim cmd As OleDbCommand = New OleDbCommand(command, conn)
            conn.Open()
            Dim sdr As OleDbDataReader = cmd.ExecuteReader()
            If (sdr.Read() = True) Then
                'correct username and password
                sessionUser = sdr("User")
                If IsDBNull(sdr("UserID")) = True Then
                    msgBoxInformative("You have no monday.com ID." & Environment.NewLine & "Please contact admin", "Oops! Something went wrong.")
                    Me.Close()
                Else
                    My.Settings.sessionMondayId = sdr("UserID")
                    My.Settings.sessionUserSurname = sdr("Surname")
                    My.Settings.sessionDepartment = sdr("Department")
                    My.Settings.titaVersion = TiTAversion
                    My.Settings.Save()
                End If
                closeDatabase()
                My.Settings.LastUser = sessionUser
                My.Settings.Save()
                msgBoxInformative("Welcome, " & My.Settings.LastUser & "." + Environment.NewLine + "monday.com ID: " & My.Settings.sessionMondayId & "", "Login Authenticated")
                Me.Hide()
                Try
                    MainDashboard.Show()
                Catch
                End Try

            Else
                'incorrect username or password
                msgBoxInformative("Please check username or password.", "Incorrect username or password.")
                tbPassword.Text = ""
                closeDatabase()
                tbPassword.Select()
            End If
        End If
    End Sub
End Class
