using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ELO
{
    public class Person
    {

        private readonly string _name;
        private readonly int _age;
        private readonly string _registrationDate;
        private readonly string _school;
        private readonly string _type;
        private readonly int _userID;

        private static int nextUserID = 1;

        public string Name
        {
            get { return _name;  }
        }
        public int Age
        {
            get { return _age; }
        }

        public string RegistrationDate
        {
            get { return _registrationDate; }
        }

        public string School
        {
            get { return _school; }
        }

        public string Type
        {
            get { return _type; }
        }

        public int UserID
        {
            get { return _userID; }
        }

        public Person(string name, int age, string school, string type)
        {
            _name = name;
            _age = age;
            _registrationDate = DateTime.Now.ToString();
            _school = school;
            _userID = nextUserID;
            _type = type;

            nextUserID++;
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
