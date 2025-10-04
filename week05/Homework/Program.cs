using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Homework Project.");

        Assignment assignment = new Assignment("Samuel Bennet", "Multiplication");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3", "8-19");
        Console.WriteLine($"{mathAssignment.GetSummary()}{Environment.NewLine}{mathAssignment.GetHomeWorkList()}");

        WritingAssignment writing = new WritingAssignment("Mary Waters", "European History", "The causes of Worl War II");
        Console.WriteLine($"{writing.GetSummary()}{Environment.NewLine}{writing.GetWritingInfo()}");
    }
}