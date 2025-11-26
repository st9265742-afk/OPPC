using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Book : LibraryItemBase
    {
        public override int Id { get; protected set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(int id, string title, string author, int year) : base(title, year)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
        }

        public override string GetItemType()
        {
            return "Book";
        }
        public override string GetDisplayInfo()
        {
            return $"{Id}: {Title} — {Author}";
        }
    }
}
