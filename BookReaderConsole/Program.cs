using System;
using System.Collections.Generic;
using System.IO;

namespace BookReaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
          
            using (StreamReader sr = new StreamReader("Books.txt"))
            {
                while (!sr.EndOfStream) { 
                string title = sr.ReadLine();
                string author = sr.ReadLine();
                string genre = sr.ReadLine();
                string isbn = sr.ReadLine();

              //  Book book1 = new Book(title, author, genre, isbn);
                books.Add(new Book(title, author, genre, isbn));
                }
            }

        }
    }

    class Book
    {
        public string Title;
        public string Author;
        public string Genre;
        public string ISBN;

        public Book(string Title, string Author, string Genre, string ISBN)
        {
            this.Title = Title;
            this.Author = Author;
            this.Genre = Genre;
            this.ISBN = ISBN;
        }
    }

}
