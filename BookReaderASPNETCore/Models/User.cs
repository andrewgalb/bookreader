using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class User
    {
        public string FirstName;
        public string Surname;
        public string SSN;

        public User(string FirstName, string Surname, string SSN)
        {
            this.FirstName = FirstName;
            this.Surname = Surname;
            this.SSN = SSN;
        }
    }

}
