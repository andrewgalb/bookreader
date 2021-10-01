using System;
using System.Collections.Generic;
using System.IO;

namespace BookReaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
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
            */

            //View all books and one specific book
            
            Index();
            Details("1-86092-022-5");
            
            
            //Create  a book, then view all books to see if book has been created...
            Create("The Art of Motorcycle Mainentance", "Robert Maynard Pirsig", "Self-Destruction", "0-688-00230-7");
            Index();
            
            
            //Update a book, then check to see if that specific book has been updated
            Update("The Art of Motorcycle Mainentance", "Robert Maynard Pirsig", "Self-Help", "0-688-00230-7");
            Details("0-688-00230-7");
            

            
            //Delete a book, then view all books to make sure "The Open Boat" has been deleted
            Delete("1-86092-025-x");
            Index();
            
        }


        /// <summary>
        /// Reads in all book instances from file and prints these out in a nice list.
        /// </summary>
        static void Index()
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
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine("Title: {0, -20}\tAuthor: {1, -20}\tGenre: {2, -20}\tISBN: {3, -20}\t", books[i].Title, books[i].Author, books[i].Genre, books[i].ISBN);
            }
        }

        /// <summary>
        /// Reads in all book instances from file and prints out the details of the book with a certain ISBN number.
        /// </summary>
        /// <param name="ISBN"></param>
        static void Details(string ISBN)
        {
            Console.WriteLine("Details");
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
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].ISBN == ISBN)
                    {
                        Console.WriteLine("Title: {0}\tAuthor: {1}\tGenre: {2}\tISBN: {3}\t", books[i].Title, books[i].Author, books[i].Genre, books[i].ISBN);
                        break;
                    }
                }
            }

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

            books.Add(new Book(Title, Author, Genre, ISBN));


            using (StreamWriter sw = new StreamWriter("Books.txt"))
            {
                for (int i = 0; i < books.Count; i++)
                {
                    sw.WriteLine("{0}\n{1}\n{2}\n{3}", books[i].Title, books[i].Author, books[i].Genre, books[i].ISBN);
                }
            }
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
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].ISBN == ISBN)
                    {
                        books[i].Title = Title;
                        books[i].Author = Author;
                        books[i].Genre = Genre;
                        books[i].ISBN = ISBN;
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter("Books.txt"))
            {
                for (int i = 0; i < books.Count; i++)
                {
                    sw.WriteLine("{0}\n{1}\n{2}\n{3}", books[i].Title, books[i].Author, books[i].Genre, books[i].ISBN);
                }
            }
        
    }

        /// <summary>
        ///  Reads in all book instances from file, then deletes the book with a certain ISBN number, then saves all book instances.
        /// </summary>
        /// <param name="ISBN"></param>
        static void Delete(string ISBN)
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
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].ISBN == ISBN)
                    {
                        books.Remove(books[i]);
                        break;

                    }
                }
            }
            using (StreamWriter sw = new StreamWriter("Books.txt"))
            {
                for (int i = 0; i < books.Count; i++)
                {
                    sw.WriteLine("{0}\n{1}\n{2}\n{3}", books[i].Title, books[i].Author, books[i].Genre, books[i].ISBN);
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
