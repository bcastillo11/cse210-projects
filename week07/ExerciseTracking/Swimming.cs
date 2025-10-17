public class Swimming : Activity
{
    public int Laps { get; set; }
    private const double _metersPerLap = 50.00;

    public Swimming(DateTime date, int length, int laps) : base(date, length)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * _metersPerLap / 1000 * 0.62;
    }

    public override double GetPace()
    {
        return Length / GetDistance();
    }

    public override double GetSpeed()
    {
        return 60 / GetPace();
    }
}