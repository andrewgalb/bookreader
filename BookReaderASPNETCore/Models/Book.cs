using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Models
{
    public class Book
    {
        public string Title;
        public string Author;
        public string Genre;
        public string ISBN;

        public Book(string Title, string Author, string Genre, string ISBN)
        {
            this.Title = Title;
            this.Author = Author;
            this.Genre = Genre;
            this.ISBN = ISBN;
        }
    }

}
