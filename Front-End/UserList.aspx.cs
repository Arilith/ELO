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
        public ClassManager classManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            usermanager = new UserMan();
            classManager = new ClassManager();
            loggedInPerson = (Person)Session["person"];
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}