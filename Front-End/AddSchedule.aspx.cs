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
        private TodayMan todayMan;
        public UserMan userMan;
        public Person loggedInPerson;
        public SubjectManager subjectMan;
        public ClassManager classMan;

        protected void Page_Load(object sender, EventArgs e)
        {
            loggedInPerson = (Person) Session["person"];
            todayMan = new TodayMan();
            subjectMan = new SubjectManager();
            userMan = new UserMan();
            classMan = new ClassManager();
            
            if (IsPostBack)
            {
                ConvertAndInsertData();
            }
        }

        private void ConvertAndInsertData()
        {
            string returnTeacherUUID = Request.Form["teacherName"];
            string returnSubjectUUID = Request.Form["subject"];
            string returnDateTime = Request.Form["dateTime"];
            string returnClassUUID = Request.Form["_class"];
            string returnClassroom = Request.Form["classroom"];
            string returnSchool = loggedInPerson.School;

            todayMan.AddAppointment(returnTeacherUUID, returnSubjectUUID, returnDateTime, returnClassroom, returnClassUUID, returnSchool);
        }
    }
} 