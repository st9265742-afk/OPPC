using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dish : MenuItem
{
    public string Category { get; private set; }

    public Dish(string name, decimal price, string category)
        : base(name, price)
    {
        Category = category;
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"{Name} — {Price} грн | Категорія: {Category}");
    }
}

public class Drink : MenuItem
{
    public int Volume { get; private set; }
    public bool IsAlcoholic { get; private set; }

    public Drink(string name, decimal price, int volume, bool isAlcoholic)
        : base(name, price)
    {
        Volume = volume;
        IsAlcoholic = isAlcoholic;
    }
    public override void ShowInfo()
    {
        string alcoholInfo = IsAlcoholic ? "алкогольний" : "безалкогольний";
        Console.WriteLine($"{Name} — {Price} грн | {Volume} мл | {alcoholInfo}");
    }
}
