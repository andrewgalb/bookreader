using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BookReader.Models;
using System.Data.SqlClient;

namespace BookReader.Data
{
    class BookReaderRepository
    {
        static string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static List<Book> ReadBooks()
        {
            string query = "SELECT Title, Author, Genre, ISBN, BookId FROM Books ORDER BY BookId";
            List<Book> books = new List<Book>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand commandTwo = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = commandTwo.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader.GetString(0);
                                string author = reader.GetString(1);
                                string genre = reader.GetString(2);
                                string isbn = reader.GetString(3);
                                string bookID = reader.GetInt32(4).ToString();

                                //  Book book1 = new Book(title, author, genre, isbn);

                                books.Add(new Book(title, author, genre, isbn, bookID));
                            }
                            return books;
                        }

                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Error: " + e.ToString());
                        return books;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

        }

        /// <summary>
        /// Reads in all book instances from file and prints these out in a nice list.
        /// </summary>
        public static List<Book> Index()
        {
            List<Book> books = ReadBooks();

            return books;
        }

        /// <summary>
        /// Reads in all book instances from file and prints out the details of the book with a certain ISBN number.
        /// </summary>
        /// <param name="ISBN"></param>
        public static Book Details(string bookID)
        {
            string query = $"SELECT Title, Author, Genre, ISBN, BookId FROM Books WHERE BookId = '{bookID}'";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                Book b = null;
                using (SqlCommand commandTwo = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = commandTwo.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader.GetString(0);
                                string author = reader.GetString(1);
                                string genre = reader.GetString(2);
                                string isbn = reader.GetString(3);
                                string bookID2 = reader.GetInt32(4).ToString();

                                //  Book book1 = new Book(title, author, genre, isbn);

                                b = new Book(title, author, genre, isbn, bookID2);
                            }
                            return b;
                        }

                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Error: " + e.ToString());
                        return b;
                    }
                    finally
                    {
                        connection.Close();
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
        public static void Create(string Title, string Author, string Genre, string ISBN)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string query = $"INSERT INTO Books (Title, Author, Genre, ISBN) VALUES('{Title}', '{Author}', '{Genre}', '{ISBN}')";
            using (SqlConnection connection = new SqlConnection(connString))
            {

                SqlCommand commandOne = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    commandOne.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    connection.Close();
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
        public static void Update(string Title, string Author, string Genre, string ISBN, string bookID)
        {

            string query = $"UPDATE Books SET Title = '{Title}', Author = '{Author}', Genre = '{Genre}', ISBN = '{ISBN}'WHERE BookId = {bookID}";

            using (SqlConnection connection = new SqlConnection(connString))
            {

                SqlCommand commandOne = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    commandOne.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        /// <summary>
        ///  Reads in all book instances from file, then deletes the book with a certain ISBN number, then saves all book instances.
        /// </summary>
        /// <param name="ISBN"></param>
        public static void Delete(string bookID)
        {
            string delQuery = $"DELETE FROM Books WHERE BookId = '{bookID}'";

            using (SqlConnection connection = new SqlConnection(connString))
            {

                SqlCommand commandOne = new SqlCommand(delQuery, connection);
                try
                {
                    connection.Open();
                    commandOne.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }

}

