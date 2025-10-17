public class SimpleGoal : Goal
{
    public bool _IsComplete { get; set; }

    public SimpleGoal(string name, string description, string points, bool isComplete = false) : base(name, description, points)
    {
        _IsComplete = isComplete;
    }

    public override void RecordEvent()
    {
        _IsComplete = true;

        Console.WriteLine($"Congratulations! You have earned {Points} points!");
    }

    public override bool IsComplete()
    {
        if (_IsComplete)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{_IsComplete}";
    }
}