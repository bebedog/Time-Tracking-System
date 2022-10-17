Imports System.IO
Imports System.Net
Imports System.Threading
Imports Newtonsoft.Json
Imports Newtonsoft.Json.JsonConvert
Public Class AddItemsManually
    Dim apiKey As String = "eyJhbGciOiJIUzI1NiJ9.eyJ0aWQiOjE1MjU2NzQ3OCwidWlkIjoxNTA5MzQwNywiaWFkIjoiMjAyMi0wMy0yNVQwMTo0Njo1My4wMDBaIiwicGVyIjoibWU6d3JpdGUiLCJhY3RpZCI6NjYxMjMxMCwicmduIjoidXNlMSJ9.F1TqwLS-QsuM8Ss3UcgskbNFUIer1dfwfoLyPMq1pbc"
    'VB.NET CLASSES HERE
    ' Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    Public Class Board
        Public Property items As List(Of Item)
    End Class

    Public Class ColumnValue
        Public Property value As String
        Public Property additional_info As Object
    End Class

    Public Class Data
        Public Property boards As List(Of Board)
    End Class

    Public Class Item
        Public Property column_values As List(Of ColumnValue)
    End Class

    Public Class AdditionalValue
        Public Property id As Integer
        Public Property account_id As Integer
        Public Property project_id As Object
        Public Property column_id As String
        Public Property started_user_id As Integer
        Public Property ended_user_id As Integer?
        Public Property started_at As Date
        Public Property ended_at As Date?
        Public Property manually_entered_start_time As Boolean
        Public Property manually_entered_end_time As Boolean
        Public Property manually_entered_start_date As Boolean
        Public Property manually_entered_end_date As Boolean
        Public Property created_at As Date
        Public Property updated_at As Date
        Public Property status As String
    End Class

    Public Class Root
        Public Property data As Data
        Public Property account_id As Integer
        Public Property running As String
        Public Property duration As Integer
        Public Property startDate As Integer
        Public Property changed_at As Date
        Public Property additional_value As List(Of AdditionalValue)
    End Class
    'VB.NET CLASSES HERE

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
    Private Sub AddItemsManually_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Admin Menu | Add Manual Session"
        positionLoginScreen()
    End Sub

    Private Sub AddItemsManually_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminMenuDashboard.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sampleRequest As String = "{""query"":""query{\r\n  boards(ids:2628729848){\r\n    items(ids:2877529403){\r\n      column_values(ids:time_tracking0){\r\n        value\r\n        additional_info\r\n      }\r\n    }\r\n  }\r\n}"",""variables"":{}}"
        Dim obj = JsonConvert.DeserializeObject(Of Root)(apiRequest(sampleRequest))
        Dim resultTime As String = obj.data.boards(0).items(0).column_values(0).value.ToString
        RichTextBox1.Text = resultTime
        Dim obj2 = JsonConvert.DeserializeObject(Of Root)(resultTime)

    End Sub
End Class