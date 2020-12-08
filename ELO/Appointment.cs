using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    class Appointment
    {
        private string teacher;
        private string subject;
        private string time;
        private int classroom;
        private string _class;

        public Appointment(string teacher, string subject, string time, int classroom, string _class)
        {
            this.teacher = teacher;
            this.subject = subject;
            this.time = time;
            this.classroom = classroom;
            this._class = _class;
        }
    }
}
