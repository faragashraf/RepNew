using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VOCAC;
using VOCAC.DAL;

namespace testvoca
{
    public partial class emam : System.Web.UI.Page
    {
        function fn = function.getfn;
        VOCAC.BL.CLS_LOGIN log = new VOCAC.BL.CLS_LOGIN();
        SqlConnection sqlcon = new SqlConnection(Statcdif.strConn);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable TickTblMain = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dvtree.Visible = false;
                Statcdif._IP = fn.OsIP();
            }


        }
        protected void LogInBtn_Click(object sender, EventArgs e)
        {
            Log();
        }
        private void Log()
        {
            LogInBtn.Enabled = false;
            LblLogin.Text = "          Authenticating";

            VOCAC.DAL.DataAccessLayer.rturnStruct logreslt = log.LOGIN(TxtUsrNm.Text, TxtUsrPass.Text, "WEB", Statcdif._IP);
            if (logreslt.msg == null)
            {
                if (logreslt.dt.Rows.Count > 0)
                {
                    Statcdif.UserTable = logreslt.dt;
                    IntializeUser();
                    SelctMainTables();
                    MyTeam(CurrentUser.UsrCat, CurrentUser.UsrID);
                    //treeload();
                    dvtree.Visible = true;
                    login.Visible = false;
                    lblusr.Text = "Welcome " + CurrentUser.UsrRlNm;
                    LblLogin.Visible = false;
                    filtbl();
                }
                else
                {
                    LblLogin.Text = "Invalid User Name Or Password";
                }
            }
            else
            {
                LblLogin.Text = "";
                fn.msg("لم ينجح الإتصال بقواعد البيانات" + Environment.NewLine + logreslt.msg, "Login");
            }
            LogInBtn.Enabled = true;
            GC.Collect();
        }
        private void SelctMainTables()
        {
            Statcdif.CompSurceTable = new DataTable();
            Statcdif.ProdKTable = new DataTable();
            Statcdif.ProdCompTable = new DataTable();
            Statcdif.UpdateKTable = new DataTable();
            Statcdif.CDHolDay = new DataTable();
            Statcdif.MendFildsTable = new DataTable();
            Statcdif.MendPvtTable = new DataTable();
            Statcdif.TreeUsrTbl = new DataTable();
            VOCAC.DAL.DataAccessLayer.rturnStruct SlctMainreslt = log.slctmaintbls();
            if (SlctMainreslt.ds.Tables.Count > 0)
            {
                Statcdif.CompSurceTable = SlctMainreslt.ds.Tables[0];
                Statcdif.ProdKTable = SlctMainreslt.ds.Tables[1];
                Statcdif.ProdCompTable = SlctMainreslt.ds.Tables[2];
                Statcdif.UpdateKTable = SlctMainreslt.ds.Tables[3];
                Statcdif.CDHolDay = SlctMainreslt.ds.Tables[4];
                Statcdif.MendFildsTable = SlctMainreslt.ds.Tables[5];
                Statcdif.MendPvtTable = SlctMainreslt.ds.Tables[6];
                Statcdif.MendPvtTable = SlctMainreslt.ds.Tables[6];
                Statcdif.TreeUsrTbl = SlctMainreslt.ds.Tables[7];
                if (CurrentUser.UsrUCatLvl == 7)
                {
                    Statcdif.CompSurceTable.DefaultView.RowFilter = "[SrcSusp] =" + 0 + " AND [srcCd] = '1'";     //     SrcStr = "select SrcCd, SrcNm from CDSrc where SrcSusp=0 and srcCd = 1 ORDER BY SrcNm";
                }
                else
                {
                    Statcdif.CompSurceTable.DefaultView.RowFilter = "[SrcSusp] =" + 0 + " AND [srcCd] > '1'";   //  SrcStr = "Select SrcCd, SrcNm from CDSrc where SrcSusp=0 And srcCd > 1 ORDER BY SrcNm"
                }
                Statcdif.FildList.Clear();
                for (int i = 0; i < Statcdif.MendPvtTable.Rows.Count; i++)
                {
                    Statcdif.FildList.Add("[" + Statcdif.MendPvtTable.Rows[i].Field<string>("FildKind") + "]");
                }
            }
        }
        private void IntializeUser()
        {
            CurrentUser.UsrID = Statcdif.UserTable.Rows[0].Field<int>("UsrId");                  //store user ID
            CurrentUser.UsrCat = Statcdif.UserTable.Rows[0].Field<int>("UsrCat");                //Current User Catagory
            CurrentUser.UsrNm = Statcdif.UserTable.Rows[0].Field<String>("UsrNm");               //Current User Name
            CurrentUser.UsrPWrd = Statcdif.UserTable.Rows[0].Field<String>("UsrPassTmp");        //Current User Password
            CurrentUser.UsrLvl = Statcdif.UserTable.Rows[0].Field<String>("UsrLevel");           //Current User Class
            CurrentUser.UsrRlNm = Statcdif.UserTable.Rows[0].Field<String>("UsrRealNm");         //Current user Real Name
            CurrentUser.UsrMail = Statcdif.UserTable.Rows[0].Field<String>("UsrEmail");          //Current user UsrEmail
            CurrentUser.UsrSisco = Statcdif.UserTable.Rows[0].Field<String>("UsrSisco");         //Current user UsrSisco
            CurrentUser.UsrGsm = Statcdif.UserTable.Rows[0].Field<String>("UsrGsm");             //Current user UsrGsm
            CurrentUser.UsrGndr = Statcdif.UserTable.Rows[0].Field<String>("UsrGender");         //Current user Gender
            CurrentUser.UsrActv = Statcdif.UserTable.Rows[0].Field<bool>("UsrActive");           //Current User Active Or not
            if (Statcdif.UserTable.Rows[0]["UsrLastSeen"] != null && Statcdif.UserTable.Rows[0]["UsrLastSeen"].ToString().Length > 0)
            { CurrentUser.UsrLstS = Statcdif.UserTable.Rows[0].Field<DateTime>("UsrLastSeen"); }    //Current User LastSeen
            CurrentUser.UsrSusp = Statcdif.UserTable.Rows[0].Field<bool>("UsrSusp");             //Current User Suspended Or not
            CurrentUser.UsrTcCnt = Statcdif.UserTable.Rows[0].Field<int>("UsrTkCount");          //Ticket Count
            CurrentUser.UsrSltKy = Statcdif.UserTable.Rows[0].Field<String>("SaltKey");          //SaltKey
            CurrentUser.UsrCatNm = Statcdif.UserTable.Rows[0].Field<String>("UCatNm");           //Catagory name
            CurrentUser.UsrCalCntr = Statcdif.UserTable.Rows[0].Field<bool>("UsrCalCntr");       //Call Center Boolean
            CurrentUser.UsrUCatLvl = Statcdif.UserTable.Rows[0].Field<Int16>("UCatLvl");         //User Cat. Level
            CurrentUser.UsrClsN = Statcdif.UserTable.Rows[0].Field<int>("UsrClsN");              //Open Complaint Count
            CurrentUser.UsrFlN = Statcdif.UserTable.Rows[0].Field<int>("UsrFlN");                //No Follow Count
            CurrentUser.UsrReOpY = Statcdif.UserTable.Rows[0].Field<int>("UsrReOpY");            //ReOPen Couunt
            CurrentUser.UsrUnRead = Statcdif.UserTable.Rows[0].Field<int>("UsrUnRead");          //Unread Events Count
            CurrentUser.UsrEvDy = Statcdif.UserTable.Rows[0].Field<int>("UsrEvDy");              //Event Count Per Day
            CurrentUser.UsrClsYDy = Statcdif.UserTable.Rows[0].Field<int>("UsrClsYDy");          //Closed Complaint Per day
            CurrentUser.UsrReadYDy = Statcdif.UserTable.Rows[0].Field<int>("UsrReadYDy");        //Read Events Count Per Day
            CurrentUser.UsrRecvDy = Statcdif.UserTable.Rows[0].Field<int>("UsrRecevDy");         //RecievedTickets Count Per Day
            CurrentUser.UsrClsUpdtd = Statcdif.UserTable.Rows[0].Field<int>("UsrClsUpdtd");      //Closed Tickets with New Updates
            CurrentUser.UsrFolwDay = Statcdif.UserTable.Rows[0].Field<int>("UsrTikFlowDy");      //Closed Tickets with New Updates
            CurrentUser.Usrpath = Statcdif.UserTable.Rows[0].Field<string>("UCatPath") + "/" + CurrentUser.UsrCat;          //User Tree Path
            //Usrpath

        }
        //private void treeload()
        //{
        //    TreeView1.Visible = true;
        //    TreeView1.Nodes.Clear();

        //    if (TreeView1.Nodes.Count == 0)
        //    {
        //        for (int i = 0; i < Statcdif.ProdKTable.Rows.Count; i++)
        //        {
        //            TreeNode hh = new TreeNode();
        //            hh.Value = Statcdif.ProdKTable.Rows[i][0].ToString();
        //            hh.Text = Statcdif.ProdKTable.Rows[i][1].ToString();
        //            TreeView1.Nodes.Add(hh);
        //        }
        //        TreeNode childnode = new TreeNode();
        //        string Child = "";
        //        for (int i = 0; i < Statcdif.ProdCompTable.DefaultView.Count; i++)
        //        {
        //            childnode = (TreeView1.FindNode(Statcdif.ProdCompTable.DefaultView[i]["PrdKind"].ToString()));
        //            if (Statcdif.ProdCompTable.DefaultView[i]["PrdNm"].ToString() != Child)
        //            {
        //                TreeNode nn = new TreeNode();
        //                nn.Value = Statcdif.ProdCompTable.DefaultView[i]["FnProdCd"].ToString();
        //                nn.Text = Statcdif.ProdCompTable.DefaultView[i]["PrdNm"].ToString() + "_" + Statcdif.ProdCompTable.DefaultView[i]["FnProdCd"].ToString();
        //                childnode.ChildNodes.Add(nn);
        //            }
        //            Child = Statcdif.ProdCompTable.DefaultView[i]["PrdNm"].ToString();
        //        }
        //        TreeNode childnode1 = new TreeNode();

        //        for (int W = 0; W < Statcdif.ProdKTable.DefaultView.Count; W++)
        //        {
        //            childnode1 = (TreeView1.FindNode(Statcdif.ProdKTable.DefaultView[W][0].ToString()));

        //            for (int t = 0; t < childnode1.ChildNodes.Count; t++)
        //            {
        //                Statcdif.ProdCompTable.DefaultView.RowFilter = "PrdNm = '" + childnode1.ChildNodes[t].Text.Split('_')[0] + "'";

        //                for (int i = 0; i < Statcdif.ProdCompTable.DefaultView.Count; i++)
        //                {
        //                    TreeNode nn = new TreeNode();
        //                    nn.Value = Statcdif.ProdCompTable.DefaultView[i]["FnCompCd"].ToString();
        //                    nn.Text = Statcdif.ProdCompTable.DefaultView[i]["CompNm"].ToString() + "_" + Statcdif.ProdCompTable.DefaultView[i]["FnCompCd"].ToString();
        //                    childnode1.ChildNodes[t].ChildNodes.Add(nn);
        //                }
        //            }
        //        }
        //    }


        //    //for (int o = 0; o < TreeView1.Nodes.Count; o++)
        //    //{
        //    //    for (int p = 0; p < TreeView1.Nodes[o].Nodes.Count; p++)
        //    //    {
        //    //        if (TreeView1.Nodes[o].Nodes[p].ToString().Split(':')[1].Trim().Equals(Statcdif.ProdCompTable.DefaultView[i]["PrdNm"].ToString(), StringComparison.OrdinalIgnoreCase))
        //    //        {
        //    //            TreeView1.Nodes[o].Nodes[p].Nodes.Add(Statcdif.ProdCompTable.DefaultView[i]["FnSQL"].ToString(), Statcdif.ProdCompTable.DefaultView[i]["CompNm"].ToString(), 0, 2);
        //    //            for (int q = 0; q < TreeView1.Nodes[o].Nodes[p].GetNodeCount(true); q++)
        //    //            {
        //    //                TreeView1.Nodes[o].Nodes[p].Nodes[q].ForeColor = Color.Green;
        //    //            }
        //    //            TreeView1.Nodes[o].Nodes[p].ForeColor = Color.FromArgb(165, 42, 42);
        //    //        }
        //    //    }
        //    //}



        //}
        public void MyTeam(int LedrCat, int LedrId, bool Stat = false)
        {
            List<string> UsrStr = new List<string>();
            TreeNode childnode1 = new TreeNode();
            TreeView2.Nodes.Clear();
            // if master flag has A Value will popule full tree
            if (CurrentUser.UsrLvl.Substring(16, 1) == "A")
            {
                Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UCatId = 0";
                childnode1.Value = Statcdif.TreeUsrTbl.DefaultView[0]["UCatId"].ToString();
                childnode1.Text = Statcdif.TreeUsrTbl.DefaultView[0]["UsrMix"].ToString();
                TreeView2.Nodes.Add(childnode1);
                childnode1.Selected = true;
                Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UsrId <> 32004";
                for (int i = 0; i < Statcdif.TreeUsrTbl.DefaultView.Count; i++)
                {
                    TreeNode TR1 = new TreeNode();
                    TreeNode trchld = new TreeNode();
                    TR1 = TreeView2.FindNode(Statcdif.TreeUsrTbl.DefaultView[i]["UCatPath"].ToString());
                    TR1.Selected = true;

                    trchld.Value = Statcdif.TreeUsrTbl.DefaultView[i]["UCatId"].ToString();
                    trchld.Text = Statcdif.TreeUsrTbl.DefaultView[i]["UsrMix"].ToString();
                    TreeView2.SelectedNode.ChildNodes.Add(trchld);
                    UsrStr.Add(Statcdif.TreeUsrTbl.DefaultView[i]["UsrId"].ToString());
                }
            }
            // if master flag has X Value will popule ONLY USER privilege
            else
            {
                childnode1.Value = LedrCat.ToString();
                childnode1.Text = CurrentUser.UsrCatNm + "-" + CurrentUser.UsrRlNm + "-" + LedrId.ToString();
                TreeView2.Nodes.Add(childnode1);                //add user to tree on node zero
                UsrStr.Add(CurrentUser.UsrID.ToString());
                // CurrentUser.Usrpath is the user path concatenated with + "/" + CurrentUser.UsrCat
                //filter treeusrtbl with only his team
                Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UCatPath like '" + CurrentUser.Usrpath + "%'";
                string _lstpath;
                for (int i = 0; i < Statcdif.TreeUsrTbl.DefaultView.Count; i++)
                {
                    TreeNode TR1 = new TreeNode();
                    TreeNode trchld = new TreeNode();

                    string _path = Statcdif.TreeUsrTbl.DefaultView[i]["UCatPath"].ToString();
                    //if split path count are equal will search about user cat in the tree
                    if (_path.Split('/').Count() == CurrentUser.Usrpath.Split('/').Count())
                    {
                        _lstpath = CurrentUser.UsrCat.ToString();
                    }
                    else
                    { //if split path count are not equal will concatenate the splited path to get new path to search about in the tree
                        List<string> last_path = new List<string>();
                        for (int q = CurrentUser.Usrpath.Split('/').Count() - 1; q < _path.Split('/').Count(); q++)
                        {
                            last_path.Add(_path.Split('/')[q].ToString());
                        }
                        _lstpath = string.Join("/", last_path);                   //concatenate the splited path
                    }
                    TR1 = TreeView2.FindNode(_lstpath);
                    TR1.Selected = true;

                    trchld.Value = Statcdif.TreeUsrTbl.DefaultView[i]["UCatId"].ToString();
                    trchld.Text = Statcdif.TreeUsrTbl.DefaultView[i]["UsrMix"].ToString();
                    TreeView2.SelectedNode.ChildNodes.Add(trchld);
                    UsrStr.Add(Statcdif.TreeUsrTbl.DefaultView[i]["UsrId"].ToString());
                }
            }

            CurrentUser.UsrTeam = string.Join(", ", UsrStr);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (TreeView1.FindNode(txt1.Text) != null)
            //{
            //    TreeNode TR = new TreeNode();
            //    TR = TreeView1.FindNode(txt1.Text);
            //    Label21.Text = TR.Text + " - " + TR.Depth;
            //    TR.Checked = true;
            //    TR.Selected = true;
            //}
            //else
            //{
            //    Label21.Text = "لا يوجد";
            //}
        }
        private DataTable filtbl()
        {
            DataAccessLayer DAL = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@id", SqlDbType.VarChar);
            param[0].Value = " in (" + CurrentUser.UsrTeam.ToString() + ")";
            param[1] = new SqlParameter("@STATUS_", SqlDbType.Bit);
            param[1].Value = 0;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_TICKETS_SLCT";
            cmd.Connection = sqlcon;
            cmd.Parameters.Add(param[0]);
            cmd.Parameters.Add(param[1]);
            da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(TickTblMain);
                GridTicket.DataSource = TickTblMain;
                GridTicket.DataBind();
            }
            catch (Exception ex)
            {
                fn.msg("هناك خطأ في الإتصال بقواعد البيانات" + Environment.NewLine + ex.Message, "متابعة الشكاوى");
            }
            DAL.Close();
            return TickTblMain;
        }

        protected void GridTicket_PreRender(object sender, EventArgs e)
        {
            Label1.Text = "Page " + (GridTicket.PageIndex + 1).ToString() + " Of " + GridTicket.PageCount.ToString();
        }
    }
}