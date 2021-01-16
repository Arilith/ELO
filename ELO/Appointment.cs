using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Appointment
    {
        //properties
        public string teacher { get; private set; }
        public string subject { get; private set; }
        public DateTime Date { get; private set; }
        public string classroom { get; private set; }
        public string _class { get; private set; }
        public string school { get; private set; }
        public Homework homework { get; private set; }
        public bool cancelled { get; private set; }

        public string uuid { get; private set; }

        public int LesUur { get; private set; }

        //constructor met alles er op en er aan
        public Appointment(string teacher, string subject, DateTime date, string classroom, string _class, string school, Homework homework, bool cancelled, Exam exam, string uuid, int lesUur)
        {
            this.teacher = teacher;
            this.subject = subject;
            this.Date = date;
            this.classroom = classroom;
            this._class = _class;
            this.school = school;
            this.homework = homework;
            this.cancelled = cancelled;
            this.uuid = uuid;
            this.LesUur = lesUur;
        }

        //zonder exam
        public Appointment(string teacher, string subject, DateTime date, string classroom, string _class, string school, Homework homework, bool cancelled, string uuid, int lesUur)
        {
            this.teacher = teacher;
            this.subject = subject;
            this.Date = date;
            this.classroom = classroom;
            this._class = _class;
            this.school = school;
            this.homework = homework;
            this.cancelled = cancelled;
            this.uuid = uuid;
            this.LesUur = lesUur;
        }

        //zonder homework
        public Appointment(string teacher, string subject, DateTime date, string classroom, string _class, string school, Exam exam, bool cancelled, string uuid, int lesUur)
        {
            this.teacher = teacher;
            this.subject = subject;
            this.Date = date;
            this.classroom = classroom;
            this._class = _class;
            this.school = school;
            this.cancelled = cancelled;
            this.uuid = uuid;
            this.LesUur = lesUur;
        }

        //zonder homework en exam
        public Appointment(string teacher, string subject, DateTime date, string classroom, string _class, string school, bool cancelled, string uuid, int lesUur)
        {
            this.teacher = teacher;
            this.subject = subject;
            this.Date = date;
            this.classroom = classroom;
            this._class = _class;
            this.school = school;
            this.cancelled = cancelled;
            this.uuid = uuid;
            this.LesUur = lesUur;
        }
    }
}
