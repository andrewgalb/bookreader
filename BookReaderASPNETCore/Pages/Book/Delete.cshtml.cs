using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReader.Data;

namespace BookReaderASP.NETCore.Pages.Books
{
    public class DeleteModel : PageModel
    {
        public IActionResult OnGet(string ISBN)
        {
            BookReaderRepository.Delete(ISBN);
            return RedirectToPage("Index");
        }
    }
}
