using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookReader.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReader.Data;


namespace BookReaderASP.NETCore.Pages.Users
{
    public class IndexModel : PageModel
    {
        public List<User> users = new();

        public void OnGet()
        {
             users = UserRepository.Index();
        }
    }
}
