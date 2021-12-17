using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReader.Data;

namespace BookReaderASP.NETCore.Pages.Users
{
    public class DeleteModel : PageModel
    {
        public IActionResult OnGet(Guid userID)
        {
            UserRepository.Delete(userID);
            return RedirectToPage("/User/Index");
        }
    }
}
