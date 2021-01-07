using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class AddGrade : System.Web.UI.Page
    {
        public ClassManager classMan;
        public UserMan userMan;
        public GradeMan gradeMan;
        public Person LoggedInPerson;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInPerson = (Person)Session["person"];
            gradeMan = new GradeMan();
            classMan = new ClassManager();
            userMan = new UserMan();

            if (IsPostBack && Request.Form["studentName"] != null)
            {
                ConvertAndInsertData();
            }
        }

        private void ConvertAndInsertData()
        {

            string school = LoggedInPerson.School;
            string classUUID = (Request.Form["classUUID"]);
            string date = Request.Form["date"];
            decimal weight = Convert.ToDecimal(Request.Form["weight"]);
            double grade = Convert.ToDouble(Request.Form["grade"]);
            string studentuuid = Request.Form["studentName"];
            string subjectName = Request.Form["subject"];

            gradeMan.AddGradeToDatabase(school, studentuuid, grade, weight, subjectName);
        }
    }
}