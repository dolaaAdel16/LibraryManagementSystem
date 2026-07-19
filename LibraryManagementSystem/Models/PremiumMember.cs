using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class PremiumMember : Member
    {
        public override int MaxBorrowLimit => 10;
        public override int LoanDays => 30;

        public PremiumMember(int id, string name, string email) : base(id, name, email)
        { }

        public override string GetInfo()
        {

            {
                return $"Premium Member - ID: {Id}, Name: {Name}, " +
                    $"Email: {Email}, Limit: {MaxBorrowLimit}, " +
                    $"LoanDays: {LoanDays}";
            }
        }
    }
}
