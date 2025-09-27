public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = new List<Product>(products);
        _customer = customer;
    }

    public Order()
    {
        _products = null;
        _customer = null;
    }

    public double OrderTotal()
    {
        double total = 0;
        double shipping = 0;

        foreach (Product product in _products)
        {
            total += product.Total();
        }

        if (_customer.LivesInUSA())
        {
            shipping = 5;
        }
        else
        {
            shipping = 35;
        }

        total += shipping;

        return total;
    }

    public string PackingLabel()
    {

        return string.Join(Environment.NewLine, _products.Select(p => p.ToString()));
    }


    public string shippingLabel()
    {

        return _customer.ToString();
    }
}