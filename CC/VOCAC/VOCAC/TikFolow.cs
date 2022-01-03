using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace VOCAC
{
    public partial class TikFolow : Form
    {
        DataTable TickTblMain = new DataTable();
        DataTable SerchTable = new DataTable();
        DataView TempData = new DataView();
        public TikFolow()
        {
            InitializeComponent();
        }
        function fn = new function();
        defintions Def = new defintions();
        private void TikFolow_Load(object sender, EventArgs e)
        {
            frms forms = new frms();
            forms.FrmAllSub(this);

            SerchTable.Rows.Clear();
            SerchTable.Columns.Clear();
            SerchTable.Columns.Add("Kind");
            SerchTable.Columns.Add("Item");

            SerchTable.Rows.Add("TkClNm", "اسم العميل");
            SerchTable.Rows.Add("TkClNtID", "الرقم القومي");
            SerchTable.Rows.Add("TkClPh", "تليفون العميل1");
            SerchTable.Rows.Add("TkClPh1", "تليفون العميل2");
            SerchTable.Rows.Add("TkSQL", "رقم الشكوى");
            SerchTable.Rows.Add("TkCardNo", "رقم الكارت");
            SerchTable.Rows.Add("TkShpNo", "رقم الشحنة");
            SerchTable.Rows.Add("TkGBNo", "رقم أمر الدفع");
            SerchTable.Rows.Add("SrcNm", "مصدر الشكوى");
            SerchTable.Rows.Add("TkAmount", "مبلغ العملية");

            FilterComb.DataSource = SerchTable;
            FilterComb.DisplayMember = "Item";
            FilterComb.ValueMember = "Kind";
            Fill_();
        }
        private void NewFill_()
        {
            DataColumn primaryKey = new DataColumn();
            TickTblMain = new DataTable();
            primaryKey = TickTblMain.Columns["TkSQL"];
            primaryKey = defintions.CountryTable.Columns["TkSQL"];
            if (fn.Gettable("select TkSQL, TkKind, TkDtStart, TkID, SrcNm, TkClNm, TkClPh, TkClPh1, TkMail, TkClAdr, TkCardNo, TkShpNo, TkGBNo, TkClNtID, TkAmount, TkTransDate, PrdKind, PrdNm, CompNm, CounNmSender, CounNmConsign, OffNm1, OffArea, " +
                            "TkDetails, TkClsStatus, TkFolw, TkEmpNm, tk.UsrRealNm, TkReOp, format(TkRecieveDt, 'yyyy/MM/dd') As TkRecieveDt, TkEscTyp, ProdKNm, CompHelp, TkupSTime, EvNm, TkupTxt, upusr.UsrRealNm, TkupReDt, TkupUser, TkupSQL, TkupTkSql," +
                            "TkupEvtId, EvSusp, UCatLvl, TkupUnread" +
                            " from TicketsAll tk inner join TkEvent Ev on Ev.TkupSQL = TkEvSql INNER JOIN Int_user upusr ON TkupUser = UsrId INNER JOIN CDEvent ON TkupEvtId = EvId INNER JOIN IntUserCat ON upusr.UsrCat = IntUserCat.UCatId where tk.TkClsStatus = 0 and " +
                            "tk.TkEmpNm = " + CurrentUser.PUsrID + " order by TkSQL", TickTblMain, "1006&H") == null)
            {
                int hh = Convert.ToInt32(TickTblMain.Compute("count(TkupUnread)", "TkupUnread = 1"));
            }
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
                GridTicket.Columns["TkGBNo"].Visible = true;
                GridTicket.Columns["TkClNtID"].Visible = true;
                GridTicket.Columns["TkAmount"].Visible = true;
                GridTicket.Columns["TkTransDate"].Visible = true;
                GridTicket.Columns["TkShpNo"].Visible = true;

            }
        }
        private void Fill_()
        {
            Def.thread_ = new Thread(() =>
            {
                Action action1 = () =>
                {
                    GridTicket.Visible = false;
                    GroupBox1.Visible = false;
                    BtnRefrsh.Enabled = false;
                };
                try
                {
                    this.BeginInvoke(action1);
                }
                catch (Exception)
                {
                    return;
                };
                NewFill_();
                Action action = () =>
                {
                    GridTicket.DataSource = TickTblMain.DefaultView;
                    this.Text = "متابعة الشكاوى " + " _ " + fn.ElapsedTimeSpan;
                    GridTicket.Visible = true;
                    GroupBox1.Visible = true;
                    BtnRefrsh.Enabled = true;
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

            Fill_();
        }
        private void Filtr()
        {
            StringBuilder FltrStr = new StringBuilder();
            TempData = TickTblMain.DefaultView;

            if (SerchTxt.TextLength > 0)
            {
                for (int i = 0; i < this.TickTblMain.Columns.Count - 1; i++)
                {
                    if (FilterComb.SelectedValue.ToString() == this.TickTblMain.Columns[i].ColumnName.ToString())
                    {
                        FltrStr.Append("[" + this.TickTblMain.Columns[i].ColumnName + "]" + " like '" + SerchTxt.Text + "%'");
                        break;
                    }
                }
            }
            if (FltrStr.ToString().Length > 0)
            {
                TickTblMain.DefaultView.RowFilter = FltrStr.ToString();
            }
            else
            {
                TickTblMain.DefaultView.RowFilter = string.Empty;
            }
        }
        private void TikFolow_SizeChanged(object sender, EventArgs e)
        {
            GridTicket.Size = new Size(this.Width - 50, this.Height - 250);
        }
        private void SerchTxt_TextChanged(object sender, EventArgs e)
        {
            Filtr();
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
