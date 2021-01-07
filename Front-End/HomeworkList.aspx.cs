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
    public partial class HomeworkList : System.Web.UI.Page
    {
        public HwMan HomeworkManager;
        public Person LoggedInPerson;
        public Student LoggedInStudent;
               protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInPerson = (Person) Session["person"];
            LoggedInStudent = (Student) LoggedInPerson;

            HomeworkManager = new HwMan();
        }
    }
}