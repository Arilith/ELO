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

        public static readonly Class[] ClassList =
        {
            new Class("PD-B-18", 20),
            new Class("PD-B-17", 12),
            new Class("PD-B-16", 24)
        };
        
        protected void Page_Load(object sender, EventArgs e)
        {
            userMan = new UserMan();
            userMan.AddTeacherToPersonList("Rob Broeren", 67, "Markland College",  true, "Engels", ClassList[0]);
            userMan.AddTeacherToPersonList("Jos Antens", 50, "Markland College",  true, "Lichamelijke Opvoeding", ClassList[1]);
            userMan.AddTeacherToPersonList("Tristan van der Wal", 32, "Markland College",  true, "Economie", ClassList[2]);
            
            userMan.AddStudentToPersonList("Tristan van Triest", 18, "Markland College",  ClassList[0], (Teacher)userMan.GetPersonList().Find(x => x.Name == "Tristan van der Wal"));
            userMan.AddStudentToPersonList("Christian Schets", 18, "Markland College", ClassList[1], (Teacher)userMan.GetPersonList().Find(x => x.Name == "Rob Broeren"));
            userMan.AddStudentToPersonList("Remco Broos", 18, "Markland College", ClassList[2], (Teacher)userMan.GetPersonList().Find(x => x.Name == "Jos Antens"));

        }
    }
}