Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(Replace(MaskedTextBox1.Text, " ", "") & vbCrLf & Replace(MaskedTextBox1.Text, " ", "").Length)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker
    End Sub
End Class
