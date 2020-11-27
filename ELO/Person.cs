using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Person
    {

        public string Name { get; private set; }



        public Person(string _name, int _age)
        {
            this.Name = _name;
            this.Age = _age;
        }

        public Person(string _name)
        {
            this.Name = _name;
        }

        public override string ToString()
        {
            return $"Mijn naam is: {name} en ik ben {age} jaar oud.";
        }
    }
}
