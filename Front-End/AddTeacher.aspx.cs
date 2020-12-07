using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class AddTeacher : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ConvertAndInsertData();
            }
        }

        private void ConvertAndInsertData()
        {

            string teacherName = Request.Form["name"];
            int age = Convert.ToInt32(Request.Form["age"]);
            string school = Request.Form["school"];
            Subject subject = Manager.subjectMan.FindSubject(Request.Form["subject"]);


            Class mentorClass = Manager.classMan.GetClass(Request.Form["mentorclass"]);

            if (mentorClass != null)
            {
                Manager.userMan.AddTeacherToPersonList(teacherName, age, school, true, subject, mentorClass);
            }
            else
            {
                Manager.userMan.AddTeacherToPersonList(teacherName, age, school, true, subject);
            }

            

            OutputLabel.Text = "Docent Succesvol toegevoegd!";

        }
    }
}