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
        
        public Teacher(string name, int age, string school, string type, Subject subject, Class _mentorClass, string userId, string registrationDate, string userName, string email, int exp) : base(name, age, school, type, userName, userId, registrationDate, email, exp)
        {
            this.Subject = subject;

            this.MentorForClass = _mentorClass;
        }

        public Teacher(string name, int age, string school, string type, Subject subject, string userId, string registrationDate, string userName, string email, int exp) : base(name, age, school, type, userName, userId, registrationDate, email, exp)
        {
            this.Subject = subject;
        }

        public Teacher(string name, int age, string school, string type, string userId, string registrationDate, string userName, string email, int exp) : base(name, age, school, type, userName, userId, registrationDate, email, exp)
        {
            
        }
        
        public static implicit operator Teacher(string vis)
        {
            throw new NotImplementedException();
        }
    }
}
