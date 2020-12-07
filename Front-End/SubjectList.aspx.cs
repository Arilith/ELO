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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                AddNewSubject();
            }
        }

        private void AddNewSubject()
        {
            //Escape??
            string subjectName = Request.Form["name"];
            string teachers = Request.Form["teachers"];

            Subject newSubject = new Subject(subjectName);

            string[] teacherList = teachers.Split(',');
            foreach (string teacher in teacherList)
            {
                Teacher newTeacher = Manager.userMan.GetTeacher(teacher);
                Manager.subjectMan.AddTeacherToSubject(newTeacher, newSubject);
            }

        }
    }
}