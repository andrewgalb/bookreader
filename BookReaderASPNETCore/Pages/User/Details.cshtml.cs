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
    public class DetailsModel : PageModel
    {
        public User u;

        public void OnGet(Guid userID)
        {

            u = UserRepository.Details(userID);

        }
    }
}
