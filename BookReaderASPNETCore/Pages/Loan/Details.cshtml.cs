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
    public class DetailsModel : PageModel
    {
        public Loan loan;

        public void OnGet(int loanID)
        {

            loan = LoanRepository.Details(loanID);
          
        }
    }
}
