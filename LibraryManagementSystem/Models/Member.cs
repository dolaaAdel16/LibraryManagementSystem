using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    internal class Member : ISearchable
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Email { get; set; }   
        public DateTime JoinDate { get; }

        public Book?[] BorrowedBooks { get; } = new Book?[10];

        public virtual int MaxBorrowLimit => 5;
        public virtual int LoanDays => 14;

        public Member(int id, string name, string email)
        {
            Id = id;
            Name = name;    
            Email = email;  
            JoinDate = DateTime.Now;    
        }
        
        public virtual string GetInfo()
        {
            return $"Regular Member - ID: {Id}, Name : {Name}, Email: {Email}";
        }

        public bool MatchesQuery(string query)
        {
            return Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                Email.Contains(query, StringComparison.OrdinalIgnoreCase);

        }

        public int GetBorrowedBooksCount()
        {
            int count = 0;
            foreach (Book? book in BorrowedBooks)
            {
                if(book is not null)
                {
                    count++;
                }
            }
            return count;
        }
        public void AddBorrowedBook(Book book)
        {
            if(GetBorrowedBooksCount() >= MaxBorrowLimit)
            {
                throw new InvalidOperationException("Member has reached the " +
                    "borrowing limit");
            }

            for (int i = 0; i<BorrowedBooks.Length; i++)
            {
                if (BorrowedBooks[i] is null)
                {
                    BorrowedBooks[i] = book;
                    return;
                }
            }
        }

        public void RemoveBorrowedBook(int bookId)
        {
            for (int i = 0; i<BorrowedBooks.Length; i++)
            {
                if (BorrowedBooks[i]?.Id == bookId)
                {
                    BorrowedBooks[i] = null;
                    return;
                }
            }
                    
        }
    }
}
