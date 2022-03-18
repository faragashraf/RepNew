using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FirstWebService
{
    public class DataAccessLayer
    {
        public rturnStruct Struc;
        public struct rturnStruct
        {
            public string msg;
            public DataTable dt;
            public DataSet ds;
            public int returnInt_;
        }
        SqlConnection sqlconnection;
        //This Constructor Insialize the connection Object
        public DataAccessLayer()
        {
            //"Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocac;Password=Hemonad105046";
            //@"Data Source = MyThinkbook\ASHRAFSQL; Initial Catalog = VOCAPlus; Persist Security Info = True; User ID = sa; Password = Hemonad105046")
            sqlconnection = new SqlConnection(Statcdif.strConn);
        }
        //Method to Open connection
        public void Open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                try
                {
                    sqlconnection.Open();
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    function.AppLog(ex.Message + "$" + ex.InnerException, ex.HResult.ToString(), "Error On Open Connection");
                }
            }
        }
        //Method to Close connection
        public void Close()
        {
            if (sqlconnection.State == ConnectionState.Open)
            {
                try
                {
                    sqlconnection.Close();
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    function.AppLog(ex.Message + "$" + ex.InnerException, ex.HResult.ToString(), "Error On Close Connection");
                }
            }
        }
        //Method to Read Data  From Database
        public rturnStruct SelectData(string Stored_Procedure, SqlParameter[] param)
        {
            Struc.msg = null;
            Struc.ds = null;
            Struc.dt = null;
            Struc.returnInt_ = 0;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            sqlcmd.Connection = sqlconnection;
            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            Struc.dt = new DataTable();
            try
            {
                da.Fill(Struc.dt);
            }
            catch (Exception ex)
            {
                Struc.dt = null;
                Struc.msg = ex.Message;
                function.AppLog(ex.Message + "$" + ex.InnerException, ex.HResult.ToString(), Stored_Procedure);
            }
            return Struc;
        }
        //Method to Insert,Update and Delete Data From Database
        public rturnStruct ExcuteCommand(string Stored_Procedure, SqlParameter[] param)
        {
            Struc.msg = null;
            Struc.ds = null;
            Struc.dt = null;
            Struc.returnInt_ = 0;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            sqlcmd.Connection = sqlconnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            try
            {
                Open();
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Struc.msg = ex.Message;
                function.AppLog(ex.Message + "$" + ex.InnerException, ex.HResult.ToString(), Stored_Procedure);
            }
            Close();
            return Struc;
        }
        //Method to Read Data From Database And Return A Dataset
        public rturnStruct SelectDataset(string Stored_Procedure)
        {
            Struc.msg = null;
            Struc.ds = null;
            Struc.dt = null;
            Struc.returnInt_ = 0;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            sqlcmd.Connection = sqlconnection;

            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            Struc.ds = new DataSet();
            try
            {
                da.Fill(Struc.ds);
            }
            catch (Exception ex)
            {
                Struc.msg = ex.Message;
                function.AppLog(ex.Message + "$" + ex.InnerException, ex.HResult.ToString(), Stored_Procedure);
            }
            Close();
            return Struc;
        }
    }
}