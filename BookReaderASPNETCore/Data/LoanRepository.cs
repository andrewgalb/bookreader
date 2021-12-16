using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using BookReader.Models;

namespace BookReader.Data
{
    public class LoanRepository
    {
        static List<Loan> ReadLoans()
        {
            string fileName = "Loans.xml";

            XmlSerializer serializerLoan = new XmlSerializer(typeof(List<Loan>));

            if (File.Exists(fileName))
            {
                
                using (var reader = new StreamReader(fileName))
                {
                    List<Loan> LoansLoaded = (List<Loan>)serializerLoan.Deserialize(reader);

                    return LoansLoaded;
                }

            }


            return null;
        }
        static void SaveLoans(List<Loan> loans)
        {
            string fileName = "users.json";

            if (File.Exists(fileName))
            {
                XmlSerializer serializerLoan = new XmlSerializer(typeof(List<Loan>));

                using (var writer = new StreamWriter("Loans.xml"))
                {

                    serializerLoan.Serialize(writer, loans);
                }
            }

        }
        static Loan FindLoanInList(int loanID, List<Loan> loans)
        {
            for (int i = 0; i < loans.Count; i++)
            {
                if (loans[i].loanID == loanID)
                {
                    return loans[i];
                }
            }
            return null;
        }
        public static bool FindTrue(int loanID)
        {
            bool x = false;
            List<Loan> loans = ReadLoans();
            if (FindLoanInList(loanID, loans) != null)

            {
                x = true;
            }
            return x;
        }
        public static List<Loan> Index()
        {
            List<Loan> loans = ReadLoans();

            return loans;
        }
        public static Loan Details(int loanID)
        {
            List<Loan> loans = ReadLoans();
            Loan l = FindLoanInList(loanID, loans);
            return l;
        }
        public static void Create(string firstName, string lastName, int bookISBN)
        {
            int loanID;
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddMonths(1);
            List<Loan> loans = ReadLoans();
            for (int i = 1; i == loans[i].loanID; i++)
            {
                if (i != loans[i].loanID)
                {
                    loanID = i;
                    loans.Add(new Loan(firstName, lastName, startDate, endDate, loanID, bookISBN));
                    SaveLoans(loans);
                }
            }

        }
        public static void Update(string firstName, string lastName, int loanID)
        {
            List<Loan> loans = ReadLoans();
            Loan l = FindLoanInList(loanID, loans);
            l.firstName = firstName;
            l.lastName = lastName;

            l.loanID = loanID;

            SaveLoans(loans);
        }
        public static void Delete(int loanID)
        {
            List<Loan> loans = ReadLoans();
            Loan l = FindLoanInList(loanID, loans);
            loans.Remove(l);
            SaveLoans(loans);
        }
    }
}
