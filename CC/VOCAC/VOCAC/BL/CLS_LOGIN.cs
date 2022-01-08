using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using VOCAC.Properties;

namespace VOCAC.BL
{
    class CLS_LOGIN
    {
        public DAL.DataAccessLayer.myStruct LOGIN(String ID, String PWD)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Struc.msg = null;
            DAL.Struc.dt = null;
            DAL.Struc.ds = null;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 30);
            param[0].Value = ID;
            param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 100);
            param[1].Value = PWD;
            DataTable Dt = new DataTable();
            try
            {
                DAL.Struc = DAL.SelectData("SP_USR_LOGIN_SLCT", param);
            }
            catch (Exception ex)
            {
                DAL.Struc.msg = ex.Message;
            }
            DAL.Close();
            return DAL.Struc;
        }
        public DAL.DataAccessLayer.myStruct int_Access(int usrid, string usrNm, string Stat, string ip)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Struc.msg = null;
            DAL.Struc.dt = null;
            DAL.Struc.ds = null;
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = usrid;
            param[1] = new SqlParameter("@UsrNm", SqlDbType.VarChar, 30);
            param[1].Value = usrNm;
            param[2] = new SqlParameter("@Stat", SqlDbType.VarChar, 2);
            param[2].Value = Stat;
            param[3] = new SqlParameter("@IP", SqlDbType.VarChar, 15);
            param[3].Value = ip;
            DAL.Open();
            DAL.Struc = DAL.ExcuteCommand("SP_USR_ACCESS_LOG_INSERT", param);
            if (DAL.Struc.msg == null){}
            else
            {
                function fn = function.getfn;
                fn.msg(Resources.ConnErr + Environment.NewLine + Resources.TryAgain, "Access Log");
            }
            DAL.Close();
            return DAL.Struc;
        }
        public DAL.DataAccessLayer.myStruct UsrUpdate(string ip, string Ver, int usrid)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Struc.msg = null;
            DAL.Struc.dt = null;
            DAL.Struc.ds = null;
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@IP", SqlDbType.VarChar, 15);
            param[0].Value = ip;
            param[1] = new SqlParameter("@Ver", SqlDbType.VarChar, 15);
            param[1].Value = Ver;
            param[2] = new SqlParameter("@ID", SqlDbType.Int);
            param[2].Value = usrid;
            DAL.Open();
            DAL.Struc = DAL.ExcuteCommand("SP_USR_ACTIVATE_UPDATE", param);
            if (DAL.Struc.msg == null) { }
            else
            {
                function fn = function.getfn;
                fn.msg(Resources.ConnErr + Environment.NewLine + Resources.TryAgain, "Update User");
            }
                DAL.Close();
            return DAL.Struc;
        }
        public DAL.DataAccessLayer.myStruct slctmaintbls()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataSet ds = new DataSet();
            DAL.Struc = DAL.SelectMainDs("SP_MAINTBL_SLCT");
            DAL.Close();
            return DAL.Struc;
        }
        public DAL.DataAccessLayer.myStruct SwtchBoard()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            DAL.Struc = DAL.SwitchBoard("SP_SwitchBoard_SLCT");
            DAL.Close();
            DataColumn primaryKey, primaryKey1 = new DataColumn();
            primaryKey = Statcdif.CountryTable.Columns["CounCd"];
            primaryKey1 = Statcdif.ProdKTable.Columns["ProdKNm"];
            return DAL.Struc;
        }
    }
}
