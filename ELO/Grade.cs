using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Grade
    {
        public Student student { get; private set; }

        public Class _class { get; private set; }

        public double grade { get; private set; }
        public string date { get; private set; }
        public string subject { get; private set; }
        public decimal weight { get; private set; }
        public Grade(Student student, Class _class, double grade, string date, string subject, decimal weight)
        {
            this.student = student;
            this._class = _class;
            this.grade = grade;
            this.date = date;
            this.subject = subject;
            this.weight = weight;
        }

    }
}
