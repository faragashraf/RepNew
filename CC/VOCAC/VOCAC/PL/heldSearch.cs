using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOCAUltimate.PL
{
    public partial class heldSearch : Form
    {
        DataTable SerchItmTable = new DataTable();
        DataTable HeldTable = new DataTable();
        DataTable UpdtHeldTbl = new DataTable();
        function fn = function.getfn;
        public heldSearch()
        {
            InitializeComponent();
        }

        private void HeldSearch_Load(object sender, EventArgs e)
        {
            TabControl1.TabPages.Remove(TabPage2);
            TabControl1.TabPages.Remove(TabPage3);

            SerchItmTable.Rows.Clear();
            SerchItmTable.Columns.Clear();
            SerchItmTable.Columns.Add("Kind");
            SerchItmTable.Columns.Add("Item");

            SerchItmTable.Rows.Add("RsvTracing", "رقم الشحنة");
            SerchItmTable.Rows.Add("RsvConsignee", "اسم العميل");
            SerchItmTable.Rows.Add("RsvMob", "تليفون العميل");

            FilterComb.DataSource = SerchItmTable;
            FilterComb.DisplayMember = "Item";
            FilterComb.ValueMember = "Kind";
        }
        private void Filtr()
        {
            string FltrStr = "";
            if (SerchTxt.Text != "برجاء ادخال كلمات البحث")
            {
                FltrStr = "[" + FilterComb.SelectedValue + "]" + " like '" + SerchTxt.Text + "%'";
            }
            if (FltrStr.Length > 0)
            {
                FltrStr = " And " + FltrStr;


                HeldTable.Rows.Clear();
                HeldTable = fn.returntbl("SELECT ROW_NUMBER() Over (Order by RsvDate) As [S.N.],  Store_Name, RsvID, RsvNo, RsvTracing, CounNm, RsvWeight, RsvConsignee, RsvAdd, RsvMob, RsvReason, RsvDate, RsvType, RsvType1, RsvDoc, RsvEmpNm, CASE WHEN RsvStr > 5 THEN 'رمسيس' ELSE 'مطار القاهرة'END As Location, CASE WHEN RsvPHN = 1 THEN N'✔' ELSE '' END As RsvPHN, CASE WHEN RsvRec = 1 THEN N'✔' ELSE '' END As RsvRec, CASE WHEN RsvPrintPaper = 1 THEN N'✔' ELSE '' END As RsvPrintPaper, CASE WHEN RsvOut = 1 THEN N'✘' ELSE '' END As RsvOut,Phonefailure, RsvStart, Rsv_ad_Date, Rsv_Days, MONTH(RsvDate) AS Month, YEAR(RsvDate) AS Year,(select UsrRealNm from Int_user where UsrId = rsv.RsvAssignUser) As [موظف الإخطار التليفوني] FROM Rsv INNER JOIN Int_user ON RsvEmpNm = Usrid INNER JOIN CDCountry ON RsvOrgin = CDCountry.CounCd INNER JOIN Stores ON RsvStr = Store_No WHERE (YEAR(RsvDate) > 2018)" + FltrStr + " ORDER BY RsvDate");
                if (HeldTable != null && HeldTable.Rows.Count > 0)
                {
                    GridHeld.DataSource = HeldTable;
                    GridPopulte();
                }
                else
                {
                    LblMsg.Text = ("لا توجد نتيجة للبحث");
                    LblMsg.ForeColor = Color.Red;
                }
            }
        }
        private void GridPopulte()
        {
            LblMsg.ForeColor = Color.Green;
            GridHeld.Columns[0].HeaderText = "م";
            GridHeld.Columns[1].HeaderText = "اسم القسم";
            GridHeld.Columns[2].Visible = false;
            GridHeld.Columns[3].Visible = false;
            GridHeld.Columns[4].HeaderText = "رقم الشحنة";
            GridHeld.Columns[5].HeaderText = "بلد المنشأ";
            GridHeld.Columns[6].Visible = false;
            GridHeld.Columns[7].HeaderText = "اسم العميل";
            GridHeld.Columns[8].Visible = false;
            GridHeld.Columns[9].HeaderText = "رقم الموبايل";
            GridHeld.Columns[10].Visible = false;
            GridHeld.Columns[11].HeaderText = "تاريخ الحجز";
            GridHeld.Columns[12].Visible = false;
            GridHeld.Columns[13].HeaderText = "حالة الشحنة";
            GridHeld.Columns[14].Visible = false;
            GridHeld.Columns[15].Visible = false;
            GridHeld.Columns[16].HeaderText = "موقع الحجز";
            GridHeld.Columns[17].HeaderText = "اخطار تليفوني";
            GridHeld.Columns[18].HeaderText = "استلام الأوراق";
            GridHeld.Columns[19].HeaderText = "طباعة الأوراق";
            GridHeld.Columns[20].HeaderText = "استبعاد";
            GridHeld.Columns[21].Visible = false;
            GridHeld.Columns[22].Visible = false;
            GridHeld.Columns[23].Visible = false;
            GridHeld.Columns[24].Visible = false;
            GridHeld.Columns[25].Visible = false;
            GridHeld.Columns[26].Visible = false;

            GridHeld.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridHeld.Columns[17].DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            GridHeld.Columns[17].DefaultCellStyle.ForeColor = Color.Green;
            GridHeld.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridHeld.Columns[18].DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            GridHeld.Columns[18].DefaultCellStyle.ForeColor = Color.Green;
            GridHeld.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridHeld.Columns[19].DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            GridHeld.Columns[19].DefaultCellStyle.ForeColor = Color.Green;
            GridHeld.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridHeld.Columns[20].DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            GridHeld.Columns[20].DefaultCellStyle.ForeColor = Color.Red;

            GridHeld.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridHeld.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            GridHeld.Columns[0].Width = 50;
            GridHeld.Columns[1].Width = 70;
            GridHeld.Columns[4].Width = 130;
            GridHeld.Columns[7].Width = 200;
            GridHeld.Columns[9].Width = 100;
            GridHeld.Columns[11].Width = 120;
            GridHeld.Columns[16].Width = 90;
            GridHeld.Columns[17].Width = 50;
            GridHeld.Columns[18].Width = 50;
            GridHeld.Columns[19].Width = 50;
            GridHeld.Columns[20].Width = 50;
            LblMsg.Text = "تم تحميل  " + HeldTable.Rows.Count + " بيان";
            LblMsg.ForeColor = Color.Green;
        }

        private void BtnSerch_Click(object sender, EventArgs e)
        {
            Filtr();
        }

        private void HeldSearch_SizeChanged(object sender, EventArgs e)
        {
            //GridHeld.Size = new Size(this.Width - 250, this.Height - 350);
        }

        private void SerchTxt_Enter(object sender, EventArgs e)
        {
            if (SerchTxt.Text == "برجاء ادخال كلمات البحث")
            {
                SerchTxt.Text = "";
                SerchTxt.ForeColor = Color.Black;
            }
        }

        private void SerchTxt_Leave(object sender, EventArgs e)
        {
            if (SerchTxt.Text.Trim().Length == 0)
            {
                SerchTxt.Text = "برجاء ادخال كلمات البحث";
                SerchTxt.ForeColor = Color.FromArgb(224, 224, 224);
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab.Name == "TabPage1")
            {
                if (SerchTxt.Text == "برجاء ادخال كلمات البحث")
                {
                    SerchTxt.ForeColor = Color.FromArgb(224, 224, 224);
                }
            }
            else if (TabControl1.SelectedTab.Name == "TabPage2")
            {

   
      
            }
        }

        private void GetUpdtEvent()
        {
            UpdtHeldTbl.Rows.Clear();
            UpdtHeldTbl = fn.returntbl("SELECT RsvRelationID, RsvUpdate_time,CASE WHEN (select MAX( DISTINCT RsvAdTrk) from RsvAd where  (RsvType = 1) AND (RsvAdTrk IS NOT NULL) AND (RsvAdReln = RsvRelationID) AND (format(RsvUpdate_time,'yyyy/MM/dd') = format(RsvAdDate,'yyyy/MM/dd'))) IS NULL THEN RsvUpdateTxt ELSE " +
" RsvUpdateTxt + ' _ ' + (select MAX(DISTINCT RsvAdTrk) from RsvAd where (RsvType = 1) AND(RsvAdTrk IS NOT NULL) AND(RsvAdReln = RsvRelationID) AND(format(RsvUpdate_time, 'yyyy/MM/dd') = format(RsvAdDate, 'yyyy/MM/dd'))) END, Int_user.UsrRealNm,(select MAX(DISTINCT RsvAdTrk) from RsvAd where (RsvType = 1) AND(RsvAdTrk IS NOT NULL) AND(RsvAdReln = RsvRelationID) AND(format(RsvUpdate_time, 'yyyy/MM/dd') = format(RsvAdDate, 'yyyy/MM/dd'))) AS tRACK FROM Int_user INNER JOIN RsvUpdate ON Int_user.Usrid = RsvUpdateUser INNER JOIN Rsv ON RsvRelationID = dbo.Rsv.RsvID where RsvRelationID = " + GridHeld.CurrentRow.Cells[2].Value + " ORDER BY RsvUpdate_time DESC");
            if (UpdtHeldTbl.Rows.Count > 0)
            {
                GridHeldUpdt.DataSource = UpdtHeldTbl;

                GridHeldUpdt.Columns[0].Visible = false;
                GridHeldUpdt.Columns[1].HeaderText = "تاريخ التحديث";            //1
                GridHeldUpdt.Columns[2].HeaderText = "نص التحديث";             //2
                GridHeldUpdt.Columns[3].HeaderText = "محرر التحديث";            //3
                GridHeldUpdt.Columns[4].Visible = false;
                GridHeldUpdt.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GridHeldUpdt.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                GridHeldUpdt.AutoResizeColumns();
                GridHeldUpdt.Columns[2].Width = 350;
                GridHeldUpdt.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                GridHeldUpdt.AutoResizeRows();
            }
            else
            {
                LblMsg.Text = ("لا توجد نتيجة للبحث");
                LblMsg.ForeColor = Color.Red;
            }
        }

        private void GridHeld_DoubleClick(object sender, EventArgs e)
        {
            if (TabControl1.TabPages.Contains(TabPage2) == false)
            {
                LblMsg.Text = "جاري تحميل التحديثات ...";
                LblMsg.Refresh();
                TabControl1.TabPages.Insert(1, TabPage2);
                TxtTrck.Text = GridHeld.CurrentRow.Cells[4].Value.ToString();
                TxtDt.Text = GridHeld.CurrentRow.Cells[11].Value.ToString();
                TxtPh.Text = GridHeld.CurrentRow.Cells[9].Value.ToString();
                TxtNm.Text = GridHeld.CurrentRow.Cells[7].Value.ToString();
                TxtAdd.Text = GridHeld.CurrentRow.Cells[8].Value.ToString();
                TxtOrgin.Text = GridHeld.CurrentRow.Cells[5].Value.ToString();
                if (DBNull.Value.Equals(GridHeld.CurrentRow.Cells[6].Value) == false) { TxtWieght.Text = GridHeld.CurrentRow.Cells[6].Value.ToString(); }
                TxtDoc.Text = GridHeld.CurrentRow.Cells[10].Value.ToString();
                TxtReason.Text = GridHeld.CurrentRow.Cells[14].Value.ToString();
                GetUpdtEvent();
                TabPage2.Text = "رقم الشحنة : " + GridHeld.CurrentRow.Cells[4].Value;
                TabControl1.SelectedTab = TabPage2;
                LblMsg.Text = "";
            }

        }

        private void Btn2Bck_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            TabControl1.TabPages.RemoveByKey("TabPage2");
            foreach (Control c in TabPage2.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    c.Text = "";
                }
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
