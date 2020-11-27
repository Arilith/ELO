using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Class
    {
        public string Name { get; private set; }
        public int AmountOfStudents { get; private set; }
        


        public Class(string name, int amountOfStudents)
        {
            this.Name = name;
            this.AmountOfStudents = amountOfStudents;
        }

    }
}
