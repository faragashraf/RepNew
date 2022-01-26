using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VOCAC.BL;
using VOCAC.Properties;

namespace VOCAC.PL
{
    public partial class TikFolow_Team : Form
    {
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
        public TikFolow_Team()
        {
            InitializeComponent();
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
        defintions Def = new defintions();
        private void TikFolow_Load(object sender, EventArgs e)
        {
            frms forms = new frms();
            forms.FrmAllSub(this);
            WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "  جاري تحميل البيانات .......";
            MyTeam(CurrentUser.UsrCat, CurrentUser.UsrID);
            if (filtbl().Rows.Count > 0)
            {
                try
                {
                    if (TickTblMain.DefaultView.Count > 0)
                    {
                        gridadjst();
                        Filtr();
                        assignfltrTXTintoCtrlTag();
                        this.GridTicket.SelectionChanged += new System.EventHandler(this.GridTicket_SelectionChanged);
                       treeView1.AfterSelect += new TreeViewEventHandler(TreeTeam_select);
                    }
                }
                catch (Exception ex)
                {
                    fn.msg("هناك خطأ في الإتصال بقواعد البيانات" + Environment.NewLine + ex.Message, "متابعة الشكاوى");
                }
            }
            else
            {
                fn.msg("لا توجد شكاوى للمتابعة", "متابعة الشكاوى");
                flowLayoutPanel3.Visible = false;
            }
            frmAdjust();
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
            sqlcmb = new SqlCommandBuilder(da);
            TickTblMain.Rows.Clear();
            da.Fill(TickTblMain);
            if (TickTblMain.Rows.Count > 0) { Filtr(); }
            this.StatBrPnlEn.Text = "إجمالي العدد : " + TickTblMain.Rows.Count.ToString();
        }
        private void Filtr()
        {
            StringBuilder FltrStr = new StringBuilder();
            string LK = " like ";
            string strt = "'%";
            string end_ = "%'";

            if (SerchTxt.TextLength > 0)
            {
                if (Rd_strtwith.Checked) { strt = "'"; end_ = "%'"; }
                else if (Rd_contain.Checked) { strt = "'%"; end_ = "%'"; }
                else if (Rd_endwith.Checked) { strt = "'%"; end_ = "'"; }

                if (Rd_Equal.Checked) { LK = " = "; strt = "'"; end_ = "'"; }
                else if (Rd_Like.Checked) { LK = " Like "; };
                FltrStr.Append("(");
                FltrStr.Append("Convert([TkSQL],System.String)" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkClNm]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkClPh]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkClPh1]" + LK + strt + SerchTxt.Text + end_);
                for (int i = 37; i < GridTicket.Columns.Count; i++)
                {
                    FltrStr.Append(" or [" + GridTicket.Columns[i].Name.ToString() + "]" + LK + strt + SerchTxt.Text + end_);
                }
                FltrStr.Append(" or [TkClNtID]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [PrdNm]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [CompNm]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [EvNm]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkDetails]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(")");
            }

            foreach (Control c in flowLayoutPanel3.Controls)
            {
                if (c.GetType() == typeof(RadioButton))
                {
                    RadioButton RD = (RadioButton)c;
                    if (RD.Checked == true)
                    {
                        if (RD.Tag.ToString().Length > 0)
                        {
                            if (FltrStr.Length > 0) { FltrStr.Append(" and "); };
                            FltrStr.Append("(");
                            FltrStr.Append(RD.Tag);
                            FltrStr.Append(")");
                        }
                        break;
                    }
                }
            }

            if (treeView1.SelectedNode != null)
            {
                if (FltrStr.Length > 0) { FltrStr.Append(" and "); };
                FltrStr.Append("(");
                FltrStr.Append(" [TkEmpNm] in ( " + MyTeam(Convert.ToInt32(treeView1.SelectedNode.Text.Split('-')[2])) + ")");
                FltrStr.Append(")");
            }

