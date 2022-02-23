using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOCAC.BL;
using static VOCAC.BL.ticketCurrent;

namespace VOCAC.PL
{
    public partial class TikSearchNew : Form
    {
        private static TikSearchNew frm;
        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static TikSearchNew getTikSearchfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new TikSearchNew();
                }
                return frm;
            }
        }
        frms forms = new frms();
        BL.ticketCurrent Crnt = new ticketCurrent();
        DataTable searchTbl = new DataTable();
        public TikSearchNew()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
            forms.FrmAllSub(this);
        }
        private void TikSearchNew_Load(object sender, EventArgs e)
        {
            frm.FormClosed -= new FormClosedEventHandler(frm_Closed);
            frm.FormClosed += new FormClosedEventHandler(frm_Closed);
            searchTbl.Rows.Clear();
            searchTbl.Columns.Add("FiledNm");
            searchTbl.Columns.Add("FieldText");

            searchTbl.Rows.Add("TkSQL", "رقم الشكوى");
            searchTbl.Rows.Add("TkClNm", "اسم العميل");
            searchTbl.Rows.Add("TkClPh", "التليفون1");
            searchTbl.Rows.Add("TkClPh1", "التليفون2");
            searchTbl.Rows.Add("TkClNtID", "الرقم القومي");
            searchTbl.Rows.Add("TkMail", "الإيميل");

            Statcdif.CDMend.DefaultView.RowFilter = "CDMendStat = 0";

            for (int i = 0; i < Statcdif.CDMend.DefaultView.Count; i++)
            {
                searchTbl.Rows.Add(Statcdif.CDMend.DefaultView[i][2].ToString(), Statcdif.CDMend.DefaultView[i][2].ToString());
            }

            label1.Text = "البحث بأحد البدائل التالية :" + Environment.NewLine;
            for (int i = 0; i < searchTbl.Rows.Count; i++)
            {
                label1.Text += "                   - " + searchTbl.Rows[i]["FieldText"] + Environment.NewLine;
            }

            FilterComb.DataSource = searchTbl;
            FilterComb.ValueMember = "FiledNm";
            FilterComb.DisplayMember = "FieldText";
            size_();
        }
        private void SerchTxt_TextChanged(object sender, EventArgs e)
        {
            this.StatBrPnlAr.Text = "";
            if (Struc.dt != null)
            {
                Struc.dt.Rows.Clear();
                Struc.dt.Columns.Clear();
            }
            if (SerchTxt.Text.Length > 0)
            {
                GridTicket.Visible = true;
                label1.Visible = false;
            }
            else
            {
                GridTicket.Visible = false;
                label1.Visible = true;
            }
        }
        DAL.DataAccessLayer.rturnStruct Struc = new DAL.DataAccessLayer.rturnStruct();
        private void Filter()
        {
            string LK = " like ";
            string strt = "'%";
            string end_ = "%'";
            if (Rd_strtwith.Checked) { strt = "'"; end_ = "%'"; }
            else if (Rd_contain.Checked) { strt = "'%"; end_ = "%'"; }
            else if (Rd_endwith.Checked) { strt = "'%"; end_ = "'"; }

            if (Rd_Equal.Checked) { LK = " = "; strt = "'"; end_ = "'"; }
            else if (Rd_Like.Checked) { LK = " Like "; };

            string Any = "";
            string AnyMend = "";

            if (function.CheckArlanguage(FilterComb.SelectedValue.ToString()))
            {
                AnyMend = LK + strt + SerchTxt.Text + end_;
            }
            else
            {
                Any = " AND [" + FilterComb.SelectedValue + "] " + LK + strt + SerchTxt.Text + end_;
            }
            Struc = Search_(Any, AnyMend);
            if (Struc.msg == null)
            {
                if (Struc.dt != null && Struc.dt.Rows.Count > 0)
                {
                    Statcdif.TickTblMain = new DataTable();
                    Statcdif.TickTblMain = Struc.dt.Copy();
                    GridTicket.Visible = true;
                    label1.Visible = false;
                    GridTicket.DataSource = Statcdif.TickTblMain;
                    this.Text = "شاشة البحث - نتبجة البحث : " + Struc.dt.Rows.Count.ToString();
                    string Req = Convert.ToString(Struc.dt.Compute("count(TkKind) ", "TkKind = 'طلب'"));
                    string Comp = Convert.ToString(Struc.dt.Compute("count(TkKind) ", "TkKind = 'شكوى'"));

                    string Msg = "";
                    if (Comp != "0")
                    {
                        Msg += Comp + " شكوى";
                    }
                    if (Req != "0")
                    {
                        Msg += " - " + Req + " طلب";
                    }
                    this.StatBrPnlAr.Text = "نتيجة البحث بـ" + FilterComb.Text + " : " + Msg;
                }
                else
                {
                    this.Text = " شاشة البحث ";
                    this.StatBrPnlAr.Text = "لا توجد نتيجة للبحث بـ" + FilterComb.Text;
                }
            }
            else
            {
                this.StatBrPnlAr.Text = "خطأ بتحميل البيانات - يرجى إعادة المحاولة أو الاتصال بمدير النظام";
            }
            GC.Collect();
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


                //for (int i = 37; i < GridTicket.Columns.Count; i++)
                //{
                //    GridTicket.Columns[i].Visible = true;
                //}
            }
            GridTicket.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            GridTicket.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private DAL.DataAccessLayer.rturnStruct Search_(string @Any, string @dAnyMend)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Any", SqlDbType.NVarChar);
            param[0].Value = @Any;
            param[1] = new SqlParameter("@AnyMend", SqlDbType.NVarChar);
            param[1].Value = @dAnyMend;
            //
            DAL.Struc = DAL.SelectData("SP_TICKETS_SLCT", param);
            DAL.Close();
            return DAL.Struc;
        }
        private void Radio_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Chckfltr_CheckedChanged(object sender, EventArgs e)
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
        private void BtnSerch_Click(object sender, EventArgs e)
        {
            this.StatBrPnlAr.Text = "جاري البحث ....";
            currntTicket.fieldlst.Clear();
            Filter();
            gridadjst(Struc.dt);
        }
        private void TikSearchNew_SizeChanged(object sender, EventArgs e)
        {
            size_();
        }
        private void size_()
        {
            GridTicket.Size = new Size(this.Width - 50, this.Height - 200);
            //FlowLayoutPanel2.Margin = new Padding((this.Width - FlowLayoutPanel2.Width) / 2, FlowLayoutPanel2.Margin.Top, FlowLayoutPanel2.Margin.Right, FlowLayoutPanel2.Margin.Bottom);
            GridTicket.Margin = new Padding((this.Width - GridTicket.Width) / 2, GridTicket.Margin.Top, GridTicket.Margin.Right, GridTicket.Margin.Bottom);
            //flowLayoutPanel3.Margin = new Padding((this.Width - flowLayoutPanel3.Width) / 2, flowLayoutPanel3.Margin.Top, flowLayoutPanel3.Margin.Right, flowLayoutPanel3.Margin.Bottom);
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ShowResult()
        {
            currentRow(GridTicket);
            Crnt.AssignToForm();
            //TikDetails.gettikdetlsfrm.BringToFront();
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
                            this.StatBrPnlEn.Text = (GridTicket.CurrentRow.Index + 1) + " / " + GridTicket.Rows.Count;
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
    }
}
