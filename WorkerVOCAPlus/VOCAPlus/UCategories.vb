Public Class UCategories
    Private Sub UCategories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Fn As New APblicClss.Func
        Me.Size = New Point(WelcomeScreen.Width, WelcomeScreen.Height - 110)
        UserTree.Size = New Point(Me.Width - FlowLayoutPanel2.Width - 50, Me.Height)
        'FlowLayoutPanel2
        Dim TempNode() As TreeNode
        UserTable.Rows.Clear()
        UserTable.Columns.Clear()
        UserTree.ImageList = ImgLst
        '                   0  ,    1  ,     2    ,   3          as mix name                 ***   
        If Fn.GetTblXX("Select UsrId, UCatId, UCatIdSub, CASE WHEN dbo.Int_user.UsrRealNm IS NOT NULL THEN dbo.IntUserCat.UCatNm + N'-' + dbo.Int_user.UsrRealNm ELSE dbo.IntUserCat.UCatNm + N'-' END AS UsrMix From Int_user RIGHT OUTER Join IntUserCat On UsrCat = UCatId Where (UsrSusp = 0) AND (dbo.IntUserCat.UCatLvl <> 0) Order By UCatIdSub, UsrId", UserTable, "1016&H") = Nothing Then
            Fn.GetTblXX("SELECT IntUserCat.UCatId, IntUserCat.UCatNm + N' - ' + Int_user.UsrRealNm + N' - ' +  CAST(Int_user.UsrId as varchar(10))  , Int_user.UsrId, Int_user.UsrCat FROM IntUserCat INNER JOIN Int_user ON IntUserCat.UCatId = Int_user.UsrCat WHERE (Int_user.UsrCat = 0)", tempTable, "0000&H")
            UserTree.Nodes.Add(tempTable(0).Item(0).ToString, tempTable(0).Item(1).ToString, 1, 3)

            'UserTree.Nodes.Add("0", "Root - X", 1, 3)
            'On Error Resume Next

            For Cnt_ = 0 To UserTable.Rows.Count - 1
                TempNode = UserTree.Nodes.Find(UserTable(Cnt_).Item(2).ToString, True)
                TempNode(0).Nodes.Add(UserTable(Cnt_).Item(1).ToString, UserTable(Cnt_).Item(2).ToString & "-" & UserTable(Cnt_).Item(3).ToString & "-" & UserTable(Cnt_).Item(0).ToString, 0, 2)
                If TempNode(0).Nodes.Count > 0 Then
                    TempNode(0).ImageIndex = 1
                    TempNode(0).SelectedImageIndex = 3
                    If TempNode(0).Level > 3 Then
                        TempNode(0).ForeColor = Color.Red
                    Else
                        TempNode(0).ForeColor = Color.Black
                    End If
                End If
            Next Cnt_
        Else
            WelcomeScreen.StatBrPnlEn.Text = "  Offline - Can't open User Create Form...  "
            Close()
        End If
    End Sub

    Private Sub UserTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles UserTree.AfterSelect
        If e.Action <> TreeViewAction.Unknown Then  ' The code only executes if the user caused the checked state to change.
            UserTree.SelectedNode.Expand()
            'Label1.Text = UserTree.SelectedNode.Name
            'Label2.Text = UserTree.SelectedNode.Text
            'Label3.Text = UserTree.SelectedNode.Index
            'UserTree.Visible = False
            'TxtCat.BackColor = Color.FromArgb(192, 255, 192)
            'TxtCat.Enabled = False
            'LblHCat.Visible = False
            'ChkVal()
        End If

    End Sub
    Private Sub UserTree_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles UserTree.ItemDrag
        DoDragDrop(e.Item, DragDropEffects.Move)  'Set the drag node and initiate the DragDrop
    End Sub
    Private Sub UserTree_DragEnter(sender As Object, e As DragEventArgs) Handles UserTree.DragEnter
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then '  See if TreeNode is being dragged
            e.Effect = DragDropEffects.Move                                  '  Found then move effect
        Else
            e.Effect = DragDropEffects.None '                                   Not found no move
        End If
    End Sub
    Private Sub UserTree_DragOver(sender As Object, e As DragEventArgs) Handles UserTree.DragOver
        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
        Dim selectedTreeview As TreeView = CType(sender, TreeView) 'Get the TreeView raising the event (incase multiple on form)
        '       When the mouse moves over nodes, it highlighting the node that is the Current drop target
        Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
        Dim TrgtNode As TreeNode = selectedTreeview.GetNodeAt(pt)
        '       See if the targetNode is Currently selected, if so no need to validate again
        If Not (selectedTreeview.SelectedNode Is TrgtNode) Then
            selectedTreeview.SelectedNode = TrgtNode '             Select the node Currently under the cursor

            'Check that the selected node is not the dropNode and also that it is not a child of the dropNode and is an invalid target
            Dim DrpNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
            Do Until TrgtNode Is Nothing
                If TrgtNode Is DrpNode Then
                    e.Effect = DragDropEffects.None
                    Exit Sub
                End If
                TrgtNode = TrgtNode.Parent
            Loop
        End If
        e.Effect = DragDropEffects.Move 'Currently selected node is a suitable target
    End Sub
    Private Sub UserTree_DragDrop(sender As Object, e As DragEventArgs) Handles UserTree.DragDrop
        Dim Fn As New APblicClss.Func
        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
        Dim selectedTreeview As TreeView = CType(sender, TreeView) 'Get the TreeView raising the event (incase multiple on form)
        Dim DrpNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode) 'Get the TreeNode being dragged
        Dim TrgtNode As TreeNode = selectedTreeview.SelectedNode 'The target node was selected from the DragOver event

        If TrgtNode Is Nothing Then  '   If there is no target Node do nothing else add it at end of the drop Node as child
            Exit Sub
        ElseIf DrpNode Is TrgtNode.Parent Then  '    If the  target node is a child in the drope node 
            Exit Sub
        ElseIf DrpNode.Parent Is TrgtNode Then  '    If the  target node is a child in the drope node 
            Exit Sub
        ElseIf TrgtNode Is DrpNode Then
            Exit Sub
        ElseIf DrpNode.Nodes.Count > 0 Then
            DrpNode.Remove()                '   Remove the drop node from its Current location
            TrgtNode.Nodes.Add(DrpNode)     '   Add the drop node to tthe new location
            If Fn.InsUpdate("update IntUserCat set UCatIdSub = " & TrgtNode.Name & " Where (UCatId = " & DrpNode.Name & ");", "0000&H") = Nothing Then

            Else
                MsgErr(Errmsg)
            End If
            Exit Sub
        Else
            DrpNode.Remove()                '   Remove the drop node from its Current location
            '   Add the drop node to tthe new location
            'If InsUpd("update IntUserCat set UCatIdSub = " & TrgtNode.Name & " Where (UCatId = " & DrpNode.Name & ");", "0000&H") <> Nothing Then
            '    MsgErr(Errmsg)
            'End If
            If Fn.InsUpdate("update int_user set UsrCat = " & TrgtNode.Nodes(0).Name & " Where (UsrId = " & Split(DrpNode.Text, "-")(3) & ");", "0000&H") = Nothing Then
                TrgtNode.Nodes.Add(DrpNode)
            Else
                MsgErr(Errmsg)
            End If
        End If
        DrpNode.EnsureVisible()
        selectedTreeview.SelectedNode = DrpNode ' make the change here of the catagory and sub catagory
    End Sub
    Dim SlctedNode As TreeNode
    Dim NodeCnt As Integer = 1
    Dim SlctUsrID As Integer
    Dim BeforSecStr As String = ""
    Private ReadOnly SecNODESTHATMATCH As New List(Of TreeNode) 'Tree Search Function
    Private ReadOnly NODESTHATMATCH As New List(Of TreeNode) 'Tree Search Function
    Private Sub BtnSerch_Click(sender As Object, e As EventArgs) Handles BtnSerch.Click
        Label4.Text = ""
        If IsNothing(SlctedNode) = False Then SlctedNode.BackColor = Color.White
        UserTree.CollapseAll()
        If SearchTheTreeView(UserTree, TreeSrchBx.Text) Is Nothing Then
            Label4.Text = ("No Match Found")
        Else
            NodeCnt = 1
            LblCnt.Text = NodeCnt & " Of " & NODESTHATMATCH.Count
            UserTree.SelectedNode = SearchTheTreeView(UserTree, TreeSrchBx.Text)
            SlctedNode = UserTree.SelectedNode
            SlctedNode.BackColor = Color.LimeGreen
        End If
    End Sub
    Private Function SearchTheTreeView(ByVal TreeView1 As TreeView, ByVal TextToFind As String) As TreeNode
        '  Empty previous
        NODESTHATMATCH.Clear()
        ' Keep calling RecursiveSearch
        For Each TN As TreeNode In TreeView1.Nodes
            If TN.Text.Contains(TextToFind) Then
                NODESTHATMATCH.Add(TN)

            End If
            RecursiveSearch(TN, TextToFind)
        Next

        If NODESTHATMATCH.Count > 0 Then
            For Each TN As TreeNode In TreeView1.Nodes
                If TN.Checked = True Then
                    MsgBox(TN.Text)
                    TreeView1.SelectedNode = TN
                    TN.ForeColor = Color.LightGreen
                End If
            Next
            Return NODESTHATMATCH(0)
        Else
            Return Nothing
        End If
    End Function
    Private Function SecSearchTreeView(ByVal TreeView1 As TreeView, ByVal TextToFind As String) As TreeNode
        '  Empty previous
        SecNODESTHATMATCH.Clear()
        ' Keep calling RecursiveSearch
        For Each TN As TreeNode In TreeView1.Nodes
            If TN.Name = (TextToFind) Then
                SecNODESTHATMATCH.Add(TN)
            End If
            SecRecursiveSearch(TN, TextToFind)
        Next
        If SecNODESTHATMATCH.Count > 0 Then
            Return SecNODESTHATMATCH(0)
        Else
            Return Nothing
        End If
    End Function
    Private Sub RecursiveSearch(ByVal treeNode As TreeNode, ByVal TextToFind As String)
        ' Keep calling the test recursively.
        For Each TN As TreeNode In treeNode.Nodes
            If TN.Text.Contains(TextToFind) Then
                NODESTHATMATCH.Add(TN)
                TN.Checked = True
            End If
            RecursiveSearch(TN, TextToFind)
        Next
    End Sub
    Private Sub SecRecursiveSearch(ByVal treeNode As TreeNode, ByVal TextToFind As String)
        ' Keep calling the test recursively.
        For Each TN As TreeNode In treeNode.Nodes
            If TN.Name = (TextToFind) Then
                SecNODESTHATMATCH.Add(TN)
            End If

            SecRecursiveSearch(TN, TextToFind)
        Next
    End Sub

    Private Sub TreeSrchBx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TreeSrchBx.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Label4.Text = ""
            If IsNothing(SlctedNode) = False Then SlctedNode.BackColor = Color.White
            UserTree.CollapseAll()
            If SearchTheTreeView(UserTree, TreeSrchBx.Text) Is Nothing Then
                Label4.Text = ("No Match Found")
            Else
                NodeCnt = 1
                LblCnt.Text = NodeCnt & " Of " & NODESTHATMATCH.Count
                UserTree.SelectedNode = SearchTheTreeView(UserTree, TreeSrchBx.Text)
                SlctedNode = UserTree.SelectedNode
                SlctedNode.BackColor = Color.LimeGreen
            End If
        End If
    End Sub

    Private Sub BtnNxt_Click(sender As Object, e As EventArgs) Handles BtnNxt.Click
        Label4.Text = ""
        If NodeCnt < NODESTHATMATCH.Count Then
            If NodeCnt < NODESTHATMATCH.Count Then
                NodeCnt += 1
                LblCnt.Text = NodeCnt & " Of " & NODESTHATMATCH.Count
            Else
                LblCnt.Text = NODESTHATMATCH.Count & " Of " & NODESTHATMATCH.Count
            End If
            UserTree.SelectedNode = NODESTHATMATCH(NodeCnt - 1)
            SlctedNode = UserTree.SelectedNode
            SlctedNode.BackColor = Color.LimeGreen
        ElseIf NodeCnt = NODESTHATMATCH.Count Then
            Label4.Text = ("This is the Last Record")
        End If
    End Sub

    Private Sub BtnPrvs_Click(sender As Object, e As EventArgs) Handles BtnPrvs.Click
        Label4.Text = ""
        If NodeCnt >= 2 Then
            NodeCnt -= 1
            LblCnt.Text = NodeCnt & " Of " & NODESTHATMATCH.Count
            UserTree.SelectedNode = NODESTHATMATCH(NodeCnt - 1)
            SlctedNode = UserTree.SelectedNode
            SlctedNode.BackColor = Color.LimeGreen
        Else
            Label4.Text = ("This is the First Record")
        End If
    End Sub
End Class