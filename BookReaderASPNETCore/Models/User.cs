using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Models
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string personNum { get; set; }
        public string eMail { get; set; }
        public string postAdress { get; set; }
        public string postNum { get; set; }
        public string city { get; set; }

        public string userID;
        public User(string firstName, string lastName, string personNum, string eMail, string postAdress, string postNum, string city, string userID)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.personNum = personNum;
            this.eMail = eMail;
            this.postAdress = postAdress;
            this.postNum = postNum;
            this.city = city;
            this.userID = userID;
        }
    }
}
