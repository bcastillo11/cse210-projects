public class Cycling : Activity
{
    public double Speed { get; set; }

    public Cycling(DateTime date, int length, double speed) : base(date, length)
    {
        Speed = speed;
    }

    public override double GetDistance()
    {
        double hours = (double)Length / 60.0;
        return Speed * hours;
    }

    public override double GetPace()
    {
        if (Speed == 0) return 0;
        return 60.0 / Speed;
    }

    public override double GetSpeed()
    {
        return Speed;
    }
}