using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class ClassList : System.Web.UI.Page
    {

        public Person loggedInPerson;

        public ClassManager classManager;

        public UserMan userManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            classManager = new ClassManager();
            userManager = new UserMan();

            loggedInPerson = (Person) Session["person"];

        }
    }
}