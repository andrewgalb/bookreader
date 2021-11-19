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
    public class DetailsModel : PageModel
    {
        public Book book;

        public void OnGet(string bookID)
        {
          
            book = BookReaderRepository.Details(bookID);
          
        }
    }
}
