using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class CheckAttendance : System.Web.UI.Page
    {
        public ClassManager classManager;
        public HwMan hwMan;
        public SubjectManager subjectManager;
        public Person LoggedInPerson;


        public int RB = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInPerson = (Person)Session["person"];
            classManager = new ClassManager();
            hwMan = new HwMan();
            subjectManager = new SubjectManager();

            if (IsPostBack)
            {
                ConvertAndInsertData();
            }
        }
        
        private void ConvertAndInsertData()
        {
            string presentString = Request.Form["present"];
            string absentString = Request.Form["absent"];
            string leaveString = Request.Form["leave"];
            string lateString = Request.Form["late"];
            string lateAllowString = Request.Form["lateAllow"];
            string forgotString = Request.Form["forgot"];
            string expelledString = Request.Form["expelled"];
            
            bool absent = absentString == "on";
            bool present = presentString == "on";
            bool leave = leaveString == "on";
            bool late = lateString == "on";
            bool lateAllow = lateAllowString == "on";
            bool forgot = forgotString == "on";
            bool expelled = expelledString == "on";

            if (absent == true)
                    {
                Request.Form["present"] = "off";
                    }

        OutputLabel.Text = "Huiswerk ingevoerd!";
        }

    }
}