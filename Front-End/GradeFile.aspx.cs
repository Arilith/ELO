using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End.Content
{
    public partial class GradeFile : System.Web.UI.Page
    {

        public Homework FoundHomework { get; private set; }

        public Student FoundStudent { get; private set; }

        private HwMan homeworkManager;

        private FileManager fileManager;

        private UserMan userManager;

        private Person loggedInPerson;

        private GradeMan gradeManager;

        private string getHomeworkUUID;
        private string getUserUUID;

        protected void Page_load(object sender, EventArgs e)
        {
            homeworkManager = new HwMan();
            fileManager = new FileManager();
            userManager = new UserMan();
            gradeManager = new GradeMan();

            getHomeworkUUID = Request["homeworkUUID"];
            FoundHomework = homeworkManager.GetHomeworkFromDB(getHomeworkUUID);

            getUserUUID = Request["userUUID"];
            FoundStudent = (Student)userManager.FindUserInDataBase(getUserUUID);

            loggedInPerson = (Person)Session["person"];

            if(IsPostBack)
                ConvertAndInsertData();

        }

        private void ConvertAndInsertData()
        {

            string school = loggedInPerson.School;
            decimal weight = Convert.ToDecimal(Request.Form["weight"]);
            double grade = Convert.ToDouble(Request.Form["grade"]);

            gradeManager.AddGradeToDatabase(school, getUserUUID, grade, weight, getHomeworkUUID);
        }
    }
}