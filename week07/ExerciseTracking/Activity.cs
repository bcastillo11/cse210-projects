using System.Globalization;

public abstract class Activity
{
    protected double Length { get; set; }
    private DateTime _date;

    protected DateTime Date
    {
        get { return DateTime.Now; }

        set { _date = value; }
    }

    protected Activity(DateTime date, int length)
    {
        Date = date;
        Length = length;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string dateStr = Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        string activityName = this.GetType().Name;

        return $"{dateStr} {activityName} ({Length} min) - " +
            $"Distance: {GetDistance():F2} miles, " +
            $"Speed: {GetSpeed():F2} mph, " +
            $"Pace: {GetPace():F2} min per mile";
    }
}