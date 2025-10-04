using System;

class Program
{
    static void Main(string[] args)
    {
        DateTime endTime = DateTime.Now.AddSeconds(5);

        Console.Clear();

        Console.WriteLine("Get Ready...");

        while (DateTime.Now < endTime)
        {
            Console.Write("■"); ;
            Thread.Sleep(500);

            
        }

        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");

        Console.WriteLine("");

        Console.WriteLine("This replaced the animation.");

        Thread.Sleep(2000);

        Console.Clear();

        Console.WriteLine("This replaced the animation.");

    }
}