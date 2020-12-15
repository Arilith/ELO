using System;
using System.Collections.Generic;
using System.Text;
using ELO;

namespace ELO
{
    public class Classroom
    {
        public string Name { get; private set; }
        public bool Available { get; private set; }
        public int Floor { get; private set; }
        public string UUID { get; private set; }


        public Classroom(string name, int floor, bool available, string uuid)
        {
            this.Name = name;
            this.Floor = floor;
            this.Available = available;
            this.UUID = uuid;
        }
    }
}
