public class Product
{
    private string _name;
    private string _id;
    private double _price;
    private int _quant;

    public Product(string name, string id, double price, int quant)
    {
        _name = name;
        _id = id;
        _price = price;
        _quant = quant;
    }

    public double Total()
    {
        return _price * _quant;
    }

    public override string ToString()
    {
        return $"{_id,-6} |{_name,-15} |{_quant,-3}";
    }

}