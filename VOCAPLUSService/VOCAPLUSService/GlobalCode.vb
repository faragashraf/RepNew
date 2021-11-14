Imports System.Data.SqlClient

Module GlobalCode
    Public screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Public screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Public Errmsg As String          ' Handel error message
    Public Esc As String = ""
    Public EscCnt As Integer = 0
    Public EscID As Integer = 0
    Public Cnt As Integer = 0
    Public CntDay As Integer = 0
    Public Tran As SqlTransaction = Nothing             'SQL Transaction
    Public EscAtoTable As DataTable = New DataTable
    Public tempTable As DataTable = New DataTable
    Public WdysTable As New DataTable
    Public HeldTbl As DataTable = New DataTable()
    Public Span_ As New TimeSpan
    Public StrFileName As String = "X"
    Public nxt As String
    Public ExpoTbl As New DataTable
    Public FileExported As String
    Public Class APblicClss
        Public Class Defntion
            Public sqlCcon As New SqlConnection("Data Source=MYTHINKBOOK\ASHRAFSQL;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046")
            'Public sqlCcon As New SqlConnection("Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046")
            Public sqlComm As New SqlCommand                    'SQL Command
            Public sqlComnd As New SqlCommand                    'SQL Command
            Public sqlCommUpddate_ As New SqlCommand            'SQL Command
            Public sqlComminsert_1 As New SqlCommand            'SQL Command
            Public sqlComminsert_2 As New SqlCommand            'SQL Command
            Public sqlComminsert_3 As New SqlCommand            'SQL Command
            Public sqlComminsert_4 As New SqlCommand            'SQL Command
            Public SQLTblAdpter As New SqlDataAdapter            'SQL Table Adapter
            Public SQLTblAdptr As New SqlDataAdapter            'SQL Table Adapter
            Public Reader_ As SqlDataReader                     'SQL Reader
            Public AssignTable As DataTable = New DataTable
            Public EscTable As DataTable = New DataTable
        End Class
        Public Class Func
            Public Function ServrTime() As DateTime
                Dim Fn As New APblicClss.Func
                Errmsg = Nothing
                tempTable.Rows.Clear()
                tempTable.Columns.Clear()
                Dim Nw As DateTime
                Try
                    Fn.GetTbl("Select GetDate() as Now_", tempTable)
                    Nw = Format(tempTable.Rows(0).Item(0), "yyyy/MM/dd hh:mm:ss tt")
                Catch ex As Exception

                End Try
                Return Nw
            End Function
            Public Function CalDate(StDt As Date, ByRef EnDt As Date) As Integer    ' Returns the number of CalDate between StDt and EnDt Using the table CDHolDay
                Dim Def As New Defntion
                Dim WdyCount As Integer
                StDt = DateValue(StDt)     ' DateValue returns the date part only if U use stamptime as example.
                EnDt = DateValue(EnDt)
                Def.sqlComm.Connection = Def.sqlCcon  ' Get ID & Date & UserID                        
                Def.sqlComm.CommandText = "SELECT Count(HDate) AS WDaysCount FROM CDHolDay WHERE (HDy = 1) AND (HDate BETWEEN CONVERT(DATETIME, '" & Format(StDt, "dd/MM/yyyy") & "', 103) AND CONVERT(DATETIME, '" & Format(EnDt, "dd/MM/yyyy") & "', 103));"
                Def.sqlComm.CommandType = CommandType.Text
                Try
                    Def.Reader_ = Def.sqlComm.ExecuteReader
                    Def.Reader_.Read()
                    WdyCount = Def.Reader_!WDaysCount
                    Def.Reader_.Close()
                Catch ex As Exception

                End Try
                Return WdyCount
            End Function
            Public Function GetTbl(SSqlStr As String, SqlTbl As DataTable) As String
                Dim Def As New Defntion
                Errmsg = Nothing
                Def.sqlComnd.Connection = Def.sqlCcon
                Def.SQLTblAdpter.SelectCommand = Def.sqlComnd
                Def.sqlComnd.CommandType = CommandType.Text
                Def.sqlComnd.CommandText = SSqlStr
                Try
                    SqlTbl.Rows.Clear()
                    Def.SQLTblAdpter.Fill(SqlTbl)
                    Def.sqlCcon.Close()
                    SqlConnection.ClearPool(Def.sqlCcon)
                Catch ex As Exception
                    VOCAPlusService.TxtErr.Text = Now & " Fn.GetTbl ___" & SqlTbl.TableName & ex.Message & vbCrLf
                    VOCAPlusService.TxtErr.Refresh()
                    'MsgBox(ex.Message)
                End Try
                Return Errmsg
            End Function
            Public Function InsUpd(SSqlStr As String) As String
                Dim Def As New Defntion
                Errmsg = Nothing
                Def.sqlComm.Connection = Def.sqlCcon
                Def.sqlComm.CommandType = CommandType.Text
                Def.sqlComm.CommandText = SSqlStr
                Try
                    If Def.sqlCcon.State = ConnectionState.Closed Then
                        Def.sqlCcon.Open()
                    End If
                    Def.sqlComm.ExecuteNonQuery()
                    Def.sqlCcon.Close()
                    SqlConnection.ClearPool(Def.sqlCcon)
                Catch ex As Exception
                    VOCAPlusService.TxtErr.Text = Now & " InsUpd ___ " & SSqlStr & ex.Message & vbCrLf & VOCAPlusService.TxtErr.Text
                    VOCAPlusService.TxtErr.Refresh()
                    Errmsg = "X"
                End Try
                Return Errmsg
            End Function
            Public Function InsTrans(TranStr1 As String, TranStr2 As String) As String
                Dim Def As New Defntion
                Errmsg = Nothing
                Try
                    If Def.sqlCcon.State = ConnectionState.Closed Then
                        Def.sqlCcon.Open()
                    End If
                    Def.sqlComminsert_1.Connection = Def.sqlCcon
                    Def.sqlComminsert_2.Connection = Def.sqlCcon
                    Def.sqlComminsert_1.CommandType = CommandType.Text
                    Def.sqlComminsert_2.CommandType = CommandType.Text
                    Def.sqlComminsert_1.CommandText = TranStr1
                    Def.sqlComminsert_2.CommandText = TranStr2
                    Tran = Def.sqlCcon.BeginTransaction()
                    Def.sqlComminsert_1.Transaction = Tran
                    Def.sqlComminsert_2.Transaction = Tran
                    Def.sqlComminsert_1.ExecuteNonQuery()
                    Def.sqlComminsert_2.ExecuteNonQuery()
                    Tran.Commit()
                Catch ex As Exception
                    Tran.Rollback()
                    VOCAPlusService.TxtErr.Text = vbCrLf & Now & " InsTrans ___ " & TranStr1 & "_____" & TranStr2 & ex.Message & vbCrLf
                    VOCAPlusService.TxtErr.Refresh()
                    Errmsg = "X"
                End Try
                Def.sqlCcon.Close()
                SqlConnection.ClearPool(Def.sqlCcon)
                Return Errmsg
            End Function
        End Class
    End Class
    Function OsIP() As String              'Returns the Ip address 
#Disable Warning BC40000 ' Type or member is obsolete
        OsIP = System.Net.Dns.GetHostByName("").AddressList(0).ToString()
#Enable Warning BC40000 ' Type or member is obsolete
    End Function
    Public Sub MsgInf(MsgBdy As String)
        MessageBox.Show(MsgBdy, "رسالة معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading Or MessageBoxOptions.RightAlign)
    End Sub

End Module
