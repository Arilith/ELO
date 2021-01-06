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
    public partial class AddHomework : System.Web.UI.Page
    {
        public ClassManager classManager;
        public HwMan hwMan;
        public Person LoggedInPerson;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInPerson = (Person)Session["person"];
            classManager = new ClassManager();
            hwMan = new HwMan();

            if (IsPostBack)
            {
                ConvertAndInsertData();
            }
        }

        private void ConvertAndInsertData()
        {
           
            string school = LoggedInPerson.School;
            string title = Request.Form["title"];
            string dueDate =Request.Form["dueDate"];
            string subject = Request.Form["subject"];
            string content = Request.Form["content"];

            string _class = Request.Form["class"];

			hwMan.AddHomeWorkToDB(school, title, dueDate, content, _class, subject);

			OutputLabel.Text = "Huiswerk ingevoerd!";
        }
    }
}