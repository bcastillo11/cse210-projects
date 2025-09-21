using System;

// As part of exceeding the requirements, I created a new class ScriptureGenerator, which provides random 
// Scriptures by reading them from a txt file, creates a Scripture list (List<Scripture>) and returns a random 
// Scripture
// Also created a txt file containing the Scriptures (ScripturesFile.txt)

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        ScriptureGenerator sg = new ScriptureGenerator();
        Scripture scripture = sg.GetRandomScripture();

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("Press enter to continue or tipe 'quit' to finish:");
        string interaction = Console.ReadLine();

        while (true)
        {
            if (interaction.ToLower() == "quit" || scripture.IsCompletelyHidden()) break;

            if (interaction == "")
            {
                Console.Clear();
                scripture.HideRandomWords(3);
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("Press enter to continue or tipe 'quit' to finish:");
                interaction = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Sorry, please try just hitting enter or type 'quit' to finish: ");
                interaction = Console.ReadLine();
            }
        }
    }
}