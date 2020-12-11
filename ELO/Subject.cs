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
            Teachers = new List<Teacher>();
            this.Name = name;
        }

        public static implicit operator Subject(string v)
        {
            throw new NotImplementedException();
        }
    }
}
