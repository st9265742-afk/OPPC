using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum OrderStatus
{
    New,
    InProgress,
    Ready,
    Paid
}
public class Order
{
    private static int _nextId = 1;

    public int ID { get; private set; }
    public int TableNumber { get; private set; }
    public List<MenuItem> Items { get; private set; }
    public OrderStatus Status { get; private set; }
    public Order(int tableNumber)
    {
        ID = _nextId++;
        TableNumber = tableNumber;
        Items = new List<MenuItem>();
        Status = OrderStatus.New;
    }
    public void AddItem(MenuItem item)
    {
        Items.Add(item);
    }
    public void RemoveItem(MenuItem item)
    {
        Items.Remove(item);
    }
    public decimal TotalPrice()
    {
        return Items.Sum(i => i.Price);
    }
    public void ChangeStatus(OrderStatus newStatus)
    {
        Status = newStatus;
    }
    public void ShowOrder()
    {
        Console.WriteLine($"Замовлення #{ID} | Столик {TableNumber} | Статус: {Status}");
        foreach (var item in Items)
        {
            item.ShowInfo();
        }
        Console.WriteLine($"Сума: {TotalPrice()} грн");
        Console.WriteLine("-------------------------");
    }
}
