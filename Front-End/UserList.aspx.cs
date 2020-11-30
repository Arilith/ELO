using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class UserList : System.Web.UI.Page
    {
        public UserMan userMan;
        public ClassManager classMan;
        protected void Page_Load(object sender, EventArgs e)
        {
            userMan = new UserMan();
            classMan = new ClassManager();
            userMan.AddTeacherToPersonList("Rob Broeren", 67, "Markland College",  true, "Engels", classMan.GetClass(0));
            userMan.AddTeacherToPersonList("Jos Antens", 50, "Markland College",  true, "Lichamelijke Opvoeding", classMan.GetClass(1));
            userMan.AddTeacherToPersonList("Tristan van der Wal", 32, "Markland College",  true, "Economie", classMan.GetClass(2));
            
            userMan.AddStudentToPersonList("Tristan van Triest", 18, "Markland College",  classMan.GetClass(0), userMan.GetTeacher("Tristan van der Wal"));
            userMan.AddStudentToPersonList("Christian Schets", 18, "Markland College", classMan.GetClass(1), userMan.GetTeacher("Rob Broeren"));
            userMan.AddStudentToPersonList("Remco Broos", 18, "Markland College",classMan.GetClass(2), userMan.GetTeacher("Jos Antens"));

        }
    }
}