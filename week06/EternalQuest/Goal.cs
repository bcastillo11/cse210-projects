public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Points { get; set; }

    public Goal(string name, string description, string points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        if (IsComplete())
        {
            return $"[X] {Name} ({Description})";
        }
        else
        {
            return $"[ ] {Name} ({Description})";
        }
    }

    public abstract string GetStringRepresentation();


}