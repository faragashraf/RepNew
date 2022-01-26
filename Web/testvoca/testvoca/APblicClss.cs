using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace VOCAC
{
    //Application Definitions With Current User Class Inheritance
    public class Statcdif
    {

        public static string strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=sa;Password=Hemonad105046";
        public SqlConnection CONSQL;
        public static String _ServerCD;
        public static String _serverNm;
        public static string servrTime;
        public static String _MacStr, _IP;
        public static List<string> FildList = new List<string>();
        public static bool bolyy = false;
        public static bool CncStat;

        #region DataTables
        public static DataTable MacTble, UserTable;
        public static System.Web.UI.WebControls.TreeView _tree;
        public static DataTable CompSurceTable, ProdKTable, ProdCompTable, UpdateKTable, CDHolDay, MendFildsTable, MendPvtTable, TreeUsrTbl;

        #endregion
    }
    public class defintions
    {
        #region SQL_Definition

        public SqlDataReader reader;
        public SqlDataAdapter sqladptr;
        public SqlCommand SqlComm;
        #endregion
        public Thread thread_;
    }
    //Application Functions With Definitions Class Inheritance
    public sealed class function : Statcdif
    {
        private static readonly Lazy<function> fn = new Lazy<function>(() => new function());
        public static function getfn
        {
            get
            {
                return fn.Value;
            }
        }
        private function()
        {

        }
        public string ElapsedTimeSpan;
        public bool CheckConnection()                                                                        //Check Connection
        {
            Statcdif defstac = new Statcdif();
            defstac.CONSQL = new SqlConnection(strConn);
            //if (defstac.CONSQL != null)
            //{
            if (defstac.CONSQL.State == ConnectionState.Closed)
            {
                try
                {
                    if (defstac.CONSQL.State == ConnectionState.Closed)
                    {
                        defstac.CONSQL.Open();
                        CncStat = true;
                    }
                }
                catch (SqlException Ex)
                {
                    CncStat = false;
                    AppLog("1002&H", Ex.Message, "Trying To Open Connection");
                }
            }
            else
            {
                CncStat = true;
            }
            defstac.CONSQL.Close();
            SqlConnection.ClearPool(defstac.CONSQL);
            return CncStat;
        }
        public string Gettable(String SSqlStr, DataTable SqlTbl, String ErrHndl)                             //Get Data and Fill DataTable
        {
            defintions def = new defintions();
            Statcdif defstac = new Statcdif();
            string Msg = null;
            Stopwatch Stp = new Stopwatch();
            defstac.CONSQL = new SqlConnection(strConn);
            def.sqladptr = new SqlDataAdapter(SSqlStr, defstac.CONSQL);
            Stp.Start();
            try
            {
                if (defstac.CONSQL.State == ConnectionState.Closed)
                {
                    defstac.CONSQL.Open();
                }
                def.sqladptr.Fill(SqlTbl);
                TimeSpan TimSpn = (Stp.Elapsed);
                Stp.Stop();
                this.ElapsedTimeSpan = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds);
            }
            catch (Exception Ex)
            {
                Msg = Ex.Message;
                AppLog(" ", Ex.Message, SSqlStr);
            }
            def.sqladptr.Dispose();
            defstac.CONSQL.Close();
            SqlConnection.ClearPool(defstac.CONSQL);
            return Msg;
        }
        public List<DataTable> Gettable(String SSqlStr, List<DataTable> LstDTbl, String ErrHndl)             //Get Data and Fill List of DataTable
        {
            defintions def = new defintions();
            Statcdif defstac = new Statcdif();
            Stopwatch Stp = new Stopwatch();
            defstac.CONSQL = new SqlConnection(strConn);
            Stp.Start();
            try
            {
                string[] Str = SSqlStr.Split('$');
                for (int i = 0; i < Str.Length - 1; i++)
                {
                    if (defstac.CONSQL.State == ConnectionState.Closed)
                    {
                        defstac.CONSQL.Open();
                    }
                    def.sqladptr = new SqlDataAdapter(Str[i], defstac.CONSQL);
                    DataTable dd = LstDTbl[i];
                    def.sqladptr.Fill(LstDTbl[i]);
                }
                TimeSpan TimSpn = (Stp.Elapsed);
                Stp.Stop();
                this.ElapsedTimeSpan = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimSpn.Hours, TimSpn.Minutes, TimSpn.Seconds, TimSpn.Milliseconds);
            }
            catch (Exception Ex)
            {
                AppLog(" ", Ex.Message, SSqlStr);
            }
            defstac.CONSQL.Close();
            SqlConnection.ClearPool(defstac.CONSQL);
            return LstDTbl;
        }
        public string InsUpdate(String SSqlStr, String ErrHndl)
        {
            defintions def = new defintions();
            Statcdif defstac = new Statcdif();
            string Errmsg = null;
            Stopwatch Stp = new Stopwatch();
            defstac.CONSQL = new SqlConnection(strConn);
            def.SqlComm = new SqlCommand(SSqlStr, defstac.CONSQL);
            def.SqlComm.CommandType = CommandType.Text;
            Stp.Start();
            try
            {
                if (defstac.CONSQL.State == ConnectionState.Closed)
                {
                    defstac.CONSQL.Open();
                }
                def.SqlComm.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Errmsg = Ex.Message;
                AppLog(" ", Ex.Message, SSqlStr);
            }
            def.SqlComm.Dispose();
            defstac.CONSQL.Close();
            SqlConnection.ClearPool(defstac.CONSQL);
            return Errmsg;
        }
        public string OsIP()                                                                                 //Get User IP Address
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            string address = localIPs.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).Select(_ip => _ip.ToString()).First();
            return address;
        }
        public string GetMACAddressNew()                                                                     //Get User MAC Address
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty && adapter.OperationalStatus == OperationalStatus.Up)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return sMacAddress;
        }
        public string ServrTime()
        {
            DataTable TimeTbl = new DataTable();
            if (Gettable("Select GetDate() as Now_", TimeTbl, "1003&H") == null)
            {
                servrTime = TimeTbl.Rows[0].Field<DateTime>("Now_").ToString(); // TimeTbl.Rows[0].Field<DateTime>("Now_");
            }
            return servrTime;
        }
        public void AppLog(String ErrHndls, String LogMsg, String SSqlStrs)                                  //Insert Exception Into Log FIle
        {
            string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VOCALog" + Convert.ToDateTime(DateTime.Now).ToString("MM-yy") + ".Vlg";
            string _content = DateTime.Now + " ," + ErrHndls + LogMsg + " &H" + SSqlStrs + Environment.NewLine;
            File.AppendAllText(_path, _content);
        }
        public void msg(string Messd, string titl, MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK, MessageBoxOptions messageBoxOptions = MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign)
        {
            MessageBox.Show(Messd, titl, messageBoxButtons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, messageBoxOptions);
        }
        public int CalDate(string StDt, string EnDt)
        {
            Statcdif.CDHolDay.DefaultView.RowFilter = "HDate >= '" + StDt + "' and HDate <= '" + EnDt + "'";
            int Wdays = Statcdif.CDHolDay.DefaultView.Count;
            return Wdays;
        }
        public void ClorTxt(RichTextBox richtxtbx, String Strng, Color backClr, Color FontClr, int fontsize)
        {
            try
            {
                int starttxt = 0;
                int endtxt;
                endtxt = richtxtbx.Text.LastIndexOf(Strng);
                while (starttxt < endtxt)
                {
                    if (richtxtbx.Find(Strng, starttxt, richtxtbx.TextLength, RichTextBoxFinds.None) > 0)
                    {
                        richtxtbx.SelectionBackColor = backClr;
                        richtxtbx.SelectionColor = FontClr;
                        richtxtbx.SelectionFont = new Font("Times new Roman", fontsize, FontStyle.Bold);
                    }
                    starttxt += 1;
                }

            }
            catch (Exception )
            {

                throw;
            }
        }
    }
    // Current User Class
    public static class CurrentUser
    {
        public static int UsrID = 0;          //UsrId
        public static int UsrCat;         //UsrCat
        public static String UsrNm;        //UsrNm
        public static String UsrPWrd;       //UsrPass
        public static String UsrLvl;      //UsrLevel
        public static String UsrRlNm;    //UsrRealNm
        public static String UsrMail;   //UsrEmail
        public static String UsrSisco;  //UsrSisco
        public static String UsrGsm;  //UsrMobile
        public static String UsrGndr;    //UsrGender
        public static Boolean UsrActv;   //UsrActive(Yes/No)
        public static DateTime UsrLstS;    //UsrLastSeen
        public static bool UsrSusp;   //UsrSusp(Yes/No)
        public static int UsrTcCnt;       //UsrTkCount
        public static String UsrSltKy;  //SaltKey
        public static String UsrCatNm;    //Catagory name
        public static Boolean UsrCalCntr;     //Call Center
        public static Int16 UsrUCatLvl;     //Close Count
        public static int UsrFlN;         //Follow Count
        public static int UsrClsN;    //Open Count
        public static int UsrReOpY;   //ReOpen Count
        public static int UsrUnRead;  //Read Count
        public static int UsrEvDy;    //Enent Count
        public static int UsrReadYDy;  //Read Count
        public static int UsrClsYDy;      //Close Count
        public static int UsrRecvDy;      //Recieved Count
        public static int UsrClsUpdtd;    //Closed updated Count
        public static int UsrFolwDay;     //Followed Tickets Count
        public static string UsrTeam;     //User Team Agents IDs 
        public static string Usrpath;     //User tree path 
    }
    public class frms
    {
        //Return All any form control
        public IEnumerable<Control> GetAll(Control control)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl))
                                      .Concat(controls);
        }
        //Return All any form control where exact type condition
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
    }
}

