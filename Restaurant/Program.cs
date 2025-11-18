
class Program
{
    static void Main()
    {
        Menu menu = new Menu();
        menu.AddItem(new Dish("Борщ український", 120, "Перші страви"));
        menu.AddItem(new Dish("Котлета по-київськи", 180, "Гарячі страви"));
        menu.AddItem(new Drink("Лимонад", 60, 300, false));
        menu.AddItem(new Drink("Вино червоне", 150, 150, true));

        menu.ShowAll();

        Restaurant restaurant = new Restaurant();
        Order order1 = new Order(1);
        order1.AddItem(menu.FindByName("Борщ український"));
        order1.AddItem(menu.FindByName("Лимонад"));

        restaurant.AddOrder(order1);

        restaurant.ShowActiveOrders();

        order1.ChangeStatus(OrderStatus.Ready);
        restaurant.ShowActiveOrders();
    }
}

