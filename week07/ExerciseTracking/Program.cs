using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
        DateTime date = new DateTime();

        Running running = new Running(date, 15, 1.7);
        Cycling cycling = new Cycling(date, 45, 10);
        Swimming swimming = new Swimming(date, 30, 6);

        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}