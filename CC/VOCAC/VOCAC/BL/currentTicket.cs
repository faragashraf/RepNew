using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOCAC.Properties;

namespace VOCAC.BL
{
    class currentTicket
    {
        public struct currntTicket
        {
            public static string _TkSQL;
            public static bool _TkKind;
            public static DateTime _TkDtStart;
            public static string _SrcNm;
            public static string _TkClPh;
            public static string _TkClPh1;
            public static string _TkClNm;
            public static string _TkMail;
            public static string _TkClAdr;
            public static string _TkCardNo;
            public static string _TkShpNo;
            public static string _TkGBNo;
            public static string _TkClNtID;
            public static string _TkAmount;
            public static DateTime _TkTransDate;
            public static string _PrdKind;
            public static string _PrdNm;
            public static string _CompNm;
            public static string _CounNmSender;
            public static string _CounNmConsign;
            public static string _OffNm1;
            public static string _OffArea;
            public static string _TkDetails;
            public static bool _TkClsStatus;
            public static bool _TkFolw;
            public static int _TkEmpNm;
            public static string _folowusr;
            public static bool _TkReOp;
            public static DateTime _TkRecieveDt;
            public static int _TkEscTyp;
            public static string _ProdKNm;
            public static string _CompHelp;
            public static DateTime _TkupSTime;
            public static string _EvNm;
            public static string _TkupTxt;
            public static string _updtusr;
            public static DateTime _TkupReDt;
            public static int _TkupUser;
            public static int _TkupTkSql;
            public static int _TkupEvtId;
            public static bool _EvSusp;
            public static int _UCatLvl;
            public static bool _TkupUnread;
        }
        public void currentRow( DataGridView gv)
        {
            currntTicket._TkKind = Convert.ToBoolean(gv.CurrentRow.Cells["TkKind"].Value);
            currntTicket._SrcNm = Convert.ToString(gv.CurrentRow.Cells["SrcNm"].Value);
            currntTicket._TkSQL = Convert.ToString(gv.CurrentRow.Cells["TkSQL"].Value);
            currntTicket._TkDtStart = Convert.ToDateTime(gv.CurrentRow.Cells["TkDtStart"].Value);
            currntTicket._TkClNm = Convert.ToString(gv.CurrentRow.Cells["TkClNm"].Value);
            currntTicket._TkClPh = Convert.ToString(gv.CurrentRow.Cells["TkClPh"].Value);
            currntTicket._TkClPh1 = Convert.ToString(gv.CurrentRow.Cells["TkClPh1"].Value);
            currntTicket._TkClAdr = Convert.ToString(gv.CurrentRow.Cells["TkClAdr"].Value);

            currntTicket._PrdNm = Convert.ToString(gv.CurrentRow.Cells["PrdNm"].Value);
            currntTicket._ProdKNm = Convert.ToString(gv.CurrentRow.Cells["ProdKNm"].Value);
            currntTicket._CompNm = Convert.ToString(gv.CurrentRow.Cells["CompNm"].Value);
            currntTicket._TkMail = Convert.ToString(gv.CurrentRow.Cells["TkMail"].Value);

            currntTicket._TkCardNo = Convert.ToString(gv.CurrentRow.Cells["TkCardNo"].Value);
            currntTicket._TkGBNo = Convert.ToString(gv.CurrentRow.Cells["TkGBNo"].Value);
            currntTicket._TkAmount = Convert.ToString(gv.CurrentRow.Cells["TkAmount"].Value);
            currntTicket._TkClNtID = Convert.ToString(gv.CurrentRow.Cells["TkClNtID"].Value);

            currntTicket._TkDetails = Convert.ToString(gv.CurrentRow.Cells["TkDetails"].Value);
            currntTicket._TkEmpNm = Convert.ToInt32(gv.CurrentRow.Cells["TkEmpNm"].Value);
            currntTicket._TkEscTyp = Convert.ToInt32(gv.CurrentRow.Cells["TkEscTyp"].Value);
            currntTicket._TkFolw = Convert.ToBoolean(gv.CurrentRow.Cells["TkFolw"].Value);

            currntTicket._OffArea = Convert.ToString(gv.CurrentRow.Cells["OffArea"].Value);
            currntTicket._OffNm1 = Convert.ToString(gv.CurrentRow.Cells["OffNm1"].Value);

            if (gv.CurrentRow.Cells["TkRecieveDt"].Value.ToString().Length > 0)
            {
                currntTicket._TkRecieveDt = Convert.ToDateTime(gv.CurrentRow.Cells["TkRecieveDt"].Value);
            };
            currntTicket._TkShpNo = Convert.ToString(gv.CurrentRow.Cells["TkShpNo"].Value);
            currntTicket._CounNmConsign = Convert.ToString(gv.CurrentRow.Cells["CounNmConsign"].Value);
            currntTicket._CounNmSender = Convert.ToString(gv.CurrentRow.Cells["CounNmSender"].Value);

            currntTicket._folowusr = Convert.ToString(gv.CurrentRow.Cells["folowusr"].Value);
            currntTicket._TkReOp = Convert.ToBoolean(gv.CurrentRow.Cells["TkReOp"].Value);
            currntTicket._TkClsStatus = Convert.ToBoolean(gv.CurrentRow.Cells["TkClsStatus"].Value);
            currntTicket._TkTransDate = (DateTime)gv.CurrentRow.Cells["TkTransDate"].Value;

            currntTicket._EvNm = Convert.ToString(gv.CurrentRow.Cells["EvNm"].Value);
            currntTicket._EvSusp = Convert.ToBoolean(gv.CurrentRow.Cells["EvSusp"].Value);
            currntTicket._TkupEvtId = Convert.ToInt32(gv.CurrentRow.Cells["TkupEvtId"].Value);
            currntTicket._TkupReDt = Convert.ToDateTime(gv.CurrentRow.Cells["TkupReDt"].Value);
            currntTicket._TkupSTime = Convert.ToDateTime(gv.CurrentRow.Cells["TkupSTime"].Value);
            currntTicket._TkupTkSql = Convert.ToInt32(gv.CurrentRow.Cells["TkupTkSql"].Value);
            currntTicket._TkupTxt = Convert.ToString(gv.CurrentRow.Cells["TkupTxt"].Value);
            currntTicket._TkupUnread = Convert.ToBoolean(gv.CurrentRow.Cells["TkupUnread"].Value);
            currntTicket._TkupUser = Convert.ToInt32(gv.CurrentRow.Cells["TkupUser"].Value);
            currntTicket._UCatLvl = Convert.ToInt32(gv.CurrentRow.Cells["UCatLvl"].Value);
            currntTicket._updtusr = Convert.ToString(gv.CurrentRow.Cells["updtusr"].Value);
            currntTicket._CompHelp = Convert.ToString(gv.CurrentRow.Cells["CompHelp"].Value);
        }
        public void AssignToForm()
        {
            if (currntTicket._TkClsStatus == true)
            {
                TikDetails.gettikdetlsfrm.TcktImg.BackgroundImage = Resources.Tckoff;
                TikDetails.gettikdetlsfrm.TcktImg.BackgroundImageLayout = ImageLayout.Stretch;
                TikDetails.gettikdetlsfrm.BtnAddEdt.Enabled = false;
                TikDetails.gettikdetlsfrm.TxtDetailsAdd.Enabled = false;
                TikDetails.gettikdetlsfrm.TxtDetailsAdd.Text = "لا يمكن عمل تعديل أو إضافة على تفاصيل شكوى مغلقة";
                TikDetails.gettikdetlsfrm.TxtDetailsAdd.TextAlign = HorizontalAlignment.Center;
                TikDetails.gettikdetlsfrm.TxtDetailsAdd.Font = new Font("Times new Roman", 16, FontStyle.Regular);
                TikDetails.gettikdetlsfrm.BtnClos.Visible = false;
            }
            else
            {
                TikDetails.gettikdetlsfrm.TcktImg.BackgroundImage = Resources.Tckon;
                TikDetails.gettikdetlsfrm.TcktImg.BackgroundImageLayout = ImageLayout.Stretch;
                TikDetails.gettikdetlsfrm.BtnAddEdt.Enabled = true;
                TikDetails.gettikdetlsfrm.TxtDetailsAdd.Enabled = true;
                TikDetails.gettikdetlsfrm.TxtDetailsAdd.Text = "";
                TikDetails.gettikdetlsfrm.TxtDetailsAdd.Font = new Font("Times new Roman", 12, FontStyle.Regular);
                TikDetails.gettikdetlsfrm.TxtDetailsAdd.TextAlign = HorizontalAlignment.Left;
                if (CurrentUser.PUsrRlNm == currntTicket._folowusr)
                {
                    TikDetails.gettikdetlsfrm.BtnClos.Visible = true;
                }
                else
                {
                    TikDetails.gettikdetlsfrm.BtnClos.Visible = false;
                }
            }

            TikDetails.gettikdetlsfrm.TxtPh1.Text = currntTicket._TkClPh;
            TikDetails.gettikdetlsfrm.TxtPh2.Text = currntTicket._TkClPh1;
            TikDetails.gettikdetlsfrm.TxtDt.Text = currntTicket._TkDtStart.ToString();
            TikDetails.gettikdetlsfrm.TxtNm.Text = currntTicket._TkClNm;
            TikDetails.gettikdetlsfrm.TxtAdd.Text = currntTicket._TkClAdr;
            TikDetails.gettikdetlsfrm.TxtEmail.Text = currntTicket._TkMail;
            TikDetails.gettikdetlsfrm.TxtDetails.Text = currntTicket._TkDetails;
            TikDetails.gettikdetlsfrm.TxtArea.Text = currntTicket._OffArea;
            TikDetails.gettikdetlsfrm.TxtOff.Text = currntTicket._OffNm1;
            TikDetails.gettikdetlsfrm.TxtProd.Text = currntTicket._PrdNm;
            TikDetails.gettikdetlsfrm.TxtComp.Text = currntTicket._CompNm;
            TikDetails.gettikdetlsfrm.TxtSrc.Text = currntTicket._SrcNm;
            TikDetails.gettikdetlsfrm.TxtTrck.Text = currntTicket._TkShpNo;
            TikDetails.gettikdetlsfrm.TxtOrgin.Text = currntTicket._CounNmSender;
            TikDetails.gettikdetlsfrm.TxtDist.Text = currntTicket._CounNmConsign;
            TikDetails.gettikdetlsfrm.TxtCard.Text = currntTicket._TkCardNo;
            TikDetails.gettikdetlsfrm.TxtGP.Text = currntTicket._TkGBNo;
            TikDetails.gettikdetlsfrm.TxtNId.Text = currntTicket._TkClNtID;
            TikDetails.gettikdetlsfrm.TxtAmount.Text = currntTicket._TkAmount;


            if (Convert.ToInt32((currntTicket._TkTransDate).ToString("yyyy")) < 2000)
                TikDetails.gettikdetlsfrm.TxtTransDt.Text = "";
            else { TikDetails.gettikdetlsfrm.TxtTransDt.Text = currntTicket._TkTransDate.ToString("yyyy/MM/dd"); }

            TikDetails.gettikdetlsfrm.TxtFolw.Text = currntTicket._folowusr;
            try
            {
                function fn = function.getfn;
                TikDetails.gettikdetlsfrm.LblWDays.Text = "تم تسجيل الشكوى منذ : " + fn.CalDate(currntTicket._TkDtStart.ToString(), Statcdif.servrTime).ToString() + " يوم عمل";
            }
            catch (Exception ex)
            {
                function fn = function.getfn;
                fn.msg("لم يتم احتساب أيام العمل", "عدد أيام العمل");
            }
            if (currntTicket._ProdKNm == "مالية")
            {
                TikDetails.gettikdetlsfrm.GroupBox3.Visible = true;
                TikDetails.gettikdetlsfrm.GroupBox4.Visible = false;
            }
            else if (currntTicket._ProdKNm == "بريدية")
            {
                TikDetails.gettikdetlsfrm.GroupBox3.Visible = false;
                TikDetails.gettikdetlsfrm.GroupBox4.Visible = true;
            }
            else
            {
                TikDetails.gettikdetlsfrm.GroupBox3.Visible = false;
                TikDetails.gettikdetlsfrm.GroupBox4.Visible = false;
            }
            TikDetails.gettikdetlsfrm.LblHelp.Text = currntTicket._CompHelp;
            if (currntTicket._TkKind == true)
            {
                TikDetails.gettikdetlsfrm.TxtTikID.Text = "شكوى رقم : " + currntTicket._TkSQL;
                TikDetails.gettikdetlsfrm.Text = "شكوى رقم : " + currntTicket._TkSQL;
            }
            else
            {
                TikDetails.gettikdetlsfrm.TxtTikID.Text = "طلب رقم : " + currntTicket._TkSQL;
                TikDetails.gettikdetlsfrm.Text = "طلب رقم : " + currntTicket._TkSQL;
            }
            TikDetails.gettikdetlsfrm.TxtTikID.RightToLeft = RightToLeft.Yes;
            TikDetails.gettikdetlsfrm.TxtTikID.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            TikDetails.gettikdetlsfrm.TxtTikID.TextAlign = ContentAlignment.BottomCenter;

            //SelctSerchTxt(TxtDetails, "تعديل : بواسطة")
        }
    }
}
