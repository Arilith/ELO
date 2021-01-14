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
    public partial class SubjectList : System.Web.UI.Page
    {
        public Person loggedInPerson;
        public UserMan userManager;
        public SubjectManager subjectManager;
        public Student loggedInStudent;
        protected void Page_Load(object sender, EventArgs e)
        {
            loggedInPerson = (Person)Session["person"];
            userManager = new UserMan();
            subjectManager = new SubjectManager();

            if (loggedInPerson != null && loggedInPerson.Type == "Student")
                loggedInStudent = (Student) loggedInPerson;
        }


    }
}