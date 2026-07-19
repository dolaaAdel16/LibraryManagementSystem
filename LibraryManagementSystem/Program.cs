using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Book book = new Book(1, "Clean Code", "Robert Martin", 2008, "Programming");
            //Console.WriteLine(book.GetInfo());
            //Console.WriteLine(book.MatchesQuery("clean"));

            //Member member1 = new Member(1, "Ahmed", "ahmed@gmail.com");
            //Member member2 = new Member(2, "Adel", "adel@gmail.com");

            //Console.WriteLine(member1.GetInfo());
            //Console.WriteLine(member2.GetInfo());

            Library library = new Library();

            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("===== Library System =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Register Member");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. Search Catalog");
                Console.WriteLine("6. View Available Books");
                Console.WriteLine("7. Member History");
                Console.WriteLine("8. Late Return Report");
                Console.WriteLine("0. Exit");

                Console.Write("Choose: ");
                string? choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {

                        case "1":
                            break;

                        case "2":
                            break;

                        case "3":
                            break;

                        case "4":
                            break;

                        case "5":
                            break;

                        case "6":
                            library.ViewAvailableBooks();
                            break;

                        case "7":
                            break;

                        case "8":
                            library.ShowLateReturnReport();
                            break;

                        case "0":
                            running = false;
                            break;


                        default:
                            Console.WriteLine("Invalid Choice.");
                            break;


                    }
                }

                catch (Exception exception)
                {
                    Console.WriteLine($"Error:{exception.Message}");
                }
            }


            Console.ReadKey();
        }

    }
}
