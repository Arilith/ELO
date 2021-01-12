using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;
using ELO.Managers;

namespace Front_End
{
    public partial class GradeList : System.Web.UI.Page
    {
        public GradeMan gradeMan;
        public Person LoggedInPerson;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInPerson = (Person)Session["person"];
            gradeMan = new GradeMan();
        }
    }
}