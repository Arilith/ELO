using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ELO
{
    public class Person
    {

        public string Name { get; private set;  }
        public int Age { get; }

        public string RegistrationDate { get; }

        public string School { get; }

        public string Type { get; }

        public string UserId { get; }

        public string UserName { get; private set; }

        public string Email { get; private set; }
        

        public Person(string name, int age, string school, string type, string userName, string userId, string registrationDate, string email)
        {
            this.Name = name;
            this.Age = age;
            this.RegistrationDate = registrationDate;
            this.School = school;
            this.UserId = userId;
            this.Type = type;
            this.UserName = userName;
            this.Email = email;
            
        }

        public override string ToString()
        {
            return $"Mijn naam is: {Name} en ik ben {Age} jaar oud. Ik heb mijn account aangemaakt op: {RegistrationDate} en zit op de school: {School}. Hier heb ik de rol {Type}";
        }

    }
}
