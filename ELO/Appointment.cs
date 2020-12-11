using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    class Appointment
    {
        private Teacher teacher;
        private Subject subject;
        private DateTime datetime;
        private Classroom classroom;
        private Class _class;
        private Homework homework;
        private bool cancelled;
        private Exam exam;
        


        public Appointment(Teacher teacher, Subject subject, DateTime datetime, Classroom classroom, Class _class, Homework homework, bool cancelled, Exam exam)
        {
            this.teacher = teacher;
            this.subject = subject;
            this.datetime = datetime;
            this.classroom = classroom;
            this._class = _class;
            this.homework = homework;
            this.cancelled = cancelled;
            this.exam = exam;
        }
    }
}
