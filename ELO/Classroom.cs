using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    class Classroom
    {
        private string name;
        private bool available;
        private int floor;

        public Classroom(string name, int floor, bool available)
        {
            this.name = name;
            this.floor = floor;
            this.available = available;
        }
    }
}
