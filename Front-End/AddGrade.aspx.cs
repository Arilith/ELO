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
            Student studentuuid = (Student) userMan.FindUserInDataBase(Request.Form["studentName"]);
            string subject = Request.Form["subject"];
            Class _class = classMan.GetClassFromDatabase(Request.Form["_class"]);
            string date = Request.Form["date"];
            decimal weight =Convert.ToDecimal(Request.Form["weight"]);
            double grade =Convert.ToDouble(Request.Form["grade"]);


            gradeMan.AddGradeToDatabase(school, studentuuid, grade, date, weight, subject, student);

        }
    }
}