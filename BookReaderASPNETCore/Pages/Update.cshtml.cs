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
        List<Book> books = new List<Book>();
        public void OnGet()
        {
            
        }
        public IActionResult OnPost(string ISBN, string Title, string Author, string Genre)
        {
            BookReaderRepository.Update(Title, Author, Genre, ISBN);
            return RedirectToPage("Index");
        }
    }
}
