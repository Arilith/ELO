using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;
using ELO.SQLClasses;

namespace Front_End
{
    public partial class AddSchedule : System.Web.UI.Page
    {
        private AppointmentSQL appointmentSql;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // if (IsPostBack)
            // {
            //     ConvertAndInsertData();
            // }
        }

        // private void ConvertAndInsertData()
        // {
        //     Teacher teacher = Request.Form["teacher"];
        //     Subject subject = Request.Form["subject"];
        //     string dateTime = Request.Form["dateTime"];
        //     bool cancelled = false;
        //
        //     Exam exam = new Exam();
        //     Classroom linkedClassroom = Manager.classroomMan.GetClassroom(Request.Form["Classroom"]);
        //     Class linkedClass = Manager.classMan.GetClass(Request.Form["_class"]);
        //     Homework homework = new Homework("Lezen", subject, "Dan", linkedClass);
        //     
        //     
        //     
        //     appointmentSql.AddAppointmentToDatabase(teacherUUID, subjectUUID, dateTime, classroomUUID, classUUID, school, homeworkUUID, cancelled, examUUID, UUID);
        //     
        //     OutputLabel.Text = "Item ingevoerd!";
        // }
    }
} 