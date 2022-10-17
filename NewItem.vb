Public Class NewItem
    Private Sub NewItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Form1.sessionUser + " | Add New Task"
        Me.CenterToParent()
    End Sub


End Class