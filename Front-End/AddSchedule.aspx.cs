using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELO;
using ELO.SQLClasses;

namespace Front_End
{
    public partial class AddSchedule : System.Web.UI.Page
    {
        // managers aanroepen om later te gebruiken
        private TodayMan todayMan;
        public Person loggedInPerson;
        public UserMan userMan;
        public ClassManager classManager;
        public SubjectManager subjectManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            // ingelogde persoon verkrijgen en connectie met todayman openen voor het toevoegen aan de database
            loggedInPerson = (Person) Session["person"];
            todayMan = new TodayMan();
            userMan = new UserMan();
            classManager = new ClassManager();
            subjectManager = new SubjectManager();
            if (IsPostBack)
            {
                ConvertAndInsertData();
            }
        }

        private void ConvertAndInsertData()
        {
            //data uit form opslaan in variabelen
            string returnTeacher = Request.Form["teacherName"];
            string returnSubject = Request.Form["subjectName"];
            string returnDate = Request.Form["date"];
            int returnHour = Convert.ToInt32(Request.Form["lesuur"]);
            string returnClassUUID = Request.Form["_class"];
            string returnClassroom = Request.Form["classroom"];
            string returnSchool = loggedInPerson.School;

            // die variabelen in de database zetten
            todayMan.AddAppointment(returnTeacher, returnSubject, returnDate, returnClassroom, returnClassUUID, returnSchool, returnHour);

            OutputLabelSchedule.Text = "Item Succesvol toegevoegd!";
        }
    }
}