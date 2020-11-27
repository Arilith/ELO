using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ELO
{
    public class Person
    {

        private static int _nextUserID = 1;

        public string Name { get; private set;  }
        public int Age { get; }

        public string RegistrationDate { get; }

        public string School { get; }

        public string Type { get; }

        public int UserId { get; }

        public Person(string name, int age, string school, string type)
        {
            this.Name = name;
            this.Age = age;
            this.RegistrationDate = DateTime.Now.ToString();
            this.School = school;
            this.UserId = _nextUserID;
            this.Type = type;

            _nextUserID++;
        }


        public string ToString(string type)
        {
            if (type == "long")
            {
                return $"Mijn naam is: {Name} en ik ben {Age} jaar oud. Ik heb mijn account aangemaakt op: {RegistrationDate} en zit op de school: {School}";
            } else if (type == "short")
            {
                return $"{Name}, {Age}, {RegistrationDate}, {School}";
            }

            return null;

        }



    }
}
