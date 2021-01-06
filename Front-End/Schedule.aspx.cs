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

        public Dictionary<string, List<Appointment>> AppointmentsPerDay;

        protected void Page_Load(object sender, EventArgs e)
        {
           //Haal ingelogde persoon uit de sessie.
            loggedInPerson = (Person)Session["person"];
            //Zet deze persoon om naar student (indien het een student is, zal deze de studentengegevens erbij krijgen)
            loggedInStudent = (Student)loggedInPerson;
            
            //Manager initialisatie
            userManager = new UserMan();
            todayMan = new TodayMan();

            //Vraag de gesoorteerde lijst op uit de todayman voor de ingelogde student.
            AppointmentsPerDay = todayMan.SortDaysAndAppointments(loggedInStudent);

        }
    }
}