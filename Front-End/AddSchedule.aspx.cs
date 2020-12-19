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
        private TodayMan todayMan;
        private SubjectManager subjectManager;
        private ExamMan examMan;
        private UserMan userMan;
        private ClassroomMan classroomMan;
        private HwMan hwMan;
        private string returnUUID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ConvertAndInsertData();
                returnUUID = appointmentSql.GetUUID();
            }
        }

        private void ConvertAndInsertData()
        {
            string returnTeacherUUID = Request.Form["teacher"];
            string returnSubjectName = Request.Form["subject"];
            string returnDateTime = Request.Form["dateTime"];
            string returnExamUUID = "none";
            bool cancelled = false;
            string returnHomeworkUUID = "blank";

            Person loggedInPerson = (Person)Session["person"];
            string insertUUID = GetUUID();

            Subject insertSubject = subjectManager.FindSubject(returnSubjectName);
            Exam insertExam = examMan.GetExam(returnExamUUID);
            Classroom insertClassroom = classroomMan.GetClassroom(Request.Form["Classroom"]);
            Class insertClass = Manager.classMan.GetClass(Request.Form["_class"]);
            Homework insertHomework = hwMan.GetHomework(returnHomeworkUUID);
            Teacher insertTeacher = userMan.GetTeacher(returnTeacherUUID);
            
            todayMan.AddAppointment(insertTeacher.UserId, insertSubject.uuid, returnDateTime, insertClassroom.UUID, insertClass.UUID, loggedInPerson.School, insertHomework.UUID, cancelled, insertExam.UUID, insertUUID);
        }

        public string GetUUID()
        {
            return returnUUID;
        }
    }
} 