public class Running : Activity
{
    public double Distance { get; set; }
    public Running(DateTime date, int length, double distance) : base(date, length)
    {
        Distance = distance;
    }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetPace()
    {
        if (Distance == 0) return 0;
        return (double)Length / Distance;   
    }

    public override double GetSpeed()
    {
        if (Length == 0) return 0;
        return (Distance / Length) * 60.0;
    }
}