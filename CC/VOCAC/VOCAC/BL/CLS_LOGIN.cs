using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using VOCAC.Properties;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace VOCAC.BL
{
    class CLS_LOGIN
    {
        public DAL.DataAccessLayer.rturnStruct LOGIN(String usrNm, String PWD, string vER, string ip)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Struc.msg = null;
            DAL.Struc.dt = null;
            DAL.Struc.ds = null;
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@usrNm", SqlDbType.VarChar, 30);
            param[0].Value = usrNm;
            param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 100);
            param[1].Value = PWD;
            param[2] = new SqlParameter("@Ver", SqlDbType.VarChar, 15);
            param[2].Value = vER;
            param[3] = new SqlParameter("@IP", SqlDbType.VarChar, 15);
            param[3].Value = ip;
            DataTable Dt = new DataTable();
            try
            {
                DAL.Struc = DAL.SelectData("SP_A_USR_LOG_SLCT_UPDATE", param);
            }
            catch (Exception ex)
            {
                DAL.Struc.msg = ex.Message;
            }
            DAL.Close();
            return DAL.Struc;
        }
        public DAL.DataAccessLayer.rturnStruct slctmaintbls()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Struc = DAL.SelectDataset("SP_MAINTBL_SLCT");
            DAL.Close();
            return DAL.Struc;
        }
        public DAL.DataAccessLayer.rturnStruct SwtchBoard()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = null;
            DAL.Struc = DAL.SelectData("SP_SwitchBoard_SLCT", param);
            DAL.Close();
            return DAL.Struc;
        }
        //public DAL.DataAccessLayer.rturnStruct TeamTree(bool Stat)
        //{
        //    DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
        //    SqlParameter[] param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@Stat", SqlDbType.Bit);
        //    param[0].Value = Stat;

        //    DAL.Struc = DAL.SelectData("SP_MyTeam_SLCT", param);
        //    DAL.Close();
        //    return DAL.Struc;
        //}
    }
}
