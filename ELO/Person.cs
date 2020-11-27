using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Person
    {

        public string Name { get; private set; }
        public int Age { get; private set; }

        public string RegistrationDate { get; private set; }

        public string School { get; }

        public Person(string name, int age, string school)
        {
            this.Name = name;
            this.Age = age;
            this.RegistrationDate = new DateTime().ToLongDateString();
            this.School = school;
        }


        public override string ToString()
        {
            return $"Mijn naam is: {Age} en ik ben {Name} jaar oud. Ik heb mijn account aangemaakt op: {RegistrationDate} en zit op de school: {School}";
        }
    }
}
