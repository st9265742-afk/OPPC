using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public abstract class LibraryItemBase : ILibraryItem
    {
        public readonly int _nextId = 1;
        public string Title { get; }
        public int Year { get; set; }
        public abstract int Id { get; protected set; }

        public LibraryItemBase(string title, int year)
        {
            Title = title;
            Year = year;
            Id = _nextId++;
        }
        public virtual string GetDisplayInfo()
        {
            return ($"{GetItemType()}[Type] ID: [Id], Title: [Title], Year: [Year]");
        }
        public abstract string GetItemType();
    }
}
