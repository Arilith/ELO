using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Book
    {
        private string title;
        private int number;

        public string Title { get { return title; } }
        public int Number { get { return number; } }

        public Book(string title, int number)
        {
            this.title = title;
            this.number = number;
        }
    }
}
