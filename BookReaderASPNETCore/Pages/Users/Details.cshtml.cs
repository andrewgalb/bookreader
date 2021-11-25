using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.Pages.Users
{
    public class DetailsModel : PageModel
    {
        public User user;
        public void OnGet(string SSN)
        {
            user = UserRepository.Details(SSN);
        }
    }
}
