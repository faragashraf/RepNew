using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
            public static int _TkSQL;
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
            public static int _TaskUserID;
            public static string _TaskUserNm;
            public static string _TaskUsrCatNm;
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
            public static List<string> fieldlst = new List<string>();
            public static string[] SlctdFldLstArr;
            public static int colCnt;

        }
        public static void currentRow(DataGridView gv)
        {
            if (gv.CurrentRow != null)
            {
                currntTicket.colCnt = 0;
                currntTicket._TkKind = Convert.ToString(gv.CurrentRow.Cells["TkKind"].Value);
                currntTicket._SrcNm = Convert.ToString(gv.CurrentRow.Cells["SrcNm"].Value);
                currntTicket._TkSQL = Convert.ToInt32(gv.CurrentRow.Cells["TkSQL"].Value);
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
                if (gv.CurrentRow.Cells["TkupReDt"].Value.ToString().Length > 0) { currntTicket._TkupReDt = Convert.ToDateTime(gv.CurrentRow.Cells["TkupReDt"].Value); }
                currntTicket._TkupSTime = Convert.ToDateTime(gv.CurrentRow.Cells["TkupSTime"].Value);
                currntTicket._TkupTxt = Convert.ToString(gv.CurrentRow.Cells["TkupTxt"].Value);
                currntTicket._TkupUnread = Convert.ToBoolean(gv.CurrentRow.Cells["TkupUnread"].Value);
                currntTicket._TkupUser = Convert.ToInt32(gv.CurrentRow.Cells["TkupUser"].Value);
                currntTicket._UCatLvl = Convert.ToInt32(gv.CurrentRow.Cells["UCatLvl"].Value);
                currntTicket._updtusr = Convert.ToString(gv.CurrentRow.Cells["updtusr"].Value);

                if (!DBNull.Value.Equals(gv.CurrentRow.Cells["TaskUserID"].Value)) { currntTicket._TaskUserID = Convert.ToInt32(gv.CurrentRow.Cells["TaskUserID"].Value); } else { currntTicket._TaskUserID = 0; }
                currntTicket._TaskUserNm = Convert.ToString(gv.CurrentRow.Cells["TaskUserNm"].Value);
                currntTicket._TaskUserNm = Convert.ToString(gv.CurrentRow.Cells["TaskUserNm"].Value);


                currntTicket.SlctdFldLstArr = new string[currntTicket.fieldlst.Count];

                for (int i = 0; i < currntTicket.fieldlst.Count; i++)
                {
                    if (gv.CurrentRow.Cells[currntTicket.fieldlst[i].ToString()].Value.ToString().Length > 0)
                    {
                        currntTicket.SlctdFldLstArr[i] = currntTicket.fieldlst[i].ToString() + "_" + gv.CurrentRow.Cells[currntTicket.fieldlst[i].ToString()].Value.ToString();
                    }
                }
            }
        }
        public void AssignToForm()
        {
            TikDetails.gettikdetlsfrm.FlwMend.Controls.Clear();

            if (currntTicket._TkKind.Equals("شكوى", StringComparison.OrdinalIgnoreCase))
            {
                TikDetails.gettikdetlsfrm.TxtTikID.Text = "شكوى رقم : " + currntTicket._TkSQL;
                TikDetails.gettikdetlsfrm.Text = "شكوى رقم : " + currntTicket._TkSQL;
            }
            else
            {
                TikDetails.gettikdetlsfrm.TxtTikID.Text = "طلب رقم : " + currntTicket._TkSQL;
                TikDetails.gettikdetlsfrm.Text = "طلب رقم : " + currntTicket._TkSQL;
            }

            if (currntTicket._TkClsStatus == true)
            {
                TikDetails.gettikdetlsfrm.TcktImg.BackgroundImage = Resources.Tckoff;
                TikDetails.gettikdetlsfrm.TcktImg.BackgroundImageLayout = ImageLayout.Stretch;
                TikDetails.gettikdetlsfrm.BtnAddEdt.Enabled = false;
                TikDetails.gettikdetlsfrm.TxtDetailsAdd.Enabled = false;
                TikDetails.gettikdetlsfrm.TxtDetailsAdd.Text = "لا يمكن عمل تعديل أو إضافة على تفاصيل شكوى مغلقة";
                TikDetails.gettikdetlsfrm.TxtDetailsAdd.TextAlign = HorizontalAlignment.Center;
                TikDetails.gettikdetlsfrm.TxtDetailsAdd.Font = new Font("Times new Roman", 16, FontStyle.Regular);
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

            if (currntTicket._TaskUserNm.Length > 0) { TikDetails.gettikdetlsfrm.lblRegion.Text = "✅     تم تحويل ال" + currntTicket._TkKind + " لـ" + currntTicket._TaskUserNm; } else { TikDetails.gettikdetlsfrm.lblRegion.Text = ""; }
            function fn = function.getfn;
            TikDetails.gettikdetlsfrm.LblWDays.Text = "تم تسجيل ال" + currntTicket._TkKind + " منذ : " + fn.CalDate(currntTicket._TkDtStart.ToString(), Statcdif.servrTime).ToString() + " يوم عمل";

            for (int i = 0; i < currntTicket.SlctdFldLstArr.Length; i++)
            {
                if (currntTicket.SlctdFldLstArr[i] != null)
                {
                    Label Lbl = new Label();
                    TextBox TxtBx = new TextBox();
                    Lbl.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    Lbl.Size = new Size(100, 25);
                    Lbl.TextAlign = ContentAlignment.MiddleRight;
                    TxtBx.TextAlign = HorizontalAlignment.Left;
                    TxtBx.Font = new Font("Times new Roman", 12, FontStyle.Bold);
                    TxtBx.Size = new Size(180, 25);
                    string[] ss = currntTicket.SlctdFldLstArr[i].Split('_');
                    Lbl.Text = ss[0] + " : ";
                    TxtBx.Text = ss[1];
                    TikDetails.gettikdetlsfrm.FlwMend.Controls.Add(Lbl);
                    TikDetails.gettikdetlsfrm.FlwMend.Controls.Add(TxtBx);
                    TxtBx.ReadOnly = true;
                }

            }
            TikDetails.gettikdetlsfrm.TxtTikID.RightToLeft = RightToLeft.Yes;
            TikDetails.gettikdetlsfrm.TxtTikID.Font = new Font("Times new Roman", 14, FontStyle.Bold);
            TikDetails.gettikdetlsfrm.TxtTikID.TextAlign = ContentAlignment.BottomCenter;
            TikDetails.gettikdetlsfrm.TxtDetails.Text = currntTicket._TkDetails;

            //Delete Empty lines from Details & Reassign Details Text Value
            string FiledStr = "";
            for (int i = 0; i < TikDetails.gettikdetlsfrm.TxtDetails.Lines.Length; i++)
            {
                if (TikDetails.gettikdetlsfrm.TxtDetails.Lines[i].ToString().Length > 0)
                {
                    FiledStr += TikDetails.gettikdetlsfrm.TxtDetails.Lines[i].ToString() + Environment.NewLine;

                }
            }
            TikDetails.gettikdetlsfrm.TxtDetails.Text = FiledStr;

            fn.ClorTxt(TikDetails.gettikdetlsfrm.TxtDetails, "تعديل : بواسطة", Color.Transparent, Color.Red, 16);
            fn.ClorTxt(TikDetails.gettikdetlsfrm.TxtDetails, "إضافة تلقائية من النظام:", Color.Transparent, Color.Green, 16);
        }
        public static DataTable attchtbl = new DataTable();
        public static void getupdate()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TkupTkSql", SqlDbType.Int);
            param[0].Value = currntTicket._TkSQL;
            DataTable gg = new DataTable();


            DAL.Struc = DAL.SelectData("SP_TICKET_EVENT_SLCT", param);
            if (DAL.Struc.dt.Rows.Count > 0)
            {
                //DAL.Struc.dt.PrimaryKey = new DataColumn[] { DAL.Struc.dt.Columns[0] };
                attchtbl = DAL.Struc.dt.Copy();
                DAL.Struc.dt.Columns.RemoveAt(11);
                DAL.Struc.dt.Columns.RemoveAt(10);
                //attchtbl.PrimaryKey = new DataColumn[] { attchtbl.Columns[0] };
                attchtbl.Columns.RemoveAt(9);
                attchtbl.Columns.RemoveAt(8);
                attchtbl.Columns.RemoveAt(7);
                attchtbl.Columns.RemoveAt(6);
                attchtbl.Columns.RemoveAt(5);
                attchtbl.Columns.RemoveAt(4);
                attchtbl.Columns.RemoveAt(3);
                attchtbl.Columns.RemoveAt(2);
                attchtbl.Columns.RemoveAt(1);

                attchtbl.DefaultView.RowFilter = "[AttchImg] is not null";
                DAL.Struc.dt.Columns.Add("File");
                if (attchtbl.DefaultView.Count > 0)
                {

                    for (int i = 0; i < attchtbl.DefaultView.Count; i++)
                    {
                        DataRow DRW = function.DRW(DAL.Struc.dt, attchtbl.DefaultView[i][0], DAL.Struc.dt.Columns[0]);
                        int Rowindex_ = DAL.Struc.dt.Rows.IndexOf(DRW);
                        DAL.Struc.dt.Rows[Rowindex_][10] = "✅";
                    }
                }
                DAL.Struc.dt.PrimaryKey = new DataColumn[] { DAL.Struc.dt.Columns[0] };

                //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                DAL.Struc.dt.Columns.Add("عدد أيام عمل", typeof(string)).SetOrdinal(2);
                TikUpdate.getTikupdatefrm.GridUpdt.DataSource = DAL.Struc.dt;
                DAL.Struc.dt.DefaultView.RowFilter = "EvSusp = 0 and TkupUser = " + currntTicket._TkEmpNm;
                function fn = function.getfn;
                DAL.Struc.dt.DefaultView.Sort = "TkupSTime ASC";
                for (int i = 0; i < DAL.Struc.dt.DefaultView.Count; i++)
                {
                    if (i == 0)
                    {
                        DAL.Struc.dt.DefaultView[i]["عدد أيام عمل"] = "(" + fn.CalDate(Convert.ToString(currntTicket._TkDtStart), Convert.ToString(DAL.Struc.dt.DefaultView[i]["TkupSTime"])) + ")";
                    }
                    else
                    {
                        DAL.Struc.dt.DefaultView[i]["عدد أيام عمل"] = fn.CalDate(Convert.ToString(DAL.Struc.dt.DefaultView[i - 1]["TkupSTime"]), Convert.ToString(DAL.Struc.dt.DefaultView[i]["TkupSTime"]));
                    }
                }
                DAL.Struc.dt.DefaultView.RowFilter = string.Empty;
                DAL.Struc.dt.DefaultView.Sort = "TkupSTime desc";
                //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

                if (currntTicket._TkKind.Equals("شكوى", StringComparison.OrdinalIgnoreCase))
                {
                    TikUpdate.getTikupdatefrm.Text = "تحديثات شكوى رقم : " + currntTicket._TkSQL;
                }
                else
                {
                    TikUpdate.getTikupdatefrm.Text = "تحديثات طلب رقم : " + currntTicket._TkSQL;
                }
                TikUpdate.getTikupdatefrm.Text += " _ عدد التحديثات : " + DAL.Struc.dt.Rows.Count;
                TikUpdate.getTikupdatefrm.CmbEvent.DataSource = Statcdif.UpdateKTable;
                TikUpdate.getTikupdatefrm.CmbEvent.DisplayMember = "EvNm";
                TikUpdate.getTikupdatefrm.CmbEvent.ValueMember = "EvId";
                TikUpdate.getTikupdatefrm.CmbEvent.SelectedValue = -1;
                TikUpdate.getTikupdatefrm.TxtUpdt.Text = "";
                TikUpdate.getTikupdatefrm.TxtUpdt.ReadOnly = true;
                TikUpdate.getTikupdatefrm.CmbEvent.SelectedIndexChanged += new System.EventHandler(TikUpdate.getTikupdatefrm.CmbEvent_SelectedIndexChanged);
                TikUpdate.getTikupdatefrm.GridUpdt.Columns[10].DefaultCellStyle.Font = new Font("Lucida Handwriting", 16, FontStyle.Bold);
                eventColor();
            }
            else
            {
                function fn = function.getfn;
                TikUpdate.getTikupdatefrm.Close();
                fn.msg("لاتوجد هناك تحديثات للعرض", "تحميل التحديثات", MessageBoxButtons.OK);

            }
        }
        public static void eventColor()
        { //  foreach (DataGridViewRow item in TikUpdate.getTikupdatefrm.GridUpdt.Rows)
            foreach (DataGridViewColumn item in TikUpdate.getTikupdatefrm.GridUpdt.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewRow item in TikUpdate.getTikupdatefrm.GridUpdt.Rows)
            {
                if (Convert.ToInt32(item.Cells["TkupEvtId"].Value) == 902)
                {
                    //item.DefaultCellStyle.BackColor = Color.Red;
                    item.DefaultCellStyle.ForeColor = Color.Red;
                }
                else if (Convert.ToBoolean(item.Cells["EvSusp"].Value) == true)
                {
                    item.DefaultCellStyle.BackColor = Settings.Default.ClrSys;
                }
                else if (Convert.ToInt32(item.Cells["TkupUser"].Value) == currntTicket._TkEmpNm)
                {
                    //if (item.Cells["عدد أيام عمل"].Value.ToString().Split('_').Count() > 1)
                    //{
                    //    if (item.Cells["عدد أيام عمل"].Value.ToString().Split('_')[0] == "1")
                    //    {
                    //        item.Cells["عدد أيام عمل"].Value = item.Cells["عدد أيام عمل"].Value.ToString().Split('_')[1];
                    //        item.Cells["عدد أيام عمل"].Tag = "First";
                    //        item.DefaultCellStyle.BackColor = Color.Yellow;
                    //    }
                    //}
                    if (item.Cells["عدد أيام عمل"].Value.ToString().Split('(').Count() > 1)
                    {
                        item.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        item.DefaultCellStyle.BackColor = Settings.Default.ClrUsr;
                    }

                }
                else if (Convert.ToInt32(item.Cells["TkupUser"].Value) != currntTicket._TkEmpNm)
                {
                    if (Convert.ToInt32(item.Cells["UCatLvl"].Value) >= 3 && Convert.ToInt32(item.Cells["UCatLvl"].Value) <= 5)
                    {
                        item.DefaultCellStyle.BackColor = Settings.Default.ClrSamCat;
                    }
                    else if (Convert.ToInt32(item.Cells["UCatLvl"].Value) == 200)
                    {
                        item.DefaultCellStyle.BackColor = Settings.Default.ClrOperation;
                    }
                    else
                    {
                        item.DefaultCellStyle.BackColor = Settings.Default.ClrNotUsr;
                    }
                }
                if (Convert.ToBoolean(item.Cells["TkupUnread"].Value) == false)
                {
                    item.DefaultCellStyle.Font = new Font("Times New Roman", 16, FontStyle.Bold);
                }

            }
            TikUpdate.getTikupdatefrm.GridUpdt.AutoResizeColumns();
            TikUpdate.getTikupdatefrm.GridUpdt.Columns["TkupTxt"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            TikUpdate.getTikupdatefrm.GridUpdt.Columns["TkupTxt"].Width = TikUpdate.getTikupdatefrm.GridUpdt.Width - (TikUpdate.getTikupdatefrm.GridUpdt.Columns["TkupSTime"].Width + TikUpdate.getTikupdatefrm.GridUpdt.Columns["عدد أيام عمل"].Width + TikUpdate.getTikupdatefrm.GridUpdt.Columns["EvNm"].Width + TikUpdate.getTikupdatefrm.GridUpdt.Columns["EvNm"].Width + TikUpdate.getTikupdatefrm.GridUpdt.Columns["UsrRealNm"].Width);
            TikUpdate.getTikupdatefrm.GridUpdt.AutoResizeRows();
        }
        public static string addevent(int id, string txt,  int EvId, string IP, int user, [Optional] string UpdateSTR, [Optional] byte[] attach, [Optional] string Ext)
        {
            string rslt = null;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SP_TICKET_EVENT_INSERT";
            SqlConnection con = new SqlConnection(Statcdif.strConn);
            sqlcmd.Connection = con;
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@TkupTkSql", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@TkupTxt", SqlDbType.NVarChar);
            param[1].Value = txt;
            param[2] = new SqlParameter("@TkupEvtId", SqlDbType.Int);
            param[2].Value = EvId;
            param[3] = new SqlParameter("@TkupUserIP", SqlDbType.NVarChar, 15);
            param[3].Value = IP;
            param[4] = new SqlParameter("@TkupUser", SqlDbType.Int);
            param[4].Value = user;
            param[5] = new SqlParameter("@UpdateStatement", SqlDbType.NVarChar);
            param[5].Value = UpdateSTR;
            param[6] = new SqlParameter("@TkupAttch", SqlDbType.Image);
            param[6].Value = attach;
            param[7] = new SqlParameter("@Extention", SqlDbType.NVarChar, 10);
            param[7].Value = Ext;
            for (int i = 0; i < param.Length; i++)
            {
                sqlcmd.Parameters.Add(param[i]);
            }
            try
            {
                con.Open();
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                rslt = Ex.Message;
                function fn = function.getfn;
                fn.msg("لم يتم إضافة التحديث", "إضافة تحديث جديد", MessageBoxButtons.OK);
            }
            return rslt;
        }
    }
}
