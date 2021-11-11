Imports System.Data.SqlClient

Public Class Form1
    Private strConn As String = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046" ' "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
    Private CONSQL As New SqlConnection(strConn) ' I Have assigned conn STR here and delete this row from all project
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(Replace(MaskedTextBox1.Text, " ", "") & vbCrLf & Replace(MaskedTextBox1.Text, " ", "").Length)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox(IsNumeric(TextBox1.Text))
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        'NOTE: set form's KeyPreview property to True
        Select Case e.KeyCode
            Case Keys.F1
                MsgBox("F1")
                e.SuppressKeyPress = True
            Case Keys.F2
            Case Keys.F3
                'do something
                e.SuppressKeyPress = True
            Case Keys.F4
                'do something else
                e.SuppressKeyPress = True
            Case Keys.F5
                'do something different
                e.SuppressKeyPress = True
            Case Keys.F6
            Case Keys.F7
            Case Keys.F8
            Case Keys.F9
            Case Keys.F10
            Case Keys.F11
            Case Keys.F12
        End Select
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim TimeTble As New DataTable
        Dim sqlComminsert_1 As New SqlCommand            'SQL Command
        Dim Tran As SqlTransaction = Nothing             'SQL Transaction
        Dim TimeReder As SqlDataReader                     'SQL Reader
        Try
            If CONSQL.State = ConnectionState.Closed Then
                CONSQL.Open()
            End If
            sqlComminsert_1.Connection = CONSQL
            sqlComminsert_1.CommandType = CommandType.Text
            sqlComminsert_1.CommandText = "Select GetDate() as Now_"
            Tran = CONSQL.BeginTransaction()
            sqlComminsert_1.Transaction = Tran
            TimeReder = sqlComminsert_1.ExecuteReader
            TimeTble.Load(TimeReder)
            Tran.Commit()
            Label5.Text = "Server Time : " & Format(TimeTble.Rows(0).Item(0), "yyyy/MM/dd hh:mm:ss tt")
        Catch ex As Exception
            Label5.Text = ex.Message
            Tran.Rollback()
        End Try
    End Sub
End Class
