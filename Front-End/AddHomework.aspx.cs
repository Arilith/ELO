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

        public ClassManager classMan;
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

            string work = Request.Form["work"];
            string dueDate =Request.Form["dueDate"];
            string subject = Request.Form["subject"];

            Class linkedClass = classMan.GetClassFromDatabase(Request.Form["_class"]);

			//hwMan.AddHomeWorkToDB(work, subject, dueDate, linkedClass);

			OutputLabel.Text = "Huiswerk ingevoerd!";
        }
    }
}