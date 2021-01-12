using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class AddTeacher : System.Web.UI.Page
    {

        public UserMan userManager;
        public SchoolManager schoolManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            userManager = new UserMan();
            schoolManager = new SchoolManager();

            if (IsPostBack)
            {
                Person loggedInPerson = (Person)Session["person"];

                userManager.AddTeacherToDataBase(Request.Form["username"], Request.Form["password"], loggedInPerson, Request.Form["name"], Request.Form["email"], Convert.ToInt32(Request.Form["exp"]));

                OutputLabel.Text = "Docent Succesvol toegevoegd!";
            }
        }

    }
}