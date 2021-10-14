using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReader.Data;
using BookReader.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookReaderASP.NETCore.Pages
{
    public class DetailsModel : PageModel
    {
        public Book book;
        public void OnGet()
        {
            book = BookReaderRepository.Details("1-86092-006-3");

        }
    }
}
