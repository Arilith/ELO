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

        private UserMan userManager;
        public SubjectManager subjectManager;
        public ClassManager classManager;

        public Person loggedInPerson;

        protected void Page_Load(object sender, EventArgs e)
        {
            userManager = new UserMan();
            classManager = new ClassManager();
            subjectManager = new SubjectManager(); 
            loggedInPerson = (Person)Session["person"];

            if (IsPostBack)
            {

                userManager.AddTeacherToDataBase(Request.Form["username"], Request.Form["password"], loggedInPerson, Request.Form["name"], Request.Form["email"], Request.Form["subject"], Request.Form["class"]);

                OutputLabel.Text = "Docent Succesvol toegevoegd!";
            }
        }

    }
}