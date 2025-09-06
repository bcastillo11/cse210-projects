using System;
using System.Runtime.Serialization;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 50);
        int guess = 0;
        List<int> tries = new List<int>();


        Console.WriteLine($"What is the secret number? ({number})");

        do
        {
            Console.WriteLine($"Guess the number: ({number})");
            string input_guess = Console.ReadLine();

            try
            {
                guess = int.Parse(input_guess);

                tries.Add(guess);


                if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");

                    Console.WriteLine("Would you like to play again?(Y/N)");
                    string keep_playing = Console.ReadLine();

                    if (keep_playing.ToLower() == "y" || keep_playing.ToLower() == "yes")
                    {
                        number = randomGenerator.Next(1, 50);
                        tries.Clear();
                    }
                    else
                    {
                        break;
                    }
                }

                if (tries.Count > 0)
                {
                    Console.WriteLine($"You have guessed {tries.Count} times: [{string.Join(", ", tries)}]]");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine($"'{input_guess}' is not valid");
            }

        } while (true);
    }
}