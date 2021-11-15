using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReader.Models;
using BookReader.Data;

namespace BookReaderASP.NETCore.Pages
{
    public class UpdateModel2 : PageModel
    {
        public User u;
        public void OnGet(string postAdress)
        {
            
            u = UserRepository.Details(postAdress);

        }
        public IActionResult OnPost(string firstName, string lastName, string personNum, string eMail, string postAdress, string postNum, string city)
        {
            
            UserRepository.Update(firstName, lastName, personNum, eMail, postAdress, postNum, city);
            return RedirectToPage("/User/Index");
        }
    }
}
