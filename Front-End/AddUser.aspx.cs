using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class AddUser : System.Web.UI.Page
    {

        public UserMan userManager;
        public ClassManager classManager;
        public Person loggedInUser;
        protected void Page_Load(object sender, EventArgs e)
        {

            loggedInUser = (Person)Session["person"];
            userManager = new UserMan();
            classManager = new ClassManager();

            if(IsPostBack)
            {

                string studentName = Request.Form["name"];
                string password = Request.Form["password"];
                string email = Request.Form["email"];
                int leerlingnummer = Convert.ToInt32(Request.Form["leerlingnummer"]);
                string postClass = Request.Form["class"];

                ErrorLabel.Text = userManager.AddStudentToDataBase(leerlingnummer, password, studentName, email, postClass, loggedInUser);
            }
        }




    }
}