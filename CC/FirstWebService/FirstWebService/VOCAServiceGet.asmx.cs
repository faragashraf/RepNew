using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace FirstWebService
{
    /// <summary>
    /// Summary description for VOCAServiceGet
    /// </summary>
    [WebService(Namespace = "http://10.10.26.4:8000/vocaservice")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class VOCAServiceGet : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true, XmlSerializeString = false)]
        public PostOff[] GetOff()
        {
            DataTable table = GetDataTable_("select  [OffFinCd],[OffNm1],[OffArea],[OFFICE_ID] from postoff");
            PostOff[] lst = new PostOff[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                PostOff off = new PostOff();
                off.OffFinCd = table.Rows[i][0].ToString();
                off.OffNm1 = table.Rows[i][1].ToString();
                off.OffArea = table.Rows[i][2].ToString();
                off.OfficeId = table.Rows[i][3].ToString();
                lst[i] = off;
            }
            foreach (DataRow row in table.Rows)
            {

            }
            return lst;
        }

        public DataTable GetDataTable_(string STR)
        {
            DataAccessLayer DAL = new DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@slctstat", SqlDbType.NVarChar);
            param[0].Value = STR;
            DAL.Struc = DAL.SelectData("SP_CHOICE_SLCT", param);
            DAL.Struc.dt.TableName = "Tbl";
            return DAL.Struc.dt;
        }

    }
}
