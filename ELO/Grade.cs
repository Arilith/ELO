using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Grade
    {
        public Student student { get; private set; }
        public decimal grade { get; private set; }
        public string date { get; private set; }
        public string subject { get; private set; }
        public decimal weight { get; private set; }
        public Grade(Student student, int studentID, decimal grade, string date, string subject, decimal grademultiplier)
        {
            this.student = student;
            this.grade = grade;
            this.date = date;
            this.subject = subject;
            this.weight = weight;
        }

    }
}
