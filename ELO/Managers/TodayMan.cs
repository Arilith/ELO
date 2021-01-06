using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO
{
    public class TodayMan
    {
        private SubjectManager subjectManager;
        private UserMan userMan;
        private ClassManager classManager;
        public static List<Appointment> AppointmentList { get; private set; }
        public string UUID { get; private set; }

        private AppointmentSQL appointmentSql;

        public TodayMan()
        {
            AppointmentList = new List<Appointment>();
            UUID = new Random().Next().ToString() + DateTime.Now.ToString("ddmmYYYhhiiss");
            appointmentSql = new AppointmentSQL();
        }

        public void AddAppointment(Teacher teacher, Subject subject, string dateAndTime, Classroom classroom, Class _class, Homework homework, bool cancelled, Exam exam)
        {
           // Appointment Appointment = new Appointment(teacher, subject, dateAndTime, classroom, _class, homework, cancelled, exam);
            //AppointmentList.Add(Appointment);
        }

        public void AddAppointment(string teacherUUID, string subjectUUID, string dateAndTime, string classroomUUID, string classUUID, string school)
        {
            subjectManager = new SubjectManager();
            userMan = new UserMan();
            classManager = new ClassManager();

            Teacher insertTeacher = userMan.GetTeacher(teacherUUID);
            Subject insertSubject = subjectManager.FindSubject(subjectUUID);
            Class insertClass = classManager.GetClassFromDatabase(classUUID);
            
            appointmentSql.AddAppointmentToDatabase(teacherUUID, subjectUUID, dateAndTime,  classroomUUID,  classUUID,  school, UUID);
        }

        public List<Appointment> GetAppointmentListFromDatabase(string school, string _classUUID)
        {
           return appointmentSql.GetAppointmentList(school, _classUUID);
        }

        public Dictionary<string, List<Appointment>> SortDaysAndAppointments(Student loggedInStudent)
        {
            List<Appointment> appointments;
            // 1 Jan (key) => List<Appointment> => Appointment1, appointment2
            // 2 Jan (key) => List<Appointment> => Appointment3, appointment4
            // 3 Jan (key) => List<AppointMent> => Appointment5, appointment6
            Dictionary<string, List<Appointment>> appointmentsPerDay = new Dictionary<string, List<Appointment>>();

            // Appointment 1, Appointment 2, 3, 4, 5, 6....
            appointments = new List<Appointment>();

            //Zet in bovenstaande lijst
            if (loggedInStudent != null)
                appointments = GetAppointmentListFromDatabase(loggedInStudent.School, loggedInStudent.PartOfClass.UUID);
            else
                return null;

            //Loop door alle appointments heen
            foreach (Appointment appointment in appointments)
            {
                //Zet de "string" datum uit de database om naar DateTime, ipv string (2021-01-06 11:00:00)
                DateTime newDate = Convert.ToDateTime(appointment.dateAndTime);

                //Zet de datum om naar datum zonder tijd (01/06/2021)
                string dateWithoutTime = newDate.ToString("MM/dd/yyyy");

                //Check of de huidige dag van de appointment (bijv. 01/06/2021) al in de dictionairy staat. 
                if (appointmentsPerDay.ContainsKey(dateWithoutTime))
                {
                    //Pak de appointmentslist uit de huidige key van de huidige datum;
                    List<Appointment> AppointmentsOnThisDay = appointmentsPerDay[dateWithoutTime];
                    //Voeg de huidige appointment toe aan de lijst die al bestaat met appointsments op deze dag;
                    AppointmentsOnThisDay.Add(appointment);
                    //Vervang de lijst in de dictonairy met de lijst met de nieuwe appointment
                    appointmentsPerDay[dateWithoutTime] = AppointmentsOnThisDay;
                }
                //Check of de huidige dag van de appointment nog *niet* bestaat.
                else
                {
                    //Voeg aan de dictionary een nieuwe lijst met appointments toe, met de huidige appointment, terug te vinden met de key "Huidige datum"
                    appointmentsPerDay.Add(dateWithoutTime, new List<Appointment>() { appointment });
                }
            }

            return appointmentsPerDay;
        }
    }
}
