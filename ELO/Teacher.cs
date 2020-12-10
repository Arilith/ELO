using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ELO
{
    public class Teacher : Person
    {

        public bool HasGroup { get; private set; }

        public Subject Subject { get; private set; }

        public Class MentorForClass { get; private set; } 


        public Teacher(string name, int age, string school, string type, bool hasGroup, Subject subject, Class _mentorClass, int userId, int leerLingNummer, string registrationDate, string userName) : base(name, age, school, type, userName, userId, registrationDate)
        {
            this.HasGroup = hasGroup;

            this.Subject = subject;

            this.MentorForClass = _mentorClass;

        }

        public Teacher(string name, int age, string school, string type, bool hasGroup, Subject subject, int userId, int leerLingNummer, string registrationDate, string userName) : base(name, age, school, type, userName, userId, registrationDate)
        {
            this.HasGroup = hasGroup;

            this.Subject = subject;

        }

    }
}
