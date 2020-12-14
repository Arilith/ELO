using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;
using ELO.SQLClasses;

namespace Front_End
{
    public partial class UserList : System.Web.UI.Page
    {

        public Person loggedInPerson;
        public UserMan usermanager;

        protected void Page_Load(object sender, EventArgs e)
        {
            usermanager = new UserMan();
            loggedInPerson = (Person)Session["person"];
        }
    }
}