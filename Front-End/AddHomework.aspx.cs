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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ConvertAndInsertData();
            }
        }

        private void ConvertAndInsertData()
        {
            classManager = new ClassManager();
            hwMan = new HwMan();

            string work = Request.Form["work"];
            string dueDate =Request.Form["dueDate"];
            string subject = Request.Form["subject"];
            string content = Request.Form["content"];

            Class linkedClass = classManager.GetClassFromDatabase(Request.Form["_class"]);

			hwMan.AddHomework(work, subject, dueDate, content, linkedClass);

			OutputLabel.Text = "Huiswerk ingevoerd!";
        }
    }
}