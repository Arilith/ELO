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

        protected void Page_Load(object sender, EventArgs e)
        {
            classMan = new ClassManager();
            userMan = new UserMan();

            if (IsPostBack && Request.Form["studentName"] != null)
            {
                ConvertAndInsertData();
            }
        }

        private void ConvertAndInsertData()
        {

            Student studentName = userMan.GetStudent(Request.Form["name"]);
            string subject = Request.Form["subject"];
            Class _class = classMan.GetClassFromDatabase(Request.Form["_class"]);
            string date = Request.Form["date"];
            decimal weight =Convert.ToDecimal(Request.Form["weight"]);
            double grade =Convert.ToDouble(Request.Form["grade"]);

           // gradeMan.AddGradeToDataBase(studentName, _class, grade, date, subject, weight);

        }

	
	}
}