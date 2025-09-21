using System;

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