using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class MenuItem
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    protected MenuItem(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public abstract void ShowInfo();
}