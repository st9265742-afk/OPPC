using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class LibraryCatalog<T> where T : ILibraryItem
    {
        public List<T> _items;

        List<T> items = new List<T>();

        public void AddItem(T item)
        {
            items.Add(item);
        }
        public List<T> GetAllItems()
        {
            return items;
        }
        public T? GetItemById(int id)
        {
            foreach (var item in items)
            {
                if (item.Id == id)
                    return item;
            }
            return default;
        }
    }
}
