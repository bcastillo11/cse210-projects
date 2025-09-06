using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Exercise5 Project.");

        DisplayWelcome();

        DisplayResult(PromptUserName(), SquareNumber(PromptUserNumber()));
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        string name = "";

        Console.Write("Please, enter your name: ");

        while (true)
        {
            name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                return name;
            }
            else
            {
                Console.Write($"'{name}': is not valid. PLease Try again");
            }
        }
    }

    static int PromptUserNumber()
    {
        int number = 0;

        Console.Write("Please, enter your favorite number: ");

        while (true)
        {
            string inputNumber = Console.ReadLine();

            try
            {
                number = int.Parse(inputNumber);

                return number;
            }
            catch (FormatException)
            {
                Console.Write($"'{inputNumber}': is not valid. Try again: ");
            }
        }
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int sqedNumber)
    {
        Console.WriteLine($"{name}, the square of your number is: {sqedNumber}");
    }
}