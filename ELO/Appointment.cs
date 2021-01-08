using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Appointment
    {
        //properties
        public Teacher teacher { get; private set; }
        public Subject subject { get; private set; }
        public DateTime dateAndTime { get; private set; }
        public string classroom { get; private set; }
        public Class _class { get; private set; }
        public string school { get; private set; }
        public Homework homework { get; private set; }
        public bool cancelled { get; private set; }
        public Exam exam { get; private set; }
        public string uuid { get; private set; }

        //constructor met alles er op en er aan
        public Appointment(Teacher teacher, Subject subject, DateTime dateAndTime, string classroom, Class _class, string school, Homework homework, bool cancelled, Exam exam, string uuid)
        {
            this.teacher = teacher;
            this.subject = subject;
            this.dateAndTime = dateAndTime;
            this.classroom = classroom;
            this._class = _class;
            this.school = school;
            this.homework = homework;
            this.cancelled = cancelled;
            this.exam = exam;
            this.uuid = uuid;
        }

        //zonder exam
        public Appointment(Teacher teacher, Subject subject, DateTime dateAndTime, string classroom, Class _class, string school, Homework homework, bool cancelled, string uuid)
        {
            this.teacher = teacher;
            this.subject = subject;
            this.dateAndTime = dateAndTime;
            this.classroom = classroom;
            this._class = _class;
            this.school = school;
            this.homework = homework;
            this.cancelled = cancelled;
            this.uuid = uuid;
        }

        //zonder homework
        public Appointment(Teacher teacher, Subject subject, DateTime dateAndTime, string classroom, Class _class, string school, Exam exam, bool cancelled, string uuid)
        {
            this.teacher = teacher;
            this.subject = subject;
            this.dateAndTime = dateAndTime;
            this.classroom = classroom;
            this._class = _class;
            this.school = school;
            this.exam = exam;
            this.cancelled = cancelled;
            this.uuid = uuid;
        }

        //zonder homework en exam
        public Appointment(Teacher teacher, Subject subject, DateTime dateAndTime, string classroom, Class _class, string school, bool cancelled, string uuid)
        {
            this.teacher = teacher;
            this.subject = subject;
            this.dateAndTime = dateAndTime;
            this.classroom = classroom;
            this._class = _class;
            this.school = school;
            this.cancelled = cancelled;
            this.uuid = uuid;
        }
    }
}
