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

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                ConvertAndInsertData();
            }
        }

        private void ConvertAndInsertData()
        {

                string studentName = Request.Form["name"];
                int age = Convert.ToInt32(Request.Form["age"]);
                string school = Request.Form["school"];
                string mentor = Request.Form["mentor"];
                string klas = Request.Form["class"];

                Teacher mentorTeacher = Manager.userMan.GetTeacher(mentor);
                Class _class = Manager.classMan.GetClass(klas);

                //Manager.userMan.AddStudentToPersonList(studentName, age, school, _class, mentorTeacher);

                Label1.Text = "leerling Succesvol toegevoegd!";

        }

    }
}