            if (FltrStr.ToString().Length > 2)
            {
                TickTblMain.DefaultView.RowFilter = FltrStr.ToString();
            }
            else
            {
                TickTblMain.DefaultView.RowFilter = string.Empty;
            }
            this.StatBrPnlEn.Text = "إجمالي العدد : " + TickTblMain.Rows.Count.ToString();

            LblAll.Text = Convert.ToString(TickTblMain.Compute("count(TkKind) ", String.Empty));
            LblRequest.Text = Convert.ToString(TickTblMain.Compute("count(TkKind) ", "TkKind = 'طلب'"));
            LabelCompCount.Text = Convert.ToString(TickTblMain.Compute("count(TkKind) ", "TkKind = 'شكوى'"));
            LblUpdtFollow.Text = Convert.ToString(TickTblMain.Compute("count(folowusr)", "[folowusr] = updtusr"));
            LblUpdtColleg.Text = Convert.ToString(TickTblMain.Compute("count(updtusr)", "[updtusr] <> folowusr AND UCatLvl >= 3 And UCatLvl <= 5"));
            LblUpdtOthrs.Text = Convert.ToString(TickTblMain.Compute("count(updtusr)", "[updtusr] <> folowusr AND UCatLvl < 3 or UCatLvl > 5"));
            LblNoFlwCount.Text = Convert.ToString(TickTblMain.Compute("count(TkFolw)", "TkFolw = 'False'"));
            LblRecved.Text = Convert.ToString(TickTblMain.Compute("count(TkRecieveDt)", "TkRecieveDt = '" + DateTime.Parse(Statcdif.servrTime).ToString("yyyy/MM/dd") + "'"));
            LblUnReadCount.Text = Convert.ToString(TickTblMain.Compute("count(TkupUnread)", "TkupUnread = 'False'"));
            LblFl1.Text = Convert.ToString(TickTblMain.Compute("count(TkupEvtId)", "TkupEvtId = 902"));
            LblFl2.Text = Convert.ToString(TickTblMain.Compute("count(TkupEvtId)", "TkupEvtId = 903"));
            LblFl3.Text = Convert.ToString(TickTblMain.Compute("count(TkupEvtId)", "TkupEvtId = 904"));
            Color_();


            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            if (GridTicket.Rows.Count > 0)
            {
                if (TickTblMain.DefaultView.Count < TickTblMain.Rows.Count)
                {
                    Fltrreslt = "الفلتر يعمل  : ";
                    this.StatBrPnlAr.Icon = Resources.FilterOn;
                }
                else
                {
                    Fltrreslt = "الفلتر لا يعمل : ";
                    this.StatBrPnlAr.Icon = Resources.FilterOff;
                }
                this.StatBrPnlAr.Text = Fltrreslt + (GridTicket.CurrentRow.Index + 1) + " / " + TickTblMain.DefaultView.Count.ToString() + "     ";
            }
            else if (GridTicket.Rows.Count == 0 && TickTblMain.Rows.Count > 0)
            {
                this.StatBrPnlAr.Text = "الفلتر يعمل     ";
                this.StatBrPnlAr.Icon = Resources.FilterOn;
                TikDetails.gettikdetlsfrm.Hide();
            }
            //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        }
        private void Color_()
        {
            foreach (Control c in flowLayoutPanel3.Controls)
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
            GridTicket.Size = new Size(this.Width - treeView1.Width - 50, this.Height - 260);
            GridTicket.Margin = new Padding((this.Width - treeView1.Width - GridTicket.Width) / 2, GridTicket.Margin.Top, GridTicket.Margin.Right, GridTicket.Margin.Bottom);
            treeView1.Height = GridTicket.Height;
           
            FlowLayoutPanel2.Margin = new Padding((this.Width - FlowLayoutPanel2.Width) / 2, FlowLayoutPanel2.Margin.Top, FlowLayoutPanel2.Margin.Right, FlowLayoutPanel2.Margin.Bottom);
            flowLayoutPanel3.Margin = new Padding((this.Width - flowLayoutPanel3.Width) / 2, flowLayoutPanel3.Margin.Top, flowLayoutPanel3.Margin.Right, flowLayoutPanel3.Margin.Bottom);
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
                if (frms.FormIsOpen(Application.OpenForms, typeof(TikDetails)) == true)
                {
                    ShowResult();
                    GC.Collect();
                }
            }
        }
        private void ShowResult()
        {
            ticketCurrent.currentRow(GridTicket);
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
            }
            catch (Exception ex)
            {
                fn.msg("هناك خطأ في الإتصال بقواعد البيانات" + Environment.NewLine + ex.Message, "متابعة الشكاوى");
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
        public void MyTeam(int LedrCat, int LedrId,  bool Stat = false)
        {
            List<string> UsrStr = new List<string>();
            TreeNode[] TempNode = new TreeNode[0];

            if(CurrentUser.UsrLvl.Substring(16,1) == "A")
            {
                Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UCatId = 0";
                treeView1.Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[0]["UCatId"].ToString(),
                    Statcdif.TreeUsrTbl.DefaultView[0]["UsrMix"].ToString());
                UsrStr.Add(CurrentUser.UsrID.ToString());
            }
            else
            {
                treeView1.Nodes.Add(LedrCat.ToString(), CurrentUser.UsrCatNm + "-" + CurrentUser.UsrRlNm + "-" + LedrId.ToString());
                UsrStr.Add(CurrentUser.UsrID.ToString());
            }
            if(Stat == false)
            {
                Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UCatId <> 0";
            }
            //Statcdif.TreeUsrTbl.DefaultView.RowFilter = string.Empty; // "UCatIdSub >= " + CurrentUser.UsrUCatLvl;
                for (int i = 0; i < Statcdif.TreeUsrTbl.DefaultView.Count; i++)
                {
                    TempNode = treeView1.Nodes.Find(Statcdif.TreeUsrTbl.DefaultView[i][2].ToString(), true);
                    if (TempNode.Length > 0)
                    {
                        TempNode[0].Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[i]["UCatId"].ToString(), Statcdif.TreeUsrTbl.DefaultView[i]["UsrMix"].ToString());
                        UsrStr.Add(Statcdif.TreeUsrTbl.DefaultView[i][0].ToString());
                    }
            }
            CurrentUser.UsrTeam = string.Join(", ", UsrStr);
        }
        private void TreeTeam_select(object sender, EventArgs e)
        {
            Filtr();
        }
        public string MyTeam(int slctdId)
        {
            List<string> UsrStr = new List<string>();
            TreeNode[] TempNode = new TreeNode[0];
            TreeView trvw = new TreeView();
                Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 and UsrId = " + slctdId;
                trvw.Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[0]["UCatId"].ToString(), Statcdif.TreeUsrTbl.DefaultView[0]["UsrMix"].ToString());
                UsrStr.Add(slctdId.ToString());

            Statcdif.TreeUsrTbl.DefaultView.RowFilter = "UsrSusp = 0 ";
            for (int i = 0; i < Statcdif.TreeUsrTbl.DefaultView.Count; i++)
            {
                TempNode = trvw.Nodes.Find(Statcdif.TreeUsrTbl.DefaultView[i][2].ToString(), true);
                if (TempNode.Length > 0)
                {
                    TempNode[0].Nodes.Add(Statcdif.TreeUsrTbl.DefaultView[i]["UCatId"].ToString(), Statcdif.TreeUsrTbl.DefaultView[i]["UsrMix"].ToString());
                    UsrStr.Add(Statcdif.TreeUsrTbl.DefaultView[i][0].ToString());
                }
            }
            trvw.Dispose();
            return string.Join(", ", UsrStr);
       
        }
    }
}
