using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BookReader.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace BookReader.Data
{
    public class UserRepository
    {
        static string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<User> Index()
        {
            string query = "SELECT UserId, FirstName, LastName, PersonNum, Email, PostAdress, PostNum, City FROM Users ORDER BY UserId";
            List<User> user = new List<User>();
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
                                Guid userID = reader.GetGuid(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                string personNum = reader.GetString(3);
                                string eMail = reader.GetString(4);
                                string postAdress = reader.GetString(5);
                                string postNum = reader.GetString(6);
                                string city = reader.GetString(7);

                                //  Book book1 = new Book(title, author, genre, isbn);

                                user.Add(new User(firstName, lastName, personNum, eMail, postAdress, postNum, city, userID));
                            }
                            return user;
                        }

                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Error: " + e.ToString());
                        return user;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        public static User Details(Guid userID)
        {
            string query = $"SELECT UserId, FirstName, LastName, PersonNum, Email, PostAdress, PostNum, City FROM Users WHERE UserId = '{userID}'";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                User u = null;
                using (SqlCommand commandTwo = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = commandTwo.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                string personNum = reader.GetString(3);
                                string eMail = reader.GetString(4);
                                string postAdress = reader.GetString(5);
                                string postNum = reader.GetString(6);
                                string city = reader.GetString(7);

                                //  Book book1 = new Book(title, author, genre, isbn);

                                u = new User(firstName, lastName, personNum, eMail, postAdress, postNum, city, userID);
                            }
                            return u;
                        }

                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Error: " + e.ToString());
                        return u;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        public static void Create(string firstName, string lastName, string personNum, string eMail, string postAdress, string postNum, string city)
        {
            string query = $"INSERT INTO Users (FirstName, LastName, PersonNum, Email, PostAdress, PostNum, City) VALUES('{firstName}', '{lastName}', '{personNum}', '{eMail}', '{postAdress}', '{postNum}', '{city}')";
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
        public static void Update(string firstName, string lastName, string personNum, string eMail, string postAdress, string postNum, string city, Guid userID)
        {
            string query = $"UPDATE Users SET FirstName = '{firstName}', LastName = '{lastName}', PersonNum = '{personNum}', Email = '{eMail}', PostAdress = '{postAdress}', PostNum = '{postNum}', City = '{city}' WHERE UserId = '{userID}'";

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
        public static void Delete(Guid userID)
        {
            string delQuery = $"DELETE FROM Users WHERE UserId = '{userID}'";

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
