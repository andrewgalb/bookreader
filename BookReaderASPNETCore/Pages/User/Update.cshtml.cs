using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReader.Models;
using BookReader.Data;

namespace BookReaderASP.NETCore.Pages.Users
{
    public class UpdateModel : PageModel
    {
        public User u;
        public void OnGet(string userID)
        {
            
            u = UserRepository.Details(userID);

        }
        public IActionResult OnPost(string firstName, string lastName, string personNum, string eMail, string postAdress, string postNum, string city, string userID)
        {
            
            UserRepository.Update(firstName, lastName, personNum, eMail, postAdress, postNum, city, userID);
            return RedirectToPage("/User/Index");
        }
    }
}
