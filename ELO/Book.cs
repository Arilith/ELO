using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Day
    {
        private string title;
        private int number;

        public string Title { get { return title; } }
        public int Number { get { return number; } }

        public Day(string title, int number)
        {
            this.title = title;
            this.number = number;
        }
    }
}
