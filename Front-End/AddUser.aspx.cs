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
    public partial class AddUser : System.Web.UI.Page
    {
        private UserMan userMan;
        private ClassManager classMan;

        protected void Page_Load(object sender, EventArgs e)
        {
            userMan = new UserMan();

            if(IsPostBack)
            {
                ConvertAndInsertData();
            }
        }

        private void ConvertAndInsertData()
        {
            //Add validation / HTMLSpecialchars?

            string studentName = Request.Form["name"];
            int age = Convert.ToInt32(Request.Form["age"]);
            string school = Request.Form["school"];
            string mentor = Request.Form["mentor"];
            string klas = Request.Form["klas"];

            Teacher mentorTeacher = (Teacher)userMan.GetPersonList().Find(x => x.Name == mentor);

            //userMan.AddStudentToPersonList();
            Label1.Text = Request.Form["name"];
        }
    }
}