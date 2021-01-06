using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;

namespace Front_End
{
    public partial class Schedule : System.Web.UI.Page
    {
        public Person loggedInPerson;
        public Student loggedInStudent;


        public UserMan userManager;
        public TodayMan todayMan;
        
        public List<Appointment> appointments;

        protected void Page_Load(object sender, EventArgs e)
        {
            // loggedInStudent = (Student) Session["student"];
            loggedInPerson = (Person)Session["person"];
            loggedInStudent = (Student)loggedInPerson;
            
            userManager = new UserMan();
            todayMan = new TodayMan();

            appointments = new List<Appointment>();

            if(IsPostBack)
            {
                string datum = Request.Form["datum"];
                // appointments = todayMan.GetAppointmentsAtDate(datum, loggedInStudent.PartOfClass.UUID);
            }
        }
    }
}