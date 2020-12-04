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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ConvertAndInsertData();
            }
        }

        private void ConvertAndInsertData()
        {

            Student studentName = Manager.userMan.GetStudent(Request.Form["name"]);
            string subject = Request.Form["subject"];
            Class _class = Manager.classMan.GetClass(Request.Form["_class"]);
            string date = Request.Form["date"];
            decimal weight =Convert.ToDecimal(Request.Form["weight"]);
            double grade =Convert.ToDouble(Request.Form["grade"]);

            Manager.gradeMan.AddGradeToList(studentName, _class, grade, date, subject, weight);


        }
    }
}