using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello World! This is the Exercise1 Project.");

        Console.WriteLine("What is your name: ");
        string name = Console.ReadLine();

        Console.WriteLine("What is your last name: ");
        string l_name = Console.ReadLine();

        Console.WriteLine($"Your name is {l_name}, {name} {l_name}");
    }
}