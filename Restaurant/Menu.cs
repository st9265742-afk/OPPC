using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Menu
{
    private List<MenuItem> _items = new List<MenuItem>();

    public void AddItem(MenuItem item)
    {
        _items.Add(item);
    }
    public void ShowAll()
    {
        Console.WriteLine("=== Повне меню ===");
        foreach (var item in _items)
        {
            item.ShowInfo();
        }
        Console.WriteLine("=================");
    }
    public MenuItem FindByName(string name)
    {
        return _items.FirstOrDefault(i => i.Name.ToLower() == name.ToLower());
    }
    public List<MenuItem> FindByCategory(string category)
    {
        return _items.OfType<Dish>().Where(d => d.Category.ToLower() == category.ToLower()).Cast<MenuItem>().ToList();
    }
}