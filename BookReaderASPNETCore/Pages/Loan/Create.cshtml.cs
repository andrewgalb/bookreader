using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReader.Data;
using BookReader.Models;

namespace BookReaderASP.NETCore.Pages.Loans
{
    public class CreateModel : PageModel
    {
        public string ISBN;

        public void OnGet(string ISBN)
        {
            this.ISBN = ISBN;
        }
        public IActionResult OnPost(string firstName, string lastName, string ISBN)
        {
            LoanRepository.Create(firstName, lastName, ISBN);
            return RedirectToPage("/Loan/Index");
        }
    }
}
