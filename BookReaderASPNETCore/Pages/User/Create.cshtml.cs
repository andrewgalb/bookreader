using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReader.Data;

namespace BookReaderASP.NETCore.Pages.Users
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost(string firstName, string lastName, string personNum, string eMail, string postAdress, string postNum, string city)
        {
            UserRepository.Create(firstName, lastName, personNum, eMail, postAdress, postNum, city);
            return RedirectToPage("/User/Index");
        }
    }
}
