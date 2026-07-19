using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class BorrowRecord
    {
        public int Id { get; }    
        public Book Book { get; }  
        public Member Member { get; }
        public DateTime BorrowDate { get; } 
        public DateTime? ReturnDate { get; set; }

        public BorrowRecord(int id, Book book, Member member)
        {
            Id = id;
            Book = book;
            Member = member;
            BorrowDate = DateTime.Now;
            ReturnDate = null;
        }

        public bool IsLate()
        {
            if (ReturnDate is not null)
            {
                return false;
            }

            double borrowedDays = (DateTime.Now - BorrowDate).TotalDays ;

            return borrowedDays > Member.LoanDays;
        }

        public int GetDaysOverDue()
        {
            int borrowedDays = (int)(DateTime.Now - BorrowDate).TotalDays;

            return Math.Max(0, borrowedDays - Member.LoanDays); 

        }

        public void MarkAsReturned()
        {
            ReturnDate = DateTime.Now;
        }


    }
}
