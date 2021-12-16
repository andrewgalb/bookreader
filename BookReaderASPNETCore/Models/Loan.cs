using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BookReader.Models
{
    [Serializable, XmlRoot("Loan")]
    public class Loan
    {
        [XmlElement("firstName")]
        public string firstName { get; set; }
        [XmlElement("lastName")]
        public string lastName { get; set; }
        [XmlElement("startDate")]
        public DateTime startDate { get; set; }
        [XmlElement("endDate")]
        public DateTime endDate { get; set; }
        [XmlElement("loanID")]
        public int loanID { get; set; }
        [XmlElement("bookISBN")]
        public int bookISBN { get; set; }

        public Loan() { }

        public Loan(string firstName, string lastName, DateTime startDate, DateTime endDate, int loanID, int bookISBN)
        {

            this.firstName = firstName;
            this.lastName = lastName;
            this.startDate = startDate;
            this.endDate = endDate;
            this.loanID = loanID;
            this.bookISBN = bookISBN;
        }
    }
}
