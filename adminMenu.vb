Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports System.Threading

Public Class adminMenu
    Dim apiKey As String = "eyJhbGciOiJIUzI1NiJ9.eyJ0aWQiOjE1MjU2NzQ3OCwidWlkIjoxNTA5MzQwNywiaWFkIjoiMjAyMi0wMy0yNVQwMTo0Njo1My4wMDBaIiwicGVyIjoibWU6d3JpdGUiLCJhY3RpZCI6NjYxMjMxMCwicmduIjoidXNlMSJ9.F1TqwLS-QsuM8Ss3UcgskbNFUIer1dfwfoLyPMq1pbc"
    Dim allProjectNumber() As String
    Dim timeOfProjectNumber() As Decimal
    Dim timeOnCertainProject() As Decimal
    Dim mondayIDOfProjectNumber() As String


    Dim subtasksOnEveryTasks(,) As String
    Dim subtaskNameOnEveryTask(,) As String
    Dim timeOnEverySubTask(,) As Decimal
    Dim boardIDoFEachSubTask(,) As String

    Dim t1 As Thread
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

    'JSON CLASSES
    Public Class Board
        Public Property items As List(Of Item)
    End Class

    Public Class Board2
        Public Property id As String
    End Class


    Public Class ColumnValue
        Public Property title As String
        Public Property text As String
    End Class
    Public Class ItemsByColumnValue
        Public Property column_values As List(Of ColumnValue)
        Public Property id As String
    End Class

    Public Class Group
        Public Property title As String
    End Class

    Public Class ItemsByMultipleColumnValue
        Public Property group As Group
        Public Property column_values As List(Of ColumnValue)
    End Class


    Public Class Data
        Public Property items_by_column_values As List(Of ItemsByColumnValue)
        Public Property boards As List(Of Board)
        Public Property items_by_multiple_column_values As List(Of ItemsByMultipleColumnValue)
    End Class

    Public Class Item
        Public Property id As String
        Public Property name As String
        Public Property column_values As List(Of ColumnValue)
        Public Property subitems As List(Of Subitem)
    End Class

    Public Class Subitem
        Public Property board As Board2
        Public Property id As String
        Public Property name As String
    End Class
    Public Class Root
        Public Property data As Data
        Public Property account_id As Integer
    End Class
    'JSON CLASSES


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

    Private Sub adminMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        positionLoginScreen()
        CheckForIllegalCrossThreadCalls = False
        Me.TopMost = True

        Me.Name = "Admin Menu | " + Form1.sessionUser
        Me.Size = New Size(431, 117)
        lblStatus.Visible = False
        ProgressBar1.Visible = False
        t1 = New Thread(AddressOf SubTaskHoursGenerator)
    End Sub

    Private Sub adminMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminMenuDashboard.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'YTDManHoursGenerator()
        Me.Size = New Size(431, 177)
        Button1.Enabled = False
        Button2.Enabled = False
        lblStatus.Visible = True
        lblStatus.Text = "Loading.."
        ProgressBar1.Visible = True
        ProgressBar1.Step = 1
        t1.Start()
        'OLD CODE
        'Dim queryAllTimeInTest As String = "{""query"":""{\r\n  boards(ids: 2718204773) {\r\n    items {\r\n      column_values(ids: text) {\r\n        text\r\n      }\r\n    }\r\n  }\r\n}\r\n"",""variables"":{}}"
        'Dim obj1 = JsonConvert.DeserializeObject(Of Root)(apiRequest(queryAllTimeInTest))
        'If obj1.data.boards Is Nothing Then
        '    Button1.PerformClick()
        'Else
        '    Try

        '        Dim x As Integer = obj1.data.boards(0).items.Count - 1
        '        ReDim allProjectNumber(x)
        '        ReDim timeOfProjectNumber(x)
        '        ReDim mondayIDOfProjectNumber(x)

        '        For w As Integer = 0 To x
        '            allProjectNumber(w) = obj1.data.boards(0).items(w).column_values(0).text
        '        Next

        '        For w As Integer = 0 To x
        '            Dim queryHoursViaProjectCode As String = "{""query"":""{\r\n  items_by_multiple_column_values(board_id: 2628729848, column_id: dup__of_project_code4, column_values: \""" & allProjectNumber(w) & "\"") {\r\n    group {\r\n      title\r\n    }\r\n    column_values(ids: time_tracking0) {\r\n      title\r\n      text\r\n    }\r\n  }\r\n}\r\n"",""variables"":{}}"
        '            Dim obj = JsonConvert.DeserializeObject(Of Root)(apiRequest(queryHoursViaProjectCode))
        '            Dim op As Integer = obj.data.items_by_multiple_column_values.Count() - 1
        '            Console.WriteLine((op + 1).ToString)
        '            ReDim timeOnCertainProject(op)
        '            For z As Integer = 0 To op
        '                Dim currHour As Decimal = CDec(Int(obj.data.items_by_multiple_column_values(z).column_values(0).text.Substring(0, 2)))
        '                Dim currMin As Decimal = CDec(Int(obj.data.items_by_multiple_column_values(z).column_values(0).text.Substring(3, 2)) / 60)
        '                Dim currSec As Decimal = CDec(Int(obj.data.items_by_multiple_column_values(z).column_values(0).text.Substring(6, 2)) / 3600)
        '                Dim totalHours As Decimal = currHour + currMin + currSec
        '                timeOnCertainProject(z) = Decimal.Round(totalHours, 2)
        '                timeOfProjectNumber(w) += timeOnCertainProject(z)
        '            Next
        '            Console.WriteLine(allProjectNumber(w).ToString + " has logged " + timeOfProjectNumber(w).ToString + " hours.")
        '        Next

        '        For k As Integer = 0 To x
        '            Dim queryIDOfTaskGivenProjectCode As String = "{""query"":""query{\r\n  items_by_column_values(board_id: 2718204773, column_id: text, column_value: \""" & allProjectNumber(k) & "\"") {\r\n    id\r\n  }\r\n}"",""variables"":{}}"
        '            Dim objResponse = JsonConvert.DeserializeObject(Of Root)(apiRequest(queryIDOfTaskGivenProjectCode))
        '            mondayIDOfProjectNumber(k) = objResponse.data.items_by_column_values(0).id
        '            Console.WriteLine(allProjectNumber(k) + " | " + timeOfProjectNumber(k).ToString + " hours | monday.com ID: " + mondayIDOfProjectNumber(k))
        '        Next

        '        For v As Integer = 0 To x
        '            Dim queryChangeItemValue As String = "{""query"":""mutation {\r\n  change_multiple_column_values (item_id: " & mondayIDOfProjectNumber(v) & ", board_id: 2718204773, column_values:\""{\\\""dup__of_ytd_expense\\\"":\\\""" & timeOfProjectNumber(v) & "\\\""}\""){\r\n      id\r\n  }\r\n}"",""variables"":{}}"
        '            apiRequest(queryChangeItemValue)
        '        Next



        '    Catch

        '    End Try
        'End If
        'OLD CODE
    End Sub

    Public Sub YTDManHoursGenerator()
        Dim queryAllTimeInTest As String = "{""query"":""{\r\n  boards(ids: 2718204773) {\r\n    items {\r\n      column_values(ids: text) {\r\n        text\r\n      }\r\n    }\r\n  }\r\n}\r\n"",""variables"":{}}"
        Dim obj1 = JsonConvert.DeserializeObject(Of Root)(apiRequest(queryAllTimeInTest))
        If obj1.data.boards Is Nothing Then
            'no internet connection
        Else
            Try

                lblStatus.Text = "Loading..."
                Dim x As Integer = obj1.data.boards(0).items.Count - 1
                ReDim allProjectNumber(x)
                ReDim timeOfProjectNumber(x)
                ReDim mondayIDOfProjectNumber(x)

                ProgressBar1.Maximum = x + 1
                'this code takes all the project numbers from the projects list.
                For w As Integer = 0 To x
                    allProjectNumber(w) = obj1.data.boards(0).items(w).column_values(0).text
                    lblStatus.Text = "Project Number: " + allProjectNumber(w).ToString + " found."
                    ProgressBar1.PerformStep()
                Next

                ProgressBar1.Value = 0

                'this code takes all the project names from the projects list.
                For w As Integer = 0 To x
                    Dim queryHoursViaProjectCode As String = "{""query"":""{\r\n  items_by_multiple_column_values(board_id: 2628729848, column_id: dropdown, column_values: \""" & allProjectNumber(w) & "\"") {\r\n    group {\r\n      title\r\n    }\r\n    column_values(ids: time_tracking0) {\r\n      title\r\n      text\r\n    }\r\n  }\r\n}\r\n"",""variables"":{}}"
                    Dim obj = JsonConvert.DeserializeObject(Of Root)(apiRequest(queryHoursViaProjectCode))
                    Dim op As Integer = obj.data.items_by_multiple_column_values.Count() - 1
                    Console.WriteLine((op + 1).ToString)
                    ReDim timeOnCertainProject(op)
                    For z As Integer = 0 To op
                        Dim currHour As Decimal = CDec(Int(obj.data.items_by_multiple_column_values(z).column_values(0).text.Substring(0, 2)))
                        Dim currMin As Decimal = CDec(Int(obj.data.items_by_multiple_column_values(z).column_values(0).text.Substring(3, 2)) / 60)
                        Dim currSec As Decimal = CDec(Int(obj.data.items_by_multiple_column_values(z).column_values(0).text.Substring(6, 2)) / 3600)
                        Dim totalHours As Decimal = currHour + currMin + currSec
                        timeOnCertainProject(z) = Decimal.Round(totalHours, 2)
                        timeOfProjectNumber(w) += timeOnCertainProject(z)
                    Next
                    lblStatus.Text = "Project Number: " + allProjectNumber(w) + " found with a total logged time of " + timeOfProjectNumber(w).ToString + " hours."
                    ProgressBar1.PerformStep()
                    Console.WriteLine(allProjectNumber(w).ToString + " has logged " + timeOfProjectNumber(w).ToString + " hours.")
                Next

                ProgressBar1.Value = 0

                For k As Integer = 0 To x
                    Dim queryIDOfTaskGivenProjectCode As String = "{""query"":""query{\r\n  items_by_column_values(board_id: 2718204773, column_id: text, column_value: \""" & allProjectNumber(k) & "\"") {\r\n    id\r\n  }\r\n}"",""variables"":{}}"
                    Dim objResponse = JsonConvert.DeserializeObject(Of Root)(apiRequest(queryIDOfTaskGivenProjectCode))
                    mondayIDOfProjectNumber(k) = objResponse.data.items_by_column_values(0).id
                    lblStatus.Text = "Found " + allProjectNumber(k) + " on monday.com | monday.com Item ID: " + mondayIDOfProjectNumber(k).ToString + "."
                    ProgressBar1.PerformStep()
                    Console.WriteLine(allProjectNumber(k) + " | " + timeOfProjectNumber(k).ToString + " hours | monday.com ID: " + mondayIDOfProjectNumber(k))
                Next

                ProgressBar1.Value = 0
                lblStatus.Text = "Changing YTD Hours of each project on monday.com. Please wait..."
                For v As Integer = 0 To x
                    Dim queryChangeItemValue As String = "{""query"":""mutation {\r\n  change_multiple_column_values (item_id: " & mondayIDOfProjectNumber(v) & ", board_id: 2718204773, column_values:\""{\\\""ytd_hours\\\"":\\\""" & timeOfProjectNumber(v) & "\\\""}\""){\r\n      id\r\n  }\r\n}"",""variables"":{}}"
                    apiRequest(queryChangeItemValue)
                    ProgressBar1.PerformStep()
                Next
                ProgressBar1.Visible = False
                lblStatus.Visible = False
                ProgressBar1.Value = 0
                lblStatus.Text = ""
                Me.Size = New Size(431, 117)
                Button1.Enabled = True
                Button2.Enabled = True
            Catch ex As Exception
                ProgressBar1.Visible = False
                lblStatus.Visible = False
                ProgressBar1.Value = 0
                lblStatus.Text = ""
                Button1.Enabled = True
                Button2.Enabled = True
            End Try
        End If
    End Sub

    Public Sub SubTaskHoursGenerator()
        'THIS CODE IS TO SETUP ALL THE SUBTASKS ARRAY
        Dim queryAllProjectNumbersAndNames As String = "{""query"":""query{\r\n    boards(ids:2718204773){\r\n        items{\r\n            id\r\n            name\r\n            column_values(ids:text){\r\n                text\r\n            }\r\n            subitems{\r\n                id\r\n                name\r\n            }\r\n        }\r\n    }\r\n}"",""variables"":{}}"
        Dim obj = JsonConvert.DeserializeObject(Of Root)(apiRequest(queryAllProjectNumbersAndNames))

        If obj.data.boards Is Nothing Then
            'no response from monday.com
            MessageBox.Show("TiTA could not receive any response from monday.com. Please try again later.", "Oops, Something went wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Dim indexOfProjectList As Integer = obj.data.boards(0).items.Count - 1 'the index count of project list
            Dim currentNumberOfSubtask As Integer = 0
            Dim highestNumberOfSubtask As Integer = 0
            ReDim allProjectNumber(indexOfProjectList)
            ReDim timeOfProjectNumber(indexOfProjectList)
            ReDim mondayIDOfProjectNumber(indexOfProjectList)
            For x As Integer = 0 To indexOfProjectList
                allProjectNumber(x) = obj.data.boards(0).items(x).column_values(0).text
                mondayIDOfProjectNumber(x) = obj.data.boards(0).items(x).id
                If obj.data.boards(0).items(x).subitems Is Nothing Then
                    currentNumberOfSubtask = 0
                Else
                    currentNumberOfSubtask = obj.data.boards(0).items(x).subitems.Count
                End If

                Console.WriteLine("there are " & currentNumberOfSubtask.ToString & " number of subtasks in this task.")
                If currentNumberOfSubtask > highestNumberOfSubtask Then
                    highestNumberOfSubtask = currentNumberOfSubtask
                End If
            Next

            ReDim subtasksOnEveryTasks(indexOfProjectList, highestNumberOfSubtask - 1)
            ReDim subtaskNameOnEveryTask(indexOfProjectList, highestNumberOfSubtask - 1)
            ReDim timeOnEverySubTask(indexOfProjectList, highestNumberOfSubtask - 1)
            ReDim boardIDoFEachSubTask(indexOfProjectList, highestNumberOfSubtask - 1)
            For x As Integer = 0 To indexOfProjectList
                Dim maxNumberOfSubTaskForCurrentQuery
                If obj.data.boards(0).items(x).subitems Is Nothing Then
                    maxNumberOfSubTaskForCurrentQuery = 0
                Else
                    maxNumberOfSubTaskForCurrentQuery = obj.data.boards(0).items(x).subitems.Count
                End If

                Console.WriteLine("There are " & maxNumberOfSubTaskForCurrentQuery.ToString & " number of subtasks for task named " & obj.data.boards(0).items(x).name.ToString & "")

                If maxNumberOfSubTaskForCurrentQuery = 0 Then

                Else
                    For y As Integer = 0 To maxNumberOfSubTaskForCurrentQuery - 1
                        subtasksOnEveryTasks(x, y) = obj.data.boards(0).items(x).subitems(y).id
                        subtaskNameOnEveryTask(x, y) = obj.data.boards(0).items(x).subitems(y).name
                    Next
                End If
            Next
        End If
        'THE CODE ENDS HERE.

        'THIS CODE IS TO FIND ALL THE BOARD ID OF EACH SUBTASK
        'For x As Integer = 0 To allProjectNumber.Count() - 1
        '    Dim querySubTaskBoardID As String = "{""query"":""query{\r\n    boards(ids:2718204773){\r\n        items(ids:" & mondayIDOfProjectNumber(x) & "){\r\n            subitems{\r\n                board{\r\n                    id\r\n                }\r\n            }\r\n        }\r\n    }\r\n}"",""variables"":{}}"
        '    Dim obj2 = JsonConvert.DeserializeObject(Of Root)(apiRequest(querySubTaskBoardID))
        '    Dim maxNumberOfSubTaskForCurrentQuery As Integer = 0

        '    For y As Integer = 0 To subtasksOnEveryTasks.GetLength(1) - 1
        '        If subtaskNameOnEveryTask(x, y) <> Nothing Then
        '            maxNumberOfSubTaskForCurrentQuery += 1
        '        End If
        '    Next

        '    For y As Integer = 0 To maxNumberOfSubTaskForCurrentQuery - 1
        '        boardIDoFEachSubTask(x, y) = obj2.data.boards(0).items(0).subitems(y).board.id
        '        Console.WriteLine("Subtask " & mondayIDOfProjectNumber(x) & " has the Board ID of " & boardIDoFEachSubTask(x, y) & ".(" & y & "/" & (maxNumberOfSubTaskForCurrentQuery - 1).ToString & ")")
        '    Next
        'Next
        'THIS CODE ENDS HERE

        'THIS CODE IS TO SEARCH ALL THE PROJECT NUMBER FROM TIME IN TEST BOARD.
        Button1.Enabled = False
        Button2.Enabled = False
        lblStatus.Visible = True
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        ProgressBar1.Step = 1
        ProgressBar1.Maximum = allProjectNumber.Count
        For x As Integer = 0 To allProjectNumber.Count - 1
            Dim queryProjectCodeOnTimeInTest As String = "{""query"":""query{\r\n    items_by_column_values(board_id:2628729848, column_id:\""dropdown\"", column_value:\""" & allProjectNumber(x) & "\""){\r\n        column_values(ids:[\""text4\"",\""time_tracking0\""]){\r\n            text\r\n        }\r\n    }\r\n    }"",""variables"":{}}"
            Dim obj1 = JsonConvert.DeserializeObject(Of Root)(apiRequest(queryProjectCodeOnTimeInTest))
            Dim numberOfSubTaskForCurrentTask As Integer = 0

            '    'THIS CODE IS TO SUM ALL HOURS SPENT ON A SINGLE PROJECT REGARDLESS OF SUBTASKS.
            For w As Integer = 0 To obj1.data.items_by_column_values.Count - 1
                Dim currHourIndividual As Decimal = CDec(Int(obj1.data.items_by_column_values(w).column_values(1).text.Substring(0, 2)))
                Dim currMinIndividual As Decimal = CDec(Int(obj1.data.items_by_column_values(w).column_values(1).text.Substring(3, 2)) / 60)
                Dim currSecIndividual As Decimal = CDec(Int(obj1.data.items_by_column_values(w).column_values(1).text.Substring(6, 2)) / 3600)

                timeOfProjectNumber(x) += currHourIndividual + currMinIndividual + currSecIndividual
            Next
            Console.WriteLine("" & timeOfProjectNumber(x).ToString & " hours was spent on " & allProjectNumber(x) & ".")
            'THE CODE ENDS HERE.

            'THIS CODE IS TO SUM ALL THE HOURS SPENT ON ALL THE SUBTASKS OF A CERTAIN TASK.
            For i As Integer = 0 To subtasksOnEveryTasks.GetLength(1) - 1
                If subtasksOnEveryTasks(x, i) = Nothing Then
                Else
                    numberOfSubTaskForCurrentTask += 1
                End If
            Next
            For y As Integer = 0 To numberOfSubTaskForCurrentTask - 1
                For z As Integer = 0 To obj1.data.items_by_column_values.Count - 1
                    If obj1.data.items_by_column_values(z).column_values(0).text = subtaskNameOnEveryTask(x, y) Then
                        'it's a match
                        Dim currHour As Decimal = CDec(Int(obj1.data.items_by_column_values(z).column_values(1).text.Substring(0, 2)))
                        Dim currMin As Decimal = CDec(Int(obj1.data.items_by_column_values(z).column_values(1).text.Substring(3, 2)) / 60)
                        Dim currSec As Decimal = CDec(Int(obj1.data.items_by_column_values(z).column_values(1).text.Substring(6, 2)) / 3600)
                        timeOnEverySubTask(x, y) += currHour + currMin + currSec
                    End If
                Next
                Console.WriteLine("" & allProjectNumber(x) & " has spent " & timeOnEverySubTask(x, y).ToString & " hours on " & subtaskNameOnEveryTask(x, y).ToString & ".")
            Next
            lblStatus.Text = "Calculating time spent... (" & x.ToString & "/" & allProjectNumber.Count.ToString & ")"
            ProgressBar1.PerformStep()
            'THE CODE ENDS HERE
        Next
        'THE CODE ENDS HERE.

        'After saving all the time from each tasks and their subtasks, we need to write those data to monday.com

        'THIS CODE IS TO WRITE ALL THE RESULTS OF THE TIME SPENT ON EACH SUBTASKS AND TASKS QUERY TO MONDAY.COM CEBU PROJECTS LIST BOARD.
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        ProgressBar1.Step = 1
        ProgressBar1.Maximum = allProjectNumber.Count
        For x As Integer = 0 To allProjectNumber.Count - 1
            Dim writeIndividualResults As String = "{""query"":""mutation {\r\n  change_simple_column_value(item_id: " & mondayIDOfProjectNumber(x) & ", board_id: 2718204773, column_id: \""ytd_hours\"", value: \""" & Decimal.Round(timeOfProjectNumber(x), 2).ToString & "\"") {\r\n    id\r\n  }\r\n}"",""variables"":{}}"
            apiRequest(writeIndividualResults)
            Console.WriteLine("The task " & mondayIDOfProjectNumber(x).ToString & " YTD hours is updated to " & (Decimal.Round(timeOfProjectNumber(x), 2)).ToString & ".")
            lblStatus.Text = "Writing hours spent on task to Monday.com... (" & x.ToString & "/" & allProjectNumber.Count.ToString & ")"
            ProgressBar1.PerformStep()
            Threading.Thread.Sleep(200)
        Next

        'First, know the number of monday.com ID in subtasksInEveryTasks
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        ProgressBar1.Step = 1
        ProgressBar1.Maximum = allProjectNumber.Count
        For x As Integer = 0 To subtasksOnEveryTasks.GetLength(0) - 1
            For y As Integer = 0 To subtasksOnEveryTasks.GetLength(1) - 1
                If subtasksOnEveryTasks(x, y) <> Nothing Then
                    Dim writeSubTaskResult As String = "{""query"":""mutation {\r\n  change_simple_column_value(item_id: " & subtasksOnEveryTasks(x, y) & ", board_id: 2747054130, column_id: \""text5\"", value: \""" & Decimal.Round(timeOnEverySubTask(x, y), 2).ToString & "\"") {\r\n    id\r\n  }\r\n}"",""variables"":{}}"
                    apiRequest(writeSubTaskResult)
                    Console.WriteLine("The task " & mondayIDOfProjectNumber(x) & " YTD hours for subtask " & subtaskNameOnEveryTask(x, y) & " is updated to " & (Decimal.Round(timeOnEverySubTask(x, y), 2).ToString) & " hours.")
                End If
            Next
            lblStatus.Text = "Writing hours spent on subtasks to Monday.com... (" & x.ToString & "/" & allProjectNumber.Count.ToString & ")"
            ProgressBar1.PerformStep()
        Next


        MessageBox.Show("YTD of " & allProjectNumber.Count & " tasks and their subtasks have been updated.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ProgressBar1.Visible = False
        lblStatus.Visible = False
        Button1.Enabled = True
        Button2.Enabled = True
        'THE CODE ENDS HERE.


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class