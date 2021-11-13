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
    public class UpdateModel : PageModel
    {
        public Book b;
        public void OnGet(string ISBN)
        {
            b = BookReaderRepository.Details(ISBN);
        }
        public IActionResult OnPost(string ISBN, string Title, string Author, string Genre)
        {
            BookReaderRepository.Update(Title, Author, Genre, ISBN);
            return RedirectToPage("User/Index");
        }
    }
}
