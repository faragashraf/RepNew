﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VOCAUltimate.BL;
using VOCAUltimate.Properties;
using static VOCAUltimate.BL.ticketCurrent;

namespace VOCAUltimate.PL
{
    public partial class TikFolow_Team : Form
    {
        BL.ticketCurrent Crnt = new ticketCurrent();
        private static TikFolow_Team frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
            GC.Collect();
        }
        public static TikFolow_Team getTikFolltemfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikFolow_Team();
                }
                return frm;
            }
        }
        SqlConnection sqlcon = new SqlConnection(Statcdif.strConn);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlCommandBuilder sqlcmb;

        StringBuilder FltrStr = new StringBuilder();
        TreeNode slctdNode;
        //bool slctdNodestate;
        bool bolTeamTree;
        function fn = function.getfn;
        DataTable distributeTbl;        //Distribute Table To be filled manually as Grid Row Select Button
        public TikFolow_Team()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
            adjustButton("تحميل", Resources.DbGet);
        }
        //assign Filtr TEXT into Control Tag and assign Event EventHandler
        private void assignfltrTXTintoCtrlTag()
        {
            ChckAll.Tag = string.Empty;
            ChckRequest.Tag = "TkKind = 'طلب'";
            ChckComp.Tag = "TkKind = 'شكوى'";
            ChckUpdMe.Tag = "[folowusr] = updtusr";
            ChckUpdColeg.Tag = "[updtusr] <> folowusr AND UCatLvl >= 3 And UCatLvl <= 5";
            ChckUpdOther.Tag = "[updtusr] <> folowusr AND UCatLvl < 3 or UCatLvl > 5";
            ChckFlN.Tag = "TkFolw = 'False'";
            ChckTrnsDy.Tag = "TkRecieveDt = '" + (Statcdif.servrTime) + "'";
            ChckRegions.Tag = "TaskUserID > 0";
            ChckEsc1.Tag = "TkupEvtId = 902";
            ChckEsc2.Tag = "TkupEvtId = 903";
            ChckEsc3.Tag = "TkupEvtId = 904";

            this.Rd_Like.Click += new System.EventHandler(this.Radio_CheckedChanged);
            this.Rd_Equal.Click += new System.EventHandler(this.Radio_CheckedChanged);
            this.ChckAll.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckComp.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckEsc1.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckEsc2.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckEsc3.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckFlN.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckRequest.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckTrnsDy.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckUpdColeg.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckUpdMe.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckUpdOther.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckRegions.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
        }
        string Fltrreslt;
        bool bolTeamLeader;
        private void ShowResult()
        {
            currentRow(GridTicket);
            Crnt.AssignToForm();
            if (chckShwResult.Checked) { TikDetails.gettikdetlsfrm.BringToFront(); };
        }
        private void Chckfltr_CheckedChanged(object sender, EventArgs e)
        {
            Filtr();
        }
        private String DistributeAndAssignTicket(string StoredProcedureNm, int EmpNm, string IP, DataTable FIELDTABL)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@UserDisID", SqlDbType.Int);
            param[0].Value = EmpNm;
            param[1] = new SqlParameter("@TkupUserIP", SqlDbType.NVarChar, 15);
            param[1].Value = IP;

            param[2] = new SqlParameter();
            param[2].ParameterName = "@TicketsCollection";
            param[2].Value = FIELDTABL;
            DAL.DataAccessLayer.rturnStruct RsultPopulateChoice = DAL.ExcuteCommand(StoredProcedureNm, param);
            DAL.Close();
            return RsultPopulateChoice.msg;
        }
        DAL.DataAccessLayer.rturnStruct RsultReOpen;
        private String GetTicket(string SQLID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Any", SqlDbType.NVarChar);
            param[0].Value = SQLID;
            RsultReOpen = DAL.SelectData("SP_TICKETS_SLCT", param);
            DAL.Close();
            return RsultReOpen.msg;
        }
        private DataTable filtbl(int stat, [Optional] string Any)
        {
            WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "  جاري تحميل البيانات .......";
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            //
            param[0] = new SqlParameter("@id", SqlDbType.VarChar);
            param[0].Value = " in (" + CurrentUser.UsrTeam.ToString() + ")";
            param[1] = new SqlParameter("@STATUS_", SqlDbType.Bit);
            param[1].Value = stat;
            param[2] = new SqlParameter("@Any", SqlDbType.NVarChar);
            param[2].Value = Any;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_TICKETS_SLCT";
            cmd.Connection = sqlcon;
            cmd.Parameters.Add(param[0]);
            cmd.Parameters.Add(param[1]);
            cmd.Parameters.Add(param[2]);
            da = new SqlDataAdapter(cmd);
            try
            {
                Statcdif.TickTblMain.PrimaryKey = null;
                Statcdif.TickTblMain.Rows.Clear();
                Statcdif.TickTblMain.Columns.Clear();
                Statcdif.TickTblMain = new DataTable();
                da.Fill(Statcdif.TickTblMain);
                Statcdif.TickTblMain.Columns.Add("Wdays", typeof(int));
                GridTicket.DataSource = Statcdif.TickTblMain.DefaultView;
                Statcdif.TickTblMain.PrimaryKey = new DataColumn[] { Statcdif.TickTblMain.Columns[0] };
                gridadjst(Statcdif.TickTblMain);
            }
            catch (Exception ex)
            {
                Statcdif.TickTblMain.Rows.Clear();
                function fn = function.getfn;
                function.AppLog(ex.Message + "$" + ex.InnerException, ex.HResult.ToString(), "TikFollowTeam");
                fn.msg("هناك مشكله في الإتصال بقواعد البيانات" + Environment.NewLine, "متابعة الشكاوى", MessageBoxButtons.OK);
            }
            DAL.Close();
            GC.Collect();
            WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "";
            return Statcdif.TickTblMain;
        }

        #region Event_Handler

        private void TikFolow_Load(object sender, EventArgs e)
        {
            frm.FormClosed -= new FormClosedEventHandler(frm_Closed);
            frm.FormClosed += new FormClosedEventHandler(frm_Closed);
            if (CurrentUser.UsrLvl.Substring(89, 1) == "A") { btnReassign.Visible = true; }
            if (CurrentUser.UsrLvl.Substring(90, 1) == "A") { btnExport.Visible = true; }

            //bool bolTikSearch = frms.FormIsOpen(Application.OpenForms, typeof(TikSearchNew));
            //if (bolTikSearch)
            //{
            //    DialogResult dialogResult = MessageBox.Show("سيتم إغلاق شاشة بحث الشكاوى والطلبات للإستمرار" + Environment.NewLine + "هل تريد الإستمرار؟", "شاشة إدارة الشكاوى", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        TikSearchNew.getTikSearchfrm.Close();
            //    }
            //    else
            //    {

            //        TikFolow_Team.getTikFolltemfrm.BeginInvoke(new MethodInvoker(Close));
            //    }
            //}
            if (Convert.ToBoolean(Statcdif.AppSettings.Rows[0]["Regions"]) == true)
            {
                tabControl1.TabPages.RemoveByKey("tabTask");
            }
            {
                frms forms = new frms();
                forms.FrmAllSub(this);
                usercountrsTbl.Columns.Add("ID");
                usercountrsTbl.Columns.Add("Team");
                usercountrsTbl.Columns.Add("الاسم");
                usercountrsTbl.Columns.Add("العدد", typeof(int));
                MyTeamOnLoad();
                Statcdif.TickTblMain = new DataTable();
                if (filtbl(0).Rows.Count > 0)
                {
                    try
                    {
                        if (Statcdif.TickTblMain.DefaultView.Count > 0)
                        {
                            if (treeView1.GetNodeCount(true) == 1) { bolTeamLeader = false; } else { bolTeamLeader = true; }
                            if (bolTeamLeader == false)
                            {
                                splitContainer1.Panel1Collapsed = true;
                                tabControl1.TabPages.RemoveAt(1);
                                tabControl1.TabPages.RemoveAt(1);
                                btnTree.Visible = false;
                                btnTicket.Visible = false;
                                trackBar1.Visible = false;
                                trackBar2.Visible = false;
                                btnseting.Visible = false;
                                this.Text = "متابعة الشكاوى";
                            }
                            splitContainer2.Panel1Collapsed = true;
                            btnseting.Visible = false;
                            trackBar2.Visible = false;
                            Filtr();
                            assignfltrTXTintoCtrlTag();
                            frmAdjust();
                            counersGrid();
                            GridTicket.ClearSelection();
                            treeView1.SelectedNode = treeView1.Nodes[0];
                            //this.GridTicket.SelectionChanged += new System.EventHandler(this.GridTicket_SelectionChanged);
                            treeView1.AfterSelect += new TreeViewEventHandler(TreeView_AfterSelect);
                        }
                    }
                    catch (Exception ex)
                    {
                        fn.msg("هناك خطأ في الإتصال بقواعد البيانات" + Environment.NewLine + ex.Message, "متابعة الشكاوى", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    fn.msg("لا توجد شكاوى للمتابعة", "متابعة الشكاوى", MessageBoxButtons.OK);
                    flwCounters.Visible = false;
                }
            }
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridTicket.SelectionChanged -= new EventHandler(this.GridTicket_SelectionChanged);
            if (distributeTbl != null) { distributeTbl.Rows.Clear(); }
            if (GridTicket.DataSource != Statcdif.TickTblMain.DefaultView)
            {
                txtReopen.Clear();
                GridTicket.DataSource = Statcdif.TickTblMain.DefaultView;
            }
            checkAll.Visible = false;
            checkAll.Checked = false;
            // Reopen tree if current user is team leader and tree is closed
            if ((treeView1.GetNodeCount(true) > 1 && splitContainer1.Panel1Collapsed == true) || CurrentUser.UsrLvl.Substring(70, 1) == "A")
            {
                splitContainer1.Panel1Collapsed = false;
                flwCounters.Visible = true;
                flowLayoutPanel4.Visible = true;
            }
            if (tabControl1.SelectedTab.Name == "tabDistribute" || tabControl1.SelectedTab.Name == "tabTask")
            {
                pnlBtnClose.Visible = false;
                prepareGrid();
                splitContainer1.Panel1Collapsed = false;
                if (tabControl1.SelectedTab.Name == "tabDistribute")
                {
                    tabControl1.TabPages["tabDistribute"].Text = "تحويل وتوزيع شكاوى " + slctdNode.Text.Split('-')[1].Trim();
                    counersGrid();

                    splitContainer2.Panel1Collapsed = false;
                    btnseting.Visible = true;
                    trackBar2.Visible = true;
                }
                else if (tabControl1.SelectedTab.Name == "tabTask")
                {
                    splitContainer2.Panel1Collapsed = true;
                    btnseting.Visible = false;
                    trackBar2.Visible = false;
                    if (tabControl1.TabPages.Contains(tabTask)) { tabControl1.TabPages["tabTask"].Text = "إرسال شكاوى " + slctdNode.Text.Split('-')[1].Trim() + " للمناطق"; }

                    tabControl1.TabPages.RemoveByKey("tabDistribute");

                    treeView1.AfterSelect -= new TreeViewEventHandler(TreeView_AfterSelect);
                    MyTeamOnLoad(true);
                    treeView1.AfterSelect += new TreeViewEventHandler(TreeView_AfterSelect);
                }
                flwCounters.Enabled = false;
            }
            else if (tabControl1.SelectedTab.Name == "tabReopen")
            {
                GridTicket.DataSource = null;
                splitContainer1.Panel1Collapsed = true;         // Close tree if tree is Opened
                if (GridTicket.Columns.Count == 1) { GridTicket.Columns.RemoveAt(0); }
                SerchTxt.Clear();
                txtReopen.Clear();
                StatBrPnlAr.Text = "";
                StatBrPnlAr.Icon = null;
                flowLayoutPanel7.Visible = false;
                btnGet.BackgroundImage = Resources.DbGet;
                txtReopen.Focus();
                flwCounters.Visible = false;
                flowLayoutPanel4.Visible = false;
            }
            else
            {
                if (tabControl1.SelectedTab.Name == "tabClosed")
                {

                    Statcdif.TickTblMain.Rows.Clear();
                    pikerFrom.Value = Convert.ToDateTime(Statcdif.servrTime).AddDays(-30);
                    pikerTo.Value = (Convert.ToDateTime(Statcdif.servrTime));

                    flowLayoutPanel9.Visible = true;
                    pnlBtnClose.Visible = false;
                }
                else
                {
                    filtbl(0);

                    flowLayoutPanel9.Visible = false;
                    pnlBtnClose.Visible = true;
                    counersGrid();
                    GridTicket.ClearSelection();
                    treeView1.SelectedNode = treeView1.Nodes[0];
                }

                flwCounters.Visible = true;
                flowLayoutPanel4.Visible = true;
                flowLayoutPanel7.Visible = true;
                splitContainer2.Panel1Collapsed = true;
                btnseting.Visible = false;
                trackBar2.Visible = false;
                // pnlBtnClose.Visible = true;
                if (tabControl1.TabPages.Contains(tabTask)) { tabControl1.TabPages["tabTask"].Text = "إرسال للمناطق"; }
                if (bolTeamLeader == true)
                {
                    if (!tabControl1.Contains(tabDistribute))
                    {
                        tabControl1.TabPages.Insert(1, tabDistribute);
                        tabControl1.TabPages["tabDistribute"].Text = "توزيع وتحويل الشكاوى";
                    }
                    else
                    {
                        tabControl1.TabPages["tabDistribute"].Text = "توزيع وتحويل الشكاوى";
                    }
                }
                else
                {
                    splitContainer1.Panel1Collapsed = true;
                    btnTree.Visible = false;
                    btnTicket.Visible = false;
                    trackBar1.Visible = false;
                }
                if (bolTeamTree == false)
                {
                    MyTeamOnLoad();
                }
                for (int i = 0; i < GridTicket.Columns.Count; i++)
                {
                    GridTicket.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                }
                if (GridTicket.Columns.Count > Statcdif.TickTblMain.Columns.Count)
                {
                    try
                    {
                        GridTicket.Columns.RemoveAt(GridTicket.Columns.Count - 1);
                    }
                    catch (Exception) { }
                }
                flwCounters.Enabled = true;
            }
            if (GridTicket.DataSource != null)
            {
                Filtr();
                if (tabControl1.SelectedTab.Name == "tabDistribute")
                {
                    if (Statcdif.TickTblMain.DefaultView.Count > 0)
                    {
                        this.StatBrPnlEn.Text = "جاري تحميل بيانات العملاء المرتبطة ...";
                        //------------- Customer 360 ------------------------------XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                        List<string> TkSQLlst = new List<string>();
                        List<string> phone1lst = new List<string>();
                        //List<string> phone2lst = new List<string>();
                        List<string> NIDlst = new List<string>();
                        StringBuilder where_ = new StringBuilder();
                        for (int i = 0; i < Statcdif.TickTblMain.DefaultView.Count; i++)
                        {
                            if (Statcdif.TickTblMain.DefaultView[i]["TKSQL"].ToString().Length > 0) { TkSQLlst.Add("'" + Statcdif.TickTblMain.DefaultView[i]["TKSQL"].ToString() + "'"); }
                            if (Statcdif.TickTblMain.DefaultView[i]["TkClPh"].ToString().Length > 0) { phone1lst.Add("'" + Statcdif.TickTblMain.DefaultView[i]["TkClPh"].ToString() + "'"); }
                            //if (Statcdif.TickTblMain.DefaultView[i]["TkClPh1"].ToString().Length > 0) { phone2lst.Add("'" + Statcdif.TickTblMain.DefaultView[i]["TkClPh1"].ToString() + "'"); }
                            if (Statcdif.TickTblMain.DefaultView[i]["TkClNtID"].ToString().Length > 0) { NIDlst.Add("'" + Statcdif.TickTblMain.DefaultView[i]["TkClNtID"].ToString() + "'"); }
                        }
                        if (TkSQLlst.Count > 0) { where_.Append(" (TKSQL NOT in (" + string.Join(", ", TkSQLlst) + "))"); }
                        if (phone1lst.Count > 0) { where_.Append(" AND ((TkClPh in (" + string.Join(", ", phone1lst) + ")"); }
                        //if (phone2lst.Count > 0) { where_.Append(" or TkClPh1 in (" + string.Join(", ", phone2lst) + ")"); }
                        if (NIDlst.Count > 0) { where_.Append(" or TkClNtID in (" + string.Join(", ", NIDlst) + ")"); }
                        if (Statcdif.tik360 != null) { Statcdif.tik360.Rows.Clear(); }
                        Statcdif.tik360 = fn.returntbl("select TkSQL,TkDtStart,TkClNm,TkClPh,TkClPh1,TkClNtID,PrdNm+' \\ '+CompNm 'comp',Tikfolowusr+' \\ '+TikfolowusrTeam 'Folower',CASE WHEN TkClsStatus = 0 THEN 'مفتوحة' ELSE 'مغلقة' END 'TkClsStatus' " +
                            "from All_Tickets where " + where_.ToString() + "))");
                        if (Statcdif.tik360 != null)
                        {
                            if (Statcdif.tik360.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow item in GridTicket.Rows)
                                {
                                    string flterFilter = "";
                                    if (item.Cells["TkClPh"].Value.ToString().Length > 0) { flterFilter += "TkClPh = '" + item.Cells["TkClPh"].Value + "'"; }
                                    if (item.Cells["TkClNtID"].Value.ToString().Length > 0) { flterFilter += " OR TkClNtID = '" + item.Cells["TkClNtID"].Value + "'"; }
                                    Statcdif.tik360.DefaultView.RowFilter = flterFilter;
                                    if (Statcdif.tik360.DefaultView.Count > 0)
                                    {
                                        item.DefaultCellStyle.ForeColor = Color.Blue;
                                        if (Statcdif.tik360.DefaultView[0]["TkClPh"].ToString().Equals(item.Cells["TkClPh"].Value.ToString())) { item.Cells["TkClPh"].Style.BackColor = Color.Yellow; }
                                        if (Statcdif.tik360.DefaultView[0]["TkClNtID"].ToString().Equals(item.Cells["TkClNtID"].Value.ToString())) { item.Cells["TkClNtID"].Style.BackColor = Color.Yellow; }
                                        item.DefaultCellStyle.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                                        item.Tag = Statcdif.tik360.DefaultView[0]["Folower"];
                                    }
                                }
                            }
                        }
                        else
                        {
                            fn.msg("هناك خطأ في الإتصال بقواعد البيانات", "تحميل البيانات", MessageBoxButtons.OK); ;
                        }
                        //------------- Customer 360 -------------------------------XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                        this.StatBrPnlEn.Text = "إجمالي العدد : " + Statcdif.TickTblMain.Rows.Count.ToString();
                    }
                }
            }
            this.GridTicket.SelectionChanged -= new EventHandler(this.GridTicket_SelectionChanged);
            this.GridTicket.SelectionChanged += new EventHandler(this.GridTicket_SelectionChanged);
        }
        private void TikFolow_SizeChanged(object sender, EventArgs e)
        {
            frmAdjust();
            //FlowLayoutPanel2.Size = new Size(this.Width - 200, this.FlowLayoutPanel2.Height);
        }
        private void SerchTxt_TextChanged(object sender, EventArgs e)
        {
            //this.GridTicket.SelectionChanged -= new System.EventHandler(this.GridTicket_SelectionChanged);
            TikDetails.gettikdetlsfrm.Hide();
            Filtr();
            //this.GridTicket.SelectionChanged += new System.EventHandler(this.GridTicket_SelectionChanged);
        }
        private void TxtReopen_TextChanged(object sender, EventArgs e)
        {
            if (txtReopen.Text.Length > 0)
            {
                btnGet.Enabled = true;
                adjustButton("تحميل", Resources.DbGet);
                if (RsultReOpen.dt != null)
                {
                    RsultReOpen.dt.Rows.Clear();
                    GridTicket.DataSource = null;
                }
            }
            else
            {
                btnGet.Enabled = false;
            }

        }
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = trackBar1.Value;
        }
        private void GridTicket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // IF the Clicked Cell is located in the last Column
            if (GridTicket.CurrentCell.ColumnIndex == GridTicket.Columns.Count - 1)
            {
                if (tabControl1.SelectedTab.Name == "tabDistribute")
                {
                    rowDis(GridTicket.CurrentRow.Index, "folowusr");
                }
                else if (tabControl1.SelectedTab.Name == "tabTask")
                {
                    rowDis(GridTicket.CurrentRow.Index, "TaskUserNm");
                }
                int slctCnt = 0;
                for (int i = 0; i < GridTicket.RowCount; i++)
                {
                    if (Convert.ToBoolean(GridTicket.Rows[i].Cells[GridTicket.Columns.Count - 1].Value) == false)
                    {
                        checkAll.BackColor = Color.White;
                        checkAll.ForeColor = Color.Black;
                        checkAll.Text = "اختيار الكل";
                        checkAll.Checked = false;
                        break;
                    }
                    else
                    {
                        slctCnt++;
                    }
                    if (slctCnt == GridTicket.RowCount)
                    {
                        checkAll.Checked = true; checkAll.BackColor = Color.Green;
                        checkAll.ForeColor = Color.Yellow;
                        checkAll.Text = "إلغاء اختيار الكل";
                    }
                }
            }
        }
        private void GridTicket_SelectionChanged(object sender, EventArgs e)
        {
            if (GridTicket.Rows.Count > 0)
            {
                if (GridTicket.CurrentRow != null)
                {
                    if (currntTicket._TkSQL != Convert.ToInt32(GridTicket.CurrentRow.Cells["TkSql"].Value))
                    {
                        if (GridTicket.CurrentRow != null)
                        {
                            this.StatBrPnlAr.Text = Fltrreslt + (GridTicket.CurrentRow.Index + 1) + " / " + Statcdif.TickTblMain.DefaultView.Count.ToString() + "     ";
                            bool bolTikPrifile = frms.FormIsOpen(Application.OpenForms, typeof(TikFolow360));
                            if (GridTicket.CurrentRow.DefaultCellStyle.ForeColor == Color.Blue)
                            {
                                string flterFilter = "";
                                if (GridTicket.CurrentRow.Cells["TkClPh"].Value.ToString().Length > 0) { flterFilter += "TkClPh = '" + GridTicket.CurrentRow.Cells["TkClPh"].Value + "'"; }
                                if (GridTicket.CurrentRow.Cells["TkClNtID"].Value.ToString().Length > 0) { flterFilter += " OR TkClNtID = '" + GridTicket.CurrentRow.Cells["TkClNtID"].Value + "'"; }
                                Statcdif.tik360.DefaultView.RowFilter = flterFilter;
                                if (GridTicket.CurrentRow.Tag != null) { this.StatBrPnlEn.Text = "آخر متابع شكوى للعميل : " + GridTicket.CurrentRow.Tag.ToString() + "   ( " + Statcdif.tik360.DefaultView.Count + " )"; }
                            }
                            else
                            {
                                if (bolTikPrifile) { Statcdif.tik360.DefaultView.RowFilter = "TkClPh = '" + 1 + "'"; }
                                this.StatBrPnlEn.Text = "إجمالي العدد : " + Statcdif.TickTblMain.Rows.Count.ToString();
                            }

                        }

                        ticketCurrent.currentRow(GridTicket);
                        bool bolTikDetails = frms.FormIsOpen(Application.OpenForms, typeof(TikDetails));
                        bool bolTikUpdate = frms.FormIsOpen(Application.OpenForms, typeof(TikUpdate));

                        if (bolTikDetails == true)
                        {
                            ShowResult();
                        }

                        if (bolTikUpdate == true)
                        {
                            ticketCurrent.getupdate();
                        }
                    }
                }
            }
            GC.Collect();
        }
        private void GridTicket_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (GridTicket.DataSource == Statcdif.TickTblMain.DefaultView)
            {
                if (GridTicket.Columns.Count > Statcdif.TickTblMain.Columns.Count)
                {
                    if (e.ColumnIndex == GridTicket.Columns.Count - 1 && e.RowIndex >= 0)
                    {
                        e.PaintBackground(e.CellBounds, true);
                        ControlPaint.DrawCheckBox(e.Graphics, e.CellBounds.X + 1, e.CellBounds.Y + 1,
                            e.CellBounds.Width, e.CellBounds.Height,
                            (bool)e.FormattedValue ? ButtonState.Checked : ButtonState.Normal);
                        e.Handled = true;
                    }
                }
            }
        }
        private void GridTicket_DoubleClick(object sender, EventArgs e)
        {
            if (GridTicket.SelectedRows != null)
            {
                if (frms.FormIsOpen(Application.OpenForms, typeof(TikDetails)) == false)
                {
                    ShowResult();
                    TikDetails.gettikdetlsfrm.MdiParent = WelcomeScreen.ActiveForm;
                    TikDetails.gettikdetlsfrm.WindowState = FormWindowState.Normal;
                    TikDetails.gettikdetlsfrm.Show();
                }
            }
        }
        private void TextDistrSearch_TextChanged(object sender, EventArgs e)
        {
            Filtr();
        }
        private void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Text.Split('-')[2].Trim() == GridTicket.CurrentRow.Cells["TkEmpNm"].Value.ToString()
           && tabControl1.SelectedTab.Name == "tabDistribute")
            {
                WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "برجاء اختيار الموظف أولاً";
                checkAll.Checked = false;
                return;
            }
            else
            {
                if (checkAll.Checked)
                {
                    checkAll.BackColor = Color.Green;
                    checkAll.ForeColor = Color.Yellow;
                    checkAll.Text = "إلغاء اختيار الكل";
                    distributeTbl.Rows.Clear();
                    for (int i = 0; i < GridTicket.Rows.Count; i++)
                    {

                        WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "";
                        //GridTicket.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;

                        GridTicket.Rows[i].Cells[GridTicket.Columns.Count - 1].Value = true;
                        string stat;
                        if (tabControl1.SelectedTab.Name == "tabDistribute")
                        {
                            if (GridTicket.Rows[i].Cells["TkRecieveDt"].Value.ToString().Length > 0)
                            { stat = "false"; }
                            else { stat = "true"; }
                            GridTicket.Rows[i].Tag = GridTicket.Rows[i].Cells["folowusr"].Value;
                            GridTicket.Rows[i].Cells["folowusr"].Value = treeView1.SelectedNode.Text.Split('-')[1].Trim();
                        }
                        else
                        {
                            stat = "true";
                            GridTicket.Rows[i].Tag = GridTicket.Rows[i].Cells["TaskUserNm"].Value;
                            GridTicket.Rows[i].Cells["TaskUserNm"].Value = treeView1.SelectedNode.Text.Split('-')[1].Trim();
                        }
                        distributeTbl.Rows.Add(GridTicket.Rows[i].Cells["TkSQL"].Value, treeView1.SelectedNode.Text.Split('-')[2].Trim(), stat, treeView1.SelectedNode.Text.Split('-')[1].Trim());
                    }
                }
                else if (!checkAll.Checked)
                {
                    checkAll.BackColor = Color.White;
                    checkAll.ForeColor = Color.Black;
                    checkAll.Text = "اختيار الكل";
                    distributeTbl.Rows.Clear();
                    for (int i = 0; i < GridTicket.Rows.Count; i++)
                    {
                        //GridTicket.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        GridTicket.Rows[i].Cells[GridTicket.Columns.Count - 1].Value = false;
                        // Back the leader name in only the datagrid to user point view
                        if (tabControl1.SelectedTab.Name == "tabDistribute")
                        {
                            GridTicket.Rows[i].Cells["folowusr"].Value = GridTicket.Rows[i].Tag;
                        }
                        else
                        {
                            GridTicket.Rows[i].Cells["TaskUserNm"].Value = "";
                        }
                    }
                    GridTicket.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
                }
            }
        }
        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = trackBar2.Value;
        }
        private void chckShowClose_CheckedChanged(object sender, EventArgs e)
        {
            if (chckShowClose.Checked)
            {
                chckShowClose.Text = "إخفاء زر الإغلاق";
                chckShowClose.ForeColor = Color.Black;
                btnCls.Visible = true;
            }
            else
            {
                chckShowClose.Text = "إظهار زر الإغلاق";
                chckShowClose.ForeColor = Color.Green;
                btnCls.Visible = false;
            }
        }
        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.BackColor = Color.White;
            }
        }
        private void TreeView_AfterSelect(object sender, EventArgs e)
        {
            treeView1.SelectedNode.BackColor = Color.LimeGreen;
            Filtr();
        }
        private void RadioLikeEqual_CheckedChanged(object sender, EventArgs e)
        {
            if (Rd_Equal.Checked)
            {
                Rd_strtwith.Checked = false;
                Rd_endwith.Checked = false;
                Rd_contain.Checked = false;

                Rd_strtwith.Enabled = false;
                Rd_endwith.Enabled = false;
                Rd_contain.Enabled = false;
            }
            else if (Rd_Like.Checked)
            {
                Rd_strtwith.Checked = false;
                Rd_endwith.Checked = false;
                Rd_contain.Checked = true;

                Rd_strtwith.Enabled = true;
                Rd_endwith.Enabled = true;
                Rd_contain.Enabled = true;
            }
        }
        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            Filtr();
        }
        private void StatusBar1_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {
            int panelIndex = StatusBar1.Panels.IndexOf(e.StatusBarPanel);
            string flterFilter = "";
            if (GridTicket.CurrentRow.Cells["TkClPh"].Value.ToString().Length > 0) { flterFilter += "TkClPh = '" + GridTicket.CurrentRow.Cells["TkClPh"].Value + "'"; }
            if (GridTicket.CurrentRow.Cells["TkClNtID"].Value.ToString().Length > 0) { flterFilter += " OR TkClNtID = '" + GridTicket.CurrentRow.Cells["TkClNtID"].Value + "'"; }
            if (Statcdif.tik360.Columns.Count >0)
            {
                Statcdif.tik360.DefaultView.RowFilter = flterFilter;
                if (tabControl1.TabPages.Contains(tabDistribute) && panelIndex == 0 && Statcdif.tik360.DefaultView.Count > 0)
                {
                    TikFolow360.getTikFol360frm.MdiParent = WelcomeScreen.ActiveForm;
                    TikFolow360.getTikFol360frm.WindowState = FormWindowState.Normal;
                    TikFolow360.getTikFol360frm.Show();
                }
            }

        }

        #endregion

        #region Void

        private void wdaysCal()
        {
            string FromDate;
            if (rdEventDt.Checked) { FromDate = "TkupSTime"; } else { FromDate = "TkDtStart"; }

            for (int i = 0; i < Statcdif.TickTblMain.Rows.Count; i++)
            {
                this.StatBrPnlEn.Text = "جاري احتساب ايام العمل ..." + (i + 1).ToString() + " من " + Statcdif.TickTblMain.Rows.Count;
                Statcdif.TickTblMain.Rows[i]["Wdays"] = fn.CalDate(Statcdif.TickTblMain.Rows[i][FromDate].ToString(), Statcdif.servrTime);
            }
            this.StatBrPnlEn.Text = "إجمالي العدد : " + Statcdif.TickTblMain.Rows.Count.ToString();
        }
        private void prepareGrid()
        {
            for (int i = 0; i < GridTicket.Columns.Count; i++)
            {
                GridTicket.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            if (GridTicket.Columns[GridTicket.Columns.Count - 1].Name != "توزيع/إستعادة")
            {
                DataGridViewButtonColumn column = new DataGridViewButtonColumn();
                DataGridViewCheckBoxColumn Checkcolumn = new DataGridViewCheckBoxColumn();

                Checkcolumn.Name = "توزيع/إستعادة";
                Checkcolumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                Checkcolumn.FlatStyle = FlatStyle.Popup;
                Checkcolumn.DefaultCellStyle.Font = new Font("Times new Roman", 18, FontStyle.Bold);
                Checkcolumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                Checkcolumn.DefaultCellStyle.ForeColor = Color.Black;

                GridTicket.Columns.Add(Checkcolumn);
                distributeTbl = new DataTable();
                distributeTbl.Columns.Add("SQl");
                distributeTbl.Columns.Add("usrid");
                distributeTbl.Columns.Add("state");
                distributeTbl.Columns.Add("followerNm");
                distributeTbl.Rows.Clear();
                checkAll.Visible = true;
                foreach (DataGridViewRow item in GridTicket.Rows)
                {
                    item.Cells[GridTicket.Columns.Count - 1].Value = false;
                }
            }
            this.GridTicket.CellClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.GridTicket_CellClick);
            this.GridTicket.CellClick += new DataGridViewCellEventHandler(this.GridTicket_CellClick);
            //if (treeView1.SelectedNode.Nodes.Count > 0) { slctdNodestate = true; } else { slctdNodestate = false; }
            slctdNode = treeView1.SelectedNode;
        }
        private void Filtr()
        {
            if (distributeTbl != null) { distributeTbl.Rows.Clear(); }
            this.GridTicket.SelectionChanged -= new EventHandler(this.GridTicket_SelectionChanged);
            FltrStr.Clear();                                                        //Clear Filter string

            textBoxFilter(SerchTxt);                                                //Add string to Filter string if TextBox length > 0

            radioButtonFilter();                                                    //Add string To Filter string from RadioButton if Slected
            if (tabControl1.SelectedTab.Name == "tabDistribute" || tabControl1.SelectedTab.Name == "tabTask")                                 //If Distribute Page has been selected
            {
                treeFilter(slctdNode.Text.Split('-')[2]);                                            //Get team filter string Targeted Node Before selected Tab Page
                if (tabControl1.SelectedTab.Name == "tabTask") { FltrStr.Append(" and TaskUserID = 0"); }
                Statcdif.TickTblMain.DefaultView.RowFilter = FltrStr.ToString();              //Confirm DefaultView For the Tickets Table Filter
                DataTable usrtickets = new DataTable();
                usrtickets = Statcdif.TickTblMain.Copy();                                     //Copy Tickets dataTable

                FltrStr.Clear();                                                     //Clear Filter string Before Filter Users Counters
                treeFilter(treeView1.SelectedNode.Text.Split('-')[2]);               //Get team filter string as current selected Node
                usrtickets.DefaultView.RowFilter = FltrStr.ToString();               //Assign Filter string to the Copied Datatable
                filtercounters(usrtickets);                                          //Assign Counters to RadioButtons Values as the Copied Datatable DefaultView
            }
            else                               //If Distribute Page has been NOT selected
            {

                if (treeView1.SelectedNode != null)
                {
                    treeFilter(treeView1.SelectedNode.Text.Split('-')[2]);
                }
                //Get team filter string as selected Node
                if (FltrStr.ToString().Length > 0)                                   //If String Length > Zero
                {
                    Statcdif.TickTblMain.DefaultView.RowFilter = FltrStr.ToString();          //Filter Datatable
                    filtercounters(Statcdif.TickTblMain);                                     //Assign Counters to RadioButtons Values
                }
                else
                {                                                                     //If String Length Equal Zero
                    Statcdif.TickTblMain.DefaultView.RowFilter = string.Empty;                 //Empty Defaultview Filter
                    filtercounters(Statcdif.TickTblMain);                //Assign Counters to RadioButtons Values as the tickets Datatable DefaultView
                }
            }

            this.StatBrPnlEn.Text = "إجمالي العدد : " + Statcdif.TickTblMain.Rows.Count.ToString();


            if (GridTicket.Rows.Count > 0)
            {
                if (Statcdif.TickTblMain.DefaultView.Count < Statcdif.TickTblMain.Rows.Count)
                {
                    Fltrreslt = "الفلتر يعمل  : ";
                    this.StatBrPnlAr.Icon = Resources.FilterOn;

                    if (SerchTxt.Text.Length > 0)
                    {
                        Fltrreslt += panel4.Tag + "\"" + SerchTxt.Text + "\"" + "     ";
                    }
                }
                else
                {
                    Fltrreslt = "الفلتر لا يعمل : ";
                    this.StatBrPnlAr.Icon = Resources.FilterOff;
                }
                if (GridTicket.CurrentRow == null)
                {
                    GridTicket.Rows[0].Cells[0].Selected = true;
                }
                this.StatBrPnlAr.Text = Fltrreslt + (GridTicket.CurrentRow.Index + 1) + " / " + Statcdif.TickTblMain.DefaultView.Count.ToString() + "     ";
            }
            else if (GridTicket.Rows.Count == 0 && Statcdif.TickTblMain.Rows.Count > 0)
            {
                this.StatBrPnlAr.Text = "الفلتر يعمل     " + panel4.Tag + "\"" + SerchTxt.Text + "\"" + "     ";
                this.StatBrPnlAr.Icon = Resources.FilterOn;
                TikDetails.gettikdetlsfrm.Hide();
            }
            else
            {
                Fltrreslt = "الفلتر لا يعمل : ";
                this.StatBrPnlAr.Icon = Resources.FilterOff;
                this.StatBrPnlAr.Text = "";
            }
            filterUsrCounerTbl();
            Color_();
            this.GridTicket.SelectionChanged -= new EventHandler(this.GridTicket_SelectionChanged);
            this.GridTicket.SelectionChanged += new System.EventHandler(this.GridTicket_SelectionChanged);
        }
        private List<string> listTeam = new List<string>();
        public void MyTeamOnLoad([Optional] bool RegionYes)
        {
            usercountrsTbl.Rows.Clear();
            TreeNode[] TempNode = new TreeNode[0];
            treeView1.Nodes.Clear();
            if (RegionYes == true)
            {
                bolTeamTree = false;
                Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UCatId = 0";
                treeView1.Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[0]["UCatId"].ToString(),
                Statcdif.TreeUsrTbl.DefaultView[0]["UsrMix"].ToString());
                Statcdif.TreeUsrTbl.DefaultView.RowFilter = "(UsrSusp = 0) and (UCatId <> 0 and UCatType = 1)";
                splitContainer1.Panel1Collapsed = false;
                btnTree.Visible = true;
                btnTicket.Visible = true;
                trackBar1.Visible = true;
            }
            else
            {
                bolTeamTree = true;
                // User Level For Master Flag is Match Number 70 in SwitchBoard Table
                if (CurrentUser.UsrLvl.Substring(69, 1) == "A")
                {
                    Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UCatId = 0";
                    treeView1.Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[0]["UCatId"].ToString(),
                    Statcdif.TreeUsrTbl.DefaultView[0]["UsrMix"].ToString());
                    listTeam.Add(CurrentUser.UsrID.ToString());
                }
                else
                {
                    treeView1.Nodes.Add(CurrentUser.UsrCat.ToString(), CurrentUser.UsrCatNm + "-" + CurrentUser.UsrRlNm + "-" + CurrentUser.UsrID.ToString(), 0);
                    listTeam.Add(CurrentUser.UsrID.ToString());
                }

                Statcdif.TreeUsrTbl.DefaultView.RowFilter = "(UsrSusp = 0) and (UCatId <> 0 and UCatType = 0)";
            }


            for (int i = 0; i < Statcdif.TreeUsrTbl.DefaultView.Count; i++)
            {
                TempNode = treeView1.Nodes.Find(Statcdif.TreeUsrTbl.DefaultView[i][2].ToString(), true);
                if (TempNode.Length > 0)
                {
                    TempNode[0].ImageIndex = 2;
                    int gndr;
                    if (Statcdif.TreeUsrTbl.DefaultView[i]["UsrGender"].ToString().Equals("Male", StringComparison.OrdinalIgnoreCase))
                    { gndr = 0; }
                    else { gndr = 1; }
                    TempNode[0].Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[i]["UCatId"].ToString(), Statcdif.TreeUsrTbl.DefaultView[i]["UsrMix"].ToString(), gndr);
                    listTeam.Add(Statcdif.TreeUsrTbl.DefaultView[i][0].ToString());
                    usercountrsTbl.Rows.Add(Statcdif.TreeUsrTbl.DefaultView[i][0].ToString(), Statcdif.TreeUsrTbl.DefaultView[i]["UsrMix"].ToString().Split('-')[0].Trim(), Statcdif.TreeUsrTbl.DefaultView[i]["UsrMix"].ToString().Split('-')[1].Trim(), 0);
                }
            }
            treeView1.SelectedNode = treeView1.Nodes[0];
            CurrentUser.UsrTeam = string.Join(", ", listTeam);
        }
        public string MyTeamOnSelect(int slctdId)
        {
            List<string> UsrStr = new List<string>();
            TreeNode[] TempNode = new TreeNode[0];
            TreeView trvw = new TreeView();
            Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UsrId = " + slctdId;
            trvw.Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[0]["UCatId"].ToString(), Statcdif.TreeUsrTbl.DefaultView[0]["UsrMix"].ToString());
            if (treeView1.SelectedNode.Nodes.Count > 0)
            {
                //if (tabControl1.SelectedTab.Name.Equals("tabDistribute"))
                //{ }
                UsrStr.Add(slctdId.ToString());
            }
            else if (treeView1.SelectedNode.Nodes.Count == 0)
            {
                UsrStr.Add(slctdId.ToString());
            }
            Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UCatId > = " + CurrentUser.UsrCat;
            for (int i = 0; i < Statcdif.TreeUsrTbl.DefaultView.Count; i++)
            {
                TempNode = trvw.Nodes.Find(Statcdif.TreeUsrTbl.DefaultView[i][2].ToString(), true);
                if (TempNode.Length > 0)
                {
                    TempNode[0].Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[i]["UCatId"].ToString(), Statcdif.TreeUsrTbl.DefaultView[i]["UsrMix"].ToString());
                    if (tabControl1.SelectedTab.Name != "tabDistribute" && tabControl1.SelectedTab.Name != "tabTask") { UsrStr.Add(Statcdif.TreeUsrTbl.DefaultView[i][0].ToString()); }
                }
            }
            trvw.Dispose();
            return string.Join(", ", UsrStr);
        }
        private void filtercounters(DataTable tblfilter)
        {
            LblAll.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TkKind) ", String.Empty));
            LblRequest.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TkKind) ", "TkKind = 'طلب'"));
            LabelCompCount.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TkKind) ", "TkKind = 'شكوى'"));
            LblUpdtFollow.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(folowusr)", "[folowusr] = updtusr"));
            LblUpdtColleg.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(updtusr)", "[updtusr] <> folowusr AND UCatLvl >= 3 And UCatLvl <= 5"));
            LblUpdtOthrs.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(updtusr)", "[updtusr] <> folowusr AND UCatLvl < 3 or UCatLvl > 5"));
            LblNoFlwCount.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TkFolw)", "TkFolw = 'False'"));
            LblRecved.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TkRecieveDt)", "TkRecieveDt = '" + (Statcdif.servrTime) + "'"));
            LblFl1.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TkupEvtId)", "TkupEvtId = 902"));
            LblFl2.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TkupEvtId)", "TkupEvtId = 903"));
            LblFl3.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TkupEvtId)", "TkupEvtId = 904"));
            LblRegions.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TaskUserID)", "TaskUserID > 0"));
        }
        DataTable usercountrsTbl = new DataTable();
        private void filterUsrCounerTbl()
        {
            List<int> lstint = new List<int>();
            if (treeView1.SelectedNode.Level == 0)
            {
                usercountrsTbl.DefaultView.RowFilter = string.Empty;
            }
            else if (treeView1.SelectedNode.Nodes.Count > 0)
            {
                for (int i = 0; i < treeView1.SelectedNode.Nodes.Count; i++)
                {
                    lstint.Add(Convert.ToInt32(treeView1.SelectedNode.Nodes[i].Text.ToString().Split('-')[2].Trim()));
                }
                usercountrsTbl.DefaultView.RowFilter = "ID in (" + string.Join(",", lstint) + ")";
            }
            else if (treeView1.SelectedNode.Nodes.Count == 0)
            {
                for (int i = 0; i < treeView1.SelectedNode.Parent.Nodes.Count; i++)
                {
                    lstint.Add(Convert.ToInt32(treeView1.SelectedNode.Parent.Nodes[i].Text.ToString().Split('-')[2].Trim()));
                }
                usercountrsTbl.DefaultView.RowFilter = "ID in (" + string.Join(",", lstint) + ")";
            }
        }
        private void counersGrid()
        {
            dataGridView1.DataSource = usercountrsTbl;
            dataGridView1.Columns["ID"].Visible = false;
            DataTable temptbl = new DataTable();
            temptbl = Statcdif.TickTblMain.Copy();
            for (int i = 0; i < usercountrsTbl.Rows.Count; i++)
            {
                temptbl.DefaultView.RowFilter = "TkEmpNm = " + usercountrsTbl.Rows[i][0];
                int cnt = Convert.ToInt32(temptbl.DefaultView.ToTable().Compute("count(TkRecieveDt)", "TkRecieveDt = '" + (Statcdif.servrTime) + "'"));
                if (cnt > 0)
                {
                    usercountrsTbl.Rows[i]["العدد"] = temptbl.DefaultView.ToTable().Compute("count(TkRecieveDt)", "TkRecieveDt = '" + (Statcdif.servrTime) + "'");
                }
                else
                {
                    usercountrsTbl.Rows[i]["العدد"] = 0;
                }
            }

            temptbl.Dispose();
            GC.Collect();
        }
        private void refereshtbl()
        {
            sqlcmb = new SqlCommandBuilder(da);
            Statcdif.TickTblMain.Rows.Clear();
            try
            {
                this.StatBrPnlEn.Text = "جاري تحميل البيانات ...";
                da.Fill(Statcdif.TickTblMain);
                GridTicket.DataSource = Statcdif.TickTblMain.DefaultView;
                gridadjst(Statcdif.TickTblMain);
                Statcdif.TickTblMain.PrimaryKey = new DataColumn[] { Statcdif.TickTblMain.Columns[0] };
                if (Statcdif.TickTblMain.Rows.Count > 0) { Filtr(); }
            }
            catch (Exception ex)
            {
                function.AppLog(ex.Message + "$" + ex.InnerException, ex.HResult.ToString(), "Referesh Statcdif.TickTblMain");
            }
        }
        private void treeFilter(string teamfilter)
        {
            if (treeView1.SelectedNode != null)
            {
                string team = MyTeamOnSelect(Convert.ToInt32(teamfilter));
                if (team.Length > 0)
                {
                    if (FltrStr.Length > 0) { FltrStr.Append(" and "); };
                    FltrStr.Append("(");
                    FltrStr.Append(" [TkEmpNm] in ( " + team + ")");
                    FltrStr.Append(")");
                }
            }
        }
        private void radioButtonFilter()
        {
            frms frm = new frms();
            IEnumerable<Control> rdlist = frm.GetAll(flwCounters, typeof(RadioButton));
            foreach (RadioButton c in rdlist)
            {
                if (c.Checked == true)
                {
                    if (c.Tag.ToString().Length > 0)
                    {
                        if (FltrStr.Length > 0) { FltrStr.Append(" and "); };
                        FltrStr.Append("(");
                        FltrStr.Append(c.Tag);
                        FltrStr.Append(")");
                    }
                    break;
                }
            }
        }
        private void textBoxFilter(TextBox searchbox)
        {
            string LK = " like ";
            string strt = "'%";
            string end_ = "%'";

            if (searchbox.TextLength > 0)
            {
                if (Rd_strtwith.Checked) { strt = "'"; end_ = "%'"; panel4.Tag = " يبدأ بـ "; }
                else if (Rd_contain.Checked) { strt = "'%"; end_ = "%'"; panel4.Tag = " يحتوي على "; }
                else if (Rd_endwith.Checked) { strt = "'%"; end_ = "'"; panel4.Tag = " ينتهي بـ "; }

                if (Rd_Equal.Checked) { LK = " = "; strt = "'"; end_ = "'"; panel4.Tag = " يساوي "; }
                else if (Rd_Like.Checked) { LK = " Like "; };
                FltrStr.Append("(");
                FltrStr.Append("Convert([TkSQL],System.String)" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or Convert([TkDtStart],System.String)" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or [TkClNm]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or [TkClPh]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or [TkClPh1]" + LK + strt + searchbox.Text + end_);

                for (int i = 0; i < currntTicket.fieldlst.Count; i++)
                {
                    FltrStr.Append(" or Convert([" + currntTicket.fieldlst[i].ToString() + "],System.String)" + LK + strt + searchbox.Text + end_);
                }
                FltrStr.Append(" or [TkClNtID]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or [PrdNm]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or [CompNm]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or [EvNm]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or [TkDetails]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(")");
            }
        }
        private void gridadjst(DataTable tbl)
        {
            currntTicket.fieldlst.Clear();
            if (this.GridTicket.Columns.Count > 0)
            {
                for (int i = 0; i < tbl.Columns.Count; i++)
                {
                    if (function.CheckArlanguage(tbl.Columns[i].ColumnName) != true)
                    {
                        GridTicket.Columns[i].Visible = false;
                    }
                    else
                    {
                        currntTicket.fieldlst.Add(tbl.Columns[i].ColumnName.ToString());
                    }
                }
                GridTicket.Columns["TkSQL"].Visible = true;
                GridTicket.Columns["TkSQL"].HeaderText = "رقم الشكوى";
                GridTicket.Columns["TkKind"].Visible = true;
                GridTicket.Columns["TkKind"].HeaderText = "شكوى/ طلب";
                GridTicket.Columns["TkDtStart"].Visible = true;
                GridTicket.Columns["TkDtStart"].HeaderText = "التاريخ";
                GridTicket.Columns["TkClNm"].Visible = true;
                GridTicket.Columns["TkClNm"].HeaderText = "اسم العميل";
                GridTicket.Columns["TkClPh"].Visible = true;
                GridTicket.Columns["TkClPh"].HeaderText = "تليفون العميل";
                GridTicket.Columns["TkClNtID"].Visible = true;
                GridTicket.Columns["TkClNtID"].HeaderText = "الرقم القومي";
                GridTicket.Columns["PrdNm"].Visible = true;
                GridTicket.Columns["PrdNm"].HeaderText = "اسم الخدمة";
                GridTicket.Columns["CompNm"].Visible = true;
                GridTicket.Columns["CompNm"].HeaderText = "نوع الشكوى";
                GridTicket.Columns["TkupSTime"].Visible = true;
                GridTicket.Columns["folowusr"].HeaderText = "متابع الشكوى";
                GridTicket.Columns["folowusr"].Visible = true;
                GridTicket.Columns["TkupSTime"].HeaderText = "تاريخ آخر تحديث";
                GridTicket.Columns["TkupTxt"].Visible = true;
                GridTicket.Columns["TkupTxt"].HeaderText = "نص آخر تحديث";
                GridTicket.Columns["updtusr"].Visible = true;
                GridTicket.Columns["updtusr"].HeaderText = "محرر آخر تحديث";
                GridTicket.Columns["EvNm"].Visible = true;
                GridTicket.Columns["EvNm"].HeaderText = "نوع آخر تحديث";

                if (tabControl1.SelectedTab.Name != "tabReopen")
                {
                    GridTicket.Columns["Wdays"].Visible = true;
                    GridTicket.Columns["Wdays"].HeaderText = "ايام العمل";
                }
                if (tabControl1.SelectedTab.Name == "tabClosed" && GridTicket.Columns["TkDtClose"] != null)
                {
                    GridTicket.Columns["TkDtClose"].Visible = true;
                    GridTicket.Columns["TkDtClose"].HeaderText = "تاريخ الإغلاق";
                }

                //for (int i = 37; i < GridTicket.Columns.Count; i++)
                //{
                //    GridTicket.Columns[i].Visible = true;
                //}
            }
            GridTicket.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            GridTicket.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void rowDis(int rowindex, string slctdUserNm)
        {
            if (treeView1.SelectedNode.Text.Split('-')[2].Trim() == GridTicket.Rows[rowindex].Cells["TkEmpNm"].Value.ToString()
                && tabControl1.SelectedTab.Name == "tabDistribute")
            {
                WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "               برجاء اختيار الموظف أولاً";
                return;
            }
            else
            {
                if (Convert.ToBoolean(GridTicket.Rows[rowindex].Cells[GridTicket.Columns.Count - 1].Value) == false)
                {
                    WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "";
                    //GridTicket.Rows[rowindex].DefaultCellStyle.BackColor = Color.LimeGreen;

                    GridTicket.Rows[rowindex].Cells[GridTicket.Columns.Count - 1].Value = true;
                    string stat;
                    if (tabControl1.SelectedTab.Name == "tabDistribute")
                    {
                        if (GridTicket.Rows[rowindex].Cells["TkRecieveDt"].Value.ToString().Length > 0)
                        { stat = "false"; }
                        else { stat = "true"; }
                    }
                    else
                    {
                        stat = "true";
                    }
                    distributeTbl.Rows.Add(GridTicket.Rows[rowindex].Cells["TkSQL"].Value, treeView1.SelectedNode.Text.Split('-')[2].Trim(), stat, treeView1.SelectedNode.Text.Split('-')[1].Trim());
                    // Change follower name in only the datagrid to user point view
                    GridTicket.Rows[rowindex].Tag = GridTicket.Rows[rowindex].Cells[slctdUserNm].Value;
                    GridTicket.Rows[rowindex].Cells[slctdUserNm].Value = treeView1.SelectedNode.Text.Split('-')[1].Trim();
                }
                else if (Convert.ToBoolean(GridTicket.Rows[rowindex].Cells[GridTicket.Columns.Count - 1].Value) == true)
                {
                    DataRow DRW = function.DRW(distributeTbl, GridTicket.Rows[rowindex].Cells["TkSQL"].Value, distributeTbl.Columns[0]);
                    distributeTbl.Rows.RemoveAt(distributeTbl.Rows.IndexOf(DRW));
                    //GridTicket.Rows[rowindex].DefaultCellStyle.BackColor = Color.White;
                    GridTicket.Rows[rowindex].Cells[GridTicket.Columns.Count - 1].Value = false;
                    // Back the leader name in only the datagrid to user point view
                    if (tabControl1.SelectedTab.Name == "tabDistribute")
                    {
                        GridTicket.Rows[rowindex].Cells[slctdUserNm].Value = GridTicket.Rows[rowindex].Tag;
                    }
                    else
                    {
                        GridTicket.Rows[rowindex].Cells[slctdUserNm].Value = "";
                    }
                }
            }
        }
        private void adjustButton(string tag, Image img)
        {
            btnGet.Tag = tag;
            btnGet.BackgroundImage = img;
        }
        private void Color_()
        {
            foreach (Control c in flwCounters.Controls)
            {
                if (c.GetType() == typeof(RadioButton))
                {
                    RadioButton RD = (RadioButton)c;
                    if (RD.Checked == true)
                    {
                        RD.BackColor = Color.LimeGreen;
                        RD.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    }
                    else
                    {
                        RD.BackColor = Color.White;
                        RD.Font = new Font("Times new Roman", 10, FontStyle.Regular);
                    }
                }
                else if (c.GetType() == typeof(Label))
                {
                    Label LBL = new Label();
                    LBL = c as Label;
                    if (Convert.ToInt32(LBL.Text) > 0)
                    {
                        LBL.ForeColor = Color.Green;
                        LBL.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    }
                    else
                    {
                        LBL.BackColor = Color.White;
                        LBL.Font = new Font("Times new Roman", 6, FontStyle.Regular);
                    }
                    LBL.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
        }
        private void frmAdjust()
        {
            splitContainer1.Size = new Size(this.Width - 35, this.Height - (FlwtopBar.Height + flwCounters.Height + 115));
            FlwtopBar.Margin = new Padding((this.Width - FlwtopBar.Width) / 2, FlwtopBar.Margin.Top, FlwtopBar.Margin.Right, FlwtopBar.Margin.Bottom);
            flwCounters.Margin = new Padding((this.Width - flwCounters.Width - Panel3.Width) / 2, flwCounters.Margin.Top, flwCounters.Margin.Right, flwCounters.Margin.Bottom);
            trackBar1.Value = splitContainer1.SplitterDistance;
            trackBar2.Value = splitContainer2.SplitterDistance;
        }

        #endregion

        #region Buttons
        private void btnExport_Click(object sender, EventArgs e)
        {
            function fn = function.getfn;
            if (Statcdif.TickTblMain.DefaultView.Count > 0)
            {
                DataTable exporTbl = new DataTable();
                exporTbl = Statcdif.TickTblMain.DefaultView.ToTable();
                List<int> lst = new List<int>();
                for (int i = 0; i < GridTicket.Columns.Count; i++)
                {
                    if (GridTicket.Columns[i].Visible == false && GridTicket.Columns[i].Name != "TkDetails")
                    {
                        lst.Add(i);
                    }
                    else
                    {
                        if (function.CheckArlanguage(exporTbl.Columns[i].ColumnName) == false)
                        {
                            exporTbl.Columns[i].ColumnName = GridTicket.Columns[i].HeaderText;
                        }
                    }
                }
                lst.Reverse();
                for (int i = 0; i < lst.Count; i++)
                {
                    int Index = lst[i];
                    exporTbl.Columns.RemoveAt(Index);
                }
                string Rslt = fn.exportxlsx(exporTbl, CurrentUser.UsrRlNm);
                if (Rslt == null)
                {
                    string Req = Convert.ToString(exporTbl.Compute("count([شكوى/ طلب]) ", "[شكوى/ طلب] = 'طلب'"));
                    string Comp = Convert.ToString(exporTbl.Compute("count([شكوى/ طلب]) ", "[شكوى/ طلب] = 'شكوى'"));

                    string Msg = "";
                    if (Comp != "0")
                    {
                        Msg += Environment.NewLine + Environment.NewLine + Comp + " شكوى";
                    }
                    if (Req != "0")
                    {
                        Msg += Environment.NewLine + Req + " طلب";
                    }

                    fn.msg("تم استخراج عدد " + Msg, "استخراج البيانات", MessageBoxButtons.OK);
                }
                else if (Rslt == "X")
                {
                    fn.msg("لقد قمت بإلغاء استخراج البيانات", "استخراج البيانات", MessageBoxButtons.OK);
                }
                else
                {
                    fn.msg("خطأ في استخراج البيانات", "استخراج البيانات", MessageBoxButtons.OK);
                }
            }
            else
            {
                fn.msg("لاتوجد بيانات للاستخراج", "استخراج البيانات", MessageBoxButtons.OK);
            }
        }
        private void btnTicket_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed == true)
            {
                splitContainer1.Panel2Collapsed = false;
            }
            else if (splitContainer1.Panel2Collapsed != true)
            {
                splitContainer1.Panel2Collapsed = true;
                if (bolTeamLeader == true)
                {
                    btnseting.Visible = true;
                    trackBar2.Visible = true;
                }
            }
        }
        private void btnTree_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed == true)
            {
                splitContainer1.Panel1Collapsed = false;
                if (bolTeamLeader == true)
                {
                    btnseting.Visible = true;
                    trackBar2.Visible = true;
                }
            }
            else if (splitContainer1.Panel1Collapsed != true)
            {
                splitContainer1.Panel1Collapsed = true;
                btnseting.Visible = false;
                trackBar2.Visible = false;
            }
        }
        private void btnDistrebute_Click(object sender, EventArgs e)
        {
            if (distributeTbl.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("سيتم توزيع عدد " + distributeTbl.Rows.Count + Environment.NewLine + "هل تريد الإستمرار؟", "توزيع الشكاوى", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                if (dialogResult == DialogResult.Yes)
                {
                    TikFolow_Team.getTikFolltemfrm.StatBrPnlAr.Text = "  جاري التحويل  .......";
                    TikFolow_Team.getTikFolltemfrm.Refresh();
                    DataTable paramtbl = new DataTable();
                    paramtbl = distributeTbl.Copy();
                    paramtbl.Columns.RemoveAt(3);
                    if (DistributeAndAssignTicket("SP_TICKET_Distribute_NEW", CurrentUser.UsrID, Statcdif._IP, paramtbl) == null)
                    {
                        for (int i = 0; i < distributeTbl.Rows.Count; i++)
                        {
                            // get the datarow to can get row index to change row values of the selected uers
                            DataRow DRW = function.DRW(Statcdif.TickTblMain, distributeTbl.Rows[i]["SQl"], Statcdif.TickTblMain.Columns["TkSQL"]);
                            string EventTxt = "";
                            if (distributeTbl.Rows[i]["state"].ToString() == "true")   // false Mean that Recieved Date is Empty "Mng. Distribute" With ID "2"
                            {
                                EventTxt = "The Complaint has been sent to ";
                                Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["EvNm"] = "Mng. Distribute";
                            }
                            else if (distributeTbl.Rows[i]["state"].ToString() == "false") // true Mean that Recieved Date is Not Empty "Transfered" With ID "100"
                            {
                                EventTxt = "The Complaint has been transfered to ";
                                Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["EvNm"] = "Transfered";
                            }
                            //Assign the selected user values to the datatable to refresh filter
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TkEmpNm"] = distributeTbl.Rows[i]["usrid"];
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["folowusr"] = distributeTbl.Rows[i]["followerNm"];
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TkFolw"] = false;
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TkupSTime"] = Statcdif.servrTime;
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TkupTxt"] = EventTxt + treeView1.SelectedNode.Text.Split('-')[1].Trim();
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TkupUser"] = CurrentUser.UsrID;
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["updtusr"] = CurrentUser.UsrRlNm;
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["UCatLvl"] = CurrentUser.UsrUCatLvl;
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TkRecieveDt"] = DateTime.Parse(Statcdif.servrTime).ToString("yyyy/MM/dd");
                        }
                        Filtr();
                        distributeTbl.Rows.Clear();
                        if (checkAll.Checked)
                        {
                            checkAll.BackColor = Color.Red;
                            checkAll.Text = "اختيار الكل";
                            checkAll.Checked = false;
                            tabControl1.SelectedIndex = 0;
                        }
                        else
                        {
                            //for (int i = 0; i < GridTicket.Rows.Count; i++)
                            //{
                            //    GridTicket.Rows[i].DefaultCellStyle.BackColor = Color.White;
                            //    GridTicket.Rows[i].Cells[GridTicket.Columns.Count - 1].Value = false;
                            //}
                        }
                        counersGrid();
                        fn.msg("Done", "توزيع الشكاوى", MessageBoxButtons.OK);
                    }
                    else
                    {
                        fn.msg("لم يتم توزيع عدد " + distributeTbl.Rows.Count + Environment.NewLine, "توزيع الشكاوى", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                fn.msg("برجاء اختيار الشكاوى للتوزيع", "توزيع الشكاوى", MessageBoxButtons.OK);
            }
        }
        private void BtnToRegion_Click(object sender, EventArgs e)
        {
            if (distributeTbl.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("سيتم إرسال عدد " + distributeTbl.Rows.Count + Environment.NewLine + "هل تريد الإستمرار؟", "إرسال للمناطق", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                if (dialogResult == DialogResult.Yes)
                {
                    DataTable paramtbl = new DataTable();
                    paramtbl = distributeTbl.Copy();
                    paramtbl.Columns.RemoveAt(3);
                    if (DistributeAndAssignTicket("SP_TICKET_TO_REGIONS", CurrentUser.UsrID, Statcdif._IP, paramtbl) == null)
                    {
                        for (int i = 0; i < distributeTbl.Rows.Count; i++)
                        {
                            // get the datarow to can get row index to change row values of the selected uers
                            DataRow DRW = function.DRW(Statcdif.TickTblMain, distributeTbl.Rows[i]["SQl"], Statcdif.TickTblMain.Columns["TkSQL"]);
                            string EventTxt = "";
                            if (distributeTbl.Rows[i]["state"].ToString() == "true")   // false Mean that Recieved Date is Empty "Mng. Distribute" With ID "2"
                            {
                                EventTxt = "The Complaint has been Assigned to ";
                                Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["EvNm"] = "Region Transfer";
                            }
                            else if (distributeTbl.Rows[i]["state"].ToString() == "false") // true Mean that Recieved Date is Not Empty "Transfered" With ID "100"
                            {
                                EventTxt = "The Complaint has been Returned From ";
                                Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["EvNm"] = "Region Return";
                            }
                            //Assign the selected user values to the datatable to refresh filter
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TaskUserID"] = distributeTbl.Rows[i]["usrid"];
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TaskUserNm"] = distributeTbl.Rows[i]["followerNm"];
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TkupSTime"] = Statcdif.servrTime;
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TkupTxt"] = EventTxt + treeView1.SelectedNode.Text.Split('-')[1].Trim();
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["TkupUser"] = CurrentUser.UsrID;
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["updtusr"] = CurrentUser.UsrRlNm;
                            Statcdif.TickTblMain.Rows[Statcdif.TickTblMain.Rows.IndexOf(DRW)]["UCatLvl"] = CurrentUser.UsrUCatLvl;
                        }
                        if (checkAll.Checked == true)
                        {
                            checkAll.BackColor = Color.Red;
                            checkAll.Text = "اختيار الكل";
                            checkAll.Checked = false;
                            tabControl1.SelectedIndex = 0;
                        }
                        else
                        {
                            for (int i = 0; i < GridTicket.Rows.Count; i++)
                            {
                                GridTicket.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                GridTicket.Rows[i].Cells[GridTicket.Columns.Count - 1].Value = false;
                            }
                            //filtbl();
                        }
                        counersGrid();
                        fn.msg("تم توزيع الشكاوى بنجاح", "توزيع الشكاوى", MessageBoxButtons.OK);
                    }
                    else
                    {
                        fn.msg("لم يتم توزيع عدد " + distributeTbl.Rows.Count + Environment.NewLine, "توزيع الشكاوى", MessageBoxButtons.OK);
                    }
                    distributeTbl.Rows.Clear();
                }
            }
            else
            {
                fn.msg("برجاء اختيار الشكاوى للتوزيع", "توزيع الشكاوى", MessageBoxButtons.OK);
            }
        }
        private void btnseting_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel1Collapsed == true)
            {
                splitContainer2.Panel1Collapsed = false;
                btnseting.Text = "غلق الأعداد";
            }
            else
            {
                splitContainer2.Panel1Collapsed = true;
                btnseting.Text = "فتح الأعداد";
            }
        }
        private void BtnReOen_Click(object sender, EventArgs e)
        {
            if (btnGet.Tag.Equals("تحميل"))
            {
                if (GetTicket(" AND TKSQL = " + txtReopen.Text) == null && RsultReOpen.dt.Rows.Count > 0)
                {
                    this.GridTicket.SelectionChanged -= new EventHandler(this.GridTicket_SelectionChanged);
                    GridTicket.DataSource = RsultReOpen.dt;
                    gridadjst(RsultReOpen.dt);

                    //this.GridTicket.SelectionChanged += new EventHandler(this.GridTicket_SelectionChanged);
                    if (listTeam.Contains(RsultReOpen.dt.Rows[0]["TkEmpNm"].ToString()))
                    {
                        if (Convert.ToBoolean(RsultReOpen.dt.Rows[0]["TkClsStatus"]) == true)
                        {
                            adjustButton("فتح", Resources.CpOpen); adjustButton("فتح", Resources.CpOpen);
                        }
                        else
                        {
                            fn.msg("الشكوى مغتوحة بالفعل", "إعادة فتح الشكوى", MessageBoxButtons.YesNo);
                        }
                    }
                    else
                    {
                        fn.msg("لا يمكن فتح الشكوي" + Environment.NewLine + "حيث انها تنتمي لفريق " + RsultReOpen.dt.Rows[0]["TikfolowusrTeam"].ToString().Substring(4, RsultReOpen.dt.Rows[0]["TikfolowusrTeam"].ToString().Length - 4), "إعادة فتح الشكوى", MessageBoxButtons.OK);
                        adjustButton("تحميل", Resources.DbGet);
                    }
                }
                else
                {
                    adjustButton("تحميل", Resources.DbGet);
                    fn.msg("لم يتم العثور على الشكوى" + Environment.NewLine + "من فضلك تأكد من الرقم وأعد المحاولة", "إعادة فتح الشكوى", MessageBoxButtons.OK);
                }
            }
            else if (btnGet.Tag.Equals("فتح"))
            {
                if (ticketCurrent.addevent(Convert.ToInt32(txtReopen.Text), "The Complaint has been Reopened", 999, Statcdif._IP, CurrentUser.UsrID) == null)
                {
                    GridTicket.Visible = false;
                    refereshtbl();
                    adjustButton("تحميل", Resources.DbGet);
                    RsultReOpen.dt.Rows.Clear();
                    GridTicket.DataSource = null;
                    GridTicket.Visible = true;
                    fn.msg("تم فتح الشكوى بنجاح", "إعادة فتح الشكوى", MessageBoxButtons.OK);
                }
            }
        }
        private void btnCls_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(GridTicket.CurrentRow.Cells["TaskUserID"].Value) > 0)
            {
                DataRow DRWRegion = function.DRW(Statcdif.TreeUsrTbl, GridTicket.CurrentRow.Cells["TaskUserID"].Value, Statcdif.TreeUsrTbl.Columns["UsrId"]);
                MessageBox.Show("الشكوى حاليا لدى " + DRWRegion.ItemArray[5] + Environment.NewLine + "يرجى أولاً إستعادة الشكوى", "إغلاق الشكوى", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                return;
            }
            int WDays = fn.CalDate(GridTicket.CurrentRow.Cells["TkDtStart"].Value.ToString(), Statcdif.servrTime);

            DialogResult dialogResult = MessageBox.Show("سيتم إغلاق الشكوى نهائياً " + Environment.NewLine + " في " + WDays.ToString() + " يوم عمل" + Environment.NewLine + "هل تريد الإستمرار؟", "إغلاق الشكوى", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            if (dialogResult == DialogResult.Yes)
            {
                if (ticketCurrent.addevent(Convert.ToInt32(GridTicket.CurrentRow.Cells["TkSQL"].Value), "The Complaint has been closed In " + WDays.ToString() + " Working Days", 900, Statcdif._IP, CurrentUser.UsrID) == null)
                {
                    DataRow DRW = function.DRW(Statcdif.TickTblMain, GridTicket.CurrentRow.Cells["TkSQL"].Value, Statcdif.TickTblMain.Columns["TkSQL"]);
                    Statcdif.TickTblMain.Rows.RemoveAt(Statcdif.TickTblMain.Rows.IndexOf(DRW));
                    Filtr();
                    fn.msg("تم إغلاق الشكوى بنجاح" + " في " + WDays.ToString() + " يوم عمل", "إغلاق الشكوى", MessageBoxButtons.OK);
                }
                else
                {
                    fn.msg("تم إغلاق الشكوى بنجاح", "إغلاق الشكوى", MessageBoxButtons.OK);
                }
            }
        }
        private void BtnRefrsh_Click(object sender, EventArgs e)
        {
            refereshtbl();
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TikFolow_Team_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool bolTikPrifile = frms.FormIsOpen(Application.OpenForms, typeof(TikFolow360));
            if (bolTikPrifile)
            {
                TikFolow360.getTikFol360frm.Close();
            }
        }
        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {
            DataRow DRW = function.DRW(Statcdif.ProdCompTable, GridTicket.CurrentRow.Cells["TkFnPrdCd"].Value, Statcdif.ProdCompTable.Columns[0]);
            DataRow DRW1 = function.DRW(Statcdif.TreeUsrTbl, DRW.ItemArray[8], Statcdif.TreeUsrTbl.Columns[0]);
            string UpdateStr = "Update Tickets set TkEmpNm = " + DRW.ItemArray[8].ToString() + " Where TKSQL = " + Convert.ToInt32(GridTicket.CurrentRow.Cells["TkSQL"].Value);
            string targetTeam = DRW1.ItemArray[5].ToString().Split('-')[1].Trim();

            if (targetTeam != GridTicket.CurrentRow.Cells["TikfolowusrTeam"].Value.ToString().Trim())
            {
                DialogResult dialogResult = MessageBox.Show("سيتم تحويل الشكوى ل" + targetTeam + Environment.NewLine + "هل تريد الإستمرار؟", "تحويل للفريق المختص", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                if (dialogResult == DialogResult.Yes)
                {

                    if (ticketCurrent.addevent(Convert.ToInt32(GridTicket.CurrentRow.Cells["TkSQL"].Value), "The Complaint has been ReAssigned To " + targetTeam, 101, Statcdif._IP, CurrentUser.UsrID, UpdateStr, null, null) == null)
                    {
                        fn.msg("تم تحويل الشكوى للفريق المختص", "تحويل للفريق المختص", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                fn.msg("الشكوي لدى الفريق المختص بالفعل", "تحويل للفريق المختص", MessageBoxButtons.OK);
            }





        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            wdaysCal();
        }

        private void pikerFrom_ValueChanged(object sender, EventArgs e)
        {
            pikerTo.MinDate = Convert.ToDateTime(Convert.ToDateTime("01/01/1753").ToString("yyyy/MM/dd"));
            pikerTo.MaxDate = Convert.ToDateTime(DateTime.Parse("01/12/9998").ToString("yyyy/MM/dd"));
            pikerTo.MinDate = pikerFrom.Value;
            pikerTo.MaxDate = pikerFrom.Value.AddDays(30);
            pikerTo.Value = pikerFrom.Value.AddDays(30);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.GridTicket.SelectionChanged -= new EventHandler(this.GridTicket_SelectionChanged);
            string Any = " and (TkDtClose between  CONVERT(VARCHAR,'" + pikerFrom.Value.ToString("yyyy-MM-dd") + "',111) and CONVERT(datetime, '" + pikerTo.Value.ToString("yyyy-MM-dd") + "',111) + 1 )";
            if (filtbl(1, Any).Rows.Count > 0)
            {
                counersGrid();
                GridTicket.ClearSelection();
                //treeView1.SelectedNode = treeView1.Nodes[0];

            }
            Filtr();
            this.GridTicket.SelectionChanged -= new EventHandler(this.GridTicket_SelectionChanged);
            this.GridTicket.SelectionChanged += new EventHandler(this.GridTicket_SelectionChanged);
        }
    }
}
