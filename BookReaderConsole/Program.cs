using System;
using System.Collections.Generic;
using System.IO;

namespace BookReaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //View all books and one specific book
            Console.WriteLine("\nRunning index:");
            Index();
            Console.WriteLine("\nRunning details:");
            Details("1-86092-022-5");

            Console.WriteLine("\nCreating book:");
            //Create  a book, then view all books to see if book has been created...
            Create("The Art of Motorcycle Mainentance", "Robert Maynard Pirsig", "Self-Destruction", "0-688-00230-7");
            Console.WriteLine("\nRunning index:");
            Index();

            //Update a book, then check to see if that specific book has been updated
            Console.WriteLine("\nUpdating book:");
            Update("The Art of Motorcycle Mainentance", "Robert Maynard Pirsig", "Self-Help", "0-688-00230-7");
            Console.WriteLine("\nChecking details:");
            Details("0-688-00230-7");

            //Delete a book, then view all books to make sure "The Open Boat" has been deleted
            Console.WriteLine("\nDeleting book:");
            Delete("0-688-00230-7");
            Console.WriteLine("\nRunning index:");
            Index();
        }

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
        static void Index()
        {
            List<Book> books = ReadBooks();

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine("Title: {0}\tAuthor: {1}\tGenre: {2}\tISBN: {3}\t", books[i].Title, books[i].Author, books[i].Genre, books[i].ISBN);
            }
        }

        /// <summary>
        /// Reads in all book instances from file and prints out the details of the book with a certain ISBN number.
        /// </summary>
        /// <param name="ISBN"></param>
        static void Details(string ISBN)
        {
            List<Book> books = ReadBooks();
            Book b = FindBookInList(ISBN, books);
            Console.WriteLine("Title: {0}\tAuthor: {1}\tGenre: {2}\tISBN: {3}\t", b.Title, b.Author, b.Genre, b.ISBN);
        }

        /// <summary>
        /// Creates a new book instance and adds it to the books on file.
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Author"></param>
        /// <param name="Genre"></param>
        /// <param name="ISBN"></param>
        static void Create(string Title, string Author, string Genre, string ISBN)
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
        static void Update(string Title, string Author, string Genre, string ISBN)
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
        static void Delete(string ISBN)
        {
            List<Book> books = ReadBooks();
            Book b = FindBookInList(ISBN, books);
            books.Remove(b);
            SaveBooks(books);
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
