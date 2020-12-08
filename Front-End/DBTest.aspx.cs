using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;
using ELO.SQLClasses;

namespace Front_End
{
    public partial class DBTest : System.Web.UI.Page
    {
        UserSQL userSQL;
 
        protected void Page_Load(object sender, EventArgs e)
        {
            userSQL = new UserSQL();
            Label1.Text = userSQL.ReadUser();
        }
    }
}