using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOCAC.BL;
using VOCAC.Properties;
using static VOCAC.BL.currentTicket;

namespace VOCAC
{
    public partial class TikFolow : Form
    {
        BL.currentTicket Crnt = new currentTicket();
        private static TikFolow frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static TikFolow getTikFollowfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikFolow();
                    frm.FormClosed += new FormClosedEventHandler(frm_Closed);
                }
                return frm;
            }
        }
        SqlConnection sqlcon = new SqlConnection("Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocac;Password=@VocaPlus$21-323");
        SqlDataAdapter da;
        BindingManagerBase bmb;
        SqlCommandBuilder sqlcmb;
        DataTable TickTblMain = new DataTable();
        DataView TempData = new DataView();
        public TikFolow()
        {
            WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "  جاري تحميل البيانات .......";
            InitializeComponent();
            da = new SqlDataAdapter("select TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, " +
                            "TkDetails, TkClsStatus, TkFolw, TkEmpNm, tk.UsrRealNm as 'folowusr', TkReOp, format(TkRecieveDt, 'yyyy/MM/dd') As TkRecieveDt, TkEscTyp, ProdKNm, CompHelp, TkupSTime, EvNm, TkupTxt, upusr.UsrRealNm as 'updtusr', TkupReDt, TkupUser, TkupSQL, TkupTkSql," +
                            "TkupEvtId, EvSusp, UCatLvl, TkupUnread" +
                            " from TicketsAll tk inner join TkEvent Ev on Ev.TkupSQL = TkEvSql INNER JOIN Int_user upusr ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON upusr.UsrCat = IntUserCat.UCatId where tk.TkClsStatus = 0 and " +
                            "tk.TkEmpNm = " + CurrentUser.PUsrID + " order by TkSQL", sqlcon);
            try
            {
                da.Fill(TickTblMain);
                GridTicket.DataSource = TickTblMain.DefaultView;
                gridadjst();
                Filtr();
                frmAdjust();
                assignfltrTXTintoCtrlTag();
                WelcomeScreen.getwecmscrnfrm.StatBrPnlAr.Text = "";
            }
            catch (Exception)
            {
                fn.msg("هناك خطأ في الإتصال بقواعد البيانات", "متابعة الشكاوى");
            }

            //bmb = this.BindingContext[TickTblMain];
            //TikDetails.gettikdetlsfrm.TxtPh1.DataBindings.Add("text", TickTblMain, "TkClPh");
            //TikDetails.gettikdetlsfrm.TxtPh2.DataBindings.Add("text", TickTblMain, "TkClPh1");
        }
        //assign Filtr TEXT into Control Tag and assign Event EventHandler
        private void assignfltrTXTintoCtrlTag()
        {
            ChckAll.Tag = string.Empty;
            ChckRequest.Tag = "TkKind = 0";
            ChckComp.Tag = "TkKind = 1";
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
            this.GridTicket.SelectionChanged += new System.EventHandler(this.GridTicket_SelectionChanged);
        }
        private void gridadjst()
        {
            if (this.GridTicket.Columns.Count > 0)
            {
                for (int i = 0; i < GridTicket.Columns.Count - 1; i++)
                {
                    GridTicket.Columns[i].Visible = false;
                }
                GridTicket.Columns["TkSQL"].Visible = true;
                GridTicket.Columns["TkKind"].Visible = true;
                GridTicket.Columns["TkDtStart"].Visible = true;
                GridTicket.Columns["TkClNm"].Visible = true;
                GridTicket.Columns["TkClPh"].Visible = true;
                GridTicket.Columns["TkCardNo"].Visible = true;
                GridTicket.Columns["TkClNtID"].Visible = true;
                GridTicket.Columns["TkShpNo"].Visible = true;
                GridTicket.Columns["PrdNm"].Visible = true;
                GridTicket.Columns["CompNm"].Visible = true;
                GridTicket.Columns["TkupTxt"].Visible = true;
                GridTicket.Columns["EvNm"].Visible = true;
            }
        }
        private void Fill_()
        {
            Def.thread_ = new Thread(() =>
            {
                Action action1 = () =>
                {
                    GridTicket.Visible = false;
                    flowLayoutPanel3.Visible = false;
                    BtnRefrsh.Enabled = false;
                    CloseBtn.Visible = false;
                };
                try
                {
                    this.BeginInvoke(action1);
                }
                catch (Exception)
                {
                    return;
                };
                Action action = () =>
                {
                    GridTicket.DataSource = TickTblMain.DefaultView;
                    this.Text = "متابعة الشكاوى " + " _ " + fn.ElapsedTimeSpan;
                    GridTicket.Visible = true;
                    flowLayoutPanel3.Visible = true;
                    BtnRefrsh.Enabled = true;
                    CloseBtn.Visible = true;
                    gridadjst();
                    Filtr();
                };
                try
                {
                    this.BeginInvoke(action);
                }
                catch (Exception)
                {
                    return;
                }
            });  // New Thread -------------------------

            Def.thread_.IsBackground = true;
            if (Def.thread_ is null)
            {
                Def.thread_.Start();
            }
            else
            {
                if (Def.thread_.IsAlive != true)
                {
                    Def.thread_.Start();
                }
                else
                {
                    fn.msg("البيانات قيد التحميل .." + Environment.NewLine + "يرجى الإتنظار", "رسالة معلومات", MessageBoxButtons.OK);
                }
            }
        }
        private void BtnRefrsh_Click(object sender, EventArgs e)
        {
            sqlcmb = new SqlCommandBuilder(da);
            TickTblMain.Rows.Clear();
            da.Fill(TickTblMain);
            Filtr();
            this.StatBrPnlEn.Text = "إجمالي العدد : " + TickTblMain.Rows.Count.ToString();
        }
        private void Filtr()
        {
            StringBuilder FltrStr = new StringBuilder();
            string LK = " like ";
            string strt = "'%";
            string end_ = "%'";
            TempData = TickTblMain.DefaultView;

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
                FltrStr.Append(" or [TkCardNo]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkShpNo]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkGBNo]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [TkClNtID]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [PrdNm]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [CompNm]" + LK + strt + SerchTxt.Text + end_);
                FltrStr.Append(" or [EvNm]" + LK + strt + SerchTxt.Text + end_);
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
            LblRequest.Text = Convert.ToString(TickTblMain.Compute("count(TkKind) ", "TkKind = 0"));
            LabelCompCount.Text = Convert.ToString(TickTblMain.Compute("count(TkKind) ", "TkKind = 1"));
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
                    if (Convert.ToInt32(c.Text) > 0)
                    {
                        c.ForeColor = Color.Green;
                        c.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    }
                    else
                    {
                        c.BackColor = Color.White;
                        c.Font = new Font("Times new Roman", 6, FontStyle.Regular);
                    }
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
            GridTicket.Size = new Size(this.Width - 50, this.Height - 260);
            FlowLayoutPanel2.Margin = new Padding((this.Width - FlowLayoutPanel2.Width) / 2, FlowLayoutPanel2.Margin.Top, FlowLayoutPanel2.Margin.Right, FlowLayoutPanel2.Margin.Bottom);
            GridTicket.Margin = new Padding((this.Width - GridTicket.Width) / 2, GridTicket.Margin.Top, GridTicket.Margin.Right, GridTicket.Margin.Bottom);
            flowLayoutPanel3.Margin = new Padding((this.Width - flowLayoutPanel3.Width) / 2, flowLayoutPanel3.Margin.Top, flowLayoutPanel3.Margin.Right, flowLayoutPanel3.Margin.Bottom);
        }
        private void SerchTxt_TextChanged(object sender, EventArgs e)
        {
            this.GridTicket.SelectionChanged -= new System.EventHandler(this.GridTicket_SelectionChanged);
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
                if (TickTblMain.DefaultView.Count < TickTblMain.Rows.Count)
                {
                    Fltrreslt = "نتيجة الفلتر  : ";
                }
                else
                {
                    Fltrreslt = "العدد الإجمالي :";
                }
                if (GridTicket.CurrentRow != null)
                {
                    this.StatBrPnlAr.Text = Fltrreslt + (GridTicket.CurrentRow.Index + 1) + " / " + TickTblMain.DefaultView.Count.ToString();
                }
                Stopwatch Stp = new Stopwatch();
                Stp.Start();
                Crnt.currentRow(GridTicket);
                TikDetails.gettikdetlsfrm.MdiParent = WelcomeScreen.ActiveForm;
                TikDetails.gettikdetlsfrm.WindowState = FormWindowState.Normal;
                TikDetails.gettikdetlsfrm.Show();
                if (checkBox1.Checked) { TikDetails.gettikdetlsfrm.BringToFront(); };
                Crnt.AssignToForm();
                TimeSpan TimSpn = (Stp.Elapsed);
                Stp.Stop();
                TikDetails.gettikdetlsfrm.Text += " _ " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds);
                GC.Collect();
            }
            else
            {
                this.StatBrPnlAr.Text = "";
            }
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
                Rd_strtwith.Checked = true;
                Rd_endwith.Checked = false;
                Rd_contain.Checked = false;
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
    }
}
