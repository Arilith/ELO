using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Subject
    {
        public String Name { get; private set; }

        public List<Teacher> Teachers { get; private set; }

        public string uuid { get; private set; }

        public Subject(string name, string uuid)
        {
            this.Teachers = new List<Teacher>();
            this.Name = name;
            this.uuid = uuid;
        }

        public void SetTeachers(List<Teacher> teachers)
        {
            this.Teachers = teachers;
        }

    }
}
