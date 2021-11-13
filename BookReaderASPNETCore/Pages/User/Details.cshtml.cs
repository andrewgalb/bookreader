using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReader.Models;
using BookReader.Data;

namespace BookReader.Pages
{
    public class DetailsModel2 : PageModel
    {
        public User u;

        public void OnGet(string postAdress)
        {

            u = UserRepository.Details(postAdress);

        }
    }
}
