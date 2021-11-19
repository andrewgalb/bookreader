using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReader.Models;
using BookReader.Data;

namespace BookReaderASP.NETCore.Pages.Books
{
    public class UpdateModel : PageModel
    {
        public Book b;
        public void OnGet(string bookID)
        {
            b = BookReaderRepository.Details(bookID);
        }
        public IActionResult OnPost(string ISBN, string Title, string Author, string Genre, string bookID)
        {
            BookReaderRepository.Update(Title, Author, Genre, ISBN, bookID);
            return RedirectToPage("/Book/Index");
        }
    }
}
