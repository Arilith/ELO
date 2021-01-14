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

        private string getHomeworkUUID;
        private string getUserUUID;

        private Person loggedInPerson;

        protected void Page_load(object sender, EventArgs e)
        {
            homeworkManager = new HwMan();
            fileManager = new FileManager();
            userManager = new UserMan();

            getHomeworkUUID = Request["homeworkUUID"];
            FoundHomework = homeworkManager.GetHomeworkFromDB(getHomeworkUUID);

            getUserUUID = Request["userUUID"];
            FoundStudent = (Student)userManager.FindUserInDataBase(getUserUUID);

            loggedInPerson = (Person)Session["person"];

        }
    }
}