using System;
using System.Collections.Generic;
using System.Text;

namespace ELO
{
    public class BookMan
    {
        public static List<Book> bookList { get; private set; }

        public BookMan()
        {
            bookList = new List<Book>();
        }


        public Book GetBook(string name)
        {
            return bookList.Find(bookItem => bookItem.Title.Contains(name));
        }

        public void AddBook(string titel, int nummer)
        {
            Book boek = new Book(titel, nummer);

            bookList.Add(boek);
        }

        public List<Book> GetBookList()
        {
            return bookList;
        }

    }
}
