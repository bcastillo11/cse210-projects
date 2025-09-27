using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        List<Product> list1 = new List<Product>
        {
            new Product("Carrot",      "C001", 0.45, 10),
            new Product("Dish Soap",   "D101", 2.99, 1),
            new Product("Socks",       "S201", 6.99, 3),
            new Product("Banana",      "B002", 0.25, 6),
            new Product("T-Shirt",     "T202", 12.50, 2)
        };

        List<Product> list2 = new List<Product>
        {
            new Product("Apple",       "A003", 0.60, 8),
            new Product("Laundry Det.", "L102", 8.49, 2),
            new Product("Cap",         "C204", 9.75, 1),
            new Product("Tomato",      "T004", 0.75, 5),
            new Product("Sponges",     "S105", 4.50, 2)
        };

        List<Product> list3 = new List<Product>
        {
            new Product("Jacket",      "J205", 45.00, 1),
            new Product("Lettuce",     "L005", 1.10, 2),
            new Product("Jeans",       "J203", 25.00, 1),
            new Product("Paper Towels","P103", 5.75, 3),
            new Product("Glass Cleaner","G104", 3.25, 1)
        };

        Address addr1 = new Address(
            "742 Evergreen Terrace",
            "Springfield",
            "Illinois",
            "USA"
        );

        Address addr2 = new Address(
            "Av. Insurgentes Sur 1602",
            "Ciudad de México",
            "CDMX",
            "Mexico"
        );

        Address addr3 = new Address(
            "Av. 9 de Julio 555",
            "Buenos Aires",
            "CABA",
            "Argentina"
        );

        Order order = new Order(list1, new Customer("Byron Castillo", addr1));
        Order order1 = new Order(list2, new Customer("Jhon Doe", addr2));
        Order order2 = new Order(list3, new Customer("Jane Doe", addr3));

        Console.WriteLine(new string('-', 40));

        Console.WriteLine(order.shippingLabel());
        Console.WriteLine(order.PackingLabel());

        Console.WriteLine(new string('-', 40));

        Console.WriteLine(order1.shippingLabel());
        Console.WriteLine(order1.PackingLabel());

        Console.WriteLine(new string('-', 40));

        Console.WriteLine(order2.shippingLabel());
        Console.WriteLine(order2.PackingLabel());

        Console.WriteLine(new string('-', 40));
        
    }
}