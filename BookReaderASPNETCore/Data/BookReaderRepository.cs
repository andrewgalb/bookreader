using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BookReader.Models;

namespace BookReader.Data
{
    class BookReaderRepository
    {

        static List<Book> ReadBooks()
        {
            List<Book> books = new List<Book>();

            using (StreamReader sr = new StreamReader("Books.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string title = sr.ReadLine();
                    string author = sr.ReadLine();
                    string genre = sr.ReadLine();
                    string isbn = sr.ReadLine();

                    //  Book book1 = new Book(title, author, genre, isbn);
                    books.Add(new Book(title, author, genre, isbn));
                }
            }
            return books;
        }

        static void SaveBooks(List<Book> books)
        {
            using (StreamWriter sw = new StreamWriter("Books.txt"))
            {
                for (int i = 0; i < books.Count; i++)
                {
                    sw.WriteLine("{0}\n{1}\n{2}\n{3}", books[i].Title, books[i].Author, books[i].Genre, books[i].ISBN);
                }
            }
        }

        static Book FindBookInList(string ISBN, List<Book> books)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].ISBN == ISBN)
                {
                    return books[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Reads in all book instances from file and prints these out in a nice list.
        /// </summary>
        public static List<Book> Index()
        {
            List<Book> books = ReadBooks();

            return books;
        }

        public static bool FindTrue(string ISBN)
        {
            bool x = false;
            List<Book> books = ReadBooks();
            if (FindBookInList(ISBN, books) != null)
            {
                x = true;
            }
            return x;

            
        }

        /// <summary>
        /// Reads in all book instances from file and prints out the details of the book with a certain ISBN number.
        /// </summary>
        /// <param name="ISBN"></param>
        public static Book Details(string ISBN)
        {
            List<Book> books = ReadBooks();
            Book b = FindBookInList(ISBN, books);
            return b;
        }

        /// <summary>
        /// Creates a new book instance and adds it to the books on file.
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Author"></param>
        /// <param name="Genre"></param>
        /// <param name="ISBN"></param>
        public static void Create(string Title, string Author, string Genre, string ISBN)
        {
            List<Book> books = ReadBooks();
            books.Add(new Book(Title, Author, Genre, ISBN));
            SaveBooks(books);
        }


        /// <summary>
        /// Reads in all book instances from file and updates an existing book (based on ISBN number) then saves all book instances.
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Author"></param>
        /// <param name="Genre"></param>
        /// <param name="ISBN"></param>
        public static void Update(string Title, string Author, string Genre, string ISBN)
        {
            List<Book> books = ReadBooks();
            Book b = FindBookInList(ISBN, books);

            b.Title = Title;
            b.Author = Author;
            b.Genre = Genre;
            b.ISBN = ISBN;

            SaveBooks(books);
        }

        /// <summary>
        ///  Reads in all book instances from file, then deletes the book with a certain ISBN number, then saves all book instances.
        /// </summary>
        /// <param name="ISBN"></param>
        public static void Delete(string ISBN)
        {
            List<Book> books = ReadBooks();
            Book b = FindBookInList(ISBN, books);
            books.Remove(b);
            SaveBooks(books);
        }
    }

}

