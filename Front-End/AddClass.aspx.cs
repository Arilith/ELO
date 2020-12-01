using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class AddClass : System.Web.UI.Page
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
            //Escape??
            string className = Request.Form["name"];
            string cluster = Request.Form["cluster"];
            string stream = Request.Form["stream"];
            string leshuis = Request.Form["leshuis"];
            int amountOfStudents = Convert.ToInt32(Request.Form["amountofstudents"]);
            int studyYear = Convert.ToInt32(Request.Form["studyyear"]);
            string mentor = Request.Form["mentor"];

            Teacher mentorTeacher = Manager.userMan.GetTeacher(mentor);

            Manager.classMan.AddNewClass(className, amountOfStudents, leshuis, stream, cluster, studyYear, mentorTeacher);

            OutputLabel.Text = "Klas Succesvol toegevoegd!";

        }
    }
}