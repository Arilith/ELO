using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class Schedule : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            Manager.todayMan.AddAppointment();  
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ConvertAndInsertData();
            }
        }

        private void ConvertAndInsertData()
        {
            Teacher teacher = Request.Form["teacher"];
            Subject subject = Request.Form["subject"];
            string date = Request.Form["date"];
            string time = Request.Form["time"];
            Classroom linkedClassroom = Manager.classroomMan.GetClassroom(Request.Form["Classroom"]);
            Class linkedClass = Manager.classMan.GetClass(Request.Form["_class"]);
            Homework homework = new Homework("Lezen", subject, "Dan", linkedClass);

          

            Manager.todayMan.AddAppointment(teacher, subject, date, time, linkedClassroom, linkedClass, homework);

            OutputLabel.Text = "Item ingevoerd!";
        }
    }
} 