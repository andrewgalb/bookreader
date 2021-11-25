using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.Pages.Users
{
    public class IndexModel : PageModel
    {
        public List<User> users = new List<User>();

        public void OnGet()
        {
            users = UserRepository.Index();
        }
    }
}
