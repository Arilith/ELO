using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Student : Person
    {

        public Class PartOfClass { get; private set; }
        public Teacher Mentor { get; private set; }

        public Student(string name, int age, string school, string type, Class clazz, Teacher mentor) : base(name, age, school, type)
        {
            this.PartOfClass = clazz;
            this.Mentor = mentor;
        }

    }
}
