using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BookReader.Models;
using Newtonsoft.Json;

namespace BookReader.Data
{
    public class UserRepository
    {
        static List<User> ReadUsers()
        {
            string fileName = "users.json";

            if (File.Exists(fileName))
            {

                var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(fileName));

                return users;
            }

            return null;
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
        static User FindUserInList(string postAdress, List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].postAdress == postAdress)
                {
                    return users[i];
                }
            }
            return null;
        }
        public static bool FindTrue(string postAdress)
        {
            bool x = false;
            List<User> users = ReadUsers();
            if (FindUserInList(postAdress, users) != null)
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
        public static User Details(string postAdress)
        {
            List<User> users = ReadUsers();
            User u = FindUserInList(postAdress, users);
            return u;
        }
        public static void Create(string firstName, string lastName, string personNum, string eMail, string postAdress, string postNum, string city)
        {
            List<User> users = ReadUsers();
            users.Add(new User(firstName, lastName, personNum, eMail, postAdress, postNum, city));
            SaveUsers(users);
        }
        public static void Update(string firstName, string lastName, string personNum, string eMail, string postAdress, string postNum, string city)
        {
            List<User> users = ReadUsers();
            User u = FindUserInList(postAdress, users);

            u.firstName = firstName;
            u.lastName = lastName;
            u.personNum = personNum;
            u.eMail = eMail;
            u.postAdress = postAdress;
            u.postNum = postNum;
            u.city = city;

            SaveUsers(users);
        }
        public static void Delete(string postAdress)
        {
            List<User> users = ReadUsers();
            User u = FindUserInList(postAdress, users);
            users.Remove(u);
            SaveUsers(users);
        }
    }
}
