using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello World! This is the Exercise2 Project.");
        int grade;
        string grade_letter = "";

        while (true)
        {
            Console.WriteLine("Enter your grade percentage: ");
            string user_input = Console.ReadLine();

            try
            {
                grade = int.Parse(user_input);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine($"'{user_input}' is not valid");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"'{user_input}' is not valid");
            }
        }

        // Define the letter

        if (grade >= 90)
        {
            grade_letter = "A";
        }
        else if (grade >= 80)
        {
            grade_letter = "B";
        }
        else if (grade >= 70)
        {
            grade_letter = "C";
        }
        else if (grade >= 60)
        {
            grade_letter = "D";
        }
        else if (grade < 60)
        {
            grade_letter = "F";
        }

        // Define the sign of the grade
        int last_digit = grade % 10;
        string sign = "";

        if (last_digit >= 7)
        {
            sign = "+";
        }
        else if (last_digit < 3)
        {
            sign = "-";
        }

        // Print the result

        if (grade >= 60)
        {
            if (grade < 90)
            {
                Console.WriteLine($"You got {grade_letter}{sign}");
                Console.WriteLine("You Passed the Course! Congratulations");
            }
            else
            {
                Console.WriteLine($"You got {grade_letter}");
                Console.WriteLine("You Passed the Course! Congratulations");
            }
        }
        else
        {
            Console.WriteLine($"You got {grade_letter}");
            Console.WriteLine("Not Approved. You can do it better next time!");
        }

        
    }
}