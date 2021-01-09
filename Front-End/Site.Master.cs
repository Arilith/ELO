using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class SiteMaster : MasterPage
    {
        public Person loggedInPerson;
        public Student loggedInStudent;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["person"] != null)
            {
                loggedInPerson = (Person) Session["person"];
                if (loggedInPerson.Type == "Student")
                {
                    loggedInStudent = (Student)loggedInPerson;
                    loggedInPerson = (Student)loggedInPerson;
                }
                else if (loggedInPerson.Type == "Teacher")
                    loggedInPerson = (Teacher) loggedInPerson;
            }
        }
    }
}