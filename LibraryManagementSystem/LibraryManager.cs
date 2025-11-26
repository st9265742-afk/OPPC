using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class LibraryManager
    {
        public LibraryCatalog<Book> _bookCatalog;
        public LibraryCatalog<Magazine> _magazineCatalog;

        public LibraryManager()
        {
            _bookCatalog = new LibraryCatalog<Book>();
            _magazineCatalog = new LibraryCatalog<Magazine>();
        }
        public void AddItem(ILibraryItem item)
        {
            if (item is Book book)
            {
                _bookCatalog.AddItem(book);
            }
            else if (item is Magazine magazine)
            {
                _magazineCatalog.AddItem(magazine);
            }
            else
            {
                Console.WriteLine("Невідомий тип елемента");
            }
        }
        public List<ILibraryItem> GetAllItems()
        {
            var allItems = new List<ILibraryItem>();
            allItems.AddRange(_bookCatalog.GetAllItems());
            allItems.AddRange(_magazineCatalog.GetAllItems());
            return allItems;
        }
        public ILibraryItem? GetItemById(int id)
        {
            var book = _bookCatalog.GetItemById(id);
            if (book != null)
                return book;

            var magazine = _magazineCatalog.GetItemById(id);
            if (magazine != null)
                return magazine;

            return null;
        }
    }
}
