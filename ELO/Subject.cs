using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Subject
    {
        public String Name { get; private set; }

        public List<Teacher> Teachers { get; private set; }

        public Subject(string name)
        {
            this.Name = name;
        }

    }
}
