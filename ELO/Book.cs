using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class Book
    {
        private string title;
        private int nummer;

        public string Title { get { return title; } }
        public int Nummer { get { return nummer; } }

        public Book(string title, int nummer)
        {
            this.title = title;
            this.nummer = nummer;
        }
    }
}
