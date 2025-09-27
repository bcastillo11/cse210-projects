public class Customer
{
    private string _name;
    private Address _address;

    public Customer()
    {
        _name = "";
        _address = null;
    }

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUSA()
    {
        if (_address.IsInUSA())
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{_name, -20}{_address.ToString(), 20}";
    }   
}