// As part of showing creativity, the program has an animation in the way it displays text, as a writing machine, letter
// by letter. 
// The Reflecting Activity won't repeat the same question twice. 
// Also included an additional animation only used on the questions showed in the ReflectionActivity section. 
// Hid the cursor to  make the animaitons look cleaner. 

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int run = 0;

        while (run != 4)
        {
            Console.Clear();
            Console.Write($"Menu Options:{Environment.NewLine}    1. Start Breathing Activity{Environment.NewLine}    2. Start Reflecting Activity{Environment.NewLine}    3. Start Listing Activity{Environment.NewLine}    4. Quit{Environment.NewLine}Select a choice from the menu: ");
            string input = Console.ReadLine();

            int.TryParse(input, out run);

            if (run == 1)
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (run == 2)
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
            }
            else if (run == 3)
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
        }
        
    }
}