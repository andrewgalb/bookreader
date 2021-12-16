using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReader.Data;

namespace BookReaderASP.NETCore.Pages.Loans
{
    public class DeleteModel : PageModel
    {
        public IActionResult OnGet(string loanID)
        {
            BookReaderRepository.Delete(loanID);
            return RedirectToPage("/Loan/Index");
        }
    }
}
