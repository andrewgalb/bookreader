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
        static List<User> ReadUsers()
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

        static void SaveUsers(List<User> users)
        {
            string fileName = "users.json";

            if(File.Exists(fileName))
            {
                var jsonObject = JsonConvert.SerializeObject(users, Formatting.Indented);

                File.WriteAllText(fileName, jsonObject);
            }

        }
        static User FindUserInList(Guid userID, List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].userID == userID)
                {
                    return users[i];
                }
            }
            return null;
        }
        public static bool FindTrue(Guid userID)
        {
            bool x = false;
            List<User> users = ReadUsers();
            if (FindUserInList(userID, users) != null)
            {
                x = true;
            }
            return x;
        }
        public static List<User> Index()
        {
            List<User> users = ReadUsers();

            return users;
        }
        public static User Details(Guid userID)
        {
            List<User> users = ReadUsers();
            User u = FindUserInList(userID, users);
            return u;
        }
        public static void Create(string firstName, string lastName, string personNum, string eMail, string postAdress, string postNum, string city)
        {
            Guid userID;
            List<User> users = ReadUsers();


            System.Guid guid = System.Guid.NewGuid();
            
            userID = guid;
            users.Add(new User(firstName, lastName, personNum, eMail, postAdress, postNum, city, userID));
            SaveUsers(users);

            
        }
        public static void Update(string firstName, string lastName, string personNum, string eMail, string postAdress, string postNum, string city, Guid userID)
        {
            List<User> users = ReadUsers();
            User u = FindUserInList(userID, users);

            u.firstName = firstName;
            u.lastName = lastName;
            u.personNum = personNum;
            u.eMail = eMail;
            u.postAdress = postAdress;
            u.postNum = postNum;
            u.city = city;

            SaveUsers(users);
        }
        public static void Delete(Guid userID)
        {
            List<User> users = ReadUsers();
            User u = FindUserInList(userID, users);
            users.Remove(u);
            SaveUsers(users);
        }
    }
}
