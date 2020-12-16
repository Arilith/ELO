using System;
using System.Collections.Generic;
using System.Text;
using ELO.SQLClasses;

namespace ELO
{
    public class TodayMan
    {
        public static List<Appointment> AppointmentList { get; private set; }

        private AppointmentSQL appointmentSql;

        public TodayMan()
        {
            AppointmentList = new List<Appointment>();
        }

        public void AddAppointment(Teacher teacher, Subject subject, string time, Classroom classroom, Class _class, Homework homework, bool cancelled, Exam exam)
        {
           // Appointment Appointment = new Appointment(teacher, subject, time, classroom, _class, homework, cancelled, exam);
            //AppointmentList.Add(Appointment);
        }

        public void AddAppointment(string school, string title, string dueDate, string content, string classUUID, string subject)
        {
           appointmentSql.AddAppointmentToDB(school, title, dueDate, content, classUUID, subject);
        }

        public void GetAppointmentListFromDatabase(string school, string _classUUID)
        {
           appointmentSql.GetAppointmentList(school, _classUUID);
        }
    }
}
