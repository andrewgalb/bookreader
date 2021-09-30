using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            using (StreamReader sr = new StreamReader("Books.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string title = sr.ReadLine();
                    string author = sr.ReadLine();
                    string genre = sr.ReadLine();
                    string isbn = sr.ReadLine();

                    books.Add(new Book(title, author, genre, isbn));
                }
            }
        }
    }
}
