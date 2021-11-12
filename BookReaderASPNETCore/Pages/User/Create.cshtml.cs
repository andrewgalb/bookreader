using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReader.Data;

namespace BookReaderASP.NETCore.Pages
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost(string ISBN, string Title, string Author, string Genre)
        {
            BookReaderRepository.Create(Title, Author, Genre, ISBN);
            return RedirectToPage("User/Index");
        }
    }
}
