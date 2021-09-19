Imports System.Data.SqlClient

Public Class Form2
    Private sqlComm As New SqlCommand                    'SQL Command
    Private Reader As SqlDataReader                     'SQL Reader
    Private strConn As String = "Data Source=MYTHINKBOOK\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046"
    Private CONSQL As New SqlConnection(strConn) ' I Have assigned conn STR here and delete this row from all project
    Private DD As New DataTable
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTblXX("select CDFnProd.FnSQL,CDFnProd.FnMend from CDFnProd", DD)
        DataGridView1.DataSource = DD
    End Sub
    Private Function GetTblXX(SSqlStr As String, SqlTbl As DataTable) As String

        CONSQL = New SqlConnection(strConn)
        Dim sqlCommW As New SqlCommand(SSqlStr, CONSQL)
        Try
            If CONSQL.State = ConnectionState.Closed Or CONSQL.State = ConnectionState.Broken Then
                CONSQL.Open()
            End If
            Reader = sqlCommW.ExecuteReader
            SqlTbl.Load(Reader)
        Catch ex As Exception
            If ex.Message.Contains("The connection is broken and recovery is not possible") Then
                CONSQL.Close()
                SqlConnection.ClearPool(CONSQL)
            End If

        End Try
        CONSQL.Close()
        SqlConnection.ClearPool(CONSQL)
    End Function
    Private Function InsUpdate(SSqlStr As String) As String
        CONSQL = New SqlConnection(strConn)
        sqlComm = New SqlCommand(SSqlStr, CONSQL)
        sqlComm.Connection = CONSQL
        sqlComm.CommandType = CommandType.Text
        Try
            If CONSQL.State = ConnectionState.Closed Then
                CONSQL.Open()
            End If
            sqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CONSQL.Close()
        SqlConnection.ClearPool(CONSQL)

    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For PP = 0 To DD.Rows.Count - 1
            If Mid(DD.Rows(PP).Item("FnMend"), 4, 1) = "Y" Then
                InsUpdate("insert Into	CdFnMend (MendCdFn,MendField) values (" & DD.Rows(PP).Item("FnSQL") & ",'" & "اسم المكتب" & "')")
            End If
            If Mid(DD.Rows(PP).Item("FnMend"), 6, 1) = "Y" Then
                InsUpdate("insert Into	CdFnMend (MendCdFn,MendField) values (" & DD.Rows(PP).Item("FnSQL") & ",'" & "رقم الشحنة" & "')")
            End If
            If Mid(DD.Rows(PP).Item("FnMend"), 7, 1) = "Y" Then
                InsUpdate("insert Into	CdFnMend (MendCdFn,MendField) values (" & DD.Rows(PP).Item("FnSQL") & ",'" & "بلد المرسل إلية" & "')")
            End If
            If Mid(DD.Rows(PP).Item("FnMend"), 8, 1) = "Y" Then
                InsUpdate("insert Into	CdFnMend (MendCdFn,MendField) values (" & DD.Rows(PP).Item("FnSQL") & ",'" & "رقم الكارت" & "')")
            End If
            If Mid(DD.Rows(PP).Item("FnMend"), 9, 1) = "Y" Then
                InsUpdate("insert Into	CdFnMend (MendCdFn,MendField) values (" & DD.Rows(PP).Item("FnSQL") & ",'" & "رقم أمر الدفع" & "')")
            End If
            If Mid(DD.Rows(PP).Item("FnMend"), 11, 1) = "Y" Then
                InsUpdate("insert Into	CdFnMend (MendCdFn,MendField) values (" & DD.Rows(PP).Item("FnSQL") & ",'" & "مبلغ العملية" & "')")
            End If
            If Mid(DD.Rows(PP).Item("FnMend"), 12, 1) = "Y" Then
                InsUpdate("insert Into	CdFnMend (MendCdFn,MendField) values (" & DD.Rows(PP).Item("FnSQL") & ",'" & "تاريخ العملية" & "')")
            End If
        Next
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

    End Sub
End Class