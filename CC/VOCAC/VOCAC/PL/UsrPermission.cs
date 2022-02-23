using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VOCAC.PL
{
    public partial class UsrPermission : Form
    {
        private static UsrPermission frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static UsrPermission getuserPassChangefrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new UsrPermission();
                }
                return frm;
            }
        }
        private readonly List<TreeNode> SecNODESTHATMATCH = new List<TreeNode>(); // Tree Search Function
        private readonly List<TreeNode> NODESTHATMATCH = new List<TreeNode>(); // Tree Search Function
        TreeNode SlctedNode;
        private int NodeCnt = 1;
        int SlctUsrID = 0;
        public UsrPermission()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
            this.Size = new Size(WelcomeScreen.getwecmscrnfrm.Size.Width - 100, WelcomeScreen.getwecmscrnfrm.Size.Height - 100);
            splitContainer1.Size = new Size(WelcomeScreen.getwecmscrnfrm.Size.Width - 200 - FlowLayoutPanel1.Width, WelcomeScreen.getwecmscrnfrm.Size.Height - 180);
            trackBar1.Maximum = splitContainer1.Size.Width;
            trackBar1.Value = splitContainer1.Panel1.Width;
            FlowLayoutPanel1.Height = UserTree.Height;
            treeView1.Size = new Size(treeView1.Size.Width - 20, UserTree.Size.Height - 243);
        }

        private void UsrPermission_Load(object sender, EventArgs e)
        {
            frm.FormClosed -= new FormClosedEventHandler(frm_Closed);
            frm.FormClosed += new FormClosedEventHandler(frm_Closed);
            Usertree();
            SeCTree();
        }
        public void Usertree()
        {
            UserTree.ImageList = imageList1;
            TreeNode[] TempNode = new TreeNode[0];
            UserTree.Nodes.Clear();
            Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UCatId = 0";
            UserTree.Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[0]["UCatId"].ToString(),
            Statcdif.TreeUsrTbl.DefaultView[0]["UsrMix"].ToString(), 1, 3);
            Statcdif.TreeUsrTbl.DefaultView.RowFilter = "(UsrSusp = 0) and (UCatId <> 0)";

            for (int i = 0; i < Statcdif.TreeUsrTbl.DefaultView.Count; i++)
            {
                TempNode = UserTree.Nodes.Find(Statcdif.TreeUsrTbl.DefaultView[i][2].ToString(), true);
                if (TempNode.Length > 0)
                {
                    TempNode[0].ImageIndex = 2;
                    int gndr;
                    if (Statcdif.TreeUsrTbl.DefaultView[i]["UsrGender"].ToString().Equals("Male", StringComparison.OrdinalIgnoreCase))
                    { gndr = 0; }
                    else { gndr = 1; }
                    TempNode[0].Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[i]["UCatId"].ToString(), Statcdif.TreeUsrTbl.DefaultView[i]["UsrMix"].ToString(), gndr, 2);
                    if (TempNode[0].Nodes.Count > 0)
                    {
                        TempNode[0].ImageIndex = 2;
                        TempNode[0].SelectedImageIndex = 3;
                    }
                }
            }
            UserTree.SelectedNode = UserTree.Nodes[0];
        }
        public void SeCTree()
        {
            TreeNode Chldnode2;

            Statcdif.SwitchTbl.DefaultView.RowFilter = "SwType = 'Tab' and SwID_New > 0";
            DataTable tabTbl = new DataTable();
            tabTbl = Statcdif.SwitchTbl.DefaultView.ToTable();

            for (int i = 0; i < tabTbl.Rows.Count; i++)
            {
                SecTree.Nodes[0].Nodes.Add(tabTbl.Rows[i]["SwID_New"].ToString(), tabTbl.Rows[i]["SwID_New"].ToString() + "-" + tabTbl.Rows[i]["SwNm"].ToString());
                Statcdif.SwitchTbl.DefaultView.RowFilter = "SwType <> 'Tab' and SwID_New > 0 and SwSer = '" + tabTbl.Rows[i]["SwSer"].ToString() + "'";
                Chldnode2 = SecTree.Nodes[0].Nodes[i];
                for (int u = 0; u < Statcdif.SwitchTbl.DefaultView.Count; u++)
                {
                    Chldnode2.Nodes.Add(Statcdif.SwitchTbl.DefaultView[u]["SwID_New"].ToString(), Statcdif.SwitchTbl.DefaultView[u]["SwID_New"].ToString() + "-" + Statcdif.SwitchTbl.DefaultView[u]["SwNm"].ToString());
                    Chldnode2.BackColor = Color.Aqua;
                    Chldnode2.NodeFont = new Font("Times New Roman", 12, FontStyle.Bold);
                }
            }
            Statcdif.SwitchTbl.DefaultView.RowFilter = "SwType = 'System'  and SwID_New > 0";

            for (int u = 0; u < Statcdif.SwitchTbl.DefaultView.Count; u++)
            {
                SecTree.Nodes[1].Nodes.Add(Statcdif.SwitchTbl.DefaultView[u]["SwID_New"].ToString(), Statcdif.SwitchTbl.DefaultView[u]["SwID_New"].ToString() + "-" + Statcdif.SwitchTbl.DefaultView[u]["SwNm"].ToString());
            }
            SecTree.ExpandAll();
            UserTree.SelectedNode = null;
        }
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = trackBar1.Value;
        }
        private void UserTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)// The code only executes if the user caused the checked state to change.
                AftrSlct();
        }
        private void AftrSlct()
        {
            treeView1.Nodes.Clear();
            TreeNode[] TempNode = new TreeNode[0];
            TreeNode TempNode2;
            Statcdif.TreeUsrTbl.DefaultView.RowFilter = " UsrId = " + UserTree.SelectedNode.Text.ToString().Split('-')[2].Trim();
            for (int i = 0; i < Statcdif.TreeUsrTbl.DefaultView[0]["UsrLevel_New"].ToString().Length; i++)
            {
                TempNode = SecTree.Nodes.Find((i + 1).ToString(), true);
                if (TempNode.Length > 0)
                {
                    if (Statcdif.TreeUsrTbl.DefaultView[0]["UsrLevel_New"].ToString().Substring(i, 1) == "A")
                    {
                        if (TempNode[0].Level == 1)
                        {
                            treeView1.Nodes.Add(TempNode[0].Text.Split('-')[0], TempNode[0].Text.Split('-')[1]).NodeFont = new Font("Times New Roman", 12, FontStyle.Bold);
                        }
                        else if (TempNode[0].Level == 2)
                        {
                            if (SearchTheTreeView(treeView1, TempNode[0].Parent.Text.Split('-')[1]) != null)
                            {
                                SearchTheTreeView(treeView1, TempNode[0].Parent.Text.Split('-')[1]).Nodes.Add("1", TempNode[0].Text.Split('-')[1]);
                            }
                        }
                        TempNode[0].Checked = true;
                        TempNode[0].ForeColor = Color.Green;
                        TempNode[0].NodeFont = new Font("Times New Roman", 16, FontStyle.Bold);
                    }
                    else
                    {
                        TempNode[0].Checked = false;
                        TempNode[0].ForeColor = Color.Red;
                        TempNode[0].NodeFont = new Font("Times New Roman", 10, FontStyle.Bold);
                    }

                }
            }
            treeView1.ExpandAll();
        }
        private TreeNode SecSearchTreeView(TreeView TreeView1, string TextToFind)
        {
            // Empty previous
            SecNODESTHATMATCH.Clear();
            // Keep calling RecursiveSearch
            foreach (TreeNode TN in TreeView1.Nodes)
            {
                if (TN.Name == (TextToFind))
                    SecNODESTHATMATCH.Add(TN);
                SecRecursiveSearch(TN, TextToFind);
            }
            if (SecNODESTHATMATCH.Count > 0)
                return SecNODESTHATMATCH[0];
            else
                return null/* TODO Change to default(_) if this is not a reference type */;
        }
        private void SecRecursiveSearch(TreeNode treeNode, string TextToFind)
        {
            // Keep calling the test recursively.
            foreach (TreeNode TN in treeNode.Nodes)
            {
                if (TN.Name == (TextToFind))
                    SecNODESTHATMATCH.Add(TN);

                SecRecursiveSearch(TN, TextToFind);
            }
        }
        private TreeNode SearchTheTreeView(TreeView TreeView1, string TextToFind)
        {
            // Empty previous
            NODESTHATMATCH.Clear();
            // Keep calling RecursiveSearch
            foreach (TreeNode TN in TreeView1.Nodes)
            {
                if (TN.Text.Contains(TextToFind))
                    NODESTHATMATCH.Add(TN);
                RecursiveSearch(TN, TextToFind);
            }

            if (NODESTHATMATCH.Count > 0)
            {
                foreach (TreeNode TN in TreeView1.Nodes)
                {
                    if (TN.Checked == true)
                    {
                        function fn = function.getfn;
                        fn.msg(TN.Text, "Serch", MessageBoxButtons.OK);
                        TreeView1.SelectedNode = TN;
                        TN.ForeColor = Color.LightGreen;
                    }
                }
                return NODESTHATMATCH[0];
            }
            else
            {
                return null/* TODO Change to default(_) if this is not a reference type */;
            }

        }
        private void RecursiveSearch(TreeNode treeNode, string TextToFind)
        {
            // Keep calling the test recursively.
            foreach (TreeNode TN in treeNode.Nodes)
            {
                if (TN.Text.Contains(TextToFind))
                {
                    NODESTHATMATCH.Add(TN);
                    TN.Checked = true;
                }
                RecursiveSearch(TN, TextToFind);
            }
        }
        private void BtnSerch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            Label4.Text = "";
            if (SlctedNode != null)
            {
                SlctedNode.BackColor = Color.White;
                UserTree.CollapseAll();
            }
            if (SearchTheTreeView(UserTree, TreeSrchBx.Text) == null)
            {
                Label4.Text = ("No Match Found");
            }
            else
            {
                NodeCnt = 1;
                LblCnt.Text = NodeCnt + " Of " + NODESTHATMATCH.Count;
                UserTree.SelectedNode = SearchTheTreeView(UserTree, TreeSrchBx.Text);
                SlctedNode = UserTree.SelectedNode;
                SlctedNode.BackColor = Color.LimeGreen;
                AftrSlct();
            }

        }
        private void BtnNxt_Click(object sender, EventArgs e)
        {
            Label4.Text = "";
            if (NodeCnt < NODESTHATMATCH.Count)
            {
                if (NodeCnt < NODESTHATMATCH.Count)
                {
                    NodeCnt += 1;
                    LblCnt.Text = NodeCnt + " Of " + NODESTHATMATCH.Count;
                }
                else
                {
                    LblCnt.Text = NODESTHATMATCH.Count + " Of " + NODESTHATMATCH.Count;
                }
                UserTree.SelectedNode = NODESTHATMATCH[NodeCnt - 1];
                SlctedNode = UserTree.SelectedNode;
                SlctedNode.BackColor = Color.LimeGreen;
                AftrSlct();
            }
            else if (NodeCnt == NODESTHATMATCH.Count)
            {
                Label4.Text = ("This is the Last Record");
            }
        }
        private void BtnPrvs_Click(object sender, EventArgs e)
        {
            Label4.Text = "";
            if (NodeCnt >= 2)
            {
                NodeCnt -= 1;
                LblCnt.Text = NodeCnt + " Of " + NODESTHATMATCH.Count;
                UserTree.SelectedNode = NODESTHATMATCH[NodeCnt - 1];
                SlctedNode = UserTree.SelectedNode;
                SlctedNode.BackColor = Color.LimeGreen;
                AftrSlct();
            }
            else
            {
                Label4.Text = ("This is the First Record");
            }
        }
        private void TreeSrchBx_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = Statcdif.ArabicInput;
        }
        private void TreeSrchBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)(e.KeyChar) == Keys.Enter)
            {
                Search();
            }
        }

        private void SecTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                bool AStat = e.Node.Checked;
                if (e.Node.Checked == true)
                {
                    e.Node.ForeColor = Color.DarkGreen;
                    e.Node.NodeFont = new Font("Times New Roman", 11, FontStyle.Bold);
                }
                else
                {
                    e.Node.ForeColor = Color.Red;
                    e.Node.NodeFont = new Font("Arial", 8, FontStyle.Italic);
                }


                for (var Cnt_ = 0; Cnt_ <= e.Node.Nodes.Count - 1; Cnt_++)
                {
                    e.Node.Nodes[Cnt_].Checked = AStat;

                    if (e.Node.Nodes[Cnt_].Level > 1)
                    {
                        if (AStat == true)
                        {
                            e.Node.Nodes[Cnt_].ForeColor = Color.DarkGreen;
                            e.Node.Nodes[Cnt_].NodeFont = new Font("Times New Roman", 12, FontStyle.Regular);
                        }
                        else
                        {
                            e.Node.Nodes[Cnt_].ForeColor = Color.Red;
                            e.Node.Nodes[Cnt_].NodeFont = new Font("Arial", 10, FontStyle.Italic);
                        }
                    }
                }
            }
        }

        private void BtnAply_Click(object sender, EventArgs e)
        {
            TreeNode SecTreeNode;
            string[] PerStr = new string[100];
            string LblSecLvl_;

            for (int i = 0; i < PerStr.Length; i++)
            {
                SecTreeNode = SecSearchTreeView(SecTree, (i + 1).ToString());
                if (SecTreeNode != null)
                {
                    if (SecTreeNode.Checked)
                    {
                        //MsgInf(SecTreeNode.Text.ToString & PerStr(Cnt_))
                        PerStr[i] = "A";
                    }
                    else
                    {
                        PerStr[i] = "X";
                    }
                }
                else
                {
                    PerStr[i] = "X";
                }
            }


            LblSecLvl_ = string.Join("", PerStr);

            applyPermission("update Int_user set UsrLevel_New= '" + String.Join("", PerStr) + "' WHERE (UsrId = " + UserTree.SelectedNode.Text.ToString().Split('-')[2].Trim() + ");");
            function fn = function.getfn;
            fn.msg("Done", "", MessageBoxButtons.OK);
        }
        private string applyPermission(string UpdateSTR)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@slctstat", SqlDbType.VarChar);
            param[0].Value = UpdateSTR;
            DAL.DataAccessLayer.rturnStruct RsultPopulateChoice = DAL.ExcuteCommand("SP_CHOICE_SLCT", param);
            DAL.Close();
            return RsultPopulateChoice.msg;
        }
    }
}
