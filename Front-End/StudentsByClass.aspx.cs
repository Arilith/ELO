using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class StudentsByClass : System.Web.UI.Page
    {
        public ClassManager classManager;
        public UserMan userManager;

        public Person loggedInPerson;
        protected void Page_Load(object sender, EventArgs e)
        {
            classManager = new ClassManager();
            userManager = new UserMan();

            loggedInPerson = (Person) Session["person"];

            if (IsPostBack && Request.Form["mentor"] != null)
            {
                string classUUID = Request.Form["class"];
                string mentorUUID = Request.Form["mentor"];
                //Add mentor to class
                classManager.UpdateMentor(classUUID, mentorUUID);
                OutputLabel.Text = "Mentor geupdated.";
            }

        }
    }
}