using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class Login : System.Web.UI.Page
    {
        
        public SchoolManager schoolManager;
        public UserMan userManager;
        public Person results;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            schoolManager = new SchoolManager();
            userManager = new UserMan();

            if (IsPostBack)
            {
                results = userManager.FindUserInDataBase("", Request.Form["password"], Convert.ToInt32(Request.Form["leerlingnummer"]), Request.Form["school"], "Student");
                Session["person"] = results;
            }

        }
    }
}