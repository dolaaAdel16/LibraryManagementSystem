using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public class Library
    {
        private readonly Book?[] books = new Book?[100];   
        private readonly Member?[] members = new Member?[100];   
        private readonly BorrowRecord?[] records = new BorrowRecord?[500];

        private int bookCount;
        private int memberCount;
        private int recordCount;

        private int nextBookId = 1;
        private int nextMemberId = 1;
        private int nextRecordId = 1;

        private Book? FindBookById(int id)
        {
            for (int i = 0; i< bookCount; i++)
            {
                if (books[i]?.Id == id)
                {
                    return books[i];    
                }
            }
            return null;    
        }

        private Member? FindMemberById(int id)
        {
            for (int i = 0; i < memberCount; i++)
            {
                if (members[i]?.Id == id)
                {
                    return members[i];
                }
            } 
            return null;
        }

        private BorrowRecord? FindOpenRecord(int bookId)
        {
            for (int i = 0; i < recordCount; i++)
            {
                BorrowRecord? record = records[i];

                if (record?.Book.Id == bookId && record.ReturnDate is null)
                {
                    return record;
                }
            }
            return null;
        
        }

        public void AddBook(string title, string author, int year, string genre)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) ||
                string.IsNullOrWhiteSpace(genre))
            {
                throw new ArgumentException("Book data cannot be empty.");
            }

            if (bookCount >= books.Length)
            {
                throw new InvalidOperationException("Books array is full.");
            }

            Book book = new Book(nextBookId, title, author, year, genre);

            books[bookCount] = book; 

            bookCount++;
            nextBookId++;
        }

        public void RegisterMember(string name, string email, bool isPremium)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Name and email email are required.");
            }

            Member member;

            if(isPremium)
            {
                member = new PremiumMember(nextMemberId, name, email);  
            }
            else
            {
                member = new Member (nextMemberId, name, email);
            }
            members[memberCount] = member;

            memberCount++;
            nextMemberId++;
        }

        public void ViewAvailableBooks()
        {
            bool found = false; 

            for (int i = 0 ; i < bookCount; i++)
            {
                Book? book = books[i];

                if (book is not null && book.IsAvailable)
                {
                    Console.WriteLine(book.GetInfo());
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No available books.");
            }
        }

        public void SearchCatalog(string query)
        {
            bool found = false;   

            for (int i = 0; i < bookCount; i ++)
            {
                Book? book = books[i];

                if (book is not null && book.MatchesQuery(query))
                {
                    Console.WriteLine($"[Book] {book.GetInfo()}");
                    found = true;
                }
            }

            for (int i = 0; i < memberCount; i ++)
            {
                Member? member = members[i];

                if (member is not null && member.MatchesQuery(query))
                {
                    Console.WriteLine($"[Member] {member.GetInfo()}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matching records."); 
            }
        }

        public void BorrowBook(int bookId, int memberId)
        {
            Book book = FindBookById(bookId) ?? throw new InvalidOperationException
                ("Book not found.");

            Member member = FindMemberById(memberId) ?? throw new InvalidOperationException
                ("Member not found.");

            if(!book.IsAvailable)
            {
                throw new InvalidOperationException("Book is already borrowed");
            }

            if(member.GetBorrowedBooksCount() >= member.MaxBorrowLimit)
            {
                throw new InvalidOperationException("Member reached the borrowing limit.");
            }

            BorrowRecord record = new BorrowRecord(nextRecordId, book, member);

            records[recordCount] = record;

            recordCount++;
            nextRecordId++;

            book.IsAvailable = false;
            member.AddBorrowedBook(book);
        }

        public void ReturnBook(int bookId)
        {
            BorrowRecord record = FindOpenRecord(bookId) ?? throw new InvalidOperationException(
                "No open borrow record found."); 

            record.MarkAsReturned();

            record.Book.IsAvailable = true;

            record.Member.RemoveBorrowedBook(bookId);
        }

        public void ShowMemberHistory(int memberId)
        {
            Member member = FindMemberById(memberId) ?? throw new InvalidOperationException(
                "Member not found.");

            bool found = false;

            for (int i = 0;  i < recordCount; i++)
            {
                BorrowRecord? record = records[i];
                if (record?.Member.Id == member.Id)
                {
                    string status = record.ReturnDate is null ? "Not returned" : $"Returned: {record.ReturnDate.Value:d}";
                    Console.WriteLine($"{record.Book.Title}| " + $"Borrowd: {record.BorrowDate:d} | " + status);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("This member has no borrowing history.");
            }
        }   

        public void ShowLateReturnReport()
        {
            bool found = false;

            for (int i = 0; i < recordCount; i++)
            {
                BorrowRecord? record = records[i];  

                if (record is not null && record.IsLate())
                {
                    Console.WriteLine(
                        $"Member : {record.Member.Name}" +
                        $"Book: {record.Book.Title}," +
                        $"Borrowed: {record.BorrowDate:d}" +
                        $"Days overdue: {record.GetDaysOverDue()}"
                    );
                    found = true;
                }
            }
            if ( !found )
            {
                Console.WriteLine("No late borrow records.");
            }
        }
    }
}
