using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOCAC.DAL
{
    class DataAccessLayer
    {
        public myStruct Struc;
        public struct myStruct
        {
            public string msg;
            public DataTable dt;
            public DataSet ds;
        }
        SqlConnection sqlconnection;
        //This Constructor Insialize the connection Object
        public DataAccessLayer()
        {
            //"Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocac;Password=Hemonad105046";
            //@"Data Source = MyThinkbook\ASHRAFSQL; Initial Catalog = VOCAPlus; Persist Security Info = True; User ID = sa; Password = Hemonad105046")
            sqlconnection = new SqlConnection("Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=vocac;Password=Hemonad105046");
        }
        //Method to Open connection
        public void Open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                try
                {
                    sqlconnection.Open();
                }
                catch (Exception Ex)
                {
                    function fn = function.getfn;
                    fn.AppLog(this.ToString(), Ex.Message, "Error On Open Connection");
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
                }
                catch (Exception Ex)
                {
                    function fn = function.getfn;
                    fn.AppLog(this.ToString(), Ex.Message, "Error On Close Connection");
                }
            }
        }
        //Method to Read Data  From Database
        public myStruct SelectData(string Stored_Procedure, SqlParameter[] param)
        {
            Struc.msg = null;
            Struc.ds = null;
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
            catch (Exception Ex)
            {
                Struc.msg = Ex.Message;
                function fn = function.getfn;
                fn.AppLog(this.ToString(), Ex.Message, Stored_Procedure);
            }
            return Struc;
        }
        //Method to Insert,Update and Delete Data From Database
        public myStruct ExcuteCommand(string Stored_Procedure, SqlParameter[] param)
        {
            Struc.msg = null;
            Struc.ds = null;
            Struc.dt = null;
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
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                function fn = function.getfn;
                Struc.msg = Ex.Message;
                fn.AppLog(this.ToString(), Ex.Message, Stored_Procedure);
            }
            return Struc;
        }
        public myStruct SelectMainDs(string Stored_Procedure)
        {
            Struc.msg = null;
            Struc.ds = null;
            Struc.dt = null;
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
            catch (Exception Ex)
            {
                function fn = function.getfn;
                Struc.msg = Ex.Message;
                fn.AppLog(this.ToString(), Ex.Message, Stored_Procedure);
            }
            return Struc;
        }
        public myStruct SwitchBoard(string Stored_Procedure)
        {
            Struc.msg = null;
            Struc.ds = null;
            Struc.dt = null;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            sqlcmd.Connection = sqlconnection;

            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            Struc.dt = new DataTable();
            try
            {
                da.Fill(Struc.dt);
            }
            catch (Exception Ex)
            {
                function fn = function.getfn;
                Struc.msg = Ex.Message;
                fn.AppLog(this.ToString(), Ex.Message, Stored_Procedure);
            }
            return Struc;
        }
    }
}

