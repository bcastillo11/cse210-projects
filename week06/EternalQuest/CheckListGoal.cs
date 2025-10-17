using System.Drawing;

public class CheckListGoal : Goal
{

    public int AmountCompleted { get; set; }
    public int Target { get; set; }
    public int Bonus { get; set; }
    private int _halfWayBonus;
    public int HalfwayBonus
    {
        get => _halfWayBonus;
        set
        {
            _halfWayBonus = Bonus / 2;
        }
    }


    public CheckListGoal(string name, string description, string points, int bonus, int target, int amountCompleted) : base(name, description, points)
    {
        Bonus = bonus;
        Target = target;
        AmountCompleted = amountCompleted;
    }

    public override string GetStringRepresentation()
    {
        // throw new NotImplementedException();

        return $"CheckListGoal:{Name},{Description},{Points},{Bonus},{Target},{AmountCompleted}";
    }

    public override bool IsComplete()
    {
        // throw new NotImplementedException();

        if (Target == AmountCompleted)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //     public override void RecordEvent()
    //     {
    //         // throw new NotImplementedException();
    //         AmountCompleted++;

    //         if (AmountCompleted > Target)
    //         {
    //             Console.WriteLine($"Congratulations! You had previously completed this goal. You get no points at this time.{Environment.NewLine}Try completing a different goal.");
    //             AmountCompleted--;
    //             return;
    //         }

    //         if (IsComplete())
    //         {
    //             Console.WriteLine($"Congratulations! You completed your goal: \"{Name}\"{Environment.NewLine}You get {Bonus + int.Parse(Points)} points!");
    //             return;
    //         }

    //         int halfwayPoint = (int)Math.Ceiling(Target / 2.0);


    //         if (AmountCompleted == halfwayPoint)
    //         {
    //             Console.WriteLine($"Congratulation! You have earned {Bonus + int.Parse(Points)} points");
    //         }
    //         else
    //         {
    //             Console.WriteLine($"Congratulation! You have earned {Points} points");
    //         }
    // }

    public override void RecordEvent()
    {
        AmountCompleted++;

        if (AmountCompleted > Target)
        {
            Console.WriteLine($"Congratulations! You already completed this goal earlier. No points this time.{Environment.NewLine}Try a different goal.");
            AmountCompleted--;
            return;
        }

        int halfwayPoint = (int)Math.Ceiling(Target / 2.0);

        if (AmountCompleted == halfwayPoint && AmountCompleted != Target)
        {
            Console.WriteLine($"You're halfway there! Keep it up! You earned {Points} points");
            return;
        }

        if (IsComplete())
        {
            Console.WriteLine($"Congratulations! You completed your goal: \"{Name}\"{Environment.NewLine}You get {Bonus + int.Parse(Points)} points!");
            return;
        }

        Console.WriteLine($"Good job! You earned {Points} points.");
    }


    public override string GetDetailsString()
    {
        if (IsComplete())
        {
            return $"[X] {Name} ({Description} -- Currently Completed: {AmountCompleted}/{Target})";
        }
        else
        {
            return $"[ ] {Name} ({Description} -- Currently Completed: {AmountCompleted}/{Target})";
        }
    }
}