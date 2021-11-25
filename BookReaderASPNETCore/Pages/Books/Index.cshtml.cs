using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.Pages.Books
{
    public class IndexModel : PageModel
    {
        public List<Book> books = new List<Book>();

        public void OnGet()
        {
            books = BookRepository.Index();
        }
    }
}
