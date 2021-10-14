using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookReader.Data;
using BookReader.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookReader.Pages
{
    public class IndexModel : PageModel
    {
        public List<Book> books = new List<Book>();

        public void OnGet()
        {
            books = BookReaderRepository.Index();
        }
    }
}
