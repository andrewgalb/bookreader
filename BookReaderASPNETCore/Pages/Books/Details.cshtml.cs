using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Library.Data;

namespace Library.Pages.Books
{
    public class DetailsModel : PageModel
    {
        public Book book;
        public void OnGet(string ISBN)
        {
            book = BookRepository.Details(ISBN);
        }
    }
}
