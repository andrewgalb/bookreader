using System;
using System.Collections.Generic;

namespace BookReaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //View all books and one specific book
            Console.WriteLine("\nRunning index:");
            BookReaderRepository.Index();
            Console.WriteLine("\nRunning details:");
            BookReaderRepository.Details("1-86092-022-5");

            Console.WriteLine("\nCreating book:");
            //Create  a book, then view all books to see if book has been created...
            BookReaderRepository.Create("The Art of Motorcycle Mainentance", "Robert Maynard Pirsig", "Self-Destruction", "0-688-00230-7");
            Console.WriteLine("\nRunning index:");
            BookReaderRepository.Index();

            //Update a book, then check to see if that specific book has been updated
            Console.WriteLine("\nUpdating book:");
            BookReaderRepository.Update("The Art of Motorcycle Mainentance", "Robert Maynard Pirsig", "Self-Help", "0-688-00230-7");
            Console.WriteLine("\nChecking details:");
            BookReaderRepository.Details("0-688-00230-7");

            //Delete a book, then view all books to make sure "The Open Boat" has been deleted
            Console.WriteLine("\nDeleting book:");
            BookReaderRepository.Delete("0-688-00230-7");
            Console.WriteLine("\nRunning index:");
            BookReaderRepository.Index();
        }
    }

}
