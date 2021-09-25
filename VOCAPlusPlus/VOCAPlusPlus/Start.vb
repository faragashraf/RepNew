
Imports System.Threading

Public Class Start
    Private Sub Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MacStr = GetMACAddressNew()
        Invoke(Sub()
                   Dim WC As New APblicClss.FuncWorker
                   If MacWrWrkr.IsBusy = False Then
                       MacWrWrkr.RunWorkerAsync(WC)
                   End If
               End Sub)

        Timer2.Start()
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Login.Show()
        Timer2.Stop()
        Me.Close()
    End Sub

    Private Sub MacWrWrkr_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles MacWrWrkr.DoWork
        Dim worker As System.ComponentModel.BackgroundWorker
        worker = CType(sender, System.ComponentModel.BackgroundWorker)
        ' Get the Words object and call the main method.
        Dim WC As APblicClss.FuncWorker = CType(e.Argument, APblicClss.FuncWorker)
        WC.MacTblSub(worker)
    End Sub

End Class