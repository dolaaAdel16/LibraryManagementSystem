using LibraryManagementSystem.Models;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book(1, "Clean Code", "Robert Martin", 2008, "Programming");
            Console.WriteLine(book.GetInfo());
            Console.WriteLine(book.MatchesQuery("clean"));


            Console.ReadKey();
        }

    }
}
