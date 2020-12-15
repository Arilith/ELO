using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class TodayMan
    {
        public static List<Appointment> AppointmentList { get; private set; }

        public TodayMan()
        {
            AppointmentList = new List<Appointment>();
        }

        public void AddAppointment(Teacher teacher, Subject subject, string time, Classroom classroom, Class _class, Homework homework, bool cancelled, Exam exam)
        {
           // Appointment Appointment = new Appointment(teacher, subject, time, classroom, _class, homework, cancelled, exam);
            //AppointmentList.Add(Appointment);
        }

        public void AddAppointment()
        {
            throw new NotImplementedException();
        }
    }
}
