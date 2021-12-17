using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReader.Models;
using BookReader.Data;

namespace BookReaderASP.NETCore.Pages.Loans
{
    public class UpdateModel : PageModel
    {
        public Loan l;
        public void OnGet(Guid loanID)
        {
            l = LoanRepository.Details(loanID);
        }
        public IActionResult OnPost(string firstName, string lastName, DateTime startDate, DateTime endDate, Guid loanID, int bookISBN)
        {
            LoanRepository.Update(firstName, lastName, loanID);
            return RedirectToPage("/Loan/Index");
        }
    }
}
