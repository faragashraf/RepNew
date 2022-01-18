using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using VOCAC.Properties;
using System.Windows.Forms;

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
                DAL.Struc = DAL.SelectData("SP_USR_LOG_SLCT_UPDATE", param);
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
            DataColumn primaryKey = new DataColumn();
            primaryKey = Statcdif.ProdKTable.Columns["ProdKNm"];
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
        public DAL.DataAccessLayer.rturnStruct TeamTree(bool Stat)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Stat", SqlDbType.Bit);
            param[0].Value = Stat;

            DAL.Struc = DAL.SelectData("SP_MyTeam_SLCT", param);
            DAL.Close();
            return DAL.Struc;
        }
        public DAL.DataAccessLayer.treeStruct MyTeam(int LedrCat, int LedrId, String UsrCase, bool Stat)
        {
            DAL.DataAccessLayer.treeStruct treestruc = new DAL.DataAccessLayer.treeStruct();
            List<string> UsrStr = new List<string>();
            TreeNode[] TempNode = new TreeNode[0];
            TreeView TreeTemp = new TreeView();

            TreeTemp.Nodes.Add(LedrCat.ToString(), LedrId.ToString());

            DAL.DataAccessLayer.rturnStruct SlctTeamReslt = TeamTree(Stat);

            UsrStr.Add(CurrentUser.UsrID.ToString());
            if (this.TeamTree(Stat).msg == null)
            {
                SlctTeamReslt.dt.DefaultView.RowFilter = "UCatIdSub >= " + CurrentUser.UsrUCatLvl;
                for (int i = 0; i < SlctTeamReslt.dt.DefaultView.Count; i++)
                {
                    TempNode = TreeTemp.Nodes.Find(SlctTeamReslt.dt.DefaultView[i][2].ToString(), true);
                    if (TempNode.Length > 0)
                    {
                        TempNode[0].Nodes.Add(SlctTeamReslt.dt.DefaultView[i][1].ToString(), SlctTeamReslt.dt.DefaultView[i][0].ToString());
                        UsrStr.Add(SlctTeamReslt.dt.DefaultView[i][0].ToString());
                    }
                }
            }
            treestruc.msg = UsrCase + " in (" + string.Join(", ", UsrStr) + ")";
            treestruc.tree = TreeTemp;
            return treestruc;
        }
    }
}
