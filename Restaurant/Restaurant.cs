using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Restaurant
{
    private List<Order> _orders = new List<Order>();

    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }
    public Order FindOrderById(int id)
    {
        return _orders.FirstOrDefault(o => o.ID == id);
    }
    public void ShowActiveOrders()
    {
        Console.WriteLine("=== Активні замовлення ===");
        foreach (var order in _orders.Where(o => o.Status != OrderStatus.Paid))
        {
            order.ShowOrder();
        }
    }
}
