using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOCAC.PL
{
    public partial class UserResetPassword : Form
    {
        public UserResetPassword()
        {
            InitializeComponent();
            this.Size = new Size(Statcdif.screenWidth - 100, Statcdif.screenHeight - 100);
            this.UsrData.Size = new Size(UsrData.Size.Width, this.Size.Height - 100);
        }

        private void UserResetPassword_Load(object sender, EventArgs e)
        {
            function fn = function.getfn;
            DataTable tbl = new DataTable();
            tbl = fn.returntbl("SELECT UsrId, UsrNm, UsrRealNm, UsrSusp, UCatNm FROM Int_user INNER JOIN IntUserCat ON Int_user.UsrCat = IntUserCat.UCatId");
            UsrData.DataSource = tbl;
        }
    }
}
