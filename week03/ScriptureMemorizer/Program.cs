using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        Reference reference = new Reference("1 Nefi", 3, 7);
        Scripture scripture = new Scripture(reference, "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");

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