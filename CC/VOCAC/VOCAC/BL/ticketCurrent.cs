using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOCAC.PL;
using VOCAC.Properties;

namespace VOCAC.BL
{
    class ticketCurrent
    {
        public struct currntTicket
        {
            public static string _TkSQL;
            public static string _TkKind;
            public static DateTime _TkDtStart;
            public static string _SrcNm;
            public static string _TkClPh;
            public static string _TkClPh1;
            public static string _TkClNm;
            public static string _TkMail;
            public static string _TkClAdr;
            public static string _TkClNtID;
            public static int _TkFnPrdCd;
            public static string _ProdKNm;
            public static string _PrdNm;
            public static string _CompNm;
            public static string _TkDetails;
            public static bool _TkClsStatus;
            public static bool _TkFolw;
            public static int _TkEmpNm;
            public static string _folowusr;
            public static string _TikfolowusrTeam;
            public static string _TikCreat;
            public static string _TikCreatTeam;
            public static bool _TkReOp;
            public static DateTime _TkRecieveDt;
            public static int _TkEscTyp;
            public static DateTime _TkupSTime;
            public static string _EvNm;
            public static string _TkupTxt;
            public static string _updtusr;
            public static DateTime _TkupReDt;
            public static int _TkupUser;
            public static int _TkupEvtId;
            public static bool _EvSusp;
            public static int _UCatLvl;
            public static bool _TkupUnread;
            public static List<string> SlctdFldLst = new List<string>();
        }
        public void currentRow(DataGridView gv)
        {
            currntTicket._TkKind = Convert.ToString(gv.CurrentRow.Cells["TkKind"].Value);
            currntTicket._SrcNm = Convert.ToString(gv.CurrentRow.Cells["SrcNm"].Value);
            currntTicket._TkSQL = Convert.ToString(gv.CurrentRow.Cells["TkSQL"].Value);
            currntTicket._TkDtStart = Convert.ToDateTime(gv.CurrentRow.Cells["TkDtStart"].Value);
            currntTicket._TkClNm = Convert.ToString(gv.CurrentRow.Cells["TkClNm"].Value);
            currntTicket._TkClPh = Convert.ToString(gv.CurrentRow.Cells["TkClPh"].Value);
            currntTicket._TkClPh1 = Convert.ToString(gv.CurrentRow.Cells["TkClPh1"].Value);
            currntTicket._TkClAdr = Convert.ToString(gv.CurrentRow.Cells["TkClAdr"].Value);

            currntTicket._TkFnPrdCd = Convert.ToInt32(gv.CurrentRow.Cells["TkFnPrdCd"].Value);
            currntTicket._PrdNm = Convert.ToString(gv.CurrentRow.Cells["PrdNm"].Value);
            currntTicket._ProdKNm = Convert.ToString(gv.CurrentRow.Cells["ProdKNm"].Value);
            currntTicket._CompNm = Convert.ToString(gv.CurrentRow.Cells["CompNm"].Value);
            currntTicket._TkMail = Convert.ToString(gv.CurrentRow.Cells["TkMail"].Value);


            currntTicket._TkClNtID = Convert.ToString(gv.CurrentRow.Cells["TkClNtID"].Value);

            currntTicket._TkDetails = Convert.ToString(gv.CurrentRow.Cells["TkDetails"].Value);
            currntTicket._TkEmpNm = Convert.ToInt32(gv.CurrentRow.Cells["TkEmpNm"].Value);
            currntTicket._TkEscTyp = Convert.ToInt32(gv.CurrentRow.Cells["TkEscTyp"].Value);
            currntTicket._TkFolw = Convert.ToBoolean(gv.CurrentRow.Cells["TkFolw"].Value);


            if (gv.CurrentRow.Cells["TkRecieveDt"].Value.ToString().Length > 0)
            {
                currntTicket._TkRecieveDt = Convert.ToDateTime(gv.CurrentRow.Cells["TkRecieveDt"].Value);
            };

            currntTicket._folowusr = Convert.ToString(gv.CurrentRow.Cells["folowusr"].Value);
            currntTicket._TikfolowusrTeam = Convert.ToString(gv.CurrentRow.Cells["TikfolowusrTeam"].Value);
            currntTicket._TikCreat = Convert.ToString(gv.CurrentRow.Cells["TikCreat"].Value);
            currntTicket._TikCreatTeam = Convert.ToString(gv.CurrentRow.Cells["TikCreatTeam"].Value);
            currntTicket._TkReOp = Convert.ToBoolean(gv.CurrentRow.Cells["TkReOp"].Value);
            currntTicket._TkClsStatus = Convert.ToBoolean(gv.CurrentRow.Cells["TkClsStatus"].Value);

            currntTicket._EvNm = Convert.ToString(gv.CurrentRow.Cells["EvNm"].Value);
            currntTicket._EvSusp = Convert.ToBoolean(gv.CurrentRow.Cells["EvSusp"].Value);
            currntTicket._TkupEvtId = Convert.ToInt32(gv.CurrentRow.Cells["TkupEvtId"].Value);
            currntTicket._TkupReDt = Convert.ToDateTime(gv.CurrentRow.Cells["TkupReDt"].Value);
            currntTicket._TkupSTime = Convert.ToDateTime(gv.CurrentRow.Cells["TkupSTime"].Value);
            currntTicket._TkupTxt = Convert.ToString(gv.CurrentRow.Cells["TkupTxt"].Value);
            currntTicket._TkupUnread = Convert.ToBoolean(gv.CurrentRow.Cells["TkupUnread"].Value);
            currntTicket._TkupUser = Convert.ToInt32(gv.CurrentRow.Cells["TkupUser"].Value);
            currntTicket._UCatLvl = Convert.ToInt32(gv.CurrentRow.Cells["UCatLvl"].Value);
            currntTicket._updtusr = Convert.ToString(gv.CurrentRow.Cells["updtusr"].Value);

            currntTicket.SlctdFldLst.Clear();
            for (int i = 36; i < gv.Columns.Count; i++)
            {
                if (gv.CurrentRow.Cells[i].Value.ToString().Length > 0)
                {
                    currntTicket.SlctdFldLst.Add(gv.Columns[i].Name.ToString() + "_" + gv.CurrentRow.Cells[i].Value.ToString());
                }
            }
        }
        public void AssignToForm()
        {


            TikDetails.gettikdetlsfrm.FlwMend.Controls.Clear();


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
                if (CurrentUser.UsrRlNm == currntTicket._folowusr)
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

            TikDetails.gettikdetlsfrm.TxtProd.Text = currntTicket._PrdNm;
            TikDetails.gettikdetlsfrm.TxtComp.Text = currntTicket._CompNm;
            TikDetails.gettikdetlsfrm.TxtSrc.Text = currntTicket._SrcNm;
            TikDetails.gettikdetlsfrm.TxtFolw.Text = currntTicket._folowusr;
            TikDetails.gettikdetlsfrm.TxtNId.Text = currntTicket._TkClNtID;

            TikDetails.gettikdetlsfrm.TxtFolw.Text = currntTicket._folowusr;
            TikDetails.gettikdetlsfrm.TxtfolowusrTeam.Text = currntTicket._TikfolowusrTeam;
            TikDetails.gettikdetlsfrm.TxtTikCreat.Text = currntTicket._TikCreat;
            TikDetails.gettikdetlsfrm.TxtTikCreatTeam.Text = currntTicket._TikCreatTeam;

            function fn = function.getfn;
            TikDetails.gettikdetlsfrm.LblWDays.Text = "تم تسجيل الشكوى منذ : " + fn.CalDate(currntTicket._TkDtStart.ToString(), Statcdif.servrTime).ToString() + " يوم عمل";

            for (int i = 0; i < currntTicket.SlctdFldLst.Count; i++)
            {
                Label Lbl = new Label();
                TextBox TxtBx = new TextBox();
                Lbl.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                Lbl.Size = new Size(100, 25);
                Lbl.TextAlign = ContentAlignment.MiddleRight;
                TxtBx.TextAlign = HorizontalAlignment.Left;
                TxtBx.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                TxtBx.Size = new Size(180, 25);
                string[] ss = currntTicket.SlctdFldLst[i].Split('_');
                Lbl.Text = ss[0] + " : ";
                TxtBx.Text = ss[1];
                TikDetails.gettikdetlsfrm.FlwMend.Controls.Add(Lbl);
                TikDetails.gettikdetlsfrm.FlwMend.Controls.Add(TxtBx);
                TxtBx.ReadOnly = true;
            }
            if (currntTicket._TkKind.Equals("شكوى",StringComparison.OrdinalIgnoreCase))
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
            TikDetails.gettikdetlsfrm.TxtTikID.Font = new Font("Times new Roman", 14, FontStyle.Bold);
            TikDetails.gettikdetlsfrm.TxtTikID.TextAlign = ContentAlignment.BottomCenter;
            TikDetails.gettikdetlsfrm.TxtDetails.Text = currntTicket._TkDetails;

            //Delete Empty lines from Details & Reassign Details Text Value
            string jj = "";
            for (int i = 0; i < TikDetails.gettikdetlsfrm.TxtDetails.Lines.Length; i++)
            {
                if (TikDetails.gettikdetlsfrm.TxtDetails.Lines[i].ToString().Length > 0)
                {
                    jj += TikDetails.gettikdetlsfrm.TxtDetails.Lines[i].ToString() + Environment.NewLine;

                }
            }
            TikDetails.gettikdetlsfrm.TxtDetails.Text = jj;

            fn.ClorTxt(TikDetails.gettikdetlsfrm.TxtDetails, "تعديل : بواسطة", Color.Transparent, Color.Red, 16);
            fn.ClorTxt(TikDetails.gettikdetlsfrm.TxtDetails, "إضافة تلقائية من النظام:", Color.Transparent, Color.Green, 16);
        }
    }
}
