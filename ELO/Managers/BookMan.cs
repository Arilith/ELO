using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class BookMan
    {
        public static List<Day> bookList { get; private set; }

        public BookMan()
        {
            bookList = new List<Day>();
        }


        public Day GetBook(string name)
        {
            return bookList.Find(bookItem => bookItem.Title.Contains(name));
        }

        public void AddBook(string titel, int nummer)
        {
            Day boek = new Day(titel, nummer);

            bookList.Add(boek);
        }

        public List<Day> GetBookList()
        {
            return bookList;
        }

    }
}
