using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public static void currentRow(DataGridView gv)
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
    }
}
