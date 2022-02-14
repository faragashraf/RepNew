using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VOCAC.BL;
using VOCAC.Properties;
using static VOCAC.BL.ticketCurrent;

namespace VOCAC.PL
{
    public partial class TikFolow_Team : Form
    {
        [DebuggerDisplay("lstint: {lstint}")]
        BL.ticketCurrent Crnt = new ticketCurrent();
        private static TikFolow_Team frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static TikFolow_Team getTikFolltemfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikFolow_Team();
                    frm.FormClosed += new FormClosedEventHandler(frm_Closed);
                }
                return frm;
            }
        }
        SqlConnection sqlcon = new SqlConnection(Statcdif.strConn);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlCommandBuilder sqlcmb;
        DataTable TickTblMain = new DataTable();
        StringBuilder FltrStr = new StringBuilder();
        string slctdNodetxt;
        bool slctdNodestate = false;
        List<int> lstint = new List<int>();
        DataTable distributeTbl;        //Distribute Table To be filled manually as Grid Row Select Button
        public TikFolow_Team()
        {
            InitializeComponent();
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
            ChckTrnsDy.Tag = "TkRecieveDt = '" + DateTime.Parse(Statcdif.servrTime).ToString("yyyy/MM/dd") + "'";
            ChckRead.Tag = "TkupUnread = 'False'";
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
            this.ChckRead.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckRequest.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckTrnsDy.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckUpdColeg.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckUpdMe.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
            this.ChckUpdOther.CheckedChanged += new System.EventHandler(this.Chckfltr_CheckedChanged);
        }
        function fn = function.getfn;
        private void TikFolow_Load(object sender, EventArgs e)
        {
            frms forms = new frms();
            forms.FrmAllSub(this);
            WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "  جاري تحميل البيانات .......";
            MyTeamOnLoad(CurrentUser.UsrCat, CurrentUser.UsrID);
            if (filtbl().Rows.Count > 0)
            {
                try
                {
                    if (TickTblMain.DefaultView.Count > 0)
                    {
                        if (treeView1.GetNodeCount(true) == 1)
                        {
                            splitContainer1.Panel1Collapsed = true;
                            tabControl1.TabPages.RemoveAt(1);
                            tabControl1.TabPages.RemoveAt(1);
                            button1.Visible = false;
                            button2.Visible = false;
                            trackBar1.Visible = false;
                            this.Text = "متابعة الشكاوى";
                        }
                        gridadjst();
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
            WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "";
        }
        private void gridadjst()
        {
            if (this.GridTicket.Columns.Count > 0)
            {
                for (int i = 0; i < 36; i++)
                {
                    GridTicket.Columns[i].Visible = false;
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


                for (int i = 37; i < GridTicket.Columns.Count; i++)
                {
                    GridTicket.Columns[i].Visible = true;
                }
            }
            GridTicket.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            GridTicket.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void BtnRefrsh_Click(object sender, EventArgs e)
        {
            refereshtbl();
        }
        private void refereshtbl()
        {
            sqlcmb = new SqlCommandBuilder(da);
            TickTblMain.Rows.Clear();
            try
            {
                da.Fill(TickTblMain);
                if (TickTblMain.Rows.Count > 0) { Filtr(); }
                this.StatBrPnlEn.Text = "إجمالي العدد : " + TickTblMain.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                fn.AppLog(this.ToString(), ex.Message, "Referesh TickTblMain");
            }
        }
        private void Filtr()
        {
            this.GridTicket.SelectionChanged -= new EventHandler(this.GridTicket_SelectionChanged);
            FltrStr.Clear();                                                        //Clear Filter string
            if (tabControl1.SelectedTab.Name == "tabDistribute")
            {
                textBoxFilter(textDistrSearch);                                                //Add string to Filter string if TextBox length > 0
            }
            else
            {
                textBoxFilter(SerchTxt);                                                //Add string to Filter string if TextBox length > 0
            }

            radioButtonFilter();                                                    //Add string To Filter string from RadioButton if Slected

            if (tabControl1.SelectedTab.Name != "tabDistribute")                                      //If Distribute Page has been NOT selected
            {
                if (treeView1.SelectedNode != null)
                {
                    treeFilter(treeView1.SelectedNode.Text.Split('-')[2]);
                }
                //Get team filter string as selected Node
                if (FltrStr.ToString().Length > 0)                                   //If String Length > Zero
                {
                    TickTblMain.DefaultView.RowFilter = FltrStr.ToString();          //Filter Datatable
                    filtercounters(TickTblMain);                                     //Assign Counters to RadioButtons Values
                }
                else
                {                                                                     //If String Length Equal Zero
                    TickTblMain.DefaultView.RowFilter = string.Empty;                 //Empty Defaultview Filter
                    filtercounters(TickTblMain.DefaultView.ToTable());                //Assign Counters to RadioButtons Values as the tickets Datatable DefaultView
                }
            }
            else if (tabControl1.SelectedTab.Name == "tabDistribute")                                 //If Distribute Page has been selected
            {
                treeFilter(slctdNodetxt);                                            //Get team filter string Targeted Node Before selected Tab Page
                TickTblMain.DefaultView.RowFilter = FltrStr.ToString();              //Confirm DefaultView For the Tickets Table Filter
                DataTable usrtickets = new DataTable();
                usrtickets = TickTblMain.Copy();                                     //Copy Tickets dataTable

                lstint.Clear();
                for (int i = 0; i < GridTicket.Rows.Count; i++)
                {
                    DataRow DRW = TickTblMain.Rows.Find(Convert.ToInt32(GridTicket.Rows[i].Cells["TkSQL"].Value));
                    int rowinex_ = TickTblMain.Rows.IndexOf(DRW);
                    lstint.Add(rowinex_);
                }
                FltrStr.Clear();                                                     //Clear Filter string
                treeFilter(treeView1.SelectedNode.Text.Split('-')[2]);               //Get team filter string as current selected Node
                usrtickets.DefaultView.RowFilter = FltrStr.ToString();               //Assign Filter string to the Copied Datatable
                filtercounters(usrtickets);                                          //Assign Counters to RadioButtons Values as the Copied Datatable DefaultView
            }
            this.StatBrPnlEn.Text = "إجمالي العدد : " + TickTblMain.Rows.Count.ToString();

            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            if (GridTicket.Rows.Count > 0)
            {
                if (TickTblMain.DefaultView.Count < TickTblMain.Rows.Count)
                {
                    Fltrreslt = "الفلتر يعمل  : ";
                    this.StatBrPnlAr.Icon = Resources.FilterOn;
                    if (tabControl1.SelectedTab.Name == "tabDistribute")
                    {
                        if (textDistrSearch.Text.Length > 0)
                        {
                            Fltrreslt += panel4.Tag + "\"" + textDistrSearch.Text + "\"" + "     ";
                        }
                    }
                    else
                    {
                        if (SerchTxt.Text.Length > 0)
                        {
                            Fltrreslt += panel4.Tag + "\"" + SerchTxt.Text + "\"" + "     ";
                        }
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
                this.StatBrPnlAr.Text = Fltrreslt + (GridTicket.CurrentRow.Index + 1) + " / " + TickTblMain.DefaultView.Count.ToString() + "     ";
            }
            else if (GridTicket.Rows.Count == 0 && TickTblMain.Rows.Count > 0)
            {
                this.StatBrPnlAr.Text = "الفلتر يعمل     " + panel4.Tag + "\"" + SerchTxt.Text + "\"" + "     ";
                this.StatBrPnlAr.Icon = Resources.FilterOn;
                TikDetails.gettikdetlsfrm.Hide();
            }
            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            Color_();
            this.GridTicket.SelectionChanged += new System.EventHandler(this.GridTicket_SelectionChanged);
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
                FltrStr.Append(" or [TkClNm]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or [TkClPh]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or [TkClPh1]" + LK + strt + searchbox.Text + end_);
                int ColCount = 0;
                if (tabControl1.SelectedTab.Name == "tabDistribute") { ColCount = GridTicket.Columns.Count - 1; } else { ColCount = GridTicket.Columns.Count; }
                for (int i = 37; i < ColCount; i++)
                {
                    FltrStr.Append(" or [" + GridTicket.Columns[i].Name.ToString() + "]" + LK + strt + searchbox.Text + end_);
                }
                FltrStr.Append(" or [TkClNtID]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or [PrdNm]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or [CompNm]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or [EvNm]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(" or [TkDetails]" + LK + strt + searchbox.Text + end_);
                FltrStr.Append(")");
            }
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
        private void TikFolow_SizeChanged(object sender, EventArgs e)
        {
            frmAdjust();
            //FlowLayoutPanel2.Size = new Size(this.Width - 200, this.FlowLayoutPanel2.Height);
        }
        private void frmAdjust()
        {
            //GridTicket.Size = new Size(this.Width - treeView1.Width - 50, this.Height - 260);
            //GridTicket.Margin = new Padding((this.Width - treeView1.Width - GridTicket.Width) / 2, GridTicket.Margin.Top, GridTicket.Margin.Right, GridTicket.Margin.Bottom);
            //treeView1.Height = GridTicket.Height;
            splitContainer1.Size = new Size(this.Width - 35, this.Height - (FlwtopBar.Height + flwCounters.Height + 115));
            FlwtopBar.Margin = new Padding((this.Width - FlwtopBar.Width) / 2, FlwtopBar.Margin.Top, FlwtopBar.Margin.Right, FlwtopBar.Margin.Bottom);
            flwCounters.Margin = new Padding((this.Width - flwCounters.Width - Panel3.Width) / 2, flwCounters.Margin.Top, flwCounters.Margin.Right, flwCounters.Margin.Bottom);
            trackBar1.Value = splitContainer1.SplitterDistance;
            trackBar2.Value = splitContainer2.SplitterDistance;
        }
        private void SerchTxt_TextChanged(object sender, EventArgs e)
        {
            this.GridTicket.SelectionChanged -= new System.EventHandler(this.GridTicket_SelectionChanged);
            TikDetails.gettikdetlsfrm.Hide();
            Filtr();
            this.GridTicket.SelectionChanged += new System.EventHandler(this.GridTicket_SelectionChanged);
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string Fltrreslt;
        private void GridTicket_SelectionChanged(object sender, EventArgs e)
        {
            if (GridTicket.Rows.Count > 0)
            {
                if (GridTicket.CurrentRow != null)
                {
                    this.StatBrPnlAr.Text = Fltrreslt + (GridTicket.CurrentRow.Index + 1) + " / " + TickTblMain.DefaultView.Count.ToString() + "     ";
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
            GC.Collect();
        }
        private void ShowResult()
        {
            Crnt.AssignToForm();
            if (checkBox1.Checked) { TikDetails.gettikdetlsfrm.BringToFront(); };
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
        private void Chckfltr_CheckedChanged(object sender, EventArgs e)
        {
            Filtr();
        }
        private DataTable filtbl()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
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
                GridTicket.DataSource = TickTblMain.DefaultView;
                TickTblMain.PrimaryKey = new DataColumn[] { TickTblMain.Columns[0] };
            }
            catch (Exception ex)
            {
                fn.msg("هناك خطأ في الإتصال بقواعد البيانات" + Environment.NewLine + ex.Message, "متابعة الشكاوى", MessageBoxButtons.OK);
            }
            DAL.Close();
            return TickTblMain;
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
        private List<string> listTeam = new List<string>();
        DataTable usercountrsTbl = new DataTable();
        public void MyTeamOnLoad(int LedrCat, int LedrId, bool Stat = false)
        {
            TreeNode[] TempNode = new TreeNode[0];
            usercountrsTbl.Columns.Add("ID");
            usercountrsTbl.Columns.Add("Team");
            usercountrsTbl.Columns.Add("الاسم");
            usercountrsTbl.Columns.Add("العدد");
            if (CurrentUser.UsrLvl.Substring(16, 1) == "A")
            {
                Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UCatId = 0";
                treeView1.Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[0]["UCatId"].ToString(),
                Statcdif.TreeUsrTbl.DefaultView[0]["UsrMix"].ToString());
                listTeam.Add(CurrentUser.UsrID.ToString());
            }
            else
            {
                treeView1.Nodes.Add(LedrCat.ToString(), CurrentUser.UsrCatNm + "-" + CurrentUser.UsrRlNm + "-" + LedrId.ToString(), 0);
                listTeam.Add(CurrentUser.UsrID.ToString());
            }
            if (Stat == false)
            {
                Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UCatId <> 0";
            }
            //Statcdif.TreeUsrTbl.DefaultView.RowFilter = string.Empty; // "UCatIdSub >= " + CurrentUser.UsrUCatLvl;
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
            CurrentUser.UsrTeam = string.Join(", ", listTeam);
        }
        private void counersGrid()
        {
            dataGridView1.DataSource = usercountrsTbl;
            dataGridView1.Columns["ID"].Visible = false;
            DataTable temptbl = new DataTable();
            temptbl = TickTblMain.Copy();
            for (int i = 0; i < usercountrsTbl.Rows.Count; i++)
            {
                temptbl.DefaultView.RowFilter = "TkEmpNm = " + usercountrsTbl.Rows[i][0];
                int cnt = Convert.ToInt32(temptbl.DefaultView.ToTable().Compute("count(TkRecieveDt)", "TkRecieveDt = '" + DateTime.Parse(Statcdif.servrTime).ToString("yyyy/MM/dd") + "'"));
                if (cnt > 0)
                {
                    usercountrsTbl.Rows[i]["العدد"] = Convert.ToString(temptbl.DefaultView.ToTable().Compute("count(TkRecieveDt)", "TkRecieveDt = '" + DateTime.Parse(Statcdif.servrTime).ToString("yyyy/MM/dd") + "'"));
                }
                else
                {
                    usercountrsTbl.Rows[i]["العدد"] = "";
                }
            }
            temptbl.Dispose();
            GC.Collect();
        }
        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.BackColor = Color.White;
                TreeNode TempNode = new TreeNode();
                TempNode = treeView1.SelectedNode;
                while (TempNode != null)
                {
                    TempNode.Collapse(false);
                    TempNode = TempNode.Parent;
                }
            }
        }
        private void TreeView_AfterSelect(object sender, EventArgs e)
        {
            treeView1.SelectedNode.BackColor = Color.LimeGreen;
            treeView1.SelectedNode.Expand();
            Filtr();
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
                    if (tabControl1.SelectedTab.Name != "tabDistribute") { UsrStr.Add(Statcdif.TreeUsrTbl.DefaultView[i][0].ToString()); }
                }
            }
            trvw.Dispose();
            return string.Join(", ", UsrStr);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            function fn = function.getfn;
            if (TickTblMain.DefaultView.Count > 0)
            {
                DataTable exporTbl = new DataTable();
                exporTbl = TickTblMain.DefaultView.ToTable();
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
                    fn.msg("تم استخراج البيانات بنجاح", "استخراج البيانات", MessageBoxButtons.OK);
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
        private void Button1_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed == true)
            {
                splitContainer1.Panel1Collapsed = false;
                button1.Text = "غلق الشجرة";
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
                button1.Text = "فتح الشجرة";
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed == true)
            {
                splitContainer1.Panel2Collapsed = false;
                button2.Text = "غلق الشكاوى";
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
                button2.Text = "فتح الشكاوى";
            }
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridTicket.SelectionChanged -= new EventHandler(this.GridTicket_SelectionChanged);
            if (GridTicket.DataSource != TickTblMain.DefaultView)
            {
                txtReopen.Text = "";
                GridTicket.DataSource = TickTblMain.DefaultView;
                gridadjst();
            }
            // Reopen tree if current user is team leader and tree is closed
            if ((treeView1.GetNodeCount(true) > 1 && splitContainer1.Panel1Collapsed == true) || CurrentUser.UsrLvl.Substring(16, 1) == "A")
            {
                splitContainer1.Panel1Collapsed = false;
            }

            if (tabControl1.SelectedTab.Name == "tabDistribute")
            {
                for (int i = 0; i < GridTicket.Columns.Count; i++)
                {
                    GridTicket.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                DataGridViewButtonColumn column = new DataGridViewButtonColumn();

                column.Name = "توزيع/إستعادة";
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Popup;
                column.Text = "توزيع";
                column.DefaultCellStyle.ForeColor = Color.Black;
                column.UseColumnTextForButtonValue = true;
                GridTicket.Columns.Add(column);
                distributeTbl = new DataTable();
                distributeTbl.Columns.Add("SQl");
                distributeTbl.Columns.Add("usrid");
                distributeTbl.Columns.Add("state");
                distributeTbl.Columns.Add("followerNm");
                distributeTbl.Rows.Clear();

                this.GridTicket.CellClick += new DataGridViewCellEventHandler(this.GridTicket_CellClick);
                if (treeView1.SelectedNode.Nodes.Count > 0) { slctdNodestate = true; } else { slctdNodestate = false; }
                slctdNodetxt = treeView1.SelectedNode.Text.Split('-')[2];
                flwCounters.Enabled = false;
                SerchTxt.Text = "";
            }
            else if (tabControl1.SelectedTab.Name == "tabReopen")
            {
                GridTicket.DataSource = null;
                splitContainer1.Panel1Collapsed = true;         // Close tree if tree is Opened
                if (GridTicket.Columns.Count == 1) { GridTicket.Columns.RemoveAt(0); }
                SerchTxt.Text = "";
                textDistrSearch.Text = "";
            }
            else
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    flowSearch.Visible = true;
                }
                for (int i = 0; i < GridTicket.Columns.Count; i++)
                {
                    GridTicket.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                }
                this.GridTicket.CellClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.GridTicket_CellClick);
                if (GridTicket.Columns.Count > TickTblMain.Columns.Count)
                {
                    try
                    {
                        GridTicket.Columns.RemoveAt(GridTicket.Columns.Count - 1);
                    }
                    catch (Exception){}
                }
                flwCounters.Enabled = true;
                textDistrSearch.Text = "";
            }
            if (GridTicket.DataSource != null)
            {
                Filtr();
            }
            this.GridTicket.SelectionChanged += new EventHandler(this.GridTicket_SelectionChanged);
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
            LblRecved.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TkRecieveDt)", "TkRecieveDt = '" + DateTime.Parse(Statcdif.servrTime).ToString("yyyy/MM/dd") + "'"));
            LblUnReadCount.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TkupUnread)", "TkupUnread = 'False'"));
            LblFl1.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TkupEvtId)", "TkupEvtId = 902"));
            LblFl2.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TkupEvtId)", "TkupEvtId = 903"));
            LblFl3.Text = Convert.ToString(tblfilter.DefaultView.ToTable().Compute("count(TkupEvtId)", "TkupEvtId = 904"));
        }
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = trackBar1.Value;
        }
        private void GridTicket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridTicket.CurrentCell.ColumnIndex == GridTicket.Columns.Count - 1)
            {
                //DataGridViewButtonColumn column_ = new DataGridViewButtonColumn();
                //column_ = (DataGridViewButtonColumn)GridTicket.Columns[GridTicket.CurrentCell.ColumnIndex];
                //column_.UseColumnTextForButtonValue = false;
                rowDis(GridTicket.CurrentRow.Index);
                //if (GridTicket.CurrentRow.DefaultCellStyle.BackColor != Color.LimeGreen)
                //{
                //    if (treeView1.SelectedNode.Text.Split('-')[2].Trim() != GridTicket.CurrentRow.Cells["TkEmpNm"].Value.ToString())
                //    {
                //        WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "";
                //        GridTicket.CurrentRow.DefaultCellStyle.BackColor = Color.LimeGreen;

                //        GridTicket.CurrentRow.Cells[GridTicket.CurrentCell.ColumnIndex].Value = "استعاده";
                //        string stat;
                //        if (GridTicket.CurrentRow.Cells["TkRecieveDt"].Value.ToString().Length > 0)
                //        { stat = "false"; }
                //        else { stat = "true"; }
                //        distributeTbl.Rows.Add(GridTicket.CurrentRow.Cells["TkSQL"].Value, treeView1.SelectedNode.Text.Split('-')[2].Trim(), stat, treeView1.SelectedNode.Text.Split('-')[1].Trim());
                //        // Change follower name in only the datagrid to user point view
                //        GridTicket.CurrentRow.Cells["folowusr"].Value = treeView1.SelectedNode.Text.Split('-')[1].Trim();
                //    }
                //    else
                //    {
                //        WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "               برجاء اختيار الموظف أولاً";
                //    }
                //}
                //else if (GridTicket.CurrentRow.DefaultCellStyle.BackColor == Color.LimeGreen)
                //{

                //    DataRow DRW = function.DRW(distributeTbl, GridTicket.CurrentRow.Cells["TkSQL"].Value, distributeTbl.Columns[0]);
                //    distributeTbl.Rows.RemoveAt(distributeTbl.Rows.IndexOf(DRW));
                //    GridTicket.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                //    GridTicket.CurrentRow.Cells[GridTicket.CurrentCell.ColumnIndex].Value = "توزيع";
                //    // Back the leader name in only the datagrid to user point view
                //    GridTicket.CurrentRow.Cells["folowusr"].Value = CurrentUser.UsrRlNm;
                //}
            }

        }
        private void rowDis(int rowindex)
        {
            DataGridViewButtonColumn column_ = new DataGridViewButtonColumn();
            column_ = (DataGridViewButtonColumn)GridTicket.Columns[GridTicket.Columns.Count - 1];
            column_.UseColumnTextForButtonValue = false;
            if (GridTicket.Rows[rowindex].DefaultCellStyle.BackColor != Color.LimeGreen)
            {
                if (treeView1.SelectedNode.Text.Split('-')[2].Trim() != GridTicket.Rows[rowindex].Cells["TkEmpNm"].Value.ToString())
                {
                    WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "";
                    GridTicket.Rows[rowindex].DefaultCellStyle.BackColor = Color.LimeGreen;

                    GridTicket.Rows[rowindex].Cells[GridTicket.Columns.Count - 1].Value = "استعاده";
                    string stat;
                    if (GridTicket.Rows[rowindex].Cells["TkRecieveDt"].Value.ToString().Length > 0)
                    { stat = "false"; }
                    else { stat = "true"; }
                    distributeTbl.Rows.Add(GridTicket.Rows[rowindex].Cells["TkSQL"].Value, treeView1.SelectedNode.Text.Split('-')[2].Trim(), stat, treeView1.SelectedNode.Text.Split('-')[1].Trim());
                    // Change follower name in only the datagrid to user point view
                    GridTicket.Rows[rowindex].Tag = GridTicket.Rows[rowindex].Cells["folowusr"].Value;
                    GridTicket.Rows[rowindex].Cells["folowusr"].Value = treeView1.SelectedNode.Text.Split('-')[1].Trim();
                }
                else
                {
                    WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "               برجاء اختيار الموظف أولاً";
                }
            }
            else if (GridTicket.Rows[rowindex].DefaultCellStyle.BackColor == Color.LimeGreen)
            {
                DataRow DRW = function.DRW(distributeTbl, GridTicket.Rows[rowindex].Cells["TkSQL"].Value, distributeTbl.Columns[0]);
                distributeTbl.Rows.RemoveAt(distributeTbl.Rows.IndexOf(DRW));
                GridTicket.Rows[rowindex].DefaultCellStyle.BackColor = Color.White;
                GridTicket.Rows[rowindex].Cells[GridTicket.Columns.Count - 1].Value = "توزيع";
                // Back the leader name in only the datagrid to user point view
                GridTicket.Rows[rowindex].Cells["folowusr"].Value = GridTicket.Rows[rowindex].Tag;
            }
        }
        private void btnDistrebute_Click(object sender, EventArgs e)
        {
            if (distributeTbl.Rows.Count > 0)
            {

                DialogResult dialogResult = MessageBox.Show("سيتم توزيع عدد " + distributeTbl.Rows.Count + Environment.NewLine + "هل تريد الإستمرار؟", "توزيع الشكاوى", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                if (dialogResult == DialogResult.Yes)
                {
                    DataTable paramtbl = new DataTable();
                    paramtbl = distributeTbl.Copy();
                    paramtbl.Columns.RemoveAt(3);
                    if (DistributeTicket(CurrentUser.UsrID, Statcdif._IP, paramtbl) == null)
                    {
                        for (int i = 0; i < distributeTbl.Rows.Count; i++)
                        {
                            // get the datarow to can get row index to change row values of the selected uers
                            DataRow DRW = function.DRW(TickTblMain, distributeTbl.Rows[i]["SQl"], TickTblMain.Columns["TkSQL"]);
                            string EventTxt = "";
                            if (distributeTbl.Rows[i]["state"].ToString() == "true")   // false Mean that Recieved Date is Empty "Mng. Distribute" With ID "2"
                            {
                                EventTxt = "The Complaint has been sent to ";
                                TickTblMain.Rows[TickTblMain.Rows.IndexOf(DRW)]["EvNm"] = "Mng. Distribute";
                            }
                            else if (distributeTbl.Rows[i]["state"].ToString() == "false") // true Mean that Recieved Date is Not Empty "Transfered" With ID "100"
                            {
                                EventTxt = "The Complaint has been transfered to ";
                                TickTblMain.Rows[TickTblMain.Rows.IndexOf(DRW)]["EvNm"] = "Transfered";
                            }
                            //Assign the selected user values to the datatable to refresh filter
                            TickTblMain.Rows[TickTblMain.Rows.IndexOf(DRW)]["TkEmpNm"] = distributeTbl.Rows[i]["usrid"];
                            TickTblMain.Rows[TickTblMain.Rows.IndexOf(DRW)]["folowusr"] = distributeTbl.Rows[i]["followerNm"];
                            TickTblMain.Rows[TickTblMain.Rows.IndexOf(DRW)]["TkFolw"] = false;
                            TickTblMain.Rows[TickTblMain.Rows.IndexOf(DRW)]["TkupSTime"] = Statcdif.servrTime;
                            TickTblMain.Rows[TickTblMain.Rows.IndexOf(DRW)]["TkupTxt"] = EventTxt + treeView1.SelectedNode.Text.Split('-')[1].Trim();
                            TickTblMain.Rows[TickTblMain.Rows.IndexOf(DRW)]["TkupUser"] = CurrentUser.UsrID;
                            TickTblMain.Rows[TickTblMain.Rows.IndexOf(DRW)]["updtusr"] = CurrentUser.UsrRlNm;
                            TickTblMain.Rows[TickTblMain.Rows.IndexOf(DRW)]["UCatLvl"] = CurrentUser.UsrUCatLvl;
                            TickTblMain.Rows[TickTblMain.Rows.IndexOf(DRW)]["TkRecieveDt"] = DateTime.Parse(Statcdif.servrTime).ToString("yyyy/MM/dd");
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
                            filtbl();
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
            distributeTbl.Rows.Clear();
        }
        private String DistributeTicket(int EmpNm, string IP, DataTable FIELDTABL)
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
            DAL.DataAccessLayer.rturnStruct RsultPopulateChoice = DAL.ExcuteCommand("SP_TICKET_Distribute_NEW", param);
            DAL.Close();
            return RsultPopulateChoice.msg;
        }
        DAL.DataAccessLayer.rturnStruct RsultReOpen;
        private String GetTicket(string SQLID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TicketID", SqlDbType.NVarChar);
            param[0].Value = SQLID;
            //param[1] = new SqlParameter("@STATUS_", SqlDbType.Bit);
            //param[1].Value = 1;
            RsultReOpen = DAL.SelectData("SP_TICKETS_SLCT", param);
            DAL.Close();
            return RsultReOpen.msg;
        }
        private void BtnReOen_Click(object sender, EventArgs e)
        {
            if (btnGet.Tag.Equals("تحميل"))
            {
                if (GetTicket(txtReopen.Text) == null && RsultReOpen.dt.Rows.Count > 0)
                {
                    GridTicket.DataSource = RsultReOpen.dt;
                    gridadjst();
                    if (listTeam.Contains(RsultReOpen.dt.Rows[0]["TkEmpNm"].ToString()))
                    {
                        bool ll = Convert.ToBoolean(RsultReOpen.dt.Rows[0]["TkClsStatus"]);
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
                if (ticketCurrent.addevent(Convert.ToInt32(txtReopen.Text), "The Complaint has been Reopened", true, 999, Statcdif._IP, CurrentUser.UsrID) == null)
                {
                    refereshtbl();
                    adjustButton("تحميل", Resources.DbGet);
                    fn.msg("تم فتح الشكوى بنجاح", "إعادة فتح الشكوى", MessageBoxButtons.OK);
                    RsultReOpen.dt.Rows.Clear();
                    GridTicket.DataSource = null;
                }
            }
        }
        private void adjustButton(string tag, Image img)
        {
            btnGet.Tag = tag;
            btnGet.BackgroundImage = img;
        }
        private void TxtReopen_TextChanged(object sender, EventArgs e)
        {
            adjustButton("تحميل", Resources.DbGet);
            if (RsultReOpen.dt != null)
            {
                RsultReOpen.dt.Rows.Clear();
                GridTicket.DataSource = null;
            }
        }
        private void TextDistrSearch_TextChanged(object sender, EventArgs e)
        {
            Filtr();
        }
        private void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAll.Checked)
            {
                checkAll.BackColor = Color.Green;
                checkAll.Text = "إلغاء اختيار الكل";
            }
            else if (!checkAll.Checked)
            {
                checkAll.BackColor = Color.Red;
                checkAll.Text = "اختيار الكل";
            }
            for (int i = 0; i < GridTicket.Rows.Count; i++)
            {
                rowDis(i);
            }
        }
        private void GridTicket_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = trackBar2.Value;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel1Collapsed == true)
            {
                splitContainer2.Panel1Collapsed = false;
                button3.Text = "غلق الأعداد";
            }
            else
            {
                splitContainer2.Panel1Collapsed = true;
                button3.Text = "فتح الأعداد";
            }
        }
    }
}
