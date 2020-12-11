using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;
using ELO.Managers;

namespace Front_End
{
    public partial class AddTeacher : System.Web.UI.Page
    {

        public UserMan userManager;
        public SchoolManager schoolManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            userManager = new UserMan();
            schoolManager = new SchoolManager();

            if (IsPostBack)
            {
                ConvertAndInsertData();
            }
        }

        private void ConvertAndInsertData()
        {
            string username = Request.Form["username"];
            string teacherName = Request.Form["name"];
            string password = Request.Form["password"];
            string email = Request.Form["email"];
            string school = Request.Form["school"];

            userManager.AddTeacherToDataBase(username, password, school, teacherName, email);
            

            OutputLabel.Text = "Docent Succesvol toegevoegd!";

        }
    }
}