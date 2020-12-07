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

        public Teacher(string name, int age, string school, string type, bool hasGroup, Subject subject, Class _mentorClass) : base(name, age, school, type)
        {
            this.HasGroup = hasGroup;

            this.Subject = subject;

            this.MentorForClass = _mentorClass;
        }

        public Teacher(string name, int age, string school, string type, bool hasGroup, Subject subject) : base(name, age, school, type)
        {
            this.HasGroup = hasGroup;

            this.Subject = subject;

        }

    }
}
