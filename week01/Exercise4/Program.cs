using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Exercise4 Project.");
        List<float> numbers = new List<float>();

        Console.WriteLine("Enter a secuence of numbers ('0' will end the secuence):");

        while (true)
        {
            Console.Write("Enter number: ");
            string input_number = Console.ReadLine();

            try
            {
                float number = float.Parse(input_number);

                if (number == 0)
                {
                    break;
                }

                numbers.Add(number);
            }
            catch (FormatException)
            {
                Console.WriteLine($"'{input_number}' is not valid. Try again");
            }
        }

        float sum = 0;
        float avg = 0;
        float max = numbers[0];
        float min_positive = 999999999999;

        foreach (float num in numbers)
        {
            sum = num + sum;

            if (num > max)
            {
                max = num;
            }

            if (num > 0 || num < min_positive)
            {
                min_positive = num;
            }
        }

        avg = sum / numbers.Count;

        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"Smallest positive number: {min_positive}");
        Console.WriteLine($"Sorted list: [{string.Join(",", numbers)}]");

    }
}