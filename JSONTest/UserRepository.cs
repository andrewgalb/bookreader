using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace JSONTest
{
    class UserRepository
    {

        static string filename = "Users.json";

        static List<User> ReadUsers()
        {
            List<User> users = new List<User>();

            if (!File.Exists(filename))
            {
                File.Create(filename);
            }

            using (StreamReader sr = new StreamReader(filename))
            {
                
                string input = sr.ReadToEnd();
                   
                users = JsonConvert.DeserializeObject<List<User>>(input);

            }

            if (users == null) users = new List<User>();
            return users;
        }

        static void SaveUsers(List<User> users)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                string output = JsonConvert.SerializeObject(users);

                sw.Write(output);
            }
        }

        static User FindUserInList(string SSN, List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].SSN == SSN)
                {
                    return users[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Reads in all user instances from file and returns these in a list.
        /// </summary>
        static public List<User> Index()
        {
            List<User> users = ReadUsers();
            return users;
        }

        /// <summary>
        /// Reads in all user instances from file and returns the  user with a certain SSN number.
        /// </summary>
        /// <param name="ISBN"></param>
        static public User Details(string SSN)
        {
            List<User> users = ReadUsers();
            User u = FindUserInList(SSN, users);
            return u;
              }

        /// <summary>
        /// Creates a new user instance and adds it to the users on file.
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="Surname"></param>
        /// <param name="SSN"></param>
   
        static public void Create(string FirstName, string Surname, string SSN)
        {
            List<User> users = ReadUsers();
            users.Add(new User(FirstName, Surname, SSN));
            SaveUsers(users);
        }


        /// <summary>
        /// Reads in all user instances from file and updates an existing user (based on SSN number) then saves all user instances.
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="Surname"></param>
        /// <param name="SSN"></param>
        static public void Update(string FirstName, string Surname, string SSN)
        {
            List<User> users = ReadUsers();
            User u = FindUserInList(SSN, users);

            u.FirstName = FirstName;
            u.Surname = Surname;
            u.SSN = SSN;

            SaveUsers(users);
        }

        /// <summary>
        ///  Reads in all user instances from file, then deletes the user with a certain SSN number, then saves all user instances.
        /// </summary>
        /// <param name="SSN"></param>
        static public void Delete(string SSN)
        {
            List<User> users = ReadUsers();
            User u = FindUserInList(SSN, users);
            users.Remove(u);
            SaveUsers(users);
        }
    }

  
}



