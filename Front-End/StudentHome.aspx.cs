using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class StudentHome : System.Web.UI.Page
    {

        public Student loggedInStudent;
        public GradeMan gradeMan;
        public SubjectManager subjectMan;
        public HwMan homeworkMan;
        public TodayMan todayMan;

        protected void Page_Load(object sender, EventArgs e)
        {
            loggedInStudent = (Student) Session["person"];
            homeworkMan = new HwMan();
            gradeMan = new GradeMan();
            subjectMan = new SubjectManager();
            todayMan = new TodayMan();
        }
    }
}