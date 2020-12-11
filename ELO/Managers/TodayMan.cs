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

        public void AddAppointment(Teacher teacher, Subject subject, string date, string time, Classroom classroom, Class _class, Homework homework)
        {
            Appointment Appointment = new Appointment(teacher, subject, date, time, classroom, _class, homework);
            AppointmentList.Add(Appointment);
        }

        public void AddAppointment()
        {
            throw new NotImplementedException();
        }
    }
}
