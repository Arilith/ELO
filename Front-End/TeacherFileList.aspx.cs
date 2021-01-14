using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class TeacherFileList : System.Web.UI.Page
    {
        public Person loggedInPerson;

        public Teacher loggedInTeacher;

        public FileManager FileManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            loggedInPerson = (Person)Session["person"];

            if (loggedInPerson != null && loggedInPerson.Type == "Teacher")
                loggedInTeacher = (Teacher) loggedInPerson;

            FileManager = new FileManager();
        }
    }
}