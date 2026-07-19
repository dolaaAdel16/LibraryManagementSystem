using LibraryManagementSystem.Models;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Book book = new Book(1, "Clean Code", "Robert Martin", 2008, "Programming");
            //Console.WriteLine(book.GetInfo());
            //Console.WriteLine(book.MatchesQuery("clean"));

            Member member1 = new Member(1, "Ahmed", "ahmed@gmail.com");
            Member member2 = new Member(2, "Adel", "adel@gmail.com");

            Console.WriteLine(member1.GetInfo());
            Console.WriteLine(member2.GetInfo());



            Console.ReadKey();
        }

    }
}
