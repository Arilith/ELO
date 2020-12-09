﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Student : Person
    {

        public Class PartOfClass { get; private set; }
        public Teacher Mentor { get; private set; }

        public int LeerlingNummer { get; private set; }

        public Student(string name, int age, string school, string type, Class _class, Teacher mentor, int userId, int leerLingNummer, string registrationDate, string userName) : base(name, age, school, type, userName, userId, registrationDate)
        {
            this.PartOfClass = _class;
            this.Mentor = mentor;
            this.LeerlingNummer = leerLingNummer;
        }


    }
}
