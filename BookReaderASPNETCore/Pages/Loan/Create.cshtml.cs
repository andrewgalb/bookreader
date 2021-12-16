using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReader.Data;

namespace BookReaderASP.NETCore.Pages.Loans
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost(string firstName, string lastName, int ISBN)
        {
            LoanRepository.Create(firstName, lastName, ISBN);
            return RedirectToPage("/Loan/Index");
        }
    }
}
