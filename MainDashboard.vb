Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports System.Threading
Public Class MainDashboard
    'use this to create fast class for your JSON Objects:
    'https://json2csharp.com/  to convert JSON to C# aaaaand
    'https://codeconverter.icsharpcode.net/ to convert C# to VB.NET
    Dim apiKey As String = "eyJhbGciOiJIUzI1NiJ9.eyJ0aWQiOjE1MjU2NzQ3OCwidWlkIjoxNTA5MzQwNywiaWFkIjoiMjAyMi0wMy0yNVQwMTo0Njo1My4wMDBaIiwicGVyIjoibWU6d3JpdGUiLCJhY3RpZCI6NjYxMjMxMCwicmduIjoidXNlMSJ9.F1TqwLS-QsuM8Ss3UcgskbNFUIer1dfwfoLyPMq1pbc"
    ' Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    Public currentProjectNumber As String
    Public sessionProjectNumber As String
    Public sessionSubTask As String
    Public clockSharkFirstLogin As String
    Public previousJob As String
    Public mechanicalBoard As String = "2628729848"
    Public LunchThread As System.Threading.Thread
    Public clockOutApiCommand As String
    Public checking As Integer = 1
    Public jobsFilteredCopy() As String
    Public projectNumberArrayCopy() As String
    Public SubTasksAvailable(,) As String
    Public surname As String = My.Settings.sessionUserSurname
    Public mondayID As String = My.Settings.sessionMondayId
    Public restartDashboard As Boolean = False
    Public checkIfItemIsMarkedWitX As String
    Public titaVersion As String

    Public cooldownCounter As Integer

    'Task checker API strand.
    Public alljobschecker() As String
    Public selectedItemID As String
    Public budgetHour As Decimal
    Public YTDHours As Decimal



    'THREADS ARE FOUND HERE
    Dim threadCheckStart As Thread
    Dim thread3 As Thread
    'JSON QUERY CLASSES
    Public Class Data
        Public Property items_by_column_values As List(Of ItemsByColumnValue)
        Public Property boards As List(Of Board)
        Public Property items As List(Of Item)
        Public Property change_multiple_column_values As ChangeMultipleColumnValues
        Public Property create_item As CreateItem
    End Class
    Public Class Subitem
        Public Property name As String
        Public Property id As String
    End Class
    Public Class CreateItem
        Public Property id As String
    End Class
    Public Class ChangeMultipleColumnValues
        Public Property id As String
        Public Property column_values As List(Of ColumnValue)
    End Class
    Public Class ColumnValue
        Public Property title As String
        Public Property id As String
        Public Property text As String
    End Class
    Public Class Board
        Public Property items As List(Of Item)
        Public Property groups As List(Of Group)
    End Class
    Public Class Group
        Public Property items As List(Of Item)
    End Class
    Public Class Item
        Public Property id As String
        Public Property subitems As List(Of Subitem)
        Public Property name As String
        Public Property column_values As List(Of ColumnValue)
    End Class
    Public Class ItemsByColumnValue
        Public Property name As String
        Public Property id As String
        Public Property column_values As List(Of ColumnValue)
        Public Property subitems As List(Of Subitem)
    End Class
    Public Class Root
        Public Property data As Data
        Public Property account_id As Integer
    End Class
    'JSON QUERY CLASSES

    Public Sub lunchCommand()
        btnBreak.Enabled = False
        btnLunch.Enabled = False
        btnSwitch.Enabled = False
        Dim indexSelected As Integer = Array.IndexOf(jobsFilteredCopy, cbJobsTasks.Text.ToString)
        currentProjectNumber = projectNumberArrayCopy(indexSelected)
        My.Settings.sessionProjectNumber = ""
        My.Settings.Save()
        Try
            loopCheck() 'CLOCKING OUT, LOOP CHECK AND MARKING OF START_user<============================================================
            btnBreak.Enabled = False
            btnLunch.Enabled = False
            btnSwitch.Enabled = False
            Dim addNewItem As String
            addNewItem = "{""query"":""mutation {\r\n  create_item(board_id: 2628729848, group_id: \""topics\"", item_name: \""" & surname & "\"",column_values:\""{\\\""text45\\\"":\\\""Y\\\"",\\\""text_1\\\"":\\\""START_" & surname & "\\\"",\\\""text\\\"":\\\""" & DateTime.Now.ToString("HH:mm:ss") & "\\\"",\\\""job\\\"":\\\""Lunch\\\"", \\\""person\\\"":\\\""" & mondayID & "\\\"", \\\""text64\\\"":\\\""" & titaVersion & "\\\""}\"",create_labels_if_missing:true) {\r\n    id\r\n  }\r\n}\r\n"",""variables"":{}}"
            Dim idOfNewItem = JsonConvert.DeserializeObject(Of Root)(apiRequest(addNewItem))
            My.Settings.newID = idOfNewItem.data.create_item.id.ToString
            My.Settings.Save()
            'Dim changeValueOfNewItem As String = ""
            ProgressBar1.PerformStep()
            sessionSubTask = ""
        Catch ex As Exception
            Form1.msgBoxInformative("Please contact admin." + Environment.NewLine + ex.ToString, "Oops! Something went wrong!")
            Application.Restart()
        End Try 'THIS IS THE WORKING CODE FOR TASK
    End Sub
    Public Sub recessCommand()
        btnBreak.Enabled = False
        btnLunch.Enabled = False
        btnSwitch.Enabled = False
        Dim indexSelected As Integer = Array.IndexOf(jobsFilteredCopy, cbJobsTasks.Text.ToString)
        currentProjectNumber = projectNumberArrayCopy(indexSelected)
        My.Settings.sessionProjectNumber = ""
        My.Settings.Save()
        Try
            loopCheck() 'CLOCKING OUT, LOOP CHECK AND MARKING OF START_user<============================================================
            btnBreak.Enabled = False
            btnLunch.Enabled = False
            btnSwitch.Enabled = False
            Dim addNewItem As String
            addNewItem = "{""query"":""mutation {\r\n  create_item(board_id: 2628729848, group_id: \""topics\"", item_name: \""" & surname & "\"",column_values:\""{\\\""text45\\\"":\\\""Y\\\"",\\\""text_1\\\"":\\\""START_" & surname & "\\\"",\\\""text\\\"":\\\""" & DateTime.Now.ToString("HH:mm:ss") & "\\\"",\\\""job\\\"":\\\""Break\\\"", \\\""person\\\"":\\\""" & mondayID & "\\\"", \\\""text64\\\"":\\\""" & titaVersion & "\\\""}\"",create_labels_if_missing:true) {\r\n    id\r\n  }\r\n}\r\n"",""variables"":{}}"
            Dim idOfNewItem = JsonConvert.DeserializeObject(Of Root)(apiRequest(addNewItem))
            My.Settings.newID = idOfNewItem.data.create_item.id.ToString
            My.Settings.Save()
            'Dim changeValueOfNewItem As String = ""
            ProgressBar1.PerformStep()
            sessionSubTask = ""
        Catch ex As Exception
            Form1.msgBoxInformative("Please contact admin." + Environment.NewLine + ex.ToString, "Oops! Something went wrong!")
            Application.Restart()
        End Try 'THIS IS THE WORKING CODE FOR TASK
    End Sub
    Public Function SwitchCommand()
        btnBreak.Enabled = False
        btnLunch.Enabled = False
        btnSwitch.Enabled = False
        Dim indexSelected As Integer = Array.IndexOf(jobsFilteredCopy, cbJobsTasks.Text.ToString)
        currentProjectNumber = projectNumberArrayCopy(indexSelected)
        My.Settings.sessionProjectNumber = currentProjectNumber
        My.Settings.Save()
        Try
            'WHILE LOOP HERE
            If checkBudgetHours() = False Then
                'Over Budget
                Form1.msgBoxInformative("This task is already above the budgeted man hours.", "Over budget!")
                restartDashboard = True
                'RESTART EVENT HERE
                Exit Function
            End If
            loopCheck() 'loop check and marking of START_surname
            btnBreak.Enabled = False
            btnLunch.Enabled = False
            btnSwitch.Enabled = False
            Dim addNewItem As String
            addNewItem = "{""query"":""mutation {\r\n  create_item(board_id: 2628729848, group_id: \""topics\"", item_name: \""" & surname & "\"",column_values:\""{\\\""text64\\\"":\\\""" & titaVersion & "\\\"",\\\""text45\\\"":\\\""Y\\\"",\\\""text_1\\\"":\\\""START_" & surname & "\\\"",\\\""text\\\"":\\\""" & DateTime.Now.ToString("HH:mm:ss") & "\\\"",\\\""job\\\"":\\\""" & cbJobsTasks.SelectedItem.ToString & "\\\"", \\\""person\\\"":\\\""" & mondayID & "\\\"", \\\""text4\\\"":\\\""" & cbSubTasks.Text & "\\\"", \\\""dropdown\\\"":\\\""" & currentProjectNumber & "\\\""}\"",create_labels_if_missing:true) {\r\n    id\r\n  }\r\n}\r\n"",""variables"":{}}"
            Dim idOfNewItem = JsonConvert.DeserializeObject(Of Root)(apiRequest(addNewItem))
            My.Settings.newID = idOfNewItem.data.create_item.id.ToString
            My.Settings.Save()
            'Dim changeValueOfNewItem As String = ""
            ProgressBar1.PerformStep()
            If cbSubTasks.SelectedItem = Nothing Then
                sessionSubTask = "No Subtask available for this task"
            Else
                sessionSubTask = cbSubTasks.SelectedItem.ToString
            End If
        Catch ex As Exception
            Form1.msgBoxInformative("Please contact admin." + Environment.NewLine + ex.ToString, "Oops! Something went wrong!")
            Application.Restart()
        End Try 'THIS IS THE WORKING CODE FOR TASK
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
    Public Sub fetchRnDjobs()
        Dim fetchRnDJobs As String = "{""query"":""query{\r\n  boards(ids:2476955452){\r\n    items(newest_first:true){\r\n      name\r\n    }\r\n  }\r\n}"",""variables"":{}}"
        Dim jsonResponse As String = apiRequest(fetchRnDJobs)
        Dim obj = JsonConvert.DeserializeObject(Of Root)(jsonResponse)
        Dim x As Integer = obj.data.boards(0).items.Count() - 1
        Dim JobsElexRnd(x) As String
        For i As Integer = 0 To obj.data.boards(0).items.Count() - 1
            JobsElexRnd(i) = obj.data.boards(0).items(i).name.ToString
        Next
        cbJobsTasks.Items.AddRange(JobsElexRnd)
        cbJobsTasks.SelectedIndex = 1
    End Sub
    Public Sub fetchRnDjobsMech()
        Dim fetchRnDJobs As String = "{""query"":""query{\r\n  boards(ids:2525698717){\r\n    items(newest_first:true){\r\n      name\r\n    }\r\n  }\r\n}"",""variables"":{}}"
        Dim jsonResponse As String = apiRequest(fetchRnDJobs)
        Dim obj = JsonConvert.DeserializeObject(Of Root)(jsonResponse)
        Dim x As Integer = obj.data.boards(0).items.Count() - 1
        Dim JobsElexRnd(x) As String
        For i As Integer = 0 To obj.data.boards(0).items.Count() - 1
            JobsElexRnd(i) = obj.data.boards(0).items(i).name.ToString
        Next
        cbJobsTasks.Items.AddRange(JobsElexRnd)
        cbJobsTasks.SelectedIndex = 1
    End Sub
    Public Sub checkSTART()
        btnBreak.Enabled = False
        btnLunch.Enabled = False
        btnSwitch.Enabled = False
        cbJobsTasks.Enabled = False
        cbSubTasks.Enabled = False
        cbType.Enabled = False
        'This sub checks the Time in test board for instances of "START_surname".
        Dim queryItemsByColumnValue As String = "{""query"":""query {\r\n    items_by_column_values (board_id: 2628729848, column_id: \""text_1\"", column_value: \""START_" & surname & "\"") {\r\n        id\r\n        column_values(ids:job){\r\n            text\r\n        }\r\n    }\r\n}"",""variables"":{}}"
        Dim obj = JsonConvert.DeserializeObject(Of Root)(apiRequest(queryItemsByColumnValue))
        Dim errorCounter As Integer = 0
        Dim maxRetries As Integer = 30
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = maxRetries
        ProgressBar1.Step = 1
        lblStatus.Text = "TiTA is looking for your previous log. Please wait..."
        While obj.data.items_by_column_values.Count = 0
            lblStatus.Text = "TiTA couldn't find your last logged item... Retrying " + errorCounter.ToString + "/" & maxRetries.ToString & " more times.."
            'This loop will check the Time in test board for the START_surname item before returning an error and restarting the the maindashboard form.
            errorCounter += 1
            ProgressBar1.PerformStep()
            If errorCounter = maxRetries + 1 Then
                Dim result As DialogResult = MessageBox.Show("TiTA can't find your previous log." + Environment.NewLine +
                                            "Please make sure that you have clocked in to clockshark before using TiTA." + Environment.NewLine +
                                            "Press CANCEL to return to login screen.", "Oops, something went wrong!",
                                            MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
                'This code will restart TiTA
                If result = DialogResult.Retry Then
                    restartDashboard = True
                    Exit While
                Else
                    Me.Close()
                    Application.Restart()
                End If 'error detect code and decision making found here.
            End If

            Threading.Thread.Sleep(2000)
            surname = My.Settings.sessionUserSurname
            obj = JsonConvert.DeserializeObject(Of Root)(apiRequest(queryItemsByColumnValue))
        End While

        If restartDashboard = False Then
            ProgressBar1.Value += ProgressBar1.Maximum - ProgressBar1.Value
            lblStatus.Text = "Check START_" + surname.ToString + " was found."

            If obj.data.items_by_column_values.Count > 0 Then
                'START_user is found
                clockSharkFirstLogin = obj.data.items_by_column_values(0).id.ToString 'id of the most recent item of the user @ TimeIn Test
                If obj.data.items_by_column_values(0).column_values.Count > 1 Then
                    'more than on result found.
                    Form1.msgBoxInformative("You already have a task active. " + Environment.NewLine + "Please contact admin.", "More than on task found!")
                    Application.Restart()
                ElseIf obj.data.items_by_column_values(0).column_values.Count = 0 Or obj.data.items_by_column_values(0).column_values.Count < 0 Then
                    'no results found.
                    Form1.msgBoxInformative("Please make sure that you are clocked in into clock shark", "No active task found!")
                Else
                    'an active task is found.
                    previousJob = obj.data.items_by_column_values(0).column_values(0).text.ToString 'text value of the "job" column of the recent item.
                    If previousJob = "" Then
                        Application.Restart()
                    End If
                End If
            End If
            btnBreak.Enabled = True
            btnLunch.Enabled = True
            btnSwitch.Enabled = True
            cbJobsTasks.Enabled = True
            cbSubTasks.Enabled = True
            cbType.Enabled = True
        End If
    End Sub
    Public Sub loopCheck()
        btnBreak.Enabled = False
        btnLunch.Enabled = False
        btnSwitch.Enabled = False
        cbJobsTasks.Enabled = False
        cbSubTasks.Enabled = False
        cbType.Enabled = False
        clockOutApiCommand = "{""query"": ""mutation {\r\n  change_multiple_column_values (item_id: " & clockSharkFirstLogin & ", board_id: 2628729848, column_values:\""{\\\""text_1\\\"":\\\""X\\\"",\\\""text45\\\"":\\\""X\\\"",\\\""dup__of_time_in\\\"":\\\""" & DateTime.Now.ToString("HH:mm:ss") & "\\\""}\""){\r\n      id\r\n      column_values(ids:text_1){\r\n          text\r\n      }\r\n  }\r\n}"",""variables"":{}}"
        checkIfItemIsMarkedWitX = "{""query"":""query{\r\n    boards(ids:2628729848){\r\n        items(ids:" & clockSharkFirstLogin & "){\r\n            column_values(ids:text_1){\r\n                text\r\n            }\r\n        }\r\n    }\r\n}"",""variables"":{}}"
        checking = 1
        While checking = 1
            'This code marks the previous login.
            lblStatus.Text = "Marking your previous logged task.."
            Console.WriteLine("Marking X the previous task..")
            lblStatus.Text = "Marking X the previous task.."
            apiRequest(clockOutApiCommand)
            lblStatus.Text = "Sleeping for 5 seconds to avoid overloading monday servers..."
            Thread.Sleep(5000)
            lblStatus.Text = "Checking if START_" & surname & " still persists."
            Dim obj2 = JsonConvert.DeserializeObject(Of Root)(apiRequest(checkIfItemIsMarkedWitX))
            lblStatus.Text = "Checking if START_" & surname & " still persists."





            If obj2.data.boards Is Nothing Then
                'No internet connection.
                MessageBox.Show("Could not establish connection with monday.com. Please check your internet connection", "Oops! Something went wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                restartDashboard = True
                Exit Sub
            ElseIf obj2.data.boards(0).items.Count = 0 Then
                'No record on monday.com
                MessageBox.Show("TiTA couldn't find your previously logged task. Please make sure that you are clocked in to monday.com before switching tasks." + Environment.NewLine, "Oops, something went wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                restartDashboard = True
                Exit Sub
            ElseIf obj2.data.boards(0).items(0).column_values(0).text = "START_" & surname & "" Then
                Console.WriteLine("START_" & surname & " is still present.")
                lblStatus.Text = ("START_" & surname & " is still present.")
                checking = 1
            ElseIf obj2.data.boards(0).items(0).column_values(0).text = "X" Then
                Console.WriteLine("CheckStart successful. Moving on to loop check.")
                lblStatus.Text = "CheckStart successful. Moving on to loop check."
                checking = 0
            End If

        End While
        Dim queryItemsByColumnValue1 As String = "{""query"":""query {\r\n    items_by_column_values (board_id: 2628729848, column_id: \""text_1\"", column_value: \""START_" & Form1.sessionUserSurname & "\""){\r\n        id\r\n        column_values(ids:job){\r\n            text\r\n        }\r\n    }\r\n}"",""variables"":{}}"
        Dim obj1 = JsonConvert.DeserializeObject(Of Root)(apiRequest(queryItemsByColumnValue1))
        Dim errorCounter2 As Integer = 0
        While obj1.data.items_by_column_values.Count <> 0
            errorCounter2 += 1
            lblStatus.Text = "No response from monday.com. | Retrying " + errorCounter2 + "/30..."
            If errorCounter2 = 30 Then
                MessageBox.Show("monday.com is unreachable. The program will automatically restart this form.", "Oops, something went wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'RESTART EVENT HERE
                restartDashboard = True
                Exit Sub
            End If
            Thread.Sleep(2000)
            obj1 = JsonConvert.DeserializeObject(Of Root)(apiRequest(queryItemsByColumnValue1))
        End While
        lblStatus.Text = "Loop check completed."
        btnBreak.Enabled = True
        btnLunch.Enabled = True
        btnSwitch.Enabled = True
        cbJobsTasks.Enabled = True
        cbSubTasks.Enabled = True
        cbType.Enabled = True
    End Sub
    Public Sub readyTasks()
        '"Electronics R&D", "Mechanical R&D", "Enclosure", "System Designs", "Small Batch Manufacturing"
        Try
            If cbType.SelectedItem = "Show All" Then
                showAllJobs()
            ElseIf cbType.SelectedItem = "R&D" Then
                showJobs_filtered_byGroup("topics")
            ElseIf cbType.SelectedItem = "Jobs" Then
                showJobs_filtered_byGroup("group_title")
            ElseIf cbType.SelectedItem = "Admin" Then
                showJobs_filtered_byGroup("new_group1823")
            ElseIf cbType.SelectedItem = "Electronics R&D" Then
                filterByJobClass("text6")
            ElseIf cbType.SelectedItem = "Mechanical R&D" Then
                filterByJobClass("text79")
            ElseIf cbType.SelectedItem = "Enclosure" Then
                filterByJobClass("text64")
            ElseIf cbType.SelectedItem = "System Designs" Then
                filterByJobClass("text0")
            ElseIf cbType.SelectedItem = "Small Batch Manufacturing" Then
                filterByJobClass("text_1")
            End If
        Catch ex As Exception
            Form1.msgBoxInformative("Error Code 1." + Environment.NewLine + "Please contact admin.", "Oops, something went wrong!")
            Application.Restart()
        End Try
    End Sub
    Public Sub showAllJobs()
        Dim checkingTest As Integer = 1
        Dim fetchJobs As String = "{""query"":""query{\r\n    boards(ids:2718204773){\r\n        items{\r\n            id\r\n            name\r\n            subitems{\r\n                id\r\n                name\r\n            }\r\n            column_values(ids:text){\r\n                text\r\n            }\r\n        }\r\n    }\r\n}"",""variables"":{}}"
        Dim jsonResponse As String = apiRequest(fetchJobs)
        Dim obj = JsonConvert.DeserializeObject(Of Root)(jsonResponse)
        While checkingTest = 1
            If obj.data Is Nothing Then
                lblStatus.Text = "TiTA could not receive a response from monday.com.. Retrying.."
                Threading.Thread.Sleep(5000)
                obj = JsonConvert.DeserializeObject(Of Root)(apiRequest(fetchJobs))
            Else
                checkingTest = 0
                Dim x As Integer = obj.data.boards(0).items.Count - 1
                Console.WriteLine((x + 1).ToString + " tasks found.")
                Try
                    If x <> -1 Then
                        Dim jobsFiltered(x) As String
                        Dim projectNumberArray(x) As String
                        Dim currentNumberofSubtasks As Integer = 0
                        Dim largestNumberofSubtask As Integer = 0
                        For i As Integer = 0 To x
                            jobsFiltered(i) = obj.data.boards(0).items(i).name
                            projectNumberArray(i) = obj.data.boards(0).items(i).column_values(0).text
                            If obj.data.boards(0).items(i).subitems Is Nothing Then
                                currentNumberofSubtasks = 0
                            Else
                                currentNumberofSubtasks = obj.data.boards(0).items(i).subitems.Count
                                Console.WriteLine("The current number of subtask in this task is " + currentNumberofSubtasks.ToString)
                            End If
                            If currentNumberofSubtasks > largestNumberofSubtask Then
                                largestNumberofSubtask = currentNumberofSubtasks
                            Else
                            End If
                        Next

                        ReDim SubTasksAvailable(x, largestNumberofSubtask - 1)

                        For i As Integer = 0 To x
                            If obj.data.boards(0).items(i).subitems Is Nothing Then
                            Else
                                currentNumberofSubtasks = obj.data.boards(0).items(i).subitems.Count
                                For w As Integer = 0 To currentNumberofSubtasks - 1
                                    SubTasksAvailable(i, w) = obj.data.boards(0).items(i).subitems(w).name
                                Next
                            End If
                        Next
                        cbJobsTasks.Items.Clear()
                        jobsFilteredCopy = jobsFiltered
                        projectNumberArrayCopy = projectNumberArray
                        cbJobsTasks.Items.AddRange(jobsFiltered)
                        cbJobsTasks.SelectedIndex = 1
                    End If
                Catch ex As Exception
                End Try ' Show Jobs Code here.
            End If
        End While


    End Sub
    Public Function showJobs_filtered_byGroup(ByVal group_id As String)
        Dim fetchFilteredJob As String = "{""query"":""query{\r\n  boards(ids:2718204773){\r\n   groups(ids:" & group_id & "){\r\n      items{\r\n        name\r\n        column_values(ids:text){\r\n          text\r\n        }\r\n        subitems{\r\n            name\r\n            id\r\n        }\r\n      }\r\n      }\r\n    }\r\n}"",""variables"":{}}"
        Dim jsonResponse As String = apiRequest(fetchFilteredJob)
        Dim obj = JsonConvert.DeserializeObject(Of Root)(jsonResponse)
        'Find the amount of Tasks available.
        Dim x As Integer = obj.data.boards(0).groups(0).items.Count - 1 'number of results
        Try
            If x = -1 Then
            Else
                Dim jobsFiltered(x) As String
                Dim projectNumberArray(x) As String
                Dim currentNumberofSubtasks As Integer = 0
                Dim largestNumberofSubtask As Integer = 0
                For i As Integer = 0 To x
                    If obj.data.boards(0).groups(0).items(i).subitems Is Nothing Then
                        currentNumberofSubtasks = 0
                    Else
                        currentNumberofSubtasks = obj.data.boards(0).groups(0).items(i).subitems.Count
                    End If
                    Console.WriteLine("The current number of subtask in this task is " + currentNumberofSubtasks.ToString)
                    jobsFiltered(i) = obj.data.boards(0).groups(0).items(i).name
                    projectNumberArray(i) = obj.data.boards(0).groups(0).items(i).column_values(0).text
                    Console.WriteLine(jobsFiltered(i) + " -- " + projectNumberArray(i))
                    If currentNumberofSubtasks > largestNumberofSubtask Then
                        largestNumberofSubtask = currentNumberofSubtasks
                    Else
                    End If
                Next
                Console.WriteLine("The largest number of subtask is " + largestNumberofSubtask.ToString)
                ReDim SubTasksAvailable(x, largestNumberofSubtask - 1)

                For i As Integer = 0 To x
                    If obj.data.boards(0).groups(0).items(i).subitems Is Nothing Then

                    Else
                        currentNumberofSubtasks = obj.data.boards(0).groups(0).items(i).subitems.Count
                        For w As Integer = 0 To currentNumberofSubtasks - 1
                            SubTasksAvailable(i, w) = obj.data.boards(0).groups(0).items(i).subitems(w).name
                            Console.WriteLine("Added " + SubTasksAvailable(i, w) + " as a subtask.")
                        Next
                    End If
                Next
                cbJobsTasks.Items.Clear()
                jobsFilteredCopy = jobsFiltered
                projectNumberArrayCopy = projectNumberArray
                cbJobsTasks.Items.AddRange(jobsFiltered)
                cbJobsTasks.SelectedIndex = 1

            End If

        Catch ex As Exception
            Form1.msgBoxInformative("Something went wrong. Please contact admin." + Environment.NewLine + ex.ToString, "Oops! Something went wrong!")
        End Try
    End Function
    Public Function filterByJobClass(ByVal column_id As String)
        Dim command As String = "{""query"":""query{\r\n  items_by_column_values(board_id:2718204773,column_id:\""" & column_id & "\"",column_value:\""x\""){\r\n    id\r\n    name\r\n    column_values(ids:text){\r\n      text\r\n    }\r\n    subitems{\r\n        id\r\n        name\r\n    }\r\n  }\r\n}"",""variables"":{}}"
        Dim response As String = apiRequest(command)
        Dim obj = JsonConvert.DeserializeObject(Of Root)(response)
        Dim x As Integer = obj.data.items_by_column_values.Count 'number of items with selected tag.
        'this is also the number of available task ^^^^
        If x = 0 Then
            'no result found. meaning... something's wrong.
        ElseIf x > 0 Then
            'there are results found.
            Dim jobsfiltered(x - 1) As String
            Dim projectNumberArray(x - 1) As String
            Dim currentNumberofSubtask As Integer = 0
            Dim highestNumberofSubtask As Integer = 0

            For i As Integer = 0 To x - 1
                jobsfiltered(i) = obj.data.items_by_column_values(i).name
                projectNumberArray(i) = obj.data.items_by_column_values(i).column_values(0).text
            Next

            For i As Integer = 0 To x - 1
                If obj.data.items_by_column_values(i).subitems Is Nothing Then
                    'no subitems
                    currentNumberofSubtask = 0
                Else
                    currentNumberofSubtask = obj.data.items_by_column_values(i).subitems.Count
                    If currentNumberofSubtask > highestNumberofSubtask Then
                        'current iteration has a higher subtask count.
                        highestNumberofSubtask = currentNumberofSubtask
                    End If
                End If
            Next

            ReDim SubTasksAvailable(x - 1, highestNumberofSubtask - 1)

            For i As Integer = 0 To x - 1
                If obj.data.items_by_column_values(i).subitems Is Nothing Then

                Else
                    currentNumberofSubtask = obj.data.items_by_column_values(i).subitems.Count
                    For w As Integer = 0 To currentNumberofSubtask - 1
                        SubTasksAvailable(i, w) = obj.data.items_by_column_values(i).subitems(w).name
                        Console.WriteLine("Added " + SubTasksAvailable(i, w) + " as a subtask.")
                    Next
                End If
            Next
            cbJobsTasks.Items.Clear()
            jobsFilteredCopy = jobsfiltered
            projectNumberArrayCopy = projectNumberArray
            cbJobsTasks.Items.AddRange(jobsfiltered)
            cbJobsTasks.SelectedIndex = 1
        End If
    End Function
    'R&D = topics
    'Jobs = group_title
    'Admin = new_group1823
    Public Function checkBudgetHours() As Boolean
        Dim findAllTask As String = "{""query"":""query{\r\n    boards(ids:2718204773){\r\n        items{\r\n            id\r\n            name\r\n        }\r\n    }\r\n}"",""variables"":{}}"
        Dim obj2 = JsonConvert.DeserializeObject(Of Root)(apiRequest(findAllTask))
        lblStatus.Text = "Checking budget hours.."
        If obj2.data.boards Is Nothing Then
            'No Internet connection.
            Form1.msgBoxInformative("Please check internet connection.", "Something is wrong with your network.")
            Application.Restart()
        Else
            'There is an internet connection.
            Dim count As Integer = obj2.data.boards(0).items.Count
            Dim indexCount As Integer = count - 1
            Console.WriteLine("There are " + count.ToString + " tasks found in Cebu Project List.")
            ProgressBar1.Value = 0
            ProgressBar1.Maximum = count
            ProgressBar1.Step = 1
            For x As Integer = 0 To indexCount
                ProgressBar1.PerformStep()
                Console.WriteLine(cbJobsTasks.SelectedItem.ToString)
                If obj2.data.boards(0).items(x).name = cbJobsTasks.SelectedItem Then
                    selectedItemID = obj2.data.boards(0).items(x).id
                    ProgressBar1.Value += ProgressBar1.Maximum - ProgressBar1.Value
                    Exit For
                End If
            Next

            Dim checkSelectedTaskForBudgetAndYTDHoursValue As String = "{""query"":""query{\r\n    boards(ids:2718204773){\r\n        items(ids:" & selectedItemID & "){\r\n            column_values(ids:[dup__of_budget_expense, ytd_hours]){\r\n                title\r\n                text\r\n            }\r\n        }\r\n    }\r\n}"",""variables"":{}}"
            Dim obj3 = JsonConvert.DeserializeObject(Of Root)(apiRequest(checkSelectedTaskForBudgetAndYTDHoursValue))

            ProgressBar1.Value = 0
            ProgressBar1.Maximum = 2
            ProgressBar1.Step = 1

            If obj3.data.boards Is Nothing Then
                'no internet connection
                Dim results = MessageBox.Show("Please check internet connection!", "Oops, something went wrong!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
                If results = DialogResult.Retry Then

                Else
                    Application.Restart()
                End If
            Else
                Console.WriteLine("There are " + obj3.data.boards(0).items(0).column_values.Count.ToString + " columns found..")
                'budgetHour = Convert.ToDecimal(obj3.data.boards(0).items(0).column_values(0).text)
                ProgressBar1.PerformStep()
                'DECLARE ALL VALUES FIRST EVEN IF THE COLUMNS ON MONDAY ARE BLANK.
                'column_values(0) = budget
                'column_values(1) = YearToDate Man Hours
                If obj3.data.boards(0).items(0).column_values(0).text = "" Then
                    'THERE IS NO DATA ON BUDGET VALUE ON MONDAY.COM
                    budgetHour = 0
                Else
                    budgetHour = Convert.ToDecimal(obj3.data.boards(0).items(0).column_values(0).text)
                End If

                If obj3.data.boards(0).items(0).column_values(1).text = "" Then
                    'THERE IS NO DATA ON YEAR TO DATE MAN HOURS VALUE ON MONDAY.COM
                    YTDHours = 0
                Else
                    YTDHours = Convert.ToDecimal(obj3.data.boards(0).items(0).column_values(1).text)
                End If

                If budgetHour = 0 Then
                    'No budget on value on budget column, this means that it hasn't been set up yet
                    'so it's still okay to put hours in this without restriction.
                    Return True
                Else
                    'this branch now has a budget, this means it should restrict if the ytd man hours has
                    'gone beyond the set budget.

                    If budgetHour >= YTDHours Then
                        'still in budget
                        Return True
                    Else
                        'not in budget
                        Return False
                    End If
                End If
                'If budgetHour >= YTDHours Then
                '    'still in budget
                '    Return True
                'Else
                '    'not in budget
                '    Return False
                'End If


                'If obj3.data.boards(0).items(0).column_values(0).text = "" Then
                '    'If obj3.data.boards(0).items(0).column_values(1).text = "" Or obj3.data.boards(0).items(0).column_values(1).text = "0" Then
                '    YTDHours = 0
                '    ProgressBar1.PerformStep()
                'Else
                '    YTDHours = Convert.ToDecimal(obj3.data.boards(0).items(0).column_values(1).text)
                '    ProgressBar1.PerformStep()
                'End If
                ''YTDHours = Convert.ToDecimal(obj3.data.boards(0).items(0).column_values(1).text
                'If budgetHour >= YTDHours Then
                '    'still in budget
                '    Return True
                'Else
                '    'not in budget
                '    Return False
                'End If
            End If
        End If
    End Function
    Private Sub MainDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initialize Filter ComboBoxes
        Dim JobTypes() As String = {"Show All", "R&D", "Jobs", "Admin", "Electronics R&D", "Mechanical R&D", "Enclosure", "System Designs", "Small Batch Manufacturing"}
        cbType.Items.AddRange(JobTypes)
        If My.Settings.LastFilter = "" Then
            cbType.SelectedIndex = 0
        Else
            cbType.SelectedItem = My.Settings.LastFilter
        End If
        titaVersion = My.Settings.titaVersion
        ProgressBar1.Visible = False
        Me.TopMost = True
        Me.Text = Form1.sessionUser + " | Lasermet | monday.com ID: " & Form1.sessionMondayId & " | Switch Task Page | monday.com Project Tracking App"
        positionLoginScreen()
        cbJobsTasks.DropDownStyle = ComboBoxStyle.DropDown
        cbJobsTasks.AutoCompleteSource = AutoCompleteSource.ListItems
        CheckForIllegalCrossThreadCalls = False
        'Check Previous Job
        Try
            threadCheckStart = New Thread(AddressOf checkSTART)
            threadCheckStart.SetApartmentState(ApartmentState.STA)
            threadCheckStart.IsBackground = False
            threadCheckStart.Start()
            threadCheckStart.Join()
            If restartDashboard = True Then
                Dim f2 As New MainDashboard
                Form1.restartedMainDashBoard = f2
                Me.Close()
                f2.Show()
                Exit Sub
            End If
            'checkSTART(Form1.sessionUserSurname)
        Catch ex As Exception
            Form1.msgBoxInformative("/""CHECK PREVIOUS JOB/"" has encountered an error. Please contact admin." + Environment.NewLine + ex.ToString, "Oops, something went wrong.")
            Dim f2 As New MainDashboard
            Form1.restartedMainDashBoard = f2
            Me.Close()
            f2.Show()
        End Try
        If restartDashboard = True Then
            Dim f2 As New MainDashboard
            Form1.restartedMainDashBoard = f2
            Me.Close()
            f2.Show()
        Else

        End If
        If Array.IndexOf(jobsFilteredCopy, previousJob) = -1 Then
            'Task is not found in database
            cbJobsTasks.SelectedIndex = 0
        Else
            'Job is in Database
            cbJobsTasks.SelectedItem = previousJob
        End If
    End Sub
    Public Sub btnSwitch_Click(sender As Object, e As EventArgs) Handles btnSwitch.Click
        My.Settings.LastFilter = cbType.Text
        ProgressBar1.Visible = True
        thread3 = New System.Threading.Thread(AddressOf SwitchCommand)
        thread3.SetApartmentState(ApartmentState.STA)

        If cbJobsTasks.Text = "" Then
            'this stops the user from passing a blank task.
            Form1.msgBoxInformative("Please select a task before switching.", "Oops, something went wrong!")
        Else
            If cbJobsTasks.Items.Contains(cbJobsTasks.Text) = True Then
                'WORKING SWITCH TASK CODE START
                Dim dialog As DialogResult = MessageBox.Show("Are you sure you want to switch to " + cbJobsTasks.Text + ".", cbJobsTasks.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dialog = DialogResult.Yes Then
                    thread3.Start() 'THIS IS THE SWITCH COMMAND THREAD
                    thread3.Join()
                    If restartDashboard = True Then
                        Dim f2 As New MainDashboard
                        Form1.restartedMainDashBoard = f2
                        Me.Close()
                        f2.Show()
                        Exit Sub
                    End If
                    MainDashTinood.Show()
                    Me.Close()
                End If
                'WORKING SWITCH TASK CODE END
            Else
                Form1.msgBoxInformative("The task that you entered is not in Lasermet's database." + Environment.NewLine + "Please contact admin.", "Oops, something went wrong!")
                cbJobsTasks.SelectedIndex = 0
            End If
        End If
    End Sub
    Private Sub btnLunch_Click(sender As Object, e As EventArgs) Handles btnLunch.Click
        My.Settings.LastFilter = cbType.Text
        ProgressBar1.Visible = True
        thread3 = New System.Threading.Thread(AddressOf lunchCommand)
        thread3.SetApartmentState(ApartmentState.STA)

        If cbJobsTasks.Text = "" Then
            'this stops the user from passing a blank task.
            Form1.msgBoxInformative("Please select a task before switching.", "Oops, something went wrong!")
        Else
            If cbJobsTasks.Items.Contains(cbJobsTasks.Text) = True Then
                'WORKING SWITCH TASK CODE START
                Dim dialog As DialogResult = MessageBox.Show("Are you sure you want to switch to " + cbJobsTasks.Text + ".", cbJobsTasks.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dialog = DialogResult.Yes Then
                    thread3.Start()
                    thread3.Join()
                    MainDashTinood.Show()
                    Me.Close()
                End If
                'WORKING SWITCH TASK CODE END
            Else
                Form1.msgBoxInformative("The task that you entered is not in Lasermet's database." + Environment.NewLine + "Please contact admin.", "Oops, something went wrong!")
                cbJobsTasks.SelectedIndex = 0
            End If
        End If
    End Sub
    Private Sub btnBreak_Click(sender As Object, e As EventArgs) Handles btnBreak.Click
        My.Settings.LastFilter = cbType.Text
        ProgressBar1.Visible = True
        thread3 = New System.Threading.Thread(AddressOf recessCommand)
        thread3.SetApartmentState(ApartmentState.STA)

        If cbJobsTasks.Text = "" Then
            'this stops the user from passing a blank task.
            Form1.msgBoxInformative("Please select a task before switching.", "Oops, something went wrong!")
        Else
            If cbJobsTasks.Items.Contains(cbJobsTasks.Text) = True Then
                'WORKING SWITCH TASK CODE START
                Dim dialog As DialogResult = MessageBox.Show("Are you sure you want to switch to " + cbJobsTasks.Text + ".", cbJobsTasks.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dialog = DialogResult.Yes Then
                    thread3.Start()
                    thread3.Join()
                    MainDashTinood.Show()
                    Me.Close()
                End If
                'WORKING SWITCH TASK CODE END
            Else
                Form1.msgBoxInformative("The task that you entered is not in Lasermet's database." + Environment.NewLine + "Please contact admin.", "Oops, something went wrong!")
                cbJobsTasks.SelectedIndex = 0
            End If
        End If
    End Sub
    Private Sub cbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbType.SelectedIndexChanged
        readyTasks()
    End Sub
    Private Sub cbJobsTasks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbJobsTasks.SelectedIndexChanged
        Dim index As Integer = cbJobsTasks.SelectedIndex
        Dim numberofSubtasks As Integer = SubTasksAvailable.GetLength(1) - 1
        cbSubTasks.Items.Clear()

        For i As Integer = 0 To numberofSubtasks
            If SubTasksAvailable(index, i) <> Nothing Then
                cbSubTasks.Items.Add(SubTasksAvailable(index, i))
            Else

            End If
        Next

        If cbSubTasks.Items.Count = 0 Then
            cbSubTasks.Enabled = False
        Else
            cbSubTasks.Enabled = True
            cbSubTasks.SelectedIndex = 0
        End If
    End Sub
End Class