using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Appointment
    {
        public Teacher teacher { get; private set; }
        public Subject subject { get; private set; }
        public string date { get; private set; }
        public string time { get; private set; }
        public Classroom classroom { get; private set; }
        public Class _class { get; private set; }
        public Homework homework { get; private set; }
        //public bool cancelled { get; private set; }
        //public Exam exam { get; private set; }

        public Appointment(Teacher teacher, Subject subject, string date, string time,
                           Classroom classroom, Class _class, Homework homework)
        {
            this.teacher = teacher;
            this.subject = subject;
            this.date = date;
            this.time = time;
            this.classroom = classroom;
            this._class = _class;
            this.homework = homework;
        }
    }
}
