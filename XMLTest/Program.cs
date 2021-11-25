using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace XMLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializerLoan = new XmlSerializer(typeof(List<Loan>));

            List<Loan> Loans = new List<Loan>();
            Loans.Add(new Loan("Theo", new DateTime(2021, 09, 25), new DateTime(2021, 11, 25)));
            using (var writer = new StreamWriter("Loans.xml"))
            {
                
                serializerLoan.Serialize(writer, Loans);
            }



            using (var reader = new StreamReader("Loans.xml"))
            {
                List<Loan> LoansLoaded = (List<Loan>)serializerLoan.Deserialize(reader);
                foreach (var item in LoansLoaded)
                {
                    Console.WriteLine(
                        item.name + "\n" + item.startDate + "\n" + item.endDate);
                }
            }
        }
     
    }
    public class Loan
    {
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public Loan() { }

        public Loan(string name, DateTime startDate, DateTime endDate)
        {

            this.name = name;
            this.startDate = startDate;
            this.endDate = endDate;
        }
    }
}
