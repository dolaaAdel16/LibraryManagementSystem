using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Book : LibraryItem, ISearchable
    {
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        public bool IsAvailable { get; set; }   

        public Book(int id, string title,  string author, int year, string genre): base(id, title)
        {
            Author = author;
            Year = year;
            Genre = genre;
            IsAvailable = true; 
        }

        public override string GetInfo()
        {
            string status = IsAvailable ? "Available" : "Borrowed";
            return $"ID: {Id}, Title: {Title}, Author: {Author}," +
                   $" Year: {Year}, Genre: {Genre}, Status: {status}";
        }

        public bool MatchesQuery(string query)
        {
            return Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                   Author.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                   Genre.Contains(query, StringComparison.OrdinalIgnoreCase);
        }
    }
}
