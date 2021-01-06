using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class AddSubject : System.Web.UI.Page
    {
        public Person loggedInPerson;
        public UserMan userManager;
        public SubjectManager subjectManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            loggedInPerson = (Person)Session["person"];
            userManager = new UserMan();
            subjectManager = new SubjectManager();

            if (IsPostBack)
            {
                subjectManager.AddNewSubjectToDataBase(Request.Form["name"], loggedInPerson.School, Request.Form["teachers"]);
            }
        }
    }
}